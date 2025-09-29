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
    /// <br></br>
    /// <br>Update Note : 2010/05/25�@22008 ���� ���n</br>
    /// <br>              �I�t���C���Ή�</br>
    /// <br></br>
    /// <br>Update Note : 2011/11/11 ���N�n�� Redmine 26539�Ή�</br>
    /// <br>Update Note : 2011/11/16 ���N�n�� Redmine 26539�Ή�</br>
    /// </remarks>
	public partial class DCHNB04102AA
    {
        # region ��Private Member
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private ISalHisRefDB _iSalHisRefDB = null;
        /// <summary>���_�I�v�V�����t���O</summary>
        private bool _optSection;
		private StockDataSet _dataSet;
		private DataView _salesDetailView;
        private static StockDataSet.SalesDetailDataTable _stockSlipCache;
        private static SalHisRefExtraParamWork _paraStockSlipCache;
        private static SortedList _nameList;
        private static DCHNB04102AA _searchSlipAcs;

        private string _enterpriseCode;             // ��ƃR�[�h

        private const string MESSAGE_NoResult = "���������Ɉ�v����`�[�͑��݂��܂���B";
        private const string MESSAGE_ErrResult = "�`�[���̎擾�Ɏ��s���܂����B";
		private const string ct_DateFormat = "yyyy/MM/dd";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
        private int _maxSelectCount; // �ő�I���\�s��
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

        # endregion

        // �f���Q�[�g����
        public event GetNameListEventHandler GetNameList;
        public delegate SortedList GetNameListEventHandler();

        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
        // �s�I����ԕύX�C�x���g
        /// <summary>�s�I����ԕύX�C�x���g</summary>
        public event SelectedDataChangeEventHandler SelectedDataChange;
        public delegate void SelectedDataChangeEventHandler( object sender, bool status, int count );
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

        # region ��Constracter
        /// <summary>
        /// �`�[���� �e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�啪�ރ}�X�^ �e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public DCHNB04102AA()
        {
            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // ���_OP�̔���
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
            this._dataSet = new StockDataSet();
			this._salesDetailView = new DataView(this._dataSet.SalesDetail);


            //this._stockDetailDBDataList = new List<StockDetail>();
            //this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();

            // ���O�C�����i�ŒʐM��Ԃ��m�F
            // -- UPD 2010/05/25 --------------------------------->>>
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // �����[�g�I�u�W�F�N�g�擾
            //        this._iSalHisRefDB = (ISalHisRefDB)MediationSalHisRefDB.GetSalHisRefDB();
            //    }
            //    catch (Exception)
            //    {
            //        //�I�t���C������null���Z�b�g
            //        this._iSalHisRefDB = null;
            //    }
            //}
            //else
            //{
            //    // �I�t���C�����̃f�[�^�ǂݍ���
            //    //this.SearchOfflineData();
            //    MessageBox.Show("�I�t���C����Ԃ̂��ߌ��������s�ł��܂���B");
            //}

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iSalHisRefDB = (ISalHisRefDB)MediationSalHisRefDB.GetSalHisRefDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iSalHisRefDB = null;
            }
            // -- UPD 2010/05/25 ---------------------------------<<<
        }
        # endregion

        /// <summary>
        /// �`�[�����A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�`�[�����A�N�Z�X�N���X �C���X�^���X</returns>
        public static DCHNB04102AA GetInstance()
        {
            if (_searchSlipAcs == null)
            {
                _searchSlipAcs = new DCHNB04102AA();
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

		/// <summary>
		/// ���㗚��DataView
		/// </summary>
		public DataView SalesDetailView
		{
			get { return this._salesDetailView; }
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
        /// <summary>
        /// �I���\���א� �v���p�e�B
        /// </summary>
        public int MaxSelectCount
        {
            get { return _maxSelectCount; }
            set { _maxSelectCount = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD


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
            if (this._iSalHisRefDB == null)
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
                _stockSlipCache = new StockDataSet.SalesDetailDataTable();
            }

            this._dataSet.SalesDetail.AcceptChanges();
            _stockSlipCache = (StockDataSet.SalesDetailDataTable)this._dataSet.SalesDetail.Copy();
        }

        /// <summary>
        /// ���������N���X(�ĕ\���p) �L���b�V������
        /// </summary>
        private void CacheParaStockSlip(SalHisRefExtraParamWork salHisRefExtraParamWork)
        {
            // ���������l
            if (_paraStockSlipCache == null)
            {
                _paraStockSlipCache = new SalHisRefExtraParamWork();
            }
            _paraStockSlipCache = salHisRefExtraParamWork;

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
        /// <br>Update Note: 2011/11/11 ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// <br>Update Note: 2011/11/16 ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// </remarks>
        public int SetSearchData(SalHisRefExtraParamWork salHisRefExtraParamWork)
        {
            List<SalHisRefResultParamWork> retData;
			string salesDateString = "";
			string memoExistName = "";

			string salesGoodsCdString = "";
			string salesSlipCdDtlString = "";
			string acptAnOdrStatusString = "";
            
			long salesMoneyTaxExc = 0;
            long salesPriceConsTax = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            long salesMoneyTaxInc = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

            long shipmentLeftCnt = 0;   // �o�׎c��
            long salesCost = 0;         // �������z
            string modelCategoryNo = "";// �ޕʌ`��
            string debitNoteDivStr = "";// �ԓ`�敪


            int status = this.Search(out retData, salHisRefExtraParamWork);

            this.ClearStockSlipDataTable();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                for (int i = 0; i < retData.Count; i++)
                {
					SalHisRefResultParamWork salHisRefResultParamWork = retData[i];

					//�����
					salesDateString = GetDateTimeString(salHisRefResultParamWork.SalesDate, ct_DateFormat);

					//��������
					if((salHisRefResultParamWork.SlipMemo1.Trim() != "")
					|| (salHisRefResultParamWork.SlipMemo2.Trim() != "")
					|| (salHisRefResultParamWork.SlipMemo3.Trim() != "")
					//|| (salHisRefResultParamWork.SlipMemo4.Trim() != "")
					//|| (salHisRefResultParamWork.SlipMemo5.Trim() != "")
					//|| (salHisRefResultParamWork.SlipMemo6.Trim() != "")
					|| (salHisRefResultParamWork.InsideMemo1.Trim() != "")
					|| (salHisRefResultParamWork.InsideMemo2.Trim() != "")
					|| (salHisRefResultParamWork.InsideMemo3.Trim() != "")
					//|| (salHisRefResultParamWork.InsideMemo4.Trim() != "")
					//|| (salHisRefResultParamWork.InsideMemo5.Trim() != "")
					//|| (salHisRefResultParamWork.InsideMemo6.Trim() != "")
                        )
					{
						memoExistName = "��";
					}
					else
					{
						memoExistName = "";
					}

					// ���i�敪
					// 0:���i, 1:���i�O, 2:����Œ���, 3:�c������, 4:���|�p����Œ���, 5:���|�p�c������
					switch (salHisRefResultParamWork.SalesGoodsCd)
					{
						case 0: salesGoodsCdString = "���i"; break;
						case 1: salesGoodsCdString = "���i�O"; break;
						case 2: salesGoodsCdString = "����Œ���"; break;
						case 3: salesGoodsCdString = "�c������"; break;
						case 4: salesGoodsCdString = "���|�p����Œ���"; break;
						case 5: salesGoodsCdString = "���|�p�c������"; break;
						default: salesGoodsCdString = ""; break;
					}

					// �`�[�敪
                    // 0:����, 1:�ԕi, 2:�l��, 3:����, 4:���v, 5:���, 9:�ꎮ
					switch (salHisRefResultParamWork.SalesSlipCdDtl)
					{
						case 0: salesSlipCdDtlString = "����"; break;
						case 1: salesSlipCdDtlString = "�ԕi"; break;
						case 2: salesSlipCdDtlString = "�l��"; break;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                        case 3: salesSlipCdDtlString = "����"; break;
                        case 4: salesSlipCdDtlString = "���v"; break;
                        case 5: salesSlipCdDtlString = "���"; break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
						case 9: salesSlipCdDtlString = "�ꎮ"; break;
						default: salesSlipCdDtlString = ""; break;
					}

					// �`�[�敪
					// 10:����, 20:��, 30:����, 40:�o��
					switch (salHisRefResultParamWork.AcptAnOdrStatus)
					{
                        case 10: acptAnOdrStatusString = "����"; break;
						case 20: acptAnOdrStatusString = "��"; break;
						case 30: acptAnOdrStatusString = "����"; break;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                        //case 40: acptAnOdrStatusString = "�o��"; break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                        case 40: acptAnOdrStatusString = "�ݏo"; break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
						default: acptAnOdrStatusString = ""; break;
					}

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
                    ////����Œ����E�c������
                    //if ((salHisRefResultParamWork.SalesGoodsCd == 2) || (salHisRefResultParamWork.SalesGoodsCd == 4))
                    //{
                    //    salesMoneyTaxExc = 0;
                    //    //salesPriceConsTax = salHisRefResultParamWork.SalesPriceConsTax;
                    //    salesPriceConsTax = salHisRefResultParamWork.SalesMoneyTaxInc - salHisRefResultParamWork.SalesMoneyTaxExc;
                    //}
                    //else if ((salHisRefResultParamWork.SalesGoodsCd == 3) || (salHisRefResultParamWork.SalesGoodsCd == 5))
                    //{
                    //    salesMoneyTaxExc = salHisRefResultParamWork.SalesMoneyTaxInc;
                    //    salesPriceConsTax = 0;
                    //}
                    //else
                    //{
                    //    salesMoneyTaxExc = salHisRefResultParamWork.SalesMoneyTaxExc;
                    //    //salsePriceConsTax = salHisRefResultParamWork.SalsePriceConsTax;
                    //    salesPriceConsTax = salHisRefResultParamWork.SalesMoneyTaxInc - salHisRefResultParamWork.SalesMoneyTaxExc;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                    //// �o�׎c��
                    //shipmentLeftCnt = long.Parse( (salHisRefResultParamWork.ShipmentCnt - salHisRefResultParamWork.CmpltShipmentCnt).ToString() );

                    //// �������z (�����P�� * ���㐔)
                    //salesCost = long.Parse( (salHisRefResultParamWork.SalesUnitCost * salHisRefResultParamWork.ShipmentCnt).ToString() );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                    // �o�׎c��
                    shipmentLeftCnt = (long)(salHisRefResultParamWork.ShipmentCnt - salHisRefResultParamWork.CmpltShipmentCnt);

                    // �������z (�����P�� * ���㐔)
                    //salesCost = (long)(salHisRefResultParamWork.SalesUnitCost * salHisRefResultParamWork.ShipmentCnt);
                    salesCost = (long)Math.Floor(salHisRefResultParamWork.SalesUnitCost * salHisRefResultParamWork.ShipmentCnt + 0.5);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                    //// �ޕʌ`��
                    //modelCategoryNo = salHisRefResultParamWork.ModelDesignationNo.ToString().PadLeft(5, '0') + "-" + salHisRefResultParamWork.CategoryNo.ToString().PadLeft(4, '0');
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                    // �ޕʌ`��
                    if ( salHisRefResultParamWork.ModelDesignationNo == 0 && salHisRefResultParamWork.CategoryNo == 0 )
                    {
                        modelCategoryNo = string.Empty;
                    }
                    else
                    {
                        modelCategoryNo = salHisRefResultParamWork.ModelDesignationNo.ToString().PadLeft( 5, '0' ) + "-" + salHisRefResultParamWork.CategoryNo.ToString().PadLeft( 4, '0' );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

                    // �ԓ`�敪
                    // 0:���`, 1:�ԓ`, 2:����
            		switch (salHisRefResultParamWork.DebitNoteDiv)
                    {
                        case 0: debitNoteDivStr = "���`"; break;
                        case 1: debitNoteDivStr = "�ԓ`"; break;
                        case 2: debitNoteDivStr = "����"; break;
                        default: debitNoteDivStr = ""; break;
                    }
                    
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                    # region // DEL
                    //_dataSet.SalesDetail.AddSalesDetailRow(i + 1, 
                    //                                    false,
                    //                                    salHisRefResultParamWork.EnterpriseCode,
                    //                                    salHisRefResultParamWork.LogicalDeleteCode,
                    //                                    salHisRefResultParamWork.AcceptAnOrderNo,
                    //                                    salHisRefResultParamWork.AcptAnOdrStatus,
                    //                                    acptAnOdrStatusString,//salHisRefResultParamWork.AcptAnOdrStatusString
                    //                                    salHisRefResultParamWork.SalesSlipNum,
                    //                                    salHisRefResultParamWork.SalesRowNo,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.SalesRowDerivNo,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.SectionCode,
                    //                                    salHisRefResultParamWork.SectionGuideNm,
                    //                                    salHisRefResultParamWork.SubSectionCode,
                    //                                    salHisRefResultParamWork.SubSectionName,
                    //                                    //salHisRefResultParamWork.MinSectionCode,
                    //                                    salHisRefResultParamWork.SalesDate,
                    //                                    salesDateString,
                    //                                    salHisRefResultParamWork.CommonSeqNo,
                    //                                    salHisRefResultParamWork.SalesSlipDtlNum,
                    //                                    salHisRefResultParamWork.AcptAnOdrStatusSrc,
                    //                                    salHisRefResultParamWork.SalesSlipDtlNumSrc,
                    //                                    salHisRefResultParamWork.SupplierFormalSync,
                    //                                    salHisRefResultParamWork.StockSlipDtlNumSync,
                    //                                    salHisRefResultParamWork.SalesSlipCdDtl,
                    //                                    //salHisRefResultParamWork.ServiceSlipCd,
                    //                                    //salHisRefResultParamWork.SalesDepositsDiv,
                    //                                    //salHisRefResultParamWork.StockMngExistCd,
                    //                                    salHisRefResultParamWork.GoodsKindCode,
                    //                                    salHisRefResultParamWork.GoodsMakerCd,
                    //                                    salHisRefResultParamWork.MakerName,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.MakerKanaName,
                    //                                    salHisRefResultParamWork.CmpltMakerKanaName,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.GoodsNo,
                    //                                    salHisRefResultParamWork.GoodsName,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.GoodsNameKana,
                    //                                    salHisRefResultParamWork.GoodsLGroup,
                    //                                    salHisRefResultParamWork.GoodsLGroupName,
                    //                                    salHisRefResultParamWork.GoodsMGroup,
                    //                                    salHisRefResultParamWork.GoodsMGroupName,
                    //                                    salHisRefResultParamWork.BLGroupCode,
                    //                                    salHisRefResultParamWork.BLGroupName,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    //salHisRefResultParamWork.GoodsSetDivCd,
                    //                                    //salHisRefResultParamWork.LargeGoodsGanreCode,
                    //                                    //salHisRefResultParamWork.LargeGoodsGanreName,
                    //                                    //salHisRefResultParamWork.MediumGoodsGanreCode,
                    //                                    //salHisRefResultParamWork.MediumGoodsGanreName,
                    //                                    //salHisRefResultParamWork.DetailGoodsGanreCode,
                    //                                    //salHisRefResultParamWork.DetailGoodsGanreName,
                    //                                    salHisRefResultParamWork.BLGoodsCode,
                    //                                    salHisRefResultParamWork.BLGoodsFullName,
                    //                                    salHisRefResultParamWork.EnterpriseGanreCode,
                    //                                    salHisRefResultParamWork.EnterpriseGanreName,
                    //                                    salHisRefResultParamWork.WarehouseCode,
                    //                                    salHisRefResultParamWork.WarehouseName,
                    //                                    salHisRefResultParamWork.WarehouseShelfNo,
                    //                                    salHisRefResultParamWork.SalesOrderDivCd,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.OpenPriceDiv,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    //salHisRefResultParamWork.UnitCode,
                    //                                    //salHisRefResultParamWork.UnitName,
                    //                                    salHisRefResultParamWork.GoodsRateRank,
                    //                                    salHisRefResultParamWork.CustRateGrpCode,
                    //                                    //salHisRefResultParamWork.SuppRateGrpCode,
                    //                                    salHisRefResultParamWork.ListPriceRate,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.RateSectPriceUnPrc,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.RateDivLPrice,
                    //                                    salHisRefResultParamWork.UnPrcCalcCdLPrice,
                    //                                    salHisRefResultParamWork.PriceCdLPrice,
                    //                                    salHisRefResultParamWork.StdUnPrcLPrice,
                    //                                    salHisRefResultParamWork.FracProcUnitLPrice,
                    //                                    salHisRefResultParamWork.FracProcLPrice,
                    //                                    salHisRefResultParamWork.ListPriceTaxIncFl,
                    //                                    salHisRefResultParamWork.ListPriceTaxExcFl,
                    //                                    salHisRefResultParamWork.ListPriceChngCd,
                    //                                    salHisRefResultParamWork.SalesRate,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.RateSectSalUnPrc,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.RateDivSalUnPrc,
                    //                                    salHisRefResultParamWork.UnPrcCalcCdSalUnPrc,
                    //                                    salHisRefResultParamWork.PriceCdSalUnPrc,
                    //                                    salHisRefResultParamWork.StdUnPrcSalUnPrc,
                    //                                    salHisRefResultParamWork.FracProcUnitSalUnPrc,
                    //                                    salHisRefResultParamWork.FracProcSalUnPrc,
                    //                                    salHisRefResultParamWork.SalesUnPrcTaxIncFl,
                    //                                    salHisRefResultParamWork.SalesUnPrcTaxExcFl,
                    //                                    salHisRefResultParamWork.SalesUnPrcChngCd,
                    //                                    salHisRefResultParamWork.CostRate,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.RateSectCstUnPrc,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.RateDivUnCst,
                    //                                    salHisRefResultParamWork.UnPrcCalcCdUnCst,
                    //                                    salHisRefResultParamWork.PriceCdUnCst,
                    //                                    salHisRefResultParamWork.StdUnPrcUnCst,
                    //                                    salHisRefResultParamWork.FracProcUnitUnCst,
                    //                                    salHisRefResultParamWork.FracProcUnCst,
                    //                                    salHisRefResultParamWork.SalesUnitCost,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salesCost,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.SalesUnitCostChngDiv,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.RateBLGoodsCode,
                    //                                    salHisRefResultParamWork.RateBLGoodsName,
                    //                                    salHisRefResultParamWork.PrtBLGoodsCode,
                    //                                    salHisRefResultParamWork.PrtBLGoodsName,
                    //                                    salHisRefResultParamWork.SalesCode,
                    //                                    salHisRefResultParamWork.SalesCdNm,
                    //                                    salHisRefResultParamWork.WorkManHour,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    //salHisRefResultParamWork.BargainCd,
                    //                                    //salHisRefResultParamWork.BargainNm,
                    //                                    salHisRefResultParamWork.ShipmentCnt,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    shipmentLeftCnt,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.SalesMoneyTaxInc,
                    //                                    salesMoneyTaxExc,
                    //                                    salHisRefResultParamWork.Cost,
                    //                                    salHisRefResultParamWork.GrsProfitChkDiv,
                    //                                    salHisRefResultParamWork.SalesGoodsCd,
                    //                                    salesPriceConsTax,
                    //                                    //salHisRefResultParamWork.TaxAdjust,
                    //                                    //salHisRefResultParamWork.BalanceAdjust,
                    //                                    salHisRefResultParamWork.TaxationDivCd,
                    //                                    salHisRefResultParamWork.PartySlipNumDtl,
                    //                                    salHisRefResultParamWork.DtlNote,
                    //                                    salHisRefResultParamWork.SupplierCd,
                    //                                    salHisRefResultParamWork.SupplierSnm,
                    //                                    //salHisRefResultParamWork.ResultsAddUpSecCd,
                    //                                    salHisRefResultParamWork.OrderNumber,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.WayToOrder,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.SlipMemo1,
                    //                                    salHisRefResultParamWork.SlipMemo2,
                    //                                    salHisRefResultParamWork.SlipMemo3,
                    //                                    //salHisRefResultParamWork.SlipMemo4,
                    //                                    //salHisRefResultParamWork.SlipMemo5,
                    //                                    //salHisRefResultParamWork.SlipMemo6,
                    //                                    salHisRefResultParamWork.InsideMemo1,
                    //                                    salHisRefResultParamWork.InsideMemo2,
                    //                                    salHisRefResultParamWork.InsideMemo3,
                    //                                    //salHisRefResultParamWork.InsideMemo4,
                    //                                    //salHisRefResultParamWork.InsideMemo5,
                    //                                    //salHisRefResultParamWork.InsideMemo6,
                    //                                    salHisRefResultParamWork.BfListPrice,
                    //                                    salHisRefResultParamWork.BfSalesUnitPrice,
                    //                                    salHisRefResultParamWork.BfUnitCost,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.CmpltSalesRowNo,
                    //                                    salHisRefResultParamWork.CmpltGoodsMakerCd,
                    //                                    salHisRefResultParamWork.CmpltMakerName,
                    //                                    salHisRefResultParamWork.CmpltGoodsName,
                    //                                    salHisRefResultParamWork.CmpltShipmentCnt,
                    //                                    salHisRefResultParamWork.CmpltSalesUnPrcFl,
                    //                                    salHisRefResultParamWork.CmpltSalesMoney,
                    //                                    salHisRefResultParamWork.CmpltSalesUnitCost,
                    //                                    salHisRefResultParamWork.CmpltCost,
                    //                                    salHisRefResultParamWork.CmpltPartySalSlNum,
                    //                                    salHisRefResultParamWork.CmpltNote,
                    //                                    salHisRefResultParamWork.CarMngCode,
                    //                                    salHisRefResultParamWork.ModelDesignationNo,
                    //                                    salHisRefResultParamWork.CategoryNo,
                    //                                    modelCategoryNo,
                    //                                    salHisRefResultParamWork.MakerFullName,
                    //                                    salHisRefResultParamWork.FullModel,
                    //                                    salHisRefResultParamWork.ModelFullName,
                    //                                    salHisRefResultParamWork.SearchSlipDate,
                    //                                    salHisRefResultParamWork.ShipmentDay,
                    //                                    salHisRefResultParamWork.AddUpADate,
                    //                                    salHisRefResultParamWork.InputAgenCd,
                    //                                    salHisRefResultParamWork.InputAgenNm,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    //salHisRefResultParamWork.PrtGoodsNo,
                    //                                    //salHisRefResultParamWork.PrtGoodsName,
                    //                                    //salHisRefResultParamWork.PrtGoodsMakerCd,
                    //                                    //salHisRefResultParamWork.PrtGoodsMakerNm,
                    //                                    salHisRefResultParamWork.SalesInputCode,
                    //                                    salHisRefResultParamWork.SalesInputName,
                    //                                    salHisRefResultParamWork.FrontEmployeeCd,
                    //                                    salHisRefResultParamWork.FrontEmployeeNm,
                    //                                    salHisRefResultParamWork.SalesEmployeeCd,
                    //                                    salHisRefResultParamWork.SalesEmployeeNm,
                    //                                    //salHisRefResultParamWork.MinSectionName,
                    //                                    //salHisRefResultParamWork.SalesSlipCd,
                    //                                    //salHisRefResultParamWork.AccRecDivCd,
                    //                                    salHisRefResultParamWork.ClaimCode,
                    //                                    salHisRefResultParamWork.ClaimSnm,
                    //                                    salesGoodsCdString,	//SalesGoodsCdString
                    //                                    salesSlipCdDtlString, //SalesGoodsCdString
                    //                                    salHisRefResultParamWork.CustomerCode,
                    //                                    //salHisRefResultParamWork.CustomerName,
                    //                                    //salHisRefResultParamWork.CustomerName2,
                    //                                    salHisRefResultParamWork.CustomerSnm,
                    //                                    salHisRefResultParamWork.AddresseeCode,
                    //                                    salHisRefResultParamWork.AddresseeName,
                    //                                    salHisRefResultParamWork.AddresseeName2,
                    //                                    memoExistName,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.DebitNoteDiv,
                    //                                    debitNoteDivStr,
                    //                                    salHisRefResultParamWork.AcptAnOdrRemainCnt,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA ADD END
                    //                                    0
                    //                                   );
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
                    // ����ŕ\���Ή�

                    salesMoneyTaxExc = salHisRefResultParamWork.SalesMoneyTaxExc;
                    salesPriceConsTax = salHisRefResultParamWork.SalesMoneyTaxInc - salHisRefResultParamWork.SalesMoneyTaxExc;
                    salesMoneyTaxInc = salHisRefResultParamWork.SalesMoneyTaxInc;

                    // �ݒ�K�p�i����ŕ\���Ή��j
                    ReflectMoneyForTaxPrint( ref salesMoneyTaxExc, ref salesPriceConsTax, ref salesMoneyTaxInc, salHisRefResultParamWork.TotalAmountDispWayCd, salHisRefResultParamWork.ConsTaxLayMethod, salHisRefResultParamWork.TaxationDivCd );

                    # region [���㏤�i�敪]
                    switch ( salHisRefResultParamWork.SalesGoodsCd )
                    {
                        case 2:
                        case 4:
                            // 2:����Œ���,4:���|�p����Œ���
                            salesMoneyTaxExc = 0;
                            break;
                        case 3:
                        case 5:
                            // 3:�c������,5:���|�p�c������
                            salesMoneyTaxExc = salesMoneyTaxInc;
                            salesPriceConsTax = 0;
                            break;
                        default:
                            break;
                    }
                    # endregion

                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                    StockDataSet.SalesDetailRow row = _dataSet.SalesDetail.NewSalesDetailRow();

                    # region [row]
                    row.EnterpriseCode = salHisRefResultParamWork.EnterpriseCode;
                    row.LogicalDeleteCode = salHisRefResultParamWork.LogicalDeleteCode;
                    row.AcceptAnOrderNo = salHisRefResultParamWork.AcceptAnOrderNo;
                    row.AcptAnOdrStatus = salHisRefResultParamWork.AcptAnOdrStatus;
                    row.SalesSlipNum = salHisRefResultParamWork.SalesSlipNum;
                    row.SalesRowNo = salHisRefResultParamWork.SalesRowNo;
                    row.SalesRowDerivNo = salHisRefResultParamWork.SalesRowDerivNo;
                    row.SectionCode = salHisRefResultParamWork.SectionCode;
                    row.SectionGuideNm = salHisRefResultParamWork.SectionGuideNm;
                    row.SubSectionCode = salHisRefResultParamWork.SubSectionCode;
                    row.SubSectionName = salHisRefResultParamWork.SubSectionName;
                    row.SalesDate = salHisRefResultParamWork.SalesDate;
                    row.CommonSeqNo = salHisRefResultParamWork.CommonSeqNo;
                    row.SalesSlipDtlNum = salHisRefResultParamWork.SalesSlipDtlNum;
                    row.AcptAnOdrStatusSrc = salHisRefResultParamWork.AcptAnOdrStatusSrc;
                    row.SalesSlipDtlNumSrc = salHisRefResultParamWork.SalesSlipDtlNumSrc;
                    row.SupplierFormalSync = salHisRefResultParamWork.SupplierFormalSync;
                    row.StockSlipDtlNumSync = salHisRefResultParamWork.StockSlipDtlNumSync;
                    row.SalesSlipCdDtl = salHisRefResultParamWork.SalesSlipCdDtl;
                    row.GoodsKindCode = salHisRefResultParamWork.GoodsKindCode;
                    row.GoodsMakerCd = salHisRefResultParamWork.GoodsMakerCd;
                    row.MakerName = salHisRefResultParamWork.MakerName;
                    row.MakerKanaName = salHisRefResultParamWork.MakerKanaName;
                    row.CmpltMakerKanaName = salHisRefResultParamWork.CmpltMakerKanaName;
                    row.GoodsNo = salHisRefResultParamWork.GoodsNo;
                    row.GoodsName = salHisRefResultParamWork.GoodsName;
                    row.GoodsNameKana = salHisRefResultParamWork.GoodsNameKana;
                    row.GoodsLGroup = salHisRefResultParamWork.GoodsLGroup;
                    row.GoodsLGroupName = salHisRefResultParamWork.GoodsLGroupName;
                    row.GoodsMGroup = salHisRefResultParamWork.GoodsMGroup;
                    row.GoodsMGroupName = salHisRefResultParamWork.GoodsMGroupName;
                    row.BLGroupCode = salHisRefResultParamWork.BLGroupCode;
                    row.BLGroupName = salHisRefResultParamWork.BLGroupName;
                    row.BLGoodsCode = salHisRefResultParamWork.BLGoodsCode;
                    row.BLGoodsFullName = salHisRefResultParamWork.BLGoodsFullName;
                    row.EnterpriseGanreCode = salHisRefResultParamWork.EnterpriseGanreCode;
                    row.EnterpriseGanreName = salHisRefResultParamWork.EnterpriseGanreName;
                    row.WarehouseCode = salHisRefResultParamWork.WarehouseCode;
                    row.WarehouseName = salHisRefResultParamWork.WarehouseName;
                    row.WarehouseShelfNo = salHisRefResultParamWork.WarehouseShelfNo;
                    row.SalesOrderDivCd = salHisRefResultParamWork.SalesOrderDivCd;
                    row.OpenPriceDiv = salHisRefResultParamWork.OpenPriceDiv;
                    row.GoodsRateRank = salHisRefResultParamWork.GoodsRateRank;
                    row.CustRateGrpCode = salHisRefResultParamWork.CustRateGrpCode;
                    row.ListPriceRate = salHisRefResultParamWork.ListPriceRate;
                    row.RateSectPriceUnPrc = salHisRefResultParamWork.RateSectPriceUnPrc;
                    row.RateDivLPrice = salHisRefResultParamWork.RateDivLPrice;
                    row.UnPrcCalcCdLPrice = salHisRefResultParamWork.UnPrcCalcCdLPrice;
                    row.PriceCdLPrice = salHisRefResultParamWork.PriceCdLPrice;
                    row.StdUnPrcLPrice = salHisRefResultParamWork.StdUnPrcLPrice;
                    row.FracProcUnitLPrice = salHisRefResultParamWork.FracProcUnitLPrice;
                    row.FracProcLPrice = salHisRefResultParamWork.FracProcLPrice;
                    row.ListPriceTaxIncFl = salHisRefResultParamWork.ListPriceTaxIncFl;
                    row.ListPriceTaxExcFl = salHisRefResultParamWork.ListPriceTaxExcFl;
                    row.ListPriceChngCd = salHisRefResultParamWork.ListPriceChngCd;
                    row.SalesRate = salHisRefResultParamWork.SalesRate;
                    row.RateSectSalUnPrc = salHisRefResultParamWork.RateSectSalUnPrc;
                    row.RateDivSalUnPrc = salHisRefResultParamWork.RateDivSalUnPrc;
                    row.UnPrcCalcCdSalUnPrc = salHisRefResultParamWork.UnPrcCalcCdSalUnPrc;
                    row.PriceCdSalUnPrc = salHisRefResultParamWork.PriceCdSalUnPrc;
                    row.StdUnPrcSalUnPrc = salHisRefResultParamWork.StdUnPrcSalUnPrc;
                    row.FracProcUnitSalUnPrc = salHisRefResultParamWork.FracProcUnitSalUnPrc;
                    row.FracProcSalUnPrc = salHisRefResultParamWork.FracProcSalUnPrc;
                    row.SalesUnPrcTaxIncFl = salHisRefResultParamWork.SalesUnPrcTaxIncFl;
                    row.SalesUnPrcTaxExcFl = salHisRefResultParamWork.SalesUnPrcTaxExcFl;
                    row.SalesUnPrcChngCd = salHisRefResultParamWork.SalesUnPrcChngCd;
                    row.CostRate = salHisRefResultParamWork.CostRate;
                    row.RateSectCstUnPrc = salHisRefResultParamWork.RateSectCstUnPrc;
                    row.RateDivUnCst = salHisRefResultParamWork.RateDivUnCst;
                    row.UnPrcCalcCdUnCst = salHisRefResultParamWork.UnPrcCalcCdUnCst;
                    row.PriceCdUnCst = salHisRefResultParamWork.PriceCdUnCst;
                    row.StdUnPrcUnCst = salHisRefResultParamWork.StdUnPrcUnCst;
                    row.FracProcUnitUnCst = salHisRefResultParamWork.FracProcUnitUnCst;
                    row.FracProcUnCst = salHisRefResultParamWork.FracProcUnCst;
                    row.SalesUnitCost = salHisRefResultParamWork.SalesUnitCost;
                    row.SalesUnitCostChngDiv = salHisRefResultParamWork.SalesUnitCostChngDiv;
                    row.RateBLGoodsCode = salHisRefResultParamWork.RateBLGoodsCode;
                    row.RateBLGoodsName = salHisRefResultParamWork.RateBLGoodsName;
                    row.PrtBLGoodsCode = salHisRefResultParamWork.PrtBLGoodsCode;
                    row.PrtBLGoodsName = salHisRefResultParamWork.PrtBLGoodsName;
                    row.SalesCode = salHisRefResultParamWork.SalesCode;
                    row.SalesCdNm = salHisRefResultParamWork.SalesCdNm;
                    row.WorkManHour = salHisRefResultParamWork.WorkManHour;
                    row.ShipmentCnt = salHisRefResultParamWork.ShipmentCnt;
                    row.Cost = salHisRefResultParamWork.Cost;
                    row.GrsProfitChkDiv = salHisRefResultParamWork.GrsProfitChkDiv;
                    row.SalesGoodsCd = salHisRefResultParamWork.SalesGoodsCd;
                    row.TaxationDivCd = salHisRefResultParamWork.TaxationDivCd;
                    row.PartySlipNumDtl = salHisRefResultParamWork.PartySlipNumDtl;
                    row.DtlNote = salHisRefResultParamWork.DtlNote;
                    row.SupplierCd = salHisRefResultParamWork.SupplierCd;
                    row.SupplierSnm = salHisRefResultParamWork.SupplierSnm;
                    row.OrderNumber = salHisRefResultParamWork.OrderNumber;
                    row.WayToOrder = salHisRefResultParamWork.WayToOrder;
                    row.SlipMemo1 = salHisRefResultParamWork.SlipMemo1;
                    row.SlipMemo2 = salHisRefResultParamWork.SlipMemo2;
                    row.SlipMemo3 = salHisRefResultParamWork.SlipMemo3;
                    row.InsideMemo1 = salHisRefResultParamWork.InsideMemo1;
                    row.InsideMemo2 = salHisRefResultParamWork.InsideMemo2;
                    row.InsideMemo3 = salHisRefResultParamWork.InsideMemo3;
                    row.BfListPrice = salHisRefResultParamWork.BfListPrice;
                    row.BfSalesUnitPrice = salHisRefResultParamWork.BfSalesUnitPrice;
                    row.BfUnitCost = salHisRefResultParamWork.BfUnitCost;
                    row.CmpltSalesRowNo = salHisRefResultParamWork.CmpltSalesRowNo;
                    row.CmpltGoodsMakerCd = salHisRefResultParamWork.CmpltGoodsMakerCd;
                    row.CmpltMakerName = salHisRefResultParamWork.CmpltMakerName;
                    row.CmpltGoodsName = salHisRefResultParamWork.CmpltGoodsName;
                    row.CmpltShipmentCnt = salHisRefResultParamWork.CmpltShipmentCnt;
                    row.CmpltSalesUnPrcFl = salHisRefResultParamWork.CmpltSalesUnPrcFl;
                    row.CmpltSalesMoney = salHisRefResultParamWork.CmpltSalesMoney;
                    row.CmpltSalesUnitCost = salHisRefResultParamWork.CmpltSalesUnitCost;
                    row.CmpltCost = salHisRefResultParamWork.CmpltCost;
                    row.CmpltPartySalSlNum = salHisRefResultParamWork.CmpltPartySalSlNum;
                    row.CmpltNote = salHisRefResultParamWork.CmpltNote;
                    row.CarMngCode = salHisRefResultParamWork.CarMngCode;
                    row.ModelDesignationNo = salHisRefResultParamWork.ModelDesignationNo;
                    row.CategoryNo = salHisRefResultParamWork.CategoryNo;
                    row.MakerFullName = salHisRefResultParamWork.MakerFullName;
                    row.FullModel = salHisRefResultParamWork.FullModel;
                    row.ModelFullName = salHisRefResultParamWork.ModelFullName;
                    row.SearchSlipDate = salHisRefResultParamWork.SearchSlipDate;
                    // 2008.11.10 add start [7541]
                    if (salHisRefResultParamWork.ShipmentDay != DateTime.MinValue)
                    {
                        row.ShipmentDay = salHisRefResultParamWork.ShipmentDay;
                    }
                    if (salHisRefResultParamWork.AddUpADate != DateTime.MinValue)
                    {
                        row.AddUpADate = salHisRefResultParamWork.AddUpADate;
                    }
                    // 2008.11.10 add end [7541]
                    row.InputAgenCd = salHisRefResultParamWork.InputAgenCd;
                    row.InputAgenNm = salHisRefResultParamWork.InputAgenNm;
                    row.SalesInputCode = salHisRefResultParamWork.SalesInputCode;
                    row.SalesInputName = salHisRefResultParamWork.SalesInputName;
                    row.FrontEmployeeCd = salHisRefResultParamWork.FrontEmployeeCd;
                    row.FrontEmployeeNm = salHisRefResultParamWork.FrontEmployeeNm;
                    row.SalesEmployeeCd = salHisRefResultParamWork.SalesEmployeeCd;
                    row.SalesEmployeeNm = salHisRefResultParamWork.SalesEmployeeNm;
                    row.ClaimCode = salHisRefResultParamWork.ClaimCode;
                    row.ClaimSnm = salHisRefResultParamWork.ClaimSnm;
                    row.CustomerCode = salHisRefResultParamWork.CustomerCode;
                    row.CustomerSnm = salHisRefResultParamWork.CustomerSnm;
                    row.AddresseeCode = salHisRefResultParamWork.AddresseeCode;
                    row.AddresseeName = salHisRefResultParamWork.AddresseeName;
                    row.AddresseeName2 = salHisRefResultParamWork.AddresseeName2;
                    row.DebitNoteDiv = salHisRefResultParamWork.DebitNoteDiv;
                    row.AcptAnOdrRemainCnt = salHisRefResultParamWork.AcptAnOdrRemainCnt;
                    //---ADD 2011/11/11 ------------------------------------------------------------->>>>>
                    //�A�g���
                    if (salHisRefResultParamWork.AcceptOrOrderKind == 0)
                    {
                        row.CooprtKind = "PCCforNS";
                    }
                    else if (salHisRefResultParamWork.AcceptOrOrderKind == 1)
                    {
                        row.CooprtKind = "BL�߰µ��ް";
                    }
                    else
                    {
                        row.CooprtKind = "�ʏ�";
                    }

                    //������
                    if (salHisRefResultParamWork.AutoAnswerDivSCM == 0)
                    {
                        row.AutoAnswer = "�ʏ�";
                        row.CooprtKind = "�ʏ�"; // ADD 2011/11/16
                    }
                    else if (salHisRefResultParamWork.AutoAnswerDivSCM == 1)
                    {
                        row.AutoAnswer = "�蓮��";
                    }
                    else if (salHisRefResultParamWork.AutoAnswerDivSCM == 2)
                    {
                        row.AutoAnswer = "������";
                    }
                    //---ADD 2011/11/11 -------------------------------------------------------------<<<<<
                  
                    # endregion

                    # region [row(�蓮)]
                    row.No = i + 1;
                    row.PrintFlag = false;
                    row.AcptAnOdrStatusString = acptAnOdrStatusString;
                    row.SalesDateString = salesDateString;
                    row.SalesCost = salesCost;
                    row.ShipmentLeftCnt = shipmentLeftCnt;
                    row.SalesMoneyTaxExc = salesMoneyTaxExc;
                    row.SalesPriceConsTax = salesPriceConsTax;
                    row.SalesMoneyTaxInc = salesMoneyTaxInc;
                    row.ModelCategoryNo = modelCategoryNo;
                    row.SalesGoodsCdString = salesGoodsCdString;
                    row.SalesSlipCdDtlString = salesSlipCdDtlString;
                    row.MemoExistName = memoExistName;
                    row.DebitNoteDivString = debitNoteDivStr;
                    row.NoForDisp = 0;
                    # endregion

                    _dataSet.SalesDetail.AddSalesDetailRow( row );

                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

				}

                // �����f�[�^�̃L���b�V��
                this.CacheStockSlipTable();

                // ���������̃L���b�V��
                this.CacheParaStockSlip(salHisRefExtraParamWork);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/24 ADD
                // �\���p���Z�b�g
                int noForDisp = 1;
                foreach (DataRowView rowView in this.SalesDetailView)
                {
                    rowView[_dataSet.SalesDetail.NoForDispColumn.ColumnName] = noForDisp++;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/24 ADD

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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

        /// <summary>
        /// �f�[�^�Z�b�g�N���A����
        /// </summary>
        public void ClearStockSlipDataTable()
        {
            this._dataSet.SalesDetail.Rows.Clear();

            // �L���b�V���f�[�^�̎�蒼��(�N���A��Ԃɂ���)
            this.CacheStockSlipTable();
            this.CacheParaStockSlip(null);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, true, 0 );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
        }
        
        /// <summary>
        /// �`�[��� �ǂݍ��ݏ���
        /// </summary>
        /// <param name="stockSlipWorks">�d���f�[�^ �I�u�W�F�N�g�z��</param>
        /// <param name="salHisRefExtraParamWork">�d���`�[�����p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[����ǂݍ��݂܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �ђJ</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public int Search(out List<SalHisRefResultParamWork> salHisRefResultParamWorkList, SalHisRefExtraParamWork salHisRefExtraParamWork)
        {
            try
            {
                int status;
                salHisRefResultParamWorkList = new List<SalHisRefResultParamWork>();

                // �I�����C���̏ꍇ�����[�g�擾
                // -- DEL 2010/05/25 ------------------------>>>
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // -- DEL 2010/05/25 ------------------------<<<
                //CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                //paraList.Add(salHisRefExtraParamWork);

                //CustomSerializeArrayList retList = new CustomSerializeArrayList();
                ArrayList retList = new ArrayList();

                //object paraObj = (object)paraList;
                object paraObj = (object)salHisRefExtraParamWork;
                object retObj = (object)retList;

                //�`�[���擾
                status = this._iSalHisRefDB.Search(out retObj, paraObj, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    int setCount = 0;
                    //retList = (CustomSerializeArrayList)retObj;
                    retList = (ArrayList)retObj;
                    for (int i = 0; i < retList.Count; i++)
                    {
                        salHisRefResultParamWorkList.Add((SalHisRefResultParamWork)retList[i]);
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
                // -- DEL 2010/05/25 --------------------------->>>
                //}
                //else	// �I�t���C���̏ꍇ
                //{
                //    //status = ReadStaticMemory(out lgoodsganre, enterpriseCode, largeGoodsGanreCode);
                //    status = -1;
                //}
                // -- DEL 2010/05/25 ---------------------------<<<

                return status;
            }
            catch (Exception)
            {
                salHisRefResultParamWorkList = null;
                //�I�t���C������null���Z�b�g
                this._iSalHisRefDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �`�[�f�[�^�e�[�u���L���b�V���擾����
        /// </summary>
        /// <returns>�`�[�f�[�^�e�[�u���L���b�V��</returns>
        public StockDataSet.SalesDetailDataTable GetStockSlipTableCache()
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
        public SalHisRefExtraParamWork GetParaStockSlipCache()
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
			DataRow _row = this._dataSet.SalesDetail.Rows.Find(_uniqueID);

			// ��v����s�����݂���I
			if (_row != null)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                //bool printFlag = (bool)_row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName];

                //_row.BeginEdit();
                //_row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName] = !printFlag;
                //_row.EndEdit();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                bool printFlag = (bool)_row[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName];
                SelectedPrintRow( ref _row, !printFlag );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
			}
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
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
                bool prevPrintFlag = (bool)row[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName];

                // �ύX��
                checkResult = true;
                // �ύX
                row.BeginEdit();
                row[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName] = selected;
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

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
        public bool SelectedPrintRow( int _uniqueID, bool selected )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            bool result = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

            // ------------------------------------------------------------//
            // Find ���\�b�h���g���A���AView�̃\�[�g����ύX�������Ȃ��ׁA //
            // DataTable�ɍX�V��������B                                   //
            // ------------------------------------------------------------//
            DataRow _row = this._dataSet.SalesDetail.Rows.Find( _uniqueID );

            // ��v����s�����݂���I
            if ( _row != null )
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
			DataView StockSlipView = new DataView(this._dataSet.SalesDetail);
			StockSlipView.RowFilter = String.Format("{0} = {1}", this._dataSet.SalesDetail.PrintFlagColumn.ColumnName, true);
			return (StockSlipView.Count);
		}

		/// <summary>
        /// �I���s�e�[�u���f�[�^�擾����
        /// </summary>
        /// <param name="getRowNo">�O���b�h�I��RowNo</param>
        /// <returns>�d���f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u������A�w��s�̎d���f�[�^�N���X��Ԃ��܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public List<SalHisRefResultParamWork> GetSelectedRowData(int getRowNo)
        {
			// �ߒl
			List<SalHisRefResultParamWork> salHisRefResultParamWorkList = new List<SalHisRefResultParamWork>();

			// ���i���e�[�u��
			DataView StockSlipView = new DataView(this._dataSet.SalesDetail);
			StockSlipView.RowFilter = String.Format("{0} = {1}", this._dataSet.SalesDetail.PrintFlagColumn.ColumnName,true);

			for (int ix = 0; ix < StockSlipView.Count; ix++)
			{
				SalHisRefResultParamWork salHisRefResultParamWork = new SalHisRefResultParamWork();

				salHisRefResultParamWork.EnterpriseCode = (string)StockSlipView[ix][this._dataSet.SalesDetail.EnterpriseCodeColumn.ColumnName];
				salHisRefResultParamWork.LogicalDeleteCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.LogicalDeleteCodeColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/24 DEL
                //salHisRefResultParamWork.AcceptAnOrderNo = (int)StockSlipView[ix][this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/24 ADD
                salHisRefResultParamWork.AcceptAnOrderNo = (Int64)StockSlipView[ix][this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/24 ADD
				salHisRefResultParamWork.AcptAnOdrStatus = (int)StockSlipView[ix][this._dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName];
				salHisRefResultParamWork.SalesSlipNum = (string)StockSlipView[ix][this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName];
				salHisRefResultParamWork.SalesRowNo = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.SalesRowDerivNo = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesRowDerivNoColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
				salHisRefResultParamWork.SectionCode = (string)StockSlipView[ix][this._dataSet.SalesDetail.SectionCodeColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.SectionGuideNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.SectionGuideNmColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
				salHisRefResultParamWork.SubSectionCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.SubSectionCodeColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.SubSectionName = (string)StockSlipView[ix][this._dataSet.SalesDetail.SubSectionNameColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
				//salHisRefResultParamWork.MinSectionCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.MinSectionCodeColumn.ColumnName];
                if (!String.IsNullOrEmpty(StockSlipView[ix][this._dataSet.SalesDetail.SalesDateColumn.ColumnName].ToString().Trim()))
                {
                    salHisRefResultParamWork.SalesDate = (System.DateTime)StockSlipView[ix][this._dataSet.SalesDetail.SalesDateColumn.ColumnName];
                }
				salHisRefResultParamWork.CommonSeqNo = (long)StockSlipView[ix][this._dataSet.SalesDetail.CommonSeqNoColumn.ColumnName];
				salHisRefResultParamWork.SalesSlipDtlNum = (long)StockSlipView[ix][this._dataSet.SalesDetail.SalesSlipDtlNumColumn.ColumnName];
				salHisRefResultParamWork.AcptAnOdrStatusSrc = (int)StockSlipView[ix][this._dataSet.SalesDetail.AcptAnOdrStatusSrcColumn.ColumnName];
				salHisRefResultParamWork.SalesSlipDtlNumSrc = (long)StockSlipView[ix][this._dataSet.SalesDetail.SalesSlipDtlNumSrcColumn.ColumnName];
				salHisRefResultParamWork.SupplierFormalSync = (int)StockSlipView[ix][this._dataSet.SalesDetail.SupplierFormalSyncColumn.ColumnName];
				salHisRefResultParamWork.StockSlipDtlNumSync = (long)StockSlipView[ix][this._dataSet.SalesDetail.StockSlipDtlNumSyncColumn.ColumnName];
				salHisRefResultParamWork.SalesSlipCdDtl = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesSlipCdDtlColumn.ColumnName];
				//salHisRefResultParamWork.ServiceSlipCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.ServiceSlipCdColumn.ColumnName];
				//salHisRefResultParamWork.SalesDepositsDiv = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesDepositsDivColumn.ColumnName];
				//salHisRefResultParamWork.StockMngExistCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.StockMngExistCdColumn.ColumnName];
				salHisRefResultParamWork.GoodsKindCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.GoodsKindCodeColumn.ColumnName];
				salHisRefResultParamWork.GoodsMakerCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName];
				salHisRefResultParamWork.MakerName = (string)StockSlipView[ix][this._dataSet.SalesDetail.MakerNameColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.MakerKanaName = (string)StockSlipView[ix][this._dataSet.SalesDetail.MakerKanaNameColumn.ColumnName];
                salHisRefResultParamWork.CmpltMakerKanaName = (string)StockSlipView[ix][this._dataSet.SalesDetail.CmpltMakerKanaNameColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
				salHisRefResultParamWork.GoodsNo = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsNoColumn.ColumnName];
				salHisRefResultParamWork.GoodsName = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsNameColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.GoodsNameKana = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsNameKanaColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                //salHisRefResultParamWork.GoodsSetDivCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.GoodsSetDivCdColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA MODIFY START
                salHisRefResultParamWork.GoodsLGroupName = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName];
                salHisRefResultParamWork.GoodsLGroupName = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName];
                salHisRefResultParamWork.GoodsMGroup = (int)StockSlipView[ix][this._dataSet.SalesDetail.GoodsMGroupColumn.ColumnName];
                salHisRefResultParamWork.GoodsMGroupName = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsMGroupNameColumn.ColumnName];
                salHisRefResultParamWork.BLGroupCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName];
                salHisRefResultParamWork.BLGroupName = (string)StockSlipView[ix][this._dataSet.SalesDetail.BLGroupNameColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA MODIFY END
                salHisRefResultParamWork.BLGoodsCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName];
				salHisRefResultParamWork.BLGoodsFullName = (string)StockSlipView[ix][this._dataSet.SalesDetail.BLGoodsFullNameColumn.ColumnName];
				salHisRefResultParamWork.EnterpriseGanreCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.EnterpriseGanreCodeColumn.ColumnName];
				salHisRefResultParamWork.EnterpriseGanreName = (string)StockSlipView[ix][this._dataSet.SalesDetail.EnterpriseGanreNameColumn.ColumnName];
				salHisRefResultParamWork.WarehouseCode = (string)StockSlipView[ix][this._dataSet.SalesDetail.WarehouseCodeColumn.ColumnName];
				salHisRefResultParamWork.WarehouseName = (string)StockSlipView[ix][this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName];
				salHisRefResultParamWork.WarehouseShelfNo = (string)StockSlipView[ix][this._dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName];
				salHisRefResultParamWork.SalesOrderDivCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.OpenPriceDiv = (int)StockSlipView[ix][this._dataSet.SalesDetail.OpenPriceDivColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END                
				//salHisRefResultParamWork.UnitCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.UnitCodeColumn.ColumnName];
				//salHisRefResultParamWork.UnitName = (string)StockSlipView[ix][this._dataSet.SalesDetail.UnitNameColumn.ColumnName];
				salHisRefResultParamWork.GoodsRateRank = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsRateRankColumn.ColumnName];
				salHisRefResultParamWork.CustRateGrpCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.CustRateGrpCodeColumn.ColumnName];
				//salHisRefResultParamWork.SuppRateGrpCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.SuppRateGrpCodeColumn.ColumnName];
				salHisRefResultParamWork.ListPriceRate = (double)StockSlipView[ix][this._dataSet.SalesDetail.ListPriceRateColumn.ColumnName];
				salHisRefResultParamWork.RateDivLPrice = (string)StockSlipView[ix][this._dataSet.SalesDetail.RateDivLPriceColumn.ColumnName];
				salHisRefResultParamWork.UnPrcCalcCdLPrice = (int)StockSlipView[ix][this._dataSet.SalesDetail.UnPrcCalcCdLPriceColumn.ColumnName];
				salHisRefResultParamWork.PriceCdLPrice = (int)StockSlipView[ix][this._dataSet.SalesDetail.PriceCdLPriceColumn.ColumnName];
				salHisRefResultParamWork.StdUnPrcLPrice = (double)StockSlipView[ix][this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName];
				salHisRefResultParamWork.FracProcUnitLPrice = (double)StockSlipView[ix][this._dataSet.SalesDetail.FracProcUnitLPriceColumn.ColumnName];
				salHisRefResultParamWork.FracProcLPrice = (int)StockSlipView[ix][this._dataSet.SalesDetail.FracProcLPriceColumn.ColumnName];
				salHisRefResultParamWork.ListPriceTaxIncFl = (double)StockSlipView[ix][this._dataSet.SalesDetail.ListPriceTaxIncFlColumn.ColumnName];
				salHisRefResultParamWork.ListPriceTaxExcFl = (double)StockSlipView[ix][this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName];
				salHisRefResultParamWork.ListPriceChngCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.ListPriceChngCdColumn.ColumnName];
				salHisRefResultParamWork.SalesRate = (double)StockSlipView[ix][this._dataSet.SalesDetail.SalesRateColumn.ColumnName];
				salHisRefResultParamWork.RateDivSalUnPrc = (string)StockSlipView[ix][this._dataSet.SalesDetail.RateDivSalUnPrcColumn.ColumnName];
				salHisRefResultParamWork.UnPrcCalcCdSalUnPrc = (int)StockSlipView[ix][this._dataSet.SalesDetail.UnPrcCalcCdSalUnPrcColumn.ColumnName];
				salHisRefResultParamWork.PriceCdSalUnPrc = (int)StockSlipView[ix][this._dataSet.SalesDetail.PriceCdSalUnPrcColumn.ColumnName];
				salHisRefResultParamWork.StdUnPrcSalUnPrc = (double)StockSlipView[ix][this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName];
				salHisRefResultParamWork.FracProcUnitSalUnPrc = (double)StockSlipView[ix][this._dataSet.SalesDetail.FracProcUnitSalUnPrcColumn.ColumnName];
				salHisRefResultParamWork.FracProcSalUnPrc = (int)StockSlipView[ix][this._dataSet.SalesDetail.FracProcSalUnPrcColumn.ColumnName];
				salHisRefResultParamWork.SalesUnPrcTaxIncFl = (double)StockSlipView[ix][this._dataSet.SalesDetail.SalesUnPrcTaxIncFlColumn.ColumnName];
				salHisRefResultParamWork.SalesUnPrcTaxExcFl = (double)StockSlipView[ix][this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName];
				salHisRefResultParamWork.SalesUnPrcChngCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesUnPrcChngCdColumn.ColumnName];
				salHisRefResultParamWork.CostRate = (double)StockSlipView[ix][this._dataSet.SalesDetail.CostRateColumn.ColumnName];
				salHisRefResultParamWork.RateDivUnCst = (string)StockSlipView[ix][this._dataSet.SalesDetail.RateDivUnCstColumn.ColumnName];
				salHisRefResultParamWork.UnPrcCalcCdUnCst = (int)StockSlipView[ix][this._dataSet.SalesDetail.UnPrcCalcCdUnCstColumn.ColumnName];
				salHisRefResultParamWork.PriceCdUnCst = (int)StockSlipView[ix][this._dataSet.SalesDetail.PriceCdUnCstColumn.ColumnName];
				salHisRefResultParamWork.StdUnPrcUnCst = (double)StockSlipView[ix][this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName];
				salHisRefResultParamWork.FracProcUnitUnCst = (double)StockSlipView[ix][this._dataSet.SalesDetail.FracProcUnitUnCstColumn.ColumnName];
				salHisRefResultParamWork.FracProcUnCst = (int)StockSlipView[ix][this._dataSet.SalesDetail.FracProcUnCstColumn.ColumnName];
				salHisRefResultParamWork.SalesUnitCost = (double)StockSlipView[ix][this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName];
				salHisRefResultParamWork.SalesUnitCostChngDiv = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesUnitCostChngDivColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.RateBLGoodsCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.RateBLGoodsCodeColumn.ColumnName];
                salHisRefResultParamWork.RateBLGoodsName = (string)StockSlipView[ix][this._dataSet.SalesDetail.RateBLGoodsNameColumn.ColumnName];
                salHisRefResultParamWork.PrtBLGoodsCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.PrtBLGoodsCodeColumn.ColumnName];
                salHisRefResultParamWork.PrtBLGoodsName = (string)StockSlipView[ix][this._dataSet.SalesDetail.PrtBLGoodsNameColumn.ColumnName];
                salHisRefResultParamWork.SalesCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesCodeColumn.ColumnName];
                salHisRefResultParamWork.SalesCdNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.SalesCdNmColumn.ColumnName];
                salHisRefResultParamWork.WorkManHour = (double)StockSlipView[ix][this._dataSet.SalesDetail.WorkManHourColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
				//salHisRefResultParamWork.BargainCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.BargainCdColumn.ColumnName];
				//salHisRefResultParamWork.BargainNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.BargainNmColumn.ColumnName];
				salHisRefResultParamWork.ShipmentCnt = (double)StockSlipView[ix][this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName];
				salHisRefResultParamWork.SalesMoneyTaxInc = (long)StockSlipView[ix][this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName];
				salHisRefResultParamWork.SalesMoneyTaxExc = (long)StockSlipView[ix][this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName];
				salHisRefResultParamWork.Cost = (long)StockSlipView[ix][this._dataSet.SalesDetail.CostColumn.ColumnName];
				salHisRefResultParamWork.GrsProfitChkDiv = (int)StockSlipView[ix][this._dataSet.SalesDetail.GrsProfitChkDivColumn.ColumnName];
				salHisRefResultParamWork.SalesGoodsCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesGoodsCdColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                //salHisRefResultParamWork.SalesPriceConsTax = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName];
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                salHisRefResultParamWork.SalesPriceConsTax = (Int64)StockSlipView[ix][this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
                //salHisRefResultParamWork.TaxAdjust = (long)StockSlipView[ix][this._dataSet.SalesDetail.TaxAdjustColumn.ColumnName];
				//salHisRefResultParamWork.BalanceAdjust = (long)StockSlipView[ix][this._dataSet.SalesDetail.BalanceAdjustColumn.ColumnName];
				salHisRefResultParamWork.TaxationDivCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.TaxationDivCdColumn.ColumnName];
				salHisRefResultParamWork.PartySlipNumDtl = (string)StockSlipView[ix][this._dataSet.SalesDetail.PartySlipNumDtlColumn.ColumnName];
				salHisRefResultParamWork.DtlNote = (string)StockSlipView[ix][this._dataSet.SalesDetail.DtlNoteColumn.ColumnName];
				salHisRefResultParamWork.SupplierCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.SupplierCdColumn.ColumnName];
				salHisRefResultParamWork.SupplierSnm = (string)StockSlipView[ix][this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName];
				//salHisRefResultParamWork.ResultsAddUpSecCd = (string)StockSlipView[ix][this._dataSet.SalesDetail.ResultsAddUpSecCdColumn.ColumnName];
				salHisRefResultParamWork.OrderNumber = (string)StockSlipView[ix][this._dataSet.SalesDetail.OrderNumberColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.WayToOrder = (int)StockSlipView[ix][this._dataSet.SalesDetail.WayToOrderColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END                
				salHisRefResultParamWork.SlipMemo1 = (string)StockSlipView[ix][this._dataSet.SalesDetail.SlipMemo1Column.ColumnName];
				salHisRefResultParamWork.SlipMemo2 = (string)StockSlipView[ix][this._dataSet.SalesDetail.SlipMemo2Column.ColumnName];
				salHisRefResultParamWork.SlipMemo3 = (string)StockSlipView[ix][this._dataSet.SalesDetail.SlipMemo3Column.ColumnName];
				//salHisRefResultParamWork.SlipMemo4 = (string)StockSlipView[ix][this._dataSet.SalesDetail.SlipMemo4Column.ColumnName];
				//salHisRefResultParamWork.SlipMemo5 = (string)StockSlipView[ix][this._dataSet.SalesDetail.SlipMemo5Column.ColumnName];
				//salHisRefResultParamWork.SlipMemo6 = (string)StockSlipView[ix][this._dataSet.SalesDetail.SlipMemo6Column.ColumnName];
				salHisRefResultParamWork.InsideMemo1 = (string)StockSlipView[ix][this._dataSet.SalesDetail.InsideMemo1Column.ColumnName];
				salHisRefResultParamWork.InsideMemo2 = (string)StockSlipView[ix][this._dataSet.SalesDetail.InsideMemo2Column.ColumnName];
				salHisRefResultParamWork.InsideMemo3 = (string)StockSlipView[ix][this._dataSet.SalesDetail.InsideMemo3Column.ColumnName];
				//salHisRefResultParamWork.InsideMemo4 = (string)StockSlipView[ix][this._dataSet.SalesDetail.InsideMemo4Column.ColumnName];
				//salHisRefResultParamWork.InsideMemo5 = (string)StockSlipView[ix][this._dataSet.SalesDetail.InsideMemo5Column.ColumnName];
				//salHisRefResultParamWork.InsideMemo6 = (string)StockSlipView[ix][this._dataSet.SalesDetail.InsideMemo6Column.ColumnName];
				salHisRefResultParamWork.BfListPrice = (double)StockSlipView[ix][this._dataSet.SalesDetail.BfListPriceColumn.ColumnName];
				salHisRefResultParamWork.BfSalesUnitPrice = (double)StockSlipView[ix][this._dataSet.SalesDetail.BfSalesUnitPriceColumn.ColumnName];
				salHisRefResultParamWork.BfUnitCost = (double)StockSlipView[ix][this._dataSet.SalesDetail.BfUnitCostColumn.ColumnName];
				//salHisRefResultParamWork.PrtGoodsNo = (string)StockSlipView[ix][this._dataSet.SalesDetail.PrtGoodsNoColumn.ColumnName];
				//salHisRefResultParamWork.PrtGoodsName = (string)StockSlipView[ix][this._dataSet.SalesDetail.PrtGoodsNameColumn.ColumnName];
				//salHisRefResultParamWork.PrtGoodsMakerCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.PrtGoodsMakerCdColumn.ColumnName];
				//salHisRefResultParamWork.PrtGoodsMakerNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.PrtGoodsMakerNmColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.CmpltSalesRowNo = (int)StockSlipView[ix][this._dataSet.SalesDetail.CmpltSalesRowNoColumn.ColumnName];
                salHisRefResultParamWork.CmpltGoodsMakerCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.CmpltGoodsMakerCdColumn.ColumnName];
                salHisRefResultParamWork.CmpltMakerName = (string)StockSlipView[ix][this._dataSet.SalesDetail.CmpltMakerNameColumn.ColumnName];
                salHisRefResultParamWork.CmpltGoodsName = (string)StockSlipView[ix][this._dataSet.SalesDetail.CmpltGoodsNameColumn.ColumnName];
                salHisRefResultParamWork.CmpltShipmentCnt = (double)StockSlipView[ix][this._dataSet.SalesDetail.CmpltShipmentCntColumn.ColumnName];
                salHisRefResultParamWork.CmpltSalesUnPrcFl = (double)StockSlipView[ix][this._dataSet.SalesDetail.CmpltSalesUnPrcFlColumn.ColumnName];
                salHisRefResultParamWork.CmpltSalesMoney = (long)StockSlipView[ix][this._dataSet.SalesDetail.CmpltSalesMoneyColumn.ColumnName];
                salHisRefResultParamWork.CmpltSalesUnitCost = (double)StockSlipView[ix][this._dataSet.SalesDetail.CmpltSalesUnitCostColumn.ColumnName];
                salHisRefResultParamWork.CmpltCost = (long)StockSlipView[ix][this._dataSet.SalesDetail.CmpltCostColumn.ColumnName];
                salHisRefResultParamWork.CmpltPartySalSlNum = (string)StockSlipView[ix][this._dataSet.SalesDetail.CmpltPartySalSlNumColumn.ColumnName];
                salHisRefResultParamWork.CmpltNote = (string)StockSlipView[ix][this._dataSet.SalesDetail.CmpltNoteColumn.ColumnName];
                salHisRefResultParamWork.CarMngCode = (string)StockSlipView[ix][this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName];
                salHisRefResultParamWork.ModelDesignationNo = (int)StockSlipView[ix][this._dataSet.SalesDetail.ModelDesignationNoColumn.ColumnName];
                salHisRefResultParamWork.CategoryNo = (int)StockSlipView[ix][this._dataSet.SalesDetail.CategoryNoColumn.ColumnName];
                salHisRefResultParamWork.MakerFullName = (string)StockSlipView[ix][this._dataSet.SalesDetail.MakerFullNameColumn.ColumnName];
                salHisRefResultParamWork.FullModel = (string)StockSlipView[ix][this._dataSet.SalesDetail.FullModelColumn.ColumnName];
                salHisRefResultParamWork.ModelFullName = (string)StockSlipView[ix][this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName];
                // 2008.11.14 modify start
                if (!String.IsNullOrEmpty(StockSlipView[ix][this._dataSet.SalesDetail.SearchSlipDateColumn.ColumnName].ToString().Trim()))
                {
                    salHisRefResultParamWork.SearchSlipDate = (System.DateTime)StockSlipView[ix][this._dataSet.SalesDetail.SearchSlipDateColumn.ColumnName];
                }
                if (!String.IsNullOrEmpty(StockSlipView[ix][this._dataSet.SalesDetail.ShipmentDayColumn.ColumnName].ToString().Trim()))
                {
                salHisRefResultParamWork.ShipmentDay = (System.DateTime)StockSlipView[ix][this._dataSet.SalesDetail.ShipmentDayColumn.ColumnName];
                }
                if (!String.IsNullOrEmpty(StockSlipView[ix][this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].ToString().Trim()))
                {
                    salHisRefResultParamWork.AddUpADate = (System.DateTime)StockSlipView[ix][this._dataSet.SalesDetail.AddUpADateColumn.ColumnName];
                }
                // 2008.11.14 modify end
                salHisRefResultParamWork.InputAgenCd = (string)StockSlipView[ix][this._dataSet.SalesDetail.InputAgenCdColumn.ColumnName];
                salHisRefResultParamWork.InputAgenNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.InputAgenNmColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                salHisRefResultParamWork.SalesInputCode = (string)StockSlipView[ix][this._dataSet.SalesDetail.SalesInputCodeColumn.ColumnName];
                salHisRefResultParamWork.SalesInputName = (string)StockSlipView[ix][this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName];
                salHisRefResultParamWork.FrontEmployeeCd = (string)StockSlipView[ix][this._dataSet.SalesDetail.FrontEmployeeCdColumn.ColumnName];
                salHisRefResultParamWork.FrontEmployeeNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName];
                salHisRefResultParamWork.SalesEmployeeCd = (string)StockSlipView[ix][this._dataSet.SalesDetail.SalesEmployeeCdColumn.ColumnName];
                salHisRefResultParamWork.SalesEmployeeNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.ClaimCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.ClaimCodeColumn.ColumnName];
                salHisRefResultParamWork.ClaimSnm = (string)StockSlipView[ix][this._dataSet.SalesDetail.ClaimSnmColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                salHisRefResultParamWork.CustomerCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName];
				//salHisRefResultParamWork.CustomerName = (string)StockSlipView[ix][this._dataSet.SalesDetail.CustomerNameColumn.ColumnName];
				//salHisRefResultParamWork.CustomerName2 = (string)StockSlipView[ix][this._dataSet.SalesDetail.CustomerName2Column.ColumnName];
				salHisRefResultParamWork.CustomerSnm = (string)StockSlipView[ix][this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName];
				salHisRefResultParamWork.AddresseeCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName];
				salHisRefResultParamWork.AddresseeName = (string)StockSlipView[ix][this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName];
				salHisRefResultParamWork.AddresseeName2 = (string)StockSlipView[ix][this._dataSet.SalesDetail.AddresseeName2Column.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA ADD START
                salHisRefResultParamWork.AcptAnOdrRemainCnt = (double)StockSlipView[ix][this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName];
                salHisRefResultParamWork.DebitNoteDiv = (int)StockSlipView[ix][this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA ADD END

				salHisRefResultParamWorkList.Add(salHisRefResultParamWork);
			}

			return salHisRefResultParamWorkList;
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

		/// <summary>
        /// ���i���̎擾����
        /// </summary>
        /// <param name="goodsCode">���i�R�[�h</param>
        /// <returns>true:���݂���Afalse:���݂��Ȃ�</returns>
		public bool CheckGoodsExist(string goodsCode, out string goodsName)
        {
            List<GoodsUnitData> goodsUnitDataList;
            GoodsAcs goodsAcs = new GoodsAcs();
			goodsName = "";

            // ���i�R�[�h�݂̂̎w���
            int status = goodsAcs.Read(this._enterpriseCode, goodsCode,out goodsUnitDataList);

            if( (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList.Count != 0) )
            {
				goodsName = goodsUnitDataList[0].GoodsName;
				//goodsName = goodsUnitDataList[0].GoodsShortName;
				return true;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
		/// ���i���̎擾����
		/// </summary>
		/// <param name="goodsCode">���i�R�[�h</param>
		/// <returns>true:���݂���Afalse:���݂��Ȃ�</returns>
		public int CheckGoodsExist(IWin32Window owner, ref string goodsCode, ref string goodsName, ref int goodsMakerCd, ref string makerName)
		{
			int status;
			string message;
			string searchCode;
			int searchType;

			GoodsCndtn goodsCndtn = new GoodsCndtn();
			List<GoodsUnitData> goodsUnitDataList;
			GoodsAcs goodsAcs = new GoodsAcs();

			searchType = GetSearchType(goodsCode, out searchCode);

			MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

			goodsCndtn.GoodsMakerCd = goodsMakerCd;
			goodsCndtn.GoodsNoSrchTyp = searchType;
			//goodsCndtn.GoodsNo = goodsCode;
			goodsCndtn.GoodsNo = searchCode;
			goodsCndtn.EnterpriseCode = this._enterpriseCode;

			//status = goodsSelectGuide.ReadGoods(owner, false, goodsCndtn, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
			status = goodsSelectGuide.ReadGoods(owner, false, goodsCndtn, out goodsUnitDataList, out message);


			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
			{
				goodsCode = goodsUnitDataList[0].GoodsNo;
				goodsName = goodsUnitDataList[0].GoodsName;
				//goodsName = goodsUnitDataList[0].GoodsShortName;

				makerName = goodsUnitDataList[0].MakerName;
				goodsMakerCd = goodsUnitDataList[0].GoodsMakerCd;
			}
			return (status);
		}

		// ===================================================================================== //
		// ���i�֘A����
		// ===================================================================================== //
		# region Goods Control Methods

		/// <summary>
		/// �����^�C�v�擾����
		/// </summary>
		/// <param name="inputCode">���͂��ꂽ�R�[�h</param>
		/// <param name="searchCode">�����p�R�[�h�i*�������j</param>
		/// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
		public static int GetSearchType(string inputCode, out string searchCode)
		{
			searchCode = inputCode;
			if (String.IsNullOrEmpty(inputCode)) return 0;

			if (inputCode.Contains("*"))
			{
				searchCode = inputCode.Replace("*", "");
				string firstString = inputCode.Substring(0, 1);
				string lastString = inputCode.Substring(inputCode.Length - 1, 1);

				if ((firstString == "*") && (lastString == "*"))
				{
					return 3;
				}
				else if (firstString == "*")
				{
					return 2;
				}
				else if (lastString == "*")
				{
					return 1;
				}
				else
				{
					return 3;
				}
			}
			else
			{
				// *�����݂��Ȃ����ߊ��S��v����
				return 0;
			}
		}

		# endregion

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
		# endregion

    }
}
