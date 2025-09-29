//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����e�i���X
// �v���O�����T�v   : ���i�R�[�h�ϊ��̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���c�`�[
// �� �� ��  2020/02/20  �C�����e : �V�K�쐬
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
    /// SAndEMkrGdsCdChgSetDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISAndEMkrGdsCdChgSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SAndEMkrGdsCdChgSetDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���c�`�[</br>
    /// <br>Date       : 2020.02.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSAndEMkrGdsCdChgSetDB
    {
        /// <summary>
        /// SAndEMkrGdsCdChgSetDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public MediationSAndEMkrGdsCdChgSetDB()
        {

        }

        /// <summary>
        /// ISAndEMkrGdsCdChgSetDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISAndEMkrGdsCdChgSetDB�I�u�W�F�N�g</returns>
        public static ISAndEMkrGdsCdChgSetDB GetSAndEMkrGdsCdChgSetDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISAndEMkrGdsCdChgSetDB)Activator.GetObject(typeof(ISAndEMkrGdsCdChgSetDB), string.Format("{0}/MyAppSAndEMkrGdsCdChgSet", wkStr));
        }
    }
}
