//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����f�[�^�e�L�X�g�o�́i�s�l�x�j
// �v���O�����T�v   : ����f�[�^�e�L�X�g�o�́i�s�l�x�j�@DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : ���N�n��
// �� �� ��  2011/10/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//


using System;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SalesHistoryJoinWorkDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISalesSliptextResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SalesSliptextResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���N�n��</br>										
    /// <br>Date       : 2012/10/31</br>										
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>
    /// </remarks>
    public class MediationSalesSliptextResultDB
    {
        /// <summary>
        /// SalesSliptextResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : SalesSliptextResultDB����N���X�R���X�g���N�^</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        public MediationSalesSliptextResultDB()
        {
        }

        /// <summary>
        /// IPrtmanageDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : IPrtmanageDB�C���^�[�t�F�[�X�擾</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        public static ISalesSliptextResultDB GetSalesSliptextResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
            // �f�o�b�O�p
#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISalesSliptextResultDB)Activator.GetObject(typeof(ISalesSliptextResultDB), string.Format("{0}/MyAppSalesSliptextResult", wkStr));
        }
    }
}
