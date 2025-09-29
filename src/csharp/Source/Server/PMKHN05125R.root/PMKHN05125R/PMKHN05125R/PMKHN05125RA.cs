//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ������[�g�I�u�W�F�N�g
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/23  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�}�X�^�R�[�h�ϊ������[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^�R�[�h�ϊ��̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/23</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class CustomerConvertDB : RemoteWithAppLockDB, ICustomerConvertDB
    {
        #region -- Member --

        #region -- Constant --

        /// <summary>�e�[�u���E�J��������ۑ������ݒ�t�@�C���̃p�X</summary>
        private const string TARGET_TABLE_INFO_XML = "CustomerConvertList.xml";
        /// <summary>�^�C���A�E�g�̒l��\���萔�F36000</summary>
        private readonly int DB_TIME_OUT = 36000;
        /// <summary>���Ӑ�R�[�h�ϊ��Ώۃt�@�C���ɕs���f�[�^���L�邱�Ƃ������萔�F997</summary>
        private readonly int ILLEGAL_DATA = 997;
        /// <summary>���Ӑ�R�[�h�ϊ��Ώۃt�@�C���Ƀf�[�^���������Ƃ������萔�F998</summary>
        private readonly int NO_DATA = 998;
        /// <summary>���Ӑ�R�[�h�ϊ��Ώۃt�@�C�������݂��Ȃ����Ƃ������萔�F999</summary>
        private readonly int NO_FILE = 999;

        #endregion

        #endregion

        #region -- Constructor --

        /// <summary>
        /// ���Ӑ�}�X�^�R�[�h�ϊ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public CustomerConvertDB()
        {
            // �����Ȃ�
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// �R�[�h�ϊ�����
        /// </summary>
        /// <param name="warehouseConvertPrmListObj">�ϊ�����</param>
        /// <param name="numberOfTransactions">�����������i�[�����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɓ��Ӑ�R�[�h��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public int Convert(object customerConvertPrmObj, ref int numberOfTransactions)
        {
            // �����X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �R�[�h�ϊ������i�[�p�̕ϐ�
            CustomerConvertParamInfoList prmWrkList = customerConvertPrmObj as CustomerConvertParamInfoList;
            // SqlConnection�ϐ�
            SqlConnection sqlCon = null;
            // SqlTransaction�ϐ�
            SqlTransaction sqlTrn = null;

            // �R���o�[�g�����J�n
            try
            {
                // DB�Ɛڑ����s���܂��B
                sqlCon = this.CreateConnection(true);
                // �g�����U�N�V�������J�n���܂��B
                sqlTrn = this.CreateTransaction(ref sqlCon);
                // �R���o�[�g�����s���܂��B
                status = this.ConverProc(prmWrkList, sqlCon, sqlTrn, ref numberOfTransactions);
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }
            finally
            {
                if (sqlTrn != null)
                {
                    sqlTrn.Dispose();
                }

                if (sqlCon != null)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �R�[�h�ϊ��Ώۃe�[�u�����X�g�擾����
        /// </summary>
        /// <param name="targetTableList">�R�[�h�ϊ��Ώۃe�[�u�����X�g</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �R�[�h�ϊ��Ώۂ̃e�[�u���̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public int GetConvertTableList(ref object targetTableList)
        {
            // �����X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // XML����X�V�Ώۂ̃��X�g���擾���܂��B
                status = this.GetTargetTableFromXml(ref targetTableList);
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="customerPrmObj">��������</param>
        /// <param name="customerRetObjList">��������</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɓ��Ӑ�}�X�^�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public int Search(object customerPrmObj, ref object customerRetObjList)
        {
            // �����X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // ���o�����i�[�p�̕ϐ�
            CustomerSearchParamWork prmWk = customerPrmObj as CustomerSearchParamWork;
            // �������ʊi�[�p�̕ϐ�
            ArrayList customerArrayList = new ArrayList();
            try
            {
                // DB����f�[�^���擾���܂��B
                using (SqlConnection sqlCon = this.CreateConnection(true))
                {
                    status = this.SearchProc(customerArrayList, prmWk, sqlCon);
                }
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            // �������ʂ��i�[
            customerRetObjList = customerArrayList;
            return status;
        }

        #endregion

        #region -- Private Method --

        #region -- �����֘A --

        /// <summary>
        /// ���Ӑ�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="resultList">��������</param>
        /// <param name="prmWk">��������</param>
        /// <param name="sqlCon">DB�ڑ����</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɓ��Ӑ�}�X�^�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private int SearchProc(ArrayList resultList, CustomerSearchParamWork prmWk, SqlConnection sqlCon)
        {
            // �����X�e�[�^�X��������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // �����p��SQL�𐶐����ADB����f�[�^���擾���܂��B
                using (SqlCommand cmd = new SqlCommand(String.Empty, sqlCon))
                {
                    // �N�G����ݒ�
                    cmd.CommandText = this.GenerateSearchSql(prmWk, cmd);
                    // �N�G�������s
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            resultList.Add(this.SetSearchResultToCustomerSearchWork(rd));
                        }
                    }
                    status = resultList.Count == 0 ? (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND :
                        (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException sqle)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(sqle, errMsg, sqle.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomerConvertDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�}�X�^���擾SQL�쐬�����B
        /// </summary>
        /// <param name="prmWk">��������</param>
        /// <param name="cmd">SqlCommand�I�u�W�F�N�g</param>
        /// <returns>SQL��</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������Ɍ����p��SQL���𐶐����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private string GenerateSearchSql(CustomerSearchParamWork prmWk, SqlCommand cmd)
        {
            // SQL���̐���
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Concat(
                "SELECT " + Environment.NewLine,
                " "       + CustomerRf.LogicDeleteCofrRf + " " + Environment.NewLine,
                " ,"      + CustomerRf.CustomerCodeRf    + " " + Environment.NewLine,
                " ,"      + CustomerRf.CustomerNameRf    + " " + Environment.NewLine,
                "FROM "   + Environment.NewLine,
                " "       + CustomerRf.TblCustomerRf + " " + Environment.NewLine
                ));
            // WHERE��̐���
            sb.Append(this.GenerateSearchConditionSql(prmWk, cmd));
            // ORDER BY��̐���
            sb.Append(String.Concat(
                " ORDER BY " + Environment.NewLine,
                "  " + CustomerRf.CustomerCodeRf + Environment.NewLine
                ));

            return sb.ToString();
        }

        /// <summary>
        /// ��ʂŎw�肵�����������Ɍ����p��SQL��(WHERE�啔���̍쐬)�𐶐����܂��B
        /// </summary>
        /// <param name="prmWk">��������</param>
        /// <param name="cmd">SqlCommand�I�u�W�F�N�g</param>
        /// <returns>SQL��(���o��������)</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������Ɍ����p��SQL��(WHERE�啔���̍쐬)�𐶐����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private string GenerateSearchConditionSql(CustomerSearchParamWork prmWk, SqlCommand cmd)
        {
            StringBuilder sb = new StringBuilder();

            // ��ƃR�[�h
            sb.Append(" WHERE ");
            sb.Append("" + CustomerRf.EnterpriseCodeRf + " = " + CustomerRf.CndtnEnterpriseCode + Environment.NewLine);
            SqlParameter prmEnterPriseCd = cmd.Parameters.Add(CustomerRf.CndtnEnterpriseCode, SqlDbType.NChar);
            prmEnterPriseCd.Value = SqlDataMediator.SqlSetString(prmWk.EnterpriseCode);

            // ���Ӑ�R�[�h(�J�n)�A���͓��Ӑ�R�[�h(�I��)�̂ǂ��炩�������Ƃ��Ďw�肳�ꂽ�ꍇ�A
            // �w�肵�����Ӑ�R�[�h�𒊏o�����Ƃ��܂��B
            if (prmWk.CustomerCodeStart != 0 || prmWk.CustomerCodeEnd != 0)
            {
                // ���Ӑ�R�[�h(�J�n)
                if (prmWk.CustomerCodeStart != 0)
                {
                    sb.Append(" AND " + CustomerRf.CustomerCodeRf + " >= " + CustomerRf.CndtnCustomerCodeSt + Environment.NewLine);
                    SqlParameter prm = cmd.Parameters.Add(CustomerRf.CndtnCustomerCodeSt, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetInt32(prmWk.CustomerCodeStart);
                }

                // ���Ӑ�R�[�h(�I��)
                if (prmWk.CustomerCodeEnd != 0)
                {
                    sb.Append(" AND " + CustomerRf.CustomerCodeRf + " <= " + CustomerRf.CndtnCustomerCodeEd + Environment.NewLine);
                    SqlParameter prm = cmd.Parameters.Add(CustomerRf.CndtnCustomerCodeEd, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetInt32(prmWk.CustomerCodeEnd);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// �������ʊi�[����
        /// </summary>
        /// <param name="rd"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       :�������ʂ�WarehouseSearchWork�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private CustomerSearchWork SetSearchResultToCustomerSearchWork(SqlDataReader rd)
        {
            CustomerSearchWork result = new CustomerSearchWork();
            // �_���폜
            result.LogicalDelete = SqlDataMediator.SqlGetInt32(rd, rd.GetOrdinal(CustomerRf.LogicDeleteCofrRf));
            // ���Ӑ�R�[�h
            result.CustomerCode = SqlDataMediator.SqlGetInt32(rd, rd.GetOrdinal(CustomerRf.CustomerCodeRf));
            // ���Ӑ於��
            result.CustomerName = SqlDataMediator.SqlGetString(rd, rd.GetOrdinal(CustomerRf.CustomerNameRf));

            return result;
        }

        #endregion

        #region -- �R�[�h�ϊ��֘A --

        /// <summary>
        /// �R�[�h�ϊ�����
        /// </summary>
        /// <param name="prmWorkList">�ϊ�����</param>
        /// <param name="sqlCon">SqlConnection�I�u�W�F�N�g</param>
        /// <param name="sqlTran">SqlTransaction�I�u�W�F�N�g</param>
        /// <param name="numberOfTransactions">�����������i�[�����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɓ��Ӑ�R�[�h��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private int ConverProc(CustomerConvertParamInfoList prmWrkList, SqlConnection sqlCon,
            SqlTransaction sqlTran, ref int numberOfTransactions)
        {
            // �X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // �w�肵���e�[�u���̃f�[�^���R���o�[�g���܂��B
                using (SqlCommand cmd = new SqlCommand(String.Empty, sqlCon, sqlTran))
                {
                    // �^�C���A�E�g�̐ݒ�
                    cmd.CommandTimeout = this.DB_TIME_OUT;
                    // SQL�𐶐����Ď��s���܂��B
                    cmd.CommandText = this.GenerateUpdateSql(prmWrkList.CustomerConvertParamWorkList,
                        prmWrkList.TargetTable, prmWrkList.ColumnList, cmd);
                    numberOfTransactions = cmd.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException sqle)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炢�܂��B
                status = base.WriteSQLErrorLog(sqle);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomerConvertDB ConvertProc Excepton" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // ���������������ꍇ�̓R�~�b�g�A���s�����ꍇ�̓��[���o�b�N�����{���܂��B
                if (status == 0)
                {
                    sqlTran.Commit();
                }
                else
                {
                    sqlTran.Rollback();
                }
            }

            return status;
        }

        /// <summary>
        /// �R�[�h�ϊ��pSQL�쐬����
        /// </summary>
        /// <param name="prmWorkList">�ϊ������̃��X�g</param>
        /// <param name="columnList">�X�V�ΏۃJ�������X�g</param>
        /// <param name="trgTblNm">�X�V�Ώۃe�[�u��</param>
        /// <param name="cmd">SqlCommand�I�u�W�F�N�g</param>
        /// <returns>�R�[�h�ϊ��pSQL</returns>
        /// <remarks>
        /// <br>Note       : �R�[�h�ϊ����邽�߂�SQL�𐶐����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private string GenerateUpdateSql(IList<CustomerConvertParamWork> prmWrkList, string trgTblNm,
            IList<string> columnList, SqlCommand cmd)
        {
            SqlParameter prm;
            string prmStrBf;
            string prmStrAf;
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE " + Environment.NewLine);
            sb.Append("  " + trgTblNm + Environment.NewLine);
            sb.Append(" SET " + Environment.NewLine);
            for (int i = 0; i < columnList.Count; i++)
            {
                if (i != 0)
                {
                    sb.Append("," );
                }
                sb.Append(columnList[i] + " = (" + Environment.NewLine);
                sb.Append(" CASE " + Environment.NewLine);
                int index = 1;
                for (int j = 0; j < prmWrkList.Count; j++)
                {
                    // �p�����[�^�ϐ��̏���
                    // �ύX�O���Ӑ�R�[�h�p�̃p�����[�^�ϐ�
                    prmStrBf = String.Concat(CustomerRf.CndtnCustomerCodeBf, columnList[i], index);
                    // �ύX�㓾�Ӑ�R�[�h�p�̃p�����[�^�ϐ�
                    prmStrAf = String.Concat(CustomerRf.CndtnCustomerCodeAf, columnList[i], index++);
                    sb.Append(" WHEN " + columnList[i] + " = " + prmStrBf + " THEN " + prmStrAf + Environment.NewLine);

                    // �ύX�O���Ӑ�R�[�h�̃p�����[�^���Z�b�g
                    prm = cmd.Parameters.Add(prmStrBf, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetInt32(prmWrkList[j].BfCustomerCode);
                    // �ύX�㓾�Ӑ�R�[�h�̃p�����[�^���Z�b�g
                    prm = cmd.Parameters.Add(prmStrAf, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetInt32(prmWrkList[j].AfCustomerCode);
                }
                sb.Append("  ELSE " + columnList[i] + Environment.NewLine);
                sb.Append(" END " + Environment.NewLine);
                sb.Append(" )" + Environment.NewLine);
            }

            // WHERE��̐���
            sb.Append(" WHERE " + Environment.NewLine);
            for (int i = 0; i < columnList.Count; i++)
            {
                if (i != 0)
                {
                    sb.Append(" OR ");
                }
                int index = 1;
                sb.Append(columnList[i] + " IN (");
                for (int j = 0; j < prmWrkList.Count; j++)
                {
                    if (j != 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(String.Concat(CustomerRf.CndtnCustomerCodeBf, columnList[i], index++));
                }
                sb.Append(")");
            }
            sb.Append(";");

            return sb.ToString();
        }

        #endregion

        #region -- ���Ӑ�R�[�h�ϊ��Ώۃe�[�u�����X�g�擾�����֘A --

        /// <summary>
        /// �Ώۃe�[�u�����XML�ǂݎ�菈��
        /// </summary>
        /// <param name="targetTableList">�X�V�Ώۃe�[�u�������i�[����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : XML����ϊ��ΏۂƂȂ�e�[�u������ǂݎ��܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private int GetTargetTableFromXml(ref object targetTableList)
        {
            // �����X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // XML����f�[�^��ǂݎ��܂��B
            IDictionary<string, CustomerTargetTableList> trgTblMap = targetTableList as IDictionary<string, CustomerTargetTableList>;
            using (MemoryStream fs = XMLCustomerConvertList.ms())
            {
                // XML���f�V���A���C�Y���܂��B
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfCustomerConvertList));
                ArrayOfCustomerConvertList arryCstmrCnvList = (ArrayOfCustomerConvertList)serializer.Deserialize(fs);
                // key:�e�[�u�����Avalue:�J�����̃��X�g�ƂȂ�}�b�v���쐬���܂��B
                string tmpTblNm = String.Empty;
                foreach (CustomerConvertList customerCnvList in arryCstmrCnvList.CustomerConvertList)
                {
                    tmpTblNm = customerCnvList.TargetTable.Trim().ToUpper();
                    if (String.IsNullOrEmpty(tmpTblNm))
                    {
                        // �e�[�u��������A��������null�̏ꍇ�ُ͈�f�[�^�ł���ׁA������ł��؂�
                        return this.ILLEGAL_DATA;
                    }
                    else if (!trgTblMap.ContainsKey(tmpTblNm))
                    {
                        // key�������ꍇ�͗v�f���쐬
                        trgTblMap[tmpTblNm] = new CustomerTargetTableList();
                        // �Ώۃe�[�u����(������)
                        trgTblMap[tmpTblNm].TargetTable = tmpTblNm;
                        // �Ώۃe�[�u����(�_����)
                        trgTblMap[tmpTblNm].TargetTableName = customerCnvList.TargetTableName.Trim();
                        // �ΏۃJ������(������)��ۑ����郊�X�g
                        trgTblMap[tmpTblNm].ColumnList = new List<string>();
                    }
                    // �ΏۃJ������(������)
                    string tmpClmn = customerCnvList.TargetColumn.Trim().ToUpper();
                    if (String.IsNullOrEmpty(tmpClmn))
                    {
                        // �J����������A��������null�̏ꍇ�ُ͈�f�[�^�ł���ׁA������ł��؂�
                        return this.ILLEGAL_DATA;
                    }
                    trgTblMap[tmpTblNm].ColumnList.Add(tmpClmn);
                }

                if (trgTblMap.Count == 0)
                {
                    // trgTblMap��0���̏ꍇ�́A�ϊ��Ώۂ̃e�[�u���������ׁA�X�e�[�^�X��NO_DATA�ɂ��܂��B
                    status = this.NO_DATA;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
            }

            return status;
        }
        #endregion

        #endregion

        #region -- Inner Class --

        /// <summary>
        /// ���Ӑ�}�X�^�̃J���������`�����N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�̃J���������`�����N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private class CustomerRf
        {
            #region -- Member --

            /// <summary>��ƃR�[�h�̃p�����[�^�ϐ���\���萔:@FINDENTERPRISECODERFED</summary>
            public const string CndtnEnterpriseCode = "@FINDENTERPRISECODERFED";
            /// <summary>���Ӑ�R�[�h(�J�n)�̃p�����[�^�ϐ���\���萔:@FINDCUSTOMERCODERFST</summary>
            public const string CndtnCustomerCodeSt = "@FINDCUSTOMERCODERFST";
            /// <summary>���Ӑ�R�[�h(�I��)�̃p�����[�^�ϐ���\���萔:@FINDCUSTOMERCODERFED</summary>
            public const string CndtnCustomerCodeEd = "@FINDCUSTOMERCODERFED";
            /// <summary>���Ӑ�R�[�h(Admin)�̃p�����[�^�ϐ���\���萔:@FINDCODEADMIN</summary>
            public const string CndtnCustomerCodeAdmin = "@FINDCODEADMIN";
            /// <summary>���Ӑ�R�[�h(Support)�̃p�����[�^�ϐ���\���萔:@FINDSUPPORT</summary>
            public const string CndtnCustomerCodeSupport = "@FINDSUPPORT";

            /// <summary>�p�����[�^�ŗ��p����ϐ���(�ύX�O���Ӑ�R�[�h�p)</summary>
            public const string CndtnCustomerCodeBf = "@FINDBF";
            /// <summary>�p�����[�^�ŗ��p����ϐ���(�ύX�㓾�Ӑ�R�[�h�p)</summary>
            public const string CndtnCustomerCodeAf = "@FINDAF";

            /// <summary>�_���폜�t���O��\���萔�FLOGICALDELETECODERF</summary>
            public const string LogicDeleteCofrRf = "LOGICALDELETECODERF";
            /// <summary>���Ӑ�R�[�h��\���萔�FCUSTOMERCODERF</summary>
            public const string CustomerCodeRf = "CUSTOMERCODERF";
            /// <summary>���Ӑ於�̂̃J��������\���萔�FNAMERF</summary>
            public const string CustomerNameRf = "NAMERF";
            /// <summary>��ƃR�[�h�̃J��������\���萔�FENTERPRISECODERF</summary>
            public const string EnterpriseCodeRf = "ENTERPRISECODERF";

            /// <summary>�e�[�u������\���萔�FCUSTOMERRF</summary>
            public const string TblCustomerRf = "CUSTOMERRF";

            #endregion
        }

        #endregion

        #region ICustomerConvertDB �����o

        #endregion
    }
}
