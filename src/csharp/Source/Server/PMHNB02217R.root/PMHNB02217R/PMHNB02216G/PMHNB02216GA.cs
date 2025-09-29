//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi���R�ꗗ�\DB����N���X
// �v���O�����T�v   : IRetGoodsReasonReportResultDB�I�u�W�F�N�g���擾���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/05/11  �C�����e : �V�K�쐬
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
    /// �ԕi���R�ꗗ�\ �����[�g�I�u�W�F�N�g����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IRetGoodsReasonReportResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���RetGoodsReasonReportResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.05.11</br>
    /// </remarks>
    public class MediationRetGoodsReasonReportResultDB
    {
        /// <summary>
        /// RetGoodsReasonReportResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        public MediationRetGoodsReasonReportResultDB()
        {
        }
        /// <summary>
        /// IRetGoodsReasonReportResultDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IRetGoodsReasonReportResultDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : IRetGoodsReasonReportResultDB�C���^�[�t�F�[�X���擾����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        public static IRetGoodsReasonReportResultDB GetRetGoodsReasonReportResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IRetGoodsReasonReportResultDB)Activator.GetObject(typeof(IRetGoodsReasonReportResultDB), string.Format("{0}/MyAppRetGoodsReasonReportResult", wkStr));
        }
    }
}
