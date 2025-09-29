//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���M���O�\��
// �v���O�����T�v   : ���M���O�\��DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2019/12/02  �C�����e : �V�K�쐬
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
    /// SalCprtSndLogDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISalCprtSndLogDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SalCprtSndLogDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ��������</br>
    /// <br>Date       : 2019/12/02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSalCprtSndLogDB
    {
        /// <summary>
        /// SalCprtSndLogDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ��������</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public MediationSalCprtSndLogDB()
        {
        }

		/// <summary>
        /// ISalCprtSndLogDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>ISalCprtSndLogDB�I�u�W�F�N�g</returns>
        public static ISalCprtSndLogDB GetSalCprtSndLogDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISalCprtSndLogDB)Activator.GetObject(typeof(ISalCprtSndLogDB), string.Format("{0}/MyAppSalCprtSndLog", wkStr));
        }
    }
}
