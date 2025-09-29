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
using Broadleaf.Application.Common;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
using System.Xml;
using System.IO;
using Microsoft.Win32;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i���i�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i���i�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 18322  �ؑ� ����</br>
    /// <br>Date       : 2007.04.18</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: DC.NS�Ή�</br>
    /// <br>Programmer : 21024�@���X�؁@��</br>
    /// <br>Date       : 2007.08.13</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 22008 ���� PM.NS�Ή�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: �d���`�[���͂ŉ��i�X�V���̕s��C��</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2010/11/11</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: ���i�}�X�^�C���|�[�g OutOfMemory Exception(�C�X�R GC�T�[�o���[�h)</br>
    /// <br>Programmer : 10801804-00 #35805 liusy</br>
    /// <br>Date       : 2013/06/14</br> 
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/05/20 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11175183-00</br>
    /// <br>           : Redmine#45693 �C�X�R�@���i�}�X�^�C���|�[�g OutOfMemory�����Ή�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/07/24 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11175183-00</br>
    /// <br>           : Redmine#45693 �C�X�R�@���i�}�X�^�C���|�[�g �ꎞ�e�[�u����JOIN���Č�������ύX</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2020/06/18 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br>           : PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2020/08/28 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11600006-00</br>
    /// <br>           : PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    [Serializable]
    public class GoodsPriceUDB : RemoteDB, IGoodsPriceUDB, IGetSyncdataList
    {
        #region �萔
        /// <summary>�_���폜�敪</summary>
        private enum ct_LogicalDeleteCode
        {
            Valid = 0,
            LogicalDelete = 1,
            Pending = 2,
            Delete = 3
        }
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>> 
        // �`�[�X�V�^�C���A�E�g���Ԑݒ�t�@�C��
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XML�t�@�C�����������̃f�t�H���g�l
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
        #endregion

        /// <summary>
        /// ���i���i�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        public GoodsPriceUDB()
            :
            base("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork", "GOODSPRICEURF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i���i�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="GoodsPriceUWork">��������</param>
        /// <param name="paraGoodsPriceUWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i���i�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        public int Search(out object GoodsPriceUWork, object paraGoodsPriceUWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            GoodsPriceUWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGoodsPriceProc(out GoodsPriceUWork, paraGoodsPriceUWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsPriceUDB.Search");
                GoodsPriceUWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̏��i���i�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objGoodsPriceUWork">��������</param>
        /// <param name="paraGoodsPriceUWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i���i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        public int SearchGoodsPriceProc(out object objGoodsPriceUWork, object paraGoodsPriceUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsPriceUWork GoodsPriceUWork = null; 

            ArrayList GoodsPriceUWorkList = paraGoodsPriceUWork as ArrayList;
            if (GoodsPriceUWorkList == null)
            {
                GoodsPriceUWork = paraGoodsPriceUWork as GoodsPriceUWork;
            }
            else
            {
                if (GoodsPriceUWorkList.Count > 0)
                    GoodsPriceUWork = GoodsPriceUWorkList[0] as GoodsPriceUWork;
            }

            int status = SearchGoodsPriceProc(out GoodsPriceUWorkList, GoodsPriceUWork, readMode, logicalMode, ref sqlConnection);
            objGoodsPriceUWork = GoodsPriceUWorkList;
            return status;
        }
        //add by liusy #35805 2013/06/14---------->>>>>
        /// <summary>
        /// �w�肳�ꂽ�����̏��i���i�}�X�^���LIST(��key���� �폜�O�̗��p)��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">��������</param>
        /// <param name="paraGoodsPriceUWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i���i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : liusy</br>
        /// <br>Date       : 2013/06/14</br>
        public int SearchGoodsPriceBeforeDelProc(out ArrayList GoodsPriceUWorkList, GoodsPriceUWork paraGoodsPriceUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList al = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sql = "";
            try
            {

                sqlCommand = new SqlCommand(String.Empty, sqlConnection);
                sqlCommand.CommandText += CreateQueryBeforeDelString(ref sqlCommand, paraGoodsPriceUWork, logicalMode);

                sql = sqlCommand.CommandText;
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyToGoodsPriceUWorkBeforeDelFromReader(ref myReader));
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

            GoodsPriceUWorkList = al;
            return status;
        }
        //add by liusy #35805 2013/06/14----------<<<<<

        //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
        /// <summary>
        /// ���i�f�[�^�̌���[���i�}�X�^�C���|�[�g��p]
        /// </summary>
        /// <param name="GoodsPriceUWorkList"></param>
        /// <param name="paraGoodsPriceUWork"></param>
        /// <param name="tempTalName"></param>
        /// <param name="logicalMode"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���i�f�[�^�̌���[���i�}�X�^�C���|�[�g��p]</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2015/05/20</br>
        /// <br>Update Note: 2015/07/24 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11175183-00</br>
        /// <br>           : Redmine#45693 �C�X�R�@���i�}�X�^�C���|�[�g �ꎞ�e�[�u����JOIN���Č�������ύX</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        //public int SearchGoodsPriceForGoodsImport(out ArrayList GoodsPriceUWorkList, GoodsPriceUWork paraGoodsPriceUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection) // DEL 2015/07/24 �c���� Redmine#45693
        public int SearchGoodsPriceForGoodsImport(out ArrayList GoodsPriceUWorkList, GoodsPriceUWork paraGoodsPriceUWork, string tempTalName, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection) // ADD 2015/07/24 �c���� Redmine#45693
        {
            ArrayList al = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
            try
            {
                sqlCommand = new SqlCommand(String.Empty, sqlConnection);
                //sqlCommand.CommandText += CreateQueryString(ref sqlCommand, paraGoodsPriceUWork, logicalMode); // DEL 2015/07/24 �c���� Redmine#45693
                sqlCommand.CommandText += CreateQueryStringForGoodsImport(ref sqlCommand, paraGoodsPriceUWork, tempTalName, logicalMode); // ADD 2015/07/24 �c���� Redmine#45693
                sqlCommand.CommandTimeout = 3600; // ADD 2015/07/24 �c���� Redmine#45693

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                    //al.Add(CopyToGoodsPriceUWorkFromReader(ref myReader));
                    al.Add(CopyToGoodsPriceUWorkFromReader(ref myReader, convertDoubleRelease));
                    // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
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
                // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
            }

            GoodsPriceUWorkList = al;
            return status;
        }

        //----- ADD 2015/07/24 �c���� Redmine#45693 ------->>>>>
        /// <summary>
        /// ���i�f�[�^�̌���[���i�}�X�^�C���|�[�g��p]
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="GoodsPriceUWork"></param>
        /// <param name="tempTalName"></param>
        /// <param name="logicalMode"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ꎞ�e�[�u����JOIN���Č�������ύX</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2015/07/24</br>
        /// </remarks>
        private string CreateQueryStringForGoodsImport(ref SqlCommand sqlCommand, GoodsPriceUWork GoodsPriceUWork, string tempTalName, ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder sqlText = new StringBuilder();

            sqlText.Append("SELECT" + Environment.NewLine);
            sqlText.Append(" *" + Environment.NewLine);
            sqlText.Append("FROM" + Environment.NewLine);
            sqlText.Append("  GOODSPRICEURF PRICE WITH(READUNCOMMITTED) " + Environment.NewLine);
            sqlText.Append("INNER JOIN " + tempTalName + " TEMTBL WITH(READUNCOMMITTED) " + Environment.NewLine);
            sqlText.Append("ON PRICE.ENTERPRISECODERF = TEMTBL.ENTERPRISECODERF " + Environment.NewLine);
            sqlText.Append("AND PRICE.GOODSMAKERCDRF = TEMTBL.GOODSMAKERCDRF " + Environment.NewLine);
            sqlText.Append("AND PRICE.GOODSNORF = TEMTBL.GOODSNORF " + Environment.NewLine);
            sqlText.Append("WHERE" + Environment.NewLine);
            sqlText.Append("  PRICE.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);

            // ��ƃR�[�h
            SqlParameter findparaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findparaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);

            // ���[�J�[�R�[�h
            if (IsValidParameter(GoodsPriceUWork.GoodsMakerCd, false))
            {
                sqlText.Append("  AND PRICE.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine);
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
            }

            //�_���폜�敪
            bool useLogicalMode = false;
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                useLogicalMode = true;
                sqlText.Append("  AND PRICE.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                     (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                useLogicalMode = true;
                sqlText.Append(" AND PRICE.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine);
            }
            if (useLogicalMode)
            {
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return sqlText.ToString();
        }
        //----- ADD 2015/07/24 �c���� Redmine#45693 -------<<<<<
        //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<

        /// <summary>
        /// �w�肳�ꂽ�����̏��i���i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">��������</param>
        /// <param name="paraGoodsPriceUWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i���i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026  ���R�@����</br>
        /// <br>Date       : 2007.04.20</br>
        /// <summary>
        /// �w�肳�ꂽ�����̏��i���i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">��������</param>
        /// <param name="paraGoodsPriceUWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i���i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026  ���R�@����</br>
        /// <br>Date       : 2007.04.20</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        public int SearchGoodsPriceProc(out ArrayList GoodsPriceUWorkList, GoodsPriceUWork paraGoodsPriceUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList al = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<

            try
            {
                sqlCommand = new SqlCommand(String.Empty, sqlConnection);
                sqlCommand.CommandText += CreateQueryString(ref sqlCommand, paraGoodsPriceUWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                    //al.Add(CopyToGoodsPriceUWorkFromReader(ref myReader));
                    al.Add(CopyToGoodsPriceUWorkFromReader(ref myReader, convertDoubleRelease));
                    // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
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
                // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
            }

            GoodsPriceUWorkList = al;
            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i���i�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i���i�}�X�^��߂��܂�</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

                // XML�̓ǂݍ���
                GoodsPriceUWork = (GoodsPriceUWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsPriceUWork));
                if (GoodsPriceUWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref GoodsPriceUWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(GoodsPriceUWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsPriceUDB.Read");
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
        /// �w�肳�ꂽ�����̏��i���i�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i���i�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS�Ή�</br>
        /// <br>Programmer : 21024�@���X�؁@��</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        public int ReadProc( ref GoodsPriceUWork GoodsPriceUWork, int readMode, ref SqlConnection sqlConnection )
        {
            return this.ReadProcProc(ref GoodsPriceUWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i���i�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i���i�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS�Ή�</br>
        /// <br>Programmer : 21024�@���X�؁@��</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private int ReadProcProc( ref GoodsPriceUWork GoodsPriceUWork, int readMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            string sqlText = "";
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
            try
            {
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += " *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                    findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                        //GoodsPriceUWork = CopyToGoodsPriceUWorkFromReader(ref myReader);
                        GoodsPriceUWork = CopyToGoodsPriceUWorkFromReader(ref myReader, convertDoubleRelease);
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
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
                // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// ���i���i�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <param name="writeError">�X�V�G���[</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i���i�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 19026  ���R�@����</br>
        /// <br>Date       : 2007.04.20</br>
        public int Write(ref object GoodsPriceUWork, out object writeError)
        {
            writeError = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(GoodsPriceUWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                ArrayList writeErrorList;
                status = WriteGoodsPriceProc(ref paraList, out writeErrorList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                    status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                GoodsPriceUWork = paraList;
                writeError = (object)writeErrorList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsPriceUDB.Write(ref object GoodsPriceUWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// ���i���i�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <param name="writeErrorList">�X�V�G���[���X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i���i�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 19026  ���R�@����</br>
        /// <br>Date       : 2007.04.20</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS�Ή�</br>
        /// <br>Programmer : 21024�@���X�؁@��</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: PMKOBETSU-4076 �^�C���A�E�g�Ή�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2020/08/28</br>
        /// <br>------------------------------------------------------------------------------------</br>
        public int WriteGoodsPriceProc(ref ArrayList GoodsPriceUWorkList, out ArrayList writeErrorList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            writeErrorList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (GoodsPriceUWorkList == null || GoodsPriceUWorkList.Count == 0)
                return status;

            ArrayList al = new ArrayList();
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // �R�}���h�^�C���A�E�g�i�b�j
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<


            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();

            try
            {
                // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<

                for (int i = 0; i < GoodsPriceUWorkList.Count; i++)
                {
                    GoodsPriceUWork GoodsPriceUWork = GoodsPriceUWorkList[i] as GoodsPriceUWork;
                    int writeStatus;
                    string errorMessage;
                    if (GoodsPriceUWork.LogicalDeleteCode == (int)ct_LogicalDeleteCode.Delete)
                    {
                        // --- UPD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
                        //writeStatus = DeleteGoodsPrice(ref GoodsPriceUWork, out errorMessage, ref sqlConnection, ref sqlTransaction);
                        writeStatus = DeleteGoodsPrice(ref GoodsPriceUWork, out errorMessage, ref sqlConnection, ref sqlTransaction, dbCommandTimeout);
                        // --- UPD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
                    }
                    else
                    {
                        // --- UPD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                        //writeStatus = WriteGoodsPrice(ref GoodsPriceUWork, out errorMessage, ref sqlConnection, ref sqlTransaction);
                        //writeStatus = WriteGoodsPrice(ref GoodsPriceUWork, out errorMessage, ref sqlConnection, ref sqlTransaction, convertDoubleRelease);
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
                        writeStatus = WriteGoodsPrice(ref GoodsPriceUWork, out errorMessage, ref sqlConnection, ref sqlTransaction, convertDoubleRelease, dbCommandTimeout);
                        // --- UPD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
                    }

                    if (writeStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        al.Add(GoodsPriceUWork);

                        //WARNING,ERROR����Ȃ�������NORMAL
                        if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                            status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        writeErrorList.Add(SetError(GoodsPriceUWork, writeStatus, errorMessage));
                        status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                    }
                }

            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            }
            finally
            {
                // ���
                convertDoubleRelease.Dispose();
            }
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
            
            GoodsPriceUWorkList = al;
            return status;
        }

        /// <summary>
        /// ���i���i�}�X�^ INSERT or UPDATE ����
        /// </summary>
        /// <param name="GoodsPriceUWork">���i���i�}�X�^</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">SQL�ڑ����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V�������</param>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2020/08/28</br>
        /// <br>------------------------------------------------------------------------------------</br>
        // --- UPD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
        //private int WriteGoodsPrice(ref GoodsPriceUWork GoodsPriceUWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //private int WriteGoodsPrice(ref GoodsPriceUWork GoodsPriceUWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
        private int WriteGoodsPrice(ref GoodsPriceUWork GoodsPriceUWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ConvertDoubleRelease convertDoubleRelease, int dbCommandTimeout)
        // --- UPD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
        {
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = String.Empty;
            try
            {
                //Select�R�}���h�̐���
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                sqlCommand.CommandTimeout = dbCommandTimeout; // ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή�
                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != GoodsPriceUWork.UpdateDateTime)
                    {
                        //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                        if (GoodsPriceUWork.UpdateDateTime == DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            errorMessage = "�d������f�[�^�����邽�ߍX�V�ł��܂���B";
                        }
                        //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            errorMessage = "���̃f�[�^�͊��ɍX�V����Ă��܂��B";
                        }

                        sqlCommand.Cancel();
                        return status;
                    }

                    //�X�V�p��SQL���𐶐�
                    sqlText = "";
                    sqlText += "UPDATE GOODSPRICEURF SET" + Environment.NewLine;
                    sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                    sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                    sqlText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                    sqlText += " , PRICESTARTDATERF=@PRICESTARTDATE" + Environment.NewLine;
                    sqlText += " , LISTPRICERF=@LISTPRICE" + Environment.NewLine;
                    sqlText += " , SALESUNITCOSTRF=@SALESUNITCOST" + Environment.NewLine;
                    sqlText += " , STOCKRATERF=@STOCKRATE" + Environment.NewLine;
                    sqlText += " , OPENPRICEDIVRF=@OPENPRICEDIV" + Environment.NewLine;
                    sqlText += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                    sqlText += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)GoodsPriceUWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                    GoodsPriceUWork.UpdateDate = GoodsPriceUWork.UpdateDateTime.Date;

                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                    findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                    findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (GoodsPriceUWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        errorMessage = "���̃f�[�^�͊��ɍ폜����Ă��܂��B";
                        sqlCommand.Cancel();
                        return status;
                    }

                    //�V�K�쐬����SQL���𐶐�
                    sqlText = "";
                    sqlText += "INSERT INTO GOODSPRICEURF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += "  ,GOODSNORF" + Environment.NewLine;
                    sqlText += "  ,PRICESTARTDATERF" + Environment.NewLine;
                    sqlText += "  ,LISTPRICERF" + Environment.NewLine;
                    sqlText += "  ,SALESUNITCOSTRF" + Environment.NewLine;
                    sqlText += "  ,STOCKRATERF" + Environment.NewLine;
                    sqlText += "  ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                    sqlText += "  ,UPDATEDATERF" + Environment.NewLine;
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
                    sqlText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  ,@GOODSNO" + Environment.NewLine;
                    sqlText += "  ,@PRICESTARTDATE" + Environment.NewLine;
                    sqlText += "  ,@LISTPRICE" + Environment.NewLine;
                    sqlText += "  ,@SALESUNITCOST" + Environment.NewLine;
                    sqlText += "  ,@STOCKRATE" + Environment.NewLine;
                    sqlText += "  ,@OPENPRICEDIV" + Environment.NewLine;
                    sqlText += "  ,@OFFERDATE" + Environment.NewLine;
                    sqlText += "  ,@UPDATEDATE" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    //�ȉ��̏����Ř_���폜�敪���O�ɏ����������Ă��܂��ׁA�ޔ����Ă���
                    //���i�݌Ƀ}�X�^����̘_���폜���Ɏg�p����
                    int logicalDeleteCode = GoodsPriceUWork.LogicalDeleteCode;

                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)GoodsPriceUWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                    GoodsPriceUWork.UpdateDate = GoodsPriceUWork.UpdateDateTime.Date;

                    GoodsPriceUWork.LogicalDeleteCode = logicalDeleteCode;
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
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
                SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float);
                SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                #endregion

                #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(GoodsPriceUWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(GoodsPriceUWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(GoodsPriceUWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.LogicalDeleteCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                paraPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                //paraListPrice.Value = SqlDataMediator.SqlSetDouble(GoodsPriceUWork.ListPrice);
                convertDoubleRelease.EnterpriseCode = GoodsPriceUWork.EnterpriseCode;
                convertDoubleRelease.GoodsMakerCd = GoodsPriceUWork.GoodsMakerCd;
                convertDoubleRelease.GoodsNo = GoodsPriceUWork.GoodsNo;
                convertDoubleRelease.ConvertSetParam = GoodsPriceUWork.ListPrice;

                // �ϊ��������s
                convertDoubleRelease.ConvertProc();

                paraListPrice.Value = SqlDataMediator.SqlSetDouble(convertDoubleRelease.ConvertInfParam.ConvertGetParam);
                // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
                
                paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(GoodsPriceUWork.SalesUnitCost);
                paraStockRate.Value = SqlDataMediator.SqlSetDouble(GoodsPriceUWork.StockRate);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.OpenPriceDiv);
                paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.OfferDate);
                paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.UpdateDate);
                #endregion

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "�X�V�����ŃG���[���������܂����B";
                sqlCommand.Cancel();
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

        /// <summary>
        /// ���i���i�}�X�^ ���i�X�V����
        /// </summary>
        /// <param name="goodsPriceList">���i���i�}�X�^</param>
        /// <param name="sqlConnection">SQL�ڑ����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        public int UpDatePrice(ref ArrayList goodsPriceList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpDatePriceProc(ref goodsPriceList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i���i�}�X�^ ���i�X�V����
        /// </summary>
        /// <param name="goodsPriceList">���i���i�}�X�^</param>
        /// <param name="sqlConnection">SQL�ڑ����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private int UpDatePriceProc(ref ArrayList goodsPriceList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlText = "";
            
            ArrayList al = new ArrayList();

            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<

            try 
            {
                
                if (goodsPriceList != null)
                {
                    for (int i = 0; i < goodsPriceList.Count; i++)
                    {
                        GoodsPriceUWork goodsPriceUWork = goodsPriceList[i] as GoodsPriceUWork;

                        sqlText = "";
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.EnterpriseCode);
                        findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.GoodsNo);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsPriceUWork.PriceStartDate);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //�X�V�p��SQL���𐶐�
                            sqlText = "";
                            sqlText += "UPDATE GOODSPRICEURF SET" + Environment.NewLine;
                            sqlText += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LISTPRICERF=@LISTPRICE" + Environment.NewLine;
                            sqlText += " , SALESUNITCOSTRF=@SALESUNITCOST" + Environment.NewLine;
                            sqlText += " , STOCKRATERF=@STOCKRATE" + Environment.NewLine;
                            sqlText += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                            sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsPriceUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                            goodsPriceUWork.UpdateDate = goodsPriceUWork.UpdateDateTime.Date;

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.EnterpriseCode);
                            findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.GoodsNo);
                            findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsPriceUWork.PriceStartDate);

                            if (myReader.IsClosed == false) myReader.Close();

                            //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float);
                            SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                            SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                            SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsPriceUWork.UpdateDateTime);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.UpdAssemblyId2);

                            // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                            //paraListPrice.Value = SqlDataMediator.SqlSetDouble(goodsPriceUWork.ListPrice);
                            convertDoubleRelease.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
                            convertDoubleRelease.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
                            convertDoubleRelease.GoodsNo = goodsPriceUWork.GoodsNo;
                            convertDoubleRelease.ConvertSetParam = goodsPriceUWork.ListPrice;

                            // �ϊ��������s
                            convertDoubleRelease.ConvertProc();

                            paraListPrice.Value = SqlDataMediator.SqlSetDouble(convertDoubleRelease.ConvertInfParam.ConvertGetParam);
                            // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<

                            paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(goodsPriceUWork.SalesUnitCost);
                            paraStockRate.Value = SqlDataMediator.SqlSetDouble(goodsPriceUWork.StockRate);
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);

                            sqlCommand.ExecuteNonQuery();
                            al.Add(goodsPriceUWork);

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            if (myReader.IsClosed == false) myReader.Close();

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;  // ADD 2010/11/11 
                        }
                    }
                }

            }
            catch(SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex,"",ex.Number);
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
            
            goodsPriceList = al;
            return status;
                        
        }

        /// <summary>
        /// ���i���i�}�X�^ DELETE ����
        /// </summary>
        /// <param name="GoodsPriceUWork">���i���i�}�X�^</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">SQL�ڑ����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2020/08/28</br>
        /// <br>------------------------------------------------------------------------------------</br>
        // --- UPD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
        //private int DeleteGoodsPrice(ref GoodsPriceUWork GoodsPriceUWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int DeleteGoodsPrice(ref GoodsPriceUWork GoodsPriceUWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int dbCommandTimeout)
        // --- UPD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
        {
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = String.Empty;

            try
            {
                #region [�X�V����]
                //Select�R�}���h�̐���
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                sqlCommand.CommandTimeout = dbCommandTimeout; // ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή�
                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != GoodsPriceUWork.UpdateDateTime)
                    {
                        //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        errorMessage = "���̃f�[�^�͊��ɍX�V����Ă��܂��B";

                        sqlCommand.Cancel();
                        return status;
                    }

                    sqlText = "";
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                    findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                    findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    errorMessage = "���̃f�[�^�͊��ɍ폜����Ă��܂��B";
                    sqlCommand.Cancel();
                    return status;
                }
                if (myReader.IsClosed == false) myReader.Close();

                sqlCommand.ExecuteNonQuery();
                #endregion

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "�X�V�����ŃG���[���������܂����B";
                sqlCommand.Cancel();
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

        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
        #region �ݒ�t�@�C���擾
        /// <summary>
        /// �ݒ�t�@�C���擾
        /// </summary>
        /// <param name="dbCommandTimeout">�^�C���A�E�g����</param>
        /// <remarks>
        /// <br>Note         : �ݒ�t�@�C���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // �����l�ݒ�
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //�^�C���A�E�g���Ԃ��擾
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "�ݒ�t�@�C���擾�G���[");
                }
            }

        }
        #endregion // �ݒ�t�@�C���擾

        #region XML�t�@�C������
        /// <summary>
        /// XML�t�@�C�����擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // �J�����g�f�B���N�g���擾
                homeDir = this.GetCurrentDirectory();

                // �f�B���N�g������XML�t�@�C������A��
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // �t�@�C�������݂��Ȃ��ꍇ�͋󔒂ɂ���
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XML�t�@�C������

        #region �J�����g�t�H���_
        /// <summary>
        /// �J�����g�t�H���_�擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : �J�����g�t�H���_�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML�i�[�f�B���N�g���擾
            try
            {
                // dll�i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // �����́u\�v�͏�ɂȂ�

                // ���W�X�g�������USER_AP�̃L�[�����擾
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // ���W�X�g�������擾�ł��Ȃ��ꍇ�͏����f�B���N�g�� // �^�p�゠�肦�Ȃ��P�[�X
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
                // �^�p�゠�肦�Ȃ��P�[�X
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_AP��LOG�t�H���_�Ƀ��O�o��
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // �J�����g�t�H���_
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

        /// <summary>
        /// �o�^�G���[�I�u�W�F�N�g�̐���
        /// </summary>
        /// <param name="GoodsPriceUWork">���i���i�}�X�^</param>
        /// <param name="errorCode">�G���[�R�[�h</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns>���i���i�o�^�G���[</returns>
        private GoodsPriceUWriteErrorWork SetError(GoodsPriceUWork GoodsPriceUWork, int errorCode, string errorMessage)
        {

            GoodsPriceUWriteErrorWork goodsPriceWriteErrorWork = new GoodsPriceUWriteErrorWork();

            goodsPriceWriteErrorWork.CreateDateTime = GoodsPriceUWork.CreateDateTime;
            goodsPriceWriteErrorWork.UpdateDateTime = GoodsPriceUWork.UpdateDateTime;
            goodsPriceWriteErrorWork.EnterpriseCode = GoodsPriceUWork.EnterpriseCode;
            goodsPriceWriteErrorWork.FileHeaderGuid = GoodsPriceUWork.FileHeaderGuid;
            goodsPriceWriteErrorWork.UpdEmployeeCode = GoodsPriceUWork.UpdEmployeeCode;
            goodsPriceWriteErrorWork.UpdAssemblyId1 = GoodsPriceUWork.UpdAssemblyId1;
            goodsPriceWriteErrorWork.UpdAssemblyId2 = GoodsPriceUWork.UpdAssemblyId2;
            goodsPriceWriteErrorWork.LogicalDeleteCode = GoodsPriceUWork.LogicalDeleteCode;
            goodsPriceWriteErrorWork.GoodsMakerCd = GoodsPriceUWork.GoodsMakerCd;
            goodsPriceWriteErrorWork.GoodsNo = GoodsPriceUWork.GoodsNo;
            goodsPriceWriteErrorWork.PriceStartDate = GoodsPriceUWork.PriceStartDate;
            goodsPriceWriteErrorWork.ListPrice = GoodsPriceUWork.ListPrice;
            goodsPriceWriteErrorWork.SalesUnitCost = GoodsPriceUWork.SalesUnitCost;
            goodsPriceWriteErrorWork.StockRate = GoodsPriceUWork.StockRate;
            goodsPriceWriteErrorWork.OpenPriceDiv = GoodsPriceUWork.OpenPriceDiv;
            goodsPriceWriteErrorWork.OfferDate = GoodsPriceUWork.OfferDate;
            goodsPriceWriteErrorWork.UpdateDate = GoodsPriceUWork.UpdateDate;
            goodsPriceWriteErrorWork.ErrorCode = errorCode;
            goodsPriceWriteErrorWork.ErrorMessage = errorMessage;
            return goodsPriceWriteErrorWork;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// ���i���i�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i���i�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        public int LogicalDelete(ref object GoodsPriceUWork)
        {
            return LogicalDeleteGoodsPrice(ref GoodsPriceUWork, 0);
        }

        /// <summary>
        /// �_���폜���i���i�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���i���i�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        public int RevivalLogicalDelete(ref object GoodsPriceUWork)
        {
            return LogicalDeleteGoodsPrice(ref GoodsPriceUWork, 1);
        }

        /// <summary>
        /// ���i���i�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i���i�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        private int LogicalDeleteGoodsPrice(ref object GoodsPriceUWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(GoodsPriceUWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteGoodsPriceProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "GoodsPriceUDB.LogicalDeleteGoodsPrice :" + procModestr);

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
        /// ���i���i�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i���i�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS�Ή�</br>
        /// <br>Programmer : 21024�@���X�؁@��</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        public int LogicalDeleteGoodsPriceProc( ref ArrayList GoodsPriceUWorkList
                                              , int procMode
                                              , ref SqlConnection sqlConnection
                                              , ref SqlTransaction sqlTransaction )
        {
            return this.LogicalDeleteGoodsPriceProcProc(ref GoodsPriceUWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i���i�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i���i�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS�Ή�</br>
        /// <br>Programmer : 21024�@���X�؁@��</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private int LogicalDeleteGoodsPriceProcProc( ref ArrayList GoodsPriceUWorkList
                                              , int procMode
                                              , ref SqlConnection sqlConnection
                                              , ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlText = "";

            try
            {
                if (GoodsPriceUWorkList != null)
                {
                    for (int i = 0; i < GoodsPriceUWorkList.Count; i++)
                    {
                        GoodsPriceUWork GoodsPriceUWork = GoodsPriceUWorkList[i] as GoodsPriceUWork;

                        sqlText = "";
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                        findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != GoodsPriceUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlText = "";
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,UPDATEDATERF = @UPDATEDATE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                            sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                            findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                            findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)GoodsPriceUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                            GoodsPriceUWork.UpdateDate = GoodsPriceUWork.UpdateDateTime.Date;
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
                            else if (logicalDelCd == 0) GoodsPriceUWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else GoodsPriceUWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) GoodsPriceUWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;      //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
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
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(GoodsPriceUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.LogicalDeleteCode);
                        paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.UpdateDate);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(GoodsPriceUWork);
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

            GoodsPriceUWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// ���i���i�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">���i���i�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���i���i�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
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

                status = DeleteGoodsPriceProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "GoodsPriceUDB.Delete");
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
        /// ���i���i�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">���i���i�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i���i�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS�Ή�</br>
        /// <br>Programmer : 21024�@���X�؁@��</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        public int DeleteGoodsPriceProc( ArrayList GoodsPriceUWorkList
                                       ,ref SqlConnection  sqlConnection
                                       ,ref SqlTransaction sqlTransaction)
        {
            return this.DeleteGoodsPriceProcProc(GoodsPriceUWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i���i�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">���i���i�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i���i�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS�Ή�</br>
        /// <br>Programmer : 21024�@���X�؁@��</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private int DeleteGoodsPriceProcProc( ArrayList GoodsPriceUWorkList
                                       , ref SqlConnection sqlConnection
                                       , ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = "";
            try
            {

                for (int i = 0; i < GoodsPriceUWorkList.Count; i++)
                {
                    GoodsPriceUWork GoodsPriceUWork = GoodsPriceUWorkList[i] as GoodsPriceUWork;

                    sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                    findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                    findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != GoodsPriceUWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlText = "";
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                        findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);
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

        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i���i���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS�Ή�</br>
        /// <br>Programmer : 21024�@���X�؁@��</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        public int GetSyncdataList( out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection )
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }

        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i���i���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS�Ή�</br>
        /// <br>Programmer : 21024�@���X�؁@��</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private int GetSyncdataListProc( out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = "";

            ArrayList al = new ArrayList();
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
            try
            {
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += " *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                    //al.Add(CopyToGoodsPriceUWorkFromReader(ref myReader));
                    al.Add(CopyToGoodsPriceUWorkFromReader(ref myReader, convertDoubleRelease));
                    // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
                    
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
                // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
            }

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [�N�G�������񐶐�]
        /// <summary>
        /// Search���������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="GoodsPriceUWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>�N�G��������</returns>
        /// <br>Note       : ���i���i�}�X�^�̌����p�N�G��������𐶐����Ė߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.20</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS�Ή�</br>
        /// <br>Programmer : 21024�@���X�؁@��</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2015/05/20 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11175183-00</br>
        /// <br>           : Redmine#45693 �C�X�R�@���i�}�X�^�C���|�[�g OutOfMemory�����Ή�</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private string CreateQueryString( ref SqlCommand sqlCommand, GoodsPriceUWork GoodsPriceUWork, ConstantManagement.LogicalMode logicalMode )
        {
            string sqlText = String.Empty;

            sqlText += "SELECT" + Environment.NewLine;
            sqlText += " *" + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "  GOODSPRICEURF" + Environment.NewLine;
            sqlText += "WHERE" + Environment.NewLine;
            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;

            // ��ƃR�[�h
            SqlParameter findparaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findparaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);

            // ���[�J�[�R�[�h
            if (IsValidParameter(GoodsPriceUWork.GoodsMakerCd, false))
            {
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
            }

            // �i��
            if (IsValidParameter(GoodsPriceUWork.GoodsNo))
            {
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
            }

            //----- DEL 2015/07/24 �c���� Redmine#45693 ----------------->>>>>
            ////----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
            //// ���i�}�X�^�C���|�[�g�p�i�ԊJ�n
            //if (IsValidParameter(GoodsPriceUWork.GoodsNoSt))
            //{
            //    sqlText += "  AND GOODSNORF >= @FINDGOODSNOST" + Environment.NewLine;
            //    SqlParameter findParaGoodsNoSt = sqlCommand.Parameters.Add("@FINDGOODSNOST", SqlDbType.NVarChar);
            //    findParaGoodsNoSt.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNoSt);
            //}

            //// ���i�}�X�^�C���|�[�g�p�i�ԏI��
            //if (IsValidParameter(GoodsPriceUWork.GoodsNoEd))
            //{
            //    sqlText += "  AND GOODSNORF <= @FINDGOODSNOED" + Environment.NewLine;
            //    SqlParameter findParaGoodsNoEd = sqlCommand.Parameters.Add("@FINDGOODSNOED", SqlDbType.NVarChar);
            //    findParaGoodsNoEd.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNoEd);
            //}
            ////----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
            //----- DEL 2015/07/24 �c���� Redmine#45693 -----------------<<<<<

            // ���i�J�n��
            if (GoodsPriceUWork.PriceStartDate != DateTime.MinValue)
            {
                sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);
                findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);
            }

            //�_���폜�敪
            bool useLogicalMode = false;
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                useLogicalMode = true;
                sqlText += "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                     (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                useLogicalMode = true;
                sqlText += " AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE";
            }
            if (useLogicalMode)
            {
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return sqlText;
        }
        //add by liusy #35805 2013/06/14---------->>>>>
        /// <summary>
        /// Search���������񐶐��{�����l�ݒ�(�폜�O�̗��p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="GoodsPriceUWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>�N�G��������</returns>
        /// <br>Note       : ���i���i�}�X�^�̌����p�N�G��������𐶐����Ė߂��܂�</br>
        /// <br>Programmer : liusy</br>
        private string CreateQueryBeforeDelString(ref SqlCommand sqlCommand, GoodsPriceUWork GoodsPriceUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string sqlText = String.Empty;

            sqlText += "SELECT  " + Environment.NewLine;
            sqlText += " UPDATEDATETIMERF," + Environment.NewLine;
            sqlText += " ENTERPRISECODERF," + Environment.NewLine;
            sqlText += " GOODSMAKERCDRF," + Environment.NewLine;
            sqlText += " GOODSNORF," + Environment.NewLine;
            sqlText += " PRICESTARTDATERF " + Environment.NewLine;
            sqlText += " FROM" + Environment.NewLine;
            sqlText += "  GOODSPRICEURF" + Environment.NewLine;
            sqlText += "WHERE" + Environment.NewLine;
            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;

            // ��ƃR�[�h
            SqlParameter findparaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findparaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);

            // ���[�J�[�R�[�h
            if (IsValidParameter(GoodsPriceUWork.GoodsMakerCd, false))
            {
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
            }

            // �i��
            if (IsValidParameter(GoodsPriceUWork.GoodsNo))
            {
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
            }

            // ���i�J�n��
            if (GoodsPriceUWork.PriceStartDate != DateTime.MinValue)
            {
                sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);
                findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);
            }

            //�_���폜�敪
            bool useLogicalMode = false;
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                useLogicalMode = true;
                sqlText += "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                     (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                useLogicalMode = true;
                sqlText += " AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE";
            }
            if (useLogicalMode)
            {
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return sqlText;
        }
        //add by liusy #35805 2013/06/14----------<<<<<
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS�Ή�</br>
        /// <br>Programmer : 21024�@���X�؁@��</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private string MakeSyncWhereString( ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork )
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //�����V���N�̏ꍇ�͍X�V���t�͈͎̔w��
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF >= @FINDUPDATEDATETIMEST " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        /// <summary>
        /// string���L���ȃp�����[�^���ǂ����𔻒f����
        /// </summary>
        private bool IsValidParameter(string value)
        {
            return !String.IsNullOrEmpty(value);
        }
        /// <summary>
        /// int���L���ȃp�����[�^���ǂ����𔻒f����
        /// </summary>
        private bool IsValidParameter(int value, bool includeZero)
        {
            if (includeZero)
                return value >= 0;
            return value > 0;
        }
        /// <summary>
        /// DateTime���L���ȃp�����[�^���ǂ����𔻒f����
        /// </summary>
        private bool IsValidParameter(DateTime value)
        {
            return value > DateTime.MinValue;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsPriceUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsPriceUWork</returns>
        /// <remarks>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS�Ή�</br>
        /// <br>Programmer : 21024�@���X�؁@��</br>
        /// <br>Date       : 2007.08.30</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// </remarks>
        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
        //private GoodsPriceUWork CopyToGoodsPriceUWorkFromReader(ref SqlDataReader myReader)
        private GoodsPriceUWork CopyToGoodsPriceUWorkFromReader(ref SqlDataReader myReader, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
        {
            GoodsPriceUWork wkGoodsPriceUWork = new GoodsPriceUWork();

            #region �N���X�֊i�[
            wkGoodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsPriceUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            //wkGoodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = wkGoodsPriceUWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = wkGoodsPriceUWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = wkGoodsPriceUWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // �ϊ��������s
            convertDoubleRelease.ReleaseProc();
            wkGoodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<

            wkGoodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            wkGoodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            wkGoodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            wkGoodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            #endregion

            return wkGoodsPriceUWork;
        }
        //add by liusy #35805 2013/06/14---------->>>>>
        /// <summary>
        /// �N���X�i�[���� Reader(�폜�O�̗��p) �� GoodsPriceUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsPriceUWork</returns>
        /// <remarks>
        /// <br>Programmer : liusy</br>
        /// <br>Date       : 2013/06/14</br>
        /// </remarks>
        private GoodsPriceUWork CopyToGoodsPriceUWorkBeforeDelFromReader(ref SqlDataReader myReader)
        {


            GoodsPriceUWork wkGoodsPriceUWork = new GoodsPriceUWork();
            #region �N���X�֊i�[
            wkGoodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsPriceUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            #endregion

            return wkGoodsPriceUWork;
        }
        //add by liusy #35805 2013/06/14----------<<<<<
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GoodsPriceUWork[] GoodsPriceUWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is GoodsPriceUWork)
                    {
                        GoodsPriceUWork wkGoodsPriceUWork = paraobj as GoodsPriceUWork;
                        if (wkGoodsPriceUWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkGoodsPriceUWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            GoodsPriceUWorkArray = (GoodsPriceUWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GoodsPriceUWork[]));
                        }
                        catch (Exception) { }
                        if (GoodsPriceUWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(GoodsPriceUWorkArray);
                        }
                        else
                        {
                            try
                            {
                                GoodsPriceUWork wkGoodsPriceUWork = (GoodsPriceUWork)XmlByteSerializer.Deserialize(byteArray, typeof(GoodsPriceUWork));
                                if (wkGoodsPriceUWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkGoodsPriceUWork);
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
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
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

