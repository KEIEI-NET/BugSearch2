//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���ڕW�ݒ�}�X�^�i����j
// �v���O�����T�v   : �L�����y�[���ڕW�ݒ�}�X�^�Őݒ肵�����e���ꗗ�o�͂�
//                    �m�F����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CampTrgtPrintResultDB ����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ICampTrgtPrintResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CampTrgtPrintResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �k���r</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCampTrgtPrintResultDB
    {
        /// <summary>
        /// SalTrgtPrintResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public MediationCampTrgtPrintResultDB()
        {
        }

        /// <summary>
        /// ICampTrgtPrintResultDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ICampTrgtPrintResultDB�I�u�W�F�N�g</returns>
        public static ICampTrgtPrintResultDB GetCampTrgtPrintResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ICampTrgtPrintResultDB)Activator.GetObject(typeof(ICampTrgtPrintResultDB), string.Format("{0}/MyAppCampTrgtPrintResult", wkStr));
        }
    }
}
