//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i���i�}�X�^�W�JDB RemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : ���i���i�}�X�^�W�JDB RemoteObject�C���^�[�t�F�[�X���Ǘ�����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10703874-00 �쐬�S�� : huangqb
// �� �� ��  K2011/07/14 �쐬���e : �C�X�R�ʑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10703874-00 �쐬�S�� : huangqb
// �C �� ��  K2011/08/20 �C�����e : �C�X�R�ʑΉ�
//                       Redmine23619�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources; // ADD K2011/08/20
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i���i�}�X�^�W�JDB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i���i�}�X�^�W�JDB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : huangqb</br>
    /// <br>Date       : K2011/07/14</br>
    /// <br>�Ǘ��ԍ�   : 10703874-00 �C�X�R�ʑΉ�</br>
    /// <br></br>
    /// <br>Note       : �uSytem.OutOfMemoryException�v��Q�Ή�</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : K2013/04/09</br>
    /// <br>�Ǘ��ԍ�   : 10703874-00 �C�X�R�ʑΉ�</br>
    /// <br></br>
    /// 
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICostExpandDB
    {
        // ----- ADD K2011/08/20 --------------------------->>>>>
        /// <summary>
        /// ���[�U�[���i�}�X�^�Ɖ��i�}�X�^�̂ݎ擾����
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[���i�}�X�^�Ɖ��i�}�X�^�݂̂��擾���܂��B</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/08/20</br>
        /// <br>�Ǘ��ԍ�   : 10703874-00 �C�X�R�ʑΉ�</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int UsrGoodsOnlySearch([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]out object retObj, 
                               object paraObj, 
                               int readMode, 
                               ConstantManagement.LogicalMode logicalMode);
        // ----- ADD K2011/08/20 ---------------------------<<<<<

        /// <summary>
        /// ���i���i�}�X�^�W�J����
        /// </summary>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="retObj">��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i���i�}�X�^�W�J���s���܂��B</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>�Ǘ��ԍ�   : 10703874-00 �C�X�R�ʑΉ�</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int CostExpand(object paraObj,
                       [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]out object retObj);

        // --- ADD K2013/04/05 Y.Wakita ---------->>>>>
        /// <summary>
        /// �|���ݒ�}�X�^��_���폜���܂�
        /// </summary>
        /// <param name="paraObj">RateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���ݒ�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : �e�c�@���V</br>
        /// <br>Date       : K2013/04/05</br>
        [MustCustomSerialization]
        int LogicalDelete(
			ref object paraObj
            );
        // --- ADD K2013/04/05 Y.Wakita ----------<<<<<
    }
}
