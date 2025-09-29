//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��������
// �v���O�����T�v   : �����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/06/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �C �� ��  2011/10/26  �C�����e : HTML�쐬���̃G���R�[�h���z���_���V�X�e���ƃ}�b�`���Ă��Ȃ��ׁA�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/11/17  �C�����e :  Readmine 7768�z���_e-Parts��������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/12/02  �C�����e : Readmine 8304�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2012/02/06  �C�����e : 2012/03/28�z�M�� Redmine#28287�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : ���N�n
// �� �� ��  2012/02/22  �C�����e : 2012/03/28�z�M���ARedmine#28287 
//                                  �V�X�e���敪���݌Ɉꊇ���A���ʂɂO��ݒ肳�ꂽ���ׂ��폜�����ɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : wangyl
// �C �� ��  2013/02/06  �C�����e : 10900690-00 2013/03/13�z�M���ً̋}�Ή�
//                                  Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870080-00 �쐬�S�� : ���O
// �C �� ��  2022/06/20  �C�����e : PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using Broadleaf.Application.Resources;// ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή�

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���������A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009/06/10</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
    /// <br>              Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
    /// <br>Update Note : 2022/06/20 ���O</br>
    /// <br>�Ǘ��ԍ�    : 11870080-00</br>
    /// <br>              PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή�</br>
    /// </remarks>
    public class SupplierAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private bool _isDataCanged = false;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        //�A�N�Z�X�N���X
        private static SupplierAcs _supplierAcs;
        private UoeOrderInfoAcs _uoeOrderInfoAcs;

        //�f�[�^�[�e�[�u��
        private StockInputDataSet _dataSet;
        private StockInputDataSet.OrderExpansionDataTable _orderDataTable;

        //�]�ƈ��}�X�^
        private Dictionary<string, EmployeeWork> _employeeWork;
        private IEmployeeDB _iEmployeeDB;                               // �]�ƈ���� �A�N�Z�X�N���X

        //�󒍃}�X�^
        private IAcceptOdrCarDB _iAcceptOdrCarDB;

        //�t�n�d�����f�[�^�������A�N�Z�X�N���X�Ăяo����
        List<UOEOrderDtlWork> _uOEOrderDtlWorkList = null;
        List<StockDetailWork> _stockDetailWorkList = null;

        //�󒍃}�X�^�i�ԗ��j
        List<AcceptOdrCarWork> _acceptOdrCarWorkList = null;

        static BackgroundWorker bw;

        static private int _time;

        // ---ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή�--->>>>>
        // �u���E�U�t���O�u0:ie  1:edg�v
        private static int browserUseFlg;
        // �u���E�U����XML�t�@�C��
        private const string CUSTOMSIZESETTINGSFILE = "PMUOE01504A_BrowserSetting.xml";
        // IE�u���E�U
        private const string IELOCATIONSTR = @"%ProgramFiles%\Internet Explorer\iexplore.exe";
        // edge�u���E�U
        private const string MSEDGELOCATIONSTR = @"%ProgramFiles%\Microsoft\Edge\Application\msedge.exe";
        // ---ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή�---<<<<<
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�t�H���g�R���X�g���N�^���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private SupplierAcs()
        {
            // �ϐ�������
            this._dataSet = new StockInputDataSet();
            this._orderDataTable = this._dataSet.OrderExpansion;

            this.orderDataTable.Rows.Clear();

            this._uoeOrderInfoAcs = UoeOrderInfoAcs.GetInstance();

            this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();
            this._iAcceptOdrCarDB = (IAcceptOdrCarDB)MediationAcceptOdrCarDB.GetAcceptOdrCarDB();

            this.GetBrowserSettingInfo(); // ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή�
        }

        /// <summary>
        /// �t�n�d���������A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�t�n�d���������A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �t�n�d���������A�N�Z�X�N���X �C���X�^���X�擾���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public static SupplierAcs GetInstance()
        {
            if (_supplierAcs == null)
            {
                _supplierAcs = new SupplierAcs();
            }

            return _supplierAcs;
        }

        # endregion

        #region �f�[�^�ύX�t���O
        /// <summary>�f�[�^�ύX�t���O�v���p�e�B�itrue:�ύX���� false:�ύX�Ȃ��j</summary>
        public bool IsDataChanged
        {
            get
            {
                return this._isDataCanged;
            }
            set
            {
                this._isDataCanged = value;
            }
        }
        #endregion

        # region �]�ƈ��}�X�^�L���b�V������
        /// <summary>
        /// �]�ƈ��}�X�^�L���b�V������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �]�ƈ��}�X�^�L���b�V���������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public void CacheEmployee()
        {
            object returnEmployee;
            _employeeWork = new Dictionary<string, EmployeeWork>();
            EmployeeWork paraEmployee = new EmployeeWork();
            paraEmployee.EnterpriseCode = this._enterpriseCode; ;

            try
            {

                int status = this._iEmployeeDB.Search(out returnEmployee, paraEmployee, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (returnEmployee is ArrayList)
                    {
                        foreach (EmployeeWork employeeWork in (ArrayList)returnEmployee)
                        {
                            if (employeeWork.LogicalDeleteCode == 0 &&
                                _employeeWork.ContainsKey(employeeWork.EmployeeCode.Trim()) != true)
                            {
                                this._employeeWork.Add(employeeWork.EmployeeCode.Trim(), employeeWork);
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                _employeeWork = new Dictionary<string, EmployeeWork>();
            }

        }

        /// <summary>
        /// �]�ƈ����݃`�F�b�N
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����݃`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public bool GetEmployeeName(string employeeCode, out string employeeName)
        {
            employeeName = string.Empty;

            if (!this._employeeWork.ContainsKey(employeeCode))
            {
                return false;
            }

            employeeName = this._employeeWork[employeeCode].Name.Trim();

            return true;
        }

        # endregion

        # region ���������f�[�^�Z�b�g�擾����
        /// <summary>
        /// ���������f�[�^�Z�b�g�擾����
        /// </summary>
        /// <returns>�`�[�����f�[�^�Z�b�g</returns>
        /// <remarks>
        /// <br>Note       : ���������f�[�^�Z�b�g�擾���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public StockInputDataSet DataSet
        {
            get { return this._dataSet; }
        }

        /// <summary>
        /// �L�����͍s���ݔ���
        /// </summary>
        /// <returns>�s���݃`�F�b�N���ʁiTrue : �s���� / False : �s�Ȃ��j</returns>
        /// <remarks>
        /// <br>Note       : �L�����͍s���ݔ�����s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public bool StockRowExists()
        {
            if (this._orderDataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        # endregion

        # region ���������f�[�^�e�[�u���擾����
        /// <summary>
        /// ���������f�[�^�e�[�u���擾����
        /// </summary>
        /// <returns>�`�[�����f�[�^�Z�b�g</returns>
        /// <remarks>
        /// <br>Note       : ���������f�[�^�e�[�u���擾���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public StockInputDataSet.OrderExpansionDataTable orderDataTable
        {
            get { return _orderDataTable; }
        }
        # endregion

        #region �I���E��I����ԏ���(�w��^)
        /// <summary>
        /// �I���E��I����ԏ���(�w��^)
        /// </summary>
        /// <param name="_uniqueID">���j�[�NID</param>
        /// <param name="selected">true:�I��,false:��I��</param>
        /// <remarks>
        /// <br>Note       : �I���E��I����ԏ������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public void SelectedRow(int _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find ���\�b�h���g���A���AView�̃\�[�g����ύX�������Ȃ��ׁA //
            // DataTable�ɍX�V��������B                                   //
            // ------------------------------------------------------------//
            DataRow _row = this.orderDataTable.Rows.Find(_uniqueID);

            // ��v����s�����݂���I
            if (_row != null)
            {
                _row.BeginEdit();
                _row[this.orderDataTable.InpSelectColumn.ColumnName] = selected;
                _row.EndEdit();
            }
        }
        # endregion

        # region �� ��ʃf�[�^�N���X���������p���������o�N���X ��
        /// <summary>
        /// ��ʃf�[�^�N���X���������p���������o�N���X
        /// </summary>
        /// <param name="inpDisplay">��ʃf�[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �������o���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private UOESendProcCndtnPara ToUOESendProcCndtnParaFromInpDisplay(InpDisplay inpDisplay)
        {
            UOESendProcCndtnPara para = new UOESendProcCndtnPara();

            para.EnterpriseCode = inpDisplay.EnterpriseCode;
            para.CashRegisterNo = inpDisplay.CashRegisterNo;
            para.SystemDivCd = inpDisplay.SystemDivCd;
            para.St_OnlineNo = inpDisplay.UOESalesOrderNoSt;
            para.Ed_OnlineNo = inpDisplay.UOESalesOrderNoEd;
            para.St_InputDay = inpDisplay.SalesDateSt;
            para.Ed_InputDay = inpDisplay.SalesDateEd;
            para.CustomerCode = inpDisplay.CustomerCode;
            para.UOESupplierCd = inpDisplay.UOESupplierCd;
            para.DataSendCodes = new int[1];
            para.DataSendCodes[0] = 0;
            return para;
        }
        # endregion

        # region �� �t�n�d�����f�[�^ �������� ��
        /// <summary>
        /// �t�n�d�����f�[�^ ��������
        /// </summary>
        /// <param name="inpDisplay">���������N���X</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^ �����������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
        /// <br>              Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
        /// </remarks>
        public int SearchDB(InpDisplay inpDisplay, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {   //�O���b�h�p�e�[�u���̃N���A
                this.orderDataTable.Rows.Clear();

                //�t�n�d�����f�[�^�������A�N�Z�X�N���X�Ăяo����
                _uOEOrderDtlWorkList = null;
                _stockDetailWorkList = null;

                UOESendProcCndtnPara para = ToUOESendProcCndtnParaFromInpDisplay(inpDisplay);

                status = _uoeOrderInfoAcs.Search(para, out _uOEOrderDtlWorkList, out _stockDetailWorkList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                int index = 1;

                //-----------------------------------------------------------
                // �t�n�d�����f�[�^�̊i�[
                //-----------------------------------------------------------
                foreach (UOEOrderDtlWork uOEOrderDtlWork in _uOEOrderDtlWorkList)
                {
                    StockInputDataSet.OrderExpansionRow row = this.orderDataTable.NewOrderExpansionRow();
                    row.OrderNo = index++;
                    row.OnlineNo = uOEOrderDtlWork.OnlineNo;
                    row.InputDay = uOEOrderDtlWork.InputDay;
                    row.CustomerSnm = uOEOrderDtlWork.CustomerSnm;
                    row.CashRegisterNo = uOEOrderDtlWork.CashRegisterNo;
                    row.GoodsMakerCd = uOEOrderDtlWork.GoodsMakerCd;
                    row.GoodsNo = uOEOrderDtlWork.GoodsNo;
                    row.GoodsName = uOEOrderDtlWork.GoodsName;
                    row.AcceptAnOrderCnt = uOEOrderDtlWork.AcceptAnOrderCnt;
                    row.UoeRemark1 = uOEOrderDtlWork.UoeRemark1;
                    row.EmployeeCode = uOEOrderDtlWork.EmployeeCode;
                    row.EmployeeName = uOEOrderDtlWork.EmployeeName;
                    row.OnlineRowNo = uOEOrderDtlWork.OnlineRowNo;
                    row.UOEKind = uOEOrderDtlWork.UOEKind;
                    row.CommonSeqNo = uOEOrderDtlWork.CommonSeqNo;
                    row.SupplierFormal = uOEOrderDtlWork.SupplierFormal;
                    row.StockSlipDtlNum = uOEOrderDtlWork.StockSlipDtlNum;
                    row.WarehouseName = uOEOrderDtlWork.WarehouseName;// ADD wangyl 2013/02/06 Redmine#34578
                    this.orderDataTable.AddOrderExpansionRow(row);
                }

                IsDataChanged = true;

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -1;
            }

            return status;
        }

        #region �w�b�_�[�����͒l�̕ۑ�����
        /// <summary>
        /// �w�b�_�[�����͒l�̕ۑ�����
        /// </summary>
        /// <param name="inpHedDisplay"> �w�b�_�[�����̓N���X</param>
        /// <remarks>
        /// <br>Note       : �w�b�_�[�����͒l�̕ۑ��������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public void UpdtHedaerItem(InpHedDisplay inpHedDisplay)
        {
            DataView orderDataView = new DataView(this.orderDataTable);

            string rowFilterString = "";

            //�I�����C���ԍ�
            rowFilterString = String.Format("{0} = {1}",
                                                    this.orderDataTable.OnlineNoColumn.ColumnName, inpHedDisplay.OnlineNo);

            orderDataView.RowFilter = rowFilterString;

            for (int ix = 0; ix < orderDataView.Count; ix++)
            {
                StockInputDataSet.OrderExpansionRow dataRow = (StockInputDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                dataRow[this.orderDataTable.UoeRemark1Column.ColumnName] = inpHedDisplay.UoeRemark1;                    // �t�n�d���}�[�N�P
                dataRow[this.orderDataTable.EmployeeCodeColumn.ColumnName] = inpHedDisplay.EmployeeCode;                // �]�ƈ��R�[�h
                dataRow[this.orderDataTable.EmployeeNameColumn.ColumnName] = inpHedDisplay.EmployeeName;                // �]�ƈ�����
            }

        }

        # endregion

        # endregion

        #region �t�n�d�����f�[�^�폜�����擾
        /// <summary>
        /// �t�n�d�����f�[�^�폜�����擾
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�폜�����擾���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public int GetDeleteCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
                count = orderDataView.Count;
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }

        /// <summary>
        /// �t�n�d�����f�[�^�I�����Ȃ��̌����擾
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�I�����Ȃ��̌����擾���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public int GetNoSelectCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, false);
                count = orderDataView.Count;
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }
        # endregion

        #region �����u���b�N���̎Z�o
        /// <summary>
        /// �t�n�d�����f�[�^�����u���b�N���̎Z�o
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�����u���b�N���̎Z�o���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public int GetBlocCount()
        {
            int count = 0;
            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);

                //���M���א�
                int detailIndex = 0;
                //�O���ײݔԍ�
                int bfOnlineNo = 0;
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    StockInputDataSet.OrderExpansionRow dataRow = (StockInputDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                    Int32 onlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];

                    detailIndex++;

                    if (bfOnlineNo == 0 || bfOnlineNo != onlineNo)
                    {
                        count++;
                        bfOnlineNo = onlineNo;
                        detailIndex = 0;
                    }
                    else
                    {
                        if (detailIndex >= 6)
                        {
                            count++;
                            bfOnlineNo = onlineNo;
                            detailIndex = 0;
                        }
                    }
                }

            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }

        # endregion

        #region �t�n�d�����f�[�^�X�V����
        /// <summary>
        /// �f�[�^�ۑ�����
        /// </summary>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="uOESupplier">���_�R�[�h</param>
        /// <param name="message">Message</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�ۑ��������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// <br>Update Note: 2012/02/22 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/03/28�z�M��</br>
        /// <br>             Redmine#28287 �V�X�e���敪���݌Ɉꊇ���A���ʂɂO��ݒ肳�ꂽ���ׂ��폜�����ɂ��Ă̑Ή�</br>
        /// </remarks>
        //public int WriteDB(UOESupplier uOESupplier, out string message)//DEL ���N�n�� 2012/02/22 Redmine#28287
        public int WriteDB(int systemDiv, UOESupplier uOESupplier, out string message)//ADD ���N�n�� 2012/02/22 Redmine#28287
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            try
            {
                //�ۑ��f�[�^�擾����
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;
                List<StockDetailWork> stockDetailWorkList = null;

                //---ADD ���N�n�� 2012/02/22 Redmine#28287------>>>>>
                List<UOEOrderDtlWork> uOEOrderDtlWorkDelList = null;
                List<StockDetailWork> stockDetailWorkDelList = null;
                //---ADD ���N�n�� 2012/02/22 Redmine#28287------<<<<<

                //status = GetUOEOrderDtlWorkFromRowData(1, out uOEOrderDtlWorkList, out stockDetailWorkList, out message);//DEL ���N�n�� 2012/02/22 Redmine#28287
                status = GetUOEOrderDtlWorkFromRowData(1, systemDiv, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);//ADD ���N�n�� 2012/02/22 Redmine#28287

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                //---DEL ���N�n�� 2012/02/22 Redmine#28287------>>>>>
                //if (uOEOrderDtlWorkList == null) return (-1);
                //if (uOEOrderDtlWorkList.Count == 0) return (-1);
                //---DEL ���N�n�� 2012/02/22 Redmine#28287------<<<<<

                //---ADD ���N�n�� 2012/02/22 Redmine#28287------>>>>>
                if (uOEOrderDtlWorkList == null && uOEOrderDtlWorkDelList == null) return (-1);
                if (uOEOrderDtlWorkList.Count == 0 && uOEOrderDtlWorkDelList.Count == 0) return (-1);
                // �V�X�e���敪���݌Ɉꊇ���A���ʂɂO��ݒ肳�ꂽ���ׂ��폜����
                if (uOEOrderDtlWorkDelList != null && uOEOrderDtlWorkDelList.Count > 0)
                {
                    status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);
                }
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkList != null && uOEOrderDtlWorkList.Count > 0)
                {
                //---ADD ���N�n�� 2012/02/22 Redmine#28287------<<<<<
                    status = _uoeOrderInfoAcs.WriteUOEOrderDtl(ref uOEOrderDtlWorkList, ref stockDetailWorkList, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);

                    //�󒍃}�X�^�i�ԗ��j���擾
                    GetacceptOdrCarWorkList(stockDetailWorkList);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //�F�ؗpHTML���쐬
                        DoLoginHtml(uOESupplier);
                        //�����m�F�pHTML�̍쐬
                        DoEpartsHtml(uOEOrderDtlWorkList, stockDetailWorkList, uOESupplier);
                        //--------ADD BY ������ on 2011/12/02 for Redmine#8304 ---------->>>>>>>>>>>>>
                        //�z���_e-Parts bak�t�@�C��
                        string tempPath = Path.GetTempPath();
                        string timeFormat = "yyyyMMddHHmmss";
                        DateTime dateTime = DateTime.Now;
                        string bakFileName = "e-Parts_" + dateTime.ToString(timeFormat) + ".html";
                        File.Copy(tempPath + "\\" + "e-Parts.html", uOESupplier.AnswerSaveFolder + "\\" + bakFileName);
                        //--------ADD BY ������ on 2011/12/02 for Redmine#8304 ----------<<<<<<<<<<<<<
                    }
                }//ADD ���N�n�� 2012/02/22 Redmine#28287
           
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -1;
            }
            return status;
        }        

        /// <summary>
        /// �󒍃}�X�^�i�ԗ��j���擾����
        /// </summary>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �󒍃}�X�^�i�ԗ��j���擾�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public void GetacceptOdrCarWorkList(List<StockDetailWork> stockDetailWorkList)
        {
            ArrayList acceptOdrCarWorkList = new ArrayList();
            List<AcceptOdrCarWork> tempList = new List<AcceptOdrCarWork>();

            _acceptOdrCarWorkList = new List<AcceptOdrCarWork>();

            foreach (StockDetailWork stockDetailWork in stockDetailWorkList)
            {
                AcceptOdrCarWork AcceptOdrCarWork = new AcceptOdrCarWork();
                AcceptOdrCarWork.EnterpriseCode = this._enterpriseCode;
                AcceptOdrCarWork.AcceptAnOrderNo = stockDetailWork.AcceptAnOrderNo;
                AcceptOdrCarWork.AcptAnOdrStatus = 3;
                AcceptOdrCarWork.DataInputSystem = 10;
                acceptOdrCarWorkList.Add(AcceptOdrCarWork);

            }
            object acceptOdrCarObj = acceptOdrCarWorkList;
            int status = _iAcceptOdrCarDB.ReadAll(ref acceptOdrCarObj);
            if (acceptOdrCarObj is ArrayList)
            {
                acceptOdrCarWorkList = (ArrayList)acceptOdrCarObj;

                for (int i = 0; i < acceptOdrCarWorkList.Count; i++)
                {
                    AcceptOdrCarWork temp = (AcceptOdrCarWork)acceptOdrCarWorkList[i];
                    tempList.Add(temp);
                }
            }

            _acceptOdrCarWorkList = tempList;

        }

        /// <summary>
        /// �󒍃}�X�^�i�ԗ��j���擾����
        /// </summary>
        /// <param name="uOEOrderDtlWork">UOE�����f�[�^</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �󒍃}�X�^�i�ԗ��j���擾�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public List<AcceptOdrCarWork> GetacceptOdrCarWork(UOEOrderDtlWork uOEOrderDtlWork, List<StockDetailWork> stockDetailWorkList)
        {
            string key = string.Empty;

            List<StockDetailWork> stockresultList;
            List<AcceptOdrCarWork> acceptOdrCarWorkList = new List<AcceptOdrCarWork>();

            key = MakeStockKey(uOEOrderDtlWork.EnterpriseCode, uOEOrderDtlWork.SupplierFormal, uOEOrderDtlWork.StockSlipDtlNum);
            stockresultList = stockDetailWorkList.FindAll(delegate(StockDetailWork target)
            {
                if (key.Equals(MakeStockKey(target.EnterpriseCode, target.SupplierFormal, target.StockSlipDtlNum)))
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (stockresultList != null && stockresultList.Count > 0)
            {
                StockDetailWork stockDetailWork = (StockDetailWork)stockresultList[0];

                acceptOdrCarWorkList = this._acceptOdrCarWorkList.FindAll(delegate(AcceptOdrCarWork target)
                {
                    if (stockDetailWork.AcceptAnOrderNo.Equals(target.AcceptAnOrderNo))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });
            }

            return acceptOdrCarWorkList;
        }

        # endregion

        #region �I���f�[�^�̎擾����
        /// <summary>
        /// �I���f�[�^�̎擾����
        /// </summary>
        /// <param name="mode">0:�S�� 1:�ύX�f�[�^ 2:�I���f�[�^</param>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^���X�g</param>
        /// <param name="stockDetailWorkList">�d�����׃��X�g</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE�����f�[�^�폜�p���X�g</param>
        /// <param name="stockDetailWorkDelList">�d�����׍폜�p���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I���f�[�^�̎擾�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// <br>Update Note: 2012/02/06 ������</br>
        /// <br>�Ǘ��ԍ�   �F2012/03/28�z�M��</br>
        /// <br>             Redmine#28287�̑Ή�</br>
        /// <br>Update Note: 2012/02/22 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/03/28�z�M��</br>
        /// <br>             Redmine#28287 �V�X�e���敪���݌Ɉꊇ���A���ʂɂO��ݒ肳�ꂽ���ׂ��폜�����ɂ��Ă̑Ή�</br>
        /// </remarks>
        //public int GetUOEOrderDtlWorkFromRowData(int mode, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, out string message)//DEL ���N�n�� 2012/02/22 Redmine#28287
        public int GetUOEOrderDtlWorkFromRowData(int mode, int systemDiv, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList, out string message)//ADD ���N�n�� 2012/02/22 Redmine#28287
        {
            // �ߒl
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();
            //---ADD ���N�n�� 2012/02/22 Redmine#28287------>>>>>
            uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
            stockDetailWorkDelList = new List<StockDetailWork>();
            //---ADD ���N�n�� 2012/02/22 Redmine#28287------<<<<<
            message = "";

            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);

                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);

                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    string key;
                    List<UOEOrderDtlWork> uOEresultList;
                    List<StockDetailWork> stockresultList;
                    UOEOrderDtlWork uOEOrderDtlWork = new UOEOrderDtlWork();

                    StockInputDataSet.OrderExpansionRow dataRow = (StockInputDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                    uOEOrderDtlWork.OnlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];
                    uOEOrderDtlWork.OnlineRowNo = (Int32)dataRow[this.orderDataTable.OnlineRowNoColumn.ColumnName];
                    uOEOrderDtlWork.UOEKind = (Int32)dataRow[this.orderDataTable.UOEKindColumn.ColumnName];
                    uOEOrderDtlWork.CommonSeqNo = (Int64)dataRow[this.orderDataTable.CommonSeqNoColumn.ColumnName];
                    uOEOrderDtlWork.SupplierFormal = (Int32)dataRow[this.orderDataTable.SupplierFormalColumn.ColumnName];
                    uOEOrderDtlWork.StockSlipDtlNum = (Int64)dataRow[this.orderDataTable.StockSlipDtlNumColumn.ColumnName];

                    key = MakeKey(uOEOrderDtlWork);

                    //�f�[�^�擾����
                    uOEresultList = this._uOEOrderDtlWorkList.FindAll(delegate(UOEOrderDtlWork target)
                    {
                        if (key.Equals(MakeKey(target)))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    if (uOEresultList.Count != 0)
                    {
                        UOEOrderDtlWork uOEOrderDtlWorktemp = uOEresultList[0];
                        //---DEL ���N�n�� 2012/02/22 Redmine#28287------>>>>>
                        //if (mode == 1)
                        //{
                        //---DEL ���N�n�� 2012/02/22 Redmine#28287------<<<<<
                        //---ADD ���N�n�� 2012/02/22 Redmine#28287------>>>>>
                        if (mode == 1 && (systemDiv != 3
                        || 0 != double.Parse(dataRow[this.orderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString())))
                        {
                        //---ADD ���N�n�� 2012/02/22 Redmine#28287------<<<<<
                            uOEOrderDtlWorktemp.ReceiveDate = System.DateTime.Now;
                            uOEOrderDtlWorktemp.DataSendCode = 1;
                            uOEOrderDtlWorktemp.DataRecoverDiv = 0;
                            uOEOrderDtlWorktemp.UoeRemark1 = dataRow[this.orderDataTable.UoeRemark1Column.ColumnName].ToString().Trim();
                            uOEOrderDtlWorktemp.EmployeeCode = dataRow[this.orderDataTable.EmployeeCodeColumn.ColumnName].ToString().Trim();
                            uOEOrderDtlWorktemp.EmployeeName = dataRow[this.orderDataTable.EmployeeNameColumn.ColumnName].ToString().Trim();
                            uOEOrderDtlWorktemp.AcceptAnOrderCnt = (double)dataRow[this.orderDataTable.AcceptAnOrderCntColumn.ColumnName];//ADD BY ������ on 2012/02/06 for Redmine#28287
                            //}//DEL ���N�n�� 2012/02/22 Redmine#28287

                            uOEOrderDtlWorkList.Add(uOEOrderDtlWorktemp);

                            key = MakeStockKey(uOEOrderDtlWorktemp.EnterpriseCode, uOEOrderDtlWorktemp.SupplierFormal, uOEOrderDtlWorktemp.StockSlipDtlNum);
                            stockresultList = this._stockDetailWorkList.FindAll(delegate(StockDetailWork target)
                            {
                                if (key.Equals(MakeStockKey(target.EnterpriseCode, target.SupplierFormal, target.StockSlipDtlNum)))
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            foreach (StockDetailWork stockDetailWork in stockresultList)
                            {
                                stockDetailWorkList.Add(stockDetailWork);
                            }
                        //---ADD ���N�n�� 2012/02/22 Redmine#28287------>>>>>
                        }
                        else
                        {
                            uOEOrderDtlWorkDelList.Add(uOEOrderDtlWorktemp);

                            key = MakeStockKey(uOEOrderDtlWorktemp.EnterpriseCode, uOEOrderDtlWorktemp.SupplierFormal, uOEOrderDtlWorktemp.StockSlipDtlNum);
                            stockresultList = this._stockDetailWorkList.FindAll(delegate(StockDetailWork target)
                            {
                                if (key.Equals(MakeStockKey(target.EnterpriseCode, target.SupplierFormal, target.StockSlipDtlNum)))
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            foreach (StockDetailWork stockDetailWork in stockresultList)
                            {
                                stockDetailWorkDelList.Add(stockDetailWork);
                            }
                        }
                        //---ADD ���N�n�� 2012/02/22 Redmine#28287------<<<<<
                    }
                }
            }
            catch (Exception ex)
            {
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
                message = ex.Message;
                status = -1;
            }

            return status;

        }

        #endregion

        #region �t�n�d�����f�[�^�폜����
        /// <summary>
        /// �t�n�d�����f�[�^�폜����
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�폜�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// <br>Update Note: 2012/02/22 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/03/28�z�M��</br>
        /// <br>             Redmine#28287 �V�X�e���敪���݌Ɉꊇ���A���ʂɂO��ݒ肳�ꂽ���ׂ��폜�����ɂ��Ă̑Ή�</br>
        /// </remarks>
        public int DeleteDB(out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                // �폜�Ώۂ̂t�n�d�����f�[�^�̎擾
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;
                List<StockDetailWork> stockDetailWorkList = null;

                //---ADD ���N�n�� 2012/02/22 Redmine#28287------>>>>>
                List<UOEOrderDtlWork> uOEOrderDtlWorkDelList = null;
                List<StockDetailWork> stockDetailWorkDelList = null;
                //---ADD ���N�n�� 2012/02/22 Redmine#28287------<<<<<

                //status = GetUOEOrderDtlWorkFromRowData(2, out uOEOrderDtlWorkList, out stockDetailWorkList, out message);//DEL ���N�n�� 2012/02/22 Redmine#28287
                status = GetUOEOrderDtlWorkFromRowData(2, 0, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);//ADD ���N�n�� 2012/02/22 Redmine#28287
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);

                //---DEL ���N�n�� 2012/02/22 Redmine#28287------>>>>>
                //if (uOEOrderDtlWorkList == null) return (-1);
                //if (uOEOrderDtlWorkList.Count == 0) return (-1);
                //---DEL ���N�n�� 2012/02/22 Redmine#28287------<<<<<

                //---DEL ���N�n�� 2012/02/22 Redmine#28287------>>>>>
                if (uOEOrderDtlWorkDelList == null) return (-1);
                if (stockDetailWorkDelList.Count == 0) return (-1);
                //---DEL ���N�n�� 2012/02/22 Redmine#28287------<<<<<

                //status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkList, out message);//DEL ���N�n�� 2012/02/22 Redmine#28287
                status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);//ADD ���N�n�� 2012/02/22 Redmine#28287
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -1;
            }
            return status;
        }

        # endregion
        #region Key�쐬
        /// <summary>
        /// Key�쐬����
        /// </summary>
        /// <param name="uOEOrderDtlWork">���ׁE�s</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : Key�쐬�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private string MakeKey(UOEOrderDtlWork uOEOrderDtlWork)
        {
            // ���ׁE�sPrimary Key
            string key = uOEOrderDtlWork.OnlineNo.ToString() + uOEOrderDtlWork.OnlineRowNo.ToString() + uOEOrderDtlWork.UOEKind.ToString()
                + uOEOrderDtlWork.CommonSeqNo.ToString() + uOEOrderDtlWork.SupplierFormal.ToString() + uOEOrderDtlWork.StockSlipDtlNum.ToString();

            return key;
        }

        /// <summary>
        /// Key�쐬����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="supplierFormal">�d���`��</param>
        /// <param name="stockSlipDtlNum">�d�����גʔ�</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : ���ׁE�sKey�쐬�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private string MakeStockKey(string enterpriseCode, int supplierFormal, long stockSlipDtlNum)
        {
            // ���ׁE�sPrimary Key
            string key = enterpriseCode.ToString() + supplierFormal.ToString() + stockSlipDtlNum.ToString();
            return key;
        }


        #endregion Key�쐬

        #region Html�쐬
        /// <summary>
        /// �F�ؗpHtml�쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �F�ؗpHtml�쐬�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private void DoLoginHtml(UOESupplier uOESupplier)
        {
            string tempPath = Path.GetTempPath();
            string htmlString = GetLoginHtmlContent();
            //UOE�����I��URL
            htmlString = htmlString.Replace("{%openurl%}", uOESupplier.UOEForcedTermUrl);
            //UOE���O�C��URL
            htmlString = htmlString.Replace("{%formactionurl%}", uOESupplier.UOELoginUrl);
            //e-Parts���[�UID
            htmlString = htmlString.Replace("{%username%}", uOESupplier.EPartsUserId);
            //e-Parts�p�X���[�h
            htmlString = htmlString.Replace("{%password%}", uOESupplier.EPartsPassWord);
            string loginHtmlPath = tempPath + "login.html";
            // 2011/10/26 >>>
            //using (StreamWriter sw = new StreamWriter(loginHtmlPath, false, System.Text.Encoding.GetEncoding("UTF-8"))) //�ۑ��n��
            using (StreamWriter sw = new StreamWriter(loginHtmlPath, false, System.Text.Encoding.GetEncoding("Shift_JIS")))
            // 2011/10/26 <<<
            {
                sw.WriteLine(htmlString);
                sw.Flush();
                sw.Close();
            }

            // DEL 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή� ----->>>>>
            //string IELocation = @"%ProgramFiles%\Internet Explorer\iexplore.exe";
            //IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);

            //Process.Start(IELocation, loginHtmlPath);

            // DEL 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή� -----<<<<<
            // ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή� ----->>>>>
            string IELocation = string.Empty;

            // 0:ie  1:edg
            if (browserUseFlg == 0)
            {
                IELocation = IELOCATIONSTR;
                IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);
            }
            else
            {
                IELocation = MSEDGELOCATIONSTR;
                IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);

                //�N������u���E�U��Edge�̏ꍇ�A�u%ProgramFiles%\Microsoft\Edge\Application\msedge.exe�v�����݂��Ȃ�������IE�ŋN������
                if (!File.Exists(IELocation))
                {
                    IELocation = IELOCATIONSTR;
                    IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);
                }
            }

            Process.Start(IELocation, loginHtmlPath);
            // ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή� -----<<<<<
        }

        // --- ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή� ----->>>>>
        /// <summary>
        /// �u���E�U�ݒ�XML�t�@�C���擾
        /// </summary>
        private void GetBrowserSettingInfo()
        {
            // 0:ie  1:edg
            try
            {
                BrowserSettingInfo browserSettingInfo = new BrowserSettingInfo();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CUSTOMSIZESETTINGSFILE)))
                {
                    // XML�擾
                    browserSettingInfo = UserSettingController.DeserializeUserSetting<BrowserSettingInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CUSTOMSIZESETTINGSFILE));
                    browserUseFlg = browserSettingInfo.BrowserUseFlg;

                    //�l���s���ȏꍇ��Edge�œ��삷��
                    if (browserUseFlg != 0 && browserUseFlg != 1)
                    {
                        browserUseFlg = 1;
                    }
                }
                else
                {
                    //XML�t�@�C�������������ꍇ��Edge�œ��삷��悤�ɂ���
                    browserUseFlg = 1;
                }
            }
            catch
            {
                browserUseFlg = 1;
            }
        }
        // --- ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή� -----<<<<<

        /// <summary>
        /// �����m�F�pHTML�쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����m�F�pHTML�쐬�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private void DoEpartsHtml(List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList, UOESupplier uOESupplier)
        {
            string tempPath = Path.GetTempPath();

            List<List<UOEOrderDtlWork>> tempList = GetList(uOEOrderDtlWorkList);

            string htmlString = GetEpartsHtmlContent(tempList, stockDetailWorkList);

            //UOE�����I��URL
            htmlString = htmlString.Replace("{%openurl%}", uOESupplier.UOEForcedTermUrl);

            //UOE���O�C��URL
            if (uOESupplier.InqOrdDivCd == 0)
            {
                htmlString = htmlString.Replace("{%formactionurl%}", uOESupplier.UOEOrderUrl);
            }
            else
            {
                htmlString = htmlString.Replace("{%formactionurl%}", uOESupplier.UOEStockCheckUrl);
            }

            //dirPath
            htmlString = htmlString.Replace("{%dirPath%}", uOESupplier.AnswerSaveFolder);

            //item
            htmlString = htmlString.Replace("{%item%}", uOESupplier.UOEItemCd.PadLeft(5, '0'));

            //���O�C���^�C���A�E�gtime
            _time = uOESupplier.LoginTimeoutVal;

            string loginHtmlPath = tempPath + "e-parts.html";
            // 2011/10/26 >>>
            //using (StreamWriter sw = new StreamWriter(loginHtmlPath, false, System.Text.Encoding.GetEncoding("UTF-8"))) //�ۑ��n��
            using (StreamWriter sw = new StreamWriter(loginHtmlPath, false, System.Text.Encoding.GetEncoding("Shift_JIS")))
            // 2011/10/26 <<<
            {
                sw.WriteLine(htmlString);
                sw.Flush();
                sw.Close();
            }

            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync(loginHtmlPath);

        }

        /// <summary>
        /// �����m�F�pHTML�쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����m�F�pHTML�쐬�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // DEL 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή� ----->>>>>
            //string IELocation = @"%ProgramFiles%\Internet Explorer\iexplore.exe";
            //IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);
            // DEL 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή� -----<<<<<

            // ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή� ----->>>>>
            string IELocation = string.Empty;

            // 0:ie  1:edg
            if (browserUseFlg == 0)
            {
                IELocation = IELOCATIONSTR;
                IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);
            }
            else
            {
                IELocation = MSEDGELOCATIONSTR;
                IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);
                //�N������u���E�U��Edge�̏ꍇ�A�u%ProgramFiles%\Microsoft\Edge\Application\msedge.exe�v�����݂��Ȃ�������IE�ŋN������
                if (!File.Exists(IELocation))
                {
                    IELocation = IELOCATIONSTR;
                    IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);
                }
            }
            // ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή� -----<<<<<

            Thread.Sleep(_time * 1000);

            Process.Start(IELocation, e.Argument.ToString());
        }

        /// <summary>
        /// �����m�F�pList�쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����m�F�pList�쐬�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private List<List<UOEOrderDtlWork>> GetList(List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            //uOEOrderDtlWorkList.Sort(delegate(UOEOrderDtlWork x, UOEOrderDtlWork y) { return x.UOESalesOrderNo - y.UOESalesOrderNo; });

            //�O��UOE�����ԍ�
            int befUOESalesOrderNo = 0;

            List<List<UOEOrderDtlWork>> tempList = new List<List<UOEOrderDtlWork>>();

            List<UOEOrderDtlWork> temp = new List<UOEOrderDtlWork>();

            for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
            {
                UOEOrderDtlWork uOEOrderDtlWork = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                if (befUOESalesOrderNo == 0 || befUOESalesOrderNo != uOEOrderDtlWork.UOESalesOrderNo)
                {
                    if (befUOESalesOrderNo == 0)
                    {
                        temp.Add(uOEOrderDtlWork);
                    }

                    if (befUOESalesOrderNo != 0 && befUOESalesOrderNo != uOEOrderDtlWork.UOESalesOrderNo)
                    {
                        tempList.Add(temp);

                        temp = new List<UOEOrderDtlWork>();

                        temp.Add(uOEOrderDtlWork);
                    }

                    befUOESalesOrderNo = uOEOrderDtlWork.UOESalesOrderNo;

                }
                else
                {
                    temp.Add(uOEOrderDtlWork);
                }

                if (i == (uOEOrderDtlWorkList.Count - 1))
                {
                    tempList.Add(temp);
                }
            }

            return tempList;
        }

        /// <summary>
        /// �F�ؗpHtml�쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �F�ؗpHtml�쐬�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private static string GetLoginHtmlContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<!-- saved from url=(0022)http://internet.e-mail -->");
            sb.Append("\r\n");
            sb.Append("<html><head><script language=\"javascript\">");
            sb.Append("\r\n");
            sb.Append(@"function beforeOrder(){");
            sb.Append("\r\n");
            sb.Append(@"    document.form1.submit();");
            sb.Append("\r\n");
            sb.Append(@"}");
            sb.Append("\r\n");
            sb.Append(@"function closeForce() {");
            sb.Append("\r\n");
            sb.Append(@"    if (!document.all) {");
            sb.Append("\r\n");
            sb.Append(@"        // for Netscape");
            sb.Append("\r\n");
            sb.Append("        window.open(\"{%openurl%}\", \"_top\");");
            sb.Append("\r\n");
            sb.Append(@"        window.close();");
            sb.Append("\r\n");
            sb.Append(@"   } else if ((navigator.userAgent.match(/MSIE (\d\.\d)/), RegExp.$1) >= 5.5) {");
            sb.Append("\r\n");
            sb.Append(@"       // for IE 6.0 or later");
            sb.Append("\r\n");
            sb.Append("       var w = window.open(\"{%openurl%}\", \"_top\");");
            sb.Append("\r\n");
            sb.Append(@"        w.opener = window;");
            sb.Append("\r\n");
            sb.Append(@"        w.close();");
            sb.Append("\r\n");
            sb.Append(@"    } else {");
            sb.Append("\r\n");
            sb.Append(@"        // for IE4, IE5.0");
            sb.Append("\r\n");
            sb.Append(@"        window.close()");
            sb.Append("\r\n");
            sb.Append("        setTimeout(\"closeForce()\", 500);");
            sb.Append("\r\n");
            sb.Append(@"    }");
            sb.Append("\r\n");
            sb.Append(@"}");
            sb.Append("\r\n");
            sb.Append(@"</script><body >");
            sb.Append("\r\n");
            sb.Append(@"<!-- ���� -->");
            sb.Append("\r\n");
            //sb.Append("<form name=\"form1\" action=\"{%formactionurl%}\" method=\"post\" target=\"HONDA_IPO\">"); //DEL 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή�
            sb.Append("<form name=\"form1\" action=\"{%formactionurl%}\" method=\"post\" target=\"_self\">"); //ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή�
            sb.Append("\r\n");
            sb.Append("    <input type=\"hidden\" name=\"username\" value=\"{%username%}\">");
            sb.Append("\r\n");
            sb.Append("    <input type=\"hidden\" name=\"password\" value=\"{%password%}\">");
            sb.Append("\r\n");
            sb.Append("    <input type=\"hidden\" name=\"login-form-type\" value=\"pwd\">");
            sb.Append("\r\n");
            sb.Append(@"</form>");
            sb.Append("\r\n");
            sb.Append("\r\n");
            sb.Append(@"</form></body>");
            sb.Append("\r\n");
            sb.Append("<script language=\"javascript\">beforeOrder()</script>");
            sb.Append("\r\n");
            sb.Append("<script language=\"javascript\">closeForce()</script>");
            sb.Append("\r\n");
            sb.Append(@"</html>");
            return sb.ToString();
        }

        /// <summary>
        ///�����m�F�pHTML�쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����m�F�pHTML�쐬�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private string GetEpartsHtmlContent(List<List<UOEOrderDtlWork>> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<!-- saved from url=(0022)http://internet.e-mail -->");
            sb.Append("\r\n");
            sb.Append("<html><head><script language=\"javascript\">");
            sb.Append("\r\n");
            sb.Append(@"function order(){");
            sb.Append("\r\n");
            sb.Append(@"document.form2.submit();");
            sb.Append("\r\n");
            sb.Append(@"}");
            sb.Append("\r\n");
            sb.Append(@"function closeForce() {");
            sb.Append("\r\n");
            sb.Append(@"if (!document.all) {");
            sb.Append("\r\n");
            sb.Append(@"// for Netscape");
            sb.Append("\r\n");
            sb.Append("window.open(\"{%openurl%}\", \"_top\");");
            sb.Append("\r\n");
            sb.Append(@"window.close();");
            sb.Append("\r\n");
            sb.Append(@"} else if ((navigator.userAgent.match(/MSIE (\d\.\d)/), RegExp.$1) >= 5.5) {");
            sb.Append("\r\n");
            sb.Append(@"// for IE 6.0 or later");
            sb.Append("\r\n");
            sb.Append("var w = window.open(\"{%openurl%}\", \"_top\");");
            sb.Append("\r\n");
            sb.Append(@"w.opener = window;");
            sb.Append("\r\n");
            sb.Append(@"w.close();");
            sb.Append("\r\n");
            sb.Append(@"} else {");
            sb.Append("\r\n");
            sb.Append(@"// for IE4, IE5.0");
            sb.Append("\r\n");
            sb.Append(@"window.close()");
            sb.Append("\r\n");
            sb.Append("setTimeout(\"closeForce()\", 500);");
            sb.Append("\r\n");
            sb.Append(@"}");
            sb.Append("\r\n");
            sb.Append(@"}");
            sb.Append("\r\n");
            sb.Append(@"</script><body>");
            sb.Append("\r\n");
            sb.Append(@"<!-- ���� -->");
            sb.Append("\r\n");
            //sb.Append("<form name=\"form2\" action=\"{%formactionurl%}\" method=\"post\" target=\"HONDA_IPO\">");//DEL 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή�
            sb.Append("<form name=\"form2\" action=\"{%formactionurl%}\" method=\"post\" target=\"_self\">");//ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή�
            sb.Append("\r\n");
            sb.Append("<input type=\"hidden\" name=\"interfaceXML\" value=\'<order>");
            sb.Append("\r\n");
            sb.Append("<OrderInfo dirPath=\"{%dirPath%}\" />");
            sb.Append("\r\n");

            foreach (List<UOEOrderDtlWork> UOEOrderDtlWork in uOEOrderDtlWorkList)
            {
                UOEOrderDtlWork uOEOrderDtlWork = (UOEOrderDtlWork)UOEOrderDtlWork[0];
                List<AcceptOdrCarWork> acceptOdrCarWorkList = GetacceptOdrCarWork(uOEOrderDtlWork, stockDetailWorkList);

                sb.Append(@"<hattyu>");
                sb.Append("\r\n");

                sb.Append("<HattyuInfo onlineNo=\"");
                sb.Append(UOEOrderDtlWork[0].UOESalesOrderNo.ToString("d8"));
                sb.Append("\" item=\"{%item%}\"");
                sb.Append(" reMark=\"");
                sb.Append(UOEOrderDtlWork[0].UoeRemark1);
                sb.Append("\" />");

                sb.Append("\r\n");
                sb.Append(@"<model>");
                sb.Append("\r\n");

                string modelDesignationNo = string.Empty;
                string categoryNo = string.Empty;
                string modelFullName = string.Empty;
                string seriesModel = string.Empty;
                string searchFrameNo = string.Empty;

                if (null != acceptOdrCarWorkList && acceptOdrCarWorkList.Count > 0)
                {
                    AcceptOdrCarWork acceptOdrCarWork = (AcceptOdrCarWork)acceptOdrCarWorkList[0];
                    modelDesignationNo = acceptOdrCarWork.ModelDesignationNo.ToString("d5");
                    categoryNo = acceptOdrCarWork.CategoryNo.ToString("d4");
                    //modelFullName = acceptOdrCarWork.ModelFullName; // DEL gezh 2011/11/17
                    modelFullName = acceptOdrCarWork.ModelHalfName; // ADD gezh 2011/11/17
                    seriesModel = acceptOdrCarWork.SeriesModel;
                    searchFrameNo = acceptOdrCarWork.SearchFrameNo.ToString("d8");
                }

                sb.Append("<ModelInfo katashikiShitei=\"");
                sb.Append(modelDesignationNo);
                sb.Append("\" katashikiRuibetsu=\"");
                sb.Append(categoryNo);
                sb.Append("\" name=\"");
                sb.Append(modelFullName);
                sb.Append("\" katashiki=\"");
                sb.Append(seriesModel);
                sb.Append("\" frameNo=\"");
                sb.Append(searchFrameNo);
                sb.Append("\" />");

                sb.Append("\r\n");
                sb.Append(@"<parts>");
                sb.Append("\r\n");

                foreach (UOEOrderDtlWork temp in UOEOrderDtlWork)
                {
                    sb.Append("<PartInfo partno=\"");
                    sb.Append(temp.GoodsNoNoneHyphen);
                    sb.Append("\" odrQty=\"");
                    sb.Append(temp.AcceptAnOrderCnt);
                    sb.Append("\" repQty=\"0\" />");
                    sb.Append("\r\n");
                }

                sb.Append(@"</parts>");
                sb.Append("\r\n");
                sb.Append(@"</model>");
                sb.Append("\r\n");
                sb.Append(@"</hattyu>");
                sb.Append("\r\n");
            }

            sb.Append(@"</order>");
            sb.Append("\r\n");
            sb.Append(@"'>");
            sb.Append("\r\n");
            sb.Append(@"</form></body>");
            sb.Append("\r\n");
            sb.Append("<script language=\"javascript\">order()</script>");
            sb.Append("\r\n");
            sb.Append("<script language=\"javascript\">closeForce()</script>");
            sb.Append("\r\n");
            sb.Append(@"</html>");

            return sb.ToString();
        }

        /// <summary>
        /// �^�������񏈗�
        /// </summary>
        /// <param name="seriesModel">�V���[�Y�^��</param>
        /// <returns>�V���[�Y�^��</returns>
        /// <remarks>
        /// <br>Note       : �^�������񏈗����s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private string GetSeriesModel(string seriesModel)
        {
            string temp = string.Empty;
            if (!string.IsNullOrEmpty(seriesModel))
            {
                if (seriesModel.Contains("-"))
                {
                    string[] seriesModelList = seriesModel.Split(new char[] { '-' });

                    if (seriesModelList.Length <= 2)
                    {
                        temp = seriesModelList[0];
                    }
                    else
                    {
                        temp = seriesModelList[1];
                    }
                }
                else
                {
                    temp = seriesModel;
                }
            }

            return temp;
        }

        #endregion Html�쐬
    }

    // --- ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή� --->>>>>
    /// <summary>
    /// �u���E�U�ݒ�N���X
    /// </summary>
    [Serializable]
    public class BrowserSettingInfo
    {
        // �u���E�U�g�p�敪
        private int _browserUseFlg;

        /// <summary>
        /// �u���E�U�ݒ�N���X
        /// </summary>
        public BrowserSettingInfo()
        {

        }

        /// <summary>�u���E�U�g�p�敪 0:iexplore 1:msedge</summary>
        public Int32 BrowserUseFlg
        {
            get { return this._browserUseFlg; }
            set { this._browserUseFlg = value; }
        }
    }
    // --- ADD 2022/06/20 ���O PMKOBETSU-4212 �z���_ e-parts���������@Edgi�Ή� ---<<<<<
}
