using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���ω񓚏��e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ω񓚏��e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : �Ɠc �M�u</br>
    /// <br>Date       : 2008/11/10</br>
    /// </remarks>
    public class PMUOE04112EA
    {
        #region ��Public�萔
        /// <summary> �e�[�u������(������P��) </summary>
        public const string ct_Tbl_EstmtAnsSupplier = "Tbl_EstmtAnsSupplier";
        /// <summary> �e�[�u������(���גP��) </summary>
        public const string ct_Tbl_EstmtAnsDetail = "Tbl_EstmtAnsDetail";

        // ������(���׈ȊO)���
        /// <summary> UOE�����於�� </summary>
        public const string ct_Col_UOESupplierName = "UOESupplierName";
        /// <summary> UOE���}�[�N1 </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        /// <summary> UOE���}�[�N2 </summary>
        public const string ct_Col_UoeRemark2 = "UoeRemark2";
        /// <summary> �O���b�h�ύ��ڃw�b�_�[����1 </summary>
        public const string ct_Col_GridHeadVariableName1 = "GridHeadVariableName1";
        /// <summary> �O���b�h�ύ��ڃw�b�_�[����2 </summary>
        public const string ct_Col_GridHeadVariableName2 = "GridHeadVariableName2";
        /// <summary> �O���b�h�ύ��ڃw�b�_�[����3 </summary>
        public const string ct_Col_GridHeadVariableName3 = "GridHeadVariableName3";
        /// <summary> �O���b�h�ύ��ڃw�b�_�[����4 </summary>
        public const string ct_Col_GridHeadVariableName4 = "GridHeadVariableName4";
        /// <summary> �W�����i���v </summary>
        public const string ct_Col_AnswerListPriceTotal = "AnswerListPriceTotal";
        /// <summary> ���P�����v </summary>
        public const string ct_Col_AnswerSalesUnitCostTotal = "AnswerSalesUnitCostTotal";

        // ���׏��(�O���b�h�p)
        /// <summary> UOE�����s�ԍ� </summary>
        public const string ct_Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> ���[�J�[ </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> ���� </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> �W�����i </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> ���P�� </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        /// <summary> �R�����g���� </summary>
        public const string ct_Col_Comment = "Comment";
        /// <summary> �ύ���1 </summary>
        public const string ct_Col_Variable1 = "Variable1";
        /// <summary> �ύ���2 </summary>
        public const string ct_Col_Variable2 = "Variable2";
        /// <summary> �ύ���3 </summary>
        public const string ct_Col_Variable3 = "Variable3";
        /// <summary> �ύ���4 </summary>
        public const string ct_Col_Variable4 = "Variable4";
        #endregion

        #region �� Constructor
        /// <summary>
        /// ���ω񓚃O���b�h�p�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ω񓚏��e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public PMUOE04112EA()
        {
        }
        #endregion

        #region �� Public���\�b�h
        /// <summary>
        /// DataSet�e�[�u���X�L�[�}�ݒ�(������P��)
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        static public void CreateDataTableSupplier(ref DataTable dt)
        {
            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (dt != null)
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[�̂ݍs���B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                dt.Clear();
                return;
            }

            dt = new DataTable(ct_Tbl_EstmtAnsSupplier);

            string defaultValueOfstring = string.Empty;

            // UOE�����於��
            dt.Columns.Add(ct_Col_UOESupplierName, typeof(string));
            dt.Columns[ct_Col_UOESupplierName].DefaultValue = defaultValueOfstring;
            // UOE���}�[�N1
            dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
            dt.Columns[ct_Col_UoeRemark1].DefaultValue = defaultValueOfstring;
            // UOE���}�[�N2
            dt.Columns.Add(ct_Col_UoeRemark2, typeof(string));
            dt.Columns[ct_Col_UoeRemark2].DefaultValue = defaultValueOfstring;
            // �O���b�h�ύ��ڃw�b�_�[����1
            dt.Columns.Add(ct_Col_GridHeadVariableName1, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName1].DefaultValue = defaultValueOfstring;
            // �O���b�h�ύ��ڃw�b�_�[����2
            dt.Columns.Add(ct_Col_GridHeadVariableName2, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName2].DefaultValue = defaultValueOfstring;
            // �O���b�h�ύ��ڃw�b�_�[����3
            dt.Columns.Add(ct_Col_GridHeadVariableName3, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName3].DefaultValue = defaultValueOfstring;
            // �O���b�h�ύ��ڃw�b�_�[����4
            dt.Columns.Add(ct_Col_GridHeadVariableName4, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName4].DefaultValue = defaultValueOfstring;
            // �W�����i���v
            dt.Columns.Add(ct_Col_AnswerListPriceTotal, typeof(string));
            dt.Columns[ct_Col_AnswerListPriceTotal].DefaultValue = defaultValueOfstring;
            // ���P�����v
            dt.Columns.Add(ct_Col_AnswerSalesUnitCostTotal, typeof(string));
            dt.Columns[ct_Col_AnswerSalesUnitCostTotal].DefaultValue = defaultValueOfstring;
        }

        /// <summary>
        /// DataSet�e�[�u���X�L�[�}�ݒ�(���גP��)
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
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

            dt = new DataTable(ct_Tbl_EstmtAnsDetail);

            string defaultValueOfstring = string.Empty;
            Int32 defaultValueOfInt32 = 0;
            Int64 defaultValueOfInt64 = 0;

            // �����s�ԍ�
            dt.Columns.Add(ct_Col_UOESalesOrderRowNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderRowNo].DefaultValue = defaultValueOfInt32;
            // �i��
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;
            // ���[�J�[
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfstring;
            // �i��
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defaultValueOfstring;
            // ����
            dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(Int64));
            dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defaultValueOfInt64;
            // �W�����i
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Int64));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defaultValueOfInt64;
            // ���P��
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Int64));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defaultValueOfInt64;
            // �R�����g
            dt.Columns.Add(ct_Col_Comment, typeof(string));
            dt.Columns[ct_Col_Comment].DefaultValue = defaultValueOfstring;
            // �ύ���1
            dt.Columns.Add(ct_Col_Variable1, typeof(string));
            dt.Columns[ct_Col_Variable1].DefaultValue = defaultValueOfstring;
            // �ύ���2
            dt.Columns.Add(ct_Col_Variable2, typeof(string));
            dt.Columns[ct_Col_Variable2].DefaultValue = defaultValueOfstring;
            // �ύ���3
            dt.Columns.Add(ct_Col_Variable3, typeof(string));
            dt.Columns[ct_Col_Variable3].DefaultValue = defaultValueOfstring;
            // �ύ���4
            dt.Columns.Add(ct_Col_Variable4, typeof(string));
            dt.Columns[ct_Col_Variable4].DefaultValue = defaultValueOfstring;
        }
        #endregion
    }
}
