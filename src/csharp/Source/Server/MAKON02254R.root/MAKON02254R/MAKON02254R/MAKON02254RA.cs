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
using Broadleaf.Library.Diagnostics;  //ADD 2008/06/30 D.Tanaka


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d���m�F�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���m�F�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20098�@�����@����</br>
    /// <br>Date       : 2007.03.19</br>
    /// <br></br>
    /// <br>Update Note: 30290 ���Ӑ�E�d����؂蕪��</br>
    /// <br>Date       : 2008.04.23</br>
    /// <br></br>
    /// <br>Update Note: �o�l.�m�r�p�ɕύX</br>
    /// <br>Date       : 2008/06/30</br>
    /// <br>           : 99076 �c�� ���</br>
    /// <br></br>
    /// <br>Update Note: �@�`�[�^�C�v������̏d���r�������ǉ�</br>
    /// <br>Update Note: �A���s�^�C�v�w��̕s��C��</br>
    /// <br>Date       : 2008.10.16</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br></br>
    /// <br>Update Note: �n��R�[�h���o�̕s��C��</br>
    /// <br>Date       : 2008.10.21</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br></br>
    /// <br>Update Note: ���o���ʍ��ڒǉ�</br>
    /// <br>Date       : 2008.10.29 2008.11.13 </br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br></br>
    /// <br>Update Note: �s��C��(�e�[�u���̌������@)</br>
    /// <br>Date       : 2009.01.14</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br></br>
    /// <br>Update Note: �s��C��(�l�����z�W�v�d�l�̕ύX)</br>
    /// <br>Date       : 2009.04.21</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br></br>
    /// <br>Update Note: �s��C��(UOE�A���}�b�`�敪�Q�Ƃ̏C�����`�[�^�C�v)</br>
    /// <br>Date       : 2009.04.27</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br></br>
    /// <br>Update Note: �s��C��</br>
    /// <br>Date       : 2009/05/19</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br></br>
    /// <br>Update Note: MANTIS�Ή�[11184]</br>
    /// <br>Date       : 2009/07/23</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br></br>
    /// <br>Update Note: 2009/09/08 ������</br>
    /// <br>           : PM.NS-2-B�E�o�l�D�m�r�ێ�˗��@</br>
    /// <br>           : �ߋ����\���Ή�</br>
    /// <br></br>
    /// <br>Update Note: ���x�`���[�j���O</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br>           : 22008 ���� ���n</br>
    /// <br>Update Note: �`�[�^�C�v�ɂďo�͂������ɒl���`�[���d�����ďo�͂���Ă����Q�̑Ή�</br>
    /// <br>Date       : 2012/10/16</br>
    /// <br>           : �e�c ���V</br>
    /// <br>Update Note: �`�[�^�C�v�ɂďo�͂������ɏ��i�l���̋��z���l�����ɕ\������Ȃ���Q�̑Ή�</br>
    /// <br>Date       : 2012/10/29</br>
    /// <br>           : �e�c ���V</br>
    /// <br>Update Note: �Ǘ��ԍ�10801804-00 2013/03/13�z�M���ً̋}�Ή�</br>
    /// <br>             Redmine #34611 �d���m�F�\UOE���f�[�^����s��</br>
    /// <br>Date       : 2013/02/07</br>
    /// <br>           : ���@����</br>
    /// <br>Update Note: �f�b�g���b�N�̃g���[�X���(�d�F2677/�ˁF11100068-00)</br>
    /// <br>             Redmine #44965 �d���m�F�\�u���b�N��Q�̖h�~</br>
    /// <br>Date       : 2015/03/23</br>
    /// <br>           : �k�@�g</br>
    /// <br>Update Note: 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Date	   : 2020/02/27</br>
    /// <br>           : 3H ����</br>
    /// <br>Update Note: 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j </br>
    /// <br>Date       : 2022/09/28</br>
    /// <br>           : ���O </br>
    /// </remarks>
    [Serializable]
    //public class StockConfDB : RemoteDB, IStockConfDB             DEL 2008/06/30
    public class StockConfDB : RemoteWithAppLockDB, IStockConfDB  //ADD 2008/06/30
    {
        /// <summary>
        /// �d���m�F�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        /// </remarks>
        public StockConfDB()
            :
            base("MAKON02256D", "Broadleaf.Application.Remoting.ParamData.StockConfWork", "STOCKCONFRF")
        {
        }

        #region [Search]

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
            using (SqlCommand cmd = new SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        // Add by �k�g�@2015/03/23 for redmine #44965 �u���b�N��Q�̖h�~ ----<<<<<

        /// <summary>
        /// �w�肳�ꂽ�����̎d���m�F�\���LIST��߂��܂�
        /// </summary>
        /// <param name="stockConfWork">��������</param>
        /// <param name="parastockConfWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d���m�F�\���LIST��߂��܂�</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        public int Search(out object stockConfWork, object parastockConfWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockConfWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                    return status;
                sqlConnection.Open();

                SetTransIsolationReadUncommitted(sqlConnection); // Add by �k�g�@2015/03/23 for redmine #44965 �u���b�N��Q�̖h�~

                return SearchStockConfProc(out stockConfWork, parastockConfWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockConfDB.Search");
                stockConfWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎d���m�F�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objstockConfWork">��������</param>
        /// <param name="parastockConfWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d���m�F�\���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        public int SearchStockConfProc(out object objstockConfWork, object parastockConfWork, ref SqlConnection sqlConnection)
        {
            StockConfShWork stockconfshWork = null;

            ArrayList stockconfshWorkList = parastockConfWork as ArrayList;
            ArrayList stockconfWorkList = new ArrayList();

            if (stockconfshWorkList == null)
            {
                stockconfshWork = parastockConfWork as StockConfShWork;
            }
            else
            {
                if (stockconfshWorkList.Count > 0)
                    stockconfshWork = stockconfshWorkList[0] as StockConfShWork;
            }

            int status = SearchStockConfProc(out stockconfWorkList, stockconfshWork, ref sqlConnection);
            objstockConfWork = stockconfWorkList;
            return status;

        }

        /// <summary>
        /// �w�肳�ꂽ�����̎d���m�F�\���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockconfWorkList">��������</param>
        /// <param name="stockconfShWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d���m�F�\���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        public int SearchStockConfProc(out ArrayList stockconfWorkList, StockConfShWork stockconfShWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string OrderbyStr = "";

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandText += MakeSelectString(ref sqlCommand, stockconfShWork)
                                       + MakeWhereString(ref sqlCommand, stockconfShWork)
                                       + OrderbyStr;

                #region [SQL DEBUG]
#if DEBUG
                Console.Clear();  //ADD 2008/06/30
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));  //ADD 2008/06/30

                #region [OLD-SQL DEBUG]
                // 2008/06/30 DEL-Start -------------------------------------------------- >>>>>
                //Console.Clear();
                //Console.WriteLine("--- �ϐ� ---");

                //foreach (SqlParameter param in sqlCommand.Parameters)
                //{
                //    string sqlDbType = param.SqlDbType.ToString();
                //    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                //    {
                //        sqlDbType += string.Format("({0})", param.Value.ToString().Length);
                //    }

                //    string value = param.Value.ToString();
                //    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                //    {
                //        value = string.Format("'{0}'", param.Value);
                //    }

                //    Console.WriteLine(string.Format("DECLARE {0} {1}", param.ParameterName, sqlDbType));
                //    Console.WriteLine(string.Format("SET {0} = {1}", param.ParameterName, value));
                //    Console.WriteLine("");
                //}

                //Console.WriteLine("--- SQL ---");
                //Console.WriteLine(sqlCommand.CommandText);
                // 2008/06/30 DEL-End ---------------------------------------------------- <<<<<
                #endregion
#endif
                #endregion

                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockConfWorkFromReader(ref myReader));
                }

                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockConfDB.SearchStockConfProc");
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                    myReader.Dispose();
                }
            }

            stockconfWorkList = al;

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockConfSlipTtlWork"></param>
        /// <param name="parastockConfWork"></param>
        /// <returns></returns>
        public int SearchSlipTtl(out object stockConfSlipTtlWork, object parastockConfWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction dummyTransaction = null;
            stockConfSlipTtlWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                    return status;
                sqlConnection.Open();

                SetTransIsolationReadUncommitted(sqlConnection); // Add by �k�g�@2015/03/25 for redmine #44965 �f�b�g���b�N�̃g���[�X��� 

                return SearchStockConfSlipTtlProc(out stockConfSlipTtlWork, parastockConfWork, ref sqlConnection, ref dummyTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockConfDB.SearchSlipTtl");
                stockConfSlipTtlWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockConfSlipTtlWork"></param>
        /// <param name="parastockConfWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int SearchStockConfSlipTtlProc(out object stockConfSlipTtlWork, object parastockConfWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            StockConfShWork stockconfshWork = null;

            ArrayList stockconfshWorkList = parastockConfWork as ArrayList;
            ArrayList stockConfSlipTtlWorkList = new ArrayList();

            if (stockconfshWorkList == null)
            {
                stockconfshWork = parastockConfWork as StockConfShWork;
            }
            else
            {
                if (stockconfshWorkList.Count > 0)
                    stockconfshWork = stockconfshWorkList[0] as StockConfShWork;
            }

            int status = SearchStockConfSlipTtlProc(out stockConfSlipTtlWorkList, stockconfshWork, ref sqlConnection, ref sqlTransaction);
            stockConfSlipTtlWork = stockConfSlipTtlWorkList;
            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockConfSlipTtlWorkList"></param>
        /// <param name="stockconfShWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int SearchStockConfSlipTtlProc(out ArrayList stockConfSlipTtlWorkList, StockConfShWork stockconfShWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string OrderbyStr = "";

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                if (sqlTransaction != null)
                {
                    sqlCommand.Transaction = sqlTransaction;
                }

                sqlCommand.CommandText += MakeSelectStringSlipTtl(ref sqlCommand, stockconfShWork)
                                       + MakeWhereStringSlipTtl(ref sqlCommand, stockconfShWork)
                                       + OrderbyStr;

                # region [SQL DEBUG]
#if DEBUG
                Console.Clear();
                Console.WriteLine("--- �ϐ� ---");

                foreach (SqlParameter param in sqlCommand.Parameters)
                {
                    string sqlDbType = param.SqlDbType.ToString();
                    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                    {
                        sqlDbType += string.Format("({0})", param.Value.ToString().Length);
                    }

                    string value = param.Value.ToString();
                    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                    {
                        value = string.Format("'{0}'", param.Value);
                    }

                    Console.WriteLine(string.Format("DECLARE {0} {1}", param.ParameterName, sqlDbType));
                    Console.WriteLine(string.Format("SET {0} = {1}", param.ParameterName, value));
                    Console.WriteLine("");
                }

                Console.WriteLine("--- SQL ---");
                Console.WriteLine(sqlCommand.CommandText);
#endif
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockConfSlipTtlWorkFromReader(ref myReader));
                }

                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockConfDB.SearchStockConfProc");
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                    myReader.Dispose();
                }
            }

            stockConfSlipTtlWorkList = al;

            return status;
        }
        #endregion

        #region [SQL��������]
        /// <summary>
        /// SQL����
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="stockconfShWork">���������i�[�N���X</param>
        /// <returns>�d���m�F�\��SQL������</returns>
        /// <remarks>
        /// <br>Note       : �d���m�F�\��SQL���쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.05</br>
        /// <br>Update Note: 2009/09/08 ������ �ߋ����\���Ή�</br>
        /// <br>Update Note: 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
        /// </remarks>
        private string MakeSelectString(ref SqlCommand sqlCommand, StockConfShWork stockconfShWork)
        {
            string sqlText = string.Empty;

            //--- UPD 2008/06/30 D.Tanaka --->>>
            sqlText += "SELECT" + Environment.NewLine;
            //sqlText += " SLIP.SECTIONCODERF" + Environment.NewLine;           // ���_�R�[�h
            sqlText += " SLIP.STOCKSECTIONCDRF" + Environment.NewLine;           // ���_�R�[�h
            sqlText += " ,SECI.SECTIONGUIDESNMRF" + Environment.NewLine;      // ���_�K�C�h����
            sqlText += " ,SLIP.STOCKSLIPUPDATECDRF" + Environment.NewLine;    // ADD 2008.10.16 �A
            sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;
            sqlText += " ,SLIP.INPUTDAYRF" + Environment.NewLine;
            sqlText += " ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKDATERF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKADDUPADATERF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKROWNORF" + Environment.NewLine;
            sqlText += " ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.ACCPAYDIVCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.UOEREMARK1RF" + Environment.NewLine;
            sqlText += " ,SLIP.UOEREMARK2RF" + Environment.NewLine;
            sqlText += " ,DTIL.ENTERPRISEGANRECODERF" + Environment.NewLine;
            sqlText += " ,DTIL.ENTERPRISEGANRENAMERF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;
            sqlText += " ,DTIL.GOODSNORF" + Environment.NewLine;
            sqlText += " ,DTIL.GOODSNAMERF" + Environment.NewLine;
            sqlText += " ,DTIL.GOODSMAKERCDRF" + Environment.NewLine;
            sqlText += " ,DTIL.MAKERNAMERF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKORDERDIVCDRF" + Environment.NewLine;
            sqlText += " ,DTIL.WAREHOUSECODERF" + Environment.NewLine;
            sqlText += " ,DTIL.WAREHOUSENAMERF" + Environment.NewLine;
            sqlText += " ,DTIL.WAREHOUSESHELFNORF" + Environment.NewLine;
            sqlText += " ,DTIL.BLGOODSCODERF" + Environment.NewLine;
            sqlText += " ,DTIL.BLGOODSFULLNAMERF" + Environment.NewLine;
            sqlText += " ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKDTISLIPNOTE1RF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKCOUNTRF" + Environment.NewLine;
            sqlText += " ,DTIL.BFLISTPRICERF" + Environment.NewLine;
            sqlText += " ,DTIL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
            sqlText += " ,DTIL.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKUNITPRICEFLRF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKUNITTAXPRICEFLRF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKPRICETAXEXCRF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKPRICETAXINCRF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine; // DEL 2008.11.13
            sqlText += " ,DTIL.STOCKPRICECONSTAXRF" + Environment.NewLine;   // ADD 2008.11.13
            sqlText += " ,SLIP.PAYEECODERF" + Environment.NewLine;
            sqlText += " ,SLIP.PAYEESNMRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;
            sqlText += " ,UDTIL.SALESSLIPNUMRF" + Environment.NewLine;  // ���㖾�׃f�[�^�D����`�[�ԍ�
            sqlText += " ,USLIP.CUSTOMERCODERF" + Environment.NewLine;  // ����f�[�^�D���Ӑ�R�[�h
            // ADD 2008.10.29 >>>
            sqlText += " ,SLIP.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPCTAXLAYCDRF" + Environment.NewLine;
            sqlText += " ,DTIL.TAXATIONCODERF" + Environment.NewLine;
            // ADD 2008.10.29 <<<
            // ADD 2009.01.06 >>>>>>>>>>
            sqlText += " ,DTIL.STOCKSLIPCDDTLRF" + Environment.NewLine;

            // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += " ,CASE WHEN  EXISTS (" + Environment.NewLine;
                sqlText += "       SELECT   " + Environment.NewLine;
                sqlText += "          1   " + Environment.NewLine;
                sqlText += "       FROM  STOCKSLHISTDTLRF AS STOCKSLDTL " + Environment.NewLine;
                sqlText += "         WHERE STOCKSLDTL.ENTERPRISECODERF=SLIP.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += "         AND SLIP.SUPPLIERFORMALRF = STOCKSLDTL.SUPPLIERFORMALRF  " + Environment.NewLine;
                sqlText += "         AND SLIP.SUPPLIERSLIPNORF = STOCKSLDTL.SUPPLIERSLIPNORF  " + Environment.NewLine;
                sqlText += "         AND STOCKSLDTL.TAXATIONCODERF != 1  " + Environment.NewLine;
                sqlText += "         AND SLIP.SUPPCTAXLAYCDRF = 0 ";
                sqlText += "         AND STOCKSLDTL.STOCKORDERDIVCDRF!=@FINDSTOCKORDERDIVCD)";

                sqlText += "       AND NOT EXISTS (" + Environment.NewLine;
                sqlText += "       SELECT   " + Environment.NewLine;
                sqlText += "          1   " + Environment.NewLine;
                sqlText += "       FROM  STOCKSLHISTDTLRF AS STOCKSLDTL " + Environment.NewLine;
                sqlText += "         WHERE STOCKSLDTL.ENTERPRISECODERF=SLIP.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += "         AND SLIP.SUPPLIERFORMALRF = STOCKSLDTL.SUPPLIERFORMALRF  " + Environment.NewLine;
                sqlText += "         AND SLIP.SUPPLIERSLIPNORF = STOCKSLDTL.SUPPLIERSLIPNORF  " + Environment.NewLine;
                sqlText += "         AND STOCKSLDTL.TAXATIONCODERF != 1  " + Environment.NewLine;
                sqlText += "         AND SLIP.SUPPCTAXLAYCDRF = 0 ";
                sqlText += "         AND STOCKSLDTL.STOCKORDERDIVCDRF=@FINDSTOCKORDERDIVCD)";
                sqlText += "  THEN 1 ELSE 0 END TAXRATEEXISTFLAG  " + Environment.NewLine;
            }
            else 
            {
                sqlText += " ,0 AS TAXRATEEXISTFLAG  " + Environment.NewLine;
            }
            // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<

            // ADD 2009.01.06 <<<<<<<<<<
            sqlText += " ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKPRICECONSTAXRF AS STOCKPRICECONSTAXDENRF" + Environment.NewLine;
            sqlText += " ,SLIP.STCKDISTTLTAXEXCRF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKDISOUTTAXRF" + Environment.NewLine;
            sqlText += " ,SLIP.STCKDISTTLTAXINCLURF" + Environment.NewLine;
            // --- ADD START 3H ���� 2020/02/27 ---------->>>>>
            sqlText += " ,SLIP.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
            // --- ADD END 3H ���� 2020/02/27 ----------<<<<<
            sqlText += "FROM" + Environment.NewLine;
            //sqlText += "  (STOCKSLIPRF AS SLIP INNER JOIN STOCKDETAILRF AS DTIL" + Environment.NewLine;    // �d���f�[�^�A�d�����׃f�[�^  // DEL 2009/09/08
            sqlText += "  (STOCKSLIPHISTRF AS SLIP INNER JOIN STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;    // �d�������f�[�^�A�d�����𖾍׃f�[�^  // ADD 2009/09/08
            sqlText += "    ON  SLIP.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERFORMALRF = DTIL.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERSLIPNORF = DTIL.SUPPLIERSLIPNORF)" + Environment.NewLine;
            // --- ADD 2009/04/15 ------ >>>
            // sqlText += "  LEFT JOIN SALESDETAILRF AS UDTIL" + Environment.NewLine; // DEL 2009/09/08
            sqlText += "  LEFT JOIN SALESHISTDTLRF AS UDTIL" + Environment.NewLine; // ADD 2009/09/08
            sqlText += "  ON  UDTIL.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "  AND UDTIL.ACPTANODRSTATUSRF = DTIL.ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
            sqlText += "  AND UDTIL.SALESSLIPDTLNUMRF = DTIL.SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;
            // sqlText += "  LEFT JOIN SALESSLIPRF AS USLIP" + Environment.NewLine; // DEL 2009/09/08
            sqlText += "  LEFT JOIN SALESHISTORYRF AS USLIP" + Environment.NewLine; // ADD 2009/09/08
            sqlText += "  ON  USLIP.ENTERPRISECODERF = UDTIL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "  AND USLIP.ACPTANODRSTATUSRF = UDTIL.ACPTANODRSTATUSRF" + Environment.NewLine;
            sqlText += "  AND USLIP.SALESSLIPNUMRF = UDTIL.SALESSLIPNUMRF" + Environment.NewLine;
            // --- ADD 2009/04/15 ------ <<<
            // --- DEL 2009/04/15 ------ >>>
            //sqlText += "  LEFT OUTER JOIN" + Environment.NewLine;
            //sqlText += "  (SALESDETAILRF AS UDTIL INNER JOIN SALESSLIPRF AS USLIP" + Environment.NewLine;  // ����f�[�^�A���㖾�׃f�[�^
            //sqlText += "    ON  UDTIL.ENTERPRISECODERF = USLIP.ENTERPRISECODERF" + Environment.NewLine;
            //sqlText += "    AND UDTIL.ACPTANODRSTATUSRF = USLIP.ACPTANODRSTATUSRF" + Environment.NewLine;
            //sqlText += "    AND UDTIL.SALESSLIPNUMRF = USLIP.SALESSLIPNUMRF)" + Environment.NewLine;
            //sqlText += "  ON  DTIL.ENTERPRISECODERF = UDTIL.ENTERPRISECODERF" + Environment.NewLine;
            //// �C�� 2009.01.14 >>>
            ////sqlText += "  AND DTIL.COMMONSEQNORF = UDTIL.COMMONSEQNORF" + Environment.NewLine;
            //sqlText += "  AND DTIL.STOCKSLIPDTLNUMRF = UDTIL.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
            // �C�� 2009.01.14 <<<
            // --- DEL 2009/04/15 ------ <<<
            sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;                     // ���_���ݒ�}�X�^
            sqlText += "    ON  SLIP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SLIP.STOCKSECTIONCDRF = SECI.SECTIONCODERF" + Environment.NewLine;

            # region [DC.NS-SQL��]
            //sqlText += "SELECT" + Environment.NewLine;
            //sqlText += "  SLIP.SECTIONCODERF" + Environment.NewLine;           // ���_�R�[�h
            //sqlText += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;        // ���_�K�C�h����
            //sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;            // �d����R�[�h
            //sqlText += " ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;           // �d���旪��
            //sqlText += " ,SLIP.INPUTDAYRF" + Environment.NewLine;              // ���͓��t
            //sqlText += " ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;       // ���ד�
            //sqlText += " ,SLIP.STOCKDATERF" + Environment.NewLine;             // �d����
            //sqlText += " ,SLIP.STOCKADDUPADATERF" + Environment.NewLine;       // �d���v����t
            //sqlText += " ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;        // �d���`��
            //sqlText += " ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;        // �d���`�[�ԍ�
            //sqlText += " ,DTIL.STOCKROWNORF" + Environment.NewLine;            // �d���s�ԍ�
            //sqlText += " ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;      // �����`�[�ԍ�
            //sqlText += " ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;        // �d���`�[�敪
            //sqlText += " ,SLIP.ACCPAYDIVCDRF" + Environment.NewLine;           // ���|�敪
            //sqlText += " ,DTIL.LARGEGOODSGANRECODERF" + Environment.NewLine;   // ���i�敪�O���[�v�R�[�h
            //sqlText += " ,DTIL.LARGEGOODSGANRENAMERF" + Environment.NewLine;   // ���i�敪�O���[�v����
            //sqlText += " ,DTIL.MEDIUMGOODSGANRECODERF" + Environment.NewLine;  // ���i�敪�R�[�h
            //sqlText += " ,DTIL.MEDIUMGOODSGANRENAMERF" + Environment.NewLine;  // ���i�敪����
            //sqlText += " ,DTIL.DETAILGOODSGANRECODERF" + Environment.NewLine;  // ���i�敪�ڍ׃R�[�h
            //sqlText += " ,DTIL.DETAILGOODSGANRENAMERF" + Environment.NewLine;  // ���i�敪�ڍז���
            //sqlText += " ,DTIL.ENTERPRISEGANRECODERF" + Environment.NewLine;   // ���Е��ރR�[�h
            //sqlText += " ,DTIL.ENTERPRISEGANRENAMERF" + Environment.NewLine;   // ���Е��ޖ���
            //sqlText += " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;        // �d���S���҃R�[�h
            //sqlText += " ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;        // �d���S���Җ���
            //sqlText += " ,DTIL.GOODSNORF" + Environment.NewLine;               // ���i�ԍ�
            //sqlText += " ,DTIL.GOODSNAMERF" + Environment.NewLine;             // ���i����
            //sqlText += " ,DTIL.GOODSMAKERCDRF" + Environment.NewLine;          // ���i���[�J�[�R�[�h
            //sqlText += " ,DTIL.MAKERNAMERF" + Environment.NewLine;             // ���[�J�[����
            //sqlText += " ,DTIL.STOCKORDERDIVCDRF" + Environment.NewLine;       // �d���݌Ɏ�񂹋敪
            //sqlText += " ,DTIL.WAREHOUSECODERF" + Environment.NewLine;         // �q�ɃR�[�h
            //sqlText += " ,DTIL.WAREHOUSENAMERF" + Environment.NewLine;         // �q�ɖ���
            //sqlText += " ,DTIL.WAREHOUSESHELFNORF" + Environment.NewLine;      // �q�ɒI��
            //sqlText += " ,DTIL.BLGOODSCODERF" + Environment.NewLine;           // BL���i�R�[�h
            //sqlText += " ,DTIL.BLGOODSFULLNAMERF" + Environment.NewLine;       // BL���i�R�[�h����(�S�p)
            //sqlText += " ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;          // �ԓ`�敪
            //sqlText += " ,DTIL.STOCKDTISLIPNOTE1RF" + Environment.NewLine;     // �d���`�[���ה��l�P
            //sqlText += " ,DTIL.STOCKCOUNTRF" + Environment.NewLine;            // �d����
            //sqlText += " ,DTIL.UNITCODERF" + Environment.NewLine;              // �P�ʃR�[�h
            //sqlText += " ,DTIL.UNITNAMERF" + Environment.NewLine;              // �P�ʖ���
            //sqlText += " ,DTIL.LISTPRICETAXEXCFLRF" + Environment.NewLine;     // �艿(�����A�Ŕ�)
            //sqlText += " ,DTIL.STOCKUNITPRICEFLRF" + Environment.NewLine;      // �d���P��(�����A�Ŕ�)
            //sqlText += " ,DTIL.STOCKUNITTAXPRICEFLRF" + Environment.NewLine;   // �d���P��(�����A�ō�)
            //sqlText += " ,DTIL.STOCKPRICETAXEXCRF" + Environment.NewLine;      // �d�����z(�Ŕ�)
            //sqlText += " ,DTIL.STOCKPRICETAXINCRF" + Environment.NewLine;      // �d�����z(�ō�)
            //sqlText += " ,DTIL.ORDERNUMBERRF AS ORDERFORMNORF" + Environment.NewLine;           // �����ԍ�(������)
            //sqlText += " ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine;     // �d�����z����Ŋz
            //sqlText += " ,SLIP.PAYEECODERF" + Environment.NewLine;             // �x����R�[�h
            //sqlText += " ,SLIP.PAYEESNMRF" + Environment.NewLine;              // �x���旪��
            //sqlText += " ,SLIP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;     // �d���`�[���l�P
            //sqlText += " ,SLIP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;     // �d���`�[���l�Q
            //sqlText += " ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;          // �d�����i�敪
            //sqlText += "FROM" + Environment.NewLine;
            //sqlText += "  STOCKSLIPRF AS SLIP INNER JOIN STOCKDETAILRF AS DTIL" + Environment.NewLine;
            //sqlText += "    ON  SLIP.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
            //sqlText += "    AND SLIP.SUPPLIERFORMALRF = DTIL.SUPPLIERFORMALRF" + Environment.NewLine;
            //sqlText += "    AND SLIP.SUPPLIERSLIPNORF = DTIL.SUPPLIERSLIPNORF" + Environment.NewLine;
            //sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;
            //sqlText += "    ON  SLIP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
            //sqlText += "    AND SLIP.SECTIONCODERF = SECI.SECTIONCODERF" + Environment.NewLine;
            # endregion
            //--- UPD 2008/06/30 D.Tanaka ---<<<

            return sqlText;
        }

        /// <summary>
        /// SQL����
        /// </summary>
        /// <param name="sqlCommand">sqlCommand�I�u�W�F�N�g</param>
        /// <param name="stockconfShWork">���������i�[�N���X</param>
        /// <returns>�d���m�F�\(�`�[���v)��SQL������</returns>
        /// <remarks>
        /// <br>Note       : �d���m�F�\��SQL���쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.12.19</br>
        /// <br>Update Note: 2009/09/08 ������ �ߋ����\���Ή�</br>
        /// <br>Update Note: 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>           : 2020/02/27</br>
        /// </remarks>
        private string MakeSelectStringSlipTtl(ref SqlCommand sqlCommand, StockConfShWork stockconfShWork)
        {
            string sqlText = string.Empty;

            //--- UPD 2008/06/30 D.Tanaka --->>>
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += " DISTINCT " + Environment.NewLine; // ADD 2008.10.16 �@�@
            sqlText += " SLIP.STOCKSECTIONCDRF" + Environment.NewLine;
            sqlText += " ,SECI.SECTIONGUIDESNMRF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKSLIPUPDATECDRF" + Environment.NewLine; // ADD 2008.10.16 �A
            sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;
            sqlText += " ,SLIP.INPUTDAYRF" + Environment.NewLine;
            sqlText += " ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKDATERF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
            sqlText += " ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;           
            //sqlText += " ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
            // --- DEL 2009/04/09 ------>>> 
            //sqlText += " ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            // --- DEL 2009/04/09 ------<<<

            // �C�� 2009/07/23 >>>
            //sqlText += " ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine;
            sqlText += " ,CASE WHEN SLIP.SUPPCTAXLAYCDRF =0 THEN SLIP.STOCKPRICECONSTAXRF ELSE DTL.STOCKPRICETAXINCRF -DTL.STOCKPRICETAXEXCRF END AS STOCKPRICECONSTAXRF" + Environment.NewLine;
            // �C�� 2009/07/23 <<<

            sqlText += " ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.ACCPAYDIVCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.UOEREMARK1RF" + Environment.NewLine;
            sqlText += " ,SLIP.UOEREMARK2RF" + Environment.NewLine;
            // ADD 2008.10.29 >>>
            sqlText += " ,SLIP.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPCTAXLAYCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.STCKPRCCONSTAXINCLURF" + Environment.NewLine;
            //sqlText += " ,SLIP.STCKDISTTLTAXINCLURF" + Environment.NewLine;
            // ADD 2008.10.29 <<<
            // 2009.01.09 >>>>
            //sqlText += " ,SLIP.STOCKDISOUTTAXRF" + Environment.NewLine;
            //sqlText += " ,SLIP.STCKDISTTLTAXEXCRF" + Environment.NewLine;
            // 2009.01.09 <<<<
            // --- UPD 2012/10/29 Y.Wakita ---------->>>>>
            // �C�� 2009/04/21 >>>
            ////sqlText += " ,DIS.STOCKPRICECONSTAXIN AS STCKDISTTLTAXINCLURF" + Environment.NewLine;
            ////sqlText += " ,DIS.STOCKPRICECONSTAXOUT AS STOCKDISOUTTAXRF" + Environment.NewLine;
            ////sqlText += " ,DIS.STOCKPRICETAXEXC AS STCKDISTTLTAXEXCRF" + Environment.NewLine;
            //sqlText += " ,SLIP.STCKDISTTLTAXINCLURF - DIS.STOCKPRICECONSTAXIN AS STCKDISTTLTAXINCLURF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKDISOUTTAXRF - DIS.STOCKPRICECONSTAXOUT AS STOCKDISOUTTAXRF" + Environment.NewLine;
            //sqlText += " ,SLIP.STCKDISTTLTAXEXCRF - DIS.STOCKPRICETAXEXC AS STCKDISTTLTAXEXCRF" + Environment.NewLine;
            // �C�� 2009/04/21 <<<
            sqlText += " ,DIS.STOCKPRICECONSTAXIN AS STCKDISTTLTAXINCLURF" + Environment.NewLine;
            sqlText += " ,DIS.STOCKPRICECONSTAXOUT AS STOCKDISOUTTAXRF" + Environment.NewLine;
            sqlText += " ,DIS.STOCKPRICETAXEXC AS STCKDISTTLTAXEXCRF" + Environment.NewLine;
            // --- UPD 2012/10/29 Y.Wakita ----------<<<<<

            // �C�� 2009/05/19 >>>
            //// --- ADD 2009/04/09 ------>>> 
            //sqlText += " ,DTL.STOCKPRICETAXEXCRF AS STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            //sqlText += " ,DTL.STOCKPRICETAXINCRF AS STOCKTTLPRICTAXINCRF" + Environment.NewLine;
            //sqlText += " ,DTL.STOCKPRICETAXEXCRF AS STOCKSUBTTLPRICERF" + Environment.NewLine;
            //sqlText += " ,DTL.STOCKPRICETAXINCRF AS STOCKTOTALPRICERF" + Environment.NewLine;
            //// --- ADD 2009/04/09 ------<<<
            //sqlText += " ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;
            // �C�� 2009/05/19 <<<
            // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
            sqlText += "    ,F.STOCKPRICETAXFREE AS STOCKPRICETAXFREECRF" + Environment.NewLine;
            sqlText += " ,CASE WHEN  EXISTS (" + Environment.NewLine;
            sqlText += "       SELECT   " + Environment.NewLine;
            sqlText += "          1   " + Environment.NewLine;
            sqlText += "       FROM  STOCKSLHISTDTLRF STOCKSLDTL " + Environment.NewLine;
            sqlText += "       WHERE STOCKSLDTL.ENTERPRISECODERF=SLIP.ENTERPRISECODERF " + Environment.NewLine;
            sqlText += "       AND SLIP.SUPPLIERFORMALRF = STOCKSLDTL.SUPPLIERFORMALRF  " + Environment.NewLine;
            sqlText += "       AND SLIP.SUPPLIERSLIPNORF = STOCKSLDTL.SUPPLIERSLIPNORF  " + Environment.NewLine;
            sqlText += "       AND SLIP.SUPPCTAXLAYCDRF != 9 " + Environment.NewLine;
            sqlText += "       AND STOCKSLDTL.TAXATIONCODERF != 1  " + Environment.NewLine;
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "   AND (SLIP.SUPPCTAXLAYCDRF = 0 OR ( SLIP.SUPPCTAXLAYCDRF <> 0 AND STOCKSLDTL.STOCKORDERDIVCDRF=@FINDSTOCKORDERDIVCD))";
            }
            sqlText += "  ) THEN 1 ELSE 0 END TAXRATEEXISTFLAG  " + Environment.NewLine;
            sqlText += " ,CASE WHEN  EXISTS (" + Environment.NewLine;
            sqlText += "       SELECT   " + Environment.NewLine;
            sqlText += "          1   " + Environment.NewLine;
            sqlText += "       FROM  STOCKSLHISTDTLRF STOCKSLDTL " + Environment.NewLine;
            sqlText += "       WHERE STOCKSLDTL.ENTERPRISECODERF=SLIP.ENTERPRISECODERF " + Environment.NewLine;
            sqlText += "       AND SLIP.SUPPLIERFORMALRF = STOCKSLDTL.SUPPLIERFORMALRF  " + Environment.NewLine;
            sqlText += "       AND SLIP.SUPPLIERSLIPNORF = STOCKSLDTL.SUPPLIERSLIPNORF  " + Environment.NewLine;
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "    AND STOCKSLDTL.STOCKORDERDIVCDRF=@FINDSTOCKORDERDIVCD ";
            }
            sqlText += "       AND (SLIP.SUPPCTAXLAYCDRF = 9 OR STOCKSLDTL.TAXATIONCODERF = 1))  " + Environment.NewLine;
            sqlText += "  THEN 1 ELSE 0 END TAXFREEEXISTFLAG  " + Environment.NewLine;
            // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
            // ���v�^�C�v�̏ꍇ
            // �@����ł́A�`�[�̒l���o��
            // �@���̑����z�́A���ׂ̒l���o�́���PM7�d�l
            sqlText += " ,DTL.STOCKPRICETAXEXCRF AS STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            sqlText += " ,DTL.STOCKPRICETAXEXCRF AS STOCKSUBTTLPRICERF" + Environment.NewLine;
            // �C��2009/07/23 >>>
            //sqlText += " ,DTL.STOCKPRICETAXEXCRF + SLIP.STOCKTTLPRICTAXINCRF - SLIP.STOCKTTLPRICTAXEXCRF AS STOCKTTLPRICTAXINCRF " + Environment.NewLine;
            //sqlText += " ,DTL.STOCKPRICETAXEXCRF + SLIP.STOCKTTLPRICTAXINCRF - SLIP.STOCKTTLPRICTAXEXCRF AS STOCKTOTALPRICERF " + Environment.NewLine;
            sqlText += " ,CASE WHEN SLIP.SUPPCTAXLAYCDRF =0 THEN DTL.STOCKPRICETAXEXCRF + SLIP.STOCKTTLPRICTAXINCRF - SLIP.STOCKTTLPRICTAXEXCRF  " ;
            sqlText += "   ELSE  DTL.STOCKPRICETAXINCRF END AS STOCKTTLPRICTAXINCRF  " + Environment.NewLine;
            sqlText += " ,CASE WHEN SLIP.SUPPCTAXLAYCDRF =0 THEN DTL.STOCKPRICETAXEXCRF + SLIP.STOCKTTLPRICTAXINCRF - SLIP.STOCKTTLPRICTAXEXCRF " ;
            sqlText += "  ELSE DTL.STOCKPRICETAXINCRF END AS STOCKTOTALPRICERF " + Environment.NewLine;
            // --- ADD START 3H ���� 2020/02/27 ---------->>>>>
            sqlText += " ,SLIP.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
            // --- ADD END 3H ���� 2020/02/27 ----------<<<<<
            // �C�� 2009/07/23 <<<

            sqlText += "FROM" + Environment.NewLine;
            //sqlText += "  STOCKSLIPRF AS SLIP LEFT OUTER JOIN STOCKDETAILRF AS DTIL" + Environment.NewLine;  // �d���f�[�^�A�d�����׃f�[�^  // DEL 2009/09/08
            sqlText += "  STOCKSLIPHISTRF AS SLIP LEFT OUTER JOIN STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;  // �d�������f�[�^�A�d�����𖾍׃f�[�^  // ADD 2009/09/08
            sqlText += "    ON  SLIP.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERFORMALRF = DTIL.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERSLIPNORF = DTIL.SUPPLIERSLIPNORF" + Environment.NewLine;
            sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;                       // ���_���ݒ�}�X�^
            sqlText += "    ON  SLIP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SLIP.STOCKSECTIONCDRF = SECI.SECTIONCODERF" + Environment.NewLine;
            sqlText += "  LEFT JOIN" + Environment.NewLine;
            sqlText += "  (" + Environment.NewLine;
            sqlText += "    SELECT" + Environment.NewLine;
            sqlText += "     DTIL.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "     DTIL.SUPPLIERFORMALRF," + Environment.NewLine;
            sqlText += "     DTIL.SUPPLIERSLIPNORF," + Environment.NewLine;
            //sqlText += "     DTIL.STOCKSLIPDTLNUMRF," + Environment.NewLine;  // DEL 2012/10/16 Y.Wakita
            sqlText += "     SUM(DTIL.STOCKPRICETAXEXCRF) STOCKPRICETAXEXC ," + Environment.NewLine;
            sqlText += "     SUM(CASE WHEN DTIL.TAXATIONCODERF = 0 THEN DTIL.STOCKPRICECONSTAXRF ELSE 0 END ) STOCKPRICECONSTAXOUT," + Environment.NewLine;
            sqlText += "     SUM(CASE WHEN DTIL.TAXATIONCODERF = 1 THEN DTIL.STOCKPRICECONSTAXRF ELSE 0 END ) STOCKPRICECONSTAXIN" + Environment.NewLine;
            sqlText += "    FROM" + Environment.NewLine;
            // sqlText += "     STOCKDETAILRF AS DTIL" + Environment.NewLine;  // DEL 2009/09/08
            sqlText += "     STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;  // ADD 2009/09/08
            sqlText += "    WHERE" + Environment.NewLine;
            sqlText += "     ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "     AND SUPPLIERFORMALRF = 0  " + Environment.NewLine;
            sqlText += "     AND STOCKSLIPCDDTLRF = 2 -- �l��" + Environment.NewLine;
            sqlText += "     AND STOCKCOUNTRF != 0  -- ����" + Environment.NewLine;
            sqlText += "    GROUP BY " + Environment.NewLine;
            sqlText += "     DTIL.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "     DTIL.SUPPLIERFORMALRF," + Environment.NewLine;
            // --- UPD 2012/10/16 Y.Wakita ---------->>>>>
            //sqlText += "     DTIL.SUPPLIERSLIPNORF," + Environment.NewLine;
            //sqlText += "     DTIL.STOCKSLIPDTLNUMRF" + Environment.NewLine;
            sqlText += "     DTIL.SUPPLIERSLIPNORF" + Environment.NewLine;
            // --- UPD 2012/10/16 Y.Wakita ----------<<<<<
            sqlText += "  ) AS DIS" + Environment.NewLine;
            sqlText += "    ON  SLIP.ENTERPRISECODERF = DIS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERFORMALRF = DIS.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERSLIPNORF = DIS.SUPPLIERSLIPNORF" + Environment.NewLine;
            // DEL 2009/05/19 >>>
            // --- ADD 2009/04/09 ------>>> 
            sqlText += "  LEFT JOIN" + Environment.NewLine;
            sqlText += "  (SELECT" + Environment.NewLine;
            sqlText += "    ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "   ,SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "   ,SUPPLIERSLIPNORF" + Environment.NewLine;
            //sqlText += "   ,STOCKSLIPDTLNUMRF" + Environment.NewLine;
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "   ,STOCKORDERDIVCDRF" + Environment.NewLine;
            }
            sqlText += "   ,SUM(STOCKPRICETAXEXCRF) AS STOCKPRICETAXEXCRF" + Environment.NewLine;
            sqlText += "   ,SUM(STOCKPRICETAXINCRF) AS STOCKPRICETAXINCRF" + Environment.NewLine;
            // sqlText += "   FROM STOCKDETAILRF AS STDTL" + Environment.NewLine;  // DEL 2009/09/08
            sqlText += "   FROM STOCKSLHISTDTLRF AS STDTL" + Environment.NewLine;  // ADD 2009/09/08
            sqlText += "   GROUP BY " + Environment.NewLine;
            sqlText += "    ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "   ,SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "   ,SUPPLIERSLIPNORF" + Environment.NewLine;
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "   ,STOCKORDERDIVCDRF" + Environment.NewLine;
            }
            //sqlText += "   ,STOCKSLIPDTLNUMRF" + Environment.NewLine;
            sqlText += "   ) AS DTL" + Environment.NewLine;
            sqlText += "   ON  DTL.ENTERPRISECODERF = SLIP.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "   AND DTL.SUPPLIERFORMALRF = SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
            //sqlText += "   AND DTL.STOCKSLIPDTLNUMRF = DIS.STOCKSLIPDTLNUMRF" + Environment.NewLine;
            sqlText += "   AND DTL.SUPPLIERSLIPNORF = SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
            // --- ADD 2009/04/09 ------<<<
            // DEL 2009/05/19 <<<
            // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
            sqlText += " LEFT JOIN" + Environment.NewLine;
            sqlText += " (" + Environment.NewLine;
            sqlText += "   SELECT" + Environment.NewLine;
            sqlText += "    STDTL.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "    STDTL.SUPPLIERFORMALRF," + Environment.NewLine;
            sqlText += "    STDTL.SUPPLIERSLIPNORF," + Environment.NewLine;
            sqlText += "    SUM(STDTL.STOCKPRICETAXEXCRF) STOCKPRICETAXFREE" + Environment.NewLine;
            sqlText += "   FROM " + Environment.NewLine;
            sqlText += "     STOCKSLHISTDTLRF AS STDTL" + Environment.NewLine;
            sqlText += "   LEFT JOIN STOCKSLIPHISTRF AS SLIP " + Environment.NewLine;
            sqlText += "   ON " + Environment.NewLine;
            sqlText += "    (SLIP.ENTERPRISECODERF = STDTL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "     AND SLIP.SUPPLIERFORMALRF = STDTL.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "     AND SLIP.SUPPLIERSLIPNORF = STDTL.SUPPLIERSLIPNORF) " + Environment.NewLine;
            sqlText += "   WHERE" + Environment.NewLine;
            sqlText += "        SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE  " + Environment.NewLine;
            sqlText += "    AND (STDTL.STOCKSLIPCDDTLRF != 2  OR (STDTL.STOCKSLIPCDDTLRF=2 AND STDTL.STOCKCOUNTRF=0 ))" + Environment.NewLine;
            sqlText += "    AND (SLIP.SUPPCTAXLAYCDRF = 9 OR STDTL.TAXATIONCODERF = 1)  " + Environment.NewLine;
            sqlText += "    AND (SLIP.SUPPLIERSLIPCDRF = 10 OR SLIP.SUPPLIERSLIPCDRF = 20)  " + Environment.NewLine;
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "    AND STDTL.STOCKORDERDIVCDRF=@FINDSTOCKORDERDIVCD ";
            }
            sqlText += "   GROUP BY " + Environment.NewLine;
            sqlText += "    STDTL.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "    STDTL.SUPPLIERFORMALRF," + Environment.NewLine;
            sqlText += "    STDTL.SUPPLIERSLIPNORF " + Environment.NewLine;
            sqlText += " ) AS F ON " + Environment.NewLine;
            sqlText += " (      " + Environment.NewLine;
            sqlText += "    SLIP.ENTERPRISECODERF = F.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERFORMALRF = F.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERSLIPNORF = F.SUPPLIERSLIPNORF" + Environment.NewLine;
            sqlText += "  )" + Environment.NewLine;
            // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
            //���d�����ׂ͍ݎ�敪�A�o�͎w��̒��o�����ŕK�v�ƂȂ邽�ߘA�����Ă܂��B�iGD�͖��ׂȂ��ł��`�[�o�^�\�Ȃ̂� LEFT JOIN�Ƃ���j

            # region [DC.NS-SQL��]
            //sqlText += "SELECT" + Environment.NewLine;
            //sqlText += "  SLIP.SECTIONCODERF" + Environment.NewLine;         // ���_�R�[�h
            //sqlText += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;      // ���_�K�C�h����
            //sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;          // �d����R�[�h
            //sqlText += " ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;         // �d���旪��
            //sqlText += " ,SLIP.INPUTDAYRF" + Environment.NewLine;            // ���͓��t
            //sqlText += " ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;     // ���ד��t
            //sqlText += " ,SLIP.STOCKDATERF" + Environment.NewLine;           // �d�����t
            //sqlText += " ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;      // �d���`��
            //sqlText += " ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;      // �`�[�ԍ�
            //sqlText += " ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;    // �����`�[�ԍ�
            //sqlText += " ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;        // �d�����i�敪
            //sqlText += " ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;      // �d���`�[�敪
            //sqlText += " ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;     // �d�����z���v
            //sqlText += " ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;    // �d�����z���v
            //sqlText += " ,SLIP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;  // �d�����z�v�i�ō��j
            //sqlText += " ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;  // �d�����z�v�i�Ŕ��j
            //sqlText += " ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine;   // �d�����z����Ŋz
            //sqlText += "FROM" + Environment.NewLine;
            //sqlText += "  STOCKSLIPRF AS SLIP LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;
            //sqlText += "    ON  SLIP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
            //sqlText += "    AND SLIP.SECTIONCODERF = SECI.SECTIONCODERF" + Environment.NewLine;
            # endregion
            //--- UPD 2008/06/30 D.Tanaka ---<<<
            return sqlText;
        }

        #endregion                      

        #region [WHERE�吶������]
        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="stockconfShWork">���������i�[�N���X</param>
        /// <returns>�d���m�F�\��SQL������</returns>
        /// <remarks>
        /// <br>Note       : �d���m�F�\��SQL���쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.05</br>
        /// <br>Update Note: 2009/09/08 ������ �ߋ����\���Ή�</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockConfShWork stockconfShWork)
        {
            // ��{WHERE��̍쐬
            string sqlText = "WHERE" + Environment.NewLine;

            // ��ƃR�[�h
            sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockconfShWork.EnterpriseCode);

            // �_���폜�敪
            //sqlText += "  AND SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine; // DEL 2008.10.16 �A

            // �d���`�[�敪(0:�d�� �Œ�)
            sqlText += "  AND SLIP.SUPPLIERFORMALRF = 0" + Environment.NewLine;

            // �d�����_�R�[�h
            if (stockconfShWork.StockSectionCd.Length > 0)
            {
                string[] sections = stockconfShWork.StockSectionCd;

                for (int i = 0; i < sections.Length; i++)
                {
                    sections[i] = "'" + sections[i] + "'";
                }

                string inText = string.Join(", ", sections);

                sqlText += "  AND SLIP.STOCKSECTIONCDRF IN (" + inText + ")" + Environment.NewLine;
            }

            // ���s�^�C�v
            switch (stockconfShWork.PrintType)
            {
                case 0:
                    {
                        // �ʏ�(���������{������)
                        sqlText += "  AND SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        break;
                    }
                case 1:
                    {
                        // ����
                        sqlText += "  AND (SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        //sqlText += "       AND SLIP.CREATEDATETIMERF <> SLIP.UPDATEDATETIMERF)" + Environment.NewLine; // DEL 2008.10.16 �A
                        sqlText += "       AND SLIP.STOCKSLIPUPDATECDRF = 1)" + Environment.NewLine; // ADD 2008.10.16 �A
                        break;
                    }
                case 2:
                    {
                        // �폜
                        sqlText += "  AND SLIP.LOGICALDELETECODERF = 1" + Environment.NewLine;
                        break;
                    }
                case 3:
                    {
                        // �����{�폜
                        sqlText += "  AND (SLIP.LOGICALDELETECODERF = 1" + Environment.NewLine;
                        sqlText += "       OR (SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        //sqlText += "           AND SLIP.CREATEDATETIMERF <> SLIP.UPDATEDATETIMERF))" + Environment.NewLine; // DEL 2008.10.16 �A
                        sqlText += "           AND SLIP.STOCKSLIPUPDATECDRF = 1))" + Environment.NewLine;   // DEL 2008.10.16 �A
                        break;
                    }
            }

            // �d�����t(�J�n)
            if (stockconfShWork.StockDateSt != 0)
            {
                // -- UPD 2010/05/10 -------------------------------------------->>> 
                //sqlText += "  AND SLIP.STOCKDATERF >= @FINDSTOCKDATEST" + Environment.NewLine;
                //SqlParameter paraStockDateSt = sqlCommand.Parameters.Add("@FINDSTOCKDATEST", SqlDbType.Int);
                //paraStockDateSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateSt);

                sqlText += "  AND SLIP.STOCKDATERF >= " + SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 --------------------------------------------<<<
            }

            // �d�����t(�I��)
            if (stockconfShWork.StockDateEd != 0)
            {
                // -- UPD 2010/05/10 -------------------------------------------->>>
                //sqlText += "  AND SLIP.STOCKDATERF <= @FINDSTOCKDATEED" + Environment.NewLine;
                //SqlParameter paraStockDateEd = sqlCommand.Parameters.Add("@FINDSTOCKDATEED", SqlDbType.Int);
                //paraStockDateEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateEd);

                sqlText += "  AND SLIP.STOCKDATERF <= " + SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 --------------------------------------------<<<
            }

            // ���͓��t(�J�n)
            if (stockconfShWork.InputDaySt != 0)
            {
                sqlText += "  AND SLIP.INPUTDAYRF >= @FINDINPUTDAYST" + Environment.NewLine;
                SqlParameter paraStockDateSt = sqlCommand.Parameters.Add("@FINDINPUTDAYST", SqlDbType.Int);
                paraStockDateSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.InputDaySt);
            }

            // ���͓��t(�I��)
            if (stockconfShWork.InputDayEd != 0)
            {
                sqlText += "  AND SLIP.INPUTDAYRF <= @FINDINPUTDAYED" + Environment.NewLine;
                SqlParameter paraStockDateEd = sqlCommand.Parameters.Add("@FINDINPUTDAYED", SqlDbType.Int);
                paraStockDateEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.InputDayEd);
            }

            // ���ד��t(�J�n)
            if (stockconfShWork.ArrivalGoodsDaySt != 0)
            {
                sqlText += "  AND SLIP.ARRIVALGOODSDAYRF >= @FINDARRIVALGOODSDAYST" + Environment.NewLine;
                SqlParameter paraArrivalGoodsDaySt = sqlCommand.Parameters.Add("@FINDARRIVALGOODSDAYST", SqlDbType.Int);
                paraArrivalGoodsDaySt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.ArrivalGoodsDaySt);
            }

            // ���ד��t(�I��)
            if (stockconfShWork.ArrivalGoodsDaySt != 0)
            {
                sqlText += "  AND SLIP.ARRIVALGOODSDAYRF <= @FINDARRIVALGOODSDAYED" + Environment.NewLine;
                SqlParameter paraArrivalGoodsDayEd = sqlCommand.Parameters.Add("@FINDARRIVALGOODSDAYED", SqlDbType.Int);
                paraArrivalGoodsDayEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.ArrivalGoodsDayEd);
            }

            // �d����R�[�h(�J�n)
            if (stockconfShWork.SupplierCdSt != 0)
            {
                sqlText += "  AND SLIP.SUPPLIERCDRF >= @FINDSUPPLIERCDST" + Environment.NewLine;
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@FINDSUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierCdSt);
            }

            // �d����R�[�h(�I��)
            if (stockconfShWork.SupplierCdEd != 0)
            {
                sqlText += "  AND SLIP.SUPPLIERCDRF <= @FINDSUPPLIERCDED" + Environment.NewLine;
                SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDED", SqlDbType.Int);
                paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierCdEd);
            }

            // �d���`�[�敪
            if ((stockconfShWork.SupplierSlipCd != 0) && (stockconfShWork.SupplierSlipCd != 30))
            {
                sqlText += "  AND SLIP.SUPPLIERSLIPCDRF = @FINDSUPPLIERSLIPCD" + Environment.NewLine;
                SqlParameter paraSupplierSlipCd = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPCD", SqlDbType.Int);
                paraSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierSlipCd);
            }
            if ((stockconfShWork.SupplierSlipCd == 30))
            {
                sqlText += "  AND( (SLIP.SUPPLIERSLIPCDRF = 20) OR (SLIP.SUPPLIERSLIPCDRF = 10 AND DTIL.STOCKSLIPCDDTLRF=2 ))" + Environment.NewLine;

            }

            // �ԓ`�敪
            if (stockconfShWork.DebitNoteDiv != -1)
            {
                sqlText += "  AND SLIP.DEBITNOTEDIVRF = @FINDDEBITNOTEDIV" + Environment.NewLine;
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@FINDDEBITNOTEDIV", SqlDbType.Int);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.DebitNoteDiv);
            }

            // �d���S���҃R�[�h(�J�n)
            if (!string.IsNullOrEmpty(stockconfShWork.StockAgentCodeSt) && stockconfShWork.StockAgentCodeSt == stockconfShWork.StockAgentCodeEd)
            {
                // �J�n�ƏI���������ꍇ�͌����v�̞B�������Ƃ���
                sqlText += "  AND SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeSt + "%");
            }
            else
            {

                // �d���S���҃R�[�h(�J�n)
                if (!string.IsNullOrEmpty(stockconfShWork.StockAgentCodeSt))
                {
                    // �J�n�ƏI���������ꍇ�͌����v�̞B�������Ƃ���
                    sqlText += "  AND SLIP.STOCKAGENTCODERF >= @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                    SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                    paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeSt);
                }

                // �d���S���҃R�[�h(�I��)
                if (stockconfShWork.StockAgentCodeEd != "")
                {
                    if (string.IsNullOrEmpty(stockconfShWork.StockAgentCodeSt))
                    {
                        sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2 OR" + Environment.NewLine;
                        sqlText += "       SLIP.STOCKAGENTCODERF IS NULL)" + Environment.NewLine;
                        
                        SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                        paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd);
                        
                        SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                        paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd + "%");
                    }
                    else
                    {
                        sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2)" + Environment.NewLine;

                        SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                        paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd);

                        SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                        paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd + "%");
                    }
                }
            }


            // �d���`�[�ԍ�
            // 2008/06/30 Del-Start �����ł��Ȃ��Ȃ�\��������̂ō폜 ------------- >>>>>
            //if (stockconfShWork.SupplierSlipNoSt == 0 && stockconfShWork.SupplierSlipNoEd == 0)
            //{
            //    sqlText += "  AND SLIP.SUPPLIERSLIPNORF = SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
            //}
            //else
            //{
            // 2008/06/30 Del-End ---------------------------------------------------- <<<<<
                // �d���`�[�ԍ�(�J�n)
                if (stockconfShWork.SupplierSlipNoSt != 0)
                {
                    sqlText += "  AND SLIP.SUPPLIERSLIPNORF >= @FINDSUPPLIERSLIPNOST" + Environment.NewLine;
                    SqlParameter paraSupplierSlipNoSt = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOST", SqlDbType.Int);
                    paraSupplierSlipNoSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierSlipNoSt);
                }

                // �d���`�[�ԍ�(�I��)
                if (stockconfShWork.SupplierSlipNoEd != 0)
                {
                    sqlText += "  AND SLIP.SUPPLIERSLIPNORF <= @FINDSUPPLIERSLIPNOED" + Environment.NewLine;
                    SqlParameter paraSupplierSlipNoEd = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOED", SqlDbType.Int);
                    paraSupplierSlipNoEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierSlipNoEd);
                }
            //}  2008/06/30 DEL
    
            // �����`��(�J�n)
            if (!string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumSt) &&
                stockconfShWork.PartySaleSlipNumSt == stockconfShWork.PartySaleSlipNumEd)
            {
                // �J�n�ƏI���������ꍇ�͌����v�̞B�������Ƃ���
                sqlText += "  AND SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUMST" + Environment.NewLine;
                SqlParameter paraPartySaleSlipNumSt = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMST", SqlDbType.NVarChar);
                paraPartySaleSlipNumSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumSt + "%");
            }
            else
            {
                // �����`��(�J�n)
                if (!string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumSt))
                {
                    sqlText += "  AND SLIP.PARTYSALESLIPNUMRF >= @FINDPARTYSALESLIPNUMST" + Environment.NewLine;
                    SqlParameter paraPartySaleSlipNumSt = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMST", SqlDbType.NVarChar);
                    paraPartySaleSlipNumSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumSt);
                }

                // �����`��(�I��)
                if (!string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumEd))
                {
                    if (string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumSt))
                    {
                        sqlText += "  AND (SLIP.PARTYSALESLIPNUMRF <= @FINDPARTYSALESLIPNUMED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUMED2 OR" + Environment.NewLine;
                        sqlText += "       SLIP.PARTYSALESLIPNUMRF IS NULL)" + Environment.NewLine;

                        SqlParameter paraPartySaleSlipNumEd1 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED1", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);

                        SqlParameter paraPartySaleSlipNumEd2 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED2", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);
                    }
                    else
                    {
                        sqlText += "  AND (SLIP.PARTYSALESLIPNUMRF <= @FINDPARTYSALESLIPNUMED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUMED2)" + Environment.NewLine;

                        SqlParameter paraPartySaleSlipNumEd1 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED1", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);

                        SqlParameter paraPartySaleSlipNumEd2 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED2", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);
                    }
                }
            }

            // 2008/06/30 ADD-Start -------------------------------------------------- >>>>>
            // �̔��G���A�R�[�h(�J�n)
            if (stockconfShWork.SalesAreaCodeSt != 0)
            {
                sqlText += "  AND SLIP.SALESAREACODERF >= @FINDSALESAREACODEST" + Environment.NewLine;
                SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@FINDSALESAREACODEST", SqlDbType.Int);
                paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SalesAreaCodeSt);
            }

            // �̔��G���A�R�[�h(�I��)
            if (stockconfShWork.SalesAreaCodeEd != 0)
            {
                //sqlText += "  AND SLIP.SALESAREACODERF >= @FINDSALESAREACODEED" + Environment.NewLine; // DEL 2008.10.21
                sqlText += "  AND SLIP.SALESAREACODERF <= @FINDSALESAREACODEED" + Environment.NewLine;   // ADD 2008.10.21 
                SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@FINDSALESAREACODEED", SqlDbType.Int);
                paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SalesAreaCodeEd);
            }

            // �d���݌Ɏ�񂹋敪
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "  AND DTIL.STOCKORDERDIVCDRF = @FINDSTOCKORDERDIVCD" + Environment.NewLine;
                SqlParameter paraStockOrderDivCd = sqlCommand.Parameters.Add("@FINDSTOCKORDERDIVCD", SqlDbType.Int);
                paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.StockOrderDivCd);
            }

            // �o�͎w��
            switch (stockconfShWork.OutputDesignated)
            {
                case 1:
                    {
                        // --- UPD 2009/09/08 -------------->>>>>
                        // �d�����́F�u�������@��2:�I�����C�������v&&�u ���㖾�גʔԁi�����j=0�v
                        // sqlText += "  AND (DTIL.WAYTOORDERRF <> 2" + Environment.NewLine;
                        // --- DEL 2013/02/07 BY ������ For Redmine#34611 -------------------------------->>>>>
                        //sqlText += "  AND ( NOT EXISTS ( SELECT * " + Environment.NewLine;
                        //sqlText += "                   FROM UOEORDERDTLRF " + Environment.NewLine;
                        //sqlText += "                   WHERE COMMONSEQNORF = DTIL.COMMONSEQNORF " + Environment.NewLine;
                        //sqlText += "                   AND ENTERPRISECODERF = DTIL.ENTERPRISECODERF " + Environment.NewLine;
                        //sqlText += "                   AND LOGICALDELETECODERF = 0 ) " + Environment.NewLine;
                        // --- DEL 2013/02/07 BY ������ For Redmine#34611 --------------------------------<<<<<
                        sqlText += "  AND ( NOT EXISTS ( " + GetOnLineOrder() + " ) " + Environment.NewLine;// ADD 2013/02/07 BY ������ For Redmine#34611                        
                        sqlText += "       AND DTIL.SALESSLIPDTLNUMSYNCRF = 0)" + Environment.NewLine;
                        // --- UPD 2009/09/08 --------------<<<<<
                        break;
                    }
                case 2:
                    {
                        // --- UPD 2009/09/08 -------------->>>>>
                        // UOE���F�u�������@=2:�I�����C�������v
                        // sqlText += "  AND DTIL.WAYTOORDERRF = 2" + Environment.NewLine;
                        // --- DEL 2013/02/07 BY ������ For Redmine#34611 -------------------------------->>>>>
                        //sqlText += "  AND EXISTS ( SELECT * " + Environment.NewLine;
                        //sqlText += "               FROM UOEORDERDTLRF " + Environment.NewLine;
                        //sqlText += "               WHERE COMMONSEQNORF = DTIL.COMMONSEQNORF " + Environment.NewLine;
                        //sqlText += "               AND ENTERPRISECODERF = DTIL.ENTERPRISECODERF " + Environment.NewLine;
                        //sqlText += "               AND LOGICALDELETECODERF = 0 ) " + Environment.NewLine;
                        // --- DEL 2013/02/07 BY ������ For Redmine#34611 --------------------------------<<<<<
                        sqlText += "  AND EXISTS ( " + GetOnLineOrder() + " ) " + Environment.NewLine;// ADD 2013/02/07 BY ������ For Redmine#34611                        
                        // --- UPD 2009/09/08 --------------<<<<<
                        break;
                    }
                case 3:
                    {
                        // �������͕��F�u���㖾�גʔԁi�����j��0�v
                        sqlText += "  AND DTIL.SALESSLIPDTLNUMSYNCRF <> 0 " + Environment.NewLine;
                        break;
                    }
                case 4:
                    {
                        // --- UPD 2009/09/08 -------------->>>>>
                        // UOE�A���}�b�`�F�u�������@=2:�I�����C�������v&&�u�ύX�O�d���P�����d���P���v
                        // --- ADD 2008.10.08 ---------->>>>>
                        //sqlText += "  AND (DTIL.WAYTOORDERRF = 2" + Environment.NewLine;
                        //sqlText += "       AND DTIL.BFSTOCKUNITPRICEFLRF = STOCKUNITPRICEFLRF)" + Environment.NewLine;
                        // sqlText += "  AND (DTIL.WAYTOORDERRF = 2" + Environment.NewLine;

                        // --- DEL 2013/02/07 BY ������ For Redmine#34611 -------------------------------->>>>>
                        //sqlText += "  AND ( EXISTS ( SELECT * " + Environment.NewLine;
                        //sqlText += "               FROM UOEORDERDTLRF " + Environment.NewLine;
                        //sqlText += "               WHERE COMMONSEQNORF = DTIL.COMMONSEQNORF " + Environment.NewLine;
                        //sqlText += "               AND ENTERPRISECODERF = DTIL.ENTERPRISECODERF " + Environment.NewLine;
                        //sqlText += "               AND LOGICALDELETECODERF = 0 ) " + Environment.NewLine;
                        // --- DEL 2013/02/07 BY ������ For Redmine#34611 --------------------------------<<<<<
                        sqlText += "  AND ( EXISTS ( " + GetOnLineOrder() + " ) " + Environment.NewLine;// ADD 2013/02/07 BY ������ For Redmine#34611
                        
                        sqlText += "       AND DTIL.BFSTOCKUNITPRICEFLRF <> STOCKUNITPRICEFLRF) " + Environment.NewLine;
                        // --- ADD 2008.10.08 ----------<<<<<

                        // --- UPD 2009/09/08 --------------<<<<<
                        break;
                    }
                default: // 0:�S��
                    break;
            }
            // 2008/06/30 ADD-End ---------------------------------------------------- <<<<<

            return sqlText;
        }

        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="stockconfShWork">���������i�[�N���X</param>
        /// <returns>�d���m�F�\(�`�[���v)��SQL������</returns>
        /// <br>Note       : �d���m�F�\��SQL���쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.12.19</br>
        private string MakeWhereStringSlipTtl(ref SqlCommand sqlCommand, StockConfShWork stockconfShWork)
        {
            // ��{WHERE��̍쐬
            string sqlText = "WHERE" + Environment.NewLine;

            // ��ƃR�[�h
            sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockconfShWork.EnterpriseCode);

            // �_���폜�敪
            //sqlText += "  AND SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine; // DEL 2008.10.16 �A

            // �d���`�[�敪(0:�d�� �Œ�)
            sqlText += "  AND SLIP.SUPPLIERFORMALRF = 0" + Environment.NewLine;

            // �d�����_�R�[�h
            if (stockconfShWork.StockSectionCd.Length > 0)
            {
                string[] sections = stockconfShWork.StockSectionCd;

                for (int i = 0; i < sections.Length; i++)
                {
                    sections[i] = "'" + sections[i] + "'";
                }

                string inText = string.Join(", ", sections);

                sqlText += "  AND SLIP.STOCKSECTIONCDRF IN (" + inText + ")" + Environment.NewLine;
            }

            // ���s�^�C�v
            switch (stockconfShWork.PrintType)
            {
                case 0:
                    {
                        // �ʏ�(���������{������)
                        sqlText += "  AND SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        break;
                    }
                case 1:
                    {
                        // ����
                        sqlText += "  AND (SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        //sqlText += "       AND SLIP.CREATEDATETIMERF <> SLIP.UPDATEDATETIMERF)" + Environment.NewLine; // DEL 2008.10.16 �A
                        sqlText += "       AND SLIP.STOCKSLIPUPDATECDRF = 1)" + Environment.NewLine; // ADD 2008.10.16 �A
                        break;
                    }
                case 2:
                    {
                        // �폜
                        sqlText += "  AND SLIP.LOGICALDELETECODERF = 1" + Environment.NewLine;
                        break;
                    }
                case 3:
                    {
                        // �����{�폜
                        sqlText += "  AND (SLIP.LOGICALDELETECODERF = 1" + Environment.NewLine;
                        sqlText += "       OR (SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        //sqlText += "           AND SLIP.CREATEDATETIMERF <> SLIP.UPDATEDATETIMERF))" + Environment.NewLine; // DEL 2008.10.16 �A
                        sqlText += "           AND SLIP.STOCKSLIPUPDATECDRF = 1))" + Environment.NewLine; // ADD 2008.10.16 �A
                        break;
                    }
            }

            // �d�����t(�J�n)
            if (stockconfShWork.StockDateSt != 0)
            {
                // -- UPD 2010/05/10 ---------------------------------------------->>>
                //sqlText += "  AND SLIP.STOCKDATERF >= @FINDSTOCKDATEST" + Environment.NewLine;
                //SqlParameter paraStockDateSt = sqlCommand.Parameters.Add("@FINDSTOCKDATEST", SqlDbType.Int);
                //paraStockDateSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateSt);

                sqlText += "  AND SLIP.STOCKDATERF >= " + SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 ----------------------------------------------<<<
            }

            // �d�����t(�I��)
            if (stockconfShWork.StockDateEd != 0)
            {
                // -- UPD 2010/05/10 ---------------------------------------------->>>
                //sqlText += "  AND SLIP.STOCKDATERF <= @FINDSTOCKDATEED" + Environment.NewLine;
                //SqlParameter paraStockDateEd = sqlCommand.Parameters.Add("@FINDSTOCKDATEED", SqlDbType.Int);
                //paraStockDateEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateEd);

                sqlText += "  AND SLIP.STOCKDATERF <= " + SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 ----------------------------------------------<<<
            }

            // ���͓��t(�J�n)
            if (stockconfShWork.InputDaySt != 0)
            {
                sqlText += "  AND SLIP.INPUTDAYRF >= @FINDINPUTDAYST" + Environment.NewLine;
                SqlParameter paraStockDateSt = sqlCommand.Parameters.Add("@FINDINPUTDAYST", SqlDbType.Int);
                paraStockDateSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.InputDaySt);
            }

            // ���͓��t(�I��)
            if (stockconfShWork.InputDayEd != 0)
            {
                sqlText += "  AND SLIP.INPUTDAYRF <= @FINDINPUTDAYED" + Environment.NewLine;
                SqlParameter paraStockDateEd = sqlCommand.Parameters.Add("@FINDINPUTDAYED", SqlDbType.Int);
                paraStockDateEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.InputDayEd);
            }

            // ���ד��t(�J�n)
            if (stockconfShWork.ArrivalGoodsDaySt != 0)
            {
                sqlText += "  AND SLIP.ARRIVALGOODSDAYRF >= @FINDARRIVALGOODSDAYST" + Environment.NewLine;
                SqlParameter paraArrivalGoodsDaySt = sqlCommand.Parameters.Add("@FINDARRIVALGOODSDAYST", SqlDbType.Int);
                paraArrivalGoodsDaySt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.ArrivalGoodsDaySt);
            }

            // ���ד��t(�I��)
            if (stockconfShWork.ArrivalGoodsDaySt != 0)
            {
                sqlText += "  AND SLIP.ARRIVALGOODSDAYRF <= @FINDARRIVALGOODSDAYED" + Environment.NewLine;
                SqlParameter paraArrivalGoodsDayEd = sqlCommand.Parameters.Add("@FINDARRIVALGOODSDAYED", SqlDbType.Int);
                paraArrivalGoodsDayEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.ArrivalGoodsDayEd);
            }

            // �d����R�[�h(�J�n)
            if (stockconfShWork.SupplierCdSt != 0)
            {
                sqlText += "  AND SLIP.SUPPLIERCDRF >= @FINDSUPPLIERCDST" + Environment.NewLine;
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@FINDSUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierCdSt);
            }

            // �d����R�[�h(�I��)
            if (stockconfShWork.SupplierCdEd != 0)
            {
                sqlText += "  AND SLIP.SUPPLIERCDRF <= @FINDSUPPLIERCDED" + Environment.NewLine;
                SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDED", SqlDbType.Int);
                paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierCdEd);
            }

            // �d���`�[�敪
            if ((stockconfShWork.SupplierSlipCd != 0) && stockconfShWork.SupplierSlipCd != 30)
            {
                sqlText += "  AND SLIP.SUPPLIERSLIPCDRF = @FINDSUPPLIERSLIPCD" + Environment.NewLine;
                SqlParameter paraSupplierSlipCd = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPCD", SqlDbType.Int);
                paraSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierSlipCd);
            }

            // �ԓ`�敪
            if (stockconfShWork.DebitNoteDiv != -1)
            {
                sqlText += "  AND SLIP.DEBITNOTEDIVRF = @FINDDEBITNOTEDIV" + Environment.NewLine;
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@FINDDEBITNOTEDIV", SqlDbType.Int);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.DebitNoteDiv);
            }

            // �d���S���҃R�[�h(�J�n)
            if (!string.IsNullOrEmpty(stockconfShWork.StockAgentCodeSt) && stockconfShWork.StockAgentCodeSt == stockconfShWork.StockAgentCodeEd)
            {
                // �J�n�ƏI���������ꍇ�͌����v�̞B�������Ƃ���
                sqlText += "  AND SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeSt + "%");
            }
            else
            {
                // �d���S���҃R�[�h(�J�n)
                if (!string.IsNullOrEmpty(stockconfShWork.StockAgentCodeSt))
                {
                    // �J�n�ƏI���������ꍇ�͌����v�̞B�������Ƃ���
                    sqlText += "  AND SLIP.STOCKAGENTCODERF >= @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                    SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                    paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeSt);
                }

                // �d���S���҃R�[�h(�I��)
                if (stockconfShWork.StockAgentCodeEd != "")
                {
                    if (string.IsNullOrEmpty(stockconfShWork.StockAgentCodeSt))
                    {
                        sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2 OR" + Environment.NewLine;
                        sqlText += "       SLIP.STOCKAGENTCODERF IS NULL)" + Environment.NewLine;

                        SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                        paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd);

                        SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                        paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd + "%");
                    }
                    else
                    {
                        sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2)" + Environment.NewLine;

                        SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                        paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd);

                        SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                        paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd + "%");
                    }
                }
            }


            // �d���`�[�ԍ�
            // 2008/06/30 Del-Start �����ł��Ȃ��Ȃ�\��������̂ō폜 ------------- >>>>>
            //if (stockconfShWork.SupplierSlipNoSt == 0 && stockconfShWork.SupplierSlipNoEd == 0)
            //{
            //    sqlText += "  AND SLIP.SUPPLIERSLIPNORF = SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
            //}
            //else
            //{
            // 2008/06/30 Del-End ---------------------------------------------------- <<<<<
                // �d���`�[�ԍ�(�J�n)
                if (stockconfShWork.SupplierSlipNoSt != 0)
                {
                    sqlText += "  AND SLIP.SUPPLIERSLIPNORF >= @FINDSUPPLIERSLIPNOST" + Environment.NewLine;
                    SqlParameter paraSupplierSlipNoSt = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOST", SqlDbType.Int);
                    paraSupplierSlipNoSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierSlipNoSt);
                }

                // �d���`�[�ԍ�(�I��)
                if (stockconfShWork.SupplierSlipNoEd != 0)
                {
                    sqlText += "  AND SLIP.SUPPLIERSLIPNORF <= @FINDSUPPLIERSLIPNOED" + Environment.NewLine;
                    SqlParameter paraSupplierSlipNoEd = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOED", SqlDbType.Int);
                    paraSupplierSlipNoEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierSlipNoEd);
                }
            //}  2008/06/30 DEL

            // �����`��(�J�n)
            if (!string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumSt) &&
                stockconfShWork.PartySaleSlipNumSt == stockconfShWork.PartySaleSlipNumEd)
            {
                // �J�n�ƏI���������ꍇ�͌����v�̞B�������Ƃ���
                sqlText += "  AND SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUMST" + Environment.NewLine;
                SqlParameter paraPartySaleSlipNumSt = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMST", SqlDbType.NVarChar);
                paraPartySaleSlipNumSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumSt + "%");
            }
            else
            {
                // �����`��(�J�n)
                if (!string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumSt))
                {
                    sqlText += "  AND SLIP.PARTYSALESLIPNUMRF >= @FINDPARTYSALESLIPNUMST" + Environment.NewLine;
                    SqlParameter paraPartySaleSlipNumSt = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMST", SqlDbType.NVarChar);
                    paraPartySaleSlipNumSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumSt);
                }

                // �����`��(�I��)
                if (!string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumEd))
                {
                    if (string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumSt))
                    {
                        sqlText += "  AND (SLIP.PARTYSALESLIPNUMRF <= @FINDPARTYSALESLIPNUMED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUMED2 OR" + Environment.NewLine;
                        sqlText += "       SLIP.PARTYSALESLIPNUMRF IS NULL)" + Environment.NewLine;

                        SqlParameter paraPartySaleSlipNumEd1 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED1", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);

                        SqlParameter paraPartySaleSlipNumEd2 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED2", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);
                    }
                    else
                    {
                        sqlText += "  AND (SLIP.PARTYSALESLIPNUMRF <= @FINDPARTYSALESLIPNUMED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUMED2)" + Environment.NewLine;

                        SqlParameter paraPartySaleSlipNumEd1 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED1", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);

                        SqlParameter paraPartySaleSlipNumEd2 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED2", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);
                    }
                }
            }

            // 2008/06/30 ADD-Start -------------------------------------------------- >>>>>
            // �̔��G���A�R�[�h(�J�n)
            if (stockconfShWork.SalesAreaCodeSt != 0)
            {
                sqlText += "  AND SLIP.SALESAREACODERF >= @FINDSALESAREACODEST" + Environment.NewLine;
                SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@FINDSALESAREACODEST", SqlDbType.Int);
                paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SalesAreaCodeSt);
            }

            // �̔��G���A�R�[�h(�I��)
            if (stockconfShWork.SalesAreaCodeEd != 0)
            {
                //sqlText += "  AND SLIP.SALESAREACODERF >= @FINDSALESAREACODEED" + Environment.NewLine;  // DEL 2008.10.21
                sqlText += "  AND SLIP.SALESAREACODERF <= @FINDSALESAREACODEED" + Environment.NewLine;    // ADD 2008.10.21
                SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@FINDSALESAREACODEED", SqlDbType.Int);
                paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SalesAreaCodeEd);
            }

            // �d���݌Ɏ�񂹋敪
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "  AND DTIL.STOCKORDERDIVCDRF = @FINDSTOCKORDERDIVCD" + Environment.NewLine;
                sqlText += "  AND DTL.STOCKORDERDIVCDRF = @FINDSTOCKORDERDIVCD" + Environment.NewLine;
                SqlParameter paraStockOrderDivCd = sqlCommand.Parameters.Add("@FINDSTOCKORDERDIVCD", SqlDbType.Int);
                paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.StockOrderDivCd);
            }

            // �o�͎w��
            switch (stockconfShWork.OutputDesignated)
            {
                case 1:
                    {
                        // --- UPD 2009/09/08 -------------->>>>>
                        // �d�����́F�u�������@��2:�I�����C�������v&&�u ���㖾�גʔԁi�����j=0�v
                        // sqlText += "  AND (DTIL.WAYTOORDERRF <> 2" + Environment.NewLine;

                        // --- DEL 2013/02/07 BY ������ For Redmine#34611 -------------------------------->>>>>
                        //sqlText += "  AND ( NOT EXISTS ( SELECT * " + Environment.NewLine;
                        //sqlText += "                   FROM UOEORDERDTLRF " + Environment.NewLine;
                        //sqlText += "                   WHERE COMMONSEQNORF = DTIL.COMMONSEQNORF " + Environment.NewLine;
                        //sqlText += "                   AND ENTERPRISECODERF = DTIL.ENTERPRISECODERF " + Environment.NewLine;
                        //sqlText += "                   AND LOGICALDELETECODERF = 0 ) " + Environment.NewLine;
                        // --- DEL 2013/02/07 BY ������ For Redmine#34611 --------------------------------<<<<<
                        sqlText += "  AND ( NOT EXISTS ( " + GetOnLineOrder() + " ) " + Environment.NewLine;// ADD 2013/02/07 BY ������ For Redmine#34611
                        
                        sqlText += "  AND DTIL.SALESSLIPDTLNUMSYNCRF = 0)" + Environment.NewLine;
                        // --- UPD 2009/09/08 --------------<<<<<
                        break;
                    }
                case 2:
                    {
                        // --- UPD 2009/09/08 -------------->>>>>
                        // UOE���F�u�������@=2:�I�����C�������v
                        // sqlText += "  AND DTIL.WAYTOORDERRF = 2" + Environment.NewLine;

                        // --- DEL 2013/02/07 BY ������ For Redmine#34611 -------------------------------->>>>>
                        //sqlText += "  AND EXISTS ( SELECT * " + Environment.NewLine;
                        //sqlText += "               FROM UOEORDERDTLRF " + Environment.NewLine;
                        //sqlText += "               WHERE COMMONSEQNORF = DTIL.COMMONSEQNORF " + Environment.NewLine;
                        //sqlText += "               AND ENTERPRISECODERF = DTIL.ENTERPRISECODERF " + Environment.NewLine;
                        //sqlText += "               AND LOGICALDELETECODERF = 0 ) " + Environment.NewLine;
                        // --- DEL 2013/02/07 BY ������ For Redmine#34611 --------------------------------<<<<<
                        sqlText += "  AND EXISTS ( " + GetOnLineOrder() + " ) " + Environment.NewLine;// ADD 2013/02/07 BY ������ For Redmine#34611
                        // --- UPD 2009/09/08 -------------->>>>>
                        break;
                    }
                case 3:
                    {
                        // �������͕��F�u���㖾�גʔԁi�����j��0�v
                        sqlText += "  AND DTIL.SALESSLIPDTLNUMSYNCRF <> 0" + Environment.NewLine;
                        break;
                    }
                case 4:
                    {
                        // --- UPD 2009/09/08 -------------->>>>>
                        // UOE�A���}�b�`�F�u�������@=2:�I�����C�������v&&�u�ύX�O�d���P�����d���P���v
                        // sqlText += "  AND (DTIL.WAYTOORDERRF = 2" + Environment.NewLine;

                        // --- DEL 2013/02/07 BY ������ For Redmine#34611 -------------------------------->>>>>
                        //sqlText += "  AND ( EXISTS ( SELECT * " + Environment.NewLine;
                        //sqlText += "               FROM UOEORDERDTLRF " + Environment.NewLine;
                        //sqlText += "               WHERE COMMONSEQNORF = DTIL.COMMONSEQNORF " + Environment.NewLine;
                        //sqlText += "               AND ENTERPRISECODERF = DTIL.ENTERPRISECODERF " + Environment.NewLine;
                        //sqlText += "               AND LOGICALDELETECODERF = 0 ) " + Environment.NewLine;
                        // --- DEL 2013/02/07 BY ������ For Redmine#34611 --------------------------------<<<<<
                        sqlText += "  AND ( EXISTS ( " + GetOnLineOrder() + " ) " + Environment.NewLine;// ADD 2013/02/07 BY ������ For Redmine#34611
                        
                        // �C�� 2009/04/27 >>>
                        //sqlText += "       AND DTIL.BFSTOCKUNITPRICEFLRF = STOCKUNITPRICEFLRF)" + Environment.NewLine;
                        sqlText += "       AND DTIL.BFSTOCKUNITPRICEFLRF <> STOCKUNITPRICEFLRF)" + Environment.NewLine;
                        // �C�� 2009/04/27 <<<
                        // --- UPD 2009/09/08 -------------->>>>>
                        break;
                    }
                default: // 0:�S��
                    break;
            }
            // 2008/06/30 ADD-End ---------------------------------------------------- <<<<<

            return sqlText;
        }

        // --- ADD 2013/02/07 BY ������ For Redmine#34611 -------------------------------->>>>>
        /// <summary>
        /// �I�����C�����������N�G���̎擾
        /// </summary>
        ///<returns>�I�����C�������̌����N�G��</returns>
        private string GetOnLineOrder()
        {
            // UOE�f�[�^�̌���
            // ���������͈ȉ��ł��B
            // �d�����𖾍׃f�[�^�D��ƃR�[�h=�d�����׃f�[�^�D��ƃR�[�h 
            // �d�����𖾍׃f�[�^�D�d���`���i���j=�d�����׃f�[�^�D�d���`��
            // �d�����𖾍׃f�[�^�D�d�����גʔԁi���j=�d�����׃f�[�^�D�d�����גʔ� 
            // �d�����׃f�[�^.�������@ = 2
            // �d�����׃f�[�^.�_���폜�敪 = 0

            StringBuilder sqlStringBulid = new StringBuilder();
            sqlStringBulid.Append(" SELECT * ").Append(Environment.NewLine);
            sqlStringBulid.Append(" FROM STOCKDETAILRF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            sqlStringBulid.Append(" WHERE ENTERPRISECODERF = DTIL.ENTERPRISECODERF ").Append(Environment.NewLine);
            sqlStringBulid.Append(" AND STOCKSLIPDTLNUMRF = DTIL.STOCKSLIPDTLNUMSRCRF ").Append(Environment.NewLine);
            sqlStringBulid.Append(" AND SUPPLIERFORMALRF = DTIL.SUPPLIERFORMALSRCRF ").Append(Environment.NewLine);
            sqlStringBulid.Append(" AND WAYTOORDERRF = 2 ").Append(Environment.NewLine);
            sqlStringBulid.Append(" AND LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);

            return sqlStringBulid.ToString();
        }
        // --- ADD 2013/02/07 BY ������ For Redmine#34611 --------------------------------<<<<<
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� StockConfWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockConfWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.05</br>
        /// <br>Update Note: 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
        /// </remarks>
        private StockConfWork CopyToStockConfWorkFromReader(ref SqlDataReader myReader)
        {
            StockConfWork wkStockConfWork = new StockConfWork();

            // 2008/06/30 UPD-Start -------------------------------------------------- >>>>>
            #region �N���X�֊i�[
            wkStockConfWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            wkStockConfWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            wkStockConfWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkStockConfWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkStockConfWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkStockConfWork.ArrivalGoodsDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            wkStockConfWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            wkStockConfWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            wkStockConfWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            wkStockConfWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            wkStockConfWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            wkStockConfWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            wkStockConfWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            wkStockConfWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            wkStockConfWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            wkStockConfWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            wkStockConfWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkStockConfWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            wkStockConfWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            wkStockConfWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            wkStockConfWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockConfWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStockConfWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockConfWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkStockConfWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
            wkStockConfWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockConfWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkStockConfWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStockConfWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkStockConfWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkStockConfWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            wkStockConfWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
            wkStockConfWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            wkStockConfWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
            wkStockConfWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            wkStockConfWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
            wkStockConfWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockConfWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
            wkStockConfWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            wkStockConfWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
            wkStockConfWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            wkStockConfWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkStockConfWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkStockConfWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            wkStockConfWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            wkStockConfWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            wkStockConfWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            wkStockConfWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // ADD 2008.10.29 >>>
            wkStockConfWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            wkStockConfWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            wkStockConfWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
            // ADD 2008.10.29 <<<
            // ADD 2009.01.06 >>>>>>>>>>
            wkStockConfWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
            // ADD 2009.01.06 <<<<<<<<<<
            wkStockConfWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
            wkStockConfWork.StockPriceConsTaxDen = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXDENRF"));
            wkStockConfWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
            wkStockConfWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));
            wkStockConfWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
            // --- ADD START 3H ���� 2020/02/27 ---------->>>>>
            // �d�������Őŗ�
            wkStockConfWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
            // --- ADD END 3H ���� 2020/02/27 ----------<<<<<
            wkStockConfWork.TaxRateExistFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXRATEEXISTFLAG")) > 0;// ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
            #endregion

            #region OLD-DC.NS�N���X�֊i�[
            //wkStockConfWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //wkStockConfWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            //wkStockConfWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            //wkStockConfWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            //wkStockConfWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            //wkStockConfWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            //wkStockConfWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            //wkStockConfWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            //wkStockConfWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            //wkStockConfWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            //wkStockConfWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            //wkStockConfWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            //wkStockConfWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            //wkStockConfWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            //wkStockConfWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
            //wkStockConfWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
            //wkStockConfWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
            //wkStockConfWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
            //wkStockConfWork.DetailGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRECODERF"));
            //wkStockConfWork.DetailGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRENAMERF"));
            //wkStockConfWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            //wkStockConfWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            //wkStockConfWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            //wkStockConfWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            //wkStockConfWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            //wkStockConfWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            //wkStockConfWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            //wkStockConfWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            //wkStockConfWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
            //wkStockConfWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            //wkStockConfWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            //wkStockConfWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            //wkStockConfWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            //wkStockConfWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            //wkStockConfWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            //wkStockConfWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
            //wkStockConfWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            //wkStockConfWork.UnitCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNITCODERF"));
            //wkStockConfWork.UnitName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITNAMERF"));
            //wkStockConfWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            //wkStockConfWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            //wkStockConfWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
            //wkStockConfWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            //wkStockConfWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
            //wkStockConfWork.OrderFormNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERFORMNORF"));
            //wkStockConfWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            //wkStockConfWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            //wkStockConfWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            //wkStockConfWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            //wkStockConfWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            //wkStockConfWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            #endregion
            // 2008/06/30 UPD-End --------------------------------------------------- <<<<<

            return wkStockConfWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>        
        /// <returns></returns>
        /// <br>Update Note: 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
        private StockConfSlipTtlWork CopyToStockConfSlipTtlWorkFromReader(ref SqlDataReader myReader)
        {
            StockConfSlipTtlWork wkStockConfSlipTtlWork = new StockConfSlipTtlWork();

            // 2008/06/30 UPD-Start -------------------------------------------------- >>>>>
            #region �N���X�֊i�[
            wkStockConfSlipTtlWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            wkStockConfSlipTtlWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            wkStockConfSlipTtlWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkStockConfSlipTtlWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkStockConfSlipTtlWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkStockConfSlipTtlWork.ArrivalGoodsDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            wkStockConfSlipTtlWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            wkStockConfSlipTtlWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            wkStockConfSlipTtlWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            wkStockConfSlipTtlWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            wkStockConfSlipTtlWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            wkStockConfSlipTtlWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            wkStockConfSlipTtlWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            wkStockConfSlipTtlWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
            wkStockConfSlipTtlWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
            wkStockConfSlipTtlWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            wkStockConfSlipTtlWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            wkStockConfSlipTtlWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            wkStockConfSlipTtlWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            wkStockConfSlipTtlWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            // ADD 2008.10.29 >>>
            wkStockConfSlipTtlWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            wkStockConfSlipTtlWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            wkStockConfSlipTtlWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
            wkStockConfSlipTtlWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
            // ADD 2008.10.29 <<<
            //2009.01.09 >>>>
            wkStockConfSlipTtlWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));
            wkStockConfSlipTtlWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
            // --- ADD START 3H ���� 2020/02/27 ---------->>>>>
            // �d�������Őŗ�
            wkStockConfSlipTtlWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
            // --- ADD END 3H ���� 2020/02/27 ----------<<<<<
            //2009.01.09 <<<<

            // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
            // �d�����ה�ېő��݃t���O
            wkStockConfSlipTtlWork.TaxFreeExistFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXFREEEXISTFLAG")) > 0;
            // �d�����׉ېő��݃t���O
            wkStockConfSlipTtlWork.TaxRateExistFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXRATEEXISTFLAG")) > 0;
            // �d�����z��ې�
            wkStockConfSlipTtlWork.StockPriceTaxFreeCrf = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXFREECRF"));
            // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<

            #endregion

            #region OLD-DC.NS�N���X�֊i�[
            //wkStockConfSlipTtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //wkStockConfSlipTtlWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            //wkStockConfSlipTtlWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            //wkStockConfSlipTtlWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            //wkStockConfSlipTtlWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            //wkStockConfSlipTtlWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            //wkStockConfSlipTtlWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            //wkStockConfSlipTtlWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            //wkStockConfSlipTtlWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            //wkStockConfSlipTtlWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            //wkStockConfSlipTtlWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            //wkStockConfSlipTtlWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            //wkStockConfSlipTtlWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            //wkStockConfSlipTtlWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
            //wkStockConfSlipTtlWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
            //wkStockConfSlipTtlWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            //wkStockConfSlipTtlWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            #endregion
            // 2008/06/30 UPD-End --------------------------------------------------- <<<<<

            return wkStockConfSlipTtlWork;
        }


        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
