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

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �d���`�F�b�N���� �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���`�F�b�N�����̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 30418 ���i</br>
    /// <br>Date       : 2008.11.25</br>
    /// <br>Update Note: 2009/03/24 30414 �E ��QID:12789�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2010/09/14 30517 �Ė� �x��</br>
    /// <br>             Mantis.16053 �]�ŕ����ɂ�����łƎd�����z�̕\�����@��ύX</br>
    /// <br>Update Note: 2010/10/21 �����</br>
    /// <br>             MANTIS�F0016368�A0016384 ���z�A����ŕ\�����e�̕ύX</br>
    /// <br>Update Note: 2012/08/30 ������</br>
    /// <br>             Redmine#31879�̑Ή� UOE�d���f�[�^�̋敪���擾</br>
    /// <br>Update Note: 2012/10/09 �� ��</br>
    /// <br>             Redmine#31879�̑Ή� �ԓ`�敪���擾</br>
    /// </remarks>
    public partial class SupplierCheckAcs
    {
        #region �v���C�x�[�g�ϐ�

        /// <summary>�d���`�F�b�N���������[�g�N���X</summary>
        private ISupplierCheckOrderWorkDB _supplierCheckOrderWorkDB = null;

        /// <summary>�d���`�F�b�N���������[�g�����������[�N�N���X</summary>
        private SupplierCheckOrderCndtnWork _supplierCheckOrderCndtnWork = null;

        /// <summary>�d���`�F�b�N�������ʃN���X</summary>
        private SupplierCheckResult _supplierCheckResult = null;

        /// <summary>�d���`�F�b�N�����ꗗ�f�[�^�Z�b�g</summary>
        private SupplierCheckDataSet _dataSet = null;

        /// <summary>����`�[�`�F�b�N�p�d��SEQ�ԍ�</summary>
        private Int32 _currentSupplierSlipNo = 0;

        /// <summary>����`�[�����`�F�b�N�p�X�e�[�^�X 0:���`�F�b�N, 1:�`�F�b�N, 2:�s�N��</summary>
        private Int32 _dailyCheckStatus = 0;

        /// <summary>����`�[�����`�F�b�N�p�X�e�[�^�X 0:���`�F�b�N, 1:�`�F�b�N, 2:�s�N��</summary>
        private Int32 _calcCheckStatus = 0;

        /// <summary>����`�[���ō����z�݌v</summary>
        private Int64 _totalStockPriceTaxInc = 0;

        /// <summary>����`�[�����z�݌v</summary>
        private Int64 _totalStockPriceTaxExc = 0;

        /// <summary>����`�[������ŗ݌v</summary>
        private Int64 _totalStockPriceConsTax = 0;

        /// <summary>�X�V����</summary>
        private DateTime _updateDateTime;

        /// <summary>�X�V�E���R�[�h</summary>
        private string _updateEmployeeCd = string.Empty;

        /// <summary>UI�A�Z���u��ID</summary>
        private string _UIAssemblyId = string.Empty;

        #endregion // �v���C�x�[�g�ϐ�

        #region ���v�\���p

        /// <summary>���z</summary>
        private Int64 _tAmount = 0;

        /// <summary>�����</summary>
        private Int64 _tAmountConsumeTax = 0;

        /// <summary>�ō����z</summary>
        private Int64 _tAmountTaxInc = 0;

        /// <summary>���ō����z</summary>
        private Int64 _tAmountTaxIncAll = 0;

        /// <summary>�ԕi���z</summary>
        private Int64 _tReturn = 0;

        /// <summary>�ԕi�����</summary>
        private Int64 _tReturnConsumeTax = 0;

        /// <summary>�ԕi���z</summary>
        private Int64 _tReturnTaxInc = 0;

        /// <summary>�`�[����</summary>
        private Int32 _tSlipCount = 0;

        /// <summary>���א�</summary>
        private Int32 _tDetailCount = 0;


        /// <summary>��ʗp���v�i�����v�j</summary>
        private Int64 _dDisplaySum = 0;

        /// <summary>��ʗp���v�i�`�F�b�N�t��/�����j</summary>
        private Int64 _dCheckSum_Daily = 0;

        /// <summary>��ʗp���v�i�`�F�b�N�t��/�����j</summary>
        private Int64 _dCheckSum_Calc = 0;

        /// <summary>��ʗp���v�i�s���j</summary>
        private Int64 _dLackSum = 0;

        #endregion // ���v�\���p

        #region ����S�̐ݒ�֘A

        /// <summary>DCKHN09212A)����S�̐ݒ�</summary>
        private SalesTtlStAcs _salesTtlStAcs;

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = string.Empty;

        /// <summary>�e���`�F�b�N�����l</summary>
        private double _grsProfitCheckLower = 0;

        /// <summary>�e���`�F�b�N�K���l</summary>
        private double _grsProfitCheckBest = 0;

        /// <summary>�e���`�F�b�N����l</summary>
        private double _grsProfitCheckUpper = 0;

        /// <summary>�e���`�F�b�N�����}�[�N</summary>
        private string _grsProfitChkLowSign = string.Empty;

        /// <summary>�e���`�F�b�N�K���}�[�N</summary>
        private string _grsProfitChkBestSign = string.Empty;

        /// <summary>�e���`�F�b�N����}�[�N</summary>
        private string _grsProfitChkUprSign = string.Empty;

        /// <summary>�e���`�F�b�N���E�}�[�N</summary>
        private string _grsProfitChkMaxSign = string.Empty;

        #endregion // ����S�̐ݒ�֘A

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SupplierCheckAcs()
        {
            // �����[�gDB�擾
            _supplierCheckOrderWorkDB = MediationSupplierCheckOrderWorkDB.GetSupplierCheckOrderWorkDB();

            // ���������N���X�쐬
            _supplierCheckOrderCndtnWork = new SupplierCheckOrderCndtnWork();

            // �f�[�^�Z�b�g�쐬
            this._dataSet = new SupplierCheckDataSet();

            // �������ʃf�[�^�N���X���쐬
            // �`�[�f�[�^�쐬�Ɏg�p
            this._supplierCheckResult = new SupplierCheckResult();

            // �e���}�[�N�f�[�^���擾
            this._salesTtlStAcs = new SalesTtlStAcs();

            // �R���X�g���N�^���C���X�^���X���쐬�������_�ŁA�f�[�^�Z�b�g���L���ɂȂ�

        }

        #endregion // �R���X�g���N�^

        #region �p�u���b�N�I�u�W�F�N�g

        /// <summary>
        /// �d���`�F�b�N�����ꗗ�f�[�^�Z�b�g
        /// </summary>
        public SupplierCheckDataSet DataSet
        {
            get { return this._dataSet; }
            set { this._dataSet = value; }
        }

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode; }
            set { this._enterpriseCode = value; }
        }

        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        public string SectionCode
        {
            get { return this._sectionCode; }
            set { this._sectionCode = value; }
        }

        /// <summary>
        /// �X�V�҃R�[�h
        /// </summary>
        public string UpdateEmployeeCd
        {
            get { return this._updateEmployeeCd; }
            set { this._updateEmployeeCd = value; }
        }

        /// <summary>
        /// UI�A�Z���u��ID
        /// </summary>
        public string UIAssemblyId
        {
            get { return this._UIAssemblyId; }
            set { this._UIAssemblyId = value; }
        }

        #endregion // �p�u���b�N�I�u�W�F�N�g

        #region �e���}�[�N�擾

        /// <summary>
        /// �e���}�[�N�擾
        /// </summary>
        public void GetProfitMark()
        {
            ArrayList retSalesTtlSt;
            int status = this._salesTtlStAcs.SearchAll(out retSalesTtlSt, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (SalesTtlSt salesTtlSt in retSalesTtlSt)
                {
                    // �����_�R�[�h�Ɠ������̂��s�b�N�A�b�v
                    if (salesTtlSt.SectionCode.Trim() == this._sectionCode.Trim())
                    {
                        // �������l
                        this._grsProfitCheckLower = salesTtlSt.GrsProfitCheckLower;     // �����l
                        this._grsProfitCheckBest = salesTtlSt.GrsProfitCheckBest;       // �K���l
                        this._grsProfitCheckUpper = salesTtlSt.GrsProfitCheckUpper;     // ����l

                        // �}�[�N
                        this._grsProfitChkLowSign = salesTtlSt.GrsProfitChkLowSign;     // �@�@�@�`�����l
                        this._grsProfitChkBestSign = salesTtlSt.GrsProfitChkBestSign;   // �����l�`�K���l
                        this._grsProfitChkUprSign = salesTtlSt.GrsProfitChkUprSign;     // �K���l�`����l
                        this._grsProfitChkMaxSign = salesTtlSt.GrsProfitChkMaxSign;     // ����l�`
                    }
                }
            }
        }

        #endregion // �e���}�[�N�擾

        #region �������s

        /// <summary>
        /// �������s
        /// </summary>
        public int Search(SupplierCheckOrderCndtn supplierCheckOrderCndtn, out int recordCount)
        {
            // ���������N���X���烊���[�g�����������[�N�N���X�փR�s�[
            CopyParamater2RemoteParameterWork(supplierCheckOrderCndtn);

            // ���[�J���ϐ���������
            if (this._supplierCheckResult == null)
            {
                this._supplierCheckResult = new SupplierCheckResult();
            }

            this._currentSupplierSlipNo = 0;
            this._tAmount = 0;
            this._tAmountConsumeTax = 0;
            this._tAmountTaxInc = 0;
            this._tAmountTaxIncAll = 0;
            this._tReturn = 0;
            this._tReturnConsumeTax = 0;
            this._tReturnTaxInc = 0;
            this._dDisplaySum = 0;
            this._dCheckSum_Daily = 0;
            this._dCheckSum_Calc = 0;
            this._dLackSum = 0;
            // 2008.12.10 add start [9030]
            this._tSlipCount = 0;
            this._tDetailCount = 0;
            // 2008.12.10 add end [9030]

            // �������s
            object result;
            int status = this._supplierCheckOrderWorkDB.Search(out result, (object)this._supplierCheckOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ����
                recordCount = ((ArrayList)result).Count;

                // �f�[�^�Z�b�g�֓ǂݍ��񂾏����Z�b�g
                if (result != null && result is ArrayList)
                {
                    int detailRowNo = 1;
                    int slipRowNo = 1;
                    foreach (SupplierCheckResultWork resultWork in (ArrayList)result)
                    {
                        // 2010/09/14 Add >>>
                        // �]�ŕ����ɂ�����ł̌v�Z
                        if (resultWork.SuppCTaxLayCd >= 2 || resultWork.SuppCTaxLayCd == 0)
                        {
                            resultWork.StockPriceConsTax = 0;
                            resultWork.StockPriceTaxInc = resultWork.StockPriceTaxExc;
                            if (resultWork.SuppCTaxLayCd >= 2)
                            {
                                resultWork.StockTtlPriceConsTax = 0;
                                resultWork.StockTtlPricTaxInc = resultWork.StockTtlPricTaxExc;
                            }

                            // --- ADD 2010/10/21 ---------->>>>>
                            if (resultWork.SuppCTaxLayCd == 9)
                            {
                                resultWork.StockTtlPricTaxInc = resultWork.StockTotalPrice;
                                resultWork.StockTtlPricTaxExc = resultWork.StockSubttlPrice;
                            }
                            // --- ADD 2010/10/21 ----------<<<<<
                        }
                        // 2010/09/14 Add <<<
                        // �`�[�ԍ���ۑ�
                        if (this._currentSupplierSlipNo == 0)   // ���̕����͍ŏ��̈�x�̂�
                        {
                            this._currentSupplierSlipNo = resultWork.SupplierSlipNo;

                            // ���ׂɍs���쐬�i�d����/���͓�/�d��SEQ�ԍ�/�`�[�ԍ��F�\���j
                            AddDetailRowData(resultWork, supplierCheckOrderCndtn, detailRowNo, true);

                            // ���ʃN���X�ɃR�s�[���ĕۑ����Ă���
                            CopyResultwork2Result(resultWork);

                            // �݌v���Z�b�g
                            if (resultWork.SuppCTaxLayCd == 1)
                            {
                                //this._totalStockPriceTaxInc = resultWork.StockPriceTaxInc;
                                //this._totalStockPriceTaxExc = resultWork.StockPriceTaxExc;
                                this._totalStockPriceConsTax = resultWork.StockPriceConsTax;
                            }
                            else
                            {
                                // ���גP�ʈȊO�̏ꍇ�͗݌v���g�p
                                this._totalStockPriceConsTax = resultWork.StockTtlPriceConsTax;
                            }
                            this._totalStockPriceTaxInc = resultWork.StockTtlPricTaxInc;
                            this._totalStockPriceTaxExc = resultWork.StockTtlPricTaxExc;


                            // �`�F�b�N�{�b�N�X�̃X�e�[�^�X��ۑ�
                            this._dailyCheckStatus = resultWork.StockCheckDivDaily;
                            this._calcCheckStatus = resultWork.StockCheckDivCAddUp;

                            if (this._dailyCheckStatus == 1) // �����`�F�b�N
                            {
                                this._dCheckSum_Daily = resultWork.StockPriceTaxExc;
                                this._dCheckSum_Calc = 0;
                            }

                            if (this._calcCheckStatus == 1) // �����`�F�b�N
                            {
                                this._dCheckSum_Daily = 0;
                                this._dCheckSum_Calc = resultWork.StockPriceTaxExc;
                            }

                            // --- ADD 2010/10/21 ---------->>>>>
                            // �d��
                            if (resultWork.SupplierSlipCd == 10)
                            {
                                this._tAmountConsumeTax += resultWork.StockTtlPriceConsTax;    // ����Ŋz
                            }
                            else
                            {
                                this._tReturnConsumeTax += resultWork.StockTtlPriceConsTax;    // ����Ŋz
                            }
                            // --- ADD 2010/10/21 ----------<<<<<
                        }
                        else
                        {
                            // ����`�[���ǂ������`�F�b�N�A�����ł���Η݌v�ɉ��Z
                            // ����`�[�`�F�b�N�͎d��SEQ�ԍ��̂�(11/25 ����L)
                            if (this._currentSupplierSlipNo == resultWork.SupplierSlipNo)
                            {
                                // �d�������œ]�ŕ����R�[�h�����גP�ʂ̂Ƃ��̂ݏ���ł����Z����
                                if (resultWork.SuppCTaxLayCd == 1)
                                {
                                    //this._totalStockPriceTaxInc += resultWork.StockPriceTaxInc;
                                    //this._totalStockPriceTaxExc += resultWork.StockPriceTaxExc;
                                    this._totalStockPriceConsTax += resultWork.StockPriceConsTax;
                                }
                                // ���גP�ʈȊO�̏ꍇ�͗݌v���g�p(���Z�b�g���Ɏ擾�ς�)

                                // ���ׂɍs���쐬�i�d����/���͓�/�d��SEQ�ԍ�/�`�[�ԍ��F��\���j
                                AddDetailRowData(resultWork, supplierCheckOrderCndtn, detailRowNo, false);

                                // �`�F�b�N����Ă���f�[�^������΁A�`�F�b�N���v�����Z
                                if (resultWork.StockCheckDivDaily == 1) // �����`�F�b�N
                                {
                                    this._dCheckSum_Daily += resultWork.StockPriceTaxExc;
                                }
                                if (resultWork.StockCheckDivCAddUp == 1) // �����`�F�b�N
                                {
                                    this._dCheckSum_Calc += resultWork.StockPriceTaxExc;
                                }

                                // �`�F�b�N�{�b�N�X�̃X�e�[�^�X���v�Z
                                // �O�̃f�[�^�ƈ�ł��قȂ�Εs�N�����A��x�s�N��������Έȍ~�̓`�F�b�N�s�v
                                if (this._dailyCheckStatus < 2 && this._dailyCheckStatus != resultWork.StockCheckDivDaily)
                                {
                                    this._dailyCheckStatus = 2;
                                }

                                if (this._calcCheckStatus < 2 && this._calcCheckStatus != resultWork.StockCheckDivCAddUp)
                                {
                                    this._calcCheckStatus = 2;
                                }
                            }
                            else
                            {
                                // ���ׂɍs���쐬�i�d����/���͓�/�d��SEQ�ԍ�/�`�[�ԍ��F�\���j
                                AddDetailRowData(resultWork, supplierCheckOrderCndtn, detailRowNo, true);

                                // �`�F�b�N����Ă���f�[�^������΁A�`�F�b�N���v�����Z
                                if (resultWork.StockCheckDivDaily == 1) // �����`�F�b�N
                                {
                                    this._dCheckSum_Daily += resultWork.StockPriceTaxExc;
                                }
                                if (resultWork.StockCheckDivCAddUp == 1) // �����`�F�b�N
                                {
                                    this._dCheckSum_Calc += resultWork.StockPriceTaxExc;
                                }

                                // ����łȂ���Γ`�[�e�[�u���Ƀf�[�^���쐬���A�݌v�����Z�b�g
                                AddSlipRowData(this._currentSupplierSlipNo, slipRowNo);
                                slipRowNo++;
                                this._tSlipCount++;      // �`�[���� + 1

                                // ���ʃN���X�ɃR�s�[���ĕۑ����Ă���
                                CopyResultwork2Result(resultWork);

                                // �݌v���Z�b�g
                                if (resultWork.SuppCTaxLayCd == 1)
                                {
                                    //this._totalStockPriceTaxInc = resultWork.StockPriceTaxInc;
                                    //this._totalStockPriceTaxExc = resultWork.StockPriceTaxExc;
                                    this._totalStockPriceConsTax = resultWork.StockPriceConsTax;
                                }
                                else
                                {
                                    // ���גP�ʈȊO�̏ꍇ�͗݌v���g�p
                                    this._totalStockPriceConsTax = resultWork.StockTtlPriceConsTax;
                                }
                                this._totalStockPriceTaxInc = resultWork.StockTtlPricTaxInc;
                                this._totalStockPriceTaxExc = resultWork.StockTtlPricTaxExc;


                                this._dailyCheckStatus = resultWork.StockCheckDivDaily;
                                this._calcCheckStatus = resultWork.StockCheckDivCAddUp;

                                // �ۑ����Ă���ԍ����㏑��
                                this._currentSupplierSlipNo = resultWork.SupplierSlipNo;

                                // --- ADD 2010/10/21 ---------->>>>>
                                // �d��
                                if (resultWork.SupplierSlipCd == 10)
                                {
                                    this._tAmountConsumeTax += resultWork.StockTtlPriceConsTax;    // ����Ŋz
                                }
                                else
                                {
                                    this._tReturnConsumeTax += resultWork.StockTtlPriceConsTax;    // ����Ŋz
                                }
                                // --- ADD 2010/10/21 ----------<<<<<                                
                            }
                        }

                        // ���ׂ̍Ō�̍s�ł͕K���`�[���쐬
                        if (detailRowNo == recordCount)
                        {
                            AddSlipRowData(this._currentSupplierSlipNo, slipRowNo);
                            slipRowNo++;
                            this._tSlipCount++;      // �`�[���� + 1
                        }

                        // ���v�\�����v�Z
                        // �d��
                        if (resultWork.SupplierSlipCd == 10)
                        {
                            this._tAmount += resultWork.StockPriceTaxExc;               // ���z
                            //this._tAmountConsumeTax += resultWork.StockPriceConsTax;    // ����Ŋz  // DEL 2010/10/21
                            this._tAmountTaxInc += resultWork.StockPriceTaxInc;         // �ō����z
                        }
                        else // �ԕi
                        {
                            this._tReturn += resultWork.StockPriceTaxExc;               // ���z
                            //this._tReturnConsumeTax += resultWork.StockPriceConsTax;    // ����Ŋz  // DEL 2010/10/21
                            this._tReturnTaxInc += resultWork.StockPriceTaxInc;         // �ō����z
                        }

                        // ���v�`�[�̓J�E���g���Ȃ�
                        if (resultWork.StockGoodsCd != 6)
                        {
                            this._tDetailCount++;        // ���א� + 1
                        }

                        detailRowNo++;
                    }

                    // --- ADD 2010/10/21 ---------->>>>>
                    this._tAmountTaxInc = this._tAmount + this._tAmountConsumeTax;
                    this._tReturnTaxInc = this._tReturn + this._tReturnConsumeTax;
                    // --- ADD 2010/10/21 ----------<<<<<

                    // ���v�e�[�u���փf�[�^�s���쐬
                    this._tAmountTaxIncAll = this._tAmountTaxInc + this._tReturnTaxInc;
                    AddTotalRowData();

                    // ��ʗp���v�e�[�u���֍s���쐬
                    AddSumRowData(supplierCheckOrderCndtn.ProcDiv);
                }
            }
            else
            {
                recordCount = 0;
                return status;
            }

            //object parameter = null;
            //status = this._supplierCheckOrderWorkDB.Write(ref parameter);

            // ������
            this._currentSupplierSlipNo = 0;
            this._supplierCheckResult = null;
            return status;
        }

        #endregion // �������s

        #region �f�[�^�Z�b�g�s�쐬

        #region �`�[�e�[�u���s�쐬

        /// <summary>
        /// �����[�g�����������[�N�N���X�����ɓ`�[�e�[�u���ɍs���쐬
        /// </summary>
        /// <param name="supplierSlipNo">�ۑ����ꂽ�`�[�ԍ�</param>
        /// <param name="slipRowNo">�s�ԍ�</param>
        private void AddSlipRowData(int supplierSlipNo, int slipRowNo)
        {
            // �Ώۂ�[SlipList]�e�[�u��
            DataRow row = this._dataSet.SlipList.NewRow();

            // this._supplierCheckResult�ɕۑ����ꂽ��s�ڂ̖��ׂ̃f�[�^���g�p���ăf�[�^���쐬

            // �d���`�F�b�N�i�����j
            if (this._dailyCheckStatus == 0) // ���`�F�b�N
            {
                row[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName] = false;
                row[this._dataSet.SlipList.CheckBoxDailyExColumn.ColumnName] = false;
            }
            else // 1�y��2�̓`�F�b�N
            {
                row[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName] = true;
                row[this._dataSet.SlipList.CheckBoxDailyExColumn.ColumnName] = true;
            }

            // �d���`�F�b�N�X�e�[�^�X�i�����j 0:���`�F�b�N 1:�`�F�b�N 2:�s�N��
            row[this._dataSet.SlipList.CheckBoxDailyStatusColumn.ColumnName] = this._dailyCheckStatus;
            row[this._dataSet.SlipList.CheckBoxDailyStatusExColumn.ColumnName] = this._dailyCheckStatus;

            // �d���`�F�b�N�i�����j
            if (this._calcCheckStatus == 0) // ���`�F�b�N
            {
                row[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName] = false;
                row[this._dataSet.SlipList.CheckBoxCalcExColumn.ColumnName] = false;
            }
            else // 1�y��2�̓`�F�b�N
            {
                row[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName] = true;
                row[this._dataSet.SlipList.CheckBoxCalcExColumn.ColumnName] = true;
            }

            // �d���`�F�b�N�X�e�[�^�X�i�����j 0:���`�F�b�N 1:�`�F�b�N 2:�s�N��
            row[this._dataSet.SlipList.CheckBoxCalcStatusColumn.ColumnName] = this._calcCheckStatus;
            row[this._dataSet.SlipList.CheckBoxCalcStatusExColumn.ColumnName] = this._calcCheckStatus;


            // �s�ԍ�
            row[this._dataSet.SlipList.RowNoColumn.ColumnName] = slipRowNo;

            // �d����
            if (this._supplierCheckResult.StockDate != DateTime.MinValue)
            {
                row[this._dataSet.SlipList.StockDateColumn.ColumnName] = this._supplierCheckResult.StockDate;
                row[this._dataSet.SlipList.StockDateStringColumn.ColumnName] = this._supplierCheckResult.StockDate.ToString("yyyy/MM/dd");
            }

            // ���͓�
            if (this._supplierCheckResult.InputDay != DateTime.MinValue)
            {
                row[this._dataSet.SlipList.InputDayColumn.ColumnName] = this._supplierCheckResult.InputDay;
                row[this._dataSet.SlipList.InputDayStringColumn.ColumnName] = this._supplierCheckResult.InputDay.ToString("yyyy/MM/dd");
            }

            // �d��SEQ�ԍ� (Not Null)
            row[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName] = this._supplierCheckResult.SupplierSlipNo;
            //row[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName] = supplierSlipNo;

            // �`�[�ԍ�
            if (!String.IsNullOrEmpty(this._supplierCheckResult.PartySaleSlipNum))
            {
                // --- CHG 2009/03/24 ��QID:12789�Ή�------------------------------------------------------>>>>>
                //row[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName] = this._supplierCheckResult.PartySaleSlipNum.PadLeft(8, '0'); // 2008.12.10 modify [8996]
                row[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName] = this._supplierCheckResult.PartySaleSlipNum;
                // --- CHG 2009/03/24 ��QID:12789�Ή�------------------------------------------------------<<<<<
            }

            // �ō����z(���ח݌v�z)�}�C�i�X�̒l������
            //if (this._totalStockPriceTaxInc > 0)
            //{
            // --- UPD 2010/10/21 ---------->>>>>
            //row[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName] = this._totalStockPriceTaxInc;
            row[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName] = this._totalStockPriceTaxExc + this._totalStockPriceConsTax;
            // --- UPD 2010/10/21 ----------<<<<<
            //}

            // ���z(���ח݌v�z)�}�C�i�X�̒l������
            //if (this._totalStockPriceTaxExc > 0)
            //{
            row[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName] = this._totalStockPriceTaxExc;
            //}

            // �����(���ח݌v�z)�}�C�i�X�̒l������
            //if (this._totalStockPriceConsTax > 0)
            //{
            row[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName] = this._totalStockPriceConsTax;
            //}

            // �����
            if (this._supplierCheckResult.SalesDate != DateTime.MinValue)
            {
                row[this._dataSet.SlipList.SalesDateColumn.ColumnName] = this._supplierCheckResult.SalesDate;
                row[this._dataSet.SlipList.SalesDateStringColumn.ColumnName] = this._supplierCheckResult.SalesDate.ToString("yyyy/MM/dd");
            }
            else
            {
                row[this._dataSet.SlipList.SalesDateStringColumn.ColumnName] = string.Empty;
            }

            // ����`�[�ԍ� (Not Null)
            row[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName] = this._supplierCheckResult.SalesSlipNum;
            
            // ���Ӑ�R�[�h
            if (this._supplierCheckResult.CustomerCode > 0)
            {
                row[this._dataSet.SlipList.CustomerCodeColumn.ColumnName] = this._supplierCheckResult.CustomerCode.ToString().PadLeft(8, '0');
            }

            // ���Ӑ旪��
            if (!String.IsNullOrEmpty(this._supplierCheckResult.CustomerSnm))
            {
                row[this._dataSet.SlipList.CustomerSnmColumn.ColumnName] = this._supplierCheckResult.CustomerSnm;
            }

            // ������z(�}�C�i�X�̒l������
            //if (this._supplierCheckResult.SalesMoneyTaxExc > 0)
            //{
                row[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName] = this._supplierCheckResult.SalesMoneyTaxExc;
            //}

            // ����S���Җ�
            if (!String.IsNullOrEmpty(this._supplierCheckResult.SalesEmployeeNm))
            {
                row[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName] = this._supplierCheckResult.SalesEmployeeNm;
            }

            // ����󒍎Җ�
            if (!String.IsNullOrEmpty(this._supplierCheckResult.FrontEmployeeNm))
            {
                row[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName] = this._supplierCheckResult.FrontEmployeeNm;
            }

            // ���㔭�s�Җ�
            if (!String.IsNullOrEmpty(this._supplierCheckResult.SalesInputName))
            {
                row[this._dataSet.SlipList.SalesInputNameColumn.ColumnName] = this._supplierCheckResult.SalesInputName;
            }

            // ���}�[�N1
            if (!String.IsNullOrEmpty(this._supplierCheckResult.UoeRemark1))
            {
                row[this._dataSet.SlipList.UoeRemark1Column.ColumnName] = this._supplierCheckResult.UoeRemark1;
            }

            // ���}�[�N2
            if (!String.IsNullOrEmpty(this._supplierCheckResult.UoeRemark2))
            {
                row[this._dataSet.SlipList.UoeRemark2Column.ColumnName] = this._supplierCheckResult.UoeRemark2;
            }

            // �d����R�[�h
            if (this._supplierCheckResult.SupplierCd > 0)
            {
                row[this._dataSet.SlipList.SupplierCdColumn.ColumnName] = this._supplierCheckResult.SupplierCd.ToString().PadLeft(6, '0');
            }

            // �d���旪��
            if (!String.IsNullOrEmpty(this._supplierCheckResult.SupplierSnm))
            {
                row[this._dataSet.SlipList.SupplierSnmColumn.ColumnName] = this._supplierCheckResult.SupplierSnm;
            }

            // �ȉ��͔w�i�F�ύX�̂��߂ɕK�v
            row[this._dataSet.DetailList.SupplierSlipCdColumn.ColumnName] = this._supplierCheckResult.SupplierSlipCd;          // �d���`��
            row[this._dataSet.SlipList.WayToOrderColumn.ColumnName] = this._supplierCheckResult.WayToOrder; //ADD BY ������ on 2012/08/30 for Redmine#31879
            row[this._dataSet.SlipList.DebitNoteDivColumn.ColumnName] = this._supplierCheckResult.DebitNoteDiv; //ADD BY �� �� on 2012/10/09 for Redmine#31879

            this._dataSet.SlipList.Rows.Add(row);
        }

        #endregion // �`�[�e�[�u���s�쐬

        #region ���׃e�[�u���s�쐬

        /// <summary>
        /// �����[�g�����������[�N�N���X�����ɖ��׃e�[�u���ɍs���쐬
        /// </summary>
        /// <param name="resultWork">�������ʃ��[�N</param>
        /// <param name="supplierCheckOrderCndtn">��������</param>
        /// <param name="detailRowNo">�s�ԍ�</param>
        /// <param name="firstDetailRow">�ŏ��̖��׍s�i�ڍׂ�\������j���ǂ���</param>
        private void AddDetailRowData(SupplierCheckResultWork resultWork, SupplierCheckOrderCndtn supplierCheckOrderCndtn, int detailRowNo, bool firstDetailRow)
        {
            // �v�Z�p
            Double salesMoney = 0;
            Double stockCount = 0;
            Double profit = 0;
            Double profitRate = 0;

            // �Ώۂ�[DetailList]�e�[�u��
            DataRow row = this._dataSet.DetailList.NewRow();


            // �X�V�p

            // �쐬��
            if (resultWork.CreateDateTime != DateTime.MinValue)
            {
                row[this._dataSet.DetailList.CreateDateTimeColumn.ColumnName] = resultWork.CreateDateTime;
            }

            // �X�V��
            if (resultWork.UpdateDateTime != DateTime.MinValue)
            {
                row[this._dataSet.DetailList.UpdateDateTimeColumn.ColumnName] = resultWork.UpdateDateTime;
            }

            // ��ƃR�[�h
            if (!String.IsNullOrEmpty(resultWork.EnterpriseCode))
            {
                row[this._dataSet.DetailList.EnterpriseCodeColumn.ColumnName] = resultWork.EnterpriseCode;
            }

            // GUID
            if (resultWork.FileHeaderGuid != Guid.Empty)
            {
                row[this._dataSet.DetailList.FileHeaderGuidColumn.ColumnName] = resultWork.FileHeaderGuid;
            }



            // �d���`�F�b�N�i�����j
            if (resultWork.StockCheckDivDaily == 0) // ���`�F�b�N
            {
                row[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName] = false;
                row[this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName] = false;
            }
            else
            {
                row[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName] = true;
                row[this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName] = true;
            }

            // �d���`�F�b�N�i�����j
            if (resultWork.StockCheckDivCAddUp == 0) // ���`�F�b�N
            {
                row[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName] = false;
                row[this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName] = false;
            }
            else
            {
                row[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName] = true;
                row[this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName] = true;
            }

            // �s�ԍ�
            row[this._dataSet.DetailList.RowNoColumn.ColumnName] = detailRowNo;

            // ----�ȉ�����`�[�ԍ��܂ł́A�ŏ��̖��׍s�ȊO�͔�\��

            // �d����
            if (firstDetailRow && resultWork.StockDate != DateTime.MinValue)
            {
                row[this._dataSet.DetailList.StockDateColumn.ColumnName] = resultWork.StockDate;
                row[this._dataSet.DetailList.StockDateStringColumn.ColumnName] = resultWork.StockDate.ToString("yyyy/MM/dd");
            }

            // ���͓�
            if (firstDetailRow && resultWork.InputDay != DateTime.MinValue)
            {
                row[this._dataSet.DetailList.InputDayColumn.ColumnName] = resultWork.InputDay;
                row[this._dataSet.DetailList.InputDayStringColumn.ColumnName] = resultWork.InputDay.ToString("yyyy/MM/dd");
            }

            // �d��SEQ�ԍ� (Not Null)
            if (firstDetailRow) // �\���p��ɂ͍ŏ��̍s�̂�
            {
                // --- CHG 2009/03/24 ��QID:12789�Ή�------------------------------------------------------>>>>>
                row[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName] = resultWork.SupplierSlipNo;
                // --- CHG 2009/03/24 ��QID:12789�Ή�------------------------------------------------------<<<<<
            }

            // �d��SEQ�ԍ�(�����p) (Not Null)
            row[this._dataSet.DetailList.SupplierSlipNoKeyColumn.ColumnName] = resultWork.SupplierSlipNo;

            // �`�[�ԍ�
            if (firstDetailRow && !String.IsNullOrEmpty(resultWork.PartySaleSlipNum))
            {
                // --- CHG 2009/03/24 ��QID:12789�Ή�------------------------------------------------------>>>>>
                //row[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName] = resultWork.PartySaleSlipNum.PadLeft(8, '0'); // 2008.12.10 modify [8996]
                row[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName] = resultWork.PartySaleSlipNum;
                // --- CHG 2009/03/24 ��QID:12789�Ή�------------------------------------------------------<<<<<
            }

            // ----�����܂ŁA�ŏ��̖��׍s�ȊO�͔�\��

            // �ō����z(���ח݌v�z)
            //if (resultWork.StockPriceTaxInc > 0)
            //{
                row[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName] = resultWork.StockPriceTaxInc;
            //}

            //// ���z(���ח݌v�z)
            //if (resultWork.StockPriceTaxExc > 0)
            //{
                row[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName] = resultWork.StockPriceTaxExc;
            //}

            //// �����(���ח݌v�z)
            //if (resultWork.StockPriceConsTax > 0)
            //{
                row[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName] = resultWork.StockPriceConsTax;
            //}

            // �i��
            if (!String.IsNullOrEmpty(resultWork.GoodsNo))
            {
                row[this._dataSet.DetailList.GoodsNoColumn.ColumnName] = resultWork.GoodsNo;
            }

            // ����
            //if (resultWork.StockCount > 0)
            //{
                row[this._dataSet.DetailList.StockCountColumn.ColumnName] = resultWork.StockCount;
                stockCount = Double.Parse(resultWork.StockCount.ToString());
            //}

            // BL����
            if (resultWork.BLGoodsCode > 0)
            {
                row[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName] = resultWork.BLGoodsCode;
            }

            // �i��
            if (!String.IsNullOrEmpty(resultWork.GoodsName))
            {
                row[this._dataSet.DetailList.GoodsNameColumn.ColumnName] = resultWork.GoodsName;
            }

            // �����P��
            if (resultWork.StockUnitPriceFl > 0)
            {
                row[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName] = resultWork.StockUnitPriceFl;
            }

            // �W�����i
            if (resultWork.ListPriceTaxExcFl > 0)
            {
                row[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName] = resultWork.ListPriceTaxExcFl;
            }

            //// �����P��
            //if (resultWork.SalesUnPrcTaxExcFl > 0)
            //{
                row[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName] = resultWork.SalesUnPrcTaxExcFl;
            //}

            // ������z
            //if (resultWork.SalesMoneyTaxExc > 0)
            //{
                row[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName] = resultWork.SalesMoneyTaxExc;
                salesMoney = Double.Parse(resultWork.SalesMoneyTaxExc.ToString());
            //}

            //// �e��
            //if (stockCount + salesMoney + resultWork.StockUnitPriceFl > 0)
            //{
                profit = salesMoney - (stockCount * resultWork.StockUnitPriceFl);
                row[this._dataSet.DetailList.ProfitColumn.ColumnName] = profit;
            //}

            // �e����
            if (profit != 0  && salesMoney != 0)
            {
                profitRate = profit / salesMoney * 100;
                row[this._dataSet.DetailList.ProfitRateColumn.ColumnName] = profitRate;

                // �e���}�[�N���v�Z
                row[this._dataSet.DetailList.ProfitMarkColumn.ColumnName] = this.GetProfitMark(profitRate);
            }

            // ***�ȉ��͍X�V�ɕK�v�Ȓl (�S��Not Null)
            if (resultWork.SalesDate != DateTime.MinValue)
            {
                row[this._dataSet.DetailList.SalesDateColumn.ColumnName] = resultWork.SalesDate;    // �����
                row[this._dataSet.DetailList.SalesDateStringColumn.ColumnName] = resultWork.SalesDate.ToString("yyyy/MM/dd");    // �����
            }
            else
            {
                row[this._dataSet.DetailList.SalesDateStringColumn.ColumnName] = string.Empty;
            }
            row[this._dataSet.DetailList.LogicalDeleteCodeColumn.ColumnName] = resultWork.LogicalDeleteCode;    // �폜�敪
            row[this._dataSet.DetailList.SupplierSlipCdColumn.ColumnName] = resultWork.SupplierSlipCd;          // �`�[�敪
            row[this._dataSet.DetailList.SupplierFormalColumn.ColumnName] = resultWork.SupplierFormal;          // �d���`��
            row[this._dataSet.DetailList.StockSlipDtlNumColumn.ColumnName] = resultWork.StockSlipDtlNum;        // �d�����גʔ�
            row[this._dataSet.DetailList.WayToOrderColumn.ColumnName] = resultWork.WayToOrder; //ADD BY ������ on 2012/08/30 for Redmine#31879
            row[this._dataSet.DetailList.DebitNoteDivColumn.ColumnName] = resultWork.DebitNoteDiv; //ADD BY �� �� on 2012/10/09 for Redmine#31879

            this._dataSet.DetailList.Rows.Add(row);
        }

        #endregion // ���׃e�[�u���s�쐬

        #region ���v�e�[�u���s�쐬

        /// <summary>
        /// ���v�e�[�u���s�쐬
        /// </summary>
        private void AddTotalRowData()
        {
            DataRow totalRow = this._dataSet.TotalList.NewRow();

            totalRow[this._dataSet.TotalList.AmountColumn.ColumnName] = this._tAmount;
            totalRow[this._dataSet.TotalList.AmountConsumeTaxColumn.ColumnName] = this._tAmountConsumeTax;
            totalRow[this._dataSet.TotalList.AmountTaxIncColumn.ColumnName] = this._tAmountTaxInc;
            totalRow[this._dataSet.TotalList.AmountTaxIncAllColumn.ColumnName] = this._tAmountTaxIncAll;
            totalRow[this._dataSet.TotalList.ReturnColumn.ColumnName] = this._tReturn;
            totalRow[this._dataSet.TotalList.ReturnConsumeTaxColumn.ColumnName] = this._tReturnConsumeTax;
            totalRow[this._dataSet.TotalList.ReturnTaxIncColumn.ColumnName] = this._tReturnTaxInc;
            totalRow[this._dataSet.TotalList.SlipCountColumn.ColumnName] = this._tSlipCount;
            totalRow[this._dataSet.TotalList.DetailCountColumn.ColumnName] = this._tDetailCount;

            this._dataSet.TotalList.Rows.Add(totalRow);
        }

        #endregion // ���v�e�[�u���s�쐬

        #region ��ʗp���v�e�[�u���s�쐬

        private void AddSumRowData(int procDiv)
        {
            DataRow sumRow = this._dataSet.Sum.NewRow();

            sumRow[this._dataSet.Sum.DisplaySumColumn.ColumnName] = this._tAmountTaxIncAll;
            if (procDiv == 0)
            {
                sumRow[this._dataSet.Sum.CheckSumColumn.ColumnName] = this._dCheckSum_Daily;
                sumRow[this._dataSet.Sum.LackSumColumn.ColumnName] = this._tAmountTaxIncAll - this._dCheckSum_Daily;
            }
            else
            {
                sumRow[this._dataSet.Sum.CheckSumColumn.ColumnName] = _dCheckSum_Calc;
                sumRow[this._dataSet.Sum.LackSumColumn.ColumnName] = this._tAmountTaxIncAll - this._dCheckSum_Calc;
            }

            this._dataSet.Sum.Rows.Add(sumRow);
        }

        #endregion // ��ʗp���v�e�[�u���s�쐬

        #region �e���}�[�N�v�Z

        /// <summary>
        /// �e���}�[�N�v�Z
        /// </summary>
        /// <param name="profileRate">�e����(%)</param>
        /// <returns>�e���}�[�N</returns>
        private string GetProfitMark(Double profileRate)
        {
            // �e���}�[�N�͑S�Ă������l����
            if (profileRate < this._grsProfitCheckLower)
            {
                return this._grsProfitChkLowSign;
            }
            else if (this._grsProfitCheckLower <= profileRate && profileRate < this._grsProfitCheckBest)
            {
                return this._grsProfitChkBestSign;
            }
            else if (this._grsProfitCheckBest <= profileRate && profileRate < this._grsProfitCheckUpper)
            {
                return this._grsProfitChkUprSign;
            }
            else if (this._grsProfitCheckUpper <= profileRate)
            {
                return this._grsProfitChkMaxSign;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion // �e���}�[�N�v�Z

        #endregion // �f�[�^�Z�b�g�s�쐬

        #region �f�[�^�Z�b�g����X�V�f�[�^�쐬

        /// <summary>
        /// �f�[�^�Z�b�g����X�V�f�[�^�쐬
        /// </summary>
        /// <param name="checkTargetColumn">�X�V�Ώۗ�(0:����/1:����)</param>
        /// <param name="count">�X�V������Ԃ�</param>
        /// <returns>�X�V�p�̃f�[�^</returns>
        private object GetAllUpdateData(int checkTargetColumn, out int count)
        {
            // ���N�쐬
            StockCheckDtlWork updateData = null;
            ArrayList arrayList = new ArrayList();
            count = 0;

            switch (checkTargetColumn)
            {
                #region ����
                case 0:
                    {
                        // ���׃f�[�^�̑S�Ă̍s�����؂��A�X�V�f�[�^���쐬
                        foreach (DataRow row in this._dataSet.DetailList.Rows)
                        {
                            // �`�F�b�N�{�b�N�X�̏����l�����ݒl�ƕς���Ă����ꍇ�͍X�V�Ώ�
                            if ((bool)row[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName] != (bool)row[this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName])
                            {
                                updateData = new StockCheckDtlWork();

                                updateData.CreateDateTime = (DateTime)row[this._dataSet.DetailList.CreateDateTimeColumn.ColumnName];
                                if (DBNull.Value.Equals(row[this._dataSet.DetailList.UpdateDateTimeColumn.ColumnName]))
                                {
                                    updateData.UpdateDateTime = DateTime.MinValue;
                                }
                                else
                                {
                                    updateData.UpdateDateTime = (DateTime)row[this._dataSet.DetailList.UpdateDateTimeColumn.ColumnName];
                                }
                                updateData.FileHeaderGuid = (Guid)row[this._dataSet.DetailList.FileHeaderGuidColumn.ColumnName];
                                updateData.EnterpriseCode = (string)row[this._dataSet.DetailList.EnterpriseCodeColumn.ColumnName];

                                updateData.LogicalDeleteCode = (Int32)row[this._dataSet.DetailList.LogicalDeleteCodeColumn.ColumnName];
                                updateData.SupplierFormal = (Int32)row[this._dataSet.DetailList.SupplierFormalColumn.ColumnName];
                                updateData.StockSlipDtlNum = (Int64)row[this._dataSet.DetailList.StockSlipDtlNumColumn.ColumnName];

                                // �d���`�F�b�N�敪(����)�͌��݂̒l��n��
                                if ((bool)row[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName])
                                {
                                    updateData.StockCheckDivDaily = 1;
                                }
                                else
                                {
                                    updateData.StockCheckDivDaily = 0;
                                }

                                // �d���`�F�b�N�敪(����)�͎擾���̒l��n��
                                if ((bool)row[this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName])
                                {
                                    updateData.StockCheckDivCAddUp = 1;
                                }
                                else
                                {
                                    updateData.StockCheckDivCAddUp = 0;
                                }

                                count++;
                                arrayList.Add((object)updateData);
                            }
                        }
                        break;
                    }
                #endregion // ����

                #region ����
                case 1:
                    {
                        // ���׃f�[�^�̑S�Ă̍s�����؂��A�X�V�f�[�^���쐬
                        foreach (DataRow row in this._dataSet.DetailList.Rows)
                        {
                            // �`�F�b�N�{�b�N�X�̏����l�����ݒl�ƕς���Ă����ꍇ�͍X�V�Ώ�
                            if ((bool)row[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName] != (bool)row[this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName])
                            {
                                updateData = new StockCheckDtlWork();

                                updateData.CreateDateTime = (DateTime)row[this._dataSet.DetailList.CreateDateTimeColumn.ColumnName];
                                if (DBNull.Value.Equals(row[this._dataSet.DetailList.UpdateDateTimeColumn.ColumnName]))
                                {
                                    updateData.UpdateDateTime = DateTime.MinValue;
                                }
                                else
                                {
                                    updateData.UpdateDateTime = (DateTime)row[this._dataSet.DetailList.UpdateDateTimeColumn.ColumnName];
                                }
                                updateData.FileHeaderGuid = (Guid)row[this._dataSet.DetailList.FileHeaderGuidColumn.ColumnName];
                                updateData.EnterpriseCode = (string)row[this._dataSet.DetailList.EnterpriseCodeColumn.ColumnName];

                                updateData.LogicalDeleteCode = (Int32)row[this._dataSet.DetailList.LogicalDeleteCodeColumn.ColumnName];
                                updateData.SupplierFormal = (Int32)row[this._dataSet.DetailList.SupplierFormalColumn.ColumnName];
                                updateData.StockSlipDtlNum = (Int64)row[this._dataSet.DetailList.StockSlipDtlNumColumn.ColumnName];

                                // �d���`�F�b�N�敪(����)�͌��݂̒l��n��
                                if ((bool)row[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName])
                                {
                                    updateData.StockCheckDivCAddUp = 1;
                                }
                                else
                                {
                                    updateData.StockCheckDivCAddUp = 0;
                                }

                                // �d���`�F�b�N�敪(����)�͎擾���̒l��n��
                                if ((bool)row[this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName])
                                {
                                    updateData.StockCheckDivDaily = 1;
                                }
                                else
                                {
                                    updateData.StockCheckDivDaily = 0;
                                }
                                updateData.EnterpriseCode = this.EnterpriseCode;

                                count++;
                                arrayList.Add((object)updateData);
                            }
                        }
                        break;
                    }
                #endregion // ����
            }

            // �z����I�u�W�F�N�g�Ŗ߂�
            return (object)arrayList;
        }

        #endregion // �f�[�^�Z�b�g����X�V�f�[�^�쐬

        #region �X�V����

        /// <summary>
        /// �X�V����
        /// </summary>
        /// <param name="checkTargetColumn">�X�V�Ώۗ�(0:����/1:����)</param>
        /// <param name="count">�X�V��</param>
        /// <returns></returns>
        public int Update(int checkTargetColumn, out int count)
        {
            // �X�V���t���擾�i�ꊇ�X�V�ōX�V���t�����킹�邽�߁j
            this._updateDateTime = DateTime.Now;

            // �f�[�^�Z�b�g����X�V���ׂ��f�[�^���쐬
            object parameter = GetAllUpdateData(checkTargetColumn, out count);

            // �X�V���s
            int status = this._supplierCheckOrderWorkDB.Write(ref parameter);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���펞�ɁA�`�F�b�N�{�b�N�X�̒l��Ex�J�����ɃR�s�[����
                //foreach (DataRow row in this._dataSet.DetailList.Rows)
                //{
                //    row[this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName] = row[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName];
                //    row[this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName] = row[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName];
                //}
            }

            // �X�e�[�^�X�𒼐ږ߂�
            return status;
        }

        #endregion // �X�V����

        #region ���������N���X�������[�g�����������[�N�N���X�@�f�[�^�R�s�[

        /// <summary>
        /// ���������N���X�������[�g�����������[�N�N���X�@�f�[�^�R�s�[
        /// </summary>
        /// <param name="customInqOrderCndtn"></param>
        private void CopyParamater2RemoteParameterWork(SupplierCheckOrderCndtn supplierCheckOrderCndtn)
        {
            this._supplierCheckOrderCndtnWork.EnterpriseCode = supplierCheckOrderCndtn.EnterpriseCode;
            this._supplierCheckOrderCndtnWork.SectionCode = supplierCheckOrderCndtn.SectionCode;
            this._supplierCheckOrderCndtnWork.SupplierCd = supplierCheckOrderCndtn.SupplierCd;
            this._supplierCheckOrderCndtnWork.ProcDiv = supplierCheckOrderCndtn.ProcDiv;
            this._supplierCheckOrderCndtnWork.SlipDiv = supplierCheckOrderCndtn.SlipDiv;
            this._supplierCheckOrderCndtnWork.CheckDiv = supplierCheckOrderCndtn.CheckDiv;
            this._supplierCheckOrderCndtnWork.St_StockDate = supplierCheckOrderCndtn.St_StockDate;
            this._supplierCheckOrderCndtnWork.Ed_StockDate = supplierCheckOrderCndtn.Ed_StockDate;
            this._supplierCheckOrderCndtnWork.St_InputDay = supplierCheckOrderCndtn.St_InputDay;
            this._supplierCheckOrderCndtnWork.Ed_InputDay = supplierCheckOrderCndtn.Ed_InputDay;
            this._supplierCheckOrderCndtnWork.St_SupplierSlipNo = supplierCheckOrderCndtn.St_SupplierSlipNo;
            this._supplierCheckOrderCndtnWork.Ed_SupplierSlipNo = supplierCheckOrderCndtn.Ed_SupplierSlipNo;
            this._supplierCheckOrderCndtnWork.St_PartySaleSlipNum = supplierCheckOrderCndtn.St_PartySaleSlipNum;
            this._supplierCheckOrderCndtnWork.Ed_PartySaleSlipNum = supplierCheckOrderCndtn.Ed_PartySaleSlipNum;

        }

        #endregion // ���������N���X�������[�g�����������[�N�N���X�@�f�[�^�R�s�[

        #region �������ʃ��[�N�N���X���������ʃN���X�@�f�[�^�R�s�[

        /// <summary>
        /// �������ʃ��[�N�N���X���������ʃN���X�@�f�[�^�R�s�[
        /// </summary>
        /// <param name="supplierCheckResultWork"></param>
        private void CopyResultwork2Result(SupplierCheckResultWork supplierCheckResultWork)
        {
            if (this._supplierCheckResult == null) return;

            this._supplierCheckResult.BfStockUnitPriceFl = supplierCheckResultWork.BfStockUnitPriceFl;
            this._supplierCheckResult.BLGoodsCode = supplierCheckResultWork.BLGoodsCode;
            this._supplierCheckResult.CreateDateTime = supplierCheckResultWork.CreateDateTime;
            this._supplierCheckResult.CustomerCode = supplierCheckResultWork.CustomerCode;
            this._supplierCheckResult.CustomerSnm = supplierCheckResultWork.CustomerSnm;
            this._supplierCheckResult.EnterpriseCode = supplierCheckResultWork.EnterpriseCode;
            this._supplierCheckResult.FileHeaderGuid = supplierCheckResultWork.FileHeaderGuid;
            this._supplierCheckResult.FrontEmployeeNm = supplierCheckResultWork.FrontEmployeeNm;
            this._supplierCheckResult.GoodsName = supplierCheckResultWork.GoodsName;
            this._supplierCheckResult.GoodsNo = supplierCheckResultWork.GoodsNo;
            this._supplierCheckResult.InputDay = supplierCheckResultWork.InputDay;
            this._supplierCheckResult.ListPriceTaxExcFl = supplierCheckResultWork.ListPriceTaxExcFl;
            this._supplierCheckResult.LogicalDeleteCode = supplierCheckResultWork.LogicalDeleteCode;
            this._supplierCheckResult.PartySaleSlipNum = supplierCheckResultWork.PartySaleSlipNum;
            this._supplierCheckResult.SalesDate = supplierCheckResultWork.SalesDate;
            this._supplierCheckResult.SalesEmployeeNm = supplierCheckResultWork.SalesEmployeeNm;
            this._supplierCheckResult.SalesInputName = supplierCheckResultWork.SalesInputName;
            this._supplierCheckResult.SalesMoneyTaxExc = supplierCheckResultWork.SalesMoneyTaxExc;
            this._supplierCheckResult.SalesSlipNum = supplierCheckResultWork.SalesSlipNum;
            this._supplierCheckResult.SalesUnPrcTaxExcFl = supplierCheckResultWork.SalesUnPrcTaxExcFl;
            this._supplierCheckResult.SectionCode = supplierCheckResultWork.SectionCode;
            this._supplierCheckResult.StockCheckDivCAddUp = supplierCheckResultWork.StockCheckDivCAddUp;
            this._supplierCheckResult.StockCheckDivDaily = supplierCheckResultWork.StockCheckDivDaily;
            this._supplierCheckResult.StockCount = supplierCheckResultWork.StockCount;
            this._supplierCheckResult.StockDate = supplierCheckResultWork.StockDate;
            this._supplierCheckResult.StockGoodsCd = supplierCheckResultWork.StockGoodsCd;
            this._supplierCheckResult.StockPriceConsTax = supplierCheckResultWork.StockPriceConsTax;
            this._supplierCheckResult.StockPriceTaxExc = supplierCheckResultWork.StockPriceTaxExc;
            this._supplierCheckResult.StockPriceTaxInc = supplierCheckResultWork.StockPriceTaxInc;
            this._supplierCheckResult.StockSlipDtlNum = supplierCheckResultWork.StockSlipDtlNum;
            this._supplierCheckResult.StockUnitPriceFl = supplierCheckResultWork.StockUnitPriceFl;
            this._supplierCheckResult.SupplierCd = supplierCheckResultWork.SupplierCd;
            this._supplierCheckResult.SupplierFormal = supplierCheckResultWork.SupplierFormal;
            this._supplierCheckResult.SupplierSlipCd = supplierCheckResultWork.SupplierSlipCd;
            this._supplierCheckResult.SupplierSlipNo = supplierCheckResultWork.SupplierSlipNo;
            this._supplierCheckResult.SupplierSnm = supplierCheckResultWork.SupplierSnm;
            this._supplierCheckResult.UoeRemark1 = supplierCheckResultWork.UoeRemark1;
            this._supplierCheckResult.UoeRemark2 = supplierCheckResultWork.UoeRemark2;
            this._supplierCheckResult.UpdAssemblyId1 = supplierCheckResultWork.UpdAssemblyId1;
            this._supplierCheckResult.UpdAssemblyId2 = supplierCheckResultWork.UpdAssemblyId2;
            this._supplierCheckResult.UpdateDateTime = supplierCheckResultWork.UpdateDateTime;
            this._supplierCheckResult.UpdEmployeeCode = supplierCheckResultWork.UpdEmployeeCode;
            this._supplierCheckResult.WayToOrder = supplierCheckResultWork.WayToOrder;  //ADD BY ������ on 2012/08/30 for Redmine#31879
            this._supplierCheckResult.DebitNoteDiv = supplierCheckResultWork.DebitNoteDiv;  //ADD BY �� �� on 2012/10/09 for Redmine#31879

        }
        #endregion // �������ʃ��[�N�N���X���������ʃN���X�@�f�[�^�R�s�[
    }
}
