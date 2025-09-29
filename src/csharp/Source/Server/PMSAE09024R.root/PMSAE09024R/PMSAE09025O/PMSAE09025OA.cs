//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^�����e�i���X
// �v���O�����T�v   : ���i�R�[�h�ϊ��̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/08/05  �C�����e : �V�K�쐬
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
    /// �I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.08.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISAndEGoodsCdChgSetDB
    {
        /// <summary>
        /// �I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="objectSAndEGoodsCdChgWork">SAndEGoodsCdChgWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�R�[�h�ϊ��}�X�^�̃L�[�l����v���鏤�i�R�[�h�ϊ��}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMSAE09026D", "Broadleaf.Application.Remoting.ParamData.SAndEGoodsCdChgWork")]
            ref object objectSAndEGoodsCdChgWork);

        /// <summary>
        /// �I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outSAndEGoodsCdChgWorkList">��������</param>
        /// <param name="paraSAndEGoodsCdChgSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�R�[�h�ϊ��}�X�^�̃L�[�l����v����A�S�Ă̏��i�R�[�h�ϊ��}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMSAE09026D", "Broadleaf.Application.Remoting.ParamData.SAndEGoodsCdChgWork")]
            out object outSAndEGoodsCdChgWorkList, object paraSAndEGoodsCdChgSetWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="objectsAndEGoodsCdChgWork">�ǉ��E�X�V���鏤�i�R�[�h�ϊ��}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <param name="writeMode">�X�V�敪</param>
        /// <br>Note       : SAndEGoodsCdChgWork �Ɋi�[����Ă��鏤�i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMSAE09026D", "Broadleaf.Application.Remoting.ParamData.SAndEGoodsCdChgWork")]
            ref object objectsAndEGoodsCdChgWork, int writeMode);

        /// <summary>
        /// �I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="objectsAndEGoodsCdChgWork">�_���폜���鏤�i�R�[�h�ϊ��}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork �Ɋi�[����Ă��鏤�i�R�[�h�ϊ��}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMSAE09026D", "Broadleaf.Application.Remoting.ParamData.SAndEGoodsCdChgWork")]
            ref object objectsAndEGoodsCdChgWork);

        /// <summary>
        /// �I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="objectsAndEGoodsCdChgWork">�_���폜���������鏤�i�R�[�h�ϊ��}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork �Ɋi�[����Ă��鏤�i�R�[�h�ϊ��}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMSAE09026D", "Broadleaf.Application.Remoting.ParamData.SAndEGoodsCdChgWork")]
            ref object objectsAndEGoodsCdChgWork);
    }
}
