//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ�WarehouseConvertDB����N���X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/02/18  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// WarehouseConvertDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IWarehouseConvertDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���WarehouseConvertDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    public class MediationWarehouseConvertDB
    {
        // <summary>
        /// WarehouseConvertDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public MediationWarehouseConvertDB()
        {
            // �����Ȃ�
        }

        /// <summary>
        /// IWarehouseConvertDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IWarehouseConvertDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public static IWarehouseConvertDB GetWarehouseConvertDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            //wkStr = "http://localhost:9001";
            wkStr = "http://localhost:8009";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IWarehouseConvertDB)Activator.GetObject(typeof(IWarehouseConvertDB), string.Format("{0}/MyAppWarehouseConvert", wkStr));
        }
    }
}
