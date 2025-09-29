//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i���i�}�X�^�W�JDB����N���X
// �v���O�����T�v   : ���i���i�}�X�^�W�JDB����N���X���Ǘ�����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10703874-00 �쐬�S�� : huangqb
// �� �� ��  K2011/07/14 �쐬���e : �C�X�R�ʑΉ�
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;


namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ���i���i�}�X�^�W�JDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ICostExpandDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CostExpandDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : huangqb</br>
    /// <br>Date       : K2011/07/14</br>
    /// <br>�Ǘ��ԍ�   : 10703874-00 �C�X�R�ʑΉ�</br>
    /// <br></br>
    /// </remarks>
    public class MediationCostExpandDB
    {
        /// <summary>
        /// ���i���i�}�X�^�W�JDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>�Ǘ��ԍ�   : 10703874-00 �C�X�R�ʑΉ�</br>
        /// <br></br>
        /// </remarks>
        public MediationCostExpandDB()
        {
        }

        /// <summary>
        /// ICostExpandDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ICostExpandDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ICostExpandDB�C���^�[�t�F�[�X���擾���܂��B</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>�Ǘ��ԍ�   : 10703874-00 �C�X�R�ʑΉ�</br>
        /// <br></br>
        /// </remarks>
        public static ICostExpandDB GetCostExpandDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif            
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ICostExpandDB)Activator.GetObject(typeof(ICostExpandDB), string.Format("{0}/MyAppCostExpand", wkStr));
        }
    }
}
