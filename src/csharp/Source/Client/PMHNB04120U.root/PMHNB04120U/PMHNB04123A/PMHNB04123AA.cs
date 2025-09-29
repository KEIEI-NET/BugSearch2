using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common; // ADD 2010/07/20

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���Ӑ�ߔN�x���яƉ�f�[�^�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ߔN�x���яƉ�̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 30418 ���i</br>
    /// <br>Date       : 2008.11.18</br>
    /// <br>UpdateNote : 2010/07/20 �I�M</br>
    /// <br>                Excel�A�e�L�X�g�o�͑Ή��i�U�����ǒǉ��˗����j</br>
    /// <br>UpdateNote : 2010/08/02 chenyd</br>
    /// <br>                Excel�A�e�L�X�g�o�͑Ή��i�U�����ǒǉ��˗����j</br>
    /// <br>UpdateNote : 2010/10/13 yanmgj</br>
    /// <br>             �e�L�X�g�o�͑Ή�</br>
    /// <br></br>
    /// </remarks>
    public partial class CustPastExperienceAcs
    {
        #region �v���C�x�[�g�ϐ�

        /// <summary>���Ӑ�ߔN�x���яƉ���[�g�N���X</summary>
        private ICustomInqOrderWorkDB _customInqOrderWorkDB = null;

        /// <summary>���Ӑ�ߔN�x���яƉ���[�g�����������[�N�N���X</summary>
        private CustomInqOrderCndtnWork _customInqOrderCndtnWork = null;

        /// <summary>���Ӑ�ߔN�x���яƉ�ꗗ�f�[�^�Z�b�g</summary>
        private CustomInqOrderDataSet _dataSet = null;

        /// <summary>���Ӑ�</summary>
        private CustomerSearchRet[] customerSearchRet;// ADD 2010/08/02

        /// <summary>��v�N�x�i���N�x�j</summary>
        private int _fiscalYear = 0;

        #endregion // �v���C�x�[�g�ϐ�

        #region �萔

        /// <summary>��v�N�x��̊�{�P��</summary>
        private const string CT_FISCALYEAR_MEASURE = "�N�x";

        #endregion // �萔

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public CustPastExperienceAcs()
        {
            // �����[�gDB�擾
            _customInqOrderWorkDB = MediationCustomInqOrderWorkDB.GetCustomInqOrderWorkDB();

            // ���������N���X�쐬
            _customInqOrderCndtnWork = new CustomInqOrderCndtnWork();

            // �f�[�^�Z�b�g�쐬
            this._dataSet = new CustomInqOrderDataSet();

            // �R���X�g���N�^���C���X�^���X���쐬�������_�ŁA�f�[�^�Z�b�g���L���ɂȂ�

        }

        #endregion // �R���X�g���N�^

        #region �p�u���b�N�I�u�W�F�N�g

        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�ꗗ�f�[�^�Z�b�g
        /// </summary>
        public CustomInqOrderDataSet DataSet
        {
            get { return this._dataSet; }
            set { this._dataSet = value; }
        }

        /// <summary>
        /// ��v�N�x
        /// </summary>
        public int FiscalYear
        {
            get { return this._fiscalYear; }
            set { this._fiscalYear = value; }
        }

        #endregion // �p�u���b�N�I�u�W�F�N�g

        #region �������s

        /// <summary>
        /// �������s
        /// </summary>
        public int Search(CustomInqOrderCndtn customInqOrderCndtn)
        {
            // ���������N���X���烊���[�g�����������[�N�N���X�փR�s�[
            CopyParamater2RemoteParameterWork(customInqOrderCndtn);

            // �������s
            object result;
            int status = _customInqOrderWorkDB.Search(out result, (object)this._customInqOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �f�[�^�Z�b�g�֓ǂݍ��񂾏����Z�b�g
                if (result is ArrayList)
                {
                    // ��v�N�x�i���N�x�F�t�H�[���N���X����Z�b�g�����j
                    int fiscalYear = this._fiscalYear;

                    foreach (CustomInqResultWork resultWork in (ArrayList)result)
                    {
                        // --- CHG 2009/03/09 ��QID:11994�Ή�------------------------------------------------------>>>>>
                        //AddRowData(resultWork, customInqOrderCndtn, fiscalYear - 1);
                        AddRowData(resultWork, customInqOrderCndtn, fiscalYear);
                        // --- CHG 2009/03/09 ��QID11994:�Ή�------------------------------------------------------<<<<<
                        fiscalYear--;
                    }
                }
            }
            else
            {
                return status;
            }

            return status;
        }

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>
        /// ������яƉ�f�[�^���������A�������ʂ��f�[�^�e�[�u���ɃL���b�V�����܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="selectionCodeInt">�I�����ڃR�[�h�i���l�j</param>
        /// <param name="selectionCodeStr">�I�����ڃR�[�h�i�����j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>UpdateNote  : 2010/08/02 chenyd</br>
        /// <br>             �EExcel�A�e�L�X�g�o�͑Ή�</br>
        /// <br>UpdateNote  : 2010/09/14 ����</br>
        /// <br>             �Ereadmine #14434�̂R�Ή�</br>
        /// </remarks>
        public int SearchAll(string enterpriseCode, List<string[]> sectionCodeList, List<string[]> selectionCodeList)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomInqOrderCndtn customInqOrderCndtn = null;
            // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
            // ��v�N�x���擾
            int startDate;
            int endDate;
            int fiscalYear = 0;
            ArrayList CndtnWorkList = new ArrayList();
            // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
            // �N���A����
            this._dataSet.CustomInqResult.Clear();

            foreach (string[] sectionCode in sectionCodeList)
            {
                if (selectionCodeList.Count != 0)
                {
                    foreach (string[] selectionCode in selectionCodeList)
                    {
                        customInqOrderCndtn = new CustomInqOrderCndtn();

                        customInqOrderCndtn.EnterpriseCode = enterpriseCode;
                        customInqOrderCndtn.AddUpSecCode = sectionCode[0];
                        customInqOrderCndtn.AddUpSecName = sectionCode[1];
                        if (!String.IsNullOrEmpty(selectionCode[0]))
                        {
                            customInqOrderCndtn.CustomerCode = Int32.Parse(selectionCode[0]);
                            customInqOrderCndtn.CustomerName = selectionCode[1];
                        }
                        // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
                        // ��v�N�x���擾
                        //int startDate;
                        //int endDate;
                        //int fiscalYear;
                        // ---------------------- DEL 2010/08/02 ---------------------------------<<<<<
                        status = GetFinancialYearInfo(customInqOrderCndtn.AddUpSecCode, out fiscalYear, out startDate, out endDate);
                        if (status == 0)
                        {
                            customInqOrderCndtn.St_AddUpYearMonth = startDate;
                            customInqOrderCndtn.Ed_AddUpYearMonth = endDate;
                        }
                        if (CheckParameter(customInqOrderCndtn))
                        {
                            // ���������N���X���烊���[�g�����������[�N�N���X�փR�s�[
                            CustomInqOrderCndtnWork customInqOrderCndtnWork = this.CopyParamaterRemoteParameterWork(customInqOrderCndtn);

                            CndtnWorkList.Add(customInqOrderCndtnWork);

                            // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
                            //object paraObj = (object)customInqOrderCndtnWork;
                            //object retObj;

                            //status = this._customInqOrderWorkDB.Search(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

                            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                            //{
                            //    // �f�[�^�Z�b�g�֓ǂݍ��񂾏����Z�b�g
                            //    if (retObj is ArrayList)
                            //    {
                            //        ArrayList resultList = (ArrayList)retObj;
                            //        int tempFiscalYear = fiscalYear;
                            //        this._fiscalYear = fiscalYear;

                            //        if (resultList.Count == 8)
                            //        {
                            //            DataRow row = this._dataSet.CustomInqResult.NewRow();
                            //            bool canAddFlg = false;
                            //            for (int index = 0; index < resultList.Count; index++)
                            //            {
                            //                CustomInqResultWork resultWork = (CustomInqResultWork)resultList[index];
                            //                AddOutputRowData(row, resultWork, customInqOrderCndtn, tempFiscalYear, index, ref canAddFlg);
                            //                tempFiscalYear--;
                            //            }
                            //            if (canAddFlg)
                            //                this._dataSet.CustomInqResult.Rows.Add(row);
                            //        }
                            //    }
                            //}
                            // ---------------------- DEL 2010/08/02 ---------------------------------<<<<<
                        }
                    }
                }
                else
                {

                    customInqOrderCndtn = new CustomInqOrderCndtn();

                    customInqOrderCndtn.EnterpriseCode = enterpriseCode;
                    customInqOrderCndtn.AddUpSecCode = sectionCode[0];
                    customInqOrderCndtn.AddUpSecName = sectionCode[1];
                    customInqOrderCndtn.CustomerCode = 0;
                    // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
                    // ��v�N�x���擾
                    //int startDate;
                    //int endDate;
                    //int fiscalYear;
                    // ---------------------- DEL 2010/08/02 ---------------------------------<<<<<
                    status = GetFinancialYearInfo(customInqOrderCndtn.AddUpSecCode, out fiscalYear, out startDate, out endDate);
                    if (status == 0)
                    {
                        customInqOrderCndtn.St_AddUpYearMonth = startDate;
                        customInqOrderCndtn.Ed_AddUpYearMonth = endDate;
                    }
                    if (CheckParameter(customInqOrderCndtn))
                    {

                        CustomInqOrderCndtnWork customInqOrderCndtnWork = this.CopyParamaterRemoteParameterWork(customInqOrderCndtn);

                        CndtnWorkList.Add(customInqOrderCndtnWork);
                        // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
                        //object paraObj = (object)customInqOrderCndtnWork;
                        //object retObj;

                        //status = this._customInqOrderWorkDB.Search(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

                        //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                        //{
                        //    // �f�[�^�Z�b�g�֓ǂݍ��񂾏����Z�b�g
                        //    if (retObj is ArrayList)
                        //    {
                        //        ArrayList resultList = (ArrayList)retObj;
                        //        int tempFiscalYear = fiscalYear;

                        //        if (resultList.Count == 8)
                        //        {
                        //            DataRow row = this._dataSet.CustomInqResult.NewRow();
                        //            bool canAddFlg = false;
                        //            for (int index = 0; index < resultList.Count; index++)
                        //            {
                        //                CustomInqResultWork resultWork = (CustomInqResultWork)resultList[index];
                        //                AddOutputRowData(row, resultWork, customInqOrderCndtn, tempFiscalYear, index, ref canAddFlg);
                        //                tempFiscalYear--;
                        //            }
                        //            if (canAddFlg)
                        //                this._dataSet.CustomInqResult.Rows.Add(row);
                        //        }
                        //    }
                        //}
                        // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
                    }
                }
            }
            // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
            // ���Ӑ�
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            customerSearchPara.EnterpriseCode = enterpriseCode;
            customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

            object paraObj = (object)CndtnWorkList;
            object retObj;

            status = this._customInqOrderWorkDB.SearchAll(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                // �f�[�^�Z�b�g�֓ǂݍ��񂾏����Z�b�g
                if (retObj is ArrayList)
                {
                    ArrayList resultList = (ArrayList)retObj;
                    foreach (ArrayList array in resultList)
                    {
                        int tempFiscalYear = fiscalYear;
                        this._fiscalYear = fiscalYear;

                        if (array.Count == 8)
                        {
                            DataRow row = this._dataSet.CustomInqResult.NewRow();
                            bool canAddFlg = false;
                            for (int index = 0; index < array.Count; index++)
                            {
                                CustomInqResultWork resultWork = (CustomInqResultWork)array[index];
                                AddOutputRowData(row, resultWork, customInqOrderCndtn, tempFiscalYear, index, ref canAddFlg);
                                tempFiscalYear--;
                            }
                            // --- ADD 2010/09/14 ---------->>>>>
                            canAddFlg = canAddFlg
                                    && ((Int64)row[this._dataSet.CustomInqResult.NetSales1Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales2Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales3Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales4Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales5Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales6Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales7Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales8Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName] != 0);
                            // --- ADD 2010/09/14 ----------<<<<<
                            if (canAddFlg)
                                this._dataSet.CustomInqResult.Rows.Add(row);
                        }
                    }
                }
            }
            // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
            return status;
        }
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
        #endregion // �������s

        #region �f�[�^�Z�b�g���ʃR�s�[

        /// <summary>
        /// �����[�g�����������[�N�N���X�����Ƀf�[�^�Z�b�g�ɍs���쐬
        /// </summary>
        /// <param name="customInqOrderCndtnWork">�������ʃ��[�N</param>
        /// <param name="fiscalYear">��v�N�x</param>
        private void AddRowData(CustomInqResultWork customInqResultWork, CustomInqOrderCndtn customInqOrderCndtn, int fiscalYear)
        {
            DataRow row = this._dataSet.CustomInqResult.NewRow();

            row[this._dataSet.CustomInqResult.FiscalYearColumn.ColumnName] = fiscalYear;
            row[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName] = fiscalYear.ToString() + CT_FISCALYEAR_MEASURE;
            row[this._dataSet.CustomInqResult.EnterpriseCodeColumn.ColumnName] = customInqResultWork.EnterpriseCode;
            row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode;
            row[this._dataSet.CustomInqResult.AddUpSecNameColumn.ColumnName] = customInqOrderCndtn.AddUpSecName;
            row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode;
            row[this._dataSet.CustomInqResult.SalesMoneyColumn.ColumnName] = customInqResultWork.SalesMoney;
            row[this._dataSet.CustomInqResult.SalesRetGoodsPriceColumn.ColumnName] = customInqResultWork.SalesRetGoodsPrice;
            row[this._dataSet.CustomInqResult.DiscountPriceColumn.ColumnName] = customInqResultWork.DiscountPrice;
            row[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName] = customInqResultWork.GrossProfit;
            row[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName] = customInqResultWork.SalesMoney +
                                                                           customInqResultWork.SalesRetGoodsPrice +
                                                                           customInqResultWork.DiscountPrice;

            this._dataSet.CustomInqResult.Rows.Add(row);

        }

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>
        /// �����[�g�����������[�N�N���X�����Ƀf�[�^�Z�b�g�ɍs���쐬
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="customInqOrderCndtnWork">�������ʃ��[�N</param>
        /// <param name="customInqOrderCndtn">���Ӑ�ߔN�x���яƉ�o�����N���X</param>
        /// <param name="fiscalYear">��v�N�x</param>
        /// <param name="index">Index</param>
        /// <param name="retFlg">AddFlag</param>
        /// <remarks>
        /// <br>UpdateNote  : 2010/08/02 chenyd</br>
        /// <br>             �EExcel�A�e�L�X�g�o�͑Ή�</br>
        /// <br>UpdateNote  : 2010/09/09 tianjw</br>
        /// <br>             �Ereadmine #14434�Ή�</br>
        /// </remarks>
        private void AddOutputRowData(DataRow row, CustomInqResultWork customInqResultWork, CustomInqOrderCndtn customInqOrderCndtn, int fiscalYear, int index, ref bool retFlg)
        {
            if (!string.Empty.Equals(customInqResultWork.EnterpriseCode))
                retFlg = true;

            if (index == 0)
            {
                row[this._dataSet.CustomInqResult.FiscalYearColumn.ColumnName] = fiscalYear;
                row[this._dataSet.CustomInqResult.EnterpriseCodeColumn.ColumnName] = customInqOrderCndtn.EnterpriseCode;
                // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
                //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqOrderCndtn.AddUpSecCode;
                //row[this._dataSet.CustomInqResult.AddUpSecNameColumn.ColumnName] = customInqOrderCndtn.AddUpSecName;
                //row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqOrderCndtn.CustomerCode.ToString().PadLeft(8, '0');
                //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = customInqOrderCndtn.CustomerName;
                // ---------------------- DEL 2010/08/02 ---------------------------------<<<<<
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;
                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                row[this._dataSet.CustomInqResult.NetSales8Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 1)
            {
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<

                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                row[this._dataSet.CustomInqResult.NetSales7Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 2)
            {
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                row[this._dataSet.CustomInqResult.NetSales6Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 3)
            {
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                row[this._dataSet.CustomInqResult.NetSales5Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 4)
            {
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                row[this._dataSet.CustomInqResult.NetSales4Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 5)
            {
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                row[this._dataSet.CustomInqResult.NetSales3Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 6)
            {
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                row[this._dataSet.CustomInqResult.NetSales2Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 7)
            {
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                row[this._dataSet.CustomInqResult.NetSales1Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName] = customInqResultWork.GrossProfit;
            }

        }
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<

        #endregion // �f�[�^�Z�b�g���ʃR�s�[

        #region ���������N���X�������[�g�����������[�N�N���X�@�f�[�^�R�s�[

        /// <summary>
        /// ���������N���X�������[�g�����������[�N�N���X�@�f�[�^�R�s�[
        /// </summary>
        /// <param name="customInqOrderCndtn">���Ӑ�ߔN�x���яƉ�o�����N���X</param>
        private void CopyParamater2RemoteParameterWork(CustomInqOrderCndtn customInqOrderCndtn)
        {
            this._customInqOrderCndtnWork.AddUpSecCode = customInqOrderCndtn.AddUpSecCode;
            this._customInqOrderCndtnWork.CustomerCode = customInqOrderCndtn.CustomerCode;
            this._customInqOrderCndtnWork.EnterpriseCode = customInqOrderCndtn.EnterpriseCode;
            this._customInqOrderCndtnWork.St_AddUpYearMonth = TDateTime.LongDateToDateTime(customInqOrderCndtn.St_AddUpYearMonth);
            this._customInqOrderCndtnWork.Ed_AddUpYearMonth = TDateTime.LongDateToDateTime(customInqOrderCndtn.Ed_AddUpYearMonth);
        }

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>
        /// ���������N���X�������[�g�����������[�N�N���X�@�f�[�^�R�s�[
        /// </summary>
        /// <param name="customInqOrderCndtn">���Ӑ�ߔN�x���яƉ�o�����N���X</param>
        /// <returns>�������ʃ��[�N</returns>
        private CustomInqOrderCndtnWork CopyParamaterRemoteParameterWork(CustomInqOrderCndtn customInqOrderCndtn)
        {
            CustomInqOrderCndtnWork customInqOrderCndtnWork = new CustomInqOrderCndtnWork();
            customInqOrderCndtnWork.AddUpSecCode = customInqOrderCndtn.AddUpSecCode;
            customInqOrderCndtnWork.CustomerCode = customInqOrderCndtn.CustomerCode;
            customInqOrderCndtnWork.EnterpriseCode = customInqOrderCndtn.EnterpriseCode;
            customInqOrderCndtnWork.St_AddUpYearMonth = TDateTime.LongDateToDateTime(customInqOrderCndtn.St_AddUpYearMonth);
            customInqOrderCndtnWork.Ed_AddUpYearMonth = TDateTime.LongDateToDateTime(customInqOrderCndtn.Ed_AddUpYearMonth);

            return customInqOrderCndtnWork;
        }
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<

        #endregion // ���������N���X�������[�g�����������[�N�N���X�@�f�[�^�R�s�[

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        #region ��v�N�x�擾(���񌎎����������Z�o)
        /// <summary>
        /// ��v�N�x���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="financialYear">��v�N�x</param>
        /// <param name="startDate">�N�x�J�n��</param>
        /// <param name="endDate">�N�x�I����</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetFinancialYearInfo(string sectionCode, out int financialYear, out int startDate, out int endDate)
        {
            //----------------------------------------------------------------------------------------------
            // ��v�N�x  �F���񌎎����������܂ޔN�x(=���t�擾���i���擾)���Z�b�g
            // �N�x�J�n���F�Ώۂ̉�v�N�x�̊J�n��(=���t�擾���i���擾)���Z�b�g
            // �N�x�I�����F�Ώۂ̉�v�N�x�̏I����(=���t�擾���i���擾)���Z�b�g
            //----------------------------------------------------------------------------------------------

            financialYear = 0;
            startDate = 0;
            endDate = 0;

            DateTime dummyDate;
            DateTime startYearDate;
            DateTime endYearDate;
            DateGetAcs dateGetAcs = DateGetAcs.GetInstance();        // ��v�N�x�擾

            int status;

            // ���Аݒ�}�X�^�̉�v�N�x���擾
            CompanyInf companyInf = dateGetAcs.GetCompanyInf();
            status = -1;
            if (companyInf != null)
            {
                // ���Аݒ�}�X�^�̊���N�����ŔN�x�J�n�^�I�������擾
                DateTime dateTime = TDateTime.LongDateToDateTime(companyInf.CompanyBiginDate);
                dateGetAcs.GetYearMonth(dateTime, out dummyDate, out financialYear, out dummyDate, out dummyDate, out startYearDate, out endYearDate);
                startDate = TDateTime.DateTimeToLongDate(startYearDate);
                endDate = TDateTime.DateTimeToLongDate(endYearDate);
                status = 0;
            }

            return (status);
        }
        #endregion ��v�N�x�擾(���񌎎����������Z�o)

        #region
        /// <summary>
        /// �p�����[�^�`�F�b�N�֐�
        /// </summary>
        /// <param name="customInqOrderCndtn">���Ӑ�ߔN�x���яƉ�o�����N���X</param>
        /// <returns></returns>
        private bool CheckParameter(CustomInqOrderCndtn customInqOrderCndtn)
        {

            // �p�����[�^���K�{�̂��̂��`�F�b�N

            // �N�x�J�n��
            if (customInqOrderCndtn.St_AddUpYearMonth == 0)
            {
                return false;
            }

            // �N�x�I����
            if (customInqOrderCndtn.Ed_AddUpYearMonth == 0)
            {
                return false;
            }

            // ���Ӑ�R�[�h
            if (customInqOrderCndtn.CustomerCode == 0)
            {
                return false;
            }

            // ��ƃR�[�h
            if (String.IsNullOrEmpty(customInqOrderCndtn.EnterpriseCode))
            {
                return false;
            }

            return true;
        }
        #endregion
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
    }
}
