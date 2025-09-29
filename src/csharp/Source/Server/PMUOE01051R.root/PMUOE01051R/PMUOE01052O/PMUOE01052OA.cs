//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE�����f�[�^DB�C���^�[�t�F�[�X
//                  :   PMUOE01052O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.07.16
//----------------------------------------------------------------------
// Update Note      :   2018/06/20  miyatsu
//                      �s�v�ɂȂ����ߋ��̔����f�[�^�����x�Ɉ��e����^�����
//                      ���t�w��ňꊇ�����폜���鏈����ǉ�
//                      (PMKHN02060:�����ς݃f�[�^�폜�c�[���Ŏg�p)
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11400910-00  �쐬�S�� : �c����
// �� �� ��  2018/07/26   �C�����e : Redmine#49725 UOE�����f�[�^�폜�����Ή�
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
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
    /// UOE�����f�[�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE�����f�[�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.07.16</br>
    /// <br>Update Note: Redmine#49725 UOE�����f�[�^�폜�����Ή�</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2018/07/26</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUOEOrderDtlDB
    {
        /// <summary>
        /// �P���UOE�����f�[�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlObj">UOEOrderDtlWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����UOE�����f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlObj,
            int readMode);

        /// <summary>
        /// UOE�����f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeOrderDtlList">�����폜����UOE�����f�[�^�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����UOE�����f�[�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            object uoeOrderDtlList);

        //2018/06/20 ADD >>>>
        /// <summary>
        /// UOE�����f�[�^�����ꊇ�����폜���܂�
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����Ɉ�v����UOE�����f�[�^�����ꊇ�����폜���܂��B</br>
        /// <br>Programmer : 30365 miyatsu</br>
        /// <br>Date       : 2018/06/20</br>
        // ---UPD �c���� 2018/07/26 Redmine#49725 UOE�����f�[�^�폜�����Ή� ------>>>>>
        //int DeleteForce(
        //    string enterpriseCode,
        //    int sectionCode,
        //    int inputDay,
        //    out int delcnt);
        int DeleteForce(
            string enterpriseCode,
            string sectionCode,
            int inputDay,
            out int delcnt);
        // ---UPD �c���� 2018/07/26 Redmine#49725 UOE�����f�[�^�폜�����Ή� ------<<<<<
        //2018/06/20 ADD <<<<

        /// <summary>
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">��������</param>
        /// <param name="uoeOrderDtlObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList,
            object uoeOrderDtlObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// UOE�����f�[�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�ǉ��E�X�V����UOE�����f�[�^�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlList �Ɋi�[����Ă���UOE�����f�[�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList);

        /// <summary>
        /// UOE�����f�[�^����_���폜���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�_���폜����UOE�����f�[�^�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlWork �Ɋi�[����Ă���UOE�����f�[�^����_���폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList);

        /// <summary>
        /// UOE�����f�[�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�_���폜����������UOE�����f�[�^�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlWork �Ɋi�[����Ă���UOE�����f�[�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D","Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList);

        /// <summary>
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">��������</param>
        /// <param name="paraobj">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        [MustCustomSerialization]
        int UoeOdrDtlGodsReadAll(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList, object paraobj);

    }
}
