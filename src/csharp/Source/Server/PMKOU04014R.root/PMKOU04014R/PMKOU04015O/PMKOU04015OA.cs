using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �d����d�q���� DBRemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �d����d�q�����@DBRemoteObject�C���^�[�t�F�[�X�ł��B</br>
	/// <br>Programmer : 23015 �X�{ ��P</br>
	/// <br>Date       : 2008.08.18</br>
	/// <br></br>
	/// <br>Update Note: </br>
    //----------------------------------------------------------------------------//
    // �Ǘ��ԍ�              �쐬�S�� : FSI��c �W�v
    // �C �� ��  2013/01/21  �C�����e : �d���ԕi�\��@�\�Ή�
    //----------------------------------------------------------------------------//
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISuppPrtPprWorkDB
	{
        /// <summary>
        /// �d����d�q���� �c���Ɖ�E�`�[�\���E���ו\���̃��X�g�𒊏o���܂�
		/// </summary>
        /// <param name="suppPrtPprBlDspRsltWork">��������(�c���Ɖ�)</param>
        /// <param name="suppPrtPprStcTblRsltWork">��������(�d���f�[�^)</param>
        /// <param name="suppPrtPprWork">�����p�����[�^</param>
        /// <param name="recordCount">��������(����)</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        [MustCustomSerialization]
        int SearchRef(
            [CustomSerializationMethodParameterAttribute("PMKOU04016D", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprBlDspRsltWork")]
            ref object suppPrtPprBlDspRsltWork,
            [CustomSerializationMethodParameterAttribute("PMKOU04016D", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprStcTblRsltWork")]
            ref object suppPrtPprStcTblRsltWork,
            object suppPrtPprWork,
            out Int64 recordCount,
			int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// �d����d�q���� �c���ꗗ�\���̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="suppPrtPprBlTblRsltWork">��������</param>
        /// <param name="suppPrtPprBlnceWork">�����p�����[�^</param>
        /// <param name="SrchKndDiv">������� 0:�x�� 1:���|</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        [MustCustomSerialization]
        int SearchBlTbl(
            [CustomSerializationMethodParameterAttribute("PMKOU04016D", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprBlTblRsltWork")]
			ref object suppPrtPprBlTblRsltWork,
            object suppPrtPprBlnceWork,
            int SrchKndDiv,
            int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>
        /// �d���ԕi�\����\���̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="suppPrtPprStcTblRsltWork">��������</param>
        /// <param name="suppPrtPprWork">�����p�����[�^</param>
        /// <param name="recordCount">��������(����)</param>
        /// <param name="logicalDelDiv">�폜�w��敪(0:�ʏ� 1:�폜���̂�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchRefPurchaseReturnSchedule(
            [CustomSerializationMethodParameterAttribute("PMKOU04016D", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprStcTblRsltWork")]
            ref object suppPrtPprStcTblRsltWork,
            object suppPrtPprWork,
            out Int64 recordCount,
            int logicalDelDiv
            );
        // ----------ADD 2013/01/21-----------<<<<<

    }
}
