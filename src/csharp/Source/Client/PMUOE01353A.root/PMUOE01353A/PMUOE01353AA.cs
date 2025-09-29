using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����d���񓚕\���@�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �����d���񓚕\���Ɋւ���A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: �a�J ���</br>
    /// <br>Date		: 2008/12/16</br>
    /// <br>Programmer	: �a�J ���</br>
    /// <br>Date		: 2009/01/22</br>
    /// <br>Note		: �s��C��</br>
    /// <br>UpdateNote  : 2011/08/10 caohh �A��736</br>
    /// <br>            : NS���[�U�[���Ǘv�]�ꗗ�A��736�̑Ή�</br>
    /// <br>UpdateNote  : 2011/08/24 yangmj �A��736</br>
    /// <br>            : redmine #23905�̑Ή�</br>
    /// <br>UpdateNote  : 2011/09/27 21112 M.Kubota</br>
    /// <br>            : �d����M���Ԃ��ߑO���̏ꍇ�ɔ��������Q�̉���</br>
    /// </remarks>
    public class PMUOE01353AA
    {
        #region ���萔�A�ϐ��A�\����

        // �f�[�^
        private const int SUPPLYANSINFO_FIRST = 0;           // �����d���񓚏�񏉊��f�[�^�ʒu

        // HashTable
        private Hashtable _supplyAnsInfoHTable = null;       // �����d���񓚏��(key�FINDEX)
        private Hashtable _uoeOrderDtlHTable = null;        // UOE������}�X�^(key�FUOE������R�[�h)

        private string _enterpriseCode = string.Empty;      // ��ƃR�[�h
        private string _sectionCode = string.Empty;         // ���_�R�[�h
        private int _supplyAnsInfoHTableIndex = 0;           // �����d���񓚏��INDEX

        private IUOEAnswerLedgerOrderWorkDB _iUOEAnswerLedgerOrderWorkDB = null;      // �����f�[�^�擾�p�����[�g�I�u�W�F�N�g
       
        // ---- ADD caohh 2011/08/10 -------->>>>>
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X
        // ---- ADD caohh 2011/08/10 --------<<<<<

        #region UOEOrderDtlInfo�\����
        internal struct UOEOrderDtlInfo
        {
            private string _programId;          // �ʐM�A�Z���u��ID(�v���O����ID)
            private string _uoeSupplierName;    // UOE�����於��

            /// <summary>
            /// ������}�X�^�f�[�^�ǉ�
            /// </summary>
            /// <param name="programId">�ʐM�A�Z���u��ID(�v���O����ID)</param>
            /// <param name="uoeSupplierName">UOE�����於��</param>
            public void Add(string programId, string uoeSupplierName)
            {
                _programId = programId;
                _uoeSupplierName = uoeSupplierName;
            }
            /// <summary> �ʐM�A�Z���u��ID(�v���O����ID) </summary>
            public string ProgramId
            {
                get { return _programId; }
            }
            /// <summary> UOE�����於�� </summary>
            public string UOESupplierName
            {
                get { return _uoeSupplierName; }
            }

        }
        #endregion
        #endregion ���萔�A�ϐ��A�\���� - end

        # region ��Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e��HashTable�p�f�[�^�̎擾���s���܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public PMUOE01353AA(List<OrderSndRcvJnl> orderSndRcvJnlList, string enterpriseCode, string sectionCode)
        {
            // ��ƃR�[�h
            this._enterpriseCode = enterpriseCode;

            // ���_�R�[�h
            this._sectionCode = sectionCode;

            // ---- ADD caohh 2011/08/10 -------->>>>>
            stc_Employee = null;
            stc_PrtOutSet = null;					// ���[�o�͐ݒ�f�[�^�N���X
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }
            // ---- ADD caohh 2011/08/10 --------<<<<<

            // UOE������}�X�^
            this.CreateUOEOrderDtlHTable();

            if (orderSndRcvJnlList == null)
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iUOEAnswerLedgerOrderWorkDB = (IUOEAnswerLedgerOrderWorkDB)MediationUOEAnswerLedgerOrderWorkDB.GetUOEAnswerLedgerOrderWorkDB();

                this._supplyAnsInfoHTable = null;
            }
            else
            {
                // UOE����M�W���[�i���f�[�^
                this.CreateOrderAnsInfoHTable(orderSndRcvJnlList);
            }
        }
        # endregion ��Constructor - end

        #region ��Public���\�b�h
        #region ��SearchFirst(���񌟍�)
        /// <summary>
        /// �����\���f�[�^�擾(�P�̋N���ȊO��)
        /// </summary>
        /// <param name="supplierDataSet">�O���b�h���׈ȊO(�w�b�_�[�A�O���b�h�w�b�_�[)�̃f�[�^</param>
        /// <param name="detailDataSet">�O���b�h����</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : �����\���p�f�[�^���擾���܂��B ��SearchBefore�ASearchNext�̑O�ɌĂяo���K�v������܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public bool SearchFirst(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // ����ȊO�̌Ăяo����NG
            if (this._supplyAnsInfoHTableIndex != -1)
            {
                supplierDataSet = null;
                detailDataSet = null;
                return false;
            }

            bool status = this.GetDispInfoAll(SUPPLYANSINFO_FIRST, out supplierDataSet, out detailDataSet);
            return status;
        }

        /// <summary>
        /// �����\���f�[�^�擾(�P�̋N����p)
        /// </summary>
        /// <param name="uoeAnswerLedgerOrderCndtn">�����f�[�^���o����</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : �����\���p�f�[�^���擾���܂��B ��SearchBefore�ASearchNext�̑O�ɌĂяo���K�v������܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public bool SearchFirst(UOEAnswerLedgerOrderCndtn uoeAnswerLedgerOrderCndtn, out string errorMsg)
        {
            List<OrderSndRcvJnl> orderSndRcvJnlList = null;

            // �����f�[�^���o
            bool status = this.CreateOrderSndRcvJnl(uoeAnswerLedgerOrderCndtn, out errorMsg, out orderSndRcvJnlList);
            if (status == true)
            {
                // ���o�f�[�^������HashTable���쐬
                this.CreateOrderAnsInfoHTable(orderSndRcvJnlList);
            }

            return status;
        }
        #endregion

        #region ��SearchBefore(�O�f�[�^����)
        /// <summary>
        /// �O�f�[�^�擾
        /// </summary>
        /// <param name="supplierDataSet">�O���b�h���׈ȊO(�w�b�_�[�A�O���b�h�w�b�_�[)�̃f�[�^</param>
        /// <param name="detailDataSet">�O���b�h����</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : ���ݑI������Ă���f�[�^��1�O�̃f�[�^���擾���܂��B�f�[�^�������ꍇ��false���Ԃ�܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public bool SearchBefore(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1�O�̃f�[�^���擾
            bool status = this.GetDispInfoAll(this._supplyAnsInfoHTableIndex - 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ��SearchNext(���f�[�^����)
        /// <summary>
        /// ���f�[�^�擾
        /// </summary>
        /// <param name="supplierDataSet">�O���b�h���׈ȊO(�w�b�_�[�A�O���b�h�w�b�_�[)�̃f�[�^</param>
        /// <param name="detailDataSet">�O���b�h����</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : ���ݑI������Ă���f�[�^��1��̃f�[�^���擾���܂��B�f�[�^�������ꍇ��false���Ԃ�܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public bool SearchNext(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1��̃f�[�^���擾
            bool status = this.GetDispInfoAll(this._supplyAnsInfoHTableIndex + 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ��ExistsUOESupplierCd(UOE������}�X�^���݃`�F�b�N�@�P�̋N����p)
        /// <summary>
        /// UOE������}�X�^���݃`�F�b�N
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <returns>True�F���݁AFalse�F������</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h��UOE������}�X�^�ɓo�^����Ă��邩�`�F�b�N���s���܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public bool ExistsUOESupplierCd(int uoeSupplierCd)
        {
            if (this._uoeOrderDtlHTable == null)
            {
                return false;
            }

            if (this._uoeOrderDtlHTable.ContainsKey(uoeSupplierCd) == false)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ��GetUOESupplierName(UOE�����於�̎擾�@�P�̋N����p)
        /// <summary>
        /// UOE�����於�̎擾
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <returns>UOE�����於��</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h������UOE�����於�̂��擾���܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public string GetUOESupplierName(int uoeSupplierCd)
        {
            return this.GetUOESupplierNameFromUOEOrderDtlHTable(uoeSupplierCd);
        }
        #endregion

        // ---- ADD caohh 2011/08/10 --------->>>>>
        #region ���[�o�͐ݒ�擾����
        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/07/21</br>
        /// </remarks>
        public static int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        // ---- ADD caohh 2011/08/10 ---------<<<<<

        #endregion ��Public���\�b�h - end

        #region ��Private���\�b�h
        #region ���O���b�h�w�b�_�[HashTable�֘A


        #endregion ���O���b�h�w�b�_�[HashTable�֘A - end

        #region ��UOE������}�X�^HashTable�֘A
        #region ��CreateUOEOrderDtlHTable(HashTable�쐬)
        /// <summary>
        /// UOE������}�X�^HashTable�쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^������HashTable���쐬���܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        private void CreateUOEOrderDtlHTable()
        {
            DataSet retDataSet = new DataSet();

            // UOE������}�X�^�f�[�^�擾(PMUOE09022A)
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();
            int status = uoeSupplierAcs.Search(ref retDataSet, this._enterpriseCode, this._sectionCode);

            // �ُ�
            if (status != 0)
            {
                this._uoeOrderDtlHTable = null;
                return;
            }
            // �f�[�^�Ȃ�
            if (retDataSet == null)
            {
                this._uoeOrderDtlHTable = null;
                return;
            }

            // HashTable�쐬
            this._uoeOrderDtlHTable = new Hashtable();
            foreach (DataRow dataRow in retDataSet.Tables[retDataSet.Tables[0].TableName].Rows)
            {
                int key = 0;
                int.TryParse(dataRow["UoeSupplierCd"].ToString(), out key);

                UOEOrderDtlInfo uoeOrderDtlInfo = new UOEOrderDtlInfo();
                uoeOrderDtlInfo.Add(dataRow["CommAssemblyId"].ToString(), dataRow["UOESupplierName"].ToString());

                this._uoeOrderDtlHTable[key] = uoeOrderDtlInfo;
            }
        }
        #endregion


        #region  ��GetUOESupplierNameFromUOEOrderDtlHTable(UOE�����於�̎擾)
        /// <summary>
        /// UOE�����於�̎擾
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <returns>UOE�����於��</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h������UOE������}�X�^HashTable����UOE�����於�̂��擾���܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        private string GetUOESupplierNameFromUOEOrderDtlHTable(int uoeSupplierCd)
        {
            string uoeSupplierName = string.Empty;

            // �f�[�^������
            if (this._uoeOrderDtlHTable == null)
            {
                return uoeSupplierName;
            }

            // INDEX�͈͊O
            if (this._uoeOrderDtlHTable.ContainsKey(uoeSupplierCd) == false)
            {
                return uoeSupplierName;
            }

            UOEOrderDtlInfo uoeOrderDtlInfo = (UOEOrderDtlInfo)this._uoeOrderDtlHTable[uoeSupplierCd];

            uoeSupplierName = uoeOrderDtlInfo.UOESupplierName;
            return uoeSupplierName;
        }
        #endregion
        #endregion ��UOE������}�X�^HashTable�֘A - end

        #region �������d���񓚏��HashTable�֘A
        #region ��CreateOrderAnsInfoHTable(HashTable�쐬)
        /// <summary>
        /// �����d���񓚏��HashTable�쐬
        /// </summary>
        /// <param name="orderSndRcvJnlList">UOE����M�W���[�i��(����)���X�g</param>
        /// <remarks>
        /// <br>Note       : �n���ꂽUOE����M�W���[�i��(����)���X�g��UOE������AUOE�����ԍ��P�ʂɂ܂Ƃ߂�HashTable�Ɋi�[���܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        private void CreateOrderAnsInfoHTable(List<OrderSndRcvJnl> orderSndRcvJnlList)
        {
            string bfKey = string.Empty;
            int listCnt = 0;
            int hashTableCnt = 0;
            List<OrderSndRcvJnl> orderAnsInfoListGroup = new List<OrderSndRcvJnl>();

            this._supplyAnsInfoHTable = new Hashtable();
            foreach (OrderSndRcvJnl orderSndRcvJnl in orderSndRcvJnlList)
            {
                // �L�[�FUOE������-�I�����C���ԍ�
                // 2009/01/22 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //string key = orderSndRcvJnl.UOESupplierCd + "-" + orderSndRcvJnl.UOESalesOrderNo;
                string key = orderSndRcvJnl.UOESupplierCd + "-" + orderSndRcvJnl.OnlineNo;
                // 2009/01/22 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                if ((bfKey != key) && (bfKey != string.Empty))
                {
                    // �ŏ��ȊO�ŃL�[���ς������
                    // UOE������,�����ԍ��P�ʂɂ܂Ƃ߂��f�[�^��HashTable�ɒǉ�
                    this._supplyAnsInfoHTable[hashTableCnt] = orderAnsInfoListGroup;
                    hashTableCnt++;

                    // ������
                    orderAnsInfoListGroup = new List<OrderSndRcvJnl>();
                    listCnt = 0;
                }

                orderAnsInfoListGroup.Add(orderSndRcvJnl);
                listCnt++;

                bfKey = key;
            }

            // �Ō�̃f�[�^��HashTable�ɒǉ�
            this._supplyAnsInfoHTable[hashTableCnt] = orderAnsInfoListGroup;

            // �����ʒu
            this._supplyAnsInfoHTableIndex = -1;
        }
        #endregion

        #region ��GetDispInfoAll(HashTable�f�[�^�擾)
        /// <summary>
        /// �����񓚏��HashTable�f�[�^�擾
        /// </summary>
        /// <param name="index">�����ʒu</param>
        /// <param name="supplierDataSet">�O���b�h���׈ȊO(�w�b�_�[�A�O���b�h�w�b�_�[�A���v)�̃f�[�^</param>
        /// <param name="detailDataSet">�O���b�h���׃f�[�^</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽindex�����ɔ����񓚏��HashTable����f�[�^���擾���܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// <br>UpdateNote  : 2011/08/24 yangmj</br>
        /// <br>            : redmine #23905�̑Ή�</br>
        /// </remarks>
        private bool GetDispInfoAll(int index, out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            detailDataSet = null;
            supplierDataSet = null;

            // �f�[�^������
            if (this._supplyAnsInfoHTable == null)
            {
                return false;
            }

            // INDEX�͈͊O
            if (this._supplyAnsInfoHTable.ContainsKey(index) == false)
            {
                return false;
            }
             
            // ���חpDataTable�쐬
            DataTable detailDataTable = null;
            PMUOE01352EA.CreateDataTableDetail(ref detailDataTable);

            List<OrderSndRcvJnl> orderSndRcvJnlList = (List<OrderSndRcvJnl>)this._supplyAnsInfoHTable[index];
            // ------ADD 2011/08/24----->>>>>
            string beReceiveDateYMD = string.Empty;
            string beReceiveTime = string.Empty;
            int cnt = 0;
            // ------ADD 2011/08/24-----<<<<<
            foreach (OrderSndRcvJnl orderSndRcvJnl in orderSndRcvJnlList)
            {
                // dataRow�쐬
                DataRow detailDataRow = detailDataTable.NewRow();

                //this.CopyToDataRowFromOrderSndRcvJnl(orderSndRcvJnl, ref detailDataRow);// DEL 2011/08/24
                this.CopyToDataRowFromOrderSndRcvJnl(orderSndRcvJnl, ref detailDataRow, ref beReceiveDateYMD, ref beReceiveTime, ref cnt);// ADD 2011/08/24

                detailDataTable.Rows.Add(detailDataRow);
            }

            detailDataSet = new DataSet();
            detailDataSet.Tables.Add(detailDataTable);

            this._supplyAnsInfoHTableIndex = index;      // ���݂̈ʒu
            return true;
        }
        #endregion

        #region ��CopyToDataRowFromOrderSndRcvJnl(UOE����M�W���[�i����DataRow�R�s�[)
        /// <summary>
        /// UOE����M�W���[�i��(����)��DataRow�쐬
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="orderSndRcvJnl"></param>
        /// <remarks>
        /// <br>Note       : UOE����M�W���[�i��(����)�̓��e������DataRow���쐬���܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// <br>UpdateNote  : 2011/08/24 yangmj</br>
        /// <br>            : redmine #23905�̑Ή�</br>
        /// </remarks>
        //private void CopyToDataRowFromOrderSndRcvJnl(OrderSndRcvJnl orderSndRcvJnl, ref DataRow dataRow, ref string beReceiveDateYMD)// DEL 2011/08/24
        private void CopyToDataRowFromOrderSndRcvJnl(OrderSndRcvJnl orderSndRcvJnl, ref DataRow dataRow, ref string beReceiveDateYMD, ref string beReceiveTime, ref int cnt)// ADD 2011/08/24
        {
            dataRow[PMUOE01352EA.ct_Col_UOESalesOrderNo] = orderSndRcvJnl.UOESalesOrderNo;              // UOE�����ԍ�
            dataRow[PMUOE01352EA.ct_Col_UOESalesOrderRowNo] = orderSndRcvJnl.UOESalesOrderRowNo;        // UOE�����s�ԍ�
            dataRow[PMUOE01352EA.ct_Col_ReceiveDate] = orderSndRcvJnl.ReceiveDate.ToShortDateString();   // ��M��
            // ---- ADD caohh 2011/08/10 -------->>>>>
            // ------UPD 2011/08/24----->>>>>
            string receiveDateYMD = TDateTime.DateTimeToString("YY/MM/DD", orderSndRcvJnl.ReceiveDate);  // ��M��(YY/MM/DD)
            //string receiveTime = orderSndRcvJnl.ReceiveTime.ToString().Substring(0, 2) + ":" + orderSndRcvJnl.ReceiveTime.ToString().Substring(2, 2) + ":" + orderSndRcvJnl.ReceiveTime.ToString().Substring(4, 2); // ��M����  //DEL 2011/09/27 M.Kubota
            
            //--- ADD 2011/09/27 M.Kubota --->>>
            // �O�q�̏������@�ł́A���Ԃ��P���̏ꍇ�ɑS���łT�����ƂȂ� Substring �ŗ�O����������
            int hh = (int)(orderSndRcvJnl.ReceiveTime / 10000); // ��
            int mm = orderSndRcvJnl.ReceiveTime / 100 % 100;    // ��
            int ss = orderSndRcvJnl.ReceiveTime % 100;          // �b
            string receiveTime = string.Format("{0}:{1}:{2}", hh, mm, ss);  // ��M����
            //--- ADD 2011/09/27 M.Kubota ---<<<
            
            if (string.IsNullOrEmpty(beReceiveDateYMD) || string.IsNullOrEmpty(beReceiveTime))
            {
                beReceiveDateYMD = receiveDateYMD;
                beReceiveTime = receiveTime;
                dataRow[PMUOE01352EA.ct_Col_ReceiveDateYMD] = receiveDateYMD;
                dataRow[PMUOE01352EA.ct_Col_ReceiveTime] = receiveTime;
            }
            else if (beReceiveDateYMD.Equals(receiveDateYMD) && beReceiveTime.Equals(receiveTime))
            {
                if (cnt % 10 != 0)
                {
                    dataRow[PMUOE01352EA.ct_Col_ReceiveDateYMD] = string.Empty;
                    dataRow[PMUOE01352EA.ct_Col_ReceiveTime] = string.Empty;
                }
                else
                {
                    dataRow[PMUOE01352EA.ct_Col_ReceiveDateYMD] = receiveDateYMD;
                    dataRow[PMUOE01352EA.ct_Col_ReceiveTime] = receiveTime;
                }
            }
            else
            {
                beReceiveDateYMD = receiveDateYMD;
                beReceiveTime = receiveTime;
                dataRow[PMUOE01352EA.ct_Col_ReceiveDateYMD] = receiveDateYMD;
                dataRow[PMUOE01352EA.ct_Col_ReceiveTime] = receiveTime;
            }
            cnt++;
            //dataRow[PMUOE01352EA.ct_Col_ReceiveDateYMD] = TDateTime.DateTimeToString("YY/MM/DD", orderSndRcvJnl.ReceiveDate);  // ��M��(YY/MM/DD)
            //dataRow[PMUOE01352EA.ct_Col_ReceiveTime] = orderSndRcvJnl.ReceiveTime.ToString().Substring(0, 2) + ":" + orderSndRcvJnl.ReceiveTime.ToString().Substring(2, 2) + ":" + orderSndRcvJnl.ReceiveTime.ToString().Substring(4, 2); // ��M����
            // ------UPD 2011/08/24-----<<<<<
            // �[�i�敪����
            dataRow[PMUOE01352EA.ct_Col_DeliveredGoodsDivNm] = orderSndRcvJnl.UOEDeliGoodsDiv;
            // ���[�J�[�R�[�h
            dataRow[PMUOE01352EA.ct_Col_GoodsMakerCd] = orderSndRcvJnl.GoodsMakerCd == 0 ? string.Empty : orderSndRcvJnl.GoodsMakerCd.ToString();
            // ---- ADD caohh 2011/08/10 --------<<<<<
            dataRow[PMUOE01352EA.ct_Col_GoodsNo] = orderSndRcvJnl.GoodsNo;                              // �i��
            dataRow[PMUOE01352EA.ct_Col_AnswerpartsName] = orderSndRcvJnl.AnswerPartsName;              // �񓚕i��
            dataRow[PMUOE01352EA.ct_Col_AnswerSalesUnitCost] = orderSndRcvJnl.AnswerSalesUnitCost;      // �񓚌����P��
            dataRow[PMUOE01352EA.ct_Col_UOESectionSlipNo] = orderSndRcvJnl.UOESectionSlipNo;            // UOE���_�`�[�ԍ�
            dataRow[PMUOE01352EA.ct_Col_UOECheckCode] = orderSndRcvJnl.UOECheckCode;                    // UOE�`�F�b�N�R�[�h
            dataRow[PMUOE01352EA.ct_Col_UoeRemark1] = orderSndRcvJnl.UoeRemark1;                        // UOE���}�[�N1
            dataRow[PMUOE01352EA.ct_Col_AnswerpartsNo] = orderSndRcvJnl.AnswerPartsNo;                  // �񓚕i��
            dataRow[PMUOE01352EA.ct_Col_AcceptAnOrderCnt] = orderSndRcvJnl.AcceptAnOrderCnt;            // �󒍐���
            dataRow[PMUOE01352EA.ct_Col_AnswerListPrice] = orderSndRcvJnl.AnswerListPrice;              // �񓚒艿
            dataRow[PMUOE01352EA.ct_Col_UOESectOutGoodsCnt] = orderSndRcvJnl.UOESectOutGoodsCnt;        // UOE���_�o�ɐ�
            // 2009/01/22 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // �c�̕\����"���o�ɐ�"��"�󒍐���-UOE���_�o�ɐ�"�ɕύX
            //dataRow[PMUOE01352EA.ct_Col_NonShipmentCnt] = orderSndRcvJnl.NonShipmentCnt;                // ���o�ɐ�
            dataRow[PMUOE01352EA.ct_Col_NonShipmentCnt] = orderSndRcvJnl.AcceptAnOrderCnt - orderSndRcvJnl.UOESectOutGoodsCnt;
                                                                                                        // �󒍐���-UOE���_�o�ɐ�
            // 2009/01/22  UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            dataRow[PMUOE01352EA.ct_Col_LineErrorMessage] = orderSndRcvJnl.LineErrorMassage;            // ���C���G���[���b�Z�[�W

            // UOE�[�i�敪
            dataRow[PMUOE01352EA.ct_Col_DeliGoodsDiv] = orderSndRcvJnl.DeliveredGoodsDivNm;

            // ���[�J�[�R�[�h
            if (orderSndRcvJnl.GoodsMakerCd == 0)
            {
                dataRow[PMUOE01352EA.ct_Col_MakerName] = string.Empty;
            }
            else
            {
                dataRow[PMUOE01352EA.ct_Col_MakerName] = orderSndRcvJnl.MakerName;
            }
        }
        #endregion
        #endregion �������񓚏��HashTable�֘A - end

        #region �������f�[�^��OrderSndRcvJnl�쐬�֘A(�P�̋N����p)
        #region ��CreateOrderSndRcvJnl(UOE����M�W���[�i��(����)�쐬�@�P�̋N����p)
        /// <summary>
        /// UOE����M�W���[�i���쐬(�P�̋N����p)
        /// </summary>
        /// <param name="uoeAnswerLedgerOrderCndtn">�����f�[�^���o����</param>
        /// <param name="errorMsg">�G���[���b�Z�[�W</param>
        /// <param name="orderSndRcvJnlList">UOE����M�W���[�i��</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : ���o���������ɔ����f�[�^���擾��AUOE����M�W���[�i�����쐬���܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        private bool CreateOrderSndRcvJnl(UOEAnswerLedgerOrderCndtn uoeAnswerLedgerOrderCndtn, out string errorMsg, out List<OrderSndRcvJnl> orderSndRcvJnlList)
        {
            errorMsg = string.Empty;
            orderSndRcvJnlList = new List<OrderSndRcvJnl>();

            // ���o����
            UOEAnswerLedgerOrderCndtnWork uoeAnswerLedgerOrderCndtnWork = new UOEAnswerLedgerOrderCndtnWork();
            uoeAnswerLedgerOrderCndtnWork.EnterpriseCode = uoeAnswerLedgerOrderCndtn.EnterpriseCode;        // ��ƃR�[�h
            uoeAnswerLedgerOrderCndtnWork.SectionCode = uoeAnswerLedgerOrderCndtn.SectionCode;              // ���_�R�[�h
            uoeAnswerLedgerOrderCndtnWork.SystemDivCd = uoeAnswerLedgerOrderCndtn.SystemDivCd;              // �V�X�e���敪(-1�F�S�� �Œ�)
            uoeAnswerLedgerOrderCndtnWork.St_ReceiveDate = uoeAnswerLedgerOrderCndtn.St_ReceiveDate;        // �J�n������
            uoeAnswerLedgerOrderCndtnWork.Ed_ReceiveDate = uoeAnswerLedgerOrderCndtn.Ed_ReceiveDate;        // �I��������
            uoeAnswerLedgerOrderCndtnWork.UOESupplierCd = uoeAnswerLedgerOrderCndtn.UOESupplierCd;          // ������
            uoeAnswerLedgerOrderCndtnWork.UOEKind = uoeAnswerLedgerOrderCndtn.UOEKind;                      // UOE���(1:�����d����M)
            uoeAnswerLedgerOrderCndtnWork.St_InputDay = uoeAnswerLedgerOrderCndtn.St_InputDay;              // �J�n���͓�
            uoeAnswerLedgerOrderCndtnWork.Ed_InputDay = uoeAnswerLedgerOrderCndtn.Ed_InputDay;              // �I�����͓�

            // �f�[�^���o            
            Object arrayList = null;
            int status = this._iUOEAnswerLedgerOrderWorkDB.Search(out arrayList, (object)uoeAnswerLedgerOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetDataAll);
            //@@int status = this.TestSearch(out arrayList, (object)uoeAnswerLedgerOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        errorMsg = "�Y���f�[�^������܂���";
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                default:
                    errorMsg = "�����f�[�^�̓Ǎ��Ɏ��s���܂����B";
                    return false;
            }

            // �����f�[�^��UOE����M�W���[�i���p��List�ɃZ�b�g
            foreach (UOEAnswerLedgerResultWork uoeAnswerLedgerResultWork in (ArrayList)arrayList)
            {
                OrderSndRcvJnl orderSndRcvJnl;

                this.CopyToOrderSndRcvJnlFromUOEAnswerLedgerResultWork(uoeAnswerLedgerResultWork, out orderSndRcvJnl);

                orderSndRcvJnlList.Add(orderSndRcvJnl);
            }


            return true;
        }
        #endregion

        #region test
        private int TestSearch(out object uOEAnswerLedgerResultWork, object uOEAnswerLedgerOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            ArrayList al = new ArrayList();

            #region ���o����-�l�Z�b�g0

            #region ���o����-�l�Z�b�g0-1
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork01 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork01.SectionCode = "99";
            _UOEAnswerLedgerResultWork01.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork01.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork01.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork01.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            //_UOEAnswerLedgerResultWork01.FileHeaderGuid = 
            _UOEAnswerLedgerResultWork01.UpdEmployeeCode = "1234";
            //_UOEAnswerLedgerResultWork01.UpdAssemblyId1 = 
            //_UOEAnswerLedgerResultWork01.UpdAssemblyId2 = 
            _UOEAnswerLedgerResultWork01.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork01.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork01.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork01.UOESalesOrderRowNo = 0;
            //_UOEAnswerLedgerResultWork01.SendTerminalNo = 
            //_UOEAnswerLedgerResultWork01.UOESupplierCd = 
            //_UOEAnswerLedgerResultWork01.UOESupplierName = 
            //_UOEAnswerLedgerResultWork01.CommAssemblyId = 
            //_UOEAnswerLedgerResultWork01.OnlineNo = 
            //_UOEAnswerLedgerResultWork01.OnlineRowNo = 
            //_UOEAnswerLedgerResultWork01.SalesDate = 
            //_UOEAnswerLedgerResultWork01.InputDay = 
            //_UOEAnswerLedgerResultWork01.DataUpdateDateTime = 
            //_UOEAnswerLedgerResultWork01.UOEKind = 
            //_UOEAnswerLedgerResultWork01.SubSectionCode = 
            //_UOEAnswerLedgerResultWork01.CustomerCode = 
            //_UOEAnswerLedgerResultWork01.CustomerSnm = 
            //_UOEAnswerLedgerResultWork01.CashRegisterNo = 
            //_UOEAnswerLedgerResultWork01.BoCode = 
            _UOEAnswerLedgerResultWork01.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork01.DeliveredGoodsDivNm = "�敪��";
            //_UOEAnswerLedgerResultWork01.FollowDeliGoodsDiv = 
            //_UOEAnswerLedgerResultWork01.FollowDeliGoodsDivNm = 
            //_UOEAnswerLedgerResultWork01.UOEResvdSection = 
            //_UOEAnswerLedgerResultWork01.UOEResvdSectionNm = 
            //_UOEAnswerLedgerResultWork01.EmployeeCode = 
            //_UOEAnswerLedgerResultWork01.EmployeeName = 
            _UOEAnswerLedgerResultWork01.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork01.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork01.GoodsNo = "30009-123456test";
            //_UOEAnswerLedgerResultWork01.GoodsNoNoneHyphen = 
            //_UOEAnswerLedgerResultWork01.GoodsName = "�˂�";
            //_UOEAnswerLedgerResultWork01.WarehouseCode = 
            //_UOEAnswerLedgerResultWork01.WarehouseName = 
            //_UOEAnswerLedgerResultWork01.WarehouseShelfNo = 
            _UOEAnswerLedgerResultWork01.AcceptAnOrderCnt = 120;
            //_UOEAnswerLedgerResultWork01.ListPrice = 
            //_UOEAnswerLedgerResultWork01.SalesUnitCost = 
            //_UOEAnswerLedgerResultWork01.SupplierCd = 
            //_UOEAnswerLedgerResultWork01.SupplierSnm = 
            _UOEAnswerLedgerResultWork01.UoeRemark1 = "��܁[����1";
            //_UOEAnswerLedgerResultWork01.UoeRemark2 = 
            _UOEAnswerLedgerResultWork01.ReceiveDate = DateTime.Now;
            //_UOEAnswerLedgerResultWork01.ReceiveTime = 
            //_UOEAnswerLedgerResultWork01.AnswerMakerCd = 
            _UOEAnswerLedgerResultWork01.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork01.AnswerPartsName = "�˂�";
            //_UOEAnswerLedgerResultWork01.SubstPartsNo = 
            _UOEAnswerLedgerResultWork01.UOESectOutGoodsCnt = 113;
            //_UOEAnswerLedgerResultWork01.BOShipmentCnt1 = 
            //_UOEAnswerLedgerResultWork01.BOShipmentCnt2 = 
            //_UOEAnswerLedgerResultWork01.BOShipmentCnt3 = 
            //_UOEAnswerLedgerResultWork01.MakerFollowCnt = 
            _UOEAnswerLedgerResultWork01.NonShipmentCnt = 12;
            //_UOEAnswerLedgerResultWork01.UOESectStockCnt = 
            //_UOEAnswerLedgerResultWork01.BOStockCount1 = 
            //_UOEAnswerLedgerResultWork01.BOStockCount2 = 
            //_UOEAnswerLedgerResultWork01.BOStockCount3 = 
            _UOEAnswerLedgerResultWork01.UOESectionSlipNo = "10011";
            //_UOEAnswerLedgerResultWork01.BOSlipNo1 = 
            //_UOEAnswerLedgerResultWork01.BOSlipNo2 = 
            //_UOEAnswerLedgerResultWork01.BOSlipNo3 = 
            //_UOEAnswerLedgerResultWork01.EOAlwcCount = 
            //_UOEAnswerLedgerResultWork01.BOManagementNo = 
            _UOEAnswerLedgerResultWork01.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork01.AnswerSalesUnitCost = 1200;
            //_UOEAnswerLedgerResultWork01.UOESubstMark = 
            //_UOEAnswerLedgerResultWork01.UOEStockMark = 
            //_UOEAnswerLedgerResultWork01.PartsLayerCd = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEShipSectCd1 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEShipSectCd2 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEShipSectCd3 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd1 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd2 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd3 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd4 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd5 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd6 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd7 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt1 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt2 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt3 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt4 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt5 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt6 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt7 = 
            //_UOEAnswerLedgerResultWork01.UOEDistributionCd = 
            //_UOEAnswerLedgerResultWork01.UOEOtherCd = 
            //_UOEAnswerLedgerResultWork01.UOEHMCd = 
            //_UOEAnswerLedgerResultWork01.BOCount = 
            //_UOEAnswerLedgerResultWork01.UOEMarkCode = 
            //_UOEAnswerLedgerResultWork01.SourceShipment = 
            //_UOEAnswerLedgerResultWork01.ItemCode = 
            _UOEAnswerLedgerResultWork01.UOECheckCode = "check";
            //_UOEAnswerLedgerResultWork01.HeadErrorMassage = 
            _UOEAnswerLedgerResultWork01.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork01);
            #endregion

            #region ���o����-�l�Z�b�g0-2
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork02 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork02.SectionCode = "99";
            _UOEAnswerLedgerResultWork02.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork02.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork02.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork02.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork02.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork02.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork02.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork02.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork02.UOESalesOrderRowNo = 1;
            _UOEAnswerLedgerResultWork02.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork02.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork02.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork02.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork02.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork02.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork02.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork02.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork02.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork02.AnswerPartsName = "�˂�";
            _UOEAnswerLedgerResultWork02.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork02.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork02.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork02.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork02.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork02.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork02.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork02);
            #endregion

            #region ���o����-�l�Z�b�g0-3
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork03 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork03.SectionCode = "99";
            _UOEAnswerLedgerResultWork03.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork03.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork03.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork03.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork03.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork03.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork03.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork03.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork03.UOESalesOrderRowNo = 2;
            _UOEAnswerLedgerResultWork03.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork03.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork03.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork03.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork03.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork03.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork03.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork03.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork03.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork03.AnswerPartsName = "���܂˂�";
            _UOEAnswerLedgerResultWork03.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork03.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork03.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork03.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork03.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork03.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork03.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork03);
            #endregion

            #region ���o����-�l�Z�b�g0-4
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork04 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork04.SectionCode = "99";
            _UOEAnswerLedgerResultWork04.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork04.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork04.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork04.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork04.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork04.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork04.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork04.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork04.UOESalesOrderRowNo = 3;
            _UOEAnswerLedgerResultWork04.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork04.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork04.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork04.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork04.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork04.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork04.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork04.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork04.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork04.AnswerPartsName = "�˂�";
            _UOEAnswerLedgerResultWork04.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork04.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork04.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork04.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork04.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork04.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork04.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork04);
            #endregion

            #region ���o����-�l�Z�b�g0-5
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork05 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork05.SectionCode = "99";
            _UOEAnswerLedgerResultWork05.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork05.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork05.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork05.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork05.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork05.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork05.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork05.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork05.UOESalesOrderRowNo = 4;
            _UOEAnswerLedgerResultWork05.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork05.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork05.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork05.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork05.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork05.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork05.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork05.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork05.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork05.AnswerPartsName = "���܂˂�";
            _UOEAnswerLedgerResultWork05.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork05.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork05.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork05.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork05.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork05.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork05.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork05);
            #endregion

            #region ���o����-�l�Z�b�g0-6
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork06 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork06.SectionCode = "99";
            _UOEAnswerLedgerResultWork06.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork06.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork06.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork06.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork06.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork06.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork06.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork06.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork06.UOESalesOrderRowNo = 5;
            _UOEAnswerLedgerResultWork06.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork06.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork06.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork06.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork06.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork06.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork06.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork06.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork06.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork06.AnswerPartsName = "�˂�";
            _UOEAnswerLedgerResultWork06.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork06.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork06.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork06.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork06.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork06.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork06.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork06);
            #endregion

            #region ���o����-�l�Z�b�g0-7
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork07 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork07.SectionCode = "99";
            _UOEAnswerLedgerResultWork07.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork07.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork07.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork07.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork07.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork07.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork07.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork07.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork07.UOESalesOrderRowNo = 6;
            _UOEAnswerLedgerResultWork07.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork07.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork07.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork07.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork07.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork07.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork07.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork07.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork07.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork07.AnswerPartsName = "���܂˂�";
            _UOEAnswerLedgerResultWork07.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork07.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork07.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork07.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork07.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork07.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork07.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork07);
            #endregion

            #region ���o����-�l�Z�b�g0-8
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork08 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork08.SectionCode = "99";
            _UOEAnswerLedgerResultWork08.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork08.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork08.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork08.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork08.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork08.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork08.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork08.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork08.UOESalesOrderRowNo = 7;
            _UOEAnswerLedgerResultWork08.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork08.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork08.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork08.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork08.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork08.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork08.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork08.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork08.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork08.AnswerPartsName = "�˂�";
            _UOEAnswerLedgerResultWork08.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork08.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork08.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork08.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork08.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork08.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork08.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork08);
            #endregion

            #region ���o����-�l�Z�b�g0-9
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork09 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork09.SectionCode = "99";
            _UOEAnswerLedgerResultWork09.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork09.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork09.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork09.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork09.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork09.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork09.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork09.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork09.UOESalesOrderRowNo = 8;
            _UOEAnswerLedgerResultWork09.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork09.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork09.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork09.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork09.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork09.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork09.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork09.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork09.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork09.AnswerPartsName = "���܂˂�";
            _UOEAnswerLedgerResultWork09.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork09.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork09.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork09.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork09.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork09.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork09.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork09);
            #endregion

            #region ���o����-�l�Z�b�g0-10
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork0A = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork0A.SectionCode = "99";
            _UOEAnswerLedgerResultWork0A.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork0A.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork0A.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork0A.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork0A.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork0A.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork0A.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork0A.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork0A.UOESalesOrderRowNo = 9;
            _UOEAnswerLedgerResultWork0A.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork0A.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork0A.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork0A.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork0A.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork0A.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork0A.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork0A.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork0A.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork0A.AnswerPartsName = "���܂˂�";
            _UOEAnswerLedgerResultWork0A.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork0A.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork0A.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork0A.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork0A.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork0A.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork0A.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork0A);
            #endregion

            #region ���o����-�l�Z�b�g0-11
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork0B = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork0B.SectionCode = "99";
            _UOEAnswerLedgerResultWork0B.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork0B.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork0B.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork0B.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork0B.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork0B.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork0B.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork0B.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork0B.UOESalesOrderRowNo = 10;
            _UOEAnswerLedgerResultWork0B.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork0B.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork0B.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork0B.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork0B.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork0B.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork0B.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork0B.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork0B.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork0B.AnswerPartsName = "�˂�";
            _UOEAnswerLedgerResultWork0B.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork0B.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork0B.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork0B.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork0B.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork0B.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork0B.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork0B);
            #endregion

            #region ���o����-�l�Z�b�g0-12
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork0C = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork0C.SectionCode = "99";
            _UOEAnswerLedgerResultWork0C.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork0C.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork0C.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork0C.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork0C.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork0C.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork0C.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork0C.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork0C.UOESalesOrderRowNo = 11;
            _UOEAnswerLedgerResultWork0C.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork0C.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork0C.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork0C.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork0C.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork0C.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork0C.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork0C.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork0C.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork0C.AnswerPartsName = "���܂˂�";
            _UOEAnswerLedgerResultWork0C.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork0C.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork0C.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork0C.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork0C.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork0C.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork0C.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork0C);
            #endregion
            #endregion

            #region ���o����-�l�Z�b�g1

            #region ���o����-�l�Z�b�g1-1
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork11 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork11.SectionCode = "99";
            _UOEAnswerLedgerResultWork11.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork11.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork11.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork11.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork11.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork11.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork11.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork11.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork11.UOESalesOrderRowNo = 0;
            _UOEAnswerLedgerResultWork11.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork11.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork11.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork11.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork11.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork11.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork11.UoeRemark1 = "��܁[����2";
            _UOEAnswerLedgerResultWork11.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork11.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork11.AnswerPartsName = "�ʂ��";
            _UOEAnswerLedgerResultWork11.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork11.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork11.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork11.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork11.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork11.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork11.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork11);
            #endregion

            #region ���o����-�l�Z�b�g1-2
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork12 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork12.SectionCode = "99";
            _UOEAnswerLedgerResultWork12.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork12.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork12.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork12.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork12.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork12.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork12.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork12.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork12.UOESalesOrderRowNo = 1;
            _UOEAnswerLedgerResultWork12.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork12.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork12.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork12.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork12.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork12.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork12.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork12.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork12.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork12.AnswerPartsName = "�ʂ��";
            _UOEAnswerLedgerResultWork12.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork12.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork12.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork12.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork12.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork12.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork12.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork12);
            #endregion

            #region ���o����-�l�Z�b�g1-3
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork13 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork13.SectionCode = "99";
            _UOEAnswerLedgerResultWork13.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork13.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork13.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork13.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork13.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork13.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork13.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork13.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork13.UOESalesOrderRowNo = 2;
            _UOEAnswerLedgerResultWork13.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork13.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork13.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork13.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork13.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork13.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork13.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork13.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork13.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork13.AnswerPartsName = "�ʂ��";
            _UOEAnswerLedgerResultWork13.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork13.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork13.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork13.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork13.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork13.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork13.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork13);
            #endregion

            #region ���o����-�l�Z�b�g1-4
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork14 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork14.SectionCode = "99";
            _UOEAnswerLedgerResultWork14.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork14.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork14.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork14.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork14.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork14.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork14.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork14.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork14.UOESalesOrderRowNo = 3;
            _UOEAnswerLedgerResultWork14.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork14.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork14.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork14.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork14.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork14.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork14.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork14.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork14.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork14.AnswerPartsName = "�ʂ��";
            _UOEAnswerLedgerResultWork14.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork14.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork14.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork14.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork14.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork14.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork14.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork14);
            #endregion

            #region ���o����-�l�Z�b�g1-5
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork15 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork15.SectionCode = "99";
            _UOEAnswerLedgerResultWork15.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork15.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork15.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork15.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork15.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork15.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork15.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork15.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork15.UOESalesOrderRowNo = 4;
            _UOEAnswerLedgerResultWork15.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork15.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork15.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork15.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork15.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork15.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork15.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork15.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork15.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork15.AnswerPartsName = "�ʂ��";
            _UOEAnswerLedgerResultWork15.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork15.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork15.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork15.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork15.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork15.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork15.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork15);
            #endregion

            #region ���o����-�l�Z�b�g1-6
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork16 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork16.SectionCode = "99";
            _UOEAnswerLedgerResultWork16.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork16.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork16.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork16.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork16.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork16.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork16.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork16.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork16.UOESalesOrderRowNo = 5;
            _UOEAnswerLedgerResultWork16.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork16.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork16.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork16.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork16.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork16.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork16.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork16.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork16.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork16.AnswerPartsName = "�ʂ��";
            _UOEAnswerLedgerResultWork16.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork16.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork16.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork16.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork16.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork16.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork16.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork16);
            #endregion

            #region ���o����-�l�Z�b�g1-7
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork17 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork17.SectionCode = "99";
            _UOEAnswerLedgerResultWork17.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork17.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork17.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork17.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork17.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork17.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork17.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork17.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork17.UOESalesOrderRowNo = 6;
            _UOEAnswerLedgerResultWork17.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork17.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork17.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork17.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork17.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork17.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork17.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork17.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork17.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork17.AnswerPartsName = "�ʂ��";
            _UOEAnswerLedgerResultWork17.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork17.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork17.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork17.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork17.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork17.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork17.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork17);
            #endregion

            #region ���o����-�l�Z�b�g1-8
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork18 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork18.SectionCode = "99";
            _UOEAnswerLedgerResultWork18.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork18.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork18.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork18.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork18.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork18.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork18.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork18.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork18.UOESalesOrderRowNo = 7;
            _UOEAnswerLedgerResultWork18.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork18.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork18.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork18.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork18.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork18.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork18.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork18.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork18.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork18.AnswerPartsName = "�ʂ��";
            _UOEAnswerLedgerResultWork18.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork18.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork18.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork18.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork18.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork18.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork18.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork18);
            #endregion

            #region ���o����-�l�Z�b�g1-9
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork19 = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork19.SectionCode = "99";
            _UOEAnswerLedgerResultWork19.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork19.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork19.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork19.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork19.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork19.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork19.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork19.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork19.UOESalesOrderRowNo = 8;
            _UOEAnswerLedgerResultWork19.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork19.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork19.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork19.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork19.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork19.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork19.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork19.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork19.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork19.AnswerPartsName = "�ʂ��";
            _UOEAnswerLedgerResultWork19.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork19.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork19.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork19.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork19.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork19.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork19.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork19);
            #endregion

            #region ���o����-�l�Z�b�g1-10
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork1A = new UOEAnswerLedgerResultWork();
            //�i�[����
            _UOEAnswerLedgerResultWork1A.SectionCode = "99";
            _UOEAnswerLedgerResultWork1A.SectionGuideSnm = "�e�X�g���_";
            _UOEAnswerLedgerResultWork1A.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork1A.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork1A.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork1A.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork1A.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork1A.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork1A.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork1A.UOESalesOrderRowNo = 9;
            _UOEAnswerLedgerResultWork1A.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork1A.DeliveredGoodsDivNm = "�敪��";
            _UOEAnswerLedgerResultWork1A.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork1A.MakerName = "�a�J���i901234567890";
            _UOEAnswerLedgerResultWork1A.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork1A.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork1A.UoeRemark1 = "��܁[����1";
            _UOEAnswerLedgerResultWork1A.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork1A.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork1A.AnswerPartsName = "�ʂ��";
            _UOEAnswerLedgerResultWork1A.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork1A.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork1A.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork1A.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork1A.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork1A.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork1A.LineErrorMassage = "���C���G���[���b�Z�[�W";
            al.Add(_UOEAnswerLedgerResultWork1A);
            #endregion
            #endregion

            uOEAnswerLedgerResultWork = al;
            return 0;
        }
        #endregion


        #region ��CopyToOrderSndRcvJnlFromUOEAnswerLedgerResultWork(�����f�[�^��UOE����M�W���[�i���R�s�[�@�P�̋N����p)
        /// <summary>
        /// �����f�[�^��UOE����M�W���[�i���R�s�[(�P�̋N����p)
        /// </summary>
        /// <param name="uoeAnswerLedgerResultWork">�����f�[�^</param>
        /// <param name="orderSndRcvJnl">UOE����M�W���[�i��</param>
        /// <remarks>
        /// <br>Note       : �����f�[�^�̓��e������UOE����M�W���[�i��(����)���쐬���܂��B</br>
        /// <br>Programmer	: �a�J ���</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        private void CopyToOrderSndRcvJnlFromUOEAnswerLedgerResultWork(UOEAnswerLedgerResultWork uoeAnswerLedgerResultWork, out OrderSndRcvJnl orderSndRcvJnl)
        {
            orderSndRcvJnl = new OrderSndRcvJnl();
            orderSndRcvJnl.CreateDateTime = uoeAnswerLedgerResultWork.CreateDateTime;                   // �쐬����
            orderSndRcvJnl.UpdateDateTime = uoeAnswerLedgerResultWork.UpdateDateTime;                   // �X�V����
            orderSndRcvJnl.EnterpriseCode = uoeAnswerLedgerResultWork.EnterpriseCode;                   // ��ƃR�[�h
            orderSndRcvJnl.FileHeaderGuid = uoeAnswerLedgerResultWork.FileHeaderGuid;                   // GUID
            orderSndRcvJnl.UpdEmployeeCode = uoeAnswerLedgerResultWork.UpdEmployeeCode;                 // �X�V�]�ƈ��R�[�h
            orderSndRcvJnl.UpdAssemblyId1 = uoeAnswerLedgerResultWork.UpdAssemblyId1;                   // �X�V�A�Z���u��ID1
            orderSndRcvJnl.UpdAssemblyId2 = uoeAnswerLedgerResultWork.UpdAssemblyId2;                   // �X�V�A�Z���u��ID2
            orderSndRcvJnl.LogicalDeleteCode = uoeAnswerLedgerResultWork.LogicalDeleteCode;             // �_���폜�敪
            orderSndRcvJnl.SystemDivCd = uoeAnswerLedgerResultWork.SystemDivCd;                         // �V�X�e���敪
            orderSndRcvJnl.UOESalesOrderNo = uoeAnswerLedgerResultWork.UOESalesOrderNo;                 // UOE�����ԍ�
            orderSndRcvJnl.UOESalesOrderRowNo = uoeAnswerLedgerResultWork.UOESalesOrderRowNo;           // UOE�����s�ԍ�
            orderSndRcvJnl.SendTerminalNo = uoeAnswerLedgerResultWork.SendTerminalNo;                   // ���M�[���ԍ�
            orderSndRcvJnl.UOESupplierCd = uoeAnswerLedgerResultWork.UOESupplierCd;                     // UOE������R�[�h
            orderSndRcvJnl.UOESupplierName = uoeAnswerLedgerResultWork.UOESupplierName;                 // UOE�����於��
            orderSndRcvJnl.CommAssemblyId = uoeAnswerLedgerResultWork.CommAssemblyId;                   // �ʐM�A�Z���u��ID
            orderSndRcvJnl.OnlineNo = uoeAnswerLedgerResultWork.OnlineNo;                               // �I�����C���ԍ�
            orderSndRcvJnl.OnlineRowNo = uoeAnswerLedgerResultWork.OnlineRowNo;                         // �I�����C���s�ԍ�
            orderSndRcvJnl.SalesDate = uoeAnswerLedgerResultWork.SalesDate;                             // ������t
            orderSndRcvJnl.InputDay = uoeAnswerLedgerResultWork.InputDay;                               // ���͓�
            orderSndRcvJnl.DataUpdateDateTime = uoeAnswerLedgerResultWork.DataUpdateDateTime;           // �f�[�^�X�V����
            orderSndRcvJnl.UOEKind = uoeAnswerLedgerResultWork.UOEKind;                                 // UOE���
            orderSndRcvJnl.SectionCode = uoeAnswerLedgerResultWork.SectionCode;                         // ���_�R�[�h
            orderSndRcvJnl.SubSectionCode = uoeAnswerLedgerResultWork.SubSectionCode;                   // ����R�[�h
            orderSndRcvJnl.CustomerCode = uoeAnswerLedgerResultWork.CustomerCode;                       // ���Ӑ�R�[�h
            orderSndRcvJnl.CustomerSnm = uoeAnswerLedgerResultWork.CustomerSnm;                         // ���Ӑ旪��
            orderSndRcvJnl.CashRegisterNo = uoeAnswerLedgerResultWork.CashRegisterNo;                   // ���W�ԍ�
            orderSndRcvJnl.BoCode = uoeAnswerLedgerResultWork.BoCode;                                   // BO�敪
            orderSndRcvJnl.UOEDeliGoodsDiv = uoeAnswerLedgerResultWork.UOEDeliGoodsDiv;                 // UOE�[�i�敪
            orderSndRcvJnl.DeliveredGoodsDivNm = uoeAnswerLedgerResultWork.DeliveredGoodsDivNm;         // �[�i�敪����
            orderSndRcvJnl.FollowDeliGoodsDiv = uoeAnswerLedgerResultWork.FollowDeliGoodsDiv;           // �t�H���[�[�i�敪
            orderSndRcvJnl.FollowDeliGoodsDivNm = uoeAnswerLedgerResultWork.FollowDeliGoodsDivNm;       // �t�H���[�[�i�敪����
            orderSndRcvJnl.UOEResvdSection = uoeAnswerLedgerResultWork.UOEResvdSection;                 // UOE�w�苒�_
            orderSndRcvJnl.UOEResvdSectionNm = uoeAnswerLedgerResultWork.UOEResvdSectionNm;             // UOE�w�苒�_����
            orderSndRcvJnl.EmployeeCode = uoeAnswerLedgerResultWork.EmployeeCode;                       // �]�ƈ��R�[�h
            orderSndRcvJnl.EmployeeName = uoeAnswerLedgerResultWork.EmployeeName;                       // �]�ƈ�����
            orderSndRcvJnl.GoodsMakerCd = uoeAnswerLedgerResultWork.GoodsMakerCd;                       // ���i���[�J�[�R�[�h
            orderSndRcvJnl.MakerName = uoeAnswerLedgerResultWork.MakerName;                             // ���[�J�[����
            orderSndRcvJnl.GoodsNo = uoeAnswerLedgerResultWork.GoodsNo;                                 // ���i�ԍ�
            orderSndRcvJnl.GoodsNoNoneHyphen = uoeAnswerLedgerResultWork.GoodsNoNoneHyphen;             // �n�C�t�������i�ԍ�
            orderSndRcvJnl.GoodsName = uoeAnswerLedgerResultWork.GoodsName;                             // ���i����
            orderSndRcvJnl.WarehouseCode = uoeAnswerLedgerResultWork.WarehouseCode;                     // �q�ɃR�[�h
            orderSndRcvJnl.WarehouseName = uoeAnswerLedgerResultWork.WarehouseName;                     // �q�ɖ���
            orderSndRcvJnl.WarehouseShelfNo = uoeAnswerLedgerResultWork.WarehouseShelfNo;               // �q�ɒI��
            orderSndRcvJnl.AcceptAnOrderCnt = uoeAnswerLedgerResultWork.AcceptAnOrderCnt;               // �󒍐���
            orderSndRcvJnl.ListPrice = uoeAnswerLedgerResultWork.ListPrice;                             // �艿
            orderSndRcvJnl.SalesUnitCost = uoeAnswerLedgerResultWork.SalesUnitCost;                     // �����P��
            orderSndRcvJnl.SupplierCd = uoeAnswerLedgerResultWork.SupplierCd;                           // �d����R�[�h
            orderSndRcvJnl.SupplierSnm = uoeAnswerLedgerResultWork.SupplierSnm;                         // �d���旪��
            orderSndRcvJnl.UoeRemark1 = uoeAnswerLedgerResultWork.UoeRemark1;                           // UOE���}�[�N1
            orderSndRcvJnl.UoeRemark2 = uoeAnswerLedgerResultWork.UoeRemark2;                           // UOE���}�[�N2
            orderSndRcvJnl.ReceiveDate = uoeAnswerLedgerResultWork.ReceiveDate;                         // ��M���t
            orderSndRcvJnl.ReceiveTime = uoeAnswerLedgerResultWork.ReceiveTime;                         // ��M����
            orderSndRcvJnl.AnswerMakerCd = uoeAnswerLedgerResultWork.AnswerMakerCd;                     // �񓚃��[�J�[�R�[�h
            orderSndRcvJnl.AnswerPartsNo = uoeAnswerLedgerResultWork.AnswerPartsNo;                     // �񓚕i��
            orderSndRcvJnl.AnswerPartsName = uoeAnswerLedgerResultWork.AnswerPartsName;                 // �񓚕i��
            orderSndRcvJnl.SubstPartsNo = uoeAnswerLedgerResultWork.SubstPartsNo;                       // ��֕i��
            orderSndRcvJnl.UOESectOutGoodsCnt = uoeAnswerLedgerResultWork.UOESectOutGoodsCnt;           // UOE���_�o�ɐ�
            orderSndRcvJnl.BOShipmentCnt1 = uoeAnswerLedgerResultWork.BOShipmentCnt1;                   // BO�o�ɐ�1
            orderSndRcvJnl.BOShipmentCnt2 = uoeAnswerLedgerResultWork.BOShipmentCnt2;                   // BO�o�ɐ�2
            orderSndRcvJnl.BOShipmentCnt3 = uoeAnswerLedgerResultWork.BOShipmentCnt3;                   // BO�o�ɐ�3
            orderSndRcvJnl.MakerFollowCnt = uoeAnswerLedgerResultWork.MakerFollowCnt;                   // ���[�J�[�t�H���[��
            orderSndRcvJnl.NonShipmentCnt = uoeAnswerLedgerResultWork.NonShipmentCnt;                   // ���o�ɐ�
            orderSndRcvJnl.UOESectStockCnt = uoeAnswerLedgerResultWork.UOESectStockCnt;                 // UOE���_�݌ɐ�
            orderSndRcvJnl.BOStockCount1 = uoeAnswerLedgerResultWork.BOStockCount1;                     // BO�݌ɐ�1
            orderSndRcvJnl.BOStockCount2 = uoeAnswerLedgerResultWork.BOStockCount2;                     // BO�݌ɐ�2
            orderSndRcvJnl.BOStockCount3 = uoeAnswerLedgerResultWork.BOStockCount3;                     // BO�݌ɐ�3
            orderSndRcvJnl.UOESectionSlipNo = uoeAnswerLedgerResultWork.UOESectionSlipNo;               // UOE���_�`�[�ԍ�
            orderSndRcvJnl.BOSlipNo1 = uoeAnswerLedgerResultWork.BOSlipNo1;                             // BO�`�[�ԍ�1
            orderSndRcvJnl.BOSlipNo2 = uoeAnswerLedgerResultWork.BOSlipNo2;                             // BO�`�[�ԍ�2
            orderSndRcvJnl.BOSlipNo3 = uoeAnswerLedgerResultWork.BOSlipNo3;                             // BO�`�[�ԍ�3
            orderSndRcvJnl.EOAlwcCount = uoeAnswerLedgerResultWork.EOAlwcCount;                         // EO������
            orderSndRcvJnl.BOManagementNo = uoeAnswerLedgerResultWork.BOManagementNo;                   // BO�Ǘ��ԍ�
            //2009/01/22 UPD>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //orderSndRcvJnl.ListPrice = uoeAnswerLedgerResultWork.ListPrice;                             // �񓚒艿
            //orderSndRcvJnl.SalesUnitCost = uoeAnswerLedgerResultWork.SalesUnitCost;                     // �񓚌����P��
            orderSndRcvJnl.AnswerListPrice = uoeAnswerLedgerResultWork.AnswerListPrice;                 // �񓚒艿
            orderSndRcvJnl.AnswerSalesUnitCost = uoeAnswerLedgerResultWork.AnswerSalesUnitCost;         // �񓚌����P��
            //2009/01/22 UPD<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
           
            orderSndRcvJnl.UOESubstMark = uoeAnswerLedgerResultWork.UOESubstMark;                       // UOE��փ}�[�N
            orderSndRcvJnl.UOEStockMark = uoeAnswerLedgerResultWork.UOEStockMark;                       // UOE�݌Ƀ}�[�N
            orderSndRcvJnl.PartsLayerCd = uoeAnswerLedgerResultWork.PartsLayerCd;                       // �w�ʃR�[�h
            orderSndRcvJnl.MazdaUOEShipSectCd1 = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd1;         // UOE�o�׋��_�R�[�h1(�}�c�_)
            orderSndRcvJnl.MazdaUOEShipSectCd2 = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd2;         // UOE�o�׋��_�R�[�h2(�}�c�_)
            orderSndRcvJnl.MazdaUOEShipSectCd3 = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd3;         // UOE�o�׋��_�R�[�h3(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd1 = uoeAnswerLedgerResultWork.MazdaUOESectCd1;                 // UOE���_�R�[�h1(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd2 = uoeAnswerLedgerResultWork.MazdaUOESectCd2;                 // UOE���_�R�[�h2(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd3 = uoeAnswerLedgerResultWork.MazdaUOESectCd3;                 // UOE���_�R�[�h3(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd4 = uoeAnswerLedgerResultWork.MazdaUOESectCd4;                 // UOE���_�R�[�h4(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd5 = uoeAnswerLedgerResultWork.MazdaUOESectCd5;                 // UOE���_�R�[�h5(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd6 = uoeAnswerLedgerResultWork.MazdaUOESectCd6;                 // UOE���_�R�[�h6(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd7 = uoeAnswerLedgerResultWork.MazdaUOESectCd7;                 // UOE���_�R�[�h7(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt1 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt1;             // UOE�݌ɐ�1(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt2 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt2;             // UOE�݌ɐ�2(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt3 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt3;             // UOE�݌ɐ�3(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt4 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt4;             // UOE�݌ɐ�4(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt5 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt5;             // UOE�݌ɐ�5(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt6 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt6;             // UOE�݌ɐ�6(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt7 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt7;             // UOE�݌ɐ�7(�}�c�_)
            orderSndRcvJnl.UOEDistributionCd = uoeAnswerLedgerResultWork.UOEDistributionCd;             // UOE���R�[�h
            orderSndRcvJnl.UOEOtherCd = uoeAnswerLedgerResultWork.UOEOtherCd;                           // UOE���R�[�h
            orderSndRcvJnl.UOEHMCd = uoeAnswerLedgerResultWork.UOEHMCd;                                 // UOE�g�l�R�[�h
            orderSndRcvJnl.BOCount = uoeAnswerLedgerResultWork.BOCount;                                 // BO��
            orderSndRcvJnl.UOEMarkCode = uoeAnswerLedgerResultWork.UOEMarkCode;                         // UOE�}�[�N�R�[�h
            orderSndRcvJnl.SourceShipment = uoeAnswerLedgerResultWork.SourceShipment;                   // �o�׌�
            orderSndRcvJnl.ItemCode = uoeAnswerLedgerResultWork.ItemCode;                               // �A�C�e���R�[�h
            orderSndRcvJnl.UOECheckCode = uoeAnswerLedgerResultWork.UOECheckCode;                       // UOE�`�F�b�N�R�[�h
            orderSndRcvJnl.HeadErrorMassage = uoeAnswerLedgerResultWork.HeadErrorMassage;              // �w�b�h�G���[���b�Z�[�W
            orderSndRcvJnl.LineErrorMassage = uoeAnswerLedgerResultWork.LineErrorMassage;              // ���C���G���[���b�Z�[�W
        }
        #endregion
        #endregion �������f�[�^��OrderSndRcvJnl�쐬�֘A - end
        #endregion ��Private���\�b�h - end
    }
}

