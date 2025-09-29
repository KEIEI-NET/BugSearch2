//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�e�L�X�g�ϊ�DB�����[�g�I�u�W�F�N�g�N���X
// �v���O�����T�v   : ���i�e�L�X�g�ϊ�DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-00  �쐬�S�� : FSI���� �f��
// �� �� ��  K2012/05/28  �C�����e : �V�K�쐬 �R�`���i�ʑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00  �쐬�S�� : ������
// �C �� ��  2020/08/20   �C�����e : PMKOBETSU-4005 ���i�}�X�^�@�艿���l�ϊ��Ή�
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�e�L�X�g�ϊ�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�e�L�X�g�ϊ��̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : K2012/05/28</br>
    /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2020/08/20</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class GoodsUMasDB : RemoteDB, IGoodsUMasDB
    {
        /// <summary>
        /// ���i�e�L�X�g�ϊ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : K2012/05/28</br>
        /// </remarks>
        public GoodsUMasDB()
            : base("PMKHN09928DC", "Broadleaf.Application.Remoting.ParamData.GoodsUWork", "GOODSURF")
        {

        }

        # region [Search]
        /// <summary>
        /// ���i�e�L�X�g���׏��̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outList">��������</param>
        /// <param name="paraWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�e�L�X�g�̃L�[�l����v����A�S�Ă̏��i�e�L�X�g���׏����擾���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : K2012/05/28</br>
        public int Search(out object outList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _goodsUList = null;
            GoodsUWork goodsUWork = null;
            GoodsUWork goodsUWorkSt = null;
            GoodsUWork goodsUWorkEd = null;

            outList = new CustomSerializeArrayList();

            try
            {

                if (paraWork is GoodsUWork)
                {
                    goodsUWork = paraWork as GoodsUWork;

                }
                else if (paraWork is ArrayList)
                {
                    if ((paraWork as ArrayList).Count > 0)
                    {
                        goodsUWorkSt = (paraWork as ArrayList)[0] as GoodsUWork;
                        goodsUWorkEd = (paraWork as ArrayList)[1] as GoodsUWork;

                    }
                }

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(out _goodsUList, goodsUWorkSt, goodsUWorkEd, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);


                if (_goodsUList != null)
                {
                    (outList as CustomSerializeArrayList).AddRange(_goodsUList);
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsUMasDB.Search(out object, object, int, LogicalMode)", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���i�e�L�X�g���׏��̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="goodsUList">���i�e�L�X�g���׏����i�[���� ArrayList</param>
        /// <param name="paraWorkSt">���������i�J�n�j</param>
        /// <param name="paraWorkEd">���������i�I���j</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�e�L�X�g�̃L�[�l����v����A�S�Ă̏��i�e�L�X�g���׏�񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : K2012/05/28</br>
        public int Search(out ArrayList goodsUList, GoodsUWork paraWorkSt, GoodsUWork paraWorkEd, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(out goodsUList, paraWorkSt, paraWorkEd, readMode, logicalMode, false, ref sqlConnection, ref sqlTransaction);
        }


        /// <summary>
        /// ���i�e�L�X�g���׏��̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="goodsUList">���i�e�L�X�g���׏����i�[���� ArrayList</param>
        /// <param name="paraWorkSt">���������i�J�n�j</param>
        /// <param name="paraWorkEd">���������i�I���j</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="isSearchPayeeWithChildren"></param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�e�L�X�g�̃L�[�l����v����A�S�Ă̏��i�e�L�X�g���׏�񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : K2012/05/28</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2020/08/20</br>
        private int SearchProc(out ArrayList goodsUList, GoodsUWork paraWorkSt, GoodsUWork paraWorkEd, int readMode, ConstantManagement.LogicalMode logicalMode, bool isSearchPayeeWithChildren, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �d����擾�p�̃p�����[�^�擾Reader
            SqlDataReader getParamReader = null;
            // ���ۂ̏��i�}�X�^����̃f�[�^�擾Reader
            SqlDataReader getGoodsReader = null;
            // �d����擾�p
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            // �d����擾����f�[�^�i�[�p�̃��[�N���X�g
            List<GoodsUWork> outWork2 = new List<GoodsUWork>();

            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                sqlCommand.CommandTimeout = 600;


                # region [�d����擾����ׂ̃p�����[�^�擾��SELECT��]
                StringBuilder sqlString = new StringBuilder();

                sqlString.AppendLine("SELECT DISTINCT");
                sqlString.AppendLine("	  GOODSU.ENTERPRISECODERF AS GOODS_ENTERPRISECODERF --��ƃR�[�h");
                sqlString.AppendLine("	, @FINDLOGINSECTIONCODE AS GOODS_SCTIONCODERF --���_�R�[�h");
                sqlString.AppendLine("	, GOODSU.GOODSMAKERCDRF AS GOODS_GOODSMAKERCDRF --���[�J�[�R�[�h");
                sqlString.AppendLine("	, GOODSU.GOODSNORF AS GOODS_GOODSNORF --���i�ԍ�");
                sqlString.AppendLine("	, GOODSU.BLGOODSCODERF AS GOODSU_BLGOODSCODERF --BL�R�[�h");
                sqlString.AppendLine("	, BLGROUPU.GOODSMGROUPRF AS BLGROUPU_GOODSMGROUPRF --���i�����ރR�[�h");
                sqlString.AppendLine("FROM");
                sqlString.AppendLine("	GOODSURF AS GOODSU WITH (READUNCOMMITTED)");
                sqlString.AppendLine("	LEFT JOIN BLGOODSCDURF AS BLGOODSCDU WITH (READUNCOMMITTED)");
                sqlString.AppendLine("		ON  GOODSU.ENTERPRISECODERF = BLGOODSCDU.ENTERPRISECODERF");
                sqlString.AppendLine("		AND GOODSU.BLGOODSCODERF = BLGOODSCDU.BLGOODSCODERF");
                sqlString.AppendLine("	LEFT JOIN BLGROUPURF AS BLGROUPU WITH (READUNCOMMITTED)");
                sqlString.AppendLine("		ON  GOODSU.ENTERPRISECODERF = BLGROUPU.ENTERPRISECODERF");
                sqlString.AppendLine("		AND BLGOODSCDU.BLGROUPCODERF = BLGROUPU.BLGROUPCODERF");
                sqlString.AppendLine("WHERE");
                sqlString.AppendLine("	    GOODSU.ENTERPRISECODERF = @FINDENTERPRISECODE");
                sqlString.AppendLine("	AND ( @FINDGOODSNOST IS NULL OR GOODSU.GOODSNORF >= @FINDGOODSNOST )");
                sqlString.AppendLine("	AND ( @FINDGOODSNOED IS NULL OR GOODSU.GOODSNORF <= @FINDGOODSNOED )");
	            sqlString.AppendLine("  AND ( @FINDGOODSMAKERCDST = 0 OR GOODSU.GOODSMAKERCDRF >= @FINDGOODSMAKERCDST )");
	            sqlString.AppendLine("  AND ( @FINDGOODSMAKERCDED = 0 OR GOODSU.GOODSMAKERCDRF <= @FINDGOODSMAKERCDED )");
                sqlString.AppendLine("	AND GOODSU.LOGICALDELETECODERF = 0");
                sqlString.AppendLine("ORDER BY");
                sqlString.AppendLine("	GOODSU.GOODSNORF, GOODSU.GOODSMAKERCDRF");
                sqlCommand.CommandText = sqlString.ToString();

                // Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findGoodsNoSt = sqlCommand.Parameters.Add("@FINDGOODSNOST", SqlDbType.NChar);
                SqlParameter findGoodsNoEd = sqlCommand.Parameters.Add("@FINDGOODSNOED", SqlDbType.NChar);
                SqlParameter findMakerCodeSt = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDST", SqlDbType.Int);
                SqlParameter findMakerCodeEd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDED", SqlDbType.Int);
                SqlParameter findLoginSectionCode = sqlCommand.Parameters.Add("@FINDLOGINSECTIONCODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWorkSt.EnterpriseCode);
                findGoodsNoSt.Value = SqlDataMediator.SqlSetString(paraWorkSt.GoodsNo);
                findGoodsNoEd.Value = SqlDataMediator.SqlSetString(paraWorkEd.GoodsNo);
                findMakerCodeSt.Value = SqlDataMediator.SqlSetInt(paraWorkSt.GoodsMakerCd);
                findMakerCodeEd.Value = SqlDataMediator.SqlSetInt(paraWorkEd.GoodsMakerCd);
                findLoginSectionCode.Value = SqlDataMediator.SqlSetString(paraWorkSt.LoginSectionCode);
                # endregion

                getParamReader = sqlCommand.ExecuteReader();

                while (getParamReader.Read())
                {
                    GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();

                    #region ���i�d���擾�f�[�^�N���X�֒l���i�[
                    goodsSupplierDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(getParamReader, getParamReader.GetOrdinal("GOODS_ENTERPRISECODERF"));// ��ƃR�[�h
                    goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(getParamReader, getParamReader.GetOrdinal("GOODS_SCTIONCODERF"));      // ���_�R�[�h
                    goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(getParamReader, getParamReader.GetOrdinal("GOODS_GOODSMAKERCDRF"));     // ���[�J�[�R�[�h
                    goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(getParamReader, getParamReader.GetOrdinal("GOODS_GOODSNORF"));              // ���i�ԍ�
                    goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(getParamReader, getParamReader.GetOrdinal("GOODSU_BLGOODSCODERF"));      // BL�R�[�h
                    goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(getParamReader, getParamReader.GetOrdinal("BLGROUPU_GOODSMGROUPRF"));    // ���i�����ރR�[�h
                    GoodsSupplierDataWorkList.Add(goodsSupplierDataWork);
                    #endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���i�d������擾���� ���s
                    goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                    #region ���i�d������擾���� ���ʃZ�b�g
                    // ���i�d������擾�����ɂ��擾�����d������Z�b�g
                    for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++)
                    {
                        outWork2.Add(new GoodsUWork());
                        outWork2[outWork2.Count - 1].SupplierCd  = GoodsSupplierDataWorkList[i].SupplierCd;
                        outWork2[outWork2.Count - 1].SupplierLot = GoodsSupplierDataWorkList[i].SupplierLot;
                    }
                    #endregion
                }


                if (outWork2.Count > 0)
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
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "GoodsUMasDB.Search(out ArrayList, GoodsUWork, int, LogicalMode, ref SqlConnection, ref SqlTransaction)", ex.Number);
            }
            finally
            {
                if (getParamReader != null)
                {
                    if (!getParamReader.IsClosed)
                    {
                        getParamReader.Close();
                    }

                    getParamReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                // �ϊ����Ăяo��
                ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

                // �ϊ���񏉊���
                convertDoubleRelease.ReleaseInitLib();
                //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<

                // ���ۂ̃f�[�^�擾
                try
                {
                    // �f�[�^�擾����ׂ�SQL�R�l�N�V�����𐶐��擾
                    sqlConnection = this.CreateSqlConnection(true);

                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                    //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                    sqlCommand.CommandTimeout = 600;

                    # region [�d����擾����ׂ̃p�����[�^�擾��SELECT��]
                    StringBuilder sqlString = new StringBuilder();
                    sqlString.AppendLine("SELECT DISTINCT");
                    sqlString.AppendLine("	  GOODSU.GOODSNORF --���i�ԍ�");
                    sqlString.AppendLine("	, GOODSU.GOODSNAMERF --���i����");
                    sqlString.AppendLine("	, GOODSU.GOODSMAKERCDRF --���i���[�J�[�R�[�h");
                    sqlString.AppendLine("	, GOODSU.BLGOODSCODERF --BL���i�R�[�h");
                    sqlString.AppendLine("	, GOODSU.LISTPRICENOWRF --�艿(����)[���݉��i]");
                    sqlString.AppendLine("	, GOODSU.LISTPRICENEWRF --�艿(����)[�V���i]");
                    sqlString.AppendLine("	, GOODSU.PRICESTARTDATENEWRF  --���i�J�n��[�V���i]");
                    sqlString.AppendLine("	, GOODSU.STOCKRATENOWRF --�d����[���݉��i]");
                    sqlString.AppendLine("	, GOODSU.SALESUNITCOSTNOWRF --�����P��[���݉��i]");
                    sqlString.AppendLine("	, GOODSU.GOODSRATERANKRF --���i�|�������N(�w��)");
                    sqlString.AppendLine("	, GOODSU.GOODSSPECIALNOTERF --���i�K�i����L����");
                    sqlString.AppendLine("	, GOODSU.GOODSKINDCODERF --���i����");
                    sqlString.AppendLine("	, GOODSU.ENTERPRISEGANRECODERF --���Е��ރR�[�h");
                    sqlString.AppendLine("	, GOODSU.TAXATIONDIVCDRF --�ېŋ敪");
                    sqlString.AppendLine("	, GOODSU.GOODSNOTE1RF --���i���l1");
                    sqlString.AppendLine("	, GOODSU.GOODSNOTE2RF --���i���l2");
                    sqlString.AppendLine("	, GOODSU.OFFERDATADIVRF --�񋟃f�[�^�敪");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.PRICESTARTDATENEW3RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.PRICESTARTDATENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.PRICESTARTDATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENOWRF IS NOT NULL THEN GOODSU.PRICESTARTDATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS PRICESTARTDATE1RF --���i�J�n��[No.1]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.LISTPRICENEW3RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.LISTPRICENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.LISTPRICENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENOWRF IS NOT NULL THEN GOODSU.LISTPRICENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS LISTPRICE1RF --�艿(����)[No.1]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.SALESUNITCOSTNEW3RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.SALESUNITCOSTNEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.SALESUNITCOSTNEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENOWRF IS NOT NULL THEN GOODSU.SALESUNITCOSTNOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS SALESUNITCOST1RF --�����P��[No.1]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.STOCKRATENEW3RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.STOCKRATENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.STOCKRATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENOWRF IS NOT NULL THEN GOODSU.STOCKRATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS STOCKRATE1RF --�d����[No.1]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.OPENPRICEDIVNEW3RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.OPENPRICEDIVNEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.OPENPRICEDIVNEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENOWRF IS NOT NULL THEN GOODSU.OPENPRICEDIVNOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS OPENPRICEDIV1RF --�I�[�v�����i�敪[No.1]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.OFFERDATENEW3RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.OFFERDATENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.OFFERDATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENOWRF IS NOT NULL THEN GOODSU.OFFERDATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS OFFERDATE1RF --�񋟓��t[No.1]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.PRICESTARTDATENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.PRICESTARTDATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.PRICESTARTDATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS PRICESTARTDATE2RF --���i�J�n��[No.2]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.LISTPRICENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.LISTPRICENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.LISTPRICENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS LISTPRICE2RF --�艿(����)[No.2]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.SALESUNITCOSTNEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.SALESUNITCOSTNEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.SALESUNITCOSTNOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS SALESUNITCOST2RF --�����P��[No.2]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.STOCKRATENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.STOCKRATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.STOCKRATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS STOCKRATE2RF --�d����[No.2]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.OPENPRICEDIVNEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.OPENPRICEDIVNEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.OPENPRICEDIVNOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS OPENPRICEDIV2RF --�I�[�v�����i�敪[No.2]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.OFFERDATENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.OFFERDATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.OFFERDATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS OFFERDATE2RF --�񋟓��t[No.2]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL AND GOODSU.PRICESTARTDATENEW2RF IS NOT NULL) THEN GOODSU.PRICESTARTDATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL AND GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.PRICESTARTDATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS PRICESTARTDATE3RF --���i�J�n��[No.3]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL AND GOODSU.PRICESTARTDATENEW2RF IS NOT NULL) THEN GOODSU.LISTPRICENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL AND GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.LISTPRICENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS LISTPRICE3RF --�艿(����)[No.3]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL AND GOODSU.PRICESTARTDATENEW2RF IS NOT NULL) THEN GOODSU.SALESUNITCOSTNEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL AND GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.SALESUNITCOSTNOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS SALESUNITCOST3RF --�����P��[No.3]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL AND GOODSU.PRICESTARTDATENEW2RF IS NOT NULL) THEN GOODSU.STOCKRATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL AND GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.STOCKRATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS STOCKRATE3RF --�d����[No.3]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL AND GOODSU.PRICESTARTDATENEW2RF IS NOT NULL) THEN GOODSU.OPENPRICEDIVNEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL AND GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.OPENPRICEDIVNOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS OPENPRICEDIV3RF --�I�[�v�����i�敪[No.3]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL AND GOODSU.PRICESTARTDATENEW2RF IS NOT NULL) THEN GOODSU.OFFERDATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL AND GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.OFFERDATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS OFFERDATE3RF --�񋟓��t[No.3]");
                    sqlString.AppendLine("FROM(");
                    sqlString.AppendLine("	SELECT");
                    sqlString.AppendLine("		GOODSURF.ENTERPRISECODERF");
                    sqlString.AppendLine("	  , GOODSURF.LOGICALDELETECODERF");
                    sqlString.AppendLine("	  , GOODSURF.GOODSMAKERCDRF");
                    sqlString.AppendLine("	  ,	GOODSURF.GOODSNORF");
                    sqlString.AppendLine("	  ,	GOODSNAMERF");
                    sqlString.AppendLine("	  ,	BLGOODSCODERF");
                    sqlString.AppendLine("	  ,	GOODSSPECIALNOTERF");
                    sqlString.AppendLine("	  ,	GOODSKINDCODERF");
                    sqlString.AppendLine("	  ,	ENTERPRISEGANRECODERF");
                    sqlString.AppendLine("	  ,	TAXATIONDIVCDRF");
                    sqlString.AppendLine("	  ,	GOODSNOTE1RF");
                    sqlString.AppendLine("	  ,	GOODSNOTE2RF");
                    sqlString.AppendLine("	  ,	OFFERDATADIVRF");
                    sqlString.AppendLine("	  ,	GOODSRATERANKRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU1.PRICESTARTDATERF AS PRICESTARTDATENOWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU2.PRICESTARTDATERF AS PRICESTARTDATENEWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU3.PRICESTARTDATERF AS PRICESTARTDATENEW2RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU4.PRICESTARTDATERF AS PRICESTARTDATENEW3RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU1.LISTPRICERF AS LISTPRICENOWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU2.LISTPRICERF AS LISTPRICENEWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU3.LISTPRICERF AS LISTPRICENEW2RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU4.LISTPRICERF AS LISTPRICENEW3RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU1.STOCKRATERF AS STOCKRATENOWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU2.STOCKRATERF AS STOCKRATENEWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU3.STOCKRATERF AS STOCKRATENEW2RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU4.STOCKRATERF AS STOCKRATENEW3RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU1.SALESUNITCOSTRF AS SALESUNITCOSTNOWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU2.SALESUNITCOSTRF AS SALESUNITCOSTNEWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU3.SALESUNITCOSTRF AS SALESUNITCOSTNEW2RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU4.SALESUNITCOSTRF AS SALESUNITCOSTNEW3RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU1.OPENPRICEDIVRF AS OPENPRICEDIVNOWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU2.OPENPRICEDIVRF AS OPENPRICEDIVNEWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU3.OPENPRICEDIVRF AS OPENPRICEDIVNEW2RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU4.OPENPRICEDIVRF AS OPENPRICEDIVNEW3RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU1.OFFERDATERF AS OFFERDATENOWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU2.OFFERDATERF AS OFFERDATENEWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU3.OFFERDATERF AS OFFERDATENEW2RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU4.OFFERDATERF AS OFFERDATENEW3RF");
                    sqlString.AppendLine("	  	FROM GOODSURF");
                    sqlString.AppendLine("");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT GOODSNORF , GOODSMAKERCDRF , MAX(PRICESTARTDATERF) PRICESTARTDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("			WHERE PRICESTARTDATERF <= @FINDADDUPYEARMONTHCD");
                    sqlString.AppendLine("			GROUP BY GOODSNORF , GOODSMAKERCDRF");
                    sqlString.AppendLine("		) GOODSPRICEUA ON  ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUA.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF AND GOODSPRICEUA.GOODSNORF = GOODSURF.GOODSNORF");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT GOODSNORF , GOODSMAKERCDRF , PRICESTARTDATERF , LISTPRICERF , STOCKRATERF , SALESUNITCOSTRF , OPENPRICEDIVRF , OFFERDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("		) GOODSPRICEU1 ON  ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUA.GOODSMAKERCDRF = GOODSPRICEU1.GOODSMAKERCDRF AND GOODSPRICEUA.GOODSNORF = GOODSPRICEU1.GOODSNORF AND GOODSPRICEUA.PRICESTARTDATERF = GOODSPRICEU1.PRICESTARTDATERF");
                    sqlString.AppendLine("");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT GOODSNORF , GOODSMAKERCDRF , MIN(PRICESTARTDATERF) PRICESTARTDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("			WHERE PRICESTARTDATERF > @FINDADDUPYEARMONTHCD");
                    sqlString.AppendLine("			GROUP BY GOODSNORF , GOODSMAKERCDRF");
                    sqlString.AppendLine("		) GOODSPRICEUB ON  ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUB.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF AND GOODSPRICEUB.GOODSNORF = GOODSURF.GOODSNORF");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT GOODSNORF , GOODSMAKERCDRF , PRICESTARTDATERF , LISTPRICERF , STOCKRATERF , SALESUNITCOSTRF , OPENPRICEDIVRF , OFFERDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("		) GOODSPRICEU2 ON  ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUB.GOODSMAKERCDRF = GOODSPRICEU2.GOODSMAKERCDRF AND GOODSPRICEUB.GOODSNORF = GOODSPRICEU2.GOODSNORF AND GOODSPRICEUB.PRICESTARTDATERF = GOODSPRICEU2.PRICESTARTDATERF");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT GOODSPRICEURF.ENTERPRISECODERF , GOODSPRICEURF.GOODSMAKERCDRF , GOODSPRICEURF.GOODSNORF , MIN(PRICESTARTDATERF) PRICESTARTDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("				INNER JOIN (");
                    sqlString.AppendLine("					SELECT GOODSNORF , GOODSMAKERCDRF , MIN(PRICESTARTDATERF) PRICESTARTDATE4RF");
                    sqlString.AppendLine("					FROM GOODSPRICEURF");
                    sqlString.AppendLine("					WHERE PRICESTARTDATERF > @FINDADDUPYEARMONTHCD");
                    sqlString.AppendLine("					GROUP BY GOODSNORF , GOODSMAKERCDRF");
                    sqlString.AppendLine("				)  GOODSPRICEU3 ON GOODSPRICEU3.GOODSNORF = GOODSPRICEURF.GOODSNORF AND GOODSPRICEU3.GOODSMAKERCDRF = GOODSPRICEURF.GOODSMAKERCDRF AND GOODSPRICEU3.PRICESTARTDATE4RF < GOODSPRICEURF.PRICESTARTDATERF");
                    sqlString.AppendLine("			GROUP BY GOODSPRICEURF.GOODSNORF , GOODSPRICEURF.ENTERPRISECODERF , GOODSPRICEURF.GOODSMAKERCDRF");
                    sqlString.AppendLine("		) GOODSPRICEUC ON  GOODSPRICEUC.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUC.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF AND GOODSPRICEUC.GOODSNORF = GOODSURF.GOODSNORF");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT ENTERPRISECODERF, GOODSNORF , GOODSMAKERCDRF , PRICESTARTDATERF , LISTPRICERF , STOCKRATERF , SALESUNITCOSTRF , OPENPRICEDIVRF , OFFERDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("		) GOODSPRICEU3 ON  GOODSPRICEU3.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUC.GOODSMAKERCDRF = GOODSPRICEU3.GOODSMAKERCDRF AND GOODSPRICEUC.GOODSNORF = GOODSPRICEU3.GOODSNORF AND GOODSPRICEUC.PRICESTARTDATERF = GOODSPRICEU3.PRICESTARTDATERF");
                    sqlString.AppendLine("");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT GOODSPRICEURF.ENTERPRISECODERF , GOODSPRICEURF.GOODSMAKERCDRF , GOODSPRICEURF.GOODSNORF , MIN(GOODSPRICEURF.PRICESTARTDATERF) PRICESTARTDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("				INNER JOIN (");
                    sqlString.AppendLine("					SELECT GOODSPRICEURF.ENTERPRISECODERF, GOODSPRICEURF.GOODSNORF , GOODSPRICEURF.GOODSMAKERCDRF , MIN(GOODSPRICEURF.PRICESTARTDATERF) PRICESTARTDATE5RF");
                    sqlString.AppendLine("					FROM GOODSPRICEURF");
                    sqlString.AppendLine("						INNER JOIN (");
                    sqlString.AppendLine("  					        SELECT ENTERPRISECODERF, GOODSNORF , GOODSMAKERCDRF , MIN(PRICESTARTDATERF) PRICESTARTDATE6RF");
                    sqlString.AppendLine("						    FROM GOODSPRICEURF");
                    sqlString.AppendLine("						    WHERE PRICESTARTDATERF > @FINDADDUPYEARMONTHCD");
                    sqlString.AppendLine("						    GROUP BY ENTERPRISECODERF, GOODSNORF , GOODSMAKERCDRF");
                    sqlString.AppendLine("				        )  GOODSPRICEU5 ON GOODSPRICEU5.ENTERPRISECODERF = GOODSPRICEURF.ENTERPRISECODERF AND GOODSPRICEU5.GOODSNORF = GOODSPRICEURF.GOODSNORF AND GOODSPRICEU5.GOODSMAKERCDRF = GOODSPRICEURF.GOODSMAKERCDRF AND GOODSPRICEU5.PRICESTARTDATE6RF < GOODSPRICEURF.PRICESTARTDATERF");
                    sqlString.AppendLine("			         GROUP BY GOODSPRICEURF.GOODSNORF , GOODSPRICEURF.ENTERPRISECODERF , GOODSPRICEURF.GOODSMAKERCDRF");
                    sqlString.AppendLine("		         ) GOODSPRICEUEX ON GOODSPRICEUEX.ENTERPRISECODERF = GOODSPRICEURF.ENTERPRISECODERF AND GOODSPRICEUEX.GOODSMAKERCDRF = GOODSPRICEURF.GOODSMAKERCDRF AND GOODSPRICEUEX.GOODSNORF = GOODSPRICEURF.GOODSNORF AND GOODSPRICEUEX.PRICESTARTDATE5RF < GOODSPRICEURF.PRICESTARTDATERF");
                    sqlString.AppendLine("			GROUP BY GOODSPRICEURF.GOODSNORF , GOODSPRICEURF.ENTERPRISECODERF , GOODSPRICEURF.GOODSMAKERCDRF");
                    sqlString.AppendLine("		) GOODSPRICEUD ON  GOODSPRICEUD.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUD.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF AND GOODSPRICEUD.GOODSNORF = GOODSURF.GOODSNORF");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT ENTERPRISECODERF, GOODSNORF , GOODSMAKERCDRF , PRICESTARTDATERF , LISTPRICERF , STOCKRATERF , SALESUNITCOSTRF , OPENPRICEDIVRF , OFFERDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("		) GOODSPRICEU4 ON  GOODSPRICEU4.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUD.GOODSMAKERCDRF = GOODSPRICEU4.GOODSMAKERCDRF AND GOODSPRICEUD.GOODSNORF = GOODSPRICEU4.GOODSNORF AND GOODSPRICEUD.PRICESTARTDATERF = GOODSPRICEU4.PRICESTARTDATERF");
                    sqlString.AppendLine(") GOODSU");
                    sqlString.AppendLine("WHERE");
                    sqlString.AppendLine("	    GOODSU.ENTERPRISECODERF = @FINDENTERPRISECODE");
                    sqlString.AppendLine("	AND GOODSU.LOGICALDELETECODERF = 0");
                    sqlString.AppendLine("	AND ( @FINDGOODSNOST IS NULL OR GOODSU.GOODSNORF >= @FINDGOODSNOST )");
                    sqlString.AppendLine("	AND ( @FINDGOODSNOED IS NULL OR GOODSU.GOODSNORF <= @FINDGOODSNOED )");
                    sqlString.AppendLine("	AND ( @FINDGOODSMAKERCDST = 0 OR GOODSU.GOODSMAKERCDRF >= @FINDGOODSMAKERCDST )");
                    sqlString.AppendLine("	AND ( @FINDGOODSMAKERCDED = 0 OR GOODSU.GOODSMAKERCDRF <= @FINDGOODSMAKERCDED )");
                    sqlString.AppendLine("ORDER BY");
                    sqlString.AppendLine("	GOODSU.GOODSNORF, GOODSU.GOODSMAKERCDRF");
                    sqlCommand.CommandText = sqlString.ToString();
           
                    // Parameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findGoodsNoSt = sqlCommand.Parameters.Add("@FINDGOODSNOST", SqlDbType.NChar);
                    SqlParameter findGoodsNoEd = sqlCommand.Parameters.Add("@FINDGOODSNOED", SqlDbType.NChar);
                    SqlParameter findGoodsMakerCdSt = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDST", SqlDbType.Int);
                    SqlParameter findGoodsMakerCdEd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDED", SqlDbType.Int);
                    SqlParameter findLoginSectionCode = sqlCommand.Parameters.Add("@FINDLOGINSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findAddUpYearMonthCd = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTHCD", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWorkSt.EnterpriseCode);
                    findGoodsNoSt.Value = SqlDataMediator.SqlSetString(paraWorkSt.GoodsNo);
                    findGoodsNoEd.Value = SqlDataMediator.SqlSetString(paraWorkEd.GoodsNo);
                    findGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(paraWorkSt.GoodsMakerCd);
                    findGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(paraWorkEd.GoodsMakerCd);
                    findLoginSectionCode.Value = SqlDataMediator.SqlSetString(paraWorkSt.LoginSectionCode);
                    findAddUpYearMonthCd.Value = SqlDataMediator.SqlSetInt32(paraWorkSt.AddUpYearMonthCd);
                    # endregion


                    getGoodsReader = sqlCommand.ExecuteReader();

                    int cnt = 0;

                    while (getGoodsReader.Read())
                    {

                        // �d����R�[�h�Ɣ������b�g�ȊO��tmp�Ɋi�[
                        // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                        //GoodsUWork _tmpOutWork = this.CopyToGoodsUWorkFromReader(ref getGoodsReader);
                        GoodsUWork _tmpOutWork = this.CopyToGoodsUWorkFromReader(ref getGoodsReader, paraWorkSt.EnterpriseCode, convertDoubleRelease);
                        // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<

                        // �d����R�[�h�Ɣ������b�g��outWork2����Z�b�g
                        _tmpOutWork.SupplierCd = outWork2[cnt].SupplierCd;
                        _tmpOutWork.SupplierLot = outWork2[cnt].SupplierLot;

                        // Client�ɕԂ�ArrayList��Add����
                        al.Add(_tmpOutWork);

                        cnt++;
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
                    // ���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex, "GoodsUMasDB.Search(out ArrayList, GoodsUWork, int, LogicalMode, ref SqlConnection, ref SqlTransaction)", ex.Number);
                }
                finally
                {
                    if (getParamReader != null)
                    {
                        if (!getParamReader.IsClosed)
                        {
                            getParamReader.Close();
                        }

                        getParamReader.Dispose();
                    }

                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }

                    //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                    // ���
                    convertDoubleRelease.Dispose();
                    //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
                }
            }

            goodsUList = al;

            return status;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <returns>GoodsUWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : K2012/05/28</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2020/08/20</br>
        /// </remarks>
        // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
        //private GoodsUWork CopyToGoodsUWorkFromReader(ref SqlDataReader myReader)
        private GoodsUWork CopyToGoodsUWorkFromReader(ref SqlDataReader myReader, string enterpriseCode, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
        {

            GoodsUWork outWork = new GoodsUWork();
            // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
            //this.CopyToGoodsUWorkFromReader(ref myReader, ref outWork);
            this.CopyToGoodsUWorkFromReader(ref myReader, ref outWork, enterpriseCode, convertDoubleRelease);
            // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
            return outWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="outWork">GoodsUWork �I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : K2012/05/28</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2020/08/20</br>
        /// </remarks>
        // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
        //private void CopyToGoodsUWorkFromReader(ref SqlDataReader myReader, ref GoodsUWork outWork)
        private void CopyToGoodsUWorkFromReader(ref SqlDataReader myReader, ref GoodsUWork outWork, string enterpriseCode, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
        {

            if (myReader != null && outWork != null)
            {
                # region �d���R�[�h�Ɣ������b�g�ȊO���i�[
                outWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  //���i�ԍ�
                outWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));  //���i����
                outWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  //���i���[�J�[�R�[�h
                // --- ADD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                convertDoubleRelease.EnterpriseCode = enterpriseCode;
                convertDoubleRelease.GoodsMakerCd = outWork.GoodsMakerCd;
                convertDoubleRelease.GoodsNo = outWork.GoodsNo;
                // --- ADD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
                outWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  //BL���i�R�[�h
                // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                //outWork.ListPriceNow = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICENOWRF"));  //�艿(����)[���݉��i]
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICENOWRF"));

                // �ϊ��������s
                convertDoubleRelease.ReleaseProc();

                outWork.ListPriceNow = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                //outWork.ListPriceNew = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICENEWRF"));  //�艿(����)[�V���i]
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICENEWRF"));

                // �ϊ��������s
                convertDoubleRelease.ReleaseProc();

                outWork.ListPriceNew = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
                outWork.PriceStartDateNew = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATENEWRF"));  //���i�J�n��[�V���i]
                outWork.StockRateNow = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATENOWRF"));  //�d����[���݉��i]
                outWork.SalesUnitCostNow = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTNOWRF"));  //�����P��[���݉��i]
                outWork.GoodsRaterank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));  //���i�|�������N(�w��)
                outWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));  //���i�K�i�E���L����
                outWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));  //���i����
                outWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));  //���Е��ރR�[�h
                outWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));  //�ېŋ敪
                outWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));  //���i���l�P
                outWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));  //���i���l�Q
                outWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));  //�񋟃f�[�^�敪
                outWork.PriceStartDate1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATE1RF"));  //���i�J�n��[No.1]
                // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                //outWork.ListPrice1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICE1RF"));  //�艿(����)[No.1]
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICE1RF"));  //�艿(����)[No.1]

                // �ϊ��������s
                convertDoubleRelease.ReleaseProc();

                outWork.ListPrice1 = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
                outWork.SalesUnitCost1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOST1RF"));  //�����P��[No.1]
                outWork.StockRate1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATE1RF"));  //�d����[No.1]
                outWork.OpenPriceDiv1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIV1RF"));  //�I�[�v�����i�敪[No.1]
                outWork.OfferDate1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATE1RF"));  //�񋟓��t[No.1]
                outWork.PriceStartDate2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATE2RF"));  //���i�J�n��[No.2]
                // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                //outWork.ListPrice2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICE2RF"));  //�艿(����)[No.2]
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICE2RF"));  //�艿(����)[No.2]

                // �ϊ��������s
                convertDoubleRelease.ReleaseProc();

                outWork.ListPrice2 = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
                outWork.SalesUnitCost2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOST2RF"));  //�����P��[No.2]
                outWork.StockRate2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATE2RF"));  //�d����[No.2]
                outWork.OpenPriceDiv2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIV2RF"));  //�I�[�v�����i�敪[No.2]
                outWork.OfferDate2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATE2RF"));  //�񋟓��t[No.2]
                outWork.PriceStartDate3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATE3RF"));  //���i�J�n��[No.3]
                // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                //outWork.ListPrice3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICE3RF"));  //�艿(����)[No.3]
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICE3RF"));  //�艿(����)[No.3]

                // �ϊ��������s
                convertDoubleRelease.ReleaseProc();

                outWork.ListPrice3 = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
                outWork.SalesUnitCost3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOST3RF"));  //�����P��[No.3]
                outWork.StockRate3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATE3RF"));  //�d����[No.3]
                outWork.OpenPriceDiv3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIV3RF"));  //�I�[�v�����i�敪[No.3]
                outWork.OfferDate3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATE3RF"));  //�񋟓��t[No.3]
                # endregion
            }
        }
        # endregion

        # region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : K2012/05/28</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GoodsUWork[] outWorkArray = null;

            if (paraobj != null)
                try
                {
                    // ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    // �p�����[�^�N���X�̏ꍇ
                    if (paraobj is GoodsUWork)
                    {
                        GoodsUWork outWork = paraobj as GoodsUWork;
                        if (outWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(outWork);
                        }
                    }

                    // byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            outWorkArray = (GoodsUWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GoodsUWork[]));
                        }
                        catch (Exception) { }
                        if (outWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(outWorkArray);
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
                    // ���ɉ������Ȃ�
                }

            return retal;
        }
        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : K2012/05/28</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : K2012/05/28</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // �g�����U�N�V�����̐���(�J�n)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        # endregion
    }
}
