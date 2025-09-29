//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : TSP���M�f�[�^�쐬 DB����N���X
// �v���O�����T�v   : TSP���M�f�[�^�쐬 DB����N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670305-00 �쐬�S�� : ���O
// �� �� ��  2020/11/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// MediationTspSdRvDataDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ITspSdRvData�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���TspSdRvData��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2020/11/20</br>
    /// </remarks>
    public class MediationTspSdRvDataDB
    {
        /// <summary>
        /// TspCommonSeqNo����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public MediationTspSdRvDataDB()
        {
        }
        /// <summary>
        /// ITspSdRvDataDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ITspSdRvDataDB�I�u�W�F�N�g</returns>
        public static ITspSdRvDataDB GetTspSdRvDataDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ITspSdRvDataDB)Activator.GetObject(typeof(ITspSdRvDataDB), string.Format("{0}/MyAppTspSdRvDataDB", wkStr));
        }
    }
}
