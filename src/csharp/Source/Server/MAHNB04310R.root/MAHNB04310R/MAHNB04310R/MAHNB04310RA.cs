using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ挳�������f�[�^���oDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ挳�������f�[�^���o�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22035 �O�� �O��</br>
    /// <br>Date       : 2007.05.08</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>           : 2007.11.07 ���ʊ�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>           : 2007.12.10 EdiTakeInDate(EDI�捞��)��Int32��DateTime�ɕύX</br>
    /// </remarks>
    [Serializable]
    public class LedgerDepsitMainWorkDB : RemoteDB
    {
        /// <summary>
        /// ���Ӑ挳�������f�[�^���oDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        /// </remarks>
        public LedgerDepsitMainWorkDB()
            :
        base("MAHNB04311D", "Broadleaf.Application.Remoting.ParamData.LedgerDepsitMainWork", "DEPSITMAINRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �����擾����
        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ挳�������f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="ledgerDepsitMainWork">�������ʁi�����j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startCustomerCode">���Ӑ�R�[�h(�J�n)</param>
        /// <param name="endCustomerCode">���Ӑ�R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓��Ӑ挳�������f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        public int Search(out object ledgerDepsitMainWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startCustomerCode, int endCustomerCode, int startAddUpDate, int endAddUpDate, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ledgerDepsitMainWork = null;

            try
            {
                status = SearchProc(out ledgerDepsitMainWork, enterpriseCode, addUpSecCodeList, startCustomerCode, endCustomerCode, startAddUpDate, endAddUpDate, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LedgerDepsitMainWorkDB.Search Exception=" + ex.Message);
                ledgerDepsitMainWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ挳�������f�[�^���oLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="ledgerDepsitMainWork">�������ʁi�����j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startCustomerCode">���Ӑ�R�[�h(�J�n)</param>
        /// <param name="endCustomerCode">���Ӑ�R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓��Ӑ挳�������f�[�^���oLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        private int SearchProc(out object ledgerDepsitMainWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startCustomerCode, int endCustomerCode, int startAddUpDate, int endAddUpDate, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ledgerDepsitMainWork = null;
            ArrayList al = new ArrayList();   //���o����

            string sqlText = string.Empty;

            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   MAIN.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,MAIN.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += "  ,MAIN.DEPOSITDEBITNOTECDRF" + Environment.NewLine;
                sqlText += "  ,MAIN.DEPOSITSLIPNORF" + Environment.NewLine;
                sqlText += "  ,MAIN.SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += "  ,MAIN.INPUTDEPOSITSECCDRF" + Environment.NewLine;
                sqlText += "  ,MAIN.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "  ,MAIN.UPDATESECCDRF" + Environment.NewLine;
                sqlText += "  ,MAIN.DEPOSITDATERF" + Environment.NewLine;
                sqlText += "  ,MAIN.ADDUPADATERF" + Environment.NewLine;
                sqlText += "  ,MAIN.DEPOSITAGENTCODERF" + Environment.NewLine;
                sqlText += "  ,MAIN.DEPOSITAGENTNMRF" + Environment.NewLine;
                sqlText += "  ,MAIN.DEPOSITINPUTAGENTCDRF" + Environment.NewLine;
                sqlText += "  ,MAIN.DEPOSITINPUTAGENTNMRF" + Environment.NewLine;
                sqlText += "  ,MAIN.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,MAIN.CUSTOMERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAIN.CUSTOMERNAME2RF" + Environment.NewLine;
                sqlText += "  ,MAIN.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += "  ,MAIN.CLAIMCODERF" + Environment.NewLine;
                sqlText += "  ,MAIN.CLAIMNAMERF" + Environment.NewLine;
                sqlText += "  ,MAIN.CLAIMNAME2RF" + Environment.NewLine;
                sqlText += "  ,MAIN.CLAIMSNMRF" + Environment.NewLine;
                sqlText += "  ,MAIN.OUTLINERF" + Environment.NewLine;
                sqlText += "  ,DTL.DEPOSITROWNORF" + Environment.NewLine;
                sqlText += "  ,DTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += "  ,DTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += "  ,DTL.MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += "  ,DTL.DEPOSITRF" + Environment.NewLine;
                sqlText += "  ,DTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM DEPSITMAINRF AS MAIN" + Environment.NewLine;
                sqlText += "LEFT JOIN DEPSITDTLRF AS DTL ON (MAIN.ENTERPRISECODERF=DTL.ENTERPRISECODERF AND MAIN.ACPTANODRSTATUSRF=DTL.ACPTANODRSTATUSRF AND MAIN.DEPOSITSLIPNORF=DTL.DEPOSITSLIPNORF ) " + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    // Where���̍쐬
                    bool result = this.MakeWhereString(sqlCommand, enterpriseCode, addUpSecCodeList, startCustomerCode,�@endCustomerCode, startAddUpDate, endAddUpDate);
                    if (!result) return status;

                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        try
                        {
                            //���Ӑ挳�������f�[�^���X�g�i�[����
                            this.SetListFromSQLReader(ref status, ref al, myReader);
                        }
                        finally
                        {
                            if (myReader != null) myReader.Close();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LedgerDepsitMainWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            ledgerDepsitMainWork = al;

            return status;
        }
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SQLConnection</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startCustomerCode">���Ӑ�R�[�h(�J�n)</param>
        /// <param name="endCustomerCode">���Ӑ�R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <returns>Where����������</returns>
        private bool MakeWhereString(SqlCommand sqlCommand, string enterpriseCode, ArrayList addUpSecCodeList, int startCustomerCode, int endCustomerCode,
            int startAddUpDate, int endAddUpDate)
        {
            #region WHERE���쐬
            sqlCommand.CommandText += " WHERE";

            // ��ƃR�[�h
            sqlCommand.CommandText += " MAIN.ENTERPRISECODERF=@FINDENTERPRISECODE";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            // �_���폜�敪
            sqlCommand.CommandText += " AND MAIN.LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            // �v����t
            if (startAddUpDate <= endAddUpDate)
            {
                if (startAddUpDate == endAddUpDate)
                {
                    sqlCommand.CommandText +=" AND MAIN.ADDUPADATERF=@FINDADDUPADATE";
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPADATE", SqlDbType.Int);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                }
                else
                {
                    sqlCommand.CommandText +=" AND MAIN.ADDUPADATERF>=@FINDSTARTADDUPADATE AND MAIN.ADDUPADATERF<=@FINDENDADDUPADATE";
                    SqlParameter paraStartAddUpDate = sqlCommand.Parameters.Add("@FINDSTARTADDUPADATE", SqlDbType.Int);
                    paraStartAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                    SqlParameter paraEndAddUpDate = sqlCommand.Parameters.Add("@FINDENDADDUPADATE", SqlDbType.Int);
                    paraEndAddUpDate.Value = SqlDataMediator.SqlSetInt32(endAddUpDate);
                }
            }
            else
            {
                return false;
            }

            //������R�[�h
            if (startCustomerCode != 0)
            {
                sqlCommand.CommandText += " AND MAIN.CLAIMCODERF>=@STCUSTOMERCODE";
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(startCustomerCode);
            }

            if (endCustomerCode != 0)
            {
                sqlCommand.CommandText += " AND MAIN.CLAIMCODERF<=@EDCUSTOMERCODE";
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(endCustomerCode);
            }

            // �v�㋒�_
            StringBuilder whereSectionCode = new StringBuilder();
            if (addUpSecCodeList.Count > 0)
            {
                if (addUpSecCodeList.Count == 1)
                {
                    sqlCommand.CommandText += " AND MAIN.ADDUPSECCODERF='" + addUpSecCodeList[0] + "'";
                }
                else
                {
                    sqlCommand.CommandText += " AND MAIN.ADDUPSECCODERF IN (";
                    string str = "";
                    for (int ix = 0; ix < addUpSecCodeList.Count; ix++)
                    {
                        if (ix != 0)
                        {
                            str += ",";
                        }
                        str += "'" + addUpSecCodeList[ix] + "'";
                    }
                    sqlCommand.CommandText += str + ")";
                }
            }

            #endregion
            return true;
        }

        /// <summary>
        /// ���Ӑ挳�������f�[�^���X�g�i�[����
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="al">���Ӑ挳�������f�[�^���X�g</param>
        /// <param name="myReader">SQLDataReader</param>
        /// <br>Note       : SQLDataReader�̏��𓾈Ӑ挳�������f�[�^���X�g�ɃZ�b�g���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>		
        private void SetListFromSQLReader(ref int status, ref ArrayList al, SqlDataReader myReader)
        {
            if (al == null)
            {
                al = new ArrayList();
            }

            LedgerDepsitMainWork _ledgerDepsitMainWork;

            while (myReader.Read())
            {
                _ledgerDepsitMainWork = new LedgerDepsitMainWork();

                //SQL�f�[�^���[�_�[�����Ӑ挳�������f�[�^���[�N
                this.CopyToDataClassFromSelectData(ref _ledgerDepsitMainWork, myReader);
                al.Add(_ledgerDepsitMainWork);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
        }

        /// <summary>
        /// SQL�f�[�^���[�_�[�����Ӑ挳�������f�[�^���[�N
        /// </summary>
        /// <param name="_ledgerDepsitMainWork">���Ӑ挳�������f�[�^���[�N</param>
        /// <param name="myReader">SQL�f�[�^���[�_�[</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SQL�f�[�^���[�_�[�ɕێ����Ă�����e�𓾈Ӑ挳�������f�[�^���[�N�ɃR�s�[���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>		
        private void CopyToDataClassFromSelectData(ref LedgerDepsitMainWork _ledgerDepsitMainWork, SqlDataReader myReader)
        {
            #region ���Ӑ挳�������f�[�^���[�N�֊i�[
            _ledgerDepsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _ledgerDepsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            _ledgerDepsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
            _ledgerDepsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
            _ledgerDepsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            _ledgerDepsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
            _ledgerDepsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            _ledgerDepsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            _ledgerDepsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
            _ledgerDepsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            _ledgerDepsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
            _ledgerDepsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
            _ledgerDepsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));
            _ledgerDepsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));
            _ledgerDepsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            _ledgerDepsitMainWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            _ledgerDepsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            _ledgerDepsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            _ledgerDepsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            _ledgerDepsitMainWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            _ledgerDepsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            _ledgerDepsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            _ledgerDepsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            _ledgerDepsitMainWork.DepositRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITROWNORF"));
            _ledgerDepsitMainWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            _ledgerDepsitMainWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            _ledgerDepsitMainWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            _ledgerDepsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            _ledgerDepsitMainWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
            #endregion
        }
    }
}
