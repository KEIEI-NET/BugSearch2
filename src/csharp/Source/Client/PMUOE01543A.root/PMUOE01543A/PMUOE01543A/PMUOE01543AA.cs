//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�c�_��������
// �v���O�����T�v   : �}�c�_�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : �����
// �� �� ��  2011/05/18  �C�����e : �V�K�쐬
//                                  �}�c�_WebUOE�Ƃ̘A�g�p�f�[�^�Ƃ��āAUOE�����f�[�^����}�c�_�p�V�X�e���A�g�A�h���X�̍쐬���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2011/10/12  �C�����e : �}�c�_WebUOE�s��Ή�
//                                  URL�ɃZ�b�g����i�Ԃ��n�C�t�������ɕύX����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/12/02  �C�����e : Redmine#8304�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : wangyl
// �C �� ��  2013/02/06  �C�����e : 10900690-00 2013/03/13�z�M���ً̋}�Ή�
//                                  Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870080-00 �쐬�S�� : ���O
// �C �� ��  2022/06/20  �C�����e : PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Data;
using System.Diagnostics;
//---ADD 2022/06/20 ���O PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�--->>>>>
using Broadleaf.Application.Resources;
using System.IO;
//---ADD 2022/06/20 ���O PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�---<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �}�c�_���������A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �}�c�_���������̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2011/05/18</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
    /// <br>              Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
    /// <br>Update Note : 2022/06/20 ���O</br>
    /// <br>�Ǘ��ԍ�    : 11870080-00</br>
    /// <br>              PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�</br>
    /// </remarks>
    public partial class MazdaOrderProcAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private bool _isDataCanged = false;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // ADD 2011/12/31

        //�A�N�Z�X�N���X
        private static MazdaOrderProcAcs _supplierAcs;
        private UoeOrderInfoAcs _uoeOrderInfoAcs;

        //�f�[�^�[�e�[�u��
        private MazdaOrderProcDataSet _dataSet;
        private MazdaOrderProcDataSet.OrderExpansionDataTable _orderDataTable;

        //�]�ƈ��}�X�^
        private Dictionary<string, EmployeeWork> _employeeWork;
        private IEmployeeDB _iEmployeeDB;                               // �]�ƈ���� �A�N�Z�X�N���X

        //�t�n�d�����f�[�^�������A�N�Z�X�N���X�Ăяo����
        List<UOEOrderDtlWork> _uOEOrderDtlWorkList = null;
        List<StockDetailWork> _stockDetailWorkList = null;

        private UOESupplier _uOESupplier = null;

        // ---ADD 2022/06/20 ���O PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�--->>>>>
        // �u���E�U�t���O�u0:ie  1:edg�v
        private static int browserUseFlg;
        // �u���E�U����XML�t�@�C��
        private const string CUSTOMSIZESETTINGSFILE = "PMUOE01543A_BrowserSetting.xml";
        // IE�u���E�U
        private const string IELOCATIONSTR = @"%ProgramFiles%\Internet Explorer\iexplore.exe";
        // edge�u���E�U
        private const string MSEDGELOCATIONSTR = @"%ProgramFiles%\Microsoft\Edge\Application\msedge.exe";
        // ---ADD 2022/06/20 ���O PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�---<<<<<
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private MazdaOrderProcAcs()
        {
            this.OrderDataTable.Rows.Clear();

            this._uoeOrderInfoAcs = UoeOrderInfoAcs.GetInstance();

            this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();

            //�u���E�U�ݒ�XML�t�@�C���擾����
            this.GetBrowserSettingInfo(); // ADD 2022/06/20 ���O PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�
        }

        /// <summary>
        /// �t�n�d���������A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�t�n�d���������A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �t�n�d���������A�N�Z�X�N���X �C���X�^���X�擾���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public static MazdaOrderProcAcs GetInstance()
        {
            if (_supplierAcs == null)
            {
                _supplierAcs = new MazdaOrderProcAcs();
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private MazdaOrderProcDataSet DataSet
        {
            get
            {
                if (_dataSet == null)
                {
                    _dataSet = new MazdaOrderProcDataSet();
                }
                return _dataSet;
            }
        }
        /// <summary>
        /// �L�����͍s���ݔ���
        /// </summary>
        /// <returns>�s���݃`�F�b�N���ʁiTrue : �s���� / False : �s�Ȃ��j</returns>
        /// <remarks>
        /// <br>Note       : �L�����͍s���ݔ�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public bool StockRowExists()
        {
            if (this.OrderDataTable.Rows.Count > 0)
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public MazdaOrderProcDataSet.OrderExpansionDataTable OrderDataTable
        {
            get
            {
                if (_orderDataTable == null)
                {
                    _orderDataTable = this.DataSet.OrderExpansion;
                }
                return _orderDataTable;
            }
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void SelectedRow(int _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find ���\�b�h���g���A���AView�̃\�[�g����ύX�������Ȃ��ׁA //
            // DataTable�ɍX�V��������B                                   //
            // ------------------------------------------------------------//
            DataRow _row = this.OrderDataTable.Rows.Find(_uniqueID);

            // ��v����s�����݂���I
            if (_row != null)
            {
                _row.BeginEdit();
                _row[this.OrderDataTable.InpSelectColumn.ColumnName] = selected;
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private UOESendProcCndtnPara ToUOESendProcCndtnParaFromInpDisplay(MazdaInpDisplay inpDisplay)
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

        #region �w�b�_�[�����͒l�̕ۑ�����
        /// <summary>
        /// �w�b�_�[�����͒l�̕ۑ�����
        /// </summary>
        /// <param name="inpHedDisplay"> �w�b�_�[�����̓N���X</param>
        /// <remarks>
        /// <br>Note       : �w�b�_�[�����͒l�̕ۑ��������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void UpdtHedaerItem(MazdaInpHedDisplay inpHedDisplay)
        {
            DataView orderDataView = new DataView(this.OrderDataTable);

            string rowFilterString = "";

            //�I�����C���ԍ�
            rowFilterString = String.Format("{0} = {1}",
                                                    this.OrderDataTable.OnlineNoColumn.ColumnName, inpHedDisplay.OnlineNo);

            orderDataView.RowFilter = rowFilterString;

            for (int ix = 0; ix < orderDataView.Count; ix++)
            {
                MazdaOrderProcDataSet.OrderExpansionRow dataRow = (MazdaOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                
                dataRow[this.OrderDataTable.UoeRemark1Column.ColumnName] = inpHedDisplay.UoeRemark1;                    // �t�n�d���}�[�N�P

                dataRow[this.OrderDataTable.BoCodeColumn.ColumnName] = inpHedDisplay.UOEDeliGoodsDiv;                // �[�i�敪
                //dataRow[this.OrderDataTable.UOEDeliGoodsDivNmColumn.ColumnName] = inpHedDisplay.DeliveredGoodsDivNm;                // �[�i�敪����
                
            }

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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
        /// <br>              Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
        /// </remarks>
        public int SearchDB(MazdaInpDisplay inpDisplay, out string message)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            message = "";

            try
            {   //�O���b�h�p�e�[�u���̃N���A
                this.OrderDataTable.Rows.Clear();

                //�t�n�d�����f�[�^�������A�N�Z�X�N���X�Ăяo����
                _uOEOrderDtlWorkList = null;
                _stockDetailWorkList = null;

                UOESendProcCndtnPara para = ToUOESendProcCndtnParaFromInpDisplay(inpDisplay);

                status = _uoeOrderInfoAcs.Search(para, out _uOEOrderDtlWorkList, out _stockDetailWorkList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        return (status);
                    }
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        return (status);
                    }
                }

                int index = 1;

                //-----------------------------------------------------------
                // �t�n�d�����f�[�^�̊i�[
                //-----------------------------------------------------------
                foreach (UOEOrderDtlWork uOEOrderDtlWork in _uOEOrderDtlWorkList)
                {
                    MazdaOrderProcDataSet.OrderExpansionRow row = this.OrderDataTable.NewOrderExpansionRow();
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

                    row.UOEDeliGoodsDiv = uOEOrderDtlWork.UOEDeliGoodsDiv;
                    row.UOEResvdSection = uOEOrderDtlWork.UOEResvdSection;
                    row.FollowDeliGoodsDiv = uOEOrderDtlWork.FollowDeliGoodsDiv;
                    row.UOEDeliGoodsDivNm = uOEOrderDtlWork.DeliveredGoodsDivNm;
                    row.BoCode = uOEOrderDtlWork.BoCode;
                    row.WarehouseName = uOEOrderDtlWork.WarehouseName;// ADD wangyl 2013/02/06 Redmine#34578
                    this.OrderDataTable.AddOrderExpansionRow(row);
                }

                IsDataChanged = true;

            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        # endregion

        #region �t�n�d�����f�[�^�폜�����擾
        /// <summary>
        /// �t�n�d�����f�[�^�폜�����擾
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�폜�����擾���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int GetDeleteCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int GetNoSelectCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, false);
                count = orderDataView.Count;
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
        /// <param name="cashRegisterNo">�[���ԍ�</param>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE�����폜�f�[�^</param>
        /// <param name="stockDetailWorkDelList">�d�����׍폜�f�[�^</param>
        /// <param name="uOESupplier">UOE������}�X�^�̎���</param>//ADD BY ������ on 2011/12/02 for Redmine#8304
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�ۑ��������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        //--------DEL BY ������ on 2011/12/02 for Redmine#8304 ---------------->>>>>>>>>>>
        //public int WriteDB(int cashRegisterNo, int systemDiv, out string message,
        //       out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, 
        //       out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList)
        //--------DEL BY ������ on 2011/12/02 for Redmine#8304 ----------------<<<<<<<<<<<
        //--------ADD BY ������ on 2011/12/02 for Redmine#8304 ---------------->>>>>>>>>>>
        public int WriteDB(int cashRegisterNo, int systemDiv, out string message,
              out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList,
              out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList,
              ref UOESupplier uOESupplier)
        //--------ADD BY ������ on 2011/12/02 for Redmine#8304 ---------------->>>>>>>>>>>
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //�ۑ��f�[�^�擾����
                uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                stockDetailWorkList = new List<StockDetailWork>();

                uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
                stockDetailWorkDelList = new List<StockDetailWork>();

                status = GetUOEOrderDtlWorkFromRowData(1, cashRegisterNo, systemDiv, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkList == null && uOEOrderDtlWorkDelList == null) return (-1);
                if (uOEOrderDtlWorkList.Count == 0 && uOEOrderDtlWorkDelList.Count == 0) return (-1);

                // �V�X�e���敪���݌Ɉꊇ���A���ʂɂO��ݒ肳�ꂽ���ׂ��폜����
                if (uOEOrderDtlWorkDelList != null && uOEOrderDtlWorkDelList.Count > 0)
                {
                    status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);
                }
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                // �X�V
                if (uOEOrderDtlWorkList != null && uOEOrderDtlWorkList.Count > 0)
                {
                    status = _uoeOrderInfoAcs.WriteUOEOrderDtl(ref uOEOrderDtlWorkList, ref stockDetailWorkList, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);

                    // UOE�����f�[�^�𔭒��f�[�^�̃\�[�g���Ń\�[�g
                    uOEOrderDtlWorkList.Sort(new UOEOrderDtlWorkComparer());
                    // �}�c�_WebUOE�p�A�gURL���쐬���܂��B
                    string url = this.CreatUrl(uOEOrderDtlWorkList);
                    //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                    //�}�b�_�ۑ�url
                    System.IO.StreamWriter sw = null;
                    string timeFormat = "yyyyMMddHHmmss";
                    DateTime dt = DateTime.Now;
                    string startFileName = "MAZDA_";
                    string endFileName = ".SND";
                    try
                    {
                        sw = System.IO.File.CreateText(uOESupplier.AnswerSaveFolder + "\\" + startFileName + dt.ToString(timeFormat) + endFileName);
                        sw.WriteLine(url);
                        sw.Flush();
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                    }
                    finally
                    {
                        sw.Close();
                    }
                    //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ----------<<<<<<<<

                    // URL���쐬�����̂��A����URL���g�p���ău���E�U���N�����܂��B
                    //--- ADD 2022/06/20 ���O PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�--->>>>>
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
                    //--- ADD 2022/06/20 ���O PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�---<<<<<
                    //--- DEL 2022/06/20 ���O PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�--->>>>>
                    //string IELocation = @"%ProgramFiles%\Internet Explorer\iexplore.exe";
                    //IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);
                    //--- DEL 2022/06/20 ���O PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�---<<<<<
   
                    Process.Start(IELocation, url);
                }
            }
            catch (Exception ex)
            {
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
                uOEOrderDtlWorkDelList = null;
                stockDetailWorkDelList = null;
                message = ex.Message;
                return -1;
            }

            return status;
        }
        # endregion

        #region �I���f�[�^�̎擾����
        /// <summary>
        /// �I���f�[�^�̎擾����
        /// </summary>
        /// <param name="mode">0:�S�� 1:�ύX�f�[�^ 2:�I���f�[�^</param>
        /// <param name="cashRegisterNo">�[���ԍ�</param>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^�X�V�p���X�g</param>
        /// <param name="stockDetailWorkList">�d�����׍X�V�p���X�g</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE�����f�[�^�폜�p���X�g</param>
        /// <param name="stockDetailWorkDelList">�d�����׍폜�p���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I���f�[�^�̎擾�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int GetUOEOrderDtlWorkFromRowData(int mode, int cashRegisterNo, int systemDiv, 
                                                                out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList,
                                                                out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList, 
                                                                out string message)
        {
            // �ߒl
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();
            uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
            stockDetailWorkDelList = new List<StockDetailWork>();
            message = "";
            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    string key;
                    List<UOEOrderDtlWork> uOEresultList;
                    List<StockDetailWork> stockresultList;
                    UOEOrderDtlWork uOEOrderDtlWork = new UOEOrderDtlWork();

                    MazdaOrderProcDataSet.OrderExpansionRow dataRow = (MazdaOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                    uOEOrderDtlWork.EmployeeCode = _enterpriseCode;
                    uOEOrderDtlWork.OnlineNo = (Int32)dataRow[this.OrderDataTable.OnlineNoColumn.ColumnName];
                    uOEOrderDtlWork.OnlineRowNo = (Int32)dataRow[this.OrderDataTable.OnlineRowNoColumn.ColumnName];
                    uOEOrderDtlWork.UOEKind = (Int32)dataRow[this.OrderDataTable.UOEKindColumn.ColumnName];
                    uOEOrderDtlWork.CommonSeqNo = (Int64)dataRow[this.OrderDataTable.CommonSeqNoColumn.ColumnName];
                    uOEOrderDtlWork.SupplierFormal = (Int32)dataRow[this.OrderDataTable.SupplierFormalColumn.ColumnName];
                    uOEOrderDtlWork.StockSlipDtlNum = (Int64)dataRow[this.OrderDataTable.StockSlipDtlNumColumn.ColumnName];
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
                        if (mode == 1 && (systemDiv != 3
                              || 0 != double.Parse(dataRow[this.OrderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString())))
                        {
                            // ��M���t
                            uOEOrderDtlWorktemp.ReceiveDate = System.DateTime.Now;
                            // ���M�t���O
                            uOEOrderDtlWorktemp.DataSendCode = 1;
                            // �����t���O
                            uOEOrderDtlWorktemp.DataRecoverDiv = 0;
                            // ���M�[���ԍ�
                            uOEOrderDtlWorktemp.SendTerminalNo = cashRegisterNo;
                            // UOE���}�[�N1
                            uOEOrderDtlWorktemp.UoeRemark1 = dataRow[this.OrderDataTable.UoeRemark1Column.ColumnName].ToString();
                            //// �[�i�敪����
                            //uOEOrderDtlWorktemp.DeliveredGoodsDivNm = dataRow[this.OrderDataTable.UOEDeliGoodsDivNmColumn.ColumnName].ToString();
                            // BO�敪
                            uOEOrderDtlWorktemp.BoCode = dataRow[this.OrderDataTable.BoCodeColumn.ColumnName].ToString();
                            // UOE���}�[�N�Q
                            uOEOrderDtlWorktemp.UoeRemark2 = this._uOESupplier.HondaSectionCode.Trim().PadRight(3, ' ') + uOEOrderDtlWorktemp.SystemDivCd.ToString() + uOEOrderDtlWorktemp.OnlineNo.ToString("000000000").Substring(1, 8);
                            // �󒍐���
                            uOEOrderDtlWorktemp.AcceptAnOrderCnt = double.Parse(dataRow[this.OrderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString());
                            // �󒍐���
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
                    }
                }
            }
            catch (Exception ex)
            {
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
                uOEOrderDtlWorkDelList = null;
                stockDetailWorkDelList = null;
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
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
                List<UOEOrderDtlWork> uOEOrderDtlWorkDelList = null;
                List<StockDetailWork> stockDetailWorkDelList = null;

                status = GetUOEOrderDtlWorkFromRowData(2, 0, 0, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkDelList == null) return (-1);
                if (stockDetailWorkDelList.Count == 0) return (-1);

                status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private string MakeStockKey(string enterpriseCode, int supplierFormal, long stockSlipDtlNum)
        {
            // ���ׁE�sPrimary Key
            string key = enterpriseCode.ToString() + supplierFormal.ToString() + stockSlipDtlNum.ToString();
            return key;
        }
        #endregion Key�쐬

        # region �����A�gURL�̍쐬����
        /// <summary>
        /// �}�c�_WebUOE�p�����A�gURL�̍쐬
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <returns>url</returns>
        /// <remarks>
        /// <br>Note       : �}�c�_WebUOE�p�����A�gURL�̍쐬���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private string CreatUrl(List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            string url = string.Empty;
            url += "http://epc2.mazda.co.jp/epc/servlet/OrderInputInit";

            int index = 1;
            foreach (UOEOrderDtlWork uOEOrderDtlWork in uOEOrderDtlWorkList)
            {
                // BO�敪
                string bo = uOEOrderDtlWork.BoCode;
                // �R�����g
                string comment = uOEOrderDtlWork.UoeRemark1;
                // ���i�ԍ�
                // 2011/10/12 >>>
                //string noParts = uOEOrderDtlWork.GoodsNo;
                string noParts = uOEOrderDtlWork.GoodsNoNoneHyphen;
                // 2011/10/12 <<<
                // ����
                string suryo = uOEOrderDtlWork.AcceptAnOrderCnt.ToString();
                // �A�g��
                string uoeRemark2 = uOEOrderDtlWork.UoeRemark2;

                if (index == 1)
                {
                    url += "?bo=" + bo;
                    url += "&comment=" + comment;
                }

                url += "&no_parts=" + noParts;
                url += "&suryo=" + suryo;

                if (index == uOEOrderDtlWorkList.Count)
                {
                    url += "&no_parts=" + uoeRemark2;
                    url += "&suryo=1";
                }
                else if (index % 5 == 0)
                {
                    url += "&no_parts=" + uoeRemark2;
                    url += "&suryo=1";
                }

                index++;
            }

            return url;
        }
        # endregion

        # region -- ���X�g���̍쐬���� --
        /// <summary>
        /// �Ώ�UOE�����f�[�^��r�N���X(�I�����C���ԍ�(����)�A�C�����C���s�ԍ�(����)�AUOE�����ԍ�(����)�AUOE�����s�ԍ�(����))
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ώ�UOE�����f�[�^��r�N���X�B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private class UOEOrderDtlWorkComparer : Comparer<UOEOrderDtlWork>
        {
            /// <summary>
            /// ��r����
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare(UOEOrderDtlWork x, UOEOrderDtlWork y)
            {
                // �I�����C���ԍ� 
                int result = x.OnlineNo.CompareTo(y.OnlineNo);
                if (result != 0) return result;

                // �I�����C���s�ԍ�
                result = x.OnlineRowNo.CompareTo(y.OnlineRowNo);
                if (result != 0) return result;

                // UOE�����ԍ�
                result = x.UOESalesOrderNo.CompareTo(y.UOESalesOrderNo);
                if (result != 0) return result;

                // UOE�����s�ԍ�
                result = x.UOESalesOrderRowNo.CompareTo(y.UOESalesOrderRowNo);
                return result;
            }
        }
        # endregion

        //---ADD 2022/06/20 ���O PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�--->>>>>
        # region �u���E�U�ݒ�XML�t�@�C���擾����
        /// <summary>
        /// �u���E�U�ݒ�XML�t�@�C���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �u���E�U�ݒ�XML�t�@�C�����擾����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2022/06/20</br>
        /// </remarks>
        private void GetBrowserSettingInfo()
        {
            try
            {
                // 0:ie  1:edg
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
        # endregion
        //---ADD 2022/06/20 ���O PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�---<<<<<

        /// <summary>
        /// UOE������}�X�^�ݒ菈���i�v���O�����F0304�̂ݗp�j
        /// </summary>
        /// <param name="uOESupplier">UOE������}�X�^</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^�ݒ菈������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void SetUOESupplier(UOESupplier uOESupplier)
        {
            this._uOESupplier = uOESupplier;
        }
    }

    //---ADD 2022/06/20 ���O PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�--->>>>>
    # region �u���E�U�ݒ�N���X
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
    # endregion
    //---ADD 2022/06/20 ���O PMKOBETSU-4212 �}�c�_ e-parts���������@Edgi�Ή�---<<<<<
}
