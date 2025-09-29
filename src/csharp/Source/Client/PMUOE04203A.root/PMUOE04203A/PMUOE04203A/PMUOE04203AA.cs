# region ��using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
# endregion

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE�񓚕\��(�P��) �e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
	/// <br>Note		: UOE�񓚃f�[�^�̌������s���܂��B</br>
	/// <br>Programmer	: �Ɠc �M�u</br>
    /// <br>Date		: 2008/11/10</br>
    /// <br>UpdateNote  : 2008/12/19 �Ɠc �M�u�@���o�����N���X���ڒǉ�</br>
    /// <br>              2009/01/07 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>              2009/01/13 �Ɠc �M�u�@�s��Ή�[9834][9872]</br>
    /// <br>              2009/01/21 �Ɠc �M�u�@�s��Ή�[9876]</br>
    /// </remarks>
    public class PMUOE04203AA
    {
        # region ���萔�A�ϐ��A�\����
        // �ʐM�A�Z���u��ID(�ʐM�v���O����ID)
        private const int PROGRAMID_NOTHING = 0;            // �Ȃ�
        private const int PROGRAMID_TOYOTA = 102;           // �g���^
        private const int PROGRAMID_NISSAN = 202;           // �j�b�T��
        private const int PROGRAMID_MITSUBISHI = 301;       // �~�c�r�V
        private const int PROGRAMID_MATSUDA_OLD = 401;      // ���}�c�_
        private const int PROGRAMID_MATSUDA_NEW = 402;      // �V�}�c�_
        private const int PROGRAMID_HONDA = 501;            // �z���_
        // �ϐ�
        private Hashtable _uoeOrderDtlHTable = null;        // UOE������}�X�^(key�FUOE������R�[�h)
        private Hashtable _customerHTable = null;           // ���Ӑ�}�X�^(key�F���Ӑ�R�[�h)
        private DataSet _uoeReplyDataSet = null;            // UOE�񓚃f�[�^
        private DataView _uoeReplyDataView = null;          // UOE�񓚃f�[�^(����p�ɁA�`�F�b�N���ꂽ���̂𒊏o)
        private string _enterpriseCode = string.Empty;      // ��ƃR�[�h
        private string _sectionCode = string.Empty;         // ���_�R�[�h

        private IUOEAnswerLedgerOrderWorkDB _iUOEAnswerLedgerOrderWorkDB = null;      // �����f�[�^�擾�p�����[�g�I�u�W�F�N�g
        // ��������
        #region UOEOrderDtlInfo�\����
        /// <summary>
        /// UOE��������@�\����
        /// </summary>
        public struct UOEOrderDtlInfo
        {
            /// <summary> �A�Z���u��ID </summary>
            public string CommAssemblyId;
            /// <summary> �����於�� </summary>
            public string UOESupplierName;
        }
        #endregion ���萔�A�ϐ��A�\���� - end
        # endregion

		#region ���C�x���g
        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
		public delegate void SettingStatusBarMessageEventHandler( object sender, string message );
		#endregion

		# region ��Constracter
		/// <summary>
		/// �R���X�g���N�^
        /// </summary>
        /// <remarks>
		/// <br>Note       : �C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public PMUOE04203AA()
        {
            // ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���_�R�[�h���擾����
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // �I�t���C���`�F�b�N
            if (!LoginInfoAcquisition.OnlineFlag)
            {
                MessageBox.Show("�I�t���C����Ԃ̂��ߌ��������s�ł��܂���B");
                return;
            }

            // �����[�g�I�u�W�F�N�g�擾
            this._iUOEAnswerLedgerOrderWorkDB = (IUOEAnswerLedgerOrderWorkDB)MediationUOEAnswerLedgerOrderWorkDB.GetUOEAnswerLedgerOrderWorkDB();

            // UOE�񓚕\��DataSet(�f�[�^�Ȃ��A�O���b�h���C�A�E�g�ݒ�̂�)�쐬
            DataTable dataTable = null;
            PMUOE04202EA.CreateDataTableDetail(ref dataTable);

            this._uoeReplyDataSet = new DataSet();
            this._uoeReplyDataSet.Tables.Add(dataTable);

            // ������f�[�^HashTable�쐬
            this.CreateUOEOrderDtlHTable();

            // ���Ӑ�f�[�^HashTalbe�쐬
            this.CreateCustomerHTable();
        }
        # endregion

        #region ��Public
        #region ���v���p�e�B
        /// <summary> UOE�񓚃f�[�^ </summary>
        public DataSet UOEReplyDataSet
        {
            get { return this._uoeReplyDataSet; }
        }
        /// <summary> UOE�񓚃f�[�^(����p ���׃`�F�b�N����Œ��o) </summary>
        public DataView UOEReplyDataView
        {
            get { return this._uoeReplyDataView; }
        }
        #endregion

        #region ��GetUOESupplierName(�����於�̎擾)
        /// <summary>
        /// �����於�̎擾
        /// </summary>
        /// <param name="uoeSupplierCd">������R�[�h</param>
        /// <param name="uoeSupplierName">�����於��</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h�����ɔ����於�̂��擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool GetUOESupplierName(int uoeSupplierCd, out string uoeSupplierName)
        {
            return this.GetUOESupplierNameFromUOEOrderDtlHTable(uoeSupplierCd, out uoeSupplierName);
        }
        #endregion

        #region ��GetCustomerName(���Ӑ於�̎擾)
        /// <summary>
        /// ���Ӑ於�̎擾
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�R�[�h�����ɓ��Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool GetCustomerName(int customerCode, out string customerName)
        {
            return this.GetCustomerNameFromCustomerHTable(customerCode, out customerName);
        }
        #endregion

        #region ��ClearUOEOrderDtlDataTable(UOE�񓚃f�[�^�N���A)
        /// <summary>
        /// UOE�񓚃f�[�^�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE�񓚃f�[�^�Z�b�g�̓��e���N���A���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public void ClearUOEOrderDtlDataTable()
        {
            this._uoeReplyDataSet.Tables[PMUOE04202EA.ct_Tbl_UOEReply].Rows.Clear();
        }
        #endregion

        #region ��SetSearchData(UOE�񓚃f�[�^�擾)
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="ioWriteMASIRReadWork">UOE�񓚌��������p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ɉ����Č������s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public int SetSearchData(UOEAnswerLedgerOrderCndtn uoeAnswerLedgerOrderCndtn)
        {
            // ���o����
            UOEAnswerLedgerOrderCndtnWork uoeAnswerLedgerOrderCndtnWork = new UOEAnswerLedgerOrderCndtnWork();
            uoeAnswerLedgerOrderCndtnWork.EnterpriseCode = uoeAnswerLedgerOrderCndtn.EnterpriseCode;        // ��ƃR�[�h
            uoeAnswerLedgerOrderCndtnWork.SectionCode = uoeAnswerLedgerOrderCndtn.SectionCode;              // ���_�R�[�h
            uoeAnswerLedgerOrderCndtnWork.SystemDivCd = uoeAnswerLedgerOrderCndtn.SystemDivCd;              // �V�X�e���敪
            uoeAnswerLedgerOrderCndtnWork.UOESupplierCd = uoeAnswerLedgerOrderCndtn.UOESupplierCd;          // ������R�[�h
            uoeAnswerLedgerOrderCndtnWork.CustomerCode = uoeAnswerLedgerOrderCndtn.CustomerCode;            // ���Ӑ�R�[�h
            uoeAnswerLedgerOrderCndtnWork.St_ReceiveDate = uoeAnswerLedgerOrderCndtn.St_ReceiveDate;        // �J�n������
            uoeAnswerLedgerOrderCndtnWork.Ed_ReceiveDate = uoeAnswerLedgerOrderCndtn.Ed_ReceiveDate;        // �I��������
            uoeAnswerLedgerOrderCndtnWork.UOEKind = uoeAnswerLedgerOrderCndtn.UOEKind;                      // UOE���(0�FUOE�Œ�)      //ADD 2008/12/19
            uoeAnswerLedgerOrderCndtnWork.St_InputDay = uoeAnswerLedgerOrderCndtn.St_InputDay;              // ���͓�(�J�n)             //ADD 2008/12/19
            uoeAnswerLedgerOrderCndtnWork.Ed_InputDay = uoeAnswerLedgerOrderCndtn.Ed_InputDay;              // ���͓�(�I��)             //ADD 2008/12/19

            // �f�[�^���o            
            Object arrayList = null;
            int status = this._iUOEAnswerLedgerOrderWorkDB.Search(out arrayList, (object)uoeAnswerLedgerOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        this.StatusBarMessageSetting(this, "�Y���f�[�^������܂���");
                        return -1;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                default:
                    this.StatusBarMessageSetting(this, "�����f�[�^�̓Ǎ��Ɏ��s���܂����B");
                    return -1;
            }

            // �O���b�h�\���p�f�[�^�쐬
            DataTable dataTable = this._uoeReplyDataSet.Tables[PMUOE04202EA.ct_Tbl_UOEReply];
            foreach (UOEAnswerLedgerResultWork uoeAnswerLedgerResultWork in (ArrayList)arrayList)
            {
                DataRow dr = dataTable.NewRow();

                dr[PMUOE04202EA.ct_Col_No] = dataTable.Rows.Count + 1;          // �sNo.
                dr[PMUOE04202EA.ct_Col_SelectFlg] = false;                      // �I���t���O

                // UOE�񓚃f�[�^���O���b�h�pDataRow�R�s�[
                this.CopyToUOEReplyFromUOEAnswerLedgerResultWork(uoeAnswerLedgerResultWork, ref dr);

                dataTable.Rows.Add(dr);
            }

            if (this.StatusBarMessageSetting != null)
            {
                this.StatusBarMessageSetting(this, "�f�[�^�𒊏o���܂����B");
            }

            return 0;
        }
        #endregion

        #region ��SetRowSelectedAll(�I�����ڂ̑I��/�����|�S�s)
        /// <summary>
        /// �S�Ă̍s�̑I���`�F�b�N���Z�b�g
        /// </summary>
        /// <param name="rowSelected">True�F�I���AFalse�F����</param>
        /// <remarks>
        /// <br>Note       : �S���ׂ̑I�����ڂɑ΂��đI��/�������s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public void SetRowSelectedAll(bool rowSelected)
        {
            // �S�Ă̍s�̑I���`�F�b�N��ݒ�
            foreach (DataRow dataRow in this._uoeReplyDataSet.Tables[PMUOE04202EA.ct_Tbl_UOEReply].Rows)
            {
                dataRow[PMUOE04202EA.ct_Col_SelectFlg] = rowSelected;
            }
        }
        #endregion

        #region ��SetRowSelected(�I�����ڂ̑I��/�����|1�s�̂�)
        /// <summary>
        /// �s�I���`�F�b�N����
        /// </summary>
        /// <param name="rowNo">�Ώۍs</param>
        /// <param name="rowSelected">True�F�I���AFalse�F����</param>
        /// <remarks>
        /// <br>Note       : �w�薾�ׂ̑I�����ڂɑ΂��đI��/�������s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public void SetRowSelected(int rowNo, bool rowSelected)
        {
            // �s���Ō���
            DataRow dataRow = this._uoeReplyDataSet.Tables[PMUOE04202EA.ct_Tbl_UOEReply].Rows.Find(rowNo);
            if (dataRow == null)
            {
                return;
            }

            // �`�F�b�N�l�Z�b�g
            dataRow[PMUOE04202EA.ct_Col_SelectFlg] = rowSelected;

        }
        #endregion

        #region ��GetSelectedRowCount(�I���s����Ԃ�)
        /// <summary>
        /// �I���s�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �w�薾�ׂ̑I�����ڂɑ΂��đI��/�������s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public int GetSelectedRowCount()
        {
            // �f�[�^�r���[�𐶐����āA�I���ς݃t���O�Ńt�B���^��������
            string rowFilter = string.Format("{0} = '{1}'", PMUOE04202EA.ct_Col_SelectFlg, true);       // ���o����
            //string sort = PMUOE04202EA.ct_Col_No;                                                       // �\�[�g����     //DEL 2009/01/07 �s��Ή�[9519]
            // --- ADD 2009/01/07 �s��Ή�[9519] ----------------------------------------------------------------------------------->>>>>
            // �\�[�g����
            string sort = string.Format("{0},{1},{2},{3},{4}"
                                        , PMUOE04202EA.ct_Col_UOESupplierCd         //������
                                        , PMUOE04202EA.ct_Col_ReceiveDate           //��M��
                                        , PMUOE04202EA.ct_Col_ReceiveTime           //��M����
                                        , PMUOE04202EA.ct_Col_UOESalesOrderNo       //�����񓚔ԍ�
                                        , PMUOE04202EA.ct_Col_UOESalesOrderRowNo);  //�����񓚍s�ԍ�
            // --- ADD 2009/01/07 �s��Ή�[9519] -----------------------------------------------------------------------------------<<<<<

            this._uoeReplyDataView = new DataView(this._uoeReplyDataSet.Tables[PMUOE04202EA.ct_Tbl_UOEReply],rowFilter,sort,DataViewRowState.CurrentRows);

            // ������Ԃ�
            return this._uoeReplyDataView.Count;
        }
        #endregion
        #endregion ��Public - end

        #region ��Private
        #region ��������}�X�^�֘A
        #region ��CreateUOEOrderDtlHTable(HashTable�쐬)
        /// <summary>
        /// UOE������}�X�^HashTable�쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^������HashTable���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
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

                // UOE��������擾
                UOEOrderDtlInfo uoeOrderDtlInfo;
                uoeOrderDtlInfo.CommAssemblyId = dataRow["CommAssemblyId"].ToString();
                uoeOrderDtlInfo.UOESupplierName = dataRow["UoeSupplierName"].ToString();

                this._uoeOrderDtlHTable[key] = uoeOrderDtlInfo;
            }
        }
        #endregion

        #region ��GetProgramIdFromUOEOrderDtlHTable(�ʐM�A�Z���u��ID(�ʐM�v���O����ID)�擾)
        /// <summary>
        /// �ʐM�A�Z���u��ID(�ʐM�v���O����ID)�擾
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <returns>�ʐM�A�Z���u��ID(�ʐM�v���O����ID)</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h������UOE������}�X�^HashTable����ʐM�A�Z���u��ID(�ʐM�v���O����ID)���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private int GetProgramIdFromUOEOrderDtlHTable(int uoeSupplierCd)
        {
            int programId = 0;        // �Ȃ�

            if (this.HashTableIsNullOrEmpty(this._uoeOrderDtlHTable, uoeSupplierCd) == false)
            {
                // HashTable���擾
                UOEOrderDtlInfo uoeOrderDtlInfo = (UOEOrderDtlInfo)this._uoeOrderDtlHTable[uoeSupplierCd];

                bool ret = int.TryParse(uoeOrderDtlInfo.CommAssemblyId, out programId);
            }
            return programId;
        }
        #endregion

        #region ��GetUOESupplierNameFromUOEOrderDtlHTable(UOE�����於�̎擾)
        /// <summary>
        /// UOE�����於�̎擾
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <param name="uoeSupplierName">UOE�����於��</param>
        /// <returns>True�F�f�[�^����AFalse�F�f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h������UOE������}�X�^HashTable����UOE�����於�̂��擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool GetUOESupplierNameFromUOEOrderDtlHTable(int uoeSupplierCd, out string uoeSupplierName)
        {
            uoeSupplierName = string.Empty;
            if (this.HashTableIsNullOrEmpty(this._uoeOrderDtlHTable, uoeSupplierCd))
            {
                return false;
            }

            // HashTable���擾
            UOEOrderDtlInfo uoeOrderDtlInfo = (UOEOrderDtlInfo)this._uoeOrderDtlHTable[uoeSupplierCd];
            uoeSupplierName = uoeOrderDtlInfo.UOESupplierName;

            return true;
        }
        #endregion
        #endregion ��������}�X�^�֘A - end

        #region �����Ӑ�}�X�^�֘A
        #region ��CreateCustomerHTable(HashTable�쐬)
        /// <summary>
        /// ���Ӑ�}�X�^HashTable�쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^������HashTable���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CreateCustomerHTable()
        {
            CustomerSearchRet[] customerSearchRetArray = null;

            // �����ݒ�
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            // ���Ӑ�}�X�^�f�[�^�擾(PMKHN09012A)
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            int status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);

            // �ُ�
            if (status != 0)
            {
                this._customerHTable = null;
                return;
            }
            // �f�[�^�Ȃ�
            if (customerSearchRetArray == null)
            {
                this._customerHTable = null;
                return;
            }

            // HashTable�쐬
            this._customerHTable = new Hashtable();
            foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
            {
                this._customerHTable[customerSearchRet.CustomerCode] = customerSearchRet.Name + customerSearchRet.Name2;
            }
        }
        #endregion

        #region ��GetCustomerNameFromCustomerHTable(���Ӑ於�̎擾)
        /// <summary>
        /// ���Ӑ於�̎擾
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <returns>True�F�f�[�^����AFalse�F�f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�R�[�h�����ɓ��Ӑ�}�X�^HashTable���瓾�Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool GetCustomerNameFromCustomerHTable(int customerCode, out string customerName)
        {
            customerName = string.Empty;
            if (this.HashTableIsNullOrEmpty(this._customerHTable, customerCode))
            {
                return false;
            }

            // HashTable���擾
            customerName = this._customerHTable[customerCode].ToString();

            return true;
        }
        #endregion
        #endregion �����Ӑ�}�X�^�֘A - end

        #region ��HashTableIsNullOrDataNothing(HashTable�f�[�^���݃`�F�b�N)
        /// <summary>
        /// HashTable�f�[�^���݃`�F�b�N
        /// </summary>
        /// <param name="uoeSupplierCd"></param>
        /// <returns>True:�f�[�^�Ȃ��AFalse:�f�[�^����</returns>
        /// <remarks>
        /// <br>Note       : Key�Ŏw�肳�ꂽ�f�[�^��HashTable�ɑ��݂��邩�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool HashTableIsNullOrEmpty(Hashtable hashTable, int key)
        {
            // �f�[�^������
            if (hashTable == null)
            {
                return true;
            }

            // INDEX�͈͊O
            if (hashTable.ContainsKey(key) == false)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region ��CopyToUOEReplyFromUOEAnswerLedgerResultWork(UOE�񓚃f�[�^���O���b�h�pDataRow�R�s�[)
        /// <summary>
        /// UOE�񓚃f�[�^���O���b�h�pDataRow�R�s�[
        /// </summary>
        /// <param name="uoeAnswerLedgerResultWork">UOE�񓚃f�[�^</param>
        /// <param name="dr">�O���b�h�pDataRow</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�pDataRow��UOE�񓚃f�[�^���R�s�[���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CopyToUOEReplyFromUOEAnswerLedgerResultWork(UOEAnswerLedgerResultWork uoeAnswerLedgerResultWork, ref DataRow dr)
        {
            dr[PMUOE04202EA.ct_Col_ReceiveDate] = uoeAnswerLedgerResultWork.ReceiveDate.ToString("yyyy/MM/dd");                             // ��M���t
            dr[PMUOE04202EA.ct_Col_ReceiveTime] = uoeAnswerLedgerResultWork.ReceiveTime.ToString("000000").Insert(2, ":").Insert(5, ":");   // ��M����
            dr[PMUOE04202EA.ct_Col_UOESalesOrderNo] = uoeAnswerLedgerResultWork.UOESalesOrderNo.ToString("000000");                         // UOE�����ԍ�
            dr[PMUOE04202EA.ct_Col_UOESalesOrderRowNo] = uoeAnswerLedgerResultWork.UOESalesOrderRowNo;                                      // UOE�����s�ԍ�
            dr[PMUOE04202EA.ct_Col_UOESupplierCd] = uoeAnswerLedgerResultWork.UOESupplierCd.ToString("000000");                             // UOE������R�[�h
            dr[PMUOE04202EA.ct_Col_UOESupplierName] = uoeAnswerLedgerResultWork.UOESupplierName;                                            // �����於��
            dr[PMUOE04202EA.ct_Col_UOEDeliGoodsDiv] = uoeAnswerLedgerResultWork.UOEDeliGoodsDiv;                                            // UOE�[�i�敪
            dr[PMUOE04202EA.ct_Col_FollowDeliGoodsDiv] = uoeAnswerLedgerResultWork.FollowDeliGoodsDiv;                                      // �t�H���[�[�i�敪
            dr[PMUOE04202EA.ct_Col_BOCode] = uoeAnswerLedgerResultWork.BoCode;                                                              // BO�敪

            // �˗��҃R�[�h
            try
            {
                dr[PMUOE04202EA.ct_Col_EmployeeCode] = (int.Parse(uoeAnswerLedgerResultWork.EmployeeCode)).ToString("0000");
            }
            catch
            {
                dr[PMUOE04202EA.ct_Col_EmployeeCode] = uoeAnswerLedgerResultWork.EmployeeCode;
            }

            dr[PMUOE04202EA.ct_Col_EmployeeName] = uoeAnswerLedgerResultWork.EmployeeName;                                                  // �˗��Җ���
            //dr[PMUOE04202EA.ct_Col_CustomerCode] = uoeAnswerLedgerResultWork.CustomerCode.ToString("00000000");                             // ���Ӑ�R�[�h   //DEL 2009/01/06 �s��Ή�[9516]
            // --- ADD 2009/01/06 �s��Ή�[9516] ------------------------------------------------------------------->>>>>
            if (uoeAnswerLedgerResultWork.CustomerCode == 0)
            {
                //ALL0�͔�\��
                dr[PMUOE04202EA.ct_Col_CustomerCode] = uoeAnswerLedgerResultWork.CustomerCode.ToString("########");
            }
            else
            {
                dr[PMUOE04202EA.ct_Col_CustomerCode] = uoeAnswerLedgerResultWork.CustomerCode.ToString("00000000");
            }
            // --- ADD 2009/01/06 �s��Ή�[9516] -------------------------------------------------------------------<<<<<
            dr[PMUOE04202EA.ct_Col_CustomerSnm] = uoeAnswerLedgerResultWork.CustomerSnm;                                                    // ���Ӑ於��
            dr[PMUOE04202EA.ct_Col_GoodsNo] = uoeAnswerLedgerResultWork.GoodsNo;                                                            // �i��
            dr[PMUOE04202EA.ct_Col_GoodsMakerCd] = uoeAnswerLedgerResultWork.GoodsMakerCd.ToString("0000");                                 // ���[�J�[
            dr[PMUOE04202EA.ct_Col_GoodsName] = uoeAnswerLedgerResultWork.GoodsName;                                                        // �i��
            dr[PMUOE04202EA.ct_Col_UOERemark1] = uoeAnswerLedgerResultWork.UoeRemark1;                                                      // ���}�[�N1
            dr[PMUOE04202EA.ct_Col_UOERemark2] = uoeAnswerLedgerResultWork.UoeRemark2;                                                      // ���}�[�N2
            dr[PMUOE04202EA.ct_Col_AcceptAnOrderCnt] = uoeAnswerLedgerResultWork.AcceptAnOrderCnt;                                          // ��������
            dr[PMUOE04202EA.ct_Col_UOESectOutGoodsCnt] = uoeAnswerLedgerResultWork.UOESectOutGoodsCnt;                                      // ���_�o�ɐ�
            dr[PMUOE04202EA.ct_Col_UOESectionSlipNo] = uoeAnswerLedgerResultWork.UOESectionSlipNo;                                          // ���_�`�[�ԍ�
            dr[PMUOE04202EA.ct_Col_BOShipmentCnt1] = uoeAnswerLedgerResultWork.BOShipmentCnt1;                                              // �t�H���[1(BO1)
            dr[PMUOE04202EA.ct_Col_BOSlipNo1] = uoeAnswerLedgerResultWork.BOSlipNo1;                                                        // �t�H���[�`�[�ԍ�1
            dr[PMUOE04202EA.ct_Col_BOShipmentCnt2] = uoeAnswerLedgerResultWork.BOShipmentCnt2;                                              // �t�H���[2(BO2)
            dr[PMUOE04202EA.ct_Col_BOSlipNo2] = uoeAnswerLedgerResultWork.BOSlipNo2;                                                        // �t�H���[�`�[�ԍ�2
            dr[PMUOE04202EA.ct_Col_BOShipmentCnt3] = uoeAnswerLedgerResultWork.BOShipmentCnt3;                                              // �t�H���[3(BO3)
            dr[PMUOE04202EA.ct_Col_BOSlipNo3] = uoeAnswerLedgerResultWork.BOSlipNo3;                                                        // �t�H���[�`�[�ԍ�3
            dr[PMUOE04202EA.ct_Col_MakerFollowCnt] = uoeAnswerLedgerResultWork.MakerFollowCnt;                                              // ���[�J�[�t�H���[��
            //dr[PMUOE04202EA.ct_Col_ListPrice] = uoeAnswerLedgerResultWork.ListPrice;                                                        // �艿d                  //DEL 2009/01/13 �s��Ή�[9834]
            //dr[PMUOE04202EA.ct_Col_SalesUnitCost] = uoeAnswerLedgerResultWork.SalesUnitCost;                                                // �d�ؒP��d              //DEL 2009/01/13 �s��Ή�[9834]
            dr[PMUOE04202EA.ct_Col_ListPrice] = uoeAnswerLedgerResultWork.AnswerListPrice;                                                  // �艿(�񓚒艿)           //ADD 2009/01/13 �s��Ή�[9834]
            dr[PMUOE04202EA.ct_Col_SalesUnitCost] = uoeAnswerLedgerResultWork.AnswerSalesUnitCost;                                          // �d�ؒP��(�񓚌����P��)   //ADD 2009/01/13 �s��Ή�[9834]
            dr[PMUOE04202EA.ct_Col_UOESubstMark] = uoeAnswerLedgerResultWork.UOESubstMark;                                                  // ��֋敪
            dr[PMUOE04202EA.ct_Col_PartsLayerCd] = uoeAnswerLedgerResultWork.PartsLayerCd;                                                  // �w��(���Y)
            dr[PMUOE04202EA.ct_Col_BOManagementNo] = uoeAnswerLedgerResultWork.BOManagementNo;                                              // EO�Ǘ��ԍ�(���Y)
            dr[PMUOE04202EA.ct_Col_EOAlwcCount] = uoeAnswerLedgerResultWork.EOAlwcCount;                                                    // EO������(���Y)i
            dr[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd1] = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd1;                                    // ���_�R�[�h(����)
            dr[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd2] = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd2;                                    // �t�H���[�R�[�h1(����)
            dr[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd3] = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd3;                                    // �t�H���[�R�[�h2(����)
            //dr[PMUOE04202EA.ct_Col_LineErrorMessage] = uoeAnswerLedgerResultWork.LineErrorMassage;                                          // �G���[���b�Z�[�W
            dr[PMUOE04202EA.ct_Col_SourceShipment] = uoeAnswerLedgerResultWork.SourceShipment;                                              // �o�׌��R�[�h(����)  
            dr[PMUOE04202EA.ct_Col_SectionCode] = uoeAnswerLedgerResultWork.SectionCode;                                                    // ���_�R�[�h�@���g�p�͒��[�̂�
            dr[PMUOE04202EA.ct_Col_SectionName] = uoeAnswerLedgerResultWork.SectionGuideSnm;                                                // ���_���́@�@���g�p�͒��[�̂�
            dr[PMUOE04202EA.ct_Col_ForeColor] = string.Empty;                                                                               // �\�������F

            // ---ADD 2009/01/21 �s��Ή�[9876] ----------------------------------------------->>>>>
            // �R�����g
            if (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.HeadErrorMassage.Trim()) == false)
            {
                dr[PMUOE04202EA.ct_Col_LineErrorMessage] = uoeAnswerLedgerResultWork.HeadErrorMassage;
            }
            else if (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.LineErrorMassage.Trim()) == false)
            {
                dr[PMUOE04202EA.ct_Col_LineErrorMessage] = uoeAnswerLedgerResultWork.LineErrorMassage;
            }
            else if (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.SubstPartsNo.Trim()) == false)
            {
                dr[PMUOE04202EA.ct_Col_LineErrorMessage] = uoeAnswerLedgerResultWork.SubstPartsNo;
            }
            else
            {
                dr[PMUOE04202EA.ct_Col_LineErrorMessage] = string.Empty;
            }
            // ---ADD 2009/01/21 �s��Ή�[9876] -----------------------------------------------<<<<<

            /* ---DEL 2009/01/20 �s��Ή�[10165] -------------------------------------------------------------->>>>>
            // --- ADD 2009/01/13 �s��Ή�[9872] --------------------------------------------------------->>>>>
            if (uoeAnswerLedgerResultWork.MakerFollowCnt != 0)
            {
                // ���[�J�[�t�H���[�����O�ȊO
                dr[PMUOE04202EA.ct_Col_ForeColor] = "YELLOW";
                return;
            }
            if (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.SubstPartsNo.Trim()) == false)
            {
                // ��փR�[�h���X�y�[�X�ȊO
                dr[PMUOE04202EA.ct_Col_ForeColor] = "GREEN";
                return;
            }
            if ((uoeAnswerLedgerResultWork.UOESectOutGoodsCnt == 0) &&       // ���_�o�ɐ�
                (uoeAnswerLedgerResultWork.BOShipmentCnt1 == 0) &&           // BO1��
                (uoeAnswerLedgerResultWork.BOShipmentCnt2 == 0) &&           // BO2��
                (uoeAnswerLedgerResultWork.BOShipmentCnt3 == 0) &&           // BO3��
                (uoeAnswerLedgerResultWork.MakerFollowCnt == 0) &&           // ���[�J�[�t�H���[��
                (uoeAnswerLedgerResultWork.EOAlwcCount == 0))                // EO������
            {
                // ���_�o�ɐ��ABO1�`3���A���[�J�[�t�H���[���AEO�������̑S�Ă��A�O�̏ꍇ
                dr[PMUOE04202EA.ct_Col_ForeColor] = "RED";
                return;
            }
            // ���L�����̂����P�ł��Y������ꍇ		
            // �@�񓚃f�[�^��(�������� - (���_�o�ɐ� + BO1�`3�� + ���[�J�[�t�H���[�� + EO��))���O�ȊO�̏ꍇ	
            // �ABO1���O�ȊO�̏ꍇ	
            // �BBO2���O�ȊO�̏ꍇ	
            // �CBO3�����O�ȊO�̏ꍇ	
            // �D�d�ؒP�����O�̏ꍇ
            double total = uoeAnswerLedgerResultWork.AcceptAnOrderCnt       // ��������
                        - (uoeAnswerLedgerResultWork.UOESectOutGoodsCnt     // ���_�o�ɐ�
                           + uoeAnswerLedgerResultWork.BOShipmentCnt1       // BO1��
                           + uoeAnswerLedgerResultWork.BOShipmentCnt2       // BO2��
                           + uoeAnswerLedgerResultWork.BOShipmentCnt3       // BO3��
                           + uoeAnswerLedgerResultWork.MakerFollowCnt       // ���[�J�[�t�H���[��
                           + uoeAnswerLedgerResultWork.EOAlwcCount);        // EO������
            if ((total != 0) ||
                (uoeAnswerLedgerResultWork.BOShipmentCnt1 != 0) ||
                (uoeAnswerLedgerResultWork.BOShipmentCnt2 != 0) ||
                (uoeAnswerLedgerResultWork.BOShipmentCnt3 != 0) ||
                (uoeAnswerLedgerResultWork.AnswerSalesUnitCost == 0))
            {
                dr[PMUOE04202EA.ct_Col_ForeColor] = "BLUE";
                return;
            }
            // --- ADD 2009/01/13 �s��Ή�[9872] ---------------------------------------------------------<<<<<
               ---DEL 2009/01/20 �s��Ή�[10165] --------------------------------------------------------------<<<<< */
            // ---ADD 2009/01/20 �s��Ή�[10165] -------------------------------------------------------------->>>>>
            // ��֕i
            //if (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.SubstPartsNo.Trim()) == false)         //DEL 2009/01/21 �s��Ή�[9876]
            // ---ADD 2009/01/21 �s��Ή�[9876] ---------------------------------------------------------->>>>>
            if ((string.IsNullOrEmpty(uoeAnswerLedgerResultWork.HeadErrorMassage.Trim())) &&
                (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.LineErrorMassage.Trim())) &&
                (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.SubstPartsNo.Trim()) == false))
            // ---ADD 2009/01/21 �s��Ή�[9876] ----------------------------------------------------------<<<<<
            {
                // ��փR�[�h���X�y�[�X�ȊO
                dr[PMUOE04202EA.ct_Col_ForeColor] = "GREEN";
                return;
            }
            // �S���c
            if ((uoeAnswerLedgerResultWork.UOESectOutGoodsCnt == 0) &&       // ���_�o�ɐ�
                (uoeAnswerLedgerResultWork.BOShipmentCnt1 == 0) &&           // BO1��
                (uoeAnswerLedgerResultWork.BOShipmentCnt2 == 0) &&           // BO2��
                (uoeAnswerLedgerResultWork.BOShipmentCnt3 == 0) &&           // BO3��
                (uoeAnswerLedgerResultWork.MakerFollowCnt == 0) &&           // ���[�J�[�t�H���[��
                (uoeAnswerLedgerResultWork.EOAlwcCount == 0))                // EO������
            {
                // ���_�o�ɐ��ABO1�`3���A���[�J�[�t�H���[���AEO�������̑S�Ă��A�O�̏ꍇ
                dr[PMUOE04202EA.ct_Col_ForeColor] = "RED";
                return;
            }
            // �d�ؖ���/�ꕔ�c/Ұ��̫۰��
            // �@�񓚃f�[�^��(�������� - (���_�o�ɐ� + BO1�`3�� + ���[�J�[�t�H���[�� + EO��))���O�ȊO�̏ꍇ	
            // �AҰ��̫۰�����O�ȊO�̏ꍇ
            // �B�d�ؒP�����O�̏ꍇ
            double total = uoeAnswerLedgerResultWork.AcceptAnOrderCnt       // ��������
                        - (uoeAnswerLedgerResultWork.UOESectOutGoodsCnt     // ���_�o�ɐ�
                           + uoeAnswerLedgerResultWork.BOShipmentCnt1       // BO1��
                           + uoeAnswerLedgerResultWork.BOShipmentCnt2       // BO2��
                           + uoeAnswerLedgerResultWork.BOShipmentCnt3       // BO3��
                           + uoeAnswerLedgerResultWork.MakerFollowCnt       // ���[�J�[�t�H���[��
                           + uoeAnswerLedgerResultWork.EOAlwcCount);        // EO������
            if ((total != 0) || (uoeAnswerLedgerResultWork.MakerFollowCnt != 0) || (uoeAnswerLedgerResultWork.AnswerSalesUnitCost == 0))
            {
                dr[PMUOE04202EA.ct_Col_ForeColor] = "BLUE";
                return;
            }
            // ---ADD 2009/01/20 �s��Ή�[10165] --------------------------------------------------------------<<<<<
        }
        #endregion
        #endregion
    }
}
