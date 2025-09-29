using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RateDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IRateDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���RateDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 96050  ����@����</br>
    /// <br>Date       : 2007.10.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRateDB
    {
        /// <summary>
        /// RateDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 96050  ����@����</br>
        /// <br>Date       : 2007.10.16</br>
        /// </remarks>
        public MediationRateDB()
        {
        }
        /// <summary>
        /// IRateDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IRateDB�I�u�W�F�N�g</returns>
        public static IRateDB GetRateDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IRateDB)Activator.GetObject(typeof(IRateDB), string.Format("{0}/MyAppRate", wkStr));
        }
    }
}
