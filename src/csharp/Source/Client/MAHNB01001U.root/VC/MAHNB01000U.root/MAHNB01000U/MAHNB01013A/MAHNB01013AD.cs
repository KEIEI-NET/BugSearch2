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
using Broadleaf.Library.Collections;

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
    /// <br>Update Note : 2011/01/31 21024 ���X�� ��</br>
    /// <br>              �@�[���ݒ�}�X�^�̃��C�A�E�g�ύX�Ή�</br>
    /// <br>              �A�[���ݒ�}�X�^�̌����������狒�_�R�[�h���폜</br>
    /// <br>Update Note: 2011/05/25 20056 ���n ���</br>
    /// <br>             SCM����</br>
    /// <br>              1)���M�m�F��ʂɎw�����ԍ��̓��͂�ǉ�</br>
    /// <br>              2)�t�b�^���Ɏw�����ԍ��̓��͂�ǉ�</br>
    /// <br>              3)�̔��敪�̓��͂�̔��敪�\���敪�Ő���</br>
    /// <br>Update Note : 2011/07/19  �����g</br>
    /// <br>               �`�[����ݒ�}�X�^�̃��C�A�E�g�ύX�Ή�</br>
    /// <br>Update Note: 2011/07/25 杍^ �A��No.16 �|���ݒ�Ɋւ��āA00�S�Ћ��� �� ���_�̊|���̗D�揇�ʂ̓������iWAN�^�p�j�̑Ή�</br>
    /// <br>Update Note : 2011/09/27 20056 ���n ���</br>
    /// <br>              �݌ɐ��\���敪���Q�Ƃ��A���݌ɐ��̕\��������s��</br>
    /// <br>Update Note: 2012/05/02 20056 ���n ���</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��Q�Ή�</br>
    /// <br>             ���ǁF�ݏo�d���������͑Ή�</br>
    /// <br>Update Note: 2012/09/13 30747 �O�ˁ@�L��</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2012/10/17�z�M�� ��Q�ꗗ ��2</br>
    /// <br>             �񓚔[���̎擾��ǉ��iSCM��Q��10345�C���R��j</br>
    /// <br>Update Note: 2012/11/13 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��1668</br>
    /// <br>             ����ߋ����t������ʃI�v�V�������i�C�X�R�܂��̓I�v�V��������œ��t����j</br>
    /// <br>Update Note: 2012/12/19 �� �B</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             MAHNB01001U.Log�����݂���ꍇ���O���o�͂���悤�ɕύX</br>
    /// <br>Update Note: 2013/01/18 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : Redmine#33797 �����������l�敪�̒ǉ�</br>
    /// <br>Update Note: 2013/02/05 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : BL�R�[�h�O�Ή�</br>
    /// <br>Update Note: K2013/09/20 �{�{ ����</br>
    /// <br>             ���t�^�o�I�v�V�����Ή��i�ʁj</br>
    /// <br>Update Note: ���N�n�� 2014/07/23</br>
    /// <br>�Ǘ��ԍ�   : 11070147-00</br>
    /// <br>           : SCM�d�|�ꗗ��10659��3SCM�󔭒����׃f�[�^�ɍ݌ɏ󋵋敪�̃Z�b�g�̑Ή�</br>
    /// <br>Update Note: 2015/02/10  30745 �g��</br>
    /// <br>�Ǘ��ԍ�   : 11070266-00</br>
    /// <br>           : SCM������ �񓚔[���敪�Ή�</br>
    /// <br>�Ǘ��ԍ�   : 11370030-00 2017/04/13 杍^</br>
    /// <br>             Redmine#49283 �d���S���Q�Ƌ敪��ǉ�</br>
    /// <br>Update Note: 2020/11/20 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSP�C�����C���@�\�ǉ��Ή�</br>
    /// </remarks>
    public class DelphiSalesSlipInputInitDataThirdAcs
    {
        # region ���R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private DelphiSalesSlipInputInitDataThirdAcs()
        {
        }

        /// <summary>
        /// ������͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        public static DelphiSalesSlipInputInitDataThirdAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataThirdAcs == null)
            {
                _delphiSalesSlipInputInitDataThirdAcs = new DelphiSalesSlipInputInitDataThirdAcs();
            }
            return _delphiSalesSlipInputInitDataThirdAcs;
        }
        # endregion

        #region ���v���C�x�[�g�ϐ�
        private static DelphiSalesSlipInputInitDataThirdAcs _delphiSalesSlipInputInitDataThirdAcs;

        //private UserGuideAcs _userGuideAcs; // 2010/05/30
        private List<SubSection> _subSectionList = null;       // ����}�X�^���X�g
        private List<UserGdBd> _userGdBdList = null;           // ���[�U�[�K�C�h�}�X�^���X�g
        private List<RateProtyMng> _rateProtyMngList = null;
        private List<SalesProcMoney> _salesProcMoneyList = null;
        private List<StockProcMoney> _stockProcMoneyList = null;
        private List<SlipPrtSet> _slipPrtSetList = null;
        private List<CustSlipMng> _custSlipMngList = null;
        private List<UOEGuideName> _uoeGuideNameList = null;
        private AcptAnOdrTtlSt _acptAnOdrTtlSt = null;         // �󔭒��S�̊Ǘ��ݒ�}�X�^
        private SalesTtlSt _salesTtlSt = null;                 // ����S�̐ݒ�}�X�^
        private EstimateDefSet _estimateDefSet = null;         // ���Ϗ����l�ݒ�}�X�^
        private StockTtlSt _stockTtlSt = null;                 // �d���݌ɑS�̐ݒ�}�X�^
        private AllDefSet _allDefSet = null;                   // �S�̏����l�ݒ�}�X�^
        private CompanyInf _companyInf = null;                 // ���Џ��
        //>>>2010/05/30
        private SCMTtlSt _scmTtlSt = null;                     // SCM�S�̐ݒ�}�X�^
        private List<SCMDeliDateSt> _scmDeliDateStList = null; // SCM�[���ݒ�}�X�^���X�g
        //private List<TbsPartsCdChgWork> _tbsPartsCdChgWorkList = null; // BL�R�[�h�ϊ��}�X�^���X�g // DEL 2010/06/26
        //<<<2010/05/30
        private StockMngTtlSt _stockMngTtlSt = null; // �݌ɊǗ��S�̐ݒ�}�X�^ // 2011/09/27

        /// <summary>�I�v�V�������</summary>
        private int _opt_CarMng;
        private int _opt_FreeSearch;
        private int _opt_PCC;
        private int _opt_RCLink;
        private int _opt_UOE;
        private int _opt_StockingPayment;
        private int _opt_SCM; // 2010/05/30
        private int _opt_QRMail; // 2010/05/30
        private int _opt_DateCtrl; // ADD T.Miyamoto 2012/11/13
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        private int _opt_Cpm_FutabaSlipPrtCtl; // �t�^�o�`�[�������I�v�V�����i�ʁj�FOPT-CPM0090
        private int _opt_Cpm_FutabaWarehAlloc; // �t�^�o�q�Ɉ����ăI�v�V����  �i�ʁj�FOPT-CPM0100
        private int _opt_Cpm_FutabaUOECtl;     // �t�^�oUOE�I�v�V����         �i�ʁj�FOPT-CPM0110
        private int _opt_Cpm_FutabaOutSlipCtl; // �t�^�o�o�͍ϓ`�[����        �i�ʁj�FOPT-CPM0120

        private int _opt_BLPRefWarehouse;   // BLP�Q�Ƒq�ɒǉ��I�v�V�����FOPT-PM00230
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

        // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------>>>>
        private int _opt_TSP;
        // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------<<<<

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
        /// <br>Update Note: 2009/09/08 ���M ���q�Ǘ��@�\�Ή�</br>
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

        #endregion

        #region ���C�x���g
        /// <summary>������z�����敪�ݒ�L���b�V���C�x���g</summary>
        public event CacheSalesProcMoneyListEventHandler CacheSalesProcMoneyList;
        /// <summary>�d�����z�����敪�ݒ�Z�b�g�C�x���g</summary>
        public event CacheStockProcMoneyListEventHandler CacheStockProcMoneyList;
        /// <summary>�|���D��Ǘ��}�X�^�Z�b�g�C�x���g</summary>
        public event CacheRateProtyMngListEventHandler CacheRateProtyMngList;
        #endregion

        #region ���f���Q�[�g
        /// <summary>������z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
        public delegate void CacheSalesProcMoneyListEventHandler(List<SalesProcMoney> salesProcMoneyList);
        /// <summary>�d�����z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
        public delegate void CacheStockProcMoneyListEventHandler(List<StockProcMoney> stockProcMoneyList);
        /// <summary>�|���D��Ǘ��}�X�^�L���b�V���f���Q�[�g</summary>
        public delegate void CacheRateProtyMngListEventHandler(List<RateProtyMng> rateProtyMngList);
        #endregion

        /// <summary>���_�R�[�h(�S��)</summary>
        public const string ctSectionCode = "00";

        # region ���p�u���b�N���\�b�h
        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        /// <br>Update Note: 2011/07/25 杍^ �A��No.16 �|���ݒ�Ɋւ��āA00�S�Ћ��� �� ���_�̊|���̗D�揇�ʂ̓������iWAN�^�p�j�̑Ή�</br>
        /// <br>�Ǘ��ԍ�   : 11370030-00 2017/04/13 杍^</br>
        /// <br>             Redmine#49283 �d���S���Q�Ƌ敪��ǉ�</br>
        public int ReadInitDataThird(string enterpriseCode, string sectionCode)
        {
            #region ���I�v�V�������
            LogWrite("�R�I�v�V���������擾");
            this.CacheOptionInfo();
            #endregion

            CustomSerializeArrayList workList = new CustomSerializeArrayList();
            object retObj;
            workList.Clear();
            retObj = workList;

            this._subSectionList = new List<SubSection>(); // ����}�X�^
            SubSectionWork subSectionWork = new SubSectionWork();
            subSectionWork.EnterpriseCode = enterpriseCode;

            this._rateProtyMngList = new List<RateProtyMng>(); // �|���D��Ǘ��}�X�^
            RateProtyMngWork rateProtyMngWork = new RateProtyMngWork();
            rateProtyMngWork.EnterpriseCode = enterpriseCode;

            this._userGdBdList = new List<UserGdBd>(); // ���[�U�[�K�C�h
            UserGdBdUWork userGdBdUWork = new UserGdBdUWork();
            userGdBdUWork.EnterpriseCode = enterpriseCode;

            this._salesProcMoneyList = new List<SalesProcMoney>(); // ������z�����敪�}�X�^
            SalesProcMoneyWork salesProcMoneyWork = new SalesProcMoneyWork();
            salesProcMoneyWork.EnterpriseCode = enterpriseCode;
            salesProcMoneyWork.FracProcMoneyDiv = -1;
            salesProcMoneyWork.FractionProcCode = -1;

            this._stockProcMoneyList = new List<StockProcMoney>(); // �d�����z�����敪�}�X�^
            StockProcMoneyWork stockProcMoneyWork = new StockProcMoneyWork();
            stockProcMoneyWork.EnterpriseCode = enterpriseCode;
            stockProcMoneyWork.FracProcMoneyDiv = -1;
            stockProcMoneyWork.FractionProcCode = -1;

            AcptAnOdrTtlStWork acptAnOdrTtlStWork = new AcptAnOdrTtlStWork();
            acptAnOdrTtlStWork.EnterpriseCode = enterpriseCode;

            SalesTtlStWork salesTtlStWork = new SalesTtlStWork();
            salesTtlStWork.EnterpriseCode = enterpriseCode;

            EstimateDefSetWork estimateDefSetWork = new EstimateDefSetWork();
            estimateDefSetWork.EnterpriseCode = enterpriseCode;

            StockTtlStWork stockTtlStWork = new StockTtlStWork();
            stockTtlStWork.EnterpriseCode = enterpriseCode;

            AllDefSetWork allDefSetWork = new AllDefSetWork();
            allDefSetWork.EnterpriseCode = enterpriseCode;

            CompanyInfWork companyInfWork = new CompanyInfWork();
            companyInfWork.EnterpriseCode = enterpriseCode;

            TaxRateSetWork taxRateSetWork = new TaxRateSetWork();
            taxRateSetWork.EnterpriseCode = enterpriseCode;

            this._slipPrtSetList = new List<SlipPrtSet>();
            SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();
            slipPrtSetWork.EnterpriseCode = enterpriseCode;

            this._custSlipMngList = new List<CustSlipMng>();
            CustSlipMngWork custSlipMngWork = new CustSlipMngWork();
            custSlipMngWork.EnterpriseCode = enterpriseCode;

            this._uoeGuideNameList = new List<UOEGuideName>();
            UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();
            uoeGuideNameWork.EnterpriseCode = enterpriseCode;
            uoeGuideNameWork.SectionCode = sectionCode.Trim();

            UOESettingWork uoeSettingWork = new UOESettingWork();
            uoeSettingWork.EnterpriseCode = enterpriseCode;
            uoeSettingWork.SectionCode = sectionCode.Trim();

            //>>>2010/05/30
            SCMDeliDateStWork scmDeliDateStWork = new SCMDeliDateStWork();
            scmDeliDateStWork.EnterpriseCode = enterpriseCode;
            //scmDeliDateStWork.SectionCode = sectionCode.Trim();   // 2011/01/31 Del

            SCMTtlStWork scmTtlStWork = new SCMTtlStWork();
            scmTtlStWork.EnterpriseCode = enterpriseCode;
            //scmTtlStWork.SectionCode = sectionCode.Trim();

            TbsPartsCdChgWork tbsPartsCdChgWork = new TbsPartsCdChgWork();
            //<<<2010/05/30

            // 2011/01/31 Add >>>
            this._scmDeliDateStList = new List<SCMDeliDateSt>();
            // 2011/01/31 Add <<<

            //>>>2011/09/27
            StockMngTtlStWork stockMngTtlStWork = new StockMngTtlStWork();
            stockMngTtlStWork.EnterpriseCode = enterpriseCode;
            //<<<2011/09/27

            workList.Add(subSectionWork);
            workList.Add(rateProtyMngWork);
            workList.Add(userGdBdUWork);
            workList.Add(salesProcMoneyWork);
            workList.Add(stockProcMoneyWork);

            workList.Add(acptAnOdrTtlStWork);
            workList.Add(salesTtlStWork);
            workList.Add(estimateDefSetWork);
            workList.Add(stockTtlStWork);
            workList.Add(allDefSetWork);
            workList.Add(companyInfWork);
            workList.Add(taxRateSetWork);
            workList.Add(slipPrtSetWork);
            workList.Add(custSlipMngWork);
            workList.Add(uoeGuideNameWork);
            workList.Add(uoeSettingWork);

            //>>>2010/05/30
            workList.Add(scmTtlStWork);
            workList.Add(scmDeliDateStWork);
            workList.Add(tbsPartsCdChgWork);
            //<<<2010/05/30

            workList.Add(stockMngTtlStWork); // 2011/09/27

            IVariousMasterSearchDB _iVariousMasterSearchDB = MediationVariousMasterSearchDB.GetRemoteObject();
            int ist = 0;
            try
            {
                ist = _iVariousMasterSearchDB.Search(ref retObj, null, 0, ConstantManagement.LogicalMode.GetData0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (ist == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                workList = retObj as CustomSerializeArrayList;

                if (workList[0] is ArrayList)
                {
                    foreach (ArrayList arList in workList)
                    {
                        if (arList != null && arList.Count > 0)
                        {
                            #region �󔭒��Ǘ��S�̐ݒ�
                            if (arList[0] is AcptAnOdrTtlStWork)
                            {
                                this._acptAnOdrTtlSt = new AcptAnOdrTtlSt();
                                AcptAnOdrTtlStWork svWork = new AcptAnOdrTtlStWork();
                                foreach (AcptAnOdrTtlStWork work in arList)
                                {
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == sectionCode.Trim()))
                                    {
                                        svWork = work;
                                        break;
                                    }
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == ctSectionCode.Trim()))
                                    {
                                        svWork = work;
                                    }
                                }
                                #region ���ڃZ�b�g
                                this._acptAnOdrTtlSt.AcpOdrrSlipPrtDiv = svWork.AcpOdrrSlipPrtDiv;
                                this._acptAnOdrTtlSt.CreateDateTime = svWork.CreateDateTime;
                                this._acptAnOdrTtlSt.EnterpriseCode = svWork.EnterpriseCode;
                                this._acptAnOdrTtlSt.EstmCountReflectDiv = svWork.EstmCountReflectDiv;
                                this._acptAnOdrTtlSt.FaxOrderDiv = svWork.FaxOrderDiv;
                                this._acptAnOdrTtlSt.FileHeaderGuid = svWork.FileHeaderGuid;
                                this._acptAnOdrTtlSt.LogicalDeleteCode = svWork.LogicalDeleteCode;
                                this._acptAnOdrTtlSt.SectionCode = svWork.SectionCode;
                                this._acptAnOdrTtlSt.UpdAssemblyId1 = svWork.UpdAssemblyId1;
                                this._acptAnOdrTtlSt.UpdAssemblyId2 = svWork.UpdAssemblyId2;
                                this._acptAnOdrTtlSt.UpdateDateTime = svWork.UpdateDateTime;
                                this._acptAnOdrTtlSt.UpdEmployeeCode = svWork.UpdEmployeeCode;
                                #endregion
                            }
                            #endregion

                            #region ����S�̐ݒ�
                            if (arList[0] is SalesTtlStWork)
                            {
                                this._salesTtlSt = new SalesTtlSt();
                                SalesTtlStWork svWork = new SalesTtlStWork();
                                foreach (SalesTtlStWork work in arList)
                                {
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == sectionCode.Trim()))
                                    {
                                        svWork = work;
                                        break;
                                    }
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == ctSectionCode.Trim()))
                                    {
                                        svWork = work;
                                    }
                                }
                                #region ���ڃZ�b�g
                                this._salesTtlSt.CreateDateTime = svWork.CreateDateTime; // �쐬����
                                this._salesTtlSt.UpdateDateTime = svWork.UpdateDateTime; // �X�V����
                                this._salesTtlSt.EnterpriseCode = svWork.EnterpriseCode; // ��ƃR�[�h
                                this._salesTtlSt.FileHeaderGuid = svWork.FileHeaderGuid; // GUID
                                this._salesTtlSt.UpdEmployeeCode = svWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                                this._salesTtlSt.UpdAssemblyId1 = svWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                                this._salesTtlSt.UpdAssemblyId2 = svWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                                this._salesTtlSt.LogicalDeleteCode = svWork.LogicalDeleteCode; // �_���폜�敪
                                this._salesTtlSt.SectionCode = svWork.SectionCode; // ���_�R�[�h
                                this._salesTtlSt.SalesSlipPrtDiv = svWork.SalesSlipPrtDiv; // ����`�[���s�敪
                                this._salesTtlSt.ShipmSlipPrtDiv = svWork.ShipmSlipPrtDiv; // �o�ד`�[���s�敪
                                this._salesTtlSt.ShipmSlipUnPrcPrtDiv = svWork.ShipmSlipUnPrcPrtDiv; // �o�ד`�[�P������敪
                                this._salesTtlSt.GrsProfitCheckLower = svWork.GrsProfitCheckLower; // �e���`�F�b�N����
                                this._salesTtlSt.GrsProfitCheckBest = svWork.GrsProfitCheckBest; // �e���`�F�b�N�K��
                                this._salesTtlSt.GrsProfitCheckUpper = svWork.GrsProfitCheckUpper; // �e���`�F�b�N���
                                this._salesTtlSt.GrsProfitChkLowSign = svWork.GrsProfitChkLowSign; // �e���`�F�b�N�����L��
                                this._salesTtlSt.GrsProfitChkBestSign = svWork.GrsProfitChkBestSign; // �e���`�F�b�N�K���L��
                                this._salesTtlSt.GrsProfitChkUprSign = svWork.GrsProfitChkUprSign; // �e���`�F�b�N����L��
                                this._salesTtlSt.GrsProfitChkMaxSign = svWork.GrsProfitChkMaxSign; // �e���`�F�b�N�ő�L��
                                this._salesTtlSt.SalesAgentChngDiv = svWork.SalesAgentChngDiv; // ����S���ύX�敪
                                this._salesTtlSt.AcpOdrAgentDispDiv = svWork.AcpOdrAgentDispDiv; // �󒍎ҕ\���敪
                                this._salesTtlSt.BrSlipNote2DispDiv = svWork.BrSlipNote2DispDiv; // �`�[���l�Q�\���敪
                                this._salesTtlSt.DtlNoteDispDiv = svWork.DtlNoteDispDiv; // ���ה��l�\���敪
                                this._salesTtlSt.UnPrcNonSettingDiv = svWork.UnPrcNonSettingDiv; // �������ݒ莞�敪
                                this._salesTtlSt.EstmateAddUpRemDiv = svWork.EstmateAddUpRemDiv; // ���σf�[�^�v��c�敪
                                this._salesTtlSt.AcpOdrrAddUpRemDiv = svWork.AcpOdrrAddUpRemDiv; // �󒍃f�[�^�v��c�敪
                                this._salesTtlSt.ShipmAddUpRemDiv = svWork.ShipmAddUpRemDiv; // �o�׃f�[�^�v��c�敪
                                this._salesTtlSt.RetGoodsStockEtyDiv = svWork.RetGoodsStockEtyDiv; // �ԕi���݌ɓo�^�敪
                                this._salesTtlSt.ListPriceSelectDiv = svWork.ListPriceSelectDiv; // �艿�I���敪
                                this._salesTtlSt.MakerInpDiv = svWork.MakerInpDiv; // ���[�J�[���͋敪
                                this._salesTtlSt.BLGoodsCdInpDiv = svWork.BLGoodsCdInpDiv; // BL���i�R�[�h���͋敪
                                this._salesTtlSt.SupplierInpDiv = svWork.SupplierInpDiv; // �d������͋敪
                                this._salesTtlSt.SupplierSlipDelDiv = svWork.SupplierSlipDelDiv; // �d���`�[�폜�敪
                                this._salesTtlSt.CustGuideDispDiv = svWork.CustGuideDispDiv; // ���Ӑ�K�C�h�����\���敪
                                this._salesTtlSt.SlipChngDivDate = svWork.SlipChngDivDate; // �`�[�C���敪�i���t�j
                                this._salesTtlSt.SlipChngDivCost = svWork.SlipChngDivCost; // �`�[�C���敪�i�����j
                                this._salesTtlSt.SlipChngDivUnPrc = svWork.SlipChngDivUnPrc; // �`�[�C���敪�i�����j
                                this._salesTtlSt.SlipChngDivLPrice = svWork.SlipChngDivLPrice; // �`�[�C���敪�i�艿�j
                                this._salesTtlSt.RetSlipChngDivCost = svWork.RetSlipChngDivCost; // �ԕi�`�[�C���敪�i�����j
                                this._salesTtlSt.RetSlipChngDivUnPrc = svWork.RetSlipChngDivUnPrc; // �ԕi�`�[�C���敪�i�����j
                                this._salesTtlSt.AutoDepoKindCode = svWork.AutoDepoKindCode; // ������������R�[�h
                                this._salesTtlSt.AutoDepoKindName = svWork.AutoDepoKindName; // �����������햼��
                                this._salesTtlSt.AutoDepoKindDivCd = svWork.AutoDepoKindDivCd; // ������������敪
                                this._salesTtlSt.DiscountName = svWork.DiscountName; // �l������
                                this._salesTtlSt.InpAgentDispDiv = svWork.InpAgentDispDiv; // ���s�ҕ\���敪
                                this._salesTtlSt.CustOrderNoDispDiv = svWork.CustOrderNoDispDiv; // ���Ӑ撍�ԕ\���敪
                                this._salesTtlSt.CarMngNoDispDiv = svWork.CarMngNoDispDiv; // �ԗ��Ǘ��ԍ��\���敪
                                this._salesTtlSt.BrSlipNote3DispDiv = svWork.BrSlipNote3DispDiv; // �`�[���l�R�\���敪
                                this._salesTtlSt.SlipDateClrDivCd = svWork.SlipDateClrDivCd; // �`�[���t�N���A�敪
                                this._salesTtlSt.AutoEntryGoodsDivCd = svWork.AutoEntryGoodsDivCd; // ���i�����o�^�敪
                                this._salesTtlSt.CostCheckDivCd = svWork.CostCheckDivCd; // �����`�F�b�N�敪
                                this._salesTtlSt.JoinInitDispDiv = svWork.JoinInitDispDiv; // ���������\���敪
                                this._salesTtlSt.AutoDepositCd = svWork.AutoDepositCd; // ���������敪
                                this._salesTtlSt.SubstCondDivCd = svWork.SubstCondDivCd; // ��֏����敪
                                this._salesTtlSt.SlipCreateProcess = svWork.SlipCreateProcess; // �`�[�쐬���@
                                this._salesTtlSt.WarehouseChkDiv = svWork.WarehouseChkDiv; // �q�Ƀ`�F�b�N�敪
                                this._salesTtlSt.PartsSearchDivCd = svWork.PartsSearchDivCd; // ���i�����敪
                                this._salesTtlSt.GrsProfitDspCd = svWork.GrsProfitDspCd; // �e���\���敪
                                this._salesTtlSt.PartsSearchPriDivCd = svWork.PartsSearchPriDivCd; // ���i�����D�揇�敪
                                this._salesTtlSt.SalesStockDiv = svWork.SalesStockDiv; // ����d���敪
                                this._salesTtlSt.PrtBLGoodsCodeDiv = svWork.PrtBLGoodsCodeDiv; // ����pBL���i�R�[�h�敪
                                this._salesTtlSt.SectDspDivCd = svWork.SectDspDivCd; // ���_�\���敪
                                this._salesTtlSt.GoodsNmReDispDivCd = svWork.GoodsNmReDispDivCd; // ���i���ĕ\���敪
                                this._salesTtlSt.CostDspDivCd = svWork.CostDspDivCd; // �����\���敪
                                this._salesTtlSt.DepoSlipDateClrDiv = svWork.DepoSlipDateClrDiv; // �����`�[���t�N���A�敪
                                this._salesTtlSt.DepoSlipDateAmbit = svWork.DepoSlipDateAmbit; // �����`�[���t�͈͋敪
                                this._salesTtlSt.InpGrsProfChkLower = svWork.InpGrsProfChkLower; // ���͑e���`�F�b�N����
                                this._salesTtlSt.InpGrsProfChkUpper = svWork.InpGrsProfChkUpper; // ���͑e���`�F�b�N���
                                this._salesTtlSt.InpGrsProfChkLowDiv = svWork.InpGrsPrfChkLowDiv; // ���͑e���`�F�b�N�����敪
                                this._salesTtlSt.InpGrsProfChkUppDiv = svWork.InpGrsPrfChkUppDiv; // ���͑e���`�F�b�N����敪
                                this._salesTtlSt.PrmSubstCondDivCd = svWork.PrmSubstCondDivCd; // �D�Ǒ�֏����敪
                                this._salesTtlSt.SubstApplyDivCd = svWork.SubstApplyDivCd; // ��֓K�p�敪
                                this._salesTtlSt.PartsNameDspDivCd = svWork.PartsNameDspDivCd; // �i���\���敪
                                this._salesTtlSt.BLGoodsCdDerivNoDiv = svWork.BLGoodsCdDerivNoDiv; // BL�R�[�h�}�ԋ敪
                                this._salesTtlSt.PriceSelectDispDiv = svWork.PriceSelectDispDiv; // �W�����i�I��\���敪
                                this._salesTtlSt.AcpOdrInputDiv = svWork.AcpOdrInputDiv; // �󒍐����͋敪
                                this._salesTtlSt.InpAgentChkDiv = svWork.InpAgentChkDiv; // ���s�҃`�F�b�N�敪
                                this._salesTtlSt.InpWarehChkDiv = svWork.InpWarehChkDiv; // ���͑q�Ƀ`�F�b�N�敪
                                this._salesTtlSt.FrSrchPrtAutoEntDiv = svWork.FrSrchPrtAutoEntDiv; // ���R�������i�����o�^�敪 // 2010/05/30
                                //>>>2010/07/01
                                this._salesTtlSt.BLCdPrtsNmDspDivCd1 = svWork.BLCdPrtsNmDspDivCd1; // BL�R�[�h�����i���\���敪�P
                                this._salesTtlSt.BLCdPrtsNmDspDivCd2 = svWork.BLCdPrtsNmDspDivCd2; // BL�R�[�h�����i���\���敪�Q
                                this._salesTtlSt.BLCdPrtsNmDspDivCd3 = svWork.BLCdPrtsNmDspDivCd3; // BL�R�[�h�����i���\���敪�R
                                this._salesTtlSt.BLCdPrtsNmDspDivCd4 = svWork.BLCdPrtsNmDspDivCd4; // BL�R�[�h�����i���\���敪�S
                                this._salesTtlSt.GdNoPrtsNmDspDivCd1 = svWork.GdNoPrtsNmDspDivCd1; // �i�Ԍ����i���\���敪�P
                                this._salesTtlSt.GdNoPrtsNmDspDivCd2 = svWork.GdNoPrtsNmDspDivCd2; // �i�Ԍ����i���\���敪�Q
                                this._salesTtlSt.GdNoPrtsNmDspDivCd3 = svWork.GdNoPrtsNmDspDivCd3; // �i�Ԍ����i���\���敪�R
                                this._salesTtlSt.GdNoPrtsNmDspDivCd4 = svWork.GdNoPrtsNmDspDivCd4; // �i�Ԍ����i���\���敪�S
                                this._salesTtlSt.PrmPrtsNmUseDivCd = svWork.PrmPrtsNmUseDivCd; // �D�Ǖ��i�����i���g�p�敪
                                //<<<2010/07/01

                                this._salesTtlSt.DwnPLCdSpDivCd = svWork.DwnPLCdSpDivCd; // ADD 2010/08/13
                                this._salesTtlSt.SalesCdDspDivCd = svWork.SalesCdDspDivCd; // 2011/05/25

                                //>>>2012/05/02
                                this._salesTtlSt.RentStockDiv = svWork.RentStockDiv;
                                //<<<2012/05/02

                                this._salesTtlSt.AutoDepositNoteDiv = svWork.AutoDepositNoteDiv; // �����������l�敪(0:����`�[�ԍ� 1:����`�[���l 2:����) // ADD 2013/01/18 �c���� Redmine#33797

                                // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
                                this._salesTtlSt.BLGoodsCdZeroSuprt = svWork.BLGoodsCdZeroSuprt;    // BL�R�[�h�O�Ή�
                                this._salesTtlSt.BLGoodsCdChange = svWork.BLGoodsCdChange;          // �ϊ��R�[�h
                                // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

                                this._salesTtlSt.StockEmpRefDiv = svWork.StockEmpRefDiv; // ADD 2017/04/13 杍^ Redmine#49283

                                #endregion
                            }
                            #endregion

                            #region ���Ϗ����l�ݒ�
                            if (arList[0] is EstimateDefSetWork)
                            {
                                this._estimateDefSet = new EstimateDefSet();
                                EstimateDefSetWork svWork = new EstimateDefSetWork();
                                foreach (EstimateDefSetWork work in arList)
                                {
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == sectionCode.Trim()))
                                    {
                                        svWork = work;
                                        break;
                                    }
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == ctSectionCode.Trim()))
                                    {
                                        svWork = work;
                                    }
                                }
                                #region ���ڃZ�b�g
                                this._estimateDefSet.ConsTaxPrintDiv = svWork.ConsTaxPrintDiv;
                                this._estimateDefSet.CreateDateTime = svWork.CreateDateTime;
                                this._estimateDefSet.EnterpriseCode = svWork.EnterpriseCode;
                                this._estimateDefSet.EstimateDtCreateDiv = svWork.EstimateDtCreateDiv;
                                this._estimateDefSet.EstimateNote1 = svWork.EstimateNote1;
                                this._estimateDefSet.EstimateNote2 = svWork.EstimateNote2;
                                this._estimateDefSet.EstimateNote3 = svWork.EstimateNote3;
                                this._estimateDefSet.EstimatePrtDiv = svWork.EstimatePrtDiv;
                                this._estimateDefSet.EstimateTitle1 = svWork.EstimateTitle1;
                                this._estimateDefSet.EstimateValidityTerm = svWork.EstimateValidityTerm;
                                this._estimateDefSet.EstmFormNoPickDiv = svWork.EstmFormNoPickDiv;
                                this._estimateDefSet.FaxEstimatetDiv = svWork.FaxEstimatetDiv;
                                this._estimateDefSet.FileHeaderGuid = svWork.FileHeaderGuid;
                                this._estimateDefSet.ListPricePrintDiv = svWork.ListPricePrintDiv;
                                this._estimateDefSet.LogicalDeleteCode = svWork.LogicalDeleteCode;
                                this._estimateDefSet.OptionPringDivCd = svWork.OptionPringDivCd;
                                this._estimateDefSet.PartsNoPrtCd = svWork.PartsNoPrtCd;
                                this._estimateDefSet.PartsSearchDivCd = svWork.PartsSearchDivCd;
                                this._estimateDefSet.PartsSelectDivCd = svWork.PartsSelectDivCd;
                                this._estimateDefSet.RateUseCode = svWork.RateUseCode;
                                this._estimateDefSet.SectionCode = svWork.SectionCode;
                                this._estimateDefSet.UpdAssemblyId1 = svWork.UpdAssemblyId1;
                                this._estimateDefSet.UpdAssemblyId2 = svWork.UpdAssemblyId2;
                                this._estimateDefSet.UpdateDateTime = svWork.UpdateDateTime;
                                this._estimateDefSet.UpdEmployeeCode = svWork.UpdEmployeeCode;
                                #endregion
                            }
                            #endregion

                            #region �d���݌ɑS��
                            if (arList[0] is StockTtlStWork)
                            {
                                this._stockTtlSt = new StockTtlSt();
                                StockTtlStWork svWork = new StockTtlStWork();
                                foreach (StockTtlStWork work in arList)
                                {
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == sectionCode.Trim()))
                                    {
                                        svWork = work;
                                        break;
                                    }
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == ctSectionCode.Trim()))
                                    {
                                        svWork = work;
                                    }
                                }
                                #region ���ڃZ�b�g
                                this._stockTtlSt.AutoEntryGoodsDivCd = svWork.AutoEntryGoodsDivCd;
                                this._stockTtlSt.AutoPayment = svWork.AutoPayment;
                                this._stockTtlSt.AutoPayMoneyKindCode = svWork.AutoPayMoneyKindCode;
                                this._stockTtlSt.AutoPayMoneyKindDiv = svWork.AutoPayMoneyKindDiv;
                                this._stockTtlSt.AutoPayMoneyKindName = svWork.AutoPayMoneyKindName;
                                this._stockTtlSt.CreateDateTime = svWork.CreateDateTime;
                                this._stockTtlSt.DtlNoteDispDiv = svWork.DtlNoteDispDiv;
                                this._stockTtlSt.EnterpriseCode = svWork.EnterpriseCode;
                                this._stockTtlSt.FileHeaderGuid = svWork.FileHeaderGuid;
                                this._stockTtlSt.GoodsNmReDispDivCd = svWork.GoodsNmReDispDivCd;
                                this._stockTtlSt.ListPriceInpDiv = svWork.ListPriceInpDiv;
                                this._stockTtlSt.LogicalDeleteCode = svWork.LogicalDeleteCode;
                                this._stockTtlSt.PaySlipDateAmbit = svWork.PaySlipDateAmbit;
                                this._stockTtlSt.PaySlipDateClrDiv = svWork.PaySlipDateClrDiv;
                                this._stockTtlSt.PriceCheckDivCd = svWork.PriceCheckDivCd;
                                this._stockTtlSt.PriceCostUpdtDiv = svWork.PriceCostUpdtDiv;
                                this._stockTtlSt.RgdsSlipPrtDiv = svWork.RgdsSlipPrtDiv;
                                this._stockTtlSt.RgdsUnPrcPrtDiv = svWork.RgdsUnPrcPrtDiv;
                                this._stockTtlSt.RgdsZeroPrtDiv = svWork.RgdsZeroPrtDiv;
                                this._stockTtlSt.SectDspDivCd = svWork.SectDspDivCd;
                                this._stockTtlSt.SectionCode = svWork.SectionCode;
                                this._stockTtlSt.SlipDateClrDivCd = svWork.SlipDateClrDivCd;
                                this._stockTtlSt.StockDiscountName = svWork.StockDiscountName;
                                this._stockTtlSt.StockSearchDiv = svWork.StockSearchDiv;
                                this._stockTtlSt.StockUnitChgDivCd = svWork.StockUnitChgDivCd;
                                this._stockTtlSt.UnitPriceInpDiv = svWork.UnitPriceInpDiv;
                                this._stockTtlSt.UpdAssemblyId1 = svWork.UpdAssemblyId1;
                                this._stockTtlSt.UpdAssemblyId2 = svWork.UpdAssemblyId2;
                                this._stockTtlSt.UpdateDateTime = svWork.UpdateDateTime;
                                this._stockTtlSt.UpdEmployeeCode = svWork.UpdEmployeeCode;
                                #endregion
                            }
                            #endregion

                            #region �S�̏����l
                            if (arList[0] is AllDefSetWork)
                            {
                                this._allDefSet = new AllDefSet();
                                AllDefSetWork svWork = new AllDefSetWork();
                                foreach (AllDefSetWork work in arList)
                                {
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == sectionCode.Trim()))
                                    {
                                        svWork = work;
                                        break;
                                    }
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == ctSectionCode.Trim()))
                                    {
                                        svWork = work;
                                    }
                                }
                                #region ���ڃZ�b�g
                                this._allDefSet.CnsTaxAutoCorrDiv = svWork.CnsTaxAutoCorrDiv;
                                this._allDefSet.CreateDateTime = svWork.CreateDateTime;
                                this._allDefSet.DefDspBillPrtDivCd = svWork.DefDspBillPrtDivCd;
                                this._allDefSet.DefDspClctMnyMonthCd = svWork.DefDspClctMnyMonthCd;
                                this._allDefSet.DefDspCustClctMnyDay = svWork.DefDspCustClctMnyDay;
                                this._allDefSet.DefDspCustTtlDay = svWork.DefDspCustTtlDay;
                                this._allDefSet.DefDtlBillOutput = svWork.DefDtlBillOutput;
                                this._allDefSet.DefSlTtlBillOutput = svWork.DefSlTtlBillOutput;
                                this._allDefSet.DefTtlBillOutput = svWork.DefTtlBillOutput;
                                this._allDefSet.EnterpriseCode = svWork.EnterpriseCode;
                                this._allDefSet.EraNameDispCd1 = svWork.EraNameDispCd1;
                                this._allDefSet.EraNameDispCd2 = svWork.EraNameDispCd2;
                                this._allDefSet.EraNameDispCd3 = svWork.EraNameDispCd3;
                                this._allDefSet.FileHeaderGuid = svWork.FileHeaderGuid;
                                this._allDefSet.GoodsNoInpDiv = svWork.GoodsNoInpDiv;
                                this._allDefSet.IniDspPrslOrCorpCd = svWork.IniDspPrslOrCorpCd;
                                this._allDefSet.InitDspDmDiv = svWork.InitDspDmDiv;
                                this._allDefSet.LogicalDeleteCode = svWork.LogicalDeleteCode;
                                this._allDefSet.MemoMoveDiv = svWork.MemoMoveDiv;
                                this._allDefSet.RemainCntMngDiv = svWork.RemainCntMngDiv;
                                this._allDefSet.RemCntAutoDspDiv = svWork.RemCntAutoDspDiv;
                                this._allDefSet.SectionCode = svWork.SectionCode;
                                this._allDefSet.TotalAmountDispWayCd = svWork.TotalAmountDispWayCd;
                                this._allDefSet.TtlAmntDspRateDivCd = svWork.TtlAmntDspRateDivCd;
                                this._allDefSet.UpdAssemblyId1 = svWork.UpdAssemblyId1;
                                this._allDefSet.UpdAssemblyId2 = svWork.UpdAssemblyId2;
                                this._allDefSet.UpdateDateTime = svWork.UpdateDateTime;
                                this._allDefSet.UpdEmployeeCode = svWork.UpdEmployeeCode;
                                this._allDefSet.DtlCalcStckCntDsp = svWork.DtlCalcStckCntDsp;  // ADD 2011/07/20
                                #endregion
                            }
                            #endregion

                            #region ���Џ��
                            if (arList[0] is CompanyInfWork)
                            {
                                this._companyInf = new CompanyInf();
                                CompanyInfWork svWork = new CompanyInfWork();
                                svWork = (CompanyInfWork)arList[0];

                                #region ���ڃZ�b�g
                                this._companyInf.Address1 = svWork.Address1;
                                this._companyInf.Address3 = svWork.Address3;
                                this._companyInf.Address4 = svWork.Address4;
                                this._companyInf.CompanyBiginDate = svWork.CompanyBiginDate;
                                this._companyInf.CompanyBiginMonth = svWork.CompanyBiginMonth;
                                this._companyInf.CompanyBiginMonth2 = svWork.CompanyBiginMonth2;
                                this._companyInf.CompanyCode = svWork.CompanyCode;
                                this._companyInf.CompanyName1 = svWork.CompanyName1;
                                this._companyInf.CompanyName2 = svWork.CompanyName2;
                                this._companyInf.CompanyTelNo1 = svWork.CompanyTelNo1;
                                this._companyInf.CompanyTelNo2 = svWork.CompanyTelNo2;
                                this._companyInf.CompanyTelNo3 = svWork.CompanyTelNo3;
                                this._companyInf.CompanyTelTitle1 = svWork.CompanyTelTitle1;
                                this._companyInf.CompanyTelTitle2 = svWork.CompanyTelTitle2;
                                this._companyInf.CompanyTelTitle3 = svWork.CompanyTelTitle3;
                                this._companyInf.CompanyTotalDay = svWork.CompanyTotalDay;
                                this._companyInf.CreateDateTime = svWork.CreateDateTime;
                                this._companyInf.EnterpriseCode = svWork.EnterpriseCode;
                                this._companyInf.FileHeaderGuid = svWork.FileHeaderGuid;
                                this._companyInf.FinancialYear = svWork.FinancialYear;
                                this._companyInf.LogicalDeleteCode = svWork.LogicalDeleteCode;
                                this._companyInf.PostNo = svWork.PostNo;
                                this._companyInf.SecMngDiv = svWork.SecMngDiv;
                                this._companyInf.StartMonthDiv = svWork.StartMonthDiv;
                                this._companyInf.StartYearDiv = svWork.StartYearDiv;
                                this._companyInf.UpdAssemblyId1 = svWork.UpdAssemblyId1;
                                this._companyInf.UpdAssemblyId2 = svWork.UpdAssemblyId2;
                                this._companyInf.UpdateDateTime = svWork.UpdateDateTime;
                                this._companyInf.UpdEmployeeCode = svWork.UpdEmployeeCode;
                                this._companyInf.RatePriorityDiv = svWork.RatePriorityDiv;  // ADD 2011/07/25
                                #endregion
                            }
                            #endregion

                            #region �`�[����ݒ�}�X�^
                            if (arList[0] is SlipPrtSetWork)
                            {
                                foreach (SlipPrtSetWork work in arList)
                                {
                                    SlipPrtSet slipPrtSet = new SlipPrtSet();

                                    #region ���ڃZ�b�g
                                    slipPrtSet.CreateDateTime = work.CreateDateTime; // �쐬����
                                    slipPrtSet.UpdateDateTime = work.UpdateDateTime; // �X�V����
                                    slipPrtSet.EnterpriseCode = work.EnterpriseCode; // ��ƃR�[�h
                                    slipPrtSet.FileHeaderGuid = work.FileHeaderGuid; // GUID
                                    slipPrtSet.UpdEmployeeCode = work.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                                    slipPrtSet.UpdAssemblyId1 = work.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                                    slipPrtSet.UpdAssemblyId2 = work.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                                    slipPrtSet.LogicalDeleteCode = work.LogicalDeleteCode; // �_���폜�敪
                                    slipPrtSet.DataInputSystem = work.DataInputSystem; // �f�[�^���̓V�X�e��
                                    slipPrtSet.SlipPrtKind = work.SlipPrtKind; // �`�[������
                                    slipPrtSet.SlipPrtSetPaperId = work.SlipPrtSetPaperId; // �`�[����ݒ�p���[ID
                                    slipPrtSet.SlipComment = work.SlipComment; // �`�[�R�����g
                                    slipPrtSet.OutputPgId = work.OutputPgId; // �o�̓v���O����ID
                                    slipPrtSet.OutputPgClassId = work.OutputPgClassId; // �o�̓v���O�����N���XID
                                    slipPrtSet.OutputFormFileName = work.OutputFormFileName; // �o�̓t�@�C����
                                    slipPrtSet.EnterpriseNamePrtCd = work.EnterpriseNamePrtCd; // ���Ж�����敪
                                    slipPrtSet.PrtCirculation = work.PrtCirculation; // �������
                                    slipPrtSet.SlipFormCd = work.SlipFormCd; // �`�[�p���敪
                                    slipPrtSet.OutConfimationMsg = work.OutConfimationMsg; // �o�͊m�F���b�Z�[�W
                                    slipPrtSet.OptionCode = work.OptionCode; // �I�v�V�����R�[�h
                                    slipPrtSet.TopMargin = work.TopMargin; // ��]��
                                    slipPrtSet.LeftMargin = work.LeftMargin; // ���]��
                                    slipPrtSet.RightMargin = work.RightMargin; // �E�]��
                                    slipPrtSet.BottomMargin = work.BottomMargin; // ���]��
                                    slipPrtSet.PrtPreviewExistCode = work.PrtPreviewExistCode; // ����v���r���L���敪
                                    slipPrtSet.OutputPurpose = work.OutputPurpose; // �o�͗p�r
                                    slipPrtSet.EachSlipTypeColId1 = work.EachSlipTypeColId1; // �`�[�^�C�v�ʗ�ID1
                                    slipPrtSet.EachSlipTypeColNm1 = work.EachSlipTypeColNm1; // �`�[�^�C�v�ʗ񖼏�
                                    slipPrtSet.EachSlipTypeColPrt1 = work.EachSlipTypeColPrt1; // �`�[�^�C�v�ʗ�󎚋敪
                                    slipPrtSet.EachSlipTypeColId2 = work.EachSlipTypeColId2; // �`�[�^�C�v�ʗ�ID2
                                    slipPrtSet.EachSlipTypeColNm2 = work.EachSlipTypeColNm2; // �`�[�^�C�v�ʗ񖼏�
                                    slipPrtSet.EachSlipTypeColPrt2 = work.EachSlipTypeColPrt2; // �`�[�^�C�v�ʗ�󎚋敪
                                    slipPrtSet.EachSlipTypeColId3 = work.EachSlipTypeColId3; // �`�[�^�C�v�ʗ�ID3
                                    slipPrtSet.EachSlipTypeColNm3 = work.EachSlipTypeColNm3; // �`�[�^�C�v�ʗ񖼏�
                                    slipPrtSet.EachSlipTypeColPrt3 = work.EachSlipTypeColPrt3; // �`�[�^�C�v�ʗ�󎚋敪
                                    slipPrtSet.EachSlipTypeColId4 = work.EachSlipTypeColId4; // �`�[�^�C�v�ʗ�ID4
                                    slipPrtSet.EachSlipTypeColNm4 = work.EachSlipTypeColNm4; // �`�[�^�C�v�ʗ񖼏�
                                    slipPrtSet.EachSlipTypeColPrt4 = work.EachSlipTypeColPrt4; // �`�[�^�C�v�ʗ�󎚋敪
                                    slipPrtSet.EachSlipTypeColId5 = work.EachSlipTypeColId5; // �`�[�^�C�v�ʗ�ID5
                                    slipPrtSet.EachSlipTypeColNm5 = work.EachSlipTypeColNm5; // �`�[�^�C�v�ʗ񖼏�
                                    slipPrtSet.EachSlipTypeColPrt5 = work.EachSlipTypeColPrt5; // �`�[�^�C�v�ʗ�󎚋敪
                                    slipPrtSet.EachSlipTypeColId6 = work.EachSlipTypeColId6; // �`�[�^�C�v�ʗ�ID6
                                    slipPrtSet.EachSlipTypeColNm6 = work.EachSlipTypeColNm6; // �`�[�^�C�v�ʗ񖼏�
                                    slipPrtSet.EachSlipTypeColPrt6 = work.EachSlipTypeColPrt6; // �`�[�^�C�v�ʗ�󎚋敪
                                    slipPrtSet.EachSlipTypeColId7 = work.EachSlipTypeColId7; // �`�[�^�C�v�ʗ�ID7
                                    slipPrtSet.EachSlipTypeColNm7 = work.EachSlipTypeColNm7; // �`�[�^�C�v�ʗ񖼏�
                                    slipPrtSet.EachSlipTypeColPrt7 = work.EachSlipTypeColPrt7; // �`�[�^�C�v�ʗ�󎚋敪
                                    slipPrtSet.EachSlipTypeColId8 = work.EachSlipTypeColId8; // �`�[�^�C�v�ʗ�ID8
                                    slipPrtSet.EachSlipTypeColNm8 = work.EachSlipTypeColNm8; // �`�[�^�C�v�ʗ񖼏�
                                    slipPrtSet.EachSlipTypeColPrt8 = work.EachSlipTypeColPrt8; // �`�[�^�C�v�ʗ�󎚋敪
                                    slipPrtSet.EachSlipTypeColId9 = work.EachSlipTypeColId9; // �`�[�^�C�v�ʗ�ID9
                                    slipPrtSet.EachSlipTypeColNm9 = work.EachSlipTypeColNm9; // �`�[�^�C�v�ʗ񖼏�
                                    slipPrtSet.EachSlipTypeColPrt9 = work.EachSlipTypeColPrt9; // �`�[�^�C�v�ʗ�󎚋敪
                                    slipPrtSet.EachSlipTypeColId10 = work.EachSlipTypeColId10; // �`�[�^�C�v�ʗ�ID10
                                    slipPrtSet.EachSlipTypeColNm10 = work.EachSlipTypeColNm10; // �`�[�^�C�v�ʗ񖼏�
                                    slipPrtSet.EachSlipTypeColPrt10 = work.EachSlipTypeColPrt10; // �`�[�^�C�v�ʗ�󎚋敪
                                    slipPrtSet.SlipFontName = work.SlipFontName; // �`�[�t�H���g����
                                    slipPrtSet.SlipFontSize = work.SlipFontSize; // �`�[�t�H���g�T�C�Y
                                    slipPrtSet.SlipFontStyle = work.SlipFontStyle; // �`�[�t�H���g�X�^�C��
                                    slipPrtSet.SlipBaseColorRed1 = work.SlipBaseColorRed1; // �`�[��F��
                                    slipPrtSet.SlipBaseColorGrn1 = work.SlipBaseColorGrn1; // �`�[��F��
                                    slipPrtSet.SlipBaseColorBlu1 = work.SlipBaseColorBlu1; // �`�[��F��
                                    slipPrtSet.SlipBaseColorRed2 = work.SlipBaseColorRed2; // �`�[��F��
                                    slipPrtSet.SlipBaseColorGrn2 = work.SlipBaseColorGrn2; // �`�[��F��
                                    slipPrtSet.SlipBaseColorBlu2 = work.SlipBaseColorBlu2; // �`�[��F��
                                    slipPrtSet.SlipBaseColorRed3 = work.SlipBaseColorRed3; // �`�[��F��
                                    slipPrtSet.SlipBaseColorGrn3 = work.SlipBaseColorGrn3; // �`�[��F��
                                    slipPrtSet.SlipBaseColorBlu3 = work.SlipBaseColorBlu3; // �`�[��F��
                                    slipPrtSet.SlipBaseColorRed4 = work.SlipBaseColorRed4; // �`�[��F��
                                    slipPrtSet.SlipBaseColorGrn4 = work.SlipBaseColorGrn4; // �`�[��F��
                                    slipPrtSet.SlipBaseColorBlu4 = work.SlipBaseColorBlu4; // �`�[��F��
                                    slipPrtSet.SlipBaseColorRed5 = work.SlipBaseColorRed5; // �`�[��F��
                                    slipPrtSet.SlipBaseColorGrn5 = work.SlipBaseColorGrn5; // �`�[��F��
                                    slipPrtSet.SlipBaseColorBlu5 = work.SlipBaseColorBlu5; // �`�[��F��
                                    slipPrtSet.CopyCount = work.CopyCount; // ���ʖ���
                                    slipPrtSet.TitleName1 = work.TitleName1; // �^�C�g��
                                    slipPrtSet.TitleName2 = work.TitleName2; // �^�C�g��
                                    slipPrtSet.TitleName3 = work.TitleName3; // �^�C�g��
                                    slipPrtSet.TitleName4 = work.TitleName4; // �^�C�g��
                                    slipPrtSet.SpecialPurpose1 = work.SpecialPurpose1; // ����p�r
                                    slipPrtSet.SpecialPurpose2 = work.SpecialPurpose2; // ����p�r
                                    slipPrtSet.SpecialPurpose3 = work.SpecialPurpose3; // ����p�r
                                    slipPrtSet.SpecialPurpose4 = work.SpecialPurpose4; // ����p�r
                                    slipPrtSet.TitleName102 = work.TitleName102; // �^�C�g��-2
                                    slipPrtSet.TitleName103 = work.TitleName103; // �^�C�g��-3
                                    slipPrtSet.TitleName104 = work.TitleName104; // �^�C�g��-4
                                    slipPrtSet.TitleName105 = work.TitleName105; // �^�C�g��-5
                                    slipPrtSet.TitleName202 = work.TitleName202; // �^�C�g��-2
                                    slipPrtSet.TitleName203 = work.TitleName203; // �^�C�g��-3
                                    slipPrtSet.TitleName204 = work.TitleName204; // �^�C�g��-4
                                    slipPrtSet.TitleName205 = work.TitleName205; // �^�C�g��-5
                                    slipPrtSet.TitleName302 = work.TitleName302; // �^�C�g��-2
                                    slipPrtSet.TitleName303 = work.TitleName303; // �^�C�g��-3
                                    slipPrtSet.TitleName304 = work.TitleName304; // �^�C�g��-4
                                    slipPrtSet.TitleName305 = work.TitleName305; // �^�C�g��-5
                                    slipPrtSet.TitleName402 = work.TitleName402; // �^�C�g��-2
                                    slipPrtSet.TitleName403 = work.TitleName403; // �^�C�g��-3
                                    slipPrtSet.TitleName404 = work.TitleName404; // �^�C�g��-4
                                    slipPrtSet.TitleName405 = work.TitleName405; // �^�C�g��-5
                                    slipPrtSet.Note1 = work.Note1; // ���l
                                    slipPrtSet.Note2 = work.Note2; // ���l
                                    slipPrtSet.Note3 = work.Note3; // ���l
                                    slipPrtSet.QRCodePrintDivCd = work.QRCodePrintDivCd; // QR�R�[�h�󎚋敪
                                    slipPrtSet.TimePrintDivCd = work.TimePrintDivCd; // �����󎚋敪
                                    slipPrtSet.ReissueMark = work.ReissueMark; // �Ĕ��s�}�[�N
                                    slipPrtSet.RefConsTaxDivCd = work.RefConsTaxDivCd; // �Q�l����ŋ敪
                                    slipPrtSet.RefConsTaxPrtNm = work.RefConsTaxPrtNm; // �Q�l����ň󎚖���
                                    slipPrtSet.DetailRowCount = work.DetailRowCount; // ���׍s��
                                    slipPrtSet.HonorificTitle = work.HonorificTitle; // �h��
                                    slipPrtSet.ConsTaxPrtCd = work.ConsTaxPrtCd; // ����ň󎚋敪
                                    slipPrtSet.SlipNoteCharCnt = work.SlipNoteCharCnt; // �`�[���l����
                                    slipPrtSet.SlipNote2CharCnt = work.SlipNote2CharCnt; // �`�[���l�Q����
                                    slipPrtSet.SlipNote3CharCnt = work.SlipNote3CharCnt; // �`�[���l�R����
                                    //-------ADD 2011/07/19 ------->>>>>>>
                                    slipPrtSet.SCMAnsMarkPrtDiv = work.SCMAnsMarkPrtDiv; // SCM�񓚃}�[�N�󎚋敪
                                    slipPrtSet.NormalPrtMark = work.NormalPrtMark; // �ʏ픭�s�}�[�N
                                    slipPrtSet.SCMAutoAnsMark = work.SCMAutoAnsMark; // SCM�蓮�񓚃}�[�N
                                    slipPrtSet.SCMManualAnsMark = work.SCMManualAnsMark; // SCM�����񓚃}�[�N
                                    //-------ADD 2011/07/19 -------<<<<<<<
                                    #endregion

                                    this._slipPrtSetList.Add(slipPrtSet);
                                }
                            }
                            #endregion

                            #region ���Ӑ�}�X�^(�`�[�Ǘ�)
                            if (arList[0] is CustSlipMngWork)
                            {
                                foreach (CustSlipMngWork work in arList)
                                {
                                    CustSlipMng custSlipMng = new CustSlipMng();

                                    #region ���ڃZ�b�g
                                    custSlipMng.CreateDateTime = work.CreateDateTime; // �쐬����
                                    custSlipMng.UpdateDateTime = work.UpdateDateTime; // �X�V����
                                    custSlipMng.EnterpriseCode = work.EnterpriseCode; // ��ƃR�[�h
                                    custSlipMng.FileHeaderGuid = work.FileHeaderGuid; // GUID
                                    custSlipMng.UpdEmployeeCode = work.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                                    custSlipMng.UpdAssemblyId1 = work.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                                    custSlipMng.UpdAssemblyId2 = work.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                                    custSlipMng.LogicalDeleteCode = work.LogicalDeleteCode; // �_���폜�敪
                                    custSlipMng.DataInputSystem = work.DataInputSystem; // �f�[�^���̓V�X�e��
                                    custSlipMng.SlipPrtKind = work.SlipPrtKind; // �`�[������
                                    custSlipMng.SectionCode = work.SectionCode; // ���_�R�[�h
                                    custSlipMng.CustomerCode = work.CustomerCode; // ���Ӑ�R�[�h
                                    custSlipMng.SlipPrtSetPaperId = work.SlipPrtSetPaperId; // �`�[����ݒ�p���[ID
                                    #endregion

                                    this._custSlipMngList.Add(custSlipMng);
                                }
                            }
                            #endregion

                            #region UOE�K�C�h���̃}�X�^
                            if (arList[0] is UOEGuideNameWork)
                            {
                                foreach (UOEGuideNameWork work in arList)
                                {
                                    UOEGuideName uoeGuideName = new UOEGuideName();

                                    #region ���ڃZ�b�g
                                    uoeGuideName.CreateDateTime = work.CreateDateTime; // �쐬����
                                    uoeGuideName.UpdateDateTime = work.UpdateDateTime; // �X�V����
                                    uoeGuideName.EnterpriseCode = work.EnterpriseCode; // ��ƃR�[�h
                                    uoeGuideName.FileHeaderGuid = work.FileHeaderGuid; // GUID
                                    uoeGuideName.UpdEmployeeCode = work.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                                    uoeGuideName.UpdAssemblyId1 = work.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                                    uoeGuideName.UpdAssemblyId2 = work.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                                    uoeGuideName.LogicalDeleteCode = work.LogicalDeleteCode; // �_���폜�敪
                                    uoeGuideName.SectionCode = work.SectionCode; // ���_�R�[�h
                                    uoeGuideName.UOEGuideDivCd = work.UOEGuideDivCd; // UOE�K�C�h�敪
                                    uoeGuideName.UOESupplierCd = work.UOESupplierCd; // UOE������R�[�h
                                    uoeGuideName.UOEGuideCode = work.UOEGuideCode; // UOE�K�C�h�R�[�h
                                    uoeGuideName.UOEGuideNm = work.UOEGuideName; // UOE�K�C�h����
                                    #endregion

                                    this._uoeGuideNameList.Add(uoeGuideName);
                                }
                            }
                            #endregion

                            #region ����
                            if (arList[0] is SubSectionWork)
                            {
                                foreach (SubSectionWork work in arList)
                                {
                                    SubSection subSection = new SubSection();
                                    subSection.CreateDateTime = work.CreateDateTime;
                                    subSection.EnterpriseCode = work.EnterpriseCode;
                                    subSection.FileHeaderGuid = work.FileHeaderGuid;
                                    subSection.LogicalDeleteCode = work.LogicalDeleteCode;
                                    subSection.SectionCode = work.SectionCode;
                                    subSection.SubSectionCode = work.SubSectionCode;
                                    subSection.SubSectionName = work.SubSectionName;
                                    subSection.UpdAssemblyId1 = work.UpdAssemblyId1;
                                    subSection.UpdAssemblyId2 = work.UpdAssemblyId2;
                                    subSection.UpdateDateTime = work.UpdateDateTime;
                                    subSection.UpdEmployeeCode = work.UpdEmployeeCode;
                                    this._subSectionList.Add(subSection);
                                }
                            }
                            #endregion

                            #region �|���D��Ǘ��}�X�^
                            if (arList[0] is RateProtyMngWork)
                            {
                                foreach (RateProtyMngWork work in arList)
                                {
                                    RateProtyMng rateProtyMng = new RateProtyMng();
                                    rateProtyMng.CreateDateTime = work.CreateDateTime;
                                    rateProtyMng.EnterpriseCode = work.EnterpriseCode;
                                    rateProtyMng.FileHeaderGuid = work.FileHeaderGuid;
                                    rateProtyMng.LogicalDeleteCode = work.LogicalDeleteCode;
                                    rateProtyMng.RateMngCustCd = work.RateMngCustCd;
                                    rateProtyMng.RateMngCustNm = work.RateMngCustNm;
                                    rateProtyMng.RateMngGoodsCd = work.RateMngGoodsCd;
                                    rateProtyMng.RateMngGoodsNm = work.RateMngGoodsNm;
                                    rateProtyMng.RatePriorityOrder = work.RatePriorityOrder;
                                    rateProtyMng.RateSettingDivide = work.RateSettingDivide;
                                    rateProtyMng.SectionCode = work.SectionCode;
                                    rateProtyMng.UnitPriceKind = work.UnitPriceKind;
                                    rateProtyMng.UpdAssemblyId1 = work.UpdAssemblyId1;
                                    rateProtyMng.UpdAssemblyId2 = work.UpdAssemblyId2;
                                    rateProtyMng.UpdateDateTime = work.UpdateDateTime;
                                    rateProtyMng.UpdEmployeeCode = work.UpdEmployeeCode;
                                    this._rateProtyMngList.Add(rateProtyMng);
                                }

                                this.CacheRateProtyMngListCall();
                            }
                            #endregion

                            #region ������z�����敪�}�X�^
                            if (arList[0] is SalesProcMoneyWork)
                            {
                                foreach (SalesProcMoneyWork work in arList)
                                {
                                    SalesProcMoney salesProcMoney = new SalesProcMoney();
                                    salesProcMoney.CreateDateTime = work.CreateDateTime;
                                    salesProcMoney.EnterpriseCode = work.EnterpriseCode;
                                    salesProcMoney.FileHeaderGuid = work.FileHeaderGuid;
                                    salesProcMoney.FracProcMoneyDiv = work.FracProcMoneyDiv;
                                    salesProcMoney.FractionProcCd = work.FractionProcCd;
                                    salesProcMoney.FractionProcCode = work.FractionProcCode;
                                    salesProcMoney.FractionProcUnit = work.FractionProcUnit;
                                    salesProcMoney.LogicalDeleteCode = work.LogicalDeleteCode;
                                    salesProcMoney.UpdAssemblyId1 = work.UpdAssemblyId1;
                                    salesProcMoney.UpdAssemblyId2 = work.UpdAssemblyId2;
                                    salesProcMoney.UpdateDateTime = work.UpdateDateTime;
                                    salesProcMoney.UpdEmployeeCode = work.UpdEmployeeCode;
                                    salesProcMoney.UpperLimitPrice = work.UpperLimitPrice;
                                    this._salesProcMoneyList.Add(salesProcMoney);
                                }

                                this.CacheSalesProcMoneyListCall();
                            }
                            #endregion

                            #region �d�����z�����敪�}�X�^
                            if (arList[0] is StockProcMoneyWork)
                            {
                                foreach (StockProcMoneyWork work in arList)
                                {
                                    StockProcMoney stockProcMoney = new StockProcMoney();
                                    stockProcMoney.CreateDateTime = work.CreateDateTime;
                                    stockProcMoney.EnterpriseCode = work.EnterpriseCode;
                                    stockProcMoney.FileHeaderGuid = work.FileHeaderGuid;
                                    stockProcMoney.FracProcMoneyDiv = work.FracProcMoneyDiv;
                                    stockProcMoney.FractionProcCd = work.FractionProcCd;
                                    stockProcMoney.FractionProcCode = work.FractionProcCode;
                                    stockProcMoney.FractionProcUnit = work.FractionProcUnit;
                                    stockProcMoney.LogicalDeleteCode = work.LogicalDeleteCode;
                                    stockProcMoney.UpdAssemblyId1 = work.UpdAssemblyId1;
                                    stockProcMoney.UpdAssemblyId2 = work.UpdAssemblyId2;
                                    stockProcMoney.UpdateDateTime = work.UpdateDateTime;
                                    stockProcMoney.UpdEmployeeCode = work.UpdEmployeeCode;
                                    stockProcMoney.UpperLimitPrice = work.UpperLimitPrice;
                                    this._stockProcMoneyList.Add(stockProcMoney);
                                }

                                this.CacheStockProcMoneyListCall();
                            }
                            #endregion

                            #region ���[�U�[�K�C�h
                            if (arList[0] is UserGdBdUWork)
                            {
                                foreach (UserGdBdUWork work in arList)
                                {
                                    UserGdBd userGdBd = new UserGdBd();
                                    userGdBd.CreateDateTime = work.CreateDateTime;
                                    userGdBd.EnterpriseCode = work.EnterpriseCode;
                                    userGdBd.FileHeaderGuid = work.FileHeaderGuid;
                                    userGdBd.GuideCode = work.GuideCode;
                                    userGdBd.GuideName = work.GuideName;
                                    userGdBd.GuideType = work.GuideType;
                                    userGdBd.LogicalDeleteCode = work.LogicalDeleteCode;
                                    userGdBd.UpdAssemblyId1 = work.UpdAssemblyId1;
                                    userGdBd.UpdAssemblyId2 = work.UpdAssemblyId2;
                                    userGdBd.UpdateDateTime = work.UpdateDateTime;
                                    userGdBd.UpdEmployeeCode = work.UpdEmployeeCode;
                                    userGdBd.UserGuideDivCd = work.UserGuideDivCd;
                                    this._userGdBdList.Add(userGdBd);
                                }
                            }
                            #endregion

                            //>>>2010/05/30
                            #region SCM�S�̐ݒ�
                            if (arList[0] is SCMTtlStWork)
                            {
                                SCMTtlStWork work = this.GetScmTtlStFromList(sectionCode, arList);
                                SCMTtlSt scmTtlSt = new SCMTtlSt();
                                scmTtlSt.AcpOdrrSlipPrtDiv = work.AcpOdrrSlipPrtDiv;
                                scmTtlSt.AutoAnswerDiv = work.AutoAnswerDiv;
                                scmTtlSt.AutoCooperatDis = work.AutoCooperatDis;
                                scmTtlSt.BLCodeChgDiv = work.BLCodeChgDiv;
                                scmTtlSt.CreateDateTime = work.CreateDateTime;
                                scmTtlSt.DiscountApplyCd = work.DiscountApplyCd;
                                scmTtlSt.EnterpriseCode = work.EnterpriseCode;
                                scmTtlSt.EstimatePrtDiv = work.EstimatePrtDiv;
                                scmTtlSt.FileHeaderGuid = work.FileHeaderGuid;
                                scmTtlSt.LogicalDeleteCode = work.LogicalDeleteCode;
                                scmTtlSt.OldSysCooperatDiv = work.OldSysCooperatDiv;
                                scmTtlSt.OldSysCoopFolder = work.OldSysCoopFolder;
                                scmTtlSt.SalesSlipPrtDiv = work.SalesSlipPrtDiv;
                                scmTtlSt.SectionCode = work.SectionCode;
                                scmTtlSt.UpdAssemblyId1 = work.UpdAssemblyId1;
                                scmTtlSt.UpdAssemblyId2 = work.UpdAssemblyId2;
                                scmTtlSt.UpdateDateTime = work.UpdateDateTime;
                                scmTtlSt.UpdEmployeeCode = work.UpdEmployeeCode;
                                scmTtlSt.FuwioutAutoAnsDiv = work.FuwioutAutoAnsDiv;// ADD 2014/07/23 Redmine#43080��3SCM�󔭒����׃f�[�^�ɍ݌ɏ󋵋敪�̃Z�b�g
                                this._scmTtlSt = scmTtlSt;
                            }
                            #endregion

                            #region SCM�[���ݒ�}�X�^
                            if (arList[0] is SCMDeliDateStWork)
                            {
                                foreach (SCMDeliDateStWork work in arList)
                                {
                                    SCMDeliDateSt scmDeliDateSt = new SCMDeliDateSt();
                                    scmDeliDateSt.AnswerDeadTime1 = work.AnswerDeadTime1;
                                    scmDeliDateSt.AnswerDeadTime2 = work.AnswerDeadTime2;
                                    scmDeliDateSt.AnswerDeadTime3 = work.AnswerDeadTime3;
                                    scmDeliDateSt.AnswerDeadTime4 = work.AnswerDeadTime4;
                                    scmDeliDateSt.AnswerDeadTime5 = work.AnswerDeadTime5;
                                    scmDeliDateSt.AnswerDeadTime6 = work.AnswerDeadTime6;
                                    scmDeliDateSt.AnswerDelivDate1 = work.AnswerDelivDate1;
                                    scmDeliDateSt.AnswerDelivDate2 = work.AnswerDelivDate2;
                                    scmDeliDateSt.AnswerDelivDate3 = work.AnswerDelivDate3;
                                    scmDeliDateSt.AnswerDelivDate4 = work.AnswerDelivDate4;
                                    scmDeliDateSt.AnswerDelivDate5 = work.AnswerDelivDate5;
                                    scmDeliDateSt.AnswerDelivDate6 = work.AnswerDelivDate6;
                                    scmDeliDateSt.CreateDateTime = work.CreateDateTime;
                                    scmDeliDateSt.CustomerCode = work.CustomerCode;
                                    scmDeliDateSt.EnterpriseCode = work.EnterpriseCode;
                                    scmDeliDateSt.FileHeaderGuid = work.FileHeaderGuid;
                                    scmDeliDateSt.LogicalDeleteCode = work.LogicalDeleteCode;
                                    scmDeliDateSt.SectionCode = work.SectionCode;
                                    scmDeliDateSt.UpdAssemblyId1 = work.UpdAssemblyId1;
                                    scmDeliDateSt.UpdAssemblyId2 = work.UpdAssemblyId2;
                                    scmDeliDateSt.UpdateDateTime = work.UpdateDateTime;
                                    scmDeliDateSt.UpdEmployeeCode = work.UpdEmployeeCode;
                                    // 2011/01/31 Add >>>
                                    scmDeliDateSt.AnswerDeadTime1Stc = work.AnswerDeadTime1Stc;
                                    scmDeliDateSt.AnswerDeadTime2Stc = work.AnswerDeadTime2Stc;
                                    scmDeliDateSt.AnswerDeadTime3Stc = work.AnswerDeadTime3Stc;
                                    scmDeliDateSt.AnswerDeadTime4Stc = work.AnswerDeadTime4Stc;
                                    scmDeliDateSt.AnswerDeadTime5Stc = work.AnswerDeadTime5Stc;
                                    scmDeliDateSt.AnswerDeadTime6Stc = work.AnswerDeadTime6Stc;
                                    scmDeliDateSt.AnswerDelivDate1Stc = work.AnswerDelivDate1Stc;
                                    scmDeliDateSt.AnswerDelivDate2Stc = work.AnswerDelivDate2Stc;
                                    scmDeliDateSt.AnswerDelivDate3Stc = work.AnswerDelivDate3Stc;
                                    scmDeliDateSt.AnswerDelivDate4Stc = work.AnswerDelivDate4Stc;
                                    scmDeliDateSt.AnswerDelivDate5Stc = work.AnswerDelivDate5Stc;
                                    scmDeliDateSt.AnswerDelivDate6Stc = work.AnswerDelivDate6Stc;
                                    scmDeliDateSt.EntStckAnsDeliDtDiv = work.EntStckAnsDeliDtDiv;
                                    scmDeliDateSt.EntStckAnsDeliDate = work.EntStckAnsDeliDate;
                                    // 2011/01/31 Add <<<
                                    // --- ADD 2012/09/13 �O�� 2012/10/17�z�M�� ��Q�ꗗ ��2 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                    scmDeliDateSt.PriStckAnsDeliDtDiv = work.PriStckAnsDeliDtDiv;   // �D��݌ɉ񓚔[���敪
                                    scmDeliDateSt.PriStckAnsDeliDate = work.PriStckAnsDeliDate;     // �D��݌ɉ񓚔[��
                                    scmDeliDateSt.AnsDelDatShortOfStc = work.AnsDelDatShortOfStc;   // �񓚔[���i�݌ɕs���j
                                    scmDeliDateSt.AnsDelDatWithoutStc = work.AnsDelDatWithoutStc;   // �񓚔[���i�݌ɐ������j
                                    scmDeliDateSt.EntStcAnsDelDatShort = work.EntStcAnsDelDatShort; // �ϑ��݌ɉ񓚔[���i�݌ɕs���j
                                    scmDeliDateSt.EntStcAnsDelDatWiout = work.EntStcAnsDelDatWiout; // �ϑ��݌ɉ񓚔[���i�݌ɐ������j
                                    scmDeliDateSt.PriStcAnsDelDatShort = work.PriStcAnsDelDatShort; // �Q�ƍ݌ɉ񓚔[���i�݌ɕs���j
                                    scmDeliDateSt.PriStcAnsDelDatWiout = work.PriStcAnsDelDatWiout; // �Q�ƍ݌ɉ񓚔[���i�݌ɐ������j
                                    // --- ADD 2012/09/13 �O�� 2012/10/17�z�M�� ��Q�ꗗ ��2 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                    // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                                    scmDeliDateSt.AnsDelDtDiv1 = work.AnsDelDtDiv1; //        �񓚔[���敪�P
                                    scmDeliDateSt.AnsDelDtDiv2 = work.AnsDelDtDiv2; //        �񓚔[���敪�Q
                                    scmDeliDateSt.AnsDelDtDiv3 = work.AnsDelDtDiv3; //        �񓚔[���敪�R
                                    scmDeliDateSt.AnsDelDtDiv4 = work.AnsDelDtDiv4; //        �񓚔[���敪�S
                                    scmDeliDateSt.AnsDelDtDiv5 = work.AnsDelDtDiv5; //        �񓚔[���敪�T
                                    scmDeliDateSt.AnsDelDtDiv6 = work.AnsDelDtDiv6; //        �񓚔[���敪�U
                                    scmDeliDateSt.AnsDelDtDiv1Stc = work.AnsDelDtDiv1Stc; //     �񓚔[���敪�P�i�݌Ɂj
                                    scmDeliDateSt.AnsDelDtDiv2Stc = work.AnsDelDtDiv2Stc; //     �񓚔[���敪�Q�i�݌Ɂj
                                    scmDeliDateSt.AnsDelDtDiv3Stc = work.AnsDelDtDiv3Stc; //     �񓚔[���敪�R�i�݌Ɂj
                                    scmDeliDateSt.AnsDelDtDiv4Stc = work.AnsDelDtDiv4Stc; //     �񓚔[���敪�S�i�݌Ɂj
                                    scmDeliDateSt.AnsDelDtDiv5Stc = work.AnsDelDtDiv5Stc; //     �񓚔[���敪�T�i�݌Ɂj
                                    scmDeliDateSt.AnsDelDtDiv6Stc = work.AnsDelDtDiv6Stc; //     �񓚔[���敪�U�i�݌Ɂj
                                    scmDeliDateSt.EntAnsDelDtStcDiv = work.EntAnsDelDtStcDiv; //    �ϑ��݌ɉ񓚔[���敪�i�݌Ɂj
                                    scmDeliDateSt.PriAnsDelDtStcDiv = work.PriAnsDelDtStcDiv; //    �D��݌ɉ񓚔[���敪�i�݌Ɂj
                                    scmDeliDateSt.AnsDelDtShoStcDiv = work.AnsDelDtShoStcDiv; //    �񓚔[���敪�i�݌ɕs���j
                                    scmDeliDateSt.AnsDelDtWioStcDiv = work.AnsDelDtWioStcDiv; //    �񓚔[���敪�i�݌ɐ������j
                                    scmDeliDateSt.EntAnsDelDtShoDiv = work.EntAnsDelDtShoDiv; //    �ϑ��݌ɉ񓚔[���敪�i�݌ɕs���j
                                    scmDeliDateSt.EntAnsDelDtWioDiv = work.EntAnsDelDtWioDiv; //    �ϑ��݌ɉ񓚔[���敪�i�݌ɐ������j
                                    scmDeliDateSt.PriAnsDelDtShoDiv = work.PriAnsDelDtShoDiv; //    �D��݌ɉ񓚔[���敪�i�݌ɕs���j
                                    scmDeliDateSt.PriAnsDelDtWioDiv = work.PriAnsDelDtWioDiv; //    �D��݌ɉ񓚔[���敪�i�݌ɐ������j
                                    // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                                    this._scmDeliDateStList.Add(scmDeliDateSt);
                                }
                            }
                            #endregion

                            // --- DEL 2010/06/26 ---------->>>>>
                            //#region BL�R�[�h�ϊ��}�X�^
                            //if (arList[0] is TbsPartsCdChgWork)
                            //{
                            //    this._tbsPartsCdChgWorkList = new List<TbsPartsCdChgWork>((TbsPartsCdChgWork[])arList.ToArray(typeof(TbsPartsCdChgWork)));
                            //}
                            //#endregion
                            // --- DEL 2010/06/26 ----------<<<<<
                            //<<<2010/05/30

                            //>>>2011/09/27
                            #region �݌ɊǗ��S�̐ݒ�
                            if (arList[0] is StockMngTtlStWork)
                            {
                                this._stockMngTtlSt = new StockMngTtlSt();
                                StockMngTtlStWork svWork = new StockMngTtlStWork();
                                foreach (StockMngTtlStWork work in arList)
                                {
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == ctSectionCode.Trim()))
                                    {
                                        svWork = work;
                                    }
                                }
                                #region ���ڃZ�b�g
                                this._stockMngTtlSt.CreateDateTime = svWork.CreateDateTime;
                                this._stockMngTtlSt.UpdateDateTime = svWork.UpdateDateTime;
                                this._stockMngTtlSt.EnterpriseCode = svWork.EnterpriseCode;
                                this._stockMngTtlSt.FileHeaderGuid = svWork.FileHeaderGuid;
                                this._stockMngTtlSt.UpdEmployeeCode = svWork.UpdEmployeeCode;
                                this._stockMngTtlSt.UpdAssemblyId1 = svWork.UpdAssemblyId1;
                                this._stockMngTtlSt.UpdAssemblyId2 = svWork.UpdAssemblyId2;
                                this._stockMngTtlSt.LogicalDeleteCode = svWork.LogicalDeleteCode;
                                this._stockMngTtlSt.SectionCode = svWork.SectionCode;
                                this._stockMngTtlSt.StockMoveFixCode = svWork.StockMoveFixCode;
                                this._stockMngTtlSt.StockPointWay = svWork.StockPointWay;
                                this._stockMngTtlSt.FractionProcCd = svWork.FractionProcCd;
                                this._stockMngTtlSt.StockTolerncShipmDiv = svWork.StockTolerncShipmDiv;
                                this._stockMngTtlSt.InvntryPrtOdrIniDiv = svWork.InvntryPrtOdrIniDiv;
                                this._stockMngTtlSt.MaxStkCntOverOderDiv = svWork.MaxStkCntOverOderDiv;
                                this._stockMngTtlSt.ShelfNoDuplDiv = svWork.ShelfNoDuplDiv;
                                this._stockMngTtlSt.LotUseDivCd = svWork.LotUseDivCd;
                                this._stockMngTtlSt.SectDspDivCd = svWork.SectDspDivCd;
                                this._stockMngTtlSt.InventoryMngDiv = svWork.InventoryMngDiv;
                                this._stockMngTtlSt.PreStckCntDspDiv = svWork.PreStckCntDspDiv; // ���݌ɐ��\���敪(0:�󒍕��܂� 1:�󒍕��܂܂Ȃ�)
                                #endregion
                            }
                            #endregion
                            //<<<2011/09/27
                        }
                    }
                }
            }
            return 0;  
        }

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

        # region ���|���D��Ǘ��}�X�^���䏈��
        /// <summary>
        /// �|���D��Ǘ��}�X�^�L���b�V���f���Q�[�g �R�[������
        /// </summary>
        public void CacheRateProtyMngListCall()
        {
            if (this.CacheRateProtyMngList != null) this.CacheRateProtyMngList(this._rateProtyMngList);
        }
        # endregion

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
        }
        #endregion

        //�󔭒��Ǘ��S�̐ݒ�
        public AcptAnOdrTtlSt GetAcptAnOdrTtlSt()
        {
            return this._acptAnOdrTtlSt;
        }
        //����S�̐ݒ�
        public SalesTtlSt GetSalesTtlSt()
        {
            return this._salesTtlSt;
        }
        //���Ϗ����l�ݒ�
        public EstimateDefSet GetEstimateDefSet()
        {
            return this._estimateDefSet;
        }
        //�d���݌ɑS��
        public StockTtlSt GetStockTtlSt()
        {
            return this._stockTtlSt;
        }
        //�S�̏����l
        public AllDefSet GetAllDefSet()
        {
            return this._allDefSet;
        }
        //���Џ��
        public CompanyInf GetCompanyInf()
        {
            return this._companyInf;
        }
        //�`�[����ݒ�}�X�^
        public List<SlipPrtSet> GetSlipPrtSetList()
        {
            return this._slipPrtSetList;
        }
        //���Ӑ�}�X�^(�`�[�Ǘ�
        public List<CustSlipMng> GetCustSlipMngList()
        {
            return this._custSlipMngList;
        }
        //UOE�K�C�h���̃}�X�^
        public List<UOEGuideName> GetUoeGuideNameList()
        {
            return this._uoeGuideNameList;
        }
        //����
        public List<SubSection> GetSubSectionList()
        {
            return this._subSectionList;
        }
        //�|���D��Ǘ��}�X�^
        public List<RateProtyMng> GetRateProtyMngList()
        {
            return this._rateProtyMngList;
        }
        //������z�����敪�}�X�^
        public List<SalesProcMoney> GetSalesProcMoneyList()
        {
            return this._salesProcMoneyList;
        }
        //�d�����z�����敪�}�X�^
        public List<StockProcMoney> GetStockProcMoneyList()
        {
            return this._stockProcMoneyList;
        }
        //���[�U�[�K�C�h
        public List<UserGdBd> GetUserGdBdList()
        {
            return this._userGdBdList;
        }

        //>>>2010/05/30
        # region ��SCM�S�̐ݒ萧�䏈��
        /// <summary>
        /// SCM�S�̐ݒ�}�X�^�̃��X�g������A�w�肵�����_�Ŏg�p����ݒ���擾���܂��B(���_�R�[�h��������ΑS�Аݒ�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="allDefSetArrayList">�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
        /// <returns>�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
        private SCMTtlStWork GetScmTtlStFromList(string sectionCode, ArrayList scmTtlStArrayList)
        {
            if (scmTtlStArrayList == null) return null;

            List<SCMTtlStWork> list = new List<SCMTtlStWork>((SCMTtlStWork[])scmTtlStArrayList.ToArray(typeof(SCMTtlStWork)));

            SCMTtlStWork scmTtlSt = list.Find(
                delegate(SCMTtlStWork scmTtl)
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
                delegate(SCMTtlStWork scmTtl)
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
        /// <returns></returns>
        public List<SCMDeliDateSt> GetScmDeliDateStList()
        {
            return this._scmDeliDateStList;
        }
        # endregion

        // --- DEL 2010/06/26 ---------->>>>>
        //#region ��BL�R�[�h�ϊ��}�X�^
        ///// <summary>
        ///// BL�R�[�h�ϊ��}�X�^�擾����
        ///// </summary>
        ///// <returns></returns>
        //public List<TbsPartsCdChgWork> GetTbsPartsCdChgWorkList()
        //{
        //    return this._tbsPartsCdChgWorkList;
        //}
        //# endregion
        // --- DEL 2010/06/26 ----------<<<<<
        //<<<2010/05/30

        //>>>2011/09/27
        #region ���݌ɊǗ��S�̐ݒ�
        public StockMngTtlSt GetStockMngTtlSt()
        {
            return this._stockMngTtlSt;
        }
        #endregion
        //<<<2011/09/27


        /// <summary>
        /// �ԗ��Ǘ��I�v�V����
        /// </summary>
        public int OptCarMng()
        {
            return this._opt_CarMng;
        }
        /// <summary>
        /// ���R�����I�v�V����
        /// </summary>
        public int OptFreeSearch()
        {
            return this._opt_FreeSearch;
        }
        /// <summary>
        /// �o�b�b�I�v�V����
        /// </summary>
        public int OptPCC()
        {
            return this._opt_PCC;
        }
        /// <summary>
        /// ���T�C�N���A���I�v�V����
        /// </summary>
        public int OptRCLink()
        {
            return this._opt_RCLink;
        }
        /// <summary>
        /// �t�n�d�I�v�V����
        /// </summary>
        public int OptUOE()
        {
            return this._opt_UOE;
        }
        /// <summary>
        /// �d���x���Ǘ��I�v�V����
        /// </summary>
        public int OptStockingPayment()
        {
            return this._opt_StockingPayment;
        }

        //>>>2010/05/30
        /// <summary>
        /// SCM�I�v�V����
        /// </summary>
        /// <returns></returns>
        public int OptSCM()
        {
            return this._opt_SCM;
        }
        //<<<2010/05/30

        // --- ADD 2010/06/26 ---- >>>>>
        /// <summary>
        /// QR�I�v�V����
        /// </summary>
        /// <returns></returns>
        public int OptQRMail()
        {
            return this._opt_QRMail;
        }
        // --- ADD 2010/06/26 ---- <<<<<
        // --- ADD T.Miyamoto 2012/11/13 ---------->>>>>
        /// <summary>
        /// ������t����I�v�V����
        /// </summary>
        /// <returns></returns>
        public int OptDateCtrl()
        {
            return this._opt_DateCtrl;
        }
        // --- ADD T.Miyamoto 2012/11/13 ----------<<<<<
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// �t�^�o�`�[�������I�v�V�����i�ʁj�FOPT-CPM0090
        /// </summary>
        /// <returns></returns>
        public int Opt_Cpm_FutabaSlipPrtCtl()
        {
            return this._opt_Cpm_FutabaSlipPrtCtl;
        }
        /// <summary>
        /// �t�^�o�q�Ɉ����ăI�v�V�����i�ʁj�FOPT-CPM0100
        /// </summary>
        /// <returns></returns>
        public int Opt_Cpm_FutabaWarehAlloc()
        {
            return this._opt_Cpm_FutabaWarehAlloc;
        }
        /// <summary>
        /// �t�^�oUOE�I�v�V�����i�ʁj�FOPT-CPM0110
        /// </summary>
        /// <returns></returns>
        public int Opt_Cpm_FutabaUOECtl()
        {
            return this._opt_Cpm_FutabaUOECtl;
        }
        /// <summary>
        /// �t�^�o�o�͍ϓ`�[����I�v�V�����i�ʁj�FOPT-CPM0120
        /// </summary>
        /// <returns></returns>
        public int Opt_Cpm_FutabaOutSlipCtl()
        {
            return this._opt_Cpm_FutabaOutSlipCtl;
        }

        // BLP�Q�Ƒq�ɒǉ��I�v�V����
        public int Opt_BLPRefWarehouse()
        {
            return this._opt_BLPRefWarehouse;
        }
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

        // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------>>>>
        /// <summary>
        /// TSP�I�v�V����
        /// </summary>
        public int OptTSP()
        {
           return this._opt_TSP;
        }
        // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------<<<<
        # endregion

    }
}
