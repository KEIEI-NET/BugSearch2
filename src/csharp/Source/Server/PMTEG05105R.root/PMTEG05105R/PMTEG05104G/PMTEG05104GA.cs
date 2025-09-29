//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���ώ�`��������
// �v���O�����T�v   : ���ώ�`��������DB����N���X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���ώ�`��������
// �� �� ��  2010/04/22  �C�����e : �V�K�쐬
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
    /// ���ώ�`��������DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X�͌��ώ�`��������DB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SettlementBillDelDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���ώ�`��������</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    public class MediationSettlementBillDelDB
    {
        /// <summary>
        /// ���ώ�`������������N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���ώ�`��������</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>
        public MediationSettlementBillDelDB()
        {
        }
        /// <summary>
        /// ISettlementBillDelDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISettlementBillDelDB�I�u�W�F�N�g</returns>
        public static ISettlementBillDelDB GetSettlementBillDelDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISettlementBillDelDB)Activator.GetObject(typeof(ISettlementBillDelDB), string.Format("{0}/MyAppSettlementBillDel", wkStr));
        }
    }
}
