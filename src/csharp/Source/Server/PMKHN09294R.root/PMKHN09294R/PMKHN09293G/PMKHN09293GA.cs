//****************************************************************************//
// �V�X�e��         : RC.NS
// �v���O��������   : �o�b�N�A�b�v�����N���X
// �v���O�����T�v   : �o�b�N�A�b�v�����N���XDB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2011.06.22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// BackUpExecutionDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IBackUpExecutionDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���BackUpExecutionDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ��������</br>
    /// <br>Date       : 2011.06.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationBackUpExecutionDB
    {
        /// <summary>
        /// BackUpExecutionDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ��������</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        public MediationBackUpExecutionDB()
        {
        }

		/// <summary>
        /// IBackUpExecutionDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IBackUpExecutionDB�I�u�W�F�N�g</returns>
        public static IBackUpExecutionDB GetBackUpExecutionDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IBackUpExecutionDB)Activator.GetObject(typeof(IBackUpExecutionDB), string.Format("{0}/MyAppBackUpExecution", wkStr));
        }
    }
}
