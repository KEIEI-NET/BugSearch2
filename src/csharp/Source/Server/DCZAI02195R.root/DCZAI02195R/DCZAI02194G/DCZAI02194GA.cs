using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockOverListWorkDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IStockOverListWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���StockOverListWorkDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.11.07</br>
    /// </remarks>
    public class MediationStockOverListWorkDB
    {
        /// <summary>
        /// StockListWorkDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.07</br>
        /// </remarks>
        public MediationStockOverListWorkDB()
        {
        }
        /// <summary>
        /// IPrtmanageDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
        public static IStockOverListWorkDB GetStockOverListWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif            

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IStockOverListWorkDB)Activator.GetObject(typeof(IStockOverListWorkDB), string.Format("{0}/MyAppStockOverListWork", wkStr));
        }
    }
}
