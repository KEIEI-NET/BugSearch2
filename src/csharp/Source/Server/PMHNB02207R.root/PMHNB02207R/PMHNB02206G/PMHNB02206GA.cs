//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������A���}�b�`���X�g
// �v���O�����T�v   : ���������A���}�b�`���X�gDB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RateUnMatchDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IRateUnMatchDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���RateUnMatchDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.04.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRateUnMatchDB
    {
        /// <summary>
        /// RateUnMatchDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.03</br>
        /// </remarks>
        public MediationRateUnMatchDB()
        {
        }

        /// <summary>
        /// IRateUnMatchDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IRateUnMatchDB�I�u�W�F�N�g</returns>
        public static IRateUnMatchDB GetRateUnMatchDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IRateUnMatchDB)Activator.GetObject(typeof(IRateUnMatchDB), string.Format("{0}/MyAppRateUnMatch", wkStr));
        }
    }
}
