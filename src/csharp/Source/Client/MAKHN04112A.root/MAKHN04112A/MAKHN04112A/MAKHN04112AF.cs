//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���i�A�N�Z�X
// �v���O�����T�v   : ���i�A�N�Z�X�N���X(�݌ɏ��)�̃A�N�Z�X������s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���n ���
// �� �� ��  2008/06/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2009/01/13  �C�����e : ��QID:9867�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2009/01/20  �C�����e : ��QID:10217�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2009/01/26  �C�����e : ��QID:9618�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/03/10  �C�����e : ��QID:12337�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/04/22  �C�����e : �s��Ή�[13091]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/24  �C�����e : �s��Ή�[13582]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �C �� ��  2009/12/10  �C�����e : �s��Ή�[14593]
//----------------------------------------------------------------------------//
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
    /// <br>Note       : ���i�A�N�Z�X�N���X(�݌ɏ��)�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2008.06.18</br>
    /// <br>Update Note: 2009/01/13 30414 �E �K�j ��QID:9867�Ή�</br>
    /// <br>Update Note: 2009/01/20 30414 �E �K�j ��QID:10217�Ή�</br>
    /// <br>Update Note: 2009/01/26 30414 �E �K�j ��QID:9618�Ή�</br>
    /// <br>Update Note: 2009/03/10 30452 ��� �r�� ��QID:12337�Ή�</br>
    /// <br>           : 2009/04/22       �Ɠc �M�u �s��Ή�[13091]</br>
    /// <br>           : 2009/06/24       �Ɠc �M�u �s��Ή�[13582]</br>
    /// <br>           : 2010/04/06 22008 ���� ���n ���x�`���[�j���O</br>
    /// </remarks>
    public partial class GoodsAcs
    {
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/10 ADD
        /// <summary>
        /// �݌ɏ��f�[�^�I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="stockWorkList"></param>
        /// <param name="stockList"></param>
        private void GetStockListFromStockWorkList( ArrayList stockWorkList, out List<Stock> stockList )
        {
            stockList = new List<Stock>();
            foreach ( StockWork stockWork in stockWorkList )
            {
                if ( stockWork.LogicalDeleteCode == 3 ) continue;
                Stock stock = new Stock();

                stock.CreateDateTime = stockWork.CreateDateTime; // �쐬����
                stock.UpdateDateTime = stockWork.UpdateDateTime; // �X�V����
                stock.EnterpriseCode = stockWork.EnterpriseCode; // ��ƃR�[�h
                stock.FileHeaderGuid = stockWork.FileHeaderGuid; // GUID
                stock.UpdEmployeeCode = stockWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                stock.UpdAssemblyId1 = stockWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                stock.UpdAssemblyId2 = stockWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                stock.LogicalDeleteCode = stockWork.LogicalDeleteCode; // �_���폜�敪
                stock.SectionCode = stockWork.SectionCode.TrimEnd(); // ���_�R�[�h
                stock.WarehouseCode = stockWork.WarehouseCode.TrimEnd(); // �q�ɃR�[�h
                // 2008.11.04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                stock.WarehouseName = stockWork.WarehouseName.TrimEnd(); // �q�ɖ���
                // 2008.11.04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                stock.GoodsMakerCd = stockWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
                stock.GoodsNo = stockWork.GoodsNo.TrimEnd(); // ���i�ԍ�
                stock.StockUnitPriceFl = stockWork.StockUnitPriceFl; // �d���P���i�Ŕ�,�����j
                stock.SupplierStock = stockWork.SupplierStock; // �d���݌ɐ�
                stock.AcpOdrCount = stockWork.AcpOdrCount; // �󒍐�
                stock.MonthOrderCount = stockWork.MonthOrderCount; // M/O������
                stock.SalesOrderCount = stockWork.SalesOrderCount; // ������
                stock.StockDiv = stockWork.StockDiv; // �݌ɋ敪
                stock.MovingSupliStock = stockWork.MovingSupliStock; // �ړ����d���݌ɐ�
                stock.ShipmentPosCnt = stockWork.ShipmentPosCnt; // �o�׉\��
                stock.StockTotalPrice = stockWork.StockTotalPrice; // �݌ɕۗL���z
                stock.LastStockDate = stockWork.LastStockDate; // �ŏI�d���N����
                stock.LastSalesDate = stockWork.LastSalesDate; // �ŏI�����
                stock.LastInventoryUpdate = stockWork.LastInventoryUpdate; // �ŏI�I���X�V��
                stock.MinimumStockCnt = stockWork.MinimumStockCnt; // �Œ�݌ɐ�
                stock.MaximumStockCnt = stockWork.MaximumStockCnt; // �ō��݌ɐ�
                stock.NmlSalOdrCount = stockWork.NmlSalOdrCount; // �������
                stock.SalesOrderUnit = stockWork.SalesOrderUnit; // �����P��
                stock.StockSupplierCode = stockWork.StockSupplierCode; // �݌ɔ�����R�[�h
                stock.GoodsNoNoneHyphen = stockWork.GoodsNoNoneHyphen.TrimEnd(); // �n�C�t�������i�ԍ�
                stock.WarehouseShelfNo = stockWork.WarehouseShelfNo.TrimEnd(); // �q�ɒI��
                stock.DuplicationShelfNo1 = stockWork.DuplicationShelfNo1.TrimEnd(); // �d���I�ԂP
                stock.DuplicationShelfNo2 = stockWork.DuplicationShelfNo2.TrimEnd(); // �d���I�ԂQ
                stock.PartsManagementDivide1 = stockWork.PartsManagementDivide1.TrimEnd(); // ���i�Ǘ��敪�P
                stock.PartsManagementDivide2 = stockWork.PartsManagementDivide2.TrimEnd(); // ���i�Ǘ��敪�Q
                stock.StockNote1 = stockWork.StockNote1.TrimEnd(); // �݌ɔ��l�P
                stock.StockNote2 = stockWork.StockNote2.TrimEnd(); // �݌ɔ��l�Q
                stock.ShipmentCnt = stockWork.ShipmentCnt; // �o�א��i���v��j
                stock.ArrivalCnt = stockWork.ArrivalCnt; // ���א��i���v��j
                stock.StockCreateDate = stockWork.StockCreateDate; // �݌ɓo�^��
                stock.UpdateDate = stockWork.UpdateDate; // �X�V�N����

                stockList.Add( stock );
            }
        }
        /// <summary>
        /// �݌ɏ��f�[�^���[�N�I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="stockList"></param>
        /// <param name="stockWorkList"></param>
        private void GetStockWorkListFromStockList( List<Stock> stockList, out ArrayList stockWorkList )
        {
            stockWorkList = new ArrayList();
            foreach ( Stock stock in stockList )
            {
                StockWork stockWork = new StockWork();

                stockWork.CreateDateTime = stock.CreateDateTime; // �쐬����
                stockWork.UpdateDateTime = stock.UpdateDateTime; // �X�V����
                stockWork.EnterpriseCode = stock.EnterpriseCode; // ��ƃR�[�h
                stockWork.FileHeaderGuid = stock.FileHeaderGuid; // GUID
                stockWork.UpdEmployeeCode = stock.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                stockWork.UpdAssemblyId1 = stock.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                stockWork.UpdAssemblyId2 = stock.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                stockWork.LogicalDeleteCode = stock.LogicalDeleteCode; // �_���폜�敪
                stockWork.SectionCode = stock.SectionCode.TrimEnd(); // ���_�R�[�h
                stockWork.WarehouseCode = stock.WarehouseCode.TrimEnd(); // �q�ɃR�[�h
                stockWork.GoodsMakerCd = stock.GoodsMakerCd; // ���i���[�J�[�R�[�h
                stockWork.GoodsNo = stock.GoodsNo.TrimEnd(); // ���i�ԍ�
                stockWork.StockUnitPriceFl = stock.StockUnitPriceFl; // �d���P���i�Ŕ�,�����j
                stockWork.SupplierStock = stock.SupplierStock; // �d���݌ɐ�
                stockWork.AcpOdrCount = stock.AcpOdrCount; // �󒍐�
                stockWork.MonthOrderCount = stock.MonthOrderCount; // M/O������
                stockWork.SalesOrderCount = stock.SalesOrderCount; // ������
                stockWork.StockDiv = stock.StockDiv; // �݌ɋ敪
                stockWork.MovingSupliStock = stock.MovingSupliStock; // �ړ����d���݌ɐ�
                stockWork.ShipmentPosCnt = stock.ShipmentPosCnt; // �o�׉\��
                stockWork.StockTotalPrice = stock.StockTotalPrice; // �݌ɕۗL���z
                stockWork.LastStockDate = stock.LastStockDate; // �ŏI�d���N����
                stockWork.LastSalesDate = stock.LastSalesDate; // �ŏI�����
                stockWork.LastInventoryUpdate = stock.LastInventoryUpdate; // �ŏI�I���X�V��
                stockWork.MinimumStockCnt = stock.MinimumStockCnt; // �Œ�݌ɐ�
                stockWork.MaximumStockCnt = stock.MaximumStockCnt; // �ō��݌ɐ�
                stockWork.NmlSalOdrCount = stock.NmlSalOdrCount; // �������
                stockWork.SalesOrderUnit = stock.SalesOrderUnit; // �����P��
                stockWork.StockSupplierCode = stock.StockSupplierCode; // �݌ɔ�����R�[�h
                stockWork.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen.TrimEnd(); // �n�C�t�������i�ԍ�
                stockWork.WarehouseShelfNo = stock.WarehouseShelfNo.TrimEnd(); // �q�ɒI��
                stockWork.DuplicationShelfNo1 = stock.DuplicationShelfNo1.TrimEnd(); // �d���I�ԂP
                stockWork.DuplicationShelfNo2 = stock.DuplicationShelfNo2.TrimEnd(); // �d���I�ԂQ
                stockWork.PartsManagementDivide1 = stock.PartsManagementDivide1.TrimEnd(); // ���i�Ǘ��敪�P
                stockWork.PartsManagementDivide2 = stock.PartsManagementDivide2.TrimEnd(); // ���i�Ǘ��敪�Q
                stockWork.StockNote1 = stock.StockNote1.TrimEnd(); // �݌ɔ��l�P
                stockWork.StockNote2 = stock.StockNote2.TrimEnd(); // �݌ɔ��l�Q
                stockWork.ShipmentCnt = stock.ShipmentCnt; // �o�א��i���v��j
                stockWork.ArrivalCnt = stock.ArrivalCnt; // ���א��i���v��j
                stockWork.StockCreateDate = stock.StockCreateDate; // �݌ɓo�^��
                stockWork.UpdateDate = stock.UpdateDate; // �X�V�N����                

                stockWorkList.Add( stockWork );
            }
        }
        /// <summary>
        /// �݌ɏ��f�[�^���[�N�I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="stockWork"></param>
        private void GetStockWorkFromStock(Stock stock, out StockWork stockWork)
        {
            stockWork = new StockWork();

            stockWork.CreateDateTime = stock.CreateDateTime; // �쐬����
            stockWork.UpdateDateTime = stock.UpdateDateTime; // �X�V����
            stockWork.EnterpriseCode = stock.EnterpriseCode; // ��ƃR�[�h
            stockWork.FileHeaderGuid = stock.FileHeaderGuid; // GUID
            stockWork.UpdEmployeeCode = stock.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            stockWork.UpdAssemblyId1 = stock.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            stockWork.UpdAssemblyId2 = stock.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            stockWork.LogicalDeleteCode = stock.LogicalDeleteCode; // �_���폜�敪
            stockWork.SectionCode = stock.SectionCode.TrimEnd(); // ���_�R�[�h
            stockWork.WarehouseCode = stock.WarehouseCode.TrimEnd(); // �q�ɃR�[�h
            stockWork.GoodsMakerCd = stock.GoodsMakerCd; // ���i���[�J�[�R�[�h
            stockWork.GoodsNo = stock.GoodsNo.TrimEnd(); // ���i�ԍ�
            stockWork.StockUnitPriceFl = stock.StockUnitPriceFl; // �d���P���i�Ŕ�,�����j
            stockWork.SupplierStock = stock.SupplierStock; // �d���݌ɐ�
            stockWork.AcpOdrCount = stock.AcpOdrCount; // �󒍐�
            stockWork.MonthOrderCount = stock.MonthOrderCount; // M/O������
            stockWork.SalesOrderCount = stock.SalesOrderCount; // ������
            stockWork.StockDiv = stock.StockDiv; // �݌ɋ敪
            stockWork.MovingSupliStock = stock.MovingSupliStock; // �ړ����d���݌ɐ�
            stockWork.ShipmentPosCnt = stock.ShipmentPosCnt; // �o�׉\��
            stockWork.StockTotalPrice = stock.StockTotalPrice; // �݌ɕۗL���z
            stockWork.LastStockDate = stock.LastStockDate; // �ŏI�d���N����
            stockWork.LastSalesDate = stock.LastSalesDate; // �ŏI�����
            stockWork.LastInventoryUpdate = stock.LastInventoryUpdate; // �ŏI�I���X�V��
            stockWork.MinimumStockCnt = stock.MinimumStockCnt; // �Œ�݌ɐ�
            stockWork.MaximumStockCnt = stock.MaximumStockCnt; // �ō��݌ɐ�
            stockWork.NmlSalOdrCount = stock.NmlSalOdrCount; // �������
            stockWork.SalesOrderUnit = stock.SalesOrderUnit; // �����P��
            stockWork.StockSupplierCode = stock.StockSupplierCode; // �݌ɔ�����R�[�h
            stockWork.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen.TrimEnd(); // �n�C�t�������i�ԍ�
            stockWork.WarehouseShelfNo = stock.WarehouseShelfNo.TrimEnd(); // �q�ɒI��
            stockWork.DuplicationShelfNo1 = stock.DuplicationShelfNo1.TrimEnd(); // �d���I�ԂP
            stockWork.DuplicationShelfNo2 = stock.DuplicationShelfNo2.TrimEnd(); // �d���I�ԂQ
            stockWork.PartsManagementDivide1 = stock.PartsManagementDivide1.TrimEnd(); // ���i�Ǘ��敪�P
            stockWork.PartsManagementDivide2 = stock.PartsManagementDivide2.TrimEnd(); // ���i�Ǘ��敪�Q
            stockWork.StockNote1 = stock.StockNote1.TrimEnd(); // �݌ɔ��l�P
            stockWork.StockNote2 = stock.StockNote2.TrimEnd(); // �݌ɔ��l�Q
            stockWork.ShipmentCnt = stock.ShipmentCnt; // �o�א��i���v��j
            stockWork.ArrivalCnt = stock.ArrivalCnt; // ���א��i���v��j
            stockWork.StockCreateDate = stock.StockCreateDate; // �݌ɓo�^��
            stockWork.UpdateDate = stock.UpdateDate; // �X�V�N����
        }
        /// <summary>
        /// �݌ɍ����K�p�����i �ύX�さ�ύX�O �� �������ύX�O �j
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="prevStockList"></param>
        private void ReflectStockDifference( ref GoodsUnitData goodsUnitData, List<Stock> prevStockList )
        {
            //----------------------------------------------------------------
            // goodsUnitData(�ύX��)�̓��e���A�ύX�O����̍����ɕϊ����܂��B
            //
            // �ύX��@�ύX�O
            // ���@�@�@���@�@�@���@�y�X�V�z���ʁ��i�ύX��|�ύX�O�j
            // ���@�@�@�~�@�@�@���@�y�ǉ��z���ʁ��{�ύX��
            // ���@�@�@���@�@�@���@�y�폜�z���ʁ��|�ύX�O
            // 
            // < ���F�L�A�~�F���A���F�L����LogicalDeleteCode��0 >
            //----------------------------------------------------------------

            foreach ( Stock stock in goodsUnitData.StockList )
            {
                // �Ή�����ύX�O�݌ɃI�u�W�F�N�g���擾
                Stock prevStock = GetStockFromStockList( stock.WarehouseCode, stock.GoodsMakerCd, stock.GoodsNo, prevStockList );

                if ( prevStock != null )
                {
                    if ( stock.LogicalDeleteCode == 0 )
                    {
                        // �y�X�V�z
                        # region [�X�V]
                        // �݌Ƀ}�X�^�X�V���ɍ����ɂȂ��Ă��Ȃ���΂Ȃ�Ȃ��u���ʁv(���݌Ƀ����[�gMAZAI04134R���)
                        stock.SupplierStock -= prevStock.SupplierStock; // �d���݌ɐ�
                        stock.AcpOdrCount -= prevStock.AcpOdrCount; // �󒍐�
                        stock.SalesOrderCount -= prevStock.SalesOrderCount; // ������
                        stock.MovingSupliStock -= prevStock.MovingSupliStock; // �ړ����d���݌ɐ�
                        stock.ShipmentCnt -= prevStock.ShipmentCnt; // �o�א��i���v��j
                        stock.ArrivalCnt -= prevStock.ArrivalCnt; // ���א��i���v��j
                        # endregion
                    }
                    else
                    {
                        // �y�폜or�_���폜�z
                        # region [�폜]
                        // �݌Ƀ}�X�^�X�V���ɍ����ɂȂ��Ă��Ȃ���΂Ȃ�Ȃ��u���ʁv(���݌Ƀ����[�gMAZAI04134R���)
                        stock.SupplierStock = -prevStock.SupplierStock; // �d���݌ɐ�
                        stock.AcpOdrCount = -prevStock.AcpOdrCount; // �󒍐�
                        stock.SalesOrderCount = -prevStock.SalesOrderCount; // ������
                        stock.MovingSupliStock = -prevStock.MovingSupliStock; // �ړ����d���݌ɐ�
                        stock.ShipmentCnt = -prevStock.ShipmentCnt; // �o�א��i���v��j
                        stock.ArrivalCnt = -prevStock.ArrivalCnt; // ���א��i���v��j
                        # endregion
                    }
                }
                else
                {
                    // �y�ǉ��z���ύX��݌ɃI�u�W�F�N�g�̓��e�̂܂܂ŗǂ��̂ŏ����s�v�B
                }
            }
        }

        /// <summary>
        /// �X�V��݌ɍ����K�p�����i �X�V���ʁ��X�V�O���ύX�� �� �X�V����(���قȂ��ǉ�)���X�V�O���ύX�� �j
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="prevStockList"></param>
        /// <param name="bakGoodsUnitData"></param>
        private void ReflectStockDifferenceOnAfterUpdate(ref GoodsUnitData goodsUnitData, List<Stock> prevStockList, GoodsUnitData bakGoodsUnitData)
        {
            foreach (Stock stock in bakGoodsUnitData.StockList)
            {
                // 2009.04.01 30413 �_���폜�����݌ɍ����K�p�����͍s��Ȃ� >>>>>>START
                //if (stock.LogicalDeleteCode == 3)
                if (stock.LogicalDeleteCode != 0)
                {
                    // �_���폜�^���S�폜
                    continue;
                }
                // 2009.04.01 30413 �_���폜�����݌ɍ����K�p�����͍s��Ȃ� <<<<<<END
                
                // �ύX��̍݌ɃI�u�W�F�N�g���擾
                Stock updStock = GetStockFromStockList(stock.WarehouseCode, stock.GoodsMakerCd, stock.GoodsNo, goodsUnitData.StockList);

                if (updStock == null)
                {
                    // �Ή�����ύX�O�݌ɃI�u�W�F�N�g���擾
                    // ��prevStockList�͉�ʕ\�����̒l�AbakGoodsUnitData�͍X�V���O�̒l
                    //Stock prevStock = GetStockFromStockList(stock.WarehouseCode, stock.GoodsMakerCd, stock.GoodsNo, prevStockList);                       //DEL 2009/06/24 �s��Ή�[13582]�@�X�V���O�̒l���g�p����
                    Stock prevStock = GetStockFromStockList(stock.WarehouseCode, stock.GoodsMakerCd, stock.GoodsNo, bakGoodsUnitData.StockList);            //ADD 2009/06/24 �s��Ή�[13582]  �X�V���O�̒l���g�p����

                    if (prevStock != null)
                    {
                        // �ύX�O�݌ɂ��X�V���ʂ֒ǉ�
                        # region [�����Ȃ���]
                        stock.SupplierStock = prevStock.SupplierStock;          // �d���݌ɐ�
                        stock.AcpOdrCount = prevStock.AcpOdrCount;              // �󒍐�
                        stock.SalesOrderCount = prevStock.SalesOrderCount;      // ������
                        stock.MovingSupliStock = prevStock.MovingSupliStock;    // �ړ����d���݌ɐ�
                        stock.ShipmentCnt = prevStock.ShipmentCnt;              // �o�א��i���v��j
                        stock.ArrivalCnt = prevStock.ArrivalCnt;                // ���א��i���v��j
                        # endregion

                        // �����Ȃ��݌�
                        goodsUnitData.StockList.Add(stock);
                    }
                }
                else
                {
                    // �Ή�����ύX�O�݌ɃI�u�W�F�N�g���擾
                    // ��prevStockList�͉�ʕ\�����̒l�AbakGoodsUnitData�͍X�V���O�̒l
                    //Stock prevStock = GetStockFromStockList(updStock.WarehouseCode, updStock.GoodsMakerCd, updStock.GoodsNo, prevStockList);              //DEL 2009/06/24 �s��Ή�[13582]�@�X�V���O�̒l���g�p����
                    Stock prevStock = GetStockFromStockList(updStock.WarehouseCode, updStock.GoodsMakerCd, updStock.GoodsNo, bakGoodsUnitData.StockList);   //ADD 2009/06/24 �s��Ή�[13582]  �X�V���O�̒l���g�p����

                    if ((prevStock != null) && (!CheckUpdateStock(updStock)))
                    {
                        // �ύX�O�݌ɂōX�V���ʂ��C��
                        # region [�����Ȃ���]
                        int idx = goodsUnitData.StockList.IndexOf(updStock);
                        goodsUnitData.StockList[idx].SupplierStock = prevStock.SupplierStock;          // �d���݌ɐ�
                        goodsUnitData.StockList[idx].AcpOdrCount = prevStock.AcpOdrCount;              // �󒍐�
                        goodsUnitData.StockList[idx].SalesOrderCount = prevStock.SalesOrderCount;      // ������
                        goodsUnitData.StockList[idx].MovingSupliStock = prevStock.MovingSupliStock;    // �ړ����d���݌ɐ�
                        goodsUnitData.StockList[idx].ShipmentCnt = prevStock.ShipmentCnt;              // �o�א��i���v��j
                        goodsUnitData.StockList[idx].ArrivalCnt = prevStock.ArrivalCnt;                // ���א��i���v��j
                        # endregion
                    }
                }
            }
        }

        /// <summary>
        /// �݌ɒ����f�[�^�̐����i���i�A���f�[�^���j
        /// </summary>
        /// <param name="stockAdjustList">�݌ɒ����f�[�^���X�g</param>
        /// <param name="stockAdjustDtlList">�݌ɒ������׃f�[�^���X�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="prevStockList">�ύX�O�݌Ƀ��X�g</param>
        private void CreateStockAdjustWorkFromGoodsUnitData( ref ArrayList stockAdjustList, ref ArrayList stockAdjustDtlList, GoodsUnitData goodsUnitData, List<Stock> prevStockList )
        {
            // �݌ɏ�񂪖����ꍇ�͉I��
            if ( goodsUnitData.StockList == null || goodsUnitData.StockList.Count == 0 ) return;


            //---------------------------------------------------------------
            // �o�^�p�e��ݒ�l�擾
            //---------------------------------------------------------------

            // �󕥌��`�[�敪=42:�}�X�^�����e
            const int ct_AcPaySlipCd = 42;

            // �󕥌�����敪=30:�݌ɐ�����
            const int ct_AcPayTransCd = 30;

            // �쐬����(����)
            DateTime createDateTime = DateTime.Now;

            // (۸޲�)�]�ƈ��R�[�h
            string stockInputCode = LoginInfoAcquisition.Employee.EmployeeCode;
            
            // (۸޲�)�]�ƈ�����
            string stockInputName = LoginInfoAcquisition.Employee.Name;

            // 2009.06.15 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            // 2009.06.15 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // --- ADD 2009/01/20 ��QID:10217�Ή�------------------------------------------------------>>>>>
            Dictionary<string, SecInfoSet> secInfoSetDic = new Dictionary<string, SecInfoSet>();
            // 2009.06.15 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            foreach ( SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList )
            // 2009.06.15 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
            // --- ADD 2009/01/20 ��QID:10217�Ή�------------------------------------------------------<<<<<

            //---------------------------------------------------------------
            // �݌ɒ����f�[�^
            //---------------------------------------------------------------
            StockAdjustWork stockAdjustWork = new StockAdjustWork();

            # region [�݌ɒ���]
            stockAdjustWork.CreateDateTime = createDateTime; // �쐬����
            stockAdjustWork.UpdateDateTime = DateTime.MinValue; // �X�V����
            stockAdjustWork.EnterpriseCode = _enterpriseCode; // ��ƃR�[�h
            stockAdjustWork.FileHeaderGuid = Guid.Empty; // GUID
            //stockAdjustWork.UpdEmployeeCode = default( string ); // �X�V�]�ƈ��R�[�h
            //stockAdjustWork.UpdAssemblyId1 = default( string ); // �X�V�A�Z���u��ID1
            //stockAdjustWork.UpdAssemblyId2 = default( string ); // �X�V�A�Z���u��ID2
            stockAdjustWork.LogicalDeleteCode = 0; // �_���폜�敪
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 DEL
            //stockAdjustWork.SectionCode = goodsUnitData.SectionCode; // ���_�R�[�h
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
            stockAdjustWork.SectionCode = _loginSectionCode; // ���_�R�[�h
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD
            stockAdjustWork.StockAdjustSlipNo = 0; // �݌ɒ����`�[�ԍ�
            stockAdjustWork.AcPaySlipCd = ct_AcPaySlipCd; // �󕥌��`�[�敪
            stockAdjustWork.AcPayTransCd = ct_AcPayTransCd; // �󕥌�����敪
            stockAdjustWork.AdjustDate = createDateTime; // �������t
            stockAdjustWork.InputDay = createDateTime; // ���͓��t
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 DEL
            //stockAdjustWork.StockSectionCd = goodsUnitData.SectionCode; // �d�����_�R�[�h
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
            stockAdjustWork.StockSectionCd = _loginSectionCode; // �d�����_�R�[�h
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD
            stockAdjustWork.StockInputCode = stockInputCode; // �d�����͎҃R�[�h
            stockAdjustWork.StockInputName = stockInputName; // �d�����͎Җ���
            stockAdjustWork.StockAgentCode = stockInputCode; // �d���S���҃R�[�h
            stockAdjustWork.StockAgentName = stockInputName; // �d���S���Җ���
            stockAdjustWork.StockSubttlPrice = 0; // �d�����z���v�i���������ł͏����l�Ƃ���0���Z�b�g����j
            stockAdjustWork.SlipNote = string.Empty; // �`�[���l
            //---------------------------------
            // ���d�����z���v��
            //   �S���ו������Z����K�v������̂�
            //   ��ŏ���������B
            //---------------------------------
            // --- ADD 2009/01/20 ��QID:10217�Ή�------------------------------------------------------>>>>>
            if (secInfoSetDic.ContainsKey(_loginSectionCode.Trim()))
            {
                stockAdjustWork.SectionGuideNm = secInfoSetDic[_loginSectionCode.Trim()].SectionGuideNm.Trim();
                stockAdjustWork.StockSectionGuideNm = stockAdjustWork.SectionGuideNm;
            }
            // --- ADD 2009/01/20 ��QID:10217�Ή�------------------------------------------------------<<<<<
            # endregion

            //---------------------------------------------------------------
            // �݌ɒ������׃f�[�^
            //---------------------------------------------------------------
            for(int index=0;index < goodsUnitData.StockList.Count;index++)
            {
                StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();

                //---------------------------------------------------------------
                // �݌ɃI�u�W�F�N�g�擾
                //---------------------------------------------------------------
                // �X�V�����݌�(ReflectStockDifference�ŏ����ς��Ă����)
                Stock stock = goodsUnitData.StockList[index];
                // ���ʊ֌W(�̍���)���[���Ȃ�΍݌ɒ������׃f�[�^�͕s�v�Ȃ̂ŉI��
                if ( !CheckUpdateStock( stock ) ) continue;
                

                // �Ή�����X�V�O�݌�
                Stock prevStock = GetStockFromStockList( stock.WarehouseCode, stock.GoodsMakerCd, stock.GoodsNo, prevStockList );

                //---------------------------------------------------------------
                // �Z�b�g�l�Z�o
                //---------------------------------------------------------------

                // �W�����i�E�I�[�v�����i�敪
                double listPriceFl;
                int openPriceDiv;
                this.GetListPrice( out listPriceFl, out openPriceDiv, goodsUnitData.GoodsPriceList, createDateTime );

                // --- ADD 2009/01/13 ��QID:9867�Ή�------------------------------------------------------>>>>>
                // �d���P��
                double stockUnitPriceFl;
                GetStockUnitPriceFl(out stockUnitPriceFl, goodsUnitData.GoodsPriceList, createDateTime);
                stock.StockUnitPriceFl = stockUnitPriceFl;
                // --- ADD 2009/01/13 ��QID:9867�Ή�------------------------------------------------------<<<<<

                // �d�����z�Z�o
                Int64 stockPriceTaxExc;
                this.GetStockPriceTaxExc( out stockPriceTaxExc, stock );

                // ������
                // �i�����ӁI�݌Ƀ}�X�^�X�V�p�Ɏd���݌ɐ��͍����ɏ����������O��(this.ReflectStockDifference)�j
                double adjustCount = stock.SupplierStock;


                // �ύX�O�d���P���i�����j
                double bfStockUnitPriceFl = 0;
                if ( prevStock != null )
                {
                    // �ύX�O�I�u�W�F�N�g������΁u�d���P���i�����j�v���Z�b�g����
                    bfStockUnitPriceFl = prevStock.StockUnitPriceFl;
                }

                //---------------------------------------------------------------
                // �݌ɒ������א���
                //---------------------------------------------------------------

                # region [�݌ɒ�������]
                stockAdjustDtlWork.CreateDateTime = createDateTime; // �쐬����
                stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue; // �X�V����
                stockAdjustDtlWork.EnterpriseCode = _enterpriseCode; // ��ƃR�[�h
                stockAdjustDtlWork.FileHeaderGuid = Guid.Empty; // GUID
                //stockAdjustDtlWork.UpdEmployeeCode = default( string ); // �X�V�]�ƈ��R�[�h
                //stockAdjustDtlWork.UpdAssemblyId1 = default( string ); // �X�V�A�Z���u��ID1
                //stockAdjustDtlWork.UpdAssemblyId2 = default( string ); // �X�V�A�Z���u��ID2
                stockAdjustDtlWork.LogicalDeleteCode = 0; // �_���폜�敪
                stockAdjustDtlWork.SectionCode = stockAdjustWork.SectionCode; // ���_�R�[�h
                stockAdjustDtlWork.StockAdjustSlipNo = stockAdjustWork.StockAdjustSlipNo; // �݌ɒ����`�[�ԍ�
                stockAdjustDtlWork.StockAdjustRowNo = (index + 1); // �݌ɒ����s�ԍ�
                stockAdjustDtlWork.SupplierFormalSrc = 0; // �d���`���i���j
                stockAdjustDtlWork.StockSlipDtlNumSrc = 0; // �d�����גʔԁi���j
                stockAdjustDtlWork.AcPaySlipCd = stockAdjustWork.AcPaySlipCd; // �󕥌��`�[�敪
                stockAdjustDtlWork.AcPayTransCd = stockAdjustWork.AcPayTransCd; // �󕥌�����敪
                stockAdjustDtlWork.AdjustDate = createDateTime; // �������t
                stockAdjustDtlWork.InputDay = createDateTime; // ���͓��t
                stockAdjustDtlWork.GoodsMakerCd = stock.GoodsMakerCd; // ���i���[�J�[�R�[�h
                stockAdjustDtlWork.MakerName = stock.MakerName; // ���[�J�[����
                stockAdjustDtlWork.GoodsNo = stock.GoodsNo; // ���i�ԍ�
                stockAdjustDtlWork.GoodsName = stock.GoodsName; // ���i����
                stockAdjustDtlWork.StockUnitPriceFl = stock.StockUnitPriceFl; // �d���P���i�Ŕ�,�����j
                stockAdjustDtlWork.BfStockUnitPriceFl = bfStockUnitPriceFl; // �ύX�O�d���P���i�����j
                stockAdjustDtlWork.AdjustCount = adjustCount; // ������
                stockAdjustDtlWork.DtlNote = string.Empty; // ���ה��l
                stockAdjustDtlWork.WarehouseCode = stock.WarehouseCode; // �q�ɃR�[�h
                stockAdjustDtlWork.WarehouseName = stock.WarehouseName; // �q�ɖ���
                stockAdjustDtlWork.BLGoodsCode = goodsUnitData.BLGoodsCode; // BL���i�R�[�h
                stockAdjustDtlWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
                stockAdjustDtlWork.WarehouseShelfNo = stock.WarehouseShelfNo; // �q�ɒI��
                stockAdjustDtlWork.ListPriceFl = listPriceFl; // �艿�i�����j
                stockAdjustDtlWork.OpenPriceDiv = openPriceDiv; // �I�[�v�����i�敪
                stockAdjustDtlWork.StockPriceTaxExc = stockPriceTaxExc; // �d�����z�i�Ŕ����j
                // --- ADD 2009/01/26 ��QID:9618�Ή�------------------------------------------------------>>>>>
                stockAdjustDtlWork.GoodsName = goodsUnitData.GoodsName.Trim();  // �i��
                // --- ADD 2009/01/26 ��QID:9618�Ή�------------------------------------------------------<<<<<

                // --- ADD 2009/01/20 ��QID:10217�Ή�------------------------------------------------------>>>>>
                stockAdjustDtlWork.SectionGuideNm = stockAdjustWork.SectionGuideNm;
                MakerUMnt makerUMnt;
                int status = GetMaker(_enterpriseCode, stock.GoodsMakerCd, out makerUMnt);
                if (status == 0)
                {
                    stockAdjustDtlWork.MakerName = makerUMnt.MakerName.Trim();
                }
                // 2010/04/06 Del >>>
                //string goodsName;
                //status = GetGoodsName(stock.GoodsMakerCd, stock.GoodsNo, out goodsName);
                //if (status == 0)
                //{
                //    stockAdjustDtlWork.GoodsName = goodsName.Trim();
                //}
                // 2010/04/06 Del <<<
                // --- ADD 2009/01/20 ��QID:10217�Ή�------------------------------------------------------<<<<<
                # endregion

                // �݌ɒ������׃f�[�^���X�g�ɒǉ�
                stockAdjustDtlList.Add( stockAdjustDtlWork );

                //---------------------------------------------------------------
                // ���z�v�ɍ��Z
                //---------------------------------------------------------------
                stockAdjustWork.StockSubttlPrice += stockAdjustDtlWork.StockPriceTaxExc; // �d�����z���v�ɍ��Z
            }

            // �݌ɒ����f�[�^���X�g�ɒǉ�
            // �i�����ʓI�ɖ��ׂ��[�����ɂȂ����ꍇ�͕s�v�j
            if ( stockAdjustDtlList.Count > 0 )
            {
                stockAdjustList.Add( stockAdjustWork );
            }
        }

        /// <summary>
        /// �݌ɒ����f�[�^�̐����i���i�A���f�[�^���j
        /// </summary>
        /// <param name="stockAdjustCsList">�݌ɒ����f�[�^���X�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="prevStockList">�ύX�O�݌Ƀ��X�g</param>
        private void CreateStockAdjustWorkFromGoodsUnitData(ref CustomSerializeArrayList stockAdjustCsList, GoodsUnitData goodsUnitData, List<Stock> prevStockList)
        {
            // �݌ɏ�񂪖����ꍇ�͉I��
            if (goodsUnitData.StockList == null || goodsUnitData.StockList.Count == 0) return;

            //---------------------------------------------------------------
            // �o�^�p�e��ݒ�l�擾
            //---------------------------------------------------------------

            // �󕥌��`�[�敪=42:�}�X�^�����e
            const int ct_AcPaySlipCd = 42;

            // �󕥌�����敪=30:�݌ɐ�����
            const int ct_AcPayTransCd = 30;

            // �쐬����(����)
            DateTime createDateTime = DateTime.Now;

            // (۸޲�)�]�ƈ��R�[�h
            string stockInputCode = LoginInfoAcquisition.Employee.EmployeeCode;

            // (۸޲�)�]�ƈ�����
            string stockInputName = LoginInfoAcquisition.Employee.Name;
            // 2009.02.27 30413 ���� �݌ɒ����f�[�^�͖���16���܂� >>>>>>START
            if (stockInputName.Length > 16)
            {
                // 16���Ő؂�̂�
                stockInputName = stockInputName.Substring(0, 16);
            }
            // 2009.02.27 30413 ���� �݌ɒ����f�[�^�͖���16���܂� <<<<<<END
            // 2009.06.15 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            // 2009.06.15 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            Dictionary<string, SecInfoSet> secInfoSetDic = new Dictionary<string, SecInfoSet>();
            // 2009.06.15 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            foreach ( SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList )
            // 2009.06.15 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
            
            for (int index = 0; index < goodsUnitData.StockList.Count; index++)
            {
                //---------------------------------------------------------------
                // �݌ɒ����f�[�^
                //---------------------------------------------------------------
                StockAdjustWork stockAdjustWork = new StockAdjustWork();

                # region [�݌ɒ���]
                stockAdjustWork.CreateDateTime = createDateTime; // �쐬����
                stockAdjustWork.UpdateDateTime = DateTime.MinValue; // �X�V����
                stockAdjustWork.EnterpriseCode = _enterpriseCode; // ��ƃR�[�h
                stockAdjustWork.FileHeaderGuid = Guid.Empty; // GUID
                stockAdjustWork.LogicalDeleteCode = 0; // �_���폜�敪
                stockAdjustWork.SectionCode = _loginSectionCode; // ���_�R�[�h
                stockAdjustWork.StockAdjustSlipNo = 0; // �݌ɒ����`�[�ԍ�
                stockAdjustWork.AcPaySlipCd = ct_AcPaySlipCd; // �󕥌��`�[�敪
                stockAdjustWork.AcPayTransCd = ct_AcPayTransCd; // �󕥌�����敪
                stockAdjustWork.AdjustDate = createDateTime; // �������t
                stockAdjustWork.InputDay = createDateTime; // ���͓��t
                //stockAdjustWork.StockSectionCd = _loginSectionCode; // �d�����_�R�[�h         //DEL 2009/04/22 �s��Ή�[13091]
                stockAdjustWork.StockInputCode = stockInputCode; // �d�����͎҃R�[�h
                stockAdjustWork.StockInputName = stockInputName; // �d�����͎Җ���
                stockAdjustWork.StockAgentCode = stockInputCode; // �d���S���҃R�[�h
                stockAdjustWork.StockAgentName = stockInputName; // �d���S���Җ���
                stockAdjustWork.StockSubttlPrice = 0; // �d�����z���v�i���������ł͏����l�Ƃ���0���Z�b�g����j
                stockAdjustWork.SlipNote = string.Empty; // �`�[���l
                //---------------------------------
                // ���d�����z���v��
                //   �S���ו������Z����K�v������̂�
                //   ��ŏ���������B
                //---------------------------------
                if (secInfoSetDic.ContainsKey(_loginSectionCode.Trim()))
                {
                    stockAdjustWork.SectionGuideNm = secInfoSetDic[_loginSectionCode.Trim()].SectionGuideNm.Trim();
                    //stockAdjustWork.StockSectionGuideNm = stockAdjustWork.SectionGuideNm;     //DEL 2009/04/22 �s��Ή�[13091]
                }
                # endregion


                //---------------------------------------------------------------
                // �݌ɒ������׃f�[�^
                //---------------------------------------------------------------
                StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();

                //---------------------------------------------------------------
                // �݌ɃI�u�W�F�N�g�擾
                //---------------------------------------------------------------
                // �X�V�����݌�(ReflectStockDifference�ŏ����ς��Ă����)
                Stock stock = goodsUnitData.StockList[index];
                // ���ʊ֌W(�̍���)���[���Ȃ�΍݌ɒ������׃f�[�^�͕s�v�Ȃ̂ŉI��
                //if (!CheckUpdateStock(stock)) continue;
                

                // �Ή�����X�V�O�݌�
                Stock prevStock = GetStockFromStockList(stock.WarehouseCode, stock.GoodsMakerCd, stock.GoodsNo, prevStockList);

                // ---ADD 2009/04/22 �s��Ή�[13091] ----------------------------------------------------------->>>>>
                // �d���拒�_�R�[�h�A���̎擾
                stockAdjustWork.StockSectionCd = stock.SectionCode;
                if (secInfoSetDic.ContainsKey(stockAdjustWork.StockSectionCd.Trim()))
                {
                    stockAdjustWork.StockSectionGuideNm = secInfoSetDic[stockAdjustWork.StockSectionCd.Trim()].SectionGuideNm.Trim();
                }
                // ---ADD 2009/04/22 �s��Ή�[13091] -----------------------------------------------------------<<<<<


                // 2009.03.17 30413 ���� �X�V�݌ɏ�����ύX >>>>>>START
                // 2009.03.09 30413 ���� �X�V�݌ɂ̃`�F�b�N��ύX >>>>>>START
                // ���ʊ֌W(�̍���)���[���Ȃ�΍݌ɒ������׃f�[�^�͕s�v�Ȃ̂ŉI��
                //if (!CheckUpdateStockDiff(stock, prevStock)) continue;
                if (!CheckUpdateStockDiff(stock, prevStock))
                {
                    // ���ʊ֌W�̍������[���̏ꍇ�́A�݌ɏ��̂ݐݒ�
                    CustomSerializeArrayList csListOnly = new CustomSerializeArrayList();
                    ArrayList stockWorkListOnly = new ArrayList();
                    StockWork stockWorkOnly;
                    GetStockWorkFromStock(stock, out stockWorkOnly);

                    stockWorkListOnly.Add(stockWorkOnly);
                    csListOnly.Add(stockWorkListOnly);
                    stockAdjustCsList.Add(csListOnly);
                    continue;
                }
                // 2009.03.09 30413 ���� �X�V�݌ɂ̃`�F�b�N��ύX <<<<<<END
                // 2009.03.17 30413 ���� �X�V�݌ɏ�����ύX <<<<<<END
                                
                //---------------------------------------------------------------
                // �Z�b�g�l�Z�o
                //---------------------------------------------------------------

                // �W�����i�E�I�[�v�����i�敪
                double listPriceFl;
                int openPriceDiv;
                this.GetListPrice(out listPriceFl, out openPriceDiv, goodsUnitData.GoodsPriceList, createDateTime);

                // DEL 2009/12/10 MANTIS�Ή�[14593]�F�݌Ɏd������ύX���ĕۑ�����ƒI���]���P�����ς�� ---------->>>>>
                // FIXME:�d���P��
                //double stockUnitPriceFl;
                //GetStockUnitPriceFl(out stockUnitPriceFl, goodsUnitData.GoodsPriceList, createDateTime);
                //stock.StockUnitPriceFl = stockUnitPriceFl;
                // DEL 2009/12/10 MANTIS�Ή�[14593]�F�݌Ɏd������ύX���ĕۑ�����ƒI���]���P�����ς�� ----------<<<<<
                
                // �d�����z�Z�o
                Int64 stockPriceTaxExc;
                this.GetStockPriceTaxExc(out stockPriceTaxExc, stock);

                // ������
                // �i�����ӁI�݌Ƀ}�X�^�X�V�p�Ɏd���݌ɐ��͍����ɏ����������O��(this.ReflectStockDifference)�j
                double adjustCount = stock.SupplierStock;


                // �ύX�O�d���P���i�����j
                double bfStockUnitPriceFl = 0;
                if (prevStock != null)
                {
                    // �ύX�O�I�u�W�F�N�g������΁u�d���P���i�����j�v���Z�b�g����
                    bfStockUnitPriceFl = prevStock.StockUnitPriceFl;
                }

                //---------------------------------------------------------------
                // �݌ɒ������א���
                //---------------------------------------------------------------

                # region [�݌ɒ�������]
                stockAdjustDtlWork.CreateDateTime = createDateTime; // �쐬����
                stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue; // �X�V����
                stockAdjustDtlWork.EnterpriseCode = _enterpriseCode; // ��ƃR�[�h
                stockAdjustDtlWork.FileHeaderGuid = Guid.Empty; // GUID
                stockAdjustDtlWork.LogicalDeleteCode = 0; // �_���폜�敪
                stockAdjustDtlWork.SectionCode = stockAdjustWork.SectionCode; // ���_�R�[�h
                stockAdjustDtlWork.StockAdjustSlipNo = stockAdjustWork.StockAdjustSlipNo; // �݌ɒ����`�[�ԍ�
                stockAdjustDtlWork.StockAdjustRowNo = (index + 1); // �݌ɒ����s�ԍ�
                stockAdjustDtlWork.SupplierFormalSrc = 0; // �d���`���i���j
                stockAdjustDtlWork.StockSlipDtlNumSrc = 0; // �d�����גʔԁi���j
                stockAdjustDtlWork.AcPaySlipCd = stockAdjustWork.AcPaySlipCd; // �󕥌��`�[�敪
                stockAdjustDtlWork.AcPayTransCd = stockAdjustWork.AcPayTransCd; // �󕥌�����敪
                stockAdjustDtlWork.AdjustDate = createDateTime; // �������t
                stockAdjustDtlWork.InputDay = createDateTime; // ���͓��t
                stockAdjustDtlWork.GoodsMakerCd = stock.GoodsMakerCd; // ���i���[�J�[�R�[�h
                stockAdjustDtlWork.MakerName = stock.MakerName; // ���[�J�[����
                stockAdjustDtlWork.GoodsNo = stock.GoodsNo; // ���i�ԍ�
                stockAdjustDtlWork.GoodsName = stock.GoodsName; // ���i����
                stockAdjustDtlWork.StockUnitPriceFl = stock.StockUnitPriceFl; // �d���P���i�Ŕ�,�����j
                stockAdjustDtlWork.BfStockUnitPriceFl = bfStockUnitPriceFl; // �ύX�O�d���P���i�����j
                stockAdjustDtlWork.AdjustCount = adjustCount; // ������
                stockAdjustDtlWork.DtlNote = string.Empty; // ���ה��l
                stockAdjustDtlWork.WarehouseCode = stock.WarehouseCode; // �q�ɃR�[�h
                stockAdjustDtlWork.WarehouseName = stock.WarehouseName; // �q�ɖ���
                stockAdjustDtlWork.BLGoodsCode = goodsUnitData.BLGoodsCode; // BL���i�R�[�h
                stockAdjustDtlWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
                stockAdjustDtlWork.WarehouseShelfNo = stock.WarehouseShelfNo; // �q�ɒI��
                stockAdjustDtlWork.ListPriceFl = listPriceFl; // �艿�i�����j
                stockAdjustDtlWork.OpenPriceDiv = openPriceDiv; // �I�[�v�����i�敪
                stockAdjustDtlWork.StockPriceTaxExc = stockPriceTaxExc; // �d�����z�i�Ŕ����j
                stockAdjustDtlWork.GoodsName = goodsUnitData.GoodsName.Trim();  // �i��
                
                stockAdjustDtlWork.SectionGuideNm = stockAdjustWork.SectionGuideNm;
                MakerUMnt makerUMnt;
                int status = GetMaker(_enterpriseCode, stock.GoodsMakerCd, out makerUMnt);
                if (status == 0)
                {
                    stockAdjustDtlWork.MakerName = makerUMnt.MakerName.Trim();
                }
                // 2010/04/06 Del >>>
                //string goodsName;
                //status = GetGoodsName(stock.GoodsMakerCd, stock.GoodsNo, out goodsName);
                //if (status == 0)
                //{
                //    stockAdjustDtlWork.GoodsName = goodsName.Trim();
                //}
                // 2010/04/06 Del <<<
                # endregion

                //---------------------------------------------------------------
                // ���z�v�ɍ��Z
                //---------------------------------------------------------------
                stockAdjustWork.StockSubttlPrice += stockAdjustDtlWork.StockPriceTaxExc; // �d�����z���v�ɍ��Z

                // �`�[�Ɩ��ׂ�1��1�Ŋ֘A�t����
                CustomSerializeArrayList csList = new CustomSerializeArrayList();
                ArrayList stockAdjustWorkList = new ArrayList();
                ArrayList stockAdjustDtlWorkList = new ArrayList();
                ArrayList stockWorkList = new ArrayList();
                StockWork stockWork;
                GetStockWorkFromStock(stock, out stockWork);

                stockAdjustWorkList.Add(stockAdjustWork);
                stockAdjustDtlWorkList.Add(stockAdjustDtlWork);
                stockWorkList.Add(stockWork);

                csList.Add(stockAdjustWorkList);
                csList.Add(stockAdjustDtlWorkList);
                csList.Add(stockWorkList);

                stockAdjustCsList.Add(csList);
            }
        }

        /// <summary>
        /// �݌ɐ��ʍX�V�`�F�b�N����
        /// </summary>
        /// <param name="stockDifference"></param>
        /// <returns></returns>
        private bool CheckUpdateStock( Stock stockDifference )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 DEL
            //if ( stockDifference.SupplierStock > 0 ) return true; // �d���݌ɐ�
            //if ( stockDifference.AcpOdrCount > 0 ) return true; // �󒍐�
            //if ( stockDifference.SalesOrderCount > 0 ) return true; // ������
            //if ( stockDifference.MovingSupliStock > 0 ) return true; // �ړ����d���݌ɐ�
            //if ( stockDifference.ShipmentCnt > 0 ) return true; // �o�א��i���v��j
            //if ( stockDifference.ArrivalCnt > 0 ) return true; // ���א��i���v��j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
            if ( stockDifference.SupplierStock != 0 ) return true; // �d���݌ɐ�
            if ( stockDifference.AcpOdrCount != 0 ) return true; // �󒍐�
            if ( stockDifference.SalesOrderCount != 0 ) return true; // ������
            if ( stockDifference.MovingSupliStock != 0 ) return true; // �ړ����d���݌ɐ�
            if ( stockDifference.ShipmentCnt != 0 ) return true; // �o�א��i���v��j
            if ( stockDifference.ArrivalCnt != 0 ) return true; // ���א��i���v��j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD

            // ��L���ڑS��(������)�[���Ȃ��false
            return false;
        }

        /// <summary>
        /// �݌ɐ��ʍX�V�`�F�b�N����
        /// </summary>
        /// <param name="stockDifference"></param>
        /// <param name="prevStock"></param>
        /// <returns></returns>
        private bool CheckUpdateStockDiff(Stock stockDifference, Stock prevStock)
        {
            if (stockDifference.SupplierStock != 0) return true; // �d���݌ɐ�
            if (stockDifference.AcpOdrCount != 0) return true; // �󒍐�
            if (stockDifference.SalesOrderCount != 0) return true; // ������
            if (stockDifference.MovingSupliStock != 0) return true; // �ړ����d���݌ɐ�
            if (stockDifference.ShipmentCnt != 0) return true; // �o�א��i���v��j
            if (stockDifference.ArrivalCnt != 0) return true; // ���א��i���v��j

            // 2009.04.02 30413 ���� �V�K�쐬���A�݌ɐ������͂��ƒ����f�[�^�͍쐬���Ȃ� >>>>>>START
            //if (prevStock == null) return true; // ADD 2009/03/10
            if (prevStock == null) return false;

            //if ((prevStock.LogicalDeleteCode != 0) || (stockDifference.LogicalDeleteCode != 0)) return true;  // �ύX�O��̘_���폜�R�[�h
            // 2009.04.02 30413 ���� �V�K�쐬���A�݌ɐ������͂��ƒ����f�[�^�͍쐬���Ȃ� <<<<<<END
            
            // ��L���ڑS��(������)�[���Ȃ��false
            return false;
        }

        /// <summary>
        /// ���i�W�����i�擾����
        /// </summary>
        /// <param name="listPriceFl"></param>
        /// <param name="openPriceDiv"></param>
        /// <param name="goodsPriceList"></param>
        /// <param name="priceDate"></param>
        private void GetListPrice( out double listPriceFl, out int openPriceDiv, List<GoodsPrice> goodsPriceList, DateTime priceDate )
        {
            listPriceFl = 0;
            openPriceDiv = 0;
            if ( goodsPriceList == null || goodsPriceList.Count == 0 ) return;

            // --- CHG 2009/01/13 ��QID:9867�Ή�------------------------------------------------------>>>>>
            //goodsPriceList.Sort(); // ���[�J�[(�~��)�E�i��(�~��)�E���i�J�n��(����)
            goodsPriceList.Sort(delegate(GoodsPrice x, GoodsPrice y)
            {
                int targetX = TDateTime.DateTimeToLongDate(x.PriceStartDate);
                int targetY = TDateTime.DateTimeToLongDate(y.PriceStartDate);

                return targetX - targetY;
            });
            // --- CHG 2009/01/13 ��QID:9867�Ή�------------------------------------------------------<<<<<

            int activePriceIndex = -1;
            for ( int index = goodsPriceList.Count - 1; index >= 0; index-- )
            {
                if ( goodsPriceList[index].PriceStartDate <= priceDate )
                {
                    activePriceIndex = index;
                    break;
                }
            }
            if ( activePriceIndex >= 0 )
            {
                listPriceFl = goodsPriceList[activePriceIndex].ListPrice;
                openPriceDiv = goodsPriceList[activePriceIndex].OpenPriceDiv;
            }
        }
        /// <summary>
        /// ���i�d���P���擾����
        /// </summary>
        /// <param name="stockUnitPriceFl"></param>
        /// <param name="goodsPriceList"></param>
        /// <param name="priceDate"></param>
        private void GetStockUnitPriceFl(out double stockUnitPriceFl, List<GoodsPrice> goodsPriceList, DateTime priceDate)
        {
            stockUnitPriceFl = 0;
            if (goodsPriceList == null || goodsPriceList.Count == 0) return;

            // ���[�J�[(�~��)�E�i��(�~��)�E���i�J�n��(����)
            goodsPriceList.Sort(delegate(GoodsPrice x, GoodsPrice y)
            {
                int targetX = TDateTime.DateTimeToLongDate(x.PriceStartDate);
                int targetY = TDateTime.DateTimeToLongDate(y.PriceStartDate);

                return targetX - targetY;
            });

            int activePriceIndex = -1;
            for (int index = goodsPriceList.Count - 1; index >= 0; index--)
            {
                if (goodsPriceList[index].PriceStartDate <= priceDate)
                {
                    activePriceIndex = index;
                    break;
                }
            }
            if (activePriceIndex >= 0)
            {
                stockUnitPriceFl = goodsPriceList[activePriceIndex].SalesUnitCost;
            }
        }
        /// <summary>
        /// �d�����z�Z�o����
        /// </summary>
        /// <param name="stockPriceTaxExc"></param>
        /// <param name="stock"></param>
        private void GetStockPriceTaxExc( out long stockPriceTaxExc, Stock stock )
        {
            stockPriceTaxExc = (Int64)Round((decimal)stock.StockUnitPriceFl * (decimal)stock.SupplierStock);

            // --- ADD 2009/03/19 ��QID:12231�Ή�------------------------------------------------------>>>>>
            ArrayList retList;
            StockMngTtlSt stockMngTtlSt = new StockMngTtlSt();

            int status = this._stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == 0)
            {
                foreach (StockMngTtlSt result in retList)
                {
                    if ((result.LogicalDeleteCode == 0) && (result.SectionCode.Trim() == "00"))
                    {
                        stockMngTtlSt = result.Clone();
                        break;
                    }
                }
            }
            else
            {
                stockMngTtlSt = new StockMngTtlSt();
            }

            switch (stockMngTtlSt.FractionProcCd)
            {
                case 1: // �؎̂�
                    {
                        stockPriceTaxExc = (Int64)Math.Floor((decimal)stock.StockUnitPriceFl * (decimal)stock.SupplierStock);
                        break;
                    }
                case 2: // �l�̌ܓ�
                    {
                        stockPriceTaxExc = (Int64)Round((decimal)stock.StockUnitPriceFl * (decimal)stock.SupplierStock);
                        break;
                    }
                case 3: // �؏グ
                    {
                        stockPriceTaxExc = (Int64)Math.Ceiling((decimal)stock.StockUnitPriceFl * (decimal)stock.SupplierStock);
                        break;
                    }
            }
            // --- ADD 2009/03/19 ��QID:12231�Ή�------------------------------------------------------<<<<<
        }
        /// <summary>
        /// �l�̌ܓ�����
        /// </summary>
        /// <param name="parameter">�[����������decimal�l</param>
        /// <returns>�l�̌ܓ����ꂽdecimal</returns>
        private static decimal Round( decimal parameter )
        {
            // �l�̌ܓ�
            return Round( parameter, 0, 5 );
        }
        /// <summary>
        /// �l�̌ܓ�����
        /// </summary>
        /// <param name="parameter">�[����������Double�l</param>
        /// <param name="digits">�����_�ȉ��̗L������</param>
        /// <param name="divide">�؂�グ�鋫�E�̒l 1�`9�@(ex. 5���l�̌ܓ�)</param>
        /// <returns>�l�̌ܓ����ꂽdecimal</returns>
        private static decimal Round( decimal parameter, int digits, int divide )
        {
            decimal dCoef = (decimal)Math.Pow( 10, digits );
            decimal dDiv = 1.0m - ((decimal)divide / 10);

            if ( parameter > 0 )
            {
                // 0.5�𑫂��āu�{�̂Ƃ��̐؂�̂āv�i�[���ɋ߂Â���j
                return Math.Floor( (parameter * dCoef) + dDiv ) / dCoef;
            }
            else
            {
                // -0.5�𑫂��āu�|�̂Ƃ��̐؂�̂āv�i�[���ɋ߂Â���j
                return Math.Ceiling( (parameter * dCoef) - dDiv ) / dCoef;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/10 ADD

        /// <summary>
        /// �w������Y���݌ɏ��f�[�^�I�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="stockList">�݌Ƀf�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns>�݌Ƀf�[�^�I�u�W�F�N�g</returns>
        public Stock GetStockFromStockList( string warehouseCode, int goodsMakerCd, string goodsNo, List<Stock> stockList )
        {
            Stock retStock = null;
            foreach ( Stock stock in stockList )
            {
                if ( (stock.WarehouseCode.Trim() == warehouseCode.Trim()) &&
                    (stock.GoodsMakerCd == goodsMakerCd) &&
                    (stock.GoodsNo == goodsNo) )
                {
                    retStock = stock;
                }
            }
            return retStock;
        }
    }
}
