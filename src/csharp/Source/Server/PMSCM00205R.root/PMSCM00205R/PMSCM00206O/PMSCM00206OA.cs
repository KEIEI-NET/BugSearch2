//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �ȒP�⍇���ڑ����DB�C���^�[�t�F�[�X
//                  :   PMSCM00206O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21024�@���X�� ��
// Date             :   2010/03/25
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ȒP�⍇���ڑ����DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ȒP�⍇���ڑ����DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/03/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISimplInqCnectInfoDB
    {
        /// <summary>
        /// �ȒP�⍇���ڑ��������폜���܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="simplInqCnectInfoList">�����폜����ȒP�⍇���ڑ��������܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ȒP�⍇���ڑ����̃L�[�l����v����ȒP�⍇���ڑ������𕨗��폜���܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        int Delete(
            string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMSCM00207D", "Broadleaf.Application.Remoting.ParamData.SimplInqCnectInfoWork")]
            object simplInqCnectInfoList);

        /// <summary>
        /// �ȒP�⍇���ڑ������̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="simplInqCnectInfoList">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ȒP�⍇���ڑ����̃L�[�l����v����A�S�Ă̊ȒP�⍇���ڑ��������擾���܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        [MustCustomSerialization]
        int Search(
            string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMSCM00207D", "Broadleaf.Application.Remoting.ParamData.SimplInqCnectInfoWork")]
            out object simplInqCnectInfoList);

        /// <summary>
        /// �ȒP�⍇���ڑ�������ǉ����܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="simplInqCnectInfoList">�ǉ��E�X�V����ȒP�⍇���ڑ��������܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : simplInqCnectInfoList �Ɋi�[����Ă���ȒP�⍇���ڑ�������ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        int Write(
            string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMSCM00207D", "Broadleaf.Application.Remoting.ParamData.SimplInqCnectInfoWork")]
            object simplInqCnectInfoList);
    }
}
