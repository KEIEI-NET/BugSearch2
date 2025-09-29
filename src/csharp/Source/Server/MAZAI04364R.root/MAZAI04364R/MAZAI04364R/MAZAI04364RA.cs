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
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌ɒ����f�[�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɒ����f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.02.14</br>
    /// <br></br>
    /// <br>Update Note: 2008.1.11 ���� DC.NS�p�ɏC��</br>
    /// <br>Update Note: 2008.08.05 ���� PM.NS�p�ɏC��</br>
    /// <br>Update Note: 2009.04.09 ���� �󕥗����̋��_�R�[�h�Z�b�g���e�ύX</br>
    /// <br>Update Note: 2009.05.25 ���� �I���f�[�^�X�V���\�b�h�̕����`�[�Ή�</br>
    /// <br>Update Note: 2009.06.15 ���� �ߕs���X�V�ŒI�Ԃ��X�V����Ȃ��s��̏C��</br>
    /// <br>Update Note: 2009/07/30 ���� �݌ɒ����f�[�^�o�^���̒S���Җ��̐؂�̂ď����C��</br>
    /// <br>Update Note: 2010/12/20 ������ ��Q���ǑΉ�����</br>
    /// <br>             �݌Ɏd���f�[�^�o�^���A�݌Ƀ}�X�^�̍ŏI�d�������X�V����Ȃ��s����C��</br>
    /// <br>Update Note: 2011/08/11 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j</br>
    /// <br>             �݌ɒ����f�[�^��M���ɍ݌Ƀ}�X�^�̍X�V���s��</br>
    /// <br>Update Note: 2011/09/02 ������ #24259</br>
    /// <br>             �@�u�l���Z�b�g����Ă��Ȃ��v�C��</br>
    /// <br>             �A�u�݌Ɏ󕥃f�[�^���쐬����Ȃ��B�v�C��</br>
    /// <br>Update Note: 2011/09/06 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j</br>
    /// <br>             #24355��M���̍X�V����</br>
    /// <br>Update Note: 2011/09/16 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j</br>
    /// <br>             #25139 ���_�Ǘ��@�݌Ɏd���f�[�^��M�����@�I�������f�[�^�ɂ���</br>
    /// <br>Update Note: 2013/10/09 yangyi</br>
    /// <br>             redmine#31106 �u�I���ߕs���X�V�v�̕��׌y���Ə������ԒZ�k�̒���</br>
    /// <br>Update Note: K2015/08/21 ��</br>
    /// <br>             redmine#46790  �I���ߕs���X�V�@�������A�E�g�̏C��</br>
    /// <br>Update Note: K2015/09/09 ��</br>
    /// <br>             redmine#46790  �݌ɒ������׃f�[�^�̒艿�Z�b�g�s���̑Ή�</br>
    /// <br>Update Note: �n���f�B�^�[�~�i���݌Ɏd���iUOE�ȊO�j�̓o�^�����ōŏI�d�����̕⑫</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2017/08/11</br>
    /// </remarks>
    [Serializable]
    public class StockAdjustDB : RemoteWithAppLockDB, IStockAdjustDB
    {
        private StockDB _stockDB = new StockDB();
        private InventoryExcDefUpdateDB _inventoryExcDefUpdateDB = new InventoryExcDefUpdateDB();
        private GoodsPriceUDB _goodsPriceUDB = new GoodsPriceUDB();
        // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� ----->>>>>
        private InventInputSearchDB _inventInputSearchDB = null; // �I�������[�g
        private TtlDayCalcDB _ttlDayCalcDB; // �����Z�o�����[�g
        // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� -----<<<<<
        //ADD 2011/09/02 ������ #24259 ------------------->>>>>
        private SecInfoSetDB _secInfoDB = new SecInfoSetDB();
        private Hashtable secInfoSetWorkHash = new Hashtable();    
        private bool _isRecv = false;
        //ADD 2011/09/02 ������ #24259 -------------------<<<<<
        private string _secCode = string.Empty;//ADD 2011/09/16 sundx #25139
        private enum ct_ProcMode
        {
            /// <summary>����</summary>
            Adjust = 0,
            /// <summary>�ꊇ�o�^</summary>
            BatchInpt = 1,
            /// <summary>�I��</summary>
            Inventory = 2
        }

        private enum ct_WriteMode
        {
            /// <summary>�ǉ��X�V</summary>
            Write = 0,
            /// <summary>�폜</summary>
            Delete = 1
        }

        // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� ----->>>>>
        /// <summary>
        /// �I��IInventInputSearchDB�v���p�e�B
        /// </summary>
        private InventInputSearchDB inventInputSearchDB
        {
            get
            {
                if (this._inventInputSearchDB == null)
                {
                    // �I�������[�g �𐶐�
                    this._inventInputSearchDB = new InventInputSearchDB();
                }

                return this._inventInputSearchDB;
            }
        }

        /// <summary>
        /// �����Z�oITtlDayCalcDB�v���p�e�B
        /// </summary>
        private TtlDayCalcDB ttlDayCalcDB
        {
            get
            {
                if (this._ttlDayCalcDB == null)
                {
                    // �����Z�o�����[�g �𐶐�
                    this._ttlDayCalcDB = new TtlDayCalcDB();
                }

                return this._ttlDayCalcDB;
            }
        }
        // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� -----<<<<<

        /// <summary>
        /// �݌ɒ����f�[�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        /// </remarks>
        public StockAdjustDB()
            :
            base("MAZAI04366D", "Broadleaf.Application.Remoting.ParamData.StockAdjustWork", "STOCKADJUSTRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɒ����f�[�^���LIST��߂��܂�
        /// </summary>
        /// <param name="stockAdjustWork">��������</param>
        /// <param name="parastockAdjustWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɒ����f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int Search(out object stockAdjustWork, object parastockAdjustWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockAdjustWork = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockAdjustProc(out stockAdjustWork, parastockAdjustWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAdjustDB.Search");
                stockAdjustWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̍݌ɒ����f�[�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objstockAdjustWork">��������</param>
        /// <param name="parastockAdjustWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɒ����f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int SearchStockAdjustProc(out object objstockAdjustWork, object parastockAdjustWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            StockAdjustWork stockadjustWork = null;

            ArrayList stockadjustWorkList = parastockAdjustWork as ArrayList;
            if (stockadjustWorkList == null)
            {
                stockadjustWork = parastockAdjustWork as StockAdjustWork;
            }
            else
            {
                if (stockadjustWorkList.Count > 0)
                    stockadjustWork = stockadjustWorkList[0] as StockAdjustWork;
            }

            int status = SearchStockAdjustProc(out stockadjustWorkList, stockadjustWork, readMode, logicalMode, ref sqlConnection);
            objstockAdjustWork = stockadjustWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɒ����f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockadjustWorkList">��������</param>
        /// <param name="stockadjustWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɒ����f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int SearchStockAdjustProc(out ArrayList stockadjustWorkList, StockAdjustWork stockadjustWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchStockAdjustProcProc(out stockadjustWorkList, stockadjustWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɒ����f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockadjustWorkList">��������</param>
        /// <param name="stockadjustWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɒ����f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        private int SearchStockAdjustProcProc(out ArrayList stockadjustWorkList, StockAdjustWork stockadjustWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM STOCKADJUSTRF  ", sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockadjustWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockAdjustWorkFromReader(ref myReader));

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

            stockadjustWorkList = al;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɒ����f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="bfstockadjustDtlWorkList">��������</param>
        /// <param name="stockadjustWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɒ����f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        private int SearchStockAdjustDtlProc(out ArrayList bfstockadjustDtlWorkList, StockAdjustWork stockadjustWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            bfstockadjustDtlWorkList = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlTxt = string.Empty;

            ArrayList al = new ArrayList();
            try
            {
                sqlTxt += "SELECT * FROM STOCKADJUSTDTLRF" + Environment.NewLine;
                sqlTxt += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += " AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO" + Environment.NewLine;


                if (sqlTransaction != null)
                {
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                }
                else
                {
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                }

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAdjustDtlWork work = CopyToStockAdjustDtlWorkFromReader(ref myReader);
                    bfstockadjustDtlWorkList.Add(work);
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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɒ����f�[�^���LIST��߂��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="stockAdjustSlipNo">�`�[�ԍ�</param>
        /// <param name="stockAdjustWork">�݌ɒ����f�[�^</param>
        /// <param name="stockAdjustDtlWork">�݌ɒ������׃f�[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɒ����f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.09.02</br>
        public int SearchSlipAndDtl(string enterpriseCode, int stockAdjustSlipNo, ref ArrayList stockAdjustWork , ref ArrayList stockAdjustDtlWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            StockAdjustWork parastockAdjustWork = new StockAdjustWork();
            parastockAdjustWork.EnterpriseCode = enterpriseCode;
            parastockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
            SqlTransaction sqlTransaction = null; //���g�p

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�݌ɒ����f�[�^
                status = SearchStockAdjustProcProc(out stockAdjustWork, parastockAdjustWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�݌ɒ������׃f�[�^
                    status = SearchStockAdjustDtlProc(out stockAdjustDtlWork, parastockAdjustWork, ref sqlConnection, ref sqlTransaction);

                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAdjustDB.Search");
                stockAdjustWork = new ArrayList();
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

            return status;
        }

        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɒ����f�[�^��߂��܂�
        /// </summary>
        /// <param name="paraobj">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɒ����f�[�^��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int Read(ref object paraobj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                StockAdjustWork stockadjustWork = paraobj as StockAdjustWork;
                if (stockadjustWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref stockadjustWork, readMode, ref sqlConnection);

                paraobj = stockadjustWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAdjustDB.Read");
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
        /// �w�肳�ꂽ�����̍݌ɒ����f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockadjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɒ����f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int ReadProc(ref StockAdjustWork stockadjustWork, int readMode, ref SqlConnection sqlConnection)
        {
            return ReadProcProc(ref stockadjustWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɒ����f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockadjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɒ����f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        private int ReadProcProc(ref StockAdjustWork stockadjustWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO", sqlConnection))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                    findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        stockadjustWork = CopyToStockAdjustWorkFromReader(ref myReader);
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
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂��B(�݌Ɏd�����͗p)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int Write(ref object stockAdjustWork, out string retMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            
            retMsg = string.Empty;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = this.Write(ref stockAdjustWork, out retMsg, ref sqlConnection,ref sqlTransaction);

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
                base.WriteErrorLog(ex, "StockAdjustDB.Write(ref object stockAdjustWork)");
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
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂��B(�݌Ɏd�����͗p:UOE�ȊO)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int Write(ref object stockAdjustWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteProc(ref stockAdjustWork, out retMsg, ref sqlConnection, ref sqlTransaction, 0);
        }

        /// <summary>
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂��B(�݌Ɏd�����͗p:UOE)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂� (UOE���̓V�F�A�`�F�b�N���)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int WriteNoLock(ref object stockAdjustWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteProc(ref stockAdjustWork, out retMsg, ref sqlConnection, ref sqlTransaction, 1);
        }

        /// <summary>
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂��B(�݌Ɏd�����͗p)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <param name="LockMode">�V�F�A�`�F�b�N����(0:����,1:�Ȃ�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        //public int Write(ref object stockAdjustWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int WriteProc(ref object stockAdjustWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int LockMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlEncryptInfo sqlEncryptInfo = null;
            int stockAdjustSlipNo = 0;
            retMsg = "";
            string retItemInfo = "";
            

            ArrayList stockAdjustWorkList = null;       //�݌ɒ����f�[�^���X�g
            ArrayList stockAdjustDtlWorkList = null;    //�݌ɒ������׃f�[�^���X�g
            ArrayList bfstockAdjustDtlWorkList = null;  //�݌ɒ������׃f�[�^���X�g(�O��l)
            ArrayList stockAcPayHistWorkList = null;    //�݌Ɏ󕥗������X�g
            ArrayList goodsPriceUList = null;            //���i�X�V���X�g
            ArrayList stockWorkList = new ArrayList();             //�݌Ƀ��X�g

            ArrayList infoList = new ArrayList(); //�V�F�A�`�F�b�N��񃊃X�g
            Dictionary<string, string> dic = new Dictionary<string, string>(); //�q�Ƀ��X�g 

            bool uoeflg = false;

            string resNm = "";

            try
            {
                //�p�����[�^�̃L���X�g
                CustomSerializeArrayList paraList = stockAdjustWork as CustomSerializeArrayList;
                if (paraList == null) return status;

                //���X�g����K�v�ȏ����擾
                for (int i = 0; i < paraList.Count; i++)
                {
                    ArrayList wkal = paraList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //�݌ɒ����f�[�^�̏ꍇ
                            if (wkal[0] is StockAdjustWork)
                            {
                                stockAdjustWorkList = wkal;
                            }
                            //�݌ɒ������׃f�[�^�̏ꍇ
                            else if (wkal[0] is StockAdjustDtlWork)
                            {
                                stockAdjustDtlWorkList = wkal;
                            }
                            //���i���X�g�̏ꍇ
                            else if (wkal[0] is GoodsPriceUWork)
                            {
                                goodsPriceUList = wkal;
                            }
                        }
                    }
                }

                if (LockMode != 1)
                {
                    // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                    if (stockAdjustDtlWorkList != null && stockAdjustDtlWorkList.Count > 0)
                    {
                        StockAdjustDtlWork _stockAdjustDtlWork = stockAdjustDtlWorkList[0] as StockAdjustDtlWork;
                        foreach (StockAdjustDtlWork st in stockAdjustDtlWorkList)
                        {
                            if (dic.ContainsKey(st.WarehouseCode.Trim()) == false)
                            {
                                dic.Add(st.WarehouseCode.Trim(), st.WarehouseCode.Trim());
                            }
                        }
                        foreach (string wCode in dic.Keys)
                        {
                            ShareCheckInfo info = new ShareCheckInfo();
                            info.Keys.Add(_stockAdjustDtlWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                            status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                            infoList.Add(info);
                            if (status != 0) return status;
                        }
                    }
                    // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }

                StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;

                //�݌Ɏd���ł`�o���b�N
                resNm = GetResourceName(wkStockAdjustWork.EnterpriseCode);

                //�`�o���b�N
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                    }

                    return status;
                }

                //---�݌ɒ����`�[�ԍ��̔�---
                if (wkStockAdjustWork.StockAdjustSlipNo == 0)
                {
                    status = CreateStockAdjustSlipNo(wkStockAdjustWork.EnterpriseCode, wkStockAdjustWork.SectionCode, out stockAdjustSlipNo, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                    wkStockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
                }
                else
                {
                    stockAdjustSlipNo = wkStockAdjustWork.StockAdjustSlipNo;
                    //�O��l�擾
                    status = SearchStockAdjustDtlProc(out bfstockAdjustDtlWorkList, wkStockAdjustWork, ref sqlConnection, ref sqlTransaction);
                }

                //�����v��̃`�F�b�N True:�����v��
                uoeflg = CheckSendAddUp(stockAdjustDtlWorkList);

                //�����f�[�^�X�V
                if (uoeflg && stockAdjustDtlWorkList != null)
                {
                    StockSlipDB stockSlipDB = new StockSlipDB();
                    ArrayList parastockDetailList = CopyToParaStockDetailFromStockAdjustDtl(stockAdjustDtlWorkList, bfstockAdjustDtlWorkList, (int)ct_WriteMode.Write);

                    //�d�������[�g�̔����v�チ�\�b�h�̌Ăяo��
                    status = stockSlipDB.UpdateOrderRemainCnt(new StockSlipWork(), parastockDetailList, 0, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                }

                //write���s
                //�݌ɒ����f�[�^�X�V
                if (stockAdjustWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteStockAdjustProc(ref stockAdjustWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�݌ɒ����f�[�^�̍X�V�Ɏ��s���܂����B";
                }

                //�݌ɒ������׃f�[�^�X�V
                if (stockAdjustDtlWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteDelInsStockAdjustDtlProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�݌ɒ������׃f�[�^�̍X�V�Ɏ��s���܂����B";
                }

                //�݌Ɍn�f�[�^�쐬���� (�݌Ɏ󕥗����f�[�^�쐬)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = TransStockData(true, (int)ct_WriteMode.Write, bfstockAdjustDtlWorkList, ref stockAdjustWorkList, ref stockAdjustDtlWorkList, out stockAcPayHistWorkList, ref stockWorkList, (int)ct_ProcMode.Adjust, ref sqlConnection, ref sqlTransaction);
                }

                //�݌Ƀf�[�^�X�V
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    string origin = "";
                    CustomSerializeArrayList originList = null;
                    CustomSerializeArrayList tempparaList = new CustomSerializeArrayList();
                    tempparaList.Add(stockWorkList);
                    tempparaList.Add(stockAcPayHistWorkList);
                    int position = 0;
                    string param = "";
                    object freeParam = null;
                    int shelfNoUpdateDiv = 1;  //1:�I�ԍX�V���Ȃ��i�I�ԍX�V�͒I���p�j

                    status = _stockDB.WriteForStockAdjust(origin, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);
                }

                //���i���i�X�V
                if (goodsPriceUList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = _goodsPriceUDB.UpDatePrice(ref goodsPriceUList, ref sqlConnection, ref sqlTransaction);
                }


                //�߂�l�Z�b�g
                stockAdjustWork = paraList;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockAdjustDB.Write(ref object stockAdjustWork)");
            }
            finally
            {
                //�`�o�A�����b�N
                Release(resNm, sqlConnection, sqlTransaction);

                if (LockMode != 1)
                {
                    // �V�X�e�����b�N����(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    if (status == 0 || status == 9)
                    {
                        foreach (ShareCheckInfo info in infoList)
                        {
                            status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        }
                    }
                    // �V�X�e�����b�N����(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }

            return status;
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^���A�����v��̃f�[�^���𔻒f���܂��B
        /// </summary>
        /// <param name="stockAdjustDtlList">stockAdjustDtlList�I�u�W�F�N�g</param>
        /// <returns>true:�����v��,false:�����v��ȊO</returns>
        /// <br>Note       : �����v��f�[�^���̃`�F�b�N���s���܂�</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        private bool CheckSendAddUp(ArrayList stockAdjustDtlList)
        {
            foreach(StockAdjustDtlWork work in stockAdjustDtlList)
            {
                //�d�����גʔԁi���j�������Ă�f�[�^���P���ł����݂����ꍇ�͔����v�゠��
                if (work.StockSlipDtlNumSrc != 0) return true;
            }

            return false;
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^����d�����׃f�[�^���X�g�Ɏd�����גʔԂ��Z�b�g���܂��B
        /// </summary>
        /// <param name="stockAdjustDtlList">stockAdjustDtlList�I�u�W�F�N�g</param>
        /// <param name="bfstockAdjustDtlList">�O��l���׃��X�g</param>
        /// <param name="writeMode">�X�V���[�h</param>
        /// <returns>true:�����v��,false:�����v��ȊO</returns>
        /// <br>Note       : �����v��f�[�^���̃`�F�b�N���s���܂�</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        private ArrayList CopyToParaStockDetailFromStockAdjustDtl(ArrayList stockAdjustDtlList, ArrayList bfstockAdjustDtlList, int writeMode)
        {
            ArrayList al = new ArrayList();

            for (int i = 0; i < stockAdjustDtlList.Count; i++)
            {
                StockAdjustDtlWork work = stockAdjustDtlList[i] as StockAdjustDtlWork;

                Double adjustCount = work.AdjustCount;

                if (bfstockAdjustDtlList != null)
                {
                    StockAdjustDtlWork bfwork = bfstockAdjustDtlList[i] as StockAdjustDtlWork;

                    adjustCount -= bfwork.AdjustCount;
                }

                StockDetailWork stockDetailWork = new StockDetailWork();

                if (work.StockSlipDtlNumSrc != 0)
                {
                    //�d���f�[�^�����[�g�̔����v�㏈���ɍ��킹�ĉ��z�I�Ɏd���f�[�^���쐬����
                    stockDetailWork.EnterpriseCode = work.EnterpriseCode;
                    stockDetailWork.SupplierFormalSrc = work.SupplierFormalSrc;
                    stockDetailWork.StockSlipDtlNumSrc = work.StockSlipDtlNumSrc;
                    if (writeMode == (int)ct_WriteMode.Write)
                    {
                        stockDetailWork.StockCountDifference = adjustCount;
                    }
                    else
                    {
                        stockDetailWork.StockCountDifference = adjustCount * -1;
                    }
                }

                al.Add(stockDetailWork);
            }

            return al;
        }

        /// <summary>
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂�(�݌Ɉꊇ�o�^�A���i�݌Ƀ}�X�����p)
        /// </summary>
        /// <param name="stockAdjustCustList">stockAdjustCustList�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        /// <br>Update Note: 2008.9.12 ���� ������stockMode��ǉ�</br>
        public int WriteBatch(ref object stockAdjustCustList, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = "";

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = WriteBatch(ref stockAdjustCustList, out retMsg, ref sqlConnection, ref sqlTransaction);

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
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockAdjustDB.WriteBatch(ref object stockAdjustCustList, out string retMsg, int stockMode)");
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
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂�(�݌Ɉꊇ�o�^�A���i�݌Ƀ}�X�����A�݌ɕ����A�g���p)
        /// </summary>
        /// <param name="stockAdjustCustList">stockAdjustCustList�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        /// <br>Update Note: 2008.9.12 ���� PM.NS�p�ɏC��</br>
        public int WriteBatch(ref object stockAdjustCustList, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int stockAdjustSlipNo = 0;
            retMsg = "";
            string retItemInfo = "";

            ArrayList stockAdjustWorkList = null;       //�݌ɒ����f�[�^���X�g
            ArrayList stockAdjustDtlWorkList = null;    //�݌ɒ������׃f�[�^���X�g
            ArrayList stockWorkList = null;             //�݌Ƀ��X�g
            ArrayList stockWriteList = null;            //�X�V�p�݌Ƀ��X�g
            ArrayList stockDeleteList = null;           //�폜�p�݌Ƀ��X�g
            ArrayList stockAcPayHistWorkList = null;    //�݌Ɏ󕥗������X�g

            string resNm = "";
            string enterpriseCode = ""; // 2009/08/03

            //�p�����[�^�̃L���X�g
            CustomSerializeArrayList stockAdjustCsList = stockAdjustCustList as CustomSerializeArrayList;
            if (stockAdjustCsList == null) return status;

            try
            {
                foreach (CustomSerializeArrayList paraList in stockAdjustCsList)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                    // -- ADD 2009/08/03 ------------------------------>>>
                    stockAdjustWorkList = null;       //�݌ɒ����f�[�^���X�g
                    stockAdjustDtlWorkList = null;    //�݌ɒ������׃f�[�^���X�g
                    stockWorkList = null;             //�݌Ƀ��X�g
                    stockWriteList = null;            //�X�V�p�݌Ƀ��X�g
                    stockDeleteList = null;           //�폜�p�݌Ƀ��X�g
                    stockAcPayHistWorkList = null;    //�݌Ɏ󕥗������X�g
                    // -- ADD 2009/08/03 ------------------------------<<<

                    //���X�g����K�v�ȏ����擾
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        ArrayList wkal = paraList[i] as ArrayList;
                        if (wkal != null)
                        {
                            if (wkal.Count > 0)
                            {
                                //�݌ɒ����f�[�^�̏ꍇ
                                if (wkal[0] is StockAdjustWork)
                                {
                                    stockAdjustWorkList = wkal;
                                    enterpriseCode = (wkal[0] as StockAdjustWork).EnterpriseCode;  // 2009/08/03

                                }
                                //�݌ɒ������׃f�[�^�̏ꍇ
                                if (wkal[0] is StockAdjustDtlWork)
                                {
                                    stockAdjustDtlWorkList = wkal;
                                    enterpriseCode = (wkal[0] as StockAdjustDtlWork).EnterpriseCode;  // 2009/08/03
                                }
                                //�݌ɂ̏ꍇ
                                if (wkal[0] is StockWork)
                                {
                                    stockWorkList = wkal;
                                    enterpriseCode = (wkal[0] as StockWork).EnterpriseCode;  // 2009/08/03
                                }
                            }
                        }
                    }

                    // 2009/08/03 ------------>>>
                    //if (stockAdjustWorkList != null && resNm != "")
                    if (enterpriseCode != "" && resNm == "")
                    // 2009/08/03 ------------<<<
                    {

                        // 2009/08/03 ------------------------->>>
                        //StockAdjustWork stockadjustWork = stockAdjustWorkList[0] as StockAdjustWork;
                        //resNm = GetResourceName(stockadjustWork.EnterpriseCode);
                        resNm = GetResourceName(enterpriseCode);
                        // 2009/08/03 -------------------------<<<

                        //�`�o���b�N
                        status = Lock(resNm, sqlConnection, sqlTransaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                            {
                                retMsg = "���b�N�^�C���A�E�g���������܂����B";
                            }
                            else
                            {
                                retMsg = "�r�����b�N�Ɏ��s���܂����B";
                            }

                            return status;
                        }
                    }

                    //---�݌ɒ����`�[�ԍ��̔�---
                    if (stockAdjustWorkList != null)
                    {
                        StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;

                        if (wkStockAdjustWork.StockAdjustSlipNo == 0)
                        {
                            status = CreateStockAdjustSlipNo(wkStockAdjustWork.EnterpriseCode, wkStockAdjustWork.SectionCode, out stockAdjustSlipNo, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                            wkStockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
                        }
                        else
                            stockAdjustSlipNo = wkStockAdjustWork.StockAdjustSlipNo;
                    }

                    //write���s
                    //�݌ɒ����f�[�^�X�V
                    if (stockAdjustWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteStockAdjustProc(ref stockAdjustWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�݌ɒ����f�[�^�̍X�V�Ɏ��s���܂����B";
                    }

                    //�݌ɒ������׃f�[�^�X�V
                    if (stockAdjustDtlWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteDelInsStockAdjustDtlProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�݌ɒ������׃f�[�^�̍X�V�Ɏ��s���܂����B";
                    }

                    //�݌Ɍn�f�[�^�쐬����
                    // 2009/08/03 ------------>>>
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockAdjustWorkList != null)
                    // 2009/08/03 ------------<<<
                    {
                        //�󕥃��X�g���쐬�A�݌Ƀ��X�g�͍쐬���Ȃ�
                        TransStockData(false,(int)ct_WriteMode.Write, null, ref stockAdjustWorkList, ref stockAdjustDtlWorkList, out stockAcPayHistWorkList,ref stockWorkList, (int)ct_ProcMode.BatchInpt, ref sqlConnection, ref sqlTransaction);
                    }

                    if (stockWorkList != null)
                    {
                        //�X�V�p�A�폜�p�̃��X�g���쐬
                        CreateStockWriteDelList(stockWorkList, out stockWriteList, out stockDeleteList);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    //�݌Ƀf�[�^�X�V
                    if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if ((stockWriteList != null) && (stockWriteList.Count != 0))
                        {
                            status = _stockDB.WriteStockBlanket(ref stockWriteList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction, out retMsg);
                        }
                        if ((stockDeleteList != null) && (stockDeleteList.Count != 0))
                        {
                            //�X�V�p�̃��X�g�����݂���ꍇ��WriteStockBlanket�ɂĎ󕥗����f�[�^���쐬����Ă���B
                            //��d�쐬�h�~�̂��߁A�󕥃��X�g���N���A�[
                            if ((stockWriteList != null) && (stockWriteList.Count != 0))
                            {
                                stockAcPayHistWorkList.Clear();
                            }

                            //�폜�Ώۂ̍݌ɂ����݂����ꍇ�͕����폜
                            status = _stockDB.DeleteStockBlanket(ref stockDeleteList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction, out retMsg);
                        }
                    }
                }
                
            }
            finally
            {
                //�`�o�A�����b�N
                // 2009/08/03 -------->>>
                //if (stockAdjustWorkList != null && resNm != "")
                if (resNm != "")
                // 2009/08/03 --------<<<
                {
                    Release(resNm, sqlConnection, sqlTransaction);
                }
            }

            return status;
        }

        /// <summary>
        /// �݌ɒ����f�[�^���݂̂�o�^�A�X�V���܂�(�t�n�d�p)
        /// </summary>
        /// <param name="stockAdjustCustList">stockAdjustCustList�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^���݂̂�o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        /// <br>Update Note: 2008.9.12 ���� PM.NS�p�ɏC��</br>
        public int WriteStockAdjustSlipDtl(ref object stockAdjustCustList, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int stockAdjustSlipNo = 0;
            retMsg = "";
            string retItemInfo = "";

            ArrayList stockAdjustWorkList = null;       //�݌ɒ����f�[�^���X�g
            ArrayList stockAdjustDtlWorkList = null;    //�݌ɒ������׃f�[�^���X�g

            string resNm = "";

            //�p�����[�^�̃L���X�g
            CustomSerializeArrayList stockAdjustCsList = stockAdjustCustList as CustomSerializeArrayList;
            if (stockAdjustCsList == null) return status;

            try
            {
                foreach (CustomSerializeArrayList paraList in stockAdjustCsList)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                    //���X�g����K�v�ȏ����擾
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        ArrayList wkal = paraList[i] as ArrayList;
                        if (wkal != null)
                        {
                            if (wkal.Count > 0)
                            {
                                //�݌ɒ����f�[�^�̏ꍇ
                                if (wkal[0] is StockAdjustWork)
                                {
                                    stockAdjustWorkList = wkal;
                                }
                                //�݌ɒ������׃f�[�^�̏ꍇ
                                if (wkal[0] is StockAdjustDtlWork)
                                {
                                    stockAdjustDtlWorkList = wkal;
                                }
                            }
                        }
                    }

                    if (stockAdjustWorkList != null && resNm != "")
                    {
                        StockAdjustWork stockadjustWork = stockAdjustWorkList[0] as StockAdjustWork;

                        resNm = GetResourceName(stockadjustWork.EnterpriseCode);
                        //�`�o���b�N
                        status = Lock(resNm, sqlConnection, sqlTransaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                            {
                                retMsg = "���b�N�^�C���A�E�g���������܂����B";
                            }
                            else
                            {
                                retMsg = "�r�����b�N�Ɏ��s���܂����B";
                            }

                            return status;
                        }
                    }

                    //---�݌ɒ����`�[�ԍ��̔�---
                    if (stockAdjustWorkList != null)
                    {
                        StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;

                        if (wkStockAdjustWork.StockAdjustSlipNo == 0)
                        {
                            status = CreateStockAdjustSlipNo(wkStockAdjustWork.EnterpriseCode, wkStockAdjustWork.SectionCode, out stockAdjustSlipNo, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                            wkStockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
                        }
                        else
                            stockAdjustSlipNo = wkStockAdjustWork.StockAdjustSlipNo;
                    }

                    //write���s
                    //�݌ɒ����f�[�^�X�V
                    if (stockAdjustWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteStockAdjustProc(ref stockAdjustWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�݌ɒ����f�[�^�̍X�V�Ɏ��s���܂����B";
                    }

                    //�݌ɒ������׃f�[�^�X�V
                    if (stockAdjustDtlWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteDelInsStockAdjustDtlProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�݌ɒ������׃f�[�^�̍X�V�Ɏ��s���܂����B";
                    }

                }
            }
            finally
            {
                //�`�o�A�����b�N
                if (stockAdjustWorkList != null && resNm != "")
                {
                    Release(resNm, sqlConnection, sqlTransaction);
                }
            }

            return status;
        }


        /// <summary>   
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂��B�i�ߕs���X�V�p�j
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="shelfNoUpdateDiv">�I�ԍX�V�敪 (0:���� 1:���Ȃ�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        /// <br>Update Note: 2013/10/09 yangyi</br>
        /// <br>             redmine#31106 �u�I���ߕs���X�V�v�̕��׌y���Ə������ԒZ�k�̒���</br>
        /// <br>Update Note: K2015/08/21 ��</br>
        /// <br>             Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C��</br>

        //public int WriteInventory(ref object stockAdjustWork, out string retMsg, int shelfNoUpdateDiv) // DEL �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C��
        public int WriteInventory(object stockAdjustWork, out string retMsg, int shelfNoUpdateDiv) // ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C��
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;
            int stockAdjustSlipNo = 0;
            retMsg = "";
            string retItemInfo = "";

            string resNm = "";

            // ----- ADD 2013/10/09 ---------->>>>>
            // �݌ɊǗ��S�̐ݒ�
            StockMngTtlStDB stockMngTtlStDB = new StockMngTtlStDB();
            StockMngTtlStWork stockMngTtlStWork = new StockMngTtlStWork(); ;
            // ----- ADD 2013/10/09 ----------<<<<<

            //�R�l�N�V��������
            sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            // �g�����U�N�V�����J�n
            sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            try
            {

                //�p�����[�^�̃L���X�g
                CustomSerializeArrayList stockAdjustCsList = stockAdjustWork as CustomSerializeArrayList;
                if (stockAdjustCsList == null) return status;

                // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                ArrayList infoList = new ArrayList(); //�V�F�A�`�F�b�N��񃊃X�g
                Dictionary<string, string> dic = new Dictionary<string, string>(); //�q�Ƀ��X�g 

                StockAdjustDtlWork _stockAdjustDtlWork = null;

                foreach (CustomSerializeArrayList paraList in stockAdjustCsList)
                {
                    ArrayList stockAdjustDtlWorkList = ListUtils.Find(paraList, typeof(StockAdjustDtlWork), ListUtils.FindType.Array) as ArrayList;

                    if (stockAdjustDtlWorkList != null && stockAdjustDtlWorkList.Count > 0)
                    {
                        foreach (StockAdjustDtlWork st in stockAdjustDtlWorkList)
                        {
                            _stockAdjustDtlWork = stockAdjustDtlWorkList[0] as StockAdjustDtlWork;
                            if (dic.ContainsKey(st.WarehouseCode.Trim()) == false)
                            {
                                dic.Add(st.WarehouseCode.Trim(), st.WarehouseCode.Trim());
                            }
                        }
                    }
                }
                foreach (string wCode in dic.Keys)
                {
                    ShareCheckInfo info = new ShareCheckInfo();
                    info.Keys.Add(_stockAdjustDtlWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    infoList.Add(info);
                    if (status != 0) return status;
                }
                // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                ArrayList inventoryDataUpdateList = ListUtils.Find(stockAdjustCsList[0] as CustomSerializeArrayList, typeof(InventoryDataUpdateWork), ListUtils.FindType.Array) as ArrayList;

                if (inventoryDataUpdateList != null && inventoryDataUpdateList.Count > 0)
                {
                    InventoryDataUpdateWork inventoryDataUpdateWork = inventoryDataUpdateList[0] as InventoryDataUpdateWork;
                    resNm = GetResourceName(inventoryDataUpdateWork.EnterpriseCode);
                    //�`�o���b�N
                    status = Lock(resNm, sqlConnection, sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                        {
                            retMsg = "���b�N�^�C���A�E�g���������܂����B";
                        }
                        else
                        {
                            retMsg = "�r�����b�N�Ɏ��s���܂����B";
                        }

                        return status;
                    }

                }

                // ----- ADD 2013/10/09 ---------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �݌ɊǗ��S�̐ݒ�́u���݌ɕ\���敪�v�ɂ��A�󒍐��͎Z�o�����ǉ��̔��f
                    if (inventoryDataUpdateList != null && inventoryDataUpdateList.Count > 0)
                    {
                        InventoryDataUpdateWork inventoryDataUpdateWork = inventoryDataUpdateList[0] as InventoryDataUpdateWork;
                        stockMngTtlStWork.EnterpriseCode = inventoryDataUpdateWork.EnterpriseCode;
                    }

                    stockMngTtlStWork.SectionCode = "00";
                    // XML�֕ϊ����A������̃o�C�i����
                    byte[] parabyte = XmlByteSerializer.Serialize(stockMngTtlStWork);
                    // �݌ɊǗ��S�̐ݒ�ǂݍ���
                    status = stockMngTtlStDB.Read(ref parabyte, 0);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // XML�̓ǂݍ���
                        stockMngTtlStWork = (StockMngTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockMngTtlStWork));
                    }
                    else
                    {
                        stockMngTtlStWork = null;
                        retMsg = "�v���O�����G���[�B�݌ɊǗ��S�̐ݒ���擾�Ɏ��s���܂����B";

                    }
                }
                // ----- ADD 2013/10/09 ----------<<<<<

                try
                {
                    foreach (CustomSerializeArrayList paraList in stockAdjustCsList)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        ArrayList stockAdjustWorkList = null;           //�݌ɒ����f�[�^���X�g
                        ArrayList stockAdjustDtlWorkList = null;        //�݌ɒ������׃f�[�^���X�g
                        ArrayList stockWorkList = null;                 //�݌Ƀ��X�g
                        //ArrayList trgStockWorkList = null;              //�X�V�Ώۍ݌Ƀ��X�g //2009/06/15
                        ArrayList stockAcPayHistWorkList = null;        //�݌Ɏ󕥗������X�g
                        ArrayList inventoryDataUpdateWorkList = null;   //�I���X�V���X�g


                        //���X�g����K�v�ȏ����擾
                        for (int i = 0; i < paraList.Count; i++)
                        {
                            ArrayList wkal = paraList[i] as ArrayList;
                            if (wkal != null)
                            {
                                if (wkal.Count > 0)
                                {
                                    //�݌ɒ����f�[�^�̏ꍇ
                                    if (wkal[0] is StockAdjustWork)
                                    {
                                        stockAdjustWorkList = wkal;
                                    }
                                    //�݌ɒ������׃f�[�^�̏ꍇ
                                    if (wkal[0] is StockAdjustDtlWork)
                                    {
                                        stockAdjustDtlWorkList = wkal;
                                    }
                                    //�݌ɂ̏ꍇ
                                    if (wkal[0] is StockWork)
                                    {
                                        stockWorkList = wkal;
                                    }
                                    //�I���X�V�̏ꍇ
                                    if (wkal[0] is InventoryDataUpdateWork)
                                    {
                                        inventoryDataUpdateWorkList = wkal;
                                    }

                                }
                            }
                        }

                        // 2009/06/15 >>>>>>>>>>>>>>>>>>>>>>>>
                        ////�X�V�ΏۂƂȂ�݌��ް��̎擾
                        //if (inventoryDataUpdateWorkList != null && inventoryDataUpdateWorkList.Count > 0)
                        //{
                        //    status = _inventoryExcDefUpdateDB.SearchStockFromInventoryProc(inventoryDataUpdateWorkList, out trgStockWorkList, ref sqlConnection, ref sqlTransaction);
                        //}
                        // 2009/06/15 <<<<<<<<<<<<<<<<<<<<<<<<

                        //---�݌ɒ����`�[�ԍ��̔�---
                        if (stockAdjustWorkList != null && stockAdjustWorkList.Count > 0)
                        {
                            StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;
                            if (wkStockAdjustWork.StockAdjustSlipNo == 0)
                            {
                                status = CreateStockAdjustSlipNo(wkStockAdjustWork.EnterpriseCode, wkStockAdjustWork.SectionCode, out stockAdjustSlipNo, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                                wkStockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
                            }
                            else
                                stockAdjustSlipNo = wkStockAdjustWork.StockAdjustSlipNo;
                        }


                        //write���s
                        //�݌ɒ����f�[�^�X�V
                        if (stockAdjustWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = WriteStockAdjustProc(ref stockAdjustWorkList, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�݌ɒ����f�[�^�̍X�V�Ɏ��s���܂����B";
                        }

                        //�݌ɒ������׃f�[�^�X�V
                        if (stockAdjustDtlWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = WriteDelInsStockAdjustDtlProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�݌ɒ������׃f�[�^�̍X�V�Ɏ��s���܂����B";
                        }

                        //�݌Ɍn�f�[�^�쐬����
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockAdjustWorkList != null && stockAdjustDtlWorkList != null)
                        {
                            TransStockData(false, (int)ct_WriteMode.Write, null, ref stockAdjustWorkList, ref stockAdjustDtlWorkList, out stockAcPayHistWorkList, ref stockWorkList, (int)ct_ProcMode.Inventory, ref sqlConnection, ref sqlTransaction);
                        }

                        // 2009/06/15 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        ////�ŏI�I���X�V���̍X�V�p�̍X�V�Ώۍ݌Ƀ��X�g��ǉ�
                        //if (stockWorkList == null) stockWorkList = trgStockWorkList;
                        //else
                        //    stockWorkList.AddRange(trgStockWorkList);
                        // 2009/06/15 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        //�݌Ƀf�[�^�X�V
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockWorkList != null && stockWorkList.Count > 0)
                        {
                            string origin = "";
                            CustomSerializeArrayList originList = null;
                            CustomSerializeArrayList tempparaList = new CustomSerializeArrayList();

                            if (stockWorkList != null && stockWorkList.Count > 0)
                                tempparaList.Add(stockWorkList);
                            if (stockAcPayHistWorkList != null && stockAcPayHistWorkList.Count > 0)
                                tempparaList.Add(stockAcPayHistWorkList);
                            int position = 0;
                            string param = "";
                            object freeParam = null;
                            //status = _stockDB.WriteForStockAdjust(origin, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);                  //DEL 2013/10/09
                            status = _stockDB.WriteFromInventory(origin, stockMngTtlStWork, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);  //ADD 2013/10/09

                        }

                        //�I���f�[�^�̍X�V
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && inventoryDataUpdateWorkList != null)
                        {
                            status = _inventoryExcDefUpdateDB.WriteLastInventoryUpdateProc(ref inventoryDataUpdateWorkList, ref sqlConnection, ref sqlTransaction);
                        }

                    }
                }
                finally
                {
                    //�`�o�A�����b�N
                    if (resNm != "")
                    {
                        Release(resNm, sqlConnection, sqlTransaction);
                    }

                    // �V�X�e�����b�N����(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    if (infoList != null && infoList.Count != 0)
                    {
                        foreach (ShareCheckInfo info in infoList)
                        {
                            status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        }
                    }
                    // �V�X�e�����b�N����(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                    
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //base.WriteErrorLog(ex, "StockAdjustDB.WriteInventory(ref object stockAdjustWork)"); // DEL �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C��
                base.WriteErrorLog(ex, "StockAdjustDB.WriteInventory(object stockAdjustWork)"); // ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C��
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // �R�~�b�g
                        sqlTransaction.Commit();
                    else
                    {
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }
                
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� ----->>>>>
        /// <summary>
        /// �I������(�ߕs�����p)
        /// </summary>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="inventInputUpdateCndtnWork">�X�V�p�����[�^</param>
        /// <param name="isSaved">isSaved</param>
        /// <param name="secInfoSetDic">���_�R�[�h�Ɩ���</param>
        /// <param name="warehouseDic">�q�ɃR�[�h�Ɩ���</param>
        /// <param name="makerUMntDic">���[�J�R�[�h�Ɩ���</param>
        /// <param name="blGoodsCdUMntDic">BL���i�R�[�h�Ɩ���</param>
        /// <param name="message">message</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^�����Ɖߕs���X�V</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        public int SearchInventAndUpdate(object paraobj, object inventInputUpdateCndtnWork, out bool isSaved, object secInfoSetDic, object warehouseDic, object makerUMntDic, object blGoodsCdUMntDic, out string message)
        {
            Dictionary<string, List<GoodsPriceUWork>> dicPriceList;
            Dictionary<string, InventoryDataUpdateWork> inventoryDataDictionary;
            object retObj;
            object retObjDic;
            message = string.Empty;
            isSaved = false;
            InventInputUpdateCndtnWork inventUpdateWork = inventInputUpdateCndtnWork as InventInputUpdateCndtnWork;
            int fractionProcCd = inventUpdateWork.FractionProcCd;
            int inventoryMngDiv = inventUpdateWork.InventoryMngDiv;
            // �I������(�ߕs�����p)
            int status = this.inventInputSearchDB.SearchInvent(out retObj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out retObjDic);

            dicPriceList = new Dictionary<string, List<GoodsPriceUWork>>();
            inventoryDataDictionary = new Dictionary<string, InventoryDataUpdateWork>();
            if (retObjDic != null)
            {
                dicPriceList = retObjDic as Dictionary<string, List<GoodsPriceUWork>>;
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (ArrayList retArray in (ArrayList)retObj)
                {
                    // �߂胊�X�g�̗v�f�̌^��InventoryDataUpdateWork�Ȃ�΃f�[�^�W�J
                    if ((retArray.Count > 0) && (retArray[0] is InventoryDataUpdateWork))
                    {
                        foreach (InventoryDataUpdateWork data in retArray)
                        {
                            // �ߕs���X�V�敪=0:���X�V�ꍇ
                            // ���i�}�X�^�����o�^���́A�_���폜�̏ꍇ
                            if (data.ToleranceUpdateCd == 0 && data.GoodsDiv == 0 && !"���޼".Equals(data.WarehouseShelfNo) && !"���޼".Equals(data.WarehouseShelfNo))
                            {
                                // �f�[�^�e�[�u���L���b�V��
                                Cache(data, ref inventoryDataDictionary);
                            }
                        }
                    }
                }
                status = this.Save(retObj, inventUpdateWork, out isSaved, out message, secInfoSetDic, warehouseDic, makerUMntDic, blGoodsCdUMntDic, dicPriceList, inventoryDataDictionary);
            }

            return status;
        }

        /// <summary>
        /// �f�[�^�e�[�u���L���b�V������
        /// </summary>
        /// <param name="inventoryDataUpdateWork">�I���f�[�^�������ʃI�u�W�F�N�g</param>
        /// <param name="inventoryDataDictionary">�I���f�[�^�������ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I���f�[�^�������ʃI�u�W�F�N�g���f�[�^�e�[�u���ɃL���b�V�����܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private void Cache(InventoryDataUpdateWork inventoryDataUpdateWork, ref Dictionary<string, InventoryDataUpdateWork> inventoryDataDictionary)
        {
            inventoryDataDictionary.Add(CreatKey(inventoryDataUpdateWork), inventoryDataUpdateWork);
        }

        /// <summary>
        /// key�̐ݒ�
        /// </summary>
        /// <param name="work">work</param>
        /// <returns>key</returns>
        /// <remarks>
        /// <br>Note       : key�̐ݒ���s���܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private string CreatKey(InventoryDataUpdateWork work)
        {
            StringBuilder key = new StringBuilder();

            if (work != null)
            {
                // ���_�R�[�h
                key.Append(work.SectionCode);
                // �I���ʔ�
                key.Append(work.InventorySeqNo.ToString());
                // �q�ɃR�[�h
                key.Append(work.WarehouseCode);
            }

            return key.ToString();
        }

        /// <summary>
        /// �I���f�[�^��ۑ����܂��B
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �I���f�[�^��ۑ����܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/13</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br>           : Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C��</br>
        /// </remarks>
        private int Save(object retObj, InventInputUpdateCndtnWork inventInputUpdateCndtnWork, out bool isSaved, out string message, object secInfoSetDic, object warehouseDic, object makerUMntDic, object blGoodsCdUMntDic,
            Dictionary<string, List<GoodsPriceUWork>> dicPriceList, Dictionary<string, InventoryDataUpdateWork> inventoryDataDictionary)
        {
            isSaved = false;
            int status = -1;
            message = "";

            // �ۑ��p�f�[�^��������
            CustomSerializeArrayList saveData = this.CreateSaveData(retObj, inventInputUpdateCndtnWork, secInfoSetDic, warehouseDic, makerUMntDic, blGoodsCdUMntDic, dicPriceList, inventoryDataDictionary);
            object objSaveData = (object)saveData;

            if (saveData.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                // �݌ɒ����f�[�^����o�^�A�X�V���܂��B
                status = this.WriteInventory(objSaveData, out message, inventInputUpdateCndtnWork.ShelfNoDiv);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    isSaved = true;
                }
            }
            return status;
        }

        #region �ۑ��p�f�[�^��������
        /// <summary>
        /// �ۑ��p�f�[�^��������
        /// </summary>
        /// <returns>�ۑ��p�f�[�^(CustomSerializeArrayList)</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��p�f�[�^���쐬���܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private CustomSerializeArrayList CreateSaveData(object retObj, InventInputUpdateCndtnWork inventUpdatePara, object secInfoSetDic, object warehouseDic, object makerUMntDic, object blGoodsCdUMntDic,
            Dictionary<string, List<GoodsPriceUWork>> dicPriceList, Dictionary<string, InventoryDataUpdateWork> inventoryDataDictionary)
        {
            CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();
            ArrayList stockAdjustWorkList = new ArrayList();
            ArrayList stockAdjustDtlWorkList = new ArrayList();
            ArrayList stockWorkList = new ArrayList();
            ArrayList inventoryDataList = new ArrayList();
            Dictionary<string, StockWork> stockDictionary = new Dictionary<string, StockWork>();
            Dictionary<string, List<ArrayList>> dataTableDic = new Dictionary<string, List<ArrayList>>();
            Dictionary<string, DateTime> totalDayDic = new Dictionary<string, DateTime>();

            // �O���b�h�̖��ׂ������ꍇ�A�����𔲂���
            if (retObj == null)
            {
                return saveDataList;
            }

            foreach (ArrayList al in (CustomSerializeArrayList)retObj)
            {
                if ((al.Count > 0) && (al[0] is InventoryDataUpdateWork))
                {
                    foreach (InventoryDataUpdateWork wkInventoryDataUpdateWork in al)
                    {

                        string strKey = wkInventoryDataUpdateWork.EnterpriseCode + "," + wkInventoryDataUpdateWork.SectionCode + ","
                                             + wkInventoryDataUpdateWork.InventorySeqNo.ToString() + "," + wkInventoryDataUpdateWork.WarehouseCode;

                        ArrayList al1 = new ArrayList();
                        if (dataTableDic.ContainsKey(strKey))
                        {

                            al1.Add(wkInventoryDataUpdateWork);
                            dataTableDic[strKey].Add(al1);
                        }
                        else
                        {
                            List<ArrayList> list = new List<ArrayList>();
                            al1.Add(wkInventoryDataUpdateWork);
                            list.Add(al1);
                            dataTableDic.Add(strKey, list);

                        }
                    }
                }

            }

            foreach (InventoryDataUpdateWork workData in inventoryDataDictionary.Values)
            {
                CustomSerializeArrayList csArrayList = new CustomSerializeArrayList();


                // �I���f�[�^�쐬
                inventoryDataList.Clear();
                // �I���^�p�敪���o�l�D�m�r
                if (inventUpdatePara.InventoryMngDiv == 0)
                {
                    workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockAmount;          //�I���ߕs����(�I�����|���{�����됔)
                    workData.InventoryTlrncPrice
                        = this.GetTotalPriceToLong(workData.InventoryTolerancCnt, workData.StockUnitPriceFl, inventUpdatePara.FractionProcCd);   //�I���ߕs�����z(�I���ߕs�����~�d���P��(����))
                    workData.LastInventoryUpdate = DateTime.Today;                                              //�I���ŏI�X�V��
                    workData.StockTotalExec = workData.StockAmount;                                             //�݌ɑ���(���{��)
                    workData.ToleranceUpdateCd = 1;                                                             //�ߕs���X�V�敪�@1:�X�V
                }
                // �I���^�p�敪���o�l�V
                else
                {
                    workData.LastInventoryUpdate = DateTime.Today;                                              //�I���ŏI�X�V��
                    workData.StockTotalExec = workData.StockTotal;                                              //�݌ɑ���(���{��) = �݌ɑ���
                    workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockTotalExec;       //�I���ߕs����(�I�����|�݌ɑ����i���{���j)
                    workData.InventoryTlrncPrice
                        = this.GetTotalPriceToLong(workData.InventoryTolerancCnt, workData.StockUnitPriceFl, inventUpdatePara.FractionProcCd);   //�I���ߕs�����z(�I���ߕs�����~�d���P��(����))
                    workData.ToleranceUpdateCd = 1;                                                             //�ߕs���X�V�敪�@1:�X�V
                }

                inventoryDataList.Add(workData);
                csArrayList.Add(inventoryDataList.Clone());

                //�s���f�[�^�̑Ή�
                string wareHouseCodeStr = workData.WarehouseCode;
                if (wareHouseCodeStr.Trim().Length < 4)
                {
                    wareHouseCodeStr = wareHouseCodeStr.Trim().PadLeft(4, '0').PadRight(6, ' ');
                }
                string strKey = workData.EnterpriseCode + "," + workData.SectionCode + "," + workData.InventorySeqNo.ToString() + "," + wareHouseCodeStr;

                List<ArrayList> rows = new List<ArrayList>();

                if (dataTableDic.ContainsKey(strKey))
                {
                    rows = dataTableDic[strKey];
                }
                if (rows.Count == 0)
                {
                    saveDataList.Add(csArrayList);      //�I���f�[�^�̂�
                    continue;
                }
                ArrayList row = (ArrayList)rows[0];

                if (row.Count > 0)
                {
                    InventoryDataUpdateWork inventoryDataUpdateWork = (InventoryDataUpdateWork)row[0];
                    // ������
                    stockAdjustWorkList.Clear();            //�݌ɒ���
                    stockAdjustDtlWorkList.Clear();         //�݌ɒ�������
                    stockDictionary.Clear();                //�݌�1
                    stockWorkList.Clear();                  //�݌�2

                    // �ߕs�����`�F�b�N
                    if (inventoryDataUpdateWork.InventoryTolerancCnt != 0)
                    {
                        // �݌ɒ������׃f�[�^�쐬
                        this.CreateStockAdjustDtl(inventoryDataUpdateWork, inventUpdatePara, ref stockAdjustDtlWorkList, secInfoSetDic, warehouseDic, makerUMntDic, blGoodsCdUMntDic, dicPriceList, ref totalDayDic);


                        // �݌ɒ����f�[�^�쐬
                        StockAdjustWork stockAdjustWork = this.CreateStockAdjust(inventoryDataUpdateWork, inventUpdatePara, secInfoSetDic, ref totalDayDic);

                        // --[�݌ɒ����f�[�^]�d�����z���v�����߂�
                        long stockPriceTaxExec = 0;
                        foreach (StockAdjustDtlWork work in stockAdjustDtlWorkList)
                        {
                            stockPriceTaxExec += work.StockPriceTaxExc;
                        }
                        stockAdjustWork.StockSubttlPrice = stockPriceTaxExec;

                        stockAdjustWorkList.Add(stockAdjustWork);


                        // �쐬�����f�[�^��ǉ�
                        csArrayList.Add(stockAdjustWorkList.Clone());       //�݌ɒ���
                        csArrayList.Add(stockAdjustDtlWorkList.Clone());    //�݌ɒ�������                        
                    }

                    // �݌Ƀf�[�^�쐬
                    // �I���^�p�敪���o�l�D�m�r
                    if (inventUpdatePara.InventoryMngDiv == 0)
                    {
                        inventoryDataUpdateWork.InventoryTolerancCnt = inventoryDataUpdateWork.InventoryStockCnt - inventoryDataUpdateWork.StockAmount;     //�d���݌ɐ�(�I���ߕs�����F�I�����|���{�����됔)
                    }
                    // �I���^�p�敪���o�l�V
                    else
                    {
                        inventoryDataUpdateWork.InventoryTolerancCnt = inventoryDataUpdateWork.InventoryStockCnt - inventoryDataUpdateWork.StockTotal;     //�d���݌ɐ�(�I���ߕs�����F�I�����|���{�����됔)
                    }
                    this.CreateStock(inventoryDataUpdateWork, ref stockDictionary, warehouseDic);

                    foreach (StockWork stockWork in stockDictionary.Values)
                    {
                        stockWorkList.Add(stockWork);
                    }

                    // �쐬�����f�[�^��ǉ�
                    csArrayList.Add(stockWorkList.Clone());             //�݌�
                    
                }

                saveDataList.Add(csArrayList);
            }

            return saveDataList;
        }
        #endregion

        #region StockTotalPriceToLong(�݌ɋ��z�Z�o)
        /// <summary>
        /// ���z�Z�o(Long�^�ŕԂ�)
        /// </summary>
        /// <param name="unitCount">����</param>
        /// <param name="unitCost">����</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <returns>���v���z</returns>
        /// <remarks>
        /// <br>Note       : ���z���Z�o���A�݌ɊǗ��S�̐ݒ�̒[�������敪�ɏ]���Ē[���������s���܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        public long GetTotalPriceToLong(double unitCount, double unitCost, int fractionProcCd)
        {
            long longStockTotalPrice = 0;
            double doubleStockTotalPrice = unitCost * unitCount;       // ���P���~����

            // �݌ɑS�̊Ǘ��ݒ�̒[�������敪�ɏ]��
            switch (fractionProcCd)
            {
                case 1:
                    {
                        // �؂�̂�
                        longStockTotalPrice = (long)(doubleStockTotalPrice / 1);
                        break;
                    }
                case 2:
                    {
                        // �l�̌ܓ�
                        if (doubleStockTotalPrice >= 0)
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice + 0.5) / 1);
                        }
                        else
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice - 0.5) / 1);
                        }
                        break;
                    }
                case 3:
                    {
                        // �؂�グ
                        if (doubleStockTotalPrice % 1 == 0)
                        {
                            longStockTotalPrice = (long)(doubleStockTotalPrice);
                        }
                        else
                        {
                            if (doubleStockTotalPrice >= 0)
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice + 1) / 1);
                            }
                            else
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice - 1) / 1);
                            }
                        }
                        break;
                    }
                default:
                    {
                        longStockTotalPrice = (long)(doubleStockTotalPrice);
                        break;
                    }
            }

            return longStockTotalPrice;
        }
        #endregion

        /// <summary>
        /// �݌ɒ������׃f�[�^���[�N�N���X��������
        /// </summary>
        /// <param name="data">�I���X�V�f�[�^���[�N�N���X</param>
        /// <param name="retList">�݌ɒ������׃f�[�^���X�g</param>
        /// <param name="inventUpdatePara">�ߕs���X�V�p�����[�^</param>
        /// <param name="secInfoSetDic">���_�R�[�h�Ɩ���</param>
        /// <param name="warehouseDic">�q�ɃR�[�h�Ɩ���</param>
        /// <param name="makerUMntDic">���[�J�R�[�h�Ɩ���</param>
        /// <param name="blGoodsCdUMntDic">BL���i�R�[�h�Ɩ���</param>
        /// <param name="dicPriceList">dicPriceList</param>
        /// <param name="totalDayDic">totalDayDic</param>
        /// <returns>�݌ɒ������׃f�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ������׃f�[�^���[�N�N���X�𐶐����܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private void CreateStockAdjustDtl(InventoryDataUpdateWork data, InventInputUpdateCndtnWork inventUpdatePara, ref ArrayList retList, object secInfoSetDic, object warehouseDic,
            object makerUMntDic, object blGoodsCdUMntDic, Dictionary<string, List<GoodsPriceUWork>> dicPriceList, ref Dictionary<string, DateTime> totalDayDic)
        {
            StockAdjustDtlWork workData = new StockAdjustDtlWork();

            // ��ƃR�[�h
            workData.EnterpriseCode = data.EnterpriseCode;
            // ���_�R�[�h
            workData.SectionCode = inventUpdatePara.SectionCode;
            // ���_��
            workData.SectionGuideNm = GetSectionName(workData.SectionCode.Trim(), secInfoSetDic);
            // �݌ɒ����`�[�ԍ�
            workData.StockAdjustSlipNo = 0;
            // �݌ɒ����s�ԍ�
            workData.StockAdjustRowNo = retList.Count + 1;
            // �󕥌��`�[�敪(50:�I��)
            workData.AcPaySlipCd = 50;
            // �󕥌�����敪(40:�ߕs���X�V)
            workData.AcPayTransCd = 40;
            // �������t
            // �O����������擾
            DateTime prevTotalDay = GetPrevTotalDay(data.SectionCode, inventUpdatePara.EnterpriseCode, ref totalDayDic);
            if (data.InventoryDate <= prevTotalDay)
            {
                // �I�����{�����Z�b�g
                workData.AdjustDate = prevTotalDay.AddDays(1);
            }
            else
            {
                // �I�������Z�b�g
                workData.AdjustDate = data.InventoryDate;
            }
            // ���͓��t
            workData.InputDay = DateTime.Now;
            // ���[�J�[�R�[�h
            workData.GoodsMakerCd = data.GoodsMakerCd;
            // ���[�J�[����
            workData.MakerName = GetMakerName(data.GoodsMakerCd, makerUMntDic);
            // ���i�R�[�h
            workData.GoodsNo = data.GoodsNo;
            // ���i����
            workData.GoodsName = data.GoodsName;
            // �d���P��
            workData.StockUnitPriceFl = data.AdjstCalcCost;
            // �ύX�O�d���P��
            workData.BfStockUnitPriceFl = workData.StockUnitPriceFl;
            // ������
            workData.AdjustCount = data.InventoryTolerancCnt;
            // ���ה��l
            workData.DtlNote = "";
            // �q�ɃR�[�h
            workData.WarehouseCode = data.WarehouseCode;
            // �q�ɖ���
            workData.WarehouseName = GetWarehouseName(data.WarehouseCode.Trim(), warehouseDic);
            // BL�R�[�h
            workData.BLGoodsCode = data.BLGoodsCode;
            // BL�R�[�h����
            workData.BLGoodsFullName = GetBLGoodsName(data.BLGoodsCode, blGoodsCdUMntDic);
            // �q�ɒI��
            workData.WarehouseShelfNo = data.WarehouseShelfNo;
            // �d�����z
            //�݌ɊǗ��S�̐ݒ�̒[�������敪���g�p����悤�ɏC��
            long retMoney;
            FractionCalculate.FracCalcMoney(data.InventoryTolerancCnt * data.AdjstCalcCost, 1.00, inventUpdatePara.FractionProcCd, out retMoney);
            workData.StockPriceTaxExc = retMoney;

            // �艿
            if (data.InventoryDate <= prevTotalDay)
            {
                // �I�����{�����Z�b�g
                workData.ListPriceFl = GetListPriceFl2(data.GoodsMakerCd, data.GoodsNo, workData.AdjustDate, dicPriceList);
            }
            else
            {
                // �I�������Z�b�g 
                workData.ListPriceFl = GetListPriceFl2(data.GoodsMakerCd, data.GoodsNo, workData.AdjustDate, dicPriceList);
            }

            retList.Add(workData);
        }

        /// <summary>
        /// �݌ɒ����f�[�^���[�N�N���X��������
        /// </summary>
        /// <param name="data">�I���X�V�f�[�^���[�N�N���X</param>
        /// <param name="inventUpdatePara">�ߕs���X�V�p�����[�^</param>
        /// <param name="secInfoSetDic">���_�R�[�h�Ɩ���</param>
        /// <param name="totalDayDic">totalDayDic</param>
        /// <returns>�݌ɒ����f�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ����f�[�^���[�N�N���X�𐶐����܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private StockAdjustWork CreateStockAdjust(InventoryDataUpdateWork data, InventInputUpdateCndtnWork inventUpdatePara, object secInfoSetDic, ref Dictionary<string, DateTime> totalDayDic)
        {
            StockAdjustWork workData = new StockAdjustWork();

            // ��ƃR�[�h
            workData.EnterpriseCode = data.EnterpriseCode;
            // ���_�R�[�h
            workData.SectionCode = inventUpdatePara.SectionCode;
            // ���_��
            workData.SectionGuideNm = GetSectionName(workData.SectionCode.Trim(), secInfoSetDic);
            // �󕥌��`�[�敪(50�F�I��)
            workData.AcPaySlipCd = 50;
            // �󕥌�����敪(40�F�ߕs���X�V)
            workData.AcPayTransCd = 40;
            // �������t
            // �O����������擾
            DateTime prevTotalDay = GetPrevTotalDay(data.SectionCode, inventUpdatePara.EnterpriseCode, ref totalDayDic);
            if (data.InventoryDate <= prevTotalDay)
            {
                // �I�����{�����Z�b�g
                workData.AdjustDate = prevTotalDay.AddDays(1);
            }
            else
            {
                // �I�������Z�b�g
                workData.AdjustDate = data.InventoryDate;
            }
            // ���͓��t
            workData.InputDay = DateTime.Now;
            // �d�����_�R�[�h
            workData.StockSectionCd = data.SectionCode;
            // �d�����_����
            workData.StockSectionGuideNm = GetSectionName(data.SectionCode.Trim(), secInfoSetDic);
            // �d�����͎҃R�[�h
            workData.StockInputCode = inventUpdatePara.EmployeeCode;
            // �d�����͎Җ���
            workData.StockInputName = inventUpdatePara.EmployeeName;
            // �d���S���҃R�[�h
            workData.StockAgentCode = inventUpdatePara.EmployeeCode;
            // �d���S���Җ���
            workData.StockAgentName = inventUpdatePara.EmployeeName;

            return workData;
        }

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="_makerUMntDic">���[�J�R�[�h�Ɩ���</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private string GetMakerName(int makerCode, object _makerUMntDic)
        {
            string makerName = "";
            Dictionary<int, string> makerUMntDic;
            makerUMntDic = _makerUMntDic as Dictionary<int, string>;

            if (makerUMntDic.ContainsKey(makerCode))
            {
                makerName = makerUMntDic[makerCode];
            }

            return makerName;
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="_secInfoSetDic">���_�R�[�h�Ɩ���</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        public string GetSectionName(string sectionCode, object _secInfoSetDic)
        {
            string sectionName = "";
            Dictionary<string, string> secInfoSetDic;
            secInfoSetDic = _secInfoSetDic as Dictionary<string, string>;

            if (secInfoSetDic.ContainsKey(sectionCode.PadLeft(2, '0')))
            {
                sectionName = secInfoSetDic[sectionCode.PadLeft(2, '0')];
            }

            return sectionName;
        }

        /// <summary>
        /// �q�ɖ��̎擾����
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="_warehouseDic">�q�ɃR�[�h�Ɩ���</param>
        /// <returns>�q�ɖ���</returns>
        /// <remarks>
        /// <br>Note       : �q�ɖ��̂��擾���܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        public string GetWarehouseName(string warehouseCode, object _warehouseDic)
        {
            string warehouseName = "";
            Dictionary<string, string> warehouseDic;
            warehouseDic = _warehouseDic as Dictionary<string, string>;

            if (warehouseDic.ContainsKey(warehouseCode))
            {
                warehouseName = warehouseDic[warehouseCode];
            }

            return warehouseName;
        }

        /// <summary>
        /// BL�R�[�h���̎擾����
        /// </summary>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <param name="_blGoodsCdUMntDic">BL�R�[�h�Ɩ���</param>
        /// <returns>BK�R�[�h����</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h���̂��擾���܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode, object _blGoodsCdUMntDic)
        {
            string blGoodsName = "";
            Dictionary<int, string> blGoodsCdUMntDic;
            blGoodsCdUMntDic = _blGoodsCdUMntDic as Dictionary<int, string>;

            if (blGoodsCdUMntDic.ContainsKey(blGoodsCode))
            {
                blGoodsName = blGoodsCdUMntDic[blGoodsCode];
            }

            return blGoodsName;
        }

        /// <summary>
        /// �ŏI�����X�V���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">���_�R�[�h</param>
        /// <param name="totalDayDic">totalDayDic</param>
        /// <returns>�ŏI�����X�V��</returns>
        /// <remarks>
        /// <br>Note       : �ŏI�����X�V�����擾���܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private DateTime GetPrevTotalDay(string sectionCode, string enterpriseCode, ref Dictionary<string, DateTime> totalDayDic)
        {

            DateTime prevTotalDay = new DateTime();

            int status = 0;
            if (totalDayDic.ContainsKey(sectionCode))
            {
                prevTotalDay = totalDayDic[sectionCode];
            }
            else
            {
                try
                {
                    status = GetHisTotalDayMonthly(enterpriseCode, sectionCode, out prevTotalDay);

                    if (prevTotalDay == DateTime.MinValue)
                    {
                        status = GetHisTotalDayMonthly(enterpriseCode, string.Empty, out prevTotalDay);
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        prevTotalDay = new DateTime();
                    }
                    totalDayDic.Add(sectionCode, prevTotalDay);
                }
                catch
                {
                    prevTotalDay = new DateTime();
                }
            }
            return prevTotalDay;
        }

        /// <summary>
        /// �����擾�����y�����E�������|�����|�z
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �ŏI�����X�V�����擾���܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private int GetHisTotalDayMonthly(string enterpriseCode, string sectionCode, out DateTime prevTotalDay)
        {
            int status = -1;
            // ������
            prevTotalDay = DateTime.MinValue;

            DateTime[] retPrevTotalDay = new DateTime[2];

            // ���|
            status = GetHisTotalDayMonthlyAccRecPayProc(enterpriseCode, sectionCode, out retPrevTotalDay[0], 0);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // ���|
            status = GetHisTotalDayMonthlyAccRecPayProc(enterpriseCode, sectionCode, out retPrevTotalDay[1], 1);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            //--------------------------------------
            // ���|�������Ɣ��|���������r�i�����������̗p�j
            //--------------------------------------
            if (retPrevTotalDay[0] >= retPrevTotalDay[1])
            {
                // ���|�����|�@���@���|��Ԃ�
                prevTotalDay = retPrevTotalDay[1];

            }
            else
            {
                // ���|�����|�@���@���|��Ԃ�
                prevTotalDay = retPrevTotalDay[0];
            }
            return status;
        }

        /// <summary>
        /// �����擾�����i�����E�������|�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode"></param>
        /// <param name="prevTotalDay"></param>
        /// <param name="procDiv"></param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �ŏI�����X�V�����擾���܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private int GetHisTotalDayMonthlyAccRecPayProc(string enterpriseCode, string sectionCode, out DateTime prevTotalDay, int procDiv)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            TtlDayCalcRetWork retWork;

            # region [���������[�g���o]
            // �����p�����[�^����
            TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
            paraWork.EnterpriseCode = enterpriseCode;
            paraWork.SectionCode = sectionCode;
            paraWork.WithMasterDiv = 1;
            paraWork.ProcDiv = procDiv;

            // �����[�g�Ăяo��
            object retObj;
            status = ttlDayCalcDB.SearchHisMonthly(out retObj, paraWork);
            # endregion

            CustomSerializeArrayList customSerializeArrayList = (retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList;
            // �S���_�̑O���������
            DateTime allSectionPrevDate = DateTime.MinValue;
            for (int index = 0; index < customSerializeArrayList.Count; index++)
            {
                retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);
                prevTotalDay = GetDateTime(retWork.TotalDay);
                // �S�Ќ���(�S���_�ň�ԑ傫���l���g�p)
                if (allSectionPrevDate < prevTotalDay)
                {
                    allSectionPrevDate = prevTotalDay;
                }
            }
            prevTotalDay = allSectionPrevDate;
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }


        /// <summary>
        /// DateTime�擾����(yyyymmdd �� yyyy/mm/dd)
        /// </summary>
        /// <param name="longDate"></param>
        /// <returns></returns>
        private static DateTime GetDateTime(int longDate)
        {
            if (longDate == 0)
            {
                return DateTime.MinValue;
            }
            else
            {
                try
                {
                    return new DateTime(longDate / 10000, (longDate / 100) % 100, longDate % 100);
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }

        private double GetListPriceFl2(int makerCode, string goodsNo, DateTime targetDate, Dictionary<string, List<GoodsPriceUWork>> dicPriceList)
        {
            double listPriceFl = 0;

            string keyStr = goodsNo + "," + makerCode.ToString();
            List<GoodsPriceUWork> goodsPriceUWorkList = new List<GoodsPriceUWork>();

            if (dicPriceList.ContainsKey(keyStr))
            {
                foreach (GoodsPriceUWork work in dicPriceList[keyStr])
                {
                    GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
                    goodsPriceUWork.ListPrice = work.ListPrice;
                    goodsPriceUWork.PriceStartDate = work.PriceStartDate;
                    goodsPriceUWorkList.Add(goodsPriceUWork);
                }
                GoodsPriceUWork retGoodsPriceUWork = this.GetGoodsPriceFromGoodsPriceUWorkList(targetDate, goodsPriceUWorkList);

                if (retGoodsPriceUWork != null)
                {
                    listPriceFl = retGoodsPriceUWork.ListPrice;
                }
            }
            else
            {
                listPriceFl = 0;
            }

            return listPriceFl;
        }

        /// <summary>
        /// �w��������Y�����i���f�[�^�I�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="targetDateTime"></param>
        /// <param name="goodsPriceUWorkList"></param>
        /// <returns></returns>
        private GoodsPriceUWork GetGoodsPriceFromGoodsPriceUWorkList(DateTime targetDateTime, List<GoodsPriceUWork> goodsPriceUWorkList)
        {
            // --- DEL �� K2015/09/09 Redmine#46790 �݌ɒ������׃f�[�^�̒艿�Z�b�g�s���̑Ή� ----->>>>>
            //if ((goodsPriceUWorkList != null) && (goodsPriceUWorkList.Count != 0))
            //{
            //    foreach (GoodsPriceUWork goodsPriceUWork in goodsPriceUWorkList)
            //    {
            //        if (goodsPriceUWork.PriceStartDate != DateTime.MinValue)
            //        {
            //            if (goodsPriceUWork.PriceStartDate <= targetDateTime)
            //            {
            //                return goodsPriceUWork;
            //            }
            //        }
            //    }
            //}
            // --- DEL �� K2015/09/09 Redmine#46790 �݌ɒ������׃f�[�^�̒艿�Z�b�g�s���̑Ή� -----<<<<<
            // --- ADD �� K2015/09/09 Redmine#46790 �݌ɒ������׃f�[�^�̒艿�Z�b�g�s���̑Ή� ----->>>>>
            DateTime priceStartDateFirst = DateTime.MinValue;
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
            if ((goodsPriceUWorkList != null) && (goodsPriceUWorkList.Count != 0))
            {
                for (int i = 0; i < goodsPriceUWorkList.Count; i++)
                {
                    if (goodsPriceUWorkList[i].PriceStartDate > priceStartDateFirst && goodsPriceUWorkList[i].PriceStartDate <= targetDateTime)
                    {
                        priceStartDateFirst = goodsPriceUWorkList[i].PriceStartDate;
                        goodsPriceUWork = goodsPriceUWorkList[i];
                    }
                }
                return goodsPriceUWork;
            }
            // --- ADD �� K2015/09/09 Redmine#46790 �݌ɒ������׃f�[�^�̒艿�Z�b�g�s���̑Ή� -----<<<<<
            return null;
        }

        /// <summary>
        /// �݌Ƀ}�X�^�N���X��������
        /// </summary>
        /// <param name="data">�I���X�V�f�[�^���[�N�N���X</param>
        /// <param name="stockDictionary">�݌Ƀ}�X�^Dictionary</param>
        /// <param name="warehouseDic">�q�ɃR�[�h�Ɩ���</param>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�N���X�𐶐����܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private void CreateStock(InventoryDataUpdateWork data, ref Dictionary<string, StockWork> stockDictionary, object warehouseDic)
        {
            string stockKey = CreateStockKey(data);

            bool isNew = false;
            StockWork workData = null;
            if (stockDictionary.ContainsKey(stockKey))
            {
                workData = stockDictionary[stockKey];
            }
            else
            {
                workData = new StockWork();
                isNew = true;
            }

            // ��ƃR�[�h
            workData.EnterpriseCode = data.EnterpriseCode;
            // �_���폜�敪
            workData.LogicalDeleteCode = 0;
            // ���_�R�[�h
            workData.SectionCode = data.SectionCode;
            // ���[�J�[�R�[�h
            workData.GoodsMakerCd = data.GoodsMakerCd;
            // �i��
            workData.GoodsNo = data.GoodsNo;
            // �d���P��
            workData.StockUnitPriceFl = data.StockUnitPriceFl;
            // �d���݌ɐ�
            workData.SupplierStock = data.InventoryTolerancCnt;
            // �o�׉\��
            workData.ShipmentPosCnt = workData.SupplierStock;

            if (data.InventoryTolerancCnt < 0)
            {
                Int64 longint;
                Int64.TryParse(data.StockUnitPriceFl.ToString(), out longint);
                // �o�ɕۗL���z
                workData.StockTotalPrice = workData.StockTotalPrice - longint;
            }
            else if (data.InventoryTolerancCnt > 0)
            {
                Int64 longint;
                Int64.TryParse(data.StockUnitPriceFl.ToString(), out longint);
                // �o�ɕۗL���z
                workData.StockTotalPrice = workData.StockTotalPrice + longint;
            }
            if (data.InventoryNewDiv == 1)
            {
                if (workData.LastStockDate < data.LastStockDate)
                {
                    // �ŏI�d���N����
                    workData.LastStockDate = data.LastStockDate;
                }
            }
            else
            {
                if (workData.LastStockDate < data.LastStockDate)
                {
                    // �ŏI�d���N����
                    workData.LastStockDate = data.LastStockDate;
                }
            }
            // �ŏI�I���X�V��
            workData.LastInventoryUpdate = data.InventoryDay;
            // �q�ɃR�[�h
            workData.WarehouseCode = data.WarehouseCode.TrimEnd();
            // �q�ɖ�
            workData.WarehouseName = GetWarehouseName(data.WarehouseCode.Trim(), warehouseDic);
            // �n�C�t�������i�ԍ�
            workData.GoodsNoNoneHyphen = "";
            // �q�ɒI��
            workData.WarehouseShelfNo = data.WarehouseShelfNo;
            // �d���I��1
            workData.DuplicationShelfNo1 = data.DuplicationShelfNo1;
            // �d���I��2
            workData.DuplicationShelfNo2 = data.DuplicationShelfNo2;
            // �݌ɓo�^��
            workData.StockCreateDate = DateTime.Today;
            // �X�V�N����
            workData.UpdateDate = DateTime.Today;
            if (isNew)
            {
                stockDictionary.Add(stockKey, workData);
            }
        }

        /// <summary>
        /// �݌ɏ��L�[�����񐶐�����
        /// </summary>
        /// <param name="data">�I���X�V�f�[�^���[�N�N���X</param>
        /// <returns>�݌ɏ��L�[������</returns>
        /// <remarks>
        /// <br>Note       : �݌ɏ��L�[������𐶐����܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private string CreateStockKey(InventoryDataUpdateWork data)
        {
            return data.SectionCode.Trim() + data.GoodsMakerCd + "-" + data.GoodsNo.Trim();
        }
        // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� -----<<<<<

        /// <summary>
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂��B(�ϑ���[�p)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="warehouseList">�V�F�A�`�F�b�N�p�q�Ƀ��X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int WriteEntrust(ref object stockAdjustWork, out string retMsg, ref object warehouseList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            retMsg = string.Empty;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = this.WriteEntrust(ref stockAdjustWork, ref warehouseList, out retMsg, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "StockAdjustDB.Write(ref object stockAdjustWork)");
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
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂��B(�ϑ���[�p)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="warehouseList">�V�F�A�`�F�b�N�p�q�Ƀ��X�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int WriteEntrust(ref object stockAdjustWork, ref object warehouseList, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlEncryptInfo sqlEncryptInfo = null;
            int stockAdjustSlipNo = 0;
            retMsg = "";
            string retItemInfo = "";

            ArrayList stockAdjustWorkList = null;       //�݌ɒ����f�[�^���X�g
            ArrayList stockAdjustDtlWorkList = null;    //�݌ɒ������׃f�[�^���X�g
            ArrayList bfstockAdjustDtlWorkList = null;  //�݌ɒ������׃f�[�^���X�g(�O��l)
            ArrayList stockAcPayHistWorkList = null;    //�݌Ɏ󕥗������X�g

            string resNm = "";

            if (stockAdjustWork == null) return status;

            CustomSerializeArrayList stockAdjustCsList = stockAdjustWork as CustomSerializeArrayList;
            //ArrayList wList = ListUtils.Find(stockAdjustCsList, typeof(string), ListUtils.FindType.Array) as ArrayList;
            CustomSerializeArrayList wList = warehouseList as CustomSerializeArrayList;
            if (wList == null) wList = new CustomSerializeArrayList();

            ArrayList infoList = new ArrayList();

            // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            CustomSerializeArrayList letList = stockAdjustWork as CustomSerializeArrayList;
            ArrayList paramList1 = new ArrayList();
            paramList1 = letList[0] as ArrayList;
            ArrayList rockList1 = ListUtils.Find(paramList1, typeof(StockAdjustDtlWork), ListUtils.FindType.Array) as ArrayList;
            StockAdjustDtlWork _stockMoveWork1 = rockList1[0] as StockAdjustDtlWork;

            foreach (string whouse in wList)
            {
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(_stockMoveWork1.EnterpriseCode, ShareCheckType.WareHouse, "", whouse);
                status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

                if (status != 0) return status;
                infoList.Add(info);
            }
            // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            try
            {
                foreach (CustomSerializeArrayList paraList in stockAdjustCsList)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                    ArrayList stockWorkList = new ArrayList();             //�݌Ƀ��X�g

                    //���X�g����K�v�ȏ����擾
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        ArrayList wkal = paraList[i] as ArrayList;
                        if (wkal != null)
                        {
                            if (wkal.Count > 0)
                            {
                                //�݌ɒ����f�[�^�̏ꍇ
                                if (wkal[0] is StockAdjustWork)
                                {
                                    stockAdjustWorkList = wkal;
                                }
                                //�݌ɒ������׃f�[�^�̏ꍇ
                                else if (wkal[0] is StockAdjustDtlWork)
                                {
                                    stockAdjustDtlWorkList = wkal;
                                }
                            }
                        }
                        else
                        {
                            wkal = new ArrayList();
                        }
                    }

                    StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;

                    if (resNm == "")
                    {
                        //�݌Ɏd���ł`�o���b�N
                        resNm = GetResourceName(wkStockAdjustWork.EnterpriseCode);

                        //�`�o���b�N
                        status = Lock(resNm, sqlConnection, sqlTransaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                            {
                                retMsg = "���b�N�^�C���A�E�g���������܂����B";
                            }
                            else
                            {
                                retMsg = "�r�����b�N�Ɏ��s���܂����B";
                            }

                            return status;
                        }
                    }

                    //---�݌ɒ����`�[�ԍ��̔�---
                    if (wkStockAdjustWork.StockAdjustSlipNo == 0)
                    {
                        status = CreateStockAdjustSlipNo(wkStockAdjustWork.EnterpriseCode, wkStockAdjustWork.SectionCode, out stockAdjustSlipNo, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                        wkStockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
                    }
                    else
                    {
                        stockAdjustSlipNo = wkStockAdjustWork.StockAdjustSlipNo;
                        //�O��l�擾
                        status = SearchStockAdjustDtlProc(out bfstockAdjustDtlWorkList, wkStockAdjustWork, ref sqlConnection, ref sqlTransaction);
                    }

                    //write���s
                    //�݌ɒ����f�[�^�X�V
                    if (stockAdjustWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteStockAdjustProc(ref stockAdjustWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�݌ɒ����f�[�^�̍X�V�Ɏ��s���܂����B";
                    }

                    //�݌ɒ������׃f�[�^�X�V
                    if (stockAdjustDtlWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteDelInsStockAdjustDtlProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�݌ɒ������׃f�[�^�̍X�V�Ɏ��s���܂����B";
                    }

                    //�݌Ɍn�f�[�^�쐬���� (�݌Ɏ󕥗����f�[�^�쐬)
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        TransStockData(true, (int)ct_WriteMode.Write, bfstockAdjustDtlWorkList, ref stockAdjustWorkList, ref stockAdjustDtlWorkList, out stockAcPayHistWorkList, ref stockWorkList, (int)ct_ProcMode.Adjust, ref sqlConnection, ref sqlTransaction);
                    }

                    //�݌Ƀf�[�^�X�V
                    if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList tempparaList = new CustomSerializeArrayList();
                        tempparaList.Add(stockWorkList);
                        tempparaList.Add(stockAcPayHistWorkList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        int shelfNoUpdateDiv = 1;  //1:�I�ԍX�V���Ȃ��i�I�ԍX�V�͒I���p�j

                        status = _stockDB.WriteForStockAdjust(origin, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockAdjustDB.WriteEntrust(ref object stockAdjustWork)");
            }
            finally
            {
                //�`�o�A�����b�N
                if (resNm != "")
                {
                    Release(resNm, sqlConnection, sqlTransaction);
                }

                // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (status == 0 || status == 4)
                {
                    foreach (ShareCheckInfo info2 in infoList)
                    {
                        status = this.ShareCheck(info2, LockControl.Release, sqlConnection, sqlTransaction);
                    }
                }
                // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }

            return status;
        }
        
        /// <summary>
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAdjustWorkList">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int WriteStockAdjustProc(ref ArrayList stockAdjustWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteStockAdjustProcProc(ref stockAdjustWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAdjustWorkList">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        private int WriteStockAdjustProcProc(ref ArrayList stockAdjustWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (stockAdjustWorkList != null)
                {
                    for (int i = 0; i < stockAdjustWorkList.Count; i++)
                    {
                        StockAdjustWork stockadjustWork = stockAdjustWorkList[i] as StockAdjustWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != stockadjustWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (stockadjustWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE STOCKADJUSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , STOCKADJUSTSLIPNORF=@STOCKADJUSTSLIPNO , ACPAYSLIPCDRF=@ACPAYSLIPCD , ACPAYTRANSCDRF=@ACPAYTRANSCD , ADJUSTDATERF=@ADJUSTDATE , INPUTDAYRF=@INPUTDAY , STOCKSECTIONCDRF=@STOCKSECTIONCD , STOCKINPUTCODERF=@STOCKINPUTCODE , STOCKINPUTNAMERF=@STOCKINPUTNAME , STOCKAGENTCODERF=@STOCKAGENTCODE , STOCKAGENTNAMERF=@STOCKAGENTNAME , STOCKSUBTTLPRICERF=@STOCKSUBTTLPRICE , SLIPNOTERF=@SLIPNOTE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                            findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (stockadjustWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = "INSERT INTO STOCKADJUSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @STOCKADJUSTSLIPNO, @ACPAYSLIPCD, @ACPAYTRANSCD, @ADJUSTDATE, @INPUTDAY, @STOCKSECTIONCD, @STOCKINPUTCODE, @STOCKINPUTNAME, @STOCKAGENTCODE, @STOCKAGENTNAME, @STOCKSUBTTLPRICE, @SLIPNOTE)";
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustWork;
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
                        SqlParameter paraStockAdjustSlipNo = sqlCommand.Parameters.Add("@STOCKADJUSTSLIPNO", SqlDbType.Int);
                        SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                        SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                        SqlParameter paraAdjustDate = sqlCommand.Parameters.Add("@ADJUSTDATE", SqlDbType.Int);
                        SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                        SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@STOCKSECTIONCD", SqlDbType.NChar);
                        SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@STOCKINPUTCODE", SqlDbType.NChar);
                        SqlParameter paraStockInputName = sqlCommand.Parameters.Add("@STOCKINPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                        SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);
                        SqlParameter paraStockSubttlPrice = sqlCommand.Parameters.Add("@STOCKSUBTTLPRICE", SqlDbType.BigInt);
                        SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@SLIPNOTE", SqlDbType.NVarChar);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockadjustWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockadjustWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockadjustWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.SectionCode);
                        paraStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);
                        paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.AcPaySlipCd);
                        paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.AcPayTransCd);
                        paraAdjustDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockadjustWork.AdjustDate);
                        paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockadjustWork.InputDay);
                        paraStockSectionCd.Value = SqlDataMediator.SqlSetString(stockadjustWork.StockSectionCd);
                        paraStockInputCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.StockInputCode);
                        // �C�� 2009/07/30 >>>
                        if (stockadjustWork.StockInputName.Length > 16)
                        {
                            // 16���Ő؂�̂�
                            stockadjustWork.StockInputName = stockadjustWork.StockInputName.Substring(0, 16);
                        }
                        // �C�� 2009/07/30 <<<
                        paraStockInputName.Value = SqlDataMediator.SqlSetString(stockadjustWork.StockInputName);
                        paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.StockAgentCode);
                        // �C�� 2009/07/30 >>>
                        if (stockadjustWork.StockAgentName.Length > 16)
                        {
                            // 16���Ő؂�̂�
                            stockadjustWork.StockAgentName = stockadjustWork.StockAgentName.Substring(0, 16);
                        }
                        // �C�� 2009/07/30 <<<
                        paraStockAgentName.Value = SqlDataMediator.SqlSetString(stockadjustWork.StockAgentName);
                        paraStockSubttlPrice.Value = SqlDataMediator.SqlSetInt64(stockadjustWork.StockSubttlPrice);
                        paraSlipNote.Value = SqlDataMediator.SqlSetString(stockadjustWork.SlipNote);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockadjustWork);
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
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockAdjustWorkList = al;

            return status;
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAdjustSlipNo">�݌ɒ����`�[�ԍ�</param>
        /// <param name="stockAdjustDtlWorkList">StockAdjustDtlWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ������׃f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int WriteStockAdjustDtlProc(int stockAdjustSlipNo, ref ArrayList stockAdjustDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteStockAdjustDtlProcProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAdjustSlipNo">�݌ɒ����`�[�ԍ�</param>
        /// <param name="stockAdjustDtlWorkList">StockAdjustDtlWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ������׃f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        private int WriteStockAdjustDtlProcProc(int stockAdjustSlipNo, ref ArrayList stockAdjustDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (stockAdjustDtlWorkList != null)
                {
                    for (int i = 0; i < stockAdjustDtlWorkList.Count; i++)
                    {
                        StockAdjustDtlWork stockadjustdtlWork = stockAdjustDtlWorkList[i] as StockAdjustDtlWork;

                        //�݌ɒ����`�[�ԍ��� 0 �̏ꍇ
                        if (stockadjustdtlWork.StockAdjustSlipNo == 0)
                            stockadjustdtlWork.StockAdjustSlipNo = stockAdjustSlipNo;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);
                        SqlParameter findParaStockAdjustRowNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTROWNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                        findParaStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != stockadjustdtlWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (stockadjustdtlWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE STOCKADJUSTDTLRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , STOCKADJUSTSLIPNORF=@STOCKADJUSTSLIPNO , STOCKADJUSTROWNORF=@STOCKADJUSTROWNO , SUPPLIERFORMALSRCRF=@SUPPLIERFORMALSRC , STOCKSLIPDTLNUMSRCRF=@STOCKSLIPDTLNUMSRC , ACPAYSLIPCDRF=@ACPAYSLIPCD , ACPAYTRANSCDRF=@ACPAYTRANSCD , ADJUSTDATERF=@ADJUSTDATE , INPUTDAYRF=@INPUTDAY , GOODSMAKERCDRF=@GOODSMAKERCD , MAKERNAMERF=@MAKERNAME , GOODSNORF=@GOODSNO , GOODSNAMERF=@GOODSNAME , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL , BFSTOCKUNITPRICEFLRF=@BFSTOCKUNITPRICEFL , ADJUSTCOUNTRF=@ADJUSTCOUNT , DTLNOTERF=@DTLNOTE , WAREHOUSECODERF=@WAREHOUSECODE , WAREHOUSENAMERF=@WAREHOUSENAME , BLGOODSCODERF=@BLGOODSCODE , BLGOODSFULLNAMERF=@BLGOODSFULLNAME , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO , LISTPRICEFLRF=@LISTPRICEFL , OPENPRICEDIVRF=@OPENPRICEDIV , STOCKPRICETAXEXCRF=@STOCKPRICETAXEXC WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                            findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                            findParaStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustdtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (stockadjustdtlWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = "INSERT INTO STOCKADJUSTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @STOCKADJUSTSLIPNO, @STOCKADJUSTROWNO, @SUPPLIERFORMALSRC, @STOCKSLIPDTLNUMSRC, @ACPAYSLIPCD, @ACPAYTRANSCD, @ADJUSTDATE, @INPUTDAY, @GOODSMAKERCD, @MAKERNAME, @GOODSNO, @GOODSNAME, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @ADJUSTCOUNT, @DTLNOTE, @WAREHOUSECODE, @WAREHOUSENAME, @BLGOODSCODE, @BLGOODSFULLNAME, @WAREHOUSESHELFNO, @LISTPRICEFL, @OPENPRICEDIV, @STOCKPRICETAXEXC)";
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustdtlWork;
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
                        SqlParameter paraStockAdjustSlipNo = sqlCommand.Parameters.Add("@STOCKADJUSTSLIPNO", SqlDbType.Int);
                        SqlParameter paraStockAdjustRowNo = sqlCommand.Parameters.Add("@STOCKADJUSTROWNO", SqlDbType.Int);
                        SqlParameter paraSupplierFormalSrc = sqlCommand.Parameters.Add("@SUPPLIERFORMALSRC", SqlDbType.Int);
                        SqlParameter paraStockSlipDtlNumSrc = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSRC", SqlDbType.BigInt);
                        SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                        SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                        SqlParameter paraAdjustDate = sqlCommand.Parameters.Add("@ADJUSTDATE", SqlDbType.Int);
                        SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraAdjustCount = sqlCommand.Parameters.Add("@ADJUSTCOUNT", SqlDbType.Float);
                        SqlParameter paraDtlNote = sqlCommand.Parameters.Add("@DTLNOTE", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float);
                        SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                        SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustdtlWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustdtlWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockadjustdtlWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.SectionCode);
                        paraStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                        paraStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);
                        paraSupplierFormalSrc.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.SupplierFormalSrc);
                        paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(stockadjustdtlWork.StockSlipDtlNumSrc);
                        paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.AcPaySlipCd);
                        paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.AcPayTransCd);
                        paraAdjustDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockadjustdtlWork.AdjustDate);
                        paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockadjustdtlWork.InputDay);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.GoodsMakerCd);
                        paraMakerName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.MakerName);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.GoodsNo);
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.GoodsName);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.StockUnitPriceFl);
                        paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.BfStockUnitPriceFl);
                        paraAdjustCount.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.AdjustCount);
                        paraDtlNote.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.DtlNote);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.WarehouseCode);
                        paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.WarehouseName);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.BLGoodsCode);
                        paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.BLGoodsFullName);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.WarehouseShelfNo);
                        paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.ListPriceFl);
                        paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.OpenPriceDiv);
                        paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(stockadjustdtlWork.StockPriceTaxExc);
                        #endregion  // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockadjustdtlWork);
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
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockAdjustDtlWorkList = al;

            return status;
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAdjustSlipNo">�݌ɒ����`�[�ԍ�</param>
        /// <param name="stockAdjustDtlWorkList">StockAdjustDtlWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ������׃f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int WriteDelInsStockAdjustDtlProc(int stockAdjustSlipNo, ref ArrayList stockAdjustDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteDelInsStockAdjustDtlProcProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAdjustSlipNo">�݌ɒ����`�[�ԍ�</param>
        /// <param name="stockAdjustDtlWorkList">StockAdjustDtlWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ������׃f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        private int WriteDelInsStockAdjustDtlProcProc(int stockAdjustSlipNo, ref ArrayList stockAdjustDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (stockAdjustDtlWorkList != null)
                {
                    if (stockAdjustDtlWorkList.Count > 0)
                    {
                        StockAdjustDtlWork stockadjustdtlWork = stockAdjustDtlWorkList[0] as StockAdjustDtlWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("DELETE FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO ", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockAdjustSlipNo);

                        sqlCommand.ExecuteNonQuery();

                        for (int i = 0; i < stockAdjustDtlWorkList.Count; i++)
                        {
                            stockadjustdtlWork = stockAdjustDtlWorkList[i] as StockAdjustDtlWork;

                            //�݌ɒ����`�[�ԍ��� 0 �̏ꍇ
                            if (stockadjustdtlWork.StockAdjustSlipNo == 0)
                                stockadjustdtlWork.StockAdjustSlipNo = stockAdjustSlipNo;

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand = new SqlCommand("INSERT INTO STOCKADJUSTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @STOCKADJUSTSLIPNO, @STOCKADJUSTROWNO, @SUPPLIERFORMALSRC, @STOCKSLIPDTLNUMSRC, @ACPAYSLIPCD, @ACPAYTRANSCD, @ADJUSTDATE, @INPUTDAY, @GOODSMAKERCD, @MAKERNAME, @GOODSNO, @GOODSNAME, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @ADJUSTCOUNT, @DTLNOTE, @WAREHOUSECODE, @WAREHOUSENAME, @BLGOODSCODE, @BLGOODSFULLNAME, @WAREHOUSESHELFNO, @LISTPRICEFL, @OPENPRICEDIV, @STOCKPRICETAXEXC)", sqlConnection, sqlTransaction);
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustdtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

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
                            SqlParameter paraStockAdjustSlipNo = sqlCommand.Parameters.Add("@STOCKADJUSTSLIPNO", SqlDbType.Int);
                            SqlParameter paraStockAdjustRowNo = sqlCommand.Parameters.Add("@STOCKADJUSTROWNO", SqlDbType.Int);
                            SqlParameter paraSupplierFormalSrc = sqlCommand.Parameters.Add("@SUPPLIERFORMALSRC", SqlDbType.Int);
                            SqlParameter paraStockSlipDtlNumSrc = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSRC", SqlDbType.BigInt);
                            SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                            SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                            SqlParameter paraAdjustDate = sqlCommand.Parameters.Add("@ADJUSTDATE", SqlDbType.Int);
                            SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                            SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                            SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                            SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                            SqlParameter paraAdjustCount = sqlCommand.Parameters.Add("@ADJUSTCOUNT", SqlDbType.Float);
                            SqlParameter paraDtlNote = sqlCommand.Parameters.Add("@DTLNOTE", SqlDbType.NVarChar);
                            SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                            SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                            SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                            SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                            SqlParameter paraListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float);
                            SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                            SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);
                            #endregion  // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)

                            #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustdtlWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustdtlWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockadjustdtlWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.LogicalDeleteCode);
                            paraSectionCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.SectionCode);
                            paraStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                            paraStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);
                            paraSupplierFormalSrc.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.SupplierFormalSrc);
                            paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(stockadjustdtlWork.StockSlipDtlNumSrc);
                            paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.AcPaySlipCd);
                            paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.AcPayTransCd);
                            paraAdjustDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockadjustdtlWork.AdjustDate);
                            paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockadjustdtlWork.InputDay);
                            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.GoodsMakerCd);
                            paraMakerName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.MakerName);
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.GoodsNo);
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.GoodsName);
                            paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.StockUnitPriceFl);
                            paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.BfStockUnitPriceFl);
                            paraAdjustCount.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.AdjustCount);
                            paraDtlNote.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.DtlNote);
                            paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.WarehouseCode);
                            paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.WarehouseName);
                            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.BLGoodsCode);
                            paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.BLGoodsFullName);
                            paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.WarehouseShelfNo);
                            paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.ListPriceFl);
                            paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.OpenPriceDiv);
                            paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(stockadjustdtlWork.StockPriceTaxExc);
                            #endregion // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

                            sqlCommand.ExecuteNonQuery();
                            al.Add(stockadjustdtlWork);
                        }
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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockAdjustDtlWorkList = al;

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �݌ɒ����f�[�^����_���폜���܂�
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����_���폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int LogicalDelete(ref object stockAdjustWork)
        {
            return LogicalDeleteStockAdjust(ref stockAdjustWork, 0);
        }

        /// <summary>
        /// �_���폜�݌ɒ����f�[�^���𕜊����܂�
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�݌ɒ����f�[�^���𕜊����܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int RevivalLogicalDelete(ref object stockAdjustWork)
        {
            return LogicalDeleteStockAdjust(ref stockAdjustWork, 1);
        }

        /// <summary>
        /// �݌ɒ����f�[�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        private int LogicalDeleteStockAdjust(ref object stockAdjustWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(stockAdjustWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteStockAdjustProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "StockAdjustDB.LogicalDeleteStockAdjust :" + procModestr);

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
        /// �݌ɒ����f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAdjustWorkList">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int LogicalDeleteStockAdjustProc(ref ArrayList stockAdjustWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteStockAdjustProcProc(ref stockAdjustWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɒ����f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAdjustWorkList">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        private int LogicalDeleteStockAdjustProcProc(ref ArrayList stockAdjustWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (stockAdjustWorkList != null)
                {
                    for (int i = 0; i < stockAdjustWorkList.Count; i++)
                    {
                        StockAdjustWork stockadjustWork = stockAdjustWorkList[i] as StockAdjustWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != stockadjustWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE STOCKADJUSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                            findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustWork;
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
                            else if (logicalDelCd == 0) stockadjustWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else stockadjustWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) stockadjustWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockadjustWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockadjustWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockadjustWork);
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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockAdjustWorkList = al;

            return status;

        }

        /// <summary>
        /// �݌ɒ������׃f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAdjustDtlWorkList">StockAdjustDtlWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ������׃f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int LogicalDeleteStockAdjustDtlProc(ref ArrayList stockAdjustDtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteStockAdjustDtlProcProc(ref stockAdjustDtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAdjustDtlWorkList">StockAdjustDtlWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ������׃f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        private int LogicalDeleteStockAdjustDtlProcProc(ref ArrayList stockAdjustDtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (stockAdjustDtlWorkList != null)
                {
                    for (int i = 0; i < stockAdjustDtlWorkList.Count; i++)
                    {
                        StockAdjustDtlWork stockadjustdtlWork = stockAdjustDtlWorkList[i] as StockAdjustDtlWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);
                        SqlParameter findParaStockAdjustRowNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTROWNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                        findParaStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != stockadjustdtlWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE STOCKADJUSTDTLRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                            findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                            findParaStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustdtlWork;
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
                            else if (logicalDelCd == 0) stockadjustdtlWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else stockadjustdtlWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) stockadjustdtlWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustdtlWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockadjustdtlWork);
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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockAdjustDtlWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂��B(�݌ɒ������͗p)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int Delete(ref object stockAdjustWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;
            retMsg = "";
            string retItemInfo = "";


            ArrayList stockAdjustWorkList = null;       //�݌ɒ����f�[�^���X�g
            ArrayList stockAdjustDtlWorkList = null;    //�݌ɒ������׃f�[�^���X�g
            ArrayList bfstockAdjustDtlWorkList = null;  //�݌ɒ������׃f�[�^���X�g(�O��l)
            ArrayList stockWorkList = new ArrayList();             //�݌Ƀ��X�g
            ArrayList stockAcPayHistWorkList = null;    //�݌Ɏ󕥗������X�g

            string resNm = "";

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //�p�����[�^�̃L���X�g
                CustomSerializeArrayList paraList = stockAdjustWork as CustomSerializeArrayList;
                if (paraList == null) return status;

                //���X�g����K�v�ȏ����擾
                for (int i = 0; i < paraList.Count; i++)
                {
                    ArrayList wkal = paraList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //�݌ɒ����f�[�^�̏ꍇ
                            if (wkal[0] is StockAdjustWork)
                            {
                                stockAdjustWorkList = wkal;
                            }
                            //�݌ɒ������׃f�[�^�̏ꍇ
                            else if (wkal[0] is StockAdjustDtlWork)
                            {
                                stockAdjustDtlWorkList = wkal;
                            }
                        }
                    }
                }

                StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;

                resNm = GetResourceName(wkStockAdjustWork.EnterpriseCode);
                //�`�o���b�N
                status = Lock(resNm, sqlConnection, sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                    }

                    return status;
                }

                try
                {
                    //---�݌ɒ����`�[�ԍ��̔�---
                    //�O��l�擾
                    status = SearchStockAdjustDtlProc(out bfstockAdjustDtlWorkList, wkStockAdjustWork, ref sqlConnection, ref sqlTransaction);

                    //�����v��̃`�F�b�N True:�����v��
                    bool uoeflg = CheckSendAddUp(bfstockAdjustDtlWorkList);

                    //�����f�[�^�X�V
                    if (uoeflg && bfstockAdjustDtlWorkList != null)
                    {
                        StockSlipDB stockSlipDB = new StockSlipDB();
                        ArrayList parastockDetailList = CopyToParaStockDetailFromStockAdjustDtl(bfstockAdjustDtlWorkList, null, (int)ct_WriteMode.Delete);

                        //�d�������[�g�̔����v�チ�\�b�h�̌Ăяo��
                        status = stockSlipDB.UpdateOrderRemainCnt(new StockSlipWork(), parastockDetailList, 0, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    }

                    //write���s
                    //�݌ɒ����f�[�^�폜
                    if (stockAdjustWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = LogicalDeleteStockAdjustProc(ref stockAdjustWorkList, 0, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�݌ɒ����f�[�^�̍폜�Ɏ��s���܂����B";
                    }

                    //�݌ɒ������׃f�[�^�폜
                    if (stockAdjustDtlWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = LogicalDeleteStockAdjustDtlProc(ref stockAdjustDtlWorkList, 0, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�݌ɒ������׃f�[�^�̍폜�Ɏ��s���܂����B";
                    }

                    //�O��l���X�g������X�V���X�g�̒l�ōX�V
                    for (int i = 0; i < bfstockAdjustDtlWorkList.Count; i++)
                    {
                        //���e�[�u���ɂ͂Ȃ����ڂ̂��߁A�O��l�̃��X�g�ł͎擾�o���Ȃ����ڂ��X�V
                        //�󕥍쐬���Ɏg�p����

                        StockAdjustDtlWork bfwork = bfstockAdjustDtlWorkList[i] as StockAdjustDtlWork;
                        StockAdjustDtlWork work = stockAdjustDtlWorkList[i] as StockAdjustDtlWork;

                        bfwork.SectionGuideNm = work.SectionGuideNm;
                        bfwork.SupplierCd = work.SupplierCd;
                        bfwork.SupplierSnm = work.SupplierSnm;
                    }

                    //�݌Ɍn�f�[�^�쐬���� (�݌Ɏ󕥗����f�[�^�쐬)
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //�폜���͑O��l�Ŏ󕥗������쐬����
                        TransStockData(true, (int)ct_WriteMode.Delete, null, ref stockAdjustWorkList, ref bfstockAdjustDtlWorkList, out stockAcPayHistWorkList, ref stockWorkList, (int)ct_ProcMode.Adjust, ref sqlConnection, ref sqlTransaction);
                    }

                    //�݌Ƀf�[�^�X�V
                    if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList tempparaList = new CustomSerializeArrayList();
                        tempparaList.Add(stockWorkList);
                        tempparaList.Add(stockAcPayHistWorkList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        int shelfNoUpdateDiv = 1;  //1:�I�ԍX�V���Ȃ��i�I�ԍX�V�͒I���p�j

                        status = _stockDB.WriteForStockAdjust(origin, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);
                    }

                    //�߂�l�Z�b�g
                    stockAdjustWork = paraList;
                }
                finally
                {
                    //�`�o�A�����b�N
                    Release(resNm, sqlConnection, sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockAdjustDB.Write(ref object stockAdjustWork)");
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // �R�~�b�g
                        sqlTransaction.Commit();
                    else
                    {
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /*
        /// <summary>
        /// �݌ɒ����f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">�݌ɒ����f�[�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɒ����f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(paraobj);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteStockAdjustProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "StockAdjustDB.Delete");
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
        */

        /// <summary>
        /// �݌ɒ����f�[�^���𕨗��폜���܂�(�O�������SqlConnection AND SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockadjustWorkList">�݌ɒ����f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɒ����f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int DeleteStockAdjustProc(ArrayList stockadjustWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockAdjustProcProc(stockadjustWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɒ����f�[�^���𕨗��폜���܂�(�O�������SqlConnection AND SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockadjustWorkList">�݌ɒ����f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɒ����f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        private int DeleteStockAdjustProcProc(ArrayList stockadjustWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < stockadjustWorkList.Count; i++)
                {
                    StockAdjustWork stockadjustWork = stockadjustWorkList[i] as StockAdjustWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                    findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != stockadjustWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO";
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);
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
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^���𕨗��폜���܂�(�O�������SqlConnection AMD SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockadjustdtlWorkList">�݌ɒ������׃f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɒ������׃f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        public int DeleteStockAdjustDtlProc(ArrayList stockadjustdtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockAdjustDtlProcProc(stockadjustdtlWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^���𕨗��폜���܂�(�O�������SqlConnection AMD SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockadjustdtlWorkList">�݌ɒ������׃f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɒ������׃f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        private int DeleteStockAdjustDtlProcProc(ArrayList stockadjustdtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < stockadjustdtlWorkList.Count; i++)
                {
                    StockAdjustDtlWork stockadjustdtlWork = stockadjustdtlWorkList[i] as StockAdjustDtlWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);
                    SqlParameter findParaStockAdjustRowNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTROWNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                    findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                    findParaStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != stockadjustdtlWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO";
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                        findParaStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);
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
                    if (myReader.IsClosed == false) myReader.Close();
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
        /// <param name="stockAdjustWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockAdjustWork stockAdjustWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockAdjustWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            if (stockAdjustWork.StockAdjustSlipNo != 0)
            {
                retstring += " AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO" + Environment.NewLine;
                SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);
                findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.StockAdjustSlipNo);
            }


            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� StockAdjustWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockAdjustWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        /// </remarks>
        private StockAdjustWork CopyToStockAdjustWorkFromReader(ref SqlDataReader myReader)
        {
            StockAdjustWork wkStockAdjustWork = new StockAdjustWork();

            #region �N���X�֊i�[
            wkStockAdjustWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockAdjustWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockAdjustWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockAdjustWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockAdjustWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockAdjustWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockAdjustWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockAdjustWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockAdjustWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockAdjustWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
            wkStockAdjustWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            wkStockAdjustWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            wkStockAdjustWork.AdjustDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
            wkStockAdjustWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkStockAdjustWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            wkStockAdjustWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            wkStockAdjustWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            wkStockAdjustWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            wkStockAdjustWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            wkStockAdjustWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            wkStockAdjustWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
            #endregion

            return wkStockAdjustWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� StockAdjustDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockAdjustDtlWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        /// </remarks>
        private StockAdjustDtlWork CopyToStockAdjustDtlWorkFromReader(ref SqlDataReader myReader)
        {
            StockAdjustDtlWork wkStockAdjustDtlWork = new StockAdjustDtlWork();

            #region �N���X�֊i�[
            wkStockAdjustDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockAdjustDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockAdjustDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockAdjustDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockAdjustDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockAdjustDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockAdjustDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockAdjustDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockAdjustDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockAdjustDtlWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
            wkStockAdjustDtlWork.StockAdjustRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTROWNORF"));
            wkStockAdjustDtlWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
            wkStockAdjustDtlWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
            wkStockAdjustDtlWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            wkStockAdjustDtlWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            wkStockAdjustDtlWork.AdjustDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
            wkStockAdjustDtlWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkStockAdjustDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockAdjustDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkStockAdjustDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockAdjustDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStockAdjustDtlWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockAdjustDtlWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
            wkStockAdjustDtlWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
            wkStockAdjustDtlWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
            wkStockAdjustDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockAdjustDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkStockAdjustDtlWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkStockAdjustDtlWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkStockAdjustDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStockAdjustDtlWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
            wkStockAdjustDtlWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            wkStockAdjustDtlWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            #endregion  // �N���X�֊i�[

            return wkStockAdjustDtlWork;
        }

        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            StockAdjustWork[] StockAdjustWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is StockAdjustWork)
                    {
                        StockAdjustWork wkStockAdjustWork = paraobj as StockAdjustWork;
                        if (wkStockAdjustWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkStockAdjustWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            StockAdjustWorkArray = (StockAdjustWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockAdjustWork[]));
                        }
                        catch (Exception) { }
                        if (StockAdjustWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(StockAdjustWorkArray);
                        }
                        else
                        {
                            try
                            {
                                StockAdjustWork wkStockAdjustWork = (StockAdjustWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockAdjustWork));
                                if (wkStockAdjustWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockAdjustWork);
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
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
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

        #region �݌ɒ����`�[�ԍ��̔�
        /// <summary>
        /// �݌ɒ����`�[�ԍ����̔Ԃ��ĕԂ��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="stockAdjustSlipNo">�̔Ԍ���</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ��`�[�ԍ����̔Ԃ��ĕԂ��܂�</br>
        /// <br>Programmer : 21015 �����@�F��</br>
        /// <br>Date       : 2007.02.07</br>
        private int CreateStockAdjustSlipNo(string enterpriseCode, string sectionCode, out int stockAdjustSlipNo, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            stockAdjustSlipNo = 0;

            //�߂�l������
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retMsg = null;
            retItemInfo = null;

            NumberingManager numberingManager = new NumberingManager();

            //�ԍ��͈͕����[�v
            Int32 loopCnt = 1;

            while (loopCnt <= 999999999)
            {
                long no;

                //�݌ɒ����`�[�ԍ��͋��_��ˑ������狒�_�R�[�h�͑S��
                status = numberingManager.GetSerialNumber(enterpriseCode, sectionCode, SerialNumberCode.StockAdjustSlipNo,  out no);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    //�ԍ��𐔒l�^�ɕϊ�
                    Int32 tmpStockAdjustSlipNo = System.Convert.ToInt32(no);
                    SqlDataReader myReader = null;

                    //�󂫔ԃ`�F�b�N
                    try
                    {
                        //Select�R�}���h�̐���
                        using (SqlCommand sqlCommand = new SqlCommand("SELECT STOCKADJUSTSLIPNORF FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO ", sqlConnection, sqlTransaction))
                        {

                            //Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                            findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(tmpStockAdjustSlipNo);

                            myReader = sqlCommand.ExecuteReader();
                            //�f�[�^�����̏ꍇ�ɂ͖߂�l���Z�b�g
                            if (!myReader.Read())
                            {
                                stockAdjustSlipNo = tmpStockAdjustSlipNo;
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        retMsg = "�݌ɒ����`�[�ԍ��̔Ԓ��ɃG���[���������܂����B";
                        retItemInfo = "StockAdjustSlipNo";

                        //���N���X�ɗ�O��n���ď������Ă��炤
                        status = base.WriteSQLErrorLog(ex);
                        break;
                    }
                    finally
                    {
                        if (myReader != null)
                        {
                            myReader.Close();
                            myReader.Dispose();
                        }
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
                }
                //�̔Ԃł��Ȃ������ꍇ�ɂ͏������f�B
                else break;

                //����ԍ�������ꍇ�ɂ̓��[�v�J�E���^���C���N�������g���č̔�
                loopCnt++;
            }

            //�S�����[�v���Ă��擾�o���Ȃ��ꍇ
            if (loopCnt == 999999999 && status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                retMsg = "�݌ɒ����`�[�ԍ��ɋ󂫔ԍ�������܂���B�폜�\�ȓ`�[���폜���Ă��������B";
                retItemInfo = "StockAdjustSlipNo";
            }

            //�G���[�ł��X�e�[�^�X�y�у��b�Z�[�W�͂��̂܂ܖ߂�
            return status;
        }
        #endregion

        #region �݌ɒ����f�[�^���݌Ɏ󕥗����f�[�^
        /// <summary>
        /// �݌Ɏ󕥗����f�[�^�쐬����
        /// </summary>
        /// <param name="createStock"></param>
        /// <param name="writeMode"></param>
        /// <param name="bfstockAdjustDtlWorkList"></param>
        /// <param name="stockAdjustList"></param>
        /// <param name="stockAdjustDtlList"></param>
        /// <param name="stockAcPayHistList"></param>
        /// <param name="stockList"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        /// <remarks>DC.NS�ł́A�݌Ɏ󕥗����͂��邪�A�݌Ɏ󕥗����ڍׂ͂Ȃ��B</remarks>
        /// <remarks>�݌Ɏ󕥗����ɖ��׃f�[�^�����悤�ɕύX����Ă���B</remarks>
        private int TransStockData(bool createStock,int writeMode, ArrayList bfstockAdjustDtlWorkList, ref ArrayList stockAdjustList, ref ArrayList stockAdjustDtlList, out ArrayList stockAcPayHistList,ref ArrayList stockList ,int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            stockAcPayHistList = new ArrayList();   //�݌Ɏ󕥗������X�g

            StockAdjustWork stockAdjustWork = stockAdjustList[0] as StockAdjustWork; //�����f�[�^�̃w�b�_�͕K��1���R�[�h�����݂���O��
            StockAdjustDtlWorkComparer stockAdjustDtlWorkComparer = new StockAdjustDtlWorkComparer();

            Dictionary<string, StockWork> stockDic = new Dictionary<string, StockWork>();

            //�݌ɒ������׃��X�g�̃\�[�g
            if (stockAdjustDtlList != null)
            {
                stockAdjustDtlList.Sort(stockAdjustDtlWorkComparer);
            }

            if (bfstockAdjustDtlWorkList != null)
            {
                bfstockAdjustDtlWorkList.Sort(stockAdjustDtlWorkComparer);
            }

            if (stockAdjustDtlList != null)
            {
                for (int i = 0; i < stockAdjustDtlList.Count; i++)
                {

                    //�݌ɒ������׃f�[�^�擾
                    StockAdjustDtlWork stockAdjustDtlWork = stockAdjustDtlList[i] as StockAdjustDtlWork;

                    StockAdjustDtlWork bfstockAdjustDtlWork = null;
                    StockAcPayHistWork stockAcPayHistWork = null;

                    if (bfstockAdjustDtlWorkList != null)
                    {
                        bfstockAdjustDtlWork = bfstockAdjustDtlWorkList[i] as StockAdjustDtlWork;

                        //�C���`�[�̏ꍇ�A���ʁA���z�̍������Z�b�g
                        stockAdjustDtlWork.AdjustCount -= bfstockAdjustDtlWork.AdjustCount;
                        stockAdjustDtlWork.StockPriceTaxExc -= bfstockAdjustDtlWork.StockPriceTaxExc;
                    }

                    //�݌Ɏd�����́A�ϑ���[�̏ꍇ�̓����[�g�ō݌Ƀ��X�g�𐶐�����
                    if (createStock == true)
                    {
                        if (stockDic.ContainsKey(CreateKeyStockString(stockAdjustDtlWork)))
                        {
                            StockWork stockWork = stockDic[CreateKeyStockString(stockAdjustDtlWork)] as StockWork;
                            stockWork = CopyStockWorkFromStockAdjustDtlWork(stockWork, stockAdjustDtlWork, procMode, writeMode);
                        }
                        else
                        {

                            StockWork stockWork = CopyStockWorkFromStockAdjustDtlWork(null, stockAdjustDtlWork, procMode, writeMode);

                            stockDic.Add(CreateKeyStockString(stockAdjustDtlWork), stockWork);
                            stockList.Add(stockWork);
                        }
                    }

                    //�݌Ɏ󕥗����f�[�^
                    if (bfstockAdjustDtlWork == null)
                    {
                        //�O��l�������V�K�쐬
                        stockAcPayHistWork = CopyStockAcPayHisWorkFromStockAdjustWork(stockAdjustWork, stockAdjustDtlWork, procMode, writeMode);
                    }
                    else
                    {
                        if (
                            (stockAdjustDtlWork.AdjustCount != 0) ||
                            (stockAdjustDtlWork.StockPriceTaxExc != 0) ||
                            (stockAdjustDtlWork.ListPriceFl != bfstockAdjustDtlWork.ListPriceFl) ||
                            (stockAdjustDtlWork.StockUnitPriceFl != bfstockAdjustDtlWork.StockUnitPriceFl)
                            )
                        {
                            //�C����
                            //�������A�d�����z�A�艿�A�d���P���A���ה��l�̂����ꂩ�̍��ڂ��ύX���ꂽ�ꍇ�̂ݓo�^����
                            stockAcPayHistWork = CopyStockAcPayHisWorkFromStockAdjustWork(stockAdjustWork, stockAdjustDtlWork, procMode, writeMode);
                        }
                    }

                    //�݌ɒ������ׂ���݌Ɏ󕥗������쐬
                    if (stockAcPayHistWork != null)
                        stockAcPayHistList.Add(stockAcPayHistWork);
                }
            }

            return status;
        }
        #endregion

        #region �݌ɍX�V�p�A�폜�p���X�g�쐬(���i�݌Ƀ}�X�����p)
        /// <summary>
        /// �݌ɍX�V�p�A�폜���X�g�쐬(���i�݌Ƀ}�X�����p)
        /// </summary>
        /// <param name="stockWorkList">�݌Ƀ��X�g</param>
        /// <param name="stockWriteList">�݌ɍX�V�p���X�g</param>
        /// <param name="stockDeleteList">�݌ɍ폜�p���X�g</param>
        /// <returns></returns>
        private int CreateStockWriteDelList(ArrayList stockWorkList, out ArrayList stockWriteList, out ArrayList stockDeleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            stockWriteList = new ArrayList();
            stockDeleteList = new ArrayList();

            foreach (StockWork stockWork in stockWorkList)
            {
                if (stockWork.LogicalDeleteCode == 3)
                {
                    //�폜�p���X�g�쐬
                    stockDeleteList.Add(stockWork);
                }
                else
                {
                    //�X�V�p���X�g�쐬
                    stockWriteList.Add(stockWork);
                }
            }

            return status;
        }
        #endregion

        #region �L�[�p������쐬
        /// <summary>
        /// Key�p������쐬����
        /// </summary>
        /// <param name="stockAdjustDtlWork"></param>
        /// <returns></returns>
        private string CreateKeyStockString(StockAdjustDtlWork stockAdjustDtlWork)
        {
            string retString = "";
            retString =
                stockAdjustDtlWork.EnterpriseCode + "-" +
                stockAdjustDtlWork.WarehouseCode + "-" +
                stockAdjustDtlWork.GoodsMakerCd.ToString("%06d") + "-" +
                stockAdjustDtlWork.GoodsNo;
            return retString;
        }
        #endregion

        #region �N���X�i�[����
        /// <summary>
        /// �݌Ƀf�[�^�E�݌ɒ����f�[�^�E�݌ɒ������׃f�[�^ �� �݌Ɏ󕥗����f�[�^
        /// </summary>
        /// <param name="stockAdjustWork">�݌ɒ����f�[�^</param>
        /// <param name="stockAdjustDtlWork">�݌ɒ������׃f�[�^</param>
        /// <param name="procMode">�������[�h</param>
        /// <param name="writeMode">�X�V���[�h</param>
        /// <returns>�݌Ɏ󕥖���</returns>
        private StockAcPayHistWork CopyStockAcPayHisWorkFromStockAdjustWork(StockAdjustWork stockAdjustWork, StockAdjustDtlWork stockAdjustDtlWork, int procMode, int writeMode)
        {
            StockAcPayHistWork retStockAcPayHistWork = new StockAcPayHistWork();
            int mark = 1;
            if (writeMode == (int)ct_WriteMode.Write)
            {
                mark = 1;
            }
            else
            {
                mark = -1;
            }
                
            #region �i�[����
            //�݌ɒ����f�[�^�A�݌ɒ������׃f�[�^����Z�b�g
            retStockAcPayHistWork.EnterpriseCode = stockAdjustDtlWork.EnterpriseCode;       //��ƃR�[�h

            retStockAcPayHistWork.IoGoodsDay = stockAdjustDtlWork.AdjustDate;               //���o�ד����������t
            retStockAcPayHistWork.AddUpADate = stockAdjustDtlWork.AdjustDate;               //�v����t��������
            retStockAcPayHistWork.AcPaySlipCd = stockAdjustDtlWork.AcPaySlipCd;             //�󕥌��`�[�敪
            retStockAcPayHistWork.AcPaySlipNum = stockAdjustDtlWork.StockAdjustSlipNo.ToString();    //�󕥌��`�[�ԍ����݌ɒ����`�[�ԍ�
            retStockAcPayHistWork.AcPaySlipRowNo = stockAdjustDtlWork.StockAdjustRowNo;     //�󕥌��s�ԍ����݌ɒ����s�ԍ�

            if (writeMode == (int)ct_WriteMode.Delete)
            {
                retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip;           //�󕥌�����敪
            }
            else
            {
                retStockAcPayHistWork.AcPayTransCd = stockAdjustDtlWork.AcPayTransCd;           //�󕥌�����敪
            }

            // 2009/04/09 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //retStockAcPayHistWork.InputSectionCd = stockAdjustWork.StockSectionCd;           //���͋��_�R�[�h
            //retStockAcPayHistWork.InputSectionGuidNm = stockAdjustWork.StockSectionGuideNm;  //���͋��_�K�C�h����
            retStockAcPayHistWork.InputSectionCd = stockAdjustDtlWork.SectionCode;             //���͋��_�R�[�h
            retStockAcPayHistWork.InputSectionGuidNm = stockAdjustDtlWork.SectionGuideNm;      //���͋��_�K�C�h����
            // 2009/04/09 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            retStockAcPayHistWork.InputAgenCd = stockAdjustWork.StockInputCode;                //���͒S���҃R�[�h
            retStockAcPayHistWork.InputAgenNm = stockAdjustWork.StockInputName;                //���͒S���Җ���
            retStockAcPayHistWork.AcPayNote = stockAdjustDtlWork.DtlNote;                   //�󕥔��l = ���ה��l(DtlNote)
            retStockAcPayHistWork.GoodsMakerCd = stockAdjustDtlWork.GoodsMakerCd;           //���[�J�[�R�[�h
            retStockAcPayHistWork.MakerName = stockAdjustDtlWork.MakerName;                 //���[�J�[����
            retStockAcPayHistWork.GoodsNo = stockAdjustDtlWork.GoodsNo;                     //���i�R�[�h
            retStockAcPayHistWork.GoodsName = stockAdjustDtlWork.GoodsName;                 //���i����
            retStockAcPayHistWork.BLGoodsCode = stockAdjustDtlWork.BLGoodsCode;             //BL���i�R�[�h
            retStockAcPayHistWork.BLGoodsFullName = stockAdjustDtlWork.BLGoodsFullName;     //BL���i�R�[�h����(�S�p)
            retStockAcPayHistWork.WarehouseCode = stockAdjustDtlWork.WarehouseCode;         //�q�ɃR�[�h
            retStockAcPayHistWork.WarehouseName = stockAdjustDtlWork.WarehouseName;         //�q�ɖ���
            retStockAcPayHistWork.ShelfNo = stockAdjustDtlWork.WarehouseShelfNo;            //�I��
            // 2009/04/09 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //retStockAcPayHistWork.SectionCode = stockAdjustDtlWork.SectionCode;             //���_�R�[�h
            //retStockAcPayHistWork.SectionGuideNm = stockAdjustDtlWork.SectionGuideNm;       //���_�K�C�h����
            retStockAcPayHistWork.SectionCode = stockAdjustWork.StockSectionCd;               //���_�R�[�h
            retStockAcPayHistWork.SectionGuideNm = stockAdjustWork.StockSectionGuideNm;       //���_�K�C�h����
            // 2009/04/09 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            retStockAcPayHistWork.SupplierCd = stockAdjustDtlWork.SupplierCd;               //�d����R�[�h
            retStockAcPayHistWork.SupplierSnm = stockAdjustDtlWork.SupplierSnm;             //�d���旪��

            //��[�o�ɂ̏ꍇ�͏o�ɂɒl���Z�b�g
            if (retStockAcPayHistWork.AcPaySlipCd == (int)ct_AcPaySlipCd_PM.replaceShip)
            {
                retStockAcPayHistWork.SalesUnPrcTaxExcFl = stockAdjustDtlWork.StockUnitPriceFl;   //����P�� �� �d���P��
                retStockAcPayHistWork.ShipmentCnt = stockAdjustDtlWork.AdjustCount * mark * -1;              //�o�א� �� ������
                retStockAcPayHistWork.SalesMoney = stockAdjustDtlWork.StockPriceTaxExc * mark * -1;         //������z �� �d�����z
            }
            else
            {
                retStockAcPayHistWork.StockUnitPriceFl = stockAdjustDtlWork.StockUnitPriceFl;   //�d���P��
                retStockAcPayHistWork.ArrivalCnt = stockAdjustDtlWork.AdjustCount * mark;              //���א� �� ������
                retStockAcPayHistWork.StockPrice = stockAdjustDtlWork.StockPriceTaxExc * mark;         //�d�����z
            }
            retStockAcPayHistWork.OpenPriceDiv = stockAdjustDtlWork.OpenPriceDiv;           //�I�[�v�����i�敪
            retStockAcPayHistWork.ListPriceTaxExcFl = stockAdjustDtlWork.ListPriceFl;       //�艿

            //ADD 2011/09/02 #24259------------------------------------------------------------------------------------------------->>>>>
            if (_isRecv)
            {
                retStockAcPayHistWork.SectionGuideNm = GetSecNameBySecCode(retStockAcPayHistWork.SectionCode);//���_����
                retStockAcPayHistWork.InputSectionGuidNm = GetSecNameBySecCode(retStockAcPayHistWork.InputSectionCd);//���͋��_�K�C�h����
            }
            //ADD 2011/09/02 #24259------------------------------------------------------------------------------------------------<<<<<

            #endregion // �i�[����

            return retStockAcPayHistWork;
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^ �� �݌Ƀ}�X�^
        /// </summary>
        /// <param name="retStockWork">�݌Ƀ}�X�^</param>
        /// <param name="stockAdjustDtlWork">�݌ɒ������׃f�[�^</param>
        /// <param name="procMode">�������[�h</param>
        /// <param name="writeMode">�X�V���[�h</param>
        /// <returns>�݌�</returns>
        /// <remarks>
        /// <br>UpdateNote : 2010/12/20 ������ ��Q���ǑΉ�����</br>
        /// <br>             �݌Ɏd���f�[�^�o�^���A�݌Ƀ}�X�^�̍ŏI�d�������X�V����Ȃ��s����C��</br>
        /// <br>UpdateNote : �n���f�B�^�[�~�i���݌Ɏd���iUOE�ȊO�j�̓o�^�����ōŏI�d�����̕⑫</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private StockWork CopyStockWorkFromStockAdjustDtlWork(StockWork retStockWork,StockAdjustDtlWork stockAdjustDtlWork, int procMode, int writeMode)
        {
            if (retStockWork == null)
                retStockWork = new StockWork();

            int mark = 1;
            if (writeMode == (int)ct_WriteMode.Write)
            {
                mark = 1;
            }
            else
            {
                mark = -1;
            }

            retStockWork.EnterpriseCode = stockAdjustDtlWork.EnterpriseCode;
            retStockWork.WarehouseCode = stockAdjustDtlWork.WarehouseCode;
            retStockWork.GoodsMakerCd = stockAdjustDtlWork.GoodsMakerCd;
            retStockWork.GoodsNo = stockAdjustDtlWork.GoodsNo;
            retStockWork.SupplierStock += stockAdjustDtlWork.AdjustCount * mark;
            retStockWork.SectionCode = stockAdjustDtlWork.SectionCode;

            //�d�����גʔԁi���j�����݂��Ă���ꍇ�͔����c���X�V����
            if (stockAdjustDtlWork.StockSlipDtlNumSrc != 0)
            {
                retStockWork.SalesOrderCount += stockAdjustDtlWork.AdjustCount * mark * - 1;
            }

            // ---ADD 2010/12/20---------->>>>>
            //�ŏI�d�����ɂ́A�݌ɒ������׃f�[�^�̒������t���Z�b�g����
            if ((stockAdjustDtlWork.UpdAssemblyId1 != string.Empty)
                && (stockAdjustDtlWork.UpdAssemblyId1.IndexOf("MAZAI04350") >= 0))
            {
                retStockWork.LastStockDate = stockAdjustDtlWork.AdjustDate;
            }
            // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���݌Ɏd���iUOE�ȊO�j�̓o�^�����ōŏI�d�����̕⑫ --------- >>>>
            else if ((stockAdjustDtlWork.UpdAssemblyId1 != string.Empty)
                && (stockAdjustDtlWork.UpdAssemblyId1.IndexOf("PMHND00003A") >= 0))
            {
                retStockWork.LastStockDate = stockAdjustDtlWork.AdjustDate;
            }
            // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���݌Ɏd���iUOE�ȊO�j�̓o�^�����ōŏI�d�����̕⑫ --------- <<<<
            else
            {
                //�Ȃ��B
            }
            // ---ADD 2010/12/20----------<<<<<

            // ADD 2011/09/16 sundx #25139 ----------------------------------------------->>>>>
            if (_isRecv)
            {
                //�݌ɋ��_�R�[�h���݌ɒ����f�[�^�D�d�����_�R�[�h�ɐݒ�
                retStockWork.SectionCode = _secCode;
                
                //�n�C�t�����i��
                retStockWork.GoodsNoNoneHyphen = stockAdjustDtlWork.GoodsNo.Replace("-", "");
                //�q�ɒI��
                retStockWork.WarehouseShelfNo = stockAdjustDtlWork.WarehouseShelfNo;
            }
            // ADD 2011/09/16 sundx #25139 -----------------------------------------------<<<<<

            return retStockWork;
        }
        #endregion

        #region ADD 2011/08/11 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j�݌ɒ����f�[�^��M���ɍ݌Ƀ}�X�^�̍X�V���s��        
        /// <summary>
        /// �݌ɒ����f�[�^��M�X�V����
        /// </summary>
        /// <param name="stockAdjustWorkList">��M�����݌ɒ����f�[�^���X�g</param>
        /// <param name="stockAdjustDtlWorkList">��M�����݌ɒ����f�[�^���׃��X�g</param>
        /// <param name="sqlConnection">DB�ڑ�</param>
        /// <param name="sqlTransaction">DB�g�����U�N�V����</param>
        /// <param name="retMsg">�G���[���</param>
        /// <returns>�X�e�[�^�X</returns>
        public int WriteForReceiveData(ArrayList stockAdjustWorkList, ArrayList stockAdjustDtlWorkList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)        
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlEncryptInfo sqlEncryptInfo = null;
            int stockAdjustSlipNo = 0;
            retMsg = "";
            string retItemInfo = "";

            ArrayList bfstockAdjustDtlWorkList = null;  //�݌ɒ������׃f�[�^���X�g(�O��l)
            ArrayList stockAcPayHistWorkList = null;    //�݌Ɏ󕥗������X�g
            ArrayList stockWorkList = new ArrayList();             //�݌Ƀ��X�g

            ArrayList infoList = new ArrayList(); //�V�F�A�`�F�b�N��񃊃X�g
            Dictionary<string, string> dic = new Dictionary<string, string>(); //�q�Ƀ��X�g 

            //bool uoeflg = false;//DEL 2011/09/07 sundx #24355
            string resNm = "";

            try
            {
                if (stockAdjustWorkList == null || stockAdjustDtlWorkList == null || stockAdjustWorkList.Count == 0 || stockAdjustDtlWorkList.Count == 0)
                    return status;

                //ADD 2011/09/02 #24259------------------------------->>>>>
                //�R�l�N�V��������
                if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
                {
                    SqlConnection sqlCon = CreateSqlConnection();
                    if (sqlCon == null) return status;
                    sqlCon.Open();

                    //���_�ݒ�̎擾
                    status = GetSecInfoSetWork(stockAdjustDtlWorkList, ref secInfoSetWorkHash, ref sqlCon);
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "���_�ݒ�̎擾�Ɏ��s���܂����B";
                        return status;
                    }
                }
                if (!_isRecv)
                {
                    _isRecv = true;
                }
                //ADD 2011/09/02 #24259-------------------------------<<<<<

                StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;
                _secCode = wkStockAdjustWork.StockSectionCd;//ADD 2011/09/16 sundx #25139
                //�݌Ɏd���ł`�o���b�N
                resNm = GetResourceName(wkStockAdjustWork.EnterpriseCode);

                //�`�o���b�N
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                    }

                    return status;
                }

                //---�݌ɒ����`�[�ԍ��̔�---
                if (wkStockAdjustWork.StockAdjustSlipNo == 0)
                {
                    status = CreateStockAdjustSlipNo(wkStockAdjustWork.EnterpriseCode, wkStockAdjustWork.SectionCode, out stockAdjustSlipNo, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                    wkStockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
                }
                else
                {
                    stockAdjustSlipNo = wkStockAdjustWork.StockAdjustSlipNo;
                    //�O��l�擾
                    status = SearchStockAdjustDtlProc(out bfstockAdjustDtlWorkList, wkStockAdjustWork, ref sqlConnection, ref sqlTransaction);
                    if (bfstockAdjustDtlWorkList.Count == 0)
                        bfstockAdjustDtlWorkList = null;
                }

                #region DEL 
                //DEL 2011/09/07 sundx #24355 ------------------------------------------------------------------------------------->>>>>
                ////�����v��̃`�F�b�N True:�����v��
                //uoeflg = CheckSendAddUp(stockAdjustDtlWorkList);

                ////�����f�[�^�X�V
                //if (uoeflg && stockAdjustDtlWorkList != null)
                //{
                //    StockSlipDB stockSlipDB = new StockSlipDB();
                //    ArrayList parastockDetailList = CopyToParaStockDetailFromStockAdjustDtl(stockAdjustDtlWorkList, bfstockAdjustDtlWorkList, (int)ct_WriteMode.Write);

                //    //�d�������[�g�̔����v�チ�\�b�h�̌Ăяo��
                //    status = stockSlipDB.UpdateOrderRemainCnt(new StockSlipWork(), parastockDetailList, 0, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                //}
                //DEL 2011/09/07 sundx #24355 -------------------------------------------------------------------------------------<<<<<
                #endregion

                //write���s
                //�݌Ɍn�f�[�^�쐬���� (�݌Ɏ󕥗����f�[�^�쐬)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = TransStockData(true, (int)ct_WriteMode.Write, bfstockAdjustDtlWorkList, ref stockAdjustWorkList, ref stockAdjustDtlWorkList, out stockAcPayHistWorkList, ref stockWorkList, (int)ct_ProcMode.Adjust, ref sqlConnection, ref sqlTransaction);
                }

                //�݌Ƀf�[�^�X�V
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    string origin = "";
                    CustomSerializeArrayList originList = null;
                    CustomSerializeArrayList tempparaList = new CustomSerializeArrayList();
                    tempparaList.Add(stockWorkList);
                    tempparaList.Add(stockAcPayHistWorkList);
                    int position = 0;
                    string param = "";
                    object freeParam = null;
                    int shelfNoUpdateDiv = 1;  //1:�I�ԍX�V���Ȃ��i�I�ԍX�V�͒I���p�j

                    status = _stockDB.WriteForStockAdjust(origin, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockAdjustDB.Write(ref object stockAdjustWork)");
            }
            finally
            {
                //�`�o�A�����b�N
                Release(resNm, sqlConnection, sqlTransaction);
            }

            return status;
        }

        /// <summary>
        /// �݌ɒ����f�[�^��M�X�V����
        /// </summary>
        /// <param name="stockAdjustWorkList">��M�����݌ɒ����f�[�^���X�g</param>
        /// <param name="stockAdjustDtlWorkList">��M�����݌ɒ����f�[�^���׃��X�g</param>
        /// <param name="sqlConnection">DB�ڑ�</param>
        /// <param name="sqlTransaction">DB�g�����U�N�V����</param>
        /// <param name="retMsg">�G���[���</param>
        /// <returns>�X�e�[�^�X</returns>
        public int DeleteForReceiveData(ArrayList stockAdjustWorkList, ArrayList stockAdjustDtlWorkList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlEncryptInfo sqlEncryptInfo = null;
            retMsg = "";
            string retItemInfo = "";

            ArrayList bfstockAdjustDtlWorkList = null;  //�݌ɒ������׃f�[�^���X�g(�O��l)
            ArrayList stockWorkList = new ArrayList();  //�݌Ƀ��X�g
            ArrayList stockAcPayHistWorkList = null;    //�݌Ɏ󕥗������X�g

            string resNm = "";

            try
            {
                //ADD 2011/09/02 #24259------------------------------->>>>>
                //�R�l�N�V��������
                if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
                {
                    SqlConnection sqlCon = CreateSqlConnection();
                    if (sqlCon == null) return status;
                    sqlCon.Open();

                    //���_�ݒ�̎擾
                    status = GetSecInfoSetWork(stockAdjustDtlWorkList, ref secInfoSetWorkHash, ref sqlCon);
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "���_�ݒ�̎擾�Ɏ��s���܂����B";
                        return status;
                    }
                }
                if (!_isRecv)
                {
                    _isRecv = true;                    
                }
                
                //ADD 2011/09/02 #24259-------------------------------<<<<<

                StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;
                _secCode = wkStockAdjustWork.StockSectionCd;//ADD 2011/09/16 sundx #25139
                resNm = GetResourceName(wkStockAdjustWork.EnterpriseCode);
                //�`�o���b�N
                status = Lock(resNm, sqlConnection, sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                    }

                    return status;
                }

                try
                {
                    //---�݌ɒ����`�[�ԍ��̔�---
                    //�O��l�擾
                    status = SearchStockAdjustDtlProc(out bfstockAdjustDtlWorkList, wkStockAdjustWork, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //�������_�f�[�^�͑��݂��Ȃ����A�����I��
                        if (bfstockAdjustDtlWorkList.Count == 0)
                            return status;
                        //�������_�f�[�^�̘_���敪��1�̎��A�����I��
                        StockAdjustDtlWork dtlWork = bfstockAdjustDtlWorkList[0] as StockAdjustDtlWork;
                        if (dtlWork.LogicalDeleteCode == 1)
                            return status;
                    }
                    else
                    {
                        //�G���[�������A�����I��
                        return status;
                    }
                    #region DEL 
                    //DEL 2011/09/07 sundx #24355 --------------------------------------------------------------------------------->>>>>
                    ////�����v��̃`�F�b�N True:�����v��
                    //bool uoeflg = CheckSendAddUp(bfstockAdjustDtlWorkList);

                    ////�����f�[�^�X�V
                    //if (uoeflg && bfstockAdjustDtlWorkList != null)
                    //{
                    //    StockSlipDB stockSlipDB = new StockSlipDB();
                    //    ArrayList parastockDetailList = CopyToParaStockDetailFromStockAdjustDtl(bfstockAdjustDtlWorkList, null, (int)ct_WriteMode.Delete);

                    //    //�d�������[�g�̔����v�チ�\�b�h�̌Ăяo��
                    //    status = stockSlipDB.UpdateOrderRemainCnt(new StockSlipWork(), parastockDetailList, 0, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //}
                    //DEL 2011/09/07 sundx #24355 --------------------------------------------------------------------------------->>>>>
                    #endregion

                    //write���s                   
                    //�O��l���X�g������X�V���X�g�̒l�ōX�V
                    for (int i = 0; i < bfstockAdjustDtlWorkList.Count; i++)
                    {
                        //���e�[�u���ɂ͂Ȃ����ڂ̂��߁A�O��l�̃��X�g�ł͎擾�o���Ȃ����ڂ��X�V
                        //�󕥍쐬���Ɏg�p����

                        StockAdjustDtlWork bfwork = bfstockAdjustDtlWorkList[i] as StockAdjustDtlWork;
                        StockAdjustDtlWork work = stockAdjustDtlWorkList[i] as StockAdjustDtlWork;

                        bfwork.SectionGuideNm = work.SectionGuideNm;
                        bfwork.SupplierCd = work.SupplierCd;
                        bfwork.SupplierSnm = work.SupplierSnm;
                    }

                    //�݌Ɍn�f�[�^�쐬���� (�݌Ɏ󕥗����f�[�^�쐬)
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //�폜���͑O��l�Ŏ󕥗������쐬����
                        TransStockData(true, (int)ct_WriteMode.Delete, null, ref stockAdjustWorkList, ref bfstockAdjustDtlWorkList, out stockAcPayHistWorkList, ref stockWorkList, (int)ct_ProcMode.Adjust, ref sqlConnection, ref sqlTransaction);
                    }

                    //�݌Ƀf�[�^�X�V
                    if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList tempparaList = new CustomSerializeArrayList();
                        tempparaList.Add(stockWorkList);
                        tempparaList.Add(stockAcPayHistWorkList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        int shelfNoUpdateDiv = 1;  //1:�I�ԍX�V���Ȃ��i�I�ԍX�V�͒I���p�j

                        status = _stockDB.WriteForStockAdjust(origin, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);
                    }
                }
                finally
                {
                    //�`�o�A�����b�N
                    Release(resNm, sqlConnection, sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockAdjustDB.Write(ref object stockAdjustWork)");
            }
            return status;
        }
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="secCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note        : ���_���̂��擾���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/09/02</br>
        /// </remarks>
        private string GetSecNameBySecCode(string secCode)
        {
            if (string.IsNullOrEmpty(secCode))
            {
                return null;
            }
            if (secInfoSetWorkHash.Contains(secCode))
            {
                return secInfoSetWorkHash[secCode].ToString();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ���_�ݒ�}�X�^�擾
        /// </summary>
        /// <param name="stockAdjustDtlWorkList">�݌ɒ������׃��X�g</param>
        /// <param name="secinfoSetWorkHash">���_���</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetSecInfoSetWork(ArrayList stockAdjustDtlWorkList, ref Hashtable secinfoSetWorkHash, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            secinfoSetWorkHash = new Hashtable();

            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
            if (stockAdjustDtlWorkList != null && stockAdjustDtlWorkList.Count > 0)
                secInfoSetWork.EnterpriseCode = ((StockAdjustDtlWork)stockAdjustDtlWorkList[0]).EnterpriseCode;   //��ƃR�[�h
            else
                return status;

            ArrayList secInfoList = new ArrayList();

            //���_�ݒ�Seach�Ăяo��
            status = _secInfoDB.Search(out secInfoList, secInfoSetWork, 0, 0, ref sqlConnection);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //���_���̂�HashTable�Ɋi�[
                foreach (SecInfoSetWork sec in secInfoList)
                {
                    secinfoSetWorkHash.Add(sec.SectionCode, sec.SectionGuideNm);

                }
            }

            return status;
        }
        #endregion
    }

    #region ��r�N���X
    /// <summary>
    /// �݌ɒ������׃N���X��r�N���X
    /// </summary>
    /// <remarks>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.02.01</br>
    /// </remarks>
    public class StockAdjustDtlWorkComparer : System.Collections.IComparer
    {
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="x">��r�I�u�W�F�N�g��</param>
        /// <param name="y">��r�I�u�W�F�N�g��</param>
        /// <returns>result</returns>
        public int Compare(object x, object y)
        {
            int result = 0;

            StockAdjustDtlWork cx = (StockAdjustDtlWork)x;
            StockAdjustDtlWork cy = (StockAdjustDtlWork)y;
    
            //�݌ɒ����`�[�ԍ�
            result = cx.StockAdjustSlipNo - cy.StockAdjustSlipNo;
            //�݌ɒ����s�ԍ�
            if (result == 0)
                result = cx.StockAdjustRowNo - cy.StockAdjustRowNo;

            //���ʂ�Ԃ�
            return result;
        }
    }
    /// <summary>
    /// �݌ɃN���X��r�N���X
    /// </summary>
    /// <remarks>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.02.01</br>
    /// </remarks>
    public class StockWorkComparer : System.Collections.IComparer
    {
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="x">��r�I�u�W�F�N�g��</param>
        /// <param name="y">��r�I�u�W�F�N�g��</param>
        /// <returns>result</returns>
        public int Compare(object x, object y)
        {
            int result = 0;

            StockWork cx = (StockWork)x;
            StockWork cy = (StockWork)y;

            //�q�ɃR�[�h
            //if (result == 0)
                result = cx.WarehouseCode.CompareTo(cy.WarehouseCode);
            //���[�J�[�R�[�h
            if (result == 0)
                result = cx.GoodsMakerCd - cy.GoodsMakerCd;
            //���i�R�[�h
            if (result == 0)
                result = string.Compare(cx.GoodsNo, cy.GoodsNo);

            //���ʂ�Ԃ�
            return result;
        }
    }

 
    /// <summary>
    /// �I���X�V�N���X��r�N���X
    /// </summary>
    /// <remarks>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.02.01</br>
    /// </remarks>
    public class InventoryDataUpdateWorkComparer : System.Collections.IComparer
    {
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="x">��r�I�u�W�F�N�g��</param>
        /// <param name="y">��r�I�u�W�F�N�g��</param>
        /// <returns>result</returns>
        public int Compare(object x, object y)
        {
            int result = 0;

            InventoryDataUpdateWork cx = (InventoryDataUpdateWork)x;
            InventoryDataUpdateWork cy = (InventoryDataUpdateWork)y;

            //���_�R�[�h
            result = cx.SectionCode.CompareTo(cy.SectionCode);
            //�q�ɃR�[�h
            if (result == 0)
                result = cx.WarehouseCode.CompareTo(cy.WarehouseCode);
            //���[�J�[�R�[�h
            if (result == 0)
                result = cx.GoodsMakerCd - cy.GoodsMakerCd;
            //���i�R�[�h
            if (result == 0)
                result = string.Compare(cx.GoodsNo, cy.GoodsNo);

            //���ʂ�Ԃ�
            return result;
        }
    }
    #endregion  // ��r�N���X

}
