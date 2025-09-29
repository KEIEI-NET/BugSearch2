using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �`�[����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// Note       : �`�[������i�p�̃A�N�Z�X�N���X�ł�<br />
    /// Programmer : 22018 ��� ���b<br />                                   
    /// Date       : 2007.12.27<br />                                      
    /// <br />
    /// Update Note: 2008.05.29 ��� ���b<br />
    ///                �@PM.NS�����ύX�B<br />
    ///                �@�i�������[�g������{���Ƃt�h�N���X�Ƃ̋@�\���S�������ɔ����A�S�̓I�ɑ啝�ȕύX�j<br />
    /// Update Note: 2009.08.13  20056 ���n ���</br>
    ///            : �T�[�o�[�֔z�u����N���C�A���g�A�Z���u���Ή�</br>
    ///            : �@�T�[�r�X�N�����̒[���ݒ�擾���\�b�h�ǉ�</br>
    /// Update Note: 2009.09.08 ��� ���b<br />
    ///                �@�S�̏����\���ݒ�̎擾�őS�Аݒ肪�擾�o���Ȃ��s��̏C��<br />
    /// Update Note: 2010/03/04 ��� �r��<br/>
    ///            :   �ŗ��ݒ�A������z�����敪�ݒ�擾
    /// Update Note: 2010/03/31 ��� �r��<br/>
    ///            :   Mantis�y14813�z�S�̏����ݒ�擾
    /// Update Note: 2010/03/30�@21024�@���X�� ��<br/>
    ///            : SCM�Ή��Ƃ��āA2008.08.13���̑g�ݍ��݁i2010/03/30�Ō������Ă��������j
    /// Update Note: 2010/05/14 ��� ���b<br/>
    ///            :   �T�u���|�[�g�@�\�̒ǉ��B�i�X��ʑΉ��ׁ̈A�ǉ��j
    /// Update Note: 2010/05/18 ��� �r��<br/>
    ///            :   �X�암�i�ʑΉ�
    /// Update Note: 2010/06/04 ��� ���b<br />
    ///                ���ʕ�����<br />
    ///                �@�r�b�l 2009.08.13 �̑g��<br />
    ///                �@�r�b�l 2010/03/30 �̑g��<br />
    /// Update Note: 2011/07/29 �����g<br/>
    ///            :   �����񓚋敪(SCM)�ǉ�
    /// Update Note: 2010/08/09  �����J</br>
    ///            : PCCUOE </br>
    ///            : �����[�g�`�[���s</br>
    ///            :   �����񓚋敪(SCM)�ǉ�
    /// Update Note: 2013/06/17  zhubj</br>
    ///            : Redmine #36594</br>
    ///            : ��10542 SCM</br>
    /// Update Note: 2013/07/28  zhubj</br>
    ///            : Redmine #36594</br>
    ///            : ��10542 SCM NO.10�̑Ή�</br>
    /// Update Note: 2014/10/27 wangf <br />
    /// �Ǘ��ԍ�   : 11070149-00<br />
    ///            : Redmine#43854�u�ړ��`�[�o�͐�敪�v���v�����^����<br />
    /// </remarks>
    public class SlipPrintAcs
    {
        # region [private const]
        // ���_�[��
        private const string ct_SectionZero = "00";
        // �q�Ƀ[��
        private const string ct_WarehouseZero = "0000";
        // ���Ӑ�[��
        private const int ct_CustomerZero = 0;
        // ���W�ԍ��[��
        private const int ct_CashRegisterZero = 0;
        // --- ADD  ���r��  2010/03/04 ---------->>>>>
        private const int ct_TaxRateCodeZero = 0;
        // --- ADD  ���r��  2010/03/04 ----------<<<<<

        # endregion

        # region [private fields]
        // ��ƃR�[�h
        private string _enterpriseCode;
        // ���_�R�[�h(���O�C���S���ҏ������_)
        private string _loginSectionCode;
        // �������ςݎ��R���[�󎚈ʒu�ݒ�L�[���X�g
        private Dictionary<string, bool> _decryptedFrePrtPSetDic;
        // �[���ݒ�
        private PosTerminalMg _posTerminalMg;
        // �v�����^�ݒ�A�N�Z�X�N���X
        private PrtManageAcs _prtManageAcs;
        // �`�[����ݒ胊�X�g�i�S���j
        private List<SlipPrtSetWork> _slipPrtSetWorkList;
        // ���Ӑ�}�X�^�`�[�Ǘ��i�`�[�^�C�v�Ǘ��}�X�^�j���X�g
        private List<CustSlipMngWork> _custSlipMngWorkList;
        // �`�[�o�͐�ݒ胊�X�g
        private List<SlipOutputSetWork> _slipOutputSetWorkList;
        // ���R���[����ʒu�ݒ胊�X�g
        private List<FrePrtPSetWork> _frePrtPSetWorkList;
        // ����S�̐ݒ胊�X�g
        private List<SalesTtlStWork> _salesTtlStWorkList;
        // �S�̏����\���ݒ胊�X�g
        private List<AllDefSetWork> _allDefSetWorkList;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
        // �݌ɊǗ��S�̐ݒ胊�X�g
        private List<StockMngTtlStWork> _stockMngTtlStWorkList;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
        // --- ADD  ���r��  2010/03/04 ---------->>>>>
        //�ŗ��ݒ胊�X�g
        private List<TaxRateSetWork> _taxRateSetWorkList;
        //������z�����敪�ݒ胊�X�g
        private List<SalesProcMoneyWork> _salesProcMoneyList;
        // --- ADD  ���r��  2010/03/04 ----------<<<<<
        // --- ADD  ���r��  2010/05/18 ---------->>>>>
        //UOE�K�C�h���̐ݒ�
        private List<UOEGuideNameWork> _uoeGuideNameWorkList;
        // --- ADD  ���r��  2010/05/18 ----------<<<<<

        // �`�[����A�N�Z�X�N���X�E�X�e�[�^�X
        private SlipAcsStatus _slipAcsState;
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
        /// <summary>
        /// �����[�g�`�[���s���邩
        /// </summary>
        private bool _IsRmSlpPrt;
        /// <summary>
        /// �����[�g�`�[���s�ݒ�}�X�^
        /// </summary>
        private RmSlpPrtStWork _rmSlpPrtStWork = null;
        /// <summary>
        /// �����[�g�`���ݒ�}�X�^
        /// </summary>
        private List<RmSlpPrtStWork> _rmSlpPrtStWorkList = null; 
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
        # endregion

        # region [public propaties]
        /// <summary>
        /// �`�[����A�N�Z�X�N���X�E�X�e�[�^�X
        /// </summary>
        public SlipAcsStatus SlipAcsState
        {
            get { return _slipAcsState; }
        }
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
        /// <summary>
        /// �����[�g�`�[���s�v���p�e�B
        /// </summary>
        public bool IsRmSlpPrt
        {
            get { return this._IsRmSlpPrt; }
            set { this._IsRmSlpPrt = value; }
        }
        /// <summary>
        /// �����[�g�`�[���s�ݒ�}�X�^�v���p�e�B
        /// </summary>
        public RmSlpPrtStWork RmSlpPrtStWork
        {
            get { return this._rmSlpPrtStWork; }
            set { this._rmSlpPrtStWork = value; }
        }
        /// <summary>
        /// �����[�g�`���ݒ�}�X�^�v���p�e�B
        /// </summary>
        public List<RmSlpPrtStWork> RmSlpPrtStWorkList
        {
            get { return this._rmSlpPrtStWorkList; }
            set { this._rmSlpPrtStWorkList = value; }
        }
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end

        // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
        /// <summary>�o�l������`�[�����t���O</summary>
        /// <summary>����`�[�����\���Ftrue�A���̑��Ffalse</summary>
        public bool IsPrintSplit
        {
            get { return false; }
        }
        // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
        # endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SlipPrintAcs( string enterpriseCode, string loginSectionCode )
       {
            _enterpriseCode = enterpriseCode;
            _loginSectionCode = loginSectionCode;
            _prtManageAcs = new PrtManageAcs();

            _slipAcsState = SlipAcsStatus.Normal;                        
        }
        # endregion

        # region [Search]
        # region [Search����]

        // 2010/03/30 Add >>>
        /// <summary>
        /// ���������i����`�[�j
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printDataList"></param>
        /// <returns></returns>
        public int InitialSearchFrePSalesSlip( FrePSalesSlipParaWork paraWork, ref List<List<ArrayList>> printDataList )
        {
            return this.InitialSearchFrePSalesSlip( paraWork, ref printDataList, 0 );
        }
        // 2010/03/30 Add <<<

        /// <summary>
        /// ���������i����`�[�j
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printDataList"></param>
        /// <returns></returns>      
        // 2010/03/30 >>>
        //public int InitialSearchFrePSalesSlip( FrePSalesSlipParaWork paraWork, ref List<List<ArrayList>> printDataList )
        public int InitialSearchFrePSalesSlip( FrePSalesSlipParaWork paraWork, ref List<List<ArrayList>> printDataList, int isService )
        // 2010/03/30 <<<
        {
            //// ��ƃR�[�h�ޔ�
            //_enterpriseCode = paraWork.EnterpriseCode;

            // �������ςݎ��R���[�󎚈ʒu�ݒ�f�B�N�V���i��������
            _decryptedFrePrtPSetDic = new Dictionary<string, bool>();
            
            // �[���ݒ�擾
            // 2010/03/30 >>>
            //int status = GetPosTerminalMg( out _posTerminalMg, _enterpriseCode );

            int status = 0;
            if ( isService == 0 )
            {
                status = GetPosTerminalMg( out _posTerminalMg, _enterpriseCode );
            }
            else
            {
                status = GetPosTerminalMgServer( out _posTerminalMg, _enterpriseCode );
            }
            // 2010/03/30 <<<
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_NoTerminalMg;
                return status;
            }

            // ���[�U�[DB��������
            List<ArrayList> printData = null;
            List<object> masterList = null;
            status = SearchFrePSalesSlip( paraWork, ref printData, ref masterList );
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_SearchSlip;
                return status;
            }

            // �}�X�^���X�g�W�J
            # region [�}�X�^���X�g�W�J]
            for ( int index = 0; index < masterList.Count; index++ )
            {
                if ( masterList[index] is SlipPrtSetWork[] )
                {
                    // �`�[����ݒ胊�X�g����
                    _slipPrtSetWorkList = new List<SlipPrtSetWork>( (SlipPrtSetWork[])masterList[index] );
                }
                else if ( masterList[index] is FrePrtPSetWork[] )
                {
                    // ���R���[�󎚈ʒu�ݒ胊�X�g����
                    _frePrtPSetWorkList = new List<FrePrtPSetWork>( (FrePrtPSetWork[])masterList[index] );
                }
                else if ( masterList[index] is CustSlipMngWork[] )
                {
                    // ���Ӑ�}�X�^�`�[�Ǘ��i�`�[�^�C�v�Ǘ��}�X�^�j���X�g����
                    _custSlipMngWorkList = new List<CustSlipMngWork>( (CustSlipMngWork[])masterList[index] );
                }
                else if ( masterList[index] is SlipOutputSetWork[] )
                {
                    // �`�[�o�͐�ݒ胊�X�g�쐬
                    _slipOutputSetWorkList = new List<SlipOutputSetWork>( (SlipOutputSetWork[])masterList[index] );
                }
                else if ( masterList[index] is SalesTtlStWork[] )
                {
                    // ����S�̐ݒ胊�X�g�쐬
                    _salesTtlStWorkList = new List<SalesTtlStWork>( (SalesTtlStWork[])masterList[index] );
                }
                else if ( masterList[index] is AllDefSetWork[] )
                {
                    // �S�̏����\���ݒ胊�X�g�쐬
                    _allDefSetWorkList = new List<AllDefSetWork>( (AllDefSetWork[])masterList[index] );
                }
                // --- ADD  ���r��  2010/03/04 ---------->>>>>
                else if (masterList[index] is TaxRateSetWork[])
                {
                    //�ŗ��ݒ胊�X�g�쐬
                    _taxRateSetWorkList = new List<TaxRateSetWork>((TaxRateSetWork[])masterList[index]);
                }
                else if (masterList[index] is SalesProcMoneyWork[])
                {
                    //������z�����敪�ݒ胊�X�g�쐬
                    _salesProcMoneyList = new List<SalesProcMoneyWork>((SalesProcMoneyWork[])masterList[index]);
                }
                // --- ADD  ���r��  2010/03/04 ----------<<<<<
                // --- ADD  ���r��  2010/05/18 ---------->>>>>
                else if (masterList[index] is UOEGuideNameWork[])
                {
                    //UOE�K�C�h���̐ݒ胊�X�g�쐬
                    _uoeGuideNameWorkList = new List<UOEGuideNameWork>((UOEGuideNameWork[])masterList[index]);
                }
                // --- ADD  ���r��  2010/05/18 ----------<<<<<
            }
            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
            //�����[�g�`�[���s�̏ꍇ
            if (this._IsRmSlpPrt) {
                RmSlpPrtStWork rmSlpPrtStWorkParam = new RmSlpPrtStWork();
                rmSlpPrtStWorkParam.InqOtherEpCd=this._enterpriseCode;
                IRmSlpPrtStDB iRmSlpPrtStDB;
                iRmSlpPrtStDB = MediationRmSlpPrtStDB.GetRmSlpPrtStDB();
                object rmSlpPrtStWorkObj;

                _rmSlpPrtStWorkList = null;
                try
                {
                    //�w�肳�ꂽ�����̃����[�g�`���ݒ�}�X�^�}�X�^���LIST��߂��܂�
                    status = iRmSlpPrtStDB.Search(out rmSlpPrtStWorkObj, rmSlpPrtStWorkParam, 0, ConstantManagement.LogicalMode.GetData0);
                    //���ʂ�߂�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    ArrayList rmSlpPrtStWorkArrayList = rmSlpPrtStWorkObj as ArrayList;
                    _rmSlpPrtStWorkList = new List<RmSlpPrtStWork>();
                    if (null != rmSlpPrtStWorkArrayList && rmSlpPrtStWorkArrayList.Count > 0)
                    {
                        for (int i = 0; i < rmSlpPrtStWorkArrayList.Count; i++)
                        {
                            _rmSlpPrtStWorkList.Add((RmSlpPrtStWork)rmSlpPrtStWorkArrayList[i]);
                        }
                        
                    }
                }
                catch(Exception e) {
                    return -1;
                }
            }
            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 DEL
            //// �ԋp�f�[�^�ҏW�@��DB�����E�K�p����
            //ReflectSalesSlipOfferSet( ref printData );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 DEL

            // �ԋp�f�[�^�ҏW�A�����v�����^�m��
            ReflectSalesSlipOutputPrinterSet( ref printData );


            // �ԋp�f�[�^�ҏW�BKey�ʕ��� (����󒍃X�e�[�^�X�A����v�����^�ł܂Ƃ߂�)
            # region [Key�ʕ���]
            Dictionary<SalesSlipListKey, List<ArrayList>> slipListDic = new Dictionary<SalesSlipListKey, List<ArrayList>>();
            Dictionary<RmSalesSlipListKey, List<ArrayList>> rmSlipListDic = new Dictionary<RmSalesSlipListKey, List<ArrayList>>();//ADD 2013/06/17 zhubj FOR Redmine #36594
            for ( int index = 0; index < printData.Count; index++ )
            {
                # region DEL 2013/06/17 zhubj FOR Redmine #36594
                //// �L�[����
                //SalesSlipListKey key = new SalesSlipListKey( (printData[index][0]) as FrePSalesSlipWork );
                //if ( !slipListDic.ContainsKey( key ) )
                //{
                //    // �V���X�g�ǉ�
                //    slipListDic.Add( key, new List<ArrayList>() );
                //}
                //// ���X�g�ɒǉ�
                //slipListDic[key].Add( printData[index] );
                # endregion

                // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
                if (this._IsRmSlpPrt)
                {
                    // �L�[����
                    RmSalesSlipListKey key = new RmSalesSlipListKey((printData[index][0]) as FrePSalesSlipWork);

                    if (!rmSlipListDic.ContainsKey(key))
                    {
                        // �V���X�g�ǉ�
                        rmSlipListDic.Add(key, new List<ArrayList>());
                    }
                    // ���X�g�ɒǉ�
                    rmSlipListDic[key].Add(printData[index]);
                }
                else
                {
                    // �L�[����
                    SalesSlipListKey key = new SalesSlipListKey((printData[index][0]) as FrePSalesSlipWork);

                    if (!slipListDic.ContainsKey(key))
                    {
                        // �V���X�g�ǉ�
                        slipListDic.Add(key, new List<ArrayList>());
                    }
                    // ���X�g�ɒǉ�
                    slipListDic[key].Add(printData[index]);
                }
                // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
            }
            // �f�B�N�V���i�����烊�X�g�Ɉڍs
            printDataList = new List<List<ArrayList>>();
            # region DEL 2013/06/17 zhubj FOR Redmine #36594
            //foreach ( List<ArrayList> slipList in slipListDic.Values )
            //{
            //    printDataList.Add( slipList );
            //}
            #endregion
            // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
            if (this._IsRmSlpPrt)
            {
                foreach (List<ArrayList> slipList in rmSlipListDic.Values)
                {
                    printDataList.Add(slipList);
                }
            }
            else
            {
                foreach (List<ArrayList> slipList in slipListDic.Values)
                {
                    printDataList.Add(slipList);
                }
            }
            // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
            # endregion

            return status;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 DEL
        # region //DEL
        ///// <summary>
        ///// �񋟃f�[�^�����E�K�p����
        ///// </summary>
        ///// <param name="printData"></param>
        //private void ReflectSalesSlipOfferSet( ref List<ArrayList> printData )
        //{
        //    //************************************************************************
        //    // �����F
        //    //   �E�`�[�f�[�^�𑖍����āA�K�v�Ȓ񋟃f�[�^�����������W���܂��B
        //    //   �E�S�f�[�^�����X�g�����ă����[�g�ɓn�����ƂŁA�P��̃����[�g�Ăяo���ŁA
        //    //   �@�K�v�ȑS�񋟃f�[�^���o���������܂��B
        //    // �@�E�����[�g�I����A�`�[�f�[�^�ɑ΂��ēK�p����K�v������܂����A
        //    //  �@ �\�ߓK�p�`�[�E���ׂ��ꂼ��̃��X�g�𐶐����Ă����A
        //    //   �@�Ώۂ̃��R�[�h�݂̂��X�V���鎖�ō�������}��܂��B
        //    //************************************************************************

        //    // �񋟃����[�g�p�����[�^
        //    CustomSerializeArrayList offerWorkList = new CustomSerializeArrayList();
            
        //    // �񋟂a�k�R�[�h�������X�g
        //    List<TbsPartsCodeWork> selectTbsPartsCodeList = new List<TbsPartsCodeWork>();
        //    // �񋟕��i���[�J�[�������X�g
        //    List<PMakerNmWork> selectPMakerNmWorkList = new List<PMakerNmWork>();


        //    // �K�p�Ώۃ��R�[�h�L�[�i���݂͒񋟃f�[�^����������͖̂��ׂ݂̂ł��j
        //    //List<int> refOfferSlipKeyList = new List<int>();
        //    List<RefOfferDetailKey> refOfferDetailKeyList = new List<RefOfferDetailKey>();


        //    //-----------------------------------------------------------
        //    // �����L�[�擾
        //    //-----------------------------------------------------------
        //    # region [�����L�[�擾]
        //    for ( int slipIndex = 0; slipIndex < printData.Count; slipIndex++ )
        //    {
        //        //// ����`�[�f�[�^
        //        //FrePSalesSlipWork slip = (FrePSalesSlipWork)(printData[slipIndex][0]);

        //        // ���㖾�׃f�[�^List
        //        List<FrePSalesDetailWork> detailList = (List<FrePSalesDetailWork>)(printData[slipIndex][1]);
        //        for ( int detailIndex = 0; detailIndex < detailList.Count; detailIndex++ )
        //        {
        //            FrePSalesDetailWork detail = detailList[detailIndex];

        //            // �a�k�R�[�h���̃`�F�b�N
        //            # region [�񋟂a�k]
        //            if ( detail.BLGOODSCDURF_BLGOODSCODERF == 0 )
        //            {
        //                // �����L�[���X�g�ɒǉ�
        //                TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();
        //                tbsPartsCodeWork.TbsPartsCode = detail.SALESDETAILRF_BLGOODSCODERF;
        //                selectTbsPartsCodeList.Add( tbsPartsCodeWork );

        //                // �K�p�L�[�ɒǉ�
        //                if ( !refOfferDetailKeyList.Contains( new RefOfferDetailKey( slipIndex, detailIndex ) ) )
        //                {
        //                    refOfferDetailKeyList.Add( new RefOfferDetailKey( slipIndex, detailIndex ) );
        //                }
        //            }
        //            # endregion

        //            // ���i���[�J�[���̃`�F�b�N
        //            # region [�񋟕��i���[�J�[(���i)]
        //            if ( detail.MAKGDS_GOODSMAKERCDRF == 0 )
        //            {
        //                // �����L�[���X�g�ɒǉ�
        //                PMakerNmWork pMakerNmWork = new PMakerNmWork();
        //                pMakerNmWork.PartsMakerCode = detail.SALESDETAILRF_GOODSMAKERCDRF;
        //                selectPMakerNmWorkList.Add( pMakerNmWork );

        //                // �K�p�L�[�ɒǉ�
        //                if ( !refOfferDetailKeyList.Contains( new RefOfferDetailKey( slipIndex, detailIndex ) ) )
        //                {
        //                    refOfferDetailKeyList.Add( new RefOfferDetailKey( slipIndex, detailIndex ) );
        //                }
        //            }
        //            # endregion

        //            // �ꎮ���[�J�[���̃`�F�b�N
        //            # region [�񋟕��i���[�J�[(�ꎮ)]
        //            if ( detail.MAKCMP_GOODSMAKERCDRF == 0 )
        //            {
        //                // �����L�[���X�g�ɒǉ�
        //                PMakerNmWork pMakerNmWork = new PMakerNmWork();
        //                pMakerNmWork.PartsMakerCode = detail.SALESDETAILRF_CMPLTGOODSMAKERCDRF;
        //                selectPMakerNmWorkList.Add( pMakerNmWork );

        //                // �K�p�L�[�ɒǉ�
        //                if ( !refOfferDetailKeyList.Contains( new RefOfferDetailKey( slipIndex, detailIndex ) ) )
        //                {
        //                    refOfferDetailKeyList.Add( new RefOfferDetailKey( slipIndex, detailIndex ) );
        //                }
        //            }
        //            # endregion
        //        }
        //    }

        //    // �񋟂a�k�R�[�h�������X�g
        //    if ( selectTbsPartsCodeList.Count > 0 )
        //    {
        //        offerWorkList.Add( selectTbsPartsCodeList.ToArray() );
        //    }
        //    // �񋟕��i���[�J�[�������X�g
        //    if ( selectPMakerNmWorkList.Count > 0 )
        //    {
        //        offerWorkList.Add( selectPMakerNmWorkList.ToArray() );
        //    }

        //    # endregion

        //    // �񋟌������s�v�Ȃ�΂����ŏI��
        //    if ( offerWorkList.Count == 0 ) return;

        //    //-----------------------------------------------------------
        //    // ����
        //    //-----------------------------------------------------------
        //    // �����[�g�I�u�W�F�N�g�擾
        //    IFrePSalesSlipOfferDB iFrePSalesSlipOfferDB = MediationFrePSalesSlipOfferDB.GetFrePSalesSlipOfferDB();

        //    bool msgDiv;
        //    string errMsg;
        //    object retObj = offerWorkList;
        //    int status = iFrePSalesSlipOfferDB.SearchFrePSalesSlipOffer( ref retObj, out msgDiv, out errMsg );
        //    if ( status != 0 || retObj == null || ( retObj as CustomSerializeArrayList ).Count == 0 )
        //    {
        //        // �������sor�Y���Ȃ��Ȃ炱���ŏI��
        //        return;
        //    }

        //    // �������ʃf�B�N�V���i������
        //    Dictionary<int, TbsPartsCodeWork> tbsPartsCodeWorkDic = new Dictionary<int, TbsPartsCodeWork>();
        //    Dictionary<int, PMakerNmWork> pMakerNmWorkDic = new Dictionary<int, PMakerNmWork>();

        //    # region [�������ʃf�B�N�V���i������]
        //    foreach ( object obj in (retObj as CustomSerializeArrayList) )
        //    {
        //        if ( obj is TbsPartsCodeWork[] )
        //        {
        //            foreach ( TbsPartsCodeWork work in (obj as TbsPartsCodeWork[]) )
        //            {
        //                if ( !tbsPartsCodeWorkDic.ContainsKey( work.TbsPartsCode ) )
        //                {
        //                    tbsPartsCodeWorkDic.Add( work.TbsPartsCode, work );
        //                }
        //            }
        //        }
        //        else if ( obj is PMakerNmWork[] )
        //        {
        //            foreach ( PMakerNmWork work in (obj as PMakerNmWork[]) )
        //            {
        //                if ( !pMakerNmWorkDic.ContainsKey( work.PartsMakerCode ) )
        //                {
        //                    pMakerNmWorkDic.Add( work.PartsMakerCode, work );
        //                }
        //            }
        //        }
        //    }
        //    # endregion

        //    //-----------------------------------------------------------
        //    // �ꊇ�K�p
        //    //-----------------------------------------------------------
        //    # region [�ꊇ�K�p]
        //    //foreach ( int slipIndex in refOfferSlipKeyList )
        //    //{
        //    //    // ����`�[�f�[�^
        //    //    FrePSalesSlipWork slip = (FrePSalesSlipWork)(printData[slipIndex][0]);
        //    //}

        //    // ���㖾�׃f�[�^List
        //    foreach ( RefOfferDetailKey refKey in refOfferDetailKeyList )
        //    {
        //        FrePSalesDetailWork detail = ((List<FrePSalesDetailWork>)(((ArrayList)printData[refKey.SlipIndex])[1]))[refKey.DetailIndex];

        //        // �a�k�R�[�h����
        //        # region [�񋟂a�k]
        //        if ( detail.BLGOODSCDURF_BLGOODSCODERF == 0 )
        //        {
        //            if ( tbsPartsCodeWorkDic.ContainsKey( detail.SALESDETAILRF_BLGOODSCODERF ) )
        //            {
        //                detail.SALESDETAILRF_BLGOODSFULLNAMERF = tbsPartsCodeWorkDic[detail.SALESDETAILRF_BLGOODSCODERF].TbsPartsFullName;
        //            }
        //        }
        //        # endregion

        //        // ���i���[�J�[����
        //        # region [�񋟕��i���[�J�[(���i)]
        //        if ( detail.MAKGDS_GOODSMAKERCDRF == 0 )
        //        {
        //            if ( pMakerNmWorkDic.ContainsKey( detail.SALESDETAILRF_GOODSMAKERCDRF ) )
        //            {
        //                detail.MAKGDS_MAKERKANANAMERF = pMakerNmWorkDic[detail.SALESDETAILRF_GOODSMAKERCDRF].PartsMakerHalfName;
        //                detail.MAKGDS_MAKERSHORTNAMERF = pMakerNmWorkDic[detail.SALESDETAILRF_GOODSMAKERCDRF].PartsMakerFullName;
        //            }
        //        }
        //        # endregion

        //        // �ꎮ���[�J�[����
        //        # region [�񋟕��i���[�J�[(�ꎮ)]
        //        if ( detail.MAKCMP_GOODSMAKERCDRF == 0 )
        //        {
        //            if ( pMakerNmWorkDic.ContainsKey( detail.SALESDETAILRF_CMPLTGOODSMAKERCDRF ) )
        //            {
        //                detail.MAKCMP_MAKERKANANAMERF = pMakerNmWorkDic[detail.SALESDETAILRF_CMPLTGOODSMAKERCDRF].PartsMakerHalfName;
        //                detail.MAKCMP_MAKERSHORTNAMERF = pMakerNmWorkDic[detail.SALESDETAILRF_CMPLTGOODSMAKERCDRF].PartsMakerFullName;
        //            }
        //        }
        //        # endregion
        //    }
        //    # endregion
        //}

        //# region [�񋟃f�[�^�K�p���׃L�[]
        ///// <summary>
        ///// �񋟃f�[�^�K�p���׃L�[
        ///// </summary>
        //private struct RefOfferDetailKey
        //{
        //    /// <summary>�`�[index</summary>
        //    private int _slipIndex;
        //    /// <summary>����index</summary>
        //    private int _detailIndex;
        //    /// <summary>
        //    /// �`�[index
        //    /// </summary>
        //    public int SlipIndex
        //    {
        //        get { return _slipIndex; }
        //        set { _slipIndex = value; }
        //    }
        //    /// <summary>
        //    /// ����index
        //    /// </summary>
        //    public int DetailIndex
        //    {
        //        get { return _detailIndex; }
        //        set { _detailIndex = value; }
        //    }
        //    /// <summary>
        //    /// �R���X�g���N�^
        //    /// </summary>
        //    /// <param name="slipIndex">�`�[index</param>
        //    /// <param name="detailIndex">����index</param>
        //    public RefOfferDetailKey( int slipIndex, int detailIndex )
        //    {
        //        _slipIndex = slipIndex;
        //        _detailIndex = detailIndex;
        //    }
        //}
        //# endregion
        
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 DEL


        /// <summary>
        /// �����v�����^���f����
        /// </summary>
        /// <param name="printData"></param>
        private void ReflectSalesSlipOutputPrinterSet( ref List<ArrayList> printData )
        {
            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
            if (!this._IsRmSlpPrt)
            {
                //�����[�g�`�[���s�̏ꍇ�A�����[�g�`���ݒ�}�X�^�̃f�[�^��ۑ�����
                _rmSlpPrtStWorkList = new List<RmSlpPrtStWork>();
            }
            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end

            for ( int index = 0; index < printData.Count; index++ )
            {
                try
                {
                    // ����`�[�f�[�^
                    FrePSalesSlipWork slip = (FrePSalesSlipWork)(printData[index][0]);
                    // ���㖾�׃f�[�^�P�s��
                    FrePSalesDetailWork detail1 = (FrePSalesDetailWork)((printData[index][1] as List<FrePSalesDetailWork>)[0]);

                    int slipKind = 30;
                    //10:����,20:��,30:����,40:�o��
                    switch ( slip.SALESSLIPRF_ACPTANODRSTATUSRF )
                    {
                        case 10:
                            slipKind = 140;
                            break;
                        case 20:
                            slipKind = 120;
                            break;
                        case 40:
                            slipKind = 130;
                            break;
                        case 30:
                        default:
                            slipKind = 30;
                            break;
                    }

                    // �f�t�H���g�`�[�^�C�v�擾
                    // modified by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
                    CustSlipMngWork custSlipMngWork = null;
                    if (!this._IsRmSlpPrt)
                    {
                        //�ʏ�̏ꍇ
                        custSlipMngWork = GetSlipPrintTypeDefault(slipKind, slip);
                        if (custSlipMngWork == null) continue;
                        // �`�[����p���[�h�c�Z�b�g
                        slip.HADD_SLIPPRTSETPAPERIDRF = custSlipMngWork.SlipPrtSetPaperId;
                    }
                    else {
                        //�����[�g�`�[���s�̏ꍇ
                        _rmSlpPrtStWork = GetRemoteSlipPrintTypeDefault(slipKind, slip);
                        if (_rmSlpPrtStWork == null) continue;
                        // �`�[����p���[�h�c�Z�b�g
                        slip.HADD_SLIPPRTSETPAPERIDRF = _rmSlpPrtStWork.SlipPrtSetPaperId;
                    }
                    // modified by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end

                    // �f�t�H���g�v�����^�擾
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 DEL
                    //SlipOutputSetWork slipOutputSetWork = GetSlipOutputSetDefault( slipKind, custSlipMngWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, slip, detail1 );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                    //SlipCreateProcessRF	0:���͏� 1:�݌ɕ� 2:�q�ɕ� 3:�o�͐�� (4:���׍s��?)
                    SalesTtlStWork salesTtlSt = GetSalesTtlSt();
                    bool eachWarehouseSetEnable = ((salesTtlSt != null) && (salesTtlSt.SlipCreateProcess == 3));

                    // modified by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
                    SlipOutputSetWork slipOutputSetWork;
                    if (!this._IsRmSlpPrt)
                    {
                        //�ʏ�̏ꍇ
                        slipOutputSetWork = GetSlipOutputSetDefault(slipKind, custSlipMngWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, slip, detail1, eachWarehouseSetEnable);
                    }
                    else {
                        //�����[�g�`�[���s�̏ꍇ
                        slipOutputSetWork = GetSlipOutputSetDefault(slipKind, _rmSlpPrtStWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, slip, detail1, eachWarehouseSetEnable);
                     }
                    // modified by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
                    if ( slipOutputSetWork == null ) continue;
                    // �v�����^�Ǘ����Z�b�g
                    slip.HADD_PRINTERMNGNORF = slipOutputSetWork.PrinterMngNo;
                }
                catch
                { 
                }
            }
        }
        /// <summary>
        /// ����`�[�f�[�^�擾����
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printData">����f�[�^���X�g���X�g</param>
        /// <param name="masterList">�֘A�}�X�^�z�񃊃X�g</param>
        /// <returns></returns>
        private int SearchFrePSalesSlip( FrePSalesSlipParaWork paraWork, ref List<ArrayList> printData, ref List<object> masterList )
        {
            // �����[�g�擾
            IFrePSalesSlipDB iFrePSalesSlipDB = (IFrePSalesSlipDB)MediationFrePSalesSlipDB.GetFrePSalesSlipDB();

            // ���R���[�i����`�[�j�����[�g�Ăяo��
            object retObj;
            object mstList;
            bool msgDiv;
            string errMsg;
            //int status = iFrePSalesSlipDB.Search( XmlByteSerializer.Serialize( paraWork ), out retObj, out mstList, out msgDiv, out errMsg );
            int status = iFrePSalesSlipDB.Search( paraWork, out retObj, out mstList, out msgDiv, out errMsg );

            if ( status == 0 )
            {
                // �ԋp�p�����[�^�Z�b�g
                printData = new List<ArrayList>( (ArrayList[])(retObj as CustomSerializeArrayList).ToArray( typeof( ArrayList ) ) );
                masterList = new List<object>( (mstList as CustomSerializeArrayList).ToArray() );
            }
            return status;
        }
        # endregion

        # region [Search���Ϗ�]
        /// <summary>
        /// ���������i���Ϗ��j
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="customerCode"></param>
        /// <param name="printData"></param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
        //public int InitialSearchFrePEstFm( FrePEstFmParaWork paraWork, ref List<ArrayList> printData )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
        public int InitialSearchFrePEstFm( FrePEstFmParaWork paraWork, int customerCode, ref List<ArrayList> printData )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
        {
            //// ��ƃR�[�h�ޔ�
            //_enterpriseCode = paraWork.EnterpriseCode;

            // �������ςݎ��R���[�󎚈ʒu�ݒ�f�B�N�V���i��������
            _decryptedFrePrtPSetDic = new Dictionary<string, bool>();

            // �[���ݒ�擾
            int status = GetPosTerminalMg( out _posTerminalMg, _enterpriseCode );
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_NoTerminalMg;
                return status;
            }

            // ���[�U�[DB��������
            List<object> masterList = null;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
            //status = SearchFrePEstFm( paraWork, ref printData, ref masterList );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            status = SearchFrePEstFm( paraWork, customerCode, ref printData, ref masterList );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_SearchSlip;
                return status;
            }

            // �}�X�^���X�g�W�J
            # region [�}�X�^���X�g�W�J]
            for ( int index = 0; index < masterList.Count; index++ )
            {
                if ( masterList[index] is SlipPrtSetWork[] )
                {
                    // �`�[����ݒ胊�X�g����
                    _slipPrtSetWorkList = new List<SlipPrtSetWork>( (SlipPrtSetWork[])masterList[index] );
                }
                else if ( masterList[index] is FrePrtPSetWork[] )
                {
                    // ���R���[�󎚈ʒu�ݒ胊�X�g����
                    _frePrtPSetWorkList = new List<FrePrtPSetWork>( (FrePrtPSetWork[])masterList[index] );
                }
                else if ( masterList[index] is CustSlipMngWork[] )
                {
                    // ���Ӑ�}�X�^�`�[�Ǘ��i�`�[�^�C�v�Ǘ��}�X�^�j���X�g����
                    _custSlipMngWorkList = new List<CustSlipMngWork>( (CustSlipMngWork[])masterList[index] );
                }
                else if ( masterList[index] is SlipOutputSetWork[] )
                {
                    // �`�[�o�͐�ݒ胊�X�g�쐬
                    _slipOutputSetWorkList = new List<SlipOutputSetWork>( (SlipOutputSetWork[])masterList[index] );
                }
                else if ( masterList[index] is SalesTtlStWork[] )
                {
                    // ����S�̐ݒ胊�X�g�쐬
                    _salesTtlStWorkList = new List<SalesTtlStWork>( (SalesTtlStWork[])masterList[index] );
                }
                else if ( masterList[index] is AllDefSetWork[] )
                {
                    // �S�̏����\���ݒ�
                    _allDefSetWorkList = new List<AllDefSetWork>( (AllDefSetWork[])masterList[index] );
                }
            }
            # endregion


            FrePSalesSlipWork frePSalesSlipWork = null;
            if ( printData != null && printData.Count > 0 )
            {
                foreach ( ArrayList list in printData )
                {
                    foreach ( object retObj in list )
                    {
                        if ( retObj is FrePSalesSlipWork )
                        {
                            frePSalesSlipWork = (retObj as FrePSalesSlipWork);
                        }
                    }
                }
            }

            if ( frePSalesSlipWork != null )
            {
                // �ԋp�f�[�^�ҏW�A�����v�����^�m��
                ReflectSalesSlipOutputPrinterSetForEstFm( ref frePSalesSlipWork );
            }
            return status;
        }

        /// <summary>
        /// �����v�����^���f����
        /// </summary>
        /// <param name="frePSalesSlipWork"></param>
        private void ReflectSalesSlipOutputPrinterSetForEstFm( ref FrePSalesSlipWork frePSalesSlipWork )
        {
            try
            {
                // 10:���Ϗ�
                int slipKind = 10;

                // �f�t�H���g�`�[�^�C�v�擾
                CustSlipMngWork custSlipMngWork = GetSlipPrintTypeDefaultForEstFm( slipKind, frePSalesSlipWork );
                if ( custSlipMngWork == null ) return;
                // �`�[����p���[�h�c�Z�b�g
                frePSalesSlipWork.HADD_SLIPPRTSETPAPERIDRF = custSlipMngWork.SlipPrtSetPaperId;

                // �f�t�H���g�v�����^�擾
                SlipOutputSetWork slipOutputSetWork = GetSlipOutputSetDefaultForEstFm( slipKind, custSlipMngWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, frePSalesSlipWork );
                if ( slipOutputSetWork == null ) return;
                // �v�����^�Ǘ����Z�b�g
                frePSalesSlipWork.HADD_PRINTERMNGNORF = slipOutputSetWork.PrinterMngNo;
            }
            catch
            {
            }
        }
        /// <summary>
        /// ���Ϗ��֘A�f�[�^�擾����
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="customerCode"></param>
        /// <param name="printData">����f�[�^���X�g���X�g</param>
        /// <param name="masterList">�֘A�}�X�^�z�񃊃X�g</param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
        //private int SearchFrePEstFm( FrePEstFmParaWork paraWork, ref List<ArrayList> printData, ref List<object> masterList )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
        private int SearchFrePEstFm( FrePEstFmParaWork paraWork, int customerCode, ref List<ArrayList> printData, ref List<object> masterList )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
        {
            // �����[�g�擾
            IFrePSalesSlipDB iFrePSalesSlipDB = (IFrePSalesSlipDB)MediationFrePSalesSlipDB.GetFrePSalesSlipDB();

            // ���R���[�i����`�[�j�����[�g���Ϗ��p���\�b�h�Ăяo��
            object retObj;
            object mstList;
            bool msgDiv;
            string errMsg;
            //int status = iFrePSalesSlipDB.SearchForEstFm( XmlByteSerializer.Serialize( paraWork ), out retObj, out mstList, out msgDiv, out errMsg );
            int status = iFrePSalesSlipDB.SearchForEstFm( paraWork, out retObj, out mstList, out msgDiv, out errMsg );

            if ( status == 0 )
            {
                // �ԋp�p�����[�^�Z�b�g
                //printData = new List<ArrayList>( (ArrayList[])(retObj as CustomSerializeArrayList).ToArray( typeof( ArrayList ) ) );
                FrePSalesSlipWork slipWork = (FrePSalesSlipWork)((retObj as CustomSerializeArrayList)[0]);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
                slipWork.SALESSLIPRF_CUSTOMERCODERF = customerCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
                ArrayList aList = new ArrayList();
                aList.Add( slipWork );

                printData = new List<ArrayList>();
                printData.Add( aList );
                masterList = new List<object>( (mstList as CustomSerializeArrayList).ToArray() );
            }
            return status;
        }
        # endregion

        # region [Search�݌Ɉړ�]
        /// <summary>
        /// ���������i�݌Ɉړ��`�[�j
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printDataList"></param>
        /// <returns></returns>
        public int InitialSearchFrePStockMoveSlip( FrePStockMoveSlipParaWork paraWork, ref List<List<ArrayList>> printDataList )
        {
            // �������ςݎ��R���[�󎚈ʒu�ݒ�f�B�N�V���i��������
            _decryptedFrePrtPSetDic = new Dictionary<string, bool>();

            // �[���ݒ�擾
            int status = GetPosTerminalMg( out _posTerminalMg, _enterpriseCode );
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_NoTerminalMg;
                return status;
            }

            // ���[�U�[DB��������
            List<ArrayList> printData = null;
            List<object> masterList = null;
            status = SearchFrePStockMoveSlip( paraWork, ref printData, ref masterList );
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_SearchSlip;
                return status;
            }


            // �}�X�^���X�g�W�J
            # region [�}�X�^���X�g�W�J]
            for ( int index = 0; index < masterList.Count; index++ )
            {
                if ( masterList[index] is SlipPrtSetWork[] )
                {
                    // �`�[����ݒ胊�X�g����
                    _slipPrtSetWorkList = new List<SlipPrtSetWork>( (SlipPrtSetWork[])masterList[index] );
                }
                else if ( masterList[index] is FrePrtPSetWork[] )
                {
                    // ���R���[�󎚈ʒu�ݒ胊�X�g����
                    _frePrtPSetWorkList = new List<FrePrtPSetWork>( (FrePrtPSetWork[])masterList[index] );
                }
                else if ( masterList[index] is CustSlipMngWork[] )
                {
                    // ���Ӑ�}�X�^�`�[�Ǘ��i�`�[�^�C�v�Ǘ��}�X�^�j���X�g����
                    _custSlipMngWorkList = new List<CustSlipMngWork>( (CustSlipMngWork[])masterList[index] );
                }
                else if ( masterList[index] is SlipOutputSetWork[] )
                {
                    // �`�[�o�͐�ݒ胊�X�g�쐬
                    _slipOutputSetWorkList = new List<SlipOutputSetWork>( (SlipOutputSetWork[])masterList[index] );
                }
                else if ( masterList[index] is StockMngTtlStWork[] )
                {
                    // �݌ɊǗ��S�̐ݒ胊�X�g�쐬
                    _stockMngTtlStWorkList = new List<StockMngTtlStWork>( (StockMngTtlStWork[])masterList[index] );
                }
                // --- ADD  ���r��  2010/03/31 ---------->>>>>
                else if ( masterList[index] is AllDefSetWork[] )
                {
                    //�S�̏����\���ݒ胊�X�g�쐬
                    _allDefSetWorkList = new List<AllDefSetWork>( (AllDefSetWork[])masterList[index] );
                }
                // --- ADD  ���r��  2010/03/31 ----------<<<<<
            }
            # endregion

            // �ԋp�f�[�^�ҏW�@�����v�����^�m��
            ReflectStockMoveSlipOutputPrinterSet( ref printData );

            // �ԋp�f�[�^�ҏW�AKey�ʕ��� (����󒍃X�e�[�^�X�A����v�����^�ł܂Ƃ߂�)
            # region [Key�ʕ���]
            Dictionary<StockMoveSlipListKey, List<ArrayList>> slipListDic = new Dictionary<StockMoveSlipListKey, List<ArrayList>>();
            for ( int index = 0; index < printData.Count; index++ )
            {
                // �L�[����
                StockMoveSlipListKey key = new StockMoveSlipListKey( (printData[index][0]) as FrePStockMoveSlipWork );
                if ( !slipListDic.ContainsKey( key ) )
                {
                    // �V���X�g�ǉ�
                    slipListDic.Add( key, new List<ArrayList>() );
                }
                // ���X�g�ɒǉ�
                slipListDic[key].Add( printData[index] );
            }
            // �f�B�N�V���i�����烊�X�g�Ɉڍs
            printDataList = new List<List<ArrayList>>();
            foreach ( List<ArrayList> slipList in slipListDic.Values )
            {
                printDataList.Add( slipList );
            }
            # endregion

            return status;
        }
        /// <summary>
        /// �����v�����^���f����
        /// </summary>
        /// <param name="printData"></param>
        private void ReflectStockMoveSlipOutputPrinterSet( ref List<ArrayList> printData )
        {
            for ( int index = 0; index < printData.Count; index++ )
            {
                try
                {
                    // �݌Ɉړ��`�[�f�[�^
                    FrePStockMoveSlipWork slip = (FrePStockMoveSlipWork)(printData[index][0]);
                    // �݌Ɉړ����׃f�[�^�P�s��
                    FrePStockMoveDetailWork detail1 = (FrePStockMoveDetailWork)((printData[index][1] as List<FrePStockMoveDetailWork>)[0]);

                    //int slipKind;
                    //if ( slip.SALESSLIPRF_ACPTANODRSTATUSRF == 10 )
                    //{
                    //    slipKind = 10;  // 10:���Ϗ�
                    //}
                    //else
                    //{
                    //    slipKind = 30;  // 30:�[�i��
                    //}
                    int slipKind = 150; // 150:�݌Ɉړ�

                    // �f�t�H���g�`�[�^�C�v�擾
                    CustSlipMngWork custSlipMngWork = GetSlipPrintTypeDefault( slipKind, slip );
                    if ( custSlipMngWork == null ) continue;
                    // �`�[����p���[�h�c�Z�b�g
                    slip.HADD_SLIPPRTSETPAPERIDRF = custSlipMngWork.SlipPrtSetPaperId;


                    // �f�t�H���g�v�����^�擾
                    SlipOutputSetWork slipOutputSetWork = GetSlipOutputSetDefault( slipKind, custSlipMngWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, slip, detail1 );
                    if ( slipOutputSetWork == null ) continue;
                    // �v�����^�Ǘ����Z�b�g
                    slip.HADD_PRINTERMNGNORF = slipOutputSetWork.PrinterMngNo;
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// �݌Ɉړ��`�[�f�[�^�擾����
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printData">����f�[�^���X�g���X�g</param>
        /// <param name="masterList">�֘A�}�X�^�z�񃊃X�g</param>
        /// <returns></returns>
        private int SearchFrePStockMoveSlip( FrePStockMoveSlipParaWork paraWork, ref List<ArrayList> printData, ref List<object> masterList )
        {
            // �����[�g�擾
            IFrePStockMoveSlipDB iFrePStockMoveSlipDB = (IFrePStockMoveSlipDB)MediationFrePStockMoveSlipDB.GetFrePStockMoveSlipDB();

            // ���R���[�i�݌Ɉړ��`�[�j�����[�g�Ăяo��
            object retObj;
            object mstList;
            bool msgDiv;
            string errMsg;
            int status = iFrePStockMoveSlipDB.Search( XmlByteSerializer.Serialize( paraWork ), out retObj, out mstList, out msgDiv, out errMsg );

            if ( status == 0 )
            {
                // �ԋp�p�����[�^�Z�b�g
                printData = new List<ArrayList>( (ArrayList[])(retObj as CustomSerializeArrayList).ToArray( typeof( ArrayList ) ) );
                masterList = new List<object>( (mstList as CustomSerializeArrayList).ToArray() );
            }
            return status;
        }
        # endregion

        # region [Search�t�n�d�`�[]
        /// <summary>
        /// ���������iUOE�`�[�j
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printDataList"></param>
        /// <returns></returns>
        public int InitialSearchFrePUOESlip( FrePUOESlipParaWork paraWork, ref List<List<ArrayList>> printDataList, List<UoeSales> uoeSalesList )
        {
            //// ��ƃR�[�h�ޔ�
            //_enterpriseCode = paraWork.EnterpriseCode;

            // �������ςݎ��R���[�󎚈ʒu�ݒ�f�B�N�V���i��������
            _decryptedFrePrtPSetDic = new Dictionary<string, bool>();

            // �[���ݒ�擾
            int status = GetPosTerminalMg( out _posTerminalMg, _enterpriseCode );
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_NoTerminalMg;
                return status;
            }

            // ���[�U�[DB��������
            List<ArrayList> printData = null;
            List<object> masterList = null;
            status = SearchFrePUOESlip( paraWork, ref printData, ref masterList );
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_SearchSlip;
                return status;
            }

            // �}�X�^���X�g�W�J
            # region [�}�X�^���X�g�W�J]
            for ( int index = 0; index < masterList.Count; index++ )
            {
                if ( masterList[index] is SlipPrtSetWork[] )
                {
                    // �`�[����ݒ胊�X�g����
                    _slipPrtSetWorkList = new List<SlipPrtSetWork>( (SlipPrtSetWork[])masterList[index] );
                }
                else if ( masterList[index] is FrePrtPSetWork[] )
                {
                    // ���R���[�󎚈ʒu�ݒ胊�X�g����
                    _frePrtPSetWorkList = new List<FrePrtPSetWork>( (FrePrtPSetWork[])masterList[index] );
                }
                else if ( masterList[index] is CustSlipMngWork[] )
                {
                    // ���Ӑ�}�X�^�`�[�Ǘ��i�`�[�^�C�v�Ǘ��}�X�^�j���X�g����
                    _custSlipMngWorkList = new List<CustSlipMngWork>( (CustSlipMngWork[])masterList[index] );
                }
                else if ( masterList[index] is SlipOutputSetWork[] )
                {
                    // �`�[�o�͐�ݒ胊�X�g�쐬
                    _slipOutputSetWorkList = new List<SlipOutputSetWork>( (SlipOutputSetWork[])masterList[index] );
                }
                else if ( masterList[index] is SalesTtlStWork[] )
                {
                    // ����S�̐ݒ胊�X�g�쐬
                    _salesTtlStWorkList = new List<SalesTtlStWork>( (SalesTtlStWork[])masterList[index] );
                }
                else if ( masterList[index] is AllDefSetWork[] )
                { 
                    // �S�̏����\���ݒ胊�X�g�쐬
                    _allDefSetWorkList = new List<AllDefSetWork>( (AllDefSetWork[])masterList[index] );
                }
                // --- ADD  ���r��  2010/05/18 ---------->>>>>
                else if ( masterList[index] is UOEGuideNameWork[] )
                {
                    //UOE�K�C�h���̐ݒ胊�X�g�쐬
                    _uoeGuideNameWorkList = new List<UOEGuideNameWork>( (UOEGuideNameWork[])masterList[index] );
                }
                // --- ADD  ���r��  2010/05/18 ----------<<<<<
            }
            # endregion

            // �ԋp�f�[�^�ҏW�@�����v�����^�m��
            ReflectUOESlipOutputPrinterSet( ref printData );

            // �ԋp�f�[�^�ҏW�AUOE�⑫���ǉ�
            # region [�⑫���ǉ�]
            for ( int index = 0; index < printData.Count; index++ )
            {
                if ( uoeSalesList.Count > index )
                {
                    printData[index].Add( uoeSalesList[index] );
                }
            }
            # endregion

            // �ԋp�f�[�^�ҏW�BKey�ʕ��� (����󒍃X�e�[�^�X�A����v�����^�ł܂Ƃ߂�)
            # region [Key�ʕ���]
            Dictionary<SalesSlipListKey, List<ArrayList>> slipListDic = new Dictionary<SalesSlipListKey, List<ArrayList>>();
            for ( int index = 0; index < printData.Count; index++ )
            {
                // �L�[����
                SalesSlipListKey key = new SalesSlipListKey( (printData[index][0]) as FrePSalesSlipWork );
                if ( !slipListDic.ContainsKey( key ) )
                {
                    // �V���X�g�ǉ�
                    slipListDic.Add( key, new List<ArrayList>() );
                }
                // ���X�g�ɒǉ�
                slipListDic[key].Add( printData[index] );
            }
            // �f�B�N�V���i�����烊�X�g�Ɉڍs
            printDataList = new List<List<ArrayList>>();
            foreach ( List<ArrayList> slipList in slipListDic.Values )
            {
                printDataList.Add( slipList );
            }
            # endregion

            return status;
        }

        /// <summary>
        /// �����v�����^���f�����iUOE�`�[�p�j
        /// </summary>
        /// <param name="printData"></param>
        private void ReflectUOESlipOutputPrinterSet( ref List<ArrayList> printData )
        {
            for ( int index = 0; index < printData.Count; index++ )
            {
                try
                {
                    // UOE�`�[�f�[�^
                    FrePSalesSlipWork slip = (FrePSalesSlipWork)(printData[index][0]);
                    // ���㖾�׃f�[�^�P�s��
                    FrePSalesDetailWork detail1 = (FrePSalesDetailWork)((printData[index][1] as List<FrePSalesDetailWork>)[0]);

                    //160:�t�n�d�`�[
                    int slipKind = 160;

                    // �f�t�H���g�`�[�^�C�v�擾
                    CustSlipMngWork custSlipMngWork = GetSlipPrintTypeDefault( slipKind, slip );
                    if ( custSlipMngWork == null ) continue;
                    // �`�[����p���[�h�c�Z�b�g
                    slip.HADD_SLIPPRTSETPAPERIDRF = custSlipMngWork.SlipPrtSetPaperId;

                    // �f�t�H���g�v�����^�擾
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 DEL
                    //SlipOutputSetWork slipOutputSetWork = GetSlipOutputSetDefault( slipKind, custSlipMngWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, slip, detail1 );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                    //SlipCreateProcessRF	0:���͏� 1:�݌ɕ� 2:�q�ɕ� 3:�o�͐�� (4:���׍s��?)
                    SalesTtlStWork salesTtlSt = GetSalesTtlSt();
                    bool eachWarehouseSetEnable = ((salesTtlSt != null) && (salesTtlSt.SlipCreateProcess == 3));
                    SlipOutputSetWork slipOutputSetWork = GetSlipOutputSetDefault( slipKind, custSlipMngWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, slip, detail1, eachWarehouseSetEnable );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD

                    if ( slipOutputSetWork == null ) continue;
                    // �v�����^�Ǘ����Z�b�g
                    slip.HADD_PRINTERMNGNORF = slipOutputSetWork.PrinterMngNo;
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// UOE�`�[�f�[�^�擾����
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printData">����f�[�^���X�g���X�g</param>
        /// <param name="masterList">�֘A�}�X�^�z�񃊃X�g</param>
        /// <returns></returns>
        private int SearchFrePUOESlip( FrePUOESlipParaWork paraWork, ref List<ArrayList> printData, ref List<object> masterList )
        {
            //// �����[�g�擾
            //IFrePSalesSlipDB iFrePSalesSlipDB = (IFrePSalesSlipDB)MediationFrePSalesSlipDB.GetFrePSalesSlipDB();

            ////// ���R���[�iUOE�`�[�j�����[�g�Ăяo��
            //object retObj;
            //object mstList;
            //bool msgDiv;
            //string errMsg;
            //int status = iFrePSalesSlipDB.Search( XmlByteSerializer.Serialize( paraWork ), out retObj, out mstList, out msgDiv, out errMsg );

            //if ( status == 0 )
            //{
            //    // �ԋp�p�����[�^�Z�b�g
            //    printData = new List<ArrayList>( (ArrayList[])(retObj as CustomSerializeArrayList).ToArray( typeof( ArrayList ) ) );
            //    masterList = new List<object>( (mstList as CustomSerializeArrayList).ToArray() );
            //}
            //return status;

            // �����[�g�擾
            IFrePSalesSlipDB iFrePSalesSlipDB = (IFrePSalesSlipDB)MediationFrePSalesSlipDB.GetFrePSalesSlipDB();

            // ���R���[�iUOE�`�[�j�����[�g�Ăяo��
            object retObj;
            object mstList;
            bool msgDiv;
            string errMsg;
            int status = iFrePSalesSlipDB.SearchForUOE( paraWork, out retObj, out mstList, out msgDiv, out errMsg );

            if ( status == 0 )
            {
                // �ԋp�p�����[�^�Z�b�g
                printData = new List<ArrayList>( (ArrayList[])(retObj as CustomSerializeArrayList).ToArray( typeof( ArrayList ) ) );
                masterList = new List<object>( (mstList as CustomSerializeArrayList).ToArray() );
            }

            return 0;
            //return status;
        }
        /// <summary>
        /// UOE�`�[�p �f�[�^�ڍs�����i����`�[work�����R���[����`�[work�j
        /// </summary>
        /// <param name="salesSlipWork"></param>
        /// <returns></returns>
        public static FrePSalesSlipWork CopyToFrePSalesSlipWorkFromSalesSlip( SalesSlipWork salesSlipWork )
        {
            FrePSalesSlipWork frePSalesSlipWork = new FrePSalesSlipWork();

            # region [copy]
            frePSalesSlipWork.SALESSLIPRF_ACPTANODRSTATUSRF = salesSlipWork.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            frePSalesSlipWork.SALESSLIPRF_SALESSLIPNUMRF = salesSlipWork.SalesSlipNum; // ����`�[�ԍ�
            frePSalesSlipWork.SALESSLIPRF_SECTIONCODERF = salesSlipWork.SectionCode; // ���_�R�[�h
            frePSalesSlipWork.SALESSLIPRF_SUBSECTIONCODERF = salesSlipWork.SubSectionCode; // ����R�[�h
            frePSalesSlipWork.SALESSLIPRF_DEBITNOTEDIVRF = salesSlipWork.DebitNoteDiv; // �ԓ`�敪
            frePSalesSlipWork.SALESSLIPRF_DEBITNLNKSALESSLNUMRF = salesSlipWork.DebitNLnkSalesSlNum; // �ԍ��A������`�[�ԍ�
            frePSalesSlipWork.SALESSLIPRF_SALESSLIPCDRF = salesSlipWork.SalesSlipCd; // ����`�[�敪
            frePSalesSlipWork.SALESSLIPRF_SALESGOODSCDRF = salesSlipWork.SalesGoodsCd; // ���㏤�i�敪
            frePSalesSlipWork.SALESSLIPRF_ACCRECDIVCDRF = salesSlipWork.AccRecDivCd; // ���|�敪
            frePSalesSlipWork.SALESSLIPRF_SEARCHSLIPDATERF = ToLongDate( salesSlipWork.SearchSlipDate ); // �`�[�������t
            frePSalesSlipWork.SALESSLIPRF_SHIPMENTDAYRF = ToLongDate( salesSlipWork.ShipmentDay ); // �o�ד��t
            frePSalesSlipWork.SALESSLIPRF_SALESDATERF = ToLongDate( salesSlipWork.SalesDate ); // ������t
            frePSalesSlipWork.SALESSLIPRF_ADDUPADATERF = ToLongDate( salesSlipWork.AddUpADate ); // �v����t
            frePSalesSlipWork.SALESSLIPRF_DELAYPAYMENTDIVRF = salesSlipWork.DelayPaymentDiv; // �����敪
            frePSalesSlipWork.SALESSLIPRF_ESTIMATEFORMNORF = salesSlipWork.EstimateFormNo; // ���Ϗ��ԍ�
            frePSalesSlipWork.SALESSLIPRF_ESTIMATEDIVIDERF = salesSlipWork.EstimateDivide; // ���ϋ敪
            frePSalesSlipWork.SALESSLIPRF_SALESINPUTCODERF = salesSlipWork.SalesInputCode; // ������͎҃R�[�h
            frePSalesSlipWork.SALESSLIPRF_SALESINPUTNAMERF = salesSlipWork.SalesInputName; // ������͎Җ���
            frePSalesSlipWork.SALESSLIPRF_FRONTEMPLOYEECDRF = salesSlipWork.FrontEmployeeCd; // ��t�]�ƈ��R�[�h
            frePSalesSlipWork.SALESSLIPRF_FRONTEMPLOYEENMRF = salesSlipWork.FrontEmployeeNm; // ��t�]�ƈ�����
            frePSalesSlipWork.SALESSLIPRF_SALESEMPLOYEECDRF = salesSlipWork.SalesEmployeeCd; // �̔��]�ƈ��R�[�h
            frePSalesSlipWork.SALESSLIPRF_SALESEMPLOYEENMRF = salesSlipWork.SalesEmployeeNm; // �̔��]�ƈ�����
            frePSalesSlipWork.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF = salesSlipWork.TotalAmountDispWayCd; // ���z�\�����@�敪
            frePSalesSlipWork.SALESSLIPRF_TTLAMNTDISPRATEAPYRF = salesSlipWork.TtlAmntDispRateApy; // ���z�\���|���K�p�敪
            frePSalesSlipWork.SALESSLIPRF_SALESTOTALTAXINCRF = salesSlipWork.SalesTotalTaxInc; // ����`�[���v�i�ō��݁j
            frePSalesSlipWork.SALESSLIPRF_SALESTOTALTAXEXCRF = salesSlipWork.SalesTotalTaxExc; // ����`�[���v�i�Ŕ����j
            frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXINCRF = salesSlipWork.SalesSubtotalTaxInc; // ���㏬�v�i�ō��݁j
            frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXEXCRF = salesSlipWork.SalesSubtotalTaxExc; // ���㏬�v�i�Ŕ����j
            frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXRF = salesSlipWork.SalesSubtotalTax; // ���㏬�v�i�Łj
            frePSalesSlipWork.SALESSLIPRF_ITDEDSALESOUTTAXRF = salesSlipWork.ItdedSalesOutTax; // ����O�őΏۊz
            frePSalesSlipWork.SALESSLIPRF_ITDEDSALESINTAXRF = salesSlipWork.ItdedSalesInTax; // ������őΏۊz
            frePSalesSlipWork.SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF = salesSlipWork.SalSubttlSubToTaxFre; // ���㏬�v��ېőΏۊz
            frePSalesSlipWork.SALESSLIPRF_SALAMNTCONSTAXINCLURF = salesSlipWork.SalAmntConsTaxInclu; // ������z����Ŋz�i���Łj
            frePSalesSlipWork.SALESSLIPRF_SALESDISTTLTAXEXCRF = salesSlipWork.SalesDisTtlTaxExc; // ����l�����z�v�i�Ŕ����j
            frePSalesSlipWork.SALESSLIPRF_ITDEDSALESDISOUTTAXRF = salesSlipWork.ItdedSalesDisOutTax; // ����l���O�őΏۊz���v
            frePSalesSlipWork.SALESSLIPRF_ITDEDSALESDISINTAXRF = salesSlipWork.ItdedSalesDisInTax; // ����l�����őΏۊz���v
            frePSalesSlipWork.SALESSLIPRF_SALESDISOUTTAXRF = salesSlipWork.SalesDisOutTax; // ����l������Ŋz�i�O�Łj
            frePSalesSlipWork.SALESSLIPRF_SALESDISTTLTAXINCLURF = salesSlipWork.SalesDisTtlTaxInclu; // ����l������Ŋz�i���Łj
            frePSalesSlipWork.SALESSLIPRF_TOTALCOSTRF = salesSlipWork.TotalCost; // �������z�v
            frePSalesSlipWork.SALESSLIPRF_CONSTAXLAYMETHODRF = salesSlipWork.ConsTaxLayMethod; // ����œ]�ŕ���
            frePSalesSlipWork.SALESSLIPRF_CONSTAXRATERF = salesSlipWork.ConsTaxRate; // ����Őŗ�
            frePSalesSlipWork.SALESSLIPRF_FRACTIONPROCCDRF = salesSlipWork.FractionProcCd; // �[�������敪
            frePSalesSlipWork.SALESSLIPRF_ACCRECCONSTAXRF = salesSlipWork.AccRecConsTax; // ���|�����
            frePSalesSlipWork.SALESSLIPRF_AUTODEPOSITCDRF = salesSlipWork.AutoDepositCd; // ���������敪
            frePSalesSlipWork.SALESSLIPRF_AUTODEPOSITSLIPNORF = salesSlipWork.AutoDepositSlipNo; // ���������`�[�ԍ�
            frePSalesSlipWork.SALESSLIPRF_DEPOSITALLOWANCETTLRF = salesSlipWork.DepositAllowanceTtl; // �����������v�z
            frePSalesSlipWork.SALESSLIPRF_DEPOSITALWCBLNCERF = salesSlipWork.DepositAlwcBlnce; // ���������c��
            frePSalesSlipWork.SALESSLIPRF_CLAIMCODERF = salesSlipWork.ClaimCode; // ������R�[�h
            frePSalesSlipWork.SALESSLIPRF_CLAIMSNMRF = salesSlipWork.ClaimSnm; // �����旪��
            frePSalesSlipWork.SALESSLIPRF_CUSTOMERCODERF = salesSlipWork.CustomerCode; // ���Ӑ�R�[�h
            frePSalesSlipWork.SALESSLIPRF_CUSTOMERNAMERF = salesSlipWork.CustomerName; // ���Ӑ於��
            frePSalesSlipWork.SALESSLIPRF_CUSTOMERNAME2RF = salesSlipWork.CustomerName2; // ���Ӑ於��2
            frePSalesSlipWork.SALESSLIPRF_CUSTOMERSNMRF = salesSlipWork.CustomerSnm; // ���Ӑ旪��
            frePSalesSlipWork.SALESSLIPRF_HONORIFICTITLERF = salesSlipWork.HonorificTitle; // �h��
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEECODERF = salesSlipWork.AddresseeCode; // �[�i��R�[�h
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEENAMERF = salesSlipWork.AddresseeName; // �[�i�於��
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEENAME2RF = salesSlipWork.AddresseeName2; // �[�i�於��2
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEPOSTNORF = salesSlipWork.AddresseePostNo; // �[�i��X�֔ԍ�
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR1RF = salesSlipWork.AddresseeAddr1; // �[�i��Z��1(�s���{���s��S�E�����E��)
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR3RF = salesSlipWork.AddresseeAddr3; // �[�i��Z��3(�Ԓn)
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR4RF = salesSlipWork.AddresseeAddr4; // �[�i��Z��4(�A�p�[�g����)
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEETELNORF = salesSlipWork.AddresseeTelNo; // �[�i��d�b�ԍ�
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEFAXNORF = salesSlipWork.AddresseeFaxNo; // �[�i��FAX�ԍ�
            frePSalesSlipWork.SALESSLIPRF_PARTYSALESLIPNUMRF = salesSlipWork.PartySaleSlipNum; // �����`�[�ԍ�
            frePSalesSlipWork.SALESSLIPRF_SLIPNOTERF = salesSlipWork.SlipNote; // �`�[���l
            frePSalesSlipWork.SALESSLIPRF_SLIPNOTE2RF = salesSlipWork.SlipNote2; // �`�[���l�Q
            frePSalesSlipWork.SALESSLIPRF_RETGOODSREASONDIVRF = salesSlipWork.RetGoodsReasonDiv; // �ԕi���R�R�[�h
            frePSalesSlipWork.SALESSLIPRF_RETGOODSREASONRF = salesSlipWork.RetGoodsReason; // �ԕi���R
            frePSalesSlipWork.SALESSLIPRF_REGIPROCDATERF = ToLongDate( salesSlipWork.RegiProcDate ); // ���W������
            frePSalesSlipWork.SALESSLIPRF_CASHREGISTERNORF = salesSlipWork.CashRegisterNo; // ���W�ԍ�
            frePSalesSlipWork.SALESSLIPRF_POSRECEIPTNORF = salesSlipWork.PosReceiptNo; // POS���V�[�g�ԍ�
            frePSalesSlipWork.SALESSLIPRF_DETAILROWCOUNTRF = salesSlipWork.DetailRowCount; // ���׍s��
            frePSalesSlipWork.SALESSLIPRF_EDISENDDATERF = ToLongDate( salesSlipWork.EdiSendDate ); // �d�c�h���M��
            frePSalesSlipWork.SALESSLIPRF_EDITAKEINDATERF = ToLongDate( salesSlipWork.EdiTakeInDate ); // �d�c�h�捞��
            frePSalesSlipWork.SALESSLIPRF_UOEREMARK1RF = salesSlipWork.UoeRemark1; // �t�n�d���}�[�N�P
            frePSalesSlipWork.SALESSLIPRF_UOEREMARK2RF = salesSlipWork.UoeRemark2; // �t�n�d���}�[�N�Q
            frePSalesSlipWork.SALESSLIPRF_SLIPPRINTFINISHCDRF = salesSlipWork.SlipPrintFinishCd; // �`�[���s�ϋ敪
            frePSalesSlipWork.SALESSLIPRF_SALESSLIPPRINTDATERF = ToLongDate( salesSlipWork.SalesSlipPrintDate ); // ����`�[���s��
            frePSalesSlipWork.SALESSLIPRF_BUSINESSTYPECODERF = salesSlipWork.BusinessTypeCode; // �Ǝ�R�[�h
            frePSalesSlipWork.SALESSLIPRF_BUSINESSTYPENAMERF = salesSlipWork.BusinessTypeName; // �Ǝ햼��
            frePSalesSlipWork.SALESSLIPRF_ORDERNUMBERRF = salesSlipWork.OrderNumber; // �����ԍ�
            frePSalesSlipWork.SALESSLIPRF_DELIVEREDGOODSDIVRF = salesSlipWork.DeliveredGoodsDiv; // �[�i�敪
            frePSalesSlipWork.SALESSLIPRF_DELIVEREDGOODSDIVNMRF = salesSlipWork.DeliveredGoodsDivNm; // �[�i�敪����
            frePSalesSlipWork.SALESSLIPRF_SALESAREACODERF = salesSlipWork.SalesAreaCode; // �̔��G���A�R�[�h
            frePSalesSlipWork.SALESSLIPRF_SALESAREANAMERF = salesSlipWork.SalesAreaName; // �̔��G���A����
            frePSalesSlipWork.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF = salesSlipWork.StockGoodsTtlTaxExc; // �݌ɏ��i���v���z�i�Ŕ��j
            frePSalesSlipWork.SALESSLIPRF_PUREGOODSTTLTAXEXCRF = salesSlipWork.PureGoodsTtlTaxExc; // �������i���v���z�i�Ŕ��j
            frePSalesSlipWork.SALESSLIPRF_LISTPRICEPRINTDIVRF = salesSlipWork.ListPricePrintDiv; // �艿����敪
            frePSalesSlipWork.SALESSLIPRF_ERANAMEDISPCD1RF = salesSlipWork.EraNameDispCd1; // �����\���敪�P
            frePSalesSlipWork.SALESSLIPRF_ESTIMATAXDIVCDRF = salesSlipWork.EstimaTaxDivCd; // ���Ϗ���ŋ敪
            frePSalesSlipWork.SALESSLIPRF_ESTIMATEFORMPRTCDRF = salesSlipWork.EstimateFormPrtCd; // ���Ϗ�����敪
            frePSalesSlipWork.SALESSLIPRF_ESTIMATESUBJECTRF = salesSlipWork.EstimateSubject; // ���ό���
            frePSalesSlipWork.SALESSLIPRF_FOOTNOTES1RF = salesSlipWork.Footnotes1; // �r���P
            frePSalesSlipWork.SALESSLIPRF_FOOTNOTES2RF = salesSlipWork.Footnotes2; // �r���Q
            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE1RF = salesSlipWork.EstimateTitle1; // ���σ^�C�g���P
            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE2RF = salesSlipWork.EstimateTitle2; // ���σ^�C�g���Q
            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE3RF = salesSlipWork.EstimateTitle3; // ���σ^�C�g���R
            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE4RF = salesSlipWork.EstimateTitle4; // ���σ^�C�g���S
            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE5RF = salesSlipWork.EstimateTitle5; // ���σ^�C�g���T
            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE1RF = salesSlipWork.EstimateNote1; // ���ϔ��l�P
            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE2RF = salesSlipWork.EstimateNote2; // ���ϔ��l�Q
            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE3RF = salesSlipWork.EstimateNote3; // ���ϔ��l�R
            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE4RF = salesSlipWork.EstimateNote4; // ���ϔ��l�S
            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE5RF = salesSlipWork.EstimateNote5; // ���ϔ��l�T
            frePSalesSlipWork.SALESSLIPRF_SLIPNOTE3RF = salesSlipWork.SlipNote3; // �`�[���l�R
            frePSalesSlipWork.SALESSLIPRF_RESULTSADDUPSECCDRF = salesSlipWork.ResultsAddUpSecCd; // ���ьv�㋒�_�R�[�h
            # endregion

            return frePSalesSlipWork;
        }
        /// <summary>
        /// UOE�`�[�p �f�[�^�ڍs�����i���㖾��work�����R���[���㖾��work�j
        /// </summary>
        /// <param name="salesDetailWork"></param>
        /// <returns></returns>
        public static FrePSalesDetailWork CopyToFrePSalesDetailWorkFromSalesDetail( SalesDetailWork salesDetailWork )
        {
            FrePSalesDetailWork frePSalesDetailWork = new FrePSalesDetailWork();

            # region [copy]
            frePSalesDetailWork.SALESDETAILRF_ACPTANODRSTATUSRF = salesDetailWork.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            frePSalesDetailWork.SALESDETAILRF_SALESSLIPNUMRF = salesDetailWork.SalesSlipNum; // ����`�[�ԍ�
            frePSalesDetailWork.SALESDETAILRF_ACCEPTANORDERNORF = salesDetailWork.AcceptAnOrderNo; // �󒍔ԍ�
            frePSalesDetailWork.SALESDETAILRF_SALESROWNORF = salesDetailWork.SalesRowNo; // ����s�ԍ�
            frePSalesDetailWork.SALESDETAILRF_SALESDATERF = ToLongDate( salesDetailWork.SalesDate ); // ������t
            frePSalesDetailWork.SALESDETAILRF_COMMONSEQNORF = salesDetailWork.CommonSeqNo; // ���ʒʔ�
            frePSalesDetailWork.SALESDETAILRF_SALESSLIPDTLNUMRF = salesDetailWork.SalesSlipDtlNum; // ���㖾�גʔ�
            frePSalesDetailWork.SALESDETAILRF_ACPTANODRSTATUSSRCRF = salesDetailWork.AcptAnOdrStatusSrc; // �󒍃X�e�[�^�X�i���j
            frePSalesDetailWork.SALESDETAILRF_SALESSLIPDTLNUMSRCRF = salesDetailWork.SalesSlipDtlNumSrc; // ���㖾�גʔԁi���j
            frePSalesDetailWork.SALESDETAILRF_SUPPLIERFORMALSYNCRF = salesDetailWork.SupplierFormalSync; // �d���`���i�����j
            frePSalesDetailWork.SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF = salesDetailWork.StockSlipDtlNumSync; // �d�����גʔԁi�����j
            frePSalesDetailWork.SALESDETAILRF_SALESSLIPCDDTLRF = salesDetailWork.SalesSlipCdDtl; // ����`�[�敪�i���ׁj
            frePSalesDetailWork.SALESDETAILRF_DELIGDSCMPLTDUEDATERF = ToLongDate( salesDetailWork.DeliGdsCmpltDueDate ); // �[�i�����\���
            frePSalesDetailWork.SALESDETAILRF_GOODSKINDCODERF = salesDetailWork.GoodsKindCode; // ���i����
            frePSalesDetailWork.SALESDETAILRF_GOODSMAKERCDRF = salesDetailWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            frePSalesDetailWork.SALESDETAILRF_MAKERNAMERF = salesDetailWork.MakerName; // ���[�J�[����
            frePSalesDetailWork.SALESDETAILRF_GOODSNORF = salesDetailWork.GoodsNo; // ���i�ԍ�
            frePSalesDetailWork.SALESDETAILRF_GOODSNAMERF = salesDetailWork.GoodsName; // ���i����
            frePSalesDetailWork.SALESDETAILRF_BLGOODSCODERF = salesDetailWork.BLGoodsCode; // BL���i�R�[�h
            frePSalesDetailWork.SALESDETAILRF_BLGOODSFULLNAMERF = salesDetailWork.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
            frePSalesDetailWork.SALESDETAILRF_ENTERPRISEGANRECODERF = salesDetailWork.EnterpriseGanreCode; // ���Е��ރR�[�h
            frePSalesDetailWork.SALESDETAILRF_ENTERPRISEGANRENAMERF = salesDetailWork.EnterpriseGanreName; // ���Е��ޖ���
            frePSalesDetailWork.SALESDETAILRF_WAREHOUSECODERF = salesDetailWork.WarehouseCode; // �q�ɃR�[�h
            frePSalesDetailWork.SALESDETAILRF_WAREHOUSENAMERF = salesDetailWork.WarehouseName; // �q�ɖ���
            frePSalesDetailWork.SALESDETAILRF_WAREHOUSESHELFNORF = salesDetailWork.WarehouseShelfNo; // �q�ɒI��
            frePSalesDetailWork.SALESDETAILRF_SALESORDERDIVCDRF = salesDetailWork.SalesOrderDivCd; // ����݌Ɏ�񂹋敪
            frePSalesDetailWork.SALESDETAILRF_OPENPRICEDIVRF = salesDetailWork.OpenPriceDiv; // �I�[�v�����i�敪
            frePSalesDetailWork.SALESDETAILRF_GOODSRATERANKRF = salesDetailWork.GoodsRateRank; // ���i�|�������N
            frePSalesDetailWork.SALESDETAILRF_CUSTRATEGRPCODERF = salesDetailWork.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
            frePSalesDetailWork.SALESDETAILRF_LISTPRICERATERF = salesDetailWork.ListPriceRate; // �艿��
            frePSalesDetailWork.SALESDETAILRF_LISTPRICETAXINCFLRF = salesDetailWork.ListPriceTaxIncFl; // �艿�i�ō��C�����j
            frePSalesDetailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF = salesDetailWork.ListPriceTaxExcFl; // �艿�i�Ŕ��C�����j
            frePSalesDetailWork.SALESDETAILRF_LISTPRICECHNGCDRF = salesDetailWork.ListPriceChngCd; // �艿�ύX�敪
            frePSalesDetailWork.SALESDETAILRF_SALESRATERF = salesDetailWork.SalesRate; // ������
            frePSalesDetailWork.SALESDETAILRF_SALESUNPRCTAXINCFLRF = salesDetailWork.SalesUnPrcTaxIncFl; // ����P���i�ō��C�����j
            frePSalesDetailWork.SALESDETAILRF_SALESUNPRCTAXEXCFLRF = salesDetailWork.SalesUnPrcTaxExcFl; // ����P���i�Ŕ��C�����j
            frePSalesDetailWork.SALESDETAILRF_COSTRATERF = salesDetailWork.CostRate; // ������
            frePSalesDetailWork.SALESDETAILRF_SALESUNITCOSTRF = salesDetailWork.SalesUnitCost; // �����P��
            frePSalesDetailWork.SALESDETAILRF_SHIPMENTCNTRF = salesDetailWork.ShipmentCnt; // �o�א�
            frePSalesDetailWork.SALESDETAILRF_ACCEPTANORDERCNTRF = salesDetailWork.AcceptAnOrderCnt; // �󒍐���
            frePSalesDetailWork.SALESDETAILRF_ACPTANODRADJUSTCNTRF = salesDetailWork.AcptAnOdrAdjustCnt; // �󒍒�����
            frePSalesDetailWork.SALESDETAILRF_ACPTANODRREMAINCNTRF = salesDetailWork.AcptAnOdrRemainCnt; // �󒍎c��
            frePSalesDetailWork.SALESDETAILRF_REMAINCNTUPDDATERF = ToLongDate( salesDetailWork.RemainCntUpdDate ); // �c���X�V��
            frePSalesDetailWork.SALESDETAILRF_SALESMONEYTAXINCRF = salesDetailWork.SalesMoneyTaxInc; // ������z�i�ō��݁j
            frePSalesDetailWork.SALESDETAILRF_SALESMONEYTAXEXCRF = salesDetailWork.SalesMoneyTaxExc; // ������z�i�Ŕ����j
            frePSalesDetailWork.SALESDETAILRF_COSTRF = salesDetailWork.Cost; // ����
            frePSalesDetailWork.SALESDETAILRF_GRSPROFITCHKDIVRF = salesDetailWork.GrsProfitChkDiv; // �e���`�F�b�N�敪
            frePSalesDetailWork.SALESDETAILRF_SALESGOODSCDRF = salesDetailWork.SalesGoodsCd; // ���㏤�i�敪
            frePSalesDetailWork.SALESDETAILRF_TAXATIONDIVCDRF = salesDetailWork.TaxationDivCd; // �ېŋ敪
            frePSalesDetailWork.SALESDETAILRF_PARTYSLIPNUMDTLRF = salesDetailWork.PartySlipNumDtl; // �����`�[�ԍ��i���ׁj
            frePSalesDetailWork.SALESDETAILRF_DTLNOTERF = salesDetailWork.DtlNote; // ���ה��l
            frePSalesDetailWork.SALESDETAILRF_SUPPLIERCDRF = salesDetailWork.SupplierCd; // �d����R�[�h
            frePSalesDetailWork.SALESDETAILRF_SUPPLIERSNMRF = salesDetailWork.SupplierSnm; // �d���旪��
            frePSalesDetailWork.SALESDETAILRF_ORDERNUMBERRF = salesDetailWork.OrderNumber; // �����ԍ�
            frePSalesDetailWork.SALESDETAILRF_SLIPMEMO1RF = salesDetailWork.SlipMemo1; // �`�[�����P
            frePSalesDetailWork.SALESDETAILRF_SLIPMEMO2RF = salesDetailWork.SlipMemo2; // �`�[�����Q
            frePSalesDetailWork.SALESDETAILRF_SLIPMEMO3RF = salesDetailWork.SlipMemo3; // �`�[�����R
            frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO1RF = salesDetailWork.InsideMemo1; // �Г������P
            frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO2RF = salesDetailWork.InsideMemo2; // �Г������Q
            frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO3RF = salesDetailWork.InsideMemo3; // �Г������R
            frePSalesDetailWork.SALESDETAILRF_BFLISTPRICERF = salesDetailWork.BfListPrice; // �ύX�O�艿
            frePSalesDetailWork.SALESDETAILRF_BFSALESUNITPRICERF = salesDetailWork.BfSalesUnitPrice; // �ύX�O����
            frePSalesDetailWork.SALESDETAILRF_BFUNITCOSTRF = salesDetailWork.BfUnitCost; // �ύX�O����
            frePSalesDetailWork.SALESDETAILRF_CMPLTSALESROWNORF = salesDetailWork.CmpltSalesRowNo; // �ꎮ���הԍ�
            frePSalesDetailWork.SALESDETAILRF_CMPLTGOODSMAKERCDRF = salesDetailWork.CmpltGoodsMakerCd; // ���[�J�[�R�[�h�i�ꎮ�j
            frePSalesDetailWork.SALESDETAILRF_CMPLTMAKERNAMERF = salesDetailWork.CmpltMakerName; // ���[�J�[���́i�ꎮ�j
            frePSalesDetailWork.SALESDETAILRF_CMPLTGOODSNAMERF = salesDetailWork.CmpltGoodsName; // ���i���́i�ꎮ�j
            frePSalesDetailWork.SALESDETAILRF_CMPLTSHIPMENTCNTRF = salesDetailWork.CmpltShipmentCnt; // ���ʁi�ꎮ�j
            frePSalesDetailWork.SALESDETAILRF_CMPLTSALESUNPRCFLRF = salesDetailWork.CmpltSalesUnPrcFl; // ����P���i�ꎮ�j
            frePSalesDetailWork.SALESDETAILRF_CMPLTSALESMONEYRF = salesDetailWork.CmpltSalesMoney; // ������z�i�ꎮ�j
            frePSalesDetailWork.SALESDETAILRF_CMPLTSALESUNITCOSTRF = salesDetailWork.CmpltSalesUnitCost; // �����P���i�ꎮ�j
            frePSalesDetailWork.SALESDETAILRF_CMPLTCOSTRF = salesDetailWork.CmpltCost; // �������z�i�ꎮ�j
            frePSalesDetailWork.SALESDETAILRF_CMPLTPARTYSALSLNUMRF = salesDetailWork.CmpltPartySalSlNum; // �����`�[�ԍ��i�ꎮ�j
            frePSalesDetailWork.SALESDETAILRF_CMPLTNOTERF = salesDetailWork.CmpltNote; // �ꎮ���l
            frePSalesDetailWork.SALESDETAILRF_PRTBLGOODSCODERF = salesDetailWork.PrtBLGoodsCode; // BL���i�R�[�h�i����j
            frePSalesDetailWork.SALESDETAILRF_PRTBLGOODSNAMERF = salesDetailWork.PrtBLGoodsName; // BL���i�R�[�h���́i����j
            frePSalesDetailWork.SALESDETAILRF_PRTGOODSNORF = salesDetailWork.PrtGoodsNo; // ����p�i��
            frePSalesDetailWork.SALESDETAILRF_PRTMAKERCODERF = salesDetailWork.PrtMakerCode; // ����p���[�J�[�R�[�h
            frePSalesDetailWork.SALESDETAILRF_PRTMAKERNAMERF = salesDetailWork.PrtMakerName; // ����p���[�J�[����
            frePSalesDetailWork.SALESDETAILRF_GOODSLGROUPRF = salesDetailWork.GoodsLGroup; // ���i�啪�ރR�[�h
            frePSalesDetailWork.SALESDETAILRF_GOODSLGROUPNAMERF = salesDetailWork.GoodsLGroupName; // ���i�啪�ޖ���
            frePSalesDetailWork.SALESDETAILRF_GOODSMGROUPRF = salesDetailWork.GoodsMGroup; // ���i�����ރR�[�h
            frePSalesDetailWork.SALESDETAILRF_GOODSMGROUPNAMERF = salesDetailWork.GoodsMGroupName; // ���i�����ޖ���
            frePSalesDetailWork.SALESDETAILRF_BLGROUPCODERF = salesDetailWork.BLGroupCode; // BL�O���[�v�R�[�h
            frePSalesDetailWork.SALESDETAILRF_BLGROUPNAMERF = salesDetailWork.BLGroupName; // BL�O���[�v�R�[�h����
            frePSalesDetailWork.SALESDETAILRF_SALESCODERF = salesDetailWork.SalesCode; // �̔��敪�R�[�h
            frePSalesDetailWork.SALESDETAILRF_SALESCDNMRF = salesDetailWork.SalesCdNm; // �̔��敪����
            frePSalesDetailWork.SALESDETAILRF_GOODSNAMEKANARF = salesDetailWork.GoodsNameKana; // ���i���̃J�i
            frePSalesDetailWork.SALESDETAILRF_AUTOANSWERDIVSCMRF = salesDetailWork.AutoAnswerDivSCM; // �����񓚋敪(SCM)// ADD 2011/07/29
            # endregion

            return frePSalesDetailWork;
        }
        /// <summary>
        /// ���t�ϊ�����
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int ToLongDate( DateTime date )
        {
            if ( date == DateTime.MinValue )
            {
                return 0;
            }
            else
            {
                try
                {
                    return (date.Year * 10000) + (date.Month * 100) + date.Day;
                }
                catch
                {
                    return 0;
                }
            }
        }
        # endregion
        # endregion

        # region [�}�X�^�擾]

        # region [�`�[����ݒ�擾]

        # region [�`�[����ݒ�擾�E����p]
        /// <summary>
        /// �f�t�H���g�`�[����p���[�h�c�擾�����i����p�j
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="slipWork"></param>
        /// <returns></returns>
        private CustSlipMngWork GetSlipPrintTypeDefault( int slipKind, FrePSalesSlipWork slipWork )
        {
            CustSlipMngWork custSlipMngWork = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            if ( slipWork.SALESSLIPRF_CUSTOMERCODERF != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
            {
                // ���Ӑ斈[���_=0]
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, ct_SectionZero, slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind );
                if ( custSlipMngWork == null )
                {
                    // �����̃e�[�u���̃f�[�^�Z�b�g�d�l���s����Ȃ̂ŁA���_��"0"����������
                    custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, "0", slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind );
                }
            }

            // ���_��[���Ӑ�=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, _loginSectionCode, ct_CustomerZero, slipKind );
            }

            // �S�Аݒ�[���_=0,���Ӑ�=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, ct_SectionZero, ct_CustomerZero, slipKind );
                if ( custSlipMngWork == null )
                {
                    // �����̃e�[�u���̃f�[�^�Z�b�g�d�l���s����Ȃ̂ŁA���_��"0"����������
                    custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, "0", ct_CustomerZero, slipKind );
                }
            }
            return custSlipMngWork;
        }

        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
        /// <summary>
        /// �f�t�H���g�`�[����p���[�h�c�擾�����i���ナ���[�g�`�[���s�p�j
        /// </summary>
        /// <param name="slipKind">�`�[���</param>
        /// <param name="slipWork">����`�[�f�[�^</param>
        /// <returns>�f�t�H���g�`�[����p���[�h�c</returns>
        private RmSlpPrtStWork GetRemoteSlipPrintTypeDefault(int slipKind, FrePSalesSlipWork slipWork)
        {
            RmSlpPrtStWork rmSlpPrtStWork = null;

            if (slipWork.SALESSLIPRF_CUSTOMERCODERF != 0)
            {
                // ���Ӑ斈[���_=0]
                rmSlpPrtStWork = FindRmSlpPrtStWork(_enterpriseCode, _loginSectionCode, slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind);
            }
            return rmSlpPrtStWork;
        }
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end

        /// <summary>
        /// �f�t�H���g�̓`�[�o�͐�ݒ�擾�i����p�j
        /// </summary>
        /// <param name="slipPrtKind">�`�[���</param>
        /// <param name="slipPrtSetPaperId">�`�[����p���[�h�c</param>
        /// <param name="cashRegisterNo">���W�ԍ�</param>
        /// <param name="slipWork">����`�[�f�[�^</param>
        /// <param name="detailWork">���㖾�׃f�[�^</param>
        /// <param name="eachWarehouseSetEnable">�q�ɖ��ݒ�L���敪</param>
        /// <returns>�`�[�o�͐�ݒ�work</returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 DEL
        //private SlipOutputSetWork GetSlipOutputSetDefault( int slipPrtKind, string slipPrtSetPaperId, int cashRegisterNo, FrePSalesSlipWork slipWork, FrePSalesDetailWork detailWork )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
        private SlipOutputSetWork GetSlipOutputSetDefault( int slipPrtKind, string slipPrtSetPaperId, int cashRegisterNo, FrePSalesSlipWork slipWork, FrePSalesDetailWork detailWork, bool eachWarehouseSetEnable )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
        {
            SlipOutputSetWork slipOutputSetWork = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
            if ( eachWarehouseSetEnable )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
            {
                // �q�ɖ��i�q�Ɂ{���W�j[���_=0]
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, cashRegisterNo, detailWork.SALESDETAILRF_WAREHOUSECODERF, slipPrtKind, slipPrtSetPaperId );
            }

            // ���W��[���_=0,�q��=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, cashRegisterNo, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }

            // ���_��[�q��=0,���W=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, _loginSectionCode, ct_CashRegisterZero, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }

            // �S�Аݒ�[���_=0,�q��=0,���W=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, ct_CashRegisterZero, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }
            return slipOutputSetWork;
        }
        # endregion

        # region [�`�[����ݒ�擾�E���Ϗ��p]
        /// <summary>
        /// �f�t�H���g�`�[����p���[�h�c�擾�����i���Ϗ��p�j
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="slipWork"></param>
        /// <returns></returns>
        private CustSlipMngWork GetSlipPrintTypeDefaultForEstFm( int slipKind, FrePSalesSlipWork slipWork )
        {
            CustSlipMngWork custSlipMngWork = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            if ( slipWork.SALESSLIPRF_CUSTOMERCODERF != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
            {
                // ���Ӑ斈[���_=0]
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, ct_SectionZero, slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind );
                if ( custSlipMngWork == null )
                {
                    // �����̃e�[�u���̃f�[�^�Z�b�g�d�l���s����Ȃ̂ŁA���_��"0"����������
                    custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, "0", slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind );
                }
            }

            // ���_��[���Ӑ�=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, _loginSectionCode, ct_CustomerZero, slipKind );
            }

            // �S�Аݒ�[���_=0,���Ӑ�=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, ct_SectionZero, ct_CustomerZero, slipKind );
                if ( custSlipMngWork == null )
                {
                    // �����̃e�[�u���̃f�[�^�Z�b�g�d�l���s����Ȃ̂ŁA���_��"0"����������
                    custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, "0", ct_CustomerZero, slipKind );
                }
            }
            return custSlipMngWork;
        }
        /// <summary>
        /// �f�t�H���g�̓`�[�o�͐�ݒ�擾�i���Ϗ��p�j
        /// </summary>
        /// <param name="slipPrtKind">�`�[���</param>
        /// <param name="slipPrtSetPaperId">�`�[����p���[�h�c</param>
        /// <param name="cashRegisterNo">���W�ԍ�</param>
        /// <param name="slipWork">���Ϗ��w�b�_�f�[�^</param>
        /// <returns>�`�[�o�͐�ݒ�work</returns>
        private SlipOutputSetWork GetSlipOutputSetDefaultForEstFm( int slipPrtKind, string slipPrtSetPaperId, int cashRegisterNo, FrePSalesSlipWork slipWork )
        {
            SlipOutputSetWork slipOutputSetWork = null;

            //// �q�ɖ��i�q�Ɂ{���W�j[���_=0]
            //slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, cashRegisterNo, detailWork.SALESDETAILRF_WAREHOUSECODERF, slipPrtKind, slipPrtSetPaperId );

            // ���W��[���_=0,�q��=0]
            //if ( slipOutputSetWork == null )
            //{
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, cashRegisterNo, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            //}

            // ���_��[�q��=0,���W=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, _loginSectionCode, ct_CashRegisterZero, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }

            // �S�Аݒ�[���_=0,�q��=0,���W=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, ct_CashRegisterZero, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }
            return slipOutputSetWork;
        }
        # endregion

        # region [�`�[����ݒ�擾�E�݌Ɉړ��p]
        /// <summary>
        /// �f�t�H���g�`�[����p���[�h�c�擾�����i�݌Ɉړ��p�j
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="slipWork"></param>
        /// <returns></returns>
        private CustSlipMngWork GetSlipPrintTypeDefault( int slipKind, FrePStockMoveSlipWork slipWork )
        {
            CustSlipMngWork custSlipMngWork = null;

            //// ���Ӑ斈[���_=0]
            //custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, ct_SectionZero, slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind );
            //if ( custSlipMngWork == null )
            //{
            //    // �����̃e�[�u���̃f�[�^�Z�b�g�d�l���s����Ȃ̂ŁA���_��"0"����������
            //    custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, "0", slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind );
            //}

            // ���_��[���Ӑ�=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, _loginSectionCode, ct_CustomerZero, slipKind );
            }

            // �S�Аݒ�[���_=0,���Ӑ�=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, ct_SectionZero, ct_CustomerZero, slipKind );
                if ( custSlipMngWork == null )
                {
                    // �����̃e�[�u���̃f�[�^�Z�b�g�d�l���s����Ȃ̂ŁA���_��"0"����������
                    custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, "0", ct_CustomerZero, slipKind );
                }
            }
            return custSlipMngWork;
        }
        /// <summary>
        /// �f�t�H���g�̓`�[�o�͐�ݒ�擾�i�݌Ɉړ��p�j
        /// </summary>
        /// <param name="slipPrtKind">�`�[���</param>
        /// <param name="slipPrtSetPaperId">�`�[����p���[�h�c</param>
        /// <param name="cashRegisterNo">���W�ԍ�</param>
        /// <param name="slipWork">����`�[�f�[�^</param>
        /// <param name="detailWork">���㖾�׃f�[�^</param>
        /// <returns>�`�[�o�͐�ݒ�work</returns>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br>           : Redmine#43854�u�ړ��`�[�o�͐�敪�v���v�����^����</br>
        private SlipOutputSetWork GetSlipOutputSetDefault( int slipPrtKind, string slipPrtSetPaperId, int cashRegisterNo, FrePStockMoveSlipWork slipWork, FrePStockMoveDetailWork detailWork )
        {
            SlipOutputSetWork slipOutputSetWork = null;
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 �u�ړ��`�[�o�͐�敪�v���v�����^����--------->>>>
            // �ړ��`�[�o�͐�敪�擾
            int moveSlipOutPutDiv = 0;
            StockMngTtlStWork stockMngTtlStWork = this.GetStockMngTtlSt();
            if (stockMngTtlStWork != null)
            {
                moveSlipOutPutDiv = stockMngTtlStWork.MoveSlipOutPutDiv;
            }
            // �u�ړ��`�[�o�͐�敪�v�ɂ��݌ɃR�[�h���o�ɃR�[�h���I��
            string enterWareHCode = moveSlipOutPutDiv == 0 ? slipWork.MOVH_AFENTERWAREHCODERF : slipWork.MOVH_BFENTERWAREHCODERF;
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 �u�ړ��`�[�o�͐�敪�v���v�����^����---------<<<<

            // �q�ɖ��i�q�Ɂ{���W�j[���_=0] �i���ړ���q�ɂɂ�萧��j
            //slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, cashRegisterNo, slipWork.MOVH_AFENTERWAREHCODERF, slipPrtKind, slipPrtSetPaperId ); // DEL wangf 2014/10/27 FOR Redmine#43854 �u�ړ��`�[�o�͐�敪�v���v�����^����
            slipOutputSetWork = FindSlipOutputSetWork(_enterpriseCode, ct_SectionZero, cashRegisterNo, enterWareHCode, slipPrtKind, slipPrtSetPaperId); // ADD wangf 2014/10/27 FOR Redmine#43854 �u�ړ��`�[�o�͐�敪�v���v�����^����

            // ���W��[���_=0,�q��=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, cashRegisterNo, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }

            // ���_��[�q��=0,���W=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, _loginSectionCode, ct_CashRegisterZero, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }

            // �S�Аݒ�[���_=0,�q��=0,���W=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, ct_CashRegisterZero, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }
            return slipOutputSetWork;
        }
        # endregion

        # region [�`�[����ݒ�擾�E����]
        /// <summary>
        /// �`�[�^�C�v���̃��X�g�擾����
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="printData"></param>
        /// <param name="defaultPrtTypeIndex"></param>
        /// <param name="defaultPrinterMngNo"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetSlipPrintTypeList( int slipKind, List<ArrayList> printData, out int defaultPrtTypeIndex, out int defaultPrinterMngNo  )
        {
            // �o�̓p�����[�^������
            defaultPrtTypeIndex = 0;
            defaultPrinterMngNo = 0;

            // �V�K�f�B�N�V���i��
            Dictionary<int, string> retDic = new Dictionary<int, string>();

            try
            {
                string defaultSlipPrtSetPaperId = string.Empty;

                # region [�����ʖ��̏��擾]
                switch ( slipKind )
                {
                    //----------------------------------------------------------
                    // 10:���Ϗ�
                    //----------------------------------------------------------
                    case 10:
                        {
                            FrePEstFmHead slipWork = (printData[0][0] as FrePEstFmHead);
                            // �f�t�H���g�̓`�[����p���[�h�c���擾
                            defaultSlipPrtSetPaperId = slipWork.HADD_SLIPPRTSETPAPERIDRF;
                            // �f�t�H���g�̃v�����^�Ǘ������擾
                            defaultPrinterMngNo = slipWork.HADD_PRINTERMNGNORF;
                        }
                        break;
                    //----------------------------------------------------------
                    // 40:�d���ԕi�`�[
                    //----------------------------------------------------------
                    case 40:
                        {

                        }
                        break;
                    //----------------------------------------------------------
                    // 150:�݌Ɉړ��`�[
                    //----------------------------------------------------------
                    case 150:
                        {
                            FrePStockMoveSlipWork slipWork = (printData[0][0] as FrePStockMoveSlipWork);
                            // �f�t�H���g�̓`�[����p���[�h�c���擾
                            defaultSlipPrtSetPaperId = slipWork.HADD_SLIPPRTSETPAPERIDRF;
                            // �f�t�H���g�̃v�����^�Ǘ������擾
                            defaultPrinterMngNo = slipWork.HADD_PRINTERMNGNORF;
                        }
                        break;
                    //----------------------------------------------------------
                    // 160:�t�n�d�`�[
                    //----------------------------------------------------------
                    case 160:
                        {
                            FrePSalesSlipWork slipWork = (printData[0][0] as FrePSalesSlipWork);
                            // �f�t�H���g�̓`�[����p���[�h�c���擾
                            defaultSlipPrtSetPaperId = slipWork.HADD_SLIPPRTSETPAPERIDRF;
                            // �f�t�H���g�̃v�����^�Ǘ������擾
                            defaultPrinterMngNo = slipWork.HADD_PRINTERMNGNORF;
                        }
                        break;
                    //----------------------------------------------------------
                    // ����E�󒍁E�o�ׁE���ϓ`�[
                    //----------------------------------------------------------
                    default:
                        {
                            FrePSalesSlipWork slipWork = (printData[0][0] as FrePSalesSlipWork);
                            // �f�t�H���g�̓`�[����p���[�h�c���擾
                            defaultSlipPrtSetPaperId = slipWork.HADD_SLIPPRTSETPAPERIDRF;
                            // �f�t�H���g�̃v�����^�Ǘ������擾
                            defaultPrinterMngNo = slipWork.HADD_PRINTERMNGNORF;
                        }
                        break;
                }
                # endregion

                // �`�[����ݒ胊�X�g����Y�����R�[�h�݂̂��f�B�N�V���i���ɒǉ�����
                if ( _slipPrtSetWorkList != null )
                {
                    for ( int index = 0; index < _slipPrtSetWorkList.Count; index++ )
                    {
                        SlipPrtSetWork slipPrtSetWork = _slipPrtSetWorkList[index];
                        if ( slipPrtSetWork.SlipPrtKind == slipKind )
                        {
                            // �����ɊY�����郌�R�[�h���f�B�N�V���i���ɒǉ�����B
                            retDic.Add( index, slipPrtSetWork.SlipComment );

                            // �f�t�H���g�h�c�ƈ�v������index��ޔ�
                            if ( slipPrtSetWork.SlipPrtSetPaperId == defaultSlipPrtSetPaperId )
                            {
                                defaultPrtTypeIndex = index;
                            }
                        }
                    }
                }

            }
            catch
            {
            }

            return retDic;
        }
        /// <summary>
        /// �I�� �`�[����ݒ� �擾����
        /// </summary>
        /// <param name="selectedIndex"></param>
        /// <returns></returns>
        public SlipPrtSetWork GetSlipPrtSetWork( int selectedIndex )
        {
            return _slipPrtSetWorkList[selectedIndex];
        }
        /// <summary>
        /// �f�t�H���g�`�[����p���[�h�c�擾����
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="printData"></param>
        /// <returns>�`�[����p���[�h�c�iSlipPrtSetPaperId�j</returns>
        private string GetSlipPrintTypeDefault( int slipKind, List<ArrayList> printData )
        {
            FrePSalesSlipWork slipWork = (FrePSalesSlipWork)printData[0][0];
            CustSlipMngWork custSlipMngWork = GetSlipPrintTypeDefault( slipKind, slipWork );

            if ( custSlipMngWork != null )
            {
                return custSlipMngWork.SlipPrtSetPaperId;
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// ���Ӑ�}�X�^�`�[�Ǘ��i�`�[�^�C�v�Ǘ��}�X�^�jFind����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="slipPrtKind">�`�[������</param>
        /// <returns></returns>
        private CustSlipMngWork FindCustSlipMngWork( string enterpriseCode, string sectionCode, int customerCode, int slipPrtKind )
        {
            if ( _custSlipMngWorkList == null ) return null;

            return _custSlipMngWorkList.Find(
                        delegate( CustSlipMngWork custSlipMngWork )
                        {
                            return (custSlipMngWork.EnterpriseCode == enterpriseCode)
                                    && ((custSlipMngWork.SectionCode.Trim() == sectionCode.Trim()) || ((sectionCode.Trim() == ct_SectionZero) && (custSlipMngWork.SectionCode.Trim() == string.Empty)))
                                    && (custSlipMngWork.CustomerCode == customerCode)
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                                    && (custSlipMngWork.LogicalDeleteCode == 0)
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
                                    && (custSlipMngWork.SlipPrtKind == slipPrtKind);
                        });
        }
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
        /// <summary>
        /// �����[�g�`�[���s�ݒ�Find����(�����[�g�`�[���s)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="slipPrtKind">�`�[������</param>
        /// <returns>�����[�g�`�[���s�ݒ���</returns>
        private RmSlpPrtStWork FindRmSlpPrtStWork(string enterpriseCode, string sectionCode, int customerCode, int slipPrtKind)
        {
            if (_rmSlpPrtStWorkList == null) return null;

            return _rmSlpPrtStWorkList.Find(
                        delegate(RmSlpPrtStWork rmSlpPrtStWork)
                        {
                            return (rmSlpPrtStWork.InqOtherEpCd == enterpriseCode)
                                    && ((rmSlpPrtStWork.InqOtherSecCd.Trim() == sectionCode.Trim()) || ((sectionCode.Trim() == ct_SectionZero) && (rmSlpPrtStWork.InqOtherSecCd.Trim() == string.Empty)))
                                    && (rmSlpPrtStWork.PccCompanyCode == customerCode)
                                    && (rmSlpPrtStWork.LogicalDeleteCode == 0)
                                    && (rmSlpPrtStWork.SlipPrtKind == slipPrtKind);
                        });
        }
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
        /// <summary>
        /// �`�[�o�͐�}�X�^Find����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="cashRegisterNo">���W�ԍ�</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="slipPrtKind">�`�[������</param>
        /// <param name="slipPrtSetPaperId">�`�[����p���[�h�c</param>
        /// <returns></returns>
        private SlipOutputSetWork FindSlipOutputSetWork( string enterpriseCode, string sectionCode, int cashRegisterNo, string warehouseCode, int slipPrtKind, string slipPrtSetPaperId )
        {
            if ( _slipOutputSetWorkList == null ) return null;

            return _slipOutputSetWorkList.Find(
                        delegate( SlipOutputSetWork slipOutputSetWork )
                        {
                            return (slipOutputSetWork.EnterpriseCode == enterpriseCode)
                                //&& (slipOutputSetWork.SectionCode == sectionCode)
                                    && (slipOutputSetWork.CashRegisterNo == cashRegisterNo)
                                    && ((slipOutputSetWork.WarehouseCode.Trim() == warehouseCode.Trim()) || ((warehouseCode.Trim() == ct_WarehouseZero) && (slipOutputSetWork.WarehouseCode.Trim() == string.Empty)))
                                    && (slipOutputSetWork.SlipPrtKind == slipPrtKind)
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                                    && (slipOutputSetWork.LogicalDeleteCode == 0)
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
                                    && (slipOutputSetWork.SlipPrtSetPaperId == slipPrtSetPaperId);
                        } );
        }
        # endregion

        # endregion

        # region [���R���[�󎚈ʒu�ݒ�擾]
        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ� �擾����
        /// </summary>
        /// <param name="slipPrtSet"></param>
        /// <returns></returns>
        /// <remarks>�`�[����ݒ�ƌ��т����R���[�󎚈ʒu�ݒ���擾���܂��B�Y�����Ȃ����null��Ԃ��܂��B</remarks>
        public FrePrtPSetWork GetFrePrtPSet( SlipPrtSetWork slipPrtSet )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
            //if ( slipPrtSet == null || _frePrtPSetWorkList == null || _frePrtPSetWorkList.Count <= 0 ) return null;

            //// �ǂݍ��݃L�[�擾
            //string outputFormFileName;
            //int userPrtPprIdDerivNo;
            //GetFrePrtPSetReadKey( slipPrtSet, out outputFormFileName, out userPrtPprIdDerivNo );

            //// �����ɍ��v���郌�R�[�h���擾
            //FrePrtPSetWork retWork = 
            //    _frePrtPSetWorkList.Find(
            //            delegate( FrePrtPSetWork frePrtPSetWork)
            //            {
            //                return ((frePrtPSetWork.OutputFormFileName == outputFormFileName)
            //                        && (frePrtPSetWork.UserPrtPprIdDerivNo == userPrtPprIdDerivNo));
            //            } );

            //if ( retWork != null && !_decryptedFrePrtPSetDic.ContainsKey( slipPrtSet.SlipPrtSetPaperId ) )
            //{
            //    // �󎚈ʒu�f�[�^�𕜍�������
            //    //�i�����ӁFretWork�X�V��_frePrtPSetWorkList�̊Y�����R�[�h�X�V���Ӗ����܂��j
            //    FrePrtSettingController.DecryptPrintPosClassData( retWork );
            //    // �������ς݃f�B�N�V���i���ɒǉ�����
            //    _decryptedFrePrtPSetDic.Add( slipPrtSet.SlipPrtSetPaperId, true );
            //}
            //return retWork;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
            if ( slipPrtSet == null || _frePrtPSetWorkList == null || _frePrtPSetWorkList.Count <= 0 ) return null;

            // �����ɍ��v���郌�R�[�h���擾
            FrePrtPSetWork retWork =
                _frePrtPSetWorkList.Find(
                        delegate( FrePrtPSetWork frePrtPSetWork )
                        {
                            return (frePrtPSetWork.OutputFormFileName == slipPrtSet.OutputFormFileName);
                        } );

            if ( retWork != null && !_decryptedFrePrtPSetDic.ContainsKey( retWork.OutputFormFileName ) )
            {
                // �󎚈ʒu�f�[�^�𕜍�������
                //�i�����ӁFretWork�X�V��_frePrtPSetWorkList�̊Y�����R�[�h�X�V���Ӗ����܂��j
                FrePrtSettingController.DecryptPrintPosClassData( retWork );
                // �������ς݃f�B�N�V���i���ɒǉ�����
                _decryptedFrePrtPSetDic.Add( retWork.OutputFormFileName, true );
            }
            return retWork;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
        ///// <summary>
        ///// ���R���[�󎚈ʒu�ݒ� �ǂݍ��݃L�[���擾
        ///// </summary>
        ///// <param name="slipPrtSetWork"></param>
        ///// <param name="outputFormFileName"></param>
        ///// <param name="userPrtPprIdDerivNo"></param>
        //private void GetFrePrtPSetReadKey( SlipPrtSetWork slipPrtSetWork, out string outputFormFileName, out int userPrtPprIdDerivNo )
        //{
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 DEL
        //    //outputFormFileName = slipPrtSetWork.OutputFormFileName;
        //    //userPrtPprIdDerivNo = 0;

        //    //if ( slipPrtSetWork.SlipPrtSetPaperId.StartsWith( slipPrtSetWork.OutputFormFileName ) )
        //    //{
        //    //    string derivNoText = slipPrtSetWork.SlipPrtSetPaperId.Substring( slipPrtSetWork.OutputFormFileName.Length, slipPrtSetWork.SlipPrtSetPaperId.Length - slipPrtSetWork.OutputFormFileName.Length );
        //    //    try
        //    //    {
        //    //        userPrtPprIdDerivNo = Int32.Parse( derivNoText );
        //    //    }
        //    //    catch
        //    //    {
        //    //        userPrtPprIdDerivNo = 0;
        //    //    }
        //    //}
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 DEL
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
        //    outputFormFileName = slipPrtSetWork.OutputFormFileName;
        //    try
        //    {
        //        userPrtPprIdDerivNo = Int32.Parse( slipPrtSetWork.SpecialPurpose2 );
        //    }
        //    catch
        //    {
        //        userPrtPprIdDerivNo = 0;
        //    }
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
        // --- ADD m.suzuki 2010/05/14 ---------->>>>>
        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�f�B�N�V���i���擾
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, FrePrtPSetWork> GetFrePrtPSetDic()
        {
            Dictionary<string, FrePrtPSetWork> dic = new Dictionary<string, FrePrtPSetWork>();

            foreach ( FrePrtPSetWork frePrtPSet in _frePrtPSetWorkList )
            {
                if ( !dic.ContainsKey( frePrtPSet.OutputFormFileName.Trim() ) )
                {
                    dic.Add( frePrtPSet.OutputFormFileName.Trim(), frePrtPSet );
                }
            }

            return dic;
        }
        /// <summary>
        /// �������ςݎ��R���[�󎚈ʒu�ݒ�f�B�N�V���i���擾
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, bool> GetDecryptedFrePrtPSetDic()
        {
            if ( _decryptedFrePrtPSetDic == null )
            {
                return new Dictionary<string, bool>();
            }
            return _decryptedFrePrtPSetDic;
        }
        // --- ADD m.suzuki 2010/05/14 ----------<<<<<
        # endregion

        # region [�v�����^�ݒ�擾]
        /// <summary>
        /// �v�����^�ݒ�@�S�擾
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        /// <remarks>���v�����^�Ǘ��ݒ�̓��[�J���w�l�k��ǂݍ��݂܂��B</remarks>
        public List<PrtManage> SearchAllPrtManage(string enterpriseCode)
        {
            List<PrtManage> prtManageList = new List<PrtManage>();

            ArrayList retList;
            _prtManageAcs.SearchAll( out retList, enterpriseCode );

            foreach ( PrtManage prtManage in retList )
            {
                if ( prtManage.LogicalDeleteCode == 0 )
                {
                    prtManageList.Add( prtManage );
                }
            }

            return prtManageList;
        }
        # endregion

        # region [�[���ݒ�擾]
        /// <summary>
        /// �[���ݒ�擾����
        /// </summary>
        /// <param name="posTerminalMg">POS�[���Ǘ��ݒ�</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        private int GetPosTerminalMg( out PosTerminalMg posTerminalMg, string enterpriseCode )
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search( out posTerminalMg, enterpriseCode );
        }
        // 2010/03/30 >>>
        /// <summary>
        /// �[���ݒ�擾����
        /// </summary>
        /// <param name="posTerminalMg">POS�[���Ǘ��ݒ�</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        private int GetPosTerminalMgServer( out PosTerminalMg posTerminalMg, string enterpriseCode )
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            ArrayList al = new ArrayList();
            posTerminalMg = new PosTerminalMg();

            int st = acs.SearchServer( out al, enterpriseCode );

            // �N���[���̃}�V�����Ɉ�v���郌�R�[�h�擾
            foreach ( PosTerminalMg pos in al )
            {
                if ( Environment.MachineName == pos.MachineName )
                {
                    posTerminalMg = pos;
                }
            }

            return st;
        }
        // 2010/03/30 <<<
        # endregion

        # region [����S�̐ݒ�擾]
        /// <summary>
        /// ����S�̐ݒ�擾����
        /// </summary>
        /// <returns></returns>
        public SalesTtlStWork GetSalesTtlSt()
        {
            // ���_��
            SalesTtlStWork retWork = FindSalesTtlSt( _loginSectionCode );
            if ( retWork == null )
            {
                // �S�Аݒ�[���_=0]
                retWork = FindSalesTtlSt( ct_SectionZero );
            }

            return retWork;
        }
        /// <summary>
        /// ����S�̐ݒ�Find����
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private SalesTtlStWork FindSalesTtlSt( string sectionCode )
        {
            if ( _salesTtlStWorkList == null ) return null;

            // ���_�R�[�h����v���郌�R�[�h��Ԃ�
            return _salesTtlStWorkList.Find(
                    delegate( SalesTtlStWork salesTtlStWork )
                    {
                        return (salesTtlStWork.SectionCode == sectionCode);
                    } );
        }
        # endregion

        # region [�S�̏����\���ݒ�擾]
        /// <summary>
        /// �S�̏����\���ݒ�擾����
        /// </summary>
        /// <returns></returns>
        public AllDefSetWork GetAllDefSet()
        {
            // ���_��
            AllDefSetWork retWork = FindAllDefSet( _loginSectionCode );
            if ( retWork == null )
            {
                // �S�Аݒ�[���_=0]
                retWork = FindAllDefSet( ct_SectionZero );
            }

            return retWork;
        }
        /// <summary>
        /// �S�̏����\���ݒ�Find����
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private AllDefSetWork FindAllDefSet( string sectionCode )
        {
            if ( _allDefSetWorkList == null ) return null;

            // ���_�R�[�h����v���郌�R�[�h��Ԃ�
            return _allDefSetWorkList.Find(
                    delegate( AllDefSetWork allDefSetWork )
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/08 DEL
                        //return (allDefSetWork.SectionCode == sectionCode);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/08 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/08 ADD
                        return (allDefSetWork.SectionCode.Trim() == sectionCode.Trim());
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/08 ADD
                    } );
        }
        # endregion

        # region [�݌ɊǗ��S�̐ݒ�擾]
        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�擾����
        /// </summary>
        /// <returns></returns>
        public StockMngTtlStWork GetStockMngTtlSt()
        {
            // ���_��
            StockMngTtlStWork retWork = FindStockMngTtlSt( _loginSectionCode );
            if ( retWork == null )
            {
                // �S�Аݒ�[���_=0]
                retWork = FindStockMngTtlSt( ct_SectionZero );
            }
            return retWork;
        }
        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�Find����
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br>           : Redmine#43854�u�ړ��`�[�o�͐�敪�v���v�����^����</br>
        private StockMngTtlStWork FindStockMngTtlSt( string sectionCode )
        {
            if ( _stockMngTtlStWorkList == null ) return null;

            // ���_�R�[�h����v���郌�R�[�h��Ԃ�
            return _stockMngTtlStWorkList.Find(
                    delegate( StockMngTtlStWork stockMngTtlStWork )
                    {
                        //return (stockMngTtlStWork.SectionCode == sectionCode); // DEL wangf 2014/10/27 FOR Redmine#43854 �u�ړ��`�[�o�͐�敪�v���v�����^����
                        return (stockMngTtlStWork.SectionCode.Trim() == sectionCode.Trim()); // ADD wangf 2014/10/27 FOR Redmine#43854 �u�ړ��`�[�o�͐�敪�v���v�����^����
                    } );
        }
        # endregion

        // --- ADD  ���r��  2010/03/04 ---------->>>>>
        #region [�ŗ��ݒ�擾]
        /// <summary>
        /// �ŗ��ݒ�擾����
        /// </summary>
        /// <returns></returns>
        public TaxRateSetWork GetTaxRateSet()
        {
            //TaxRateSetWork taxRate = FindTaxRateSet( _taxRateCode );
            //return taxRate;
            return FindTaxRateSet(ct_TaxRateCodeZero);
        }
        /// <summary>
        /// �ŗ��ݒ�Find����
        /// </summary>
        /// <param name="taxRateCode"></param>
        /// <returns></returns>
        private TaxRateSetWork FindTaxRateSet(Int32 taxRateCode)
        {
            if (_taxRateSetWorkList == null) return null;

            //�ŗ��R�[�h���u0:��ʏ���Łv�ƈ�v���郌�R�[�h��Ԃ�
            return _taxRateSetWorkList.Find(
                   delegate(TaxRateSetWork taxRateSetWork)
                   {
                       return (taxRateSetWork.TaxRateCode == taxRateCode);
                   }
                );
        }
        #endregion

        #region [������z�����敪�ݒ�擾]
        /// <summary>
        /// ������z�����敪�ݒ�擾
        /// </summary>
        /// <returns></returns>
        public List<SalesProcMoneyWork> GetSalesProcMoney()
        {
            return _salesProcMoneyList;
        }

        #endregion
        // --- ADD  ���r��  2010/03/04 ----------<<<<<
        // --- ADD  ���r��  2010/05/18 ---------->>>>>
        #region[UOE�K�C�h���̐ݒ�]
        /// <summary>
        /// UOE�K�C�h���̐ݒ�擾����
        /// </summary>
        /// <returns></returns>
        public UOEGuideNameWork GetUOEGuideName()
        {
            // ���_��
            UOEGuideNameWork retwork = FindUOEGuideName(_loginSectionCode);
            if (retwork == null)
            {
                // �S�̐ݒ�[���_=0]
                retwork = FindUOEGuideName(ct_SectionZero);
            }

            return retwork;
        }
        /// <summary>
        /// UOE�K�C�h����Find����
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private UOEGuideNameWork FindUOEGuideName(string sectionCode)
        {
            if (_uoeGuideNameWorkList == null) return null;

            // ���_�R�[�h����v���郌�R�[�h��Ԃ�
            return _uoeGuideNameWorkList.Find(
                delegate(UOEGuideNameWork uoeGuideNmWork)
                {
                    return (uoeGuideNmWork.SectionCode == sectionCode);
                } );
        }
        #endregion
        // --- ADD  ���r��  2010/05/18 ----------<<<<<

        # endregion

        # region [�`�[���X�g�U��KEY��`]
        // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
        # region [���ナ���[�g�`�[���X�g�U��KEY]
        /// <summary>
        /// ����`�[���X�g�U��KEY
        /// </summary>
        private struct RmSalesSlipListKey
        {
            /// <summary>�󒍃X�e�[�^�X</summary>
            private int _acptAnOdrStatus;
            /// <summary>�v�����^�Ǘ���</summary>
            private int _printerMngNo;
            /// <summary>����`�[�ԍ�</summary>
            private string _salesSlipNum;

            /// <summary>
            /// ����`�[�ԍ�
            /// </summary>
            public string SalesSlipNum
            {
                get { return _salesSlipNum; }
                set { _salesSlipNum = value; }
            }

            /// <summary>
            /// �󒍃X�e�[�^�X
            /// </summary>
            public int AcptAnOdrStatus
            {
                get { return _acptAnOdrStatus; }
                set { _acptAnOdrStatus = value; }
            }
            /// <summary>
            /// �v�����^�Ǘ���
            /// </summary>
            public int PrinterMngNo
            {
                get { return _printerMngNo; }
                set { _printerMngNo = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
            /// <param name="printerMngNo">�v�����^�Ǘ���</param>
            /// <param name="salesSlipNum">����`�[�ԍ�</param>
            public RmSalesSlipListKey(int acptAnOdrStatus, int printerMngNo, string salesSlipNum)
            {
                _acptAnOdrStatus = acptAnOdrStatus;
                _printerMngNo = printerMngNo;
                _salesSlipNum = salesSlipNum;
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="frePSalesSlipWork"></param>
            public RmSalesSlipListKey(FrePSalesSlipWork frePSalesSlipWork)
            {
                _acptAnOdrStatus = frePSalesSlipWork.SALESSLIPRF_ACPTANODRSTATUSRF;
                _printerMngNo = frePSalesSlipWork.HADD_PRINTERMNGNORF;
                _salesSlipNum = frePSalesSlipWork.SALESSLIPRF_SALESSLIPNUMRF;
            }
        }
        # endregion
        // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<

        # region [����`�[���X�g�U��KEY]
        /// <summary>
        /// ����`�[���X�g�U��KEY
        /// </summary>
        private struct SalesSlipListKey
        {
            /// <summary>�󒍃X�e�[�^�X</summary>
            private int _acptAnOdrStatus;
            /// <summary>�v�����^�Ǘ���</summary>
            private int _printerMngNo;
            /// <summary>
            /// �󒍃X�e�[�^�X
            /// </summary>
            public int AcptAnOdrStatus
            {
                get { return _acptAnOdrStatus; }
                set { _acptAnOdrStatus = value; }
            }
            /// <summary>
            /// �v�����^�Ǘ���
            /// </summary>
            public int PrinterMngNo
            {
                get { return _printerMngNo; }
                set { _printerMngNo = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
            /// <param name="printerMngNo">�v�����^�Ǘ���</param>
            public SalesSlipListKey( int acptAnOdrStatus, int printerMngNo )
            {
                _acptAnOdrStatus = acptAnOdrStatus;
                _printerMngNo = printerMngNo;
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="frePSalesSlipWork"></param>
            public SalesSlipListKey( FrePSalesSlipWork frePSalesSlipWork )
            {
                _acptAnOdrStatus = frePSalesSlipWork.SALESSLIPRF_ACPTANODRSTATUSRF;
                _printerMngNo = frePSalesSlipWork.HADD_PRINTERMNGNORF;
            }
        }
        # endregion

        # region [���Ϗ����X�g�U��KEY]
        /// <summary>
        /// ���Ϗ����X�g�U��KEY
        /// </summary>
        private struct EstFmListKey
        {
            /// <summary>�v�����^�Ǘ���</summary>
            private int _printerMngNo;
            /// <summary>
            /// �v�����^�Ǘ���
            /// </summary>
            public int PrinterMngNo
            {
                get { return _printerMngNo; }
                set { _printerMngNo = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="printerMngNo">�v�����^�Ǘ���</param>
            public EstFmListKey( int printerMngNo )
            {
                _printerMngNo = printerMngNo;
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="frePEstFmHead"></param>
            public EstFmListKey( FrePEstFmHead frePEstFmHead )
            {
                _printerMngNo = frePEstFmHead.HADD_PRINTERMNGNORF;
            }
        }
        # endregion

        # region [�݌Ɉړ��`�[���X�g�U��KEY]
        /// <summary>
        /// �݌Ɉړ��`�[���X�g�U��KEY
        /// </summary>
        private struct StockMoveSlipListKey
        {
            /// <summary>�ړ��`��</summary>
            private int _stockMoveFormal;
            /// <summary>�v�����^�Ǘ���</summary>
            private int _printerMngNo;
            /// <summary>
            /// �󒍃X�e�[�^�X
            /// </summary>
            public int StockMoveFormal
            {
                get { return _stockMoveFormal; }
                set { _stockMoveFormal = value; }
            }
            /// <summary>
            /// �v�����^�Ǘ���
            /// </summary>
            public int PrinterMngNo
            {
                get { return _printerMngNo; }
                set { _printerMngNo = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="acptAnOdrStatus">�ړ��`��</param>
            /// <param name="printerMngNo">�v�����^�Ǘ���</param>
            public StockMoveSlipListKey( int stockMoveFormal, int printerMngNo )
            {
                _stockMoveFormal = stockMoveFormal;
                _printerMngNo = printerMngNo;
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="frePSalesSlipWork"></param>
            public StockMoveSlipListKey( FrePStockMoveSlipWork frePStockMoveSlipWork )
            {
                _stockMoveFormal = frePStockMoveSlipWork.MOVH_STOCKMOVEFORMALRF;
                _printerMngNo = frePStockMoveSlipWork.HADD_PRINTERMNGNORF;
            }
        }
        # endregion
        # endregion

        # region [�`�[����A�N�Z�X�N���X�E�X�e�[�^�Xenum]
        /// <summary>
        /// �`�[����A�N�Z�X�N���X�E�X�e�[�^�X
        /// </summary>
        public enum SlipAcsStatus
        {
            /// <summary>����</summary>
            Normal = 0,
            /// <summary>�[���ݒ�Ȃ��G���[</summary>
            Error_NoTerminalMg = 1,
            /// <summary>�`�[��񒊏o�G���[</summary>
            Error_SearchSlip = 2,
        }
        # endregion
    }
}
