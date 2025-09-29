//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����N���T�[�r�X����
// �v���O�����T�v   : �����N���T�[�r�X�t�@�C����ۑ�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/09/01  �C�����e : #24278 �f�[�^������M�������N�����܂���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2014/10/02  �C�����e : �c�[���`�F�b�N�̏C��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DC�R���g���[��DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : DC�R���g���[��DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IServiceFilesDB
    {
        /// <summary>
        /// �t�@�C���ǂ�
        /// </summary>
        /// <param name="file">�t�@�C�����e</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="fileFlg">�t�@�C���t���O</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int Read([CustomSerializationMethodParameterAttribute("PMKYO09307D", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork")]
            ref object file, ref string msg, ref int fileFlg);

        // ---- ADD 杍^ 2014/10/02 ---------------------------->>>>>
        /// <summary>
        /// �t�@�C���ǂ�
        /// </summary>
        /// <param name="file">�t�@�C�����e</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="fileFlg">�t�@�C���t���O</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int Read([CustomSerializationMethodParameterAttribute("PMKYO09307D", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork")]
            ref object userFile,
                 [CustomSerializationMethodParameterAttribute("PMKYO09307D", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork")]
            ref object commFile, ref string msg, ref int fileFlg);
        // ---- ADD 杍^ 2014/10/02 ----------------------------<<<<<

        /// <summary>
        /// �t�@�C������
        /// </summary>
        /// <param name="file">�t�@�C�����e</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09307D", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork")]
            object file);


        /// <summary>
        /// �t�@�C���ǂ�
        /// </summary>
        /// <param name="file">�t�@�C�����e</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="fileFlg">�t�@�C���t���O</param>
        /// <param name="dataType">�f�[�^�^�C�v</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.09.01</br>
        [MustCustomSerialization]
        int Read([CustomSerializationMethodParameterAttribute("PMKYO09307D", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork")]
            ref object file, ref string msg, ref int fileFlg, int dataType);

        /// <summary>
        /// �t�@�C������
        /// </summary>
        /// <param name="file">�t�@�C�����e</param>
        /// <param name="dataType">�f�[�^�^�C�v</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.09.01</br>
        /// [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09307D", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork")]
            object file, int dataType);
    }
}
