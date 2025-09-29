//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �Z�b�g�}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : �Z�b�g�}�X�^�i�C���|�[�g�jDB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/05/15  �C�����e : �V�K�쐬
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
    /// GoodsSetImportDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IGoodsSetImportDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���GoodsSetImportDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationGoodsSetImportDB
    {
        /// <summary>
        /// GoodsSetImportDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public MediationGoodsSetImportDB()
        {
        }

        /// <summary>
        /// IGoodsSetImportDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IGoodsSetImportDB�I�u�W�F�N�g</returns>
        public static IGoodsSetImportDB GetGoodsSetImportDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IGoodsSetImportDB)Activator.GetObject(typeof(IGoodsSetImportDB), string.Format("{0}/MyAppGoodsSetImport", wkStr));
        }
    }
}
