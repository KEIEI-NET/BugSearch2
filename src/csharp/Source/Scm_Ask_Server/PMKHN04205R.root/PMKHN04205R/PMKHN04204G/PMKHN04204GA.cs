//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Е��i���������Ɖ� 
// �v���O�����T�v   : ���Е��i���������Ɖ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ScmInqLogInquiryDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IScmInqLogInquiryDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���ScmInqLogInquiryDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �� ��</br>
    /// <br>Date       : 2010/11/11</br>
    /// </remarks>
    public class MediationScmInqLogInquiryDB
    {
        /// <summary>
        /// ScmInqLogInquiryDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        public MediationScmInqLogInquiryDB()
        {

        }

        /// <summary>
        /// IScmInqLogDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IScmInqLogDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        public static IScmInqLogInquiryDB GetIScmInqLogInquiryDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_ASK_AP_NS);
#if DEBUG
            wkStr = "http://localhost:9010";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IScmInqLogInquiryDB)Activator.GetObject(typeof(IScmInqLogInquiryDB), string.Format("{0}/MyAppScmInqLogInquiry", wkStr));
        }
    }
}
