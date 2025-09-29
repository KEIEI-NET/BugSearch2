using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �����d���񓚏��e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����d���񓚏��e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : �a�J ���</br>
    /// <br>Date       : 2008/12/16</br>
    /// <br>Update Note: 2011/08/10 caohh �A��736</br>
    /// <br>           : NS���[�U�[���Ǘv�]�ꗗ�A��736�̑Ή�</br>
    /// </remarks>
    public class PMUOE01352EA
    {
        #region ��Public�萔
        /// <summary> �e�[�u������(���גP��) </summary>
        public const string ct_Tbl_OrderAnsDetail = "Tbl_OrderAnsDetail";
        /// <summary> ���ׂ̃O���[�v���� </summary>
        public const string ct_Grp_OrderAnsDeltail = "Grp_OrderAnsDetail";

        // ���׏��(�O���b�h�p)
        /// <summary> UOE�����s�ԍ� </summary>
        public const string ct_Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";
        /// <summary> ��M���t </summary>
        public const string ct_Col_ReceiveDate = "ReceiveDate";
        // ------ ADD 2011/08/10 ------>>>>>
        /// <summary> ��M���t </summary>
        /// <remarks> YY/MM/DD</remarks>
        public const string ct_Col_ReceiveDateYMD = "ReceiveDateYmd";
        /// <summary> ��M���� </summary>
        public const string ct_Col_ReceiveTime = "ReceiveTime";
        // ------ ADD 2011/08/10 ------<<<<<
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> UOE�[�i�敪 </summary>
        public const string ct_Col_DeliGoodsDiv = "DeliGoodsDiv";
        /// <summary> �[�i�敪���� </summary>
        public const string ct_Col_DeliveredGoodsDivNm = "DeliveredGoodsDivNm";
        /// <summary> �񓚕i�� </summary>
        public const string ct_Col_AnswerpartsName = "AnswerpartsName";
        /// <summary> �񓚌����P�� </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        /// <summary> UOE���_�`�[�ԍ� </summary>
        public const string ct_Col_UOESectionSlipNo = "UOESectionSlipNo";
        /// <summary> UOE�`�F�b�N�R�[�h </summary>
        public const string ct_Col_UOECheckCode = "UOECheckCode";
        /// <summary> UOE���}�[�N1 </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        /// <summary> UOE�����ԍ� </summary>
        public const string ct_Col_UOESalesOrderNo = "UOESalesOrderNo";
        /// <summary> �񓚕i�� </summary>
        public const string ct_Col_AnswerpartsNo = "AnswerpartsNo";
        /// <summary> �󒍐��� </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> ���[�J�[���� </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> �񓚒艿 </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> UOE���_�o�ɐ� </summary>
        public const string ct_Col_UOESectOutGoodsCnt = "UOESectOutGoodsCnt";
        /// <summary> ���o�ɐ� </summary>
        public const string ct_Col_NonShipmentCnt = "NonShipmentCnt";
        /// <summary> ���C���G���[���b�Z�[�W </summary>
        public const string ct_Col_LineErrorMessage = "LineErrorMessage";
        /// <summary> �O�i�F </summary>
        public const string ct_Col_ForeColor = "ForeColor";

        #endregion

        #region �� Constructor
        /// <summary>
        /// �����d���񓚃O���b�h�p�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����d���񓚏��e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : �a�J ���</br>
        /// <br>Date       : 2008/12/16</br>
        /// </remarks>
        public PMUOE01352EA()
        {
        }
        #endregion

        #region �� Public���\�b�h
        /// <summary>
        /// DataSet�e�[�u���X�L�[�}�ݒ�(���גP��)
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : �a�J ���</br>
        /// <br>Date       : 2008/12/16</br>
        /// </remarks>
        static public void CreateDataTableDetail(ref DataTable dt)
        {
            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (dt != null)
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[�̂ݍs���B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                dt.Clear();
                return;
            }

            dt = new DataTable(ct_Tbl_OrderAnsDetail);

            string defaultValueOfstring = string.Empty;
            Int32 defaultValueOfInt32 = 0;
            Double defaultValueOfDouble = 0.0;

            // ��M���t
            dt.Columns.Add(ct_Col_ReceiveDate, typeof(string));
            dt.Columns[ct_Col_ReceiveDate].DefaultValue = defaultValueOfstring;
            // ------ ADD 2011/08/10 ------>>>>>
            // ��M���t(YY/MM/DD)
            dt.Columns.Add(ct_Col_ReceiveDateYMD, typeof(string));
            dt.Columns[ct_Col_ReceiveDateYMD].DefaultValue = defaultValueOfstring;
            // ��M����
            dt.Columns.Add(ct_Col_ReceiveTime, typeof(string));
            dt.Columns[ct_Col_ReceiveTime].DefaultValue = defaultValueOfstring;
            // �[�i�敪����
            dt.Columns.Add(ct_Col_DeliveredGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_DeliveredGoodsDivNm].DefaultValue = defaultValueOfstring;
            // ���[�J�[�R�[�h
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfstring;
            // ------ ADD 2011/08/10 ------<<<<<
            // �i��
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;
            // UOE�[�i�敪
            dt.Columns.Add(ct_Col_DeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_DeliGoodsDiv].DefaultValue = defaultValueOfstring;
            // �񓚕i��
            dt.Columns.Add(ct_Col_AnswerpartsName, typeof(string));
            dt.Columns[ct_Col_AnswerpartsName].DefaultValue = defaultValueOfstring;
            // �񓚌����P��
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defaultValueOfDouble;
            // UOE���_�`�[�ԍ�
            dt.Columns.Add(ct_Col_UOESectionSlipNo, typeof(string));
            dt.Columns[ct_Col_UOESectionSlipNo].DefaultValue = defaultValueOfstring;
            // UOE�`�F�b�N�R�[�h
            dt.Columns.Add(ct_Col_UOECheckCode, typeof(string));
            dt.Columns[ct_Col_UOECheckCode].DefaultValue = defaultValueOfstring;
            // UOE���}�[�N1
            dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
            dt.Columns[ct_Col_UoeRemark1].DefaultValue = defaultValueOfstring;
            // UOE�����ԍ�
            dt.Columns.Add(ct_Col_UOESalesOrderNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderNo].DefaultValue = defaultValueOfInt32;
            // UOE�����s�ԍ�
            dt.Columns.Add(ct_Col_UOESalesOrderRowNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderRowNo].DefaultValue = defaultValueOfInt32;
            // �񓚕i��
            dt.Columns.Add(ct_Col_AnswerpartsNo, typeof(string));
            dt.Columns[ct_Col_AnswerpartsNo].DefaultValue = defaultValueOfstring;
            // �󒍐���
            dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(Double));
            dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defaultValueOfDouble;
            // ���[�J�[����
            dt.Columns.Add(ct_Col_MakerName, typeof(string));
            dt.Columns[ct_Col_MakerName].DefaultValue = defaultValueOfstring;
            // �񓚒艿
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Double));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defaultValueOfDouble;
            // UOE���_�o�ɐ�
            dt.Columns.Add(ct_Col_UOESectOutGoodsCnt, typeof(Int32));
            dt.Columns[ct_Col_UOESectOutGoodsCnt].DefaultValue = defaultValueOfInt32;
            // ���o�ɐ�
            dt.Columns.Add(ct_Col_NonShipmentCnt, typeof(Int32));
            dt.Columns[ct_Col_NonShipmentCnt].DefaultValue = defaultValueOfInt32;
            // ���C���G���[���b�Z�[�W
            dt.Columns.Add(ct_Col_LineErrorMessage, typeof(string));
            dt.Columns[ct_Col_LineErrorMessage].DefaultValue = defaultValueOfstring;
        }
        #endregion
    }
}
