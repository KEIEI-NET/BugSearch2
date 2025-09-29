using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Reflection;// ADD ���N�n�� K2014/02/17

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����`�[����(Delphi)�����l�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����`�[����(Delphi)�̏����l�擾�f�[�^������s���܂��B</br>
    /// <br>Programmer : LDNS</br>
    /// <br>Date       : 2010/05/29</br>
    /// <br></br>
    /// <br>Update Note : 2010/05/30 20056 ���n ��� </br>
    /// <br>              ���ʕ�����(�U�����ǁ{�V�����ǁ{���R�����{SCM)</br>
    /// <br>Update Note : 2010/06/26 ����� </br>
    /// <br>              BL�R�[�h�ϊ������̃��W�b�N�̍폜</br>
    /// <br>Update Note: 2012/11/13 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��1668</br>
    /// <br>             ����ߋ����t������ʃI�v�V�������i�C�X�R�܂��̓I�v�V��������œ��t����j</br>
    /// <br>Update Note: 2012/12/19 �� �B</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             MAHNB01001U.Log�����݂���ꍇ���O���o�͂���悤�ɕύX</br>
    /// <br>Update Note: 2012/12/21 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             �R�`���i�I�v�V�����Ή�</br>
    /// <br>Update Note: K2013/09/20 �{�{ ����</br>
    /// <br>             ���t�^�o�I�v�V�����Ή��i�ʁj</br>
    /// <br>Update Note: K2014/01/22 杍^</br>
    /// <br>�Ǘ��ԍ�   : 10970602-00</br>
    /// <br>             �o�ˌʓ��̋敪�̕ύX�Ή�</br>
    /// <br>Update Note: K2014/02/17 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10970602-00</br>
    /// <br>             �t�r�a�o�ˌʃI�v�V�����n�m �`�m�c ���̊Ǘ��}�X�^�̌�</br>
    /// <br>             �A�Z���u����������ɑ��݂���ꍇ �˃I�v�V�����n�m�̑Ή�</br>
    /// <br>Update Note: K2015/04/01 ���t </br>
    /// <br>�Ǘ��ԍ�   : 11100713-00</br>
    /// <br>           : �X�암�i�ʈ˗��̉��Ǎ�ƑS���_�݌ɏ��ꗗ�@�\�ǉ�</br>
    /// <br>Update Note: K2015/04/29 �����M</br>
    /// <br>�Ǘ��ԍ�   : 11100543-00 �x�m�W�[���C������ UOE�捞�Ή�</br>
    /// <br>Update Note: K2015/06/18 �I��</br>
    /// <br>�Ǘ��ԍ�   : 11100543-00 �����C�S�@WebUOE�����񓚎捞�Ή�</br>
    /// <br>Update Note: K2016/11/01 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11202099-00 ����`�[���͂���O��PG���N�����Ĕ��P�����Z�o�̑Ή�</br>
    /// <br>             ���R�[�G�C�I�v�V�����i�ʁj</br>
    /// <br>Update Note: K2016/12/14  ���V��</br>
    /// <br>�Ǘ��ԍ�   : 11202330-00</br>
    /// <br>           : �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή�</br>
    /// <br>Update Note: K2016/12/26 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11270116-00 ����`�[���̓p�b�P�[�W�o�חp�\�[�X�̃}�[�W</br>
    /// <br>             �����c���i�I�v�V�����i�ʁj</br>
    /// <br>Update Note: K2016/12/30 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11202452-00</br>
    /// <br>             ���쏤�H�l�ʕύX���e��PM.NS�ɂĎ������邽�߁A��񔄉��̑Ή��s���܂��B</br>
    /// <br>Update Note: 2020/11/20 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSP�C�����C���@�\�ǉ��Ή�</br>
    /// <br>Update Note: 2021/08/23 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11601223-00</br>
    /// <br>           : PMKOBETSU-4178 �ŗ��̃��O�ǉ�</br> 
    /// <br>Update Note: 2021/10/09 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11601223-00</br>
    /// <br>           : PMKOBETSU-4192 �`�[���͌�̏������x�����̒���</br>
    /// <br>Update Note: 2022/01/05 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11800082-00</br>
    /// <br>           : PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ�</br> 
    /// </remarks>
    public class DelphiSalesSlipInputInitDataSecondAcs
    {
        # region ���R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private DelphiSalesSlipInputInitDataSecondAcs()
        {
        }

        /// <summary>
        /// ������͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        public static DelphiSalesSlipInputInitDataSecondAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataSecondAcs == null)
            {
                _delphiSalesSlipInputInitDataSecondAcs = new DelphiSalesSlipInputInitDataSecondAcs();
            }
            return _delphiSalesSlipInputInitDataSecondAcs;
        }
        # endregion

        #region ���v���C�x�[�g�ϐ�
        private static DelphiSalesSlipInputInitDataSecondAcs _delphiSalesSlipInputInitDataSecondAcs;

        private List<Employee> _employeeList = null;           // �]�ƈ��}�X�^���X�g
        private List<EmployeeDtl> _employeeDtlList = null;     // �]�ƈ��ڍ׃}�X�^���X�g
        private UOESetting _uoeSetting = null;                 // UOE���Ѓ}�X�^
        private PosTerminalMg _posTerminalMg = null;
        private TaxRateSet _taxRateSet = null;                 // �ŗ��ݒ�}�X�^
        private double _taxRate = 0;
        //private List<TbsPartsCdChgWork> _tbsPartsCdChgWorkList = null; // BL�R�[�h�ϊ��}�X�^���X�g // 2010/05/30 // 2010/06/26

        /// <summary> ���̓��[�h</summary>
        //private int _inputMode; // 2010/05/30
        /// <summary>�I�v�V�������</summary>
        private int _opt_CarMng;
        private int _opt_FreeSearch;
        private int _opt_PCC;
        private int _opt_RCLink;
        private int _opt_UOE;
        private int _opt_StockingPayment;
        private int _opt_SCM; // 2010/05/30
        private int _opt_QRMail; // 2010/05/30
        private int _opt_DateCtrl; // 2012/11/13 T.Miyamoto ADD
        private int _opt_NoBuTo; // ADD 杍^ K2014/01/22
        // ---ADD ���N�n�� K2014/02/17--------------->>>>>
        private MethodInfo _myMethodNobuto; // �Q�Ɨp���@�R�[��
        private object _objNobuto;          // �Q�Ɨpobject
        // ---ADD ���N�n�� K2014/02/17---------------<<<<<
        private int _opt_FuJi; // �x�m�W�[���C�������I�v�V�����i�ʁj// ADD K2015/04/29 �����M �x�m�W�[���C������
        private int _opt_MeiGo; // �����C�S�I�v�V�����i�ʁj// ADD K2015/06/18 �I�� �����C�S�@WebUOE�����񓚎捞
        private int _opt_Mizuno2ndSellPriceCtl;�@�@// ADD K2016/12/30 杍^ ���쏤�H��
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
        private int _opt_StockEntCtrl;  // ���d���������͐���I�v�V����    (OPT-CPM0050)
        private int _opt_StockDateCtrl; // �d�����t�t�H�[�J�X����I�v�V����(OPT-CPM0060)
        private int _opt_SalesCostCtrl; // �����C������I�v�V����          (OPT-CPM0070)
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        private int _opt_Cpm_FutabaSlipPrtCtl; // �t�^�o�`�[�������I�v�V�����i�ʁj�FOPT-CPM0090
        private int _opt_Cpm_FutabaWarehAlloc; // �t�^�o�q�Ɉ����ăI�v�V����  �i�ʁj�FOPT-CPM0100
        private int _opt_Cpm_FutabaUOECtl;     // �t�^�oUOE�I�v�V����         �i�ʁj�FOPT-CPM0110
        private int _opt_Cpm_FutabaOutSlipCtl; // �t�^�o�o�͍ϓ`�[����        �i�ʁj�FOPT-CPM0120

        private int _opt_BLPRefWarehouse;   // BLP�Q�Ƒq�ɒǉ��I�v�V�����FOPT-PM00230
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
        private int _opt_MoriKawa; // �X�암�i�I�v�V�����i�ʁj// ADD K2015/04/01 ���t �X�암�i�ʈ˗�
        private int _opt_YamagataCustom; // �R�`���i�� ����`�[����(���i�E�����ύX���b�N)(��) // ADD ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή�
        private int _opt_PermitForKoei; // ���R�[�G�C�I�v�V�����i�ʁj  // ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C

        private int _opt_FukudaCustom; // �����c���i�I�v�V�����i�ʁj  // ADD 杍^ K2016/12/26 �����c���i
        private int _opt_PM_EBooks;   // �d�q����A�g�I�v�V���� // ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�

        // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------>>>>
        private int _opt_TSP;
        // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------<<<<
        // --- ADD K2021/08/23 ���O PMKOBETSU-4178 �ŗ��̃��O�ǉ�--->>>>
        // ���O�o�͕��i
        OutLogCommon LogCommon;
        //private const string PGID_Log = "MAHNB01001U";//DEL 2021/10/09 �c���� PMKOBETSU-4192 �`�[���͌�̏������x�����̒���
        private const string CtRateLogSetting = "MAHNB01001URateLog";//ADD 2021/10/09 �c���� PMKOBETSU-4192 �`�[���͌�̏������x�����̒���
        private const string CtStGetTaxRateStatus = "��ʋN�� �ŗ��擾 status:{0}";
        private const string CtStGetTaxRateNull = "��ʋN�� �ŗ��擾Null";
        // --- ADD K2021/08/23 ���O PMKOBETSU-4178 �ŗ��̃��O�ǉ�---<<<<
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;//ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�
        // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� --->>>>>
        private SupplierAcs _supplierAcs;
        private List<Supplier> _supplierList = null;
        private const string LOGWRITESUPPLIER = "�d���惊�X�g���擾";
        // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� ---<<<<<
        #endregion

        #region ���񋓑�
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>����</summary>
            OFF = 0,
            /// <summary>�L��</summary>
            ON = 1,
        }
        #endregion

        #region ���p�u���b�N�ϐ�
        /// <summary>���[�J��DB�ǂݍ��ݔ���</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#else
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#endif
        /// <summary>���[�U�[�K�C�h�敪�R�[�h�i�ԕi���R�j</summary>
        public static readonly int ctDIVCODE_UserGuideDivCd_RetGoodsReason = 91;
        /// <summary>���[�U�[�K�C�h�敪�R�[�h�i�[�i�敪�j</summary>
        public static readonly int ctDIVCODE_UserGuideDivCd_DeliveredGoodsDiv = 48;
        /// <summary>���[�U�[�K�C�h�敪�R�[�h�i�̔��敪�j</summary>
        public static readonly int ctDIVCODE_UserGuideDivCd_SalesCode = 71;

        /// <summary>���l�K�C�h�敪�R�[�h�P</summary>
        public static readonly int ctDIVCODE_NoteGuideDivCd_1 = 101;//�`�[���l�P
        /// <summary>���l�K�C�h�敪�R�[�h�Q</summary>
        public static readonly int ctDIVCODE_NoteGuideDivCd_2 = 102;//�`�[���l�Q
        /// <summary>���l�K�C�h�敪�R�[�h�R</summary>
        public static readonly int ctDIVCODE_NoteGuideDivCd_3 = 106;//�`�[���l�Q

        /// <summary>���q���l�K�C�h�敪�R�[�h</summary>
        public static readonly int ctDIVCODE_CarNoteGuideDivCd = 201;//���q���l

        /// <summary>�i�ԕK�{���[�h</summary>
        public static readonly int ctINPUTMODE_NecessaryGoodsNo = 1;
        /// <summary>�i�ԔC�Ӄ��[�h</summary>
        //public static readonly int ctINPUTMODE_VoluntaryGoodsNo = 2;
        public static readonly int ctINPUTMODE_VoluntaryGoodsNo = 0;
        /// <summary>�[�������Ώۋ��z�敪�i������z�j</summary>
        public const int ctFracProcMoneyDiv_SalesMoney = 0;
        /// <summary>�[�������Ώۋ��z�敪�i����Łj</summary>
        public const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>�[�������Ώۋ��z�敪�i����P���j</summary>
        public const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        /// <summary>�[�������Ώۋ��z�敪�i�����P���j</summary>
        public const int ctFracProcMoneyDiv_SalesUnitCost = 2;
        /// <summary>�[�������Ώۋ��z�敪�i�������z�j</summary>
        public const int ctFracProcMoneyDiv_Cost = 0;

        /// <summary>���_�R�[�h(�S��)</summary>
        public const string ctSectionCode = "00";
        # endregion

        #region ���f���Q�[�g
        /// <summary>������z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
        public delegate void CacheSalesProcMoneyListEventHandler(List<SalesProcMoney> salesProcMoneyList);
        /// <summary>�d�����z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
        public delegate void CacheStockProcMoneyListEventHandler(List<StockProcMoney> stockProcMoneyList);
        /// <summary>�|���D��Ǘ��}�X�^�L���b�V���f���Q�[�g</summary>
        public delegate void CacheRateProtyMngListEventHandler(List<RateProtyMng> rateProtyMngList);

        #endregion

        # region ���p�u���b�N���\�b�h
        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2021/08/23 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br>           : PMKOBETSU-4178 �ŗ��̃��O�ǉ�</br> 
        /// <br>Update Note: 2021/10/09 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br>           : PMKOBETSU-4192 �`�[���͌�̏������x�����̒���</br>
        /// </remarks>
        public int ReadInitDataSecond(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            ArrayList aList2;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            #region ���ŗ��ݒ�}�X�^SFUKK09002A
            LogWrite("�Q����ł��擾");
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            TaxRateSetAcs.SearchMode taxRateSearchMode = (ctIsLocalDBRead == true) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
            status = taxRateSetAcs.Search(out aList, enterpriseCode, taxRateSearchMode);
            

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                this._taxRateSet = (TaxRateSet)aList[0];
                this._taxRate = this.GetTaxRate(DateTime.Today);
                // --- ADD K2021/08/23 ���O PMKOBETSU-4178 �ŗ��̃��O�ǉ�--->>>>
                if (_taxRateSet == null)
                {
                    // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�--->>>>>
                    this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();
                    if (_salesSlipInputInitDataAcs.ProcessControlSetting.RateLogOutFlg == (int)SalesSlipInputInitDataAcs.OutFlgType.Output)
                    {
                    // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�---<<<<<
                        try
                        {
                            // ���O�o��
                            if (LogCommon == null)
                            {
                                LogCommon = new OutLogCommon();
                            }
                            //LogCommon.OutputClientLog(PGID_Log, CtStGetTaxRateNull, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//DEL 2021/10/09 �c���� PMKOBETSU-4192 �`�[���͌�̏������x�����̒���
                            LogCommon.OutputClientLog(CtRateLogSetting, CtStGetTaxRateNull, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//ADD 2021/10/09 �c���� PMKOBETSU-4192 �`�[���͌�̏������x�����̒���
                        }
                        catch
                        {
                            // �������W�b�N�ɉe������
                        }
                    }//ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�
                }
                // --- ADD K2021/08/23 ���O PMKOBETSU-4178 �ŗ��̃��O�ǉ�---<<<<
            }
            // --- ADD K2021/08/23 ���O PMKOBETSU-4178 �ŗ��̃��O�ǉ�--->>>>
            else
            {
                // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�--->>>>>
                this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();
                if (_salesSlipInputInitDataAcs.ProcessControlSetting.RateLogOutFlg == (int)SalesSlipInputInitDataAcs.OutFlgType.Output)
                {
                // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�---<<<<<
                    try
                    {
                        //���b�Z�[�W
                        string logMsg = string.Format(CtStGetTaxRateStatus, status.ToString());

                        // ���O�o��
                        if (LogCommon == null)
                        {
                            LogCommon = new OutLogCommon();
                        }
                        //LogCommon.OutputClientLog(PGID_Log, logMsg, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//DEL 2021/10/09 �c���� PMKOBETSU-4192 �`�[���͌�̏������x�����̒���
                        LogCommon.OutputClientLog(CtRateLogSetting, logMsg, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//ADD 2021/10/09 �c���� PMKOBETSU-4192 �`�[���͌�̏������x�����̒���
                    }
                    catch
                    {
                        // �������W�b�N�ɉe������
                    }
                }//ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�
            }
            // --- ADD K2021/08/23 ���O PMKOBETSU-4178 �ŗ��̃��O�ǉ�---<<<<
            #endregion

            #region ���t�n�d���Ѓ}�X�^PMUOE09042A
            LogWrite("�QUOE���Ѓ}�X�^���擾");
            UOESettingAcs uoeSettingAcs = new UOESettingAcs();
            uoeSettingAcs.Read(out this._uoeSetting, enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            #endregion

            #region ���[���Ǘ��}�X�^MAPOS09152A(�L���b�V���Ȃ�)
            LogWrite("�Q�[���Ǘ��}�X�^���擾�C���X�^���X�����@�J�n");
            PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
            LogWrite("�Q�[���Ǘ��}�X�^���擾���[���@�J�n");
            posTerminalMgAcs.Search(out this._posTerminalMg, enterpriseCode);
            LogWrite("�Q�[���Ǘ��}�X�^���擾�I��");
            #endregion

            #region ���S�]�ƈ��^�]�ƈ��ڍ׏����擾SFTOK09382A
            LogWrite("�Q�S�]�ƈ��^�]�ƈ��ڍ׏����擾");
            EmployeeAcs employeeAcs = new EmployeeAcs();
            employeeAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = employeeAcs.SearchOnlyEmployeeInfo(out aList, out aList2, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._employeeList = new List<Employee>((Employee[])aList.ToArray(typeof(Employee)));
                if (aList2 != null) this._employeeDtlList = new List<EmployeeDtl>((EmployeeDtl[])aList2.ToArray(typeof(EmployeeDtl)));
            }
            #endregion

            #region ���I�v�V�������
            this.CacheOptionInfo();
            #endregion

            //>>>2010/06/26
            //#region ��BL�R�[�h�ϊ��}�X�^
            //LogWrite("�R BL�R�[�h�ϊ��}�X�^���擾");
            //BLCodeChangeAcs blCodeChangeAcs = new BLCodeChangeAcs();
            //TbsPartsCdChgWork paraTbsPartsCdChgWork = new TbsPartsCdChgWork();
            //status = blCodeChangeAcs.Search(out this._tbsPartsCdChgWorkList, paraTbsPartsCdChgWork);
            //#endregion
            //<<<2010/06/26
            // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� --->>>>>
            #region ���d���惊�X�g
            LogWrite(LOGWRITESUPPLIER);
            _supplierAcs = new SupplierAcs();
            ArrayList supplierList;
            status = this._supplierAcs.SearchAll(out supplierList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (supplierList != null)
                {
                    _supplierList = new List<Supplier>((Supplier[])supplierList.ToArray(typeof(Supplier)));
                }
            }
            #endregion
            // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� ---<<<<<

            return 0;
        }

        #region ��DEBUG���O�o��
        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (SalesSlipInputInitDataAcs._Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    SalesSlipInputInitDataAcs._Log_Check = 1;
                }
                else
                {
                    SalesSlipInputInitDataAcs._Log_Check = 2;
                }

            }
   
            if (SalesSlipInputInitDataAcs._Log_Check == 1)
            {
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
            System.IO.FileStream _fs;										// �t�@�C���X�g���[��
            System.IO.StreamWriter _sw;										// �X�g���[��writer
            _fs = new FileStream("MAHNB01001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#endif
        }
        // --- UPD T.Nishi 2012/12/19 ----------<<<<<
    }

        #endregion

        #region ���I�v�V������񐧌䏈��
        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ���ԗ��Ǘ��I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_CarMng);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_CarMng = (int)Option.ON;
            }
            else
            {
                this._opt_CarMng = (int)Option.OFF;
            }
            #endregion

            #region �����R�����I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FreeSearch = (int)Option.ON;
            }
            else
            {
                this._opt_FreeSearch = (int)Option.OFF;
            }
            #endregion

            #region ���o�b�b�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCC);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_PCC = (int)Option.ON;
            }
            else
            {
                this._opt_PCC = (int)Option.OFF;
            }
            #endregion

            #region �����T�C�N���A���I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RCLink);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_RCLink = (int)Option.ON;
            }
            else
            {
                this._opt_RCLink = (int)Option.OFF;
            }
            #endregion

            #region ���t�n�d�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_UOE);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_UOE = (int)Option.ON;
            }
            else
            {
                this._opt_UOE = (int)Option.OFF;
            }
            #endregion

            #region ���d���x���Ǘ��I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_StockingPayment = (int)Option.ON;
            }
            else
            {
                this._opt_StockingPayment = (int)Option.OFF;
            }
            #endregion

            //>>>2010/05/30
            #region ��SCM�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_SCM = (int)Option.ON;
            }
            else
            {
                this._opt_SCM = (int)Option.OFF;
            }
            #endregion
            //<<<2010/05/30

            // --- ADD 2010/06/26 ---- >>>>>
            #region ��QR�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_QRMail);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_QRMail = (int)Option.ON;
            }
            else
            {
                this._opt_QRMail = (int)Option.OFF;
            }
            #endregion
            // --- ADD 2010/06/26 ---- <<<<<
            // --- ADD T.Miyamoto 2012/11/13 ---------->>>>>
            #region ��������t����I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SalesDateControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_DateCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_DateCtrl = (int)Option.OFF;
            }
            #endregion
            // --- ADD T.Miyamoto 2012/11/13 ----------<<<<<

            // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
            #region ���R�`���i�I�v�V����
            // ���d���������͐���I�v�V����(OPT-CPM0050)
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockEntControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_StockEntCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_StockEntCtrl = (int)Option.OFF;
            }
            // �d�����t�t�H�[�J�X����I�v�V����(OPT-CPM0060)
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockDateControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_StockDateCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_StockDateCtrl = (int)Option.OFF;
            }
            // �����C������I�v�V����(OPT-CPM0070)
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SalesCostControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_SalesCostCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_SalesCostCtrl = (int)Option.OFF;
            }
            #endregion
            // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
            #region �����t�^�o�I�v�V�����i�ʁj
            // �t�^�o�`�[�������I�v�V�����i�ʁj�FOPT-CPM0090
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaSlipPrtCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Cpm_FutabaSlipPrtCtl = (int)Option.ON;
            }
            else
            {
                this._opt_Cpm_FutabaSlipPrtCtl = (int)Option.OFF;
            }
            // �t�^�o�`�[�������I�v�V�����i�ʁj�FOPT-CPM0100
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaWarehAlloc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Cpm_FutabaWarehAlloc = (int)Option.ON;
            }
            else
            {
                this._opt_Cpm_FutabaWarehAlloc = (int)Option.OFF;
            }
            // �t�^�oUOE�I�v�V�����i�ʁj�FOPT-CPM0110
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Cpm_FutabaUOECtl = (int)Option.ON;
            }
            else
            {
                this._opt_Cpm_FutabaUOECtl = (int)Option.OFF;
            }
            // �t�^�o�o�͍ϓ`�[����I�v�V�����i�ʁj�FOPT-CPM0120
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaOutSlipCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Cpm_FutabaOutSlipCtl = (int)Option.ON;
            }
            else
            {
                this._opt_Cpm_FutabaOutSlipCtl = (int)Option.OFF;
            }
            #endregion

            #region ��BLP�Q�Ƒq�ɒǉ��I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_BLPRefWarehouse);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_BLPRefWarehouse = (int)Option.ON;
            }
            else
            {
                this._opt_BLPRefWarehouse = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

            // --- ADD 杍^ K2014/01/22 ---------->>>>>
            #region ���o�ˌʐ��p�̃L�[�ɃI�v�V�����i�ʁj
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_NobutoCustom);
   
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                // ---ADD ���N�n�� K2014/02/17--------------->>>>>
                // �C���X�^���X����
                this._objNobuto = this.LoadAssemblyNobuto("PMHNB09312AC", "Broadleaf.Application.Controller.NobutoSpecSalesAcs");
                this._myMethodNobuto = null;
                if (this._objNobuto != null)
                {
                    // ���\�b�h�擾
                    this._myMethodNobuto = this._objNobuto.GetType().GetMethod("ReadSpecSalesDetailUriAge", new Type[] { typeof(string), typeof(string), typeof(int) });
                }

                if (this._myMethodNobuto != null)
                {
                    this._opt_NoBuTo = (int)Option.ON;
                }
                else
                {
                    this._opt_NoBuTo = (int)Option.OFF;
                }
                // ---ADD ���N�n�� K2014/02/17---------------<<<<<
                //this._opt_NoBuTo = (int)Option.ON;// DEL ���N�n�� K2014/02/17
            }
            else
            {
                this._opt_NoBuTo = (int)Option.OFF;
            }
            #endregion
            // --- ADD 杍^ K2014/01/22 ----------<<<<<
            // --- ADD K2015/04/01 ���t �X�암�i�ʈ˗� ---------->>>>>
            #region ���X�암�i�I�v�V�����i�ʁj
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MorikawaCustom);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_MoriKawa = (int)Option.ON;
            }
            else
            {
                this._opt_MoriKawa = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2015/04/01 ���t �X�암�i�ʈ˗� ----------<<<<<

            // --- ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C --- >>>>>
            #region �����R�[�G�C�I�v�V�����i�ʁj
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_KoeiCallExtProgCtl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_PermitForKoei = (int)Option.ON;
            }
            else
            {
                this._opt_PermitForKoei = (int)Option.OFF;
            }
            #endregion

            // --- ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C --- <<<<<

            // --- ADD 杍^ K2016/12/26 �����c���i --- >>>>>
            #region �������c���i�I�v�V�����i�ʁj
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FukudaCustom);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FukudaCustom = (int)Option.ON;
            }
            else
            {
                this._opt_FukudaCustom = (int)Option.OFF;
            }
            #endregion
            // --- ADD 杍^ K2016/12/26 �����c���i --- <<<<<

            // --- ADD K2015/04/29 �����M �x�m�W�[���C������ ---------->>>>>
            #region ���x�m�W�[���C�������I�v�V�����i�ʁj
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FujiGYSubaruWebUoeCtl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuJi = (int)Option.ON;
            }
            else
            {
                this._opt_FuJi = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2015/04/29 �����M �x�m�W�[���C������ ----------<<<<<

           // --- ADD K2015/06/18 �I�� �����C�S�@WebUOE�����񓚎捞 ---------->>>>>
            #region �������C�S�I�v�V�����i�ʁj
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MeigoWebUOECtrl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_MeiGo = (int)Option.ON;
            }
            else
            {
                this._opt_MeiGo = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2015/06/18 �I�� �����C�S�@WebUOE�����񓚎捞 ----------<<<<<

            // --- ADD ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή� ---------->>>>>
            // �R�`���i�� ����`�[����(���i�E�����ύX���b�N)(��)
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_YamagataCustomControl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_YamagataCustom = (int)Option.ON;
            }
            else
            {
                this._opt_YamagataCustom = (int)Option.OFF;
            }
            // --- ADD ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή� ----------<<<<<

            // --- ADD K2016/12/30 杍^ ���쏤�H���@��񔄉� ---------->>>>>
            #region �����쏤�H���I�v�V�����i�ʁj
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_Mizuno2ndSellPriceCtl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Mizuno2ndSellPriceCtl = (int)Option.ON;
            }
            else
            {
                this._opt_Mizuno2ndSellPriceCtl = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2016/12/30 杍^ ���쏤�H���@��񔄉� ----------<<<<<

            // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------>>>>
            #region ��TSP�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_Tsp);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_TSP = (int)Option.ON;
            }
            else
            {
                this._opt_TSP = (int)Option.OFF;
            }
            #endregion
            // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------<<<<<
            // --- ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�--->>>>>
            #region ���d�q����A�g�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_EBooks);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_PM_EBooks = (int)Option.ON;
            }
            else
            {
                this._opt_PM_EBooks = (int)Option.OFF;
            }
            #endregion
            // --- ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<
        }
        #endregion

        // �ԗ��Ǘ��I�v�V����
        public int GetOptCarMng()
        {
            return this._opt_CarMng;
        }
        // ���R�����I�v�V����
        public int GetOptFreeSearch()
        {
            return this._opt_FreeSearch;
        }
        // �o�b�b�I�v�V����
        public int GetOptPCC()
        {
            return this._opt_PCC;
        }
        // ���T�C�N���A���I�v�V����
        public int GetOpt_RCLink()
        {
            return this._opt_RCLink;
        }
        // �t�n�d�I�v�V����
        public int GetOptUOE()
        {
            return this._opt_UOE;
        }
        // �d���x���Ǘ��I�v�V����
        public int GetOptStockingPayment()
        {
            return this._opt_StockingPayment;
        }

        //>>>2010/05/30
        // SCM�I�v�V����
        public int GetOptSCM()
        {
            return this._opt_SCM;
        }

        // QR�I�v�V����
        public int GetOptQRMail()
        {
            return this._opt_QRMail;
        }

        // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------>>>>
        // TSP�I�v�V����
        public int GetOptTSP()
        {
            return this._opt_TSP;
        }
        // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------<<<<
        // --- ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�--->>>>>
        // �d�q����A�g�I�v�V����
        public int GetOptEBooks()
        {
            return this._opt_PM_EBooks;
        }
        // --- ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<

        // --- ADD T.Miyamoto 2012/11/13 ---------->>>>>
        // ������t����I�v�V����
        public int GetOptDateCtrl()
        {
            return this._opt_DateCtrl;
        }
        // --- ADD T.Miyamoto 2012/11/13 ----------<<<<<

        // --- ADD 杍^ K2014/01/22 ---------->>>>>
        // �o�ˌʐ��p�̃L�[�ɃI�v�V�����i�ʁj
        public int GetOptNoBuTo()
        {
            return this._opt_NoBuTo;
        }
        // --- ADD 杍^ K2014/01/22 ----------<<<<<

        // ---ADD ���N�n�� K2014/02/17--------------->>>>>
        /// <summary>�Q�Ɨp���@�R�[��</summary>
        public MethodInfo MyMethodNobuto
        {
            get { return this._myMethodNobuto; }
        }

        /// <summary>�Q�Ɨpobject</summary>
        public object ObjNobuto
        {
            get { return this._objNobuto; }
        }
        // ---ADD ���N�n�� K2014/02/17---------------<<<<<

        // --- ADD K2015/04/29 �����M �x�m�W�[���C������ ---------->>>>>
        // �x�m�W�[���C�������I�v�V�����i�ʁj
        public int GetOptForFuJi()
        {
            return this._opt_FuJi;
        }
        // --- ADD K2015/04/29 �����M �x�m�W�[���C������ ----------<<<<<

        // --- ADD K2015/06/18 �I�� �����C�S�@WebUOE�����񓚎捞 ---------->>>>>
        // �����C�S�I�v�V�����i�ʁj
        public int GetOptForMeiGo()
        {
            return this._opt_MeiGo;
        }
        // --- ADD K2015/06/18 �I�� �����C�S�@WebUOE�����񓚎捞 ----------<<<<<

        // --- ADD K2016/12/30 杍^ ���쏤�H���@��񔄉� ---------->>>>>
        // ���쏤�H���I�v�V�����i�ʁj
        public int GetOptForMizuno2ndSellPriceCtl()
        {
            return this._opt_Mizuno2ndSellPriceCtl;
        }
        // --- ADD K2016/12/30 杍^ ���쏤�H���@��񔄉� ----------<<<<<

        // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
        // ���d���������͐���I�v�V����(OPT-CPM0050)
        public int GetOptStockEntCtrl()
        {
            return this._opt_StockEntCtrl;
        }
        // �d�����t�t�H�[�J�X����I�v�V����(OPT-CPM0060)
        public int GetOptStockDateCtrl()
        {
            return this._opt_StockDateCtrl;
        }
        // �����C������I�v�V����(OPT-CPM0070)
        public int GetOptSalesCostCtrl()
        {
            return this._opt_SalesCostCtrl;
        }
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        public int GetOptFutabaSlipPrtCtl()
        {
            return this._opt_Cpm_FutabaSlipPrtCtl;
        }
        public int GetOptFutabaWarehAlloc()
        {
            return this._opt_Cpm_FutabaWarehAlloc;
        }
        public int GetOptFutabaUOECtl()
        {
            return this._opt_Cpm_FutabaUOECtl;
        }
        public int GetOptFutabaOutSlipCtl()
        {
            return this._opt_Cpm_FutabaOutSlipCtl;
        }
        // BLP�Q�Ƒq�ɒǉ��I�v�V����
        public int GetOptBLPRefWarehouse()
        {
            return this._opt_BLPRefWarehouse;
        }
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
        // --- ADD K2015/04/01 ���t �X�암�i�ʈ˗� ---------->>>>>
        // �X�암�i�I�v�V�����i�ʁj
        public int GetOptMoriKawa()
        {
            return this._opt_MoriKawa;
        }
        // --- ADD K2015/04/01 ���t �X�암�i�ʈ˗� ----------<<<<<

        // --- ADD ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή� ---------->>>>>
        // �R�`���i�� ����`�[����(���i�E�����ύX���b�N)(��)
        public int GetOptYamagataCustom()
        {
            return this._opt_YamagataCustom;
        }
        // --- ADD ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή� ----------<<<<<

        // --- ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C --- >>>>>
        // ���R�[�G�C�I�v�V�����i�ʁj
        public int GetOptPermitForKoei()
        {
            return this._opt_PermitForKoei;
        }
        // --- ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C --- <<<<<

        // --- ADD 杍^ K2016/12/26 �����c���i --- >>>>>
        // �����c���i�I�v�V�����i�ʁj
        public int GetOptFukudaCustom()
        {
            return this._opt_FukudaCustom;
        }
        // --- ADD 杍^ K2016/12/26 �����c���i --- <<<<<

        // --- DEL 2010/06/26 ---------->>>>>
        ///// <summary>
        ///// BL�R�[�h�ϊ��}�X�^�擾����(��)
        ///// </summary>
        ///// <returns></returns>
        //public List<TbsPartsCdChgWork> GetTbsPartsCdChgWorkList()
        //{
        //    return this._tbsPartsCdChgWorkList;
        //}
        // --- DEL 2010/06/26 ----------<<<<<
        //<<<2010/05/30

        /// <summary>
        /// �ŗ��擾����
        /// </summary>
        /// <param name="addUpADate"></param>
        /// <returns></returns>
        public double GetTaxRate(DateTime addUpADate)
        {
            if (_taxRateSet == null)
            {
                this._taxRate = 0;
            }
            else
            {
                this._taxRate = 0;

                if ((addUpADate >= _taxRateSet.TaxRateStartDate) &&
                    (addUpADate <= _taxRateSet.TaxRateEndDate))
                {
                    this._taxRate = _taxRateSet.TaxRate;
                }
                else if ((addUpADate >= _taxRateSet.TaxRateStartDate2) &&
                         (addUpADate <= _taxRateSet.TaxRateEndDate2))
                {
                    this._taxRate = _taxRateSet.TaxRate2;
                }
                else if ((addUpADate >= _taxRateSet.TaxRateStartDate3) &&
                         (addUpADate <= _taxRateSet.TaxRateEndDate3))
                {
                    this._taxRate = _taxRateSet.TaxRate3;
                }
            }
            return this._taxRate;
        }

        //�ŗ��ݒ�}�X�^
        public TaxRateSet GetTaxRateSet()
        {
            return this._taxRateSet;
        }
        public double GetTaxRate()
        {
            return this._taxRate;
        }
        //�t�n�d���Ѓ}�X�^
        public UOESetting GetUoeSetting()
        {
            return this._uoeSetting;
        }
        //�[���Ǘ��}�X�^
        public PosTerminalMg GetPosTerminalMg()
        {
            return this._posTerminalMg;
        }
        //�S�]�ƈ��^�]�ƈ��ڍ׏��
        public List<Employee> GetEmployeeList()
        {
            return this._employeeList;
        }
        public List<EmployeeDtl> GetEmployeeDtlList()
        {
            return this._employeeDtlList;
        }
        # endregion


        // --- ADD ���N�n�� K2014/02/17 -------------------->>>>>
        #region �o�ˌʑΉ�
        /// <summary>
        /// �A�Z���u���C���X�^���X��
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : K2014/02/17</br>
        /// </remarks>
        private object LoadAssemblyNobuto(string asmname, string classname)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return obj;
        }
        #endregion
        // --- ADD ���N�n�� K2014/02/17 --------------------<<<<<

        // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� --->>>>>
        //�d����}�X�^
        public List<Supplier> GetSupplierList()
        {
            return this._supplierList;
        }
        // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� ---<<<<<

    }
}
