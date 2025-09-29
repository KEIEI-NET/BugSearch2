//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�Ə��i�Z�b�g�}�X�^�ϊ�����
// �v���O�����T�v   : �b�r�u�t�@�C�����A��ʒ��o�����𖞂������f�[�^���e�L�X�g�t�@�C���֏o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00   �쐬�S�� : �i�N
// �� �� ��  2015/01/26  �@�C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/02/26  �C�����e : Redmine#44209 ���b�Z�[�W�̕����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/07  �C�����e : Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2015/04/13  �C�����e : Redmine#45436 �\�����ʏd���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/17  �C�����e : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/29  �C�����e : Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����Y�Ə��i�Z�b�g�}�X�^�ϊ�����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���i�Z�b�g�}�X�^�ϊ������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer  : �i�N</br>
    /// <br>Date        : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiGoodsSetChgDB : RemoteDB
    {

        private GoodsSetDB _goodsSetDB;
        private GoodsNoChgCommonDB _goodsNoChgCommonDB;

        #region GoodsSetChgDB
        /// <summary>
        /// ���i�Z�b�g�}�X�^�ϊ������R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ɂȂ�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiGoodsSetChgDB()
        {
            // ���i�Z�b�g�}�X�^
            if (this._goodsSetDB == null)
            {
                this._goodsSetDB = new GoodsSetDB();
            }

            if (this._goodsNoChgCommonDB == null)
            {
                this._goodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
        }
        #endregion

        #region ReadIn
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̏��i�Z�b�g�}�X�^�ɕϊ������̑S�Ė߂鏈��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ��ƃR�[�h�̏��i�Z�b�g�}�X�^�ɕϊ�����LIST��S�Ė߂��܂�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public int ReadIn(out object goodsSuccessResultWork, out object errorResultWork, out int count, int mode, string enterpriseCode)
        {
            // �R�l�N�V����
            SqlConnection sqlConnection = null;
            // �g�����U�N�V����
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;


            #region ���i�Z�b�g�}�X�^
            // ���i�Z�b�g�}�X�^���O
            goodsSuccessResultWork = null;
            errorResultWork = null;
            count = 0;
            ArrayList goodsSuccessResultWorkList = new ArrayList();
            ArrayList errorList = new ArrayList();


            #endregion
            try
            {
                // �R�l�N�V��������
                sqlConnection = _goodsNoChgCommonDB.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = _goodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // ���i�Z�b�g�}�X�^�ϊ�����
                status = ReadInProc(out goodsSuccessResultWorkList, out errorList, out count, mode, enterpriseCode, ref sqlConnection, ref sqlTransaction);

                goodsSuccessResultWork = goodsSuccessResultWorkList;
                errorResultWork = errorList;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetChgDB.ReadIn");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̏��i�Z�b�g�}�X�^�ɕϊ�������S�Ė߂鏈��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private int ReadInProc(out ArrayList goodsSuccessResultWorkList, out ArrayList errorList, out int count, int mode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            count = 0;

            // ���i�Z�b�g�}�X�^
            goodsSuccessResultWorkList = new ArrayList();
            errorList = new ArrayList();
            try
            {
                // ���i�Z�b�g�}�X�^�̍X�V
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = goodSetReadInProc(out goodsSuccessResultWorkList, out errorList, out count, mode, enterpriseCode, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    goodsSuccessResultWorkList.Clear();
                    errorList.Clear();
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetChgDB.ReadInProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }



        /// <summary>
        /// ���i�Z�b�g�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="goodsSetArray"></param>
        /// <param name="goodsSetChgCtnList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="mode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="strMsg"></param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        public int SearchgoodsSet(ref ArrayList goodsSetArray, out ArrayList goodsSetChgCtnList, string enterpriseCode, int mode, ref SqlConnection sqlConnection, out string strMsg)
        {
            return this.SearchProc(ref goodsSetArray, out goodsSetChgCtnList, enterpriseCode, mode, ref sqlConnection, out strMsg);
        }

        /// <summary>
        /// ���i�Z�b�g�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="goodsSetArray"></param>
        /// <param name="goodsSetChgCtnList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="mode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="strMsg"></param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        private int SearchProc(ref ArrayList goodsSetArray, out ArrayList goodsSetChgCtnList, string enterpriseCode, int mode, ref SqlConnection sqlConnection, out string strMsg)
        {
            Dictionary<string, string> _goodsSetChgWorkDic = new Dictionary<string, string>();
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            goodsSetChgCtnList = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            strMsg = "";
            try
            {
                string sqlText = "SELECT A.CREATEDATETIMERF , A.UPDATEDATETIMERF, A.ENTERPRISECODERF , A.FILEHEADERGUIDRF , A.UPDEMPLOYEECODERF , A.UPDASSEMBLYID1RF , A.UPDASSEMBLYID2RF , A.LOGICALDELETECODERF ,A.PARENTGOODSMAKERCDRF , A.PARENTGOODSNORF , A.SUBGOODSMAKERCDRF , A.SUBGOODSNORF , A.CNTFLRF , A.DISPLAYORDERRF, A.SETSPECIALNOTERF , A.CATALOGSHAPENORF," + Environment.NewLine;
                sqlText += "B.GOODSMAKERCDRF, B.CHGSRCGOODSNORF, B.CHGDESTGOODSNORF" + Environment.NewLine;
                sqlText += "FROM GOODSSETRF A WITH (READUNCOMMITTED) " + Environment.NewLine;

                if (mode == 0)
                {
                    sqlText += "INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON (A.PARENTGOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.PARENTGOODSNORF=B.CHGSRCGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF) OR (A.SUBGOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.SUBGOODSNORF = B.CHGSRCGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF) " + Environment.NewLine;
                }
                if (mode == 1)
                {
                    sqlText += "INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "ON (A.PARENTGOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.PARENTGOODSNORF=B.CHGSRCGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF) OR (A.SUBGOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.SUBGOODSNORF = B.CHGSRCGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF) " + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, mode, enterpriseCode);

                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    GoodsSetChgWork goodsSetChgWork = this.CopyToGoodsSetWorkFromReader(ref myReader);
                    string key = goodsSetChgWork.ParentGoodsMakerCd.ToString() + goodsSetChgWork.ParentGoodsNo + goodsSetChgWork.SubGoodsMakerCd.ToString() + goodsSetChgWork.SubGoodsNo;
                    //����
                    GoodsSetChgWork goodsSetChgCtn = new GoodsSetChgWork();
                    goodsSetChgCtn.OldPrmSetDtlName = goodsSetChgWork.OldPrmSetDtlName;
                    goodsSetChgCtn.NewPrmSetDtlName = goodsSetChgWork.NewPrmSetDtlName;
                    goodsSetChgCtn.GoodsMakerCd = goodsSetChgWork.GoodsMakerCd;
                    goodsSetChgCtnList.Add(goodsSetChgCtn);

                    if (!_goodsSetChgWorkDic.ContainsKey(key))
                    {
                        _goodsSetChgWorkDic.Add(key, string.Empty);
                        goodsSetArray.Add(goodsSetChgWork);
                    }
                    else
                    {
                        continue;
                    }
                }

                if (goodsSetArray.Count > 0)
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
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                strMsg = ex.Message;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetChgDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                strMsg = ex.Message;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

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

        #region �\�����ʂ���������
        /// <summary>
        /// ���i�Z�b�g�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="displayOrderDic"></param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="mode">���[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/04/13</br>
        private int SearchDisplayOrder(out Dictionary<string, int> displayOrderDic, string enterpriseCode, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �R�l�N�V����
            SqlConnection sqlConnection = null;

            Dictionary<string,int> displayOrder = new Dictionary<string,int>();
            try
            {
                // �R�l�N�V��������
                sqlConnection = _goodsNoChgCommonDB.CreateSqlConnection(true);
                // ���i�Z�b�g�}�X�^��������
                status = SearchDisplayOrderProc(out displayOrder, enterpriseCode, mode, ref sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetChgDB.SearchDisplayOrder");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            displayOrderDic = displayOrder;

            return status;
        }

        /// <summary>
        /// ���i�Z�b�g�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="displayOrderDic"></param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="mode">���[�h</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/04/13</br>
        private int SearchDisplayOrderProc(out Dictionary<string, int> displayOrderDic, string enterpriseCode, int mode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            displayOrderDic = new Dictionary<string, int>();
            try
            {
                string sqlText = "SELECT A.PARENTGOODSMAKERCDRF , A.PARENTGOODSNORF , MAX(A.DISPLAYORDERRF) AS DISPLAYORDERRF " + Environment.NewLine;
                sqlText += "FROM GOODSSETRF A WITH (READUNCOMMITTED) " + Environment.NewLine;

                if (mode == 0)
                {
                    sqlText += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON A.PARENTGOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.PARENTGOODSNORF=B.CHGDESTGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                }
                if (mode == 1)
                {
                    sqlText += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON A.PARENTGOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.PARENTGOODSNORF=B.CHGDESTGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereStringDisplayOrder(ref sqlCommand, mode, enterpriseCode);

                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    GoodsSetChgWork goodsSetWork = new GoodsSetChgWork();
                    if (myReader != null && goodsSetWork != null)
                    {
                        # region �N���X�֊i�[
                        goodsSetWork.ParentGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARENTGOODSMAKERCDRF"));
                        goodsSetWork.ParentGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNORF"));
                        goodsSetWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                        # endregion
                    }
                    string key = goodsSetWork.ParentGoodsMakerCd.ToString().Trim().PadLeft(4, '0') + ":" + goodsSetWork.ParentGoodsNo.Trim();
                    if (!displayOrderDic.ContainsKey(key))
                    {
                        displayOrderDic.Add(key, goodsSetWork.DisplayOrder);
                    }
                    else
                    {
                        continue;
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetChgDB.SearchDisplayOrderProc");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

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
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="mode">���[�h</param>
        /// <param name="enterpriseCode">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/04/13</br>
        private string MakeWhereStringDisplayOrder(ref SqlCommand sqlCommand, int mode, string enterpriseCode)
        {
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");

            //��ƃR�[�h
            retstring.Append(" A.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            //�_���폜�敪
            retstring.Append(" AND B.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //�}�X�^�敪
            if (mode == 1)
            {
                retstring.Append(" AND B.MASTERDIVCDRF = @FINDMASTERDIVCDRF ").Append(Environment.NewLine);
                SqlParameter paraLogicalMasterDiv = sqlCommand.Parameters.Add("@FINDMASTERDIVCDRF", SqlDbType.Int);
                paraLogicalMasterDiv.Value = SqlDataMediator.SqlSetInt32(6);
            }

            //GROUP BY
            retstring.Append(" GROUP BY A.PARENTGOODSMAKERCDRF, A.PARENTGOODSNORF ");

            return retstring.ToString();
        }
        #endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsSetChgWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>goodsSetChgWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private GoodsSetChgWork CopyToGoodsSetWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsSetChgWork goodsSetWork = new GoodsSetChgWork();

            this.CopyToGoodsSetWorkFromReader(ref myReader, ref goodsSetWork);

            return goodsSetWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsSetChgWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>goodsSetChgWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private GoodsSetChgWork NewNoCopyToGoodsSetWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsSetChgWork goodsSetWork = new GoodsSetChgWork();

            this.NewNoCopyToGoodsSetWorkFromReader(ref myReader, ref goodsSetWork);

            return goodsSetWork;
        }
        #endregion

        #region
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsSetChgWork
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="goodsSetWork"></param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void CopyToGoodsSetWorkFromReader(ref SqlDataReader myReader, ref GoodsSetChgWork goodsSetWork)
        {
            if (myReader != null && goodsSetWork != null)
            {
                # region �N���X�֊i�[
                goodsSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                goodsSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                goodsSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                goodsSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                goodsSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                goodsSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                goodsSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                goodsSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                goodsSetWork.ParentGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARENTGOODSMAKERCDRF"));
                goodsSetWork.ParentGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNORF"));
                goodsSetWork.SubGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBGOODSMAKERCDRF"));
                goodsSetWork.SubGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNORF"));
                goodsSetWork.CntFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CNTFLRF"));
                goodsSetWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                goodsSetWork.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
                goodsSetWork.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));
                goodsSetWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                goodsSetWork.OldPrmSetDtlName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                goodsSetWork.NewPrmSetDtlName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));

                # endregion
            }
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsSetChgWork
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="goodsSetWork"></param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void NewNoCopyToGoodsSetWorkFromReader(ref SqlDataReader myReader, ref GoodsSetChgWork goodsSetWork)
        {
            if (myReader != null && goodsSetWork != null)
            {
                # region �N���X�֊i�[
                goodsSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                goodsSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                goodsSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                goodsSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                goodsSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                goodsSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                goodsSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                goodsSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                goodsSetWork.ParentGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARENTGOODSMAKERCDRF"));
                goodsSetWork.ParentGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNORF"));
                goodsSetWork.SubGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBGOODSMAKERCDRF"));
                goodsSetWork.SubGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNORF"));
                goodsSetWork.CntFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CNTFLRF"));
                goodsSetWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                goodsSetWork.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
                goodsSetWork.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));
                # endregion
            }
        }
        # endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="mode">���[�h</param>
        /// <param name="enterpriseCode">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, int mode, string enterpriseCode)
        {
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");

            //��ƃR�[�h
            retstring.Append(" A.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            //�_���폜�敪
            retstring.Append(" AND B.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //�}�X�^�敪
            if (mode == 1)
            {
                retstring.Append(" AND B.MASTERDIVCDRF = @FINDMASTERDIVCDRF ").Append(Environment.NewLine);
                SqlParameter paraLogicalMasterDiv = sqlCommand.Parameters.Add("@FINDMASTERDIVCDRF", SqlDbType.Int);
                paraLogicalMasterDiv.Value = SqlDataMediator.SqlSetInt32(6);
            }

            //ORDER BY
            retstring.Append(" ORDER BY A.ENTERPRISECODERF, A.PARENTGOODSMAKERCDRF, A.PARENTGOODSNORF, A.SUBGOODSMAKERCDRF, A.SUBGOODSNORF");

            return retstring.ToString();
        }
        #endregion

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̏��i�Z�b�g�}�X�^�̎捞����
        /// </summary>
        /// <param name="goodSetSuccessResultWork"></param>
        /// <param name="errorResultWork"></param>
        /// <param name="count"></param>
        /// <param name="mode"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Note        : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : 2015/04/17</br>
        /// <br>Note        : Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : 2015/04/29</br>
        /// </remarks>
        private int goodSetReadInProc(out ArrayList goodSetSuccessResultWork, out ArrayList errorResultWork, out int count, int mode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // �߂���錋�ʃ��X�g
            goodSetSuccessResultWork = new ArrayList();
            // �G���[���b�Z�[�W
            string message = string.Empty;
            string strMsg;
            count = 0;
            errorResultWork = new ArrayList();
            Dictionary<string, string> _goodsSetSuccessDic = new Dictionary<string, string>();
            Dictionary<string, string> _ctnDic = new Dictionary<string, string>();
            Dictionary<string, string> _logicalDeleteDic = new Dictionary<string, string>();
            Dictionary<string, GoodsSetChgWork> _DelErrorOrSusDic = new Dictionary<string, GoodsSetChgWork>();
            Dictionary<string, string> _insertDic = new Dictionary<string, string>();
            Dictionary<string, int> _displayOrderDic = new Dictionary<string, int>(); // ADD �i�N 2015/04/13 �\�����ʏd���̑Ή�
            // �e���X�g
            ArrayList parentgoodSetSuccessList = new ArrayList();
            // ���������߂���냊�X�g
            ArrayList selectWorkList = new ArrayList();
            // �폜���X�g
            ArrayList deleteWorkList = new ArrayList();
            ArrayList FinalDeleteWorkList = new ArrayList();
            // �ǉ����X�g
            ArrayList insertWorkList = new ArrayList();
            // �_���폜���X�g
            ArrayList logicalDeleteList = new ArrayList();
            // �������X�g
            ArrayList CtnList = new ArrayList();
            // Error���X�g
            ArrayList ErrorList = new ArrayList();

            ArrayList NewNoExistList = new ArrayList();
            ArrayList ExistList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection SearchSubNoSqlConnection = _goodsNoChgCommonDB.CreateSqlConnection(true);
            SqlConnection SearchNewNoSqlConnection = _goodsNoChgCommonDB.CreateSqlConnection(true);

            try
            {
                // --- ADD �i�N 2015/04/13 �\�����ʏd���̑Ή� ------>>>>>
                // �\�����ʂ���������
                status = this.SearchDisplayOrder(out _displayOrderDic, enterpriseCode, mode);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                // --- ADD �i�N 2015/04/13 �\�����ʏd���̑Ή� ------<<<<<
                // ���i�Z�b�g�}�X�^�Ō�������
                status = this.SearchgoodsSet(ref deleteWorkList, out CtnList, enterpriseCode, mode, ref SearchSubNoSqlConnection, out strMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && deleteWorkList.Count > 0)
                {
                    count = deleteWorkList.Count;

                    status = _goodsNoChgCommonDB.DeleteGoodsNoChangeErrorDataProc(enterpriseCode, GoodsNoChgCommonDB.SETMST, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        foreach (GoodsSetChgWork ctnWork in CtnList)
                        {
                            string ctnKey = ctnWork.OldPrmSetDtlName + ctnWork.GoodsMakerCd.ToString();
                            if (!_ctnDic.ContainsKey(ctnKey))
                            {
                                _ctnDic.Add(ctnKey, ctnWork.NewPrmSetDtlName);
                            }
                        }
                        foreach (GoodsSetChgWork goodsSetChgWork in deleteWorkList)
                        {
                            string errorkey = goodsSetChgWork.ParentGoodsMakerCd.ToString() + goodsSetChgWork.ParentGoodsNo + goodsSetChgWork.SubGoodsMakerCd.ToString() + goodsSetChgWork.SubGoodsNo;
                            //�Ώەۗ�
                            if (!_DelErrorOrSusDic.ContainsKey(errorkey))
                            {
                                _DelErrorOrSusDic.Add(errorkey, goodsSetChgWork);
                            }
                            //GoodsSetChgWork --> GoodsSetWork
                            GoodsSetWork goodsSetWork = GoodsSetChgWorkToGoodsSetWork(goodsSetChgWork);
                            FinalDeleteWorkList.Add(goodsSetWork);
                        }
                    }
                    else
                    {
                        return status;
                    }
                }
                else
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    return status;
                }

                // �V���i�Ԃ�ϊ�����
                if (FinalDeleteWorkList != null && FinalDeleteWorkList.Count > 0)
                {
                    for (int i = 0; i < FinalDeleteWorkList.Count; i++)
                    {
                        sqlTransaction.Save("GoodsSetSavePoint");
                        //GoodsSetWork copyGoodsSetWork = CloneSetWork((GoodsSetWork)FinalDeleteWorkList[i]);// DEL 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------>>>>>
                        GoodsSetWork copyGoodsSetWork = null;
                        if (FinalDeleteWorkList != null && FinalDeleteWorkList.Count > 0)
                        {
                            copyGoodsSetWork = CloneSetWork((GoodsSetWork)FinalDeleteWorkList[i]);
                        }
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------<<<<<

                        bool parflag = false;
                        bool subflag = false;
                        GoodsNoChangeErrorDataWork errorWork1 = new GoodsNoChangeErrorDataWork();
                        GoodsNoChangeErrorDataWork errorWork2 = new GoodsNoChangeErrorDataWork();
                        // ���O�t�@�C���f�[�^�̍쐬
                        GoodsSetChgWork SuccessGoodsSetChgWork = new GoodsSetChgWork();
                        SuccessGoodsSetChgWork.ParentGoodsMakerCd = copyGoodsSetWork.ParentGoodsMakerCd;
                        SuccessGoodsSetChgWork.ParentGoodsNo = copyGoodsSetWork.ParentGoodsNo;
                        SuccessGoodsSetChgWork.SubGoodsMakerCd = copyGoodsSetWork.SubGoodsMakerCd;
                        SuccessGoodsSetChgWork.SubGoodsNo = copyGoodsSetWork.SubGoodsNo;
                        SuccessGoodsSetChgWork.AfChgParentGoodsNo = copyGoodsSetWork.ParentGoodsNo;
                        SuccessGoodsSetChgWork.AfChgSubGoodsNo = copyGoodsSetWork.SubGoodsNo;

                        foreach (GoodsSetChgWork goodsSetCtn in CtnList)
                        {
                            if (goodsSetCtn.OldPrmSetDtlName.Equals(copyGoodsSetWork.ParentGoodsNo) && goodsSetCtn.GoodsMakerCd == copyGoodsSetWork.ParentGoodsMakerCd)
                            {
                                errorWork1.GoodsMakerCd = copyGoodsSetWork.ParentGoodsMakerCd;
                                errorWork1.ChgSrcGoodsNo = copyGoodsSetWork.ParentGoodsNo;
                                errorWork1.ChgDestGoodsNo = goodsSetCtn.NewPrmSetDtlName;
                                errorWork1.MasterDivCd = GoodsNoChgCommonDB.SETMST;
                                parflag = true;
                                copyGoodsSetWork.ParentGoodsNo = goodsSetCtn.NewPrmSetDtlName;
                                SuccessGoodsSetChgWork.AfChgParentGoodsNo = goodsSetCtn.NewPrmSetDtlName;
                            }
                            if (goodsSetCtn.OldPrmSetDtlName.Equals(copyGoodsSetWork.SubGoodsNo) && goodsSetCtn.GoodsMakerCd == copyGoodsSetWork.SubGoodsMakerCd)
                            {
                                errorWork2.GoodsMakerCd = copyGoodsSetWork.SubGoodsMakerCd;
                                errorWork2.ChgSrcGoodsNo = copyGoodsSetWork.SubGoodsNo;
                                errorWork2.ChgDestGoodsNo = goodsSetCtn.NewPrmSetDtlName;
                                errorWork2.MasterDivCd = GoodsNoChgCommonDB.SETMST;
                                subflag = true;
                                copyGoodsSetWork.SubGoodsNo = goodsSetCtn.NewPrmSetDtlName;
                                SuccessGoodsSetChgWork.AfChgSubGoodsNo = goodsSetCtn.NewPrmSetDtlName;
                            }
                        }
                        //GoodsSetWork goodsSetWork = (GoodsSetWork)FinalDeleteWorkList[i];// DEL 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------>>>>>
                        GoodsSetWork goodsSetWork = null;
                        if (FinalDeleteWorkList != null && FinalDeleteWorkList.Count > 0)
                        {
                            goodsSetWork = (GoodsSetWork)FinalDeleteWorkList[i];
                        }
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------<<<<<
                        string errKey = goodsSetWork.ParentGoodsMakerCd.ToString() + goodsSetWork.ParentGoodsNo + goodsSetWork.SubGoodsMakerCd.ToString() + goodsSetWork.SubGoodsNo;

                        ArrayList finalDelList = new ArrayList();
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------>>>>>
                        if (FinalDeleteWorkList != null && FinalDeleteWorkList.Count > 0)
                        {
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------<<<<<
                            finalDelList.Add(FinalDeleteWorkList[i]);
                        }// ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�

                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                        try
                        {
                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                            status = this._goodsSetDB.DeleteGoodsSetProc(finalDelList, ref sqlConnection, ref sqlTransaction);
                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "DeleteGoodsSetProc");
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                        finalDelList.Clear();
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //----- ADD 2015/04/07 ���V�� Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�------>>>>>
                            if (!string.IsNullOrEmpty(copyGoodsSetWork.ParentGoodsNo.Trim())
                                && copyGoodsSetWork.ParentGoodsNo.Trim().Equals(copyGoodsSetWork.SubGoodsNo.Trim())
                                && copyGoodsSetWork.ParentGoodsMakerCd == copyGoodsSetWork.SubGoodsMakerCd)
                            {
                                SuccessGoodsSetChgWork.AfContentExplain = GoodsNoChgCommonDB.REPEATSETMSG;
                                errorResultWork.Add(SuccessGoodsSetChgWork);
                                if (parflag)
                                {
                                    ErrorList.Add(errorWork1);
                                }
                                if (subflag)
                                {
                                    ErrorList.Add(errorWork2);
                                }

                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //----- ADD 2015/04/07 ���V�� Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�------<<<<<
                                selectWorkList.Add(copyGoodsSetWork);
                                //���i�ԁ[�[�[���V�i��
                                foreach (GoodsSetWork goodsSetChgWork in selectWorkList)
                                {
                                    if (goodsSetChgWork.LogicalDeleteCode == 1)
                                    {
                                        //SuccessGoodsSetChgWork.AfContentExplain = "�_���폜�f�[�^"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                        SuccessGoodsSetChgWork.AfContentExplain = GoodsNoChgCommonDB.DELETEMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                    }
                                    goodsSetChgWork.UpdateDateTime = DateTime.MinValue;
                                    // --- ADD �i�N 2015/04/13 �\�����ʏd���̑Ή� ------>>>>>
                                    string displayOrderKey = goodsSetChgWork.ParentGoodsMakerCd.ToString().Trim().PadLeft(4, '0') + ":" + goodsSetChgWork.ParentGoodsNo.Trim();
                                    if (_displayOrderDic.ContainsKey(displayOrderKey))
                                    {
                                        goodsSetChgWork.DisplayOrder = _displayOrderDic[displayOrderKey] + 1;
                                    }
                                    //----- ADD 2015/04/29 ���V�� Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�------>>>>>
                                    if (goodsSetChgWork.DisplayOrder > 50)
                                    {
                                        SuccessGoodsSetChgWork.AfContentExplain = GoodsNoChgCommonDB.DISPORDEROVERNUMBER;
                                        errorResultWork.Add(SuccessGoodsSetChgWork);
                                        if (parflag)
                                        {
                                            ErrorList.Add(errorWork1);
                                        }
                                        if (subflag)
                                        {
                                            ErrorList.Add(errorWork2);
                                        }

                                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                    }
                                    else
                                    {
                                    //----- ADD 2015/04/29 ���V�� Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�------<<<<<
                                        // --- ADD �i�N 2015/04/13 �\�����ʏd���̑Ή� ------<<<<<
                                        insertWorkList.Add(goodsSetChgWork);
                                    } // ADD 2015/04/29 ���V�� Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�
                                }
                                selectWorkList.Clear();

                                //----- ADD 2015/04/29 ���V�� Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�------>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //----- ADD 2015/04/29 ���V�� Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�------<<<<<
                                    //�_���폜dic�쐬
                                    foreach (GoodsSetWork goodsSetChgWork in insertWorkList)
                                    {
                                        if (goodsSetChgWork.LogicalDeleteCode == 1)
                                        {
                                            string LogicalDeleteKey = goodsSetChgWork.ParentGoodsMakerCd.ToString() + goodsSetChgWork.ParentGoodsNo + goodsSetChgWork.SubGoodsMakerCd.ToString() + goodsSetChgWork.SubGoodsNo;
                                            if (!_logicalDeleteDic.ContainsKey(LogicalDeleteKey))
                                            {
                                                _logicalDeleteDic.Add(LogicalDeleteKey, string.Empty);
                                            }
                                        }

                                    }
                                    //�ǉ�����
                                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                    try
                                    {
                                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                        status = this._goodsSetDB.WriteGoodsSetProc(ref insertWorkList, ref sqlConnection, ref sqlTransaction);
                                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                    }
                                    catch (Exception ex)
                                    {
                                        base.WriteErrorLog(ex, "WriteGoodsSetProc");
                                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                    }
                                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // --- ADD �i�N 2015/04/13 �\�����ʏd���̑Ή� ------>>>>>
                                        foreach (GoodsSetWork goodsSetWork3 in insertWorkList)
                                        {
                                            string displayOrderKey = goodsSetWork3.ParentGoodsMakerCd.ToString().Trim().PadLeft(4, '0') + ":" + goodsSetWork3.ParentGoodsNo.Trim();
                                            if (_displayOrderDic.ContainsKey(displayOrderKey))
                                            {
                                                _displayOrderDic[displayOrderKey] = _displayOrderDic[displayOrderKey] + 1;
                                            }
                                        }
                                        // --- ADD �i�N 2015/04/13 �\�����ʏd���̑Ή� ------<<<<<
                                        foreach (GoodsSetWork goodsSetWork2 in insertWorkList)
                                        {
                                            string logicalDeleteKey = goodsSetWork2.ParentGoodsMakerCd.ToString() + goodsSetWork2.ParentGoodsNo + goodsSetWork2.SubGoodsMakerCd.ToString() + goodsSetWork2.SubGoodsNo;
                                            if (_logicalDeleteDic.ContainsKey(logicalDeleteKey))
                                            {
                                                logicalDeleteList.Add(goodsSetWork2);
                                            }
                                        }
                                        insertWorkList.Clear();
                                        if (logicalDeleteList != null && logicalDeleteList.Count > 0)
                                        {
                                            //�_���폜��ԕۂ�
                                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                            try
                                            {
                                                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                                status = this._goodsSetDB.LogicalDeleteGoodsSetProc(ref logicalDeleteList, 0, ref sqlConnection, ref sqlTransaction);
                                                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                            }
                                            catch (Exception ex)
                                            {
                                                base.WriteErrorLog(ex, "LogicalDeleteGoodsSetProc");
                                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                            }
                                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                            logicalDeleteList.Clear();
                                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            {
                                                parentgoodSetSuccessList.Add(SuccessGoodsSetChgWork);
                                                logicalDeleteList.Clear();
                                            }
                                            else
                                            {
                                                //SuccessGoodsSetChgWork.AfContentExplain = "�o�^�G���[�A�ϊ���i�Ԃ̓o�^�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                                SuccessGoodsSetChgWork.AfContentExplain = GoodsNoChgCommonDB.NEWEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                                errorResultWork.Add(SuccessGoodsSetChgWork);
                                                if (parflag)
                                                {
                                                    ErrorList.Add(errorWork1);
                                                }
                                                if (subflag)
                                                {
                                                    ErrorList.Add(errorWork2);
                                                }
                                                logicalDeleteList.Clear();
                                            }
                                        }
                                        else
                                        {
                                            parentgoodSetSuccessList.Add(SuccessGoodsSetChgWork);
                                            logicalDeleteList.Clear();
                                        }
                                    }
                                    else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                    {
                                        insertWorkList.Clear();
                                        //SuccessGoodsSetChgWork.AfContentExplain = "�ϊ���i�Ԃ����ɓo�^����܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                        SuccessGoodsSetChgWork.AfContentExplain = string.Format(GoodsNoChgCommonDB.EXISTMSG, "�Z�b�g�}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                        errorResultWork.Add(SuccessGoodsSetChgWork);
                                        if (parflag)
                                        {
                                            ErrorList.Add(errorWork1);
                                        }
                                        if (subflag)
                                        {
                                            ErrorList.Add(errorWork2);
                                        }
                                    }
                                    else
                                    {
                                        insertWorkList.Clear();
                                        //SuccessGoodsSetChgWork.AfContentExplain = "�o�^�G���[�A�ϊ���i�Ԃ̓o�^�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                        SuccessGoodsSetChgWork.AfContentExplain = GoodsNoChgCommonDB.NEWEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                        errorResultWork.Add(SuccessGoodsSetChgWork);
                                        if (parflag)
                                        {
                                            ErrorList.Add(errorWork1);
                                        }
                                        if (subflag)
                                        {
                                            ErrorList.Add(errorWork2);
                                        }
                                    }
                                }// ADD 2015/04/29 ���V�� Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�
                            }// ADD 2015/04/07 ���V�� Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�

                        }
                        //errorList�쐬
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                        {
                            GoodsSetChgWork errorGoodsSetChgWork = _DelErrorOrSusDic[errKey];

                            //errorGoodsSetChgWork.AfContentExplain = "�r���G���[�A�ϊ����i�Ԃ̍폜�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            errorGoodsSetChgWork.AfContentExplain = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "�Z�b�g�}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            string parentkey = errorGoodsSetChgWork.ParentGoodsNo + errorGoodsSetChgWork.ParentGoodsMakerCd.ToString();
                            string subkey = errorGoodsSetChgWork.SubGoodsNo + errorGoodsSetChgWork.SubGoodsMakerCd.ToString();
                            if (_ctnDic.ContainsKey(parentkey))
                            {
                                errorGoodsSetChgWork.AfChgParentGoodsNo = _ctnDic[parentkey];
                                errorGoodsSetChgWork.AfChgSubGoodsNo = errorGoodsSetChgWork.SubGoodsNo;
                                GoodsNoChangeErrorDataWork errorWork3 = GoodsSetChgWorkToErrorWork(errorGoodsSetChgWork, errorGoodsSetChgWork.ParentGoodsMakerCd, errorGoodsSetChgWork.ParentGoodsNo);
                                ErrorList.Add(errorWork3);
                            }
                            if (_ctnDic.ContainsKey(subkey))
                            {
                                errorGoodsSetChgWork.AfChgSubGoodsNo = _ctnDic[subkey];
                                errorGoodsSetChgWork.AfChgParentGoodsNo = errorGoodsSetChgWork.ParentGoodsNo;
                                GoodsNoChangeErrorDataWork errorWork4 = GoodsSetChgWorkToErrorWork(errorGoodsSetChgWork, errorGoodsSetChgWork.SubGoodsMakerCd, errorGoodsSetChgWork.SubGoodsNo);
                                ErrorList.Add(errorWork4);
                            }
                            errorResultWork.Add(errorGoodsSetChgWork);
                            continue;

                        }
                        else
                        {
                            //SuccessGoodsSetChgWork.AfContentExplain = "�폜�G���[�A�ϊ����i�Ԃ̍폜�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            SuccessGoodsSetChgWork.AfContentExplain = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            errorResultWork.Add(SuccessGoodsSetChgWork);
                            if (parflag)
                            {
                                ErrorList.Add(errorWork1);
                            }
                            if (subflag)
                            {
                                ErrorList.Add(errorWork2);
                            }
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback("GoodsSetSavePoint");
                        }
                    }
                }

                goodSetSuccessResultWork = parentgoodSetSuccessList;

                if (ErrorList != null && ErrorList.Count > 0)
                {
                    Dictionary<string, GoodsNoChangeErrorDataWork> repeatDate = new Dictionary<string, GoodsNoChangeErrorDataWork>();
                    string repeatDateKey = "";
                    for (int i = 0; i < ErrorList.Count; i++)
                    {
                        //GoodsNoChangeErrorDataWork errorDataWork = ErrorList[i] as GoodsNoChangeErrorDataWork;// DEL 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------>>>>>
                        GoodsNoChangeErrorDataWork errorDataWork = null;
                        if (ErrorList != null && ErrorList.Count > 0)
                        {
                            errorDataWork = ErrorList[i] as GoodsNoChangeErrorDataWork;
                        }
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------<<<<<
                        repeatDateKey = errorDataWork.GoodsMakerCd.ToString() + "-" + errorDataWork.ChgSrcGoodsNo.Trim();

                        if (!repeatDate.ContainsKey(repeatDateKey))
                        {
                            repeatDate.Add(repeatDateKey, errorDataWork);
                        }
                    }
                    // �i�ԕϊ��G���[�f�[�^��o�^
                    status = _goodsNoChgCommonDB.WriteGoodsNoChangeErrorDataProc(repeatDate, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ErrorList.Clear();
                    }
                    else
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
                return status;
            }

            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetChgDB.goodSetReadInProc");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (SearchNewNoSqlConnection != null)
                {
                    SearchNewNoSqlConnection.Close();
                    SearchNewNoSqlConnection.Dispose();
                }
                if (SearchSubNoSqlConnection != null)
                {
                    SearchSubNoSqlConnection.Close();
                    SearchSubNoSqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// ���[�N��Clone
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        private GoodsSetWork CloneSetWork(GoodsSetWork work)
        {
            GoodsSetWork goodsSetWork = new GoodsSetWork();

            goodsSetWork.CreateDateTime = work.CreateDateTime;
            goodsSetWork.UpdateDateTime = work.UpdateDateTime;
            goodsSetWork.EnterpriseCode = work.EnterpriseCode;
            goodsSetWork.FileHeaderGuid = work.FileHeaderGuid;
            goodsSetWork.UpdEmployeeCode = work.UpdEmployeeCode;
            goodsSetWork.UpdAssemblyId1 = work.UpdAssemblyId1;
            goodsSetWork.UpdAssemblyId2 = work.UpdAssemblyId2;
            goodsSetWork.LogicalDeleteCode = work.LogicalDeleteCode;
            goodsSetWork.ParentGoodsMakerCd = work.ParentGoodsMakerCd;
            goodsSetWork.ParentGoodsNo = work.ParentGoodsNo;
            goodsSetWork.SubGoodsMakerCd = work.SubGoodsMakerCd;
            goodsSetWork.SubGoodsNo = work.SubGoodsNo;
            goodsSetWork.CntFl = work.CntFl;
            goodsSetWork.DisplayOrder = work.DisplayOrder;
            goodsSetWork.SetSpecialNote = work.SetSpecialNote;
            goodsSetWork.CatalogShapeNo = work.CatalogShapeNo;

            return goodsSetWork;
        }

        /// <summary>
        /// �N���X�i�[���� GoodsSetChgWork �� GoodsSetWork
        /// </summary>
        /// <param name="goodsSetChgWork">GoodsSetChgWork �I�u�W�F�N�g</param>
        /// <returns>GoodsSetWork</returns>
        /// <remarks>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private GoodsSetWork GoodsSetChgWorkToGoodsSetWork(GoodsSetChgWork goodsSetChgWork)
        {
            GoodsSetWork goodsSetWork = new GoodsSetWork();
            goodsSetWork.CreateDateTime = goodsSetChgWork.CreateDateTime;
            goodsSetWork.UpdateDateTime = goodsSetChgWork.UpdateDateTime;
            goodsSetWork.EnterpriseCode = goodsSetChgWork.EnterpriseCode;
            goodsSetWork.FileHeaderGuid = goodsSetChgWork.FileHeaderGuid;
            goodsSetWork.UpdEmployeeCode = goodsSetChgWork.UpdEmployeeCode;
            goodsSetWork.UpdAssemblyId1 = goodsSetChgWork.UpdAssemblyId1;
            goodsSetWork.UpdAssemblyId2 = goodsSetChgWork.UpdAssemblyId2;
            goodsSetWork.LogicalDeleteCode = goodsSetChgWork.LogicalDeleteCode;
            goodsSetWork.ParentGoodsMakerCd = goodsSetChgWork.ParentGoodsMakerCd;
            goodsSetWork.ParentGoodsNo = goodsSetChgWork.ParentGoodsNo;
            goodsSetWork.SubGoodsMakerCd = goodsSetChgWork.SubGoodsMakerCd;
            goodsSetWork.SubGoodsNo = goodsSetChgWork.SubGoodsNo;
            goodsSetWork.CntFl = goodsSetChgWork.CntFl;
            goodsSetWork.DisplayOrder = goodsSetChgWork.DisplayOrder;
            goodsSetWork.SetSpecialNote = goodsSetChgWork.SetSpecialNote;
            goodsSetWork.CatalogShapeNo = goodsSetChgWork.CatalogShapeNo;
            return goodsSetWork;
        }

        /// <summary>
        /// �N���X�i�[���� GoodsSetChgWork �� GoodsSetWork
        /// </summary>
        /// <param name="goodsSetChgWork">GoodsSetChgWork �I�u�W�F�N�g</param>
        /// <param name="makercd"></param>
        /// <param name="goodNo"></param>
        /// <returns>GoodsSetWork</returns>
        /// <remarks>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private GoodsNoChangeErrorDataWork GoodsSetChgWorkToErrorWork(GoodsSetChgWork goodsSetChgWork, int makercd, string goodNo)
        {
            GoodsNoChangeErrorDataWork errorDataWork = new GoodsNoChangeErrorDataWork();
            errorDataWork.CreateDateTime = goodsSetChgWork.CreateDateTime;
            errorDataWork.UpdateDateTime = DateTime.MinValue;
            errorDataWork.EnterpriseCode = goodsSetChgWork.EnterpriseCode;
            errorDataWork.FileHeaderGuid = goodsSetChgWork.FileHeaderGuid;
            errorDataWork.UpdEmployeeCode = goodsSetChgWork.UpdEmployeeCode;
            errorDataWork.UpdAssemblyId1 = goodsSetChgWork.UpdAssemblyId1;
            errorDataWork.UpdAssemblyId2 = goodsSetChgWork.UpdAssemblyId2;
            errorDataWork.LogicalDeleteCode = goodsSetChgWork.LogicalDeleteCode;
            errorDataWork.GoodsMakerCd = makercd;
            errorDataWork.ChgSrcGoodsNo = goodNo;
            errorDataWork.ChgDestGoodsNo = goodsSetChgWork.NewPrmSetDtlName;
            errorDataWork.MasterDivCd = GoodsNoChgCommonDB.SETMST;

            return errorDataWork;
        }
    }
}




