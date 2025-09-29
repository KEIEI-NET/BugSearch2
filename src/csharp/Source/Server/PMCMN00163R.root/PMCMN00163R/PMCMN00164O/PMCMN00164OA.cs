//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �R���o�[�g�Ώۃo�b�N�A�b�v�����e�i���X
// �v���O�����T�v   : �R���o�[�g�Ώۃo�b�N�A�b�v���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ����
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �R���o�[�g�Ώۃo�b�N�A�b�v RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώۃo�b�N�A�b�v RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IConvObjSingleBkDB
    {
        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�v���܂��B
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώۃo�b�N�A�b�v���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int ConvObjSingleBackupExec([CustomSerializationMethodParameterAttribute("PMCMN00165D", "Broadleaf.Application.Remoting.ParamData.ConvObjSingleBkWork")]
            ref ConvObjSingleBkWork ConvObjSingleBkWork
            );

        /// <summary>
        /// ���샍�O�o��
        /// </summary>
        /// <param name="writeParam">���O�o�͏��</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���샍�O�e�[�u���Ƀ��O���o�͂���</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        int WriteOprtnHisLog(OprtnHisLogWork writeParam);

    }
}
