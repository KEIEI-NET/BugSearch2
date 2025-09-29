//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^�i����j
// �v���O�����T�v   : �\���敪�}�X�^�i����jDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �� �� ��  2012/06/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �\���敪�}�X�^���DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �\���敪�}�X�^����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �L�w��</br>
    /// <br>Date       : 2012/06/11</br>
    /// </remarks>
    [Serializable]
    public class PriceSelectSetWorkDB : RemoteDB, IPriceSelectSetWorkDB
    {
        /// <summary>
        /// �\���敪�}�X�^���DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        public PriceSelectSetWorkDB()
            :
        base("PMKHN08727D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetCndtnWork", "PriceSelectSetRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region IPriceSelectSetWorkDB �����o
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̕\���敪�}�X�^���LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="priceSelectSetResultWork">��������</param>
        /// <param name="priceSelectSetCndtnWork">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̕\���敪�}�X�^���LIST��S�Ė߂��܂��i�_���폜�����j�B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        public int Search(out object priceSelectSetResultWork, object priceSelectSetCndtnWork, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            priceSelectSetResultWork = null;

            try
            {
                status = SearchProc(out priceSelectSetResultWork, priceSelectSetCndtnWork, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceSelectSetWorkDB.Search Exception=" + ex.Message);
                priceSelectSetResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̕\���敪�}�X�^���LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="priceSelectSetResultWork">��������</param>
        /// <param name="priceSelectSetCndtnWork">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̏��i�Ǘ��}�X�^�i�G�N�X�|�[�g�jLIST��S�Ė߂��܂��B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        private int SearchProc(out object priceSelectSetResultWork, object priceSelectSetCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            priceSelectSetResultWork = null;

            ArrayList al = new ArrayList();   //���o����

            try
            {
                // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = SearchOrderProc(ref al, ref sqlConnection, priceSelectSetCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceSelectSetWorkDB.SearchProc Exception=" + ex.Message);
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

            priceSelectSetResultWork = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="paramObj">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������������񐶐��{�����l�ݒ�B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, object paramObj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                PriceSelectSetCndtnWork priceSelectSetCndtnWork = (PriceSelectSetCndtnWork)paramObj;
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt = "";
                sqlCommand.Parameters.Clear();
                #region Select���쐬

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "   PRI.CUSTOMERCODERF" + Environment.NewLine;             // ���Ӑ�
                selectTxt += "  ,CUS.NAMERF" + Environment.NewLine;                     // ���Ӑ於
                selectTxt += "  ,PRI.CUSTRATEGRPCODERF" + Environment.NewLine;          // ���Ӑ�|���O���[�v
                selectTxt += "	,PRI.GOODSMAKERCDRF" + Environment.NewLine;             // ���[�J�[
                selectTxt += "  ,MAKER.MAKERNAMERF" + Environment.NewLine;              // ���[�J�[��
                selectTxt += "  ,PRI.BLGOODSCODERF" + Environment.NewLine;              // BL�R�[�h
                selectTxt += "  ,BLGOOD.BLGOODSHALFNAMERF" + Environment.NewLine;       // BL�R�[�h��=
                selectTxt += "  ,PRI.PRICESELECTDIVRF" + Environment.NewLine;           // �W�����i�I���敪
                selectTxt += "  ,PRI.LOGICALDELETECODERF" + Environment.NewLine;        // �_���폜�敪
                selectTxt += "  ,PRI.UPDATEDATETIMERF" + Environment.NewLine;           // �X�V����
                selectTxt += "  ,PRI.PRICESELECTPTNRF" + Environment.NewLine;           // �W�����i�I��ݒ�p�^�[��
                selectTxt += " FROM PRICESELECTSETRF AS PRI WITH(READUNCOMMITTED)" + Environment.NewLine;

                #region [LEFT JION���쐬]
                // ���Ӑ於
                selectTxt += "LEFT JOIN CUSTOMERRF AS CUS WITH(READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "	ON  CUS.CUSTOMERCODERF = PRI.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "	AND  CUS.ENTERPRISECODERF = PRI.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND  CUS.LOGICALDELETECODERF = 0 " + Environment.NewLine;

                // ���[�J�[��
                selectTxt += "LEFT JOIN MAKERURF AS MAKER WITH(READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "	ON  MAKER.GOODSMAKERCDRF = PRI.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	AND  MAKER.ENTERPRISECODERF = PRI.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND  MAKER.LOGICALDELETECODERF = 0 " + Environment.NewLine;

                // �a�k���i�R�[�h��
                selectTxt += "LEFT JOIN BLGOODSCDURF AS BLGOOD WITH(READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "	ON  BLGOOD.BLGOODSCODERF = PRI.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "	AND  BLGOOD.ENTERPRISECODERF = PRI.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND  BLGOOD.LOGICALDELETECODERF = 0 " + Environment.NewLine;
                #endregion

                #endregion

                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, priceSelectSetCndtnWork, logicalMode);

                //ORDER BY�̍쐬
                #region [ORDER BY���쐬]
                selectTxt += " ORDER BY " + Environment.NewLine;
                selectTxt += " PRI.PRICESELECTPTNRF, " + Environment.NewLine;
                selectTxt += " PRI.CUSTOMERCODERF, " + Environment.NewLine;
                selectTxt += " PRI.CUSTRATEGRPCODERF, " + Environment.NewLine;
                selectTxt += " PRI.GOODSMAKERCDRF, " + Environment.NewLine;
                selectTxt += " PRI.BLGOODSCODERF " + Environment.NewLine;
                #endregion

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    PriceSelectSetResultWork priceSelectSetResultWork = new PriceSelectSetResultWork();

                    //�i�[����
                    priceSelectSetResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    priceSelectSetResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    priceSelectSetResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                    priceSelectSetResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    priceSelectSetResultWork.GoodsMakerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    priceSelectSetResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    priceSelectSetResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                    priceSelectSetResultWork.PriceSelectDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESELECTDIVRF"));
                    priceSelectSetResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    priceSelectSetResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    priceSelectSetResultWork.PriceSelectPtn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESELECTPTNRF"));
                    #endregion

                    al.Add(priceSelectSetResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (!myReader.IsClosed) myReader.Close();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqResultWork.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// WHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂�)</param>
        /// <returns>WHERE��</returns>
        /// <remarks>
        /// <br>Note       : WHERE�� ���������B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, PriceSelectSetCndtnWork CndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += " PRI.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //���i���[�J�[�R�[�h
            if (CndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND PRI.GOODSMAKERCDRF >= @ST_GOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@ST_GOODSMAKERCD", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.St_GoodsMakerCd);
            }
            if (CndtnWork.Ed_GoodsMakerCd != 0)
            {
                retstring += " AND PRI.GOODSMAKERCDRF <= @ED_GOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@ED_GOODSMAKERCD", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.Ed_GoodsMakerCd);
            }

            //BL���i�R�[�h
            if (CndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND PRI.BLGOODSCODERF >= @ST_BLGOODSCODE" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@ST_BLGOODSCODE", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.St_BLGoodsCode);
            }
            if (CndtnWork.Ed_BLGoodsCode != 0)
            {
                retstring += " AND PRI.BLGOODSCODERF <= @ED_BLGOODSCODE" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@ED_BLGOODSCODE", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.Ed_BLGoodsCode);
            }

            //���Ӑ�
            if (CndtnWork.St_CustomerCode != 0)
            {
                retstring += " AND PRI.CUSTOMERCODERF >= @ST_CUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.St_CustomerCode);
            }
            if (CndtnWork.Ed_CustomerCode != 0)
            {
                retstring += " AND PRI.CUSTOMERCODERF <= @ED_CUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.Ed_CustomerCode);
            }

            //���Ӑ�|���O���[�v�R�[�h
            if (!string.IsNullOrEmpty(CndtnWork.St_BLGroupCode))
            {
                retstring += " AND PRI.CUSTRATEGRPCODERF >= @ST_BLGROUPCODE" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@ST_BLGROUPCODE", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetString(CndtnWork.St_BLGroupCode);
            }
            if (!string.IsNullOrEmpty(CndtnWork.Ed_BLGroupCode))
            {
                retstring += " AND PRI.CUSTRATEGRPCODERF <= @ED_BLGROUPCODE" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@ED_BLGROUPCODE", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetString(CndtnWork.Ed_BLGroupCode);
            }

            // �_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0))
            {
                retstring += " AND PRI.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)0);
            }
            else
            {
                retstring += " AND PRI.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)1);
            }

            // �W�����i�I���敪
            if (CndtnWork.PriceSelectPtn != 9)
            {
                retstring += " AND PRI.PRICESELECTPTNRF = @PRICESELECTPTN" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@PRICESELECTPTN", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PriceSelectPtn);
            }
            else
            {
                if (CndtnWork.St_BLGroupCode.Equals("0000"))
                {
                    retstring += " AND PRI.PRICESELECTPTNRF <= 5 " + Environment.NewLine;
                    retstring += " AND PRI.PRICESELECTPTNRF >= 3 " + Environment.NewLine;
                }
            }

            // �폜���t
            if (CndtnWork.LogicalDeleteCode == 1)
            {
                if (CndtnWork.DeleteDateTimeSt != DateTime.MinValue && CndtnWork.DeleteDateTimeEd != DateTime.MinValue)
                {
                    retstring += " AND PRI.UPDATEDATETIMERF >= @DELETEDATETIMEST" + Environment.NewLine;
                    SqlParameter paraDeleteDateTimeSt = sqlCommand.Parameters.Add("@DELETEDATETIMEST", SqlDbType.BigInt);
                    paraDeleteDateTimeSt.Value = SqlDataMediator.SqlSetLong(CndtnWork.DeleteDateTimeSt.Ticks);
                    retstring += " AND PRI.UPDATEDATETIMERF <= @DELETEDATETIMEED" + Environment.NewLine;
                    SqlParameter paraDeleteDateTimeEd = sqlCommand.Parameters.Add("@DELETEDATETIMEED", SqlDbType.BigInt);
                    paraDeleteDateTimeEd.Value = SqlDataMediator.SqlSetLong(CndtnWork.DeleteDateTimeEd.AddDays(1).Ticks);

                }
                else if (CndtnWork.DeleteDateTimeSt != DateTime.MinValue && CndtnWork.DeleteDateTimeEd == DateTime.MinValue)
                {
                    retstring += " AND PRI.UPDATEDATETIMERF >= @DELETEDATETIMEST" + Environment.NewLine;
                    SqlParameter paraDeleteDateTimeSt = sqlCommand.Parameters.Add("@DELETEDATETIMEST", SqlDbType.BigInt);
                    paraDeleteDateTimeSt.Value = SqlDataMediator.SqlSetLong(CndtnWork.DeleteDateTimeSt.Ticks);
                }
                else if (CndtnWork.DeleteDateTimeSt == DateTime.MinValue && CndtnWork.DeleteDateTimeEd != DateTime.MinValue)
                {
                    retstring += " AND PRI.UPDATEDATETIMERF <= @DELETEDATETIMEED" + Environment.NewLine;
                    SqlParameter paraDeleteDateTimeEd = sqlCommand.Parameters.Add("@DELETEDATETIMEED", SqlDbType.BigInt);
                    paraDeleteDateTimeEd.Value = SqlDataMediator.SqlSetLong(CndtnWork.DeleteDateTimeEd.AddDays(1).Ticks);
                }

            }
            return retstring;
        }
        #endregion
    }
}
