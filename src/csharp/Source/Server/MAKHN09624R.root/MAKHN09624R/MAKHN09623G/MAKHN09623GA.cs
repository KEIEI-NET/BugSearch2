using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// GoodsSetDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IGoodsSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>            ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���GoodsSetDB��</br>
    /// <br>            �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 19026�@���R�@����</br>
    /// <br>Date       : 2007.04.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationGoodsSetDB
    {
        /// <summary>
        /// GoodsSetDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        /// </remarks>
        public MediationGoodsSetDB()
        {
        }
        /// <summary>
        /// IPrtmanageDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
        public static IGoodsSetDB GetGoodsSetDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IGoodsSetDB)Activator.GetObject(typeof(IGoodsSetDB),string.Format("{0}/MyAppGoodsSet",wkStr));
        }
    }
}
