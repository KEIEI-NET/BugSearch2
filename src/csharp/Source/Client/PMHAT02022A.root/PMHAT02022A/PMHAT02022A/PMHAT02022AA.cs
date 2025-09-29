//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^���X�g�A�N�Z�X�N���X
// �v���O�����T�v   : �����_�ݒ�}�X�^���X�g�ꗗ�Ŏg�p����f�[�^���擾����
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/04/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Data;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����_�ݒ�}�X�^���X�g�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ�}�X�^���X�g�ꗗ�Ŏg�p����f�[�^���擾����</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.03.26</br>
    /// </remarks>
    public class OrderSetMasListReportAcs
    {
        #region �� Private Member
        // �����_�ݒ�}�X�^���X�g�����C���^�t�F�[�X
        private IOrderSetMasListDB _iOrderSetMasListDB;

        // DataSet�I�u�W�F�N�g
        private DataSet _dataSet;
        #endregion

        #region �� Public Property
        /// <summary>
        /// �f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet DataSet
        {
            get { return this._dataSet; }
        }
        #endregion �� Public Property

        #region �� �R���X�g���N�^
        /// <summary>
        /// �����_�ݒ�}�X�^���X�g�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public OrderSetMasListReportAcs()
        {
            _iOrderSetMasListDB = (IOrderSetMasListDB)MediationOrderSetMasListDB.GetOrderSetMasListDB();
        }
        #endregion

        #region �� �����_�ݒ�}�X�^���X�g��񌟍�
        /// <summary>
        /// �����_�ݒ�}�X�^���X�g�f�[�^�擾����
        /// </summary>
        /// <param name="para">��������</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Search(OrderSetMasListPara para, out string errMsg)
        {
            return this.SearchProc(para, out errMsg);
        }

        /// <summary>
        /// �����_�ݒ�}�X�^���X�g�f�[�^�擾
        /// </summary>
        /// <param name="para">��������</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private int SearchProc( OrderSetMasListPara para, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;

            // DataTable Create ----------------------------------------------------------
            PMHAT02025EA.CreateDataTable(ref _dataSet);

            OrderSetMasListParaWork paraWork = new OrderSetMasListParaWork();


            // ���o�����W�J<��ʌ������->remoteDean>  --------------------------------------------------------------
            status = this.SetCondInfo(ref para, out paraWork, out errMsg);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // �f�[�^�擾  ----------------------------------------------------------------
            object retList = null;
            object paraWorkRef = paraWork;

            status = _iOrderSetMasListDB.Search(out retList, ref paraWorkRef);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    //remote -> dataset
                    ConverToDataSetForPdf(_dataSet.Tables[PMHAT02025EA.Tbl_OrderSetMasListReportData], (ArrayList)retList);
                   
                    if (this._dataSet.Tables[PMHAT02025EA.Tbl_OrderSetMasListReportData].Rows.Count < 1)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    }
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    break;
                default:
                    errMsg = "�����_�ݒ�}�X�^�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
                    break;
            }
            return status;
        }
        #endregion

        #region �� ���o�����ݒ�
        /// <summary>
        /// ���o�����ݒ菈��
        /// </summary>
        /// <param name="condition">UI���o�����N���X</param>
        /// <param name="dRemoteCondition">�����[�g���o�����N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private int SetCondInfo(ref OrderSetMasListPara condition, out OrderSetMasListParaWork dRemoteCondition, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            dRemoteCondition = new OrderSetMasListParaWork();
            errMsg = string.Empty;
            try
            {   // ��ƃR�[�h
                dRemoteCondition.EnterpriseCode = condition.EnterpriseCode;

                // �ݒ�R�[�h�i�J�n�j
                dRemoteCondition.StartSetCode = condition.StartSetCode;

                //  �ݒ�R�[�h�i�I���j
                dRemoteCondition.EndSetCode = condition.EndSetCode;

                // �q�ɃR�[�h�i�J�n�j
                dRemoteCondition.StartWarehouseCode= condition.StartWarehouseCode;

                // �q�ɃR�[�h�i�I���j
                dRemoteCondition.EndWarehouseCode = condition.EndWarehouseCode;

                // �d����R�[�h�i�J�n�j
                dRemoteCondition.StartSupplierCd = condition.StartSupplierCd;

                // �d����R�[�h�i�I���j
                dRemoteCondition.EndSupplierCd = condition.EndSupplierCd;

                // �����ރR�[�h�i�J�n�j
                dRemoteCondition.StartGoodsMGroup = condition.StartGoodsMGroup;

                // �����ރR�[�h�i�I���j
                dRemoteCondition.EndGoodsMGroup = condition.EndGoodsMGroup;

               // �O���[�v�R�[�h�i�J�n�j
                dRemoteCondition.StartBLGroupCode = condition.StartBLGroupCode;

                // �O���[�v�R�[�h�i�I���j
                dRemoteCondition.EndBLGroupCode = condition.EndBLGroupCode;

                 // �a�k�R�[�h�i�J�n�j
                dRemoteCondition.StartBLGoodsCode = condition.StartBLGoodsCode;

                // �a�k�R�[�h�i�I���j
                dRemoteCondition.EndBLGoodsCode = condition.EndBLGoodsCode;
               
                 // ���[�J�[�R�[�h�i�J�n�j
                dRemoteCondition.StartGoodsMakerCd = condition.StartGoodsMakerCd;

                // ���[�J�[�R�[�h�i�I���j
                dRemoteCondition.EndGoodsMakerCd = condition.EndGoodsMakerCd;

                // ���s�^�C�v
                dRemoteCondition.PrintType = condition.PrintType;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region �� DataTable�Ƀf�[�^�ݒ�
        /// <summary>
        /// DataTable�Ƀf�[�^��ݒ菈��
        /// </summary>
        /// <param name="dataTable">���[�pDataTable</param>
        /// <param name="retList">������񃊃X�g</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList)
        {
            for (int i = 0; i < retList.Count; i++)
            {
                OrderSetMasListWork rsltInfo = (OrderSetMasListWork)retList[i];
                DataRow dr = null;
                dr = dataTable.NewRow();
                // �ݒ�R�[�h
                dr[PMHAT02025EA.Col_SetCode] = rsltInfo.PatterNo.ToString("D3");
                // �q�ɃR�[�h
                dr[PMHAT02025EA.Col_WarehouseCodeRF] = rsltInfo.WarehouseCode.PadLeft(4, '0');
                // �q�ɖ���
                dr[PMHAT02025EA.Col_WarehouseNameRF] = rsltInfo.WarehouseName;
                // �d����R�[�h
                dr[PMHAT02025EA.Col_SupplierCdRF] = rsltInfo.SupplierCd.PadLeft(6, '0');
                // �d���於��
                dr[PMHAT02025EA.Col_SupplierNameRF] = rsltInfo.SupplierSnm;
                // ���[�J�[�R�[�h
                dr[PMHAT02025EA.Col_GoodsMakerCdRF] = rsltInfo.GoodsMakerCd.PadLeft(4, '0');
                // ���[�J�[����
                dr[PMHAT02025EA.Col_GoodsMakerNameRF] = rsltInfo.MakerName;
                // �����ރR�[�h
                dr[PMHAT02025EA.Col_GoodsMGroupCdRF] = rsltInfo.GoodsMGroup.PadLeft(4, '0');
                // �����ޖ���
                dr[PMHAT02025EA.Col_GoodsMGroupNameRF] = rsltInfo.GoodsMGroupName;
                // BL�O���[�v�R�[�h
                dr[PMHAT02025EA.Col_BLGroupCodeRF] = rsltInfo.BLGroupCode.PadLeft(5, '0');
                // BL�O���[�v����
                dr[PMHAT02025EA.Col_BLGroupNameRF] = rsltInfo.BLGroupName;
                // BL���i�R�[�h
                dr[PMHAT02025EA.Col_BLGoodsCodeRF] = rsltInfo.BLGoodsCode.PadLeft(5, '0');                // BL���i�R�[�h����
                dr[PMHAT02025EA.Col_BLGoodsNameRF] = rsltInfo.BLGoodsHalfName;
                // �݌ɏo�בΏۊJ�n��
                dr[PMHAT02025EA.Col_StckShipMonthStRF] = rsltInfo.StckShipMonthSt;
                // �݌ɏo�בΏۏI����
                dr[PMHAT02025EA.Col_StckShipMonthEdRF] = rsltInfo.StckShipMonthEd;
                // �݌ɓo�^��
                dr[PMHAT02025EA.Col_StockCreateDateRF] = rsltInfo.StockCreateDate;
                // �o�א��͈�(�ȏ�)
                dr[PMHAT02025EA.Col_ShipScopeMoreRF] = rsltInfo.ShipScopeMore;
                // �o�א��͈�(�ȉ�)
                dr[PMHAT02025EA.Col_ShipScopeLessRF] = rsltInfo.ShipScopeLess;
                // �Œ�݌ɐ�
                dr[PMHAT02025EA.Col_MinimumStockCntRF] = rsltInfo.MinimumStockCnt;
                // �ō��݌ɐ�
                dr[PMHAT02025EA.Col_MaximumStockCntRF] = rsltInfo.MaximumStockCnt;
                // ���b�g��
                dr[PMHAT02025EA.Col_SalesOrderUnitRF] = rsltInfo.SalesOrderUnit;
                // �����_�����X�V�t���O
                dr[PMHAT02025EA.Col_OrderPProcUpdFlgRF] = rsltInfo.OrderPProcUpdFlg;
                // �敪
                dr[PMHAT02025EA.Col_OrderApplyDivRF] = rsltInfo.OrderApplyDiv;

                dataTable.Rows.Add(dr);
            }
        }

        #endregion

        #region �� Private Mehtods
        /// <summary>
        /// ������f���؂鏈��
        /// </summary>
        /// <param name="useName">������</param>
        /// <param name="byteLength">�f���؂�T�C�Y</param>
        private string GetStringToByte(string useName, int byteLength)
        {
            if (string.IsNullOrEmpty(useName))
            {
                return string.Empty;
            }

            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(useName);
            int n = 0;  //  ���Y�̊���
            int i;  //  �\���̊���
            if (bytes.GetLength(0) < byteLength)
            {
                return useName;
            }
            for (i = 0; i < bytes.GetLength(0) && n < byteLength; i++)
            {
                //  
                if (i % 2 == 0)
                {
                    n++;      //  
                }
                else
                {
                    //  
                    if (bytes[i] > 0)
                    {
                        n++;
                    }
                }

            }
            //  
            if (i % 2 == 1)
            {
                // 
                if (bytes[i] > 0)
                    i = i - 1;
                 //  
                else
                    i = i + 1;
            }
            return System.Text.Encoding.Unicode.GetString(bytes, 0, i);
        }
        #endregion
    }
}
