//***************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���ԕi�v��X�V���i
// �v���O�����T�v   : �d���ԕi�v��X�V���i DBRemoteObject����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI�֓� �a�G
// �� �� ��  2013/01/22  �C�����e : �d���ԕi�\��@�\�ǉ��Ή�
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockSlipRetPlnDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IStockSlipRetPlnDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���StockSlipRetPlnDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : FSI�֓� �a�G</br>
    /// <br>Date       : 2013/01/22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockSlipRetPlnDB
    {
        /// <summary>
        /// StockSlipRetPlnDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2013/01/22</br>
        /// </remarks>
        public MediationStockSlipRetPlnDB()
        {
        }
        /// <summary>
        /// IStockSlipRetPlnDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IStockSlipRetPlnDB�I�u�W�F�N�g</returns>
        public static IStockSlipRetPlnDB GetStockSlipRetPlnDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9011";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IStockSlipRetPlnDB)Activator.GetObject(typeof(IStockSlipRetPlnDB), string.Format("{0}/MyAppStockSlipRetPln", wkStr));
        }
    }
}
