//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ�EmployeeConvertDB����N���X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/10  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// EmployeeConvertDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IEmployeeConvertDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���EmployeeConvertDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    public class MediationEmployeeConvertDB
    {
        #region -- Constructor --

        // <summary>
        /// EmployeeConvertDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public MediationEmployeeConvertDB()
        {
            // �����Ȃ�
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// IEmployeeConvertDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IEmployeeConvertDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public static IEmployeeConvertDB GetEmployeeConvertDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            //wkStr = "http://localhost:9001";
            wkStr = "http://localhost:8008";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IEmployeeConvertDB)Activator.GetObject(typeof(IEmployeeConvertDB), string.Format("{0}/MyAppEmployeeConvert", wkStr));
        }

        #endregion
    }
}
