using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �x���`�[�����A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �x���`�[�̌������s���܂��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2006.05.31</br>
	/// </remarks>
	public class SearchPaymentAcs
	{
		#region PrivateMember
		// �G���[���b�Z�[�W
		private string _errorMessage;
		#endregion

		#region Interface
		// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
		private IPaymentReadDB _iPaymentReadDB = null;
		#endregion

		#region Property
		/// <summary>�G���[���b�Z�[�W</summary>
		public string ErrorMessage
		{
			get { return _errorMessage; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SearchPaymentAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iPaymentReadDB= (IPaymentReadDB)MediationPaymentReadDB.GetPaymentReadDB();
			}
			catch (Exception)
			{				
				// �I�t���C������null���Z�b�g
				this._iPaymentReadDB = null;
			}
		}
		#endregion

		#region PublicMethod
        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �x���`�[��������
		/// </summary>
		/// <param name="searchParaPaymentRead">�x���`�[�����p�����[�^</param>
        /// <param name="searchPaymentSlpList">��������LIST</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �x���`�[�̌����������s���܂��B</br>
		/// <br>Programmer	: 30414 �E �K�j</br>
		/// <br>Date		: 2008/07/08</br>
		/// </remarks>
		public int Search(SearchParaPaymentRead searchParaPaymentRead, out ArrayList searchPaymentSlpList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			searchPaymentSlpList = new ArrayList();

			try
			{
				object paymentSlpWorkObj;
				// �x���f�[�^�Ǎ���
				status = this._iPaymentReadDB.Search(out paymentSlpWorkObj, (object)searchParaPaymentRead, 0, ConstantManagement.LogicalMode.GetData0);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        ArrayList wkList = paymentSlpWorkObj as ArrayList;
                        foreach (PaymentDataWork paymentDataWork in wkList)
                        {
                            searchPaymentSlpList.Add(CopyToSearchPaymentSlpFromPaymentDataWork(paymentDataWork));
                        }
						break;
					}
				}
			}
			catch (Exception ex)
			{
				//�I�t���C������null���Z�b�g
				this._iPaymentReadDB = null;
				status = -1;
				_errorMessage = "�x���`�[�̌��������ɂė�O���������܂����B\r\n" + ex.Message;
			}

			return status;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="paymentDataWork">�x���`�[���[�N�N���X</param>
        /// <returns>�x���`�[�N���X</returns>
        private SearchPaymentSlp CopyToSearchPaymentSlpFromPaymentDataWork(PaymentDataWork paymentDataWork)
        {
            SearchPaymentSlp searchPaymentSlp = new SearchPaymentSlp();

            searchPaymentSlp.CreateDateTime = paymentDataWork.CreateDateTime;              // �쐬���t
            searchPaymentSlp.UpdateDateTime = paymentDataWork.UpdateDateTime;              // �X�V���t
            searchPaymentSlp.EnterpriseCode = paymentDataWork.EnterpriseCode;              // ��ƃR�[�h
            searchPaymentSlp.FileHeaderGuid = paymentDataWork.FileHeaderGuid;              // GUID
            searchPaymentSlp.UpdEmployeeCode = paymentDataWork.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
            searchPaymentSlp.UpdAssemblyId1 = paymentDataWork.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
            searchPaymentSlp.UpdAssemblyId2 = paymentDataWork.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
            searchPaymentSlp.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;        // �_���폜�敪
            searchPaymentSlp.DebitNoteDiv = paymentDataWork.DebitNoteDiv;                  // �ԓ`�敪
            searchPaymentSlp.PaymentSlipNo = paymentDataWork.PaymentSlipNo;                // �x���`�[�ԍ�
            searchPaymentSlp.SupplierCd = paymentDataWork.SupplierCd;                      // �d����R�[�h
            searchPaymentSlp.SupplierNm1 = paymentDataWork.SupplierNm1;                    // �d���於1
            searchPaymentSlp.SupplierNm2 = paymentDataWork.SupplierNm2;                    // �d���於2
            searchPaymentSlp.SupplierSnm = paymentDataWork.SupplierSnm;                    // �d���旪��
            searchPaymentSlp.PayeeCode = paymentDataWork.PayeeCode;                        // �x����R�[�h
            searchPaymentSlp.PayeeName = paymentDataWork.PayeeName;                        // �x���於��
            searchPaymentSlp.PayeeName2 = paymentDataWork.PayeeName2;                      // �x���於��2
            searchPaymentSlp.PayeeSnm = paymentDataWork.PayeeSnm;                          // �x���旪��
            searchPaymentSlp.PaymentInpSectionCd = paymentDataWork.PaymentInpSectionCd;    // �x�����͋��_�R�[�h
            searchPaymentSlp.AddUpSecCode = paymentDataWork.AddUpSecCode;                  // �v�㋒�_�R�[�h
            searchPaymentSlp.UpdateSecCd = paymentDataWork.UpdateSecCd;                    // �X�V���_�R�[�h
            searchPaymentSlp.PaymentDate = paymentDataWork.PaymentDate;                    // �x�����t
            searchPaymentSlp.AddUpADate = paymentDataWork.AddUpADate;                      // �v����t
            searchPaymentSlp.PaymentTotal = paymentDataWork.PaymentTotal;                  // �x���v
            searchPaymentSlp.Payment = paymentDataWork.Payment;                            // �x�����z
            searchPaymentSlp.FeePayment = paymentDataWork.FeePayment;                      // �萔���x���z
            searchPaymentSlp.DiscountPayment = paymentDataWork.DiscountPayment;            // �l���x���z
            searchPaymentSlp.AutoPayment = paymentDataWork.AutoPayment;                    // �����x���敪
            searchPaymentSlp.DraftDrawingDate = paymentDataWork.DraftDrawingDate;          // ��`�U�o��
            searchPaymentSlp.DebitNoteLinkPayNo = paymentDataWork.DebitNoteLinkPayNo;      // �ԍ��x���A���ԍ�
            searchPaymentSlp.PaymentAgentCode = paymentDataWork.PaymentAgentCode;          // �x���S���҃R�[�h
            searchPaymentSlp.PaymentAgentName = paymentDataWork.PaymentAgentName;          // �x���S���Җ���
            searchPaymentSlp.PaymentInputAgentCd = paymentDataWork.PaymentInputAgentCd;
            searchPaymentSlp.PaymentInputAgentNm = paymentDataWork.PaymentInputAgentNm;
            searchPaymentSlp.Outline = paymentDataWork.Outline;                            // �`�[�E�v
            searchPaymentSlp.DraftKind = paymentDataWork.DraftKind;                        // ��`���
            searchPaymentSlp.DraftKindName = paymentDataWork.DraftKindName;                // ��`��ޖ���
            searchPaymentSlp.DraftDivide = paymentDataWork.DraftDivide;                    // ��`�敪
            searchPaymentSlp.DraftDivideName = paymentDataWork.DraftDivideName;            // ��`�敪����
            searchPaymentSlp.DraftNo = paymentDataWork.DraftNo;                            // ��`�ԍ�
            searchPaymentSlp.BankCode = paymentDataWork.BankCode;                          // ��s�R�[�h
            searchPaymentSlp.BankName = paymentDataWork.BankName;                          // ��s����
            searchPaymentSlp.PaymentRowNoDtl = new int[10];
            searchPaymentSlp.PaymentRowNoDtl[0] = paymentDataWork.PaymentRowNo1;
            searchPaymentSlp.PaymentRowNoDtl[1] = paymentDataWork.PaymentRowNo2;
            searchPaymentSlp.PaymentRowNoDtl[2] = paymentDataWork.PaymentRowNo3;
            searchPaymentSlp.PaymentRowNoDtl[3] = paymentDataWork.PaymentRowNo4;
            searchPaymentSlp.PaymentRowNoDtl[4] = paymentDataWork.PaymentRowNo5;
            searchPaymentSlp.PaymentRowNoDtl[5] = paymentDataWork.PaymentRowNo6;
            searchPaymentSlp.PaymentRowNoDtl[6] = paymentDataWork.PaymentRowNo7;
            searchPaymentSlp.PaymentRowNoDtl[7] = paymentDataWork.PaymentRowNo8;
            searchPaymentSlp.PaymentRowNoDtl[8] = paymentDataWork.PaymentRowNo9;
            searchPaymentSlp.PaymentRowNoDtl[9] = paymentDataWork.PaymentRowNo10;
            searchPaymentSlp.MoneyKindCodeDtl = new int[10];
            searchPaymentSlp.MoneyKindCodeDtl[0] = paymentDataWork.MoneyKindCode1;
            searchPaymentSlp.MoneyKindCodeDtl[1] = paymentDataWork.MoneyKindCode2;
            searchPaymentSlp.MoneyKindCodeDtl[2] = paymentDataWork.MoneyKindCode3;
            searchPaymentSlp.MoneyKindCodeDtl[3] = paymentDataWork.MoneyKindCode4;
            searchPaymentSlp.MoneyKindCodeDtl[4] = paymentDataWork.MoneyKindCode5;
            searchPaymentSlp.MoneyKindCodeDtl[5] = paymentDataWork.MoneyKindCode6;
            searchPaymentSlp.MoneyKindCodeDtl[6] = paymentDataWork.MoneyKindCode7;
            searchPaymentSlp.MoneyKindCodeDtl[7] = paymentDataWork.MoneyKindCode8;
            searchPaymentSlp.MoneyKindCodeDtl[8] = paymentDataWork.MoneyKindCode9;
            searchPaymentSlp.MoneyKindCodeDtl[9] = paymentDataWork.MoneyKindCode10;
            searchPaymentSlp.MoneyKindNameDtl = new string[10];
            searchPaymentSlp.MoneyKindNameDtl[0] = paymentDataWork.MoneyKindName1;
            searchPaymentSlp.MoneyKindNameDtl[1] = paymentDataWork.MoneyKindName2;
            searchPaymentSlp.MoneyKindNameDtl[2] = paymentDataWork.MoneyKindName3;
            searchPaymentSlp.MoneyKindNameDtl[3] = paymentDataWork.MoneyKindName4;
            searchPaymentSlp.MoneyKindNameDtl[4] = paymentDataWork.MoneyKindName5;
            searchPaymentSlp.MoneyKindNameDtl[5] = paymentDataWork.MoneyKindName6;
            searchPaymentSlp.MoneyKindNameDtl[6] = paymentDataWork.MoneyKindName7;
            searchPaymentSlp.MoneyKindNameDtl[7] = paymentDataWork.MoneyKindName8;
            searchPaymentSlp.MoneyKindNameDtl[8] = paymentDataWork.MoneyKindName9;
            searchPaymentSlp.MoneyKindNameDtl[9] = paymentDataWork.MoneyKindName10;
            searchPaymentSlp.MoneyKindDivDtl = new int[10];
            searchPaymentSlp.MoneyKindDivDtl[0] = paymentDataWork.MoneyKindDiv1;
            searchPaymentSlp.MoneyKindDivDtl[1] = paymentDataWork.MoneyKindDiv2;
            searchPaymentSlp.MoneyKindDivDtl[2] = paymentDataWork.MoneyKindDiv3;
            searchPaymentSlp.MoneyKindDivDtl[3] = paymentDataWork.MoneyKindDiv4;
            searchPaymentSlp.MoneyKindDivDtl[4] = paymentDataWork.MoneyKindDiv5;
            searchPaymentSlp.MoneyKindDivDtl[5] = paymentDataWork.MoneyKindDiv6;
            searchPaymentSlp.MoneyKindDivDtl[6] = paymentDataWork.MoneyKindDiv7;
            searchPaymentSlp.MoneyKindDivDtl[7] = paymentDataWork.MoneyKindDiv8;
            searchPaymentSlp.MoneyKindDivDtl[8] = paymentDataWork.MoneyKindDiv9;
            searchPaymentSlp.MoneyKindDivDtl[9] = paymentDataWork.MoneyKindDiv10;
            searchPaymentSlp.PaymentDtl = new long[10];
            searchPaymentSlp.PaymentDtl[0] = paymentDataWork.Payment1;
            searchPaymentSlp.PaymentDtl[1] = paymentDataWork.Payment2;
            searchPaymentSlp.PaymentDtl[2] = paymentDataWork.Payment3;
            searchPaymentSlp.PaymentDtl[3] = paymentDataWork.Payment4;
            searchPaymentSlp.PaymentDtl[4] = paymentDataWork.Payment5;
            searchPaymentSlp.PaymentDtl[5] = paymentDataWork.Payment6;
            searchPaymentSlp.PaymentDtl[6] = paymentDataWork.Payment7;
            searchPaymentSlp.PaymentDtl[7] = paymentDataWork.Payment8;
            searchPaymentSlp.PaymentDtl[8] = paymentDataWork.Payment9;
            searchPaymentSlp.PaymentDtl[9] = paymentDataWork.Payment10;
            searchPaymentSlp.ValidityTermDtl = new DateTime[10];
            searchPaymentSlp.ValidityTermDtl[0] = paymentDataWork.ValidityTerm1;
            searchPaymentSlp.ValidityTermDtl[1] = paymentDataWork.ValidityTerm2;
            searchPaymentSlp.ValidityTermDtl[2] = paymentDataWork.ValidityTerm3;
            searchPaymentSlp.ValidityTermDtl[3] = paymentDataWork.ValidityTerm4;
            searchPaymentSlp.ValidityTermDtl[4] = paymentDataWork.ValidityTerm5;
            searchPaymentSlp.ValidityTermDtl[5] = paymentDataWork.ValidityTerm6;
            searchPaymentSlp.ValidityTermDtl[6] = paymentDataWork.ValidityTerm7;
            searchPaymentSlp.ValidityTermDtl[7] = paymentDataWork.ValidityTerm8;
            searchPaymentSlp.ValidityTermDtl[8] = paymentDataWork.ValidityTerm9;
            searchPaymentSlp.ValidityTermDtl[9] = paymentDataWork.ValidityTerm10;
            searchPaymentSlp.InputDay = paymentDataWork.InputDay;

            return searchPaymentSlp;
        }

        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/08 Partsman�p�ɕύX
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �x���`�[��������
        /// </summary>
        /// <param name="searchParaPaymentRead">�x���`�[�����p�����[�^</param>
        /// <param name="searchPaymentSlpList">��������LIST</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�̌����������s���܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2006.05.31</br>
        /// </remarks>
        public int Search(SearchParaPaymentRead searchParaPaymentRead, out ArrayList searchPaymentSlpList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            searchPaymentSlpList = new ArrayList();

            try
            {
                object paymentSlpWorkObj;
                // �x���f�[�^�Ǎ���
                status = this._iPaymentReadDB.Search(out paymentSlpWorkObj, (object)searchParaPaymentRead, 0, ConstantManagement.LogicalMode.GetData0);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            searchPaymentSlpList = DBAndXMLDataMergeParts.CopyPropertyInList((ArrayList)paymentSlpWorkObj, typeof(SearchPaymentSlp));
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                //�I�t���C������null���Z�b�g
                this._iPaymentReadDB = null;
                status = -1;
                _errorMessage = "�x���`�[�̌��������ɂė�O���������܂����B\r\n" + ex.Message;
            }

            return status;
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman�p�ɕύX

        #endregion
    }
}
