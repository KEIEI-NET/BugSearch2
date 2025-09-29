//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����h���i�֘A�ݒ�}�X�^�����e
// �v���O�����T�v   : ���R�����h���i�֘A�ݒ�}�X�^�����eDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �� �� ��  2015.01.16  �C�����e : �V�K�쐬
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
    /// ���R�����h���i�֘A�ݒ�}�X�^�����eDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^�����eDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �� �B</br>
    /// <br>Date       : 2015.01.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IRecGoodsLkDB
    {

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object RecGoodsLkWorkList);

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="parseRecGoodsLkWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            out object RecGoodsLkWorkList,
            RecGoodsLkWork parseRecGoodsLkWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e���������B
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="parseRecGoodsLkWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// �w����(CarpodTab)���ŗ��p����C���^�[�t�F�[�X�ƂȂ�܂��B<br/>
        /// �w���҂̃L�[���ƂȂ�A������ƃR�[�h���K�{�����ƂȂ�܂��B<br/>
        /// �܂���Ƌ��_�A���}�X�^�ŗL���ƂȂ�ڑ���ɂ�������݂̂��Ԃ���܂��B
        /// <br>Programmer : ���{ �G�I</br>
        /// <br>Date       : 2015.02.22</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchForBuyer(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            out object RecGoodsLkWorkList, 
            RecGoodsLkWork parseRecGoodsLkWork, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object RecGoodsLkWorkList, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object RecGoodsLkWorkList);

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object RecGoodsLkWorkList);

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object RecGoodsLkWorkList);

        // --- ADD 2015/01/22 T.Miyamoto ------------------------------------------------------------------------------------------------------------------->>>>>
        /// <summary>
        ///�w�肳�ꂽ�����̃��R�����h���i�֘A�ݒ�}�X�^���LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="count">count</param>
        /// <param name="errMsg">�G���[msg</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int SearchRcmd(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            out object retobj,
            object paraobj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            out int count,
            ref string errMsg);

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraobj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int WriteRcmd(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object paraobj);


        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">RecGoodsLkWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int DeleteRcmd(
            [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            object paraobj);

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��_���폜�Ɠo�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraDelObj">RecGoodsLkWork�I�u�W�F�N�g</param>
        /// <param name="paraUpdObj">RecGoodsLkWork�I�u�W�F�N�g</param>
        /// <param name="errorObj">RecGoodsLkWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^��_���폜�Ɠo�^�A�X�V���܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int DeleteAndWrite(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            object paraDelObj,
            ref object paraUpdObj,
            out object errorObj);

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����S�폜�A�������܂�
        /// </summary>
        /// <param name="paraDelObj">RecGoodsLkWork�I�u�W�F�N�g</param>
        /// <param name="paraUpdObj">RecGoodsLkWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^�����S�폜�A�������܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int DeleteAndRevival(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            object paraDelObj,
            ref object paraUpdObj);

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��_���폜���܂�
        /// </summary>
        /// <param name="paraobj">RecGoodsLkWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int LogicalDeleteRcmd(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object paraobj);

        /// <summary>
        /// �_���폜���R�����h���i�֘A�ݒ�}�X�^�𕜊����܂�
        /// </summary>
        /// <param name="paraobj">RecGoodsLkWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���R�����h���i�֘A�ݒ�}�X�^�𕜊����܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int RevivalLogicalDeleteRcmd(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object paraobj);
        // --- ADD 2015/01/22 T.Miyamoto -------------------------------------------------------------------------------------------------------------------<<<<<
    }
}