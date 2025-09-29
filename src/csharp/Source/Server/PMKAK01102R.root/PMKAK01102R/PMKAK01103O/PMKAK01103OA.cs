//***************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���ԕi�v��X�V���i
// �v���O�����T�v   : �d���ԕi�v��X�V���i RemoteObject Interface 
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI�֓� �a�G
// �� �� ��  2013/01/22  �C�����e : �d���ԕi�\��@�\�ǉ��Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d���ԕi�v��X�V���i�����[�g�I�u�W�F�N�gDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���ԕi�v��X�V���i�����[�g�I�u�W�F�N�gDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : FSI�֓� �a�G</br>
    /// <br>Date       : 2013/01/22</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockSlipRetPlnDB
    {
        /// <summary>
        /// �G���g���X�V
        /// </summary>
        /// <param name="paraList">�X�V���I�u�W�F�N�g���X�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                  ref object paraList,
                  out string retMsg, out string retItemInfo);

        /// <summary>
        /// ���㖾�׏��Ǎ�
        /// </summary>
        /// <param name="salesDetailWork">���㖾�׃f�[�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="salesSlipNumList">����`�[�ԍ����X�g</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����`�[�ԍ����甄�㖾�׏����擾���܂�</br>
        /// <br>Programmer : FSI���� �G</br>
        /// <br>Date       : 2013/01/24</br>
        [MustCustomSerialization]
        int SearchSalesDetail(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object salesDetailWork,
            string enterpriseCode,
            object salesSlipNumList,
            string sectionCode
            );

        /// <summary>
        /// �_���폜���܂�
        /// </summary>
        /// <param name="stockSlipWork">�I�u�W�F�N�g</param>
        /// <param name="retMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����_���폜���܂�</br>
        /// <br>Programmer : FSI���� ���</br>
        /// <br>Date       : 2013/01/23</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKON01826D", "Broadleaf.Application.Remoting.ParamData.StockSlipWork")]
            ref object stockSlipWork
          , out string retMsg
            );

        /// <summary>
        /// �G���g���X�V
        /// </summary>
        /// <param name="paraList">�X�V���I�u�W�F�N�g���X�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int AddUp([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                  ref object paraList,
                  out string retMsg, out string retItemInfo);
    }
}
