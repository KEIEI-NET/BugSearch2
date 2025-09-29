//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ������
// �v���O�����T�v   : ���������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ���X�ؘj
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ������ RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������ RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���X�ؘj</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEnvSurvObjDB
    {
        /// <summary>
        /// �S�̃o�b�N�A�b�v���擾
        /// </summary>
        /// <param name="envFullBackupInf">�S�̃o�b�N�A�b�v���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int EnvFullBackupInfSearch([CustomSerializationMethodParameterAttribute("PMCMN00155D", "Broadleaf.Application.Remoting.ParamData.EnvFullBackupInfWork")]
            out object envFullBackupInf
            );

        /// <summary>
        /// �}�X�^�����擾
        /// </summary>
        /// <param name="mstCount">�}�X�^����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int PriceMstInfCntSearch(out Int32 mstCount);

    }
}
