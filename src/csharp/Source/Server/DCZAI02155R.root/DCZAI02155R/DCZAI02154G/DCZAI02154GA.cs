using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockAnalysisOrderListWorkDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IStockAnalysisOrderWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���StockMoveListWorkDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.09.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockAnalysisOrderListWorkDB
    {
        /// <summary>
        /// MediationStockAnalysisOrderListWorkDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.09.13</br>
        /// </remarks>
        public MediationStockAnalysisOrderListWorkDB()
        {
        }
        /// <summary>
        /// IStockMoveListWorkDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IStockMoveListWorkDB�I�u�W�F�N�g</returns>
        public static IStockAnalysisOrderListWorkDB GetStockAnalysisOrderListWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IStockAnalysisOrderListWorkDB)Activator.GetObject(typeof(IStockAnalysisOrderListWorkDB), string.Format("{0}/MyAppStockAnalysisOrderListWork", wkStr));
        }
    }
}
