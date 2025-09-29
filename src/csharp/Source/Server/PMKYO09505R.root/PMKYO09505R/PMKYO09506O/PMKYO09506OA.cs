//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ����O�Q�ƃc�[��
// �v���O�����T�v   : ����M�����̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �� �� ��  2012/07/23  �C�����e : �V�K�쐬
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
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DC����M�����@�����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����M����DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2012/07/23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Center_UserAP)]
    public interface ISndRcvHisTableDB
    {
        # region �J�X�^���V���A���C�Y
        /// <summary>
        /// ����M��������o�^�A�X�V���܂�
        /// </summary>
        /// <param name="sndRcvHisTableList">����M�������O�u�W�F�N�g���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M��������o�^�A�X�V���܂�</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2012/07/23</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09507D", "Broadleaf.Application.Remoting.ParamData.SndRcvHisTableWork")]
            ref object sndRcvHisTableList);

        /// <summary>
        /// ����M����LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="sndRcvHisConWork">�����p�����[�^</param>
        /// <param name="retList1">����M������������</param>
        /// <param name="retList2">����M���o�����������O�f�[�^��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2012/07/23</br>
        [MustCustomSerialization]
        int Search(
            SndRcvHisConWork sndRcvHisConWork,
            [CustomSerializationMethodParameterAttribute("PMKYO09507D", "Broadleaf.Application.Remoting.ParamData.SndRcvHisTableWork")]
            out object retList1,
            [CustomSerializationMethodParameterAttribute("PMKYO09407D", "Broadleaf.Application.Remoting.ParamData.SndRcvEtrWork")]
            out object retList2);

        /// <summary>
        /// ����M�������𕨗��폜
        /// </summary>
        /// <param name="paraList">�����폜���I�u�W�F�N�g���X�g</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMKYO09507D", "Broadleaf.Application.Remoting.ParamData.SndRcvHisTableWork")]
                   ref object paraList);

        #endregion
    }
}
