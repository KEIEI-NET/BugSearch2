//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����������i�ݒ�}�X�^
// �v���O�����T�v   : �����������i�ݒ�}�X�^DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��Y
// �� �� ��  2015/01/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RecBgnGdsDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IRecBgnGdsDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���RecBgnGdsDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���� ��Y</br>
    /// <br>Date       : 2015/01/19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRecBgnGdsDB
    {
        /// <summary>
        /// RecBgnGdsDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���� ��Y</br>
        /// <br>Date       : 2015/01/19</br>
        /// </remarks>
        public MediationRecBgnGdsDB()
        {
        }

		/// <summary>
        /// IRecBgnGdsDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IRecBgnGdsDB�I�u�W�F�N�g</returns>
        public static IRecBgnGdsDB GetRecBgnGdsDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
            //string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9002";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IRecBgnGdsDB)Activator.GetObject(typeof(IRecBgnGdsDB), string.Format("{0}/MyAppRecBgnGds", wkStr));
        }
    }
}
