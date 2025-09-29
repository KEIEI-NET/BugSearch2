using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.LocalAccess;

using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.InteropServices;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�A�N�Z�X�N���X(���i���)�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2008.06.18</br>
    /// <br>Update Note: 2009/02/03 30414 �E �K�j ��QID:10848�Ή�</br>
    /// <br>Update Note: 2009/03/17 30414 �E �K�j ��QID:12473�Ή�</br>
    /// <br>Update Note: 2012/12/06 �c����</br>
    /// <br>�Ǘ��ԍ�   : 2013/01/16�z�M��</br>
    /// <br>             Redmine#33663��#4 �|���P�i�����y�d���P���z���ݒ肳�ꂽ�ꍇ�A�|���f�[�^�d���P���̎Q�ƕ\���s���̑Ή�</br>
    /// <br>Update Note: 2013/02/08 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/26�z�M��</br>
    /// <br>             Redmine#34640 ���i�݌Ƀ}�X�^�̎d�l�ύX(#33231�̎c����)</br>
    /// </remarks>
    public partial class GoodsAcs
    {
        /// <summary>
        /// ���i���L���b�V������
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        public void CacheGoodsPrice(GoodsUnitData goodsUnitData)
        {
            int rowNo = 1;
            _goodsPriceDataTable.Clear();
            List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;
            goodsPriceList.Sort(); // ���[�J�[(�~��)�E�i��(�~��)�E���i�J�n��(����)
            foreach (GoodsPrice goodsPrice in goodsPriceList)
            {
                this.CacheGoodsPrice(rowNo, goodsPrice, _goodsPriceDataTable, goodsUnitData);
                rowNo++;
            }

            while (true)
            {
                if (rowNo > ctGoodsPriceMaxCount) break;

                GoodsPrice goodsPrice = new GoodsPrice();
                this.AddGoodsPriceEmptyRow(rowNo, goodsPrice, _goodsPriceDataTable);
                rowNo++;
            }
        }

        /// <summary>
        /// ���i���L���b�V������
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="goodsPrice"></param>
        /// <param name="goodsPriceDataTable"></param>
        /// <param name="goodsUnitData"></param>
        private void CacheGoodsPrice(int rowNo, GoodsPrice goodsPrice, GoodsInputDataSet.GoodsPriceDataTable goodsPriceDataTable, GoodsUnitData goodsUnitData)
        {
            try
            {
                goodsPriceDataTable.AddGoodsPriceRow(this.CreateRowFromUIData(rowNo, goodsPrice, goodsPriceDataTable, goodsUnitData));
            }
            catch (ConstraintException)
            {
                DataRow[] rows = _goodsPriceDataTable.Select(string.Format("{0}={1} and {2}={3} and {4}={5}",
                    this.GoodsPriceDataTable.GoodsMakerCdColumn, goodsPrice.GoodsMakerCd,
                    this.GoodsPriceDataTable.GoodsNoColumn, goodsPrice.GoodsNo,
                    this.GoodsPriceDataTable.PriceStartDateColumn, goodsPrice.PriceStartDate));

                GoodsInputDataSet.GoodsPriceRow goodsPriceRow = (GoodsInputDataSet.GoodsPriceRow)rows[0];
                this.SetGoodsPriceRowFromUIData(ref goodsPriceRow, goodsPrice, goodsUnitData);
            }
        }

        /// <summary>
        /// ���i����s�ǉ�����
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="goodsPrice"></param>
        /// <param name="goodsPriceDataTable"></param>
        public void AddGoodsPriceEmptyRow(int rowNo, GoodsPrice goodsPrice, GoodsInputDataSet.GoodsPriceDataTable goodsPriceDataTable)
        {
            goodsPriceDataTable.AddGoodsPriceRow(this.CreateRowFromUIData(rowNo, goodsPrice, goodsPriceDataTable, null));
        }

        /// <summary>
        /// ���i���f�[�^�e�[�u��������
        /// </summary>
        public void ClearGoodsPriceDataTable()
        {
            this.ClearGoodsPriceDataTable(ref _goodsPriceDataTable);
        }

        /// <summary>
        /// ���i���f�[�^�e�[�u��������
        /// </summary>
        /// <param name="goodsPriceDataTable"></param>
        private void ClearGoodsPriceDataTable(ref GoodsInputDataSet.GoodsPriceDataTable goodsPriceDataTable)
        {
            goodsPriceDataTable.Clear();
            for (int i = 1; i <= GoodsAcs.ctGoodsPriceMaxCount; i++)
            {
                GoodsPrice goodsPrice = new GoodsPrice();
                this.AddGoodsPriceEmptyRow(i, goodsPrice, goodsPriceDataTable);
            }
        }

        /// <summary>
        /// ���i���f�[�^�s�I�u�W�F�N�g��������
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="goodsPrice"></param>
        /// <param name="goodsPriceDataTable"></param>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        private GoodsInputDataSet.GoodsPriceRow CreateRowFromUIData(int rowNo, GoodsPrice goodsPrice, GoodsInputDataSet.GoodsPriceDataTable goodsPriceDataTable, GoodsUnitData goodsUnitData)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = goodsPriceDataTable.NewGoodsPriceRow();
            goodsPriceRow.FileHeaderGuid = Guid.Empty;
            this.SetGoodsPriceRowFromUIData(ref goodsPriceRow, goodsPrice, goodsUnitData);
            goodsPriceRow.RowNo = rowNo;
            return goodsPriceRow;
        }

        /// <summary>
        /// ���i���f�[�^�s�I�u�W�F�N�g�ݒ菈��
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        /// <param name="goodsPrice"></param>
        /// <param name="goodsUnitData"></param>
        /// <remarks>
        /// <br>Update Note: 2013/02/08 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/26�z�M��</br>
        /// <br>             Redmine#34640 ���i�݌Ƀ}�X�^�̎d�l�ύX(#33231�̎c����)</br>
        /// </remarks>
        private void SetGoodsPriceRowFromUIData(ref GoodsInputDataSet.GoodsPriceRow goodsPriceRow, GoodsPrice goodsPrice, GoodsUnitData goodsUnitData)
        {
            goodsPriceRow.CreateDateTime = goodsPrice.CreateDateTime; // �쐬����
            goodsPriceRow.UpdateDateTime = goodsPrice.UpdateDateTime; // �X�V����
            goodsPriceRow.EnterpriseCode = goodsPrice.EnterpriseCode; // ��ƃR�[�h
            goodsPriceRow.FileHeaderGuid = goodsPrice.FileHeaderGuid; // GUID
            goodsPriceRow.UpdEmployeeCode = goodsPrice.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            goodsPriceRow.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            goodsPriceRow.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            goodsPriceRow.LogicalDeleteCode = goodsPrice.LogicalDeleteCode; // �_���폜�敪
            goodsPriceRow.GoodsMakerCd = goodsPrice.GoodsMakerCd; // ���i���[�J�[�R�[�h
            goodsPriceRow.GoodsNo = goodsPrice.GoodsNo; // ���i�ԍ�
            goodsPriceRow.PriceStartDate = goodsPrice.PriceStartDate; // ���i�J�n��
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 ADD
            if ( goodsPrice.PriceStartDate != null && goodsPrice.PriceStartDate != DateTime.MinValue )
            {
                goodsPriceRow.PriceStartDateYear = goodsPrice.PriceStartDate.Year;
                goodsPriceRow.PriceStartDateMonth = goodsPrice.PriceStartDate.Month;
                goodsPriceRow.PriceStartDateDay = goodsPrice.PriceStartDate.Day;
                goodsPriceRow.PriceStartDateDis = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate(goodsPrice.PriceStartDate); // ADD 2013/02/08 �c����
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 ADD
            goodsPriceRow.ListPrice = goodsPrice.ListPrice; // �艿�i�����j
            goodsPriceRow.SalesUnitCost = goodsPrice.SalesUnitCost; // �����P��
            goodsPriceRow.StockRate = goodsPrice.StockRate; // �d����
            goodsPriceRow.OpenPriceDiv = goodsPrice.OpenPriceDiv; // �I�[�v�����i�敪
            goodsPriceRow.OfferDate = goodsPrice.OfferDate; // �񋟓��t

            // 2009.04.06 30413 ���� ���i�A���f�[�^null���l�� >>>>>>START
            // 2009.04.01 30413 ���� �d���P���[�������R�[�h�̒ǉ� >>>>>>START
            //goodsPriceRow.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;  // �d���P���[�������R�[�h
            if (goodsUnitData != null)
            {
                goodsPriceRow.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;  // �d���P���[�������R�[�h
            }
            // 2009.04.01 30413 ���� �d���P���[�������R�[�h�̒ǉ� <<<<<<END
            // 2009.04.06 30413 ���� ���i�A���f�[�^null���l�� <<<<<<END
            
            if (goodsUnitData != null) this.CalclateUnitPrice(goodsPriceRow, goodsUnitData); // �P���Z�o
            this.SettingCalcMaster(goodsPriceRow); // �Z�o�}�X�^
            this.SettingCalcStockRate(goodsPriceRow); // �Z�o�p������
            this.SettingCalcSalesUnitCost(goodsPriceRow); // �Z�o�p�����P��
            
        }

        /// <summary>
        /// ���i���f�[�^�s�I�u�W�F�N�g�폜����
        /// </summary>
        /// <param name="goodsMakerCode"></param>
        /// <param name="goodsNo"></param>
        /// <param name="priceStartDate"></param>
        private void DeleteGoodsPriceRow(int goodsMakerCode, string goodsNo, DateTime priceStartDate)
        {
            DataRow[] rows = _goodsPriceDataTable.Select(string.Format("{0}={1} and {2}={3} and {4}={5}",
                this.GoodsPriceDataTable.GoodsMakerCdColumn, goodsMakerCode,
                this.GoodsPriceDataTable.GoodsNoColumn, goodsNo,
                this.GoodsPriceDataTable.PriceStartDateColumn, priceStartDate));

            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = (GoodsInputDataSet.GoodsPriceRow)rows[0];
            if (goodsPriceRow != null)
            {
                _goodsPriceDataTable.RemoveGoodsPriceRow(goodsPriceRow);
            }
        }

        /// <summary>
        /// ���i���f�[�^�I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="goodsPriceList"></param>
        public void GetGoodsPriceListFromGoodsPriceDataTable(out List<GoodsPrice> goodsPriceList)
        {
            this.GetGoodsPriceListFromGoodsPriceDataTableProc(_goodsPriceDataTable, out goodsPriceList);
        }

        /// <summary>
        /// ���i���f�[�^�I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="goodsPriceDataTable"></param>
        /// <param name="goodsPriceList"></param>
        public void GetGoodsPriceListFromGoodsPriceDataTable(GoodsInputDataSet.GoodsPriceDataTable goodsPriceDataTable, out List<GoodsPrice> goodsPriceList)
        {
            this.GetGoodsPriceListFromGoodsPriceDataTableProc(goodsPriceDataTable, out goodsPriceList);
        }

        /// <summary>
        /// ���i���f�[�^�I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="goodsPriceDataTable"></param>
        /// <param name="goodsPriceList"></param>
        private void GetGoodsPriceListFromGoodsPriceDataTableProc(GoodsInputDataSet.GoodsPriceDataTable goodsPriceDataTable, out List<GoodsPrice> goodsPriceList)
        {
            goodsPriceList = new List<GoodsPrice>();

            foreach (GoodsInputDataSet.GoodsPriceRow goodsPriceRow in goodsPriceDataTable)
            {
                GoodsPrice goodsPrice = new GoodsPrice();
                
                goodsPrice.CreateDateTime = goodsPriceRow.CreateDateTime; // �쐬����
                goodsPrice.UpdateDateTime = goodsPriceRow.UpdateDateTime; // �X�V����
                goodsPrice.EnterpriseCode = goodsPriceRow.EnterpriseCode; // ��ƃR�[�h
                goodsPrice.FileHeaderGuid = goodsPriceRow.FileHeaderGuid; // GUID
                goodsPrice.UpdEmployeeCode = goodsPriceRow.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                goodsPrice.UpdAssemblyId1 = goodsPriceRow.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                goodsPrice.UpdAssemblyId2 = goodsPriceRow.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                goodsPrice.LogicalDeleteCode = goodsPriceRow.LogicalDeleteCode; // �_���폜�敪
                goodsPrice.GoodsMakerCd = goodsPriceRow.GoodsMakerCd; // ���i���[�J�[�R�[�h
                goodsPrice.GoodsNo = goodsPriceRow.GoodsNo; // ���i�ԍ�
                goodsPrice.PriceStartDate = goodsPriceRow.PriceStartDate; // ���i�J�n��
                goodsPrice.ListPrice = goodsPriceRow.ListPrice; // �艿�i�����j
                goodsPrice.SalesUnitCost = goodsPriceRow.SalesUnitCost; // �����P��
                goodsPrice.StockRate = goodsPriceRow.StockRate; // �d����
                goodsPrice.OpenPriceDiv = goodsPriceRow.OpenPriceDiv; // �I�[�v�����i�敪
                goodsPrice.OfferDate = goodsPriceRow.OfferDate; // �񋟓��t

                goodsPriceList.Add(goodsPrice);
            }
        }

        /// <summary>
        /// ���i���f�[�^�I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="goodsPriceWorkList">���i���f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsPriceList">���i���f�[�^�I�u�W�F�N�g���X�g</param>
        private void GetGoodsPriceListFromGoodsPriceUWorkList(ArrayList goodsPriceWorkList, out List<GoodsPrice> goodsPriceList)
        {
            goodsPriceList = new List<GoodsPrice>();

            foreach (GoodsPriceUWork goodsPriceUWork in goodsPriceWorkList)
            {
                GoodsPrice goodsPrice = new GoodsPrice();

                goodsPrice.CreateDateTime = goodsPriceUWork.CreateDateTime; // �쐬����
                goodsPrice.UpdateDateTime = goodsPriceUWork.UpdateDateTime; // �X�V����
                goodsPrice.EnterpriseCode = goodsPriceUWork.EnterpriseCode; // ��ƃR�[�h
                goodsPrice.FileHeaderGuid = goodsPriceUWork.FileHeaderGuid; // GUID
                goodsPrice.UpdEmployeeCode = goodsPriceUWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                goodsPrice.UpdAssemblyId1 = goodsPriceUWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                goodsPrice.UpdAssemblyId2 = goodsPriceUWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                goodsPrice.LogicalDeleteCode = goodsPriceUWork.LogicalDeleteCode; // �_���폜�敪
                goodsPrice.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
                goodsPrice.GoodsNo = goodsPriceUWork.GoodsNo; // ���i�ԍ�
                goodsPrice.PriceStartDate = goodsPriceUWork.PriceStartDate; // ���i�J�n��
                goodsPrice.ListPrice = goodsPriceUWork.ListPrice; // �艿�i�����j
                goodsPrice.SalesUnitCost = goodsPriceUWork.SalesUnitCost; // �����P��
                goodsPrice.StockRate = goodsPriceUWork.StockRate; // �d����
                goodsPrice.OpenPriceDiv = goodsPriceUWork.OpenPriceDiv; // �I�[�v�����i�敪
                goodsPrice.OfferDate = goodsPriceUWork.OfferDate; // �񋟓��t
                goodsPrice.UpdateDate = goodsPriceUWork.UpdateDate; // �X�V�N����

                goodsPriceList.Add(goodsPrice);
            }
        }

        /// <summary>
        /// ���i���f�[�^���[�N�I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="goodsPriceList">���i���f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsPriceWorkList">���i���f�[�^�I�u�W�F�N�g���X�g</param>
        private void GetGoodsPriceUWorkListFromGoodsPriceList(List<GoodsPrice> goodsPriceList, out ArrayList goodsPriceWorkList)
        {
            goodsPriceWorkList = new ArrayList();
            foreach (GoodsPrice goodsPrice in goodsPriceList)
            {
                if (goodsPrice.PriceStartDate != DateTime.MinValue)
                {
                    GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

                    goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime; // �쐬����
                    goodsPriceUWork.UpdateDateTime = goodsPrice.UpdateDateTime; // �X�V����
                    goodsPriceUWork.EnterpriseCode = goodsPrice.EnterpriseCode; // ��ƃR�[�h
                    goodsPriceUWork.FileHeaderGuid = goodsPrice.FileHeaderGuid; // GUID
                    goodsPriceUWork.UpdEmployeeCode = goodsPrice.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                    goodsPriceUWork.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                    goodsPriceUWork.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                    goodsPriceUWork.LogicalDeleteCode = goodsPrice.LogicalDeleteCode; // �_���폜�敪
                    goodsPriceUWork.GoodsMakerCd = goodsPrice.GoodsMakerCd; // ���i���[�J�[�R�[�h
                    goodsPriceUWork.GoodsNo = goodsPrice.GoodsNo; // ���i�ԍ�
                    goodsPriceUWork.PriceStartDate = goodsPrice.PriceStartDate; // ���i�J�n��
                    goodsPriceUWork.ListPrice = goodsPrice.ListPrice; // �艿�i�����j
                    goodsPriceUWork.SalesUnitCost = goodsPrice.SalesUnitCost; // �����P��
                    goodsPriceUWork.StockRate = goodsPrice.StockRate; // �d����
                    goodsPriceUWork.OpenPriceDiv = goodsPrice.OpenPriceDiv; // �I�[�v�����i�敪
                    goodsPriceUWork.OfferDate = goodsPrice.OfferDate; // �񋟓��t
                    goodsPriceUWork.UpdateDate = goodsPrice.UpdateDate; // �X�V�N����

                    goodsPriceWorkList.Add(goodsPriceUWork);
                }
            }
        }


        /// <summary>
        /// ���i���f�[�^�s�I�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="priceStartDate"></param>
        /// <returns></returns>
        public GoodsInputDataSet.GoodsPriceRow GetGoodsPriceRowFromGoodsPriceDataTable(string goodsNo, int goodsMakerCd, DateTime priceStartDate)
        {
            DataRow[] rows = _goodsPriceDataTable.Select(string.Format("{0}={1} and {2}={3} and {4}={5}",
                this.GoodsPriceDataTable.GoodsMakerCdColumn, goodsMakerCd,
                this.GoodsPriceDataTable.GoodsNoColumn, goodsNo,
                this.GoodsPriceDataTable.PriceStartDateColumn, priceStartDate));

            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = (GoodsInputDataSet.GoodsPriceRow)rows[0];
            return goodsPriceRow;
        }

        /// <summary>
        /// ���i���f�[�^�s�I�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="rowNo"></param>
        /// <returns></returns>
        public GoodsInputDataSet.GoodsPriceRow GetGoodsPriceRowFromGoodsPriceDataTable(int rowNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            return goodsPriceRow;
        }

        /// <summary>
        /// �w��������Y�����i���f�[�^�s�I�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="targetDateTime"></param>
        /// <returns></returns>
        public GoodsInputDataSet.GoodsPriceRow GetGoodsPriceRowFromGoodsPriceDataTable(DateTime targetDateTime)
        {
            DataView goodsPriceDataView = _goodsPriceDataTable.DefaultView;
            goodsPriceDataView.Sort = string.Format("{0}, {1}, {2} DESC", _goodsPriceDataTable.GoodsMakerCdColumn,
                                                                          _goodsPriceDataTable.GoodsNoColumn,
                                                                          _goodsPriceDataTable.PriceStartDateColumn);
            foreach (DataRowView dv in goodsPriceDataView)
            {
                DateTime priceStartDate = (DateTime)dv[_goodsPriceDataTable.PriceStartDateColumn.ColumnName];
                if (priceStartDate >= targetDateTime)
                {
                    GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo((int)dv[_goodsPriceDataTable.RowNoColumn.ColumnName]);
                    return goodsPriceRow;
                }
            }
            return null;
        }

        /// <summary>
        /// �w��������Y�����i���f�[�^�I�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="targetDateTime"></param>
        /// <param name="goodsPriceList"></param>
        /// <returns></returns>
        public GoodsPrice GetGoodsPriceFromGoodsPriceList(DateTime targetDateTime, List<GoodsPrice> goodsPriceList)
        {
            if ((goodsPriceList != null) && (goodsPriceList.Count != 0))
            {
                goodsPriceList.Sort(); // ���[�J�[(�~��)�E�i��(�~��)�E���i�J�n��(����)

                foreach (GoodsPrice goodsPrice in goodsPriceList)
                {
                    if (goodsPrice.PriceStartDate != DateTime.MinValue)
                    {
                        if (goodsPrice.PriceStartDate <= targetDateTime)
                        {
                            return goodsPrice;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// ���i�J�n�����̓`�F�b�N
        /// </summary>
        /// <returns>ture:���͂��� false:���͂Ȃ�</returns>
        public bool CheckInputPriceStartDate()
        {
            foreach (GoodsInputDataSet.GoodsPriceRow goodsPriceRow in _goodsPriceDataTable)
            {
                if (goodsPriceRow.PriceStartDate == DateTime.MinValue) continue;
                if (goodsPriceRow.PriceStartDate != DateTime.MinValue) return true;
            }
            return false;
        }

        /// <summary>
        /// ���i�J�n���d���`�F�b�N
        /// </summary>
        /// <param name="priceStartDate"></param>
        /// <returns>true:�d������ false:�d���Ȃ�</returns>
        public bool CheckRepeatPriceStartDate(DateTime priceStartDate)
        {
            foreach (GoodsInputDataSet.GoodsPriceRow goodsPriceRow in _goodsPriceDataTable)
            {
                if (goodsPriceRow.PriceStartDate == DateTime.MinValue) continue;
                if (goodsPriceRow.PriceStartDate == priceStartDate) return true;
            }
            return false;
        }

        /// <summary>
        /// �v�Z���������̓`�F�b�N
        /// </summary>
        /// <param name="rowNo"></param>
        /// <returns>true:���͂��� false:���͂Ȃ�</returns>
        public bool CheckInputCalcStockRate(int rowNo)
        {
            bool ret = false;

            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            if (goodsPriceRow != null)
            {
                if (goodsPriceRow.CalcStockRate != 0) ret = true;
            }

            return ret;
        }

        /// <summary>
        /// ���[�J�[�E�i�Ԑݒ菈��
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        public void SettingKeyValue(int rowNo, int goodsMakerCd, string goodsNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.SettingKeyValue(goodsPriceRow, goodsMakerCd, goodsNo);
        }

        /// <summary>
        /// ���[�J�[�E�i�Ԑݒ菈��
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        public void SettingKeyValue(GoodsInputDataSet.GoodsPriceRow goodsPriceRow, int goodsMakerCd, string goodsNo)
        {
            if (goodsPriceRow != null)
            {
                goodsPriceRow.GoodsMakerCd = goodsMakerCd;
                goodsPriceRow.GoodsNo = goodsNo;
            }
        }

        /// <summary>
        /// ���[�J�[�E�i�Ԑݒ菈��
        /// </summary>
        /// <param name="goodsPriceList"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        public void SettingKeyValue(List<GoodsPrice> goodsPriceList, int goodsMakerCd, string goodsNo)
        {
            if (goodsPriceList != null)
            {
                foreach (GoodsPrice goodsPrice in goodsPriceList)
                {
                    goodsPrice.GoodsMakerCd = goodsMakerCd;
                    goodsPrice.GoodsNo = goodsNo;
                }
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/10 ADD
        /// <summary>
        /// ���[�J�[�E�i�Ԑݒ菈��
        /// </summary>
        /// <param name="stockList"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        public void SettingKeyValue( List<Stock> stockList, int goodsMakerCd, string goodsNo )
        {
            if ( stockList != null )
            {
                foreach ( Stock stock in stockList )
                {
                    stock.GoodsMakerCd = goodsMakerCd;
                    stock.GoodsNo = goodsNo;

                    // --- ADD 2008/12/24 [��QID:9457�Ή�]----------------------------------------------------------->>>>>
                    stock.GoodsNoNoneHyphen = goodsNo.Replace("-", "").TrimEnd(); // �n�C�t�����i��
                    // --- ADD 2008/12/24 [��QID:9457�Ή�]-----------------------------------------------------------<<<<<
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/10 ADD

        /// <summary>
        /// �v�Z�p�������ݒ菈��
        /// </summary>
        /// <param name="rowNo"></param>
        public void SettingCalcStockRate(int rowNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.SettingCalcStockRate(goodsPriceRow);
        }

        /// <summary>
        /// �v�Z�p�������ݒ菈��
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        public void SettingCalcStockRate(GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            if (goodsPriceRow != null)
            {
                if (goodsPriceRow.SalesUnitCost == 0)
                {
                    if (goodsPriceRow.StockRate != 0)
                    {
                        // 2009.04.02 30413 ���� �|�����㏑�����Ȃ��悤�ɏC�� >>>>>>START
                        //goodsPriceRow.CalcStockRate = goodsPriceRow.StockRate;
                        // 2009.04.02 30413 ���� �|�����㏑�����Ȃ��悤�ɏC�� <<<<<<END
                    }
                }
                else
                {
                    goodsPriceRow.CalcStockRate = 0;
                }
            }
        }

        /// <summary>
        /// �v�Z�����z�ݒ菈��
        /// </summary>
        /// <param name="rowNo"></param>
        public void SettingCalcSalesUnitCost(int rowNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.SettingCalcSalesUnitCost(goodsPriceRow);
        }

        /// <summary>
        /// �v�Z�����z�ݒ菈��
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        public void SettingCalcSalesUnitCost(GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            if (goodsPriceRow != null)
            {
                if (goodsPriceRow.SalesUnitCost == 0)
                {
                    if (goodsPriceRow.CalcSalesUnitCost == 0)
                    {
                        double fracProcUnit = 0;
                        int fracProcCd = 0;
                        // 2009.04.02 30413 ���� �d���������͂���Ă���ꍇ���l�� >>>>>>START
                        double stockRate = goodsPriceRow.CalcStockRate;
                        if (goodsPriceRow.StockRate != 0.0)
                        {
                            stockRate = goodsPriceRow.StockRate;
                        }
                        //double unitCost = this.CalclateUnitPriceByRate(UnitPriceKind.UnitCost, 0, goodsPriceRow.ListPrice, goodsPriceRow.CalcStockRate, ref fracProcUnit, ref fracProcCd);
                        double unitCost = this.CalclateUnitPriceByRate(UnitPriceKind.UnitCost, goodsPriceRow.StockUnPrcFrcProcCd, goodsPriceRow.ListPrice, stockRate, ref fracProcUnit, ref fracProcCd);
                        // 2009.04.02 30413 ���� �d���������͂���Ă���ꍇ���l�� <<<<<<END
                        goodsPriceRow.CalcSalesUnitCost = unitCost;
                    }
                }
                else
                {
                    goodsPriceRow.CalcSalesUnitCost = goodsPriceRow.SalesUnitCost;
                }
            }
        }

        /// <summary>
        /// �Z�o�}�X�^�ݒ菈��
        /// </summary>
        /// <param name="rowNo"></param>
        public void SettingCalcMaster(int rowNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.SettingCalcMaster(goodsPriceRow);
        }

        /// <summary>
        /// �Z�o�}�X�^�ݒ菈��
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        public void SettingCalcMaster(GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            if (goodsPriceRow != null)
            {
                if (goodsPriceRow.PriceStartDate != DateTime.MinValue)
                {
                    if ((goodsPriceRow.SalesUnitCost == 0) && (goodsPriceRow.StockRate == 0))
                    {
                        if ((goodsPriceRow.CalcStockRate == 0) && (goodsPriceRow.CalcSalesUnitCost != 0))
                        {
                            goodsPriceRow.CalcMaster = "�P�i�ݒ�";
                        }
                        else if ((goodsPriceRow.CalcStockRate == 0) && (goodsPriceRow.CalcSalesUnitCost == 0))
                        {
                            goodsPriceRow.CalcMaster = string.Empty;
                        }
                        else
                        {
                            goodsPriceRow.CalcMaster = "�|���ݒ�";
                        }
                    }
                    else
                    {
                        goodsPriceRow.CalcMaster = "���i";
                    }
                }
                else
                {
                    goodsPriceRow.CalcMaster = string.Empty;
                }
            }
        }

        /// <summary>
        /// �Z�o���N���A����
        /// </summary>
        /// <param name="rowNo">�s�ԍ�</param>
        public void ClearCalcInfo(int rowNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.ClearCalcInfo(goodsPriceRow);
        }

        /// <summary>
        /// �Z�o���N���A����
        /// </summary>
        /// <param name="goodsPriceRow">���i�A���f�[�^�s�I�u�W�F�N�g</param>
        public void ClearCalcInfo(GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            if (goodsPriceRow != null)
            {
                goodsPriceRow.CalcMaster = string.Empty;
                goodsPriceRow.CalcSalesUnitCost = 0;
                // 2009.04.02 30413 ���� �v�Z�d�����ƗD�揇�ʂ̓N���A���Ȃ� >>>>>>START
                //goodsPriceRow.CalcStockRate = 0;
                //goodsPriceRow.PriorityOrder = 0;
                // 2009.04.02 30413 ���� �v�Z�d�����ƗD�揇�ʂ̓N���A���Ȃ� <<<<<<END
            }
        }

        /// <summary>
        /// ���͏��N���A����
        /// </summary>
        /// <param name="rowNo">�s�ԍ�</param>
        public void ClearInputInfo(int rowNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.ClearInputInfo(goodsPriceRow);
        }

        /// <summary>
        /// ���͏��N���A����
        /// </summary>
        /// <param name="goodsPriceRow">���i�A���f�[�^�s�I�u�W�F�N�g</param>
        public void ClearInputInfo(GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            if (goodsPriceRow != null)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                goodsPriceRow.ListPrice = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                goodsPriceRow.SalesUnitCost = 0;
                goodsPriceRow.StockRate = 0;

                // --- ADD 2009/02/03 ��QID:10848�Ή�------------------------------------------------------>>>>>
                goodsPriceRow.CalcStockRate = 0;
                goodsPriceRow.CalcSalesUnitCost = 0;
                // --- ADD 2009/02/03 ��QID:10848�Ή�------------------------------------------------------<<<<<
            }
        }

        /// <summary>
        /// �|�����g�p���ĒP�����v�Z���܂��B
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="stdPrice">����i</param>
        /// <param name="rate">�|��</param>
        /// <param name="fracProcUnit">�[�������P��</param>
        /// <param name="fracProcCd">�[�������敪</param>
        /// <returns></returns>
        public double CalclateUnitPriceByRate(UnitPriceKind unitPriceKind, int fractionProcCode, double stdPrice, double rate, ref double fracProcUnit, ref int fracProcCd)
        {
            return this.CalclateUnitPriceByRateProc(unitPriceKind, fractionProcCode, stdPrice, rate, ref fracProcUnit, ref fracProcCd);
        }

        /// <summary>
        /// �|�����g�p���ĒP�����v�Z���܂��B
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="stdPrice">����i</param>
        /// <param name="rate">�|��</param>
        /// <param name="fracProcUnit">�[�������P��</param>
        /// <param name="fracProcCd">�[�������敪</param>
        /// <returns></returns>
        private double CalclateUnitPriceByRateProc(UnitPriceKind unitPriceKind, int fractionProcCode, double stdPrice, double rate, ref double fracProcUnit, ref int fracProcCd)
        {
            if ((rate == 0) || (stdPrice == 0)) return 0;

            double unitPrice = (rate < 0) ? stdPrice * (100 + rate) * 0.01 : stdPrice * rate * 0.01;

            this.SettingFracProcInfo(unitPriceKind, fractionProcCode, unitPrice, ref fracProcUnit, ref fracProcCd);

            FractionCalculate.FracCalcMoney(unitPrice, fracProcUnit, fracProcCd, out unitPrice);

            return unitPrice;
        }

        /// <summary>
        /// �P���Z�o����
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        public void CalclateUnitPrice(GoodsUnitData goodsUnitData)
        {
            for (int i = 0; i < _goodsPriceDataTable.Count; i++)
            {
                this.CalclateUnitPrice(i + 1, goodsUnitData);
            }
        }

        /// <summary>
        /// �P���Z�o����
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        public void CalclateUnitPrice(int rowNo, GoodsUnitData goodsUnitData)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.CalclateUnitPriceProc(goodsPriceRow, goodsUnitData);
        }

        /// <summary>
        /// �P���Z�o����
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        /// <param name="goodsUnitData"></param>
        public void CalclateUnitPrice(GoodsInputDataSet.GoodsPriceRow goodsPriceRow, GoodsUnitData goodsUnitData)
        {
            this.CalclateUnitPriceProc(goodsPriceRow, goodsUnitData);
        }

        /// <summary>
        /// �P���Z�o����
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        /// <param name="goodsUnitData"></param>
        private void CalclateUnitPriceProc(GoodsInputDataSet.GoodsPriceRow goodsPriceRow, GoodsUnitData goodsUnitData)
        {
            //----------------------------------------------------------------------------
            // ��������
            //----------------------------------------------------------------------------
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            //----------------------------------------------------------------------------
            // �P���Z�o
            //----------------------------------------------------------------------------
            unitPriceCalcRetList = this.CalclateUnitPriceProc(goodsUnitData, goodsPriceRow);

            //----------------------------------------------------------------------------
            // �P���Z�o���ݒ�
            //----------------------------------------------------------------------------
            this.SettingCalclateUnitPriceInfo(unitPriceCalcRetList, ref goodsPriceRow);
        }
        
        /// <summary>
        /// �P���Z�o����
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="goodsPriceRow"></param>
        /// <returns></returns>
        private List<UnitPriceCalcRet> CalclateUnitPriceProc(GoodsUnitData goodsUnitData, GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            //----------------------------------------------------------------------------
            // ��������
            //----------------------------------------------------------------------------
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

            if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
            {
                //----------------------------------------------------------------------------
                // �p�����[�^�ݒ�
                //----------------------------------------------------------------------------
                unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                 // BL�R�[�h
                unitPriceCalcParam.BLGoodsName = goodsUnitData.BLGoodsName;                 // BL�R�[�h����
                unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                 // BL�O���[�v�R�[�h
                unitPriceCalcParam.CountFl = 0;                                             // ����
                unitPriceCalcParam.CustomerCode = 0;                                        // ���Ӑ�R�[�h
                unitPriceCalcParam.CustRateGrpCode = 0;                                     // ���Ӑ�|���O���[�v�R�[�h
                unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;               // ���[�J�[�R�[�h
                unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsMGroup;            // ���i�����ރR�[�h
                unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                         // �i��
                unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;             // ���i�|�������N
                unitPriceCalcParam.PriceApplyDate = DateTime.Today;                         // ���i�K�p��
                unitPriceCalcParam.SalesUnPrcFrcProcCd = 0;                                 // ����P���[�������R�[�h
                unitPriceCalcParam.SectionCode = goodsUnitData.SectionCode;                 // ���_�R�[�h
                unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd; // �d���P���[�������R�[�h
                unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                   // �d����R�[�h
                unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;             // �ېŋ敪

                unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;// �d������Œ[�������R�[�h
                unitPriceCalcParam.SalesCnsTaxFrcProcCd = 0;                                // �������Œ[�������R�[�h
                unitPriceCalcParam.TaxRate = this._taxRate;                                 // �ŗ�
                unitPriceCalcParam.TotalAmountDispWayCd = 0;                                // ���z�\�����@�敪(0:���z�\�����Ȃ�)
                unitPriceCalcParam.TtlAmntDspRateDivCd = 0;                                 // ���z�\���|���K�p�敪(0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��) �� ���z�\�����Ȃ��ꍇ�A�Q�Ƃ��Ȃ�

                //----------------------------------------------------------------------------
                // �P���Z�o
                //----------------------------------------------------------------------------
                this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
            }

            return unitPriceCalcRetList;

        }

        /// <summary>
        /// �P���Z�o���ݒ�
        /// </summary>
        /// <param name="unitPriceCalcRetList"></param>
        /// <param name="goodsPriceRow"></param>
        /// <remarks>
        /// <br>Update Note: 2012/12/06 �c����</br>
        /// <br>�Ǘ��ԍ�   : 2013/01/16�z�M��</br>
        /// <br>             Redmine#33663��#4 �|���P�i�����y�d���P���z���ݒ肳�ꂽ�ꍇ�A�|���f�[�^�d���P���̎Q�ƕ\���s���̑Ή�</br>
        /// </remarks>
        private void SettingCalclateUnitPriceInfo(List<UnitPriceCalcRet> unitPriceCalcRetList, ref GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                // �����ݒ莞�̂ݓW�J
                if (unitPriceCalcRet.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    //goodsPriceRow.RateUnitCost = unitPriceCalcRet.UnitPriceTaxIncFl; // �Z�o�p���P��
                    //goodsPriceRow.RateStockRate = unitPriceCalcRet.RateVal; // �Z�o�p������
                    if ((goodsPriceRow.SalesUnitCost == 0) && (goodsPriceRow.StockRate == 0))
                    {
                        // 2009.04.02 30413 ���� �d���P���̒[���Ή� >>>>>>START
                        // --- CHG 2009/03/17 ��QID:12473�Ή�------------------------------------------------------>>>>>
                        //goodsPriceRow.CalcSalesUnitCost = unitPriceCalcRet.UnitPriceTaxIncFl;
                        //goodsPriceRow.CalcSalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                        // --- CHG 2009/03/17 ��QID:12473�Ή�------------------------------------------------------<<<<<
                        // 2009.04.02 30413 ���� �d���P���̒[���Ή� <<<<<<END
                        goodsPriceRow.CalcStockRate = unitPriceCalcRet.RateVal;
                        //----- ADD 2012/12/06 �c���� Redmine#33663��#4 ---------->>>>>
                        // �|���P�i�����y�d���P���z���ݒ肳�ꂽ�ꍇ�A�Z�o�p���P�����d���P���ŃZ�b�g����
                        if (unitPriceCalcRet.RateVal == 0)
                        {
                            goodsPriceRow.CalcSalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                        }
                        //----- ADD 2012/12/06 �c���� Redmine#33663��#4 ----------<<<<<
                    }
                    goodsPriceRow.PriorityOrder = unitPriceCalcRet.RatePriorityOrder; // �D�揇��
                    this.SettingCalcMaster(goodsPriceRow);
                }
            }
        }

        #region �}�X�^�L���b�V��
        /// <summary>
        /// �d�����z�[�������敪�ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^���X�g</param>
        public void CacheStockProcMoneyList(List<StockProcMoney> stockProcMoneyList)
        {
            _stockProcMoneyList = stockProcMoneyList;
            this.SettingStockProcMoneyTable();
        }

        /// <summary>
        /// ������z�[�������敪�ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="salesProcMoneyList">������z�����敪�ݒ�}�X�^���X�g</param>
        public void CacheSalesProcMoneyList(List<SalesProcMoney> salesProcMoneyList)
        {
            _salesProcMoneyList = salesProcMoneyList;
            this.SettingSalesProcMoneyTable();
        }
        #endregion

        #region ���z������}�X�^�֘A
        /// <summary>
        /// �P����ށA���z�ɏ]���Ē[�������P�ʁA�[�������敪��ݒ肵�܂��B
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="price">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        private void SettingFracProcInfo(UnitPriceKind unitPriceKind, int fractionProcCode, double price, ref double fractionProcUnit, ref int fractionProcCd)
        {
            if (fractionProcUnit == 0)
            {
                switch (unitPriceKind)
                {
                    // �d���P��
                    case UnitPriceKind.UnitCost:
                        {
                            this.GetStockFractionProcInfo(ctFracProcMoneyDiv_UnitPrice, fractionProcCode, price, out fractionProcUnit, out fractionProcCd);
                            break;
                        }
                    // �艿�A����P��
                    case UnitPriceKind.ListPrice:
                    case UnitPriceKind.SalesUnitPrice:
                        {
                            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_UnitPrice, fractionProcCode, price, out fractionProcUnit, out fractionProcCd);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// ������z�����敪�ݒ�}�X�^���X�g���f�[�^�e�[�u���ɃZ�b�g���܂��B
        /// </summary>
        private void SettingSalesProcMoneyTable()
        {
            if (_salesProcMoneyList == null) return;

            // �f�[�^�e�[�u������
            CreateSalesProcMoneyTable(out _salesProcMoneyDataTable, _salesProcMoneyList);

            _salesProcMoneyDataTableView = new DataView(_salesProcMoneyDataTable);
            _salesProcMoneyDataTableView.Sort = string.Format("{0},{1}", _salesProcMoneyDataTable.FracProcMoneyDivColumn, _salesProcMoneyDataTable.FractionProcCodeColumn, _salesProcMoneyDataTable.UpperLimitPriceColumn);
        }

        /// <summary>
        /// ������z�����敪�ݒ�}�X�^���A�Ώۋ��z�ɊY������[�������P�ʁA�[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="price">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        private void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = GetDefaultFractionProcUnit(fracProcMoneyDiv);
            fractionProcCd = GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_salesProcMoneyDataTableView == null) return;

            string defaultSort = _salesProcMoneyDataTableView.Sort;
            string defaultRowFilter = _salesProcMoneyDataTableView.RowFilter;
            try
            {
                _salesProcMoneyDataTableView.RowFilter = string.Format("{0}={1} AND {2}={3} AND {4}>={5}", _salesProcMoneyDataTable.FracProcMoneyDivColumn, fracProcMoneyDiv, _salesProcMoneyDataTable.FractionProcCodeColumn.ColumnName, fractionProcCode, _salesProcMoneyDataTable.UpperLimitPriceColumn.ColumnName, price);

                if (_salesProcMoneyDataTableView.Count > 0)
                {
                    fractionProcUnit = (double)_salesProcMoneyDataTableView[0][_salesProcMoneyDataTable.FractionProcUnitColumn.ColumnName];
                    fractionProcCd = (int)_salesProcMoneyDataTableView[0][_salesProcMoneyDataTable.FractionProcCdColumn.ColumnName];
                }
            }
            finally
            {
                _salesProcMoneyDataTableView.Sort = defaultSort;
                _salesProcMoneyDataTableView.RowFilter = defaultRowFilter;
            }
        }

        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^���������܂��B
        /// </summary>
        private void SettingStockProcMoneyTable()
        {
            if (_stockProcMoneyList == null) return;

            // �f�[�^�e�[�u������
            CreateStockProcMoneyTable(out _stockProcMoneyDataTable, _stockProcMoneyList);

            _stockProcMoneyDataTableView = new DataView(_stockProcMoneyDataTable);
            _stockProcMoneyDataTableView.Sort = string.Format("{0},{1}", _stockProcMoneyDataTable.FracProcMoneyDivColumn.ColumnName, _stockProcMoneyDataTable.FractionProcCodeColumn.ColumnName, _stockProcMoneyDataTable.UpperLimitPriceColumn.ColumnName);
        }

        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^���A�Ώۋ��z�ɊY������[�������P�ʁA�[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="price">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        private void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = GetDefaultFractionProcUnit(fracProcMoneyDiv);
            fractionProcCd = GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_stockProcMoneyDataTableView == null) return;

            string defaultSort = _stockProcMoneyDataTableView.Sort;
            string defaultRowFilter = _stockProcMoneyDataTableView.RowFilter;
            try
            {
                _stockProcMoneyDataTableView.RowFilter = string.Format("{0}={1} AND {2}={3} AND {4}>={5}", _stockProcMoneyDataTable.FracProcMoneyDivColumn, fracProcMoneyDiv, _stockProcMoneyDataTable.FractionProcCodeColumn.ColumnName, fractionProcCode, _stockProcMoneyDataTable.UpperLimitPriceColumn.ColumnName, price);

                if (_stockProcMoneyDataTableView.Count > 0)
                {
                    fractionProcUnit = (double)_stockProcMoneyDataTableView[0][_stockProcMoneyDataTable.FractionProcUnitColumn.ColumnName];
                    fractionProcCd = (int)_stockProcMoneyDataTableView[0][_stockProcMoneyDataTable.FractionProcCdColumn.ColumnName];
                }
            }
            finally
            {
                _stockProcMoneyDataTableView.Sort = defaultSort;
                _stockProcMoneyDataTableView.RowFilter = defaultRowFilter;
            }
        }
        #endregion

        #region ��Public Static Methods
        /// <summary>
        /// ������z�����ݒ�敪���X�g���A���z�����敪�e�[�u���𐶐����܂��B
        /// </summary>
        /// <param name="procMoneyDataTable"></param>
        /// <param name="salesProcMoneyList"></param>
        public static void CreateSalesProcMoneyTable(out GoodsInputDataSet.ProcMoneyDataTable procMoneyDataTable, List<SalesProcMoney> salesProcMoneyList)
        {
            procMoneyDataTable = new GoodsInputDataSet.ProcMoneyDataTable();
            try
            {
                procMoneyDataTable.BeginLoadData();

                foreach (SalesProcMoney salesProcMoney in salesProcMoneyList)
                {
                    GoodsInputDataSet.ProcMoneyRow row = procMoneyDataTable.NewProcMoneyRow();

                    row[procMoneyDataTable.FracProcMoneyDivColumn.ColumnName] = salesProcMoney.FracProcMoneyDiv;
                    row[procMoneyDataTable.FractionProcCodeColumn.ColumnName] = salesProcMoney.FractionProcCode;
                    row[procMoneyDataTable.UpperLimitPriceColumn.ColumnName] = salesProcMoney.UpperLimitPrice;
                    row[procMoneyDataTable.FractionProcUnitColumn.ColumnName] = salesProcMoney.FractionProcUnit;
                    row[procMoneyDataTable.FractionProcCdColumn.ColumnName] = salesProcMoney.FractionProcCd;

                    procMoneyDataTable.AddProcMoneyRow(row);
                }
            }
            finally
            {
                procMoneyDataTable.EndLoadData();
            }
        }

        /// <summary>
        /// �d�����z�����ݒ�敪���X�g���A���z�����敪�e�[�u���𐶐����܂��B
        /// </summary>
        /// <param name="procMoneyDataTable"></param>
        /// <param name="stockProcMoneyList"></param>
        public static void CreateStockProcMoneyTable(out GoodsInputDataSet.ProcMoneyDataTable procMoneyDataTable, List<StockProcMoney> stockProcMoneyList)
        {
            procMoneyDataTable = new GoodsInputDataSet.ProcMoneyDataTable();

            try
            {
                procMoneyDataTable.BeginLoadData();

                foreach (StockProcMoney stockProcMoney in stockProcMoneyList)
                {
                    GoodsInputDataSet.ProcMoneyRow row = procMoneyDataTable.NewProcMoneyRow();

                    if (stockProcMoney.LogicalDeleteCode == 0)
                    {
                        row[procMoneyDataTable.FracProcMoneyDivColumn.ColumnName] = stockProcMoney.FracProcMoneyDiv;
                        row[procMoneyDataTable.FractionProcCodeColumn.ColumnName] = stockProcMoney.FractionProcCode;
                        row[procMoneyDataTable.UpperLimitPriceColumn.ColumnName] = stockProcMoney.UpperLimitPrice;
                        row[procMoneyDataTable.FractionProcUnitColumn.ColumnName] = stockProcMoney.FractionProcUnit;
                        row[procMoneyDataTable.FractionProcCdColumn.ColumnName] = stockProcMoney.FractionProcCd;
                    }

                    procMoneyDataTable.AddProcMoneyRow(row);
                }
            }
            finally
            {
                procMoneyDataTable.EndLoadData();
            }
        }

        /// <summary>
        /// �[�������Ώۋ��z�ݒ�敪�ɏ]�����[�������P�ʂ̃f�t�H���g�l���擾���܂��B
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <returns>�[�������P��</returns>
        public static double GetDefaultFractionProcUnit(int fracProcMoneyDiv)
        {
            switch (fracProcMoneyDiv)
            {
                // ���z�A�����A����ł�1�~�P��
                case ctFracProcMoneyDiv_Price:
                //case ctFracProcMoneyDiv_CostPrice: // 2009.01.21
                case ctFracProcMoneyDiv_Tax:
                    {
                        return 1;
                    }
                default:
                    {
                        return 0.01;
                    }
            }
        }

        /// <summary>
        /// �[�������敪�����l�擾
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <returns>�[�������敪</returns>
        public static int GetDefaultFractionProcCd(int fracProcMoneyDiv)
        {
            // 1:�؎̂�
            return 1;
        }
        #endregion

        #region ���i���擾
        /// <summary>
        /// ���i���擾
        /// </summary>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="goodsPriceList"></param>
        /// <returns></returns>
        public int GetGoodsPriceU(int goodsMakerCd, string goodsNo, out List<GoodsPrice> goodsPriceList)
        {
             IGoodsPriceUDB iGoodsPriceUDB = null;
            iGoodsPriceUDB = (IGoodsPriceUDB)MediationGoodsPriceUDB.GetGoodsPriceUDB();

            object objGoodsPriceUWorkArrayList = null;
            GoodsPriceUWork paraGoodsPriceUWork = new GoodsPriceUWork();
            paraGoodsPriceUWork.EnterpriseCode = this._enterpriseCode;
            paraGoodsPriceUWork.GoodsMakerCd = goodsMakerCd;
            paraGoodsPriceUWork.GoodsNo = goodsNo;

            int st = iGoodsPriceUDB.Search(out objGoodsPriceUWorkArrayList, paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData0);

            this.GetGoodsPriceListFromGoodsPriceUWorkList(objGoodsPriceUWorkArrayList as ArrayList, out goodsPriceList);

            return st;
        }
        #endregion
    }
}
