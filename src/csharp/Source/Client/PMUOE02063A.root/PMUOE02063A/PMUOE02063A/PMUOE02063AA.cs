using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���ɗ\��\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ɗ\��\�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2008.12.03</br>
    /// <br>Note       : �n���f�B�^�[�~�i���񎟊J���̑Ή�</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2017/09/14</br>
    /// </remarks>
    public class EnterSchOrderAcs
    {
        #region �� Constructor
		/// <summary>
        /// ���ɗ\��\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���ɗ\��\�A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : 30413 ����</br>
	    /// <br>Date       : 2008.12.03</br>
		/// </remarks>
		public EnterSchOrderAcs()
		{
            this._iEnterSchOrderWorkDB = (IEnterSchOrderWorkDB)MediationEnterSchOrderWorkDB.GetEnterSchOrderWorkDB();
		}

		/// <summary>
        /// ���ɗ\��\�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���ɗ\��\�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.03</br>
        /// </remarks>
        static EnterSchOrderAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// ���[�o�͐ݒ�f�[�^�N���X
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X
			
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
        private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X
        #endregion �� Static Member

        #region �� Private Member
        IEnterSchOrderWorkDB _iEnterSchOrderWorkDB;         // ���ɗ\��\�����[�g

        private DataSet _enterSchDs;				        // ���ɗ\��\�f�[�^�Z�b�g

        // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        /// <summary>�d����BO�`�[�ԍ��ҏW�p-F</summary>
        private const string DuplicationSlipNoF = "-F";
        /// <summary>�d����BO�`�[�ԍ��ҏW�p-F2</summary>
        private const string DuplicationSlipNoF2 = "-F2";
        /// <summary>�d����BO�`�[�ԍ��ҏW�p-F3</summary>
        private const string DuplicationSlipNoF3 = "-F3";
        /// <summary>UOE���_�o�ɂ̐ݒ� �d���`�[�ԍ�(�o�[�R�[�h���p)</summary>
        private const string BangoNasiKyoTen = "BANGO-NASI-KYOTEN";
        /// <summary>BO1�o�ɂ̐ݒ� �d���`�[�ԍ�(�o�[�R�[�h���p)</summary>
        private const string BangoNasiBo1 = "BANGO-NASI-BO1";
        /// <summary>BO2�o�ɂ̐ݒ� �d���`�[�ԍ�(�o�[�R�[�h���p)</summary>
        private const string BangoNasiBo2 = "BANGO-NASI-BO2";
        /// <summary>BO3�o�ɂ̐ݒ� �d���`�[�ԍ�(�o�[�R�[�h���p)</summary>
        private const string BangoNasiBo3 = "BANGO-NASI-BO3";
        /// <summary>Ұ��̫۰���o�ɂ̐ݒ� �d���`�[�ԍ�(�o�[�R�[�h���p)</summary>
        private const string BangoNasiMaker = "BANGO-NASI-MAKER";
        /// <summary>EO�������o�ɂ̐ݒ� �d���`�[�ԍ�(�o�[�R�[�h���p)</summary>
        private const string BangoNasiEo = "BANGO-NASI-EO";

        /// <summary> �o�[�R�[�h�󎚋敪�uFalse:�󎚂��Ȃ� True:�󎚂���v</summary>
        private bool _barCodeShowDiv = false;
        // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

        
        #endregion �� Private Member

        #region �� Public Property
        /// <summary>
        /// ���ɗ\��\�f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet EnterSchDs
        {
            get { return this._enterSchDs; }
        }
        // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        /// <summary>
        /// �o�[�R�[�h�󎚋敪�uFalse:�󎚂��Ȃ� True:�󎚂���v
        /// </summary>
        public bool BarCodeShowDiv
        {
            get { return _barCodeShowDiv; }
            set { _barCodeShowDiv = value; }
        }
        // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
        #endregion �� Public Property

        #region �� Public Method
        #region �� �o�̓f�[�^�擾
        #region �� �����f�[�^�擾
        /// <summary>
        /// ���ɗ\��\�f�[�^�擾
        /// </summary>
        /// <param name="enterSchOrderCndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���������ɗ\��\�f�[�^���擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.03</br>
        /// <br>Note       : �n���f�B�^�[�~�i���񎟊J���̑Ή�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/09/14</br>
        /// </remarks>
        public int SearchEnterSchOrder(EnterSchOrderCndtn enterSchOrderCndtn, out string errMsg)
        {
            // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
            // �o�[�R�[�h�󎚂���ꍇ
            if (enterSchOrderCndtn.BarCodeShowDiv == 0)
            {
                this._barCodeShowDiv = true;
            }
            // �o�[�R�[�h�󎚂��Ȃ��ꍇ
            else
            {
                this._barCodeShowDiv = false;
            }
            // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

            return this.SearchEnterSchOrderProc(enterSchOrderCndtn, out errMsg);
        }
        #endregion
        #endregion �� �o�̓f�[�^�擾
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� ���ɗ\��\�f�[�^�擾
        /// <summary>
        /// ���ɗ\��\�f�[�^�擾
        /// </summary>
        /// <param name="enterSchOrderCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���������ɗ\��\�f�[�^���擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.03</br>
        /// </remarks>
        private int SearchEnterSchOrderProc(EnterSchOrderCndtn enterSchOrderCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                EnterSchResult.CreateDataTableResultEnterSch(ref this._enterSchDs);
                EnterSchOrderCndtnWork enterSchOrderCndtnWork = new EnterSchOrderCndtnWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevEnterSchOrder(enterSchOrderCndtn, out enterSchOrderCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                status = this._iEnterSchOrderWorkDB.Search(out retList, (object)enterSchOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevEnterSchOrderData(enterSchOrderCndtn, this._enterSchDs.Tables[EnterSchResult.Col_Tbl_Result_EnterSch], (ArrayList)retList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "���ɗ\��\�f�[�^�̎擾�Ɏ��s���܂����B";
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

        #region �� �f�[�^�W�J����
        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="enterSchOrderCndtn">UI���o�����N���X</param>
        /// <param name="enterSchOrderCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevEnterSchOrder(EnterSchOrderCndtn enterSchOrderCndtn, out EnterSchOrderCndtnWork enterSchOrderCndtnWork, out string errMsg)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            enterSchOrderCndtnWork = new EnterSchOrderCndtnWork();

            try
            {
                // ��ƃR�[�h
                enterSchOrderCndtnWork.EnterpriseCode = enterSchOrderCndtn.EnterpriseCode;

                // ���o�����p�����[�^�Z�b�g
                if (enterSchOrderCndtn.SectionCodes.Length != 0)
                {
                    if (enterSchOrderCndtn.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        enterSchOrderCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        enterSchOrderCndtnWork.SectionCodes = enterSchOrderCndtn.SectionCodes;
                    }
                }
                else
                {
                    enterSchOrderCndtnWork.SectionCodes = null;
                }


                enterSchOrderCndtnWork.St_UOESupplierCd = enterSchOrderCndtn.St_UOESupplierCd;          // �J�nUOE������R�[�h
                enterSchOrderCndtnWork.Ed_UOESupplierCd = enterSchOrderCndtn.Ed_UOESupplierCd;          // �I��UOE������R�[�h
                enterSchOrderCndtnWork.UOESupplierCds = enterSchOrderCndtn.UOESupplierCds;              // �d����w��

                enterSchOrderCndtnWork.St_ReceiveDate = enterSchOrderCndtn.St_ReceiveDate;	            // �J�n��M���t
                enterSchOrderCndtnWork.Ed_ReceiveDate = enterSchOrderCndtn.Ed_ReceiveDate;	            // �I����M���t

                enterSchOrderCndtnWork.PrintTypeCndtn = enterSchOrderCndtn.PrintTypeCndtn;              // ����^�C�v
                
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region �� ���ɗ\��\�f�[�^�W�J����
        /// <summary>
        /// ���ɗ\��\�f�[�^�W�J����
        /// </summary>
        /// <param name="enterSchOrderCndtn">UI���o�����N���X</param>
        /// <param name="enterSchOrderDt">�W�J�Ώ�DataTable</param>
        /// <param name="enterSchResultWorkList">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���ɗ\��\�f�[�^��W�J����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.03</br>
        /// </remarks>
        private void DevEnterSchOrderData(EnterSchOrderCndtn enterSchOrderCndtn, DataTable enterSchOrderDt, ArrayList enterSchResultWorkList)
        {
            foreach (EnterSchResultWork enterSchResultWork in enterSchResultWorkList)
            {
                if (enterSchOrderCndtn.PrintTypeCndtn == 0)
                {
                    // ���ɕ��̂�
                    if (enterSchResultWork.UOESectOutGoodsCnt != 0)
                    {
                        DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 0);
                    }
                    if (enterSchResultWork.BOShipmentCnt1 != 0)
                    {
                        DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 1);
                    }
                    if (enterSchResultWork.BOShipmentCnt2 != 0)
                    {
                        DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 2);
                    }
                    if (enterSchResultWork.BOShipmentCnt3 != 0)
                    {
                        DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 3);
                    }
                    if (enterSchResultWork.MakerFollowCnt != 0)
                    {
                        DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 4);
                    }
                    if (enterSchResultWork.EOAlwcCount != 0)
                    {
                        DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 5);
                    }
                }
                else if (enterSchOrderCndtn.PrintTypeCndtn == 1)
                {
                    // Ұ��̫۰���̂�
                    DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 4);
                }
                else
                {
                    // ���i���̂�
                    DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 6);
                }

            }
        }
        #endregion


        /// <summary>
        /// �擾�f�[�^�ݒ菈��
        /// </summary>
        /// <param name="enterSchOrderDt">�W�J�Ώ�DataTable</param>
        /// <param name="enterSchResultWork">�擾�f�[�^</param>
        /// <param name="addFlg">�f�[�^�ݒ�t���O</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��ݒ肷��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.03</br>
        /// <br>UpdateNote : �n���f�B�^�[�~�i���񎟊J���̑Ή�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date	   : 2017/09/14</br>
        /// </remarks>
        private void DataSetEnterSchOrder(DataTable enterSchOrderDt, EnterSchResultWork enterSchResultWork, int addFlg)
        {
            // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
            string boSlipNo1 = string.Empty;
            string boSlipNo2 = string.Empty;
            string boSlipNo3 = string.Empty;

            // �o�[�R�[�h�󎚂���ꍇ
            if (this._barCodeShowDiv)
            {
                this.UpdBOSlipNo(enterSchResultWork, out boSlipNo1, out boSlipNo2, out boSlipNo3);
            }
            // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

            DataRow dr;

            dr = enterSchOrderDt.NewRow();

            // ���ɗ\��\�f�[�^�W�J
            #region ���ɗ\��\�f�[�^�W�J
            // ���_�R�[�h
            dr[EnterSchResult.Col_SectionCode] = enterSchResultWork.SectionCode;
            // ���_�K�C�h����
            dr[EnterSchResult.Col_SectionGuideSnm] = enterSchResultWork.SectionGuideSnm;
            // �q�ɃR�[�h
            dr[EnterSchResult.Col_WarehouseCode] = enterSchResultWork.WarehouseCode;
            // �q�ɖ���
            dr[EnterSchResult.Col_WarehouseName] = enterSchResultWork.WarehouseName;
            // �q�ɒI��
            dr[EnterSchResult.Col_WarehouseShelfNo] = enterSchResultWork.WarehouseShelfNo;
            // ���i�ԍ�
            dr[EnterSchResult.Col_GoodsNo] = enterSchResultWork.GoodsNo;
            // ���i���[�J�[�R�[�h
            dr[EnterSchResult.Col_GoodsMakerCd] = enterSchResultWork.GoodsMakerCd;
            // ���i����
            dr[EnterSchResult.Col_GoodsName] = enterSchResultWork.GoodsName;
            // �󒍐���
            dr[EnterSchResult.Col_AcceptAnOrderCnt] = enterSchResultWork.AcceptAnOrderCnt;
            // UOE���_�o�ɐ�
            dr[EnterSchResult.Col_UOESectOutGoodsCnt] = enterSchResultWork.UOESectOutGoodsCnt;
            // BO�o�ɐ�1
            dr[EnterSchResult.Col_BOShipmentCnt1] = enterSchResultWork.BOShipmentCnt1;
            // BO�o�ɐ�2
            dr[EnterSchResult.Col_BOShipmentCnt2] = enterSchResultWork.BOShipmentCnt2;
            // BO�o�ɐ�3
            dr[EnterSchResult.Col_BOShipmentCnt3] = enterSchResultWork.BOShipmentCnt3;
            // ���[�J�[�t�H���[��
            dr[EnterSchResult.Col_MakerFollowCnt] = enterSchResultWork.MakerFollowCnt;
            // EO������
            dr[EnterSchResult.Col_EOAlwcCount] = enterSchResultWork.EOAlwcCount;
            // �񓚒艿
            dr[EnterSchResult.Col_AnswerListPrice] = enterSchResultWork.AnswerListPrice;
            // �񓚌����P��
            dr[EnterSchResult.Col_AnswerSalesUnitCost] = enterSchResultWork.AnswerSalesUnitCost;
            // �d����R�[�h
            dr[EnterSchResult.Col_SupplierCd] = enterSchResultWork.SupplierCd;
            // BO�`�[�ԍ��P
            dr[EnterSchResult.Col_BOSlipNo1] = enterSchResultWork.BOSlipNo1;
            // BO�`�[�ԍ��Q
            dr[EnterSchResult.Col_BOSlipNo2] = enterSchResultWork.BOSlipNo2;
            // BO�`�[�ԍ��R
            dr[EnterSchResult.Col_BOSlipNo3] = enterSchResultWork.BOSlipNo3;
            // UOE���_�`�[�ԍ�
            dr[EnterSchResult.Col_UOESectionSlipNo] = enterSchResultWork.UOESectionSlipNo;
            // �t�n�d���}�[�N�P
            dr[EnterSchResult.Col_UoeRemark1] = enterSchResultWork.UoeRemark1;
            // �t�n�d���}�[�N�Q
            dr[EnterSchResult.Col_UoeRemark2] = enterSchResultWork.UoeRemark2;
            // ��M���t
            dr[EnterSchResult.Col_ReceiveDate] = TDateTime.DateTimeToString("YYYY/MM/DD", enterSchResultWork.ReceiveDate);

            if (addFlg == 0)
            {
                // UOE���_�o�ɐ�
                // ���ɐ�(����p)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = enterSchResultWork.UOESectOutGoodsCnt;
                // BO��(����p)
                dr[EnterSchResult.Col_BOCnt_Print] = 0;
                // �d���`�[�ԍ�(����p)
                dr[EnterSchResult.Col_SlipNo_Print] = enterSchResultWork.UOESectionSlipNo;

                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                // �o�[�R�[�h�󎚂���ꍇ
                if (this._barCodeShowDiv)
                {
                    if (!string.IsNullOrEmpty(enterSchResultWork.UOESectionSlipNo))
                    {
                        // �d��SEQ�ԍ�(�o�[�R�[�h���p)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = enterSchResultWork.UOESectionSlipNo;
                    }
                    else
                    {
                        // �d��SEQ�ԍ�(�o�[�R�[�h���p)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = BangoNasiKyoTen;
                    }
                }
                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
            }
            else if (addFlg == 1)
            {
                // BO�o�ɐ�1
                // ���ɐ�(����p)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = 0;
                // BO��(����p)
                dr[EnterSchResult.Col_BOCnt_Print] = enterSchResultWork.BOShipmentCnt1;
                // �d���`�[�ԍ�(����p)
                dr[EnterSchResult.Col_SlipNo_Print] = enterSchResultWork.BOSlipNo1;

                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                // �o�[�R�[�h�󎚂���ꍇ
                if (this._barCodeShowDiv)
                {
                    if (!string.IsNullOrEmpty(boSlipNo1))
                    {
                        // �d��SEQ�ԍ�(�o�[�R�[�h���p)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = boSlipNo1;
                    }
                    else
                    {
                        // �d��SEQ�ԍ�(�o�[�R�[�h���p)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = BangoNasiBo1;
                    }
                }
                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
            }
            else if (addFlg == 2)
            {
                // BO�o�ɐ�2
                // ���ɐ�(����p)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = 0;
                // BO��(����p)
                dr[EnterSchResult.Col_BOCnt_Print] = enterSchResultWork.BOShipmentCnt2;
                // �d���`�[�ԍ�(����p)
                dr[EnterSchResult.Col_SlipNo_Print] = enterSchResultWork.BOSlipNo2;

                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                // �o�[�R�[�h�󎚂���ꍇ
                if (this._barCodeShowDiv)
                {
                    if (!string.IsNullOrEmpty(boSlipNo2))
                    {
                        // �d��SEQ�ԍ�(�o�[�R�[�h���p)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = boSlipNo2;
                    }
                    else
                    {
                        // �d��SEQ�ԍ�(�o�[�R�[�h���p)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = BangoNasiBo2;
                    }
                }
                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
            }
            else if (addFlg == 3)
            {
                // BO�o�ɐ�3
                // ���ɐ�(����p)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = 0;
                // BO��(����p)
                dr[EnterSchResult.Col_BOCnt_Print] = enterSchResultWork.BOShipmentCnt3;
                // �d���`�[�ԍ�(����p)
                dr[EnterSchResult.Col_SlipNo_Print] = enterSchResultWork.BOSlipNo3;

                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                // �o�[�R�[�h�󎚂���ꍇ
                if (this._barCodeShowDiv)
                {
                    if (!string.IsNullOrEmpty(boSlipNo3))
                    {
                        // �d��SEQ�ԍ�(�o�[�R�[�h���p)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = boSlipNo3;
                    }
                    else
                    {
                        // �d��SEQ�ԍ�(�o�[�R�[�h���p)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = BangoNasiBo3;
                    }
                }
                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
            }
            else if (addFlg == 4)
            {
                // Ұ��̫۰��
                // ���ɐ�(����p)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = 0;
                // BO��(����p)
                dr[EnterSchResult.Col_BOCnt_Print] = enterSchResultWork.MakerFollowCnt;
                // �d���`�[�ԍ�(����p)
                dr[EnterSchResult.Col_SlipNo_Print] = "";

                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                // �o�[�R�[�h�󎚂���ꍇ
                if (this._barCodeShowDiv)
                {
                    // �d��SEQ�ԍ�(�o�[�R�[�h���p)
                    dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = BangoNasiMaker;
                }
                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
            }
            else if (addFlg == 5)
            {
                // EO������
                // ���ɐ�(����p)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = 0;
                // BO��(����p)
                dr[EnterSchResult.Col_BOCnt_Print] = enterSchResultWork.EOAlwcCount;
                // �d���`�[�ԍ�(����p)
                dr[EnterSchResult.Col_SlipNo_Print] = "";

                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                // �o�[�R�[�h�󎚂���ꍇ
                if (this._barCodeShowDiv)
                {
                    // �d��SEQ�ԍ�(�o�[�R�[�h���p)
                    dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = BangoNasiEo;
                }
                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
            }
            else
            {
                // ���i���̂�
                // ���ɐ�(����p)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = 0;
                // BO��(����p)
                dr[EnterSchResult.Col_BOCnt_Print] = 0;
                // �d���`�[�ԍ�(����p)
                dr[EnterSchResult.Col_SlipNo_Print] = "";

                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                // �o�[�R�[�h�󎚂���ꍇ
                if (this._barCodeShowDiv)
                {
                    // �d��SEQ�ԍ�(�o�[�R�[�h���p)
                    dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = string.Empty;
                }
                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
            }

            // Table��Add
            enterSchOrderDt.Rows.Add(dr);
        }

        // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        /// <summary>
        /// �d����BO�`�[�ԍ��ҏW����
        /// </summary>
        /// <param name="handyUOEOrderListWork">UOE�����f�[�^</param>
        /// <param name="boSlipNo1">BO1�`�[�ԍ�</param>
        /// <param name="boSlipNo2">BO2�`�[�ԍ�</param>
        /// <param name="boSlipNo3">BO3�`�[�ԍ�</param>
        /// <remarks>
        /// <br>Note       : �d����BO�`�[�ԍ��ɂ���āA�ʐMID��āA�u-F�v�̕ҏW�������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/09/14</br>
        /// </remarks>
        private void UpdBOSlipNo(EnterSchResultWork enterSchResultWork, out string boSlipNo1, out string boSlipNo2, out string boSlipNo3)
        {
            // UOE�`�[�ԍ�
            string tempUOESectionSlipNo = enterSchResultWork.UOESectionSlipNo;
            // BO1�`�[�ԍ�
            string tempBOSlipNo1 = enterSchResultWork.BOSlipNo1;
            boSlipNo1 = enterSchResultWork.BOSlipNo1;
            // BO2�`�[�ԍ�
            string tempBOSlipNo2 = enterSchResultWork.BOSlipNo2;
            boSlipNo2 = enterSchResultWork.BOSlipNo2;
            // BO3�`�[�ԍ�
            string tempBOSlipNo3 = enterSchResultWork.BOSlipNo3;
            boSlipNo3 = enterSchResultWork.BOSlipNo3;

            switch (enterSchResultWork.CommAssemblyId.Trim())
            {
                // �z���_ e-Parts�u�ʐMID�F0502�v�̏ꍇ
                case EnumUoeConst.ctCommAssemblyId_0502:
                    {
                        // BO1�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo1) && !string.IsNullOrEmpty(tempBOSlipNo1.Trim()))
                        {
                            boSlipNo1 = tempBOSlipNo1 + DuplicationSlipNoF;
                        }

                        // BO2�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo2) && !string.IsNullOrEmpty(tempBOSlipNo2.Trim()))
                        {
                            if (tempBOSlipNo2.Equals(tempUOESectionSlipNo))
                            {
                                boSlipNo2 = tempBOSlipNo2 + DuplicationSlipNoF2;
                            }
                        }

                        // BO3�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo3) && !string.IsNullOrEmpty(tempBOSlipNo3.Trim()))
                        {
                            if (tempBOSlipNo3.Equals(tempUOESectionSlipNo) || tempBOSlipNo3.Equals(tempBOSlipNo2))
                            {
                                boSlipNo3 = tempBOSlipNo3 + DuplicationSlipNoF3;
                            }
                        }

                        break;
                    }
                // �z���_ e-Parts�u�ʐMID�F0502�v�ȊO�̏ꍇ
                default:
                    {
                        // BO1�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo1) && !string.IsNullOrEmpty(tempBOSlipNo1.Trim()))
                        {
                            if (tempBOSlipNo1.Equals(tempUOESectionSlipNo))
                            {
                                boSlipNo1 = tempBOSlipNo1 + DuplicationSlipNoF;
                            }
                        }

                        // BO2�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo2) && !string.IsNullOrEmpty(tempBOSlipNo2.Trim()))
                        {
                            if (tempBOSlipNo2.Equals(tempUOESectionSlipNo) ||
                                tempBOSlipNo2.Equals(tempBOSlipNo1))
                            {
                                boSlipNo2 = tempBOSlipNo2 + DuplicationSlipNoF2;
                            }
                        }

                        // BO3�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo3) && !string.IsNullOrEmpty(tempBOSlipNo3.Trim()))
                        {
                            if (tempBOSlipNo3.Equals(tempUOESectionSlipNo) ||
                                tempBOSlipNo3.Equals(tempBOSlipNo1) ||
                                tempBOSlipNo3.Equals(tempBOSlipNo2))
                            {
                                boSlipNo3 = tempBOSlipNo3 + DuplicationSlipNoF3;
                            }
                        }

                        break;
                    }
            }
        }
        // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

        #endregion �� �f�[�^�W�J����
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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.03</br>
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
        #endregion �� Private Method
    }
}
