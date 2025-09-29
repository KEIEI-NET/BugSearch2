//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �d����}�X�^�i�����ݒ�jDB�C���^�[�t�F�[�X
//                  :   PMKAK09005O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   FSI�֓� �a�G
// Date             :   2012/08/29
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
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
    /// �d����}�X�^�i�����ݒ�jDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����}�X�^�i�����ݒ�jDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : FSI�֓� �a�G</br>
    /// <br>Date       : 2012/08/29</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISumSuppStDB
    {
        /// <summary>
        /// �d����}�X�^�i�����ݒ�j���𕨗��폜���܂�
        /// </summary>
        /// <param name="sumSuppStList">�����폜����d����}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����}�X�^�i�����ݒ�j�̃L�[�l����v����d����}�X�^�i�����ݒ�j���𕨗��폜���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKAK09006D", "Broadleaf.Application.Remoting.ParamData.SumSuppStWork")]
            object sumSuppStList);

        /// <summary>
        /// �d����}�X�^�i�����ݒ�j���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sumSuppStList">��������</param>
        /// <param name="sumSuppStObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����}�X�^�i�����ݒ�j�̃L�[�l����v����A�S�Ă̎d����}�X�^�i�����ݒ�j�����擾���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKAK09006D", "Broadleaf.Application.Remoting.ParamData.SumSuppStWork")]
            ref object sumSuppStList,
            object sumSuppStObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �d����}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sumSuppStList">�ǉ��E�X�V����d����}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList �Ɋi�[����Ă���d����}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKAK09006D", "Broadleaf.Application.Remoting.ParamData.SumSuppStWork")]
            ref object sumSuppStList);

        /// <summary>
        /// �d����}�X�^�i�����ݒ�j����_���폜���܂��B
        /// </summary>
        /// <param name="sumSuppStList">�_���폜����d����}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStWork �Ɋi�[����Ă���d����}�X�^�i�����ݒ�j����_���폜���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKAK09006D", "Broadleaf.Application.Remoting.ParamData.SumSuppStWork")]
            ref object sumSuppStList);

        /// <summary>
        /// �d����}�X�^�i�����ݒ�j���̘_���폜���������܂��B
        /// </summary>
        /// <param name="sumSuppStList">�_���폜����������d����}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStWork �Ɋi�[����Ă���d����}�X�^�i�����ݒ�j���̘_���폜���������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKAK09006D", "Broadleaf.Application.Remoting.ParamData.SumSuppStWork")]
            ref object sumSuppStList);
    }
}
