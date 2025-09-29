//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�i�e�L�X�g�ϊ��j
// �v���O�����T�v   : ���i�}�X�^�e�L�X�g�ϊ�  DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902160-00  �쐬�S�� : ���z
// �� �� ��  K2013/08/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// ���i�}�X�^�e�L�X�g�ϊ�  DB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IGoodsTextExpDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���GoodsTextExpDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���z</br>
    /// <br>Date       : K2013/08/08</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationGoodsTextExpDB
	{
		/// <summary>
        /// GoodsTextExpDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���z</br>
        /// <br>Date       : K2013/08/08</br>
        /// </remarks>
        public MediationGoodsTextExpDB()
		{
		}

		/// <summary>
        /// IGoodsTextExpDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IGoodsTextExpDB�I�u�W�F�N�g</returns>
        public static IGoodsTextExpDB GetGoodsTextExpDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IGoodsTextExpDB)Activator.GetObject(typeof(IGoodsTextExpDB), string.Format("{0}/MyAppGoodsTextExp", wkStr));
		}
	}
}
