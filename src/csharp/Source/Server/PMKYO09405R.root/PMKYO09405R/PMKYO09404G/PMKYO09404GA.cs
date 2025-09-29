//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : DC����M�������O�����[�g
// �v���O�����T�v   : DC����M�������O��ΏۂɁA�������ꊇ�œo�^�E�C���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : lushan
// �� �� ��  2011/07/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RateDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISndRcvHisRFDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���RateDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer  : lushan</br>
    /// <br>Date        : 2011/07/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSndRcvHisRFDB
    {
        /// <summary>
        /// SndRcvHisRFDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer  : lushan</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        public MediationSndRcvHisRFDB()
        {
        }
        /// <summary>
        /// ISndRcvHisRFDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISndRcvHisRFDB�I�u�W�F�N�g</returns>
        public static ISndRcvHisDB GetSndRcvHisRFDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_Center_UserAP);
#if DEBUG
            wkStr = "http://localhost:9003";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISndRcvHisDB)Activator.GetObject(typeof(ISndRcvHisDB), string.Format("{0}/MyAppSndRcvHis", wkStr));
        }
    }
}
