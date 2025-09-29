//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �݌Ɉړ��d�q����
// �v���O�����T�v   : �݌Ɉړ��d�q�����f�[�^�擾�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj
// �� �� ��  2011/04/06  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : tianjw
// �� �� ��  2011/05/11  �C�����e : redmine #20913
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��r��
// �� �� ��  2011/05/20  �C�����e : redmine #21657
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �݌Ɉړ��d�q�����f�[�^�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɉړ��d�q�����̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br>Update Note: 2011/05/11 tianjw</br>
    /// <br>             redmine #20913</br>
    /// </remarks>
    public partial class StockMoveSlipSearchAcs
    {
        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public StockMoveSlipSearchAcs()
        {
            // �����[�g�C���X�^���X�擾
            this._iStockMoveWorkDB = MediationStockMoveWorkDB.GetStockMoveWorkDB();

            // �f�[�^�Z�b�g���쐬
            this._dataSet = new StockMoveDetailDataSet();
        }

        #endregion // �R���X�g���N�^

        #region �v���C�x�[�g�ϐ�

        // �����[�gDB�����N���X �C���^�t�F�[�X�I�u�W�F�N�g
        private IStockMoveWorkDB _iStockMoveWorkDB;

        // �f�[�^�Z�b�g�N���X
        private StockMoveDetailDataSet _dataSet;

        // ���o���f�t���O
        private bool _extractCancelFlag;

        // �o��/�o�� ���v����
        private double _totalMoveCountOut = 0;
        // �o��/�o�� ���v���z
        private double _totalStockMovePriceOut = 0;
        // �o��/�o�� ���v�W�����i
        private double _totalListPriceFlOut = 0;
        // ���׍�/���� ���v����
        private double _totalMoveCountIn = 0;
        // ���׍�/���� ���v���z
        private double _totalStockMovePriceIn = 0;
        // ���׍�/���� ���v�W�����i
        private double _totalListPriceFlIn = 0;
        // ������ ���v����
        private double _totalMoveCount = 0;
        // ������ ���v���z
        private double _totalStockMovePrice = 0;
        // ������ ���v�W�����i
        private double _totalListPriceFl = 0;
        // �`�[����
        private int _totalSaleslipCnt = 0;
        // ���א�
        private int _totalCnt = 0;
        // �݌Ɉړ��m��敪

        #endregion // �v���C�x�[�g�ϐ�

        #region �v���p�e�B
        /// <summary>
        /// �f�[�^�Z�b�g�I�u�W�F�N�g 
        /// </summary>
        public StockMoveDetailDataSet DataSet
        {
            get { return this._dataSet; }
        }

        /// <summary>
        /// ���o���f�t���O
        /// </summary>
        public bool ExtractCancelFlag
        {
            get { return _extractCancelFlag; }
            set { _extractCancelFlag = value; }
        }

        /// <summary>
        /// �o��/�o�� ���v����
        /// </summary>
        public double TotalMoveCounIn
        {
            get { return _totalMoveCountOut; }
            set { _totalMoveCountOut = value; }
        }

        /// <summary>
        /// �o��/�o�� ���v���z
        /// </summary>
        public double TotalStockMovePriceIn
        {
            get { return _totalStockMovePriceOut; }
            set { _totalStockMovePriceOut = value; }
        }

        /// <summary>
        /// �o��/�o�� ���v�W�����i
        /// </summary>
        public double TotalListPriceFlIn
        {
            get { return _totalListPriceFlOut; }
            set { _totalListPriceFlOut = value; }
        }

        /// <summary>
        /// ���׍�/���� ���v����
        /// </summary>
        public double TotalMoveCounOut
        {
            get { return _totalMoveCountIn; }
            set { _totalMoveCountIn = value; }
        }

        /// <summary>
        /// ���׍�/���� ���v���z
        /// </summary>
        public double TotalStockMovePriceOut
        {
            get { return _totalStockMovePriceIn; }
            set { _totalStockMovePriceIn = value; }
        }

        /// <summary>
        /// ���׍�/���� ���v�W�����i
        /// </summary>
        public double TotalListPriceFlOut
        {
            get { return _totalListPriceFlIn; }
            set { _totalListPriceFlIn = value; }
        }

        /// <summary>
        /// ������ ���v����
        /// </summary>
        public double TotalMoveCoun
        {
            get { return _totalMoveCount; }
            set { _totalMoveCount = value; }
        }

        /// <summary>
        /// ������ ���v���z
        /// </summary>
        public double TotalStockMovePrice
        {
            get { return _totalStockMovePrice; }
            set { _totalStockMovePrice = value; }
        }

        /// <summary>
        /// ������ ���v�W�����i
        /// </summary>
        public double TotalListPriceFl
        {
            get { return _totalListPriceFl; }
            set { _totalListPriceFl = value; }
        }

        /// <summary>
        /// �`�[����
        /// </summary>
        public int TotalSaleslipCnt
        {
            get { return _totalSaleslipCnt; }
            set { _totalSaleslipCnt = value; }
        }

        /// <summary>
        /// ���א�
        /// </summary>
        public int TotalCnt
        {
            get { return _totalCnt; }
            set { _totalCnt = value; }
        }

        #endregion // �v���p�e�B

        #region delegate
        /// <summary>
        /// UpdateSectionEventHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="sectionCode"></param>
        /// <param name="sectionName"></param>
        public delegate void UpdateSectionEventHandler( object sender, string sectionCode, string sectionName );
        #endregion // delegate

        #region Search
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="stockMovePpr">���������N���X</param>
        /// <param name="logicalDelDiv">�폜�w��敪�F0=�W��,1=�폜���̂�</param>
        /// <param name="counter">���׌���</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���������B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/11 tianjw</br>
        /// <br>             redmine #20913</br>
        /// <br>Update Note: 2011/05/20 ��r�� �d����Ǝd���於��ǉ����܂�</br>
        /// <br></br>
        /// </remarks>
        public int Search( StockMovePpr stockMovePpr, int logicalDelDiv, out long counter )
        {
            int status;

            // �p�����[�^�N���X���쐬
            StockMovePrtWork stockMovePrtWork = new StockMovePrtWork();
            StockMovePprStockMovePprWork(ref stockMovePpr, ref stockMovePrtWork);
            object stockMovePrtWorkObj = new object();
            //---------------------------------
            // �Ԃ�l�Ŏg�p����N���X���쐬
            //---------------------------------
            counter = 0;
 
            if ( _extractCancelFlag == true ) return 0;

            if ( logicalDelDiv == 0 )
            {
                // �폜�����܂܂Ȃ��ꍇ��GetData0���w��(�폜�t���O=0�̃f�[�^��Ԃ�)
                status = this._iStockMoveWorkDB.SearchRef(ref stockMovePrtWorkObj, (object)stockMovePrtWork, out counter, 0, ConstantManagement.LogicalMode.GetData0);
            }
            else
            {
                // �폜�ς݂̏ꍇ��GetData1���w��(�폜�t���O=1�̃f�[�^��Ԃ�)
                status = this._iStockMoveWorkDB.SearchRef(ref stockMovePrtWorkObj, (object)stockMovePrtWork, out counter, 0, ConstantManagement.LogicalMode.GetData1);
            }
            if ( _extractCancelFlag == true ) return 0;
            // ��������readMode�͌��ݎg�p���Ă��Ȃ��̂łǂ�Ȓl�����Ă����Ȃ�

            if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
            {
                this._totalMoveCountIn = 0;
                this._totalStockMovePriceIn = 0;
                this._totalListPriceFlIn = 0;
                this._totalMoveCountOut = 0;
                this._totalStockMovePriceOut = 0;
                this._totalListPriceFlOut = 0;
                this._totalMoveCount = 0;
                this._totalStockMovePrice = 0;
                this._totalListPriceFl = 0;
                this._totalSaleslipCnt = 0;
                this._totalCnt = 0;

                DataRow row2;

                int rowNo = 1;
                if (counter > 0)
                {
                    int lastIndex = 0;

                    int maxCount = (stockMovePrtWorkObj as ArrayList).Count;
                    if (maxCount > stockMovePpr.SearchCnt - 1)
                    {
                        // �����[�g����͍ő��20,001���Ԃ��Ă���̂ŁA20,000���܂łɂ���
                        maxCount = (int)stockMovePpr.SearchCnt - 1;
                    }
                    DataRow row;

                    ArrayList keyList = new ArrayList();

                    for (int index = 0; index < maxCount; index++)
                    {
                        lastIndex = index;
                        StockMoveWork data = (StockMoveWork)((stockMovePrtWorkObj as ArrayList)[index]);

                        string key = data.StockMoveFormal.ToString() + data.StockMoveSlipNo.ToString();
                        string saleSlipNum = data.StockMoveSlipNo.ToString().PadLeft(9, '0');
                        if (keyList == null || keyList.Count == 0)
                        {
                            keyList.Add(key);
                            this._totalSaleslipCnt++;
                        }
                        else
                        {
                            if (!keyList.Contains(key))
                            {
                                this._totalSaleslipCnt++;
                                keyList.Add(key);
                            }
                        }

                        row = this._dataSet.StockMoveDetail.NewRow();

                        try
                        {
                            if (stockMovePrtWork.StockMoveFixCode == 1) // �݌Ɉړ��m��敪�����׊m�肠��
                            {
                                // �o�͋敪���u���׍ϕ��v�u�����ו��v�ŕ\������Ƃ��͔�\��
                                if (stockMovePpr.OutputDiv == 1 || stockMovePpr.OutputDiv == 2)
                                {
                                    row[_dataSet.StockMoveDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StockMoveDetail.SelectionCheckColumn.ColumnName] = false;
                                }
                            }
                            else if (stockMovePrtWork.StockMoveFixCode == 2) // �݌Ɉړ��m��敪�����׊m��Ȃ�
                            {
                                // ���Ƀf�[�^�i�݌Ɉړ��`��=3,4�j
                                if (data.StockMoveFormal == 3
                                    || data.StockMoveFormal == 4)
                                {
                                    row[_dataSet.StockMoveDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StockMoveDetail.SelectionCheckColumn.ColumnName] = false;
                                }
                            }

                            //row[_dataSet.StockMoveDetail.SelectionCheckColumn.ColumnName] = false;
                            // 1�F���׊m�肠��
                            if (stockMovePrtWork.StockMoveFixCode == 1)
                            {
                                //�o�͋敪�����׍�
                                if (stockMovePrtWork.OutputDiv == 1)
                                {
                                    row[_dataSet.StockMoveDetail.DateColumn.ColumnName] = data.ArrivalGoodsDay;// ���ד�

                                    this._totalMoveCountIn += data.MoveCount;
                                    this._totalStockMovePriceIn += data.StockMovePrice;
                                    this._totalListPriceFlIn += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);
                                }
                                //�o�͋敪���o�ו�
                                else if (stockMovePrtWork.OutputDiv == 0)
                                {
                                    row[_dataSet.StockMoveDetail.DateColumn.ColumnName] = data.ShipmentFixDay;//�o�׊m���
                                    this._totalMoveCountOut += data.MoveCount;
                                    this._totalStockMovePriceOut += data.StockMovePrice;
                                    this._totalListPriceFlOut += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);

                                }
                                //�o�͋敪�������ו�
                                else
                                {
                                    row[_dataSet.StockMoveDetail.DateColumn.ColumnName] = data.ShipmentFixDay;//�o�׊m���
                                    this._totalMoveCount += data.MoveCount;
                                    this._totalStockMovePrice += data.StockMovePrice;
                                    this._totalListPriceFl += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);
                                }
                            }
                            //�Q�F���׊m��Ȃ� 
                            else
                            {
                                row[_dataSet.StockMoveDetail.DateColumn.ColumnName] = data.ArrivalGoodsDay;// ���ד�
                                if (stockMovePrtWork.SalesSlipDiv == 0)
                                {
                                    if (data.StockMoveFormal == 1 || data.StockMoveFormal == 2)
                                    {
                                        this._totalMoveCountOut += data.MoveCount;
                                        this._totalStockMovePriceOut += data.StockMovePrice;
                                        this._totalListPriceFlOut += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);
                                    }
                                    else
                                    {
                                        this._totalMoveCountIn += data.MoveCount;
                                        this._totalStockMovePriceIn += data.StockMovePrice;
                                        this._totalListPriceFlIn += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);
                                    }
                                }
                                else if (stockMovePrtWork.SalesSlipDiv == 1)
                                {
                                    this._totalMoveCountOut += data.MoveCount;
                                    this._totalStockMovePriceOut += data.StockMovePrice;
                                    this._totalListPriceFlOut += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);
                                }
                                else
                                {
                                    this._totalMoveCountIn += data.MoveCount;
                                    this._totalStockMovePriceIn += data.StockMovePrice;
                                    this._totalListPriceFlIn += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);
                                }
                            }

                            row[_dataSet.StockMoveDetail.RowNoColumn.ColumnName] = rowNo;//�s�ԍ�

                            row[_dataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName] = saleSlipNum;//�݌Ɉړ��`�[�ԍ�

                            row[_dataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName] = data.StockMoveRowNo;//�݌Ɉړ��s�ԍ�

                            row[_dataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName] = data.StockMoveFormal; // �敪�R�[�h

                            //�敪�\��
                            if (data.StockMoveFormal == 1 || data.StockMoveFormal == 2)
                            {
                                row[_dataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName] = "�o��";
                            }
                            else if (data.StockMoveFormal == 3 || data.StockMoveFormal == 4)
                            {
                                row[_dataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName] = "����";
                            }

                            // �S���Җ�
                            //�o�͋敪�����׍�
                            if (stockMovePrtWork.OutputDiv == 1)
                            {
                                row[_dataSet.StockMoveDetail.AgentNmColumn.ColumnName] = data.ReceiveAgentNm;// ����S���]�ƈ�����
                            }
                            else
                            {
                                row[_dataSet.StockMoveDetail.AgentNmColumn.ColumnName] = data.StockMvEmpName;// �݌Ɉړ����͏]�ƈ�����
                            }

                            //�i��
                            row[_dataSet.StockMoveDetail.GoodsNameColumn.ColumnName] = data.GoodsName;// �i��

                            //�i��
                            row[_dataSet.StockMoveDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;//�i��

                            // ���[�J�[�R�[�h
                            row[_dataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName] = data.GoodsMakerCd.ToString().PadLeft(4, '0'); ;// ���[�J�[�R�[�h
                            // ���[�J�[��
                            row[_dataSet.StockMoveDetail.MakerNameColumn.ColumnName] = data.MakerName;// ���[�J�[��
                            // ADD 2011/05/20 -------------------------->>>>>>
                            // �d����R�[�h
                            row[_dataSet.StockMoveDetail.SupplierCdColumn.ColumnName] = data.SupplierCd.ToString().PadLeft(6, '0'); ;// ���[�J�[�R�[�h
                            // �d����[��
                            row[_dataSet.StockMoveDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;// ���[�J�[��
                            // ADD 2011/05/20 --------------------------<<<<<<
                            // BL����
                            row[_dataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft(5, '0'); ;
                            // �ړ��P��
                            row[_dataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName] = data.StockUnitPriceFl;
                            // ����
                            row[_dataSet.StockMoveDetail.MoveCounColumn.ColumnName] = data.MoveCount;
                            // �W�����i
                            row[_dataSet.StockMoveDetail.ListPriceFlColumn.ColumnName] = data.ListPriceFl;
                            // �ړ����z
                            row[_dataSet.StockMoveDetail.StockMovePriceColumn.ColumnName] = data.StockMovePrice;
                            // ���͋��_�R�[�h
                            row[_dataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName] = data.UpdateSecCd.PadLeft(2, '0');
                            // ���͋��_��
                            row[_dataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName] = data.UpdateSecNm;
                            // �o�ɋ��_�R�[�h
                            row[_dataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName] = data.BfSectionCode.PadLeft(2, '0');
                            // �o�ɋ��_��
                            row[_dataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName] = data.BfSectionGuideSnm;
                            // �o�ɑq��
                            row[_dataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName] = data.BfEnterWarehCode.PadLeft(4, '0');
                            // �o�ɑq�ɖ�
                            row[_dataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName] = data.BfEnterWarehName;
                            // �o�ɒI��
                            row[_dataSet.StockMoveDetail.BfShelfNoColumn.ColumnName] = data.BfShelfNo;
                            // ���ɋ��_�R�[�h
                            row[_dataSet.StockMoveDetail.AfSectionCodColumn.ColumnName] = data.AfSectionCode.PadLeft(2, '0');
                            // ���ɋ��_��
                            row[_dataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName] = data.AfSectionGuideSnm;
                            // ���ɑq��
                            row[_dataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName] = data.AfEnterWarehCode.PadLeft(4, '0');
                            // ���ɑq�ɖ�
                            row[_dataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName] = data.AfEnterWarehName;
                            // ���ɒI��
                            row[_dataSet.StockMoveDetail.AfShelfNoColumn.ColumnName] = data.AfShelfNo;
                            // ���׋敪
                            if (data.MoveStatus == 9)
                            {
                                row[_dataSet.StockMoveDetail.MoveStatusColumn.ColumnName] = "���׍�";
                            }
                            else
                            {
                                row[_dataSet.StockMoveDetail.MoveStatusColumn.ColumnName] = "������";
                            }
                            // �o�ד�
                            // ----- UPD 2011/05/11 tianjw --------------------------------------------------->>>>>
                            //row[_dataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName] = data.ShipmentFixDay;
                            if (data.ShipmentFixDay == DateTime.MinValue)
                            {
                                row[_dataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName] = DBNull.Value;
                            }
                            else
                            {
                                row[_dataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName] = data.ShipmentFixDay;
                            }
                            // ���ד�
                            //row[_dataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName] = data.ArrivalGoodsDay;
                            if (data.ArrivalGoodsDay == DateTime.MinValue)
                            {
                                row[_dataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName] = DBNull.Value;
                            }
                            else
                            {
                                row[_dataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName] = data.ArrivalGoodsDay;
                            }
                            // ----- UPD 2011/05/11 tianjw ---------------------------------------------------<<<<<
                            // ���͓�
                            row[_dataSet.StockMoveDetail.InputDayColumn.ColumnName] = data.InputDay;
                            // ���l
                            row[_dataSet.StockMoveDetail.WarehouseNote1Column.ColumnName] = data.WarehouseNote1;

                            this._dataSet.StockMoveDetail.Rows.Add(row);
                            _totalCnt++;
                            rowNo++;

                            if (_extractCancelFlag == true)
                            {
                                break;
                            }
                        }
                        catch (ConstraintException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    // �����[���Ȃ�΃����[�gstatus��0:����ł��Y���Ȃ��ŕԂ�
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                // ���v�\����
                row2 = this._dataSet.StockMoveTotal.NewRow();
                // �o��/�o�� ���v����
                row2[this._dataSet.StockMoveTotal.ShipmentCount_TotalColumn.ColumnName] = _totalMoveCountOut;
                // �o��/�o�� ���v���z
                row2[this._dataSet.StockMoveTotal.ShipmentPrice_TotalColumn.ColumnName] = _totalStockMovePriceOut;
                // �o��/�o�� ���v�W�����i
                row2[this._dataSet.StockMoveTotal.ShipmentListPriceFl_TotalColumn] = _totalListPriceFlOut;
                // ���׍�/���� ���v����
                row2[this._dataSet.StockMoveTotal.ArrivalCount_TotalColumn.ColumnName] = _totalMoveCountIn;
                // ���׍�/���� ���v���z
                row2[this._dataSet.StockMoveTotal.ArrivalPrice_TotalColumn.ColumnName] = _totalStockMovePriceIn;
                // ���׍�/���� ���v�W�����i
                row2[this._dataSet.StockMoveTotal.ArrivalListPriceFl_TotalColumn.ColumnName] = _totalListPriceFlIn;
                // ������ ���v����
                row2[this._dataSet.StockMoveTotal.NotArrivalCount_TotalColumn.ColumnName] = _totalMoveCount;
                // ������ ���v���z
                row2[this._dataSet.StockMoveTotal.NotArrivalPrice_TotalColumn.ColumnName] = _totalStockMovePrice;
                // ������ ���v�W�����i
                row2[this._dataSet.StockMoveTotal.NotArrivalListPriceFl_TotalColumn.ColumnName] = _totalListPriceFl;
                // �`�[����
                row2[this._dataSet.StockMoveTotal.SlipCountColumn.ColumnName] = _totalSaleslipCnt;
                // ���א�
                row2[this._dataSet.StockMoveTotal.DetailCountColumn.ColumnName] = _totalCnt;

                this._dataSet.StockMoveTotal.Rows.Add(row2);
            }
            return status;
        }
        #endregion // Search

        #region StockMovePprStockMovePprWork
        /// <summary>
        /// �p�����[�^�N���X(PMZAI04602E.StockMovePpr)���烊���[�g�p�����[�^�N���X(PMKAU04016D.StockMovePrtWork)�N���X�֕ϊ�
        /// </summary>
        /// <param name="stockMovePpr"></param>
        /// <param name="stockMovePrtWork"></param>
        /// <remarks>
        /// <br>Note       : �ϊ������B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void StockMovePprStockMovePprWork(ref StockMovePpr stockMovePpr, ref StockMovePrtWork stockMovePrtWork)
        {
            stockMovePrtWork.SearchCnt = stockMovePpr.SearchCnt;
            stockMovePrtWork.EnterpriseCode = stockMovePpr.EnterpriseCode;
            stockMovePrtWork.OutputDiv = stockMovePpr.OutputDiv;
            stockMovePrtWork.InputSectionCode = stockMovePpr.InputSectionCode;
            stockMovePrtWork.SectionCode = stockMovePpr.SectionCode;
            stockMovePrtWork.WarehouseCode = stockMovePpr.WarehouseCode;
            stockMovePrtWork.St_Date = stockMovePpr.St_Date;
            stockMovePrtWork.Ed_Date = stockMovePpr.Ed_Date;
            stockMovePrtWork.SalesSlipNum = stockMovePpr.SalesSlipNum;
            stockMovePrtWork.St_AddUpADate = stockMovePpr.St_AddUpADate;
            stockMovePrtWork.Ed_AddUpADate = stockMovePpr.Ed_AddUpADate;
            stockMovePrtWork.SalesEmployeeCd = stockMovePpr.SalesEmployeeCd;
            stockMovePrtWork.SupplierCd = stockMovePpr.SupplierCd;
            stockMovePrtWork.GoodsMakerCd = stockMovePpr.GoodsMakerCd;
            stockMovePrtWork.BLGoodsCode = stockMovePpr.BLGoodsCode;
            stockMovePrtWork.GoodsNo = stockMovePpr.GoodsNo;
            stockMovePrtWork.GoodsName = stockMovePpr.GoodsName;
            stockMovePrtWork.WarehouseShelfNo = stockMovePpr.WarehouseShelfNo;
            stockMovePrtWork.AfSectionCode = stockMovePpr.AfSectionCode;
            stockMovePrtWork.AfEnterWarehCode = stockMovePpr.AfEnterWarehCode;
            stockMovePrtWork.ArrivalGoodsFlag = stockMovePpr.ArrivalGoodsFlag;
            stockMovePrtWork.SlipNote = stockMovePpr.SlipNote;
            stockMovePrtWork.DeleteFlag = stockMovePpr.DeleteFlag;
            stockMovePrtWork.StockMoveFixCode = stockMovePpr.StockMoveFixCode;
            stockMovePrtWork.SalesSlipDiv = stockMovePpr.SalesSlipDiv;
        }
        #endregion // StockMovePprStockMovePprWork
    }
}
