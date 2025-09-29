//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������s(�d�q����A�g)����N���X
// �v���O�����T�v   : ���������s(�d�q����A�g)����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright 2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00   �쐬�S�� : ���O
// �� �� ��  2022/03/07    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// EBooksBillTableDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note        : ���̃N���X��IEBooksBillTableDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>		 	 ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���EBooksBillTableDB��</br>
    /// <br>			 �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2022/03/07</br>
	/// <br></br>
	/// </remarks>
	public class MediationEBooksBillTableDB
	{
		/// <summary>
        /// EBooksBillTableDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note        : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		public MediationEBooksBillTableDB()
		{
		}
		/// <summary>
        /// IEBooksBillTableDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IEBooksBillTableDB�I�u�W�F�N�g</returns>
        public static IEBooksBillTableDB GetEBooksBillTableDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IEBooksBillTableDB)Activator.GetObject(typeof(IEBooksBillTableDB), string.Format("{0}/MyAppEBooksBillTable", wkStr));
		}
	}
}
