//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : UOE�ڑ�����}�X�^�����e�i���X
// �v���O�����T�v   : UOE�ڑ�����}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : caowj
// �� �� ��  2010/07/26  �C�����e : �V�K�쐬
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
    /// UOEConnectInfoDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IUOEConnectInfoDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���UOEConnectInfoDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : caowj</br>
    /// <br>Date       : 2010/07/26</br>
    /// <br></br>
    /// </remarks>
    public class MediationUOEConnectInfoDB
    {
        /// <summary>
        /// UOEConnectInfoDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public MediationUOEConnectInfoDB()
        {
        }
        /// <summary>
        /// IUOEConnectInfoDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IUOEConnectInfoDB�I�u�W�F�N�g</returns>
        public static IUOEConnectInfoDB GetUOEConnectInfoDB()
        {
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            #if DEBUG
            wkStr = "http://localhost:8009";
            #endif
            return (IUOEConnectInfoDB)Activator.GetObject(typeof(IUOEConnectInfoDB), string.Format("{0}/MyAppUOEConnectInfo", wkStr));
        }
    }
}
