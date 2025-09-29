//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : TSP�A�g�}�X�^�ݒ�
// �v���O�����T�v   : TSP�A�g�}�X�^�ݒ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11670305-00  �쐬�S�� : 3H ������
// �� �� �� : 2020/11/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// TSP�A�g�}�X�^�ݒ�@DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : TSP�A�g�}�X�^�ݒ� DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date       : 2020/11/23</br>
    /// <br>�˗��ԍ�   : 11670305-00</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // �A�v���P�[�V�����T�[�o�[�̐ڑ���
    public interface ITspCprtStDB
    {
        /// <summary>
        /// �w�肳�ꂽ������TSP�A�g�}�X�^�ݒ���LIST�̌�����߂��܂��B
        /// </summary>
        /// <param name="tspCprtStWork">��������</param>
        /// <param name="tspCprtStWorkList">TSP�A�g�}�X�^�ݒ���LIST</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ������TSP�A�g�}�X�^�ݒ���LIST�̌�����߂��܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            object tspCprtStWork,
            [CustomSerializationMethodParameterAttribute("PMTSP09006D", "Broadleaf.Application.Remoting.ParamData.TspCprtStWork")]
            out object tspCprtStWorkList,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ����o�^�A�X�V���܂��B
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�ݒ����o�^�A�X�V���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMTSP09006D", "Broadleaf.Application.Remoting.ParamData.TspCprtStWork")]
            ref object tspCprtStWork
            );

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ�������S�폜���܂��B
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�ݒ�������S�폜���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            object tspCprtStWork
            );

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ����_���폜���܂��B
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�ݒ����_���폜���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTSP09006D", "Broadleaf.Application.Remoting.ParamData.TspCprtStWork")]
            ref object tspCprtStWork
            );

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ���𕜊����܂��B
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�ݒ���𕜊����܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Revival(
            [CustomSerializationMethodParameterAttribute("PMTSP09006D", "Broadleaf.Application.Remoting.ParamData.TspCprtStWork")]
            ref object tspCprtStWork
            );
    }
}