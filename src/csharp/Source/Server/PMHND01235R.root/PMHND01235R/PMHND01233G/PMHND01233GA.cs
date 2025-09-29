//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�i�ԃp�^�[���}�X�^
// �v���O�����T�v   : ���[�J�[�i�ԃp�^�[���}�X�^ DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright 2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570249-00   �쐬�S�� : ���O
// �� �� ��  2020/03/09    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// IHandyMakerGoodsPtrnDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IHandyMakerGoodsPtrnDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���IHandyMakerGoodsPtrnDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : ���O</br>
	/// <br>Date       : 2020/03/09</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationHandyMakerGoodsPtrnDB
	{
		/// <summary>
        /// IHandyMakerGoodsPtrnDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : ���O</br>
		/// <br>Date       : 2020/03/09</br>
		/// </remarks>
        public MediationHandyMakerGoodsPtrnDB()
		{
		}
		/// <summary>
        /// IHandyMakerGoodsPtrnDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IHandyMakerGoodsPtrnDB�I�u�W�F�N�g</returns>
        public static IHandyMakerGoodsPtrnDB GetHandyMakerGoodsPtrnDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:8001";
#endif
			
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IHandyMakerGoodsPtrnDB)Activator.GetObject(typeof(IHandyMakerGoodsPtrnDB), string.Format("{0}/MyAppHandyMakerGoodsPtrn", wkStr));
		}
	}
}
