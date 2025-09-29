using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// OrderPointOrderWorkDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IOrderPointOrderWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���OrderPointOrderWorkDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.10.23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationOrderPointOrderWorkDB
    {
        /// <summary>
        /// MediationOrderBrokenListWorkDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.10.23</br>
        /// </remarks>
        public MediationOrderPointOrderWorkDB()
        {
        }
        /// <summary>
        /// IOrderPointOrderWorkDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IOrderPointOrderWorkDB�I�u�W�F�N�g</returns>
        public static IOrderPointOrderWorkDB GetOrderPointOrderWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            //wkStr = "http://localhost:8008/";
            wkStr = "http://localhost:9001";
#endif        

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IOrderPointOrderWorkDB)Activator.GetObject(typeof(IOrderPointOrderWorkDB), string.Format("{0}/MyAppOrderPointOrderWork", wkStr));
        }
    }
}
