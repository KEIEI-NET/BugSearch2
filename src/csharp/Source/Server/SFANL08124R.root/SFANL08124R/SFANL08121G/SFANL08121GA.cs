using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// FrePrtPSetDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���̃N���X��IFrePrtPSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			  ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���FrePrtPSetDB��</br>
	/// <br>			  �C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.05.10</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFrePrtPSetDB
	{
		/// <summary>
		/// FrePrtPSetDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 22024 ����@�_�u</br>
		/// <br>Date       : 2007.05.10</br>
		/// </remarks>
		public MediationFrePrtPSetDB()
		{
		}

		/// <summary>
		/// IFrePrtPSetDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IFrePrtPSetDB�I�u�W�F�N�g</returns>
		/// <remarks>
		/// <br>Note       : �����[�g�I�u�W�F�N�g�擾�p�̃v���L�V���쐬���܂��B</br>
		/// <br>Programmer : 22024 ����@�_�u</br>
		/// <br>Date       : 2007.05.10</br>
		/// </remarks>
		public static IFrePrtPSetDB GetFrePrtPSetDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            # if DEBUG
            wkStr = "http://localhost:9001";
            # endif

			return (IFrePrtPSetDB)Activator.GetObject(typeof(IFrePrtPSetDB), string.Format("{0}/MyAppFrePrtPSet", wkStr));
		}
	}
}
