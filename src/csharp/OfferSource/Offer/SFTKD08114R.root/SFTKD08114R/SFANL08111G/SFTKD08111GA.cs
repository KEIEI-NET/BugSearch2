using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// PrtItemSetDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���̃N���X��IPrtItemSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			  ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PrtItemSetDB��</br>
	/// <br>			  �C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.05.07</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPrtItemSetDB
	{
		/// <summary>
		/// PrtItemSetDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 22024 ����@�_�u</br>
		/// <br>Date       : 2007.05.07</br>
		/// </remarks>
		public MediationPrtItemSetDB()
		{
		}

		/// <summary>
		/// IPrtItemSetDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtItemSetDB�I�u�W�F�N�g</returns>
		/// <remarks>
		/// <br>Note       : �����[�g�I�u�W�F�N�g�擾�p�̃v���L�V���쐬���܂��B</br>
		/// <br>Programmer : 22024 ����@�_�u</br>
		/// <br>Date       : 2007.05.07</br>
		/// </remarks>
		public static IPrtItemSetDB GetPrtItemSetDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
			return (IPrtItemSetDB)Activator.GetObject(typeof(IPrtItemSetDB), string.Format("{0}/MyAppPrtItemSet", wkStr));
		}
	}
}
