//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���iMAX���ח\��
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11270001-00  �쐬�S�� : ���O
// �� �� ��  2016/01/21   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// MediationPartsMaxStockArrivalDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���̃N���X��IMediationPartsMaxStockArrivalDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>              ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���IMediationPartsMaxStockArrivalDB��</br>
    /// <br>              �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2016/01/21</br>
    /// <br></br>
    /// </remarks>
    public class MediationPartsMaxStockArrivalDB
    {
        /// <summary>
        /// YamanakaSalesGoodsAchieveDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        public MediationPartsMaxStockArrivalDB()
        {
        }

        /// <summary>
        /// IPartsMaxStockArrivalDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPartsMaxStockArrivalDB�I�u�W�F�N�g</returns>
        public static IPartsMaxStockArrivalDB GetPartsMaxStockArrivalDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif   
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPartsMaxStockArrivalDB)Activator.GetObject(typeof(IPartsMaxStockArrivalDB), string.Format("{0}/MyAppPartsMaxStockArrival", wkStr));
        }
    }
}
