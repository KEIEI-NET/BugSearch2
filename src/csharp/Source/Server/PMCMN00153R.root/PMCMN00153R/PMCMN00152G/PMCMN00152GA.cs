//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ������
// �v���O�����T�v   : ���������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ���X�ؘj
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// EnvSurvObjDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IEnvSurvObjDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���EnvSurvObjDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���X�ؘj</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    public class MediationEnvSurvObjDB 
    {
        /// <summary>
        /// IEnvSurvObjDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public MediationEnvSurvObjDB()
        {
        }
        /// <summary>
        /// IEnvSurvObjDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IEnvSurvObjDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : IEnvSurvObjDB�C���^�[�t�F�[�X�擾</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// <br></br>
        /// </remarks>
        public static IEnvSurvObjDB GetEnvSurvObjDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IEnvSurvObjDB)Activator.GetObject(typeof(IEnvSurvObjDB), string.Format("{0}/MyAppEnvSurvObj", wkStr));
        }
    }
}
