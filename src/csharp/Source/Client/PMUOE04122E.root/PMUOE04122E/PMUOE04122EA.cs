using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �݌ɉ񓚏��e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɉ񓚏��e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : �Ɠc �M�u</br>
    /// <br>Date       : 2008/11/10</br>
    /// <br>UpdateNote : 2009/02/03 �Ɠc �M�u�@�s��Ή�[10841] </br>
    /// <br></br>
    /// <br>UpdateNote : 2012/07/13 30517 �Ė� �x��</br>
    /// <br>             �d�������������_�ȉ��\���\�ɏC��</br>
    /// </remarks>
    public class PMUOE04122EA
    {
        #region ��Public�萔
        /// <summary> �e�[�u������(������P��) </summary>
        public const string ct_Tbl_StockAnsSupplier = "Tbl_StockAnsSupplier";
        /// <summary> �e�[�u������(���גP��) </summary>
        public const string ct_Tbl_StockAnsDetail = "Tbl_StockAnsDetail";
        /// <summary> �e�[�u������(���_�P��) </summary>
        public const string ct_Tbl_StockAnsSection = "Tbl_StockAnsSection";

        // ������(���׈ȊO)���
        /// <summary> UOE�����於�� </summary>
        public const string ct_Col_UOESupplierName = "UOESupplierName";
        /// <summary> UOE���}�[�N1 </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        /// <summary> UOE���}�[�N2 </summary>
        public const string ct_Col_UoeRemark2 = "UoeRemark2";

        // ���׏��(�O���b�h�p)
        /// <summary> UOE������R�[�h </summary>
        public const string ct_Col_UOESupplierCd = "UOESupplierCd";
        /// <summary> UOE�����ԍ� </summary>
        public const string ct_Col_UOESalesOrder = "UOESalesOrder";
        /// <summary> UOE�����s�ԍ� </summary>
        public const string ct_Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> ���[�J�[ </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> �W�����i </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> ���P�� </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        /// <summary> �[�� </summary>
        public const string ct_Col_UOEDelivDateCd = "UOEDelivDateCd";
        /// <summary> ��� </summary>
        public const string ct_Col_UOESubstCode = "UOESubstCode";
        /// <summary> �R�����g���� </summary>
        public const string ct_Col_Comment = "Comment";
        #endregion

        // ���_���(�O���b�h�p)
        /// <summary>���_</summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary>�݌ɐ�</summary>
        public const string ct_Col_SectionStock = "SectionStock";

        #region �� Constructor
        /// <summary>
        /// �݌ɉ񓚃O���b�h�p�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌ɉ񓚏��e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public PMUOE04122EA()
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

            dt = new DataTable(ct_Tbl_StockAnsSupplier);

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

            dt = new DataTable(ct_Tbl_StockAnsDetail);

            string defaultValueOfstring = string.Empty;
            Int32 defaultValueOfInt32 = 0;
            Int64 defaultValueOfInt64 = 0;

            // ������R�[�h
            dt.Columns.Add(ct_Col_UOESupplierCd, typeof(Int32));
            dt.Columns[ct_Col_UOESupplierCd].DefaultValue = defaultValueOfInt32;
            // �����ԍ�
            dt.Columns.Add(ct_Col_UOESalesOrder, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrder].DefaultValue = defaultValueOfInt32;
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
            // �W�����i
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Int64));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defaultValueOfInt64;
            // ���P��
            // upd 2012/07/13 >>>
            //dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Int64));
            //dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defaultValueOfInt64;
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = 0.0;
            // upd 2012/07/13 <<<
            // �[��
            dt.Columns.Add(ct_Col_UOEDelivDateCd, typeof(string));
            dt.Columns[ct_Col_UOEDelivDateCd].DefaultValue = defaultValueOfstring;
            // ���
            dt.Columns.Add(ct_Col_UOESubstCode, typeof(string));
            dt.Columns[ct_Col_UOESubstCode].DefaultValue = defaultValueOfstring;
            // �R�����g
            dt.Columns.Add(ct_Col_Comment, typeof(string));
            dt.Columns[ct_Col_Comment].DefaultValue = defaultValueOfstring;
        }

        /// <summary>
        /// DataSet�e�[�u���X�L�[�}�ݒ�(���_�P��)
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        static public void CreateDataTableSection(ref DataTable dt)
        {
            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (dt != null)
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[�̂ݍs���B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                dt.Clear();
                return;
            }

            dt = new DataTable(ct_Tbl_StockAnsSection);

            string defaultValueOfstring = string.Empty;
            Int32 defaultValueOfInt32 = 0;

            // ���_
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;

            // �݌ɐ�
            /* ---DEL 2009/02/03 �s��Ή�[10841] ------------------------------------>>>>>
            dt.Columns.Add(ct_Col_SectionStock, typeof(Int32));
            dt.Columns[ct_Col_SectionStock].DefaultValue = defaultValueOfInt32;
               ---DEL 2009/02/03 �s��Ή�[10841] ------------------------------------<<<<< */
            // ---ADD 2009/02/03 �s��Ή�[10841] ------------------------------------>>>>>
            dt.Columns.Add(ct_Col_SectionStock, typeof(string));
            dt.Columns[ct_Col_SectionStock].DefaultValue = defaultValueOfstring;
            // ---ADD 2009/02/03 �s��Ή�[10841] ------------------------------------<<<<<
        }
        #endregion
    }
}
