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
    /// �݌ɊǗ��S�̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20036�@�ē��@�떾</br>
    /// <br>Date       : 2007.03.02</br>
    /// <br></br>
    /// <br>Update Note: 22008 ���� ���n PM.NS�p�ɏC��</br>
    /// <br>Update Note: 2009/12/02 ��r�� �I���^�p�敪�̒ǉ�</br>
    /// <br>Update Note: 2011/08/29 ���J �A�� 1016 �u���݌ɕ\���敪�v���ɒǉ�</br>
    /// <br>Update Note: 2012/06/08 lanl #Redmine30282 �u�I���f�[�^�폜�敪�v���ɒǉ�</br>
    /// <br>Update Note: 2012/07/02 �O�ˁ@�L��u�ړ����݌Ɏ����o�^�敪�v����ʂɒǉ�</br>
    /// <br>Update Note: 2014/10/27 wangf </br>
    /// <br>           : Redmine#43854��ʂɗ�u�ړ��`�[�o�͐�敪�v�ǉ�</br>
    /// </remarks>
    [Serializable]
    public class StockMngTtlStDB : RemoteDB, IStockMngTtlStDB
    {
        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        /// </remarks>
        public StockMngTtlStDB()
            :
            base("MAZAI09116D", "Broadleaf.Application.Remoting.ParamData.StockMngTtlStWork", "STOCKMNGTTLSTRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="stockmngttlstWork">��������</param>
        /// <param name="parastockmngttlstWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int Search(out object stockmngttlstWork, object parastockmngttlstWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockmngttlstWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockMngTtlStProc(out stockmngttlstWork, parastockmngttlstWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMngTtlStDB.Search");
                stockmngttlstWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objstockmngttlstWork">��������</param>
        /// <param name="parastockmngttlstWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int SearchStockMngTtlStProc(out object objstockmngttlstWork, object parastockmngttlstWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            StockMngTtlStWork stockmngttlstWork = null; 

            ArrayList stockmngttlstWorkList = parastockmngttlstWork as ArrayList;
            if (stockmngttlstWorkList == null)
            {
                stockmngttlstWork = parastockmngttlstWork as StockMngTtlStWork;
            }
            else
            {
                if (stockmngttlstWorkList.Count > 0)
                    stockmngttlstWork = stockmngttlstWorkList[0] as StockMngTtlStWork;
            }

            int status = SearchStockMngTtlStProc(out stockmngttlstWorkList, stockmngttlstWork, readMode, logicalMode, ref sqlConnection);
            objstockmngttlstWork = stockmngttlstWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">��������</param>
        /// <param name="stockmngttlstWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int SearchStockMngTtlStProc(out ArrayList stockmngttlstWorkList, StockMngTtlStWork stockmngttlstWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchStockMngTtlStProcProc(out stockmngttlstWorkList, stockmngttlstWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">��������</param>
        /// <param name="stockmngttlstWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        private int SearchStockMngTtlStProcProc(out ArrayList stockmngttlstWorkList, StockMngTtlStWork stockmngttlstWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;
                selectTxt += "SELECT STK.*, SEC.SECTIONGUIDENMRF,STK2.STOCKMOVEFIXCODERF AS STOCKMOVEFIXCODE FROM STOCKMNGTTLSTRF AS STK" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " LEFT JOIN STOCKMNGTTLSTRF AS STK2" + Environment.NewLine;
                selectTxt += " ON STK2.ENTERPRISECODERF =STK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STK2.SECTIONCODERF = '00' " + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockmngttlstWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockMngTtlStWorkFromReader(ref myReader));

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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            stockmngttlstWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                StockMngTtlStWork stockmngttlstWork = new StockMngTtlStWork();

                // XML�̓ǂݍ���
                stockmngttlstWork = (StockMngTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockMngTtlStWork));
                if (stockmngttlstWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref stockmngttlstWork, readMode, ref sqlConnection,ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(stockmngttlstWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMngTtlStDB.Read");
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// 
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int ReadProc(ref StockMngTtlStWork stockmngttlstWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref stockmngttlstWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        private int ReadProcProc(ref StockMngTtlStWork stockmngttlstWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;
                selectTxt += "SELECT STK.*, SEC.SECTIONGUIDENMRF,STK2.STOCKMOVEFIXCODERF AS STOCKMOVEFIXCODE FROM STOCKMNGTTLSTRF AS STK" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " LEFT JOIN STOCKMNGTTLSTRF AS STK2" + Environment.NewLine;
                selectTxt += " ON STK2.ENTERPRISECODERF =STK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STK2.SECTIONCODERF = '00' " + Environment.NewLine;
                selectTxt += " WHERE STK.ENTERPRISECODERF=@FINDENTERPRISECODE AND STK.SECTIONCODERF=@FINDSECTIONCODE";

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        stockmngttlstWork = CopyToStockMngTtlStWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        /// <br>Update Note: 2012/06/13 yangyi</br>
        /// <br>�Ǘ��ԍ�   �F10801804-00 2012/06/27�z�M��</br>
        /// <br>             Redmine#30437 ��1002 No.33 �݌ɑS�̐ݒ� �S�Ѓ��R�[�h�X�V���ɔ�������T�[�o�[�G���[�̏C��</br>
        public int Write(ref object stockmngttlstWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(stockmngttlstWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteStockMngTtlStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                // DEL yangyi 2012/06/13 Redmine#30437 ------------->>>>>
                //StockMngTtlStWork paraWork = paraList[0] as StockMngTtlStWork;
                
                ////�S�Аݒ���X�V�����ꍇ�́A���̍��ڂɂ����f������
                //if (paraWork.SectionCode == _allSecCode)
                //{
                //    UpdateAllSecStockMngTtlSt(ref paraList, ref sqlConnection, ref sqlTransaction);
                //}
                // DEL yangyi 2012/06/13 Redmine#30437 -------------<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                stockmngttlstWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMngTtlStDB.Write(ref object stockmngttlstWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int WriteStockMngTtlStProc(ref ArrayList stockmngttlstWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteStockMngTtlStProcProc(ref stockmngttlstWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        /// <br>Update Note: 2009/12/02 ��r�� �I���^�p�敪�̒ǉ�</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             #Redmine30282 �u�I���f�[�^�폜�敪�v���ɒǉ��@</br>
        /// <br>Update Note: 2012/07/02 �O�ˁ@�L��</br>
        /// <br>             �u�ړ����݌Ɏ����o�^�敪�v����ʂɒǉ��@</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854��ʂɗ�u�ړ��`�[�o�͐�敪�v�ǉ�</br>
        private int WriteStockMngTtlStProcProc(ref ArrayList stockmngttlstWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (stockmngttlstWorkList != null)
                {
                    for (int i = 0; i < stockmngttlstWorkList.Count; i++)
                    {
                        StockMngTtlStWork stockmngttlstWork = stockmngttlstWorkList[i] as StockMngTtlStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM STOCKMNGTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != stockmngttlstWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (stockmngttlstWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �X�V����SQL������
                            string sqlText = string.Empty;
                            sqlText += "UPDATE STOCKMNGTTLSTRF SET " + Environment.NewLine;
                            sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " , STOCKMOVEFIXCODERF=@STOCKMOVEFIXCODE" + Environment.NewLine;
                            sqlText += " , STOCKPOINTWAYRF=@STOCKPOINTWAY" + Environment.NewLine;
                            sqlText += " , FRACTIONPROCCDRF=@FRACTIONPROCCD" + Environment.NewLine;
                            // --- ADD 2009/12/02 ---------->>>>>
                            // �I���^�p�敪
                            sqlText += " , INVENTORYMNGDIVRF=@INVENTORYMNGDIV" + Environment.NewLine;
                            // --- ADD 2009/12/02 ----------<<<<<
                            // ------------- ADD 2011/08/29 ---------------- >>>>>
                            // ���݌ɕ\���敪
                            sqlText += " , PRESTCKCNTDSPDIVRF=@PRESTCKCNTDSPDIV" + Environment.NewLine;
                            // ------------- ADD 2011/08/29 ---------------- <<<<<
                            // ------------- ADD 2012/06/08 Redmine#30282 ---------------- >>>>>
                            // �I���f�[�^�폜�敪
                            sqlText += " , INVNTRYDTDELDIVRF=@INVNTRYDTDELDIV" + Environment.NewLine;
                            // ------------- ADD 2012/06/08 Redmine#30282 ---------------- <<<<<
                            // --- ADD �O�� 2012/07/02 ---------->>>>>
                            // �ړ����݌Ɏ����o�^�敪
                            sqlText += " , MOVESTOCKAUTOINSDIVRF=@MOVESTOCKAUTOINSDIV" + Environment.NewLine;
                            // --- ADD �O�� 2012/07/02 ----------<<<<<
                            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�--------->>>>
                            // �ړ��`�[�o�͐�敪
                            sqlText += " , MOVESLIPOUTPUTDIVRF=@MOVESLIPOUTPUTDIV" + Environment.NewLine;
                            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�---------<<<<
                            sqlText += " , STOCKTOLERNCSHIPMDIVRF=@STOCKTOLERNCSHIPMDIV" + Environment.NewLine;
                            sqlText += " , INVNTRYPRTODRINIDIVRF=@INVNTRYPRTODRINIDIV" + Environment.NewLine;
                            sqlText += " , MAXSTKCNTOVERODERDIVRF=@MAXSTKCNTOVERODERDIV" + Environment.NewLine;
                            sqlText += " , SHELFNODUPLDIVRF=@SHELFNODUPLDIV" + Environment.NewLine;
                            sqlText += " , LOTUSEDIVCDRF=@LOTUSEDIVCD" + Environment.NewLine;
                            sqlText += " , SECTDSPDIVCDRF=@SECTDSPDIVCD" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmngttlstWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (stockmngttlstWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �V�K�쐬����SQL���𐶐�
                            string sqlText = string.Empty;
                            sqlText += "INSERT INTO STOCKMNGTTLSTRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "  ,STOCKMOVEFIXCODERF" + Environment.NewLine;
                            sqlText += "  ,STOCKPOINTWAYRF" + Environment.NewLine;
                            sqlText += "  ,FRACTIONPROCCDRF" + Environment.NewLine;
                            // --- ADD 2009/12/02 ---------->>>>>
                            // �I���^�p�敪
                            sqlText += "  ,INVENTORYMNGDIVRF" + Environment.NewLine;
                            // --- ADD 2009/12/02 ----------<<<<<
                            // -------------- ADD 2011/08/29 ---------------- >>>>>
                            // ���݌ɕ\���敪
                            sqlText += "  ,PRESTCKCNTDSPDIVRF" + Environment.NewLine;
                            // -------------- ADD 2011/08/29 ---------------- <<<<<
                            // -------------- ADD 2012/06/08 Redmine#30282 ---------------- >>>>>
                            // �I���f�[�^�폜�敪
                            sqlText += "  ,INVNTRYDTDELDIVRF" + Environment.NewLine;
                            // -------------- ADD 2012/06/08 Redmine#30282 ---------------- <<<<<
                            // --- ADD �O�� 2012/07/02 ---------->>>>>
                            // �ړ����݌Ɏ����o�^�敪
                            sqlText += "  ,MOVESTOCKAUTOINSDIVRF" + Environment.NewLine;
                            // --- ADD �O�� 2012/07/02 ----------<<<<<
                            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�--------->>>>
                            // �ړ��`�[�o�͐�敪
                            sqlText += "  ,MOVESLIPOUTPUTDIVRF" + Environment.NewLine;
                            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�---------<<<<
                            sqlText += "  ,STOCKTOLERNCSHIPMDIVRF" + Environment.NewLine;
                            sqlText += "  ,INVNTRYPRTODRINIDIVRF" + Environment.NewLine;
                            sqlText += "  ,MAXSTKCNTOVERODERDIVRF" + Environment.NewLine;
                            sqlText += "  ,SHELFNODUPLDIVRF" + Environment.NewLine;
                            sqlText += "  ,LOTUSEDIVCDRF" + Environment.NewLine;
                            sqlText += "  ,SECTDSPDIVCDRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "  ,@STOCKMOVEFIXCODE" + Environment.NewLine; ;
                            sqlText += "  ,@STOCKPOINTWAY" + Environment.NewLine;
                            sqlText += "  ,@FRACTIONPROCCD" + Environment.NewLine;
                            // --- ADD 2009/12/02 ---------->>>>>
                            // �I���^�p�敪
                            sqlText += "  ,@INVENTORYMNGDIV" + Environment.NewLine;
                            // --- ADD 2009/12/02 ----------<<<<<
                            // ------------------- ADD 2011/08/29 ---------->>>>>
                            // ���݌ɕ\���敪
                            sqlText += "  ,@PRESTCKCNTDSPDIV" + Environment.NewLine;
                            // ------------------- ADD 2011/08/29 ----------<<<<<
                            // ------------------- ADD 2012/06/08 Redmine#30282 ---------->>>>>
                            // �I���f�[�^�폜�敪
                            sqlText += "  ,@INVNTRYDTDELDIV" + Environment.NewLine;
                            // ------------------- ADD 2012/06/08 Redmine#30282 ----------<<<<<
                            // --- ADD �O�� 2012/07/02 ---------->>>>>
                            // �ړ����݌Ɏ����o�^�敪
                            sqlText += "  ,@MOVESTOCKAUTOINSDIV" + Environment.NewLine;
                            // --- ADD �O�� 2012/07/02 ----------<<<<<
                            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�--------->>>>
                            // �ړ��`�[�o�͐�敪
                            sqlText += "  ,@MOVESLIPOUTPUTDIV" + Environment.NewLine;
                            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�---------<<<<
                            sqlText += "  ,@STOCKTOLERNCSHIPMDIV" + Environment.NewLine;
                            sqlText += "  ,@INVNTRYPRTODRINIDIV" + Environment.NewLine;
                            sqlText += "  ,@MAXSTKCNTOVERODERDIV" + Environment.NewLine;
                            sqlText += "  ,@SHELFNODUPLDIV" + Environment.NewLine;
                            sqlText += "  ,@LOTUSEDIVCD" + Environment.NewLine;
                            sqlText += "  ,@SECTDSPDIVCD" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmngttlstWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraStockMoveFixCode = sqlCommand.Parameters.Add("@STOCKMOVEFIXCODE", SqlDbType.Int);
                        SqlParameter paraStockPointWay = sqlCommand.Parameters.Add("@STOCKPOINTWAY", SqlDbType.Int);
                        SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                        // --- ADD 2009/12/02 ---------->>>>>
                        // �I���^�p�敪
                        SqlParameter paraInventoryMngDiv = sqlCommand.Parameters.Add("@INVENTORYMNGDIV", SqlDbType.Int);
                        // --- ADD 2009/12/02 ----------<<<<<
                        // -------------------- ADD 2011/08/29 -------------------- >>>>>
                        // ���݌ɕ\���敪
                        SqlParameter paraPreStckCntDspDiv = sqlCommand.Parameters.Add("@PRESTCKCNTDSPDIV", SqlDbType.Int);
                        // -------------------- ADD 2011/08/29 -------------------- <<<<<
                        // -------------------- ADD 2012/06/08 Redmine#30282 -------------------- >>>>>
                        // �I���f�[�^�폜�敪
                        SqlParameter paraInvntryDtDelDiv = sqlCommand.Parameters.Add("@INVNTRYDTDELDIV", SqlDbType.Int);
                        // -------------------- ADD 2012/06/08 Redmine#30282 -------------------- <<<<<
                        // --- ADD �O�� 2012/07/02 ---------->>>>>
                        // �ړ����݌Ɏ����o�^�敪
                        SqlParameter paraMoveStockAutoInsDiv = sqlCommand.Parameters.Add("@MOVESTOCKAUTOINSDIV",SqlDbType.Int);
                        // --- ADD �O�� 2012/07/02 ----------<<<<<
                        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�--------->>>>
                        // �ړ��`�[�o�͐�敪
                        SqlParameter paraMoveSlipOutPutDiv = sqlCommand.Parameters.Add("@MOVESLIPOUTPUTDIV", SqlDbType.Int);
                        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�---------<<<<
                        SqlParameter paraStockTolerncShipmDiv = sqlCommand.Parameters.Add("@STOCKTOLERNCSHIPMDIV", SqlDbType.Int);
                        SqlParameter paraInvntryPrtOdrIniDiv = sqlCommand.Parameters.Add("@INVNTRYPRTODRINIDIV", SqlDbType.Int);
                        SqlParameter paraMaxStkCntOverOderDiv = sqlCommand.Parameters.Add("@MAXSTKCNTOVERODERDIV", SqlDbType.Int);
                        SqlParameter paraShelfNoDuplDiv = sqlCommand.Parameters.Add("@SHELFNODUPLDIV", SqlDbType.Int);
                        SqlParameter paraLotUseDivCd = sqlCommand.Parameters.Add("@LOTUSEDIVCD", SqlDbType.Int);
                        SqlParameter paraSectDspDivCd = sqlCommand.Parameters.Add("@SECTDSPDIVCD", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmngttlstWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmngttlstWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockmngttlstWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);
                        paraStockMoveFixCode.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.StockMoveFixCode);
                        paraStockPointWay.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.StockPointWay);
                        paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.FractionProcCd);
                        // --- ADD 2009/12/02 ---------->>>>>
                        // �I���^�p�敪
                        paraInventoryMngDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.InventoryMngDiv);
                        // --- ADD 2009/12/02 ----------<<<<<
                        // ------------------- ADD 2011/08/29 --------------------- >>>>>
                        // ���݌ɕ\���敪
                        paraPreStckCntDspDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.PreStckCntDspDiv);
                        // ------------------- ADD 2011/08/29 --------------------- <<<<<
                        // ------------------- ADD 2012/06/08 Redmine#30282 --------------------- >>>>>
                        // �I���f�[�^�폜�敪
                        paraInvntryDtDelDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.InvntryDtDelDiv);
                        // ------------------- ADD 2012/06/08 Redmine#30282 --------------------- <<<<<
                        // --- ADD �O�� 2012/07/02 ---------->>>>>
                        // �ړ����݌Ɏ����o�^�敪
                        paraMoveStockAutoInsDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.MoveStockAutoInsDiv);
                        // --- ADD �O�� 2012/07/02 ----------<<<<<
                        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�--------->>>>
                        // �ړ��`�[�o�͐�敪
                        paraMoveSlipOutPutDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.MoveSlipOutPutDiv);
                        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�---------<<<<
                        paraStockTolerncShipmDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.StockTolerncShipmDiv);
                        paraInvntryPrtOdrIniDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.InvntryPrtOdrIniDiv);
                        paraMaxStkCntOverOderDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.MaxStkCntOverOderDiv);
                        paraShelfNoDuplDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.ShelfNoDuplDiv);
                        paraLotUseDivCd.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.LotUseDivCd);
                        paraSectDspDivCd.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.SectDspDivCd);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockmngttlstWork);
                    }
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
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockmngttlstWorkList = al;

            return status;
        }

        // DEL yangyi 2012/06/13 Redmine#30437 ------------->>>>>
        /// <summary>
        /// �S�Ћ��ʍ��ڂ��X�V����
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        /// <br>Update Note: 2009/12/02 ��r�� �I���^�p�敪�̒ǉ�</br>
        //private int UpdateAllSecStockMngTtlSt(ref ArrayList stockmngttlstWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    SqlCommand sqlCommand = null;
        //    ArrayList al = new ArrayList();
        //    try
        //    {
        //        if (stockmngttlstWorkList != null)
        //        {
        //            StockMngTtlStWork stockmngttlstWork = stockmngttlstWorkList[0] as StockMngTtlStWork;

        //            sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
        //            # region �X�V����SQL������
        //            string sqlText = string.Empty;
        //            sqlText += "UPDATE STOCKMNGTTLSTRF SET " + Environment.NewLine;
        //            sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
        //            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
        //            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
        //            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
        //            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
        //            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
        //            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
        //            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
        //            sqlText += " , STOCKMOVEFIXCODERF=@STOCKMOVEFIXCODE" + Environment.NewLine;
        //            sqlText += " , STOCKPOINTWAYRF=@STOCKPOINTWAY" + Environment.NewLine;
        //            sqlText += " , FRACTIONPROCCDRF=@FRACTIONPROCCD" + Environment.NewLine;
        //            // --- ADD 2009/12/02 ---------->>>>>
        //            // �I���^�p�敪
        //            sqlText += " , INVENTORYMNGDIVRF=@INVENTORYMNGDIV" + Environment.NewLine;
        //            // --- ADD 2009/12/02 ----------<<<<<
        //            // ------------- ADD 2011/08/29 ---------------- >>>>>
        //            // ���݌ɕ\���敪
        //            sqlText += " , PRESTCKCNTDSPDIVRF=@PRESTCKCNTDSPDIV" + Environment.NewLine;
        //            // ------------- ADD 2011/08/29 ---------------- <<<<<
        //            // ------------- ADD 2012/06/07 ---------------- >>>>>
        //            // �I���f�[�^�폜�敪
        //            sqlText += " , INVNTRYDTDELDIVRF=@INVNTRYDTDELDIV" + Environment.NewLine;
        //            // ------------- ADD 2012/06/07 ---------------- <<<<<
        //            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;//DEL 2012/06/07
        //            sqlText += "  AND SECTIONCODERF<>'00'" + Environment.NewLine;
        //            sqlCommand.CommandText = sqlText;

        //            //�X�V�w�b�_����ݒ�
        //            object obj = (object)this;
        //            IFileHeader flhd = (IFileHeader)stockmngttlstWork;
        //            FileHeader fileHeader = new FileHeader(obj);
        //            fileHeader.SetUpdateHeader(ref flhd, obj);
        //            #endregion

        //            #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
        //            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
        //            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
        //            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
        //            //SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);// DEL 2012/06/07
        //            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
        //            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
        //            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
        //            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
        //            SqlParameter paraStockMoveFixCode = sqlCommand.Parameters.Add("@STOCKMOVEFIXCODE", SqlDbType.Int);
        //            SqlParameter paraStockPointWay = sqlCommand.Parameters.Add("@STOCKPOINTWAY", SqlDbType.Int);
        //            SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
        //            // --- ADD 2009/12/02 ---------->>>>>
        //            // �I���^�p�敪
        //            SqlParameter paraInventoryMngDiv = sqlCommand.Parameters.Add("@INVENTORYMNGDIV", SqlDbType.Int);
        //            // --- ADD 2009/12/02 ----------<<<<<
        //            // -------------------- ADD 2011/08/29 -------------------- >>>>>
        //            // ���݌ɕ\���敪
        //            SqlParameter paraPreStckCntDspDiv = sqlCommand.Parameters.Add("@PRESTCKCNTDSPDIV", SqlDbType.Int);
        //            // -------------------- ADD 2011/08/29 -------------------- <<<<<
        //            // -------------------- ADD 2012/06/07 -------------------- >>>>>
        //            // �I���f�[�^�폜�敪
        //            SqlParameter paraInvntryDtDelDiv = sqlCommand.Parameters.Add("@INVNTRYDTDELDIV", SqlDbType.Int);
        //            // -------------------- ADD 2012/06/07 -------------------- <<<<<
        //            #endregion

        //            #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
        //            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmngttlstWork.CreateDateTime);
        //            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmngttlstWork.UpdateDateTime);
        //            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
        //            //paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockmngttlstWork.FileHeaderGuid);// DEL 2012/06/07
        //            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdEmployeeCode);
        //            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdAssemblyId1);
        //            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdAssemblyId2);
        //            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.LogicalDeleteCode);
        //            paraStockMoveFixCode.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.StockMoveFixCode);
        //            paraStockPointWay.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.StockPointWay);
        //            paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.FractionProcCd);
        //            // --- ADD 2009/12/02 ---------->>>>>
        //            // �I���^�p�敪
        //            paraInventoryMngDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.InventoryMngDiv);
        //            // --- ADD 2009/12/02 ----------<<<<<
        //            // ------------------- ADD 2011/08/29 --------------------- >>>>>
        //            // ���݌ɕ\���敪
        //            paraPreStckCntDspDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.PreStckCntDspDiv);
        //            // ------------------- ADD 2011/08/29 --------------------- <<<<<
        //            // ------------------- ADD 2012/06/07 --------------------- >>>>>
        //            // �I���f�[�^�폜�敪
        //            paraInvntryDtDelDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.InvntryDtDelDiv);
        //            // ------------------- ADD 2012/06/07 --------------------- <<<<<
        //            #endregion

        //            sqlCommand.ExecuteNonQuery();

        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    finally
        //    {
        //        if (sqlCommand != null)
        //        {
        //            sqlCommand.Cancel();
        //            sqlCommand.Dispose();
        //        }
        //    }

        //    return status;
        //}
        // DEL yangyi 2012/06/13 Redmine#30437 -------------<<<<<
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int LogicalDelete(ref object stockmngttlstWork)
        {
            return LogicalDeleteStockMngTtlSt(ref stockmngttlstWork, 0);
        }

        /// <summary>
        /// �_���폜�݌ɊǗ��S�̐ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�݌ɊǗ��S�̐ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int RevivalLogicalDelete(ref object stockmngttlstWork)
        {
            return LogicalDeleteStockMngTtlSt(ref stockmngttlstWork, 1);
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        private int LogicalDeleteStockMngTtlSt(ref object stockmngttlstWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(stockmngttlstWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteStockMngTtlStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "StockMngTtlStDB.LogicalDeleteStockMngTtlSt :" + procModestr);

                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int LogicalDeleteStockMngTtlStProc(ref ArrayList stockmngttlstWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteStockMngTtlStProcProc(ref stockmngttlstWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        private int LogicalDeleteStockMngTtlStProcProc(ref ArrayList stockmngttlstWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (stockmngttlstWorkList != null)
                {
                    for (int i = 0; i < stockmngttlstWorkList.Count; i++)
                    {
                        StockMngTtlStWork stockmngttlstWork = stockmngttlstWorkList[i] as StockMngTtlStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM STOCKMNGTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != stockmngttlstWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE STOCKMNGTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmngttlstWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //�_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) stockmngttlstWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else stockmngttlstWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) stockmngttlstWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmngttlstWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockmngttlstWork);
                    }

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
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockmngttlstWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�݌ɊǗ��S�̐ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteStockMngTtlStProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMngTtlStDB.Delete");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">�݌ɊǗ��S�̐ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int DeleteStockMngTtlStProc(ArrayList stockmngttlstWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteStockMngTtlStProcProc(stockmngttlstWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">�݌ɊǗ��S�̐ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        private int DeleteStockMngTtlStProcProc(ArrayList stockmngttlstWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < stockmngttlstWorkList.Count; i++)
                {
                    StockMngTtlStWork stockmngttlstWork = stockmngttlstWorkList[i] as StockMngTtlStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM STOCKMNGTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != stockmngttlstWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM STOCKMNGTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

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
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
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

	    #region [Where���쐬����]
	    /// <summary>
	    /// �������������񐶐��{�����l�ݒ�
	    /// </summary>
	    /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
	    /// <param name="stockmngttlstWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockMngTtlStWork stockmngttlstWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
		    retstring += "STK.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);

            //���_�R�[�h
            if (string.IsNullOrEmpty(stockmngttlstWork.SectionCode) == false)
            {
                retstring += "AND STK.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);
            }
            
            //�_���폜�敪
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
			    wkstring = "AND STK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND STK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

		    return retstring;
		}
	    #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� StockMngTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockMngTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             #Redmine30282 �u�I���f�[�^�폜�敪�v���ɒǉ��@</br>
        /// <br>Update Note: 2012/07/02 �O�ˁ@�L��</br>
        /// <br>             �u�ړ����݌Ɏ����o�^�敪�v����ʂɒǉ��@</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854��ʂɗ�u�ړ��`�[�o�͐�敪�v�ǉ�</br>
        /// </remarks>
        private StockMngTtlStWork CopyToStockMngTtlStWorkFromReader(ref SqlDataReader myReader)
        {
            StockMngTtlStWork wkStockMngTtlStWork = new StockMngTtlStWork();

            #region �N���X�֊i�[
            wkStockMngTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockMngTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockMngTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockMngTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockMngTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockMngTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockMngTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockMngTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockMngTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockMngTtlStWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkStockMngTtlStWork.StockMoveFixCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFIXCODE"));
            wkStockMngTtlStWork.StockPointWay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKPOINTWAYRF"));
            wkStockMngTtlStWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            // --- ADD 2009/12/02 ---------->>>>>
            // �I���^�p�敪
            wkStockMngTtlStWork.InventoryMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYMNGDIVRF"));
            // --- ADD 2009/12/02 ----------<<<<<
            // ---------------------- ADD 2011/08/29 ----------------------- >>>>>
            // ���݌ɕ\���敪
            wkStockMngTtlStWork.PreStckCntDspDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRESTCKCNTDSPDIVRF"));
            // ---------------------- ADD 2011/08/29 ----------------------- <<<<<
            // ---------------------- ADD 2012/06/08 Redmine#30282 ----------------------- >>>>>
            // �I���f�[�^�폜�敪
            wkStockMngTtlStWork.InvntryDtDelDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVNTRYDTDELDIVRF"));
            // ---------------------- ADD 2012/06/08 Redmine#30282 ----------------------- <<<<<
            // --- ADD �O�� 2012/07/02 ---------->>>>>
            // �ړ����݌Ɏ����o�^�敪
            wkStockMngTtlStWork.MoveStockAutoInsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTOCKAUTOINSDIVRF"));
            // --- ADD �O�� 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�--------->>>>
            // �ړ��`�[�o�͐�敪
            wkStockMngTtlStWork.MoveSlipOutPutDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESLIPOUTPUTDIVRF"));
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�---------<<<<
            wkStockMngTtlStWork.StockTolerncShipmDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKTOLERNCSHIPMDIVRF"));
            wkStockMngTtlStWork.InvntryPrtOdrIniDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVNTRYPRTODRINIDIVRF"));
            wkStockMngTtlStWork.MaxStkCntOverOderDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAXSTKCNTOVERODERDIVRF"));
            wkStockMngTtlStWork.ShelfNoDuplDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHELFNODUPLDIVRF"));
            wkStockMngTtlStWork.LotUseDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOTUSEDIVCDRF"));
            wkStockMngTtlStWork.SectDspDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECTDSPDIVCDRF"));
            #endregion

            return wkStockMngTtlStWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            StockMngTtlStWork[] StockMngTtlStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is StockMngTtlStWork)
                    {
                        StockMngTtlStWork wkStockMngTtlStWork = paraobj as StockMngTtlStWork;
                        if (wkStockMngTtlStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkStockMngTtlStWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            StockMngTtlStWorkArray = (StockMngTtlStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockMngTtlStWork[]));
                        }
                        catch (Exception) { }
                        if (StockMngTtlStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(StockMngTtlStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                StockMngTtlStWork wkStockMngTtlStWork = (StockMngTtlStWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockMngTtlStWork));
                                if (wkStockMngTtlStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockMngTtlStWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //���ɉ������Ȃ�
                }

            return retal;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
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
