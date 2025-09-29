//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����������i�O���[�v�ݒ�}�X�^
// �v���O�����T�v   : �����������i�O���[�v�ݒ�}�X�^DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2015/02/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RecBgnGrpDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IRecBgnGrpDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���RecBgnGrpDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ��������</br>
    /// <br>Date       : 2015/02/23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRecBgnGrpDB
    {
        /// <summary>
        /// RecBgnGrpDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ��������</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public MediationRecBgnGrpDB()
        {
        }

		/// <summary>
        /// IRecBgnGrpDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IRecBgnGrpDB�I�u�W�F�N�g</returns>
        public static IRecBgnGrpDB GetRecBgnGrpDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
            //string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9002";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IRecBgnGrpDB)Activator.GetObject(typeof(IRecBgnGrpDB), string.Format("{0}/MyAppPMRecBgnGrp", wkStr));
        }
    }
}
