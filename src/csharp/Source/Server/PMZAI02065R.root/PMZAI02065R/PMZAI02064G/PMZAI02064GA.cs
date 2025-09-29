using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// TrustStockOrderWorkDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ITrustStockOrderWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���TrustStockOrderWorkDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationTrustStockOrderWorkDB
    {
        /// <summary>
        /// MediationTrustStockOrderWorkDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        public MediationTrustStockOrderWorkDB()
        {
        }
        /// <summary>
        /// ITrustStockOrderWorkDB�C���^�[�t�F�[�X�擾
        /// </summary>+
        /// <returns>ITrustStockOrderWorkDB�I�u�W�F�N�g</returns>
        public static ITrustStockOrderWorkDB GetTrustStockOrderWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ITrustStockOrderWorkDB)Activator.GetObject(typeof(ITrustStockOrderWorkDB), string.Format("{0}/MyAppTrustStockOrderWork", wkStr));
        }
    }
}
