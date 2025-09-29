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
    /// �������M�G���[���X�g�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������M�G���[���X�g�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2008.12.10</br>
    /// <br></br>
    /// </remarks>
    public class SupplierSendErOrderAcs
    {
        #region �� Constructor
		/// <summary>
        /// �������M�G���[���X�g�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �������M�G���[���X�g�A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : 30413 ����</br>
	    /// <br>Date       : 2008.12.10</br>
		/// </remarks>
		public SupplierSendErOrderAcs()
		{
            this._iSupplierSendErOrderWorkDB = (ISupplierSendErOrderWorkDB)MediationSupplierSendErOrderWorkDB.GetSupplierSendErOrderWorkDB();
            this._iUOEOrderDtlDB = (IUOEOrderDtlDB)MediationUOEOrderDtlDB.GetUOEOrderDtlDB();
		}

		/// <summary>
        /// �������M�G���[���X�g�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �������M�G���[���X�g�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.10</br>
        /// </remarks>
        static SupplierSendErOrderAcs()
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
        ISupplierSendErOrderWorkDB _iSupplierSendErOrderWorkDB;         // �������M�G���[���X�g�����[�g
        IUOEOrderDtlDB _iUOEOrderDtlDB;         // UOE�����f�[�^�X�V�����[�g

        private DataSet _supplierSendErDs;				        // �������M�G���[���X�g�f�[�^�Z�b�g

        // �������M�G���[���X�g�̒��o���ʂ�ۑ�
        private static ArrayList _stc_SupplierSendErResultWorkList;

        #endregion �� Private Member

        #region �� Public Property
        /// <summary>
        /// �������M�G���[���X�g�f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet SupplierSendErDs
        {
            get { return this._supplierSendErDs; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� �o�̓f�[�^�擾
        #region �� �������M�G���[���X�g�f�[�^�擾
        /// <summary>
        /// �������M�G���[���X�g�f�[�^�擾
        /// </summary>
        /// <param name="supplierSendErOrderCndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������锭�����M�G���[���X�g�f�[�^���擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.10</br>
        /// </remarks>
        public int SearchSupplierSendErOrder(SupplierSendErOrderCndtn supplierSendErOrderCndtn, out string errMsg)
        {
            return this.SearchSupplierSendErOrderProc(supplierSendErOrderCndtn, out errMsg);
        }
        #endregion
        #endregion �� �o�̓f�[�^�擾
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� �������M�G���[���X�g�f�[�^�擾
        /// <summary>
        /// �������M�G���[���X�g�f�[�^�擾
        /// </summary>
        /// <param name="supplierSendErOrderCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������锭�����M�G���[���X�g�f�[�^���擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.10</br>
        /// </remarks>
        private int SearchSupplierSendErOrderProc(SupplierSendErOrderCndtn supplierSendErOrderCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // �X�V�p�̔������M�G���[���X�g���N���A
                _stc_SupplierSendErResultWorkList = new ArrayList();

                // DataTable Create ----------------------------------------------------------
                SupplierSendErResult.CreateDataTableResultSupplierSendEr(ref this._supplierSendErDs);
                SupplierSendErOrderCndtnWork supplierSendErOrderCndtnWork = new SupplierSendErOrderCndtnWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevSupplierSendErOrder(supplierSendErOrderCndtn, out supplierSendErOrderCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                status = this._iSupplierSendErOrderWorkDB.Search(out retList, (object)supplierSendErOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevSupplierSendErOrderData(supplierSendErOrderCndtn, this._supplierSendErDs.Tables[SupplierSendErResult.Col_Tbl_Result_SupplierSendEr], (ArrayList)retList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�������M�G���[���X�g�f�[�^�̎擾�Ɏ��s���܂����B";
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
        /// <param name="supplierSendErOrderCndtn">UI���o�����N���X</param>
        /// <param name="supplierSendErOrderCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevSupplierSendErOrder(SupplierSendErOrderCndtn supplierSendErOrderCndtn, out SupplierSendErOrderCndtnWork supplierSendErOrderCndtnWork, out string errMsg)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            supplierSendErOrderCndtnWork = new SupplierSendErOrderCndtnWork();

            try
            {
                // ��ƃR�[�h
                supplierSendErOrderCndtnWork.EnterpriseCode = supplierSendErOrderCndtn.EnterpriseCode;

                // ���o�����p�����[�^�Z�b�g
                if (supplierSendErOrderCndtn.SectionCodes.Length != 0)
                {
                    if (supplierSendErOrderCndtn.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        supplierSendErOrderCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        supplierSendErOrderCndtnWork.SectionCodes = supplierSendErOrderCndtn.SectionCodes;
                    }
                }
                else
                {
                    supplierSendErOrderCndtnWork.SectionCodes = null;
                }


                supplierSendErOrderCndtnWork.St_UOESupplierCd = supplierSendErOrderCndtn.St_UOESupplierCd;          // �J�nUOE������R�[�h
                supplierSendErOrderCndtnWork.Ed_UOESupplierCd = supplierSendErOrderCndtn.Ed_UOESupplierCd;          // �I��UOE������R�[�h
                
                supplierSendErOrderCndtnWork.St_ReceiveDate = supplierSendErOrderCndtn.St_ReceiveDate;	            // �J�n��M���t
                supplierSendErOrderCndtnWork.Ed_ReceiveDate = supplierSendErOrderCndtn.Ed_ReceiveDate;	            // �I����M���t

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region �� �������M�G���[���X�g�f�[�^�W�J����
        /// <summary>
        /// �������M�G���[���X�g�f�[�^�W�J����
        /// </summary>
        /// <param name="supplierSendErOrderCndtn">UI���o�����N���X</param>
        /// <param name="supplierSendErOrderDt">�W�J�Ώ�DataTable</param>
        /// <param name="supplierSendErResultWorkList">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������M�G���[���X�g�f�[�^��W�J����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.10</br>
        /// </remarks>
        private void DevSupplierSendErOrderData(SupplierSendErOrderCndtn supplierSendErOrderCndtn, DataTable supplierSendErOrderDt, ArrayList supplierSendErResultWorkList)
        {
            DataRow dr;

            foreach (SupplierSendErResultWork supplierSendErResultWork in supplierSendErResultWorkList)
            {
                dr = supplierSendErOrderDt.NewRow();

                // �������M�G���[���X�g�f�[�^�W�J
                #region �������M�G���[���X�g�f�[�^�W�J
                // �쐬����
                dr[SupplierSendErResult.Col_CreateDateTime] = supplierSendErResultWork.CreateDateTime;
                // �X�V����
                dr[SupplierSendErResult.Col_UpdateDateTime] = supplierSendErResultWork.UpdateDateTime;
                // ��ƃR�[�h
                dr[SupplierSendErResult.Col_EnterpriseCode] = supplierSendErResultWork.EnterpriseCode;
                // GUID
                dr[SupplierSendErResult.Col_FileHeaderGuid] = supplierSendErResultWork.FileHeaderGuid;
                // �X�V�]�ƈ��R�[�h
                dr[SupplierSendErResult.Col_UpdEmployeeCode] = supplierSendErResultWork.UpdEmployeeCode;
                // �X�V�A�Z���u��ID1
                dr[SupplierSendErResult.Col_UpdAssemblyId1] = supplierSendErResultWork.UpdAssemblyId1;
                // �X�V�A�Z���u��ID2
                dr[SupplierSendErResult.Col_UpdAssemblyId2] = supplierSendErResultWork.UpdAssemblyId2;
                // �_���폜�敪
                dr[SupplierSendErResult.Col_LogicalDeleteCode] = supplierSendErResultWork.LogicalDeleteCode;
                // �V�X�e���敪
                dr[SupplierSendErResult.Col_SystemDivCd] = supplierSendErResultWork.SystemDivCd;
                // UOE�����ԍ�
                dr[SupplierSendErResult.Col_UOESalesOrderNo] = supplierSendErResultWork.UOESalesOrderNo;
                // UOE�����s�ԍ�
                dr[SupplierSendErResult.Col_UOESalesOrderRowNo] = supplierSendErResultWork.UOESalesOrderRowNo;
                // ���M�[���ԍ�
                dr[SupplierSendErResult.Col_SendTerminalNo] = supplierSendErResultWork.SendTerminalNo;
                // UOE������R�[�h
                dr[SupplierSendErResult.Col_UOESupplierCd] = supplierSendErResultWork.UOESupplierCd;
                // UOE�����於��
                dr[SupplierSendErResult.Col_UOESupplierName] = supplierSendErResultWork.UOESupplierName;
                // �ʐM�A�Z���u��ID
                dr[SupplierSendErResult.Col_CommAssemblyId] = supplierSendErResultWork.CommAssemblyId;
                // �ʐM�A�Z���u��ID
                dr[SupplierSendErResult.Col_OnlineNo] = supplierSendErResultWork.OnlineNo;
                // �I�����C���s�ԍ�
                dr[SupplierSendErResult.Col_OnlineRowNo] = supplierSendErResultWork.OnlineRowNo;
                // ������t
                dr[SupplierSendErResult.Col_SalesDate] = supplierSendErResultWork.SalesDate;
                // ���͓�
                dr[SupplierSendErResult.Col_InputDay] = supplierSendErResultWork.InputDay;
                // �f�[�^�X�V����
                dr[SupplierSendErResult.Col_DataUpdateDateTime] = supplierSendErResultWork.DataUpdateDateTime;
                // UOE���
                dr[SupplierSendErResult.Col_UOEKind] = supplierSendErResultWork.UOEKind;
                // ����`�[�ԍ�
                dr[SupplierSendErResult.Col_SalesSlipNum] = supplierSendErResultWork.SalesSlipNum;
                // �󒍃X�e�[�^�X
                dr[SupplierSendErResult.Col_AcptAnOdrStatus] = supplierSendErResultWork.AcptAnOdrStatus;
                // ���㖾�גʔ�
                dr[SupplierSendErResult.Col_SalesSlipDtlNum] = supplierSendErResultWork.SalesSlipDtlNum;
                // ���_�R�[�h
                dr[SupplierSendErResult.Col_SectionCode] = supplierSendErResultWork.SectionCode;
                // ���_�K�C�h����
                dr[SupplierSendErResult.Col_SectionGuideSnm] = supplierSendErResultWork.SectionGuideSnm;
                // ����R�[�h
                dr[SupplierSendErResult.Col_SubSectionCode] = supplierSendErResultWork.SubSectionCode;
                // ���Ӑ�R�[�h
                dr[SupplierSendErResult.Col_CustomerCode] = supplierSendErResultWork.CustomerCode;
                // ���Ӑ旪��
                dr[SupplierSendErResult.Col_CustomerSnm] = supplierSendErResultWork.CustomerSnm;
                // ���W�ԍ�
                dr[SupplierSendErResult.Col_CashRegisterNo] = supplierSendErResultWork.CashRegisterNo;
                // ���ʒʔ�
                dr[SupplierSendErResult.Col_CommonSeqNo] = supplierSendErResultWork.CommonSeqNo;
                // �d���`��
                dr[SupplierSendErResult.Col_SupplierFormal] = supplierSendErResultWork.SupplierFormal;
                // �d���`�[�ԍ�
                dr[SupplierSendErResult.Col_SupplierSlipNo] = supplierSendErResultWork.SupplierSlipNo;
                // �d�����גʔ�
                dr[SupplierSendErResult.Col_StockSlipDtlNum] = supplierSendErResultWork.StockSlipDtlNum;
                // BO�敪
                dr[SupplierSendErResult.Col_BoCode] = supplierSendErResultWork.BoCode;
                // UOE�[�i�敪
                dr[SupplierSendErResult.Col_UOEDeliGoodsDiv] = supplierSendErResultWork.UOEDeliGoodsDiv;
                // �[�i�敪����
                dr[SupplierSendErResult.Col_DeliveredGoodsDivNm] = supplierSendErResultWork.DeliveredGoodsDivNm;
                // �t�H���[�[�i�敪
                dr[SupplierSendErResult.Col_FollowDeliGoodsDiv] = supplierSendErResultWork.FollowDeliGoodsDiv;
                // �t�H���[�[�i�敪����
                dr[SupplierSendErResult.Col_FollowDeliGoodsDivNm] = supplierSendErResultWork.FollowDeliGoodsDivNm;
                // UOE�w�苒�_
                dr[SupplierSendErResult.Col_UOEResvdSection] = supplierSendErResultWork.UOEResvdSection;
                // UOE�w�苒�_����
                dr[SupplierSendErResult.Col_UOEResvdSectionNm] = supplierSendErResultWork.UOEResvdSectionNm;
                // �]�ƈ��R�[�h
                dr[SupplierSendErResult.Col_EmployeeCode] = supplierSendErResultWork.EmployeeCode;
                // �]�ƈ�����
                dr[SupplierSendErResult.Col_EmployeeName] = supplierSendErResultWork.EmployeeName;
                // ���i���[�J�[�R�[�h
                dr[SupplierSendErResult.Col_GoodsMakerCd] = supplierSendErResultWork.GoodsMakerCd;
                // ���[�J�[����
                dr[SupplierSendErResult.Col_MakerName] = supplierSendErResultWork.MakerName;
                // ���i�ԍ�
                dr[SupplierSendErResult.Col_GoodsNo] = supplierSendErResultWork.GoodsNo;
                // �n�C�t�������i�ԍ�
                dr[SupplierSendErResult.Col_GoodsNoNoneHyphen] = supplierSendErResultWork.GoodsNoNoneHyphen;
                // ���i����
                dr[SupplierSendErResult.Col_GoodsName] = supplierSendErResultWork.GoodsName;
                // �q�ɃR�[�h
                dr[SupplierSendErResult.Col_WarehouseCode] = supplierSendErResultWork.WarehouseCode;
                // �q�ɖ���
                dr[SupplierSendErResult.Col_WarehouseName] = supplierSendErResultWork.WarehouseName;
                // �q�ɒI��
                dr[SupplierSendErResult.Col_WarehouseShelfNo] = supplierSendErResultWork.WarehouseShelfNo;
                // �󒍐���
                dr[SupplierSendErResult.Col_AcceptAnOrderCnt] = supplierSendErResultWork.AcceptAnOrderCnt;
                // �艿�i�����j
                dr[SupplierSendErResult.Col_ListPrice] = supplierSendErResultWork.ListPrice;
                // �����P��
                dr[SupplierSendErResult.Col_SalesUnitCost] = supplierSendErResultWork.SalesUnitCost;
                // �d����R�[�h
                dr[SupplierSendErResult.Col_SupplierCd] = supplierSendErResultWork.SupplierCd;
                // �d���旪��
                dr[SupplierSendErResult.Col_SupplierSnm] = supplierSendErResultWork.SupplierSnm;
                // �t�n�d���}�[�N�P
                dr[SupplierSendErResult.Col_UoeRemark1] = supplierSendErResultWork.UoeRemark1;
                // �t�n�d���}�[�N�Q
                dr[SupplierSendErResult.Col_UoeRemark2] = supplierSendErResultWork.UoeRemark2;
                // ��M���t
                dr[SupplierSendErResult.Col_ReceiveDate] = supplierSendErResultWork.ReceiveDate;
                // ��M����
                dr[SupplierSendErResult.Col_ReceiveTime] = supplierSendErResultWork.ReceiveTime;
                // �񓚃��[�J�[�R�[�h
                dr[SupplierSendErResult.Col_AnswerMakerCd] = supplierSendErResultWork.AnswerMakerCd;
                // �񓚕i��
                dr[SupplierSendErResult.Col_AnswerPartsNo] = supplierSendErResultWork.AnswerPartsNo;
                // �񓚕i��
                dr[SupplierSendErResult.Col_AnswerPartsName] = supplierSendErResultWork.AnswerPartsName;
                // ��֕i��
                dr[SupplierSendErResult.Col_SubstPartsNo] = supplierSendErResultWork.SubstPartsNo;
                // UOE���_�o�ɐ�
                dr[SupplierSendErResult.Col_UOESectOutGoodsCnt] = supplierSendErResultWork.UOESectOutGoodsCnt;
                // BO�o�ɐ�1
                dr[SupplierSendErResult.Col_BOShipmentCnt1] = supplierSendErResultWork.BOShipmentCnt1;
                // BO�o�ɐ�2
                dr[SupplierSendErResult.Col_BOShipmentCnt2] = supplierSendErResultWork.BOShipmentCnt2;
                // BO�o�ɐ�3
                dr[SupplierSendErResult.Col_BOShipmentCnt3] = supplierSendErResultWork.BOShipmentCnt3;
                // ���[�J�[�t�H���[��
                dr[SupplierSendErResult.Col_MakerFollowCnt] = supplierSendErResultWork.MakerFollowCnt;
                // ���o�ɐ�
                dr[SupplierSendErResult.Col_NonShipmentCnt] = supplierSendErResultWork.NonShipmentCnt;
                // UOE���_�݌ɐ�
                dr[SupplierSendErResult.Col_UOESectStockCnt] = supplierSendErResultWork.UOESectStockCnt;
                // BO�݌ɐ�1
                dr[SupplierSendErResult.Col_BOStockCount1] = supplierSendErResultWork.BOStockCount1;
                // BO�݌ɐ�2
                dr[SupplierSendErResult.Col_BOStockCount2] = supplierSendErResultWork.BOStockCount2;
                // BO�݌ɐ�3
                dr[SupplierSendErResult.Col_BOStockCount3] = supplierSendErResultWork.BOStockCount3;
                // UOE���_�`�[�ԍ�
                dr[SupplierSendErResult.Col_UOESectionSlipNo] = supplierSendErResultWork.UOESectionSlipNo;
                // BO�`�[�ԍ��P
                dr[SupplierSendErResult.Col_BOSlipNo1] = supplierSendErResultWork.BOSlipNo1;
                // BO�`�[�ԍ��Q
                dr[SupplierSendErResult.Col_BOSlipNo2] = supplierSendErResultWork.BOSlipNo2;
                // BO�`�[�ԍ��R
                dr[SupplierSendErResult.Col_BOSlipNo3] = supplierSendErResultWork.BOSlipNo3;
                // EO������
                dr[SupplierSendErResult.Col_EOAlwcCount] = supplierSendErResultWork.EOAlwcCount;
                // BO�Ǘ��ԍ�
                dr[SupplierSendErResult.Col_BOManagementNo] = supplierSendErResultWork.BOManagementNo;
                // �񓚒艿
                dr[SupplierSendErResult.Col_AnswerListPrice] = supplierSendErResultWork.AnswerListPrice;
                // �񓚌����P��
                dr[SupplierSendErResult.Col_AnswerSalesUnitCost] = supplierSendErResultWork.AnswerSalesUnitCost;
                // UOE��փ}�[�N
                dr[SupplierSendErResult.Col_UOESubstMark] = supplierSendErResultWork.UOESubstMark;
                // UOE�݌Ƀ}�[�N
                dr[SupplierSendErResult.Col_UOEStockMark] = supplierSendErResultWork.UOEStockMark;
                // �w�ʃR�[�h
                dr[SupplierSendErResult.Col_PartsLayerCd] = supplierSendErResultWork.PartsLayerCd;
                // UOE�o�׋��_�R�[�h�P�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOEShipSectCd1] = supplierSendErResultWork.MazdaUOEShipSectCd1;
                // UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOEShipSectCd2] = supplierSendErResultWork.MazdaUOEShipSectCd2;
                // UOE�o�׋��_�R�[�h�R�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOEShipSectCd3] = supplierSendErResultWork.MazdaUOEShipSectCd3;
                // UOE���_�R�[�h�P�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOESectCd1] = supplierSendErResultWork.MazdaUOESectCd1;
                // UOE���_�R�[�h�Q�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOESectCd2] = supplierSendErResultWork.MazdaUOESectCd2;
                // UOE���_�R�[�h�R�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOESectCd3] = supplierSendErResultWork.MazdaUOESectCd3;
                // UOE���_�R�[�h�S�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOESectCd4] = supplierSendErResultWork.MazdaUOESectCd4;
                // UOE���_�R�[�h�T�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOESectCd5] = supplierSendErResultWork.MazdaUOESectCd5;
                // UOE���_�R�[�h�U�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOESectCd6] = supplierSendErResultWork.MazdaUOESectCd6;
                // UOE���_�R�[�h�V�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOESectCd7] = supplierSendErResultWork.MazdaUOESectCd7;
                // UOE�݌ɐ��P�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt1] = supplierSendErResultWork.MazdaUOEStockCnt1;
                // UOE�݌ɐ��Q�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt2] = supplierSendErResultWork.MazdaUOEStockCnt2;
                // UOE�݌ɐ��R�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt3] = supplierSendErResultWork.MazdaUOEStockCnt3;
                // UOE�݌ɐ��S�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt4] = supplierSendErResultWork.MazdaUOEStockCnt4;
                // UOE�݌ɐ��T�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt5] = supplierSendErResultWork.MazdaUOEStockCnt5;
                // UOE�݌ɐ��U�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt6] = supplierSendErResultWork.MazdaUOEStockCnt6;
                // UOE�݌ɐ��V�i�}�c�_�j
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt7] = supplierSendErResultWork.MazdaUOEStockCnt7;
                // UOE���R�[�h
                dr[SupplierSendErResult.Col_UOEDistributionCd] = supplierSendErResultWork.UOEDistributionCd;
                // UOE���R�[�h
                dr[SupplierSendErResult.Col_UOEOtherCd] = supplierSendErResultWork.UOEOtherCd;
                // UOE�g�l�R�[�h
                dr[SupplierSendErResult.Col_UOEHMCd] = supplierSendErResultWork.UOEHMCd;
                // �a�n��
                dr[SupplierSendErResult.Col_BOCount] = supplierSendErResultWork.BOCount;
                // UOE�}�[�N�R�[�h
                dr[SupplierSendErResult.Col_UOEMarkCode] = supplierSendErResultWork.UOEMarkCode;
                // �o�׌�
                dr[SupplierSendErResult.Col_SourceShipment] = supplierSendErResultWork.SourceShipment;
                // �A�C�e���R�[�h
                dr[SupplierSendErResult.Col_ItemCode] = supplierSendErResultWork.ItemCode;
                // UOE�`�F�b�N�R�[�h
                dr[SupplierSendErResult.Col_UOECheckCode] = supplierSendErResultWork.UOECheckCode;
                // �w�b�h�G���[���b�Z�[�W
                dr[SupplierSendErResult.Col_HeadErrorMassage] = supplierSendErResultWork.HeadErrorMassage;
                // ���C���G���[���b�Z�[�W
                dr[SupplierSendErResult.Col_LineErrorMassage] = supplierSendErResultWork.LineErrorMassage;
                // �f�[�^���M�敪
                dr[SupplierSendErResult.Col_DataSendCode] = supplierSendErResultWork.DataSendCode;
                // �f�[�^�����敪
                dr[SupplierSendErResult.Col_DataRecoverDiv] = supplierSendErResultWork.DataRecoverDiv;
                // ���ɍX�V�敪�i���_�j
                dr[SupplierSendErResult.Col_EnterUpdDivSec] = supplierSendErResultWork.EnterUpdDivSec;
                // ���ɍX�V�敪�iBO1�j
                dr[SupplierSendErResult.Col_EnterUpdDivBO1] = supplierSendErResultWork.EnterUpdDivBO1;
                // ���ɍX�V�敪�iBO2�j
                dr[SupplierSendErResult.Col_EnterUpdDivBO2] = supplierSendErResultWork.EnterUpdDivBO2;
                // ���ɍX�V�敪�iBO3�j
                dr[SupplierSendErResult.Col_EnterUpdDivBO3] = supplierSendErResultWork.EnterUpdDivBO3;
                // ���ɍX�V�敪�iҰ���j
                dr[SupplierSendErResult.Col_EnterUpdDivMaker] = supplierSendErResultWork.EnterUpdDivMaker;
                // ���ɍX�V�敪�iEO�j
                dr[SupplierSendErResult.Col_EnterUpdDivEO] = supplierSendErResultWork.EnterUpdDivEO;

                // ����p
                // ��M���t(����p)
                dr[SupplierSendErResult.Col_ReceiveDate_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", supplierSendErResultWork.ReceiveDate);

                // �V�X�e���敪(����p)
                if (supplierSendErResultWork.SystemDivCd == 0)
                {
                    dr[SupplierSendErResult.Col_SystemDivCd_Print] = "�����";
                }
                else if (supplierSendErResultWork.SystemDivCd == 1)
                {
                    dr[SupplierSendErResult.Col_SystemDivCd_Print] = "�`��";
                }
                else if (supplierSendErResultWork.SystemDivCd == 2)
                {
                    dr[SupplierSendErResult.Col_SystemDivCd_Print] = "����";
                }
                else
                {
                    dr[SupplierSendErResult.Col_SystemDivCd_Print] = "�ꊇ";
                }

                #endregion

                // Table��Add
                supplierSendErOrderDt.Rows.Add(dr);

                // �X�V�p�̔������M�G���[���X�g�ɒǉ�
                _stc_SupplierSendErResultWorkList.Add(supplierSendErResultWork);
            }
        }
        #endregion

        #endregion �� �f�[�^�W�J����

        #region �� UOE�����f�[�^�̍X�V����
        #region �� UOE�����f�[�^�X�V
        /// <summary>
        /// UOE�����f�[�^�X�V
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������M�G���[��UOE�����f�[�^���X�V����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        public int UpdateUOEOrderDtl(out string errMsg)
        {
            return this.UpdateUOEOrderDtlProc(out errMsg);
        }
        #endregion

        #region �� UOE�����f�[�^�X�V
        /// <summary>
        /// UOE�����f�[�^�X�V
        /// </summary>
        /// <param name="supplierSendErOrderCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������M�G���[��UOE�����f�[�^���X�V����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private int UpdateUOEOrderDtlProc(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                ArrayList uoeOrderDtlWorkList;
                // �X�V�p��UOE�����f�[�^�쐬
                this.SetUOEOrderDtlWork(out uoeOrderDtlWorkList);
                
                // �X�V����
                object writeObj = uoeOrderDtlWorkList;
                status = this._iUOEOrderDtlDB.Write(ref writeObj);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                       status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "UOE�����f�[�^�̍X�V�Ɏ��s���܂����B";
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

        #region UOE�����f�[�^�̐ݒ�
        /// <summary>
        /// UOE�����f�[�^�̐ݒ�
        /// </summary>
        /// <param name="orderListCndtn">���o�����f�[�^�N���X</param>
        /// <param name="dr">���o���ʃf�[�^�s</param>
        /// <param name="guid">UOE�������֘A�t��Guid</param>
        /// <param name="uoeList">UOE�����f�[�^���X�g</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^���쐬�B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private void SetUOEOrderDtlWork(out ArrayList uoeOrderDtlWorkList)
        {
            UOEOrderDtlWork uoeOrderDtlWork;
         
            uoeOrderDtlWorkList = new ArrayList();

            foreach (SupplierSendErResultWork supplierSendErResultWork in _stc_SupplierSendErResultWorkList)
            {
                uoeOrderDtlWork = new UOEOrderDtlWork();

                // �쐬����
                uoeOrderDtlWork.CreateDateTime = supplierSendErResultWork.CreateDateTime;
                // �X�V����
                uoeOrderDtlWork.UpdateDateTime = supplierSendErResultWork.UpdateDateTime;
                // ��ƃR�[�h
                uoeOrderDtlWork.EnterpriseCode = supplierSendErResultWork.EnterpriseCode;
                // GUID
                uoeOrderDtlWork.FileHeaderGuid = supplierSendErResultWork.FileHeaderGuid;
                // �X�V�]�ƈ��R�[�h
                uoeOrderDtlWork.UpdEmployeeCode = supplierSendErResultWork.UpdEmployeeCode;
                // �X�V�A�Z���u��ID1
                uoeOrderDtlWork.UpdAssemblyId1 = supplierSendErResultWork.UpdAssemblyId1;
                // �X�V�A�Z���u��ID2
                uoeOrderDtlWork.UpdAssemblyId2 = supplierSendErResultWork.UpdAssemblyId2;
                // �_���폜�敪
                uoeOrderDtlWork.LogicalDeleteCode = supplierSendErResultWork.LogicalDeleteCode;
                // �V�X�e���敪
                uoeOrderDtlWork.SystemDivCd = supplierSendErResultWork.SystemDivCd;
                // UOE�����ԍ�
                uoeOrderDtlWork.UOESalesOrderNo = supplierSendErResultWork.UOESalesOrderNo;
                // UOE�����s�ԍ�
                uoeOrderDtlWork.UOESalesOrderRowNo = supplierSendErResultWork.UOESalesOrderRowNo;
                // ���M�[���ԍ�
                uoeOrderDtlWork.SendTerminalNo = 0;
                // UOE������R�[�h
                uoeOrderDtlWork.UOESupplierCd = supplierSendErResultWork.UOESupplierCd;
                // UOE�����於��
                uoeOrderDtlWork.UOESupplierName = supplierSendErResultWork.UOESupplierName;
                // �ʐM�A�Z���u��ID
                uoeOrderDtlWork.CommAssemblyId = supplierSendErResultWork.CommAssemblyId;
                // �ʐM�A�Z���u��ID
                uoeOrderDtlWork.OnlineNo = supplierSendErResultWork.OnlineNo;
                // �I�����C���s�ԍ�
                uoeOrderDtlWork.OnlineRowNo = supplierSendErResultWork.OnlineRowNo;
                // ������t
                uoeOrderDtlWork.SalesDate = supplierSendErResultWork.SalesDate;
                // ���͓�
                uoeOrderDtlWork.InputDay = supplierSendErResultWork.InputDay;
                // �f�[�^�X�V����
                uoeOrderDtlWork.DataUpdateDateTime = supplierSendErResultWork.DataUpdateDateTime;
                // UOE���
                uoeOrderDtlWork.UOEKind = supplierSendErResultWork.UOEKind;
                // ����`�[�ԍ�
                uoeOrderDtlWork.SalesSlipNum = supplierSendErResultWork.SalesSlipNum;
                // �󒍃X�e�[�^�X
                uoeOrderDtlWork.AcptAnOdrStatus = supplierSendErResultWork.AcptAnOdrStatus;
                // ���㖾�גʔ�
                uoeOrderDtlWork.SalesSlipDtlNum = supplierSendErResultWork.SalesSlipDtlNum;
                // ���_�R�[�h
                uoeOrderDtlWork.SectionCode = supplierSendErResultWork.SectionCode;
                // ����R�[�h
                uoeOrderDtlWork.SubSectionCode = supplierSendErResultWork.SubSectionCode;
                // ���Ӑ�R�[�h
                uoeOrderDtlWork.CustomerCode = supplierSendErResultWork.CustomerCode;
                // ���Ӑ旪��
                uoeOrderDtlWork.CustomerSnm = supplierSendErResultWork.CustomerSnm;
                // ���W�ԍ�
                uoeOrderDtlWork.CashRegisterNo = supplierSendErResultWork.CashRegisterNo;
                // ���ʒʔ�
                uoeOrderDtlWork.CommonSeqNo = supplierSendErResultWork.CommonSeqNo;
                // �d���`��
                uoeOrderDtlWork.SupplierFormal = supplierSendErResultWork.SupplierFormal;
                // �d���`�[�ԍ�
                uoeOrderDtlWork.SupplierSlipNo = supplierSendErResultWork.SupplierSlipNo;
                // �d�����גʔ�
                uoeOrderDtlWork.StockSlipDtlNum = supplierSendErResultWork.StockSlipDtlNum;
                // BO�敪
                uoeOrderDtlWork.BoCode = supplierSendErResultWork.BoCode;
                // UOE�[�i�敪
                uoeOrderDtlWork.UOEDeliGoodsDiv = supplierSendErResultWork.UOEDeliGoodsDiv;
                // �[�i�敪����
                uoeOrderDtlWork.DeliveredGoodsDivNm = supplierSendErResultWork.DeliveredGoodsDivNm;
                // �t�H���[�[�i�敪
                uoeOrderDtlWork.FollowDeliGoodsDiv = supplierSendErResultWork.FollowDeliGoodsDiv;
                // �t�H���[�[�i�敪����
                uoeOrderDtlWork.FollowDeliGoodsDivNm = supplierSendErResultWork.FollowDeliGoodsDivNm;
                // UOE�w�苒�_
                uoeOrderDtlWork.UOEResvdSection = supplierSendErResultWork.UOEResvdSection;
                // UOE�w�苒�_����
                uoeOrderDtlWork.UOEResvdSectionNm = supplierSendErResultWork.UOEResvdSectionNm;
                // �]�ƈ��R�[�h
                uoeOrderDtlWork.EmployeeCode = supplierSendErResultWork.EmployeeCode;
                // �]�ƈ�����
                uoeOrderDtlWork.EmployeeName = supplierSendErResultWork.EmployeeName;
                // ���i���[�J�[�R�[�h
                uoeOrderDtlWork.GoodsMakerCd = supplierSendErResultWork.GoodsMakerCd;
                // ���[�J�[����
                uoeOrderDtlWork.MakerName = supplierSendErResultWork.MakerName;
                // ���i�ԍ�
                uoeOrderDtlWork.GoodsNo = supplierSendErResultWork.GoodsNo;
                // �n�C�t�������i�ԍ�
                uoeOrderDtlWork.GoodsNoNoneHyphen = supplierSendErResultWork.GoodsNoNoneHyphen;
                // ���i����
                uoeOrderDtlWork.GoodsName = supplierSendErResultWork.GoodsName;
                // �q�ɃR�[�h
                uoeOrderDtlWork.WarehouseCode = supplierSendErResultWork.WarehouseCode;
                // �q�ɖ���
                uoeOrderDtlWork.WarehouseName = supplierSendErResultWork.WarehouseName;
                // �q�ɒI��
                uoeOrderDtlWork.WarehouseShelfNo = supplierSendErResultWork.WarehouseShelfNo;
                // �󒍐���
                uoeOrderDtlWork.AcceptAnOrderCnt = supplierSendErResultWork.AcceptAnOrderCnt;
                // �艿�i�����j
                uoeOrderDtlWork.ListPrice = supplierSendErResultWork.ListPrice;
                // �����P��
                uoeOrderDtlWork.SalesUnitCost = supplierSendErResultWork.SalesUnitCost;
                // �d����R�[�h
                uoeOrderDtlWork.SupplierCd = supplierSendErResultWork.SupplierCd;
                // �d���旪��
                uoeOrderDtlWork.SupplierSnm = supplierSendErResultWork.SupplierSnm;
                // �t�n�d���}�[�N�P
                uoeOrderDtlWork.UoeRemark1 = supplierSendErResultWork.UoeRemark1;
                // �t�n�d���}�[�N�Q
                uoeOrderDtlWork.UoeRemark2 = supplierSendErResultWork.UoeRemark2;
                // ��M���t
                uoeOrderDtlWork.ReceiveDate = supplierSendErResultWork.ReceiveDate;
                // ��M����
                uoeOrderDtlWork.ReceiveTime = supplierSendErResultWork.ReceiveTime;
                // �񓚃��[�J�[�R�[�h
                uoeOrderDtlWork.AnswerMakerCd = supplierSendErResultWork.AnswerMakerCd;
                // �񓚕i��
                uoeOrderDtlWork.AnswerPartsNo = supplierSendErResultWork.AnswerPartsNo;
                // �񓚕i��
                uoeOrderDtlWork.AnswerPartsName = supplierSendErResultWork.AnswerPartsName;
                // ��֕i��
                uoeOrderDtlWork.SubstPartsNo = supplierSendErResultWork.SubstPartsNo;
                // UOE���_�o�ɐ�
                uoeOrderDtlWork.UOESectOutGoodsCnt = supplierSendErResultWork.UOESectOutGoodsCnt;
                // BO�o�ɐ�1
                uoeOrderDtlWork.BOShipmentCnt1 = supplierSendErResultWork.BOShipmentCnt1;
                // BO�o�ɐ�2
                uoeOrderDtlWork.BOShipmentCnt2 = supplierSendErResultWork.BOShipmentCnt2;
                // BO�o�ɐ�3
                uoeOrderDtlWork.BOShipmentCnt3 = supplierSendErResultWork.BOShipmentCnt3;
                // ���[�J�[�t�H���[��
                uoeOrderDtlWork.MakerFollowCnt = supplierSendErResultWork.MakerFollowCnt;
                // ���o�ɐ�
                uoeOrderDtlWork.NonShipmentCnt = supplierSendErResultWork.NonShipmentCnt;
                // UOE���_�݌ɐ�
                uoeOrderDtlWork.UOESectStockCnt = supplierSendErResultWork.UOESectStockCnt;
                // BO�݌ɐ�1
                uoeOrderDtlWork.BOStockCount1 = supplierSendErResultWork.BOStockCount1;
                // BO�݌ɐ�2
                uoeOrderDtlWork.BOStockCount2 = supplierSendErResultWork.BOStockCount2;
                // BO�݌ɐ�3
                uoeOrderDtlWork.BOStockCount3 = supplierSendErResultWork.BOStockCount3;
                // UOE���_�`�[�ԍ�
                uoeOrderDtlWork.UOESectionSlipNo = supplierSendErResultWork.UOESectionSlipNo;
                // BO�`�[�ԍ��P
                uoeOrderDtlWork.BOSlipNo1 = supplierSendErResultWork.BOSlipNo1;
                // BO�`�[�ԍ��Q
                uoeOrderDtlWork.BOSlipNo2 = supplierSendErResultWork.BOSlipNo2;
                // BO�`�[�ԍ��R
                uoeOrderDtlWork.BOSlipNo3 = supplierSendErResultWork.BOSlipNo3;
                // EO������
                uoeOrderDtlWork.EOAlwcCount = supplierSendErResultWork.EOAlwcCount;
                // BO�Ǘ��ԍ�
                uoeOrderDtlWork.BOManagementNo = supplierSendErResultWork.BOManagementNo;
                // �񓚒艿
                uoeOrderDtlWork.AnswerListPrice = supplierSendErResultWork.AnswerListPrice;
                // �񓚌����P��
                uoeOrderDtlWork.AnswerSalesUnitCost = supplierSendErResultWork.AnswerSalesUnitCost;
                // UOE��փ}�[�N
                uoeOrderDtlWork.UOESubstMark = supplierSendErResultWork.UOESubstMark;
                // UOE�݌Ƀ}�[�N
                uoeOrderDtlWork.UOEStockMark = supplierSendErResultWork.UOEStockMark;
                // �w�ʃR�[�h
                uoeOrderDtlWork.PartsLayerCd = supplierSendErResultWork.PartsLayerCd;
                // UOE�o�׋��_�R�[�h�P�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOEShipSectCd1 = supplierSendErResultWork.MazdaUOEShipSectCd1;
                // UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOEShipSectCd2 = supplierSendErResultWork.MazdaUOEShipSectCd2;
                // UOE�o�׋��_�R�[�h�R�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOEShipSectCd3 = supplierSendErResultWork.MazdaUOEShipSectCd3;
                // UOE���_�R�[�h�P�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOESectCd1 = supplierSendErResultWork.MazdaUOESectCd1;
                // UOE���_�R�[�h�Q�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOESectCd2 = supplierSendErResultWork.MazdaUOESectCd2;
                // UOE���_�R�[�h�R�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOESectCd3 = supplierSendErResultWork.MazdaUOESectCd3;
                // UOE���_�R�[�h�S�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOESectCd4 = supplierSendErResultWork.MazdaUOESectCd4;
                // UOE���_�R�[�h�T�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOESectCd5 = supplierSendErResultWork.MazdaUOESectCd5;
                // UOE���_�R�[�h�U�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOESectCd6 = supplierSendErResultWork.MazdaUOESectCd6;
                // UOE���_�R�[�h�V�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOESectCd7 = supplierSendErResultWork.MazdaUOESectCd7;
                // UOE�݌ɐ��P�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOEStockCnt1 = supplierSendErResultWork.MazdaUOEStockCnt1;
                // UOE�݌ɐ��Q�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOEStockCnt2 = supplierSendErResultWork.MazdaUOEStockCnt2;
                // UOE�݌ɐ��R�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOEStockCnt3 = supplierSendErResultWork.MazdaUOEStockCnt3;
                // UOE�݌ɐ��S�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOEStockCnt4 = supplierSendErResultWork.MazdaUOEStockCnt4;
                // UOE�݌ɐ��T�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOEStockCnt5 = supplierSendErResultWork.MazdaUOEStockCnt5;
                // UOE�݌ɐ��U�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOEStockCnt6 = supplierSendErResultWork.MazdaUOEStockCnt6;
                // UOE�݌ɐ��V�i�}�c�_�j
                uoeOrderDtlWork.MazdaUOEStockCnt7 = supplierSendErResultWork.MazdaUOEStockCnt7;
                // UOE���R�[�h
                uoeOrderDtlWork.UOEDistributionCd = supplierSendErResultWork.UOEDistributionCd;
                // UOE���R�[�h
                uoeOrderDtlWork.UOEOtherCd = supplierSendErResultWork.UOEOtherCd;
                // UOE�g�l�R�[�h
                uoeOrderDtlWork.UOEHMCd = supplierSendErResultWork.UOEHMCd;
                // �a�n��
                uoeOrderDtlWork.BOCount = supplierSendErResultWork.BOCount;
                // UOE�}�[�N�R�[�h
                uoeOrderDtlWork.UOEMarkCode = supplierSendErResultWork.UOEMarkCode;
                // �o�׌�
                uoeOrderDtlWork.SourceShipment = supplierSendErResultWork.SourceShipment;
                // �A�C�e���R�[�h
                uoeOrderDtlWork.ItemCode = supplierSendErResultWork.ItemCode;
                // UOE�`�F�b�N�R�[�h
                uoeOrderDtlWork.UOECheckCode = supplierSendErResultWork.UOECheckCode;
                // �w�b�h�G���[���b�Z�[�W
                uoeOrderDtlWork.HeadErrorMassage = supplierSendErResultWork.HeadErrorMassage;
                // ���C���G���[���b�Z�[�W
                uoeOrderDtlWork.LineErrorMassage = supplierSendErResultWork.LineErrorMassage;
                // �f�[�^���M�敪
                uoeOrderDtlWork.DataSendCode = 4;�@ // 4:�ُ�I��
                // �f�[�^�����敪
                uoeOrderDtlWork.DataRecoverDiv = 1; // 1:������
                // ���ɍX�V�敪�i���_�j
                uoeOrderDtlWork.EnterUpdDivSec = supplierSendErResultWork.EnterUpdDivSec;
                // ���ɍX�V�敪�iBO1�j
                uoeOrderDtlWork.EnterUpdDivBO1 = supplierSendErResultWork.EnterUpdDivBO1;
                // ���ɍX�V�敪�iBO2�j
                uoeOrderDtlWork.EnterUpdDivBO2 = supplierSendErResultWork.EnterUpdDivBO2;
                // ���ɍX�V�敪�iBO3�j
                uoeOrderDtlWork.EnterUpdDivBO3 = supplierSendErResultWork.EnterUpdDivBO3;
                // ���ɍX�V�敪�iҰ���j
                uoeOrderDtlWork.EnterUpdDivMaker = supplierSendErResultWork.EnterUpdDivMaker;
                // ���ɍX�V�敪�iEO�j
                uoeOrderDtlWork.EnterUpdDivEO = supplierSendErResultWork.EnterUpdDivEO;

                // �X�V�pUOE�����f�[�^���X�g�ɒǉ�
                uoeOrderDtlWorkList.Add(uoeOrderDtlWork);
            }
        }
        #endregion
        #endregion �� UOE�����f�[�^�̍X�V����

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
        /// <br>Date       : 2008.12.10</br>
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
