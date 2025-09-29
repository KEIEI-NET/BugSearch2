//============================================================================//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�}�X�^�����[�g����N���X
// �v���O�����T�v   : ���Ӑ�}�X�^�����[�g�I�u�W�F�N�g���擾���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10402071-00  �쐬�S�� : 21112
// �� �� ��  2008/04/23  �C�����e : SFTOK01134G ���x�[�X��PM.NS�p���쐬
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// CustomerDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��ICustomerDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>�@�@�@�@�@�@ ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CustomerDB��</br>
	/// <br>�@�@�@�@�@�@ �C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 21112</br>
	/// <br>Date       : 2008.04.23</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// <br></br>
	/// </remarks>
	public class MediationCustomerInfoDB
	{
		/// <summary>
		/// CustomerDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		public MediationCustomerInfoDB()
		{

		}

		/// <summary>
		/// ICustomerDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>ICustomerDB�I�u�W�F�N�g</returns>
		public static ICustomerInfoDB GetCustomerInfoDB()
		{
			// USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			// AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (ICustomerInfoDB)Activator.GetObject(typeof(ICustomerInfoDB),string.Format("{0}/MyAppCustomer",wkStr));
		}
	}
}
