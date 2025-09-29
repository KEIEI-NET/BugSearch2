//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d�����͕\
// �v���O�����T�v   : �d�����͕\�̈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �� �� ��  2008/11/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/01/30  �C�����e : �݌Ɋz�̌v�Z���C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/04/13  �C�����e : Mantis�y13136�z�c�Č�No.19 �[������
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �d�����͕\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : �d�����͕\�g�p����f�[�^���擾����B</br>
    /// <br>Programmer   : 30452 ��� �r��</br>
    /// <br>Date         : 2008.11.10</br>
    /// <br>Programmer   : 30452 ��� �r��</br>
    /// <br>Date         : 2009.01.30</br>
    /// <br>             : �݌Ɋz�̌v�Z���C��</br>
    /// <br>             : </br>
    /// </remarks>
    public class SlipHistAnalyzeAcs
    {
        #region �� �R���X�g���N�^
        /// <summary>
        /// �d�����͕\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �d�����͕\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.10</br>
		/// </remarks>
        public SlipHistAnalyzeAcs()
		{
            this._iSlipHistAnalyzeResultWorkDB = (ISlipHistAnalyzeResultWorkDB)MediationSlipHistAnalyzeResultWorkDB.GetSlipHistAnalyzeResultWorkDB();
		}

        /// <summary>
        /// �d�����͕\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �d�����͕\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.10</br>
		/// </remarks>
        static SlipHistAnalyzeAcs()
		{
            stc_Employee		= null;
			stc_PrtOutSet		= null;					// ���[�o�͐ݒ�f�[�^�N���X
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

            stc_SecInfoAcs      = new SecInfoAcs(1);    // ���_�A�N�Z�X�N���X
            stc_SectionDic      = new Dictionary<string,SecInfoSet>();  // ���_Dictionary

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // ���_Dictionary����
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSetList )
            {
                // �����łȂ����
                if ( !stc_SectionDic.ContainsKey( secInfoSet.SectionCode ) )
                {
                    // �ǉ�
                    stc_SectionDic.Add( secInfoSet.SectionCode, secInfoSet );
                }
            }
        }
        #endregion 

        #region �� Static�ϐ�
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X

        private static SecInfoAcs stc_SecInfoAcs;               // ���_�A�N�Z�X�N���X
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // ���_Dictionary
        #endregion

        #region �� Private�ϐ�
        ISlipHistAnalyzeResultWorkDB _iSlipHistAnalyzeResultWorkDB;

        private DataTable _slipHistAnalyzeDt;			// ���DataTable
        private DataView _slipHistAnalyzeDv;	        // ���DataView

        #endregion

        #region �� Public�v���p�e�B
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataView SlipHistAnalyzeDataView
        {
            get { return this._slipHistAnalyzeDv; }
        }
        #endregion

        #region �� Public���\�b�h
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="salesRsltListCndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note         : �������f�[�^���擾����B</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.10</br>
        /// </remarks>
        public int SearchMain(SlipHistAnalyzeParam slipHistAnalyzeParam, out string errMsg)
        {
            return this.SearchProc(slipHistAnalyzeParam, out errMsg);
        }

        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
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
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region �� Private���\�b�h
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="salesRsltListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.10</br>
        /// </remarks>
        private int SearchProc(SlipHistAnalyzeParam slipHistAnalyzeParam, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKOU02025EA.CreateDataTable(ref this._slipHistAnalyzeDt);

                SlipHistAnalyzeParamWork slipHistAnalyzeParamWork = new SlipHistAnalyzeParamWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevListCndtn(slipHistAnalyzeParam, out slipHistAnalyzeParamWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iSlipHistAnalyzeResultWorkDB.Search(out retWorkList, slipHistAnalyzeParamWork, 0, ConstantManagement.LogicalMode.GetData0);

                // �e�X�g�p
                //status = this.testproc(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevListData(slipHistAnalyzeParam, (ArrayList)retWorkList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�d�����͕\�f�[�^�̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="salesRsltListCndtn">UI���o�����N���X</param>
        /// <param name="salesRsltListCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       �@: ��ʒ��o�����������[�g���o�����֓W�J����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.10</br>
        /// </remarks>
        private int DevListCndtn(SlipHistAnalyzeParam slipHistAnalyzeParam, out SlipHistAnalyzeParamWork slipHistAnalyzeParamWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            slipHistAnalyzeParamWork = new SlipHistAnalyzeParamWork();
            try
            {
                slipHistAnalyzeParamWork.EnterpriseCode = slipHistAnalyzeParam.EnterpriseCode;  // ��ƃR�[�h

                // ���o�����p�����[�^�Z�b�g
                if (slipHistAnalyzeParam.SectionCodes.Length != 0)
                {
                    if (slipHistAnalyzeParam.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        slipHistAnalyzeParamWork.SectionCodes = null;
                    }
                    else
                    {
                        slipHistAnalyzeParamWork.SectionCodes = slipHistAnalyzeParam.SectionCodes;
                    }
                }
                else
                {
                    slipHistAnalyzeParamWork.SectionCodes = null;
                }

                slipHistAnalyzeParamWork.StSupplierCd = slipHistAnalyzeParam.StSupplierCd; // �J�n�d����R�[�h
                if (slipHistAnalyzeParam.EdSupplierCd == 0) slipHistAnalyzeParamWork.EdSupplierCd = 999999;
                else slipHistAnalyzeParamWork.EdSupplierCd = slipHistAnalyzeParam.EdSupplierCd; // �I���d����R�[�h
                slipHistAnalyzeParamWork.StAddUpYearMonth = slipHistAnalyzeParam.StAddUpYearMonth; // �J�n�N�x
                slipHistAnalyzeParamWork.EdAddUpYearMonth = slipHistAnalyzeParam.EdAddUpYearMonth; // �I���N�x
                slipHistAnalyzeParamWork.StAnnualAddUpYearMonth = slipHistAnalyzeParam.StAnnualAddUpYearMonth; // �J�n�v��N��
                slipHistAnalyzeParamWork.EdAnnualAddUpYearMonth = slipHistAnalyzeParam.EdAnnualAddUpYearMonth; // �I���v��N��
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="salesRsltListCndtn">UI���o�����N���X</param>
        /// <param name="resultWork">�擾�f�[�^</param>
        /// <remarks>
        /// <br>Note       �@: �����[�g���o���ʂ𒠕[�󎚗pDataTable�֓W�J����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.10</br>
        /// </remarks>
        private void DevListData(SlipHistAnalyzeParam slipHistAnalyzeParam, ArrayList resultWork)
        {
            // �����[�g���o���ʂ������[�g���o���ʗpDataTable�ɓW�J
            DataRow dr;
            // ���d�����vDictionary
            // key:�\����P�� value�F�\����P�ʖ��̏��d���z���v
            string dicKey;
            Dictionary<string, long> pureTotalPriceSumDic = new Dictionary<string, long>(); ; // (����)
            Dictionary<string, long> annualPureTotalPriceSumDic = new Dictionary<string, long>(); // (����)

            foreach (SlipHistAnalyzeResultWork slipHistAnalyzeResultWork in resultWork)
            {
                dr = this._slipHistAnalyzeDt.NewRow();

                // 2009.03.02 30413 ���� �ԕi�E�l���̕����𔽓]������ >>>>>>START
                // �����[�g���o���ʍ���
                dr[PMKOU02025EA.ct_Col_AddUpSecCode] = slipHistAnalyzeResultWork.AddUpSecCode; // �v�㋒�_�R�[�h
                dr[PMKOU02025EA.ct_Col_SectionGuideSnm] = slipHistAnalyzeResultWork.SectionGuideSnm; // ���_�K�C�h����
                dr[PMKOU02025EA.ct_Col_SupplierCd] = slipHistAnalyzeResultWork.SupplierCd; // �d����R�[�h
                dr[PMKOU02025EA.ct_Col_SupplierSnm] = slipHistAnalyzeResultWork.SupplierSnm; // �d���旪��
                dr[PMKOU02025EA.ct_Col_TotalPrice] = slipHistAnalyzeResultWork.TotalPrice; // �d�����z���v(����)
                //dr[PMKOU02025EA.ct_Col_RetGoodsPrice] = slipHistAnalyzeResultWork.RetGoodsPrice; // �d���ԕi�z(����)
                //dr[PMKOU02025EA.ct_Col_TotalDiscount] = slipHistAnalyzeResultWork.TotalDiscount; // �d���l���v(����)
                dr[PMKOU02025EA.ct_Col_RetGoodsPrice] = -(slipHistAnalyzeResultWork.RetGoodsPrice); // �d���ԕi�z(����)
                dr[PMKOU02025EA.ct_Col_TotalDiscount] = -(slipHistAnalyzeResultWork.TotalDiscount); // �d���l���v(����)
                dr[PMKOU02025EA.ct_Col_TotalPriceStock] = slipHistAnalyzeResultWork.TotalPriceStock; // �d�����z���v(�����݌�)
                dr[PMKOU02025EA.ct_Col_TotalPriceTotal] = slipHistAnalyzeResultWork.TotalPriceTotal; // �d�����z���v(�������v)
                dr[PMKOU02025EA.ct_Col_AnnualTotalPrice] = slipHistAnalyzeResultWork.AnnualTotalPrice; // �d�����z���v(����)
                //dr[PMKOU02025EA.ct_Col_AnnualRetGoodsPrice] = slipHistAnalyzeResultWork.AnnualRetGoodsPrice; // �d���ԕi�z(����)
                //dr[PMKOU02025EA.ct_Col_AnnualTotalDiscount] = slipHistAnalyzeResultWork.AnnualTotalDiscount; // �d���l���v(����)
                dr[PMKOU02025EA.ct_Col_AnnualRetGoodsPrice] = -(slipHistAnalyzeResultWork.AnnualRetGoodsPrice); // �d���ԕi�z(����)
                dr[PMKOU02025EA.ct_Col_AnnualTotalDiscount] = -(slipHistAnalyzeResultWork.AnnualTotalDiscount); // �d���l���v(����)
                dr[PMKOU02025EA.ct_Col_AnnualTotalPriceStock] = slipHistAnalyzeResultWork.AnnualTotalPriceStock; // �d�����z���v(�����݌�)
                dr[PMKOU02025EA.ct_Col_AnnualTotalPriceTotal] = slipHistAnalyzeResultWork.AnnualTotalPriceTotal; // �d�����z���v(�������v)
                // 2009.03.02 30413 ���� �ԕi�E�l���̕����𔽓]������ <<<<<<END
            
                // ��������
                dr[PMKOU02025EA.ct_Col_PureTotalPrice] = slipHistAnalyzeResultWork.TotalPrice 
                                                        + slipHistAnalyzeResultWork.RetGoodsPrice 
                                                        + slipHistAnalyzeResultWork.TotalDiscount; // ���d��(����)

                //dr[PMKOU02025EA.ct_Col_StockPrice] = slipHistAnalyzeResultWork.TotalPriceStock 
                //                                    + slipHistAnalyzeResultWork.RetGoodsPrice
                //                                    + slipHistAnalyzeResultWork.TotalDiscount; // �݌Ɋz(����) // DEL 2009/01/30
                dr[PMKOU02025EA.ct_Col_StockPrice] = slipHistAnalyzeResultWork.TotalPriceStock; // �݌Ɋz(����) // ADD 2009/01/30

                dr[PMKOU02025EA.ct_Col_OrderPrice] = slipHistAnalyzeResultWork.TotalPriceTotal 
                                                    - slipHistAnalyzeResultWork.TotalPriceStock; // ���z(����)

                // ��������
                dr[PMKOU02025EA.ct_Col_AnnualPureTotalPrice] = slipHistAnalyzeResultWork.AnnualTotalPrice
                                                              + slipHistAnalyzeResultWork.AnnualRetGoodsPrice
                                                              + slipHistAnalyzeResultWork.AnnualTotalDiscount; // ���d��(����)

                //dr[PMKOU02025EA.ct_Col_AnnualStockPrice] = slipHistAnalyzeResultWork.AnnualTotalPriceStock
                //                                          + slipHistAnalyzeResultWork.AnnualRetGoodsPrice
                //                                          + slipHistAnalyzeResultWork.AnnualTotalDiscount; // �݌Ɋz�i�����j // DEL 2009/01/30
                dr[PMKOU02025EA.ct_Col_AnnualStockPrice] = slipHistAnalyzeResultWork.AnnualTotalPriceStock; // �݌Ɋz�i�����j // ADD 2009/01/30

                dr[PMKOU02025EA.ct_Col_AnnualOrderPrice] = slipHistAnalyzeResultWork.AnnualTotalPriceTotal
                                                          - slipHistAnalyzeResultWork.AnnualTotalPriceStock; // ���z�i�����j

                // 2009.03.02 30413 ���� �ԕi�E�l���̕����𔽓]������ >>>>>>START
                // ���v�Z�p����(���z�P�ʂ�K�p���Ȃ�)
                dr[PMKOU02025EA.ct_Col_TotalPriceOrg] = slipHistAnalyzeResultWork.TotalPrice; // �d�����z���v(����)
                //dr[PMKOU02025EA.ct_Col_RetGoodsPriceOrg] = slipHistAnalyzeResultWork.RetGoodsPrice; // �d���ԕi�z(����)
                //dr[PMKOU02025EA.ct_Col_TotalDiscountOrg] = slipHistAnalyzeResultWork.TotalDiscount; // �d���l���v(����)
                dr[PMKOU02025EA.ct_Col_RetGoodsPriceOrg] = -(slipHistAnalyzeResultWork.RetGoodsPrice); // �d���ԕi�z(����)
                dr[PMKOU02025EA.ct_Col_TotalDiscountOrg] = -(slipHistAnalyzeResultWork.TotalDiscount); // �d���l���v(����)
                dr[PMKOU02025EA.ct_Col_AnnualTotalPriceOrg] = slipHistAnalyzeResultWork.AnnualTotalPrice; // �d�����z���v(����)
                //dr[PMKOU02025EA.ct_Col_AnnualRetGoodsPriceOrg] = slipHistAnalyzeResultWork.AnnualRetGoodsPrice; // �d���ԕi�z(����)
                //dr[PMKOU02025EA.ct_Col_AnnualTotalDiscountOrg] = slipHistAnalyzeResultWork.AnnualTotalDiscount; // �d���l���v(����)
                dr[PMKOU02025EA.ct_Col_AnnualRetGoodsPriceOrg] = -(slipHistAnalyzeResultWork.AnnualRetGoodsPrice); // �d���ԕi�z(����)
                dr[PMKOU02025EA.ct_Col_AnnualTotalDiscountOrg] = -(slipHistAnalyzeResultWork.AnnualTotalDiscount); // �d���l���v(����)
                // 2009.03.02 30413 ���� �ԕi�E�l���̕����𔽓]������ <<<<<<END
            
                dr[PMKOU02025EA.ct_Col_PureTotalPriceOrg] = slipHistAnalyzeResultWork.TotalPrice
                                                        + slipHistAnalyzeResultWork.RetGoodsPrice
                                                        + slipHistAnalyzeResultWork.TotalDiscount; // ���d��(����)

                //dr[PMKOU02025EA.ct_Col_StockPriceOrg] = slipHistAnalyzeResultWork.TotalPriceStock
                //                                    + slipHistAnalyzeResultWork.RetGoodsPrice
                //                                    + slipHistAnalyzeResultWork.TotalDiscount; // �݌Ɋz(����) // DEL 2009/01/30
                dr[PMKOU02025EA.ct_Col_StockPriceOrg] = slipHistAnalyzeResultWork.TotalPriceStock; // �݌Ɋz(����) // ADD 2009/01/30

                dr[PMKOU02025EA.ct_Col_OrderPriceOrg] = slipHistAnalyzeResultWork.TotalPriceTotal
                                                    - slipHistAnalyzeResultWork.TotalPriceStock; // ���z(����)

                dr[PMKOU02025EA.ct_Col_AnnualPureTotalPriceOrg] = slipHistAnalyzeResultWork.AnnualTotalPrice
                                                              + slipHistAnalyzeResultWork.AnnualRetGoodsPrice
                                                              + slipHistAnalyzeResultWork.AnnualTotalDiscount; // ���d��(����)

                //dr[PMKOU02025EA.ct_Col_AnnualStockPriceOrg] = slipHistAnalyzeResultWork.AnnualTotalPriceStock
                //                                          + slipHistAnalyzeResultWork.AnnualRetGoodsPrice
                //                                          + slipHistAnalyzeResultWork.AnnualTotalDiscount; // �݌Ɋz�i�����j // DEL 2009/01/30
                dr[PMKOU02025EA.ct_Col_AnnualStockPriceOrg] = slipHistAnalyzeResultWork.AnnualTotalPriceStock; // �݌Ɋz�i�����j // ADD 2009/01/30

                dr[PMKOU02025EA.ct_Col_AnnualOrderPriceOrg] = slipHistAnalyzeResultWork.AnnualTotalPriceTotal
                                                          - slipHistAnalyzeResultWork.AnnualTotalPriceStock; // ���z�i�����j

                // �\����P�ʗp ���d�����v
                if (slipHistAnalyzeParam.ConstUnitDiv == SlipHistAnalyzeParam.ConstUnitDivState.Total)
                {
                    // �����v
                    dicKey = string.Empty;
                }
                else
                {
                    if (slipHistAnalyzeParam.PrintType == SlipHistAnalyzeParam.PrintTypeState.Section)
                    {
                        dicKey = slipHistAnalyzeResultWork.AddUpSecCode;
                    }
                    else
                    {
                        dicKey = slipHistAnalyzeResultWork.SupplierCd.ToString();
                    }
                }

                // ����
                if (pureTotalPriceSumDic.ContainsKey(dicKey))
                {
                    // ���L�[�l�̏ꍇ���Z
                    pureTotalPriceSumDic[dicKey] = pureTotalPriceSumDic[dicKey]
                                                        + slipHistAnalyzeResultWork.TotalPrice
                                                        + slipHistAnalyzeResultWork.RetGoodsPrice
                                                        + slipHistAnalyzeResultWork.TotalDiscount;
                }
                else
                {
                    // �V�K�ǉ�
                    pureTotalPriceSumDic.Add(dicKey, slipHistAnalyzeResultWork.TotalPrice
                                                        + slipHistAnalyzeResultWork.RetGoodsPrice
                                                        + slipHistAnalyzeResultWork.TotalDiscount);
                }

                // ����
                if (annualPureTotalPriceSumDic.ContainsKey(dicKey))
                {
                    annualPureTotalPriceSumDic[dicKey] = annualPureTotalPriceSumDic[dicKey]
                                                        + slipHistAnalyzeResultWork.AnnualTotalPrice
                                                        + slipHistAnalyzeResultWork.AnnualRetGoodsPrice
                                                        + slipHistAnalyzeResultWork.AnnualTotalDiscount;
                }
                else
                {
                    annualPureTotalPriceSumDic.Add(dicKey, slipHistAnalyzeResultWork.AnnualTotalPrice
                                                        + slipHistAnalyzeResultWork.AnnualRetGoodsPrice
                                                        + slipHistAnalyzeResultWork.AnnualTotalDiscount);
                }

                this._slipHistAnalyzeDt.Rows.Add(dr);
            }

            // �\����P��
            foreach (DataRow workDr in this._slipHistAnalyzeDt.Rows)
            {
                if (slipHistAnalyzeParam.ConstUnitDiv == SlipHistAnalyzeParam.ConstUnitDivState.Total)
                {
                    workDr[PMKOU02025EA.ct_Col_PureTotalPriceSum] = pureTotalPriceSumDic[string.Empty];
                    workDr[PMKOU02025EA.ct_Col_AnnualPureTotalPriceSum] = annualPureTotalPriceSumDic[string.Empty];
                }
                else
                {
                    if (slipHistAnalyzeParam.PrintType == SlipHistAnalyzeParam.PrintTypeState.Section)
                    {
                        workDr[PMKOU02025EA.ct_Col_PureTotalPriceSum] = pureTotalPriceSumDic[workDr[PMKOU02025EA.ct_Col_AddUpSecCode].ToString()];
                        workDr[PMKOU02025EA.ct_Col_AnnualPureTotalPriceSum] = annualPureTotalPriceSumDic[workDr[PMKOU02025EA.ct_Col_AddUpSecCode].ToString()];
                    }
                    else
                    {
                        workDr[PMKOU02025EA.ct_Col_PureTotalPriceSum] = pureTotalPriceSumDic[workDr[PMKOU02025EA.ct_Col_SupplierCd].ToString()];
                        workDr[PMKOU02025EA.ct_Col_AnnualPureTotalPriceSum] = annualPureTotalPriceSumDic[workDr[PMKOU02025EA.ct_Col_SupplierCd].ToString()];
                    }
                }
            }

            // ���z�P�ʓK�p
            //this.SetMoneyUnit(slipHistAnalyzeParam);      // DEL 2009/04/13

            // DataView�쐬
            // ���s�^�C�v�ɂ��\�[�g
            this._slipHistAnalyzeDv = new DataView(this._slipHistAnalyzeDt, "", this.GetSortStr(slipHistAnalyzeParam), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// ���z�P�ʓK�p
        /// </summary>
        /// <param name="slipHistAnalyzeParam"></param>
        private void SetMoneyUnit(SlipHistAnalyzeParam slipHistAnalyzeParam)
        {
            int moneyUnit = 1;

            if (slipHistAnalyzeParam.MoneyUnitDiv == SlipHistAnalyzeParam.MoneyUnitDivState.One)
            {
                // �����͕s�v
                return;
            }
            else if (slipHistAnalyzeParam.MoneyUnitDiv == SlipHistAnalyzeParam.MoneyUnitDivState.Thousand)
            {
                // ��~�P��
                moneyUnit = 1000;
            }

            foreach (DataRow dr in this._slipHistAnalyzeDt.Rows)
            {
                dr[PMKOU02025EA.ct_Col_TotalPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_TotalPrice]) / (decimal)moneyUnit); // �d�����z���v(����)
                dr[PMKOU02025EA.ct_Col_RetGoodsPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_RetGoodsPrice]) / (decimal)moneyUnit); // �d���ԕi�z(����)
                dr[PMKOU02025EA.ct_Col_TotalDiscount] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_TotalDiscount]) / (decimal)moneyUnit); // �d���l���v(����)
                dr[PMKOU02025EA.ct_Col_PureTotalPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_PureTotalPrice]) / (decimal)moneyUnit); // ���d���i�����j
                dr[PMKOU02025EA.ct_Col_StockPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_StockPrice]) / (decimal)moneyUnit); // �݌Ɋz�i�����j
                dr[PMKOU02025EA.ct_Col_OrderPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_OrderPrice]) / (decimal)moneyUnit); // ���z�i�����j

                dr[PMKOU02025EA.ct_Col_AnnualTotalPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_AnnualTotalPrice]) / (decimal)moneyUnit); // �d�����z���v(����)
                dr[PMKOU02025EA.ct_Col_AnnualRetGoodsPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_AnnualRetGoodsPrice]) / (decimal)moneyUnit); // �d���ԕi�z(����)
                dr[PMKOU02025EA.ct_Col_AnnualTotalDiscount] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_AnnualTotalDiscount]) / (decimal)moneyUnit); // �d���l���v(����)
                dr[PMKOU02025EA.ct_Col_AnnualPureTotalPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_AnnualPureTotalPrice]) / (decimal)moneyUnit); // ���d���i�����j
                dr[PMKOU02025EA.ct_Col_AnnualStockPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_AnnualStockPrice]) / (decimal)moneyUnit); // �݌Ɋz�i�����j
                dr[PMKOU02025EA.ct_Col_AnnualOrderPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_AnnualOrderPrice]) / (decimal)moneyUnit); // ���z�i�����j
            }
        }

        /// <summary>
        /// �\�[�g������擾
        /// </summary>
        /// <param name="slipHistAnalyzeParam"></param>
        /// <returns></returns>
        private string GetSortStr(SlipHistAnalyzeParam slipHistAnalyzeParam)
        {
            if (slipHistAnalyzeParam.PrintType == SlipHistAnalyzeParam.PrintTypeState.Section)
            {
                return PMKOU02025EA.ct_Col_AddUpSecCode + ", " + PMKOU02025EA.ct_Col_SupplierCd;
            }
            else
            {
                return PMKOU02025EA.ct_Col_SupplierCd + ", " + PMKOU02025EA.ct_Col_AddUpSecCode;
            }
        }

        #endregion

        #region �e�X�g�f�[�^
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            SlipHistAnalyzeResultWork param1 = new SlipHistAnalyzeResultWork();

            param1.AddUpSecCode = "1"; // �v�㋒�_�R�[�h
            param1.SectionGuideSnm = "���_�̍ő包���P�O��"; // ���_�K�C�h����
            param1.SupplierCd = 1; // �d����R�[�h
            param1.SupplierSnm = "�d����̍ő包�P�O��"; // �d���旪��
            param1.TotalPrice = 100; // �d�����z���v(����)
            param1.RetGoodsPrice = 10; // �d���ԕi�z(����)
            param1.TotalDiscount = 20; // �d���l���v(����)
            param1.TotalPriceStock = 1000; // �d�����z���v(�����݌�)
            param1.TotalPriceTotal = 200; // �d�����z���v(�������v)
            param1.AnnualTotalPrice = 1000; // �d�����z���v(����)
            param1.AnnualRetGoodsPrice = 30; // �d���ԕi�z(����)
            param1.AnnualTotalDiscount = 20; // �d���l���v(����)
            param1.AnnualTotalPriceStock = 10000; // �d�����z���v(�����݌�)
            param1.AnnualTotalPriceTotal = 2500; // �d�����z���v(�������v)

            paramlist.Add(param1);

            SlipHistAnalyzeResultWork param2 = new SlipHistAnalyzeResultWork();

            param2.AddUpSecCode = "2"; // �v�㋒�_�R�[�h
            param2.SectionGuideSnm = "���_�̍ő包���P�O��"; // ���_�K�C�h����
            param2.SupplierCd = 1; // �d����R�[�h
            param2.SupplierSnm = "�d����̍ő包�P�O��"; // �d���旪��
            param2.TotalPrice = 100; // �d�����z���v(����)
            param2.RetGoodsPrice = 10; // �d���ԕi�z(����)
            param2.TotalDiscount = 20; // �d���l���v(����)
            param2.TotalPriceStock = 1000; // �d�����z���v(�����݌�)
            param2.TotalPriceTotal = 200; // �d�����z���v(�������v)
            param2.AnnualTotalPrice = 1000; // �d�����z���v(����)
            param2.AnnualRetGoodsPrice = 30; // �d���ԕi�z(����)
            param2.AnnualTotalDiscount = 20; // �d���l���v(����)
            param2.AnnualTotalPriceStock = 10000; // �d�����z���v(�����݌�)
            param2.AnnualTotalPriceTotal = 2500; // �d�����z���v(�������v)
            
            paramlist.Add(param2);

            SlipHistAnalyzeResultWork param3 = new SlipHistAnalyzeResultWork();

            param3.AddUpSecCode = ""; // �v�㋒�_�R�[�h
            param3.SectionGuideSnm = ""; // ���_�K�C�h����
            param3.SupplierCd = 0; // �d����R�[�h
            param3.SupplierSnm = ""; // �d���旪��
            param3.TotalPrice = 0; // �d�����z���v(����)
            param3.RetGoodsPrice = 0; // �d���ԕi�z(����)
            param3.TotalDiscount = 0; // �d���l���v(����)
            param3.TotalPriceStock = 0; // �d�����z���v(�����݌�)
            param3.TotalPriceTotal = 0; // �d�����z���v(�������v)
            param3.AnnualTotalPrice = 0; // �d�����z���v(����)
            param3.AnnualRetGoodsPrice = 0; // �d���ԕi�z(����)
            param3.AnnualTotalDiscount = 0; // �d���l���v(����)
            param3.AnnualTotalPriceStock = 0; // �d�����z���v(�����݌�)
            param3.AnnualTotalPriceTotal = 0; // �d�����z���v(�������v)

            paramlist.Add(param3);

            retList = (object)paramlist;

            return 0;

        }
        #endregion
    }
}
