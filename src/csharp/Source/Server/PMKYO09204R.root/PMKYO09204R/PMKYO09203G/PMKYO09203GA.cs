//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����M�Ώېݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ����M�Ώېݒ�̕ύX���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/04/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SendSetDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISendSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SendSetDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.04.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSendSetDB
    {
        /// <summary>
        /// SendSetDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        public MediationSendSetDB()
        {

        }

        /// <summary>
        /// ISendSetDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISendSetDB�I�u�W�F�N�g</returns>
        public static ISendSetDB GetSendSetDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISendSetDB)Activator.GetObject(typeof(ISendSetDB), string.Format("{0}/MyAppSecMngSndRcv", wkStr));
        }
    }
}
