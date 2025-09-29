//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �D�ǃf�[�^�폜����
// �v���O�����T�v   : �D�ǃf�[�^�폜����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : ���X��
// �� �� ��  2011/07/15  �C�����e : �A��No.2 �V�K�쐬                      
//----------------------------------------------------------------------------//
// <br>Update Note: 2011/08/17  �A��2 ���X��</br>
// <br>            : REDMINE#23748�̑Ή�</br>
//----------------------------------------------------------------------------//
// <br>Update Note: 2011/08/19  �A��2 ���X��</br>
// <br>            : REDMINE#23820�̑Ή�</br>
// --------------------------------------------------------------------------//
// <br>Update Note: 2011/08/19  �A��2 caohh</br>
// <br>            : REDMINE#23820�̑Ή�</br>
//----------------------------------------------------------------------------//
// <br>Update Note: 2011/08/30  �A��2 ���X��</br>
// <br>            : REDMINE#23820�̑Ή�</br>
// --------------------------------------------------------------------------//
// <br>Update Note: 2015/01/28 ���{</br>
// <br>           : PMSCM�������Ή��̕ύX</br>
// --------------------------------------------------------------------------//
// <br>Update Note: 2015/06/08  ���t</br>
// <br>            : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>
// --------------------------------------------------------------------------//
// <br>Update Note: 2015/08/20  ���t</br>
// <br>            : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>
// --------------------------------------------------------------------------//
//****************************************************************************//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using System.Collections.Generic; 

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �D�ǃf�[�^�폜���������[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : �d�������W�v�f�[�^�X�V�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer	: ���X��</br>
    /// <br>Date		: 2011/07/15</br>
    /// <br>Update Note : 2011/07/21 caohh</br>
    /// <br>            : �D�ǃf�[�^�폜�`�F�b�N���X�g�Ή�</br>
    /// <br>Update Note : 2015/06/08 ���t</br>
    /// <br>�Ǘ��ԍ�    : 11100068-00 </br>
    /// <br>            : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>    
    /// </remarks>
    [Serializable]
    public class YuuRyouDataDelDB : RemoteWithAppLockDB, IYuuRyouDataDelDB
    {
        private int StockDeleteCount = 0;
        private int GoodsDeleteCount = 0;
        private int JoinDeleteCount = 0;
        private int RateDeleteCount = 0; // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
        /// <summary>
        /// �D�ǃf�[�^�폜���������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/07/15</br>
        /// </remarks>
        public YuuRyouDataDelDB()
            : base("PMKHN01516D", "Broadleaf.Application.Remoting.ParamData.MTtlStockSlipWork", "MTTLSTOCKSLIPRF")
        {
        }
        # region [�폜����]
        /// <summary>
        /// �w�肳�ꂽ�����ɗD�ǃf�[�^�𕨗��폜�B
        /// </summary>
        /// <param name="deleteConditionObj">deleteConditionObj�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����ɗD�ǃf�[�^�𕨗��폜���܂��B</br>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/07/13</br>
        public int Delete(ref object deleteConditionObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection connection = this.CreateSqlConnection(true);

            if (connection == null)
            {
                return status;
            }

            SqlTransaction transaction = this.CreateTransaction(ref connection);

            if (transaction == null)
            {
                return status;
            }

            try
            {
                status = this.DeleteProc(ref deleteConditionObj, connection, transaction);
            }
            finally
            {
                if (transaction != null)
                {
                    if (transaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }

                    transaction.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return status;
        }
        # endregion

        // ---- ADD caohh 2011/07/21 ---->>>>
        # region [Search����]
        /// <summary>
        /// �w�肳�ꂽ�����ɗD�ǃf�[�^��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="deleteResultWork">��������</param>
        /// <param name="deleteConditionObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����ɗD�ǃf�[�^��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/07/21</br>
        public int Search(out object deleteResultWork, object deleteConditionObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            deleteResultWork = null;

            DeleteConditionWork deleteConditionWork = deleteConditionObj as DeleteConditionWork;

            try
            {
                status = SearchProc(out deleteResultWork, deleteConditionWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "YuuRyouDataDelDB.Search Exception=" + ex.Message);
                deleteResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����ɗD�ǃf�[�^��S�Ė߂��܂�
        /// </summary>
        /// <param name="deleteResultWork">��������</param>
        /// <param name="deleteConditionWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����ɗD�ǃf�[�^��S�Ė߂��܂�</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/07/21</br>
        /// <br></br>
        private int SearchProc(out object deleteResultWork, DeleteConditionWork deleteConditionWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            deleteResultWork = null;
            ArrayList al = new ArrayList();   //���o����

            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null)
                {
                    return status;
                }

                status = SearchDeleteDataProc(ref al, ref sqlConnection, deleteConditionWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "YuuRyouDataDelDB.SearchProc Exception=" + ex.Message);
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

            deleteResultWork = al;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����ɗD�ǃf�[�^��S�Ė߂��܂�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="deleteConditionWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����ɗD�ǃf�[�^��S�Ė߂��܂�</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/07/21</br>
        /// <br>Update Note: 2011/08/30  �A��2 ���X��</br>
        /// <br>            : REDMINE#23820�̑Ή�</br>
        /// <br></br>
        private int SearchDeleteDataProc(ref ArrayList al, ref SqlConnection sqlConnection, DeleteConditionWork deleteConditionWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region Select���쐬
                //�u�݌ɕi�戵���F�C�݌ɕi�� �`�F�b�N���X�g���o�� ���i�ƍ݌ɍ폜���Ȃ��v�̏ꍇ
                if (deleteConditionWork.GoodsDeleteCode == 4 || deleteConditionWork.GoodsDeleteCode == 3)
                {
                    # region �����ɂ��A���i�}�X�^�i���[�U�[�o�^���j����������;
                    sqlText += " SELECT " + Environment.NewLine;
                    if (deleteConditionWork.DeleteCode == 1 || deleteConditionWork.DeleteCode == 2)
                    {
                        sqlText += " DISTINCT (CAST(GOODSURF.GOODSMAKERCDRF as CHAR(4))+GOODSURF.GOODSNORF) AS FLAG, " + Environment.NewLine;
                    }
                    sqlText += " GOODSURF.GOODSMAKERCDRF, " + Environment.NewLine;//���i���[�J�[�R�[�h
                    sqlText += " MAK.MAKERNAMERF, " + Environment.NewLine;//���[�J�[����
                    sqlText += " GOODSURF.GOODSNORF, " + Environment.NewLine;//���i�ԍ�
                    sqlText += " GOODSURF.GOODSNAMERF, " + Environment.NewLine;//���i����
                    sqlText += " GOODSURF.BLGOODSCODERF, " + Environment.NewLine;//BL���i�R�[�h
                    sqlText += " '' AS WAREHOUSECODERF, " + Environment.NewLine; //�q�ɃR�[�h
                    sqlText += " '' AS WAREHOUSENAMERF, " + Environment.NewLine; //�q�ɖ���                   
                    sqlText += " '' AS WAREHOUSESHELFNORF, " + Environment.NewLine;//�q�ɒI��
                    sqlText += " CAST(0 as bigint) AS SHIPMENTPOSCNTRF, " + Environment.NewLine;//�o�׉\��
                    sqlText += " CAST(0 as bigint)  AS SALESORDERCOUNTRF " + Environment.NewLine;//������
                    sqlText += " FROM " + Environment.NewLine;
                    sqlText += " GOODSURF " + Environment.NewLine;
                    //���[�J�[�}�X�^
                    sqlText += " LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                    sqlText += " ON" + Environment.NewLine;
                    sqlText += "     MAK.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND MAK.GOODSMAKERCDRF=GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                    //�폜�敪:���[�J�[+������/���[�J�[+�O���[�v�R�[�h
                    if (deleteConditionWork.DeleteCode == 1 || deleteConditionWork.DeleteCode == 2)
                    {
                        //DEL by Liangsd   2011/08/30----------------->>>>>>>>>>
                        ////���i�Ǘ����}�X�^
                        //sqlText += " LEFT JOIN GOODSMNGRF " + Environment.NewLine;
                        //sqlText += " ON" + Environment.NewLine;
                        //sqlText += "     GOODSMNGRF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                        //sqlText += " AND GOODSMNGRF.GOODSMAKERCDRF=GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                        //sqlText += " AND GOODSMNGRF.GOODSNORF=GOODSURF.GOODSNORF" + Environment.NewLine;
                        //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<
                        sqlText += " LEFT JOIN BLGOODSCDURF " + Environment.NewLine;
                        sqlText += " ON" + Environment.NewLine;
                        sqlText += "     BLGOODSCDURF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " AND BLGOODSCDURF.BLGOODSCODERF=GOODSURF.BLGOODSCODERF" + Environment.NewLine;

                    }
                    //Where��
                    sqlText += " WHERE " + Environment.NewLine;
                    sqlText += " GOODSURF.ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //�폜�敪:���[�J�[
                    if (deleteConditionWork.DeleteCode == 0)
                    {
                        //���i���[�J�[�R�[�h
                        sqlText += " AND (" + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            //���i�ԍ�
                            sqlText += " AND  GOODSURF.GOODSNORF  NOT IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /*--- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                            --- DEL by caohh 2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            sqlText += " ))" + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            if (deleteConditionWork.Code1 != 0) 
                            {
                                sqlText += " OR " + Environment.NewLine;
                            }
                            sqlText += " ( GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            //���i�ԍ�
                            sqlText += " AND  GOODSURF.GOODSNORF  NOT IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /*--- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                            --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            sqlText += " ))" + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0)
                            {
                                sqlText += " OR " + Environment.NewLine;
                            }
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            //���i�ԍ�
                            sqlText += " AND  GOODSURF.GOODSNORF  NOT IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /*--- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                             --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            sqlText += " ))" + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0)
                            {
                                sqlText += " OR " + Environment.NewLine;
                            }
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            //���i�ԍ�
                            sqlText += " AND  GOODSURF.GOODSNORF  NOT IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /* --- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                            --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            sqlText += " ))"+ Environment.NewLine;
                        }
                        sqlText += " )";
                    }
                    //�폜�敪:���[�J�[+������/���[�J�[+�O���[�v�R�[�h
                    if (deleteConditionWork.DeleteCode == 1 || deleteConditionWork.DeleteCode == 2)
                    {
                        sqlText += " AND GOODSURF.GOODSMAKERCDRF =" + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        //DEL by Liangsd   2011/08/30----------------->>>>>>>>>>
                        //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                        //{
                        //    sqlText += " AND " + Environment.NewLine;
                        //    sqlText += " GOODSMNGRF.SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                        //}
                        //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<
                        //���i�ԍ�
                        sqlText += " AND GOODSURF.GOODSNORF IN (" + Environment.NewLine;
                        //ADD by Liangsd   2011/08/30----------------->>>>>>>>>>
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        if (deleteConditionWork.DeleteCode == 2)
                        {
                            sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            sqlText += " AND (" + Environment.NewLine;
                            if (deleteConditionWork.Code1 != 0)
                            {
                                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code2 != 0)
                            {
                                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code3 != 0)
                            {
                                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                                if (deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            }
                            sqlText += " ) ) ) )";
                        }
                        if (deleteConditionWork.DeleteCode == 1)
                        {
                            sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            sqlText += " AND ( " + Environment.NewLine;
                            sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                            sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            sqlText += " AND ( " + Environment.NewLine;
                            if (deleteConditionWork.Code1 != 0)
                            {
                                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code2 != 0)
                            {
                                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code3 != 0)
                            {
                                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                                if (deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            }
                            sqlText += ") ) ) ) ) )";
                        }
                        //ADD by Liangsd   2011/08/30-----------------<<<<<<<<<<

                        //DEL by Liangsd   2011/08/30----------------->>>>>>>>>>
                        //sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                        //sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        
                        //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                        //{
                        //    sqlText += " AND " + Environment.NewLine;
                        //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                        //}
                       
                        //sqlText += " AND " + Environment.NewLine;
                        //sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        //if (deleteConditionWork.DeleteCode == 1)
                        //{
                        //    sqlText += " AND ( " + Environment.NewLine;
                        //    if (deleteConditionWork.Code1 != 0)
                        //    {
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code2 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code3 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code4 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        //    }
                        //    sqlText += " ) ";
                        //}
                        //if (deleteConditionWork.DeleteCode == 2)
                        //{
                        //    sqlText += " AND GOODSMGROUPRF IN (" + Environment.NewLine;
                        //    sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
                        //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        //    sqlText += " AND (" + Environment.NewLine;
                        //    if (deleteConditionWork.Code1 != 0)
                        //    {
                        //        sqlText += " BLGROUPCODERF= " + deleteConditionWork.Code1 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code2 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code3 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code4 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        //    }
                        //    sqlText += " ) ) ";
                        //}
                        //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<
                        sqlText += " AND GOODSNORF NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        /* --- DEL by caohh  2011/08/19---------------->>>>>
                        if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                        {
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                        }
                         --- DEL by caohh  2011/08/19----------------<<<<<*/
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " ) ";
                    }
                    # endregion
                }
                //�u�݌ɕi�戵���F�B�`�F�b�N���X�g���o�͂��āA�݌Ƀ}�X�^���폜����v�̏ꍇ
                if (deleteConditionWork.GoodsDeleteCode == 3)
                {
                    # region �����ɂ��A�݌Ƀ}�X�^�Ə��i�}�X�^�i���[�U�[�o�^���j����������;
                    sqlText += " UNION ALL " + Environment.NewLine;
                    sqlText += " SELECT " + Environment.NewLine;
                    if (deleteConditionWork.DeleteCode == 1 || deleteConditionWork.DeleteCode == 2)
                    {
                        sqlText += " '' AS FLAG, " + Environment.NewLine;
                    }
                    sqlText += " GOODSURF.GOODSMAKERCDRF, " + Environment.NewLine;//���i���[�J�[�R�[�h
                    sqlText += " MAK.MAKERNAMERF, " + Environment.NewLine;//���[�J�[����
                    sqlText += " GOODSURF.GOODSNORF, " + Environment.NewLine;//���i�ԍ�
                    sqlText += " GOODSURF.GOODSNAMERF, " + Environment.NewLine;//���i����
                    sqlText += " GOODSURF.BLGOODSCODERF, " + Environment.NewLine;//BL���i�R�[�h
                    sqlText += " STOCKRF.WAREHOUSECODERF, " + Environment.NewLine; //�q�ɃR�[�h
                    sqlText += " WARE.WAREHOUSENAMERF, " + Environment.NewLine; //�q�ɖ���                   
                    sqlText += " STOCKRF.WAREHOUSESHELFNORF, " + Environment.NewLine;//�q�ɒI��
                    sqlText += " STOCKRF.SHIPMENTPOSCNTRF, " + Environment.NewLine;//�o�׉\��
                    sqlText += " STOCKRF.SALESORDERCOUNTRF " + Environment.NewLine;//������                                   
                    sqlText += " FROM " + Environment.NewLine;
                    sqlText += " GOODSURF " + Environment.NewLine;
                    //���[�J�[�}�X�^
                    sqlText += " LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                    sqlText += " ON" + Environment.NewLine;
                    sqlText += "     MAK.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND MAK.GOODSMAKERCDRF=GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                    //�݌Ƀ}�X�^
                    sqlText += " LEFT JOIN STOCKRF" + Environment.NewLine;
                    sqlText += " ON STOCKRF.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND STOCKRF.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " AND STOCKRF.GOODSNORF = GOODSURF.GOODSNORF" + Environment.NewLine;
                    //�q�Ƀ}�X�^
                    sqlText += " LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                    sqlText += " ON" + Environment.NewLine;
                    sqlText += "     WARE.ENTERPRISECODERF=STOCKRF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND WARE.WAREHOUSECODERF=STOCKRF.WAREHOUSECODERF" + Environment.NewLine;
                    //WHERE��
                    sqlText += " WHERE  " + Environment.NewLine;
                    sqlText += " GOODSURF.ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    /* --- DEL by caohh  2011/08/19---------------->>>>>
                    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                    {
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " STOCKRF.SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                    }
                     --- DEL by caohh  2011/08/19----------------<<<<<*/
                    //�폜�敪:���[�J�[
                    if (deleteConditionWork.DeleteCode == 0)
                    {
                        //���i�}�X�^
                        sqlText += " AND ( " + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " STOCKRF.GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            //���i�ԍ�
                            sqlText += " AND  GOODSURF.GOODSNORF IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /* --- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                             --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            sqlText += " ) )";
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            if (deleteConditionWork.Code1 != 0)
                            {
                                sqlText += " OR " + Environment.NewLine;
                            }
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " STOCKRF.GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            //���i�ԍ�
                            sqlText += " AND  GOODSURF.GOODSNORF IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /*--- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                            --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            sqlText += " ) )";
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0)
                            {
                                sqlText += " OR " + Environment.NewLine;
                            }
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " STOCKRF.GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            //���i�ԍ�
                            sqlText += " AND  GOODSURF.GOODSNORF IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /*--- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                            --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            sqlText += " ) )";
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0)
                            {
                                sqlText += " OR " + Environment.NewLine;
                            }
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " STOCKRF.GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            //���i�ԍ�
                            sqlText += " AND  GOODSURF.GOODSNORF IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /* --- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                             --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            sqlText += "  ) )";
                        }
                        sqlText += " )";
                    }
                    //�폜�敪:���[�J�[�{������/���[�J�[�{�O���[�v�R�[�h
                    if (deleteConditionWork.DeleteCode == 1 || deleteConditionWork.DeleteCode == 2)
                    {
                        //���i�}�X�^
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSURF.GOODSNORF IN ( " + Environment.NewLine;

                        //ADD by Liangsd   2011/08/30----------------->>>>>>>>>>
                        sqlText += " SELECT STOCK.GOODSNORF FROM GOODSURF " + Environment.NewLine;
                        sqlText += " INNER JOIN  STOCKRF AS STOCK " + Environment.NewLine;
                        sqlText += " ON STOCK.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " AND STOCK.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                        sqlText += " AND STOCK.GOODSNORF = GOODSURF.GOODSNORF" + Environment.NewLine;
                        sqlText += " WHERE " + Environment.NewLine;
                        sqlText += " GOODSURF.ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " GOODSURF.BLGOODSCODERF IN ( " + Environment.NewLine;
                        if (deleteConditionWork.DeleteCode == 1)
                        {
                            sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            sqlText += " AND ( " + Environment.NewLine;
                            sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                            sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            sqlText += " AND ( " + Environment.NewLine;
                            if (deleteConditionWork.Code1 != 0)
                            {
                                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code2 != 0)
                            {
                                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code3 != 0)
                            {
                                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                                if (deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            }
                            sqlText += ") ) ) ) ) )";
                        }
                        if (deleteConditionWork.DeleteCode == 2)
                        {
                            sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            sqlText += " AND (" + Environment.NewLine;
                            if (deleteConditionWork.Code1 != 0)
                            {
                                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code2 != 0)
                            {
                                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code3 != 0)
                            {
                                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                                if (deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            }
                            sqlText += " ) ) ) )";
                        }
                        //ADD by Liangsd   2011/08/30-----------------<<<<<<<<<<
                        //DEL by Liangsd   2011/08/30----------------->>>>>>>>>>
                        //sqlText += " SELECT STOCK.GOODSNORF FROM GOODSMNGRF AS GOODSMNG " + Environment.NewLine;
                        //sqlText += " INNER JOIN  STOCKRF AS STOCK " + Environment.NewLine;
                        //sqlText += " ON STOCK.ENTERPRISECODERF = GOODSMNG.ENTERPRISECODERF" + Environment.NewLine;
                        ////sqlText += " AND STOCK.SECTIONCODERF = GOODSMNG.SECTIONCODERF" + Environment.NewLine;//DEL by Liangsd     2011/08/19
                        //sqlText += " AND STOCK.GOODSMAKERCDRF = GOODSMNG.GOODSMAKERCDRF" + Environment.NewLine;
                        //sqlText += " AND STOCK.GOODSNORF = GOODSMNG.GOODSNORF" + Environment.NewLine;
                        //sqlText += " WHERE " + Environment.NewLine;
                        //sqlText += " GOODSMNG.ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                       
                        //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                        //{
                        //    sqlText += " AND " + Environment.NewLine;
                        //    sqlText += " GOODSMNG.SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                        //}
                        
                        //sqlText += " AND GOODSMNG.GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        //if (deleteConditionWork.DeleteCode == 1)
                        //{
                        //    sqlText += " AND ( " + Environment.NewLine;
                        //    if (deleteConditionWork.Code1 != 0)
                        //    {
                        //        sqlText += " GOODSMNG.GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code2 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code3 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code4 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        //    }
                        //    sqlText += " ) ) ";
                        //}
                        //if (deleteConditionWork.DeleteCode == 2)
                        //{
                        //    sqlText += " AND GOODSMGROUPRF IN (" + Environment.NewLine;
                        //    sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
                        //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        //    sqlText += " AND (" + Environment.NewLine;
                        //    if (deleteConditionWork.Code1 != 0)
                        //    {
                        //        sqlText += " BLGROUPCODERF= " + deleteConditionWork.Code1 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code2 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code3 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code4 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        //    }
                        //    sqlText += " ) ) ) ";
                        //}
                        //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<
                    }
                    //ORDER BY
                    sqlText += " ORDER BY GOODSMAKERCDRF, GOODSNORF, WAREHOUSECODERF " + Environment.NewLine;
                    # endregion
                }

                sqlCommand.CommandText = sqlText;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    DeleteResultWork deleteResultWork = new DeleteResultWork();
                    #region [���o����-�l�Z�b�g]
                    deleteResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));�@ // ���i���[�J�[�R�[�h
                    deleteResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));�@ // ���[�J�[����
                    deleteResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));�@         // ���i�ԍ�
                    deleteResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL���i�R�[�h
                    deleteResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF")); �@�@�@// ���i����
                    if (deleteConditionWork.GoodsDeleteCode == 3)
                    {
                        deleteResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));         // �q�ɃR�[�h
                        deleteResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));         // �q�ɖ���
                        deleteResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));           // �q�ɒI��
                        deleteResultWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));            //�o�׉\��
                        deleteResultWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));                   // ������
                    }
                    #endregion

                    al.Add(deleteResultWork);
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
                base.WriteErrorLog(ex, "YuuRyouDataDelDB.SearchDeleteDataProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        # endregion [Search����]
        // ---- ADD caohh 2011/07/21 ----<<<<

        #region ���[�J�[�R�[�h�𕨗��폜�B
        /// <summary>
        /// ���[�J�[�R�[�h�𕨗��폜���܂��B
        /// </summary>
        /// <param name="deleteConditionObj">deleteConditionObj�I�u�W�F�N�g</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>        /// <remarks>
        /// <br>Note		: ���[�J�[�R�[�h�𕨗��폜�����������܂��B</br>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/07/13</br>
        /// <br>Update Note : 2015/06/08 ���t</br>
        /// <br>�Ǘ��ԍ�    : 11100068-00 </br>
        /// <br>            : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>     
        /// </remarks>
        /// <returns>STATUS</returns>
        private int DeleteProc(ref object deleteConditionObj, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            DeleteConditionWork deleteConditionWork = (DeleteConditionWork)deleteConditionObj;
            status = SearchStockDelete(ref deleteConditionWork, connection, transaction);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = SearchGoodsDelete(ref deleteConditionWork, connection, transaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = SearchJoinDelete(ref deleteConditionWork, connection, transaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
                        status = SearchRateDelete(ref deleteConditionWork, connection, transaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                        if (deleteConditionWork.RateDeleteCode != 9)
                        {
                            status = DeleteRateUProc(ref deleteConditionWork, connection, transaction);
                            deleteConditionWork.RateNotDeleteCnt = RateDeleteCount - deleteConditionWork.RateDeleteCnt;
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return status;
                            }
                        }
                        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<
                        if ((deleteConditionWork.GoodsDeleteCode == 1 || deleteConditionWork.GoodsDeleteCode == 3) && deleteConditionWork.JoinDeleteCode == 1)
                        {
                            status = DeleteStockProc(ref deleteConditionWork, connection, transaction);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                            }
                            else
                            {
                                return status;
                            }
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                /*----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                                status = DeleteRateUProc(ref deleteConditionWork, connection, transaction); 
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                  ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                                status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                                /*----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                                }
                                else
                                {
                                    return status;
                                }
                                  ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    DeleteGoodsUProc(ref deleteConditionWork, connection, transaction);
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                                deleteConditionWork.GoodsNotDeleteCnt = GoodsDeleteCount - deleteConditionWork.GoodsDeleteCnt;
                            }
                            else
                            {
                                return status;
                            }
                        }
                        if ((deleteConditionWork.GoodsDeleteCode == 1 || deleteConditionWork.GoodsDeleteCode == 3) && deleteConditionWork.JoinDeleteCode == 2)
                        {
                            status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                            deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = DeleteStockProc(ref deleteConditionWork, connection, transaction);
                            }
                            else
                            {
                                return status;
                            }
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                /*----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                                 status = DeleteRateUProc(ref deleteConditionWork, connection, transaction); 
                                 if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                 {
                                  ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                                status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                                /*----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                                }
                                else
                                {
                                    return status;
                                }
                                 ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    DeleteGoodsUProc(ref deleteConditionWork, connection, transaction);
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                                deleteConditionWork.GoodsNotDeleteCnt = GoodsDeleteCount - deleteConditionWork.GoodsDeleteCnt;
                            }
                            else
                            {
                                return status;
                            }
                        }
                        if ((deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4) && deleteConditionWork.JoinDeleteCode == 1)
                        {
                            /*----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                             status = DeleteRateUProc(ref deleteConditionWork, connection, transaction); 
                             if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                             {
                              ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                                status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                                //ADD by tianjw     2011/09/05------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                    deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by tianjw     2011/09/05-------------<<<<<<<<<<<
                                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    DeleteGoodsUProc(ref deleteConditionWork, connection, transaction);
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                                deleteConditionWork.GoodsNotDeleteCnt = GoodsDeleteCount - deleteConditionWork.GoodsDeleteCnt;
                                //DEL by tianjw     2011/09/05------------->>>>>>>>>>>
                                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                //{
                                //    status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                //    deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                                //}
                                //else
                                //{
                                //    return status;
                                //}
                                //DEL by tianjw     2011/09/05-------------<<<<<<<<<<<
                            /*----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                            else
                            {
                                return status;
                            }
                              ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                        }
                        if ((deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4) && deleteConditionWork.JoinDeleteCode == 2)
                        {
                            /*----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                            status = DeleteRateUProc(ref deleteConditionWork, connection, transaction); 
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                              ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                            status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                            /*----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                            }
                            else
                            {
                                return status;
                            }
                              ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                                //ADD by tianjw     2011/09/05------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                    deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by tianjw     2011/09/05-------------<<<<<<<<<<<
                                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    DeleteGoodsUProc(ref deleteConditionWork, connection, transaction);
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                                deleteConditionWork.GoodsNotDeleteCnt = GoodsDeleteCount - deleteConditionWork.GoodsDeleteCnt;
                                //DEL by tianjw     2011/09/05------------->>>>>>>>>>>
                                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                //{
                                //    status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                //    deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                                //}
                                //else
                                //{
                                //    return status;
                                //}
                                //DEL by tianjw     2011/09/05-------------<<<<<<<<<<<

                            }
                            else
                            {
                                return status;
                            }
                        }
                        if ((deleteConditionWork.GoodsDeleteCode == 1 || deleteConditionWork.GoodsDeleteCode == 3) && deleteConditionWork.JoinDeleteCode == 9)
                        {
                            status = DeleteStockProc(ref deleteConditionWork, connection, transaction);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                /*----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                                status = DeleteRateUProc(ref deleteConditionWork, connection, transaction); 
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                  ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                                status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                                /*----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                                }
                                else
                                {
                                    return status;
                                }
                                  ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/

                                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    DeleteGoodsUProc(ref deleteConditionWork, connection, transaction);
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                                deleteConditionWork.GoodsNotDeleteCnt = GoodsDeleteCount - deleteConditionWork.GoodsDeleteCnt;
                            }
                            else
                            {
                                return status;
                            }
                        }
                        if ((deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4) && deleteConditionWork.JoinDeleteCode == 9)
                        {
                            // status = DeleteRateUProc(ref deleteConditionWork, connection, transaction); // DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                            }
                            else
                            {
                                return status;
                            }

                            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                DeleteGoodsUProc(ref deleteConditionWork, connection, transaction);
                            }
                            else
                            {
                                return status;
                            }
                            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                            deleteConditionWork.GoodsNotDeleteCnt = GoodsDeleteCount - deleteConditionWork.GoodsDeleteCnt;
                        }
                        if (deleteConditionWork.GoodsDeleteCode == 9 && deleteConditionWork.JoinDeleteCode == 1)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                            }
                            else
                            {
                                return status;
                            }
                        }
                        if (deleteConditionWork.GoodsDeleteCode == 9 && deleteConditionWork.JoinDeleteCode == 2)
                        {
                                status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                            
                        }
                    }
                    else
                    {
                        return status;
                    }
                }
                else
                {
                    return status;
                }
            }
            else
            {
                return status;
            }
            deleteConditionWork.StockNotDeleteCnt = StockDeleteCount - deleteConditionWork.StockDeleteCnt;
            return status;
        }
        #endregion
        //DEL by Liangsd 2011/08/30------>>>>>>>>
        #region DeleteSource
        //#region �݌Ƀ}�X�^�폜
        ///// <summary>
        /////    �݌Ƀ}�X�^�폜
        ///// </summary>
        ///// <param name="deleteConditionWork"></param>
        ///// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="transaction">�g�����U�N�V�������</param>
        ///// <br>Programmer	: ���X��</br>
        ///// <br>Date		: 2011/07/13</br>
        ///// <br>Update Note: 2011/08/19  �A��2 ���X��</br>
        ///// <br>            : REDMINE#23820�̑Ή�</br>
        ///// <returns></returns>
        //private int DeleteStockProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    try
        //    {
        //        # region �����ɂ��A�݌Ƀ}�X�^���폜����
        //        string sqlText = string.Empty;
        //        sqlText += " DELETE " + Environment.NewLine;
        //        sqlText += " FROM " + Environment.NewLine;
        //        sqlText += " STOCKRF " + Environment.NewLine;
        //        sqlText += "  WHERE  " + Environment.NewLine;
        //        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //        //DEL by Liangsd     2011/08/19---------------->>>>>>>>>>>>
        //        //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //        //{
        //        //    sqlText += " AND " + Environment.NewLine;
        //        //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //        //}
        //        //DEL by Liangsd     2011/08/19-----------------<<<<<<<<<<<<
        //        if (deleteConditionWork.DeleteCode == 0)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " )";
        //        }
        //         if (deleteConditionWork.DeleteCode == 1)
        //         {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSNORF in ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //            }
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine; 
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) )";
        //        }
        //        if (deleteConditionWork.DeleteCode == 2)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //            }
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMGROUPRF  IN (  "   + Environment.NewLine;
        //            sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) )";
        //        }
        //        using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
        //        {
        //            deleteConditionWork.StockDeleteCnt = command.ExecuteNonQuery();
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //        # endregion
        //    }
        //    catch (SqlException ex)
        //    {
        //        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
        //        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
        //    }
        //    return status;
        //}
        //#endregion
        
        //#region ���i�}�X�^�폜
        ////ADD by Liangsd     2011/08/17------------------->>>>>>>>>>
        ///// <summary>
        ///// ���i�}�X�^�폜
        ///// </summary>
        ///// <param name="deleteConditionWork"></param>
        ///// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="transaction">�g�����U�N�V�������</param>
        ///// <br>Programmer	: ���X��</br>
        ///// <br>Date		: 2011/07/13</br>
        ///// <returns></returns>
        //private int DeleteGoodsUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    try
        //    {
        //        # region �����ɂ��A���i�}�X�^�i���[�U�[�o�^���j���폜����;
        //        string sqlText = string.Empty;
        //        sqlText += " DELETE " + Environment.NewLine;
        //        sqlText += " FROM " + Environment.NewLine;
        //        sqlText += " GOODSURF " + Environment.NewLine;
        //        sqlText += " WHERE " + Environment.NewLine;
        //        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //        //�폜�敪 = ���[�J�[
        //        if (deleteConditionWork.DeleteCode == 0)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " )";
        //        // �݌ɕi�戵���F�A�C�݌ɕi���A���i�^�݌ɂǂ�����폜���Ȃ���
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {

        //                sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) )";
        //            }
        //        }
        //        //�폜�敪 = ���[�J�[+������
        //        if (deleteConditionWork.DeleteCode == 1)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) )";
        //            // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            { 
        //                sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) )";
        //            }
        //        }
        //        //�폜�敪 =���[�J�[ +  �O���[�v�R�[�h
        //        if (deleteConditionWork.DeleteCode == 2)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            sqlText += " GOODSMGROUPRF IN ( "  + Environment.NewLine;
        //            sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) ) ) )";

        //            // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {
        //                sqlText += "  AND  ( GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += "GOODSMGROUPRF IN (  "  + Environment.NewLine;
        //                sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) ) ) )";
        //            }
        //        }
        //        using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
        //        {
        //            deleteConditionWork.GoodsDeleteCnt = command.ExecuteNonQuery();
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //        # endregion
        //    }
        //    catch (SqlException ex)
        //    {
        //        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
        //        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
        //    }
        //    return status;
        //}
        ////ADD by Liangsd     2011/08/17-------------------<<<<<<<<<<
        //#endregion
        //#region ���i�}�X�^�폜
        ///// <summary>
        ///// ���i�}�X�^�폜
        ///// </summary>
        ///// <param name="deleteConditionWork"></param>
        ///// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="transaction">�g�����U�N�V�������</param>
        ///// <br>Programmer	: ���X��</br>
        ///// <br>Date		: 2011/08/17</br>
        ///// <br>Update Note: 2011/08/17  �A��2 ���X��</br>
        ///// <br>            : REDMINE#23748�̑Ή�</br>
        ///// <returns></returns>
        //private int DeleteGoodsPriceUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    try
        //    {
        //        # region �����ɂ��A���i�}�X�^�i���[�U�[�o�^���j���폜����;
        //        string sqlText = string.Empty;
        //        sqlText += " DELETE " + Environment.NewLine;
        //        sqlText += " FROM " + Environment.NewLine;
        //        sqlText += " GOODSPRICEURF " + Environment.NewLine;
        //        sqlText += " WHERE " + Environment.NewLine;
        //        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //        //�폜�敪 = ���[�J�[
        //        if (deleteConditionWork.DeleteCode == 0)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " )";
        //            // �݌ɕi�戵���F�A�C�݌ɕi���A���i�^�݌ɂǂ�����폜���Ȃ���
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {

        //                sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) )";
        //            }
        //        }
        //        //�폜�敪 = ���[�J�[+������
        //        if (deleteConditionWork.DeleteCode == 1)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) )";
        //            // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {
        //                sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) )";
        //            }
        //        }
        //        //�폜�敪 =���[�J�[ +  �O���[�v�R�[�h
        //        if (deleteConditionWork.DeleteCode == 2)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            sqlText += " GOODSMGROUPRF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) ) ) )";

        //            // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {
        //                sqlText += "  AND  ( GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += "GOODSMGROUPRF IN (  " + Environment.NewLine;
        //                sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) ) ) )";
        //            }
        //        }
        //        # endregion
        //        using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
        //        {
        //            int i = command.ExecuteNonQuery();
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
        //        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
        //    }
        //    return status;
        //}
        //#endregion
        //ADD by Liangsd  2011/08/19--------------->>>>>>>>>>>>>>
        //#region �|���}�X�^�폜
        ///// <summary>
        ///// �|���}�X�^�폜
        ///// </summary>
        ///// <param name="deleteConditionWork"></param>
        ///// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="transaction">�g�����U�N�V�������</param>
        ///// <br>Programmer	: ���X��</br>
        ///// <br>Date		: 2011/08/19</br>
        ///// <br>Update Note: 2011/08/19  �A��2 ���X��</br>
        ///// <br>            : REDMINE#23820�̑Ή�</br>
        ///// <returns></returns>
        //private int DeleteRateUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    try
        //    {
        //        # region �����ɂ��A���i�}�X�^�i���[�U�[�o�^���j���폜����;
        //        string sqlText = string.Empty;
        //        sqlText += " DELETE " + Environment.NewLine;
        //        sqlText += " FROM " + Environment.NewLine;
        //        sqlText += " RATERF " + Environment.NewLine;
        //        sqlText += " WHERE " + Environment.NewLine;
        //        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //        sqlText += " AND " + Environment.NewLine;//ADDby Liangsd     2011/08/19
        //        sqlText += " SECTIONCODERF= '00'";//ADDby Liangsd     2011/08/19
        //        //�폜�敪 = ���[�J�[
        //        if (deleteConditionWork.DeleteCode == 0)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " )";
        //            // �݌ɕi�戵���F�A�C�݌ɕi���A���i�^�݌ɂǂ�����폜���Ȃ���
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {

        //                sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) )";
        //            }
        //        }
        //        //�폜�敪 = ���[�J�[+������
        //        if (deleteConditionWork.DeleteCode == 1)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) )";
        //            // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {
        //                sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) )";
        //            }
        //        }
        //        //�폜�敪 =���[�J�[ +  �O���[�v�R�[�h
        //        if (deleteConditionWork.DeleteCode == 2)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            sqlText += " GOODSMGROUPRF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) ) ) )";

        //            // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {
        //                sqlText += "  AND  ( GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += "GOODSMGROUPRF IN (  " + Environment.NewLine;
        //                sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) ) ) )";
        //            }
        //        }
        //        # endregion
        //        using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
        //        {
        //            int i = command.ExecuteNonQuery();
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
        //        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
        //    }
        //    return status;
        //}
        //#endregion
        //ADD by Liangsd  2011/08/19---------------<<<<<<<<<<<<<<
        //#region �����}�X�^�i���[�U�[�o�^�j�폜
        ///// <summary>
        ///// �����}�X�^�i���[�U�[�o�^�j�폜
        ///// </summary>
        ///// <param name="deleteConditionWork"></param>
        ///// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="transaction">�g�����U�N�V�������</param>
        ///// <br>Programmer	: ���X��</br>
        ///// <br>Date		: 2011/07/13</br>
        ///// <returns></returns>
        //private int DeleteJoinPartsUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    try
        //    {
        //        # region �����ɂ��A���i�}�X�^�i���[�U�[�o�^���j���폜����;
        //        string sqlText = string.Empty;
        //        sqlText += " DELETE " + Environment.NewLine;
        //        sqlText += " FROM " + Environment.NewLine;
        //        sqlText += " JOINPARTSURF " + Environment.NewLine;
        //        sqlText += " WHERE " + Environment.NewLine;
        //        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //        //�폜�敪 = ���[�J�[
        //        if (deleteConditionWork.DeleteCode == 0)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " (JOINDESTMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " )";
        //            // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
        //            if (deleteConditionWork.JoinDeleteCode == 2)
        //            {
        //                sqlText += "  AND  JOINDESTPARTSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) )";
        //            }
        //        }

        //        //�폜�敪 = ���[�J�[ + �O���[�v�R�[�h
        //        if (deleteConditionWork.DeleteCode == 1)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) )";
                    
        //            // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
        //            if (deleteConditionWork.JoinDeleteCode == 2)
        //            {
        //                sqlText += "  AND  JOINDESTPARTSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) )";
        //            }
        //        }

        //        //�폜�敪 =���[�J�[ +  ������
        //        if (deleteConditionWork.DeleteCode == 1)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            sqlText += " GOODSMGROUPRF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) ) ) )";
        //            // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
        //            if (deleteConditionWork.JoinDeleteCode == 2)
        //            {
        //                sqlText += "  AND  ( JOINDESTPARTSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += "GOODSMGROUPRF IN (  " + Environment.NewLine;
        //                sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) ) ) )";
        //            }
        //        }
        //        using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
        //        {
        //            deleteConditionWork.JoinDeleteCnt = command.ExecuteNonQuery();
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //        # endregion
        //    }
        //    catch (SqlException ex)
        //    {
        //        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
        //        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
        //    }
        //    return status;
        //}
        //#endregion
        #endregion
        //DEL by Liangsd 2011/08/30------<<<<<<<<

        #region �݌Ƀ}�X�^�폜��������
        /// <summary>
        /// �݌Ƀ}�X�^�폜��������
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/07/13</br>
        /// <br>Update Note: 2011/08/30  �A��2 ���X��</br>
        /// <br>            : REDMINE#23820�̑Ή�</br>
        /// <returns></returns>
        private int SearchStockDelete(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string sqlText = string.Empty;
                sqlText += " SELECT COUNT(*) " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " STOCKRF " + Environment.NewLine;
                sqlText += "  WHERE  " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //DEL by Liangsd 2011/08/30 ------------>>>>>>>>>>>>>
                //if (deleteConditionWork.DeleteCode == 0)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " )";
                //}
                //if (deleteConditionWork.DeleteCode == 1)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSNORF in ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                //    {
                //        sqlText += " AND " + Environment.NewLine;
                //        sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                //    }
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    if (deleteConditionWork.Code1 != 0)
                //    {
                //        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //        if (deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " ) )";
                //}
                //if (deleteConditionWork.DeleteCode == 2)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                //    {
                //        sqlText += " AND " + Environment.NewLine;
                //        sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                //    }
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMGROUPRF  IN (  " + Environment.NewLine;
                //    sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    if (deleteConditionWork.Code1 != 0)
                //    {
                //        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //        if (deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " ) ) )";
                //}
                //DEL by Liangsd 2011/08/30 ------------<<<<<<<<<<<<
                //ADD by Liangsd 2011/08/30 ------------>>>>>>>>>>>>
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                }
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) )";
                }
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += ") ) ) ) )";
                }
                //ADD by Liangsd 2011/08/30 ------------<<<<<<<<<<<<<<<
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    SqlDataReader sdr = command.ExecuteReader();
                    if (sdr.Read())
                    {
                        StockDeleteCount = sdr.GetInt32(0);
                    }
                    sdr.Close();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion

        #region ���i�}�X�^�폜��������
        /// <summary>
        /// ���i�}�X�^�폜��������
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/07/13</br>
        /// <br>Update Note: 2011/08/30  �A��2 ���X��</br>
        /// <br>            : REDMINE#23820�̑Ή�</br>
        /// <returns></returns>
        private int SearchGoodsDelete(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT COUNT( * )  " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " GOODSURF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //DEL by Liangsd 2011/08/30 ------------>>>>>>>>>>>>
                ////�폜�敪 = ���[�J�[
                //if (deleteConditionWork.DeleteCode == 0)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " )";
                //}
                ////�폜�敪 = ���[�J�[+������
                //if (deleteConditionWork.DeleteCode == 1)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
                //    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                //    {
                //        sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                //        sqlText += " AND " + Environment.NewLine;
                //    }
                //    //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                //    if (deleteConditionWork.Code1 != 0)
                //    {
                //        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //        if (deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " ) ) )";
                //}
                ////�폜�敪 =���[�J�[ +  �O���[�v�R�[�h
                //if (deleteConditionWork.DeleteCode == 2)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
                //    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                //    {
                //        sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                //        sqlText += " AND " + Environment.NewLine;
                //    }
                //    //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                //    sqlText += " GOODSMGROUPRF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    if (deleteConditionWork.Code1 != 0)
                //    {
                //        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //        if (deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " ) ) ) ) )";
                //}
                //DEL by Liangsd 2011/08/30 ------------<<<<<<<<<<<<
                //ADD by Liangsd 2011/08/30 ------------>>>>>>>>>>>>
                //�폜�敪 = ���[�J�[
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                }
                //�폜�敪 = ���[�J�[+�O���[�v�R�[�h
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) )";
                }
                //�폜�敪 =���[�J�[ +  ������
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) ) )";
                }
                //ADD by Liangsd 2011/08/30 ------------<<<<<<<<<<<<
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    SqlDataReader sdr = command.ExecuteReader();
                    if (sdr.Read())
                    {
                        GoodsDeleteCount = sdr.GetInt32(0);
                    }
                    sdr.Close();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion

        #region �����}�X�^�폜��������
        /// <summary>
        /// �����}�X�^�폜��������
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/07/13</br>
        /// <br>Update Note: 2011/08/30  �A��2 ���X��</br>
        /// <br>            : REDMINE#23820�̑Ή�</br>
        /// <returns></returns>
        private int SearchJoinDelete(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string sqlText = string.Empty;
                sqlText += " SELECT COUNT( * ) " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " JOINPARTSURF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //�폜�敪 = ���[�J�[
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (JOINDESTMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                }

                ////�폜�敪 = ���[�J�[ +������
                //if (deleteConditionWork.DeleteCode == 1)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
                //    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                //    {
                //        sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                //        sqlText += " AND " + Environment.NewLine;
                //    }
                //    //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                //    if (deleteConditionWork.Code1 != 0)
                //    {
                //        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //        if (deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " ) ) )";
                //}

                ////�폜�敪 =���[�J�[ +  �O���[�v�R�[�h
                //if (deleteConditionWork.DeleteCode == 2)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
                //    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                //    {
                //        sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                //        sqlText += " AND " + Environment.NewLine;
                //    }
                //    //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    sqlText += " GOODSMGROUPRF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    if (deleteConditionWork.Code1 != 0)
                //    {
                //        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //        if (deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " ) ) ) ) )";
                //}
                //ADD by Liangsd 2011/08/30------>>>>>>>>
                //�폜�敪 = ���[�J�[ + �O���[�v�R�[�h
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) ) )";
                }
                 //�폜�敪 =���[�J�[ +  ������
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += ") ) ) ) ) )";
                }
                //ADD by Liangsd 2011/08/30------<<<<<<<<
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    SqlDataReader sdr = command.ExecuteReader();
                    if (sdr.Read())
                    {
                        JoinDeleteCount = sdr.GetInt32(0);
                    }
                    sdr.Close();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion

        //ADD by Liangsd 2011/08/30------>>>>>>>>
        #region ���i�}�X�^�폜
        /// <summary>
        /// ���i�}�X�^�폜
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/08/30</br>
        /// <returns></returns>
        private int DeleteGoodsUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                # region �����ɂ��A���i�}�X�^�i���[�U�[�o�^���j���폜����;
                string sqlText = string.Empty;
                sqlText += " DELETE " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " GOODSURF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //�폜�敪 = ���[�J�[
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                    // �݌ɕi�戵���F�A�C�݌ɕi���A���i�^�݌ɂǂ�����폜���Ȃ���
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    {

                        sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += " ) )";
                    }
                }
                //�폜�敪 = ���[�J�[+�O���[�v�R�[�h
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) )";
                    // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    {
                        sqlText += "  AND  GOODSNORF  NOT IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND (" + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += ") ) ) ) )";
                    }
                }
                //�폜�敪 =���[�J�[ +  ������
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) ) )";

                    // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    {
                        sqlText += "  AND  ( GOODSNORF  NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += " ) ) ) ) ) ) )";
                    }
                }
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    deleteConditionWork.GoodsDeleteCnt = command.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                # endregion
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion

        #region ���i�}�X�^�폜
        /// <summary>
        /// ���i�}�X�^�폜
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/08/30</br>
        /// <returns></returns>
        private int DeleteGoodsPriceUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                # region �����ɂ��A���i�}�X�^�i���[�U�[�o�^���j���폜����;
                string sqlText = string.Empty;
                sqlText += " DELETE " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " GOODSPRICEURF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //�폜�敪 = ���[�J�[
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                    // �݌ɕi�戵���F�A�C�݌ɕi���A���i�^�݌ɂǂ�����폜���Ȃ���
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    {

                        sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += " ) )";
                    }
                }
                //�폜�敪 = ���[�J�[+�O���[�v�R�[�h
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) )";
                    // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    {
                        sqlText += "  AND  GOODSNORF  NOT IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND (" + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += ") ) ) ) )";
                    }
                }
                //�폜�敪 =���[�J�[ +  ������
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += ") ) ) ) )";

                    // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    {
                        sqlText += "  AND  ( GOODSNORF  NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += " ) ) ) ) ) ) )";
                    }
                }
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    int i = command.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                # endregion
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion

        #region �|���}�X�^�폜
        /// <summary>
        /// �|���}�X�^�폜
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/08/30</br>
        /// <br>Update Note : 2015/06/08 ���t</br>
        /// <br>�Ǘ��ԍ�    : 11100068-00 </br>
        /// <br>            : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>     
        /// <returns></returns>
        private int DeleteRateUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                # region �����ɂ��A���i�}�X�^�i���[�U�[�o�^���j���폜����;
                string sqlText = string.Empty;
                sqlText += " DELETE " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " RATERF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� --->>>>>
                //sqlText += " AND " + Environment.NewLine;
                //sqlText += " SECTIONCODERF= '00'";
                // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---<<<<<
                //�폜�敪 = ���[�J�[
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                    /*----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                    // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    //----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                    // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� --->>>>>
                    //if (deleteConditionWork.RateDeleteCode == 2) // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    //{

                    //    sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
                    //    sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND " + Environment.NewLine;
                    //    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    //    if (deleteConditionWork.Code2 != 0)
                    //    {
                    //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    //    }
                    //    if (deleteConditionWork.Code3 != 0)
                    //    {
                    //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    //    }
                    //    if (deleteConditionWork.Code4 != 0)
                    //    {
                    //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    //    }
                    //    sqlText += " ) )";
                    //}
                    // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---<<<<<
                }
                //�폜�敪 = ���[�J�[+�O���[�v�R�[�h
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine; // ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    //sqlText += " ) ) ) )";// DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    // --- ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                    sqlText += " ) ) ) )" + Environment.NewLine;
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) " + Environment.NewLine;
                    // ���f�����F BL�R�[�h
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) )  " + Environment.NewLine;
                    sqlText += " ) " + Environment.NewLine;

                    sqlText += " ) ";
                    // --- ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<
                    /*----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                    // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    //----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                    // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� --->>>>>
                    //if (deleteConditionWork.RateDeleteCode == 2) // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    //{
                    //    sqlText += "  AND  GOODSNORF  NOT IN ( " + Environment.NewLine;
                    //    sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND " + Environment.NewLine;
                    //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    //    sqlText += " AND  " + Environment.NewLine;
                    //    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    //    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND " + Environment.NewLine;
                    //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    //    sqlText += " AND ( " + Environment.NewLine;
                    //    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    //    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND (" + Environment.NewLine;
                    //    if (deleteConditionWork.Code1 != 0)
                    //    {
                    //        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                    //        {
                    //            sqlText += " OR  " + Environment.NewLine;
                    //        }
                    //    }
                    //    if (deleteConditionWork.Code2 != 0)
                    //    {
                    //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                    //        {
                    //            sqlText += " OR  " + Environment.NewLine;
                    //        }
                    //    }
                    //    if (deleteConditionWork.Code3 != 0)
                    //    {
                    //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    //        if (deleteConditionWork.Code4 != 0)
                    //        {
                    //            sqlText += " OR  " + Environment.NewLine;
                    //        }
                    //    }
                    //    if (deleteConditionWork.Code4 != 0)
                    //    {
                    //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    //    }
                    //    sqlText += ") ) ) ) )";
                    //}
                    // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---<<<<<
                }
                //�폜�敪 =���[�J�[ +  ������
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine; // ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    //sqlText += " ) ) ) ) ) ) )"; // DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    // --- ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                    sqlText += " ) ) ) ) ) ) )" + Environment.NewLine;
                    // ���f�����F �O���[�v�R�[�h
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) " + Environment.NewLine;
                    sqlText += " ) " + Environment.NewLine;
                    // ���f�����F BL�R�[�h
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) ) " + Environment.NewLine;
                    sqlText += " ) " + Environment.NewLine;

                    sqlText += " ) ";
                    // --- ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<
                    /*----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                    // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    //----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                    // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� --->>>>>
                    //if (deleteConditionWork.RateDeleteCode == 2) // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    //{
                    //    sqlText += "  AND  ( GOODSNORF  NOT IN (" + Environment.NewLine;
                    //    sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND " + Environment.NewLine;
                    //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    //    sqlText += " AND  " + Environment.NewLine;
                    //    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    //    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND " + Environment.NewLine;
                    //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    //    sqlText += " AND  " + Environment.NewLine;
                    //    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    //    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND ( " + Environment.NewLine;
                    //    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    //    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND ( " + Environment.NewLine;
                    //    if (deleteConditionWork.Code1 != 0)
                    //    {
                    //        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                    //        {
                    //            sqlText += " OR  " + Environment.NewLine;
                    //        }
                    //    }
                    //    if (deleteConditionWork.Code2 != 0)
                    //    {
                    //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                    //        {
                    //            sqlText += " OR  " + Environment.NewLine;
                    //        }
                    //    }
                    //    if (deleteConditionWork.Code3 != 0)
                    //    {
                    //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    //        if (deleteConditionWork.Code4 != 0)
                    //        {
                    //            sqlText += " OR  " + Environment.NewLine;
                    //        }
                    //    }
                    //    if (deleteConditionWork.Code4 != 0)
                    //    {
                    //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    //    }
                    //    sqlText += " ) ) ) ) ) ) )";
                    //}
                    // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---<<<<<
                }
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    int i = command.ExecuteNonQuery();
                    deleteConditionWork.RateDeleteCnt = i; // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                # endregion
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion

        #region �݌Ƀ}�X�^�폜
        /// <summary>
        ///    �݌Ƀ}�X�^�폜
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/08/30</br>
        /// <returns></returns>
        private int DeleteStockProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                # region �����ɂ��A�݌Ƀ}�X�^���폜����
                string sqlText = string.Empty;
                sqlText += " DELETE " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " STOCKRF " + Environment.NewLine;
                sqlText += "  WHERE  " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                }
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) )";
                }
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += ") ) ) ) )";
                }
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    deleteConditionWork.StockDeleteCnt = command.ExecuteNonQuery();
                    //----- ADD START ���{ 2015/01/28 ----->>>>>>
                    connection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                    connection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                    //----- ADD END ���{ 2015/01/28 -----<<<<<<	
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                # endregion
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion

        #region �����}�X�^�i���[�U�[�o�^�j�폜
        /// <summary>
        /// �����}�X�^�i���[�U�[�o�^�j�폜
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/08/30</br>
        /// <returns></returns>
        private int DeleteJoinPartsUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                # region �����ɂ��A���i�}�X�^�i���[�U�[�o�^���j���폜����;
                string sqlText = string.Empty;
                sqlText += " DELETE " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " JOINPARTSURF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //�폜�敪 = ���[�J�[
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (JOINDESTMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                    // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
                    if (deleteConditionWork.JoinDeleteCode == 2)
                    {
                        sqlText += "  AND  JOINDESTPARTSNORF  NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += " ) )";
                    }
                }

                //�폜�敪 = ���[�J�[ + �O���[�v�R�[�h
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) ) )";
                    // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
                    if (deleteConditionWork.JoinDeleteCode == 2)
                    {
                        sqlText += "  AND  JOINDESTPARTSNORF  NOT IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND (" + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += ") ) ) ) )";
                    }
                }

                //�폜�敪 =���[�J�[ +  ������
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += ") ) ) ) ) )";

                    // �݌ɕi�戵���F�A�݌ɕi���A�����}�X�^���폜���Ȃ�
                    if (deleteConditionWork.JoinDeleteCode == 2)
                    {
                        sqlText += "  AND  ( JOINDESTPARTSNORF  NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += " ) ) ) ) ) ) )";
                    }
                }
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    deleteConditionWork.JoinDeleteCnt = command.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                # endregion
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion

        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
        #region �|���}�X�^�폜��������
        /// <summary>
        /// �|���}�X�^�폜��������
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <br>Programmer	: ���t</br>
        /// <br>Date		: 2015/06/08</br>
        /// <br>            : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>
        /// <returns></returns>
        private int SearchRateDelete(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string sqlText = string.Empty;
                sqlText += " SELECT COUNT( * ) " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " RATERF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //sqlText += " AND SECTIONCODERF= '00'"; // DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                //�폜�敪 = ���[�J�[
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                }
                //�폜�敪 = ���[�J�[ + �O���[�v�R�[�h
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine; // ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    //sqlText += " ) ) ) )"; // DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    // --- ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                    sqlText += " ) ) ) )" + Environment.NewLine;
                    // ���f�����F�O���[�v�R�[�h
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) " + Environment.NewLine;
                    // ���f�����F BL�R�[�h
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) )  " + Environment.NewLine;
                    sqlText += " ) " + Environment.NewLine;
                    sqlText += " ) ";
                    // --- ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<
                }
                //�폜�敪 =���[�J�[ +  ������
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine; // ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    //sqlText += " ) ) ) ) ) ) )"; // DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    // --- ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                    sqlText += " ) ) ) ) ) ) )" +Environment.NewLine;
                    // ���f�����F �O���[�v�R�[�h
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) " + Environment.NewLine;
                    sqlText += " ) " + Environment.NewLine;
                    // ���f�����F BL�R�[�h
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) ) " + Environment.NewLine;
                    sqlText += " ) " + Environment.NewLine;

                    sqlText += " ) ";
                    // --- ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<
                }
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    SqlDataReader sdr = command.ExecuteReader();
                    if (sdr.Read())
                    {
                        RateDeleteCount = sdr.GetInt32(0);
                    }
                    sdr.Close();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion
        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<

        //ADD by Liangsd 2011/08/30------<<<<<<<<
    }
}
