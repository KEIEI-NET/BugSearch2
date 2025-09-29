//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ������[�g�I�u�W�F�N�g
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/10  �C�����e : �V�K�쐬
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
    /// �S���҃}�X�^�R�[�h�ϊ������[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �S���҃}�X�^�R�[�h�ϊ��̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/10</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class EmployeeConvertDB : RemoteWithAppLockDB, IEmployeeConvertDB
    {
        #region -- Member --

        #region -- Constant --
        /// <summary>�^�C���A�E�g�̒l��\���萔�F36000</summary>
        private readonly int DB_TIME_OUT = 36000;        
        /// <summary>�S���҃R�[�h�ϊ��Ώۃt�@�C���ɕs���f�[�^���L�邱�Ƃ������萔�F997</summary>
        private readonly int ILLEGAL_DATA = 997;
        /// <summary>�S���҃R�[�h�ϊ��Ώۃt�@�C���Ƀf�[�^���������Ƃ������萔�F998</summary>
        private readonly int NO_DATA = 998;
        /// <summary>�S���҃R�[�h�ϊ��Ώۃt�@�C�������݂��Ȃ����Ƃ������萔�F999</summary>
        private readonly int NO_FILE = 999;

        #endregion

        #endregion
        
        #region -- Constructor --

        /// <summary>
        /// �S���҃}�X�^�R�[�h�ϊ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public EmployeeConvertDB()
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
        /// <br>Note       : ��ʂŎw�肵�����������ɒS���҃R�[�h��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public int Convert(object employeeConvertPrmObj, ref int numberOfTransactions)
        {
            // �����X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �R�[�h�ϊ������i�[�p�̕ϐ�
            EmployeeConvertParamInfoList prmWrkList = employeeConvertPrmObj as EmployeeConvertParamInfoList;
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
                status = this.ConvertProc(prmWrkList, sqlCon, sqlTrn, ref numberOfTransactions);
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
        /// <br>Date       : 2016/03/10</br>
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
        /// �S���҃}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="employeePrmObj">��������</param>
        /// <param name="employeeRetObjList">��������</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɒS���҃}�X�^�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public int Search(object employeePrmObj, ref object employeeRetObjList)
        {
            // �����X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // ���o�����i�[�p�̕ϐ�
            EmployeeSearchParamWork prmWk = employeePrmObj as EmployeeSearchParamWork;
            // �������ʊi�[�p�̕ϐ�
            ArrayList employeeArrayList = new ArrayList();
            try
            {
                // DB����f�[�^���擾���܂��B
                using (SqlConnection sqlCon = this.CreateConnection(true))
                {
                    status = this.SearchProc(employeeArrayList, prmWk, sqlCon);
                }
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            // �������ʂ��i�[
            employeeRetObjList = employeeArrayList;
            return status;
        }

        #endregion

        #region -- Private Method --

        #region -- �����֘A --

        /// <summary>
        /// �S���҃}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="resultList">��������</param>
        /// <param name="prmWk">��������</param>
        /// <param name="sqlCon">DB�ڑ����</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɒS���҃}�X�^�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private int SearchProc(ArrayList resultList, EmployeeSearchParamWork prmWk, SqlConnection sqlCon)
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
                            resultList.Add(this.SetSearchResultToEmployeeSearchWork(rd));                            
                        }
                    }
                }
                status = resultList.Count == 0 ? (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND :
                    (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqle)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(sqle, errMsg, sqle.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeConvertDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �S���҃}�X�^���擾SQL�쐬�����B
        /// </summary>
        /// <param name="prmWk">��������</param>
        /// <param name="cmd">SqlCommand�I�u�W�F�N�g</param>
        /// <returns>SQL��</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������Ɍ����p��SQL���𐶐����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private string GenerateSearchSql(EmployeeSearchParamWork prmWk, SqlCommand cmd)
        {
            // SQL���̐���
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Concat(
                "SELECT " + Environment.NewLine,
                " " + EmployeeRf.LogicDeleteCofrRf + " " + Environment.NewLine,
                " ," + EmployeeRf.EmployeeCodeRf + " " + Environment.NewLine,
                " ," + EmployeeRf.EmployeeNameRf + " " + Environment.NewLine,
                "FROM " + Environment.NewLine,
                " EMPLOYEERF " + Environment.NewLine 
                ));
            // WHERE��̐���
            sb.Append(this.GenerateSearchConditionSql(prmWk, cmd));
            // ORDER BY��̐���
            sb.Append(" ORDER BY " + Environment.NewLine);
            sb.Append("  " + EmployeeRf.EmployeeCodeRf + Environment.NewLine);

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
        private string GenerateSearchConditionSql(EmployeeSearchParamWork prmWk, SqlCommand cmd)
        {
            StringBuilder sb = new StringBuilder();

            // ��ƃR�[�h
            sb.Append(" WHERE ");
            sb.Append("" + EmployeeRf.EnterpriseCodeRf + " = " + EmployeeRf.CndtnEnterpriseCode + Environment.NewLine);
            SqlParameter prmEnterPriseCd = cmd.Parameters.Add(EmployeeRf.CndtnEnterpriseCode, SqlDbType.NChar);
            prmEnterPriseCd.Value = SqlDataMediator.SqlSetString(prmWk.EnterpriseCode);

            // �S���҃R�[�h(�J�n)�A���͒S���҃R�[�h(�I��)�̂ǂ��炩�������Ƃ��Ďw�肳�ꂽ�ꍇ�A
            // �w�肵���S���҃R�[�h�𒊏o�����Ƃ��܂��B
            if (!String.IsNullOrEmpty(prmWk.EmployeeCodeStart) || !String.IsNullOrEmpty(prmWk.EmployeeCodeEnd))
            {                
                // �S���҃R�[�h(�J�n)
                if (!String.IsNullOrEmpty(prmWk.EmployeeCodeStart))
                {
                    sb.Append(" AND " + EmployeeRf.EmployeeCodeRf + " >= " + EmployeeRf.CndtnEmployeeCodeSt + Environment.NewLine);
                    SqlParameter prm = cmd.Parameters.Add(EmployeeRf.CndtnEmployeeCodeSt, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWk.EmployeeCodeStart);
                }

                // �S���҃R�[�h(�I��)
                if (!String.IsNullOrEmpty(prmWk.EmployeeCodeEnd))
                {
                    sb.Append(" AND " + EmployeeRf.EmployeeCodeRf + " <= " + EmployeeRf.CndtnEmployeeCodeEd + Environment.NewLine);
                    SqlParameter prm = cmd.Parameters.Add(EmployeeRf.CndtnEmployeeCodeEd, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWk.EmployeeCodeEnd);
                }
            }

            // �S���҃R�[�hAdmin��Support�͏��O���܂��B
            sb.Append(" AND " + EmployeeRf.EmployeeCodeRf + " != " + EmployeeRf.CndtnEmployeeCodeAdmin);
            SqlParameter codeAdmin = cmd.Parameters.Add(EmployeeRf.CndtnEmployeeCodeAdmin, SqlDbType.NChar);
            codeAdmin.Value = EmployeeRf.EmployeeCodeAdmin;
            sb.Append(" AND " + EmployeeRf.EmployeeCodeRf + " != " + EmployeeRf.CndtnEmployeeCodeSupport);
            SqlParameter codeSuppor = cmd.Parameters.Add(EmployeeRf.CndtnEmployeeCodeSupport, SqlDbType.NChar);
            codeSuppor.Value = EmployeeRf.EmployeeCodeSupport;

            return sb.ToString();
        }

        /// <summary>
        /// �������ʊi�[����
        /// </summary>
        /// <param name="rd">�X�g���[���f�[�^</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�������ʂ�EmployeeSearchWork�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private EmployeeSearchWork SetSearchResultToEmployeeSearchWork(SqlDataReader rd)
        {
            EmployeeSearchWork result = new EmployeeSearchWork();
            // �_���폜
            result.LogicalDelete = SqlDataMediator.SqlGetInt32(rd, rd.GetOrdinal(EmployeeRf.LogicDeleteCofrRf));
            // �S���҃R�[�h
            result.EmployeeCode = SqlDataMediator.SqlGetString(rd, rd.GetOrdinal(EmployeeRf.EmployeeCodeRf));
            // �S���Җ���
            result.EmployeeName = SqlDataMediator.SqlGetString(rd, rd.GetOrdinal(EmployeeRf.EmployeeNameRf));

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
        /// <br>Note       : ��ʂŎw�肵�����������ɒS���҃R�[�h��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private int ConvertProc(EmployeeConvertParamInfoList prmWrkList, SqlConnection sqlCon, 
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
                    cmd.CommandText = this.GenerateUpdateSql(prmWrkList.EmployeeConvertParamWorkList, 
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
                base.WriteErrorLog(ex, "EmployeeConvertDB ConvertProc Excepton" + ex.Message);
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
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private string GenerateUpdateSql(IList<EmployeeConvertParamWork> prmWrkList, string trgTblNm,
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
                    sb.Append(", ");
                }
                sb.Append(columnList[i] + " = (" + Environment.NewLine);
                sb.Append(" CASE " + Environment.NewLine);
                int index = 1;
                for (int j = 0; j < prmWrkList.Count; j++)
                {
                    // �p�����[�^�ϐ��̏���
                    // �ύX�O�̒S���҃R�[�h�p�̃p�����[�^�ϐ�
                    prmStrBf = String.Concat(EmployeeRf.CndtnEmployeeCodeBf, columnList[i], index);
                    // �ύX��̒S���҃R�[�h�p�̃p�����[�^�ϐ�
                    prmStrAf = String.Concat(EmployeeRf.CndtnEmployeeCodeAf, columnList[i], index++);
                    sb.Append(" WHEN " + columnList[i] + " = " + prmStrBf + " THEN " + prmStrAf + Environment.NewLine);

                    // �ύX�O�R�[�h�̃p�����[�^�̃Z�b�g
                    prm = cmd.Parameters.Add(prmStrBf, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWrkList[j].BfEmployeeCode);
                    // �ύX��R�[�h�̃p�����[�^�̃Z�b�g
                    prm = cmd.Parameters.Add(prmStrAf, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWrkList[j].AfEmployeeCode);
                }
                sb.Append("  ELSE " + columnList[i] + Environment.NewLine);
                sb.Append(" END " + Environment.NewLine);
                sb.Append(" )");
            }

            // WHERE��̐���
            sb.Append(" WHERE ");
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
                    sb.Append(String.Concat(EmployeeRf.CndtnEmployeeCodeBf, columnList[i], index++));
                }
                sb.Append(")");
            }
            sb.Append(";");

            return sb.ToString();
        }

        #endregion

        #region -- �S���҃R�[�h�ϊ��Ώۃe�[�u�����X�g�擾�����֘A --

        /// <summary>
        /// �Ώۃe�[�u�����XML�ǂݎ�菈��
        /// </summary
        /// <param name="targetTableList">�X�V�Ώۃe�[�u�������i�[����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : XML����ϊ��ΏۂƂȂ�e�[�u������ǂݎ��܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private int GetTargetTableFromXml(ref object targetTableList)
        {
            // �����X�e�[�^�X�����������܂�
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // XML����f�[�^��ǂݎ��܂�
            IDictionary<string, EmployeeTargetTableList> trgTblMap = targetTableList as IDictionary<string, EmployeeTargetTableList>;
            using (MemoryStream fs = XMLEmployeeConvertList.ms())
            {
                // XML���f�V���A���C�Y���܂��B
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfEmployeeConvertList));
                ArrayOfEmployeeConvertList arryEmplyCnvList = (ArrayOfEmployeeConvertList)serializer.Deserialize(fs);
                // key:�e�[�u�����Avalue:�J�����̃��X�g�ƂȂ�}�b�v���쐬���܂��B
                string tmpTblNm = String.Empty;
                foreach (EmployeeConvertList employeeCnvList in arryEmplyCnvList.EmployeeConvertList)
                {
                    tmpTblNm = employeeCnvList.TargetTable.Trim().ToUpper();
                    if (String.IsNullOrEmpty(tmpTblNm))
                    {
                        // �e�[�u��������A��������null�̏ꍇ�ُ͈�f�[�^�ł���ׁA������ł��؂�
                        return this.ILLEGAL_DATA;
                    }
                    else if (!trgTblMap.ContainsKey(tmpTblNm))
                    {
                        trgTblMap[tmpTblNm] = new EmployeeTargetTableList();
                        // �Ώۃe�[�u����(������)
                        trgTblMap[tmpTblNm].TargetTable = tmpTblNm;
                        // �Ώۃe�[�u����(�_����)
                        trgTblMap[tmpTblNm].TargetTableName = employeeCnvList.TargetTableName.Trim();
                        // �ΏۃJ������(������)��ۑ����郊�X�g
                        trgTblMap[tmpTblNm].ColumnList = new List<string>();
                    }
                    // �ΏۃJ������(������)
                    string tmpClmn = employeeCnvList.TargetColumn.Trim().ToUpper();
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
        /// �S���҃}�X�^�̃J���������`�����N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S���҃}�X�^�̃J���������`�����N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private class EmployeeRf
        {
            #region -- Member --

            /// <summary>��ƃR�[�h�̃p�����[�^�ϐ���\���萔:@FINDENTERPRISECODERFED</summary>
            public const string CndtnEnterpriseCode = "@FINDENTERPRISECODERFED";
            /// <summary>�S���҃R�[�h(�J�n)�̃p�����[�^�ϐ���\���萔:@FINDEMPLOYEECODERFST</summary>
            public const string CndtnEmployeeCodeSt = "@FINDEMPLOYEECODERFST";
            /// <summary>�S���҃R�[�h(�I��)�̃p�����[�^�ϐ���\���萔:@FINDEMPLOYEECODERFED</summary>
            public const string CndtnEmployeeCodeEd = "@FINDEMPLOYEECODERFED";
            /// <summary>�S���҃R�[�h(Admin)�̃p�����[�^�ϐ���\���萔:@FINDCODEADMIN</summary>
            public const string CndtnEmployeeCodeAdmin = "@FINDCODEADMIN";
            /// <summary>�S���҃R�[�h(Support)�̃p�����[�^�ϐ���\���萔:@FINDSUPPORT</summary>
            public const string CndtnEmployeeCodeSupport = "@FINDSUPPORT";

            /// <summary>�p�����[�^�ŗ��p����ϐ���(�ύX�O�S���҃R�[�h�p)</summary>
            public const string CndtnEmployeeCodeBf = "@FINDBF";
            /// <summary>�p�����[�^�ŗ��p����ϐ���(�ύX��S���҃R�[�h�p)</summary>
            public const string CndtnEmployeeCodeAf = "@FINDAF";

            /// <summary>�_���폜�t���O��\���萔�FLOGICALDELETECODERF</summary>
            public const string LogicDeleteCofrRf = "LOGICALDELETECODERF";
            /// <summary>�S���҃R�[�h��\���萔�FEMPLOYEECODERF</summary>
            public const string EmployeeCodeRf = "EMPLOYEECODERF";
            /// <summary>�S���Җ��̂̃J��������\���萔�FNAMERF</summary>
            public const string EmployeeNameRf = "NAMERF";
            /// <summary>��ƃR�[�h�̃J��������\���萔�FENTERPRISECODERF</summary>
            public const string EnterpriseCodeRf = "ENTERPRISECODERF";

            /// <summary>�S���҃R�[�h�AAdmin��\���萔�FAdmin</summary>
            public const string EmployeeCodeAdmin = "Admin";
            /// <summary>�S���҃R�[�h�ASupport��\���萔�FSupport</summary>
            public const string EmployeeCodeSupport = "Support";

            #endregion
        }

        #endregion
    }
}
