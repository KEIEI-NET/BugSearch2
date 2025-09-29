//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE���ɍX�VDB�C���^�[�t�F�[�X
//                  :   PMUOE01206O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc
// Date             :   2008.10.17
//----------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ����
// �� �� ��  2009/08/24  �C�����e : E-Parts�Ή��ɔ������o���\�b�h�ǉ�
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE���ɍX�VDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE���ɍX�VDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUOEStockUpdateDB
    {
        /// <summary>
        /// UOE���ɍX�V���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeStcUpdSearch">���������ƂȂ� UOEStockUpdSearchWork ���w�肵�܂��B</param>
        /// <param name="uoeStcUpdDataList">�������ʂ��i�[ CustomSerializeArrayList ���w�肵�܂��B</param>
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������ɍ��v����UOE�����f�[�^�A�d���f�[�^�A�d�����׃f�[�^���������܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        [MustCustomSerialization]
        int Search(
            object uoeStcUpdSearch,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object uoeStcUpdDataList,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        // -- ADD 2009/08/24 ---------------------------->>>
        /// <summary>
        /// UOE���ɍX�V���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeStcUpdSearch">���������ƂȂ� UOEStockUpdSearchWork ���w�肵�܂��B</param>
        /// <param name="uoeStcUpdDataList">�������ʂ��i�[ CustomSerializeArrayList ���w�肵�܂��B</param>
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������ɍ��v����UOE�����f�[�^�A�d���f�[�^�A�d�����׃f�[�^���������܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        [MustCustomSerialization]
        int SearchAllPartySlip(
            object uoeStcUpdSearch,
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeStcUpdDataList,
            int readMode, ConstantManagement.LogicalMode logicalMode);
        // -- ADD 2009/08/24 ----------------------------<<<

        /// <summary>
        /// UOE���ɍX�V����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeStcUpdDataList">�ǉ��E�X�V����UOE���ɍX�V�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeStockUpdateList �Ɋi�[����Ă���d���f�[�^��݌ɒ����f�[�^��o�^���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        ///
        /// CustomSerializeArrayList     [uoeStockUpdateList]
        /// ��
        /// ��IOWriteCtrlOptWork         [����E�d������f�[�^]
        /// ��
        /// ��CustomSerializeArrayList   [��֌��i�ԍX�V�p�����f�[�^�Q]
        /// ����StockSlipWork            [�d���f�[�^(�d���`��=2:����)]
        /// ����ArrayList
        /// ��  ��StockDetailWork        [�d�����׃f�[�^(����)]
        /// ��
        /// ��CustomSerializeArrayList   [�����v�コ�ꂽ�d���f�[�^�Q]
        /// ����StockSlipWork            [�d���f�[�^(�d���`��=0:�d��)]
        /// ����ArrayList
        /// ������StockDetailWork        [�d�����׃f�[�^(����)]
        /// ����ArrayList
        /// ��  ��SlipDetailAddInfoWork  [�`�[���גǉ����(����)]
        /// ��
        /// ��CustomSerializeArrayList   [�݌ɒ����f�[�^(1�`�[��)]
        ///   ��ArrayList
        ///   ����StockAdjustWork        [�݌ɒ����f�[�^(�K��1����)]
        ///   ��ArrayList
        ///     ��StockAdjustDtlWork     [�݌ɒ������׃f�[�^(����)]
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object uoeStcUpdDataList);

        /*
        /// <summary>
        /// �P���UOE���ɍX�V�����擾���܂��B
        /// </summary>
        /// <param name="uoeStockUpdateObj">UOEStockUpdateWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE���ɍX�V�̃L�[�l����v����UOE���ɍX�V�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMUOE01207D", "Broadleaf.Application.Remoting.ParamData.UOEStockUpdateWork")]
            ref object uoeStockUpdateObj,
            int readMode);

        /// <summary>
        /// UOE���ɍX�V���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeStockUpdateList">�����폜����UOE���ɍX�V�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE���ɍX�V�̃L�[�l����v����UOE���ɍX�V���𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMUOE01207D", "Broadleaf.Application.Remoting.ParamData.UOEStockUpdateWork")]
            object uoeStockUpdateList);

        /// <summary>
        /// UOE���ɍX�V����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeStockUpdateList">�ǉ��E�X�V����UOE���ɍX�V�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeStockUpdateList �Ɋi�[����Ă���UOE���ɍX�V����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMUOE01207D", "Broadleaf.Application.Remoting.ParamData.UOEStockUpdateWork")]
            ref object uoeStockUpdateList);

        /// <summary>
        /// UOE���ɍX�V����_���폜���܂��B
        /// </summary>
        /// <param name="uoeStockUpdateList">�_���폜����UOE���ɍX�V�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeStockUpdateWork �Ɋi�[����Ă���UOE���ɍX�V����_���폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE01207D", "Broadleaf.Application.Remoting.ParamData.UOEStockUpdateWork")]
            ref object uoeStockUpdateList);

        /// <summary>
        /// UOE���ɍX�V���̘_���폜���������܂��B
        /// </summary>
        /// <param name="uoeStockUpdateList">�_���폜����������UOE���ɍX�V�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeStockUpdateWork �Ɋi�[����Ă���UOE���ɍX�V���̘_���폜���������܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE01207D","Broadleaf.Application.Remoting.ParamData.UOEStockUpdateWork")]
            ref object uoeStockUpdateList);
        */
    }
}
