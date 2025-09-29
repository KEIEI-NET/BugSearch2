//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �݌Ɉړ�����
// �v���O�����T�v   : �ړ��݌ɓ��͂̏����l�擾�f�[�^������s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20008 �ɓ� �L
// �� �� ��  2007/01/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� ���b
// �C �� ��  2007/09/25  �C�����e : ����.NS�p�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2008/07/14  �C�����e : Partsman�p�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/04  �C�����e : �ړ��f�[�^���_�Ǘ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �C �� ��  2010/06/10  �C�����e : �ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �O�� �L��
// �C �� ��  2012/07/05  �C�����e : �ړ����݌Ɏ����o�^�敪�ɂ�鐧���ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Xml.Serialization;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ړ��݌ɓ��͗p�����l�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ړ��݌ɓ��͂̏����l�擾�f�[�^������s���܂��B</br>
    /// <br>Programmer : 20008 �ɓ� �L</br>
    /// <br>Date       : 2007.01.26</br>
    /// <br>UpDate     : 2007.01.26 �ɓ� �L �V�K�쐬</br>
    /// <br>UpDate     : 2007.09.25 ��� ���b ����.NS�p�ɕύX</br>
    /// <br>UpDate     : 2008/07/14 �E �K�j Partsman�p�ɕύX</br>
    /// <br>           : 2009/06/04 �Ɠc �M�u�@�ړ��f�[�^���_�Ǘ��Ή�</br>
    /// </remarks>
    public class StockMoveInputInitDataAcs
    {
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private StockMoveInputInitDataAcs()
        {
            // �ϐ�������
            this._stockMoveHeader = new StockMoveHeader();
            this._stockMoveSlipSearchCond = new StockMoveSlipSearchCond();

            // �S���҃f�[�^
            this._EmployeeTable = new Hashtable();
            // ���_�f�[�^
            this._SectionTable = new Hashtable();
            // �q�Ƀf�[�^
            this._WareHouseTable = new Hashtable();

            // �S���҃A�N�Z�X�N���X
            this._employeeAcs = new EmployeeAcs();

            // ���Ӑ�(���_)�A�N�Z�X�N���X
            this._secInfoSetAcs = new SecInfoSetAcs();

            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            this._secInfoAcs = new SecInfoAcs();
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

            // �q�ɃA�N�Z�X�N���X
            this._warehouseAcs = new WarehouseAcs();

            // �݌ɑS�̐ݒ�}�X�^�A�N�Z�X�N���X
            this._stockMngTtlStAcs = new StockMngTtlStAcs();

            //// �O���X�f�[�^
            //this._GrossMap = new Hashtable();

            this._totalDayCalculator = TotalDayCalculator.GetInstance();
�@      }

        /// <summary>
        /// �݌Ɉړ��p�����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�d�����͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X</returns>
        public static StockMoveInputInitDataAcs GetInstance()
        {
            if (_stockSlipInputInitDataAcs == null)
            {
                _stockSlipInputInitDataAcs = new StockMoveInputInitDataAcs();
            }

            return _stockSlipInputInitDataAcs;
        }

        private static StockMoveInputInitDataAcs _stockSlipInputInitDataAcs;

        // �ړ��݌Ƀw�b�_�f�[�^
        private StockMoveHeader _stockMoveHeader;
        // �݌Ɉړ����������f�[�^
        private StockMoveSlipSearchCond _stockMoveSlipSearchCond;

        // �S���҃f�[�^
        private Hashtable _EmployeeTable;
        // ���_�f�[�^
        private Hashtable _SectionTable;
        // �q�Ƀf�[�^
        private Hashtable _WareHouseTable;

        // �O���X�f�[�^
        private Hashtable _GrossMap;

        // �X�V���[�h
        private int registMode = 0;

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        // �{�Ћ@�\�t���O
        private int _MainOfficeFuncFlag;
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        // �`�[��������I�����ꂽ�ꍇ��Ture
        private Boolean guideSelected = false;

        // �݌ɑS�̐ݒ�}�X�^�A�N�Z�X�N���X
        private StockMngTtlStAcs _stockMngTtlStAcs;

        // �݌ɑS�̐ݒ�}�X�^�f�[�^
        private StockMngTtlSt _stockMngTtlSt;

        /// <summary>�[���Ǘ��}�X�^�A�N�Z�X�N���X</summary>
        public PosTerminalMgAcs _posTerminalMgAcs = new PosTerminalMgAcs();

        /// <summary>�[���Ǘ��}�X�^�f�[�^�N���X</summary>
        public PosTerminalMg _posTerminalMg = new PosTerminalMg();

        // �S���҃A�N�Z�X�N���X
        EmployeeAcs _employeeAcs;

        // ���Ӑ�(���_)�A�N�Z�X�N���X
        SecInfoSetAcs _secInfoSetAcs;

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        SecInfoAcs _secInfoAcs;
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        // �q�ɃA�N�Z�X�N���X
        WarehouseAcs _warehouseAcs;

        // �����Z�o���W���[��
        private TotalDayCalculator _totalDayCalculator;

        // POSPC���ʋ敪
        private int _POSPCTermCd;

        # region Getter���\�b�h

        /// <summary>
        /// �X�V���[�h���̔���
        /// </summary>
        public int RegistMode
        {
            get { return registMode; }
            set { registMode = value; }
        }

        /// <summary>
        /// �K�C�h�ɂđI�����ꂽ���̃t���O
        /// </summary>
        public Boolean GuideSelected
        {
            get { return guideSelected; }
            set { guideSelected = value; }
        }

        /// <summary>
        /// �ړ��݌Ƀw�b�_�f�[�^�v���p�e�B
        /// </summary>
        public StockMoveHeader StockMoveHeader
        {
            get { return _stockMoveHeader; }
        }

        /// <summary>
        /// �ړ��݌Ɍ��������f�[�^
        /// </summary>
        public StockMoveSlipSearchCond StockMoveSlipSearchCond
        {
            get { return _stockMoveSlipSearchCond; }
        }

        /// <summary>
        /// �O���X�f�[�^�̏ڍ׃f�[�^�ꎞ�i�[�p
        /// </summary>
        public Hashtable GrossMap
        {
            get { return _GrossMap; }
            set { _GrossMap = value; }
        }

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �{�Ћ@�\���p�t���O
        /// </summary>
        public int MainOfficeFunc
        {
            get { return _MainOfficeFuncFlag; }
            set { _MainOfficeFuncFlag = value; }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        public StockMngTtlSt StockMngTtlSt  // FIXME:
        {
            get { return _stockMngTtlSt; }
        }

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �݌ɑS�̐ݒ�}�X�^(�݌ɊǗ��S�̐ݒ�Ǘ��R�[�h)
        /// </summary>
        public int StockMngTtlStCd
        {
            get { return _stockMngTtlSt.StockMngTtlStCd; }
        }

        /// <summary>
        /// �݌ɑS�̐ݒ�}�X�^(����݌ɋ��_�Ԉړ��敪)
        /// </summary>
        public int TrustStSectMoveCd
        {
            get { return _stockMngTtlSt.TrustStSectMoveCd; }
        }

        /// <summary>
        /// �݌ɑS�̐ݒ�}�X�^(����݌ɑq�Ɉړ��敪)
        /// </summary>
        public int TrustStWhouMoveCd
        {
            get { return _stockMngTtlSt.TrustStWhouMoveCd; }
        }

        /// <summary>
        /// �݌ɑS�̐ݒ�}�X�^(����݌Ɉϑ����敪)
        /// </summary>
        public int TrEntrustPermCd
        {
            get { return _stockMngTtlSt.TrEntrustPermCd; }
        }

        /// <summary>
        /// �݌ɑS�̐ݒ�}�X�^(�݌Ɉړ��m��敪)
        /// </summary>
        public int StockMoveFixCode
        {
            get { return _stockMngTtlSt.StockMoveFixCode; }
        }

        /// <summary>
        /// �݌ɑS�̐ݒ�}�X�^(�݌ɊǗ��L���敪�����\���l)
        /// </summary>
        public int StockMngExistCdDisp
        {
            get { return _stockMngTtlSt.StockMngExistCdDisp; }
        }

        /// <summary>
        /// �݌Ɏ����o�^
        /// </summary>
        public int AutoEntryStockCd
        {
            get { return _stockMngTtlSt.AutoEntryStockCd; }
        }

        /// <summary>
        /// �݌ɑS�̐ݒ�}�X�^(�œK�݌ɏ����敪)
        /// </summary>
        public int BeatStockCondCd
        {
            get { return _stockMngTtlSt.BeatStockCondCd; }
        }

        /// <summary>
        /// �݌ɑS�̐ݒ�}�X�^(�݌ɕ]�����@)
        /// </summary>
        public int StockPointWay
        {
            get { return _stockMngTtlSt.StockPointWay; }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        // ---ADD 2009/06/04 ----------------------------->>>>>
        /// <summary>
        /// �݌ɑS�̐ݒ�}�X�^(�݌Ɉړ��m��敪)
        /// </summary>
        public int StockMoveFixCode
        {
            get { return _stockMngTtlSt.StockMoveFixCode; }
        }
        // ---ADD 2009/06/04 -----------------------------<<<<<

        // --- ADD �O�� 2012/07/05 ---------->>>>>
        /// <summary>
        /// �݌ɑS�̐ݒ�}�X�^(�ړ����݌Ɏ����o�^�敪)
        /// </summary>
        public int MoveStockAutoInsDiv
        {
            get { return _stockMngTtlSt.MoveStockAutoInsDiv; }
        }
        // --- ADD �O�� 2012/07/05 ----------<<<<<

        /// <summary>
        /// POSPC���ʋ敪
        /// </summary>
        public int POSPCTermCd
        {
            get { return _POSPCTermCd; }
        }

        # endregion

        //private StockTtlSt _stockTtlSt;

        /// <summary>
        /// �����f�[�^�擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        public int ReadInitData(string enterpriseCode)
        {
            // �S���҃}�X�^
            ArrayList retEmpList;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //int statusEmp = _employeeAcs.Search(out retEmpList, LoginInfoAcquisition.EnterpriseCode);

            _EmployeeTable = new Hashtable();
            ArrayList retEmpList2;
            int statusEmp = _employeeAcs.Search( out retEmpList, out retEmpList2, LoginInfoAcquisition.EnterpriseCode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            if (statusEmp == 0)
            {
                foreach (Employee retEmp in retEmpList)
                {
                    if (retEmp.LogicalDeleteCode == 0)
                    {
                        _EmployeeTable.Add(retEmp.EmployeeCode.Trim(), retEmp.Name);
                    }
                }
            }

            // ���Ӑ�(���_)�}�X�^
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            ArrayList retSecList;

            int statusSec = _secInfoSetAcs.Search(out retSecList, LoginInfoAcquisition.EnterpriseCode);

            if (statusSec == 0)
            {
                foreach (SecInfoSet retSec in retSecList)
                {
                    _SectionTable.Add(retSec.SectionCode.Trim(), retSec.SectionGuideNm);
                }
            }
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            _SectionTable = new Hashtable();
            // DEL 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ---------->>>>>
            // FIXME:this._secInfoAcs.ResetSectionInfo();
            // DEL 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ----------<<<<<
            // ADD 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ---------->>>>>
            this._secInfoAcs = new SecInfoAcs();
            // ADD 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ----------<<<<<
            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._SectionTable.Add(secInfoSet.SectionCode.Trim(), secInfoSet.SectionGuideNm);
                }
            }
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

            // �q�Ƀ}�X�^
            _WareHouseTable = new Hashtable();
            ArrayList retWarehouseList;

            int statusWarehouse = _warehouseAcs.Search(out retWarehouseList, LoginInfoAcquisition.EnterpriseCode);

            if (statusWarehouse == 0)
            {
                foreach (Warehouse retWare in retWarehouseList)
                {
                    if (retWare.LogicalDeleteCode == 0)
                    {
                        // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
                        //_WareHouseTable.Add(retWare.SectionCode.Trim() + "_" + retWare.WarehouseCode.Trim(), retWare.WarehouseName);
                        _WareHouseTable.Add(retWare.WarehouseCode.Trim(), retWare.WarehouseName);
                        // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
                    }
                }
            }

            // �݌ɊǗ��S�̐ݒ�}�X�^
            StockMngTtlSt retStockMngTtlSt;

            int statusMngTtlSt = _stockMngTtlStAcs.Read(out retStockMngTtlSt, LoginInfoAcquisition.EnterpriseCode, 0);
            if (statusMngTtlSt == 0)
            {
                _stockMngTtlSt = retStockMngTtlSt;
            }

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            // �{�Ћ@�\���p�t���O
            SecInfoSet mainSec;

            int statusMain = _secInfoSetAcs.Read(out mainSec, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

            if (statusMain == 0)
            {
                _MainOfficeFuncFlag = mainSec.MainOfficeFuncFlag;
            }
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

#if false //..�ۗ� �[���Ǘ��f�[�^
            // �[���Ǘ��f�[�^�擾
            int posTerminalMgStatus = this._posTerminalMgAcs.Search(out this._posTerminalMg, LoginInfoAcquisition.EnterpriseCode);
            if ( posTerminalMgStatus == ( int ) ConstantManagement.DB_Status.ctDB_NORMAL || this._posTerminalMg == null ) {
                _POSPCTermCd = this._posTerminalMg.PosPCTermCd;
            }
#endif
            return 0;
        }

        public bool CheckHisTotalDayMonthly(string sectionCode, DateTime targetDate, out DateTime prevTotalDay)
        {
            int status;
            prevTotalDay = new DateTime();

            // �����Z�o���W���[���̃L���b�V���N���A
            this._totalDayCalculator.ClearCache();
            
            // ���|�I�v�V��������
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            if (ps == PurchaseStatus.Contract)
            {
                // ���|�I�v�V��������
                // ���㌎���������A�d�������������̌Â��N���擾
                this._totalDayCalculator.InitializeHisMonthly();
                status = this._totalDayCalculator.GetHisTotalDayMonthly(sectionCode, out prevTotalDay);
                if (prevTotalDay == DateTime.MinValue)
                {
                    // ���㌎���������擾
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode, out prevTotalDay);
                    if (prevTotalDay == DateTime.MinValue)
                    {
                        // �d�������������擾
                        status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay(sectionCode, out prevTotalDay);
                    }
                }
            }
            else
            {
                // ���|�I�v�V�����Ȃ�
                // ���㌎���������擾
                this._totalDayCalculator.InitializeHisMonthlyAccRec();
                status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode, out prevTotalDay);
            }

            if (status == 0)
            {
                if (prevTotalDay == DateTime.MinValue)
                {
                    return (true);
                }

                if (targetDate > prevTotalDay)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            else
            {
                return (true);
            }
        }

        public void ReadStockMngTtlSt()
        {

            ArrayList retList;

            int statusMngTtlSt = _stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (statusMngTtlSt == 0)
            {
                foreach (StockMngTtlSt stockMngTtlSt in retList)
                {
                    if ((stockMngTtlSt.LogicalDeleteCode == 0) && (stockMngTtlSt.SectionCode.Trim() == "00"))
                    {
                        _stockMngTtlSt = stockMngTtlSt;
                        break;
                    }
                }
            }
            else
            {
                _stockMngTtlSt = new StockMngTtlSt();
            }
        }

        /// <summary>
        /// �݌Ɉړ��w�b�_���N���A����
        /// </summary>
        public void StockMoveHeaderClear()
        {
            _stockMoveHeader.CreateDateTime = new DateTime();
            _stockMoveHeader.UpdateDateTime = new DateTime();
            _stockMoveHeader.EnterpriseCode = "";
            _stockMoveHeader.FileHeaderGuid = new Guid();
            _stockMoveHeader.UpdEmployeeCode = "";
            _stockMoveHeader.UpdAssemblyId1 = "";
            _stockMoveHeader.UpdAssemblyId2 = "";
            _stockMoveHeader.LogicalDeleteCode = 0;
            _stockMoveHeader.StockMvEmpCode = "";
            _stockMoveHeader.StockMvEmpName = "";
            _stockMoveHeader.ShipmentScdlDay = new DateTime();
            _stockMoveHeader.ShipmentFixDay = new DateTime();
            _stockMoveHeader.BfSectionCode = "";
            _stockMoveHeader.BfSectionGuideName = "";
            _stockMoveHeader.BfEnterWarehCode = "";
            _stockMoveHeader.BfEnterWarehName = "";
            _stockMoveHeader.AfSectionCode = "";
            _stockMoveHeader.AfSectionGuideName = "";
            _stockMoveHeader.AfEnterWarehCode = "";
            _stockMoveHeader.AfEnterWarehName = "";
            _stockMoveHeader.MoveSlipPrintDiv = false;
            _stockMoveHeader.ShipAgentCd = "";
            _stockMoveHeader.ShipAgentNm = "";
            _stockMoveHeader.ReceiveAgentCd = "";
            _stockMoveHeader.ReceiveAgentNm = "";
            _stockMoveHeader.ArrivalGoodsDay = new DateTime();
        }

        /// <summary>
        /// �݌Ɉړ������f�[�^���N���A����
        /// </summary>
        public void StockMoveSlipSearchCondClear()
        {
            _stockMoveSlipSearchCond.EnterpriseCode = "";
            _stockMoveSlipSearchCond.SectionCode = "";
            _stockMoveSlipSearchCond.StockMoveSlipNo = 0; 
            _stockMoveSlipSearchCond.StockMvEmpCode = "";
            _stockMoveSlipSearchCond.ShipAgentCd = "";
            _stockMoveSlipSearchCond.ReceiveAgentCd = "";
            _stockMoveSlipSearchCond.ShipmentScdlStDay = new DateTime();
            _stockMoveSlipSearchCond.ShipmentScdlEdDay = new DateTime();
            _stockMoveSlipSearchCond.ShipmentFixStDay = new DateTime();
            _stockMoveSlipSearchCond.ShipmentFixEdDay = new DateTime();
            _stockMoveSlipSearchCond.ArrivalGoodsStDay = new DateTime();
            _stockMoveSlipSearchCond.ArrivalGoodsEdDay = new DateTime();
            _stockMoveSlipSearchCond.BfSectionCode = "";
            _stockMoveSlipSearchCond.BfEnterWarehCode = "";
            _stockMoveSlipSearchCond.AfSectionCode = "";
            _stockMoveSlipSearchCond.AfEnterWarehCode = "";
            _stockMoveSlipSearchCond.MoveStatus = 0;
            _stockMoveSlipSearchCond.CellphoneModelCode = 0;
            _stockMoveSlipSearchCond.ProductNumber = "";
            _stockMoveSlipSearchCond.EnterpriseName = "";
            _stockMoveSlipSearchCond.ReceiveAgentNm = "";
            _stockMoveSlipSearchCond.CellphoneModelName = "";
        }

        # region �L���b�V���f�[�^����

        #region DEL 2008/07/14 Partsman�p�ɕύX
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �S���Җ��̎擾
        /// </summary>
        /// <param name="employeeCode">�S���҃R�[�h</param>
        /// <returns>�S���Җ���</returns>
        public string GetEmployeeName(string employeeCode)
        {
            Boolean containsFlg = _EmployeeTable.ContainsKey(employeeCode.Trim());

            if (containsFlg == true)
            {
                return (string)_EmployeeTable[employeeCode.Trim()];
            }
            else
            {
                //return null;
                return "";
            }
        }

        /// <summary>
        /// ���_���̎擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        public string GetSectionName(string sectionCode)
        {
            Boolean containsFlg = _SectionTable.ContainsKey(sectionCode.Trim());

            if (containsFlg == true)
            {
                return (string)_SectionTable[sectionCode.Trim()];
            }
            else
            {
                //return null;
                return "";
            }
        }

        /// <summary>
        /// �q�ɖ��̎擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns>�q�ɖ���</returns>
        public string GetWarehouseName(string sectionCode, string warehouseCode)
        {
            Boolean containsFlg = _WareHouseTable.ContainsKey(sectionCode.Trim() + "_" + warehouseCode.Trim());

            if (containsFlg == true)
            {
                return (string)_WareHouseTable[sectionCode.Trim() + "_" + warehouseCode.Trim()];
            }
            else
            {
                //return null;
                return "";
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman�p�ɕύX

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �S���Җ��̎擾
        /// </summary>
        /// <param name="employeeCode">�S���҃R�[�h</param>
        /// <returns>�S���Җ���</returns>
        public string GetEmployeeName(string employeeCode)
        {
            string employeeName = "";

            if (this._EmployeeTable.ContainsKey(employeeCode.Trim().PadLeft(4, '0')))
            {
                employeeName = (string)this._EmployeeTable[employeeCode.Trim().PadLeft(4, '0')];
            }

            return employeeName;
        }

        /// <summary>
        /// ���_���̎擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._SectionTable.ContainsKey(sectionCode.Trim().PadLeft(2, '0')))
            {
                sectionName = (string)this._SectionTable[sectionCode.Trim().PadLeft(2, '0')];
            }

            return sectionName;
        }

        /// <summary>
        /// �q�ɖ��̎擾
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns>�q�ɖ���</returns>
        public string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            if (this._WareHouseTable.ContainsKey(warehouseCode.Trim().PadLeft(4, '0')))
            {
                warehouseName = (string)this._WareHouseTable[warehouseCode.Trim().PadLeft(4, '0')];
            }

            return warehouseName;
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        # endregion

        #region DEL 2008/07/14 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ����������
        /// </summary>
        public void Clear()
        {
            this.StockMoveHeaderClear();
            this.StockMoveSlipSearchCondClear();

            this.GrossMap.Clear();
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        // ADD 2010/06/09 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ---------->>>>>
        /// <summary>�ݒ��ۑ�����t�@�C����</summary>
        private const string FILE_NAME = "UISetting_MAZAI04122A.xml";
        /// <summary>�ݒ��ۑ�����t�@�C�������擾���܂��B</summary>
        private static string FileName { get { return FILE_NAME; } }

        /// <summary>
        /// �ݒ��ۑ�����f�B���N�g���p�X���擾���܂��B
        /// </summary>
        private static string DirPath
        {
            get
            {
                string dirPath = Path.Combine(Environment.CurrentDirectory, "UISettings");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                return dirPath;
            }
        }

        /// <summary>
        /// ���[�U�[�ݒ��ۑ����܂��B
        /// </summary>
        /// <param name="userCustomSetting">���[�U�[�ݒ�</param>
        public static void SaveUserCustomSetting(UserCustomSetting userCustomSetting)
        {
            #region Guard Phrase

            if (userCustomSetting == null) return;

            #endregion // Guard Phrase

            FileStream fileStream = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserCustomSetting));
                fileStream = new FileStream(Path.Combine(DirPath, FileName), FileMode.Create);
                serializer.Serialize(fileStream, userCustomSetting);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }
        }

        /// <summary>
        /// ���[�U�[�ݒ����荞�݂܂��B
        /// </summary>
        /// <returns>�ۑ�����Ă��郆�[�U�[�ݒ�̓��e</returns>
        public static UserCustomSetting LoadUserCustomSetting()
        {
            UserCustomSetting userCustomSetting = null;

            FileStream fileStream = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserCustomSetting));
                fileStream = new FileStream(Path.Combine(DirPath, FileName), FileMode.Open);
                userCustomSetting = (UserCustomSetting)serializer.Deserialize(fileStream);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }

            return userCustomSetting ?? new UserCustomSetting();
        }
        // ADD 2010/06/09 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ----------<<<<<
    }

    // ADD 2010/06/09 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ---------->>>>>
    /// <summary>
    /// ���[�U�[�ݒ�N���X
    /// </summary>
    [Serializable]
    public sealed class UserCustomSetting
    {
        /// <summary>�ړ��`�[��[���s����]�t���O</summary>
        private bool _printsSlip;
        /// <summary>�ړ��`�[��[���s����]�t���O���擾�܂��͐ݒ肵�܂��B</summary>
        public bool PrintsSlip
        {
            get { return _printsSlip; }
            set { _printsSlip = value; }
        }

        #region Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UserCustomSetting(): this(true) { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="printsSlip">�ړ��`�[��[���s����]�t���O</param>
        public UserCustomSetting(bool printsSlip)
        {
            _printsSlip = printsSlip;
        }

        #endregion // Constructor
    }
    // ADD 2010/06/09 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ----------<<<<<
}
