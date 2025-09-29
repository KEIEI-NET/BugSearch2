//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����e�i���X
// �v���O�����T�v   : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���c�`�[
// �� �� ��  2020/02/20  �C�����e : �V�K�쐬
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���c�`�[</br>
    /// <br>Date       : 2020.02.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISAndEMkrGdsCdChgSetDB
    {
        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">SAndEMkrGdsCdChgWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̃L�[�l����v���郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMSAE09046D", "Broadleaf.Application.Remoting.ParamData.SAndEMkrGdsCdChgWork")]
            ref object objectSAndEMkrGdsCdChgWork);

        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outSAndEMkrGdsCdChgWorkList">��������</param>
        /// <param name="paraSAndEMkrGdsCdChgSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̃L�[�l����v����A�S�Ẵ��[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMSAE09046D", "Broadleaf.Application.Remoting.ParamData.SAndEMkrGdsCdChgWork")]
            out object outSAndEMkrGdsCdChgWorkList, object paraSAndEMkrGdsCdChgSetWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">�ǉ��E�X�V���郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <param name="writeMode">�X�V�敪</param>
        /// <br>Note       : SAndEMkrGdsCdChgWork �Ɋi�[����Ă��郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMSAE09046D", "Broadleaf.Application.Remoting.ParamData.SAndEMkrGdsCdChgWork")]
            ref object objectSAndEMkrGdsCdChgWork, int writeMode);

        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">�_���폜���郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork �Ɋi�[����Ă��郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMSAE09046D", "Broadleaf.Application.Remoting.ParamData.SAndEMkrGdsCdChgWork")]
            ref object objectSAndEMkrGdsCdChgWork);

        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">�_���폜���������郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork �Ɋi�[����Ă��郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMSAE09046D", "Broadleaf.Application.Remoting.ParamData.SAndEMkrGdsCdChgWork")]
            ref object objectSAndEMkrGdsCdChgWork);
    }
}
