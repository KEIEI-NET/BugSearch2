//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i�����i�Ɖ���[�g�I�u�W�F�N�g
// �v���O�����T�v   : �n���f�B�^�[�~�i�����i�Ɖ���s���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : ���O
// �� �� ��  2017/07/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 3H ������                               
// �C �� ��  2017/09/07  �C�����e : ���i�Ɖ�̕ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470154-00 �쐬�S�� : ���O                              
// �C �� ��  2018/10/16  �C�����e : �n���f�B�^�[�~�i���܎��Ή�
//                                  ����@�\�ƃe�L�X�g�o�͋@�\�̒ǉ�
//----------------------------------------------------------------------------//

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
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �n���f�B�^�[�~�i�����i�Ɖ���[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �n���f�B�^�[�~�i�����i�Ɖ���[�g�I�u�W�F�N�g�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/07/20</br>
    /// <br>Update Note: 2017/09/07 3H ������</br>
    /// <br>�@�@�@�@�@ : ���i�Ɖ�̕ύX�Ή�</br>
    /// <br>Update Note: 2018/10/16 ���O</br>
    /// <br>�@�@�@�@�@ : �n���f�B�^�[�~�i���܎��Ή�</br>
    /// </remarks>
    [Serializable]
    public class HandyInspectRefDataDB : RemoteDB, IHandyInspectRefDataDB
    {
        #region const
        /// <summary>�󒍃X�e�[�^�X�i30�F����j</summary>
        private const int SalesStatus = 30;
        /// <summary>�󒍃X�e�[�^�X�i40�F�ݏo�j</summary>
        private const int RentStatus = 40;
        /// <summary>�󕥌��`�[�敪�i20�F����j</summary>
        private const int SalesAcPaySlipCd = 20;
        /// <summary>�󕥌��`�[�敪�i22�F�o�ׁj</summary>
        private const int ShipmSlipCd = 22;
        /// <summary>����`�[�敪(����)�i0�F����j</summary>
        private const int SalesSlipCdDtl = 0;
        /// <summary>����`�[�敪(����)�i1�F�ԕi�j</summary>
        private const int RetSlipCdDtl = 1;
        /// <summary>�[��</summary>
        private const int Zero = 0;
        #endregion

        #region
        private InspectDataDB HandyInspectDataDB = null;

        /// <summary>
        /// ���i�f�[�^ DB�����[�g�v���p�e�B
        /// </summary>
        private InspectDataDB InspectDataObj
        {
            get
            {
                if (this.HandyInspectDataDB == null)
                {
                    // ���i�f�[�^ DB�����[�g�𐶐�
                    this.HandyInspectDataDB = new InspectDataDB();
                }

                return this.HandyInspectDataDB;
            }
        }
        #endregion

        #region [�R���X�g���N�^]
        /// <summary>
        /// �n���f�B�^�[�~�i�����i�Ɖ���[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public HandyInspectRefDataDB()
        {
            // �Ȃ�
        }
        #endregion

        #region Search
        /// <summary>
        /// �n���f�B�^�[�~�i�����i�Ɖ��񃊃X�g�̎擾����
        /// </summary>
        /// <param name="inspectRefDataObj">���i�Ɖ���</param>
        /// <param name="searchCondtObj">�����p�����[�^</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i�����i�Ɖ��񃊃X�g���擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H ������</br>
        /// <br>�@�@�@�@�@ : ���i�Ɖ�̕ύX�Ή�</br>
        /// </remarks>
        public int Search(out object inspectRefDataObj, object searchCondtObj, out string errMessage)
        {
            SqlConnection Connection = null;
            errMessage = string.Empty;
            // ��������
            inspectRefDataObj = null;
            ArrayList RetList = null;
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �R�l�N�V��������
            using (Connection = CreateSqlConnection(true))
            {
                try
                {
                    // ��������
                    HandyInspectParamWork cndtnWork = searchCondtObj as HandyInspectParamWork;
                    // --- DEL 3H ������ 2017/09/07---------->>>>>
                    //// �o�Ɍ��i�Ɠ��Ɍ��i�̃f�[�^���o
                    //if (cndtnWork.Pattern == 0 || cndtnWork.Pattern == 1)
                    //{
                    //    // ����f�[�^��������
                    //    Status = SearchProc(out RetList, cndtnWork, out errMessage, ref Connection);
                    //}
                    //else if (cndtnWork.Pattern == 3)
                    //{
                    //    // ���i�̂݃f�[�^���o����
                    //    Status = SearchInspectProc(out RetList, cndtnWork, out errMessage, ref Connection);
                    //}
                    // --- DEL 3H ������ 2017/09/07----------<<<<<
                    // --- ADD 3H ������ 2017/09/07---------->>>>>
                    RetList = new ArrayList();
                    // �p�^�[��:�u�o�Ɍ��i�v�̃f�[�^���o
                    if (cndtnWork.Pattern == 0)
                    {
                        // ����Ώۂ́u����v1�F�I��L�� �� ����Ώۂ́u�ݏo�v1�F�I��L��
                        if (cndtnWork.TransSales == 1 || cndtnWork.TransLend == 1)
                        {
                            // ����f�[�^
                            ArrayList salesList = null;
                            // ����f�[�^��������
                            Status = SearchProc(out salesList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (salesList != null && salesList.Count > 0)
                            {
                                for (int i = 0; i < salesList.Count; i++)
                                {
                                    RetList.Add(salesList[i]);
                                }
                            }
                        }
                        // ����Ώۂ́u�d���v1�F�I��L��
                        if (cndtnWork.TransStockSlip == 1)
                        {
                            // �d���f�[�^
                            ArrayList stockSlipList = null;
                            // �d���f�[�^���o����
                            Status = SearchStockSlipProc(out stockSlipList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockSlipList != null && stockSlipList.Count > 0)
                            {
                                for (int i = 0; i < stockSlipList.Count; i++)
                                {
                                    RetList.Add(stockSlipList[i]);
                                }
                            }
                        }
                        // ����Ώۂ́u�ړ��o�Ɂv1�F�I��L��
                        if (cndtnWork.TransMoveOutWarehouse == 1)
                        {
                            // �݌Ɉړ��f�[�^
                            ArrayList stockMoveList = null;
                            // �݌Ɉړ��f�[�^���o����
                            Status = SearchStockMoveProc(out stockMoveList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockMoveList != null && stockMoveList.Count > 0)
                            {
                                for (int i = 0; i < stockMoveList.Count; i++)
                                {
                                    RetList.Add(stockMoveList[i]);
                                }
                            }
                        }
                        // ����Ώۂ́u��[�o�Ɂv1�F�I��L��
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            // �݌ɒ����f�[�^
                            ArrayList stockAdjustList = null;
                            // �݌ɒ����f�[�^���o����
                            Status = SearchStockAdjustProc(out stockAdjustList, cndtnWork, out errMessage, ref Connection, false);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockAdjustList != null && stockAdjustList.Count > 0)
                            {
                                for (int i = 0; i < stockAdjustList.Count; i++)
                                {
                                    RetList.Add(stockAdjustList[i]);
                                }
                            }
                        }
                        // ����Ώۂ́u�݌Ɏd���v1�F�I��L��
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            // �݌ɒ����f�[�^
                            ArrayList stockAdjustList = null;
                            // �݌ɒ����f�[�^���o����
                            Status = SearchStockAdjustProc(out stockAdjustList, cndtnWork, out errMessage, ref Connection, true);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockAdjustList != null && stockAdjustList.Count > 0)
                            {
                                for (int i = 0; i < stockAdjustList.Count; i++)
                                {
                                    RetList.Add(stockAdjustList[i]);
                                }
                            }
                        }
                    }
                    // �p�^�[��:�u���Ɍ��i�v�̃f�[�^���o
                    else if (cndtnWork.Pattern == 1)
                    {
                        // ����Ώۂ́u����v1�F�I��L�� �� ����Ώۂ́u�ݏo�v1�F�I��L��
                        if (cndtnWork.TransSales == 1 || cndtnWork.TransLend == 1)
                        {
                            // ����f�[�^
                            ArrayList salesList = null;
                            // ����f�[�^��������
                            Status = SearchProc(out salesList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (salesList != null && salesList.Count > 0)
                            {
                                for (int i = 0; i < salesList.Count; i++)
                                {
                                    RetList.Add(salesList[i]);
                                }
                            }
                        }
                        // ����Ώۂ́u�d���v1�F�I��L��
                        if (cndtnWork.TransStockSlip == 1)
                        {
                            // �d���f�[�^
                            ArrayList stockSlipList = null;
                            // �d���f�[�^���o����
                            Status = SearchStockSlipProc(out stockSlipList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockSlipList != null && stockSlipList.Count > 0)
                            {
                                for (int i = 0; i < stockSlipList.Count; i++)
                                {
                                    RetList.Add(stockSlipList[i]);
                                }
                            }
                        }
                        // ����Ώۂ́u�ړ����Ɂv1�F�I��L��
                        if (cndtnWork.TransMoveInWarehouse == 1)
                        {
                            // �݌Ɉړ��f�[�^
                            ArrayList stockMoveList = null;
                            // �݌Ɉړ��f�[�^���o����
                            Status = SearchStockMoveProc(out stockMoveList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockMoveList != null && stockMoveList.Count > 0)
                            {
                                for (int i = 0; i < stockMoveList.Count; i++)
                                {
                                    RetList.Add(stockMoveList[i]);
                                }
                            }
                        }
                        // ����Ώۂ́u�݌Ɏd���v1�F�I��L��
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            // �݌ɒ����f�[�^
                            ArrayList stockAdjustList = null;
                            // �݌ɒ����f�[�^���o����
                            Status = SearchStockAdjustProc(out stockAdjustList, cndtnWork, out errMessage, ref Connection, true);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockAdjustList != null && stockAdjustList.Count > 0)
                            {
                                for (int i = 0; i < stockAdjustList.Count; i++)
                                {
                                    RetList.Add(stockAdjustList[i]);
                                }
                            }
                        }
                    }
                    // �p�^�[��:�u�����Ɂv�̃f�[�^���o
                    else if (cndtnWork.Pattern == 2)
                    {
                        // ����Ώۂ́u�d���v1�F�I��L��
                        if (cndtnWork.TransStockSlip == 1)
                        {
                            // �d���f�[�^���o����
                            Status = SearchStockSlipProc(out RetList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                        }
                    }
                    // �p�^�[��:�u���i�̂݁v�̃f�[�^���o
                    else if (cndtnWork.Pattern == 3)
                    {
                        // ���i�̂݃f�[�^���o����
                        Status = SearchInspectProc(out RetList, cndtnWork, out errMessage, ref Connection);
                        if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                        {
                            return Status;
                        }
                    }
                    // ���i�Ɖ���f�[�^������
                    if (RetList != null && RetList.Count > 0)
                    {
                        Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    // --- ADD 3H ������ 2017/09/07----------<<<<<
                    
                    // �������ʂ̊i�[
                    inspectRefDataObj = RetList;
                }
                catch (Exception ex)
                {
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.Search Exception=" + ex.Message, Status);
                }
            }
            return Status;
        }
        #endregion

        #region ���i�K�C�h����
        /// <summary>
        /// ���i�K�C�h�f�[�^�̎擾����
        /// </summary>
        /// <param name="searchCondtObj">�����p�����[�^</param>
        /// <param name="inspectDataObj">���i�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�K�C�h�f�[�^���擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H ������</br>
        /// <br>�@�@�@�@�@ : ���i�Ɖ�̕ύX�Ή�</br>
        /// </remarks>
        public int SearchGuid(object searchCondtObj,out object inspectDataObj)
        {
            SqlConnection Connection = null;
            // ��������
            inspectDataObj = null;
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �R�l�N�V��������
            using (Connection = CreateSqlConnection(true))
            {
                try
                {
                    // ��������
                    HandyInspectDataWork cndtnWork = searchCondtObj as HandyInspectDataWork;
                    // ���i�f�[�^��������
                    // --- DEL 3H ������ 2017/09/07---------->>>>>
                    //Status = this.InspectDataObj.SearchProc(cndtnWork, out inspectDataObj, ref Connection);
                    // --- DEL 3H ������ 2017/09/07----------<<<<<
                    // --- ADD 3H ������ 2017/09/07---------->>>>>
                    Status = this.InspectDataObj.SearchGuidProc(cndtnWork, out inspectDataObj, ref Connection);
                    // --- ADD 3H ������ 2017/09/07----------<<<<<
                }
                catch (Exception ex)
                {
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchGuid Exception=" + ex.Message, Status);
                }
            }
            return Status;
        }
        #endregion

        #region [��������]
        /// <summary>
        /// �����f�[�^����
        /// </summary>
        /// <param name="deleteDataObj">��s���i�f�[�^�����폜�f�[�^</param>
        /// <param name="insertDataObj">���i�f�[�^</param>
        /// <param name="type">0:�蓮���i�f�[�^�o�^����,1:��s���i�����o�^����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����f�[�^�������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public int WriteInspectData(object deleteDataObj, object insertDataObj, int type)
        {
            SqlConnection Connection = null;
            SqlTransaction Transaction = null;
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �R�l�N�V��������
            using (Connection = CreateSqlConnection(true))
            {
                try
                {
                    // �g�����U�N�V�����J�n
                    Transaction = Connection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                    if (type == 0)
                    {
                        ArrayList insertDataList = insertDataObj as ArrayList;
                        // �蓮���i�f�[�^�o�^����
                        Status = this.InspectDataObj.WriteInspectDataProc(ref insertDataList, ref Connection, ref Transaction, type);
                    }
                    else
                    {
                        // �폜����
                        ArrayList deleteDataList = deleteDataObj as ArrayList;
                        // ��s���i�f�[�^�����폜����
                        Status = this.InspectDataObj.DeleteInspectData(ref deleteDataList, ref Connection, ref Transaction);
                        if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            ArrayList insertDataList = insertDataObj as ArrayList;
                            // �o�^����
                            Status = this.InspectDataObj.WriteInspectDataProc(ref insertDataList, ref Connection, ref Transaction, 0);
                        }
                    }

                    if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // �R�~�b�g
                        Transaction.Commit();
                    else
                    {
                        // ���[���o�b�N
                        if (Transaction.Connection != null) Transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.WriteInspectData Exception=" + ex.Message, Status);
                }
                finally
                {
                    if (Transaction != null) Transaction.Dispose();
                }
            }
            return Status;

        }
        #endregion

        // --- ADD ���O 2018/10/16 �n���f�B�^�[�~�i���܎��Ή�---------->>>>>
        #region [�폜����]
        /// <summary>
        /// ���i�f�[�^�폜����
        /// </summary>
        /// <param name="delInspectDataObj">���i�f�[�^</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�f�[�^�폜�������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2019/10/16</br>
        /// </remarks>
        public int DeleteInspectData(object delInspectDataObj, out string retMessage)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMessage = string.Empty;
            // �R�l�N�V��������
            using (connection = CreateSqlConnection(true))
            {
                try
                {
                    // �g�����U�N�V�����J�n
                    transaction = connection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    // �폜����
                    ArrayList deleteDataList = delInspectDataObj as ArrayList;
                    // ���i�f�[�^�����폜����
                    status = this.InspectDataObj.DeleteInspectData(ref deleteDataList, ref connection, ref transaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // �R�~�b�g
                        transaction.Commit();
                    else
                    {
                        // ���[���o�b�N
                        if (transaction.Connection != null) transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    retMessage = ex.Message;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.WriteInspectData Exception=" + retMessage, status);
                }
                finally
                {
                    if (transaction != null) transaction.Dispose();
                }
            }
            return status;

        }
        #endregion
        // --- ADD ���O 2018/10/16 �n���f�B�^�[�~�i���܎��Ή�----------<<<<<

        #region ����f�[�^����
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̌��i�Ɖ�f�[�^�̑S�Ė߂鏈��
        /// </summary>
        /// <param name="retList">�o�̓f�[�^</param>
        /// <param name="cndtnWork">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̌��i�Ɖ�f�[�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList,
            HandyInspectParamWork cndtnWork, out string errMessage, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = new ArrayList();
            errMessage = string.Empty;
            // ����f�[�^�ꎞ�e�[�u��
            string TableNameGuid = Guid.NewGuid().ToString();
            string TempTblName = "##SALES_" + TableNameGuid.Replace('-', '_');

            // ���㖾�׃f�[�^�ꎞ�e�[�u��
            TableNameGuid = Guid.NewGuid().ToString();
            string TempDtlName = "##SALESDTL_" + TableNameGuid.Replace('-', '_');
            try
            {
                // ����f�[�^�ꎞ�e�[�u���̍쐬
                Status = CreateSalesTempTbl(cndtnWork, TempTblName, ref sqlConnection);

                //  ���㖾�׃f�[�^�ꎞ�e�[�u���̍쐬
                if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && cndtnWork.Pattern == 1 && cndtnWork.TransLend ==1)
                {
                    // ���㖾�׃f�[�^�̌���
                    Status = CreateSalesDtlTempTbl(cndtnWork, TempDtlName, ref sqlConnection);
                }

                // ����f�[�^�̌���
                if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���o�Ɍ��i�f�[�^�̌���
                    Status = SearchSalesProc(out retList, cndtnWork, TempTblName, TempDtlName, out errMessage, ref sqlConnection);
                }
            }
            catch (Exception ex)
            {
                retList = new ArrayList();
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchProc Exception=" + ex.Message, Status);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                // ����f�[�^�ꎞ�e�[�u���̍폜
                this.DropTempTable(TempTblName, ref sqlConnection);
                // ���㖾�׃f�[�^�ꎞ�e�[�u���̍폜
                this.DropTempTable(TempDtlName, ref sqlConnection);
            }

            return Status;
        }
        #endregion

        #region �ꎞ�e�[�u���̍쐬
        /// <summary>
        /// ����f�[�^�̈ꎞ�e�[�u���̍쐬
        /// </summary>
        /// <param name="cndtnWork">��������</param>
        /// <param name="tempTblName">�ꎞ�e�[�u����</param>
        /// <param name="sqlConnection">�R�l�V�������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ����f�[�^�̈ꎞ�e�[�u���̍쐬���s��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/07/20</br>
        /// <br>Update Note : 2017/09/07 3H ������</br>
        /// <br>�@�@�@�@�@  : 11370074-00 �󒍃X�e�[�^�X�񋓑̑��x���P</br>
        /// </remarks>
        private int CreateSalesTempTbl(HandyInspectParamWork cndtnWork, string tempTblName, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand SqCommand = null;
            try
            {
                using (SqCommand = new SqlCommand("", sqlConnection))
                {
                    StringBuilder SqlText = new StringBuilder();

                    #region �N�G�����̍\�z
                    SqlText.AppendLine(" SELECT ");
                    SqlText.AppendLine(" SALES.ENTERPRISECODERF ");
                    SqlText.AppendLine(" ,SALES.RESULTSADDUPSECCDRF  ");    // ���㖾�׃f�[�^.���ьv�㋒�_�R�[�h
                    SqlText.AppendLine(" ,SALES.SALESSLIPNUMRF ");         // ���㖾�׃f�[�^.����`�[�ԍ�
                    SqlText.AppendLine(" ,SALES.SALESROWNORF ");           // ���㖾�׃f�[�^.�s�ԍ�
                    SqlText.AppendLine(" ,SALES.GOODSMAKERCDRF");         // ���㖾�׃f�[�^.���i���[�J�[�R�[�h
                    SqlText.AppendLine(" ,SALES.GOODSNORF");              // ���㖾�׃f�[�^.���i�ԍ�
                    SqlText.AppendLine(" ,SALES.SHIPMENTCNTRF ");           // ���㖾�׃f�[�^.�o�א�
                    SqlText.AppendLine(" ,SALES.CUSTOMERSNMRF");          // ���㖾�׃f�[�^.���Ӑ旪��
                    SqlText.AppendLine(" ,SALES.WAREHOUSECODERF");              // ���㖾�׃f�[�^.�q�ɃR�[�h
                    SqlText.AppendLine(" ,SALES.WAREHOUSENAMERF ");           // ���㖾�׃f�[�^.�q�ɖ���
                    SqlText.AppendLine(" ,SALES.WAREHOUSESHELFNORF");          // ���㖾�׃f�[�^.�q�ɒI��
                    SqlText.AppendLine(" ,SALES.SHIPMENTDAYRF ");           // ����f�[�^.�o�ד��t
                    SqlText.AppendLine(" ,SALES.ACPTANODRSTATUSRF");          // ���㖾�׃f�[�^.�󒍃X�e�[�^�X
                    SqlText.AppendLine(" ,SALES.LOGICALDELETECODERF");              // ���㖾�׃f�[�^.�_���폜�敪
                    SqlText.AppendLine(" ,SALES.SECTIONCODERF");              // ���㖾�׃f�[�^.���_�R�[�h
                    SqlText.AppendLine(" ,SALES.SALESSLIPDTLNUMRF ");           // ���㖾�׃f�[�^.���㖾�גʔ�
                    SqlText.AppendLine(" ,SALES.ACPTANODRSTATUSSRCRF");          // ���㖾�׃f�[�^.�󒍃X�e�[�^�X�i���j
                    SqlText.AppendLine(" ,SALES.SALESSLIPDTLNUMSRCRF");              // ���㖾�׃f�[�^.���㖾�גʔԁi���j
                    SqlText.AppendLine(" ,SALES.SALESSLIPCDDTLRF");          // ���㖾�׃f�[�^.����`�[�敪�i���ׁj
                    SqlText.AppendLine(" ,SALES.MAKERNAMERF");          // ���㖾�׃f�[�^.���[�J�[����
                    SqlText.AppendLine(" ,SALES.GOODSNAMERF");          // ���㖾�׃f�[�^.���i����
                    SqlText.AppendLine(" INTO " + tempTblName);
                    SqlText.AppendLine(" FROM ( ");
                    SqlText.AppendLine("  SELECT ");
                    SqlText.AppendLine(" SD.ENTERPRISECODERF ");
                    SqlText.AppendLine(" ,SL.RESULTSADDUPSECCDRF  ");    // ���㖾�׃f�[�^.���ьv�㋒�_�R�[�h
                    SqlText.AppendLine(" ,SD.SALESSLIPNUMRF ");         // ���㖾�׃f�[�^.����`�[�ԍ�
                    SqlText.AppendLine(" ,SD.SALESROWNORF ");           // ���㖾�׃f�[�^.�s�ԍ�
                    SqlText.AppendLine(" ,SD.GOODSMAKERCDRF");         // ���㖾�׃f�[�^.���i���[�J�[�R�[�h
                    SqlText.AppendLine(" ,SD.GOODSNORF");              // ���㖾�׃f�[�^.���i�ԍ�
                    SqlText.AppendLine(" ,SD.SHIPMENTCNTRF ");           // ���㖾�׃f�[�^.�o�א�
                    SqlText.AppendLine(" ,SL.CUSTOMERSNMRF");          // ���㖾�׃f�[�^.���Ӑ旪��
                    SqlText.AppendLine(" ,SD.WAREHOUSECODERF");              // ���㖾�׃f�[�^.�q�ɃR�[�h
                    SqlText.AppendLine(" ,SD.WAREHOUSENAMERF ");           // ���㖾�׃f�[�^.�q�ɖ���
                    SqlText.AppendLine(" ,SD.WAREHOUSESHELFNORF");          // ���㖾�׃f�[�^.�q�ɒI��
                    SqlText.AppendLine(" ,SL.SHIPMENTDAYRF ");           // ����f�[�^.�o�ד��t
                    SqlText.AppendLine(" ,SD.ACPTANODRSTATUSRF");          // ���㖾�׃f�[�^.�󒍃X�e�[�^�X
                    SqlText.AppendLine(" ,SD.LOGICALDELETECODERF");              // ���㖾�׃f�[�^.�_���폜�敪
                    SqlText.AppendLine(" ,SD.SECTIONCODERF");              // ���㖾�׃f�[�^.���_�R�[�h
                    SqlText.AppendLine(" ,SD.SALESSLIPDTLNUMRF ");           // ���㖾�׃f�[�^.���㖾�גʔ�
                    SqlText.AppendLine(" ,SD.ACPTANODRSTATUSSRCRF");          // ���㖾�׃f�[�^.�󒍃X�e�[�^�X�i���j
                    SqlText.AppendLine(" ,SD.SALESSLIPDTLNUMSRCRF");              // ���㖾�׃f�[�^.���㖾�גʔԁi���j
                    SqlText.AppendLine(" ,SD.SALESSLIPCDDTLRF");          // ���㖾�׃f�[�^.����`�[�敪�i���ׁj
                    SqlText.AppendLine(" ,SD.MAKERNAMERF");          // ���㖾�׃f�[�^.���[�J�[����
                    SqlText.AppendLine(" ,SD.GOODSNAMERF");          // ���㖾�׃f�[�^.���i����
                    // ���㖾�׃f�[�^
                    SqlText.AppendLine(" FROM SALESDETAILRF AS SD WITH (READUNCOMMITTED)");
                    // INNER JOIN ����f�[�^
                    SqlText.AppendLine(" INNER JOIN SALESSLIPRF AS SL WITH (READUNCOMMITTED)");
                    SqlText.AppendLine(" ON SL.ENTERPRISECODERF = SD.ENTERPRISECODERF");
                    SqlText.AppendLine(" AND SL.ACPTANODRSTATUSRF = SD.ACPTANODRSTATUSRF");
                    SqlText.AppendLine(" AND SL.SALESSLIPNUMRF = SD.SALESSLIPNUMRF");
                    SqlText.AppendLine(" AND SL.LOGICALDELETECODERF = SD.LOGICALDELETECODERF");

                    // WHERE��
                    SqlText.AppendLine(MakeWhereString(cndtnWork, ref SqCommand, 0));

                    SqlText.AppendLine(" ) AS SALES ");

                    #endregion

                    SqCommand.CommandText = SqlText.ToString();
                    SqCommand.CommandTimeout = 3600;
                    SqCommand.ExecuteNonQuery();

                    Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                Status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "HandyInspectRefDataDB.CreateSalesTempTbl Exception=" + ex.Message);
                Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return Status;
        }

        /// <summary>
        /// ���㖾�׃f�[�^�̈ꎞ�e�[�u���̍쐬
        /// </summary>
        /// <param name="cndtnWork">��������</param>
        /// <param name="tempDtlName">�ꎞ�e�[�u����</param>
        /// <param name="sqlConnection">�R�l�V�������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ���㖾�׃f�[�^�̈ꎞ�e�[�u���̍쐬���s��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/07/20</br>
        /// </remarks>
        private int CreateSalesDtlTempTbl(HandyInspectParamWork cndtnWork, string tempDtlName, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand SqlCommandInfo = null;
            try
            {
                using (SqlCommandInfo = new SqlCommand("", sqlConnection))
                {
                    StringBuilder SqlText = new StringBuilder();

                    #region �N�G�����̍\�z
                    SqlText.AppendLine(" SELECT ");
                    SqlText.AppendLine(" SDTL.ENTERPRISECODERF ");
                    SqlText.AppendLine(" ,SDTL.SALESSLIPNUMRF ");         // ���㖾�׃f�[�^.����`�[�ԍ�
                    SqlText.AppendLine(" ,SDTL.SALESROWNORF ");           // ���㖾�׃f�[�^.�s�ԍ�
                    SqlText.AppendLine(" ,SDTL.GOODSMAKERCDRF");         // ���㖾�׃f�[�^.���i���[�J�[�R�[�h
                    SqlText.AppendLine(" ,SDTL.GOODSNORF");              // ���㖾�׃f�[�^.���i�ԍ�
                    SqlText.AppendLine(" ,SDTL.SHIPMENTCNTRF ");           // ���㖾�׃f�[�^.�o�א�
                    SqlText.AppendLine(" ,SDTL.WAREHOUSECODERF");              // ���㖾�׃f�[�^.�q�ɃR�[�h
                    SqlText.AppendLine(" ,SDTL.WAREHOUSENAMERF ");           // ���㖾�׃f�[�^.�q�ɖ���
                    SqlText.AppendLine(" ,SDTL.WAREHOUSESHELFNORF");          // ���㖾�׃f�[�^.�q�ɒI��
                    SqlText.AppendLine(" ,SDTL.ACPTANODRSTATUSRF");          // ���㖾�׃f�[�^.�󒍃X�e�[�^�X
                    SqlText.AppendLine(" ,SDTL.LOGICALDELETECODERF");              // ���㖾�׃f�[�^.�_���폜�敪
                    SqlText.AppendLine(" ,SDTL.SECTIONCODERF");              // ���㖾�׃f�[�^.���_�R�[�h
                    SqlText.AppendLine(" ,SDTL.SALESSLIPDTLNUMRF ");           // ���㖾�׃f�[�^.���㖾�גʔ�
                    SqlText.AppendLine(" ,SDTL.ACPTANODRSTATUSSRCRF");          // ���㖾�׃f�[�^.�󒍃X�e�[�^�X�i���j
                    SqlText.AppendLine(" ,SDTL.SALESSLIPDTLNUMSRCRF");              // ���㖾�׃f�[�^.���㖾�גʔԁi���j
                    SqlText.AppendLine(" ,SDTL.SALESSLIPCDDTLRF");          // ���㖾�׃f�[�^.����`�[�敪�i���ׁj
                    SqlText.AppendLine(" ,SDTL.SALESDATERF");              // ���㖾�׃f�[�^.������t
                    SqlText.AppendLine(" ,SDTL.MAKERNAMERF");          // ���㖾�׃f�[�^.���[�J�[����
                    SqlText.AppendLine(" ,SDTL.GOODSNAMERF");          // ���㖾�׃f�[�^.���i����
                    SqlText.AppendLine(" INTO " + tempDtlName);
                    SqlText.AppendLine(" FROM ( ");
                    SqlText.AppendLine("  SELECT ");
                    SqlText.AppendLine(" SD.ENTERPRISECODERF ");
                    SqlText.AppendLine(" ,SD.SALESSLIPNUMRF ");         // ���㖾�׃f�[�^.����`�[�ԍ�
                    SqlText.AppendLine(" ,SD.SALESROWNORF ");           // ���㖾�׃f�[�^.�s�ԍ�
                    SqlText.AppendLine(" ,SD.GOODSMAKERCDRF");         // ���㖾�׃f�[�^.���i���[�J�[�R�[�h
                    SqlText.AppendLine(" ,SD.GOODSNORF");              // ���㖾�׃f�[�^.���i�ԍ�
                    SqlText.AppendLine(" ,SD.SHIPMENTCNTRF ");           // ���㖾�׃f�[�^.�o�א�
                    SqlText.AppendLine(" ,SD.WAREHOUSECODERF");              // ���㖾�׃f�[�^.�q�ɃR�[�h
                    SqlText.AppendLine(" ,SD.WAREHOUSENAMERF ");           // ���㖾�׃f�[�^.�q�ɖ���
                    SqlText.AppendLine(" ,SD.WAREHOUSESHELFNORF");          // ���㖾�׃f�[�^.�q�ɒI��
                    SqlText.AppendLine(" ,SD.ACPTANODRSTATUSRF");          // ���㖾�׃f�[�^.�󒍃X�e�[�^�X
                    SqlText.AppendLine(" ,SD.LOGICALDELETECODERF");              // ���㖾�׃f�[�^.�_���폜�敪
                    SqlText.AppendLine(" ,SD.SECTIONCODERF");              // ���㖾�׃f�[�^.���_�R�[�h
                    SqlText.AppendLine(" ,SD.SALESSLIPDTLNUMRF ");           // ���㖾�׃f�[�^.���㖾�גʔ�
                    SqlText.AppendLine(" ,SD.ACPTANODRSTATUSSRCRF");          // ���㖾�׃f�[�^.�󒍃X�e�[�^�X�i���j
                    SqlText.AppendLine(" ,SD.SALESSLIPDTLNUMSRCRF");              // ���㖾�׃f�[�^.���㖾�גʔԁi���j
                    SqlText.AppendLine(" ,SD.SALESSLIPCDDTLRF");          // ���㖾�׃f�[�^.����`�[�敪�i���ׁj
                    SqlText.AppendLine(" ,SD.SALESDATERF");              // ���㖾�׃f�[�^.������t
                    SqlText.AppendLine(" ,SD.MAKERNAMERF");          // ���㖾�׃f�[�^.���[�J�[����
                    SqlText.AppendLine(" ,SD.GOODSNAMERF");          // ���㖾�׃f�[�^.���i����
                    // ���㖾�׃f�[�^
                    SqlText.AppendLine(" FROM SALESDETAILRF AS SD WITH (READUNCOMMITTED)");
                    // WHERE��
                    SqlText.AppendLine(MakeWhereString(cndtnWork, ref SqlCommandInfo, 1));

                    SqlText.AppendLine(" ) AS SDTL ");

                    #endregion

                    SqlCommandInfo.CommandText = SqlText.ToString();
                    SqlCommandInfo.CommandTimeout = 3600;
                    SqlCommandInfo.ExecuteNonQuery();

                    Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                Status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectRefDataDB.CreateSalesDtlTempTbl Exception=" + ex.Message, Status);
            }

            return Status;
        }
        #endregion

        #region �ꎞ�e�[�u���̍폜
        /// <summary>
        /// �ꎞ�e�[�u���̍폜
        /// </summary>
        /// <param name="tempTblName">�ꎞ�e�[�u����</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �ꎞ�e�[�u���̍폜���s��</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note : 2017/09/07 3H ������</br>
        /// <br>�@�@�@�@�@  : 11370074-00 �ꎞ�e�[�u���𑶍݊m�F������DROP���Ă���s��Ή�</br>
        /// </remarks>
        private int DropTempTable(string tempTblName, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {
                    StringBuilder SqlText = new StringBuilder();

                    #region �N�G�����̍\�z
                    // --- UPD 3H ������ 2017/09/07---------->>>>>
                    //SqlText.AppendLine( " DROP TABLE " + tempTblName );
                    SqlText.AppendFormat( " IF OBJECT_ID(N'[tempdb].[dbo].{0}', N'U') IS NOT NULL " , tempTblName );
                    SqlText.AppendFormat( " BEGIN DROP TABLE {0} END " , tempTblName );
                    SqlText.AppendLine();
                    // --- UPD 3H ������ 2017/09/07----------<<<<<
                    #endregion

                    sqlCommand.CommandText = SqlText.ToString();

                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                Status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectRefDataDB.DropTempTable Exception=" + ex.Message, Status);
            }

            return Status;
        }
        #endregion

        #region �ꎞ�e�[�u����MakeWhereString
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="cndtnWork">���������i�[�N���X</param>
        /// <param name="sqlCommand">�R�}���h</param>
        /// <param name="type">0:���㕪�̃f�[�^���o�@1:���㖾�׃f�[�^���̃f�[�^���o</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Note       : �������������񐶐��{�����l�ݒ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private string MakeWhereString(HandyInspectParamWork cndtnWork, ref SqlCommand sqlCommand, int type)
        {
            StringBuilder SqlText = new StringBuilder();
            SqlText.AppendLine("WHERE ");

            // ���㕪�̃f�[�^���o
            if (type == 0)
            {
                // ��ƃR�[�h
                SqlText.AppendLine(" SL.ENTERPRISECODERF=@ENTERPRISECODE");
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

                //���_�R�[�h
                if (!String.IsNullOrEmpty(cndtnWork.SectionCode) && !"00".Equals(cndtnWork.SectionCode))
                {
                    SqlText.AppendLine(" AND SL.RESULTSADDUPSECCDRF=@FINDSECTIONCODE");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.SectionCode);
                }

                // �󒍃X�e�[�^�X
                if (cndtnWork.TransSales == 1 && cndtnWork.TransLend == 1)
                {
                    SqlText.AppendLine(" AND (SL.ACPTANODRSTATUSRF = " + RentStatus);
                    SqlText.AppendLine(" OR (SL.ACPTANODRSTATUSRF = " + SalesStatus);
                    // ���o�ד�(�J�n)
                    if (cndtnWork.St_SalesDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND SL.SHIPMENTDAYRF >= @SALESDATEST ");
                        SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                        paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
                    }
                    // ���o�ד�(�I��)
                    if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND SL.SHIPMENTDAYRF <= @SALESDATEED ");
                        SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                        paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
                    }
                    SqlText.AppendLine(" ))");
                }
                else if (cndtnWork.TransSales == 1)
                {
                    SqlText.AppendLine(" AND SL.ACPTANODRSTATUSRF = " + SalesStatus);
                    // ���o�ד�(�J�n)
                    if (cndtnWork.St_SalesDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND SL.SHIPMENTDAYRF >= @SALESDATEST ");
                        SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                        paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
                    }
                    // ���o�ד�(�I��)
                    if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND SL.SHIPMENTDAYRF <= @SALESDATEED ");
                        SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                        paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
                    }
                }
                else if (cndtnWork.TransLend == 1)
                {
                    SqlText.AppendLine(" AND SL.ACPTANODRSTATUSRF = " + RentStatus);
                }
                
                // �ԓ`�敪
                SqlText.AppendLine(" AND SL.DEBITNOTEDIVRF = @FINDDEBITNOTEDIV");
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@FINDDEBITNOTEDIV", SqlDbType.Int);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(Zero);
            }
            // ���㖾�׃f�[�^���̃f�[�^���o
            else
            {
                // ��ƃR�[�h
                SqlText.AppendLine(" SD.ENTERPRISECODERF=@ENTERPRISECODE");
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

                // �_���폜�敪
                SqlText.AppendLine(" AND SD.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

                // �󒍃X�e�[�^�X(��)
                SqlText.AppendLine(" AND SD.ACPTANODRSTATUSSRCRF = @FINDACPTANODRSTATUSSRC");
                SqlParameter paraAcptAnOdrStatusSrc = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUSSRC", SqlDbType.Int);
                paraAcptAnOdrStatusSrc.Value = SqlDataMediator.SqlSetInt32(RentStatus);

                // �󒍃X�e�[�^�X
                SqlText.AppendLine(" AND SD.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS");
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(SalesStatus);

                // �����(�J�n)
                if (cndtnWork.St_SalesDate > DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND SD.SALESDATERF >= @SALESDATEST ");
                    SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                    paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
                }
                // �����(�I��)
                if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND SD.SALESDATERF <= @SALESDATEED ");
                    SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                    paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
                }
            }

            //���i�ԍ�
            if (!String.IsNullOrEmpty(cndtnWork.GoodsNo))
            {
                SqlText.AppendLine(" AND SD.GOODSNORF LIKE @GOODSNO");
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                //�O����v�����̏ꍇ
                if (cndtnWork.GoodsNoSrchTyp == 1) cndtnWork.GoodsNo = cndtnWork.GoodsNo + "%";
                //�����v�����̏ꍇ
                if (cndtnWork.GoodsNoSrchTyp == 2) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo;
                //�����܂������̏ꍇ
                if (cndtnWork.GoodsNoSrchTyp == 3) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo + "%";
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(cndtnWork.GoodsNo);
            }

            // ���i���[�J�[�R�[�h
            if (cndtnWork.GoodsMakerCd > 0)
            {
                SqlText.AppendLine(" AND SD.GOODSMAKERCDRF=@FINDGOODSMAKERCD");
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(cndtnWork.GoodsMakerCd);
            }
            else 
            {
                SqlText.AppendLine(" AND SD.GOODSMAKERCDRF > " + Zero); 
            }

            // ���敪
            if (cndtnWork.OrderDivCd == 0)
            {
                if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                {
                    SqlText.AppendLine(" AND (SD.WAREHOUSECODERF=@FINDWAREHOUSECODE OR SD.WAREHOUSECODERF IS NULL)");
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                {
                    SqlText.AppendLine(" AND SD.WAREHOUSECODERF=@FINDWAREHOUSECODE");
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                }
                else
                {
                    SqlText.AppendLine(" AND SD.WAREHOUSECODERF IS NOT NULL ");
                }
            }

            return SqlText.ToString();
        }
        #endregion MakeWhereString

        #region ���o�׌��i�f�[�^�̌���
        /// <summary>
        /// ���o�׌��i�f�[�^�̌���
        /// </summary>
        /// <param name="retList">�o�̓f�[�^</param>
        /// <param name="cndtnWork">��������</param>
        /// <param name="tempTblName">����ꎞ�e�[�u����</param>
        /// <param name="tempDtlName">���㖾�׈ꎞ�e�[�u����</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���o�׌��i�f�[�^�̌������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private int SearchSalesProc(out ArrayList retList,
            HandyInspectParamWork cndtnWork, string tempTblName, string tempDtlName, out string errMessage, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            errMessage = string.Empty;
            SqlCommand SqlCommandInfo = null;
            retList = new ArrayList();

            using (SqlCommandInfo = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder SqlText = new StringBuilder();
                    SqlText.AppendLine(SalesSqlText(cndtnWork, tempTblName, tempDtlName, ref SqlCommandInfo));
                    SqlCommandInfo.CommandText = SqlText.ToString();

                    // �N�G�����s���̃^�C���A�E�g���Ԃ�3600�b�ɐݒ肷��
                    SqlCommandInfo.CommandTimeout = 3600;
                    using (SqlDataReader MyReader = SqlCommandInfo.ExecuteReader())
                    {
                        while (MyReader.Read())
                        {
                            // �������ʂ̊i�[
                            retList.Add(CopyDataFromReader(MyReader, cndtnWork));

                            Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    if (retList.Count == 0)
                    {
                        // �������ʂȂ��ꍇ�A�uNOT_FOUND�v��߂�
                        Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                }
                catch (SqlException ex)
                {
                    errMessage = ex.Message;
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    Status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    errMessage = ex.Message;
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchSalesProc Exception=" + ex.Message, Status);
                }
            }

            return Status;
        }

        /// <summary>
        /// ���o�׌��i�f�[�^�̌���
        /// </summary>
        /// <param name="cndtnWork">��������</param>
        /// <param name="tempTblName">����ꎞ�e�[�u����</param>
        /// <param name="tempDtlName">���㖾�׈ꎞ�e�[�u����</param>
        /// <param name="sqlCommand"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���o�׌��i�f�[�^�̌������s��</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note : 2017/09/07 3H ������</br>
        /// <br>�@�@�@�@�@  : 11370074-00 �o�Ɍ��i���ꂽ�ݏo�f�[�^��_���폜�i���ԕi�j���ꂽ�ꍇ�A�o�Ɍ��i�f�[�^��JOIN������Q�Ή�</br>
        /// </remarks>
        private string SalesSqlText(HandyInspectParamWork cndtnWork, string tempTblName, string tempDtlName, ref SqlCommand sqlCommand)
        {
            StringBuilder SqlText = new StringBuilder();

            SqlText.AppendLine(" SELECT ");
            SqlText.AppendLine(" SALES.SALESSLIPNUMRF ");   // �`�[�ԍ�
            SqlText.AppendLine(" ,SALES.SALESROWNORF");  // �s�ԍ�
            SqlText.AppendLine(" ,SALES.GOODSMAKERCDRF");         // ���i���[�J�[�R�[�h
            SqlText.AppendLine(" ,SALES.GOODSNORF");              // ���i�ԍ�
            SqlText.AppendLine(" ,SALES.MAKERNAMERF");          // ���[�J�[����
            SqlText.AppendLine(" ,SALES.GOODSNAMERF");          // ���i����

            // �u���Ɍ��i�v�̏ꍇ
            if (cndtnWork.Pattern == 1 && cndtnWork.TransLend == 1)
            {
                SqlText.AppendLine(" ,(CASE WHEN SALES.LOGICALDELETECODERF = 1 THEN DTL.SALESDATERF ELSE SALES.SHIPMENTDAYRF END) AS INPUTOUTDAYRF ");           //���o�ד�
                SqlText.AppendLine(" ,(CASE WHEN SALES.LOGICALDELETECODERF = 1 THEN (SALES.SHIPMENTCNTRF- DTL.SHIPMENTCNTRF) ELSE SALES.SHIPMENTCNTRF*(-1) END) AS INPUTCNTRF ");           //���ɐ�
            }
            //�u�o�Ɍ��i�v�̏ꍇ
            else
            {
                SqlText.AppendLine(" ,SALES.SHIPMENTDAYRF AS INPUTOUTDAYRF ");           //���o�ד�
                SqlText.AppendLine(" ,SALES.SHIPMENTCNTRF*(-1) AS INPUTCNTRF ");           //���ɐ�
            }
            SqlText.AppendLine(" ,SALES.SHIPMENTCNTRF AS SHIPMENTCNTRF ");           //�o�ɐ�
            SqlText.AppendLine(" ,SALES.CUSTOMERSNMRF  AS CUSTOMERSNM");          // ���Ӑ旪��
            SqlText.AppendLine(" ,SALES.WAREHOUSECODERF");              // �q�ɃR�[�h
            SqlText.AppendLine(" ,SALES.WAREHOUSENAMERF ");           // �q�ɖ���
            SqlText.AppendLine(" ,SALES.WAREHOUSESHELFNORF");          // �q�ɒI��
            SqlText.AppendLine(" ,SALES.LOGICALDELETECODERF  ");    // �_���폜�敪
            SqlText.AppendLine(" ,SALES.ACPTANODRSTATUSRF");          // �󒍃X�e�[�^�X
            SqlText.AppendLine(" ,SALES.SALESSLIPCDDTLRF");          // ����`�[�敪�i���ׁj
            SqlText.AppendLine(" ,I.ACPAYSLIPCDRF");          // �󕥌��`�[�敪
            SqlText.AppendLine(" ,I.ACPAYTRANSCDRF");          // �󕥌�����敪
            SqlText.AppendLine(" ,I.INSPECTSTATUSRF");          // ���i�X�e�[�^�X
            SqlText.AppendLine(" ,I.HANDTERMINALCODERF");          // �n���f�B�^�[�~�i���敪
            SqlText.AppendLine(" ,I.INSPECTDATETIMERF ");   // ���i����
            SqlText.AppendLine(" ,I.EMPLOYEECODERF ");   // �]�ƈ��R�[�h

            SqlText.AppendLine(" FROM " + tempTblName + " AS SALES WITH (READUNCOMMITTED) ");
            // �u���Ɍ��i�v�̏ꍇ
            if (cndtnWork.Pattern == 1 && cndtnWork.TransLend == 1)
            {
                SqlText.AppendLine(" LEFT JOIN " + tempDtlName + " AS DTL WITH (READUNCOMMITTED)");
                SqlText.AppendLine(" ON DTL.ENTERPRISECODERF = SALES.ENTERPRISECODERF");
                SqlText.AppendLine(" AND DTL.ACPTANODRSTATUSSRCRF = SALES.ACPTANODRSTATUSRF");
                SqlText.AppendLine(" AND DTL.SALESSLIPDTLNUMSRCRF = SALES.SALESSLIPDTLNUMRF");
            }
            SqlText.AppendLine(" LEFT JOIN INSPECTDATARF AS I WITH (READUNCOMMITTED)");
            SqlText.AppendLine(" ON SALES.ENTERPRISECODERF = I.ENTERPRISECODERF");
            SqlText.AppendLine(" AND SALES.SALESSLIPNUMRF = I.ACPAYSLIPNUMRF");
            SqlText.AppendLine(" AND SALES.SALESROWNORF = I.ACPAYSLIPROWNORF");
            SqlText.AppendLine(" AND ((SALES.ACPTANODRSTATUSRF = " + SalesStatus);
            SqlText.AppendLine(" AND I.ACPAYSLIPCDRF = " + SalesAcPaySlipCd + ")");
            SqlText.AppendLine(" OR (SALES.ACPTANODRSTATUSRF = " + RentStatus);
            // --- UPD 3H ������ 2017/09/07---------->>>>>
            //SqlText.AppendLine( " AND I.ACPAYSLIPCDRF = " + ShipmSlipCd + "))" );
            SqlText.AppendFormat( " AND I.ACPAYSLIPCDRF = {0}", HandyInspectRefDataDB.ShipmSlipCd );
            int acPayTransCd = 10; //�ʏ�`�[
            if (cndtnWork.Pattern == 1 && cndtnWork.TransLend == 1)
            {
                acPayTransCd = 11; //�ԕi
            }
            SqlText.AppendFormat( " AND I.ACPAYTRANSCDRF = {0}", acPayTransCd );
            SqlText.AppendLine( " ))" );
            // --- UPD 3H ������ 2017/09/07---------->>>>>
            SqlText.AppendLine(" AND I.LOGICALDELETECODERF = " + (Int32)ConstantManagement.LogicalMode.GetData0);

            // WHERE��
            SqlText.AppendLine("WHERE ");

            // ��ƃR�[�h
            SqlText.AppendLine(" SALES.ENTERPRISECODERF=@ENTERPRISECODE");

            // �]�ƈ��R�[�h
            if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
            {
                SqlText.AppendLine(" AND I.EMPLOYEECODERF = @FINDGEMPLOYEECODE");
            }
            // ���i��(�J�n)
            if (cndtnWork.St_InspectDate > DateTime.MinValue)
            {
                SqlText.AppendLine(" AND I.INSPECTDATETIMERF >= @INSPECTDATETIMEST ");
            }
            // ���i��(�I��)
            if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
            {
                if (cndtnWork.St_InspectDate == DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND (I.INSPECTDATETIMERF < @INSPECTDATETIMEED OR I.INSPECTDATETIMERF IS NULL)");
                }
                else
                {
                    SqlText.AppendLine(" AND  I.INSPECTDATETIMERF < @INSPECTDATETIMEED ");
                }
            }
           
            // �o�Ɍ��i
            if (cndtnWork.Pattern ==0)
            {
                // �_���폜�敪
                SqlText.AppendLine(" AND SALES.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
                SqlParameter ParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                ParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

                // ���o�ד�(�J�n)
                if (cndtnWork.St_SalesDate > DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND SALES.SHIPMENTDAYRF >= @SHIPMENTDAYST ");
                }
                // ���o�ד�(�I��)
                if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND SALES.SHIPMENTDAYRF <= @SHIPMENTDAYED");
                }

                // �o�א�
                SqlText.AppendLine(" AND SALES.SHIPMENTCNTRF > @FINDSHIPMENTCNT");
                if (cndtnWork.TransSales == 1 && cndtnWork.TransLend == 1)
                {
                    // �󒍃X�e�[�^�X
                    SqlText.AppendLine(" AND (SALES.ACPTANODRSTATUSRF = " + SalesStatus + " OR SALES.ACPTANODRSTATUSRF = " + RentStatus + " )");
                }
                else if (cndtnWork.TransSales == 1)
                { 
                    // �󒍃X�e�[�^�X
                    SqlText.AppendLine(" AND SALES.ACPTANODRSTATUSRF = " + SalesStatus );
                }
                else if (cndtnWork.TransLend == 1)
                {
                    // �󒍃X�e�[�^�X
                    SqlText.AppendLine(" AND SALES.ACPTANODRSTATUSRF = " + RentStatus);
                }
                // ����`�[�敪�i���ׁj
                SqlText.AppendLine(" AND SALES.SALESSLIPCDDTLRF = @FINDSALESSLIPCDDTL" );
                SqlParameter ParaSalesSlipCdDtl = sqlCommand.Parameters.Add("@FINDSALESSLIPCDDTL", SqlDbType.Int);
                ParaSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(SalesSlipCdDtl);
                // �󒍃X�e�[�^�X(��)
                SqlText.AppendLine(" AND SALES.ACPTANODRSTATUSSRCRF <> @FINDACPTANODRSTATUSSRC");
                SqlParameter ParaAcptAnOdrStatusSrc = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUSSRC", SqlDbType.Int);
                ParaAcptAnOdrStatusSrc.Value = SqlDataMediator.SqlSetInt32(RentStatus);
                SqlText.AppendLine("  ORDER BY INPUTOUTDAYRF, SALES.GOODSMAKERCDRF, SALES.GOODSNORF, SALES.SALESSLIPNUMRF, SALESROWNORF ASC");
            }
            // ���Ɍ��i
            else if (cndtnWork.Pattern == 1)
            {
                // �_���폜�敪
                SqlText.AppendLine(" AND SALES.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

                // ���o�ד�(�J�n)
                if (cndtnWork.St_SalesDate > DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND SALES.SHIPMENTDAYRF >= @SHIPMENTDAYST ");
                }
                // ���o�ד�(�I��)
                if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND SALES.SHIPMENTDAYRF <= @SHIPMENTDAYED");
                }
                // �o�א�
                SqlText.AppendLine(" AND SALES.SHIPMENTCNTRF*(-1) > @FINDSHIPMENTCNT");
                // �󒍃X�e�[�^�X
                SqlText.AppendLine(" AND (SALES.ACPTANODRSTATUSRF = " + SalesStatus + " OR SALES.ACPTANODRSTATUSRF = " + RentStatus + " )");
                // ����`�[�敪�i���ׁj
                SqlText.AppendLine(" AND SALES.SALESSLIPCDDTLRF = @FINDRETSLIPCDDTL");
                SqlParameter findParaRetSlipCdDtl = sqlCommand.Parameters.Add("@FINDRETSLIPCDDTL", SqlDbType.Int);
                findParaRetSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(RetSlipCdDtl);
                if (cndtnWork.TransLend == 1)
                {
                    SqlText.AppendLine("UNION ");
                    SqlText.AppendLine(" SELECT ");
                    SqlText.AppendLine(" SALES.SALESSLIPNUMRF ");   // �`�[�ԍ�
                    SqlText.AppendLine(" ,SALES.SALESROWNORF");  // �s�ԍ�
                    SqlText.AppendLine(" ,SALES.GOODSMAKERCDRF");         // ���i���[�J�[�R�[�h
                    SqlText.AppendLine(" ,SALES.GOODSNORF");              // ���i�ԍ�
                    SqlText.AppendLine(" ,SALES.MAKERNAMERF");          // ���[�J�[����
                    SqlText.AppendLine(" ,SALES.GOODSNAMERF");          // ���i����
                    SqlText.AppendLine(" ,(CASE WHEN SALES.LOGICALDELETECODERF = 1 THEN DTL.SALESDATERF ELSE SALES.SHIPMENTDAYRF END) AS INPUTOUTDAYRF ");           //���o�ד�
                    SqlText.AppendLine(" ,(CASE WHEN SALES.LOGICALDELETECODERF = 1 THEN (SALES.SHIPMENTCNTRF- DTL.SHIPMENTCNTRF) ELSE SALES.SHIPMENTCNTRF*(-1) END) AS INPUTCNTRF ");           //���ɐ�
                    SqlText.AppendLine(" ,SALES.SHIPMENTCNTRF ");           //�o�ɐ�
                    SqlText.AppendLine(" ,SALES.CUSTOMERSNMRF AS CUSTOMERSNM");          // ���Ӑ旪��
                    SqlText.AppendLine(" ,SALES.WAREHOUSECODERF");              // �q�ɃR�[�h
                    SqlText.AppendLine(" ,SALES.WAREHOUSENAMERF ");           // �q�ɖ���
                    SqlText.AppendLine(" ,SALES.WAREHOUSESHELFNORF");          // �q�ɒI��
                    SqlText.AppendLine(" ,SALES.LOGICALDELETECODERF  ");    // �_���폜�敪
                    SqlText.AppendLine(" ,SALES.ACPTANODRSTATUSRF");          // �󒍃X�e�[�^�X
                    SqlText.AppendLine(" ,SALES.SALESSLIPCDDTLRF");          // ����`�[�敪�i���ׁj
                    SqlText.AppendLine(" ,I.ACPAYSLIPCDRF");          // �󕥌��`�[�敪
                    SqlText.AppendLine(" ,I.ACPAYTRANSCDRF");          // �󕥌�����敪
                    SqlText.AppendLine(" ,I.INSPECTSTATUSRF");          // ���i�X�e�[�^�X
                    SqlText.AppendLine(" ,I.HANDTERMINALCODERF");          // �n���f�B�^�[�~�i���敪
                    SqlText.AppendLine(" ,I.INSPECTDATETIMERF ");   // ���i����
                    SqlText.AppendLine(" ,I.EMPLOYEECODERF ");   // �]�ƈ��R�[�h
                    SqlText.AppendLine(" FROM " + tempTblName + " AS SALES WITH (READUNCOMMITTED) ");
                    SqlText.AppendLine(" LEFT JOIN " + tempDtlName + " AS DTL WITH (READUNCOMMITTED)");
                    SqlText.AppendLine(" ON DTL.ENTERPRISECODERF = SALES.ENTERPRISECODERF");
                    SqlText.AppendLine(" AND DTL.ACPTANODRSTATUSSRCRF = SALES.ACPTANODRSTATUSRF");
                    SqlText.AppendLine(" AND DTL.SALESSLIPDTLNUMSRCRF = SALES.SALESSLIPDTLNUMRF");
                    // ���i�f�[�^
                    SqlText.AppendLine(" LEFT JOIN INSPECTDATARF AS I WITH (READUNCOMMITTED)");
                    SqlText.AppendLine(" ON SALES.ENTERPRISECODERF = I.ENTERPRISECODERF");
                    SqlText.AppendLine(" AND SALES.SALESSLIPNUMRF = I.ACPAYSLIPNUMRF");
                    SqlText.AppendLine(" AND SALES.SALESROWNORF = I.ACPAYSLIPROWNORF");
                    SqlText.AppendLine(" AND ((SALES.ACPTANODRSTATUSRF = " + SalesStatus);
                    SqlText.AppendLine(" AND I.ACPAYSLIPCDRF = " + SalesAcPaySlipCd + ")");
                    SqlText.AppendLine(" OR (SALES.ACPTANODRSTATUSRF = " + RentStatus);
                    // --- UPD 3H ������ 2017/09/07---------->>>>>
                    //SqlText.AppendLine( " AND I.ACPAYSLIPCDRF = " + ShipmSlipCd + "))" );
                    SqlText.AppendFormat( " AND I.ACPAYSLIPCDRF = {0}", HandyInspectRefDataDB.ShipmSlipCd );
                    acPayTransCd = 11; //�ԕi
                    SqlText.AppendFormat( " AND I.ACPAYTRANSCDRF = {0}", acPayTransCd );
                    SqlText.AppendLine( " ))" );
                    // --- UPD 3H ������ 2017/09/07---------->>>>>
                    SqlText.AppendLine( " AND I.LOGICALDELETECODERF = " + (Int32)ConstantManagement.LogicalMode.GetData0 );

                    // WHERE��
                    SqlText.AppendLine("WHERE ");
                    // ��ƃR�[�h
                    SqlText.AppendLine(" SALES.ENTERPRISECODERF=@ENTERPRISECODE");

                    // �]�ƈ��R�[�h
                    if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
                    {
                        SqlText.AppendLine(" AND I.EMPLOYEECODERF = @FINDGEMPLOYEECODE");
                    }
                    // ���i��(�J�n)
                    if (cndtnWork.St_InspectDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND I.INSPECTDATETIMERF >= @INSPECTDATETIMEST ");
                    }
                    // ���i��(�I��)
                    if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
                    {
                        if (cndtnWork.St_InspectDate == DateTime.MinValue)
                        {
                            SqlText.AppendLine(" AND (I.INSPECTDATETIMERF < @INSPECTDATETIMEED OR I.INSPECTDATETIMERF IS NULL)");
                        }
                        else
                        {
                            SqlText.AppendLine(" AND  I.INSPECTDATETIMERF < @INSPECTDATETIMEED ");
                        }
                    }
                    // �_���폜�敪:1
                    SqlText.AppendLine(" AND SALES.LOGICALDELETECODERF=@FINDLOGICALDELETECD");
                    SqlParameter ParaLogicalDeleteCd = sqlCommand.Parameters.Add("@FINDLOGICALDELETECD", SqlDbType.Int);
                    ParaLogicalDeleteCd.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData1);

                    // �����(�J�n)
                    if (cndtnWork.St_SalesDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND DTL.SALESDATERF >= @SHIPMENTDAYST ");
                    }
                    // �����(�I��)
                    if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND DTL.SALESDATERF <= @SHIPMENTDAYED");
                    }

                    // �󒍃X�e�[�^�X
                    SqlText.AppendLine(" AND SALES.ACPTANODRSTATUSRF = @ACPTANODRSTATUS");
                    SqlParameter ParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    ParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(RentStatus);
                    // ����`�[�敪�i���ׁj
                    SqlText.AppendLine(" AND SALES.SALESSLIPCDDTLRF = @FINDSALESSLIPCDDTL");
                    SqlParameter ParaSalesSlipCdDtl = sqlCommand.Parameters.Add("@FINDSALESSLIPCDDTL", SqlDbType.Int);
                    ParaSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(SalesSlipCdDtl);

                    // �o�א�
                    SqlText.AppendLine(" AND (SALES.SHIPMENTCNTRF -DTL.SHIPMENTCNTRF) > @FINDSHIPMENTCNT");

                    // �ݏo�v�㎞�ɍ폜���ꂽ�ݏo�f�[�^���̎擾�N�G���̒ǉ�
                    SqlText.AppendLine( "" );
                    SqlText.AppendLine( "UNION " );
                    SqlText.AppendLine( this.CreateGetDelRentDataQuery( cndtnWork, ref sqlCommand ) );
                }
                SqlText.AppendLine("  ORDER BY INPUTOUTDAYRF, SALES.GOODSMAKERCDRF, SALES.GOODSNORF, SALES.SALESSLIPNUMRF, SALESROWNORF ASC");
                
            }

            // ��ƃR�[�h
            SqlParameter ParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            ParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

            // �]�ƈ��R�[�h
            if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
            {
                SqlParameter ParaEmployeeCode = sqlCommand.Parameters.Add("@FINDGEMPLOYEECODE", SqlDbType.NChar);
                ParaEmployeeCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EmployeeCode);
            }
            // ���i��(�J�n)
            if (cndtnWork.St_InspectDate > DateTime.MinValue)
            {
                SqlParameter ParaInspectDateTimeSt = sqlCommand.Parameters.Add("@INSPECTDATETIMEST", SqlDbType.BigInt);
                ParaInspectDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.St_InspectDate);
            }
            // ���i��(�I��)
            if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
            {
                SqlParameter ParaInspectDateTimeEd = sqlCommand.Parameters.Add("@INSPECTDATETIMEED", SqlDbType.BigInt);
                ParaInspectDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.Ed_InspectDate);
            }
           
            // �o�א�
            SqlParameter ParaShipmentCnt = sqlCommand.Parameters.Add("@FINDSHIPMENTCNT", SqlDbType.Float);
            ParaShipmentCnt.Value = SqlDataMediator.SqlSetDouble(Zero);

            // ���o�ד�(�J�n)
            if (cndtnWork.St_SalesDate > DateTime.MinValue)
            {
                SqlParameter ParaShipmentDaySt = sqlCommand.Parameters.Add("@SHIPMENTDAYST", SqlDbType.Int);
                ParaShipmentDaySt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
            }
            // ���o�ד�(�I��)
            if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
            {
                SqlParameter ParaShipmentDayEd = sqlCommand.Parameters.Add("@SHIPMENTDAYED", SqlDbType.Int);
                ParaShipmentDayEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
            }
            return SqlText.ToString();
        }

        /// <summary>
        /// �ݏo�v�㎞�ɍ폜���ꂽ�ݏo�f�[�^���̎擾�N�G��������
        /// </summary>
        /// <param name="cndtnWork">��������</param>
        /// <param name="sqlCommand">�p�����[�^�Z�b�g��SQL���s�R�}���h�i�[�N���X</param>
        /// <returns>�ݏo�v�㎞�ɍ폜���ꂽ�ݏo�f�[�^���̎擾�N�G����</returns>
        /// <remarks>
        /// <br>Note       : �ݏo�v�㎞�ɍ폜���ꂽ�ݏo�f�[�^���̎擾�N�G�����𐶐�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note : 2017/09/07 3H ������</br>
        /// <br>�@�@�@�@�@  : 11370074-00 �ݏo�v�コ�ꂸ�ɍ폜���ꂽ�ݏo�f�[�^���܂߂�d�l�ύX�Ή�</br>
        /// <br>�@�@�@�@�@                �o�Ɍ��i���ꂽ�ݏo�f�[�^��_���폜�i���ԕi�j���ꂽ�ꍇ�A�o�Ɍ��i�f�[�^��JOIN������Q�Ή�</br>
        /// </remarks>
        private string CreateGetDelRentDataQuery( HandyInspectParamWork cndtnWork, ref SqlCommand sqlCommand )
        {
            StringBuilder sqlTextStrings = new StringBuilder();

            #region SELECT��
            sqlTextStrings.AppendLine("SELECT ");
            sqlTextStrings.AppendLine("   RentSS.SALESSLIPNUMRF ");
            sqlTextStrings.AppendLine(" , RentSD.SALESROWNORF ");
            sqlTextStrings.AppendLine(" , RentSD.GOODSMAKERCDRF ");
            sqlTextStrings.AppendLine(" , RentSD.GOODSNORF ");
            sqlTextStrings.AppendLine(" , RentSD.MAKERNAMERF ");
            sqlTextStrings.AppendLine(" , RentSD.GOODSNAMERF ");
            sqlTextStrings.AppendLine(" , RentSS.SALESDTLSALESDATE AS INPUTOUTDAYRF --���ɓ� ");
            sqlTextStrings.AppendLine(" , CASE ");
            sqlTextStrings.AppendLine("     WHEN SalesSD.SHIPMENTCNTRF is null THEN RentSD.SHIPMENTCNTRF ");
            sqlTextStrings.AppendLine("     ELSE                                    RentSD.SHIPMENTCNTRF - SalesSD.SHIPMENTCNTRF ");
            sqlTextStrings.AppendLine("   END AS INPUTCNTRF  --���ɐ� ");
            sqlTextStrings.AppendLine(" , 0 AS SHIPMENTCNTRF --�o�ɐ� ");
            sqlTextStrings.AppendLine(" , RentSS.CUSTOMERSNMRF AS CUSTOMERSNM ");
            sqlTextStrings.AppendLine(" , RentSD.WAREHOUSECODERF ");
            sqlTextStrings.AppendLine(" , RentSD.WAREHOUSENAMERF ");
            sqlTextStrings.AppendLine(" , RentSD.WAREHOUSESHELFNORF " );
            sqlTextStrings.AppendLine(" , RentSS.LOGICALDELETECODERF ");
            sqlTextStrings.AppendLine(" , RentSS.ACPTANODRSTATUSRF ");
            sqlTextStrings.AppendLine(" , RentSD.SALESSLIPCDDTLRF ");
            sqlTextStrings.AppendLine(" , InspDT.ACPAYSLIPCDRF      -- ���i�f�[�^ �󕥌��`�[�敪 ");
            sqlTextStrings.AppendLine(" , InspDT.ACPAYTRANSCDRF     -- ���i�f�[�^ �󕥌�����敪 ");
            sqlTextStrings.AppendLine(" , InspDT.INSPECTSTATUSRF    -- ���i�f�[�^ ���i�X�e�[�^�X ");
            sqlTextStrings.AppendLine(" , InspDT.HANDTERMINALCODERF -- ���i�f�[�^ �n���f�B�^�[�~�i���敪 ");
            sqlTextStrings.AppendLine(" , InspDT.INSPECTDATETIMERF  -- ���i�f�[�^ ���i���� ");
            sqlTextStrings.AppendLine(" , InspDT.EMPLOYEECODERF     -- ���i�f�[�^ �]�ƈ��R�[�h ");
            #endregion //SELECT��

            #region FROM��

            #region �ݏo�v�㎞�Ɍv�コ��Ȃ������폜�ϑݏo�f�[�^
            sqlTextStrings.AppendLine("FROM ( ");
            CreateGetDelRentSlipQuery( cndtnWork, ref sqlTextStrings, ref sqlCommand, "    " );
            // --- ADD 3H ������ 2017/09/07---------->>>>>
            sqlTextStrings.AppendLine( "    UNION" );
            this.CreateGetLogicalDelRentSlipQuery( cndtnWork, ref sqlTextStrings, ref sqlCommand, "    " );
            // --- ADD 3H ������ 2017/09/07----------<<<<<
            sqlTextStrings.AppendLine( "	) AS RentSS " );
            #endregion //�ݏo�v�㎞�Ɍv�コ��Ȃ������폜�ϑݏo�f�[�^
            
            #region �ݏo�v�㎞�Ɍv�コ��Ȃ��������̍폜�ϑݏo���׃f�[�^
            sqlTextStrings.AppendLine("INNER JOIN SALESDETAILRF AS RentSD WITH (READUNCOMMITTED) ON ");
            sqlTextStrings.AppendLine("	        RentSS.ENTERPRISECODERF = RentSD.ENTERPRISECODERF ");
            sqlTextStrings.AppendLine("		AND RentSD.ACPTANODRSTATUSRF = RentSS.ACPTANODRSTATUSRF ");
            sqlTextStrings.AppendLine("		AND RentSS.SALESSLIPNUMRF = RentSD.SALESSLIPNUMRF ");
            sqlTextStrings.AppendLine("		AND	RentSD.LOGICALDELETECODERF = 1 ");
            #endregion //�ݏo�v�㎞�Ɍv�コ��Ȃ��������̍폜�ϑݏo���׃f�[�^
            
            #region �ݏo�v�㎞�Ɍv�コ�ꂽ���̔��㖾�׃f�[�^
            sqlTextStrings.AppendLine("LEFT JOIN SALESDETAILRF AS SalesSD WITH (READUNCOMMITTED) ON "); 
            sqlTextStrings.AppendLine("	        SalesSD.ENTERPRISECODERF = RentSD.ENTERPRISECODERF ");
            sqlTextStrings.AppendLine("	    AND SalesSD.ACPTANODRSTATUSRF = 30 ");
            sqlTextStrings.AppendLine("		AND SalesSD.SALESSLIPDTLNUMSRCRF = RentSD.SALESSLIPDTLNUMRF ");
            sqlTextStrings.AppendLine("		AND SalesSD.ACPTANODRSTATUSSRCRF = RentSD.ACPTANODRSTATUSRF ");
            sqlTextStrings.AppendLine("		AND SalesSD.LOGICALDELETECODERF = 0 ");
            #endregion //�ݏo�v�㎞�Ɍv�コ�ꂽ���̔��㖾�׃f�[�^

            #region ���i�f�[�^
            sqlTextStrings.AppendLine("LEFT JOIN INSPECTDATARF AS InspDT WITH (READUNCOMMITTED) ON ");
            sqlTextStrings.AppendLine("	        InspDT.ENTERPRISECODERF = RentSS.ENTERPRISECODERF ");
            sqlTextStrings.AppendLine("	    AND InspDT.ACPAYSLIPNUMRF = RentSS.SALESSLIPNUMRF ");
            sqlTextStrings.AppendLine("	    AND InspDT.ACPAYSLIPROWNORF = RentSD.SALESROWNORF ");
            sqlTextStrings.AppendLine("	    AND RentSS.ACPTANODRSTATUSRF = RentSD.ACPTANODRSTATUSRF ");
            sqlTextStrings.AppendLine("		AND InspDT.ACPAYSLIPCDRF = 22 ");
            // --- ADD 3H ������ 2017/09/07---------->>>>>
            sqlTextStrings.AppendLine( "     AND InspDT.ACPAYTRANSCDRF = 11 " );
            // --- ADD 3H ������ 2017/09/07----------<<<<<
            sqlTextStrings.AppendLine( "     AND InspDT.LOGICALDELETECODERF = 0 " );
            #endregion //���i�f�[�^

            #endregion //FROM��

            #region WHERE��
            this.CreateGetDelRentDataWhere( cndtnWork, ref sqlTextStrings, ref sqlCommand, string.Empty );
            #endregion //WHERE��

            return sqlTextStrings.ToString();
        }

        /// <summary>
        /// �ݏo�v�㎞�Ɍv�コ��Ȃ������폜�ϑݏo�f�[�^�擾����������
        /// </summary>
        /// <param name="cndtnWork">��������</param>
        /// <param name="sqlTextStrings">�����������̊i�[��</param>
        /// <param name="sqlCommand">�p�����[�^�Z�b�g��SQL���s�R�}���h�i�[�N���X</param>
        /// <param name="prefixString">�e�s�̃C���f���g������</param>
        /// <remarks>
        /// <br>Note       : �ݏo�v�㎞�Ɍv�コ��Ȃ������폜�ϑݏo�f�[�^�擾�������𐶐����i�[��֊i�[����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void CreateGetDelRentDataWhere( HandyInspectParamWork cndtnWork, ref StringBuilder sqlTextStrings, ref SqlCommand sqlCommand, string prefixString )
        {
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "WHERE  " );

            #region ��ƃR�[�h
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "     RentSS.ENTERPRISECODERF = @ENTERPRISECODE " );
            #endregion //��ƃR�[�h

            #region �󒍃X�e�[�^�X
            //�ݏo�f�[�^���擾����̂�40�Œ�
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( " AND RentSS.ACPTANODRSTATUSRF = 40 " );
            #endregion //�󒍃X�e�[�^�X

            #region ����`�[�敪
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( " AND RentSD.SALESSLIPCDDTLRF = @FINDSALESSLIPCDDTL " );
            #endregion //����`�[�敪

            #region ���i�Ώې�
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( " AND CASE " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "         WHEN SalesSD.SHIPMENTCNTRF IS NULL THEN RentSD.SHIPMENTCNTRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "         ELSE                                    RentSD.SHIPMENTCNTRF - SalesSD.SHIPMENTCNTRF  " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    END > @FINDSHIPMENTCNT" );
            sqlTextStrings.Append( prefixString );
            #endregion //���i�Ώې�

            #region �ݏo�v��Ώۍs����
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( " AND SalesSD.ENTERPRISECODERF IS NULL " );
            #endregion //�ݏo�v��Ώۍs����

            #region ���ד�
            //�ݏo�v�㔄��f�[�^�̔��������ד��Ƃ��Ĉ���
            if (cndtnWork.St_SalesDate > DateTime.MinValue)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSS.SALESDTLSALESDATE >= @SHIPMENTDAYST " );
            }
            if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSS.SALESDTLSALESDATE <= @SHIPMENTDAYED " );
            }
            #endregion //���ד�

            #region ���ьv�㋒�_�R�[�h
            if (!String.IsNullOrEmpty( cndtnWork.SectionCode ) && !"00".Equals( cndtnWork.SectionCode ))
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSS.RESULTSADDUPSECCDRF=@FINDSECTIONCODE" );
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add( "@FINDSECTIONCODE", SqlDbType.NChar );
                findParaSectionCode.Value = SqlDataMediator.SqlSetString( cndtnWork.SectionCode );
            }
            #endregion //���ьv�㋒�_�R�[�h

            #region ���i�ԍ�
            if (!String.IsNullOrEmpty( cndtnWork.GoodsNo ))
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSD.GOODSNORF LIKE @GOODSNO" );
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add( "@GOODSNO", SqlDbType.NChar );
                //�O����v�����̏ꍇ
                if (cndtnWork.GoodsNoSrchTyp == 1) cndtnWork.GoodsNo = cndtnWork.GoodsNo + "%";
                //�����v�����̏ꍇ
                if (cndtnWork.GoodsNoSrchTyp == 2) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo;
                //�����܂������̏ꍇ
                if (cndtnWork.GoodsNoSrchTyp == 3) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo + "%";
                paraGoodsNo.Value = SqlDataMediator.SqlSetString( cndtnWork.GoodsNo );
            }
            #endregion //���i�ԍ�

            #region ���i���[�J�[�R�[�h
            if (cndtnWork.GoodsMakerCd > 0)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSD.GOODSMAKERCDRF=@FINDGOODSMAKERCD" );
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add( "@FINDGOODSMAKERCD", SqlDbType.Int );
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32( cndtnWork.GoodsMakerCd );
            }
            else
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSD.GOODSMAKERCDRF > 0 " );
            }
            #endregion //���i���[�J�[�R�[�h

            #region �q�ɃR�[�h
            if (!String.IsNullOrEmpty( cndtnWork.WarehouseCode ))
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.Append( "    AND (" );

                // �q�ɂ��w�肳��Ă���ꍇ�A�w��R�[�h�������ɒǉ�����
                sqlTextStrings.Append( "RentSD.WAREHOUSECODERF=@FINDWAREHOUSECODE " );
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add( "@FINDWAREHOUSECODE", SqlDbType.NChar );
                findParaWarehouseCode.Value = SqlDataMediator.SqlSetString( cndtnWork.WarehouseCode );

                if (cndtnWork.OrderDivCd == 0)
                {
                    // �q�ɂ��w�肳��Ă���A�������܂ޏꍇ�A�q�ɃR�[�h��NULL�̃��R�[�h�����o����������ǉ�����
                    sqlTextStrings.Append( "OR RentSD.WAREHOUSECODERF IS NULL" );
                }
                sqlTextStrings.AppendLine( " ) " );
            }
            else if (cndtnWork.OrderDivCd != 0)
            {
                // �q�ɂ��w�肳��Ă��炸�A�������܂܂Ȃ��ꍇ�A�q�ɃR�[�h��NULL�̃��R�[�h�͒��o����Ȃ�������ǉ�����
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSD.WAREHOUSECODERF IS NOT NULL " );
            }
            #endregion //�q�ɃR�[�h

            #region ���i�S���҃R�[�h
            if (!String.IsNullOrEmpty( cndtnWork.EmployeeCode ))
            {
                sqlTextStrings.AppendLine( " AND InspDT.EMPLOYEECODERF = @FINDGEMPLOYEECODE " );
            }
            #endregion //���i�S���҃R�[�h

            #region ���i��(�J�n)
            if (cndtnWork.St_InspectDate > DateTime.MinValue)
            {
                sqlTextStrings.AppendLine( " AND InspDT.INSPECTDATETIMERF >= @INSPECTDATETIMEST " );
            }
            #endregion //���i��(�J�n)

            #region ���i��(�I��)
            if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
            {
                if (cndtnWork.St_InspectDate == DateTime.MinValue)
                {
                    sqlTextStrings.AppendLine( " AND (InspDT.INSPECTDATETIMERF < @INSPECTDATETIMEED OR InspDT.INSPECTDATETIMERF IS NULL)" );
                }
                else
                {

                    sqlTextStrings.AppendLine( " AND InspDT.INSPECTDATETIMERF < @INSPECTDATETIMEED " );
                }
            }
            #endregion //���i��(�I��)

        }

        /// <summary>
        /// �ݏo�v�㎞�Ɍv�コ��Ȃ������폜�ϑݏo�f�[�^�擾�N�G������
        /// </summary>
        /// <param name="cndtnWork">��������</param>
        /// <param name="sqlTextStrings">�����N�G���̊i�[��</param>
        /// <param name="sqlCommand">�p�����[�^�Z�b�g��SQL���s�R�}���h�i�[�N���X</param>
        /// <param name="prefixString">�e�s�̃C���f���g������</param>
        /// <remarks>
        /// <br>Note       : �ݏo�v�㎞�Ɍv�コ��Ȃ������폜�ϑݏo�f�[�^�擾�N�G���𐶐����i�[��֊i�[����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void CreateGetDelRentSlipQuery( HandyInspectParamWork cndtnWork, ref StringBuilder sqlTextStrings, ref SqlCommand sqlCommand, string prefixString )
        {
            #region SELECT��
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "SELECT " );

            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "      SS.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , SD.SALESDATERF AS SALESDTLSALESDATE --���ɓ����ݏo�v��̔���� " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.CUSTOMERSNMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.LOGICALDELETECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.RESULTSADDUPSECCDRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "FROM SALESSLIPRF AS SS WITH (READUNCOMMITTED) " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "INNER JOIN SALESDETAILRF AS SD WITH (READUNCOMMITTED) ON " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        SD.ENTERPRISECODERF = SS.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.ACPTANODRSTATUSRF = SS.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND	SD.LOGICALDELETECODERF = 0  " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "INNER JOIN SALESDETAILRF AS RSD WITH (READUNCOMMITTED) ON " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        RSD.ENTERPRISECODERF = SD.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSD.ACPTANODRSTATUSRF = SD.ACPTANODRSTATUSSRCRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSD.SALESSLIPDTLNUMRF = SD.SALESSLIPDTLNUMSRCRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND	RSD.LOGICALDELETECODERF = 1  " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "INNER JOIN SALESSLIPRF AS RSS WITH (READUNCOMMITTED) ON " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        RSS.ENTERPRISECODERF = RSD.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.ACPTANODRSTATUSRF = RSD.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.SALESSLIPNUMRF = RSD.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.LOGICALDELETECODERF = RSD.LOGICALDELETECODERF " );
            #endregion //SELECT��

            #region WHERE��
            this.CreateGetDelRentSlipWhere( cndtnWork, ref sqlTextStrings, ref sqlCommand, prefixString );
            #endregion //WHERE��

            #region GROUP BY��
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "GROUP BY " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "      SS.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , SD.SALESDATERF  " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.LOGICALDELETECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.RESULTSADDUPSECCDRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.CUSTOMERSNMRF " );
            #endregion //GROUP BY��

        
        
        }

        /// <summary>
        /// �ݏo�v�㎞�Ɍv�コ��Ȃ������폜�ϑݏo�f�[�^�擾����������
        /// </summary>
        /// <param name="cndtnWork">��������</param>
        /// <param name="sqlTextStrings">�����������̊i�[��</param>
        /// <param name="sqlCommand">�p�����[�^�Z�b�g��SQL���s�R�}���h�i�[�N���X</param>
        /// <param name="prefixString">�e�s�̃C���f���g������</param>
        /// <remarks>
        /// <br>Note       : �ݏo�v�㎞�Ɍv�コ��Ȃ������폜�ϑݏo�f�[�^�擾�������𐶐����i�[��֊i�[����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void CreateGetDelRentSlipWhere( HandyInspectParamWork cndtnWork, ref StringBuilder sqlTextStrings, ref SqlCommand sqlCommand, string prefixString )
        {
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "WHERE  " );

            #region ��ƃR�[�h
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        SS.ENTERPRISECODERF = @ENTERPRISECODE " );
            #endregion //��ƃR�[�h

            #region �_���폜�敪
            //�ݏo�v��ς̔���f�[�^���擾����̂ŁA0�Œ�
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SS.LOGICALDELETECODERF = 0 " );
            #endregion //�_���폜�敪

            #region �󒍃X�e�[�^�X
            //�ݏo�v��ς̔���f�[�^���擾����̂ŁA30�Œ�
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SS.ACPTANODRSTATUSRF = 30 " );
            #endregion //�󒍃X�e�[�^�X

            #region ���ד�
            //�ݏo�v�㔄��f�[�^�̔��������ד��Ƃ��Ĉ���
            if (cndtnWork.St_SalesDate > DateTime.MinValue)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND SS.SALESDATERF >= @SHIPMENTDAYST " );
            }
            if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND SS.SALESDATERF <= @SHIPMENTDAYED " );
            }
            #endregion //���ד�

            #region �ԓ`�敪
            //�ݏo�v��ς̔���f�[�^���擾����̂ŁA0�Œ�
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "   AND SS.DEBITNOTEDIVRF = 0" );
            #endregion //�ԓ`�敪
        }

        /// <summary>
        /// �ݏo�v�コ�ꂸ�ɘ_���폜���ꂽ�ݏo�f�[�^�擾�N�G������
        /// </summary>
        /// <param name="cndtnWork">��������</param>
        /// <param name="sqlTextStrings">�����N�G���̊i�[��</param>
        /// <param name="sqlCommand">�p�����[�^�Z�b�g��SQL���s�R�}���h�i�[�N���X</param>
        /// <param name="prefixString">�e�s�̃C���f���g������</param>
        /// <remarks>
        /// <br>Note       : �ݏo�v�コ�ꂸ�ɘ_���폜���ꂽ�ݏo�f�[�^�擾�N�G���𐶐����i�[��֊i�[����</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private void CreateGetLogicalDelRentSlipQuery( HandyInspectParamWork cndtnWork, ref StringBuilder sqlTextStrings, ref SqlCommand sqlCommand, string prefixString )
        {
            #region SELECT��
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "SELECT " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "      RSS.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.SHIPMENTDAYRF AS SALESDTLSALESDATE --���ɓ����ݏo�̏o�ɓ� " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.CUSTOMERSNMRF  " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.LOGICALDELETECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.RESULTSADDUPSECCDRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "FROM SALESSLIPRF AS RSS WITH (READUNCOMMITTED) " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "INNER JOIN SALESDETAILRF AS RSD WITH (READUNCOMMITTED) ON " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        RSS.ENTERPRISECODERF = RSD.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.ACPTANODRSTATUSRF = RSD.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND	RSS.SALESSLIPNUMRF = RSD.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSD.SALESROWNORF > 0 " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND	RSD.ACPTANODRSTATUSSRCRF = 0 " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND	RSD.SALESSLIPDTLNUMSRCRF = 0 " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND	RSS.LOGICALDELETECODERF = RSD.LOGICALDELETECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "LEFT JOIN SALESDETAILRF AS SD WITH (READUNCOMMITTED) ON " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        SD.ENTERPRISECODERF = RSD.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.ACPTANODRSTATUSSRCRF = RSD.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.SALESSLIPDTLNUMSRCRF = RSD.SALESSLIPDTLNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.LOGICALDELETECODERF = 0 " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.ACPTANODRSTATUSRF = 30 " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "LEFT JOIN SALESSLIPRF AS SS WITH (READUNCOMMITTED) ON " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        SD.ENTERPRISECODERF = SS.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.SALESSLIPNUMRF = SS.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.ACPTANODRSTATUSRF = SS.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.LOGICALDELETECODERF = SS.LOGICALDELETECODERF " );
            #endregion //SELECT��

            #region WHERE��
            this.CreateGetLogicalDelRentSlipWhere( cndtnWork, ref sqlTextStrings, ref sqlCommand, prefixString );
            #endregion //WHERE��

            #region GROUP BY��
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "GROUP BY " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "      RSS.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.SHIPMENTDAYRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.CUSTOMERSNMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.LOGICALDELETECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.RESULTSADDUPSECCDRF " );	
            #endregion //GROUP BY��
        }

        /// <summary>
        /// �ݏo�v�コ�ꂸ�ɘ_���폜���ꂽ�ݏo�f�[�^�擾����������
        /// </summary>
        /// <param name="cndtnWork">��������</param>
        /// <param name="sqlTextStrings">�����������̊i�[��</param>
        /// <param name="sqlCommand">�p�����[�^�Z�b�g��SQL���s�R�}���h�i�[�N���X</param>
        /// <param name="prefixString">�e�s�̃C���f���g������</param>
        /// <remarks>
        /// <br>Note       : �ݏo�v�コ�ꂸ�ɘ_���폜���ꂽ�ݏo�f�[�^�擾�������𐶐����i�[��֊i�[����</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private void CreateGetLogicalDelRentSlipWhere( HandyInspectParamWork cndtnWork, ref StringBuilder sqlTextStrings, ref SqlCommand sqlCommand, string prefixString )
        {
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "WHERE  " );

            #region ��ƃR�[�h
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        RSS.ENTERPRISECODERF = @ENTERPRISECODE " );
            #endregion //��ƃR�[�h

            #region �_���폜�敪
            //�_���폜�ς̑ݏo�f�[�^���擾����̂ŁA1�Œ�
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.LOGICALDELETECODERF = 1 " );
            #endregion //�_���폜�敪

            #region �󒍃X�e�[�^�X
            //�ݏo�f�[�^���擾����̂ŁA40�Œ�
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.ACPTANODRSTATUSRF = 40 " );
            #endregion //�󒍃X�e�[�^�X

            #region �����
            // �v�コ��Ă��Ȃ��ݏo�f�[�^���擾����̂ŁANULL�Œ�
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.SALESDATERF IS NULL  " );
            #endregion //�����

            #region ���ד�
            //�ݏo�f�[�^�̏o�ד�����ד��Ƃ��Ĉ���
            if (cndtnWork.St_SalesDate > DateTime.MinValue)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RSS.SHIPMENTDAYRF >= @SHIPMENTDAYST " );
            }
            if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RSS.SHIPMENTDAYRF <= @SHIPMENTDAYED " );
            }
            #endregion //���ד�

            #region �v��攄��f�[�^��ƃR�[�h
            //�v�コ��Ă��Ȃ��ݏo�f�[�^���擾����̂ŁANULL�Œ�
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "   AND SS.ENTERPRISECODERF IS NULL " );
            #endregion //�v��攄��f�[�^��ƃR�[�h

            #region �ԓ`�敪
            //�_���폜���ꂽ�ݏo�f�[�^���擾����̂ŁA0�Œ�
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "   AND RSS.DEBITNOTEDIVRF = 0" );
            #endregion //�ԓ`�敪
        }

        /// <summary>
        /// ����f�[�^�̊i�[
        /// </summary>
        /// <param name="myReader">��������</param>
        /// <param name="cndtnWork">�o�͏���</param>
        /// <returns>�o�̓f�[�^</returns>
        /// <remarks>
        /// <br>Note       : ����f�[�^�̊i�[���s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H ������</br>
        /// <br>�@�@�@�@�@ : ���i�Ɖ�̕ύX�Ή�</br>
        /// <br>Update Note: 2018/10/16 ���O</br>
        /// <br>�@�@�@�@�@ : �n���f�B�^�[�~�i���܎��Ή�</br>
        /// </remarks>
        private InspectRefDataWork CopyDataFromReader(SqlDataReader myReader, HandyInspectParamWork cndtnWork)
        {
            InspectRefDataWork ResultWork = new InspectRefDataWork();
            ResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            if (cndtnWork.Pattern != 3)
            {
                ResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                ResultWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                ResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                ResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                ResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNM"));
            }
            // --- ADD ���O 2018/10/16 �n���f�B�^�[�~�i���܎��Ή�---------->>>>>
            else
            {
                // ���i�݂̂̏ꍇ
                ResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACPAYSLIPNUMRF"));
                ResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPROWNORF"));
            }
            // --- ADD ���O 2018/10/16 �n���f�B�^�[�~�i���܎��Ή�----------<<<<<
            ResultWork.ShipmentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTOUTDAYRF"));
            ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            ResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            ResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            ResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            ResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            ResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            ResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            // �u���Ɍ��i�v�̏ꍇ�̓[���Œ�
            if (cndtnWork.Pattern == 1)
            {
                ResultWork.ShipmentCnt = 0;
            }
            else
            {
                ResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            }
            // �u�o�Ɍ��i�v�̏ꍇ�̓[���Œ�
            if (cndtnWork.Pattern == 0)
            {
                ResultWork.InputCnt = 0;
            }
            else
            {
                ResultWork.InputCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INPUTCNTRF"));
            }
            ResultWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            ResultWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            ResultWork.InspectStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTSTATUSRF"));
            ResultWork.HandTerminalCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDTERMINALCODERF"));
            ResultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            ResultWork.InspectDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("INSPECTDATETIMERF"));
            // --- ADD 3H ������ 2017/09/07---------->>>>>
            // �f�[�^�\�[�X�敪 1:����f�[�^ 2:�d���f�[�^ 3:�݌Ɉړ��f�[�^ 4:�݌ɒ����f�[�^
            ResultWork.DataSourceDiv = 1;
            // --- ADD 3H ������ 2017/09/07----------<<<<<
            
            return ResultWork;
        }
        #endregion

        // --- ADD 3H ������ 2017/09/07---------->>>>>
        #region �d���f�[�^�̒��o����
        /// <summary>
        /// �d���f�[�^�̒��o����
        /// </summary>
        /// <param name="retList">���o�f�[�^</param>
        /// <param name="cndtnWork">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d���f�[�^�𒊏o�������܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private int SearchStockSlipProc(out ArrayList retList,
            HandyInspectParamWork cndtnWork, out string errMessage, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            errMessage = string.Empty;
            SqlCommand sqlCommand = null;
            retList = new ArrayList();

            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();

                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine("  STOCK.SUPPLIERSLIPNORF ");          // �d���`�[�ԍ�
                    sqlText.AppendLine(" ,STOCK.STOCKROWNORF ");          // �d���s�ԍ�
                    sqlText.AppendLine(" ,STOCK.ARRIVALGOODSDAYRF ");          // ���ד�
                    sqlText.AppendLine(" ,STOCK.GOODSMAKERCDRF ");          // ���i���[�J�[�R�[�h
                    sqlText.AppendLine(" ,STOCK.MAKERNAMERF ");          // ���i���[�J�[��
                    sqlText.AppendLine(" ,STOCK.GOODSNORF ");          // ���i�ԍ�
                    sqlText.AppendLine(" ,STOCK.GOODSNAMERF ");          // ���i����
                    sqlText.AppendLine(" ,STOCK.STOCKCOUNTRF ");          // �d����
                    sqlText.AppendLine(" ,STOCK.SUPPLIERSNMRF ");          // �d���旪��
                    sqlText.AppendLine(" ,STOCK.WAREHOUSECODERF ");          // �q�ɃR�[�h
                    sqlText.AppendLine(" ,STOCK.WAREHOUSENAMERF ");          // �q�ɖ���
                    sqlText.AppendLine(" ,STOCK.WAREHOUSESHELFNORF ");          // �q�ɒI��
                    sqlText.AppendLine(" ,STOCK.SUPPLIERFORMALRF ");          // �d���`��
                    sqlText.AppendLine(" ,STOCK.STOCKSLIPCDDTLRF ");          // �d���`�[�敪�i���ׁj
                    sqlText.AppendLine(" ,I.ACPAYSLIPCDRF ");          // �󕥌��`�[�敪
                    sqlText.AppendLine(" ,I.ACPAYTRANSCDRF ");          // �󕥌�����敪
                    sqlText.AppendLine(" ,I.INSPECTSTATUSRF ");          // ���i�X�e�[�^�X
                    sqlText.AppendLine(" ,I.HANDTERMINALCODERF ");          // �n���f�B�^�[�~�i���敪
                    sqlText.AppendLine(" ,I.INSPECTDATETIMERF ");          // ���i����
                    sqlText.AppendLine(" ,I.EMPLOYEECODERF ");          // �]�ƈ��R�[�h
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" (SELECT SL.ENTERPRISECODERF ");
                    sqlText.AppendLine(" ,SL.STOCKSECTIONCDRF ");
                    sqlText.AppendLine(" ,SD.SUPPLIERSLIPNORF ");
                    sqlText.AppendLine(" ,SD.STOCKROWNORF ");
                    sqlText.AppendLine(" ,SD.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" ,SD.MAKERNAMERF ");
                    sqlText.AppendLine(" ,SD.GOODSNORF ");
                    sqlText.AppendLine(" ,SD.GOODSNAMERF ");
                    // �p�^�[�����u�o�Ɍ��i�v�̏ꍇ
                    if (cndtnWork.Pattern == 0)
                    {
                        sqlText.AppendLine(" ,SD.STOCKCOUNTRF *(-1) AS STOCKCOUNTRF ");
                    }
                    // �p�^�[�����u���Ɍ��i�vOR�u�����Ɂv�̏ꍇ
                    else
                    {
                        sqlText.AppendLine(" ,SD.STOCKCOUNTRF ");
                    }
                    sqlText.AppendLine(" ,SL.SUPPLIERSNMRF ");
                    sqlText.AppendLine(" ,SD.WAREHOUSECODERF ");
                    sqlText.AppendLine(" ,SD.WAREHOUSENAMERF ");
                    sqlText.AppendLine(" ,SD.WAREHOUSESHELFNORF ");
                    sqlText.AppendLine(" ,SL.ARRIVALGOODSDAYRF ");
                    sqlText.AppendLine(" ,SD.SUPPLIERFORMALRF ");
                    sqlText.AppendLine(" ,SD.STOCKSLIPCDDTLRF ");
                    sqlText.AppendLine("FROM STOCKSLIPRF AS SL WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine("INNER JOIN STOCKDETAILRF AS SD WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine("ON SD.ENTERPRISECODERF=SL.ENTERPRISECODERF ");
                    sqlText.AppendLine("AND SD.SUPPLIERSLIPNORF =SL.SUPPLIERSLIPNORF ");
                    sqlText.AppendLine("AND SD.SUPPLIERFORMALRF =SL.SUPPLIERFORMALRF ");
                    // WHERE��
                    sqlText.AppendLine("WHERE ");

                    // ��ƃR�[�h
                    sqlText.AppendLine(" SL.ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

                    // �_���폜�敪�u0:�L���v�Œ�
                    sqlText.AppendLine(" AND SD.LOGICALDELETECODERF = 0 ");

                    //���_�R�[�h
                    if (!String.IsNullOrEmpty(cndtnWork.SectionCode) && !"00".Equals(cndtnWork.SectionCode))
                    {
                        sqlText.AppendLine(" AND SL.STOCKSECTIONCDRF=@FINDSTOCKSECTIONCDRF ");
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSTOCKSECTIONCDRF", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.SectionCode);
                    }

                    // �ԓ`�敪 0:���`
                    sqlText.AppendLine(" AND SL.DEBITNOTEDIVRF=0 ");

                    // �p�^�[�����u�o�Ɍ��i�v�̏ꍇ
                    if (cndtnWork.Pattern == 0)
                    {
                        // �d���`�� 0�F�d��
                        sqlText.AppendLine(" AND SL.SUPPLIERFORMALRF=0 ");
                        // �d���`�[�敪�i���ׁj1:�ԕi
                        sqlText.AppendLine(" AND SD.STOCKSLIPCDDTLRF=1 ");
                    }
                    // �p�^�[�����u���Ɍ��i�v�̏ꍇ
                    else if (cndtnWork.Pattern == 1)
                    {
                        // �d���`�� 0�F�d��
                        sqlText.AppendLine(" AND SL.SUPPLIERFORMALRF=0 ");
                        // �d���`�[�敪�i���ׁj0:�d��
                        sqlText.AppendLine(" AND SD.STOCKSLIPCDDTLRF=0 ");
                    }
                    // �p�^�[�����u�����Ɂv�̏ꍇ
                    else if (cndtnWork.Pattern == 2)
                    {
                        // �d���`�� 1�F����
                        sqlText.AppendLine(" AND SL.SUPPLIERFORMALRF=1 ");
                        // �d���`�[�敪�i���ׁj0:�d��
                        sqlText.AppendLine(" AND SD.STOCKSLIPCDDTLRF=0 ");
                    }

                    // ���敪�u0:�܂ށv
                    if (cndtnWork.OrderDivCd == 0)
                    {
                        // �q�ɃR�[�h
                        if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                        {
                            sqlText.AppendLine(" AND (SD.WAREHOUSECODERF=@FINDWAREHOUSECODE OR SD.WAREHOUSECODERF IS NULL)");
                            SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                        {
                            sqlText.AppendLine(" AND SD.WAREHOUSECODERF=@FINDWAREHOUSECODE");
                            SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                        }
                        else
                        {
                            sqlText.AppendLine(" AND SD.WAREHOUSECODERF IS NOT NULL ");
                        }
                    }

                    // ���o�ד�(�J�n)
                    if (cndtnWork.St_SalesDate > DateTime.MinValue)
                    {
                        sqlText.AppendLine(" AND SL.ARRIVALGOODSDAYRF >= @SALESDATEST ");
                        SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                        paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
                    }

                    // ���o�ד�(�I��)
                    if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                    {
                        sqlText.AppendLine(" AND SL.ARRIVALGOODSDAYRF <= @SALESDATEED ");
                        SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                        paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
                    }

                    // ���i���[�J�[�R�[�h
                    if (cndtnWork.GoodsMakerCd > 0)
                    {
                        sqlText.AppendLine(" AND SD.GOODSMAKERCDRF=@FINDGOODSMAKERCD");
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(cndtnWork.GoodsMakerCd);
                    }
                    else
                    {
                        sqlText.AppendLine(" AND SD.GOODSMAKERCDRF > " + Zero);
                    }

                    //���i�ԍ�
                    if (!String.IsNullOrEmpty(cndtnWork.GoodsNo))
                    {
                        sqlText.AppendLine(" AND SD.GOODSNORF LIKE @FINDGOODSNO");
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                        //�O����v�����̏ꍇ
                        if (cndtnWork.GoodsNoSrchTyp == 1) cndtnWork.GoodsNo = cndtnWork.GoodsNo + "%";
                        //�����v�����̏ꍇ
                        if (cndtnWork.GoodsNoSrchTyp == 2) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo;
                        //�����܂������̏ꍇ
                        if (cndtnWork.GoodsNoSrchTyp == 3) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo + "%";
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(cndtnWork.GoodsNo);
                    }

                    sqlText.AppendLine(" ) AS STOCK ");
                    sqlText.AppendLine(" LEFT JOIN INSPECTDATARF AS I WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" ON STOCK.ENTERPRISECODERF = I.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND STOCK.SUPPLIERSLIPNORF = I.ACPAYSLIPNUMRF ");
                    sqlText.AppendLine(" AND STOCK.STOCKROWNORF = I.ACPAYSLIPROWNORF ");
                    // �d�����׃f�[�^.�d���`����0�F�d���@AND�@���i�f�[�^.�󕥌��`�[�敪��10�F�d��
                    sqlText.AppendLine(" AND (STOCK.SUPPLIERFORMALRF = 0 AND I.ACPAYSLIPCDRF =10) ");
                    // �_���폜�敪��0
                    sqlText.AppendLine(" AND I.LOGICALDELETECODERF = 0 ");

                    // �d����
                    sqlText.AppendLine(" WHERE STOCK.STOCKCOUNTRF>0 ");

                    // �]�ƈ��R�[�h
                    if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
                    {
                        sqlText.AppendLine(" AND I.EMPLOYEECODERF =@FINDEMPLOYEECODE ");
                        SqlParameter ParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                        ParaEmployeeCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EmployeeCode);
                    }

                    // ���i��(�J�n)
                    if (cndtnWork.St_InspectDate > DateTime.MinValue)
                    {
                        sqlText.AppendLine(" AND I.INSPECTDATETIMERF >= @INSPECTDATETIMEST ");
                        SqlParameter ParaInspectDateTimeSt = sqlCommand.Parameters.Add("@INSPECTDATETIMEST", SqlDbType.BigInt);
                        ParaInspectDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.St_InspectDate);
                    }

                    // ���i��(�I��)
                    if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
                    {
                        if (cndtnWork.St_InspectDate == DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND (I.INSPECTDATETIMERF < @INSPECTDATETIMEED OR I.INSPECTDATETIMERF IS NULL)");
                        }
                        else
                        {
                            sqlText.AppendLine(" AND  I.INSPECTDATETIMERF < @INSPECTDATETIMEED ");
                        }
                        SqlParameter ParaInspectDateTimeEd = sqlCommand.Parameters.Add("@INSPECTDATETIMEED", SqlDbType.BigInt);
                        ParaInspectDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.Ed_InspectDate);
                    }

                    sqlText.AppendLine(" ORDER BY ");
                    sqlText.AppendLine("  STOCK.ARRIVALGOODSDAYRF ");
                    sqlText.AppendLine(" ,STOCK.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" ,STOCK.GOODSNORF ");
                    sqlText.AppendLine(" ,STOCK.SUPPLIERSLIPNORF ");
                    sqlText.AppendLine(" ,STOCK.STOCKROWNORF ");

                    sqlCommand.CommandText = sqlText.ToString();

                    // �N�G�����s���̃^�C���A�E�g���Ԃ�3600�b�ɐݒ肷��
                    sqlCommand.CommandTimeout = 3600;
                    using (SqlDataReader MyReader = sqlCommand.ExecuteReader())
                    {
                        while (MyReader.Read())
                        {
                            // �������ʎd���f�[�^�̊i�[
                            retList.Add(CopyStockSlipDataFromReader(MyReader, cndtnWork));
                        }
                    }
                    if (retList != null && retList.Count > 0)
                    {
                        // �������ʂ���ꍇ�A�uctDB_NORMAL�v��߂�
                        Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        // �������ʂȂ��ꍇ�A�uNOT_FOUND�v��߂�
                        Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                }
                catch (SqlException ex)
                {
                    errMessage = ex.Message;
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    Status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    errMessage = ex.Message;
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchStockSlipProc Exception=" + ex.Message, Status);
                }
            }

            return Status;
        }

        /// <summary>
        /// �d���f�[�^�̊i�[
        /// </summary>
        /// <param name="myReader">��������</param>
        /// <param name="cndtnWork">��������</param>
        /// <returns>���i�Ɖ�o����</returns>
        /// <remarks>
        /// <br>Note       : �d���f�[�^�̊i�[���s���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/09/07</br>
        /// <br>Update Note: 2017/10/13 3H ������</br>
        /// <br>�@�@�@�@�@ : ���i�Ɖ�̕ύX�Ή�</br>
        /// </remarks>
        private InspectRefDataWork CopyStockSlipDataFromReader(SqlDataReader myReader, HandyInspectParamWork cndtnWork)
        {
            InspectRefDataWork resultWork = new InspectRefDataWork();
            // �`�[�ԍ�
            resultWork.SalesSlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF")).ToString();
            // �s�ԍ�
            resultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            // ���o�ד�
            resultWork.ShipmentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            // ���i�ԍ�
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            // ���i����
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            // ���i���[�J�[�R�[�h
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            // ���[�J�[����
            resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));

            // �p�^�[�����u�o�Ɍ��i�v�̏ꍇ
            if (cndtnWork.Pattern == 0)
            {
                // ���ɐ�:�[���Œ�
                resultWork.InputCnt = 0;
            }
            // �p�^�[�����u���Ɍ��i�vOR�u�����Ɂv�̏ꍇ
            else
            {
                // ���ɐ�:�d����
                resultWork.InputCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            }

            // �p�^�[�����u�o�Ɍ��i�v�̏ꍇ
            if (cndtnWork.Pattern == 0)
            {
                // �o�ɐ�:�d����
                resultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            }
            // �p�^�[�����u���Ɍ��i�vOR�u�����Ɂv�̏ꍇ
            else
            {
                // �o�ɐ�:�[���Œ�
                resultWork.ShipmentCnt = 0;
            }

            // ����於��
            resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            // �q�ɃR�[�h
            resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            // �q�ɖ���
            resultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            // �q�ɒI��
            resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            // �d���`��
            resultWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            // �d���`�[�敪�i���ׁj
            resultWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
            // �󕥌��`�[�敪
            resultWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            // �󕥌�����敪
            resultWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            // ���i�S���҃R�[�h
            resultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            // ���i����
            resultWork.InspectDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("INSPECTDATETIMERF"));
            // ���i�X�e�[�^�X
            resultWork.InspectStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTSTATUSRF"));
            // �n���f�B�^�[�~�i���敪
            resultWork.HandTerminalCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDTERMINALCODERF"));
            // �f�[�^�\�[�X�敪 1:����f�[�^ 2:�d���f�[�^ 3:�݌Ɉړ��f�[�^ 4:�݌ɒ����f�[�^
            resultWork.DataSourceDiv = 2;

            return resultWork;
        }
        #endregion

        #region �݌Ɉړ��f�[�^�̒��o����
        /// <summary>
        /// �݌Ɉړ��f�[�^�̒��o����
        /// </summary>
        /// <param name="retList">���o�f�[�^</param>
        /// <param name="cndtnWork">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �݌Ɉړ��f�[�^�𒊏o�������܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private int SearchStockMoveProc(out ArrayList retList,
            HandyInspectParamWork cndtnWork, out string errMessage, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            errMessage = string.Empty;
            SqlCommand sqlCommand = null;
            retList = new ArrayList();

            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();

                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine("  SM.STOCKMOVESLIPNORF ");          // �݌Ɉړ��`�[�ԍ�
                    sqlText.AppendLine(" ,SM.STOCKMOVEROWNORF ");          // �݌Ɉړ��s�ԍ�

                    sqlText.AppendLine(" ,SM.SHIPMENTFIXDAYRF ");          // �o�׊m���
                    sqlText.AppendLine(" ,SM.ARRIVALGOODSDAYRF ");          // ���ד�

                    sqlText.AppendLine(" ,SM.GOODSMAKERCDRF ");          // ���i���[�J�[�R�[�h
                    sqlText.AppendLine(" ,SM.MAKERNAMERF ");          // ���i���[�J�[��
                    sqlText.AppendLine(" ,SM.GOODSNORF ");          // ���i�ԍ�
                    sqlText.AppendLine(" ,SM.GOODSNAMERF ");          // ���i����
                    sqlText.AppendLine(" ,SM.MOVECOUNTRF ");          // �ړ���

                    sqlText.AppendLine(" ,SM.AFSECTIONGUIDESNMRF ");          // �ړ��拒�_�K�C�h����
                    sqlText.AppendLine(" ,SM.BFSECTIONGUIDESNMRF ");          // �ړ������_�K�C�h����

                    sqlText.AppendLine(" ,SM.BFENTERWAREHCODERF ");          // �ړ����q�ɃR�[�h
                    sqlText.AppendLine(" ,SM.BFENTERWAREHNAMERF ");          // �ړ����q�ɖ���
                    sqlText.AppendLine(" ,SM.AFENTERWAREHCODERF ");          // �ړ���q�ɃR�[�h
                    sqlText.AppendLine(" ,SM.AFENTERWAREHNAMERF ");          // �ړ���q�ɖ���

                    sqlText.AppendLine(" ,SM.BFSHELFNORF ");          // �ړ����I��
                    sqlText.AppendLine(" ,SM.AFSHELFNORF ");          // �ړ���I��


                    sqlText.AppendLine(" ,SM.STOCKMOVEFORMALRF ");          // �݌Ɉړ��`��
                    sqlText.AppendLine(" ,I.ACPAYSLIPCDRF ");          // �󕥌��`�[�敪
                    sqlText.AppendLine(" ,I.ACPAYTRANSCDRF ");          // �󕥌�����敪
                    sqlText.AppendLine(" ,I.INSPECTSTATUSRF ");          // ���i�X�e�[�^�X
                    sqlText.AppendLine(" ,I.HANDTERMINALCODERF ");          // �n���f�B�^�[�~�i���敪
                    sqlText.AppendLine(" ,I.INSPECTDATETIMERF ");          // ���i����
                    sqlText.AppendLine(" ,I.EMPLOYEECODERF ");          // �]�ƈ��R�[�h
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" (SELECT ENTERPRISECODERF ");

                    sqlText.AppendLine(" ,BFSECTIONCODERF ");
                    sqlText.AppendLine(" ,AFSECTIONCODERF ");

                    sqlText.AppendLine(" ,STOCKMOVESLIPNORF ");
                    sqlText.AppendLine(" ,STOCKMOVEROWNORF ");
                    sqlText.AppendLine(" ,GOODSMAKERCDRF ");
                    sqlText.AppendLine(" ,MAKERNAMERF ");
                    sqlText.AppendLine(" ,GOODSNORF ");
                    sqlText.AppendLine(" ,GOODSNAMERF ");
                    sqlText.AppendLine(" ,MOVECOUNTRF ");

                    sqlText.AppendLine(" ,AFSECTIONGUIDESNMRF ");
                    sqlText.AppendLine(" ,BFSECTIONGUIDESNMRF ");

                    sqlText.AppendLine(" ,BFENTERWAREHCODERF ");
                    sqlText.AppendLine(" ,BFENTERWAREHNAMERF ");
                    sqlText.AppendLine(" ,AFENTERWAREHCODERF ");
                    sqlText.AppendLine(" ,AFENTERWAREHNAMERF ");

                    sqlText.AppendLine(" ,AFSHELFNORF ");
                    sqlText.AppendLine(" ,ARRIVALGOODSDAYRF ");

                    sqlText.AppendLine(" ,BFSHELFNORF ");
                    sqlText.AppendLine(" ,SHIPMENTFIXDAYRF ");

                    sqlText.AppendLine(" ,STOCKMOVEFORMALRF ");
                    sqlText.AppendLine("FROM STOCKMOVERF  WITH (READUNCOMMITTED) ");
                    // WHERE��
                    sqlText.AppendLine("WHERE ");

                    // ��ƃR�[�h
                    sqlText.AppendLine(" STOCKMOVERF.ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

                    // �_���폜�敪�u0:�L���v�Œ�
                    sqlText.AppendLine(" AND STOCKMOVERF.LOGICALDELETECODERF = 0 ");

                    // �p�^�[�����u�o�Ɍ��i�v�̏ꍇ
                    if (cndtnWork.Pattern == 0)
                    {
                        // ���_�R�[�h
                        if (!String.IsNullOrEmpty(cndtnWork.SectionCode) && !"00".Equals(cndtnWork.SectionCode))
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.BFSECTIONCODERF=@FINDSTOCKSECTIONCDRF ");
                        }
                        // �ړ��`�� 1:�݌ɏo�� OR 2�F�q�ɏo��
                        sqlText.AppendLine(" AND STOCKMOVERF.STOCKMOVEFORMALRF IN(1,2) ");
                        // �q�ɃR�[�h
                        if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.BFENTERWAREHCODERF=@FINDWAREHOUSECODE ");
                        }
                        // ���o�ד�(�J�n)
                        if (cndtnWork.St_SalesDate > DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.SHIPMENTFIXDAYRF >= @SALESDATEST ");
                        }
                        // ���o�ד�(�I��)
                        if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.SHIPMENTFIXDAYRF <= @SALESDATEED ");
                        }
                    }
                    // �p�^�[�����u���Ɍ��i�v�̏ꍇ
                    else
                    {
                        // ���_�R�[�h
                        if (!String.IsNullOrEmpty(cndtnWork.SectionCode) && !"00".Equals(cndtnWork.SectionCode))
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.AFSECTIONCODERF=@FINDSTOCKSECTIONCDRF ");
                        }
                        // �ړ��`�� 3:�݌ɓ��� OR 4�F�q�ɏo��
                        sqlText.AppendLine(" AND STOCKMOVERF.STOCKMOVEFORMALRF IN(3,4) ");
                        // �q�ɃR�[�h
                        if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.AFENTERWAREHCODERF=@FINDWAREHOUSECODE ");
                        }
                        // ���o�ד�(�J�n)
                        if (cndtnWork.St_SalesDate > DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.ARRIVALGOODSDAYRF >= @SALESDATEST ");
                        }
                        // ���o�ד�(�I��)
                        if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.ARRIVALGOODSDAYRF <= @SALESDATEED ");
                        }
                    }

                    //���_�R�[�h
                    if (!String.IsNullOrEmpty(cndtnWork.SectionCode) && !"00".Equals(cndtnWork.SectionCode))
                    {
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSTOCKSECTIONCDRF", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.SectionCode);
                    }

                    // �q�ɃR�[�h
                    if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                    {
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                    }

                    // ���o�ד�(�J�n)
                    if (cndtnWork.St_SalesDate > DateTime.MinValue)
                    {
                        SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                        paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
                    }

                    // ���o�ד�(�I��)
                    if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                    {
                        SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                        paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
                    }

                    // ���i���[�J�[�R�[�h
                    if (cndtnWork.GoodsMakerCd > 0)
                    {
                        sqlText.AppendLine(" AND STOCKMOVERF.GOODSMAKERCDRF=@FINDGOODSMAKERCD");
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(cndtnWork.GoodsMakerCd);
                    }
                    else
                    {
                        sqlText.AppendLine(" AND STOCKMOVERF.GOODSMAKERCDRF > " + Zero);
                    }

                    //���i�ԍ�
                    if (!String.IsNullOrEmpty(cndtnWork.GoodsNo))
                    {
                        sqlText.AppendLine(" AND STOCKMOVERF.GOODSNORF LIKE @FINDGOODSNO");
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                        //�O����v�����̏ꍇ
                        if (cndtnWork.GoodsNoSrchTyp == 1) cndtnWork.GoodsNo = cndtnWork.GoodsNo + "%";
                        //�����v�����̏ꍇ
                        if (cndtnWork.GoodsNoSrchTyp == 2) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo;
                        //�����܂������̏ꍇ
                        if (cndtnWork.GoodsNoSrchTyp == 3) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo + "%";
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(cndtnWork.GoodsNo);
                    }

                    sqlText.AppendLine(" ) AS SM ");
                    sqlText.AppendLine(" LEFT JOIN INSPECTDATARF AS I WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" ON SM.ENTERPRISECODERF = I.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND SM.STOCKMOVESLIPNORF = I.ACPAYSLIPNUMRF ");
                    sqlText.AppendLine(" AND SM.STOCKMOVEROWNORF = I.ACPAYSLIPROWNORF ");
                    // �݌Ɉړ��f�[�^.�݌Ɉړ��`�� IN (1:�݌ɏo��,2:�q�ɏo��) AND ���i�f�[�^.�󕥌��`�[�敪��30�F�ړ��o��
                    sqlText.AppendLine(" AND ((SM.STOCKMOVEFORMALRF IN(1,2)  AND I.ACPAYSLIPCDRF =30) ");
                    // �݌Ɉړ��f�[�^.�݌Ɉړ��`�� IN (3:�݌ɓ���,4:�q�ɓ���) AND ���i�f�[�^.�󕥌��`�[�敪��31�F�ړ�����
                    sqlText.AppendLine("   OR (SM.STOCKMOVEFORMALRF IN(3,4)  AND I.ACPAYSLIPCDRF =31)) ");
                    // �󕥌�����敪��10
                    sqlText.AppendLine(" AND I.ACPAYTRANSCDRF = 10 ");
                    // �_���폜�敪��0
                    sqlText.AppendLine(" AND I.LOGICALDELETECODERF = 0 ");
                    // �ړ�����0
                    sqlText.AppendLine(" WHERE   SM.MOVECOUNTRF>0 ");

                    // �]�ƈ��R�[�h
                    if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
                    {
                        sqlText.AppendLine(" AND I.EMPLOYEECODERF =@FINDEMPLOYEECODE ");
                        SqlParameter ParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                        ParaEmployeeCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EmployeeCode);
                    }

                    // ���i��(�J�n)
                    if (cndtnWork.St_InspectDate > DateTime.MinValue)
                    {
                        sqlText.AppendLine(" AND I.INSPECTDATETIMERF >= @INSPECTDATETIMEST ");
                        SqlParameter ParaInspectDateTimeSt = sqlCommand.Parameters.Add("@INSPECTDATETIMEST", SqlDbType.BigInt);
                        ParaInspectDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.St_InspectDate);
                    }

                    // ���i��(�I��)
                    if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
                    {
                        if (cndtnWork.St_InspectDate == DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND (I.INSPECTDATETIMERF < @INSPECTDATETIMEED OR I.INSPECTDATETIMERF IS NULL)");
                        }
                        else
                        {
                            sqlText.AppendLine(" AND  I.INSPECTDATETIMERF < @INSPECTDATETIMEED ");
                        }
                        SqlParameter ParaInspectDateTimeEd = sqlCommand.Parameters.Add("@INSPECTDATETIMEED", SqlDbType.BigInt);
                        ParaInspectDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.Ed_InspectDate);
                    }

                    sqlText.AppendLine(" ORDER BY ");
                    // �p�^�[�����u�o�Ɍ��i�v�̏ꍇ
                    if (cndtnWork.Pattern == 0)
                    {
                        sqlText.AppendLine("  SM.SHIPMENTFIXDAYRF ");
                    }
                    else
                    {
                        sqlText.AppendLine("  SM.ARRIVALGOODSDAYRF ");
                    }
                    sqlText.AppendLine(" ,SM.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" ,SM.GOODSNORF ");
                    sqlText.AppendLine(" ,SM.STOCKMOVESLIPNORF ");
                    sqlText.AppendLine(" ,SM.STOCKMOVEROWNORF ");

                    sqlCommand.CommandText = sqlText.ToString();

                    // �N�G�����s���̃^�C���A�E�g���Ԃ�3600�b�ɐݒ肷��
                    sqlCommand.CommandTimeout = 3600;
                    using (SqlDataReader MyReader = sqlCommand.ExecuteReader())
                    {
                        while (MyReader.Read())
                        {
                            // �������ʍ݌Ɉړ��f�[�^�̊i�[
                            retList.Add(CopyStockMoveDataFromReader(MyReader, cndtnWork));
                        }
                    }

                    if (retList != null && retList.Count > 0)
                    {
                        // �������ʂ���ꍇ�A�uctDB_NORMAL�v��߂�
                        Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        // �������ʂȂ��ꍇ�A�uNOT_FOUND�v��߂�
                        Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                }
                catch (SqlException ex)
                {
                    errMessage = ex.Message;
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    Status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    errMessage = ex.Message;
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchStockMoveProc Exception=" + ex.Message, Status);
                }
            }

            return Status;
        }

        /// <summary>
        /// �݌Ɉړ��f�[�^�̊i�[
        /// </summary>
        /// <param name="myReader">��������</param>
        /// <param name="cndtnWork">��������</param>
        /// <returns>���i�Ɖ�o����</returns>
        /// <remarks>
        /// <br>Note       : �݌Ɉړ��f�[�^�̊i�[���s���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private InspectRefDataWork CopyStockMoveDataFromReader(SqlDataReader myReader, HandyInspectParamWork cndtnWork)
        {
            InspectRefDataWork resultWork = new InspectRefDataWork();
            // �`�[�ԍ�
            resultWork.SalesSlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF")).ToString();
            // �s�ԍ�
            resultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
            // �p�^�[�����u�o�Ɍ��i�v�̏ꍇ
            if (cndtnWork.Pattern == 0)
            {
                // ���o�ד�:�o�׊m���
                resultWork.ShipmentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF"));
            }
            else
            {
                // ���o�ד�:���ד�
                resultWork.ShipmentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            }
            // ���i�ԍ�
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            // ���i����
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            // ���i���[�J�[�R�[�h
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            // ���[�J�[����
            resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));

            // �p�^�[�����u�o�Ɍ��i�v�̏ꍇ
            if (cndtnWork.Pattern == 0)
            {
                // ���ɐ�:�[���Œ�
                resultWork.InputCnt = 0;
                // �o�ɐ�:�ړ���
                resultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
                // ����於��
                resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF")) + ":" + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
                // �q�ɃR�[�h
                resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
                // �q�ɖ���
                resultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
                // �q�ɒI��
                resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
            }
            // �p�^�[�����u���Ɍ��i�v�̏ꍇ
            else
            {
                // ���ɐ�:�ړ���
                resultWork.InputCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
                // �o�ɐ�:�[���Œ�
                resultWork.ShipmentCnt = 0;
                // ����於��
                resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF")) + ":" + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
                // �q�ɃR�[�h
                resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
                // �q�ɖ���
                resultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
                // �q�ɒI��
                resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
            }
            // �ړ��`��
            resultWork.StockMoveFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFORMALRF"));

            // �󕥌��`�[�敪
            resultWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            // �󕥌�����敪
            resultWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            // ���i�S���҃R�[�h
            resultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            // ���i����
            resultWork.InspectDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("INSPECTDATETIMERF"));
            // ���i�X�e�[�^�X
            resultWork.InspectStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTSTATUSRF"));
            // �n���f�B�^�[�~�i���敪
            resultWork.HandTerminalCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDTERMINALCODERF"));
            // �f�[�^�\�[�X�敪 1:����f�[�^ 2:�d���f�[�^ 3:�݌Ɉړ��f�[�^ 4:�݌ɒ����f�[�^
            resultWork.DataSourceDiv = 3;

            return resultWork;
        }
        #endregion

        #region �݌ɒ����f�[�^���o����
        /// <summary>
        /// �݌ɒ����f�[�^���o����
        /// </summary>
        /// <param name="retList">���o�f�[�^</param>
        /// <param name="cndtnWork">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="stockSlipFlg">�݌Ɏd���t���O</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ����f�[�^�𒊏o�������܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private int SearchStockAdjustProc(out ArrayList retList,
            HandyInspectParamWork cndtnWork, out string errMessage, ref SqlConnection sqlConnection, bool stockSlipFlg)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            errMessage = string.Empty;
            SqlCommand sqlCommand = null;
            retList = new ArrayList();

            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();

                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine("  ST.STOCKSECTIONCDRF ");             // �d�����_�R�[�h
                    sqlText.AppendLine(" ,ST.STOCKADJUSTSLIPNORF ");          // �݌ɒ����`�[�ԍ�
                    sqlText.AppendLine(" ,ST.STOCKADJUSTROWNORF ");           // �݌ɒ����s�ԍ�
                    sqlText.AppendLine(" ,ST.GOODSMAKERCDRF ");               // ���i���[�J�[�R�[�h
                    sqlText.AppendLine(" ,ST.MAKERNAMERF ");                  // ���i���[�J�[��
                    sqlText.AppendLine(" ,ST.GOODSNORF ");                    // ���i�ԍ�
                    sqlText.AppendLine(" ,ST.GOODSNAMERF ");                  // ���i����
                    if (stockSlipFlg)
                    {
                        // �݌Ɏd�� 1�F�I��L��
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            // �p�^�[�� 0:�o�Ɍ��i
                            if (cndtnWork.Pattern == 0)
                            {
                                sqlText.AppendLine(" ,ST.ADJUSTCOUNTRF*(-1) AS ADJUSTCOUNTRF");                // ������
                            }
                            // �p�^�[�� 1:���Ɍ��i
                            else if (cndtnWork.Pattern == 1)
                            {
                                sqlText.AppendLine(" ,ST.ADJUSTCOUNTRF ");                // ������
                            }
                        }
                    }
                    else
                    {
                        // ��[�o�� 1�F�I��L��
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            sqlText.AppendLine(" ,ST.ADJUSTCOUNTRF ");                // ������
                        }
                    }
                    sqlText.AppendLine(" ,ST.SUPPLIERSNMRF ");                // �d���旪��
                    sqlText.AppendLine(" ,ST.WAREHOUSECODERF ");              // �q�ɃR�[�h
                    sqlText.AppendLine(" ,ST.WAREHOUSENAMERF ");              // �q�ɖ���
                    sqlText.AppendLine(" ,ST.WAREHOUSESHELFNORF ");           // �q�ɒI��
                    sqlText.AppendLine(" ,ST.ADJUSTDATERF ");                 // �������t
                    sqlText.AppendLine(" ,ST.ACPAYSLIPCDRF ");                // �󕥌��`�[�敪
                    sqlText.AppendLine(" ,ST.ACPAYTRANSCDRF ");               // �󕥌�����敪
                    sqlText.AppendLine(" ,I.INSPECTSTATUSRF ");               // ���i�X�e�[�^�X
                    sqlText.AppendLine(" ,I.HANDTERMINALCODERF ");            // �n���f�B�^�[�~�i���敪
                    sqlText.AppendLine(" ,I.INSPECTDATETIMERF ");             // ���i����
                    sqlText.AppendLine(" ,I.EMPLOYEECODERF ");                // �]�ƈ��R�[�h
                    sqlText.AppendLine(" FROM ( ");
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine("  SA.ENTERPRISECODERF ");
                    sqlText.AppendLine(" ,SA.STOCKSECTIONCDRF ");
                    sqlText.AppendLine(" ,SD.STOCKADJUSTSLIPNORF ");
                    sqlText.AppendLine(" ,SD.STOCKADJUSTROWNORF ");
                    sqlText.AppendLine(" ,SD.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" ,SD.MAKERNAMERF ");
                    sqlText.AppendLine(" ,SD.GOODSNORF ");
                    sqlText.AppendLine(" ,SD.GOODSNAMERF ");
                    sqlText.AppendLine(" ,SD.ADJUSTCOUNTRF ");
                    if (stockSlipFlg)
                    {
                        // �݌Ɏd�� 1�F�I��L��
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            sqlText.AppendLine(" ,SH.SUPPLIERSNMRF ");
                        }
                    }
                    else
                    {
                        // ��[�o�� 1�F�I��L��
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            sqlText.AppendLine(" ,NULL AS SUPPLIERSNMRF ");
                        }
                    }
                    sqlText.AppendLine(" ,SD.WAREHOUSECODERF ");
                    sqlText.AppendLine(" ,SD.WAREHOUSENAMERF ");
                    if (stockSlipFlg)
                    {
                        // �݌Ɏd�� 1�F�I��L��
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            sqlText.AppendLine(" ,SD.WAREHOUSESHELFNORF "); // �q�ɒI��
                        }
                    }
                    else
                    {
                        // ��[�o�� 1�F�I��L��
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            sqlText.AppendLine(" ,SS.WAREHOUSESHELFNORF "); // �q�ɒI��
                        }
                    }
                    sqlText.AppendLine(" ,SD.ADJUSTDATERF ");
                    sqlText.AppendLine(" ,SD.ACPAYSLIPCDRF ");
                    sqlText.AppendLine(" ,SD.ACPAYTRANSCDRF ");
                    sqlText.AppendLine(" FROM STOCKADJUSTRF AS SA WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" INNER JOIN STOCKADJUSTDTLRF AS SD WITH (READUNCOMMITTED) ");// �݌ɒ������׃f�[�^[INNER JOIN]==> �݌ɒ����f�[�^   
                    sqlText.AppendLine(" ON SD.ENTERPRISECODERF = SA.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND SD.STOCKADJUSTSLIPNORF = SA.STOCKADJUSTSLIPNORF ");

                    if (stockSlipFlg)
                    {
                        // �݌Ɏd�� 1�F�I��L��
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            sqlText.AppendLine(" LEFT JOIN STOCKACPAYHISTRF AS SH  WITH (READUNCOMMITTED) ");
                            sqlText.AppendLine(" ON SH.ENTERPRISECODERF=SD.ENTERPRISECODERF ");        // ��ƃR�[�h
                            sqlText.AppendLine( " AND SH.LOGICALDELETECODERF=0 " );                    // �_���폜�敪
                            sqlText.AppendLine( " AND SH.ACPAYTRANSCDRF=SD.ACPAYTRANSCDRF " );         // �󕥌�����敪
                            sqlText.AppendLine( " AND SH.ACPAYSLIPCDRF=SD.ACPAYSLIPCDRF " );           // �󕥌��`�[�敪
                            sqlText.AppendLine(" AND SH.ACPAYSLIPNUMRF=SD.STOCKADJUSTSLIPNORF ");      // �󕥌��`�[�ԍ�
                            sqlText.AppendLine(" AND SH.ACPAYSLIPROWNORF=SD.STOCKADJUSTROWNORF ");     // �󕥌��s�ԍ�
                            //sqlText.AppendLine(" AND SH.ACPAYTRANSCDRF=SD.ACPAYTRANSCDRF ");         // �󕥌�����敪
                            sqlText.AppendLine(" AND SH.GOODSNORF=SD.GOODSNORF ");                     // ���i�ԍ�
                            sqlText.AppendLine(" AND SH.GOODSMAKERCDRF=SD.GOODSMAKERCDRF ");           // ���i���[�J�[�R�[�h
                            sqlText.AppendLine(" AND SH.WAREHOUSECODERF=SD.WAREHOUSECODERF ");         // �q�ɃR�[�h
                        }
                    }
                    else
                    {
                        // ��[�o�� 1�F�I��L��
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            sqlText.AppendLine(" INNER JOIN WAREHOUSERF AS WH  WITH (READUNCOMMITTED) ");
                            sqlText.AppendLine(" ON WH.ENTERPRISECODERF=SD.ENTERPRISECODERF ");        // ��ƃR�[�h
                            sqlText.AppendLine(" AND WH.WAREHOUSECODERF=SD.WAREHOUSECODERF ");         // �q�ɃR�[�h
                            sqlText.AppendLine(" AND WH.LOGICALDELETECODERF=0 ");                      // �_���폜�敪
                            sqlText.AppendLine(" LEFT JOIN STOCKRF AS SS  WITH (READUNCOMMITTED) ");
                            sqlText.AppendLine(" ON SS.ENTERPRISECODERF=SD.ENTERPRISECODERF ");        // ��ƃR�[�h                        
                            sqlText.AppendLine(" AND SS.GOODSMAKERCDRF=SD.GOODSMAKERCDRF ");           // ���i���[�J�[�R�[�h
                            sqlText.AppendLine(" AND SS.GOODSNORF=SD.GOODSNORF ");                     // ���i�ԍ�
                            sqlText.AppendLine(" AND SS.WAREHOUSECODERF=WH.MAINMNGWAREHOUSECDRF ");    // �q�ɃR�[�h
                        }
                    }
                    // WHERE��
                    sqlText.AppendLine("WHERE ");
                    // ��ƃR�[�h
                    sqlText.AppendLine(" SA.ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

                    // �_���폜�敪�u0:�L���v�Œ�
//                    sqlText.AppendLine(" AND SD.LOGICALDELETECODERF = 0 ");
                    sqlText.AppendLine(" AND SA.LOGICALDELETECODERF = 0 ");

                    //���_�R�[�h
                    if (!String.IsNullOrEmpty( cndtnWork.SectionCode ) && !"00".Equals( cndtnWork.SectionCode ))
                    {
                        sqlText.AppendLine( " AND SA.STOCKSECTIONCDRF=@FINDSTOCKSECTIONCDRF " );
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add( "@FINDSTOCKSECTIONCDRF", SqlDbType.NChar );
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString( cndtnWork.SectionCode );
                    }
                    else
                    {
                        sqlText.AppendLine( " AND SA.STOCKSECTIONCDRF IS NOT NULL " );
                    }

                    if (stockSlipFlg)
                    {
                        // �݌Ɏd�� 1�F�I��L��
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            //sqlText.AppendLine( " AND SD.ACPAYSLIPCDRF=13 " );
                            sqlText.AppendLine( " AND SA.ACPAYSLIPCDRF=13 " );
                            sqlText.AppendLine(" AND SD.ACPAYTRANSCDRF IN(10,30) ");
                        }
                    }
                    else
                    {
                        // ��[�o�� 1�F�I��L��
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            //sqlText.AppendLine(" AND SD.ACPAYSLIPCDRF=70 ");
                            sqlText.AppendLine( " AND SA.ACPAYSLIPCDRF=70 " );
                            sqlText.AppendLine( " AND SD.ACPAYTRANSCDRF=30 " );
                        }
                    }

                    if (stockSlipFlg)
                    {
                        // �q�ɃR�[�h
                        #region [�q�ɃR�[�h]
                        // �݌Ɏd�� 1�F�I��L��A �q�ɃR�[�h���͂̏ꍇ
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            // �q�ɃR�[�h���͂̏ꍇ
                            if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                            {
                                sqlText.AppendLine(" AND SD.WAREHOUSECODERF=@FINDWAREHOUSECODE ");
                                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                                findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                            }
                        }
                    }
                    else
                    {
                        // ��[�o�� 1�F�I��L��̏ꍇ
                        if ((cndtnWork.TransReplenishOutWarehouse == 1))
                        {
                            // �ϑ���q�ɃR�[�h���͂̏ꍇ
                            if (!String.IsNullOrEmpty(cndtnWork.AfWarehouseCd))
                            {
                                sqlText.AppendLine(" AND SD.WAREHOUSECODERF=@FINDWAREHOUSECODE ");
                                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                                findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.AfWarehouseCd);
                            }

                            // �q�ɃR�[�h���͂̏ꍇ
                            if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                            {
                                sqlText.AppendLine(" AND WH.MAINMNGWAREHOUSECDRF=@MAINMNGWAREHOUSECD ");
                                SqlParameter findParaMainmngwarehouseCd = sqlCommand.Parameters.Add("@MAINMNGWAREHOUSECD", SqlDbType.NChar);
                                findParaMainmngwarehouseCd.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                            }
                        }
                    }
                    #endregion

                    // ���o�ד�(�J�n)
                    if (cndtnWork.St_SalesDate > DateTime.MinValue)
                    {
                        //sqlText.AppendLine(" AND SD.ADJUSTDATERF >= @SALESDATEST ");
                        sqlText.AppendLine(" AND SA.ADJUSTDATERF >= @SALESDATEST ");
                        SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add( "@SALESDATEST", SqlDbType.Int );
                        paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
                    }

                    // ���o�ד�(�I��)
                    if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                    {
                        //sqlText.AppendLine(" AND SD.ADJUSTDATERF <= @SALESDATEED ");
                        sqlText.AppendLine(" AND SA.ADJUSTDATERF <= @SALESDATEED ");
                        SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add( "@SALESDATEED", SqlDbType.Int );
                        paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
                    }

                    // ���i���[�J�[�R�[�h
                    if (cndtnWork.GoodsMakerCd > 0)
                    {
                        sqlText.AppendLine(" AND SD.GOODSMAKERCDRF=@FINDGOODSMAKERCD");
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(cndtnWork.GoodsMakerCd);
                    }
                    else
                    {
                        sqlText.AppendLine(" AND SD.GOODSMAKERCDRF > " + Zero);
                    }

                    //���i�ԍ�
                    if (!String.IsNullOrEmpty(cndtnWork.GoodsNo))
                    {
                        sqlText.AppendLine(" AND SD.GOODSNORF LIKE @FINDGOODSNO");
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                        //�O����v�����̏ꍇ
                        if (cndtnWork.GoodsNoSrchTyp == 1) cndtnWork.GoodsNo = cndtnWork.GoodsNo + "%";
                        //�����v�����̏ꍇ
                        if (cndtnWork.GoodsNoSrchTyp == 2) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo;
                        //�����܂������̏ꍇ
                        if (cndtnWork.GoodsNoSrchTyp == 3) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo + "%";
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(cndtnWork.GoodsNo);
                    }

                    sqlText.AppendLine(" ) AS ST ");
                    sqlText.AppendLine(" LEFT JOIN INSPECTDATARF AS I WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" ON ST.ENTERPRISECODERF = I.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND ST.STOCKADJUSTSLIPNORF = I.ACPAYSLIPNUMRF ");
                    sqlText.AppendLine(" AND ST.STOCKADJUSTROWNORF = I.ACPAYSLIPROWNORF ");
                    sqlText.AppendLine(" AND ST.ACPAYSLIPCDRF  =I.ACPAYSLIPCDRF ");
                    sqlText.AppendLine(" AND ST.ACPAYTRANSCDRF =I.ACPAYTRANSCDRF ");
                    // �_���폜�敪��0
                    sqlText.AppendLine(" AND I.LOGICALDELETECODERF = 0 ");

                    if (stockSlipFlg)
                    {
                        // �݌Ɏd�� 1�F�I��L��
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            // �p�^�[�� 0:�o�Ɍ��i
                            if (cndtnWork.Pattern == 0)
                            {
                                // ������>0
                                sqlText.AppendLine(" WHERE ST.ADJUSTCOUNTRF <0 ");
                            }
                            // �p�^�[�� 1:���Ɍ��i
                            else if (cndtnWork.Pattern == 1)
                            {
                                // ������>0
                                sqlText.AppendLine(" WHERE ST.ADJUSTCOUNTRF >0 ");
                            }
                        }
                    }
                    else
                    {
                        // ��[�o�� 1�F�I��L��
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            // ������>0
                            sqlText.AppendLine(" WHERE ST.ADJUSTCOUNTRF >0 ");
                        }
                    }

                    // �]�ƈ��R�[�h
                    if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
                    {
                        sqlText.AppendLine(" AND I.EMPLOYEECODERF =@FINDEMPLOYEECODE ");
                        SqlParameter ParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                        ParaEmployeeCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EmployeeCode);
                    }

                    // ���i��(�J�n)
                    if (cndtnWork.St_InspectDate > DateTime.MinValue)
                    {
                        sqlText.AppendLine(" AND I.INSPECTDATETIMERF >= @INSPECTDATETIMEST ");
                        SqlParameter ParaInspectDateTimeSt = sqlCommand.Parameters.Add("@INSPECTDATETIMEST", SqlDbType.BigInt);
                        ParaInspectDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.St_InspectDate);
                    }

                    // ���i��(�I��)
                    if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
                    {
                        if (cndtnWork.St_InspectDate == DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND (I.INSPECTDATETIMERF < @INSPECTDATETIMEED OR I.INSPECTDATETIMERF IS NULL)");
                        }
                        else
                        {
                            sqlText.AppendLine(" AND  I.INSPECTDATETIMERF < @INSPECTDATETIMEED ");
                        }
                        SqlParameter ParaInspectDateTimeEd = sqlCommand.Parameters.Add("@INSPECTDATETIMEED", SqlDbType.BigInt);
                        ParaInspectDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.Ed_InspectDate);
                    }

                    sqlText.AppendLine(" ORDER BY ");
                    sqlText.AppendLine("  ST.ADJUSTDATERF ");
                    sqlText.AppendLine(" ,ST.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" ,ST.GOODSNORF ");
                    sqlText.AppendLine(" ,ST.STOCKADJUSTSLIPNORF ");
                    sqlText.AppendLine(" ,ST.STOCKADJUSTROWNORF ");

                    sqlCommand.CommandText = sqlText.ToString();

                    // �N�G�����s���̃^�C���A�E�g���Ԃ�3600�b�ɐݒ肷��
                    sqlCommand.CommandTimeout = 3600;
                    using (SqlDataReader MyReader = sqlCommand.ExecuteReader())
                    {
                        while (MyReader.Read())
                        {
                            // �������ʍ݌ɒ����f�[�^�̊i�[
                            retList.Add(CopyStockAdjustDataFromReader(MyReader, cndtnWork));
                        }
                    }
                    if (retList != null && retList.Count > 0)
                    {
                        // �������ʂ���ꍇ�A�uctDB_NORMAL�v��߂�
                        Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        // �������ʂȂ��ꍇ�A�uNOT_FOUND�v��߂�
                        Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                }
                catch (SqlException ex)
                {
                    errMessage = ex.Message;
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    Status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    errMessage = ex.Message;
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchStockSlipProc Exception=" + ex.Message, Status);
                }
            }

            return Status;
        }

        /// <summary>
        /// �݌ɒ����f�[�^�̊i�[
        /// </summary>
        /// <param name="myReader">��������</param>
        /// <param name="cndtnWork">��������</param>
        /// <returns>���i�Ɖ�o����</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ����f�[�^�̊i�[���s���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private InspectRefDataWork CopyStockAdjustDataFromReader(SqlDataReader myReader, HandyInspectParamWork cndtnWork)
        {
            InspectRefDataWork resultWork = new InspectRefDataWork();
            // �`�[�ԍ�
            resultWork.SalesSlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF")).ToString();
            // �s�ԍ�
            resultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTROWNORF"));
            // ���o�ד�
            resultWork.ShipmentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
            // ���i�ԍ�
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            // ���i����
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            // ���i���[�J�[�R�[�h
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            // ���[�J�[����
            resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));

            // �݌Ɏd�� 1�F�I��L��
            if (cndtnWork.TransStockStockSlip == 1)
            {
                if (cndtnWork.Pattern == 0)
                {
                    // ���ɐ�:�[���Œ�
                    resultWork.InputCnt = 0;
                    // �o�ɐ�:������
                    resultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF")); ;
                    // ����於��
                    resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                }
                else if (cndtnWork.Pattern == 1)
                {
                    // ���ɐ�:������
                    resultWork.InputCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                    // �o�ɐ�:�[���Œ�
                    resultWork.ShipmentCnt = 0;
                    // ����於��
                    resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                }   
            }
            // ��[�o�� 1�F�I��L��
            else if (cndtnWork.TransReplenishOutWarehouse == 1)
            {
                // ���ɐ�:�[���Œ�
                resultWork.InputCnt = 0;
                // �o�ɐ�:������
                resultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                // ����於��
                resultWork.CustomerSnm = "";
            }

            // �q�ɃR�[�h
            resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            // �q�ɖ���
            resultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            // �q�ɒI��
            resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            // �󕥌��`�[�敪
            resultWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            // �󕥌�����敪
            resultWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            // ���i�S���҃R�[�h
            resultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            // ���i����
            resultWork.InspectDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("INSPECTDATETIMERF"));
            // ���i�X�e�[�^�X
            resultWork.InspectStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTSTATUSRF"));
            // �n���f�B�^�[�~�i���敪
            resultWork.HandTerminalCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDTERMINALCODERF"));
            // �f�[�^�\�[�X�敪 1:����f�[�^ 2:�d���f�[�^ 3:�݌Ɉړ��f�[�^ 4:�݌ɒ����f�[�^
            resultWork.DataSourceDiv = 4;

            return resultWork;
        }
        #endregion
        // --- ADD 3H ������ 2017/09/07----------<<<<<

        #region ���i�̂݃f�[�^���o����
        /// <summary>
        /// ���i�̂݃f�[�^���o����
        /// </summary>
        /// <param name="retList">�o�̓f�[�^</param>
        /// <param name="cndtnWork">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�̂݃f�[�^���o�������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private int SearchInspectProc(out ArrayList retList,
            HandyInspectParamWork cndtnWork, out string errMessage, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;
            SqlCommand SqlCommandInfo = null;
            retList = new ArrayList();

            using (SqlCommandInfo = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder SqlText = new StringBuilder();
                    SqlText.AppendLine(InspectSqlText(cndtnWork, ref SqlCommandInfo));
                    SqlCommandInfo.CommandText = SqlText.ToString();

                    // �N�G�����s���̃^�C���A�E�g���Ԃ�3600�b�ɐݒ肷��
                    SqlCommandInfo.CommandTimeout = 3600;
                    using (SqlDataReader myReader = SqlCommandInfo.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            // �������ʂ̊i�[
                            retList.Add(CopyDataFromReader(myReader, cndtnWork));

                            Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    if (retList.Count == 0)
                    {
                        // �������ʂȂ��ꍇ�A�uNOT_FOUND�v��߂�
                        Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                catch (SqlException ex)
                {
                    errMessage = ex.Message;
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    Status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    errMessage = ex.Message;
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchInspectProc Exception=" + ex.Message, Status);
                }
            }

            return Status;
        }

        /// <summary>
        /// ���i�̂݃f�[�^���o����
        /// </summary>
        /// <param name="cndtnWork">��������</param>
        /// <param name="sqlCommand"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�̂݃f�[�^�̌������s��</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private string InspectSqlText(HandyInspectParamWork cndtnWork, ref SqlCommand sqlCommand)
        {
            StringBuilder SqlText = new StringBuilder();

            SqlText.AppendLine(" SELECT ");
            SqlText.AppendLine(" I.ACPAYSLIPNUMRF ");   // �`�[�ԍ�
            SqlText.AppendLine(" ,I.ACPAYSLIPROWNORF");  // �s�ԍ�
            SqlText.AppendLine(" ,I.GOODSMAKERCDRF");         // ���i���[�J�[�R�[�h
            SqlText.AppendLine(" ,I.GOODSNORF");              // ���i�ԍ�
            SqlText.AppendLine(" ,G.GOODSNAMERF");              // ���i����
            SqlText.AppendLine(" ,M.MAKERNAMERF");              // ���i���[�J�[����
            SqlText.AppendLine(" ,(CASE WHEN I.ACPAYTRANSCDRF = 10 THEN I.INSPECTCNTRF ELSE 0 END) AS SHIPMENTCNTRF ");           //�o�ɐ�
            SqlText.AppendLine(" ,(CASE WHEN I.ACPAYTRANSCDRF = 11 THEN I.INSPECTCNTRF ELSE 0 END) AS INPUTCNTRF ");           //���ɐ�
            SqlText.AppendLine(" ,0 AS INPUTOUTDAYRF ");           //���o�ד�
            SqlText.AppendLine(" ,I.WAREHOUSECODERF");              // �q�ɃR�[�h
            SqlText.AppendLine(" ,W.WAREHOUSENAMERF ");           // �q�ɖ���
            SqlText.AppendLine(" ,S.WAREHOUSESHELFNORF");          // �q�ɒI��
            SqlText.AppendLine(" ,I.ACPAYSLIPCDRF");          // �󕥌��`�[�敪
            SqlText.AppendLine(" ,I.ACPAYTRANSCDRF");          // �󕥌�����敪
            SqlText.AppendLine(" ,I.INSPECTSTATUSRF");          // ���i�X�e�[�^�X
            SqlText.AppendLine(" ,I.HANDTERMINALCODERF");          // �n���f�B�^�[�~�i���敪
            SqlText.AppendLine(" ,I.LOGICALDELETECODERF ");   // �_���폜�敪
            SqlText.AppendLine(" ,I.INSPECTDATETIMERF ");   // ���i����
            SqlText.AppendLine(" ,I.EMPLOYEECODERF ");   // �]�ƈ��R�[�h
            // ���i�f�[�^
            SqlText.AppendLine(" FROM INSPECTDATARF AS I WITH (READUNCOMMITTED) ");
            // �q�Ƀ}�X�^
            SqlText.AppendLine(" LEFT JOIN WAREHOUSERF AS W WITH (READUNCOMMITTED) ");
            SqlText.AppendLine(" ON  W.ENTERPRISECODERF=I.ENTERPRISECODERF ");
            SqlText.AppendLine(" AND W.WAREHOUSECODERF=I.WAREHOUSECODERF ");
            // �݌Ƀ}�X�^
            SqlText.AppendLine(" LEFT JOIN STOCKRF AS S WITH (READUNCOMMITTED) ");
            SqlText.AppendLine(" ON  S.ENTERPRISECODERF=I.ENTERPRISECODERF ");
            SqlText.AppendLine(" AND S.WAREHOUSECODERF=I.WAREHOUSECODERF ");
            SqlText.AppendLine(" AND S.GOODSMAKERCDRF = I.GOODSMAKERCDRF");
            SqlText.AppendLine(" AND S.GOODSNORF = I.GOODSNORF");
            // ���i�}�X�^�i���[�U�[�o�^���j
            SqlText.Append(" LEFT JOIN GOODSURF AS G WITH (READUNCOMMITTED) ");
            SqlText.AppendLine(" ON  G.ENTERPRISECODERF=I.ENTERPRISECODERF ");
            SqlText.AppendLine(" AND G.GOODSMAKERCDRF = I.GOODSMAKERCDRF");
            SqlText.AppendLine(" AND G.GOODSNORF = I.GOODSNORF");
            // ���[�J�[�}�X�^�i���[�U�[�o�^���j
            SqlText.Append(" LEFT JOIN MAKERURF AS M WITH (READUNCOMMITTED) ");
            SqlText.AppendLine(" ON  M.ENTERPRISECODERF=I.ENTERPRISECODERF ");
            SqlText.AppendLine(" AND M.GOODSMAKERCDRF = I.GOODSMAKERCDRF");
            SqlText.AppendLine(" WHERE");
            // ��ƃR�[�h
            SqlText.AppendLine(" I.ENTERPRISECODERF=@ENTERPRISECODE");
            SqlParameter ParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            ParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

            //���_�R�[�h
            if (!String.IsNullOrEmpty(cndtnWork.SectionCode) && !"00".Equals(cndtnWork.SectionCode))
            {
                SqlText.AppendLine(" AND W.SECTIONCODERF=@FINDSECTIONCODE");
                SqlParameter ParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                ParaSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.SectionCode);
            }

            // ���敪
            if (cndtnWork.OrderDivCd == 0)
            {
                if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                {
                    SqlText.AppendLine(" AND (I.WAREHOUSECODERF=@FINDWAREHOUSECODE OR I.WAREHOUSECODERF = " + Zero.ToString() + ")");
                    SqlParameter ParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    ParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                {
                    SqlText.AppendLine(" AND I.WAREHOUSECODERF=@FINDWAREHOUSECODE");
                    SqlParameter ParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    ParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                }
                else
                {
                    SqlText.AppendLine(" AND (I.WAREHOUSECODERF IS NOT NULL AND I.WAREHOUSECODERF <> @FINDWAREHOUSECODE )");
                    SqlParameter ParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    ParaWarehouseCode.Value = SqlDataMediator.SqlSetString(Zero.ToString());
                }
            }

            //���i�ԍ�
            if (!String.IsNullOrEmpty(cndtnWork.GoodsNo))
            {
                SqlText.AppendLine(" AND I.GOODSNORF LIKE @GOODSNO");
                SqlParameter ParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                //�O����v�����̏ꍇ
                if (cndtnWork.GoodsNoSrchTyp == 1) cndtnWork.GoodsNo = cndtnWork.GoodsNo + "%";
                //�����v�����̏ꍇ
                if (cndtnWork.GoodsNoSrchTyp == 2) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo;
                //�����܂������̏ꍇ
                if (cndtnWork.GoodsNoSrchTyp == 3) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo + "%";
                ParaGoodsNo.Value = SqlDataMediator.SqlSetString(cndtnWork.GoodsNo);
            }

            // �]�ƈ��R�[�h
            if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
            {
                SqlText.AppendLine(" AND I.EMPLOYEECODERF = @FINDGEMPLOYEECODE");
                SqlParameter ParaEmployeeCode = sqlCommand.Parameters.Add("@FINDGEMPLOYEECODE", SqlDbType.NChar);
                ParaEmployeeCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EmployeeCode);
            }

            // ���i���[�J�[�R�[�h
            if (cndtnWork.GoodsMakerCd > 0)
            {
                SqlText.AppendLine(" AND I.GOODSMAKERCDRF = @FINDGGOODSMAKERCD");
                SqlParameter ParaGoodsMakerCode = sqlCommand.Parameters.Add("@FINDGGOODSMAKERCD", SqlDbType.Int);
                ParaGoodsMakerCode.Value = SqlDataMediator.SqlSetInt32(cndtnWork.GoodsMakerCd);
            }

            // �󕥌��s�ԍ�
            SqlText.AppendLine(" AND I.ACPAYSLIPROWNORF = @FINDACPAYSLIPROWNORF");
            SqlParameter ParaAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNORF", SqlDbType.Int);
            ParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(Zero);
            // �_���폜�敪
            SqlText.AppendLine(" AND I.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
            SqlParameter ParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            ParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

            // ���i��(�J�n)
            if (cndtnWork.St_InspectDate > DateTime.MinValue)
            {
                SqlText.AppendLine(" AND I.INSPECTDATETIMERF >= @INSPECTDATETIMEST ");
                SqlParameter ParaInspectDateTimeSt = sqlCommand.Parameters.Add("@INSPECTDATETIMEST", SqlDbType.BigInt);
                ParaInspectDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.St_InspectDate);
            }
            // ���i��(�I��)
            if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
            {
                SqlText.AppendLine(" AND  I.INSPECTDATETIMERF < @INSPECTDATETIMEED ");
                SqlParameter ParaInspectDateTimeEd = sqlCommand.Parameters.Add("@INSPECTDATETIMEED", SqlDbType.BigInt);
                ParaInspectDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.Ed_InspectDate);
            }
            SqlText.AppendLine(" ORDER BY I.INSPECTDATETIMERF ASC ");

            return SqlText.ToString();
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ����� false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Note        : SqlConnection���������B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/07/20</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection RetSqlConnection = null;

            // SqlConnection����
            SqlConnectionInfo ConnectionInfo = new SqlConnectionInfo();

            // SqlConnection�ڑ�
            string ConnectionText = ConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(ConnectionText))
            {
                RetSqlConnection = new SqlConnection(ConnectionText);

                if (open)
                {
                    RetSqlConnection.Open();
                }
            }
            else
            {
                base.WriteErrorLog("HandyInspectRefDataDB.CreateSqlConnection" + "�R�l�N�V�����擾���s");
            }

            // SqlConnection�Ԃ�
            return RetSqlConnection;
        }
        #endregion  // �R�l�N�V������������
    }
}
