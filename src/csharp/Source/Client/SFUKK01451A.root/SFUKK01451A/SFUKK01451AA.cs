using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���������A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����f�[�^�̌���������s���A�N�Z�X�N���X�ł��B</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.19</br>
	/// <br></br>
	/// <br>Update Note: 2007.01.29 18322 T.Kimura MA.NS�p�ɓ����E���������}�X�^�̃����o�R�s�[��ύX</br>
    /// <br>Update Note: 2007.10.05 20081 �D�c �E�l DC.NS�p�ɕύX</br>
    /// <br>Update Note: 2008/06/26 30414 �E �K�j Partsman�p�ɕύX</br>
    /// <br>Update Note: 2012/09/21 �c����</br>
    /// <br>�Ǘ��ԍ�   : 2012/10/17�z�M��</br>
    /// <br>             Redmine#32415 ���s�҂̒ǉ��Ή�</br>
    /// <br></br>
	/// </remarks>
	public class SearchDepsitAcs
	{
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private IDepositReadDB _iDepositReadDB = null;

		/// <summary>
		/// ���������A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���������A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		public SearchDepsitAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iDepositReadDB= (IDepositReadDB)MediationDepositReadDB.GetDepositReadDB();
			}
			catch (Exception)
			{				
				// �I�t���C������null���Z�b�g
				this._iDepositReadDB = null;
			}
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �����Ǎ�����
		/// </summary>
		/// <param name="searchParaDepositRead">��������</param>
		/// <param name="depsitMainList">�������</param>
		/// <param name="depositAlwList">�����������</param>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : ���������ɓ������E�����������̎擾���s���܂�</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		public int SearchDB(SearchParaDepositRead searchParaDepositRead, out ArrayList depsitMainList,  out ArrayList depositAlwList, out string errmsg)
		{

			object depsitMainWorListkObj = null;
			object depositAlwWorkListObj = null;

			depsitMainList = null;
			depositAlwList = null;
			errmsg = "";
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// �����f�[�^�Ǎ���
				status = this._iDepositReadDB.Search(out depsitMainWorListkObj, out depositAlwWorkListObj, searchParaDepositRead, 0, ConstantManagement.LogicalMode.GetData0);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					ArrayList depsitMainWorkList = (ArrayList)depsitMainWorListkObj;
					ArrayList depositAlwWorkList = (ArrayList)depositAlwWorkListObj;

					// �N���X�����o�[�R�s�[�����i�����}�X�^���[�N�N���X�˓����}�X�^�N���X�j
					depsitMainList = this.CopyToDepsitMainFromDepsitMainWork(depsitMainWorkList);

					// �N���X�����o�[�R�s�[�����i���������}�X�^���[�N�N���X�˓��������}�X�^�N���X�j
					depositAlwList = this.CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);
				}
			}
			catch (Exception ex)
			{
				//�I�t���C������null���Z�b�g
				this._iDepositReadDB = null;
				status = (int)ConstantManagement.DB_Status.ctDB_OFFLINE;

				errmsg = ex.Message;
			}

			return status;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �����Ǎ�����
        /// </summary>
        /// <param name="searchParaDepositRead">��������</param>
        /// <param name="depsitDataList">�������</param>
        /// <param name="depositAlwList">�����������</param>
        /// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : ���������ɓ������E�����������̎擾���s���܂�</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int SearchDB(SearchParaDepositRead searchParaDepositRead, out ArrayList depsitDataList, out ArrayList depositAlwList, out string errmsg)
        {
            
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            object objDepsitDataWork = null;
            object objDepsitAlwWork = null;
            object objSearchParaDepositRead = searchParaDepositRead;

            errmsg = "";
            depsitDataList = new ArrayList();
            depositAlwList = new ArrayList();

            try
            {
                // �����f�[�^�Ǎ���
                status = this._iDepositReadDB.Search(out objDepsitDataWork, out objDepsitAlwWork, objSearchParaDepositRead, 0, ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList depsitDataWorkList = (ArrayList)objDepsitDataWork;
                    ArrayList depsitAlwWorkList = (ArrayList)objDepsitAlwWork;

                    // �N���X�����o�[�R�s�[�����i�����}�X�^���[�N�N���X�˓����}�X�^�N���X�j
                    depsitDataList = this.CopyToDepsitMainFromDepsitDataWork(depsitDataWorkList);

                    // �N���X�����o�[�R�s�[�����i���������}�X�^���[�N�N���X�˓��������}�X�^�N���X�j
                    depositAlwList = this.CopyToDepositAlwFromDepositAlwWork(depsitAlwWorkList);
                }
            }
            catch (Exception ex)
            {
                //�I�t���C������null���Z�b�g
                this._iDepositReadDB = null;
                status = (int)ConstantManagement.DB_Status.ctDB_OFFLINE;

                errmsg = ex.Message;
            }

            return status;
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�����}�X�^���[�N�N���X�˓����}�X�^�N���X�j
		/// </summary>
		/// <param name="depsitMainWorkList">�����}�X�^���[�N�N���X</param>
		/// <returns>�����}�X�^�N���X</returns>
		/// <remarks>
		/// <br>Note       : �����}�X�^���[�N�N���X��������}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.19</br>
        /// <br>Update Note: 2007.01.29 18322 T.Kimura MA.NS�p�ɕύX</br>
	    /// <br></br>
		/// </remarks>
		private ArrayList CopyToDepsitMainFromDepsitMainWork(ArrayList depsitMainWorkList)
		{
			ArrayList depositAlwList = new ArrayList();

			foreach (DepsitMainWork depsitMainWork in depsitMainWorkList)
			{

				SearchDepsitMain depsitMain = new SearchDepsitMain();

                // �� 20070129 18322 c MA.NS�p�ɕύX
                #region SF �����}�X�^���[�N�N���X�˓����}�X�^�N���X�i�S�ăR�����g�A�E�g�j
                //depsitMain.CreateDateTime		= depsitMainWork.CreateDateTime;
				//depsitMain.UpdateDateTime		= depsitMainWork.UpdateDateTime;
				//depsitMain.EnterpriseCode		= depsitMainWork.EnterpriseCode;
				//depsitMain.FileHeaderGuid		= depsitMainWork.FileHeaderGuid;
				//depsitMain.UpdEmployeeCode		= depsitMainWork.UpdEmployeeCode;
				//depsitMain.UpdAssemblyId1		= depsitMainWork.UpdAssemblyId1;
				//depsitMain.UpdAssemblyId2		= depsitMainWork.UpdAssemblyId2;
				//depsitMain.LogicalDeleteCode	= depsitMainWork.LogicalDeleteCode;
				//depsitMain.DepositDebitNoteCd	= depsitMainWork.DepositDebitNoteCd;
				//depsitMain.DepositSlipNo		= depsitMainWork.DepositSlipNo;
				//depsitMain.DepositKindCode		= depsitMainWork.DepositKindCode;
				//depsitMain.CustomerCode			= depsitMainWork.CustomerCode;
				//depsitMain.DepositCd			= depsitMainWork.DepositCd;
				//depsitMain.DepositTotal			= depsitMainWork.DepositTotal;
				//depsitMain.Outline				= depsitMainWork.Outline;
				//depsitMain.AcceptAnOrderSalesNo	= depsitMainWork.AcceptAnOrderSalesNo;
				//depsitMain.InputDepositSecCd	= depsitMainWork.InputDepositSecCd;
				//depsitMain.DepositDate			= depsitMainWork.DepositDate;
				//depsitMain.AddUpSecCode			= depsitMainWork.AddUpSecCode;
				//depsitMain.AddUpADate			= depsitMainWork.AddUpADate;
				//depsitMain.UpdateSecCd			= depsitMainWork.UpdateSecCd;
				//depsitMain.DepositKindName		= depsitMainWork.DepositKindName;
				//depsitMain.DepositAllowance		= depsitMainWork.DepositAllowance;
				//depsitMain.DepositAlwcBlnce		= depsitMainWork.DepositAlwcBlnce;
				//depsitMain.DepositAgentCode		= depsitMainWork.DepositAgentCode;
				//depsitMain.DepositKindDivCd		= depsitMainWork.DepositKindDivCd;
				//depsitMain.FeeDeposit			= depsitMainWork.FeeDeposit;
				//depsitMain.DiscountDeposit		= depsitMainWork.DiscountDeposit;
				//depsitMain.CreditOrLoanCd		= depsitMainWork.CreditOrLoanCd;
				//depsitMain.CreditCompanyCode	= depsitMainWork.CreditCompanyCode;
				//depsitMain.Deposit				= depsitMainWork.Deposit;
				//depsitMain.DraftDrawingDate		= depsitMainWork.DraftDrawingDate;
				//depsitMain.DraftPayTimeLimit	= depsitMainWork.DraftPayTimeLimit;
				//depsitMain.DebitNoteLinkDepoNo	= depsitMainWork.DebitNoteLinkDepoNo;
				//depsitMain.LastReconcileAddUpDt	= depsitMainWork.LastReconcileAddUpDt;
				//depsitMain.AutoDepositCd		= depsitMainWork.AutoDepositCd;
				//depsitMain.AcpOdrDeposit		= depsitMainWork.AcpOdrDeposit;
				//depsitMain.AcpOdrChargeDeposit	= depsitMainWork.AcpOdrChargeDeposit;
				//depsitMain.AcpOdrDisDeposit		= depsitMainWork.AcpOdrDisDeposit;
				//depsitMain.VariousCostDeposit	= depsitMainWork.VariousCostDeposit;
				//depsitMain.VarCostChargeDeposit	= depsitMainWork.VarCostChargeDeposit;
				//depsitMain.VarCostDisDeposit	= depsitMainWork.VarCostDisDeposit;
				//depsitMain.AcpOdrDepositAlwc	= depsitMainWork.AcpOdrDepositAlwc;
				//depsitMain.AcpOdrDepoAlwcBlnce	= depsitMainWork.AcpOdrDepoAlwcBlnce;
				//depsitMain.VarCostDepoAlwc		= depsitMainWork.VarCostDepoAlwc;
				//depsitMain.VarCostDepoAlwcBlnce	= depsitMainWork.VarCostDepoAlwcBlnce;
                #endregion

                // MA.NS �����}�X�^���[�N�N���X�˓����}�X�^�N���X
                // �쐬����
                depsitMain.CreateDateTime       = depsitMainWork.CreateDateTime;
                // �X�V����                           
                depsitMain.UpdateDateTime       = depsitMainWork.UpdateDateTime;
                // ��ƃR�[�h                         
                depsitMain.EnterpriseCode       = depsitMainWork.EnterpriseCode;
                // GUID                               
                depsitMain.FileHeaderGuid       = depsitMainWork.FileHeaderGuid;
                // �X�V�]�ƈ��R�[�h                   
                depsitMain.UpdEmployeeCode      = depsitMainWork.UpdEmployeeCode;
                // �X�V�A�Z���u��ID1                  
                depsitMain.UpdAssemblyId1       = depsitMainWork.UpdAssemblyId1;
                // �X�V�A�Z���u��ID2                  
                depsitMain.UpdAssemblyId2       = depsitMainWork.UpdAssemblyId2;
                // �_���폜�敪                       
                depsitMain.LogicalDeleteCode    = depsitMainWork.LogicalDeleteCode;
                // �����ԍ��敪                       
                depsitMain.DepositDebitNoteCd   = depsitMainWork.DepositDebitNoteCd;
                // �����`�[�ԍ�                       
                depsitMain.DepositSlipNo        = depsitMainWork.DepositSlipNo;
                // �󒍔ԍ�                           
                // depsitMain.AcceptAnOrderNo      = depsitMainWork.AcceptAnOrderNo;   // 2007.10.05 hikita del
                // ����`�[�ԍ�
                depsitMain.SalesSlipNum         = depsitMainWork.SalesSlipNum;         // 2007.10.05 hikita add
                // �������͋��_�R�[�h                 
                depsitMain.InputDepositSecCd    = depsitMainWork.InputDepositSecCd;
                // �v�㋒�_�R�[�h                     
                depsitMain.AddUpSecCode         = depsitMainWork.AddUpSecCode;
                // �X�V���_�R�[�h                     
                depsitMain.UpdateSecCd          = depsitMainWork.UpdateSecCd;
                // �������t                           
                depsitMain.DepositDate          = depsitMainWork.DepositDate;
                // �v����t                           
                depsitMain.AddUpADate           = depsitMainWork.AddUpADate;
                // ��������R�[�h                     
                depsitMain.DepositKindCode      = depsitMainWork.DepositKindCode;
                // �������햼��                       
                depsitMain.DepositKindName      = depsitMainWork.DepositKindName;
                // ��������敪                       
                depsitMain.DepositKindDivCd     = depsitMainWork.DepositKindDivCd;
                // �����v                             
                depsitMain.DepositTotal         = depsitMainWork.DepositTotal;
                // �������z                           
                depsitMain.Deposit              = depsitMainWork.Deposit;
                // �萔�������z                       
                depsitMain.FeeDeposit           = depsitMainWork.FeeDeposit;
                // �l�������z                         
                depsitMain.DiscountDeposit      = depsitMainWork.DiscountDeposit;
                // ���x�[�g�����z                     
                // depsitMain.RebateDeposit        = depsitMainWork.RebateDeposit;      // 2007.10.05 hikita del
                // ���������敪                       
                depsitMain.AutoDepositCd        = depsitMainWork.AutoDepositCd;
                // �a����敪                         
                depsitMain.DepositCd            = depsitMainWork.DepositCd;
                // �N���W�b�g�^���[���敪             
                // depsitMain.CreditOrLoanCd       = depsitMainWork.CreditOrLoanCd;     // 2007.10.05 hikita del
                // �N���W�b�g��ЃR�[�h               
                // depsitMain.CreditCompanyCode    = depsitMainWork.CreditCompanyCode;  // 2007.10.05 hikita del
                // ��`�U�o��                         
                depsitMain.DraftDrawingDate     = depsitMainWork.DraftDrawingDate;
                // ��`�x������                       
                depsitMain.DraftPayTimeLimit    = depsitMainWork.DraftPayTimeLimit;
                // ���������z                         
                depsitMain.DepositAllowance     = depsitMainWork.DepositAllowance;
                // ���������c��                       
                depsitMain.DepositAlwcBlnce     = depsitMainWork.DepositAlwcBlnce;
                // �ԍ������A���ԍ�                   
                depsitMain.DebitNoteLinkDepoNo  = depsitMainWork.DebitNoteLinkDepoNo;
                // �ŏI�������݌v���                 
                depsitMain.LastReconcileAddUpDt = depsitMainWork.LastReconcileAddUpDt;
                // �����S���҃R�[�h                   
                depsitMain.DepositAgentCode     = depsitMainWork.DepositAgentCode;
                // �����S���Җ���                     
                depsitMain.DepositAgentNm       = depsitMainWork.DepositAgentNm;
                // ������R�[�h                       
                depsitMain.ClaimCode            = depsitMainWork.ClaimCode;
                // �����於��                         
                depsitMain.ClaimName            = depsitMainWork.ClaimName;
                // �����於��2                        
                depsitMain.ClaimName2           = depsitMainWork.ClaimName2;
                // �����旪��                        
                depsitMain.ClaimSnm             = depsitMainWork.ClaimSnm;
                // ���Ӑ�R�[�h                       
                depsitMain.CustomerCode         = depsitMainWork.CustomerCode;
                // ���Ӑ於��                         
                depsitMain.CustomerName         = depsitMainWork.CustomerName;
                // ���Ӑ於��2                        
                depsitMain.CustomerName2        = depsitMainWork.CustomerName2;
                // ���Ӑ旪��                        
                depsitMain.CustomerSnm          = depsitMainWork.CustomerSnm;
                
                // �`�[�E�v                           
                depsitMain.Outline              = depsitMainWork.Outline;
                // �� 20070129 18322 c

                // 2007.10.05 hikita add start --------------------------------------------->>
                // ��s�R�[�h
                depsitMain.BankCode             = depsitMainWork.BankCode;
                // ��s����
                depsitMain.BankName             = depsitMainWork.BankName;
                // ��`�ԍ�
                depsitMain.DraftNo              = depsitMainWork.DraftNo;
                // ��`���
                depsitMain.DraftKind            = depsitMainWork.DraftKind;
                // ��`��ޖ���
                depsitMain.DraftKindName        = depsitMainWork.DraftKindName;
                // ��`�敪
                depsitMain.DraftDivide          = depsitMainWork.DraftDivide;
                // ��`�敪����
                depsitMain.DraftDivideName      = depsitMainWork.DraftDivideName;
                // 2007.10.05 hikita add end -----------------------------------------------<<

                switch (depsitMain.DepositCd)
				{
					case 0:
						depsitMain.DepositNm = "�ʏ����";
						break;
					case 1:
						depsitMain.DepositNm = "�a���";
						break;
				}

				depositAlwList.Add(depsitMain);
			}

			return depositAlwList;
		}
        
        /// <summary>
		/// �N���X�����o�[�R�s�[�����i���������}�X�^���[�N�N���X�˓��������}�X�^�N���X�j
		/// </summary>
		/// <param name="depositAlwWorkList">���������}�X�^���[�N�N���X</param>
		/// <returns>���������}�X�^�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���������}�X�^���[�N�N���X������������}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.19</br>
        /// <br>Update Note: 2007.01.29 18322 T.Kimura MA.NS�p�ɕύX</br>
	    /// <br></br>
		/// </remarks>
		private ArrayList CopyToDepositAlwFromDepositAlwWork(ArrayList depositAlwWorkList)
		{
			ArrayList depositAlwList = new ArrayList();

			foreach (DepositAlwWork depositAlwWork in depositAlwWorkList)
			{
				SearchDepositAlw depositAlw = new SearchDepositAlw();

                // �� 20070129 18322 c MA.NS�p�ɕύX
                #region SF ���������}�X�^���[�N�N���X�˓��������}�X�^�N���X�i�S�ăR�����g�A�E�g�j
                //depositAlw.CreateDateTime		= depositAlwWork.CreateDateTime;
				//depositAlw.UpdateDateTime		= depositAlwWork.UpdateDateTime;
				//depositAlw.EnterpriseCode		= depositAlwWork.EnterpriseCode;
				//depositAlw.FileHeaderGuid		= depositAlwWork.FileHeaderGuid;
				//depositAlw.UpdEmployeeCode		= depositAlwWork.UpdEmployeeCode;
				//depositAlw.UpdAssemblyId1		= depositAlwWork.UpdAssemblyId1;
				//depositAlw.UpdAssemblyId2		= depositAlwWork.UpdAssemblyId2;
				//depositAlw.LogicalDeleteCode	= depositAlwWork.LogicalDeleteCode;
				//depositAlw.CustomerCode			= depositAlwWork.CustomerCode;
				//depositAlw.AddUpSecCode			= depositAlwWork.AddUpSecCode;
				//depositAlw.AcceptAnOrderNo		= depositAlwWork.AcceptAnOrderNo;
				//depositAlw.DepositSlipNo		= depositAlwWork.DepositSlipNo;
				//depositAlw.DepositKindCode		= depositAlwWork.DepositKindCode;
				//depositAlw.DepositInputDate		= depositAlwWork.DepositInputDate;
				//depositAlw.DepositAllowance		= depositAlwWork.DepositAllowance;
				//depositAlw.ReconcileDate		= depositAlwWork.ReconcileDate;
				//depositAlw.ReconcileAddUpDate	= depositAlwWork.ReconcileAddUpDate;
				//depositAlw.DebitNoteOffSetCd	= depositAlwWork.DebitNoteOffSetCd;
				//depositAlw.DepositCd			= depositAlwWork.DepositCd;
				//depositAlw.CreditOrLoanCd		= depositAlwWork.CreditOrLoanCd;
				//depositAlw.AcpOdrDepositAlwc	= depositAlwWork.AcpOdrDepositAlwc;
				//depositAlw.VarCostDepoAlwc		= depositAlwWork.VarCostDepoAlwc;
                #endregion

                // �쐬����
                depositAlw.CreateDateTime      = depositAlwWork.CreateDateTime;
                // �X�V����                          
                depositAlw.UpdateDateTime      = depositAlwWork.UpdateDateTime;
                // ��ƃR�[�h                        
                depositAlw.EnterpriseCode      = depositAlwWork.EnterpriseCode;
                // GUID                              
                depositAlw.FileHeaderGuid      = depositAlwWork.FileHeaderGuid;
                // �X�V�]�ƈ��R�[�h                  
                depositAlw.UpdEmployeeCode     = depositAlwWork.UpdEmployeeCode;
                // �X�V�A�Z���u��ID1                 
                depositAlw.UpdAssemblyId1      = depositAlwWork.UpdAssemblyId1;
                // �X�V�A�Z���u��ID2                 
                depositAlw.UpdAssemblyId2      = depositAlwWork.UpdAssemblyId2;
                // �_���폜�敪                      
                depositAlw.LogicalDeleteCode   = depositAlwWork.LogicalDeleteCode;
                // �������͋��_�R�[�h                
                depositAlw.InputDepositSecCd   = depositAlwWork.InputDepositSecCd;
                // �v�㋒�_�R�[�h                    
                depositAlw.AddUpSecCode        = depositAlwWork.AddUpSecCode;
                // �����ݓ�                          
                depositAlw.ReconcileDate       = depositAlwWork.ReconcileDate;
                // �����݌v���                      
                depositAlw.ReconcileAddUpDate  = depositAlwWork.ReconcileAddUpDate;
                // �����`�[�ԍ�                      
                depositAlw.DepositSlipNo       = depositAlwWork.DepositSlipNo;

                // ��������R�[�h                    
                depositAlw.DepositKindCode     = depositAlwWork.DepositKindCode;
                // �������햼��                      
                depositAlw.DepositKindName     = depositAlwWork.DepositKindName;

                // ���������z                        
                depositAlw.DepositAllowance    = depositAlwWork.DepositAllowance;
                // �����S���҃R�[�h                  
                depositAlw.DepositAgentCode    = depositAlwWork.DepositAgentCode;
                // �����S���Җ���                    
                depositAlw.DepositAgentNm      = depositAlwWork.DepositAgentNm;
                // ���Ӑ�R�[�h                      
                depositAlw.CustomerCode        = depositAlwWork.CustomerCode;
                // ���Ӑ於��                        
                depositAlw.CustomerName        = depositAlwWork.CustomerName;
                // ���Ӑ於��2                       
                depositAlw.CustomerName2       = depositAlwWork.CustomerName2;
                // �󒍔ԍ�                          
                //depositAlw.AcceptAnOrderNo     = depositAlwWork.AcceptAnOrderNo;  // 2007.10.05 hikita del
                // ����`�[�ԍ�
                depositAlw.SalesSlipNum        = depositAlwWork.SalesSlipNum;       // 2007.10.05 hikita add
                // �ԓ`���E�敪                      
                depositAlw.DebitNoteOffSetCd   = depositAlwWork.DebitNoteOffSetCd;

                // �a����敪                        
                depositAlw.DepositCd           = depositAlwWork.DepositCd;

                // �N���W�b�g�^���[���敪            
                // depositAlw.CreditOrLoanCd      = depositAlwWork.CreditOrLoanCd;  // 2007.10.05 hikita del
                // �� 20070129 18322 c

                depositAlwList.Add(depositAlw);
			}

			return depositAlwList;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�����}�X�^���[�N�˓����}�X�^�j
        /// </summary>
        /// <param name="depsitDataWorkList">�����}�X�^���[�N�N���X</param>
        /// <returns>�����}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^���[�N�N���X��������}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// <br>Update Note: 2012/09/21 �c����</br>
        /// <br>�Ǘ��ԍ�   : 2012/10/17�z�M��</br>
        /// <br>             Redmine#32415 ���s�҂̒ǉ��Ή�</br>
        /// </remarks>
        private ArrayList CopyToDepsitMainFromDepsitDataWork(ArrayList depsitDataWorkList)
        {
            ArrayList depositAlwList = new ArrayList();

            foreach (DepsitDataWork depsitDataWork in depsitDataWorkList)
            {
                SearchDepsitMain depsitMain = new SearchDepsitMain();

                depsitMain.CreateDateTime = depsitDataWork.CreateDateTime;                  // �쐬����
                depsitMain.UpdateDateTime = depsitDataWork.UpdateDateTime;                  // �X�V����
                depsitMain.EnterpriseCode = depsitDataWork.EnterpriseCode;                  // ��ƃR�[�h
                depsitMain.FileHeaderGuid = depsitDataWork.FileHeaderGuid;                  // GUID
                depsitMain.UpdEmployeeCode = depsitDataWork.UpdEmployeeCode;                // �X�V�]�ƈ��R�[�h
                depsitMain.UpdAssemblyId1 = depsitDataWork.UpdAssemblyId1;                  // �X�V�A�Z���u��ID1
                depsitMain.UpdAssemblyId2 = depsitDataWork.UpdAssemblyId2;                  // �X�V�A�Z���u��ID2
                depsitMain.LogicalDeleteCode = depsitDataWork.LogicalDeleteCode;            // �_���폜�敪
                depsitMain.DepositDebitNoteCd = depsitDataWork.DepositDebitNoteCd;          // �����ԍ��敪
                depsitMain.DepositSlipNo = depsitDataWork.DepositSlipNo;                    // �����`�[�ԍ�
                depsitMain.SalesSlipNum = depsitDataWork.SalesSlipNum;                      // ����`�[�ԍ�
                depsitMain.InputDepositSecCd = depsitDataWork.InputDepositSecCd;            // �������͋��_�R�[�h
                depsitMain.AddUpSecCode = depsitDataWork.AddUpSecCode;                      // �v�㋒�_�R�[�h
                depsitMain.UpdateSecCd = depsitDataWork.UpdateSecCd;                        // �X�V���_�R�[�h
                depsitMain.AcptAnOdrStatus = depsitDataWork.AcptAnOdrStatus;                // �󒍃X�e�[�^�X
                depsitMain.DepositDate = depsitDataWork.DepositDate;                        // �������t
                depsitMain.AddUpADate = depsitDataWork.AddUpADate;                          // �v����t
                depsitMain.Deposit = depsitDataWork.Deposit;                                // �������z
                depsitMain.FeeDeposit = depsitDataWork.FeeDeposit;                          // �萔�������z
                depsitMain.DiscountDeposit = depsitDataWork.DiscountDeposit;                // �l�������z
                depsitMain.DepositAllowance = depsitDataWork.DepositAllowance;              // ���������z
                depsitMain.DepositAlwcBlnce = depsitDataWork.DepositAlwcBlnce;              // ���������c��
                depsitMain.AutoDepositCd = depsitDataWork.AutoDepositCd;                    // ���������敪
                depsitMain.DraftDrawingDate = depsitDataWork.DraftDrawingDate;              // ��`�U�o��
                depsitMain.DebitNoteLinkDepoNo = depsitDataWork.DebitNoteLinkDepoNo;        // �ԍ������A���ԍ�
                depsitMain.LastReconcileAddUpDt = depsitDataWork.LastReconcileAddUpDt;      // �ŏI�������݌v���
                depsitMain.DepositAgentCode = depsitDataWork.DepositAgentCode;              // �����S���҃R�[�h
                depsitMain.DepositAgentNm = depsitDataWork.DepositAgentNm;                  // �����S���Җ���
                //----- ADD 2012/09/21 �c���� redmine#32415 ---------->>>>>
                depsitMain.DepositInputAgentCd = depsitDataWork.DepositInputAgentCd;        // �������͎҃R�[�h
                depsitMain.DepositInputAgentNm = depsitDataWork.DepositInputAgentNm;        // �������͎Җ�
                //----- ADD 2012/09/21 �c���� redmine#32415 ----------<<<<<
                depsitMain.ClaimCode = depsitDataWork.ClaimCode;                            // ������R�[�h
                depsitMain.ClaimName = depsitDataWork.ClaimName;                            // �����於��
                depsitMain.ClaimName2 = depsitDataWork.ClaimName2;                          // �����於��2
                depsitMain.ClaimSnm = depsitDataWork.ClaimSnm;                              // �����旪��
                depsitMain.CustomerCode = depsitDataWork.CustomerCode;                      // ���Ӑ�R�[�h
                depsitMain.CustomerName = depsitDataWork.CustomerName;                      // ���Ӑ於��
                depsitMain.CustomerName2 = depsitDataWork.CustomerName2;                    // ���Ӑ於��2
                depsitMain.CustomerSnm = depsitDataWork.CustomerSnm;                        // ���Ӑ旪��
                depsitMain.Outline = depsitDataWork.Outline;                                // �`�[�E�v
                depsitMain.BankCode = depsitDataWork.BankCode;                              // ��s�R�[�h
                depsitMain.BankName = depsitDataWork.BankName;                              // ��s����
                depsitMain.DraftNo = depsitDataWork.DraftNo;                                // ��`�ԍ�
                depsitMain.DraftKind = depsitDataWork.DraftKind;                            // ��`���
                depsitMain.DraftKindName = depsitDataWork.DraftKindName;                    // ��`��ޖ���
                depsitMain.DraftDivide = depsitDataWork.DraftDivide;                        // ��`�敪
                depsitMain.DraftDivideName = depsitDataWork.DraftDivideName;                // ��`�敪����
                depsitMain.DepositNm = "�ʏ����";                                          // �a������敪����
                // �����s�ԍ�1�`10
                depsitMain.DepositRowNo = new Int32[10];
                depsitMain.DepositRowNo[0] = depsitDataWork.DepositRowNo1;
                depsitMain.DepositRowNo[1] = depsitDataWork.DepositRowNo2;
                depsitMain.DepositRowNo[2] = depsitDataWork.DepositRowNo3;
                depsitMain.DepositRowNo[3] = depsitDataWork.DepositRowNo4;
                depsitMain.DepositRowNo[4] = depsitDataWork.DepositRowNo5;
                depsitMain.DepositRowNo[5] = depsitDataWork.DepositRowNo6;
                depsitMain.DepositRowNo[6] = depsitDataWork.DepositRowNo7;
                depsitMain.DepositRowNo[7] = depsitDataWork.DepositRowNo8;
                depsitMain.DepositRowNo[8] = depsitDataWork.DepositRowNo9;
                depsitMain.DepositRowNo[9] = depsitDataWork.DepositRowNo10;
                // ����R�[�h1�`10
                depsitMain.MoneyKindCode = new Int32[10];
                depsitMain.MoneyKindCode[0] = depsitDataWork.MoneyKindCode1;
                depsitMain.MoneyKindCode[1] = depsitDataWork.MoneyKindCode2;
                depsitMain.MoneyKindCode[2] = depsitDataWork.MoneyKindCode3;
                depsitMain.MoneyKindCode[3] = depsitDataWork.MoneyKindCode4;
                depsitMain.MoneyKindCode[4] = depsitDataWork.MoneyKindCode5;
                depsitMain.MoneyKindCode[5] = depsitDataWork.MoneyKindCode6;
                depsitMain.MoneyKindCode[6] = depsitDataWork.MoneyKindCode7;
                depsitMain.MoneyKindCode[7] = depsitDataWork.MoneyKindCode8;
                depsitMain.MoneyKindCode[8] = depsitDataWork.MoneyKindCode9;
                depsitMain.MoneyKindCode[9] = depsitDataWork.MoneyKindCode10;
                // ���햼��1�`10
                depsitMain.MoneyKindName = new String[10];
                depsitMain.MoneyKindName[0] = depsitDataWork.MoneyKindName1;
                depsitMain.MoneyKindName[1] = depsitDataWork.MoneyKindName2;
                depsitMain.MoneyKindName[2] = depsitDataWork.MoneyKindName3;
                depsitMain.MoneyKindName[3] = depsitDataWork.MoneyKindName4;
                depsitMain.MoneyKindName[4] = depsitDataWork.MoneyKindName5;
                depsitMain.MoneyKindName[5] = depsitDataWork.MoneyKindName6;
                depsitMain.MoneyKindName[6] = depsitDataWork.MoneyKindName7;
                depsitMain.MoneyKindName[7] = depsitDataWork.MoneyKindName8;
                depsitMain.MoneyKindName[8] = depsitDataWork.MoneyKindName9;
                depsitMain.MoneyKindName[9] = depsitDataWork.MoneyKindName10;
                // ����敪1�`10
                depsitMain.MoneyKindDiv = new Int32[10];
                depsitMain.MoneyKindDiv[0] = depsitDataWork.MoneyKindDiv1;
                depsitMain.MoneyKindDiv[1] = depsitDataWork.MoneyKindDiv2;
                depsitMain.MoneyKindDiv[2] = depsitDataWork.MoneyKindDiv3;
                depsitMain.MoneyKindDiv[3] = depsitDataWork.MoneyKindDiv4;
                depsitMain.MoneyKindDiv[4] = depsitDataWork.MoneyKindDiv5;
                depsitMain.MoneyKindDiv[5] = depsitDataWork.MoneyKindDiv6;
                depsitMain.MoneyKindDiv[6] = depsitDataWork.MoneyKindDiv7;
                depsitMain.MoneyKindDiv[7] = depsitDataWork.MoneyKindDiv8;
                depsitMain.MoneyKindDiv[8] = depsitDataWork.MoneyKindDiv9;
                depsitMain.MoneyKindDiv[9] = depsitDataWork.MoneyKindDiv10;
                // �������z1�`10
                depsitMain.DepositDtl = new Int64[10];
                depsitMain.DepositDtl[0] = depsitDataWork.Deposit1;
                depsitMain.DepositDtl[1] = depsitDataWork.Deposit2;
                depsitMain.DepositDtl[2] = depsitDataWork.Deposit3;
                depsitMain.DepositDtl[3] = depsitDataWork.Deposit4;
                depsitMain.DepositDtl[4] = depsitDataWork.Deposit5;
                depsitMain.DepositDtl[5] = depsitDataWork.Deposit6;
                depsitMain.DepositDtl[6] = depsitDataWork.Deposit7;
                depsitMain.DepositDtl[7] = depsitDataWork.Deposit8;
                depsitMain.DepositDtl[8] = depsitDataWork.Deposit9;
                depsitMain.DepositDtl[9] = depsitDataWork.Deposit10;
                // �L������1�`10
                depsitMain.ValidityTerm = new DateTime[10];
                depsitMain.ValidityTerm[0] = depsitDataWork.ValidityTerm1;
                depsitMain.ValidityTerm[1] = depsitDataWork.ValidityTerm2;
                depsitMain.ValidityTerm[2] = depsitDataWork.ValidityTerm3;
                depsitMain.ValidityTerm[3] = depsitDataWork.ValidityTerm4;
                depsitMain.ValidityTerm[4] = depsitDataWork.ValidityTerm5;
                depsitMain.ValidityTerm[5] = depsitDataWork.ValidityTerm6;
                depsitMain.ValidityTerm[6] = depsitDataWork.ValidityTerm7;
                depsitMain.ValidityTerm[7] = depsitDataWork.ValidityTerm8;
                depsitMain.ValidityTerm[8] = depsitDataWork.ValidityTerm9;
                depsitMain.ValidityTerm[9] = depsitDataWork.ValidityTerm10;

                depositAlwList.Add(depsitMain);
            }

            return depositAlwList;
        }

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���������}�X�^���[�N�˓��������}�X�^�j
		/// </summary>
		/// <param name="depositAlwWorkList">���������}�X�^���[�N�N���X</param>
		/// <returns>���������}�X�^�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���������}�X�^���[�N�N���X������������}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 30414 �E �K�j</br>
		/// <br>Date       : 2008/06/26</br>
	    /// <br></br>
		/// </remarks>
		private ArrayList CopyToDepositAlwFromDepositAlwWork(ArrayList depositAlwWorkList)
		{
			ArrayList depositAlwList = new ArrayList();

			foreach (DepositAlwWork depositAlwWork in depositAlwWorkList)
			{
				SearchDepositAlw depositAlw = new SearchDepositAlw();

                depositAlw.CreateDateTime = depositAlwWork.CreateDateTime;          // �쐬����
                depositAlw.UpdateDateTime = depositAlwWork.UpdateDateTime;          // �X�V����
                depositAlw.EnterpriseCode = depositAlwWork.EnterpriseCode;          // ��ƃR�[�h
                depositAlw.FileHeaderGuid = depositAlwWork.FileHeaderGuid;          // GUID
                depositAlw.UpdEmployeeCode = depositAlwWork.UpdEmployeeCode;        // �X�V�]�ƈ��R�[�h
                depositAlw.UpdAssemblyId1 = depositAlwWork.UpdAssemblyId1;          // �X�V�A�Z���u��ID1
                depositAlw.UpdAssemblyId2 = depositAlwWork.UpdAssemblyId2;          // �X�V�A�Z���u��ID2
                depositAlw.LogicalDeleteCode = depositAlwWork.LogicalDeleteCode;    // �_���폜�敪
                depositAlw.InputDepositSecCd = depositAlwWork.InputDepositSecCd;    // �������͋��_�R�[�h
                depositAlw.AddUpSecCode = depositAlwWork.AddUpSecCode;              // �v�㋒�_�R�[�h
                depositAlw.AcptAnOdrStatus = depositAlwWork.AcptAnOdrStatus;        // �󒍃X�e�[�^�X
                depositAlw.ReconcileDate = depositAlwWork.ReconcileDate;            // �����ݓ�
                depositAlw.ReconcileAddUpDate = depositAlwWork.ReconcileAddUpDate;  // �����݌v���
                depositAlw.DepositSlipNo = depositAlwWork.DepositSlipNo;            // �����`�[�ԍ�
                depositAlw.DepositAllowance = depositAlwWork.DepositAllowance;      // ���������z
                depositAlw.DepositAgentCode = depositAlwWork.DepositAgentCode;      // �����S���҃R�[�h
                depositAlw.DepositAgentNm = depositAlwWork.DepositAgentNm;          // �����S���Җ���
                depositAlw.CustomerCode = depositAlwWork.CustomerCode;              // ���Ӑ�R�[�h
                depositAlw.CustomerName = depositAlwWork.CustomerName;              // ���Ӑ於��
                depositAlw.CustomerName2 = depositAlwWork.CustomerName2;            // ���Ӑ於��2
                depositAlw.SalesSlipNum = depositAlwWork.SalesSlipNum;              // ����`�[�ԍ�
                depositAlw.DebitNoteOffSetCd = depositAlwWork.DebitNoteOffSetCd;    // �ԓ`���E�敪

                depositAlwList.Add(depositAlw);
			}

			return depositAlwList;
		}
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
	}
}
