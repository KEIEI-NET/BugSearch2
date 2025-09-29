//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^���X�g��DB����N���X
// �v���O�����T�v   : IOrderSetMasListDB�I�u�W�F�N�g���擾���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/04/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �����_�ݒ�}�X�^���X�g��DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IDemoFeeMessDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			 ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���OrderSetMasListDB��</br>
    /// <br>			 �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationOrderSetMasListDB
    {
        /// <summary>
        /// �����_�ݒ�}�X�^���X�gDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public MediationOrderSetMasListDB()
        {
        }

        /// <summary>
        /// IOrderSetMasListDB�I�u�W�F�N�g�̎擾
        /// </summary>
        /// <returns>IOrderSetMasListDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : IOrderSetMasListDB�I�u�W�F�N�g���擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public static IOrderSetMasListDB GetOrderSetMasListDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8009";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IOrderSetMasListDB)Activator.GetObject(typeof(IOrderSetMasListDB), string.Format("{0}/MyAppOrderSetMasList", wkStr));
        }
    }
}
