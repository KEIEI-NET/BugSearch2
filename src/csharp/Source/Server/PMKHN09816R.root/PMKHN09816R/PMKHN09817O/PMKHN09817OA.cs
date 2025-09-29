//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�G�N�X�|�[�gDB�C���^�[�t�F�[�X
// �v���O�����T�v   : �|���}�X�^�G�N�X�|�[�gDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-**  �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12   �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : K.Miura
// �C �� ��  2015/10/14   �C�����e : �N���X���d���̂��ߕύX 
//                                   StockMasWork �� RateTextWork
//                                   IStockMasDB �� IRateTextDB
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
    /// �|���}�X�^�G�N�X�|�[�gDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^�G�N�X�|�[�gDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : 2013/06/12 </br>
    /// <br></br>
    /// <br>Update Note: �|�����}�X�^�C���|�[�g�E�G�N�X�|�[�g�@�\�ǉ��Ή�</br>
    /// <br>Programmer : 30521 T.MOTOYAMA</br>
    /// <br>Date       : 2013.10.28</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    // --- CHG  2015/10/14 K.Miura --- >>>>
    // public interface IStockMasDB
    public interface IRateTextDB
    // --- CHG  2015/10/14 K.Miura --- <<<<
    {
        /// <summary>
        /// �|���}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outList">��������</param>
        /// <param name="paraWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���}�X�^�̃L�[�l����v����A�S�Ă̊|���}�X�^�����擾���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        [MustCustomSerialization]
        // --- CHG  2015/10/14 K.Miura --- >>>>
        //int Search([CustomSerializationMethodParameterAttribute("PMKHN09818D", "Broadleaf.Application.Remoting.ParamData.StockMasWork")]
        //           out object outList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode);
        int Search([CustomSerializationMethodParameterAttribute("PMKHN09818D", "Broadleaf.Application.Remoting.ParamData.RateTextWork")]
                   out object outList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode);
        // --- CHG  2015/10/14 K.Miura --- <<<<

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        /// <summary>
        /// �|���ݒ�}�X�^����o�^�A�X�V���܂�(�|�����}�X�^ �C���|�[�g�E�G�N�X�|�[�g�p)
        /// </summary>
        /// <param name="RateWork">RateWork�I�u�W�F�N�g</param>
        /// <param name="writestatus">�X�V�����@1:�ǉ��@2:�X�V�@3:�ǉ��{�X�V</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30521 T.MOTOYAMA</br>
        /// <br>Date       : 2013.10.28</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
			ref object RateWork, int writestatus
            );
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
    }
}