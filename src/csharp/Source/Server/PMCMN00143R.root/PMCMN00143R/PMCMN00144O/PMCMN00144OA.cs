//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �R���o�[�g�Ώێ����X�V�����e�i���X
// �v���O�����T�v   : �R���o�[�g�Ώێ����X�V���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ���X�ؘj
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �R���o�[�g�Ώێ����X�V RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώێ����X�V RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���X�ؘj</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IConvObjDB
    {
        /// <summary>
        /// �R���o�[�g�Ώێ����X�V���܂��B
        /// </summary>
        /// <param name="convObjWorkbyte">�����X�V���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώێ����X�V���܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int ConvObjAutoUpdate([CustomSerializationMethodParameterAttribute("PMCMN00145D", "Broadleaf.Application.Remoting.ParamData.ConvObjWork")]
            ref ConvObjWork convObjWorkbyte
            );

        /// <summary>
        /// ���샍�O�o��
        /// </summary>
        /// <param name="writeParam">���O�o�͏��</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���샍�O�e�[�u���Ƀ��O���o�͂���</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        int WriteOprtnHisLog(OprtnHisLogWork writeParam);

    }
}
