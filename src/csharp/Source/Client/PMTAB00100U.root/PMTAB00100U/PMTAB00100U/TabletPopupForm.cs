//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : Tablet�풓����
// �v���O�����T�v   : Tablet�풓�������s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/05/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �C�����e�@��Q�� #37530�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg                                    
// �� �� ��  2013/07/01  �쐬���e : �y�|�b�v�A�b�v�z����o�^��̃|�b�v�A�b�v��ʉ����ɁA�����\������Ă��Ȃ��󔒕������\������Ă��܂�
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #39489�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/08/01  �쐬���e : ��Q�� #39489�̑Ή�
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/08/07  �C�����e : �ċN���Ή�
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39972 
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �g��
// Date            : 2013/08/16
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �O��
// �� �� ��  2013/08/23  �C�����e : �e�����񓯊��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/08/26  �C�����e : Redmine#40121 �f�[�^�o�^��WebSync�ʒm�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/08/30  �C�����e : Redmine#40121 �f�[�^�o�^��WebSync�ʒm�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/09/02  �C�����e : Redmine#40121 ���Ӑ挟����WebSync�ʒm�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g��
// �� �� ��  2013/10/08  �C�����e : �R�`���i���x�x���Ή� SCM�d�|�ꗗ��10579
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2013/10/08  �C�����e : �R�`���i���x�x���Ή� SCM�d�|�ꗗ��10579
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070091-00 �쐬�S�� : zhujw
// �� �� ��  2014/06/11  �C�����e : RedMine#42648 Windows8.1���쌟�،���_�풓�|�b�v�A�b�v�w�i���������\�������ꍇ������ �C��
//----------------------------------------------------------------------------//

using System.Windows.Forms;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using Broadleaf.Application.Controller;
using System.Data;
using System;
using Broadleaf.Application.UIData;
using System.Configuration;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using Broadleaf.Library.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Collections;
// ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
using System.Threading;
// ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<



namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// Tablet�풓����UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �|�b�v�A�b�v��M�������s���܂��B</br>
    /// <br>Programmer	: ����</br>
    /// <br>Date		: 2013/05/29</br>
    /// <br>Update Note : �\�[�X�`�F�b�N�m�F�����ꗗNO.1�̑Ή�</br>
    /// <br>�Ǘ��ԍ�    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/10</br>
    /// <br>Update Note : �\�[�X�`�F�b�N�m�F�����ꗗNO.5�̑Ή�</br>
    /// <br>�Ǘ��ԍ�    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/10</br>
    /// <br>Update Note : �\�[�X�`�F�b�N�m�F�����ꗗNO.6�̑Ή�</br>
    /// <br>�Ǘ��ԍ�    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/10</br>
    /// <br>Update Note : �\�[�X�`�F�b�N�m�F�����ꗗ�^�u���b�g���O�Ή�</br>
    /// <br>�Ǘ��ԍ�    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/19</br>
    /// <br>Update Note : �\�[�X�`�F�b�N�m�F�����ꗗNO.49�̑Ή�</br>
    /// <br>�Ǘ��ԍ�    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/20</br>
    /// <br>Update Note : Redmine#37163</br>
    /// <br>�Ǘ��ԍ�    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/25</br>
    /// <br>Update Note : Redmine#37412</br>
    /// <br>�Ǘ��ԍ�    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/27</br>
    /// <br>Update Note : Redmine#38118</br>
    /// <br>�Ǘ��ԍ�    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/07/10</br>
    /// <br>Update Note : ���O������</br>
    /// <br>�Ǘ��ԍ�    : 10902622-01</br>
    /// <br>Programmer  : �g��</br>
    /// <br>Date        : 2013/07/29</br>
    /// <br>Update Note : Redmine#39398</br>
    /// <br>�Ǘ��ԍ�    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/07/30</br>
    /// <br></br>
    /// </remarks>
    public partial class TabletPopupForm : Form
    {
        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>
        #region public�ϐ�
        public object setMastUpLoadLock = new object();         // �r�����b�N�p�i�ݒ�}�X�^�A�b�v���[�h�j
        public object autoAnswerCustInfoLock = new object();    // �r�����b�N�p�i�����񓚏����i���Ӑ���j�j
        public object autoAnswerSearchLock = new object();      // �r�����b�N�p�i�����񓚏����i�����j�j
        public object autoAnswerDataCreateLock = new object();  // �r�����b�N�p�i�����񓚏����i�f�[�^�o�^�j�j
        public object autoAnswerSlipListLock = new object();    // �r�����b�N�p�i�����񓚏����i���Ӑ�d�q�����j�j
        public ConstantManagement.MethodResult resultReply;
        public CustomerInfo customerInfo;
        // ADD 2013/08/30 Remine#40121 yugami -------------------------------->>>>>
        public object sessionIdDicLock = new object();             // �r�����b�N�p�i�Z�b�V����IDDictionary�j
        // ADD 2013/08/30 Remine#40121 yugami --------------------------------<<<<<
        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
        public object searchInitialLock = new object();         // �r�����b�N�p�i���i�����A�N�Z�X�N���X�L���b�V���j
        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<
        #endregion
        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<

        #region private�萔
        private const int SET_MAST_UP_LOAD = 1; // �ݒ�}�X�^�A�b�v���[�h
        private const int AUTO_ANSWER_CUST_INFO = 2; // �����񓚏����i���Ӑ���j
        private const int AUTO_ANSWER_SEARCH = 3; // �����񓚏����i�����j
        private const int AUTO_ANSWER_DATA_CREATE = 4; // �����񓚏����i�f�[�^�o�^�j
        private const int AUTO_ANSWER_SLIP_LIST = 5; // �����񓚏����i���Ӑ�d�q�����j

        private const string CT_Conf_PortNumber = "PortNumber"; // �ʐM�p�|�[�g�ԍ�
        private const double ctFormOpacity = 0.92;
        //private const int ctDefaultFormHeight = 158;//-----DEL songg 2013/07/01 ��Q�� #37530�̑Ή�
        private const int ctDefaultFormHeight = 126;//-----ADD songg 2013/07/01 ��Q�� #37530�̑Ή�
        
        /// <summary>������o�^�̒񎦂�\�����邩�ǂ����萔</summary>
        private const string CT_Conf_SaleSlipCreateView = "SaleSlipCreateView";
        /// <summary>�uconfig�v�t�@�C��</summary>
        private const string Exe_Conf_Filename = "PMTAB00100U.exe.config";
        /// <summary>appSettings</summary>
        private const string App_Set_Section = "appSettings";
        /// <summary>�����񓚂̏���\�����邩�ǂ����t���O</summary>
        private bool _visbleFlg = false;

        private const string ctColumnName_CustomerCdName = "CustomerCdName";
        private const string BLANK = "     ";
        private const string CT_Conf_ExeFileName = "PMTAB00100U.exe";

        #endregion

        #region private�ϐ�
        private List<string> _settingList; // ���O�C�����AApp.config���ݒ胊�X�g

        /// <summary>�����񓚂̏���\�����邩�ǂ����̐ݒ���</summary>
        private PMTAB00100UC _form = null;

        private CustomerInfoAcs _customerInfoAcs;
        private DataTable _dataTable;

        private SFCMN01501CA _tabletPushClient;    // Push�N���C�A���g�I�u�W�F�N�g
        private string _enterpriseCode;         // ���O�C���]�ƈ��̊�ƃR�[�h
        private string _sectionCode;            // ���O�C���]�ƈ��̋��_�R�[�h

        // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        private const string CLASS_NAME = "TabletPopupForm";
        private const string DEFAULT_NAME = "PMTAB00100U_";
        // �^�u���b�g���O�Ή��@---------------------------------<<<<<

        // ADD 2013/08/30 Remine#40121 yugami -------------------------------->>>>>
        // �������̃Z�b�V�����h�c��ۑ�
        private Dictionary<string, object> _sessionIdDic = new Dictionary<string, object>();
        // ADD 2013/08/30 Remine#40121 yugami --------------------------------<<<<<

        /// <summary>
        /// �풓���
        /// </summary>
        private ResidentController _residentController;// ADD 2013/07/10 wangl2 FOR Redmine#38118

        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
        private GoodsAcs _goodsAccesser1;
        private GoodsAcs _goodsAccesser2;
        private CampaignPrcPrStAcs _campaignPrcPrStAcs;
        private ArrayList _campaignPrcPrStList;
        private int _cacheInitType = 0;
        private int _cacheInUsedType = 0;

        /// <summary>
        /// �荏�L���b�V���p�^�C�}�[
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        /// <summary>
        /// �荏
        /// </summary>
        private DateTime punctual;
        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<

        #endregion

        #region <�R�}���h���C������>

        /// <summary>�R�}���h���C������</summary>
        private readonly string[] _commandLineArgs;
        /// <summary>�R�}���h���C���������擾���܂��B</summary>
        private string[] CommandLineArgs { get { return _commandLineArgs; } }

        #endregion // </�R�}���h���C������>

        #region <�t�H�[������锻��>

        /// <summary>�t�H�[������锻��t���O</summary>
        private bool _canClose;
        /// <summary>�t�H�[������锻��t���O�̃A�N�Z�T</summary>
        private bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        #endregion // </�t�H�[������锻��>

        #region <�������̎擾>
        /// <summary>
        /// �������擾����
        /// </summary>
        private void GetInitialSettings()
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetInitialSettings";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            this._settingList = new List<string>();
            // --------------- DEL START 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.6�̑Ή� ------>>>>
            //if (Program.PM7Mode)
            //{
            //    // ��ƃR�[�h�擾
            //    this._settingList.Add("0000000000000000");

            //    // ���O�C������莩���_���擾
            //    this._settingList.Add("00");

            //    // �|�b�v�A�b�v���ߑ���M�p�̃|�[�g�ԍ�
            //    this._settingList.Add(ConfigurationManager.AppSettings[CT_Conf_PortNumber]);

            //    // PM7�A�g�R�[�h
            //    this._settingList.Add("0");
            //}
            //else
            //{
            //    // ��ƃR�[�h�擾
            //    this._settingList.Add(LoginInfoAcquisition.EnterpriseCode);

            //    // ���O�C������莩���_���擾
            //    this._settingList.Add(LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0'));

            //    // �|�b�v�A�b�v���ߑ���M�p�̃|�[�g�ԍ�
            //    this._settingList.Add(ConfigurationManager.AppSettings[CT_Conf_PortNumber]);

            //    // PM7�A�g�R�[�h
            //    this._settingList.Add("1");

            //}
            // --------------- DEL END 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.6�̑Ή� --------<<<<
            // --------------- ADD START 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.6�̑Ή� ------>>>>
            //��ƃR�[�h�擾
            this._settingList.Add(LoginInfoAcquisition.EnterpriseCode);

            // ���O�C������莩���_���擾
            this._settingList.Add(LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0'));

            // �|�b�v�A�b�v���ߑ���M�p�̃|�[�g�ԍ�
            this._settingList.Add(ConfigurationManager.AppSettings[CT_Conf_PortNumber]);

            // PM7�A�g�R�[�h
            this._settingList.Add("1");
            // --------------- ADD END 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.6�̑Ή� --------<<<<

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        /// <summary>
        /// �������̐ݒ���e�`�F�b�N
        /// </summary>
        /// <returns></returns>
        private bool CheckInitialSettings()
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "CheckInitialSettings";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            Int32 portNumber;
            if (!Int32.TryParse(ConfigurationManager.AppSettings[CT_Conf_PortNumber], out portNumber))
            {
                LogWriter.LogWrite("config�t�@�C���̃|�[�g�ԍ��̐ݒ肪����������܂���B");
                return false;
            }
            else
            {
                if (portNumber < 0 || portNumber > 65535)
                {
                    LogWriter.LogWrite("config�t�@�C���̃|�[�g�ԍ��̐ݒ肪����������܂���B");
                    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                    // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                    return false;
                }
            }

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return true;
        }
        #endregion

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        private TabletPopupForm()
            : base()
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>

            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            this._dataTable = new DataTable();
            this._dataTable.Columns.Add(new DataColumn(ctColumnName_CustomerCdName, typeof(string)));
            this.dataGridView_Data.DataSource = this._dataTable.DefaultView;
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            // �R���X�g���N�^�Ń��O�o�͗p�f�B���N�g�����쐬
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="commandLineArgs">�R�}���h���C������</param>
        public TabletPopupForm(string[] commandLineArgs)
            : this()
        {
            _commandLineArgs = commandLineArgs;

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            // �R���X�g���N�^�Ń��O�o�͗p�f�B���N�g�����쐬
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        #endregion // </Constructor>

        #region <�t�H�[��>

        /// <summary>�f�t�H���gx���W</summary>
        private const int DEFAULT_X = 100000;
        /// <summary>�f�t�H���gy���W</summary>
        private const int DEFAULT_Y = 100000;



        // ADD �g�� 2013/08/07 �풓�����ċN���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���b�Z�[�W��M�i�ċN���j
        /// </summary>
        /// <param name="m">��M���b�Z�[�W</param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Program.WM_COPYDATA:
                    //���������M����ė���

                    Program.COPYDATASTRUCT mystr = new Program.COPYDATASTRUCT();
                    Type mytype = mystr.GetType();
                    mystr = (Program.COPYDATASTRUCT)m.GetLParam(mytype);
                    if (mystr.lpData.Trim().Equals(Program.RESTART))
                    {
                        // �I������
                        CanClose = true;
                        Close();
                    }
                    break; 
            }
            base.WndProc(ref m);
        }
        // ADD �g�� 2013/08/07 �풓�����ċN���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �t�H�[����Load�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void TabletPopupForm_Load(object sender, EventArgs e)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "TabletPopupForm_Load";
            EasyLogger.Name = DEFAULT_NAME;
            EasyLogger.Write(CLASS_NAME,methodName,methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            // --------------- ADD START 2013/07/10 wangl2 FOR Redmine#38118------>>>>
            if (_residentController == null)
                _residentController = new ResidentController();
            this._residentController.SearchSetting(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            // --------------- ADD END 2013/07/10 wangl2 FOR Redmine#38118--------<<<<
            this.dataGridView_Data.Columns[ctColumnName_CustomerCdName].Visible = false;

            this.Height = ctDefaultFormHeight;
            //this.SetNewestData();

            // �����\���͉B��
            SetVisibleState(false);

            // �����ʒu��ݒ�i������h�~�ׁ̈A10000�ɂ��Ă��܂��j
            SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);

            // App.Config���擾
            GetInitialSettings();

            // App.Config���`�F�b�N
            if (!this.CheckInitialSettings())
            {
                // �����ݒ肪�G���[�̏ꍇ�͏I��
                CanClose = true;
                Close();
                return;
            }

            // ADD 2013/08/23 �O�� �e�����񓯊��Ή�------>>>>>>>>
            this._dataTable.Clear();
            DataRow dr = this._dataTable.NewRow();
            this._dataTable.Rows.Add(dr);
            // ADD 2013/08/23 �O�� �e�����񓯊��Ή�------<<<<<<<<

            this.SetStyle(ControlStyles.ResizeRedraw, true);

            // ADD 2013/08/30 Redmine#40121 yugami ----------------------------------->>>>>
            // �^�C�}�[�N��
            waitTimeReset.Enabled = true;
            // ADD 2013/08/30 Redmine#40121 yugami -----------------------------------<<<<<

            // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
            _goodsAccesser1 = new GoodsAcs(LoginInfoAcquisition.Employee.BelongSectionCode);
            string msg = string.Empty;
            _goodsAccesser1.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
            _cacheInitType = 1;
            _campaignPrcPrStAcs = new CampaignPrcPrStAcs();
            _campaignPrcPrStAcs.SearchAll(out _campaignPrcPrStList, LoginInfoAcquisition.EnterpriseCode);
            // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<

            InitPushMode();
            DelLogFile();// ADD 2013/07/30 wangl2 FOR Redmine#39398

            // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
            CachePunctualTimerSet();
            // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Name = DEFAULT_NAME;
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        // --------------- ADD START 2013/07/30 wangl2 FOR Redmine#39398------>>>>
        /// <summary>
        /// ���O�t�@�C�����폜����
        /// </summary>
        private void DelLogFile()
        {
            const string methodName = "DelLogFile";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ���O�p�X
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Log\PmTablet";
            // �폜���t
            string dateTimeNow = DateTime.Now.AddMonths(-6).ToString("yyyyMMdd");
            try
            {
                if (System.IO.Directory.Exists(path))
                {
                    // ���ʃ��X�g
                    List<string> results = new List<string>();
                    // �t�@�C�����X�g��������
                    List<string> importList = this.GetFileList(path);
                    foreach (string paths in importList)
                    {
                        FileInfo file = new FileInfo(paths);
                        DateTime filetime = file.LastWriteTime;
                        string time = filetime.ToString("yyyyMMdd");
                        if (Convert.ToInt64(time) <= Convert.ToInt64(dateTimeNow))
                        {
                            // ���X�g�ɒǉ�
                            results.Add(paths);
                        }
                    }
                    if (results != null && results.Count > 0)
                    {
                        foreach (string delpath in results)
                        {
                            File.Delete(delpath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            }
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        }

        /// <summary>
        /// �t�@�C�����X�g��������
        /// </summary>
        /// <param name="folderPath">�����t�H���_�p�X</param>
        /// <returns>�t�@�C�����X�g</returns>
        /// <remarks>
        /// <br>Note	   : �w�肳�ꂽ�t�H���_�����̃t�@�C�����X�g��Ԃ��܂��B</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013.07.30</br>
        /// </remarks>
        private List<string> GetFileList(string folderPath)
        {
            const string methodName = "GetFileList";
            EasyLogger.Name = DEFAULT_NAME;
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            string[] fileExtension ={"*.log"};
            List<string> fileLsit = new List<string>();
            for (int i = 0; i < fileExtension.Length; i++)
            {
                string[] Lsit = new string[0];
                Lsit = Directory.GetFiles(folderPath, fileExtension[i]);
                if (Lsit != null && Lsit.Length > 0)
                {
                    foreach (string dir in Lsit)
                    {
                        // ���X�g�ɒǉ�
                        fileLsit.Add(dir);
                    }
                }
            }
            EasyLogger.Name = DEFAULT_NAME;
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            return fileLsit;
        }
        // --------------- ADD END 2013/07/30 wangl2 FOR Redmine#39398--------<<<<

        /// <summary>
        /// Push���[�h�̏�����
        /// </summary>
        private void InitPushMode()
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "InitPushMode";
            EasyLogger.Name = DEFAULT_NAME;
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            ClientArgs clientArgs = new ClientArgs();

            // Push�T�[�o�[URL�̐ݒ�
            string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP);
            string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP, ConstantManagement_SF_PRO.IndexCode_WebSync_WebPath);
            string webSyncUrl = wkStr1 + wkStr2;
            clientArgs.Url = webSyncUrl;

            _tabletPushClient = new SFCMN01501CA(clientArgs);

            ConnectArgs connectArgs = new ConnectArgs();
            connectArgs.StayConnected = true; // �ڑ����ؒf�ꍇ�A�����I�ɍĐڑ�����
            connectArgs.ReconnectInterval = 5000; // 5�b�@�ڑ����s�ꍇ�A�Đڑ��Ԋu���w�肷��
            connectArgs.ConnectFailure += new PushClientEventHandler<ConnectFailureEventArgs>(
                delegate(IScmPushClient client, ConnectFailureEventArgs args)
                {
                    // �V���`�F�b�J�[���N�����鎞�APush�T�[�o�[��ڑ��ł��Ȃ���΁A���̃��\�b�h���Ăт���
                    // �ڑ�������APush�T�[�o�[�ƒʐM�G���[�ꍇ�AOnStreamFailure�C�x���g�������Ăт���

                    // �ڑ������s����΁APush�T�[�o�[�֍Đڑ�
                    args.Reconnect = true;
                }
            );
            _tabletPushClient.Connect(connectArgs);

            // SCM�₢���킹�����̓e�X�g���b�Z�[�W���󂯎��邽�߂ɁA�`�����l����\�񂷂�            
            //if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) >= PurchaseStatus.Contract)// DEL 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.1�̑Ή�
            //if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicTablet) >= PurchaseStatus.Contract)// ADD 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.1�̑Ή�   // DEL 2013/06/27 wangl2 FOR Redmine#37412
            //{ // DEL 2013/06/27 wangl2 FOR Redmine#37412
                SubscribeArgs<TabletPushData> subscribeArgs = new SubscribeArgs<TabletPushData>();
                subscribeArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}", _tabletPushClient.WEBSYNC_CHANNEL_PMTAB, _enterpriseCode, _sectionCode.Trim());
                subscribeArgs.SubscribeSuccess += new PushClientEventHandler<SubscribeSuccessEventArgs>(
                    delegate(IScmPushClient client, SubscribeSuccessEventArgs args)
                    {
                        // �ڑ����邢�͍Đڑ�����������Ƃ��A���̃��\�b�h���Ăт���
                        Invoke(new MethodInvoker(delegate()
                        {
                            if (args.IsResubscribe)
                            {
                                
                            }
                        }));
                    }
                );
                subscribeArgs.SubscribeReceive += new PushClientEventHandler<SubscribeReceiveEventArgs<TabletPushData>>(
                    delegate(IScmPushClient client, SubscribeReceiveEventArgs<TabletPushData> args)
                    {
                        // --------------- ADD START 2013/07/10 wangl2 FOR Redmine#38118------>>>>
                        // UPD 2013/08/01 �g�� Redmine#39489 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //if (this._residentController.Match() == false)
                        if (this._residentController.Match(_enterpriseCode,_sectionCode) == false)
                        // UPD 2013/08/01 �g�� Redmine#39489 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        {
                            return;
                        }
                        // --------------- ADD END 2013/07/10 wangl2 FOR Redmine#38118--------<<<<
                        // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //// �^�u���b�g���O�Ή��@--------------------------------->>>>>
                        //EasyLogger.Write(CLASS_NAME, methodName, "�����������풓�����񓚏����@�J�n����������");
                        //// �^�u���b�g���O�Ή��@---------------------------------<<<<<
                        EasyLogger.Name = DEFAULT_NAME;
                        EasyLogger.Write(CLASS_NAME, methodName, "���풓�����񓚏����@�J�n��");
                        // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        // SF.NS����₢���킹�����̓e�X�g���b�Z�[�W���󂯎�ꂽ��A���̃��\�b�h���Ăт���
                        Invoke(new MethodInvoker(delegate()
                        {
                            // Push�T�[�o�[����Push�f�[�^�擾�̌㏈��
                            TabletPushData data = args.Payload;

                            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            string message = string.Empty;
                            string enterpriseCode = string.Empty;
                            string sectionCode = string.Empty;
                            string sessionid = string.Empty;
                            switch (data.ProcKind)
                            {
                                // ������� = �u�ݒ�}�X�^�A�b�v���[�h�v�̏ꍇ
                                case SET_MAST_UP_LOAD:
                                    {
                                        //# region <TODO�F�ꎞ�R�����g�Ƃ���>// DEL 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.5�̑Ή�
                                        # region// ADD 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.5�̑Ή�
                                        // --- DEL 2013/08/23 �O�� �e�����񓯊��Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>

                                        //PMTabSCMUpLoadMastAcs pmTabSCMUpLoadMastAcs = new PMTabSCMUpLoadMastAcs();
                                        //#region �p�����[�^����
                                        //// ��ƃR�[�h: TabletPushData�N���X�v���p�e�B�̊�ƃR�[�h
                                        //enterpriseCode = data.EnterpriseCode;
                                        //// ���_�R�[�h: TabletPushData�N���X�v���p�e�B�̋��_�R�[�h
                                        //sectionCode = data.SectionCode;
                                        //#endregion

                                        //// �^�u���b�g���O�Ή��@--------------------------------->>>>>
                                        //EasyLogger.Write(CLASS_NAME, methodName, "�ݒ�}�X�^�A�b�v���[�h");
                                        //EasyLogger.Write(CLASS_NAME, methodName, "��ƃR�[�h�F" + enterpriseCode + "  ���_�R�[�h�F" + sectionCode);
                                        //// �^�u���b�g���O�Ή��@---------------------------------<<<<<

                                        //// �����񓚏����i�ݒ�}�X�^�j���Ăяo��
                                        //status = pmTabSCMUpLoadMastAcs.PMTabMastSCMUpLoad(enterpriseCode, sectionCode);
                                        // --- DEL 2013/08/23 �O�� �e�����񓯊��Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<

                                        #endregion

                                        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        EasyLogger.Name = DEFAULT_NAME;
                                        EasyLogger.Write(CLASS_NAME, methodName, "�ݒ�}�X�^�A�b�v���[�h");
                                        EasyLogger.Write(CLASS_NAME, methodName, "��ƃR�[�h�F" + data.EnterpriseCode + "  ���_�R�[�h�F" + data.SectionCode);
                                        setMastUpLoadAsyncCall caller = setMastUpLoad;
                                        IAsyncResult result = caller.BeginInvoke(data, methodName, null, null);  //�񓯊��Ăяo���J�n
                                        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<

                                        break;
                                    }
                                
                                // ������� = �u�����񓚏����i���Ӑ���j�v�̏ꍇ
                                case AUTO_ANSWER_CUST_INFO:
                                    {
                                        # region// DEL 2013/08/23 �O�� �e�����񓯊��Ή�
                                        // --- DEL 2013/08/23 �O�� �e�����񓯊��Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        //TabSCMCustomerAcs tabSCMCustomerAcs = new TabSCMCustomerAcs();
                                        //#region �p�����[�^����

                                        //// ��ƃR�[�h: TabletPushData�N���X�v���p�e�B�̊�ƃR�[�h
                                        //enterpriseCode = data.EnterpriseCode;

                                        //// ���_�R�[�h: TabletPushData�N���X�v���p�e�B�̋��_�R�[�h
                                        //sectionCode = data.SectionCode;

                                        //// �Ɩ��Z�b�V����ID: TabletPushData�N���X�v���p�e�B�̋Ɩ��Z�b�V����ID
                                        //sessionid = data.SessionId;

                                        //// ���׎���GUI: TabletPushData�N���X�v���p�e�B�̖��׎���GUID
                                        //string guidId = data.GuidId;
                                        //string[] param = data.Param.Split(new char[1] { ':' });

                                        //string custNameKana = string.Empty;
                                        //// ���Ӑ於�J�i: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂P�Ԗ�
                                        //if (param.Length >= 1)
                                        //{
                                        //    custNameKana = param[0];
                                        //}

                                        //int custcode = 0;
                                        //// ���Ӑ�R�[�h: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂Q�Ԗ�
                                        //if (param.Length >= 2)
                                        //{
                                        //    if (!string.IsNullOrEmpty(param[1]))
                                        //    {
                                        //        custcode = Convert.ToInt32(param[1]);
                                        //    }
                                        //    else 
                                        //    {
                                        //        custcode = 0;
                                        //    }
                                        //}

                                        //string mngSectionCode = string.Empty;
                                        //// �Ǘ����_: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂R�Ԗ�
                                        //if (param.Length >= 3)
                                        //{
                                        //    mngSectionCode = param[2];
                                        //}

                                        //int kanaSearchDiv = 0;
                                        //// �Ŗ������敪: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂S�Ԗ�
                                        //if (param.Length >= 4)
                                        //{
                                        //    kanaSearchDiv = Convert.ToInt32(param[3]);
                                        //}

                                        //#endregion

                                        //// �^�u���b�g���O�Ή��@--------------------------------->>>>>
                                        //EasyLogger.Write(CLASS_NAME, methodName, "�����񓚏����i���Ӑ���j");
                                        //EasyLogger.Write(CLASS_NAME, methodName, 
                                        //    "��ƃR�[�h�F" + enterpriseCode
                                        //    + "  ���_�R�[�h�F" + sectionCode
                                        //    + "  �Ɩ��Z�b�V����ID�F" + sessionid
                                        //    + "  ���׎���GUID�F" + guidId
                                        //    + "  ���Ӑ於�J�i�F" + custNameKana
                                        //    + "  ���Ӑ�R�[�h�F" + custcode
                                        //    + "  �Ǘ����_�F" + mngSectionCode
                                        //    + "  �Ŗ������敪�F" + kanaSearchDiv
                                        //    );
                                        //// �^�u���b�g���O�Ή��@---------------------------------<<<<<

                                        //// �����񓚏����i���Ӑ���j���Ăяo��
                                        //status = tabSCMCustomerAcs.SearchCustomerDataForTablet(enterpriseCode, sectionCode, sessionid, custNameKana, custcode, mngSectionCode, kanaSearchDiv, out message);
                                        // --- DEL 2013/08/23 �O�� �e�����񓯊��Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                        #endregion

                                        // ADD 2013/09/02 Redmine#40121 ----------------------------------------->>>>>
                                        // Tablet�[���ւ̕ԓ����M����
                                        NotifyTabletByPublish(status, message, data.SessionId, (int)ScmPushDataConstMode.CHECNK1WAITESEND);
                                        // ADD 2013/09/02 Redmine#40121 -----------------------------------------<<<<<

                                        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        #region �p�����[�^����
                                        string[] param = data.Param.Split(new char[1] { ':' });

                                        string custNameKana = string.Empty;
                                        // ���Ӑ於�J�i: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂P�Ԗ�
                                        if (param.Length >= 1)
                                        {
                                            custNameKana = param[0];
                                        }

                                        int custcode = 0;
                                        // ���Ӑ�R�[�h: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂Q�Ԗ�
                                        if (param.Length >= 2)
                                        {
                                            if (!string.IsNullOrEmpty(param[1]))
                                            {
                                                custcode = Convert.ToInt32(param[1]);
                                            }
                                            else
                                            {
                                                custcode = 0;
                                            }
                                        }

                                        string mngSectionCode = string.Empty;
                                        // �Ǘ����_: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂R�Ԗ�
                                        if (param.Length >= 3)
                                        {
                                            mngSectionCode = param[2];
                                        }

                                        int kanaSearchDiv = 0;
                                        // �Ŗ������敪: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂S�Ԗ�
                                        if (param.Length >= 4)
                                        {
                                            kanaSearchDiv = Convert.ToInt32(param[3]);
                                        }
                                        #endregion

                                        EasyLogger.Name = DEFAULT_NAME;
                                        EasyLogger.Write(CLASS_NAME, methodName, "�����񓚏����i���Ӑ���j");
                                        EasyLogger.Write(CLASS_NAME, methodName,
                                            "��ƃR�[�h�F" + data.EnterpriseCode
                                            + "  ���_�R�[�h�F" + data.SectionCode
                                            + "  �Ɩ��Z�b�V����ID�F" + data.SectionCode
                                            + "  ���׎���GUID�F" + data.GuidId
                                            + "  ���Ӑ於�J�i�F" + custNameKana
                                            + "  ���Ӑ�R�[�h�F" + custcode
                                            + "  �Ǘ����_�F" + mngSectionCode
                                            + "  �Ŗ������敪�F" + kanaSearchDiv
                                            );

                                        autoAnswerCustInfoAsyncCall caller = autoAnswerCustInfo;
                                        IAsyncResult result = caller.BeginInvoke(methodName, data.EnterpriseCode, data.SectionCode, data.SessionId, custNameKana, custcode, mngSectionCode, kanaSearchDiv, null, null);  //�񓯊��Ăяo���J�n
                                        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<

                                        break;
                                    }
                                // ������� = �u�����񓚏����i�����j�v�̏ꍇ
                                case AUTO_ANSWER_SEARCH:
                                    {
                                        //# region <TODO�F�ꎞ�R�����g�Ƃ���> // DEL 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.5�̑Ή�
                                        # region  // ADD 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.5�̑Ή�
                                        // --- DEL 2013/08/23 �O�� �e�����񓯊��Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        //ScmSearchForTablet scmSearchForTablet = new ScmSearchForTablet();

                                        //#region �p�����[�^����
                                        //// ��ƃR�[�h: TabletPushData�N���X�v���p�e�B�̊�ƃR�[�h
                                        //enterpriseCode = data.EnterpriseCode;

                                        //// ���_�R�[�h: TabletPushData�N���X�v���p�e�B�̋��_�R�[�h
                                        //sectionCode = data.SectionCode;

                                        //// �Ɩ��Z�b�V����ID: TabletPushData�N���X�v���p�e�B�̋Ɩ��Z�b�V����ID
                                        //sessionid = data.SessionId;

                                        //// ���׎���GUID: TabletPushData�N���X�v���p�e�B�̖��׎���GUID
                                        //string guidId = data.GuidId;

                                        //string[] param = data.Param.Split(new char[1] { ':' });

                                        //string goodNo = string.Empty;
                                        //// ���i�ԍ�: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂P�Ԗ�
                                        //if (param.Length >= 1)
                                        //{
                                        //    goodNo = param[0];
                                        //}

                                        //int blCode = 0;
                                        //// BL�R�[�h: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂Q�Ԗ�
                                        //if (param.Length >= 2)
                                        //{
                                        //    blCode = Convert.ToInt32(param[1]);
                                        //}

                                        //int custCode = 0;
                                        //// ���Ӑ�R�[�h: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂R�Ԗ�
                                        //if (param.Length >= 3)
                                        //{
                                        //    custCode = Convert.ToInt32(param[2]);
                                        //}

                                        //#endregion

                                        //// �^�u���b�g���O�Ή��@--------------------------------->>>>>
                                        //EasyLogger.Write(CLASS_NAME, methodName, "�����񓚏����i�����j");
                                        //EasyLogger.Write(CLASS_NAME, methodName,
                                        //    "��ƃR�[�h�F" + enterpriseCode
                                        //    + "  ���_�R�[�h�F" + sectionCode
                                        //    + "  �Ɩ��Z�b�V����ID�F" + sessionid
                                        //    + "  ���׎���GUID�F" + guidId
                                        //    + "  ���i�ԍ��F" + goodNo
                                        //    + "  BL�R�[�h�F" + blCode
                                        //    + "  ���Ӑ�R�[�h�F" + custCode
                                        //    );
                                        //// �^�u���b�g���O�Ή��@---------------------------------<<<<<
                                        //// �����񓚏����i�����j���Ăяo��
                                        //status = scmSearchForTablet.SearchForTablet(enterpriseCode, sectionCode, goodNo, blCode, custCode, sessionid, guidId, out message);
                                        // --- DEL 2013/08/23 �O�� �e�����񓯊��Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                        #endregion

                                        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        #region �p�����[�^����
                                        string[] param = data.Param.Split(new char[1] { ':' });

                                        string goodNo = string.Empty;
                                        // ���i�ԍ�: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂P�Ԗ�
                                        if (param.Length >= 1)
                                        {
                                            goodNo = param[0];
                                        }

                                        int blCode = 0;
                                        // BL�R�[�h: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂Q�Ԗ�
                                        if (param.Length >= 2)
                                        {
                                            blCode = Convert.ToInt32(param[1]);
                                        }

                                        int custCode = 0;
                                        // ���Ӑ�R�[�h: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂R�Ԗ�
                                        if (param.Length >= 3)
                                        {
                                            custCode = Convert.ToInt32(param[2]);
                                        }
                                        #endregion

                                        EasyLogger.Name = DEFAULT_NAME;
                                        EasyLogger.Write(CLASS_NAME, methodName, "�����񓚏����i�����j");
                                        EasyLogger.Write(CLASS_NAME, methodName,
                                            "��ƃR�[�h�F" + data.EnterpriseCode
                                            + "  ���_�R�[�h�F" + data.SectionCode
                                            + "  �Ɩ��Z�b�V����ID�F" + data.SessionId
                                            + "  ���׎���GUID�F" + data.GuidId
                                            + "  ���i�ԍ��F" + goodNo
                                            + "  BL�R�[�h�F" + blCode
                                            + "  ���Ӑ�R�[�h�F" + custCode
                                            );

                                        autoAnswerSearchAsyncCall caller = autoAnswerSearch;
                                        IAsyncResult result = caller.BeginInvoke(methodName, data.EnterpriseCode, data.SectionCode, data.SessionId, goodNo, blCode, custCode, data.GuidId, null, null);  //�񓯊��Ăяo���J�n
                                        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                        break;
          
                                    }
                                // ������� = �u�����񓚏����i�f�[�^�o�^�j�v�̏ꍇ
                                case AUTO_ANSWER_DATA_CREATE:
                                    {
                                        # region// DEL 2013/08/23 �O�� �e�����񓯊��Ή�
                                        // --- DEL 2013/08/23 �O�� �e�����񓯊��Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        //#region �p�����[�^����

                                        //// ��ƃR�[�h: TabletPushData�N���X�v���p�e�B�̊�ƃR�[�h
                                        //enterpriseCode = data.EnterpriseCode;

                                        //// ���_�R�[�h: TabletPushData�N���X�v���p�e�B�̋��_�R�[�h
                                        //sectionCode = data.SectionCode;

                                        //// �Ɩ��Z�b�V����ID: TabletPushData�N���X�v���p�e�B�̋Ɩ��Z�b�V����ID
                                        //sessionid = data.SessionId;

                                        //#endregion

                                        //// �^�u���b�g���O�Ή��@--------------------------------->>>>>
                                        //EasyLogger.Write(CLASS_NAME, methodName, "�����񓚏����i�f�[�^�o�^�j");
                                        //EasyLogger.Write(CLASS_NAME, methodName,
                                        //    "��ƃR�[�h�F" + enterpriseCode
                                        //    + "  ���_�R�[�h�F" + sectionCode
                                        //    + "  �Ɩ��Z�b�V����ID�F" + sessionid
                                        //    );
                                        //// �^�u���b�g���O�Ή��@---------------------------------<<<<<

                                        //CustomerInfo customerInfo;
                                        //TabSCMSalesDataMaker tabSCMSalesDataMaker = new TabSCMSalesDataMaker(Program.argsSave[0] + " " + Program.argsSave[1]);

                                        //ConstantManagement.MethodResult result = tabSCMSalesDataMaker.Reply(enterpriseCode, sectionCode, sessionid, out message, out customerInfo);
                                        //status = (int)result;

                                        //// ������o�^�̒񎦂��|�b�v�A�b�v
                                        //if (result == ConstantManagement.MethodResult.ctFNC_NORMAL && null != customerInfo)
                                        //{
                                        //    this._dataTable.Clear();
                                        //    DataRow dr = this._dataTable.NewRow();
                                        //    dr[ctColumnName_CustomerCdName] = BLANK + customerInfo.CustomerCode + " " + customerInfo.CustomerSnm;
                                        //    this._dataTable.Rows.Add(dr);

                                        //    AppSettingsSection appSettingSection = GetAppSettingsSection();
                                        //    if (appSettingSection.Settings[CT_Conf_SaleSlipCreateView].Value.Equals("1"))
                                        //    {
                                        //        this.ShowPopup(this, new ReceivedEventArgs());
                                        //    }
                                        //}
                                        // --- DEL 2013/08/23 �O�� �e�����񓯊��Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                        #endregion

                                        // ADD 2013/08/26 Redmine#40121 ----------------------------------------->>>>>
                                        // Tablet�[���ւ̕ԓ����M����
                                        NotifyTabletByPublish(status, message, data.SessionId, (int)ScmPushDataConstMode.CHECNK1WAITESEND);
                                        // ADD 2013/08/26 Redmine#40121 -----------------------------------------<<<<<

                                        // ADD 2013/08/30 Redmine#40121 yugami ----------------------------------------->>>>>
                                        if (!this._sessionIdDic.ContainsKey(data.SessionId))
                                        {
                                            this._sessionIdDic.Add(data.SessionId, null);
                                        }
                                        // ADD 2013/08/30 Redmine#40121 yugami -----------------------------------------<<<<<

                                        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        EasyLogger.Name = DEFAULT_NAME;
                                        EasyLogger.Write(CLASS_NAME, methodName, "�����񓚏����i�f�[�^�o�^�j");
                                        EasyLogger.Write(CLASS_NAME, methodName,
                                            "��ƃR�[�h�F" + data.EnterpriseCode
                                            + "  ���_�R�[�h�F" + data.SectionCode
                                            + "  �Ɩ��Z�b�V����ID�F" + data.SessionId
                                            );
                                        autoAnswerDataCreateAsyncCall caller = autoAnswerDataCreate;
                                        IAsyncResult result = caller.BeginInvoke(data, methodName, new AsyncCallback(autoAnswerDataCreateCallback), null);  //�񓯊��Ăяo���J�n
                                        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<

                                        break;
                                    }
                                // ������� = �u�����񓚏����i���Ӑ�d�q�����j�v�̏ꍇ
                                case AUTO_ANSWER_SLIP_LIST:
                                    {
                                        //# region <TODO�F�ꎞ�R�����g�Ƃ���>// DEL 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.5�̑Ή�
                                        # region // ADD 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.5�̑Ή�
                                        // --- DEL 2013/08/23 �O�� �e�����񓯊��Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        //CustPrtSlipTabSearchAcs custPrtSlipTabSearchAcs = new CustPrtSlipTabSearchAcs();
                                        //custPrtSlipTabSearchAcs.notifyTabletByPublish += new CustPrtSlipTabSearchAcs.NotifyTabletByPublishEventHandler(NotifyTabletByPublish);

                                        //#region �p�����[�^����

                                        //// ��ƃR�[�h: TabletPushData�N���X�v���p�e�B�̊�ƃR�[�h
                                        //enterpriseCode = data.EnterpriseCode;

                                        //// ���_�R�[�h: TabletPushData�N���X�v���p�e�B�̋��_�R�[�h
                                        //sectionCode = data.SectionCode;
                                        //sessionid = data.SessionId;
                                        //// ��������: TabletPushData�N���X�v���p�e�B�̌�������
                                        //string jsonString = data.SearchCondition.ToString();
                                        //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CustPrtParaWork));
                                        //MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                                        //CustPrtParaWork custPrtParaWork = (CustPrtParaWork)ser.ReadObject(ms);
                                        //CustPrtPprWork custPrtPprWork = new CustPrtPprWork();
                                        ////custPrtPprWork.AcptAnOdrStatus = new int[] { Convert.ToInt32(custPrtParaWork.AcptAnOdrStatus) };// DEL 2013/06/20 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.49�̑Ή�
                                        //// --------------- ADD START 2013/06/20 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.49�̑Ή� ------>>>>
                                        //if (custPrtParaWork.AcptAnOdrStatus == "-1")
                                        //{
                                        //    custPrtPprWork.AcptAnOdrStatus = new int[] { 20, 30, 40 };
                                        //}
                                        //else 
                                        //{ 
                                        //    custPrtPprWork.AcptAnOdrStatus = new int[] { Convert.ToInt32(custPrtParaWork.AcptAnOdrStatus) };
                                        //}
                                        //if (custPrtParaWork.SalesSlipCd == "-1")
                                        //{
                                        //    custPrtPprWork.SalesSlipCd = new int[] { 0, 1 };
                                        //}

                                        //else
                                        //{
                                        //    custPrtPprWork.SalesSlipCd = new int[] { Convert.ToInt32(custPrtParaWork.SalesSlipCd) };
                                        //}
                                        //// --------------- ADD END 2013/06/20 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.49�̑Ή� ------<<<<
                                        //// --------------- ADD START 2013/06/25 wangl2 FOR Redmin#37163 ------>>>>
                                        //if (!string.IsNullOrEmpty(custPrtParaWork.CustomerCode))
                                        //{
                                        //    custPrtPprWork.CustomerCode = Convert.ToInt32(custPrtParaWork.CustomerCode);
                                        //}
                                        //else 
                                        //{
                                        //    custPrtPprWork.CustomerCode = 0;
                                        //}
                                        //// --------------- ADD END 2013/06/25 wangl2 FOR Redmin#37163 ------<<<<
                                        //custPrtPprWork.St_SalesDate = GetDate(Convert.ToInt64(custPrtParaWork.SalesDateSt));
                                        //custPrtPprWork.Ed_SalesDate = GetDate(Convert.ToInt64(custPrtParaWork.SalesDateEd));
                                        //custPrtPprWork.SectionCode = new string[] { custPrtParaWork.SearchSectionCode };
                                        ////custPrtPprWork.SalesSlipCd = new int[] { Convert.ToInt32(custPrtParaWork.SalesSlipCd) };// DEL 2013/06/20 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.49�̑Ή�
                                        //custPrtPprWork.SearchType = Convert.ToInt32(custPrtParaWork.SalesDepoDiv);
                                        //custPrtPprWork.SearchType++; // ADD 2013/06/20 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.49�̑Ή�
                                        //string[] param = data.Param.Split(new char[1] { ':' });

                                        //string pmTabSearchGuid = param[0];

                                        //int notifyCount = 0;
                                        //// �ʒm����: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂Q�Ԗ�
                                        //if (param.Length >= 2)
                                        //{
                                        //    notifyCount = Convert.ToInt32(param[1]);
                                        //}

                                        //#endregion
                                       
                                        //// �^�u���b�g���O�Ή��@--------------------------------->>>>>
                                        //EasyLogger.Write(CLASS_NAME, methodName, "�����񓚏����i���Ӑ�d�q�����j");
                                        //EasyLogger.Write(CLASS_NAME, methodName,
                                        //    "��ƃR�[�h�F" + enterpriseCode
                                        //    + "  ���_�R�[�h�F" + sectionCode
                                        //    + "  �Ɩ��Z�b�V����ID�F" + sessionid
                                        //    + "  ��������.AcptAnOdrStatus�F" + EasyLogger.LogUtlIntAryToCsv(custPrtPprWork.AcptAnOdrStatus)
                                        //    + "  ��������.St_SalesDate�F" + custPrtPprWork.St_SalesDate.ToString()
                                        //    + "  ��������.Ed_SalesDate�F" + custPrtPprWork.Ed_SalesDate.ToString()
                                        //    + "  ��������.SectionCode�F" + string.Join(",", custPrtPprWork.SectionCode)
                                        //    + "  ��������.SalesSlipCd�F" + EasyLogger.LogUtlIntAryToCsv(custPrtPprWork.SalesSlipCd)
                                        //    + "  ��������.SearchType�F" + custPrtPprWork.SearchType.ToString()
                                        //    + "  ��������.CustomerCode�F" + custPrtPprWork.CustomerCode.ToString() // ADD 2013/06/25 wangl2 FOR Redmin#37163
                                        //    + "  PMTAB����GUID�F" + pmTabSearchGuid
                                        //    + "  �ʒm�����F" + notifyCount.ToString()
                                        //    );
                                        //// �^�u���b�g���O�Ή��@---------------------------------<<<<<

                                        //// PMTAB �����񓚏���(���Ӑ�d�q����)
                                        //status = custPrtSlipTabSearchAcs.SearchPmToScm(enterpriseCode, sectionCode, custPrtPprWork, pmTabSearchGuid, notifyCount, out message);
                                        // --- DEL 2013/08/23 �O�� �e�����񓯊��Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                        #endregion


                                        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        #region �p�����[�^����
                                        // ��������: TabletPushData�N���X�v���p�e�B�̌�������
                                        string jsonString = data.SearchCondition.ToString();
                                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CustPrtParaWork));
                                        MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                                        CustPrtParaWork custPrtParaWork = (CustPrtParaWork)ser.ReadObject(ms);
                                        CustPrtPprWork custPrtPprWork = new CustPrtPprWork();
                                        if (custPrtParaWork.AcptAnOdrStatus == "-1")
                                        {
                                            custPrtPprWork.AcptAnOdrStatus = new int[] { 20, 30, 40 };
                                        }
                                        else
                                        {
                                            custPrtPprWork.AcptAnOdrStatus = new int[] { Convert.ToInt32(custPrtParaWork.AcptAnOdrStatus) };
                                        }
                                        if (custPrtParaWork.SalesSlipCd == "-1")
                                        {
                                            custPrtPprWork.SalesSlipCd = new int[] { 0, 1 };
                                        }

                                        else
                                        {
                                            custPrtPprWork.SalesSlipCd = new int[] { Convert.ToInt32(custPrtParaWork.SalesSlipCd) };
                                        }
                                        if (!string.IsNullOrEmpty(custPrtParaWork.CustomerCode))
                                        {
                                            custPrtPprWork.CustomerCode = Convert.ToInt32(custPrtParaWork.CustomerCode);
                                        }
                                        else
                                        {
                                            custPrtPprWork.CustomerCode = 0;
                                        }
                                        custPrtPprWork.St_SalesDate = GetDate(Convert.ToInt64(custPrtParaWork.SalesDateSt));
                                        custPrtPprWork.Ed_SalesDate = GetDate(Convert.ToInt64(custPrtParaWork.SalesDateEd));
                                        custPrtPprWork.SectionCode = new string[] { custPrtParaWork.SearchSectionCode };
                                        custPrtPprWork.SearchType = Convert.ToInt32(custPrtParaWork.SalesDepoDiv);
                                        custPrtPprWork.SearchType++;
                                        string[] param = data.Param.Split(new char[1] { ':' });

                                        string pmTabSearchGuid = param[0];

                                        int notifyCount = 0;
                                        // �ʒm����: TabletPushData�N���X�v���p�e�B�̃p�����[�^�̂Q�Ԗ�
                                        if (param.Length >= 2)
                                        {
                                            notifyCount = Convert.ToInt32(param[1]);
                                        }
                                        #endregion

                                        EasyLogger.Name = DEFAULT_NAME;
                                        EasyLogger.Write(CLASS_NAME, methodName, "�����񓚏����i���Ӑ�d�q�����j");
                                        EasyLogger.Write(CLASS_NAME, methodName,
                                            "��ƃR�[�h�F" + data.EnterpriseCode
                                            + "  ���_�R�[�h�F" + data.SectionCode
                                            + "  �Ɩ��Z�b�V����ID�F" + data.SessionId
                                            + "  ��������.AcptAnOdrStatus�F" + EasyLogger.LogUtlIntAryToCsv(custPrtPprWork.AcptAnOdrStatus)
                                            + "  ��������.St_SalesDate�F" + custPrtPprWork.St_SalesDate.ToString()
                                            + "  ��������.Ed_SalesDate�F" + custPrtPprWork.Ed_SalesDate.ToString()
                                            + "  ��������.SectionCode�F" + string.Join(",", custPrtPprWork.SectionCode)
                                            + "  ��������.SalesSlipCd�F" + EasyLogger.LogUtlIntAryToCsv(custPrtPprWork.SalesSlipCd)
                                            + "  ��������.SearchType�F" + custPrtPprWork.SearchType.ToString()
                                            + "  ��������.CustomerCode�F" + custPrtPprWork.CustomerCode.ToString() // ADD 2013/06/25 wangl2 FOR Redmin#37163
                                            + "  PMTAB����GUID�F" + pmTabSearchGuid
                                            + "  �ʒm�����F" + notifyCount.ToString()
                                            );

                                        autoAnswerSlipListAsyncCall caller = autoAnswerSlipList;
                                        IAsyncResult result = caller.BeginInvoke(methodName, data.EnterpriseCode, data.SectionCode, data.SessionId, custPrtPprWork, pmTabSearchGuid, notifyCount, null, null); //�񓯊��Ăяo���J�n
                                        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<

                                        break;
                                    }
                            }

                            // --- DEL 2013/08/23 �O�� �e�����񓯊��Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>
                            //// WebSync�ɒʒm����
                            //// UPD 2013/08/16 �g�� Redmine#39972 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //// this.NotifyTabletByPublish(status, message, sessionid);
                            //// �����񓚏����i�f�[�^�o�^�j�̏ꍇ�́APMTAB00152A�Œʒm��Ԃ��̂ŁA�����ł͎��{���Ȃ�
                            //if (!data.ProcKind.Equals(AUTO_ANSWER_DATA_CREATE))
                            //{
                            //    this.NotifyTabletByPublish(status, message, sessionid);
                            //}
                            //// UPD 2013/08/16 �g�� Redmine#39972 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            // --- DEL 2013/08/23 �O�� �e�����񓯊��Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        }));
                        // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //// �^�u���b�g���O�Ή��@--------------------------------->>>>>
                        //EasyLogger.Write(CLASS_NAME, methodName, "�����������풓�����񓚏����@�I������������");
                        //// �^�u���b�g���O�Ή��@---------------------------------<<<<<
                        EasyLogger.Name = DEFAULT_NAME;
                        EasyLogger.Write(CLASS_NAME, methodName, "���풓�����񓚏����@�I����");
                        // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                 );
                _tabletPushClient.Subscribe<TabletPushData>(subscribeArgs);
            //}// DEL 2013/06/27 wangl2 FOR Redmine#37412
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                EasyLogger.Name = DEFAULT_NAME;
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �񓯊��f���Q�[�g�̒�`�i�ݒ�}�X�^�A�b�v���[�h�j
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        delegate void setMastUpLoadAsyncCall(TabletPushData data, string methodName);

        /// <summary>
        /// �񓯊��f���Q�[�g�̒�`�i�����񓚏����i���Ӑ���j�j
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        delegate void autoAnswerCustInfoAsyncCall(string methodName, string enterpriseCode, string sectionCode, string sessionid, string custNameKana, int custcode, string mngSectionCode, int kanaSearchDiv);

        /// <summary>
        /// �񓯊��f���Q�[�g�̒�`�i�����񓚏����i�����j�j
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        delegate void autoAnswerSearchAsyncCall(string methodName, string enterpriseCode, string sectionCode, string sessionid, string goodNo, int blCode, int custCode, string guidId);

        /// <summary>
        /// �񓯊��f���Q�[�g�̒�`�i�����񓚏����i�f�[�^�o�^�j�j
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        delegate void autoAnswerDataCreateAsyncCall(TabletPushData data, string methodName);

        /// <summary>
        /// �񓯊��f���Q�[�g�̒�`�i�����񓚏����i���Ӑ�d�q�����j�j
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        delegate void autoAnswerSlipListAsyncCall(string methodName, string enterpriseCode, string sectionCode, string sessionid, CustPrtPprWork custPrtPprWork, string pmTabSearchGuid, int notifyCount);

        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
        /// <summary>
        /// �񓯊��f���Q�[�g�̒�`�i���i�����A�N�Z�X�N���X�L���b�V�������j
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        delegate void searchInitialAsyncCall();
        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<

        /// <summary>
        /// �ݒ�}�X�^�A�b�v���[�h�Ăяo��
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        private void setMastUpLoad(TabletPushData data, string methodName)
        {
            System.Threading.Monitor.Enter(setMastUpLoadLock);
            try
            {
                PMTabSCMUpLoadMastAcs pmTabSCMUpLoadMastAcs = new PMTabSCMUpLoadMastAcs();
                #region �p�����[�^����
                // ��ƃR�[�h: TabletPushData�N���X�v���p�e�B�̊�ƃR�[�h
                string enterpriseCode = data.EnterpriseCode;
                // ���_�R�[�h: TabletPushData�N���X�v���p�e�B�̋��_�R�[�h
                string sectionCode = data.SectionCode;
                string message = string.Empty;
                string sessionid = data.SessionId;
                #endregion

                // �����񓚏����i�ݒ�}�X�^�j���Ăяo��
                int status = pmTabSCMUpLoadMastAcs.PMTabMastSCMUpLoad(enterpriseCode, sectionCode);

                this.NotifyTabletByPublish(status, message, sessionid);
            }
            finally
            {
                System.Threading.Monitor.Exit(setMastUpLoadLock);
            }
        }

        /// <summary>
        /// �����񓚏����i���Ӑ���j�Ăяo��
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        private void autoAnswerCustInfo(string methodName, string enterpriseCode, string sectionCode, string sessionid, string custNameKana, int custcode, string mngSectionCode, int kanaSearchDiv)
        {
            System.Threading.Monitor.Enter(autoAnswerCustInfoLock);
            try
            {
                TabSCMCustomerAcs tabSCMCustomerAcs = new TabSCMCustomerAcs();

                string message = string.Empty;

                // �����񓚏����i���Ӑ���j���Ăяo��
                int status = tabSCMCustomerAcs.SearchCustomerDataForTablet(enterpriseCode, sectionCode, sessionid, custNameKana, custcode, mngSectionCode, kanaSearchDiv, out message);

                this.NotifyTabletByPublish(status, message, sessionid);

                // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
                // ���i�����A�N�Z�X�N���X�̃L���b�V������
                searchInitialAsyncCall caller = SearchInitial;
                IAsyncResult result = caller.BeginInvoke(null, null);  //�񓯊��Ăяo���J�n
                // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<

            }
            finally
            {
                System.Threading.Monitor.Exit(autoAnswerCustInfoLock);
            }
        }

        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
        /// <summary>
        ///  ���i�����A�N�Z�X�N���X�L���b�V������
        /// </summary>
        public void SearchInitial()
        {
            System.Threading.Monitor.Enter(searchInitialLock);
            try
            {
                string msg = string.Empty;
                // ���i�����A�N�Z�X�N���X�L���b�V���Ώ�
                if (_cacheInitType == 1)
                {
                    if (_cacheInUsedType == 2)
                    {
                        // �Q�Ԗڂ̃N���X���g�p���̂��߂P�Ԗڂ̃N���X�ɃL���b�V�����܂�
                        _goodsAccesser1 = new GoodsAcs(LoginInfoAcquisition.Employee.BelongSectionCode);
                        // ���i�����A�N�Z�X�N���X�L���b�V������
                        _goodsAccesser1.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
                        // �P�Ԗڂ��L���b�V����
                        _cacheInitType = 1;
                    }
                    else
                    {
                        // �P�Ԗڂ��L���b�V���ς̂��߂Q�ԖڂɃL���b�V�����܂�
                        _goodsAccesser2 = new GoodsAcs(LoginInfoAcquisition.Employee.BelongSectionCode);
                        // ���i�����A�N�Z�X�N���X�L���b�V������
                        _goodsAccesser2.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
                        // �Q�Ԗڂ��L���b�V����
                        _cacheInitType = 2;
                    }
                }
                else
                {
                    if (_cacheInUsedType == 1)
                    {
                        // �P�Ԗڂ̃N���X���g�p���̂��߂Q�Ԗڂ̃N���X�ɃL���b�V�����܂�
                        _goodsAccesser2 = new GoodsAcs(LoginInfoAcquisition.Employee.BelongSectionCode);
                        // ���i�����A�N�Z�X�N���X�L���b�V������
                        _goodsAccesser2.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
                        // �Q�Ԗڂ��L���b�V����
                        _cacheInitType = 2;
                    }
                    else
                    {
                        // �Q�Ԗڂ��L���b�V���ς̂��߂P�ԖڂɃL���b�V�����܂�
                        _goodsAccesser1 = new GoodsAcs(LoginInfoAcquisition.Employee.BelongSectionCode);
                        // ���i�����A�N�Z�X�N���X�L���b�V������
                        _goodsAccesser1.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
                        // �P�Ԗڂ��L���b�V����
                        _cacheInitType = 1;
                    }
                }
                // �L�����y�[�������D��ݒ�}�X�^�A�N�Z�X�N���X
                ArrayList campaignPrcPrStList = new ArrayList();
                _campaignPrcPrStAcs.SearchAll(out campaignPrcPrStList, LoginInfoAcquisition.EnterpriseCode);
                _campaignPrcPrStList = (ArrayList)campaignPrcPrStList.Clone();
            }
            finally
            {
                System.Threading.Monitor.Exit(searchInitialLock);
            }
        }
        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<

        /// <summary>
        /// �����񓚏����i�����j�Ăяo��
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        private void autoAnswerSearch(string methodName, string enterpriseCode, string sectionCode, string sessionid, string goodNo, int blCode, int custCode, string guidId)
        {
            System.Threading.Monitor.Enter(autoAnswerSearchLock);
            try
            {
                const string methodName2 = "autoAnswerSearch";
                EasyLogger.Name = DEFAULT_NAME;
                EasyLogger.Write(CLASS_NAME, methodName2, "�����񓚏����i�����j�J�n�@SessionId�F" + sessionid);
                ScmSearchForTablet scmSearchForTablet = new ScmSearchForTablet();

                string message = string.Empty;

                // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
                scmSearchForTablet.CampaignPrcPrStList = this._campaignPrcPrStList;
                if (_cacheInitType == 1)
                {
                    // �P�Ԗڂ̃N���X���L���b�V����
                    scmSearchForTablet.GoodsAccesser = this._goodsAccesser1;
                    // �P�Ԗڂ̃N���X���g�p��
                    _cacheInUsedType = 1;
                }
                else
                {
                    // �Q�Ԗڂ̃N���X���L���b�V����
                    scmSearchForTablet.GoodsAccesser = this._goodsAccesser2;
                    // �Q�Ԗڂ̃N���X���g�p��
                    _cacheInUsedType = 2;
                }
                // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<


                // �����񓚏����i�����j���Ăяo��
                int status = scmSearchForTablet.SearchForTablet(enterpriseCode, sectionCode, goodNo, blCode, custCode, sessionid, guidId, out message);

                this.NotifyTabletByPublish(status, message, sessionid);

                // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
                // �g�p���t���O�����
                _cacheInUsedType = 0;
                // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<

            }
            finally
            {
                System.Threading.Monitor.Exit(autoAnswerSearchLock);
            }
        }

        /// <summary>
        /// �����񓚏����i�f�[�^�o�^�j�Ăяo��
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        private void autoAnswerDataCreate(TabletPushData data, string methodName)
        {
            System.Threading.Monitor.Enter(autoAnswerDataCreateLock);
            try
            {
                #region �p�����[�^����

                // ��ƃR�[�h: TabletPushData�N���X�v���p�e�B�̊�ƃR�[�h
                string enterpriseCode = data.EnterpriseCode;

                // ���_�R�[�h: TabletPushData�N���X�v���p�e�B�̋��_�R�[�h
                string sectionCode = data.SectionCode;

                // �Ɩ��Z�b�V����ID: TabletPushData�N���X�v���p�e�B�̋Ɩ��Z�b�V����ID
                string sessionid = data.SessionId;

                string message = string.Empty;

                #endregion

                // ADD 2013/08/26 Redmine#40121 ----------------------------------------->>>>>
                // Tablet�[���ւ̕ԓ����M����
                NotifyTabletByPublish(0, "", data.SessionId, (int)ScmPushDataConstMode.PROCESSING);
                // ADD 2013/08/26 Redmine#40121 -----------------------------------------<<<<<

                TabSCMSalesDataMaker tabSCMSalesDataMaker = new TabSCMSalesDataMaker(Program.argsSave[0] + " " + Program.argsSave[1]);

                resultReply = tabSCMSalesDataMaker.Reply(enterpriseCode, sectionCode, sessionid, out message, out customerInfo);

                // ADD 2013/08/30 Redmine#40121 yugami ------------------------------------------>>>>>
                // ������o�^�̒񎦂��|�b�v�A�b�v
                if (resultReply == ConstantManagement.MethodResult.ctFNC_NORMAL && null != customerInfo)
                {
                    this._dataTable.Rows[0][ctColumnName_CustomerCdName] = BLANK + customerInfo.CustomerCode + " " + customerInfo.CustomerSnm;

                    AppSettingsSection appSettingSection = GetAppSettingsSection();
                    if (appSettingSection.Settings[CT_Conf_SaleSlipCreateView].Value.Equals("1"))
                    {
                        this.ShowPopup(this, new ReceivedEventArgs());
                    }
                }

                // sessionId�f�B�N�V���i����菜�O
                System.Threading.Monitor.Enter(sessionIdDicLock);
                try
                {
                    this._sessionIdDic.Remove(data.SessionId);
                }
                finally
                {
                    System.Threading.Monitor.Exit(sessionIdDicLock);
                }
                // ADD 2013/08/30 Redmine#40121 yugami ------------------------------------------<<<<<

            }
            finally
            {
                System.Threading.Monitor.Exit(autoAnswerDataCreateLock);
            }
        }

        /// <summary>
        /// �����񓚏����i�f�[�^�o�^�j�����R�[���o�b�N
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        private void autoAnswerDataCreateCallback(IAsyncResult result)
        {
            // DEL 2013/08/30 Redmine#40121 yugami ------------------------------------------------------->>>>>
            // ������o�^�̒񎦂��|�b�v�A�b�v
            //if (resultReply == ConstantManagement.MethodResult.ctFNC_NORMAL && null != customerInfo)
            //{
            //    this._dataTable.Rows[0][ctColumnName_CustomerCdName] = BLANK + customerInfo.CustomerCode + " " + customerInfo.CustomerSnm;

            //    AppSettingsSection appSettingSection = GetAppSettingsSection();
            //    if (appSettingSection.Settings[CT_Conf_SaleSlipCreateView].Value.Equals("1"))
            //    {
            //        this.ShowPopup(this, new ReceivedEventArgs());
            //    }
            //}
            // DEL 2013/08/30 Redmine#40121 yugami -------------------------------------------------------<<<<<

        }

        /// <summary>
        /// �����񓚏����i���Ӑ�d�q�����j�Ăяo��
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        private void autoAnswerSlipList(string methodName, string enterpriseCode, string sectionCode, string sessionid, CustPrtPprWork custPrtPprWork, string pmTabSearchGuid, int notifyCount)
        {
            System.Threading.Monitor.Enter(autoAnswerSlipListLock);
            try
            {
                CustPrtSlipTabSearchAcs custPrtSlipTabSearchAcs = new CustPrtSlipTabSearchAcs();
                custPrtSlipTabSearchAcs.notifyTabletByPublish += new CustPrtSlipTabSearchAcs.NotifyTabletByPublishEventHandler(NotifyTabletByPublish);
                string message = string.Empty;

                // PMTAB �����񓚏���(���Ӑ�d�q����)
                int status = custPrtSlipTabSearchAcs.SearchPmToScm(enterpriseCode, sectionCode, custPrtPprWork, pmTabSearchGuid, notifyCount, out message);

                this.NotifyTabletByPublish(status, message, sessionid);
            }
            finally
            {
                System.Threading.Monitor.Exit(autoAnswerSlipListLock);
            }
        }
        // --- ADD 2013/08/23 �O�� �e�����񓯊��Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �w�舽���͊֘A��Tablet�[���ւ̕ԓ����M����
        /// </summary>
        /// <param name="destEnterpriseCode">��ƃR�[�h</param>
        /// <param name="destSectionCode">���_�R�[�h</param>
        /// <param name="inquiryNumber">�₢���킹�ԍ�</param>
        private void NotifyTabletByPublish(int status, string message,string sessionId)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "NotifyTabletByPublish";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            TabletPullData payload = new TabletPullData();
            payload.Status = status;
            payload.Message = message;
            // ADD 2013/08/26 Redmine#40121 ----------------------------------------------->>>>>
            payload.SessionId = sessionId;
            payload.NoticeMode = (int)ScmPushDataConstMode.PROCESSFINISHED;
            // ADD 2013/08/26 Redmine#40121 -----------------------------------------------<<<<<
            
            PublishArgs publishArgs = new PublishArgs();
            publishArgs.Payload = payload;
            // �w���Tablet�[���ւ̕ԓ����M����
            publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}/{3}", _tabletPushClient.WEBSYNC_CHANNEL_PMTAB, _enterpriseCode, _sectionCode.Trim(), sessionId);
            _tabletPushClient.Publish(publishArgs);
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName,
                "�ʒm���e Status�F" + payload.Status.ToString()
                + "  Message�F" + payload.Message
                + "  Channel�F" + publishArgs.Channel
                );
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        // ADD 2013/08/26 Redmine#40121 ----------------------------------------------->>>>>
        /// <summary>
        ///  �w�舽���͊֘A��Tablet�[���ւ̕ԓ����M�����i�ʒm���[�h�j
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="sessionId">�Z�b�V����ID</param>
        /// <param name="noticeMode">�ʒm���[�h</param>
        private void NotifyTabletByPublish(int status, string message, string sessionId, int noticeMode)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "NotifyTabletByPublish(NoticeMode)";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            TabletPullData payload = new TabletPullData();
            payload.Status = status;
            payload.Message = message;
            payload.SessionId = sessionId;
            payload.NoticeMode = noticeMode;

            PublishArgs publishArgs = new PublishArgs();
            publishArgs.Payload = payload;
            // �w���Tablet�[���ւ̕ԓ����M����
            publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}/{3}", _tabletPushClient.WEBSYNC_CHANNEL_PMTAB, _enterpriseCode, _sectionCode.Trim(), sessionId);
            _tabletPushClient.Publish(publishArgs);
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName,
                "�ʒm���e Status�F" + payload.Status.ToString()
                + "  Message�F" + payload.Message
                + "  NoticeMode�F" + payload.NoticeMode
                + "  Channel�F" + publishArgs.Channel
                );
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }
        // ADD 2013/08/26 Redmine#40121 -----------------------------------------------<<<<<

        /// <summary>
        /// �\����Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="visible">�\���t���O</param>
        private void SetVisibleState(bool visible)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "CheckInitialSettings";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            if (visible)
            {
                SetInitialPosition();
                Visible = true;
                TopMost = true;
                Activate();
                TopMost = false;
            }
            else
            {
                Visible = false;
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        /// <summary>
        /// �����N���ʒu��ݒ肵�܂��B
        /// </summary>
        private void SetInitialPosition()
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "SetInitialPosition";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenheigth = Screen.PrimaryScreen.WorkingArea.Height;
            int appWidth = Width;
            //-----ADD songg 2013/07/01 ��Q�� #37530�̑Ή� ---->>>>>
            // ��ʂ̍��x�ēx�ݒ�
            int count = 1;
            if((this._dataTable != null) && (this._dataTable.Rows.Count > 0))
            {
                if (this._dataTable.Rows.Count > 5)
                {
                    count = 5;
                }
                else
                {
                    count = this._dataTable.Rows.Count;
                }

                this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * (count - 1));
            }
            else
            {
                this.Height = ctDefaultFormHeight;
            }
            //-----ADD songg 2013/07/01 ��Q�� #37530�̑Ή� ----<<<<<
            int appHeight = Height;
            int appLeftXPos = screenWidth - appWidth;
            int appLeftYPos = screenheigth - appHeight;

            SetDesktopBounds(appLeftXPos, appLeftYPos, appWidth, appHeight);
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        /// <summary>
        /// �t�H�[����FormClosing�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void TabletPopupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "TabletPopupForm_FormClosing";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            if (!CanClose)
            {
                if (e.CloseReason.Equals(CloseReason.UserClosing))
                {
                    // �Ӑ}�I�ȏI���ȊO�̓L�����Z�����ăA�C�R�����i�t�H�[�����\���ɂ���j
                    e.Cancel = true; // �I�������̃L�����Z��
                    SetVisibleState(false);
                    return;
                }
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }
        #endregion // </�t�H�[��>

        #region <�|�b�v�A�b�v>

        /// <summary>
        /// ��M�X���b�h�p�|�b�v�A�b�v�\�������R�[���o�b�N
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private delegate void ShowPopupCallback(object sender, ReceivedEventArgs e);

        /// <summary>
        /// �|�b�v�A�b�v��\�����܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        void ShowPopup(
            object sender,
            ReceivedEventArgs e
        )
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "ShowPopup";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            if (InvokeRequired)
            {
                // ��M�X���b�h����̃C�x���g����
                Invoke(new ShowPopupCallback(ShowPopup), new object[] { sender, e });
            }
            else
            {
                SetVisibleState(true);

                this.Refresh();// ADD BY zhujw 2014/06/11 RedMine#42648 Windows8.1���쌟�،���_�풓�|�b�v�A�b�v�w�i���������\�������ꍇ������ �C��
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        #endregion // </�|�b�v�A�b�v>

        #region private���\�b�h
        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private CustomerInfo GetCustomerInfo(int customerCode)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetCustomerInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            CustomerInfo cust;

            int status = _customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, customerCode, out cust);

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            if (status == 0 && cust != null)
            {
                return cust;
            }
            else
            {
                return new CustomerInfo();
            }
        }

        /// <summary>
        /// ��� Paint�C�x���g�i�_�u���o�b�t�@�����O�ɂ��A��ʃT�C�Y�ύX���ɔ�������j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabletPopupForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //���Ăɔ����獕�ւ̃O���f�[�V�����̃u���V���쐬
            //g.VisibleClipBounds�͕\���N���b�s���O�̈�ɊO�ڂ���l�p�`
            LinearGradientBrush gb = new LinearGradientBrush(
                    panel_Info.Bounds,
                    Color.Black,
                    Color.Gray,
                    LinearGradientMode.Vertical);

            // �l�p��`��
            g.FillRectangle(gb, panel_Info.Bounds);
            gb.Dispose();
            g.Dispose();
        }

        /// <summary>
        /// ������@�o�C�g���w��؂蔲���iLeft [12345]678��12345�j
        /// </summary>
        /// <param name="orgString">���̕�����</param>
        /// <param name="byteCount">�o�C�g��</param>
        /// <returns>�w��o�C�g���Ő؂蔲����������</returns>
        private static string SubStringOfByteLeft(string orgString, int byteCount)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "SubStringOfByteLeft";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            Encoding _sjisEnc = Encoding.GetEncoding("Shift_JIS");
            string resultString = string.Empty;

            // ���炩���߁u�������v���w�肵�Đ؂蔲���Ă���
            // (���̒i�K��byte����<������>�`2*<������>�̊ԂɂȂ�)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // �u�������v�����炷
                resultString = orgString.Substring(0, i);

                // �o�C�g�����擾���Ĕ���
                count = _sjisEnc.GetByteCount(resultString);
                if (count <= byteCount) break;
            }

            int nowlength = _sjisEnc.GetByteCount(resultString);
            if (nowlength < byteCount)
            {
                for (int x = 0; x < byteCount - nowlength; x++)
                {
                    resultString += " ";
                }
            }

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return resultString;
        }

        /// <summary>
        /// [�ݒ�]���j���[�A�C�e����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void setToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "setToolStripMenuItem_Click";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            if (null == _form)
            {
                this._form = new PMTAB00100UC();
            }
            this._form.Owner = this;
            
            this._form.ShowDialog();

            AppSettingsSection appSettingSection = GetAppSettingsSection();

            int count = 0;
            if (this._dataTable.Rows.Count >= 5)
            {
                count = 5;
            }
            else
            {
                count = this._dataTable.Rows.Count;
            }

            if (appSettingSection.Settings[CT_Conf_SaleSlipCreateView].Value.Equals("1"))
            {
                this._visbleFlg = true;
                if (this._visbleFlg)
                {
                    //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count + 1);
                }
                this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count) + 50;
            }
            else
            {
                this._visbleFlg = false;
                //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count);
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        /// <summary>
        /// ConfigurationSection�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ConfigurationSection�擾�������s���܂��B</br>
        /// </remarks>
        private AppSettingsSection GetAppSettingsSection()
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetAppSettingsSection";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            ExeConfigurationFileMap file = new ExeConfigurationFileMap();

            file.ExeConfigFilename = Exe_Conf_Filename;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return (AppSettingsSection)config.GetSection(App_Set_Section);
        }

        /// <summary>
        /// [����]���j���[�A�C�e����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "closeToolStripMenuItem_Click";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            DialogResult dResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "��M�ҋ@�������I�����܂��B\r\n" +
                    "�I�����Ă���낵���ł����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dResult == DialogResult.No) return;

            CanClose = true;
            Close();
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        /// <summary>
        /// [�X�V]���j���[�A�C�e����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "updateToolStripMenuItem_Click";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            // �V�����v���Z�X�̋N��
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                string fileName = Path.Combine(Directory.GetCurrentDirectory(), CT_Conf_ExeFileName);
                process.StartInfo.FileName = fileName;
                process.StartInfo.Arguments = Program.argsSave[0] + " " + Program.argsSave[1] + " " + Program.RIGHTCLICK;
                process.Start();
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            // catch (Exception)
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

                MessageBox.Show(ex.Message);
            }
            CanClose = true;
            Close();
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }
        #endregion

        /// <summary>
        /// ���t�t�H�[�}�b�g����
        /// </summary>
        /// <param name="baseDate">yyyyMMdd�̓��t</param>
        /// <returns>yyyyMMdd�̎��Ԃ�߂�</returns>
        /// <remarks>
        /// <br>Note       : ���t�t�H�[�}�b�g����</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013/06/18</br> 
        /// </remarks>
        private DateTime GetDate(long baseDate)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetDate";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            if (baseDate == 0)
            {
                return DateTime.MinValue;

            }
            string datetime = Convert.ToString(baseDate);
            int year, month, day = 0;
            //�N�����ɕ���
            year = int.Parse(datetime.Substring(0, 4));
            month = int.Parse(datetime.Substring(4, 2));
            day = int.Parse(datetime.Substring(6, 2));

            DateTime date = new DateTime(year, month, day);

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return date;
        }

        // ADD 2013/08/30 Redmine#40121 yugami -------------------------------------------->>>>>
        /// <summary>
        ///  �ҋ@���ԃ��Z�b�g�ʒm����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void waitTimeReset_Tick(object sender, EventArgs e)
        {
            // sessionId�f�B�N�V���i���ɑ��݂��Ȃ����A�I��
            if (this._sessionIdDic == null || this._sessionIdDic.Count == 0) return;

            System.Threading.Monitor.Enter(sessionIdDicLock);
            try
            {
                foreach (string key in this._sessionIdDic.Keys)
                {
                    NotifyTabletByPublish(0, "", key, (int)ScmPushDataConstMode.WAITETIMERESET);
                }
            }
            finally
            {
                System.Threading.Monitor.Exit(sessionIdDicLock);
            }
        }
        // ADD 2013/08/30 Redmine#40121 yugami --------------------------------------------<<<<<

        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
        /// <summary>
        /// �荏�L���b�V���^�C�}�[�����ݒ�
        /// </summary>
        private void CachePunctualTimerSet()
        {
            const string methodName = "CachePunctualTimerSet";
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();

            file.ExeConfigFilename = Exe_Conf_Filename;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

            DateTime punctualWk = new DateTime();
            if (config.AppSettings.Settings["CachePunctual"] == null ||
                !DateTime.TryParse(config.AppSettings.Settings["CachePunctual"].Value, out punctualWk))
            {
                // �f�t�H���g AM9��
                punctualWk = punctualWk.AddHours(6);
            }

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �荏�L���b�V�������F" + punctualWk.ToString("HH:mm"));


            // 1�N1��1���{�荏
            punctual = new DateTime(1, 1, 1, punctualWk.Hour, punctualWk.Minute, punctualWk.Second, punctualWk.Millisecond);

            this.timer.Interval = GetPunctualInterval();
            // �^�C�}�[�X�^�[�g
            this.timer.Tick += new EventHandler(CachePunctual);
            this.timer.Start();
        }

        /// <summary>
        /// �荏�L���b�V���^�C�}�[�p �C���^�[�o���擾
        /// </summary>
        /// <returns></returns>
        private int GetPunctualInterval()
        {
            // 1�N1��1���{���ݎ���
            DateTime now = new DateTime(1, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);

            if (punctual <= now)
            {
                punctual = punctual.AddDays(1);
            }

            // ���̒荏�܂ł̍������擾���A�^�C�}�[�̃C���^�[�o���ɃZ�b�g
            System.TimeSpan dif = punctual - now;
            return (int)dif.TotalMilliseconds;
        }

        /// <summary>
        /// �荏�L���b�V���^�C�}�[����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CachePunctual(object sender, EventArgs e)
        {
            // ����ȍ~��24���Ԍ�
            timer.Interval = GetPunctualInterval();
            
            // �L���b�V������
            SearchInitial();
        }
        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<

    }

    /// <summary>
    /// 
    /// </summary>
    public class CustPrtParaWork 
    {
        /// <summary>�J�n������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _salesDateSt;

        /// <summary>�I��������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _salesDateEd;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
        private string _searchSectionCode;

        /// <summary>�����^�C�v</summary>
        /// <remarks>(�z��)�@�S�w��̏ꍇ��{""}</remarks>
        private string _salesDepoDiv;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>(�z��)�@�S�w��̏ꍇ��{""}</remarks>
        private string _acptAnOdrStatus;

        /// <summary>����`�[�敪</summary>
        /// <remarks>(�z��)�@�S�w��̏ꍇ��{""}</remarks>
        private string _salesSlipCd;
        // --------------- ADD START 2013/06/25 wangl2 FOR Redmin#37163 ------>>>>
        /// <summary>���Ӑ�R�[�h</summary>
        private string _customerCode;
        // --------------- ADD END 2013/06/25 wangl2 FOR Redmin#37163 ------<<<<

        /// public propaty name  :  SalesDateSt
        /// <summary>�J�n������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        // --------------- ADD START 2013/06/25 wangl2 FOR Redmin#37163 ------>>>>
        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }
        // --------------- ADD END 2013/06/25 wangl2 FOR Redmin#37163 ------<<<<

        /// public propaty name  :  SalesDateEd
        /// <summary>�I��������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  SearchSectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>(�z��)�@�S�Ўw���{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchSectionCode
        {
            get { return _searchSectionCode; }
            set { _searchSectionCode = value; }
        }

        /// public propaty name  :  SalesDepoDiv
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>(�z��)�@�S�w��̏ꍇ��{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDepoDiv
        {
            get { return _salesDepoDiv; }
            set { _salesDepoDiv = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>(�z��)�@�S�w��̏ꍇ��{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>�����^�C�v</summary>
        /// <value>(�z��)�@�S�w��̏ꍇ��{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�C�v</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

    }

    // --------------- ADD START 2013/07/10 wangl2 FOR Redmine#38118------>>>>
    /// <summary>
    /// �풓��񐧌�N���X
    /// </summary>
    /// <remarks>���̃N���C�A���g�ŏ풓��񐧌�N���X�ł��B</remarks>
    internal class ResidentController
    {
        private PosTerminalMg _posTerminalMg;

        private ArrayList _arrayList;

        private const string CLASS_NAME = "NewArrNtfyController";
        public PosTerminalMg PosTerminalMg
        {
            get { return _posTerminalMg; }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ResidentController()
        {
        }

        /// <summary>
        /// �ݒ�ǂݍ���(�S��)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        public void SearchSetting(string enterpriseCode, string sectionCode)
        {
            const string methodName = "SearchSetting";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            try
            {
                # region [���[���̒[���ԍ����擾]
                // ���[���̒[���ԍ����擾
                PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
                int status = posTerminalMgAcs.Search(out _posTerminalMg, enterpriseCode);
                # endregion

                # region [�S�̐ݒ�}�X�^(���_��)]
                // �S�̐ݒ�}�X�^(���_��)�̒[���ԍ����擾
                if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    PmTabTtlStSecAcs pmTabTtlStSecAcs = new PmTabTtlStSecAcs();
                    status = pmTabTtlStSecAcs.Search(out _arrayList,enterpriseCode,sectionCode);
                    if (status != (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = pmTabTtlStSecAcs.Search(out _arrayList, enterpriseCode, "00");
                    }

                }
                #endregion

            }
            catch
            {

            }

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        }

        /// <summary>
        /// �}�b�`���O���菈��
        /// </summary>
        // UPD 2013/08/01 �g�� Redmine#39489 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // public bool Match()
        public bool Match(string enterpriseCode, string sectionCode)
        // UPD 2013/08/01 �g�� Redmine#39489 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            const string methodName = "Match";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            // ADD 2013/08/01 �g�� Redmine#39489 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            _arrayList = null;
            SearchSetting(enterpriseCode, sectionCode);
            // ADD 2013/08/01 �g�� Redmine#39489 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // �[���Ǘ��ݒ�
            if (_posTerminalMg == null)
            {
                return false;
            }

            if (_arrayList == null)
            {
                return false;
            }

            foreach (PmTabTtlStSec pmTabTtlStSec in _arrayList)
            {
                if (pmTabTtlStSec.CashRegisterNo == _posTerminalMg.CashRegisterNo)
                {
                    return true;
                }
            }
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            return false;
        }
    }
    // --------------- ADD END 2013/07/10 wangl2 FOR Redmine#38118--------<<<<

}
