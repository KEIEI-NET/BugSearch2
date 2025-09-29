//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignGoodsStDB
    {
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="searchParaObj">��������</param>
        /// <param name="objCampaignMngStWorkList">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            object searchParaObj,
            [CustomSerializationMethodParameterAttribute("PMKHN09647D", "Broadleaf.Application.Remoting.ParamData.CampaignMngStWork")]
            ref object objCampaignMngStWorkList);

        /// <summary>
        /// �ꊇ�폜����
        /// </summary>
        /// <param name="deleteParaObj">�폜����</param>
        /// <param name="campaignGoodsListobj">�r����������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ꊇ�폜�������s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int DeleteAll(
            object campaignGoodsListobj,
            [CustomSerializationMethodParameterAttribute("PMKHN09647D", "Broadleaf.Application.Remoting.ParamData.CampaignGoodsDataWork")]
            ref object deleteParaObj);
    }
}
