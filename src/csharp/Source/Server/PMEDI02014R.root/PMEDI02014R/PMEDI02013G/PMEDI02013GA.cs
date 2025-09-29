//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����f�[�^�e�L�X�g
// �v���O�����T�v   : ����f�[�^�e�L�X�g���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11370098-00  �쐬�S�� : ���O
// �� �� ��  2017/11/20   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// EDISalesResultDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IEDISalesResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���EDISalesResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/11/20</br>
    /// <br></br>
    /// </remarks>
    public class MediationEDISalesResultDB
    {
        /// <summary>
        /// EDISalesResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        public MediationEDISalesResultDB()
        {
        }
        /// <summary>
        /// IEDISalesResultDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IEDISalesResultDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : IEDISalesResultDB�C���^�[�t�F�[�X���擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        public static IEDISalesResultDB GetEDISalesResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
            // �f�o�b�O�p
#if DEBUG
            wkStr = "http://localhost:8001";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IEDISalesResultDB)Activator.GetObject(typeof(IEDISalesResultDB), string.Format("{0}/MyAppEDISalesResult", wkStr));
        }
    }
}
