//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : BL�R�[�h�ϊ��}�X�^�擾�ݒ�}�X�^�����e
// �v���O�����T�v   : BL�R�[�h�ϊ��}�X�^�擾�ݒ�}�X�^�����eDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g�� �F�� 30745
// �� �� ��  2012/08/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
    /// BL�R�[�h�ϊ��}�X�^�擾�ݒ�}�X�^�����eDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : BL�R�[�h�ϊ��}�X�^�擾�ݒ�}�X�^�����eDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �g�� �F�� 30745</br>
    /// <br>Date       :2012/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IBLGoodsCdChgUDB
    {

        /// <summary>
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="blCodeChangeObj">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       :2012/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork")]
            ref object blCodeChangeObj,
            int readMode);


        /// <summary>
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       :2012/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork")]
            ref object blCodeChangeList);

        /// <summary>
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <param name="blCodeChangeObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       :2012/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork")]
            ref object blCodeChangeList,
            BLGoodsCdChgUWork blCodeChangeObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       :2012/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork")]
            ref object blCodeChangeList);

        /// <summary>
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       :2012/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork")]
            ref object blCodeChangeList);


        /// <summary>
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       :2012/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork")]
            ref object blCodeChangeList);



    }
}