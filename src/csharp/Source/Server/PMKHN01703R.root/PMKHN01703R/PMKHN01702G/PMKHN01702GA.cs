//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y��MeijiGoodsChgAllDB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2015/01/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// MeijiGoodsChgAllDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IMeijiGoodsChgAllDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���MeijiGoodsChgAllDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2015/01/26</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    public class MediationMeijiGoodsChgAllDB
	{
		/// <summary>
		/// GoodsNoChangeDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
		public MediationMeijiGoodsChgAllDB()
		{
		}
		/// <summary>
		/// IPrtmanageDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
        public static IMeijiGoodsChgAllDB GetMeijiGoodsChgAllDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IMeijiGoodsChgAllDB)Activator.GetObject(typeof(IMeijiGoodsChgAllDB), string.Format("{0}/MyAppMeijiGoodsChgAll", wkStr));
		}
	}
}
