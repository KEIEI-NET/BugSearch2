//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`�f�[�^�����e�i���X
// �v���O�����T�v   : ��`�f�[�^�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2010/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : zhuhh
// �C �� ��  2013/01/10  �C�����e : 2013/03/13�z�M�� Redmine #34123
//                                  ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����`�f�[�^�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����`�f�[�^�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRcvDraftDataDB
    {
        /// <summary>
        /// ����`�f�[�^�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">��������</param>
        /// <param name="paraRcvDraftDataWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����`�f�[�^�}�X�^�̃L�[�l����v����A�S�Ă̎���`�f�[�^�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
                  out object outRcvDraftDataList, object paraRcvDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
        /// <summary>
        /// ����`�f�[�^�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">��������</param>
        /// <param name="paraRcvDraftDataWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����`�f�[�^�ԍ��l����v����A����`�f�[�^�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M�� Redmine#34123</br>
        /// <br>           : ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchWithoutBabCd([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
                  out object outRcvDraftDataList, object paraRcvDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ����`�f�[�^�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">��������</param>
        /// <param name="paraRcvDraftDataWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����`�f�[�^�ԍ��l�Ƌ�s�E�x�X�R�[�h�l����v����A����`�f�[�^�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M�� Redmine#34123</br>
        /// <br>           : ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchWithBabCd([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
                  out object outRcvDraftDataList, object paraRcvDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ����`�f�[�^�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">��������</param>
        /// <param name="paraRcvDraftDataWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����`�f�[�^�ԍ��l�Ƌ�s�E�x�X�R�[�h�l����v����A����`�f�[�^�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M�� Redmine#34123</br>
        /// <br>           : ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchWithDrawingDate([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
                  out object outRcvDraftDataList, object paraRcvDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode);
        // ----- ADD zhuhh 2013/01/10 for Redmime #34123 -----<<<<<

        /// <summary>
        /// ����`�f�[�^�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">RcvDraftDataWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����`�f�[�^�}�X�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
            ref object outRcvDraftDataList);

        /// <summary>
        /// ����`�f�[�^�}�X�^����_���폜���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">RcvDraftDataWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����`�f�[�^�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
            ref object outRcvDraftDataList);

        /// <summary>
        /// �_���폜����`�f�[�^�}�X�^�����𕜊����܂�
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">RcvDraftDataWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜����`�f�[�^�}�X�^�����𕜊����܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
            ref object outRcvDraftDataList);

        /// <summary>
        /// ����`�f�[�^�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="outRcvDraftDataList">RcvDraftDataWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����`�f�[�^�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
            ref object outRcvDraftDataList);
    }


    /// <summary>
    /// �x����`�f�[�^�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �x����`�f�[�^�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPayDraftDataDB
    {
        /// <summary>
        /// �x����`�f�[�^�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">��������</param>
        /// <param name="paraPayDraftDataList">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x����`�f�[�^�}�X�^�̃L�[�l����v����A�S�Ă̎x����`�f�[�^�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
                  out object outPayDraftDataList, object paraPayDraftDataList, int readMode, ConstantManagement.LogicalMode logicalMode);

        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
        /// <summary>
        /// �x����`�f�[�^�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">��������</param>
        /// <param name="paraPayDraftDataList">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x����`�f�[�^�}�X�^�̃L�[�l����v����A�S�Ă̎x����`�f�[�^�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M�� Redmine#34123</br>
        /// <br>           : ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchWithoutBab([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
                  out object outPayDraftDataList, object paraPayDraftDataList, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �x����`�f�[�^�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">��������</param>
        /// <param name="paraPayDraftDataList">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x����`�f�[�^�}�X�^�̃L�[�l����v����A�S�Ă̎x����`�f�[�^�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M�� Redmine#34123</br>
        /// <br>           : ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchWithBab([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
                  out object outPayDraftDataList, object paraPayDraftDataList, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �x����`�f�[�^�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">��������</param>
        /// <param name="paraPayDraftDataList">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x����`�f�[�^�}�X�^�̃L�[�l����v����A�S�Ă̎x����`�f�[�^�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M�� Redmine#34123</br>
        /// <br>           : ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchWithDrawingDate([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
                  out object outPayDraftDataList, object paraPayDraftDataList, int readMode, ConstantManagement.LogicalMode logicalMode);
        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

        /// <summary>
        /// �x����`�f�[�^�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">PayDraftDataWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x����`�f�[�^�}�X�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
            ref object outPayDraftDataList);

        /// <summary>
        /// �x����`�f�[�^�}�X�^����_���폜���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">PayDraftDataWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x����`�f�[�^�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
            ref object outPayDraftDataList);

        /// <summary>
        /// �_���폜�x����`�f�[�^�}�X�^�����𕜊����܂�
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">PayDraftDataWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�x����`�f�[�^�}�X�^�����𕜊����܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
            ref object outPayDraftDataList);

        /// <summary>
        /// �x����`�f�[�^�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="outPayDraftDataList">PayDraftDataWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �x����`�f�[�^�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
            ref object outPayDraftDataList);
    }
}
