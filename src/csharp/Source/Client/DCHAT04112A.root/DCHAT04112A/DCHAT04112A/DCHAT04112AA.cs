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
    /// �����c�Ɖ� �e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
	/// <br>Note		: �����f�[�^�̌������s���܂��B</br>
	/// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2007.10.15</br>
    /// </remarks>
    public class DCHAT04112AA
    {
        # region ��Private Member
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IOrderListWorkDB _iOrderListWorkDB = null;
        /// <summary>���_�I�v�V�����t���O</summary>
        private bool _optSection;
		// ���_�A�N�Z�X�N���X
        private static SecInfoAcs _secInfoAcs;													
		private OrderRemainDataSet _dataSet;
		private static OrderRemainDataSet.OrderListResultDataTable _orderListResultDataTable;
        private static OrderListCndtnWork _orderListCndtnCache;
        private static SortedList _nameList;
        //private static DCHAT04112AA _searchSlipAcs;

        private string _enterpriseCode;             // ��ƃR�[�h

        private const string MESSAGE_NoResult = "���������Ɉ�v����`�[�͑��݂��܂���B";
        private const string MESSAGE_ErrResult = "�`�[���̎擾�Ɏ��s���܂����B";
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";
		private const string ct_DateFormat = "yyyy/MM/dd";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
        private int _maxSelectCount;
        private bool _rowChangeStatus;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

        # endregion

		#region ��event
		public event GetNameListEventHandler GetNameList;
        public delegate SortedList GetNameListEventHandler();

        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
		public delegate void SettingStatusBarMessageEventHandler( object sender, string message );

		public event EventHandler SelectedRowChanged;
		#endregion

		# region ��Constracter
		/// <summary>
		/// �����c�Ɖ� �e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
		/// <br>Note       : �����c�Ɖ�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public DCHAT04112AA()
        {
            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // ���_OP�̔���
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
            this._dataSet = new OrderRemainDataSet();

            // ���O�C�����i�ŒʐM��Ԃ��m�F
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // �����[�g�I�u�W�F�N�g�擾
					this._iOrderListWorkDB = (IOrderListWorkDB)MediationOrderListWorkDB.GetOrderListWorkDB();
                }
                catch (Exception)
                {
                    //�I�t���C������null���Z�b�g
                    this._iOrderListWorkDB = null;
                }
            }
            else
            {
                // �I�t���C�����̃f�[�^�ǂݍ���
                //this.SearchOfflineData();
                MessageBox.Show("�I�t���C����Ԃ̂��ߌ��������s�ł��܂���B");
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            this.RowChangeStatus = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
        }
        # endregion

        /// <summary>
		/// �����c�Ɖ�f�[�^�Z�b�g�擾����
        /// </summary>
		/// <returns>�����c�Ɖ�f�[�^�Z�b�g</returns>
        public OrderRemainDataSet DataSet
        {
            get { return this._dataSet; }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
        /// <summary>
        /// �I���\�ő喾�׍s��
        /// </summary>
        public int MaxSelectCount
        {
            get { return _maxSelectCount; }
            set { _maxSelectCount = value; }
        }
        /// <summary>
        /// �s�I����ԕύX�X�e�[�^�X
        /// </summary>
        public bool RowChangeStatus
        {
            get { return _rowChangeStatus; }
            set { _rowChangeStatus = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

        # region ��public int GetOnlineMode()
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iOrderListWorkDB == null)
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
        private void CacheOrderRemainTable()
        {
            if (_orderListResultDataTable == null)
            {
                _orderListResultDataTable = new OrderRemainDataSet.OrderListResultDataTable();
            }

            this._dataSet.OrderListResult.AcceptChanges();
            _orderListResultDataTable = (OrderRemainDataSet.OrderListResultDataTable)this._dataSet.OrderListResult.Copy();
        }

        /// <summary>
        /// ���������N���X(�ĕ\���p) �L���b�V������
        /// </summary>
        private void CacheOrderListCndtn(OrderListCndtnWork orderListCndtnWork)
        {
            // ���������l
            if (_orderListCndtnCache == null)
            {
                _orderListCndtnCache = new OrderListCndtnWork();
            }
            _orderListCndtnCache = orderListCndtnWork;

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

		/// <summary>
		/// �����ꗗ���o���ʃ��[�N�I�u�W�F�N�g���甭���ꗗ���o���ʃf�[�^�e�[�u���s�I�u�W�F�N�g�𐶐����܂��B
		/// </summary>
		/// <param name="no">�s�ԍ�</param>
		/// <param name="orderListResultWork"></param>
		/// <returns></returns>
		private OrderRemainDataSet.OrderListResultRow CreateOrderListResultRow( int no, OrderListResultWork orderListResultWork )
		{
			OrderRemainDataSet.OrderListResultRow row = _dataSet.OrderListResult.NewOrderListResultRow();

			#region ���ڂ̃R�s�[

			row.No = no;
			row.SelectFlag = false;
			row.DebitNoteDiv = orderListResultWork.DebitNoteDiv;
			row.SupplierSlipCd = orderListResultWork.SupplierSlipCd;
			row.PartySaleSlipNum = orderListResultWork.PartySaleSlipNum;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row.OrderFormPrintDate = orderListResultWork.OrderFormPrintDate;
            //row.OrderFormPrintDateDisplay = GetDateTimeString(orderListResultWork.OrderFormPrintDate, ct_DateFormat);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			row.AcceptAnOrderNo = orderListResultWork.AcceptAnOrderNo;
			row.SupplierFormal = orderListResultWork.SupplierFormal;
            // 2008.11.19 modify start [7968]
            if (orderListResultWork.SupplierSlipNo > 0)
            {
                row.SupplierSlipNo = orderListResultWork.SupplierSlipNo;
            }
            // 2008.11.19 modify end [7968]
			row.StockRowNo = orderListResultWork.StockRowNo;
			row.SectionCode = orderListResultWork.SectionCode;
			row.StockAgentCode = orderListResultWork.StockAgentCode;
			row.StockAgentName = orderListResultWork.StockAgentName;
			row.StockInputCode = orderListResultWork.StockInputCode;
			row.StockInputName = orderListResultWork.StockInputName;
			row.GoodsMakerCd = orderListResultWork.GoodsMakerCd;
			row.MakerName = orderListResultWork.MakerName;
			row.GoodsNo = orderListResultWork.GoodsNo;
			row.GoodsName = orderListResultWork.GoodsName;
			row.WarehouseCode = orderListResultWork.WarehouseCode;
			row.WarehouseName = orderListResultWork.WarehouseName;
			row.StockOrderDivCd = orderListResultWork.StockOrderDivCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row.UnitCode = orderListResultWork.UnitCode;
            //row.UnitName = orderListResultWork.UnitName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			row.StockUnitPriceFl = orderListResultWork.StockUnitPriceFl;
			row.StockUnitTaxPriceFl = orderListResultWork.StockUnitTaxPriceFl;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row.BargainCd = orderListResultWork.BargainCd;
            //row.BargainNm = orderListResultWork.BargainNm;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			row.StockCount = orderListResultWork.StockCount - orderListResultWork.OrderRemainCnt;
			row.StockPriceTaxExc = orderListResultWork.StockPriceTaxExc;
			row.StockPriceTaxInc = orderListResultWork.StockPriceTaxInc;
			row.StockDtiSlipNote1 = orderListResultWork.StockDtiSlipNote1;
			row.SalesCustomerCode = orderListResultWork.SalesCustomerCode;
			row.SalesCustomerSnm = orderListResultWork.SalesCustomerSnm;
            // 2008.11.19 modify start [7968]
            if (orderListResultWork.SupplierCd > 0)
            {
                row.SupplierCd = orderListResultWork.SupplierCd;
            }
            // 2008.11.19 modify end [7968]
			row.SupplierSnm = orderListResultWork.SupplierSnm;
			row.AddresseeCode = orderListResultWork.AddresseeCode;
			row.AddresseeName = orderListResultWork.AddresseeName;
			row.RemainCntUpdDate = orderListResultWork.RemainCntUpdDate;
			row.RemainCntUpdDateDisplay = GetDateTimeString(orderListResultWork.RemainCntUpdDate, ct_DateFormat);
			row.DirectSendingCd = orderListResultWork.DirectSendingCd;
			row.OrderNumber = orderListResultWork.OrderNumber;
			row.WayToOrder = orderListResultWork.WayToOrder;
			row.DeliGdsCmpltDueDate = orderListResultWork.DeliGdsCmpltDueDate;
			row.DeliGdsCmpltDueDateDisplay = GetDateTimeString(orderListResultWork.DeliGdsCmpltDueDate, ct_DateFormat);
			row.ExpectDeliveryDate = orderListResultWork.ExpectDeliveryDate;
			row.ExpectDeliveryDateDisplay = GetDateTimeString(orderListResultWork.ExpectDeliveryDate, ct_DateFormat);
			row.OrderCnt = orderListResultWork.StockCount;
			row.OrderAdjustCnt = orderListResultWork.StockCount;
			row.OrderRemainCnt = orderListResultWork.OrderRemainCnt;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row.ReconcileFlag = orderListResultWork.ReconcileFlag;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			row.OrderFormIssuedDiv = orderListResultWork.OrderFormIssuedDiv;
			row.OrderDataCreateDate = orderListResultWork.OrderDataCreateDate;
			row.OrderDataCreateDateDisplay = GetDateTimeString(orderListResultWork.OrderDataCreateDate, ct_DateFormat);
			row.SlipMemo1 = orderListResultWork.SlipMemo1;
			row.SlipMemo2 = orderListResultWork.SlipMemo2;
			row.SlipMemo3 = orderListResultWork.SlipMemo3;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row.SlipMemo4 = orderListResultWork.SlipMemo4;
            //row.SlipMemo5 = orderListResultWork.SlipMemo5;
            //row.SlipMemo6 = orderListResultWork.SlipMemo6;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			row.InsideMemo1 = orderListResultWork.InsideMemo1;
			row.InsideMemo2 = orderListResultWork.InsideMemo2;
			row.InsideMemo3 = orderListResultWork.InsideMemo3;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row.InsideMemo4 = orderListResultWork.InsideMemo4;
            //row.InsideMemo5 = orderListResultWork.InsideMemo5;
            //row.InsideMemo6 = orderListResultWork.InsideMemo6;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			row.StockSlipDtlNum = orderListResultWork.StockSlipDtlNum;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //if (( row.SlipMemo1 != string.Empty ) || ( row.SlipMemo2 != string.Empty ) || ( row.SlipMemo3 != string.Empty ) ||
            //    ( row.SlipMemo4 != string.Empty ) || ( row.SlipMemo5 != string.Empty ) || ( row.SlipMemo6 != string.Empty ) ||
            //    ( row.InsideMemo1 != string.Empty ) || ( row.InsideMemo2 != string.Empty ) || ( row.InsideMemo3 != string.Empty ) ||
            //    ( row.InsideMemo4 != string.Empty ) || ( row.InsideMemo5 != string.Empty ) || ( row.InsideMemo6 != string.Empty )
            //    )
            //{
            //    row.MemoExist = true;
            //    row.MemoExistName = "��";
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            if ( (row.SlipMemo1 != string.Empty) || (row.SlipMemo2 != string.Empty) || (row.SlipMemo3 != string.Empty) ||
                (row.InsideMemo1 != string.Empty) || (row.InsideMemo2 != string.Empty) || (row.InsideMemo3 != string.Empty)
                )
            {
                row.MemoExist = true;
                row.MemoExistName = "��";
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
            // 2008.11.19 add start [7968]
            if (orderListResultWork.InputDay != DateTime.MinValue)
            {
                row.InputDay = orderListResultWork.InputDay;
            }
            if (orderListResultWork.BLGoodsCode > 0)
            {
                row.BLGoodsCode = orderListResultWork.BLGoodsCode;
            }
            row.ListPriceTaxExcFl = orderListResultWork.ListPriceTaxExcFl;
            row.StockPriceConsTax = orderListResultWork.StockPriceConsTax;
            row.SectionGuideNm = orderListResultWork.SectionGuideNm;
            row.SectionGuideSnm = orderListResultWork.SectionGuideSnm;
            // 2008.11.19 add end [7968]

			#endregion

			return row;
		}

        #endregion

        #region ��Public Method

        /// <summary>
		/// �����c�Ɖ� �Ǎ��E�f�[�^�Z�b�g�i�[���s����
        /// </summary>
		/// <param name="ioWriteMASIRReadWork">�����c�����p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public int SetSearchData(OrderListCndtnWork orderListCndtnWork)
        {
            List<OrderListResultWork> retData;
            
            int status = this.Search(out retData, orderListCndtnWork);

            this.ClearOrderListResultDataTable();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                for (int i = 0; i < retData.Count; i++)
                {
                    OrderListResultWork orderListResultWork = retData[i];
					
					_dataSet.OrderListResult.AddOrderListResultRow(CreateOrderListResultRow(i + 1, orderListResultWork));
				}

                // �����f�[�^�̃L���b�V��
                this.CacheOrderRemainTable();

                // ���������̃L���b�V��
                this.CacheOrderListCndtn(orderListCndtnWork);
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

		/// <summary>
		/// �����ς݃f�[�^�̃f�[�^�Z�b�g�i�[����
		/// </summary>
		/// <param name="orderListResultWorkList">�����c�������ʃI�u�W�F�N�g���X�g</param>
		/// <returns></returns>
		public void SetSearchData( List<OrderListResultWork> orderListResultWorkList )
		{
			this.ClearOrderListResultDataTable();

			int cnt = 0;
			foreach (OrderListResultWork orderListResultWork in orderListResultWorkList)
			{
				this._dataSet.OrderListResult.AddOrderListResultRow(CreateOrderListResultRow(cnt++, orderListResultWork));

			}
			// �����f�[�^�̃L���b�V��
			this.CacheOrderRemainTable();

			// ���������̃L���b�V��
			this.CacheOrderListCndtn(new OrderListCndtnWork());
		}

        /// <summary>
        /// �f�[�^�Z�b�g�N���A����
        /// </summary>
        public void ClearOrderListResultDataTable()
        {
            this._dataSet.OrderListResult.Rows.Clear();

            // �L���b�V���f�[�^�̎�蒼��(�N���A��Ԃɂ���)
            this.CacheOrderRemainTable();
            this.CacheOrderListCndtn(null);

			if (this.SelectedRowChanged != null)
			{
				this.SelectedRowChanged(this, new EventArgs());
			}
		}
        
        /// <summary>
        /// �`�[��� �ǂݍ��ݏ���
        /// </summary>
        /// <param name="stockSlipWorks">�d���f�[�^ �I�u�W�F�N�g�z��</param>
        /// <param name="orderListCndtnWork">�d���`�[�����p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public int Search(out List<OrderListResultWork> orderListResultWorkList, OrderListCndtnWork orderListCndtnWork)
        {
            try
            {
                int status;
                orderListResultWorkList = new List<OrderListResultWork>();

                // �I�����C���̏ꍇ�����[�g�擾
                if (LoginInfoAcquisition.OnlineFlag)
                {
					ArrayList retList = new ArrayList();

					object paraObj = (object)orderListCndtnWork;
                    object retObj = (object)retList;

                    //�`�[���擾
					status = this._iOrderListWorkDB.Search(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);
                    
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
						foreach (OrderListResultWork orderListResultWork in (ArrayList)retObj)
						{
							orderListResultWorkList.Add(orderListResultWork);
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
            catch (Exception)
            {
                orderListResultWorkList = null;
                //�I�t���C������null���Z�b�g
                this._iOrderListWorkDB= null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �`�[�f�[�^�e�[�u���L���b�V���擾����
        /// </summary>
        /// <returns>�`�[�f�[�^�e�[�u���L���b�V��</returns>
        public OrderRemainDataSet.OrderListResultDataTable GetStockSlipTableCache()
        {
            return _orderListResultDataTable;
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
        public OrderListCndtnWork GetOrderListCndtnCache()
        {
            return _orderListCndtnCache;
		}

		/// <summary>
		/// ���������N���X�L���b�V���N���A����
		/// </summary>
		public void ClearOrderListCndtnCache()
		{
			_orderListCndtnCache = new OrderListCndtnWork();
		}

		/// <summary>
        /// �I���s�e�[�u���f�[�^�擾����
        /// </summary>
        /// <returns>�d���f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u������A�w��s�̎d���f�[�^�N���X��Ԃ��܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public List<OrderListResultWork> GetSelectedRowData()
        {
			// �ߒl
			List<OrderListResultWork> orderListResultWorkList = new List<OrderListResultWork>();

			DataView orderListResultView = new DataView(this._dataSet.OrderListResult);
			orderListResultView.RowFilter = String.Format("{0} = {1}", this._dataSet.OrderListResult.SelectFlagColumn.ColumnName, true);

			for (int ix = 0; ix < orderListResultView.Count; ix++)
			{
				#region ���ڂ̃R�s�[
				OrderListResultWork orderListResultWork = new OrderListResultWork();

				orderListResultWork.DebitNoteDiv = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.DebitNoteDivColumn.ColumnName];
				orderListResultWork.SupplierSlipCd = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.SupplierSlipCdColumn.ColumnName];
				orderListResultWork.PartySaleSlipNum = (string)orderListResultView[ix][this._dataSet.OrderListResult.PartySaleSlipNumColumn.ColumnName];
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //orderListResultWork.OrderFormPrintDate = (DateTime)orderListResultView[ix][this._dataSet.OrderListResult.OrderFormPrintDateColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
				orderListResultWork.AcceptAnOrderNo = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.AcceptAnOrderNoColumn.ColumnName];
				orderListResultWork.SupplierFormal = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.SupplierFormalColumn.ColumnName];
				orderListResultWork.SupplierSlipNo = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.SupplierSlipNoColumn.ColumnName];
				orderListResultWork.StockRowNo = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.StockRowNoColumn.ColumnName];
				orderListResultWork.SectionCode = (string)orderListResultView[ix][this._dataSet.OrderListResult.SectionCodeColumn.ColumnName];
				orderListResultWork.StockAgentCode = (string)orderListResultView[ix][this._dataSet.OrderListResult.StockAgentCodeColumn.ColumnName];
				orderListResultWork.StockAgentName = (string)orderListResultView[ix][this._dataSet.OrderListResult.StockAgentNameColumn.ColumnName];
				orderListResultWork.StockInputCode = (string)orderListResultView[ix][this._dataSet.OrderListResult.StockInputCodeColumn.ColumnName];
				orderListResultWork.StockInputName = (string)orderListResultView[ix][this._dataSet.OrderListResult.StockInputNameColumn.ColumnName];
				orderListResultWork.GoodsMakerCd = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.GoodsMakerCdColumn.ColumnName];
				orderListResultWork.MakerName = (string)orderListResultView[ix][this._dataSet.OrderListResult.MakerNameColumn.ColumnName];
				orderListResultWork.GoodsNo = (string)orderListResultView[ix][this._dataSet.OrderListResult.GoodsNoColumn.ColumnName];
				orderListResultWork.GoodsName = (string)orderListResultView[ix][this._dataSet.OrderListResult.GoodsNameColumn.ColumnName];
				orderListResultWork.WarehouseCode = (string)orderListResultView[ix][this._dataSet.OrderListResult.WarehouseCodeColumn.ColumnName];
				orderListResultWork.WarehouseName = (string)orderListResultView[ix][this._dataSet.OrderListResult.WarehouseNameColumn.ColumnName];
				orderListResultWork.StockOrderDivCd = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.StockOrderDivCdColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //orderListResultWork.UnitCode = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.UnitCodeColumn.ColumnName];
                //orderListResultWork.UnitName = (string)orderListResultView[ix][this._dataSet.OrderListResult.UnitNameColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
				orderListResultWork.StockUnitPriceFl = (Double)orderListResultView[ix][this._dataSet.OrderListResult.StockUnitPriceFlColumn.ColumnName];
				orderListResultWork.StockUnitTaxPriceFl = (Double)orderListResultView[ix][this._dataSet.OrderListResult.StockUnitTaxPriceFlColumn.ColumnName];
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //orderListResultWork.BargainCd = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.BargainCdColumn.ColumnName];
                //orderListResultWork.BargainNm = (string)orderListResultView[ix][this._dataSet.OrderListResult.BargainNmColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
				orderListResultWork.StockCount = (Double)orderListResultView[ix][this._dataSet.OrderListResult.StockCountColumn.ColumnName];
				orderListResultWork.StockPriceTaxExc = (Int64)orderListResultView[ix][this._dataSet.OrderListResult.StockPriceTaxExcColumn.ColumnName];
				orderListResultWork.StockPriceTaxInc = (Int64)orderListResultView[ix][this._dataSet.OrderListResult.StockPriceTaxIncColumn.ColumnName];
				orderListResultWork.StockDtiSlipNote1 = (string)orderListResultView[ix][this._dataSet.OrderListResult.StockDtiSlipNote1Column.ColumnName];
				orderListResultWork.SalesCustomerCode = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.SalesCustomerCodeColumn.ColumnName];
				orderListResultWork.SalesCustomerSnm = (string)orderListResultView[ix][this._dataSet.OrderListResult.SalesCustomerSnmColumn.ColumnName];
				orderListResultWork.SupplierCd = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.SupplierCdColumn.ColumnName];
				orderListResultWork.SupplierSnm = (string)orderListResultView[ix][this._dataSet.OrderListResult.SupplierSnmColumn.ColumnName];
				orderListResultWork.AddresseeCode = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.AddresseeCodeColumn.ColumnName];
				orderListResultWork.AddresseeName = (string)orderListResultView[ix][this._dataSet.OrderListResult.AddresseeNameColumn.ColumnName];
				orderListResultWork.RemainCntUpdDate = (DateTime)orderListResultView[ix][this._dataSet.OrderListResult.RemainCntUpdDateColumn.ColumnName];
				orderListResultWork.DirectSendingCd = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.DirectSendingCdColumn.ColumnName];
				orderListResultWork.OrderNumber = (string)orderListResultView[ix][this._dataSet.OrderListResult.OrderNumberColumn.ColumnName];
				orderListResultWork.WayToOrder = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.WayToOrderColumn.ColumnName];
				orderListResultWork.DeliGdsCmpltDueDate = (DateTime)orderListResultView[ix][this._dataSet.OrderListResult.DeliGdsCmpltDueDateColumn.ColumnName];
				orderListResultWork.ExpectDeliveryDate = (DateTime)orderListResultView[ix][this._dataSet.OrderListResult.ExpectDeliveryDateColumn.ColumnName];
				orderListResultWork.OrderCnt = (Double)orderListResultView[ix][this._dataSet.OrderListResult.OrderCntColumn.ColumnName];
				orderListResultWork.OrderAdjustCnt = (Double)orderListResultView[ix][this._dataSet.OrderListResult.OrderAdjustCntColumn.ColumnName];
				orderListResultWork.OrderRemainCnt = (Double)orderListResultView[ix][this._dataSet.OrderListResult.OrderRemainCntColumn.ColumnName];
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //orderListResultWork.ReconcileFlag = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.ReconcileFlagColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
				orderListResultWork.OrderFormIssuedDiv = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.OrderFormIssuedDivColumn.ColumnName];
				orderListResultWork.OrderDataCreateDate = (DateTime)orderListResultView[ix][this._dataSet.OrderListResult.OrderDataCreateDateColumn.ColumnName];
				orderListResultWork.SlipMemo1 = (string)orderListResultView[ix][this._dataSet.OrderListResult.SlipMemo1Column.ColumnName];
				orderListResultWork.SlipMemo2 = (string)orderListResultView[ix][this._dataSet.OrderListResult.SlipMemo2Column.ColumnName];
				orderListResultWork.SlipMemo3 = (string)orderListResultView[ix][this._dataSet.OrderListResult.SlipMemo3Column.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //orderListResultWork.SlipMemo4 = (string)orderListResultView[ix][this._dataSet.OrderListResult.SlipMemo4Column.ColumnName];
                //orderListResultWork.SlipMemo5 = (string)orderListResultView[ix][this._dataSet.OrderListResult.SlipMemo5Column.ColumnName];
                //orderListResultWork.SlipMemo6 = (string)orderListResultView[ix][this._dataSet.OrderListResult.SlipMemo6Column.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
				orderListResultWork.InsideMemo1 = (string)orderListResultView[ix][this._dataSet.OrderListResult.InsideMemo1Column.ColumnName];
				orderListResultWork.InsideMemo2 = (string)orderListResultView[ix][this._dataSet.OrderListResult.InsideMemo2Column.ColumnName];
				orderListResultWork.InsideMemo3 = (string)orderListResultView[ix][this._dataSet.OrderListResult.InsideMemo3Column.ColumnName];
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //orderListResultWork.InsideMemo4 = (string)orderListResultView[ix][this._dataSet.OrderListResult.InsideMemo4Column.ColumnName];
                //orderListResultWork.InsideMemo5 = (string)orderListResultView[ix][this._dataSet.OrderListResult.InsideMemo5Column.ColumnName];
                //orderListResultWork.InsideMemo6 = (string)orderListResultView[ix][this._dataSet.OrderListResult.InsideMemo6Column.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
				orderListResultWork.StockSlipDtlNum = (Int64)orderListResultView[ix][this._dataSet.OrderListResult.StockSlipDtlNumColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                if ( orderListResultView[ix][this._dataSet.OrderListResult.InputDayColumn.ColumnName] != DBNull.Value )
                {
                    orderListResultWork.InputDay = (DateTime)orderListResultView[ix][this._dataSet.OrderListResult.InputDayColumn.ColumnName];
                }
                else
                {
                    orderListResultWork.InputDay = DateTime.MinValue;
                }
                if ( orderListResultView[ix][this._dataSet.OrderListResult.BLGoodsCodeColumn.ColumnName] != DBNull.Value )
                {
                    orderListResultWork.BLGoodsCode = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.BLGoodsCodeColumn.ColumnName];
                }
                else
                {
                    orderListResultWork.BLGoodsCode = 0;
                }
                orderListResultWork.ListPriceTaxExcFl = (Double)orderListResultView[ix][this._dataSet.OrderListResult.ListPriceTaxExcFlColumn.ColumnName];
                orderListResultWork.StockPriceConsTax = (Int64)orderListResultView[ix][this._dataSet.OrderListResult.StockPriceConsTaxColumn.ColumnName];
                orderListResultWork.SectionGuideNm = (String)orderListResultView[ix][this._dataSet.OrderListResult.SectionGuideNmColumn.ColumnName];
                orderListResultWork.SectionGuideSnm = (String)orderListResultView[ix][this._dataSet.OrderListResult.SectionGuideSnmColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
				#endregion

				orderListResultWorkList.Add(orderListResultWork);
			}

			return orderListResultWorkList;
        }


		# region �� �s�I���`�F�b�N�ҏW ��

		/// <summary>
		/// �I���s�擾����
		/// </summary>
		public int GetSelectedRowCount()
		{
			// �f�[�^�r���[�𐶐����āA�I���ς݃t���O�Ńt�B���^��������
			DataView view = new DataView(this._dataSet.OrderListResult);
			view.RowFilter = string.Format("{0} = '{1}'",
												this._dataSet.OrderListResult.SelectFlagColumn.ColumnName, true);
			// ������Ԃ�
			return view.Count;
		}

		/// <summary>
		/// �s�I���`�F�b�N�����ibool���]�j
		/// </summary>
		/// <param name="rowNo"></param>
		public void SetRowSelected( int rowNo )
		{
			// �s���Ō���
			DataRow row = this._dataSet.OrderListResult.Rows.Find(rowNo);
			if (row == null) return;

			// �`�F�b�N�lbool���]�Z�b�g
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName] = !(bool)row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            int currentCount = GetSelectedRowCount();
            bool currentValue = (bool)row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName];

            if ( currentCount >= this.MaxSelectCount && currentValue == false )
            {
                this.RowChangeStatus = false;
            }
            else
            {
                row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName] = !currentValue;
                this.RowChangeStatus = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

			if (this.SelectedRowChanged != null)
			{
				this.SelectedRowChanged(this, new EventArgs());
			}
		}
		/// <summary>
		/// �s�I���`�F�b�N����
		/// </summary>
		/// <param name="rowNo"></param>
		/// <param name="rowSelected"></param>
		public void SetRowSelected( int rowNo, bool rowSelected )
		{
			// �s���Ō���
			DataRow row = this._dataSet.OrderListResult.Rows.Find(rowNo);
			if (row == null) return;

			// �`�F�b�N�l�Z�b�g
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName] = rowSelected;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            int currentCount = GetSelectedRowCount();

            if ( currentCount >= this.MaxSelectCount && rowSelected == true )
            {
                this.RowChangeStatus = false;
            }
            else
            {
                row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName] = rowSelected;
                this.RowChangeStatus = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

			if (this.SelectedRowChanged != null)
			{
				this.SelectedRowChanged(this, new EventArgs());
			}
		}
		/// <summary>
		/// �S�Ă̍s�̑I���`�F�b�N���Z�b�g
		/// </summary>
		public void SetRowSelectedAll( bool rowSelected )
		{
			// �S�Ă̍s�̑I���`�F�b�N��ݒ�
			foreach (DataRow row in this._dataSet.OrderListResult.Rows)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                int currentCount = GetSelectedRowCount();

                if ( currentCount >= this.MaxSelectCount && rowSelected == true )
                {
                    this.RowChangeStatus = false;
                    break;
                }
                this.RowChangeStatus = true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
				row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName] = rowSelected;
			}

			if (this.SelectedRowChanged != null)
			{
				this.SelectedRowChanged(this, new EventArgs());
			}
		}
		#endregion

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
                return true;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
        /// ���_����A�N�Z�X�N���X�C���X�^���X������
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ���O�C���S�����_���̎擾
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// �{�Ћ@�\�^���_�@�\�`�F�b�N����
        /// </summary>
        /// <returns>true:�{�Ћ@�\ false:���_�@�\</returns>
        public bool IsMainOfficeFunc()
        {
            bool isMainOfficeFunc = false;

            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs();

            // ���O�C���S�����_���̎擾
            SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            if (secInfoSet != null)
            {
                // �{�Ћ@�\���H
                if (secInfoSet.MainOfficeFuncFlag == 1)
                {
                    isMainOfficeFunc = true;
                }
            }
            else
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }

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
		# endregion

	}
}
