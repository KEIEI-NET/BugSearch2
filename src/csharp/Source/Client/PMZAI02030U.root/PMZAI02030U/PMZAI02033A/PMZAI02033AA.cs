using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����c�N���A�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����c�N���A�̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.10.23</br>
    /// <br>Update Note: 2009.02.02 30452 ��� �r��</br>
    /// <br>            �E�r�����䏈���ǉ��B</br>
    /// <br>Update Note: 2009/12/16 ������</br>
    /// <br>            �E���i�Ǘ����}�X�^�̎d������Q�Ƃ���悤�ɕύX</br>
    /// <br>Update Note: 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/22 30517 �Ė� �x��</br>
    /// <br>            �E���i���������̑��̏��i�ɑ΂��ăN���A������������Ȃ��s��̏C��</br>
    /// <br>Update Note: 2010/08/02 22018 ��� ���b</br>
    /// <br>            �E�݌Ƀ}�X�^�̔����c�͎d���f�[�^�������Z�����Ƀ[�����Œ�ŃZ�b�g����悤�ύX</br>
    /// <br>Update Note: 2011/04/11 liyp</br>
    /// <br>           : ��ʂŎd�����͈͎w�肵�Ă��S�f�[�^�̔����c���N���A�����s��C��</br>
    /// </remarks>
    public class SalesOrderRemainClearAcs
    {
        #region �� �R���X�g���N�^
        public SalesOrderRemainClearAcs()
        {
        }
        #endregion

        #region public���\�b�h
        /// <summary>
        /// �����c�N���A���s
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClear"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
        /// <br>Update Note: 2011/04/11 liyp</br>
        /// <br>           : ��ʂŎd�����͈͎w�肵�Ă��S�f�[�^�̔����c���N���A�����s��C��</br>
        /// </remarks>
        public int Clear(ExtrInfo_SalesOrderRemainClear extrInfo_SalesOrderRemainClear, out string msg)
        {
            msg = string.Empty;
            int status = 0;

            ExtrInfo_SalesOrderRemainClearWork extrInfo_SalesOrderRemainClearWork;
            
            // ���������ݒ�
            this.SetClearParameter(extrInfo_SalesOrderRemainClear, out extrInfo_SalesOrderRemainClearWork);         

            // ���s
            ISalesOrderRemainClearDB mediationSalesOrderRemainClearDB =
                (ISalesOrderRemainClearDB) MediationSalesOrderRemainClearDB.GetSalesOrderRemainClearDB();

            //status = mediationSalesOrderRemainClearDB.SearchUpdate(extrInfo_SalesOrderRemainClearWork);// DEL 2009/12/16
            // -------------ADD 2009/12/16------------->>>>>
            // -------------UPD 2010/06/08------------->>>>>
            //object resultList = null;
            object stockDetailResultList = null;
            bool updateStatus = false;
            // ���i�Ǘ����}�X�^�擾�p
            GoodsAcs _goodsAcs = new GoodsAcs();
            //status = mediationSalesOrderRemainClearDB.Search(out resultList, extrInfo_SalesOrderRemainClearWork);
            status = mediationSalesOrderRemainClearDB.SearchStockDetail(out stockDetailResultList, extrInfo_SalesOrderRemainClearWork);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList stockDetailResultData = stockDetailResultList as ArrayList;
                foreach (StockDetailWork sdw in stockDetailResultData)
                {
                    object resultList = null;
                    status = mediationSalesOrderRemainClearDB.SearchStock(out resultList, sdw);
                    // -------------UPD 2010/06/08-------------<<<<<
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList resultData = resultList as ArrayList;
                        if (resultData != null)
                        {
                            // ���i�Ǘ��݌ɃN���X����d��������擾���A�Ȃ��ꍇ�͌��ʂƂ��ĕԂ��Ȃ�
                            List<GoodsUnitData> unitDataList = new List<GoodsUnitData>();
                            GoodsUnitData unitData = new GoodsUnitData();
                            string message = string.Empty;
                            ArrayList al = new ArrayList();
                            int st_SupplierCd = extrInfo_SalesOrderRemainClearWork.St_SupplierCd;
                            int ed_SupplierCd = extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd;
                            // ���.�d���斢���͂����ꍇ
                            if (st_SupplierCd == 0 && ed_SupplierCd == 999999)
                            {
                                al = resultData;
                            }
                            else
                            {
                                foreach (StockWork sw in resultData)
                                {
                                    int status_1 = 0;
                                    // �݌Ƀ}�X�^�̔����悪���ݒ�̏ꍇ
                                    if (sw.StockSupplierCode == 0)
                                    {
                                        // ���i�݌ɊǗ��N���X������
                                        GoodsCndtn condition = new GoodsCndtn();
                                        condition.EnterpriseCode = sw.EnterpriseCode;
                                        condition.SectionCode = sw.SectionCode;
                                        condition.GoodsMakerCd = sw.GoodsMakerCd;
                                        condition.GoodsNo = sw.GoodsNo;
                                        // 2010/06/22 Add ���i�����Ɋւ�炸�N���A���� >>>
                                        condition.GoodsKindCode = 9;
                                        // 2010/06/22 Add <<<
                                        //SearchStockAcs.LogWrite("�����i�����@�J�n");
                                        status_1 = _goodsAcs.Search(condition, out unitDataList, out message);
                                        //SearchStockAcs.LogWrite("�����i�����@�I��");
                                        if (status_1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            unitData = unitDataList[0];
                                            _goodsAcs.SettingGoodsUnitDataFromVariousMst(ref unitData);
                                            // ���i�Ǘ����}�X�^.�d���悪����ꍇ
                                            if (unitData.SupplierCd != 0)
                                            {
                                                CheckData(ref al, st_SupplierCd, ed_SupplierCd, unitData.SupplierCd, sw);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        CheckData(ref al, st_SupplierCd, ed_SupplierCd, sw.StockSupplierCode, sw);
                                    }

                                }
                            }
                            //�f�[�^������ꍇ
                            if (al.Count > 0)
                            {
                                // -------------UPD 2010/06/08------------->>>>>
                                //status = mediationSalesOrderRemainClearDB.Update(al);
                                // --- UPD m.suzuki 2010/08/02 ---------->>>>>
                                //status = mediationSalesOrderRemainClearDB.Update(al, sdw);
                                status = mediationSalesOrderRemainClearDB.UpdateStockDetail( sdw ); // �d���f�[�^�X�V
                                // --- UPD m.suzuki 2010/08/02 ----------<<<<<
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    updateStatus = true;
                                }
                                // -------------UPD 2010/06/08-------------<<<<<
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }
                        }
                    }
                    // -------------ADD 2010/06/08------------->>>>>
                }
                if (updateStatus)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            // -------------ADD 2010/06/08-------------<<<<<
            // --- ADD m.suzuki 2010/08/02 ---------->>>>>
            if ( status != (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT &&
                 status != (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT &&
                 status != (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT )
            {
                // �݌Ƀ}�X�^�̔����c���N���A
                // status = mediationSalesOrderRemainClearDB.SearchUpdate( extrInfo_SalesOrderRemainClearWork ); // DEL 2011/04/01
                // -------------ADD 2011/04/11------------->>>>>
                object resultList2 = null;
                status = mediationSalesOrderRemainClearDB.Search(out resultList2, extrInfo_SalesOrderRemainClearWork);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultData2 = resultList2 as ArrayList;
                    if (resultData2 != null)
                    {
                        // ���i�Ǘ��݌ɃN���X����d��������擾���A�Ȃ��ꍇ�͌��ʂƂ��ĕԂ��Ȃ�
                        List<GoodsUnitData> unitDataList2 = new List<GoodsUnitData>();
                        GoodsUnitData unitData2 = new GoodsUnitData();
                        string message = string.Empty;
                        ArrayList al = new ArrayList();
                        int st_SupplierCd = extrInfo_SalesOrderRemainClearWork.St_SupplierCd;
                        int ed_SupplierCd = extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd;
                        // ���.�d���斢���͂����ꍇ
                        if (st_SupplierCd == 0 && ed_SupplierCd == 999999)
                        {
                            al = resultData2;
                        }
                        else
                        {
                            foreach (StockWork sw in resultData2)
                            {
                                int status_1 = 0;
                                // �݌Ƀ}�X�^�̔����悪���ݒ�̏ꍇ
                                if (sw.StockSupplierCode == 0)
                                {
                                    // ���i�݌ɊǗ��N���X������
                                    GoodsCndtn condition = new GoodsCndtn();
                                    condition.EnterpriseCode = sw.EnterpriseCode;
                                    condition.SectionCode = sw.SectionCode;
                                    condition.GoodsMakerCd = sw.GoodsMakerCd;
                                    condition.GoodsNo = sw.GoodsNo;
                                    condition.GoodsKindCode = 9; // ���i�����Ɋւ�炸�N���A����
                                    //SearchStockAcs.LogWrite("�����i�����@�J�n");
                                    status_1 = _goodsAcs.Search(condition, out unitDataList2, out message);
                                    //SearchStockAcs.LogWrite("�����i�����@�I��");
                                    if (status_1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        unitData2 = unitDataList2[0];
                                        _goodsAcs.SettingGoodsUnitDataFromVariousMst(ref unitData2);
                                        // ���i�Ǘ����}�X�^.�d���悪����ꍇ
                                        if (unitData2.SupplierCd != 0)
                                        {
                                            CheckData(ref al, st_SupplierCd, ed_SupplierCd, unitData2.SupplierCd, sw);
                                        }
                                    }
                                }
                                else
                                {
                                    CheckData(ref al, st_SupplierCd, ed_SupplierCd, sw.StockSupplierCode, sw);
                                }

                            }
                        }
                        //�f�[�^������ꍇ
                        if (al.Count > 0)
                        {
                            status = mediationSalesOrderRemainClearDB.Update(al);
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }
                }
                // -------------ADD 2011/04/11-------------<<<<<
            }
            // --- ADD m.suzuki 2010/08/02 ----------<<<<<

            // -------------ADD 2009/12/16-------------<<<<<
            switch (status)
            {
                // --- ADD 2009/02/02 -------------------------------->>>>>
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    msg = "�V�F�A�`�F�b�N�G���[(��ƃ��b�N)�ł��B" + "\r\n"
                            + "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n"
                            + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B" + "\r\n";
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    msg = "�V�F�A�`�F�b�N�G���[(���_���b�N)�ł��B" + "\r\n"
                        + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                        + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B" + "\r\n";
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    msg = "�V�F�A�`�F�b�N�G���[(�q�Ƀ��b�N)�ł��B" + "\r\n"
                        + "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                        + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B" + "\r\n";
                    break;
                // --- ADD 2009/02/02 --------------------------------<<<<<
            }

            return status;
        }

        // ----------ADD 2009/12/16------------>>>>>
        /// <summary>
        /// �݌Ƀf�[�^�̃`�F�b�N
        /// </summary>
        /// <remarks>
        /// <param name="al">al</param>
        /// <param name="st_SupplierCd">��ʂ̊J�n�d����</param>
        /// <param name="ed_SupplierCd">��ʂ̏I���d����</param>
        /// <param name="supplier">�݌Ƀf�[�^�̎d����</param>
        /// <param name="sw">�݌Ƀf�[�^</param>
        /// <br>Note       : �݌Ƀf�[�^�̃`�F�b�N���s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.12.16</br>
        /// </remarks>
        private void CheckData(ref ArrayList al, int st_SupplierCd, int ed_SupplierCd, int supplier, StockWork sw)
        {
            // �J�n�d����ƏI���d������͂����ꍇ
            if (st_SupplierCd != 0 && ed_SupplierCd != 999999)
            {
                if (supplier >= st_SupplierCd && supplier <= ed_SupplierCd)
                {
                    al.Add(sw);
                }
            }
            // �J�n�d������͂����ꍇ
            else if (st_SupplierCd != 0 && ed_SupplierCd == 999999)
            {
                if (supplier >= st_SupplierCd)
                {
                    al.Add(sw);
                }
            }
            // �I���d������͂����ꍇ
            else if (st_SupplierCd == 0 && ed_SupplierCd != 999999)
            {
                if (supplier <= ed_SupplierCd)
                {
                    al.Add(sw);
                }
            }
        }
        // ----------ADD 2009/12/16------------<<<<<
        #endregion

        #region �� private���\�b�h
        /// <summary>
        /// �����[�g���o�����ݒ�
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClear"></param>
        /// <param name="extrInfo_SalesOrderRemainClearWork"></param>
        /// <remarks>
        /// <br>Update Note: 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
        /// </remarks>
        private void SetClearParameter(ExtrInfo_SalesOrderRemainClear extrInfo_SalesOrderRemainClear,
                                        out ExtrInfo_SalesOrderRemainClearWork extrInfo_SalesOrderRemainClearWork)
        {
            extrInfo_SalesOrderRemainClearWork = new ExtrInfo_SalesOrderRemainClearWork();

            extrInfo_SalesOrderRemainClearWork.EnterpriseCode = extrInfo_SalesOrderRemainClear.EnterpriseCode;
            extrInfo_SalesOrderRemainClearWork.St_WarehouseCode = extrInfo_SalesOrderRemainClear.St_WarehouseCode;
            extrInfo_SalesOrderRemainClearWork.Ed_WarehouseCode = extrInfo_SalesOrderRemainClear.Ed_WarehouseCode;
            extrInfo_SalesOrderRemainClearWork.St_SupplierCd = extrInfo_SalesOrderRemainClear.St_SupplierCd;
            extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd = extrInfo_SalesOrderRemainClear.Ed_SupplierCd;
            // ----------DEL 2010/06/08------------>>>>>
            //extrInfo_SalesOrderRemainClearWork.St_GoodsMakerCd = extrInfo_SalesOrderRemainClear.St_GoodsMakerCd;
            //extrInfo_SalesOrderRemainClearWork.Ed_GoodsMakerCd = extrInfo_SalesOrderRemainClear.Ed_GoodsMakerCd;
            //extrInfo_SalesOrderRemainClearWork.St_BLGoodsCode = extrInfo_SalesOrderRemainClear.St_BLGoodsCode;
            //extrInfo_SalesOrderRemainClearWork.Ed_BLGoodsCode = extrInfo_SalesOrderRemainClear.Ed_BLGoodsCode;
            // ----------DEL 2010/06/08------------<<<<<
        }
        #endregion
    }
}
