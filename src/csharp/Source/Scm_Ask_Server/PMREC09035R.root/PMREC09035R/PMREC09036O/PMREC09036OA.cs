//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����������i�O���[�v�ݒ�}�X�^
// �v���O�����T�v   : �����������i�O���[�v�ݒ�}�X�^DB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X�� �j
// �� �� ��  2015/02/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����������i�O���[�v�ݒ�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����������i�O���[�v�ݒ�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ��������</br>
    /// <br>Date       : 2015/02/23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    //[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRecBgnGrpDB
    {

        /// <summary>
        /// ���������i���������i�O���[�v�}�X�^�S�������j
        /// </summary>
        /// <param name="retobj">RecBgnGrpWork�������ʃf�[�^���X�g</param>
        /// <param name="cnectOtherEpCd">PM���Њ�ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</param>
        /// <param name="count">����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMREC09037D", "Broadleaf.Application.Remoting.ParamData.RecBgnGrpWork")]
            out object retobj,
            string cnectOtherEpCd,
            ConstantManagement.LogicalMode logicalMode,
            out int count, 
            ref string errMsg);

        /// <summary>
        /// ���������i���������i�O���[�v�}�X�^�����j
        /// </summary>
        /// <param name="retobj">RecBgnGrpWork�������ʃf�[�^���X�g</param>
        /// <param name="paraobj">RecBgnGrpSearchParaWork�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</param>
        /// <param name="count">����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMREC09037D", "Broadleaf.Application.Remoting.ParamData.RecBgnGrpWork")]
            out object retobj,
            object paraobj,
            ConstantManagement.LogicalMode logicalMode,
            out int count,
            ref string errMsg);

    }
}