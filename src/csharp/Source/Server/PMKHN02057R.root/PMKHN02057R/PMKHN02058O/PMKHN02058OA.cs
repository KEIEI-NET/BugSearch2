//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[�����ѕ\
// �v���O�����T�v   : �L�����y�[�����ѕ\�@DBRemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/05/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �L�����y�[�����ѕ\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[�����ѕ\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2011/05/19</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignRsltListResultDB
    {
        #region
        /// <summary>
        /// �A�N�Z�X�N���X�����n���ꂽ��ƃR�[�h�ŁA�o�^��������f�[�^�i�`�[��ʁF����j�̒��o���s���B
        /// </summary>
        /// <param name="campaignstRsltListSalesWork">��������1</param>
        /// <param name="campaignstRsltListTargetWork">��������2</param>
        /// <param name="campaignstRsltListPrtWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[�����уf�[�^��߂��܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN02059D", "Broadleaf.Application.Remoting.ParamData.CampaignstRsltListResultWork")]
			out object campaignstRsltListSalesWork,
            out object campaignstRsltListTargetWork,
            object campaignstRsltListPrtWork);

        #endregion
    }
}
