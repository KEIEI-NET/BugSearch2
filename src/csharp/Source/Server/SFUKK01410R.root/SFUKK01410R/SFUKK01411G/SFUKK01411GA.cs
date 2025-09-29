using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// DepBillMonSecDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IDepBillMonSecDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���DepBillMonSecDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 90027�@�����@��</br>
    /// <br>Date       : 2005.08.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationDepBillMonSecDB
    {
        /// <summary>
        /// DepBillMonSecDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 90027�@�����@��</br>
        /// <br>Date       : 2005.08.17</br>
        /// </remarks>
        public MediationDepBillMonSecDB()
        {
        }
        /// <summary>
        /// IDepBillMonSecDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IDepBillMonSecDB�I�u�W�F�N�g</returns>
        public static IDepBillMonSecDB GetDepBillMonSecDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IDepBillMonSecDB)Activator.GetObject(typeof(IDepBillMonSecDB),string.Format("{0}/MyDepBillMonSec",wkStr));
        }
    }
}
