//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �C �� ��  2009/04/29  �C�����e : �݌Ɍn�f�[�^�ƏW�v�@�Ή��̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �C �� ��  2009/07/06  �C�����e : �}�X�^����M�����̂`�o�o���b�N�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : Liangsd
// �C �� ��  2011/09/06 �C�����e :  Redmine#23918���_�Ǘ�����PG�ύX�ǉ��˗���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/09/08  �C�����e : Redmine #24562 �d�����׃f�[�^�̑��M�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : Liangsd
// �C �� ��  2011/09/09 �C�����e :  Redmine#246331�`�[6���ׂ̃G���[�ڍׂ��\��������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/09/15  �C�����e : Redmine #24562 �d�����׃f�[�^�̑��M�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21112 �v�ۓc
// �C �� ��  2011/09/28  �C�����e : ���������ς݂̔���f�[�^����߃`�F�b�N�ΏۊO�Ƃ��鏈����ǉ�
//                                 �����̔���E�d���f�[�^����߃`�F�b�N�ΏۊO�Ƃ��鏈����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/29  �C�����e : Redmine #8136 ���_�Ǘ��^��M�����̒��`�F�b�N�����ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/12/07  �C�����e : Redmine #8136 ���_�Ǘ��^��M�����̒��`�F�b�N�����ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/03/16  �C�����e : �^�C���A�E�g�Ή�(30�b��600�b)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �C �� ��  2012/07/24  �C�����e : ���_�Ǘ�DC���O���Ԓǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �C �� ��  2012/09/05  �C�����e : AP�A�����b�N���̏����ύX�i���b�N�o���Ȃ������ꍇ�̓A�����b�N���Ȃ��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �� �� ��  2012/10/16  �C�����e : ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�
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
    /// DC�R���g���[��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : DC�R���g���[��DB�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: ���m�@2009.04.28 �S�f�[�^��ǉ�</br>
    /// </remarks>
    [Serializable]
    public class DCControlDB : RemoteWithAppLockDB, IDCControlDB
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
		// DEl 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		//private DCMTtlSalesSlipDB _mTtlSalesSlipDB = null;
		//private DCGoodsMTtlSaSlipDB _goodsMTtlSaSlipDB = null;
		//private DCMTtlStockSlipDB _mTtlStockSlipDB = null;
		//private DCStockAcPayHistDB _stockAcPayHistDB = null;
		// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        // �� 2009.04.28 liuyang add
        private DCStockAdjustDB _stockAdjustDB = null;
        private DCStockAdjustDtlDB _stockAdjustDtlDB = null;       
		private DCStockMoveDB _stockMoveDB = null;
        // �� 2009.04.28 liuyang add
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		private DCDepositAlwDB _depositAlwDB = null;
		private DCRcvDraftDataDB _rcvDraftDataDB = null;
		private DCPayDraftDataDB _payDraftDataDB = null;
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        private ArrayList keylist = new ArrayList();//ADD by Liangsd   2011/09/09 Redmine #24633
        #endregion
        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
        #region �� Const Memebers ��
        private const String SALESSLIPRF = "SalesSlipRF";            //����f�[�^
        private const String SALESDETAILRF = "SalesDetailRF";        //���㖾�׃f�[�^
        private const String ACCEPTODRRF = "AcceptOdrRF";            //�󒍃}�X�^
        private const String ACCEPTODRCARRF = "AcceptOdrCarRF";      //�󒍃}�X�^�i�ԗ��j
        private const String SALESHISTORYRF = "SalesHistoryRF";      //���㗚���f�[�^
        private const String SALESHISTDTLRF = "SalesHistDtlRF";      //���㗚�𖾍׃f�[�^
        private const String DEPSITMAINRF = "DepsitMainRF";          //�����f�[�^
        private const String DEPSITDTLRF = "DepsitDtlRF";            //�������׃f�[�^
        private const String STOCKSLIPRF = "StockSlipRF";            //�d���f�[�^
        private const String STOCKDETAILRF = "StockDetailRF";        //�d�����׃f�[�^
        private const String STOCKADJUSTRF = "StockAdjustRF";        //�݌ɒ����f�[�^
        private const String STOCKSLIPHISTRF = "StockSlipHistRF";    //�d�������f�[�^
        private const String STOCKSLHISTDTLRF = "StockSlHistDtlRF";  //�d�����𖾍׃f�[�^
        private const String PAYMENTSLPRF = "PaymentSlpRF";          //�x���`�[�}�X�^
        private const String PAYMENTDTLRF = "PaymentDtlRF";          //�x�����׃f�[�^
        private const String STOCKADJUSTDTLRF = "StockAdjustDtlRF";  //�݌ɒ������׃f�[�^
        private const String STOCKMOVERF = "StockMoveRF";            //�݌Ɉړ��f�[�^
        private const String DEPOSITALWRF = "DepositAlwRF";          //���������}�X�^
        private const String RCVDRAFTDATARF = "RcvDraftDataRF";      //����`�f�[�^
        private const String PAYDRAFTDATARF = "PayDraftDataRF";      //�x����`�f�[�^
        #endregion �� Const Memebers ��
        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<

        /// <summary>
        /// DC�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2008.4.24</br>
        /// </remarks>
        public DCControlDB()
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
			// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			//_mTtlSalesSlipDB = new DCMTtlSalesSlipDB();
			//_goodsMTtlSaSlipDB = new DCGoodsMTtlSaSlipDB();
			//_mTtlStockSlipDB = new DCMTtlStockSlipDB();
			//_stockAcPayHistDB = new DCStockAcPayHistDB();
			// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
            // �� 2009.04.28 liuyang add
            _stockAdjustDB = new DCStockAdjustDB();
            _stockAdjustDtlDB = new DCStockAdjustDtlDB();
            _stockMoveDB = new DCStockMoveDB();
            // �� 2009.04.28 liuyang add
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			_depositAlwDB = new DCDepositAlwDB();
			_rcvDraftDataDB = new DCRcvDraftDataDB();
			_payDraftDataDB = new DCPayDraftDataDB();
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        }

        #region ���o
        #region [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
        /*
        /// <summary>
        /// �f�[�^���擾���܂��B
        /// </summary>
        /// <param name="outreceiveList">��������</param>
        /// <param name="parareceiveWork">��������</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="fileIds">�����f�[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ���m</br>
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

                            default:
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

		*/
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        #endregion

        // ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		 /// <summary>
        /// �f�[�^���擾���܂��B
        /// </summary>
        /// <param name="outreceiveList">��������</param>
        /// <param name="parareceiveWork">��������</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="fileIds">�����f�[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011.7.26</br>
        /// <br>Update Note : 2012/07/24 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 10801804-00�ARedmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
		public int SearchSCM(out object outreceiveList, DCReceiveDataWork parareceiveWork, string sectionCode, string[] fileIds)
		{
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
            //// �����J�n�������擾����B
            //DateTime startCurrentTime = new DateTime();
            //startCurrentTime = DateTime.Now;
            //string retMessage = string.Empty;
            //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
            string retMessage = string.Empty;
            string tempSndRcvFileID = string.Empty;
            Dictionary<string, string> tempSndRcvDic = new Dictionary<string, string>();
            ArrayList tempSndRcvHisResWorkList = new ArrayList();
            SndRcvHisTableWork tempSndRcvHisTableWork = new SndRcvHisTableWork();

            // ��ƃR�[�h
            tempSndRcvHisTableWork.EnterpriseCode = parareceiveWork.PmEnterpriseCode;
            // ���_�R�[�h
            tempSndRcvHisTableWork.SectionCode = sectionCode;
            // ����M�������O���M�ԍ�
            tempSndRcvHisTableWork.SndRcvHisConsNo = parareceiveWork.SndRcvHisConsNo;
            // ����M�敪:��M�����i�J�n�j
            tempSndRcvHisTableWork.SendOrReceiveDivCd = 3;
            // ����M����
            tempSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            // ���
            tempSndRcvHisTableWork.Kind = 0;
            // ����M���O���o�����敪
            tempSndRcvHisTableWork.SndLogExtraCondDiv = parareceiveWork.SndLogExtraCondDiv;
            // ���M���ƃR�[�h
            tempSndRcvHisTableWork.SendDestEpCode = parareceiveWork.SendDestEpCode;
            // ���M�拒�_�R�[�h
            tempSndRcvHisTableWork.SendDestSecCode = parareceiveWork.SendDestSecCode;
            // ����M���
            tempSndRcvHisTableWork.SndRcvCondition = 0;
            if (tempSndRcvHisTableWork.Kind == 0 && tempSndRcvHisTableWork.SndLogExtraCondDiv == 1)
            {
                if (parareceiveWork.StartDateTime.ToString().Length >= 8)
                {
                    //���M�ΏۊJ�n����
                    DateTime sndObjStartDate = new DateTime(int.Parse(parareceiveWork.StartDateTime.ToString().Substring(0, 4)), int.Parse(parareceiveWork.StartDateTime.ToString().Substring(4, 2)), int.Parse(parareceiveWork.StartDateTime.ToString().Substring(6, 2)));
                    tempSndRcvHisTableWork.SndObjStartDate = sndObjStartDate.Ticks;
                }
                else
                {
                    tempSndRcvHisTableWork.SndObjStartDate = 0;
                }
                //���M�ΏۏI������
                tempSndRcvHisTableWork.SndObjEndDate = parareceiveWork.EndDateTimeTicks;
            }
            else
            {
                //���M�ΏۊJ�n����
                tempSndRcvHisTableWork.SndObjStartDate = parareceiveWork.StartDateTime;
                //���M�ΏۏI������
                tempSndRcvHisTableWork.SndObjEndDate = parareceiveWork.EndDateTime;
            }
            // ����M�敪
            if (parareceiveWork.TempReceiveDiv == 2)
            {
                tempSndRcvHisTableWork.TempReceiveDiv = 2;
            }
            else
            {
                tempSndRcvHisTableWork.TempReceiveDiv = 1;
            }
            // �G���[���e
            tempSndRcvHisTableWork.SndRcvErrContents = retMessage;
            // ����M�t�@�C���h�c
            tempSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;

            SndRcvHisTableDB tempSndRcvHisTableDB = new SndRcvHisTableDB();
            tempSndRcvHisResWorkList.Add(tempSndRcvHisTableWork);
            object tempObjSndRcvHisResWorkList = tempSndRcvHisResWorkList as object;
            tempSndRcvHisTableDB.Write(ref tempObjSndRcvHisResWorkList);
            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			DCReceiveDataWork receiveDataWork = parareceiveWork;


            outreceiveList = new CustomSerializeArrayList();
			ArrayList resultList = new ArrayList();
			ArrayList saleAcpOdrList = new ArrayList();
			ArrayList stockAcpOdrList = new ArrayList();
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
									// ����f�[�^�A���㖾�׃f�[�^�A�󒍃}�X�^�A�󒍃}�X�^�i�ԗ��j
									receiveDataWork.DoSalesSlipFlg = true;
									receiveDataWork.DoStockDetailFlg = true;
									receiveDataWork.DoAcceptOdrFlg = true;
									receiveDataWork.DoAcceptOdrCarFlg = true;
									status = _salesslipDB.SearchSCM(out resultList, out saleAcpOdrList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										for (int i = 0; i < resultList.Count; i++)
										{
											(outreceiveList as CustomSerializeArrayList).Add(resultList[i]);
										}
									}
								}
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(SALESSLIPRF))
                                {
                                    tempSndRcvDic.Add(SALESSLIPRF, SALESSLIPRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(SALESDETAILRF))
                                {
                                    tempSndRcvDic.Add(SALESDETAILRF, SALESDETAILRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(ACCEPTODRRF))
                                {
                                    tempSndRcvDic.Add(ACCEPTODRRF, ACCEPTODRRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(ACCEPTODRCARRF))
                                {
                                    tempSndRcvDic.Add(ACCEPTODRCARRF, ACCEPTODRCARRF);
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "SalesHistoryRF":
								{
									// ���㗚���f�[�^�A���㗚�𖾍׃f�[�^
									receiveDataWork.DoSalesHistoryFlg = true;
									receiveDataWork.DoSalesHistDtlFlg = true;
									status = _salesHistoryDB.SearchSCM(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										for (int i = 0; i < resultList.Count; i++)
										{
											(outreceiveList as CustomSerializeArrayList).Add(resultList[i]);
										}
									}
								}
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(SALESHISTORYRF))
                                {
                                    tempSndRcvDic.Add(SALESHISTORYRF, SALESHISTORYRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(SALESHISTDTLRF))
                                {
                                    tempSndRcvDic.Add(SALESHISTDTLRF, SALESHISTDTLRF);
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "DepsitMainRF":
								{
									// �����f�[�^�A�������׃f�[�^
									receiveDataWork.DoDepsitMainFlg = true;
									receiveDataWork.DoDepsitDtlFlg = true;
									status = _depsitMainDB.SearchSCM(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										for (int i = 0; i < resultList.Count; i++)
										{
											(outreceiveList as CustomSerializeArrayList).Add(resultList[i]);
										}
									}
								}
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(DEPSITMAINRF))
                                {
                                    tempSndRcvDic.Add(DEPSITMAINRF, DEPSITMAINRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(DEPSITDTLRF))
                                {
                                    tempSndRcvDic.Add(DEPSITDTLRF, DEPSITDTLRF);
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "StockSlipRF":
								{
									// �d���f�[�^�A�d�����׃f�[�^,�󒍃}�X�^
									receiveDataWork.DoStockSlipFlg = true;
									receiveDataWork.DoStockDetailFlg = true;
									receiveDataWork.DoAcceptOdrFlg = true;
									//ArrayList newStockDtlList = new ArrayList();// DEL 2011/09/15
									//status = _stockSlipDB.SearchSCM(out resultList,out newStockDtlList, out stockAcpOdrList, receiveDataWork, ref sqlConnection, ref sqlTransaction);// DEL 2011/09/15
									status = _stockSlipDB.SearchSCM(out resultList, out stockAcpOdrList, receiveDataWork, ref sqlConnection, ref sqlTransaction);// ADD 2011/09/15
									if (resultList != null && resultList.Count > 0)
									{
										for (int i = 0; i < resultList.Count; i++)
										{
											(outreceiveList as CustomSerializeArrayList).Add(resultList[i]);
										}
									}
									// DEL 2011/09/15 ----------- >>>>>
									//// ADD 2011.09.08 ----------- >>>>>
									//// �d�����ׂ݂̂̏ꍇ
									//ArrayList onlyStockDtlList = new ArrayList();
									//string retMsg = string.Empty;
									//status = _stockDetailDB.Search(out onlyStockDtlList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									//if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
									//{
									//    if (onlyStockDtlList != null && onlyStockDtlList.Count > 0)
									//    {
									//        foreach (DCStockDetailWork tmpWork in onlyStockDtlList)
									//        {
									//            newStockDtlList.Add(tmpWork);
									//        }
									//    }
									//}
									//(outreceiveList as CustomSerializeArrayList).Add(newStockDtlList);
									//// ADD 2011.09.08 ----------- <<<<<
									// DEL 2011/09/15 ----------- <<<<<
								}
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(STOCKSLIPRF))
                                {
                                    tempSndRcvDic.Add(STOCKSLIPRF, STOCKSLIPRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(STOCKDETAILRF))
                                {
                                    tempSndRcvDic.Add(STOCKDETAILRF, STOCKDETAILRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(ACCEPTODRRF))
                                {
                                    tempSndRcvDic.Add(ACCEPTODRRF, ACCEPTODRRF);
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "StockSlipHistRF":
								{
									// �d�������f�[�^�A�d�����𖾍׃f�[�^
									receiveDataWork.DoStockSlipHistFlg = true;
									receiveDataWork.DoStockSlHistDtlFlg = true;
									status = _stockSlipHistDB.SearchSCM(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										for (int i = 0; i < resultList.Count; i++)
										{
											(outreceiveList as CustomSerializeArrayList).Add(resultList[i]);
										}
									}
								}
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(STOCKSLIPHISTRF))
                                {
                                    tempSndRcvDic.Add(STOCKSLIPHISTRF, STOCKSLIPHISTRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(STOCKSLHISTDTLRF))
                                {
                                    tempSndRcvDic.Add(STOCKSLHISTDTLRF, STOCKSLHISTDTLRF);
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "PaymentSlpRF":
								{
									// �x���`�[�}�X�^,�A�x�����׃f�[�^
									receiveDataWork.DoPaymentSlpFlg = true;
									receiveDataWork.DoPaymentDtlFlg = true;
									status = _paymentSlpDB.SearchSCM(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										for (int i = 0; i < resultList.Count; i++)
										{
											(outreceiveList as CustomSerializeArrayList).Add(resultList[i]);
										}
									}
								}
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(PAYMENTSLPRF))
                                {
                                    tempSndRcvDic.Add(PAYMENTSLPRF, PAYMENTSLPRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(PAYMENTDTLRF))
                                {
                                    tempSndRcvDic.Add(PAYMENTDTLRF, PAYMENTDTLRF);
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "StockAdjustRF":
								{
									// �݌ɒ����f�[�^
									status = _stockAdjustDB.Search(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										(outreceiveList as CustomSerializeArrayList).Add(resultList);
									}
								}
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(STOCKADJUSTRF))
                                {
                                    tempSndRcvDic.Add(STOCKADJUSTRF, STOCKADJUSTRF);
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "StockAdjustDtlRF":
								{
									// �݌ɒ������׃f�[�^
									status = _stockAdjustDtlDB.Search(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										(outreceiveList as CustomSerializeArrayList).Add(resultList);
									}
								}
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(STOCKADJUSTDTLRF))
                                {
                                    tempSndRcvDic.Add(STOCKADJUSTDTLRF, STOCKADJUSTDTLRF);
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
								break;

							case "StockMoveRF":
								{
									// �݌Ɉړ��f�[�^
									status = _stockMoveDB.Search(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										(outreceiveList as CustomSerializeArrayList).Add(resultList);
									}
								}
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(STOCKMOVERF))
                                {
                                    tempSndRcvDic.Add(STOCKMOVERF, STOCKMOVERF);
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "DepositAlwRF":
								{
									// ���������}�X�^
									status = _depositAlwDB.Search(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										(outreceiveList as CustomSerializeArrayList).Add(resultList);
									}
								}
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(DEPOSITALWRF))
                                {
                                    tempSndRcvDic.Add(DEPOSITALWRF, DEPOSITALWRF);
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "RcvDraftDataRF":
								{
									// ����`�f�[�^
									status = _rcvDraftDataDB.Search(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										(outreceiveList as CustomSerializeArrayList).Add(resultList);
									}
								}
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(RCVDRAFTDATARF))
                                {
                                    tempSndRcvDic.Add(RCVDRAFTDATARF, RCVDRAFTDATARF);
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "PayDraftDataRF":
								{
									// �x����`�f�[�^
									status = _payDraftDataDB.Search(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										(outreceiveList as CustomSerializeArrayList).Add(resultList);
									}
								}
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(PAYDRAFTDATARF))
                                {
                                    tempSndRcvDic.Add(PAYDRAFTDATARF, PAYDRAFTDATARF);
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
								break;

							default:
								break;

						}
					}
				}
				if (receiveDataWork.DoAcceptOdrFlg)
				{
					for (int cnt = 0; cnt < stockAcpOdrList.Count; cnt++)
					{
						saleAcpOdrList.Add(stockAcpOdrList[cnt]);
					}

					(outreceiveList as CustomSerializeArrayList).Add(saleAcpOdrList);
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
                retMessage = e.Message;    // ADD 2012/07/24 �L�w��
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "DCControlDB.Search(out object outreceiveList, object parareceiveWork)", status);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                retMessage = ex.Message;    // ADD 2012/07/24 �L�w��
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

            // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// �����I�����t���擾����B
            //DateTime endCurrentTime = new DateTime();
            //endCurrentTime = DateTime.Now;
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
            foreach (KeyValuePair<string, string> tempFileId in tempSndRcvDic)
            {
                if (string.IsNullOrEmpty(tempSndRcvFileID))
                {
                    tempSndRcvFileID = tempSndRcvFileID + tempFileId.Key;
                }
                else
                {
                    tempSndRcvFileID = tempSndRcvFileID + "," + tempFileId.Key;
                }

            }
            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<

            ArrayList sndRcvHisResWorkList = new ArrayList();
            SndRcvHisTableWork sndRcvHisTableWork = new SndRcvHisTableWork();

            // ��ƃR�[�h
            sndRcvHisTableWork.EnterpriseCode = receiveDataWork.PmEnterpriseCode;
            // ���_�R�[�h
            //sndRcvHisTableWork.SectionCode = receiveDataWork.PmSectionCode;//DEL 2012/10/16 ������ for redmine#31026
            sndRcvHisTableWork.SectionCode = sectionCode;//ADD 2012/10/16 ������ for redmine#31026
            // ����M�������O���M�ԍ�
            sndRcvHisTableWork.SndRcvHisConsNo = receiveDataWork.SndRcvHisConsNo;
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// ����M�敪
            //sndRcvHisTableWork.SendOrReceiveDivCd = 1;
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
            // ����M�敪:��M�����i�I���j
            sndRcvHisTableWork.SendOrReceiveDivCd = 4;
            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
            // ����M����
            //sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));//DEL 2012/10/16 ������ for redmine#31026
            sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));//ADD 2012/10/16 ������ for redmine#31026
            // ���
            sndRcvHisTableWork.Kind = 0;
            // ����M���O���o�����敪
            sndRcvHisTableWork.SndLogExtraCondDiv = receiveDataWork.SndLogExtraCondDiv;
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// �����J�n����
            //sndRcvHisTableWork.ProcStartDateTime = startCurrentTime.Ticks;
            //// �����I������
            //sndRcvHisTableWork.ProcEndDateTime = endCurrentTime.Ticks;
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
            // ���M���ƃR�[�h
            sndRcvHisTableWork.SendDestEpCode = receiveDataWork.SendDestEpCode;
            // ���M�拒�_�R�[�h
            sndRcvHisTableWork.SendDestSecCode = receiveDataWork.SendDestSecCode;
            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
            if (sndRcvHisTableWork.Kind == 0 && sndRcvHisTableWork.SndLogExtraCondDiv == 1)
            {
                if (receiveDataWork.StartDateTime.ToString().Length >= 8)
                {
                    //���M�ΏۊJ�n����
                    DateTime sndObjStartDate = new DateTime(int.Parse(receiveDataWork.StartDateTime.ToString().Substring(0, 4)), int.Parse(receiveDataWork.StartDateTime.ToString().Substring(4, 2)), int.Parse(receiveDataWork.StartDateTime.ToString().Substring(6, 2)));
                    sndRcvHisTableWork.SndObjStartDate = sndObjStartDate.Ticks;
                }
                else
                {
                    sndRcvHisTableWork.SndObjStartDate = 0;
                }
                //���M�ΏۏI������
                sndRcvHisTableWork.SndObjEndDate = receiveDataWork.EndDateTimeTicks;
            }
            else
            {
                //���M�ΏۊJ�n����
                sndRcvHisTableWork.SndObjStartDate = receiveDataWork.StartDateTime;
                //���M�ΏۏI������
                sndRcvHisTableWork.SndObjEndDate = receiveDataWork.EndDateTime;
            }
            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
            // ����M���
            if (status == 0)
            {
                sndRcvHisTableWork.SndRcvCondition = 0;
            }
            else
            {
                sndRcvHisTableWork.SndRcvCondition = 1;
            }
            // ����M�敪
            if (receiveDataWork.TempReceiveDiv == 2)
            {
                sndRcvHisTableWork.TempReceiveDiv = 2;
            }
            else
            {
                sndRcvHisTableWork.TempReceiveDiv = 1;
            }
            // �G���[���e
            sndRcvHisTableWork.SndRcvErrContents = retMessage;
            // ����M�t�@�C���h�c
            //sndRcvHisTableWork.SndRcvFileID = receiveDataWork.SndRcvFileID;//DEL 2012/10/16 ������ for redmine#31026
            sndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;//ADD 2012/10/16 ������ for redmine#31026
            
            SndRcvHisTableDB sndRcvHisTableDB = new SndRcvHisTableDB();
            sndRcvHisResWorkList.Add(sndRcvHisTableWork);
            object objSndRcvHisResWorkList = sndRcvHisResWorkList as object;
            sndRcvHisTableDB.Write(ref objSndRcvHisResWorkList);
            // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<
            return status;
		}

		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        #endregion

        #region �X�V
        #region [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
        /*
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
                // MOD 2009/07/06 --->>>
                //�`�o���b�N
                //status = Lock(resNm, sqlConnection, sqlTransaction);
                status = Lock(resNm, 1, sqlConnection, sqlTransaction);
                // MOD 2009/07/06 ---<<<

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                for ( int i = 0; i < retCSAList.Count; i++ )
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

                // DEL 2009/07/06--->>>
                // sqlTransaction.Commit();
                // DEL 2009/07/06---<<<

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                // DEL 2009/07/06--->>>
                // if (sqlTransaction != null && sqlTransaction.Connection != null) sqlTransaction.Rollback();
                // DEL 2009/07/06---<<<
                // ���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCControlDB.Update(Connection�t) SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                // DEL 2009/07/06--->>>
                // if (sqlTransaction != null && sqlTransaction.Connection != null) sqlTransaction.Rollback();
                // DEL 2009/07/06---<<<
                // ���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCControlDB.Update(Connection�t) Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // MOD 2009/07/06--->>>
                
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

                if (resNm != "")
                {
                    //�`�o�A�����b�N
                    status = Release(resNm, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }

                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                // MOD 2009/07/06---<<<
            }
            //STATUS��߂�
            return status;
        }		
        */
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        #endregion [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]

        // ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		/// <summary>
		/// DC�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɂȂ�</br>
		/// <br>Programmer : 杍^</br>
		/// <br>Date       : 2009.04.02</br>
        /// <br>Update Note : 2012/07/24 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 10801804-00�ARedmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
		/// </remarks>
		public int UpdateSCM(ref CustomSerializeArrayList retCSAList, string enterpriseCode, ArrayList logList, out string retMessage)
		{
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
            //// �����J�n���t���擾����B
            //DateTime startCurrentTime = new DateTime();
            //startCurrentTime = DateTime.Now;
            //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
            string tempSndRcvFileID = string.Empty;
            Dictionary<string, string> tempSndRcvDic = new Dictionary<string, string>();
            ArrayList tempSndRcvHisResWorkList = new ArrayList();
            SndRcvHisTableWork tempSndRcvHisTableWork = null;

            for (int i = 0; i < logList.Count; i++)
            {
                if (logList[i].GetType() == typeof(ArrayList))
                {
                    ArrayList tempLogList = logList[i] as ArrayList;

                    for (int j = 0; j < tempLogList.Count; j++)
                    {
                        if (tempLogList[j].GetType() == typeof(SndRcvHisWork))
                        {
                            tempSndRcvHisTableWork = new SndRcvHisTableWork();
                            // ��ƃR�[�h
                            tempSndRcvHisTableWork.EnterpriseCode = ((SndRcvHisWork)tempLogList[j]).EnterpriseCode;
                            // ���_�R�[�h
                            tempSndRcvHisTableWork.SectionCode = ((SndRcvHisWork)tempLogList[j]).SectionCode;
                            // ����M���𑗐M�ԍ�
                            tempSndRcvHisTableWork.SndRcvHisConsNo = ((SndRcvHisWork)tempLogList[j]).SndRcvHisConsNo;
                            // ����M�敪:���M�����i�J�n�j
                            tempSndRcvHisTableWork.SendOrReceiveDivCd = 0;
                            // ����M����
                            tempSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                            // ���
                            tempSndRcvHisTableWork.Kind = 0;
                            // ����M���O���o�����敪
                            tempSndRcvHisTableWork.SndLogExtraCondDiv = ((SndRcvHisWork)tempLogList[j]).SndLogExtraCondDiv;
                            // ���M���ƃR�[�h
                            tempSndRcvHisTableWork.SendDestEpCode = ((SndRcvHisWork)tempLogList[j]).SendDestEpCode;
                            // ���M�拒�_�R�[�h
                            tempSndRcvHisTableWork.SendDestSecCode = ((SndRcvHisWork)tempLogList[j]).SendDestSecCode;
                            //���M�ΏۊJ�n����
                            tempSndRcvHisTableWork.SndObjStartDate = ((SndRcvHisWork)tempLogList[j]).SndObjStartDate.Ticks;
                            //���M�ΏۏI������
                            tempSndRcvHisTableWork.SndObjEndDate = ((SndRcvHisWork)tempLogList[j]).SndObjEndDate.Ticks;
                            // ����M���
                            tempSndRcvHisTableWork.SndRcvCondition = 0;
                            // ����M�敪
                            tempSndRcvHisTableWork.TempReceiveDiv = 0;
                            // ����M�t�@�C���h�c
                            tempSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;

                            tempSndRcvHisResWorkList.Add(tempSndRcvHisTableWork);
                        }
                    }
                }
            }

            SndRcvHisTableDB tempSndRcvHisTableDB = new SndRcvHisTableDB();
            object tempObjSndRcvHisResWorkList = tempSndRcvHisResWorkList as object;
            tempSndRcvHisTableDB.Write(ref tempObjSndRcvHisResWorkList);
            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
            
			//��STATUS������
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			int status2 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			int status3 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			retMessage = string.Empty;
			SqlTransaction sqlTransaction = null;
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			string resNm = "";
			//����M���o�����������O
			SndRcvHisDB _logDB = new SndRcvHisDB();

#if !DEBUG
            IntentExclusiveLockComponent intentLockObj = null;
#endif
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
                // del 2012/09/05 >>>
                //status = Lock(resNm, 1, sqlConnection, sqlTransaction);

                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    return status;
                //}
                // del 2012/09/05 <<<
                // add 2012/09/05 >>>
                status2 = Lock(resNm, 1, sqlConnection, sqlTransaction);

                if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    return status2;
				}
                status2 = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                // add 2012/09/05 <<<
                // ADD 2011/08/22 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>
#if !DEBUG
                // �C���e���g���b�N���s��
                intentLockObj = new IntentExclusiveLockComponent(); // ���b�N���i���C���X�^���X
                // �C���e���g���b�N�Ώۂ�ݒ�
                string[] targetTables = new string[]{"SALESSLIPRF", "ACCEPTODRCARRF", "SALESDETAILRF", "SALESHISTORYRF"       // ����f�[�^�A�󒍃}�X�^�i�ԗ��j�A���㖾�׃f�[�^�A���㗚���f�[�^
                                    ,"SALESHISTDTLRF","STOCKSLIPRF", "STOCKDETAILRF","STOCKSLIPHISTRF"                        // ���㗚�𖾍׃f�[�^�A�d���f�[�^�A�d�����׃f�[�^�A�d�������f�[�^
                                    ,"STOCKSLHISTDTLRF", "STOCKADJUSTRF", "STOCKADJUSTDTLRF", "STOCKMOVERF", "ACCEPTODRRF"};  // �d�����𖾍׃f�[�^�A�݌ɒ����f�[�^�A�݌ɒ������׃f�[�^�A�݌Ɉړ��f�[�^�A�󒍃}�X�^
                status = intentLockObj.IntentLock(targetTables);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    return status;
#endif
                // ADD 2011/08/22 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<

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
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(SALESSLIPRF))
                        {
                            tempSndRcvDic.Add(SALESSLIPRF, SALESSLIPRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC���㖾�׃f�[�^�X�V����
					if (retCSATemList[0] is DCSalesDetailWork)
					{
						DCSalesDetailDB _salesDetailDB = new DCSalesDetailDB();
						// ���݂���f�[�^���폜����B
						_salesDetailDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_salesDetailDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(SALESDETAILRF))
                        {
                            tempSndRcvDic.Add(SALESDETAILRF, SALESDETAILRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC���㗚���f�[�^�X�V����
					if (retCSATemList[0] is DCSalesHistoryWork)
					{
						DCSalesHistoryDB _salesHistoryDB = new DCSalesHistoryDB();
						// ���݂���f�[�^���폜����B
						_salesHistoryDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_salesHistoryDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(SALESHISTORYRF))
                        {
                            tempSndRcvDic.Add(SALESHISTORYRF, SALESHISTORYRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC���㗚�𖾍׃f�[�^�X�V����
					if (retCSATemList[0] is DCSalesHistDtlWork)
					{
						DCSalesHistDtlDB _salesHistDtlDB = new DCSalesHistDtlDB();
						// ���݂���f�[�^���폜����B
						_salesHistDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_salesHistDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(SALESHISTDTLRF))
                        {
                            tempSndRcvDic.Add(SALESHISTDTLRF, SALESHISTDTLRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC�����f�[�^�X�V����
					if (retCSATemList[0] is DCDepsitMainWork)
					{
						DCDepsitMainDB _depsitMainDB = new DCDepsitMainDB();
						// ���݂���f�[�^���폜����B
						_depsitMainDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_depsitMainDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(DEPSITMAINRF))
                        {
                            tempSndRcvDic.Add(DEPSITMAINRF, DEPSITMAINRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC�������׃f�[�^�X�V����
					if (retCSATemList[0] is DCDepsitDtlWork)
					{
						DCDepsitDtlDB _depsitDtlDB = new DCDepsitDtlDB();
						// ���݂���f�[�^���폜����B
						_depsitDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_depsitDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(DEPSITDTLRF))
                        {
                            tempSndRcvDic.Add(DEPSITDTLRF, DEPSITDTLRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC�d���f�[�^�X�V����
					if (retCSATemList[0] is DCStockSlipWork)
					{
						DCStockSlipDB _stockSlipDB = new DCStockSlipDB();
						// ���݂���f�[�^���폜����B
						_stockSlipDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_stockSlipDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKSLIPRF))
                        {
                            tempSndRcvDic.Add(STOCKSLIPRF, STOCKSLIPRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC�d�����׃f�[�^�X�V����
					if (retCSATemList[0] is DCStockDetailWork)
					{
						DCStockDetailDB _stockDetailDB = new DCStockDetailDB();
						// ���݂���f�[�^���폜����B
						_stockDetailDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_stockDetailDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKDETAILRF))
                        {
                            tempSndRcvDic.Add(STOCKDETAILRF, STOCKDETAILRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC�d�������f�[�^�X�V����
					if (retCSATemList[0] is DCStockSlipHistWork)
					{
						DCStockSlipHistDB _stockSlipHistDB = new DCStockSlipHistDB();
						// ���݂���f�[�^���폜����B
						_stockSlipHistDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_stockSlipHistDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKSLIPHISTRF))
                        {
                            tempSndRcvDic.Add(STOCKSLIPHISTRF, STOCKSLIPHISTRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC�d�����𖾍׃f�[�^�X�V����
					if (retCSATemList[0] is DCStockSlHistDtlWork)
					{
						DCStockSlHistDtlDB _stockSlHistDtlDB = new DCStockSlHistDtlDB();
						// ���݂���f�[�^���폜����B
						_stockSlHistDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_stockSlHistDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKSLHISTDTLRF))
                        {
                            tempSndRcvDic.Add(STOCKSLHISTDTLRF, STOCKSLHISTDTLRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC�x���`�[�}�X�^�X�V����
					if (retCSATemList[0] is DCPaymentSlpWork)
					{
						DCPaymentSlpDB _paymentSlpDB = new DCPaymentSlpDB();
						// ���݂���f�[�^���폜����B
						_paymentSlpDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_paymentSlpDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(PAYMENTSLPRF))
                        {
                            tempSndRcvDic.Add(PAYMENTSLPRF, PAYMENTSLPRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC�x�����׃f�[�^�X�V����
					if (retCSATemList[0] is DCPaymentDtlWork)
					{
						DCPaymentDtlDB _paymentDtlDB = new DCPaymentDtlDB();
						// ���݂���f�[�^���폜����B
						_paymentDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_paymentDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(PAYMENTDTLRF))
                        {
                            tempSndRcvDic.Add(PAYMENTDTLRF, PAYMENTDTLRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC�󒍃}�X�^�X�V����
					if (retCSATemList[0] is DCAcceptOdrWork)
					{
						DCAcceptOdrDB _acceptOdrDB = new DCAcceptOdrDB();
						// ���݂���f�[�^���폜����B
						_acceptOdrDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_acceptOdrDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(ACCEPTODRRF))
                        {
                            tempSndRcvDic.Add(ACCEPTODRRF, ACCEPTODRRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC�󒍃}�X�^�i�ԗ��j�X�V����
					if (retCSATemList[0] is DCAcceptOdrCarWork)
					{
						DCAcceptOdrCarDB _acceptOdrCarDB = new DCAcceptOdrCarDB();
						// ���݂���f�[�^���폜����B
						_acceptOdrCarDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_acceptOdrCarDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(ACCEPTODRCARRF))
                        {
                            tempSndRcvDic.Add(ACCEPTODRCARRF, ACCEPTODRCARRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					
					// DC�݌ɒ����f�[�^�X�V����
					if (retCSATemList[0] is DCStockAdjustWork)
					{
						DCStockAdjustDB _stockAdjustDB = new DCStockAdjustDB();
						// ���݂���f�[�^���폜����B
						_stockAdjustDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_stockAdjustDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKADJUSTRF))
                        {
                            tempSndRcvDic.Add(STOCKADJUSTRF, STOCKADJUSTRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC�݌ɒ������׃f�[�^�X�V����
					if (retCSATemList[0] is DCStockAdjustDtlWork)
					{
						DCStockAdjustDtlDB _stockAdjustDtlDB = new DCStockAdjustDtlDB();
						// ���݂���f�[�^���폜����B
						_stockAdjustDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_stockAdjustDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKADJUSTDTLRF))
                        {
                            tempSndRcvDic.Add(STOCKADJUSTDTLRF, STOCKADJUSTDTLRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC�݌Ɉړ��f�[�^�X�V����
					if (retCSATemList[0] is DCStockMoveWork)
					{
						DCStockMoveDB _stockMoveDB = new DCStockMoveDB();
						// ���݂���f�[�^���폜����B
						_stockMoveDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_stockMoveDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKMOVERF))
                        {
                            tempSndRcvDic.Add(STOCKMOVERF, STOCKMOVERF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					
					// ���������}�X�^
					if (retCSATemList[0] is DCDepositAlwWork)
					{
						DCDepositAlwDB _depositAlwDB = new DCDepositAlwDB();
						// ���݂���f�[�^���폜����B
						_depositAlwDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_depositAlwDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(DEPOSITALWRF))
                        {
                            tempSndRcvDic.Add(DEPOSITALWRF, DEPOSITALWRF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// ����`�f�[�^
					if (retCSATemList[0] is DCRcvDraftDataWork)
					{
						DCRcvDraftDataDB _rcvDraftDataDB = new DCRcvDraftDataDB();
						// ���݂���f�[�^���폜����B
						_rcvDraftDataDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_rcvDraftDataDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(RCVDRAFTDATARF))
                        {
                            tempSndRcvDic.Add(RCVDRAFTDATARF, RCVDRAFTDATARF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
					// �x����`�f�[�^
					if (retCSATemList[0] is DCPayDraftDataWork)
					{
						DCPayDraftDataDB _payDraftDataDB = new DCPayDraftDataDB();
						// ���݂���f�[�^���폜����B
						_payDraftDataDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// ���o�����f�[�^��o�^����B
						_payDraftDataDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(PAYDRAFTDATARF))
                        {
                            tempSndRcvDic.Add(PAYDRAFTDATARF, PAYDRAFTDATARF);
                        }
                        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
					}
				}

                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                foreach (KeyValuePair<string, string> tempFileId in tempSndRcvDic)
                {
                    if (string.IsNullOrEmpty(tempSndRcvFileID))
                    {
                        tempSndRcvFileID = tempSndRcvFileID + tempFileId.Key;
                    }
                    else
                    {
                        tempSndRcvFileID = tempSndRcvFileID + "," + tempFileId.Key;
                    }

                }
                ArrayList temSndRcvHisTableWorkList = new ArrayList();
                SndRcvHisTableWork temSndRcvHisTableWork = null;

                for (int i = 0; i < logList.Count; i++)
                {
                    if (logList[i].GetType() == typeof(ArrayList))
                    {
                        ArrayList temLogList = logList[i] as ArrayList;

                        for (int j = 0; j < temLogList.Count; j++)
                        {
                            if (temLogList[j].GetType() == typeof(SndRcvHisWork))
                            {
                                temSndRcvHisTableWork = new SndRcvHisTableWork();
                                // ��ƃR�[�h
                                temSndRcvHisTableWork.EnterpriseCode = ((SndRcvHisWork)temLogList[j]).EnterpriseCode;
                                // ���_�R�[�h
                                temSndRcvHisTableWork.SectionCode = ((SndRcvHisWork)temLogList[j]).SectionCode;
                                // ����M���𑗐M�ԍ�
                                temSndRcvHisTableWork.SndRcvHisConsNo = ((SndRcvHisWork)temLogList[j]).SndRcvHisConsNo;
                                // ����M�敪:���M�����i�I���j
                                temSndRcvHisTableWork.SendOrReceiveDivCd = 1;
                                // ����M����
                                temSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                                // ���
                                temSndRcvHisTableWork.Kind = 0;
                                // ����M���O���o�����敪
                                temSndRcvHisTableWork.SndLogExtraCondDiv = ((SndRcvHisWork)temLogList[j]).SndLogExtraCondDiv;
                                // ���M���ƃR�[�h
                                temSndRcvHisTableWork.SendDestEpCode = ((SndRcvHisWork)temLogList[j]).SendDestEpCode;
                                // ���M�拒�_�R�[�h
                                temSndRcvHisTableWork.SendDestSecCode = ((SndRcvHisWork)temLogList[j]).SendDestSecCode;
                                //���M�ΏۊJ�n����
                                temSndRcvHisTableWork.SndObjStartDate = ((SndRcvHisWork)temLogList[j]).SndObjStartDate.Ticks;
                                //���M�ΏۏI������
                                temSndRcvHisTableWork.SndObjEndDate = ((SndRcvHisWork)temLogList[j]).SndObjEndDate.Ticks;
                                // ����M���
                                temSndRcvHisTableWork.SndRcvCondition = 0;
                                // ����M�敪
                                temSndRcvHisTableWork.TempReceiveDiv = 0;
                                // ����M�t�@�C���h�c
                                temSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;

                                temSndRcvHisTableWorkList.Add(temSndRcvHisTableWork);
                            }
                        }
                    }
                }

                SndRcvHisTableDB temSndRcvHisTableDB = new SndRcvHisTableDB();
                object temObjSndRcvHisTableWorkList = temSndRcvHisTableWorkList as object;
                temSndRcvHisTableDB.Write(ref temObjSndRcvHisTableWorkList);
                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
				//�������O
				status3 = _logDB.WriteProc(logList, ref sqlConnection, ref sqlTransaction);

				if (status3 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					status = status3;
				}
				else
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}

			}
			catch (SqlException ex)
			{
				// ���N���X�ɗ�O��n���ď������Ă��炤
				base.WriteErrorLog(ex, "DCControlDB.Update(Connection�t) SqlException=" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                retMessage = ex.Message;    // ADD 2012/07/24 �L�w��
			}
			catch (Exception ex)
			{
				// ���N���X�ɗ�O��n���ď������Ă��炤
				base.WriteErrorLog(ex, "DCControlDB.Update(Connection�t) Exception=" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                retMessage = ex.Message;    // ADD 2012/07/24 �L�w��
			}
			finally
			{
                // ADD 2011/08/22 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>
#if !DEBUG
                if (null != intentLockObj)
                {
                    // �C���e���g���b�N����
                    intentLockObj.UnLock();
                }
#endif
                // ADD 2011/08/22 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<

                // upd 2012/09/05 >>>
                //if (resNm != "")
                if (resNm != "" && status2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                // upd 2012/09/05 <<<
				{
					//�`�o�A�����b�N
					status2 = Release(resNm, sqlConnection, sqlTransaction);
					if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
					}
				}

				if (sqlTransaction != null)
				{
					if (sqlTransaction.Connection != null)
					{
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							sqlTransaction.Commit();
						}
						else
						{
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
				if (sqlCommand != null)
				{
					sqlCommand.Cancel();
					sqlCommand.Dispose();
				}
			}
            // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// �����I�����t���擾����B
            //DateTime endCurrentTime = new DateTime();
            //endCurrentTime = DateTime.Now;
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<

            ArrayList sndRcvHisResWorkList = new ArrayList();
            SndRcvHisTableWork sndRcvHisTableWork = new SndRcvHisTableWork();

            for (int i = 0; i < logList.Count; i++)
            {
                if (logList[i].GetType() == typeof(ArrayList))
                {
                     ArrayList al= logList[i] as ArrayList;

                     for (int j = 0; j < al.Count; j++)
                    {
                        if (al[j].GetType() == typeof(SndRcvHisWork))
                        {
                            // ��ƃR�[�h
                            sndRcvHisTableWork.EnterpriseCode = ((SndRcvHisWork)al[j]).EnterpriseCode;
                            // ���_�R�[�h
                            sndRcvHisTableWork.SectionCode = ((SndRcvHisWork)al[j]).SectionCode;
                            // ����M���𑗐M�ԍ�
                            sndRcvHisTableWork.SndRcvHisConsNo = ((SndRcvHisWork)al[j]).SndRcvHisConsNo;
                            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                            //// ����M�敪
                            //sndRcvHisTableWork.SendOrReceiveDivCd = 0;
                            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            // ����M�敪:���M�����i����M�����X�V�j
                            sndRcvHisTableWork.SendOrReceiveDivCd = 2;
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                            // ����M����
                            //sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));//DEL 2012/10/16 ������ for redmine#31026
                            sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));//ADD 2012/10/16 ������ for redmine#31026
                            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                            //// �����J�n����
                            //sndRcvHisTableWork.ProcStartDateTime = startCurrentTime.Ticks;
                            //// �����I������
                            //sndRcvHisTableWork.ProcEndDateTime = endCurrentTime.Ticks;
                            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                            // ���
                            sndRcvHisTableWork.Kind = 0;
                            // ����M���O���o�����敪
                            sndRcvHisTableWork.SndLogExtraCondDiv = ((SndRcvHisWork)al[j]).SndLogExtraCondDiv;
                            // ���M���ƃR�[�h
                            sndRcvHisTableWork.SendDestEpCode = ((SndRcvHisWork)al[j]).SendDestEpCode;
                            // ���M�拒�_�R�[�h
                            sndRcvHisTableWork.SendDestSecCode = ((SndRcvHisWork)al[j]).SendDestSecCode;
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            //���M�ΏۊJ�n����
                            sndRcvHisTableWork.SndObjStartDate = ((SndRcvHisWork)al[j]).SndObjStartDate.Ticks;
                            //���M�ΏۏI������
                            sndRcvHisTableWork.SndObjEndDate = ((SndRcvHisWork)al[j]).SndObjEndDate.Ticks;
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                            // ����M���
                            if (status == 0)
                            {
                                sndRcvHisTableWork.SndRcvCondition = 0;
                            }
                            else
                            {
                                sndRcvHisTableWork.SndRcvCondition = 1;
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                // �G���[���e
                                if (string.IsNullOrEmpty(retMessage))
                                {
                                    sndRcvHisTableWork.SndRcvErrContents = "�������O�X�V���s���܂����B";
                                }
                                else
                                {
                                    sndRcvHisTableWork.SndRcvErrContents = retMessage;
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                            }
                            // ����M�敪
                            sndRcvHisTableWork.TempReceiveDiv = 0;
                            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                            //// �G���[���e
                            //sndRcvHisTableWork.SndRcvErrContents = retMessage;
                            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                            // ����M�t�@�C���h�c
                            //sndRcvHisTableWork.SndRcvFileID = ((SndRcvHisWork)al[j]).SndRcvFileID;//DEL 2012/10/16 ������ for redmine#31026 
                            sndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;//ADD 2012/10/16 ������ for redmine#31026
                        }
                    }
                }
            }

            SndRcvHisTableDB sndRcvHisTableDB = new SndRcvHisTableDB();
            sndRcvHisResWorkList.Add(sndRcvHisTableWork);
            object objSndRcvHisResWorkList = sndRcvHisResWorkList as object;
            sndRcvHisTableDB.Write(ref objSndRcvHisResWorkList);

            // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<

			//STATUS��߂�
			return status;
		}
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

        #endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlConnection CreateSqlConnectionData(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);

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
        /// <br>Programmer : ���m</br>
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

		#region [���߃`�F�b�N]
		// ADD 2011/07/26 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		/// <summary>
		/// ���߃`�F�b�N���܂��B
		/// </summary>
		/// <param name="outErrorList">��������</param>
		/// <param name="parareceiveWork">��������</param>
		/// <param name="salesSimeDate">������ߓ�</param>
		/// <param name="StockSimeDate">�d�����ߓ�</param>
		/// <param name="saleCheckFlg">����`�F�b�N�t���O</param>
		/// <param name="depsitCheckFlg">�����`�F�b�N�t���O</param>
		/// <param name="stockCheckFlg">�d���`�F�b�N�t���O</param>
		/// <param name="paymentCheckFlg">�x�����`�F�b�N�t���O</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���߃`�F�b�N</br>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011.07.21</br>
		public int SimeCheckSCM(out ArrayList outErrorList, DCReceiveDataWork parareceiveWork,
            Int64 salesSimeDate, Int64 StockSimeDate, bool saleCheckFlg, bool depsitCheckFlg, bool stockCheckFlg, bool paymentCheckFlg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			DCReceiveDataWork receiveDataWork = parareceiveWork;
            outErrorList = new ArrayList();
			try
			{
				if (parareceiveWork != null)
				{
					// �R�l�N�V��������
					sqlConnection = this.CreateSqlConnectionData(true);
					sqlTransaction = this.CreateTransactionData(ref sqlConnection);

                    status = this.SimeCheckProcSCM(out outErrorList, parareceiveWork, salesSimeDate, StockSimeDate,
						saleCheckFlg, depsitCheckFlg, stockCheckFlg, paymentCheckFlg, ref sqlConnection, ref sqlTransaction);

				}
			}
			catch (SqlException e)
			{
				base.WriteErrorLog(e, "DCControlDB.simeCheckSCM(out object outerrorList, object parareceiveWork)", status);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "DCControlDB.simeCheckSCM(out object outerrorList, object parareceiveWork)", status);
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

        /// <summary>
        /// ���߃`�F�b�N���܂��B
        /// </summary>
        /// <param name="outErrorList">��������</param>
        /// <param name="parareceiveWorkList">��������</param>
        /// <param name="salesSimeDate">������ߓ�</param>
        /// <param name="StockSimeDate">�d�����ߓ�</param>
        /// <param name="saleCheckFlg">����`�F�b�N�t���O</param>
        /// <param name="depsitCheckFlg">�����`�F�b�N�t���O</param>
        /// <param name="stockCheckFlg">�d���`�F�b�N�t���O</param>
        /// <param name="paymentCheckFlg">�x�����`�F�b�N�t���O</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���߃`�F�b�N</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011.07.21</br>
        public int SimeCheckSCM(out ArrayList outErrorList, ArrayList parareceiveWorkList,
            Int64 salesSimeDate, Int64 StockSimeDate, bool saleCheckFlg, bool depsitCheckFlg, bool stockCheckFlg, bool paymentCheckFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            outErrorList = new ArrayList();
            try
            {
                if (parareceiveWorkList != null && parareceiveWorkList.Count > 0)
                {
                    // �R�l�N�V��������
                    sqlConnection = this.CreateSqlConnectionData(true);
                    sqlTransaction = this.CreateTransactionData(ref sqlConnection);

                    for (int i = 0; i < parareceiveWorkList.Count; i++)
                    {
                        DCReceiveDataWork parareceiveWork = (DCReceiveDataWork)parareceiveWorkList[i];
                        ArrayList errList;
                        status = this.SimeCheckProcSCM(out errList, parareceiveWork, salesSimeDate, StockSimeDate,
                            saleCheckFlg, depsitCheckFlg, stockCheckFlg, paymentCheckFlg, ref sqlConnection, ref sqlTransaction);
                        outErrorList.AddRange(errList);
                    }
                    keylist.Clear();//ADD by Liangsd   2011/09/09 Redmine #24633

                }
            }
            catch (SqlException e)
            {
                base.WriteErrorLog(e, "DCControlDB.simeCheckSCM(out object outerrorList, object parareceiveWork)", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DCControlDB.simeCheckSCM(out object outerrorList, object parareceiveWork)", status);
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

		/// <summary>
		/// ���߃`�F�b�N���܂��B
		/// </summary>
		/// <param name="outErrorList">��������</param>
		/// <param name="parareceiveWork">��������</param>
		/// <param name="salesSimeDate">������ߓ�</param>
		/// <param name="StockSimeDate">�d�����ߓ�</param>
		/// <param name="saleCheckFlg">����`�F�b�N�t���O</param>
		/// <param name="depsitCheckFlg">�����`�F�b�N�t���O</param>
		/// <param name="stockCheckFlg">�d���`�F�b�N�t���O</param>
		/// <param name="paymentCheckFlg">�x�����`�F�b�N�t���O</param>
		/// <param name="sqlConnection">sqlConnection</param>
		/// <param name="sqlTransaction">sqlTransaction</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���߃`�F�b�N</br>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011.07.21</br>
		private int SimeCheckProcSCM(out ArrayList outErrorList, DCReceiveDataWork parareceiveWork, Int64 salesSimeDate, Int64 StockSimeDate,
			bool saleCheckFlg, bool depsitCheckFlg, bool stockCheckFlg, bool paymentCheckFlg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			outErrorList = new ArrayList();

			string sqlText = string.Empty;
			SqlParameter findParaUpdateEndDateTime = new SqlParameter();
			SqlParameter findParaUpdateStartDateTime = new SqlParameter();
			SqlParameter findParaSectionCode = new SqlParameter();
			SqlParameter findParaSaleSimeDate = new SqlParameter();
			SqlParameter findParaStockSimeDate = new SqlParameter();
            SqlParameter findParaFindEnterPriseCode = new SqlParameter();
            if (saleCheckFlg)
			{
				sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
				//����f�[�^-------------------------------------------
				StringBuilder sb = new StringBuilder();
				sb.Append("SELECT A.ENTERPRISECODERF as ENTERPRISECODERF").Append(Environment.NewLine);
				sb.Append(" ,A.ACPTANODRSTATUSRF as ACPTANODRSTATUSRF ").Append(Environment.NewLine);
				sb.Append(" ,A.SALESSLIPNUMRF as SALESSLIPNUMRF").Append(Environment.NewLine);
				sb.Append(" ,A.ADDUPADATERF as ADDUPADATERF").Append(Environment.NewLine);
				sb.Append(" ,A.RESULTSADDUPSECCDRF as RESULTSADDUPSECCDRF").Append(Environment.NewLine);
				sb.Append(" ,A.CUSTOMERCODERF as CUSTOMERCODERF").Append(Environment.NewLine);
				sb.Append(" ,A.CUSTOMERNAMERF as CUSTOMERNAMERF").Append(Environment.NewLine);
                sb.Append(" ,A.FILEHEADERGUIDRF as FILEHEADERGUIDRF").Append(Environment.NewLine);//ADD by Liangsd   2011/09/09 Redmine #24633
                sb.Append(" ,B.SECTIONGUIDENMRF as SECTIONGUIDENMRF").Append(Environment.NewLine);

				sb.Append(" FROM SALESSLIPRF A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sb.Append(" LEFT JOIN SECINFOSETRF B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				//	����f�[�^.���ьv�㋒�_�R�[�h�@���@���_���ݒ�}�X�^.���_�R�[�h
				sb.Append(" ON A.RESULTSADDUPSECCDRF = B.SECTIONCODERF ").Append(Environment.NewLine);
				//	����f�[�^.���ьv�㋒�_�R�[�h�@���@�p�����[�^.��M���.���_�R�[�h
				sb.Append(" WHERE A.RESULTSADDUPSECCDRF = @FINDRESULTSADDUPSECCD ").Append(Environment.NewLine);

                // --- UPD 2011/11/29 ---------------- >>>>>
                //�������M�̏ꍇ
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    //	����f�[�^.�X�V�����@>�@�p�����[�^.��M���.�J�n���t
                    sb.Append(" AND A.UPDATEDATETIMERF > @FINDTIMEST ").Append(Environment.NewLine);
                    //	����f�[�^.�X�V�����@���@�p�����[�^.��M���.�I�����t
                    sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                }
                //�`�[���t���M�̏ꍇ
                else
                {
                    //	���㖾�׃f�[�^.������t(�󒍃X�e�[�^�X��40�A���㖾�׃f�[�^.������t�����o�����Ƃ��Ȃ��ŁA����f�[�^.���ד��t�ł�)
                    //sb.Append("    AND(((A.ACPTANODRSTATUSRF = 40) ").Append(Environment.NewLine);  // DEL 2011/12/07
                    sb.Append("    AND ((((A.ACPTANODRSTATUSRF = 40) ").Append(Environment.NewLine);  // ADD 2011/12/07
                    sb.Append("    AND (A.SHIPMENTDAYRF>=@FINDTIMEST) ").Append(Environment.NewLine);
                    sb.Append("    AND (A.SHIPMENTDAYRF<=@FINDTIMEED)) ").Append(Environment.NewLine);
                    sb.Append("    OR ((A.ACPTANODRSTATUSRF<>40) ").Append(Environment.NewLine);
                    sb.Append("    AND (A.SALESDATERF>=@FINDTIMEST) ").Append(Environment.NewLine);
                    sb.Append("    AND (A.SALESDATERF<=@FINDTIMEED)))").Append(Environment.NewLine);

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    sb.Append("    OR ((A.UPDATEDATETIMERF >= @FINDTIME) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.UPDATEDATETIMERF <= @FINDTIMETICKSED) ").Append(Environment.NewLine);
                    sb.Append("        AND (((A.ACPTANODRSTATUSRF = 40) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.SHIPMENTDAYRF<=@FINDTIMEED)) ").Append(Environment.NewLine);
                    sb.Append("        OR ((A.ACPTANODRSTATUSRF <> 40) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.SALESDATERF<=@FINDTIMEED))))) ").Append(Environment.NewLine);
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- UPD 2011/11/29 ---------------- <<<<<

				//	����f�[�^.�v����t�@���@�p�����[�^.������ߓ�
				sb.Append(" AND A.ADDUPADATERF <= @FINDSALESIMEDATE ").Append(Environment.NewLine);
                //����f�[�^.��ƃR�[�h = �p�����[�^.��M���.���M����ƃR�[�h
                sb.Append(" AND  A.ENTERPRISECODERF = @FINDENTERPRISECODERF ").Append(Environment.NewLine);//ADD by Liangsd    2011/09/09 Redmine #24633
                //����f�[�^.�����������v�z != 0
                sb.Append(" AND  A.DEPOSITALLOWANCETTLRF = 0 ").Append(Environment.NewLine);  //ADD 2011/09/28 M.Kubota
                //����f�[�^.�ԓ`�敪 != 2
                sb.Append(" AND  A.DEBITNOTEDIVRF != 2 ").Append(Environment.NewLine);        //ADD 2011/09/28 M.Kubota
                
				sqlText = sb.ToString();

				//Prameter�I�u�W�F�N�g�̍쐬
				findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDTIMEST", SqlDbType.BigInt);
				findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDTIMEED", SqlDbType.BigInt);
				findParaSectionCode = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCD", SqlDbType.NChar);
                findParaSaleSimeDate = sqlCommand.Parameters.Add("@FINDSALESIMEDATE", SqlDbType.BigInt);
                findParaFindEnterPriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/09 Redmine #24633

				//Parameter�I�u�W�F�N�g�֒l�ݒ�

                // --- DEL 2011/11/29 ---------------- >>>>>
                //findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                //findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                // --- DEL 2011/11/29 ---------------- <<<<<

                // --- ADD 2011/11/29 ---------------- >>>>>
                //�������M�̏ꍇ
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                    findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                }
                else
                {
                    DateTime tempDateTimeSt = new DateTime(parareceiveWork.StartDateTime);
                    DateTime tempDateTimeEd = new DateTime(parareceiveWork.EndDateTime);
                    findParaUpdateEndDateTime.Value = Convert.ToInt32(tempDateTimeSt.ToString("yyyyMMdd"));
                    findParaUpdateStartDateTime.Value = Convert.ToInt32(tempDateTimeEd.ToString("yyyyMMdd"));

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    SqlParameter findParaDateTime = new SqlParameter();
                    findParaDateTime = sqlCommand.Parameters.Add("@FINDTIME", SqlDbType.BigInt);
                    findParaDateTime.Value = parareceiveWork.EndDateTimeTicks;
                    SqlParameter findParaEndDateTime = new SqlParameter();
                    findParaEndDateTime = sqlCommand.Parameters.Add("@FINDTIMETICKSED", SqlDbType.BigInt);
                    findParaEndDateTime.Value = parareceiveWork.EndDateTime;
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<


				findParaSectionCode.Value = parareceiveWork.PmSectionCode;
				findParaSaleSimeDate.Value = salesSimeDate;
                findParaFindEnterPriseCode.Value = parareceiveWork.PmEnterpriseCode;//ADD by Liangsd    2011/09/09 Redmine #24633

				// SQL��
				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
                    //outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 0));//DEL by Liangsd    2011/09/09 Redmine #24633
                    //ADD by Liangsd   2011/09/09 Redmine #24633----------------->>>>>>>>>>
                    string hKey = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF")).ToString();
                    if (keylist.Contains(hKey) == false)
                    {
                        outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 0));
                        keylist.Add(hKey);
                    }
                    //ADD by Liangsd   2011/09/09 Redmine #24633-----------------<<<<<<<<<<
				}
			}

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

            if (depsitCheckFlg)
			{
				// �����f�[�^-------------------------------------------
				sqlText = string.Empty;
				sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

				StringBuilder sb = new StringBuilder();
				sb.Append("SELECT A.ENTERPRISECODERF as ENTERPRISECODERF").Append(Environment.NewLine);
				sb.Append(" ,A.ACPTANODRSTATUSRF as ACPTANODRSTATUSRF ").Append(Environment.NewLine);
				sb.Append(" ,A.DEPOSITSLIPNORF as SALESSLIPNUMRF").Append(Environment.NewLine);
				sb.Append(" ,A.ADDUPADATERF as ADDUPADATERF").Append(Environment.NewLine);
				sb.Append(" ,A.ADDUPSECCODERF as RESULTSADDUPSECCDRF").Append(Environment.NewLine);
				sb.Append(" ,A.CUSTOMERCODERF as CUSTOMERCODERF").Append(Environment.NewLine);
                sb.Append(" ,A.CUSTOMERNAMERF as CUSTOMERNAMERF").Append(Environment.NewLine);
                sb.Append(" ,A.FILEHEADERGUIDRF as FILEHEADERGUIDRF").Append(Environment.NewLine);//ADD by Liangsd   2011/09/09 Redmine #24633
				sb.Append(" ,B.SECTIONGUIDENMRF as SECTIONGUIDENMRF").Append(Environment.NewLine);

				sb.Append(" FROM DEPSITMAINRF A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sb.Append(" LEFT JOIN SECINFOSETRF B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				// �����f�[�^.�v�㋒�_�R�[�h�@���@���_���ݒ�}�X�^.���_�R�[�h
				sb.Append(" ON A.ADDUPSECCODERF = B.SECTIONCODERF ").Append(Environment.NewLine);
				//	�����f�[�^.�v�㋒�_�R�[�h�@���@�p�����[�^.��M���.���_�R�[�h
				sb.Append(" WHERE A.ADDUPSECCODERF = @FINDRESULTSADDUPSECCD ").Append(Environment.NewLine);

                // --- DEL 2011/11/29 ---------------- >>>>>

                ////	�����f�[�^.�X�V�����@>�@�p�����[�^.��M���.�J�n���t
                //sb.Append(" AND A.UPDATEDATETIMERF > @FINDTIMEST ").Append(Environment.NewLine);
                ////	�����f�[�^.�X�V�����@���@�p�����[�^.��M���.�I�����t
                //sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                // --- DEL 2011/11/29 ---------------- <<<<<<

                // --- ADD 2011/11/29 ---------------- >>>>>
                //�������M�̏ꍇ
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    //	�����f�[�^.�X�V�����@>�@�p�����[�^.��M���.�J�n���t
                    sb.Append(" AND A.UPDATEDATETIMERF > @FINDTIMEST ").Append(Environment.NewLine);
                    //	�����f�[�^.�X�V�����@���@�p�����[�^.��M���.�I�����t
                    sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                }
                //�`�[���t���M�̏ꍇ
                else
                {
                    //	�����f�[�^.�������t�@>=�@�p�����[�^.�J�n���t
                    //sb.Append(" AND A.DEPOSITDATERF >= @FINDTIMEST ").Append(Environment.NewLine);  // DEL 2011/12/07
                    ////	�����f�[�^.�������t�@���@�p�����[�^.��M���.�I�����t
                    //sb.Append(" AND A.DEPOSITDATERF <= @FINDTIMEED ").Append(Environment.NewLine);  // DEL 2011/12/07

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    //	�����f�[�^.�������t�@>=�@�p�����[�^.�J�n���t
                    sb.Append(" AND ((A.DEPOSITDATERF >= @FINDTIMEST ").Append(Environment.NewLine);
                    //	�����f�[�^.�������t�@���@�p�����[�^.��M���.�I�����t
                    sb.Append(" AND A.DEPOSITDATERF <= @FINDTIMEED) ").Append(Environment.NewLine);

                    sb.Append("    OR ((A.UPDATEDATETIMERF >= @FINDTIME) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.UPDATEDATETIMERF <= @FINDTIMETICKSED) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.DEPOSITDATERF<=@FINDTIMEED))) ").Append(Environment.NewLine);
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<


				//	�����f�[�^.�v����t�@���@�p�����[�^.������ߓ�
				sb.Append(" AND A.ADDUPADATERF <= @FINDSALESIMEDATE ").Append(Environment.NewLine);
                sb.Append(" AND A.ENTERPRISECODERF = @FINDENTERPRISECODERF ").Append(Environment.NewLine);//ADD by Liangsd    2011/09/09 Redmine #24633
				sqlText = sb.ToString();

				//Prameter�I�u�W�F�N�g�̍쐬

                findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDTIMEST", SqlDbType.BigInt);
                findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDTIMEED", SqlDbType.BigInt);
				findParaSectionCode = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCD", SqlDbType.NChar);
                findParaSaleSimeDate = sqlCommand.Parameters.Add("@FINDSALESIMEDATE", SqlDbType.BigInt);
                findParaFindEnterPriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/09 Redmine #24633

				//Parameter�I�u�W�F�N�g�֒l�ݒ�

                // --- DEL 2011/11/29 ---------------- >>>>>
                //findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                //findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                // --- DEL 2011/11/29 ---------------- <<<<<

                // --- ADD 2011/11/29 ---------------- >>>>>
                //�������M�̏ꍇ
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                    findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                }
                else
                {
                    DateTime tempDateTimeSt = new DateTime(parareceiveWork.StartDateTime);
                    DateTime tempDateTimeEd = new DateTime(parareceiveWork.EndDateTime);
                    findParaUpdateEndDateTime.Value = Convert.ToInt32(tempDateTimeSt.ToString("yyyyMMdd"));
                    findParaUpdateStartDateTime.Value = Convert.ToInt32(tempDateTimeEd.ToString("yyyyMMdd"));

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    SqlParameter findParaDateTime = new SqlParameter();
                    findParaDateTime = sqlCommand.Parameters.Add("@FINDTIME", SqlDbType.BigInt);
                    findParaDateTime.Value = parareceiveWork.EndDateTimeTicks;
                    SqlParameter findParaEndDateTime = new SqlParameter();
                    findParaEndDateTime = sqlCommand.Parameters.Add("@FINDTIMETICKSED", SqlDbType.BigInt);
                    findParaEndDateTime.Value = parareceiveWork.EndDateTime;
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<

				findParaSectionCode.Value = parareceiveWork.PmSectionCode;
                findParaSaleSimeDate.Value = salesSimeDate;
                findParaFindEnterPriseCode.Value = parareceiveWork.PmEnterpriseCode;//ADD by Liangsd   2011/09/09 Redmine #24633

				// SQL��
				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
                    //outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 1));//DEL by Liangsd    2011/09/09 Redmine #24633
                    //ADD by Liangsd   2011/09/09 Redmine #24633----------------->>>>>>>>>>
                    string hKey = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF")).ToString();
                    if (keylist.Contains(hKey) == false)
                    {
                        outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 1));
                        keylist.Add(hKey);
                    }
                    //ADD by Liangsd   2011/09/09 Redmine #24633-----------------<<<<<<<<<<
				}
			}

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

			if (stockCheckFlg)
			{
				// �d���f�[�^-------------------------------------------
				sqlText = string.Empty;
				sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

				StringBuilder sb = new StringBuilder();
				sb.Append("SELECT A.ENTERPRISECODERF as ENTERPRISECODERF").Append(Environment.NewLine);
				sb.Append(" ,A.SUPPLIERFORMALRF as ACPTANODRSTATUSRF ").Append(Environment.NewLine);
				sb.Append(" ,A.SUPPLIERSLIPNORF as SALESSLIPNUMRF").Append(Environment.NewLine);
				sb.Append(" ,A.STOCKADDUPADATERF as ADDUPADATERF").Append(Environment.NewLine);
				//sb.Append(" ,A.STOCKADDUPSECTIONCDRF as RESULTSADDUPSECCDRF").Append(Environment.NewLine);  // DEL 2011/11/29
                sb.Append(" ,A.STOCKSECTIONCDRF as RESULTSADDUPSECCDRF").Append(Environment.NewLine);   // ADD 2011/11/29
				sb.Append(" ,A.SUPPLIERCDRF as CUSTOMERCODERF").Append(Environment.NewLine);
                sb.Append(" ,A.SUPPLIERSNMRF as CUSTOMERNAMERF").Append(Environment.NewLine);
                sb.Append(" ,A.FILEHEADERGUIDRF as FILEHEADERGUIDRF").Append(Environment.NewLine);//ADD by Liangsd   2011/09/09 Redmine #24633
				sb.Append(" ,B.SECTIONGUIDENMRF as SECTIONGUIDENMRF").Append(Environment.NewLine);

				sb.Append(" FROM STOCKSLIPRF A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sb.Append(" LEFT JOIN SECINFOSETRF B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);

                // --- DEL 2011/11/29 ---------------- >>>>>

                ////	�d���f�[�^.�d���v�㋒�_�R�[�h�@���@���_���ݒ�}�X�^.���_�R�[�h
                //sb.Append(" ON A.STOCKADDUPSECTIONCDRF = B.SECTIONCODERF ").Append(Environment.NewLine);
                ////	�d���f�[�^.�d���v�㋒�_�R�[�h�@���@�p�����[�^.��M���.���_�R�[�h
                //sb.Append(" WHERE A.STOCKADDUPSECTIONCDRF = @FINDRESULTSADDUPSECCD ").Append(Environment.NewLine);
                

                ////	�d���f�[�^.�X�V�����@>�@�p�����[�^.��M���.�J�n���t
                //sb.Append(" AND A.UPDATEDATETIMERF > @FINDTIMEST ").Append(Environment.NewLine);
                ////	�d���f�[�^.�X�V�����@���@�p�����[�^.��M���.�I�����t
                //sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                // --- DEL 2011/11/29 ---------------- <<<<<

                // --- ADD 2011/11/29 ---------------- >>>>>
                //	�d���f�[�^.�d�����_�R�[�h�@���@���_���ݒ�}�X�^.���_�R�[�h
                sb.Append(" ON A.STOCKSECTIONCDRF = B.SECTIONCODERF ").Append(Environment.NewLine);
                //	�d���f�[�^.�d�����_�R�[�h�@���@�p�����[�^.��M���.���_�R�[�h
                sb.Append(" WHERE A.STOCKSECTIONCDRF = @FINDRESULTSADDUPSECCD ").Append(Environment.NewLine);

                //�������M�̏ꍇ
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    //	�d���f�[�^.�X�V�����@>�@�p�����[�^.��M���.�J�n���t
                    sb.Append(" AND A.UPDATEDATETIMERF >= @FINDTIMEST ").Append(Environment.NewLine);
                    //	�d���f�[�^.�X�V�����@���@�p�����[�^.��M���.�I�����t
                    sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                }
                //�`�[���t���M�̏ꍇ
                else
                {
                    //1:����=>���ד��t
                    //sb.Append(" AND ((A.SUPPLIERFORMALRF=1 ").Append(Environment.NewLine);  // DEL 2011/12/07
                    sb.Append(" AND (((A.SUPPLIERFORMALRF=1 ").Append(Environment.NewLine);    // ADD 2011/12/07
                    //	�d���f�[�^.���ד��t�@���@�p�����[�^.�J�n���t
                    sb.Append(" AND A.ARRIVALGOODSDAYRF>=@FINDTIMEST").Append(Environment.NewLine);
                    //	�d���f�[�^.���ד��t�@���@�p�����[�^.�I�����t
                    sb.Append(" AND A.ARRIVALGOODSDAYRF<=@FINDTIMEED ").Append(Environment.NewLine);
                    sb.Append(" ) OR ").Append(Environment.NewLine);
                    //0:�d��,2:����=>�d�����t
                    sb.Append(" (A.SUPPLIERFORMALRF<>1 ").Append(Environment.NewLine);
                    //-----Add 2011/11/01 ���� for #26228 end-----<<<<<<    
                    //	�d���f�[�^.�d�����@���@�p�����[�^.�J�n���t
                    sb.Append(" AND A.STOCKDATERF>=@FINDTIMEST ").Append(Environment.NewLine);
                    //	�d���f�[�^.�d�����@���@�p�����[�^.�I�����t
                    sb.Append(" AND A.STOCKDATERF<=@FINDTIMEED ").Append(Environment.NewLine);
                    sb.Append(" ))");

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    sb.Append("    OR ((A.UPDATEDATETIMERF >= @FINDTIME) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.UPDATEDATETIMERF <= @FINDTIMETICKSED) ").Append(Environment.NewLine);
                    sb.Append("        AND (((A.SUPPLIERFORMALRF = 1) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.ARRIVALGOODSDAYRF<=@FINDTIMEED)) ").Append(Environment.NewLine);
                    sb.Append("        OR ((A.SUPPLIERFORMALRF <> 1) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.STOCKDATERF<=@FINDTIMEED))))) ").Append(Environment.NewLine);
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<


				//	�d���f�[�^.�d���v����t�@���@�p�����[�^.�d�����ߓ�
				sb.Append(" AND A.STOCKADDUPADATERF <= @FINDSTOCKSIMEDATE ").Append(Environment.NewLine);
                sb.Append(" AND A.ENTERPRISECODERF = @FINDENTERPRISECODERF ").Append(Environment.NewLine);//ADD by Liangsd    2011/09/09 Redmine #24633
                //  �d���f�[�^.�ԓ`�敪 != 2
                sb.Append(" AND A.DEBITNOTEDIVRF != 2 ").Append(Environment.NewLine);  //ADD 2011/09/28 M.Kubota

				sqlText = sb.ToString();

				//Prameter�I�u�W�F�N�g�̍쐬
				findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDTIMEST", SqlDbType.BigInt);
				findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDTIMEED", SqlDbType.BigInt);
				findParaSectionCode = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCD", SqlDbType.NChar);
                findParaStockSimeDate = sqlCommand.Parameters.Add("@FINDSTOCKSIMEDATE", SqlDbType.BigInt);
                findParaFindEnterPriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/09 Redmine #24633

				//Parameter�I�u�W�F�N�g�֒l�ݒ�

                // --- DEL 2011/11/29 ---------------- >>>>>
                //findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                //findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                // --- DEL 2011/11/29 ---------------- <<<<<
                // --- ADD 2011/11/29 ---------------- >>>>>
                //�������M�̏ꍇ
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                    findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                }
                else
                {
                    DateTime tempDateTimeSt = new DateTime(parareceiveWork.StartDateTime);
                    DateTime tempDateTimeEd = new DateTime(parareceiveWork.EndDateTime);
                    findParaUpdateEndDateTime.Value = Convert.ToInt32(tempDateTimeSt.ToString("yyyyMMdd"));
                    findParaUpdateStartDateTime.Value = Convert.ToInt32(tempDateTimeEd.ToString("yyyyMMdd"));

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    SqlParameter findParaDateTime = new SqlParameter();
                    findParaDateTime = sqlCommand.Parameters.Add("@FINDTIME", SqlDbType.BigInt);
                    findParaDateTime.Value = parareceiveWork.EndDateTimeTicks;
                    SqlParameter findParaEndDateTime = new SqlParameter();
                    findParaEndDateTime = sqlCommand.Parameters.Add("@FINDTIMETICKSED", SqlDbType.BigInt);
                    findParaEndDateTime.Value = parareceiveWork.EndDateTime;
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<

				findParaSectionCode.Value = parareceiveWork.PmSectionCode;
				findParaStockSimeDate.Value = StockSimeDate;
                findParaFindEnterPriseCode.Value = parareceiveWork.PmEnterpriseCode;//ADD by Liangsd    2011/09/09 Redmine #24633

				// SQL��
				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
                    //outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 2));//DEL by Liangsd    2011/09/09 Redmine #24633
                    //ADD by Liangsd   2011/09/09 Redmine #24633----------------->>>>>>>>>>
                    string hKey = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF")).ToString();
                    if (keylist.Contains(hKey) == false)
                    {
                        outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 2));
                        keylist.Add(hKey);
                    }
                    //ADD by Liangsd   2011/09/09 Redmine #24633-----------------<<<<<<<<<<
				}
			}

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

			if (paymentCheckFlg)
			{
				// �x���`�[�f�[�^-------------------------------------------
				sqlText = string.Empty;
				sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

				StringBuilder sb = new StringBuilder();
				sb.Append("SELECT A.ENTERPRISECODERF as ENTERPRISECODERF").Append(Environment.NewLine);
				sb.Append(" ,A.SUPPLIERFORMALRF as ACPTANODRSTATUSRF ").Append(Environment.NewLine);
				sb.Append(" ,A.PAYMENTSLIPNORF as SALESSLIPNUMRF").Append(Environment.NewLine);
				sb.Append(" ,A.ADDUPADATERF as ADDUPADATERF").Append(Environment.NewLine);
				sb.Append(" ,A.ADDUPSECCODERF as RESULTSADDUPSECCDRF").Append(Environment.NewLine);
				sb.Append(" ,A.SUPPLIERCDRF as CUSTOMERCODERF").Append(Environment.NewLine);
                sb.Append(" ,A.SUPPLIERSNMRF as CUSTOMERNAMERF").Append(Environment.NewLine);
                sb.Append(" ,A.FILEHEADERGUIDRF as FILEHEADERGUIDRF").Append(Environment.NewLine);//ADD by Liangsd   2011/09/09 Redmine #24633
				sb.Append(" ,B.SECTIONGUIDENMRF as SECTIONGUIDENMRF").Append(Environment.NewLine);

				sb.Append(" FROM PAYMENTSLPRF A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sb.Append(" LEFT JOIN SECINFOSETRF B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				//	�x���`�[�f�[�^.�v�㋒�_�R�[�h�@���@���_���ݒ�}�X�^.���_�R�[�h
				sb.Append(" ON A.ADDUPSECCODERF = B.SECTIONCODERF ").Append(Environment.NewLine);
				//	�x���`�[�f�[�^.�v�㋒�_�R�[�h�@���@�p�����[�^.��M���.���_�R�[�h
				sb.Append(" WHERE A.ADDUPSECCODERF = @FINDRESULTSADDUPSECCD ").Append(Environment.NewLine);

                // --- DEL 2011/11/29 ---------------- >>>>>
                ////	�x���`�[�f�[�^.�X�V�����@>�@�p�����[�^.��M���.�J�n���t
                //sb.Append(" AND A.UPDATEDATETIMERF > @FINDTIMEST ").Append(Environment.NewLine);
                ////	�x���`�[�f�[�^.�X�V�����@���@�p�����[�^.��M���.�I�����t
                //sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                // --- DEL 2011/11/29 ---------------- <<<<<

                // --- ADD 2011/11/29 ---------------- >>>>>
                //�������M�̏ꍇ
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    //	�x���`�[�f�[�^.�X�V�����@>�@�p�����[�^.��M���.�J�n���t
                    sb.Append(" AND A.UPDATEDATETIMERF > @FINDTIMEST ").Append(Environment.NewLine);
                    //	�x���`�[�f�[�^.�X�V�����@���@�p�����[�^.��M���.�I�����t
                    sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                }
                //�`�[���t���M�̏ꍇ
                else
                {
                    //	�x���`�[�f�[�^.�x�����t�@>=�@�p�����[�^.�J�n���t
                    //sb.Append(" AND A.PAYMENTDATERF>=@FINDTIMEST ").Append(Environment.NewLine);
                    ////	�x���`�[�f�[�^.�x�����t�@���@�p�����[�^.�I�����t
                    //sb.Append(" AND A.PAYMENTDATERF<=@FINDTIMEED  ").Append(Environment.NewLine);

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    //	�x���`�[�f�[�^.�x�����t�@>=�@�p�����[�^.�J�n���t
                    sb.Append(" AND ((A.PAYMENTDATERF>=@FINDTIMEST ").Append(Environment.NewLine);
                    //	�x���`�[�f�[�^.�x�����t�@���@�p�����[�^.�I�����t
                    sb.Append(" AND A.PAYMENTDATERF<=@FINDTIMEED)  ").Append(Environment.NewLine);

                    sb.Append("    OR ((A.UPDATEDATETIMERF >= @FINDTIME) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.UPDATEDATETIMERF <= @FINDTIMETICKSED) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.PAYMENTDATERF<=@FINDTIMEED))) ").Append(Environment.NewLine);
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<<

				//	�x���`�[�f�[�^.�v����t�@���@�p�����[�^.�d�����ߓ�
				sb.Append(" AND A.ADDUPADATERF <= @FINDSTOCKSIMEDATE ").Append(Environment.NewLine);
                sb.Append(" AND A.ENTERPRISECODERF = @FINDENTERPRISECODERF ").Append(Environment.NewLine);//ADD by Liangsd    2011/09/09 Redmine #24633
				sqlText = sb.ToString();

				//Prameter�I�u�W�F�N�g�̍쐬
				findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDTIMEST", SqlDbType.BigInt);
				findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDTIMEED", SqlDbType.BigInt);
				findParaSectionCode = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCD", SqlDbType.NChar);
                findParaStockSimeDate = sqlCommand.Parameters.Add("@FINDSTOCKSIMEDATE", SqlDbType.BigInt);
                findParaFindEnterPriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/09 Redmine #24633

				//Parameter�I�u�W�F�N�g�֒l�ݒ�

                // --- DEL 2011/11/29 ---------------- >>>>>
                //findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                //findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                // --- DEL 2011/11/29 ---------------- <<<<<

                // --- ADD 2011/11/29 ---------------- >>>>>
                //�������M�̏ꍇ
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                    findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                }
                else
                {
                    DateTime tempDateTimeSt = new DateTime(parareceiveWork.StartDateTime);
                    DateTime tempDateTimeEd = new DateTime(parareceiveWork.EndDateTime);
                    findParaUpdateEndDateTime.Value = Convert.ToInt32(tempDateTimeSt.ToString("yyyyMMdd"));
                    findParaUpdateStartDateTime.Value = Convert.ToInt32(tempDateTimeEd.ToString("yyyyMMdd"));

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    SqlParameter findParaDateTime = new SqlParameter();
                    findParaDateTime = sqlCommand.Parameters.Add("@FINDTIME", SqlDbType.BigInt);
                    findParaDateTime.Value = parareceiveWork.EndDateTimeTicks;
                    SqlParameter findParaEndDateTime = new SqlParameter();
                    findParaEndDateTime = sqlCommand.Parameters.Add("@FINDTIMETICKSED", SqlDbType.BigInt);
                    findParaEndDateTime.Value = parareceiveWork.EndDateTime;
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<

				findParaSectionCode.Value = parareceiveWork.PmSectionCode;
				findParaStockSimeDate.Value = StockSimeDate;
                findParaFindEnterPriseCode.Value = parareceiveWork.PmEnterpriseCode;//ADD by Liangsd    2011/09/09 Redmine #24633

				// SQL��
				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
                    //outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 3));//DEL by Liangsd    2011/09/09 Redmine #24633
                    //ADD by Liangsd   2011/09/09 Redmine #24633----------------->>>>>>>>>>
                    string hKey = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF")).ToString();
                    if (keylist.Contains(hKey) == false)
                    {
                        outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 3));
                        keylist.Add(hKey);
                    }
                    //ADD by Liangsd   2011/09/09 Redmine #24633-----------------<<<<<<<<<<
				}
			}

			if (outErrorList.Count > 0)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}

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

			return status;
		}

		/// <summary>
		/// �N���X�i�[���� Reader �� eRInfoDataWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="mode">mode</param>
		/// <returns>�I�u�W�F�N�g</returns>
		/// <remarks>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011.7.26</br>
		/// </remarks>
		private ERInfoDataWork CopyToErrorDataWorkFromReader(ref SqlDataReader myReader, int mode)
		{
			ERInfoDataWork eRInfoDataWork = new ERInfoDataWork();

			this.CopyToErrorDataWorkFromReader(ref myReader, ref eRInfoDataWork, mode);

			return eRInfoDataWork;
		}

		/// <summary>
		/// �N���X�i�[���� Reader �� eRInfoDataWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="eRInfoDataWork">eRInfoDataWork �I�u�W�F�N�g</param>
		/// <param name="mode">mode</param>
		/// <returns>void</returns>
		/// <remarks>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011.7.26</br>
		/// </remarks>
		private void CopyToErrorDataWorkFromReader(ref SqlDataReader myReader, ref ERInfoDataWork eRInfoDataWork, int mode)
		{
			if (myReader != null && eRInfoDataWork != null)
			{
				# region �N���X�֊i�[
				switch (mode)
				{
					case 0:
						eRInfoDataWork.ErSlipNm = "����";
                        eRInfoDataWork.ErSalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
						break;
					case 1:
						eRInfoDataWork.ErSlipNm = "����";
                        eRInfoDataWork.ErSalesSlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPNUMRF")).ToString();
						break;
					case 2:
						eRInfoDataWork.ErSlipNm = "�d��";
                        eRInfoDataWork.ErSalesSlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPNUMRF")).ToString();
						break;
					case 3:
						eRInfoDataWork.ErSlipNm = "�x��";
                        eRInfoDataWork.ErSalesSlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPNUMRF")).ToString();
						break;
					default:
						break;
				}
				eRInfoDataWork.ErDateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPADATERF"));
				eRInfoDataWork.ErSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
				eRInfoDataWork.ErSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
				eRInfoDataWork.ErCustCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
				eRInfoDataWork.ErCustName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
				eRInfoDataWork.ErInfo = string.Empty;
				# endregion
			}
		}

		// ADD 2011/07/26 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
		#endregion

		#region [Clear]
		/// <summary>
		/// DC�������O��DC�e�f�[�^�̃N���A�������s��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011.08.26</br>
        // public int DCDataClear(string enterpriseCode)                                 //DEL by Liangsd     2011/09/06
        public int DCDataClear(string sectionCode, string enterpriseCode) //ADD by Liangsd    2011/09/06
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			int status2 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlTransaction sqlTransaction = null;
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			string resNm = "";

#if !DEBUG
            IntentExclusiveLockComponent intentLockObj = null;
#endif
			try
			{
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
				status = Lock(resNm, 1, sqlConnection, sqlTransaction);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					return status;
				}
#if !DEBUG
                // �C���e���g���b�N���s��
                intentLockObj = new IntentExclusiveLockComponent(); // ���b�N���i���C���X�^���X
                // �C���e���g���b�N�Ώۂ�ݒ�
                string[] targetTables = new string[]{"SALESSLIPRF", "ACCEPTODRCARRF", "SALESDETAILRF", "SALESHISTORYRF"       // ����f�[�^�A�󒍃}�X�^�i�ԗ��j�A���㖾�׃f�[�^�A���㗚���f�[�^
                                    ,"SALESHISTDTLRF","STOCKSLIPRF", "STOCKDETAILRF","STOCKSLIPHISTRF"                        // ���㗚�𖾍׃f�[�^�A�d���f�[�^�A�d�����׃f�[�^�A�d�������f�[�^
                                    ,"STOCKSLHISTDTLRF", "STOCKADJUSTRF", "STOCKADJUSTDTLRF", "STOCKMOVERF", "ACCEPTODRRF"};  // �d�����𖾍׃f�[�^�A�݌ɒ����f�[�^�A�݌ɒ������׃f�[�^�A�݌Ɉړ��f�[�^�A�󒍃}�X�^
                status = intentLockObj.IntentLock(targetTables);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    return status;
#endif
                #region DEL by Liangsd     2011/09/06
                //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
                //// DC����f�[�^�X�V����
                //DCSalesSlipDB _salesSlipDB = new DCSalesSlipDB();
                //_salesSlipDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC���㖾�׃f�[�^�X�V����
                //DCSalesDetailDB _salesDetailDB = new DCSalesDetailDB();
                //_salesDetailDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC���㗚���f�[�^�X�V����
                //DCSalesHistoryDB _salesHistoryDB = new DCSalesHistoryDB();
                //_salesHistoryDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC���㗚�𖾍׃f�[�^�X�V����
                //DCSalesHistDtlDB _salesHistDtlDB = new DCSalesHistDtlDB();
                //_salesHistDtlDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC�����f�[�^�X�V����
                //DCDepsitMainDB _depsitMainDB = new DCDepsitMainDB();
                //_depsitMainDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC�������׃f�[�^�X�V����
                //DCDepsitDtlDB _depsitDtlDB = new DCDepsitDtlDB();
                //_depsitDtlDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC�d���f�[�^�X�V����
                //DCStockSlipDB _stockSlipDB = new DCStockSlipDB();
                //_stockSlipDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC�d�����׃f�[�^�X�V����
                //DCStockDetailDB _stockDetailDB = new DCStockDetailDB();
                //_stockDetailDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC�d�������f�[�^�X�V����
                //DCStockSlipHistDB _stockSlipHistDB = new DCStockSlipHistDB();
                //_stockSlipHistDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC�d�����𖾍׃f�[�^�X�V����
                //DCStockSlHistDtlDB _stockSlHistDtlDB = new DCStockSlHistDtlDB();
                //_stockSlHistDtlDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC�x���`�[�}�X�^�X�V����
                //DCPaymentSlpDB _paymentSlpDB = new DCPaymentSlpDB();
                //_paymentSlpDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC�x�����׃f�[�^�X�V����
                //DCPaymentDtlDB _paymentDtlDB = new DCPaymentDtlDB();
                //_paymentDtlDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC�󒍃}�X�^�X�V����
                //DCAcceptOdrDB _acceptOdrDB = new DCAcceptOdrDB();
                //_acceptOdrDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC�󒍃}�X�^�i�ԗ��j�X�V����
                //DCAcceptOdrCarDB _acceptOdrCarDB = new DCAcceptOdrCarDB();
                //_acceptOdrCarDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC�݌ɒ����f�[�^�X�V����
                //DCStockAdjustDB _stockAdjustDB = new DCStockAdjustDB();
                //_stockAdjustDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC�݌ɒ������׃f�[�^�X�V����
                //DCStockAdjustDtlDB _stockAdjustDtlDB = new DCStockAdjustDtlDB();
                //_stockAdjustDtlDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC�݌Ɉړ��f�[�^�X�V����
                //DCStockMoveDB _stockMoveDB = new DCStockMoveDB();
                //_stockMoveDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// ���������}�X�^
                //DCDepositAlwDB _depositAlwDB = new DCDepositAlwDB();
                //_depositAlwDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// ����`�f�[�^
                //DCRcvDraftDataDB _rcvDraftDataDB = new DCRcvDraftDataDB();
                //_rcvDraftDataDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// �x����`�f�[�^
                //DCPayDraftDataDB _payDraftDataDB = new DCPayDraftDataDB();
                //_payDraftDataDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// ���M�������O
                //this.ClearSndRcvhis(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
                #endregion

                //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
                // DC�󒍃}�X�^�i�ԗ��j�X�V����
                DCAcceptOdrCarDB _acceptOdrCarDB = new DCAcceptOdrCarDB();
                _acceptOdrCarDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                // DC�󒍃}�X�^�X�V����
                DCAcceptOdrDB _acceptOdrDB = new DCAcceptOdrDB();
                _acceptOdrDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                _acceptOdrDB.StockClear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC���㖾�׃f�[�^�X�V����
                DCSalesDetailDB _salesDetailDB = new DCSalesDetailDB();
                _salesDetailDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC����f�[�^�X�V����
                DCSalesSlipDB _salesSlipDB = new DCSalesSlipDB();
                _salesSlipDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC���㗚�𖾍׃f�[�^�X�V����
                DCSalesHistDtlDB _salesHistDtlDB = new DCSalesHistDtlDB();
                _salesHistDtlDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC���㗚���f�[�^�X�V����
                DCSalesHistoryDB _salesHistoryDB = new DCSalesHistoryDB();
                _salesHistoryDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC�������׃f�[�^�X�V����
                DCDepsitDtlDB _depsitDtlDB = new DCDepsitDtlDB();
                _depsitDtlDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC�����f�[�^�X�V����
                DCDepsitMainDB _depsitMainDB = new DCDepsitMainDB();
                _depsitMainDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC�d�����׃f�[�^�X�V����
                DCStockDetailDB _stockDetailDB = new DCStockDetailDB();
                _stockDetailDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC�d���f�[�^�X�V����
                DCStockSlipDB _stockSlipDB = new DCStockSlipDB();
                _stockSlipDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC�d�����𖾍׃f�[�^�X�V����
                DCStockSlHistDtlDB _stockSlHistDtlDB = new DCStockSlHistDtlDB();
                _stockSlHistDtlDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC�d�������f�[�^�X�V����
                DCStockSlipHistDB _stockSlipHistDB = new DCStockSlipHistDB();
                _stockSlipHistDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC�x�����׃f�[�^�X�V����
                DCPaymentDtlDB _paymentDtlDB = new DCPaymentDtlDB();
                _paymentDtlDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC�x���`�[�}�X�^�X�V����
                DCPaymentSlpDB _paymentSlpDB = new DCPaymentSlpDB();
                _paymentSlpDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC�݌ɒ����f�[�^�X�V����
                DCStockAdjustDB _stockAdjustDB = new DCStockAdjustDB();
                _stockAdjustDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC�݌ɒ������׃f�[�^�X�V����
                DCStockAdjustDtlDB _stockAdjustDtlDB = new DCStockAdjustDtlDB();
                _stockAdjustDtlDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC�݌Ɉړ��f�[�^�X�V����
                DCStockMoveDB _stockMoveDB = new DCStockMoveDB();
                _stockMoveDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // ���������}�X�^
                DCDepositAlwDB _depositAlwDB = new DCDepositAlwDB();
                _depositAlwDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // ����`�f�[�^
                DCRcvDraftDataDB _rcvDraftDataDB = new DCRcvDraftDataDB();
                _rcvDraftDataDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // �x����`�f�[�^
                DCPayDraftDataDB _payDraftDataDB = new DCPayDraftDataDB();
                _payDraftDataDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                
                ClearSndRcvEtr(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
				// ���M�������O
                this.ClearSndRcvhis(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                //ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex)
			{
				// ���N���X�ɗ�O��n���ď������Ă��炤
				base.WriteErrorLog(ex, "DCControlDB.DCDataClear(Connection�t) SqlException=" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			catch (Exception ex)
			{
				// ���N���X�ɗ�O��n���ď������Ă��炤
				base.WriteErrorLog(ex, "DCControlDB.DCDataClear(Connection�t) Exception=" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
#if !DEBUG
                if (null != intentLockObj)
                {
                    // �C���e���g���b�N����
                    intentLockObj.UnLock();
                }
#endif

				if (resNm != "")
				{
					//�`�o�A�����b�N
					status2 = Release(resNm, sqlConnection, sqlTransaction);
					if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
					}
				}

				if (sqlTransaction != null)
				{
					if (sqlTransaction.Connection != null)
					{
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							sqlTransaction.Commit();
                        }
						else
						{
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

		// ADD 2011.08.26 ���� ---------->>>>>
		# region [ClearSndRcvhis]
		// R�N���X�� Method��SQL�������ʖ�
		/// <summary>
		/// �f�[�^�N���A
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <param name="sqlCommand">SQL�R�����g</param>
		/// <returns></returns>
        // private void ClearSndRcvhis(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                  //DEL by Liangsd    2011/09/06
        private void ClearSndRcvhis(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand) //ADD by Liangsd    2011/09/06
		{
            //ClearSndRcvhisProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand); //DEL by Liangsd    2011/09/06
            ClearSndRcvhisProc(sectionCode,enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);    //ADD by Liangsd    2011/09/06
		}
		/// <summary>
		/// �f�[�^�N���A
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <param name="sqlCommand">SQL�R�����g</param>
		/// <returns></returns>
        //private void ClearSndRcvhisProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)//DEL by Liangsd    2011/09/06
        private void ClearSndRcvhisProc(string sectionCode,string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)   //ADD by Liangsd    2011/09/06
		{
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Delete�R�}���h�̐���
            //sqlCommand.CommandText = "DELETE FROM SNDRCVHISRF WHERE ( ENTERPRISECODERF=@FINDENTERPRISECODE OR SENDDESTEPCODERF=@FINDSENDDESTEPCODE) AND KINDRF=@FINDKINDRF ";
            sqlCommand.CommandText = "DELETE FROM SNDRCVHISRF WHERE ( ENTERPRISECODERF=@FINDENTERPRISECODE OR SENDDESTEPCODERF=@FINDSENDDESTEPCODE)  AND (SNDRCVHISRF.SECTIONCODERF =  @FINDSECTIONCODERF OR SNDRCVHISRF.SENDDESTSECCODERF = @FINDSECTIONCODERF )";
			//Prameter�I�u�W�F�N�g�̍쐬
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
			SqlParameter findParaSendEstEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
			SqlParameter paraKind = sqlCommand.Parameters.Add("@FINDKINDRF", SqlDbType.Int);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/06
			//Parameter�I�u�W�F�N�g�֒l�ݒ�
			findParaEnterpriseCode.Value = enterpriseCode;
			findParaSendEstEpCode.Value = enterpriseCode;
            paraKind.Value = SqlDataMediator.SqlSetInt32(0);
            findParaSectionCode.Value = sectionCode;//ADD by Liangsd    2011/09/06

            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            // ����f�[�^���폜����
			sqlCommand.ExecuteNonQuery();

		}
		#endregion
        # region [ClearSndRcvEtr]
        // R�N���X�� Method��SQL�������ʖ�
        /// <summary>
        /// �f�[�^�N���A
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void ClearSndRcvEtr(string sectionCode,string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            ClearSndRcvEtrProc(sectionCode,enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        /// <summary>
        /// �f�[�^�N���A
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void ClearSndRcvEtrProc(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM SNDRCVETRRF WHERE EXISTS ( SELECT * FROM SNDRCVHISRF WHERE (SNDRCVHISRF.ENTERPRISECODERF = @FINFENTERPRISECODE OR SNDRCVHISRF.SENDDESTEPCODERF = @FINDSENDDESTEPCODE )  AND (SNDRCVHISRF.SECTIONCODERF =  @FINDSECTIONCODERF OR SNDRCVHISRF.SENDDESTSECCODERF = @FINDSECTIONCODERF ) AND SNDRCVHISRF.KINDRF=@FINDKINDRF  AND SNDRCVHISRF.ENTERPRISECODERF = SNDRCVETRRF.ENTERPRISECODERF AND SNDRCVHISRF.SECTIONCODERF = SNDRCVETRRF.SECTIONCODERF AND SNDRCVHISRF.SNDRCVHISCONSNORF = SNDRCVETRRF.SNDRCVHISCONSNORF ) ";
            
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINFENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSendEstEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
            SqlParameter paraKind = sqlCommand.Parameters.Add("@FINDKINDRF", SqlDbType.Int);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/06
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = enterpriseCode;
            findParaSendEstEpCode.Value = enterpriseCode;
            paraKind.Value = SqlDataMediator.SqlSetInt32(1);
            findParaSectionCode.Value = sectionCode;//ADD by Liangsd    2011/09/06
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            // �f�[�^���폜����
            sqlCommand.ExecuteNonQuery();

        }
        #endregion
        // ADD 2011.08.26 ���� ----------<<<<<
	}
}
