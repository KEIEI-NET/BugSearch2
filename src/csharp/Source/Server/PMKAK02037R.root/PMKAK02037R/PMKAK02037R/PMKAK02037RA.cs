//***************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���ԕi�\��ꗗ�\
// �v���O�����T�v   : �d���ԕi�\��ꗗ�\ �����[�g�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI���� ����
// �� �� ��   2013/01/28 �C�����e : �V�K�쐬 �d���ԕi�\��@�\�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�֓� �a�G
// �C �� ��  2013/02/18  �C�����e : �d�����̃Z�b�g���e�C��
//----------------------------------------------------------------------------//
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d���ԕi�\��ꗗ�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���ԕi�\��ꗗ�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : FSI���� ����</br>
    /// <br>Date       :  2013/01/28</br>
    /// </remarks>
    [Serializable]
    public class StockRetPlnTableDB : RemoteDB, IStockRetPlnTableDB
    {
        /// <summary>
        /// �d���ԕi�\��ꗗ�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public StockRetPlnTableDB()
            :
            base("PMKAK02039D", "Broadleaf.Application.Remoting.ParamData.StockRetPlnList", "STOCKSLIPRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̎d���ԕi�\��ꗗ�\���LIST��߂��܂�
        /// </summary>
        /// <param name="StockRetPlnList">��������</param>
        /// <param name="stockRetPlnParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d���ԕi�\��ꗗ�\���LIST��߂��܂�</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        public int Search(out object StockRetPlnList, object stockRetPlnParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            StockRetPlnList = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockRetList(out StockRetPlnList, stockRetPlnParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockRetPlnTableDB.Search");
                StockRetPlnList = new ArrayList();
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
        /// �w�肳�ꂽ�����̎d���ԕi�\��ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objStockRetPlnList">��������</param>
        /// <param name="objStockRetPlnParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d���ԕi�\��ꗗ�\���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        public int SearchStockRetList(out object objStockRetPlnList, object objStockRetPlnParamWork, ref SqlConnection sqlConnection)
        {
            StockRetPlnParamWork stockRetPlnParamWork = null;

            ArrayList stockRetPlnParamWorkList = objStockRetPlnParamWork as ArrayList;
            ArrayList StockRetPlnListList = null;

            if (stockRetPlnParamWorkList == null)
            {
                stockRetPlnParamWork = objStockRetPlnParamWork as StockRetPlnParamWork;
            }
            else
            {
                if (stockRetPlnParamWorkList.Count > 0)
                    stockRetPlnParamWork = stockRetPlnParamWorkList[0] as StockRetPlnParamWork;
            }

            int status = SearchArrivalListProc(out StockRetPlnListList, stockRetPlnParamWork, ref sqlConnection);
            objStockRetPlnList = StockRetPlnListList;
            return status;

        }

        /// <summary>
        /// �w�肳�ꂽ�����̎d���ԕi�\��ꗗ�\���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="StockRetPlnListList">��������</param>
        /// <param name="stockRetPlnParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d���ԕi�\��ꗗ�\���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        public int SearchArrivalListProc(out ArrayList StockRetPlnListList, StockRetPlnParamWork stockRetPlnParamWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandTimeout = 600; // �^�C���A�E�g��10��
                sqlCommand.CommandText += MakeSelectString(ref sqlCommand, stockRetPlnParamWork)
                                       + MakeWhereString(ref sqlCommand, stockRetPlnParamWork)
                                       + MakeOrderByString(ref sqlCommand, stockRetPlnParamWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockRetPlnListFromReader(ref myReader));

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

            StockRetPlnListList = al;

            return status;
        }
        #endregion

        #region [SQL��������]
        /// <summary>
        /// SQL����
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="stockRetPlnParamWork">���������i�[�N���X</param>
        /// <returns>�d���ԕi�\��ꗗ�\��SQL������</returns>
        /// <br>Note       : �d���ԕi�\��ꗗ�\��SQL���쐬���Ė߂��܂�</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        private string MakeSelectString(ref SqlCommand sqlCommand, StockRetPlnParamWork stockRetPlnParamWork)
        {
            string sqlstring = string.Empty;
            sqlstring += "SELECT STKSLP.ENTERPRISECODERF" + Environment.NewLine; //��ƃR�[�h
            sqlstring += "    ,STKSLP.STOCKSECTIONCDRF" + Environment.NewLine; //���_�R�[�h
            sqlstring += "    ,SECIN.SECTIONGUIDESNMRF" + Environment.NewLine; //���_����
            sqlstring += "    ,STKSLP.SUPPLIERCDRF" + Environment.NewLine; //�d����R�[�h
            sqlstring += "    ,STKSLP.SUPPLIERSNMRF" + Environment.NewLine;//�d���於
            sqlstring += "    ,STKDTL.SUPPLIERFORMALRF" + Environment.NewLine;//�d���`��
            sqlstring += "    ,STKSLP.INPUTDAYRF" + Environment.NewLine;//���͓�
            sqlstring += "    ,STKSLP.STOCKDATERF" + Environment.NewLine;//�d����
            // --- ADD 2013/02/18 ---------->>>>>
            // �d���`�[���s�����擾
            sqlstring += "    ,STKSLP.STOCKSLIPPRINTDATERF" + Environment.NewLine;//�d���`�[���s����
            // --- ADD 2013/02/18 ----------<<<<<
            sqlstring += "    ,STKDTL.SUPPLIERSLIPNORF" + Environment.NewLine;//�d���`�[�ԍ�
            sqlstring += "    ,STKDTL.GOODSNORF" + Environment.NewLine;//���[�J�[��
            sqlstring += "    ,STKDTL.BLGOODSCODERF" + Environment.NewLine;//BL�R�[�h
            sqlstring += "    ,STKDTL.GOODSMAKERCDRF" + Environment.NewLine;//���i���[�J�[�R�[�h
            sqlstring += "    ,STKDTL.GOODSNAMERF" + Environment.NewLine;//���i��
            sqlstring += "    ,STKDTL.STOCKCOUNTRF" + Environment.NewLine;//����
            sqlstring += "    ,STKSLP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;//���l
            sqlstring += "    ,STKSLP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;//�`�[���z�i�Ŕ��j
            sqlstring += "    ,STKSLP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;//�`�[���z�i�ō��j
            sqlstring += "    ,STKSLP.STOCKPRICECONSTAXRF AS SLPCONSTAXRF" + Environment.NewLine;//�`�[����Łi�ō��j
            sqlstring += "    ,STKDTL.STOCKUNITPRICEFLRF" + Environment.NewLine;//�P���i�Ŕ��j
            sqlstring += "    ,STKDTL.STOCKUNITTAXPRICEFLRF" + Environment.NewLine;//�P���i�ō��j
            sqlstring += "    ,STKDTL.STOCKPRICETAXEXCRF" + Environment.NewLine;//���׎d�����z�i�Ŕ��j
            sqlstring += "    ,STKDTL.STOCKPRICETAXINCRF" + Environment.NewLine;//���׎d�����z�i�ō��j
            sqlstring += "    ,STKDTL.LISTPRICETAXEXCFLRF" + Environment.NewLine;//�艿�i�Ŕ��j
            sqlstring += "    ,STKDTL.LISTPRICETAXINCFLRF" + Environment.NewLine;//�艿�i�ō��j
            sqlstring += "    ,STKDTL.STOCKPRICECONSTAXRF AS DTLCONSTAXRF" + Environment.NewLine;//���׏���Ŋz
            sqlstring += "    ,STKSLP.LOGICALDELETECODERF AS SLPLOGDELCD" + Environment.NewLine;//�d���_���폜�敪
            sqlstring += "    ,STKDTL.LOGICALDELETECODERF AS STLLOGDELCD" + Environment.NewLine;//���ט_���폜�敪
            sqlstring += "    ,STKSLP.SUPPCTAXLAYCDRF" + Environment.NewLine;//����œ]�ŋ敪
            sqlstring += "    ,STKDTL.TAXATIONCODERF" + Environment.NewLine;//�ېŋ敪
            sqlstring += "    ,STKDTL.SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;//���㖾�גʔԁi�����j
            sqlstring += "    ,STKSLP.SUPPLIERSLIPCDRF" + Environment.NewLine;//�d���`�[�敪
            sqlstring += " FROM STOCKSLIPRF AS STKSLP WITH (READUNCOMMITTED)" + Environment.NewLine;        //�d�����z
            sqlstring += " LEFT JOIN STOCKDETAILRF AS STKDTL WITH (READUNCOMMITTED)" + Environment.NewLine; //�d������
            sqlstring += " ON (STKDTL.ENTERPRISECODERF = STKSLP.ENTERPRISECODERF AND STKDTL.SUPPLIERSLIPNORF = STKSLP.SUPPLIERSLIPNORF AND STKDTL.SUPPLIERFORMALRF = STKSLP.SUPPLIERFORMALRF)" + Environment.NewLine;
            sqlstring += " LEFT JOIN SECINFOSETRF AS SECIN WITH (READUNCOMMITTED) " + Environment.NewLine;  //���_���ݒ�}�X�^
            sqlstring += " ON (SECIN.SECTIONCODERF = STKSLP.STOCKSECTIONCDRF AND SECIN.ENTERPRISECODERF = STKSLP.ENTERPRISECODERF)" + Environment.NewLine;

            return sqlstring;
        }
        #endregion

        #region [WHERE�吶������]
        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="stockRetPlnParamWork">���������i�[�N���X</param>
        /// <returns>�d���ԕi�\��ꗗ�\��SQL������</returns>
        /// <br>Note       : �d���ԕi�\��ꗗ�\��SQL���쐬���Ė߂��܂�</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockRetPlnParamWork stockRetPlnParamWork)
        {

            string wherestring = "WHERE ";
            //�Œ����
            //��ƃR�[�h
            wherestring += "STKSLP.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockRetPlnParamWork.EnterpriseCode);


            //������p�����[�^�̒l�ɂ�蓮�I�ω��̍���
            //���_�R�[�h (�z��)
            if (stockRetPlnParamWork.SectionCodes.Length > 0)
            {
                string[] sections = stockRetPlnParamWork.SectionCodes;

                for (int i = 0; i < sections.Length; i++)
                {
                    sections[i] = "'" + sections[i] + "'";
                }

                string inText = string.Join(", ", sections);

                wherestring += "AND STKSLP.STOCKSECTIONCDRF IN (" + inText + ") ";
            }

            // �d���`�� 3:�ԕi�\��
            wherestring += "AND STKDTL.SUPPLIERFORMALRF = 3	";

            //�J�n�d����R�[�h
            if (stockRetPlnParamWork.SupplierCdSt != 0)
            {
                wherestring += "AND STKSLP.SUPPLIERCDRF>=@SUPPLIERCDST ";
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@SUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(stockRetPlnParamWork.SupplierCdSt);
            }

            //�I���d����R�[�h
            if (stockRetPlnParamWork.SupplierCdEd != 0)
            {
                wherestring += "AND STKSLP.SUPPLIERCDRF<=@SUPPLIERCDED ";
                SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@SUPPLIERCDED", SqlDbType.Int);
                paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(stockRetPlnParamWork.SupplierCdEd);
            }

            // ���t�w��
            // 0:�`�[���t 1:���͓��t
            if (stockRetPlnParamWork.PrintDailyFooter == 0)
            {
                //�J�n�`�[���t
                if (stockRetPlnParamWork.InputDaySt != 0)
                {
                    // --- DEL 2013/02/18 ---------->>>>>
                    //wherestring += "AND STKSLP.STOCKDATERF>=@INPUTDAYST ";
                    // --- DEL 2013/02/18 ----------<<<<<
                    // --- ADD 2013/02/18 ---------->>>>>
                    wherestring += "AND STKSLP.STOCKSLIPPRINTDATERF>=@INPUTDAYST ";
                    // --- ADD 2013/02/18 ----------<<<<<

                    SqlParameter paraInputDaySt = sqlCommand.Parameters.Add("@INPUTDAYST", SqlDbType.Int);
                    paraInputDaySt.Value = SqlDataMediator.SqlSetInt32(stockRetPlnParamWork.InputDaySt);
                }

                //�I���`�[���t
                if (stockRetPlnParamWork.InputDayEd != 0)
                {
                    // --- DEL 2013/02/18 ---------->>>>>
                    //wherestring += "AND STKSLP.STOCKDATERF<=@INPUTDAYED ";
                    // --- DEL 2013/02/18 ----------<<<<<
                    // --- ADD 2013/02/18 ---------->>>>>
                    wherestring += "AND STKSLP.STOCKSLIPPRINTDATERF<=@INPUTDAYED ";
                    // --- ADD 2013/02/18 ----------<<<<<
                    SqlParameter paraInputDayEd = sqlCommand.Parameters.Add("@INPUTDAYED", SqlDbType.Int);
                    paraInputDayEd.Value = SqlDataMediator.SqlSetInt32(stockRetPlnParamWork.InputDayEd);
                }
            }
            else if (stockRetPlnParamWork.PrintDailyFooter == 1)
            {
                //�J�n���͓��t
                if (stockRetPlnParamWork.InputDaySt != 0)
                {
                    wherestring += "AND STKSLP.INPUTDAYRF>=@INPUTDAYST ";
                    SqlParameter paraInputDaySt = sqlCommand.Parameters.Add("@INPUTDAYST", SqlDbType.Int);
                    paraInputDaySt.Value = SqlDataMediator.SqlSetInt32(stockRetPlnParamWork.InputDaySt);
                }

                //�I�����͓��t
                if (stockRetPlnParamWork.InputDayEd != 0)
                {
                    wherestring += "AND STKSLP.INPUTDAYRF<=@INPUTDAYED ";
                    SqlParameter paraInputDayEd = sqlCommand.Parameters.Add("@INPUTDAYED", SqlDbType.Int);
                    paraInputDayEd.Value = SqlDataMediator.SqlSetInt32(stockRetPlnParamWork.InputDayEd);
                }
            }


            // ���s�^�C�v(�d���f�[�^�_���폜�敪)
            if (stockRetPlnParamWork.MakeShowDiv == 0)//�ʏ�
            {
                // �o�͎w��(�d�����׃f�[�^�_���폜�敪)
                if (stockRetPlnParamWork.SlipDiv == 0) // 0:�ԕi�\��̂�
                {
                    // �d���f�[�^ �_���폜:0,�d�����׃f�[�^ �_���폜:0,���㖾�גʔԁi�����j:0�ȊO
                    wherestring += "AND STKSLP.LOGICALDELETECODERF=0 AND STKDTL.LOGICALDELETECODERF=0 AND STKDTL.SALESSLIPDTLNUMSYNCRF>0 ";
                }
                else if (stockRetPlnParamWork.SlipDiv == 1)// 1:�ԕi�ς̂�
                {
                    // �d���f�[�^�_���폜:0�A�d�����׃f�[�^�_���폜:1�A���㖾�גʔԁi�����j:0
                    // �d���f�[�^�_���폜:1�A�d�����׃f�[�^�_���폜:1�A���㖾�גʔԁi�����j:0
                    wherestring += "AND (STKSLP.LOGICALDELETECODERF=0 AND STKDTL.LOGICALDELETECODERF=1 AND STKDTL.SALESSLIPDTLNUMSYNCRF=0 OR STKSLP.LOGICALDELETECODERF=1 AND STKDTL.LOGICALDELETECODERF=1 AND STKDTL.SALESSLIPDTLNUMSYNCRF=0) ";
                }
                else if (stockRetPlnParamWork.SlipDiv == 2)// 2:���ׂ�
                {
                    wherestring += "AND (STKSLP.LOGICALDELETECODERF=0 AND STKDTL.LOGICALDELETECODERF IN (0,1) AND STKDTL.SALESSLIPDTLNUMSYNCRF>=0 OR STKSLP.LOGICALDELETECODERF=1 AND STKDTL.LOGICALDELETECODERF=1 AND STKDTL.SALESSLIPDTLNUMSYNCRF=0) ";
                }
            }
            else if (stockRetPlnParamWork.MakeShowDiv == 1)//�폜
            {
                wherestring += "AND STKSLP.LOGICALDELETECODERF=1 ";
                wherestring += "AND STKDTL.LOGICALDELETECODERF=1 ";

                // �o�͎w��(�d�����׃f�[�^�_���폜�敪)
                if (stockRetPlnParamWork.SlipDiv == 0) // 0:�ԕi�\��̂�
                {
                    wherestring += "AND STKDTL.SALESSLIPDTLNUMSYNCRF>0 ";
                }
                else if (stockRetPlnParamWork.SlipDiv == 2)// 2:���ׂ�
                {
                    wherestring += "AND STKDTL.SALESSLIPDTLNUMSYNCRF>0 ";
                }
            }
            return wherestring;
        }
        #endregion

        #region [ORDER BY�吶������]
        /// <summary>
        /// ORDER BY�吶��
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="stockRetPlnParamWork">���������i�[�N���X</param>
        /// <returns>�d���ԕi�\��ꗗ�\��SQL������</returns>
        /// <br>Note       : �d���ԕi�\��ꗗ�\��SQL���쐬���Ė߂��܂�</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       : 2013/01/28</br>
        private string MakeOrderByString(ref SqlCommand sqlCommand, StockRetPlnParamWork stockRetPlnParamWork)
        {
            string sqlstring = "ORDER BY STKSLP.STOCKSECTIONCDRF ,STKSLP.SUPPLIERCDRF,STKSLP.STOCKDATERF,STKSLP.INPUTDAYRF,STKSLP.SUPPLIERSLIPNORF";
    
            return sqlstring;
        }
        #endregion


        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� PreChargedDataSelectResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesConfWork</returns>
        /// <remarks>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private StockRetPlnList CopyToStockRetPlnListFromReader(ref SqlDataReader myReader)
        {
            StockRetPlnList StockRetPlnList = new StockRetPlnList();

            #region �N���X�֊i�[
            StockRetPlnList.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
            StockRetPlnList.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
            StockRetPlnList.SlpConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLPCONSTAXRF"));
            StockRetPlnList.DtlConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTLCONSTAXRF"));
            StockRetPlnList.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            StockRetPlnList.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
            StockRetPlnList.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            StockRetPlnList.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
            StockRetPlnList.ListPriceTaxExc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            StockRetPlnList.ListPriceTaxInc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
            StockRetPlnList.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            StockRetPlnList.SlpLogDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLPLOGDELCD"));
            StockRetPlnList.DtlLogDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STLLOGDELCD"));
            StockRetPlnList.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));
            StockRetPlnList.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
            StockRetPlnList.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            StockRetPlnList.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            StockRetPlnList.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            StockRetPlnList.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            StockRetPlnList.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));

            // --- DEL 2013/02/18 ---------->>>>>
            //StockRetPlnList.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            // --- DEL 2013/02/18 ----------<<<<<
            // --- ADD 2013/02/18 ---------->>>>>
            // �`�[���t�͎d���`�[���s������擾
            StockRetPlnList.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));
            // --- ADD 2013/02/18 ----------<<<<<
            StockRetPlnList.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            StockRetPlnList.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            StockRetPlnList.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            StockRetPlnList.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            StockRetPlnList.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            StockRetPlnList.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            StockRetPlnList.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            StockRetPlnList.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            #endregion

            return StockRetPlnList;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
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
        #endregion
    }
}