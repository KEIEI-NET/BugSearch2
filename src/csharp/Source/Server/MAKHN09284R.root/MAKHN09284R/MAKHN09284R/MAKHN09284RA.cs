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
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>> 
using System.Xml;
using System.IO;
using Microsoft.Win32;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�}�X�^�i���[�U�[�o�^���jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.01.24</br>
    /// <br></br>
    /// <br>Update Note: DC.NS�p�ɏC��</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2007.08.15</br>
    /// <br></br>
    /// <br>Update Note: PM.NS�p�ɏC��</br>
    /// <br>Programmer : 20081�@�D�c �E�l</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br>Update Note: 2014.02.10 ���z</br>
    /// <br>           : Redmine#41976 ���i�}�X�^�U�̒ǉ�</br>
    /// <br>Update Note: 2015/05/20 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11175183-00</br>
    /// <br>           : Redmine#45693 �C�X�R�@���i�}�X�^�C���|�[�g OutOfMemory�����Ή�</br>
    /// <br>Update Note: 2015/07/24 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11175183-00</br>
    /// <br>           : Redmine#45693 �C�X�R�@���i�}�X�^�C���|�[�g �ꎞ�e�[�u����JOIN���Č�������ύX</br>
    /// <br>Update Note: 2020/08/28 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11600006-00</br>
    /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br> 
    /// </remarks>
    [Serializable]
    public class GoodsUDB : RemoteDB, IGoodsUDB, IGetSyncdataList
    {
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>> 
        // �`�[�X�V�^�C���A�E�g���Ԑݒ�t�@�C��
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XML�t�@�C�����������̃f�t�H���g�l
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        /// </remarks>
        public GoodsUDB()
            :
            base("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork", "GOODSURF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j���LIST��߂��܂�
        /// </summary>
        /// <param name="goodsUWork">��������</param>
        /// <param name="paragoodsUWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j���LIST��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        public int Search(out object goodsUWork, object paragoodsUWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsUWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGoodsUProc(out goodsUWork, paragoodsUWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsUDB.Search");
                goodsUWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objgoodsUWork">��������</param>
        /// <param name="paragoodsUWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        public int SearchGoodsUProc(out object objgoodsUWork, object paragoodsUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsUWork goodsuWork = null;

            ArrayList goodsuWorkList = paragoodsUWork as ArrayList;
            if (goodsuWorkList == null)
            {
                goodsuWork = paragoodsUWork as GoodsUWork;
            }
            else
            {
                if (goodsuWorkList.Count > 0)
                    goodsuWork = goodsuWorkList[0] as GoodsUWork;
            }

            int status = SearchGoodsUProc(out goodsuWorkList, goodsuWork, readMode, logicalMode, ref sqlConnection);
            objgoodsUWork = goodsuWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsuWorkList">��������</param>
        /// <param name="goodsuWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        public int SearchGoodsUProc(out ArrayList goodsuWorkList, GoodsUWork goodsuWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchGoodsUProcProc(out goodsuWorkList, goodsuWork, readMode, logicalMode, ref sqlConnection);
        }

        //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j���̌���[���i�}�X�^�C���|�[�g��p]
        /// </summary>
        /// <param name="goodsuWorkList"></param>
        /// <param name="goodsuWork"></param>
        /// <param name="tempTalName"></param>
        /// <param name="logicalMode"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j���̌���[���i�}�X�^�C���|�[�g��p]</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2015/05/20</br>
        /// <br>Update Note: 2015/07/24 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11175183-00</br>
        /// <br>           : Redmine#45693 �C�X�R�@���i�}�X�^�C���|�[�g �ꎞ�e�[�u����JOIN���Č�������ύX</br>
        /// </remarks>
        //public int SearchGoodsUForGoodsImport(out ArrayList goodsuWorkList, GoodsUWork goodsuWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection) // DEL 2015/07/24 �c���� Redmine#45693
        public int SearchGoodsUForGoodsImport(out ArrayList goodsuWorkList, GoodsUWork goodsuWork, string tempTalName, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection) // ADD 2015/07/24 �c���� Redmine#45693
        {
            //return this.SearchGoodsUProcProc(out goodsuWorkList, goodsuWork, readMode, logicalMode, ref sqlConnection); // DEL 2015/07/24 �c���� Redmine#45693
            return this.SearchGoodsUProcProcForGoodsImport(out goodsuWorkList, goodsuWork, tempTalName, logicalMode, ref sqlConnection); // ADD 2015/07/24 �c���� Redmine#45693
        }

        //----- ADD 2015/07/24 �c���� Redmine#45693 ------->>>>>
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j���̌���[���i�}�X�^�C���|�[�g��p]
        /// </summary>
        /// <param name="goodsuWorkList"></param>
        /// <param name="goodsuWork"></param>
        /// <param name="tempTalName"></param>
        /// <param name="logicalMode"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ꎞ�e�[�u����JOIN���Č�������ύX</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2015/07/24</br>
        /// </remarks>
        private int SearchGoodsUProcProcForGoodsImport(out ArrayList goodsuWorkList, GoodsUWork goodsuWork, string tempTalName, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlText.Append("SELECT" + Environment.NewLine);
                sqlText.Append("   GOODS.CREATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.ENTERPRISECODERF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.GOODSMAKERCDRF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.GOODSNORF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.GOODSNAMERF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.GOODSNAMEKANARF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.JANRF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.BLGOODSCODERF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.DISPLAYORDERRF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.GOODSRATERANKRF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.OFFERDATERF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.GOODSKINDCODERF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.GOODSNOTE1RF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.GOODSNOTE2RF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.UPDATEDATERF" + Environment.NewLine);
                sqlText.Append("  ,GOODS.OFFERDATADIVRF" + Environment.NewLine);
                sqlText.Append("FROM" + Environment.NewLine);
                sqlText.Append("  GOODSURF AS GOODS WITH(READUNCOMMITTED) " + Environment.NewLine);
                sqlText.Append("INNER JOIN " + tempTalName + " TEMTBL WITH(READUNCOMMITTED) " + Environment.NewLine);
                sqlText.Append("ON GOODS.ENTERPRISECODERF = TEMTBL.ENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append("AND GOODS.GOODSMAKERCDRF = TEMTBL.GOODSMAKERCDRF " + Environment.NewLine);
                sqlText.Append("AND GOODS.GOODSNORF = TEMTBL.GOODSNORF " + Environment.NewLine);

                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                sqlText = new StringBuilder();
                sqlText.Append("WHERE" + Environment.NewLine);

                //��ƃR�[�h
                sqlText.Append(" GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);

                //���i���[�J�[�R�[�h
                if (goodsuWork.GoodsMakerCd != 0)
                {
                    sqlText.Append(" AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                }

                string wkstring = "";
                //�_���폜�敪
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = " AND GOODS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = " AND GOODS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    sqlText.Append(wkstring);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                sqlCommand.CommandText += sqlText.ToString();
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToGoodsUWorkFromReader(ref myReader));

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

            goodsuWorkList = al;

            return status;
        }
        //----- ADD 2015/07/24 �c���� Redmine#45693 -------<<<<<
        //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsuWorkList">��������</param>
        /// <param name="goodsuWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br>Update Note: 2015/05/20 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11175183-00</br>
        /// <br>           : Redmine#45693 �C�X�R�@���i�}�X�^�C���|�[�g OutOfMemory�����Ή�</br>
        private int SearchGoodsUProcProc(out ArrayList goodsuWorkList, GoodsUWork goodsuWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   GOODS.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.MAKERNAMERF" + Environment.NewLine;       // 2008.06.06 del
                sqlTxt += "  ,GOODS.GOODSNORF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.GOODSSHORTNAMERF" + Environment.NewLine;  // 2008.06.06 del
                sqlTxt += "  ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.JANRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                // 2008.06.06 del start ---------------------------->>
                //sqlTxt += "  ,GOODS.BLGOODSFULLNAMERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.UNITCODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.UNITNAMERF" + Environment.NewLine;
                // 2008.06.06 del end ------------------------------<<
                sqlTxt += "  ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                // 2008.06.06 del start ---------------------------->>
                //sqlTxt += "  ,GOODS.LARGEGOODSGANRECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.LARGEGOODSGANRENAMERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.MEDIUMGOODSGANRECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.MEDIUMGOODSGANRENAMERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.DETAILGOODSGANRECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.DETAILGOODSGANRENAMERF" + Environment.NewLine;
                // 2008.06.06 del end ------------------------------<<
                sqlTxt += "  ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                // 2008.06.06 del start ---------------------------->>
                //sqlTxt += "  ,GOODS.SALESORDERUNITRF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.GOODSSETDIVCDRF" + Environment.NewLine;
                // 2008.06.06 del end ------------------------------<<
                sqlTxt += "  ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.ENTERPRISEGANRENAMERF" + Environment.NewLine; // 2008.06.06 del
                sqlTxt += "  ,GOODS.UPDATEDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATADIVRF" + Environment.NewLine;
                sqlTxt += "FROM" + Environment.NewLine;
                sqlTxt += "  GOODSURF AS GOODS" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlTxt = "";
                sqlTxt += "WHERE" + Environment.NewLine;

                //��ƃR�[�h
                sqlTxt += " GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);

                //���i�ԍ�
                if (string.IsNullOrEmpty(goodsuWork.GoodsNo) == false)
                {
                    sqlTxt += " AND GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNo);
                }

                //----- DEL 2015/07/24 �c���� Redmine#45693 ----------------->>>>>
                ////----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                ////���i�}�X�^�C���|�[�g�p�J�n���i�ԍ�
                //if (string.IsNullOrEmpty(goodsuWork.GoodsNoSt) == false)
                //{
                //    sqlTxt += " AND GOODS.GOODSNORF>=@FINDGOODSNOST" + Environment.NewLine;
                //    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@FINDGOODSNOST", SqlDbType.NVarChar);
                //    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNoSt);
                //}
                ////���i�}�X�^�C���|�[�g�p�I�����i�ԍ�
                //if (string.IsNullOrEmpty(goodsuWork.GoodsNoEd) == false)
                //{
                //    sqlTxt += " AND GOODS.GOODSNORF<=@FINDGOODSNOED" + Environment.NewLine;
                //    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@FINDGOODSNOED", SqlDbType.NVarChar);
                //    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNoEd);
                //}
                ////----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                //----- DEL 2015/07/24 �c���� Redmine#45693 -----------------<<<<<

                //���i���[�J�[�R�[�h
                if (goodsuWork.GoodsMakerCd != 0)
                {
                    sqlTxt += " AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                }

                string wkstring = "";
                //�_���폜�敪
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = " AND GOODS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = " AND GOODS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    sqlTxt += wkstring;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                //sqlCommand.CommandText += MakeWhereString(ref sqlCommand, goodsuWork, logicalMode);
                sqlCommand.CommandText += sqlTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsUWorkFromReader(ref myReader));

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

            goodsuWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j��߂��܂�
        /// </summary>
        /// <param name="parabyte">GoodsUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                GoodsUWork goodsuWork = new GoodsUWork();

                // XML�̓ǂݍ���
                goodsuWork = (GoodsUWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsUWork));
                if (goodsuWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref goodsuWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(goodsuWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsUDB.Read");
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
        /// �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsuWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br></br>
        /// <br>UpDateNote       : DC.NS�p�Ƀ��C�A�E�g�ύX</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.15</br>
        public int ReadProc(ref GoodsUWork goodsuWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref goodsuWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsuWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br></br>
        /// <br>UpDateNote       : DC.NS�p�Ƀ��C�A�E�g�ύX</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.15</br>
        private int ReadProcProc(ref GoodsUWork goodsuWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   GOODS.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.MAKERNAMERF" + Environment.NewLine;      // 2008.06.06 del
                sqlTxt += "  ,GOODS.GOODSNORF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.GOODSSHORTNAMERF" + Environment.NewLine; // 2008.06.06 del
                sqlTxt += "  ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.JANRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                // 2008.06.06 del start ---------------------------->>
                //sqlTxt += "  ,GOODS.BLGOODSFULLNAMERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.UNITCODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.UNITNAMERF" + Environment.NewLine;
                // 2008.06.06 del end ------------------------------<<
                sqlTxt += "  ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                // 2008.06.06 del start ---------------------------->>
                //sqlTxt += "  ,GOODS.LARGEGOODSGANRECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.LARGEGOODSGANRENAMERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.MEDIUMGOODSGANRECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.MEDIUMGOODSGANRENAMERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.DETAILGOODSGANRECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.DETAILGOODSGANRENAMERF" + Environment.NewLine;
                // 2008.06.06 del end ------------------------------<<
                sqlTxt += "  ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                // 2008.06.06 del start ---------------------------->>
                //sqlTxt += "  ,GOODS.SALESORDERUNITRF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.GOODSSETDIVCDRF" + Environment.NewLine;
                // 2008.06.06 del end ------------------------------<<
                sqlTxt += "  ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.ENTERPRISEGANRENAMERF" + Environment.NewLine; // 2008.06.06 del
                sqlTxt += "  ,GOODS.UPDATEDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATADIVRF" + Environment.NewLine;
                sqlTxt += "FROM" + Environment.NewLine;
                sqlTxt += "  GOODSURF AS GOODS" + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                sqlTxt += "  GOODS.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "  AND GOODS.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlTxt += "  AND GOODS.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        goodsuWork = CopyToGoodsUWorkFromReader(ref myReader);
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

        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20096 �����@����</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br></br>
        /// <br>UpDateNote : DC.NS�p�ɏC��</br>
        /// <br>Programmer : 22008 �����@���n</br>
        /// <br>Date       : 2007.08.15</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }

        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20096 �����@����</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br></br>
        /// <br>UpDateNote : DC.NS�p�ɏC��</br>
        /// <br>Programmer : 22008 �����@���n</br>
        /// <br>Date       : 2007.08.15</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   GOODS.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.MAKERNAMERF" + Environment.NewLine; // 2008.06.06 del
                sqlTxt += "  ,GOODS.GOODSNORF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.GOODSSHORTNAMERF" + Environment.NewLine; // 2008.06.06 del
                sqlTxt += "  ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.JANRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                // 2008.06.06 del start -------------------------------->>
                //sqlTxt += "  ,GOODS.BLGOODSFULLNAMERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.UNITCODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.UNITNAMERF" + Environment.NewLine;
                // 2008.06.06 del end ----------------------------------<<
                sqlTxt += "  ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                // 2008.06.06 del start -------------------------------->>
                //sqlTxt += "  ,GOODS.LARGEGOODSGANRECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.LARGEGOODSGANRENAMERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.MEDIUMGOODSGANRECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.MEDIUMGOODSGANRENAMERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.DETAILGOODSGANRECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.DETAILGOODSGANRENAMERF" + Environment.NewLine;
                // 2008.06.06 del end ----------------------------------<<
                sqlTxt += "  ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                // 2008.06.06 del start -------------------------------->>
                //sqlTxt += "  ,GOODS.SALESORDERUNITRF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.GOODSSETDIVCDRF" + Environment.NewLine;
                // 2008.06.06 del end ----------------------------------<<
                sqlTxt += "  ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GOODS.ENTERPRISEGANRENAMERF" + Environment.NewLine; // 2008.06.06 del
                sqlTxt += "  ,GOODS.UPDATEDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATADIVRF" + Environment.NewLine;
                sqlTxt += "FROM" + Environment.NewLine;
                sqlTxt += "  GOODSURF AS GOODS" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsUWorkFromReader(ref myReader));

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

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        public int Write(ref object goodsUWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(goodsUWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteGoodsUProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                goodsUWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsUDB.Write(ref object goodsUWork)");
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
        /// ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsUWorkList">GoodsUWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br></br>
        /// <br>UpDateNote : DC.NS�p�ɏC��</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.15</br>
        public int WriteGoodsUProc(ref ArrayList goodsUWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteGoodsUProcProc(ref goodsUWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsUWorkList">GoodsUWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br></br>
        /// <br>UpDateNote : DC.NS�p�ɏC��</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.15</br>
        /// <br>Update Note: 2014.02.10 ���z</br>
        /// <br>           : Redmine#41976 �K�i/�׎p/POS.No/���[�J�[�i��/�X�V�����U�̒ǉ�</br>
        /// <br>Update Note: 2020/08/28 �c����</br>
        /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br> 
        private int WriteGoodsUProcProc(ref ArrayList goodsUWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // �R�}���h�^�C���A�E�g�i�b�j
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
            try
            {
                if (goodsUWorkList != null)
                {
                    string sqlTxt = "";
                    for (int i = 0; i < goodsUWorkList.Count; i++)
                    {
                        GoodsUWork goodsuWork = goodsUWorkList[i] as GoodsUWork;
                        GoodsUAWork goodsuaWork = CopyToGoodsUAWorkFromGoodsUWork(goodsuWork);// ADD 2014.02.10 ���z
                        sqlTxt = "";
                        sqlTxt += "SELECT" + Environment.NewLine;
                        sqlTxt += "   GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "  GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  AND GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNo);

                        sqlCommand.CommandTimeout = dbCommandTimeout; //ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή�
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != goodsuWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (goodsuWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlTxt = "";

                            sqlTxt += "UPDATE GOODSURF" + Environment.NewLine;
                            sqlTxt += "SET" + Environment.NewLine;
                            sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            //sqlTxt += " , MAKERNAMERF=@MAKERNAME" + Environment.NewLine; // 2008.06.06 del
                            sqlTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            sqlTxt += " , GOODSNAMERF=@GOODSNAME" + Environment.NewLine;
                            //sqlTxt += " , GOODSSHORTNAMERF=@GOODSSHORTNAME" + Environment.NewLine; // 2008.06.06 del
                            sqlTxt += " , GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;
                            sqlTxt += " , JANRF=@JAN" + Environment.NewLine;
                            sqlTxt += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            // 2008.06.06 del start -------------------------->>
                            //sqlTxt += " , BLGOODSFULLNAMERF=@BLGOODSFULLNAME" + Environment.NewLine;
                            //sqlTxt += " , UNITCODERF=@UNITCODE" + Environment.NewLine;
                            //sqlTxt += " , UNITNAMERF=@UNITNAME" + Environment.NewLine;
                            // 2008.06.06 del end ----------------------------<<
                            sqlTxt += " , DISPLAYORDERRF=@DISPLAYORDER" + Environment.NewLine;
                            // 2008.06.06 del start -------------------------->>
                            //sqlTxt += " , LARGEGOODSGANRECODERF=@LARGEGOODSGANRECODE" + Environment.NewLine;
                            //sqlTxt += " , LARGEGOODSGANRENAMERF=@LARGEGOODSGANRENAME" + Environment.NewLine;
                            //sqlTxt += " , MEDIUMGOODSGANRECODERF=@MEDIUMGOODSGANRECODE" + Environment.NewLine;
                            //sqlTxt += " , MEDIUMGOODSGANRENAMERF=@MEDIUMGOODSGANRENAME" + Environment.NewLine;
                            //sqlTxt += " , DETAILGOODSGANRECODERF=@DETAILGOODSGANRECODE" + Environment.NewLine;
                            //sqlTxt += " , DETAILGOODSGANRENAMERF=@DETAILGOODSGANRENAME" + Environment.NewLine;
                            // 2008.06.06 del end ----------------------------<<
                            sqlTxt += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                            // 2008.06.06 del start -------------------------->>
                            //sqlTxt += " , SALESORDERUNITRF=@SALESORDERUNIT" + Environment.NewLine;
                            //sqlTxt += " , GOODSSETDIVCDRF=@GOODSSETDIVCD" + Environment.NewLine;
                            // 2008.06.06 del end ----------------------------<<
                            sqlTxt += " , TAXATIONDIVCDRF=@TAXATIONDIVCD" + Environment.NewLine;
                            sqlTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                            sqlTxt += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                            sqlTxt += " , GOODSKINDCODERF=@GOODSKINDCODE" + Environment.NewLine;
                            sqlTxt += " , GOODSNOTE1RF=@GOODSNOTE1" + Environment.NewLine;
                            sqlTxt += " , GOODSNOTE2RF=@GOODSNOTE2" + Environment.NewLine;
                            sqlTxt += " , GOODSSPECIALNOTERF=@GOODSSPECIALNOTE" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE" + Environment.NewLine;
                            //sqlTxt += " , ENTERPRISEGANRENAMERF=@ENTERPRISEGANRENAME" + Environment.NewLine; // 2008.06.06 del
                            sqlTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                            sqlTxt += " , OFFERDATADIVRF=@OFFERDATADIVRF" + Environment.NewLine;
                            sqlTxt += "WHERE" + Environment.NewLine;
                            sqlTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                            sqlCommand.CommandText = sqlTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsuWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            // -------- ADD START 2014.02.10 ���z -------->>>>>
                            // ���i�}�X�^�\���p�I�v�V��������
                            if (goodsuWork.OptKonmanGoodsMstCtl == 1)
                            {
                                if (myReader.IsClosed == false) myReader.Close();
                                // �K�i/�׎p/POS.No/���[�J�[�i�Ԃ̂����ꂩ���ݒ肳��Ă���ꍇ
                                if (!string.IsNullOrEmpty(goodsuWork.Standard) ||
                                    !string.IsNullOrEmpty(goodsuWork.Packing) ||
                                    !string.IsNullOrEmpty(goodsuWork.PosNo) ||
                                    !string.IsNullOrEmpty(goodsuWork.MakerGoodsNo))
                                {
                                    // ���i�}�X�^�U����o�^�A�X�V���܂�
                                    status = this.WriteGoodsUAProc(ref goodsuaWork, ref sqlConnection, ref sqlTransaction);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        goodsuWork.CreateDateTimeA = goodsuaWork.CreateDateTime;
                                        goodsuWork.UpdateDateTimeA = goodsuaWork.UpdateDateTime;
                                        goodsuWork.FileHeaderGuidA = goodsuaWork.FileHeaderGuid;
                                    }
                                    else
                                    {
                                        sqlCommand.Cancel();
                                        if (myReader.IsClosed == false) myReader.Close();
                                        return status;
                                    }
                                }
                                else
                                {
                                    // ���i�}�X�^�U���𕨗��폜���܂�
                                    status = this.DeleteGoodsUAProc(goodsuaWork, ref sqlConnection, ref sqlTransaction);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        goodsuWork.UpdateDateTimeA = DateTime.MinValue;
                                    }
                                    else
                                    {
                                        sqlCommand.Cancel();
                                        if (myReader.IsClosed == false) myReader.Close();
                                        return status;
                                    }
                                }
                            }
                            // -------- ADD END 2014.02.10 ���z --------<<<<<
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (goodsuWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlTxt = "" + Environment.NewLine;
                            sqlTxt += "INSERT INTO GOODSURF" + Environment.NewLine;
                            sqlTxt += "  (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            //sqlTxt += "  ,MAKERNAMERF" + Environment.NewLine; // 2008.06.06 del
                            sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSNAMERF" + Environment.NewLine;
                            //sqlTxt += "  ,GOODSSHORTNAMERF" + Environment.NewLine; // 2008.06.06 del
                            sqlTxt += "  ,GOODSNAMEKANARF" + Environment.NewLine;
                            sqlTxt += "  ,JANRF" + Environment.NewLine;
                            sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                            // 2008.06.06 del start -------------------------->>
                            //sqlTxt += "  ,BLGOODSFULLNAMERF" + Environment.NewLine;
                            //sqlTxt += "  ,UNITCODERF" + Environment.NewLine;
                            //sqlTxt += "  ,UNITNAMERF" + Environment.NewLine;
                            // 2008.06.06 del end ----------------------------<<
                            sqlTxt += "  ,DISPLAYORDERRF" + Environment.NewLine;
                            // 2008.06.06 del start -------------------------->>
                            //sqlTxt += "  ,LARGEGOODSGANRECODERF" + Environment.NewLine;
                            //sqlTxt += "  ,LARGEGOODSGANRENAMERF" + Environment.NewLine;
                            //sqlTxt += "  ,MEDIUMGOODSGANRECODERF" + Environment.NewLine;
                            //sqlTxt += "  ,MEDIUMGOODSGANRENAMERF" + Environment.NewLine;
                            //sqlTxt += "  ,DETAILGOODSGANRECODERF" + Environment.NewLine;
                            //sqlTxt += "  ,DETAILGOODSGANRENAMERF" + Environment.NewLine;
                            // 2008.06.06 del end ----------------------------<<
                            sqlTxt += "  ,GOODSRATERANKRF" + Environment.NewLine;
                            // 2008.06.06 del start -------------------------->>
                            //sqlTxt += "  ,SALESORDERUNITRF" + Environment.NewLine;
                            //sqlTxt += "  ,GOODSSETDIVCDRF" + Environment.NewLine;
                            // 2008.06.06 del end ----------------------------<<
                            sqlTxt += "  ,TAXATIONDIVCDRF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                            sqlTxt += "  ,OFFERDATERF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSKINDCODERF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSNOTE1RF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSNOTE2RF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSSPECIALNOTERF" + Environment.NewLine;
                            sqlTxt += "  ,ENTERPRISEGANRECODERF" + Environment.NewLine;
                            //sqlTxt += "  ,ENTERPRISEGANRENAMERF" + Environment.NewLine; // 2008.06.06 del
                            sqlTxt += "  ,UPDATEDATERF" + Environment.NewLine;
                            sqlTxt += " , OFFERDATADIVRF" + Environment.NewLine;
                            sqlTxt += "  )" + Environment.NewLine;
                            sqlTxt += "VALUES" + Environment.NewLine;
                            sqlTxt += "  (@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            //sqlTxt += "  ,@MAKERNAME" + Environment.NewLine; // 2008.06.06 del
                            sqlTxt += "  ,@GOODSNO" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSNAME" + Environment.NewLine;
                            //sqlTxt += "  ,@GOODSSHORTNAME" + Environment.NewLine; // 2008.06.06 del
                            sqlTxt += "  ,@GOODSNAMEKANA" + Environment.NewLine;
                            sqlTxt += "  ,@JAN" + Environment.NewLine;
                            sqlTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                            // 2008.06.06 del start -------------------------->>
                            //sqlTxt += "  ,@BLGOODSFULLNAME" + Environment.NewLine;
                            //sqlTxt += "  ,@UNITCODE" + Environment.NewLine;
                            //sqlTxt += "  ,@UNITNAME" + Environment.NewLine;
                            // 2008.06.06 del end ----------------------------<<
                            sqlTxt += "  ,@DISPLAYORDER" + Environment.NewLine;
                            // 2008.06.06 del start -------------------------->>
                            //sqlTxt += "  ,@LARGEGOODSGANRECODE" + Environment.NewLine;
                            //sqlTxt += "  ,@LARGEGOODSGANRENAME" + Environment.NewLine;
                            //sqlTxt += "  ,@MEDIUMGOODSGANRECODE" + Environment.NewLine;
                            //sqlTxt += "  ,@MEDIUMGOODSGANRENAME" + Environment.NewLine;
                            //sqlTxt += "  ,@DETAILGOODSGANRECODE" + Environment.NewLine;
                            //sqlTxt += "  ,@DETAILGOODSGANRENAME" + Environment.NewLine;
                            // 2008.06.06 del end ----------------------------<<
                            sqlTxt += "  ,@GOODSRATERANK" + Environment.NewLine;
                            // 2008.06.06 del start -------------------------->>
                            //sqlTxt += "  ,@SALESORDERUNIT" + Environment.NewLine;
                            //sqlTxt += "  ,@GOODSSETDIVCD" + Environment.NewLine;
                            // 2008.06.06 del end ----------------------------<<
                            sqlTxt += "  ,@TAXATIONDIVCD" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                            sqlTxt += "  ,@OFFERDATE" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSKINDCODE" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSNOTE1" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSNOTE2" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSSPECIALNOTE" + Environment.NewLine;
                            sqlTxt += "  ,@ENTERPRISEGANRECODE" + Environment.NewLine;
                            //sqlTxt += "  ,@ENTERPRISEGANRENAME" + Environment.NewLine; // 2008.06.06 del
                            sqlTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                            sqlTxt += "  ,@OFFERDATADIVRF" + Environment.NewLine;
                            sqlTxt += "  )" + Environment.NewLine;

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = sqlTxt;
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsuWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            // -------- ADD START 2014.02.10 ���z -------->>>>>
                            // ���i�}�X�^�\���p�I�v�V��������
                            if (goodsuWork.OptKonmanGoodsMstCtl == 1)
                            {
                                // �K�i/�׎p/POS.No/���[�J�[�i�Ԃ̂����ꂩ���ݒ肳��Ă���ꍇ
                                if (!string.IsNullOrEmpty(goodsuWork.Standard) ||
                                    !string.IsNullOrEmpty(goodsuWork.Packing) ||
                                    !string.IsNullOrEmpty(goodsuWork.PosNo) ||
                                    !string.IsNullOrEmpty(goodsuWork.MakerGoodsNo))
                                {
                                    if (myReader.IsClosed == false) myReader.Close();
                                    // ���i�}�X�^�U����o�^�A�X�V���܂�
                                    status = this.WriteGoodsUAProc(ref goodsuaWork, ref sqlConnection, ref sqlTransaction);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        goodsuWork.CreateDateTimeA = goodsuaWork.CreateDateTime;
                                        goodsuWork.UpdateDateTimeA = goodsuaWork.UpdateDateTime;
                                        goodsuWork.FileHeaderGuidA = goodsuaWork.FileHeaderGuid;
                                    }
                                    else
                                    {
                                        sqlCommand.Cancel();
                                        if (myReader.IsClosed == false) myReader.Close();
                                        return status;
                                    }
                                }
                            }
                            // -------- ADD END 2014.02.10 ���z --------<<<<<
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
                        //SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar); // 2008.06.06 del
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                        //SqlParameter paraGoodsShortName = sqlCommand.Parameters.Add("@GOODSSHORTNAME", SqlDbType.NVarChar); // 2008.06.06 del
                        SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                        SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        // 2008.06.06 del start -------------------------->>
                        //SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                        //SqlParameter paraUnitCode = sqlCommand.Parameters.Add("@UNITCODE", SqlDbType.Int);
                        //SqlParameter paraUnitName = sqlCommand.Parameters.Add("@UNITNAME", SqlDbType.NVarChar);
                        // 2008.06.06 del end ----------------------------<<
                        SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                        // 2008.06.06 del start -------------------------->>
                        //SqlParameter paraLargeGoodsGanreCode = sqlCommand.Parameters.Add("@LARGEGOODSGANRECODE", SqlDbType.NChar);
                        //SqlParameter paraLargeGoodsGanreName = sqlCommand.Parameters.Add("@LARGEGOODSGANRENAME", SqlDbType.NVarChar);
                        //SqlParameter paraMediumGoodsGanreCode = sqlCommand.Parameters.Add("@MEDIUMGOODSGANRECODE", SqlDbType.NChar);
                        //SqlParameter paraMediumGoodsGanreName = sqlCommand.Parameters.Add("@MEDIUMGOODSGANRENAME", SqlDbType.NVarChar);
                        //SqlParameter paraDetailGoodsGanreCode = sqlCommand.Parameters.Add("@DETAILGOODSGANRECODE", SqlDbType.NChar);
                        //SqlParameter paraDetailGoodsGanreName = sqlCommand.Parameters.Add("@DETAILGOODSGANRENAME", SqlDbType.NVarChar);
                        // 2008.06.06 del end ----------------------------<<
                        SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                        // 2008.06.06 del start -------------------------->>
                        //SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
                        //SqlParameter paraGoodsSetDivCd = sqlCommand.Parameters.Add("@GOODSSETDIVCD", SqlDbType.Int);
                        // 2008.06.06 del end ----------------------------<<
                        SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                        SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNote1 = sqlCommand.Parameters.Add("@GOODSNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNote2 = sqlCommand.Parameters.Add("@GOODSNOTE2", SqlDbType.NVarChar);
                        SqlParameter paraGoodsSpecialNote = sqlCommand.Parameters.Add("@GOODSSPECIALNOTE", SqlDbType.NVarChar);
                        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                        //SqlParameter paraEnterpriseGanreName = sqlCommand.Parameters.Add("@ENTERPRISEGANRENAME", SqlDbType.NVarChar); // 2008.06.06 del
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIVRF", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsuWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsuWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsuWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsuWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsuWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsuWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.LogicalDeleteCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                        //paraMakerName.Value = SqlDataMediator.SqlSetString(goodsuWork.MakerName); // 2008.06.06 del
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNo);
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsName);
                        //paraGoodsShortName.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsShortName); // 2008.06.06 del
                        paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNameKana);
                        paraJan.Value = SqlDataMediator.SqlSetString(goodsuWork.Jan);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.BLGoodsCode);
                        // 2008.06.06 del start -------------------------->>
                        //paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(goodsuWork.BLGoodsFullName); 
                        //paraUnitCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.UnitCode);
                        //paraUnitName.Value = SqlDataMediator.SqlSetString(goodsuWork.UnitName);
                        // 2008.06.06 del end ----------------------------<<
                        paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(goodsuWork.DisplayOrder);
                        // 2008.06.06 del start -------------------------->>
                        //paraLargeGoodsGanreCode.Value = SqlDataMediator.SqlSetString(goodsuWork.LargeGoodsGanreCode);
                        //paraLargeGoodsGanreName.Value = SqlDataMediator.SqlSetString(goodsuWork.LargeGoodsGanreName);
                        //paraMediumGoodsGanreCode.Value = SqlDataMediator.SqlSetString(goodsuWork.MediumGoodsGanreCode);
                        //paraMediumGoodsGanreName.Value = SqlDataMediator.SqlSetString(goodsuWork.MediumGoodsGanreName);
                        //paraDetailGoodsGanreCode.Value = SqlDataMediator.SqlSetString(goodsuWork.DetailGoodsGanreCode);
                        //paraDetailGoodsGanreName.Value = SqlDataMediator.SqlSetString(goodsuWork.DetailGoodsGanreName);
                        // 2008.06.06 del end ----------------------------<<
                        paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsRateRank);
                        // 2008.06.06 del start -------------------------->>
                        //paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(goodsuWork.SalesOrderUnit);
                        //paraGoodsSetDivCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsSetDivCd);
                        // 2008.06.06 del end ----------------------------<<
                        paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.TaxationDivCd);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNoNoneHyphen);
                        paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsuWork.OfferDate);
                        paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsKindCode);
                        paraGoodsNote1.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNote1);
                        paraGoodsNote2.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNote2);
                        paraGoodsSpecialNote.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsSpecialNote);
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.EnterpriseGanreCode);
                        //paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseGanreName); // 2008.06.06 del
                        paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsuWork.UpdateDateTime);
                        paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(goodsuWork.OfferDataDiv);

                        goodsuWork.UpdateDate = goodsuWork.UpdateDateTime.Date;
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsuWork);
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

            goodsUWorkList = al;

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

        // -------- ADD START 2014.02.10 ���z -------->>>>>
        /// <summary>
        /// ���i�}�X�^�U����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsuaWork">���i�}�X�^�U�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�U����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : ���z</br>
        /// <br>Date       : 2014.02.10</br>
        /// <br></br>
        private int WriteGoodsUAProc(ref GoodsUAWork goodsuaWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (goodsuaWork != null)
                {
                    string sqlTxt = "";
                    sqlTxt += "SELECT" + Environment.NewLine;
                    sqlTxt += "   GOODSA.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "  ,GOODSA.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "FROM GOODSUARF AS GOODSA" + Environment.NewLine;
                    sqlTxt += "WHERE" + Environment.NewLine;
                    sqlTxt += "  GOODSA.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "  AND GOODSA.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += "  AND GOODSA.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                    //Select�R�}���h�̐���
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuaWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuaWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuaWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != goodsuaWork.UpdateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (goodsuaWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        sqlTxt = "";

                        sqlTxt += "UPDATE GOODSUARF" + Environment.NewLine;
                        sqlTxt += "SET" + Environment.NewLine;
                        sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                        sqlTxt += " , STANDARDRF=@STANDARD" + Environment.NewLine;
                        sqlTxt += " , PACKINGRF=@PACKING" + Environment.NewLine;
                        sqlTxt += " , POSNORF=@POSNO" + Environment.NewLine;
                        sqlTxt += " , MAKERGOODSNORF=@MAKERGOODSNO" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuaWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuaWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuaWork.GoodsNo);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsuaWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (goodsuaWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        sqlTxt = "" + Environment.NewLine;
                        sqlTxt += "INSERT INTO GOODSUARF" + Environment.NewLine;
                        sqlTxt += "  (CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                        sqlTxt += "  ,STANDARDRF" + Environment.NewLine;
                        sqlTxt += "  ,PACKINGRF" + Environment.NewLine;
                        sqlTxt += "  ,POSNORF" + Environment.NewLine;
                        sqlTxt += "  ,MAKERGOODSNORF" + Environment.NewLine;
                        sqlTxt += "  )" + Environment.NewLine;
                        sqlTxt += "VALUES" + Environment.NewLine;
                        sqlTxt += "  (@CREATEDATETIME" + Environment.NewLine;
                        sqlTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNO" + Environment.NewLine;
                        sqlTxt += "  ,@STANDARD" + Environment.NewLine;
                        sqlTxt += "  ,@PACKING" + Environment.NewLine;
                        sqlTxt += "  ,@POSNO" + Environment.NewLine;
                        sqlTxt += "  ,@MAKERGOODSNO" + Environment.NewLine;
                        sqlTxt += "  )" + Environment.NewLine;

                        //�V�K�쐬����SQL���𐶐�
                        sqlCommand.CommandText = sqlTxt;
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsuaWork;
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
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraStandard = sqlCommand.Parameters.Add("@STANDARD", SqlDbType.NVarChar);
                    SqlParameter paraPacking = sqlCommand.Parameters.Add("@PACKING", SqlDbType.NVarChar);
                    SqlParameter paraPosNo = sqlCommand.Parameters.Add("@POSNO", SqlDbType.NVarChar);
                    SqlParameter paraMakerGoodsNo = sqlCommand.Parameters.Add("@MAKERGOODSNO", SqlDbType.NVarChar);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsuaWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsuaWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuaWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsuaWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsuaWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsuaWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsuaWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsuaWork.LogicalDeleteCode);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuaWork.GoodsMakerCd);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuaWork.GoodsNo);
                    paraStandard.Value = SqlDataMediator.SqlSetString(goodsuaWork.Standard);
                    paraPacking.Value = SqlDataMediator.SqlSetString(goodsuaWork.Packing);
                    paraPosNo.Value = SqlDataMediator.SqlSetString(goodsuaWork.PosNo);
                    paraMakerGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuaWork.MakerGoodsNo);
                    #endregion

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
        // -------- ADD END 2014.02.10 ���z --------<<<<<
        #endregion

        // 2008.06.06 add start ----------------------------------------->>
        #region [ReadWrite]
        /// <summary>
        /// �w�肵�����i���}�X�^�ɑ��݂��Ȃ��ꍇ�ɐV�K�o�^���܂��B
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肵�����i���}�X�^�ɑ��݂��Ȃ��ꍇ�ɐV�K�o�^���܂��B</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int ReadWrite(ref object goodsUWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(goodsUWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = ReadWriteGoodsUProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                goodsUWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsUDB.Write(ref object goodsUWork)");
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
        /// �w�肵�����i���}�X�^�ɑ��݂��Ȃ��ꍇ�ɐV�K�o�^���܂��B(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsUWorkList">GoodsUWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肵�����i���}�X�^�ɑ��݂��Ȃ��ꍇ�ɐV�K�o�^���܂��B(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int ReadWriteGoodsUProc(ref ArrayList goodsUWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadWriteGoodsUProcProc(ref goodsUWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肵�����i���}�X�^�ɑ��݂��Ȃ��ꍇ�ɐV�K�o�^���܂��B(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsUWorkList">GoodsUWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肵�����i���}�X�^�ɑ��݂��Ȃ��ꍇ�ɐV�K�o�^���܂��B(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int ReadWriteGoodsUProcProc(ref ArrayList goodsUWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (goodsUWorkList != null)
                {
                    string sqlTxt = "";
                    for (int i = 0; i < goodsUWorkList.Count; i++)
                    {
                        GoodsUWork goodsuWork = goodsUWorkList[i] as GoodsUWork;
                        sqlTxt = "";
                        sqlTxt += "SELECT" + Environment.NewLine;
                        sqlTxt += "   GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "  GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  AND GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            // �������Ȃ�
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (goodsuWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlTxt = "" + Environment.NewLine;
                            sqlTxt += "INSERT INTO GOODSURF" + Environment.NewLine;
                            sqlTxt += "  (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSNAMERF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSNAMEKANARF" + Environment.NewLine;
                            sqlTxt += "  ,JANRF" + Environment.NewLine;
                            sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                            sqlTxt += "  ,DISPLAYORDERRF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSRATERANKRF" + Environment.NewLine;
                            sqlTxt += "  ,TAXATIONDIVCDRF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                            sqlTxt += "  ,OFFERDATERF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSKINDCODERF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSNOTE1RF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSNOTE2RF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSSPECIALNOTERF" + Environment.NewLine;
                            sqlTxt += "  ,ENTERPRISEGANRECODERF" + Environment.NewLine;
                            sqlTxt += "  ,UPDATEDATERF" + Environment.NewLine;
                            sqlTxt += "  )" + Environment.NewLine;
                            sqlTxt += "VALUES" + Environment.NewLine;
                            sqlTxt += "  (@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSNO" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSNAME" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSNAMEKANA" + Environment.NewLine;
                            sqlTxt += "  ,@JAN" + Environment.NewLine;
                            sqlTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                            sqlTxt += "  ,@DISPLAYORDER" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSRATERANK" + Environment.NewLine;
                            sqlTxt += "  ,@TAXATIONDIVCD" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                            sqlTxt += "  ,@OFFERDATE" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSKINDCODE" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSNOTE1" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSNOTE2" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSSPECIALNOTE" + Environment.NewLine;
                            sqlTxt += "  ,@ENTERPRISEGANRECODE" + Environment.NewLine;
                            sqlTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                            sqlTxt += "  )" + Environment.NewLine;

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = sqlTxt;
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsuWork;
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
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                        SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                        SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                        SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                        SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNote1 = sqlCommand.Parameters.Add("@GOODSNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNote2 = sqlCommand.Parameters.Add("@GOODSNOTE2", SqlDbType.NVarChar);
                        SqlParameter paraGoodsSpecialNote = sqlCommand.Parameters.Add("@GOODSSPECIALNOTE", SqlDbType.NVarChar);
                        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsuWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsuWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsuWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsuWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsuWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsuWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.LogicalDeleteCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNo);
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsName);
                        paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNameKana);
                        paraJan.Value = SqlDataMediator.SqlSetString(goodsuWork.Jan);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.BLGoodsCode);
                        paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(goodsuWork.DisplayOrder);
                        paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsRateRank);
                        paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.TaxationDivCd);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNoNoneHyphen);
                        paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsuWork.OfferDate);
                        paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsKindCode);
                        paraGoodsNote1.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNote1);
                        paraGoodsNote2.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNote2);
                        paraGoodsSpecialNote.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsSpecialNote);
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.EnterpriseGanreCode);
                        paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsuWork.UpdateDateTime);

                        goodsuWork.UpdateDate = goodsuWork.UpdateDateTime.Date;
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsuWork);
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

            goodsUWorkList = al;

            return status;
        }
        #endregion
        // 2008.06.06 add end -------------------------------------------<<

        #region [LogicalDelete]
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j����_���폜���܂�
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����_���폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        public int LogicalDelete(ref object goodsUWork)
        {
            return LogicalDeleteGoodsU(ref goodsUWork, 0);
        }

        /// <summary>
        /// �_���폜���i�}�X�^�i���[�U�[�o�^���j���𕜊����܂�
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���i�}�X�^�i���[�U�[�o�^���j���𕜊����܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        public int RevivalLogicalDelete(ref object goodsUWork)
        {
            return LogicalDeleteGoodsU(ref goodsUWork, 1);
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        private int LogicalDeleteGoodsU(ref object goodsUWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(goodsUWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteGoodsUProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "GoodsUDB.LogicalDeleteGoodsU :" + procModestr);

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
        /// ���i�}�X�^�i���[�U�[�o�^���j���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsUWorkList">GoodsUWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br></br>
        /// <br>UpDateNote : DC.NS�p�ɏC��</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.15</br>
        public int LogicalDeleteGoodsUProc(ref ArrayList goodsUWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteGoodsUProcProc(ref goodsUWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsUWorkList">GoodsUWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br></br>
        /// <br>UpDateNote : DC.NS�p�ɏC��</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.15</br>
        /// <br>Update Note: 2014.02.10 ���z</br>
        /// <br>           : Redmine#41976 �K�i/�׎p/POS.No/���[�J�[�i��/�X�V�����U�̒ǉ�</br>
        private int LogicalDeleteGoodsUProcProc(ref ArrayList goodsUWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (goodsUWorkList != null)
                {
                    for (int i = 0; i < goodsUWorkList.Count; i++)
                    {
                        GoodsUWork goodsuWork = goodsUWorkList[i] as GoodsUWork;
                        GoodsUAWork goodsuaWork = CopyToGoodsUAWorkFromGoodsUWork(goodsuWork);// ADD 2014.02.10 ���z
                        string sqlTxt = "";

                        sqlTxt += "SELECT" + Environment.NewLine;
                        sqlTxt += "   GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "      GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  AND GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != goodsuWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlTxt = "";
                            sqlTxt += "UPDATE GOODSURF" + Environment.NewLine;
                            sqlTxt += "SET" + Environment.NewLine;
                            sqlTxt += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "WHERE" + Environment.NewLine;
                            sqlTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                            sqlCommand.CommandText = sqlTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsuWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            // -------- ADD START 2014.02.10 ���z -------->>>>>
                            // ���i�}�X�^�\���p�I�v�V��������
                            if (goodsuWork.OptKonmanGoodsMstCtl == 1)
                            {
                                // �K�i/�׎p/POS.No/���[�J�[�i�Ԃ̂����ꂩ���ݒ肳��Ă���ꍇ
                                if (!string.IsNullOrEmpty(goodsuWork.Standard) ||
                                    !string.IsNullOrEmpty(goodsuWork.Packing) ||
                                    !string.IsNullOrEmpty(goodsuWork.PosNo) ||
                                    !string.IsNullOrEmpty(goodsuWork.MakerGoodsNo))
                                {
                                    if (myReader.IsClosed == false) myReader.Close();
                                    // ���i�}�X�^�U����_���폜�A�������܂�
                                    status = this.LogicalDeleteGoodsUAProc(ref goodsuaWork, procMode, ref sqlConnection, ref sqlTransaction);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        goodsuWork.CreateDateTimeA = goodsuaWork.CreateDateTime;
                                        goodsuWork.UpdateDateTimeA = goodsuaWork.UpdateDateTime;
                                        goodsuWork.FileHeaderGuidA = goodsuaWork.FileHeaderGuid;
                                    }
                                    else
                                    {
                                        sqlCommand.Cancel();
                                        if (myReader.IsClosed == false) myReader.Close();
                                        return status;
                                    }
                                }
                            }
                            // -------- ADD END 2014.02.10 ���z --------<<<<<
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
                            else if (logicalDelCd == 0) goodsuWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else goodsuWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) goodsuWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsuWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsuWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsuWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsuWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsuWork);
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

            goodsUWorkList = al;

            return status;

        }

        // -------- ADD START 2014.02.10 ���z -------->>>>>
        /// <summary>
        /// ���i�}�X�^�U���̘_���폜�A�����𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsuaWork">GoodsUAWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�U���̘_���폜�A�����𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : ���z</br>
        /// <br>Date       : 2014.02.10</br>
        /// <br></br>
        private int LogicalDeleteGoodsUAProc(ref GoodsUAWork goodsuaWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (goodsuaWork != null)
                {
                    string sqlTxt = "";

                    sqlTxt += "SELECT" + Environment.NewLine;
                    sqlTxt += "   GOODSA.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "  ,GOODSA.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "  ,GOODSA.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "FROM GOODSUARF AS GOODSA" + Environment.NewLine;
                    sqlTxt += "WHERE" + Environment.NewLine;
                    sqlTxt += "      GOODSA.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "  AND GOODSA.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += "  AND GOODSA.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                    //Select�R�}���h�̐���
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuaWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuaWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuaWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != goodsuaWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        //���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlTxt = "";
                        sqlTxt += "UPDATE GOODSUARF" + Environment.NewLine;
                        sqlTxt += "SET" + Environment.NewLine;
                        sqlTxt += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuaWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuaWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuaWork.GoodsNo);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsuaWork;
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
                        else if (logicalDelCd == 0) goodsuaWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                        else goodsuaWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1) goodsuaWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsuaWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsuaWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsuaWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsuaWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsuaWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();

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

            return status;

        }
        // -------- ADD END 2014.02.10 ���z --------<<<<<
        #endregion

        #region [Delete]
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">���i�}�X�^�i���[�U�[�o�^���j���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
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

                status = DeleteGoodsUProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "GoodsUDB.Delete");
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
        /// ���i�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsuWorkList">���i�}�X�^�i���[�U�[�o�^���j���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br></br>
        /// <br>Note       : DC.NS�p�ɕύX</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.15</br>
        public int DeleteGoodsUProc(ArrayList goodsuWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteGoodsUProcProc(goodsuWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsuWorkList">���i�}�X�^�i���[�U�[�o�^���j���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br></br>
        /// <br>Note       : DC.NS�p�ɕύX</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.15</br>
        /// <br>Update Note: 2014.02.10 ���z</br>
        /// <br>           : Redmine#41976 �K�i/�׎p/POS.No/���[�J�[�i��/�X�V�����U�̒ǉ�</br>
        private int DeleteGoodsUProcProc(ArrayList goodsuWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                string sqlTxt = "";
                for (int i = 0; i < goodsuWorkList.Count; i++)
                {
                    GoodsUWork goodsuWork = goodsuWorkList[i] as GoodsUWork;
                    GoodsUAWork goodsuaWork = CopyToGoodsUAWorkFromGoodsUWork(goodsuWork);// ADD 2014.02.10 ���z

                    sqlTxt = "";
                    sqlTxt += "SELECT" + Environment.NewLine;
                    sqlTxt += "   GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                    sqlTxt += "WHERE " + Environment.NewLine;
                    sqlTxt += "      GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "  AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += "  AND GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNo);


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != goodsuWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlTxt = "";
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += "FROM GOODSURF" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNo);

                        // -------- ADD START 2014.02.10 ���z -------->>>>>
                        // ���i�}�X�^�\���p�I�v�V��������
                        if (goodsuWork.OptKonmanGoodsMstCtl == 1)
                        {
                            // �K�i/�׎p/POS.No/���[�J�[�i�Ԃ̂����ꂩ���ݒ肳��Ă���ꍇ
                            if (!string.IsNullOrEmpty(goodsuWork.Standard) ||
                                !string.IsNullOrEmpty(goodsuWork.Packing) ||
                                !string.IsNullOrEmpty(goodsuWork.PosNo) ||
                                !string.IsNullOrEmpty(goodsuWork.MakerGoodsNo))
                            {
                                if (myReader.IsClosed == false) myReader.Close();
                                // ���i�}�X�^�U���𕨗��폜���܂�
                                status = this.DeleteGoodsUAProc(goodsuaWork, ref sqlConnection, ref sqlTransaction);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    goodsuWork.UpdateDateTimeA = DateTime.MinValue;
                                }
                                else
                                {
                                    sqlCommand.Cancel();
                                    if (myReader.IsClosed == false) myReader.Close();
                                    return status;
                                }
                            }
                        }
                        // -------- ADD END 2014.02.10 ���z --------<<<<<
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

        // -------- ADD START 2014.02.10 ���z -------->>>>>
        /// <summary>
        /// ���i�}�X�^�U���𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsuaWork">���i�}�X�^�U���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�U���𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p)</br>
        /// <br>Programmer : ���z</br>
        /// <br>Date       : 2014.02.10</br>
        /// <br></br>
        private int DeleteGoodsUAProc(GoodsUAWork goodsuaWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (goodsuaWork != null)
                {
                    string sqlTxt = "";
                    sqlTxt += "SELECT" + Environment.NewLine;
                    sqlTxt += "   GOODSA.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "  ,GOODSA.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "  ,GOODSA.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "FROM GOODSUARF AS GOODSA" + Environment.NewLine;
                    sqlTxt += "WHERE " + Environment.NewLine;
                    sqlTxt += "      GOODSA.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "  AND GOODSA.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += "  AND GOODSA.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuaWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuaWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuaWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != goodsuaWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlTxt = "";
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += "FROM GOODSUARF" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuaWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuaWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuaWork.GoodsNo);
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
        // -------- ADD END 2014.02.10 ���z --------<<<<<
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="goodsUWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsUWork goodsUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsUWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return retstring;
        }
        #endregion

        #region [�V���N�pWhere���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="syncServiceWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20096 �����@����</br>
        /// <br>Date       : 2007.05.08</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //�����V���N�̏ꍇ�͍X�V���t�͈͎̔w��
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsUWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br></br>
        /// <br>UpDateNote : DC.NS�p�ɏC��</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.15</br>
        /// </remarks>
        private GoodsUWork CopyToGoodsUWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsUWork wkGoodsUWork = new GoodsUWork();

            #region �N���X�֊i�[
            wkGoodsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

            wkGoodsUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            //wkGoodsUWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF")); // 2008.06.06 del
            wkGoodsUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsUWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            //wkGoodsUWork.GoodsShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSHORTNAMERF")); // 2008.06.06 del
            wkGoodsUWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkGoodsUWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkGoodsUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            // 2008.06.06 del start --------------------------------->>
            //wkGoodsUWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            //wkGoodsUWork.UnitCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNITCODERF"));
            //wkGoodsUWork.UnitName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITNAMERF"));
            // 2008.06.06 del end -----------------------------------<<
            wkGoodsUWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            // 2008.06.06 del start --------------------------------->>
            //wkGoodsUWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
            //wkGoodsUWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
            //wkGoodsUWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
            //wkGoodsUWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
            //wkGoodsUWork.DetailGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRECODERF"));
            //wkGoodsUWork.DetailGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRENAMERF"));
            // 2008.06.06 del end -----------------------------------<<
            wkGoodsUWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            // 2008.06.06 del start --------------------------------->>
            //wkGoodsUWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
            //wkGoodsUWork.GoodsSetDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSETDIVCDRF"));
            // 2008.06.06 del end -----------------------------------<<
            wkGoodsUWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkGoodsUWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkGoodsUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsUWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            wkGoodsUWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            wkGoodsUWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            wkGoodsUWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            wkGoodsUWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            //wkGoodsUWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF")); // 2008.06.06 del
            wkGoodsUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            wkGoodsUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));

            #endregion

            return wkGoodsUWork;
        }

        // -------- ADD START 2014.02.10 ���z -------->>>>>
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���i�}�X�^�T�ˏ��i�}�X�^�U�j
        /// </summary>
        /// <param name="goodsUWork">���i�}�X�^�T</param>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�U���쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���z</br>
        /// <br>Date       : 2014.02.10</br>
        /// <br></br>
        /// </remarks>
        private GoodsUAWork CopyToGoodsUAWorkFromGoodsUWork(GoodsUWork goodsUWork)
        {
            GoodsUAWork goodsUAWork = new GoodsUAWork();
            goodsUAWork.CreateDateTime = goodsUWork.CreateDateTimeA; // �쐬����
            goodsUAWork.UpdateDateTime = goodsUWork.UpdateDateTimeA; // �X�V����
            goodsUAWork.EnterpriseCode = goodsUWork.EnterpriseCode; // ��ƃR�[�h
            goodsUAWork.FileHeaderGuid = goodsUWork.FileHeaderGuidA; // GUID
            goodsUAWork.UpdEmployeeCode = goodsUWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            goodsUAWork.UpdAssemblyId1 = goodsUWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            goodsUAWork.UpdAssemblyId2 = goodsUWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            goodsUAWork.LogicalDeleteCode = goodsUWork.LogicalDeleteCode; // �_���폜�敪
            goodsUAWork.GoodsMakerCd = goodsUWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            goodsUAWork.GoodsNo = goodsUWork.GoodsNo; // ���i�ԍ�
            goodsUAWork.Standard = goodsUWork.Standard; // �K�i
            goodsUAWork.Packing = goodsUWork.Packing; // �׎p
            goodsUAWork.PosNo = goodsUWork.PosNo; // �o�n�rNo.
            goodsUAWork.MakerGoodsNo = goodsUWork.MakerGoodsNo; // ���[�J�[�i��

            return goodsUAWork;
        }
        // -------- ADD END 2014.02.10 ���z --------<<<<<
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GoodsUWork[] GoodsUWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is GoodsUWork)
                    {
                        GoodsUWork wkGoodsUWork = paraobj as GoodsUWork;
                        if (wkGoodsUWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkGoodsUWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            GoodsUWorkArray = (GoodsUWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GoodsUWork[]));
                        }
                        catch (Exception) { }
                        if (GoodsUWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(GoodsUWorkArray);
                        }
                        else
                        {
                            try
                            {
                                GoodsUWork wkGoodsUWork = (GoodsUWork)XmlByteSerializer.Deserialize(byteArray, typeof(GoodsUWork));
                                if (wkGoodsUWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkGoodsUWork);
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
        /// <br>Date       : 2007.01.24</br>
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
