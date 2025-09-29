//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE ������}�X�^DB�C���^�[�t�F�[�X
//                  :   PMUOE09025O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 �D�c �E�l
// Date             :   2008.06.06
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
    /// UOE ������}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE ������}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUOESupplierDB
    {
        /// <summary>
        /// �P���UOE ������}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeSupplierObj">UOESupplierWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ������}�X�^�̃L�[�l����v����UOE ������}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMUOE09026D", "Broadleaf.Application.Remoting.ParamData.UOESupplierWork")]
            ref object uoeSupplierObj,
            int readMode);

        /// <summary>
        /// UOE ������}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeSupplierList">�����폜����UOE ������}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ������}�X�^�̃L�[�l����v����UOE ������}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMUOE09026D", "Broadleaf.Application.Remoting.ParamData.UOESupplierWork")]
            object uoeSupplierList);

        /// <summary>
        /// UOE ������}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeSupplierList">��������</param>
        /// <param name="uoeSupplierObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ������}�X�^�̃L�[�l����v����A�S�Ă�UOE ������}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMUOE09026D", "Broadleaf.Application.Remoting.ParamData.UOESupplierWork")]
            ref object uoeSupplierList,
           object uoeSupplierObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// UOE ������}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeSupplierList">�ǉ��E�X�V����UOE ������}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierList �Ɋi�[����Ă���UOE ������}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMUOE09026D", "Broadleaf.Application.Remoting.ParamData.UOESupplierWork")]
            ref object uoeSupplierList);

        /// <summary>
        /// UOE ������}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="uoeSupplierList">�_���폜����UOE ������}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierWork �Ɋi�[����Ă���UOE ������}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE09026D", "Broadleaf.Application.Remoting.ParamData.UOESupplierWork")]
            ref object uoeSupplierList);

        /// <summary>
        /// UOE ������}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="uoeSupplierList">�_���폜����������UOE ������}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierWork �Ɋi�[����Ă���UOE ������}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE09026D","Broadleaf.Application.Remoting.ParamData.UOESupplierWork")]
            ref object uoeSupplierList);
    }
}
