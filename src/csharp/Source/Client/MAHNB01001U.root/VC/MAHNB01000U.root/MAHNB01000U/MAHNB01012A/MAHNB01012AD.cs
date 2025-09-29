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
//using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Reflection;// ADD ���N�n�� K2014/02/17

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ������͗p�����l�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������͂̏����l�擾�f�[�^������s���܂��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 20056 ���n ���  �V�K�쐬</br>
    /// <br>2009.07.15 22018 ��� ���b MANTIS[0013801] �a�k�R�[�h�K�C�h�̏����\�����[�h��ݒ�\�ɕύX�B</br>
    /// <br>Update Note  : 2009/09/08 ���M</br>
    /// <br>               PM.NS-2-A�E���q�Ǘ�</br>
    /// <br>               ���q�Ǘ��@�\�̒ǉ�</br>
    /// <br>Update Note  : 2009/10/19 ���M</br>
    /// <br>               PM.NS-3-A�E�ێ�˗��A</br>
    /// <br>               �ێ�˗��A�@�\�̒ǉ�</br>
    /// <br>Update Note :  2009/11/13 �����</br>
    /// <br>               PM.NS-4-A�E�ێ�˗��B</br>
    /// <br>               TBO�����{�^������TBO�����̏C��</br>
    /// <br>Update Note :  2009/12/23 ���M</br>
    /// <br>               PM.NS-3-A�EPM.NS�ێ�˗��C</br>
    /// <br>               PM.NS�ێ�˗��C��ǉ�</br>
    /// <br>Update Note : 2010/02/26 ���n ��� </br>
    /// <br>              SCM�Ή�</br>
    /// <br>Update Note : 2010/03/01 ����� PM.NS�ێ�˗��T�����ǑΉ�</br>
    /// <br>              �P�����W���[���̊|���D��Ǘ��}�X�^�L���b�V���������g�p����悤�ɕύX</br>
    /// <br>Update Note : 2010/04/28 20056 ���n ���</br>
    /// <br>              �������x�A�b�v�Ή�</br>
    /// <br>Update Note : 2010/05/30 20056 ���n ��� </br>
    /// <br>              ���ʕ�����(�U�����ǁ{�V�����ǁ{���R�����{SCM)</br>
    /// <br>Update Note : 2010/06/02 杍^ PM.NS��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
    /// <br>Update Note : 2010/06/26 ����� </br>
    /// <br>              BL�R�[�h�ϊ������̃��W�b�N�̍폜</br>
    /// <br>Update Note : 2010/07/29 20056 ���n ��� </br>
    /// <br>              �\���敪�}�X�^������^�C�~���O�Ɏ擾�ł��Ȃ����̑Ή�(�����擾�}�X�^�ŏI���Ƀ��X�g��null�̏ꍇ�A�Ď擾����)</br>
    /// <br>Update Note : 2010/08/30 20056 ���n ��� </br>
    /// <br>              �ŗ��ݒ�͈̓`�F�b�N�ǉ�</br>
    /// <br>Update Note : 2011/09/27 20056 ���n ���</br>
    /// <br>              �݌ɐ��\���敪���Q�Ƃ��A���݌ɐ��̕\��������s��</br>
    /// <br>Update Note : 2012/06/14 20073 �� �B </br>
    /// <br>              �q�Ƀ}�X�^�G���[�C��</br>
    /// <br>Update Note : 2012/11/13 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 ��1668</br>
    /// <br>              ����ߋ����t������ʃI�v�V�������i�C�X�R�܂��̓I�v�V��������œ��t����j</br>
    /// <br>Update Note : 2012/12/19 �� �B</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00</br>
    /// <br>              MAHNB01001U.Log�����݂���ꍇ���O���o�͂���悤�ɕύX</br>
    /// <br>Update Note : 2012/12/21 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00</br>
    /// <br>              �R�`���i�I�v�V�����Ή�</br>
    /// <br>Update Note : 2013/02/13 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00</br>
    /// <br>              ������������SearchInitial���\�b�h���C���i���x���P�j</br>
    /// <br>Update Note: K2013/09/20 �{�{ ����</br>
    /// <br>             ���t�^�o�I�v�V�����Ή��i�ʁj</br>
    /// <br>Update Note : 2013/05/09 �� �B</br>
    /// <br>�Ǘ��ԍ�    : 10902175-00 �d�|�ꗗ��935(#30784) </br>
    /// <br>              ����S�̐ݒ�̂a�k�R�[�h�}�ԋ敪���u�}�Ԃ���v�Őݒ肷�鎞�A��ʋN�������A�a�k�R�[�h�����ł��Ȃ�</br>
    /// <br>Update Note : 2013/09/13 ����</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00</br>
    /// <br>              SCM�d�|�ꗗ��10571�Ή��@�Q�Ƒq�ɒǉ�</br>
    /// <br>Update Note : K2014/01/22 杍^</br>
    /// <br>�Ǘ��ԍ�    : 10970602-00</br>
    /// <br>              �o�ˌʓ��̋敪�̕ύX�Ή�</br>
    /// <br>Update Note : K2014/02/17 ���N�n��</br>
    /// <br>�Ǘ��ԍ�    : 10970602-00</br>
    /// <br>              �t�r�a�o�ˌʃI�v�V�����n�m �`�m�c ���̊Ǘ��}�X�^�̌�</br>
    /// <br>              �A�Z���u����������ɑ��݂���ꍇ �˃I�v�V�����n�m�̑Ή�</br>
    /// <br>Update Note: 2014/08/11 duzg</br>
    /// <br>�Ǘ��ԍ�   : </br>
    /// <br>             ���؁^�����e�X�g��QNo.5</br>
    /// <br>Update Note: 2015/02/18  30744 ����</br>
    /// <br>�Ǘ��ԍ�   : 11070266-00</br>
    /// <br>           : SCM������Redmine#243�Ή�</br>
    /// <br>Update Note: 2015/03/18  31065 �L��</br>
    /// <br>�Ǘ��ԍ�   : 11070266-00</br>
    /// <br>           : SCM������ ���[�J�[��]�������i�Ή�</br>
    /// <br>Update Note: K2015/04/01 ���t </br>
    /// <br>�Ǘ��ԍ�   : 11100713-00</br>
    /// <br>           : �X�암�i�ʈ˗��̉��Ǎ�ƑS���_�݌ɏ��ꗗ�@�\�ǉ�</br>
    /// <br>Update Note: 2015/04/06 30757 ���X�� �M�p</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>             �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�</br>
    /// <br>Update Note: K2015/04/29 �����M</br>
    /// <br>�Ǘ��ԍ�   : 11100543-00 �x�m�W�[���C������ UOE�捞�Ή�</br>
    /// <br>Update Note: K2015/06/18 �I��</br>
    /// <br>�Ǘ��ԍ�   : 11101427-00 �����C�S�@WebUOE�����񓚎捞�Ή�</br>
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
    /// <br>Update Note: 2020/02/24 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11570208-00</br>
    /// <br>           : PMKOBETSU-2912����Őŗ��@�\�ǉ��Ή�</br>
    /// <br>Update Note: 2020/11/20 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSP�C�����C���@�\�ǉ��Ή�</br>
    /// <br>Update Note: 2021/03/16 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4133 ����`�[���͌���0�~��Q�̑Ή�</br>
    /// <br>Update Note: 2021/08/23 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11601223-00</br>
    /// <br>           : PMKOBETSU-4178 �ŗ��̃��O�ǉ�</br> 
    /// <br>Update Note: 2021/09/10 ������</br>
    /// <br>�Ǘ��ԍ�   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�</br> 
    /// <br>Update Note: 2021/10/09 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11601223-00</br>
    /// <br>           : PMKOBETSU-4192 �`�[���͌�̏������x�����̒���</br> 
    /// <br>Update Note: 2022/01/05 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11800082-00</br>
    /// <br>           : PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ�</br> 
    /// </remarks>
    public partial class SalesSlipInputInitDataAcs
    {
        # region ���R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private SalesSlipInputInitDataAcs()
        {
        }

        /// <summary>
        /// ������͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        public static SalesSlipInputInitDataAcs GetInstance()
        {
            if (_salesSlipInputInitDataAcs == null)
            {
                _salesSlipInputInitDataAcs = new SalesSlipInputInitDataAcs();
            }
            return _salesSlipInputInitDataAcs;
        }
        # endregion

        #region ���v���C�x�[�g�ϐ�
        private static SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private int _employeeCodeMaxLength = 4;
        // --- ADD 2009/12/23 ---------->>>>>
        /// <summary>�`�[���l����</summary>
        private Int32 _slipNoteCharCnt;

        /// <summary>�`�[���l�Q����</summary>
        private Int32 _slipNote2CharCnt;

        /// <summary>�`�[���l�R����</summary>
        private Int32 _slipNote3CharCnt;
        // --- ADD 2009/12/23 ----------<<<<<
        private UserGuideAcs _userGuideAcs;
        private GoodsAcs _goodsAcs;
        private List<SalesProcMoney> _salesProcMoneyList = null;
        private List<StockProcMoney> _stockProcMoneyList = null;
        private List<RateProtyMng> _rateProtyMngList = null; // ADD 2010/03/01

        private AllDefSet _allDefSet = null;                   // �S�̏����l�ݒ�}�X�^
        private StockTtlSt _stockTtlSt = null;                 // �d���݌ɑS�̐ݒ�}�X�^
        private AcptAnOdrTtlSt _acptAnOdrTtlSt = null;         // �󔭒��S�̊Ǘ��ݒ�}�X�^
        private SalesTtlSt _salesTtlSt = null;                 // ����S�̐ݒ�}�X�^
        private EstimateDefSet _estimateDefSet = null;         // ���Ϗ����l�ݒ�}�X�^
        private TaxRateSet _taxRateSet = null;                 // �ŗ��ݒ�}�X�^
        private List<SlipPrtSet> _slipPrtSetList = null;       // �`�[����ݒ�}�X�^���X�g
        private List<CustSlipMng> _custSlipMngList = null;     // ���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g
        private List<UOEGuideName> _uoeGuideNameList = null;   // �t�n�d�K�C�h���̃}�X�^���X�g
        private List<Warehouse> _warehouseList = null;         // �q�ɃR�[�h�}�X�^���X�g
        private List<SubSection> _subSectionList = null;       // ����}�X�^���X�g
        private List<Employee> _employeeList = null;           // �]�ƈ��}�X�^���X�g
        private List<EmployeeDtl> _employeeDtlList = null;     // �]�ƈ��ڍ׃}�X�^���X�g
        private List<MakerUMnt> _makerUMntList = null;         // ���[�J�[�}�X�^���X�g
        private List<BLGoodsCdUMnt> _blGoodsCdUMntList = null; // �a�k�R�[�h�}�X�^���X�g
        private List<UserGdBd> _userGdBdList = null;           // ���[�U�[�K�C�h�}�X�^���X�g
        private CompanyInf _companyInf = null;                 // ���Џ��
        private UOESetting _uoeSetting = null;                 // UOE���Ѓ}�X�^
        private PosTerminalMg _posTerminalMg = null;
        // --- ADD 2009/10/19 ---------->>>>>
        private ArrayList _allCustRateGroupList = null;        // ���Ӑ�}�X�^�S�����X�g
        private List<PriceSelectSet> _displayDivList = null;              // �\���敪���X�g
        // --- ADD 2009/10/19 ----------<<<<<
        private List<NoteGuidBd> _noteGuidList = null;              // ���l�K�C�h�S�����X�g ADD 2009/12/23
        private double _taxRate = 0;
        // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------>>>>
        private double _taxRateInput = 0;
        private int _consTaxLayMethod = -1;
        private int _taxRateDiv = 0;
        private double _taxRateMst = 0;
        private bool _rentSyncSupSlipFlag = false;
        private bool _slipSrcTaxFlg = false;
        // �ݏo�����d���`�[Flg
        private bool _rentSyncSupFlg = false;
        // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------<<<<
        private IWin32Window _owner = null;
        //>>>2010/02/26
        private SCMTtlSt _scmTtlSt = null;                     // SCM�S�̐ݒ�}�X�^
        private List<SCMDeliDateSt> _scmDeliDateStList = null; // SCM�[���ݒ�}�X�^���X�g
        private List<TbsPartsCodeWork> _tbsPartsCodeList = null; // �񋟂a�k�R�[�h�}�X�^���X�g
        //private List<TbsPartsCdChgWork> _tbsPartsCdChgWorkList = null; // BL�R�[�h�ϊ��}�X�^���X�g // 2010/06/26
        //<<<2010/02/26
        private StockMngTtlSt _stockMngTtlSt = null; // �݌ɊǗ��S�̐ݒ� // 2011/09/27

        /// <summary> ���̓��[�h</summary>
        private int _inputMode;

        /// <summary>�I�v�V�������</summary>
        private int _opt_CarMng;
        private int _opt_FreeSearch;
        private int _opt_PCC;
        private int _opt_RCLink;
        private int _opt_UOE;
        private int _opt_StockingPayment;
        private int _opt_SCM; // 2010/02/26
        private int _opt_QRMail; // 2010/06/26
        private int _opt_DateCtrl; // 2012/11/13 T.Miyamoto ADD
        private int _opt_NoBuTo; // K2014/01/22 杍^ ADD
        // ---ADD ���N�n�� K2014/02/17--------------->>>>>
        private MethodInfo _myMethodNobuto; // �Q�Ɨp���@�R�[��
        private object _objNobuto;          // �Q�Ɨpobject
        // ---ADD ���N�n�� K2014/02/17---------------<<<<<
        private int _opt_FuJi;   // �x�m�W�[���C�������I�v�V�����i�ʁj// ADD K2015/04/29 �����M �x�m�W�[���C������
        private int _opt_MeiGo;   // �����C�S�I�v�V�����i�ʁj// ADD K2015/06/18 �I�� �����C�S WebUOE�����񓚎捞
        private int _opt_Mizuno2ndSellPriceCtl;  // ADD K2016/12/30 杍^ ���쏤�H��
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
        private int _opt_StockEntCtrl;  // ���d���������͐���I�v�V����    (OPT-CPM0050)
        private int _opt_StockDateCtrl; // �d�����t�t�H�[�J�X����I�v�V����(OPT-CPM0060)
        private int _opt_SalesCostCtrl; // �����C������I�v�V����          (OPT-CPM0070)
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
        private int _opt_BLPPriWarehouse; // BLP�Q�Ƒq�ɒǉ��I�v�V����     (OPT-PM00230)
        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        private int _opt_Cpm_FutabaSlipPrtCtl; // �t�^�o�`�[�������I�v�V�����i�ʁj�FOPT-CPM0090
        private int _opt_Cpm_FutabaWarehAlloc; // �t�^�o�q�Ɉ����ăI�v�V����  �i�ʁj�FOPT-CPM0100
        private int _opt_Cpm_FutabaUOECtl;     // �t�^�oUOE�I�v�V����         �i�ʁj�FOPT-CPM0110
        private int _opt_Cpm_FutabaOutSlipCtl; // �t�^�o�o�͍ϓ`�[����        �i�ʁj�FOPT-CPM0120

        private int _opt_BLPRefWarehouse;   // BLP�Q�Ƒq�ɒǉ��I�v�V�����FOPT-PM00230
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
        private int _opt_MoriKawa;   // �X�암�i�I�v�V�����i�ʁj// ADD K2015/04/01 ���t �X�암�i�ʈ˗�
        private int _opt_YamagataCustom;   // �R�`���i�� ����`�[����(���i�E�����ύX���b�N)(��)  //  ADD ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή�

        private int _opt_PermitForKoei;  // ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C

        private int _opt_FukudaCustom;  // ADD 杍^ K2016/12/26 �����c���i
        private int _opt_PM_EBooks;   // �d�q����A�g�I�v�V���� // ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�


        // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
        /// <summary>�������i�ݒ胊�X�g</summary>
        private List<IsolIslandPrcWork> _isolIslandList;
        // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<

        // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------>>>>
        private int _opt_TSP;
        // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------<<<<

        // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�--->>>>>
        // ����XML�t�@�C��
        private const string ProcessControlSettingFile = "MAHNB01000U_ProcessControlSetting.xml";
        // �o�͐���XML
        private ProcessControlSetting _processControlSetting;
        public ProcessControlSetting ProcessControlSetting
        {
            get
            {
                return this._processControlSetting;
            }
        }

        /// <summary>
        /// �o�̓t���O
        /// </summary>
        public enum OutFlgType : int
        {
            /// <summary>�o�͂��Ȃ�</summary>
            noOutput = 0,
            /// <summary>�o�͂���</summary>
            Output = 1,
        }
        // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�---<<<<<

        // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� --->>>>>
        private SupplierAcs _supplierAcs;
        private List<Supplier> _supplierList = null;
        private const string LOGWRITESUPPLIER = "�P �d���惊�X�g���擾";
        // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� ---<<<<<
        #endregion

        #region ���f���Q�[�g
        /// <summary>������z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
        public delegate void CacheSalesProcMoneyListEventHandler(List<SalesProcMoney> salesProcMoneyList);
        /// <summary>�d�����z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
        public delegate void CacheStockProcMoneyListEventHandler(List<StockProcMoney> stockProcMoneyList);
        // --- ADD 2010/03/01 ---------->>>>>
        /// <summary>�|���D��Ǘ��}�X�^�L���b�V���f���Q�[�g</summary>
        public delegate void CacheRateProtyMngListEventHandler(List<RateProtyMng> rateProtyMngList);
        // --- ADD 2010/03/01 ----------<<<<<
        #endregion

        #region ���C�x���g
        /// <summary>������z�����敪�ݒ�L���b�V���C�x���g</summary>
        public event CacheSalesProcMoneyListEventHandler CacheSalesProcMoneyList;
        /// <summary>�d�����z�����敪�ݒ�Z�b�g�C�x���g</summary>
        public event CacheStockProcMoneyListEventHandler CacheStockProcMoneyList;

        // --- ADD 2010/03/01 ---------->>>>>
        /// <summary>�|���D��Ǘ��}�X�^�Z�b�g�C�x���g</summary>
        public event CacheRateProtyMngListEventHandler CacheRateProtyMngList;
        // --- ADD 2010/03/01 ----------<<<<<
        #endregion

        #region ���p�u���b�N�ϐ�
        /// <summary>���[�J��DB�ǂݍ��ݔ���</summary>
        /// <br>Update Note: 2009/09/08 ���M ���q�Ǘ��@�\�Ή�</br>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#else
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#endif
        public static int _Log_Check = 0; // 2012/12/19 T.Nishi ADD

        /// <summary>���[�U�[�K�C�h�敪�R�[�h�i�ԕi���R�j</summary>
        public static readonly int ctDIVCODE_UserGuideDivCd_RetGoodsReason = 91;
        /// <summary>���[�U�[�K�C�h�敪�R�[�h�i�[�i�敪�j</summary>
        public static readonly int ctDIVCODE_UserGuideDivCd_DeliveredGoodsDiv = 48;
        /// <summary>���[�U�[�K�C�h�敪�R�[�h�i�̔��敪�j</summary>
        public static readonly int ctDIVCODE_UserGuideDivCd_SalesCode= 71;

        /// <summary>���l�K�C�h�敪�R�[�h�P</summary>
        public static readonly int ctDIVCODE_NoteGuideDivCd_1 = 101;//�`�[���l�P
        /// <summary>���l�K�C�h�敪�R�[�h�Q</summary>
        public static readonly int ctDIVCODE_NoteGuideDivCd_2 = 102;//�`�[���l�Q
        /// <summary>���l�K�C�h�敪�R�[�h�R</summary>
        public static readonly int ctDIVCODE_NoteGuideDivCd_3 = 106;//�`�[���l�Q

        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>���q���l�K�C�h�敪�R�[�h</summary>
        public static readonly int ctDIVCODE_CarNoteGuideDivCd = 201;//���q���l
        // --- ADD 2009/09/08 ----------<<<<<

        /// <summary>�i�ԕK�{���[�h</summary>
        public static readonly int ctINPUTMODE_NecessaryGoodsNo = 1;
        /// <summary>�i�ԔC�Ӄ��[�h</summary>
        // --- UPD 2009/10/19 ---------->>>>>
        //public static readonly int ctINPUTMODE_VoluntaryGoodsNo = 2;
        public static readonly int ctINPUTMODE_VoluntaryGoodsNo = 0;
        // --- UPD 2009/10/19 ----------<<<<<
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

        // ------ ADD 2021/03/16 ���O FOR PMKOBETSU-4133-------->>>>
        /// <summary>���O�p</summary>
        private const string PGID_Log = "MAHNB01001U";
        /// <summary>���\�b�h��</summary>
        private const string MethodNm = "SearchBLGoodsInfo";
        // ���O�o�͕��i
        OutLogCommon LogCommon;
        // ------ ADD 2021/03/16 ���O FOR PMKOBETSU-4133--------<<<<<
        // --- ADD K2021/08/23 ���O PMKOBETSU-4178 �ŗ��̃��O�ǉ�--->>>>
        private const string CtRateLogSetting = "MAHNB01001URateLog";//ADD 2021/10/09 �c���� PMKOBETSU-4192 �`�[���͌�̏������x�����̒���
        private const string CtRnGetTaxRateStatus = "�ŐV��� �ŗ��擾 status:{0}";
        private const string CtRnGetTaxRateNull = "�ŐV��� �ŗ��擾Null";
        // --- ADD K2021/08/23 ���O PMKOBETSU-4178 �ŗ��̃��O�ǉ�---<<<<
        # endregion

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

        #region ���v���p�e�B
        /// <summary>���̓��[�h</summary>
        public int InputMode
        {
            get { return this._inputMode; }
        }
        /// <summary>�ŗ�</summary>
        public double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }

        // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------>>>>
        /// <summary>�ŗ����͒l</summary>
        public double TaxRateInput
        {
            get { return _taxRateInput; }
            set { _taxRateInput = value; }
        }

        /// <summary>����œ]�ŕ���</summary>
        public int ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// <summary>����Őŗ��敪</summary>
        public int TaxRateDiv
        {
            get { return _taxRateDiv; }
            set { _taxRateDiv = value; }
        }

        /// <summary>�ŗ��}�X�^�l</summary>
        public double TaxRateMst
        {
            get { return _taxRateMst; }
            set { _taxRateMst = value; }
        }

        public bool RentSyncSupSlipFlag
        {
            set { this._rentSyncSupSlipFlag = value; }
            get { return this._rentSyncSupSlipFlag; }
        }

        public bool SlipSrcTaxFlg
        {
            set { this._slipSrcTaxFlg = value; }
            get { return this._slipSrcTaxFlg; }
        }

        /// <summary>�ݏo�����d���`�[Flg</summary>
        public bool RentSyncSupFlg
        {
            set { this._rentSyncSupFlg = value; }
            get { return this._rentSyncSupFlg; }
        }
        // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------<<<<

        /// <summary>�`�[����ݒ�}�X�^���X�g</summary>
        public List<SlipPrtSet> SlipPrtSetList
        {
            get { return this._slipPrtSetList; }
        }
        /// <summary>���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g</summary>
        public List<CustSlipMng> CustSlipMngList
        {
            get { return this._custSlipMngList; }
        }

        /// <summary>�]�ƈ��R�[�hMAX����</summary>
        public int EmployeeCodeMaxLength
        {
            get { return this._employeeCodeMaxLength; }
            set { this._employeeCodeMaxLength = value; }
        }

        // --- ADD 2009/12/23 ---------->>>>>
        /// public propaty name  :  SlipNoteCharCnt
        /// <summary>�`�[���l�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipNoteCharCnt
        {
            get { return _slipNoteCharCnt; }
            set { _slipNoteCharCnt = value; }
        }

        /// public propaty name  :  SlipNote2CharCnt
        /// <summary>�`�[���l�Q�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�Q�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipNote2CharCnt
        {
            get { return _slipNote2CharCnt; }
            set { _slipNote2CharCnt = value; }
        }

        /// public propaty name  :  SlipNote3CharCnt
        /// <summary>�`�[���l�R�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�R�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipNote3CharCnt
        {
            get { return _slipNote3CharCnt; }
            set { _slipNote3CharCnt = value; }
        }
        // --- ADD 2009/12/23 ----------<<<<<

        /// <summary>�I�[�i�[�t�H�[��</summary>
        public IWin32Window Owner
        {
            set { this._owner = value; }
            get { return this._owner; }
        }

        /// <summary>
        /// �ԗ��Ǘ��I�v�V����
        /// </summary>
        public int Opt_CarMng
        {
            get { return this._opt_CarMng; }
            set { this._opt_CarMng = value; }
        }

        /// <summary>
        /// ���R�����I�v�V����
        /// </summary>
        public int Opt_FreeSearch
        {
            get { return this._opt_FreeSearch; }
            set { this._opt_FreeSearch = value; }
        }
        /// <summary>
        /// �o�b�b�I�v�V����
        /// </summary>
        public int Opt_PCC
        {
            get { return this._opt_PCC; }
            set { this._opt_PCC = value; }
        }
        /// <summary>
        /// ���T�C�N���A���I�v�V����
        /// </summary>
        public int Opt_RCLink
        {
            get { return this._opt_RCLink; }
            set { this._opt_RCLink = value; }
        }
        /// <summary>
        /// �t�n�d�I�v�V����
        /// </summary>
        public int Opt_UOE
        {
            get { return this._opt_UOE; }
            set { this._opt_UOE = value; }
        }
        /// <summary>
        /// �d���x���Ǘ��I�v�V����
        /// </summary>
        public int Opt_StockingPayment
        {
            get { return this._opt_StockingPayment; }
            set { this._opt_StockingPayment = value; }
        }
        //>>>2010/02/26
        /// <summary>
        /// SCM�I�v�V����
        /// </summary>
        public int Opt_SCM
        {
            get { return this._opt_SCM; }
            set { this._opt_SCM = value; }
        }
        //<<<2010/02/26

        //>>>2010/06/26
        /// <summary>
        /// QRMail�I�v�V����
        /// </summary>
        public int Opt_QRMail
        {
            get { return this._opt_QRMail; }
            set { this._opt_QRMail = value; }
        }
        //<<<2010/06/26

        // --- ADD T.Miyamoto 2012/11/13 ---------->>>>>
        // ������t����I�v�V����
        public int Opt_DateCtrl
        {
            get { return this._opt_DateCtrl; }
            set { this._opt_DateCtrl = value; }
        }
        // --- ADD T.Miyamoto 2012/11/13 ----------<<<<<

        // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
        // ���d���������͐���I�v�V����(OPT-CPM0050)
        public int Opt_StockEntCtrl
        {
            get { return this._opt_StockEntCtrl; }
            set { this._opt_StockEntCtrl = value; }
        }
        // �d�����t�t�H�[�J�X����I�v�V����(OPT-CPM0060)
        public int Opt_StockDateCtrl
        {
            get { return this._opt_StockDateCtrl; }
            set { this._opt_StockDateCtrl = value; }
        }
        // �����C������I�v�V����(OPT-CPM0070)
        public int Opt_SalesCostCtrl
        {
            get { return this._opt_SalesCostCtrl; }
            set { this._opt_SalesCostCtrl = value; }
        }
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
        // BLP�Q�ƍ݌ɒǃI�v�V����(OPT-PM00230)
        public int Opt_BLPPriWarehouse
        {
            get { return this._opt_BLPPriWarehouse; }
            set { this._opt_BLPPriWarehouse = value; }
        }
        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<

        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        // �t�^�o�`�[�������I�v�V�����i�ʁj�FOPT-CPM0090
        public int Opt_Cpm_FutabaSlipPrtCtl
        {
            get { return this._opt_Cpm_FutabaSlipPrtCtl; }
            set { this._opt_Cpm_FutabaSlipPrtCtl = value; }
        }
        // �t�^�o�q�Ɉ����ăI�v�V�����i�ʁj�FOPT-CPM0100
        public int Opt_Cpm_FutabaWarehAlloc
        {
            get { return this._opt_Cpm_FutabaWarehAlloc; }
            set { this._opt_Cpm_FutabaWarehAlloc = value; }
        }
        // �t�^�oUOE�I�v�V�����i�ʁj�FOPT-CPM0110
        public int Opt_Cpm_FutabaUOECtl
        {
            get { return this._opt_Cpm_FutabaUOECtl; }
            set { this._opt_Cpm_FutabaUOECtl = value; }
        }
        // �t�^�o�o�͍ϓ`�[����I�v�V�����i�ʁj�FOPT-CPM0120
        public int Opt_Cpm_FutabaOutSlipCtl
        {
            get { return this._opt_Cpm_FutabaOutSlipCtl; }
            set { this._opt_Cpm_FutabaOutSlipCtl = value; }
        }

        // --- ADD 杍^ K2014/01/22 ---------->>>>>
        // �o�ˌʐ��p�̃L�[�ɃI�v�V�����i�ʁj�FOPT-CPM0120
        public int Opt_NoBuTo
        {
            get { return this._opt_NoBuTo; }
            set { this._opt_NoBuTo = value; }
        }
        // --- ADD 杍^ K2014/01/22 ----------<<<<<

        // ---ADD ���N�n�� K2014/02/17--------------->>>>>
        /// <summary>�Q�Ɨp���@�R�[��</summary>
        public MethodInfo MyMethodNobuto
        {
            get { return this._myMethodNobuto; }
            set { this._myMethodNobuto = value; }
        }

        /// <summary>�Q�Ɨpobject</summary>
        public object ObjNobuto
        {
            get { return this._objNobuto; }
            set { this._objNobuto = value; }
        }
        // ---ADD ���N�n�� K2014/02/17---------------<<<<<

        // --- ADD K2015/04/29 �����M �x�m�W�[���C������ ---------->>>>>
        /// <summary>
        /// �x�m�W�[���C�������I�v�V�����i�ʁj
        /// </summary>
        public int Opt_ForFuJi
        {
            get { return this._opt_FuJi; }
            set { this._opt_FuJi = value; }
        }
        // --- ADD K2015/04/29 �����M �x�m�W�[���C������ ----------<<<<<

       // --- ADD K2015/06/18 �I�� �����C�S WebUOE�����񓚎捞 ---------->>>>>
        /// <summary>
        /// �����C�S�I�v�V�����i�ʁj
        /// </summary>
        public int Opt_ForMeiGo
        {
            get { return this._opt_MeiGo; }
            set { this._opt_MeiGo = value; }
        }
        // --- ADD K2015/06/18 �I�� �����C�S WebUOE�����񓚎捞 ----------<<<<<

        // --- ADD K2016/12/30 杍^ ���쏤�H���@��񔄉� ---------->>>>>
        /// <summary>
        /// ���쏤�H���I�v�V�����i�ʁj
        /// </summary>
        public int Opt_Mizuno2ndSellPriceCtl
        {
            get { return this._opt_Mizuno2ndSellPriceCtl; }
            set { this._opt_Mizuno2ndSellPriceCtl = value; }
        }
        // --- ADD K2016/12/30 杍^ ���쏤�H���@��񔄉� ----------<<<<<

        /// <summary>
        /// BLP�Q�Ƒq�ɒǉ��I�v�V����
        /// </summary>
        public int Opt_BLPRefWarehouse
        {
            get { return this._opt_BLPRefWarehouse; }
            set { this._opt_BLPRefWarehouse = value; }
        }
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
        // --- ADD K2015/04/01 ���t �X�암�i�ʈ˗� ---------->>>>>
        /// <summary>
        /// �X�암�i�I�v�V�����i�ʁj
        /// </summary>
        public int Opt_MoriKawa
        {
            get { return this._opt_MoriKawa; }
            set { this._opt_MoriKawa = value; }
        }
        // --- ADD K2015/04/01 ���t �X�암�i�ʈ˗� ----------<<<<<

        // --- ADD ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή� ---------->>>>>
        /// <summary>
        /// �R�`���i�� ����`�[����(���i�E�����ύX���b�N)(��)
        /// </summary>
        public int Opt_YamagataCustom
        {
            get { return this._opt_YamagataCustom; }
            set { this._opt_YamagataCustom = value; }
        }
        // --- ADD ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή� ----------<<<<<

        // --- ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C --- >>>>>
        /// <summary>
        ///  ���R�[�G�C�I�v�V�����i�ʁj
        /// </summary>
        public int Opt_PermitForKoei
        {
            get { return this._opt_PermitForKoei; }
            set { this._opt_PermitForKoei = value; }
        }
        // --- ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C --- <<<<<


        // --- ADD 杍^ K2016/12/26 �����c���i --- >>>>>
        /// <summary>
        ///  �����c���i�I�v�V�����i�ʁj
        /// </summary>
        public int Opt_FukudaCustom
        {
            get { return this._opt_FukudaCustom; }
            set { this._opt_FukudaCustom = value; }
        }
        // --- ADD 杍^ K2016/12/26 �����c���i --- >>>>>

        // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------>>>>
        /// <summary>
        /// TSP�I�v�V����
        /// </summary>
        public int Opt_TSP
        {
            get { return this._opt_TSP; }
            set { this._opt_TSP = value; }
        }
        // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------<<<<
        // --- ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�--->>>>>
        /// <summary>
        /// �d�q����A�g�I�v�V����
        /// </summary>
        public int Opt_PM_EBooks
        {
            get { return this._opt_PM_EBooks; }
            set { this._opt_PM_EBooks = value; }
        }
        // --- ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<

        // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
        /// <summary>�������i�ݒ胊�X�g���擾�E�ݒ肵�܂��B</summary>
        public List<IsolIslandPrcWork> IsolIslandList
        {
            get 
            {
                if (this._isolIslandList == null || this._isolIslandList.Count == 0)
                {
                    if (this._goodsAcs != null)
                    {
                        this._isolIslandList = new List<IsolIslandPrcWork>();
                        if (this._goodsAcs.IsolIslandPrcWorkList != null && this._goodsAcs.IsolIslandPrcWorkList.Count != 0)
                        {
                            this._isolIslandList.AddRange(this._goodsAcs.IsolIslandPrcWorkList);
                        }
                    }
                }
                return _isolIslandList; 
            }
            set { _isolIslandList = value; }
        }
        // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<

        #endregion

        # region ���p�u���b�N���\�b�h
        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2009/10/19 ���M �ێ�˗��A�@�\�Ή�</br>
        /// <br>Update Note : 2010/03/01 ����� PM.NS�ێ�˗��T�����ǑΉ�</br>
        /// <br>             �P�����W���[���̊|���D��Ǘ��}�X�^�L���b�V���������g�p����悤�ɕύX</br>
        public int ReadInitData(string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList aList;

            #region �����i�A�N�Z�X�N���X��������(�L���b�V���Ȃ�)
            LogWrite("�P ���i�A�N�Z�X�N���X��������");
            string retMessage;
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.IsLocalDBRead = ctIsLocalDBRead;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.IsGetSupplier = true; // 2010/04/28
            this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);
            #endregion

            //>>>2010/02/26
            #region ���񋟂a�k�R�[�h���X�g
            this._tbsPartsCodeList = this._goodsAcs.OfrBLList;
            LogWrite("�����������񋟂a�k�R�[�h���X�g�����F" + this._tbsPartsCodeList.Count.ToString());
            #endregion
            //<<<2010/02/26

            #region �����[�J�[�}�X�^
            LogWrite("�P ���[�J�[���X�g���擾");
            List<MakerUMnt> makerList;
            status = this._goodsAcs.GetAllMaker(enterpriseCode, out makerList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (makerList != null) this._makerUMntList = makerList;
            }
            #endregion

            #region ���a�k�R�[�h���X�g
            LogWrite("�P BL�R�[�h���X�g���擾");
            List<BLGoodsCdUMnt> blGoodsList;
            status = this._goodsAcs.GetAllBLGoodsCd(enterpriseCode, out blGoodsList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (blGoodsList != null) this._blGoodsCdUMntList = blGoodsList;
            }
            #endregion

            #region ���[���Ǘ��}�X�^ MAPOS09152A(�L���b�V���Ȃ�)
            LogWrite("�P �[���Ǘ��}�X�^���擾");
            PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
            posTerminalMgAcs.Search(out this._posTerminalMg, enterpriseCode);
            #endregion

            #region ��������擾 DCKHN09012A(�L���b�V���Ȃ�)
            LogWrite("�P ������擾");
            SubSectionAcs subSectionAcs = new SubSectionAcs();
            status = subSectionAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._subSectionList = new List<SubSection>((SubSection[])aList.ToArray(typeof(SubSection)));
            }
            #endregion

            // --- ADD 2009/10/19 ---------->>>>>
            #region �����Ӑ�|����ٰ�߂̑S���擾 PMKHN09172A(�L���b�V���Ȃ�)
            LogWrite("���Ӑ�|����ٰ�߂��擾");
            CustRateGroupAcs custRateGroupAcs = new CustRateGroupAcs();
            status = custRateGroupAcs.Search(out aList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._allCustRateGroupList = aList;
            }
            else
            {
                this._allCustRateGroupList = new ArrayList();
            }
            #endregion

            #region ���\���敪�}�X�^ PMHNB09003A
            LogWrite("�\���敪�}�X�^���擾");
            PriceSelectSetAcs priceSelectSetAcs = new PriceSelectSetAcs();
            status = priceSelectSetAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._displayDivList = new List<PriceSelectSet>((PriceSelectSet[])aList.ToArray(typeof(PriceSelectSet))); ;
            }
            else
            {
                this._displayDivList = new List<PriceSelectSet>();
            }
            #endregion
            // --- ADD 2009/10/19 ----------<<<<<

            // --- ADD 2009/12/23 ---------->>>>>
            #region �����l�K�C�h�}�X�^�A�N�Z�X�N���X SFTOK09402A
            LogWrite("���l�K�C�h�S�����擾");
            NoteGuidAcs noteGuidAcs = new NoteGuidAcs();
            noteGuidAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = noteGuidAcs.SearchBody(out aList, enterpriseCode);
            this._noteGuidList = new List<NoteGuidBd>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._noteGuidList = new List<NoteGuidBd>((NoteGuidBd[])aList.ToArray(typeof(NoteGuidBd)));
            }
            #endregion

            // --- ADD 2009/12/23 ----------<<<<<

            // --- ADD 2010/03/01 ---------->>>>>
            #region ���|���D��Ǘ��}�X�^ DCKHN09102A
            LogWrite("�|���D��Ǘ��}�X�^���擾");
            RateProtyMngAcs rateProtyMngAcs = new RateProtyMngAcs();
            int retTotalCnt;
            bool nextDat;
            status = rateProtyMngAcs.Search(out aList, out retTotalCnt, out nextDat, enterpriseCode, string.Empty, out retMessage);
            this._rateProtyMngList = new List<RateProtyMng>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._rateProtyMngList = new List<RateProtyMng>((RateProtyMng[])aList.ToArray(typeof(RateProtyMng)));
            }
            this.CacheRateProtyMngListCall();
            #endregion
            // --- ADD 2010/03/01 ----------<<<<<

            return 0;
        }

        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2020/02/24 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912����Őŗ��@�\�ǉ��Ή�</br>
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
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ���q�ɏ��擾 MAKHN09332A
            LogWrite("�Q �q�ɏ����擾");
            WarehouseAcs warehouseAcs = new WarehouseAcs();
            warehouseAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = warehouseAcs.Search(out aList, enterpriseCode, sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._warehouseList = new List<Warehouse>((Warehouse[])aList.ToArray(typeof(Warehouse)));
            }
            #endregion

            #region ���󔭒��Ǘ��S�̐ݒ�}�X�^ DCKHN09232A
            LogWrite("�Q �󔭒��Ǘ��S�̐ݒ���擾");
            AcptAnOdrTtlStAcs acptAnOdrTtlStAcs = new AcptAnOdrTtlStAcs();  // �󔭒��S�̐ݒ�}�X�^
            acptAnOdrTtlStAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = acptAnOdrTtlStAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheAcptAnOdrTtlSt(aList, enterpriseCode, sectionCode);
            }
            #endregion

            #region ������S�̐ݒ�}�X�^ DCKHN09212A
            LogWrite("�Q ����S�̐ݒ���擾");
            SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();          // ����S�̐ݒ�}�X�^
            salesTtlStAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = salesTtlStAcs.SearchOnlySalesTtlInfo(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheSalesTtlSt(aList, enterpriseCode, sectionCode);
            }
            #endregion

            #region �����Ϗ����l�ݒ�}�X�^ DCMIT09012A
            LogWrite("�Q ���Ϗ����l�ݒ���擾");
            EstimateDefSetAcs estimateDefSetAcs = new EstimateDefSetAcs();  // ���Ϗ����l�ݒ�}�X�^
            status = estimateDefSetAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheEstimateDefSet(aList, enterpriseCode, sectionCode);
            }
            #endregion

            #region ���d���݌ɑS�̐ݒ�}�X�^ SFSIR09002A
            LogWrite("�Q �d���݌ɑS�̐ݒ���擾");
            StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();          // �d���݌ɑS�̐ݒ�}�X�^
            status = stockTtlStAcs.SearchOnlyStockTtlInfo(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheStockTtlSt(aList, enterpriseCode, sectionCode);
            }
            #endregion

            #region ���S�̏����l�ݒ�}�X�^ SFCMN09082A
            LogWrite("�Q �S�̏����l�ݒ���擾");
            AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
            AllDefSetAcs.SearchMode allDefSetSearchMode = (ctIsLocalDBRead == true) ? AllDefSetAcs.SearchMode.Local : AllDefSetAcs.SearchMode.Remote;
            status = allDefSetAcs.Search(out aList, enterpriseCode, allDefSetSearchMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, aList);
                if (this._allDefSet != null) this._inputMode = this._allDefSet.GoodsNoInpDiv;
            }
            #endregion

            #region �����Џ��ݒ�}�X�^ SFUKN09002A
            LogWrite("�Q ���Џ��ݒ���擾");
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            companyInfAcs.Read(out this._companyInf, enterpriseCode);
            #endregion

            #region ���ŗ��ݒ�}�X�^ SFUKK09002A
            LogWrite("�Q ����ł��擾");
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            TaxRateSetAcs.SearchMode taxRateSearchMode = (ctIsLocalDBRead == true) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
            status = taxRateSetAcs.Search(out aList, enterpriseCode, taxRateSearchMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._taxRateSet = (TaxRateSet)aList[0];
                // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------>>>>
                this._taxRateInput = 0;
                this._rentSyncSupFlg = false;
                this._rentSyncSupSlipFlag = false;
                // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------<<<<<
                this._taxRate = this.GetTaxRate(DateTime.Today);
                // --- ADD K2021/08/23 ���O PMKOBETSU-4178 �ŗ��̃��O�ǉ�--->>>>
                if (_taxRateSet == null)
                {
                    // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�--->>>>>
                    if (ProcessControlSetting.RateLogOutFlg == (int)OutFlgType.Output)
                    {
                    // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�---<<<<<
                        try
                        {
                            // ���O�o��
                            if (LogCommon == null)
                            {
                                LogCommon = new OutLogCommon();
                            }
                            //LogCommon.OutputClientLog(PGID_Log, CtRnGetTaxRateNull, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//DEL 2021/10/09 �c���� PMKOBETSU-4192 �`�[���͌�̏������x�����̒���
                            LogCommon.OutputClientLog(CtRateLogSetting, CtRnGetTaxRateNull, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//ADD 2021/10/09 �c���� PMKOBETSU-4192 �`�[���͌�̏������x�����̒���
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
                if (ProcessControlSetting.RateLogOutFlg == (int)OutFlgType.Output)
                {
                // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�---<<<<<
                    try
                    {
                        //���b�Z�[�W
                        string logMsg = string.Format(CtRnGetTaxRateStatus, status.ToString());

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

            #region ���`�[����ݒ�}�X�^ SFURI09022A
            LogWrite("�Q �`�[����ݒ�}�X�^���X�g���擾");
            SlipPrtSetAcs slipPrtSetAcs = new SlipPrtSetAcs();
            slipPrtSetAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = slipPrtSetAcs.SearchSlipPrtSet(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._slipPrtSetList = new List<SlipPrtSet>((SlipPrtSet[])aList.ToArray(typeof(SlipPrtSet)));
            }
            #endregion

            #region �����Ӑ�}�X�^�i�`�[�Ǘ��j SFURI09022A
            LogWrite("�Q ���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g���擾");
            int count = 0;
            CustSlipMngAcs custSlipMngAcs = new CustSlipMngAcs();
            custSlipMngAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = custSlipMngAcs.SearchOnlyCustSlipMng(out count, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._custSlipMngList = new List<CustSlipMng>((CustSlipMng[])custSlipMngAcs.CustSlipMngList.ToArray(typeof(CustSlipMng)));
            }
            #endregion

            #region ���I�v�V�������
            LogWrite("�Q �I�v�V���������擾");
            this.CacheOptionInfo();
            #endregion

            #region ���t�n�d�K�C�h���̃}�X�^ PMUOE09032A
            LogWrite("�Q UOE�K�C�h���̃}�X�^���X�g���擾");
            UOEGuideName uOEGuideName = new UOEGuideName();
            uOEGuideName.EnterpriseCode = enterpriseCode;
            uOEGuideName.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            UOEGuideNameAcs uOEGuideNameAcs = new UOEGuideNameAcs();
            status = uOEGuideNameAcs.Search(out aList, uOEGuideName);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._uoeGuideNameList = new List<UOEGuideName>((UOEGuideName[])aList.ToArray(typeof(UOEGuideName)));
            }
            #endregion

            #region ���t�n�d���Ѓ}�X�^ PMUOE09042A
            LogWrite("�Q UOE���Ѓ}�X�^���擾");
            UOESettingAcs uoeSettingAcs = new UOESettingAcs();
            uoeSettingAcs.Read(out this._uoeSetting, enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            #endregion

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

        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataThird(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            ArrayList aList2;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ���S�]�ƈ��^�]�ƈ��ڍ׏����擾 SFTOK09382A
            LogWrite("�R �S�]�ƈ��^�]�ƈ��ڍ׏����擾");
            EmployeeAcs employeeAcs = new EmployeeAcs();
            employeeAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = employeeAcs.SearchOnlyEmployeeInfo(out aList, out aList2, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._employeeList = new List<Employee>((Employee[])aList.ToArray(typeof(Employee)));
                if (aList2 != null) this._employeeDtlList = new List<EmployeeDtl>((EmployeeDtl[])aList2.ToArray(typeof(EmployeeDtl)));
            }
            #endregion

            #region �����[�U�[�K�C�h�}�X�^ SFCMN09062A
            LogWrite("�R ���[�U�[�K�C�h���擾");
            this._userGuideAcs = new UserGuideAcs();
            CacheUserGd(enterpriseCode, ctDIVCODE_UserGuideDivCd_RetGoodsReason);       // �ԕi���R
            CacheUserGd(enterpriseCode, ctDIVCODE_UserGuideDivCd_DeliveredGoodsDiv);    // �[�i�敪
            CacheUserGd(enterpriseCode, ctDIVCODE_UserGuideDivCd_SalesCode);            // �̔��敪
            #endregion

            #region ��������z�����敪�ݒ�}�X�^ DCHMB09112A
            LogWrite("�R ������z�����敪�ݒ���擾");
            SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
            salesProcMoneyAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = salesProcMoneyAcs.Search(out aList, enterpriseCode);
            this._salesProcMoneyList = new List<SalesProcMoney>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])aList.ToArray(typeof(SalesProcMoney)));
            }
            this.CacheSalesProcMoneyListCall();
            #endregion

            #region ���d�����z�����敪�ݒ�}�X�^ DCKON09102A
            LogWrite("�R �d�����z�����敪�ݒ���擾");
            StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
            status = stockProcMoneyAcs.Search(out aList, enterpriseCode);
            this._stockProcMoneyList = new List<StockProcMoney>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._stockProcMoneyList = new List<StockProcMoney>((StockProcMoney[])aList.ToArray(typeof(StockProcMoney)));
            }
            this.CacheStockProcMoneyListCall();
            #endregion

            //>>>2010/02/26
            #region ��SCM�S�̐ݒ�}�X�^ SFCMN09082A
            LogWrite("�R SCM�S�̐ݒ�}�X�^���擾");
            SCMTtlStAcs scmTtlStAcs = new SCMTtlStAcs();
            status = scmTtlStAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._scmTtlSt = this.GetScmTtlStFromList(sectionCode, aList);
            }
            #endregion

            #region ��SCM�[���ݒ�}�X�^
            LogWrite("�R SCM�[���ݒ�}�X�^���擾");
            SCMDeliDateStAcs scmDeliDateStAcs = new SCMDeliDateStAcs();
            status = scmDeliDateStAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._scmDeliDateStList = new List<SCMDeliDateSt>((SCMDeliDateSt[])aList.ToArray(typeof(SCMDeliDateSt)));
                // 2012/08/28 ADD T.Yoshioka 2012/10���z�M�\�� SCM��Q��10363 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                this._scmDeliDateStList.Sort(new SCMDeliDateStComparer());
                // 2012/08/28 ADD T.Yoshioka 2012/10���z�M�\�� SCM��Q��10363 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            #endregion

            //>>>2010/06/26
            //#region ��BL�R�[�h�ϊ��}�X�^
            //LogWrite("�R BL�R�[�h�ϊ��}�X�^���擾");
            //BLCodeChangeAcs blCodeChangeAcs = new BLCodeChangeAcs();
            //TbsPartsCdChgWork paraTbsPartsCdChgWork = new TbsPartsCdChgWork();
            //status = blCodeChangeAcs.Search(out this._tbsPartsCdChgWorkList, paraTbsPartsCdChgWork);
            //#endregion
            //<<<2010/06/26
            //<<<2010/02/26

            //>>>2011/09/27
            #region ���݌ɊǗ��S�̐ݒ�}�X�^
            LogWrite("�R �݌ɊǗ��S�̐ݒ���擾");
            StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
            status = stockMngTtlStAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheStockMngTtlSt(aList, enterpriseCode, sectionCode);
            }
            #endregion
            //<<<2011/09/27

            return 0;  
        }

        /// <summary>
        /// �����敪�}�X�^���X�g�ݒ菈��
        /// </summary>
        public void SettingProcMoney()
        {
            this._goodsAcs.SalesProcMoneyList = this._salesProcMoneyList;
            this._goodsAcs.SalesProcMoneyList = this._salesProcMoneyList;
        }
        # endregion

        # region ���]�ƈ��}�X�^���䏈��
        /// <summary>
        /// �]�ƈ����̎擾����
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ�����</returns>
        public string GetName_FromEmployee(string employeeCode)
        {
            Employee employee = this.GetEmployee(employeeCode);

            return (employee == null) ? string.Empty : employee.Name;
        }

        /// <summary>
        /// �]�ƈ����擾����
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ��}�X�^�I�u�W�F�N�g</returns>
        public Employee GetEmployee(string employeeCode)
        {
            Employee employee = this._employeeList.Find(
                delegate(Employee emp)
                {
                    return (emp.EmployeeCode.Trim() == employeeCode.Trim()) ? true : false;
                }
            );

            return (employee == null) ? null : employee;
        }

        /// <summary>
        /// �]�ƈ��������擾
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="belongSectionCode">�������_�R�[�h</param>
        /// <param name="belongSubSectionCode">��������R�[�h</param>
        public void GetBelongInfo_FromEmployee(string employeeCode, out string belongSectionCode, out int belongSubSectionCode)
        {
            belongSectionCode = string.Empty;
            belongSubSectionCode = 0;
            Employee employee = this.GetEmployee(employeeCode.PadLeft(_employeeCodeMaxLength, '0'));
            EmployeeDtl employeeDtl = this.GetEmployeeDtl(employeeCode.PadLeft(_employeeCodeMaxLength, '0'));
            if (employee != null) belongSectionCode = employee.BelongSectionCode;
            if (employeeDtl != null) belongSubSectionCode = employeeDtl.BelongSubSectionCode;
        }
        # endregion

        #region ���]�ƈ��ڍ׃}�X�^���䏈��
        /// <summary>
        /// �]�ƈ��ڍ׏��擾����
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public EmployeeDtl GetEmployeeDtl(string employeeCode)
        {
            EmployeeDtl employeeDtl = this._employeeDtlList.Find(
                delegate(EmployeeDtl empDtl)
                {
                    return (empDtl.EmployeeCode.Trim() == employeeCode.Trim()) ? true : false;
                }
            );
            return (employeeDtl == null) ? null : employeeDtl;
        }

        /// <summary>
        /// ��������A�����ێ擾����
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="subSectionCode">����R�[�h</param>
        public void GetSubSection_FromEmployeeDtl(string employeeCode, out int subSectionCode)
        {
            EmployeeDtl employeeDtl = this.GetEmployeeDtl(employeeCode);
            subSectionCode = (employeeDtl == null) ? 0 : employeeDtl.BelongSubSectionCode;
        }
        #endregion

        # region ���q�Ƀ}�X�^���䏈��
        /// <summary>
        /// �q�ɖ��̎擾����
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns>�q�ɖ���</returns>
        public string GetName_FromWarehouse(string warehouseCode)
        {
            Warehouse warehouse = this._warehouseList.Find(
                delegate(Warehouse whouse)
                {
                    return (whouse.WarehouseCode.Trim() == warehouseCode.Trim()) ? true : false;
                }
            );
            return (warehouse == null) ? string.Empty : warehouse.WarehouseName;
        }

        //>>>2010/02/26
        /// <summary>
        /// �q�ɏ��擾����
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns>�q�ɖ���</returns>
        public Warehouse GetInfo_FromWarehouse(string warehouseCode)
        {
            // --- UPD T.Nishi 2012/06/14 ---------->>>>>
            //Warehouse warehouse = this._warehouseList.Find(
            //    delegate(Warehouse whouse)
            //    {
            //        return (whouse.WarehouseCode.Trim() == warehouseCode.Trim()) ? true : false;
            //    }
            //);
            //return warehouse;
            Warehouse warehouse = null;

            if (this._warehouseList != null)
            {
                warehouse = this._warehouseList.Find(
                delegate(Warehouse whouse)
                {
                    return (whouse.WarehouseCode.Trim() == warehouseCode.Trim()) ? true : false;
                }
                );
            }
            return warehouse;
            // --- UPD T.Nishi 2012/06/14 ----------<<<<<
        }
        //<<<2010/02/26

        // ADD 2015/02/18 SCM������Redmine#243�Ή� ------------------------------------->>>>>
        /// <summary>
        ///  �q�ɏ��擾
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�q�ɏ��</returns>
        public Warehouse GetInfo_FromWarehouse(string warehouseCode, string enterpriseCode)
        {
            Warehouse warehouse = null;
            // �q�Ƀ��X�g�����݂��Ȃ����̓}�X�^���擾����
            if (this._warehouseList == null)
            {
                ArrayList aList;
                List<Warehouse> warehouseList = null;
                int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                WarehouseAcs warehouseAcs = new WarehouseAcs();
                status = warehouseAcs.Search(out aList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (aList != null) warehouseList = new List<Warehouse>((Warehouse[])aList.ToArray(typeof(Warehouse)));
                    this.SetWarehouseList(warehouseList);
                }
            }

            if (this._warehouseList != null)
            {
                warehouse = this._warehouseList.Find(
                delegate(Warehouse whouse)
                {
                    return (whouse.WarehouseCode.Trim() == warehouseCode.Trim()) ? true : false;
                }
                );
            }
            return warehouse;

        }
        // ADD 2015/02/18 SCM������Redmine#243�Ή� -------------------------------------<<<<<

        # endregion

        # region ������}�X�^���䏈��
        /// <summary>
        /// ���喼�̎擾����
        /// </summary>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <returns>���喼��</returns>
        public string GetName_FromSubSection(int subSectionCode)
        {
            SubSection subSection = null;
            if (this._subSectionList != null)
            {
                subSection = this._subSectionList.Find(
                    delegate(SubSection sSection)
                    {
                        return (sSection.SubSectionCode == subSectionCode) ? true : false;
                    }
                );
            }
            return (subSection == null) ? string.Empty : subSection.SubSectionName;
        }
        # endregion

        # region ���󔭒��Ǘ��S�̐ݒ�}�X�^���䏈��
        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="acptAnOdrTtlStList">�󔭒��Ǘ��S�̐ݒ�}�X�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        internal void CacheAcptAnOdrTtlSt(ArrayList acptAnOdrTtlStList, string enterpriseCode, string sectionCode)
        {
            if (acptAnOdrTtlStList != null)
            {
                List<AcptAnOdrTtlSt> list = new List<AcptAnOdrTtlSt>((AcptAnOdrTtlSt[])acptAnOdrTtlStList.ToArray(typeof(AcptAnOdrTtlSt)));

                this._acptAnOdrTtlSt = list.Find(
                    delegate(AcptAnOdrTtlSt acptttl)
                    {
                        if ((acptttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (acptttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._acptAnOdrTtlSt != null) return;

                this._acptAnOdrTtlSt = list.Find(
                    delegate(AcptAnOdrTtlSt acptttl)
                    {
                        if ((acptttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (acptttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );


                //// �w���ƃR�[�h�����_�R�[�h�ň�v
                //foreach (AcptAnOdrTtlSt acptAnOdrTtlSt in acptAnOdrTtlStList)
                //{
                //    if ((acptAnOdrTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                //        (acptAnOdrTtlSt.SectionCode.Trim() == sectionCode.Trim()))
                //    {
                //        this._acptAnOdrTtlSt = acptAnOdrTtlSt;
                //        return;
                //    }
                //}
                //// �w��R�[�h�ň�v���Ȃ��ꍇ�A�S�̐ݒ�L���b�V��
                //foreach (AcptAnOdrTtlSt acptAnOdrTtlSt in acptAnOdrTtlStList)
                //{
                //    if ((acptAnOdrTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                //        (acptAnOdrTtlSt.SectionCode.Trim() == ctSectionCode.Trim()))
                //    {
                //        this._acptAnOdrTtlSt = acptAnOdrTtlSt;
                //        return;
                //    }
                //}
            }
        }

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�}�X�^�I�u�W�F�N�g�擾����
        /// </summary>
        /// <returns></returns>
        public AcptAnOdrTtlSt GetAcptAnOdrTtlSt()
        {
            return this._acptAnOdrTtlSt;
        }
        # endregion

        # region ������S�̐ݒ�}�X�^���䏈��
        /// <summary>
        /// ����S�̐ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="salesTtlStList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheSalesTtlSt(ArrayList salesTtlStList, string enterpriseCode, string sectionCode)
        {
            if (salesTtlStList != null)
            {
                List<SalesTtlSt> list = new List<SalesTtlSt>((SalesTtlSt[])salesTtlStList.ToArray(typeof(SalesTtlSt)));

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if ((salesttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._salesTtlSt != null) return;

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if ((salesttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
        }

        /// <summary>
        /// ����S�̐ݒ�}�X�^�I�u�W�F�N�g�擾����
        /// </summary>
        /// <returns></returns>
        public SalesTtlSt GetSalesTtlSt()
        {
            return this._salesTtlSt;
        }
        # endregion

        # region �����Ϗ����l�ݒ�}�X�^���䏈��
        /// <summary>
        /// ���Ϗ����l�ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="estimateDefSetList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheEstimateDefSet(ArrayList estimateDefSetList, string enterpriseCode, string sectionCode)
        {
            if (estimateDefSetList != null)
            {
                List<EstimateDefSet> list = new List<EstimateDefSet>((EstimateDefSet[])estimateDefSetList.ToArray(typeof(EstimateDefSet)));

                this._estimateDefSet = list.Find(
                    delegate(EstimateDefSet estimatedef)
                    {
                        if ((estimatedef.SectionCode.Trim() == sectionCode.Trim()) &&
                            (estimatedef.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._estimateDefSet != null) return;

                this._estimateDefSet = list.Find(
                    delegate(EstimateDefSet estimatedef)
                    {
                        if ((estimatedef.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (estimatedef.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                //// �w���ƃR�[�h�����_�R�[�h�ň�v
                //foreach (EstimateDefSet estimateDefSet in estimateDefSetList)
                //{
                //    if ((estimateDefSet.EnterpriseCode.Trim() == enterpriseCode) &&
                //        (estimateDefSet.SectionCode.Trim() == sectionCode))
                //    {
                //        this._estimateDefSet = estimateDefSet;
                //        return;
                //    }
                //}
                //// �w��R�[�h�ň�v���Ȃ��ꍇ�A�S�̐ݒ�L���b�V��
                //foreach (EstimateDefSet estimateDefSet in estimateDefSetList)
                //{
                //    if ((estimateDefSet.EnterpriseCode.Trim() == enterpriseCode) &&
                //        (estimateDefSet.SectionCode.Trim() == ctSectionCode))
                //    {
                //        this._estimateDefSet = estimateDefSet;
                //        return;
                //    }
                //}
            }
        }

        /// <summary>
        /// ���Ϗ����l�ݒ�}�X�^�擾����
        /// </summary>
        /// <returns></returns>
        public EstimateDefSet GetEstimateDefSet()
        {
            return this._estimateDefSet;
        }
        # endregion

        # region ���d���݌ɑS�̐ݒ�}�X�^���䏈��
        /// <summary>
        /// �d���݌ɑS�̐ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="stockTtlStList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheStockTtlSt(ArrayList stockTtlStList, string enterpriseCode, string sectionCode)
        {
            if (stockTtlStList != null)
            {
                List<StockTtlSt> list = new List<StockTtlSt>((StockTtlSt[])stockTtlStList.ToArray(typeof(StockTtlSt)));

                this._stockTtlSt = list.Find(
                    delegate(StockTtlSt stockttl)
                    {
                        if ((stockttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (stockttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._stockTtlSt != null) return;

                this._stockTtlSt = list.Find(
                    delegate(StockTtlSt stockttl)
                    {
                        if ((stockttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (stockttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );


                //// �w���ƃR�[�h�����_�R�[�h�ň�v
                //foreach (StockTtlSt stockTtlSt in stockTtlStList)
                //{
                //    if ((stockTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                //        (stockTtlSt.SectionCode.Trim() == sectionCode.Trim()))
                //    {
                //        this._stockTtlSt = stockTtlSt;
                //        return;
                //    }
                //}
                //// �w��R�[�h�ň�v���Ȃ��ꍇ�A�S�̐ݒ�L���b�V��
                //foreach (StockTtlSt stockTtlSt in stockTtlStList)
                //{
                //    if ((stockTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                //        (stockTtlSt.SectionCode.Trim() == ctSectionCode.Trim()))
                //    {
                //        this._stockTtlSt = stockTtlSt;
                //        return;
                //    }
                //}
            }
        }

        /// <summary>
        /// �d���݌ɑS�̐ݒ�}�X�^�擾����
        /// </summary>
        /// <returns></returns>
        public StockTtlSt GetStockTtlSt()
        {
            return this._stockTtlSt;
        }
        # endregion

        # region ���S�̏����l�ݒ�}�X�^���䏈��
        /// <summary>
        /// �S�̏����l�ݒ�}�X�^�̃��X�g������A�w�肵�����_�Ŏg�p����ݒ���擾���܂��B(���_�R�[�h��������ΑS�Аݒ�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="allDefSetArrayList">�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
        /// <returns>�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            if (allDefSetArrayList == null) return null;

            List<AllDefSet> list = new List<AllDefSet>((AllDefSet[])allDefSetArrayList.ToArray(typeof(AllDefSet)));

            AllDefSet allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == sectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (allSecAllDefSet != null) return allSecAllDefSet;

            allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == ctSectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return allSecAllDefSet;




            //if (allDefSetArrayList == null) return null;

            //AllDefSet allSecAllDefSet = null;

            //foreach (AllDefSet allDefSet in allDefSetArrayList)
            //{
            //    if (allDefSet.SectionCode.Trim() == sectionCode.Trim())
            //    {
            //        return allDefSet;
            //    }
            //    else if (allDefSet.SectionCode.Trim() == ctSectionCode.Trim())
            //    {
            //        allSecAllDefSet = allDefSet;
            //    }
            //}

            //return allSecAllDefSet;
        }

        /// <summary>
        /// �S�̏����l�ݒ�}�X�^�擾����
        /// </summary>
        /// <returns></returns>
        public AllDefSet GetAllDefSet()
        {
            return this._allDefSet;
        }
        # endregion

        # region �����[�U�[�K�C�h�}�X�^�i�{�f�B�j���䏈��
        /// <summary>
        /// ���[�U�[�K�C�h�L���b�V������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�K�C�h�敪�R�[�h</param>
        private void CacheUserGd(string enterpriseCode, int userGuideDivCd)
        {
            ArrayList userGdBdList;
            List<UserGdBd> tmpList = new List<UserGdBd>();

            int status = this._userGuideAcs.SearchDivCodeBody(out userGdBdList, enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if ((this._userGdBdList != null) && (this._userGdBdList.Count != 0))
                {
                    this._userGdBdList.AddRange(new List<UserGdBd>((UserGdBd[])userGdBdList.ToArray(typeof(UserGdBd))));
                }
                else
                {
                    this._userGdBdList = new List<UserGdBd>((UserGdBd[])userGdBdList.ToArray(typeof(UserGdBd)));
                }
            }
        }

        // -------ADD 2010/06/02------->>>>>
        /// <summary>
        /// ���[�U�[�K�C�h���X�g�̃N���A����
        /// </summary>
        /// <returns></returns>
        public void ClearUserGd()
        {
            this._userGdBdList = new List<UserGdBd>();
        }
        // -------ADD 2010/06/02-------<<<<<

        /// <summary>
        /// �K�C�h���̎擾����
        /// </summary>
        /// <param name="userGuideDivCd">���[�U�[�K�C�h�敪</param>
        /// <param name="guideCode">�K�C�h�R�[�h</param>
        /// <returns>�K�C�h����</returns>
        public string GetName_FromUserGdBd(int userGuideDivCd, int guideCode)
        {
            UserGdBd userGuide = this._userGdBdList.Find(
                delegate(UserGdBd uGuide)
                {
                    if ((uGuide.UserGuideDivCd == userGuideDivCd) &&
                        (uGuide.GuideCode == guideCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (userGuide == null)
            {
                return string.Empty;
            }
            else
            {
                return userGuide.GuideName;
            }
        }

        /// <summary>
        /// ���[�U�[�K�C�h�R���{�G�f�B�^���X�g�ݒ菈��
        /// </summary>
        /// <param name="sender">�ΏۃR���{�G�f�B�^</param>
        /// <param name="userGuideDivCd">���[�U�[�K�C�h�敪</param>
        public void SetUserGdBdComboEditor(ref TComboEditor sender, int userGuideDivCd)
        {
            Infragistics.Win.ValueList valueList;
            this.SetUserGdBdComboEditor(out valueList, userGuideDivCd);

            if (valueList != null)
            {
                for (int i = 0; i < valueList.ValueListItems.Count; i++)
                {
                    Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                    vlltem.Tag = valueList.ValueListItems[i].Tag;
                    vlltem.DataValue = valueList.ValueListItems[i].DataValue;
                    vlltem.DisplayText = valueList.ValueListItems[i].DisplayText;                    
                    sender.Items.Add(vlltem);
                }

                if (valueList.ValueListItems.Count > 0)
                {
                    sender.MaxDropDownItems = valueList.ValueListItems.Count;
                }
            }
        }

        /// <summary>
        /// ���[�U�[�K�C�h�R���{�G�f�B�^���X�g�ݒ菈��
        /// </summary>
        /// <param name="sender">�ΏۃR���{�{�b�N�X�o�����[���X�g</param>
        /// <param name="userGuideDivCd">���[�U�[�K�C�h�敪</param>
        public void SetUserGdBdComboEditor(out Infragistics.Win.ValueList sender, int userGuideDivCd)
        {

            sender = new Infragistics.Win.ValueList();

            List<UserGdBd> userGuideList = this._userGdBdList.FindAll(
                delegate(UserGdBd uGuide)
                {
                    if (uGuide.UserGuideDivCd == userGuideDivCd)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            int i = 0;
            foreach (UserGdBd userGuide in userGuideList)
            {
                Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
                secInfoItem.Tag = i;
                secInfoItem.DataValue = userGuide.GuideCode;
                secInfoItem.DisplayText = userGuide.GuideName;
                sender.ValueListItems.Add(secInfoItem);
                i++;
            }
#if false
            sender = new Infragistics.Win.ValueList();

            DataRow[] rows = this._dataSet.UserGdBd.Select(string.Format("UserGuideDivCd = {0}", userGuideDivCd), "GuideCode ASC");
            int i = 0;
            foreach (SalesInputInitialDataSet.UserGdBdRow row in rows)
            {
                Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
                secInfoItem.Tag = i;
                secInfoItem.DataValue = row.GuideCode;
                secInfoItem.DisplayText = row.GuideName;
                sender.ValueListItems.Add(secInfoItem);
                i++;
            }
#endif
        }

        /// <summary>
        /// ���[�U�[�K�C�h �R�[�h�ŏ��l�擾����
        /// </summary>
        /// <param name="userGuideDivCd">���[�U�[�K�C�h�敪</param>
        /// <returns>�ŏ��R�[�h</returns>
        public int GetMinCode_FormUserCd(int userGuideDivCd)
        {
            if ((this._userGdBdList == null) || (this._userGdBdList.Count == 0)) return 0;

            List<UserGdBd> userGuideList = this._userGdBdList.FindAll(
                delegate(UserGdBd uGuide)
                {
                    if (uGuide.UserGuideDivCd == userGuideDivCd)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if ((userGuideList != null) && (userGuideList.Count != 0))
            {
                userGuideList.Sort(new UserGdBdComparer());
                return userGuideList[0].GuideCode;
            }
            else
            {
                return 0;
            }

#if false
            DataRow[] rows = this._dataSet.UserGdBd.Select(string.Format("UserGuideDivCd = {0}", userGuideDivCd), "GuideCode ASC");
            if ((rows == null) || (rows.Length == 0))
            {
                return 0;
            }
            else
            {
                SalesInputInitialDataSet.UserGdBdRow[] dataRows = (SalesInputInitialDataSet.UserGdBdRow[])rows;

                return dataRows[0].GuideCode;
            }
#endif
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^��r�N���X(�K�C�h�R�[�h(����))
        /// </summary>
        private class UserGdBdComparer : Comparer<UserGdBd>
        {
            public override int Compare(UserGdBd x, UserGdBd y)
            {
                int result = x.GuideCode.CompareTo(y.GuideCode);
                return result;
            }
        }

        # endregion

        # region �����[�J�[�}�X�^���䏈��
        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        public string GetName_FromMaker(int makerCode)
        {
            MakerUMnt makerUMnt = this._makerUMntList.Find(
                delegate(MakerUMnt maker)
                {
                    return (maker.GoodsMakerCd == makerCode) ? true : false;
                }
            );
            return (makerUMnt == null) ? string.Empty : makerUMnt.MakerName;
        }

        /// <summary>
        /// ���[�J�[���̎擾����(���p�J�i����)
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        public string GetKanaName_FromMaker(int makerCode)
        {
            MakerUMnt makerUMnt = this._makerUMntList.Find(
                delegate(MakerUMnt maker)
                {
                    return (maker.GoodsMakerCd == makerCode) ? true : false;
                }
            );
            return (makerUMnt == null) ? string.Empty : makerUMnt.MakerKanaName;
        }
        # endregion

        // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� --->>>>>
        # region ���d����}�X�^���䏈��
        /// <summary>
        /// �d���於�̎擾����
        /// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns>�d���於��</returns>
        public string GetName_FromSupplier(int supplierCode)
        {
            Supplier supplierInfo = this._supplierList.Find(
                delegate(Supplier supplier)
                {
                    return (supplier.SupplierCd == supplierCode) ? true : false;
                }
            );
            return (supplierInfo == null) ? string.Empty : supplierInfo.SupplierSnm;
        }
        #endregion
        // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� ---<<<<<

        // --- ADD 2009/12/23 ---------->>>>>
        # region ���w����l��񐧌䏈��
        /// <summary>
        /// ���l�K�C�h���̎擾����
        /// </summary>
        /// <param name="noteGuideDivCode">���l�K�C�h�敪</param>
        /// <param name="noteGuideCode">���l�K�C�h�R�[�h</param>
        /// <param name="noteGuideName">���l�K�C�h����</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h���̎擾�������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/12/23</br>
        /// </remarks>
        public int GetName_NoteGuidBd(int noteGuideDivCode, int noteGuideCode, out string noteGuideName)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            noteGuideName = string.Empty;

            NoteGuidBd noteGuidBd = this._noteGuidList.Find(
                delegate(NoteGuidBd noteGuid)
                {
                    return (noteGuid.NoteGuideDivCode == noteGuideDivCode && noteGuid.NoteGuideCode == noteGuideCode) ? true : false;
                }
            );

            if (noteGuidBd != null)
            {
                noteGuideName = noteGuidBd.NoteGuideName;
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        # endregion

        // --- ADD 2009/12/23 ----------<<<<<

        # region ��BL�R�[�h�}�X�^���䏈��
        /// <summary>
        /// BL�R�[�h���擾����
        /// </summary>
        /// <param name="blGoodsCode">BL���i�R�[�h</param>
        /// <returns></returns>
        public BLGoodsCdUMnt GetBLGoodsInfo_FromBLGoods(int blGoodsCode)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = this._blGoodsCdUMntList.Find(
                delegate(BLGoodsCdUMnt blGoods)
                {
                    return (blGoods.BLGoodsCode == blGoodsCode) ? true : false;
                }
            );
            return blGoodsCdUMnt;
        }

        /// <summary>
        /// BL�R�[�h�}�X�^���ݒ菈��
        /// </summary>
        /// <param name="bLGoodsCdUMntList"></param>
        public void SettingBLGoodsInfo(ref List<BLGoodsCdUMnt> bLGoodsCdUMntList)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = null;
            List<BLGoodsCdUMnt> retBLGoodsCdUMntList = new List<BLGoodsCdUMnt>();

            foreach (BLGoodsCdUMnt bLGoodsCdUMnt in bLGoodsCdUMntList)
            {
                blGoodsCdUMnt = this.GetBLGoodsInfo_FromBLGoods(bLGoodsCdUMnt.BLGoodsCode);
                if (blGoodsCdUMnt != null)
                {
                    bLGoodsCdUMnt.BLGoodsName = blGoodsCdUMnt.BLGoodsFullName;
                    bLGoodsCdUMnt.BLGoodsFullName = blGoodsCdUMnt.BLGoodsFullName;
                    bLGoodsCdUMnt.BLGoodsHalfName = blGoodsCdUMnt.BLGoodsHalfName;
                }
                retBLGoodsCdUMntList.Add(bLGoodsCdUMnt);
            }
        }
        # endregion

        //>>>2010/02/26
        #region ����BL�R�[�h�}�X�^���䏈��
        /// <summary>
        /// ��BL�R�[�h���擾����
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <param name="blGoodsDerivedNo"></param>
        /// <returns></returns>
        public TbsPartsCodeWork GetOfrBLGoodsInfo_FromTbsPartsCodeWork(int blGoodsCode, int blGoodsDerivedNo)
        {
            TbsPartsCodeWork tbsPartsCodeWork = this._tbsPartsCodeList.Find(
                delegate(TbsPartsCodeWork work)
                {
                    if ((work.TbsPartsCode == blGoodsCode) &&
                        (work.TbsPartsCdDerivedNo == blGoodsDerivedNo))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            return tbsPartsCodeWork;
        }

        /// <summary>
        /// ��BL�R�[�h���擾����
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <returns></returns>
        public List<TbsPartsCodeWork> GetOfrBLGoodsInfo_FromTbsPartsCodeWork(int blGoodsCode)
        {
            List<TbsPartsCodeWork> tbsPartsCodeWorkList = this._tbsPartsCodeList.FindAll(
                delegate(TbsPartsCodeWork work)
                {
                    if (work.TbsPartsCode == blGoodsCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            return tbsPartsCodeWorkList;
        }
        #endregion
        //<<<2010/02/26

        # region ���t�n�d�K�C�h���̃}�X�^�L���b�V�����䏈��
        /// <summary>
        /// �t�n�d�K�C�h���̎擾����
        /// </summary>
        /// <param name="uOEGuideCode">�t�n�d�K�C�h�敪</param>
        /// <param name="uOESupplierCd">�t�n�d������R�[�h</param>
        /// <param name="uOEGuideDivCd">�t�n�d�K�C�h�R�[�h</param>
        public UOEGuideName GetUOEGuideNameRow_FromUOEGuideName(int uOEGuideDivCd, int uOESupplierCd, string uOEGuideCode)
        {
            if (this._uoeGuideNameList == null) return null;
            UOEGuideName uoeGuideName = this._uoeGuideNameList.Find(
                delegate(UOEGuideName uoeName)
                {
                    if ((uoeName.UOEGuideCode.Trim() == uOEGuideCode.Trim()) &&
                        (uoeName.UOESupplierCd == uOESupplierCd) &&
                        (uoeName.UOEGuideDivCd == uOEGuideDivCd))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return uoeGuideName;
        }

        /// <summary>
        /// �t�n�d�K�C�h���̎擾����
        /// </summary>
        /// <param name="uOEGuideCode">�t�n�d�K�C�h�敪</param>
        /// <param name="uOESupplierCd">�t�n�d������R�[�h</param>
        /// <param name="uOEGuideDivCd">�t�n�d�K�C�h�R�[�h</param>
        public string GetName_FromUOEGuideName(int uOEGuideDivCd, int uOESupplierCd, string uOEGuideCode)
        {
            UOEGuideName uoeGuideName = this.GetUOEGuideNameRow_FromUOEGuideName(uOEGuideDivCd, uOESupplierCd, uOEGuideCode);
            return (uoeGuideName == null) ? string.Empty : uoeGuideName.UOEGuideNm;
        }
        # endregion

        # region ��������z�����敪�ݒ�}�X�^���䏈��
        /// <summary>
        /// ������z�����敪�ݒ�L���b�V���f���Q�[�g �R�[������
        /// </summary>
        public void CacheSalesProcMoneyListCall()
        {
            if (this.CacheSalesProcMoneyList != null) this.CacheSalesProcMoneyList(this._salesProcMoneyList);
        }
        # endregion

        # region ���d�����z�����敪�ݒ�}�X�^���䏈��
        /// <summary>
        /// �d�����z�����敪�ݒ�L���b�V���f���Q�[�g �R�[������
        /// </summary>
        public void CacheStockProcMoneyListCall()
        {
            if (this.CacheStockProcMoneyList != null) this.CacheStockProcMoneyList(this._stockProcMoneyList);
        }
        # endregion

        // --- ADD 2010/03/01 ---------->>>>>
        # region ���|���D��Ǘ��}�X�^���䏈��
        /// <summary>
        /// �|���D��Ǘ��}�X�^�L���b�V���f���Q�[�g �R�[������
        /// </summary>
        public void CacheRateProtyMngListCall()
        {
            if (this.CacheRateProtyMngList != null) this.CacheRateProtyMngList(this._rateProtyMngList);
        }
        # endregion
        // --- ADD 2010/03/01 ----------<<<<<

        #region �����Џ��ݒ�}�X�^����֘A
        /// <summary>
        /// ���Џ��ݒ�}�X�^�擾����
        /// </summary>
        /// <returns>���Џ��ݒ�}�X�^�I�u�W�F�N�g</returns>
        public CompanyInf GetCompanyInf()
        {
            return this._companyInf;
        }
        #endregion

        # region ���ŗ��ݒ�}�X�^���䏈��
        /// <summary>
        /// �]�ŕ����擾����(�ŗ��ݒ�}�X�^)
        /// </summary>
        /// <param name="taxRateCode"></param>
        /// <returns></returns>
        public Int32 GetConsTaxLayMethod(int taxRateCode)
        {
            return (_taxRateSet == null) ? 0 : _taxRateSet.ConsTaxLayMethod;
        }

        /// <summary>
        /// �ŗ��ݒ�}�X�^�擾����
        /// </summary>
        /// <returns></returns>
        public TaxRateSet GetTaxRateSet()
        {
            return this._taxRateSet;
        }

        /// <summary>
        /// �ŗ��擾����
        /// </summary>
        /// <param name="addUpADate"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2020/02/24 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912����Őŗ��@�\�ǉ��Ή�</br>
        /// </remarks>
        public double GetTaxRate(DateTime addUpADate)
        {
            if (_taxRateSet == null)
            {
                this._taxRate = 0;
                this._taxRateDiv = 0;// ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή�
            }
            else
            {
                this._taxRate = 0;
                //----- ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή�------->>>>>
                if (this.ConsTaxLayMethod != 0 || this._taxRateInput == 0)
                {
                //----- ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή�-------<<<<<
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
                    //----- ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή�------->>>>>
                    // �ŗ��}�X�^�̐ŗ��𗘗p
                    this._taxRateDiv = 0;
                    this._taxRateMst = this._taxRate;
                }
                else
                {
                    if(this._taxRateInput != 0 )
                    {
                        this._taxRate = this._taxRateInput;
                        // ����ŗ��ݒ�V�K��ʂ̐ŗ��𗘗p
                        this._taxRateDiv = 1;
                    }
                    if ((addUpADate >= _taxRateSet.TaxRateStartDate) &&
                        (addUpADate <= _taxRateSet.TaxRateEndDate))
                    {
                        this._taxRateMst = _taxRateSet.TaxRate;
                    }
                    else if ((addUpADate >= _taxRateSet.TaxRateStartDate2) &&
                        (addUpADate <= _taxRateSet.TaxRateEndDate2))
                    {
                        this._taxRateMst = _taxRateSet.TaxRate2;
                    }
                    else if ((addUpADate >= _taxRateSet.TaxRateStartDate3) &&
                             (addUpADate <= _taxRateSet.TaxRateEndDate3))
                    {
                        this._taxRateMst = _taxRateSet.TaxRate3;
                    }
                }
                //----- ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή�-------<<<<<
            }
            return this._taxRate;
        }

        //----- ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή�------->>>>>
        /// <summary>
        /// �ŗ��ݒ�}�X�^�̐ŗ��擾����
        /// </summary>
        /// <param name="addUpADate"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note: 2020/02/24 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912����Őŗ��@�\�ǉ��Ή�</br>
        /// </remarks>
        public double GetTaxRateMst(DateTime addUpADate)
        {
            if (_taxRateSet == null)
            {
                this._taxRateMst = 0;
            }
            else
            {
                if ((addUpADate >= _taxRateSet.TaxRateStartDate) &&
                        (addUpADate <= _taxRateSet.TaxRateEndDate))
                {
                    this._taxRateMst = _taxRateSet.TaxRate;
                }
                else if ((addUpADate >= _taxRateSet.TaxRateStartDate2) &&
                        (addUpADate <= _taxRateSet.TaxRateEndDate2))
                {
                    this._taxRateMst = _taxRateSet.TaxRate2;
                }
                else if ((addUpADate >= _taxRateSet.TaxRateStartDate3) &&
                         (addUpADate <= _taxRateSet.TaxRateEndDate3))
                {
                    this._taxRateMst = _taxRateSet.TaxRate3;
                }
            }
            return this._taxRateMst;
        }
        //----- ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή�-------<<<<<

        /// <summary>
        /// �ŗ��ݒ�}�X�^�ɐݒ肳��Ă������Ŗ��̂��擾���܂��B
        /// </summary>
        /// <returns>����ŕ\������</returns>
        public string GetTaxRateName()
        {
            string result = string.Empty;

            if (_taxRateSet == null) return result;

            return _taxRateSet.TaxRateName;
        }

        //>>>2010/08/30
        /// <summary>
        /// �ŗ��ݒ�͈͗L���`�F�b�N
        /// </summary>
        /// <param name="addUpADate"></param>
        /// <returns></returns>
        public bool ExistTaxRateRange(DateTime addUpADate)
        {
            bool ret = false;

            if (_taxRateSet == null)
            {
                ret = false;
            }
            else
            {
                if (((addUpADate >= _taxRateSet.TaxRateStartDate) &&
                     (addUpADate <= _taxRateSet.TaxRateEndDate)) ||
                    ((addUpADate >= _taxRateSet.TaxRateStartDate2) &&
                     (addUpADate <= _taxRateSet.TaxRateEndDate2)) ||
                    ((addUpADate >= _taxRateSet.TaxRateStartDate3) &&
                     (addUpADate <= _taxRateSet.TaxRateEndDate3)))
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            return ret;
        }
        //<<<2010/08/30

        //>>>2010/11/26
        /// <summary>
        /// �ŗ��ݒ�}�X�^�擾����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="dt"></param>
        public void GetTaxRateSet(string enterpriseCode, DateTime dt)
        {
            #region ���ŗ��ݒ�}�X�^ SFUKK09002A
            ArrayList aList;
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            TaxRateSetAcs.SearchMode taxRateSearchMode = (ctIsLocalDBRead == true) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
            int status = taxRateSetAcs.Search(out aList, enterpriseCode, taxRateSearchMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._taxRateSet = (TaxRateSet)aList[0];
                this._taxRate = this.GetTaxRate(dt);
            }
            #endregion
        }
        //<<<2010/11/26
        # endregion

        //>>>2010/02/26
        # region ��SCM�S�̐ݒ萧�䏈��
        /// <summary>
        /// SCM�S�̐ݒ�}�X�^�̃��X�g������A�w�肵�����_�Ŏg�p����ݒ���擾���܂��B(���_�R�[�h��������ΑS�Аݒ�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="allDefSetArrayList">�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
        /// <returns>�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
        private SCMTtlSt GetScmTtlStFromList(string sectionCode, ArrayList scmTtlStArrayList)
        {
            if (scmTtlStArrayList == null) return null;

            List<SCMTtlSt> list = new List<SCMTtlSt>((SCMTtlSt[])scmTtlStArrayList.ToArray(typeof(SCMTtlSt)));

            SCMTtlSt scmTtlSt = list.Find(
                delegate(SCMTtlSt scmTtl)
                {
                    if (scmTtl.SectionCode.Trim() == sectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (scmTtlSt != null) return scmTtlSt;

            scmTtlSt = list.Find(
                delegate(SCMTtlSt scmTtl)
                {
                    if (scmTtl.SectionCode.Trim() == ctSectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return scmTtlSt;
        }

        /// <summary>
        /// SCM�S�̐ݒ�}�X�^�擾����
        /// </summary>
        /// <returns></returns>
        public SCMTtlSt GetScmTtlSt()
        {
            return this._scmTtlSt;
        }
        # endregion

        #region ��SCM�[���ݒ�}�X�^
        /// <summary>
        /// SCM�[���ݒ�}�X�^�擾����
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public SCMDeliDateSt GetSCMDeliDateSt(string sectionCode, int customerCode)
        {
            SCMDeliDateSt ret = null;
            if (this._scmDeliDateStList == null) return null;

            ret = this._scmDeliDateStList.Find(
                delegate(SCMDeliDateSt work)
                {
                    if ((work.CustomerCode == customerCode) && (work.SectionCode.Trim() == string.Empty))
                    {
                        return true;
                    }
                    else if ((work.CustomerCode == 0) && (work.SectionCode.Trim() == string.Empty))
                    {
                        return true;
                    }
                    else if ((work.CustomerCode == 0) && (work.SectionCode.Trim() == sectionCode.Trim()))
                    {
                        return true;
                    }
                    else if ((work.CustomerCode == 0) && (work.SectionCode.Trim() == "00"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return ret;
        }

        // 2011/01/31 Add >>>
        /// <summary>
        /// �r�b�l�[���ݒ�}�X�^��r�N���X(���Ӑ�A���_(����))
        /// </summary>
        private class SCMDeliDateStComparer : Comparer<SCMDeliDateSt>
        {
            public override int Compare(SCMDeliDateSt x, SCMDeliDateSt y)
            {
                int result = y.CustomerCode.CompareTo(x.CustomerCode);
                if (result != 0) return result;

                result = y.SectionCode.Trim().CompareTo(x.SectionCode.Trim());
                if (result != 0) return result;

                return result;
            }
        }
        // 2011/01/31 Add <<<
        # endregion

        //>>>2010/06/26
        //#region ��BL�R�[�h�ϊ��}�X�^
        ///// <summary>
        ///// BL�R�[�h�ϊ��}�X�^�̃��X�g������A�w�肵�������ŏ��擾���܂��B
        ///// </summary>
        ///// <param name="blCode"></param>
        ///// <returns></returns>
        //public List<TbsPartsCdChgWork> GetBLPartsCdChgList(int blCode)
        //{
        //    List<TbsPartsCdChgWork> retList = null;

        //    if (this._tbsPartsCdChgWorkList == null) return null;

        //    retList = this._tbsPartsCdChgWorkList.FindAll(
        //        delegate(TbsPartsCdChgWork work)
        //        {
        //            if (work.TbsPartsCode == blCode)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    );
        //    return retList;
        //}
        //# endregion
        //<<<2010/06/26

        //<<<2010/02/26

        //>>>2011/09/27
        # region ���݌ɊǗ��S�̐ݒ�}�X�^
        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="salesTtlStList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheStockMngTtlSt(ArrayList stockMngTtlStList, string enterpriseCode, string sectionCode)
        {

            if (stockMngTtlStList != null)
            {
                List<StockMngTtlSt> list = new List<StockMngTtlSt>((StockMngTtlSt[])stockMngTtlStList.ToArray(typeof(StockMngTtlSt)));

                this._stockMngTtlSt = list.Find(
                    delegate(StockMngTtlSt stockmngttl)
                    {
                        if ((stockmngttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (stockmngttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
        }
        
        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^�I�u�W�F�N�g�擾����
        /// </summary>
        /// <returns></returns>
        public StockMngTtlSt GetStockMngTtlSt()
        {
            return this._stockMngTtlSt;
        }
        # endregion
        //<<<2011/09/27

        #region ���[���Ǘ��}�X�^
        /// <summary>
        /// �[���Ǘ��}�X�^���擾���܂��B
        /// </summary>
        /// <returns></returns>
        public PosTerminalMg GetPosTerminalMg()
        {
            return this._posTerminalMg;
        }
        #endregion

        #region ��UOE���Ѓ}�X�^
        /// <summary>
        /// UOE���Ѓ}�X�^���擾���܂��B
        /// </summary>
        /// <returns></returns>
        public UOESetting GetUOESetting()
        {
            if (this._uoeSetting == null) this._uoeSetting = new UOESetting();
            return this._uoeSetting;
        }
        #endregion

        // --- ADD 2009/10/19 ---------->>>>>
        #region �����Ӑ�|���O���[�v�R�[�h�}�X�^
        /// <summary>
        /// ���Ӑ�|���O���[�v�R�[�h�}�X�^�̑S���擾����
        /// </summary>
        /// <returns></returns>
        public ArrayList GetGetCustRateGrpAll()
        {
            return this._allCustRateGroupList;
        }
        #endregion

        #region ���\���敪�}�X�^
        /// <summary>
        /// �\���敪�}�X�^�̎擾����
        /// </summary>
        /// <returns></returns>
        public List<PriceSelectSet> GetDisplayDivList()
        {
            return this._displayDivList;
        }
        #endregion

        // --- ADD 2009/10/19 ----------<<<<<

        #region ��������z�����敪�ݒ�}�X�^ �f�[�^�擾�����֘A
        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        public void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // �����l
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // �P����0.01�~�P��
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // �P���ȊO��1�~�P��
                    break;
            }
            fractionProcCd = 1;     // �؎̂�

            //-----------------------------------------------------------------------------
            // �R�[�h�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            List<SalesProcMoney> salesProcMoneyList = this._salesProcMoneyList.FindAll(
                delegate(SalesProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // �\�[�g�i������z�i�����j�j
            //-----------------------------------------------------------------------------
            salesProcMoneyList.Sort(new SalesProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // ������z�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            SalesProcMoney salesProcMoney = salesProcMoneyList.Find(
                delegate(SalesProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // �߂�l�ݒ�
            //-----------------------------------------------------------------------------
            if (salesProcMoney != null)
            {
                fractionProcUnit = salesProcMoney.FractionProcUnit;
                fractionProcCd = salesProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// ������z�����敪�}�X�^��r�N���X(������z(����))
        /// </summary>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {
            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }
#if false
        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// 
        public void GetFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //�f�t�H���g
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // �P����0.01�~�P��
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // �P���ȊO��1�~�P��
                    break;
            }
            fractionProcCd = 1;     // �؎̂�

            // �[�������Ώۋ��z�敪�A�[�������R�[�h����v����f�[�^���~���Ɏ擾
            DataRow[] dr = this._dataSet.SalesProcMoney.Select(string.Format("{0} = {1} AND {2} = {3}", this._dataSet.SalesProcMoney.FracProcMoneyDivColumn.ColumnName,
                                                                                                        fracProcMoneyDiv,
                                                                                                        this._dataSet.SalesProcMoney.FractionProcCodeColumn, fractionProcCode,
                                                                                                        fractionProcCode),
                                                               string.Format("{0} DESC", this._dataSet.SalesProcMoney.UpperLimitPriceColumn.ColumnName));

            foreach (SalesInputInitialDataSet.SalesProcMoneyRow stockProcMoneyRow in dr)
            {
                if (stockProcMoneyRow.UpperLimitPrice < targetPrice)
                {
                    break;
                }
                fractionProcUnit = stockProcMoneyRow.FractionProcUnit;
                fractionProcCd = stockProcMoneyRow.FractionProcCd;
            }
        }
#endif
        #endregion

        #region ���d�����z�����敪�ݒ�}�X�^ �f�[�^�擾�����֘A
        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        public void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // �����l
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // �P����0.01�~�P��
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // �P���ȊO��1�~�P��
                    break;
            }
            fractionProcCd = 1;     // �؎̂�

            //-----------------------------------------------------------------------------
            // �R�[�h�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            List<StockProcMoney> stockProcMoneyList = this._stockProcMoneyList.FindAll(
                delegate(StockProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // �\�[�g�i������z�i�����j�j
            //-----------------------------------------------------------------------------
            stockProcMoneyList.Sort(new StockProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // ������z�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            StockProcMoney stockProcMoney = stockProcMoneyList.Find(
                delegate(StockProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // �߂�l�ݒ�
            //-----------------------------------------------------------------------------
            if (stockProcMoney != null)
            {
                fractionProcUnit = stockProcMoney.FractionProcUnit;
                fractionProcCd = stockProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// �d�����z�����敪�}�X�^��r�N���X(������z(����))
        /// </summary>
        private class StockProcMoneyComparer : Comparer<StockProcMoney>
        {
            public override int Compare(StockProcMoney x, StockProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }
#if false
        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// 
        public void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //�f�t�H���g
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // �P����0.01�~�P��
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // �P���ȊO��1�~�P��
                    break;
            }
            fractionProcCd = 1;     // �؎̂�

            // �[�������Ώۋ��z�敪�A�[�������R�[�h����v����f�[�^���~���Ɏ擾
            DataRow[] dr = this._dataSet.StockProcMoney.Select(string.Format("{0} = {1} AND {2} = {3}", this._dataSet.StockProcMoney.FracProcMoneyDivColumn.ColumnName,
                                                                                                        fracProcMoneyDiv,
                                                                                                        this._dataSet.StockProcMoney.FractionProcCodeColumn, fractionProcCode,
                                                                                                        fractionProcCode),
                                                               string.Format("{0} DESC", this._dataSet.StockProcMoney.UpperLimitPriceColumn.ColumnName));

            foreach (SalesInputInitialDataSet.StockProcMoneyRow stockProcMoneyRow in dr)
            {
                if (stockProcMoneyRow.UpperLimitPrice < targetPrice)
                {
                    break;
                }
                fractionProcUnit = stockProcMoneyRow.FractionProcUnit;
                fractionProcCd = stockProcMoneyRow.FractionProcCd;
            }
        }
#endif
        #endregion

        # region �����i�֘A����
        /// <summary>
        /// �w�肵�����i�R�[�h�����ɏ��i�����擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsCode">���i�R�[�h</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g�iout�j</param>
        /// <returns>STATUS</returns>
        public int GetGoodsUnitData(string enterpriseCode, string loginSectionCode, int makerCode, string goodsCode, out GoodsUnitData goodsUnitData)
        {
            return this._goodsAcs.Read(enterpriseCode, loginSectionCode, makerCode, goodsCode, 1, 1, ConstantManagement.LogicalMode.GetData0, out goodsUnitData);
        }

        /// <summary>
        /// �w��������Y�����i���f�[�^�I�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="targetDateTime">���i�J�n��</param>
        /// <param name="goodsPriceList">���i���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns>���i���f�[�^�I�u�W�F�N�g</returns>
        public GoodsPrice GetGoodsPrice(DateTime targetDateTime, List<GoodsPrice> goodsPriceList)
        {
            return this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDateTime, goodsPriceList);
        }

        /// <summary>
        /// �i�Ԍ���
        /// </summary>
        /// <param name="cndtn">���i�������o�����N���X</param>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNo(GoodsCndtn cndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            return this._goodsAcs.SearchPartsFromGoodsNo(cndtn, out partsInfoDataSet, out  goodsUnitDataList, out msg);
        }

        /// <summary>
        /// BL�R�[�h����
        /// </summary>
        /// <param name="cndtn">���i�������o�����N���X</param>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchPartsFromBLCode(GoodsCndtn cndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            return this._goodsAcs.SearchPartsFromBLCode(cndtn, out partsInfoDataSet, out  goodsUnitDataList, out msg);
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="mode">���[�h</param>
        /// <param name="cndtnList">���i���������I�u�W�F�N�g���X�g</param>
        /// <param name="partsInfoDataSetList">���i�����f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataListList">���i�A���f�[�^�I�u�W�F�N�g���X�g���X�g</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �����������������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/10/19</br>
        /// <br></br>
        /// <br>Update Note: 2015/04/06 30757 ���X�� �M�p</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br>             �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�</br>
        /// <br></br>
        /// </remarks>
        /// <returns>ConstantManagement.MethodResult</returns>
        public int SearchPartsForSrcParts(int mode, GoodsCndtn cndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            //---DEL 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ---------------->>>>>
            //GoodsAcs goodsAcs = new GoodsAcs();
            //---DEL 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ----------------<<<<<
            //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ---------------->>>>>

            // �����i�̕W�����i���擾����ہA�������i�𔽉f�������i���擾����ׁA
            // �f�t�H���g�R���X�g���N�^�ł͂Ȃ��A�p�����[�^�Ōv�㋒�_���w�肷��
            // �R���X�g���N�^��GoodsAcs�C���X�^���X�𐶐�����悤�C��
            GoodsAcs goodsAcs = new GoodsAcs(cndtn.SectionCode);
            //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ----------------<<<<<
            // --- UPD 2013/02/13 Y.Wakita ---------->>>>>
            //goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
            goodsAcs.SearchInitial();
            // --- UPD 2013/02/13 Y.Wakita ----------<<<<<
            return goodsAcs.SearchPartsForSrcParts(mode, cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
        }

        /// <summary>
        /// TBO����
        /// </summary>
        /// <param name="cndtn">���i�������o�����N���X</param>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.MethodResult</returns>
        /// <br>Update Note : 2009/11/13 �����</br>
        /// <br>              TBO�����{�^������TBO�������C��</br>
        public int SearchTBO(GoodsCndtn cndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            //return this._goodsAcs.SearchTBO(cndtn, out partsInfoDataSet, out  goodsUnitDataList, out msg); // DEL 2009/11/13
            return this._goodsAcs.SearchTBOForButton(cndtn, out partsInfoDataSet, out  goodsUnitDataList, out msg); // ADD 2009/11/13
        }

        /// <summary>
        /// ���i�A���f�[�^�s�����ݒ�
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="isSettingSupplier"></param>
        /// <param name="sectionCode"></param>
        public void SettingGoodsUnitDataListFromVariousMst(ref List<GoodsUnitData> goodsUnitDataList, bool isSettingSupplier, string sectionCode)
        {
            List<GoodsUnitData> retGoodsUnitDataList = new List<GoodsUnitData>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData retGoodsUnitData = goodsUnitData.Clone();
                retGoodsUnitData.SectionCode = sectionCode;
                this.SettingGoodsUnitDataListFromVariousMst(ref retGoodsUnitData, isSettingSupplier);
                retGoodsUnitDataList.Add(retGoodsUnitData);
            }
            goodsUnitDataList = retGoodsUnitDataList;
        }

        /// <summary>
        /// ���i�A���f�[�^�s�����ݒ�
        /// </summary>
        /// <param name="cndtn">���i���������N���X</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        public void SettingGoodsUnitDataListFromVariousMst(ref GoodsUnitData goodsUnitData, bool isSettingSupplier)
        {
            //this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, (isSettingSupplier) ? 0 : 1);// DEL 2014/08/11 duzg For ���؁^�����e�X�g��QNo.5
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst2(ref goodsUnitData, (isSettingSupplier) ? 0 : 1);// Add 2014/08/11 duzg For ���؁^�����e�X�g��QNo.5
        }

        /// <summary>
        /// �w������Y���݌ɏ��擾����
        /// </summary>
        /// <param name="warehouseCode"></param>
        /// <param name="makerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="stockList"></param>
        /// <returns></returns>
        public Stock GetStockFromStockList(string warehouseCode, int makerCd, string goodsNo, List<Stock> stockList)
        {
            if (stockList == null) return null;
            return this._goodsAcs.GetStockFromStockList(warehouseCode, makerCd, goodsNo, stockList);
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�N��
        /// </summary>
        /// <param name="bLGoodsCdUMntList"></param>
        /// <param name="searchCarInfo"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 DEL
        //public int ExecuteBLGoodsCd(out List<BLGoodsCdUMnt> bLGoodsCdUMntList, PMKEN01010E searchCarInfo, int customerCode)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
        public int ExecuteBLGoodsCd( out List<BLGoodsCdUMnt> bLGoodsCdUMntList, PMKEN01010E searchCarInfo, int customerCode, GoodsAcs.BLGuideMode blGuideMode )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 DEL
            //return this._goodsAcs.ExecuteBLGoodsCd(out bLGoodsCdUMntList, searchCarInfo, customerCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
            return this._goodsAcs.ExecuteBLGoodsCd( out bLGoodsCdUMntList, searchCarInfo, _loginSectionCode, customerCode, blGuideMode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
        }

        // UPD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� --------------------->>>>>
        ///// <summary>
        ///// �i�Ԍ���(���i���ꊇ�擾)
        ///// </summary>
        ///// <param name="goodsCndtnList">���i���������I�u�W�F�N�g���X�g</param>
        ///// <param name="goodsUnitDataListList">���i�A���f�[�^�I�u�W�F�N�g���X�g���X�g</param>
        ///// <param name="msg">���b�Z�[�W</param>
        //public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(List<GoodsCndtn> goodsCndtnList, out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        //{
        //    return this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);
        //}
        /// <summary>
        /// �i�Ԍ���(���i���ꊇ�擾)
        /// </summary>
        /// <param name="goodsCndtnList">���i���������I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataListList">���i�A���f�[�^�I�u�W�F�N�g���X�g���X�g</param>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="msg">���b�Z�[�W</param>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(List<GoodsCndtn> goodsCndtnList, out List<List<GoodsUnitData>> goodsUnitDataListList, out PartsInfoDataSet partsInfoDataSet, out String msg)
        {
            return this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out partsInfoDataSet, out msg);
        }
        // UPD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� ---------------------<<<<<

        /// <summary>
        /// BL�R�[�h�ɘA������BL�R�[�h�}�X�^���ABL�O���[�v�R�[�h���A���i�����ޏ��A���i�啪�ޏ����擾���܂��B
        /// </summary>
        /// <param name="bLGoodsCode">BL�R�[�h</param>
        /// <param name="bLGoodsCdUMnt">BL�R�[�h�}�X�^</param>
        /// <param name="bLGroupU">�O���[�v�R�[�h�}�X�^</param>
        /// <param name="goodsGroupU">���i�����ރ}�X�^</param>
        /// <param name="userGdBdU">���i�啪�ރ}�X�^�i���[�U�[�K�C�h�j</param>
        /// <returns>True:�擾����</returns>
        public bool GetBLGoodsRelation(int bLGoodsCode, out BLGoodsCdUMnt bLGoodsCdUMnt, out BLGroupU bLGroupU, out GoodsGroupU goodsGroupU, out UserGdBdU userGdBdU)
        {
            this._goodsAcs.GetBLGoodsRelation(bLGoodsCode, out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU);

            return !((bLGoodsCdUMnt.BLGoodsCode == 0) && (string.IsNullOrEmpty(bLGoodsCdUMnt.BLGoodsName)));
        }

        /// <summary>
        /// ���i�A���f�[�^���X�g���X�g��菤�i�A���f�[�^���X�g���擾
        /// </summary>
        /// <param name="goodsUnitDataListList"></param>
        /// <param name="goodsUnitDataList"></param>
        public void GetGoodsUnitDataListFromListList(List<List<GoodsUnitData>> goodsUnitDataListList, out List<GoodsUnitData> goodsUnitDataList)
        {
            goodsUnitDataList = new List<GoodsUnitData>();

            if (goodsUnitDataListList != null)
            {
                foreach (List<GoodsUnitData> tempGoodsUnitDataList in goodsUnitDataListList)
                {
                    if (tempGoodsUnitDataList.Count != 0) goodsUnitDataList.Add(tempGoodsUnitDataList[0]);
                }
            }
        }
        # endregion

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

            //>>>2010/02/26
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
            //<<<2010/02/26

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
            #region �����t�^�o�I�v�V����
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
            // �t�^�o�q�Ɉ����ăI�v�V�����i�ʁj�FOPT-CPM0100
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
            #region �� ���R�[�G�C�I�v�V�����i�ʁj
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
            #region �� �����c���i�I�v�V�����i�ʁj
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

           // --- ADD K2015/06/18 �I�� �����C�S WebUOE�����񓚎捞 ---------->>>>>
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
            // --- ADD K2015/06/18 �I�� �����C�S WebUOE�����񓚎捞 ----------<<<<<

            // --- ADD ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή� ---------->>>>>
            #region ���R�`���i�� ����`�[����(���i�E�����ύX���b�N)(��)
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_YamagataCustomControl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_YamagataCustom = (int)Option.ON;
            }
            else
            {
                this._opt_YamagataCustom = (int)Option.OFF;
            }
            #endregion
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

        #region ��DEBUG���O�o��
        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (_Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    _Log_Check = 1;
                }
                else
                {
                    _Log_Check = 2;
                }

            }

            if (_Log_Check == 1)
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

        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="pMsg"></param>
        public static void LogWrite(string className, string methodName, string pMsg)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (_Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    _Log_Check = 1;
                }
                else
                {
                    _Log_Check = 2;
                }

            }

            if (_Log_Check == 1)
            {
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
            System.IO.FileStream _fs;										// �t�@�C���X�g���[��
            System.IO.StreamWriter _sw;										// �X�g���[��writer
            _fs = new FileStream("MAHNB01001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2,-70} {3}", edt, edt.Millisecond, className + "." + methodName, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#endif
            }
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
        }

        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="pMsg"></param>
        /// <param name="count"></param>
        public static void LogWrite(string className, string methodName, string pMsg, string count)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (_Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    _Log_Check = 1;
                }
                else
                {
                    _Log_Check = 2;
                }

            }

            if (_Log_Check == 1)
            {
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
            System.IO.FileStream _fs;										// �t�@�C���X�g���[��
            System.IO.StreamWriter _sw;										// �X�g���[��writer
            _fs = new FileStream("MAHNB01001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2,-70} {3} {4}", edt, edt.Millisecond, className + "." + methodName, pMsg, count));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#endif
            }
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
        }

        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="pMsg"></param>
        /// <param name="count1"></param>
        /// <param name="count2"></param>
        public static void LogWrite(string className, string methodName, string pMsg, string count1, string count2)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (_Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    _Log_Check = 1;
                }
                else
                {
                    _Log_Check = 2;
                }

            }

            if (_Log_Check == 1)
            {
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
            System.IO.FileStream _fs;										// �t�@�C���X�g���[��
            System.IO.StreamWriter _sw;										// �X�g���[��writer
            _fs = new FileStream("MAHNB01001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2,-70} {3} {4} {5}", edt, edt.Millisecond, className + "." + methodName, pMsg, count1, count2));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#endif
            }
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
        }

        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="pMsg"></param>
        /// <param name="count1"></param>
        /// <param name="count2"></param>
        /// <param name="count3"></param>
        public static void LogWrite(string className, string methodName, string pMsg, string count1, string count2, string count3)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (_Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    _Log_Check = 1;
                }
                else
                {
                    _Log_Check = 2;
                }

            }

            if (_Log_Check == 1)
            {
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
            System.IO.FileStream _fs;										// �t�@�C���X�g���[��
            System.IO.StreamWriter _sw;										// �X�g���[��writer
            _fs = new FileStream("MAHNB01001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2,-70} {3} {4} {5} {6}", edt, edt.Millisecond, className + "." + methodName, pMsg, count1, count2, count3));
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

        // --- ADD 2010/04/01 ----------<<<<
        #region �}�X�^�`�F�b�N����
        // �}�X�^�`�F�b�N����
        public int ExistUserGuideDivCd_FormUserCd(int userGuideDivCd)
        {
            if ((this._userGdBdList == null) || (this._userGdBdList.Count == 0)) return 0;

            UserGdBd userGuide = this._userGdBdList.Find(
                delegate(UserGdBd uGuide)
                {
                    if (uGuide.UserGuideDivCd == userGuideDivCd)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (userGuide != null)
            {
                return userGuide.GuideCode;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region ReadInitData
        // ���[�J�[�}�X�^
        public void GetMakerUMntList(out List<MakerUMnt> makerUMntList)
        {
            makerUMntList = this._makerUMntList;
        }
        // �񋟂a�k�R�[�h�}�X�^
        public void GettbsPartsCodeList(out List<TbsPartsCodeWork> tbsPartsCodeList)
        {
            tbsPartsCodeList = this._tbsPartsCodeList;
        }
        public void SetMakerUMntList(List<MakerUMnt> makerUMntList)
        {
            this._makerUMntList = makerUMntList;
        }
        // �a�k�R�[�h���X
        public void GetBlGoodsCdUMntList(out List<BLGoodsCdUMnt> blGoodsCdUMntList)
        {
            blGoodsCdUMntList = this._blGoodsCdUMntList;
        }
        public void SetBlGoodsCdUMntList(List<BLGoodsCdUMnt> blGoodsCdUMntList)
        {
            this._blGoodsCdUMntList = blGoodsCdUMntList;
        }
        // �[���Ǘ��}�X�^
        public void GetPosTerminalMg(out PosTerminalMg posTerminalMg)
        {
            posTerminalMg = this._posTerminalMg;
        }
        public void SetPosTerminalMg(PosTerminalMg posTerminalMg)
        {
            this._posTerminalMg = posTerminalMg;
        }
        // ������擾
        public void GetSubSectionList(out List<SubSection> subSectionList)
        {
            subSectionList = this._subSectionList;
        }
        public void SetSubSectionList(List<SubSection> subSectionList)
        {
            this._subSectionList = subSectionList;
        }
        // ���Ӑ�|����ٰ�߂̑S���擾
        public void GetAllCustRateGroupList(out ArrayList allCustRateGroupList)
        {
            allCustRateGroupList = this._allCustRateGroupList;
        }
        public void SetAllCustRateGroupList(ArrayList allCustRateGroupList)
        {
            this._allCustRateGroupList = allCustRateGroupList;
        }
        //2013/05/09 T.Nishi
        public void SetTbsPartsCodeList(List<TbsPartsCodeWork> tbsPartsCodeList)
        {
            this._tbsPartsCodeList = tbsPartsCodeList;
        }
        //2013/05/09 T.Nishi
        // �\���敪�}�X�^
        public void GetDisplayDivList(out List<PriceSelectSet> displayDivList)
        {
            displayDivList = this._displayDivList;
        }
        public void SetDisplayDivList(List<PriceSelectSet> displayDivList)
        {
            this._displayDivList = displayDivList;
        }
        // ���l�K�C�h�}�X�^
        public void GetNoteGuidList(out List<NoteGuidBd> noteGuidList)
        {
            noteGuidList = this._noteGuidList;
        }
        public void SetNoteGuidList(List<NoteGuidBd> noteGuidList)
        {
            this._noteGuidList = noteGuidList;
        }
        // �|���D��Ǘ��}�X�^
        public void GetRateProtyMngList(out List<RateProtyMng> rateProtyMngList)
        {
            rateProtyMngList = this._rateProtyMngList;
        }
        public void SetRateProtyMngList(List<RateProtyMng> rateProtyMngList)
        {
            this._rateProtyMngList = rateProtyMngList;
        }
        // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� --->>>>>
        // �d����}�X�^
        public void GetSupplierList(out List<Supplier> supplierList)
        {
            supplierList = this._supplierList;
        }
        public void SetSupplierList(List<Supplier> supplierList)
        {
            this._supplierList = supplierList;
        }
        // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� ---<<<<<
        #endregion

        #region ReadInitDataSecond
        // �q�ɏ��擾
        public void GetWarehouseList(out List<Warehouse> warehouseList)
        {
            warehouseList = this._warehouseList;
        }
        public void SetWarehouseList(List<Warehouse> warehouseList)
        {
            this._warehouseList = warehouseList;
        }
        // �󔭒��Ǘ��S�̐ݒ�}�X�^
        public void GetAcptAnOdrTtlSt(out AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            acptAnOdrTtlSt = this._acptAnOdrTtlSt;
        }
        public void SetAcptAnOdrTtlSt(AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            this._acptAnOdrTtlSt = acptAnOdrTtlSt;
        }
        // ����S�̐ݒ�}�X�^
        public void GetSalesTtlSt(out SalesTtlSt salesTtlSt)
        {
            salesTtlSt = this._salesTtlSt;
        }
        public void SetSalesTtlSt(SalesTtlSt salesTtlSt)
        {
            this._salesTtlSt = salesTtlSt;
        }
        // ���Ϗ����l�ݒ�}�X�^
        public void GetEstimateDefSet(out EstimateDefSet estimateDefSet)
        {
            estimateDefSet = this._estimateDefSet;
        }
        public void SetEstimateDefSet(EstimateDefSet estimateDefSet)
        {
            this._estimateDefSet = estimateDefSet;
        }
        // �d���݌ɑS�̐ݒ�}�X�^
        public void GetStockTtlSt(out StockTtlSt stockTtlSt)
        {
            stockTtlSt = this._stockTtlSt;
        }
        public void SetStockTtlSt(StockTtlSt stockTtlSt)
        {
            this._stockTtlSt = stockTtlSt;
        }
        // �S�̏����l�ݒ�}�X�^
        public void GetAllDefSet(out AllDefSet allDefSet)
        {
            allDefSet = this._allDefSet;
        }
        public void SetAllDefSet(AllDefSet allDefSet)
        {
            this._allDefSet = allDefSet;
        }
        public void SetInputMode(int inputMode)
        {
            this._inputMode = inputMode;
        }
        // ���Џ��ݒ�}�X�^
        public void GetCompanyInf(out CompanyInf companyInf)
        {
            companyInf = this._companyInf;
        }
        public void SetCompanyInf(CompanyInf companyInf)
        {
            this._companyInf = companyInf;
        }
        // �ŗ��ݒ�}�X�^
        public void GetTaxRateSet(out TaxRateSet taxRateSet, out double taxRate)
        {
            taxRateSet = this._taxRateSet;
            taxRate = this._taxRate;
        }
        public void SetTaxRateSet(TaxRateSet taxRateSet, double taxRate)
        {
            this._taxRateSet = taxRateSet;
            this._taxRate = taxRate;
        }
        // �`�[����ݒ�}�X�^
        public void GetSlipPrtSetList(out List<SlipPrtSet> slipPrtSetList)
        {
            slipPrtSetList = this._slipPrtSetList;
        }
        public void SetSlipPrtSetList(List<SlipPrtSet> slipPrtSetList)
        {
            this._slipPrtSetList = slipPrtSetList;
        }
        // ���Ӑ�}�X�^�i�`�[�Ǘ��j
        public void GetCustSlipMngList(out List<CustSlipMng> custSlipMngList)
        {
            custSlipMngList = this._custSlipMngList;
        }
        public void SetCustSlipMngList(List<CustSlipMng> custSlipMngList)
        {
            this._custSlipMngList = custSlipMngList;
        }
        // �I�v�V�������
        // --- UPD T.Miyamoto 2012/11/13 ---------->>>>>
        ////>>>2010/05/30
        ////public void GetOptInfo(out int opt_CarMng, out int opt_FreeSearch, out int opt_PCC, out int opt_RCLink, out int opt_UOE,
        ////    out int opt_StockingPayment)
        //public void GetOptInfo(out int opt_CarMng, out int opt_FreeSearch, out int opt_PCC, out int opt_RCLink, out int opt_UOE,
        //    out int opt_StockingPayment, out int opt_SCM, out int opt_QRMail)
        ////<<<2010/05/30
        // --- DEL 杍^ K2014/01/22 ---------->>>>>
        //public void GetOptInfo(out int opt_CarMng, out int opt_FreeSearch, out int opt_PCC, out int opt_RCLink, out int opt_UOE,
        //    out int opt_StockingPayment, out int opt_SCM, out int opt_QRMail, out int opt_DateCtrl)
        // --- UPD T.Miyamoto 2012/11/13 ----------<<<<<
        // --- DEL 杍^ K2014/01/22 ----------<<<<<
        // --- ADD 杍^ K2014/01/22 ---------->>>>>
        public void GetOptInfo(out int opt_CarMng, out int opt_FreeSearch, out int opt_PCC, out int opt_RCLink, out int opt_UOE,
            out int opt_StockingPayment, out int opt_SCM, out int opt_QRMail, out int opt_DateCtrl, out int opt_NoBuTo)
        // --- ADD 杍^ K2014/01/22 ----------<<<<<
        {
            // �ԗ��Ǘ��I�v�V����
            opt_CarMng = this._opt_CarMng;
            // ���R�����I�v�V����
            opt_FreeSearch = this._opt_FreeSearch;
            // �o�b�b�I�v�V����
            opt_PCC = this._opt_PCC;
            // ���T�C�N���A���I�v�V����
            opt_RCLink = this._opt_RCLink;
            // �t�n�d�I�v�V����
            opt_UOE = this._opt_UOE;
            // �d���x���Ǘ��I�v�V����
            opt_StockingPayment = this._opt_StockingPayment;
            //>>>2010/05/30
            // SCM
            opt_SCM = this._opt_SCM;
            //<<<2010/05/30
            //>>>2010/06/26
            // QR
            opt_QRMail = this._opt_QRMail;
            //<<<2010/06/26
            // --- ADD T.Miyamoto 2012/11/13 ---------->>>>>
            // ������t����I�v�V����
            opt_DateCtrl = this._opt_DateCtrl;
            // --- ADD T.Miyamoto 2012/11/13 ----------<<<<<

            // --- ADD 杍^ K2014/01/22 ---------->>>>>
            // �o�ˌʐ��p�̃L�[�ɃI�v�V����
            opt_NoBuTo = this._opt_NoBuTo;
            // --- ADD 杍^ K2014/01/22 ----------<<<<<
        }

        // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
        // �R�`���i�I�v�V�������
        public void GetYamagataOptInfo(out int opt_StockEntCtrl
                                     , out int opt_StockDateCtrl
                                     , out int opt_SalesCostCtrl
                                      )
        {
            opt_StockEntCtrl = this._opt_StockEntCtrl;
            opt_StockDateCtrl = this._opt_StockDateCtrl;
            opt_SalesCostCtrl = this._opt_SalesCostCtrl;
        }
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
        // BLP�Q�Ƒq�ɒǉ��I�v�V�����擾
        public void GetBLPPriWarehouseOptInfo(out int opt_BLPPriWarehouse)
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            #region ��BLP�Q�Ƒq�ɒǉ��I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_BLPRefWarehouse);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_BLPPriWarehouse = (int)Option.ON;
            }
            else
            {
                this._opt_BLPPriWarehouse = (int)Option.OFF;
            }
            #endregion
            opt_BLPPriWarehouse = this._opt_BLPPriWarehouse;
        }
        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<

        // --- UPD T.Miyamoto 2012/11/13 ---------->>>>>
        ////>>>2010/05/30
        ////public void SetOptInfo(int opt_CarMng, int opt_FreeSearch, int opt_PCC, int opt_RCLink, int opt_UOE,
        ////    int opt_StockingPayment)
        //public void SetOptInfo(int opt_CarMng, int opt_FreeSearch, int opt_PCC, int opt_RCLink, int opt_UOE,
        //    int opt_StockingPayment, int opt_SCM, int opt_QRMail)
        ////<<<2010/05/30
        // --- DEL 杍^ K2014/01/22 ---------->>>>>
        //public void SetOptInfo(int opt_CarMng, int opt_FreeSearch, int opt_PCC, int opt_RCLink, int opt_UOE,
        //    int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl)
        // --- UPD T.Miyamoto 2012/11/13 ----------<<<<<
        // --- DEL 杍^ K2014/01/22 ----------<<<<<
        // --- ADD 杍^ K2014/01/22 ---------->>>>>
        public void SetOptInfo(int opt_CarMng, int opt_FreeSearch, int opt_PCC, int opt_RCLink, int opt_UOE,
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo)// DEL ���N�n�� K2014/02/17
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, MethodInfo myMethodNobuto, object objNobuto)// ADD ���N�n�� K2014/02/17�@// DEL ���t K2015/04/01
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, MethodInfo myMethodNobuto, object objNobuto, int opt_MoriKawa)// ADD ���t K2015/04/01 // DEL K2015/04/29 �����M �x�m�W�[���C������
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, int opt_FuJi, MethodInfo myMethodNobuto, object objNobuto, int opt_MoriKawa)// ADD K2015/04/29 �����M �x�m�W�[���C������  // DEL  杍^ 2015/10/26 Redmine#47609
            int opt_PermitForKoei,   // ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C
            int opt_FukudaCustom,   // ADD 杍^ K2016/12/26 �����c���i
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, int opt_FuJi, int opt_MeiGo, MethodInfo myMethodNobuto, object objNobuto, int opt_MoriKawa)// ADD  杍^ 2015/10/26 Redmine#47609  // DEL ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή�
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, int opt_FuJi, int opt_MeiGo, MethodInfo myMethodNobuto, int opt_YamagataCustom, object objNobuto, int opt_MoriKawa) // ADD ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή�   // DEL K2016/12/30 杍^ ���쏤�H��
            // ---UPD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------>>>>
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, int opt_FuJi, int opt_MeiGo, int opt_Mizuno2ndSellPriceCtl, MethodInfo myMethodNobuto, int opt_YamagataCustom, object objNobuto, int opt_MoriKawa)  // ADD K2016/12/30 杍^ ���쏤�H��
            // --- ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�--->>>>>
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, int opt_FuJi, int opt_MeiGo, int opt_Mizuno2ndSellPriceCtl, MethodInfo myMethodNobuto, int opt_YamagataCustom, object objNobuto, int opt_MoriKawa, int opt_TSP)
            int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, int opt_FuJi, int opt_MeiGo, int opt_Mizuno2ndSellPriceCtl, MethodInfo myMethodNobuto, int opt_YamagataCustom, object objNobuto, int opt_MoriKawa, int opt_TSP, int opt_PM_EBooks)
            // --- ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<
            // ---UPD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------<<<<
        // --- ADD 杍^ K2014/01/22 ----------<<<<<
        {
            // �ԗ��Ǘ��I�v�V����
            this._opt_CarMng = opt_CarMng;
            // ���R�����I�v�V����
            this._opt_FreeSearch = opt_FreeSearch;
            // �o�b�b�I�v�V����
            this._opt_PCC = opt_PCC;
            // ���T�C�N���A���I�v�V����
            this._opt_RCLink = opt_RCLink;
            // �t�n�d�I�v�V����
            this._opt_UOE = opt_UOE;
            // �d���x���Ǘ��I�v�V����
            this._opt_StockingPayment = opt_StockingPayment;
            //>>>2010/05/30
            // SCM
            this._opt_SCM = opt_SCM;
            //<<<2010/05/30
            //>>>2010/06/26
            // QR
            this._opt_QRMail = opt_QRMail;
            //<<<2010/06/26
            // --- ADD T.Miyamoto 2012/11/13 ---------->>>>>
            // ������t����I�v�V����
            this._opt_DateCtrl = opt_DateCtrl;
            // --- ADD T.Miyamoto 2012/11/13 ----------<<<<<

            this._opt_NoBuTo = Opt_NoBuTo; // ADD 杍^ K2014/01/22

            // ---ADD ���N�n�� K2014/02/17--------------->>>>>
            // �Q�Ɨp���@�R�[��
            this.MyMethodNobuto = myMethodNobuto;
            // �Q�Ɨpobject
            this.ObjNobuto = objNobuto;
            // ---ADD ���N�n�� K2014/02/17---------------<<<<<
            
            // --- ADD K2015/04/01 ���t �X�암�i�ʈ˗� ---------->>>>>
            // �X�암�i�I�v�V�����i�ʁj
            this._opt_MoriKawa = opt_MoriKawa;
            // --- ADD K2015/04/01 ���t �X�암�i�ʈ˗� ----------<<<<<

            // --- ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C --- >>>>>
            //  ���R�[�G�C�I�v�V�����i�ʁj
            this._opt_PermitForKoei = opt_PermitForKoei;
            // --- ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C --- <<<<<

            // --- ADD 杍^ K2016/12/26 �����c���i --- >>>>>
            //  �����c���i�I�v�V�����i�ʁj
            this._opt_FukudaCustom = opt_FukudaCustom;
            // --- ADD 杍^ K2016/12/26 �����c���i --- <<<<<

            // --- ADD K2015/04/29 �����M �x�m�W�[���C������ ---------->>>>>
            // �x�m�W�[���C�������I�v�V�����i�ʁj
            this._opt_FuJi = opt_FuJi;
            // --- ADD K2015/04/29 �����M �x�m�W�[���C������ ----------<<<<<

            // --- ADD K2015/06/18 �I�� �����C�S WebUOE�����񓚎捞 ---------->>>>>
            // �����C�S�I�v�V�����i�ʁj
            this._opt_MeiGo = opt_MeiGo;
            // --- ADD K2015/06/18 �I�� �����C�S WebUOE�����񓚎捞 ----------<<<<<

            // --- ADD ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή� ---------->>>>>
            // �R�`���i�� ����`�[����(���i�E�����ύX���b�N)(��)
            this._opt_YamagataCustom = opt_YamagataCustom;
            // --- ADD ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή� ----------<<<<<

            // --- ADD K2016/12/30 杍^ ���쏤�H���@��񔄉� ---------->>>>>
            // ���쏤�H���I�v�V�����i�ʁj
            this._opt_Mizuno2ndSellPriceCtl = opt_Mizuno2ndSellPriceCtl;
            // --- ADD K2016/12/30 杍^ ���쏤�H���@��񔄉� ----------<<<<<
            this._opt_TSP = opt_TSP;// ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή�
            this._opt_PM_EBooks = opt_PM_EBooks;// ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�
        }

        // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
        public void SetYamagataOptInfo(int opt_StockEntCtrl
                                     , int opt_StockDateCtrl
                                     , int opt_SalesCostCtrl
                                      )
        {
            this._opt_StockEntCtrl = opt_StockEntCtrl;
            this._opt_StockDateCtrl = opt_StockDateCtrl;
            this._opt_SalesCostCtrl = opt_SalesCostCtrl;
        }
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        public void SetFutabaOptInfo(int opt_Cpm_FutabaSlipPrtCtl
                                    ,int opt_Cpm_FutabaWarehAlloc
                                    ,int opt_Cpm_FutabaUOECtl
                                    ,int opt_Cpm_FutabaOutSlipCtl
                                    )
        {
            this._opt_Cpm_FutabaSlipPrtCtl = opt_Cpm_FutabaSlipPrtCtl;
            this._opt_Cpm_FutabaWarehAlloc = opt_Cpm_FutabaWarehAlloc;
            this._opt_Cpm_FutabaUOECtl     = opt_Cpm_FutabaUOECtl;
            this._opt_Cpm_FutabaOutSlipCtl = opt_Cpm_FutabaOutSlipCtl;
        }
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

        // �t�n�d�K�C�h���̃}�X�^
        public void GetUoeGuideNameList(out List<UOEGuideName> uoeGuideNameList)
        {
            uoeGuideNameList = this._uoeGuideNameList;
        }
        public void SetUoeGuideNameList(List<UOEGuideName> uoeGuideNameList)
        {
            this._uoeGuideNameList = uoeGuideNameList;
        }
        // �t�n�d���Ѓ}�X�^
        public void GetUoeSetting(out UOESetting uoeSetting)
        {
            uoeSetting = this._uoeSetting;
        }
        public void SetUoeSetting(UOESetting uoeSetting)
        {
            this._uoeSetting = uoeSetting;
        }
        #endregion

        #region ReadInitDataThird
        // �S�]�ƈ��^�]�ƈ��ڍ׏��
        public void GetEmployeeInfo(out List<Employee> employeeList, out List<EmployeeDtl> employeeDtlList)
        {
            employeeList = this._employeeList;
            employeeDtlList = this._employeeDtlList;
        }
        public void SetEmployeeInfo(List<Employee> employeeList, List<EmployeeDtl> employeeDtlList)
        {
            this._employeeList = employeeList;
            this._employeeDtlList = employeeDtlList;
        }
        // ���[�U�[�K�C�h�}�X�^
        public void GetUserGdBdList(out List<UserGdBd> userGdBdList)
        {
            userGdBdList = this._userGdBdList;
        }
        public void SetUserGdBdList(List<UserGdBd> userGdBdList)
        {
            this._userGdBdList = userGdBdList;
        }
        // ������z�����敪�ݒ�}�X�^
        public void GetSalesProcMoneyList(out List<SalesProcMoney> salesProcMoneyList)
        {
            salesProcMoneyList = this._salesProcMoneyList;
        }
        public void SetSalesProcMoneyList(List<SalesProcMoney> salesProcMoneyList)
        {
            this._salesProcMoneyList = salesProcMoneyList;
        }
        // �d�����z�����敪�ݒ�}�X�^
        public void GetStockProcMoneyList(out List<StockProcMoney> stockProcMoneyList)
        {
            stockProcMoneyList = this._stockProcMoneyList;
        }
        public void SetStockProcMoneyList(List<StockProcMoney> stockProcMoneyList)
        {
            this._stockProcMoneyList = stockProcMoneyList;
        }
        public void SetGoodsAcs(GoodsAcs goodsAcs)
        {
            this._goodsAcs = goodsAcs;
        }
        public void SetUserGuideAcs(UserGuideAcs userGuideAcs)
        {
            this._userGuideAcs = userGuideAcs;
        }
        #endregion
        // --- ADD 2010/04/01 ---------->>>>

        //>>>2010/05/30
        public void SetSCMTtlSt(SCMTtlSt scmTtlSt)
        {
            this._scmTtlSt = scmTtlSt;
        }
        public void SetSCMDeliDateStList(List<SCMDeliDateSt> scmDeliDateStList)
        {
            this._scmDeliDateStList = scmDeliDateStList;
            // 2011/01/31 Add >>>
            this._scmDeliDateStList.Sort(new SCMDeliDateStComparer());
            // 2011/01/31 Add <<<
        }
        // --- DEL 2010/06/26 ---------->>>>>
        //public void SetTbsPartsCdChgWorkList(List<TbsPartsCdChgWork> tbsPartsCdChgWorkList)
        //{
        //    this._tbsPartsCdChgWorkList = tbsPartsCdChgWorkList;
        //}
        // --- DEL 2010/06/26 ----------<<<<<
        //<<<2010/05/30

        //>>>2010/07/29
        public void SetSCMTtlSt(List<PriceSelectSet> displayDivList)
        {
            this._displayDivList = displayDivList;
        }
        //<<<2010/07/29

        //>>>2011/09/27
        // �݌ɊǗ��S�̐ݒ�}�X�^
        public void GetStockMngTtlSt(out StockMngTtlSt stockMngTtlSt)
        {
            stockMngTtlSt = this._stockMngTtlSt;
        }
        public void SetStockMngTtlSt(StockMngTtlSt stockMngTtlSt)
        {
            this._stockMngTtlSt = stockMngTtlSt;
        }
        //<<<2011/09/27

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
        public object LoadAssemblyNobuto(string asmname, string classname)
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

        // ------ ADD 2021/03/16 ���O FOR PMKOBETSU-4133-------->>>>>
        /// <summary>
        /// �����l�f�[�^�擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <remarks>
        /// <br>Note       : �����l�f�[�^���擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/03/16</br>
        /// </remarks>
        public void SearchBLGoodsInfo(string enterpriseCode)
        {
            string retMessage = string.Empty;
            // ���O�o�͕��i
            if (LogCommon == null)
            {
                LogCommon = new OutLogCommon();
            }
            try
            {
                
                // �����l�f�[�^�擾
                this._goodsAcs.SearchInitial(enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out retMessage);
                // ���b�Z�[�W����̏ꍇ�A���O�o��
                if (!string.IsNullOrEmpty(retMessage))
                {
                    LogCommon.OutputClientLog(PGID_Log, retMessage, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);
                }
            }
            catch (Exception ex)
            {
                // ���O�o��
                LogCommon.OutputClientLog(PGID_Log, MethodNm, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, ex);
            }
        }
        // ------ ADD 2021/03/16 ���O FOR PMKOBETSU-4133--------<<<<<

        // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�--->>>>>
        /// <summary>
        /// �o�͐���XML�t�@�C���擾
        /// </summary>
        /// <remarks>
        /// <br>Note         : �o�͐���XML�t�@�C���擾�������s��</br>
        /// <br>Programmer   : ������</br>
        /// <br>Date         : 2021/09/10</br>
        /// </remarks>
        public void GetControlXmlInfo()
        {
            try
            {
                _processControlSetting = new ProcessControlSetting();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ProcessControlSettingFile)))
                {
                    // XML�����擾����
                    _processControlSetting = UserSettingController.DeserializeUserSetting<ProcessControlSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ProcessControlSettingFile));

                }
                else
                {
                    _processControlSetting.RateLogOutFlg = (int)OutFlgType.noOutput;
                    _processControlSetting.SaveAddUpDateCheckFlg = (int)OutFlgType.noOutput;
                }
            }
            catch
            {
                if (_processControlSetting == null) _processControlSetting = new ProcessControlSetting();
                _processControlSetting.RateLogOutFlg = (int)OutFlgType.noOutput;
                _processControlSetting.SaveAddUpDateCheckFlg = (int)OutFlgType.noOutput;
            }
        }
        // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�---<<<<<

    }

    // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�--->>>>>
    # region
    /// <summary>
    /// �o�͐���ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�͐���ݒ�N���X</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2021/09/10</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ProcessControlSetting
    {
        // �ŗ����O�o�͋敪
        private int _rateLogOutFlg;
        // �v����`�F�b�N�敪
        private int _saveAddUpDateCheckFlg;

        /// <summary>
        /// �ŗ����O����ݒ�N���X
        /// </summary>
        public ProcessControlSetting()
        {

        }

        /// <summary>�ŗ����O�o�͋敪</summary>
        public Int32 RateLogOutFlg
        {
            get { return this._rateLogOutFlg; }
            set { this._rateLogOutFlg = value; }
        }

        /// <summary>�v����`�F�b�N�敪</summary>
        public Int32 SaveAddUpDateCheckFlg
        {
            get { return this._saveAddUpDateCheckFlg; }
            set { this._saveAddUpDateCheckFlg = value; }
        }
    }
    # endregion
    // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�---<<<<<
}
