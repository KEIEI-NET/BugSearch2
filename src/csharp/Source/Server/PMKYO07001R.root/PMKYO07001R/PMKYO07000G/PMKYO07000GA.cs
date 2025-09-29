//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^���M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// APBaseDataExtraDefSetDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IIAPSendMessageDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���IAPSendMessageDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class APBaseDataExtraDefSetDB
    {
        /// <summary>
        /// APBaseDataExtraDefSetDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APBaseDataExtraDefSetDB()
        {
        }
        /// <summary>
        /// ISalesSlipDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IIOWriteMAHNBDB�I�u�W�F�N�g</returns>
        public static IAPSendMessageDB GetExtraAndUpdControlDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
# endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IAPSendMessageDB)Activator.GetObject(typeof(IAPSendMessageDB), string.Format("{0}/MyAppAPSendMessage", wkStr));
        }
    }
}
