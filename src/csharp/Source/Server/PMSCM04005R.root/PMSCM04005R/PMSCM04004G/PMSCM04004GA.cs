using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SCMInquiryResultWork����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISCMInquiryResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SCMInquiryResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSCMInquiryResultDB
    {
        /// <summary>
        /// MediationSCMInquiryResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public MediationSCMInquiryResultDB()
        {
        }
        /// <summary>
        /// ISupplierSendErOrderWorkDB�C���^�[�t�F�[�X�擾
        /// </summary>+
        /// <returns>ISupplierSendErOrderWorkDB�I�u�W�F�N�g</returns>
        public static ISCMInquiryDB GetSCMInquiryDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:8001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISCMInquiryDB)Activator.GetObject(typeof(ISCMInquiryDB), string.Format("{0}/MyAppSCMInquiry", wkStr));
        }
    }
}
