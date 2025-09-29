//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ挟��
// �v���O�����T�v   �F���Ӑ�̌������s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F22018 ��� ���b
// �C����    2008/05/07     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/06/08     �C�����e�FSCM�I�v�V�������ڒǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/06/19     �C�����e�FSCM�I�v�V�������ڒǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10504551-00    �쐬�S���F30517 �Ė� �x��
// �C����    2009/12/02     �C�����e�FMANTIS:14720 ���Ӑ於�����ǉ�
//                                    MANTIS:14721 ���Ӑ挟�����ʂ̕\�����ڂɎ���FAX�ƋΖ���FAX��ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10601193-00    �쐬�S���F21024 ���X�� ��
// �C����    2010/04/06     �C�����e�F�I�����C����ʋ敪 �ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10601193-00    �쐬�S���F30434 �H�� �b�D
// �C����    2010/06/26     �C�����e�F�ȒP�⍇���A�J�E���g�O���[�vID �ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  PM1012A        �쐬�S���F�� ��
// �C����    2010/08/06     �C�����e�F�d�b�ԍ������ǉ��Ɣ����C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  PM1107C        �쐬�S���F���юR
// �C����    2011/07/22     �C�����e�F���Ӑ旪�̕\����ƌ����ǉ�(#826)
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  PM1107C        �쐬�S���F���C��
// �C����    2011/08/19     �C�����e�FPCC���Зp���Ӑ�K�C�h�ǉ� for #23705
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F22024 ���� �_�u
// �C����    2012.04.10     �C�����e�F�ڋq�S���]�ƈ����� �ǉ��ɔ����Ή�
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���Ӑ�ԗ������e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ�ԗ������e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 22018 ��ؐ��b</br>
	/// <br>Date       : 2007.02.13</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/12/02 30517 �Ė� �x��</br>
    /// <br>             MANTIS:14720 ���Ӑ於�����ǉ�</br>
    /// <br>             MANTIS:14721 ���Ӑ挟�����ʂ̕\�����ڂɎ���FAX�ƋΖ���FAX��ǉ�</br>
    /// <br>------------------------------------------------------------------------------------</br>
	/// <br>------------------------------------------------------------------------------------</br>
	/// <br>Update Note: 2012.04.10 22024 ���� �_�u</br>
	/// <br>             �ڋq�S���]�ƈ����� �ǉ��ɔ����Ή�</br>
	/// <br>------------------------------------------------------------------------------------</br>
	/// </remarks>
	public class CustomerSearchAcs
	{
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private ICustomerSearchDB _iCustomerSearchDB = null;

		/// <summary>
		/// ���Ӑ�ԗ������e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ�ԗ������e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2007.02.13</br>
		/// <br></br>
		/// </remarks>
		public CustomerSearchAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iCustomerSearchDB = (ICustomerSearchDB)MediationCustomerSearchDB.GetCustomerSearchDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._iCustomerSearchDB = null;
			}
		}

		/// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
		public enum OnlineMode 
		{
			/// <summary>�I�t���C��</summary>
			Offline,
			/// <summary>�I�����C��</summary>
			Online 
		}

		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : 980079 ��ؐ��b</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iCustomerSearchDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// �ڋq�S������
		/// </summary>
        /// <param name="retArray"></param>
        /// <param name="paraRec"></param>
		/// <returns></returns>
		public int Serch(out CustomerSearchRet[] retArray, CustomerSearchPara paraRec)
		{
			CustomerSearchParaWork customerSearchParaWork = new CustomerSearchParaWork();
			customerSearchParaWork = CopyToParamDataFromUIData(paraRec);

			customerSearchParaWork.EnterpriseCode = paraRec.EnterpriseCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/20 ADD
            if ( customerSearchParaWork.AcceptWholeSale == 0 )
            {
                customerSearchParaWork.AcceptWholeSale = -1;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/20 ADD
			
			object paraObj = customerSearchParaWork;
			object retObj;
			ArrayList retList = new ArrayList();
			ArrayList customerSearchRetList = new ArrayList();

            // --- DEL 2008/09/04 -------------------------------->>>>>
			// ���Ӑ挟��
            //int status = this._iCustomerSearchDB.Search( out retObj, ref paraObj, CustomerSearchReadMode.CustomerSearchMode_All, ConstantManagement.LogicalMode.GetData0 );
            // --- DEL 2008/09/04 --------------------------------<<<<<
            // --- ADD 2008/09/04 -------------------------------->>>>>
            // ���Ӑ挟�� (�_���폜�s���擾)
            int status = this._iCustomerSearchDB.Search(out retObj, ref paraObj, CustomerSearchReadMode.CustomerSearchMode_All, ConstantManagement.LogicalMode.GetData01);
            // --- ADD 2008/09/04 --------------------------------<<<<<

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				retList = retObj as ArrayList;

				if (retList == null)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;
				}
				else
				{
                    //-----DEL PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
                    //foreach (CustomerSearchRetWork retWork in retList)
                    //{
                    //    customerSearchRetList.Add(this.CopyToUIDataFromParamData(retWork));
                    //}
                    //-----DEL PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
                    //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
                    Hashtable pccCmpnyStHt = null;
                    //2:PCC�}�X�����p PCC���Аݒ�}�X�^�ɊY������
                    if (customerSearchParaWork.PccuoeMode == 2)
                    {
                        //PCC���Аݒ�}�X�^�ɊY������
                        List<PccCmpnySt> pccCmpnyStList = null;
                        PccCmpnySt parsePccCmpnySt = new PccCmpnySt();
                        parsePccCmpnySt.InqOtherEpCd = customerSearchParaWork.EnterpriseCode;
                        parsePccCmpnySt.InqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;
                        PccCmpnyStAcs pccCmpnyStAcs = new PccCmpnyStAcs();
                        //PCC���Аݒ�}�X�^�����e��������
                        status = pccCmpnyStAcs.Search(out pccCmpnyStList, parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData0);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            pccCmpnyStHt = new Hashtable();
                            foreach (PccCmpnySt pccCmpnyStRe in pccCmpnyStList)
                            {
                                if (!pccCmpnyStHt.ContainsKey(pccCmpnyStRe.PccCompanyCode))
                                {
                                    pccCmpnyStHt.Add(pccCmpnyStRe.PccCompanyCode, pccCmpnyStRe);
                                }
                            }
                        }
                        foreach (CustomerSearchRetWork retWork in retList)
                        {
                            if (pccCmpnyStHt == null || pccCmpnyStHt.Count == 0)
                            {
                                break;
                            }
                            else if (!pccCmpnyStHt.ContainsKey(retWork.CustomerCode))
                            {
                                continue;
                            }
                            customerSearchRetList.Add(this.CopyToUIDataFromParamData(retWork));
                        }
                    }
                    else
                    {
                        foreach (CustomerSearchRetWork retWork in retList)
                        {
                            customerSearchRetList.Add(this.CopyToUIDataFromParamData(retWork));
                        }
                    }
                    //----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
				}
			}

			retArray = (CustomerSearchRet[])customerSearchRetList.ToArray(typeof(CustomerSearchRet));

			return status;
		}
		
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���Ӑ�ԗ��������[�N�N���X�˓��Ӑ�ԗ��������ʃN���X�j
		/// </summary>
		/// <param name="customerSearchWork">���Ӑ�ԗ��������[�N�N���X</param>
		/// <returns>���Ӑ�ԗ��������ʃN���X</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�ԗ��������[�N�N���X���瓾�Ӑ�ԗ������N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 980079 ��ؐ��b</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private CustomerSearchRet CopyToUIDataFromParamData(CustomerSearchRetWork customerSearchWork)
		{
			CustomerSearchRet customerSearchRet = new CustomerSearchRet();

			// ���Ӑ���
			customerSearchRet.EnterpriseCode	= customerSearchWork.EnterpriseCode;
			customerSearchRet.CustomerCode		= customerSearchWork.CustomerCode;
			customerSearchRet.CustomerSubCode	= customerSearchWork.CustomerSubCode;
			customerSearchRet.Name				= customerSearchWork.Name;
			customerSearchRet.Name2				= customerSearchWork.Name2;
			customerSearchRet.HonorificTitle	= customerSearchWork.HonorificTitle;
			customerSearchRet.Kana				= customerSearchWork.Kana;
            customerSearchRet.Snm               = customerSearchWork.CustomerSnm;
			customerSearchRet.SearchTelNo		= customerSearchWork.SearchTelNo;
			customerSearchRet.HomeTelNo			= customerSearchWork.HomeTelNo;
			customerSearchRet.OfficeTelNo		= customerSearchWork.OfficeTelNo;
			customerSearchRet.PortableTelNo		= customerSearchWork.PortableTelNo;
	
			customerSearchRet.PostNo = customerSearchWork.PostNo;
			customerSearchRet.Address1 = customerSearchWork.Address1;
			customerSearchRet.Address3 = customerSearchWork.Address3;
			customerSearchRet.Address4 = customerSearchWork.Address4;
			customerSearchRet.TotalDay = customerSearchWork.TotalDay;
			customerSearchRet.LogicalDeleteCode = customerSearchWork.LogicalDeleteCode;
			customerSearchRet.AcceptWholeSale = customerSearchWork.AcceptWholeSale;
            customerSearchRet.MngSectionCode = customerSearchWork.MngSectionCode;

            // --- ADD 2008/09/04 -------------------------------->>>>>
            customerSearchRet.UpdateDate = customerSearchWork.UpdateDateTime;
            // --- ADD 2008/09/04 --------------------------------<<<<<
            // ADD 2009/06/08 ------>>>
            customerSearchRet.CustomerEpCode = customerSearchWork.CustomerEpCode;
            customerSearchRet.CustomerSecCode = customerSearchWork.CustomerSecCode;
            // ADD 2009/06/08 ------<<<
            // --- ADD 2009/06/19 -------------------------------->>>>>
            customerSearchRet.CustomerAgentCd = customerSearchWork.CustomerAgentCd;
            // --- ADD 2009/06/19 --------------------------------<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
			customerSearchRet.CustomerAgentNm = customerSearchWork.CustomerAgentNm;
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
            // --- ADD 2009/02/12 -------------------------------->>>>>
            customerSearchRet.CustomerSlipNoDiv = customerSearchWork.CustomerSlipNoDiv;
            // --- ADD 2009/02/12 --------------------------------<<<<<

            // 2009/12/02 Add >>>
            customerSearchRet.HomeFaxNo = customerSearchWork.HomeFaxNo;
            customerSearchRet.OfficeFaxNo = customerSearchWork.OfficeFaxNo;
            // 2009/12/02 Add <<<

            customerSearchRet.OnlineKindDiv = customerSearchWork.OnlineKindDiv; // 2010/04/06 Add

            // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή� ---------->>>>>
            customerSearchRet.SimplInqAcntAcntGrId = customerSearchWork.SimplInqAcntAcntGrId;
            // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή� ----------<<<<<

			return customerSearchRet;
		}


		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���Ӑ�ԗ����������N���X�˓��Ӑ�ԗ��������[�N�N���X�j
		/// </summary>
        /// <param name="customerSearchPara">���Ӑ�ԗ����������N���X</param>
		/// <returns>���Ӑ�ԗ��������[�N�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�ԗ����������N���X���瓾�Ӑ�ԗ��������[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 95089 ���i ��</br>
		/// <br>Date       : 2005.03.28</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 �� ��</br>
        /// <br>             PM1012A:�d�b�ԍ������ǉ��Ɣ����C��</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		private CustomerSearchParaWork CopyToParamDataFromUIData(CustomerSearchPara customerSearchPara)
		{
			CustomerSearchParaWork customerSearchParaWork = new CustomerSearchParaWork();

			customerSearchParaWork.EnterpriseCode = customerSearchPara.EnterpriseCode;
			customerSearchParaWork.CustomerCode = customerSearchPara.CustomerCode;
			customerSearchParaWork.CustomerSubCode = customerSearchPara.CustomerSubCode;
			customerSearchParaWork.Kana = customerSearchPara.Kana;
			customerSearchParaWork.SearchTelNo = customerSearchPara.SearchTelNo;
			customerSearchParaWork.CustomerSubCodeSearchType = customerSearchPara.CustomerSubCodeSearchType;
			customerSearchParaWork.KanaSearchType = customerSearchPara.KanaSearchType;
			customerSearchParaWork.CustAnalysCode1 = customerSearchPara.CustAnalysCode1;
			customerSearchParaWork.CustAnalysCode2 = customerSearchPara.CustAnalysCode2;
			customerSearchParaWork.CustAnalysCode3 = customerSearchPara.CustAnalysCode3;
			customerSearchParaWork.CustAnalysCode4 = customerSearchPara.CustAnalysCode4;
			customerSearchParaWork.CustAnalysCode5 = customerSearchPara.CustAnalysCode5;
			customerSearchParaWork.CustAnalysCode6 = customerSearchPara.CustAnalysCode6;
			customerSearchParaWork.CustomerAgentCd = customerSearchPara.CustomerAgentCd;
			customerSearchParaWork.BillCollecterCd = customerSearchPara.BillCollecterCd;
			customerSearchParaWork.AcceptWholeSale = customerSearchPara.AcceptWholeSale;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            customerSearchParaWork.MngSectionCode = customerSearchPara.MngSectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009/12/02 Add >>>
            customerSearchParaWork.Name = customerSearchPara.Name;
            customerSearchParaWork.NameSearchType = customerSearchPara.NameSearchType;
            // 2009/12/02 Add <<<

            // ---ADD 2010/08/06-------------------->>>
            customerSearchParaWork.TelNum = customerSearchPara.TelNum;
            customerSearchParaWork.TelNumSearchType = customerSearchPara.TelNumSearchType;
            // ---ADD 2010/08/06--------------------<<<
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
            customerSearchParaWork.PccuoeMode = customerSearchPara.PccuoeMode;
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
            // 2011/7/22 XUJS ADD STA>>>>>>
            customerSearchParaWork.CustomerSnm = customerSearchPara.CustomerSnm;
            customerSearchParaWork.CustomerSnmSearchType = customerSearchPara.CustomerSnmSearchType;
            // 2011/7/22 XUJS ADD END<<<<<<

			return customerSearchParaWork;
		}
	}
}
