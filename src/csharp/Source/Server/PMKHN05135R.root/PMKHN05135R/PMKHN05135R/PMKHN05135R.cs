//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���_�R�[�h�ϊ������[�g�I�u�W�F�N�g
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2017/12/15  �C�����e : �V�K�쐬
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
    /// ���_�R�[�h�ϊ������[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���_�R�[�h�ϊ��̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2017/12/15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SectionConvertDB : RemoteWithAppLockDB, ISectionConvertDB
    {

        #region -- Member --
        /// <summary>�^�C���A�E�g�̒l��\���萔�F36000</summary>
        private readonly int DB_TIME_OUT = 36000;
        /// <summary>���_�R�[�h�ϊ��Ώۃt�@�C���ɕs���f�[�^���L�邱�Ƃ������萔�F997</summary>
        private readonly int ILLEGAL_DATA = 997;
        /// <summary>���_�R�[�h�ϊ��Ώۃt�@�C���Ƀf�[�^���������Ƃ������萔�F998</summary>
        private readonly int NO_DATA = 998;
        /// <summary>���_�R�[�h�ϊ��Ώۃt�@�C�������݂��Ȃ����Ƃ������萔�F999</summary>
        private readonly int NO_FILE = 999;
        
        #endregion

        #region -- Constructor --

        /// <summary>
        /// ���_�R�[�h�ϊ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        public SectionConvertDB()
        {
        }

        #endregion

        #region -- Public Method -- 

        /// <summary>
        /// ���_�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sectionPrmObj">��������</param>
        /// <param name="sectionRetObjList">��������</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɋ��_�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        public int Search(object sectionPrmObj, ref object sectionRetObjList)
        {
            // �����X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // ���o�����i�[�p�̕ϐ�
            SectionSearchParamWork prmWk = sectionPrmObj as SectionSearchParamWork;
            // �������ʊi�[�p�̕ϐ�
            ArrayList sectionArrayList = new ArrayList();            
            try
            {
                // DB����f�[�^���擾���܂�
                using (SqlConnection sqlCon = this.CreateConnection(true))
                {
                    status = this.SearchProc(sectionArrayList, prmWk, sqlCon);
                }
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            // �������ʂ��i�[
            sectionRetObjList = sectionArrayList;
            return status;
        }

        /// <summary>
        /// �R�[�h�ϊ�����
        /// </summary>
        /// <param name="sectionConvertPrmListObj">�ϊ�����</param>
        /// <param name="numberOfTransactions">�����������i�[�����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɋ��_�R�[�h��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        public int Convert(object sectionConvertPrmListObj, ref long numberOfTransactions)
        {
            // �����X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �ϊ������i�[�p�̕ϐ�
            SectionConvertPrmInfoList prmWorkList = (SectionConvertPrmInfoList)sectionConvertPrmListObj;
            // SqlConnection�ϐ�
            SqlConnection sqlCon = null;
            // SqlTrancation�ϐ�
            SqlTransaction tran = null;

            // �R���o�[�g�����̊J�n
            try
            {
                // DB�Ɛڑ����s���܂�
                sqlCon = this.CreateConnection(true);
                // �g�����U�N�V�������J�n���܂�
                tran = this.CreateTransaction(ref sqlCon);
                // �R���o�[�g�����s���܂�
                status = this.ConvertProc(prmWorkList, sqlCon, tran, ref numberOfTransactions);
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }
            finally
            {
                if (tran != null)
                {
                    tran.Dispose();
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
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        public int GetConvertTableList(ref object targetTableMap)
        {
            // �����X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // XML����X�V�Ώۂ̃��X�g���擾���܂��B
                status = this.GetTargetTableFromXml(ref targetTableMap);
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            return status;
        }

        #endregion

        #region -- Private Method --

        #region -- ���_�����֘A --

        /// <summary>
        /// ���_�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="resultList">��������</param>
        /// <param name="prmWk">��������</param>
        /// <param name="sqlCon">DB�ڑ����</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɋ��_�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        private int SearchProc(ArrayList resultList, SectionSearchParamWork prmWk, SqlConnection sqlCon)
        {
            // �����X�e�[�^�X��������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // �����p��SQL�𐶐����A�������s���܂�
                using (SqlCommand cmd = new SqlCommand())
                {
                    // �ڑ�����ݒ�
                    cmd.Connection = sqlCon;
                    // �N�G����ݒ�
                    cmd.CommandText = this.GenerateSearchSql(prmWk, cmd);
                    // �N�G�������s
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            resultList.Add(this.SetSearchResultToSectionSearchWork(rd));
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
                base.WriteErrorLog(ex, "SectionConvertDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���_���擾SQL�쐬�����B
        /// </summary>
        /// <param name="prmWk">��������</param>
        /// <param name="cmd">SqlCommand�I�u�W�F�N�g</param>
        /// <returns>SQL��</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������Ɍ����p��SQL���𐶐����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        private string GenerateSearchSql(SectionSearchParamWork prmWk, SqlCommand cmd)
        {
            // SQL���̐���
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Concat(
                "SELECT " + Environment.NewLine,
                "  LOGICALDELETECODERF " + Environment.NewLine,
                " ,SECTIONCODERF " + Environment.NewLine,
                " ,SECTIONGUIDENMRF " + Environment.NewLine,
                "FROM " + Environment.NewLine,
                " SECINFOSETRF " + Environment.NewLine
                ));
            // WHERE��ȉ��̐���
            sb.Append(this.GenerateSearchConditionSql(prmWk, cmd));
            // GROUP BY��̐���
            sb.Append(String.Concat(
                " ORDER BY " + Environment.NewLine,
                "  " + SectionRf.SectionCodeRf
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
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        private string GenerateSearchConditionSql(SectionSearchParamWork prmWk, SqlCommand cmd)
        {
            StringBuilder sb = new StringBuilder();

            // ���_�R�[�h(�J�n)�A���͋��_�R�[�h(�I��)�̂ǂ��炩�������Ƃ��Ďw�肳�ꂽ�ꍇ
            // WHERE��𐶐����܂��B
            if (!String.IsNullOrEmpty(prmWk.SectionStCd) || !String.IsNullOrEmpty(prmWk.SectionEdCd))
            {
                // ��ƃR�[�h
                sb.Append(" WHERE ");
                sb.Append("   ENTERPRISECODERF = " + SectionRf.CndtnEnterpriseCodeEd + Environment.NewLine);
                SqlParameter prmEnterPriseCd = cmd.Parameters.Add(SectionRf.CndtnEnterpriseCodeEd, SqlDbType.NChar);
                prmEnterPriseCd.Value = SqlDataMediator.SqlSetString(prmWk.EnterPriseCode);

                // ���_�R�[�h(�J�n)
                if (!String.IsNullOrEmpty(prmWk.SectionStCd))
                {
                    sb.Append("  AND SECTIONCODERF >= " + SectionRf.CndtnSectionCodeSt + Environment.NewLine);
                    SqlParameter prm = cmd.Parameters.Add(SectionRf.CndtnSectionCodeSt, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWk.SectionStCd);
                }
                // ���_�R�[�h(�I��)
                if (!String.IsNullOrEmpty(prmWk.SectionEdCd))
                {
                    sb.Append("  AND SECTIONCODERF <= " + SectionRf.CndtnSectionCodeEd + Environment.NewLine);
                    SqlParameter prm = cmd.Parameters.Add(SectionRf.CndtnSectionCodeEd, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWk.SectionEdCd);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// �������ʊi�[����
        /// </summary>
        /// <param name="rd">�X�g���[���f�[�^</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�������ʂ�SectionSearchWork�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        private SectionSearchWork SetSearchResultToSectionSearchWork(SqlDataReader rd)
        {
            SectionSearchWork result = new SectionSearchWork();

            // �_���폜
            result.LogicalDelete = (int)SqlDataMediator.SqlSetInt32(rd.GetInt32(rd.GetOrdinal(SectionRf.LogicalDeleteCodeRf)));
            // ���_�R�[�h
            result.SectionCd = SqlDataMediator.SqlGetString(rd, rd.GetOrdinal(SectionRf.SectionCodeRf));
            // ���_����
            result.SectionNm = SqlDataMediator.SqlGetString(rd, rd.GetOrdinal(SectionRf.SectionNameRf));

            return result;
        }

        #endregion

        #region -- ���_�R�[�h�ϊ� --

        /// <summary>
        /// �R�[�h�ϊ�����
        /// </summary>
        /// <param name="prmWorkList">�ϊ�����</param>
        /// <param name="sqlCon">SqlConnection�I�u�W�F�N�g</param>
        /// <param name="sqlTran">SqlTransaction�I�u�W�F�N�g</param>
        /// <param name="numberOfTransactions">�����������i�[�����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɋ��_�R�[�h��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        private int ConvertProc(SectionConvertPrmInfoList prmWorkList, SqlConnection sqlCon,
            SqlTransaction sqlTran, ref long numberOfTransactions)
        {
            // �X�e�[�^�X�����������܂�
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // �X�V�Ώۂ̃e�[�u�����A�f�[�^�̃R���o�[�g���s���܂��B
                using (SqlCommand cmd = new SqlCommand(String.Empty, sqlCon, sqlTran))
                {
                    // �^�C���A�E�g�̐ݒ�
                    cmd.CommandTimeout = this.DB_TIME_OUT;
                    // SQL�𐶐����Ď��s���܂�
                    cmd.CommandText = this.GenerateUpdateSql(prmWorkList.SectionConvertPrmWorkList, 
                        prmWorkList.TargetTable, prmWorkList.ColumnList, cmd);                    
                    long count = cmd.ExecuteNonQuery();
                    numberOfTransactions = count;
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď��������Ă��炢�܂�
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SectionConvertDB ConvertProc Exception" + ex.Message);
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
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        private string GenerateUpdateSql(IList<SectionConvertPrmWork> prmWorkList, string trgTblNm, IList<string> columnList,
            SqlCommand cmd)
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
                for (int j = 0; j < prmWorkList.Count; j++)
                {
                    // �p�����[�^�ϐ��̏���
                    // �ϊ��O�̋��_�R�[�h�p�̃p�����[�^�ϐ�
                    prmStrBf = String.Concat(SectionRf.CndtnSectionCodeBf, columnList[i], index);
                    // �ϊ���̋��_�R�[�h�p�̃p�����[�^�ϐ�
                    prmStrAf = String.Concat(SectionRf.CndtnSectionCodeAf, columnList[i], index++);
                    sb.Append("  WHEN " + columnList[i] + " = " + prmStrBf + " THEN " + prmStrAf + Environment.NewLine);

                    // �ύX�O�R�[�h�̃p�����[�^���Z�b�g
                    prm = cmd.Parameters.Add(prmStrBf, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWorkList[j].BfSectionCode);    
                    // �ύX��R�[�h�̃p�����[�^���Z�b�g
                    prm = cmd.Parameters.Add(prmStrAf, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWorkList[j].AfSectionCode);
                }
                sb.Append("  ELSE " + columnList[i] + Environment.NewLine);
                sb.Append(" END " + Environment.NewLine);
                sb.Append(" ) ");
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
                for (int j = 0; j < prmWorkList.Count; j++)
                {
                    if (j != 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(String.Concat(SectionRf.CndtnSectionCodeBf, columnList[i], index++));
                }
                sb.Append(")");
            }

            sb.Append(";");
            
            return sb.ToString();
        }

        #endregion

        #region -- ���_�R�[�h�ϊ��Ώۃe�[�u�����X�g�擾�֘A --

        /// <summary>
        /// �Ώۃe�[�u�����XML�ǂݎ�菈��
        /// </summary
        /// <param name="targetTableList">�X�V�Ώۃe�[�u�������i�[����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : XML����ϊ��ΏۂƂȂ�e�[�u������ǂݎ��܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        private int GetTargetTableFromXml(ref object targetTableList)
        {
            // �����X�e�[�^�X�����������܂�
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // XML����f�[�^��ǂݎ��܂��B
            IDictionary<string, SectionTargetTableList> trgTblMap = targetTableList as IDictionary<string, SectionTargetTableList>;
            using (MemoryStream fs = XMLSectionConvertList.ms())
            {
                // XML���f�V���A���C�Y���܂��B
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfSectionConvertList));
                ArrayOfSectionConvertList arrySectionCnvList = (ArrayOfSectionConvertList)serializer.Deserialize(fs);
                // key:�e�[�u�����Avalue:�J�����̃��X�g�ƂȂ�}�b�v���쐬���܂��B
                string tmpTblNm = String.Empty;                
                foreach (SectionConvertList sectionCnvList in arrySectionCnvList.SectionConvertList)
                {
                    tmpTblNm = sectionCnvList.TargetTable.Trim().ToUpper();
                    if (String.IsNullOrEmpty(tmpTblNm))
                    {
                        // �e�[�u��������A��������null�̏ꍇ�ُ͈�f�[�^�ł���ׁA������ł��؂�
                        return this.ILLEGAL_DATA;
                    }
                    else if (!trgTblMap.ContainsKey(tmpTblNm))
                    {
                        trgTblMap[tmpTblNm] = new SectionTargetTableList();
                        // �e�[�u����(������)
                        trgTblMap[tmpTblNm].TargetTable = tmpTblNm;
                        // �e�[�u����(�_����)
                        trgTblMap[tmpTblNm].TargetTableName = sectionCnvList.TargetTableName.Trim();
                        // �J������(������)�̃��X�g
                        trgTblMap[tmpTblNm].ColumnList = new List<string>();
                    }
                    // �J������(������)
                    string tmpClmn = sectionCnvList.TargetColumn.Trim().ToUpper();
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
        /// ���_�̃J���������`�����N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�̃J���������`�����N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        private class SectionRf
        {
            #region -- Member -- 

            /// <summary>��ƃR�[�h�̃p�����[�^�ϐ���\���萔:@ENTERPRISECODERFED</summary>
            public const string CndtnEnterpriseCodeEd = "@FINDENTERPRISECODERFED";
            /// <summary>���_�R�[�h(�J�n)�̃p�����[�^�ϐ���\���萔:@SECTIONCODERF</summary>
            public const string CndtnSectionCodeSt = "@FINDSECTIONCODERFST";
            /// <summary>���_�R�[�h(�I��)�̃p�����[�^�ϐ���\���萔:@SECTIONGUIDENMRFED</summary>
            public const string CndtnSectionCodeEd = "@FINDSECTIONGUIDENMRFED";

            /// <summary>�p�����[�^�ŗ��p����ϐ���(�ύX�O���_�R�[�h�p)</summary>
            public const string CndtnSectionCodeBf = "@FINDBF";
            /// <summary>�p�����[�^�ŗ��p����ϐ���(�ύX�㋒�_�R�[�h�p)</summary>
            public const string CndtnSectionCodeAf = "@FINDAF";

            public const string LogicalDeleteCodeRf = "LOGICALDELETECODERF";         
            /// <summary>���_�R�[�h�̃J��������\���萔</summary>
            public const string SectionCodeRf = "SECTIONCODERF";
            /// <summary>���_���̂̃J��������\���萔</summary>
            public const string SectionNameRf = "SECTIONGUIDENMRF";

            #endregion
        }

        #endregion
    }
}
