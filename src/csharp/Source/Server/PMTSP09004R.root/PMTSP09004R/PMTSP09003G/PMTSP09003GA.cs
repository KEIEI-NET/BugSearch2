//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : TSP�A�g�}�X�^�ݒ�
// �v���O�����T�v   : TSP�A�g�}�X�^�ݒ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11670305-00  �쐬�S�� : 3H ������
// �� �� �� : 2020/11/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// TSP�A�g�}�X�^�ݒ� DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : ���̃N���X��ITspCprtStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>               ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���TspCprtStDB��</br>
    /// <br>               �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer   : 3H ������</br>
    /// <br>Date         : 2020/11/23</br>
    /// <br>�˗��ԍ�     : 11670305-00</br>
    /// <br></br>
    /// </remarks>
    public class MediationTspCprtStDB
    {
        /// <summary>
        /// TspCprtStDB DB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public MediationTspCprtStDB()
        {
        }

        /// <summary>
        /// TspCprtStDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ITspCprtStDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : TspCprtStDB�C���^�[�t�F�[�X�擾</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public static ITspCprtStDB GetTspCprtStDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:9001";
# endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ITspCprtStDB)Activator.GetObject(typeof(ITspCprtStDB), string.Format("{0}/MyAppTspCprtStDB", wkStr));
        }
    }
}