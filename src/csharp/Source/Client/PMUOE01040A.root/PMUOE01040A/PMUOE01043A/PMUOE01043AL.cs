//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ����ꗗ���׃A�N�Z�X�N���X
// �v���O�����T�v   : ����ꗗ���׃A�N�Z�X���s��
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
    /// ����ꗗ���׃A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ����ꗗ���׃A�N�Z�X�N���X</br>
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
        # region ����ꗗ���׃f�[�^�e�[�u��Row�쐬
        /// <summary>
        /// ����ꗗ���׃f�[�^�e�[�u��Row�쐬
        /// </summary>
        /// <param name="orderLstInputDtlList">����ꗗ����(�����)</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns></returns>
        public int buyOutLstDtlFromDtlWrite(ArrayList list, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                BuyOutLstDtlSchema.SettingDataSet(ref _uoeJnlDataSet, BuyOutLstDtlSchema.CT_BuyOutLstDtlDataTable);

                foreach (BuyOutLstDtl rst in list)
                {
                    DataRow dr = BuyOutLstDtlTable.NewRow();
                    CreateSchemaFromBuyOutLstDtl(ref dr, rst);
                    BuyOutLstDtlTable.Rows.Add(dr);
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

        # region ����ꗗ���׃f�[�^�e�[�u��Row�쐬
        /// <summary>
        /// ����ꗗ���׃f�[�^�e�[�u��Row�쐬
		/// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="rst">����ꗗ����(�����)�N���X</param>
        public void CreateSchemaFromBuyOutLstDtl(ref DataRow dr, BuyOutLstDtl rst)
		{
            dr[BuyOutLstDtlSchema.ct_Col_No] = rst.No;// �ʔ�
            dr[BuyOutLstDtlSchema.ct_Col_OrderDate] = rst.OrderDate;// ��������
            dr[BuyOutLstDtlSchema.ct_Col_BuyOutDate] = rst.BuyOutDate;// �������
            dr[BuyOutLstDtlSchema.ct_Col_GoodsNo] = rst.GoodsNo;// ����
            dr[BuyOutLstDtlSchema.ct_Col_GoodsName] = rst.GoodsName;// �i��
            dr[BuyOutLstDtlSchema.ct_Col_ShipmentCnt] = rst.ShipmentCnt;// ����
            dr[BuyOutLstDtlSchema.ct_Col_AnswerListPrice] = rst.AnswerListPrice;// ��]�������i
            dr[BuyOutLstDtlSchema.ct_Col_BuyOutCost] = rst.BuyOutCost;// ������P��
            dr[BuyOutLstDtlSchema.ct_Col_BuyOutTotalCost] = rst.BuyOutTotalCost;// ������z���v
            dr[BuyOutLstDtlSchema.ct_Col_BuyOutSlipNo] = rst.BuyOutSlipNo;// �`�[�ԍ�
            dr[BuyOutLstDtlSchema.ct_Col_OrderSlipNo] = rst.OrderSlipNo;// �������`�[�ԍ�
            dr[BuyOutLstDtlSchema.ct_Col_Comment] = rst.Comment;// �R�����g(���L����)
            dr[BuyOutLstDtlSchema.ct_Col_OrderCost] = rst.OrderCost;// �������P��
            dr[BuyOutLstDtlSchema.ct_Col_UpdRsl] = rst.UpdRsl;// �X�V����
        }
		# endregion

        # region ����ꗗ���ׁ�DataRow �� �N���X���쐬
        /// <summary>
        /// ����ꗗ���ׁ�DataRow �� �N���X���쐬
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="rst"></param>
        public BuyOutLstDtl CreateBuyOutLstDtlFromSchema(DataRow dr)
		{
            BuyOutLstDtl rst = new BuyOutLstDtl();

            rst.No = (Int32)dr[BuyOutLstDtlSchema.ct_Col_No];// �ʔ�
            rst.OrderDate = (DateTime)dr[BuyOutLstDtlSchema.ct_Col_OrderDate];// ��������
            rst.BuyOutDate = (DateTime)dr[BuyOutLstDtlSchema.ct_Col_BuyOutDate];// �������
            rst.GoodsNo = (String)dr[BuyOutLstDtlSchema.ct_Col_GoodsNo];// ����
            rst.GoodsName = (String)dr[BuyOutLstDtlSchema.ct_Col_GoodsName];// �i��
            rst.ShipmentCnt = (Double)dr[BuyOutLstDtlSchema.ct_Col_ShipmentCnt];// ����
            rst.AnswerListPrice = (Double)dr[BuyOutLstDtlSchema.ct_Col_AnswerListPrice];// ��]�������i
            rst.BuyOutCost = (Double)dr[BuyOutLstDtlSchema.ct_Col_BuyOutCost];// ������P��
            rst.BuyOutTotalCost = (Double)dr[BuyOutLstDtlSchema.ct_Col_BuyOutTotalCost];// ������z���v
            rst.BuyOutSlipNo = (String)dr[BuyOutLstDtlSchema.ct_Col_BuyOutSlipNo];// �`�[�ԍ�
            rst.OrderSlipNo = (String)dr[BuyOutLstDtlSchema.ct_Col_OrderSlipNo];// �������`�[�ԍ�
            rst.Comment = (String)dr[BuyOutLstDtlSchema.ct_Col_Comment];// �R�����g(���L����)
            rst.OrderCost = (Double)dr[BuyOutLstDtlSchema.ct_Col_OrderCost];// �������P��
            rst.UpdRsl = (Int32)dr[BuyOutLstDtlSchema.ct_Col_UpdRsl];// �X�V����
			return (rst);
		}
		# endregion

        # region ���㖾�בΏۃf�[�^�̒��o
        /// <summary>
        /// ���㖾�בΏۃf�[�^�̒��o
        /// </summary>
        /// <param name="mode">0:�����㎞�`�[�ԍ��� 1:���������`�[�ԍ���</param>
        /// <param name="PartySaleSlipNum">�����`�[�ԍ�</param>
        /// <returns>DataView</returns>
        public DataView GetBuyOutLstDtlFormCreateView(int mode, string partySaleSlipNum)
        {
            DataView view = new DataView(this.BuyOutLstDtlTable);

            string rowFilterText = String.Empty;

            //�����㎞�`�[�ԍ���
            if (mode == 0)
            {
                rowFilterText = string.Format("{0} = {1}",
                                                BuyOutLstDtlSchema.ct_Col_BuyOutSlipNo, partySaleSlipNum
                                                );
            }
            //���������`�[�ԍ���
            else
            {
                rowFilterText = string.Format("{0} = {1}",
                                                BuyOutLstDtlSchema.ct_Col_OrderSlipNo, partySaleSlipNum
                                                );
            }


            // �\�[�g���ݒ�
            string sortText = string.Format("{0}",
                                            BuyOutLstDtlSchema.ct_Col_No
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }
        
        /// <summary>
        /// ���㖾�בΏۃf�[�^�̒��o
        /// </summary>
        /// <param name="PartySaleSlipNum">�����`�[�ԍ�</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="shipmentCnt">����</param>
        /// <param name="updRsl">�X�V����</param>
        /// <returns>DataView</returns>
        public DataView GetBuyOutLstDtlFormCreateView(string partySaleSlipNum, string goodsNo, double shipmentCnt, Int32 updRsl)
        {
            DataView view = new DataView(this.BuyOutLstDtlTable);

            string rowFilterText = String.Empty;

            //���������E�������`�[�ԍ��E�i�ԁE���ʁ�
            rowFilterText = string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = {5} AND {6} = {7}",
                                                BuyOutLstDtlSchema.ct_Col_OrderSlipNo, partySaleSlipNum,
                                                BuyOutLstDtlSchema.ct_Col_GoodsNo, goodsNo,
                                                BuyOutLstDtlSchema.ct_Col_ShipmentCnt, shipmentCnt,
                                                BuyOutLstDtlSchema.ct_Col_UpdRsl, updRsl
                                            );


            // �\�[�g���ݒ�
            string sortText = string.Format("{0}",
                                            BuyOutLstDtlSchema.ct_Col_No
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }

        /// <summary>
        /// ���㖾�בΏۃf�[�^�̒��o
        /// </summary>
        /// <param name="updRsl">�X�V����</param>
        /// <returns>DataView</returns>
        public DataView GetBuyOutLstDtlFormCreateView(Int32 updRsl)
        {
            DataView view = new DataView(this.BuyOutLstDtlTable);

            string rowFilterText = String.Empty;

            //���������E�������`�[�ԍ��E�i�ԁE���ʁ�
            rowFilterText = string.Format("{0} = {1}",
                                                BuyOutLstDtlSchema.ct_Col_UpdRsl, updRsl
                                            );


            // �\�[�g���ݒ�
            string sortText = string.Format("{0}",
                                            BuyOutLstDtlSchema.ct_Col_No
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }

        /// <summary>
        /// ���㖾�בΏۃf�[�^�̒��o
        /// </summary>
        /// <returns>DataView</returns>
        public DataView GetBuyOutLstDtlFormCreateView()
        {
            DataView view = new DataView(this.BuyOutLstDtlTable);

            string rowFilterText = String.Empty;

            // �\�[�g���ݒ�
            string sortText = string.Format("{0}",
                                            BuyOutLstDtlSchema.ct_Col_No
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }

        # endregion



		# endregion
	}
}
