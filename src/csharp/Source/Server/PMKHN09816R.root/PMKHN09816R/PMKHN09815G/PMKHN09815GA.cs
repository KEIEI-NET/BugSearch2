//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�G�N�X�|�[�gDB����N���X
// �v���O�����T�v   : �|���}�X�^�G�N�X�|�[�gDB�����
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-**  �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12   �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : K.Miura
// �C �� ��  2015/10/14   �C�����e : �N���X���d���̂��ߕύX 
//                                   StockMas �� RateText
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : ���V�@���M
// �C �� ��  2015/10/14   �C�����e : �N���X���d���̂��ߕύX 
//                                   MediationStockMasDB �� MediationRateTextDB
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �|���}�X�^�G�N�X�|�[�gDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IStockMasDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���RateTextDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : 2013/06/12 </br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
// --- CHG  2015/10/14 ���V ���M --- >>>>
//  public class MediationStockMasDB
    public class MediationRateTextDB     
// --- CHG  2015/10/14 ���V ���M --- <<<<
    {
        /// <summary>
        /// RateTextDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12 </br>
        /// </remarks>
// --- CHG  2015/10/14 ���V ���M --- >>>>
//      public MediationStockMasDB()
        public MediationRateTextDB()
// --- CHG  2015/10/14 ���V ���M --- <<<<
        {

        }

        /// <summary>
        /// IStockMasDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IStockMasDB�I�u�W�F�N�g</returns>
// --- CHG  2015/10/14 K.Miura --- >>>>
//      public static IStockMasDB GetStockMasDB()
        public static IRateTextDB GetRateTextDB()
// --- CHG  2015/10/14 K.Miura --- <<<<
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
// --- CHG  2015/10/14 K.Miura --- >>>>
//            return (IRateTextDB)Activator.GetObject(typeof(IRateTextDB), string.Format("{0}/MyAppStockMas", wkStr));
              return (IRateTextDB)Activator.GetObject(typeof(IRateTextDB), string.Format("{0}/MyAppRateText", wkStr));
// --- CHG  2015/10/14 K.Miura --- <<<<
        }
    }
}
