//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�Ǘ����}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���i�Ǘ����}�X�^�i�C���|�[�g�jDB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �� �� ��  2012/06/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// GoodsMngImportDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IGoodsMngImportDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���GoodsMngImportDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2012/06/04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationGoodsMngImportDB
    {
        /// <summary>
        /// GoodsMngImportDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        public MediationGoodsMngImportDB()
        {
        }

        /// <summary>
        /// IGoodsMngImportDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IGoodsMngImportDB�I�u�W�F�N�g</returns>
        public static IGoodsMngImportDB GetGoodsMngImportDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IGoodsMngImportDB)Activator.GetObject(typeof(IGoodsMngImportDB), string.Format("{0}/MyAppGoodsMngImport", wkStr));
        }
    }
}
