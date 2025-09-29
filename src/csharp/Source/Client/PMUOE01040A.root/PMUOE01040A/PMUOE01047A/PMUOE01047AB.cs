//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �񓚃f�[�^�A�N�Z�X�N���X
// �v���O�����T�v   : �z���_ UOE WEB��p �񓚃f�[�^�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2009/05/25  �C�����e : 96186 ���� �T�� �z���_ UOE WEB�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  XXXXXXXX-00 �쐬�S�� : ���� ���n
// �� �� ��  2011/10/13  �C�����e : UOE�����f�[�^�̏o�׌����ڂŌ���ꂪ��������s��̏C��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �񓚃f�[�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �z���_ UOE WEB��p �񓚃f�[�^�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
    /// <br>Date       : 2009/05/25</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009/05/25 men �V�K�쐬</br>
    /// <br>Update Note  : 2009/05/25 96186 ���� �T��</br>
    /// <br>              �E�z���_ UOE WEB�Ή�</br>
    /// </remarks>
	public partial class UOEAnswerAcs
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		# endregion

		// ===================================================================================== //
		// �萔�Q
		// ===================================================================================== //
		#region Public Const Member
		# endregion

		// ===================================================================================== //
		// �f���Q�[�g
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
        # region �z���_ UOE WEB��p �񓚃f�[�^�X�V����
        /// <summary>
        /// �z���_ UOE WEB��p �񓚃f�[�^�X�V����
		/// </summary>
        /// <param name="uOESupplier">UOE������N���X</param>
        /// <param name="lstDtl">�����ꗗ���ׁiPM�A���j�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>0:���� 0�ȊO:�G���[</returns>
        public int UpDtAnswerEParts(UOESupplier uOESupplier, ArrayList lstDtl, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
			try
			{
                //-----------------------------------------------------------
                // �p�����[�^����������
                //-----------------------------------------------------------
                # region �p�����[�^����������
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                List<StockSlipGrp> stockSlipGrpList = new List<StockSlipGrp>();
                # endregion

                //-----------------------------------------------------------
                // �񓚃f�[�^�̎擾
                //-----------------------------------------------------------
                # region �񓚃f�[�^�̎擾
                status = UpDtAnswerEParts(uOESupplier, lstDtl, ref stockSlipGrpList, ref uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // �񓚃f�[�^�X�V����
                //-----------------------------------------------------------
                # region �񓚃f�[�^�X�V����
                status = _uOEOrderDtlAcs.Write(ref stockSlipGrpList, ref uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // �X�V���ʁ�Datatable
                //-----------------------------------------------------------
                # region �X�V���ʁ�Datatable
                if((stockSlipGrpList == null) || (uOEOrderDtlWorkList == null))
                {
                    return (status);
                }
                if ((stockSlipGrpList.Count == 0) && (uOEOrderDtlWorkList.Count == 0))
                {
                    return (status);
                }

                //�t�n�d�����f�[�^���t�n�d�����f�[�^�e�[�u���̍X�V 
                status = _uoeSndRcvJnlAcs.UpdateTableFromUOEOrderDtlList(uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }

                foreach (StockSlipGrp grp in stockSlipGrpList)
                {
                    //�d�����ׁ��d�����׃e�[�u���̍X�V
                    status = _uoeSndRcvJnlAcs.UpdateTableFromStockDetailList(StockDetailTable, grp.stockDetailWorkList, out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }

                    //�d���f�[�^���d���f�[�^�e�[�u���̍X�V
                    if (grp.stockSlipWork != null)
                    {
                        //�d�����ׂ�苤�ʓ`�[�ԍ����擾
                        StockDetailWork work = null;
                        string commonSlipNo = "";

                        status = _uoeSndRcvJnlAcs.ReadStockDetailWork(
                                        StockDetailTable,
                                        grp.stockDetailWorkList[0].SupplierFormal,
                                        grp.stockDetailWorkList[0].DtlRelationGuid,
                                        out work,
                                        out commonSlipNo,
                                        out message);
                        if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            return (status);
                        }

                        status = _uoeSndRcvJnlAcs.UpdateTableFromStockSlipWork(StockSlipTable, grp.stockSlipWork, commonSlipNo, out message);
                        if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            return (status);
                        }
                    }
                }
                # endregion
            }
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region �z���_ UOE WEB��p �񓚃f�[�^�̎擾
        /// <summary>
        /// �z���_ UOE WEB��p �񓚃f�[�^�̎擾
        /// </summary>
        /// <param name="uOESupplier">������I�u�W�F�N�g</param>
        /// <param name="lstDtl">�����ꗗ���ׁiPM�A���j�N���X</param>
        /// <param name="stockSlipGrpList">�d�����I�u�W�F�N�g</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int UpDtAnswerEParts(UOESupplier uOESupplier, ArrayList lstDtl, ref List<StockSlipGrp> stockSlipGrpList, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList, out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";
            try
            {
                //-----------------------------------------------------------
                // ����M�i�m�k�iDataTable�j�̐ݒ�
                //-----------------------------------------------------------
                # region ����M�i�m�k�iDataTable�j�̐ݒ�
                foreach (OrderLstPmDtl dtl in lstDtl)
                {
                    # region ����M�i�m�k�iDataTable�j�̃t�B���^����
                    // ����M�i�m�k�iDataTable�j�̃t�B���^����
                    DataView view = GetOrderFormCreateView(
                        uOESupplier.UOESupplierCd,
                        dtl.LinkNo,
                        dtl.OrderGoodsNo);

                    if (view.Count == 0) continue;
                    # endregion

                    # region �o�׋��_�̎Z�o
                    // �o�׋��_�̎Z�o
                    string sourceShipment = String.Empty;
                    // -- UPD 2011/10/13 ------------------->>>
                    //if ((dtl.SourceShipment.IndexOf("�鎭") != -1) || (dtl.SourceShipment.IndexOf("���R") != -1))
                    //{
                    //    sourceShipment = dtl.SourceShipment;
                    //}
                    
                    if (dtl.SourceShipment.IndexOf("�鎭") != -1)
                    {
                        sourceShipment = "�鎭";
                    }
                    if (dtl.SourceShipment.IndexOf("���R") != -1)
                    {
                        sourceShipment = "���R";
                    }
                    // -- UPD 2011/10/13 -------------------<<<
                    # endregion

                    # region ����M�i�m�k���ڂ̐ݒ�
                    // ����M�i�m�k���ڂ̐ݒ�
                    foreach (DataRowView dr in view)
                    {
                        # region ��֕i�ԁE�񓚃��[�J�[�R�[�h�̎Z�o
                        // ��֕i�ԁE�񓚃��[�J�[�R�[�h�̎Z�o
                        Int32 answerMakerCd = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_GoodsMakerCd];	//���������[�J�[�R�[�h
                        string substPartsNo = dtl.ShipmGoodsNo.Replace("-", "");

                        //��ւ���
                        if((dtl.OrderGoodsNo != substPartsNo)
                        && (dtl.ShipmGoodsNo.Trim() != String.Empty))
                        {
                            // ��֕i�ԁE���[�J�[�R�[�h�̎Z�o
                            List<GoodsUnitData> list = null;
                            int st = _uoeSndRcvCtlInitAcs.SearchPartsFromGoodsNoForMstInf(substPartsNo, uOESupplier, out list);
                            //�I���Ȃ�
                            //�Y���i�ԂȂ�
                            if ((st == -1) || (st == 1) || (list == null))
                            {
                                substPartsNo = dtl.ShipmGoodsNo;                                        //�i��
                                answerMakerCd = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_GoodsMakerCd];    //���[�J�[�R�[�h
                            }
                            //�Y���i�Ԃ���
                            else if (list.Count > 0)
                            {
                                substPartsNo = list[0].GoodsNo;			//�i��
                                answerMakerCd = list[0].GoodsMakerCd;	//���[�J�[�R�[�h
                            }
                        }
                        //��ւȂ�
                        else
                        {
                            substPartsNo = String.Empty;
                        }

                        # endregion

                        # region �o�׌��̐ݒ�
                        // �o�׌��̐ݒ�
                        if(sourceShipment != String.Empty)
                        {
                            dr[OrderSndRcvJnlSchema.ct_Col_SourceShipment] = sourceShipment;
                        }
                        # endregion

                        # region �����`�[�ԍ��E�������̐ݒ�
                        // �����`�[�ԍ��E�������̐ݒ�
                        //�������ʁE�o�וi�Ԃ̃`�F�b�N
                        if((dtl.ShipmentCnt > 0)
                        && (dtl.ShipmGoodsNo.Trim() != String.Empty))
                        {
                            //���_�o��
                            if(sourceShipment == String.Empty)
                            {
                                //���ɐݒ�ς̏ꍇ�́A�ݒ肵�Ȃ�
                                Int32 cnt = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt];
                                string slipNo = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo];
                                if ((cnt != 0) || (slipNo.Trim() != String.Empty)) continue;

                                //�`�[�ԍ��E���ʂ̐ݒ�
                                dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = (Int32)dtl.ShipmentCnt;	// UOE���_�o�ɐ�
                                dr[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = dtl.SlipNoDtl.ToString();	    // UOE���_�`�[�ԍ�
                            }
                            //�a�n�o��
                            else
                            {
                                //���ɐݒ�ς̏ꍇ�́A�ݒ肵�Ȃ�
                                Int32 cnt = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1];
                                string slipNo = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1];
                                if ((cnt != 0) || (slipNo.Trim() != String.Empty)) continue;

                                //�`�[�ԍ��E���ʂ̐ݒ�
                                dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] = (Int32)dtl.ShipmentCnt;// BO�o�ɐ�1
                                dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = dtl.SlipNoDtl.ToString();	    // BO�`�[�ԍ��P
                            }
                        }
                        # endregion

                        # region ���ɍX�V�t���O(1:���ɍ�)�̐ݒ�
                        //��������
                        int enterUpdDivSec = 0;		//���_
                        int enterUpdDivBO1 = 0;		//BO1
                        int enterUpdDivBO2 = 0;		//BO2
                        int enterUpdDivBO3 = 0;		//BO3
                        int enterUpdDivMaker = 0;	//Ұ��
                        int enterUpdDivEO = 0;		//EO

                        //�V�X�e���敪
                        Int32 systemDivCd = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_SystemDivCd];

                        //���ɍX�V�t���O(1:���ɍ�)�̐ݒ�
                        int warehouseCode = 0;
                        UoeCommonFnc.ToInt32FromString((string)dr[OrderSndRcvJnlSchema.ct_Col_WarehouseCode], out warehouseCode);

                        //�V�X�e���敪���`��������
                        //�V�X�e���敪���i����́A���������j�̎��i
                        if ( (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                        || (((systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)
                        || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search))
                            && (warehouseCode == 0)))
                        {
                            enterUpdDivSec = 1;		//���_
                            enterUpdDivBO1 = 1;		//BO1
                            enterUpdDivBO2 = 1;		//BO2
                            enterUpdDivBO3 = 1;		//BO3
                            enterUpdDivMaker = 1;	//Ұ��
                            enterUpdDivEO = 1;		//EO
                        }
                        //�V�X�e���敪���i����́A���������̍݌ɕi�j
                        //�V�X�e���敪���݌Ɉꊇ
                        else if ((((systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search)
                                || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)) && (warehouseCode != 0))
                                || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Lump))
                        {
                            //���_
                            if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] == 0) enterUpdDivSec = 1;
                            //BO1
                            if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] == 0) enterUpdDivBO1 = 1;
                            //BO2
                            if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] == 0) enterUpdDivBO2 = 1;
                            //BO3
                            if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3] == 0) enterUpdDivBO3 = 1;
                            //Ұ��
                            if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] == 0) enterUpdDivMaker = 1;
                            //EO
                            if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount] == 0) enterUpdDivEO = 1;
                        }

                        //���ɍX�V�敪
                        dr[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivSec] = enterUpdDivSec;	    // ���_
                        dr[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivBO1] = enterUpdDivBO1;	    // BO1
                        dr[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivBO2] = enterUpdDivBO2;	    // BO2
                        dr[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivBO3] = enterUpdDivBO3;	    // BO3
                        dr[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivMaker] = enterUpdDivMaker;	// Ұ��
                        dr[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivEO] = enterUpdDivEO;	        // EO
                        # endregion

                        # region ��֕i�ԁE�񓚃��[�J�[�R�[�h�̐ݒ�
                        // ��֕i�ԁEUOE��փ}�[�N�E�񓚃��[�J�[�R�[�h�̐ݒ�

                        //���[�J�[�R�[�h
                        dr[OrderSndRcvJnlSchema.ct_Col_AnswerMakerCd] = answerMakerCd;

                        // ��֕i�ԁEUOE��փ}�[�N
                        if (substPartsNo != String.Empty)
                        {
                            dr[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = substPartsNo;
                            dr[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = "D";
                        }
                        # endregion

                        # region UOE�񓚃f�[�^��
                        //UOE�񓚃f�[�^��
                        dr[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = dtl.OrderDate;	                // ��M���t
                        dr[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = dtl.OrderTime;	                // ��M����
                        dr[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = dtl.ShipmGoodsNo;	            // �񓚕i��
                        dr[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = dtl.GoodsName;	            // �񓚕i��
                        dr[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = dtl.AnswerListPrice;	        // �񓚒艿
                        dr[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = dtl.AnswerSalesUnitCost;	// �񓚌����P��
                        # endregion

                        # region �f�[�^�敪
                        // �f�[�^�敪
                        dr[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = (int)EnumUoeConst.ctDataSendCode.ct_OK;	        // �f�[�^���M�敪
                        dr[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;	    // �f�[�^�����敪
                        # endregion

                        # region �w�b�h�G���[���b�Z�[�W�̐ݒ�
                        // �w�b�h�G���[���b�Z�[�W�̐ݒ�
                        if (dtl.Msg.IndexOf("��������") == -1)
                        {
                            dr[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = dtl.Msg;
                        }
                        # endregion

                        break;
                    }
                    # endregion
                }
                # endregion

                //-----------------------------------------------------------
                // �d�����ׁiDataTable�j�̐ݒ�
                //-----------------------------------------------------------
                # region �d������DataTable�̐ݒ�
                # region �ϐ��̏���������
                // �ϐ��̏���������
                Dictionary<Int32, Int32> uOESalesOrderNoDictionary = new Dictionary<Int32, Int32>();
                # endregion

                # region ����M�i�m�k�iDataTable�j�̃t�B���^����
                // ����M�i�m�k�iDataTable�j�̃t�B���^����
                DataView viewJnl = GetOrderFormCreateView(
                    0,
                    uOESupplier.UOESupplierCd,
                    (int)EnumUoeConst.ctDataSendCode.ct_OK,
                    (int)EnumUoeConst.ctDataRecoverDiv.ct_NO);
                # endregion

                foreach (DataRowView dr in viewJnl)
                {
                    //-----------------------------------------------------------
                    // �t�n�d�����iDataTable�j�̐ݒ�
                    //-----------------------------------------------------------
                    # region �t�n�d�����iDataTable�j�̐ݒ�
                    # region �t�n�d�����iDataTable�j��FIND����
                    // ����M�i�m�k��FIND����
                    object[] findUOEOrderDtl = new object[3];
                    findUOEOrderDtl[0] = uOESupplier.UOESupplierCd;
                    findUOEOrderDtl[1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];
                    findUOEOrderDtl[2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo];
                    DataRow uOEOrderDtlRow = UOEOrderDtlTable.Rows.Find(findUOEOrderDtl);
                    if (uOEOrderDtlRow == null) continue;
                    # endregion

                    # region �t�n�d����DataTable�ݒ菈��
                    //UOE�񓚃f�[�^��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_ReceiveDate] = (DateTime)dr[OrderSndRcvJnlSchema.ct_Col_ReceiveDate];	// ��M���t
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_ReceiveTime] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_ReceiveTime];	// ��M����
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerMakerCd] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_AnswerMakerCd];	// �񓚃��[�J�[�R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerPartsNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo];	// �񓚕i��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerPartsName] = (string)dr[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName];	// �񓚕i��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_SubstPartsNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo];	// ��֕i��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt];	// UOE���_�o�ɐ�
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1];	// BO�o�ɐ�1
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2];	// BO�o�ɐ�2
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3];	// BO�o�ɐ�3
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MakerFollowCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt];	// ���[�J�[�t�H���[��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_NonShipmentCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_NonShipmentCnt];	// ���o�ɐ�
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectStockCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectStockCnt];	// UOE���_�݌ɐ�
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOStockCount1];	// BO�݌ɐ�1
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOStockCount2];	// BO�݌ɐ�2
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount3] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOStockCount3];	// BO�݌ɐ�3
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectionSlipNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo];	// UOE���_�`�[�ԍ�
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo1] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1];	// BO�`�[�ԍ��P
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo2] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2];	// BO�`�[�ԍ��Q
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo3] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo3];	// BO�`�[�ԍ��R
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EOAlwcCount] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount];	// EO������
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOManagementNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOManagementNo];	// BO�Ǘ��ԍ�
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerListPrice] = (Double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice];	// �񓚒艿
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost] = (Double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost];	// �񓚌����P��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESubstMark] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOESubstMark];	// UOE��փ}�[�N
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEStockMark] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEStockMark];	// UOE�݌Ƀ}�[�N
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_PartsLayerCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_PartsLayerCd];	// �w�ʃR�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd1] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd1];	// UOE�o�׋��_�R�[�h�P�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd2] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd2];	// UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd3] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd3];	// UOE�o�׋��_�R�[�h�R�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd1] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd1];	// UOE���_�R�[�h�P�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd2] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd2];	// UOE���_�R�[�h�Q�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd3] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd3];	// UOE���_�R�[�h�R�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd4] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd4];	// UOE���_�R�[�h�S�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd5] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd5];	// UOE���_�R�[�h�T�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd6] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd6];	// UOE���_�R�[�h�U�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd7] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd7];	// UOE���_�R�[�h�V�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt1];	// UOE�݌ɐ��P�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt2];	// UOE�݌ɐ��Q�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt3] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt3];	// UOE�݌ɐ��R�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt4] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt4];	// UOE�݌ɐ��S�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt5] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt5];	// UOE�݌ɐ��T�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt6] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt6];	// UOE�݌ɐ��U�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt7] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt7];	// UOE�݌ɐ��V�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEDistributionCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEDistributionCd];	// UOE���R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEOtherCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEOtherCd];	// UOE���R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEHMCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEHMCd];	// UOE�g�l�R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOCount] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOCount];	// �a�n��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEMarkCode] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode];	// UOE�}�[�N�R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_SourceShipment] = (string)dr[OrderSndRcvJnlSchema.ct_Col_SourceShipment];	// �o�׌�
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_ItemCode] = (string)dr[OrderSndRcvJnlSchema.ct_Col_ItemCode];	// �A�C�e���R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOECheckCode] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOECheckCode];	// UOE�`�F�b�N�R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_HeadErrorMassage] = (string)dr[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage];	// �w�b�h�G���[���b�Z�[�W
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_LineErrorMassage] = (string)dr[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage];	// ���C���G���[���b�Z�[�W

                    //�f�[�^�敪
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_DataSendCode] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_DataSendCode];	// �f�[�^���M�敪
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_DataRecoverDiv] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv];	// �f�[�^�����敪

                    //���ɍX�V�敪
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec] = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec];	// ���_
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1] = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1];	// BO1
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2] = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2];	// BO2
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3] = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3];	// BO3
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker] = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker];	// Ұ��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO] = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO];	// EO
                    # endregion

                    # region �t�n�d����(DataTable��UOEOrderDtlWork)
                    // �t�n�d����(DataTable��UOEOrderDtlWork)
                    UOEOrderDtlWork uOEOrderDtlWork = _uoeSndRcvJnlAcs.CreateUOEOrderDtlWorkFromSchema(ref uOEOrderDtlRow);
                    uOEOrderDtlWorkList.Add(uOEOrderDtlWork);
                    # endregion
                    # endregion

                    //-----------------------------------------------------------
                    // �d�����ׂ̂q�d�`�c����
                    //-----------------------------------------------------------
                    # region �d�����ׂ̂q�d�`�c����
                    object[] findStockDetail = new object[2];
                    findStockDetail[0] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_SupplierFormal];
                    findStockDetail[1] = (Guid)dr[OrderSndRcvJnlSchema.ct_Col_DtlRelationGuid];
                    DataRow stockDetailRow = StockDetailTable.Rows.Find(findStockDetail);
                    if (stockDetailRow == null)
                    {
                        continue;
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // �d�����ׂ̍��ڐݒ�
                    //-----------------------------------------------------------
                    # region �d�����ׂ̍��ڐݒ�
                    # region ���ʓ`�[�ԍ��̐ݒ�
                    // ���ʓ`�[�ԍ��̐ݒ�

                    // �d������̎擾
                    int supplierCd = (int)stockDetailRow[StockDetailSchema.ct_Col_SupplierCd];
                    Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(supplierCd);

                    //���ʓ`�[�ԍ��̐ݒ�
                    Int32 uOESalesOrderNo = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];
                    stockDetailRow[StockDetailSchema.ct_Col_CommonSlipNo] = uOESalesOrderNo;//UOE�����ԍ�;

                    //���ʓ`�[�s�ԍ��̐ݒ�
                    stockDetailRow[StockDetailSchema.ct_Col_CommonSlipRowNo] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];  // UOE�����s�ԍ�

                    // UOE�����ԍ�Dictionary�̒ǉ�
                    if (uOESalesOrderNoDictionary.ContainsKey(uOESalesOrderNo) != true)
                    {
                        uOESalesOrderNoDictionary.Add(uOESalesOrderNo, uOESalesOrderNo);
                    }

                    # endregion

                    #region �������̐ݒ�
                    //�������̐ݒ�
                    Int32 cnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt]
                                + (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1]
                                + (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2]
                                + (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3]
                                + (Int32)dr[UOEOrderDtlSchema.ct_Col_MakerFollowCnt]
                                + (Int32)dr[UOEOrderDtlSchema.ct_Col_EOAlwcCount];
                    stockDetailRow[StockDetailSchema.ct_Col_OrderCnt] = (double)cnt;
                    stockDetailRow[StockDetailSchema.ct_Col_StockCount] = (double)cnt;
                    stockDetailRow[StockDetailSchema.ct_Col_OrderRemainCnt] = (double)cnt;
                    #endregion

                    #region �ېŋ敪�̎Z�o
                    int dstTaxationCode = (int)stockDetailRow[StockDetailSchema.ct_Col_TaxationCode];

                    if ((supplier.SuppCTaxLayCd == 9)
                    || (supplier.SuppCTaxationCd == 1)
                    || (dstTaxationCode == (int)CalculateTax.TaxationCode.TaxNone))
                    {
                        dstTaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }
                    #endregion

                    #region �艿
                    //�艿�i�Ŕ��C�����j
                    double dstPrice = (double)dr[UOEOrderDtlSchema.ct_Col_AnswerListPrice];

                    stockDetailRow[StockDetailSchema.ct_Col_ListPriceTaxExcFl] = dstPrice;

                    //�艿�i�ō��C�����j
                    if (supplier != null)
                    {
                        stockDetailRow[StockDetailSchema.ct_Col_ListPriceTaxIncFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstPrice, dstTaxationCode, supplier.StockCnsTaxFrcProcCd);
                    }
                    #endregion

                    #region �d���P���ύX�敪
                    //�d���P���ύX�敪
                    //�ύX�O�����Ɖ񓚌������قȂ�

                    double srcCost = (double)stockDetailRow[StockDetailSchema.ct_Col_BfStockUnitPriceFl];
                    double dstCost = (double)dr[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost];

                    if (srcCost != dstCost)
                    {
                        stockDetailRow[StockDetailSchema.ct_Col_StockUnitChngDiv] = 1;
                    }
                    //�ύX�O�����Ɖ񓚌���������
                    else
                    {
                        stockDetailRow[StockDetailSchema.ct_Col_StockUnitChngDiv] = 0;
                    }
                    #endregion

                    #region �d���P��
                    //�d���P���i�Ŕ��C�����j
                    stockDetailRow[StockDetailSchema.ct_Col_StockUnitPriceFl] = (double)dr[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost];

                    //�d���P���i�ō��C�����j
                    if (supplier != null)
                    {
                        stockDetailRow[StockDetailSchema.ct_Col_StockUnitTaxPriceFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstCost, dstTaxationCode, supplier.StockCnsTaxFrcProcCd);
                    }
                    #endregion

                    #region �d�����z
                    if (supplier != null)
                    {
                        long stockPriceTaxInc = 0;
                        long stockPriceTaxExc = 0;
                        long stockPriceConsTax = 0;

                        bool bStatus = _uOEOrderDtlAcs.CalculationStockPrice(
                            (double)cnt,
                            (double)stockDetailRow[StockDetailSchema.ct_Col_StockUnitPriceFl],
                            dstTaxationCode,
                            supplier.StockMoneyFrcProcCd,
                            supplier.StockCnsTaxFrcProcCd,
                            out stockPriceTaxInc,
                            out stockPriceTaxExc,
                            out stockPriceConsTax);

                        if (bStatus == true)
                        {
                            //�d�����z�i�Ŕ����j
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxExc] = stockPriceTaxExc;

                            //�d�����z�i�ō��݁j
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxInc] = stockPriceTaxInc;
                        }
                        else
                        {
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxExc] = 0;
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxInc] = 0;
                        }
                    }
                    #endregion

                    #region �����
                    //�d�����z����Ŋz
                    stockDetailRow[StockDetailSchema.ct_Col_StockPriceConsTax] = (Int64)stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxInc]
                                                                               - (Int64)stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxExc];
                    #endregion
                    # endregion
                }
                # endregion

                //-----------------------------------------------------------
                // �d���f�[�^�̍쐬�i�d�����I�u�W�F�N�g�̍쐬�j
                //-----------------------------------------------------------
                # region �d���f�[�^�쐬�i�d�����I�u�W�F�N�g�̍쐬�j
                foreach (Int32 key in uOESalesOrderNoDictionary.Keys)
                {
                    # region �t�n�d������ԍ��̎擾
                    // �t�n�d������ԍ��̎擾
                    Int32 savUOESalesOrderNo = uOESalesOrderNoDictionary[key];
                    if (savUOESalesOrderNo == 0) continue;
                    # endregion

                    # region �d�����ׂ̎擾
                    // �d�����ׂ̎擾
                    DataView view = GetStockDetailFormCreateView(uOESupplier.UOESupplierCd, savUOESalesOrderNo);
                    if (view.Count == 0) continue;

                    List<StockDetailWork> uoeStockDetailWorkList = new List<StockDetailWork>();
                    foreach (DataRowView dataRowView in view)
                    {
                        StockDetailWork stockDetailWork = _uoeSndRcvJnlAcs.CreateStockDetailWorkFromSchema(dataRowView.Row);
                        uoeStockDetailWorkList.Add(stockDetailWork);
                    }
                    #endregion

                    # region �d���f�[�^�v�������̎擾
                    //�d���f�[�^�v�������̎擾
                    StockSlipWork stockSlipWork = GetStockSlipWorkFromStockDetailDataTable(
                                                            uOESupplier.UOESupplierCd,
                                                            savUOESalesOrderNo,
                                                            out message);
                    if (stockSlipWork == null)  continue;
                    #endregion

                    # region �d�����I�u�W�F�N�g�̍쐬
                    //�d�����I�u�W�F�N�g�̍쐬
                    StockSlipGrp stockSlipGrp = new StockSlipGrp();
                    stockSlipGrp.stockSlipWork = stockSlipWork;
                    stockSlipGrp.stockDetailWorkList = uoeStockDetailWorkList;
                    stockSlipGrpList.Add(stockSlipGrp);
                    # endregion
                }
                # endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region ������M�i�m�k���񓚍X�V�Ώۃf�[�^�̒��o
        /// <summary>
        /// ������M�i�m�k���񓚍X�V�Ώۃf�[�^�̒��o�iUOE������R�[�h�EUOE������R�[�h�E�n�C�t�������i�ԍ��j
        /// </summary>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <param name="uOESalesOrderNo">UOE�����ԍ�</param>
        /// <param name="goodsNoNoneHyphen">�n�C�t�������i�ԍ�</param>
        /// <returns>�񓚍X�V�Ώۃf�[�^</returns>
        private DataView GetOrderFormCreateView(int uOESupplierCd, int uOESalesOrderNo, string goodsNoNoneHyphen)
        {
            DataView view = new DataView(this.OrderTable);

            string rowFilterText = string.Format("{0} = {1} AND {2} = {3} AND {4} = '{5}'",
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd, uOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo, uOESalesOrderNo,
                                            OrderSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen, goodsNoNoneHyphen
                                            );


            // �\�[�g���ݒ�
            string sortText = string.Format("{0}, {1}, {2}, {3}, {4}",
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineRowNo
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }

        /// <summary>
        /// ������M�i�m�k���񓚍X�V�Ώۃf�[�^�̒��o�iUOE������R�[�h�E�f�[�^���M�敪�E�f�[�^�����敪�j
        /// </summary>
        /// <param name="uOEKind">UOE���</param>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <param name="dataSendCode">�f�[�^���M�敪</param>
        /// <param name="dataRecoverDiv">�f�[�^�����敪</param>
        /// <returns>�񓚍X�V�Ώۃf�[�^</returns>
        private DataView GetOrderFormCreateView(int uOEKind, int uOESupplierCd, int dataSendCode, int dataRecoverDiv)
        {
            DataView view = new DataView(this.OrderTable);

            string rowFilterText = string.Format("{0} = {1} AND {2} = {3} AND {4} = {5} AND {6} = {7}",
                                            OrderSndRcvJnlSchema.ct_Col_UOEKind, uOEKind,
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd, uOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_DataSendCode, dataSendCode,
                                            OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv, dataRecoverDiv
                                            );

            // �\�[�g���ݒ�
            string sortText = string.Format("{0}, {1}, {2}, {3}, {4}",
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineRowNo
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }
    	# endregion
        # endregion

    }
}
