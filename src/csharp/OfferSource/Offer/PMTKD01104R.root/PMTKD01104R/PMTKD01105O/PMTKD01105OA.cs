//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �񋟃f�[�^�폜����DB RemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : �񋟃f�[�^�폜����DB RemoteObject Interface�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/06/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �񋟃f�[�^�폜���� �����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �񋟃f�[�^�폜���� �����[�g �C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.06.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IOfferDataDeleteDB
    {
        /// <summary>
        /// �񋟃f�[�^�폜����
        /// </summary>
        /// <param name="offerDataDeleteList">�񋟃f�[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �񋟃f�[�^�폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.16</br>
        [MustCustomSerialization]
        int DeleteOfferData(
            [CustomSerializationMethodParameterAttribute("PMTKD01106D", "Broadleaf.Application.Remoting.ParamData.OfferDataDeleteWork")]
           ref object offerDataDeleteList);

        /// <summary>
        /// �T�[�o�[�̃��W�X�g���X�V����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �T�[�o�[�̃��W�X�g���X�V����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.16</br>
        int ServerRegeditUpdate();
    }


}
