using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PrmSettingPrintOrderWorkDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IPrmSettingPrintOrderWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PrmSettingPrintOrderWorkDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2008.10.24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPrmSettingPrintOrderWorkDB
    {
        /// <summary>
        /// MediationSupplierUnmOrderWorkDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public MediationPrmSettingPrintOrderWorkDB()
        {
        }
        /// <summary>
        /// IPrmSettingPrintOrderWorkDB�C���^�[�t�F�[�X�擾
        /// </summary>+
        /// <returns>IPrmSettingPrintOrderWorkDB�I�u�W�F�N�g</returns>
        public static IPrmSettingPrintOrderWorkDB GetPrmSettingPrintOrderWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPrmSettingPrintOrderWorkDB)Activator.GetObject(typeof(IPrmSettingPrintOrderWorkDB), string.Format("{0}/MyAppPrmSettingPrintOrderWork", wkStr));
        }
    }
}
