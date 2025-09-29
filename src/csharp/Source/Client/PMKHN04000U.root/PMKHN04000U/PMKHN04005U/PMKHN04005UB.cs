using System;
using System.Text;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.UIData
{
	internal class CustomerSimpleSearchCndtn : CustomerSearchPara
	{
		/// <summary>
		/// ���o�������͏��N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���o�������͏��N���X�̃R���X�g���N�^�ł�</br>
		/// <br>Programer        :   22018�@��ؐ��b</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2009/12/02 30517 �Ė� �x��</br>
        /// <br>             MANTIS:14720 ���Ӑ於�����ǉ�</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/27 ���юR</br>
        /// <br>             PM1107C:�i�荞�݃t�B���^�[�ǉ�(#9)</br>
        /// <br>------------------------------------------------------------------------------------</br> 
        /// </remarks>
        public CustomerSimpleSearchCndtn()
            : base()
		{
			this.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		}

		/// <summary>
		/// �C���X�^���X������
		/// </summary>
		/// <param name="source">���N���X</param>
		/// <returns>�C���X�^���X����̓��Ӑ�ԗ����������N���X</returns>
        public static CustomerSimpleSearchCndtn Create( CustomerSimpleSearchCndtn source )
		{
            CustomerSimpleSearchCndtn customerSearchExtractionConditionInfo = new CustomerSimpleSearchCndtn();
			customerSearchExtractionConditionInfo.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// �����^�C�v�͌�����ێ�����
			customerSearchExtractionConditionInfo.CustomerSubCodeSearchType = source.CustomerSubCodeSearchType;
			customerSearchExtractionConditionInfo.KanaSearchType = source.KanaSearchType;

			return customerSearchExtractionConditionInfo;
		}

		/// <summary>
		/// ���o�������͏��N���X��������
		/// </summary>
		/// <returns>CusCarSearchExtractionConditionInfo�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CusCarSearchExtractionConditionInfo�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   22018�@��ؐ��b</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/25 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
        public new CustomerSimpleSearchCndtn Clone()
		{
            CustomerSimpleSearchCndtn ret = new CustomerSimpleSearchCndtn();
			CustomerSearchPara customerSearchPara = base.Clone();

			ret.EnterpriseCode = customerSearchPara.EnterpriseCode;
			ret.CustomerCode = customerSearchPara.CustomerCode;
			ret.CustomerSubCode = customerSearchPara.CustomerSubCode;
			ret.Kana = customerSearchPara.Kana;
			ret.SearchTelNo = customerSearchPara.SearchTelNo;
			ret.LogicalDeleteDataPickUp = customerSearchPara.LogicalDeleteDataPickUp;
			ret.AcceptWholeSale = customerSearchPara.AcceptWholeSale;
			ret.CustomerSubCodeSearchType = customerSearchPara.CustomerSubCodeSearchType;
			ret.KanaSearchType = customerSearchPara.KanaSearchType;

			ret.CustAnalysCode1 = customerSearchPara.CustAnalysCode1;
			ret.CustAnalysCode2 = customerSearchPara.CustAnalysCode2;
			ret.CustAnalysCode3 = customerSearchPara.CustAnalysCode3;
			ret.CustAnalysCode4 = customerSearchPara.CustAnalysCode4;
			ret.CustAnalysCode5 = customerSearchPara.CustAnalysCode5;
			ret.CustAnalysCode6 = customerSearchPara.CustAnalysCode6;
			ret.CustomerAgentCd = customerSearchPara.CustomerAgentCd;
			ret.CustomerAgentNm = customerSearchPara.CustomerAgentNm;
			ret.BillCollecterCd = customerSearchPara.BillCollecterCd;
			ret.BillCollecterNm = customerSearchPara.BillCollecterNm;
			ret.LogicalDeleteDataPickUp = customerSearchPara.LogicalDeleteDataPickUp;
			ret.EnterpriseName = customerSearchPara.EnterpriseName;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ret.MngSectionCode = customerSearchPara.MngSectionCode;
            ret.MngSectionName = customerSearchPara.MngSectionName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009/12/02 Add >>>
            ret.Name = customerSearchPara.Name;
            ret.NameSearchType = customerSearchPara.NameSearchType;
            // 2009/12/02 Add <<<

            // 2011/07/27 XUJS ADD STA>>>>>>
            ret.CustomerSnm = customerSearchPara.CustomerSnm;
            ret.CustomerSnmSearchType = customerSearchPara.CustomerSnmSearchType;
			// 2011/07/27 XUJS END END<<<<<<
            

			return ret;
		}

		/// <summary>
		/// ���o�������͏��N���X�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CusCarSearchExtractionConditionInfo�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CusCarSearchExtractionConditionInfo�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   22018�@��ؐ��b</br>
		/// </remarks>
        public bool Equals( CustomerSimpleSearchCndtn target )
		{
			return base.Equals(target);
		}
	
		/// <summary>
		/// ���o�������͏��N���X�N���X��r����
		/// </summary>
		/// <param name="customerSearchExtractionConditionInfo1">
		///                    ��r����CusCarSearchExtractionConditionInfo�N���X�̃C���X�^���X
		/// </param>
		/// <param name="customerSearchExtractionConditionInfo2">��r����CusCarSearchExtractionConditionInfo�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CusCarSearchExtractionConditionInfo�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   22018�@��ؐ��b</br>
		/// </remarks>
        public static bool Equals( CustomerSimpleSearchCndtn customerSearchExtractionConditionInfo1, CustomerSimpleSearchCndtn customerSearchExtractionConditionInfo2 )
		{
			return CustomerSearchPara.Equals(customerSearchExtractionConditionInfo1, customerSearchExtractionConditionInfo2);
		}

		/// <summary>
		/// ���o�������͏��N���X�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CusCarSearchExtractionConditionInfo�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CusCarSearchExtractionConditionInfo�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   22018�@��ؐ��b</br>
		/// </remarks>
        public ArrayList Compare( CustomerSimpleSearchCndtn target )
		{
			return base.Compare(target);
		}

		/// <summary>
		/// ���o�������͏��N���X�N���X��r����
		/// </summary>
		/// <param name="customerSearchExtractionConditionInfo1">��r����CusCarSearchExtractionConditionInfo�N���X�̃C���X�^���X</param>
		/// <param name="customerSearchExtractionConditionInfo2">��r����CusCarSearchExtractionConditionInfo�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CusCarSearchExtractionConditionInfo�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public static ArrayList Compare( CustomerSimpleSearchCndtn customerSearchExtractionConditionInfo1, CustomerSimpleSearchCndtn customerSearchExtractionConditionInfo2 )
		{
			return CustomerSearchPara.Compare(customerSearchExtractionConditionInfo1, customerSearchExtractionConditionInfo2);
		}

		public override string ToString()
		{
			StringBuilder message = new StringBuilder();

			// ���Ӑ�R�[�h
			if (this.CustomerCode != 0)
			{
				message.Append("\r\n" + "���Ӑ�R�[�h : " + this.CustomerCode.ToString());
			}

			// ���Ӑ�T�u�R�[�h
			if (this.CustomerSubCode.Trim() != "")
			{
				message.Append("\r\n" + "���Ӑ�T�u�R�[�h : " + this.CustomerSubCode.ToString());
			}

			// �J�i
			if (this.Kana.Trim() != "")
			{
				message.Append("\r\n" + "���Ӑ於(��) : " + this.Kana.ToString());
			}

            // 2009/12/02 Add >>>
            // ���Ӑ於
            if (this.Name.Trim() != "")
            {
                message.Append("\r\n" + "���Ӑ於 : " + this.Name.ToString());
            }
            // 2009/12/02 Add <<<

			// �d�b�ԍ��i���S���j
			if (this.SearchTelNo.Trim() != "")
			{
				message.Append("\r\n" + "�d�b�ԍ��i�����ԍ��j : " + this.SearchTelNo.ToString());
			}
			
			// ���Ӑ���
			StringBuilder customerKindName = new StringBuilder();
			if (this.AcceptWholeSale != 0)
			{
				if (customerKindName.ToString() != "") customerKindName.Append("�^");
				customerKindName.Append("�Ɣ̐�");
			}

			if (customerKindName.ToString() != "")
			{
				message.Append("\r\n" + "���Ӑ��� : " + customerKindName.ToString());
			}

			if ((this.CustAnalysCode1 != 0) || (this.CustAnalysCode2 != 0) || (this.CustAnalysCode3 != 0) || (this.CustAnalysCode4 != 0) || (this.CustAnalysCode5 != 0) || (this.CustAnalysCode6 != 0))
			{
				message.Append("\r\n" + "���̓R�[�h : " + this.CustAnalysCode1.ToString() + "-" + this.CustAnalysCode2.ToString() + "-" + this.CustAnalysCode3.ToString() + "-" + this.CustAnalysCode4.ToString() + "-" + this.CustAnalysCode5.ToString() + "-" + this.CustAnalysCode6.ToString());
			}

			if (this.CustomerAgentCd != "")
			{
				message.Append("\r\n" + "���Ӑ�S���� : " + this.CustomerAgentNm.ToString());
			}

			return message.ToString();
		}

	}
}
