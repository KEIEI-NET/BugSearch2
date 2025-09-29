using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using System.Collections; // ADD 2013/03/13 �v�� Redmine#35020 No.1834

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �������� UOE�����I���A�N�Z�X�N���X
    /// </summary>
    /// <br>Note       : �������ς�UOE�����p�̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.10.17 men �V�K�쐬</br>
    /// <br>Update     : 2011/02/14 dingjx</br>
    /// <br>Note       : �����I�����̐��ʃ`�F�b�N�����ǉ�</br>
    /// <br>Update Note: 2013/02/27 杍^</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00�A2013/03/13�z�M��</br>
    /// <br>             Redmine#34434 No.1180 ���݌ɐ����O�̂Ƃ��݌ɐ����󔒂ŕ\�������̑Ή�</br>
    /// <br>Update Note: 2013/03/07 gaofeng</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00�A2013/03/13�z�M��</br>
    /// <br>             Redmine#34994 �D�ǔ�����̏ꍇ�ɂa�n�敪����͂���ƁA���������f�t�H���g�\�����Ȃ��A�O�ŕ\�������̑Ή�</br>
    /// <br>Update Note: 2013/03/08 杍^</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00�A2013/03/13�z�M��</br>
    /// <br>             Redmine#34994 �D�ǔ�����̏ꍇ�ɂa�n�敪����͂���ƁA���������f�t�H���g�\�����Ȃ��A�O�ŕ\�������̑Ή�</br>
    /// <br>Update Note: 2013/03/10 杍^</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : redmine#34994�A�������ϔ��s�@���݌ɐ����O�̂Ƃ��݌ɐ����O�ŕ\���̑Ή�</br>
    /// <br>Update Note: 2013/03/13 �v��</br>
    /// <br>�Ǘ��ԍ�   : 10900691-00�A2013/05/15�z�M��</br>
    /// <br>             Redmine#35020 �Ǘ���1834 �u�������ρv�́u����������ʁv�̃��X�|���X�ቺ�̃g���K�[�̔r��</br>
    /// <br>Update Note: 2013/04/15 donggy</br>
    /// <br>�Ǘ��ԍ�   : 10900691-00 2013/05/15�z�M��</br>
    /// <br>               Redmine#35020�@�������ρv�́u����������ʁv�̃��X�|���X�ቺ�̃g���K�[�̔r��</br>
    /// <remarks></remarks>
    public class EstimateInputOrderSelectAcs
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region ��Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public EstimateInputOrderSelectAcs()
        {
            //this._primeInfoDataTable = primeInfoDataTable;
            //this._estimateDetailDataTable = estimateDetailDataTable;
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._estimateInputInitDataAcs = EstimateInputInitDataAcs.GetInstance();
            this._uOESupplierAcs = new UOESupplierAcs();
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region �� Private Members

        // ADD 2013/03/13 �v�� Redmine#35020 No.1834 ---->>>>>>>>
        // �S��UOE��������Dictionary
        private Dictionary<int, UOESupplier> _allSupplierDic;
        // ADD 2013/03/13 �v�� Redmine#35020 No.1834 ----<<<<<<<<

        private string _enterpriseCode;
        private DataTable _headerTable;
        private DataTable _detailTable;
        private DataView _headerView;
        private DataView _detailView;

        private EstimateInputInitDataAcs _estimateInputInitDataAcs;

        private UOESupplierAcs _uOESupplierAcs;

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region ��Properties

        /// <summary>�w�b�_���f�[�^�r���[</summary>
        public DataView HeaderView
        {
            get { return _headerView; }
            set { _headerView = value; }
        }

        /// <summary>���׏��f�[�^�r���[</summary>
        public DataView DetailView
        {
            get { return _detailView; }
            set { _detailView = value; }
        }

        /// <summary>���׏��f�[�^�r���[</summary>
        public DataTable DetailTable
        {
            get { return _detailTable; }
            set { _detailTable = value; }
        }

        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region ��Public Methods

        /// <summary>
        /// �����I�������f�[�^���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDataTable">�t�n�d�����f�[�^�e�[�u��</param>
        /// <param name="uoeOrderDetailDataTable">�t�n�d�������׃f�[�^�e�[�u��</param>
        public void GetOrderSelectData(out EstimateInputDataSet.UOEOrderDataTable uoeOrderDataTable, out EstimateInputDataSet.UOEOrderDetailDataTable uoeOrderDetailDataTable)
        {
            uoeOrderDataTable = new EstimateInputDataSet.UOEOrderDataTable();
            uoeOrderDetailDataTable = new EstimateInputDataSet.UOEOrderDetailDataTable();

            // �����I������Ă�����𒊏o����
            DataRow[] hdRows = this._headerTable.Select(string.Format("{0}='{1}'", EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrder, true),EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd);

            foreach (DataRow hdRow in hdRows)
            {
                Guid orderGuid = Guid.NewGuid();

                // �Ώ۔�����Ŕ����������͂���Ă���f�[�^�𒊏o����
                DataRow[] dtlRows = this._detailTable.Select(string.Format("{0}<>{1} AND {2}={3}", EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt, 0, EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_SupplierCd, (int)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd]));
                if (( dtlRows != null ) && ( dtlRows.Length > 0 ))
                {
                    // �f�[�^�����݂���ꍇ�̓w�b�_�s�𐶐�
                    EstimateInputDataSet.UOEOrderRow uoeOrderRow = uoeOrderDataTable.NewUOEOrderRow();
                    uoeOrderRow.OrderGuid = orderGuid;
                    uoeOrderRow.UOESupplierCd = (int)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierCd];
                    uoeOrderRow.UOESupplierName = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierName];
                    uoeOrderRow.UOEDeliGoodsDiv = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEDeliGoodsDiv];
                    uoeOrderRow.DeliveredGoodsDivNm = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_DeliveredGoodsDivNm];
                    uoeOrderRow.FollowDeliGoodsDiv = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_FollowDeliGoodsDiv];
                    uoeOrderRow.FollowDeliGoodsDivNm = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_FollowDeliGoodsDivNm];
                    uoeOrderRow.UOEResvdSection = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEResvdSection];
                    uoeOrderRow.UOEResvdSectionNm = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEResvdSectionNm];
                    uoeOrderRow.UoeRemark1 = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark1];
                    uoeOrderRow.UoeRemark2 = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark2];
                    uoeOrderRow.CommAssemblyId = ( (UOESupplier)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplier] ).CommAssemblyId;
                    uoeOrderRow.SupplierCd = ( (UOESupplier)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplier] ).SupplierCd;
                    uoeOrderDataTable.AddUOEOrderRow(uoeOrderRow);

                    foreach (DataRow dtlRow in dtlRows)
                    {
                        EstimateInputDataSet.UOEOrderDetailRow uoeOrderDetailRow = uoeOrderDetailDataTable.NewUOEOrderDetailRow();
                        uoeOrderDetailRow.DtlRelationGuid = (Guid)dtlRow[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_DtlRelationGuid];
                        uoeOrderDetailRow.BoCode = (string)dtlRow[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode];
                        uoeOrderDetailRow.OrderCnt = (int)dtlRow[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt];
                        uoeOrderDetailRow.OrderGuid = orderGuid;

                        uoeOrderDetailDataTable.AddUOEOrderDetailRow(uoeOrderDetailRow);

                    }
                }
            }
        }

        /// <summary>
        /// �����I��p�̃f�[�^�e�[�u���𐶐����܂��B
        /// </summary>
        /// <param name="estimateDetailDataTable"></param>
        /// <param name="primeInfoDataTable"></param>
        /// <param name="uoeOrderDataTable"></param>
        /// <param name="uoeOrderDetailDataTable"></param>
        /// <br>Update Note: 2013/03/08 杍^</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A2013/03/13�z�M��</br>
        /// <br>             Redmine#34994 �D�ǔ�����̏ꍇ�ɂa�n�敪����͂���ƁA���������f�t�H���g�\�����Ȃ��A�O�ŕ\�������̑Ή�</br>
        /// <br>Update Note: 2013/04/15 donggy</br>
        /// <br>�Ǘ��ԍ�   : 10900691-00 2013/05/15�z�M��</br>
        /// <br>             Redmine#35020�@�������ρv�́u����������ʁv�̃��X�|���X�ቺ�̃g���K�[�̔r��</br>
        /// <remarks></remarks>
        public void CreateOrderSelectDataTable(EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable, EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable, EstimateInputDataSet.UOEOrderDataTable uoeOrderDataTable, EstimateInputDataSet.UOEOrderDetailDataTable uoeOrderDetailDataTable)
        {
            List<int> supplierList = new List<int>();

            OrderSelectHdTable.CreateTable(ref this._headerTable);
            OrderSelectDtlTable.CreateTable(ref this._detailTable);

            DataView estmView = new DataView(estimateDetailDataTable);
            DataView primeView = new DataView(primeInfoDataTable);

            #region �������i�̔����e�[�u�������i���ϖ��׃e�[�u�����j

            estmView.RowFilter = string.Format("{0}<>{1} AND {2}<>'{3}' AND {4}<>{5}",
                estimateDetailDataTable.SupplierCdColumn.ColumnName, 0,
                estimateDetailDataTable.GoodsNoColumn.ColumnName, string.Empty,
                estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, 0);

            foreach (DataRowView drv in estmView)
            {
                if (!supplierList.Contains((int)drv[estimateDetailDataTable.SupplierCdColumn.ColumnName]))
                {
                    DataRow hdRow = _headerTable.NewRow();
                    hdRow[OrderSelectHdTable.ctColName_SupplierCd] = (int)drv[estimateDetailDataTable.SupplierCdColumn.ColumnName];
                    hdRow[OrderSelectHdTable.ctColName_SupplierSnm] = (string)drv[estimateDetailDataTable.SupplierSnmColumn.ColumnName];

                    _headerTable.Rows.Add(hdRow);
                    supplierList.Add((int)drv[estimateDetailDataTable.SupplierCdColumn.ColumnName]);
                }

                DataRow dtlRow = _detailTable.NewRow();
                dtlRow[OrderSelectDtlTable.ctColName_DtlRelationGuid] = (Guid)drv[estimateDetailDataTable.DtlRelationGuidColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_SupplierCd] = (int)drv[estimateDetailDataTable.SupplierCdColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsName] = (string)drv[estimateDetailDataTable.GoodsNameColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsNo] = (string)drv[estimateDetailDataTable.GoodsNoColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsMakerCd] = (int)drv[estimateDetailDataTable.GoodsMakerCdColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_WarehouseCode] = (string)drv[estimateDetailDataTable.WarehouseCodeColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_ShipmentCnt] = (double)drv[estimateDetailDataTable.ShipmentCntColumn.ColumnName];
                //dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = (double)drv[estimateDetailDataTable.ShipmentPosCntColumn.ColumnName]; // DEL 2013/03/08 tanh Redmine#34994

                // ADD 2013/03/08 tanh Redmine#34994 ---- >>>>>
                if (string.IsNullOrEmpty(dtlRow[OrderSelectDtlTable.ctColName_WarehouseCode].ToString()))
                {
                    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = string.Empty;
                }
                else
                {
                    //dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = ((double)drv[estimateDetailDataTable.ShipmentPosCntColumn.ColumnName]).ToString("N");// DEL 杍^ Redmine#34994 2013/03/10
                    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = double.Parse(drv[estimateDetailDataTable.ShipmentPosCntColumn.ColumnName].ToString()).ToString("N");// ADD 杍^ Redmine#34994 2013/03/10
                }
                // ADD 2013/03/08 tanh Redmine#34994 ---- <<<<<

                if ((Guid)drv[estimateDetailDataTable.UOEOrderGuidColumn.ColumnName] == Guid.Empty)
                {
                    dtlRow[OrderSelectDtlTable.ctColName_BOCode] = "*";
                }
                else
                {

                }
                _detailTable.Rows.Add(dtlRow);
            }
            #endregion

            #region �D�Ǖ��i�̔����e�[�u�������i���ϖ��׃e�[�u�����j

            // �D�ǘA��GUID�������Ă���f�[�^�͏��O�i�D�ǃf�[�^�e�[�u����蒊�o����ׁj���Ē��o
            estmView.RowFilter = string.Format("{0}<>{1} AND {2}<>'{3}' AND {4}<>{5} AND {6}='{7}'",
                estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName, 0,
                estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, string.Empty,
                estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName, 0,
                estimateDetailDataTable.PrimeInfoRelationGuidColumn.ColumnName, Guid.Empty);

            foreach (DataRowView drv in estmView)
            {
                if (!supplierList.Contains((int)drv[estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName]))
                {
                    DataRow hdRow = _headerTable.NewRow();
                    hdRow[OrderSelectHdTable.ctColName_SupplierCd] = (int)drv[estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName];
                    hdRow[OrderSelectHdTable.ctColName_SupplierSnm] = (string)drv[estimateDetailDataTable.SupplierSnm_PrimeColumn.ColumnName];

                    _headerTable.Rows.Add(hdRow);
                    supplierList.Add((int)drv[estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName]);
                }

                DataRow dtlRow = _detailTable.NewRow();
                dtlRow[OrderSelectDtlTable.ctColName_DtlRelationGuid] = (Guid)drv[estimateDetailDataTable.DtlRelationGuid_PrimeColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_SupplierCd] = (int)drv[estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsName] = (string)drv[estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsNo] = (string)drv[estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsMakerCd] = (int)drv[estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName];
                //dtlRow[OrderSelectDtlTable.ctColName_WarehouseCode] = (string)drv[estimateDetailDataTable.WarehouseName_PrimeColumn.ColumnName];// DEL 2013/03/10 杍^ Redmine#34994
                dtlRow[OrderSelectDtlTable.ctColName_WarehouseCode] = (string)drv[estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName];// ADD 2013/03/10 杍^ Redmine#34994
                dtlRow[OrderSelectDtlTable.ctColName_ShipmentCnt] = (double)drv[estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName];
                //dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = (double)drv[estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName]; // DEL 2013/03/08 tanh Redmine#34994
                // ADD 2013/03/08 tanh Redmine#34994 ---- >>>>>
                if (string.IsNullOrEmpty(dtlRow[OrderSelectDtlTable.ctColName_WarehouseCode].ToString()))
                {
                    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = string.Empty;
                }
                else
                {
                    //dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = ((double)drv[estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName]).ToString("N");// DEL 杍^ Redmine#34994 2013/03/10
                    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = double.Parse(drv[estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName].ToString()).ToString("N");// ADD 杍^ Redmine#34994 2013/03/10
                }
                // ADD 2013/03/08 tanh Redmine#34994 ---- <<<<<
                if ((Guid)drv[estimateDetailDataTable.UOEOrderGuid_PrimeColumn.ColumnName] == Guid.Empty)
                {
                    dtlRow[OrderSelectDtlTable.ctColName_BOCode] = "*";
                }
                else
                {

                }

                _detailTable.Rows.Add(dtlRow);
            }

            #endregion

            #region �D�Ǖ��i�̔����e�[�u�������i�D�Ǖ��i�e�[�u�����j

            primeView.RowFilter = string.Format("{0}<>{1} AND {2}<>'{3}' AND {4}<>{5}",
                primeInfoDataTable.SupplierCdColumn.ColumnName, 0,
                primeInfoDataTable.GoodsNoColumn.ColumnName, string.Empty,
                primeInfoDataTable.GoodsMakerCdColumn.ColumnName, 0);

            foreach (DataRowView drv in primeView)
            {
                if (!supplierList.Contains((int)drv[primeInfoDataTable.SupplierCdColumn.ColumnName]))
                {
                    DataRow hdRow = _headerTable.NewRow();
                    hdRow[OrderSelectHdTable.ctColName_SupplierCd] = (int)drv[primeInfoDataTable.SupplierCdColumn.ColumnName];
                    hdRow[OrderSelectHdTable.ctColName_SupplierSnm] = (string)drv[primeInfoDataTable.SupplierSnmColumn.ColumnName];

                    _headerTable.Rows.Add(hdRow);
                    supplierList.Add((int)drv[primeInfoDataTable.SupplierCdColumn.ColumnName]);
                }

                DataRow dtlRow = _detailTable.NewRow();
                dtlRow[OrderSelectDtlTable.ctColName_DtlRelationGuid] = (Guid)drv[primeInfoDataTable.DtlRelationGuidColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_SupplierCd] = (int)drv[primeInfoDataTable.SupplierCdColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsName] = (string)drv[primeInfoDataTable.GoodsNameColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsNo] = (string)drv[primeInfoDataTable.GoodsNoColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsMakerCd] = (int)drv[primeInfoDataTable.GoodsMakerCdColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_WarehouseCode] = (string)drv[primeInfoDataTable.WarehouseCodeColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_ShipmentCnt] = (double)drv[primeInfoDataTable.ShipmentCntColumn.ColumnName];
                //dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = (double)drv[primeInfoDataTable.ShipmentPosCntColumn.ColumnName]; // DEL 2013/02/27 tanh Redmine#34434 No.1180

                // DEL 2013/03/08 tanh Redmine#34994 ---- >>>>>
                // ADD 2013/02/27 tanh Redmine#34434 No.1180 ---- >>>>>>>>>>>>
                //if (string.IsNullOrEmpty(drv[primeInfoDataTable.ShipmentPosCntColumn.ColumnName].ToString()))
                //{
                //    //dtlRow[OrderSelectDtlTable.ctColName_ShipmentCnt] = 0; // DEL 2013/03/07 gaofeng Redmine#34994
                //    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = 0;�@// ADD 2013/03/07 gaofeng Redmine#34994
                //}
                //else
                //{
                //    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = double.Parse(drv[primeInfoDataTable.ShipmentPosCntColumn.ColumnName].ToString());

                //}
                // ADD 2013/02/27 tanh Redmine#34434 No.1180 ---- <<<<<<<<<<<<
                // DEL 2013/03/08 tanh Redmine#34994 ---- <<<<<

                // ADD 2013/03/08 tanh Redmine#34994 ---- >>>>>
                if (string.IsNullOrEmpty(drv[primeInfoDataTable.ShipmentPosCntColumn.ColumnName].ToString()))
                {
                    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = string.Empty;
                }
                else
                {
                    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = (double.Parse(drv[primeInfoDataTable.ShipmentPosCntColumn.ColumnName].ToString())).ToString("N"); 
                }
                // ADD 2013/03/08 tanh Redmine#34994 ---- <<<<<

                if ((Guid)drv[primeInfoDataTable.UOEOrderGuidColumn.ColumnName] == Guid.Empty)
                {
                    dtlRow[OrderSelectDtlTable.ctColName_BOCode] = "*";
                }
                else
                {
                }
                _detailTable.Rows.Add(dtlRow);
            }

            #endregion

            #region �����I���ςݏ��̔��f

            List<Guid> orderGuidList = new List<Guid>();
            foreach (EstimateInputDataSet.UOEOrderDetailRow uoeOrderDetailRow in uoeOrderDetailDataTable.Rows)
            {
                DataRow row = _detailTable.Rows.Find(uoeOrderDetailRow.DtlRelationGuid);

                if (row != null)
                {
                    if (!orderGuidList.Contains(uoeOrderDetailRow.OrderGuid))
                    {
                        DataRow hdRow = _headerTable.Rows.Find((int)row[OrderSelectDtlTable.ctColName_SupplierCd]);
                        EstimateInputDataSet.UOEOrderRow uoeOrderRow = uoeOrderDataTable.FindByOrderGuid(uoeOrderDetailRow.OrderGuid);

                        if (( hdRow != null ) && ( uoeOrderRow != null ))
                        {
                            hdRow[OrderSelectHdTable.ctColName_ExistOrder] = true;
                            hdRow[OrderSelectHdTable.ctColName_OrderGuid] = uoeOrderRow.OrderGuid;
                            hdRow[OrderSelectHdTable.ctColName_UOESupplierCd] = uoeOrderRow.UOESupplierCd;
                            hdRow[OrderSelectHdTable.ctColName_UOESupplierName] = uoeOrderRow.UOESupplierName;
                            hdRow[OrderSelectHdTable.ctColName_UoeRemark1] = uoeOrderRow.UoeRemark1;
                            hdRow[OrderSelectHdTable.ctColName_UoeRemark2] = uoeOrderRow.UoeRemark2;
                            hdRow[OrderSelectHdTable.ctColName_UOEDeliGoodsDiv] = uoeOrderRow.UOEDeliGoodsDiv;
                            hdRow[OrderSelectHdTable.ctColName_DeliveredGoodsDivNm] = uoeOrderRow.DeliveredGoodsDivNm;
                            hdRow[OrderSelectHdTable.ctColName_FollowDeliGoodsDiv] = uoeOrderRow.FollowDeliGoodsDiv;
                            hdRow[OrderSelectHdTable.ctColName_FollowDeliGoodsDivNm] = uoeOrderRow.FollowDeliGoodsDivNm;
                            hdRow[OrderSelectHdTable.ctColName_UOEResvdSection] = uoeOrderRow.UOEResvdSection;
                            hdRow[OrderSelectHdTable.ctColName_UOEResvdSectionNm] = uoeOrderRow.UOEResvdSectionNm;
                        }
                        orderGuidList.Add(uoeOrderDetailRow.OrderGuid);
                    }
                    row[OrderSelectDtlTable.ctColName_BOCode] = uoeOrderDetailRow.BoCode;
                    row[OrderSelectDtlTable.ctColName_OrderCnt] = uoeOrderDetailRow.OrderCnt;
                }
            }
            
            #endregion

            #region ��������̐ݒ�
            // --- DEL donggy 2013/04/15 for Redmine#35020 --->>>>>>>
            //// ADD 2013/03/13 �v�� Redmine#35020 No.1834 ---->>>>>>>>
            //// �S��UOE�������񌟍�����
            //FindAllSupplierInfo();
            //// ADD 2013/03/13 �v�� Redmine#35020 No.1834 ----<<<<<<<<

            //foreach (DataRow row in _headerTable.Rows)
            //{
            //    bool defaultSetting = ( (Guid)row[OrderSelectHdTable.ctColName_OrderGuid] == Guid.Empty );

            //    int targetCode = ( defaultSetting ) ? (int)row[OrderSelectHdTable.ctColName_SupplierCd] : (int)row[OrderSelectHdTable.ctColName_UOESupplierCd];

            //this.UOESupplierInfoReadAndSetting(row, targetCode, defaultSetting);
            //}
            // --- DEL donggy 2013/04/15 for Redmine#35020 ---<<<<<<<

            // --- ADD donggy 2013/04/15 for Redmine#35020 --->>>>>>>
            List<UOESupplier> uoeSupplierList = new List<UOESupplier>();
            // �w�蔭����R�[�h�擾
            foreach (DataRow row in _headerTable.Rows)
            {
                bool defaultSetting = ( (Guid)row[OrderSelectHdTable.ctColName_OrderGuid] == Guid.Empty );

                int targetCode = ( defaultSetting ) ? (int)row[OrderSelectHdTable.ctColName_SupplierCd] : (int)row[OrderSelectHdTable.ctColName_UOESupplierCd];

                UOESupplier paraUoeSupplier = new UOESupplier();
                paraUoeSupplier.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                paraUoeSupplier.EnterpriseCode = this._enterpriseCode;
                paraUoeSupplier.UOESupplierCd = targetCode;

                uoeSupplierList.Add(paraUoeSupplier);

            }
            // UOE ������}�X�^���̃��X�g���擾���܂��B
            ArrayList retSupplierList = new ArrayList();
            this._uOESupplierAcs.SearchBySupplierCds(out retSupplierList, uoeSupplierList);
            // UOE��������Dictionary�쐬
            // Dictionary�̐���
            //           KEY : UOESupplierCd
            //           VALUE : UOESupplier
            _allSupplierDic = new Dictionary<int, UOESupplier>();
            foreach (UOESupplier tempUOESupplier in retSupplierList)
            {
                if (!_allSupplierDic.ContainsKey(tempUOESupplier.UOESupplierCd))
                {
                    _allSupplierDic.Add(tempUOESupplier.UOESupplierCd, tempUOESupplier);
                }
            }
            // ��������̐ݒ�
            foreach (DataRow row in _headerTable.Rows)
            {
                bool defaultSetting = ((Guid)row[OrderSelectHdTable.ctColName_OrderGuid] == Guid.Empty);

                int targetCode = (defaultSetting) ? (int)row[OrderSelectHdTable.ctColName_SupplierCd] : (int)row[OrderSelectHdTable.ctColName_UOESupplierCd];
                if (!_allSupplierDic.ContainsKey(targetCode))
                {
                    UOESupplier newUoeSupplier = new UOESupplier();
                    _allSupplierDic.Add(targetCode, newUoeSupplier);
                }
                // ��������̏����l�ݒ�
                this.UOESupplierInfoSetting(row, _allSupplierDic[targetCode], true);
            }
            #endregion

            this._headerView = new DataView(this._headerTable);
            this._detailView = new DataView(this._detailTable);
        }

        /// <summary>
        /// �����I��p�̃f�[�^�����݂��邩�`�F�b�N���܂��B
        /// </summary>
        /// <returns></returns>
        public bool ExistData()
        {
            return ( this._headerTable.Rows.Count > 0 );
        }

        /// <summary>
        /// �d����ύX������
        /// </summary>
        public void ChangeSupplier(int supplierCd)
        {
            this._detailView.RowFilter = string.Format("{0}={1}", EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_SupplierCd, supplierCd);

            int index = 1;
            foreach(DataRowView drv in this._detailView)
            {
                drv[OrderSelectDtlTable.ctColName_No] = index;
                index++;
            }
        }

        /// <summary>
        /// ���׏��ύX���C�x���g
        /// </summary>
        /// <param name="supplierCd">�d����</param>
        public void DetailDataChenged(int supplierCd)
        {
            DataRow[] dtlRows = this._detailTable.Select(string.Format("{0}={1} AND {2}<>{3}", OrderSelectDtlTable.ctColName_SupplierCd, supplierCd, OrderSelectDtlTable.ctColName_OrderCnt, 0));

            DataRow row = this._headerTable.Rows.Find(supplierCd);
            if (row != null)
            {
                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrder] = ( ( dtlRows != null ) && ( dtlRows.Length > 0 ) );
            }
            this._headerTable.AcceptChanges();
        }

        /// <summary>
        /// �w�b�_�s�擾����
        /// </summary>
        /// <param name="supplierCd"></param>
        public DataRow GetOrderSelectHeaderRow(int supplierCd)
        {
            return this._headerTable.Rows.Find(supplierCd);
        }

        /// <summary>
        /// ��������̏����l�ݒ菈��
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="uoeSupplier">�t�n�d������}�X�^</param>
        public void UOESupplierInfoDefaultSetting(int supplierCd, UOESupplier uoeSupplier)
        {
            DataRow row = this._headerTable.Rows.Find(supplierCd);

            this.UOESupplierInfoSetting(row, uoeSupplier, true);
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        public void OrderCancel(int supplierCd)
        {
            DataRow row = this._headerTable.Rows.Find(supplierCd);

            if (row != null)
            {
                this.DetailOrderCancel((int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd]);
                //this._detailInput.AllOrderCancel((int)row[OrderSelectHdTable.ctColName_SupplierCd]);
            }

            row[OrderSelectHdTable.ctColName_ExistOrder] = false;
            this.UOESupplierInfoReadAndSetting(row, supplierCd, true);
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        public void OrderCancel(Guid dtlRelationGuid)
        {
            DataRow row = this._detailTable.Rows.Find(dtlRelationGuid);

            if (row != null)
            {
                this.DetailOrderCancel(row);
            }
        }

        /// <summary>
        /// ���ׂ̔������ݒ�
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        /// <param name="orderCnt"></param>
        public void DetailSettingOrderCnt(Guid dtlRelationGuid, int orderCnt)
        {
            DataRow row = this._detailTable.Rows.Find(dtlRelationGuid);

            if (row != null)
            {
                row[OrderSelectDtlTable.ctColName_OrderCnt] = orderCnt;
            }
            this._detailTable.AcceptChanges();
        }

        /// <summary>
        /// ���ׂ̔����������l�ݒ�
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        public void DetailSettingDefaultOrderCnt(Guid dtlRelationGuid)
        {
            DataRow row = this._detailTable.Rows.Find(dtlRelationGuid);

            if (row != null)
            {
                row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt] = (int)(double)row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentCnt];
            }
            this._detailTable.AcceptChanges();
        }

        /// <summary>
        /// ���ה����L�����Z������
        /// </summary>
        /// <param name="supplierCd"></param>
        public void DetailOrderCancel(int supplierCd)
        {
            DataRow[] rows = this._detailTable.Select(string.Format("{0}={1}", EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_SupplierCd, supplierCd));

            if (( rows != null ) && ( rows.Length > 0 ))
            {
                foreach (DataRow row in rows)
                {
                    this.DetailOrderCancel(row);
                }
            }
        }

        /// <summary>
        /// ���ה����L�����Z������
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        public  void DetailOrderCancel(Guid dtlRelationGuid)
        {
            DataRow row = this._detailTable.Rows.Find(dtlRelationGuid);

            if (row != null)
            {
                this.DetailOrderCancel(row);
            }
            this._detailTable.AcceptChanges();
        }

        /// <summary>
        /// ���ה����L�����Z������
        /// </summary>
        /// <param name="row"></param>
        public void DetailOrderCancel(DataRow row)
        {
            if (row != null)
            {
                row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt] = 0;
                row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode] = "*";
            }
        }

        /// <summary>
        /// �������ݒ�
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        /// <param name="orderCnt"></param>
        public void DetailOrderCntSetting(Guid dtlRelationGuid, int orderCnt)
        {
            DataRow row = this._detailTable.Rows.Find(dtlRelationGuid);

            if (row != null)
            {
                row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt] = orderCnt;
            }
        }

        /// <summary>
        /// �����ۃ`�F�b�N
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        public bool ChackCanOrder(Guid dtlRelationGuid)
        {
            bool ret = false;

            DataRow row = this._detailTable.Rows.Find(dtlRelationGuid);

            if (row != null)
            {
                DataRow hdRow = this._headerTable.Rows.Find((int)row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_SupplierCd]);
                if (hdRow != null)
                {
                    UOESupplier uoeSupplier = (UOESupplier)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplier];

                    UOESupplierAcs.PureCodeDiv pureCodeDiv = UOESupplierAcs.PureCodeUOESupplier(uoeSupplier.CommAssemblyId);
                    if (pureCodeDiv == UOESupplierAcs.PureCodeDiv.Prime)
                    {
                        ret = true;
                    }
                    else
                    {
                        int goodsMakerCd = (int)row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsMakerCd];
                        ret = ( ( goodsMakerCd == uoeSupplier.EnableOdrMakerCd1 ) || ( goodsMakerCd == uoeSupplier.EnableOdrMakerCd2 ) || ( goodsMakerCd == uoeSupplier.EnableOdrMakerCd3 ) || ( goodsMakerCd == uoeSupplier.EnableOdrMakerCd4 ) || ( goodsMakerCd == uoeSupplier.EnableOdrMakerCd5 ) );
                    }
                }
            }

            return ret;
        }

        //  ADD 2011/02/14  >>>
        /// <summary>
        /// �����I�����̐��ʃ`�F�b�N
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <returns></returns>
        public string CheckDetail(int supplierCd)
        {
            string message = null;

            this._detailView.RowFilter = string.Format("{0}={1}", EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_SupplierCd, supplierCd);

            int index = 1;
            foreach (DataRowView drv in this._detailView)
            {
                if ((int)(drv.Row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt]) > 999)
                    message += "      �s�� " + index.ToString() + "\r\n";
                index++;
            }

            return message;
        } 
        //  ADD 2011/02/14  <<<

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g ���\�b�h
        // ===================================================================================== //
        #region ��Private Methods

        // --- DEL 2013/04/15 donggy for Redmine#35020 ---->>>>>>>>>
        #region DEL
        //// ADD 2013/03/13 �v�� Redmine#35020 No.1834 ---->>>>>>>>
        ///// <summary>
        ///// �S��UOE�������񌟍�����
        ///// </summary>
        //private void FindAllSupplierInfo()
        //{
        //    // �S��UOE��������Dictionary����������
        //    _allSupplierDic = new Dictionary<int, UOESupplier>();
        //    ArrayList supplierList = new ArrayList();

        //    // UOE ������}�X�^���̃��X�g���擾���܂��B
        //    _uOESupplierAcs.Search(out supplierList, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

        //    // UOE��������Dictionary�쐬
        //    // Dictionary�̐���
        //    //           KEY : UOESupplierCd
        //    //           VALUE : UOESupplier
        //    foreach (UOESupplier tempUOESupplier in supplierList)
        //    {
        //        if (!_allSupplierDic.ContainsKey(tempUOESupplier.UOESupplierCd))
        //        {
        //            _allSupplierDic.Add(tempUOESupplier.UOESupplierCd, tempUOESupplier);
        //        }
        //    }
        //}
        //// ADD 2013/03/13 �v�� Redmine#35020 No.1834 ----<<<<<<<<
        #endregion DEL
        // --- DEL 2013/04/15 donggy for Redmine#35020 ----<<<<<<<<
        /// <summary>
        /// ��������̓ǂݍ��݂Ə����ݒ菈��
        /// </summary>
        /// <param name="row"></param>
        /// <param name="supplierCd"></param>
        /// <param name="defaultSetting"></param>
        /// <br>Update Note  : 2013/04/15 donggy</br>
        /// <br>�Ǘ��ԍ�     : 10900691-00 2013/05/15�z�M��</br>
        /// <br>               Redmine#35020�@�������ρv�́u����������ʁv�̃��X�|���X�ቺ�̃g���K�[�̔r��</br>
        private void UOESupplierInfoReadAndSetting(DataRow row, int supplierCd, bool defaultSetting)
        {
            if (row != null)
            {
                UOESupplier uoeSupplier;
                // --- DEL 2013/04/15 donggy for  Redmine#35020 ---->>>>>>>>
                //// ADD 2013/03/13 �v�� Redmine#35020 No.1834 ---->>>>>>>>
                //if (null == _allSupplierDic)
                //{
                //    _allSupplierDic = new Dictionary<int, UOESupplier>();
                //}

                //// UOE������Dictionary����AUOE��������擾
                //if (_allSupplierDic.ContainsKey(supplierCd))
                //{
                //    uoeSupplier = _allSupplierDic[supplierCd];
                //}
                //else
                //{
                //    // UOE������Dictionary���Ȃ���΁A�Č����������s���܂�
                //    int status = this._uOESupplierAcs.Read(out uoeSupplier, this._enterpriseCode, supplierCd, LoginInfoAcquisition.Employee.BelongSectionCode);

                //    // �����悪���݂��Ȃ��ꍇ�A������UOESupplier�I�u�W�F�N�g
                //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        uoeSupplier = new UOESupplier();
                //    }

                //    // �����悪���݂���ꍇ�AUOE������Dictionary�ɒǉ����܂�
                //    if (!_allSupplierDic.ContainsKey(supplierCd))
                //    {
                //        _allSupplierDic.Add(supplierCd, uoeSupplier);
                //    }
                //}

                //this.UOESupplierInfoSetting(row, _allSupplierDic[supplierCd], true);
                //// ADD 2013/03/13 �v�� Redmine#35020 No.1834 ----<<<<<<<<
                // --- DEL 2013/04/15 donggy for  Redmine#35020 ----<<<<<<<<<


                /* DEL 2013/03/13 �v�� Redmine#35020 No.1834 ---->>>>>>>>
                int status = this._uOESupplierAcs.Read(out uoeSupplier, this._enterpriseCode, supplierCd, LoginInfoAcquisition.Employee.BelongSectionCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.UOESupplierInfoSetting(row, uoeSupplier, true);
                }
                else
                {
                        uoeSupplier = new UOESupplier();
                    }
                this.UOESupplierInfoSetting(row, uoeSupplier, true);
                // DEL 2013/03/13 �v�� Redmine#35020 No.1834 ----<<<<<<<<*/
                // --- ADD 2013/04/15 donggy for  Redmine#35020 ---->>>>>>>>
                int status = this._uOESupplierAcs.Read(out uoeSupplier, this._enterpriseCode, supplierCd, LoginInfoAcquisition.Employee.BelongSectionCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.UOESupplierInfoSetting(row, uoeSupplier, true);
                }
                else
                {
                    uoeSupplier = new UOESupplier();
                }
                this.UOESupplierInfoSetting(row, uoeSupplier, true);
                // --- ADD 2013/04/15 donggy for  Redmine#35020 ----<<<<<<<<<
            }
        }

        ///// <summary>
        ///// ��������̐ݒ�
        ///// </summary>
        ///// <param name="row"></param>
        ///// <param name="uoeSupplier"></param>
        //private void UOESupplierInfoSetting(DataRow row, UOESupplier uoeSupplier)
        //{
        //    if (row != null)
        //    {
        //        row[OrderSelectHdTable.ctColName_UOESupplier] = uoeSupplier;
        //    }
        //}
      
        /// <summary>
        /// ��������̏����l�ݒ菈��
        /// </summary>
        /// <param name="row">�f�[�^�s</param>
        /// <param name="uoeSupplier">�t�n�d������}�X�^</param>
        /// <param name="defaultSetting">True:�����l�ݒ�</param>
        private void UOESupplierInfoSetting(DataRow row, UOESupplier uoeSupplier, bool defaultSetting)
        {
            if (row != null)
            {
                row[OrderSelectHdTable.ctColName_UOESupplier] = uoeSupplier;
                if (defaultSetting)
                {
                    row[OrderSelectHdTable.ctColName_UOESupplierCd] = uoeSupplier.UOESupplierCd;
                    row[OrderSelectHdTable.ctColName_UOESupplierName] = uoeSupplier.UOESupplierName;

                    if ((Guid)row[OrderSelectHdTable.ctColName_OrderGuid] == Guid.Empty)
                    {
                        row[OrderSelectHdTable.ctColName_UoeRemark1] = this._estimateInputInitDataAcs.GetUOESetting().InpSearchRemark;
                        row[OrderSelectHdTable.ctColName_UoeRemark2] = string.Empty;

                        // �[�i�敪�̏����l�ݒ�
                        if (UOESupplierAcs.EnabledDeliveredGoodsDiv(uoeSupplier.CommAssemblyId))
                        {
                            string uoeGuideCode, uoeGuideName;
                            this._estimateInputInitDataAcs.GetMinElementFromUOEGuideName(EstimateInputInitDataAcs.ctUOEGuideDivCd_DeliveredGoodsDiv, uoeSupplier.UOESupplierCd, out uoeGuideCode, out uoeGuideName);
                            row[OrderSelectHdTable.ctColName_UOEDeliGoodsDiv] = uoeGuideCode;
                            row[OrderSelectHdTable.ctColName_DeliveredGoodsDivNm] = uoeGuideName;
                        }
                        else
                        {
                            row[OrderSelectHdTable.ctColName_UOEDeliGoodsDiv] = string.Empty;
                            row[OrderSelectHdTable.ctColName_DeliveredGoodsDivNm] = string.Empty;
                        }

                        // H�[�i�敪�̏����l�ݒ�
                        if (UOESupplierAcs.EnabledFollowDeliGoodsDiv(uoeSupplier.CommAssemblyId))
                        {
                            string uoeGuideCode, uoeGuideName;
                            this._estimateInputInitDataAcs.GetMinElementFromUOEGuideName(EstimateInputInitDataAcs.ctUOEGuideDivCd_DeliveredGoodsDiv, uoeSupplier.UOESupplierCd, out uoeGuideCode, out uoeGuideName);
                            row[OrderSelectHdTable.ctColName_FollowDeliGoodsDiv] = uoeGuideCode;
                            row[OrderSelectHdTable.ctColName_FollowDeliGoodsDivNm] = uoeGuideName;
                        }
                        else
                        {
                            row[OrderSelectHdTable.ctColName_FollowDeliGoodsDiv] = string.Empty;
                            row[OrderSelectHdTable.ctColName_FollowDeliGoodsDivNm] = string.Empty;
                        }

                        // �S�����_�̏����l�ݒ�
                        if (UOESupplierAcs.EnabledUOEResvdSection(uoeSupplier.CommAssemblyId))
                        {
                            string uoeGuideCode, uoeGuideName;
                            this._estimateInputInitDataAcs.GetMinElementFromUOEGuideName(EstimateInputInitDataAcs.ctUOEGuideDivCd_UOEResvdSection, uoeSupplier.UOESupplierCd, out uoeGuideCode, out uoeGuideName);
                            row[OrderSelectHdTable.ctColName_UOEResvdSection] = uoeGuideCode;
                            row[OrderSelectHdTable.ctColName_UOEResvdSectionNm] = uoeGuideName;
                        }
                        else
                        {
                            row[OrderSelectHdTable.ctColName_UOEResvdSection] = string.Empty;
                            row[OrderSelectHdTable.ctColName_UOEResvdSectionNm] = string.Empty;
                        }
                    }
                }
            }
        }

        #endregion

        // ===================================================================================== //
        // �����I��p�̃w�b�_�A���ׂ̃e�[�u���X�L�[�}��`
        // ===================================================================================== //
        #region �\���p�̃e�[�u���X�L�[�}��`�N���X

        /// <summary>
        /// �����I���̃w�b�_�p�̃e�[�u���X�L�[�}��`�N���X
        /// </summary>
        public class OrderSelectHdTable
        {
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public OrderSelectHdTable()
            {
            }

            /// <summary>�e�[�u������</summary>
            public const string ctTableName = "OrderSelectHdTable";
            /// <summary>�J�������i�����L���j</summary>
            public const string ctColName_ExistOrder = "ExistOrder";
            /// <summary>�J�������i�\���p�����L���j</summary>
            public const string ctColName_ExistOrderDisplay = "ExistOrderDisplay";
            /// <summary>�J�������i�d����R�[�h�j</summary>
            public const string ctColName_SupplierCd = "SupplierCd";
            /// <summary>�J�������i�d���旪�́j</summary>
            public const string ctColName_SupplierSnm = "SupplierSnm";
            /// <summary>�J�������i�t�n�d������j</summary>
            public const string ctColName_UOESupplierCd = "UOESupplierCd";
            /// <summary>�J�������i�t�n�d�����於�́j</summary>
            public const string ctColName_UOESupplierName = "UOESupplierName";
            /// <summary>�J�������i�t�n�d�d����j</summary>
            public const string ctColName_UOESupplier = "UOESupplier";
            /// <summary>�J�������i�t�n�d���}�[�N�P�j</summary>
            public const string ctColName_UoeRemark1 = "UoeRemark1";
            /// <summary>�J�������i�t�n�d���}�[�N�Q�j</summary>
            public const string ctColName_UoeRemark2 = "UoeRemark2";
            /// <summary>�J�������i�t�n�d�[�i�敪�j</summary>
            public const string ctColName_UOEDeliGoodsDiv = "UOEDeliGoodsDiv";
            /// <summary>�J�������i�t�n�d�[�i�敪���́j</summary>
            public const string ctColName_DeliveredGoodsDivNm = "DeliveredGoodsDivNm";
            /// <summary>�J�������i�t�H���[�[�i�敪�j</summary>
            public const string ctColName_FollowDeliGoodsDiv = "FollowDeliGoodsDiv";
            /// <summary>�J�������i�t�H���[�[�i�敪���́j</summary>
            public const string ctColName_FollowDeliGoodsDivNm = "FollowDeliGoodsDivNm";
            /// <summary>�J�������i�w�苒�_�j</summary>
            public const string ctColName_UOEResvdSection = "UOEResvdSection";
            /// <summary>�J�������i�w�苒�_���́j</summary>
            public const string ctColName_UOEResvdSectionNm = "UOEResvdSectionNm";

            /// <summary>�J�������i�����f�t�h�c�j</summary>
            public const string ctColName_OrderGuid = "OrderGuid";

            /// <summary>
            /// �e�[�u���𐶐����܂��B
            /// </summary>
            /// <param name="dt"></param>
            static public void CreateTable(ref DataTable dt)
            {
                if (dt == null)
                {
                    dt = new DataTable(ctTableName);
                }
                dt.Rows.Clear();

                // �J��������
                // �����L��
                dt.Columns.Add(ctColName_ExistOrder, typeof(bool));
                dt.Columns[ctColName_ExistOrder].DefaultValue = false;

                // �����L��(�\��)
                dt.Columns.Add(ctColName_ExistOrderDisplay, typeof(string));
                dt.Columns[ctColName_ExistOrderDisplay].DefaultValue = string.Empty;

                // �d����
                dt.Columns.Add(ctColName_SupplierCd, typeof(int));
                dt.Columns[ctColName_SupplierCd].DefaultValue = 0;

                // �d���旪��
                dt.Columns.Add(ctColName_SupplierSnm, typeof(string));
                dt.Columns[ctColName_SupplierSnm].DefaultValue = string.Empty;

                // ������R�[�h
                dt.Columns.Add(ctColName_UOESupplierCd, typeof(int));
                dt.Columns[ctColName_UOESupplierCd].DefaultValue = 0;

                // �����於��
                dt.Columns.Add(ctColName_UOESupplierName, typeof(string));
                dt.Columns[ctColName_UOESupplierName].DefaultValue = string.Empty;

                // ������}�X�^�I�u�W�F�N�g
                dt.Columns.Add(ctColName_UOESupplier, typeof(UOESupplier));
                dt.Columns[ctColName_UOESupplier].DefaultValue = new UOESupplier();

                // �t�n�d���}�[�N�P
                dt.Columns.Add(ctColName_UoeRemark1, typeof(string));
                dt.Columns[ctColName_UoeRemark1].DefaultValue = string.Empty;

                // �t�n�d���}�[�N�Q
                dt.Columns.Add(ctColName_UoeRemark2, typeof(string));
                dt.Columns[ctColName_UoeRemark2].DefaultValue = string.Empty;

                // �[�i�敪
                dt.Columns.Add(ctColName_UOEDeliGoodsDiv, typeof(string));
                dt.Columns[ctColName_UOEDeliGoodsDiv].DefaultValue = string.Empty;

                // �[�i�敪����
                dt.Columns.Add(ctColName_DeliveredGoodsDivNm, typeof(string));
                dt.Columns[ctColName_DeliveredGoodsDivNm].DefaultValue = string.Empty;

                // �t�H���[�[�i�敪
                dt.Columns.Add(ctColName_FollowDeliGoodsDiv, typeof(string));
                dt.Columns[ctColName_FollowDeliGoodsDiv].DefaultValue = string.Empty;

                // �t�H���[�[�i�敪����
                dt.Columns.Add(ctColName_FollowDeliGoodsDivNm, typeof(string));
                dt.Columns[ctColName_FollowDeliGoodsDivNm].DefaultValue = string.Empty;

                // UOE�w�苒�_
                dt.Columns.Add(ctColName_UOEResvdSection, typeof(string));
                dt.Columns[ctColName_UOEResvdSection].DefaultValue = string.Empty;

                // UOE�w�苒�_����
                dt.Columns.Add(ctColName_UOEResvdSectionNm, typeof(string));
                dt.Columns[ctColName_UOEResvdSectionNm].DefaultValue = string.Empty;


                dt.Columns.Add(ctColName_OrderGuid, typeof(Guid));
                dt.Columns[ctColName_OrderGuid].DefaultValue = Guid.Empty;

                dt.PrimaryKey = new DataColumn[] { dt.Columns[ctColName_SupplierCd] };
            }
        }

        /// <summary>
        /// �����I���̖��חp�̃e�[�u���X�L�[�}��`�N���X
        /// </summary>
        /// <br>Update Note: 2013/03/08 杍^</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A2013/03/13�z�M��</br>
        /// <br>             Redmine#34994 �D�ǔ�����̏ꍇ�ɂa�n�敪����͂���ƁA���������f�t�H���g�\�����Ȃ��A�O�ŕ\�������̑Ή�</br>
        /// <remarks></remarks>
        public class OrderSelectDtlTable
        {
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public OrderSelectDtlTable()
            {
            }

            /// <summary>�����I�𖾍חp�e�[�u������</summary>
            public const string ctTableName = "OrderSelectDtlTable";

            /// <summary>�J�������iNo.�j</summary>
            public const string ctColName_No = "No";

            /// <summary>�J�������i���טA���f�t�h�c�j</summary>
            public const string ctColName_DtlRelationGuid = "DtlRelationGuid";
            /// <summary>�J�������i�d����R�[�h�j</summary>
            public const string ctColName_SupplierCd = "SupplierCd";
            /// <summary>�J�������i�a�n�R�[�h�j</summary>
            public const string ctColName_BOCode = "BOCode";
            /// <summary>�J�������i�������j</summary>
            public const string ctColName_OrderCnt = "OrderCnt";
            /// <summary>�J�������i�o�א��j</summary>
            public const string ctColName_ShipmentCnt = "ShipmentCnt";
            /// <summary>�J�������i�i���j</summary>
            public const string ctColName_GoodsName = "GoodsNo";
            /// <summary>�J�������i�i�ԁj</summary>
            public const string ctColName_GoodsNo = "GoodsName";
            /// <summary>�J�������i���[�J�[�R�[�h�j</summary>
            public const string ctColName_GoodsMakerCd = "GoodsMakerCd";
            /// <summary>�J�������i�q�ɃR�[�h�j</summary>
            public const string ctColName_WarehouseCode = "WarehouseCode";
            /// <summary>�J�������i���݌ɐ��j</summary>
            public const string ctColName_ShipmentPosCnt = "ShipmentPosCnt";

            /// <summary>
            /// �e�[�u���𐶐����܂��B
            /// </summary>
            /// <param name="dt"></param>
            static public void CreateTable(ref DataTable dt)
            {
                if (dt == null)
                {
                    dt = new DataTable(ctTableName);
                }

                dt.Rows.Clear();

                // �J��������
                // ���טA��Guid
                dt.Columns.Add(ctColName_DtlRelationGuid, typeof(Guid));
                dt.Columns[ctColName_DtlRelationGuid].DefaultValue = Guid.Empty;

                // ��
                dt.Columns.Add(ctColName_No, typeof(int));
                dt.Columns[ctColName_No].DefaultValue = 0;

                // �d����
                dt.Columns.Add(ctColName_SupplierCd, typeof(int));
                dt.Columns[ctColName_SupplierCd].DefaultValue = 0;

                // BO
                dt.Columns.Add(ctColName_BOCode, typeof(string));
                dt.Columns[ctColName_BOCode].DefaultValue = string.Empty;

                // ������
                dt.Columns.Add(ctColName_OrderCnt, typeof(int));
                dt.Columns[ctColName_OrderCnt].DefaultValue = 0;

                // QTY
                dt.Columns.Add(ctColName_ShipmentCnt, typeof(double));
                dt.Columns[ctColName_ShipmentCnt].DefaultValue = 0;

                // �i��
                dt.Columns.Add(ctColName_GoodsName, typeof(string));
                dt.Columns[ctColName_GoodsName].DefaultValue = string.Empty;

                // �i��
                dt.Columns.Add(ctColName_GoodsNo, typeof(string));
                dt.Columns[ctColName_GoodsNo].DefaultValue = string.Empty;

                // ���[�J�[�R�[�h
                dt.Columns.Add(ctColName_GoodsMakerCd, typeof(int));
                dt.Columns[ctColName_GoodsMakerCd].DefaultValue = 0;

                // �q��
                dt.Columns.Add(ctColName_WarehouseCode, typeof(string));
                dt.Columns[ctColName_WarehouseCode].DefaultValue = string.Empty;

                // ���݌ɐ�
                // DEL 2013/03/08 tanh Redmine#34994 ---- >>>>>
                //dt.Columns.Add(ctColName_ShipmentPosCnt, typeof(double));
                //dt.Columns[ctColName_ShipmentPosCnt].DefaultValue = 0;
                // DEL 2013/03/08 tanh Redmine#34994 ---- <<<<<

                // ADD 2013/03/08 tanh Redmine#34994 ---- >>>>>
                dt.Columns.Add(ctColName_ShipmentPosCnt, typeof(string));
                dt.Columns[ctColName_ShipmentPosCnt].DefaultValue = string.Empty;
                // ADD 2013/03/08 tanh Redmine#34994 ---- <<<<<

                dt.PrimaryKey = new DataColumn[] { dt.Columns[ctColName_DtlRelationGuid] };
            }
        }

        #endregion

    }
}
