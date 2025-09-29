//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �x���ꗗ�\�i�����j
// �v���O�����T�v   : �x���ꗗ�\�i�����j�̈󎚂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���@���j
// �� �� ��  2012/09/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// SumPaymentTableDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��ISumPaymentTableDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SumPaymentTableDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : FSI�� ���j</br>
	/// <br>Date       : 2012/09/04 </br>
	/// </remarks>
	public class MediationSumPaymentTableDB
	{
		/// <summary>
        /// SumPaymentTableDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : 2012/09/04 </br>
		/// </remarks>
		public MediationSumPaymentTableDB()
		{
		}
		/// <summary>
        /// ISumPaymentTableDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>ISumPaymentTableDB�I�u�W�F�N�g</returns>
        public static ISumPaymentTableDB GetSumPaymentTableDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (ISumPaymentTableDB)Activator.GetObject(typeof(ISumPaymentTableDB),string.Format("{0}/MyAppSumPaymentTable",wkStr));
		}
	}
}
