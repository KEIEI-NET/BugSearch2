//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE�����pI/OWriteDB�C���^�[�t�F�[�X
//                  :   PMUOE01007O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc
// Date             :   2008.09.22
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE�����pI/OWriteDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE�����pI/OWriteDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IIOWriteUOEOdrDtlDB
    {
        /// <summary>
        /// UOE�����f�[�^�ƁA����ɕR�t���d�����׃f�[�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeSendProcCndtn">��������</param>
        /// <param name="uoeOrderDtlList">��������(UOE�����f�[�^)</param>
        /// <param name="stockDtlList">��������(�d�����׃f�[�^)</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������Ɉ�v����UOE�����f�[�^�ƁA����ɕR�t���d�����׃f�[�^���擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        [MustCustomSerialization]
        int Search(
            object uoeSendProcCndtn,
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList,
            [CustomSerializationMethodParameterAttribute("MAKON01826D", "Broadleaf.Application.Remoting.ParamData.StockDetailWork")]
            ref object stockDtlList,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// UOE�����f�[�^�̓��荀�ڂ��L�[�ɁAUOE�����f�[�^�Ƃ���ɕR�t���d���f�[�^�{�d�����׃f�[�^���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">���������ƂȂ�UOE�����f�[�^</param>
        /// <param name="slipGroupList">��������(UOE�����f�[�^�A�d���f�[�^�A�d�����׃f�[�^)</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������Ɉ�v����UOE�����f�[�^�ƁA����ɕR�t���d�����׃f�[�^���擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.12.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object slipGroupList,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        // ------ADD 2023/01/20 �c������ �����d����M������Q�Ή� ------>>>>>        	
        /// <summary>
        /// UOE�����f�[�^�̓��荀�ڂ��L�[�ɁAUOE�����f�[�^�Ƃ���ɕR�t���d���f�[�^�{�d�����׃f�[�^���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">���������ƂȂ�UOE�����f�[�^</param>
        /// <param name="slipGroupList">��������(UOE�����f�[�^�A�d���f�[�^�A�d�����׃f�[�^)</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: PMKOBETSU-4202 �����d����M������Q�Ή�</br>
        /// <br>Programmer : �c������</br>
        /// <br>Date       : 2023/01/20</br>
        [MustCustomSerialization]
        int Search2(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object slipGroupList,
            int readMode, ConstantManagement.LogicalMode logicalMode);
        // ------ADD 2023/01/20 �c������ �����d����M������Q�Ή� ------<<<<<

        /// <summary>
        /// UOE�����f�[�^��ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeOdrDtlList">�ǉ��E�X�V����UOE�����f�[�^���܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList �Ɋi�[����Ă���UOE�����f�[�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOdrDtlList);

        /// <summary>
        /// UOE�����pI/OWrite����_���폜���܂��B
        /// </summary>
        /// <param name="uoeOdrDtlList">�_���폜����UOE�����f�[�^���܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ioWriteUOEOdrDtlWork �Ɋi�[����Ă���UOE�����pI/OWrite����_���폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOdrDtlList);

        /// <summary>
        /// UOE�����m�菈�����s���܂��B
        /// </summary>
        /// <param name="uoeOdrSlipList">UOE�����f�[�^���܂�ArrayList�Ɣ����f�[�^���܂�ArrayList���i�[����CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����m�菈�����s���܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        [MustCustomSerialization]
        int OrderFixation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object uoeOdrSlipList);

        /// <summary>
        /// UOE�����f�[�^�̓��荀�ڂ��L�[�ɁAUOE�����f�[�^�Ƃ���ɕR�t���d���f�[�^�{�d�����׃f�[�^���擾���܂��B
        /// </summary>
        /// <param name="paraList">��������</param>
        /// <param name="uoeOrderDtlList">��������(UOE�����f�[�^)</param>
        /// <param name="stockDtlList">��������(�d�����׃f�[�^)</param>        
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������Ɉ�v����UOE�����f�[�^�ƁA����ɕR�t���d�����׃f�[�^���擾���܂��B</br>
        /// <br>Programmer : 22008�@����</br>
        /// <br>Date       : 2009.05.25</br>
        [MustCustomSerialization]
        int UoeOdrDtlGodsReadAll(object paraList,
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList,
          [CustomSerializationMethodParameterAttribute("MAKON01826D", "Broadleaf.Application.Remoting.ParamData.StockDetailWork")]
            ref object stockDtlList);

        #region ADD 2013/04/3 Redmine#35210 wangl2 for No.1802�̑Ή�
        /// <summary>
        /// UOE�����f�[�^��ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeOdrDtlList">UOE�����f�[�^���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList �Ɋi�[����Ă���UOE�����f�[�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013.04.03</br>
        [MustCustomSerialization]
        int WriteUOESalesOrderNo(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref ArrayList uoeOdrDtlList);
        #endregion

    }
}
