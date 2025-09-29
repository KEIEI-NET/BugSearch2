//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^���p�o�^
// �v���O�����T�v   : �|���}�X�^���p�o�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �|���}�X�^���p�o�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^���p�o�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.5.13</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RateQuoteDB : RemoteDB, IRateQuoteDB
    {
        #region ��private member
        /// <summary>
        /// ���i�����[�g
        /// </summary>
        private RateDB _rateDB = new RateDB();
        #endregion

        #region �E�ǉ�
        /// <summary>
        /// �f�[�^�ǉ�����
        /// </summary>
        /// <param name="rateInsertList">�ǉ����X�g</param>
        /// <param name="rateDeleteList">�폜���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int Write(ref object rateInsertList, ref object rateDeleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraRateInsertList = rateInsertList as ArrayList;
                ArrayList paraRateDeleteList = rateDeleteList as ArrayList;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // �|���}�X�^�o�^
                if (paraRateInsertList != null && paraRateInsertList.Count != 0)
                {
                    // �X�V����
                    foreach (RateWork rateWork in paraRateInsertList)
                    {
                        rateWork.UpdateDateTime = DateTime.MinValue;
                    }
                    status = _rateDB.WriteSubSectionProc(ref paraRateInsertList, ref sqlConnection, ref sqlTransaction);
                }

                // 2009/06/09�@�Ή������@�ǉ��̏ꍇ�A�_���폜�敪�f�[�^�X�V���Ȃ�
                // �|���}�X�^�o�^
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    if (paraRateDeleteList != null && paraRateDeleteList.Count != 0)
                //    {
                //        // �����폜����
                //        status = _rateDB.DeleteSubSectionProc(paraRateDeleteList, ref sqlConnection, ref sqlTransaction);
                //        // ����o�^����
                //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //        {
                //            // �X�V����
                //            foreach (RateWork rateWork in paraRateDeleteList)
                //            {
                //                rateWork.UpdateDateTime = DateTime.MinValue;
                //            }
                //            status = _rateDB.WriteSubSectionProc(ref paraRateDeleteList, ref sqlConnection, ref sqlTransaction);
                //        }
                //    }
                //}

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (SqlException e)
            {
                base.WriteErrorLog(e, "RateQuoteDB.Write(ref object GoodsPriceUWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateQuoteDB.Write(ref object GoodsPriceUWork)");
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
        #endregion

        #region �E�X�V
        /// <summary>
        /// �f�[�^�ǉ��E�X�V����
        /// </summary>
        /// <param name="rateInsertList">�ǉ����X�g</param>
        /// <param name="rateUpdateList">�X�V���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int Update(ref object rateInsertList, ref object rateUpdateList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraRateInsertList = rateInsertList as ArrayList;
                ArrayList paraRateUpdateList = rateUpdateList as ArrayList;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �� 2009.06.18 ���m add ���b�g���C��
                ArrayList paraRateSearchList = new ArrayList();
                ArrayList searchResultList = new ArrayList();
                if (paraRateUpdateList != null && paraRateUpdateList.Count != 0)
                {
                    // �X�V���X�g
                    foreach (RateWork rateUpdate in paraRateUpdateList)
                    {
                        bool isExistFlg = false;

                        // ���ݔ��f
                        foreach (RateWork rateSearch in paraRateSearchList)
                        {
                            if (rateSearch.EnterpriseCode.Equals(rateUpdate.EnterpriseCode)
                                && rateSearch.SectionCode.Equals(rateUpdate.SectionCode)
                                && rateSearch.UnitRateSetDivCd.Equals(rateUpdate.UnitRateSetDivCd)
                                && rateSearch.GoodsMakerCd == rateUpdate.GoodsMakerCd
                                && rateSearch.GoodsNo.Equals(rateUpdate.GoodsNo)
                                && rateSearch.GoodsRateRank.Equals(rateUpdate.GoodsRateRank)
                                && rateSearch.GoodsRateGrpCode == rateUpdate.GoodsRateGrpCode
                                && rateSearch.BLGroupCode == rateUpdate.BLGroupCode
                                && rateSearch.BLGoodsCode == rateUpdate.BLGoodsCode
                                && rateSearch.CustomerCode == rateUpdate.CustomerCode
                                && rateSearch.CustRateGrpCode == rateUpdate.CustRateGrpCode
                                && rateSearch.SupplierCd == rateUpdate.SupplierCd)
                            {
                                isExistFlg = true;
                                break;
                            }
                        }

                        if (!isExistFlg)
                        {
                            paraRateSearchList.Add(rateUpdate);

                            // ����
                            double logCount = rateUpdate.LotCount;
                            // ���b�g��
                            rateUpdate.LotCount = -1;
                            ArrayList searchRes = null;
                            status = _rateDB.SearchSubSectionProc(out searchRes, rateUpdate, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection);

                            rateUpdate.LotCount = logCount;

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                searchResultList.AddRange(searchRes);
                            }
                        }
                    }
                }
                // �� 2009.06.18 ���m add

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // �|���}�X�^�o�^
                if (paraRateInsertList != null && paraRateInsertList.Count != 0)
                {
                    // �X�V����
                    foreach (RateWork rateWork in paraRateInsertList)
                    {
                        rateWork.UpdateDateTime = DateTime.MinValue;
                    }
                    status = _rateDB.WriteSubSectionProc(ref paraRateInsertList, ref sqlConnection, ref sqlTransaction);
                }
                // �|���}�X�^�o�^
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    if (paraRateUpdateList != null && paraRateUpdateList.Count != 0)
                    {
                        // �����폜����
                        status = _rateDB.DeleteSubSectionProc(searchResultList, ref sqlConnection, ref sqlTransaction);
                        // ����o�^����
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �X�V����
                            foreach (RateWork rateWork in paraRateUpdateList)
                            {
                                rateWork.UpdateDateTime = DateTime.MinValue;
                            }
                            status = _rateDB.WriteSubSectionProc(ref paraRateUpdateList, ref sqlConnection, ref sqlTransaction);
                        }
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (SqlException e)
            {
                base.WriteErrorLog(e, "RateQuoteDB.Update(ref object GoodsPriceUWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateQuoteDB.Update(ref object GoodsPriceUWork)");
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
        #endregion

        #region ��[�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
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
