using System;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{

	/// <summary>
	/// CustomerSearchDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��ICustomerSearchDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CustomerSearchDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 980076�@�Ȓ��@����Y</br>
	/// <br>Date       : 2007.02.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationCustomerSearchDB
	{
		/// <summary>
		/// CustomerSearchDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 980076�@�Ȓ��@����Y</br>
		/// <br>Date       : 2007.02.13</br>
		/// </remarks>
		public MediationCustomerSearchDB()
		{
		}

		/// <summary>
		/// ICustomerSearchDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>ICustomerSearchDB�I�u�W�F�N�g</returns>
		public static ICustomerSearchDB GetCustomerSearchDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

			// �f�o�b�O�p
#if DEBUG
			wkStr = "http://localhost:9001";
# endif

			return (ICustomerSearchDB)Activator.GetObject(typeof(ICustomerSearchDB),string.Format("{0}/MyAppCustomerSearch",wkStr));
		}
	}
}
