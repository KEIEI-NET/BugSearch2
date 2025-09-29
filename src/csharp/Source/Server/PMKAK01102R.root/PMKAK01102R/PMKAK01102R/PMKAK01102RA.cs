//***************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���ԕi�v��X�V���i
// �v���O�����T�v   : �d���ԕi�v��X�V���i �����[�g�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI�֓� �a�G
// �� �� ��  2013/01/22  �C�����e : �d���ԕi�\��@�\�ǉ��Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d���ԕi�v��X�V���i �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���ԕi�v��X�V���i�����[�g�I�u�W�F�N�g�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : FSI�֓� �a�G</br>
    /// <br>Date       : 2013/01/22</br>
    /// </remarks>
    [Serializable]
    public class StockSlipRetPlnDB : RemoteWithAppLockDB, IStockSlipRetPlnDB
    {

        #region [�d���G���g���X�V�����[�g�I�u�W�F�N�g�ŕK�v�Ȃ���]
        //�v���O����ID
        private string _origin = "IOWriteMASIRDB";
        //�֐��R�[��KEY
        //�O
        private string _funcCallKey_BFR = "IOWriteMASIRDBBfr";
        //��
        private string _funcCallKey_AFT = "IOWriteMASIRDBAft";
        //�����R���g���[�����i
        private FunctionCallControl _functionCallControl = null;
        #endregion [�d���G���g���X�V�����[�g�I�u�W�F�N�g�ŕK�v�Ȃ���]

        # region [�g�p�����[�g�E�v���p�e�B]
        private IOWriteCtrlOptWork _CtrlOptWork = null;                 // ����E�d������I�v�V����
        private StockSlipDB _stockSlipDB = null;                        // �d�������[�g
        private StockSlipHistDB _stockSlipHistDB = null;                // �d�����������[�g
        private IOWriteMASIRStockUpdateDB _stockUpdateDB = null;        // �݌ɍX�V�����[�g
        private MonthlyTtlStockUpdDB _monthlyTtlStockUpdDb = null;      // �d�������X�V���������[�g
        private AcceptOdrDB _acceptOdrDb = null;                        // �󒍃}�X�^�����[�g
        private SalesSlipDB _salesSlipDb = null;                        // ����f�[�^DB�����[�g
        private IOWriteGoodsUser _ioWriteGoodsUser = null;              // ���i�}�X�^(���[�U�[)�����[�g
        private IOWriteGoodsPriceUser _ioWriteGoodsPriceUser = null;    // ���i���i�}�X�^(���[�U�[)�����[�g

        /// <summary> ����E�d������I�v�V���� �v���p�e�B </summary>
        private IOWriteCtrlOptWork CtrlOptWork
        {
            get { return this._CtrlOptWork; }

            set
            {
                this._CtrlOptWork = value;
                this._ResourceName = this.GetResourceName(this._CtrlOptWork.EnterpriseCode);
            }
        }

        /// <summary> �d�������[�g�v���p�e�B </summary>
        private StockSlipDB stockSlipDB
        {
            get
            {
                if (this._stockSlipDB == null)
                {
                    // �d�������[�g�𐶐�
                    this._stockSlipDB = new StockSlipDB();
                }

                this._stockSlipDB.IOWriteCtrlOptWork = this._CtrlOptWork;

                return this._stockSlipDB;
            }
        }

        /// <summary> �d�����������[�g�v���p�e�B </summary>
        private StockSlipHistDB StockSlipHistDb
        {
            get
            {
                if (this._stockSlipHistDB == null)
                {
                    this._stockSlipHistDB = new StockSlipHistDB();
                }

                return this._stockSlipHistDB;
            }
        }

        /// <summary> �݌ɍX�V�����[�g �v���p�e�B </summary>
        private IOWriteMASIRStockUpdateDB StockUpdateDb
        {
            get
            {
                if (this._stockUpdateDB == null)
                {
                    this._stockUpdateDB = new IOWriteMASIRStockUpdateDB(this._CtrlOptWork);
                }

                return this._stockUpdateDB;
            }
        }

        /// <summary> �d�������X�V���������[�g �v���p�e�B </summary>
        private MonthlyTtlStockUpdDB MonthlyTtlStockUpdDb
        {
            get
            {
                if (this._monthlyTtlStockUpdDb == null)
                {
                    this._monthlyTtlStockUpdDb = new MonthlyTtlStockUpdDB();
                }

                return this._monthlyTtlStockUpdDb;
            }
        }

        /// <summary> �󒍃}�X�^DB�����[�g �v���p�e�B </summary>
        private AcceptOdrDB AcceptOdrDb
        {
            get
            {
                if (this._acceptOdrDb == null)
                {
                    this._acceptOdrDb = new AcceptOdrDB();
                }

                return this._acceptOdrDb;
            }
        }

        /// <summary> ����f�[�^DB�����[�g �v���p�e�B </summary>
        private SalesSlipDB SalesSlipDb
        {
            get
            {
                if (this._salesSlipDb == null)
                {
                    this._salesSlipDb = new SalesSlipDB();
                }

                return this._salesSlipDb;
            }
        }

        /// <summary> ���i�}�X�^(���[�U�[)�����[�g �v���p�e�B </summary>
        private IOWriteGoodsUser GoodsUserDb
        {
            get
            {
                if (this._ioWriteGoodsUser == null)
                {
                    this._ioWriteGoodsUser = new IOWriteGoodsUser();
                }

                return this._ioWriteGoodsUser;
            }
        }

        /// <summary> ���i���i�}�X�^(���[�U�[)�����[�g �v���p�e�B </summary>
        private IOWriteGoodsPriceUser GoodsPriceUserDb
        {
            get
            {
                if (this._ioWriteGoodsPriceUser == null)
                {
                    this._ioWriteGoodsPriceUser = new IOWriteGoodsPriceUser();
                }

                return this._ioWriteGoodsPriceUser;
            }
        }

        # endregion

        #region[�V�F�A�`�F�b�N�֘A]
        /// <summary>
        /// �A�v���P�[�V���� ���b�N ���\�[�X��
        /// </summary>
        private string _ResourceName = "";

        /// <summary>
        /// �A�v���P�[�V���� ���b�N ���\�[�X�� �v���p�e�B
        /// </summary>
        private string ResourceName
        {
            get { return this._ResourceName; }
        }
        #endregion[�V�F�A�`�F�b�N�֘A]

        /// <summary>
        /// �d���ԕi�v��X�V���i�����[�g�I�u�W�F�N�gDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2013/01/22</br>
        /// </remarks>
        public StockSlipRetPlnDB()
            :
            base("PMKAK01104D", "Broadleaf.Application.Remoting.ParamData.StockSlipRetPlnDBWork", "StockSlipRetPlnDBRF")
        {
            #if DEBUG
            Console.WriteLine("�d���ԕi�v��X�V���i�����[�g�I�u�W�F�N�g");
            #endif

            //���X�V�t�@���N�V�����R���g���[���N���X����
            _functionCallControl = new FunctionCallControl(IOWriteMASIRDBServerRsc.GetResource());

        }

        # region [��������]

        /// <summary>
        /// �d���ԕi�\��f�[�^�̓o�^���s���܂�
        /// </summary>
        /// <param name="paraList">�o�^����d���ԕi�\��f�[�^</param>
        /// <param name="retMsg">�ԋp����G���[���b�Z�[�W</param>
        /// <param name="retItemInfo">���g�p</param>
        /// <returns>RETURN</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// <br>              DCHNB01864RA.cs ���p</br>
        /// </remarks>
        public int Write(ref object paraList, out string retMsg, out string retItemInfo)
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlEncryptInfo encryptinfo = null;

            if (SlipListUtils.IsEmpty(paraList as ArrayList))
            {
                retMsg = "�X�V��񃊃X�g�����o�^�ł��B"; // �� �I��
                base.WriteErrorLog("public int Write()" + retMsg, status);
            }
            else
            {
                try
                {
                    ArrayList list = paraList as ArrayList;

                    status = this.WriteProc(ref list, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                    if (transaction != null && transaction.Connection != null)
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
                }
                catch (Exception ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);

                    retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + ex.Message;

                    if (transaction != null && transaction.Connection != null)
                    {
                        transaction.Rollback();
                    }
                }
                finally
                {
                    // �g�����U�N�V�����̔j��
                    if (transaction != null)
                    {
                        transaction.Dispose();
                    }

                    // �Í����L�[�̃N���[�Y
                    //if (encryptinfo != null && encryptinfo.IsOpen)
                    //{
                    //    encryptinfo.CloseSymKey(ref connection);
                    //}

                    // �R�l�N�V�����̔j��
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// �d���ԕi�\��f�[�^�̓o�^���C������
        /// </summary>
        /// <param name="paramlist">�o�^����d���ԕi�\��f�[�^</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>RETURN</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// <br>              DCHNB01864RA.cs ���p</br>
        /// </remarks>
        private int WriteProc(ref ArrayList paramlist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;
            string methodNm = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            //���e��p�����[�^�̊m�F���s��
            # region [�p�����[�^�`�F�b�N]

            //���X�V��񃊃X�g�`�F�b�N
            if (SlipListUtils.IsEmpty(paramlist))
            {
                retMsg = "�X�V��񃊃X�g�����o�^�ł��B";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            //������E�d������I�v�V�����`�F�b�N
            this.CtrlOptWork = SlipListUtils.Find(paramlist, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;

            if (this.CtrlOptWork == null)
            {
                retMsg = "����E�d������I�v�V������������܂���B";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            //���R�l�N�V�����`�F�b�N
            if (connection == null)
            {
                connection = this.CreateSqlConnection();
                connection.Open();
            }

            if (connection == null)
            {
                retMsg = "�f�[�^�x�[�X�֐ڑ��o���܂���B";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            //���g�����U�N�V�����`�F�b�N
            if (transaction == null)
            {

                transaction = connection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            if (transaction == null)
            {
                retMsg = "�g�����U�N�V�������J�n�ł��܂���B";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }
            # endregion

            Hashtable new2org = new Hashtable();

            //���r�����b�N���J�n����(DCHNB01864RA.cs���l)
#if !DEBUG  // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
            ShareCheckInfo info = null;
            // --- UPD m.suzuki 2010/08/17 ---------->>>>>
            //this.ShareCheckInitialize(paramlist, ref info);
            this.ShareCheckInitialize(paramlist, ref info, ref connection, ref transaction);
            // --- UPD m.suzuki 2010/08/17 ----------<<<<<

            status = this.ShareCheck(info, LockControl.Locke, connection, transaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            status = this.Lock(this.ResourceName, connection, transaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    retMsg = "���b�N�^�C���A�E�g���������܂����B";
                }
                else
                {
                    retMsg = "�r�����b�N�Ɏ��s���܂����B";
                }

                return status;
            }
# endif

            try
            {
                // �o�^��̎d���f�[�^���X�g
                ArrayList afterPurchaseList = new ArrayList();

                //���`�[�o�^�����������Ăяo��
                # region [�o�^�f�[�^��������]
                foreach (object item in paramlist)
                {
                    if (item is IOWriteCtrlOptWork)
                    {
                        continue;
                    }
                    else
                    {
                        if (!isContainStockDetailWorkData(item))
                        {
                            retMsg += "�d���ԕi�\��f�[�^�̓o�^���������Ɏ��s���܂����B";
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            base.WriteErrorLog(methodNm + retMsg, status);
                            return status;
                        }

                        ArrayList newSliplist = item as ArrayList;
                        ArrayList orgSliplist = null;

                        // �d���n�f�[�^�o�^��������
                        status = this.PurchaseWriteInitialize(out orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            new2org.Add(newSliplist, orgSliplist);
                        }
                        else
                        {
                            retMsg += "StockSlipRetPlnDB.WriteProc�d���ԕi�\��f�[�^�̓o�^���������Ɏ��s���܂����B";
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            base.WriteErrorLog(methodNm + retMsg, status);
                            return status;
                        }
                    }
                }
                # endregion

                //���X�V��񃊃X�g���Ɋi�[����Ă���`�[�f�[�^�̓`�[��ނ����ɔ���E�d���̓`�[�o�^�������Ăяo��
                # region [�f�[�^�o�^����]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (object item in paramlist)
                    {
                        if (item is IOWriteCtrlOptWork)
                        {
                            continue;
                        }

                        if (item is ArrayList)
                        {
                            ArrayList newSliplist = item as ArrayList;
                            ArrayList orgSliplist = null;

                            if (!isContainStockDetailWorkData(item))
                            {
                                retMsg += "StockSlipRetPlnDB.WriteProc: �d���ԕi�\��f�[�^�̓o�^�����Ɏ��s���܂����B";
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                base.WriteErrorLog(methodNm + retMsg, status);
                                return status;
                            }

                            // �d���n�f�[�^�o�^����
                            orgSliplist = new2org[newSliplist] as ArrayList;
                            status = this.PurchaseWrite(orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                            // �o�^�����Ɏ��s�����ꍇ�͏����𒆒f����
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg += "StockSlipRetPlnDB.WriteProc: �d���ԕi�\��f�[�^�̓o�^�����Ɏ��s���܂����B";
                                break;
                            }
                            else
                            {
                                // �o�^�ナ�X�g�ɒǉ�
                                afterPurchaseList.Add(newSliplist);
                            }
                        }
                    }
                }
                # endregion
            }
            finally
            {
#if !DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
                //���r�����b�N����������
                this.Release(this.ResourceName, connection, transaction);
                
                this.ShareCheck(info, LockControl.Release, connection, transaction);
#endif
            }
            return status;
        }

        # region [�d���ԕi�\��f�[�^�̓o�^����������]
        /// <summary>
        /// �d���ԕi�\��f�[�^�̓o�^����������
        /// </summary>
        /// <param name="orgsliplist">�o�^�Ώۂ̍X�V�O�`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="newsliplist">�o�^�Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="otherdatalist">���̑��̊֘A�`�[�f�[�^���܂ރ��X�g(�o�^�Ώۃf�[�^���܂�)</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// <br>              DCHNB01864RA.cs���痬�p</br>
        /// </remarks>
        private int PurchaseWriteInitialize(out ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            StockSlipWork slip = SlipListUtils.Find(newsliplist, typeof(StockSlipWork), SlipListUtils.FindType.Class) as StockSlipWork;
            ArrayList slipdtls = SlipListUtils.Find(newsliplist, typeof(StockDetailWork), SlipListUtils.FindType.Array) as ArrayList;

            if (slip == null)
            {
                // �`�[�f�[�^�����݂��Ȃ��ꍇ�̓G���[�Ƃ��ĕԋp
                retMsg += "StockSlipRetPlnDB.PurchaseWriteInitialize: �d���`�[�f�[�^���ݒ肳��Ă��܂���B";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog("private int PurchaseWriteInitialize()" + retMsg, status);
            }

            //���d�������[�g�̓o�^�������������s����
            // ���������𕔕i�Ăяo���ɂ������B��Ō��؂��Ă݂�B
            status = this.IOWriteDBWriteInitialize(out orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            return status;
        }

        # region [�d���G���g���X�V(MAKON01814RA.cs)���痬�p�������\�b�h]
        /// <summary>
        /// �d���ԕi�\��f�[�^�̓o�^����������(MAKON01814RA.cs��WriteInitialize���痬�p)
        /// </summary>
        /// <param name="orgslips">�o�^�Ώۂ̍X�V�O�`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="newslips">�o�^�Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// <br>              MAKON01814RA.cs���痬�p</br>
        /// </remarks>
        private int IOWriteDBWriteInitialize(out ArrayList orgslips, ref ArrayList newslips, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;
            orgslips = new ArrayList();

            #region [�p�����[�^�`�F�b�N����]

            //���p�����[�^�`�F�b�N
            if (newslips == null || newslips.Count <= 0)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": �o�^�Ώۂ̎d���f�[�^���ݒ肳��Ă��܂���B", status);
                return status;
            }

            //���f�[�^�x�[�X�ڑ��󋵃`�F�b�N
            if (connection == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": �f�[�^�x�[�X�ڑ���񂪐ݒ肳��Ă��܂���B", status);
                return status;
            }

            if ((connection.State & ConnectionState.Open) == 0)
            {
                connection.Open();
            }

            //--- DEL 2008/06/03 M.Kubota --->>>
            ////���Í����L�[�̃`�F�b�N
            //if (encryptinfo == null)
            //{
            //    retMsg = "IOWriteMASIRDB.WriteInitialize: �Í����L�[��񂪐ݒ肳��Ă��܂���B";
            //    base.WriteErrorLog(retMsg);
            //    return status;
            //}
            //--- DEL 2008/06/03 M.Kubota ---<<<

            //���g�����U�N�V�����̃`�F�b�N
            if (transaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": �g�����U�N�V������񂪐ݒ肳��Ă��܂���B", status);
                return status;
            }
            # endregion

            try
            {
                CustomSerializeArrayList cstSlips = new CustomSerializeArrayList();
                cstSlips.AddRange(newslips);

                CustomSerializeArrayList orgSlips = new CustomSerializeArrayList();

                object freeparam = null;

                //��WriteInitial�O�I�v�V�����t�@���N�V�����Ăяo��
                status = _functionCallControl.WriteInitial(_origin, _funcCallKey_BFR, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //��IOWrite WriteInitial�������C��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcWriteInitial(ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //��WriteInitial��I�v�V�����t�@���N�V�����Ăяo��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.WriteInitial(_origin, _funcCallKey_AFT, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                // �o�^���������̌��ʂ��Ăяo�����ɕԂ�
                newslips.Clear();
                newslips.AddRange(cstSlips);

                orgslips.AddRange(orgSlips);
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// IOWrite WriteInitial�������C��
        /// </summary>
        /// <param name="originArray">���p�����[�^List</param>
        /// <param name="paramArray">�p�����[�^List</param>
        /// <param name="freeParam">�ذ���Ұ�</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">Sql�ڑ����</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// <br>              MAKON01814RA.cs���痬�p</br>
        /// </remarks>
        private Int32 IOWriteMASIRFunctionProcWriteInitial(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            int stockSlipWork_Posi = MakePosition(paramArray, typeof(StockSlipWork), 0);

            // �d�����͂�WriteInitial�֐����Ăяo��
            if (stockSlipWork_Posi > -1)
            {
                // �`�[�ԍ��E���ʒʔԁE�͂����Ŏ擾
                // ���̐�͋��ʕ��i
                StockSlipWork stockSlipWork = paramArray[stockSlipWork_Posi] as StockSlipWork;
                status = this.stockSlipDB.WriteInitial(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*�\��̧�����Ұ�����*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }

            return status;
        }

        /// <summary>
        /// �d���f�[�^�o�^��������
        /// </summary>
        /// <param name="orgslips">�X�V�Ώۂ̌��d���f�[�^�y�юd�����׃f�[�^���i�[����ArrayList</param>
        /// <param name="newslips">�o�^�Ώۂ̎d���f�[�^�y�юd�����׃f�[�^���i�[����ArrayList</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        public int WriteInitialize(out ArrayList orgslips, ref ArrayList newslips, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;
            orgslips = new ArrayList();

            #region [�p�����[�^�`�F�b�N����]

            //���p�����[�^�`�F�b�N
            if (newslips == null || newslips.Count <= 0)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": �o�^�Ώۂ̎d���f�[�^���ݒ肳��Ă��܂���B", status);
                return status;
            }

            //���f�[�^�x�[�X�ڑ��󋵃`�F�b�N
            if (connection == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": �f�[�^�x�[�X�ڑ���񂪐ݒ肳��Ă��܂���B", status);
                return status;
            }

            if ((connection.State & ConnectionState.Open) == 0)
            {
                connection.Open();
            }

            //--- DEL 2008/06/03 M.Kubota --->>>
            ////���Í����L�[�̃`�F�b�N
            //if (encryptinfo == null)
            //{
            //    retMsg = "IOWriteMASIRDB.WriteInitialize: �Í����L�[��񂪐ݒ肳��Ă��܂���B";
            //    base.WriteErrorLog(retMsg);
            //    return status;
            //}
            //--- DEL 2008/06/03 M.Kubota ---<<<

            //���g�����U�N�V�����̃`�F�b�N
            if (transaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": �g�����U�N�V������񂪐ݒ肳��Ă��܂���B", status);
                return status;
            }
            # endregion

            try
            {
                CustomSerializeArrayList cstSlips = new CustomSerializeArrayList();
                cstSlips.AddRange(newslips);

                CustomSerializeArrayList orgSlips = new CustomSerializeArrayList();

                object freeparam = null;

                //��WriteInitial�O�I�v�V�����t�@���N�V�����Ăяo��
                status = _functionCallControl.WriteInitial(_origin, _funcCallKey_BFR, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //��IOWrite WriteInitial�������C��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcWriteInitial(ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //��WriteInitial��I�v�V�����t�@���N�V�����Ăяo��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.WriteInitial(_origin, _funcCallKey_AFT, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                // �o�^���������̌��ʂ��Ăяo�����ɕԂ�
                newslips.Clear();
                newslips.AddRange(cstSlips);

                orgslips.AddRange(orgSlips);
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// �p�����[�^�ʒu�擾
        /// </summary>
        /// <param name="paramArray">�󂯎��p�����[�^List</param>
        /// <param name="type">�擾�^�C�v</param>
        /// <param name="pattern">�p�����[�^�p�^�[���F0�N���X 1:Array</param>
        /// <returns>�p�����[�^�ʒu:�����ꍇ��-1</returns>
        private int MakePosition(CustomSerializeArrayList paramArray, Type type, Int32 pattern)
        {
            int result = -1;
            //�p�����[�^���擾
            if (pattern == 0)
            {
                for (int i = 0; i < paramArray.Count; i++)
                {
                    if (paramArray[i] != null && paramArray[i].GetType() == type)
                    {
                        result = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < paramArray.Count; i++)
                {
                    if (paramArray[i] is ArrayList)
                    {
                        ArrayList al = paramArray[i] as ArrayList;
                        if (al != null && al.Count > 0)
                        {
                            if (al[0] != null && al[0].GetType() == type)
                            {
                                result = i;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }
        # endregion [�d���G���g���X�V(MAKON01814RA.cs)���痬�p�������\�b�h]

        /// <summary>
        /// �d���n�`�[�f�[�^�o�^
        /// </summary>
        /// <param name="orgsliplist">�o�^�Ώۂ̍X�V�O�`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="newsliplist">�o�^�Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="otherdatalist">���̑��̊֘A�`�[�f�[�^���܂ރ��X�g(�o�^�Ώۃf�[�^���܂�)</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// </remarks>
        private int PurchaseWrite(ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //���d�������[�g�̓o�^���������s����
            status = this.IOWriteDBWriteA(orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            //���o�^���������ɂă_�~�[�̔����f�[�^�����X�g�ɒǉ�����Ă���ꍇ�͍폜����
            OrderSlipWork orderSlip = SlipListUtils.Find(newsliplist, typeof(OrderSlipWork), ListUtils.FindType.Class) as OrderSlipWork;

            if (orderSlip != null)
            {
                newsliplist.Remove(orderSlip);
            }

            return status;
        }

        /// <summary>
        /// �d���f�[�^�o�^����
        /// </summary>
        /// <param name="orgslips">�o�^�Ώۂ̌��d���f�[�^�y�ь��d�����׃f�[�^���i�[����ArrayList</param>
        /// <param name="newslips">�o�^�Ώۂ̎d���f�[�^�y�юd�����׃f�[�^���i�[����ArrayList</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// //MAKON01814RA.cs
        private int IOWriteDBWriteA(ArrayList orgslips, ref ArrayList newslips, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;
            string methodNm = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
            #region [�p�����[�^�`�F�b�N����]

            //���p�����[�^�`�F�b�N
            if (newslips == null || newslips.Count <= 0)
            {
                retMsg = ": �o�^�Ώۂ̎d���f�[�^���ݒ肳��Ă��܂���B";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            //���f�[�^�x�[�X�ڑ��󋵃`�F�b�N
            if (connection == null)
            {
                retMsg = ": �f�[�^�x�[�X�ڑ���񂪐ݒ肳��Ă��܂���B";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            if ((connection.State & ConnectionState.Open) == 0)
            {
                connection.Open();
            }

            //���Í����L�[�̃`�F�b�N
            //if (encryptinfo == null)
            //{
            //    retMsg = ": �Í����L�[��񂪐ݒ肳��Ă��܂���B";
            //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
            //    base.WriteErrorLog(errmsg + retMsg, status);
            //    return status;
            //}

            //���g�����U�N�V�����̃`�F�b�N
            if (transaction == null)
            {
                retMsg = ": �g�����U�N�V������񂪐ݒ肳��Ă��܂���B";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            # endregion

            try
            {
                CustomSerializeArrayList cstSlips = new CustomSerializeArrayList();
                cstSlips.AddRange(newslips);

                CustomSerializeArrayList orgSlips = new CustomSerializeArrayList();
                orgSlips.AddRange(orgslips);

                object freeparam = null;

                //��Write�O�I�v�V�����t�@���N�V�����Ăяo��
                status = _functionCallControl.Write(_origin, _funcCallKey_BFR, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //��IOWrite Write�������C��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcWrite(ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //��Write��I�v�V�����t�@���N�V�����Ăяo��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Write(_origin, _funcCallKey_AFT, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                // �o�^���������̌��ʂ��Ăяo�����ɕԂ�
                newslips.Clear();
                newslips.AddRange(cstSlips);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, methodNm, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, methodNm, status);
            }

            return status;
        }

        /// <summary>
        /// IOWrite Write�������C��
        /// </summary>
        /// <param name="originArray">���p�����[�^List</param>
        /// <param name="paramArray">�p�����[�^List</param>
        /// <param name="freeParam">�ذ���Ұ�</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">Sql�ڑ����</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        //MAKON01814RA.cs
        private Int32 IOWriteMASIRFunctionProcWrite(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            // �p�����[�^�C���f�b�N�X�̎擾
            int stockSlipWork_Posi = MakePosition(paramArray, typeof(StockSlipWork), 0);

            if (stockSlipWork_Posi > -1)
            {
                StockSlipWork wrkStockSlipWork = paramArray[stockSlipWork_Posi] as StockSlipWork;

                // ���ʕ��i���Ăяo���O�Ɏd���`�����u3�v�ɃZ�b�g����B
                this.SetToRetPlnFromParamList(ref paramArray);

                // �d������Write�֐����Ăяo��
                // ���̐�͋��ʕ��i
                status = this.stockSlipDB.Write(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*�\��̧�����Ұ�����*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

            }

            return status;
        }

        # endregion

        /// <summary>
        /// �d���`�����d���ԕi�\��ɍX�V���܂��B
        /// </summary>
        /// <param name="paramArray">�o�^�Ώۂ̃p�����[�^���X�g</param>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// </remarks>
        private void SetToRetPlnFromParamList(ref CustomSerializeArrayList paramArray)
        {
            StockSlipWork stockSlip = new StockSlipWork();
            List<StockDetailWork> stockDetailList = new List<StockDetailWork>();

            // �f�[�^�擾(�d�����X�g����)
            foreach (object data in paramArray)
            {
                if (data is StockSlipWork) // �d���`�[�̏ꍇ
                {
                    stockSlip = (StockSlipWork)data;

                    // �d���`���u3�v���Z�b�g
                    stockSlip.SupplierFormal = 3;
                }
                else if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is StockDetailWork)
                {
                    // foreach��StockDetailWork���o��
                    foreach (StockDetailWork stockDetail in (ArrayList)data)
                    {
                        // �d���`���u3�v���Z�b�g
                        stockDetail.SupplierFormal = 3;
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        #region [���㖾�דǍ�]
        // �ԕi�\��f�[�^�̔��㖾�גʔԁi�����j�擾���̏���
        /// <summary>
        /// ���㖾�׏��Ǎ�
        /// </summary>
        /// <param name="salesDetailWork">���㖾�׃f�[�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="salesSlipNumList">����`�[�ԍ����X�g</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����`�[�ԍ����甄�㖾�׏����擾���܂�</br>
        /// <br>Programmer : FSI���� �G</br>
        /// <br>Date       : 2013/01/24</br>        
        public int SearchSalesDetail(out object salesDetailWork, string enterpriseCode, object salesSlipNumList, string sectionCode)
        {
            return this.SearchSalesDetailWork(out salesDetailWork, enterpriseCode, salesSlipNumList, sectionCode);
        }
        /// <summary>
        /// ���㖾�׏��Ǎ�
        /// </summary>
        /// <param name="salesDetailWork">���㖾�׃f�[�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="salesSlipNumList">����`�[�ԍ����X�g</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����`�[�ԍ����甄�㖾�׏����擾���܂�</br>
        /// <br>Programmer : FSI���� �G</br>
        /// <br>Date       : 2013/01/24</br>        
        private int SearchSalesDetailWork(out object salesDetailWork, string enterpriseCode, object salesSlipNumList, string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesDetailWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSalesDetailWorkSearchProc(out salesDetailWork, enterpriseCode, salesSlipNumList, sectionCode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesDetailSearchDB.Search");
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
        /// ���㖾�׏��Ǎ�
        /// </summary>
        /// <param name="salesDetailWork">��������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="salesSlipNumList">����`�[�ԍ����X�g</param>
        /// <param name="sectionCode">���_�R�[�h</param>        
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����`�[�ԍ����甄�㖾�׏����擾���܂�</br>
        /// <br>Programmer : FSI���� �G</br>
        /// <br>Date       : 2013/01/24</br>
        private int SearchSalesDetailWorkSearchProc(out object salesDetailWork, string enterpriseCode, object salesSlipNumList, string sectionCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            StringBuilder sqlString = new StringBuilder(string.Empty);

            // ����`�[�ԍ����X�g�̃p�����[�^��ArrayList�ɃL���X�g
            ArrayList salesSlipNumParamList = null;
            if (salesSlipNumList != null && salesSlipNumList is ArrayList && ((ArrayList)salesSlipNumList).Count > 0)
            {
                salesSlipNumParamList = salesSlipNumList as ArrayList;
            }
            else
            {
                salesDetailWork = null;
                return status;
            }

            string methodNm = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region[SQL��]
                sqlString.AppendLine("SELECT");
                sqlString.AppendLine(" DTIL.FILEHEADERGUIDRF");
                sqlString.AppendLine(",DTIL.ACPTANODRSTATUSRF");
                sqlString.AppendLine(",DTIL.SALESSLIPNUMRF");
                sqlString.AppendLine(",DTIL.SALESROWNORF");
                sqlString.AppendLine(",DTIL.COMMONSEQNORF");
                sqlString.AppendLine(",DTIL.SALESSLIPDTLNUMRF");
                sqlString.AppendLine(",DTIL.SUPPLIERCDRF");
                sqlString.AppendLine("FROM SALESSLIPRF WITH (READUNCOMMITTED)");
                sqlString.AppendLine("LEFT JOIN SALESDETAILRF AS DTIL WITH (READUNCOMMITTED)");
                sqlString.AppendLine("ON SALESSLIPRF.ENTERPRISECODERF = DTIL.ENTERPRISECODERF");
                sqlString.AppendLine("AND SALESSLIPRF.ACPTANODRSTATUSRF = DTIL.ACPTANODRSTATUSRF");
                sqlString.AppendLine("AND SALESSLIPRF.SALESSLIPNUMRF = DTIL.SALESSLIPNUMRF");
                sqlString.AppendLine("WHERE DTIL.ENTERPRISECODERF = @ENTERPRISECODE");
                sqlString.AppendLine(" AND DTIL.SALESSLIPNUMRF = @SALESSLIPNUM");
                sqlString.AppendLine(" AND SALESSLIPRF.RESULTSADDUPSECCDRF = @RESULTSADDUPSECCD");
                sqlString.AppendLine(" AND DTIL.LOGICALDELETECODERF = 0");
                sqlString.AppendLine(" AND DTIL.ACPTANODRSTATUSRF = 30");
                #endregion[SQL��]

                sqlCommand.CommandText = sqlString.ToString();
                sqlCommand.CommandTimeout = 600;

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);    // ��ƃR�[�h
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);        // ����`�[�ԍ�
                SqlParameter paraSectionCodeRF = sqlCommand.Parameters.Add("@RESULTSADDUPSECCD", SqlDbType.NChar);  // ���ьv�㋒�_�R�[�h

                foreach (string salesSlipNum in salesSlipNumParamList)
                {
                    if (salesSlipNum != string.Empty)
                    {
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                        paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipNum);
                        paraSectionCodeRF.Value = SqlDataMediator.SqlSetString(sectionCode);

                        try
                        {
                            myReader = sqlCommand.ExecuteReader();
                            while (myReader.Read())
                            {
                                retList.Add(this.CopyToSalesDetailWorkFromReader(myReader));
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        catch
                        {

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
                                myReader = null;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, methodNm, status);
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
                    myReader = null;
                }
            }

            salesDetailWork = retList;

            return status;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� StockAcPayHisSearchWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesDetailWork</returns>
        /// <remarks>
        /// <br>Programmer : FSI���� �G</br>
        /// <br>Date       : 2013/01/24</br>
        /// </remarks>
        private StockSlipRetPlnWork CopyToSalesDetailWorkFromReader(SqlDataReader myReader)
        {
            StockSlipRetPlnWork stockSlipRetPlnWork = new StockSlipRetPlnWork();
            
            #region ���㖾�׃��[�N�N���X�֑��
            // Client���ŕK�v�ȃA�C�e���̂ݎ擾
            // GUID
            stockSlipRetPlnWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            // �󒍃X�e�[�^�X
            stockSlipRetPlnWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            // ����`�[�ԍ�
            stockSlipRetPlnWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            // ����s�ԍ�
            stockSlipRetPlnWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
            // ���㖾�גʔ�
            stockSlipRetPlnWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
            // ���ʒʔ�
            stockSlipRetPlnWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            // �d����R�[�h
            stockSlipRetPlnWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            #endregion

            return stockSlipRetPlnWork;
        }

        #endregion [���㖾�דǍ�]
        
        #endregion

        #region [�_���폜]
        /// <summary>
        /// ����_���폜���܂�
        /// </summary>
        /// <param name="stockSlipWork">stockSlipWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����_���폜���܂�</br>
        /// <br>Programmer : FSI���� ���</br>
        /// <br>Date       : 2012/01/23</br>
        public int LogicalDelete(ref object stockSlipWork, out string retMsg)
        {
            return this.LogicalDeleteProc(ref stockSlipWork, out retMsg);
        }

        /// <summary>
        /// �_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="stockSlipWork">stockSlipWork�I�u�W�F�N�g</param>
        /// <param name="retMsg"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : FSI���� ���</br>
        /// <br>Date       : 2012/01/23</br>
        private int LogicalDeleteProc(ref object stockSlipWork, out string retMsg)
        {
            //�������l�ݒ�
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            int procMode = 0;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            string methodNm = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            try
            {
                ArrayList paraList = new ArrayList();

                // StockSlipWork�̃��X�g�̏ꍇ
                if (stockSlipWork is ArrayList)
                {
                    paraList = new ArrayList();

                    foreach (StockSlipWork stockSlip in stockSlipWork as ArrayList)
                    {
                        paraList.Add(stockSlip);
                    }
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    retMsg = "�d���`�[�f�[�^���s���ł��B";
                    base.WriteErrorLog(methodNm, retMsg, status);
                    return status;
                }
                //���d���f�[�^�L���̃`�F�b�N
                if (paraList == null || paraList.Count <= 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    retMsg = "�폜�Ώۂ̎d���f�[�^������܂���B";
                    base.WriteErrorLog(methodNm, retMsg, status);
                    return status;
                }

                //���R�l�N�V�����`�F�b�N
                if (sqlConnection == null)
                {
                    sqlConnection = this.CreateSqlConnection();
                    sqlConnection.Open();
                }
                if (sqlConnection == null)
                {
                    retMsg = "�f�[�^�x�[�X�֐ڑ��o���܂���B";
                    base.WriteErrorLog(methodNm + retMsg, status);
                    return status;
                }

                //���g�����U�N�V�����`�F�b�N
                if (sqlTransaction == null) sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                if (sqlTransaction == null)
                {
                    retMsg = "�g�����U�N�V�������J�n�ł��܂���B";
                    base.WriteErrorLog(methodNm + retMsg, status);
                    return status;
                }

                //���_���폜������
                status = LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction, out retMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //���R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    //�����[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    base.WriteErrorLog(methodNm + retMsg, status);
                }
            }
            catch (Exception ex)
            {
                retMsg = "�d���`�[�f�[�^���s���ł�";
                base.WriteErrorLog(ex, methodNm + retMsg, status);
                //�����[���o�b�N
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
        /// ���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockSlipWork">�_���폜�Ώۂ�StockSlipWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪</param>
        /// <param name="retMsg">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2013/01/22</br>
        public int LogicalDelete(ref object stockSlipWork, int procMode, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //�������l�ݒ�
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            ArrayList paraList = new ArrayList();
            string methodNm = "public int LogicalDelete()";

            //���R�l�N�V�������p�����[�^�`�F�b�N
            if (sqlConnection == null || sqlTransaction == null)
            {
                retMsg = "�f�[�^�x�[�X�ڑ����p�����[�^�����w��ł��B";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            // StockSlipWork�̃��X�g�̏ꍇ
            if (stockSlipWork is List<StockSlipWork>)
            {
                paraList = new ArrayList();

                foreach (StockSlipWork stockSlip in stockSlipWork as List<StockSlipWork>)
                {
                    paraList.Add(stockSlip);
                }
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                retMsg = "�d���`�[�f�[�^���s���ł��B";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            if (paraList == null || paraList.Count <= 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                retMsg = "�폜�Ώۂ̎d���f�[�^������܂���B";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            return this.LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction, out retMsg);
        }

        /// <summary>
        /// ���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="stockSlipWorkList">�_���폜�Ώۂ�StockSlipWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <param name="retMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2013/01/22</br>
        private int LogicalDeleteProc(ref ArrayList stockSlipWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMsg)
        {
            //�������l�ݒ�
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            int logicalCnt = 0;
            retMsg = "";
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string methodNm = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            //���r�����b�N���J�n����(DCHNB01864RA.cs���l)
#if !DEBUG  // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
            ShareCheckInfo info = null;
            // --- UPD m.suzuki 2010/08/17 ---------->>>>>
            //this.ShareCheckInitialize(paramlist, ref info);
            this.ShareCheckInitialize(stockSlipWorkList, ref info, ref sqlConnection, ref sqlTransaction);
            // --- UPD m.suzuki 2010/08/17 ----------<<<<<

            status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            status = this.Lock(this.ResourceName, sqlConnection, sqlTransaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    retMsg = "���b�N�^�C���A�E�g���������܂����B";
                }
                else
                {
                    retMsg = "�r�����b�N�Ɏ��s���܂����B";
                }

                return status;
            }
# endif

            try
            {
                if (stockSlipWorkList != null)
                {
                    for (int i = 0; i < stockSlipWorkList.Count; i++)
                    {
                        StockSlipWork stockSlipWork = stockSlipWorkList[i] as StockSlipWork;

                        # region [�`�[�E���׃f�[�^�擾SQL��]
                        //Select�R�}���h�̐���
                        StringBuilder sqlText = new StringBuilder();
                        sqlText.Capacity = 800;
                        sqlText.AppendLine("SELECT");
                        sqlText.AppendLine(" SLIP.UPDATEDATETIMERF");
                        sqlText.AppendLine(" ,SLIP.UPDASSEMBLYID1RF");
                        sqlText.AppendLine(" ,SLIP.UPDASSEMBLYID2RF");
                        sqlText.AppendLine(" ,SLIP.UPDEMPLOYEECODERF");
                        sqlText.AppendLine(" ,SLIP.ENTERPRISECODERF");
                        sqlText.AppendLine(" ,SLIP.SUPPLIERFORMALRF AS SLIP_FORMAL");
                        sqlText.AppendLine(" ,SDTL.SUPPLIERFORMALRF AS SDTL_FORMAL");
                        sqlText.AppendLine(" ,SLIP.LOGICALDELETECODERF AS SLIP_LOGICAL");
                        sqlText.AppendLine(" ,SDTL.LOGICALDELETECODERF AS SDTL_LOGICAL");
                        sqlText.AppendLine("FROM  STOCKSLIPRF AS SLIP  WITH (READUNCOMMITTED)");
                        sqlText.AppendLine(" LEFT JOIN STOCKDETAILRF AS SDTL WITH (READUNCOMMITTED)");
                        sqlText.AppendLine("  ON SLIP.ENTERPRISECODERF = SDTL.ENTERPRISECODERF");
                        sqlText.AppendLine(" AND SLIP.SECTIONCODERF = SDTL.SECTIONCODERF");
                        sqlText.AppendLine(" AND SLIP.SUPPLIERSLIPNORF = SDTL.SUPPLIERSLIPNORF");
                        sqlText.AppendLine(" WHERE SLIP.ENTERPRISECODERF=@FINDENTERPRISECODE");
                        sqlText.AppendLine(" AND SLIP.STOCKSECTIONCDRF=@FINDSTOCKSECTIONCODE" + Environment.NewLine);
                        sqlText.AppendLine(" AND SLIP.SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO" + Environment.NewLine);
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);
                        # endregion

                        # region [�e��p�����[�^�̒�`�Ɛݒ�]
                        sqlCommand.Parameters.Clear();
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockSectionCode = sqlCommand.Parameters.Add("@FINDSTOCKSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                        
                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);
                        findParaStockSectionCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockSectionCd);
                        findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipNo);
                        # endregion
                        int detailCnt = 0;
                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            //�`�[�f�[�^�̘_���폜�敪���u0�v�ŁA�d���`�����u3�v�ł��邱�ƁB
                            int _supplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIP_FORMAL"));
                            int _logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIP_LOGICAL"));
                            if (_supplierFormal != 3 || _logicalDeleteCode != 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                retMsg = "�폜�Ώۂł͂Ȃ��d���f�[�^�̂��ߍ폜�ł��܂���B";
                                base.WriteErrorLog(methodNm + retMsg, status);
                                sqlCommand.Cancel();
                                return status;
                            }

                            //�`�[���׃f�[�^�̘_���폜�敪���u0�v�ŁA�d���`�����u3�v�ł��邱�ƁB
                            _supplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SDTL_FORMAL"));
                            _logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SDTL_LOGICAL"));
                            if (_supplierFormal != 3)
                            {
                                retMsg = "�폜�Ώۂ̎d���`���ł͂Ȃ����ߍ폜�ł��܂���B";
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                base.WriteErrorLog(methodNm + retMsg, status);
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if(_logicalDeleteCode != 0)
                            {
                                // ���גP�ʂŌv�コ��Ă���ꍇ�͂������C���N�������g�����
                                logicalCnt++;
                            }
                            detailCnt++;
                        }

                        //�����׃f�[�^����0�̎��́A�Y���f�[�^���Ȃ����̂Ƃ���
                        if (detailCnt == 0)
                        {
                            retMsg = "�폜�Ώۂ̎d���f�[�^�����݂��Ȃ����ߍ폜�ł��܂���B";
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            base.WriteErrorLog(methodNm + retMsg, status);
                            sqlCommand.Cancel();
                            return status;
                        }
                        //�����א��Ɠ����������_���폜����Ă���f�[�^������ꍇ�̓G���[�Ώ�
                        if (detailCnt == logicalCnt)
                        {
                            retMsg = "���׃f�[�^���S�Čv�㏈���ς݂̂��ߍ폜�ł��܂���B";
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            base.WriteErrorLog(methodNm + retMsg, status);
                            sqlCommand.Cancel();
                            return status;
                        }

                        # region [�_���폜]
                        //��UPDATE������
                        sqlText.Remove(0, sqlText.Length);
                        sqlText.Append("UPDATE" + Environment.NewLine);
                        sqlText.Append("  STOCKSLIPRF WITH (REPEATABLEREAD) " + Environment.NewLine);
                        sqlText.Append("SET" + Environment.NewLine);
                        sqlText.Append("  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine);
                        sqlText.Append(" ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine);
                        sqlText.Append(" ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine);
                        sqlText.Append("WHERE" + Environment.NewLine);
                        sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                        sqlText.Append("  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine);
                        sqlText.Append("  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine);
                        sqlText.Append(" " + Environment.NewLine);
                        sqlText.Append("UPDATE" + Environment.NewLine);
                        sqlText.Append("  STOCKDETAILRF WITH (REPEATABLEREAD) " + Environment.NewLine);
                        sqlText.Append("SET" + Environment.NewLine);
                        sqlText.Append("  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine);
                        sqlText.Append(" ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine);
                        sqlText.Append(" ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine);
                        sqlText.Append("WHERE" + Environment.NewLine);
                        sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                        sqlText.Append("  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine);
                        sqlText.Append("  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine);
                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);
                        findParaStockSectionCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.SectionCode);
                        findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipNo);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockSlipWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //�_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 1)
                            {
                                retMsg = "�폜�ς݃f�[�^�̂��ߍ폜�ł��܂���B";
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                base.WriteErrorLog(methodNm + retMsg, status);
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0)
                            {
                                stockSlipWork.SupplierFormal = 3;
                                stockSlipWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            }
                        }
                        else
                        {
                            //�_���폜�ȊO�Ŏg�p����ꍇ��`����

                        }


                        # region [�e��p�����[�^�̒�`�Ɛݒ�]
                        //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraFindSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockSlipWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.LogicalDeleteCode);
                        paraFindSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierFormal);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockSlipWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                retMsg = "�d���`�[�f�[�^���s���ł�";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex,methodNm + retMsg, status);
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
#if !DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
                //���r�����b�N����������
                this.Release(this.ResourceName, sqlConnection, sqlTransaction);

                this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
#endif
            }

            stockSlipWorkList = al;

            return status;

        }

        #endregion [�_���폜]

        #region[�v�㏈��]
        /// <summary>
        /// �d���ԕi�\��f�[�^�̕ԕi�v�㏈�����s���܂�
        /// </summary>
        /// <param name="paraList">�v�シ��d���ԕi�\��f�[�^</param>
        /// <param name="retMsg">�ԋp����G���[���b�Z�[�W</param>
        /// <param name="retItemInfo">���g�p</param>
        /// <returns>RETURN</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// <br>              DCHNB01864RA.cs ���p</br>
        /// </remarks>
        public int AddUp(ref object paraList, out string retMsg, out string retItemInfo)
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlEncryptInfo encryptinfo = null;

            if (SlipListUtils.IsEmpty(paraList as ArrayList))
            {
                retMsg = "�X�V��񃊃X�g�����o�^�ł��B"; // �� �I��
            }
            else
            {
                try
                {
                    ArrayList list = paraList as ArrayList;

                    status = this.AddUpProc(ref list, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                    if (transaction != null && transaction.Connection != null)
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
                }
                catch (Exception ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);

                    retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + ex.Message;

                    if (transaction != null && transaction.Connection != null)
                    {
                        transaction.Rollback();
                    }
                }
                finally
                {
                    // �g�����U�N�V�����̔j��
                    if (transaction != null)
                    {
                        transaction.Dispose();
                    }

                    // �Í����L�[�̃N���[�Y
                    //if (encryptinfo != null && encryptinfo.IsOpen)
                    //{
                    //    encryptinfo.CloseSymKey(ref connection);
                    //}

                    // �R�l�N�V�����̔j��
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }

            return status;
        }
        
        /// <summary>
        /// �d���ԕi�\��f�[�^�̕ԕi�v�㏈�����s���܂�
        /// </summary>
        /// <param name="paramlist">�v�シ��d���ԕi�\��f�[�^</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>RETURN</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// <br>              DCHNB01864RA.cs ���p</br>
        /// </remarks>
        private int AddUpProc(ref ArrayList paramlist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //���e��p�����[�^�̊m�F���s��
            # region [�p�����[�^�`�F�b�N]

            //���X�V��񃊃X�g�`�F�b�N
            if (SlipListUtils.IsEmpty(paramlist))
            {
                retMsg = "�X�V��񃊃X�g�����o�^�ł��B";
                return status;
            }

            //������E�d������I�v�V�����`�F�b�N
            this.CtrlOptWork = SlipListUtils.Find(paramlist, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;

            if (this.CtrlOptWork == null)
            {
                retMsg = "����E�d������I�v�V������������܂���B";
                return status;
            }

            //���R�l�N�V�����`�F�b�N
            if (connection == null)
            {
                connection = this.CreateSqlConnection();
                connection.Open();
            }

            if (connection == null)
            {
                retMsg = "�f�[�^�x�[�X�֐ڑ��o���܂���B";
                return status;
            }

            //���g�����U�N�V�����`�F�b�N
            if (transaction == null)
            {
                transaction = connection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            if (transaction == null)
            {
                retMsg = "�g�����U�N�V�������J�n�ł��܂���B";
                return status;
            }
            # endregion

            Hashtable new2org = new Hashtable();

            //���r�����b�N���J�n����(DCHNB01864RA.cs���l)
#if !DEBUG  // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
            ShareCheckInfo info = null;
            // --- UPD m.suzuki 2010/08/17 ---------->>>>>
            //this.ShareCheckInitialize(paramlist, ref info);
            this.ShareCheckInitialize(paramlist, ref info, ref connection, ref transaction);
            // --- UPD m.suzuki 2010/08/17 ----------<<<<<

            status = this.ShareCheck(info, LockControl.Locke, connection, transaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            status = this.Lock(this.ResourceName, connection, transaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    retMsg = "���b�N�^�C���A�E�g���������܂����B";
                }
                else
                {
                    retMsg = "�r�����b�N�Ɏ��s���܂����B";
                }

                return status;
            }
# endif

            try
            {
                // �v���̎d���f�[�^���X�g
                ArrayList afterPurchaseList = new ArrayList();

                //���`�[�o�^�����������Ăяo��
                # region [�o�^�f�[�^��������]
                foreach (object item in paramlist)
                {
                    if (item is IOWriteCtrlOptWork)
                    {
                        continue;
                    }
                    else
                    {
                        if (!isContainStockDetailWorkData(item))
                        {
                            retMsg += "StockSlipRetPlnDB.AddUpProc: �d���ԕi�\��f�[�^�̓o�^���������Ɏ��s���܂����B";
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }

                        ArrayList newSliplist = item as ArrayList;
                        ArrayList orgSliplist = null;

                        // �܂��d���ԕi�\��f�[�^�̍X�V����
                        // ���㖾�גʔԁi�����j�E�d�����גʔԁi���j�E�_���폜�t���O:1���s��
                        // �ŏ��ɍs��Ȃ��ƌ��̕ԕi�\��f�[�^�����ǂ�Ȃ��Ȃ�
                        status = this.UpdateStockDetailForRetPlnData(newSliplist, out retMsg, ref connection, ref transaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }

                        // ���̕ԕi�\��f�[�^�����ǂ�ׂ̒l�Ȃǂ��N���A����
                        status = this.AdjustPurchaseListBeforeInitial(ref newSliplist, out retMsg, ref connection, ref transaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                #endregion

                        // �d���n�f�[�^�o�^��������
                        status = this.PurchaseAddUpInitialize(out orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            new2org.Add(newSliplist, orgSliplist);
                        }
                        else
                        {
                            retMsg += "StockSlipRetPlnDB.AddUpProc: �d���ԕi�\��f�[�^�̓o�^���������Ɏ��s���܂����B";
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                    }
                }

                //���X�V��񃊃X�g���Ɋi�[����Ă���`�[�f�[�^�̓`�[��ނ����ɔ���E�d���̓`�[�o�^�������Ăяo��
                # region [�f�[�^�o�^����]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (object item in paramlist)
                    {
                        if (item is IOWriteCtrlOptWork)
                        {
                            continue;
                        }

                        if (item is ArrayList)
                        {
                            ArrayList newSliplist = item as ArrayList;
                            ArrayList orgSliplist = null;

                            if (!isContainStockDetailWorkData(item))
                            {
                                retMsg += "StockSlipRetPlnDB.AddUpProc: �d���ԕi�\��f�[�^�̓o�^�����Ɏ��s���܂����B";
                                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }

                            // �d���n�f�[�^�o�^����
                            orgSliplist = new2org[newSliplist] as ArrayList;
                            status = this.PurchaseAddUp(orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                            afterPurchaseList.Add(newSliplist);

                            // �o�^�����Ɏ��s�����ꍇ�͏����𒆒f����
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg += "StockSlipRetPlnDB.AddUpProc: �d���ԕi�\��f�[�^�̓o�^�����Ɏ��s���܂����B";
                                break;
                            }
                        }
                    }
                }
                # endregion

                #region[�f�[�^�o�^�㏈��]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (ArrayList SlipList in afterPurchaseList)
                    {
                        // �o�^�ナ�X�g���疾�׃f�[�^�����o��
                        foreach (object data in SlipList)
                        {
                            if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is StockDetailWork)
                            {
                                // ���̎d���̓�������(�����e�[�u���ւ̍X�V������1�̃��[�v�ł܂Ƃ߂�)
                                foreach (object stockDetail in data as ArrayList)
                                {
                                    StockDetailWork stockDetailWork = stockDetail as StockDetailWork;

                                    if (stockDetailWork != null)
                                    {
                                        if (!string.IsNullOrEmpty(stockDetailWork.WarehouseCode.Trim()))
                                            continue;  // �q�ɃR�[�h�����݂��閾�ׂ͔���f�[�^�Ƃ̓��������͍s��Ȃ�
                                        else if (stockDetailWork.SalesSlipDtlNumSync == 0)
                                            continue;  // �d��������ʂŕύX�������͔̂���f�[�^�Ɠ������Ƃ�Ȃ�
                                        else
                                        {
                                            status = UpdateSalesDetailWork(stockDetailWork, ref connection, ref transaction);

                                            // �o�^�����Ɏ��s�����ꍇ�͏����𒆒f����
                                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            {
                                                retMsg += "StockSlipRetPlnDB.AddUpProc: �d���ԕi�\��f�[�^�̓o�^�㏈���Ɏ��s���܂����B";
                                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

            }
            finally
            {
#if !DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
                //���r�����b�N����������
                this.Release(this.ResourceName, connection, transaction);
                
                this.ShareCheck(info, LockControl.Release, connection, transaction);
#endif
            }
            return status;
        }

        # region [�v�㏉��������]
        /// <summary>
        /// �d���ԕi�\��f�[�^�̌v�㏉��������
        /// </summary>
        /// <param name="orgsliplist">�v��Ώۂ̍X�V�O�`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="newsliplist">�v��Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="otherdatalist">���̑��̊֘A�`�[�f�[�^���܂ރ��X�g(�o�^�Ώۃf�[�^���܂�)</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// <br>              DCHNB01864RA.cs���痬�p</br>
        /// </remarks>
        private int PurchaseAddUpInitialize(out ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            StockSlipWork slip = SlipListUtils.Find(newsliplist, typeof(StockSlipWork), SlipListUtils.FindType.Class) as StockSlipWork;
            ArrayList slipdtls = SlipListUtils.Find(newsliplist, typeof(StockDetailWork), SlipListUtils.FindType.Array) as ArrayList;

            if (slip == null)
            {
                // �`�[�f�[�^�����݂��Ȃ��ꍇ�̓G���[�Ƃ��ĕԋp
                retMsg += "StockSlipRetPlnDB.PurchaseWriteInitialize: �d���`�[�f�[�^���ݒ肳��Ă��܂���B";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //���d�������[�g�̓o�^�������������s����
            status = this.IOWriteDBAddUpInitialize(out orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            return status;
        }

        /// <summary>
        /// �d���ԕi�\��f�[�^�̌v�㏉��������(MAKON01814RA.cs��WriteInitialize���痬�p)
        /// </summary>
        /// <param name="orgslips">�v��Ώۂ̍X�V�O�`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="newslips">�v��Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// <br>              MAKON01814RA.cs���痬�p</br>
        /// </remarks>
        private int IOWriteDBAddUpInitialize(out ArrayList orgslips, ref ArrayList newslips, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;
            orgslips = new ArrayList();

            #region [�p�����[�^�`�F�b�N����]

            //���p�����[�^�`�F�b�N
            if (newslips == null || newslips.Count <= 0)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": �o�^�Ώۂ̎d���f�[�^���ݒ肳��Ă��܂���B", status);
                return status;
            }

            //���f�[�^�x�[�X�ڑ��󋵃`�F�b�N
            if (connection == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": �f�[�^�x�[�X�ڑ���񂪐ݒ肳��Ă��܂���B", status);
                return status;
            }

            if ((connection.State & ConnectionState.Open) == 0)
            {
                connection.Open();
            }

            //--- DEL 2008/06/03 M.Kubota --->>>
            ////���Í����L�[�̃`�F�b�N
            //if (encryptinfo == null)
            //{
            //    retMsg = "IOWriteMASIRDB.WriteInitialize: �Í����L�[��񂪐ݒ肳��Ă��܂���B";
            //    base.WriteErrorLog(retMsg);
            //    return status;
            //}
            //--- DEL 2008/06/03 M.Kubota ---<<<

            //���g�����U�N�V�����̃`�F�b�N
            if (transaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": �g�����U�N�V������񂪐ݒ肳��Ă��܂���B", status);
                return status;
            }
            # endregion

            try
            {
                CustomSerializeArrayList cstSlips = new CustomSerializeArrayList();
                cstSlips.AddRange(newslips);

                CustomSerializeArrayList orgSlips = new CustomSerializeArrayList();

                object freeparam = null;

                //��WriteInitial�O�I�v�V�����t�@���N�V�����Ăяo��
                status = _functionCallControl.WriteInitial(_origin, _funcCallKey_BFR, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //��IOWrite WriteInitial�������C��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcAddUpInitial(ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //��WriteInitial��I�v�V�����t�@���N�V�����Ăяo��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.WriteInitial(_origin, _funcCallKey_AFT, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                // �o�^���������̌��ʂ��Ăяo�����ɕԂ�
                newslips.Clear();
                newslips.AddRange(cstSlips);

                orgslips.AddRange(orgSlips);
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// IOWrite AddUpInitial�������C��
        /// </summary>
        /// <param name="originArray">���p�����[�^List</param>
        /// <param name="paramArray">�p�����[�^List</param>
        /// <param name="freeParam">�ذ���Ұ�</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">Sql�ڑ����</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// <br>              MAKON01814RA.cs���痬�p</br>
        /// </remarks>
        private Int32 IOWriteMASIRFunctionProcAddUpInitial(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            int stockSlipWork_Posi = MakePosition(paramArray, typeof(StockSlipWork), 0);
            int stockDetailWork_Posi = MakePosition(paramArray, typeof(StockDetailWork), 1);

            ArrayList stockDetailWorkList = new ArrayList();   
            StockDetailWork targetStockDetailWork = null;

            if (stockSlipWork_Posi > -1 && stockDetailWork_Posi > -1)
            {
                // �d�����׃f�[�^���擾(�ԕi�v��Ώۂ��݌ɓo�^�Ώۂ����f����)
                stockDetailWorkList = paramArray[stockDetailWork_Posi] as ArrayList;
                targetStockDetailWork = stockDetailWorkList[0] as StockDetailWork;

                // �@�܂��݌ɍX�V�ԕi�v����킸�d�����͂�WriteInitial�֐����Ăяo��
                //   MAKON01814RA.cs���l
                StockSlipWork stockSlipWork = paramArray[stockSlipWork_Posi] as StockSlipWork;

                if (targetStockDetailWork == null || stockSlipWork == null)
                {
                    retMsg = "�d���f�[�^/�d�����׃f�[�^���擾�o���܂���ł����B";
                    return status;
                }

                // �`�[�ԍ��E���ʒʔԁE�󒍔ԍ��͂����Ŏ擾
                // ���̐�͋��ʕ��i
                status = this.stockSlipDB.WriteInitial(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*�\��̧�����Ұ�����*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            
                // �A����I�����݌ɍX�V�̏ꍇ�͍݌Ƀ}�X�^WriteInitial�֐����Ăяo��
                //  (�݌Ƀ}�X�^/�݌Ɏ󕥗����f�[�^�̍X�V���i)
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                     targetStockDetailWork.StockOrderDivCd == 1 &&
                     !string.IsNullOrEmpty(targetStockDetailWork.WarehouseCode.Trim()))
                {
                    status = this.StockUpdateDb.WriteInitial(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*�\��̧�����Ұ�����*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }
            }

            return status;
        }
        #endregion[�v�㏉��������]

        #region[�v��Write����]
        /// <summary>
        /// �ԕi�\��v��`�[�f�[�^�o�^
        /// </summary>
        /// <param name="orgsliplist">�o�^�Ώۂ̍X�V�O�`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="newsliplist">�o�^�Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="otherdatalist">���̑��̊֘A�`�[�f�[�^���܂ރ��X�g(�o�^�Ώۃf�[�^���܂�)</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// </remarks>
        private int PurchaseAddUp(ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //���d�������[�g�̓o�^���������s����
            status = this.IOWriteDBAddUpA(orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            //���o�^���������ɂă_�~�[�̔����f�[�^�����X�g�ɒǉ�����Ă���ꍇ�͍폜����
            OrderSlipWork orderSlip = SlipListUtils.Find(newsliplist, typeof(OrderSlipWork), ListUtils.FindType.Class) as OrderSlipWork;

            if (orderSlip != null)
            {
                newsliplist.Remove(orderSlip);
            }

            return status;
        }

        /// <summary>
        /// �d���f�[�^�v��o�^����
        /// </summary>
        /// <param name="orgslips">�o�^�Ώۂ̌��d���f�[�^�y�ь��d�����׃f�[�^���i�[����ArrayList</param>
        /// <param name="newslips">�o�^�Ώۂ̎d���f�[�^�y�юd�����׃f�[�^���i�[����ArrayList</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// //MAKON01814RA.cs
        private int IOWriteDBAddUpA(ArrayList orgslips, ref ArrayList newslips, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            #region [�p�����[�^�`�F�b�N����]

            //���p�����[�^�`�F�b�N
            if (newslips == null || newslips.Count <= 0)
            {
                retMsg = ": �o�^�Ώۂ̎d���f�[�^���ݒ肳��Ă��܂���B";
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + retMsg, status);
                return status;
            }

            //���f�[�^�x�[�X�ڑ��󋵃`�F�b�N
            if (connection == null)
            {
                retMsg = ": �f�[�^�x�[�X�ڑ���񂪐ݒ肳��Ă��܂���B";
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + retMsg, status);
                return status;
            }

            if ((connection.State & ConnectionState.Open) == 0)
            {
                connection.Open();
            }

            //���Í����L�[�̃`�F�b�N
            //if (encryptinfo == null)
            //{
            //    retMsg = ": �Í����L�[��񂪐ݒ肳��Ă��܂���B";
            //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
            //    base.WriteErrorLog(errmsg + retMsg, status);
            //    return status;
            //}

            //���g�����U�N�V�����̃`�F�b�N
            if (transaction == null)
            {
                retMsg = ": �g�����U�N�V������񂪐ݒ肳��Ă��܂���B";
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + retMsg, status);
                return status;
            }

            # endregion

            try
            {
                CustomSerializeArrayList cstSlips = new CustomSerializeArrayList();
                cstSlips.AddRange(newslips);

                CustomSerializeArrayList orgSlips = new CustomSerializeArrayList();
                orgSlips.AddRange(orgslips);

                object freeparam = null;

                //��Write�O�I�v�V�����t�@���N�V�����Ăяo��
                status = _functionCallControl.Write(_origin, _funcCallKey_BFR, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //��IOWrite Write�������C��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcAddUp(ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //��Write��I�v�V�����t�@���N�V�����Ăяo��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Write(_origin, _funcCallKey_AFT, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                // �o�^���������̌��ʂ��Ăяo�����ɕԂ�
                newslips.Clear();
                newslips.AddRange(cstSlips);
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// IOWrite���g�p���� �v�㏈�����C��
        /// </summary>
        /// <param name="originArray">���p�����[�^List</param>
        /// <param name="paramArray">�p�����[�^List</param>
        /// <param name="freeParam">�ذ���Ұ�</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">Sql�ڑ����</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        //MAKON01814RA.cs
        private Int32 IOWriteMASIRFunctionProcAddUp(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            // �p�����[�^�C���f�b�N�X�̎擾
            int stockSlipWork_Posi = MakePosition(paramArray, typeof(StockSlipWork), 0);
            int stockDetailWork_Posi = MakePosition(paramArray, typeof(StockDetailWork), 1);

            ArrayList stockDetailWorkList = new ArrayList();   
            StockDetailWork targetStockDetailWork = null;

            if (stockSlipWork_Posi > -1 && stockDetailWork_Posi > -1)
            {
                // �d�����׃f�[�^���擾(�ԕi�v��Ώۂ��݌ɓo�^�Ώۂ����f����)
                stockDetailWorkList = paramArray[stockDetailWork_Posi] as ArrayList;
                targetStockDetailWork = stockDetailWorkList[0] as StockDetailWork;

                // �d���v��̏ꍇ�͎d�����͂�Write�֐����Ăяo��
                if (targetStockDetailWork.StockOrderDivCd == 0 && string.IsNullOrEmpty(targetStockDetailWork.WarehouseCode.Trim()))
                {
                    #region �d���v�㎞��Write���i�R�[��
                    StockSlipWork wrkStockSlipWork = paramArray[stockSlipWork_Posi] as StockSlipWork;

                    // �d������Write�֐����Ăяo��
                    // ���̐�͋��ʕ��i
                    status = this.stockSlipDB.Write(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*�\��̧�����Ұ�����*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    // �d��������Write�֐����Ăяo��
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wrkStockSlipWork.SupplierFormal == 0)
                    {
                        ArrayList workArray = (paramArray as ArrayList);
                        status = this.StockSlipHistDb.WriteInitialize(ref workArray, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = this.StockSlipHistDb.Write(ref workArray, ref sqlConnection, ref sqlTransaction);
                        }
                    }

                    // �����W�v�X�V����
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �d�������W�v�f�[�^�X�V�p�����[�^�ݒ�
                        MTtlStockUpdParaWork mTtlStcUpdPara = new MTtlStockUpdParaWork();
                        mTtlStcUpdPara.EnterpriseCode = wrkStockSlipWork.EnterpriseCode;  // ��ƃR�[�h
                        mTtlStcUpdPara.StockSectionCd = wrkStockSlipWork.StockSectionCd;  // �d�����_�R�[�h
                        mTtlStcUpdPara.StockDateYmSt = 0;                                 // �d����(�J�n) 0:���w��
                        mTtlStcUpdPara.StockDateYmEd = 0;                                 // �d����(�I��) 0:���w��
                        mTtlStcUpdPara.SlipRegDiv = 1;                                    // �`�[�o�^�敪 1:�o�^

                        ArrayList newStockSlips = new ArrayList();
                        newStockSlips.Add(paramArray);

                        ArrayList oldStockSlips = new ArrayList();
                        oldStockSlips.Add(originArray);

                        status = this.MonthlyTtlStockUpdDb.Write(mTtlStcUpdPara, newStockSlips, oldStockSlips, sqlConnection, sqlTransaction);
                    }
                    #endregion �d���v�㎞��Write���i�R�[��
                }
                else if (targetStockDetailWork.StockOrderDivCd == 1 && !string.IsNullOrEmpty(targetStockDetailWork.WarehouseCode.Trim()))
                {
                    // ���̃p�^�[���͎d���E�d�������E�d�������W�v�̃e�[�u���͍X�V���Ȃ��B

                    // ���i�}�X�^�ւ̓o�^
                    int addListPos = -1;  // �_�~�[
                    status = this.GoodsUserDb.Write(ref paramArray, out addListPos, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                
                    // ���i���i�}�X�^�ւ̓o�^
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        addListPos = -1;  // �_�~�[
                        status = this.GoodsPriceUserDb.Write(ref paramArray, out addListPos, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �݌Ƀf�[�^Write�֐����Ăяo��(�݌ɍX�V�����[�g����݌Ɏ󕥗����X�V�����[�g���Ăяo��)
                        status = this.StockUpdateDb.Write(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*�\��̧�����Ұ�����*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                }
            }
            return status;
        }

        #endregion[�v��Write����]

        #region[�v��ɔ���UPDATE����]

        /// <summary>
        /// �d�����׃f�[�^�̗\��f�[�^���X�V����B
        /// </summary>
        /// <param name="PurchaseList">�d�����X�g</param>
        /// <param name="retMsg">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        private int UpdateStockDetailForRetPlnData(ArrayList PurchaseList, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            retMsg = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (PurchaseList == null || PurchaseList.Count < 3 )
            {
                retMsg = "UpdateStockDetailForRetPlnData: �p�����[�^���s���ł�";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            try
            {
                string sqlText = string.Empty;
                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                #region[�d���ԕi�\��f�[�^�X�V��SQL��]
                StringBuilder commandText = new StringBuilder();
                commandText.AppendLine("UPDATE STOCKDETAILRF SET");
                commandText.AppendLine("  UPDATEDATETIMERF=@UPDATEDATETIME,");
                commandText.AppendLine("  UPDEMPLOYEECODERF=@UPDEMPLOYEECODE,");
                commandText.AppendLine("  UPDASSEMBLYID1RF=@UPDASSEMBLYID1,");
                commandText.AppendLine("  UPDASSEMBLYID2RF=@UPDASSEMBLYID2,");
                commandText.AppendLine("  LOGICALDELETECODERF=@LOGICALDELETECODE,");
                commandText.AppendLine("  SALESSLIPDTLNUMSYNCRF=@SALESSLIPDTLNUMSYNC,");
                commandText.AppendLine("  STOCKSLIPDTLNUMSRCRF=@STOCKSLIPDTLNUMSRC");
                commandText.AppendLine("  WHERE");
                commandText.AppendLine("    ENTERPRISECODERF=@FINDENTERPRISECODE AND");
                commandText.AppendLine("    SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND");
                // �d�����גʔԁE���㖾�גʔԁi�����j���o�^�O���X�g����擾�����l�ƈ�v������̂�UPDATE
                commandText.AppendLine("    STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUMRF AND");
                commandText.AppendLine("    SALESSLIPDTLNUMSYNCRF=@FINDSALESSLIPDTLNUMSYNCRF");
                #endregion[�d���ԕi�\��f�[�^�X�V��SQL��]

                sqlCommand.CommandText = commandText.ToString();
                sqlCommand.CommandTimeout = 600;

                #region[Prameter�I�u�W�F�N�g]
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSalesSlipDtlNumSync = sqlCommand.Parameters.Add("@SALESSLIPDTLNUMSYNC", SqlDbType.BigInt);
                SqlParameter paraStockSlipDtlNumSrc = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSRC", SqlDbType.BigInt);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUMRF", SqlDbType.BigInt);
                SqlParameter findSalesSlipDtlNumSync = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUMSYNCRF", SqlDbType.BigInt);
                #endregion

                // ���׃f�[�^�̒���������𒊏o����
                foreach (object data in PurchaseList)
                {
                    if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is StockDetailWork)
                    {
                        // ���׏����擾
                        foreach (object stockDetail in data as ArrayList)
                        {
                            // �X�V�O�̎d���ԕi�\��f�[�^
                            StockDetailWork StockDetailWorkSrc = stockDetail as StockDetailWork;

                            if (StockDetailWorkSrc.StockSlipCdDtl == 2)
                            {
                                // �萔�����ׂ͌��̗\��f�[�^���Ȃ�����UPDATE���Ȃ�
                                continue;
                            }
                            else if (StockDetailWorkSrc.SalesSlipDtlNumSync != 0 && StockDetailWorkSrc.StockSlipDtlNum != 0)
                            {
                                //�X�V�w�b�_����ݒ�
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)StockDetailWorkSrc;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);

                                //UPDATE�p
                                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(StockDetailWorkSrc.UpdateDateTime);
                                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(StockDetailWorkSrc.UpdEmployeeCode);
                                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(StockDetailWorkSrc.UpdAssemblyId1);
                                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(StockDetailWorkSrc.UpdAssemblyId2);
                                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData1);
                                // �d���ԕi�f�[�^�Ɋi�[����Ă���ׁA
                                // ���㖾�גʔԁi�����j�Ǝd�����גʔԁi���j��0�ɃZ�b�g
                                paraSalesSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(0);
                                paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(0);

                                //���o�����p
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(StockDetailWorkSrc.EnterpriseCode);
                                findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(3); // �d���`�����u3:�d���ԕi�\��v�Ɉ�v�������
                                findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(StockDetailWorkSrc.StockSlipDtlNum); // �d�����גʔԂɈ�v�������
                                findSalesSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(StockDetailWorkSrc.SalesSlipDtlNumSync); // ���㖾�גʔ�(����)�Ɉ�v�������

                                if (sqlCommand.ExecuteNonQuery() > 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                    continue;
                                }
                                else
                                {
                                    retMsg = "UpdateStockDetailForRetPlnData: �d���ԕi�\��f�[�^�̍X�V�Ɏ��s���܂���";
                                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                }
                            }
                            else
                            {
                                retMsg = "UpdateStockDetailForRetPlnData: ���㖾�גʔԁi�����jor �d�����גʔԂ��s���ł�";
                                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            return status;
        }

        /// <summary>
        /// ���㖾�׃f�[�^�̎d�����גʔ�(����)���X�V����B
        /// </summary>
        /// <param name="targetStockDetailWork">�d������work</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        private int UpdateSalesDetailWork(StockDetailWork targetStockDetailWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            if (targetStockDetailWork == null || targetStockDetailWork.SalesSlipDtlNumSync == 0)
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                StringBuilder commandText = new StringBuilder();

                #region[SQL��]
                commandText.AppendLine("UPDATE SALESDETAILRF SET");
                commandText.AppendLine("  UPDATEDATETIMERF=@UPDATEDATETIME,");
                commandText.AppendLine("  UPDEMPLOYEECODERF=@UPDEMPLOYEECODE,");
                commandText.AppendLine("  UPDASSEMBLYID1RF=@UPDASSEMBLYID1,");
                commandText.AppendLine("  UPDASSEMBLYID2RF=@UPDASSEMBLYID2,");
                commandText.AppendLine("  STOCKSLIPDTLNUMSYNCRF=@STOCKSLIPDTLNUMSYNC");
                commandText.AppendLine("  WHERE");
                commandText.AppendLine("    ENTERPRISECODERF=@FINDENTERPRISECODE AND");
                commandText.AppendLine("    ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND");
                commandText.AppendLine("    SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUMRF");
                commandText.AppendLine("UPDATE SALESHISTDTLRF SET");
                commandText.AppendLine("  UPDATEDATETIMERF=@UPDATEDATETIME,");
                commandText.AppendLine("  UPDEMPLOYEECODERF=@UPDEMPLOYEECODE,");
                commandText.AppendLine("  UPDASSEMBLYID1RF=@UPDASSEMBLYID1,");
                commandText.AppendLine("  UPDASSEMBLYID2RF=@UPDASSEMBLYID2,");
                commandText.AppendLine("  STOCKSLIPDTLNUMSYNCRF=@STOCKSLIPDTLNUMSYNC");
                commandText.AppendLine("  WHERE");
                commandText.AppendLine("    ENTERPRISECODERF=@FINDENTERPRISECODE AND");
                commandText.AppendLine("    ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND");
                commandText.AppendLine("    SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUMRF");
                #endregion

                using (SqlCommand sqlCommand = new SqlCommand(commandText.ToString(), sqlConnection, sqlTransaction))
                {
                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)targetStockDetailWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);

                    //Prameter�I�u�W�F�N�g�̍쐬(UPDATE��)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraStockSlipDtlNumSync = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSYNC", SqlDbType.BigInt);
                    //Prameter�I�u�W�F�N�g�̍쐬(WHERE��)
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUMRF", SqlDbType.BigInt);

                    //KEY�R�}���h���Đݒ�
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(targetStockDetailWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(targetStockDetailWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(targetStockDetailWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(targetStockDetailWork.UpdAssemblyId2);
                    paraStockSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(targetStockDetailWork.StockSlipDtlNum);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(targetStockDetailWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(targetStockDetailWork.AcptAnOdrStatusSync);
                    findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(targetStockDetailWork.SalesSlipDtlNumSync); // ���㖾�גʔ�(����)�Ɉ�v�������

                    if (sqlCommand.ExecuteNonQuery() > 1)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            return status;
        }

        #endregion[�v��ɔ���UPDATE����]

        #region[�v��ɔ����d�����X�g�f�[�^��������]

        /// <summary>
        /// Initial�����O�̎d�����X�g�f�[�^�̒����������s���܂�
        /// </summary>
        /// <param name="PurchaseList">�d�����X�g</param>
        /// <param name="retMsg">�G���[���b�Z�[�W</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// </remarks>
        private int AdjustPurchaseListBeforeInitial(ref ArrayList PurchaseList, out string retMsg, ref SqlConnection connection, ref SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retMsg = string.Empty;

            if (PurchaseList == null || PurchaseList.Count < 3)
            {
                retMsg = "AdjustPurchaseListBeforeInitial: �p�����[�^���s���ł�";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            StockSlipWork stockSlipWork = null;

            // �`�[�f�[�^�Ɩ��׃f�[�^�𒊏o����
            foreach (object data in PurchaseList)
            {
                if (data is StockSlipWork)
                {
                    // �`�[�̏ꍇ
                    stockSlipWork = data as StockSlipWork;
                }
                else if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is StockDetailWork)
                {
                    // ���׃��X�g�̏ꍇ
                    StockDetailWork targetstockDetailWork = ((ArrayList)data)[0] as StockDetailWork;
                    ArrayList stockDetailWorkList = data as ArrayList;

                    // �ԕi�v��f�[�^�̏ꍇ
                    if (targetstockDetailWork.StockOrderDivCd == 0 &&
                         string.IsNullOrEmpty(targetstockDetailWork.WarehouseCode.Trim()))
                    {
                        // ���㖾�׃f�[�^���狤�ʒʔԌ����p�̃p�����[�^
                        ArrayList paraSalesDetailWorkList = new ArrayList();
                        ArrayList RetSalesDetailWorkList = new ArrayList();

                        foreach (object item in stockDetailWorkList)
                        {
                            // ���׃f�[�^���擾
                            StockDetailWork work = item as StockDetailWork;

                            // �萔�����ׂ͂��̂܂�
                            if (work.StockSlipCdDtl == 2)
                                continue;

                            stockSlipWork.SupplierSlipNo = 0;       // �d���`�[�ԍ����N���A
                            work.SupplierSlipNo = 0;                // �d���`�[�ԍ����N���A
                            work.StockSlipDtlNum = 0;               // �d�����גʔԂ��N���A

                            // �ԕi�����ύX����Ă��邩�`�F�b�N
                            if (work.StockCount != work.OrderRemainCnt)
                            {
                                work.SalesSlipDtlNumSync = 0;       // ���㖾�גʔԁi�����j
                                work.CommonSeqNo = 0;               // ���ʒʔԂ��N���A
                                work.AcptAnOdrStatusSync = 0;       // �󒍃X�e�[�^�X�i�����j���N���A

                                // �����c�����d�����Ɠ����l�ɂ���
                                work.OrderRemainCnt = work.StockCount;
                            }
                            else
                            {
                                // �����ύX����Ă��Ȃ��ꍇ�͔��㖾�׃f�[�^�Ɠ������s��
                                // ���ʒʔԂ͎d���ԕi�\��f�[�^�ł͐V�K�̔Ԃ���Ă���̂ŁA
                                // ���㖾�גʔԁi�����j���L�[�Ɍ��ƂȂ锄��ԕi�̔��㖾�׃f�[�^��T���ċ��ʒʔԂ��擾
                                SalesDetailWork paraSalesDetailWork = new SalesDetailWork();

                                paraSalesDetailWork.EnterpriseCode = work.EnterpriseCode;       // ��ƃR�[�h
                                paraSalesDetailWork.AcptAnOdrStatus = 30;                       // �󒍃X�e�[�^�X
                                paraSalesDetailWork.SalesSlipDtlNum = work.SalesSlipDtlNumSync; // ���㖾�גʔ�

                                paraSalesDetailWorkList.Add(paraSalesDetailWork);

                            }
                        }

                        if (paraSalesDetailWorkList.Count > 0)
                        {
                            // ���׃f�[�^�̓ǂݍ��݂��I����Ă��甄�㖾�ׂ�����
                            status = this.SalesSlipDb.ReadSalesDetailWork(out RetSalesDetailWorkList,
                                                                              paraSalesDetailWorkList,
                                                                          ref connection,
                                                                          ref transaction);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "���ʒʔԂ̎擾�Ɏ��s���܂���";
                                return status;
                            }
                            else
                            {
                                // �擾�������ʒʔԂ��d�����׃f�[�^�ɃZ�b�g
                                status = this.SetToCommonSeqNoFromSalesDetailWork(ref stockDetailWorkList, RetSalesDetailWorkList);

                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    retMsg = "���ʒʔԂ̎擾�Ɏ��s���܂���";
                                    return status;
                                }
                            }
                        }
                    }
                    // �݌ɓo�^�f�[�^�̏ꍇ
                    else if (targetstockDetailWork.StockOrderDivCd == 1 &&
                         !string.IsNullOrEmpty(targetstockDetailWork.WarehouseCode.Trim()))
                    {
                        // �݌ɓo�^�f�[�^�͍ŏI�I�Ɏd���ԕi�f�[�^���쐬����Ȃ��̂ŁA
                        // �d���������̍ۂɓ`�[�ԍ����̔Ԃ���Ȃ��悤�ɂ���
                        foreach (object item in data as ArrayList)
                        {
                            StockDetailWork work = item as StockDetailWork;

                            // �萔�����ׂ͂��̂܂�
                            if (work.StockSlipCdDtl == 2)
                                continue;
                            
                            // �݌ɂɓo�^�������𒲐�
                            work.StockCount *= -1;              // �d�����𐳐��ɂ���
                            work.OrderRemainCnt *= -1;          // �����c���𐳐��ɂ���

                            work.StockCountDifference = work.StockCount;
                        }
                    }
                    else
                    {
                        retMsg = "UpdateStockDetailForRetPlnData: �q�ɃR�[�h���s���ł�";
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
                else
                {
                    continue;
                }
            }
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// �擾�����d�����׃f�[�^���狤�ʒʔԂ��Z�b�g���܂�
        /// </summary>
        /// <param name="stockDetailWorkList">�d�����׃��X�g</param>
        /// <param name="retSalesDetailWorkList">���㖾�׃��X�g</param>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI�֓� �a�G</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              �d�|No.1105 �d���ԕi�\��@�\�ǉ��Ή�</br>
        /// </remarks>
        private int SetToCommonSeqNoFromSalesDetailWork(ref ArrayList stockDetailWorkList, ArrayList retSalesDetailWorkList)
        {
            // �p�����[�^�`�F�b�N
            if (stockDetailWorkList == null || stockDetailWorkList.Count == 0 ||
                retSalesDetailWorkList == null || retSalesDetailWorkList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            // ReadSalesDetailWork���\�b�h�����retList��
            // �󒍃}�X�^(�ԗ�)�f�[�^���ǉ�����Ă���ꍇ������̂ŁA
            // SalesSlipDetailWork�̂ݎ擾
            ArrayList SalesDetailWorkList = new ArrayList();

            foreach (object data in retSalesDetailWorkList)
            {
                if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is SalesDetailWork)
                {
                    SalesDetailWorkList = data as ArrayList;
                    break;
                }
            }

            // ���㖾�׃��X�g���Ȃ��ꍇ�̓G���[
            if (SalesDetailWorkList.Count == 0)
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ���ʒʔԂ��擾
            foreach (object stockdata in stockDetailWorkList)
            {
                StockDetailWork stockDetailWork = stockdata as StockDetailWork;

                // �d�����׃f�[�^���擾�ł��Ȃ��ꍇ�̓G���[
                if (stockDetailWork == null)
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;

                else if (stockDetailWork.StockCount == stockDetailWork.OrderRemainCnt)
                {
                    // ���㖾�ׂƓ�������ꍇ�̂ݔ��㖾�׃��X�g���狤�ʒʔԂ��擾���Ċi�[
                    foreach (object salesdataList in SalesDetailWorkList)
                    {
                        SalesDetailWork salesDetailWork = salesdataList as SalesDetailWork;

                        if (salesDetailWork == null)
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;

                        else if (stockDetailWork.SalesSlipDtlNumSync == salesDetailWork.SalesSlipDtlNum)
                        {
                            stockDetailWork.CommonSeqNo = salesDetailWork.CommonSeqNo;
                            break;
                        }
                    }
                }
                else
                    continue;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        }
        #endregion[�v��ɔ����d�����X�g�f�[�^��������]

        #endregion[�v�㏈��]

        #region[���ʏ���]

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }

        /// <summary>
        /// �p�����[�^�f�[�^���d�����׃f�[�^���`�F�b�N���܂��B
        /// </summary>
        /// <param name="item">�擾�����d�����׃f�[�^</param>
        /// <returns>flag</returns>
        private bool isContainStockDetailWorkData(object item)
        {
            bool ret = false;

            if (item is ArrayList)
            {
                ArrayList slips = item as ArrayList;

                if (SlipListUtils.IsNotEmpty(slips))
                {
                    object findObj = null;

                    // �d�����׃f�[�^����������(���ׂŌ�������͔̂����f�[�^���܂܂�邽��)
                    findObj = SlipListUtils.Find(slips, typeof(StockDetailWork), SlipListUtils.FindType.Array);

                    if (findObj != null)
                    {
                        ret = true;
                    }
                }
            }

            return ret;
        }
        #endregion

        # region [�V�F�A�`�F�b�N����(DCHNB01864RA.cs��藬�p)]
        /// <br>Update Note: Redmine#23737�@�d���`�[���͂ŁA������������̂��ߓo�^�ł��܂���̂��C������</br>
        /// <br>Programmer : XUJS</br>
        /// <br>Date       : 2011/08/18</br>
        /// <br>Update Note: ��������W�v�������ɓ`�[���s�s�̏C��</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        /// <br>Update Note: 2012/11/09 wangf </br>
        /// <br>           : 10801804-00�A12��12���z�M���ARedmine#33215 PM.NS��Q�ꗗNo.1582�̑Ή�</br>
        /// <br>           : ����`�[���� ���������̎�����̔r���̑Ή�</br>
        // --- UPD m.suzuki 2010/08/17 ---------->>>>>
        //private void ShareCheckInitialize(ArrayList param, ref ShareCheckInfo info)
        private void ShareCheckInitialize(ArrayList param, ref ShareCheckInfo info, ref SqlConnection connection, ref SqlTransaction transaction)
        // --- UPD m.suzuki 2010/08/17 ----------<<<<<
        {
            if (info == null)
            {
                info = new ShareCheckInfo();
            }

            ShareCheckKey dummyKey = new ShareCheckKey();

            foreach (object item in param)
            {
                if (item is ArrayList)
                {
                    // --- UPD m.suzuki 2010/08/17 ---------->>>>>
                    //this.ShareCheckInitialize((item as ArrayList), ref info);
                    this.ShareCheckInitialize((item as ArrayList), ref info, ref connection, ref transaction);
                    // --- UPD m.suzuki 2010/08/17 ----------<<<<<
                    continue;
                }
                // --- ADD m.suzuki 2010/08/17 ----------<<<<<
                // --- ADD XUJS 2011/08/18 ---------->>>>>
                // �d���f�[�^
                else if (item is StockSlipWork)
                {
                    // �������b�N
                    dummyKey.EnterpriseCode = (item as StockSlipWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as StockSlipWork).SectionCode;
                    dummyKey.AddUpUpdDate = ToLongDate((item as StockSlipWork).StockAddUpADate);
                    dummyKey.TotalDay = 0;

                    // �d����̒���(DD)���擾����
                    SupplierDB supplierDB = new SupplierDB();
                    SupplierWork supplier = new SupplierWork();
                    supplier.EnterpriseCode = (item as StockSlipWork).EnterpriseCode;
                    supplier.SupplierCd = (item as StockSlipWork).SupplierCd;
                    int ret = supplierDB.Read(ref supplier, 0, ref connection, ref transaction);

                    if (ret == 0)
                    {
                        int supplierTotalDay = 0;
                        supplierTotalDay = supplier.PaymentTotalDay;
                        dummyKey.TotalDay = supplierTotalDay;
                    }

                    // ���s�����ꍇ�̓��b�N�̃L�[��ǉ����Ȃ�
                    if (dummyKey.TotalDay == 0)
                    {
                        continue;
                    }
                }
                // --- ADD XUJS 2011/08/17 ----------<<<<< 
                // �d�����׃f�[�^
                else if (item is StockDetailWork)
                {
                    dummyKey.EnterpriseCode = (item as StockDetailWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as StockDetailWork).SectionCode;
                    dummyKey.WarehouseCode = (item as StockDetailWork).WarehouseCode;
                }
                else
                {
                    continue;
                }

                if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                      {
                                          return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                              // --- ADD m.suzuki 2010/08/17 ---------->>>>>
                                                 key.Type == ShareCheckType.Section &&
                                              // --- ADD m.suzuki 2010/08/17 ----------<<<<<
                                                 key.SectionCode == dummyKey.SectionCode;
                                      }))
                {
                    info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.Section, dummyKey.SectionCode, "");
                }

                // -- ADD 2011/02/21 --------------------->>>
                if (dummyKey.WarehouseCode != "")
                {
                    // -- ADD 2011/02/21 ---------------------<<<
                    if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                          {
                                              return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                     key.WarehouseCode == dummyKey.WarehouseCode;
                                          }))
                    {
                        info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.WareHouse, "", dummyKey.WarehouseCode);
                    }
                }  // ADD 2011/02/21

                // --- ADD m.suzuki 2010/08/17 ---------->>>>>
                // �������b�N�L�[�ǉ�
                if (dummyKey.TotalDay != 0)
                {
                    //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
                    // �d���f�[�^
                    if (item is StockSlipWork)
                    {
                        if (!info.Keys.Exists(delegate(ShareCheckKey key)
                        {
                            return key.Type == ShareCheckType.SupUpSlip &&
                                   key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                   key.SectionCode == dummyKey.SectionCode &&
                                   key.TotalDay == dummyKey.TotalDay &&
                                   key.AddUpUpdDate == dummyKey.AddUpUpdDate;
                        }))
                        {
                            info.Keys.Add(new ShareCheckKey(dummyKey.EnterpriseCode, ShareCheckType.SupUpSlip, dummyKey.SectionCode, "", dummyKey.TotalDay, dummyKey.AddUpUpdDate));
                        }

                    }
                    else
                    {
                        //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��-----<<<<<
                        if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                                  {
                                                      return key.Type == ShareCheckType.AddUpSlip &&
                                                             key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                             key.SectionCode == dummyKey.SectionCode &&
                                                             key.TotalDay == dummyKey.TotalDay &&
                                                             key.AddUpUpdDate == dummyKey.AddUpUpdDate;
                                                  }))
                        {
                            info.Keys.Add(new ShareCheckKey(dummyKey.EnterpriseCode, ShareCheckType.AddUpSlip, dummyKey.SectionCode, "", dummyKey.TotalDay, dummyKey.AddUpUpdDate));
                        }
                    } //ADD yangmj 2012/05/10 ��������W�v�������ɓ`�[���s�s�̏C��

                }
                // --- ADD m.suzuki 2010/08/17 ----------<<<<<
            }

        }
        // --- ADD m.suzuki 2010/08/17 ---------->>>>>
        /// <summary>
        /// ���t�ϊ�����
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int ToLongDate(DateTime dateTime)
        {
            try
            {
                return (dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day);
            }
            catch
            {
                return 0;
            }
        }
        // --- ADD m.suzuki 2010/08/17 ----------<<<<<
        # endregion

        # region [�`�[�p�����[�^���X�g���쏈��]
        /// <summary>
        /// List ���[�e�B���e�B�N���X
        /// </summary>
        private class SlipListUtils : ListUtils
        {
            /*
            /// <summary>�����p�^�[�� Find() �Ŏg�p</summary>
            public enum FindType
            {
                /// <summary>�N���X</summary>
                Class,
                /// <summary>Array</summary>
                Array
            }
            */
            /// <summary>�����Ώۍ��� FindSlipDetail() �Ŏg�p</summary>
            public enum FindItem
            {
                /// <summary>�ʏ�</summary>
                Normal,
                /// <summary>�v�㌳</summary>
                Source,
                /// <summary>�����v��</summary>
                Synchronize,
                /// <summary>UOE����</summary>
                UoeOrder
                # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
#if false
            /// <summary>����ꎞ</summary>
            SalesTemp
#endif
                # endregion
            }
        }

        /// <summary>
        /// �`�[�^�C�v
        /// </summary>
        internal enum SlipType : int
        {
            /// <summary>���w��</summary>
            None = -1,
            /// <summary>����</summary>
            Estimation = 10,
            /// <summary>��</summary>
            AcceptAnOrder = 20,
            /// <summary>�o��</summary>
            Shipment = 40,
            /// <summary>����</summary>
            Sales = 30,
            /// <summary>����</summary>
            Order = 2,
            /// <summary>����</summary>
            Arrival = 1,
            /// <summary>�d��</summary>
            Purchase = 0,
            /// <summary>UOE����</summary>
            UoeOrder = 98,
            /// <summary>����폜</summary>
            SalesDel = 100,
            /// <summary>�d���폜</summary>
            PurchaseDel = 101,
            /// <summary>�݌ɒ���</summary>
            StockAdjust = 102
            #region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
            ///// <summary>����ꎞ(�d�����㓯���v��)</summary>            
            //SalesTemp = 99
            #endregion
        }
        # endregion

    }
}
