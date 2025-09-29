//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�����e�i���X
// �v���O�����T�v   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/08/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���jDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���jDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2010/08/10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRateProtyMngPatternDB
    {
        /// <summary>
        /// �|���D��Ǘ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outRateProtyMngList">��������</param>
        /// <param name="paraRateProtyMngWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������ɂ��|���D��Ǘ��}�X�^���̃��X�g���擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        [MustCustomSerialization]
        int Search(out object outRateProtyMngList, object paraRateProtyMngWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���o�����ɂ���ĂŊ|���|���}�X�^�ƃ}�X�^��ǂݍ��ݏ���
        /// </summary>
        /// <param name="newList">�V�K���X�g</param>
        /// <param name="updateList">�|���}�X�^(�X�V���X�g)</param>
        /// <param name="paraRateProtyMngPatternWork">rateProtyMngPatternWork</param>
        /// <param name="patternMode">���[�h(0:BL�R�[�h;1:�i�Ԏw��;2:�i�Ԏw��;3:�i�Ԏw��;4:���i�|��G�w��;5:���i�|��G�w��;6:���i�|��G�w��;7:���[�J�[�w��)</param>
        /// <param name="readMode">readMode</param>
        /// <param name="logicalMode">logicalMode</param>
        /// <returns>���o���</returns>
        /// <remarks>
        /// <br>Note       : ���o�����ɂ���ĂŊ|���|���}�X�^�ƃ}�X�^��ǂݍ��݂܂��B </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchRateRelationData([CustomSerializationMethodParameterAttribute("PMKHN09484D", "Broadleaf.Application.Remoting.ParamData.RateRlationWork")]
            out object newList, out object updateList, object paraRateProtyMngPatternWork, int patternMode, int readMode, ConstantManagement.LogicalMode logicalMode);


        /// <summary>
        /// �|���}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="updateList">�|���}�X�^���X�g(�X�V�p)</param>
        /// <param name="deleteList">�|���}�X�^���X�g(�폜�p)</param>
        /// <param name="patternMode">patternMode(0:�ʏ�;1:�w��)</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        [MustCustomSerialization]
        int WriteRateRelationData(
            ArrayList updateList, ArrayList deleteList, int patternMode,
            out string retMessage);
    }
}
