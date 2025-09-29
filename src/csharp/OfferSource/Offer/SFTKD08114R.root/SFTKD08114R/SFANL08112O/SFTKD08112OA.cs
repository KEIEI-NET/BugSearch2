using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���R���[�󎚍���DBRemoteObject�C���^�[�t�F�[�X	
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�󎚍��� RemoteObject Interface�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.05.07</br>
	/// <br></br>
	/// <br>Update Note	: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IPrtItemSetDB
	{
		/// <summary>
		/// ���R���[���ڃO���[�v�}�X�^�擾�����i�S���j
		/// </summary>
		/// <param name="prtItemGrpWorkArray">���R���[���ڃO���[�v�}�X�^�z��</param>
		/// <param name="msgDiv">���b�Z�[�W�敪</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <br>Note		: ���R���[���ڃO���[�v�}�X�^�z���S���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.07</br>
		[MustCustomSerialization]
		int SearchPrtItemGrp(
			[CustomSerializationMethodParameterAttribute("SFTKD08113D", "Broadleaf.Application.Remoting.ParamData.PrtItemGrpWork")]
			out object prtItemGrpWorkArray,
			out bool msgDiv,
			out string errMsg
			);

		/// <summary>
		/// ���R���[���ڐݒ�}�X�^�擾����
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
		/// <param name="retCustomSerializeArrayList">�󎚍��ڏ��J�X�^���V���A���C�YLIST</param>
		/// <param name="msgDiv">���b�Z�[�W�敪</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <br>Note		: �w�肳�ꂽ���R���[���ڐݒ�}�X�^�z����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.07</br>
		[MustCustomSerialization]
		int SearchPrtItemSet(
			int freePrtPprItemGrpCd,
			[CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retCustomSerializeArrayList,
			out bool msgDiv,
			out string errMsg
			);

		/// <summary>
		/// ���R���[���ڐݒ�}�X�^�擾����
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
		/// <param name="freePrtPprSchmGrpCd">���R���[�X�L�[�}�O���[�v�R�[�h</param>
		/// <param name="retCustomSerializeArrayList">�󎚍��ڏ��J�X�^���V���A���C�YLIST</param>
		/// <param name="msgDiv">���b�Z�[�W�敪</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <br>Note		: �w�肳�ꂽ���R���[���ڐݒ�}�X�^�z����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.07</br>
		[MustCustomSerialization]
		int SearchPrtItemSetWithFPprSchmCv(
			int freePrtPprItemGrpCd,
			int freePrtPprSchmGrpCd,
			[CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retCustomSerializeArrayList,
			out bool msgDiv,
			out string errMsg
			);
	}
}
