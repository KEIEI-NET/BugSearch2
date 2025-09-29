//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ڕW�����ݒ�
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/06/18  �C�����e : PVCS#203 ���т̏ꍇ�A�W�v���ʂƋ��z��3�{�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/07/07  �C�����e : PVCS#261 ���ʂ̒[���������@�s�� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00  �쐬�S�� : yangyi
// �C �� ��  2012/11/12   �C�����e : 2012/12/12�z�M�� 
//                        redmine#33218  No.1633 �ڕW�����ݒ� �ڕW�ݒ�͕s�������� 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using System.Collections.Generic;
using System.IO;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ڕW�����ݒ菈��READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ڕW�����ݒ菈��READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    [Serializable]
    public class ObjAutoSetControlDB : RemoteDB, IObjAutoSetControlDB
    {

        #region �� Const Memebers ��
        private const Int32 kubun_Section = 1;
        private const Int32 kubun_SubSection = 2;
        private const Int32 kubun_Customer = 3;
        private const Int32 kubun_Tantosya = 4;
        private const Int32 kubun_ReceOrd = 5;
        private const Int32 kubun_Publisher = 6;
        private const Int32 kubun_District = 7;
        private const Int32 kubun_TypeBusiness = 8;
        private const Int32 kubun_SalesCode = 9;
        private const Int32 kubun_ComDivision = 10;
        #endregion

        # region �� Constructor ��
        /// <summary>
        /// �ڕW�����ݒ菈��READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڕW�����ݒ菈��READ�̎��f�[�^������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public ObjAutoSetControlDB()
        {
            this._empSalesTargetDB = new EmpSalesTargetDB();
            this._custSalesTargetDB = new CustSalesTargetDB();
            this._gcdSalesTargetDB = new GcdSalesTargetDB();
        }
        #endregion

        # region �� Private Members ��
        EmpSalesTargetDB _empSalesTargetDB = null;
        CustSalesTargetDB _custSalesTargetDB = null;
        GcdSalesTargetDB _gcdSalesTargetDB = null;
        #endregion

        # region �� �ڕW�����ݒ�X�V���� ��
        /// <summary>
        /// �ڕW�����ݒ�X�V����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="pastStartMonthDate">�O���K�p�J�n��</param>
        /// <param name="pastEndMonthDate">�O���K�p�I����</param>
        /// <param name="pastYearMonth">�O�������X�V�N��</param>
        /// <param name="nowStartMonthDate">����K�p�J�n��</param>
        /// <param name="nowEndMonthDate">����K�p�I����</param>
        /// <param name="nowYearMonth">���񌎎��X�V�N��</param>
        /// <param name="yearMonth">���ݏ����N��</param>
        /// <param name="objAutoSetWork">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ڕW�����ݒ�X�V����</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.05.20</br>
        public int ObjAutoSetProc(string enterpriseCode, string baseCode, List<DateTime> pastStartMonthDate, List<DateTime> pastEndMonthDate, List<DateTime> pastYearMonth,
            List<DateTime> nowStartMonthDate, List<DateTime> nowEndMonthDate, List<DateTime> nowYearMonth, DateTime yearMonth, ObjAutoSetWork objAutoSetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;

            DateTime startMonthDt = new DateTime();
            DateTime endMonthDt = new DateTime();
            Int32 startMonthInt;
            Int32 endMonthInt;

            // �ߋ�*����
            Int32 pastMonth = objAutoSetWork.Past;


            // �Ώۊ��͑O���̏ꍇ�A
            if (objAutoSetWork.ObjPeriodDrp == 0)
            {
                Int32 pastYearMonthCount = pastYearMonth.Count;
                if (null != pastYearMonth && pastYearMonthCount > 0)
                {
                    startMonthDt = pastYearMonth[0];
                    endMonthDt = pastYearMonth[pastYearMonthCount - 1];

                    startMonthInt = this.DateTimeToInt(startMonthDt);
                    endMonthInt = this.DateTimeToInt(endMonthDt);
                }
                else
                {
                    return status;
                }
            }
            // �Ώۊ��͍����̏ꍇ�A
            else
            {
                //Int32 nowYearMonthCount = nowYearMonth.Count;
                //if (null != nowYearMonth && nowYearMonthCount > 0)
                //{
                //    startMonthDt = nowYearMonth[0];
                //    endMonthDt = nowYearMonth[nowYearMonthCount - 1];

                //    startMonthInt = this.DateTimeToInt(startMonthDt);
                //    endMonthInt = this.DateTimeToInt(endMonthDt);
                //}
                //else
                //{
                //    return status;
                //}
                startMonthInt = this.DateTimeToInt(yearMonth.AddMonths(-pastMonth));
                endMonthInt = this.DateTimeToInt(yearMonth.AddMonths(-1));
            }

            // �O����v�N�x���A������v�N�x�擾
            Hashtable fiscalYear = new Hashtable();
            Hashtable fiscalStartMonth = new Hashtable();
            Hashtable fiscalEndMonth = new Hashtable();
            string fiscalYearKey = string.Empty;
            string fiscalYearValue = string.Empty;
            for ( int i = 0; i < pastYearMonth.Count; i++ )
            {
                fiscalYearKey = Convert.ToString(this.DateTimeToInt(pastYearMonth[i]));
                fiscalYearValue = Convert.ToString(this.DateTimeToInt(nowYearMonth[i]));
                fiscalYear.Add(fiscalYearKey, fiscalYearValue);
                fiscalStartMonth.Add(fiscalYearKey, nowStartMonthDate[i]);
                fiscalEndMonth.Add(fiscalYearKey, nowEndMonthDate[i]);
            }

            // UP��
            Int32 salesTarget = objAutoSetWork.SalesTarget;
            Int32 amountTarget = objAutoSetWork.AmountTarget;
            Int32 groMarginTarget = objAutoSetWork.GroMarginTarget;


            // �P��
            Int32 unit = objAutoSetWork.UnitDrp;
            // �[������
            Int32 fractionProc = objAutoSetWork.FractionProcDrp;
            // �Ώۊ��敪
            Int32 periodKun = objAutoSetWork.ObjPeriodDrp;


            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();



#if DEBUG
                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif


                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);


                // �g�����U�N�V����
                sqlCommand.Transaction = sqlTransaction;
                // ���_DRP�I���̏ꍇ�A
                // ���_���s���̏ꍇ�A
                if (objAutoSetWork.SecDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Ώۋ��z���u���сv�̏ꍇ
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // ���㌎���W�v�f�[�^�𒊏o����
                        status = GetSectionMTtList(baseCode, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // �Ώۋ��z���u�ڕW�v�̏ꍇ
                    else
                    {
                        // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̃f�[�^�𒊏o����
                        status = GetSectionEmpList(baseCode, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);

                            // ���_�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�폜����B
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���_�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach(ArrayList empList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���_�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���_�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // ���Ӑ�̖ڕW����Đݒ�̏ꍇ�A
                else if (objAutoSetWork.SecDrp == 2)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Đݒ�̏ꍇ
                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̓��Ӑ�f�[�^�𒊏o����
                    status = GetMoreSecCustomerEmpList(baseCode, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Customer, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // �S���҂̖ڕW����Đݒ�̏ꍇ�A
                else if (objAutoSetWork.SecDrp == 3)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Đݒ�̏ꍇ
                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̓��Ӑ�f�[�^�𒊏o����
                    status = GetMoreSecTantosyaEmpList(baseCode, 10, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    }

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        sqlTransaction.Rollback();
                        return status;
                    }
                }
                // �󒍎҂̖ڕW����Đݒ�̏ꍇ�A
                else if (objAutoSetWork.SecDrp == 4)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Đݒ�̏ꍇ
                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̎󒍎҃f�[�^�𒊏o����
                    status = GetMoreSecTantosyaEmpList(baseCode, 20, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �󒍎ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �󒍎ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �󒍎ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �󒍎ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    }

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        sqlTransaction.Rollback();
                        return status;
                    }
                }
                // ���s�҂̖ڕW����Đݒ�̏ꍇ�A
                else if (objAutoSetWork.SecDrp == 5)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Đݒ�̏ꍇ�A
                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̎󒍎҃f�[�^�𒊏o����
                    status = GetMoreSecTantosyaEmpList(baseCode, 30, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���s�ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���s�ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���s�ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���s�ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // �n��̖ڕW����Đݒ�̏ꍇ�A
                else if (objAutoSetWork.SecDrp == 6)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Đݒ�̏ꍇ
                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̎󒍎҃f�[�^�𒊏o����
                    status = GetMoreDistrictCusList(baseCode, 21, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �n��ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �n��ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �n��ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �n��ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // �Ǝ�̖ڕW����Đݒ�̏ꍇ�A
                else if (objAutoSetWork.SecDrp == 7)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Đݒ�̏ꍇ�A
                    // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�̎󒍎҃f�[�^�𒊏o����
                    status = GetMoreTypeBusinessCusList(baseCode, 33, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �Ǝ�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �Ǝ�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �Ǝ�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �Ǝ�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // �̔��敪�̖ڕW����Đݒ�̏ꍇ�A
                else if (objAutoSetWork.SecDrp == 8)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Đݒ�̏ꍇ�A
                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̔̔��敪�f�[�^�𒊏o����
                    status = GetMoreSalesDivisionGcdList(baseCode, 71, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �̔��敪�ڕW(���i�ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �̔��敪�ڕW(���i�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �̔��敪�ڕW(���i�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �̔��敪�ڕW(���i�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // ���Ӑ�DRP�I���̏ꍇ�A
                // ���Ӑ悪�s���̏ꍇ�A
                if (objAutoSetWork.CustomerDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Ώۋ��z���u���сv�̏ꍇ
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // ���㌎���W�v����f�[�^�𒊏o����
                        status = GetCustomerMTtList(baseCode, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // �Ώۋ��z���u�ڕW�v�̏ꍇ
                    else
                    {
                        // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�̓��Ӑ�f�[�^�𒊏o����
                        status = GetCustomerCusList(baseCode, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList custSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_Customer, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_Customer, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList custList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_Customer, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_Customer, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // �S����DRP�I���̏ꍇ�A
                // �S���҂��s���̏ꍇ�A
                if (objAutoSetWork.TantosyaDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Ώۋ��z���u���сv�̏ꍇ
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // ���㌎���W�v�S���҃f�[�^�𒊏o����
                        status = GetTantosyaMTtList(baseCode, enterpriseCode, 10, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // �Ώۋ��z���u�ڕW�v�̏ꍇ
                    else
                    {
                        // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̒S���҃f�[�^�𒊏o����
                        status = GetTantosyaEmpList(baseCode, 10, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Tantosya, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�폜
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Tantosya, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�폜
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Tantosya, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Tantosya, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // �S���҂̓��Ӑ�̖ڕW����Đݐݒ�
                else if (objAutoSetWork.TantosyaDrp == 2)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Đݒ�̏ꍇ
                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̓��Ӑ�f�[�^�𒊏o����
                    status = GetMoreCustomerEmpList(baseCode, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Tantosya, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Tantosya, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Tantosya, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Tantosya, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // �󒍎�DRP�I���̏ꍇ�A
                // �󒍎҂��s���̏ꍇ�A
                if (objAutoSetWork.ReceOrdDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Ώۋ��z���u���сv�̏ꍇ
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // ���㌎���W�v�S���҃f�[�^�𒊏o����
                        status = GetTantosyaMTtList(baseCode, enterpriseCode, 20, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // �Ώۋ��z���u�ڕW�v�̏ꍇ
                    else
                    {
                        // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̒S���҃f�[�^�𒊏o����
                        status = GetTantosyaEmpList(baseCode, 20, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_ReceOrd, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�폜
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_ReceOrd, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�폜
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_ReceOrd, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_ReceOrd, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // ���s��DRP�I���̏ꍇ�A
                // ���s�҂��s���̏ꍇ�A
                if (objAutoSetWork.PublisherDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Ώۋ��z���u���сv�̏ꍇ
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // ���㌎���W�v�S���҃f�[�^�𒊏o����
                        status = GetTantosyaMTtList(baseCode, enterpriseCode, 30, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // �Ώۋ��z���u�ڕW�v�̏ꍇ
                    else
                    {
                        // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̒S���҃f�[�^�𒊏o����
                        status = GetTantosyaEmpList(baseCode, 30, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Publisher, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�폜
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Publisher, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�폜
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Publisher, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Publisher, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // �S���ҖڕW(�]�ƈ��ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // �n��DRP�I���̏ꍇ�A
                // �n�悪�s���̏ꍇ�A
                if (objAutoSetWork.DistrictDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Ώۋ��z���u���сv�̏ꍇ
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // ���㌎���W�v����f�[�^�𒊏o����
                        status = GetDistrictMTtList(baseCode, 21, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // �Ώۋ��z���u�ڕW�v�̏ꍇ
                    else
                    {
                        // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�̓��Ӑ�f�[�^�𒊏o����
                        status = GetDistrictDOCusList(baseCode, 21, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList custSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_District, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_District, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList custList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_District, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_District, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // �n��̓��Ӑ�̖ڕW����Đݒ�
                else if (objAutoSetWork.DistrictDrp == 2)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Đݒ�̏ꍇ
                    // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�̒n��f�[�^�𒊏o����
                    status = GetDistrictCusList(baseCode, 21, 30, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList custSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_District, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_District, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList custList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_District, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_District, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // �Ǝ�DRP�I���̏ꍇ�A
                // �Ǝ킪�s���̏ꍇ�A
                if (objAutoSetWork.TypeBusinessDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Ώۋ��z���u���сv�̏ꍇ
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // ���㌎���W�v����f�[�^�𒊏o����
                        status = GetTypeBusinessMTtList(baseCode, 33, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // �Ώۋ��z���u�ڕW�v�̏ꍇ
                    else
                    {
                        // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�̓��Ӑ�f�[�^�𒊏o����
                        // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j33 �ڕW�Δ�敪 31
                        status = GetTypeBusinessTBCusList(baseCode, 33, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList custSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_TypeBusiness, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_TypeBusiness, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList custList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_TypeBusiness, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_TypeBusiness, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // �Ǝ�̓��Ӑ�̖ڕW����Đݒ�
                else if (objAutoSetWork.TypeBusinessDrp == 2)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Đݒ�̏ꍇ
                    // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�̓��Ӑ�f�[�^�𒊏o����
                    status = GetTypeBusinessCusList(baseCode, 33, 30, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList custSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_TypeBusiness, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_TypeBusiness, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList custList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_TypeBusiness, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_TypeBusiness, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // �̔��敪DRP�I���̏ꍇ�A
                // �̔��敪���s���̏ꍇ�A
                if (objAutoSetWork.SalesDivisionDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // �Ώۋ��z���u���сv�̏ꍇ
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // ���㌎���W�v����f�[�^�𒊏o����  ���[�U�[�K�C�h�}�X�^�i�̔��敪�j 71
                        status = GetSalesDivisionMTtList(baseCode, 71, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // �Ώۋ��z���u�ڕW�v�̏ꍇ
                    else
                    {
                        // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�̓��Ӑ�f�[�^�𒊏o����
                        status = GetSalesDivisionGcdList(baseCode, 71, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // �S�Ђ̏ꍇ�A�����f�[�^���폜����B
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList gcdSalesTargetList = new ArrayList();
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageGcdDate(periodKun, pastMonth, kubun_SalesCode, baseCode, enterpriseCode, gcdSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V
                            status = this.DeleteGcdSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareGcdMonthDate(kubun_SalesCode, baseCode, enterpriseCode, gcdSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteGcdSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // �G���[�̏ꍇ�A�Ԃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList gcdList in allDataList)
                    {
                        // �䗦�̐ݒ肪�u���ρv�̏ꍇ�͌��ʂ̍��v���v�Z���Y�����錎���Ŋ���A�[�������̐ݒ�ɏ]���v�Z����B
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageGcdDate(periodKun, pastMonth, kubun_SalesCode, baseCode, enterpriseCode, gcdList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteGcdSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _gcdSalesTargetDB.WriteGcdSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // �䗦�̐ݒ肪�u������v�̏ꍇ
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareGcdMonthDate(kubun_SalesCode, baseCode, enterpriseCode, gcdList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // ���Ӑ�ڕW(���Ӑ�ʔ���ڕW�ݒ�}�X�^��)�X�V

                            status = this.DeleteGcdSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _gcdSalesTargetDB.WriteGcdSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // �G���[�̏ꍇ�A�Ԃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }



                // �G���[�̏ꍇ�A�Ԃ�
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Rollback();
                }
                else
                {
                    sqlTransaction.Commit();
                }

            }
            catch (SqlException ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                // ���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "IOWriteMAHNBDB.Read(Connection�t) Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        # region �� ������ƕ��όv�Z���� ��
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̓����䏈��
        /// </summary>
        /// <param name="kubun">�����敪</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="empSalesTargetList">�]�ƈ��ʃf�[�^���X�g</param>
        /// <param name="unit">�[�������̒P��</param>
        /// <param name="fractionProc">�[�������敪</param>
        /// <param name="salesTarget">����</param>
        /// <param name="amountTarget">����ڕW</param>
        /// <param name="groMarginTarget">�e���ڕW</param>
        /// <param name="fiscalYear">��v�N�x</param>
        /// <param name="fiscalStartMonth">��v�N�x�J�n��</param>
        /// <param name="fiscalEndMonth">��v�N�x�I����</param>
        /// <param name="nowYearMonth">��v�N�x�N��</param>
        /// <param name="compareMonthDataList">������f�[�^���X�g</param>
        /// <param name="delDataList">�폜�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̓����䏈�����s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public void CompareEmpMonthDate(Int32 kubun, string baseCode, string enterpriseCode, ArrayList empSalesTargetList, Int32 unit, Int32 fractionProc, Int32 salesTarget,
            Int32 amountTarget, Int32 groMarginTarget, Hashtable fiscalYear, Hashtable fiscalStartMonth, Hashtable fiscalEndMonth,
            List<DateTime> nowYearMonth, out ArrayList compareMonthDataList, out ArrayList delDataList)
        {
            compareMonthDataList = new ArrayList();
            Int32 subSectionCode = 0;
            string employeeCode = string.Empty;
            double fractionUnit = 1;
            Int32 fractionProcess = 1;

            if (null != empSalesTargetList && empSalesTargetList.Count > 0)
            {
                double totalAmount = 0;
                double totalMoney = 0;
                double totalProfit = 0;

                Int32 empSalesTargetCount = empSalesTargetList.Count;

                for (int i = 0; i < empSalesTargetCount; i++)
                {
                    EmpSalesTargetWork empSalesTargetWork = (EmpSalesTargetWork)empSalesTargetList[i];
                    baseCode = empSalesTargetWork.SectionCode;
                    subSectionCode = empSalesTargetWork.SubSectionCode;
                    employeeCode = empSalesTargetWork.EmployeeCode;

                    totalAmount = empSalesTargetWork.SalesTargetCount;
                    totalMoney = (double)empSalesTargetWork.SalesTargetMoney;
                    totalProfit = (double)empSalesTargetWork.SalesTargetProfit;

                    // �P��
                    // �S�~�A
                    if (unit == 1)
                    {
                        fractionUnit = 100;
                    }
                    // ��~�A
                    else if (unit == 2)
                    {
                        fractionUnit = 1000;
                    }
                    // ���~
                    else if (unit == 3)
                    {
                        fractionUnit = 10000;
                    }

                    // �[������
                    // �l�̌ܓ�
                    if (fractionProc == 0)
                    {
                        fractionProcess = 2;
                    }
                    // �؏�
                    else if (fractionProc == 1)
                    {
                        fractionProcess = 3;
                    }
                    // �؎�
                    else
                    {
                        fractionProcess = 1;
                    }

                    // UP������
                    totalAmount = totalAmount * amountTarget / 100;
                    totalMoney = totalMoney * salesTarget / 100;
                    totalProfit = totalProfit * groMarginTarget / 100;

                    // MOD 2009/07/07 杍^ --->>>
                    FractionCalculate.FracCalcMoney(totalAmount, 1, fractionProcess, out totalAmount);
                    // MOD 2009/07/07 杍^ ---<<<
                    FractionCalculate.FracCalcMoney(totalMoney, fractionUnit, fractionProcess, out totalMoney);
                    FractionCalculate.FracCalcMoney(totalProfit, fractionUnit, fractionProcess, out totalProfit);

                    EmpSalesTargetWork compareMonthDataWork = new EmpSalesTargetWork();
                    // ��ƃR�[�h
                    compareMonthDataWork.EnterpriseCode = enterpriseCode;
                    // ���_�R�[�h
                    compareMonthDataWork.SectionCode = baseCode;
                    // �ڕW�ݒ�敪
                    compareMonthDataWork.TargetSetCd = 10;
                    // �ڕW�Δ�敪
                    compareMonthDataWork.TargetContrastCd = 10;
                    // �ڕW�敪�R�[�h
                    compareMonthDataWork.TargetDivideCode = Convert.ToString(fiscalYear[empSalesTargetWork.TargetDivideCode.Trim()]);
                    // �ڕW�敪����
                    compareMonthDataWork.TargetDivideName = string.Empty;
                    // �K�p�J�n��
                    compareMonthDataWork.ApplyStaDate = (DateTime)fiscalStartMonth[empSalesTargetWork.TargetDivideCode.Trim()];
                    // �K�p�I����
                    compareMonthDataWork.ApplyEndDate = (DateTime)fiscalEndMonth[empSalesTargetWork.TargetDivideCode.Trim()];
                    // ����ڕW����
                    compareMonthDataWork.SalesTargetCount = totalAmount;
                    // ����ڕW���z
                    compareMonthDataWork.SalesTargetMoney = (long)totalMoney;
                    // ����ڕW�e���z
                    compareMonthDataWork.SalesTargetProfit = (long)totalProfit;
                    // ���_�ڕW�X�V�̏ꍇ�A
                    if (kubun == kubun_Section)
                    {
                        // �ڕW�Δ�敪
                        compareMonthDataWork.TargetContrastCd = 10;
                        // ����R�[�h
                        compareMonthDataWork.SubSectionCode = 0;
                        // �]�ƈ��敪
                        compareMonthDataWork.EmployeeDivCd = 0;
                        // �]�ƈ��R�[�h
                        compareMonthDataWork.EmployeeCode = string.Empty;
                    }
                    // ����ڕW�X�V�̏ꍇ�A
                    else if (kubun == kubun_SubSection)
                    {
                        // �ڕW�Δ�敪
                        compareMonthDataWork.TargetContrastCd = 20;
                        // ����R�[�h
                        compareMonthDataWork.SubSectionCode = subSectionCode;
                        // �]�ƈ��敪
                        compareMonthDataWork.EmployeeDivCd = 0;
                        // �]�ƈ��R�[�h
                        compareMonthDataWork.EmployeeCode = string.Empty;
                    }
                    // �S���ҖڕW�X�V�̏ꍇ�A
                    else if (kubun == kubun_Tantosya)
                    {
                        // �ڕW�Δ�敪
                        compareMonthDataWork.TargetContrastCd = 22;
                        // ����R�[�h
                        compareMonthDataWork.SubSectionCode = 0;
                        // �]�ƈ��敪
                        compareMonthDataWork.EmployeeDivCd = 10;
                        // �]�ƈ��R�[�h
                        compareMonthDataWork.EmployeeCode = employeeCode;
                    }
                    // �󒍎ҖڕW�X�V�̏ꍇ�A
                    else if (kubun == kubun_ReceOrd)
                    {
                        // �ڕW�Δ�敪
                        compareMonthDataWork.TargetContrastCd = 22;
                        // ����R�[�h
                        compareMonthDataWork.SubSectionCode = 0;
                        // �]�ƈ��敪
                        compareMonthDataWork.EmployeeDivCd = 20;
                        // �]�ƈ��R�[�h
                        compareMonthDataWork.EmployeeCode = employeeCode;
                    }
                    // ���s�ҖڕW�X�V�̏ꍇ�A
                    else if (kubun == kubun_Publisher)
                    {
                        // �ڕW�Δ�敪
                        compareMonthDataWork.TargetContrastCd = 22;
                        // ����R�[�h
                        compareMonthDataWork.SubSectionCode = 0;
                        // �]�ƈ��敪
                        compareMonthDataWork.EmployeeDivCd = 30;
                        // �]�ƈ��R�[�h
                        compareMonthDataWork.EmployeeCode = employeeCode;
                    }
                    compareMonthDataList.Add(compareMonthDataWork);
                }
            }

            // �폜�p���[�N
            delDataList = new ArrayList();
            EmpSalesTargetWork delDataWork = null;
            Int32 nowYearMonthInt = 0;
            for (int i = 0; i < 12; i++)
            {
                delDataWork = new EmpSalesTargetWork();
                // ��ƃR�[�h
                delDataWork.EnterpriseCode = enterpriseCode;
                // ���_�R�[�h
                delDataWork.SectionCode = baseCode;
                // �ڕW�ݒ�敪
                delDataWork.TargetSetCd = 10;
                // �ڕW�敪�R�[�h
                DateTime nowYearMonthDt = nowYearMonth[i];
                nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                delDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                // ���_�ڕW�X�V�̏ꍇ�A
                if (kubun == kubun_Section)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 10;
                    // ����R�[�h
                    delDataWork.SubSectionCode = 0;
                    // �]�ƈ��敪
                    delDataWork.EmployeeDivCd = 0;
                    // �]�ƈ��R�[�h
                    delDataWork.EmployeeCode = string.Empty;
                }
                // ����ڕW�X�V�̏ꍇ�A
                else if (kubun == kubun_SubSection)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 20;
                    // ����R�[�h
                    delDataWork.SubSectionCode = subSectionCode;
                    // �]�ƈ��敪
                    delDataWork.EmployeeDivCd = 0;
                    // �]�ƈ��R�[�h
                    delDataWork.EmployeeCode = string.Empty;
                }
                // �S���ҖڕW�X�V�̏ꍇ�A
                else if (kubun == kubun_Tantosya)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 22;
                    // ����R�[�h
                    delDataWork.SubSectionCode = 0;
                    // �]�ƈ��敪
                    delDataWork.EmployeeDivCd = 10;
                    // �]�ƈ��R�[�h
                    delDataWork.EmployeeCode = employeeCode;
                }
                // �󒍎ҖڕW�X�V�̏ꍇ�A
                else if (kubun == kubun_ReceOrd)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 22;
                    // ����R�[�h
                    delDataWork.SubSectionCode = 0;
                    // �]�ƈ��敪
                    delDataWork.EmployeeDivCd = 20;
                    // �]�ƈ��R�[�h
                    delDataWork.EmployeeCode = employeeCode;
                }
                // ���s�ҖڕW�X�V�̏ꍇ�A
                else if (kubun == kubun_Publisher)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 22;
                    // ����R�[�h
                    delDataWork.SubSectionCode = 0;
                    // �]�ƈ��敪
                    delDataWork.EmployeeDivCd = 30;
                    // �]�ƈ��R�[�h
                    delDataWork.EmployeeCode = employeeCode;
                }
                delDataList.Add(delDataWork);
            }
        }

        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̕��Ϗ���
        /// </summary>
        /// <param name="periodKun">�Ώۊ��敪</param>
        /// <param name="pastMonth">�ߋ�*����</param>
        /// <param name="kubun">�����敪</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="empSalesTargetList">�]�ƈ��ʃf�[�^���X�g</param>
        /// <param name="unit">�[�������̒P��</param>
        /// <param name="fractionProc">�[�������敪</param>
        /// <param name="salesTarget">����</param>
        /// <param name="amountTarget">����ڕW</param>
        /// <param name="groMarginTarget">�e���ڕW</param>
        /// <param name="nowStartMonthDate">��v�N�x</param>
        /// <param name="nowEndMonthDate">��v�N�x�J�n��</param>
        /// <param name="nowYearMonth">��v�N�x�N��</param>
        /// <param name="averageDataList">���σf�[�^���X�g</param>
        /// <param name="delDataList">�폜�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̕��Ϗ������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public void AverageEmpDate(Int32 periodKun, Int32 pastMonth, Int32 kubun, string baseCode, string enterpriseCode, ArrayList empSalesTargetList, Int32 unit, Int32 fractionProc, Int32 salesTarget,
            Int32 amountTarget, Int32 groMarginTarget, List<DateTime> nowStartMonthDate, List<DateTime> nowEndMonthDate,
            List<DateTime> nowYearMonth, out ArrayList averageDataList, out ArrayList delDataList)
        {
            averageDataList = new ArrayList();
            Int32 empSalesTargetCount = empSalesTargetList.Count;
            Int32 subSectionCode = 0;
            string employeeCode = string.Empty;
            Int32 nowYearMonthInt = 0;
            delDataList = new ArrayList();
            double fractionUnit = 1;
            Int32 fractionProcess = 1;

            if (null != empSalesTargetList && empSalesTargetCount > 0)
            {
                double totalAmount = 0;
                double totalMoney = 0;
                double totalProfit = 0;

                for (int i = 0; i < empSalesTargetCount; i++)
                {
                    EmpSalesTargetWork empSalesTargetWork = (EmpSalesTargetWork)empSalesTargetList[i];
                    baseCode = empSalesTargetWork.SectionCode;
                    subSectionCode = empSalesTargetWork.SubSectionCode;
                    employeeCode = empSalesTargetWork.EmployeeCode;

                    totalAmount = totalAmount + empSalesTargetWork.SalesTargetCount;
                    totalMoney = totalMoney + (double)empSalesTargetWork.SalesTargetMoney;
                    totalProfit = totalProfit + (double)empSalesTargetWork.SalesTargetProfit;
                }

                // �����ɐ��ʁA���z�A�e�����W�v����
                // �O��
                if (0 == periodKun)
                {
                    totalAmount = totalAmount / 12;
                    totalMoney = totalMoney / 12;
                    totalProfit = totalProfit / 12;
                }
                else
                {
                    totalAmount = totalAmount / pastMonth;
                    totalMoney = totalMoney / pastMonth;
                    totalProfit = totalProfit / pastMonth;
                }

                // �P��
                // �S�~�A
                if (unit == 1)
                {
                    fractionUnit = 100;
                }
                // ��~�A
                else if (unit == 2)
                {
                    fractionUnit = 1000;
                }
                // ���~
                else if (unit == 3)
                {
                    fractionUnit = 10000;
                }

                // �[������
                // �l�̌ܓ�
                if (fractionProc == 0)
                {
                    fractionProcess = 2;
                }
                // �؏�
                else if (fractionProc == 1)
                {
                    fractionProcess = 3;
                }
                // �؎�
                else
                {
                    fractionProcess = 1;
                }

                // UP������
                totalAmount = totalAmount * amountTarget / 100;
                totalMoney = totalMoney * salesTarget / 100;
                totalProfit = totalProfit * groMarginTarget / 100;
                // MOD 2009/07/07 杍^ --->>>
                FractionCalculate.FracCalcMoney(totalAmount, 1, fractionProcess, out totalAmount);
                // MOD 2009/07/07 杍^ ---<<<
                FractionCalculate.FracCalcMoney(totalMoney, fractionUnit, fractionProcess, out totalMoney);
                FractionCalculate.FracCalcMoney(totalProfit, fractionUnit, fractionProcess, out totalProfit);

                // �o�^�w�b�_���
                EmpSalesTargetWork empSalesTargetInsertWork = new EmpSalesTargetWork();
                object objInsert = (object)this;
                IFileHeader insertIf = (IFileHeader)empSalesTargetInsertWork;
                FileHeader fileInsert = new FileHeader(objInsert);
                fileInsert.SetInsertHeader(ref insertIf, objInsert);

                for (int i = 0; i < 12; i++)
                {
                    EmpSalesTargetWork averageDataWork = new EmpSalesTargetWork();
                    // ��ƃR�[�h
                    averageDataWork.EnterpriseCode = enterpriseCode;
                    // ���_�R�[�h
                    averageDataWork.SectionCode = baseCode;
                    // �ڕW�ݒ�敪
                    averageDataWork.TargetSetCd = 10;
                    // �ڕW�敪����
                    averageDataWork.TargetDivideName = string.Empty;
                    // �ڕW�敪�R�[�h
                    DateTime nowYearMonthDt = nowYearMonth[i];
                    nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                    averageDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                    // �K�p�J�n��
                    DateTime nowStartMonthDt = nowStartMonthDate[i];
                    averageDataWork.ApplyStaDate = nowStartMonthDt;
                    // �K�p�I����
                    DateTime nowEndMonthDt = nowEndMonthDate[i];
                    averageDataWork.ApplyEndDate = nowEndMonthDt;
                    // ����ڕW����
                    averageDataWork.SalesTargetCount = totalAmount;
                    // ����ڕW���z
                    averageDataWork.SalesTargetMoney = (long)totalMoney;
                    // ����ڕW�e���z
                    averageDataWork.SalesTargetProfit = (long)totalProfit;
                    // ���_�ڕW�X�V�̏ꍇ�A
                    if (kubun == kubun_Section)
                    {
                        // �ڕW�Δ�敪
                        averageDataWork.TargetContrastCd = 10;
                        // ����R�[�h
                        averageDataWork.SubSectionCode = 0;
                        // �]�ƈ��敪
                        averageDataWork.EmployeeDivCd = 0;
                        // �]�ƈ��R�[�h
                        averageDataWork.EmployeeCode = string.Empty;
                    }
                    // �S���ҖڕW�X�V�̏ꍇ�A
                    else if (kubun == kubun_Tantosya)
                    {
                        // �ڕW�Δ�敪
                        averageDataWork.TargetContrastCd = 22;
                        // ����R�[�h
                        averageDataWork.SubSectionCode = 0;
                        // �]�ƈ��敪
                        averageDataWork.EmployeeDivCd = 10;
                        // �]�ƈ��R�[�h
                        averageDataWork.EmployeeCode = employeeCode;
                    }
                    // �󒍎ҖڕW�X�V�̏ꍇ�A
                    else if (kubun == kubun_ReceOrd)
                    {
                        // �ڕW�Δ�敪
                        averageDataWork.TargetContrastCd = 22;
                        // ����R�[�h
                        averageDataWork.SubSectionCode = 0;
                        // �]�ƈ��敪
                        averageDataWork.EmployeeDivCd = 20;
                        // �]�ƈ��R�[�h
                        averageDataWork.EmployeeCode = employeeCode;
                    }
                    // ���s�ҖڕW�X�V�̏ꍇ�A
                    else if (kubun == kubun_Publisher)
                    {
                        // �ڕW�Δ�敪
                        averageDataWork.TargetContrastCd = 22;
                        // ����R�[�h
                        averageDataWork.SubSectionCode = 0;
                        // �]�ƈ��敪
                        averageDataWork.EmployeeDivCd = 30;
                        // �]�ƈ��R�[�h
                        averageDataWork.EmployeeCode = employeeCode;
                    }
                    averageDataList.Add(averageDataWork);
                }
            }

            for (int i = 0; i < 12; i++)
            {
                EmpSalesTargetWork delDataWork = new EmpSalesTargetWork();
                // ��ƃR�[�h
                delDataWork.EnterpriseCode = enterpriseCode;
                // ���_�R�[�h
                delDataWork.SectionCode = baseCode;
                // �ڕW�ݒ�敪
                delDataWork.TargetSetCd = 10;
                // �ڕW�敪�R�[�h
                DateTime nowYearMonthDt = nowYearMonth[i];
                nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                delDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                // ���_�ڕW�X�V�̏ꍇ�A
                if (kubun == kubun_Section)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 10;
                    // ����R�[�h
                    delDataWork.SubSectionCode = 0;
                    // �]�ƈ��敪
                    delDataWork.EmployeeDivCd = 0;
                    // �]�ƈ��R�[�h
                    delDataWork.EmployeeCode = string.Empty;
                }
                // �S���ҖڕW�X�V�̏ꍇ�A
                else if (kubun == kubun_Tantosya)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 22;
                    // ����R�[�h
                    delDataWork.SubSectionCode = 0;
                    // �]�ƈ��敪
                    delDataWork.EmployeeDivCd = 10;
                    // �]�ƈ��R�[�h
                    delDataWork.EmployeeCode = employeeCode;
                }
                // �󒍎ҖڕW�X�V�̏ꍇ�A
                else if (kubun == kubun_ReceOrd)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 22;
                    // ����R�[�h
                    delDataWork.SubSectionCode = 0;
                    // �]�ƈ��敪
                    delDataWork.EmployeeDivCd = 20;
                    // �]�ƈ��R�[�h
                    delDataWork.EmployeeCode = employeeCode;
                }
                // ���s�ҖڕW�X�V�̏ꍇ�A
                else if (kubun == kubun_Publisher)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 22;
                    // ����R�[�h
                    delDataWork.SubSectionCode = 0;
                    // �]�ƈ��敪
                    delDataWork.EmployeeDivCd = 30;
                    // �]�ƈ��R�[�h
                    delDataWork.EmployeeCode = employeeCode;
                }
                delDataList.Add(delDataWork);
            }
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^�̓����䏈��
        /// </summary>
        /// <param name="kubun">�����敪</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="custSalesTargetList">���Ӑ�ʃf�[�^���X�g</param>
        /// <param name="unit">�[�������̒P��</param>
        /// <param name="fractionProc">�[�������敪</param>
        /// <param name="salesTarget">����</param>
        /// <param name="amountTarget">����ڕW</param>
        /// <param name="groMarginTarget">�e���ڕW</param>
        /// <param name="fiscalYear">��v�N�x</param>
        /// <param name="fiscalStartMonth">��v�N�x�J�n��</param>
        /// <param name="fiscalEndMonth">��v�N�x�I����</param>
        /// <param name="nowYearMonth">��v�N�x�N��</param>
        /// <param name="compareMonthDataList">������f�[�^���X�g</param>
        /// <param name="delDataList">�폜�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�̓����䏈�����s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public void CompareCusMonthDate(Int32 kubun, string baseCode, string enterpriseCode, ArrayList custSalesTargetList, Int32 unit, Int32 fractionProc, Int32 salesTarget,
    Int32 amountTarget, Int32 groMarginTarget, Hashtable fiscalYear, Hashtable fiscalStartMonth, Hashtable fiscalEndMonth,
    List<DateTime> nowYearMonth, out ArrayList compareMonthDataList, out ArrayList delDataList)
        {
            compareMonthDataList = new ArrayList();

            Int32 customerCode = -1;
            Int32 salesAreaCode = -1;
            double fractionUnit = 1;
            Int32 fractionProcess = 1;
            Int32 typeBusiness = -1;

            if (null != custSalesTargetList && custSalesTargetList.Count > 0)
            {
                double totalAmount = 0;
                double totalMoney = 0;
                double totalProfit = 0;

                Int32 custSalesTargetCount = custSalesTargetList.Count;

                for (int i = 0; i < custSalesTargetCount; i++)
                {
                    CustSalesTargetWork custSalesTargetWork = (CustSalesTargetWork)custSalesTargetList[i];
                    baseCode = custSalesTargetWork.SectionCode;
                    customerCode = custSalesTargetWork.CustomerCode;
                    salesAreaCode = custSalesTargetWork.SalesAreaCode;
                    typeBusiness = custSalesTargetWork.BusinessTypeCode;

                    totalAmount = custSalesTargetWork.SalesTargetCount;
                    totalMoney = (double)custSalesTargetWork.SalesTargetMoney;
                    totalProfit = (double)custSalesTargetWork.SalesTargetProfit;

                    // �P��
                    // �S�~�A
                    if (unit == 1)
                    {
                        fractionUnit = 100;
                    }
                    // ��~�A
                    else if (unit == 2)
                    {
                        fractionUnit = 1000;
                    }
                    // ���~
                    else if (unit == 3)
                    {
                        fractionUnit = 10000;
                    }

                    // �[������
                    // �l�̌ܓ�
                    if (fractionProc == 0)
                    {
                        fractionProcess = 2;
                    }
                    // �؏�
                    else if (fractionProc == 1)
                    {
                        fractionProcess = 3;
                    }
                    // �؎�
                    else
                    {
                        fractionProcess = 1;
                    }

                    // UP������
                    totalAmount = totalAmount * amountTarget / 100;
                    totalMoney = totalMoney * salesTarget / 100;
                    totalProfit = totalProfit * groMarginTarget / 100;
                    // MOD 2009/07/07 杍^ --->>>
                    FractionCalculate.FracCalcMoney(totalAmount, 1, fractionProcess, out totalAmount);
                    // MOD 2009/07/07 杍^ ---<<<
                    FractionCalculate.FracCalcMoney(totalMoney, fractionUnit, fractionProcess, out totalMoney);
                    FractionCalculate.FracCalcMoney(totalProfit, fractionUnit, fractionProcess, out totalProfit);

                    CustSalesTargetWork compareMonthDataWork = new CustSalesTargetWork();
                    // ��ƃR�[�h
                    compareMonthDataWork.EnterpriseCode = enterpriseCode;
                    // ���_�R�[�h
                    compareMonthDataWork.SectionCode = baseCode;
                    // �ڕW�ݒ�敪
                    compareMonthDataWork.TargetSetCd = 10;
                    // �ڕW�敪�R�[�h
                    compareMonthDataWork.TargetDivideCode = Convert.ToString(fiscalYear[custSalesTargetWork.TargetDivideCode.Trim()]);
                    // �ڕW�敪����
                    compareMonthDataWork.TargetDivideName = string.Empty;
                    // �Ǝ�R�[�h
                    compareMonthDataWork.BusinessTypeCode = 0;
                    // �K�p�J�n��
                    compareMonthDataWork.ApplyStaDate = (DateTime)fiscalStartMonth[custSalesTargetWork.TargetDivideCode.Trim()];
                    // �K�p�I����
                    compareMonthDataWork.ApplyEndDate = (DateTime)fiscalEndMonth[custSalesTargetWork.TargetDivideCode.Trim()];
                    // ����ڕW����
                    compareMonthDataWork.SalesTargetCount = totalAmount;
                    // ����ڕW���z
                    compareMonthDataWork.SalesTargetMoney = (long)totalMoney;
                    // ����ڕW�e���z
                    compareMonthDataWork.SalesTargetProfit = (long)totalProfit;
                    // ���Ӑ�ڕW�X�V�̏ꍇ�A
                    if (kubun == kubun_Customer)
                    {
                        // �ڕW�Δ�敪
                        compareMonthDataWork.TargetContrastCd = 30;
                        // ���Ӑ�R�[�h
                        compareMonthDataWork.CustomerCode = customerCode;
                        // �̔��G���A�R�[�h
                        compareMonthDataWork.SalesAreaCode = 0;
                    }
                    // �n��ڕW�X�V�̏ꍇ�A
                    else if (kubun == kubun_District)
                    {
                        // �ڕW�Δ�敪
                        compareMonthDataWork.TargetContrastCd = 32;
                        // ���Ӑ�R�[�h
                        compareMonthDataWork.CustomerCode = 0;
                        // �̔��G���A�R�[�h
                        compareMonthDataWork.SalesAreaCode = salesAreaCode;
                    }
                    // �Ǝ�ڕW�X�V�̏ꍇ�A
                    else if (kubun == kubun_TypeBusiness)
                    {
                        // �ڕW�Δ�敪
                        compareMonthDataWork.TargetContrastCd = 31;
                        // ���Ӑ�R�[�h
                        compareMonthDataWork.CustomerCode = 0;
                        // �̔��G���A�R�[�h
                        compareMonthDataWork.SalesAreaCode = 0;
                        // �Ǝ�R�[�h
                        compareMonthDataWork.BusinessTypeCode = typeBusiness;
                    }
                    compareMonthDataList.Add(compareMonthDataWork);
                }
            }

            // �폜�p���[�N
            delDataList = new ArrayList();
            CustSalesTargetWork delDataWork = null;
            Int32 nowYearMonthInt = 0;
            for (int i = 0; i < 12; i++)
            {
                delDataWork = new CustSalesTargetWork();
                // ��ƃR�[�h
                delDataWork.EnterpriseCode = enterpriseCode;
                // ���_�R�[�h
                delDataWork.SectionCode = baseCode;
                // �ڕW�ݒ�敪
                delDataWork.TargetSetCd = 10;
                // �ڕW�敪�R�[�h
                DateTime nowYearMonthDt = nowYearMonth[i];
                nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                delDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                // �Ǝ�R�[�h
                delDataWork.BusinessTypeCode = 0;
                // ���Ӑ�ڕW�X�V�̏ꍇ�A
                if (kubun == kubun_Customer)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 30;
                    // ���Ӑ�R�[�h
                    delDataWork.CustomerCode = customerCode;
                    // �̔��G���A�R�[�h
                    delDataWork.SalesAreaCode = 0;
                }
                // �n��ڕW�X�V�̏ꍇ�A
                else if (kubun == kubun_District)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 32;
                    // ���Ӑ�R�[�h
                    delDataWork.CustomerCode = 0;
                    // �̔��G���A�R�[�h
                    delDataWork.SalesAreaCode = salesAreaCode;
                }
                // �Ǝ�ڕW�X�V�̏ꍇ�A
                else if (kubun == kubun_TypeBusiness)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 31;
                    // ���Ӑ�R�[�h
                    delDataWork.CustomerCode = 0;
                    // �̔��G���A�R�[�h
                    delDataWork.SalesAreaCode = 0;
                    // �Ǝ�R�[�h
                    delDataWork.BusinessTypeCode = typeBusiness;
                }
                delDataList.Add(delDataWork);
            }
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^�̕��Ϗ���
        /// </summary>
        /// <param name="periodKun">�Ώۊ��敪</param>
        /// <param name="pastMonth">�ߋ�*����</param>
        /// <param name="kubun">�����敪</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="custSalesTargetList">���Ӑ�ʃf�[�^���X�g</param>
        /// <param name="unit">�[�������̒P��</param>
        /// <param name="fractionProc">�[�������敪</param>
        /// <param name="salesTarget">����</param>
        /// <param name="amountTarget">����ڕW</param>
        /// <param name="groMarginTarget">�e���ڕW</param>
        /// <param name="nowStartMonthDate">��v�N�x</param>
        /// <param name="nowEndMonthDate">��v�N�x�J�n��</param>
        /// <param name="nowYearMonth">��v�N�x�N��</param>
        /// <param name="averageDataList">���σf�[�^���X�g</param>
        /// <param name="delDataList">�폜�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�̕��Ϗ������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public void AverageCusDate(Int32 periodKun, Int32 pastMonth, Int32 kubun, string baseCode, string enterpriseCode, ArrayList custSalesTargetList, Int32 unit, Int32 fractionProc, Int32 salesTarget,
            Int32 amountTarget, Int32 groMarginTarget, List<DateTime> nowStartMonthDate, List<DateTime> nowEndMonthDate,
            List<DateTime> nowYearMonth, out ArrayList averageDataList, out ArrayList delDataList)
        {
            averageDataList = new ArrayList();
            Int32 custSalesTargetCount = custSalesTargetList.Count;
            Int32 customerCode = -1;
            Int32 salesAreaCode = -1;
            Int32 typeBusiness = -1;
            Int32 nowYearMonthInt = 0;
            delDataList = new ArrayList();
            double fractionUnit = 1;
            Int32 fractionProcess = 1;


            if (null != custSalesTargetList && custSalesTargetCount > 0)
            {
                double totalAmount = 0;
                double totalMoney = 0;
                double totalProfit = 0;

                for (int i = 0; i < custSalesTargetCount; i++)
                {
                    CustSalesTargetWork custSalesTargetWork = (CustSalesTargetWork)custSalesTargetList[i];
                    baseCode = custSalesTargetWork.SectionCode;
                    customerCode = custSalesTargetWork.CustomerCode;
                    salesAreaCode = custSalesTargetWork.SalesAreaCode;
                    typeBusiness = custSalesTargetWork.BusinessTypeCode;

                    totalAmount = totalAmount + custSalesTargetWork.SalesTargetCount;
                    totalMoney = totalMoney + (double)custSalesTargetWork.SalesTargetMoney;
                    totalProfit = totalProfit + (double)custSalesTargetWork.SalesTargetProfit;
                }

                // �����ɐ��ʁA���z�A�e�����W�v����
                // �O��
                if (0 == periodKun)
                {
                    totalAmount = totalAmount / 12;
                    totalMoney = totalMoney / 12;
                    totalProfit = totalProfit / 12;
                }
                // ����
                else
                {
                    totalAmount = totalAmount / pastMonth;
                    totalMoney = totalMoney / pastMonth;
                    totalProfit = totalProfit / pastMonth;
                }


                // �P��
                // �S�~�A
                if (unit == 1)
                {
                    fractionUnit = 100;
                }
                // ��~�A
                else if (unit == 2)
                {
                     fractionUnit = 1000;
                }
                // ���~
                else if (unit == 3)
                {
                     fractionUnit = 10000;
                }

                // �[������
                // �l�̌ܓ�
                if (fractionProc == 0)
                {
                    fractionProcess = 2;
                }
                // �؏�
                else if (fractionProc == 1)
                {
                    fractionProcess = 3;
                }
                // �؎�
                else
                {
                    fractionProcess = 1;
                }

                // UP������
                totalAmount = totalAmount * amountTarget / 100;
                totalMoney = totalMoney * salesTarget / 100;
                totalProfit = totalProfit * groMarginTarget / 100;

                // MOD 2009/07/07 杍^ --->>>
                FractionCalculate.FracCalcMoney(totalAmount, 1, fractionProcess, out totalAmount);
                // MOD 2009/07/07 杍^ ---<<<
                FractionCalculate.FracCalcMoney(totalMoney, fractionUnit, fractionProcess, out totalMoney);
                FractionCalculate.FracCalcMoney(totalProfit, fractionUnit, fractionProcess, out totalProfit);

                for (int i = 0; i < 12; i++)
                {
                    CustSalesTargetWork averageDataWork = new CustSalesTargetWork();
                    // ��ƃR�[�h
                    averageDataWork.EnterpriseCode = enterpriseCode;
                    // ���_�R�[�h
                    averageDataWork.SectionCode = baseCode;
                    // �ڕW�ݒ�敪
                    averageDataWork.TargetSetCd = 10;
                    // �ڕW�敪����
                    averageDataWork.TargetDivideName = string.Empty;
                    // �ڕW�敪�R�[�h
                    DateTime nowYearMonthDt = nowYearMonth[i];
                    nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                    averageDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                    // �K�p�J�n��
                    DateTime nowStartMonthDt = nowStartMonthDate[i];
                    averageDataWork.ApplyStaDate = nowStartMonthDt;
                    // �K�p�I����
                    DateTime nowEndMonthDt = nowEndMonthDate[i];
                    averageDataWork.ApplyEndDate = nowEndMonthDt;
                    // ����ڕW����
                    averageDataWork.SalesTargetCount = (double)totalAmount;
                    // ����ڕW���z
                    averageDataWork.SalesTargetMoney = (long)totalMoney;
                    // ����ڕW�e���z
                    averageDataWork.SalesTargetProfit = (long)totalProfit;
                    // ���Ӑ�ڕW�X�V�̏ꍇ�A
                    if (kubun == kubun_Customer)
                    {
                        // �ڕW�Δ�敪
                        averageDataWork.TargetContrastCd = 30;
                        // ���Ӑ�R�[�h
                        averageDataWork.CustomerCode = customerCode;
                        // �̔��G���A�R�[�h
                        averageDataWork.SalesAreaCode = 0;
                        // �Ǝ�R�[�h
                        averageDataWork.BusinessTypeCode = 0;
                    }
                    // �n��ڕW�X�V�̏ꍇ�A
                    else if (kubun == kubun_District)
                    {
                        // �ڕW�Δ�敪
                        averageDataWork.TargetContrastCd = 32;
                        // ���Ӑ�R�[�h
                        averageDataWork.CustomerCode = 0;
                        // �̔��G���A�R�[�h
                        averageDataWork.SalesAreaCode = salesAreaCode;
                        // �Ǝ�R�[�h
                        averageDataWork.BusinessTypeCode = 0;
                    }
                    // �Ǝ�ڕW�X�V�̏ꍇ�A
                    else if (kubun == kubun_TypeBusiness)
                    {
                        // �ڕW�Δ�敪
                        averageDataWork.TargetContrastCd = 31;
                        // ���Ӑ�R�[�h
                        averageDataWork.CustomerCode = 0;
                        // �̔��G���A�R�[�h
                        averageDataWork.SalesAreaCode = 0;
                        // �Ǝ�R�[�h
                        averageDataWork.BusinessTypeCode = typeBusiness;
                    }

                    averageDataList.Add(averageDataWork);
                }
            }

            for (int i = 0; i < 12; i++)
            {
                CustSalesTargetWork delDataWork = new CustSalesTargetWork();
                // ��ƃR�[�h
                delDataWork.EnterpriseCode = enterpriseCode;
                // ���_�R�[�h
                delDataWork.SectionCode = baseCode;
                // �ڕW�ݒ�敪
                delDataWork.TargetSetCd = 10;
                // �ڕW�敪�R�[�h
                DateTime nowYearMonthDt = nowYearMonth[i];
                nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                delDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                // ���Ӑ�ڕW�X�V�̏ꍇ�A
                if (kubun == kubun_Customer)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 30;
                    // ���Ӑ�R�[�h
                    delDataWork.CustomerCode = customerCode;
                    // �̔��G���A�R�[�h
                    delDataWork.SalesAreaCode = 0;
                    // �Ǝ�R�[�h
                    delDataWork.BusinessTypeCode = 0;
                }
                // �n��ڕW�X�V�̏ꍇ�A
                else if (kubun == kubun_District)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 32;
                    // ���Ӑ�R�[�h
                    delDataWork.CustomerCode = 0;
                    // �̔��G���A�R�[�h
                    delDataWork.SalesAreaCode = salesAreaCode;
                    // �Ǝ�R�[�h
                    delDataWork.BusinessTypeCode = 0;
                }
                // �Ǝ�ڕW�X�V�̏ꍇ�A
                else if (kubun == kubun_TypeBusiness)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 31;
                    // ���Ӑ�R�[�h
                    delDataWork.CustomerCode = 0;
                    // �̔��G���A�R�[�h
                    delDataWork.SalesAreaCode = 0;
                    // �Ǝ�R�[�h
                    delDataWork.BusinessTypeCode = typeBusiness;
                }
                delDataList.Add(delDataWork);
            }
        }

        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^�̓����䏈��
        /// </summary>
        /// <param name="kubun">�����敪</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="gcdSalesTargetList">���i�ʃf�[�^���X�g</param>
        /// <param name="unit">�[�������̒P��</param>
        /// <param name="fractionProc">�[�������敪</param>
        /// <param name="salesTarget">����</param>
        /// <param name="amountTarget">����ڕW</param>
        /// <param name="groMarginTarget">�e���ڕW</param>
        /// <param name="fiscalYear">��v�N�x</param>
        /// <param name="fiscalStartMonth">��v�N�x�J�n��</param>
        /// <param name="fiscalEndMonth">��v�N�x�I����</param>
        /// <param name="nowYearMonth">��v�N�x�N��</param>
        /// <param name="compareMonthDataList">������f�[�^���X�g</param>
        /// <param name="delDataList">�폜�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�̓����䏈�����s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public void CompareGcdMonthDate(Int32 kubun, string baseCode, string enterpriseCode, ArrayList gcdSalesTargetList, Int32 unit, Int32 fractionProc, Int32 salesTarget,
Int32 amountTarget, Int32 groMarginTarget, Hashtable fiscalYear, Hashtable fiscalStartMonth, Hashtable fiscalEndMonth,
List<DateTime> nowYearMonth, out ArrayList compareMonthDataList, out ArrayList delDataList)
        {
            compareMonthDataList = new ArrayList();

            Int32 salesCode = -1;
            double fractionUnit = 1;
            Int32 fractionProcess = 1;

            if (null != gcdSalesTargetList && gcdSalesTargetList.Count > 0)
            {
                double totalAmount = 0;
                double totalMoney = 0;
                double totalProfit = 0;

                Int32 gcdSalesTargetCount = gcdSalesTargetList.Count;

                for (int i = 0; i < gcdSalesTargetCount; i++)
                {
                    GcdSalesTargetWork gcdSalesTargetWork = (GcdSalesTargetWork)gcdSalesTargetList[i];
                    baseCode = gcdSalesTargetWork.SectionCode;
                    salesCode = gcdSalesTargetWork.SalesCode;

                    totalAmount = gcdSalesTargetWork.SalesTargetCount;
                    totalMoney = (double)gcdSalesTargetWork.SalesTargetMoney;
                    totalProfit = (double)gcdSalesTargetWork.SalesTargetProfit;

                    // �P��
                    // �S�~�A
                    if (unit == 1)
                    {
                        fractionUnit = 100;
                    }
                    // ��~�A
                    else if (unit == 2)
                    {
                        fractionUnit = 1000;
                    }
                    // ���~
                    else if (unit == 3)
                    {
                        fractionUnit = 10000;
                    }

                    // �[������
                    // �l�̌ܓ�
                    if (fractionProc == 0)
                    {
                        fractionProcess = 2;
                    }
                    // �؏�
                    else if (fractionProc == 1)
                    {
                        fractionProcess = 3;
                    }
                    // �؎�
                    else
                    {
                        fractionProcess = 1;
                    }

                    // UP������
                    totalAmount = totalAmount * amountTarget / 100;
                    totalMoney = totalMoney * salesTarget / 100;
                    totalProfit = totalProfit * groMarginTarget / 100;

                    // MOD 2009/07/07 杍^ --->>>
                    FractionCalculate.FracCalcMoney(totalAmount, 1, fractionProcess, out totalAmount);
                    // MOD 2009/07/07 杍^ ---<<<
                    FractionCalculate.FracCalcMoney(totalMoney, fractionUnit, fractionProcess, out totalMoney);
                    FractionCalculate.FracCalcMoney(totalProfit, fractionUnit, fractionProcess, out totalProfit);

                    GcdSalesTargetWork compareMonthDataWork = new GcdSalesTargetWork();
                    // ��ƃR�[�h
                    compareMonthDataWork.EnterpriseCode = enterpriseCode;
                    // ���_�R�[�h
                    compareMonthDataWork.SectionCode = baseCode;
                    // �ڕW�ݒ�敪
                    compareMonthDataWork.TargetSetCd = 10;
                    // �ڕW�Δ�敪
                    compareMonthDataWork.TargetContrastCd = 30;
                    // �ڕW�敪�R�[�h
                    compareMonthDataWork.TargetDivideCode = Convert.ToString(fiscalYear[gcdSalesTargetWork.TargetDivideCode.Trim()]);
                    // �ڕW�敪����
                    compareMonthDataWork.TargetDivideName = string.Empty;
                    // ���i���[�J�[�R�[�h
                    compareMonthDataWork.GoodsMakerCd = 0;
                    // ���i�ԍ�
                    compareMonthDataWork.GoodsNo = string.Empty;
                    // BL�O���[�v�R�[�h
                    compareMonthDataWork.BLGroupCode = 0;
                    // BL���i�R�[�h
                    compareMonthDataWork.BLGoodsCode = 0;
                    // ���Е��ރR�[�h
                    compareMonthDataWork.EnterpriseGanreCode = 0;
                    // �K�p�J�n��
                    compareMonthDataWork.ApplyStaDate = (DateTime)fiscalStartMonth[gcdSalesTargetWork.TargetDivideCode.Trim()];
                    // �K�p�I����
                    compareMonthDataWork.ApplyEndDate = (DateTime)fiscalEndMonth[gcdSalesTargetWork.TargetDivideCode.Trim()];
                    // ����ڕW����
                    compareMonthDataWork.SalesTargetCount = (double)totalAmount;
                    // ����ڕW���z
                    compareMonthDataWork.SalesTargetMoney = (long)totalMoney;
                    // ����ڕW�e���z
                    compareMonthDataWork.SalesTargetProfit = (long)totalProfit;
                    // �̔��敪�ڕW�X�V�̏ꍇ�A
                    if (kubun == kubun_SalesCode)
                    {
                        // �ڕW�Δ�敪
                        compareMonthDataWork.TargetContrastCd = 44;
                        // �̔��敪�R�[�h
                        compareMonthDataWork.SalesCode = salesCode;
                    }

                    compareMonthDataList.Add(compareMonthDataWork);
                }
            }

            // �폜�p���[�N
            delDataList = new ArrayList();
            GcdSalesTargetWork delDataWork = null;
            Int32 nowYearMonthInt = 0;
            for (int i = 0; i < 12; i++)
            {
                delDataWork = new GcdSalesTargetWork();
                // ��ƃR�[�h
                delDataWork.EnterpriseCode = enterpriseCode;
                // ���_�R�[�h
                delDataWork.SectionCode = baseCode;
                // �ڕW�ݒ�敪
                delDataWork.TargetSetCd = 10;
                // �ڕW�Δ�敪
                delDataWork.TargetContrastCd = 30;
                // �ڕW�敪�R�[�h
                DateTime nowYearMonthDt = nowYearMonth[i];
                nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                delDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                // ���i���[�J�[�R�[�h
                delDataWork.GoodsMakerCd = 0;
                // ���i�ԍ�
                delDataWork.GoodsNo = string.Empty;
                // BL�O���[�v�R�[�h
                delDataWork.BLGroupCode = 0;
                // BL���i�R�[�h
                delDataWork.BLGoodsCode = 0;
                // ���Е��ރR�[�h
                delDataWork.EnterpriseGanreCode = 0;
                // �̔��敪�ڕW�X�V�̏ꍇ�A
                if (kubun == kubun_SalesCode)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 44;
                    // �̔��敪�R�[�h
                    delDataWork.SalesCode = salesCode;
                }
                delDataList.Add(delDataWork);
            }
        }

        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^�̕��Ϗ���
        /// </summary>
        /// <param name="periodKun">�Ώۊ��敪</param>
        /// <param name="pastMonth">�ߋ�*����</param>
        /// <param name="kubun">�����敪</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="gcdSalesTargetList">���i�ʃf�[�^���X�g</param>
        /// <param name="unit">�[�������̒P��</param>
        /// <param name="fractionProc">�[�������敪</param>
        /// <param name="salesTarget">����</param>
        /// <param name="amountTarget">����ڕW</param>
        /// <param name="groMarginTarget">�e���ڕW</param>
        /// <param name="nowStartMonthDate">��v�N�x</param>
        /// <param name="nowEndMonthDate">��v�N�x�J�n��</param>
        /// <param name="nowYearMonth">��v�N�x�N��</param>
        /// <param name="averageDataList">���σf�[�^���X�g</param>
        /// <param name="delDataList">�폜�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�̕��Ϗ������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public void AverageGcdDate(Int32 periodKun, Int32 pastMonth, Int32 kubun, string baseCode, string enterpriseCode, ArrayList gcdSalesTargetList, Int32 unit, Int32 fractionProc, Int32 salesTarget,
            Int32 amountTarget, Int32 groMarginTarget, List<DateTime> nowStartMonthDate, List<DateTime> nowEndMonthDate,
            List<DateTime> nowYearMonth, out ArrayList averageDataList, out ArrayList delDataList)
        {
            averageDataList = new ArrayList();
            Int32 gcdSalesTargetCount = gcdSalesTargetList.Count;
            Int32 salesCode = -1;
            Int32 enterpriseGanreCode = 0;
            Int32 nowYearMonthInt = 0;
            double fractionUnit = 1;
            Int32 fractionProcess = 1;
            delDataList = new ArrayList();

            if (null != gcdSalesTargetList && gcdSalesTargetCount > 0)
            {
                double totalAmount = 0;
                double totalMoney = 0;
                double totalProfit = 0;

                for (int i = 0; i < gcdSalesTargetCount; i++)
                {
                    GcdSalesTargetWork gcdSalesTargetWork = (GcdSalesTargetWork)gcdSalesTargetList[i];
                    baseCode = gcdSalesTargetWork.SectionCode;
                    salesCode = gcdSalesTargetWork.SalesCode;
                    enterpriseGanreCode = gcdSalesTargetWork.EnterpriseGanreCode;

                    totalAmount = totalAmount + gcdSalesTargetWork.SalesTargetCount;
                    totalMoney = totalMoney + (double)gcdSalesTargetWork.SalesTargetMoney;
                    totalProfit = totalProfit + (double)gcdSalesTargetWork.SalesTargetProfit;
                }

                // �����ɐ��ʁA���z�A�e�����W�v����
                // �O��
                if (0 == periodKun)
                {
                    totalAmount = totalAmount / 12;
                    totalMoney = totalMoney / 12;
                    totalProfit = totalProfit / 12;
                }
                else
                {
                    totalAmount = totalAmount / pastMonth;
                    totalMoney = totalMoney / pastMonth;
                    totalProfit = totalProfit / pastMonth;
                }


                // �P��
                // �S�~�A
                if (unit == 1)
                {
                    fractionUnit = 100;
                }
                // ��~�A
                else if (unit == 2)
                {
                    fractionUnit = 1000;
                }
                // ���~
                else if (unit == 3)
                {
                    fractionUnit = 10000;
                }

                // �[������
                // �l�̌ܓ�
                if (fractionProc == 0)
                {
                    fractionProcess = 2;
                }
                // �؏�
                else if (fractionProc == 1)
                {
                    fractionProcess = 3;
                }
                // �؎�
                else
                {
                    fractionProcess = 1;
                }

                // UP������
                totalAmount = totalAmount * amountTarget / 100;
                totalMoney = totalMoney * salesTarget / 100;
                totalProfit = totalProfit * groMarginTarget / 100;

                // MOD 2009/07/07 杍^ --->>>
                FractionCalculate.FracCalcMoney(totalAmount, 1, fractionProcess, out totalAmount);
                // MOD 2009/07/07 杍^ ---<<<
                FractionCalculate.FracCalcMoney(totalMoney, fractionUnit, fractionProcess, out totalMoney);
                FractionCalculate.FracCalcMoney(totalProfit, fractionUnit, fractionProcess, out totalProfit);

                for (int i = 0; i < 12; i++)
                {
                    GcdSalesTargetWork averageDataWork = new GcdSalesTargetWork();
                    // ��ƃR�[�h
                    averageDataWork.EnterpriseCode = enterpriseCode;
                    // ���_�R�[�h
                    averageDataWork.SectionCode = baseCode;
                    // �ڕW�ݒ�敪
                    averageDataWork.TargetSetCd = 10;
                    // �ڕW�敪����
                    averageDataWork.TargetDivideName = string.Empty;
                    // �ڕW�敪�R�[�h
                    DateTime nowYearMonthDt = nowYearMonth[i];
                    nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                    averageDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                    // ���i���[�J�[�R�[�h
                    averageDataWork.GoodsMakerCd = 0;
                    // ���i�ԍ�
                    averageDataWork.GoodsNo = string.Empty;
                    // BL�O���[�v�R�[�h
                    averageDataWork.BLGroupCode = 0;
                    // BL���i�R�[�h
                    averageDataWork.BLGoodsCode = 0;
                    // �K�p�J�n��
                    DateTime nowStartMonthDt = nowStartMonthDate[i];
                    averageDataWork.ApplyStaDate = nowStartMonthDt;
                    // �K�p�I����
                    DateTime nowEndMonthDt = nowEndMonthDate[i];
                    averageDataWork.ApplyEndDate = nowEndMonthDt;
                    // ����ڕW����
                    averageDataWork.SalesTargetCount = totalAmount;
                    // ����ڕW���z
                    averageDataWork.SalesTargetMoney = (long)totalMoney;
                    // ����ڕW�e���z
                    averageDataWork.SalesTargetProfit = (long)totalProfit;
                    // �̔��敪�ڕW�X�V�̏ꍇ�A
                    if (kubun == kubun_SalesCode)
                    {
                        // �ڕW�Δ�敪
                        averageDataWork.TargetContrastCd = 44;
                        // �̔��敪�R�[�h
                        averageDataWork.SalesCode = salesCode;
                        // ���Е��ރR�[�h
                        averageDataWork.EnterpriseGanreCode = 0;
                    }
                    // ���i�敪�ڕW�X�V�̏ꍇ�A
                    else if (kubun == kubun_ComDivision)
                    {
                        // �ڕW�Δ�敪
                        averageDataWork.TargetContrastCd = 45;
                        // �̔��敪�R�[�h
                        averageDataWork.SalesCode = 0;
                        // ���Е��ރR�[�h
                        averageDataWork.EnterpriseGanreCode = enterpriseGanreCode;
                    }
                    averageDataList.Add(averageDataWork);
                }
            }

            for (int i = 0; i < 12; i++)
            {
                GcdSalesTargetWork delDataWork = new GcdSalesTargetWork();
                // ��ƃR�[�h
                delDataWork.EnterpriseCode = enterpriseCode;
                // ���_�R�[�h
                delDataWork.SectionCode = baseCode;
                // �ڕW�ݒ�敪
                delDataWork.TargetSetCd = 10;
                // �ڕW�敪�R�[�h
                DateTime nowYearMonthDt = nowYearMonth[i];
                nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                delDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                // ���i���[�J�[�R�[�h
                delDataWork.GoodsMakerCd = 0;
                // ���i�ԍ�
                delDataWork.GoodsNo = string.Empty;
                // BL�O���[�v�R�[�h
                delDataWork.BLGroupCode = 0;
                // BL���i�R�[�h
                delDataWork.BLGoodsCode = 0;
                // �̔��敪�ڕW�X�V�̏ꍇ�A
                if (kubun == kubun_SalesCode)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 44;
                    // �̔��敪�R�[�h
                    delDataWork.SalesCode = salesCode;
                    // ���Е��ރR�[�h
                    delDataWork.EnterpriseGanreCode = 0;
                }
                // ���i�敪�ڕW�X�V�̏ꍇ�A
                else if (kubun == kubun_ComDivision)
                {
                    // �ڕW�Δ�敪
                    delDataWork.TargetContrastCd = 45;
                    // �̔��敪�R�[�h
                    delDataWork.SalesCode = 0;
                    // ���Е��ރR�[�h
                    delDataWork.EnterpriseGanreCode = enterpriseGanreCode;
                }
                delDataList.Add(delDataWork);
            }
        }


        /// <summary>
        /// DateTime��Int����
        /// </summary>
        /// <param name="yearMonthDt">����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : DateTime��Int�������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public Int32 DateTimeToInt(DateTime yearMonthDt)
        {
            string yearMonthStr = yearMonthDt.ToString("yyyyMMdd");
            //yearMonthStr = yearMonthStr.Replace("/", "");
            //yearMonthStr = yearMonthStr.Replace(":", "");
            yearMonthStr = yearMonthStr.Substring(0, 6);
            Int32 yearMonthInt = Convert.ToInt32(yearMonthStr);
            return yearMonthInt;
        }
        #endregion

        #region �� �W�v�p�f�[�^���������� ��
        /// <summary>
        /// ���㌎���W�v�f�[�^���������i���_�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���㌎���W�v�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2012/11/12 yangyi</br>
        /// <br>             redmine#31515 No.1633 �ڕW�����ݒ� �ڕW�ݒ�͕s��������</br>
        /// </remarks>
        private int GetSectionMTtList(string baseCode, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.ADDUPYEARMONTHRF, ");
                sb.Append(" A.ADDUPSECCODERF, ");
                sb.Append(" SUM(A.TOTALSALESCOUNTRF) AS SALESCOUNTRF, ");
                // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                sb.Append(" SUM(A.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF, ");
                sb.Append(" SUM(A.DISCOUNTPRICERF) AS DISCOUNTPRICERF, ");
                // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                sb.Append(" SUM(A.SALESMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.GROSSPROFITRF) AS PROFITRF ");
                sb.Append(" FROM MTTLSALESSLIPRF A, SECINFOSETRF B ");
                sb.Append(" WHERE ");
                sb.Append(" A.ADDUPYEARMONTHRF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.ADDUPYEARMONTHRF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.ADDUPSECCODERF = B.SECTIONCODERF ");
                // ���яW�v�敪
                sb.Append(" AND A.RSLTTTLDIVCDRF=@RSLTTTLDIVCD ");
                // ADD 2009/06/18 --->>>
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // ADD 2009/06/18 ---<<<

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.ADDUPSECCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.ADDUPYEARMONTHRF, A.ADDUPSECCODERF ");
                sb.Append(" ORDER BY A.ADDUPSECCODERF ");


                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 --->>>
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 ---<<<


                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                // ADD 2009/06/18 --->>>
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(10);
                // ADD 2009/06/18 ---<<<

                sqlCommand.CommandText = sb.ToString();

                //using (StreamWriter sw = new StreamWriter(@"C:\CopyFile.log"))
                //{
                //    sw.WriteLine(sb.ToString());
                //    sw.WriteLine(yearMonthEndInt);
                //    sw.WriteLine(yearMonthBegInt);
                //}

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                    long salesretgoodprice = 0;
                    long discount = 0;
                    // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        empSalesTargetWork.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        empSalesTargetWork.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���������i���_�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetSectionEmpList(string baseCode, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM EMPSALESTARGETRF A, SECINFOSETRF B ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(10);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        /// <summary>
        /// ���㌎���W�v�f�[�^���������i���Ӑ�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���㌎���W�v�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2012/11/12 yangyi</br>
        /// <br>             redmine#31515 No.1633 �ڕW�����ݒ� �ڕW�ݒ�͕s��������</br>
        /// </remarks>
        private int GetCustomerMTtList(string baseCode, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.ADDUPYEARMONTHRF, ");
                sb.Append(" A.ADDUPSECCODERF, ");
                sb.Append(" A.CUSTOMERCODERF, ");
                sb.Append(" SUM(A.TOTALSALESCOUNTRF) AS SALESCOUNTRF, ");
                // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                sb.Append(" SUM(A.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF, ");
                sb.Append(" SUM(A.DISCOUNTPRICERF) AS DISCOUNTPRICERF, ");
                // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                sb.Append(" SUM(A.SALESMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.GROSSPROFITRF) AS PROFITRF ");
                sb.Append(" FROM MTTLSALESSLIPRF A, CUSTOMERRF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.ADDUPYEARMONTHRF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.ADDUPYEARMONTHRF >= @BEGADDUPYEARMONTHRF ");
                // ��ƃR�[�h
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                // �_���폜�敪
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                // ���яW�v�敪
                sb.Append(" AND A.RSLTTTLDIVCDRF=@RSLTTTLDIVCD ");
                // �u�Ǘ����_�R�[�h�v�Ɓu���Ӑ�R�[�h�v�����Ӑ�}�X�^�ɖ��o�^�̏ꍇ�͍쐬�ΏۂƂ��܂���B
                sb.Append(" AND A.ADDUPSECCODERF + A.CUSTOMERCODERF = C.MNGSECTIONCODERF + C.CUSTOMERCODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                // ADD 2009/06/18 --->>>
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // ADD 2009/06/18 ---<<<

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.ADDUPSECCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.ADDUPYEARMONTHRF, A.ADDUPSECCODERF, A.CUSTOMERCODERF ");
                sb.Append(" ORDER BY A.ADDUPSECCODERF, A.CUSTOMERCODERF ");


                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                // ADD 2009/06/18 --->>>
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 ---<<<


                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // ADD 2009/06/18 --->>>
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(10);
                // ADD 2009/06/18 ---<<<

                sqlCommand.CommandText = sb.ToString(); ;

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string custmoerCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                    long salesretgoodprice = 0;
                    long discount = 0;
                    // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    custmoerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")).ToString();
                    compareKey = sectionCode.Trim() + custmoerCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        custSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + custmoerCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        custSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + custmoerCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���������i���Ӑ�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetCustomerCusList(string baseCode, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        A.CUSTOMERCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, CUSTOMERRF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                // �u�Ǘ����_�R�[�h�v�Ɓu���Ӑ�R�[�h�v�����Ӑ�}�X�^�ɖ��o�^�̏ꍇ�͍쐬�ΏۂƂ��܂���B
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF + A.CUSTOMERCODERF = C.MNGSECTIONCODERF + C.CUSTOMERCODERF ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, A.CUSTOMERCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, A.CUSTOMERCODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(30);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string customerCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    customerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")).ToString();
                    compareKey = sectionCode.Trim() + customerCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + customerCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + customerCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���㌎���W�v�f�[�^���������i�S���ҁj
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeDivCd">�]�ƈ��敪</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���㌎���W�v�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2012/11/12 yangyi</br>
        /// <br>             redmine#33218 No.1633 �ڕW�����ݒ� �ڕW�ݒ�͕s��������</br>
        /// </remarks>
        private int GetTantosyaMTtList(string baseCode, string enterpriseCode, Int32 employeeDivCd, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.ADDUPYEARMONTHRF, ");
                sb.Append(" A.ADDUPSECCODERF, ");
                sb.Append(" A.EMPLOYEECODERF, ");
                sb.Append(" SUM(A.TOTALSALESCOUNTRF) AS SALESCOUNTRF, ");
                // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                sb.Append(" SUM(A.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF, ");
                sb.Append(" SUM(A.DISCOUNTPRICERF) AS DISCOUNTPRICERF, ");
                // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                sb.Append(" SUM(A.SALESMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.GROSSPROFITRF) AS PROFITRF ");
                sb.Append(" FROM MTTLSALESSLIPRF A, EMPLOYEERF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.ADDUPYEARMONTHRF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.ADDUPYEARMONTHRF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                // ���㌎���W�v�f�[�^�́u�v�㋒�_�R�[�h�E�]�ƈ��R�[�h�v���]�ƈ��}�X�^�́u�������_�E�]�ƈ��R�[�h�v�ƈ�v����ꍇ�̂ݑΏۂƂ���
                sb.Append(" AND A.ADDUPSECCODERF + A.EMPLOYEECODERF = C.BELONGSECTIONCODERF + C.EMPLOYEECODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                // �Ώېݒ�}�X�^���u�S���ҁF�s���v�ł��u���сv�̏ꍇ�A�u�P�O�v��ΏۂƂ���
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // ���яW�v�敪
                sb.Append(" AND A.RSLTTTLDIVCDRF=@RSLTTTLDIVCD ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.ADDUPSECCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.ADDUPYEARMONTHRF, A.ADDUPSECCODERF, A.EMPLOYEECODERF ");
                sb.Append(" ORDER BY A.ADDUPSECCODERF, A.EMPLOYEECODERF ");


                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                SqlParameter findRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);


                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(employeeDivCd);
                findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sb.ToString(); ;

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string employeeCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                    long salesretgoodprice = 0;
                    long discount = 0;
                    // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    employeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    compareKey = sectionCode.Trim() + employeeCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        empSalesTargetWork.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        empSalesTargetList.Add(empSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + employeeCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        empSalesTargetWork.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        empSalesTargetList.Add(empSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + employeeCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^���������i�S���ҁj
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="employeeDivCd">�]�ƈ��敪</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetTantosyaEmpList(string baseCode, Int32 employeeDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        A.EMPLOYEECODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM EMPSALESTARGETRF A, EMPLOYEERF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�́u���_�R�[�h�E�]�ƈ��R�[�h�v���]�ƈ��}�X�^�́u�������_�E�]�ƈ��R�[�h�v�ƈ�v����ꍇ�̂ݑΏۂƂ���
                sb.Append(" AND A.SECTIONCODERF + A.EMPLOYEECODERF = C.BELONGSECTIONCODERF + C.EMPLOYEECODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, A.EMPLOYEECODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, A.EMPLOYEECODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(22);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 10:�S����
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(employeeDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string employeeCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    employeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    compareKey = sectionCode.Trim() + employeeCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + employeeCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + employeeCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���㌎���W�v�f�[�^���������i�n��j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���㌎���W�v�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2012/11/12 yangyi</br>
        /// <br>             redmine#33218 No.1633 �ڕW�����ݒ� �ڕW�ݒ�͕s��������</br>
        /// </remarks>
        private int GetDistrictMTtList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.ADDUPYEARMONTHRF, ");
                sb.Append(" A.ADDUPSECCODERF, ");
                sb.Append(" C.SALESAREACODERF, ");
                sb.Append(" SUM(A.TOTALSALESCOUNTRF) AS SALESCOUNTRF, ");
                // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                sb.Append(" SUM(A.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF, ");
                sb.Append(" SUM(A.DISCOUNTPRICERF) AS DISCOUNTPRICERF, ");
                // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                sb.Append(" SUM(A.SALESMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.GROSSPROFITRF) AS PROFITRF ");
                sb.Append(" FROM MTTLSALESSLIPRF A, SECINFOSETRF B, CUSTOMERRF C, USERGDBDURF D ");
                sb.Append(" WHERE ");
                sb.Append(" A.ADDUPYEARMONTHRF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.ADDUPYEARMONTHRF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.ADDUPSECCODERF = B.SECTIONCODERF ");
                // ���㌎���W�v�f�[�^�́u�v�㋒�_�R�[�h�E���Ӑ�R�[�h�v�Ɓu�Ǘ����_�R�[�h�E���Ӑ�R�[�h�v����v����
                sb.Append(" AND A.ADDUPSECCODERF + A.CUSTOMERCODERF = C.MNGSECTIONCODERF + C.CUSTOMERCODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND D.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND A.ENTERPRISECODERF = D.ENTERPRISECODERF ");
                sb.Append(" AND C.SALESAREACODERF = D.GUIDECODERF ");
                // ���яW�v�敪
                sb.Append(" AND A.RSLTTTLDIVCDRF=@RSLTTTLDIVCD ");
                // ADD 2009/06/18 --->>>
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // ADD 2009/06/18 ---<<<

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.ADDUPSECCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.ADDUPYEARMONTHRF, A.ADDUPSECCODERF, C.SALESAREACODERF ");
                sb.Append(" ORDER BY A.ADDUPSECCODERF, C.SALESAREACODERF ");


                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);
                SqlParameter findRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 --->>>
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 ---<<<


                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // �̔��G���A�R�[�h 21
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);
                findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                // ADD 2009/06/18 --->>>
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(10);
                // ADD 2009/06/18 ---<<<

                sqlCommand.CommandText = sb.ToString(); ;

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string salesAreaCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                    long salesretgoodprice = 0;
                    long discount = 0;
                    // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    salesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF")).ToString();
                    compareKey = sectionCode.Trim() + salesAreaCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        custSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesAreaCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        custSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesAreaCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���������i�n��j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�R�[�h</param>
        /// <param name="targetContrastCd">�ڕW�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetDistrictCusList(string baseCode, Int32 userGuideDivCd, Int32 targetContrastCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        D.SALESAREACODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C, CUSTOMERRF D ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                sb.Append(" AND D.LOGICALDELETECODERF=@DLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = D.SALESAREACODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");
                // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�́u���_�R�[�h�E���Ӑ�R�[�h�v�Ɓu�Ǘ����_�R�[�h�E���Ӑ�R�[�h�v����v����
                sb.Append(" AND A.ENTERPRISECODERF = D.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF + A.CUSTOMERCODERF = D.MNGSECTIONCODERF + D.CUSTOMERCODERF ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, D.SALESAREACODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, D.SALESAREACODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findDLogicalDeleteCode = sqlCommand.Parameters.Add("@DLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(targetContrastCd);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findDLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // �̔��G���A�R�[�h 21
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string salesAreaCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    salesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF")).ToString();
                    compareKey = sectionCode.Trim() + salesAreaCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesAreaCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesAreaCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���㌎���W�v�f�[�^���������i�Ǝ�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���㌎���W�v�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2012/11/12 yangyi</br>
        /// <br>             redmine#33218 No.1633 �ڕW�����ݒ� �ڕW�ݒ�͕s��������</br>
        /// </remarks>
        private int GetTypeBusinessMTtList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.ADDUPYEARMONTHRF, ");
                sb.Append(" A.ADDUPSECCODERF, ");
                sb.Append(" C.BUSINESSTYPECODERF, ");
                sb.Append(" SUM(A.TOTALSALESCOUNTRF) AS SALESCOUNTRF, ");
                // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                sb.Append(" SUM(A.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF, ");
                sb.Append(" SUM(A.DISCOUNTPRICERF) AS DISCOUNTPRICERF, ");
                // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                sb.Append(" SUM(A.SALESMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.GROSSPROFITRF) AS PROFITRF ");
                sb.Append(" FROM MTTLSALESSLIPRF A, SECINFOSETRF B, CUSTOMERRF C, USERGDBDURF D ");
                sb.Append(" WHERE ");
                sb.Append(" A.ADDUPYEARMONTHRF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.ADDUPYEARMONTHRF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                sb.Append(" AND D.LOGICALDELETECODERF=@DLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.ADDUPSECCODERF = B.SECTIONCODERF ");
                // ���㌎���W�v�f�[�^�́u�v�㋒�_�R�[�h�E���Ӑ�R�[�h�v�Ɓu�Ǘ����_�R�[�h�E���Ӑ�R�[�h�v����v����
                sb.Append(" AND A.ADDUPSECCODERF + A.CUSTOMERCODERF = C.MNGSECTIONCODERF + C.CUSTOMERCODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND D.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND A.ENTERPRISECODERF = D.ENTERPRISECODERF ");
                sb.Append(" AND C.BUSINESSTYPECODERF = D.GUIDECODERF ");
                // ���яW�v�敪
                sb.Append(" AND A.RSLTTTLDIVCDRF=@RSLTTTLDIVCD ");
                // ADD 2009/06/18 --->>>
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // ADD 2009/06/18 ---<<<

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.ADDUPSECCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.ADDUPYEARMONTHRF, A.ADDUPSECCODERF, C.BUSINESSTYPECODERF ");
                sb.Append(" ORDER BY A.ADDUPSECCODERF, C.BUSINESSTYPECODERF ");


                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findDLogicalDeleteCode = sqlCommand.Parameters.Add("@DLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);
                SqlParameter findRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 --->>>
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 ---<<<


                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findDLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // �Ǝ�R�[�h 33
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);
                findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                // ADD 2009/06/18 --->>>
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(10);
                // ADD 2009/06/18 ---<<<

                sqlCommand.CommandText = sb.ToString(); ;

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string businessTypeCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                    long salesretgoodprice = 0;
                    long discount = 0;
                    // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    businessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF")).ToString();
                    compareKey = sectionCode.Trim() + businessTypeCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        custSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + businessTypeCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        custSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + businessTypeCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���������i�Ǝ�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�R�[�h</param>
        /// <param name="targetContrastCd">�ڕW�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetTypeBusinessCusList(string baseCode, Int32 userGuideDivCd, Int32 targetContrastCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        D.BUSINESSTYPECODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C, CUSTOMERRF D ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                sb.Append(" AND D.LOGICALDELETECODERF=@DLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = D.BUSINESSTYPECODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");
                // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�́u���_�R�[�h�E���Ӑ�R�[�h�v�Ɓu�Ǘ����_�R�[�h�E���Ӑ�R�[�h�v����v����
                sb.Append(" AND A.ENTERPRISECODERF = D.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF + A.CUSTOMERCODERF = D.MNGSECTIONCODERF + D.CUSTOMERCODERF ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, D.BUSINESSTYPECODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, D.BUSINESSTYPECODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findDLogicalDeleteCode = sqlCommand.Parameters.Add("@DLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(targetContrastCd);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findDLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // �Ǝ�R�[�h 33
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string businessTypeCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    businessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF")).ToString();
                    compareKey = sectionCode.Trim() + businessTypeCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + businessTypeCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + businessTypeCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���㌎���W�v�f�[�^���������i�̔��敪�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���㌎���W�v�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2012/11/12 yangyi</br>
        /// <br>             redmine#33218 No.1633 �ڕW�����ݒ� �ڕW�ݒ�͕s��������</br>
        /// </remarks>
        private int GetSalesDivisionMTtList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.ADDUPYEARMONTHRF, ");
                sb.Append(" A.ADDUPSECCODERF, ");
                sb.Append(" A.SALESCODERF, ");
                sb.Append(" SUM(A.TOTALSALESCOUNTRF) AS SALESCOUNTRF, ");
                // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                sb.Append(" SUM(A.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF, ");
                sb.Append(" SUM(A.DISCOUNTPRICERF) AS DISCOUNTPRICERF, ");
                // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                sb.Append(" SUM(A.SALESMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.GROSSPROFITRF) AS PROFITRF ");
                sb.Append(" FROM MTTLSALESSLIPRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.ADDUPYEARMONTHRF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.ADDUPYEARMONTHRF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.ADDUPSECCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND A.SALESCODERF = C.GUIDECODERF ");
                // ���яW�v�敪
                sb.Append(" AND A.RSLTTTLDIVCDRF=@RSLTTTLDIVCD ");
                // ADD 2009/06/18 --->>>
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // ADD 2009/06/18 ---<<<

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.ADDUPSECCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.ADDUPYEARMONTHRF, A.ADDUPSECCODERF, A.SALESCODERF ");
                sb.Append(" ORDER BY A.ADDUPSECCODERF, A.SALESCODERF ");


                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);
                SqlParameter findRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 --->>>
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 ---<<<


                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j 71
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);
                findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                // ADD 2009/06/18 --->>>
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(10);
                // ADD 2009/06/18 ---<<<

                sqlCommand.CommandText = sb.ToString(); ;

                myReader = sqlCommand.ExecuteReader();

                GcdSalesTargetWork gcdSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string salesCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList gcdSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                    long salesretgoodprice = 0;
                    long discount = 0;
                    // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    salesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF")).ToString();
                    compareKey = sectionCode.Trim() + salesCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(gcdSalesTargetList);
                        gcdSalesTargetList = new ArrayList();
                        gcdSalesTargetWork = new GcdSalesTargetWork();
                        gcdSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        gcdSalesTargetWork.SectionCode = sectionCode;
                        gcdSalesTargetWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                        gcdSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        gcdSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        gcdSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        gcdSalesTargetWork.SalesTargetMoney = gcdSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        gcdSalesTargetList.Add(gcdSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        gcdSalesTargetWork = new GcdSalesTargetWork();
                        gcdSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        gcdSalesTargetWork.SectionCode = sectionCode;
                        gcdSalesTargetWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                        gcdSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        gcdSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        gcdSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        gcdSalesTargetWork.SalesTargetMoney = gcdSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        gcdSalesTargetList.Add(gcdSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesCode;
                    }
                }

                if (null != gcdSalesTargetList && gcdSalesTargetList.Count > 0)
                {
                    allDataList.Add(gcdSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^���������i�̔��敪�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetSalesDivisionGcdList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        A.SALESCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM GCDSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = A.SALESCODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, A.SALESCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, A.SALESCODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(44);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j 71
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                GcdSalesTargetWork gcdSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string salesCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList gcdSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    salesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF")).ToString();
                    compareKey = sectionCode.Trim() + salesCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(gcdSalesTargetList);
                        gcdSalesTargetList = new ArrayList();
                        gcdSalesTargetWork = new GcdSalesTargetWork();
                        gcdSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        gcdSalesTargetWork.SectionCode = sectionCode;
                        gcdSalesTargetWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                        gcdSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        gcdSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        gcdSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        gcdSalesTargetList.Add(gcdSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        gcdSalesTargetWork = new GcdSalesTargetWork();
                        gcdSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        gcdSalesTargetWork.SectionCode = sectionCode;
                        gcdSalesTargetWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                        gcdSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        gcdSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        gcdSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        gcdSalesTargetList.Add(gcdSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesCode;
                    }
                }

                if (null != gcdSalesTargetList && gcdSalesTargetList.Count > 0)
                {
                    allDataList.Add(gcdSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���������i���_�˓��Ӑ�Đݒ�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreSecCustomerEmpList(string baseCode, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(30);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���������i���Ӑ�Đݒ�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreCustomerEmpList(string baseCode, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        C.EMPLOYEECODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, CUSTOMERRF B, EMPLOYEERF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");

                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.CUSTOMERCODERF = B.CUSTOMERCODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                // ���Ӑ�}�X�^���Q�Ƃ��A���Ӑ�}�X�^�́u�Ǘ����_�R�[�h�E�ڋq�S���]�ƈ��R�[�h�v���]�ƈ��}�X�^�́u�������_�E�]�ƈ��R�[�h�v�ƈ�v����ꍇ�̂ݑΏۂƂ���@
                sb.Append(" AND B.MNGSECTIONCODERF + B.CUSTOMERAGENTCDRF = C.BELONGSECTIONCODERF + EMPLOYEECODERF ");
                // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�́u���_�R�[�h�E���Ӑ�R�[�h�v�Ɓu�Ǘ����_�R�[�h�E���Ӑ�R�[�h�v����v����
                sb.Append(" AND A.SECTIONCODERF + A.CUSTOMERCODERF = B.MNGSECTIONCODERF + B.CUSTOMERCODERF ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, C.EMPLOYEECODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(30);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string compareKey = string.Empty;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string employeeCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    employeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    compareKey = sectionCode.Trim() + employeeCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + employeeCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + employeeCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^���������i���_�˒S���ҍĐݒ�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="employeeDivCd">�]�ƈ��R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreSecTantosyaEmpList(string baseCode, Int32 employeeDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM EMPSALESTARGETRF A, SECINFOSETRF B ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND A.EMPLOYEEDIVCDRF = @EMPLOYEEDIVCD ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(22);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 10:�S����
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(employeeDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^���������i�S���ҍĐݒ�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="employeeDivCd">�]�ƈ��R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreTantosyaEmpList(string baseCode, Int32 employeeDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM EMPSALESTARGETRF A, SECINFOSETRF B, EMPLOYEERF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND A.EMPLOYEECODERF = C.EMPLOYEECODERF ");
                sb.Append(" AND A.EMPLOYEEDIVCDRF = @EMPLOYEEDIVCD ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(22);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 10:�S����
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(employeeDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���������i�n��j�ڕW�ˍs��
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetDistrictDOCusList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        A.SALESAREACODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = A.SALESAREACODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, A.SALESAREACODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, A.SALESAREACODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(32);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // �̔��G���A�R�[�h 21
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;
                string salesAreaCode = string.Empty;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    salesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF")).ToString();
                    compareKey = sectionCode.Trim() + salesAreaCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesAreaCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesAreaCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���������i�n��Đݒ�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreDistrictCusList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = A.SALESAREACODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(32);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // �̔��G���A�R�[�h 21
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���������i�Ǝ�Đݒ�j���_�p
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreTypeBusinessCusList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = A.BUSINESSTYPECODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(31);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // �Ǝ�R�[�h 33
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���������i�Ǝ�j�Ǝ�p
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetTypeBusinessTBCusList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        A.BUSINESSTYPECODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = A.BUSINESSTYPECODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, A.BUSINESSTYPECODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, A.BUSINESSTYPECODERF  ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(31);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // �Ǝ�R�[�h 33
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                string compareKey = string.Empty;
                string businessTypeCode = string.Empty;
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    businessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF")).ToString();
                    compareKey = sectionCode.Trim() + businessTypeCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + businessTypeCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + businessTypeCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^���������i�̔��敪�Đݒ�j
        /// </summary>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="yearMonthBegInt">�J�n���t</param>
        /// <param name="yearMonthEndInt">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="allDataList">�߂郁�b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�f�[�^�����������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreSalesDivisionGcdList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //select�R�}���h�̐���
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM GCDSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = A.SALESCODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");

                // �u00�v�͑S�đΏ�
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(44);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j 71
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        #endregion

        # region �� �]�ƈ��ʁA���Ӑ�ʁA���i�ʔ���ڕW�ݒ�}�X�^�����폜���� ��
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="empsalestargetList">�]�ƈ��ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.30</br>
        private int DeleteEmpSalesTargetProc(ArrayList empsalestargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            string sqlStr = string.Empty;
            try
            {

                for (int i = 0; i < empsalestargetList.Count; i++)
                {
                    EmpSalesTargetWork empsalestargetWork = empsalestargetList[i] as EmpSalesTargetWork;

                    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                    sqlStr = "DELETE FROM EMPSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                    if (!"00".Equals(empsalestargetWork.SectionCode))
                    {
                        sqlStr += " AND SECTIONCODERF=@FINDSECTIONCODE ";
                    }
                    sqlStr += " AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE  ";
                    // �]�ƈ��R�[�h
                    if (!string.IsNullOrEmpty(empsalestargetWork.EmployeeCode.Trim()))
                    {
                        sqlStr += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE ";
                    }

                    sqlCommand.CommandText = sqlStr;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    if (!"00".Equals(empsalestargetWork.SectionCode))
                    {
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                    }
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                    SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                    // �]�ƈ��R�[�h
                    if (!string.IsNullOrEmpty(empsalestargetWork.EmployeeCode.Trim()))
                    {
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                        findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EmployeeCode);
                    }


                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                    findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                    findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);


                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="custSalesTargetList">���Ӑ�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.30</br>
        private int DeleteCustSalesTargetProc(ArrayList custSalesTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            string sqlStr = string.Empty;
            try
            {

                for (int i = 0; i < custSalesTargetList.Count; i++)
                {
                    CustSalesTargetWork custSalesTargetWork = custSalesTargetList[i] as CustSalesTargetWork;

                    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                    sqlStr = "DELETE FROM CUSTSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                    // ���_�R�[�h
                    if (!"00".Equals(custSalesTargetWork.SectionCode))
                    {
                        sqlStr += " AND SECTIONCODERF=@FINDSECTIONCODE ";
                    }
                    // ���Ӑ�R�[�h
                    if (-1 != custSalesTargetWork.CustomerCode)
                    {
                        sqlStr += " AND CUSTOMERCODERF=@FINDCUSTOMERCODE ";
                    }
                    // �Ǝ�R�[�h
                    if (-1 != custSalesTargetWork.BusinessTypeCode)
                    {
                        sqlStr += " AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE ";
                    }
                    // �̔��G���A�R�[�h
                    if (-1 != custSalesTargetWork.SalesAreaCode)
                    {
                        sqlStr += " AND SALESAREACODERF=@FINDSALESAREACODE ";
                    }
                    sqlStr += " AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE ";
                    
                    
                    
                    sqlCommand.CommandText = sqlStr;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // ���_�R�[�h
                    if (!"00".Equals(custSalesTargetWork.SectionCode))
                    {
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                    }
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    // �̔��G���A�R�[�h
                    if (-1 != custSalesTargetWork.SalesAreaCode)
                    {
                        SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                    }

                    // �Ǝ�R�[�h
                    if (-1 != custSalesTargetWork.BusinessTypeCode)
                    {
                        SqlParameter findParaBusinessTypeCode = sqlCommand.Parameters.Add("@FINDBUSINESSTYPECODE", SqlDbType.Int);
                        findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);

                    }
                    // ���Ӑ�R�[�h
                    if (-1 != custSalesTargetWork.CustomerCode)
                    {
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);
                    }

                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="gcdSalesTargetList">�]�ƈ��ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.30</br>
        private int DeleteGcdSalesTargetProc(ArrayList gcdSalesTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            string sqlStr = string.Empty;
            try
            {

                for (int i = 0; i < gcdSalesTargetList.Count; i++)
                {
                    GcdSalesTargetWork gcdSalesTargetWork = gcdSalesTargetList[i] as GcdSalesTargetWork;

                    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                    sqlStr = "DELETE FROM GCDSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                    if (!"00".Equals(gcdSalesTargetWork.SectionCode))
                    {
                        sqlStr += " AND SECTIONCODERF=@FINDSECTIONCODE ";
                    }
                    sqlStr += " AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND BLGROUPCODERF=@FINDBLGROUPCODE AND BLGOODSCODERF=@FINDBLGOODSCODE ";
                    // �̔��敪�R�[�h
                    if (-1 != gcdSalesTargetWork.SalesCode)
                    {
                        sqlStr += " AND SALESCODERF=@FINDSALESCODE ";
                    }
                    sqlStr += " AND ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE ";

                    sqlCommand.CommandText = sqlStr;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    if (!"00".Equals(gcdSalesTargetWork.SectionCode))
                    {
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(gcdSalesTargetWork.SectionCode);
                    }

                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    // �̔��敪�R�[�h
                    if (-1 != gcdSalesTargetWork.SalesCode)
                    {
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.SalesCode);
                    }
                    SqlParameter findParaEnterpriseGanreCode = sqlCommand.Parameters.Add("@FINDENTERPRISEGANRECODE", SqlDbType.Int);

                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(gcdSalesTargetWork.EnterpriseCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(gcdSalesTargetWork.TargetDivideCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.GoodsMakerCd);
                    if (string.IsNullOrEmpty(gcdSalesTargetWork.GoodsNo.Trim()))
                    {
                        findParaGoodsNo.Value = gcdSalesTargetWork.GoodsNo;
                    }
                    else
                    {
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(gcdSalesTargetWork.GoodsNo);
                    }

                    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.BLGoodsCode);
                    findParaEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.EnterpriseGanreCode);

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion
    }
}
