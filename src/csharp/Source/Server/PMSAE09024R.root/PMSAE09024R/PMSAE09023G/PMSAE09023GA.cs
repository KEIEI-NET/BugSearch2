//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�R�[�h�ϊ��}�X�^�����e�i���X
// �v���O�����T�v   : ���i�R�[�h�ϊ��̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/08/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SAndEGoodsCdChgSetDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISAndEGoodsCdChgSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SAndEGoodsCdChgSetDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.08.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSAndEGoodsCdChgSetDB
    {
        /// <summary>
        /// SAndEGoodsCdChgSetDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public MediationSAndEGoodsCdChgSetDB()
        {

        }

        /// <summary>
        /// ISAndEGoodsCdChgSetDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISAndEGoodsCdChgSetDB�I�u�W�F�N�g</returns>
        public static ISAndEGoodsCdChgSetDB GetSAndEGoodsCdChgSetDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISAndEGoodsCdChgSetDB)Activator.GetObject(typeof(ISAndEGoodsCdChgSetDB), string.Format("{0}/MyAppSAndEGoodsCdChgSet", wkStr));
        }
    }
}
