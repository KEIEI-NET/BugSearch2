//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�|���ꊇ�o�^�E�C���U
// �v���O�����T�v   �F�|���}�X�^�̓o�^�E�C�������ꊇ�ōs��
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���Fcaohh
// �C����    2013/02/19     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �|���ꊇ�o�^�E�C���UDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IRate2DB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���Rate2DB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2013/02/19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRate2DB
    {
        /// <summary>
        /// �|���ꊇ�o�^�E�C���UDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public MediationRate2DB()
        {
        }
        /// <summary>
        /// IRateDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IRateDB�I�u�W�F�N�g</returns>
        public static IRate2DB GetRate2DB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IRate2DB)Activator.GetObject(typeof(IRate2DB), string.Format("{0}/MyAppRate2", wkStr));
        }
    }
}
