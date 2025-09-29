//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���M���O�\��
// �v���O�����T�v   : ���M���O�\��DB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2019/12/02  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���M���O�\��DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���M���O�\��DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/12/02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalCprtSndLogDB
    {
        /// <summary>
        /// ����f�[�^���M���O�e�[�u���̃��O���擾
        /// </summary>
        /// <param name="salCprtSndLogListResultWork">����f�[�^���M���O���o����</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="salCprtSndLogListCondPara">����f�[�^���M���O���o�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchSalCprtSndLog(
            [CustomSerializationMethodParameterAttribute("PMSDC04007D", "Broadleaf.Application.Remoting.ParamData.SalCprtSndLogListResultWork")]
            out object salCprtSndLogListResultWork, 
            out string errMessage,
            ref object salCprtSndLogListCondPara,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// SE����f�[�^���M���O�e�[�u���̃��O�����폜����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        int ResetSalCprtSndLog(
            out string errMessage,
            string enterpriseCode);

    }
}