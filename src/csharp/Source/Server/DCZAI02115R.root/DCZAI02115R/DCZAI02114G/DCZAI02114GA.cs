using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockManagementListWorkDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IStockManagementWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���StockManagementListWorkDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockManagementListWorkDB
    {
        /// <summary>
        /// MediationStockManagementListWorkDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public MediationStockManagementListWorkDB()
        {
        }
        /// <summary>
        /// IStockMoveListWorkDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IStockMoveListWorkDB�I�u�W�F�N�g</returns>
        public static IStockManagementListWorkDB GetStockManagementListWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IStockManagementListWorkDB)Activator.GetObject(typeof(IStockManagementListWorkDB), string.Format("{0}/MyAppStockManagementListWork", wkStr));
        }
    }
}
