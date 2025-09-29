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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �D�ǐݒ�}�X�^���DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���A���}�b�`���X�g�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2008.10.24</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class PrmSettingPrintOrderWorkDB : RemoteDB, IPrmSettingPrintOrderWorkDB
    {
        /// <summary>
        /// �D�ǐݒ�}�X�^���DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public PrmSettingPrintOrderWorkDB()
            :
        base("PMKEN02019D", "Broadleaf.Application.Remoting.ParamData.PrmSettingPrintResultWork", "PRMSETTINGURF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �D�ǐݒ�}�X�^���
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̗D�ǐݒ�}�X�^�����LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="prmSettingPrintResultWork">��������</param>
        /// <param name="prmSettingPrintOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̗L���ݒ�}�X�^�����S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.24</br>
        public int Search(out object prmSettingPrintResultWork, object prmSettingPrintOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            prmSettingPrintResultWork = null;

            PrmSettingPrintOrderCndtnWork _prmSettingPrintOrderCndtnWork = prmSettingPrintOrderCndtnWork as PrmSettingPrintOrderCndtnWork;

            try
            {
                status = SearchProc(out prmSettingPrintResultWork, _prmSettingPrintOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrmSettingPrintOrderWork.Search Exception=" + ex.Message);
                prmSettingPrintResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̗D�ǐݒ�}�X�^�����LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="prmSettingPrintResultWork">��������</param>
        /// <param name="prmSettingPrintOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̗D�ǐݒ�}�X�^�����LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.24</br>
        /// <br></br>
        private int SearchProc(out object prmSettingPrintResultWork, PrmSettingPrintOrderCndtnWork _prmSettingPrintOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            prmSettingPrintResultWork = null;

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


                status = SearchOrderProc(ref al, ref sqlConnection, _prmSettingPrintOrderCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrmSettingPrintOrderWorkDB.SearchProc Exception=" + ex.Message);
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

            prmSettingPrintResultWork = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, PrmSettingPrintOrderCndtnWork _prmSettingPrintOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select���쐬

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "	       PRM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "        ,PRM.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "        ,PRM.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "        ,GGR.GOODSMGROUPNAMERF" + Environment.NewLine;
                selectTxt += "        ,PRM.TBSPARTSCODERF" + Environment.NewLine;
                selectTxt += "        ,BLG.BLGOODSHALFNAMERF" + Environment.NewLine;
                selectTxt += "        ,PRM.PARTSMAKERCDRF" + Environment.NewLine;
                selectTxt += "        ,MAK.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "        ,PRM.PRIMEDISPORDERRF" + Environment.NewLine;
                selectTxt += "        ,MNG.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "        ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "        ,PRM.PRMSETDTLNAME1RF" + Environment.NewLine;
                selectTxt += "        ,PRM.PRMSETDTLNAME2RF" + Environment.NewLine;
                selectTxt += "        ,PRM.MAKERDISPORDERRF" + Environment.NewLine;
                selectTxt += "        ,PRM.PRIMEDISPLAYCODERF" + Environment.NewLine;
                selectTxt += " FROM PRMSETTINGURF AS PRM" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	SEC.ENTERPRISECODERF=PRM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND SEC.SECTIONCODERF=PRM.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSGROUPURF AS GGR" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	GGR.ENTERPRISECODERF=PRM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND GGR.GOODSMGROUPRF = PRM.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN BLGOODSCDURF BLG" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	BLG.ENTERPRISECODERF=PRM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND BLG.BLGOODSCODERF=PRM.TBSPARTSCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	MAK.ENTERPRISECODERF=PRM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND MAK.GOODSMAKERCDRF=PRM.PARTSMAKERCDRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSMNGRF AS MNG" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	MNG.ENTERPRISECODERF=PRM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND MNG.SECTIONCODERF=PRM.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "	AND MNG.GOODSMAKERCDRF=PRM.PARTSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	AND MNG.BLGOODSCODERF=PRM.TBSPARTSCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	SUP.ENTERPRISECODERF=MNG.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND SUP.SUPPLIERCDRF=MNG.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "" + Environment.NewLine;
                
                //WHERE���̍쐬
                 selectTxt += MakeWhereString(ref sqlCommand, _prmSettingPrintOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();  
                
                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    PrmSettingPrintResultWork wkPrmSettingPrintResultWork = new PrmSettingPrintResultWork();
                    
                    //�i�[����
                    wkPrmSettingPrintResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkPrmSettingPrintResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkPrmSettingPrintResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkPrmSettingPrintResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkPrmSettingPrintResultWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                    wkPrmSettingPrintResultWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    wkPrmSettingPrintResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                    wkPrmSettingPrintResultWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    wkPrmSettingPrintResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkPrmSettingPrintResultWork.PrimeDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEDISPORDERRF"));
                    wkPrmSettingPrintResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkPrmSettingPrintResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkPrmSettingPrintResultWork.PrmSetDtlName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME1RF"));
                    wkPrmSettingPrintResultWork.PrmSetDtlName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2RF"));
                    wkPrmSettingPrintResultWork.MakerDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERDISPORDERRF"));
                    wkPrmSettingPrintResultWork.PrimeDisplayCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEDISPLAYCODERF"));                   
#endregion

                    al.Add(wkPrmSettingPrintResultWork);

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
                base.WriteErrorLog(ex, "PrmSettingPrintOrderWorkDB.SearchOrderProc Exception=" + ex.Message);
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
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, PrmSettingPrintOrderCndtnWork _prmSettingPrintOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;


            //��ƃR�[�h
            retstring += " PRM.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_prmSettingPrintOrderCndtnWork.EnterpriseCode);

            //���_�R�[�h
            if (_prmSettingPrintOrderCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _prmSettingPrintOrderCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND PRM.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //���i�����ރR�[�h
            if (_prmSettingPrintOrderCndtnWork.St_GoodsMGroup != 0)
            {
                retstring += " AND PRM.GOODSMGROUPRF>=@STGOODSMGROUPRF" + Environment.NewLine;
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@STGOODSMGROUPRF", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(_prmSettingPrintOrderCndtnWork.St_GoodsMGroup);
            }
            if (_prmSettingPrintOrderCndtnWork.Ed_GoodsMGroup != 0)
            {
                retstring += " AND PRM.GOODSMGROUPRF<=@EDGOODSMGROUPRF" + Environment.NewLine;
                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@EDGOODSMGROUPRF", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(_prmSettingPrintOrderCndtnWork.Ed_GoodsMGroup);
            }
            #endregion
            return retstring;
        }
    }
}
