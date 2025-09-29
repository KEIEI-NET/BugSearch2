using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller.Facade;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �^�M�z�ݒ菈�� �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^�M�z�ݒ菈���̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 30418 ���i</br>
    /// <br>Date       : 2008.12.02</br>
    /// <br></br>
    /// </remarks>
    public partial class CustomerCreditAcs
    {

        #region �v���C�x�[�g�ϐ�

        /// <summary>�^�M�z�ݒ菈�������[�g�N���X</summary>
        private ICustCreditDB _custCreditDB = null;

        /// <summary>�^�M�z�ݒ菈�������[�g�����������[�N�N���X</summary>
        private CustCreditCndtnWork _custCreditCndtnWork = null;

        /// <summary>���ʕۑ��p�f�[�^�Z�b�g</summary>
        private CustomerChangeDataSet _dataSet = null;

        /// <summary>���O�ۑ��p�C���^�t�F�[�X�I�u�W�F�N�g</summary>
        OperationHistoryLog _operationLog = null;
        
        #endregion // �v���C�x�[�g�ϐ�

        #region ���O�X�V�p

        /// <summary>���O�p�t�H�[�}�b�g�F�������u���ݔ��|�c���ݒ�v</summary>
        private const string CT_PROCESS_NAME_SETTINGCURRENT = "���ݔ���c���ݒ�";

        /// <summary>���O�p�t�H�[�}�b�g�F�������u�^�M�z�ر�v</summary>
        private const string CT_PROCESS_NAME_CLEARCREDIT = "�^�M�z�ر";

        /// <summary>���O�p�t�H�[�}�b�g�F���ݔ��|�c���ݒ�</summary>
        private const string CT_LOGFORMAT_SETTINGCURRENT = "���Ӑ�:{0}�@���ݔ��|�c��:{1}";

        /// <summary>���O�p�t�H�[�}�b�g�F�^�M�z�N���A������{</summary>
        private const string CT_LOGFORMAT_CLEARCREDIT_0 = "���Ӑ�:{0}�@";

        /// <summary>���O�p�t�H�[�}�b�g�F�^�M�z�N���A���� �^�M�z:0</summary>
        private const string CT_LOGFORMAT_CLEARCREDIT_1 = "�^�M�z:0�@";

        /// <summary>���O�p�t�H�[�}�b�g�F�^�M�z�N���A���� �x���^�M�z:0</summary>
        private const string CT_LOGFORMAT_CLEARCREDIT_2 = "�x���^�M�z:0�@";

        /// <summary>���O�p�t�H�[�}�b�g�F�^�M�z�N���A���� ���ݔ��|�c��:0</summary>
        private const string CT_LOGFORMAT_CLEARCREDIT_3 = "���ݔ��|�c��:0";

        #endregion //���O�X�V�p

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public CustomerCreditAcs()
        {
            // �����[�gDB�擾
            this._custCreditDB = MediationCustCreditDB.GetCustCreditDB();

            // ���������N���X�쐬
            this._custCreditCndtnWork = new CustCreditCndtnWork();

            // �f�[�^�Z�b�g�쐬
            // �R���X�g���N�^���C���X�^���X���쐬�������_�ŁA�f�[�^�Z�b�g���L���ɂȂ�
            this._dataSet = new CustomerChangeDataSet();
        }

        #endregion // �R���X�g���N�^

        #region �p�u���b�N�I�u�W�F�N�g

        /// <summary>
        /// �^�M�z�ݒ菈�����ʈꗗ�f�[�^�Z�b�g
        /// </summary>
        public CustomerChangeDataSet DataSet
        {
            get { return this._dataSet; }
            set { this._dataSet = value; }
        }

        #endregion // �p�u���b�N�I�u�W�F�N�g

        #region �������s

        /// <summary>
        /// �������s
        /// </summary>
        public int Search(CustCreditCndtn custCreditCndtn, out int recordCount)
        {
            // ���������N���X���烊���[�g�����������[�N�N���X�փR�s�[
            CopyParamater2RemoteParameterWork(custCreditCndtn);

            // ���[�J���ϐ���������


            // �������s
            object result;
            int status = this._custCreditDB.Write(out result, (object)this._custCreditCndtnWork);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ����
                recordCount = ((ArrayList)result).Count;

                // �f�[�^�Z�b�g�֓ǂݍ��񂾏����Z�b�g
                if (result != null && result is ArrayList)
                {
                    foreach (CustomerChangeWork resultWork in (ArrayList)result)
                    {
                        // ���ʃe�[�u���֍s���쐬
                        AddRowData(resultWork);
                    }
                }

                // ���O�o��
                OutputLog();
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
        /// �f�[�^�Z�b�g�s�쐬
        /// </summary>
        /// <param name="supplierSlipNo">�ۑ����ꂽ�`�[�ԍ�</param>
        /// <param name="slipRowNo">�s�ԍ�</param>
        private void AddRowData(CustomerChangeWork resultWork)
        {
            // �Ώۂ�[CustomerChangeWork]�e�[�u��
            DataRow row = this._dataSet.CustomerChange.NewRow();

            // �쐬����
            row[this._dataSet.CustomerChange.CreateDateTimeColumn.ColumnName] = resultWork.CreateDateTime;

            // �X�V����
            row[this._dataSet.CustomerChange.UpdateDateTimeColumn.ColumnName] = resultWork.UpdateDateTime;

            // ��ƃR�[�h
            row[this._dataSet.CustomerChange.EnterpriseCodeColumn.ColumnName] = resultWork.EnterpriseCode;

            // GUID
            row[this._dataSet.CustomerChange.FileHeaderGuidColumn.ColumnName] = resultWork.FileHeaderGuid;

            // �X�V�]�ƈ��R�[�h
            row[this._dataSet.CustomerChange.UpdEmployeeCodeColumn.ColumnName] = resultWork.UpdEmployeeCode;

            // �X�V�A�Z���u��ID1
            row[this._dataSet.CustomerChange.UpdAssemblyId1Column.ColumnName] = resultWork.UpdAssemblyId1;

            // �X�V�A�Z���u��ID2
            row[this._dataSet.CustomerChange.UpdAssemblyId2Column.ColumnName] = resultWork.UpdAssemblyId2;

            // �_���폜�敪
            row[this._dataSet.CustomerChange.LogicalDeleteCodeColumn.ColumnName] = resultWork.LogicalDeleteCode;

            // ���Ӑ�R�[�h
            row[this._dataSet.CustomerChange.CustomerCodeColumn.ColumnName] = resultWork.CustomerCode;

            // �^�M�z
            row[this._dataSet.CustomerChange.CreditMoneyColumn.ColumnName] = resultWork.CreditMoney;

            // �x���^�M�z
            row[this._dataSet.CustomerChange.WarningCreditMoneyColumn.ColumnName] = resultWork.WarningCreditMoney;

            // ���ݔ��|�c��
            row[this._dataSet.CustomerChange.PrsntAccRecBalanceColumn.ColumnName] = resultWork.PrsntAccRecBalance;

            this._dataSet.CustomerChange.Rows.Add(row);
        }

        #endregion // �f�[�^�Z�b�g�s�쐬

        #region ���������N���X�������[�g�����������[�N�N���X�@�f�[�^�R�s�[

        /// <summary>
        /// ���������N���X�������[�g�����������[�N�N���X�@�f�[�^�R�s�[
        /// </summary>
        /// <param name="customInqOrderCndtn"></param>
        private void CopyParamater2RemoteParameterWork(CustCreditCndtn custCreditCndtn)
        {
            this._custCreditCndtnWork.EnterpriseCode = custCreditCndtn.EnterpriseCode;
            this._custCreditCndtnWork.CustomerCodes = custCreditCndtn.CustomerCodes;

            this._custCreditCndtnWork.St_CustomerCode = custCreditCndtn.St_CustomerCode;
            this._custCreditCndtnWork.Ed_CustomerCode = custCreditCndtn.Ed_CustomerCode;

            this._custCreditCndtnWork.TotalDay = custCreditCndtn.TotalDay;
            this._custCreditCndtnWork.ProcDiv = custCreditCndtn.ProcDiv;

            this._custCreditCndtnWork.CreditMoneyFlg = custCreditCndtn.CreditMoneyFlg;
            this._custCreditCndtnWork.WarningCrdMnyFrg = custCreditCndtn.WarningCrdMnyFrg;
            this._custCreditCndtnWork.AccRecDiv = custCreditCndtn.AccRecDiv;
        }

        #endregion // ���������N���X�������[�g�����������[�N�N���X�@�f�[�^�R�s�[

        #region ���O�o��

        /// <summary>
        /// ���O�o��
        /// </summary>
        /// <returns></returns>
        private int OutputLog()
        {
            // ���O�ۑ��p�N���X�쐬
            if (this._operationLog == null)
            {
                _operationLog = new OperationHistoryLog();
            }

            foreach (DataRow row in this._dataSet.CustomerChange.Rows)
            {
                string message = string.Empty;
                string logData = string.Empty;

                if (this._custCreditCndtnWork.ProcDiv == 0)
                {
                    message = CT_PROCESS_NAME_SETTINGCURRENT;
                    logData = String.Format(CT_LOGFORMAT_SETTINGCURRENT,
                                ((Int32)row[this._dataSet.CustomerChange.CustomerCodeColumn.ColumnName]).ToString(),
                                ((Int64)row[this._dataSet.CustomerChange.PrsntAccRecBalanceColumn.ColumnName]).ToString());
                }
                else
                {
                    message = CT_PROCESS_NAME_CLEARCREDIT;
                    logData = String.Format(CT_LOGFORMAT_CLEARCREDIT_0,
                                ((Int32)row[this._dataSet.CustomerChange.CustomerCodeColumn.ColumnName]).ToString());
                    if (this._custCreditCndtnWork.CreditMoneyFlg) logData += CT_LOGFORMAT_CLEARCREDIT_1;
                    if (this._custCreditCndtnWork.WarningCrdMnyFrg) logData += CT_LOGFORMAT_CLEARCREDIT_2;
                    if (this._custCreditCndtnWork.AccRecDiv) logData += CT_LOGFORMAT_CLEARCREDIT_3;
                }

                // ���O�o��
                _operationLog.WriteOperationLog(this,
                        LogDataKind.SystemLog,
                        "PMKHN09261U",
                        "�^�M�z�ݒ菈��",
                        string.Empty,
                        0,
                        0,
                        message,
                        logData);
            }

            return 0;
        }

        #endregion // ���O�o��

    }
}
