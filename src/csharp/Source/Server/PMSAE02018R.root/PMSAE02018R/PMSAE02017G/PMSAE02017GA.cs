//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : S&E����f�[�^�e�L�X�g
// �v���O�����T�v   : S&E����f�[�^�e�L�X�g���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/08/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
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
    /// <br>Note       : ���̃N���X��ISalesHistoryJoinWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SalesHistoryJoinWorkDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.08.14</br>
    /// <br></br>
    /// </remarks>
    public class MediationSalesHistoryJoinResultDB
    {
        /// <summary>
        /// SalesHistoryJoinWorkDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.14</br>
        /// </remarks>
        public MediationSalesHistoryJoinResultDB()
        {
        }
        /// <summary>
        /// IPrtmanageDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
        public static ISalesHistoryJoinWorkDB GetSalesHistoryJoinWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
            // �f�o�b�O�p
#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISalesHistoryJoinWorkDB)Activator.GetObject(typeof(ISalesHistoryJoinWorkDB), string.Format("{0}/MyAppSalesHistoryJoin", wkStr));
        }
    }
}
