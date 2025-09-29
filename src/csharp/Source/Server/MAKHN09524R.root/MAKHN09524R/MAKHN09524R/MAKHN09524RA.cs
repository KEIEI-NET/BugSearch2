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
    /// ���i�Ǘ����}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Ǘ����}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.01.25</br>
    /// <br></br>
    /// <br>Update Note: 2007.05.08 �����@�V���N�����ǉ� </br>
    /// <br>Update Note: 2007.08.20 �����@DC.NS�p�ɏC�� </br>
    /// <br></br>
    /// <br>Update Note: 2010/11/05 22018  ��� ���b  PM.NS�p �O��R����Ăяo���\�ȃ��\�b�h���ꕔ�ύX�B(ReadProc)</br>
    /// <br>UpDateNote : 2010/12/03 ������ ���_�{���[�J�[�̃��R�[�h��_���폜����ꍇ�̕s����C��</br>
    /// <br>UpDateNote : 2012/05/29 �{�Á@�^�C���A�E�g�G���[�Ή�</br>
    /// <br>Update Note: 2020/08/28 �c����</br>
    /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
    /// <br>UpDateNote : 2021/02/26 32470�@�����@�R�`���i��Q�Ή��@�^�C���A�E�g�G���[�Ή��i���׌y���̂���READUNCOMMITTED�ǉ��j�@���O�o�͑Ή� </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class GoodsMngDB : RemoteDB, IGoodsMngDB, IGetSyncdataList
    {
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>> 
        // �`�[�X�V�^�C���A�E�g���Ԑݒ�t�@�C��
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XML�t�@�C�����������̃f�t�H���g�l
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
        // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
        private OutLogCommon _outLogCommon = null;                // ���O�o��
        private const string PGID = "MAKHN09524R";
        // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<

        /// <summary>
        /// ���i�Ǘ����}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// </remarks>
        public GoodsMngDB()
            :
            base("MAKHN09526D", "Broadleaf.Application.Remoting.ParamData.GoodsMngWork", "GOODSMNGRF")
        {
            // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
            _outLogCommon = new OutLogCommon();
            // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="goodsMngWork">��������</param>
        /// <param name="paragoodsMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        public int Search(out object goodsMngWork, object paragoodsMngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsMngWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGoodsMngProc(out goodsMngWork, paragoodsMngWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngDB.Search");
                goodsMngWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objgoodsMngWork">��������</param>
        /// <param name="paragoodsMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        public int SearchGoodsMngProc(out object objgoodsMngWork, object paragoodsMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsMngWork goodsmngWork = null;

            ArrayList goodsmngWorkList = paragoodsMngWork as ArrayList;
            if (goodsmngWorkList == null)
            {
                goodsmngWork = paragoodsMngWork as GoodsMngWork;
            }
            else
            {
                if (goodsmngWorkList.Count > 0)
                    goodsmngWork = goodsmngWorkList[0] as GoodsMngWork;
            }

            int status = SearchGoodsMngProc(out goodsmngWorkList, goodsmngWork, readMode, logicalMode, ref sqlConnection);
            objgoodsMngWork = goodsmngWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsmngWorkList">��������</param>
        /// <param name="goodsmngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        public int SearchGoodsMngProc(out ArrayList goodsmngWorkList, GoodsMngWork goodsmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchGoodsMngProcProc(out goodsmngWorkList, goodsmngWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsmngWorkList">��������</param>
        /// <param name="goodsmngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        /// <br>UpDateNote : 2021/02/26 �����@�R�`���i��Q�Ή��@�^�C���A�E�g�G���[�Ή��i���׌y���̂���READUNCOMMITTED�ǉ��j</br>
        private int SearchGoodsMngProcProc( out ArrayList goodsmngWorkList, GoodsMngWork goodsmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                //sqlTxt += "SELECT" + Environment.NewLine;
                //sqlTxt += "   GDM.CREATEDATETIMERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDATEDATETIMERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.ENTERPRISECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.LOGICALDELETECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.SECTIONCODERF" + Environment.NewLine;
                //sqlTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.GOODSMAKERCDRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.BLGOODSCODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.GOODSNORF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.SUPPLIERCDRF" + Environment.NewLine;
                //sqlTxt += "  ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.SUPPLIERLOTRF" + Environment.NewLine;
                //sqlTxt += " FROM GOODSMNGRF AS GDM" + Environment.NewLine;
                //sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                //sqlTxt += "ON " + Environment.NewLine;
                //sqlTxt += "     GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                //sqlTxt += " AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                //sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                //sqlTxt += "ON " + Environment.NewLine;
                //sqlTxt += "     GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
                //sqlTxt += " AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;

                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "	 GDM.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "	,GDM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "	,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "	,MAK.MAKERNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "	,BLC.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSNORF" + Environment.NewLine;
                sqlTxt += "	,GOO.GOODSNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "	,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERLOTRF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "	,GGR.GOODSMGROUPNAMERF" + Environment.NewLine;
                // --- UPD ���� 2021/02/26 �^�C���A�E�g�G���[�Ή� ------>>>>>
                //sqlTxt += "FROM GOODSMNGRF AS GDM" + Environment.NewLine;
                //sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlTxt += "FROM GOODSMNGRF AS GDM WITH(READUNCOMMITTED)" + Environment.NewLine;
                sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH(READUNCOMMITTED)" + Environment.NewLine;
                // --- UPD ���� 2021/02/26 �^�C���A�E�g�G���[�Ή� ------<<<<<
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                // --- UPD ���� 2021/02/26 �^�C���A�E�g�G���[�Ή� ------>>>>>
                //sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP WITH(READUNCOMMITTED)" + Environment.NewLine;
                // --- UPD ���� 2021/02/26 �^�C���A�E�g�G���[�Ή� ------<<<<<
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;
                // --- UPD ���� 2021/02/26 �^�C���A�E�g�G���[�Ή� ------>>>>>
                //sqlTxt += "LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                sqlTxt += "LEFT JOIN MAKERURF AS MAK WITH(READUNCOMMITTED)" + Environment.NewLine;
                // --- UPD ���� 2021/02/26 �^�C���A�E�g�G���[�Ή� ------<<<<<
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	MAK.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND MAK.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
                // --- UPD ���� 2021/02/26 �^�C���A�E�g�G���[�Ή� ------>>>>>
                //sqlTxt += "LEFT JOIN BLGOODSCDURF AS BLC" + Environment.NewLine;
                sqlTxt += "LEFT JOIN BLGOODSCDURF AS BLC WITH(READUNCOMMITTED)" + Environment.NewLine;
                // --- UPD ���� 2021/02/26 �^�C���A�E�g�G���[�Ή� ------<<<<<
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	BLC.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND BLC.BLGOODSCODERF = GDM.BLGOODSCODERF" + Environment.NewLine;
                // --- UPD ���� 2021/02/26 �^�C���A�E�g�G���[�Ή� ------>>>>>
                //sqlTxt += "LEFT JOIN GOODSGROUPURF AS GGR" + Environment.NewLine;
                sqlTxt += "LEFT JOIN GOODSGROUPURF AS GGR WITH(READUNCOMMITTED)" + Environment.NewLine;
                // --- UPD ���� 2021/02/26 �^�C���A�E�g�G���[�Ή� ------<<<<<
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GGR.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GGR.GOODSMGROUPRF = GDM.GOODSMGROUPRF" + Environment.NewLine;
                // --- UPD ���� 2021/02/26 �^�C���A�E�g�G���[�Ή� ------>>>>>
                //sqlTxt += "LEFT JOIN GOODSURF AS GOO" + Environment.NewLine;
                sqlTxt += "LEFT JOIN GOODSURF AS GOO WITH(READUNCOMMITTED)" + Environment.NewLine;
                // --- UPD ���� 2021/02/26 �^�C���A�E�g�G���[�Ή� ------<<<<<
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GOO.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GOO.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "AND GOO.GOODSNORF = GDM.GOODSNORF	" + Environment.NewLine;



                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlTxt = "";
                sqlTxt += "WHERE" + Environment.NewLine;

                //��ƃR�[�h
                sqlTxt += " GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);

                //���_�R�[�h
                if (string.IsNullOrEmpty(goodsmngWork.SectionCode) == false)
                {
                    sqlTxt += " AND GDM.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                    {
                        paraSectionCode.Value = "";
                    }
                    else
                    {
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                    }
                }

                //���i���[�J�[�R�[�h
                if (goodsmngWork.GoodsMakerCd != 0)
                {
                    sqlTxt += " AND GDM.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                }

                //BL�R�[�h
                if (goodsmngWork.BLGoodsCode != 0)
                {
                    sqlTxt += " AND GDM.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                }

                //���i�ԍ�
                if (string.IsNullOrEmpty(goodsmngWork.GoodsNo) == false)
                {
                    sqlTxt += " AND GDM.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                    {
                        paraGoodsNo.Value = "";
                    }
                    else
                    {
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                    }
                }

                // ���i������
                if (goodsmngWork.GoodsMGroup != 0)
                {
                    sqlTxt += " AND GDM.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);
                }

                string wkstring = "";
                //�_���폜�敪
                if (( logicalMode == ConstantManagement.LogicalMode.GetData0 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData1 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData2 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData3 ))
                {
                    wkstring = " AND GDM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if (( logicalMode == ConstantManagement.LogicalMode.GetData01 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData012 ))
                {
                    wkstring = " AND GDM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    sqlTxt += wkstring;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                sqlCommand.CommandText += sqlTxt;

                sqlCommand.CommandTimeout = 3600; // ADD 2012/05/29

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsMngWorkFromReader(ref myReader, 0));

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

            goodsmngWorkList = al;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="goodsMngWork">��������</param>
        /// <param name="paragoodsMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        public int SearchNoneGoodsNo(out object goodsMngWork, object paragoodsMngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsMngWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchNoneGoodsNoProc(out goodsMngWork, paragoodsMngWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngDB.Search");
                goodsMngWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objgoodsMngWork">��������</param>
        /// <param name="paragoodsMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        public int SearchNoneGoodsNoProc(out object objgoodsMngWork, object paragoodsMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsMngWork goodsmngWork = null;

            ArrayList goodsmngWorkList = paragoodsMngWork as ArrayList;
            if (goodsmngWorkList == null)
            {
                goodsmngWork = paragoodsMngWork as GoodsMngWork;
            }
            else
            {
                if (goodsmngWorkList.Count > 0)
                    goodsmngWork = goodsmngWorkList[0] as GoodsMngWork;
            }

            int status = SearchNoneGoodsNoProc(out goodsmngWorkList, goodsmngWork, readMode, logicalMode, ref sqlConnection);
            objgoodsMngWork = goodsmngWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsmngWorkList">��������</param>
        /// <param name="goodsmngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        public int SearchNoneGoodsNoProc(out ArrayList goodsmngWorkList, GoodsMngWork goodsmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchNoneGoodsNoProcProc(out goodsmngWorkList, goodsmngWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsmngWorkList">��������</param>
        /// <param name="goodsmngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        private int SearchNoneGoodsNoProcProc( out ArrayList goodsmngWorkList, GoodsMngWork goodsmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                //sqlTxt += "SELECT" + Environment.NewLine;
                //sqlTxt += "   GDM.CREATEDATETIMERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDATEDATETIMERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.ENTERPRISECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.LOGICALDELETECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.SECTIONCODERF" + Environment.NewLine;
                //sqlTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.GOODSMAKERCDRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.BLGOODSCODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.GOODSNORF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.SUPPLIERCDRF" + Environment.NewLine;
                //sqlTxt += "  ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.SUPPLIERLOTRF" + Environment.NewLine;
                //sqlTxt += " FROM GOODSMNGRF AS GDM" + Environment.NewLine;
                //sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                //sqlTxt += "ON " + Environment.NewLine;
                //sqlTxt += "     GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                //sqlTxt += " AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                //sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                //sqlTxt += "ON " + Environment.NewLine;
                //sqlTxt += "     GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
                //sqlTxt += " AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;

                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "	 GDM.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "	,GDM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "	,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "	,MAK.MAKERNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "	,BLC.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSNORF" + Environment.NewLine;
                sqlTxt += "	,GOO.GOODSNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "	,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERLOTRF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "	,GGR.GOODSMGROUPNAMERF" + Environment.NewLine;
                sqlTxt += "FROM GOODSMNGRF AS GDM" + Environment.NewLine;
                sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	MAK.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND MAK.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN BLGOODSCDURF AS BLC" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	BLC.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND BLC.BLGOODSCODERF = GDM.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN GOODSGROUPURF AS GGR" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GGR.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GGR.GOODSMGROUPRF = GDM.GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN GOODSURF AS GOO" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GOO.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GOO.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "AND GOO.GOODSNORF = GDM.GOODSNORF	" + Environment.NewLine;




                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlTxt = "";
                sqlTxt += "WHERE" + Environment.NewLine;

                //��ƃR�[�h
                sqlTxt += " GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);

                //���i�ԍ�
                sqlTxt += " AND GDM.GOODSNORF=''" + Environment.NewLine;

                string wkstring = "";
                //�_���폜�敪
                if (( logicalMode == ConstantManagement.LogicalMode.GetData0 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData1 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData2 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData3 ))
                {
                    wkstring = " AND GDM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if (( logicalMode == ConstantManagement.LogicalMode.GetData01 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData012 ))
                {
                    wkstring = " AND GDM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    sqlTxt += wkstring;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                sqlCommand.CommandText += sqlTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsMngWorkFromReader(ref myReader, 0));

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

            goodsmngWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">GoodsMngWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                GoodsMngWork goodsmngWork = new GoodsMngWork();

                // XML�̓ǂݍ���
                goodsmngWork = (GoodsMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsMngWork));
                if (goodsmngWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref goodsmngWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(goodsmngWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngDB.Read");
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
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsmngWork">GoodsMngWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        public int ReadProc(ref GoodsMngWork goodsmngWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref goodsmngWork, readMode, ref sqlConnection);
        }
        // --- UPD m.suzuki 2010/11/05 ---------->>>>>
        # region // DEL
        ///// <summary>
        ///// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        ///// </summary>
        ///// <param name="goodsmngWork">GoodsMngWork�I�u�W�F�N�g</param>
        ///// <param name="readMode">�����敪</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        ///// <br>Programmer : 21015�@�����@�F��</br>
        ///// <br>Date       : 2007.01.25</br>
        ///// <br></br>
        ///// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        //private int ReadProcProc( ref GoodsMngWork goodsmngWork, int readMode, ref SqlConnection sqlConnection )
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlDataReader myReader = null;

        //    try
        //    {
        //        string sqlTxt = "";
        //        //sqlTxt += "SELECT" + Environment.NewLine;
        //        //sqlTxt += "   GDM.CREATEDATETIMERF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.UPDATEDATETIMERF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.ENTERPRISECODERF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.LOGICALDELETECODERF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.SECTIONCODERF" + Environment.NewLine;
        //        //sqlTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.GOODSMAKERCDRF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.BLGOODSCODERF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.GOODSNORF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.SUPPLIERCDRF" + Environment.NewLine;
        //        //sqlTxt += "  ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.SUPPLIERLOTRF" + Environment.NewLine;
        //        //sqlTxt += " FROM GOODSMNGRF AS GDM" + Environment.NewLine;
        //        //sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
        //        //sqlTxt += "ON " + Environment.NewLine;
        //        //sqlTxt += "     GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
        //        //sqlTxt += " AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
        //        //sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
        //        //sqlTxt += "ON " + Environment.NewLine;
        //        //sqlTxt += "     GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
        //        //sqlTxt += " AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;

        //        sqlTxt += "SELECT" + Environment.NewLine;
        //        sqlTxt += "	 GDM.CREATEDATETIMERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.UPDATEDATETIMERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.LOGICALDELETECODERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.SECTIONCODERF" + Environment.NewLine;
        //        sqlTxt += "	,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.GOODSMAKERCDRF" + Environment.NewLine;
        //        sqlTxt += "	,MAK.MAKERNAMERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.BLGOODSCODERF" + Environment.NewLine;
        //        sqlTxt += "	,BLC.BLGOODSFULLNAMERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.GOODSNORF" + Environment.NewLine;
        //        sqlTxt += "	,GOO.GOODSNAMERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.SUPPLIERCDRF" + Environment.NewLine;
        //        sqlTxt += "	,SUP.SUPPLIERSNMRF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.SUPPLIERLOTRF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.GOODSMGROUPRF" + Environment.NewLine;
        //        sqlTxt += "	,GGR.GOODSMGROUPNAMERF" + Environment.NewLine;
        //        sqlTxt += "FROM GOODSMNGRF AS GDM" + Environment.NewLine;
        //        sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
        //        sqlTxt += "ON" + Environment.NewLine;
        //        sqlTxt += "	GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
        //        sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
        //        sqlTxt += "ON" + Environment.NewLine;
        //        sqlTxt += "	GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;
        //        sqlTxt += "LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
        //        sqlTxt += "ON" + Environment.NewLine;
        //        sqlTxt += "	MAK.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "AND MAK.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
        //        sqlTxt += "LEFT JOIN BLGOODSCDURF AS BLC" + Environment.NewLine;
        //        sqlTxt += "ON" + Environment.NewLine;
        //        sqlTxt += "	BLC.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "AND BLC.BLGOODSCODERF = GDM.BLGOODSCODERF" + Environment.NewLine;
        //        sqlTxt += "LEFT JOIN GOODSGROUPURF AS GGR" + Environment.NewLine;
        //        sqlTxt += "ON" + Environment.NewLine;
        //        sqlTxt += "	GGR.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "AND GGR.GOODSMGROUPRF = GDM.GOODSMGROUPRF" + Environment.NewLine;
        //        sqlTxt += "LEFT JOIN GOODSURF AS GOO" + Environment.NewLine;
        //        sqlTxt += "ON" + Environment.NewLine;
        //        sqlTxt += "	GOO.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "AND GOO.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
        //        sqlTxt += "AND GOO.GOODSNORF = GDM.GOODSNORF	" + Environment.NewLine;

        //        sqlTxt += "WHERE" + Environment.NewLine;
        //        sqlTxt += "     GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
        //        sqlTxt += " AND GDM.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
        //        sqlTxt += " AND GDM.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
        //        sqlTxt += " AND GDM.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
        //        sqlTxt += " AND GDM.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
        //        sqlTxt += " AND GDM.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;


        //        //Select�R�}���h�̐���
        //        using ( SqlCommand sqlCommand = new SqlCommand( sqlTxt, sqlConnection ) )
        //        {

        //            //Prameter�I�u�W�F�N�g�̍쐬
        //            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
        //            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
        //            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
        //            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
        //            SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);

        //            //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
        //            if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
        //            {
        //                findParaSectionCode.Value = "";
        //            }
        //            else
        //            {
        //                findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
        //            }

        //            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
        //            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
        //            paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

        //            if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
        //            {
        //                findParaGoodsNo.Value = "";
        //            }
        //            else
        //            {
        //                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
        //            }

        //            myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //            if (myReader.Read())
        //            {
        //                goodsmngWork = CopyToGoodsMngWorkFromReader(ref myReader, 0);
        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    finally
        //    {
        //        if (myReader != null)
        //            if (!myReader.IsClosed) myReader.Close();
        //    }

        //    return status;
        //}
        # endregion

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsmngWork"></param>
        /// <param name="readMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int ReadProc( ref GoodsMngWork goodsmngWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            return ReadProcProc( ref goodsmngWork, readMode, ref sqlConnection, ref sqlTransaction );
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsmngWork">GoodsMngWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 22018�@��� ���b</br>
        /// <br>Date       : 2010/11/05</br>
        /// <br></br>
        private int ReadProcProc( ref GoodsMngWork goodsmngWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                // SELECT
                string sqlTxt = GetSqlTextForRead();

                //Select�R�}���h�̐���
                SqlCommand sqlCommand = null;
                try
                {
                    // �ύX�_�@�F�g�����U�N�V������n��
                    sqlCommand = new SqlCommand( sqlTxt, sqlConnection, sqlTransaction );

                    // SetParam
                    SetParamForRead( ref sqlCommand, goodsmngWork );

                    // �ύX�_�A�F�R�l�N�V�������N���[�Y���Ȃ�
                    myReader = sqlCommand.ExecuteReader();
                    if ( myReader.Read() )
                    {
                        goodsmngWork = CopyToGoodsMngWorkFromReader( ref myReader, 0 );
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                finally
                {
                    if ( sqlCommand != null )
                    {
                        sqlCommand.Dispose();
                    }
                }
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            finally
            {
                if ( myReader != null )
                    if ( !myReader.IsClosed ) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsmngWork">GoodsMngWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        private int ReadProcProc( ref GoodsMngWork goodsmngWork, int readMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                // SELECT
                string sqlTxt = GetSqlTextForRead();


                //Select�R�}���h�̐���
                SqlCommand sqlCommand = null;
                try
                {
                    sqlCommand = new SqlCommand( sqlTxt, sqlConnection );

                    // SetParam
                    SetParamForRead( ref sqlCommand, goodsmngWork );

                    myReader = sqlCommand.ExecuteReader( CommandBehavior.CloseConnection );
                    if ( myReader.Read() )
                    {
                        goodsmngWork = CopyToGoodsMngWorkFromReader( ref myReader, 0 );
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                finally
                {
                    if ( sqlCommand != null )
                    {
                        sqlCommand.Dispose();
                    }
                }
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            finally
            {
                if ( myReader != null )
                    if ( !myReader.IsClosed ) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �N�G����������(Read�p)
        /// </summary>
        /// <returns></returns>
        private string GetSqlTextForRead()
        {
            string sqlTxt = string.Empty;

            sqlTxt += "SELECT" + Environment.NewLine;
            sqlTxt += "	 GDM.CREATEDATETIMERF" + Environment.NewLine;
            sqlTxt += "	,GDM.UPDATEDATETIMERF" + Environment.NewLine;
            sqlTxt += "	,GDM.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "	,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
            sqlTxt += "	,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
            sqlTxt += "	,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
            sqlTxt += "	,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
            sqlTxt += "	,GDM.LOGICALDELETECODERF" + Environment.NewLine;
            sqlTxt += "	,GDM.SECTIONCODERF" + Environment.NewLine;
            sqlTxt += "	,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
            sqlTxt += "	,GDM.GOODSMAKERCDRF" + Environment.NewLine;
            sqlTxt += "	,MAK.MAKERNAMERF" + Environment.NewLine;
            sqlTxt += "	,GDM.BLGOODSCODERF" + Environment.NewLine;
            sqlTxt += "	,BLC.BLGOODSFULLNAMERF" + Environment.NewLine;
            sqlTxt += "	,GDM.GOODSNORF" + Environment.NewLine;
            sqlTxt += "	,GOO.GOODSNAMERF" + Environment.NewLine;
            sqlTxt += "	,GDM.SUPPLIERCDRF" + Environment.NewLine;
            sqlTxt += "	,SUP.SUPPLIERSNMRF" + Environment.NewLine;
            sqlTxt += "	,GDM.SUPPLIERLOTRF" + Environment.NewLine;
            sqlTxt += "	,GDM.GOODSMGROUPRF" + Environment.NewLine;
            sqlTxt += "	,GGR.GOODSMGROUPNAMERF" + Environment.NewLine;
            sqlTxt += "FROM GOODSMNGRF AS GDM" + Environment.NewLine;
            sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
            sqlTxt += "ON" + Environment.NewLine;
            sqlTxt += "	GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
            sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
            sqlTxt += "ON" + Environment.NewLine;
            sqlTxt += "	GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;
            sqlTxt += "LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
            sqlTxt += "ON" + Environment.NewLine;
            sqlTxt += "	MAK.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "AND MAK.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
            sqlTxt += "LEFT JOIN BLGOODSCDURF AS BLC" + Environment.NewLine;
            sqlTxt += "ON" + Environment.NewLine;
            sqlTxt += "	BLC.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "AND BLC.BLGOODSCODERF = GDM.BLGOODSCODERF" + Environment.NewLine;
            sqlTxt += "LEFT JOIN GOODSGROUPURF AS GGR" + Environment.NewLine;
            sqlTxt += "ON" + Environment.NewLine;
            sqlTxt += "	GGR.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "AND GGR.GOODSMGROUPRF = GDM.GOODSMGROUPRF" + Environment.NewLine;
            sqlTxt += "LEFT JOIN GOODSURF AS GOO" + Environment.NewLine;
            sqlTxt += "ON" + Environment.NewLine;
            sqlTxt += "	GOO.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "AND GOO.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
            sqlTxt += "AND GOO.GOODSNORF = GDM.GOODSNORF	" + Environment.NewLine;

            sqlTxt += "WHERE" + Environment.NewLine;
            sqlTxt += "     GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlTxt += " AND GDM.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
            sqlTxt += " AND GDM.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            sqlTxt += " AND GDM.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
            sqlTxt += " AND GDM.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
            sqlTxt += " AND GDM.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;

            return sqlTxt;
        }
        /// <summary>
        /// �p�����[�^�ݒ菈��(Read�p)
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="goodsmngWork"></param>
        private void SetParamForRead( ref SqlCommand sqlCommand, GoodsMngWork goodsmngWork )
        {
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add( "@FINDSECTIONCODE", SqlDbType.NChar );
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add( "@FINDGOODSMAKERCD", SqlDbType.Int );
            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add( "@FINDBLGOODSCODE", SqlDbType.Int );
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add( "@FINDGOODSNO", SqlDbType.NVarChar );
            SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add( "@FINDGOODSMGROUP", SqlDbType.Int );

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( goodsmngWork.EnterpriseCode );
            if ( SqlDataMediator.SqlSetString( goodsmngWork.SectionCode ) == DBNull.Value )
            {
                findParaSectionCode.Value = "";
            }
            else
            {
                findParaSectionCode.Value = SqlDataMediator.SqlSetString( goodsmngWork.SectionCode );
            }

            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32( goodsmngWork.GoodsMakerCd );
            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32( goodsmngWork.BLGoodsCode );
            paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32( goodsmngWork.GoodsMGroup );

            if ( SqlDataMediator.SqlSetString( goodsmngWork.GoodsNo ) == DBNull.Value )
            {
                findParaGoodsNo.Value = "";
            }
            else
            {
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString( goodsmngWork.GoodsNo );
            }
        }
        // --- ADD m.suzuki 2010/11/05 ----------<<<<<
        #endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20096 �����@����</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
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
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20096 �����@����</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br>GetSyncdataListProc</br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        private int GetSyncdataListProc( out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                sqlTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "  ,SUPPLIERLOTRF" + Environment.NewLine;
                sqlTxt += "  ,GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += " FROM GOODSMNGRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsMngWorkFromReader(ref myReader, 1));

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
        /// ���i�Ǘ����}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="goodsMngWork">GoodsMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        public int Write(ref object goodsMngWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(goodsMngWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteGoodsMngProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                goodsMngWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngDB.Write(ref object goodsMngWork)");
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
        /// ���i�Ǘ����}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsMngWorkList">GoodsMngWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        public int WriteGoodsMngProc(ref ArrayList goodsMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteGoodsMngProcProc(ref goodsMngWorkList,ref sqlConnection,ref sqlTransaction);
        }
        
        /// <summary>
        /// ���i�Ǘ����}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsMngWorkList">GoodsMngWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: 2020/08/28 �c����</br>
        /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
        private int WriteGoodsMngProcProc(ref ArrayList goodsMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                string sqlTxt = "";
            
                if (goodsMngWorkList != null)
                {
                    for (int i = 0; i < goodsMngWorkList.Count; i++)
                    {
                        GoodsMngWork goodsmngWork = goodsMngWorkList[i] as GoodsMngWork;

                        sqlTxt = "";
                        sqlTxt += "SELECT" + Environment.NewLine;
                        sqlTxt += "  GDM.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += " ,GDM.ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "FROM GOODSMNGRF AS GDM" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "     GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " AND GDM.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlTxt += " AND GDM.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += " AND GDM.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        sqlTxt += " AND GDM.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlTxt += " AND GDM.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                        if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                        {
                          findParaSectionCode.Value = "";
                        }
                        else
                        {
                          findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                        }

                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

                        if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                        {
                          findParaGoodsNo.Value = "";
                        }
                        else
                        {
                          findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                        }

                        sqlCommand.CommandTimeout = dbCommandTimeout;  //ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή�
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != goodsmngWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (goodsmngWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                            
                            sqlTxt = "";
                            sqlTxt += "UPDATE GOODSMNGRF SET" + Environment.NewLine;
                            sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            sqlTxt += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            sqlTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            sqlTxt += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                            sqlTxt += " , SUPPLIERLOTRF=@SUPPLIERLOT" + Environment.NewLine;
                            sqlTxt += " , GOODSMGROUPRF=@GOODSMGROUP" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                            sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                            sqlTxt += "  AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            
                            sqlCommand.CommandText = sqlTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                            if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                            {
                              findParaSectionCode.Value = "";
                            }
                            else
                            {
                              findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                            }

                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

                            if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                            {
                              findParaGoodsNo.Value = "";
                            }
                            else
                            {
                              findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                            }

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsmngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (goodsmngWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                            
                            sqlTxt = "";
                            sqlTxt += "INSERT INTO GOODSMNGRF" + Environment.NewLine;
                            sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                            sqlTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                            sqlTxt += "  ,SUPPLIERLOTRF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSMGROUPRF" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;
                            sqlTxt += " VALUES" + Environment.NewLine;
                            sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            sqlTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSNO" + Environment.NewLine;
                            sqlTxt += "  ,@SUPPLIERCD" + Environment.NewLine;
                            sqlTxt += "  ,@SUPPLIERLOT" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSMGROUP" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = sqlTxt;
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsmngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraSupplierLot = sqlCommand.Parameters.Add("@SUPPLIERLOT", SqlDbType.Int);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                        {
                          paraSectionCode.Value = "";
                        }
                        else
                        {
                          paraSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                        }
                        if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                        {
                          paraGoodsNo.Value = "";

                        }
                        else
                        {
                          paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                        }
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsmngWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsmngWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsmngWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsmngWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsmngWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.LogicalDeleteCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.SupplierCd);
                        paraSupplierLot.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.SupplierLot);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsmngWork);
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

            goodsMngWorkList = al;

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
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// ���i�Ǘ����}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="goodsMngWork">GoodsMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        public int LogicalDelete(ref object goodsMngWork)
        {
            return LogicalDeleteGoodsMng(ref goodsMngWork, 0);
        }

        /// <summary>
        /// �_���폜���i�Ǘ����}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="goodsMngWork">GoodsMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���i�Ǘ����}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        public int RevivalLogicalDelete(ref object goodsMngWork)
        {
            return LogicalDeleteGoodsMng(ref goodsMngWork, 1);
        }

        /// <summary>
        /// ���i�Ǘ����}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="goodsMngWork">GoodsMngWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        private int LogicalDeleteGoodsMng(ref object goodsMngWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(goodsMngWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteGoodsMngProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "GoodsMngDB.LogicalDeleteGoodsMng :" + procModestr);

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
        /// ���i�Ǘ����}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsMngWorkList">GoodsMngWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        public int LogicalDeleteGoodsMngProc(ref ArrayList goodsMngWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteGoodsMngProcProc(ref goodsMngWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�Ǘ����}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsMngWorkList">GoodsMngWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        /// <br>UpDateNote : 2010/12/03 ������ ���_�{���[�J�[�̃��R�[�h��_���폜����ꍇ�̕s����C��</br>
        private int LogicalDeleteGoodsMngProcProc( ref ArrayList goodsMngWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                string sqlTxt = "";

                if (goodsMngWorkList != null)
                {
                    for (int i = 0; i < goodsMngWorkList.Count; i++)
                    {
                        GoodsMngWork goodsmngWork = goodsMngWorkList[i] as GoodsMngWork;

                        sqlTxt = "";
                        sqlTxt += "SELECT" + Environment.NewLine;
                        sqlTxt += "  GOODSMNG.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += " ,GOODSMNG.ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += " ,GOODSMNG.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "FROM GOODSMNGRF AS GOODSMNG" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "     GOODSMNG.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " AND GOODSMNG.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlTxt += " AND GOODSMNG.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += " AND GOODSMNG.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        sqlTxt += " AND GOODSMNG.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlTxt += " AND GOODSMNG.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                        if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                        {
                            findParaSectionCode.Value = "";
                        }
                        else
                        {
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                        }

                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

                        if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                        {
                            findParaGoodsNo.Value = "";
                        }
                        else
                        {
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                        }

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != goodsmngWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlTxt = "";
                            sqlTxt += "UPDATE GOODSMNGRF" + Environment.NewLine;
                            sqlTxt += "SET" + Environment.NewLine;
                            sqlTxt += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "WHERE" + Environment.NewLine;
                            sqlTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlTxt += " AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                            sqlTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                            // ---ADD 2010/12/03----------->>>>>
                            sqlTxt += " AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            // ---ADD 2010/12/03-----------<<<<<

                            sqlCommand.CommandText = sqlTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                            if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                            {
                                findParaSectionCode.Value = "";
                            }
                            else
                            {
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                            }

                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

                            if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                            {
                                findParaGoodsNo.Value = "";
                            }
                            else
                            {
                                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                            }

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsmngWork;
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
                            else if (logicalDelCd == 0) goodsmngWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else goodsmngWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) goodsmngWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsmngWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsmngWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsmngWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsmngWork);
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

            goodsMngWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// ���i�Ǘ����}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">���i�Ǘ����}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�Ǘ����}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
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

                status = DeleteGoodsMngProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "GoodsMngDB.Delete");
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
        /// ���i�Ǘ����}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsmngWorkList">���i�Ǘ����}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i�Ǘ����}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        public int DeleteGoodsMngProc(ArrayList goodsmngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteGoodsMngProcProc(goodsmngWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�Ǘ����}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsmngWorkList">���i�Ǘ����}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i�Ǘ����}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        private int DeleteGoodsMngProcProc( ArrayList goodsmngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string sqlTxt = "";

                for (int i = 0; i < goodsmngWorkList.Count; i++)
                {
                    sqlTxt = "";
                    sqlTxt += "SELECT" + Environment.NewLine;
                    sqlTxt += "  GOODSMNG.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += " ,GOODSMNG.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += " ,GOODSMNG.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "FROM GOODSMNGRF AS GOODSMNG" + Environment.NewLine;
                    sqlTxt += "WHERE" + Environment.NewLine;
                    sqlTxt += "     GOODSMNG.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " AND GOODSMNG.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    sqlTxt += " AND GOODSMNG.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += " AND GOODSMNG.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                    sqlTxt += " AND GOODSMNG.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    sqlTxt += " AND GOODSMNG.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;

                    GoodsMngWork goodsmngWork = goodsmngWorkList[i] as GoodsMngWork;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                    if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                    {
                        findParaSectionCode.Value = "";
                    }
                    else
                    {
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                    }

                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

                    if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                    {
                        findParaGoodsNo.Value = "";
                    }
                    else
                    {
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                    }

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != goodsmngWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlTxt = "";
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += "FROM GOODSMNGRF" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += " AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        sqlTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlTxt += " AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine; 

                        sqlCommand.CommandText = sqlTxt;

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                        if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                        {
                            findParaSectionCode.Value = "";
                        }
                        else
                        {
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                        }

                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

                        if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                        {
                            findParaGoodsNo.Value = "";
                        }
                        else
                        {
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                        }
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
        /// �N���X�i�[���� Reader �� GoodsMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">�i�[���ڐ؂�ւ�</param>
        /// <returns>GoodsMngWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        /// <br>UpDateNote : 2021/02/26 ���� �R�`���i��Q�Ή��@���O�o�͑Ή�</br>
        /// </remarks>
        private GoodsMngWork CopyToGoodsMngWorkFromReader(ref SqlDataReader myReader, int mode)
        {
            GoodsMngWork wkGoodsMngWork = new GoodsMngWork();
            // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
            string getRead = string.Empty;
            string enterpriseCode = string.Empty;
            string updEmployeeCode = string.Empty;
            string goodsMakerCd = string.Empty;
            string goodsNo = string.Empty;
            try
            {
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                #region �N���X�֊i�[
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    getRead = "CREATEDATETIMERF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    getRead = "UPDATEDATETIMERF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    getRead = "ENTERPRISECODERF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    enterpriseCode = wkGoodsMngWork.EnterpriseCode;
                    getRead = "FILEHEADERGUIDRF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    getRead = "UPDEMPLOYEECODERF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    updEmployeeCode = wkGoodsMngWork.UpdEmployeeCode;
                    getRead = "UPDASSEMBLYID1RF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    getRead = "UPDASSEMBLYID2RF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    getRead = "LOGICALDELETECODERF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    getRead = "SECTIONCODERF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    getRead = "GOODSMAKERCDRF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    goodsMakerCd = string.Format("GMC={0};", wkGoodsMngWork.GoodsMakerCd.ToString());
                    getRead = "BLGOODSCODERF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    getRead = "GOODSNORF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    goodsNo = string.Format("GN={0};", wkGoodsMngWork.GoodsNo.ToString());
                    getRead = "SUPPLIERCDRF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    getRead = "SUPPLIERLOTRF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERLOTRF"));
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                try
                {
                    getRead = "GOODSMGROUPRF";
                }
                catch
                {
                }
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                wkGoodsMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));

                if (mode == 0)
                {
                    // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                    try
                    {
                        getRead = "SECTIONGUIDENMRF";
                    }
                    catch
                    {
                    }
                    // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                    wkGoodsMngWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                    try
                    {
                        getRead = "SUPPLIERSNMRF";
                    }
                    catch
                    {
                    }
                    // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                    wkGoodsMngWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                    try
                    {
                        getRead = "MAKERNAMERF";
                    }
                    catch
                    {
                    }
                    // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                    wkGoodsMngWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                    try
                    {
                        getRead = "BLGOODSFULLNAMERF";
                    }
                    catch
                    {
                    }
                    // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                    wkGoodsMngWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                    try
                    {
                        getRead = "GOODSNAMERF";
                    }
                    catch
                    {
                    }
                    // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                    wkGoodsMngWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
                    try
                    {
                        getRead = "GOODSMGROUPNAMERF";
                    }
                    catch
                    {
                    }
                    // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<
                    wkGoodsMngWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));

                }
                #endregion
                // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� --->>>>>
            }
            catch(Exception ex)
            {
                // ��O��CLC�A�N���C�A���g���O�o��
                _outLogCommon.OutputServerLog(PGID, goodsMakerCd + goodsNo + getRead, enterpriseCode, updEmployeeCode, ex);

                throw;
            }
            // --- ADD ���� 2021/02/26 ��O�����O�o�͑Ή� ---<<<<<


            return wkGoodsMngWork;
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
        /// <br>Date       : 2007.01.25</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GoodsMngWork[] GoodsMngWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is GoodsMngWork)
                    {
                        GoodsMngWork wkGoodsMngWork = paraobj as GoodsMngWork;
                        if (wkGoodsMngWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkGoodsMngWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            GoodsMngWorkArray = (GoodsMngWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GoodsMngWork[]));
                        }
                        catch (Exception) { }
                        if (GoodsMngWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(GoodsMngWorkArray);
                        }
                        else
                        {
                            try
                            {
                                GoodsMngWork wkGoodsMngWork = (GoodsMngWork)XmlByteSerializer.Deserialize(byteArray, typeof(GoodsMngWork));
                                if (wkGoodsMngWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkGoodsMngWork);
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
        /// <br>Date       : 2007.01.25</br>
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
