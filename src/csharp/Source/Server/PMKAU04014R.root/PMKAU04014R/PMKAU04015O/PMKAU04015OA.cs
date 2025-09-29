using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���Ӑ�d�q���� DBRemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���Ӑ�d�q�����@DBRemoteObject�C���^�[�t�F�[�X�ł��B</br>
	/// <br>Programmer : 23015 �X�{ ��P</br>
	/// <br>Date       : 2008.07.30</br>
	/// <br></br>
	/// <br>Update Note: �_�P�Y��-�^�M���� �Ή�</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2013/03/13</br>
    /// <br>Update Note: 2015/02/05 ������</br>
    /// <br>           : �e�L�X�g�o�͌��������Ȃ����[�h�̒ǉ�</br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustPrtPprWorkDB
	{
        /// <summary>
        /// ���Ӑ�d�q���� �c���Ɖ�E�`�[�\���E���ו\���̃��X�g�𒊏o���܂�
		/// </summary>
        /// <param name="custPrtPprBlDspRsltWork">��������(�c���Ɖ�)</param>
        /// <param name="custPrtPprSalTblRsltWork">��������(����f�[�^)</param>
        /// <param name="custPrtPprWork">�����p�����[�^</param>
        /// <param name="recordCount">��������(����)</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        [MustCustomSerialization]
        int SearchRef(
            [CustomSerializationMethodParameterAttribute("PMKAU04016D", "Broadleaf.Application.Remoting.ParamData.CustPrtPprBlDspRsltWork")]
            ref object custPrtPprBlDspRsltWork,
            [CustomSerializationMethodParameterAttribute("PMKAU04016D", "Broadleaf.Application.Remoting.ParamData.CustPrtPprSalTblRsltWork")]
            ref object custPrtPprSalTblRsltWork,
            object custPrtPprWork,
            out Int64 recordCount,
			int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// ���Ӑ�d�q���� �c���ꗗ�\���̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="custPrtPprBlTblRsltWork">��������</param>
        /// <param name="custPrtPprBlnceWork">�����p�����[�^</param>
        /// <param name="SrchKndDiv">������� 0:���� 1:���|</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        [MustCustomSerialization]
        int SearchBlTbl(
            [CustomSerializationMethodParameterAttribute("PMKAU04016D", "Broadleaf.Application.Remoting.ParamData.CustPrtPprBlTblRsltWork")]
			ref object custPrtPprBlTblRsltWork,
            object custPrtPprBlnceWork,
            int SrchKndDiv,
            int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
        /// <summary>
        /// ���Ӑ�d�q���� �c���ꗗ�\���i�^�M�c���o�͗p�j�̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="custPrtPprBlTblOutputRsltWork">��������</param>
        /// <param name="custPrtPprBlnceWork">�����p�����[�^</param>
        /// <param name="SrchKndDiv">������� 0:���� 1:���|</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30744 ���� ����q</br>
        /// <br>Date       : 2013/03/13</br>
        [MustCustomSerialization]
        int SearchBlTblOutput(
            [CustomSerializationMethodParameterAttribute("PMKAU04016D", "Broadleaf.Application.Remoting.ParamData.CustPrtPprBlTblRsltWork")]
			ref object custPrtPprBlTblRsltWork,
            object custPrtPprBlnceWork,
            int SrchKndDiv,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            bool CreditMng
            );

        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
        /// <summary>
        /// ����`�[�ǂݍ��ݏ����i�����܂ށj
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retList"></param>
        /// <param name="retRelationList"></param>
        /// <returns></returns>
        int ReadSalesSlip(
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
            ref object paraList,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
            out object retList,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
            out object retRelationList,
            int readMode
            );
        /// <summary>
        /// �����`�[�ԍ��ɂ��d���f�[�^�̌������s���܂��B
        /// </summary>
        /// <param name="retStockSlipList">�������ʂ��i�[���� CustomSerializeArrayList ���w�肵�܂��B</param>
        /// <param name="paraStockSlip">�����������i�[���� StockSlip ���w�肵�܂��B</param>
        /// <param name="mode">0:���S��v 1:�O����v 2:���S��v�{�d�����׎擾</param>
        /// <returns>STATUS</returns>
        int SearchPartySaleSlipNum(
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
            ref object retStockSlipList,
            object paraStockSlip,
            int mode );
        /// <summary>
        /// �G���g���X�V�Ăяo��
        /// </summary>
        /// <param name="paraList">�X�V���I�u�W�F�N�g���X�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int WriteByIOWriter( [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                  ref object paraList,
                   out string retMsg, out string retItemInfo );
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

        // --- ADD 2012/12/17 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// �T�[�o�[�V�X�e�����t�擾��߂��܂�		
        /// </summary>
        /// <returns>DateTime.now</returns>
        /// <br>Note        : �T�[�o�[�V�X�e�����t�擾��߂��܂�	</br>
        /// <br>Programmer  : �{�{ ����</br>
        /// <br>Date        : 2012.12.17</br>
        DateTime GetServerNowTime();
        // --- ADD 2012/12/17 T.Miyamoto ------------------------------<<<<<

        //----- ADD 2015/02/05 ������ -------------------->>>>>
        /// <summary>
        /// ��������w�肳��Ȃ��ꍇ�ADB����J�n�E�I�����������������
        /// </summary>
        /// <param name="salesDateSt">�J�n�����</param>
        /// <param name="salesDateEd">�I�������</param>
        /// <param name="custPrtPprParam">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : ��������w�肳��Ȃ��ꍇ�ADB����J�n�E�I�����������������</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2015/02/05</br>
        /// </remarks>
        int GetSalesDate(
            out DateTime salesDateSt, 
            out DateTime salesDateEd, 
            object custPrtPprParam, 
            ConstantManagement.LogicalMode logicalMode);
        //----- ADD 2015/02/05 ������ --------------------<<<<<
    }
}
