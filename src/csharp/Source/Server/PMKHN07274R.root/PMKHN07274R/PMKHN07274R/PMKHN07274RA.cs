//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�Ǘ��}�X�^
// �v���O�����T�v   : ���i�Ǘ��}�X�^�̃G�N�X�|�[�g���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���R
// �� �� ��  2012/06/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : liusy
// �X �V ��  2012/09/24�@�C�����e : 2012/10/17�z�M���ARedmine#32367 
//                                  ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή��B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �� �� ��  2012/11/13  �C�����e : 2012/10/17�z�M���ARedmine#32367
//                                  ���i�}�X�^�G�N�X�|�[�g�ŕs����ۂ̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using System.Text;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�Ǘ��}�X�^�i�G�N�X�|�[�g�jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Ǘ��}�X�^�i�G�N�X�|�[�g�j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2012/06/05</br>
    /// <br>Note       : ���i�Ǘ����}�X�^���C�Ή��B(#32367)</br>
    /// <br>Programmer : liusy</br>
    /// <br>Date       : 2012/09/24</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>Note       : ���i�}�X�^�G�N�X�|�[�g�ŕs����ۂ̑Ή��B(#32367)</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2012/11/13</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class GoodsMngExportDB : RemoteDB, IGoodsMngExportDB
    {
        // --- ADD ������ 2012/11/13 for Redmine#32367---------->>>>>
        #region  �� Private cost
        //�ݒ���
        private const int SETKIND_1_VALUE = 0;
        private const int SETKIND_2_VALUE = 1;
        private const int SETKIND_3_VALUE = 2;
        private const int SETKIND_4_VALUE = 3;
        private const int SETKIND_5_VALUE = 4;
        #endregion
        // --- ADD ������ 2012/11/13 for Redmine#32367----------<<<<<
        /// <summary>
        /// ���i�Ǘ��}�X�^�i�G�N�X�|�[�g�jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>Note       : ���i�Ǘ����}�X�^���C�Ή��B(#32367)</br>
        /// <br>Programmer : liusy</br>
        /// <br>Date       : 2012/09/24</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        public GoodsMngExportDB()
            :
        base("MAKHN09526D", "Broadleaf.Application.Remoting.ParamData.GoodsMngWork", "GOODSMNGRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region ���i�Ǘ��}�X�^�̂ݎ擾����
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̏��i�Ǘ��}�X�^�i�G�N�X�|�[�g�jLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̏��i�Ǘ��}�X�^�i�G�N�X�|�[�g�jLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2012/06/05</br>
        /// </remarks>
        public int SearchGoodsMng(out object retObj, object paraObj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retObj = null;

            GoodsMngExportParamWork goodsMngExportParamWork = paraObj as GoodsMngExportParamWork;

            try
            {
                status = SearchGoodsMngProc(out retObj, goodsMngExportParamWork, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngExportDB.SearchGoodsMng Exception=" + ex.Message);
                retObj = new ArrayList();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̏��i�Ǘ��}�X�^�i�G�N�X�|�[�g�jLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retObj">�������ʁi���i�Ǘ��}�X�^�j</param>
        /// <param name="goodsMngExportParamWork">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̏��i�Ǘ��}�X�^�i�G�N�X�|�[�g�jLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2012/06/05</br>
        /// </remarks>
        private int SearchGoodsMngProc(out object retObj, GoodsMngExportParamWork goodsMngExportParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            retObj = null;

            ArrayList al = new ArrayList();   //���o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //���i�Ǘ��}�X�^�f�[�^�擾���s��
                status = SearchGoodsMngAction(ref al, ref sqlConnection, goodsMngExportParamWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngExportDB.SearchGoodsMngProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retObj = (object)al;

            return status;
        }
        #endregion

        #region ���i�Ǘ��}�X�^�f�[�^�擾�����i���s���j
        /// <summary>
        /// ���i�Ǘ��}�X�^�i�G�N�X�|�[�g�jLIST�擾����
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="goodsMngExportParamWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ��}�X�^�i�G�N�X�|�[�g�jLIST�擾�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2012/06/05</br>
        /// </remarks>
        private int SearchGoodsMngAction(ref ArrayList al, ref SqlConnection sqlConnection, GoodsMngExportParamWork goodsMngExportParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder selectTxt = new StringBuilder();

                sqlCommand = new SqlCommand("", sqlConnection);

                selectTxt.Append( "SELECT CREATEDATETIMERF" + 
                            ",     UPDATEDATETIMERF" + 
                            ",     ENTERPRISECODERF" + 
                            ",     FILEHEADERGUIDRF" + 
                            ",     UPDEMPLOYEECODERF" + 
                            ",     UPDASSEMBLYID1RF" + 
                            ",     UPDASSEMBLYID2RF" + 
                            ",     LOGICALDELETECODERF" + 
                            ",     SECTIONCODERF" + 
                            ",     GOODSMGROUPRF" + 
                            ",     GOODSMAKERCDRF" + 
                            ",     BLGOODSCODERF" + 
                            ",     GOODSNORF" + 
                            ",     SUPPLIERCDRF" + 
                            ",     SUPPLIERLOTRF" + 
                            " FROM" +
                            " GOODSMNGRF WITH (READUNCOMMITTED)");

                selectTxt.Append(MakeWhereString(ref sqlCommand, goodsMngExportParamWork, logicalMode));
                sqlCommand.CommandText = selectTxt.ToString();
                sqlCommand.CommandTimeout = 600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    GoodsMngWork goodsMngWork = new GoodsMngWork();
                    goodsMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    goodsMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    goodsMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    goodsMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    goodsMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    goodsMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    goodsMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    goodsMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    goodsMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    goodsMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    goodsMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    goodsMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    goodsMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsMngWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    goodsMngWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERLOTRF"));
                    #endregion

                    al.Add(goodsMngWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngExportDB.SearchGoodsMngAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {

                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="goodsMngExportParamWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Note       : �������������񐶐��{�����l�ݒ菈�����s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>Update Note: 2012/11/13 ������</br>
        ///	<br>			 Redmine#32367 ���i�}�X�^�G�N�X�|�[�g�ŕs����ۂ̑Ή�</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsMngExportParamWork goodsMngExportParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            StringBuilder retstring = new StringBuilder(" WHERE ");

            //��ƃR�[�h
            retstring.Append(" ENTERPRISECODERF=@FINDENTERPRISECODE");
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring.Append( " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring.Append(" AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE");
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }
            /* --- DEL liusy 2012/09/24 for Redmine#32367---------->>>>>
            //���i�����ރR�[�h
            retstring.Append(" AND GOODSMGROUPRF=@FINDGOODSMGROUP");
            SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
            paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroup);

            //BL���i�R�[�h
            retstring.Append(" AND BLGOODSCODERF=@FINDBLGOODSCODE");
            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.BLGoodsCode);
            */
            // --- DEL liusy 2012/09/24 for Redmine#32367----------<<<<<
            // --- ADD ������ 2012/11/13 for Redmine#32367---------->>>>>
            if (goodsMngExportParamWork.SetKind != SETKIND_5_VALUE)
            {
                //���_�{�i��
                if (goodsMngExportParamWork.SetKind == SETKIND_1_VALUE)
                {

                    //���_�R�[�h�ݒ�
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdSt))
                    {
                        retstring.Append(" AND SECTIONCODERF>=@FINDSTSECTIONCODE");
                        SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@FINDSTSECTIONCODE", SqlDbType.NChar);
                        paraStSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdSt);
                    }
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdEd))
                    {
                        retstring.Append(" AND SECTIONCODERF<=@FINDEDSECTIONCODE");
                        SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@FINDEDSECTIONCODE", SqlDbType.NChar);
                        paraEdSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdEd);
                    }

                    //���i���[�J�[�R�[�h�ݒ�
                    if (goodsMngExportParamWork.GoodsMakerCdSt != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF>=@FINDSTGOODSMAKERCD");
                        SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                        paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdSt);
                    }
                    if (goodsMngExportParamWork.GoodsMakerCdEd != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF<=@FINDEDGOODSMAKERCD");
                        SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                        paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdEd);
                    }

                    //���i�ԍ��ݒ�
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.GoodsNoSt))
                    {
                        retstring.Append(" AND GOODSNORF>=@FINDSTGOODSNO");
                        SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@FINDSTGOODSNO", SqlDbType.NChar);
                        paraStGoodsNo.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.GoodsNoSt);
                    }
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.GoodsNoEd))
                    {
                        retstring.Append(" AND GOODSNORF<=@FINDEDGOODSNO");
                        SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@FINDEDGOODSNO", SqlDbType.NChar);
                        paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.GoodsNoEd);
                    }

                    //���i�ԍ��ݒ�
                    retstring.Append(" AND GOODSNORF<>@FINDGOODSNO");
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                    paraGoodsNo.Value = string.Empty;

                    //���i���[�J�[�R�[�h�ݒ�
                    retstring.Append(" AND GOODSMAKERCDRF<>@FINDGOODSMAKERCD");
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(0);

                    //BL�R�[�h
                    retstring.Append(" AND BLGOODSCODERF=@FINDBLGOODSCODE");
                    SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);

                    //������
                    retstring.Append(" AND GOODSMGROUPRF=@FINDGOODSMGROUP");
                    SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);
                }
                //���_�{�����ށ{���[�J�[�{BL�R�[�h
                else if (goodsMngExportParamWork.SetKind == SETKIND_2_VALUE)
                {

                    //���_�R�[�h�ݒ�
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdSt))
                    {
                        retstring.Append(" AND SECTIONCODERF>=@FINDSTSECTIONCODE");
                        SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@FINDSTSECTIONCODE", SqlDbType.NChar);
                        paraStSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdSt);
                    }
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdEd))
                    {
                        retstring.Append(" AND SECTIONCODERF<=@FINDEDSECTIONCODE");
                        SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@FINDEDSECTIONCODE", SqlDbType.NChar);
                        paraEdSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdEd);
                    }

                    //���i���[�J�[�R�[�h�ݒ�
                    if (goodsMngExportParamWork.GoodsMakerCdSt != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF>=@FINDSTGOODSMAKERCD");
                        SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                        paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdSt);
                    }
                    if (goodsMngExportParamWork.GoodsMakerCdEd != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF<=@FINDEDGOODSMAKERCD");
                        SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                        paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdEd);
                    }

                    //BL�R�[�h
                    if (goodsMngExportParamWork.BLGoodsCodeSt != 0)
                    {
                        retstring.Append(" AND BLGOODSCODERF>=@FINDSTBLGOODSCODE");
                        SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@FINDSTBLGOODSCODE", SqlDbType.Int);
                        paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.BLGoodsCodeSt);
                    }
                    if (goodsMngExportParamWork.BLGoodsCodeEd != 0)
                    {
                        retstring.Append(" AND BLGOODSCODERF<=@FINDEDBLGOODSCODE");
                        SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@FINDEDBLGOODSCODE", SqlDbType.Int);
                        paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.BLGoodsCodeEd);
                    }

                    //������
                    if (goodsMngExportParamWork.GoodsMGroupSt != 0)
                    {
                        retstring.Append(" AND GOODSMGROUPRF>=@FINDSTGOODSMGROUP");
                        SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDSTGOODSMGROUP", SqlDbType.Int);
                        paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroupSt);
                    }
                    if (goodsMngExportParamWork.GoodsMGroupEd != 0)
                    {
                        retstring.Append(" AND GOODSMGROUPRF<=@FINDEDGOODSMGROUP");
                        SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@FINDEDGOODSMGROUP", SqlDbType.Int);
                        paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroupEd);
                    }

                    //���i�ԍ��ݒ�
                    retstring.Append(" AND GOODSNORF=@FINDGOODSNO");
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                    paraGoodsNo.Value = string.Empty;

                    //���i���[�J�[�R�[�h�ݒ�
                    retstring.Append(" AND GOODSMAKERCDRF<>@FINDGOODSMAKERCD");
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(0);

                    //BL�R�[�h
                    retstring.Append(" AND BLGOODSCODERF<>@FINDBLGOODSCODE");
                    SqlParameter paraStGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraStGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);

                    //������
                    retstring.Append(" AND GOODSMGROUPRF<>@FINDGOODSMGROUP");
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);
                }
                //���_�{�����ށ{���[�J�[
                else if (goodsMngExportParamWork.SetKind == SETKIND_3_VALUE)
                {
                    //���_�R�[�h�ݒ�
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdSt))
                    {
                        retstring.Append(" AND SECTIONCODERF>=@FINDSTSECTIONCODE");
                        SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@FINDSTSECTIONCODE", SqlDbType.NChar);
                        paraStSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdSt);
                    }
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdEd))
                    {
                        retstring.Append(" AND SECTIONCODERF<=@FINDEDSECTIONCODE");
                        SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@FINDEDSECTIONCODE", SqlDbType.NChar);
                        paraEdSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdEd);
                    }

                    //���i���[�J�[�R�[�h�ݒ�
                    if (goodsMngExportParamWork.GoodsMakerCdSt != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF>=@FINDSTGOODSMAKERCD");
                        SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                        paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdSt);
                    }
                    if (goodsMngExportParamWork.GoodsMakerCdEd != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF<=@FINDEDGOODSMAKERCD");
                        SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                        paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdEd);
                    }

                    //������
                    if (goodsMngExportParamWork.GoodsMGroupSt != 0)
                    {
                        retstring.Append(" AND GOODSMGROUPRF>=@FINDSTGOODSMGROUP");
                        SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDSTGOODSMGROUP", SqlDbType.Int);
                        paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroupSt);
                    }
                    if (goodsMngExportParamWork.GoodsMGroupEd != 0)
                    {
                        retstring.Append(" AND GOODSMGROUPRF<=@FINDEDGOODSMGROUP");
                        SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@FINDEDGOODSMGROUP", SqlDbType.Int);
                        paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroupEd);
                    }

                    //���i�ԍ��ݒ�
                    retstring.Append(" AND GOODSNORF=@FINDGOODSNO");
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                    paraGoodsNo.Value = string.Empty;

                    //���i���[�J�[�R�[�h�ݒ�
                    retstring.Append(" AND GOODSMAKERCDRF<>@FINDGOODSMAKERCD");
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(0);

                    //BL�R�[�h
                    retstring.Append(" AND BLGOODSCODERF=@FINDBLGOODSCODE");
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);

                    //������
                    retstring.Append(" AND GOODSMGROUPRF<>@FINDGOODSMGROUP");
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);

                }
                //���_�{���[�J�[
                else if (goodsMngExportParamWork.SetKind == SETKIND_4_VALUE)
                {

                    //���_�R�[�h�ݒ�
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdSt))
                    {
                        retstring.Append(" AND SECTIONCODERF>=@FINDSTSECTIONCODE");
                        SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@FINDSTSECTIONCODE", SqlDbType.NChar);
                        paraStSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdSt);
                    }
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdEd))
                    {
                        retstring.Append(" AND SECTIONCODERF<=@FINDEDSECTIONCODE");
                        SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@FINDEDSECTIONCODE", SqlDbType.NChar);
                        paraEdSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdEd);
                    }

                    //���i���[�J�[�R�[�h�ݒ�
                    if (goodsMngExportParamWork.GoodsMakerCdSt != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF>=@FINDSTGOODSMAKERCD");
                        SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                        paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdSt);
                    }
                    if (goodsMngExportParamWork.GoodsMakerCdEd != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF<=@FINDEDGOODSMAKERCD");
                        SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                        paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdEd);
                    }

                    //���i�ԍ��ݒ�
                    retstring.Append(" AND GOODSNORF=@FINDGOODSNO");
                    SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                    paraStGoodsNo.Value = string.Empty;

                    //���i���[�J�[�R�[�h�ݒ�
                    retstring.Append(" AND GOODSMAKERCDRF<>@FINDGOODSMAKERCD");
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(0);

                    //BL�R�[�h
                    retstring.Append(" AND BLGOODSCODERF=@FINDBLGOODSCODE");
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);

                    //������
                    retstring.Append(" AND GOODSMGROUPRF=@FINDGOODSMGROUP");
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);
                }
            }
            else
            {
                // --- ADD ������ 2012/11/13 for Redmine#32367----------<<<<<
                //���_�R�[�h�ݒ�
                if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdSt))
                {
                    retstring.Append(" AND SECTIONCODERF>=@FINDSTSECTIONCODE");
                    SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@FINDSTSECTIONCODE", SqlDbType.NChar);
                    paraStSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdSt);
                }
                if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdEd))
                {
                    retstring.Append(" AND SECTIONCODERF<=@FINDEDSECTIONCODE");
                    SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@FINDEDSECTIONCODE", SqlDbType.NChar);
                    paraEdSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdEd);
                }

                //���i���[�J�[�R�[�h�ݒ�
                if (goodsMngExportParamWork.GoodsMakerCdSt != 0)
                {
                    retstring.Append(" AND GOODSMAKERCDRF>=@FINDSTGOODSMAKERCD");
                    SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                    paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdSt);
                }
                if (goodsMngExportParamWork.GoodsMakerCdEd != 0)
                {
                    retstring.Append(" AND GOODSMAKERCDRF<=@FINDEDGOODSMAKERCD");
                    SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                    paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdEd);
                }

                //���i�ԍ��ݒ�
                if (!String.IsNullOrEmpty(goodsMngExportParamWork.GoodsNoSt))
                {
                    retstring.Append(" AND GOODSNORF>=@FINDSTGOODSNO");
                    SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@FINDSTGOODSNO", SqlDbType.NChar);
                    paraStGoodsNo.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.GoodsNoSt);
                }
                if (!String.IsNullOrEmpty(goodsMngExportParamWork.GoodsNoEd))
                {
                    retstring.Append(" AND GOODSNORF<=@FINDEDGOODSNO");
                    SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@FINDEDGOODSNO", SqlDbType.NChar);
                    paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.GoodsNoEd);
                }
                // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
                //BL�R�[�h
                if (goodsMngExportParamWork.BLGoodsCodeSt != 0)
                {
                    retstring.Append(" AND BLGOODSCODERF>=@FINDSTBLGOODSCODE");
                    SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@FINDSTBLGOODSCODE", SqlDbType.Int);
                    paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.BLGoodsCodeSt);
                }
                if (goodsMngExportParamWork.BLGoodsCodeEd != 0)
                {
                    retstring.Append(" AND BLGOODSCODERF<=@FINDEDBLGOODSCODE");
                    SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@FINDEDBLGOODSCODE", SqlDbType.Int);
                    paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.BLGoodsCodeEd);
                }

                //������
                if (goodsMngExportParamWork.GoodsMGroupSt != 0)
                {
                    retstring.Append(" AND GOODSMGROUPRF>=@FINDSTGOODSMGROUP");
                    SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDSTGOODSMGROUP", SqlDbType.Int);
                    paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroupSt);
                }
                if (goodsMngExportParamWork.GoodsMGroupEd != 0)
                {
                    retstring.Append(" AND GOODSMGROUPRF<=@FINDEDGOODSMGROUP");
                    SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@FINDEDGOODSMGROUP", SqlDbType.Int);
                    paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroupEd);
                }
                // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
            // --- ADD ������ 2012/11/13 for Redmine#32367---------->>>>>
            }
            retstring.Append(" ORDER BY ENTERPRISECODERF,SECTIONCODERF,GOODSMGROUPRF, GOODSMAKERCDRF,BLGOODSCODERF,GOODSNORF");
            // --- ADD ������ 2012/11/13 for Redmine#32367----------<<<<<
            #endregion
            return retstring.ToString();
        }
    }
}
