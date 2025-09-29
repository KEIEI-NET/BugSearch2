//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ʐM�e�X�g�c�[��
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2014/09/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// APNSNetworkTestDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IAPNSNetworkTestDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���IAPNSNetworkTestDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2014/09/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class APNSNetworkTestDB
    {
        /// <summary>
        /// APBaseDataExtraDefSetDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/09/18</br>
        /// </remarks>
        public APNSNetworkTestDB()
        {
        }
        /// <summary>
        /// ISalesSlipDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IIOWriteMAHNBDB�I�u�W�F�N�g</returns>
        public static IAPNSNetworkTestDB GetNSNetworkTestDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_Center_UserAP);

//#if DEBUG
//            wkStr = "http://localhost:9001";
//# endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IAPNSNetworkTestDB)Activator.GetObject(typeof(IAPNSNetworkTestDB), string.Format("{0}/MyAppAPNSNetworkTest", wkStr));
        }
    }
}
