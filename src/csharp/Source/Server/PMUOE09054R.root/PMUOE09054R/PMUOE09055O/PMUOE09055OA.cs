//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : UOE�ڑ�����}�X�^�����e�i���X
// �v���O�����T�v   : UOE�ڑ�����}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : caowj
// �� �� ��  2010/07/26  �C�����e : �V�K�쐬
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
    /// UOE�ڑ�����DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE�ڑ�����DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : caowj</br>
    /// <br>Date       : 2010/07/26</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUOEConnectInfoDB
    {
        /// <summary>
        /// UOE�ڑ�����LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMUOE09056D", "Broadleaf.Application.Remoting.ParamData.UOEConnectInfoWork")]
			out object retobj,
            object paraobj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// UOE�ڑ�����}�X�^LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retbyte">��������</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/27</br>
        int Search(out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �w�肳�ꂽUOE�ڑ�����Guid��UOE�ڑ������߂��܂�
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽUOE�ڑ�����Guid��UOE�ڑ������߂��܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// UOE�ڑ������o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�ڑ������o�^�A�X�V���܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        int Write(ref byte[] parabyte);

        /// <summary>
        /// UOE�ڑ�����𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�ڑ�����𕨗��폜���܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// UOE�ڑ������_���폜���܂�
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�ڑ������_���폜���܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        int LogicalDelete(ref byte[] parabyte);

        /// <summary>
        /// �_���폜UOE�ڑ�����𕜊����܂�
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜UOE�ڑ�����𕜊����܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        int RevivalLogicalDelete(ref byte[] parabyte);
    }
}
