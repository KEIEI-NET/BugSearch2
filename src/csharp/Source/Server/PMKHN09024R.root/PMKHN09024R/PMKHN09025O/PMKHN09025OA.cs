//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �d����}�X�^DB�C���^�[�t�F�[�X
//                  :   PMKHN09025O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc�@��
// Date             :   2008.4.24
//----------------------------------------------------------------------
// Update Note      :
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
    /// �d����}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2008.4.24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISupplierDB
    {
        /// <summary>
        /// �P��̎d����}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="parabyte">SupplierWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����}�X�^�̃L�[�l����v����d����}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.4.24</br>
        int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// �d����}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">SupplierWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����}�X�^�̃L�[�l����v����d����}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.4.24</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// �d����}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outsupplierList">��������</param>
        /// <param name="parasupplierWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����}�X�^�̃L�[�l����v����A�S�Ă̎d����}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.4.24</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMKHN09026D", "Broadleaf.Application.Remoting.ParamData.SupplierWork")]
                   out object outsupplierList, object parasupplierWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
        /// <summary>
        /// �d����}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outsupplierList">��������</param>
        /// <param name="parasupplierWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x����R�[�h����v����A�S�Ă̎d����}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22018�@��� ���b</br>
        /// <br>Date       : 2009.5.27</br>
        [MustCustomSerialization]
        int SearchWithChildren( [CustomSerializationMethodParameterAttribute( "PMKHN09026D", "Broadleaf.Application.Remoting.ParamData.SupplierWork" )]
                   out object outsupplierList, object parasupplierWork, int readMode, ConstantManagement.LogicalMode logicalMode );
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD

        /// <summary>
        /// �d����}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="supplierWork">�ǉ��E�X�V����d����}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork �Ɋi�[����Ă���d����}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.4.24</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKHN09026D", "Broadleaf.Application.Remoting.ParamData.SupplierWork")]
                  ref object supplierWork);

        /// <summary>
        /// �d����}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="supplierWork">�_���폜����d����}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork �Ɋi�[����Ă���d����}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.4.24</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMKHN09026D", "Broadleaf.Application.Remoting.ParamData.SupplierWork")]
                          ref object supplierWork);

        /// <summary>
        /// �d����}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="supplierWork">�_���폜����������d����}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork �Ɋi�[����Ă���d����}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.4.24</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMKHN09026D","Broadleaf.Application.Remoting.ParamData.SupplierWork")]
                                 ref object supplierWork);
    }
}
