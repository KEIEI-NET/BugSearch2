//****************************************************************************//
// �V�X�e��         : PMTAB �����񓚏���(�f�[�^�o�^)
// �v���O��������   : PMTAB �����񓚏���(�f�[�^�o�^)�A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : zhubj
// �� �� ��  2013/05/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37832 �y�����񓚏���(�f�[�^�o�^�j�z
//                   ���㖾�׃f�[�^�o�^���ABL�O���[�v���́i�|���j��BL�O���[�v���̂��Z�b�g����Ă��܂��� //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : songg                                                    //
// Date            : 2013/07/04                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38976  �l��������͂��ēo�^����ƁA�ُ�ȂقǏd��//
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/23                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39126  �����`�[�̓E�v���������Ȃ��Ή�          �@//
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : �A����                                                   //
// Date            : 2013/07/24                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39026 �s�l�����̔��㕔�i���v(�ō�)���C��         //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/24                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39486 ���[�J�[���E�d���於�ݒ�@�@�@�@�@         //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : �O��                                                     //
// Date            : 2013/08/01                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39637�@�L�����y�[���R�[�h�̐ݒ�
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �g��
// Date            : 2013/08/06
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39979 �񓚏������i�ԍ��̐ݒ�
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �g��
// Date            : 2013/08/16
//----------------------------------------------------------------------------//
// Update Note     : Redmine#40183 �������i���[�J�[�R�[�h�ݒ�
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : ����
// Date            : 2013/08/29
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39979 �񓚏������i�ԍ��̐ݒ�
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �g��
// Date            : 2013/08/30
//----------------------------------------------------------------------------//
// Update Note     : Tablet�ł̔��㎞�ɔ��㖾�ׂ̏������[�J�[�����o�^�ɂȂ��Q���C��
// �Ǘ��ԍ�        : 11070148-00
// Programmer      : �{�{
// Date            : 2014/09/08
//----------------------------------------------------------------------------//

using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PMTAB �����񓚏���(�f�[�^�o�^)�A�N�Z�X�N���X
    /// </summary>
    public partial class TabSCMSalesDataMaker
    {
        #region Private Members
        // �i�Ԍ����A�N�Z�X
        private static GoodsAcs _goodsAcs;
        private GoodsAcs GetGoodsAcs
        {
            get
            {
                if (_goodsAcs == null) _goodsAcs = new GoodsAcs();
                return _goodsAcs;
            }
        }

        // �]�ƈ��A�N�Z�X
        private EmployeeAcs _employeeAcs;
        private EmployeeAcs GetEmployeeAcs
        {
            get
            {
                if (_employeeAcs == null) _employeeAcs = new EmployeeAcs();
                return _employeeAcs;
            }
        }

        // ���_����A�N�Z�X
        private SecInfoAcs _secInfoAcs;
        private SecInfoAcs GetSecInfoAcs
        {
            get
            {
                if (_secInfoAcs == null) _secInfoAcs = new SecInfoAcs();
                return _secInfoAcs;
            }
        }

        // ���[�U�[�A�N�Z�X
        private UserGuideAcs _userGuideAcs;
        private UserGuideAcs GetUserGuideAcs
        {
            get
            {
                if (_userGuideAcs == null) _userGuideAcs = new UserGuideAcs();
                return _userGuideAcs;
            }
        }

        // ���Аݒ胊���[�g
        IPccCmpnyStDB _iPccCmpnyStDB;
        private IPccCmpnyStDB GetIPccCmpnyStDB
        {
            get
            {
                if (_iPccCmpnyStDB == null) _iPccCmpnyStDB = MediationPccCmpnyStDB.GetPccCmpnyStDB();
                return _iPccCmpnyStDB;
            }
        }
        
        // ���Ӑ��� 
        private CustomerInfo _customerInfo;
        // �O�񌟍����Ӑ�R�[�h
        private int _customerCodeSave;
        /// <summary>�[�������Ώۋ��z�敪�i����P���j</summary>
        private const int ctFracProcMoneyDiv_SalesUnitPrice = 2;// ADD 2013/07/24 qijh Redmine#39026

        // ADD 2013/08/01 �O�� Redmine#39486 --------->>>>>>>>>>>>>>>>>>>>>>>>
        private List<MakerUMnt> _makerUMntList = null;          // ���[�J�[�}�X�^���X�g
        private SupplierAcs supplierAcs = new SupplierAcs();    // �d����
        // ADD 2013/08/01 �O�� Redmine#39486 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/08/16 �g�� Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private List<SCMAcOdrDtlAsWork> sCMAcOdrDtlAsWorkForAnsPureGoodsNo = new List<SCMAcOdrDtlAsWork>();
        // ADD 2013/08/16 �g�� Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        #region Private Method
        /// <summary>
        /// PM���݌ɐ��擾����
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <returns>PM���݌ɐ�</returns>
        //private double GetPmPrsntCount(SalesSlipWork salesSlip, SalesDetailWork salesDetail) // DEL 2013/07/03 qijh Redmine#37586
        private double GetPmPrsntCount(SalesSlip salesSlip, SalesDetail salesDetail) // ADD 2013/07/03 qijh Redmine#37586
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetPmPrsntCount";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            List<string> warehouseList = new List<string>();
            // �ϑ��A�D��q�ɂ̎擾
            // �ʐM�����FBLP
            warehouseList = this.CreatePriorWarehouseListForPccuoe(this.GetCustomerInfo(salesSlip).CustomerEpCode, this.GetCustomerInfo(salesSlip).CustomerSecCode, salesSlip.EnterpriseCode, salesSlip.SectionCode);

            // ���i���
            //GoodsUnitData goodsUnitData = GetGoodsUnitData(salesSlip, salesDetail); // DEL 2013/07/23 wangl2 FOR Redmine#38976
            // --------------- ADD START 2013/07/23 wangl2 FOR Redmine#38976------>>>>
            GoodsUnitData goodsUnitData = null;
            if (salesDetail.SalesSlipCdDtl != 2)
            {
                goodsUnitData = GetGoodsUnitData(salesSlip, salesDetail);
            }
            // --------------- ADD END 2013/07/23 wangl2 FOR Redmine#38976--------<<<<
            Stock retStock = null;
            if (goodsUnitData != null && goodsUnitData.StockList != null)
            {
                foreach (Stock stock in goodsUnitData.StockList)
                {
                    if (retStock == null)
                    {
                        for (int i = 0; i < warehouseList.Count; i++)
                        {
                            retStock = GetGoodsAcs.GetStockFromStockList(warehouseList[i], goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, goodsUnitData.StockList);
                            if (retStock != null) break;
                        }
                    }
                }
            }

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            if(retStock != null)
            {
                EasyLogger.Write(CLASS_NAME, methodName, 
                    "���[�J�[�R�[�h�F" + goodsUnitData.GoodsMakerCd
                    + "�@���i�ԍ��F" + goodsUnitData.GoodsNo
                    + "�@�q�ɃR�[�h�F" + retStock.WarehouseCode
                    + "�@�݌ɐ��F" + retStock.ShipmentCnt.ToString()
                    );
            }
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            if (retStock != null)
                return retStock.ShipmentPosCnt;
            else
                return 0.00d;
        }

        /// <summary>
        /// ����f�[�^�␳����
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="claim">���Ӑ���</param>
        //private void ReviseSalesSlip(SalesSlipWork salesSlip, CustomerInfo claim) // DEL 2013/07/03 qijh Redmine#37586
        private void ReviseSalesSlip(SalesSlip salesSlip, CustomerInfo claim) // ADD 2013/07/03 qijh Redmine#37586
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "ReviseSalesSlip";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            #region ����f�[�^�␳

            #region ����R�[�h�␳
            // �]�ƈ��ڍ׎擾
            EmployeeDtl employeeDetail = GetEmployeeDtl(salesSlip.EnterpriseCode, salesSlip.SalesEmployeeCd);
            if (employeeDetail != null)
            {
                salesSlip.SubSectionCode = employeeDetail.BelongSubSectionCode;
            }
            #endregion

            #region �����v�㋒�_�R�[�h�␳
            // �����v�㋒�_�R�[�h
            string sectionCode;
            // ���Ӑ���
            CustomerInfo customerInfo = GetCustomerInfo(salesSlip);
            GetOwnSeCtrlCode(customerInfo.ClaimSectionCode, out sectionCode);
            salesSlip.DemandAddUpSecCd = sectionCode; // �����v�㋒�_�R�[�h
            #endregion

            #region ���ьv�㋒�_�R�[�h�␳
            // ���ьv�㋒�_�R�[�h
            salesSlip.ResultsAddUpSecCd = customerInfo.MngSectionCode;
            #endregion

            #region �v����t�␳�A�����敪�␳
            SettingSalesSlipAddUpDate(ref salesSlip, claim);
            //// ADD 2013/08/01 �O�� Redmine#39549 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //if (salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) salesSlip.AddUpADate = DateTime.MinValue;
            //// ADD 2013/08/01 �O�� Redmine#39549 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion

            #region �����旪�̕␳
            // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- >>>>>
            CustomerInfo claimInfo = null;
            string outErrorMessage = null;
            ConstantManagement.MethodResult methodResult = GetCustomerInfo(salesSlip.EnterpriseCode, salesSlip.ClaimCode, out claimInfo, out outErrorMessage);
            if (ConstantManagement.MethodResult.ctFNC_NORMAL == methodResult)
                salesSlip.ClaimSnm = claimInfo.CustomerSnm; // �����旪��
            // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- <<<<<
            #endregion

            // �`�[�������ݒ�
            SetSalesSlipPrintInfo(salesSlip, claim); // ADD 2013/07/18 qijh Redmine#38565

            #endregion
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

        }

        /// <summary>
        /// ���㖾�׃f�[�^�␳����
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        //private void ReviseSalesDetail(SalesSlipWork salesSlip, SalesDetailWork salesDetail) // DEL 2013/07/03 qijh Redmine#37586
        private void ReviseSalesDetail(SalesSlip salesSlip, SalesDetail salesDetail) // ADD 2013/07/03 qijh Redmine#37586
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "ReviseSalesDetail";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            #region ���㖾�׃f�[�^�␳
            // ���[�J�[
            //GoodsUnitData goodsUnitData = GetGoodsUnitData(salesSlip, salesDetail); // DEL 2013/07/23 wangl2 FOR Redmine#38976
            // --------------- ADD START 2013/07/23 wangl2 FOR Redmine#38976------>>>>
            // DEL 2013/08/01 �O�� Redmine#39486 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //GoodsUnitData goodsUnitData = null;
            //if(salesDetail.SalesSlipCdDtl != 2)
            //{
            //    goodsUnitData = GetGoodsUnitData(salesSlip, salesDetail);
            //}
            //// --------------- ADD END 2013/07/23 wangl2 FOR Redmine#38976--------<<<<
            //if (goodsUnitData != null)
            //{
            //    // ���[�J�[����
            //    salesDetail.MakerName = goodsUnitData.MakerName;
            //    // ���[�J�[���̃J�i
            //    salesDetail.MakerKanaName = goodsUnitData.MakerKanaName;
            //    // �d���旪��
            //    salesDetail.SupplierSnm = goodsUnitData.SupplierSnm;
            //}
            // DEL 2013/08/01 �O�� Redmine#39486 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/08/01 �O�� Redmine#39486 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (salesDetail.GoodsMakerCd > 0)
            {
                // ���[�J�[���̎擾
                salesDetail.MakerName = GetName_FromMaker(salesDetail.GoodsMakerCd);
                // ���[�J�[���̃J�i
                salesDetail.MakerKanaName = GetKanaName_FromMaker(salesDetail.GoodsMakerCd);
            }
            if (salesDetail.SupplierCd > 0)
            {
                // �d���旪��
                Supplier supplier = null;
                supplierAcs.Read(out supplier, salesDetail.EnterpriseCode, salesDetail.SupplierCd);
                if (supplier != null) salesDetail.SupplierSnm = supplier.SupplierSnm;
            }

            // ADD 2013/08/01 �O�� Redmine#39486 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // BL�R�[�h�}�X�^
            BLGoodsCdUMnt bLGoodsCdUMnt;
            // �O���[�v�R�[�h�}�X�^
            BLGroupU bLGroupU;
            // ���i�����ރ}�X�^
            GoodsGroupU goodsGroupU;
            // ���i�啪�ރ}�X�^�i���[�U�[�K�C�h�j
            UserGdBdU userGdBdU;
            // BL�R�[�h�ɘA�����擾
            if (GetBLGoodsRelation(salesDetail.BLGoodsCode, out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU))
            {
                // ���i�啪�ރR�[�h
                salesDetail.GoodsLGroup = bLGroupU.GoodsLGroup;
                // ���i�啪�ޖ���
                salesDetail.GoodsLGroupName = GetGuideName(salesDetail.EnterpriseCode, 70, bLGroupU.GoodsLGroup);
                // ���i�����ޖ���
                salesDetail.GoodsMGroupName = goodsGroupU.GoodsMGroupName;
                // ���i�����ރR�[�h
                salesDetail.GoodsMGroup = bLGroupU.GoodsMGroup;

                // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- >>>>>
                if (string.IsNullOrEmpty(salesDetail.GoodsMGroupName))
                {
                    GoodsGroupU goodsMGroup = null;
                    GetGoodsAcs.GetGoodsMGroup(salesSlip.EnterpriseCode, bLGoodsCdUMnt.GoodsRateGrpCode, out goodsMGroup);
                    salesDetail.GoodsMGroupName = goodsMGroup.GoodsMGroupName;
                    salesDetail.GoodsMGroup = bLGoodsCdUMnt.GoodsRateGrpCode;
                }
                // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- <<<<<

                // BL�O���[�v�R�[�h����
                salesDetail.BLGroupName = bLGroupU.BLGroupName;
                // BL���i�R�[�h���́i�|���j
                //salesDetail.RateBLGoodsName = bLGoodsCdUMnt.BLGoodsFullName; // DEL 2013/07/19 qijh Redmine#38510
                salesDetail.RateBLGoodsName = bLGoodsCdUMnt.BLGoodsHalfName; // ADD 2013/07/19 qijh Redmine#38510
                // BL�O���[�v���́i�|���j
                //salesDetail.RateGoodsRateGrpNm = bLGroupU.BLGroupName; // DEL 2013/07/04 songg Redmine#37832
                salesDetail.RateBLGroupName = bLGroupU.BLGroupName;// ADD 2013/07/04 songg Redmine#37832
                // BL���i�R�[�h���́i����j
                //salesDetail.PrtBLGoodsName = bLGoodsCdUMnt.BLGoodsFullName; // DEL 2013/07/18 qijh Redmine#38565
                salesDetail.PrtBLGoodsName = bLGoodsCdUMnt.BLGoodsHalfName; // ADD 2013/07/18 qijh Redmine#38565
                // ���Е��ޖ���
                salesDetail.EnterpriseGanreName = GetEnterpriseGanreName(salesDetail.EnterpriseCode, 41, salesDetail.EnterpriseGanreCode);
                // ���i�|���O���[�v���́i�|���j 
                salesDetail.RateGoodsRateGrpNm = goodsGroupU.GoodsMGroupName;
                // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- >>>>>
                if (string.IsNullOrEmpty(salesDetail.RateGoodsRateGrpNm))
                    salesDetail.RateGoodsRateGrpNm = salesDetail.GoodsMGroupName;
                // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- <<<<<
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            else
            {
                EasyLogger.Write(CLASS_NAME, methodName, "BL�R�[�h�A�����̎擾�Ɏ��s���܂����@BL�R�[�h�F" + salesDetail.BLGoodsCode);
            }

            // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- >>>>>
            // ����p���[�J�[�R�[�h
            if (0 == salesDetail.PrtMakerCode)
                salesDetail.PrtMakerCode = salesDetail.GoodsMakerCd; // 0�̏ꍇ�́A���i���[�J�[�R�[�h��ݒ�
            // ����p���[�J�[����
            if (null == salesDetail.PrtMakerName || string.IsNullOrEmpty(salesDetail.PrtMakerName.Trim()))
                salesDetail.PrtMakerName = salesDetail.MakerName; // �ݒ肳��Ă��Ȃ��ꍇ�́A���[�J�[���̂�ݒ�
            // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- <<<<<

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            #endregion
        }

        // ADD 2013/08/01 �O�� Redmine#39486 --------->>>>>>>>>>>>>>>>>>>>>>>>
        #region �����[�J�[�}�X�^
        private int InitMaker(string enterpriseCode)
        {
            List<MakerUMnt> makerList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = GetGoodsAcs.GetAllMaker(enterpriseCode, out makerList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (makerList != null) this._makerUMntList = makerList;
            }
            return status;
        }

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        private string GetName_FromMaker(int makerCode)
        {
            MakerUMnt makerUMnt = this._makerUMntList.Find(
                delegate(MakerUMnt maker)
                {
                    return (maker.GoodsMakerCd == makerCode) ? true : false;
                }
            );
            return (makerUMnt == null) ? string.Empty : makerUMnt.MakerName;
        }

        /// <summary>
        /// ���[�J�[���̎擾����(���p�J�i����)
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        private string GetKanaName_FromMaker(int makerCode)
        {
            MakerUMnt makerUMnt = this._makerUMntList.Find(
                delegate(MakerUMnt maker)
                {
                    return (maker.GoodsMakerCd == makerCode) ? true : false;
                }
            );
            return (makerUMnt == null) ? string.Empty : makerUMnt.MakerKanaName;
        }
        #endregion
        // ADD 2013/08/01 �O�� Redmine#39486 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// ���Е��ޖ��̎擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�K�C�h�敪�R�[�h</param>
        /// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
        private string GetEnterpriseGanreName(string enterpriseCode, int userGuideDivCd, int enterpriseGanreCode)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetEnterpriseGanreName";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            string enterpriseGanreName = "";
            ArrayList userGdBdList;
            List<UserGdBd> tmpList = new List<UserGdBd>();

            int status = GetUserGuideAcs.SearchDivCodeBody(out userGdBdList, enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tmpList = new List<UserGdBd>((UserGdBd[])userGdBdList.ToArray(typeof(UserGdBd)));

                UserGdBd findUserGdBd = tmpList.Find(delegate(UserGdBd userGdBd)
                {
                    if (userGdBd.GuideCode == enterpriseGanreCode) return true;
                    else return false;
                });

                if(findUserGdBd != null)
                {
                    enterpriseGanreName = findUserGdBd.GuideName;
                }
            }

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            return enterpriseGanreName;
        }

        /// <summary>
        /// ���i�啪�ޖ��̎擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="userGuideDivCd">���[�U�[�K�C�h�敪�R�[�h</param>
        /// <param name="goodsLGroup">���i�啪�ރR�[�h</param>
        private string GetGuideName(string enterpriseCode, int userGuideDivCd, int goodsLGroup)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetGuideName";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            string guideName = "";
            ArrayList userGdBdList;
            List<UserGdBd> tmpList = new List<UserGdBd>();

            int status = GetUserGuideAcs.SearchDivCodeBody(out userGdBdList, enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tmpList = new List<UserGdBd>((UserGdBd[])userGdBdList.ToArray(typeof(UserGdBd)));

                UserGdBd findUserGdBd = tmpList.Find(delegate(UserGdBd userGdBd)
                {
                    if (userGdBd.GuideCode == goodsLGroup) return true;
                    else return false;
                });

                if (findUserGdBd != null)
                {
                    guideName = findUserGdBd.GuideName;
                }
            }

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return guideName;
        }

        /// <summary>
        /// BL�R�[�h�ɘA������BL�R�[�h�}�X�^���ABL�O���[�v�R�[�h���A���i�����ޏ��A���i�啪�ޏ����擾���܂��B
        /// </summary>
        /// <param name="bLGoodsCode">BL�R�[�h</param>
        /// <param name="bLGoodsCdUMnt">BL�R�[�h�}�X�^</param>
        /// <param name="bLGroupU">�O���[�v�R�[�h�}�X�^</param>
        /// <param name="goodsGroupU">���i�����ރ}�X�^</param>
        /// <param name="userGdBdU">���i�啪�ރ}�X�^�i���[�U�[�K�C�h�j</param>
        /// <returns>True:�擾����</returns>
        private bool GetBLGoodsRelation(int bLGoodsCode, out BLGoodsCdUMnt bLGoodsCdUMnt, out BLGroupU bLGroupU, out GoodsGroupU goodsGroupU, out UserGdBdU userGdBdU)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetBLGoodsRelation";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            EasyLogger.Write(CLASS_NAME, methodName, "BL�R�[�h�}�X�^�A�O���[�v�R�[�h�}�X�^�A���i�����ރ}�X�^�A���i�啪�ރ}�X�^�i���[�U�[�K�C�h�j ��������"
                + "�@BL�R�[�h�F" + bLGoodsCode.ToString()
                );
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            GetGoodsAcs.GetBLGoodsRelation(bLGoodsCode, out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU);

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return !((bLGoodsCdUMnt.BLGoodsCode == 0) && (string.IsNullOrEmpty(bLGoodsCdUMnt.BLGoodsName)));
        }

        /// <summary>
        /// �v�����ݒ肵�܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="claim">���Ӑ���</param>
        //private void SettingSalesSlipAddUpDate(ref SalesSlipWork salesSlip, CustomerInfo claim) // DEL 2013/07/03 qijh Redmine#37586
        private void SettingSalesSlipAddUpDate(ref SalesSlip salesSlip, CustomerInfo claim) // ADD 2013/07/03 qijh Redmine#37586
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "SettingSalesSlipAddUpDate";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            DateTime addUpDate;
            int delayPaymentDiv;
            CalcAddUpDate(salesSlip.SalesDate, claim.TotalDay, claim.NTimeCalcStDate, out addUpDate, out delayPaymentDiv);

            salesSlip.AddUpADate = addUpDate;
            salesSlip.DelayPaymentDiv = delayPaymentDiv;

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        /// <summary>
        /// �w����t�̎���ȍ~�̒������Z�o���܂��B
        /// </summary>
        /// <param name="loopCnt">0:����,1:����,2:���X��...</param>
        /// <param name="targetdate">�Ώۓ�</param>
        /// <param name="totalDay">����</param>
        /// <returns>�Ώی��̎��ۂ̒���</returns>
        private DateTime GetNextTotalDate(int loopCnt, DateTime targetdate, int totalDay)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetNextTotalDate";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            DateTime retDate = targetdate;

            // �Ώی��̎��ۂ̒������擾
            int totalDayR = GetRealTotalDay(retDate, totalDay);

            // �Ώۓ������ۂ̒������傫���ꍇ��1�������Z
            if (targetdate.Day > totalDayR)
            {
                retDate = retDate.AddMonths(1);

                totalDayR = GetRealTotalDay(retDate, totalDay);
            }
            retDate = new DateTime(retDate.Year, retDate.Month, totalDayR);

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return (loopCnt == 0) ? retDate : GetNextTotalDate(loopCnt - 1, retDate.AddDays(1), totalDay);
        }

        /// <summary>
        /// �Ώ۔N�����A��������A���ۂɒ��ΏۂƂȂ���t���Z�o���܂��B
        /// </summary>
        /// <param name="targetDate">�Ώ۔N����</param>
        /// <param name="totalDay">�ݒ��̒���</param>
        /// <returns>�Ώی��̎��ۂ̒���</returns>
        private int GetRealTotalDay(DateTime targetDate, int totalDay)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetRealTotalDay";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            int retValue = totalDay;
            // �Ώی��̖����擾
            int lastDayofMonth = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);

            if (lastDayofMonth < totalDay) retValue = lastDayofMonth;

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return retValue;
        }

        /// <summary>
        /// �v����v�Z����
        /// </summary>
        /// <param name="targetDate">�Ώۓ�</param>
        /// <param name="totalDay">����</param>
        /// <param name="nTimeCalcStDate">��������J�n��</param>
        /// <param name="addUpADate">�v���(�Z�o����)</param>
        /// <param name="delayPaymentDiv">�����敪(�Z�o	����)</param>
        private void CalcAddUpDate(DateTime targetDate, int totalDay, int nTimeCalcStDate, out DateTime addUpADate, out int delayPaymentDiv)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "CalcAddUpDate";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            // ��{�I�ɑΏۓ����v����œ�������
            addUpADate = targetDate;
            delayPaymentDiv = 0;

            // �����A��������J�n�����ݒ肳��Ă��Ȃ��ꍇ�͂��̂܂܏I��
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            //if ((totalDay == 0) || (nTimeCalcStDate == 0))
            if ((totalDay == 0) || (nTimeCalcStDate == 0))
            {
                EasyLogger.Write(CLASS_NAME, methodName, "�����A��������J�n�� ���ݒ�");
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                return;
            }
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            DateTime thisTimeAddUpDate = GetNextTotalDate(0, targetDate, totalDay);
            // ���������̏ꍇ�́A���񐿋����̗������v���
            DateTime nextTimeAddUpDate = thisTimeAddUpDate.AddDays(1);


            // ��������J�n�� �� ����
            if (nTimeCalcStDate <= totalDay)
            {
                // �Ώۓ��̓��t����������J�n���`�����̏ꍇ�ɗ�������
                if ((nTimeCalcStDate <= targetDate.Day) && (targetDate.Day <= totalDay))
                {
                    addUpADate = nextTimeAddUpDate;
                    delayPaymentDiv = 1;
                }
            }
            // ��������J�n�� �� ����
            else
            {
                // �Ώۓ��̓��t��1���`�����A��������J�n���`�����̏ꍇ�ɗ�������
                if ((1 <= targetDate.Day) && (targetDate.Day <= totalDay) ||
                    (nTimeCalcStDate <= targetDate.Day))
                {
                    addUpADate = nextTimeAddUpDate;
                    delayPaymentDiv = 1;
                }
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        /// <summary>
        /// ����@�\���_�擾����
        /// </summary>
        /// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
        /// <param name="ctrlSectionCode">�Ώې��䋒�_�R�[�h</param>
        private void GetOwnSeCtrlCode(string sectionCode, out string ctrlSectionCode)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetOwnSeCtrlCode";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            EasyLogger.Write(CLASS_NAME, methodName, "����@�\���_�@���������@���_�R�[�h�F" + sectionCode);
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            SecInfoSet secInfoSet;
            ctrlSectionCode = null;
            int status = GetSecInfoAcs.GetSecInfo(sectionCode, out secInfoSet);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (secInfoSet != null)
                {
                    ctrlSectionCode = secInfoSet.SectionCode;
                }
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        /// <summary>
        /// �]�ƈ���������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�Y������]�ƈ�</returns>
        private EmployeeDtl GetEmployeeDtl(string enterpriseCode, string employeeCode)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetEmployeeDtl";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            EasyLogger.Write(CLASS_NAME, methodName, "�]�ƈ��������� ��������"
                + "�@��ƃR�[�h�F" + enterpriseCode
                + "�@�]�ƈ��R�[�h�F" + employeeCode
                );
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            Employee foundEmployee = null;
            EmployeeDtl foundEmployeeDetail = null;
            // �]�ƈ����擾
            int status = GetEmployeeAcs.Read(out foundEmployee, out foundEmployeeDetail, enterpriseCode, employeeCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �^�u���b�g���O�Ή��@--------------------------------->>>>>

                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                return foundEmployeeDetail;
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return null;
        }

        /// <summary>
        /// ���Ӑ���̎擾
        /// </summary>
        /// <param name="saleSlip">������</param>
        /// <returns>���Ӑ���</returns>
        //private CustomerInfo GetCustomerInfo(SalesSlipWork saleSlip) // DEL 2013/07/03 qijh Redmine#37586
        private CustomerInfo GetCustomerInfo(SalesSlip saleSlip) // ADD 2013/07/03 qijh Redmine#37586
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetCustomerInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            // ����A�܂��͓��Ӑ悪�ύX���ꂽ�ꍇ
            if (this._customerInfo == null || this._customerCodeSave != saleSlip.CustomerCode)
            {
                // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "���Ӑ���@��������"
                    + "��ƃR�[�h�F" + saleSlip.EnterpriseCode
                    + "���Ӑ�R�[�h�F" + saleSlip.CustomerCode.ToString()
                    );
                // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                this._customerInfoAcs.ReadDBData(saleSlip.EnterpriseCode, saleSlip.CustomerCode, out this._customerInfo);
            }
            this._customerCodeSave = saleSlip.CustomerCode;
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return _customerInfo;
        }

        /// <summary>
        /// ���i���̎擾
        /// </summary>
        /// <param name="salesSlip">������</param>
        /// <param name="salesDetail">���㖾�׏��</param>
        /// <returns>���i���</returns>
        //private GoodsUnitData GetGoodsUnitData(SalesSlipWork salesSlip, SalesDetailWork salesDetail) // DEL 2013/07/03 qijh Redmine#37586
        private GoodsUnitData GetGoodsUnitData(SalesSlip salesSlip, SalesDetail salesDetail) // ADD 2013/07/03 qijh Redmine#37586
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetGoodsUnitData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            EasyLogger.Write(CLASS_NAME, methodName, "���i���@��������"
                + "�@��ƃR�[�h�F" + salesSlip.EnterpriseCode
                + "�@���_�R�[�h�F" + salesSlip.SectionCode
                + "�@���[�J�[�R�[�h�F" + salesDetail.GoodsMakerCd
                + "�@���i�ԍ��F" + salesDetail.GoodsNo
            );
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            // ���i���
            GoodsUnitData goodsUnitData;
            // �݌ɏ��擾
            GetGoodsAcs.Read(salesSlip.EnterpriseCode, salesSlip.SectionCode, salesDetail.GoodsMakerCd, salesDetail.GoodsNo, ConstantManagement.LogicalMode.GetData0, out goodsUnitData);

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return goodsUnitData;
        }

        /// <summary>
        /// ���Аݒ�}�X�^�f�[�^���擾����
        /// </summary>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <returns>���Аݒ�}�X�^</returns>
        private PccCmpnyStWork SearchPccCmpnyStList(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "SearchPccCmpnyStList";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            EasyLogger.Write(CLASS_NAME, methodName, "���Аݒ�}�X�^�@��������"
                + "�⍇������ƃR�[�h�F" + inqOriginalEpCd
                + "�⍇�������_�R�[�h�F" + inqOriginalSecCd
                + "�⍇�����ƃR�[�h�F" + inqOtherEpCd
                + "�⍇���拒�_�R�[�h�F" + inqOtherSecCd
                );
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            object pccCmpnyStObj = null;
            // �����p�����[�^
            PccCmpnyStWork parsePccCmpnyStWork = new PccCmpnyStWork();
            // �⍇������ƃR�[�h
            parsePccCmpnyStWork.InqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            // �⍇�������_�R�[�h
            parsePccCmpnyStWork.InqOriginalSecCd = inqOriginalSecCd;
            // �⍇�����ƃR�[�h
            parsePccCmpnyStWork.InqOtherEpCd = inqOtherEpCd;
            // �⍇���拒�_�R�[�h
            parsePccCmpnyStWork.InqOtherSecCd = inqOtherSecCd;
            // �����敪(���ݖ��g�p)
            int readMode = 0;
            // �_���폜�L��
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;

            int status = GetIPccCmpnyStDB.Search(out pccCmpnyStObj, parsePccCmpnyStWork, readMode, logicalMode);

            if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
                // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                return (PccCmpnyStWork)((ArrayList)pccCmpnyStObj)[0];
            }

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F"+ status.ToString());
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return null;
        }

        /// <summary>
        /// �D��q�Ƀ��X�g(PCC���Аݒ�}�X�^�̗D��q��)�𐶐����܂��B
        /// </summary>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <returns>�D��q�Ƀ��X�g</returns>
        private List<string> CreatePriorWarehouseListForPccuoe(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "CreatePriorWarehouseListForPccuoe";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            PccCmpnyStWork pccCmpnySt = SearchPccCmpnyStList(inqOriginalEpCd.Trim(), inqOriginalSecCd, inqOtherEpCd, inqOtherSecCd);//@@@@20230303

            List<string> sectWarehouseCdList = new List<string>();
            if (pccCmpnySt != null)
            {
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccWarehouseCd) ? "" : pccCmpnySt.PccWarehouseCd.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd1) ? "" : pccCmpnySt.PccPriWarehouseCd1.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd2) ? "" : pccCmpnySt.PccPriWarehouseCd2.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd3) ? "" : pccCmpnySt.PccPriWarehouseCd3.Trim());
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return sectWarehouseCdList;
        }

        // -------------- ADD 2013/07/12 qijh Redmine#38166 ----------- >>>>>
        /// <summary>
        /// ����p�i�Ԃ�ݒ�
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <param name="pmTabSalesDetail">PMTAB���㖾�׃f�[�^</param>
        private void SetPrtGoodsNo(SalesDetail salesDetail, PmTabSaleDetailWork pmTabSalesDetail)
        {
            // UPD 2013/08/16 �g�� Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //// �Ώۂ̖��ׂ��A �D�ǃ��[�J�[(GoodsMakerCd �� 1000) ���� 
            //if (salesDetail.GoodsMakerCd < 1000)
            //    return; // �ΏۊO
            //PmtSalDtlSupTmpWork pmtSalDtlSupTmpWork = null;
            //if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != GetPmtSalDtlSupTmp(pmTabSalesDetail, out pmtSalDtlSupTmpWork) || null == pmtSalDtlSupTmpWork)
            //{
            //    // �Ώۂ̔���s�ԍ�(SalesRowNoRF)�̃f�[�^���擾�ł��Ȃ��ꍇ�i�ʏ�͗L�蓾�Ȃ��j�́A���㖾�׃f�[�^(PmTabSaleDetailRF)�D���i�ԍ�(GoodsNoRF)��ݒ肷��
            //    salesDetail.PrtGoodsNo = pmTabSalesDetail.GoodsNo;
            //    return;
            //}
            #endregion
            // �Ώۂ̖��ׂ��A �D�ǃ��[�J�[(GoodsMakerCd �� 1000) �܂��́ABL�����̏ꍇ��PmtSalDtlSupTmpWork���擾����
            if (salesDetail.GoodsMakerCd < 1000 && !salesDetail.GoodsSearchDivCd.Equals(0)) return; // �ΏۊO

            // PMTAB���㖾�ו⑫�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^ �̎擾
            PmtSalDtlSupTmpWork pmtSalDtlSupTmpWork = null;
            int status = GetPmtSalDtlSupTmp(pmTabSalesDetail, out pmtSalDtlSupTmpWork);
            
            // BL�R�[�h�����܂��͕i�Ԍ����ŗD�ǃ��[�J�[�̏ꍇ�́A�����i�Ԃ��񓚏������i�ԍ��ɕێ�
            // UPD 2013/08/30 �g�� Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // if (salesDetail.GoodsSearchDivCd.Equals(0))
            if (salesDetail.GoodsSearchDivCd.Equals(0)
                || salesDetail.GoodsSearchDivCd.Equals(1) && salesDetail.GoodsMakerCd >= 1000
                )
            // UPD 2013/08/30 �g�� Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                SCMAcOdrDtlAsWork wk = new SCMAcOdrDtlAsWork();
                wk.SalesRowNo = salesDetail.SalesRowNo;
                wk.AnsPureGoodsNo = pmtSalDtlSupTmpWork.PmTabPurePartsNo;
                wk.BLGoodsCode = pmtSalDtlSupTmpWork.BLGoodsCode;

                sCMAcOdrDtlAsWorkForAnsPureGoodsNo.Add(wk);
            }

            // �ȍ~�̏����͗D�ǃ��[�J�[�̏ꍇ�̂ݎ��{
            if (salesDetail.GoodsMakerCd < 1000)  return; 

            if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status || null == pmtSalDtlSupTmpWork)
            {
                // �Ώۂ̔���s�ԍ�(SalesRowNoRF)�̃f�[�^���擾�ł��Ȃ��ꍇ�i�ʏ�͗L�蓾�Ȃ��j�́A���㖾�׃f�[�^(PmTabSaleDetailRF)�D���i�ԍ�(GoodsNoRF)��ݒ肷��
                salesDetail.PrtGoodsNo = pmTabSalesDetail.GoodsNo;
                return;
            }
            // UPD 2013/08/16 �g�� Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            

            // PMTAB���㖾�ו⑫�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^(PmtSalDtlSupTmpRF)�D���i�I���敪(PriceSelectDivRF)��0:���� �̏ꍇ�A
            if (pmtSalDtlSupTmpWork.PriceSelectDiv != 0)
                return; // �ΏۊO

            // ����p�i�Ԃ�ݒ�
            switch (this.PmTabTtlStSec.LiPriSelPrtGdsNoDiv)
            {
                case 0:
                    {
                        // �W�����i�I������p�i�Ԑݒ�敪��0:�D�Ǖi�Ԃ��󎚁@�̏ꍇ
                        // ���㖾�׃f�[�^(PmTabSaleDetailRF)�D���i�ԍ�(GoodsNoRF)��ݒ肷��
                        salesDetail.PrtGoodsNo = pmTabSalesDetail.GoodsNo;
                        break;
                    }
                case 1:
                    {
                        // �W�����i�I������p�i�Ԑݒ�敪��1:�i�Ԉ󎚂Ȃ��̏ꍇ
                        // (�󕶎�)��ݒ肷��
                        salesDetail.PrtGoodsNo = string.Empty;
                        break;
                    }
                case 2:
                    {
                        // �W�����i�I������p�i�Ԑݒ�敪��2:����S�̐ݒ�̎��Еi�Ԉ󎚋敪�ɏ]��(�󎚋敪�F���Ȃ��@�̏ꍇ�͗D�Ǖi�Ԉ�)�@�̏ꍇ
                        if (SalesTtlSt.EpPartsNoPrtCd == 0)
                            // ����S�̐ݒ�}�X�^.���Еi�Ԉ󎚋敪(EpPartsNoPrtCdRF)��0�F���Ȃ��@�̏ꍇ
                            // PMTAB���㖾�׃f�[�^(PmTabSaleDetailRF)�D���i�ԍ�(GoodsNoRF)��ݒ肷��
                            salesDetail.PrtGoodsNo = pmTabSalesDetail.GoodsNo;

                        else if (SalesTtlSt.EpPartsNoPrtCd == 1)
                            // ����S�̐ݒ�}�X�^.���Еi�Ԉ󎚋敪(EpPartsNoPrtCdRF)��1�F����@�̏ꍇ
                            // PMTAB���㖾�ו⑫�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^.�����i��(PmTabPurePartsNoRF) �{ ����S�̐ݒ�}�X�^.���Еi�ԕt������(EpPartsNoAddCharRF)
                            salesDetail.PrtGoodsNo = pmtSalDtlSupTmpWork.PmTabPurePartsNo + SalesTtlSt.EpPartsNoAddChar;
                        
                        break;
                    }
                case 3:
                    {
                        // �W�����i�I������p�i�Ԑݒ�敪��3:����S�̐ݒ�̎��Еi�Ԉ󎚋敪�ɏ]��(�󎚋敪�F���Ȃ��@�̏ꍇ�͕i�Ԉ󎚂Ȃ�)�@�̏ꍇ
                        if (SalesTtlSt.EpPartsNoPrtCd == 0)
                            // ����S�̐ݒ�}�X�^.���Еi�Ԉ󎚋敪(EpPartsNoPrtCdRF)��0�F���Ȃ��@�̏ꍇ
                            // (�󕶎�)��ݒ肷��
                            salesDetail.PrtGoodsNo = string.Empty;

                        else if (SalesTtlSt.EpPartsNoPrtCd == 1)
                            // ����S�̐ݒ�}�X�^.���Еi�Ԉ󎚋敪(EpPartsNoPrtCdRF)��1�F����@�̏ꍇ
                            // PMTAB���㖾�ו⑫�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^.�����i��(PmTabPurePartsNoRF) �{ ����S�̐ݒ�}�X�^.���Еi�ԕt������(EpPartsNoAddCharRF)
                            salesDetail.PrtGoodsNo = pmtSalDtlSupTmpWork.PmTabPurePartsNo + SalesTtlSt.EpPartsNoAddChar;

                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// PMTAB���㖾�ו⑫�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^���擾
        /// </summary>
        /// <param name="pmTabSalesDetail">PMTAB���㖾�׃f�[�^</param>
        /// <param name="pmtSalDtlSupTmpWork">PMTAB���㖾�ו⑫�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetPmtSalDtlSupTmp(PmTabSaleDetailWork pmTabSalesDetail, out PmtSalDtlSupTmpWork pmtSalDtlSupTmpWork)
        {
            pmtSalDtlSupTmpWork = null;
            // �����p�����[�^
            PmtSalDtlSupTmpWork paramPmtSalDtlSupTmp = new PmtSalDtlSupTmpWork();
            paramPmtSalDtlSupTmp.EnterpriseCode = pmTabSalesDetail.EnterpriseCode;
            paramPmtSalDtlSupTmp.SearchSectionCode = pmTabSalesDetail.SearchSectionCode;
            paramPmtSalDtlSupTmp.BusinessSessionId = pmTabSalesDetail.BusinessSessionId;
            CustomSerializeArrayList searchParamList = new CustomSerializeArrayList();
            searchParamList.Add(paramPmtSalDtlSupTmp);

            // PMTAB���㖾�ו⑫�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^���擾
            object searchResultListObj;
            int status = this.IPmtPartsSearchDB.Search(searchParamList, out searchResultListObj);
            CustomSerializeArrayList searchResultList = searchResultListObj as CustomSerializeArrayList;

            // �������ʃ`�F�b�N
            if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status || null == searchResultList || searchResultList.Count == 0)
                return status;
            ArrayList searchResultAryList = searchResultList[0] as ArrayList;
            if (null == searchResultAryList || searchResultAryList.Count == 0)
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // ����s�ԍ��Ńt�B���^
            List<PmtSalDtlSupTmpWork> resultList = new List<PmtSalDtlSupTmpWork>((PmtSalDtlSupTmpWork[])searchResultAryList.ToArray(typeof(PmtSalDtlSupTmpWork)));
            pmtSalDtlSupTmpWork = resultList.Find(
                delegate(PmtSalDtlSupTmpWork pmtSalDtlSupTmp)
                {
                    if (pmtSalDtlSupTmp.SalesRowNo == pmTabSalesDetail.SalesRowNo)
                        return true;
                    return false;
                }
            );

            // ���ʂ�߂�
            if (null == pmtSalDtlSupTmpWork)
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            return status;
        }
        // -------------- ADD 2013/07/12 qijh Redmine#38166 ----------- <<<<<

        // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- >>>>>
        /// <summary>
        /// �`�[�������ݒ�
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="customer">���Ӑ���</param>
        private void SetSalesSlipPrintInfo(SalesSlip salesSlip, CustomerInfo customer)
        {
            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlip.AcptAnOdrStatus)
            {
                case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder:
                    switch (customer.AcpOdrrSlipPrtDiv)
                    {
                        // 0:�W�� �� �󒍑S�̐ݒ�
                        default:
                        case 0:
                            salesSlip.SlipPrintDivCd = this.AcptAnOdrTtlSt.AcpOdrrSlipPrtDiv;
                            break;
                        // 1:���g�p �� 0:���Ȃ�
                        case 1:
                            salesSlip.SlipPrintDivCd = 0;
                            break;
                        // 2:�g�p �� 1:����
                        case 2:
                            salesSlip.SlipPrintDivCd = 1;
                            break;
                    }
                    break;
                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                    switch (customer.SalesSlipPrtDiv)
                    {
                        // 0:�W�� �� ����S�̐ݒ�
                        default:
                        case 0:
                            salesSlip.SlipPrintDivCd = this.SalesTtlSt.SalesSlipPrtDiv + 1 % 2;
                            break;
                        // 1:���g�p �� 0:���Ȃ�
                        case 1:
                            salesSlip.SlipPrintDivCd = 0;
                            break;
                        // 2:�g�p �� 1:����
                        case 2:
                            salesSlip.SlipPrintDivCd = 1;
                            break;
                    }
                    break;
                default:
                    break;
            }
            salesSlip.SlipPrtSetPaperId = this.GetSlipPrtSetPaperId(salesSlip); // �`�[����ݒ�p���[�h�c
            salesSlip.SlipPrintFinishCd = salesSlip.SlipPrintDivCd; // �`�[���s�ϋ敪
            salesSlip.SalesSlipPrintDate = (salesSlip.SlipPrintDivCd == (int)SalesSlipInputAcs.SlipPrintDivCd.Print) ? DateTime.Today : DateTime.MinValue; // ����`�[���s��
        }

        /// <summary>
        /// �`�[����ݒ�p���[�h�c�擾����
        /// </summary>
        /// <param name="slipInfo">����f�[�^</param>
        /// <returns>�`�[����ݒ�p���[�h�c</returns>
        private string GetSlipPrtSetPaperId(SalesSlip slipInfo)
        {
            string slipPrtSetPaperId = string.Empty;

            SlipPrtSet slipPrtSet = new SlipPrtSet();
            switch ((AcptAnOdrStatusState)slipInfo.AcptAnOdrStatus)
            {
                case AcptAnOdrStatusState.AcceptAnOrder:
                case AcptAnOdrStatusState.Sales:
                    slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.SalesSlip, slipInfo);
                    break;
            }
            if (slipPrtSet != null) slipPrtSetPaperId = slipPrtSet.SlipPrtSetPaperId;
            return slipPrtSetPaperId;
        }
        // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- <<<<<
        // -------------- ADD 2013/07/24 qijh Redmine#39026 ----------- >>>>>
        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private int ReadInitDataNinth(string enterpriseCode, string sectionCode, out List<SalesProcMoney> salesProcMoneyList)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ��������z�����敪�ݒ�}�X�^
            SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
            salesProcMoneyAcs.IsLocalDBRead = false;
            status = salesProcMoneyAcs.Search(out aList, enterpriseCode);
            salesProcMoneyList = new List<SalesProcMoney>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])aList.ToArray(typeof(SalesProcMoney)));
            }
            #endregion

            return 0;
        }

        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        private void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // �����l
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // �P����0.01�~�P��
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // �P���ȊO��1�~�P��
                    break;
            }
            fractionProcCd = 1;     // �؎̂�

            //-----------------------------------------------------------------------------
            // �R�[�h�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            List<SalesProcMoney> salesProcMoneyList = this.SalesProcMoneyList.FindAll(
                delegate(SalesProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // �\�[�g�i������z�i�����j�j
            //-----------------------------------------------------------------------------
            salesProcMoneyList.Sort(new SalesProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // ������z�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            SalesProcMoney salesProcMoney = salesProcMoneyList.Find(
                delegate(SalesProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // �߂�l�ݒ�
            //-----------------------------------------------------------------------------
            if (salesProcMoney != null)
            {
                fractionProcUnit = salesProcMoney.FractionProcUnit;
                fractionProcCd = salesProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// ������z�����敪�}�X�^��r�N���X(������z(����))
        /// </summary>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {
            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }
        // -------------- ADD 2013/07/24 qijh Redmine#39026 ----------- <<<<<
        #endregion

        #region Public Method
        // ----------------- ADD 2013/07/03 qijh Redmine#37586 --------------- >>>>>
        #region <�����[�g�p���[�N�f�[�^>
        #region <����f�[�^���[�N>

        /// <summary>
        /// �����[�g�p����f�[�^�𐶐����܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>�����[�g�p����f�[�^</returns>
        public static SalesSlipWork CreateSalesSlipWork(SalesSlip salesSlip)
        {
            SalesSlipWork salesSlipWork = new SalesSlipWork();
            {
                salesSlipWork.CreateDateTime = salesSlip.CreateDateTime; // �쐬����
                salesSlipWork.UpdateDateTime = salesSlip.UpdateDateTime; // �X�V����
                salesSlipWork.EnterpriseCode = salesSlip.EnterpriseCode; // ��ƃR�[�h
                salesSlipWork.FileHeaderGuid = salesSlip.FileHeaderGuid; // GUID
                salesSlipWork.UpdEmployeeCode = salesSlip.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                salesSlipWork.UpdAssemblyId1 = salesSlip.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                salesSlipWork.UpdAssemblyId2 = salesSlip.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                salesSlipWork.LogicalDeleteCode = salesSlip.LogicalDeleteCode; // �_���폜�敪
                salesSlipWork.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus; // �󒍃X�e�[�^�X
                salesSlipWork.SalesSlipNum = salesSlip.SalesSlipNum; // ����`�[�ԍ�
                salesSlipWork.SectionCode = salesSlip.SectionCode; // ���_�R�[�h
                salesSlipWork.SubSectionCode = salesSlip.SubSectionCode; // ����R�[�h
                salesSlipWork.DebitNoteDiv = salesSlip.DebitNoteDiv; // �ԓ`�敪
                salesSlipWork.DebitNLnkSalesSlNum = salesSlip.DebitNLnkSalesSlNum; // �ԍ��A������`�[�ԍ�
                salesSlipWork.SalesSlipCd = salesSlip.SalesSlipCd; // ����`�[�敪
                salesSlipWork.SalesGoodsCd = salesSlip.SalesGoodsCd; // ���㏤�i�敪
                salesSlipWork.AccRecDivCd = salesSlip.AccRecDivCd; // ���|�敪
                salesSlipWork.SalesInpSecCd = salesSlip.SalesInpSecCd; // ������͋��_�R�[�h
                salesSlipWork.DemandAddUpSecCd = salesSlip.DemandAddUpSecCd; // �����v�㋒�_�R�[�h
                salesSlipWork.ResultsAddUpSecCd = salesSlip.ResultsAddUpSecCd; // ���ьv�㋒�_�R�[�h
                salesSlipWork.UpdateSecCd = salesSlip.UpdateSecCd; // �X�V���_�R�[�h
                salesSlipWork.SalesSlipUpdateCd = salesSlip.SalesSlipUpdateCd; // ����`�[�X�V�敪
                salesSlipWork.SearchSlipDate = salesSlip.SearchSlipDate; // �`�[�������t
                salesSlipWork.ShipmentDay = salesSlip.ShipmentDay; // �o�ד��t
                salesSlipWork.SalesDate = salesSlip.SalesDate; // ������t
                salesSlipWork.AddUpADate = salesSlip.AddUpADate; // �v����t
                // ADD 2013/08/02 �O�� Redmine#39549 --------->>>>>>>>>>>>>>>>>>>>>>>>
                if (salesSlipWork.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) salesSlipWork.AddUpADate = DateTime.MinValue;
                // ADD 2013/08/02 �O�� Redmine#39549 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                salesSlipWork.DelayPaymentDiv = salesSlip.DelayPaymentDiv; // �����敪
                salesSlipWork.EstimateFormNo = salesSlip.EstimateFormNo; // ���Ϗ��ԍ�
                salesSlipWork.EstimateDivide = salesSlip.EstimateDivide; // ���ϋ敪
                salesSlipWork.InputAgenCd = salesSlip.InputAgenCd; // ���͒S���҃R�[�h
                salesSlipWork.InputAgenNm = salesSlip.InputAgenNm; // ���͒S���Җ���
                salesSlipWork.SalesInputCode = salesSlip.SalesInputCode; // ������͎҃R�[�h
                salesSlipWork.SalesInputName = salesSlip.SalesInputName; // ������͎Җ���
                salesSlipWork.FrontEmployeeCd = salesSlip.FrontEmployeeCd; // ��t�]�ƈ��R�[�h
                salesSlipWork.FrontEmployeeNm = salesSlip.FrontEmployeeNm; // ��t�]�ƈ�����
                salesSlipWork.SalesEmployeeCd = salesSlip.SalesEmployeeCd; // �̔��]�ƈ��R�[�h
                salesSlipWork.SalesEmployeeNm = salesSlip.SalesEmployeeNm; // �̔��]�ƈ�����
                salesSlipWork.TotalAmountDispWayCd = salesSlip.TotalAmountDispWayCd; // ���z�\�����@�敪
                salesSlipWork.TtlAmntDispRateApy = salesSlip.TtlAmntDispRateApy; // ���z�\���|���K�p�敪
                salesSlipWork.SalesTotalTaxInc = salesSlip.SalesTotalTaxInc; // ����`�[���v�i�ō��݁j
                salesSlipWork.SalesTotalTaxExc = salesSlip.SalesTotalTaxExc; // ����`�[���v�i�Ŕ����j
                salesSlipWork.SalesPrtTotalTaxInc = salesSlip.SalesPrtTotalTaxInc; // ���㕔�i���v�i�ō��݁j
                salesSlipWork.SalesPrtTotalTaxExc = salesSlip.SalesPrtTotalTaxExc; // ���㕔�i���v�i�Ŕ����j
                salesSlipWork.SalesWorkTotalTaxInc = salesSlip.SalesWorkTotalTaxInc; // �����ƍ��v�i�ō��݁j
                salesSlipWork.SalesWorkTotalTaxExc = salesSlip.SalesWorkTotalTaxExc; // �����ƍ��v�i�Ŕ����j
                salesSlipWork.SalesSubtotalTaxInc = salesSlip.SalesSubtotalTaxInc; // ���㏬�v�i�ō��݁j
                salesSlipWork.SalesSubtotalTaxExc = salesSlip.SalesSubtotalTaxExc; // ���㏬�v�i�Ŕ����j
                salesSlipWork.SalesPrtSubttlInc = salesSlip.SalesPrtSubttlInc; // ���㕔�i���v�i�ō��݁j
                salesSlipWork.SalesPrtSubttlExc = salesSlip.SalesPrtSubttlExc; // ���㕔�i���v�i�Ŕ����j
                salesSlipWork.SalesWorkSubttlInc = salesSlip.SalesWorkSubttlInc; // �����Ə��v�i�ō��݁j
                salesSlipWork.SalesWorkSubttlExc = salesSlip.SalesWorkSubttlExc; // �����Ə��v�i�Ŕ����j
                salesSlipWork.SalesNetPrice = salesSlip.SalesNetPrice; // ���㐳�����z
                salesSlipWork.SalesSubtotalTax = salesSlip.SalesSubtotalTax; // ���㏬�v�i�Łj
                salesSlipWork.ItdedSalesOutTax = salesSlip.ItdedSalesOutTax; // ����O�őΏۊz
                salesSlipWork.ItdedSalesInTax = salesSlip.ItdedSalesInTax; // ������őΏۊz
                salesSlipWork.SalSubttlSubToTaxFre = salesSlip.SalSubttlSubToTaxFre; // ���㏬�v��ېőΏۊz
                salesSlipWork.SalesOutTax = salesSlip.SalesOutTax; // ������z����Ŋz�i�O�Łj
                salesSlipWork.SalAmntConsTaxInclu = salesSlip.SalAmntConsTaxInclu; // ������z����Ŋz�i���Łj
                salesSlipWork.SalesDisTtlTaxExc = salesSlip.SalesDisTtlTaxExc; // ����l�����z�v�i�Ŕ����j
                salesSlipWork.ItdedSalesDisOutTax = salesSlip.ItdedSalesDisOutTax; // ����l���O�őΏۊz���v
                salesSlipWork.ItdedSalesDisInTax = salesSlip.ItdedSalesDisInTax; // ����l�����őΏۊz���v
                salesSlipWork.ItdedPartsDisOutTax = salesSlip.ItdedPartsDisOutTax; // ���i�l���Ώۊz���v�i�Ŕ����j
                salesSlipWork.ItdedPartsDisInTax = salesSlip.ItdedPartsDisInTax; // ���i�l���Ώۊz���v�i�ō��݁j
                salesSlipWork.ItdedWorkDisOutTax = salesSlip.ItdedWorkDisOutTax; // ��ƒl���Ώۊz���v�i�Ŕ����j
                salesSlipWork.ItdedWorkDisInTax = salesSlip.ItdedWorkDisInTax; // ��ƒl���Ώۊz���v�i�ō��݁j
                salesSlipWork.ItdedSalesDisTaxFre = salesSlip.ItdedSalesDisTaxFre; // ����l����ېőΏۊz���v
                salesSlipWork.SalesDisOutTax = salesSlip.SalesDisOutTax; // ����l������Ŋz�i�O�Łj
                salesSlipWork.SalesDisTtlTaxInclu = salesSlip.SalesDisTtlTaxInclu; // ����l������Ŋz�i���Łj
                salesSlipWork.PartsDiscountRate = salesSlip.PartsDiscountRate; // ���i�l����
                salesSlipWork.RavorDiscountRate = salesSlip.RavorDiscountRate; // �H���l����
                salesSlipWork.TotalCost = salesSlip.TotalCost; // �������z�v
                salesSlipWork.ConsTaxLayMethod = salesSlip.ConsTaxLayMethod; // ����œ]�ŕ���
                salesSlipWork.ConsTaxRate = salesSlip.ConsTaxRate; // ����Őŗ�
                salesSlipWork.FractionProcCd = salesSlip.FractionProcCd; // �[�������敪
                salesSlipWork.AccRecConsTax = salesSlip.AccRecConsTax; // ���|�����
                salesSlipWork.AutoDepositCd = salesSlip.AutoDepositCd; // ���������敪
                salesSlipWork.AutoDepositSlipNo = salesSlip.AutoDepositSlipNo; // ���������`�[�ԍ�
                salesSlipWork.DepositAllowanceTtl = salesSlip.DepositAllowanceTtl; // �����������v�z
                salesSlipWork.DepositAlwcBlnce = salesSlip.DepositAlwcBlnce; // ���������c��
                salesSlipWork.ClaimCode = salesSlip.ClaimCode; // ������R�[�h
                salesSlipWork.ClaimSnm = salesSlip.ClaimSnm; // �����旪��
                salesSlipWork.CustomerCode = salesSlip.CustomerCode; // ���Ӑ�R�[�h
                salesSlipWork.CustomerName = salesSlip.CustomerName; // ���Ӑ於��
                salesSlipWork.CustomerName2 = salesSlip.CustomerName2; // ���Ӑ於��2
                salesSlipWork.CustomerSnm = salesSlip.CustomerSnm; // ���Ӑ旪��
                salesSlipWork.HonorificTitle = salesSlip.HonorificTitle; // �h��
                salesSlipWork.OutputNameCode = salesSlip.OutputNameCode; // �����R�[�h
                salesSlipWork.OutputName = salesSlip.OutputName; // ��������
                salesSlipWork.CustSlipNo = salesSlip.CustSlipNo; // ���Ӑ�`�[�ԍ�
                salesSlipWork.SlipAddressDiv = salesSlip.SlipAddressDiv; // �`�[�Z���敪
                salesSlipWork.AddresseeCode = salesSlip.AddresseeCode; // �[�i��R�[�h
                salesSlipWork.AddresseeName = salesSlip.AddresseeName; // �[�i�於��
                salesSlipWork.AddresseeName2 = salesSlip.AddresseeName2; // �[�i�於��2
                salesSlipWork.AddresseePostNo = salesSlip.AddresseePostNo; // �[�i��X�֔ԍ�
                salesSlipWork.AddresseeAddr1 = salesSlip.AddresseeAddr1; // �[�i��Z��1(�s���{���s��S�E�����E��)
                salesSlipWork.AddresseeAddr3 = salesSlip.AddresseeAddr3; // �[�i��Z��3(�Ԓn)
                salesSlipWork.AddresseeAddr4 = salesSlip.AddresseeAddr4; // �[�i��Z��4(�A�p�[�g����)
                salesSlipWork.AddresseeTelNo = salesSlip.AddresseeTelNo; // �[�i��d�b�ԍ�
                salesSlipWork.AddresseeFaxNo = salesSlip.AddresseeFaxNo; // �[�i��FAX�ԍ�
                salesSlipWork.PartySaleSlipNum = salesSlip.PartySaleSlipNum; // �����`�[�ԍ�
                salesSlipWork.SlipNote = salesSlip.SlipNote; // �`�[���l
                salesSlipWork.SlipNote2 = salesSlip.SlipNote2; // �`�[���l�Q
                salesSlipWork.SlipNote3 = salesSlip.SlipNote3; // �`�[���l�R
                salesSlipWork.RetGoodsReasonDiv = salesSlip.RetGoodsReasonDiv; // �ԕi���R�R�[�h
                salesSlipWork.RetGoodsReason = salesSlip.RetGoodsReason; // �ԕi���R
                salesSlipWork.RegiProcDate = salesSlip.RegiProcDate; // ���W������
                salesSlipWork.CashRegisterNo = salesSlip.CashRegisterNo; // ���W�ԍ�
                salesSlipWork.PosReceiptNo = salesSlip.PosReceiptNo; // POS���V�[�g�ԍ�
                salesSlipWork.DetailRowCount = salesSlip.DetailRowCount; // ���׍s��
                salesSlipWork.EdiSendDate = salesSlip.EdiSendDate; // �d�c�h���M��
                salesSlipWork.EdiTakeInDate = salesSlip.EdiTakeInDate; // �d�c�h�捞��
                salesSlipWork.UoeRemark1 = salesSlip.UoeRemark1; // �t�n�d���}�[�N�P
                salesSlipWork.UoeRemark2 = salesSlip.UoeRemark2; // �t�n�d���}�[�N�Q
                salesSlipWork.SlipPrintDivCd = salesSlip.SlipPrintDivCd; // �`�[���s�敪
                salesSlipWork.SlipPrintFinishCd = salesSlip.SlipPrintFinishCd; // �`�[���s�ϋ敪
                salesSlipWork.SalesSlipPrintDate = salesSlip.SalesSlipPrintDate; // ����`�[���s��
                salesSlipWork.BusinessTypeCode = salesSlip.BusinessTypeCode; // �Ǝ�R�[�h
                salesSlipWork.BusinessTypeName = salesSlip.BusinessTypeName; // �Ǝ햼��
                salesSlipWork.OrderNumber = salesSlip.OrderNumber; // �����ԍ�
                salesSlipWork.DeliveredGoodsDiv = salesSlip.DeliveredGoodsDiv; // �[�i�敪
                salesSlipWork.DeliveredGoodsDivNm = salesSlip.DeliveredGoodsDivNm; // �[�i�敪����
                salesSlipWork.SalesAreaCode = salesSlip.SalesAreaCode; // �̔��G���A�R�[�h
                salesSlipWork.SalesAreaName = salesSlip.SalesAreaName; // �̔��G���A����
                salesSlipWork.ReconcileFlag = salesSlip.ReconcileFlag; // �����t���O
                salesSlipWork.SlipPrtSetPaperId = salesSlip.SlipPrtSetPaperId; // �`�[����ݒ�p���[ID
                salesSlipWork.CompleteCd = salesSlip.CompleteCd; // �ꎮ�`�[�敪
                salesSlipWork.SalesPriceFracProcCd = salesSlip.SalesPriceFracProcCd; // ������z�[�������敪
                salesSlipWork.StockGoodsTtlTaxExc = salesSlip.StockGoodsTtlTaxExc; // �݌ɏ��i���v���z�i�Ŕ��j
                salesSlipWork.PureGoodsTtlTaxExc = salesSlip.PureGoodsTtlTaxExc; // �������i���v���z�i�Ŕ��j
                salesSlipWork.ListPricePrintDiv = salesSlip.ListPricePrintDiv; // �艿����敪
                salesSlipWork.EraNameDispCd1 = salesSlip.EraNameDispCd1; // �����\���敪�P
                salesSlipWork.EstimaTaxDivCd = salesSlip.EstimaTaxDivCd; // ���Ϗ���ŋ敪
                salesSlipWork.EstimateFormPrtCd = salesSlip.EstimateFormPrtCd; // ���Ϗ�����敪
                salesSlipWork.EstimateSubject = salesSlip.EstimateSubject; // ���ό���
                salesSlipWork.Footnotes1 = salesSlip.Footnotes1; // �r���P
                salesSlipWork.Footnotes2 = salesSlip.Footnotes2; // �r���Q
                salesSlipWork.EstimateTitle1 = salesSlip.EstimateTitle1; // ���σ^�C�g���P
                salesSlipWork.EstimateTitle2 = salesSlip.EstimateTitle2; // ���σ^�C�g���Q
                salesSlipWork.EstimateTitle3 = salesSlip.EstimateTitle3; // ���σ^�C�g���R
                salesSlipWork.EstimateTitle4 = salesSlip.EstimateTitle4; // ���σ^�C�g���S
                salesSlipWork.EstimateTitle5 = salesSlip.EstimateTitle5; // ���σ^�C�g���T
                salesSlipWork.EstimateNote1 = salesSlip.EstimateNote1; // ���ϔ��l�P
                salesSlipWork.EstimateNote2 = salesSlip.EstimateNote2; // ���ϔ��l�Q
                salesSlipWork.EstimateNote3 = salesSlip.EstimateNote3; // ���ϔ��l�R
                salesSlipWork.EstimateNote4 = salesSlip.EstimateNote4; // ���ϔ��l�S
                salesSlipWork.EstimateNote5 = salesSlip.EstimateNote5; // ���ϔ��l�T
                salesSlipWork.EstimateValidityDate = salesSlip.EstimateValidityDate; // ���ϗL������
                salesSlipWork.PartsNoPrtCd = salesSlip.PartsNoPrtCd; // �i�Ԉ󎚋敪
                salesSlipWork.OptionPringDivCd = salesSlip.OptionPringDivCd; // �I�v�V�����󎚋敪
                salesSlipWork.RateUseCode = salesSlip.RateUseCode; // �|���g�p�敪
                salesSlipWork.AutoDepositNoteDiv = salesSlip.AutoDepositNoteDiv; // �����������l�敪 // ADD �A���� Redmine#39126 �����`�[�̓E�v���������Ȃ��Ή�
            }
            return salesSlipWork;
        }

        #endregion // </����f�[�^���[�N>

        #region <���㖾�׃f�[�^���[�N>

        /// <summary>
        /// �����[�g�p���㖾�׃f�[�^�𐶐����܂��B
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <returns>�����[�g�p���㖾�׃f�[�^</returns>
        public static SalesDetailWork CreateSalesDetailWork(SalesDetail salesDetail)
        {
            SalesDetailWork salesDetailWork = new SalesDetailWork();
            {
                salesDetailWork.CreateDateTime = salesDetail.CreateDateTime; // �쐬����
                salesDetailWork.UpdateDateTime = salesDetail.UpdateDateTime; // �X�V����
                salesDetailWork.EnterpriseCode = salesDetail.EnterpriseCode; // ��ƃR�[�h
                salesDetailWork.FileHeaderGuid = salesDetail.FileHeaderGuid; // GUID
                salesDetailWork.UpdEmployeeCode = salesDetail.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                salesDetailWork.UpdAssemblyId1 = salesDetail.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                salesDetailWork.UpdAssemblyId2 = salesDetail.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                salesDetailWork.LogicalDeleteCode = salesDetail.LogicalDeleteCode; // �_���폜�敪
                salesDetailWork.AcceptAnOrderNo = salesDetail.AcceptAnOrderNo; // �󒍔ԍ�
                salesDetailWork.AcptAnOdrStatus = salesDetail.AcptAnOdrStatus; // �󒍃X�e�[�^�X
                salesDetailWork.SalesSlipNum = salesDetail.SalesSlipNum; // ����`�[�ԍ�
                salesDetailWork.SalesRowNo = salesDetail.SalesRowNo; // ����s�ԍ�
                salesDetailWork.SalesRowDerivNo = salesDetail.SalesRowDerivNo; // ����s�ԍ��}��
                salesDetailWork.SectionCode = salesDetail.SectionCode; // ���_�R�[�h
                salesDetailWork.SubSectionCode = salesDetail.SubSectionCode; // ����R�[�h
                salesDetailWork.SalesDate = salesDetail.SalesDate; // ������t
                salesDetailWork.CommonSeqNo = salesDetail.CommonSeqNo; // ���ʒʔ�
                salesDetailWork.SalesSlipDtlNum = salesDetail.SalesSlipDtlNum; // ���㖾�גʔ�
                salesDetailWork.AcptAnOdrStatusSrc = salesDetail.AcptAnOdrStatusSrc; // �󒍃X�e�[�^�X�i���j
                salesDetailWork.SalesSlipDtlNumSrc = salesDetail.SalesSlipDtlNumSrc; // ���㖾�גʔԁi���j
                salesDetailWork.SupplierFormalSync = salesDetail.SupplierFormalSync; // �d���`���i�����j
                salesDetailWork.StockSlipDtlNumSync = salesDetail.StockSlipDtlNumSync; // �d�����גʔԁi�����j
                salesDetailWork.SalesSlipCdDtl = salesDetail.SalesSlipCdDtl; // ����`�[�敪�i���ׁj
                salesDetailWork.DeliGdsCmpltDueDate = salesDetail.DeliGdsCmpltDueDate; // �[�i�����\���
                salesDetailWork.GoodsKindCode = salesDetail.GoodsKindCode; // ���i����
                salesDetailWork.GoodsSearchDivCd = salesDetail.GoodsSearchDivCd; // ���i�����敪
                salesDetailWork.GoodsMakerCd = salesDetail.GoodsMakerCd; // ���i���[�J�[�R�[�h
                salesDetailWork.MakerName = salesDetail.MakerName; // ���[�J�[����
                salesDetailWork.MakerKanaName = salesDetail.MakerKanaName; // ���[�J�[�J�i����
                salesDetailWork.CmpltMakerKanaName = salesDetail.CmpltMakerKanaName; // ���[�J�[�J�i���́i�ꎮ�j
                salesDetailWork.GoodsNo = salesDetail.GoodsNo; // ���i�ԍ�
                salesDetailWork.GoodsName = salesDetail.GoodsName; // ���i����
                salesDetailWork.GoodsNameKana = salesDetail.GoodsNameKana; // ���i���̃J�i
                salesDetailWork.GoodsLGroup = salesDetail.GoodsLGroup; // ���i�啪�ރR�[�h
                salesDetailWork.GoodsLGroupName = salesDetail.GoodsLGroupName; // ���i�啪�ޖ���
                salesDetailWork.GoodsMGroup = salesDetail.GoodsMGroup; // ���i�����ރR�[�h
                salesDetailWork.GoodsMGroupName = salesDetail.GoodsMGroupName; // ���i�����ޖ���
                salesDetailWork.BLGroupCode = salesDetail.BLGroupCode; // BL�O���[�v�R�[�h
                salesDetailWork.BLGroupName = salesDetail.BLGroupName; // BL�O���[�v�R�[�h����
                salesDetailWork.BLGoodsCode = salesDetail.BLGoodsCode; // BL���i�R�[�h
                salesDetailWork.BLGoodsFullName = salesDetail.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
                salesDetailWork.EnterpriseGanreCode = salesDetail.EnterpriseGanreCode; // ���Е��ރR�[�h
                salesDetailWork.EnterpriseGanreName = salesDetail.EnterpriseGanreName; // ���Е��ޖ���
                salesDetailWork.WarehouseCode = salesDetail.WarehouseCode; // �q�ɃR�[�h
                salesDetailWork.WarehouseName = salesDetail.WarehouseName; // �q�ɖ���
                salesDetailWork.WarehouseShelfNo = salesDetail.WarehouseShelfNo; // �q�ɒI��
                salesDetailWork.SalesOrderDivCd = salesDetail.SalesOrderDivCd; // ����݌Ɏ�񂹋敪
                salesDetailWork.OpenPriceDiv = salesDetail.OpenPriceDiv; // �I�[�v�����i�敪
                salesDetailWork.GoodsRateRank = salesDetail.GoodsRateRank; // ���i�|�������N
                salesDetailWork.CustRateGrpCode = salesDetail.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
                salesDetailWork.ListPriceRate = salesDetail.ListPriceRate; // �艿��
                salesDetailWork.RateSectPriceUnPrc = salesDetail.RateSectPriceUnPrc; // �|���ݒ苒�_�i�艿�j
                salesDetailWork.RateDivLPrice = salesDetail.RateDivLPrice; // �|���ݒ�敪�i�艿�j
                salesDetailWork.UnPrcCalcCdLPrice = salesDetail.UnPrcCalcCdLPrice; // �P���Z�o�敪�i�艿�j
                salesDetailWork.PriceCdLPrice = salesDetail.PriceCdLPrice; // ���i�敪�i�艿�j
                salesDetailWork.StdUnPrcLPrice = salesDetail.StdUnPrcLPrice; // ��P���i�艿�j
                salesDetailWork.FracProcUnitLPrice = salesDetail.FracProcUnitLPrice; // �[�������P�ʁi�艿�j
                salesDetailWork.FracProcLPrice = salesDetail.FracProcLPrice; // �[�������i�艿�j
                salesDetailWork.ListPriceTaxIncFl = salesDetail.ListPriceTaxIncFl; // �艿�i�ō��C�����j
                salesDetailWork.ListPriceTaxExcFl = salesDetail.ListPriceTaxExcFl; // �艿�i�Ŕ��C�����j
                salesDetailWork.ListPriceChngCd = salesDetail.ListPriceChngCd; // �艿�ύX�敪
                salesDetailWork.SalesRate = salesDetail.SalesRate; // ������
                salesDetailWork.RateSectSalUnPrc = salesDetail.RateSectSalUnPrc; // �|���ݒ苒�_�i����P���j
                salesDetailWork.RateDivSalUnPrc = salesDetail.RateDivSalUnPrc; // �|���ݒ�敪�i����P���j
                salesDetailWork.UnPrcCalcCdSalUnPrc = salesDetail.UnPrcCalcCdSalUnPrc; // �P���Z�o�敪�i����P���j
                salesDetailWork.PriceCdSalUnPrc = salesDetail.PriceCdSalUnPrc; // ���i�敪�i����P���j
                salesDetailWork.StdUnPrcSalUnPrc = salesDetail.StdUnPrcSalUnPrc; // ��P���i����P���j
                salesDetailWork.FracProcUnitSalUnPrc = salesDetail.FracProcUnitSalUnPrc; // �[�������P�ʁi����P���j
                salesDetailWork.FracProcSalUnPrc = salesDetail.FracProcSalUnPrc; // �[�������i����P���j
                salesDetailWork.SalesUnPrcTaxIncFl = salesDetail.SalesUnPrcTaxIncFl; // ����P���i�ō��C�����j
                salesDetailWork.SalesUnPrcTaxExcFl = salesDetail.SalesUnPrcTaxExcFl; // ����P���i�Ŕ��C�����j
                salesDetailWork.SalesUnPrcChngCd = salesDetail.SalesUnPrcChngCd; // ����P���ύX�敪
                salesDetailWork.CostRate = salesDetail.CostRate; // ������
                salesDetailWork.RateSectCstUnPrc = salesDetail.RateSectCstUnPrc; // �|���ݒ苒�_�i�����P���j
                salesDetailWork.RateDivUnCst = salesDetail.RateDivUnCst; // �|���ݒ�敪�i�����P���j
                salesDetailWork.UnPrcCalcCdUnCst = salesDetail.UnPrcCalcCdUnCst; // �P���Z�o�敪�i�����P���j
                salesDetailWork.PriceCdUnCst = salesDetail.PriceCdUnCst; // ���i�敪�i�����P���j
                salesDetailWork.StdUnPrcUnCst = salesDetail.StdUnPrcUnCst; // ��P���i�����P���j
                salesDetailWork.FracProcUnitUnCst = salesDetail.FracProcUnitUnCst; // �[�������P�ʁi�����P���j
                salesDetailWork.FracProcUnCst = salesDetail.FracProcUnCst; // �[�������i�����P���j
                salesDetailWork.SalesUnitCost = salesDetail.SalesUnitCost; // �����P��
                salesDetailWork.SalesUnitCostChngDiv = salesDetail.SalesUnitCostChngDiv; // �����P���ύX�敪
                salesDetailWork.RateBLGoodsCode = salesDetail.RateBLGoodsCode; // BL���i�R�[�h�i�|���j
                salesDetailWork.RateBLGoodsName = salesDetail.RateBLGoodsName; // BL���i�R�[�h���́i�|���j
                salesDetailWork.RateGoodsRateGrpCd = salesDetail.RateGoodsRateGrpCd; // ���i�|���O���[�v�R�[�h�i�|���j
                salesDetailWork.RateGoodsRateGrpNm = salesDetail.RateGoodsRateGrpNm; // ���i�|���O���[�v���́i�|���j
                salesDetailWork.RateBLGroupCode = salesDetail.RateBLGroupCode; // BL�O���[�v�R�[�h�i�|���j
                salesDetailWork.RateBLGroupName = salesDetail.RateBLGroupName; // BL�O���[�v���́i�|���j
                salesDetailWork.PrtBLGoodsCode = salesDetail.PrtBLGoodsCode; // BL���i�R�[�h�i����j
                salesDetailWork.PrtBLGoodsName = salesDetail.PrtBLGoodsName; // BL���i�R�[�h���́i����j
                salesDetailWork.SalesCode = salesDetail.SalesCode; // �̔��敪�R�[�h
                salesDetailWork.SalesCdNm = salesDetail.SalesCdNm; // �̔��敪����
                salesDetailWork.WorkManHour = salesDetail.WorkManHour; // ��ƍH��
                salesDetailWork.ShipmentCnt = salesDetail.ShipmentCnt; // �o�א�
                salesDetailWork.AcceptAnOrderCnt = salesDetail.AcceptAnOrderCnt; // �󒍐���
                salesDetailWork.AcptAnOdrAdjustCnt = salesDetail.AcptAnOdrAdjustCnt; // �󒍒�����
                salesDetailWork.AcptAnOdrRemainCnt = salesDetail.AcptAnOdrRemainCnt; // �󒍎c��
                salesDetailWork.RemainCntUpdDate = salesDetail.RemainCntUpdDate; // �c���X�V��
                salesDetailWork.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxInc; // ������z�i�ō��݁j
                salesDetailWork.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc; // ������z�i�Ŕ����j
                salesDetailWork.Cost = salesDetail.Cost; // ����
                salesDetailWork.GrsProfitChkDiv = salesDetail.GrsProfitChkDiv; // �e���`�F�b�N�敪
                salesDetailWork.SalesGoodsCd = salesDetail.SalesGoodsCd; // ���㏤�i�敪
                salesDetailWork.SalesPriceConsTax = salesDetail.SalesPriceConsTax; // ������z����Ŋz
                salesDetailWork.TaxationDivCd = salesDetail.TaxationDivCd; // �ېŋ敪
                salesDetailWork.PartySlipNumDtl = salesDetail.PartySlipNumDtl; // �����`�[�ԍ��i���ׁj
                salesDetailWork.DtlNote = salesDetail.DtlNote; // ���ה��l
                salesDetailWork.SupplierCd = salesDetail.SupplierCd; // �d����R�[�h
                salesDetailWork.SupplierSnm = salesDetail.SupplierSnm; // �d���旪��
                salesDetailWork.OrderNumber = salesDetail.OrderNumber; // �����ԍ�
                salesDetailWork.WayToOrder = salesDetail.WayToOrder; // �������@
                salesDetailWork.SlipMemo1 = salesDetail.SlipMemo1; // �`�[�����P
                salesDetailWork.SlipMemo2 = salesDetail.SlipMemo2; // �`�[�����Q
                salesDetailWork.SlipMemo3 = salesDetail.SlipMemo3; // �`�[�����R
                salesDetailWork.InsideMemo1 = salesDetail.InsideMemo1; // �Г������P
                salesDetailWork.InsideMemo2 = salesDetail.InsideMemo2; // �Г������Q
                salesDetailWork.InsideMemo3 = salesDetail.InsideMemo3; // �Г������R
                salesDetailWork.BfListPrice = salesDetail.BfListPrice; // �ύX�O�艿
                salesDetailWork.BfSalesUnitPrice = salesDetail.BfSalesUnitPrice; // �ύX�O����
                salesDetailWork.BfUnitCost = salesDetail.BfUnitCost; // �ύX�O����
                salesDetailWork.CmpltSalesRowNo = salesDetail.CmpltSalesRowNo; // �ꎮ���הԍ�
                // UPD 2014/09/08 T.Miyamoto ------------------------------>>>>>
                // Tablet�ł̔��㎞�ɏ������[�J�[���o�^����Ȃ��ׁA���L�̍폜�ӏ��𕜊�
                //// DEL 2013/08/29 Redmine#40183�Ή� ------------------------------------>>>>>
                ////salesDetailWork.CmpltGoodsMakerCd = salesDetail.CmpltGoodsMakerCd; // ���[�J�[�R�[�h�i�ꎮ�j
                //// DEL 2013/08/29 Redmine#40183�Ή� ------------------------------------<<<<<
                salesDetailWork.CmpltGoodsMakerCd = salesDetail.CmpltGoodsMakerCd; // ���[�J�[�R�[�h�i�ꎮ�j
                // UPD 2014/09/08 T.Miyamoto ------------------------------<<<<<
                salesDetailWork.CmpltMakerName = salesDetail.CmpltMakerName; // ���[�J�[���́i�ꎮ�j
                salesDetailWork.CmpltGoodsName = salesDetail.CmpltGoodsName; // ���i���́i�ꎮ�j
                salesDetailWork.CmpltShipmentCnt = salesDetail.CmpltShipmentCnt; // ���ʁi�ꎮ�j
                salesDetailWork.CmpltSalesUnPrcFl = salesDetail.CmpltSalesUnPrcFl; // ����P���i�ꎮ�j
                salesDetailWork.CmpltSalesMoney = salesDetail.CmpltSalesMoney; // ������z�i�ꎮ�j
                salesDetailWork.CmpltSalesUnitCost = salesDetail.CmpltSalesUnitCost; // �����P���i�ꎮ�j
                salesDetailWork.CmpltCost = salesDetail.CmpltCost; // �������z�i�ꎮ�j
                salesDetailWork.CmpltPartySalSlNum = salesDetail.CmpltPartySalSlNum; // �����`�[�ԍ��i�ꎮ�j
                salesDetailWork.CmpltNote = salesDetail.CmpltNote; // �ꎮ���l
                salesDetailWork.PrtGoodsNo = salesDetail.PrtGoodsNo; // ����p�i��
                salesDetailWork.PrtMakerCode = salesDetail.PrtMakerCode; // ����p���[�J�[�R�[�h
                salesDetailWork.PrtMakerName = salesDetail.PrtMakerName; // ����p���[�J�[����
                salesDetailWork.DtlRelationGuid = salesDetail.DtlRelationGuid; // ���ʃL�[
                salesDetailWork.AcceptOrOrderKind = salesDetail.AcceptOrOrderKind;// �󔭒����
                salesDetailWork.InquiryNumber = salesDetail.InquiryNumber; // �⍇���ԍ�
                salesDetailWork.InqRowNumber = salesDetail.InqRowNumber; // �⍇���s�ԍ�
                salesDetailWork.AutoAnswerDivSCM = salesDetail.AutoAnswerDivSCM; // �����񓚋敪(SCM)
                salesDetailWork.AnswerDelivDate = salesDetail.AnswerDelivDate; // �񓚔[��
                salesDetailWork.WayToAcptOdr = salesDetail.WayToAcptOdr; // �󒍕��@
                salesDetailWork.GoodsSpecialNote = salesDetail.GoodsSpecialNote; // ���L����
                // ADD �g�� 2013/08/06 Redmine#39637 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                salesDetailWork.CampaignCode = salesDetail.CampaignCode;    // �L�����y�[���R�[�h
                // ADD �g�� 2013/08/06 Redmine#39637 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            return salesDetailWork;
        }
        #endregion // </���㖾�׃f�[�^���[�N>
        #endregion // </�����[�g�p���[�N�f�[�^>
        // ----------------- ADD 2013/07/03 qijh Redmine#37586 --------------- <<<<<
        #endregion
    }
}
