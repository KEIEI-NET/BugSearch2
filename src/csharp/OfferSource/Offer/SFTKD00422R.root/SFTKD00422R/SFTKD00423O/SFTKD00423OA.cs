using System;
using System.Collections;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Runtime;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �����[�e�B���O�I�u�W�F�N�g�p�C���^�[�t�F�C�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IOfferAddressInfo
	{
        /// <summary>
        /// �Z�������擾����ʐM�����f�[�^�ɂ͈��k�������{����܂�
        /// </summary>
        /// <param name="paraAddressWork"></param>
        /// <param name="retList"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int SearchAddressWork(AddressWork paraAddressWork, [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]out object retList);

        /// <summary>
        /// �Z�������擾���܂��B
        /// </summary>
        /// <param name="addrIndex"></param>
        /// <param name="alResult"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetAddressWork(AddressWork addrIndex,
            [CustomSerializationMethodParameterAttribute("SFTKD00424D", "Broadleaf.Application.Remoting.ParamData.AddressWork")]out object alResult);
				
        /// <summary>
        /// �S�Z���}�X�^�X�V�Ǘ��}�X�^���擾����
        /// </summary>
        /// <param name="objAddrUpdMngList"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int SearchAddrUpdMng([CustomSerializationMethodParameterAttribute("SFTKD00424D", "Broadleaf.Application.Remoting.ParamData.AddrUpdMngWork")]out object objAddrUpdMngList);

        /// <summary>
        /// �Z���}�X�^�Z���R�[�h�C���f�b�N�X�}�X�^�ƏZ���}�X�^�X�֔ԍ��C���f�b�N�X�}�X�^���擾����
        /// </summary>
        /// <param name="objAddrCdIndxList"></param>
        /// <param name="objPostNoIndxList"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int SearchAddrCdIndxAndPostNoIndx([CustomSerializationMethodParameterAttribute("SFTKD00424D", "Broadleaf.Application.Remoting.ParamData.AddrCdIndxWork")]out object objAddrCdIndxList, [CustomSerializationMethodParameterAttribute("SFTKD00424D", "Broadleaf.Application.Remoting.ParamData.PostNoIndxWork")]out object objPostNoIndxList);

	}
}
