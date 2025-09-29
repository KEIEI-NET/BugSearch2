//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���`�F�b�N���X�g
// �v���O�����T�v   : �d���`�F�b�N���X�g���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/05/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2009/06/19  �C�����e : ��ʂ̋��_�͈͎w��͍폜�i��\���j�֕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2009/07/17  �C�����e : �d���v�㋒�_�R�[�h ==> �d�����_�R�[�h
//                                  �d�����z���v ==> �d�����z�v�i�Ŕ����j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : ����
// �C �� ��  2014/04/18  �C�����e : PM.NS�d�|�ꗗNo2370
//                                  Redmine#42500�@�d�����z�̕ύX�i�d�����z�v�i�Ŕ����j==>�d�����z���v�j
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d���`�F�b�N���X�gDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���`�F�b�N���X�g�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2009.05.10</br>
    /// <br>Update Note: 2014/04/18 ����</br>
    /// <br>�Ǘ��ԍ�   �F10904597-00 PM.NS�d�|�ꗗNo2370</br>
    /// <br>             Redmine#42500�@�d�����z�̕ύX�i�d�����z�v�i�Ŕ����j==>�d�����z���v�j</br>
    /// <br>Update Note: �f�b�g���b�N�̃g���[�X���(�d�F2677/�ˁF11100068-00)</br>
    /// <br>             Redmine #44965 �d���`�F�b�N���X�g�u���b�N��Q�̖h�~</br>
    /// <br>Date       : 2015/03/23</br>
    /// <br>           : �k�@�g</br>
    /// </remarks>
    [Serializable]
    public class StockSlipResultDB : RemoteDB, IStockSlipResultDB
    {
        /// <summary>
        /// �d���`�F�b�N���X�g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public StockSlipResultDB()
            :
        base("PMKOU02059D", "Broadleaf.Application.Remoting.ParamData.StockSlipResultWork", "STOCKSLIPRESULTRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region Search

        // Add by �k�g�@2015/03/23 for redmine #44965 �u���b�N��Q�̖h�~ ---->>>>>
        /// <summary>
        /// �g�����U�N�V�����������x�����uREAD UNCOMMITTED�v�ɐݒ肵�܂��B
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        /// <br>Note       : �g�����U�N�V�����������x���̐ݒ�</br>
        /// <br>Programmer : �k�@�g</br>
        /// <br>Date       : 2015.03.23</br>
        private static void SetTransIsolationReadUncommitted(SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED" , conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        // Add by �k�g�@2015/03/23 for redmine #44965 �u���b�N��Q�̖h�~ ----<<<<<

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���`�F�b�N���X�g��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="stockSlipResultWork">��������</param>
        /// <param name="stockSlipCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���f�[�^LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        public int Search(out object stockSlipResultWork, object stockSlipCndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockSlipResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (null == sqlConnection)
                {
                    return status;
                }
                sqlConnection.Open();

                SetTransIsolationReadUncommitted(sqlConnection); // Add by �k�g�@2015/03/23 for redmine #44965 �u���b�N��Q�̖h�~

                return SearchProc(out stockSlipResultWork, stockSlipCndtnWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockSlipResultDB.Search");
                stockSlipResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���`�F�b�N���X�g��S�Ė߂��܂�
        /// </summary>
        /// <param name="stockSlipResultWork">��������</param>
        /// <param name="_stockSlipCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���f�[�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// <br>Update Note: 2014/04/18 ����</br>
        /// <br>�Ǘ��ԍ�   �F10904597-00 PM.NS�d�|�ꗗNo2370</br>
        /// <br>             Redmine#42500�@�d�����z�̕ύX�i�d�����z�v�i�Ŕ����j==>�d�����z���v�j</br>
        private int SearchProc(out object stockSlipResultWork, object _stockSlipCndtnWork, ref SqlConnection sqlConnection)
        {
            StockSlipCndtnWork stockSlipCndtnWork = _stockSlipCndtnWork as StockSlipCndtnWork;
            
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            stockSlipResultWork = new ArrayList();
            ArrayList al = new ArrayList();   //���o����

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText += " SELECT ";
                sqlCommand.CommandText += " SSRF.PARTYSALESLIPNUMRF AS PARTYSALESLIPNUM, ";
                sqlCommand.CommandText += " SSRF.STOCKDATERF AS STOCKDATE, ";
                // sqlCommand.CommandText += " SSRF.STOCKADDUPSECTIONCDRF AS STOCKADDUPSECTIONCD, ";  // del 20090717 �d���v�㋒�_�R�[�h ==> �d�����_�R�[�h
                sqlCommand.CommandText += " SSRF.STOCKSECTIONCDRF AS STOCKADDUPSECTIONCD, ";  // add 20090717   �d���v�㋒�_�R�[�h ==> �d�����_�R�[�h
                sqlCommand.CommandText += " SSRF.SUPPLIERSLIPNORF AS SUPPLIERSLIPNO, ";
                sqlCommand.CommandText += " SSRF.SUPPLIERSLIPNOTE1RF AS SUPPLIERSLIPNOTE1, ";
                //sqlCommand.CommandText += " SSRF.STOCKTOTALPRICERF AS STOCKTOTALPRICE, ";  // del 20090717 �d�����z���v ==> �d�����z�v�i�Ŕ����j
                //sqlCommand.CommandText += " SSRF.STOCKTTLPRICTAXEXCRF AS STOCKTOTALPRICE, ";  // add 20090717  �d�����z���v ==> �d�����z�v�i�Ŕ����j//DEL 2014/04/18 PM.NS�d�|�ꗗNo2370 �d�����z�v�i�Ŕ����j==>�d�����z���v
                sqlCommand.CommandText += " SSRF.STOCKSUBTTLPRICERF AS STOCKTOTALPRICE, ";   //ADD 2014/04/18  PM.NS�d�|�ꗗNo2370 �d�����z�v�i�Ŕ����j==>�d�����z���v
                sqlCommand.CommandText += " SSRF.PAYEECODERF AS PAYEECODE, ";
                sqlCommand.CommandText += " SSRF.PAYEESNMRF AS PAYEESNM, ";
                sqlCommand.CommandText += " MAX( SDRF.WAYTOORDERRF)AS WAYTOORDER ";
                sqlCommand.CommandText += " FROM STOCKSLIPRF SSRF WITH (READUNCOMMITTED)";
                sqlCommand.CommandText += " LEFT JOIN STOCKDETAILRF SDRF ";
                sqlCommand.CommandText += " ON SDRF.ENTERPRISECODERF =  SSRF.ENTERPRISECODERF ";
                sqlCommand.CommandText += " AND SDRF.LOGICALDELETECODERF =  0 ";
                sqlCommand.CommandText += " AND SDRF.SUPPLIERSLIPNORF =  SSRF.SUPPLIERSLIPNORF ";
                // ��������
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockSlipCndtnWork);

                sqlCommand.CommandText += " GROUP BY ";
                sqlCommand.CommandText += " SSRF.PARTYSALESLIPNUMRF, ";
                sqlCommand.CommandText += " SSRF.STOCKDATERF, ";
                sqlCommand.CommandText += " SSRF.STOCKSECTIONCDRF, ";
                sqlCommand.CommandText += " SSRF.SUPPLIERSLIPNORF, ";
                sqlCommand.CommandText += " SSRF.SUPPLIERSLIPNOTE1RF, ";
                //sqlCommand.CommandText += " SSRF.STOCKTTLPRICTAXEXCRF, ";//DEL 2014/04/18 PM.NS�d�|�ꗗNo2370 �d�����z�v�i�Ŕ����j==>�d�����z���v
                sqlCommand.CommandText += " SSRF.STOCKSUBTTLPRICERF, ";    //ADD 2014/04/18  PM.NS�d�|�ꗗNo2370 �d�����z�v�i�Ŕ����j==>�d�����z���v
                sqlCommand.CommandText += " SSRF.PAYEECODERF, ";
                sqlCommand.CommandText += " SSRF.PAYEESNMRF ";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    StockSlipResultWork wkStockSlipResultWork = new StockSlipResultWork();
                    
                    //�d���f�[�^���ʎ擾���e�i�[
                    wkStockSlipResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNO"));
                    wkStockSlipResultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATE"));
                    wkStockSlipResultWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCD"));
                    wkStockSlipResultWork.StockAddUpSectionCdPm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCD"));
                    wkStockSlipResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODE"));
                    wkStockSlipResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNM"));
                    wkStockSlipResultWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICE"));
                    wkStockSlipResultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUM"));
                    wkStockSlipResultWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1"));
                    wkStockSlipResultWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDER"));
                    wkStockSlipResultWork.UoeRemark2 = "unchecked";
                    #endregion

                    al.Add(wkStockSlipResultWork);
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
                if (null != sqlCommand)
                {
                    sqlCommand.Dispose();
                }
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }
            }

            stockSlipResultWork = al;

            return status;
        }
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockSlipCndtnWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockSlipCndtnWork _stockSlipCndtnWork)
        {
            #region WHERE���쐬
            string retstring = " WHERE ";

            //��ƃR�[�h
            retstring += " SSRF.ENTERPRISECODERF=@ENTERPRISECODERF";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_stockSlipCndtnWork.EnterpriseCode);

            retstring += " AND SSRF.LOGICALDELETECODERF = 0 ";

            // DEL 2009/06/18 ��ʂ̋��_�͈͎w��͍폜�i��\���j�֕ύX
            //���_�R�[�h    ���z��ŕ����w�肳���
            //if (_stockSlipCndtnWork.SectionCodeList != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _stockSlipCndtnWork.SectionCodeList)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }

            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND SSRF.SECTIONCODERF IN (" + sectionCodestr + ") ";
            //    }
            //}

            // AND �d����>���p�����[�^.�x�������̊J�n��																																	
            if (!DateTime.MinValue.Equals(_stockSlipCndtnWork.St_csvDate))
            {
                retstring += "AND SSRF.STOCKDATERF>=@ST_SCVDAY ";
                SqlParameter Para_St_csvDate = sqlCommand.Parameters.Add("@ST_SCVDAY", SqlDbType.Int);
                Para_St_csvDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockSlipCndtnWork.St_csvDate);
            }

            // AND �d����<���p�����[�^.�x�������̏I����
            if (!DateTime.MinValue.Equals(_stockSlipCndtnWork.Ed_csvDate))
            {
                retstring += "AND SSRF.STOCKDATERF<=@ED_SCVDAY ";
                SqlParameter Para_Ed_csvDate = sqlCommand.Parameters.Add("@ED_SCVDAY", SqlDbType.Int);
                Para_Ed_csvDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockSlipCndtnWork.Ed_csvDate);
            }

            //�d����R�[�h(SUPPLIERCDRF)
            if (_stockSlipCndtnWork.SupplierCd != 0)
            {
                retstring += " AND SSRF.SUPPLIERCDRF=@SUPPLIERCDRF";
                SqlParameter paraStStockAdjustSlipNo = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                paraStStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(_stockSlipCndtnWork.SupplierCd);
            }
            #endregion
            return retstring;
        }

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
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
