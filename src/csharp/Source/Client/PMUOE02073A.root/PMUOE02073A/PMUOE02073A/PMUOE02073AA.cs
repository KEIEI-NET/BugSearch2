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
    /// �d����ϯ�ؽăA�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����ϯ�ؽĂŎg�p����f�[�^���擾����B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2008.12.17</br>
    /// <br></br>
    /// </remarks>
    public class SupplierUnmAcs
    {
        #region �� Constructor
		/// <summary>
        /// �d����ϯ�ؽăA�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �d����ϯ�ؽăA�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : 30413 ����</br>
	    /// <br>Date       : 2008.12.17</br>
		/// </remarks>
		public SupplierUnmAcs()
		{
            this._iSupplierUnmOrderWorkDB = (ISupplierUnmOrderWorkDB)MediationSupplierUnmOrderWorkDB.GetSupplierUnmOrderWorkDB();
		}

		/// <summary>
        /// �d����ϯ�ؽĕ\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �d����ϯ�ؽĕ\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.17</br>
        /// </remarks>
        static SupplierUnmAcs()
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
        ISupplierUnmOrderWorkDB _iSupplierUnmOrderWorkDB;         // �d����ϯ�ؽă����[�g

        private DataSet _supplierUnmDs;				        // �d����ϯ�ؽăf�[�^�Z�b�g
        
        #endregion �� Private Member

        #region �� Private Const
        private const string ct_Contents_UOE_BO = "�`�[�ԍ����ݒ�";
        private const string ct_Contents_Maker = "�`�[�ԍ����ݒ�(Ұ��̫۰)";
        private const string ct_Contents_EO = "�`�[�ԍ����ݒ�(EO)";
        #endregion �� Private Const

        #region �� Public Property
        /// <summary>
        /// �d����ϯ�ؽăf�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet SupplierUnmDs
        {
            get { return this._supplierUnmDs; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� �o�̓f�[�^�擾
        #region �� �����f�[�^�擾
        /// <summary>
        /// �d����ϯ�ؽăf�[�^�擾
        /// </summary>
        /// <param name="enterSchOrderCndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������d����ϯ�ؽăf�[�^���擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.17</br>
        /// </remarks>
        public int SearchSupplierUnm(SupplierUnmOrderCndtn supplierUnmOrderCndtn, out string errMsg)
        {
            return this.SearchSupplierUnmProc(supplierUnmOrderCndtn, out errMsg);
        }
        #endregion
        #endregion �� �o�̓f�[�^�擾
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� �d����ϯ�ؽăf�[�^�擾
        /// <summary>
        /// �d����ϯ�ؽăf�[�^�擾
        /// </summary>
        /// <param name="supplierUnmOrderCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������d����ϯ�ؽăf�[�^���擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.17</br>
        /// </remarks>
        private int SearchSupplierUnmProc(SupplierUnmOrderCndtn supplierUnmOrderCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                SupplierUnmResult.CreateDataTableResultSupplierUnm(ref this._supplierUnmDs);
                SupplierUnmOrderCndtnWork supplierUnmOrderCndtnWork = new SupplierUnmOrderCndtnWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevSupplierUnm(supplierUnmOrderCndtn, out supplierUnmOrderCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                status = this._iSupplierUnmOrderWorkDB.Search(out retList, (object)supplierUnmOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevSupplierUnmData(supplierUnmOrderCndtn, this._supplierUnmDs.Tables[SupplierUnmResult.Col_Tbl_Result_SupplierUnm], (ArrayList)retList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�d����ϯ�ؽăf�[�^�̎擾�Ɏ��s���܂����B";
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
        /// <param name="supplierUnmOrderCndtn">UI���o�����N���X</param>
        /// <param name="supplierUnmOrderCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevSupplierUnm(SupplierUnmOrderCndtn supplierUnmOrderCndtn, out SupplierUnmOrderCndtnWork supplierUnmOrderCndtnWork, out string errMsg)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            supplierUnmOrderCndtnWork = new SupplierUnmOrderCndtnWork();

            try
            {
                // ��ƃR�[�h
                supplierUnmOrderCndtnWork.EnterpriseCode = supplierUnmOrderCndtn.EnterpriseCode;

                // ���o�����p�����[�^�Z�b�g
                if (supplierUnmOrderCndtn.SectionCodes.Length != 0)
                {
                    if (supplierUnmOrderCndtn.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        supplierUnmOrderCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        supplierUnmOrderCndtnWork.SectionCodes = supplierUnmOrderCndtn.SectionCodes;
                    }
                }
                else
                {
                    supplierUnmOrderCndtnWork.SectionCodes = null;
                }


                supplierUnmOrderCndtnWork.St_SupplierCd = supplierUnmOrderCndtn.St_SupplierCd;              // �J�n�d����R�[�h
                supplierUnmOrderCndtnWork.Ed_SupplierCd = supplierUnmOrderCndtn.Ed_SupplierCd;              // �I���d����R�[�h
                
                supplierUnmOrderCndtnWork.St_ReceiveDate = supplierUnmOrderCndtn.St_ReceiveDate;	        // �J�n��M���t
                supplierUnmOrderCndtnWork.Ed_ReceiveDate = supplierUnmOrderCndtn.Ed_ReceiveDate;	        // �I����M���t
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region �� �d����ϯ�ؽăf�[�^�W�J����
        /// <summary>
        /// �d����ϯ�ؽăf�[�^�W�J����
        /// </summary>
        /// <param name="supplierUnmOrderCndtn">UI���o�����N���X</param>
        /// <param name="supplierUnmDt">�W�J�Ώ�DataTable</param>
        /// <param name="supplierUnmResultWorkList">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �d����ϯ�ؽăf�[�^��W�J����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.17</br>
        /// </remarks>
        private void DevSupplierUnmData(SupplierUnmOrderCndtn supplierUnmOrderCndtn, DataTable supplierUnmDt, ArrayList supplierUnmResultWorkList)
        {
            foreach (SupplierUnmResultWork supplierUnmResultWork in supplierUnmResultWorkList)
            {
                // 2009.02.18 30413 ���� �`�[�ԍ����󔒂̏ꍇ�Ɉ󎚂���悤�ɏC�� >>>>>>START
                //if (supplierUnmResultWork.UOESectOutGoodsCnt != 0)
                if ((supplierUnmResultWork.UOESectOutGoodsCnt != 0) && (string.IsNullOrEmpty(supplierUnmResultWork.UOESectionSlipNo)))
                {
                    // UOE���_�o�ɐ�
                    DataSetSupplierUnm(supplierUnmDt, supplierUnmResultWork, 0);
                }
                //if (supplierUnmResultWork.BOShipmentCnt1 != 0)
                if ((supplierUnmResultWork.BOShipmentCnt1 != 0) && (string.IsNullOrEmpty(supplierUnmResultWork.BOSlipNo1)))
                {
                    // BO�o�ɐ�1
                    DataSetSupplierUnm(supplierUnmDt, supplierUnmResultWork, 1);
                }
                //if (supplierUnmResultWork.BOShipmentCnt2 != 0)
                if ((supplierUnmResultWork.BOShipmentCnt2 != 0) && (string.IsNullOrEmpty(supplierUnmResultWork.BOSlipNo2)))
                {
                    // BO�o�ɐ�2
                    DataSetSupplierUnm(supplierUnmDt, supplierUnmResultWork, 2);
                }
                //if (supplierUnmResultWork.BOShipmentCnt3 != 0)
                if ((supplierUnmResultWork.BOShipmentCnt3 != 0) && (string.IsNullOrEmpty(supplierUnmResultWork.BOSlipNo3)))
                {
                    // BO�o�ɐ�3
                    DataSetSupplierUnm(supplierUnmDt, supplierUnmResultWork, 3);
                }
                // 2009.02.18 30413 ���� �`�[�ԍ����󔒂̏ꍇ�Ɉ󎚂���悤�ɏC�� <<<<<<END
                if (supplierUnmResultWork.MakerFollowCnt != 0)
                {
                    // ���[�J�[�t�H���[��
                    DataSetSupplierUnm(supplierUnmDt, supplierUnmResultWork, 4);
                }
                if (supplierUnmResultWork.EOAlwcCount != 0)
                {
                    // EO������
                    DataSetSupplierUnm(supplierUnmDt, supplierUnmResultWork, 5);
                }
            }
        }
        #endregion


        /// <summary>
        /// �擾�f�[�^�ݒ菈��
        /// </summary>
        /// <param name="supplierUnmDt">�W�J�Ώ�DataTable</param>
        /// <param name="supplierUnmResultWork">�擾�f�[�^</param>
        /// <param name="addFlg">�f�[�^�ݒ�t���O</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��ݒ肷��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.17</br>
        /// </remarks>
        private void DataSetSupplierUnm(DataTable supplierUnmDt, SupplierUnmResultWork supplierUnmResultWork, int addFlg)
        {
            DataRow dr;

            dr = supplierUnmDt.NewRow();

            // �d����ϯ�ؽăf�[�^�W�J
            #region �d����ϯ�ؽăf�[�^�W�J
            // ���_�R�[�h
            dr[SupplierUnmResult.Col_SectionCode] = supplierUnmResultWork.SectionCode;
            // ���_�K�C�h����
            dr[SupplierUnmResult.Col_SectionGuideSnm] = supplierUnmResultWork.SectionGuideSnm;
            // �d����R�[�h
            dr[SupplierUnmResult.Col_SupplierCd] = supplierUnmResultWork.SupplierCd;
            // �d���旪��
            dr[SupplierUnmResult.Col_SupplierSnm] = supplierUnmResultWork.SupplierSnm;            
            // ������t(�󒍓��t)
            dr[SupplierUnmResult.Col_SalesDate] = supplierUnmResultWork.SalesDate;
            // ���i�ԍ�
            dr[SupplierUnmResult.Col_GoodsNo] = supplierUnmResultWork.GoodsNo;
            // ���i����
            dr[SupplierUnmResult.Col_GoodsName] = supplierUnmResultWork.GoodsName;
            // �󒍐���
            dr[SupplierUnmResult.Col_AcceptAnOrderCnt] = supplierUnmResultWork.AcceptAnOrderCnt;
            // BO�敪
            dr[SupplierUnmResult.Col_BoCode] = supplierUnmResultWork.BoCode;
            // �񓚒艿
            dr[SupplierUnmResult.Col_AnswerListPrice] = supplierUnmResultWork.AnswerListPrice;
            // �񓚌����P��
            dr[SupplierUnmResult.Col_AnswerSalesUnitCost] = supplierUnmResultWork.AnswerSalesUnitCost;
            // UOE�����ԍ�
            dr[SupplierUnmResult.Col_UOESalesOrderNo] = supplierUnmResultWork.UOESalesOrderNo;
            // �V�X�e���敪
            dr[SupplierUnmResult.Col_SystemDivCd] = supplierUnmResultWork.SystemDivCd;
            // UOE���_�o�ɐ�
            dr[SupplierUnmResult.Col_UOESectOutGoodsCnt] = supplierUnmResultWork.UOESectOutGoodsCnt;
            // BO�o�ɐ�1
            dr[SupplierUnmResult.Col_BOShipmentCnt1] = supplierUnmResultWork.BOShipmentCnt1;
            // BO�o�ɐ�2
            dr[SupplierUnmResult.Col_BOShipmentCnt2] = supplierUnmResultWork.BOShipmentCnt2;
            // BO�o�ɐ�3
            dr[SupplierUnmResult.Col_BOShipmentCnt3] = supplierUnmResultWork.BOShipmentCnt3;
            // ���[�J�[�t�H���[��
            dr[SupplierUnmResult.Col_MakerFollowCnt] = supplierUnmResultWork.MakerFollowCnt;
            // UOE���_�`�[�ԍ�
            dr[SupplierUnmResult.Col_UOESectionSlipNo] = supplierUnmResultWork.UOESectionSlipNo;
            // BO�`�[�ԍ��P
            dr[SupplierUnmResult.Col_BOSlipNo1] = supplierUnmResultWork.BOSlipNo1;
            // BO�`�[�ԍ��Q
            dr[SupplierUnmResult.Col_BOSlipNo2] = supplierUnmResultWork.BOSlipNo2;
            // BO�`�[�ԍ��R
            dr[SupplierUnmResult.Col_BOSlipNo3] = supplierUnmResultWork.BOSlipNo3;
            // EO������
            dr[SupplierUnmResult.Col_EOAlwcCount] = supplierUnmResultWork.EOAlwcCount;
            
            // ����p
            // ������t(�󒍓��t)(����p)
            dr[SupplierUnmResult.Col_SalesDate_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", supplierUnmResultWork.SalesDate);            
            // �V�X�e���敪(����p)
            switch (supplierUnmResultWork.SystemDivCd)
            {
                case 0:
                    {
                        dr[SupplierUnmResult.Col_SystemDivCd_Print] = "�����";
                        break;
                    }
                case 1:
                    {
                        dr[SupplierUnmResult.Col_SystemDivCd_Print] = "�`��";
                        break;
                    }
                case 2:
                    {
                        dr[SupplierUnmResult.Col_SystemDivCd_Print] = "����";
                        break;
                    }
                default:
                    {
                        // ���̑�
                        dr[SupplierUnmResult.Col_SystemDivCd_Print] = "";
                        break;
                    }
            }

            if (addFlg == 0)
            {
                // UOE���_�o�ɐ�
                // ����
                dr[SupplierUnmResult.Col_QTY] = supplierUnmResultWork.UOESectOutGoodsCnt;
                // ���e
                dr[SupplierUnmResult.Col_Contents] = ct_Contents_UOE_BO;
            }
            else if (addFlg == 1)
            {
                // BO�o�ɐ�1
                // ����
                dr[SupplierUnmResult.Col_QTY] = supplierUnmResultWork.BOShipmentCnt1;
                // ���e
                dr[SupplierUnmResult.Col_Contents] = ct_Contents_UOE_BO;
            }
            else if (addFlg == 2)
            {
                // BO�o�ɐ�2
                // ����
                dr[SupplierUnmResult.Col_QTY] = supplierUnmResultWork.BOShipmentCnt2;
                // ���e
                dr[SupplierUnmResult.Col_Contents] = ct_Contents_UOE_BO;
            }
            else if (addFlg == 3)
            {
                // BO�o�ɐ�3
                // ����
                dr[SupplierUnmResult.Col_QTY] = supplierUnmResultWork.BOShipmentCnt3;
                // ���e
                dr[SupplierUnmResult.Col_Contents] = ct_Contents_UOE_BO;
            }
            else if (addFlg == 4)
            {
                // Ұ��̫۰��
                // ����
                dr[SupplierUnmResult.Col_QTY] = supplierUnmResultWork.MakerFollowCnt;
                // ���e
                dr[SupplierUnmResult.Col_Contents] = ct_Contents_Maker;
            }
            else
            {
                // EO������
                // ����
                dr[SupplierUnmResult.Col_QTY] = supplierUnmResultWork.EOAlwcCount;
                // ���e
                dr[SupplierUnmResult.Col_Contents] = ct_Contents_EO;
            }

            // Table��Add
            supplierUnmDt.Rows.Add(dr);
        }

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
        /// <br>Date       : 2008.12.17</br>
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
