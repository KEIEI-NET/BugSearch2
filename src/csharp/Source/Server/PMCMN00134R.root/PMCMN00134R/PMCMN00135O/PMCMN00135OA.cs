//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^�����e�i���X
// �v���O�����T�v   : �R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^�̓o�^�E�ύX���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ���X�ؘj
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���X�ؘj</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IConvObjVerMngDB
    {
        /// <summary>
        /// �R���o�[�g�Ώۃo�[�W�����Ǘ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="outConvObjVerMng">��������</param>
        /// <param name="paraConvObjVerMngWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώۃo�[�W�����Ǘ�LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMCMN00136D", "Broadleaf.Application.Remoting.ParamData.ConvObjVerMngWork")]
			out object outConvObjVerMng,
            object paraConvObjVerMngWork);
    }
}
