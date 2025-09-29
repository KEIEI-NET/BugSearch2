// �V�X�e��         : PM.NS
// �v���O��������   : �������i���i����
// �v���O�����T�v   : �������i���i�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �������i���i�����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������i���i�����̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009/04/28</br>
    /// </remarks>
    public class GoodsInfoAcs
    {
        #region �� Private Members


        /// <summary> ���[�o�͐ݒ�A�N�Z�X�N���X </summary>
        private PrtOutSetAcs _prtOutSetAcs;

        /// <summary> �������i���i�����A�N�Z�X�N���X </summary>
        private IGoodsInfoWorkDB _iGoodsInfoWorkDB;

        #endregion �� Private Members


        # region �� Constractor
        /// <summary>
        /// �������i���i�����A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������i���i�����̃A�N�Z�X�N���X�̃R���X�g���N�^�ł��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public GoodsInfoAcs()
        {
            this._prtOutSetAcs = new PrtOutSetAcs();

            string errMsg=string.Empty;
            this._iGoodsInfoWorkDB = (IGoodsInfoWorkDB)MediationGoodsInfoWorkDB.GetGoodsInfoWorkDB();
        }
        # endregion �� Constractor


        #region �� Public Methods
        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            prtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                status = this._prtOutSetAcs.Read(out prtOutSet, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    default:
                        errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                prtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return (status);
        }


        /// <summary>
        /// �������i���i�����X�V����
        /// </summary>
        /// <param name="trustStockResultList">�������i���i�����f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������i���i�������X�V���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public int WriteGoodsInfo(out object countNum, out object writeError, GoodsInfoCndtn goodsInfoCndtn, List<GoodsInfoData> normalGoodsInfoLst, List<GoodsInfoData> warnGoodsInfoLst, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            countNum = null;
            writeError = null;
            ArrayList normalGoodsInfoDataWorkLst = new ArrayList();

            ArrayList warnGoodsInfoDataWorkLst = new ArrayList();

            if (((null != normalGoodsInfoLst) && (normalGoodsInfoLst.Count > 0))
                || ((null != warnGoodsInfoLst) && (warnGoodsInfoLst.Count > 0)))
            {
                if ((null != normalGoodsInfoLst) && (normalGoodsInfoLst.Count > 0))
                {
                    status = this.DevGoodsInfoData(normalGoodsInfoLst, out normalGoodsInfoDataWorkLst, out errMsg);

                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        return status;
                    }
                }

                if ((null != warnGoodsInfoLst) && (warnGoodsInfoLst.Count > 0))
                {
                    status = this.DevGoodsInfoData(warnGoodsInfoLst, out warnGoodsInfoDataWorkLst, out errMsg);

                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        return status;
                    }
                }
            }

            GoodsInfoCndtnWork goodsInfoCndtnWork = new GoodsInfoCndtnWork();

            
            // ���o�����W�J  --------------------------------------------------------------
            status = this.DevGoodsInfoMainCndtn(goodsInfoCndtn, out goodsInfoCndtnWork, out errMsg);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            object normalGoodsInfoData = normalGoodsInfoDataWorkLst;
            object warnGoodsInfoData = warnGoodsInfoDataWorkLst;
            status = this._iGoodsInfoWorkDB.WriteGoodsInfo(out countNum, out writeError, ref normalGoodsInfoData, ref warnGoodsInfoData, goodsInfoCndtnWork);
            return status;
        }

        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="AcceptAnOrderReportCndtn">UI���o�����N���X</param>
        /// <param name="extrInfo_AcceptAnOrderReportWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s���܂��B</br>		
        /// <br>Programmer : ���痈</br>		
        /// <br>Date       : 2009/04/28</br>		
        /// </remarks>		
        private int DevGoodsInfoData(List<GoodsInfoData> goodsInfoDataLst, out ArrayList goodsInfoDataWorkLst, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            GoodsInfoDataWork tempGoodsInfoDataWork = null;
            goodsInfoDataWorkLst = new ArrayList();
            try
            {
                foreach (GoodsInfoData tempGoodsInfoData in goodsInfoDataLst)
                {
                    tempGoodsInfoDataWork = new GoodsInfoDataWork();
                    tempGoodsInfoDataWork.BLGoodsCode = tempGoodsInfoData.BLGoodsCode;
                    tempGoodsInfoDataWork.FileCreateDateTime = tempGoodsInfoData.FileCreateDateTime;
                    tempGoodsInfoDataWork.EnterpriseCode = tempGoodsInfoData.EnterpriseCode;
                    tempGoodsInfoDataWork.GoodsMakerCd = tempGoodsInfoData.GoodsMakerCd;
                    tempGoodsInfoDataWork.GoodsName = tempGoodsInfoData.GoodsName;
                    tempGoodsInfoDataWork.GoodsNo = tempGoodsInfoData.GoodsNo;
                    tempGoodsInfoDataWork.GoodsTraderCd = tempGoodsInfoData.GoodsTraderCd;
                    tempGoodsInfoDataWork.KindCd = tempGoodsInfoData.KindCd;
                    tempGoodsInfoDataWork.LoginFlg = tempGoodsInfoData.LoginFlg;
                    tempGoodsInfoDataWork.PdfStatus = tempGoodsInfoData.PdfStatus;
                    tempGoodsInfoDataWork.Price = tempGoodsInfoData.Price;
                    tempGoodsInfoDataWork.Price1 = tempGoodsInfoData.Price1;
                    tempGoodsInfoDataWork.Price2 = tempGoodsInfoData.Price2;
                    tempGoodsInfoDataWork.Price3 = tempGoodsInfoData.Price3;
                    tempGoodsInfoDataWork.PriceStartDate = tempGoodsInfoData.PriceStartDate;
                    tempGoodsInfoDataWork.SalesUnitCost = tempGoodsInfoData.SalesUnitCost;
                    tempGoodsInfoDataWork.StockRate = tempGoodsInfoData.StockRate;
                    tempGoodsInfoDataWork.SupplierCd = tempGoodsInfoData.SupplierCd;

                    goodsInfoDataWorkLst.Add(tempGoodsInfoDataWork);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="AcceptAnOrderReportCndtn">UI���o�����N���X</param>
        /// <param name="extrInfo_AcceptAnOrderReportWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s���܂��B</br>		
        /// <br>Programmer : ���痈</br>		
        /// <br>Date       : 2009/04/28</br>		
        /// </remarks>		
        private int DevGoodsInfoMainCndtn(GoodsInfoCndtn goodsInfoCndtn, out GoodsInfoCndtnWork goodsInfoCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            goodsInfoCndtnWork = new GoodsInfoCndtnWork();

            try
            {
                goodsInfoCndtnWork.EnterpriseCode = goodsInfoCndtn.EnterpriseCode;

                goodsInfoCndtnWork.UpdateType = goodsInfoCndtn.UpdateType;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }



        #endregion



        #endregion �� Public Methods


        #region �� Private Methods


        #endregion �� Private Methods
    }
}
