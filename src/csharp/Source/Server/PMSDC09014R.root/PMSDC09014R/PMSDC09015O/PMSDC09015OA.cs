//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ڑ�����}�X�^�����e�i���X
// �v���O�����T�v   : �ڑ�����}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901034-00 �쐬�S�� : �c����
// �� �� ��  2019/12/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ڑ�����ݒ�DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ڑ�����ݒ�DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/12/03</br>
    /// <br>�Ǘ��ԍ�   : 10901034-00</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalCprtConnectInfoPrcPrStDB
    {
        /// <summary>
        ///  �ڑ�����ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="outConnectInfoPrcPrSt">��������</param>
        /// <param name="paraConnectInfoWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����ݒ�LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSDC09016D", "Broadleaf.Application.Remoting.ParamData.SalCprtConnectInfoWork")]
			out object outConnectInfoPrcPrSt,
            object paraConnectInfoWork,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �w�肳�ꂽ�ڑ�����ݒ�Guid�̐ڑ�����ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :  �w�肳�ꂽ�ڑ�����ݒ�Guid�̐ڑ�����ݒ��߂��܂�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        int Read(ref byte[] parabyte, int readMode);
        
        /// <summary>
        ///�ڑ�����}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="connectInfoWork">�_���폜����ڑ�����}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMSDC09016D", "Broadleaf.Application.Remoting.ParamData.SalCprtConnectInfoWork")]
            ref object connectInfoWork);

        /// <summary>
        /// �ڑ�����}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="connectInfoWorkbyte">�ǉ��E�X�V����ڑ�����}�X�^���</param>
        /// <param name="writeMode">�X�V�敪</param>
        /// <param name="flag">���ԍX�V�t���O</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMSDC09016D", "Broadleaf.Application.Remoting.ParamData.SalCprtConnectInfoWork")]
            ref object connectInfoWorkbyte, int writeMode, int flag);

        /// <summary>
        /// �ڑ�����}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="connectInfoWork">�_���폜����������ڑ�����}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMSDC09016D", "Broadleaf.Application.Remoting.ParamData.SalCprtConnectInfoWork")]
            ref object connectInfoWork);

        /// <summary>
        /// �ڑ�����}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWork�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        int Delete(byte[] parabyte);      
    }
}
