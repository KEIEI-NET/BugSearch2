//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����������i�ݒ�}�X�^
// �v���O�����T�v   : �����������i�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��Y
// �� �� ��  2015/01/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���I ���
// �� �� ��  2015/03/03  �C�����e : �⍇�����_�R�[�h�i���������C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��Y
// �� �� ��  2015/03/06  �C�����e : �G���[�������Write�����s�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �e�c ���V
// �� �� ��  2015/03/09  �C�����e : RedMine#329 ���Ӑ�ʐݒ肪���閾�ׂ�����ƃG���[������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �e�c ���V
// �� �� ��  2015/03/16  �C�����e : ���Ӑ�ʐݒ�̃f�[�^���d������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���{ �G�I
// �� �� ��  2015.03.24  �C�����e : �i��redmine#3251�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/23  �C�����e : �i��Redmine#3158 �ۑ�Ǘ��\��37
//                                  ���J�敪�`�F�b�N���͂�������Ԃł���Ή��o�^�ł���悤�ɑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/26  �C�����e : �i��Redmine#3247
//                                  PM���i�}�X�^(���[�U�[�o�^)����擾�������[�J�[���i�ɑ΂��ė����ݒ肪���f�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���{ �G�I
// �� �� ��  2015.03.28  �C�����e : �i��redmine#3257�̑Ή�
//----------------------------------------------------------------------------//
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
using Broadleaf.Application.Resources;
using Microsoft.Win32;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����������i�ݒ�}�X�^ �����[�g�I�u�W�F�N�g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����������i�ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���� ��Y</br>
    /// <br>Date       : 2015/01/19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class RecBgnGdsDB : RemoteDB, IRecBgnGdsDB
    {

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : RecBgnGdsDB �R���X�g���N�^</br>
        /// <br>Programmer : ���� ��Y</br>
        /// <br>Date       : 2015/01/19</br>
        /// </remarks>
        public RecBgnGdsDB() : base("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork", "RecBgnGdsRF")
        {
        }

        #endregion

        #region �R�l�N�V������������

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���� ��Y</br>
        /// <br>Date       : 2015/01/19</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            
            // �ڑ�������擾
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_UserDB);
            //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText)) return null;

            // �R�l�N�V�����쐬
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }

        #endregion

        #region �����U�N�V������������

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <returns>SqlTransaction</returns>
        /// <remarks>
        /// <br>Note       : SqlTransaction��������</br>
        /// <br>Programmer : ���� ��Y</br>
        /// <br>Date       : 2015/01/19</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            return retSqlTransaction;
        }

        #endregion  //�g�����U�N�V������������

        //--- ADD  2015/02/23 ���X�� ----->>>>>

        #region IRecBgnGdsDB �����o

        #region Write

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�APM�������i�}�X�^�o�^�A�X�V����
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�o�^�f�[�^</param>
        /// <param name="paraCustobj">RecBgnCustPMWork�o�^�f�[�^</param>
        /// <param name="paraIsolobj">PmIsolPrcWork�o�^�f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�APM�������i�}�X�^��o�^�A�X�V���܂��B</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int Write(ref object paraobj, ref object paraCustobj, ref object paraIsolobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // ���������i�ݒ�}�X�^ �o�^�E�X�V����
                status = WriteProc(ref paraobj, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���������i���Ӑ�ʐݒ�}�X�^ �o�^�E�X�V����
                    status = WriteProcCust(ref paraCustobj, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // PM�������i�}�X�^ �o�^�E�X�V����
                    status = WriteProcIsol(ref paraIsolobj, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.Write");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
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

        #endregion

        #region Read

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^ ��������
        /// </summary>
        /// <param name="retobj">RecBgnPMWork�������ʃ��X�g</param>
        /// <param name="retCustobj">RecBgnCustPMWork�������ʃ��X�g</param>
        /// <param name="paraobj">RecBgnGdsPMWork�����f�[�^</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^���������܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int Read(ref object retobj, ref object retCustobj, object paraobj, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V�����쐬
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // ���������i�ݒ�}�X�^ ��������
                status = ReadProc(out retobj, paraobj, sqlConnection, ref errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���������i���Ӑ�ʐݒ�}�X�^ ��������
                    status = ReadProcCust(out retCustobj, paraobj, sqlConnection, ref errMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.Read");
                retobj = new ArrayList();
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

        #region Search

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�F���������i�_���폜�����j
        /// </summary>
        /// <param name="retobj">RecBgnGdsPMWork�������ʃf�[�^���X�g</param>
        /// <param name="retCustobj">RecBgnCustPMWork�������ʃf�[�^���X�g</param>
        /// <param name="paraobj">RecBgnGdsPMSearchParaWork�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜���[�h(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="count">����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�����������ʃ��X�g��ԋp���܂��B�i�_���폜�����j</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int Search(out object retobj, out object retCustobj, object paraobj, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            retobj = null;
            retCustobj = null;

            count = 0;

            try
            {
                // �R�l�N�V�����쐬
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // ���������i�ݒ�}�X�^ ��������
                status = SearchProc(out retobj, paraobj, logicalMode, ref sqlConnection, out count, ref errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���������i���Ӑ�ʐݒ�}�X�^ ��������
                    status = SearchProcCust(out retCustobj, paraobj, logicalMode, ref sqlConnection, ref errMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.Search");
                retobj = new ArrayList();
                count = 0;
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

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�F���������i�_���폜�����j
        /// </summary>
        /// <param name="retobj">RecBgnGdsPMWork�������ʃf�[�^���X�g</param>
        /// <param name="retCustobj">RecBgnCustPMWork�������ʃf�[�^���X�g</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�����������ʃ��X�g��ԋp���܂��B�i�_���폜�����j</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        public int Search(out object retobj, out object retCustobj, string inqOtherEpCd, ConstantManagement.LogicalMode logicalMode, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            retobj = null;
            retCustobj = null;

            try
            {
                // �R�l�N�V�����쐬
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // ���������i�ݒ�}�X�^ ��������
                status = SearchProc(out retobj, inqOtherEpCd, logicalMode, ref sqlConnection, ref errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���������i���Ӑ�ʐݒ�}�X�^ ��������
                    status = SearchProcCust(out retCustobj, inqOtherEpCd, logicalMode, ref sqlConnection, ref errMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.Search");
                retobj = null;
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        #region Delete

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^ ���S�폜����
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�f�[�^</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V�����쐬
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����쐬
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // ���������i�ݒ�}�X�^ �폜����
                status = DeleteProc(paraobj, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���������i���Ӑ�ʐݒ�}�X�^ �폜�����i���������i�ݒ�}�X�^�̃L�[���g�p�j
                    status = DeleteProcCust(paraobj, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.Delete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
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

        #endregion

        #region DeleteAndWrite

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�APM�������i�}�X�^ ���S�폜�E�o�^�����i���X�g�����j
        /// </summary>
        /// <param name="paraDelObj">RecBgnGdsPMWork�폜�f�[�^���X�g</param>
        /// <param name="paraUpdObj">RecBgnGdsPMWork�o�^�f�[�^���X�g</param>
        /// <param name="paraCustUpdObj">RecBgnCustPMWork�o�^�f�[�^���X�g</param>
        /// <param name="paraIsolUpdObj">PmIsolPrcWork�o�^�f�[�^���X�g</param>
        /// <param name="errorObj">RecBgnGdsPMWork�G���[���X�g</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�APM�������i�}�X�^�����S�폜�A�o�^���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        public int DeleteAndWrite(object paraDelObj, ref object paraUpdObj, ref object paraCustUpdObj, ref object paraIsolUpdObj, out object errorObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            errorObj = null;

            try
            {
                // �R�l�N�V�����쐬
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // �ϊ�
                ArrayList delList = paraDelObj as ArrayList;
                ArrayList updList = paraUpdObj as ArrayList;
                ArrayList updCustList = paraCustUpdObj as ArrayList;
                ArrayList updIsolList = paraIsolUpdObj as ArrayList;

                // ���������i�ݒ�}�X�^�E���������i���Ӑ�ʐݒ�}�X�^���S�폜
                foreach (RecBgnGdsPMWork recBgnGdsPMWork in delList)
                {
                    object paraObj = recBgnGdsPMWork as object;

                    // ���������i�ݒ�}�X�^���S�폜
                    status = this.DeleteProc(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errorObj = null;
                        return status;
                    }

                    // ���������i���Ӑ�ʐݒ�}�X�^���S�폜�i���������i�ݒ�}�X�^�̃L�[���g�p�j
                    status = this.DeleteProcCust(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errorObj = null;
                        return status;
                    }
                }

                // �폜�p���[�J�[�R�[�h���X�g
                List<int> makerList = new List<int>();

                // PM�������i�}�X�^�̍폜�Ώۂ𒊏o
                foreach (PmIsolPrcWork pmIsolPrcWork in updIsolList)
                {
                    // ���݂��Ă��Ȃ��ꍇ
                    if (makerList.Contains(pmIsolPrcWork.MakerCode) == false)
                    {
                        // ���X�g�ɒǉ�
                        makerList.Add(pmIsolPrcWork.MakerCode);

                        // PM�������i�}�X�^���S�폜
                        status = this.DeleteProcIsol(pmIsolPrcWork.MakerCode, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            errorObj = null;
		                    //--- ADD  2015/03/06 ���� ----->>>>>                    
                            return status;
		                    //--- ADD  2015/03/06 ���� -----<<<<<                    
                        }
                    }
                }

                // ���������i�ݒ�}�X�^ �o�^
                foreach (RecBgnGdsPMWork recBgnGdsPMWork in updList)
                {
                    object paraObj = recBgnGdsPMWork as object;
                    if (recBgnGdsPMWork.LogicalDeleteCode == 0)
                    {
                        status = this.ReadDBBeforeSave(ref paraObj, ref sqlConnection, ref sqlTransaction);
                        if (status != 0)
                        {
                            errorObj = paraObj;
                            return status;
                        }
                        status = this.WriteProc(ref paraObj, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        // ���������i�ݒ�}�X�^ �_���폜
                        status = this.LogicalDeleteProc(ref paraObj, 0, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // ���������i���Ӑ�ʐݒ�}�X�^ �_���폜
                            status = this.LogicalDeleteProcCust(ref paraObj, 0, ref sqlConnection, ref sqlTransaction);
                        }
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
	                    //--- ADD  2015/03/06 ���� ----->>>>>                    
                        errorObj = null;
                        return status;
	                    //--- ADD  2015/03/06 ���� -----<<<<<                    
                    }
                }

                // ���������i���Ӑ�ʐݒ�}�X�^ �o�^
                foreach (RecBgnCustPMWork recBgnCustPMWork in updCustList)
                {
                    object paraCustObj = recBgnCustPMWork as object;
                    if (recBgnCustPMWork.LogicalDeleteCode == 0)
                    {
                        status = this.ReadDBBeforeSaveCust(ref paraCustObj, ref sqlConnection, ref sqlTransaction);
                        if (status != 0)
                        {
                            errorObj = null;
                            return status;
                        }
                        status = this.WriteProcCust(ref paraCustObj, ref sqlConnection, ref sqlTransaction);
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
	                    //--- ADD  2015/03/06 ���� ----->>>>>                    
                        errorObj = null;
                        return status;
	                    //--- ADD  2015/03/06 ���� -----<<<<<                    
                    }
                }

                // PM�������i�}�X�^ �o�^
                foreach (PmIsolPrcWork pmIsolPrcWork in updIsolList)
                {
                    object paraIsolObj = pmIsolPrcWork as object;
                    if (pmIsolPrcWork.LogicalDeleteCode == 0)
                    {
                        status = this.ReadDBBeforeSaveIsol(ref paraIsolObj, ref sqlConnection, ref sqlTransaction);
                        if (status != 0)
                        {
                            errorObj = null;
                            return status;
                        }
                        status = this.WriteProcIsol(ref paraIsolObj, ref sqlConnection, ref sqlTransaction);
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
	                    //--- ADD  2015/03/06 ���� ----->>>>>                    
                        errorObj = null;
                        return status;
	                    //--- ADD  2015/03/06 ���� -----<<<<<                    
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.DeleteAndWrite");
                errorObj = null;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
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

        #endregion

        #region DeleteAndRevival

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^���S�폜�E���������i���X�g�����j
        /// </summary>
        /// <param name="paraDelObj">RecBgnGdsPMWork�폜�f�[�^���X�g</param>
        /// <param name="paraUpdObj">RecBgnGdsPMWork�����f�[�^���X�g</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�����S�폜�A�������܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        public int DeleteAndRevival(object paraDelObj, ref object paraUpdObj)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // �ϊ�
                ArrayList delList = paraDelObj as ArrayList;
                ArrayList updList = paraUpdObj as ArrayList;

                // ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^ ���S�폜
                foreach (RecBgnGdsPMWork recBgnGdsPMWork in delList)
                {
                    object paraObj = recBgnGdsPMWork as object;

                    // ���������i�ݒ�}�X�^ ���S�폜
                    status = this.DeleteProc(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                    // ���������i���Ӑ�ʐݒ�}�X�^ ���S�폜�i���������i�ݒ�}�X�^�̃L�[���g�p�j
                    status = this.DeleteProcCust(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                }

                // ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^ ����
                foreach (RecBgnGdsPMWork recBgnGdsPMWork in updList)
                {
                    object paraObj = recBgnGdsPMWork as object;

                    // ���������i�ݒ�}�X�^ ����
                    status = this.LogicalDeleteProc(ref paraObj, 1, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                    // ���������i���Ӑ�ʐݒ�}�X�^ �����i���������i�ݒ�}�X�^�̃L�[���g�p�j
                    status = this.LogicalDeleteProcCust(ref paraObj, 1, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.DeleteAndRevival");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
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

        #endregion

        #region LogicalDelete

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�_���폜����
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�f�[�^</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int LogicalDelete(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // ���������i�ݒ�}�X�^ �_���폜
                status = LogicalDeleteProc(ref paraobj, 0, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���������i���Ӑ�ʐݒ�}�X�^ �_���폜�i���������i�ݒ�}�X�^�̃L�[���g�p�j
                    status = LogicalDeleteProcCust(ref paraobj, 0, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.LogicalDelete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
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

        #endregion

        #region RevivalLogicalDelete

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^ ��������
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // ���������i�ݒ�}�X�^ ��������
                status = RevivalLogicalDeleteProc(ref paraobj, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���������i���Ӑ�ʐݒ�}�X�^ ���������i���������i�ݒ�}�X�^�̃L�[���g�p�j
                    status = RevivalLogicalDeleteProcCust(ref paraobj, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.RevivalLogicalDelete");
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

        #endregion

        #region �o�^�E�X�V����

        /// <summary>
        /// ���������i�ݒ�}�X�^ �o�^�E�X�V�����i�������j
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�o�^�f�[�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int WriteProc(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                string commandText = string.Empty;

                // �R�}���h�쐬
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    // ���������i�ݒ�}�X�^ Select�R�}���h
                    commandText = MakeRecBgnGdsRFSelectString()
                                + MakeRecBgnGdsRFWhereKeyString();

                    sqlCommand.CommandText = commandText;

                    //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyStaDate);

                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                    // Read
                    SqlDataReader myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // �X�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        if (updateDateTime != recBgnGdsPMWork.UpdateDateTime)
                        {
                            // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (recBgnGdsPMWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            // Close
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                myReader.Close();
                            }
                            return status;
                        }

                        //Update�R�}���h�̐���
                        commandText = "UPDATE RECBGNGDSRF" + Environment.NewLine
                                    + "SET" + Environment.NewLine
                                    + " CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine
                                    + " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine
                                    + " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine
                                    + " , INQOTHEREPCDRF=@INQOTHEREPCD" + Environment.NewLine
                                    + " , INQOTHERSECCDRF=@INQOTHERSECCD" + Environment.NewLine
                                    + " , GOODSNORF=@GOODSNO" + Environment.NewLine
                                    + " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine
                                    + " , GOODSMAKERNMRF=@GOODSMAKERNM" + Environment.NewLine
                                    + " , GOODSNAMERF=@GOODSNAME" + Environment.NewLine
                                    + " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine
                                    + " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine
                                    + " , GOODSCOMMENTRF=@GOODSCOMMENT" + Environment.NewLine
                                    + " , MKRSUGGESTRTPRICRF=@MKRSUGGESTRTPRIC" + Environment.NewLine
                                    + " , LISTPRICERF=@LISTPRICE" + Environment.NewLine
                                    + " , UNITCALCRATERF=@UNITCALCRATE" + Environment.NewLine
                                    + " , UNITPRICERF=@UNITPRICE" + Environment.NewLine
                                    + " , APPLYSTADATERF=@APPLYSTADATE" + Environment.NewLine
                                    + " , APPLYENDDATERF=@APPLYENDDATE" + Environment.NewLine
                                    + " , MODELFITDIVRF=@MODELFITDIV" + Environment.NewLine
                                    + " , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE" + Environment.NewLine
                                    + " , DISPLAYDIVCODERF=@DISPLAYDIVCODE" + Environment.NewLine
                                    + " , BRGNGOODSGRPCODERF=@BRGNGOODSGRPCODE" + Environment.NewLine
                                    + " , GOODSIMAGERF=@GOODSIMAGE" + Environment.NewLine
                                    + " WHERE " + Environment.NewLine
                                    + " INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                    + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                    + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                    + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                    + " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;

                        //�o�^�w�b�_����ݒ�
                        recBgnGdsPMWork.UpdateDateTime = DateTime.Now;
                    }
                    else
                    {
                        //�@�X�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (recBgnGdsPMWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                myReader.Close();
                            }
                            return status;
                        }

                        //Insert�R�}���h�̐���
                        commandText = "INSERT INTO RECBGNGDSRF (" + Environment.NewLine
                                    + " CREATEDATETIMERF" + Environment.NewLine
                                    + ", UPDATEDATETIMERF" + Environment.NewLine
                                    + ", LOGICALDELETECODERF" + Environment.NewLine
//                                    + ", INQORIGINALEPCDRF" + Environment.NewLine
//                                    + ", INQORIGINALSECCDRF" + Environment.NewLine
                                    + ", INQOTHEREPCDRF" + Environment.NewLine
                                    + ", INQOTHERSECCDRF" + Environment.NewLine
                                    + ", GOODSNORF" + Environment.NewLine
                                    + ", GOODSMAKERCDRF" + Environment.NewLine
                                    + ", GOODSMAKERNMRF" + Environment.NewLine
                                    + ", GOODSNAMERF" + Environment.NewLine
                                    + ", BLGROUPCODERF" + Environment.NewLine
                                    + ", BLGOODSCODERF" + Environment.NewLine
                                    + ", GOODSCOMMENTRF" + Environment.NewLine
                                    + ", MKRSUGGESTRTPRICRF" + Environment.NewLine
                                    + ", LISTPRICERF" + Environment.NewLine
                                    + ", UNITCALCRATERF" + Environment.NewLine
                                    + ", UNITPRICERF" + Environment.NewLine
                                    + ", APPLYSTADATERF" + Environment.NewLine
                                    + ", APPLYENDDATERF" + Environment.NewLine
                                    + ", MODELFITDIVRF" + Environment.NewLine
                                    + ", CUSTRATEGRPCODERF" + Environment.NewLine
                                    + ", DISPLAYDIVCODERF" + Environment.NewLine
                                    + ", BRGNGOODSGRPCODERF" + Environment.NewLine
                                    + ", GOODSIMAGERF" + Environment.NewLine
                                    + ") VALUES (" + Environment.NewLine
                                    + "  @CREATEDATETIME" + Environment.NewLine
                                    + ", @UPDATEDATETIME" + Environment.NewLine
                                    + ", @LOGICALDELETECODE" + Environment.NewLine
//                                    + ", '' " + Environment.NewLine
//                                    + ", '' " + Environment.NewLine
                                    + ", @INQOTHEREPCD" + Environment.NewLine
                                    + ", @INQOTHERSECCD" + Environment.NewLine
                                    + ", @GOODSNO" + Environment.NewLine
                                    + ", @GOODSMAKERCD" + Environment.NewLine
                                    + ", @GOODSMAKERNM" + Environment.NewLine
                                    + ", @GOODSNAME" + Environment.NewLine
                                    + ", @BLGROUPCODE" + Environment.NewLine
                                    + ", @BLGOODSCODE" + Environment.NewLine
                                    + ", @GOODSCOMMENT" + Environment.NewLine
                                    + ", @MKRSUGGESTRTPRIC" + Environment.NewLine
                                    + ", @LISTPRICE" + Environment.NewLine
                                    + ", @UNITCALCRATE" + Environment.NewLine
                                    + ", @UNITPRICE" + Environment.NewLine
                                    + ", @APPLYSTADATE" + Environment.NewLine
                                    + ", @APPLYENDDATE" + Environment.NewLine
                                    + ", @MODELFITDIV" + Environment.NewLine
                                    + ", @CUSTRATEGRPCODE" + Environment.NewLine
                                    + ", @DISPLAYDIVCODE" + Environment.NewLine
                                    + ", @BRGNGOODSGRPCODE" + Environment.NewLine
                                    + ", @GOODSIMAGE" + Environment.NewLine
                                    + ")" + Environment.NewLine;

                        //�o�^�w�b�_����ݒ�
                        recBgnGdsPMWork.UpdateDateTime = DateTime.Now;
                        recBgnGdsPMWork.CreateDateTime = DateTime.Now;
                    }

                    // SqlReader Close
                    if (myReader != null)
                    {
                        myReader.Close();
                    }

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraGoodsMakerNm = sqlCommand.Parameters.Add("@GOODSMAKERNM", SqlDbType.NVarChar);
                    SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraGoodsComment = sqlCommand.Parameters.Add("@GOODSCOMMENT", SqlDbType.NVarChar);
                    SqlParameter paraMkrSuggestRtPric = sqlCommand.Parameters.Add("@MKRSUGGESTRTPRIC", SqlDbType.BigInt);
                    SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.BigInt);
                    SqlParameter paraUnitCalcRate = sqlCommand.Parameters.Add("@UNITCALCRATE", SqlDbType.Float);
                    SqlParameter paraUnitPrice = sqlCommand.Parameters.Add("@UNITPRICE", SqlDbType.BigInt);
                    SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                    SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                    SqlParameter paraModelFitDiv = sqlCommand.Parameters.Add("@MODELFITDIV", SqlDbType.SmallInt);
                    SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter paraDisplayDivCode = sqlCommand.Parameters.Add("@DISPLAYDIVCODE", SqlDbType.Int);
                    SqlParameter paraBrgnGoodsGrpCode = sqlCommand.Parameters.Add("@BRGNGOODSGRPCODE", SqlDbType.SmallInt);
                    SqlParameter paraGoodsImage = sqlCommand.Parameters.Add("@GOODSIMAGE", SqlDbType.VarBinary);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsPMWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsPMWork.UpdateDateTime);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.LogicalDeleteCode);
                    paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    paraGoodsMakerNm.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsMakerNm);
                    paraGoodsName.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsName);
                    paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.BLGroupCode);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.BLGoodsCode);
                    paraGoodsComment.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsComment);
                    paraMkrSuggestRtPric.Value = SqlDataMediator.SqlSetInt64(recBgnGdsPMWork.MkrSuggestRtPric);
                    paraListPrice.Value = SqlDataMediator.SqlSetInt64(recBgnGdsPMWork.ListPrice);
                    paraUnitCalcRate.Value = SqlDataMediator.SqlSetDouble(recBgnGdsPMWork.UnitCalcRate);
                    paraUnitPrice.Value = SqlDataMediator.SqlSetInt64(recBgnGdsPMWork.UnitPrice);
                    paraApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyStaDate);
                    paraApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyEndDate);
                    paraModelFitDiv.Value = SqlDataMediator.SqlSetInt16(recBgnGdsPMWork.ModelFitDiv);
                    paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.CustRateGrpCode);
                    paraDisplayDivCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.DisplayDivCode);
                    paraBrgnGoodsGrpCode.Value = SqlDataMediator.SqlSetInt16(recBgnGdsPMWork.BrgnGoodsGrpCode);
                    paraGoodsImage.Value = SqlDataMediator.SqlSetBinary(recBgnGdsPMWork.GoodsImage);

                    // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    if (paraGoodsName.Size == 0) paraGoodsName.Value = string.Empty;
                    if (paraGoodsComment.Size == 0) paraGoodsComment.Value = string.Empty;
                    // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

                    // �o�^�E�X�V���s
                    sqlCommand.CommandText = commandText;
                    sqlCommand.ExecuteNonQuery();

                    paraobj = recBgnGdsPMWork as object;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.WriteProc");
            }

            return status;
        }

        /// <summary>
        /// ���������i���Ӑ�ʐݒ�}�X�^ �o�^�E�X�V�����i�������j
        /// </summary>
        /// <param name="paraCustobj">RecBgnCustPMWork�o�^�f�[�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int WriteProcCust(ref object paraCustobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                RecBgnCustPMWork recBgnCustPMWork = paraCustobj as RecBgnCustPMWork;
                string commandText = string.Empty;

                // �R�}���h�쐬
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    // ���������i���Ӑ�ʐݒ�}�X�^ Select�R�}���h
                    commandText = MakeRecBgnCustRFSelectString()
                                + MakeRecBgnCustRFWhereKeyString();

                    sqlCommand.CommandText = commandText;

                    //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOriginalEpCd);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOriginalSecCd);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOtherSecCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.GoodsNo);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.ApplyStaDate);

                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                    // Read
                    SqlDataReader myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // �X�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        if (updateDateTime != recBgnCustPMWork.UpdateDateTime)
                        {
                            // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (recBgnCustPMWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            // Close
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                myReader.Close();
                            }
                            return status;
                        }

                        //Update�R�}���h�̐���
                        commandText = "UPDATE RECBGNCUSTRF" + Environment.NewLine
                                    + "SET" + Environment.NewLine
                                    + " CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine
                                    + " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine
                                    + " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine
                                    + " , INQORIGINALEPCDRF=@INQORIGINALEPCD" + Environment.NewLine
                                    + " , INQORIGINALSECCDRF=@INQORIGINALSECCD" + Environment.NewLine
                                    + " , INQOTHEREPCDRF=@INQOTHEREPCD" + Environment.NewLine
                                    + " , INQOTHERSECCDRF=@INQOTHERSECCD" + Environment.NewLine
                                    + " , GOODSNORF=@GOODSNO" + Environment.NewLine
                                    + " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine
                                    + " , GOODSAPPLYSTADATERF=@GOODSAPPLYSTADATE" + Environment.NewLine
                                    + " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine
                                    + " , MNGSECTIONCODERF=@MNGSECTIONCODE" + Environment.NewLine
                                    + " , MKRSUGGESTRTPRICRF=@MKRSUGGESTRTPRIC" + Environment.NewLine
                                    + " , LISTPRICERF=@LISTPRICE" + Environment.NewLine
                                    + " , UNITCALCRATERF=@UNITCALCRATE" + Environment.NewLine
                                    + " , UNITPRICERF=@UNITPRICE" + Environment.NewLine
                                    + " , APPLYSTADATERF=@APPLYSTADATE" + Environment.NewLine
                                    + " , APPLYENDDATERF=@APPLYENDDATE" + Environment.NewLine
                                    + " , BRGNGOODSGRPCODERF=@BRGNGOODSGRPCODE" + Environment.NewLine
                                    + " , DISPLAYDIVCODERF=@DISPLAYDIVCODE" + Environment.NewLine
                                    + " WHERE" + Environment.NewLine
                                    + " INQORIGINALEPCDRF=@FINDINQORIGINALEPCD " + Environment.NewLine
                                    + " AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD " + Environment.NewLine
                                    + " AND INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                    + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                    + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                    + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                    + " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;

                        //�o�^�w�b�_����ݒ�
                        recBgnCustPMWork.UpdateDateTime = DateTime.Now;
                    }
                    else
                    {
                        //�@�X�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (recBgnCustPMWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                myReader.Close();
                            }
                            return status;
                        }

                        //Insert�R�}���h�̐���
                        commandText = "INSERT INTO RECBGNCUSTRF (" + Environment.NewLine
                                    + "  CREATEDATETIMERF" + Environment.NewLine
                                    + ", UPDATEDATETIMERF" + Environment.NewLine
                                    + ", LOGICALDELETECODERF" + Environment.NewLine
                                    + ", INQORIGINALEPCDRF" + Environment.NewLine
                                    + ", INQORIGINALSECCDRF" + Environment.NewLine
                                    + ", INQOTHEREPCDRF" + Environment.NewLine
                                    + ", INQOTHERSECCDRF" + Environment.NewLine
                                    + ", GOODSNORF" + Environment.NewLine
                                    + ", GOODSMAKERCDRF" + Environment.NewLine
                                    + ", GOODSAPPLYSTADATERF" + Environment.NewLine
                                    + ", CUSTOMERCODERF" + Environment.NewLine
                                    + ", MNGSECTIONCODERF" + Environment.NewLine
                                    + ", MKRSUGGESTRTPRICRF" + Environment.NewLine
                                    + ", LISTPRICERF" + Environment.NewLine
                                    + ", UNITCALCRATERF" + Environment.NewLine
                                    + ", UNITPRICERF" + Environment.NewLine
                                    + ", APPLYSTADATERF" + Environment.NewLine
                                    + ", APPLYENDDATERF" + Environment.NewLine
                                    + ", BRGNGOODSGRPCODERF" + Environment.NewLine
                                    + ", DISPLAYDIVCODERF" + Environment.NewLine
                                    + ") VALUES (" + Environment.NewLine
                                    + "  @CREATEDATETIME" + Environment.NewLine
                                    + ", @UPDATEDATETIME" + Environment.NewLine
                                    + ", @LOGICALDELETECODE" + Environment.NewLine
                                    + ", @INQORIGINALEPCD" + Environment.NewLine
                                    + ", @INQORIGINALSECCD" + Environment.NewLine
                                    + ", @INQOTHEREPCD" + Environment.NewLine
                                    + ", @INQOTHERSECCD" + Environment.NewLine
                                    + ", @GOODSNO" + Environment.NewLine
                                    + ", @GOODSMAKERCD" + Environment.NewLine
                                    + ", @GOODSAPPLYSTADATE" + Environment.NewLine
                                    + ", @CUSTOMERCODE" + Environment.NewLine
                                    + ", @MNGSECTIONCODE" + Environment.NewLine
                                    + ", @MKRSUGGESTRTPRIC" + Environment.NewLine
                                    + ", @LISTPRICE" + Environment.NewLine
                                    + ", @UNITCALCRATE" + Environment.NewLine
                                    + ", @UNITPRICE" + Environment.NewLine
                                    + ", @APPLYSTADATE" + Environment.NewLine
                                    + ", @APPLYENDDATE" + Environment.NewLine
                                    + ", @BRGNGOODSGRPCODE" + Environment.NewLine
                                    + ", @DISPLAYDIVCODE" + Environment.NewLine
                                    + ")" + Environment.NewLine;

                        //�o�^�w�b�_����ݒ�
                        recBgnCustPMWork.UpdateDateTime = DateTime.Now;
                        recBgnCustPMWork.CreateDateTime = DateTime.Now;
                    }

                    // SqlReader Close
                    if (myReader != null)
                    {
                        myReader.Close();
                    }

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                    SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraGoodsApplyStaDate = sqlCommand.Parameters.Add("@GOODSAPPLYSTADATE", SqlDbType.Int);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraMkrSuggestRtPric = sqlCommand.Parameters.Add("@MKRSUGGESTRTPRIC", SqlDbType.BigInt);
                    SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.BigInt);
                    SqlParameter paraUnitCalcRate = sqlCommand.Parameters.Add("@UNITCALCRATE", SqlDbType.Float);
                    SqlParameter paraUnitPrice = sqlCommand.Parameters.Add("@UNITPRICE", SqlDbType.BigInt);
                    SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                    SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                    SqlParameter paraBrgnGoodsGrpCode = sqlCommand.Parameters.Add("@BRGNGOODSGRPCODE", SqlDbType.SmallInt);
                    SqlParameter paraDisplayDivCode = sqlCommand.Parameters.Add("@DISPLAYDIVCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnCustPMWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnCustPMWork.UpdateDateTime);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.LogicalDeleteCode);
                    paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOriginalEpCd);
                    paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOriginalSecCd);
                    paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOtherEpCd);
                    paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOtherSecCd);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.GoodsNo);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.GoodsMakerCd);
                    paraGoodsApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.GoodsApplyStaDate);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.CustomerCode);
                    paraMngSectionCode.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.MngSectionCode);
                    paraMkrSuggestRtPric.Value = SqlDataMediator.SqlSetInt64(recBgnCustPMWork.MkrSuggestRtPric);
                    paraListPrice.Value = SqlDataMediator.SqlSetInt64(recBgnCustPMWork.ListPrice);
                    paraUnitCalcRate.Value = SqlDataMediator.SqlSetDouble(recBgnCustPMWork.UnitCalcRate);
                    paraUnitPrice.Value = SqlDataMediator.SqlSetInt64(recBgnCustPMWork.UnitPrice);
                    paraApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.ApplyStaDate);
                    paraApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.ApplyEndDate);
                    paraBrgnGoodsGrpCode.Value = SqlDataMediator.SqlSetInt16(recBgnCustPMWork.BrgnGoodsGrpCode);
                    paraDisplayDivCode.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.DisplayDivCode);

                    // �o�^�E�X�V���s
                    sqlCommand.CommandText = commandText;
                    sqlCommand.ExecuteNonQuery();

                    paraCustobj = recBgnCustPMWork as object;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.WriteProcCust");
            }

            return status;
        }

        /// <summary>
        /// PM�������i�}�X�^ �o�^�E�X�V�����i�������j
        /// </summary>
        /// <param name="paraIsolobj">PmIsolPrcWork�o�^�f�[�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int WriteProcIsol(ref object paraIsolobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                PmIsolPrcWork pmIsolPrcWork = paraIsolobj as PmIsolPrcWork;
                string commandText = string.Empty;

                // �R�}���h�쐬
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    //Insert�R�}���h�̐���
                    commandText = " INSERT INTO PMISOLPRCRF ( " + Environment.NewLine
                                + "  CREATEDATETIMERF " + Environment.NewLine
                                + " , UPDATEDATETIMERF " + Environment.NewLine
                                + " , LOGICALDELETECODERF " + Environment.NewLine
                                + " , ENTERPRISECODERF " + Environment.NewLine
                                + " , SECTIONCODERF " + Environment.NewLine
                                + " , MAKERCODERF " + Environment.NewLine
                                + " , UPPERLIMITPRICERF " + Environment.NewLine
                                + " , PMFRACTIONPROCUNITRF " + Environment.NewLine
                                + " , PMFRACTIONPROCCDRF " + Environment.NewLine
                                + " , LISTPRICEUPRATERF " + Environment.NewLine
                                + " ) VALUES ( " + Environment.NewLine
                                + "   @CREATEDATETIME " + Environment.NewLine
                                + " , @UPDATEDATETIME " + Environment.NewLine
                                + " , @LOGICALDELETECODE " + Environment.NewLine
                                + " , @ENTERPRISECODE " + Environment.NewLine
                                + " , @SECTIONCODE " + Environment.NewLine
                                + " , @MAKERCODE " + Environment.NewLine
                                + " , @UPPERLIMITPRICE " + Environment.NewLine
                                + " , @PMFRACTIONPROCUNIT " + Environment.NewLine
                                + " , @PMFRACTIONPROCCD " + Environment.NewLine
                                + " , @LISTPRICEUPRATE " + Environment.NewLine
                                + " ) " + Environment.NewLine;

                    //�o�^�w�b�_����ݒ�
                    pmIsolPrcWork.UpdateDateTime = DateTime.Now;
                    pmIsolPrcWork.CreateDateTime = DateTime.Now;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                    SqlParameter paraUpperLimitPrice = sqlCommand.Parameters.Add("@UPPERLIMITPRICE", SqlDbType.Float);
                    SqlParameter paraPMFractionProcUnit = sqlCommand.Parameters.Add("@PMFRACTIONPROCUNIT", SqlDbType.Float);
                    SqlParameter paraPMFractionProcCd = sqlCommand.Parameters.Add("@PMFRACTIONPROCCD", SqlDbType.Int);
                    SqlParameter paraListPriceUpRate = sqlCommand.Parameters.Add("@LISTPRICEUPRATE", SqlDbType.Float);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmIsolPrcWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmIsolPrcWork.UpdateDateTime);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmIsolPrcWork.LogicalDeleteCode);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmIsolPrcWork.EnterpriseCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(pmIsolPrcWork.SectionCode);
                    paraMakerCode.Value = SqlDataMediator.SqlSetInt32(pmIsolPrcWork.MakerCode);
                    paraUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(pmIsolPrcWork.UpperLimitPrice);
                    paraPMFractionProcUnit.Value = SqlDataMediator.SqlSetDouble(pmIsolPrcWork.PMFractionProcUnit);
                    paraPMFractionProcCd.Value = SqlDataMediator.SqlSetInt32(pmIsolPrcWork.PMFractionProcCd);
                    paraListPriceUpRate.Value = SqlDataMediator.SqlSetDouble(pmIsolPrcWork.ListPriceUpRate);

                    // �o�^���s
                    sqlCommand.CommandText = commandText;
                    sqlCommand.ExecuteNonQuery();

                    paraIsolobj = pmIsolPrcWork as object;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.WriteProcIsol");
            }

            return status;
        }

        #endregion

        #region ��������
        /// <summary>
        /// �w���Ҍ������������B
        /// </summary>
        /// <param name="retobj">RecBgnGdsWork�������ʃf�[�^���X�g</param>
        /// <param name="paraobj">RecBgnGdsSearchParaWork�����p�����[�^</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜</param>
        /// <param name="count">����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���{ �G�I</br>
        /// <br>Date       : 2015/02/25</br>
        /// </remarks>
        public int SearchForBuyer(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            retobj = null;
            count = 0;

            try
            {
                // �R�l�N�V�����쐬
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // ��������
                status = SearchForBuyperProc(out retobj, paraobj, logicalMode, ref sqlConnection, out count, ref errMsg);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.Search");
                retobj = new ArrayList();
                count = 0;
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


        /// <summary>
        /// �w���Ҍ������������B
        /// </summary>
        /// <param name="retobj">RecBgnGdsWork�������ʃ��X�g</param>
        /// <param name="paraobj">RecBgnGdsSearchParaWork�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="count">����</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������i�ݒ�}�X�^�����������ʃ��X�g��ԋp���܂�</br>
        /// <br>Programmer : ���{ �G�I</br>
        /// <br>Date       : 2015/01/19</br>
        /// </remarks>
        public int SearchForBuyperProc(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList al = new ArrayList();
            retobj = null;
            count = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                RecBgnGdsSearchParaWork recBgnGdsSearchParaWork = paraobj as RecBgnGdsSearchParaWork;
                StringBuilder sqlTxt = new StringBuilder(4096);

                sqlCommand = new SqlCommand(string.Empty, sqlConnection);

                #region SQL�\�z
                sqlTxt.AppendLine(" SELECT ");
                sqlTxt.AppendLine(" * ");
                sqlTxt.AppendLine(" FROM ( ");
                sqlTxt.AppendLine("   SELECT ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTORIGINALEPCDRF   AS EPSCCNT_CNECTORIGINALEPCDRF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTORIGINALSECCDRF  AS EPSCCNT_CNECTORIGINALSECCDRF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTOTHEREPCDRF      AS EPSCCNT_CNECTOTHEREPCDRF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTOTHERSECCDRF     AS EPSCCNT_CNECTOTHERSECCDRF, ");
                sqlTxt.AppendLine("   RECGOOD.CREATEDATETIMERF      AS RECGOOD_CREATEDATETIMERF, ");
                sqlTxt.AppendLine("   RECCUST.CREATEDATETIMERF      AS RECCUST_CREATEDATETIMERF, ");
                sqlTxt.AppendLine("   RECGOOD.UPDATEDATETIMERF      AS RECGOOD_UPDATEDATETIMERF, ");
                sqlTxt.AppendLine("   RECCUST.UPDATEDATETIMERF      AS RECCUST_UPDATEDATETIMERF, ");
                sqlTxt.AppendLine("   RECGOOD.LOGICALDELETECODERF   AS RECGOOD_LOGICALDELETECODERF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSMAKERCDRF        AS RECGOOD_GOODSMAKERCDRF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSMAKERNMRF        AS RECGOOD_GOODSMAKERNMRF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSNORF             AS RECGOOD_GOODSNORF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSNAMERF           AS RECGOOD_GOODSNAMERF, ");
                sqlTxt.AppendLine("   RECGOOD.BLGROUPCODERF         AS RECGOOD_BLGROUPCODERF, ");
                sqlTxt.AppendLine("   RECGOOD.BLGOODSCODERF         AS RECGOOD_BLGOODSCODERF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSCOMMENTRF        AS RECGOOD_GOODSCOMMENTRF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.MKRSUGGESTRTPRICRF,RECGOOD.MKRSUGGESTRTPRICRF) AS REC_MKRSUGGESTRTPRICRF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.LISTPRICERF,RECGOOD.LISTPRICERF)               AS REC_LISTPRICERF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.UNITPRICERF,RECGOOD.UNITPRICERF)               AS REC_UNITPRICERF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.APPLYSTADATERF,RECGOOD.APPLYSTADATERF)         AS REC_APPLYSTADATERF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.APPLYENDDATERF,RECGOOD.APPLYENDDATERF)         AS REC_APPLYENDDATERF, ");
                sqlTxt.AppendLine("   RECGOOD.MODELFITDIVRF         AS RECGOOD_MODELFITDIVRF, ");
                sqlTxt.AppendLine("   RECGOOD.CUSTRATEGRPCODERF     AS RECGOOD_CUSTRATEGRPCODERF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.DISPLAYDIVCODERF,RECGOOD.DISPLAYDIVCODERF)     AS REC_DISPLAYDIVCODERF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.BRGNGOODSGRPCODERF,RECGOOD.BRGNGOODSGRPCODERF) AS REC_BRGNGOODSGRPCODERF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSIMAGERF          AS RECGOOD_GOODSIMAGERF, ");
                sqlTxt.AppendLine("   RECCUST.CUSTOMERCODERF        AS RECCUST_CUSTOMERCODERF, ");
                sqlTxt.AppendLine("   RECCUST.MNGSECTIONCODERF      AS RECCUST_MNGSECTIONCODERF, ");

                sqlTxt.AppendLine("   PMISOLP.MAKERCODERF           AS PMISOLP_MAKERCODERF, ");
                sqlTxt.AppendLine("   PMISOLP.UPPERLIMITPRICERF     AS PMISOLP_UPPERLIMITPRICERF, ");
                sqlTxt.AppendLine("   PMISOLP.PMFRACTIONPROCUNITRF  AS PMISOLP_PMFRACTIONPROCUNITRF, ");
                sqlTxt.AppendLine("   PMISOLP.PMFRACTIONPROCCDRF    AS PMISOLP_PMFRACTIONPROCCDRF, ");
                sqlTxt.AppendLine("   PMISOLP.LISTPRICEUPRATERF     AS PMISOLP_LISTPRICEUPRATERF, ");

                sqlTxt.AppendLine("   ROW_NUMBER() OVER ( ");
                sqlTxt.AppendLine("     PARTITION BY EPSCCNT.CNECTORIGINALEPCDRF,EPSCCNT.CNECTORIGINALSECCDRF,EPSCCNT.CNECTOTHEREPCDRF,EPSCCNT.CNECTOTHERSECCDRF,RECGOOD.GOODSMAKERCDRF,RECGOOD.GOODSNORF,RECGOOD.APPLYSTADATERF");//MOD:2015.03.28 ���{ �G�I #3257
                sqlTxt.AppendLine("     ORDER BY     RECGOOD.INQOTHERSECCDRF DESC,PMISOLP.UPPERLIMITPRICERF ASC ");
                sqlTxt.AppendLine("   ) AS ROWNUM ");
                sqlTxt.AppendLine("   FROM RECBGNGDSRF         AS RECGOOD WITH(READUNCOMMITTED) ");
                sqlTxt.AppendLine("   INNER JOIN  SCMEPCNECTRF AS EPCNECT WITH(READUNCOMMITTED)  ");
                sqlTxt.AppendLine("    ON    EPCNECT.LOGICALDELETECODERF = 0  ");
                sqlTxt.AppendLine("      AND EPCNECT.DISCDIVCDRF         = 0  ");
                sqlTxt.AppendLine("      AND EPCNECT.CNECTORIGINALEPCDRF = @FINDINQORIGINALEPCD ");
                sqlTxt.AppendLine("      AND EPCNECT.CNECTOTHEREPCDRF    = RECGOOD.INQOTHEREPCDRF  ");
                sqlTxt.AppendLine("    INNER JOIN SCMEPSCCNTRF  AS EPSCCNT WITH(READUNCOMMITTED)   ");
                sqlTxt.AppendLine("    ON    EPSCCNT.LOGICALDELETECODERF  = 0  ");
                sqlTxt.AppendLine("      AND EPSCCNT.DISCDIVCDRF          = 0  ");
                #region ADD:2015.03.24 ���{ �G�I #3251 ------------------- >>>>>
                sqlTxt.AppendLine("      AND EPSCCNT.PMUPLOADDIVRF       = 1  ");
                sqlTxt.AppendLine("      AND ISNULL(EPSCCNT.PMDBIDRF,'') != ''");
                #endregion
                sqlTxt.AppendLine("      AND EPSCCNT.CNECTORIGINALEPCDRF  = EPCNECT.CNECTORIGINALEPCDRF ");
                sqlTxt.AppendLine("      AND EPSCCNT.CNECTOTHEREPCDRF     = EPCNECT.CNECTOTHEREPCDRF   ");
                sqlTxt.AppendLine("      AND (EPSCCNT.PCCUOECOMMMETHODRF  = 1 OR EPSCCNT.SCMCOMMMETHODRF = 1)  ");
                sqlTxt.AppendLine("      AND (RECGOOD.INQOTHERSECCDRF='00' OR EPSCCNT.CNECTOTHERSECCDRF    = RECGOOD.INQOTHERSECCDRF)  ");

                // �⍇�������_�R�[�h
                if (!string.IsNullOrEmpty(recBgnGdsSearchParaWork.InqOriginalSecCd))
                {
                    sqlTxt.AppendLine("     AND EPSCCNT.CNECTORIGINALSECCDRF = @FINDCNECTORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDCNECTORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOriginalSecCd);
                }
                // �⍇�����ƃR�[�h
                if (!string.IsNullOrEmpty(recBgnGdsSearchParaWork.InqOtherEpCd))
                {
                    sqlTxt.AppendLine("     AND EPSCCNT.CNECTOTHEREPCDRF     = @FINDCNECTOTHEREPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDCNECTOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherEpCd);
                }
                // �⍇���拒�_�R�[�h
                if (!string.IsNullOrEmpty(recBgnGdsSearchParaWork.InqOtherSecCd))
                {
                    sqlTxt.AppendLine("     AND EPSCCNT.CNECTOTHERSECCDRF    = @FINDCNECTOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDCNECTOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherSecCd);
                }
                sqlTxt.AppendLine("   LEFT JOIN RECBGNCUSTRF AS RECCUST WITH(READUNCOMMITTED) ");
                sqlTxt.AppendLine("    ON   RECCUST.INQOTHEREPCDRF      = RECGOOD.INQOTHEREPCDRF ");
                sqlTxt.AppendLine("     AND RECCUST.INQOTHERSECCDRF     = RECGOOD.INQOTHERSECCDRF ");
                sqlTxt.AppendLine("     AND RECCUST.GOODSNORF           = RECGOOD.GOODSNORF ");
                sqlTxt.AppendLine("     AND RECCUST.GOODSMAKERCDRF      = RECGOOD.GOODSMAKERCDRF ");
                sqlTxt.AppendLine("     AND RECCUST.GOODSAPPLYSTADATERF = RECGOOD.APPLYSTADATERF ");
                sqlTxt.AppendLine("     AND RECCUST.INQORIGINALEPCDRF   = @FINDINQORIGINALEPCD ");
                sqlTxt.AppendLine("     AND RECCUST.INQORIGINALSECCDRF  = EPSCCNT.CNECTORIGINALSECCDRF ");
                sqlTxt.AppendLine("   LEFT JOIN PMISOLPRCRF  AS PMISOLP WITH(READUNCOMMITTED)  ");
                sqlTxt.AppendLine("    ON   PMISOLP.ENTERPRISECODERF    = RECGOOD.INQOTHEREPCDRF ");
                sqlTxt.AppendLine("     AND PMISOLP.SECTIONCODERF       = EPSCCNT.CNECTOTHERSECCDRF ");
                sqlTxt.AppendLine("     AND PMISOLP.LOGICALDELETECODERF = 0 ");
                sqlTxt.AppendLine("     AND PMISOLP.MAKERCODERF         = RECGOOD.GOODSMAKERCDRF ");
                sqlTxt.AppendLine("     AND PMISOLP.UPPERLIMITPRICERF  >= RECGOOD.MKRSUGGESTRTPRICRF ");

                sqlTxt.AppendLine("   WHERE RECGOOD.LOGICALDELETECODERF = @LOGICALDELETECODE ");

                //���[�J�[�R�[�h�i�J�n�j
                if (recBgnGdsSearchParaWork.GoodsMakerCdSt != 0)
                {
                    sqlTxt.AppendLine("    AND RECGOOD.GOODSMAKERCDRF>=@GOODSMAKERCDST").Append(Environment.NewLine);
                    SqlParameter paraStGoodsMakerCdST = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                    paraStGoodsMakerCdST.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdSt);
                }
                //���[�J�[�R�[�h�i�I���j
                if (recBgnGdsSearchParaWork.GoodsMakerCdEd != 0)
                {
                    sqlTxt.AppendLine("    AND RECGOOD.GOODSMAKERCDRF<=@GOODSMAKERCDED").Append(Environment.NewLine);
                    SqlParameter paraEdGoodsMakerCdED = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                    paraEdGoodsMakerCdED.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdEd);
                }

                // ���J�J�n���i�J�n�j�`���J�J�n���i�I���j
                if ((recBgnGdsSearchParaWork.ApplyDateSt != 0)
                && (recBgnGdsSearchParaWork.ApplyDateEd != 0))
                {
                    sqlTxt.Append(" AND ((RECGOOD.APPLYSTADATERF<=@APPLYSTADATE AND @APPLYENDDATE<=RECGOOD.APPLYENDDATERF) ").Append(Environment.NewLine);
                    sqlTxt.Append(" OR   (RECGOOD.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RECGOOD.APPLYENDDATERF) ").Append(Environment.NewLine);
                    sqlTxt.Append(" OR   (RECGOOD.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RECGOOD.APPLYSTADATERF) ").Append(Environment.NewLine);
                    sqlTxt.Append(" OR   (RECGOOD.APPLYENDDATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RECGOOD.APPLYENDDATERF)) ").Append(Environment.NewLine);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
                    SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                    findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
                }

                // ���J�J�n���i�J�n�j�`
                if ((recBgnGdsSearchParaWork.ApplyDateSt != 0)
                && (recBgnGdsSearchParaWork.ApplyDateEd == 0))
                {
                    sqlTxt.Append(" AND RECGOOD.APPLYENDDATERF>=@APPLYSTADATE ").Append(Environment.NewLine);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
                }

                // �`���J�J�n���i�I���j
                if ((recBgnGdsSearchParaWork.ApplyDateSt == 0)
                && (recBgnGdsSearchParaWork.ApplyDateEd != 0))
                {
                    sqlTxt.Append(" AND RECGOOD.APPLYSTADATERF<=@APPLYENDDATE ").Append(Environment.NewLine);
                    SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                    findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
                }

                //�i��*
                if (!string.IsNullOrEmpty(recBgnGdsSearchParaWork.GoodsNo))
                {
                    string workGoodsNo = recBgnGdsSearchParaWork.GoodsNo.Trim();
                    if (workGoodsNo.Substring(workGoodsNo.Length - 1, 1) == "*")
                    {
                        sqlTxt.AppendLine("    AND REPLACE(RECGOOD.GOODSNORF,'-','') LIKE REPLACE(@GOODSNO,'-','')").Append(Environment.NewLine);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(workGoodsNo.Substring(0, workGoodsNo.Length - 1) + "%");
                    }
                    else
                    {
                        sqlTxt.AppendLine("    AND REPLACE(RECGOOD.GOODSNORF,'-','') = REPLACE(@GOODSNO,'-','')").Append(Environment.NewLine);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(workGoodsNo);
                    }
                }
                sqlTxt.AppendLine("  ) AS SUB01 ");
                sqlTxt.AppendLine("  WHERE ROWNUM = 1 AND REC_DISPLAYDIVCODERF = 0");
                sqlTxt.AppendLine("  ORDER BY  ");
                sqlTxt.AppendLine("    EPSCCNT_CNECTORIGINALEPCDRF, ");
                sqlTxt.AppendLine("    EPSCCNT_CNECTORIGINALSECCDRF, ");
                sqlTxt.AppendLine("    EPSCCNT_CNECTOTHEREPCDRF, ");
                sqlTxt.AppendLine("    EPSCCNT_CNECTOTHERSECCDRF, ");
                sqlTxt.AppendLine("    RECGOOD_GOODSMAKERCDRF, ");
                sqlTxt.AppendLine("    RECGOOD_BLGOODSCODERF ");
                #endregion

                //�_���폜�敪
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                //�⍇������ƃR�[�h
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOriginalEpCd);

                sqlCommand.CommandText = sqlTxt.ToString();

                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (al.Count == 20000)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        retobj = al;
                        count = 20001;
                        return status;
                    }
                    RecBgnGdsWork recBgnGdsWork = CopyToRecBgnGdsWorkFromBuyerSearchReader(ref myReader);
                    al.Add(recBgnGdsWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                #region �������i�}�X�^�v�Z����
                #endregion
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnItmstDB.Search", status);
                errMsg = ex.ToString();
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
            retobj = al;

            return status;
        }


        /// <summary>
        /// ���������i�ݒ�}�X�^ ���������i�������j
        /// </summary>
        /// <param name="retobj">RecBgnGdsPMWork�������ʃ��X�g</param>
        /// <param name="paraobj">RecBgnGdsSearchParaWork�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="count">����</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�����������ʃ��X�g��ԋp���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchProc(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList al = new ArrayList();
            count = 0;
            retobj = null;
            
            try
            {
                RecBgnGdsSearchParaWork recBgnGdsSearchParaWork = paraobj as RecBgnGdsSearchParaWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // Select�R�}���h
                    sqlTxt.Append(MakeRecBgnGdsRFSelectString());

                    #region Where��
                    sqlTxt.Append(" WHERE").Append(Environment.NewLine);

                    //�_���폜�敪
                    sqlTxt.Append(" RBG.LOGICALDELETECODERF=@LOGICALDELETECODE ").Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                    // �⍇�����ƃR�[�h
                    if (recBgnGdsSearchParaWork.InqOtherEpCd.Trim() != string.Empty)
                    {
                        sqlTxt.Append(" AND RBG.INQOTHEREPCDRF=@INQOTHEREPCD ").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherEpCd);
                    }
 
                    // �⍇���拒�_�R�[�h
                    //--- UPD  2015/03/03 ���I ----->>>>>                    
                    //int inqOtherSecCd = 0;
                    //int.TryParse(recBgnGdsSearchParaWork.InqOtherSecCd, out inqOtherSecCd);
                    //if (inqOtherSecCd != 0)
                    if (recBgnGdsSearchParaWork.InqOtherSecCd.Trim() != string.Empty)
                    //--- UPD  2015/03/03 ���I -----<<<<<                    
                    {
                        sqlTxt.Append(" AND RBG.INQOTHERSECCDRF=@INQOTHERSECCD ").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherSecCd);
                    }

                    // ���[�J�[�R�[�h�i�J�n�j
                    if (recBgnGdsSearchParaWork.GoodsMakerCdSt != 0)
                    {
                        sqlTxt.Append(" AND RBG.GOODSMAKERCDRF>=@GOODSMAKERCDST ").Append(Environment.NewLine);
                        SqlParameter paraStGoodsMakerCdST = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                        paraStGoodsMakerCdST.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdSt);
                    }
                    // ���[�J�[�R�[�h�i�I���j
                    if (recBgnGdsSearchParaWork.GoodsMakerCdEd != 0)
                    {
                        sqlTxt.Append(" AND RBG.GOODSMAKERCDRF<=@GOODSMAKERCDED ").Append(Environment.NewLine);
                        SqlParameter paraEdGoodsMakerCdED = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                        paraEdGoodsMakerCdED.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdEd);
                    }

                    // ���J�J�n���i�J�n�j�`���J�J�n���i�I���j
                    if ((recBgnGdsSearchParaWork.ApplyDateSt != 0)
                    &&  (recBgnGdsSearchParaWork.ApplyDateEd != 0))
                    {
                        sqlTxt.Append(" AND ((RBG.APPLYSTADATERF<=@APPLYSTADATE AND @APPLYENDDATE<=RBG.APPLYENDDATERF) ").Append(Environment.NewLine);
                        sqlTxt.Append(" OR   (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYENDDATERF) ").Append(Environment.NewLine);
                        sqlTxt.Append(" OR   (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYSTADATERF) ").Append(Environment.NewLine); 
                        sqlTxt.Append(" OR   (RBG.APPLYENDDATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYENDDATERF)) ").Append(Environment.NewLine);
                        SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
                        SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
                    }

                    // ���J�J�n���i�J�n�j�`
                    if ((recBgnGdsSearchParaWork.ApplyDateSt != 0)
                    &&  (recBgnGdsSearchParaWork.ApplyDateEd == 0))
                    {
                        // --- UPD 2015/03/23 Y.Wakita ---------->>>>>
                        //sqlTxt.Append(" AND RBG.APPLYENDDATERF>=@APPLYSTADATE ").Append(Environment.NewLine);
                        sqlTxt.Append(" AND (RBG.APPLYENDDATERF>=@APPLYSTADATE ").Append(Environment.NewLine);
                        sqlTxt.Append("  OR (RBG.DISPLAYDIVCODERF=1 AND RBG.APPLYSTADATERF>=@APPLYSTADATE)) ").Append(Environment.NewLine);
                        // --- UPD 2015/03/23 Y.Wakita ----------<<<<<
                        SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
                    }

                    // �`���J�J�n���i�I���j
                    if ((recBgnGdsSearchParaWork.ApplyDateSt == 0)
                    &&  (recBgnGdsSearchParaWork.ApplyDateEd != 0))
                    {
                        sqlTxt.Append(" AND RBG.APPLYSTADATERF<=@APPLYENDDATE ").Append(Environment.NewLine);
                        SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
                    }

                    // �i��*
                    if (recBgnGdsSearchParaWork.GoodsNo.Trim() != string.Empty)
                    {
                        if (recBgnGdsSearchParaWork.GoodsNo.Trim().Substring(recBgnGdsSearchParaWork.GoodsNo.Trim().Length - 1, 1) == "*")
                        {
                            sqlTxt.Append(" AND REPLACE(RBG.GOODSNORF,'-','') LIKE REPLACE(@GOODSNO,'-','') ").Append(Environment.NewLine);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.GoodsNo.Trim().Substring(0, recBgnGdsSearchParaWork.GoodsNo.Trim().Length - 1) + "%");
                        }
                        else
                        {
                            sqlTxt.Append(" AND REPLACE(RBG.GOODSNORF,'-','') = REPLACE(@GOODSNO,'-','') ").Append(Environment.NewLine);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.GoodsNo.Trim());
                        }
                    }

                    #endregion

                    // OrderBy��ǋL
                    #region ORDER BY��
                    sqlTxt.Append(" ORDER BY ").Append(Environment.NewLine);
                    sqlTxt.Append(" RBG.INQOTHEREPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.INQOTHERSECCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.GOODSNORF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.GOODSMAKERCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.APPLYSTADATERF ").Append(Environment.NewLine);
                    #endregion

                    sqlCommand.CommandText = sqlTxt.ToString();

                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (al.Count == 20000)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            retobj = al;
                            count = 20001;
                            return status;
                        }
                        RecBgnGdsPMWork recBgnGdsPMWork = CopyToRecBgnGdsPMWorkFromReader(ref myReader);
                        al.Add(recBgnGdsPMWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();

                } // end using
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.SearchProc", status);
                errMsg = ex.ToString();
            }
            retobj = al;

            return status;
        }

        /// <summary>
        /// ���������i�ݒ�}�X�^ ���������i�������j
        /// </summary>
        /// <param name="retobj">RecBgnGdsPMWork�������ʃ��X�g</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w��⍇�����ƃR�[�h�̊Y���f�[�^���������܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchProc(out object retobj, string inqOtherEpCd, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            retobj = null;
            ArrayList al = new ArrayList();            
            
            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // Select�R�}���h
                    sqlTxt.Append(MakeRecBgnGdsRFSelectString());

                    #region WHERE��
                    sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

                    // �⍇�����ƃR�[�h
                    sqlTxt.Append(" RBG.INQOTHEREPCDRF = @FINDINQOTHEREPCD ").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(inqOtherEpCd);

                    //�_���폜�敪
                    string wkstring = string.Empty;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlTxt.Append(" AND RBG.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlTxt.Append(" AND RBG.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }

                    #endregion

                    // OrderBy��ǋL
                    #region ORDER BY��
                    sqlTxt.Append(" ORDER BY ").Append(Environment.NewLine);
                    sqlTxt.Append(" RBG.INQOTHEREPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.INQOTHERSECCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.GOODSNORF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.GOODSMAKERCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.APPLYSTADATERF ").Append(Environment.NewLine);
                    #endregion

                    sqlCommand.CommandText = sqlTxt.ToString();

                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        RecBgnGdsPMWork work = CopyToRecBgnGdsPMWorkFromReader(ref myReader);
                        al.Add(work);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();

                } // end using
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.SearchProc", status);
                errMsg = ex.ToString();
            }

            retobj = al;

            return status;
        }

        /// <summary>
        /// ���������i���Ӑ�ʐݒ�}�X�^ ���������i�������j
        /// </summary>
        /// <param name="retCustobj">RecBgnCustPMWork�������ʃ��X�g</param>
        /// <param name="paraobj">RecBgnGdsSearchParaWork�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i���Ӑ�ʐݒ�}�X�^�����������ʃ��X�g��ԋp���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchProcCust(out object retCustobj, object paraobj, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList al = new ArrayList();
            retCustobj = null;

            try
            {
                RecBgnGdsSearchParaWork recBgnGdsSearchParaWork = paraobj as RecBgnGdsSearchParaWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // Select�R�}���h
                    sqlTxt.Append(MakeRecBgnCustRFSelectString());

                    // Join����
                    sqlTxt.Append(" INNER JOIN RECBGNGDSRF RBG WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    sqlTxt.Append(" ON RBG.INQOTHEREPCDRF = RBC.INQOTHEREPCDRF ").Append(Environment.NewLine);
                    // --- ADD 2015/03/16 Y.Wakita ---------->>>>>
                    sqlTxt.Append(" AND RBG.INQOTHERSECCDRF = RBC.INQOTHERSECCDRF ").Append(Environment.NewLine);
                    // --- ADD 2015/03/16 Y.Wakita ----------<<<<<
                    sqlTxt.Append(" AND RBG.GOODSNORF = RBC.GOODSNORF ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND RBG.GOODSMAKERCDRF = RBC.GOODSMAKERCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND RBG.APPLYSTADATERF = RBC.GOODSAPPLYSTADATERF ").Append(Environment.NewLine);

                    #region Where��
                    sqlTxt.Append(" WHERE").Append(Environment.NewLine);

                    //�_���폜�敪
                    sqlTxt.Append(" RBG.LOGICALDELETECODERF=@LOGICALDELETECODE ").Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                    // �⍇�����ƃR�[�h
                    if (recBgnGdsSearchParaWork.InqOtherEpCd.Trim() != string.Empty)
                    {
                        sqlTxt.Append(" AND RBG.INQOTHEREPCDRF=@INQOTHEREPCD ").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherEpCd);
                    }

                    // �⍇���拒�_�R�[�h
                    //--- UPD  2015/03/03 ���I ----->>>>>                    
                    //int inqOtherSecCd = 0;
                    //int.TryParse(recBgnGdsSearchParaWork.InqOtherSecCd, out inqOtherSecCd);
                    //if (inqOtherSecCd != 0)
                    if (recBgnGdsSearchParaWork.InqOtherSecCd.Trim() != string.Empty)                    
                    //--- UPD  2015/03/03 ���I -----<<<<<
                    {
                        sqlTxt.Append(" AND RBG.INQOTHERSECCDRF=@INQOTHERSECCD ").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherSecCd);
                    }

                    // ���[�J�[�R�[�h�i�J�n�j
                    if (recBgnGdsSearchParaWork.GoodsMakerCdSt != 0)
                    {
                        sqlTxt.Append(" AND RBG.GOODSMAKERCDRF>=@GOODSMAKERCDST ").Append(Environment.NewLine);
                        SqlParameter paraStGoodsMakerCdST = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                        paraStGoodsMakerCdST.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdSt);
                    }
                    // ���[�J�[�R�[�h�i�I���j
                    if (recBgnGdsSearchParaWork.GoodsMakerCdEd != 0)
                    {
                        sqlTxt.Append(" AND RBG.GOODSMAKERCDRF<=@GOODSMAKERCDED ").Append(Environment.NewLine);
                        SqlParameter paraEdGoodsMakerCdED = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                        paraEdGoodsMakerCdED.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdEd);
                    }

                    // ���J�J�n���i�J�n�j�`���J�J�n���i�I���j
                    if ((recBgnGdsSearchParaWork.ApplyDateSt != 0)
                    && (recBgnGdsSearchParaWork.ApplyDateEd != 0))
                    {
                        sqlTxt.Append(" AND ((RBG.APPLYSTADATERF<=@APPLYSTADATE AND @APPLYENDDATE<=RBG.APPLYENDDATERF) ").Append(Environment.NewLine);
                        sqlTxt.Append(" OR   (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYENDDATERF) ").Append(Environment.NewLine);
                        sqlTxt.Append(" OR   (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYSTADATERF) ").Append(Environment.NewLine);
                        sqlTxt.Append(" OR   (RBG.APPLYENDDATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYENDDATERF)) ").Append(Environment.NewLine);
                        SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
                        SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
                    }

                    // ���J�J�n���i�J�n�j�`
                    if ((recBgnGdsSearchParaWork.ApplyDateSt != 0)
                    && (recBgnGdsSearchParaWork.ApplyDateEd == 0))
                    {
                        sqlTxt.Append(" AND RBG.APPLYENDDATERF>=@APPLYSTADATE ").Append(Environment.NewLine);
                        SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
                    }

                    // �`���J�J�n���i�I���j
                    if ((recBgnGdsSearchParaWork.ApplyDateSt == 0)
                    && (recBgnGdsSearchParaWork.ApplyDateEd != 0))
                    {
                        sqlTxt.Append(" AND RBG.APPLYSTADATERF<=@APPLYENDDATE ").Append(Environment.NewLine);
                        SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
                    }

                    // �i��*
                    if (recBgnGdsSearchParaWork.GoodsNo.Trim() != string.Empty)
                    {
                        if (recBgnGdsSearchParaWork.GoodsNo.Trim().Substring(recBgnGdsSearchParaWork.GoodsNo.Trim().Length - 1, 1) == "*")
                        {
                            sqlTxt.Append(" AND REPLACE(RBG.GOODSNORF,'-','') LIKE REPLACE(@GOODSNO,'-','') ").Append(Environment.NewLine);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.GoodsNo.Trim().Substring(0, recBgnGdsSearchParaWork.GoodsNo.Trim().Length - 1) + "%");
                        }
                        else
                        {
                            sqlTxt.Append(" AND REPLACE(RBG.GOODSNORF,'-','') = REPLACE(@GOODSNO,'-','') ").Append(Environment.NewLine);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.GoodsNo.Trim());
                        }
                    }

                    #endregion

                    // OrderBy��ǋL
                    #region ORDER BY��
                    sqlTxt.Append(" ORDER BY ").Append(Environment.NewLine);
                    sqlTxt.Append(" RBC.INQOTHEREPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.INQOTHERSECCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.GOODSNORF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.GOODSMAKERCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.GOODSAPPLYSTADATERF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.INQORIGINALEPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.INQORIGINALSECCDRF ").Append(Environment.NewLine);
                    #endregion

                    sqlCommand.CommandText = sqlTxt.ToString();

                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (al.Count == 20000)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            retCustobj = al;
                            return status;
                        }
                        RecBgnCustPMWork recBgnCustPMWork = CopyToRecBgnCustPMWorkFromReader(ref myReader);
                        al.Add(recBgnCustPMWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();

                } // end using
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.SearchProcCust", status);
                errMsg = ex.ToString();
            }
            retCustobj = al;

            return status;

        }

        /// <summary>
        /// ���������i���Ӑ�ʐݒ�}�X�^ ���������i�������j
        /// </summary>
        /// <param name="retCustobj">RecBgnCustPMWork�������ʃ��X�g</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i���Ӑ�ʐݒ�}�X�^�����������ʃ��X�g��ԋp���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchProcCust(out object retCustobj, string inqOtherEpCd, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            retCustobj = null;
            ArrayList al = new ArrayList();

            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // Select�R�}���h
                    sqlTxt.Append(MakeRecBgnCustRFSelectString());

                    // Join����
                    sqlTxt.Append(" INNER JOIN RECBGNGDSRF RBG WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    sqlTxt.Append(" ON RBG.INQOTHEREPCDRF = RBC.INQOTHEREPCDRF ").Append(Environment.NewLine);
                    // --- ADD 2015/03/16 Y.Wakita ---------->>>>>
                    sqlTxt.Append(" AND RBG.INQOTHERSECCDRF = RBC.INQOTHERSECCDRF ").Append(Environment.NewLine);
                    // --- ADD 2015/03/16 Y.Wakita ----------<<<<<
                    sqlTxt.Append(" AND RBG.GOODSNORF = RBC.GOODSNORF ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND RBG.GOODSMAKERCDRF = RBC.GOODSMAKERCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND RBG.APPLYSTADATERF = RBC.GOODSAPPLYSTADATERF ").Append(Environment.NewLine);

                    #region WHERE��
                    sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

                    // �⍇�����ƃR�[�h
                    sqlTxt.Append(" RBG.INQOTHEREPCDRF = @FINDINQOTHEREPCD ").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(inqOtherEpCd);

                    //�_���폜�敪
                    string wkstring = string.Empty;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlTxt.Append(" AND RBG.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlTxt.Append(" AND RBG.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }

                    #endregion

                    // OrderBy��ǋL
                    #region ORDER BY��
                    sqlTxt.Append(" ORDER BY ").Append(Environment.NewLine);
                    sqlTxt.Append(" RBC.INQOTHEREPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.INQOTHERSECCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.GOODSNORF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.GOODSMAKERCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.GOODSAPPLYSTADATERF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.INQORIGINALEPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.INQORIGINALSECCDRF ").Append(Environment.NewLine);
                    #endregion

                    sqlCommand.CommandText = sqlTxt.ToString();

                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (al.Count == 20000)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            retCustobj = al;
                            return status;
                        }
                        RecBgnCustPMWork recBgnCustPMWork = CopyToRecBgnCustPMWorkFromReader(ref myReader);
                        al.Add(recBgnCustPMWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();

                } // end using
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.SearchProcCust", status);
                errMsg = ex.ToString();
            }

            retCustobj = al;

            return status;
        }

        #endregion 

        #region �Ǎ�����

        /// <summary>
        /// ���������i�ݒ�}�X�^ �Ǎ������i�������j
        /// </summary>
        /// <param name="retobj">RecBgnPMWork�������ʃ��X�g</param>
        /// <param name="paraobj">RecBgnGdsPMWork�����p�����[�^</param>
        /// <param name="sqlConnection">SqlConnenction</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�����������ʃ��X�g��ԋp���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int ReadProc(out object retobj, object paraobj, SqlConnection sqlConnection, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            retobj = null;
            ArrayList al = new ArrayList(); 

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                StringBuilder whereTxt = new StringBuilder(string.Empty);

                using(SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(),sqlConnection))
                {

                    // Select�R�}���h
                    sqlTxt.Append(MakeRecBgnGdsRFSelectString());

                    #region WHERE��

                    // �⍇�����ƃR�[�h
                    if (recBgnGdsPMWork.InqOtherEpCd.Trim() != string.Empty)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBG.INQOTHEREPCDRF=@INQOTHEREPCDRF").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCDRF", SqlDbType.NChar);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    }

                    // �⍇���拒�_�R�[�h
                    if (recBgnGdsPMWork.InqOtherSecCd.Trim() != string.Empty)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBG.INQOTHERSECCDRF=@INQOTHERSECCDRF").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCDRF", SqlDbType.NChar);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    }

                    // ���i���[�J�[�R�[�h
                    if (recBgnGdsPMWork.GoodsMakerCd != 0)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBG.GOODSMAKERCDRF=@GOODSMAKERCDRF").Append(Environment.NewLine);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCDRF", SqlDbType.Int);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    }

                    // ���i�ԍ�
                    if (recBgnGdsPMWork.GoodsNo.Trim() != string.Empty)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBG.GOODSNORF=@GOODSNORF").Append(Environment.NewLine);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNORF", SqlDbType.NVarChar);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    }

                    if (whereTxt.ToString().Trim() != string.Empty)
                    {
                        sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                        sqlTxt.Append(whereTxt.ToString()).Append(Environment.NewLine);
                    }

                    #endregion

                    // �R�}���h�ݒ�
                    sqlCommand.CommandText = sqlTxt.ToString();
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    // Reader �� Work
                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        RecBgnGdsPMWork work = this.CopyToRecBgnGdsPMWorkFromReader(ref myReader);
                        al.Add(work);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.ReadProc", status);
                errMsg = ex.ToString();
            }
            finally
            {
                // �������ʃ��X�g���i�[
                retobj = al;
            }

            return status;

        }

        /// <summary>
        /// ���������i���Ӑ�ʐݒ�}�X�^ �Ǎ������i�������j
        /// </summary>
        /// <param name="retCustobj">RecBgnCustPMWork�������ʃ��X�g</param>
        /// <param name="paraList">�������ʃ��X�g</param>
        /// <param name="sqlConnection">SqlConnenction</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i���Ӑ�ʐݒ�}�X�^�����������ʃ��X�g��ԋp���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int ReadProcCust(out object retCustobj, object paraobj, SqlConnection sqlConnection, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            retCustobj = null;
            ArrayList al = new ArrayList();

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                StringBuilder whereTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // Select�R�}���h
                    sqlTxt.Append(MakeRecBgnCustRFSelectString());

                    #region WHERE��

                    // �⍇�����ƃR�[�h
                    if (recBgnGdsPMWork.InqOtherEpCd.Trim() != string.Empty)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBC.INQOTHEREPCDRF=@INQOTHEREPCDRF").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCDRF", SqlDbType.NChar);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    }

                    // �⍇���拒�_�R�[�h
                    if (recBgnGdsPMWork.InqOtherSecCd.Trim() != string.Empty)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBC.INQOTHERSECCDRF=@INQOTHERSECCDRF").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCDRF", SqlDbType.NChar);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    }

                    // ���i���[�J�[�R�[�h
                    if (recBgnGdsPMWork.GoodsMakerCd != 0)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBC.GOODSMAKERCDRF=@GOODSMAKERCDRF").Append(Environment.NewLine);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCDRF", SqlDbType.Int);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    }

                    // ���i�ԍ�
                    if (recBgnGdsPMWork.GoodsNo.Trim() != string.Empty)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBC.GOODSNORF=@GOODSNORF").Append(Environment.NewLine);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNORF", SqlDbType.NVarChar);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    }

                    if (whereTxt.ToString().Trim() != string.Empty)
                    {
                        sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                        sqlTxt.Append(whereTxt.ToString()).Append(Environment.NewLine);
                    }

                    #endregion

                    // �R�}���h�ݒ�
                    sqlCommand.CommandText = sqlTxt.ToString();
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    // Reader �� Work
                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        RecBgnGdsPMWork work = this.CopyToRecBgnGdsPMWorkFromReader(ref myReader);
                        al.Add(work);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.ReadProcCust", status);
                errMsg = ex.ToString();
            }
            finally
            {
                // �������ʃ��X�g���i�[
                retCustobj = al;
            }

            return status;

        }

        #endregion

        #region ���S�폜����

        /// <summary>
        /// ���������i�ݒ�}�X�^ ���S�폜�����i�������j
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int DeleteProc(object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                string commandText = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    // ���������i�ݒ�}�X�^ Select�R�}���h
                    commandText = MakeRecBgnGdsRFSelectString()
                                + MakeRecBgnGdsRFWhereKeyString();

                    sqlCommand.CommandText = commandText;

                    //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyStaDate);

                    // Read
                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // �X�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        if (updateDateTime != recBgnGdsPMWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                myReader.Close();
                            }
                            return status;
                        }

                        // SqlReader Close
                        if (myReader != null)
                        {
                            myReader.Close();
                        }

                        // Delete�R�}���h�̐���
                        commandText = " DELETE FROM RECBGNGDSRF " + Environment.NewLine
                                    + " WHERE " + Environment.NewLine
                                    + " INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                    + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                    + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                    + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                    + " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;

                        sqlCommand.CommandText = commandText;

                        // Delete���s
                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    }
                    else
                    {
                        // �X�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (myReader != null)
                        {
                            myReader.Close();
                        }
                    }

                } // end using

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.DeleteProc");
            }

            return status;
        }

        /// <summary>
        /// ���������i���Ӑ�ʐݒ�}�X�^ ���S�폜�����i�������j
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�̃L�[����肨�������i���Ӑ�ʐݒ�}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int DeleteProcCust(object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                string commandText = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    // Delete�R�}���h�̐���
                    commandText = " DELETE FROM RECBGNCUSTRF " + Environment.NewLine
                                + " WHERE" + Environment.NewLine
                                + " INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                // --- UPD 2015/03/09 Y.Wakita Redmine#329 ---------->>>>>
                                //+ " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;
                                + " AND GOODSAPPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;
                                // --- UPD 2015/03/09 Y.Wakita Redmine#329 ----------<<<<<

                    sqlCommand.CommandText = commandText;

                    //Parameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyStaDate);

                    // Delete���s
                    sqlCommand.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                } // end using

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.DeleteProcCust");
            }

            return status;
        }

        /// <summary>
        /// PM�������i�}�X�^ ���S�폜�����i�������j
        /// </summary>
        /// <param name="makercode">���[�J�[�R�[�h</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : PM�������i�}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int DeleteProcIsol(int makercode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                string commandText = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    // Delete�R�}���h�̐���
                    commandText = " DELETE FROM PMISOLPRCRF " + Environment.NewLine
                                + " WHERE " + Environment.NewLine
                                + " MAKERCODERF=@MAKERCODE " + Environment.NewLine;

                    sqlCommand.CommandText = commandText;

                    //Parameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaMakerCode.Value = SqlDataMediator.SqlSetInt32(makercode);

                    // Delete���s
                    sqlCommand.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    
                } // end using

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.DeleteProcIsol");
            }

            return status;
        }
        #endregion
        
        #region �_���폜����

        /// <summary>
        /// ���������i�ݒ�}�X�^ �_���폜�����i�������j
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�f�[�^</param>
        /// <param name="procMode">�������[�h 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int LogicalDeleteProc(ref object paraobj, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                string commandText = string.Empty;

                // �R�}���h�쐬
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    // ���������i�ݒ�}�X�^ Select�R�}���h
                    commandText = MakeRecBgnGdsRFSelectString()
                                + MakeRecBgnGdsRFWhereKeyString();

                    sqlCommand.CommandText = commandText;

                    //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyStaDate);
                    
                    // Read
                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // �X�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        if (updateDateTime != recBgnGdsPMWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                myReader.Close();
                            }
                            return status;
                        }

                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        // �_���폜�敪�ύX
                        if (procMode == 0)
                        {
                            //�_���폜���[�h�̏ꍇ
                            if (logicalDelCd == 0) recBgnGdsPMWork.LogicalDeleteCode = 1; //�_���폜�t���O���Z�b�g
                            else recBgnGdsPMWork.LogicalDeleteCode = 3; //���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            //�������[�h�̏ꍇ
                            if (logicalDelCd == 1) recBgnGdsPMWork.LogicalDeleteCode = 0; //�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; // ���S�폜�̓f�[�^�Ȃ���߂�

                                sqlCommand.Cancel();
                                if (myReader != null)
                                {
                                    myReader.Close();
                                }
                                return status;
                            }
                        }

                        // SqlReader Close
                        if (myReader != null)
                        {
                            myReader.Close();
                        }

                        // Update�R�}���h�̐���
                        commandText = " UPDATE RECBGNGDSRF " + Environment.NewLine
                                    + " SET" + Environment.NewLine
                                    + " UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine
                                    + " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine
                                    + " WHERE " + Environment.NewLine
                                    + " INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                    + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                    + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                    + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                    + " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;

                        sqlCommand.CommandText = commandText;

                        //�o�^�w�b�_����ݒ�
                        recBgnGdsPMWork.UpdateDateTime = DateTime.Now;

                        // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);       // �X�V����
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);    // �_���폜�敪

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsPMWork.UpdateDateTime);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.LogicalDeleteCode);

                        //�^�C���A�E�g���Ԃ̐ݒ�
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                        // Update���s
                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    }
                    else
                    {
                        // �X�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        if (myReader != null)
                        {
                            myReader.Close();
                        }
                        return status;
                    }

                } // end using

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.LogicalDeleteProc");
            }

            return status;

        }

        /// <summary>
        /// ���������i���Ӑ�ʐݒ�}�X�^ �_���폜�����i�������j
        /// </summary>
        /// <param name="paraobj">RecBgnCustPMWork�f�[�^</param>
        /// <param name="procMode">�������[�h 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i���Ӑ�ʐݒ�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int LogicalDeleteProcCust(ref object paraobj, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                string commandText = string.Empty;

                // �R�}���h�쐬
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {

                    // �_���폜�敪�ύX
                    if (procMode == 0)
                    {
                        //�_���폜���[�h�̏ꍇ
                        // Update�R�}���h
                        commandText = " UPDATE RECBGNCUSTRF " + Environment.NewLine
                                    + " SET " + Environment.NewLine
                                    + " UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine
                                    + " , LOGICALDELETECODERF = CASE WHEN LOGICALDELETECODERF = 0 THEN 1 ELSE 3 END " + Environment.NewLine
                                    + " WHERE" + Environment.NewLine
                                    + " INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                    + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                    + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                    + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                    + " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;
                    }
                    else
                    {
                        //�������[�h�̏ꍇ
                        // Update�R�}���h
                        commandText = " UPDATE RECBGNCUSTRF " + Environment.NewLine
                                    + " SET " + Environment.NewLine
                                    + " UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine
                                    + " , LOGICALDELETECODERF = CASE WHEN LOGICALDELETECODERF = 1 THEN 0 ELSE LOGICALDELETECODERF END " + Environment.NewLine
                                    + " WHERE" + Environment.NewLine
                                    + " INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                    + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                    + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                    + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                    + " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;
                    }

                    //Parameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);       // �X�V����
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsPMWork.UpdateDateTime);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyStaDate);

                    sqlCommand.CommandText = commandText;

                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                    // Update���s
                    sqlCommand.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;


                } // end using

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.LogicalDeleteProcCust");
            }

            return status;

        }

        #endregion

        #region ��������

        /// <summary>
        /// ���������i�ݒ�}�X�^ ���������i�������j
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�f�[�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�̘_���폜�f�[�^�𕜊����܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int RevivalLogicalDeleteProc(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // �_���폜���������{
            return LogicalDeleteProc(ref paraobj, 1, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���������i���Ӑ�ʐݒ�}�X�^ ���������i�������j
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�f�[�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i���Ӑ�ʐݒ�}�X�^�̘_���폜�f�[�^�𕜊����܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int RevivalLogicalDeleteProcCust(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // �_���폜���������{
            return LogicalDeleteProcCust(ref paraobj, 1, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���������i�ݒ�}�X�^ �o�^�A�X�V�O�A�d�����R�[�h�̑��݃`�F�b�N���s��
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^ �o�^�A�X�V�O�A�d�����R�[�h�̑��݃`�F�b�N���s��</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int ReadDBBeforeSave(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {

                    // Select�R�}���h
                    sqlTxt.Append(MakeRecBgnGdsRFSelectString());

                    #region WHERE��
                    sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

                    // �⍇�����ƃR�[�h
                    sqlTxt.Append(" RBG.INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);

                    // �⍇���拒�_�R�[�h
                    sqlTxt.Append(" AND RBG.INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);

                    // ���i�ԍ�
                    sqlTxt.Append(" AND RBG.GOODSNORF=@GOODSNO").Append(Environment.NewLine);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);

                    // ���i���[�J�[�R�[�h
                    sqlTxt.Append(" AND RBG.GOODSMAKERCDRF=@GOODSMAKERCD").Append(Environment.NewLine);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);

                    // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    if (recBgnGdsPMWork.DisplayDivCode == 1)
                    {
                        // �K�p��
                        sqlTxt.Append(" AND ((RBG.APPLYSTADATERF<=@APPLYSTADATE AND @APPLYSTADATE<=RBG.APPLYENDDATERF)").Append(Environment.NewLine);
                        sqlTxt.Append("  OR  (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYSTADATE>=RBG.APPLYENDDATERF)").Append(Environment.NewLine);
                        sqlTxt.Append("  OR  (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYSTADATE>=RBG.APPLYSTADATERF)").Append(Environment.NewLine);
                        sqlTxt.Append("  OR  (RBG.APPLYENDDATERF>=@APPLYSTADATE AND @APPLYSTADATE>=RBG.APPLYENDDATERF))").Append(Environment.NewLine);
                    }
                    else
                    {
                        // --- ADD 2015/03/23 Y.Wakita ----------<<<<<
	                    // �K�p��
	                    sqlTxt.Append(" AND ((RBG.APPLYSTADATERF<=@APPLYSTADATE AND @APPLYENDDATE<=RBG.APPLYENDDATERF)").Append(Environment.NewLine);
	                    sqlTxt.Append("  OR  (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYENDDATERF)").Append(Environment.NewLine);
	                    sqlTxt.Append("  OR  (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYSTADATERF)").Append(Environment.NewLine);
	                    sqlTxt.Append("  OR  (RBG.APPLYENDDATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYENDDATERF))").Append(Environment.NewLine);
                        // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    }
                    // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

                    SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                    paraApplyStaDate.Value = SqlDataMediator.SqlSetInt(recBgnGdsPMWork.ApplyStaDate);
                    SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                    paraApplyEndDate.Value = SqlDataMediator.SqlSetInt(recBgnGdsPMWork.ApplyEndDate);

                    #endregion

                    // �R�}���h�ݒ�
                    sqlCommand.CommandText = sqlTxt.ToString();
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                    if (sqlTransaction != null)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        paraobj = recBgnGdsPMWork as object;
                        if (myReader != null)
                        {
                            myReader.Close();
                        }
                        return status;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.ReadDBBeforeSave", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;

        }

        /// <summary>
        /// ���������i���Ӑ�ʐݒ�}�X�^ �o�^�A�X�V�O�A�d�����R�[�h�̑��݃`�F�b�N���s��
        /// </summary>
        /// <param name="paraCustobj">RecBgnCustPMWork�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���������i���Ӑ�ʐݒ�}�X�^ �o�^�A�X�V�O�A�d�����R�[�h�̑��݃`�F�b�N���s��</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int ReadDBBeforeSaveCust(ref object paraCustobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                RecBgnCustPMWork recBgnCustPMWork = paraCustobj as RecBgnCustPMWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {

                    // Select�R�}���h
                    sqlTxt.Append(MakeRecBgnCustRFSelectString());

                    #region WHERE��
                    sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

                    // �⍇������ƃR�[�h
                    sqlTxt.Append(" RBC.INQORIGINALEPCDRF=@INQORIGINALEPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOriginalEpCd);

                    // �⍇�������_�R�[�h
                    sqlTxt.Append("  AND RBC.INQORIGINALSECCDRF=@INQORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOriginalSecCd);

                    // �⍇�����ƃR�[�h
                    sqlTxt.Append("  AND RBC.INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOtherEpCd);

                    // �⍇���拒�_�R�[�h
                    sqlTxt.Append("  AND RBC.INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOtherSecCd);

                    // ���i�ԍ�
                    sqlTxt.Append("  AND RBC.GOODSNORF=@GOODSNO").Append(Environment.NewLine);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.GoodsNo);

                    // ���i���[�J�[�R�[�h
                    sqlTxt.Append("  AND RBC.GOODSMAKERCDRF=@GOODSMAKERCD").Append(Environment.NewLine);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.GoodsMakerCd);

                    // �K�p��
                    sqlTxt.Append(" AND ((RBC.APPLYSTADATERF<=@APPLYSTADATE AND @APPLYENDDATE<=RBC.APPLYENDDATERF)").Append(Environment.NewLine);
                    sqlTxt.Append("  OR  (RBC.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBC.APPLYENDDATERF)").Append(Environment.NewLine);
                    sqlTxt.Append("  OR  (RBC.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBC.APPLYSTADATERF)").Append(Environment.NewLine);
                    sqlTxt.Append("  OR  (RBC.APPLYENDDATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBC.APPLYENDDATERF))").Append(Environment.NewLine);

                    SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                    paraApplyStaDate.Value = SqlDataMediator.SqlSetInt(recBgnCustPMWork.ApplyStaDate);
                    SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                    paraApplyEndDate.Value = SqlDataMediator.SqlSetInt(recBgnCustPMWork.ApplyEndDate);

                    #endregion

                    // �R�}���h�ݒ�
                    sqlCommand.CommandText = sqlTxt.ToString();
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                    if (sqlTransaction != null)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        paraCustobj = recBgnCustPMWork as object;
                        if (myReader != null)
                        {
                            myReader.Close();
                        }
                        return status;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.ReadDBBeforeSaveCust", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;

        }

        /// <summary>
        /// PM�������i�}�X�^ �o�^�O�A�d�����R�[�h�̑��݃`�F�b�N���s��
        /// </summary>
        /// <param name="paraIsolobj">PmIsolPrcWork�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PM�������i�}�X�^ �o�^�O�A�d�����R�[�h�̑��݃`�F�b�N���s��</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int ReadDBBeforeSaveIsol(ref object paraIsolobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                PmIsolPrcWork pmIsolPrcWork = paraIsolobj as PmIsolPrcWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {

                    // Select�R�}���h
                    sqlTxt.Append(MakePmIsolPrcRFSelectString());

                    #region WHERE��

                    sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                    sqlTxt.Append(" PIP.ENTERPRISECODERF=@ENTERPRISECODE ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND PIP.SECTIONCODERF=@SECTIONCODE ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND PIP.MAKERCODERF=@MAKERCODE ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND PIP.UPPERLIMITPRICERF=@UPPERLIMITPRICE ").Append(Environment.NewLine);

                    //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                    SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@UPPERLIMITPRICE", SqlDbType.Float);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmIsolPrcWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(pmIsolPrcWork.SectionCode);
                    findParaMakerCode.Value = SqlDataMediator.SqlSetInt32(pmIsolPrcWork.MakerCode);
                    findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(pmIsolPrcWork.UpperLimitPrice);

                    #endregion

                    // �R�}���h�ݒ�
                    sqlCommand.CommandText = sqlTxt.ToString();
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                    if (sqlTransaction != null)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        paraIsolobj = pmIsolPrcWork as object;
                        if (myReader != null)
                        {
                            myReader.Close();
                        }
                        return status;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.ReadDBBeforeSaveIsol", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;

        }

        #endregion 

        #region �N���X�i�[����

        /// <summary>
        /// ���������i�ݒ�}�X�^ �������ʊi�[�����iReader��RecBgnGdsPMWork�j
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RecBgnGdsPMWork</returns>
        /// <remarks>
        /// <br>Note       : SqlDataReaer�̌��ݍs��RecBgnGdsPMWork�֊i�[���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private RecBgnGdsPMWork CopyToRecBgnGdsPMWorkFromReader(ref SqlDataReader myReader)
        {
            RecBgnGdsPMWork recBgnGdsPMWork = new RecBgnGdsPMWork();

            recBgnGdsPMWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            recBgnGdsPMWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            recBgnGdsPMWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            recBgnGdsPMWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
            recBgnGdsPMWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
            recBgnGdsPMWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            recBgnGdsPMWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            recBgnGdsPMWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMAKERNMRF"));
            recBgnGdsPMWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            recBgnGdsPMWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            recBgnGdsPMWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            recBgnGdsPMWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSCOMMENTRF"));
            recBgnGdsPMWork.MkrSuggestRtPric = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MKRSUGGESTRTPRICRF"));
            recBgnGdsPMWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));
            recBgnGdsPMWork.UnitCalcRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNITCALCRATERF"));
            recBgnGdsPMWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));
            recBgnGdsPMWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
            recBgnGdsPMWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
            recBgnGdsPMWork.ModelFitDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("MODELFITDIVRF"));
            recBgnGdsPMWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            recBgnGdsPMWork.DisplayDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYDIVCODERF"));
            recBgnGdsPMWork.BrgnGoodsGrpCode = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("BRGNGOODSGRPCODERF"));
            recBgnGdsPMWork.GoodsImage = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("GOODSIMAGERF"));

            return recBgnGdsPMWork;
        }

        /// <summary>
        /// ���������i���Ӑ�ʐݒ�}�X�^ �������ʊi�[�����iReader��RecBgnCustPMWork�j
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RecBgnCustPMWork</returns>
        /// <remarks>
        /// <br>Note       : SqlDataReaer�̌��ݍs��RecBgnCustPMWork�֊i�[���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private RecBgnCustPMWork CopyToRecBgnCustPMWorkFromReader(ref SqlDataReader myReader)
        {
            RecBgnCustPMWork recBgnCustPMWork = new RecBgnCustPMWork();

            recBgnCustPMWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            recBgnCustPMWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            recBgnCustPMWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            recBgnCustPMWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
            recBgnCustPMWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
            recBgnCustPMWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
            recBgnCustPMWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
            recBgnCustPMWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            recBgnCustPMWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            recBgnCustPMWork.GoodsApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSAPPLYSTADATERF"));
            recBgnCustPMWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            recBgnCustPMWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
            recBgnCustPMWork.MkrSuggestRtPric = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MKRSUGGESTRTPRICRF"));
            recBgnCustPMWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));
            recBgnCustPMWork.UnitCalcRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNITCALCRATERF"));
            recBgnCustPMWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));
            recBgnCustPMWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
            recBgnCustPMWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
            recBgnCustPMWork.BrgnGoodsGrpCode = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("BRGNGOODSGRPCODERF"));
            recBgnCustPMWork.DisplayDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYDIVCODERF"));

            return recBgnCustPMWork;
        }

        /// <summary>
        /// PM�������i�}�X�^ �������ʊi�[�����iReader��PmIsolPrcWork�j
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PmIsolPrcWork</returns>
        /// <remarks>
        /// <br>Note       : SqlDataReaer�̌��ݍs��PmIsolPrcWork�֊i�[���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private PmIsolPrcWork CopyToPmIsolPrcRFWorkFromReader(ref SqlDataReader myReader)
        {
            PmIsolPrcWork pmIsolPrcWork = new PmIsolPrcWork();

            pmIsolPrcWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            pmIsolPrcWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            pmIsolPrcWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            pmIsolPrcWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            pmIsolPrcWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            pmIsolPrcWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
            pmIsolPrcWork.UpperLimitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPPERLIMITPRICERF"));
            pmIsolPrcWork.PMFractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PMFRACTIONPROCUNITRF"));
            pmIsolPrcWork.PMFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PMFRACTIONPROCCDRF"));
            pmIsolPrcWork.ListPriceUpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEUPRATERF"));

            return pmIsolPrcWork;
        }


        /// <summary>
        /// �������ʊi�[�����iSeaechForBuyer��Reader��RecBgnGdsWork�j
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RecBgnGdsWork</returns>
        /// <remarks>
        /// <br>Note       : SqlDataReaer�̌��ݍs��RecBgnGdsWork�֊i�[���܂�</br>
        /// <br>Programmer : ���{ �G�I</br>
        /// <br>Date       : 2015.02.23</br>
        /// </remarks>
        private RecBgnGdsWork CopyToRecBgnGdsWorkFromBuyerSearchReader(ref SqlDataReader myReader)
        {
            RecBgnGdsWork recBgnGdsWork = new RecBgnGdsWork();
            #region CREATEDATETIMERF
            DateTime ticks1, ticks2;
            ticks1 = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("RECGOOD_CREATEDATETIMERF"));
            ticks2 = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("RECCUST_CREATEDATETIMERF"));
            recBgnGdsWork.CreateDateTime = (ticks1 > ticks2) ? ticks1 : ticks2;
            #endregion

            #region UPDATEDATETIMERF
            ticks1 = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("RECGOOD_UPDATEDATETIMERF"));
            ticks2 = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("RECCUST_UPDATEDATETIMERF"));
            recBgnGdsWork.UpdateDateTime = (ticks1 > ticks2) ? ticks1 : ticks2;
            #endregion

            recBgnGdsWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECGOOD_LOGICALDELETECODERF"));
            recBgnGdsWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EPSCCNT_CNECTORIGINALEPCDRF"));
            recBgnGdsWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EPSCCNT_CNECTORIGINALSECCDRF"));
            recBgnGdsWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EPSCCNT_CNECTOTHEREPCDRF"));
            recBgnGdsWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EPSCCNT_CNECTOTHERSECCDRF"));

            recBgnGdsWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECCUST_CUSTOMERCODERF"));
            recBgnGdsWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECCUST_MNGSECTIONCODERF"));
            recBgnGdsWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECGOOD_GOODSNORF"));
            recBgnGdsWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECGOOD_GOODSMAKERCDRF"));
            recBgnGdsWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECGOOD_GOODSMAKERNMRF"));
            recBgnGdsWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECGOOD_GOODSNAMERF"));
            recBgnGdsWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECGOOD_BLGROUPCODERF"));
            recBgnGdsWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECGOOD_BLGOODSCODERF"));
            recBgnGdsWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECGOOD_GOODSCOMMENTRF"));

            recBgnGdsWork.MkrSuggestRtPric = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REC_MKRSUGGESTRTPRICRF"));
            recBgnGdsWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REC_LISTPRICERF"));
            recBgnGdsWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REC_UNITPRICERF"));
            recBgnGdsWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REC_APPLYSTADATERF"));
            recBgnGdsWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REC_APPLYENDDATERF"));
            recBgnGdsWork.ModelFitDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("RECGOOD_MODELFITDIVRF"));
            recBgnGdsWork.GoodsImage = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("RECGOOD_GOODSIMAGERF"));

            recBgnGdsWork.BrgnGoodsGrpCode = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("REC_BRGNGOODSGRPCODERF"));
            recBgnGdsWork.DisplayDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REC_DISPLAYDIVCODERF"));

            #region �������i�}�X�^�v�Z����
            double upRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PMISOLP_LISTPRICEUPRATERF"));
            double fractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PMISOLP_PMFRACTIONPROCUNITRF"));
            int fractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PMISOLP_PMFRACTIONPROCCDRF")); ;
            double mkrSuggestRtPric = recBgnGdsWork.MkrSuggestRtPric;

            #endregion
            // --- UPD 2015/03/26 Y.Wakita ---------->>>>>
            // �K���Ԏ�敪��1�̏ꍇ�̂ݗ������i��K�p����
            //if (upRate > 0)
            if ((upRate > 0) && (recBgnGdsWork.ModelFitDiv == 1))
            // --- UPD 2015/03/26 Y.Wakita ----------<<<<<
            {
                mkrSuggestRtPric = mkrSuggestRtPric * upRate / 100;
                mkrSuggestRtPric = mkrSuggestRtPric / fractionProcUnit;
                switch (fractionProcCd)
                {
                    case 1://�؎̂�
                        mkrSuggestRtPric = Math.Floor(mkrSuggestRtPric);
                        break;
                    case 2://�l�̌ܓ�
                        mkrSuggestRtPric = Math.Round(mkrSuggestRtPric, MidpointRounding.AwayFromZero);
                        break;
                    case 3://�؂�グ
                        mkrSuggestRtPric = Math.Ceiling(mkrSuggestRtPric);
                        break;
                    default:
                        break;
                }
                mkrSuggestRtPric = mkrSuggestRtPric * fractionProcUnit;
                recBgnGdsWork.MkrSuggestRtPric = (long)mkrSuggestRtPric;
            }
            return recBgnGdsWork;

        }
        #endregion 

        #region �N�G��������

        private string MakeRecBgnGdsRFSelectString()
        {
            string commandText = string.Empty;

            // Select�R�}���h
            commandText = " SELECT " + Environment.NewLine
                        + "  RBG.CREATEDATETIMERF " + Environment.NewLine
                        + ", RBG.UPDATEDATETIMERF " + Environment.NewLine
                        + ", RBG.LOGICALDELETECODERF " + Environment.NewLine
                        + ", RBG.INQOTHEREPCDRF " + Environment.NewLine
                        + ", RBG.INQOTHERSECCDRF " + Environment.NewLine
                        + ", RBG.GOODSNORF " + Environment.NewLine
                        + ", RBG.GOODSMAKERCDRF " + Environment.NewLine
                        + ", RBG.GOODSMAKERNMRF " + Environment.NewLine
                        + ", RBG.GOODSNAMERF " + Environment.NewLine
                        + ", RBG.BLGROUPCODERF " + Environment.NewLine
                        + ", RBG.BLGOODSCODERF " + Environment.NewLine
                        + ", RBG.GOODSCOMMENTRF " + Environment.NewLine
                        + ", RBG.MKRSUGGESTRTPRICRF " + Environment.NewLine
                        + ", RBG.LISTPRICERF " + Environment.NewLine
                        + ", RBG.UNITCALCRATERF " + Environment.NewLine
                        + ", RBG.UNITPRICERF " + Environment.NewLine
                        + ", RBG.APPLYSTADATERF " + Environment.NewLine
                        + ", RBG.APPLYENDDATERF " + Environment.NewLine
                        + ", RBG.MODELFITDIVRF " + Environment.NewLine
                        + ", RBG.CUSTRATEGRPCODERF " + Environment.NewLine
                        + ", RBG.DISPLAYDIVCODERF " + Environment.NewLine
                        + ", RBG.BRGNGOODSGRPCODERF " + Environment.NewLine
                        + ", RBG.GOODSIMAGERF " + Environment.NewLine
                        + "  FROM RECBGNGDSRF RBG WITH (READUNCOMMITTED) " + Environment.NewLine;

            return commandText;
        }

        private string MakeRecBgnGdsRFWhereKeyString()
        {
            string commandText = string.Empty;

            commandText = " WHERE " + Environment.NewLine
                        + " RBG.INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                        + " AND RBG.INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                        + " AND RBG.GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                        + " AND RBG.GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                        + " AND RBG.APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;

            return commandText;
        }

        private string MakeRecBgnCustRFSelectString()
        {
            string commandText = string.Empty;

            // Select�R�}���h
            commandText = " SELECT " + Environment.NewLine
                        + "  RBC.CREATEDATETIMERF " + Environment.NewLine
                        + ", RBC.UPDATEDATETIMERF " + Environment.NewLine
                        + ", RBC.LOGICALDELETECODERF " + Environment.NewLine
                        + ", RBC.INQORIGINALEPCDRF " + Environment.NewLine
                        + ", RBC.INQORIGINALSECCDRF " + Environment.NewLine
                        + ", RBC.INQOTHEREPCDRF " + Environment.NewLine
                        + ", RBC.INQOTHERSECCDRF " + Environment.NewLine
                        + ", RBC.GOODSNORF " + Environment.NewLine
                        + ", RBC.GOODSMAKERCDRF " + Environment.NewLine
                        + ", RBC.GOODSAPPLYSTADATERF " + Environment.NewLine
                        + ", RBC.CUSTOMERCODERF " + Environment.NewLine
                        + ", RBC.MNGSECTIONCODERF " + Environment.NewLine
                        + ", RBC.MKRSUGGESTRTPRICRF " + Environment.NewLine
                        + ", RBC.LISTPRICERF " + Environment.NewLine
                        + ", RBC.UNITCALCRATERF " + Environment.NewLine
                        + ", RBC.UNITPRICERF " + Environment.NewLine
                        + ", RBC.APPLYSTADATERF " + Environment.NewLine
                        + ", RBC.APPLYENDDATERF " + Environment.NewLine
                        + ", RBC.BRGNGOODSGRPCODERF " + Environment.NewLine
                        + ", RBC.DISPLAYDIVCODERF " + Environment.NewLine
                        + "  FROM RECBGNCUSTRF RBC WITH (READUNCOMMITTED) " + Environment.NewLine;


            return commandText;
        }

        private string MakeRecBgnCustRFWhereKeyString()
        {
            string commandText = string.Empty;

            commandText = " WHERE" + Environment.NewLine
                        + " RBC.INQORIGINALEPCDRF=@FINDINQORIGINALEPCD " + Environment.NewLine
                        + " AND RBC.INQORIGINALSECCDRF=@FINDINQORIGINALSECCD " + Environment.NewLine
                        + " AND RBC.INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                        + " AND RBC.INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                        + " AND RBC.GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                        + " AND RBC.GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                        + " AND RBC.APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;

            return commandText;
        }

        private string MakePmIsolPrcRFSelectString()
        {
            string commandText = string.Empty;

            // Select�R�}���h
            commandText = "SELECT" + Environment.NewLine
                        + "  PIP.CREATEDATETIMERF " + Environment.NewLine
                        + " , PIP.UPDATEDATETIMERF " + Environment.NewLine
                        + " , PIP.LOGICALDELETECODERF " + Environment.NewLine
                        + " , PIP.ENTERPRISECODERF " + Environment.NewLine
                        + " , PIP.SECTIONCODERF " + Environment.NewLine
                        + " , PIP.MAKERCODERF " + Environment.NewLine
                        + " , PIP.UPPERLIMITPRICERF " + Environment.NewLine
                        + " , PIP.PMFRACTIONPROCUNITRF " + Environment.NewLine
                        + " , PIP.PMFRACTIONPROCCDRF " + Environment.NewLine
                        + " , PIP.LISTPRICEUPRATERF " + Environment.NewLine
                        + "  FROM PMISOLPRCRF PIP WITH (READUNCOMMITTED) " + Environment.NewLine;

            return commandText;
        }

        private string MakePmIsolPrcRFWhereKeyString()
        {
            string commandText = string.Empty;

            commandText = " WHERE " + Environment.NewLine
                        + " PIP.ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine
                        + " AND PIP.SECTIONCODERF=@SECTIONCODE " + Environment.NewLine
                        + " AND PIP.MAKERCODERF=@MAKERCODE " + Environment.NewLine
                        + " AND PIP.UPPERLIMITPRICERF=@UPPERLIMITPRICE " + Environment.NewLine;

            return commandText;
        }

        #endregion

        //--- ADD  2015/02/23 ���X�� -----<<<<<

        //--- DEL  2015/02/23 ���X�� ----->>>>>
        #region ���C�A�E�g�ύX�O�R�����g

        //#region IRecBgnGdsDB �����o
        //
        //#region Write
        //
        ///// <summary>
        ///// �o�^�E�X�V����
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork�o�^�f�[�^</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //public int Write(ref object paraobj)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //    try
        //    {
        //        // �R�l�N�V��������
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // �g�����U�N�V�����J�n
        //        sqlTransaction = this.CreateSqlTransaction(sqlConnection);
        //
        //        // �o�^�E�X�V����
        //        status = WriteProc(ref paraobj, ref sqlConnection, ref sqlTransaction);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Write");
        //        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    // �R�~�b�g
        //                    sqlTransaction.Commit();
        //                }
        //                else
        //                {
        //                    // ���[���o�b�N
        //                    sqlTransaction.Rollback();
        //                }
        //            }
        //            sqlTransaction.Dispose();
        //        }
        //
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        //
        //#endregion
        //
        //#region Read
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ��������
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork�������ʃ��X�g</param>
        ///// <param name="paraobj">RecBgnGdsWork�����f�[�^</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : �����������i�ݒ�}�X�^���������܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //public int Read(ref object retobj, object paraobj, ref string errMsg)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlConnection sqlConnection = null;
        //
        //    try
        //    {
        //        // �R�l�N�V�����쐬
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // ��������
        //        status = ReadProc(out retobj, paraobj, sqlConnection, ref errMsg);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Read");
        //        retobj = new ArrayList();
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //
        //    return status;
        //}
        //
        //#endregion
        //
        //#region Search
        //
        ///// <summary>
        ///// ��������
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork�������ʃf�[�^���X�g</param>
        ///// <param name="paraobj">RecBgnGdsSearchParaWork�����p�����[�^</param>
        ///// <param name="paraobj">�����p�����[�^</param>
        ///// <param name="logicalMode">�_���폜</param>
        ///// <param name="count">����</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //public int Search(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlConnection sqlConnection = null;
        //    retobj = null;
        //    count = 0;
        //
        //    try
        //    {
        //        // �R�l�N�V�����쐬
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // ��������
        //        status = SearchProc(out retobj, paraobj, logicalMode, ref sqlConnection, out count, ref errMsg);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Search");
        //        retobj = new ArrayList();
        //        count = 0;
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        //
        ///// <summary>
        ///// ���������i�_���폜�����j
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork�������ʃf�[�^���X�g</param>
        ///// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        ///// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <br>Note       : </br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        //public int Search(out object retobj, string inqOtherEpCd, ConstantManagement.LogicalMode logicalMode, ref string errMsg)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlConnection sqlConnection = null;
        //    retobj = null;
        //
        //    try
        //    {
        //        // �R�l�N�V�����쐬
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // ��������
        //        status = SearchProc(out retobj, inqOtherEpCd, logicalMode, ref sqlConnection, ref errMsg);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Search");
        //        retobj = null;
        //        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //
        //    return status;
        //}
        //
        //#endregion
        //
        //#region Delete
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ���S�폜����
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork�폜�f�[�^</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : �����������i�ݒ�}�X�^�𕨗��폜���܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //public int Delete(object paraobj)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //
        //    try
        //    {
        //        // �R�l�N�V�����쐬
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // �g�����U�N�V�����쐬
        //        sqlTransaction = this.CreateSqlTransaction(sqlConnection);
        //
        //        // �폜����
        //        status = DeleteProc(paraobj, ref sqlConnection, ref sqlTransaction);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Delete");
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    // �R�~�b�g
        //                    sqlTransaction.Commit();
        //                }
        //                else
        //                {
        //                    // ���[���o�b�N
        //                    sqlTransaction.Rollback();
        //                }
        //            }
        //            sqlTransaction.Dispose();
        //        }
        //
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        //
        //#endregion
        //
        //#region DeleteAndWrite
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ���S�폜�E�_���폜�E�o�^�E�X�V�����i���X�g�����j
        ///// </summary>
        ///// <param name="paraDelObj">RecBgnGdsWork�폜�f�[�^���X�g</param>
        ///// <param name="paraUpdObj">RecBgnGdsWork�o�^�E�X�V�f�[�^���X�g</param>
        ///// <param name="errorObj">RecBgnGdsWork�G���[���X�g</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <br>Note       : �����������i�ݒ�}�X�^�����S�폜�A�_���폜�A�o�^�E�X�V���܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        //public int DeleteAndWrite(object paraDelObj, ref object paraUpdObj, out object errorObj)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //    errorObj = null;
        //
        //    try
        //    {
        //        // �R�l�N�V�����쐬
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // �g�����U�N�V�����J�n
        //        sqlTransaction = this.CreateSqlTransaction(sqlConnection);
        //
        //        // �ϊ�
        //        ArrayList delList = paraDelObj as ArrayList;
        //        ArrayList updList = paraUpdObj as ArrayList;
        //
        //        // ���S�폜
        //        foreach (RecBgnGdsWork recBgnGdsWork in delList)
        //        {
        //            object paraObj = recBgnGdsWork as object;
        //            status = this.DeleteProc(paraObj, ref sqlConnection, ref sqlTransaction);
        //            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            {
        //                errorObj = null;
        //                return status;
        //            }
        //        }
        //
        //        // �o�^�E�X�V�E�_���폜
        //        foreach (RecBgnGdsWork recBgnGdsWork in updList)
        //        {
        //            object paraObj = recBgnGdsWork as object;
        //            if (recBgnGdsWork.LogicalDeleteCode == 0)
        //            {
        //                status = this.ReadDBBeforeSave(ref paraObj, ref sqlConnection, ref sqlTransaction);
        //                if (status != 0)
        //                {
        //                    errorObj = paraObj;
        //                    return status;
        //                }
        //                status = this.WriteProc(ref paraObj, ref sqlConnection, ref sqlTransaction);
        //            }
        //            else
        //            {
        //                status = this.LogicalDeleteProc(ref paraObj, 0, ref sqlConnection, ref sqlTransaction);
        //            }
        //
        //            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            {
        //                errorObj = null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsWorkDB.DeleteAndWrite");
        //        errorObj = null;
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    // �R�~�b�g
        //                    sqlTransaction.Commit();
        //                }
        //                else
        //                {
        //                    // ���[���o�b�N
        //                    sqlTransaction.Rollback();
        //                }
        //            }
        //            sqlTransaction.Dispose();
        //        }
        //
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        //
        //#endregion
        //
        //#region DeleteAndRevival
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ���S�폜�E���������i���X�g�����j
        ///// </summary>
        ///// <param name="paraDelObj">RecBgnGdsWork�폜�f�[�^���X�g</param>
        ///// <param name="paraUpdObj">RecBgnGdsWork�����f�[�^���X�g</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <br>Note       : �����������i�ݒ�}�X�^�����S�폜�A�������܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        //public int DeleteAndRevival(object paraDelObj, ref object paraUpdObj)
        //{
        //
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //
        //    try
        //    {
        //        // �R�l�N�V��������
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // �g�����U�N�V�����J�n
        //        sqlTransaction = this.CreateSqlTransaction(sqlConnection);
        //
        //        // �ϊ�
        //        ArrayList delList = paraDelObj as ArrayList;
        //        ArrayList updList = paraUpdObj as ArrayList;
        //
        //        // ���S�폜
        //        foreach (RecBgnGdsWork recBgnGdsWork in delList)
        //        {
        //            object paraObj = recBgnGdsWork as object;
        //            status = this.DeleteProc(paraObj, ref sqlConnection, ref sqlTransaction);
        //            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
        //        }
        //
        //        // ����
        //        foreach (RecBgnGdsWork recBgnGdsWork in updList)
        //        {
        //            object paraObj = recBgnGdsWork as object;
        //            status = this.LogicalDeleteProc(ref paraObj, 1, ref sqlConnection, ref sqlTransaction);
        //            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.DeleteAndWrite");
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    // �R�~�b�g
        //                    sqlTransaction.Commit();
        //                }
        //                else
        //                {
        //                    // ���[���o�b�N
        //                    sqlTransaction.Rollback();
        //                }
        //            }
        //
        //            sqlTransaction.Dispose();
        //        }
        //
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        //
        //#endregion
        //
        //#region LogicalDelete
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ �_���폜����
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork�_���폜�f�[�^</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : �����������i�ݒ�}�X�^��_���폜���܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //public int LogicalDelete(ref object paraobj)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //
        //    try
        //    {
        //        // �R�l�N�V��������
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // �g�����U�N�V�����J�n
        //        sqlTransaction = this.CreateSqlTransaction(sqlConnection);
        //
        //        // �_���폜
        //        status = LogicalDeleteProc(ref paraobj, 0, ref sqlConnection, ref sqlTransaction);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.LogicalDelete");
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    // �R�~�b�g
        //                    sqlTransaction.Commit();
        //                }
        //                else
        //                {
        //                    // ���[���o�b�N
        //                    sqlTransaction.Rollback();
        //                }
        //            }
        //            sqlTransaction.Dispose();
        //        }
        //
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //
        //}
        //
        //#endregion
        //
        //#region RevivalLogicalDelete
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ��������
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork�����f�[�^</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : �����������i�ݒ�}�X�^�̘_���폜�f�[�^�𕜊����܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //public int RevivalLogicalDelete(ref object paraobj)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //
        //    try
        //    {
        //        // �R�l�N�V��������
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // �g�����U�N�V�����J�n
        //        sqlTransaction = this.CreateSqlTransaction(sqlConnection);
        //
        //        // ��������
        //        status = RevivalLogicalDeleteProc(ref paraobj, ref sqlConnection, ref sqlTransaction);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.RevivalLogicalDelete");
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        //
        //#endregion
        //
        //#endregion
        //
        //#region �o�^�E�X�V����
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ �o�^�E�X�V�����i�������j
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork�o�^�f�[�^</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="sqlTransaction">SqlTransaction</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int WriteProc(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //
        //    try
        //    {
        //        RecBgnGdsWork recBgnGdsWork = paraobj as RecBgnGdsWork;
        //        string commandText = string.Empty;
        //
        //        // �R�}���h�쐬
        //        using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
        //        {
        //            // Select�R�}���h
        //            commandText += MakeSelectString();
        //            commandText += MakeWhereKeyString();
        //
        //            sqlCommand.CommandText = commandText;
        //
        //            //Parameter�I�u�W�F�N�g�̍쐬(�����p)
        //            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
        //            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
        //            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
        //            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
        //            SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);
        //
        //            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
        //            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalEpCd);
        //            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalSecCd);
        //            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherEpCd);
        //            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherSecCd);
        //            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.CustomerCode);
        //            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.GoodsMakerCd);
        //            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsNo);
        //            findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.ApplyStaDate);
        //
        //            //�^�C���A�E�g���Ԃ̐ݒ�
        //            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
        //
        //            // Read
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //
        //            if (myReader.Read())
        //            {
        //                // �X�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
        //                DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //                if (updateDateTime != recBgnGdsWork.UpdateDateTime)
        //                {
        //                    // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
        //                    if (recBgnGdsWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
        //                    // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
        //                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
        //                    // Close
        //                    sqlCommand.Cancel();
        //                    myReader.Close();
        //                    return status;
        //                }
        //
        //                //Update�R�}���h�̐���
        //                commandText = "UPDATE RECBGNGDSRF" + Environment.NewLine;
        //                commandText += "SET" + Environment.NewLine;
        //                commandText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
        //                commandText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
        //                commandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
        //                commandText += " , INQORIGINALEPCDRF=@INQORIGINALEPCD" + Environment.NewLine;
        //                commandText += " , INQORIGINALSECCDRF=@INQORIGINALSECCD" + Environment.NewLine;
        //                commandText += " , INQOTHEREPCDRF=@INQOTHEREPCD" + Environment.NewLine;
        //                commandText += " , INQOTHERSECCDRF=@INQOTHERSECCD" + Environment.NewLine;
        //                commandText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
        //                commandText += " , MNGSECTIONCODERF=@MNGSECTIONCODE" + Environment.NewLine;
        //                commandText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
        //                commandText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
        //                commandText += " , GOODSMAKERNMRF=@GOODSMAKERNM" + Environment.NewLine;
        //                commandText += " , GOODSNAMERF=@GOODSNAME" + Environment.NewLine;
        //                commandText += " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
        //                commandText += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
        //                commandText += " , GOODSCOMMENTRF=@GOODSCOMMENT" + Environment.NewLine;
        //                commandText += " , MKRSUGGESTRTPRICRF=@MKRSUGGESTRTPRIC" + Environment.NewLine;
        //                commandText += " , LISTPRICERF=@LISTPRICE" + Environment.NewLine;
        //                commandText += " , UNITPRICERF=@UNITPRICE" + Environment.NewLine;
        //                commandText += " , APPLYSTADATERF=@APPLYSTADATE" + Environment.NewLine;
        //                commandText += " , APPLYENDDATERF=@APPLYENDDATE" + Environment.NewLine;
        //                commandText += " , MODELFITDIVRF=@MODELFITDIV" + Environment.NewLine;
        //                commandText += " , GOODSIMAGERF=@GOODSIMAGE" + Environment.NewLine;
        //                commandText += MakeWhereKeyString();
        //
        //                //�o�^�w�b�_����ݒ�
        //                recBgnGdsWork.UpdateDateTime = DateTime.Now;
        //            }
        //            else
        //            {
        //                //�@�X�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
        //                if (recBgnGdsWork.UpdateDateTime > DateTime.MinValue)
        //                {
        //                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
        //                    sqlCommand.Cancel();
        //                    if (!myReader.IsClosed) myReader.Close();
        //                    return status;
        //                }
        //
        //                //Insert�R�}���h�̐���
        //                commandText = "INSERT INTO RECBGNGDSRF (" + Environment.NewLine;
        //                commandText += "  CREATEDATETIMERF" + Environment.NewLine;
        //                commandText += ", UPDATEDATETIMERF" + Environment.NewLine;
        //                commandText += ", LOGICALDELETECODERF" + Environment.NewLine;
        //                commandText += ", INQORIGINALEPCDRF" + Environment.NewLine;
        //                commandText += ", INQORIGINALSECCDRF" + Environment.NewLine;
        //                commandText += ", INQOTHEREPCDRF" + Environment.NewLine;
        //                commandText += ", INQOTHERSECCDRF" + Environment.NewLine;
        //                commandText += ", CUSTOMERCODERF" + Environment.NewLine;
        //                commandText += ", MNGSECTIONCODERF" + Environment.NewLine;
        //                commandText += ", GOODSNORF" + Environment.NewLine;
        //                commandText += ", GOODSMAKERCDRF" + Environment.NewLine;
        //                commandText += ", GOODSMAKERNMRF" + Environment.NewLine;
        //                commandText += ", GOODSNAMERF" + Environment.NewLine;
        //                commandText += ", BLGROUPCODERF" + Environment.NewLine;
        //                commandText += ", BLGOODSCODERF" + Environment.NewLine;
        //                commandText += ", GOODSCOMMENTRF" + Environment.NewLine;
        //                commandText += ", MKRSUGGESTRTPRICRF" + Environment.NewLine;
        //                commandText += ", LISTPRICERF" + Environment.NewLine;
        //                commandText += ", UNITPRICERF" + Environment.NewLine;
        //                commandText += ", APPLYSTADATERF" + Environment.NewLine;
        //                commandText += ", APPLYENDDATERF" + Environment.NewLine;
        //                commandText += ", MODELFITDIVRF" + Environment.NewLine;
        //                commandText += ", GOODSIMAGERF" + Environment.NewLine;
        //                commandText += ") VALUES (" + Environment.NewLine;
        //                commandText += "  @CREATEDATETIME" + Environment.NewLine;
        //                commandText += ", @UPDATEDATETIME" + Environment.NewLine;
        //                commandText += ", @LOGICALDELETECODE" + Environment.NewLine;
        //                commandText += ", @INQORIGINALEPCD" + Environment.NewLine;
        //                commandText += ", @INQORIGINALSECCD" + Environment.NewLine;
        //                commandText += ", @INQOTHEREPCD" + Environment.NewLine;
        //                commandText += ", @INQOTHERSECCD" + Environment.NewLine;
        //                commandText += ", @CUSTOMERCODE" + Environment.NewLine;
        //                commandText += ", @MNGSECTIONCODE" + Environment.NewLine;
        //                commandText += ", @GOODSNO" + Environment.NewLine;
        //                commandText += ", @GOODSMAKERCD" + Environment.NewLine;
        //                commandText += ", @GOODSMAKERNM" + Environment.NewLine;
        //                commandText += ", @GOODSNAME" + Environment.NewLine;
        //                commandText += ", @BLGROUPCODE" + Environment.NewLine;
        //                commandText += ", @BLGOODSCODE" + Environment.NewLine;
        //                commandText += ", @GOODSCOMMENT" + Environment.NewLine;
        //                commandText += ", @MKRSUGGESTRTPRIC" + Environment.NewLine;
        //                commandText += ", @LISTPRICE" + Environment.NewLine;
        //                commandText += ", @UNITPRICE" + Environment.NewLine;
        //                commandText += ", @APPLYSTADATE" + Environment.NewLine;
        //                commandText += ", @APPLYENDDATE" + Environment.NewLine;
        //                commandText += ", @MODELFITDIV" + Environment.NewLine;
        //                commandText += ", @GOODSIMAGE" + Environment.NewLine;
        //                commandText += ")" + Environment.NewLine;
        //
        //                //�o�^�w�b�_����ݒ�
        //                recBgnGdsWork.UpdateDateTime = DateTime.Now;
        //                recBgnGdsWork.CreateDateTime = DateTime.Now;
        //            }
        //
        //            // SqlReader Close
        //            if (!myReader.IsClosed) myReader.Close();
        //
        //            //Prameter�I�u�W�F�N�g�̍쐬
        //            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
        //            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
        //            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
        //            SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
        //            SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
        //            SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
        //            SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
        //            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
        //            SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
        //            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
        //            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
        //            SqlParameter paraGoodsMakerNm = sqlCommand.Parameters.Add("@GOODSMAKERNM", SqlDbType.NVarChar);
        //            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
        //            SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
        //            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
        //            SqlParameter paraGoodsComment = sqlCommand.Parameters.Add("@GOODSCOMMENT", SqlDbType.NVarChar);
        //            SqlParameter paraMkrSuggestRtPric = sqlCommand.Parameters.Add("@MKRSUGGESTRTPRIC", SqlDbType.BigInt);
        //            SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.BigInt);
        //            SqlParameter paraUnitPrice = sqlCommand.Parameters.Add("@UNITPRICE", SqlDbType.BigInt);
        //            SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
        //            SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
        //            SqlParameter paraModelFitDiv = sqlCommand.Parameters.Add("@MODELFITDIV", SqlDbType.SmallInt);
        //            SqlParameter paraGoodsImage = sqlCommand.Parameters.Add("@GOODSIMAGE", SqlDbType.VarBinary);
        //
        //            //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsWork.CreateDateTime);
        //            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsWork.UpdateDateTime);
        //            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.LogicalDeleteCode);
        //            paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalEpCd);
        //            paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalSecCd);
        //            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherEpCd);
        //            paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherSecCd);
        //            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.CustomerCode);
        //            paraMngSectionCode.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.MngSectionCode);
        //            paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsNo);
        //            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.GoodsMakerCd);
        //            paraGoodsMakerNm.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsMakerNm);
        //            paraGoodsName.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsName);
        //            paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.BLGroupCode);
        //            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.BLGoodsCode);
        //            paraGoodsComment.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsComment);
        //            paraMkrSuggestRtPric.Value = SqlDataMediator.SqlSetInt64(recBgnGdsWork.MkrSuggestRtPric);
        //            paraListPrice.Value = SqlDataMediator.SqlSetInt64(recBgnGdsWork.ListPrice);
        //            paraUnitPrice.Value = SqlDataMediator.SqlSetInt64(recBgnGdsWork.UnitPrice);
        //            paraApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.ApplyStaDate);
        //            paraApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.ApplyEndDate);
        //            paraModelFitDiv.Value = SqlDataMediator.SqlSetInt16(recBgnGdsWork.ModelFitDiv);
        //            paraGoodsImage.Value = SqlDataMediator.SqlSetBinary(recBgnGdsWork.GoodsImage);
        //
        //            // �o�^�E�X�V���s
        //            sqlCommand.CommandText = commandText;
        //            sqlCommand.ExecuteNonQuery();
        //
        //            paraobj = recBgnGdsWork as object;
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Delete");
        //    }
        //
        //    return status;
        //}
        //
        //#endregion
        //
        //#region ��������
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ���������i�������j
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork�������ʃ��X�g</param>
        ///// <param name="paraobj">RecBgnGdsSearchParaWork�����p�����[�^</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <param name="count">����</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : �����������i�ݒ�}�X�^�����������ʃ��X�g��ԋp���܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int SearchProc(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, out int count, ref string errMsg)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    ArrayList al = new ArrayList();
        //    count = 0;
        //    retobj = null;
        //
        //    try
        //    {
        //        RecBgnGdsSearchParaWork recBgnGdsSearchParaWork = paraobj as RecBgnGdsSearchParaWork;
        //        StringBuilder sqlTxt = new StringBuilder(string.Empty);
        //
        //        using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
        //        {
        //            // Select�R�}���h
        //            sqlTxt.Append(MakeSelectString());
        //
        //            #region Where��
        //            sqlTxt.Append(" WHERE").Append(Environment.NewLine);
        //
        //            //�_���폜�敪
        //            sqlTxt.Append("      LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
        //            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
        //            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
        //
        //            // �⍇������ƃR�[�h
        //            if (recBgnGdsSearchParaWork.InqOriginalEpCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND INQORIGINALEPCDRF=@INQORIGINALEPCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCDRF", SqlDbType.NChar);
        //                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOriginalEpCd);
        //            }
        //
        //            // �⍇�������_�R�[�h
        //            if (recBgnGdsSearchParaWork.InqOriginalSecCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND INQORIGINALSECCDRF=@INQORIGINALSECCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCDRF", SqlDbType.NChar);
        //                findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOriginalSecCd);
        //            }
        //
        //            // �⍇�����ƃR�[�h
        //            if (recBgnGdsSearchParaWork.InqOtherEpCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
        //                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
        //                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherEpCd);
        //            }
        //
        //            // �⍇���拒�_�R�[�h
        //            int inqOtherSecCd = 0;
        //            int.TryParse(recBgnGdsSearchParaWork.InqOtherSecCd, out inqOtherSecCd);
        //            if (inqOtherSecCd != 0)
        //            {
        //                sqlTxt.Append("  AND INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
        //                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
        //                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherSecCd);
        //            }
        //
        //            // ���Ӑ�R�[�h
        //            if (recBgnGdsSearchParaWork.CustomerCode != 0)
        //            {
        //                sqlTxt.Append("  AND CUSTOMERCODERF=@CUSTOMERCODE").Append(Environment.NewLine);
        //                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
        //                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.CustomerCode);
        //            }
        //
        //            //���[�J�[�R�[�h�i�J�n�j
        //            if (recBgnGdsSearchParaWork.GoodsMakerCdSt != 0)
        //            {
        //                sqlTxt.Append("  AND GOODSMAKERCDRF>=@GOODSMAKERCDST").Append(Environment.NewLine);
        //                SqlParameter paraStGoodsMakerCdST = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
        //                paraStGoodsMakerCdST.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdSt);
        //            }
        //            //���[�J�[�R�[�h�i�I���j
        //            if (recBgnGdsSearchParaWork.GoodsMakerCdEd != 0)
        //            {
        //                sqlTxt.Append("  AND GOODSMAKERCDRF<=@GOODSMAKERCDED").Append(Environment.NewLine);
        //                SqlParameter paraEdGoodsMakerCdED = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
        //                paraEdGoodsMakerCdED.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdEd);
        //            }
        //
        //            // ���J�J�n���i�J�n�j
        //            if (recBgnGdsSearchParaWork.ApplyDateSt != 0)
        //            {
        //                sqlTxt.Append("  AND APPLYSTADATERF>=@APPLYSTADATE").Append(Environment.NewLine);
        //                SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
        //                findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
        //            }
        //
        //            // ���J�J�n���i�I���j
        //            if (recBgnGdsSearchParaWork.ApplyDateEd != 0)
        //            {
        //                sqlTxt.Append("  AND APPLYENDDATERF<=@APPLYENDDATE").Append(Environment.NewLine);
        //                SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
        //                findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
        //            }
        //
        //            //�i��*
        //            if (recBgnGdsSearchParaWork.GoodsNo.Trim() != string.Empty)
        //            {
        //                if (recBgnGdsSearchParaWork.GoodsNo.Trim().Substring(recBgnGdsSearchParaWork.GoodsNo.Trim().Length - 1, 1) == "*")
        //                {
        //                    sqlTxt.Append("  AND REPLACE(GOODSNORF,'-','') LIKE REPLACE(@GOODSNO,'-','')").Append(Environment.NewLine);
        //                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
        //                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.GoodsNo.Trim().Substring(0, recBgnGdsSearchParaWork.GoodsNo.Trim().Length - 1) + "%");
        //                }
        //                else
        //                {
        //                    sqlTxt.Append("  AND REPLACE(GOODSNORF,'-','') = REPLACE(@GOODSNO,'-','')").Append(Environment.NewLine);
        //                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
        //                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.GoodsNo.Trim());
        //                }
        //            }
        //
        //
        //            #endregion
        //
        //            // OrderBy��ǋL
        //            #region ORDER BY��
        //            sqlTxt.Append("    ORDER BY ").Append(Environment.NewLine);
        //            sqlTxt.Append("       INQORIGINALEPCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,INQORIGINALSECCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,GOODSMAKERCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,GOODSNORF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,APPLYSTADATERF").Append(Environment.NewLine);
        //            #endregion
        //
        //            sqlCommand.CommandText = sqlTxt.ToString();
        //
        //            //�^�C���A�E�g���Ԃ̐ݒ�
        //            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
        //
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //            while (myReader.Read())
        //            {
        //                if (al.Count == 20000)
        //                {
        //                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //                    retobj = al;
        //                    count = 20001;
        //                    return status;
        //                }
        //                RecBgnGdsWork recBgnGdsWork = CopyToRecBgnGdsWorkFromReader(ref myReader);
        //                al.Add(recBgnGdsWork);
        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //            if (!myReader.IsClosed) myReader.Close();
        //            myReader.Dispose();
        //
        //        } // end using
        //    }
        //    catch (SqlException ex)
        //    {
        //        status = base.WriteSQLErrorLog(ex, "RecBgnItmstDB.Search", status);
        //        errMsg = ex.ToString();
        //    }
        //    retobj = al;
        //
        //    return status;
        //}
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ���������i�������j
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork�������ʃ��X�g</param>
        ///// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : �w��⍇�����ƃR�[�h�̊Y���f�[�^���������܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int SearchProc(out object retobj, string inqOtherEpCd, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref string errMsg)
        //{
        //
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //
        //    retobj = null;
        //    ArrayList al = new ArrayList();
        //
        //    try
        //    {
        //        StringBuilder sqlTxt = new StringBuilder(string.Empty);
        //
        //        using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
        //        {
        //            // Select�R�}���h
        //            sqlTxt.Append(MakeSelectString());
        //
        //            #region WHERE��
        //            sqlTxt.Append("   WHERE ").Append(Environment.NewLine);
        //
        //            // �⍇�����ƃR�[�h
        //            sqlTxt.Append("       INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
        //            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
        //            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(inqOtherEpCd);
        //
        //            //�_���폜�敪
        //            string wkstring = string.Empty;
        //            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
        //                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
        //                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
        //                (logicalMode == ConstantManagement.LogicalMode.GetData3))
        //            {
        //                sqlTxt.Append("   AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
        //                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
        //                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
        //            }
        //            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
        //                (logicalMode == ConstantManagement.LogicalMode.GetData012))
        //            {
        //                sqlTxt.Append("   AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
        //                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
        //                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
        //            }
        //
        //            #endregion
        //
        //            // OrderBy��ǋL
        //            #region ORDER BY��
        //            sqlTxt.Append("    ORDER BY ").Append(Environment.NewLine);
        //            sqlTxt.Append("       INQORIGINALEPCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,INQORIGINALSECCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,GOODSMAKERCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,GOODSNORF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,APPLYSTADATERF").Append(Environment.NewLine);
        //            #endregion
        //
        //            sqlCommand.CommandText = sqlTxt.ToString();
        //
        //            //�^�C���A�E�g���Ԃ̐ݒ�
        //            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
        //
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //            while (myReader.Read())
        //            {
        //                RecBgnGdsWork work = CopyToRecBgnGdsWorkFromReader(ref myReader);
        //                al.Add(work);
        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //            if (!myReader.IsClosed) myReader.Close();
        //            myReader.Dispose();
        //
        //        } // end using
        //    }
        //    catch (SqlException ex)
        //    {
        //        status = base.WriteSQLErrorLog(ex, "RecBgnItmstDB.Search", status);
        //        errMsg = ex.ToString();
        //    }
        //
        //    retobj = al;
        //
        //    return status;
        //}
        //
        //#endregion
        //
        //#region �Ǎ�����
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ �Ǎ������i�������j
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork�������ʃ��X�g</param>
        ///// <param name="paraobj">RecBgnGdsWork�����p�����[�^</param>
        ///// <param name="sqlConnection">SqlConnenction</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : �����������i�ݒ�}�X�^�����������ʃ��X�g��ԋp���܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int ReadProc(out object retobj, object paraobj, SqlConnection sqlConnection, ref string errMsg)
        //{
        //
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //
        //    retobj = null;
        //    ArrayList al = new ArrayList();
        //
        //    try
        //    {
        //        RecBgnGdsWork recBgnGdsWork = paraobj as RecBgnGdsWork;
        //        StringBuilder sqlTxt = new StringBuilder(string.Empty);
        //
        //        using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
        //        {
        //
        //            // Select�R�}���h
        //            sqlTxt.Append(MakeSelectString());
        //
        //            #region WHERE��
        //            sqlTxt.Append("  WHERE ").Append(Environment.NewLine);
        //
        //            // �⍇������ƃR�[�h
        //            if (recBgnGdsWork.InqOriginalEpCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("      INQORIGINALEPCDRF=@INQORIGINALEPCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCDRF", SqlDbType.NChar);
        //                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalEpCd);
        //            }
        //
        //            // �⍇�������_�R�[�h
        //            if (recBgnGdsWork.InqOriginalSecCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND INQORIGINALSECCDRF=@INQORIGINALSECCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCDRF", SqlDbType.NChar);
        //                findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalSecCd);
        //            }
        //
        //            // �⍇�����ƃR�[�h
        //            if (recBgnGdsWork.InqOtherEpCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND INQOTHEREPCDRF=@INQOTHEREPCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCDRF", SqlDbType.NChar);
        //                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherEpCd);
        //            }
        //
        //            // �⍇���拒�_�R�[�h
        //            if (recBgnGdsWork.InqOtherSecCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND INQOTHERSECCDRF=@INQOTHERSECCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCDRF", SqlDbType.NChar);
        //                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherSecCd);
        //            }
        //
        //            //// ���Ӑ�R�[�h
        //            //if (recBgnGdsWork.CustomerCode != 0)
        //            //{
        //            //    sqlTxt.Append("  AND CUSTOMERCODERF=@CUSTOMERCODERF").Append(Environment.NewLine);
        //            //    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODERF", SqlDbType.Int);
        //            //    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.CustomerCode);
        //            //}
        //
        //            // ���i���[�J�[�R�[�h
        //            if (recBgnGdsWork.GoodsMakerCd != 0)
        //            {
        //                sqlTxt.Append("  AND GOODSMAKERCDRF=@GOODSMAKERCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCDRF", SqlDbType.Int);
        //                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.GoodsMakerCd);
        //            }
        //
        //            // ���i�ԍ�
        //            if (recBgnGdsWork.GoodsNo.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND GOODSNORF=@GOODSNORF").Append(Environment.NewLine);
        //                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNORF", SqlDbType.NVarChar);
        //                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsNo);
        //            }
        //
        //            //// BL�O���[�v�R�[�h
        //            //if (recBgnGdsWork.BLGroupCode != 0)
        //            //{
        //            //    sqlTxt.Append("  AND BLGROUPCODERF=@BLGROUPCODERF").Append(Environment.NewLine);
        //            //    SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODERF", SqlDbType.Int);
        //            //    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.BLGroupCode);
        //            //}
        //
        //            //// BL���i�R�[�h
        //            //if (recBgnGdsWork.BLGoodsCode != 0)
        //            //{
        //            //    sqlTxt.Append("  AND BLGOODSCODERF=@BLGOODSCODERF").Append(Environment.NewLine);
        //            //    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODERF", SqlDbType.Int);
        //            //    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.BLGoodsCode);
        //            //}
        //
        //            //// ���J�J�n��
        //            //if (recBgnGdsWork.OpenStartDate != 0)
        //            //{
        //            //    sqlTxt.Append("  AND OPENSTARTDATERF=@OPENSTARTDATERF").Append(Environment.NewLine);
        //            //    SqlParameter findParaOpenStartDate = sqlCommand.Parameters.Add("@OPENSTARTDATERF", SqlDbType.Int);
        //            //    findParaOpenStartDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.OpenStartDate);
        //            //}
        //
        //            //// ���J�I����
        //            //if (recBgnGdsWork.OpenEndDate != 0)
        //            //{
        //            //    sqlTxt.Append("  AND OPENENDDATERF=@OPENENDDATERF").Append(Environment.NewLine);
        //            //    SqlParameter findParaOpenEndDate = sqlCommand.Parameters.Add("@OPENENDDATERF", SqlDbType.Int);
        //            //    findParaOpenEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.OpenEndDate);
        //            //}
        //
        //            #endregion
        //
        //            // �R�}���h�ݒ�
        //            sqlCommand.CommandText = sqlTxt.ToString();
        //            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
        //
        //            // Reader �� Work
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //            while (myReader.Read())
        //            {
        //                RecBgnGdsWork work = this.CopyToRecBgnGdsWorkFromReader(ref myReader);
        //                al.Add(work);
        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //            myReader.Close();
        //            myReader.Dispose();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        status = base.WriteSQLErrorLog(ex, "RecBgnItmstDB.Read", status);
        //        errMsg = ex.ToString();
        //    }
        //    finally
        //    {
        //        // �������ʃ��X�g���i�[
        //        retobj = al;
        //    }
        //
        //    return status;
        //
        //}
        //
        //#endregion
        //
        //#region ���S�폜����
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ���S�폜�����i�������j
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork�f�[�^</param>
        ///// <param name="sqlConnection">sqlConnection</param>
        ///// <param name="sqlTransaction">sqlTransaction</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : �����������i�ݒ�}�X�^�𕨗��폜���܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int DeleteProc(object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //
        //    try
        //    {
        //        RecBgnGdsWork recBgnGdsWork = paraobj as RecBgnGdsWork;
        //        string commandText = string.Empty;
        //
        //        using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
        //        {
        //            // Select�R�}���h
        //            commandText += MakeSelectString();
        //            commandText += MakeWhereKeyString();
        //
        //            sqlCommand.CommandText = commandText;
        //
        //            //Parameter�I�u�W�F�N�g�̍쐬(�����p)
        //            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
        //            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
        //            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
        //            SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);
        //
        //            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
        //            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalEpCd);
        //            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalSecCd);
        //            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherEpCd);
        //            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherSecCd);
        //            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.GoodsMakerCd);
        //            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsNo);
        //            findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.ApplyStaDate);
        //
        //            // Read
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //            if (myReader.Read())
        //            {
        //                // �X�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
        //                DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //                if (updateDateTime != recBgnGdsWork.UpdateDateTime)
        //                {
        //                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
        //                    sqlCommand.Cancel();
        //                    myReader.Close();
        //                    return status;
        //                }
        //
        //                // SqlReader Close
        //                if (!myReader.IsClosed) myReader.Close();
        //
        //                // Delete�R�}���h�̐���
        //                commandText = "DELETE FROM RECBGNGDSRF" + Environment.NewLine;
        //                commandText += MakeWhereKeyString();
        //                sqlCommand.CommandText = commandText;
        //
        //                // Delete���s
        //                sqlCommand.ExecuteNonQuery();
        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //
        //            }
        //            else
        //            {
        //                // �X�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
        //                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
        //                sqlCommand.Cancel();
        //                if (!myReader.IsClosed) myReader.Close();
        //            }
        //
        //        } // end using
        //
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Delete");
        //    }
        //
        //    return status;
        //}
        //
        //#endregion
        //
        //#region �_���폜����
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ �_���폜�����i�������j
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork�f�[�^</param>
        ///// <param name="procMode">�������[�h 0:�_���폜 1:����</param>
        ///// <param name="sqlConnection">sqlConnection</param>
        ///// <param name="sqlTransaction">sqlTransaction</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : �����������i�ݒ�}�X�^��_���폜���܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int LogicalDeleteProc(ref object paraobj, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    int logicalDelCd = 0;
        //
        //    try
        //    {
        //        RecBgnGdsWork recBgnGdsWork = paraobj as RecBgnGdsWork;
        //        string commandText = string.Empty;
        //
        //        // �R�}���h�쐬
        //        using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
        //        {
        //            // Select�R�}���h
        //            commandText += MakeSelectString();
        //            commandText += MakeWhereKeyString();
        //
        //            sqlCommand.CommandText = commandText;
        //
        //            //Parameter�I�u�W�F�N�g�̍쐬(�����p)
        //            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
        //            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
        //            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
        //            SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);
        //
        //            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
        //            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalEpCd);
        //            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalSecCd);
        //            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherEpCd);
        //            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherSecCd);
        //            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.GoodsMakerCd);
        //            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsNo);
        //            findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.ApplyStaDate);
        //
        //            // Read
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //            if (myReader.Read())
        //            {
        //                // �X�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
        //                DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //                if (updateDateTime != recBgnGdsWork.UpdateDateTime)
        //                {
        //                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
        //                    sqlCommand.Cancel();
        //                    myReader.Close();
        //                    return status;
        //                }
        //
        //                // ���݂̘_���폜�敪���擾
        //                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //
        //                // �_���폜�敪�ύX
        //                if (procMode == 0)
        //                {
        //                    //�_���폜���[�h�̏ꍇ
        //                    if (logicalDelCd == 0) recBgnGdsWork.LogicalDeleteCode = 1; //�_���폜�t���O���Z�b�g
        //                    else recBgnGdsWork.LogicalDeleteCode = 3; //���S�폜�t���O���Z�b�g
        //                }
        //                else
        //                {
        //                    //�������[�h�̏ꍇ
        //                    if (logicalDelCd == 1) recBgnGdsWork.LogicalDeleteCode = 0; //�_���폜�t���O������
        //                    else
        //                    {
        //                        if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
        //                        else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; // ���S�폜�̓f�[�^�Ȃ���߂�
        //
        //                        sqlCommand.Cancel();
        //                        if (!myReader.IsClosed) myReader.Close();
        //                        return status;
        //                    }
        //                }
        //
        //                // SqlReader Close
        //                if (!myReader.IsClosed) myReader.Close();
        //
        //                // Update�R�}���h�̐���
        //                commandText = "UPDATE RECBGNGDSRF" + Environment.NewLine;
        //                commandText += "SET" + Environment.NewLine;
        //                commandText += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
        //                commandText += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
        //                commandText += MakeWhereKeyString();
        //                sqlCommand.CommandText = commandText;
        //
        //                //�o�^�w�b�_����ݒ�
        //                recBgnGdsWork.UpdateDateTime = DateTime.Now;
        //
        //                // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
        //                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);       // �X�V����
        //                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);    // �_���폜�敪
        //
        //                // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
        //                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsWork.UpdateDateTime);
        //                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.LogicalDeleteCode);
        //
        //                //�^�C���A�E�g���Ԃ̐ݒ�
        //                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
        //
        //                // Update���s
        //                sqlCommand.ExecuteNonQuery();
        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //
        //            }
        //            else
        //            {
        //                // �X�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
        //                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
        //                if (!myReader.IsClosed) myReader.Close();
        //                return status;
        //            }
        //
        //        } // end using
        //
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.LogicalDelete");
        //    }
        //
        //    return status;
        //
        //}
        //
        //#endregion
        //
        //#region ��������
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ���������i�������j
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork�f�[�^</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="sqlTransaction">SqlTransaction</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : �����������i�ݒ�}�X�^�̘_���폜�f�[�^�𕜊����܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int RevivalLogicalDeleteProc(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //
        //    // �_���폜���������{
        //    return LogicalDeleteProc(ref paraobj, 1, ref sqlConnection, ref sqlTransaction);
        //
        //}
        //
        ///// <summary>
        ///// �o�^�A�X�V�O�A�d�����R�[�h�̑��݃`�F�b�N���s��
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork�f�[�^</param>
        ///// <param name="sqlConnection">sqlConnection</param>
        ///// <param name="sqlTransaction">sqlTransaction</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : �o�^�A�X�V�O�A�d�����R�[�h�̑��݃`�F�b�N���s��</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int ReadDBBeforeSave(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //
        //    try
        //    {
        //        RecBgnGdsWork recBgnGdsWork = paraobj as RecBgnGdsWork;
        //        StringBuilder sqlTxt = new StringBuilder(string.Empty);
        //
        //        using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
        //        {
        //
        //            // Select�R�}���h
        //            sqlTxt.Append(MakeSelectString());
        //
        //            #region WHERE��
        //            sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
        //
        //            // �⍇������ƃR�[�h
        //            sqlTxt.Append("      INQORIGINALEPCDRF=@INQORIGINALEPCD").Append(Environment.NewLine);
        //            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
        //            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalEpCd);
        //
        //            // �⍇�������_�R�[�h
        //            sqlTxt.Append("  AND INQORIGINALSECCDRF=@INQORIGINALSECCD").Append(Environment.NewLine);
        //            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
        //            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalSecCd);
        //
        //            // �⍇�����ƃR�[�h
        //            sqlTxt.Append("  AND INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
        //            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
        //            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherEpCd);
        //
        //            // �⍇���拒�_�R�[�h
        //            sqlTxt.Append("  AND INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
        //            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
        //            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherSecCd);
        //
        //            // ���Ӑ�R�[�h
        //            sqlTxt.Append("  AND CUSTOMERCODERF=@CUSTOMERCODE").Append(Environment.NewLine);
        //            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
        //            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.CustomerCode);
        //
        //            // ���i�ԍ�
        //            sqlTxt.Append("  AND GOODSNORF=@GOODSNO").Append(Environment.NewLine);
        //            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
        //            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsNo);
        //
        //            // ���i���[�J�[�R�[�h
        //            sqlTxt.Append("  AND GOODSMAKERCDRF=@GOODSMAKERCD").Append(Environment.NewLine);
        //            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
        //            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.GoodsMakerCd);
        //
        //            // �K�p��
        //            sqlTxt.Append(" AND ((APPLYSTADATERF<=@APPLYSTADATE AND @APPLYENDDATE<=APPLYENDDATERF)").Append(Environment.NewLine);
        //            sqlTxt.Append("  OR  (APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=APPLYENDDATERF)").Append(Environment.NewLine);
        //            sqlTxt.Append("  OR  (APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=APPLYSTADATERF)").Append(Environment.NewLine);
        //            sqlTxt.Append("  OR  (APPLYENDDATERF>=@APPLYSTADATE AND @APPLYENDDATE>=APPLYENDDATERF))").Append(Environment.NewLine);
        //
        //            SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
        //            paraApplyStaDate.Value = SqlDataMediator.SqlSetInt(recBgnGdsWork.ApplyStaDate);
        //            SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
        //            paraApplyEndDate.Value = SqlDataMediator.SqlSetInt(recBgnGdsWork.ApplyEndDate);
        //
        //            #endregion
        //
        //            // �R�}���h�ݒ�
        //            sqlCommand.CommandText = sqlTxt.ToString();
        //            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
        //            if (sqlTransaction != null)
        //            {
        //                sqlCommand.Transaction = sqlTransaction;
        //            }
        //
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //            while (myReader.Read())
        //            {
        //                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //                paraobj = recBgnGdsWork as object;
        //                myReader.Close();
        //                return status;
        //            }
        //
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //
        //            if (myReader.IsClosed == false)
        //            {
        //                myReader.Close();
        //                myReader.Dispose();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.ReadDBBeforeSave", status);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //
        //    return status;
        //
        //}
        //
        //#endregion
        //
        //#region �N���X�i�[����
        //
        ///// <summary>
        ///// �������ʊi�[�����iReader��RecBgnGdsWork�j
        ///// </summary>
        ///// <param name="myReader">SqlDataReader</param>
        ///// <returns>RecBgnGdsWork</returns>
        ///// <remarks>
        ///// <br>Note       : SqlDataReaer�̌��ݍs��RecBgnGdsWork�֊i�[���܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private RecBgnGdsWork CopyToRecBgnGdsWorkFromReader(ref SqlDataReader myReader)
        //{
        //    RecBgnGdsWork recBgnGdsWork = new RecBgnGdsWork();
        //
        //    recBgnGdsWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //    recBgnGdsWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //    recBgnGdsWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //    recBgnGdsWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
        //    recBgnGdsWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
        //    recBgnGdsWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
        //    recBgnGdsWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
        //
        //    recBgnGdsWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //    recBgnGdsWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
        //    recBgnGdsWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
        //    recBgnGdsWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
        //    recBgnGdsWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMAKERNMRF"));
        //    recBgnGdsWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
        //    recBgnGdsWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
        //    recBgnGdsWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
        //    recBgnGdsWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSCOMMENTRF"));
        //    recBgnGdsWork.MkrSuggestRtPric = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MKRSUGGESTRTPRICRF"));
        //    recBgnGdsWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));
        //    recBgnGdsWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));
        //    recBgnGdsWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
        //    recBgnGdsWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
        //    recBgnGdsWork.ModelFitDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("MODELFITDIVRF"));
        //    recBgnGdsWork.GoodsImage = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("GOODSIMAGERF"));
        //
        //    return recBgnGdsWork;
        //}
        //
        //#endregion
        //
        //private string MakeSelectString()
        //{
        //    string commandText = string.Empty;
        //
        //    // Select�R�}���h
        //    commandText = "SELECT" + Environment.NewLine;
        //    commandText += "  CREATEDATETIMERF" + Environment.NewLine;
        //    commandText += ", UPDATEDATETIMERF" + Environment.NewLine;
        //    commandText += ", LOGICALDELETECODERF" + Environment.NewLine;
        //    commandText += ", INQORIGINALEPCDRF" + Environment.NewLine;
        //    commandText += ", INQORIGINALSECCDRF" + Environment.NewLine;
        //    commandText += ", INQOTHEREPCDRF" + Environment.NewLine;
        //    commandText += ", INQOTHERSECCDRF" + Environment.NewLine;
        //    commandText += ", CUSTOMERCODERF" + Environment.NewLine;
        //    commandText += ", MNGSECTIONCODERF" + Environment.NewLine;
        //    commandText += ", GOODSNORF" + Environment.NewLine;
        //    commandText += ", GOODSMAKERCDRF" + Environment.NewLine;
        //    commandText += ", GOODSMAKERNMRF" + Environment.NewLine;
        //    commandText += ", GOODSNAMERF" + Environment.NewLine;
        //    commandText += ", BLGROUPCODERF" + Environment.NewLine;
        //    commandText += ", BLGOODSCODERF" + Environment.NewLine;
        //    commandText += ", GOODSCOMMENTRF" + Environment.NewLine;
        //    commandText += ", MKRSUGGESTRTPRICRF" + Environment.NewLine;
        //    commandText += ", LISTPRICERF" + Environment.NewLine;
        //    commandText += ", UNITPRICERF" + Environment.NewLine;
        //    commandText += ", APPLYSTADATERF" + Environment.NewLine;
        //    commandText += ", APPLYENDDATERF" + Environment.NewLine;
        //    commandText += ", MODELFITDIVRF" + Environment.NewLine;
        //    commandText += ", GOODSIMAGERF" + Environment.NewLine;
        //    commandText += "  FROM RECBGNGDSRF" + Environment.NewLine;
        //
        //    return commandText;
        //}
        //
        //private string MakeWhereKeyString()
        //{
        //    string commandText = string.Empty;
        //
        //    commandText += " WHERE" + Environment.NewLine;
        //    commandText += "       INQORIGINALEPCDRF=@FINDINQORIGINALEPCD" + Environment.NewLine;
        //    commandText += "   AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD" + Environment.NewLine;
        //    commandText += "   AND INQOTHEREPCDRF=@FINDINQOTHEREPCD" + Environment.NewLine;
        //    commandText += "   AND INQOTHERSECCDRF=@FINDINQOTHERSECCD" + Environment.NewLine;
        //    commandText += "   AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
        //    commandText += "   AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
        //    commandText += "   AND APPLYSTADATERF=@FINDAPPLYSTADATE" + Environment.NewLine;
        //
        //    return commandText;
        //}
        #endregion
        //--- DEL  2015/02/23 ���X�� -----<<<<<



    }
}
