//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �����ꗗ����(�����)�A�N�Z�X�N���X
// �v���O�����T�v   : �����ꗗ����(�����)�A�N�Z�X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2009/05/25  �C�����e : 96186 ���� �T�� �z���_ UOE WEB�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// �����ꗗ����(�����)�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �����ꗗ����(�����)�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2009/05/25</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2009/05/25 �V�K�쐬</br>
	/// </remarks>
	public partial class UoeSndRcvJnlAcs
	{
		// ===================================================================================== //
		// public���\�b�h
		// ===================================================================================== //
		# region public Methods
        # region �����ꗗ����(�����)�f�[�^�e�[�u��Row�쐬
        /// <summary>
        /// �����ꗗ����(�����)�f�[�^�e�[�u��Row�쐬
        /// </summary>
        /// <param name="orderLstInputDtlList">�����ꗗ����(�����)</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns></returns>
        public int orderLstInputDtlFromDtlWrite(ArrayList list, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                OrderLstInputDtlSchema.SettingDataSet(ref _uoeJnlDataSet, OrderLstInputDtlSchema.CT_OrderLstInputDtlDataTable);

                foreach (OrderLstInputDtl rst in list)
                {
                    DataRow dr = OrderLstInputDtlTable.NewRow();
                    CreateSchemaFromOrderLstInputDtl(ref dr, rst);
                    OrderLstInputDtlTable.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region �����ꗗ����(�����)�f�[�^�e�[�u��Row�쐬
        /// <summary>
        /// �����ꗗ����(�����)�f�[�^�e�[�u��Row�쐬
		/// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="rst">�����ꗗ����(�����)�N���X</param>
        public void CreateSchemaFromOrderLstInputDtl(ref DataRow dr, OrderLstInputDtl rst)
		{
            dr[OrderLstInputDtlSchema.ct_Col_UserName] = rst.UserName;// ���q�l��
            dr[OrderLstInputDtlSchema.ct_Col_UserCode] = rst.UserCode;// ���q�lCD
            dr[OrderLstInputDtlSchema.ct_Col_ItemCode] = rst.ItemCode;// �A�C�e��
            dr[OrderLstInputDtlSchema.ct_Col_OrderDate] = rst.OrderDate;// ������
            dr[OrderLstInputDtlSchema.ct_Col_OrderTime] = rst.OrderTime;// ��������
            dr[OrderLstInputDtlSchema.ct_Col_SlipNoHead] = rst.SlipNoHead;// �`�[�ԍ�(�w�b�_�[��)
            dr[OrderLstInputDtlSchema.ct_Col_Memo] = rst.Memo;// ������
            dr[OrderLstInputDtlSchema.ct_Col_OrderGoodsNo] = rst.OrderGoodsNo;// �������i�ԍ�
            dr[OrderLstInputDtlSchema.ct_Col_ShipmGoodsNo] = rst.ShipmGoodsNo;// �o�ו��i�ԍ�
            dr[OrderLstInputDtlSchema.ct_Col_GoodsName] = rst.GoodsName;// �o�ו��i��
            dr[OrderLstInputDtlSchema.ct_Col_ShipmentCnt] = rst.ShipmentCnt;// ��������
            dr[OrderLstInputDtlSchema.ct_Col_OrderRemCnt] = rst.OrderRemCnt;// �����c����
            dr[OrderLstInputDtlSchema.ct_Col_AnswerListPrice] = rst.AnswerListPrice;// ��]�������i
            dr[OrderLstInputDtlSchema.ct_Col_SourceShipment] = rst.SourceShipment;// �o�׌���
            dr[OrderLstInputDtlSchema.ct_Col_PlanDate] = rst.PlanDate;// ���͗\���
            dr[OrderLstInputDtlSchema.ct_Col_SlipNoDtl] = rst.SlipNoDtl;// �`�[�ԍ�(���ו�)
            dr[OrderLstInputDtlSchema.ct_Col_AnswerSalesUnitCost] = rst.AnswerSalesUnitCost;// �d���ꉿ�i
        }
		# endregion

        # region �����ꗗ����(�����)��DataRow �� �N���X���쐬
        /// <summary>
        /// �����ꗗ����(�����)��DataRow �� �N���X���쐬
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="rst"></param>
        public OrderLstInputDtl CreateOrderLstInputDtlFromSchema(DataRow dr)
		{
            OrderLstInputDtl rst = new OrderLstInputDtl();

            rst.UserName = (String)dr[OrderLstInputDtlSchema.ct_Col_UserName];// ���q�l��
            rst.UserCode = (String)dr[OrderLstInputDtlSchema.ct_Col_UserCode];// ���q�lCD
            rst.ItemCode = (String)dr[OrderLstInputDtlSchema.ct_Col_ItemCode];// �A�C�e��
            rst.OrderDate = (DateTime)dr[OrderLstInputDtlSchema.ct_Col_OrderDate];// ������
            rst.OrderTime = (Int32)dr[OrderLstInputDtlSchema.ct_Col_OrderTime];// ��������
            rst.SlipNoHead = (String)dr[OrderLstInputDtlSchema.ct_Col_SlipNoHead];// �`�[�ԍ�(�w�b�_�[��)
            rst.Memo = (String)dr[OrderLstInputDtlSchema.ct_Col_Memo];// ������
            rst.OrderGoodsNo = (String)dr[OrderLstInputDtlSchema.ct_Col_OrderGoodsNo];// �������i�ԍ�
            rst.ShipmGoodsNo = (String)dr[OrderLstInputDtlSchema.ct_Col_ShipmGoodsNo];// �o�ו��i�ԍ�
            rst.GoodsName = (String)dr[OrderLstInputDtlSchema.ct_Col_GoodsName];// �o�ו��i��
            rst.ShipmentCnt = (Double)dr[OrderLstInputDtlSchema.ct_Col_ShipmentCnt];// ��������
            rst.OrderRemCnt = (Double)dr[OrderLstInputDtlSchema.ct_Col_OrderRemCnt];// �����c����
            rst.AnswerListPrice = (Double)dr[OrderLstInputDtlSchema.ct_Col_AnswerListPrice];// ��]�������i
            rst.SourceShipment = (String)dr[OrderLstInputDtlSchema.ct_Col_SourceShipment];// �o�׌���
            rst.PlanDate = (DateTime)dr[OrderLstInputDtlSchema.ct_Col_PlanDate];// ���͗\���
            rst.SlipNoDtl = (String)dr[OrderLstInputDtlSchema.ct_Col_SlipNoDtl];// �`�[�ԍ�(���ו�)
            rst.AnswerSalesUnitCost = (Double)dr[OrderLstInputDtlSchema.ct_Col_AnswerSalesUnitCost];// �d���ꉿ�i

			return (rst);
		}
		# endregion

        # region �����ꗗ����(�����)�Ώۃf�[�^�̒��o
        /// <summary>
        /// �����ꗗ����(�����)�Ώۃf�[�^�̒��o
        /// </summary>
        /// <param name="StockDate">�d�����t</param>
        /// <param name="PartySaleSlipNum">�����`�[�ԍ�</param>
        /// <returns>DataView</returns>
        public DataView GetOrderLstInputFormCreateView(DateTime stockDate, string partySaleSlipNum)
        {
            DataView view = new DataView(this.OrderLstInputDtlTable);

            //string rowFilterText = string.Format("{0} = {1}",
            string rowFilterText = string.Format("{0} = '{1}' AND {2} = '{3}'",
                                            OrderLstInputDtlSchema.ct_Col_PlanDate, stockDate,
                                            OrderLstInputDtlSchema.ct_Col_SlipNoDtl, partySaleSlipNum
                                            );


            // �\�[�g���ݒ�
            string sortText = string.Format("{0}",
                                            OrderLstInputDtlSchema.ct_Col_OrderGoodsNo
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }

        # endregion

        # endregion
    }
}
