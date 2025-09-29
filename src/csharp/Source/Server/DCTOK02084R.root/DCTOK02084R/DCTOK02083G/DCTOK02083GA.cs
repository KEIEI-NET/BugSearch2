using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockTransListResultDB ����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IStockTransListResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���StockTransListResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �R�c ���F</br>
    /// <br>Date       : 2007.11.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockTransListResultDB
    {
        /// <summary>
        /// StockTransListResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �R�c ���F</br>
        /// <br>Date       : 2007.11.30</br>
        /// </remarks>
        public MediationStockTransListResultDB()
        {
        }
        /// <summary>
        /// IStockTransListResultDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IStockTransListResultDB�I�u�W�F�N�g</returns>
        public static IStockTransListResultDB GetStockTransListResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IStockTransListResultDB)Activator.GetObject(typeof(IStockTransListResultDB), string.Format("{0}/MyAppStockTransListResult", wkStr));
        }
    }
}
