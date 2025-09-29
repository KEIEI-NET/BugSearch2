//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�ʏo�׎��ѕ\
// �v���O�����T�v   : ���q�ʏo�׎��ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/09/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/10/13  �C�����e : �e���� =�i�e�� �� ������z�j*100��ύX����
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using System.Collections.Specialized;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���q�ʏo�׎��ѕ\ �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���q�ʏo�׎��ѕ\�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer	: ����</br>
    /// <br>Date		: 2009.09.15</br>
    /// <br>UpdateNote	: ���� 2009.10.13</br>
    /// <br>    		: �e���� =�i�e�� �� ������z�j*100��ύX����</br>
    /// </remarks>
    public class CarShipRsltAcs
    {
        #region �� Constructor
        /// <summary>
        /// ���q�ʏo�׎��ѕ\�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���q�ʏo�׎��ѕ\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        public CarShipRsltAcs()
        {
            this._iCarShipResultDB = (ICarShipResultDB)MediationCarShipResultDB.GetCarShipWorkDB();
        }

        /// <summary>
        /// ���q�ʏo�׎��ѕ\�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���q�ʏo�׎��ѕ\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        static CarShipRsltAcs()
        {
            stc_Employee = null;
            stc_PrtOutSet = null;					// ���[�o�͐ݒ�f�[�^�N���X	
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }
        }
        #endregion �� Constructor

        #region �� Static Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			            // ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	            // ���[�o�͐ݒ�A�N�Z�X�N���X

        #endregion �� Static Member

        #region �� Private Member
        ICarShipResultDB _iCarShipResultDB;

        private DataSet _carShipListDs;	    		// ���DataTable
        private bool lineFlg = false;
        // �y�[�W���ς�����ꍇ
        private bool newPage = false;
        // �v�����y�[�W���ς�����ꍇ
        private bool diffPage = false;
        // detail�f�[�^�y�[�W���ς�����ꍇ
        private bool detailPage = false;
        // BLGroup�v�̏ꍇ�y�[�W���ς�����ꍇ
        private bool BLGroupPage = false;
        // Car�v�̏ꍇ�y�[�W���ς�����ꍇ
        private bool carPage = false;
        private bool carGroupPage = false;
        #endregion �� Private Member

        #region �� Pricate Const
        const string ct_Extr_Top = "�ŏ�����";
        const string ct_Extr_End = "�Ō�܂�";
        const string ct_Space = "�@";
        #endregion �� Pricate Const

        #region �� Public Property
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet CarShipListDs
        {
            get { return this._carShipListDs; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� �o�̓f�[�^�擾
        #region �� �����f�[�^�擾
        /// <summary>
        /// �d���f�[�^�擾
        /// </summary>
        /// <param name="carShip">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������d���f�[�^���擾����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        public int SearchCarShipProcMain(CarShipRsltListCndtn carShip, out string errMsg)
        {
            return this.SearchCarShipProc(carShip, out errMsg);
        }
        #endregion
        #endregion �� �o�̓f�[�^�擾
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� �f�[�^�擾
        /// <summary>
        /// �d���f�[�^�擾
        /// </summary>
        /// <param name="carShipCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������d���f�[�^���擾����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private int SearchCarShipProc(CarShipRsltListCndtn carShipCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMSYA02005EA.CreateDataTable(ref this._carShipListDs);

                // ���o�����W�J  --------------------------------------------------------------
                CarShipRsltCndtnWork carShipRsltCndtnWork = new CarShipRsltCndtnWork();
                status = this.DevCarShip(carShipCndtn, out carShipRsltCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object carShipResultWork = null;
                status = this._iCarShipResultDB.Search(out carShipResultWork, (object)carShipRsltCndtnWork);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        ArrayList carShipResultList = carShipResultWork as ArrayList;
                        // �f�[�^�W�v����
                        if ((int)carShipCndtn.GroupBySectionDiv == 0)
                        {
                            CarDataGroup(carShipCndtn, ref carShipResultList);
                        }

                        // lineFlg�̎擾�����i���o�����ҏW�����j
                        StringCollection extraInfomations;

                        this.MakeExtarCondition(out extraInfomations,carShipCndtn);


                        // �f�[�^�W�J����
                        DevCarShipMainData(carShipCndtn, this._carShipListDs.Tables[PMSYA02005EA.Tbl_CarShipListData], carShipResultList);

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;                      
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "���q�ʏo�׎��ѕ\�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion �� ���[�f�[�^�擾

        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="carShipCndtn">UI���o�����N���X</param>
        /// <param name="carShipRsltCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevCarShip(CarShipRsltListCndtn carShipCndtn, out CarShipRsltCndtnWork carShipRsltCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            carShipRsltCndtnWork = new CarShipRsltCndtnWork();
            try
            {
                // ��ƃR�[�h 
                carShipRsltCndtnWork.EnterpriseCode = carShipCndtn.EnterpriseCode;
                // ���_�R�[�h���X�g
                carShipRsltCndtnWork.SectionCodeList = carShipCndtn.SectionCodeList;
                // �W�v���@
                carShipRsltCndtnWork.GroupBySectionDiv = (int)carShipCndtn.GroupBySectionDiv;
                // �����(�J�n)
                carShipRsltCndtnWork.SalesDateSt = carShipCndtn.SalesDateSt;
                // �����(�I��)
                carShipRsltCndtnWork.SalesDateEd = carShipCndtn.SalesDateEd;
                // ���͓�(�J�n)
                carShipRsltCndtnWork.InputDateSt = carShipCndtn.InputDateSt;
                // ���͓�(�I��)
                carShipRsltCndtnWork.InputDateEd = carShipCndtn.InputDateEd;
                // �݌Ɏ�񂹋敪
                carShipRsltCndtnWork.RsltTtlDiv = (int)carShipCndtn.RsltTtlDiv;
                // �i�ԏo��
                carShipRsltCndtnWork.GoodsNoPrint = (int)carShipCndtn.GoodsNoPrint;
                // �����E�e���o��
                carShipRsltCndtnWork.CostGrossPrint = (int)carShipCndtn.CostGrossPrint;
                // ����
                carShipRsltCndtnWork.NewPageDiv = (int)carShipCndtn.NewPageDiv;
                // ���גP��
                carShipRsltCndtnWork.DetailDataValue = (int)carShipCndtn.DetailDataValue;
                // �J�n���Ӑ�R�[�h
                carShipRsltCndtnWork.CustomerCodeSt = carShipCndtn.CustomerCodeSt;
                // �I�����Ӑ�R�[�h
                carShipRsltCndtnWork.CustomerCodeEd = carShipCndtn.CustomerCodeEd;
                // �J�n�Ǘ��ԍ��R�[�h
                carShipRsltCndtnWork.CarMngCodeSt = carShipCndtn.CarMngCodeSt;
                // �I���Ǘ��ԍ��R�[�h
                carShipRsltCndtnWork.CarMngCodeEd = carShipCndtn.CarMngCodeEd;
                // �J�nBL�O���[�v�R�[�h
                carShipRsltCndtnWork.BLGroupCodeSt = carShipCndtn.BLGroupCodeSt;
                // �I��BL�O���[�v�R�[�h
                carShipRsltCndtnWork.BLGroupCodeEd = carShipCndtn.BLGroupCodeEd;
                // �J�nBL���i�R�[�h
                carShipRsltCndtnWork.BLGoodsCodeSt = carShipCndtn.BLGoodsCodeSt;
                // �I��BL���i�R�[�h
                carShipRsltCndtnWork.BLGoodsCodeEd = carShipCndtn.BLGoodsCodeEd;
                // �J�n�i��
                carShipRsltCndtnWork.GoodsNoSt = carShipCndtn.GoodsNoSt;
                // �I���i��
                carShipRsltCndtnWork.GoodsNoEd = carShipCndtn.GoodsNoEd;
                // ���q���l
                carShipRsltCndtnWork.SlipNoteCar = carShipCndtn.SlipNoteCar;
                // ���q���o�敪
                carShipRsltCndtnWork.CarOutDiv = (int)carShipCndtn.CarOutDiv;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        #endregion �� ���o�����W�J����

        #region �� �f�[�^�W�J����
        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="carShipCndtn">UI���o�����N���X</param>
        /// <param name="resultWork">�擾�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void CarDataGroup(CarShipRsltListCndtn carShipCndtn, ref ArrayList resultWork)
        {
            Hashtable carDataTable = new Hashtable();
            string checkKey = string.Empty;

            foreach (CarShipResultWork carShipResultWork in resultWork)
            {
                // �W�v���@�́u���ѕ\�v�A���גP�ʂ́u�i�ԁv
                // �W�v���̂j�d�x����
                // ���ьv�㋒�_�R�[�h�E���Ӑ�R�[�h�E���q�Ǘ��R�[�h�E�ԗ��Ǘ��ԍ��E�O���[�v�R�[�h�EBL�R�[�h�E���i�ԍ��E���i���[�J�[�R�[�h
                if ((int)carShipCndtn.DetailDataValue == 0)
                {
                    checkKey = carShipResultWork.ResultsAddUpSecCd +
                                         "_" + carShipResultWork.CustomerCode.ToString("00000000") +
                                         "_" + carShipResultWork.CarMngCode +
                                         "_" + carShipResultWork.CarMngNo +
                                         "_" + carShipResultWork.BLGroupCode.ToString("00000") +
                                         "_" + carShipResultWork.BLGoodsCode.ToString("00000") +
                                         "_" + carShipResultWork.GoodsNo +
                                         "_" + carShipResultWork.GoodsMakerCd.ToString("0000");

                }

                // �W�v���@�́u���ѕ\�v�A���גP�ʂ́u�a�k�R�[�h�v
                // �W�v���̂j�d�x����
                // ���ьv�㋒�_�R�[�h�E���Ӑ�R�[�h�E���q�Ǘ��R�[�h�E�ԗ��Ǘ��ԍ��E�O���[�v�R�[�h�EBL�R�[�h
                if ((int)carShipCndtn.DetailDataValue == 1)
                {
                    checkKey = carShipResultWork.ResultsAddUpSecCd +
                                        "_" + carShipResultWork.CustomerCode.ToString("00000000") +
                                        "_" + carShipResultWork.CarMngCode +
                                        "_" + carShipResultWork.CarMngNo +
                                        "_" + carShipResultWork.BLGroupCode.ToString("00000") +
                                        "_" + carShipResultWork.BLGoodsCode.ToString("00000");
                }
                // �W�v���@�́u���ѕ\�v�A���גP�ʂ́u�O���[�v�R�[�h�v
                // �W�v���̂j�d�x����
                // ���ьv�㋒�_�R�[�h�E���Ӑ�R�[�h�E���q�Ǘ��R�[�h�E�ԗ��Ǘ��ԍ��E�O���[�v�R�[�h
                if ((int)carShipCndtn.DetailDataValue == 2)
                {
                    checkKey = carShipResultWork.ResultsAddUpSecCd +
                                        "_" + carShipResultWork.CustomerCode.ToString("00000000") +
                                        "_" + carShipResultWork.CarMngCode +
                                        "_" + carShipResultWork.CarMngNo +
                                        "_" + carShipResultWork.BLGroupCode.ToString("00000");
                }

                if (carDataTable.Contains(checkKey))
                {
                    CarShipResultWork carShipResultWorkInTable = (CarShipResultWork)carDataTable[checkKey];
                    // �o�א�
                    carShipResultWork.ShipmentCnt += carShipResultWorkInTable.ShipmentCnt;
                    // �o�א�(�݌�)
                    carShipResultWork.ShipmentCntIn += carShipResultWorkInTable.ShipmentCntIn;
                    // �o�א�(���)
                    carShipResultWork.ShipmentCntNotIn += carShipResultWorkInTable.ShipmentCntNotIn;
                    // ������z�i�Ŕ����j
                    carShipResultWork.SalesMoneyTaxExc += carShipResultWorkInTable.SalesMoneyTaxExc;
                    // �e�����z
                    carShipResultWork.GrossProfit += carShipResultWorkInTable.GrossProfit;

                    carDataTable.Remove(checkKey);
                    carDataTable.Add(checkKey, carShipResultWork);

                }
                else
                {
                    carDataTable.Add(checkKey, carShipResultWork);
                }
            }
            List<string> sortKey = new List<string>();
            foreach (string key in carDataTable.Keys)
            {
                sortKey.Add(key);
            }
            sortKey.Sort();
            string keyDet = string.Empty;
            resultWork.Clear();
            for (int i = 0; i < sortKey.Count;i++ )
            {
                keyDet = sortKey[i];

                if (carDataTable.Contains(keyDet))
                {
                    resultWork.Add(carDataTable[keyDet]);
                }
            }
            //resultWork = new ArrayList(carDataTable.Values);
        }


        #endregion �� �f�[�^�W�J����

        #region �� ���[�ݒ�f�[�^�擾
        #region �� ���[�o�͐ݒ�擾����
        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
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
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion �� ���[�ݒ�f�[�^�擾

        /// <summary>
        /// ���[�ݒ�f�[�^�擾����
        /// </summary>
        /// <param name="carShipRsltListCndtn">UI���o�����N���X</param>
        /// <param name="carShipRsltDt">carShipRsltDt</param>
        /// <param name="carShipRsltWork">�擾�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void DevCarShipMainData(CarShipRsltListCndtn carShipRsltListCndtn, DataTable carShipRsltDt, ArrayList carShipRsltWork)
        {
            DataRow dr;
            CarShipResultWork disCarShipResultWork = null;
            CarShipResultWork nextDisCarShipResultWork = null;
            CarShipResultWork lastDisCarShipResultWork = null;
            int count = carShipRsltWork.Count;
            int k = 0;
            for (int i = 0; i < count; i++)
            {
                disCarShipResultWork = (CarShipResultWork)carShipRsltWork[i];
                if (i + 1 < count)
                {
                    nextDisCarShipResultWork = (CarShipResultWork)carShipRsltWork[i + 1];
                }
                dr = carShipRsltDt.NewRow();
                //����`�[�ԍ�
                dr[PMSYA02005EA.ct_Col_SalesSlipNumRF] = disCarShipResultWork.SalesSlipNum;
                //���ьv�㋒�_�R�[�h
                dr[PMSYA02005EA.ct_Col_ResultsAddUpSecCdRF] = disCarShipResultWork.ResultsAddUpSecCd;
                //������t
                dr[PMSYA02005EA.ct_Col_SalesDateRF] = disCarShipResultWork.SalesDate;
                //���Ӑ�R�[�h
                dr[PMSYA02005EA.ct_Col_CustomerCodeRF] = disCarShipResultWork.CustomerCode;
                //���Ӑ旪��
                if (string.IsNullOrEmpty(disCarShipResultWork.CustomerSnm))
                {
                    dr[PMSYA02005EA.ct_Col_CustomerSnmRF] = "���o�^";
                }
                else
                {
                    dr[PMSYA02005EA.ct_Col_CustomerSnmRF] = disCarShipResultWork.CustomerSnm;
                }
               
                //����s�ԍ�
                dr[PMSYA02005EA.ct_Col_SalesRowNoRF] = disCarShipResultWork.SalesRowNo;
                //���i���[�J�[�R�[�h
                dr[PMSYA02005EA.ct_Col_GoodsMakerCdRF] = disCarShipResultWork.GoodsMakerCd;
                //���i�ԍ�
                dr[PMSYA02005EA.ct_Col_GoodsNoRF] = disCarShipResultWork.GoodsNo;
                //���i���̃J�i
                dr[PMSYA02005EA.ct_Col_GoodsNameKanaRF] = disCarShipResultWork.GoodsNameKana;
                //BL���i�R�[�h
                dr[PMSYA02005EA.ct_Col_BLGoodsCodeRF] = disCarShipResultWork.BLGoodsCode;
                //BL���i�R�[�hCopy
                dr[PMSYA02005EA.ct_Col_BLGoodsCodeRFCopy] = disCarShipResultWork.BLGoodsCode;
                //BL���i�R�[�h���́i���p�j
                if (string.IsNullOrEmpty(disCarShipResultWork.BLGoodsHalfName))
                {
                    dr[PMSYA02005EA.ct_Col_BLGoodsHalfNameRF] = "���o�^";
                }
                else
                {
                    dr[PMSYA02005EA.ct_Col_BLGoodsHalfNameRF] = disCarShipResultWork.BLGoodsHalfName;
                }
                //BL�O���[�v�R�[�h
                dr[PMSYA02005EA.ct_Col_BLGroupCodeRF] = disCarShipResultWork.BLGroupCode;
                //BL�O���[�v�R�[�hCopy
                dr[PMSYA02005EA.ct_Col_BLGroupCodeRFCopy] = disCarShipResultWork.BLGroupCode;
                //BL�O���[�v�R�[�h�J�i����
                if (string.IsNullOrEmpty(disCarShipResultWork.BLGroupKanaName))
                {
                    dr[PMSYA02005EA.ct_Col_BLGroupKanaNameRF] = "���o�^";
                }
                else
                {
                    dr[PMSYA02005EA.ct_Col_BLGroupKanaNameRF] = disCarShipResultWork.BLGroupKanaName;
                }
                //�艿�i�Ŕ��C�����j
                dr[PMSYA02005EA.ct_Col_ListPriceTaxExcFlRF] = disCarShipResultWork.ListPriceTaxExcFl;
                //����P���i�Ŕ��C�����j
                dr[PMSYA02005EA.ct_Col_SalesUnPrcTaxExcFlRF] = disCarShipResultWork.SalesUnPrcTaxExcFl;
                //�����P��
                dr[PMSYA02005EA.ct_Col_SalesUnitCostRF] = disCarShipResultWork.SalesUnitCost;
                //�o�א�
                dr[PMSYA02005EA.ct_Col_ShipmentCntRF] = disCarShipResultWork.ShipmentCnt;
                //�o�א�(�݌�)
                dr[PMSYA02005EA.ct_Col_ShipmentCntInRF] = disCarShipResultWork.ShipmentCntIn;
                //�o�א�(���)
                dr[PMSYA02005EA.ct_Col_ShipmentCntNotInRF] = disCarShipResultWork.ShipmentCntNotIn;
                // ����݌Ɏ�񂹋敪
                // ����݌Ɏ�񂹋敪��1(�݌�)�͋󔒁A��0(���)��"*"���Z�b�g
                if (disCarShipResultWork.SalesOrderDivCd == 1)
                {
                    dr[PMSYA02005EA.ct_Col_SalesOrderDivCdRF] = "";
                }
                else if (disCarShipResultWork.SalesOrderDivCd == 0)
                {
                    dr[PMSYA02005EA.ct_Col_SalesOrderDivCdRF] = "*";
                }
                //������z�i�Ŕ����j
                dr[PMSYA02005EA.ct_Col_SalesMoneyTaxExcRF] = disCarShipResultWork.SalesMoneyTaxExc;
                //���_�K�C�h����
                if(string.IsNullOrEmpty(disCarShipResultWork.SectionGuideSnm))
                {
                    dr[PMSYA02005EA.ct_Col_SectionGuideSnmRF] = "���o�^";
                }
                else
                {
                    dr[PMSYA02005EA.ct_Col_SectionGuideSnmRF] = disCarShipResultWork.SectionGuideSnm;
                }
                
                //�e�����z
                dr[PMSYA02005EA.ct_Col_GrossProfitRF] = disCarShipResultWork.GrossProfit;
                //�e����
                // �[������
                double grosspiv = 0;
                if (disCarShipResultWork.SalesMoneyTaxExc != 0)
                {
                    // --- UPD 2009/10/13 ------>>>>>
                    // �e�����@�i�e�� �� ������z�j*100�@
                    // grosspiv = ((double)disCarShipResultWork.GrossProfit)/((double)disCarShipResultWork.SalesMoneyTaxExc);
                    grosspiv = (((double)disCarShipResultWork.GrossProfit)/((double)disCarShipResultWork.SalesMoneyTaxExc))*100;
                    // --- UPD 2009/10/13 ------<<<<<
                }
                dr[PMSYA02005EA.ct_Col_GrossPivRF] = grosspiv.ToString("f2");
                //�ԗ��Ǘ��ԍ�
                dr[PMSYA02005EA.ct_Col_CarMngNoRF] = disCarShipResultWork.CarMngCode + disCarShipResultWork.CarMngNo.ToString();
                //���q�Ǘ��R�[�h
                dr[PMSYA02005EA.ct_Col_CarMngCodeRF] = disCarShipResultWork.CarMngCode;
                //���^�����ǖ���
                dr[PMSYA02005EA.ct_Col_NumberPlate1NameRF] = disCarShipResultWork.NumberPlate1Name;
                //�ԗ��o�^�ԍ��i��ʁj
                dr[PMSYA02005EA.ct_Col_NumberPlate2RF] = disCarShipResultWork.NumberPlate2;
                //�ԗ��o�^�ԍ��i�J�i�j
                dr[PMSYA02005EA.ct_Col_NumberPlate3RF] = disCarShipResultWork.NumberPlate3;
                //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                if (disCarShipResultWork.NumberPlate4 != 0)
                {
                    dr[PMSYA02005EA.ct_Col_NumberPlate4RF] = disCarShipResultWork.NumberPlate4;
                }
                else
                {
                    dr[PMSYA02005EA.ct_Col_NumberPlate4RF] = string.Empty;
                }

                //���N�x
                if (DateTime.MinValue.Equals(disCarShipResultWork.FirstEntryDate))
                {
                    dr[PMSYA02005EA.ct_Col_FirstEntryDateRF] = "";
                }
                else
                {
                    dr[PMSYA02005EA.ct_Col_FirstEntryDateRF] = disCarShipResultWork.FirstEntryDate;
                }
                
                //���[�J�[�R�[�h
                dr[PMSYA02005EA.ct_Col_MakerCodeRF] = disCarShipResultWork.MakerCode;
                //�Ԏ�R�[�h
                dr[PMSYA02005EA.ct_Col_ModelCodeRF] = disCarShipResultWork.ModelCode;
                //�Ԏ�T�u�R�[�h
                dr[PMSYA02005EA.ct_Col_ModelSubCodeRF] = disCarShipResultWork.ModelSubCode;
                //�Ԏ피�p����
                dr[PMSYA02005EA.ct_Col_ModelHalfNameRF] = disCarShipResultWork.ModelHalfName;
                //�^���i�t���^�j
                dr[PMSYA02005EA.ct_Col_FullModelRF] = disCarShipResultWork.FullModel;
                //�ԗ����s����
                dr[PMSYA02005EA.ct_Col_MileageRF] = disCarShipResultWork.Mileage;
                // lineShow
                dr[PMSYA02005EA.ct_Col_LineShow] = true;

                //�󔒂���������
                if (count > 1)
                {
                    
                    if (i == 0)
                    {
                        if ((int)carShipRsltListCndtn.GroupBySectionDiv == 1)
                        {
                            // Line_Show
                            if ((disCarShipResultWork.ResultsAddUpSecCd.Equals(nextDisCarShipResultWork.ResultsAddUpSecCd))
                                && (disCarShipResultWork.CustomerCode == nextDisCarShipResultWork.CustomerCode)
                                && (disCarShipResultWork.CarMngCode == nextDisCarShipResultWork.CarMngCode)
                                && (disCarShipResultWork.CarMngNo == nextDisCarShipResultWork.CarMngNo))
                            {
                                if (disCarShipResultWork.SalesDate == nextDisCarShipResultWork.SalesDate)
                                {
                                    if (disCarShipResultWork.SalesSlipNum == nextDisCarShipResultWork.SalesSlipNum)
                                    {
                                        // lineShow
                                        dr[PMSYA02005EA.ct_Col_LineShow] = false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        lastDisCarShipResultWork = (CarShipResultWork)carShipRsltWork[i - 1];

                        //���ѕ\
                        if (((int)carShipRsltListCndtn.GroupBySectionDiv == 0))
                        {
                            //�i��
                            if (((int)carShipRsltListCndtn.DetailDataValue == 0) || ((int)carShipRsltListCndtn.DetailDataValue == 1))
                            {
                                if ((int)carShipRsltListCndtn.GroupBySectionDiv == 0)
                                {
                                    //���ѕ\
                                    //���_�Ɠ��Ӑ�Ǝ��q�Ǘ��R�[�h�Ǝԗ��Ǘ��ԍ�
                                    if ((disCarShipResultWork.ResultsAddUpSecCd == lastDisCarShipResultWork.ResultsAddUpSecCd)
                                        && (disCarShipResultWork.CustomerCode == lastDisCarShipResultWork.CustomerCode)
                                        && (disCarShipResultWork.CarMngCode == lastDisCarShipResultWork.CarMngCode)
                                        && (disCarShipResultWork.CarMngNo == lastDisCarShipResultWork.CarMngNo))
                                    {
                                        if (disCarShipResultWork.BLGroupCode == lastDisCarShipResultWork.BLGroupCode)
                                        {
                                            if (disCarShipResultWork.BLGoodsCode == lastDisCarShipResultWork.BLGoodsCode)
                                            {
                                                //BL���i�R�[�h
                                                dr[PMSYA02005EA.ct_Col_BLGoodsCodeRF] = string.Empty;
                                                //BL���i�R�[�h���́i���p�j
                                                dr[PMSYA02005EA.ct_Col_BLGoodsHalfNameRF] = string.Empty;

                                                if (disCarShipResultWork.GoodsNameKana == lastDisCarShipResultWork.GoodsNameKana)
                                                {
                                                    //���i���̃J�i
                                                    dr[PMSYA02005EA.ct_Col_GoodsNameKanaRF] = string.Empty;
                                                }
                                            }
                                        }
                                        

                                    }
                                }
                            }
                            else if ((int)carShipRsltListCndtn.DetailDataValue == 2)
                            {
                                //�O���[�v�R�[�h
                                //���_�Ɠ��Ӑ�Ǝ��q�Ǘ��R�[�h�Ǝԗ��Ǘ��ԍ�
                                if ((disCarShipResultWork.ResultsAddUpSecCd == lastDisCarShipResultWork.ResultsAddUpSecCd)
                                    && (disCarShipResultWork.CustomerCode == lastDisCarShipResultWork.CustomerCode)
                                    && (disCarShipResultWork.CarMngCode == lastDisCarShipResultWork.CarMngCode)
                                    && (disCarShipResultWork.CarMngNo == lastDisCarShipResultWork.CarMngNo))
                                {
                                    if (disCarShipResultWork.BLGroupCode == lastDisCarShipResultWork.BLGroupCode)
                                    {
                                        //�O���[�v�R�[�h
                                        dr[PMSYA02005EA.ct_Col_BLGroupCodeRF] = string.Empty;
                                    }
                                }
                            }
                        }
                        else
                        {
                            //���X�g
                            //���_�Ɠ��Ӑ�Ǝ��q�Ǘ��R�[�h�Ǝԗ��Ǘ��ԍ�
                            if ((disCarShipResultWork.ResultsAddUpSecCd.Equals(lastDisCarShipResultWork.ResultsAddUpSecCd))
                                && (disCarShipResultWork.CustomerCode == lastDisCarShipResultWork.CustomerCode)
                                && (disCarShipResultWork.CarMngCode == lastDisCarShipResultWork.CarMngCode)
                                && (disCarShipResultWork.CarMngNo == lastDisCarShipResultWork.CarMngNo))
                            {

                                if (disCarShipResultWork.SalesDate == lastDisCarShipResultWork.SalesDate)
                                {
                                    //������t
                                    dr[PMSYA02005EA.ct_Col_SalesDateRF] = string.Empty;
                                    if (disCarShipResultWork.SalesSlipNum == lastDisCarShipResultWork.SalesSlipNum)
                                    {
                                        //����`�[�ԍ�
                                        dr[PMSYA02005EA.ct_Col_SalesSlipNumRF] = string.Empty;
                                    }
                                }

                            }
                            // Line_Show
                            if ((disCarShipResultWork.ResultsAddUpSecCd.Equals(nextDisCarShipResultWork.ResultsAddUpSecCd))
                                && (disCarShipResultWork.CustomerCode == nextDisCarShipResultWork.CustomerCode)
                                && (disCarShipResultWork.CarMngCode == nextDisCarShipResultWork.CarMngCode)
                                && (disCarShipResultWork.CarMngNo == nextDisCarShipResultWork.CarMngNo))
                            {
                                if (disCarShipResultWork.SalesDate == nextDisCarShipResultWork.SalesDate)
                                {
                                    if (disCarShipResultWork.SalesSlipNum == nextDisCarShipResultWork.SalesSlipNum)
                                    {
                                        // lineShow
                                        dr[PMSYA02005EA.ct_Col_LineShow] = false;
                                    }
                                }
                            }
                        }
                    }

                    //���y�[�W�ɁA���s�f�[�^���Z�b�g����
                    if (i == 0)
                    {
                        if ((int)carShipRsltListCndtn.GroupBySectionDiv == 0)
                        {
                             //�i��
                            if ((int)carShipRsltListCndtn.DetailDataValue != 2)
                            {
                                k++;
                                k++;
                            }
                            else
                            {
                                k++;
                            }

                        }
                        else
                        {
                            k++;
                        }
                        
                    }
                   
                    string disCarMngNo = disCarShipResultWork.CarMngCode + disCarShipResultWork.CarMngNo.ToString();
                    string nextCarMngNo = nextDisCarShipResultWork.CarMngCode + nextDisCarShipResultWork.CarMngNo.ToString();
                    if ((int)carShipRsltListCndtn.GroupBySectionDiv == 0)
                    {
                        //���ѕ\
                        //���� �Ȃ�
                        if ((int)carShipRsltListCndtn.NewPageDiv == 0)
                        {
                            //���_�Ɠ��Ӑ�
                            if ((disCarShipResultWork.ResultsAddUpSecCd.Equals(nextDisCarShipResultWork.ResultsAddUpSecCd))
                                && (disCarShipResultWork.CustomerCode == nextDisCarShipResultWork.CustomerCode))
                            {
                                k++;
                                detailPage = true;
                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);

                                //�i��
                                if ((int)carShipRsltListCndtn.DetailDataValue == 0)
                                {
                                    //���q�v
                                    if ((disCarMngNo != nextCarMngNo))
                                    {
                                        //BL���i�R�[�h�v
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        //BL�O���[�v�R�[�h�v
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        BLGroupPage = true;
                                        carGroupPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        //���q�v
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        carPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        if (!newPage)
                                        {
                                            //�Ǘ��ԍ�����
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                        if (!newPage)
                                        {
                                            //�O���[�v�R�[�h����
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                    }
                                    else
                                    {
                                        // BL�O���[�v�R�[�h
                                        if (disCarShipResultWork.BLGroupCode != nextDisCarShipResultWork.BLGroupCode)
                                        {
                                            //BL���i�R�[�h�v
                                            k++;
                                            diffPage = true;
                                            detailPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                            //BL�O���[�v�R�[�h�v
                                            k++;
                                            diffPage = true;
                                            detailPage = true;
                                            BLGroupPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                            if (!newPage)
                                            {
                                                //�O���[�v�R�[�h����
                                                k++;
                                                diffPage = true;
                                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                            }
                                        }
                                        else
                                        {
                                            //BL���i�R�[�h
                                            if (disCarShipResultWork.BLGoodsCode != nextDisCarShipResultWork.BLGoodsCode)
                                            {
                                                //BL���i�R�[�h�v
                                                k++;
                                                diffPage = true;
                                                detailPage = true;
                                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                            }
                                        }
                                    }

                                }
                                else if ((int)carShipRsltListCndtn.DetailDataValue == 1)
                                {
                                    // BL����
                                    //���q�v
                                    if (disCarMngNo != nextCarMngNo)
                                    {
                                        //BL�O���[�v�R�[�h�v
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        BLGroupPage = true;
                                        carGroupPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        //���q�v
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        carPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        if (!newPage)
                                        {
                                            //�Ǘ��ԍ�����
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                        if (!newPage)
                                        {
                                            //�O���[�v�R�[�h����
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                    }
                                    else
                                    {
                                        // BL�O���[�v�R�[�h
                                        if (disCarShipResultWork.BLGroupCode != nextDisCarShipResultWork.BLGroupCode)
                                        {
                                            //BL�O���[�v�R�[�h�v
                                            k++;
                                            diffPage = true;
                                            detailPage = true;
                                            BLGroupPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);

                                            if (!newPage)
                                            {
                                                //�O���[�v�R�[�h����
                                                k++;
                                                diffPage = true;
                                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                            }

                                        }
                                    }
                                }

                                //BL�O���[�v�R�[�h
                                else if ((int)carShipRsltListCndtn.DetailDataValue == 2)
                                {
                                    //���q�v
                                    if (disCarMngNo != nextCarMngNo)
                                    {
                                        //���q�v
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        carPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);

                                        if (!newPage)
                                        {
                                            //�Ǘ��ԍ�����
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                    }

                                }
                            }
                            else
                            {
                                //�i��
                                if ((int)carShipRsltListCndtn.DetailDataValue != 2)
                                {
                                    k = 2;
                                }
                                else
                                {
                                    k = 1;
                                }
                            }
                        }
                        else
                        {
                            //���� ���q
                            //���_�Ɠ��Ӑ�Ǝ��q�Ǘ��R�[�h�Ǝԗ��Ǘ��ԍ�
                            if ((disCarShipResultWork.ResultsAddUpSecCd == nextDisCarShipResultWork.ResultsAddUpSecCd)
                                && (disCarShipResultWork.CustomerCode == nextDisCarShipResultWork.CustomerCode)
                                && (disCarShipResultWork.CarMngCode == nextDisCarShipResultWork.CarMngCode)
                                && (disCarShipResultWork.CarMngNo == nextDisCarShipResultWork.CarMngNo))
                            {
                                k++;
                                detailPage = true;
                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                //�i��
                                if ((int)carShipRsltListCndtn.DetailDataValue == 0)
                                {
                                    //BL�O���[�v�R�[�h
                                    if (disCarShipResultWork.BLGroupCode != nextDisCarShipResultWork.BLGroupCode)
                                    {
                                        // BL���i�R�[�h�v
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        // BL�O���[�v�R�[�v
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        BLGroupPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        // BL�O���[�v�R�[����
                                        if (!newPage)
                                        {
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                    }
                                    else
                                    {
                                        //BL���i�R�[�h
                                        if (disCarShipResultWork.BLGoodsCode != nextDisCarShipResultWork.BLGoodsCode)
                                        {
                                            //BL���i�R�[�h�v
                                            k++;
                                            diffPage = true;
                                            detailPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                    }

                                }
                                else if ((int)carShipRsltListCndtn.DetailDataValue == 1)
                                {
                                    //BL�O���[�v�R�[�h
                                    if (disCarShipResultWork.BLGroupCode != nextDisCarShipResultWork.BLGroupCode)
                                    {
                                        //BL�O���[�v�R�[�h�v
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        BLGroupPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);

                                        // BL�O���[�v�R�[����
                                        if (!newPage)
                                        {
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                    }

                                }
                            }
                            else
                            {
                                //�i��
                                if ((int)carShipRsltListCndtn.DetailDataValue != 2)
                                {
                                    k = 2;
                                }
                                else
                                {
                                    k = 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        //���X�g
                        //���� �Ȃ�
                        if ((int)carShipRsltListCndtn.NewPageDiv == 0)
                        {
                            //���_�Ɠ��Ӑ�
                            if ((disCarShipResultWork.ResultsAddUpSecCd.Equals(nextDisCarShipResultWork.ResultsAddUpSecCd))
                                && (disCarShipResultWork.CustomerCode == nextDisCarShipResultWork.CustomerCode))
                            {
                                k++;
                                detailPage = true;
                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);

                                //���q�v
                                if (disCarMngNo != nextCarMngNo)
                                {
                                    k++;
                                    diffPage = true;
                                    detailPage = true;
                                    k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                    // �Ǘ��ԍ�����
                                    if (!newPage)
                                    {
                                        k++;
                                        diffPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                    }
                                }

                            }
                            else
                            {
                                k = 1;
                            }
                        }
                        else
                        {
                            //���� ���q
                            //���_�Ɠ��Ӑ�Ǝ��q�Ǘ��R�[�h�Ǝԗ��Ǘ��ԍ�
                            if ((disCarShipResultWork.ResultsAddUpSecCd == nextDisCarShipResultWork.ResultsAddUpSecCd)
                                && (disCarShipResultWork.CustomerCode == nextDisCarShipResultWork.CustomerCode)
                                && (disCarShipResultWork.CarMngCode == nextDisCarShipResultWork.CarMngCode)
                                && (disCarShipResultWork.CarMngNo == nextDisCarShipResultWork.CarMngNo))
                            {
                                k++;
                                detailPage = true;
                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                            }
                            else
                            {
                                k = 1;
                            }
                        }
                    }
 
                }
                // Table��Add
                carShipRsltDt.Rows.Add(dr);
            }
        }

        /// <summary>
        /// ���[�f�[�^����
        /// </summary>
        /// <param name="k">line Num</param>
        /// <param name="disCarShipResultWork">�擾�f�[�^</param>
        /// <param name="dr">DataRow</param>
        /// <param name="carShipRsltListCndtn">UI���o�����N���X</param>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private int DivPage(int k, CarShipResultWork disCarShipResultWork, ref DataRow dr, CarShipRsltListCndtn carShipRsltListCndtn)
        {
            newPage = false;
            int NUM = 32;
            if(lineFlg)
            {
                NUM = NUM - 1;
            }

            if (k / NUM == 1 && k % NUM == 1)
            {
                newPage = true;
                if(!diffPage)
                {
                    //BL���i�R�[�h
                    dr[PMSYA02005EA.ct_Col_BLGoodsCodeRF] = disCarShipResultWork.BLGoodsCode;

                    //BL���i�R�[�h���́i���p�j
                    dr[PMSYA02005EA.ct_Col_BLGoodsHalfNameRF] = disCarShipResultWork.BLGoodsHalfName;

                    //���i���̃J�i
                    dr[PMSYA02005EA.ct_Col_GoodsNameKanaRF] = disCarShipResultWork.GoodsNameKana;

                    //����`�[�ԍ�
                    dr[PMSYA02005EA.ct_Col_SalesSlipNumRF] = disCarShipResultWork.SalesSlipNum;

                    //������t
                    dr[PMSYA02005EA.ct_Col_SalesDateRF] = disCarShipResultWork.SalesDate;
                }
                if (detailPage)
                {
                    if (diffPage)
                    {
                        // ���ѕ\
                        if ((int)carShipRsltListCndtn.GroupBySectionDiv == 0)
                        {
                            if ((int)carShipRsltListCndtn.DetailDataValue != 2)
                            {
                                k = 3;
                            }
                            else
                            {
                                k = 2;
                            }
                            if (BLGroupPage && !carGroupPage)
                            {
                                k += 1;
                            }
                            // ���q�v���ł̏ꍇ
                            if (carPage)
                            {
                                k += 1;
                            }
                        }
                        else
                        {
                            k = 3;
                        }

                        
                    }
                    else
                    {
                        // ���ѕ\
                        if ((int)carShipRsltListCndtn.GroupBySectionDiv == 0)
                        {
                            if ((int)carShipRsltListCndtn.DetailDataValue != 2)
                            {
                                k = 3;
                            }
                            else
                            {
                                k = 2;
                            }
                        }
                        else
                        {
                            k = 2;
                        }
                    }
                    
                }
                else
                {
                    // ���ѕ\
                    if ((int)carShipRsltListCndtn.GroupBySectionDiv == 0)
                    {
                        if ((int)carShipRsltListCndtn.DetailDataValue != 2)
                        {
                            k = 2;
                        }
                        else
                        {
                            k = 1;
                        }
                    }
                    else
                    {
                        k = 1;
                    }
                }
                
            }

            diffPage = false;
            detailPage = false;
            BLGroupPage = false;
            carPage = false;
            carGroupPage = false;
            return k;
        }

        #region �� ���o�����o�͏��쐬
        /// <summary>
        /// ���o�����o�͏��쐬
        /// </summary>
        /// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        /// <param name="_carShipRsltListCndtn">���o����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions, CarShipRsltListCndtn _carShipRsltListCndtn)
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();
            // �����
            if (!DateTime.MinValue.Equals(_carShipRsltListCndtn.SalesDateSt))
            {
                if (!DateTime.MinValue.Equals(_carShipRsltListCndtn.SalesDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("������F{0} �` {1}",
                         _carShipRsltListCndtn.SalesDateSt.ToString("yyyy/MM/dd"),
                         _carShipRsltListCndtn.SalesDateEd.ToString("yyyy/MM/dd")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("������F{0} �` {1}",
                        _carShipRsltListCndtn.SalesDateSt.ToString("yyyy/MM/dd"),
                        ct_Extr_End));
                }
            }
            else
            {
                if (!DateTime.MinValue.Equals(_carShipRsltListCndtn.SalesDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("������F{0} �` {1}",
                         ct_Extr_Top,
                         _carShipRsltListCndtn.SalesDateEd.ToString("yyyy/MM/dd")));
                }
            }

            // ���͓�
            if (!DateTime.MinValue.Equals(_carShipRsltListCndtn.InputDateSt))
            {
                if (!DateTime.MinValue.Equals(_carShipRsltListCndtn.InputDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("���͓��F{0} �` {1}",
                         _carShipRsltListCndtn.InputDateSt.ToString("yyyy/MM/dd"),
                         _carShipRsltListCndtn.InputDateEd.ToString("yyyy/MM/dd")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("���͓��F{0} �` {1}",
                        _carShipRsltListCndtn.InputDateSt.ToString("yyyy/MM/dd"),
                        ct_Extr_End));
                }
            }
            else
            {
                if (!DateTime.MinValue.Equals(_carShipRsltListCndtn.InputDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("���͓��F{0} �` {1}",
                         ct_Extr_Top,
                         _carShipRsltListCndtn.InputDateEd.ToString("yyyy/MM/dd")));
                }
            }

            // �݌Ɏ��w��
            this.EditCondition(ref addConditions, string.Format("�݌Ɏ��w��F{0}",
                         _carShipRsltListCndtn.RsltTtlDivName));

            // ���Ӑ�
            if (_carShipRsltListCndtn.CustomerCodeSt != 0)
            {
                if (_carShipRsltListCndtn.CustomerCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("���Ӑ�F{0} �` {1}",
                         _carShipRsltListCndtn.CustomerCodeSt.ToString("00000000"), _carShipRsltListCndtn.CustomerCodeEd.ToString("00000000")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("���Ӑ�F{0} �` {1}",
                        _carShipRsltListCndtn.CustomerCodeSt.ToString("00000000"), ct_Extr_End));
                }
            }
            else
            {
                if (_carShipRsltListCndtn.CustomerCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("���Ӑ�F{0} �` {1}",
                         ct_Extr_Top, _carShipRsltListCndtn.CustomerCodeEd.ToString("00000000")));
                }
            }

            // �Ǘ��ԍ�
            if (!string.IsNullOrEmpty(_carShipRsltListCndtn.CarMngCodeSt))
            {
                if (!string.IsNullOrEmpty(_carShipRsltListCndtn.CarMngCodeEd))
                {
                    this.EditCondition(ref addConditions, string.Format("�Ǘ��ԍ��F{0} �` {1}",
                         _carShipRsltListCndtn.CarMngCodeSt, _carShipRsltListCndtn.CarMngCodeEd));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("�Ǘ��ԍ��F{0} �` {1}",
                        _carShipRsltListCndtn.CarMngCodeSt, ct_Extr_End));
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(_carShipRsltListCndtn.CarMngCodeEd))
                {
                    this.EditCondition(ref addConditions, string.Format("�Ǘ��ԍ��F{0} �` {1}",
                         ct_Extr_Top, _carShipRsltListCndtn.CarMngCodeEd));
                }
            }

            // ��ٰ�ߺ���
            if (_carShipRsltListCndtn.BLGroupCodeSt != 0)
            {
                if (_carShipRsltListCndtn.BLGroupCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("�O���[�v�R�[�h�F{0} �` {1}",
                         _carShipRsltListCndtn.BLGroupCodeSt.ToString("00000"), _carShipRsltListCndtn.BLGroupCodeEd.ToString("00000")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("�O���[�v�R�[�h�F{0} �` {1}",
                        _carShipRsltListCndtn.BLGroupCodeSt.ToString("00000"), ct_Extr_End));
                }
            }
            else
            {
                if (_carShipRsltListCndtn.BLGroupCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("�O���[�v�R�[�h�F{0} �` {1}",
                         ct_Extr_Top, _carShipRsltListCndtn.BLGroupCodeEd.ToString("00000")));
                }
            }

            // BL����
            if (_carShipRsltListCndtn.BLGoodsCodeSt != 0)
            {
                if (_carShipRsltListCndtn.BLGoodsCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("BL�R�[�h�F{0} �` {1}",
                         _carShipRsltListCndtn.BLGoodsCodeSt.ToString("00000"), _carShipRsltListCndtn.BLGoodsCodeEd.ToString("00000")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("BL�R�[�h�F{0} �` {1}",
                        _carShipRsltListCndtn.BLGoodsCodeSt.ToString("00000"), ct_Extr_End));
                }
            }
            else
            {
                if (_carShipRsltListCndtn.BLGoodsCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("BL�R�[�h�F{0} �` {1}",
                         ct_Extr_Top, _carShipRsltListCndtn.BLGoodsCodeEd.ToString("00000")));
                }
            }

            // �i��
            if (!string.IsNullOrEmpty(_carShipRsltListCndtn.GoodsNoSt))
            {
                if (!string.IsNullOrEmpty(_carShipRsltListCndtn.GoodsNoEd))
                {
                    this.EditCondition(ref addConditions, string.Format("�i�ԁF{0} �` {1}",
                         _carShipRsltListCndtn.GoodsNoSt, _carShipRsltListCndtn.GoodsNoEd));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("�i�ԁF{0} �` {1}",
                        _carShipRsltListCndtn.GoodsNoSt, ct_Extr_End));
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(_carShipRsltListCndtn.GoodsNoEd))
                {
                    this.EditCondition(ref addConditions, string.Format("�i�ԁF{0} �` {1}",
                         ct_Extr_Top, _carShipRsltListCndtn.GoodsNoEd));
                }
            }

            // ���q���l
            if (!string.IsNullOrEmpty(_carShipRsltListCndtn.SlipNoteCar))
            {
                // ���q���l,���q���l�����敪
                this.EditCondition(ref addConditions, string.Format("���q���l�F{0} {1}",
                         _carShipRsltListCndtn.SlipNoteCar, _carShipRsltListCndtn.CarOutDivName));

            }

            // �ǉ�
            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
        }
        #endregion

        #region �� ���o����������ҏW
        /// <summary>
        /// ���o����������ҏW
        /// </summary>
        /// <param name="editArea">�i�[�G���A</param>
        /// <param name="target">�Ώە�����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void EditCondition(ref StringCollection editArea, string target)
        {
            bool isEdit = false;

            // �ҏW�Ώە����o�C�g���Z�o
            int targetByte = TStrConv.SizeCountSJIS(target);

            for (int i = 0; i < editArea.Count; i++)
            {
                int areaByte = 0;

                // �i�[�G���A�̃o�C�g���Z�o
                if (editArea[i] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[i]);
                }

                if ((areaByte + targetByte + 2) <= 190)
                {
                    isEdit = true;

                    // �S�p�X�y�[�X��}��
                    if (editArea[i] != null) editArea[i] += ct_Space;

                    editArea[i] += target;
                    break;
                }
                else
                {
                    lineFlg = true;
                }
            }
            // �V�K�ҏW�G���A�쐬
            if (!isEdit)
            {
                editArea.Add(target);
            }
        }
        #endregion

        #endregion �� Private Method

    }
}
