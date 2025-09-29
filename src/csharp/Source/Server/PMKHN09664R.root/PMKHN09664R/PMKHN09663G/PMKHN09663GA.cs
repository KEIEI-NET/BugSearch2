//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����[�g�`���ݒ�}�X�^�����e
// �v���O�����T�v   : �����[�g�`���ݒ�}�X�^�����eDB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011.08.03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
//****************************************************************************//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RmSlpPrtStDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IRmSlpPrtStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			 ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���RmSlpPrtStDB��</br>
    /// <br>			 �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011.08.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRmSlpPrtStDB
    {
        /// <summary>
        /// SlipTypeMngDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public MediationRmSlpPrtStDB()
        {
        }
        /// <summary>
        /// IRmSlpPrtStDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IRmSlpPrtStDB�I�u�W�F�N�g</returns>
        public static IRmSlpPrtStDB GetRmSlpPrtStDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);

#if DEBUG
            wkStr = "http://localhost:9002";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IRmSlpPrtStDB)Activator.GetObject(typeof(IRmSlpPrtStDB), string.Format("{0}/MyAppRmSlpPrtSt", wkStr));
        }
    }
}
