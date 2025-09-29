//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   TBO�����}�X�^(���[�U�[�o�^)DB�C���^�[�t�F�[�X
//                  :   PMKEN09115O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.11.17
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
    /// TBO�����}�X�^(���[�U�[�o�^)DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : TBO�����}�X�^(���[�U�[�o�^)DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.11.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITBOSearchUDB
    {
        /// <summary>
        /// �P���TBO�����}�X�^(���[�U�[�o�^)�����擾���܂��B
        /// </summary>
        /// <param name="tboSearchUObj">TBOSearchUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^(���[�U�[�o�^)�̃L�[�l����v����TBO�����}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUObj,
            int readMode);

        /// <summary>
        /// TBO�����}�X�^(���[�U�[�o�^)���𕨗��폜���܂�
        /// </summary>
        /// <param name="tboSearchUList">�����폜����TBO�����}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^(���[�U�[�o�^)�̃L�[�l����v����TBO�����}�X�^(���[�U�[�o�^)���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            object tboSearchUList);

        /// <summary>
        /// TBO�����}�X�^(���[�U�[�o�^)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="tboSearchUList">��������</param>
        /// <param name="tboSearchUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^(���[�U�[�o�^)�̃L�[�l����v����A�S�Ă�TBO�����}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUList,
            object tboSearchUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �������̃K�C�h�p�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="tboSearchUList">��������</param>
        /// <param name="tboSearchUObj">��������</param>
        /// <param name="equipNameSrchTyp">�������̌����^�C�v 0:���S��v,1:�O����v����,2:�����v����,3:�B������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������̃K�C�h�p�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        int SearchEquipNameGuide(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUList, object tboSearchUObj, int equipNameSrchTyp);

        /// <summary>
        /// TBO�����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="tboSearchUList">�ǉ��E�X�V����TBO�����}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUList);

        /// <summary>
        /// <br>TBO�����}�X�^����o�^�A�X�V���܂�</br>
        /// <br>���ꑕ�����́A���[�J�[�R�[�h�̃f�[�^����������DELETE���A�V�K�œ��e��o�^���܂�</br>
        /// </summary>
        /// <param name="tboSearchUWork">�ǉ��E�X�V����TBO�����}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="equipGenreCode">��������</param>
        /// <param name="equipName">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUWork,
            string enterpriseCode, Int32 equipGenreCode, string equipName
           );

        /// <summary>
        /// TBO�����}�X�^(���[�U�[�o�^)����_���폜���܂��B
        /// </summary>
        /// <param name="tboSearchUList">�_���폜����TBO�����}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUWork �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)����_���폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUList);

        /// <summary>
        /// TBO�����}�X�^(���[�U�[�o�^)���̘_���폜���������܂��B
        /// </summary>
        /// <param name="tboSearchUList">�_���폜����������TBO�����}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUWork �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUList);
    }
}
