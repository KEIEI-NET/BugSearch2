//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �t���E�����E�c�l�e�L�X�g�o��
// �v���O�����T�v   : �t���E�����E�c�l�e�L�X�g�o�͂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>																	
    /// �}�X�^�ꗗ�\DB RemoteObject�C���^�[�t�F�[�X																	
    /// </summary>																	
    /// <remarks>																	
    /// <br>Note       : �}�X�^�ꗗ�\DB RemoteObject Interface�ł��B</br>																	
    /// <br>Programmer : ���R</br>																	
    /// <br>Date       : 2009.04.01</br>																	
    /// <br></br>																	
    /// <br>Update Note: </br>																	
    /// </remarks>																	
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUseMastListDB
    {
        /// <summary>																	
        /// ���Ӑ�ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y																	
        /// </summary>																	
        /// <param name="ListRetWorkList">��������</param>																	
        /// <param name="ListParaWork">�����p�����[�^</param>																	
        /// <returns>STATUS</returns>																	
        /// <br>Note       : </br>																	
        /// <br>Programmer : ���R</br>																	
        /// <br>Date       : 2009.04.01</br>																	
        [MustCustomSerialization]
        int SearchCustomer(
            [CustomSerializationMethodParameterAttribute("PMKHN07007D", "Broadleaf.Application.Remoting.ParamData.PostCustomerWork")]																	
			 out object ListRetWorkList,object ListParaWork);

        /// <summary>																	
        /// ���_�ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y																	
        /// </summary>																	
        /// <param name="ListRetWorkList">��������</param>																	
        /// <param name="ListParaWork">�����p�����[�^</param>																	
        /// <returns>STATUS</returns>																	
        /// <br>Note       : </br>																	
        /// <br>Programmer : ���R</br>																	
        /// <br>Date       : 2009.04.01</br>																	
        [MustCustomSerialization]
        int SearchSecInfoSet(
            [CustomSerializationMethodParameterAttribute("PMKHN07007D", "Broadleaf.Application.Remoting.ParamData.PostSecInfoSetWork")]																	
			 out object ListRetWorkList, object ListParaWork);

    }																	

}
