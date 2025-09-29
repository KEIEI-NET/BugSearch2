//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ����ڕW�ݒ�}�X�^
// �v���O�����T�v   : ����ڕW�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �� �� ��  2008/10/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/20  �C�����e : MANTIS�y13308�z�d���I�y���[�V�����G���[�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/29  �C�����e : MANTIS�y13352�z�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2010/12/20  �C�����e : ��Q���ǑΉ��P�Q��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10704766-00  �쐬�S�� : wangf
// �� �� ��  2011/07/18  �C�����e : ��Q���ǑΉ��A��818
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using System.Collections;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ����ڕW�ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����ڕW�ݒ�t�H�[���N���X</br>
    /// <br>Programmer : 30414 �E �K�j</br>
    /// <br>Date       : 2008/10/08</br>
    /// <br>Update Note: 2010/12/20 ������</br>
    /// <br>             ��Q���ǑΉ��P�Q��</br>
    /// </remarks>
    public partial class PMKHN09251UA : Form, ISalesTargetMDIChild
    {
        #region �� Constants

        private const string ASSEMBLY_ID = "PMKHN09251U";

        private const string COLUMN_MONTH = "Month";
        private const string COLUMN_RATIO = "Ratio";
        private const string COLUMN_SALESTARGET = "SalesTarget";
        private const string COLUMN_PROFITTARGET = "ProfitTarget";
        private const string COLUMN_COUNTTARGET = "CountTarget";

        private const string FORMAT_NUM = "###,###";

        private const string INSERT_MODE = "�V�K";
        private const string UPDATE_MODE = "�X�V";
        private const string DELETE_MODE = "�폜";

        #endregion �� Constants


        #region �� Private Members

        private bool _isClose;
        private bool _isSave;
        private bool _isNew;
        private bool _isRevival;
        private bool _isLogicalDelete;
        private bool _isDelete;
        private bool _isUndo;
        private bool _isCalc;
        private bool _isRenewal;

        private string _enterpriseCode;                     // ��ƃR�[�h

        private bool _cusotmerGuideSelected;                // ���Ӑ�K�C�h�I���t���O

        private List<DateTime> _startMonthDateList;         // �N���x�J�n�����X�g
        private List<DateTime> _endMonthDateList;           // �N���x�I�������X�g
        private List<DateTime> _yearMonthList;              // �N���x���X�g
        private int _year;                                  // ��v�N�x
        private int _thisYear;                              // ���N�x

        private SalesTargetAcs _salesTargetAcs;
        private SecInfoAcs _secInfoAcs;
        private SecInfoSetAcs _secInfoSetAcs;
        private SubSectionAcs _subSectionAcs;
        private CustomerInfoAcs _customerInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;
        private EmployeeAcs _employeeAcs;
        private UserGuideAcs _userGuideAcs;
        private DateGetAcs _dateGetAcs;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, SubSection> _subSectionDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Dictionary<string, Employee> _employeeDic;
        private Dictionary<int, string> _salesAreaDic;
        private Dictionary<int, string> _businessTypeDic;
        private Dictionary<int, string> _salesCodeDic;
        private Dictionary<int, string> _enterpriseGanreDic;

        private Dictionary<string, EmpSalesTarget> _empSalesTargetDicClone;
        private Dictionary<string, CustSalesTarget> _custSalesTargetDicClone;
        private Dictionary<string, GcdSalesTarget> _gcdSalesTargetDicClone;

        private bool _searchFlg;

        private int _prevYear;
        private int _prevTargetContrastCd;
        private string _prevSectionCode;
        private int _prevSubSectionCode;
        private int _prevCustomerCode;
        private string _prevEmployeeCode;
        private int _prevSalesAreaCode;
        private int _prevBusinessTypeCode;
        private int _prevSalesCode;
        private int _prevEnterpriseGanreCode;

        #endregion �� Private Members


        #region �� Constructor

        /// <summary>
        /// ����ڕW�ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�t�H�[���N���X</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public PMKHN09251UA()
        {
            InitializeComponent();

            this._isClose = true;
            this._isSave = true;
            this._isNew = true;
            this._isRevival = false;
            this._isLogicalDelete = false;
            this._isDelete = false;
            this._isUndo = true;
            this._isCalc = true;
            this._isRenewal = true;

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �e��A�N�Z�X�N���X�C���X�^���X����
            this._salesTargetAcs = new SalesTargetAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._subSectionAcs = new SubSectionAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._employeeAcs = new EmployeeAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._dateGetAcs = DateGetAcs.GetInstance();

            this._empSalesTargetDicClone = new Dictionary<string, EmpSalesTarget>();
            this._custSalesTargetDicClone = new Dictionary<string, CustSalesTarget>();
            this._gcdSalesTargetDicClone = new Dictionary<string, GcdSalesTarget>();

            // �e��}�X�^�擾
            bool bStatus = ReadMaster();
            if (!bStatus)
            {
                return;
            }

            // ��v�N�x���擾
            GetFinancialYearTable(0);
        }

        #endregion �� Constructor


        #region �� ISalesTargetMDIChild �����o

        /// <summary> �c�[���o�[Visible����C�x���g </summary>
        public event ParentToolbarSalesTargetEventHandler ParentToolbarSalesTargetEvent;

        /// <summary> �I���{�^��Visible�v���p�e�B </summary>
        public bool IsClose
        {
            get { return this._isClose; }
        }

        /// <summary> �ۑ��{�^��Visible�v���p�e�B </summary>
        public bool IsSave
        {
            get { return this._isSave; }
        }

        /// <summary> �V�K�{�^��Visible�v���p�e�B </summary>
        public bool IsNew
        {
            get { return this._isNew; }
        }

        /// <summary> �����{�^��Visible�v���p�e�B </summary>
        public bool IsRevival
        {
            get { return this._isRevival; }
        }

        /// <summary> �_���폜�{�^��Visible�v���p�e�B </summary>
        public bool IsLogicalDelete
        {
            get { return this._isLogicalDelete; }
        }

        /// <summary> ���S�폜�{�^��Visible�v���p�e�B </summary>
        public bool IsDelete
        {
            get { return this._isDelete; }
        }

        /// <summary> ���ɖ߂��{�^��Visible�v���p�e�B </summary>
        public bool IsUndo
        {
            get { return this._isUndo; }
        }

        /// <summary> �䗦����v�Z�{�^��Visible�v���p�e�B </summary>
        public bool IsCalc
        {
            get { return this._isCalc; }
        }

        /// <summary> �ŐV���{�^��Visible�v���p�e�B </summary>
        public bool IsRenewal
        {
            get { return this._isRenewal; }
        }

        /// <summary>
        /// �I���O����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I���O�������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int BeforeClose()
        {
            DialogResult result = DialogResult.No;

            // ��ʏ�ԕύX�`�F�b�N
            bool bStatus = CompareInputScreen();
            if (!bStatus)
            {
                result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                        "",
                                        0,
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxDefaultButton.Button2);
            }

            switch (result)
            {
                case DialogResult.Yes:
                    {
                        // �ۑ�����
                        int status = SaveProc();
                        if (status != 0)
                        {
                            return (status);
                        }

                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        return -1;
                    }
            }

            return 0;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Save()
        {
            return SaveProc();
        }

        /// <summary>
        /// �V�K����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �V�K�������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int New()
        {
            DialogResult result = DialogResult.No;

            // ��ʏ�ԕύX�`�F�b�N
            bool bStatus = CompareInputScreen();
            if (!bStatus)
            {
                result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                        "",
                                        0,
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxDefaultButton.Button2);
            }

            switch (result)
            {
                case DialogResult.Yes:
                    {
                        // �ۑ�����
                        int status = SaveProc();
                        if (status != 0)
                        {
                            return (status);
                        }

                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        return 0;
                    }
            }

            // ��ʏ���������
            ClearScreen();

            SetControlEnabled(INSERT_MODE);

            // �����R���g���[��Enabled����
            ChangeTargetContrastControl(10);

            // �t�H�[�J�X�ݒ�
            this.tNedit_Year.Focus();

            return 0;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Revival()
        {
            int statsu = RevivalProc();
            if (statsu == 0)
            {
                // �t�H�[�J�X�ݒ�
                this.tNedit_SalesTargetSale.Focus();
            }

            return (statsu);
        }

        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int LogicalDelete()
        {
            // �_���폜�m�F
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                 "�f�[�^��_���폜���܂��B\r\n��낵���ł����H",
                                                 0,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Cancel)
            {
                return 0;
            }

            return LogicalDeleteProc();
        }

        /// <summary>
        /// �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����폜�������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Delete()
        {
            // ���S�폜�m�F
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                 "�f�[�^�𕨗��폜���܂��B\r\n��낵���ł����H",
                                                 0,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Cancel)
            {
                return 0;
            }

            return DeleteProc();
        }

        /// <summary>
        /// ���ɖ߂�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���ɖ߂��������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Undo()
        {
            return UndoProc();
        }

        /// <summary>
        /// �䗦����v�Z����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �䗦����v�Z�������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Calc()
        {
            return CalcProc();
        }

        /// <summary>
        /// �ŐV���擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ŐV�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Renewal()
        {
            return RenewalProc();
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public void SetFocus()
        {
            this.tNedit_Year.Focus();
        }

        #endregion �� ISalesTargetMDIChild �����o


        #region �� Private Methods

        #region �}�X�^�Ǎ�
        /// <summary>
        /// �e��}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:�ُ�)</returns>
        /// <remarks>
        /// <br>Note       : �e��}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool ReadMaster()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string errMsg = "";

            try
            {
                // ���_
                status = ReadSecInfoSet();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "���_�}�X�^�̓Ǎ��Ɏ��s���܂����B";
                        return (false);
                }

                // ����
                status = ReadSubSection();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "����}�X�^�̓Ǎ��Ɏ��s���܂����B";
                        return (false);
                }

                // ���Ӑ�
                status = ReadCustomer();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "���Ӑ�}�X�^�̓Ǎ��Ɏ��s���܂����B";
                        return (false);
                }

                // �]�ƈ�
                status = ReadEmployee();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "�]�ƈ��}�X�^�̓Ǎ��Ɏ��s���܂����B";
                        return (false);
                }

                // �n��
                status = ReadSalesArea();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "�n����̎擾�Ɏ��s���܂����B";
                        return (false);
                }

                // �Ǝ�
                status = ReadBusinessType();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "�Ǝ���̎擾�Ɏ��s���܂����B";
                        return (false);
                }

                // �̔��敪
                status = ReadSalesCode();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "�̔��敪���̎擾�Ɏ��s���܂����B";
                        return (false);
                }

                // ���i�敪
                status = ReadEnterpriseGanre();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "���i�敪���̎擾�Ɏ��s���܂����B";
                        return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(this,
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                  this.Name,
                                  errMsg,
                                  status,
                                  MessageBoxButtons.OK);
                }
            }

            return (true);
        }

        /// <summary>
        /// ���_�}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���_�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            this._secInfoAcs.ResetSectionInfo();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// ����}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadSubSection()
        {
            this._subSectionDic = new Dictionary<int, SubSection>();

            try
            {
                ArrayList retList;

                int status = this._subSectionAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (SubSection subSection in retList)
                    {
                        if (subSection.LogicalDeleteCode == 0)
                        {
                            this._subSectionDic.Add(subSection.SubSectionCode, subSection);
                        }
                    }
                }
            }
            catch
            {
                this._subSectionDic = new Dictionary<int, SubSection>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadCustomer()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                CustomerSearchRet[] retArray;
                
                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet customerSearchRet in retArray)
                    {
                        if (customerSearchRet.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(customerSearchRet.CustomerCode, customerSearchRet);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// �]�ƈ��}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadEmployee()
        {
            this._employeeDic = new Dictionary<string, Employee>();

            try
            {
                ArrayList retList;
                ArrayList retList2;

                int status = this._employeeAcs.SearchAll(out retList, out retList2, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Employee employee in retList)
                    {
                        if (employee.LogicalDeleteCode == 0)
                        {
                            this._employeeDic.Add(employee.EmployeeCode.Trim(), employee);
                        }
                    }
                }
            }
            catch
            {
                this._employeeDic = new Dictionary<string, Employee>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// �n��}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �n��}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadSalesArea()
        {
            this._salesAreaDic = new Dictionary<int, string>();

            return ReadUserGdBd(21, ref this._salesAreaDic);
        }

        /// <summary>
        /// �Ǝ�}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ǝ�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadBusinessType()
        {
            this._businessTypeDic = new Dictionary<int, string>();

            return ReadUserGdBd(33, ref this._businessTypeDic);
        }

        /// <summary>
        /// �̔��敪�}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �̔��敪�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadSalesCode()
        {
            this._salesCodeDic = new Dictionary<int, string>();

            return ReadUserGdBd(71, ref this._salesCodeDic);
        }

        /// <summary>
        /// ���i�敪�}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�敪�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadEnterpriseGanre()
        {
            this._enterpriseGanreDic = new Dictionary<int, string>();

            return ReadUserGdBd(41, ref this._enterpriseGanreDic);
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�Ǎ�����
        /// </summary>
        /// <param name="userGuideDivCd">�K�C�h�敪</param>
        /// <param name="targetDic">�Ώ�Dictionary</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadUserGdBd(int userGuideDivCd, ref Dictionary<int, string> targetDic)
        {
            try
            {
                ArrayList retList;

                int status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                                     userGuideDivCd, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            targetDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                        }
                    }
                }
            }
            catch
            {
                targetDic = new Dictionary<int, string>();
                return -1;
            }

            return 0;
        }
        #endregion �}�X�^�Ǎ�

        #region ���̎擾
        /// <summary>
        /// ���_���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <remarks>
        /// <br>Note       : ���_�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// ���喼�擾����
        /// </summary>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <returns>���喼</returns>
        /// <remarks>
        /// <br>Note       : ���喼���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetSubSectionName(int subSectionCode)
        {
            string subSectionName = "";

            if (this._subSectionDic.ContainsKey(subSectionCode))
            {
                subSectionName = this._subSectionDic[subSectionCode].SubSectionName.Trim();
            }

            return subSectionName;
        }

        /// <summary>
        /// ���Ӑ於�擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ於���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                customerName = this._customerSearchRetDic[customerCode].Snm.Trim();
            }

            return customerName;
        }

        /// <summary>
        /// �]�ƈ����擾����
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ���</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ������擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetEmployeeName(string employeeCode)
        {
            string employeeName = "";

            if (this._employeeDic.ContainsKey(employeeCode.Trim()))
            {
                employeeName = this._employeeDic[employeeCode].Name.Trim();
            }

            return employeeName;
        }

        /// <summary>
        /// �n�於�擾����
        /// </summary>
        /// <param name="salesAreaCode">�n��R�[�h</param>
        /// <returns>�n�於</returns>
        /// <remarks>
        /// <br>Note       : �n�於���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetSalesAreaName(int salesAreaCode)
        {
            string salesAreaName = "";

            if (this._salesAreaDic.ContainsKey(salesAreaCode))
            {
                salesAreaName = this._salesAreaDic[salesAreaCode].Trim();
            }

            return salesAreaName;
        }

        /// <summary>
        /// �Ǝ햼�擾����
        /// </summary>
        /// <param name="businessTypeCode">�Ǝ�R�[�h</param>
        /// <returns>�Ǝ햼</returns>
        /// <remarks>
        /// <br>Note       : �Ǝ햼���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetBusinessTypeName(int businessTypeCode)
        {
            string businessTypeName = "";

            if (this._businessTypeDic.ContainsKey(businessTypeCode))
            {
                businessTypeName = this._businessTypeDic[businessTypeCode].Trim();
            }

            return businessTypeName;
        }

        /// <summary>
        /// �̔��敪���擾����
        /// </summary>
        /// <param name="salesCode">�̔��敪�R�[�h</param>
        /// <returns>�̔��敪��</returns>
        /// <remarks>
        /// <br>Note       : �̔��敪�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetSalesCodeName(int salesCode)
        {
            string salesCodeName = "";

            if (this._salesCodeDic.ContainsKey(salesCode))
            {
                salesCodeName = this._salesCodeDic[salesCode].Trim();
            }

            return salesCodeName;
        }

        /// <summary>
        /// ���i�敪���擾����
        /// </summary>
        /// <param name="enterpriseGanreCode">���i�敪�R�[�h</param>
        /// <returns>���i�敪��</returns>
        /// <remarks>
        /// <br>Note       : ���i�敪�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetEnterpriseGanreName(int enterpriseGanreCode)
        {
            string enterpriseGanreName = "";

            if (this._enterpriseGanreDic.ContainsKey(enterpriseGanreCode))
            {
                enterpriseGanreName = this._enterpriseGanreDic[enterpriseGanreCode].Trim();
            }

            return enterpriseGanreName;
        }
        #endregion ���̎擾

        // ADD 2009/06/29 ------>>>
        #region �}�X�^���݃`�F�b�N
        /// <summary>
        /// ���Ӑ摶�݃`�F�b�N����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>true�FOK�Afalse�FNG</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ悪���݂��邩�`�F�b�N���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool CheckCustomer(int customerCode)
        {
            bool check = false;

            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    check = true;
                }
            }
            catch
            {
                check = false;
            }

            return check;
        }
        #endregion �}�X�^���݃`�F�b�N
        // ADD 2009/06/29 ------<<<
        
        #region ��v�N�x�e�[�u���擾
        /// <summary>
        /// ��v�N�x�e�[�u���擾����
        /// </summary>
        /// <param name="addYearFromThis">���N����̍���</param>
        /// <remarks>
        /// <br>Note       : ��v�N�x�e�[�u�����擾���A��v�N�x�����o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void GetFinancialYearTable(int addYearFromThis)
        {
            try
            {
                this._dateGetAcs.GetFinancialYearTable(addYearFromThis,
                                                       out this._startMonthDateList,
                                                       out this._endMonthDateList,
                                                       out this._yearMonthList,
                                                       out this._year);
                if (addYearFromThis == 0)
                {
                    this._thisYear = this._year;
                }
            }
            catch
            {
                this._startMonthDateList = new List<DateTime>();
                this._endMonthDateList = new List<DateTime>();
                this._yearMonthList = new List<DateTime>();
                this._year = 0;
            }
        }
        #endregion ��v�N�x�e�[�u���擾

        #region ��ʏ�����
        /// <summary>
        /// ��ʏ�񏉊�������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ClearScreen()
        {
            this.tNedit_Year.SetInt(this._thisYear);
            this.tComboEditor_TargetContrastCd.Value = 10;
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tNedit_SubSectionCode.Clear();
            this.tEdit_SubSectionName.Clear();
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Clear();
            this.tEdit_EmployeeCode.Clear();
            this.tEdit_EmployeeName.Clear();
            this.tNedit_SalesAreaCode.Clear();
            this.tEdit_SalesAreaName.Clear();
            this.tNedit_BusinessTypeCode.Clear();
            this.tEdit_BusinessTypeName.Clear();
            this.tNedit_SalesCode.Clear();
            this.tEdit_SalesCodeName.Clear();
            this.tNedit_EnterpriseGanreCode.Clear();
            this.tEdit_EnterpriseGanreName.Clear();

            ClearGrid();

            this.Mode_Label.Text = INSERT_MODE;

            this._searchFlg = false;

            // 2011.07.18 wangf del start
            // �V�K�ȂǏ�����őO�񌟍��̔N���������K�v�͂Ȃ��A�t�H�[�J�X�ړ����O�񌟍��̔N�����X�V���Ă̂ŁB
            // �����ŁA�������Ȃ�΁A���S�폜��ŁA�V�K���A�O�񌟍��N���擾�ł��Ȃ��B
            //this._prevYear = this._thisYear;
            // 2011.07.18 wangf del end
            this._prevTargetContrastCd = 10;
            this._prevSectionCode = "";
            this._prevSubSectionCode = 0;
            this._prevCustomerCode = 0;
            this._prevEmployeeCode = "";
            this._prevSalesAreaCode = 0;
            this._prevBusinessTypeCode = 0;
            this._prevSalesCode = 0;
            this._prevEnterpriseGanreCode = 0;
        }

        /// <summary>
        /// �O���b�h����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�������������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ClearGrid()
        {
            this.tNedit_SalesTargetSale.Clear();
            this.tNedit_SalesTargetProfit.Clear();
            this.tNedit_SalesTargetCount.Clear();

            for (int index = 0; index < 13; index++)
            {
                if (index != 12)
                {
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_MONTH].Value = this._yearMonthList[index].Month.ToString("00");
                }
                else
                {
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_MONTH].Value = "�v";
                }
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_RATIO].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            this._empSalesTargetDicClone.Clear();
            this._custSalesTargetDicClone.Clear();
            this._gcdSalesTargetDicClone.Clear();
        }
        #endregion ��ʏ�����

        #region ��ʐݒ�
        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���T�C�Y��ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tNedit_Year.Size = new Size(51, 24);
            this.tEdit_SectionCode.Size = new Size(74, 24);
            this.tEdit_SectionName.Size = new Size(315, 24);
            this.tNedit_SubSectionCode.Size = new Size(74, 24);
            this.tEdit_SubSectionName.Size = new Size(315, 24);
            this.tNedit_CustomerCode.Size = new Size(74, 24);
            this.tEdit_CustomerName.Size = new Size(315, 24);
            this.tEdit_EmployeeCode.Size = new Size(74, 24);
            this.tEdit_EmployeeName.Size = new Size(315, 24);
            this.tNedit_SalesAreaCode.Size = new Size(74, 24);
            this.tEdit_SalesAreaName.Size = new Size(315, 24);
            this.tNedit_BusinessTypeCode.Size = new Size(74, 24);
            this.tEdit_BusinessTypeName.Size = new Size(315, 24);
            this.tNedit_SalesCode.Size = new Size(74, 24);
            this.tEdit_SalesCodeName.Size = new Size(315, 24);
            this.tNedit_EnterpriseGanreCode.Size = new Size(74, 24);
            this.tEdit_EnterpriseGanreName.Size = new Size(315, 24);
            
            this.tNedit_SalesTargetSale.Size = new Size(139, 24);
            this.tNedit_SalesTargetProfit.Size = new Size(139, 24);
            this.tNedit_SalesTargetCount.Size = new Size(115, 24);

            this.tEdit_TargetContrastCd10.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd20.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd30.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd22_1.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd22_2.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd22_3.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd31.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd32.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd44.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd45.Size = new Size(144, 24);
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();

            // -----------------------------
            // �{�^���A�C�R���ݒ�
            // -----------------------------
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SubSectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EmployeeGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SalesAreaGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BusinessTypeGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SalesCodeGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EnterpriseGanreGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // -----------------------------
            // �O���b�h�ݒ�
            // -----------------------------
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(COLUMN_MONTH, typeof(string));
            dataTable.Columns.Add(COLUMN_RATIO, typeof(string));
            dataTable.Columns.Add(COLUMN_SALESTARGET, typeof(string));
            dataTable.Columns.Add(COLUMN_PROFITTARGET, typeof(string));
            dataTable.Columns.Add(COLUMN_COUNTTARGET, typeof(string));

            for (int index = 0; index < 13; index++)
            {
                DataRow dataRow;
                dataRow = dataTable.NewRow();

                if (index != 12)
                {
                    dataRow[COLUMN_MONTH] = this._yearMonthList[index].Month.ToString("00");
                }
                else
                {
                    dataRow[COLUMN_MONTH] = "�v";
                }
                dataRow[COLUMN_RATIO] = "";
                dataRow[COLUMN_SALESTARGET] = "";
                dataRow[COLUMN_PROFITTARGET] = "";
                dataRow[COLUMN_COUNTTARGET] = "";
                dataTable.Rows.Add(dataRow);
            }

            this.SalesTarget_uGrid.DataSource = dataTable;

            // �L���v�V����
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Caption = "��";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].Header.Caption = "���ʔ䗦";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Caption = "����ڕW";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Caption = "�e���ڕW";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Caption = "���ʖڕW";

            // ��
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Width = 33;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].Width = 73;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Width = 140;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Width = 140;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Width = 110;

            // TextHAlign(�w�b�_�[)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.TextHAlign = HAlign.Center;

            // TextHAlign(�Z��)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].CellAppearance.TextHAlign = HAlign.Right;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.TextHAlign = HAlign.Right;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.TextHAlign = HAlign.Right;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.TextHAlign = HAlign.Right;

            // TextVAlign(�w�b�_�[)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.TextVAlign = VAlign.Middle;

            // TextVAlign(�Z��)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.TextVAlign = VAlign.Middle;

            // ForeColor(�w�b�_�[)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.ForeColorDisabled = Color.White;

            // ForeColor(�Z��)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].CellAppearance.ForeColorDisabled = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.ForeColorDisabled = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.ForeColorDisabled = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.ForeColorDisabled = Color.Black;

            // ��ݒ�(��)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.ForeColorDisabled = Color.White;

            // �s�ݒ�(�v)
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_RATIO].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_RATIO].Appearance.BackColorDisabled = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Appearance.BackColorDisabled = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Appearance.BackColorDisabled = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Appearance.BackColorDisabled = Color.Gainsboro;

            // Activation
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellActivation = Activation.Disabled;
            this.SalesTarget_uGrid.Rows[12].Activation = Activation.Disabled;
        }
        #endregion ��ʐݒ�

        #region �R���g���[��Enabled����
        /// <summary>
        /// �ݒ�敪�����R���g���[��Enabled���䏈��
        /// </summary>
        /// <param name="targetContrastCd">�ݒ�敪�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �ݒ�敪�̒l�ɂ���ăR���g���[���̐�����s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ChangeTargetContrastControl(int targetContrastCd)
        {
            this.tEdit_SectionCode.Enabled = false;
            this.SectionGuide_Button.Enabled = false;
            this.tNedit_SubSectionCode.Enabled = false;
            this.SubSectionGuide_Button.Enabled = false;
            this.tNedit_CustomerCode.Enabled = false;
            this.CustomerGuide_Button.Enabled = false;
            this.tEdit_EmployeeCode.Enabled = false;
            this.EmployeeGuide_Button.Enabled = false;
            this.tNedit_SalesAreaCode.Enabled = false;
            this.SalesAreaGuide_Button.Enabled = false;
            this.tNedit_BusinessTypeCode.Enabled = false;
            this.BusinessTypeGuide_Button.Enabled = false;
            this.tNedit_SalesCode.Enabled = false;
            this.SalesCodeGuide_Button.Enabled = false;
            this.tNedit_EnterpriseGanreCode.Enabled = false;
            this.EnterpriseGanreGuide_Button.Enabled = false;
            
            switch (targetContrastCd)
            {
                case 10:    // ���_
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;

                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 20:    // ���_�{����
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_SubSectionCode.Enabled = true;
                        this.SubSectionGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 30:    // ���_�{���Ӑ�
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;

                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 221:   // ���_�{�S����
                case 222:   // ���_�{�󒍎�
                case 223:   // ���_�{���s��
                    {
                        if (targetContrastCd == 221)
                        {
                            this.uLabel_Employee.Text = "�S����";
                        }
                        else if (targetContrastCd == 222)
                        {
                            this.uLabel_Employee.Text = "�󒍎�";
                        }
                        else
                        {
                            this.uLabel_Employee.Text = "���s��";
                        }
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tEdit_EmployeeCode.Enabled = true;
                        this.EmployeeGuide_Button.Enabled = true;

                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 32:    // ���_�{�n��
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_SalesAreaCode.Enabled = true;
                        this.SalesAreaGuide_Button.Enabled = true;

                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 31:    // ���_�{�Ǝ�
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_BusinessTypeCode.Enabled = true;
                        this.BusinessTypeGuide_Button.Enabled = true;

                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 44:    // ���_�{�̔��敪
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_SalesCode.Enabled = true;
                        this.SalesCodeGuide_Button.Enabled = true;

                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 45:    // ���i�敪
                    {
                        this.tNedit_EnterpriseGanreCode.Enabled = true;
                        this.EnterpriseGanreGuide_Button.Enabled = true;

                        this.tEdit_SectionCode.Clear();
                        this.tEdit_SectionName.Clear();
                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();

                        break;
                    }
            }
        }

        /// <summary>
        /// �R���g���[��Enabled���䏈��
        /// </summary>
        /// <param name="editMode">�ҏW���[�h</param>
        /// <remarks>
        /// <br>Note       : �R���g���[����Enabled������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SetControlEnabled(string editMode)
        {
            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;

            switch (editMode)
            {
                case INSERT_MODE:
                    {
                        //this.tNedit_Year.Enabled = true;
                        //this.tComboEditor_TargetContrastCd.Enabled = true;

                        //// �����R���g���[��Enabled����
                        //ChangeTargetContrastControl(targetContrastCd);

                        // ADD 2009/05/20 ------>>>
                        // �N�x�Ɛݒ�敪�����
                        this.tNedit_Year.Enabled = true;
                        this.tComboEditor_TargetContrastCd.Enabled = true;
                        // ADD 2009/05/20 ------<<<

                        this.tNedit_SalesTargetSale.Enabled = true;
                        this.tNedit_SalesTargetProfit.Enabled = true;
                        this.tNedit_SalesTargetCount.Enabled = true;

                        this.SalesTarget_uGrid.Enabled = true;

                        this._isClose = true;
                        this._isSave = true;
                        this._isNew = true;
                        this._isRevival = false;
                        this._isLogicalDelete = false;
                        this._isDelete = false;
                        this._isUndo = true;
                        this._isCalc = true;
                        this._isRenewal = true;

                        break;
                    }
                case UPDATE_MODE:
                    {
                        //this.tNedit_Year.Enabled = false;
                        //this.tComboEditor_TargetContrastCd.Enabled = false;

                        //// �����R���g���[��Enabled����
                        //ChangeTargetContrastControl(0);

                        // ADD 2009/05/20 ------>>>
                        // �e�[�u���L�[���ڂ͓��͕s��
                        this.tNedit_Year.Enabled = false;
                        this.tComboEditor_TargetContrastCd.Enabled = false;
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.tNedit_SubSectionCode.Enabled = false;
                        this.SubSectionGuide_Button.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BusinessTypeCode.Enabled = false;
                        this.BusinessTypeGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_EnterpriseGanreCode.Enabled = false;
                        this.EnterpriseGanreGuide_Button.Enabled = false;
                        // ADD 2009/05/20 ------<<<

                        this.tNedit_SalesTargetSale.Enabled = true;
                        this.tNedit_SalesTargetProfit.Enabled = true;
                        this.tNedit_SalesTargetCount.Enabled = true;

                        this.SalesTarget_uGrid.Enabled = true;

                        this._isClose = true;
                        this._isSave = true;
                        this._isNew = true;
                        this._isRevival = false;
                        this._isLogicalDelete = true;
                        this._isDelete = false;
                        this._isUndo = true;
                        this._isCalc = true;
                        this._isRenewal = true;

                        break;
                    }
                case DELETE_MODE:
                    {
                        //this.tNedit_Year.Enabled = false;
                        //this.tComboEditor_TargetContrastCd.Enabled = false;

                        //// �����R���g���[��Enabled����
                        //ChangeTargetContrastControl(0);

                        // ADD 2009/05/20 ------>>>
                        // �e�[�u���L�[���ڂ͓��͕s��
                        this.tNedit_Year.Enabled = false;
                        this.tComboEditor_TargetContrastCd.Enabled = false;
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.tNedit_SubSectionCode.Enabled = false;
                        this.SubSectionGuide_Button.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BusinessTypeCode.Enabled = false;
                        this.BusinessTypeGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_EnterpriseGanreCode.Enabled = false;
                        this.EnterpriseGanreGuide_Button.Enabled = false;
                        // ADD 2009/05/20 ------<<<

                        this.tNedit_SalesTargetSale.Enabled = false;
                        this.tNedit_SalesTargetProfit.Enabled = false;
                        this.tNedit_SalesTargetCount.Enabled = false;

                        this.SalesTarget_uGrid.Enabled = false;

                        this._isClose = true;
                        this._isSave = false;
                        this._isNew = true;
                        this._isRevival = true;
                        this._isLogicalDelete = false;
                        this._isDelete = true;
                        this._isUndo = false;
                        this._isCalc = false;
                        this._isRenewal = false;

                        break;
                    }
            }

            ParentToolbarSalesTargetEvent(this);
        }
        #endregion �R���g���[��Enabled����

        // ADD 2009/05/20 ------>>>
        #region �L�[�R���g���[��Disable����
        /// <summary>
        /// �L�[�R���g���[��Disable���䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�[�R���g���[����Disable������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SetKeyControlDisable()
        {
            // �e�[�u���L�[���ڂ͓��͕s��
            this.tNedit_Year.Enabled = false;
            this.tComboEditor_TargetContrastCd.Enabled = false;
            this.tEdit_SectionCode.Enabled = false;
            this.SectionGuide_Button.Enabled = false;
            this.tNedit_SubSectionCode.Enabled = false;
            this.SubSectionGuide_Button.Enabled = false;
            this.tNedit_CustomerCode.Enabled = false;
            this.CustomerGuide_Button.Enabled = false;
            this.tEdit_EmployeeCode.Enabled = false;
            this.EmployeeGuide_Button.Enabled = false;
            this.tNedit_SalesAreaCode.Enabled = false;
            this.SalesAreaGuide_Button.Enabled = false;
            this.tNedit_BusinessTypeCode.Enabled = false;
            this.BusinessTypeGuide_Button.Enabled = false;
            this.tNedit_SalesCode.Enabled = false;
            this.SalesCodeGuide_Button.Enabled = false;
            this.tNedit_EnterpriseGanreCode.Enabled = false;
            this.EnterpriseGanreGuide_Button.Enabled = false;
            
        }
        #endregion �L�[�R���g���[��Disable����
        // ADD 2009/05/20 ------<<<

        #region Focus�ݒ�
        /// <summary>
        /// Next�R���g���[���擾����
        /// </summary>
        /// <param name="prevControl">���݃R���g���[��</param>
        /// <param name="nextControl">Next�R���g���[��</param>
        /// <remarks>
        /// <br>Note       : Next�R���g���[�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void GetNextControl(Control prevControl, out Control nextControl)
        {
            nextControl = null;

            if (prevControl == null)
            {
                return;
            }

            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;

            switch (prevControl.Name)
            {
                case "tEdit_SectionCode":
                case "SectionGuide_Button":
                    {
                        switch (targetContrastCd)
                        {
                            case 10:    // ���_
                                {
                                    nextControl = this.tNedit_SalesTargetSale;
                                    break;
                                }
                            case 20:    // ���_�{����
                                {
                                    nextControl = this.tNedit_SubSectionCode;
                                    break;
                                }
                            case 30:    // ���_�{���Ӑ�
                                {
                                    nextControl = this.tNedit_CustomerCode;
                                    break;
                                }
                            case 221:   // ���_�{�S����
                            case 222:   // ���_�{�󒍎�
                            case 223:   // ���_�{���s��
                                {
                                    nextControl = this.tEdit_EmployeeCode;
                                    break;
                                }
                            case 32:    // ���_�{�n��
                                {
                                    nextControl = this.tNedit_SalesAreaCode;
                                    break;
                                }
                            case 31:    // ���_�{�Ǝ�
                                {
                                    nextControl = this.tNedit_BusinessTypeCode;
                                    break;
                                }
                            case 44:    // ���_�{�̔��敪
                                {
                                    nextControl = tNedit_SalesCode;
                                    break;
                                }
                        }
                        break;
                    }
                case "tNedit_SubSectionCode":
                case "SubSectionGuide_Button":
                case "tNedit_CustomerCode":
                case "CustomerGuide_Button":
                case "tEdit_EmployeeCode":
                case "EmployeeGuide_Button":
                case "tNedit_SalesAreaCode":
                case "SalesAreaGuide_Button":
                case "tNedit_BusinessTypeCode":
                case "BusinessTypeGuide_Button":
                case "tNedit_SalesCode":
                case "SalesCodeGuide_Button":
                case "tNedit_EnterpriseGanreCode":
                case "EnterpriseGanreGuide_Button":
                    {
                        nextControl = this.tNedit_SalesTargetSale;
                        break;
                    }
            }
        }

        /// <summary>
        /// NextCell�ݒ菈��
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <param name="shiftFlg">ShiftKey�����t���O(True:���� Flase:��������)</param>
        /// <remarks>
        /// <br>Note       : NextCell��ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SetNextCell(ref ChangeFocusEventArgs e, bool shiftFlg)
        {
            int rowIndex;
            int columnIndex;

            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                if (this.SalesTarget_uGrid.ActiveRow == null)
                {
                    rowIndex = 0;
                    columnIndex = 1;
                }
                else
                {
                    rowIndex = this.SalesTarget_uGrid.ActiveRow.Index;
                    columnIndex = 1;
                }
            }
            else
            {
                rowIndex = this.SalesTarget_uGrid.ActiveCell.Row.Index;
                columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;
            }

            e.NextCtrl = null;

            if (shiftFlg == false)
            {
                if (rowIndex < 11)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (columnIndex < 4)
                    {
                        this.SalesTarget_uGrid.Rows[0].Cells[columnIndex + 1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        if (this.Mode_Label.Text == INSERT_MODE)
                        {
                            this.tNedit_Year.Focus();
                        }
                        else
                        {
                            this.tNedit_SalesTargetSale.Focus();
                        }
                    }
                }
            }
            else
            {
                if (rowIndex > 0)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (columnIndex > 1)
                    {
                        this.SalesTarget_uGrid.Rows[11].Cells[columnIndex - 1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.tNedit_SalesTargetCount.Focus();
                    }
                }
            }
        }
        #endregion Focus�ݒ�

        #region �ۑ�����
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ��ۑ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int SaveProc()
        {
            this.SalesTarget_uGrid.ActiveCell = null;

            // ���̓`�F�b�N
            bool bStatus = CheckScreenInput(true);
            if (!bStatus)
            {
                return -1;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // ���_
                case 20:    // ���_�{����
                case 221:   // ���_�{�S����
                case 222:   // ���_�{�󒍎�
                case 223:   // ���_�{���s��
                    {
                        status = SaveEmpSalesTarget();
                        break;
                    }
                case 30:    // ���_�{���Ӑ�
                case 31:    // ���_�{�Ǝ�
                case 32:    // ���_�{�n��
                    {
                        status = SaveCustSalesTarget();
                        break;
                    }
               default:     // ���_�{�̔��敪�A���i�敪
                    {
                        status = SaveGcdSalesTarget();
                        break;
                    }
            }

            return (status);
        }

        /// <summary>
        /// �ۑ�����(�]�ƈ��ʔ���ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ��ۑ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// <br>Update Note: 2010/12/20 ������</br>
        /// <br>             ��Q���ǑΉ��P�Q��</br>
        /// </remarks>
        private int SaveEmpSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ��ʏ��擾
            List<EmpSalesTarget> empSalesTargetList = new List<EmpSalesTarget>();
            ScreenToEmpSalesTargetList(ref empSalesTargetList);

            // �폜���X�g�擾
            List<EmpSalesTarget> deleteList = new List<EmpSalesTarget>();
            foreach (EmpSalesTarget empSalesTarget in this._empSalesTargetDicClone.Values)
            {
                deleteList.Add(empSalesTarget);
            }

            // ---UPD 2010/12/20--------->>>>>
            //// �폜����
            //if (deleteList.Count > 0)
            //{
            //    status = this._salesTargetAcs.Delete(deleteList);
            //    switch (status)
            //    {
            //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //            {
            //                break;
            //            }
            //        default:
            //            {
            //                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //               "SaveProc",
            //               "�ۑ������Ɏ��s���܂����B",
            //               status,
            //               MessageBoxButtons.OK);
            //                return (status);
            //            }
            //    }
            //}

            // �ۑ�����
            if (deleteList.Count > 0)
            {
                status = this._salesTargetAcs.WriteProc(ref empSalesTargetList, deleteList);
            }
            else
            {
                status = this._salesTargetAcs.Write(ref empSalesTargetList);
            }
            // ---UPD 2010/12/20---------<<<<<

            // ---DEL 2010/12/20--------->>>>>
            //// �ۑ�����
            //status = this._salesTargetAcs.Write(ref empSalesTargetList);
            // ---DEL 2010/12/20---------<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        // �ҏW���[�h�ݒ�
                        this.Mode_Label.Text = UPDATE_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(UPDATE_MODE);

                        // �o�b�t�@�X�V
                        this._empSalesTargetDicClone.Clear();
                        foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                        {
                            this._empSalesTargetDicClone.Add(empSalesTarget.TargetDivideCode.Trim(), empSalesTarget);
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "�ۑ������Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        /// <summary>
        /// �ۑ�����(���Ӑ�ʔ���ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ��ۑ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// <br>Update Note: 2010/12/20 ������</br>
        /// <br>             ��Q���ǑΉ��P�Q��</br>
        /// </remarks>
        private int SaveCustSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ��ʏ��擾
            List<CustSalesTarget> custSalesTargetList = new List<CustSalesTarget>();
            ScreenToCustSalesTargetList(ref custSalesTargetList);

            // �폜���X�g�擾
            List<CustSalesTarget> deleteList = new List<CustSalesTarget>();
            foreach (CustSalesTarget custSalesTarget in this._custSalesTargetDicClone.Values)
            {
                deleteList.Add(custSalesTarget);
            }

            // ---UPD 2010/12/20--------->>>>>
            //if (deleteList.Count > 0)
            //{
            //    status = this._salesTargetAcs.Delete(deleteList);
            //    switch (status)
            //    {
            //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //            {
            //                break;
            //            }
            //        default:
            //            {
            //                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //               "SaveProc",
            //               "�ۑ������Ɏ��s���܂����B",
            //               status,
            //               MessageBoxButtons.OK);
            //                return (status);
            //            }
            //    }
            //}

            // �ۑ�����
            if (deleteList.Count > 0)
            {
                status = this._salesTargetAcs.WriteProc(ref custSalesTargetList, deleteList);
            }
            else
            {
                status = this._salesTargetAcs.Write(ref custSalesTargetList);
            }
            // ---UPD 2010/12/20---------<<<<<

            // ---DEL 2010/12/20--------->>>>>
            //// �ۑ�����
            //status = this._salesTargetAcs.Write(ref custSalesTargetList);
            // ---DEL 2010/12/20---------<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        // �ҏW���[�h�ݒ�
                        this.Mode_Label.Text = UPDATE_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(UPDATE_MODE);

                        // �o�b�t�@�X�V
                        this._custSalesTargetDicClone.Clear();
                        foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                        {
                            this._custSalesTargetDicClone.Add(custSalesTarget.TargetDivideCode.Trim(), custSalesTarget);
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "�ۑ������Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        /// <summary>
        /// �ۑ�����(���i�ʔ���ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ��ۑ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// <br>Update Note: 2010/12/20 ������</br>
        /// <br>             ��Q���ǑΉ��P�Q��</br>
        /// </remarks>
        private int SaveGcdSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ��ʏ��擾
            List<GcdSalesTarget> gcdSalesTargetList = new List<GcdSalesTarget>();
            ScreenToGcdSalesTargetList(ref gcdSalesTargetList);

            // �폜���X�g�擾
            List<GcdSalesTarget> deleteList = new List<GcdSalesTarget>();
            foreach (GcdSalesTarget gcdSalesTarget in this._gcdSalesTargetDicClone.Values)
            {
                deleteList.Add(gcdSalesTarget);
            }

            // ---UPD 2010/12/20--------->>>>>
            //if (deleteList.Count > 0)
            //{
            //    status = this._salesTargetAcs.Delete(deleteList);
            //    switch (status)
            //    {
            //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //            {
            //                break;
            //            }
            //        default:
            //            {
            //                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //               "SaveProc",
            //               "�ۑ������Ɏ��s���܂����B",
            //               status,
            //               MessageBoxButtons.OK);
            //                return (status);
            //            }
            //    }
            //}

            if (deleteList.Count > 0)
            {
                // �ۑ�����
                status = this._salesTargetAcs.WriteProc(ref gcdSalesTargetList, deleteList);
            }
            else
            {
                // �ۑ�����
                status = this._salesTargetAcs.Write(ref gcdSalesTargetList);
            }
            // ---UPD 2010/12/20---------<<<<<

            // ---DEL 2010/12/20--------->>>>>
            //// �ۑ�����
            //status = this._salesTargetAcs.Write(ref gcdSalesTargetList);
            // ---DEL 2010/12/20---------<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        // �ҏW���[�h�ݒ�
                        this.Mode_Label.Text = UPDATE_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(UPDATE_MODE);

                        // �o�b�t�@�X�V
                        this._gcdSalesTargetDicClone.Clear();
                        foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                        {
                            this._gcdSalesTargetDicClone.Add(gcdSalesTarget.TargetDivideCode, gcdSalesTarget);
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "�ۑ������Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion �ۑ�����

        #region ���ɖ߂�����
        /// <summary>
        /// ���ɖ߂�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ�Ԃ����ɖ߂��܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int UndoProc()
        {
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // ��ʏ�����
                ClearScreen();

                // ADD 2009/05/20 ------>>>
                // �R���g���[��Enabled����
                SetControlEnabled(INSERT_MODE);

                // �ݒ�敪�����R���g���[��Enabled����
                ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
                // ADD 2009/05/20 ------<<<
            }
            else if (this.Mode_Label.Text == UPDATE_MODE)
            {
                // �ݒ�敪
                int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                switch (targetContrastCd)
                {
                    case 10:    // ���_
                    case 20:    // ���_�{����
                    case 221:   // ���_�{�S����
                    case 222:   // ���_�{�󒍎�
                    case 223:   // ���_�{���s��
                        {
                            // ��ʓW�J
                            EmpSalesTargetToScreen(this._empSalesTargetDicClone);
                            break;
                        }
                    case 30:    // ���_�{���Ӑ�
                    case 31:    // ���_�{�Ǝ�
                    case 32:    // ���_�{�n��
                        {
                            // ��ʓW�J
                            CustSalesTargetToScreen(this._custSalesTargetDicClone);
                            break;
                        }
                    default:    // ���_�{�̔��敪�A���i�敪
                        {
                            // ��ʓW�J
                            GcdSalesTargetToScreen(this._gcdSalesTargetDicClone);
                            break;
                        }
                }
            }
            return 0;
        }
        #endregion ���ɖ߂�����

        #region �_���폜����
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ��_���폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int LogicalDeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // ���_
                case 20:    // ���_�{����
                case 221:   // ���_�{�S����
                case 222:   // ���_�{�󒍎�
                case 223:   // ���_�{���s��
                    {
                        status = LogicalDeleteEmpSalesTarget();
                        break;
                    }
                case 30:    // ���_�{���Ӑ�
                case 31:    // ���_�{�Ǝ�
                case 32:    // ���_�{�n��
                    {
                        status = LogicalDeleteCustSalesTarget();
                        break;
                    }
                default:    // ���_�{�̔��敪�A���i�敪
                    {
                        status = LogicalDeleteGcdSalesTarget();
                        break;
                    }
            }

            return (status);
        }

        /// <summary>
        /// �_���폜����(�]�ƈ��ʔ���ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ��_���폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int LogicalDeleteEmpSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<EmpSalesTarget> empSalesTargetList = new List<EmpSalesTarget>();
            foreach (EmpSalesTarget empSalesTarget in this._empSalesTargetDicClone.Values)
            {
                empSalesTargetList.Add(empSalesTarget);
            }

            // �_���폜
            status = this._salesTargetAcs.LogicalDelete(ref empSalesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ύX
                        this.Mode_Label.Text = DELETE_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(DELETE_MODE);

                        // �o�b�t�@�X�V
                        this._empSalesTargetDicClone.Clear();
                        foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                        {
                            this._empSalesTargetDicClone.Add(empSalesTarget.TargetDivideCode.Trim(), empSalesTarget);
                        }

                        // ��ʓW�J
                        EmpSalesTargetToScreen(this._empSalesTargetDicClone);

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "LogicalDeleteProc",
                                       "�폜�����Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        /// <summary>
        /// �_���폜����(���Ӑ�ʔ���ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ��_���폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int LogicalDeleteCustSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<CustSalesTarget> custSalesTargetList = new List<CustSalesTarget>();
            foreach (CustSalesTarget custSalesTarget in this._custSalesTargetDicClone.Values)
            {
                custSalesTargetList.Add(custSalesTarget);
            }

            // �_���폜
            status = this._salesTargetAcs.LogicalDelete(ref custSalesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ύX
                        this.Mode_Label.Text = DELETE_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(DELETE_MODE);

                        // �o�b�t�@�X�V
                        this._custSalesTargetDicClone.Clear();
                        foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                        {
                            this._custSalesTargetDicClone.Add(custSalesTarget.TargetDivideCode.Trim(), custSalesTarget);
                        }

                        // ��ʓW�J
                        CustSalesTargetToScreen(this._custSalesTargetDicClone);

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "LogicalDeleteProc",
                                       "�폜�����Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        /// <summary>
        /// �_���폜����(���i�ʔ���ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ��_���폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int LogicalDeleteGcdSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<GcdSalesTarget> gcdSalesTargetList = new List<GcdSalesTarget>();
            foreach (GcdSalesTarget gcdSalesTarget in this._gcdSalesTargetDicClone.Values)
            {
                gcdSalesTargetList.Add(gcdSalesTarget);
            }

            // �_���폜
            status = this._salesTargetAcs.LogicalDelete(ref gcdSalesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ύX
                        this.Mode_Label.Text = DELETE_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(DELETE_MODE);

                        // �o�b�t�@�X�V
                        this._gcdSalesTargetDicClone.Clear();
                        foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                        {
                            this._gcdSalesTargetDicClone.Add(gcdSalesTarget.TargetDivideCode.Trim(), gcdSalesTarget);
                        }

                        // ��ʓW�J
                        GcdSalesTargetToScreen(this._gcdSalesTargetDicClone);

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "LogicalDeleteProc",
                                       "�폜�����Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion �_���폜����

        #region �����폜����
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�𕨗��폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int DeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // ���_
                case 20:    // ���_�{����
                case 221:   // ���_�{�S����
                case 222:   // ���_�{�󒍎�
                case 223:   // ���_�{���s��
                    {
                        List<EmpSalesTarget> empSalesTargetList = new List<EmpSalesTarget>();
                        foreach (EmpSalesTarget empSalesTarget in this._empSalesTargetDicClone.Values)
                        {
                            empSalesTargetList.Add(empSalesTarget);
                        }

                        // �����폜
                        status = this._salesTargetAcs.Delete(empSalesTargetList);
                        break;
                    }
                case 30:    // ���_�{���Ӑ�
                case 31:    // ���_�{�Ǝ�
                case 32:    // ���_�{�n��
                    {
                        List<CustSalesTarget> custSalesTargetList = new List<CustSalesTarget>();
                        foreach (CustSalesTarget custSalesTarget in this._custSalesTargetDicClone.Values)
                        {
                            custSalesTargetList.Add(custSalesTarget);
                        }

                        // �����폜
                        status = this._salesTargetAcs.Delete(custSalesTargetList);
                        break;
                    }
                default:    // ���_�{�̔��敪�A���i�敪
                    {
                        List<GcdSalesTarget> gcdSalesTargetList = new List<GcdSalesTarget>();
                        foreach (GcdSalesTarget gcdSalesTarget in this._gcdSalesTargetDicClone.Values)
                        {
                            gcdSalesTargetList.Add(gcdSalesTarget);
                        }

                        // �����폜
                        status = this._salesTargetAcs.Delete(gcdSalesTargetList);
                        break;
                    }
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ύX
                        this.Mode_Label.Text = INSERT_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(INSERT_MODE);

                        // ADD 2009/05/20 ------>>>
                        // �ݒ�敪�����R���g���[��Enabled����
                        ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
                        // ADD 2009/05/20 ------<<<
                        
                        // ��ʃN���A
                        ClearScreen();

                        this.tNedit_Year.Focus(); // 2011.07.18 wangf add

                        // �o�b�t�@�X�V
                        this._empSalesTargetDicClone.Clear();
                        this._custSalesTargetDicClone.Clear();
                        this._gcdSalesTargetDicClone.Clear();

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "DeleteProc",
                                       "���S�폜�����Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion �����폜����

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�𕜊����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int RevivalProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // ���_
                case 20:    // ���_�{����
                case 221:   // ���_�{�S����
                case 222:   // ���_�{�󒍎�
                case 223:   // ���_�{���s��
                    {
                        status = RevivalEmpSalesTarget();
                        break;
                    }
                case 30:    // ���_�{���Ӑ�
                case 31:    // ���_�{�Ǝ�
                case 32:    // ���_�{�n��
                    {
                        status = RevivalCustSalesTarget();
                        break;
                    }
                default:    // ���_�{�̔��敪�A���i�敪
                    {
                        status = RevivalGcdSalesTarget();
                        break;
                    }
            }

            return (status);
        }

        /// <summary>
        /// ��������(�]�ƈ��ʔ���ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�𕜊����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int RevivalEmpSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<EmpSalesTarget> empSalesTargetList = new List<EmpSalesTarget>();
            foreach (EmpSalesTarget empSalesTarget in this._empSalesTargetDicClone.Values)
            {
                empSalesTargetList.Add(empSalesTarget);
            }

            // ����
            status = this._salesTargetAcs.Revival(ref empSalesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ύX
                        this.Mode_Label.Text = UPDATE_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(UPDATE_MODE);

                        // �o�b�t�@�X�V
                        this._empSalesTargetDicClone.Clear();
                        foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                        {
                            this._empSalesTargetDicClone.Add(empSalesTarget.TargetDivideCode.Trim(), empSalesTarget);
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "RevivalProc",
                                       "���������Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        /// <summary>
        /// ��������(���Ӑ�ʔ���ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�𕜊����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int RevivalCustSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<CustSalesTarget> custSalesTargetList = new List<CustSalesTarget>();
            foreach (CustSalesTarget custSalesTarget in this._custSalesTargetDicClone.Values)
            {
                custSalesTargetList.Add(custSalesTarget);
            }

            // ����
            status = this._salesTargetAcs.Revival(ref custSalesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ύX
                        this.Mode_Label.Text = UPDATE_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(UPDATE_MODE);

                        // �o�b�t�@�X�V
                        this._custSalesTargetDicClone.Clear();
                        foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                        {
                            this._custSalesTargetDicClone.Add(custSalesTarget.TargetDivideCode.Trim(), custSalesTarget);
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "RevivalProc",
                                       "���������Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        /// <summary>
        /// ��������(���i�ʔ���ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�𕜊����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int RevivalGcdSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<GcdSalesTarget> gcdSalesTargetList = new List<GcdSalesTarget>();
            foreach (GcdSalesTarget gcdSalesTarget in this._gcdSalesTargetDicClone.Values)
            {
                gcdSalesTargetList.Add(gcdSalesTarget);
            }

            // ����
            status = this._salesTargetAcs.Revival(ref gcdSalesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ύX
                        this.Mode_Label.Text = UPDATE_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(UPDATE_MODE);

                        // �o�b�t�@�X�V
                        this._gcdSalesTargetDicClone.Clear();
                        foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                        {
                            this._gcdSalesTargetDicClone.Add(gcdSalesTarget.TargetDivideCode.Trim(), gcdSalesTarget);
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "RevivalProc",
                                       "���������Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion ��������

        #region �䗦����v�Z����
        /// <summary>
        /// �䗦����v�Z����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �䗦����ڕW�������v�Z���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int CalcProc()
        {
            // �v�Z�O�`�F�b�N
            bool bStatus = CheckBeforeCalc();
            if (!bStatus)
            {
                return -1;
            }

            // �䗦
            double ratio = 0;
            // �䗦���v
            double totalRatio = 0;
            // �䗦�i�[�z��
            double[] ratioArray = new double[12];

            //-----------------------------------
            // ���v�䗦�擾�{�e�䗦�i�[
            //-----------------------------------
            for (int index = 0; index < 12; index++)
            {
                // �Z���l�ϊ�
                ratio = ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_RATIO].Value);
                totalRatio += ratio;
                ratioArray[index] = ratio;
            }

            //-----------------------------------
            // �O���b�h�N���A
            //-----------------------------------
            for (int index = 0; index < 13; index++)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            long targetValue = 0;

            //-----------------------------------
            // ����ڕW�l�ݒ�
            //-----------------------------------
            if (this.tNedit_SalesTargetSale.GetInt() != 0)
            {
                // ����ڕW(�N��)
                double salesTarget = this.tNedit_SalesTargetSale.GetInt();
                
                long totalValue = 0;

                for (int index = 0; index < 12; index++)
                {
                    if (ratioArray[index] == 0)
                    {
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                    }
                    else
                    {
                        targetValue = (long)(salesTarget * ratioArray[index] / totalRatio);
                        totalValue += targetValue;
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = targetValue.ToString(FORMAT_NUM);
                    }
                }
                
                // �N�ԖڕW�l�Ɛ��������Ƃ�܂�
                for (int index = 11; index >= 0; index--)
                {
                    if (ratioArray[index] != 0)
                    {
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = (targetValue + salesTarget - totalValue).ToString(FORMAT_NUM);
                        break;
                    }
                }

                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Value = salesTarget.ToString(FORMAT_NUM);
            }

            //-----------------------------------
            // �e���ڕW�l�ݒ�
            //-----------------------------------
            if (this.tNedit_SalesTargetProfit.GetInt() != 0)
            {
                // �e���ڕW(�N��)
                double profitTarget = this.tNedit_SalesTargetProfit.GetInt();

                long totalValue = 0;

                for (int index = 0; index < 12; index++)
                {
                    if (ratioArray[index] == 0)
                    {
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                    }
                    else
                    {
                        targetValue = (long)(profitTarget * ratioArray[index] / totalRatio);
                        totalValue += targetValue;
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = targetValue.ToString(FORMAT_NUM);
                    }
                }

                // �N�ԖڕW�l�Ɛ��������Ƃ�܂�
                for (int index = 11; index >= 0; index--)
                {
                    if (ratioArray[index] != 0)
                    {
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = (targetValue + profitTarget - totalValue).ToString(FORMAT_NUM);
                        break;
                    }
                }

                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Value = profitTarget.ToString(FORMAT_NUM);
            }

            //-----------------------------------
            // ���ʖڕW�l�ݒ�
            //-----------------------------------
            if (this.tNedit_SalesTargetCount.GetInt() != 0)
            {
                // ���ʖڕW(�N��)
                double countTarget = this.tNedit_SalesTargetCount.GetInt();

                long totalValue = 0;

                for (int index = 0; index < 12; index++)
                {
                    if (ratioArray[index] == 0)
                    {
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
                    }
                    else
                    {
                        targetValue = (long)(countTarget * ratioArray[index] / totalRatio);
                        totalValue += targetValue;
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = targetValue.ToString(FORMAT_NUM);
                    }
                }

                // �N�ԖڕW�l�Ɛ��������Ƃ�܂�
                for (int index = 11; index >= 0; index--)
                {
                    if (ratioArray[index] != 0)
                    {
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = (targetValue + countTarget - totalValue).ToString(FORMAT_NUM);
                        break;
                    }
                }

                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Value = countTarget.ToString(FORMAT_NUM);
            }

            return 0;
        }
        #endregion �䗦����v�Z����

        #region �ŐV���擾����
        /// <summary>
        /// �ŐV���擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ŐV�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int RenewalProc()
        {
            // �e��}�X�^�擾
            bool bStatus = ReadMaster();
            if (!bStatus)
            {
                return (-1);
            }

            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "�ŐV�����擾���܂����B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

            return (0);
        }
        #endregion �ŐV���擾����

        #region �`�F�b�N����
        /// <summary>
        /// �v�Z�O�`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �䗦����v�Z�O�ɓ��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool CheckBeforeCalc()
        {
            string errMsg = "";

            try
            {
                // �N�ԖڕW�������͂̏ꍇ
                if ((this.tNedit_SalesTargetSale.GetInt() == 0) &&
                    (this.tNedit_SalesTargetProfit.GetInt() == 0) &&
                    (this.tNedit_SalesTargetCount.GetInt() == 0))
                {
                    errMsg = "�N�ԖڕW����͂��Ă��������B";
                    this.tNedit_SalesTargetSale.Focus();
                    return (false);
                }

                double totalRatio = 0;
                for (int index = 0; index < 12; index++)
                {
                    // �Z���l�ϊ�
                    totalRatio += ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_RATIO].Value);
                }
                // �䗦�������͂̏ꍇ
                if (totalRatio == 0)
                {
                    errMsg = "���ʔ䗦����͂��Ă��������B";
                    this.SalesTarget_uGrid.Focus();
                    this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_RATIO].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="beforeSaveFlg">�ۑ��O�t���O(True:�ۑ��O False:������)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool CheckScreenInput(bool beforeSaveFlg)
        {
            bool bStatus;

            // ���̓`�F�b�N(����)
            bStatus = CheckCondition(beforeSaveFlg);
            if (!bStatus)
            {
                return (false);
            }

            if (beforeSaveFlg == true)
            {
                // ���̓`�F�b�N(�ڕW)
                bStatus = CheckSalesTarget();
                if (!bStatus)
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// ���̓`�F�b�N����(����)
        /// </summary>
        /// <param name="beforeSaveFlg">�ۑ��O�t���O(True:�ۑ��O False:������)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool CheckCondition(bool beforeSaveFlg)
        {
            // �ꊇ�[���l��
            this.uiSetControl1.SettingAllControlsZeroPaddedText();

            string errMsg = "";
            Control control = null;

            try
            {
                if (this.tNedit_Year.GetInt() == 0)
                {
                    errMsg = "�N�x����͂��Ă��������B";
                    control = this.tNedit_Year;
                    return (false);
                }

                // �ݒ�敪
                int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                switch (targetContrastCd)
                {
                    case 45:
                        {
                            if (this.tNedit_EnterpriseGanreCode.GetInt() == 0)
                            {
                                errMsg = "���i�敪����͂��Ă��������B";
                                control = this.tNedit_EnterpriseGanreCode;
                                return (false);
                            }

                            int enterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                            if (GetEnterpriseGanreName(enterpriseGanreCode) == "")
                            {
                                errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                control = this.tNedit_EnterpriseGanreCode;
                                return (false);
                            }
                            break;
                        }
                    default:
                        {
                            if (this.tEdit_SectionCode.DataText.Trim() == "")
                            {
                                errMsg = "���_����͂��Ă��������B";
                                control = this.tEdit_SectionCode;
                                return (false);
                            }

                            string sectionCode = this.tEdit_SectionCode.DataText.Trim();
                            if (GetSectionName(sectionCode) == "")
                            {
                                errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                control = this.tEdit_SectionCode;
                                return (false);
                            }

                            if (targetContrastCd == 20)
                            {
                                if (this.tNedit_SubSectionCode.GetInt() == 0)
                                {
                                    errMsg = "�������͂��Ă��������B";
                                    control = this.tNedit_SubSectionCode;
                                    return (false);
                                }

                                int subSectionCode = this.tNedit_SubSectionCode.GetInt();
                                if (GetSubSectionName(subSectionCode) == "")
                                {
                                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                    control = this.tNedit_SubSectionCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 30)
                            {
                                if (this.tNedit_CustomerCode.GetInt() == 0)
                                {
                                    errMsg = "���Ӑ����͂��Ă��������B";
                                    control = this.tNedit_CustomerCode;
                                    return (false);
                                }

                                int customerCode = this.tNedit_CustomerCode.GetInt();
                                //if (GetCustomerName(customerCode) == "")  // DEL 2009/06/29
                                if (!CheckCustomer(customerCode))   // ADD 2009/06/29
                                {
                                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                    control = this.tNedit_CustomerCode;
                                    return (false);
                                }
                            }
                            else if ((targetContrastCd == 221) || (targetContrastCd == 222) || (targetContrastCd == 223))
                            {
                                if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                                {
                                    if (targetContrastCd == 221)
                                    {
                                        errMsg = "�S���҂���͂��Ă��������B";
                                    }
                                    else if (targetContrastCd == 222)
                                    {
                                        errMsg = "�󒍎҂���͂��Ă��������B";
                                    }
                                    else
                                    {
                                        errMsg = "���s�҂���͂��Ă��������B";
                                    }
                                    control = this.tEdit_EmployeeCode;
                                    return (false);
                                }

                                string employeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                                if (GetEmployeeName(employeeCode) == "")
                                {
                                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                    control = this.tEdit_EmployeeCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 32)
                            {
                                if (this.tNedit_SalesAreaCode.GetInt() == 0)
                                {
                                    errMsg = "�n�����͂��Ă��������B";
                                    control = this.tNedit_SalesAreaCode;
                                    return (false);
                                }

                                int salesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                                if (GetSalesAreaName(salesAreaCode) == "")
                                {
                                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                    control = this.tNedit_SalesAreaCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 31)
                            {
                                if (this.tNedit_BusinessTypeCode.GetInt() == 0)
                                {
                                    errMsg = "�Ǝ����͂��Ă��������B";
                                    control = this.tNedit_BusinessTypeCode;
                                    return (false);
                                }

                                int businessTypeCode = this.tNedit_BusinessTypeCode.GetInt();
                                if (GetBusinessTypeName(businessTypeCode) == "")
                                {
                                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                    control = this.tNedit_BusinessTypeCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 44)
                            {
                                if (this.tNedit_SalesCode.GetInt() == 0)
                                {
                                    errMsg = "�̔��敪����͂��Ă��������B";
                                    control = this.tNedit_SalesCode;
                                    return (false);
                                }

                                int salesCode = this.tNedit_SalesCode.GetInt();
                                if (GetSalesCodeName(salesCode) == "")
                                {
                                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                    control = this.tNedit_SalesCode;
                                    return (false);
                                }
                            }

                            break;
                        }
                }
            }
            finally
            {
                if ((errMsg.Length > 0) && (beforeSaveFlg == true))
                {
                    control.Focus();

                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// ���̓`�F�b�N����(�ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool CheckSalesTarget()
        {
            string errMsg = "";

            try
            {
                bool inputFlg = false;
                for (int index = 0; index < 12; index++)
                {
                    // �Z���l�ϊ�
                    if ((ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) == 0) &&
                        (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) == 0) &&
                        (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) == 0))
                    {
                        continue;
                    }

                    inputFlg = true;
                }

                if (inputFlg == false)
                {
                    errMsg = "�ڕW����͂��Ă��������B";
                    this.SalesTarget_uGrid.Focus();
                    this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_SALESTARGET].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// ��ʏ��ύX�`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ��@False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂪕ύX����Ă��邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool CompareInputScreen()
        {
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                if (this.tNedit_Year.GetInt() != this._thisYear)
                {
                    return (false);
                }
                if ((int)this.tComboEditor_TargetContrastCd.Value != 10)
                {
                    return (false);
                }
                if (this.tEdit_SectionCode.DataText.Trim() != "")
                {
                    return (false);
                }
                if (this.tNedit_SubSectionCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_CustomerCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tEdit_EmployeeCode.DataText.Trim() != "")
                {
                    return (false);
                }
                if (this.tNedit_SalesAreaCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_BusinessTypeCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_SalesCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_EnterpriseGanreCode.GetInt() != 0)
                {
                    return (false);
                }
            }

            return CompareInputGrid();
        }

        /// <summary>
        /// �O���b�h���ύX�`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ��@False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h���ύX����Ă��邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool CompareInputGrid()
        {
            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // ���_
                case 20:    // ���_�{����
                case 221:   // ���_�{�S����
                case 222:   // ���_�{�󒍎�
                case 223:   // ���_�{���s��
                    {
                        List<EmpSalesTarget> empSalesTargetList = new List<EmpSalesTarget>();
                        ScreenToEmpSalesTargetList(ref empSalesTargetList);

                        if (empSalesTargetList.Count != this._empSalesTargetDicClone.Count)
                        {
                            return (false);
                        }

                        string targetDivideCode;
                        foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                        {
                            targetDivideCode = empSalesTarget.TargetDivideCode.Trim();
                            if (!this._empSalesTargetDicClone.ContainsKey(targetDivideCode))
                            {
                                return (false);
                            }

                            if (empSalesTarget.SalesTargetMoney != this._empSalesTargetDicClone[targetDivideCode].SalesTargetMoney)
                            {
                                return (false);
                            }

                            if (empSalesTarget.SalesTargetProfit != this._empSalesTargetDicClone[targetDivideCode].SalesTargetProfit)
                            {
                                return (false);
                            }

                            if (empSalesTarget.SalesTargetCount != this._empSalesTargetDicClone[targetDivideCode].SalesTargetCount)
                            {
                                return (false);
                            }
                        }
                        break;
                    }
                case 30:    // ���_�{���Ӑ�
                case 31:    // ���_�{�Ǝ�
                case 32:    // ���_�{�n��
                    {
                        List<CustSalesTarget> custSalesTargetList = new List<CustSalesTarget>();
                        ScreenToCustSalesTargetList(ref custSalesTargetList);

                        if (custSalesTargetList.Count != this._custSalesTargetDicClone.Count)
                        {
                            return (false);
                        }

                        string targetDivideCode;
                        foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                        {
                            targetDivideCode = custSalesTarget.TargetDivideCode.Trim();
                            if (!this._custSalesTargetDicClone.ContainsKey(targetDivideCode))
                            {
                                return (false);
                            }

                            if (custSalesTarget.SalesTargetMoney != this._custSalesTargetDicClone[targetDivideCode].SalesTargetMoney)
                            {
                                return (false);
                            }

                            if (custSalesTarget.SalesTargetProfit != this._custSalesTargetDicClone[targetDivideCode].SalesTargetProfit)
                            {
                                return (false);
                            }

                            if (custSalesTarget.SalesTargetCount != this._custSalesTargetDicClone[targetDivideCode].SalesTargetCount)
                            {
                                return (false);
                            }
                        }
                        break;
                    }
                default:    // ���_�{�̔��敪�A���i�敪
                    {
                        List<GcdSalesTarget> gcdSalesTargetList = new List<GcdSalesTarget>();
                        ScreenToGcdSalesTargetList(ref gcdSalesTargetList);

                        if (gcdSalesTargetList.Count != this._gcdSalesTargetDicClone.Count)
                        {
                            return (false);
                        }

                        string targetDivideCode;
                        foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                        {
                            targetDivideCode = gcdSalesTarget.TargetDivideCode.Trim();
                            if (!this._gcdSalesTargetDicClone.ContainsKey(targetDivideCode))
                            {
                                return (false);
                            }

                            if (gcdSalesTarget.SalesTargetMoney != this._gcdSalesTargetDicClone[targetDivideCode].SalesTargetMoney)
                            {
                                return (false);
                            }

                            if (gcdSalesTarget.SalesTargetProfit != this._gcdSalesTargetDicClone[targetDivideCode].SalesTargetProfit)
                            {
                                return (false);
                            }

                            if (gcdSalesTarget.SalesTargetCount != this._gcdSalesTargetDicClone[targetDivideCode].SalesTargetCount)
                            {
                                return (false);
                            }
                        }
                        break;
                    }
            }

            return (true);
        }

        private bool CheckSaveConfirm()
        {
            if (this.tNedit_Year.GetInt() == 0)
            {
                return (false);
            }

            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 45:
                    {
                        if (this.tNedit_EnterpriseGanreCode.GetInt() == 0)
                        {
                            return (false);
                        }

                        int enterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                        if (GetEnterpriseGanreName(enterpriseGanreCode) == "")
                        {
                            return (false);
                        }
                        break;
                    }
                default:
                    {
                        if (this.tEdit_SectionCode.DataText.Trim() == "")
                        {
                            return (false);
                        }

                        string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
                        if (GetSectionName(sectionCode) == "")
                        {
                            return (false);
                        }

                        if (targetContrastCd == 20)
                        {
                            if (this.tNedit_SubSectionCode.GetInt() == 0)
                            {
                                return (false);
                            }

                            int subSectionCode = this.tNedit_SubSectionCode.GetInt();
                            if (GetSubSectionName(subSectionCode) == "")
                            {
                                return (false);
                            }
                        }
                        else if (targetContrastCd == 30)
                        {
                            if (this.tNedit_CustomerCode.GetInt() == 0)
                            {
                                return (false);
                            }

                            int customerCode = this.tNedit_CustomerCode.GetInt();
                            //if (GetCustomerName(customerCode) == "")  // DEL 2009/06/29
                            if (!CheckCustomer(customerCode))   // ADD 2009/06/29
                            {
                                return (false);
                            }
                        }
                        else if ((targetContrastCd == 221) || (targetContrastCd == 222) || (targetContrastCd == 223))
                        {
                            if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                            {
                                return (false);
                            }

                            string employeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');
                            if (GetEmployeeName(employeeCode) == "")
                            {
                                return (false);
                            }
                        }
                        else if (targetContrastCd == 32)
                        {
                            if (this.tNedit_SalesAreaCode.GetInt() == 0)
                            {
                                return (false);
                            }

                            int salesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                            if (GetSalesAreaName(salesAreaCode) == "")
                            {
                                return (false);
                            }
                        }
                        else if (targetContrastCd == 31)
                        {
                            if (this.tNedit_BusinessTypeCode.GetInt() == 0)
                            {
                                return (false);
                            }

                            int businessTypeCode = this.tNedit_BusinessTypeCode.GetInt();
                            if (GetBusinessTypeName(businessTypeCode) == "")
                            {
                                return (false);
                            }
                        }
                        else if (targetContrastCd == 44)
                        {
                            if (this.tNedit_SalesCode.GetInt() == 0)
                            {
                                return (false);
                            }

                            int salesCode = this.tNedit_SalesCode.GetInt();
                            if (GetSalesCodeName(salesCode) == "")
                            {
                                return (false);
                            }
                        }

                        break;
                    }
            }

            // ADD 2009/05/20 ------>>>
            // �V�K�ŃL�[���ڂ��S�ē���OK�̏ꍇ�A�L�[�R���g���[����Disable����
            SetKeyControlDisable();
            // ADD 2009/05/20 ------<<<
            
            return (true);
        }
        #endregion �`�F�b�N����

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�}�X�^���������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int SearchProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            bool bStatus;

            // ���������`�F�b�N
            bStatus = CheckScreenInput(false);
            if (!bStatus)
            {
                return (-1);
            }

            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // ���_
                case 20:    // ���_�{����
                case 221:   // ���_�{�S����
                case 222:   // ���_�{�󒍎�
                case 223:   // ���_�{���s��
                    {
                        status = SearchEmpSalesTarget();
                        break;
                    }
                case 30:    // ���_�{���Ӑ�
                case 31:    // ���_�{�Ǝ�
                case 32:    // ���_�{�n��
                    {
                        status = SearchCustSalesTarget();
                        break;
                    }
                default:    // ���_�{�̔��敪�A���i�敪
                    {
                        status = SearchGcdSalesTarget();
                        break;
                    }
            }
            
            return (status);
        }

        /// <summary>
        /// ��������(�]�ƈ��ʔ���ڕW�ݒ�)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�}�X�^���������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int SearchEmpSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // ���������ݒ�
            SearchEmpSalesTargetPara searchPara = new SearchEmpSalesTargetPara();
            SetSearchEmpSalesTargetPara(ref searchPara);

            List<EmpSalesTarget> empSalesTargetList;

            // ����
            status = this._salesTargetAcs.Search(out empSalesTargetList, searchPara, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ݒ�
                        if (empSalesTargetList[0].LogicalDeleteCode == 0)
                        {
                            this.Mode_Label.Text = UPDATE_MODE;

                            // �R���g���[��Enabled����
                            SetControlEnabled(UPDATE_MODE);
                        }
                        else
                        {
                            this.Mode_Label.Text = DELETE_MODE;

                            // �R���g���[��Enabled����
                            SetControlEnabled(DELETE_MODE);
                        }

                        // �o�b�t�@�X�V
                        this._empSalesTargetDicClone.Clear();
                        foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                        {
                            this._empSalesTargetDicClone.Add(empSalesTarget.TargetDivideCode.Trim(), empSalesTarget);
                        }

                        // ��ʓW�J
                        EmpSalesTargetToScreen(this._empSalesTargetDicClone);

                        break;
                    }
                default:
                    {
                        this.Mode_Label.Text = INSERT_MODE;
                        break;
                    }
            }

            this._searchFlg = true;

            return (status);
        }

        /// <summary>
        /// ��������(���Ӑ�ʔ���ڕW�ݒ�)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�}�X�^���������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int SearchCustSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // ���������ݒ�
            SearchCustSalesTargetPara searchPara = new SearchCustSalesTargetPara();
            SetSearchCustSalesTargetPara(ref searchPara);

            List<CustSalesTarget> custSalesTargetList;

            // ����
            status = this._salesTargetAcs.Search(out custSalesTargetList, searchPara, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ݒ�
                        if (custSalesTargetList[0].LogicalDeleteCode == 0)
                        {
                            this.Mode_Label.Text = UPDATE_MODE;

                            // �R���g���[��Enabled����
                            SetControlEnabled(UPDATE_MODE);
                        }
                        else
                        {
                            this.Mode_Label.Text = DELETE_MODE;

                            // �R���g���[��Enabled����
                            SetControlEnabled(DELETE_MODE);
                        }

                        // �o�b�t�@�X�V
                        this._custSalesTargetDicClone.Clear();
                        foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                        {
                            this._custSalesTargetDicClone.Add(custSalesTarget.TargetDivideCode.Trim(), custSalesTarget);
                        }

                        // ��ʓW�J
                        CustSalesTargetToScreen(this._custSalesTargetDicClone);

                        break;
                    }
                default:
                    {
                        this.Mode_Label.Text = INSERT_MODE;
                        break;
                    }
            }

            this._searchFlg = true;

            return (status);
        }

        /// <summary>
        /// ��������(���i�ʔ���ڕW�ݒ�)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�}�X�^���������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int SearchGcdSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // ���������ݒ�
            SearchGcdSalesTargetPara searchPara = new SearchGcdSalesTargetPara();
            SetSearchGcdSalesTargetPara(ref searchPara);

            List<GcdSalesTarget> gcdSalesTargetList;

            // ����
            status = this._salesTargetAcs.Search(out gcdSalesTargetList, searchPara, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ݒ�
                        if (gcdSalesTargetList[0].LogicalDeleteCode == 0)
                        {
                            this.Mode_Label.Text = UPDATE_MODE;

                            // �R���g���[��Enabled����
                            SetControlEnabled(UPDATE_MODE);
                        }
                        else
                        {
                            this.Mode_Label.Text = DELETE_MODE;

                            // �R���g���[��Enabled����
                            SetControlEnabled(DELETE_MODE);
                        }

                        // �o�b�t�@�X�V
                        this._gcdSalesTargetDicClone.Clear();
                        foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                        {
                            this._gcdSalesTargetDicClone.Add(gcdSalesTarget.TargetDivideCode.Trim(), gcdSalesTarget);
                        }

                        // ��ʓW�J
                        GcdSalesTargetToScreen(this._gcdSalesTargetDicClone);

                        break;
                    }
                default:
                    {
                        this.Mode_Label.Text = INSERT_MODE;
                        break;
                    }
            }

            this._searchFlg = true;

            return (status);
        }
        #endregion ��������

        #region �O���b�h�֘A
        /// <summary>
        /// ���v�ڕW�擾����
        /// </summary>
        /// <param name="columnIndex">��C���f�b�N�X(2:����ڕW 3:�e���ڕW 4:���ʖڕW)</param>
        /// <returns>���v�ڕW</returns>
        /// <remarks>
        /// <br>Note       : ���v�ڕW���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private double GetTotalTarget(int columnIndex)
        {
            double totalTarget = 0;

            if (columnIndex < 2)
            {
                return totalTarget;
            }

            for (int index = 0; index < 12; index++)
            {
                if ((this.SalesTarget_uGrid.Rows[index].Cells[columnIndex].Value == DBNull.Value) ||
                    ((string)this.SalesTarget_uGrid.Rows[index].Cells[columnIndex].Value == ""))
                {
                    continue;
                }

                totalTarget += double.Parse((string)this.SalesTarget_uGrid.Rows[index].Cells[columnIndex].Value);
            }

            return totalTarget;
        }

        /// <summary>
        /// �Z���l�ϊ�����(�Z���l��Double�^)
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <returns>�Z���l</returns>
        /// <remarks>
        /// <br>Note       : �Z���l��Double�^�ɕϊ����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private double ChangeCellValue(object cellValue)
        {
            double target = 0;

            if ((cellValue != DBNull.Value) && (cellValue != null) && ((string)cellValue != ""))
            {
                target = double.Parse((string)cellValue);
            }

            return target;
        }
        #endregion �O���b�h�֘A

        #region ���������ݒ�
        /// <summary>
        /// ���������ݒ菈��(�]�ƈ��ʔ���ڕW)
        /// </summary>
        /// <param name="searchPara">�]�ƈ��ʔ���ڕW��������</param>
        /// <remarks>
        /// <br>Note       : ����������ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// <br>Update Note: 2010/12/20 ������</br>
        /// <br>             ��Q���ǑΉ��P�Q��</br>
        /// </remarks>
        private void SetSearchEmpSalesTargetPara(ref SearchEmpSalesTargetPara searchPara)
        {
            // ��ƃR�[�h
            searchPara.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h
            searchPara.SelectSectCd = new string[1];
            searchPara.SelectSectCd[0] = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            // �ڕW�ݒ�敪
            searchPara.TargetSetCd = 10;
            
            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:
                    {
                        // �ڕW�Δ�敪
                        searchPara.TargetContrastCd = 10;
                        break;
                    }
                case 20:
                    {
                        // �ڕW�Δ�敪
                        searchPara.TargetContrastCd = 20;
                        // ����R�[�h
                        searchPara.SubSectionCode = this.tNedit_SubSectionCode.GetInt();
                        break;
                    }
                case 221:
                    {
                        // �ڕW�Δ�敪
                        searchPara.TargetContrastCd = 22;
                        // �]�ƈ��敪
                        searchPara.EmployeeDivCd = 10;
                        // �]�ƈ��R�[�h
                        searchPara.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');
                        break;
                    }
                case 222:
                    {
                        // �ڕW�Δ�敪
                        searchPara.TargetContrastCd = 22;
                        // �]�ƈ��敪
                        searchPara.EmployeeDivCd = 20;
                        // �]�ƈ��R�[�h
                        searchPara.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');
                        break;
                    }
                case 223:
                    {
                        // �ڕW�Δ�敪
                        searchPara.TargetContrastCd = 22;
                        // �]�ƈ��敪
                        searchPara.EmployeeDivCd = 30;
                        // �]�ƈ��R�[�h
                        searchPara.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');
                        break;
                    }
            }

            // �K�p�J�n��(�J�n)
            searchPara.StartApplyStaDate = this._startMonthDateList[0];
            // �K�p�I����(�I��)
            searchPara.EndApplyEndDate = this._endMonthDateList[11];
            // ---ADD 2010/12/20--------->>>>>
            // �ڕW�敪�R�[�h
            searchPara.TargetDivideCode = this._yearMonthList[0].Year.ToString("0000") + this._yearMonthList[0].Month.ToString("00");
            // ---ADD 2010/12/20---------<<<<<
        }

        /// <summary>
        /// ���������ݒ菈��(���Ӑ�ʔ���ڕW)
        /// </summary>
        /// <param name="searchPara">���Ӑ�ʔ���ڕW��������</param>
        /// <remarks>
        /// <br>Note       : ����������ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// <br>Update Note: 2010/12/20 ������</br>
        /// <br>             ��Q���ǑΉ��P�Q��</br>
        /// </remarks>
        private void SetSearchCustSalesTargetPara(ref SearchCustSalesTargetPara searchPara)
        {
            // ��ƃR�[�h
            searchPara.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h
            searchPara.SelectSectCd = new string[1];
            searchPara.SelectSectCd[0] = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            // �ڕW�ݒ�敪
            searchPara.TargetSetCd = 10;

            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 30:
                    {
                        // �ڕW�Δ�敪
                        searchPara.TargetContrastCd = 30;
                        // ���Ӑ�R�[�h
                        searchPara.CustomerCode = this.tNedit_CustomerCode.GetInt();
                        break;
                    }
                case 31:
                    {
                        // �ڕW�Δ�敪
                        searchPara.TargetContrastCd = 31;
                        // �Ǝ�R�[�h
                        searchPara.BusinessTypeCode = this.tNedit_BusinessTypeCode.GetInt();
                        break;
                    }
                case 32:
                    {
                        // �ڕW�Δ�敪
                        searchPara.TargetContrastCd = 32;
                        // �n��R�[�h
                        searchPara.SalesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                        break;
                    }
            }

            // �K�p�J�n��(�J�n)
            searchPara.StartApplyStaDate = this._startMonthDateList[0];
            // �K�p�I����(�I��)
            searchPara.EndApplyEndDate = this._endMonthDateList[11];
            // ---ADD 2010/12/20--------->>>>>
            // �ڕW�敪�R�[�h
            searchPara.TargetDivideCode = this._yearMonthList[0].Year.ToString("0000") + this._yearMonthList[0].Month.ToString("00");
            // ---ADD 2010/12/20---------<<<<<
        }

        /// <summary>
        /// ���������ݒ菈��(���i�ʔ���ڕW)
        /// </summary>
        /// <param name="searchPara">���i�ʔ���ڕW��������</param>
        /// <remarks>
        /// <br>Note       : ����������ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// <br>Update Note: 2010/12/20 ������</br>
        /// <br>             ��Q���ǑΉ��P�Q��</br>
        /// </remarks>
        private void SetSearchGcdSalesTargetPara(ref SearchGcdSalesTargetPara searchPara)
        {
            // ��ƃR�[�h
            searchPara.EnterpriseCode = this._enterpriseCode;
            // �ڕW�ݒ�敪
            searchPara.TargetSetCd = 10;

            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 44:
                    {
                        // ���_�R�[�h
                        searchPara.SelectSectCd = new string[1];
                        searchPara.SelectSectCd[0] = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
                        // �ڕW�Δ�敪
                        searchPara.TargetContrastCd = 44;
                        // �̔��敪�R�[�h
                        searchPara.SalesCode = this.tNedit_SalesCode.GetInt();
                        break;
                    }
                case 45:
                    {
                        // ���_�R�[�h
                        searchPara.SelectSectCd = new string[1];
                        searchPara.SelectSectCd[0] = "";
                        // �ڕW�Δ�敪
                        searchPara.TargetContrastCd = 45;
                        // ���i�敪�R�[�h
                        searchPara.EnterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                        break;
                    }
            }

            // �K�p�J�n��(�J�n)
            searchPara.StartApplyStaDate = this._startMonthDateList[0];
            // �K�p�I����(�I��)
            searchPara.EndApplyEndDate = this._endMonthDateList[11];
            // ---ADD 2010/12/20--------->>>>>
            // �ڕW�敪�R�[�h
            searchPara.TargetDivideCode = this._yearMonthList[0].Year.ToString("0000") + this._yearMonthList[0].Month.ToString("00");
            // ---ADD 2010/12/20---------<<<<<
        }
        #endregion ���������ݒ�

        #region ��ʏ��擾
        /// <summary>
        /// ��ʏ��擾����(�]�ƈ��ʔ���ڕW�ݒ�}�X�^)
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ����擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ScreenToEmpSalesTargetList(ref List<EmpSalesTarget> empSalesTargetList)
        {
            for (int index = 0; index < 12; index++)
            {
                // �Z���l�ϊ�
                if ((ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) == 0))
                {
                    continue;
                }

                EmpSalesTarget empSalesTarget = new EmpSalesTarget();

                // ��ƃR�[�h
                empSalesTarget.EnterpriseCode = this._enterpriseCode;
                // ���_�R�[�h
                empSalesTarget.SectionCode = this.tEdit_SectionCode.DataText.Trim();
                // �ڕW�ݒ�敪
                empSalesTarget.TargetSetCd = 10;

                int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                switch (targetContrastCd)
                {
                    case 10:
                        {
                            // �ڕW�Δ�敪
                            empSalesTarget.TargetContrastCd = 10;
                            break;
                        }
                    case 20:
                        {
                            // �ڕW�Δ�敪
                            empSalesTarget.TargetContrastCd = 20;
                            // ����R�[�h
                            empSalesTarget.SubSectionCode = this.tNedit_SubSectionCode.GetInt();
                            break;
                        }
                    case 221:
                        {
                            // �ڕW�Δ�敪
                            empSalesTarget.TargetContrastCd = 22;
                            // �]�ƈ��敪
                            empSalesTarget.EmployeeDivCd = 10;
                            // �]�ƈ��R�[�h
                            empSalesTarget.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                            break;
                        }
                    case 222:
                        {
                            // �ڕW�Δ�敪
                            empSalesTarget.TargetContrastCd = 22;
                            // �]�ƈ��敪
                            empSalesTarget.EmployeeDivCd = 20;
                            // �]�ƈ��R�[�h
                            empSalesTarget.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                            break;
                        }
                    case 223:
                        {
                            // �ڕW�Δ�敪
                            empSalesTarget.TargetContrastCd = 22;
                            // �]�ƈ��敪
                            empSalesTarget.EmployeeDivCd = 30;
                            // �]�ƈ��R�[�h
                            empSalesTarget.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                            break;
                        }
                }
                // �ڕW�敪�R�[�h
                empSalesTarget.TargetDivideCode = this._yearMonthList[index].Year.ToString("0000") + this._yearMonthList[index].Month.ToString("00");
                // �K�p�J�n��
                empSalesTarget.ApplyStaDate = this._startMonthDateList[index];
                // �K�p�I����
                empSalesTarget.ApplyEndDate = this._endMonthDateList[index];
                // ����ڕW���z
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) != 0)
                {
                    empSalesTarget.SalesTargetMoney = (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value);
                }
                // ����ڕW�e���z
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) != 0)
                {
                    empSalesTarget.SalesTargetProfit = (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value);
                }
                // ����ڕW����
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) != 0)
                {
                    empSalesTarget.SalesTargetCount = ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value);
                }

                empSalesTargetList.Add(empSalesTarget);
            }
        }

        /// <summary>
        /// ��ʏ��擾����(���Ӑ�ʔ���ڕW�ݒ�}�X�^)
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ����擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ScreenToCustSalesTargetList(ref List<CustSalesTarget> custSalesTargetList)
        {
            for (int index = 0; index < 12; index++)
            {
                // �Z���l�ϊ�
                if ((ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) == 0))
                {
                    continue;
                }

                CustSalesTarget custSalesTarget = new CustSalesTarget();

                // ��ƃR�[�h
                custSalesTarget.EnterpriseCode = this._enterpriseCode;
                // ���_�R�[�h
                custSalesTarget.SectionCode = this.tEdit_SectionCode.DataText.Trim();
                // �ڕW�ݒ�敪
                custSalesTarget.TargetSetCd = 10;

                int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                switch (targetContrastCd)
                {
                    case 30:
                        {
                            // �ڕW�Δ�敪
                            custSalesTarget.TargetContrastCd = 30;
                            // ���Ӑ�R�[�h
                            custSalesTarget.CustomerCode = this.tNedit_CustomerCode.GetInt();
                            break;
                        }
                    case 31:
                        {
                            // �ڕW�Δ�敪
                            custSalesTarget.TargetContrastCd = 31;
                            // �Ǝ�R�[�h
                            custSalesTarget.BusinessTypeCode = this.tNedit_BusinessTypeCode.GetInt();
                            break;
                        }
                    case 32:
                        {
                            // �ڕW�Δ�敪
                            custSalesTarget.TargetContrastCd = 32;
                            // �n��R�[�h
                            custSalesTarget.SalesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                            break;
                        }
                }

                // �ڕW�敪�R�[�h
                custSalesTarget.TargetDivideCode = this._yearMonthList[index].Year.ToString("0000") + this._yearMonthList[index].Month.ToString("00");
                // �K�p�J�n��
                custSalesTarget.ApplyStaDate = this._startMonthDateList[index];
                // �K�p�I����
                custSalesTarget.ApplyEndDate = this._endMonthDateList[index];
                // ����ڕW���z
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) != 0)
                {
                    custSalesTarget.SalesTargetMoney = (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value);
                }
                // ����ڕW�e���z
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) != 0)
                {
                    custSalesTarget.SalesTargetProfit = (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value);
                }
                // ����ڕW����
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) != 0)
                {
                    custSalesTarget.SalesTargetCount = ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value);
                }

                custSalesTargetList.Add(custSalesTarget);
            }
        }

        /// <summary>
        /// ��ʏ��擾����(���i�ʔ���ڕW�ݒ�}�X�^)
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ����擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ScreenToGcdSalesTargetList(ref List<GcdSalesTarget> gcdSalesTargetList)
        {
            for (int index = 0; index < 12; index++)
            {
                // �Z���l�ϊ�
                if ((ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) == 0))
                {
                    continue;
                }

                GcdSalesTarget gcdSalesTarget = new GcdSalesTarget();

                // ��ƃR�[�h
                gcdSalesTarget.EnterpriseCode = this._enterpriseCode;
                // �ڕW�ݒ�敪
                gcdSalesTarget.TargetSetCd = 10;

                int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                switch (targetContrastCd)
                {
                    case 44:
                        {
                            // ���_�R�[�h
                            gcdSalesTarget.SectionCode = this.tEdit_SectionCode.DataText.Trim();
                            // �ڕW�Δ�敪
                            gcdSalesTarget.TargetContrastCd = 44;
                            // �̔��敪�R�[�h
                            gcdSalesTarget.SalesCode = this.tNedit_SalesCode.GetInt();
                            break;
                        }
                    case 45:
                        {
                            // ���_�R�[�h
                            gcdSalesTarget.SectionCode = "";
                            // �ڕW�Δ�敪
                            gcdSalesTarget.TargetContrastCd = 45;
                            // ���i�敪�R�[�h
                            gcdSalesTarget.EnterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                            break;
                        }
                }

                // �ڕW�敪�R�[�h
                gcdSalesTarget.TargetDivideCode = this._yearMonthList[index].Year.ToString("0000") + this._yearMonthList[index].Month.ToString("00");
                // �K�p�J�n��
                gcdSalesTarget.ApplyStaDate = this._startMonthDateList[index];
                // �K�p�I����
                gcdSalesTarget.ApplyEndDate = this._endMonthDateList[index];
                // ����ڕW���z
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) != 0)
                {
                    gcdSalesTarget.SalesTargetMoney = (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value);
                }
                // ����ڕW�e���z
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) != 0)
                {
                    gcdSalesTarget.SalesTargetProfit = (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value);
                }
                // ����ڕW����
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) != 0)
                {
                    gcdSalesTarget.SalesTargetCount = ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value);
                }

                gcdSalesTargetList.Add(gcdSalesTarget);
            }
        }
        #endregion ��ʏ��擾

        #region ��ʓW�J
        /// <summary>
        /// ��ʓW�J����(�]�ƈ��ʔ���ڕW)
        /// </summary>
        /// <param name="empSalesTargetList">�]�ƈ��ʔ���ڕW���X�g</param>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ���ڕW���X�g����ʓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void EmpSalesTargetToScreen(Dictionary<string, EmpSalesTarget> empSalesTargetDic)
        {
            //------------------------------
            // �ڕW��񏉊���
            //------------------------------
            this.tNedit_SalesTargetSale.Clear();
            this.tNedit_SalesTargetProfit.Clear();
            this.tNedit_SalesTargetCount.Clear();

            for (int index = 0; index < 13; index++)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_RATIO].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            //------------------------------
            // �ڕW���ݒ�
            //------------------------------
            double totalMoney = 0;
            double totalProfit = 0;
            double totalCount = 0;

            for (int index = 0; index < 12; index++)
            {
                string targetDivideCode = this._yearMonthList[index].Year.ToString("0000") + this._yearMonthList[index].Month.ToString("00");

                if (!empSalesTargetDic.ContainsKey(targetDivideCode))
                {
                    continue;
                }

                EmpSalesTarget empSalesTarget = (EmpSalesTarget)empSalesTargetDic[targetDivideCode];

                // ����ڕW
                if (empSalesTarget.SalesTargetMoney != 0)
                {
                    totalMoney += empSalesTarget.SalesTargetMoney;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = empSalesTarget.SalesTargetMoney.ToString(FORMAT_NUM);
                }
                // �e���ڕW
                if (empSalesTarget.SalesTargetProfit != 0)
                {
                    totalProfit += empSalesTarget.SalesTargetProfit;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = empSalesTarget.SalesTargetProfit.ToString(FORMAT_NUM);
                }
                // ���ʖڕW
                if (empSalesTarget.SalesTargetCount != 0)
                {
                    totalCount += empSalesTarget.SalesTargetCount;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = empSalesTarget.SalesTargetCount.ToString(FORMAT_NUM);
                }
            }

            //------------------------------
            // ���v�s�ݒ�
            //------------------------------
            if (totalMoney != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Value = totalMoney.ToString(FORMAT_NUM);
            }
            if (totalProfit != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Value = totalProfit.ToString(FORMAT_NUM);
            }
            if (totalCount != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Value = totalCount.ToString(FORMAT_NUM);
            }
        }

        /// <summary>
        /// ��ʓW�J����(���Ӑ�ʔ���ڕW)
        /// </summary>
        /// <param name="custSalesTargetList">���Ӑ�ʔ���ڕW���X�g</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW���X�g����ʓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void CustSalesTargetToScreen(Dictionary<string, CustSalesTarget> custSalesTargetDic)
        {
            //------------------------------
            // �ڕW��񏉊���
            //------------------------------
            this.tNedit_SalesTargetSale.Clear();
            this.tNedit_SalesTargetProfit.Clear();
            this.tNedit_SalesTargetCount.Clear();

            for (int index = 0; index < 13; index++)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_RATIO].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            //------------------------------
            // �ڕW���ݒ�
            //------------------------------
            double totalMoney = 0;
            double totalProfit = 0;
            double totalCount = 0;

            for (int index = 0; index < 12; index++)
            {
                string targetDivideCode = this._yearMonthList[index].Year.ToString("0000") + this._yearMonthList[index].Month.ToString("00");

                if (!custSalesTargetDic.ContainsKey(targetDivideCode))
                {
                    continue;
                }

                CustSalesTarget custSalesTarget = (CustSalesTarget)custSalesTargetDic[targetDivideCode];

                // ����ڕW
                if (custSalesTarget.SalesTargetMoney != 0)
                {
                    totalMoney += custSalesTarget.SalesTargetMoney;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = custSalesTarget.SalesTargetMoney.ToString(FORMAT_NUM);
                }
                // �e���ڕW
                if (custSalesTarget.SalesTargetProfit != 0)
                {
                    totalProfit += custSalesTarget.SalesTargetProfit;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = custSalesTarget.SalesTargetProfit.ToString(FORMAT_NUM);
                }
                // ���ʖڕW
                if (custSalesTarget.SalesTargetCount != 0)
                {
                    totalCount += custSalesTarget.SalesTargetCount;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = custSalesTarget.SalesTargetCount.ToString(FORMAT_NUM);
                }
            }

            //------------------------------
            // ���v�s�ݒ�
            //------------------------------
            if (totalMoney != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Value = totalMoney.ToString(FORMAT_NUM);
            }
            if (totalProfit != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Value = totalProfit.ToString(FORMAT_NUM);
            }
            if (totalCount != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Value = totalCount.ToString(FORMAT_NUM);
            }
        }

        /// <summary>
        /// ��ʓW�J����(���i�ʔ���ڕW)
        /// </summary>
        /// <param name="gcdSalesTargetList">���i�ʔ���ڕW���X�g</param>
        /// <remarks>
        /// <br>Note       : ���i�ʔ���ڕW���X�g����ʓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void GcdSalesTargetToScreen(Dictionary<string, GcdSalesTarget> gcdSalesTargetDic)
        {
            //------------------------------
            // �ڕW��񏉊���
            //------------------------------
            this.tNedit_SalesTargetSale.Clear();
            this.tNedit_SalesTargetProfit.Clear();
            this.tNedit_SalesTargetCount.Clear();

            for (int index = 0; index < 13; index++)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_RATIO].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            //------------------------------
            // �ڕW���ݒ�
            //------------------------------
            double totalMoney = 0;
            double totalProfit = 0;
            double totalCount = 0;

            for (int index = 0; index < 12; index++)
            {
                string targetDivideCode = this._yearMonthList[index].Year.ToString("0000") + this._yearMonthList[index].Month.ToString("00");

                if (!gcdSalesTargetDic.ContainsKey(targetDivideCode))
                {
                    continue;
                }

                GcdSalesTarget gcdSalesTarget = (GcdSalesTarget)gcdSalesTargetDic[targetDivideCode];

                // ����ڕW
                if (gcdSalesTarget.SalesTargetMoney != 0)
                {
                    totalMoney += gcdSalesTarget.SalesTargetMoney;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = gcdSalesTarget.SalesTargetMoney.ToString(FORMAT_NUM);
                }
                // �e���ڕW
                if (gcdSalesTarget.SalesTargetProfit != 0)
                {
                    totalProfit += gcdSalesTarget.SalesTargetProfit;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = gcdSalesTarget.SalesTargetProfit.ToString(FORMAT_NUM);
                }
                // ���ʖڕW
                if (gcdSalesTarget.SalesTargetCount != 0)
                {
                    totalCount += gcdSalesTarget.SalesTargetCount;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = gcdSalesTarget.SalesTargetCount.ToString(FORMAT_NUM);
                }
            }

            //------------------------------
            // ���v�s�ݒ�
            //------------------------------
            if (totalMoney != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Value = totalMoney.ToString(FORMAT_NUM);
            }
            if (totalProfit != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Value = totalProfit.ToString(FORMAT_NUM);
            }
            if (totalCount != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Value = totalCount.ToString(FORMAT_NUM);
            }
        }
        #endregion ��ʓW�J

        #region �r������
        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �r��������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            string errMsg = "";

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        errMsg = "���ɑ��[�����X�V����Ă��܂��B";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        errMsg = "���ɑ��[�����폜����Ă��܂��B";
                        break;
                    }
            }

            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           errMsg,
                           status,
                           MessageBoxButtons.OK,
                           MessageBoxDefaultButton.Button1);
        }
        #endregion �r������

        #region ���b�Z�[�W�{�b�N�X�\��

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <param name="defaultButton">�����\���{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         ASSEMBLY_ID,                       // �A�Z���u��ID
                                         message,                           // �\�����郁�b�Z�[�W
                                         status,                            // �X�e�[�^�X�l
                                         msgButton,                         // �\������{�^��
                                         defaultButton);                    // �����\���{�^��
            return dialogResult;
        }

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="methodName">��������</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // �e�E�B���h�E�t�H�[��
                                         errLevel,			                // �G���[���x��
                                         this.Name,						    // �v���O��������
                                         ASSEMBLY_ID, 		  �@�@			// �A�Z���u��ID
                                         methodName,						// ��������
                                         "",					            // �I�y���[�V����
                                         message,	                        // �\�����郁�b�Z�[�W
                                         status,							// �X�e�[�^�X�l
                                         this._salesTargetAcs,				// �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }

        #endregion ���b�Z�[�W�{�b�N�X�\��

        #region ������ҏW����

        /// <summary>
        /// �J���}�E�s���I�h�폜����
        /// </summary>
        /// <param name="targetText">�J���}�E�s���I�h�폜�O�e�L�X�g</param>
        /// <param name="retText">�J���}�E�s���I�h�폜�ς݃e�L�X�g</param>
        /// <param name="periodDelFlg">�s���I�h�폜�t���O(True:�J���}�E�s���I�h�폜  False:�J���}�폜)</param>
        /// <remarks>
        /// <br>Note		: �Ώۂ̃e�L�X�g����J���}�E�s���I�h���폜���܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void RemoveCommaPeriod(string targetText, out string retText, bool periodDelFlg)
        {
            retText = "";

            // �Z���l�ҏW�p�ɃJ���}�E�s���I�h�폜
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // �J���}�E�s���I�h�폜
                if (periodDelFlg == true)
                {
                    if ((targetText[i].ToString() == ",") || (targetText[i].ToString() == "."))
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
                // �J���}�̂ݍ폜
                else
                {
                    if (targetText[i].ToString() == ",")
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
            }

            retText = targetText;
        }

        /// <summary>
        /// �����_�擾����
        /// </summary>
        /// <param name="targetText">�`�F�b�N�Ώۃe�L�X�g</param>
        /// <param name="retText">���������e�L�X�g</param>
        /// <remarks>
        /// <br>Note		: �Ώۂ̃e�L�X�g���珬�������݂̂�Ԃ��܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void GetDecimal(string targetText, out string retText)
        {
            retText = "";

            for (int i = targetText.IndexOf(".") + 1; i < targetText.Length; i++)
            {
                retText += targetText[i].ToString();
            }
        }

        #endregion ������ҏW����

        #endregion �� Private Methods


        #region �� Control Events

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : Form_Load���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void PMKHN09251UA_Load(object sender, EventArgs e)
        {
            // ��ʏ����ݒ�
            SetScreenInitialSetting();

            // ��ʏ���������
            ClearScreen();
        }

        #region �K�C�h�{�^������
        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // ���_�R�[�h�ݒ�
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    // ���_���ݒ�
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // �ۑ�����
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevSectionCode = secInfoSet.SectionCode.Trim();
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tEdit_SectionCode.DataText = this._prevSectionCode;
                                        this.tEdit_SectionName.DataText = GetSectionName(this._prevSectionCode);
                                        return;
                                    }
                            }
                        }

                        // ����
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        }
                        else
                        {
                            this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        }
                    }

                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.SectionGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ����K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SubSectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SubSection subSection;

                int status = this._subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode);
                if (status == 0)
                {
                    // ����R�[�h�ݒ�
                    this.tNedit_SubSectionCode.SetInt(subSection.SubSectionCode);
                    // ���喼�ݒ�
                    this.tEdit_SubSectionName.DataText = subSection.SubSectionName.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSubSectionCode = subSection.SubSectionCode;
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // �ۑ�����
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevSubSectionCode = subSection.SubSectionCode;
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tNedit_SubSectionCode.SetInt(this._prevSubSectionCode);
                                        this.tEdit_SubSectionName.DataText = GetSubSectionName(this._prevSubSectionCode);
                                        return;
                                    }
                            }
                        }

                        // ����
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSubSectionCode = subSection.SubSectionCode;
                        }
                        else
                        {
                            this._prevSubSectionCode = subSection.SubSectionCode;
                        }
                    }

                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.SubSectionGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (this._cusotmerGuideSelected == true)
                {
                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.CustomerGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�I�����ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            int status;

            // ���Ӑ�R�[�h�ݒ�
            this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);
            // ���Ӑ於�ݒ�
            this.tEdit_CustomerName.DataText = customerSearchRet.Snm.Trim();

            if (CheckSaveConfirm() == false)
            {
                this._prevCustomerCode = customerSearchRet.CustomerCode;
                return;
            }
            else
            {
                if (this._searchFlg)
                {
                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                        "",
                                                        0,
                                                        MessageBoxButtons.YesNoCancel,
                                                        MessageBoxDefaultButton.Button2);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            {
                                // �ۑ�����
                                status = SaveProc();
                                if (status != 0)
                                {
                                    this._prevCustomerCode = customerSearchRet.CustomerCode;
                                    return;
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        case DialogResult.Cancel:
                            {
                                this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
                                this.tEdit_CustomerName.DataText = GetCustomerName(this._prevCustomerCode);
                                return;
                            }
                    }
                }

                // ����
                status = SearchProc();
                if (status != 0)
                {
                    ClearGrid();
                    this._prevCustomerCode = customerSearchRet.CustomerCode;
                }
                else
                {
                    this._prevCustomerCode = customerSearchRet.CustomerCode;
                }
            }

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �]�ƈ��K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void EmployeeGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Employee employee;

                int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, false, out employee);
                if (status == 0)
                {
                    // �]�ƈ��R�[�h�ݒ�
                    this.tEdit_EmployeeCode.DataText = employee.EmployeeCode.Trim();
                    // �]�ƈ����ݒ�
                    this.tEdit_EmployeeName.DataText = employee.Name.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // �ۑ�����
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevEmployeeCode = employee.EmployeeCode.Trim();
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tEdit_EmployeeCode.DataText = this._prevEmployeeCode;
                                        this.tEdit_EmployeeName.DataText = GetEmployeeName(this._prevEmployeeCode);
                                        return;
                                    }
                            }
                        }

                        // ����
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        }
                        else
                        {
                            this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        }
                    }

                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.EmployeeGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �n��K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesAreaGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);
                if (status == 0)
                {
                    // �n��R�[�h�ݒ�
                    this.tNedit_SalesAreaCode.SetInt(userGdBd.GuideCode);
                    // �n�於�ݒ�
                    this.tEdit_SalesAreaName.DataText = userGdBd.GuideName.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSalesAreaCode = userGdBd.GuideCode;
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // �ۑ�����
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevSalesAreaCode = userGdBd.GuideCode;
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tNedit_SalesAreaCode.SetInt(this._prevSalesAreaCode);
                                        this.tEdit_SalesAreaName.DataText = GetSalesAreaName(this._prevSalesAreaCode);
                                        return;
                                    }
                            }
                        }

                        // ����
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSalesAreaCode = userGdBd.GuideCode;
                        }
                        else
                        {
                            this._prevSalesAreaCode = userGdBd.GuideCode;
                        }
                    }

                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.SalesAreaGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ǝ�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void BusinessTypeGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);
                if (status == 0)
                {
                    // �Ǝ�R�[�h�ݒ�
                    this.tNedit_BusinessTypeCode.SetInt(userGdBd.GuideCode);
                    // �Ǝ햼�ݒ�
                    this.tEdit_BusinessTypeName.DataText = userGdBd.GuideName.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevBusinessTypeCode = userGdBd.GuideCode;
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // �ۑ�����
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevBusinessTypeCode = userGdBd.GuideCode;
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tNedit_BusinessTypeCode.SetInt(this._prevBusinessTypeCode);
                                        this.tEdit_BusinessTypeName.DataText = GetBusinessTypeName(this._prevBusinessTypeCode);
                                        return;
                                    }
                            }
                        }

                        // ����
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevBusinessTypeCode = userGdBd.GuideCode;
                        }
                        else
                        {
                            this._prevBusinessTypeCode = userGdBd.GuideCode;
                        }
                    }

                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.BusinessTypeGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �̔��敪�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesCodeGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 71);
                if (status == 0)
                {
                    // �̔��敪�R�[�h�ݒ�
                    this.tNedit_SalesCode.SetInt(userGdBd.GuideCode);
                    // �̔��敪���ݒ�
                    this.tEdit_SalesCodeName.DataText = userGdBd.GuideName.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSalesCode = userGdBd.GuideCode;
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // �ۑ�����
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevSalesCode = userGdBd.GuideCode;
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tNedit_SalesCode.SetInt(this._prevSalesCode);
                                        this.tEdit_SalesCodeName.DataText = GetSalesCodeName(this._prevSalesCode);
                                        return;
                                    }
                            }
                        }

                        // ����
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSalesCode = userGdBd.GuideCode;
                        }
                        else
                        {
                            this._prevSalesCode = userGdBd.GuideCode;
                        }
                    }

                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.SalesCodeGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���i�敪�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void EnterpriseGanreGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 41);
                if (status == 0)
                {
                    // ���i�敪�R�[�h�ݒ�
                    this.tNedit_EnterpriseGanreCode.SetInt(userGdBd.GuideCode);
                    // ���i�敪���ݒ�
                    this.tEdit_EnterpriseGanreName.DataText = userGdBd.GuideName.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevEnterpriseGanreCode = userGdBd.GuideCode;
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // �ۑ�����
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevEnterpriseGanreCode = userGdBd.GuideCode;
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tNedit_EnterpriseGanreCode.SetInt(this._prevEnterpriseGanreCode);
                                        this.tEdit_EnterpriseGanreName.DataText = GetEnterpriseGanreName(this._prevEnterpriseGanreCode);
                                        return;
                                    }
                            }
                        }

                        // ����
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevEnterpriseGanreCode = userGdBd.GuideCode;
                        }
                        else
                        {
                            this._prevEnterpriseGanreCode = userGdBd.GuideCode;
                        }
                    }

                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.EnterpriseGanreGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion �K�C�h�{�^������

        #region �O���b�h�֘A

        /// <summary>
        /// AfterEnterEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z�����ҏW���[�h�ɂȂ������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesTarget_uGrid_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            if ((this.SalesTarget_uGrid.ActiveCell.Value == DBNull.Value) || 
                ((string)this.SalesTarget_uGrid.ActiveCell.Value == ""))
            {
                return;
            }

            string retText;
            string targetText = (string)this.SalesTarget_uGrid.ActiveCell.Value;

            // �J���}�̂ݍ폜
            RemoveCommaPeriod(targetText, out retText, false);

            this.SalesTarget_uGrid.ActiveCell.Value = retText;
            this.SalesTarget_uGrid.ActiveCell.SelStart = 0;
            this.SalesTarget_uGrid.ActiveCell.SelLength = retText.Length;
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z���̕ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesTarget_uGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            int columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;

            if ((this.SalesTarget_uGrid.ActiveCell.Value != DBNull.Value) &&
                ((string)this.SalesTarget_uGrid.ActiveCell.Value != ""))
            {
                string retText;
                string targetText = (string)this.SalesTarget_uGrid.ActiveCell.Value;

                // �J���}�̂ݍ폜
                RemoveCommaPeriod(targetText, out retText, false);

                double targetValue = double.Parse(retText);

                // ���[�U�[�艿�̏ꍇ
                if (columnIndex == 1)
                {
                    this.SalesTarget_uGrid.ActiveCell.Value = targetValue.ToString("N");
                }
                else
                {
                    this.SalesTarget_uGrid.ActiveCell.Value = targetValue.ToString(FORMAT_NUM);
                }
            }

            // ���v�ڕW�擾
            double totalTarget = GetTotalTarget(columnIndex);

            if (totalTarget == 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[columnIndex].Value = "";
            }
            else
            {
                this.SalesTarget_uGrid.Rows[12].Cells[columnIndex].Value = totalTarget.ToString(FORMAT_NUM);
            }
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h���A�N�e�B�u��ԂŃL�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesTarget_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                if (this.SalesTarget_uGrid.ActiveRow == null)
                {
                    rowIndex = 0;
                    columnIndex = 1;
                }
                else
                {
                    rowIndex = this.SalesTarget_uGrid.ActiveRow.Index;
                    columnIndex = 1;
                }
            }
            else
            {
                rowIndex = this.SalesTarget_uGrid.ActiveCell.Row.Index;
                columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        e.Handled = true;

                        if (rowIndex == 0)
                        {
                            if (columnIndex <= 2)
                            {
                                this.tNedit_SalesTargetSale.Focus();
                            }
                            else if (columnIndex == 3)
                            {
                                this.tNedit_SalesTargetProfit.Focus();
                            }
                            else
                            {
                                this.tNedit_SalesTargetCount.Focus();
                            }
                        }
                        else
                        {
                            this.SalesTarget_uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex < 11)
                        {
                            this.SalesTarget_uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (this.SalesTarget_uGrid.ActiveCell.IsInEditMode)
                        {
                            if (this.SalesTarget_uGrid.ActiveCell.SelStart == 0)
                            {
                                e.Handled = true;

                                if (columnIndex <= 1)
                                {
                                    int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                                    if (targetContrastCd == 45)
                                    {
                                        this.EnterpriseGanreGuide_Button.Focus();
                                    }
                                    else
                                    {
                                        this.SectionGuide_Button.Focus();
                                    }
                                }
                                else
                                {
                                    this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (this.SalesTarget_uGrid.ActiveCell.IsInEditMode)
                        {
                            if (this.SalesTarget_uGrid.ActiveCell.SelStart >= this.SalesTarget_uGrid.ActiveCell.Text.Length)
                            {
                                e.Handled = true;

                                if (columnIndex != 4)
                                {
                                    this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex + 1].Activate();
                                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h���A�N�e�B�u��ԂŃL�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesTarget_uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.SalesTarget_uGrid.ActiveCell.Row.Index;
            int columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;

            if (columnIndex < 1)
            {
                return;
            }

            // �uBackspace�v�L�[�������ꂽ��
            if ((byte)e.KeyChar == (byte)'\b')
            {
                return;
            }

            // �ΏۃZ���̃e�L�X�g�擾
            string retText;
            string targetText = this.SalesTarget_uGrid.ActiveCell.Text;
            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);

            // �e�s�̓��͉\������ݒ肵�܂�
            switch (columnIndex)
            {
                // ���ʔ䗦
                // 3V2
                case 1:
                    // �Z���̃e�L�X�g���I������Ă���ꍇ
                    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                    {
                        // ���l�̂ݓ��͉�
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // �J���}�A�s���I�h�폜
                        RemoveCommaPeriod(targetText, out retText, true);

                        // ��������5��������������͕s��
                        if (retText.Length == 5)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // ���l�ȊO�̎�
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // ���͒l��1�����ڂ́u,�v�u.�v�s��
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    if (targetText.IndexOf(".") >= 0)
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    // �J���}�A�s���I�h�폜
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 3)
                                    {
                                        if ((byte)e.KeyChar != '.')
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }

                                    // �u,�v�u.�v�͓��͉�
                                    if (((byte)e.KeyChar == ',') || ((byte)e.KeyChar == '.'))
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                            else
                            {
                                if (targetText.IndexOf(".") >= 0)
                                {
                                    // �����_�擾
                                    GetDecimal(targetText, out retText);

                                    if (retText.Length == 2)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                                else
                                {
                                    // �J���}�A�s���I�h�폜
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 3)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;

                // ����ڕW�A�e���ڕW
                // 11
                case 2:
                case 3:
                    // �Z���̃e�L�X�g���I������Ă���ꍇ
                    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                    {
                        // ���l�̂ݓ��͉�
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // �J���}�A�s���I�h�폜
                        RemoveCommaPeriod(targetText, out retText, true);

                        // ��������9��������������͕s��
                        if (retText.Length == 11)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // ���l�ȊO�̎�
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // ���͒l��1�����ڂ́u,�v�s��
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // �u,�v�͓��͉�
                                    if ((byte)e.KeyChar != ',')
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;

                // ���ʖڕW
                // 8
                case 4:
                    // �Z���̃e�L�X�g���I������Ă���ꍇ
                    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                    {
                        // ���l�̂ݓ��͉�
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // �J���}�A�s���I�h�폜
                        RemoveCommaPeriod(targetText, out retText, true);

                        // ��������9��������������͕s��
                        if (retText.Length == 8)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // ���l�ȊO�̎�
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // ���͒l��1�����ڂ́u,�v�s��
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // �u,�v�͓��͉�
                                    if ((byte)e.KeyChar != ',')
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h����t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesTarget_uGrid_Leave(object sender, EventArgs e)
        {
            this.SalesTarget_uGrid.ActiveCell = null;
            this.SalesTarget_uGrid.ActiveRow = null;
        }
        #endregion �O���b�h�֘A

        /// <summary>
        /// SelectionChangeCommitted �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ݒ�敪�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void tComboEditor_TargetContrastCd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.tComboEditor_TargetContrastCd.Value == null)
            {
                return;
            }

            AfterChangeTargetContrastCd();
        }

        private void AfterChangeTargetContrastCd()
        {
            int status;

            if (this._searchFlg)
            {
                DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                    "",
                                                    0,
                                                    MessageBoxButtons.YesNoCancel,
                                                    MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Yes:
                        {
                            // �ۑ�����
                            status = SaveProc();
                            if (status != 0)
                            {
                                this._prevTargetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                                return;
                            }

                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            this.tComboEditor_TargetContrastCd.SelectionChangeCommitted -= tComboEditor_TargetContrastCd_SelectionChangeCommitted;
                            this.tComboEditor_TargetContrastCd.Value = this._prevTargetContrastCd;
                            this.tComboEditor_TargetContrastCd.SelectionChangeCommitted += tComboEditor_TargetContrastCd_SelectionChangeCommitted;
                            return;
                        }
                }
            }

            // ����
            status = SearchProc();
            if (status != 0)
            {
                int prevTargetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                int year = this.tNedit_Year.GetInt();
                ClearScreen();
                this.tNedit_Year.SetInt(year);
                this._prevTargetContrastCd = prevTargetContrastCd;
                this.tComboEditor_TargetContrastCd.SelectionChangeCommitted -= tComboEditor_TargetContrastCd_SelectionChangeCommitted;
                this.tComboEditor_TargetContrastCd.Value = prevTargetContrastCd;
                this.tComboEditor_TargetContrastCd.SelectionChangeCommitted += tComboEditor_TargetContrastCd_SelectionChangeCommitted;
            }
            else
            {
                this._prevTargetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            }

            this.Top_Panel.Focus();
            this.tComboEditor_TargetContrastCd.Focus();

            // �ݒ�敪�����R���g���[��Enabled����
            ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
        }
        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃t�H�[�J�X���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            int status;

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_Year":
                    {
                        int year = this.tNedit_Year.GetInt();

                        if (year == this._prevYear)
                        {
                            return;
                        }

                        // ��v�N�x�e�[�u���擾
                        GetFinancialYearTable(year - this._thisYear);

                        if (CheckSaveConfirm() == false)
                        {
                            this._prevYear = year;
                            return;
                        }
                        else
                        {
                            if (this._searchFlg)
                            {
                                DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                    "",
                                                                    0,
                                                                    MessageBoxButtons.YesNoCancel,
                                                                    MessageBoxDefaultButton.Button2);
                                switch (result)
                                {
                                    case DialogResult.Yes:
                                        {
                                            // �ۑ�����
                                            status = SaveProc();
                                            if (status != 0)
                                            {
                                                this._prevYear = year;
                                                return;
                                            }

                                            break;
                                        }
                                    case DialogResult.No:
                                        {
                                            break;
                                        }
                                    case DialogResult.Cancel:
                                        {
                                            this.tNedit_Year.SetInt(this._prevYear);

                                            // ��v�N�x�e�[�u���擾
                                            GetFinancialYearTable(this._prevYear - this._thisYear);
                                            return;
                                        }
                                }
                            }

                            // ����
                            status = SearchProc();
                            if (status != 0)
                            {
                                ClearScreen();

                                this.tNedit_Year.SetInt(year);
                                this._prevYear = year;
                            }
                            else
                            {
                                this._prevYear = year;
                            }
                        }
                        break;
                    }
                case "tComboEditor_TargetContrastCd":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                AfterChangeTargetContrastCd();
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                AfterChangeTargetContrastCd();
                            }
                        }
                        break;
                    }
                case "tEdit_SectionCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 10)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }

                        if (this.tEdit_SectionCode.DataText.Trim() == "")
                        {
                            this.tEdit_SectionName.Clear();
                            this._prevSectionCode = "";
                            return;
                        }

                        // ���_�R�[�h�擾
                        string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');

                        if (sectionCode != this._prevSectionCode)
                        {
                            // ���_���擾
                            this.tEdit_SectionName.DataText = GetSectionName(sectionCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevSectionCode = sectionCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // �ۑ�����
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevSectionCode = sectionCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tEdit_SectionCode.DataText = this._prevSectionCode;
                                                this.tEdit_SectionName.DataText = GetSectionName(this._prevSectionCode);
                                                return;
                                            }
                                    }
                                }

                                // ����
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevSectionCode = sectionCode;
                                }
                                else
                                {
                                    this._prevSectionCode = sectionCode;
                                }
                            }
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tEdit_SectionCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SubSectionCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 20)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }

                        if (this.tNedit_SubSectionCode.GetInt() == 0)
                        {
                            this.tEdit_SubSectionName.Clear();
                            this._prevSubSectionCode = 0;
                            return;
                        }

                        // ����R�[�h�擾
                        int subSectionCode = this.tNedit_SubSectionCode.GetInt();

                        if (subSectionCode != this._prevSubSectionCode)
                        {
                            // ���喼�擾
                            this.tEdit_SubSectionName.DataText = GetSubSectionName(subSectionCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevSubSectionCode = subSectionCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // �ۑ�����
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevSubSectionCode = subSectionCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tNedit_SubSectionCode.SetInt(this._prevSubSectionCode);
                                                this.tEdit_SubSectionName.DataText = GetSubSectionName(this._prevSubSectionCode);
                                                return;
                                            }
                                    }
                                }

                                // ����
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevSubSectionCode = subSectionCode;
                                }
                                else
                                {
                                    this._prevSubSectionCode = subSectionCode;
                                }
                            }
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SubSectionName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_SubSectionCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_CustomerCode":
                    {
                        if (this.tNedit_CustomerCode.GetInt() == 0)
                        {
                            this.tEdit_CustomerName.Clear();
                            this._prevCustomerCode = 0;
                            return;
                        }

                        // ���Ӑ�R�[�h�擾
                        int customerCode = this.tNedit_CustomerCode.GetInt();

                        if (customerCode != this._prevCustomerCode)
                        {
                            // ���Ӑ於�擾
                            this.tEdit_CustomerName.DataText = GetCustomerName(customerCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevCustomerCode = customerCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // �ۑ�����
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevCustomerCode = customerCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
                                                this.tEdit_CustomerName.DataText = GetCustomerName(this._prevCustomerCode);
                                                return;
                                            }
                                    }
                                }

                                // ����
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevCustomerCode = customerCode;
                                }
                                else
                                {
                                    this._prevCustomerCode = customerCode;
                                }
                            }
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_CustomerName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_CustomerCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tEdit_EmployeeCode":
                    {
                        if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                        {
                            this.tEdit_EmployeeName.Clear();
                            this._prevEmployeeCode = "";
                            return;
                        }

                        // �]�ƈ��R�[�h�擾
                        string employeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');

                        if (employeeCode != this._prevEmployeeCode)
                        {
                            // �]�ƈ����擾
                            this.tEdit_EmployeeName.DataText = GetEmployeeName(employeeCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevEmployeeCode = employeeCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // �ۑ�����
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevEmployeeCode = employeeCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tEdit_EmployeeCode.DataText = this._prevEmployeeCode;
                                                this.tEdit_EmployeeName.DataText = GetEmployeeName(this._prevEmployeeCode);
                                                return;
                                            }
                                    }
                                }

                                // ����
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevEmployeeCode = employeeCode;
                                }
                                else
                                {
                                    this._prevEmployeeCode = employeeCode;
                                }
                            }
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_EmployeeName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tEdit_EmployeeCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesAreaCode":
                    {
                        if (this.tNedit_SalesAreaCode.GetInt() == 0)
                        {
                            this.tEdit_SalesAreaName.Clear();
                            this._prevSalesAreaCode = 0;
                            return;
                        }

                        // �n��R�[�h�擾
                        int salesAreaCode = this.tNedit_SalesAreaCode.GetInt();

                        if (salesAreaCode != this._prevSalesAreaCode)
                        {
                            // �n�於�擾
                            this.tEdit_SalesAreaName.DataText = GetSalesAreaName(salesAreaCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevSalesAreaCode = salesAreaCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // �ۑ�����
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevSalesAreaCode = salesAreaCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tNedit_SalesAreaCode.SetInt(this._prevSalesAreaCode);
                                                this.tEdit_SalesAreaName.DataText = GetSalesAreaName(this._prevSalesAreaCode);
                                                return;
                                            }
                                    }
                                }

                                // ����
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevSalesAreaCode = salesAreaCode;
                                }
                                else
                                {
                                    this._prevSalesAreaCode = salesAreaCode;
                                }
                            }
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SalesAreaName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_SalesAreaCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_BusinessTypeCode":
                    {
                        if (this.tNedit_BusinessTypeCode.GetInt() == 0)
                        {
                            this.tEdit_BusinessTypeName.Clear();
                            this._prevBusinessTypeCode = 0;
                            return;
                        }

                        // �Ǝ�R�[�h�擾
                        int businessTypeCode = this.tNedit_BusinessTypeCode.GetInt();

                        if (businessTypeCode != this._prevBusinessTypeCode)
                        {
                            // �Ǝ햼�擾
                            this.tEdit_BusinessTypeName.DataText = GetBusinessTypeName(businessTypeCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevBusinessTypeCode = businessTypeCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // �ۑ�����
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevBusinessTypeCode = businessTypeCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tNedit_BusinessTypeCode.SetInt(this._prevBusinessTypeCode);
                                                this.tEdit_BusinessTypeName.DataText = GetBusinessTypeName(this._prevBusinessTypeCode);
                                                return;
                                            }
                                    }
                                }

                                // ����
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevBusinessTypeCode = businessTypeCode;
                                }
                                else
                                {
                                    this._prevBusinessTypeCode = businessTypeCode;
                                }
                            }
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_BusinessTypeName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_BusinessTypeCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "SectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 10)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tNedit_SalesTargetSale;
                                return;
                            }
                        }
                        break;
                    }
                case "SubSectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 20)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tNedit_SalesTargetSale;
                                return;
                            }
                        }
                        break;
                    }
                case "CustomerGuide_Button":
                case "EmployeeGuide_Button":
                case "SalesAreaGuide_Button":
                case "BusinessTypeGuide_Button":
                case "SalesCodeGuide_Button":
                case "EnterpriseGanreGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tNedit_SalesTargetSale;
                                return;
                            }
                        }
                        break;
                    }
                case "tNedit_SalesCode":
                    {
                        if (tNedit_SalesCode.GetInt() == 0)
                        {
                            this.tEdit_SalesCodeName.Clear();
                            this._prevSalesCode = 0;
                            return;
                        }

                        // �̔��敪�R�[�h�擾
                        int salesCode = this.tNedit_SalesCode.GetInt();

                        if (salesCode != this._prevSalesCode)
                        {
                            // �̔��敪���擾
                            this.tEdit_SalesCodeName.DataText = GetSalesCodeName(salesCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevSalesCode = salesCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // �ۑ�����
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevSalesCode = salesCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tNedit_SalesCode.SetInt(this._prevSalesCode);
                                                this.tEdit_SalesCodeName.DataText = GetSalesCodeName(this._prevSalesCode);
                                                return;
                                            }
                                    }
                                }

                                // ����
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevSalesCode = salesCode;
                                }
                                else
                                {
                                    this._prevSalesCode = salesCode;
                                }
                            }
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SalesCodeName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_SalesCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_EnterpriseGanreCode":
                    {
                        if (this.tNedit_EnterpriseGanreCode.GetInt() == 0)
                        {
                            this.tEdit_EnterpriseGanreName.Clear();
                            this._prevEnterpriseGanreCode = 0;
                            return;
                        }

                        // ���i�敪�R�[�h�擾
                        int enterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();

                        if (enterpriseGanreCode != this._prevEnterpriseGanreCode)
                        {
                            this._prevEnterpriseGanreCode = enterpriseGanreCode;

                            // ���i�敪���擾
                            this.tEdit_EnterpriseGanreName.DataText = GetEnterpriseGanreName(enterpriseGanreCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevEnterpriseGanreCode = enterpriseGanreCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // �ۑ�����
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevEnterpriseGanreCode = enterpriseGanreCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tNedit_EnterpriseGanreCode.SetInt(this._prevEnterpriseGanreCode);
                                                this.tEdit_EnterpriseGanreName.DataText = GetEnterpriseGanreName(this._prevEnterpriseGanreCode);
                                                return;
                                            }
                                    }
                                }

                                // ����
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevEnterpriseGanreCode = enterpriseGanreCode;
                                }
                                else
                                {
                                    this._prevEnterpriseGanreCode = enterpriseGanreCode;
                                }
                            }
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_EnterpriseGanreName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_EnterpriseGanreCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesTargetSale":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                                this.SalesTarget_uGrid.Focus();
                                this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_SALESTARGET].Activate();
                                this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.Mode_Label.Text == INSERT_MODE)
                                {
                                    // �ݒ�敪
                                    int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;

                                    switch (targetContrastCd)
                                    {
                                        case 10:    // ���_
                                            {
                                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tEdit_SectionCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 20:    // ���_�{����
                                            {
                                                if (this.tEdit_SubSectionName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tNedit_SubSectionCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 30:    // ���_�{���Ӑ�
                                            {
                                                if (this.tEdit_CustomerName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tNedit_CustomerCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 221:   // ���_�{�S����
                                        case 222:   // ���_�{�󒍎�
                                        case 223:   // ���_�{���s��
                                            {
                                                if (this.tEdit_EmployeeName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tEdit_EmployeeCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 32:    // ���_�{�n��
                                            {
                                                if (this.tEdit_SalesAreaName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tNedit_SalesAreaCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 31:    // ���_�{�Ǝ�
                                            {
                                                if (this.tEdit_BusinessTypeName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tNedit_SalesCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 44:    // ���_�{�̔��敪
                                            {
                                                if (this.tEdit_BusinessTypeName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tNedit_BusinessTypeCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 45:    // ���i�敪
                                            {
                                                if (this.tEdit_EnterpriseGanreName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tNedit_EnterpriseGanreCode;
                                                    return;
                                                }
                                                break;
                                            }
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = this.SalesTarget_uGrid;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesTargetProfit":
                    {
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            this.SalesTarget_uGrid.Focus();
                            this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_PROFITTARGET].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                        break;
                    }
                case "tNedit_SalesTargetCount":
                    {
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            this.SalesTarget_uGrid.Focus();
                            this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_COUNTTARGET].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                        break;
                    }
                case "SalesTarget_uGrid":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextCell(ref e, false);
                                return;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                SetNextCell(ref e, true);
                                return;
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            if (e.NextCtrl == this.SalesTarget_uGrid)
            {
                e.NextCtrl = null;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_RATIO].Activate();
                    }
                }
                else
                {
                    this.SalesTarget_uGrid.Rows[11].Cells[COLUMN_COUNTTARGET].Activate();
                }
                
                this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        #endregion �� Control Events
    }
}