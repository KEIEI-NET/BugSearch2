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
    /// ���㑬��\�� �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���㑬��\���̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 30418 ���i</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br></br>
    /// </remarks>
    public partial class SalesReportAcs
    {
        #region �v���C�x�[�g�ϐ�

        /// <summary>���㑬��\�������[�g�N���X</summary>
        private ISalesReportOrderWorkDB _salesReportOrderWorkDB = null;

        /// <summary>���㑬��\�������[�g�����������[�N�N���X</summary>
        private SalesReportOrderCndtnWork _salesReportOrderCndtnWork = null;

        /// <summary>���㑬��\���ꗗ�f�[�^�Z�b�g</summary>
        private SalesReportDataSet _dataSet = null;

        #endregion // �v���C�x�[�g�ϐ�

        #region ���v�s�Z�o�p

        /// <summary>�����㍇�v</summary>
        private Int64 _salesTotalTaxExc_Total = 0;

        /// <summary>����ڕW���z���v</summary>
        private Int64 _salesTargetMoney_Total = 0;

        /// <summary>�e�����v</summary>
        private Int64 _grossMargin_Total = 0;

        /// <summary>�e���ڕW���v</summary>
        private Int64 _salesTargetProfit_Total = 0;


        #endregion // ���v�s�Z�o�p

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SalesReportAcs()
        {
            // �����[�gDB�擾
            _salesReportOrderWorkDB = MediationSalesReportOrderWorkDB.GetSalesReportOrderWorkDB();

            // ���������N���X�쐬
            _salesReportOrderCndtnWork = new SalesReportOrderCndtnWork();

            // �f�[�^�Z�b�g�쐬
            this._dataSet = new SalesReportDataSet();

            // �R���X�g���N�^���C���X�^���X���쐬�������_�ŁA�f�[�^�Z�b�g���L���ɂȂ�

        }

        #endregion // �R���X�g���N�^

        #region �p�u���b�N�I�u�W�F�N�g

        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�ꗗ�f�[�^�Z�b�g
        /// </summary>
        public SalesReportDataSet DataSet
        {
            get { return this._dataSet; }
            set { this._dataSet = value; }
        }

        #endregion // �p�u���b�N�I�u�W�F�N�g

        #region �������s

        /// <summary>
        /// �������s
        /// </summary>
        public int Search(SalesReportOrderCndtn salesReportOrderCndtn, out int recordCount)
        {
            // ���������N���X���烊���[�g�����������[�N�N���X�փR�s�[
            CopyParamater2RemoteParameterWork(salesReportOrderCndtn);

            // ���[�J���ϐ���������
            this._salesTotalTaxExc_Total = 0;
            this._grossMargin_Total = 0;
            this._salesTargetMoney_Total = 0;
            this._salesTargetProfit_Total = 0;

            // �������s
            object result;
            int status = _salesReportOrderWorkDB.Search(out result, (object)this._salesReportOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ����
                recordCount = ((ArrayList)result).Count;

                // �f�[�^�Z�b�g�֓ǂݍ��񂾏����Z�b�g
                if (result != null && result is ArrayList)
                {
                    int rowNo = 1;
                    foreach (SalesReportResultWork resultWork in (ArrayList)result)
                    {
                        AddRowData(resultWork, salesReportOrderCndtn, rowNo);
                        rowNo++;
                    }

                    // ���v�s���쐬
                    DataRow row = this._dataSet.SalesReportResult.NewRow();

                    // �����_�ȉ����������邽�߂�Double�^�Ōv�Z
                    Double dParent = 0;
                    Double dChild = 0;

                    row[this._dataSet.SalesReportResult.RowNoColumn.ColumnName] = rowNo;
                    row[this._dataSet.SalesReportResult.EnterpriseCodeColumn.ColumnName] = string.Empty;
                    row[this._dataSet.SalesReportResult.SectionCodeColumn.ColumnName] = string.Empty;
                    row[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName] = "���v";
                    row[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName] = this._salesTotalTaxExc_Total;
                    if (this._salesTargetMoney_Total > 0)
                    {
                        row[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName] = this._salesTargetMoney_Total;
                        dParent = Double.Parse(this._salesTotalTaxExc_Total.ToString());
                        dChild = Double.Parse(this._salesTargetMoney_Total.ToString());
                        row[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName] = dParent / dChild * 100;
                    }
                    row[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName] = this._grossMargin_Total;
                    if (this._salesTargetProfit_Total > 0)
                    {
                        row[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName] = this._salesTargetProfit_Total;
                        dParent = Double.Parse(this._grossMargin_Total.ToString());
                        dChild = Double.Parse(this._salesTargetProfit_Total.ToString());
                        row[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName] = dParent / dChild * 100;
                    }
                    row[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName] = string.Empty;
                    this._dataSet.SalesReportResult.Rows.Add(row);
                }
            }
            else
            {
                recordCount = 0;
                return status;
            }

            return status;
        }

        #endregion // �������s

        #region �f�[�^�Z�b�g�s�쐬

        /// <summary>
        /// �����[�g�����������[�N�N���X�����Ƀf�[�^�Z�b�g�ɍs���쐬
        /// </summary>
        /// <param name="customInqOrderCndtnWork">�������ʃ��[�N</param>
        private void AddRowData(SalesReportResultWork salesReportResultWork, SalesReportOrderCndtn salesReportOrderCndtn, int rowNo)
        {
            DataRow row = this._dataSet.SalesReportResult.NewRow();

            row[this._dataSet.SalesReportResult.RowNoColumn.ColumnName] = rowNo;
            row[this._dataSet.SalesReportResult.EnterpriseCodeColumn.ColumnName] = salesReportResultWork.EnterpriseCode;
            row[this._dataSet.SalesReportResult.SectionCodeColumn.ColumnName] = salesReportResultWork.SectionCode;
            row[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName] = salesReportResultWork.SectionGuideSnm;

            // ������
            row[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName] = salesReportResultWork.SalesTotalTaxExc;
            _salesTotalTaxExc_Total += salesReportResultWork.SalesTotalTaxExc;

            // ����ڕW, �B����(��̎��͋�)
            if (salesReportResultWork.SalesTargetMoney > 0)
            {
                row[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName] = salesReportResultWork.SalesTargetMoney;
                _salesTargetMoney_Total += salesReportResultWork.SalesTargetMoney;
                row[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName] = salesReportResultWork.AchievementRateNet;
            }
            
            // �e��
            row[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName] = salesReportResultWork.GrossMargin;
            _grossMargin_Total += salesReportResultWork.GrossMargin;

            // �e���ڕW, �B����(��̎��͋�)
            if (salesReportResultWork.SalesTargetProfit > 0)
            {
                row[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName] = salesReportResultWork.SalesTargetProfit;
                _salesTargetProfit_Total += salesReportResultWork.SalesTargetProfit;
                row[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName] = salesReportResultWork.AchievementRateGross;
            }

            // �ғ���
            row[this._dataSet.SalesReportResult.OperationDayColumn.ColumnName] = salesReportResultWork.OperationDay;
            row[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName] = salesReportResultWork.OperationDay.ToString() + "��";

            this._dataSet.SalesReportResult.Rows.Add(row);

        }

        #endregion // �f�[�^�Z�b�g�s�쐬

        #region ���������N���X�������[�g�����������[�N�N���X�@�f�[�^�R�s�[

        /// <summary>
        /// ���������N���X�������[�g�����������[�N�N���X�@�f�[�^�R�s�[
        /// </summary>
        /// <param name="customInqOrderCndtn"></param>
        private void CopyParamater2RemoteParameterWork(SalesReportOrderCndtn salesReportOrderCndtn)
        {
            this._salesReportOrderCndtnWork.SectionCode = salesReportOrderCndtn.SectionCode;
            this._salesReportOrderCndtnWork.EnterpriseCode = salesReportOrderCndtn.EnterpriseCode;
            this._salesReportOrderCndtnWork.St_SalesDate = TDateTime.LongDateToDateTime(salesReportOrderCndtn.St_SalesDate);
            this._salesReportOrderCndtnWork.Ed_SalesDate = TDateTime.LongDateToDateTime(salesReportOrderCndtn.Ed_SalesDate);
        }

        #endregion // ���������N���X�������[�g�����������[�N�N���X�@�f�[�^�R�s�[
    }
}
