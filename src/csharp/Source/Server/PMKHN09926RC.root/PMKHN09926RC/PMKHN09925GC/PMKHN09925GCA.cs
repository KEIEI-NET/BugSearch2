//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�e�L�X�g�ϊ�DB����N���X
// �v���O�����T�v   : ���i�e�L�X�g�ϊ�DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-00  �쐬�S�� : FSI���� �f��
// �� �� ��  K2012/05/28  �C�����e : �V�K�쐬 �R�`���i�ʑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ���i�e�L�X�g�ϊ�DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IGoodsUMasDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���GoodsUMasDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : K2012/05/28</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationGoodsUMasDB
    {
        /// <summary>
        /// GoodsUMasDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : K2012/05/28</br>
        /// </remarks>
        public MediationGoodsUMasDB()
        {

        }

        /// <summary>
        /// IGoodsUMasDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IGoodsUMasDB�I�u�W�F�N�g</returns>
        public static IGoodsUMasDB GetGoodsUMasDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IGoodsUMasDB)Activator.GetObject(typeof(IGoodsUMasDB), string.Format("{0}/MyAppGoodsUMas", wkStr));
        }
    }
}
