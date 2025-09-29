using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockAdjRefSearchDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISearchStockSlipDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���StockSlipDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 22018�@��؁@���b</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockAdjRefSearchDB
    {
        /// <summary>
        /// StockAdjRefSearchDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 22018�@��؁@���b</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        public MediationStockAdjRefSearchDB()
        {
        }
        /// <summary>
        /// IStockAdjRefSearchDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IStockAdjRefSearchDB�I�u�W�F�N�g</returns>
        public static IStockAdjRefSearchDB GetStockAdjRefSearchDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";   
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IStockAdjRefSearchDB)Activator.GetObject( typeof( IStockAdjRefSearchDB ), string.Format( "{0}/MyAppStockAdjRefSearch", wkStr ) );
        }
    }
}
