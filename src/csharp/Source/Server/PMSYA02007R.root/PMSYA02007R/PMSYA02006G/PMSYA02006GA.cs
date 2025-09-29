//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�ʏo�׎��ѕ\
// �v���O�����T�v   : ���q�ʏo�׎��ѕ\ ���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/09/15  �C�����e : �V�K�쐬
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
    /// CarShipWorkDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ICarShipWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CarShipWorkDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2009.09.15</br>
    /// <br></br>
    /// </remarks>
    public class MediationCarShipResultDB
    {
        /// <summary>
        /// CarAdjustWorkDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        public MediationCarShipResultDB()
        {
        }
        /// <summary>
        /// IPrtmanageDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
        public static ICarShipResultDB GetCarShipWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
            // �f�o�b�O�p
#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ICarShipResultDB)Activator.GetObject(typeof(ICarShipResultDB), string.Format("{0}/MyAppCarShipResult", wkStr));
        }
    }
}
