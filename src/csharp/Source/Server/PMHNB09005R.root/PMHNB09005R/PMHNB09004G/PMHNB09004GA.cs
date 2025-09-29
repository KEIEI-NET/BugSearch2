//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^�����e�i���X
// �v���O�����T�v   : �\���敪�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/10/16  �C�����e : �V�K�쐬
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
    /// SAndESettingDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISAndESettingDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SAndESettingDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.10.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPriceSelectSetDB
    {
        /// <summary>
        /// SAndESettingDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        /// </remarks>
        public MediationPriceSelectSetDB()
        {

        }

        /// <summary>
        /// ISupplierDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISupplierDB�I�u�W�F�N�g</returns>
        public static IPriceSelectSetDB GetPriceSelectSetDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPriceSelectSetDB)Activator.GetObject(typeof(IPriceSelectSetDB), string.Format("{0}/MyAppPriceSelectSet", wkStr));
        }
    }
}
