using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// UOEAnswerLedgerOrderWorkDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IUOEAnswerLedgerOrderWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���UOEAnswerLedgerOrderWorkDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2008.9.24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationUOEAnswerLedgerOrderWorkDB
    {
        /// <summary>
        /// MediationSupplierUnmOrderWorkDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.24</br>
        /// </remarks>
        public MediationUOEAnswerLedgerOrderWorkDB()
        {
        }
        /// <summary>
        /// IUOEAnswerLedgerOrderWorkDB�C���^�[�t�F�[�X�擾
        /// </summary>+
        /// <returns>IUOEAnswerLedgerOrderWorkDB�I�u�W�F�N�g</returns>
        public static IUOEAnswerLedgerOrderWorkDB GetUOEAnswerLedgerOrderWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IUOEAnswerLedgerOrderWorkDB)Activator.GetObject(typeof(IUOEAnswerLedgerOrderWorkDB), string.Format("{0}/MyAppUOEAnswerLedgerOrderWork", wkStr));
        }
    }
}
