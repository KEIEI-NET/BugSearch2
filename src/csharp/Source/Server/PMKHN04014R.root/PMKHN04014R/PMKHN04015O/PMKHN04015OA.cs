using System;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���Ӑ挟�� RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ挟�� RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 980076�@�Ȓ��@����Y</br>
	/// <br>Date       : 2007.02.13</br>
	/// <br></br>
    /// <br>Update Note: MANTIS:14720 ���Ӑ於�����ǉ�</br>
    /// <br>Programmer : 30517 �Ė� �x��</br>
    /// <br>Date       : 2009/12/02</br>
    /// <br>Update Note: ���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
    /// <br>Programmer : PM1107C ���юR</br>
    /// <br>Date       : 2011/07/22</br>
    /// <br>Update Note: PM-Tablet�̉��C</br>
    /// <br>�Ǘ��ԍ�   :10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/05/29</br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface ICustomerSearchDB
	{
		/// <summary>
		/// �w�肳�ꂽ�����̓��Ӑ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retObj">��������</param>
		/// <param name="paraObj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN04016D", "Broadleaf.Application.Remoting.ParamData.CustomerSearchRetWork")]
			out object retObj,
            [CustomSerializationMethodParameterAttribute("PMKHN04016D", "Broadleaf.Application.Remoting.ParamData.CustomerSearchParaWork")]
			ref object paraObj,
			CustomerSearchReadMode readMode,
			ConstantManagement.LogicalMode logicalMode);

        // --------------- ADD START 2013/05/29 wangl2 FOR PM-Tablet------>>>>
        /// <summary>
        /// PMTAB���Ӑ挟�����ʏ���S�Ė߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchForTablet(
            [CustomSerializationMethodParameterAttribute("PMKHN09016D", "Broadleaf.Application.Remoting.ParamData.CustomerWork")]
			out object retObj,
            [CustomSerializationMethodParameterAttribute("PMKHN04016D", "Broadleaf.Application.Remoting.ParamData.CustomerSearchParaWork")]
			ref object paraObj,
            ConstantManagement.LogicalMode logicalMode);
        // --------------- ADD END 2013/05/29 wangl2 FOR PM-Tablet--------<<<<
	}

	/// <summary>
	/// CustomerSearchReadMode
	/// </summary>
    /// <remarks>
    /// <br>Update Note: �d�b�ԍ������ǉ��Ɣ����C��</br>
    /// <br>Programmer : PM1012A �� ��</br>
    /// <br>Date       : 2010/08/06</br>
    /// </remarks>
	public enum CustomerSearchReadMode
	{
		/// <summary>�S������������</summary>
		CustomerSearchMode_All = 0,							// �S�������������i�l�̂�����̂𗘗p�j
		/// <summary>���Ӑ�R�[�h����</summary>
		CustomerSearchMode_Customer_Code = 1000,			// ���Ӑ�R�[�h����
		/// <summary>���Ӑ�T�u�R�[�h</summary>
		CustomerSearchMode_Customer_SubCode = 1001,			// ���Ӑ�T�u�R�[�h
		/// <summary>���Ӑ�d�b�ԍ�����</summary>
		CustomerSearchMode_Customer_Tel = 1002,				// ���Ӑ�d�b�ԍ�����
		/// <summary>���Ӑ�J�i����</summary>
		CustomerSearchMode_Customer_Kana = 1003,			// ���Ӑ�J�i����
		/// <summary>�d����敪����</summary>
		CustomerSearchMode_Customer_SupplierDiv = 1004,		// �d����敪����		// ���g�p
		/// <summary>�Ɣ̐�敪����</summary>
		CustomerSearchMode_Customer_AcceptWholeSale = 1005, // �Ɣ̐�敪����		// ���g�p
		/// <summary>���̓R�[�h1����</summary>
		CustomerSearchMode_Customer_CustAnalysCode1 = 1006, // ���̓R�[�h����
		/// <summary>���̓R�[�h2����</summary>
		CustomerSearchMode_Customer_CustAnalysCode2 = 1007, // ���̓R�[�h����
		/// <summary>���̓R�[�h3����</summary>
		CustomerSearchMode_Customer_CustAnalysCode3 = 1008, // ���̓R�[�h����
		/// <summary>���̓R�[�h4����</summary>
		CustomerSearchMode_Customer_CustAnalysCode4 = 1009, // ���̓R�[�h����
		/// <summary>���̓R�[�h5����</summary>
		CustomerSearchMode_Customer_CustAnalysCode5 = 1010, // ���̓R�[�h����
		/// <summary>���̓R�[�h6����</summary>
		CustomerSearchMode_Customer_CustAnalysCode6 = 1011, // ���̓R�[�h����
		/// <summary>���Ӑ�S���҃R�[�h����</summary>
		CustomerSearchMode_Customer_CustomerAgentCd = 1012, // ���Ӑ�S���҃R�[�h����
		/// <summary>���Ӑ�敪����</summary>
		CustomerSearchMode_Customer_CustomerDiv = 1013,		// ���Ӑ�敪����
        /// <summary>�Ǘ����_�R�[�h����</summary>
        CustomerSearchMode_Customer_MngSecCode = 1014,      // �Ǘ����_�R�[�h
        // 2009/12/02 Add >>>
        /// <summary>���Ӑ於����</summary>
        CustomerSearchMode_Customer_Name = 1015,			// ���Ӑ挟��
        // 2009/12/02 Add <<<
        // ---ADD 2010/08/06-------------------->>>
        /// <summary>�d�b�ԍ�����</summary>
        CustomerSearchMode_Customer_TelNum = 1016,          // �d�b�ԍ�����
        // ---ADD 2010/08/06--------------------<<<
        // 2011/7/22 XUJS ADD STA>>>>>>
        CustomerSearchMode_Customer_CustomerSnm = 1017,     //����
        // 2011/7/22 XUJS ADD END<<<<<<

	}
}
