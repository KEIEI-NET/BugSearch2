//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���|�c���ꗗ�\(����)�A�N�Z�X�N���X
// �v���O�����T�v   : ���|�c���ꗗ�\(����)�Ŏg�p����f�[�^���擾����
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�y�~ �їR��
// �� �� ��  2012/09/14  �C�����e : �V�K�쐬 �d�������@�\�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570208-00 �쐬�S�� : 3H ������
// �C �� ��  2020/04/10  �C�����e : �y���ŗ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870141-00 �쐬�S�� : 3H ����
// �C �� ��  2022/10/20  �C�����e : �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// ���|�c���ꗗ�\(����)�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���|�c���ꗗ�\(����)�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer : FSI�y�~ �їR��</br>
    /// <br>Date       : 2012/09/14</br>
    /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date	   : 2020/04/10</br>
    /// <br>UpdateNote : 11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
    /// <br>Programmer : 3H ����</br>
    /// <br>Date       : 2022/10/20</br>
    /// </remarks>
	public class SumAccPaymentListAcs
	{
		#region �� Constructor
		/// <summary>
        /// ���|�c���ꗗ�\(����)�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���|�c���ꗗ�\(����)�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
		public SumAccPaymentListAcs()
		{
            this._iSumAccPaymentListWorkDB = (ISumAccPaymentListWorkDB)MediationSumAccPaymentListWorkDB.GetSumAccPaymentListWorkDB();
		}

		/// <summary>
		/// ���|�c���ꗗ�\(����)�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���|�c���ꗗ�\(����)�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
		static SumAccPaymentListAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// ���[�o�͐ݒ�f�[�^�N���X
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X
			
			// ���O�C�����_�擾
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }
		}
		#endregion �� Constructor

		#region �� Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X
		#endregion �� Static Member

		#region �� Private Member
        private ISumAccPaymentListWorkDB _iSumAccPaymentListWorkDB;

		private DataSet _AccPaymentListDs;				    // �d���攃�|�f�[�^�Z�b�g

        private Dictionary<string, bool> _monAddUpNonProcDic;

		#endregion �� Private Member

		#region �� Public Property
		/// <summary>
        /// �d���攃�|���z�f�[�^�Z�b�g(�ǂݎ���p)
		/// </summary>
		public DataSet CustAccRecDs
		{
			get{ return this._AccPaymentListDs; }
		}
		#endregion �� Public Property

		#region �� Public Method
		#region �� �o�̓f�[�^�擾
        #region �� �d���攃�|���z�f�[�^�擾
        /// <summary>
        /// �d���攃�|���z�f�[�^�擾
		/// </summary>
        /// <param name="sumAccPaymentListCndtn">���o����</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : �������d���攃�|���z�f�[�^���擾����B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
        public int SearchCustAccRecMain(SumAccPaymentListCndtn sumAccPaymentListCndtn, out string errMsg)
		{
            return this.SearchProc(sumAccPaymentListCndtn, out errMsg);
		}
		#endregion
		#endregion �� �o�̓f�[�^�擾
		#endregion �� Public Method

		#region �� Private Method
		#region �� ���[�f�[�^�擾
        #region �� �d���攃�|���z�f�[�^�擾
        /// <summary>
        /// �d���攃�|���z�f�[�^�擾
		/// </summary>
        /// <param name="sumAccPaymentListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
        private int SearchProc(SumAccPaymentListCndtn sumAccPaymentListCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                PMKAK02025EA.CreateDataTable(ref this._AccPaymentListDs);
                
                SumAccPaymentListCndtnWork sumAccPaymentListCndtnWork = new SumAccPaymentListCndtnWork();
				// ���o�����W�J  --------------------------------------------------------------
                status = this.DevSumAccPaymentListCndtn(sumAccPaymentListCndtn, out sumAccPaymentListCndtnWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// �f�[�^�擾  ----------------------------------------------------------------
                object retCustAccRecMainList = null;

                status = this._iSumAccPaymentListWorkDB.Search( out retCustAccRecMainList, sumAccPaymentListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0 );
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        _monAddUpNonProcDic = new Dictionary<string, bool>();
                        
                        // �f�[�^�W�J����
                        DevListData(sumAccPaymentListCndtn, this._AccPaymentListDs.Tables[PMKAK02025EA.ct_Tbl_AccPaymentList], (ArrayList)retCustAccRecMainList);
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        if (this._AccPaymentListDs.Tables[PMKAK02025EA.ct_Tbl_AccPaymentList].Rows.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
                        errMsg = "�d���攃�|���z�f�[�^�̎擾�Ɏ��s���܂����B";
						break;
				}
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

		#endregion �� ���[�f�[�^�擾

		#region �� �f�[�^�W�J����
		#region �� ���o�����W�J����
		/// <summary>
		/// ���o�����W�J����
		/// </summary>
		/// <param name="sumAccPaymentListCndtn">UI���o�����N���X</param>
		/// <param name="sumAccPaymentListCndtnWork">�����[�g���o�����N���X</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date	   : 2020/04/10</br>
        /// </remarks>
        private int DevSumAccPaymentListCndtn(SumAccPaymentListCndtn sumAccPaymentListCndtn, out SumAccPaymentListCndtnWork sumAccPaymentListCndtnWork, out string errMsg)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            sumAccPaymentListCndtnWork = new SumAccPaymentListCndtnWork();

			try
			{
                // ���o�����v���p�e�B�̕ύX
                sumAccPaymentListCndtnWork.EnterpriseCode = sumAccPaymentListCndtn.EnterpriseCode;

				// ��ƃR�[�h
				// ���o�����p�����[�^�Z�b�g
                if (sumAccPaymentListCndtn.SectionCodes.Length != 0)
				{
					if ( sumAccPaymentListCndtn.IsSelectAllSection )
					{
						// �S�Ђ̎�
                        sumAccPaymentListCndtnWork.SectionCodes = null;
					}
					else
					{
                        sumAccPaymentListCndtnWork.SectionCodes = sumAccPaymentListCndtn.SectionCodes;
					}
				}
				else
				{
                    sumAccPaymentListCndtnWork.SectionCodes = null;
				}
                                          
                sumAccPaymentListCndtnWork.EnterpriseCode = sumAccPaymentListCndtn.EnterpriseCode; // ��ƃR�[�h
                sumAccPaymentListCndtnWork.SectionCodes = sumAccPaymentListCndtn.SectionCodes; // ���_�R�[�h�i�����w��j
                sumAccPaymentListCndtnWork.AddUpYearMonth = sumAccPaymentListCndtn.AddUpYearMonth; // �v��N��
                sumAccPaymentListCndtnWork.St_PayeeCode = sumAccPaymentListCndtn.St_PayeeCode; // �J�n������R�[�h
                if (sumAccPaymentListCndtn.Ed_PayeeCode == 0)
                {
                    // �����͂̏ꍇ�́A�ő�l���Z�b�g
                    sumAccPaymentListCndtnWork.Ed_PayeeCode = 999999;                           // �I��������R�[�h
                }
                else
                {
                    sumAccPaymentListCndtnWork.Ed_PayeeCode = sumAccPaymentListCndtn.Ed_PayeeCode; // �I��������R�[�h
                }

                sumAccPaymentListCndtnWork.AddUpDate = sumAccPaymentListCndtn.AddUpDate;  // �v��N����
                sumAccPaymentListCndtnWork.PayDtlDiv = sumAccPaymentListCndtn.PayDtlDiv;  // �x������敪

                // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
                // �ŕʓ���󎚋敪
                sumAccPaymentListCndtnWork.TaxPrintDiv = sumAccPaymentListCndtn.TaxPrintDiv;
                // �ŗ�1
                sumAccPaymentListCndtnWork.TaxRate1 = sumAccPaymentListCndtn.TaxRate1;
                // �ŗ�2
                sumAccPaymentListCndtnWork.TaxRate2 = sumAccPaymentListCndtn.TaxRate2;
                // --- ADD END 3H ������ 2020/04/10 ----------<<<<<
            }
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

		#region �� �d���攃�|�f�[�^�W�J����
		/// <summary>
        /// �d���攃�|�f�[�^�W�J����
		/// </summary>
		/// <param name="sumAccPaymentListCndtn">UI���o�����N���X</param>
		/// <param name="accPaymentTable">�W�J�Ώ�DataTable</param>
        /// <param name="sumAccPaymentListResultWorkList">�擾�f�[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : �d���攃�|�f�[�^��W�J����B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date	   : 2020/04/10</br>
        /// <br>UpdateNote : 11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2022/10/20</br>
		/// </remarks>
        private void DevListData(SumAccPaymentListCndtn sumAccPaymentListCndtn, DataTable accPaymentTable, ArrayList sumAccPaymentListResultWorkList)
		{
			DataRow dr;
            foreach ( SumAccPaymentListResultWork sumAccPaymentListResultWork in sumAccPaymentListResultWorkList )
			{
                // �o�͋��z�敪�`�F�b�N
                if (!CheckOutputMoneyDiv(sumAccPaymentListCndtn, sumAccPaymentListResultWork))
                {
                    // ����Ώۃf�[�^�ł͖���
                    continue;
                }

                dr = accPaymentTable.NewRow();

                // ���o���ʃv���p�e�B
                dr[PMKAK02025EA.ct_Col_SumAddUpSecCode] = sumAccPaymentListResultWork.SumAddUpSecCode; // �����v�㋒�_�R�[�h
                dr[PMKAK02025EA.ct_Col_SumSectionGuideNm] = sumAccPaymentListResultWork.SumSectionGuideSnm; // �����v�㋒�_����
                dr[PMKAK02025EA.ct_Col_AddUpSecCode] = sumAccPaymentListResultWork.AddUpSecCode; // �v�㋒�_�R�[�h
                dr[PMKAK02025EA.ct_Col_SectionGuideNm] = sumAccPaymentListResultWork.SectionGuideSnm; // �v�㋒�_����

                dr[PMKAK02025EA.ct_Col_SumPayeeCode] = sumAccPaymentListResultWork.SumPayeeCode; // �����x����R�[�h
                dr[PMKAK02025EA.ct_Col_SumPayeeSnm] = sumAccPaymentListResultWork.SumPayeeSnm; // �����x���旪��
                dr[PMKAK02025EA.ct_Col_PayeeCode] = sumAccPaymentListResultWork.PayeeCode; // �x����R�[�h
                dr[PMKAK02025EA.ct_Col_PayeeSnm] = sumAccPaymentListResultWork.PayeeSnm; // �x���旪��
                dr[PMKAK02025EA.ct_Col_LastTimeAccPay] = sumAccPaymentListResultWork.LastTimeAccPay; // �O�񔃊|���z
                dr[PMKAK02025EA.ct_Col_ThisTimePayNrml] = sumAccPaymentListResultWork.ThisTimePayNrml; // ����x�����z�i�ʏ�x���j
                dr[PMKAK02025EA.ct_Col_ThisTimeFeePayNrml] = sumAccPaymentListResultWork.ThisTimeFeePayNrml; // ����萔���z�i�ʏ�x���j
                dr[PMKAK02025EA.ct_Col_ThisTimeDisPayNrml] = sumAccPaymentListResultWork.ThisTimeDisPayNrml; // ����l���z�i�ʏ�x���j
                dr[PMKAK02025EA.ct_Col_ThisTimeTtlBlcAcPay] = sumAccPaymentListResultWork.ThisTimeTtlBlcAcPay; // ����J�z�c���i���|�v�j
                dr[PMKAK02025EA.ct_Col_OfsThisTimeStock] = sumAccPaymentListResultWork.OfsThisTimeStock; // ���E�㍡��d�����z

                long thisRgdsDisPric = sumAccPaymentListResultWork.ThisRgdsDisPric;
                dr[PMKAK02025EA.ct_Col_ThisRgdsDisPric] = -thisRgdsDisPric; // �ԕi�l��

                dr[PMKAK02025EA.ct_Col_OfsThisStockTax] = sumAccPaymentListResultWork.OfsThisStockTax; // ���E�㍡��d�������
                dr[PMKAK02025EA.ct_Col_ThisTimeStockPrice] = sumAccPaymentListResultWork.ThisTimeStockPrice; // ����d�����z

                dr[PMKAK02025EA.ct_Col_StckTtlAccPayBalance] = sumAccPaymentListResultWork.StckTtlAccPayBalance; // �d�����v�c���i���|�v�j
                dr[PMKAK02025EA.ct_Col_StockSlipCount] = sumAccPaymentListResultWork.StockSlipCount; // �d���`�[����

                dr[PMKAK02025EA.ct_Col_CashPayment] = sumAccPaymentListResultWork.CashPayment; // ����
                dr[PMKAK02025EA.ct_Col_TrfrPayment] = sumAccPaymentListResultWork.TrfrPayment; // �U��
                dr[PMKAK02025EA.ct_Col_CheckPayment] = sumAccPaymentListResultWork.CheckPayment; // ���؎�
                dr[PMKAK02025EA.ct_Col_DraftPayment] = sumAccPaymentListResultWork.DraftPayment; // ��`
                dr[PMKAK02025EA.ct_Col_OffsetPayment] = sumAccPaymentListResultWork.OffsetPayment; // ���E
                dr[PMKAK02025EA.ct_Col_FundTransferPayment] = sumAccPaymentListResultWork.FundTransferPayment; // �����U��
                dr[PMKAK02025EA.ct_Col_OthsPayment] = sumAccPaymentListResultWork.OthsPayment; // ���̑�

                // ���d���z��ǉ�(���E�㍡��d�����z)
                long pureStock = sumAccPaymentListResultWork.OfsThisTimeStock;
                dr[PMKAK02025EA.ct_Col_PureStock] = pureStock;
                
                // ���񍇌v���z(���d���z+�����)
                dr[PMKAK02025EA.ct_Col_StockPricTax] = pureStock + sumAccPaymentListResultWork.OfsThisStockTax;

                // �����X�V�`�F�b�N
                dr[PMKAK02025EA.Col_MonAddUpNonProc] = CheckMonAddUpNonProc(sumAccPaymentListCndtn, sumAccPaymentListResultWork);

                // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
                // �d���z(�v�ŗ�1)
                dr[PMKAK02025EA.ct_Col_TotalThisTimeStockPriceTaxRate1] = sumAccPaymentListResultWork.TotalThisTimeStockPriceTaxRate1;
                // �d���z(�v�ŗ�2)
                dr[PMKAK02025EA.ct_Col_TotalThisTimeStockPriceTaxRate2] = sumAccPaymentListResultWork.TotalThisTimeStockPriceTaxRate2;
                // �d���z(�v���̑�)
                dr[PMKAK02025EA.ct_Col_TotalThisTimeStockPriceOther] = sumAccPaymentListResultWork.TotalThisTimeStockPriceOther;
                // �ԕi�l��(�v�ŗ�1)
                dr[PMKAK02025EA.ct_Col_TotalThisRgdsDisPricTaxRate1] = sumAccPaymentListResultWork.TotalThisRgdsDisPricTaxRate1;
                // �ԕi�l��(�v�ŗ�2)
                dr[PMKAK02025EA.ct_Col_TotalThisRgdsDisPricTaxRate2] = sumAccPaymentListResultWork.TotalThisRgdsDisPricTaxRate2;
                // �ԕi�l��(�v���̑�)
                dr[PMKAK02025EA.ct_Col_TotalThisRgdsDisPricOther] = sumAccPaymentListResultWork.TotalThisRgdsDisPricOther;
                // ���d���z(�v�ŗ�1)
                dr[PMKAK02025EA.ct_Col_TotalPureStockTaxRate1] = sumAccPaymentListResultWork.TotalPureStockTaxRate1;
                // ���d���z(�v�ŗ�2)
                dr[PMKAK02025EA.ct_Col_TotalPureStockTaxRate2] = sumAccPaymentListResultWork.TotalPureStockTaxRate2;
                // ���d���z(�v���̑�)
                dr[PMKAK02025EA.ct_Col_TotalPureStockOther] = sumAccPaymentListResultWork.TotalPureStockOther;
                // �����(�v�ŗ�1)
                dr[PMKAK02025EA.ct_Col_TotalStockPricTaxTaxRate1] = sumAccPaymentListResultWork.TotalStockPricTaxTaxRate1;
                // �����(�v�ŗ�2)
                dr[PMKAK02025EA.ct_Col_TotalStockPricTaxTaxRate2] = sumAccPaymentListResultWork.TotalStockPricTaxTaxRate2;
                // �����(�v���̑�)
                dr[PMKAK02025EA.ct_Col_TotalStockPricTaxOther] = sumAccPaymentListResultWork.TotalStockPricTaxOther;
                // �������v(�v�ŗ�1)
                dr[PMKAK02025EA.ct_Col_TotalStckTtlAccPayBalanceTaxRate1] = sumAccPaymentListResultWork.TotalStckTtlAccPayBalanceTaxRate1;
                // �������v(�v�ŗ�2)
                dr[PMKAK02025EA.ct_Col_TotalStckTtlAccPayBalanceTaxRate2] = sumAccPaymentListResultWork.TotalStckTtlAccPayBalanceTaxRate2;
                // �������v(�v���̑�)
                dr[PMKAK02025EA.ct_Col_TotalStckTtlAccPayBalanceOther] = sumAccPaymentListResultWork.TotalStckTtlAccPayBalanceOther;
                // ����(�v�ŗ�1)
                dr[PMKAK02025EA.ct_Col_TotalStockSlipCountTaxRate1] = sumAccPaymentListResultWork.TotalStockSlipCountTaxRate1;
                // ����(�v�ŗ�2)
                dr[PMKAK02025EA.ct_Col_TotalStockSlipCountTaxRate2] = sumAccPaymentListResultWork.TotalStockSlipCountTaxRate2;
                // ����(�v���̑�)
                dr[PMKAK02025EA.ct_Col_TotalStockSlipCountOther] = sumAccPaymentListResultWork.TotalStockSlipCountOther;
                // �ŗ�1�^�C�g��
                dr[PMKAK02025EA.ct_Col_TitleTaxRate1] = sumAccPaymentListResultWork.TitleTaxRate1;
                // �ŗ�2�^�C�g��
                dr[PMKAK02025EA.ct_Col_TitleTaxRate2] = sumAccPaymentListResultWork.TitleTaxRate2;
                // --- ADD END 3H ������ 2020/04/10 ----------<<<<<
                // --- ADD START 3H ���� 2022/10/20 ----->>>>>
                // �d���z(�v��ې�)
                dr[PMKAK02025EA.Col_TotalThisTimeStockPriceTaxFree] = sumAccPaymentListResultWork.TotalThisTimeStockPriceTaxFree;
                // �ԕi�l��(�v��ې�)
                dr[PMKAK02025EA.Col_TotalThisRgdsDisPricTaxFree] = sumAccPaymentListResultWork.TotalThisRgdsDisPricTaxFree;
                // ���d���z(�v��ې�)
                dr[PMKAK02025EA.Col_TotalPureStockTaxFree] = sumAccPaymentListResultWork.TotalPureStockTaxFree;
                // �����(�v��ې�)
                dr[PMKAK02025EA.Col_TotalStockPricTaxTaxFree] = sumAccPaymentListResultWork.TotalStockPricTaxTaxFree;
                // �������v(�v��ې�)
                dr[PMKAK02025EA.Col_TotalStckTtlAccPayBalanceTaxFree] = sumAccPaymentListResultWork.TotalStckTtlAccPayBalanceTaxFree;
                // ����(�v��ې�)
                dr[PMKAK02025EA.Col_TotalStockSlipCountTaxFree] = sumAccPaymentListResultWork.TotalStockSlipCountTaxFree;
                // --- ADD END 3H ���� 2022/10/20 -----<<<<<

                // Table��Add
				accPaymentTable.Rows.Add( dr );
			}
		}
		#endregion

        /// <summary>
        /// �o�͋��z�敪�`�F�b�N
        /// </summary>
        /// <param name="sumAccPaymentListCndtn">UI���o�����N���X</param>
        /// <param name="sumAccPaymentListResultWork">���o���ʃN���X</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �o�͋��z�敪�ō���x���z���`�F�b�N����B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
        private bool CheckOutputMoneyDiv(SumAccPaymentListCndtn sumAccPaymentListCndtn, SumAccPaymentListResultWork sumAccPaymentListResultWork)
        {
            bool bRet = false;

            // �o�͋��z�敪�Ŏd�����v�c���̃`�F�b�N
            switch (sumAccPaymentListCndtn.OutMoneyDiv)
            {
                case SumAccPaymentListCndtn.OutMoneyDivState.All: // �S�ďo�� 
                    {
                        bRet = true;
                        break;
                    }
                case SumAccPaymentListCndtn.OutMoneyDivState.ZeroPlus: // �O�ƃv���X���z���o��
                    {
                        if (sumAccPaymentListResultWork.StckTtlAccPayBalance >= 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumAccPaymentListCndtn.OutMoneyDivState.Plus: // �v���X���z�̂ݏo��
                    {
                        if (sumAccPaymentListResultWork.StckTtlAccPayBalance > 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumAccPaymentListCndtn.OutMoneyDivState.Zero: // �O�̂ݏo��
                    {
                        if (sumAccPaymentListResultWork.StckTtlAccPayBalance == 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumAccPaymentListCndtn.OutMoneyDivState.PlusMinus: // �v���X���z�ƃ}�C�i�X���z���o��
                    {
                        if (sumAccPaymentListResultWork.StckTtlAccPayBalance != 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumAccPaymentListCndtn.OutMoneyDivState.ZeroMinus: // �O�ƃ}�C�i�X���z���o��
                    {
                        if (sumAccPaymentListResultWork.StckTtlAccPayBalance <= 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumAccPaymentListCndtn.OutMoneyDivState.Minus: // �}�C�i�X���z�̂ݏo��
                    {
                        if (sumAccPaymentListResultWork.StckTtlAccPayBalance < 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                default:
                    break;
            }
            
            return bRet;
        }

        /// <summary>
        /// ���������X�V�`�F�b�N
        /// </summary>
        /// <param name="sumAccPaymentListCndtn">UI���o�����N���X</param>
        /// <param name="sumAccPaymentListResultWork">���o���ʃN���X</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���_���̌��������X�V�`�F�b�N���s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2012/11/07</br>
        /// </remarks>
        private bool CheckMonAddUpNonProc(SumAccPaymentListCndtn sumAccPaymentListCndtn, SumAccPaymentListResultWork sumAccPaymentListResultWork)
        {
            bool retb = false;
            string key = sumAccPaymentListResultWork.AddUpSecCode.TrimEnd();

            if (_monAddUpNonProcDic.ContainsKey(key))
            {
                // �Y�����_�̌��������X�V�`�F�b�N��
                retb = _monAddUpNonProcDic[key];
            }
            else
            {
                // �Y�����_�̌��������X�V�`�F�b�N
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                DateTime prevTotalDay;
                DateTime currentTotalDay;
                DateTime prevTotalMonth;
                DateTime currentTotalMonth;
                totalDayCalculator.InitializeHisMonthlyAccPay();
                totalDayCalculator.GetHisTotalDayMonthlyAccPay(key, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);

                if (prevTotalMonth == DateTime.MinValue)
                {
                    // ���������X�V
                    _monAddUpNonProcDic.Add(key, true);
                    retb = true;

                }
                else
                {
                    // �������X�V
                    if (prevTotalMonth < sumAccPaymentListCndtn.AddUpYearMonth)
                    {
                        // ���������O����X�V����薢��
                        _monAddUpNonProcDic.Add(key, true);
                        retb = true;
                    }
                    else
                    {
                        // ���������O����X�V���ȑO
                        _monAddUpNonProcDic.Add(key, false);
                        retb = false;
                    }
                }
            }
            return retb;
        }

		#endregion �� �f�[�^�W�J����

		#region �� ���[�ݒ�f�[�^�擾

        #region �� ���[�o�͐ݒ�擾����
		/// <summary>
		/// ���[�o�͐ݒ�Ǎ�
		/// </summary>
		/// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
		static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			retPrtOutSet = new PrtOutSet();
			errMsg = "";	

			try
			{
				// �f�[�^�͓Ǎ��ς݂��H
				if (stc_PrtOutSet != null)
				{
					retPrtOutSet = stc_PrtOutSet.Clone(); 
					status    = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				} 
				else 
				{
					status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

					switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							retPrtOutSet = stc_PrtOutSet.Clone();	
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
						default:
							errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
							status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
							break;
					}
				}
			}
			catch(Exception ex)
			{
				errMsg = ex.Message;
				retPrtOutSet = new PrtOutSet();
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion �� ���[�ݒ�f�[�^�擾
		#endregion �� Private Method

	}
}
