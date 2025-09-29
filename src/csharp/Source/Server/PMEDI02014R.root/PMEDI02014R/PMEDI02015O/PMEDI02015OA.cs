//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����f�[�^�e�L�X�g�o�� DBRemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : ����f�[�^�e�L�X�g�o�͂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11370098-00  �쐬�S�� : ���O
// �� �� ��  2017/11/20   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary> 
    /// ����f�[�^�e�L�X�gDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^�e�L�X�gDB�C���^�[�t�F�[�X�ł�.</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/11/20</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEDISalesResultDB
    {
        #region Search
        /// <summary>
        /// ����f�[�^�e�L�X�g��񃊃X�g�̎擾�����B
        /// </summary>
        /// <param name="eDISalesResultObj">��������</param>
        /// <param name="eDISalesCndtnObj">��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�̃L�[�l����v����A�S�Ă̔���f�[�^�e�L�X�g�����擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMEDI02016D", "Broadleaf.Application.Remoting.ParamData.EDISalesResultWork")]
            out object eDISalesResultObj,
           object eDISalesCndtnObj);
        #endregion

        #region Write
        /// <summary>
        /// ����f�[�^�e�L�X�g���̒ǉ��E�X�V�����B
        /// </summary>
        /// <param name="eDISalesResultWorkObj">�ǉ��E�X�V���锄��f�[�^�e�L�X�g���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDISalesResultWork �Ɋi�[����Ă��锄��f�[�^�e�L�X�g����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMEDI02016D", "Broadleaf.Application.Remoting.ParamData.EDISalesResultWork")]
            ref object eDISalesResultWorkObj);
        #endregion

    }
}
