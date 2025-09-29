//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�������i�}�X�^
// �v���O�����T�v   : ���R�������i�}�X�^ DBRemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/04/30  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���R�������i�}�X�^�pDB Access RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�������i�}�X�^�pDB Access RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���`</br>
    /// <br>Date       : 2010/04/30</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IFreeSearchPartsDB
    {
        /// <summary>
        /// ���R�������i�}�X�^��������
        /// </summary>
        /// <param name="paraWork">���R�������i�}�X�^�����N���X</param>
        /// <param name="retList">���ʃR���N�V����</param>
        /// <param name="readMode">�����敪�i���݁A���g�p�j</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�������i�}�X�^�����������s���N���X�ł��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(object paraWork, 
            [CustomSerializationMethodParameterAttribute("PMJKN09017D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsWork")]
            out object retList,
           int readMode, 
           ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �w�肳�ꂽ�����̎��R�������i�f�[�^�o�^�A�X�V
        /// </summary>
        /// <param name="paraObjList">���R�������i�I�u�W�F�N�g���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��R�������i�f�[�^��o�^�A�X�V���܂�</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameter("PMJKN09017D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsWork")] 
            ref object paraObjList);

        /// <summary>
        /// �w�肳�ꂽ�����̎��R�������i�f�[�^�����폜
        /// </summary>
        /// <param name="paraObjList">���R�������i�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��R�������i�f�[�^�𕨗��폜���܂�</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameter("PMJKN09017D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsWork")] 
            object paraObjList);

        /// <summary>
        /// �w�肳�ꂽ�����̎��R�������i�f�[�^�o�^�A�X�V�ƕ����폜
        /// </summary>
        /// <param name="writeParaObjList">���R�������i�I�u�W�F�N�g���X�g</param>
        /// <param name="deleteParaObjList">���R�������i�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��R�������i�f�[�^��o�^�A�X�V�ƕ����폜���܂�</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        [MustCustomSerialization]
        int WriteAndDelete(
            [CustomSerializationMethodParameter("PMJKN09017D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsWork")] 
            ref object writeParaObjList,
            object deleteParaObjList);
    }
}
