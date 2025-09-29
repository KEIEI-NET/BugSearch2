//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����f�[�^�e�L�X�g�o�́i�s�l�x�j
// �v���O�����T�v   : ����f�[�^�e�L�X�g�o�́i�s�l�x�j�@DBRemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : ���N�n��
// �� �� ��  2011/10/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary> ����f�[�^�e�L�X�gDB�C���^�[�t�F�[�X</summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�jDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���N�n��</br>										
    /// <br>Date       : 2012/10/31</br>										
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesSliptextResultDB
    {
        /// <summary>
        ///  ����f�[�^�e�L�X�g�o�́i�s�l�x�j��񃊃X�g�̎擾�����B
        /// </summary>
        /// <param name="salesSliptextResultWork">��������</param>
        /// <param name="salesSliptextcndtnWork">��������</param>
        /// <param name="retMsg"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�j��񃊃X�g�̎擾�����B</br>
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>  
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN07707D", "Broadleaf.Application.Remoting.ParamData.SalesSliptextResultWork")]
            out object salesSliptextResultWork,
            object salesSliptextcndtnWork,
            out string retMsg);

    }
}
