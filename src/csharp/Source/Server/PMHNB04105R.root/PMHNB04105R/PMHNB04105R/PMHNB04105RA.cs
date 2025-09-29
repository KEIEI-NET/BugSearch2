using System;
using System.Collections;
using System.Collections.Generic;
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
    /// �o�ו��i�\��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�ו��i�\���̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.10.03</br>
    /// <br>Update Note: ���N�n��</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Date       : </br>
    /// <br>           : </br>
    /// </remarks>
    [Serializable]
    public class SPartsDspDB : RemoteDB, ISPartsDspDB
    {
        /// <summary>
        /// �o�ו��i�\��DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
        /// </remarks>
        public SPartsDspDB()
            :
            base("PMHNB04107D", "Broadleaf.Application.Remoting.ParamData.ShipmentPartsDspResultWork", "MTTLSALESSLIPRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏o�ו��i�\���f�[�^��߂��܂�
        /// </summary>
        /// <param name="shipmentPartsDspResultWork">��������</param>
        /// <param name="shipmentPartsDspParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏o�ו��i�\���f�[�^��߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
        /// <br>Update Note: ���N�n��</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        public int Search(out object shipmentPartsDspResultWork, object shipmentPartsDspParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            shipmentPartsDspResultWork = null;
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();// ADD 2011/03/22
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((ShipmentPartsDspParamWork)shipmentPartsDspParamWork).EnterpriseCode, "�o�ו��i�\��", "���o�J�n");// ADD 2011/03/22
                return SearchSPartsDsp(out shipmentPartsDspResultWork, shipmentPartsDspParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SPartsDspDB.Search");
                shipmentPartsDspResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((ShipmentPartsDspParamWork)shipmentPartsDspParamWork).EnterpriseCode, "�o�ו��i�\��", "���o�I��");// ADD 2011/03/22
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏o�ו��i�\���f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objShipmentPartsDspResultWork">��������</param>
        /// <param name="objShipmentPartsDspParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏o�ו��i�\���f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
        private int SearchSPartsDsp(out object objShipmentPartsDspResultWork, object objShipmentPartsDspParamWork, ref SqlConnection sqlConnection)
        {
            ShipmentPartsDspParamWork paramWork = null;

            ArrayList paramWorkList = objShipmentPartsDspParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objShipmentPartsDspParamWork as ShipmentPartsDspParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as ShipmentPartsDspParamWork;
            }

            ArrayList shipmentPartsDspResultWork = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // �o�ו��i�\���f�[�^���擾
            status = SearchSPartsDspProc(out shipmentPartsDspResultWork, paramWork, ref sqlConnection);

            objShipmentPartsDspResultWork = shipmentPartsDspResultWork;
            return status;

        }
        #endregion  //Search

        #region [SearchSPartsDspProc]
        /// <summary>
        /// �w�肳�ꂽ�����̏o�ו��i�\���f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="shipmentPartsDspResultWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏o�ו��i�\���f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
        private int SearchSPartsDspProc(out ArrayList shipmentPartsDspResultWorkList, ShipmentPartsDspParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string sqlText = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region [SELECT]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "	ENTERPRISECODERF AS ENTERPRISECODE" + Environment.NewLine;
                sqlText += "	,RSLTTTLDIVCDRF AS RSLTTTLDIVCD" + Environment.NewLine;
                sqlText += "	,SUM(SALESTIMESRF) AS SALESTIMES" + Environment.NewLine;
                sqlText += "	,SUM(GROSSPROFITRF) AS GROSSPROFIT" + Environment.NewLine;
                sqlText += "	,SUM(SALESMONEYRF+SALESRETGOODSPRICERF +DISCOUNTPRICERF) AS SALESMONEY" + Environment.NewLine; // ADD 2009.02.10
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "	MTTLSALESSLIPRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += " 	ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND LOGICALDELETECODERF=0" + Environment.NewLine;
                if (paramWork.SectionCode != "" && paramWork.SectionCode != "00")
                {
                    sqlText += " 	AND ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                }
                sqlText += " 	AND ADDUPYEARMONTHRF >= @STADDUPYEARMONTH" + Environment.NewLine;
                sqlText += " 	AND ADDUPYEARMONTHRF <= @EDADDUPYEARMONTH" + Environment.NewLine;
                sqlText += " 	AND EMPLOYEEDIVCDRF = 10" + Environment.NewLine; // ADD 2009.02.10
                sqlText += "GROUP BY" + Environment.NewLine;
                sqlText += "	ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "	,RSLTTTLDIVCDRF" + Environment.NewLine;
                #endregion

                sqlCommand.CommandText = sqlText;

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(paramWork.StAddUpYearMonth);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(paramWork.EdAddUpYearMonth);

                if (paramWork.SectionCode != "" && paramWork.SectionCode != "00")
                {
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                }

                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                sqlCommand.CommandTimeout = 3600;
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToSPartsDspWorkFromReader(ref myReader, paramWork));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            shipmentPartsDspResultWorkList = al;

            return status;
        }
        #endregion  //SearchSPartsDspProc

        #region [�N���X�֊i�[]
        /// <summary>
        /// �N���X�i�[���� Reader �� ShipmentPartsDspResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>ShipmentPartsDspResultWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
        /// </remarks>
        private ShipmentPartsDspResultWork CopyToSPartsDspWorkFromReader(ref SqlDataReader myReader, ShipmentPartsDspParamWork paramWork)
        {
            ShipmentPartsDspResultWork shipmentPartsDspResultWork = new ShipmentPartsDspResultWork();

            if (myReader != null)
            {
                # region �N���X�֊i�[
                shipmentPartsDspResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODE"));
                shipmentPartsDspResultWork.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RSLTTTLDIVCD"));
                shipmentPartsDspResultWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES"));
                shipmentPartsDspResultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY"));
                shipmentPartsDspResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFIT"));
                # endregion
            }

            return shipmentPartsDspResultWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion  //�R�l�N�V������������
    }

}
