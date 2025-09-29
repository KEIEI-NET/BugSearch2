//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^�����e�i���X
// �v���O�����T�v   : �R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^�̓o�^�E�ύX���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ���X�ؘj
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ConvObjVerMngDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IConvObjVerMngDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���ConvObjVerMngDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���X�ؘj</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    public class MediationConvObjVerMngDB 
    {
        /// <summary>
        /// IConvObjVerMngDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public MediationConvObjVerMngDB()
        {
        }
        /// <summary>
        /// IConvObjVerMngDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IConvObjVerMngDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : IConvObjVerMngDB�C���^�[�t�F�[�X�擾</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// <br></br>
        /// </remarks>
        public static IConvObjVerMngDB GetConvObjVerMngDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IConvObjVerMngDB)Activator.GetObject(typeof(IConvObjVerMngDB), string.Format("{0}/MyAppConvObjVerMng", wkStr));
        }
    }
}
