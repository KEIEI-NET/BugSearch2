//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : TSP���M�f�[�^�쐬 DBRemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : TSP���M�f�[�^�쐬 DBRemoteObject�C���^�[�t�F�[�X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670305-00 �쐬�S�� : ���O
// �� �� ��  2020/11/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// TSP���M�f�[�^�쐬 DBRemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : TSP���M�f�[�^�쐬 DBRemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2020/11/20</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITspSdRvDataDB
    {
        #region
        /// <summary>
        /// ���ʒʔԂ��̔Ԃ��܂��B
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h���w�肵�܂��B</param>
        /// <param name="sectioncode">���_�R�[�h���w�肵�܂��B</param>
        /// <param name="commonseqno">�̔Ԃ������ʒʔԂ�Ԃ��܂��B</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���ʒʔԂ��̔Ԃ��܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        int GetTspCommonSeqNo(
            string enterprisecode, 
            string sectioncode, 
            out Int64 commonseqno);

        /// <summary>
        /// �w�肳�ꂽ������TSP���׃f�[�^LIST�̌�����߂��܂��B
        /// </summary>
        /// <param name="tspDtlWorkPara">��������</param>
        /// <param name="tspDtlWorkList">TSP���׃f�[�^LIST</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ������TSP���׃f�[�^LIST�̌�����߂��܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            TspDtlWork tspDtlWorkPara,
            [CustomSerializationMethodParameterAttribute("PMTSP01206D", "Broadleaf.Application.Remoting.ParamData.TspDtlWork")]
            out object tspDtlWorkList
            );

        /// <summary>
        /// TSP���׃f�[�^��o�^�A�X�V���܂��B
        /// </summary>
        /// <param name="tspDtlWork">TSP�A�g�}�X�^�ݒ���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP���׃f�[�^��o�^�A�X�V���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMTSP01206D", "Broadleaf.Application.Remoting.ParamData.TspDtlWork")]
            ref object tspDtlWork
            );

        /// <summary>
        /// TSP���׃f�[�^�����S�폜���܂��B
        /// </summary>
        /// <param name="tspDtlWork">TSP���׃f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP���׃f�[�^�����S�폜���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            object tspDtlWork
            );
        #endregion
    }
}
