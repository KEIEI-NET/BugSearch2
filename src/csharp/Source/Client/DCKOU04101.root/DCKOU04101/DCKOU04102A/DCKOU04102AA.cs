//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d�������Ɖ�
// �v���O�����T�v   : �d�������Ɖ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/04/09  �C�����e : ��Q�Ή�13014
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/04/15  �C�����e : ��Q�Ή�13180
//----------------------------------------------------------------------------//

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
    /// �`�[���� �e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �`�[�������s���܂��B</br>
    /// <br>Programmer	: 980023 �ђJ�@�k��</br>
    /// <br>Date		: 2007.01.29</br>
    /// </remarks>
    public class DCKOU04102AA
    {
        # region ��Private Member
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IStcHisRefDataDB _iStcHisRefDataDB = null;
        /// <summary>���_�I�v�V�����t���O</summary>
        private bool _optSection;
		// ���_�A�N�Z�X�N���X
        //private static SecInfoAcs _secInfoAcs;													
        private StockDataSet _dataSet;
        private static StockDataSet.StockSlipDataTable _stockSlipCache;
        private static StcHisRefExtraParamWork _paraStockSlipCache;
        private static SortedList _nameList;
        private static DCKOU04102AA _searchSlipAcs;

        private string _enterpriseCode;             // ��ƃR�[�h
        private const string MESSAGE_NoResult = "���������Ɉ�v����`�[�͑��݂��܂���B";
        private const string MESSAGE_ErrResult = "�`�[���̎擾�Ɏ��s���܂����B";
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";
		private const string ct_DateFormat = "yyyy/MM/dd";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
        private int _maxSelectCount;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

        // ADD 2009/04/09 ------>>>
        private SubSectionAcs _subSectionAcs;
        private Dictionary<int, SubSection> _subSectionDic;
        // ADD 2009/04/09 ------<<<
        
        # endregion

		// �f���Q�[�g����
        public event GetNameListEventHandler GetNameList;
        public delegate SortedList GetNameListEventHandler();

        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
        // �s�I����ԕύX�C�x���g
        /// <summary>�s�I����ԕύX�C�x���g</summary>
        public event SelectedDataChangeEventHandler SelectedDataChange;
        public delegate void SelectedDataChangeEventHandler( object sender, bool status, int count );
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

        # region ��Constracter
        /// <summary>
        /// �`�[���� �e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�啪�ރ}�X�^ �e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public DCKOU04102AA()
        {
            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // ���_OP�̔���
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
            this._dataSet = new StockDataSet();
            //this._stockDetailDBDataList = new List<StockDetail>();
            //this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();

            // ADD 2009/04/09 ------>>>
            this._subSectionAcs = new SubSectionAcs();
            ReadSubSection();
            // ADD 2009/04/09 ------<<<
            
            // ���O�C�����i�ŒʐM��Ԃ��m�F
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // �����[�g�I�u�W�F�N�g�擾
					this._iStcHisRefDataDB = (IStcHisRefDataDB)MediationStcHisRefDataDB.GetStcHisRefDataDB();
                }
                catch (Exception)
                {
                    //�I�t���C������null���Z�b�g
                    this._iStcHisRefDataDB = null;
                }
            }
            else
            {
                // �I�t���C�����̃f�[�^�ǂݍ���
                //this.SearchOfflineData();
                MessageBox.Show("�I�t���C����Ԃ̂��ߌ��������s�ł��܂���B");
            }
        }
        # endregion

        /// <summary>
        /// �`�[�����A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�`�[�����A�N�Z�X�N���X �C���X�^���X</returns>
        public static DCKOU04102AA GetInstance()
        {
            if (_searchSlipAcs == null)
            {
                _searchSlipAcs = new DCKOU04102AA();
            }

            return _searchSlipAcs;
        }

        /// <summary>
        /// �`�[�����f�[�^�Z�b�g�擾����
        /// </summary>
        /// <returns>�`�[�����f�[�^�Z�b�g</returns>
        public StockDataSet DataSet
        {
            get { return this._dataSet; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
        /// <summary>
        /// �I���\���א� �v���p�e�B
        /// </summary>
        public int MaxSelectCount
        {
            get { return _maxSelectCount; }
            set { _maxSelectCount = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

        # region ��public int GetOnlineMode()
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iStcHisRefDataDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        # endregion

        #region ��Private Method


        /// <summary>
        /// �`�[�f�[�^�e�[�u�� �L���b�V������
        /// </summary>
        private void CacheStockSlipTable()
        {
            if (_stockSlipCache == null)
            {
                _stockSlipCache = new StockDataSet.StockSlipDataTable();
            }

            this._dataSet.StockSlip.AcceptChanges();
            _stockSlipCache = (StockDataSet.StockSlipDataTable)this._dataSet.StockSlip.Copy();
        }

        /// <summary>
        /// ���������N���X(�ĕ\���p) �L���b�V������
        /// </summary>
        private void CacheParaStockSlip(StcHisRefExtraParamWork stcHisRefExtraParamWork)
        {
            // ���������l
            if (_paraStockSlipCache == null)
            {
                _paraStockSlipCache = new StcHisRefExtraParamWork();
            }
            _paraStockSlipCache = stcHisRefExtraParamWork;

            // ����
            if (_nameList == null)
            {
                _nameList = new SortedList();
            }

            // �f���Q�[�g�ɂĉ�ʂ̖��̍��ڒl���X�g���擾�E�i�[
            if (this.GetNameList != null)
            {
                _nameList = this.GetNameList();
            }
        }

        // ADD 2009/04/09 ------>>>
        private void ReadSubSection()
        {
            this._subSectionDic = new Dictionary<int, SubSection>();

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
        // ADD 2009/04/09 ------<<<
        
        #endregion



        #region ��Public Method

        /// <summary>
        /// �`�[��� �Ǎ��E�f�[�^�Z�b�g�i�[���s����
        /// </summary>
        /// <param name="ioWriteMASIRReadWork">�d���`�[�����p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[����ǂݍ��݂܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �ђJ</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public int SetSearchData(StcHisRefExtraParamWork stcHisRefExtraParamWork)
        {
            List<StcHisRefDataWork> retData;
			string supplierFormalName = "";
			string supplierSlipCdName = "";
			string accPayDivCdName = "";
			string arrivalGoodsDayString = "";
			string stockDateString = "";
			string memoExistName = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
            string debitNoteName = "";                  // �ԓ`�敪��
            string stockGoodsCdName = "";               // ���i�敪��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END

			long stockPriceTaxExc = 0;
			long stockPriceConsTax = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
            long stockPriceTaxInc = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD
            
            int status = this.Search(out retData, stcHisRefExtraParamWork);

            // �d���`��
            List<string> SupplierFormalList = new List<string>();
            SupplierFormalList.Add("�d��");
            SupplierFormalList.Add("����");

            // ���|�敪    
            List<string> AccPayDivCdList = new List<string>();
            AccPayDivCdList.Add("���|�Ǘ����Ȃ�");
            AccPayDivCdList.Add("���|�Ǘ�����");

            this.ClearStockSlipDataTable();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                for (int i = 0; i < retData.Count; i++)
                {
                    StcHisRefDataWork stcHisRefDataWork = retData[i];

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 DEL
                    ////����Œ����E�c������
                    //if ((stcHisRefDataWork.StockGoodsCd == 2) || (stcHisRefDataWork.StockGoodsCd == 4))
                    //{
                    //    stockPriceTaxExc = 0;
                    //    stockPriceConsTax = stcHisRefDataWork.StockPriceConsTax;
                    //}

                    //else if ((stcHisRefDataWork.StockGoodsCd == 3) || (stcHisRefDataWork.StockGoodsCd == 5))
                    //{
                    //    stockPriceTaxExc = stcHisRefDataWork.StockPriceTaxInc;
                    //    stockPriceConsTax = 0;
                    //}
                    //else
                    //{
                    //    stockPriceTaxExc = stcHisRefDataWork.StockPriceTaxExc;
                    //    stockPriceConsTax = stcHisRefDataWork.StockPriceConsTax;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 DEL

					//�d���`��
					if (stcHisRefDataWork.SupplierFormal == 0)
					{
						supplierFormalName = "�d��";
					}
					else
					{
						supplierFormalName = "����";
					}

					//�d���`�[�敪
					if (stcHisRefDataWork.SupplierSlipCd == 10)
					{
                        // --- DEL 2009/01/23 -------------------------------->>>>>
                        //if (stcHisRefDataWork.AccPayDivCd == 0)
                        //{
                        //    supplierSlipCdName = "�����d��";
                        //}
                        //else
                        //{
                        //    supplierSlipCdName = "�|�d��";
                        //}
                        // --- DEL 2009/01/23 --------------------------------<<<<<
                        supplierSlipCdName = "�d��";
					}
					else
					{
                        // --- DEL 2009/01/23 -------------------------------->>>>>
                        //if (stcHisRefDataWork.AccPayDivCd == 0)
                        //{
                        //    supplierSlipCdName = "�����ԕi";
                        //}
                        //else
                        //{
                        //    supplierSlipCdName = "�|�ԕi";
                        //}
                        // --- DEL 2009/01/23 --------------------------------<<<<<
                        supplierSlipCdName = "�ԕi"; 
					}

					//���|�敪
					if (stcHisRefDataWork.AccPayDivCd == 0)
					{
						accPayDivCdName = "���|�Ȃ�";
					}
					else
					{
						accPayDivCdName = "���|����";
					}

					//���ד�
					arrivalGoodsDayString = GetDateTimeString(stcHisRefDataWork.ArrivalGoodsDay, ct_DateFormat);

					//�d����
					stockDateString = GetDateTimeString(stcHisRefDataWork.StockDate, ct_DateFormat);

                    // �ԍ�
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
                    switch (stcHisRefDataWork.DebitNoteDiv)
                    {
                        case 0: debitNoteName = "���`"; break;
                        case 1: debitNoteName = "�ԓ`"; break;
                        case 2: debitNoteName = "����"; break;
                    }

                    switch (stcHisRefDataWork.StockGoodsCd)
                    {
                        case 0: stockGoodsCdName = "���i"; break;
                        case 1: stockGoodsCdName = "���i�O"; break;
                        case 2: stockGoodsCdName = "����Œ���"; break;
                        case 3: stockGoodsCdName = "�c������"; break;
                        case 4: stockGoodsCdName = "���|�p����Œ���"; break;
                        case 5: stockGoodsCdName = "���|�p�c������"; break;
                        case 6: stockGoodsCdName = "���v����"; break;
                        case 10: stockGoodsCdName = "���p����Œ���(����)"; break;
                        case 11: stockGoodsCdName = "���E"; break;
                        case 12: stockGoodsCdName = "���E(����)"; break;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END

					//��������
					if(stcHisRefDataWork.MemoExist != 0)
					{
						memoExistName = "��";
					}
					else
					{
						memoExistName = "";
					}

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 DEL
                    # region // DEL
                    //_dataSet.StockSlip.AddStockSlipRow(i + 1, 
                    //                                    false,//stcHisRefDataWork.PrintFlag, 
                    //                                    stcHisRefDataWork.EnterpriseCode,
                    //                                    stcHisRefDataWork.SupplierFormal, 
                    //                                    supplierFormalName,//stcHisRefDataWork.SupplierFomalName, 
                    //                                    stcHisRefDataWork.SupplierSlipNo, 
                    //                                    stcHisRefDataWork.SectionCode, 
                    //                                    stcHisRefDataWork.SectionGuideNm, 
                    //                                    stcHisRefDataWork.SupplierSlipCd,
                    //                                    supplierSlipCdName,//stcHisRefDataWork.SupplierSlipCdName, 
                    //                                    stcHisRefDataWork.AccPayDivCd,
                    //                                    accPayDivCdName,//stcHisRefDataWork.AccPayDivCdName, 
                    //                                    stcHisRefDataWork.ArrivalGoodsDay,
                    //                                    arrivalGoodsDayString,//stcHisRefDataWork.ArrivalGoodsDayString, 
                    //                                    stcHisRefDataWork.StockDate,
                    //                                    stockDateString,//stcHisRefDataWork.StockDateString, 
                    //                                    stcHisRefDataWork.StockInputCode, 
                    //                                    stcHisRefDataWork.StockInputName, 
                    //                                    stcHisRefDataWork.StockAgentCode, 
                    //                                    stcHisRefDataWork.StockAgentName, 
                    //                                    //stcHisRefDataWork.CustomerCode, 
                    //                                    //stcHisRefDataWork.CustomerName, 
                    //                                    //stcHisRefDataWork.CustomerName2, 
                    //                                    //stcHisRefDataWork.CustomerSnm, 
                    //                                    stcHisRefDataWork.PartySaleSlipNum, 
                    //                                    stcHisRefDataWork.StockRowNo, 
                    //                                    stcHisRefDataWork.CommonSeqNo, 
                    //                                    stcHisRefDataWork.StockSlipDtlNum, 
                    //                                    stcHisRefDataWork.GoodsMakerCd, 
                    //                                    stcHisRefDataWork.MakerName, 
                    //                                    stcHisRefDataWork.GoodsNo, 
                    //                                    stcHisRefDataWork.GoodsName, 
                    //                                    //stcHisRefDataWork.ListPriceFl, 
                    //                                    stcHisRefDataWork.StockUnitPriceFl, 
                    //                                    stcHisRefDataWork.StockCount, 
                    //                                    stockPriceTaxExc,
                    //                                    stockPriceConsTax,
                    //                                    //stcHisRefDataWork.UnitCode, 
                    //                                    //stcHisRefDataWork.UnitName, 
                    //                                    stcHisRefDataWork.WarehouseCode, 
                    //                                    stcHisRefDataWork.WarehouseName, 
                    //                                    stcHisRefDataWork.WarehouseShelfNo, 
                    //                                    stcHisRefDataWork.SupplierCd, 
                    //                                    stcHisRefDataWork.SupplierSnm, 
                    //                                    stcHisRefDataWork.OrderNumber, 
                    //                                    //stcHisRefDataWork.OrderCnt,
                    //                                    //stcHisRefDataWork.OrderCnt + stcHisRefDataWork.OrderAdjustCnt,
                    //                                    //stcHisRefDataWork.OrderAdjustCnt, 
                    //                                    //stcHisRefDataWork.OrderRemainCnt, 
                    //                                    stcHisRefDataWork.StockDtiSlipNote1,
                    //                                    stcHisRefDataWork.SalesCustomerCode,
                    //                                    //.CustomerCode,	//�̔���R�[�h
                    //                                    stcHisRefDataWork.SalesCustomerSnm,
                    //                                    //.CustomerSnm,	//�̔��旪��
                    //                                    stcHisRefDataWork.MemoExist,
                    //                                    memoExistName,//stcHisRefDataWork.MemoExistName, 
                    //                                    stcHisRefDataWork.SlipMemo1, 
                    //                                    stcHisRefDataWork.SlipMemo2, 
                    //                                    stcHisRefDataWork.SlipMemo3, 
                    //                                    //stcHisRefDataWork.SlipMemo4, 
                    //                                    //stcHisRefDataWork.SlipMemo5, 
                    //                                    //stcHisRefDataWork.SlipMemo6, 
                    //                                    stcHisRefDataWork.InsideMemo1, 
                    //                                    stcHisRefDataWork.InsideMemo2, 
                    //                                    stcHisRefDataWork.InsideMemo3,
                    //                                    stcHisRefDataWork.BLGoodsCode,
                    //                                    stcHisRefDataWork.ListPriceTaxExcFl,
                    //                                    stcHisRefDataWork.DebitNoteDiv,
                    //                                    debitNoteName,  // �ԍ�
                    //                                    stcHisRefDataWork.InputDay,
                    //                                    stcHisRefDataWork.StockAddUpADate,
                    //                                    stcHisRefDataWork.PayeeCode,
                    //                                    stcHisRefDataWork.PayeeSnm,
                    //                                    stockGoodsCdName
                    //                                    //stcHisRefDataWork.InsideMemo4, 
                    //                                    //stcHisRefDataWork.InsideMemo5, 
                    //                                    //stcHisRefDataWork.InsideMemo6
                    //                                   );
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 DEL

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
                    // ����ŕ\���Ή�

                    stockPriceTaxExc = stcHisRefDataWork.StockPriceTaxExc;
                    stockPriceConsTax = stcHisRefDataWork.StockPriceTaxInc - stcHisRefDataWork.StockPriceTaxExc;
                    stockPriceTaxInc = stcHisRefDataWork.StockPriceTaxInc;

                    // �ݒ�K�p
                    ReflectMoneyForTaxPrint( ref stockPriceTaxExc, ref stockPriceConsTax, ref stockPriceTaxInc, stcHisRefDataWork.SuppTtlAmntDspWayCd, stcHisRefDataWork.SuppCTaxLayCd, stcHisRefDataWork.TaxationCode );

                    # region [���i�敪]
                    switch ( stcHisRefDataWork.StockGoodsCd )
                    {
                        case 2:
                        case 4:
                            // 2:����Œ���,4:���|�p����Œ���
                            stockPriceTaxExc = 0;
                            break;
                        case 3:
                        case 5:
                            // 3:�c������,5:���|�p�c������
                            stockPriceTaxExc = stockPriceTaxInc;
                            stockPriceConsTax = 0;
                            break;
                        default:
                            break;
                    }
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
                    StockDataSet.StockSlipRow row = _dataSet.StockSlip.NewStockSlipRow();

                    # region [row]
                    row.EnterpriseCode = stcHisRefDataWork.EnterpriseCode;
                    row.SupplierFormal = stcHisRefDataWork.SupplierFormal;
                    row.SupplierSlipNo = stcHisRefDataWork.SupplierSlipNo;
                    row.SectionCode = stcHisRefDataWork.SectionCode;
                    row.SectionGuideNm = stcHisRefDataWork.SectionGuideNm;
                    row.SupplierSlipCd = stcHisRefDataWork.SupplierSlipCd;
                    row.AccPayDivCd = stcHisRefDataWork.AccPayDivCd;
                    row.ArrivalGoodsDay = stcHisRefDataWork.ArrivalGoodsDay;
                    row.StockDate = stcHisRefDataWork.StockDate;
                    row.StockInputCode = stcHisRefDataWork.StockInputCode;
                    row.StockInputName = stcHisRefDataWork.StockInputName;
                    row.StockAgentCode = stcHisRefDataWork.StockAgentCode;
                    row.StockAgentName = stcHisRefDataWork.StockAgentName;
                    row.PartySaleSlipNum = stcHisRefDataWork.PartySaleSlipNum;
                    row.StockRowNo = stcHisRefDataWork.StockRowNo;
                    row.CommonSeqNo = stcHisRefDataWork.CommonSeqNo;
                    row.StockSlipDtlNum = stcHisRefDataWork.StockSlipDtlNum;
                    row.GoodsMakerCd = stcHisRefDataWork.GoodsMakerCd;
                    row.MakerName = stcHisRefDataWork.MakerName;
                    row.GoodsNo = stcHisRefDataWork.GoodsNo;
                    row.GoodsName = stcHisRefDataWork.GoodsName;
                    row.StockUnitPriceFl = stcHisRefDataWork.StockUnitPriceFl;
                    row.StockCount = stcHisRefDataWork.StockCount;
                    row.WarehouseCode = stcHisRefDataWork.WarehouseCode;
                    row.WarehouseName = stcHisRefDataWork.WarehouseName;
                    row.WarehouseShelfNo = stcHisRefDataWork.WarehouseShelfNo;
                    row.SupplierCd = stcHisRefDataWork.SupplierCd;
                    row.SupplierSnm = stcHisRefDataWork.SupplierSnm;
                    row.OrderNumber = stcHisRefDataWork.OrderNumber;
                    row.StockDtiSlipNote1 = stcHisRefDataWork.StockDtiSlipNote1;
                    row.SalesCustomerCode = stcHisRefDataWork.SalesCustomerCode;
                    row.SalesCustomerSnm = stcHisRefDataWork.SalesCustomerSnm;
                    row.MemoExist = stcHisRefDataWork.MemoExist;
                    row.SlipMemo1 = stcHisRefDataWork.SlipMemo1;
                    row.SlipMemo2 = stcHisRefDataWork.SlipMemo2;
                    row.SlipMemo3 = stcHisRefDataWork.SlipMemo3;
                    row.InsideMemo1 = stcHisRefDataWork.InsideMemo1;
                    row.InsideMemo2 = stcHisRefDataWork.InsideMemo2;
                    row.InsideMemo3 = stcHisRefDataWork.InsideMemo3;
                    row.BLGoodsCode = stcHisRefDataWork.BLGoodsCode;
                    row.ListPriceTaxExcFl = stcHisRefDataWork.ListPriceTaxExcFl;
                    row.DebitNoteDiv = stcHisRefDataWork.DebitNoteDiv;
                    row.InputDay = stcHisRefDataWork.InputDay;
                    // --- CHG 2009/02/24 ��QID:11873�Ή�------------------------------------------------------>>>>>
                    //row.StockAddUpADate = stcHisRefDataWork.StockAddUpADate;
                    if (stcHisRefDataWork.StockAddUpADate != DateTime.MinValue)
                    {
                        row.StockAddUpADate = stcHisRefDataWork.StockAddUpADate;
                    }
                    // --- CHG 2009/02/24 ��QID:11873�Ή�------------------------------------------------------<<<<<
                    row.PayeeCode = stcHisRefDataWork.PayeeCode;
                    row.PayeeSnm = stcHisRefDataWork.PayeeSnm;
                    row.SubSectionName = GetSubSectionName(stcHisRefDataWork.SubSectionCode);  // ADD 2009/04/09
                    # endregion

                    # region [row(�蓮)]
                    row.No = i + 1;
                    row.PrintFlag = false;
                    row.SupplierFormalName = supplierFormalName;
                    row.SupplierSlipCdName = supplierSlipCdName;
                    row.AccPayDivCdName = accPayDivCdName;
                    row.ArrivalGoodsDayString = arrivalGoodsDayString;
                    row.StockDateString = stockDateString;
                    row.StockPriceTaxExc = stockPriceTaxExc;
                    row.StockPriceConsTax = stockPriceConsTax;
                    row.DebitNoteDivName = debitNoteName;
                    row.StockGoodsCdName = stockGoodsCdName;
                    row.MemoExistName = memoExistName;
                    # endregion

                    _dataSet.StockSlip.AddStockSlipRow( row );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD
				}

                // �����f�[�^�̃L���b�V��
                this.CacheStockSlipTable();

                // ���������̃L���b�V��
                this.CacheParaStockSlip(stcHisRefExtraParamWork);
            }
            else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                     (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                if (this.StatusBarMessageSetting != null)
                {
                    this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                }
            }
            return status;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
        /// <summary>
        /// ���z�擾�����i����ň���Ή��j
        /// </summary>
        /// <param name="moneyTaxExc"></param>
        /// <param name="priceConsTax"></param>
        /// <param name="moneyTaxInc"></param>
        /// <param name="totalAmountDispWayCd"></param>
        /// <param name="consTaxLayMethod"></param>
        /// <param name="taxationDivCd"></param>
        private static void ReflectMoneyForTaxPrint( ref long moneyTaxExc, ref long priceConsTax, ref long moneyTaxInc, int totalAmountDispWayCd, int consTaxLayMethod, int taxationDivCd )
        {
            bool printTax;

            # region [printTax]
            switch ( GetTaxPrintType( totalAmountDispWayCd, consTaxLayMethod ) )
            {
                case 0:
                default:
                    {
                        // �`�[�P�ʁi���ז��̏���ł͕\�����Ȃ��j
                        printTax = false;
                    }
                    break;
                case 1:
                    {
                        // ���גP��/���z�\��
                        printTax = true;
                    }
                    break;
                case 2:
                    {
                        // �����e�q�E��ېŁi�ېŋ敪�����ł̂ݕ\���j
                        // �ېŋ敪�i0:�ې�,1:��ې�,2:�ېŁi���Łj�j
                        switch ( taxationDivCd )
                        {
                            case 0:
                            case 1:
                            default:
                                {
                                    printTax = false;
                                }
                                break;
                            case 2:
                                {
                                    printTax = true;
                                }
                                break;
                        }
                    }
                    break;
            }
            # endregion

            // �ň󎚂��Ȃ��ꍇ
            if ( !printTax )
            {
                priceConsTax = 0;
                moneyTaxInc = moneyTaxExc;
            }
        }
        /// <summary>
        /// ����ŕ\���^�C�v�擾
        /// </summary>
        /// <param name="slipWork"></param>
        /// <returns>TaxPrintType�i0:�`�[�P��, 1:���גP��/���z�\������, 2:�����e/�����q/��ېŁj</returns>
        private static int GetTaxPrintType( int totalAmountDispWayCd, int consTaxLayMethod )
        {
            // ���z�\�����@
            switch ( totalAmountDispWayCd )
            {
                case 1:
                    // ���z�\������
                    return 1;
                case 0:
                default:
                    {
                        // ���z�\�����Ȃ�

                        switch ( consTaxLayMethod )
                        {
                            // 0:�`�[�P��
                            case 0:
                                return 0;
                            // 1:���גP��
                            case 1:
                                return 1;
                            // 2:�����e
                            case 2:
                            // 3:�����q
                            case 3:
                            // 9:��ې�
                            case 9:
                            default:
                                return 2;
                        }
                    }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD

        /// <summary>
        /// �f�[�^�Z�b�g�N���A����
        /// </summary>
        public void ClearStockSlipDataTable()
        {
            this._dataSet.StockSlip.Rows.Clear();

            // �L���b�V���f�[�^�̎�蒼��(�N���A��Ԃɂ���)
            this.CacheStockSlipTable();
            this.CacheParaStockSlip(null);
        }
        
        /// <summary>
        /// �`�[��� �ǂݍ��ݏ���
        /// </summary>
        /// <param name="stockSlipWorks">�d���f�[�^ �I�u�W�F�N�g�z��</param>
        /// <param name="stcHisRefExtraParamWork">�d���`�[�����p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[����ǂݍ��݂܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �ђJ</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public int Search(out List<StcHisRefDataWork> stcHisRefDataWorkList, StcHisRefExtraParamWork stcHisRefExtraParamWork)
        {
            try
            {
                int status;
                stcHisRefDataWorkList = new List<StcHisRefDataWork>();

                // �I�����C���̏ꍇ�����[�g�擾
                if (LoginInfoAcquisition.OnlineFlag)
                {
                    CustomSerializeArrayList paraList = new CustomSerializeArrayList();
					paraList.Add(stcHisRefExtraParamWork);

                    //CustomSerializeArrayList retList = new CustomSerializeArrayList();
					ArrayList retList = new ArrayList();

                    object paraObj = (object)paraList;
                    object retObj = (object)retList;

                    //�`�[���擾
                    status = this._iStcHisRefDataDB.Search( out retObj, paraObj );
                    
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        int setCount = 0;
                        //retList = (CustomSerializeArrayList)retObj;
						retList = (ArrayList)retObj;
						for (int i = 0; i < retList.Count; i++)
                        {
                            stcHisRefDataWorkList.Add((StcHisRefDataWork)retList[i]);
                            setCount++;
                        }
                    }
                    else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                    {
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                        }
                    }
                    else
                    {
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_ErrResult);
                        }
                    }
                }
                else	// �I�t���C���̏ꍇ
                {
                    //status = ReadStaticMemory(out lgoodsganre, enterpriseCode, largeGoodsGanreCode);
                    status = -1;
                }

                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );

                stcHisRefDataWorkList = null;
                //�I�t���C������null���Z�b�g
                this._iStcHisRefDataDB= null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �`�[�f�[�^�e�[�u���L���b�V���擾����
        /// </summary>
        /// <returns>�`�[�f�[�^�e�[�u���L���b�V��</returns>
        public StockDataSet.StockSlipDataTable GetStockSlipTableCache()
        {
            return _stockSlipCache;
        }

        /// <summary>
        /// ��ʖ��̍��ڒl���X�g �L���b�V���擾����
        /// </summary>
        /// <returns>��ʖ��̍��ڒl���X�g �L���b�V��</returns>
        public SortedList GetCacheNmaeList()
        {
            return _nameList;
        }


        /// <summary>
        /// ���������N���X�L���b�V���擾����
        /// </summary>
        /// <returns>���������N���X�L���b�V��</returns>
        public StcHisRefExtraParamWork GetParaStockSlipCache()
        {
            return _paraStockSlipCache;
		}


		/// <summary>
		/// �I���s�󎚑I���E��I����ԏ���
		/// </summary>
		/// <param name="_uniqueID">���j�[�NID</param>
		/// <remarks>
		/// <br>Note       : ���o�f�[�^�����������܂��B</br>
		/// <br>Programer  : 980023  �ђJ �k��</br>
		/// <br>Date       : 2007.07.09</br>
		/// </remarks>
		public void SelectedPrintRow(int _uniqueID)
		{
			// ------------------------------------------------------------//
			// Find ���\�b�h���g���A���AView�̃\�[�g����ύX�������Ȃ��ׁA //
			// DataTable�ɍX�V��������B                                   //
			// ------------------------------------------------------------//
			DataRow _row = this._dataSet.StockSlip.Rows.Find(_uniqueID);

			// ��v����s�����݂���I
			if (_row != null)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
                //bool printFlag = (bool)_row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName];

                //_row.BeginEdit();
                //_row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName] = !printFlag;
                //_row.EndEdit();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                bool printFlag = (bool)_row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName];
                SelectedPrintRow( ref _row, !printFlag );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
			}
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
        /// <summary>
        /// �I���s��Ԑݒ�
        /// </summary>
        /// <param name="row"></param>
        /// <param name="selected"></param>
        /// <returns></returns>
        public bool SelectedPrintRow( ref DataRow row, bool selected )
        {
            bool checkResult;
            int selectedCount = GetSelectedRowCount();

            if ( selected == true && selectedCount == MaxSelectCount )
            {
                // �ύX�s��
                checkResult = false;
            }
            else
            {
                // �ύX�O�̒l��ޔ�
                bool prevPrintFlag = (bool)row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName];

                // �ύX��
                checkResult = true;
                // �ύX
                row.BeginEdit();
                row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName] = selected;
                row.EndEdit();

                if ( !prevPrintFlag && selected )
                {
                    selectedCount++;
                }
                else if ( prevPrintFlag && !selected )
                {
                    selectedCount--;
                }
            }

            // �I����ԕύX�C�x���g
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, checkResult, selectedCount );
            }

            return checkResult;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

		/// <summary>
		/// �I���s�󎚑I���E��I����ԏ���(�w��^)
		/// </summary>
		/// <param name="_uniqueID">���j�[�NID</param>
		/// <param name="selected">true:�I��,false:��I��</param>
		/// <remarks>
		/// <br>Note       : ���o�f�[�^�����������܂��B</br>
		/// <br>Programer  : 980023  �ђJ �k��</br>
		/// <br>Date       : 2007.07.09</br>
		/// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
        //public void SelectedPrintRow(int _uniqueID, bool selected)
        public bool SelectedPrintRow(int _uniqueID, bool selected)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            bool result = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

			// ------------------------------------------------------------//
			// Find ���\�b�h���g���A���AView�̃\�[�g����ύX�������Ȃ��ׁA //
			// DataTable�ɍX�V��������B                                   //
			// ------------------------------------------------------------//
			DataRow _row = this._dataSet.StockSlip.Rows.Find(_uniqueID);

			// ��v����s�����݂���I
			if (_row != null)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
                //_row.BeginEdit();
                //_row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName] = selected;
                //_row.EndEdit();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                result = SelectedPrintRow( ref _row, selected );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
			}
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            return result;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
        }

		/// <summary>
		/// �I���s�e�[�u���f�[�^���擾����
		/// </summary>
		/// <returns></returns>
		public int GetSelectedRowCount()
		{
			// ���i���e�[�u��
			DataView StockSlipView = new DataView(this._dataSet.StockSlip);
			StockSlipView.RowFilter = String.Format("{0} = {1}", this._dataSet.StockSlip.PrintFlagColumn.ColumnName, true);
			return (StockSlipView.Count);
		}

		/// <summary>
        /// �I���s�e�[�u���f�[�^�擾�����������s�I����
        /// </summary>
        /// <param name="getRowNo">�O���b�h�I��RowNo</param>
        /// <returns>�d���f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u������A�w��s�̎d���f�[�^�N���X��Ԃ��܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public List<StcHisRefDataWork> GetSelectedRowData()
        {
			// �ߒl
			List<StcHisRefDataWork> stcHisRefDataWorkList = new List<StcHisRefDataWork>();

			// ���i���e�[�u��
			DataView StockSlipView = new DataView(this._dataSet.StockSlip);
			StockSlipView.RowFilter = String.Format("{0} = {1}", this._dataSet.StockSlip.PrintFlagColumn.ColumnName,true);

			for (int ix = 0; ix < StockSlipView.Count; ix++)
			{
				StcHisRefDataWork stcHisRefDataWork = new StcHisRefDataWork();

				stcHisRefDataWork.EnterpriseCode = (string)StockSlipView[ix][this._dataSet.StockSlip.EnterpriseCodeColumn.ColumnName];

				stcHisRefDataWork.EnterpriseCode = (string)StockSlipView[ix][this._dataSet.StockSlip.EnterpriseCodeColumn.ColumnName];
				stcHisRefDataWork.SupplierFormal = (int)StockSlipView[ix][this._dataSet.StockSlip.SupplierFormalColumn.ColumnName];
				stcHisRefDataWork.SupplierSlipNo = (int)StockSlipView[ix][this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName];
				stcHisRefDataWork.SectionCode = (string)StockSlipView[ix][this._dataSet.StockSlip.SectionCodeColumn.ColumnName];
				stcHisRefDataWork.SectionGuideNm = (string)StockSlipView[ix][this._dataSet.StockSlip.SectionGuideNmColumn.ColumnName];
				stcHisRefDataWork.SupplierSlipCd = (int)StockSlipView[ix][this._dataSet.StockSlip.SupplierSlipCdColumn.ColumnName];
				stcHisRefDataWork.AccPayDivCd = (int)StockSlipView[ix][this._dataSet.StockSlip.AccPayDivCdColumn.ColumnName];
				stcHisRefDataWork.ArrivalGoodsDay = (System.DateTime)StockSlipView[ix][this._dataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName];
				stcHisRefDataWork.StockDate = (System.DateTime)StockSlipView[ix][this._dataSet.StockSlip.StockDateColumn.ColumnName];
				stcHisRefDataWork.StockInputCode = (string)StockSlipView[ix][this._dataSet.StockSlip.StockInputCodeColumn.ColumnName];
				stcHisRefDataWork.StockInputName = (string)StockSlipView[ix][this._dataSet.StockSlip.StockInputNameColumn.ColumnName];
				stcHisRefDataWork.StockAgentCode = (string)StockSlipView[ix][this._dataSet.StockSlip.StockAgentCodeColumn.ColumnName];
				stcHisRefDataWork.StockAgentName = (string)StockSlipView[ix][this._dataSet.StockSlip.StockAgentNameColumn.ColumnName];
				//stcHisRefDataWork.CustomerCode = (int)StockSlipView[ix][this._dataSet.StockSlip.CustomerCodeColumn.ColumnName];
				//stcHisRefDataWork.CustomerName = (string)StockSlipView[ix][this._dataSet.StockSlip.CustomerNameColumn.ColumnName];
				//stcHisRefDataWork.CustomerName2 = (string)StockSlipView[ix][this._dataSet.StockSlip.CustomerName2Column.ColumnName];
				//stcHisRefDataWork.CustomerSnm = (string)StockSlipView[ix][this._dataSet.StockSlip.CustomerSnmColumn.ColumnName];
				stcHisRefDataWork.PartySaleSlipNum = (string)StockSlipView[ix][this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName];
				stcHisRefDataWork.StockRowNo = (int)StockSlipView[ix][this._dataSet.StockSlip.StockRowNoColumn.ColumnName];
				stcHisRefDataWork.CommonSeqNo = (long)StockSlipView[ix][this._dataSet.StockSlip.CommonSeqNoColumn.ColumnName];
				stcHisRefDataWork.StockSlipDtlNum = (long)StockSlipView[ix][this._dataSet.StockSlip.StockSlipDtlNumColumn.ColumnName];
				stcHisRefDataWork.GoodsMakerCd = (int)StockSlipView[ix][this._dataSet.StockSlip.GoodsMakerCdColumn.ColumnName];
				stcHisRefDataWork.MakerName = (string)StockSlipView[ix][this._dataSet.StockSlip.MakerNameColumn.ColumnName];
				stcHisRefDataWork.GoodsNo = (string)StockSlipView[ix][this._dataSet.StockSlip.GoodsNoColumn.ColumnName];
				stcHisRefDataWork.GoodsName = (string)StockSlipView[ix][this._dataSet.StockSlip.GoodsNameColumn.ColumnName];
				//stcHisRefDataWork.ListPriceFl = (double)StockSlipView[ix][this._dataSet.StockSlip.ListPriceFlColumn.ColumnName];
				stcHisRefDataWork.StockUnitPriceFl = (double)StockSlipView[ix][this._dataSet.StockSlip.StockUnitPriceFlColumn.ColumnName];
				stcHisRefDataWork.StockCount = (double)StockSlipView[ix][this._dataSet.StockSlip.StockCountColumn.ColumnName];
				stcHisRefDataWork.StockPriceTaxExc = (long)StockSlipView[ix][this._dataSet.StockSlip.StockPriceTaxExcColumn.ColumnName];
				//stcHisRefDataWork.UnitCode = (int)StockSlipView[ix][this._dataSet.StockSlip.UnitCodeColumn.ColumnName];
				//stcHisRefDataWork.UnitName = (string)StockSlipView[ix][this._dataSet.StockSlip.UnitNameColumn.ColumnName];
				stcHisRefDataWork.WarehouseCode = (string)StockSlipView[ix][this._dataSet.StockSlip.WarehouseCodeColumn.ColumnName];
				stcHisRefDataWork.WarehouseName = (string)StockSlipView[ix][this._dataSet.StockSlip.WarehouseNameColumn.ColumnName];
				stcHisRefDataWork.WarehouseShelfNo = (string)StockSlipView[ix][this._dataSet.StockSlip.WarehouseShelfNoColumn.ColumnName];
				stcHisRefDataWork.SupplierCd = (int)StockSlipView[ix][this._dataSet.StockSlip.SupplierCdColumn.ColumnName];
				stcHisRefDataWork.SupplierSnm = (string)StockSlipView[ix][this._dataSet.StockSlip.SupplierSnmColumn.ColumnName];
				stcHisRefDataWork.OrderNumber = (string)StockSlipView[ix][this._dataSet.StockSlip.OrderNumberColumn.ColumnName];
				//stcHisRefDataWork.OrderCnt = (double)StockSlipView[ix][this._dataSet.StockSlip.OrderCntColumn.ColumnName];
				//stcHisRefDataWork.OrderAdjustCnt = (double)StockSlipView[ix][this._dataSet.StockSlip.OrderAdjustCntColumn.ColumnName];
				//stcHisRefDataWork.OrderRemainCnt = (double)StockSlipView[ix][this._dataSet.StockSlip.OrderRemainCntColumn.ColumnName];
				//stcHisRefDataWork.StockDtiSlipNote1 = (string)StockSlipView[ix][this._dataSet.StockSlip.StockDtiSlipNote1Column.ColumnName];
//
				//stcHisRefDataWork.SalesCustomerCode = (int)StockSlipView[ix][this._dataSet.StockSlip.SalesCustomerCodeColumn.ColumnName];
				//stcHisRefDataWork.SalesCustomerSnm = (string)StockSlipView[ix][this._dataSet.StockSlip.SalesCustomerSnmColumn.ColumnName];
				
				stcHisRefDataWork.MemoExist = (int)StockSlipView[ix][this._dataSet.StockSlip.MemoExistColumn.ColumnName];
				stcHisRefDataWork.SlipMemo1 = (string)StockSlipView[ix][this._dataSet.StockSlip.SlipMemo1Column.ColumnName];
				stcHisRefDataWork.SlipMemo2 = (string)StockSlipView[ix][this._dataSet.StockSlip.SlipMemo2Column.ColumnName];
				stcHisRefDataWork.SlipMemo3 = (string)StockSlipView[ix][this._dataSet.StockSlip.SlipMemo3Column.ColumnName];
				//stcHisRefDataWork.SlipMemo4 = (string)StockSlipView[ix][this._dataSet.StockSlip.SlipMemo4Column.ColumnName];
				//stcHisRefDataWork.SlipMemo5 = (string)StockSlipView[ix][this._dataSet.StockSlip.SlipMemo5Column.ColumnName];
				//stcHisRefDataWork.SlipMemo6 = (string)StockSlipView[ix][this._dataSet.StockSlip.SlipMemo6Column.ColumnName];
				stcHisRefDataWork.InsideMemo1 = (string)StockSlipView[ix][this._dataSet.StockSlip.InsideMemo1Column.ColumnName];
				stcHisRefDataWork.InsideMemo2 = (string)StockSlipView[ix][this._dataSet.StockSlip.InsideMemo2Column.ColumnName];
				stcHisRefDataWork.InsideMemo3 = (string)StockSlipView[ix][this._dataSet.StockSlip.InsideMemo3Column.ColumnName];
				//stcHisRefDataWork.InsideMemo4 = (string)StockSlipView[ix][this._dataSet.StockSlip.InsideMemo4Column.ColumnName];
				//stcHisRefDataWork.InsideMemo5 = (string)StockSlipView[ix][this._dataSet.StockSlip.InsideMemo5Column.ColumnName];
				//stcHisRefDataWork.InsideMemo6 = (string)StockSlipView[ix][this._dataSet.StockSlip.InsideMemo6Column.ColumnName];
                stcHisRefDataWork.BLGoodsCode = (int)StockSlipView[ix][this._dataSet.StockSlip.BLGoodsCodeColumn.ColumnName];
                stcHisRefDataWork.ListPriceTaxExcFl = (double)StockSlipView[ix][this._dataSet.StockSlip.ListPriceTaxExcFlColumn.ColumnName];
                stcHisRefDataWork.DebitNoteDiv = (int)StockSlipView[ix][this._dataSet.StockSlip.DebitNoteDivColumn.ColumnName];
                stcHisRefDataWork.InputDay = (System.DateTime)StockSlipView[ix][this._dataSet.StockSlip.InputDayColumn.ColumnName];
                //stcHisRefDataWork.StockAddUpADate = (System.DateTime)StockSlipView[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName];     // DEL 2009/04/15
                // ADD 2009/04/15 ------>>>
                // ���ׂ̏ꍇ�A�v��������ݒ�
                if (StockSlipView[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName] != DBNull.Value)
                {
                    stcHisRefDataWork.StockAddUpADate = (System.DateTime)StockSlipView[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName];
                }
                else
                {
                    stcHisRefDataWork.StockAddUpADate = DateTime.MinValue;
                }
                // ADD 2009/04/15 ------<<<
                stcHisRefDataWork.PayeeCode = (int)StockSlipView[ix][this._dataSet.StockSlip.PayeeCodeColumn.ColumnName];
                stcHisRefDataWork.PayeeSnm = (string)StockSlipView[ix][this._dataSet.StockSlip.PayeeSnmColumn.ColumnName];

				stcHisRefDataWorkList.Add(stcHisRefDataWork);
			}

			return stcHisRefDataWorkList;
        }

		/// <summary>
		/// �I���s�e�[�u���f�[�^�擾������1�s�I����
		/// </summary>
		/// <param name="getRowNo">�O���b�h�I��RowNo</param>
		/// <returns>�d���f�[�^�N���X</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�e�[�u������A�w��s�̎d���f�[�^�N���X��Ԃ��܂��B</br>
		/// <br>Programmer : 980023 �ђJ  �k��</br>
		/// <br>Date       : 2007.01.29</br>
		/// </remarks>
		public List<StcHisRefDataWork> GetSelectedRowData(int ix)
		{
			// �ߒl
			List<StcHisRefDataWork> stcHisRefDataWorkList = new List<StcHisRefDataWork>();

			StcHisRefDataWork stcHisRefDataWork = new StcHisRefDataWork();

			stcHisRefDataWork.EnterpriseCode = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.EnterpriseCodeColumn.ColumnName];

			stcHisRefDataWork.EnterpriseCode = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.EnterpriseCodeColumn.ColumnName];
			stcHisRefDataWork.SupplierFormal = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SupplierFormalColumn.ColumnName];
			stcHisRefDataWork.SupplierSlipNo = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName];
			stcHisRefDataWork.SectionCode = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SectionCodeColumn.ColumnName];
			stcHisRefDataWork.SectionGuideNm = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SectionGuideNmColumn.ColumnName];
			stcHisRefDataWork.SupplierSlipCd = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SupplierSlipCdColumn.ColumnName];
			stcHisRefDataWork.AccPayDivCd = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.AccPayDivCdColumn.ColumnName];
			stcHisRefDataWork.ArrivalGoodsDay = (System.DateTime)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName];
			stcHisRefDataWork.StockDate = (System.DateTime)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockDateColumn.ColumnName];
			stcHisRefDataWork.StockInputCode = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockInputCodeColumn.ColumnName];
			stcHisRefDataWork.StockInputName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockInputNameColumn.ColumnName];
			stcHisRefDataWork.StockAgentCode = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockAgentCodeColumn.ColumnName];
			stcHisRefDataWork.StockAgentName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockAgentNameColumn.ColumnName];
			//stcHisRefDataWork.CustomerCode = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.CustomerCodeColumn.ColumnName];
			//stcHisRefDataWork.CustomerName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.CustomerNameColumn.ColumnName];
			//stcHisRefDataWork.CustomerName2 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.CustomerName2Column.ColumnName];
			//stcHisRefDataWork.CustomerSnm = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.CustomerSnmColumn.ColumnName];
			stcHisRefDataWork.PartySaleSlipNum = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName];
			stcHisRefDataWork.StockRowNo = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockRowNoColumn.ColumnName];
			stcHisRefDataWork.CommonSeqNo = (long)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.CommonSeqNoColumn.ColumnName];
			stcHisRefDataWork.StockSlipDtlNum = (long)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockSlipDtlNumColumn.ColumnName];
			stcHisRefDataWork.GoodsMakerCd = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.GoodsMakerCdColumn.ColumnName];
			stcHisRefDataWork.MakerName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.MakerNameColumn.ColumnName];
			stcHisRefDataWork.GoodsNo = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.GoodsNoColumn.ColumnName];
			stcHisRefDataWork.GoodsName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.GoodsNameColumn.ColumnName];
			//stcHisRefDataWork.ListPriceFl = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.ListPriceFlColumn.ColumnName];
			stcHisRefDataWork.StockUnitPriceFl = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockUnitPriceFlColumn.ColumnName];
			stcHisRefDataWork.StockCount = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockCountColumn.ColumnName];
			stcHisRefDataWork.StockPriceTaxExc = (long)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockPriceTaxExcColumn.ColumnName];
			//stcHisRefDataWork.UnitCode = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.UnitCodeColumn.ColumnName];
			//stcHisRefDataWork.UnitName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.UnitNameColumn.ColumnName];
			stcHisRefDataWork.WarehouseCode = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.WarehouseCodeColumn.ColumnName];
			stcHisRefDataWork.WarehouseName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.WarehouseNameColumn.ColumnName];
			stcHisRefDataWork.WarehouseShelfNo = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.WarehouseShelfNoColumn.ColumnName];
			stcHisRefDataWork.SupplierCd = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SupplierCdColumn.ColumnName];
			stcHisRefDataWork.SupplierSnm = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SupplierSnmColumn.ColumnName];
			stcHisRefDataWork.OrderNumber = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.OrderNumberColumn.ColumnName];
			//stcHisRefDataWork.OrderCnt = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.OrderCntColumn.ColumnName];
			//stcHisRefDataWork.OrderAdjustCnt = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.OrderAdjustCntColumn.ColumnName];
			//stcHisRefDataWork.OrderRemainCnt = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.OrderRemainCntColumn.ColumnName];
			stcHisRefDataWork.StockDtiSlipNote1 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockDtiSlipNote1Column.ColumnName];
			stcHisRefDataWork.MemoExist = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.MemoExistColumn.ColumnName];
			stcHisRefDataWork.SlipMemo1 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SlipMemo1Column.ColumnName];
			stcHisRefDataWork.SlipMemo2 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SlipMemo2Column.ColumnName];
			stcHisRefDataWork.SlipMemo3 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SlipMemo3Column.ColumnName];
			//stcHisRefDataWork.SlipMemo4 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SlipMemo4Column.ColumnName];
			//stcHisRefDataWork.SlipMemo5 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SlipMemo5Column.ColumnName];
			//stcHisRefDataWork.SlipMemo6 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SlipMemo6Column.ColumnName];
			stcHisRefDataWork.InsideMemo1 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InsideMemo1Column.ColumnName];
			stcHisRefDataWork.InsideMemo2 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InsideMemo2Column.ColumnName];
			stcHisRefDataWork.InsideMemo3 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InsideMemo3Column.ColumnName];
			//stcHisRefDataWork.InsideMemo4 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InsideMemo4Column.ColumnName];
			//stcHisRefDataWork.InsideMemo5 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InsideMemo5Column.ColumnName];
			//stcHisRefDataWork.InsideMemo6 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InsideMemo6Column.ColumnName];
            stcHisRefDataWork.BLGoodsCode = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.BLGoodsCodeColumn.ColumnName];
            stcHisRefDataWork.ListPriceTaxExcFl = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.ListPriceTaxExcFlColumn.ColumnName];
            stcHisRefDataWork.DebitNoteDiv = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.DebitNoteDivColumn.ColumnName];
            stcHisRefDataWork.InputDay = (System.DateTime)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InputDayColumn.ColumnName];
            //stcHisRefDataWork.StockAddUpADate = (System.DateTime)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName];   // DEL 2009/04/15
            // ADD 2009/04/15 ------>>>
            // ���ׂ̏ꍇ�A�v��������ݒ�
            if (this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName] != DBNull.Value)
            {
                stcHisRefDataWork.StockAddUpADate = (System.DateTime)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName];
            }
            else
            {
                stcHisRefDataWork.StockAddUpADate = DateTime.MinValue;
            }
            // ADD 2009/04/15 ------<<<
            stcHisRefDataWork.StockAddUpADate = (System.DateTime)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName];
            stcHisRefDataWork.PayeeCode = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.PayeeCodeColumn.ColumnName];
            stcHisRefDataWork.PayeeSnm = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.PayeeSnmColumn.ColumnName];

			stcHisRefDataWorkList.Add(stcHisRefDataWork);

			return stcHisRefDataWorkList;
		}



		/// <summary>
        /// �]�ƈ����̎擾����
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ�����</returns>
        public string GetName_FromEmployee(string employeeCode)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;

            int status = employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return employee.Name.Trim();
            }
            else
            {
                return "";
            }
        }

		/// <summary>
		/// ���[�J�[���̎擾����
		/// </summary>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <returns>�]�ƈ�����</returns>
		public string GetName_FromGoodsMaker(int goodsMakerCd)
		{
			MakerAcs makerAcs = new MakerAcs();
			MakerUMnt makerUMnt;

			int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, goodsMakerCd);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				return makerUMnt.MakerName.Trim();
			}
			else
			{
				return "";
			}
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        ///// <summary>
        ///// ���i���̎擾����
        ///// </summary>
        ///// <param name="goodsCode">���i�R�[�h</param>
        ///// <returns>true:���݂���Afalse:���݂��Ȃ�</returns>
        //public bool CheckGoodsExist(string goodsCode, out string goodsName)
        //{
        //    List<GoodsUnitData> goodsUnitDataList;
        //    GoodsAcs goodsAcs = new GoodsAcs();
        //    goodsName = "";

        //    // ���i�R�[�h�݂̂̎w���
        //    int status = goodsAcs.Read(this._enterpriseCode, goodsCode,out goodsUnitDataList);

        //    if( (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList.Count != 0) )
        //    {
        //        goodsName = goodsUnitDataList[0].GoodsName;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// ���i���̎擾����
        ///// </summary>
        ///// <param name="goodsCode">���i�R�[�h</param>
        ///// <returns>true:���݂���Afalse:���݂��Ȃ�</returns>
        //public int CheckGoodsExist(IWin32Window owner, ref string goodsCode, ref string goodsName, ref int goodsMakerCd, ref string makerName)
        //{
        //    int status;
        //    string message;
        //    string searchCode;
        //    int searchType;

        //    GoodsCndtn goodsCndtn = new GoodsCndtn();
        //    List<GoodsUnitData> goodsUnitDataList;
        //    GoodsAcs goodsAcs = new GoodsAcs();

        //    searchType = GetSearchType(goodsCode, out searchCode);

        //    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

        //    goodsCndtn.GoodsMakerCd = goodsMakerCd;
        //    goodsCndtn.GoodsNoSrchTyp = searchType;
        //    //goodsCndtn.GoodsNo = goodsCode;
        //    goodsCndtn.GoodsNo = searchCode;
        //    goodsCndtn.EnterpriseCode = this._enterpriseCode;

        //    //status = goodsSelectGuide.ReadGoods(owner, false, goodsCndtn, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
        //    status = goodsSelectGuide.ReadGoods(owner, false, goodsCndtn, out goodsUnitDataList, out message);


        //    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
        //    {
        //        goodsCode = goodsUnitDataList[0].GoodsNo;
        //        goodsName = goodsUnitDataList[0].GoodsName;

        //        makerName = goodsUnitDataList[0].MakerName;
        //        goodsMakerCd = goodsUnitDataList[0].GoodsMakerCd;
        //    }
        //    return (status);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

		// ===================================================================================== //
		// ���i�֘A����
		// ===================================================================================== //
		# region Goods Control Methods

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        ///// <summary>
        ///// �����^�C�v�擾����
        ///// </summary>
        ///// <param name="inputCode">���͂��ꂽ�R�[�h</param>
        ///// <param name="searchCode">�����p�R�[�h�i*�������j</param>
        ///// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
        //public static int GetSearchType(string inputCode, out string searchCode)
        //{
        //    searchCode = inputCode;
        //    if (String.IsNullOrEmpty(inputCode)) return 0;

        //    if (inputCode.Contains("*"))
        //    {
        //        searchCode = inputCode.Replace("*", "");
        //        string firstString = inputCode.Substring(0, 1);
        //        string lastString = inputCode.Substring(inputCode.Length - 1, 1);

        //        if ((firstString == "*") && (lastString == "*"))
        //        {
        //            return 3;
        //        }
        //        else if (firstString == "*")
        //        {
        //            return 2;
        //        }
        //        else if (lastString == "*")
        //        {
        //            return 1;
        //        }
        //        else
        //        {
        //            return 3;
        //        }
        //    }
        //    else
        //    {
        //        // *�����݂��Ȃ����ߊ��S��v����
        //        return 0;
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

		# endregion

		/// <summary>
        /// ���_����A�N�Z�X�N���X�C���X�^���X������
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            //if (_secInfoAcs == null)
            //{
            //    _secInfoAcs = new SecInfoAcs();
            //}

            //// ���O�C���S�����_���̎擾
            //if (_secInfoAcs.SecInfoSet == null)
            //{
            //    throw new ApplicationException(MESSAGE_NONOWNSECTION);
            //}
        }

        /// <summary>
        /// �{�Ћ@�\�^���_�@�\�`�F�b�N����
        /// </summary>
        /// <returns>true:�{�Ћ@�\ false:���_�@�\</returns>
        public bool IsMainOfficeFunc()
        {
            bool isMainOfficeFunc = true;// ��ɖ{�Ћ@�\�Ƃ��Ďg�p
            //bool isMainOfficeFunc = false;

            //// ���_����A�N�Z�X�N���X�C���X�^���X������
            //this.CreateSecInfoAcs();

            //// ���O�C���S�����_���̎擾
            //SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            //if (secInfoSet != null)
            //{
            //    // �{�Ћ@�\���H
            //    if (secInfoSet.MainOfficeFuncFlag == 1)
            //    {
            //        isMainOfficeFunc = true;
            //    }
            //}
            //else
            //{
            //    throw new ApplicationException(MESSAGE_NONOWNSECTION);
            //}

            return isMainOfficeFunc;
        }

		/// <summary>
		/// ���t��������擾���܂��B
		/// </summary>
		/// <param name="date">���t</param>
		/// <param name="format">�t�H�[�}�b�g������</param>
		/// <returns>���t������</returns>
		public static string GetDateTimeString(DateTime date, string format)
		{
			if (date == DateTime.MinValue)
			{
				return "";
			}
			else
			{
				return date.ToString(format);
			}
		}

        // ADD 2009/04/09 ------>>>
        public string GetSubSectionName(int subSectionCode)
        {
            if (this._subSectionDic.ContainsKey(subSectionCode))
            {
                return this._subSectionDic[subSectionCode].SubSectionName.Trim();
            }
            else
            {
                return "";
            }
        }

        public int ExecuteSubSectionGuide(out SubSection subSection)
        {
            int status = this._subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode);

            return status;
        }
        // ADD 2009/04/09 ------<<<
        # endregion

    }
}
