//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�Ǘ����}�X�^
// �v���O�����T�v   : ���i�Ǘ����}�X�^�̃G�N�X�|�[�g���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���R
// �� �� ��  2012/06/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// GoodsMngExportDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IGoodsMngExportDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���GoodsMngExportDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2012/06/05</br>
    /// <br></br>
    /// </remarks>
    public class MediationGoodsMngExportDB
    {
        /// <summary>
        /// GoodsMngExportDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2012/06/05</br>
        /// </remarks>
        public MediationGoodsMngExportDB()
        {
        }
        /// <summary>
        /// IGoodsMngExportDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IGoodsMngExportDB�I�u�W�F�N�g</returns>
        public static IGoodsMngExportDB GetGoodsMngExportDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IGoodsMngExportDB)Activator.GetObject(typeof(IGoodsMngExportDB), string.Format("{0}/MyAppGoodsMngExport", wkStr));
        }
    }
}
