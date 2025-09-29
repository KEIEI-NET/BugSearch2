//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���N�n��</br>
    /// <br>Date       : 2011/05/20</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignLoginDB
    {
    
        /// <summary>
        /// ���i�}�X�^(���[�U�[)��������
        /// </summary>
        /// <param name="campaignGoodsDataWorkList">��������</param>
        /// <param name="campaignGoodsDataWork">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			ref object campaignGoodsDataWorkList,
            object campaignGoodsDataWork
           );

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^��������
        /// </summary>
        /// <param name="campaignMngList">��������</param>
        /// <param name="campaignGoodsDataWork">��������</param>
        /// <param name="readMode">readMode</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignMngWork")]
			ref object campaignMngList,
            object campaignGoodsDataWork, 
            int readMode
           );

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�̓o�^����
        /// </summary>
        /// <param name="campaignGoodsDataWorkList">�o�^�i�����X�g</param>
        /// <param name="campaignGoodsData">����</param>
        /// <param name="objcampaignLinklist">���Ӑ惊�X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �o�^�������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        int Write(
        [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignMngWork")]
			object campaignGoodsDataWorkList, 
            object campaignGoodsData, 
            object objcampaignLinklist
      �@ );

        /// <summary>
        /// �L�����y�[�����̐ݒ�}�X�^��������
        /// </summary>
        /// <param name="campaignStList">��������</param>
        /// <param name="CampaignStWork">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�����̐ݒ�}�X�^�����������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchCampaignSt(
            [CustomSerializationMethodParameterAttribute("PMKHN09566D", "Broadleaf.Application.Remoting.ParamData.CampaignStWork")]
            ref object campaignStList,
            object CampaignStWork
           );

        /// <summary>
        /// �L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^��������
        /// </summary>
        /// <param name="searchParaObj">��������</param>
        /// <param name="objcampaignLinkList">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^�����������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchCustomer(
            [CustomSerializationMethodParameterAttribute("PMKHN09576D", "Broadleaf.Application.Remoting.ParamData.CampaignLinkWork")]
            object searchParaObj,
            ref object objcampaignLinkList
          ); 
    }
}
