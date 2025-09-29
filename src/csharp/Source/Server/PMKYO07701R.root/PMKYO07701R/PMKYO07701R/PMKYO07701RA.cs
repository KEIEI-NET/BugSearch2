//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �W�v�@�R���g���[��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �W�v�@�R���g���[��DB�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.4.29</br>
    /// <br></br>
    /// <br>Update Note: ���w�q�@2009.04.28 �S�f�[�^��ǉ�</br>
    /// </remarks>
    [Serializable]
    public class SKControlDB : RemoteWithAppLockDB, ISKControlDB
    {
        #region [�萔]
        private DCSalesSlipDB _salesslipDB = null;
        private DCSalesDetailDB _salesDetailDB = null;
        private DCSalesHistoryDB _salesHistoryDB = null;
        private DCSalesHistDtlDB _salesHistDtlDB = null;
        private DCDepsitMainDB _depsitMainDB = null;
        private DCDepsitDtlDB _depsitDtlDB = null;
        private DCStockSlipDB _stockSlipDB = null;
        private DCStockDetailDB _stockDetailDB = null;
        private DCStockSlipHistDB _stockSlipHistDB = null;
        private DCStockSlHistDtlDB _stockSlHistDtlDB = null;
        private DCPaymentSlpDB _paymentSlpDB = null;
        private DCPaymentDtlDB _paymentDtlDB = null;
        private DCAcceptOdrDB _acceptOdrDB = null;
        private DCAcceptOdrCarDB _acceptOdrCarDB = null;
        private DCMTtlSalesSlipDB _mTtlSalesSlipDB = null;
        private DCGoodsMTtlSaSlipDB _goodsMTtlSaSlipDB = null;
        private DCMTtlStockSlipDB _mTtlStockSlipDB = null;
        // �� 2009.04.28 liuyang add
        private DCStockAdjustDB _stockAdjustDB = null;
        private DCStockAdjustDtlDB _stockAdjustDtlDB = null;
        private DCStockMoveDB _stockMoveDB = null;
        private DCStockAcPayHistDB _stockAcPayHistDB = null;
        // �� 2009.04.28 liuyang add
        #endregion

        /// <summary>
        /// �W�v�@�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2008.4.24</br>
        /// </remarks>
        public SKControlDB()
        {
            // �ϐ�������
            _salesslipDB = new DCSalesSlipDB();
            _salesDetailDB = new DCSalesDetailDB();
            _salesHistoryDB = new DCSalesHistoryDB();
            _salesHistDtlDB = new DCSalesHistDtlDB();
            _depsitMainDB = new DCDepsitMainDB();
            _depsitDtlDB = new DCDepsitDtlDB();
            _stockSlipDB = new DCStockSlipDB();
            _stockDetailDB = new DCStockDetailDB();
            _stockSlipHistDB = new DCStockSlipHistDB();
            _stockSlHistDtlDB = new DCStockSlHistDtlDB();
            _paymentSlpDB = new DCPaymentSlpDB();
            _paymentDtlDB = new DCPaymentDtlDB();
            _acceptOdrDB = new DCAcceptOdrDB();
            _acceptOdrCarDB = new DCAcceptOdrCarDB();
            _mTtlSalesSlipDB = new DCMTtlSalesSlipDB();
            _goodsMTtlSaSlipDB = new DCGoodsMTtlSaSlipDB();
            _mTtlStockSlipDB = new DCMTtlStockSlipDB();
            // �� 2009.04.28 liuyang add
            _stockAdjustDB = new DCStockAdjustDB();
            _stockAdjustDtlDB = new DCStockAdjustDtlDB();
            _stockMoveDB = new DCStockMoveDB();
            _stockAcPayHistDB = new DCStockAcPayHistDB();
            // �� 2009.04.28 liuyang add
        }

        #region ���o
        /// <summary>
        /// �f�[�^���擾���܂��B
        /// </summary>
        /// <param name="outreceiveList">��������</param>
        /// <param name="parareceiveWork">��������</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="fileIds">�����f�[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.3.31</br>
        public int Search(out object outreceiveList, DCReceiveDataWork parareceiveWork, string sectionCode, string[] fileIds)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _salesSlipList = null;                       // ����f�[�^
            ArrayList _salesDetailList = null;                     // ���㖾�׃f�[�^
            ArrayList _salesHistoryList = null;                    // ���㗚���f�[�^
            ArrayList _salesHistDtlList = null;                    // ���㗚�𖾍׃f�[�^
            ArrayList _depsitMainList = null;                      // �����f�[�^
            ArrayList _depsitDtlList = null;                       // �������׃f�[�^
            ArrayList _stockSlipList = null;                       // �d���f�[�^
            ArrayList _stockDetailList = null;                     // �d�����׃f�[�^
            ArrayList _stockSlipHistList = null;                   // �d�������f�[�^
            ArrayList _stockSlHistDtlList = null;                  // �d�����𖾍׃f�[�^
            ArrayList _paymentSlpList = null;                      // �x���`�[�}�X�^
            ArrayList _paymentDtlList = null;                      // �x�����׃f�[�^
            ArrayList _acceptOdrList = null;                       // �󒍃}�X�^
            ArrayList _acceptOdrCarList = null;                    // �󒍃}�X�^�i�ԗ��j
            ArrayList _mTtlSalesSlipList = null;                   // ���㌎���W�v�f�[�^
            ArrayList _goodsMTtlSaSlipList = null;                 // ���i�ʔ��㌎���W�v�f�[�^
            ArrayList _mTtlStockSlipList = null;                   // �d�������W�v�f�[�^
            // �� 2009.04.28 liuyang add
            ArrayList _stockAdjustList = null;                     // �݌ɒ����f�[�^
            ArrayList _stockAdjustDtlList = null;                  // �݌ɒ������׃f�[�^
            ArrayList _stockMoveList = null;                       // �݌Ɉړ��f�[�^
            ArrayList _stockAcPayHistList = null;                  // �݌Ɏ󕥗����f�[�^
            // �� 2009.04.28 liuyang add

            DCReceiveDataWork receiveDataWork = parareceiveWork;


            outreceiveList = new CustomSerializeArrayList();

            try
            {
                if (parareceiveWork != null)
                {
                    // �R�l�N�V��������
                    sqlConnection = this.CreateSqlConnectionData(true);

                    sqlTransaction = this.CreateTransactionData(ref sqlConnection);

                    foreach (string fileId in fileIds)
                    {
                        switch (fileId)
                        {
                            case "SalesSlipRF":
                                {
                                    // ����f�[�^
                                    status = _salesslipDB.Search(out _salesSlipList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_salesSlipList != null && _salesSlipList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_salesSlipList);
                                    }
                                }
                                break;

                            case "SalesDetailRF":
                                {
                                    // ���㖾�׃f�[�^
                                    status = _salesDetailDB.Search(out _salesDetailList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_salesDetailList != null && _salesDetailList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_salesDetailList);
                                    }
                                }
                                break;

                            case "SalesHistoryRF":
                                {
                                    // ���㗚���f�[�^
                                    status = _salesHistoryDB.Search(out _salesHistoryList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_salesHistoryList != null && _salesHistoryList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_salesHistoryList);
                                    }
                                }
                                break;

                            case "SalesHistDtlRF":
                                {
                                    // ���㗚�𖾍׃f�[�^
                                    status = _salesHistDtlDB.Search(out _salesHistDtlList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_salesHistDtlList != null && _salesHistDtlList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_salesHistDtlList);
                                    }
                                }
                                break;

                            case "DepsitMainRF":
                                {
                                    // �����f�[�^
                                    status = _depsitMainDB.Search(out _depsitMainList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_depsitMainList != null && _depsitMainList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_depsitMainList);
                                    }
                                }
                                break;

                            case "DepsitDtlRF":
                                {
                                    // �������׃f�[�^
                                    status = _depsitDtlDB.Search(out _depsitDtlList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_depsitDtlList != null && _depsitDtlList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_depsitDtlList);
                                    }
                                }
                                break;

                            case "StockSlipRF":
                                {
                                    // �d���f�[�^
                                    status = _stockSlipDB.Search(out _stockSlipList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockSlipList != null && _stockSlipList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockSlipList);
                                    }
                                }
                                break;

                            case "StockDetailRF":
                                {
                                    // �d�����׃f�[�^
                                    status = _stockDetailDB.Search(out _stockDetailList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockDetailList != null && _stockDetailList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockDetailList);
                                    }
                                }
                                break;

                            case "StockSlipHistRF":
                                {
                                    // �d�������f�[�^
                                    status = _stockSlipHistDB.Search(out _stockSlipHistList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockSlipHistList != null && _stockSlipHistList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockSlipHistList);
                                    }
                                }
                                break;

                            case "StockSlHistDtlRF":
                                {
                                    // �d�����𖾍׃f�[�^
                                    status = _stockSlHistDtlDB.Search(out _stockSlHistDtlList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockSlHistDtlList != null && _stockSlHistDtlList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockSlHistDtlList);
                                    }
                                }
                                break;

                            case "PaymentSlpRF":
                                {
                                    // �x���`�[�}�X�^
                                    status = _paymentSlpDB.Search(out _paymentSlpList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_paymentSlpList != null && _paymentSlpList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_paymentSlpList);
                                    }
                                }
                                break;

                            case "PaymentDtlRF":
                                {
                                    // �x�����׃f�[�^
                                    status = _paymentDtlDB.Search(out _paymentDtlList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_paymentDtlList != null && _paymentDtlList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_paymentDtlList);
                                    }
                                }
                                break;

                            case "AcceptOdrRF":
                                {
                                    // �󒍃}�X�^
                                    status = _acceptOdrDB.Search(out _acceptOdrList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_acceptOdrList != null && _acceptOdrList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_acceptOdrList);
                                    }
                                }
                                break;

                            case "AcceptOdrCarRF":
                                {
                                    // �󒍃}�X�^�i�ԗ��j
                                    status = _acceptOdrCarDB.Search(out _acceptOdrCarList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_acceptOdrCarList != null && _acceptOdrCarList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_acceptOdrCarList);
                                    }
                                }
                                break;

                            case "MTtlSalesSlipRF":
                                {
                                    // ���㌎���W�v�f�[�^
                                    status = _mTtlSalesSlipDB.Search(out _mTtlSalesSlipList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_mTtlSalesSlipList != null && _mTtlSalesSlipList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_mTtlSalesSlipList);
                                    }
                                }
                                break;

                            case "GoodsMTtlSaSlipRF":
                                {
                                    // ���i�ʔ��㌎���W�v�f�[�^
                                    status = _goodsMTtlSaSlipDB.Search(out _goodsMTtlSaSlipList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_goodsMTtlSaSlipList != null && _goodsMTtlSaSlipList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_goodsMTtlSaSlipList);
                                    }
                                }
                                break;

                            case "MTtlStockSlipRF":
                                {
                                    // �d�������W�v�f�[�^
                                    status = _mTtlStockSlipDB.Search(out _mTtlStockSlipList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_mTtlStockSlipList != null && _mTtlStockSlipList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_mTtlStockSlipList);
                                    }
                                }
                                break;

                            case "StockAdjustRF":
                                {
                                    // �� 2009.04.28 liuyang add
                                    // �݌ɒ����f�[�^
                                    status = _stockAdjustDB.Search(out _stockAdjustList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockAdjustList != null && _stockAdjustList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockAdjustList);
                                    }
                                }
                                break;

                            case "StockAdjustDtlRF":
                                {
                                    // �݌ɒ������׃f�[�^
                                    status = _stockAdjustDtlDB.Search(out _stockAdjustDtlList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockAdjustDtlList != null && _stockAdjustDtlList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockAdjustDtlList);
                                    }
                                }
                                break;

                            case "StockMoveRF":
                                {
                                    // �݌Ɉړ��f�[�^
                                    status = _stockMoveDB.Search(out _stockMoveList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockMoveList != null && _stockMoveList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockMoveList);
                                    }
                                }
                                break;

                            case "StockAcPayHistRF":
                                {
                                    // �݌Ɏ󕥗����f�[�^
                                    status = _stockAcPayHistDB.Search(out _stockAcPayHistList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockAcPayHistList != null && _stockAcPayHistList.Count > 0)
                                    {
                                        // �ΏۊO���𔻒f
                                        ArrayList result = new ArrayList();
                                        foreach (DCStockAcPayHistWork stockAcPayHistWork in _stockAcPayHistList)
                                        {
                                            // �󕥌��`�[�敪��30:�ړ��o��,31:�ړ����ׂ̏ꍇ
                                            if (stockAcPayHistWork.AcPaySlipCd == 30 || stockAcPayHistWork.AcPaySlipCd == 31)
                                            {
                                                // ���_��v�̏ꍇ
                                                if (stockAcPayHistWork.SectionCode == sectionCode)
                                                {
                                                    result.Add(stockAcPayHistWork);
                                                }
                                            }
                                            else
                                            {
                                                result.Add(stockAcPayHistWork);
                                            }
                                        }

                                        (outreceiveList as CustomSerializeArrayList).Add(result);
                                    }
                                }
                                break;

                            default :
                                break;
                        }
                    }

                    // �� 2009.04.28 liuyang add
                }

                // �X�e�[�^�X
                if (outreceiveList != null)
                {
                    CustomSerializeArrayList dataList = (CustomSerializeArrayList)outreceiveList;
                    if (dataList.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException e)
            {
                base.WriteErrorLog(e, "DCControlDB.Search(out object outreceiveList, object parareceiveWork)", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DCControlDB.Search(out object outreceiveList, object parareceiveWork)", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        #endregion

        #region �X�V
        /// <summary>
        /// DC�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        public int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, out string retMessage)
        {
            //��STATUS������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMessage = string.Empty;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            string resNm = "";

            try
            {
                //���p�����[�^�`�F�b�N
                if (retCSAList == null || retCSAList.Count <= 0)
                {
                    base.WriteErrorLog(null, "�v���O�����G���[�B�p�����[�^�����ݒ�ł�");
                    return status;
                }

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnectionData(true);

#if DEBUG
                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif

                resNm = GetResourceName(enterpriseCode);
                //�`�o���b�N
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                for (int i = 0; i < retCSAList.Count; i++)
                {
                    ArrayList retCSATemList = (ArrayList)retCSAList[i];

                    if (retCSATemList.Count == 0) continue;

                    // DC����f�[�^�X�V����
                    if (retCSATemList[0] is DCSalesSlipWork)
                    {
                        DCSalesSlipDB _salesSlipDB = new DCSalesSlipDB();
                        // ���݂���f�[�^���폜����B
                        _salesSlipDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _salesSlipDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC���㖾�׃f�[�^�X�V����
                    if (retCSATemList[0] is DCSalesDetailWork)
                    {
                        DCSalesDetailDB _salesDetailDB = new DCSalesDetailDB();
                        // ���݂���f�[�^���폜����B
                        _salesDetailDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _salesDetailDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC���㗚���f�[�^�X�V����
                    if (retCSATemList[0] is DCSalesHistoryWork)
                    {
                        DCSalesHistoryDB _salesHistoryDB = new DCSalesHistoryDB();
                        // ���݂���f�[�^���폜����B
                        _salesHistoryDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _salesHistoryDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC���㗚�𖾍׃f�[�^�X�V����
                    if (retCSATemList[0] is DCSalesHistDtlWork)
                    {
                        DCSalesHistDtlDB _salesHistDtlDB = new DCSalesHistDtlDB();
                        // ���݂���f�[�^���폜����B
                        _salesHistDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _salesHistDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�����f�[�^�X�V����
                    if (retCSATemList[0] is DCDepsitMainWork)
                    {
                        DCDepsitMainDB _depsitMainDB = new DCDepsitMainDB();
                        // ���݂���f�[�^���폜����B
                        _depsitMainDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _depsitMainDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�������׃f�[�^�X�V����
                    if (retCSATemList[0] is DCDepsitDtlWork)
                    {
                        DCDepsitDtlDB _depsitDtlDB = new DCDepsitDtlDB();
                        // ���݂���f�[�^���폜����B
                        _depsitDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _depsitDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�d���f�[�^�X�V����
                    if (retCSATemList[0] is DCStockSlipWork)
                    {
                        DCStockSlipDB _stockSlipDB = new DCStockSlipDB();
                        // ���݂���f�[�^���폜����B
                        _stockSlipDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _stockSlipDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�d�����׃f�[�^�X�V����
                    if (retCSATemList[0] is DCStockDetailWork)
                    {
                        DCStockDetailDB _stockDetailDB = new DCStockDetailDB();
                        // ���݂���f�[�^���폜����B
                        _stockDetailDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _stockDetailDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�d�������f�[�^�X�V����
                    if (retCSATemList[0] is DCStockSlipHistWork)
                    {
                        DCStockSlipHistDB _stockSlipHistDB = new DCStockSlipHistDB();
                        // ���݂���f�[�^���폜����B
                        _stockSlipHistDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _stockSlipHistDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�d�����𖾍׃f�[�^�X�V����
                    if (retCSATemList[0] is DCStockSlHistDtlWork)
                    {
                        DCStockSlHistDtlDB _stockSlHistDtlDB = new DCStockSlHistDtlDB();
                        // ���݂���f�[�^���폜����B
                        _stockSlHistDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _stockSlHistDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�x���`�[�}�X�^�X�V����
                    if (retCSATemList[0] is DCPaymentSlpWork)
                    {
                        DCPaymentSlpDB _paymentSlpDB = new DCPaymentSlpDB();
                        // ���݂���f�[�^���폜����B
                        _paymentSlpDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _paymentSlpDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�x�����׃f�[�^�X�V����
                    if (retCSATemList[0] is DCPaymentDtlWork)
                    {
                        DCPaymentDtlDB _paymentDtlDB = new DCPaymentDtlDB();
                        // ���݂���f�[�^���폜����B
                        _paymentDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _paymentDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�󒍃}�X�^�X�V����
                    if (retCSATemList[0] is DCAcceptOdrWork)
                    {
                        DCAcceptOdrDB _acceptOdrDB = new DCAcceptOdrDB();
                        // ���݂���f�[�^���폜����B
                        _acceptOdrDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _acceptOdrDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�󒍃}�X�^�i�ԗ��j�X�V����
                    if (retCSATemList[0] is DCAcceptOdrCarWork)
                    {
                        DCAcceptOdrCarDB _acceptOdrCarDB = new DCAcceptOdrCarDB();
                        // ���݂���f�[�^���폜����B
                        _acceptOdrCarDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _acceptOdrCarDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC���㌎���W�v�f�[�^�X�V����
                    if (retCSATemList[0] is DCMTtlSalesSlipWork)
                    {
                        DCMTtlSalesSlipDB _mTtlSalesSlipDB = new DCMTtlSalesSlipDB();
                        // ���݂���f�[�^���폜����B
                        _mTtlSalesSlipDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _mTtlSalesSlipDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC���i�ʔ��㌎���W�v�f�[�^�X�V����
                    if (retCSATemList[0] is DCGoodsMTtlSaSlipWork)
                    {
                        DCGoodsMTtlSaSlipDB _goodsMTtlSaSlipDB = new DCGoodsMTtlSaSlipDB();
                        // ���݂���f�[�^���폜����B
                        _goodsMTtlSaSlipDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _goodsMTtlSaSlipDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�d�������W�v�f�[�^�X�V����
                    if (retCSATemList[0] is DCMTtlStockSlipWork)
                    {
                        DCMTtlStockSlipDB _mTtlStockSlipDB = new DCMTtlStockSlipDB();
                        // ���݂���f�[�^���폜����B
                        _mTtlStockSlipDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _mTtlStockSlipDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�݌ɒ����f�[�^�X�V����
                    if (retCSATemList[0] is DCStockAdjustWork)
                    {
                        DCStockAdjustDB _stockAdjustDB = new DCStockAdjustDB();
                        // ���݂���f�[�^���폜����B
                        _stockAdjustDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _stockAdjustDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�݌ɒ������׃f�[�^�X�V����
                    if (retCSATemList[0] is DCStockAdjustDtlWork)
                    {
                        DCStockAdjustDtlDB _stockAdjustDtlDB = new DCStockAdjustDtlDB();
                        // ���݂���f�[�^���폜����B
                        _stockAdjustDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _stockAdjustDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC�݌Ɉړ��f�[�^�X�V����
                    if (retCSATemList[0] is DCStockMoveWork)
                    {
                        DCStockMoveDB _stockMoveDB = new DCStockMoveDB();
                        // ���݂���f�[�^���폜����B
                        _stockMoveDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _stockMoveDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // // DC�݌Ɏ󕥗����f�[�^�X�V����
                    if (retCSATemList[0] is DCStockAcPayHistWork)
                    {
                        DCStockAcPayHistDB _stockAcPayHistDB = new DCStockAcPayHistDB();
                        // ���݂���f�[�^���폜����B
                        _stockAcPayHistDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // ���o�����f�[�^��o�^����B
                        _stockAcPayHistDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }

                sqlTransaction.Commit();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                if (sqlTransaction != null && sqlTransaction.Connection != null) sqlTransaction.Rollback();
                // ���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "SKControlDB.Update(Connection�t) SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                if (sqlTransaction != null && sqlTransaction.Connection != null) sqlTransaction.Rollback();
                // ���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "SKControlDB.Update(Connection�t) Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //�`�o�A�����b�N
                Release(resNm, sqlConnection, sqlTransaction);

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            //STATUS��߂�
            return status;
        }

        #endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlConnection CreateSqlConnectionData(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Summary_DB);

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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlTransaction CreateTransactionData(ref SqlConnection sqlconnection)
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
