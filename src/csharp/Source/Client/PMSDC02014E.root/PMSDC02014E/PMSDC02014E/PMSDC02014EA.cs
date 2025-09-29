//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����A�g�e�L�X�g�o��
// �v���O�����T�v   : ����A�g�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00      �쐬�S�� : �c����
// �� �� ��  2019/12/02       �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ����A�g�e�L�X�g�o�� �e�[�u���X�L�[�}���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����A�g�e�L�X�g�o�� �e�[�u���X�L�[�}���N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/12/02</br>
    /// </remarks>
    public class PMSDC02014EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_SalesCprtData = "Tbl_SalesCprtData";

        /// <summary> AB�`�[�� </summary>
        public const string ct_Col_SalesSlipNum = "SalesSlipNum";

        /// <summary> �����敪 </summary>
        public const string ct_Col_RequestDiv = "RequestDiv";

        /// <summary> AB�X�ܺ��� </summary>
        public const string ct_Col_AddresseeShopCd = "AddresseeShopCd";

        /// <summary> ����� </summary>
        public const string ct_Col_AddUpADate = "AddUpADate";

        /// <summary> �����D�ǋ敪 </summary>
        public const string ct_Col_GoodDiv = "GoodDiv";

        /// <summary> ���i������ </summary>
        public const string ct_Col_TradCompCd = "TradCompCd";

        /// <summary> �r���d�d���� </summary>
        public const string ct_Col_TradCompRate = "TradCompRate";

        /// <summary> AB���㗦 </summary>
        public const string ct_Col_AbSalesRate = "AbSalesRate";

        /// <summary> �s�� </summary>
        public const string ct_Col_SalesRowNo = "SalesRowNo";

        /// <summary> �Ǘ��� </summary>
        public const string ct_Col_AdministrationNo = "AdministrationNo";

        /// <summary> �Ǘ����́i�i�ԁj </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";

        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsNameKana = "GoodsNameKana";

        /// <summary> ���i���� </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";

        /// <summary> ���� </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";

        /// <summary> �[���P��</summary>
        public const string ct_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";

        /// <summary> �[�����z </summary>
        public const string ct_Col_SalesMoneyTaxExc = "SalesMoneyTaxExc";

        /// <summary> �d�����z</summary>
        public const string ct_Col_SupplierMoney = "SupplierMoney";

        /// <summary> PDF�p�[�����z </summary>
        public const string ct_Col_PdfSalesMoneyTaxExc = "PdfSalesMoneyTaxExc";

        /// <summary> PDF�p�d�����z</summary>
        public const string ct_Col_PdfSupplierMoney = "PdfSupplierMoney";

        /// <summary> ������z</summary>
        public const string ct_Col_SalesMoney = "SalesMoney";

        /// <summary> ���Ӑ溰�� </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";

        /// <summary> �n�溰�� </summary>
        public const string ct_Col_AreaCd = "AreaCd";

        /// <summary> �����ްĂx�l�c </summary>
        public const string ct_Col_SearchSlipDate = "SearchSlipDate";

        /// <summary> �d����R�[�h </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";

        /// <summary> �o��敪 </summary>
        public const string ct_Col_ExpenseDivCd = "ExpenseDivCd";

        /// <summary> ���[�J�[�R�[�h </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";

        /// <summary> �����i���o�[</summary>
        public const string ct_Col_OrderNum = "OrderNum";

        /// <summary> �e�h�k�k�d�q </summary>
        public const string ct_Col_Filler = "Filler";

        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCodeRF = "SectionCode";

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_PdfData = "Tbl_PdfData";

        /// <summary> �`�[����</summary>
        public const string ct_Col_SlipCountSum = "SlipCountSum";

        /// <summary> ���㍇�v</summary>
        public const string ct_Col_SalesMoneySum = "SalesMoneySum";

        /// <summary> �l���\��z </summary>
        public const string ct_Col_SalesSupplierMoneySum = "SalesSupplierMoneySum";

        /// <summary> �s���i�����j </summary>
        public const string ct_Col_PureCount = "PureCount";

        /// <summary> ���_�K�C�h���� </summary>
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";

        /// <summary> ���Ӑ旪�� </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";

        /// <summary> �`�[���l</summary>
        public const string ct_Col_SlipNote = "SlipNote";

        /// <summary> �`�[���l2</summary>
        public const string ct_Col_SlipNote2 = "SlipNote2";

        /// <summary> �`�[���l3</summary>
        public const string ct_Col_SlipNote3 = "SlipNote3";

        /// <summary> �X�V����</summary>
        public const string ct_Col_UpDate = "UpdateDateTime";

        /// <summary> �`�[�敪</summary>
        public const string ct_Col_SalesSlipCd = "SalesSlipCd";

        /// <summary> ���[�J�[��</summary>
        public const string ct_Col_MakerName = "MakerName";

        /// <summary> �����`�[�ԍ�</summary>
        public const string ct_Col_DebitNLnkSalesSlNum = "DebitNLnkSalesSlNum";

        #endregion �� Public Const

		#region �� Constructor
		/// <summary>
        /// ����A�g�e�L�X�g�o�� �e�[�u���X�L�[�}���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ����A�g�e�L�X�g�o�� �e�[�u���X�L�[�}���N���X�̏������y�уC���X�^���X�������s���B</br>
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2019/12/02</br>
		/// </remarks>
        public PMSDC02014EA()
		{
		}
		#endregion

        #region �� Static Public Method
        #region �� �f�[�^DataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// ����f�[�^�e�L�X�gDataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
		/// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
		/// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
		/// </remarks>
        static public void CreateDataTable(ref DataTable dt)
        {
            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (dt != null)
            {
                // �e�[�u�������݂��鎞�̓N���A����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                dt.Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                dt = new DataTable(ct_Tbl_SalesCprtData);

                // AB�`�[��
                dt.Columns.Add(ct_Col_SalesSlipNum, typeof(string));
                dt.Columns[ct_Col_SalesSlipNum].DefaultValue = "";

                // �����敪
                dt.Columns.Add(ct_Col_RequestDiv, typeof(string));
                dt.Columns[ct_Col_RequestDiv].DefaultValue = "";

                // AB�X�ܺ���
                dt.Columns.Add(ct_Col_AddresseeShopCd, typeof(string));
                dt.Columns[ct_Col_AddresseeShopCd].DefaultValue = "";

                // ����� 
                dt.Columns.Add(ct_Col_AddUpADate, typeof(string));
                dt.Columns[ct_Col_AddUpADate].DefaultValue = "";

                // �����D�ǋ敪 
                dt.Columns.Add(ct_Col_GoodDiv, typeof(string));
                dt.Columns[ct_Col_GoodDiv].DefaultValue = "";

                // ���i������
                dt.Columns.Add(ct_Col_TradCompCd, typeof(string));
                dt.Columns[ct_Col_TradCompCd].DefaultValue = "";

                // �r���d�d����
                dt.Columns.Add(ct_Col_TradCompRate, typeof(string));
                dt.Columns[ct_Col_TradCompRate].DefaultValue = "";

                // AB���㗦
                dt.Columns.Add(ct_Col_AbSalesRate, typeof(string));
                dt.Columns[ct_Col_AbSalesRate].DefaultValue = "";

                // �s�� 
                dt.Columns.Add(ct_Col_SalesRowNo, typeof(string));
                dt.Columns[ct_Col_SalesRowNo].DefaultValue = "";

                // �Ǘ���
                dt.Columns.Add(ct_Col_AdministrationNo, typeof(string));
                dt.Columns[ct_Col_AdministrationNo].DefaultValue = "";

                // �Ǘ����́i�i�ԁj
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";

                // �i��
                dt.Columns.Add(ct_Col_GoodsNameKana, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana].DefaultValue = "";

                // ���i���� 
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(string));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = "";

                // ����
                dt.Columns.Add(ct_Col_ShipmentCnt, typeof(string));
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = "";

                // �[���P��
                dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFl, typeof(string));
                dt.Columns[ct_Col_SalesUnPrcTaxExcFl].DefaultValue = "";

                // �[�����z
                dt.Columns.Add(ct_Col_SalesMoneyTaxExc, typeof(string));
                dt.Columns[ct_Col_SalesMoneyTaxExc].DefaultValue = "";

                // �d�����z
                dt.Columns.Add(ct_Col_SupplierMoney, typeof(string));
                dt.Columns[ct_Col_SupplierMoney].DefaultValue = "";

                // PDF�p�[�����z
                dt.Columns.Add(ct_Col_PdfSalesMoneyTaxExc, typeof(string));
                dt.Columns[ct_Col_PdfSalesMoneyTaxExc].DefaultValue = "";

                // PDF�p�d�����z
                dt.Columns.Add(ct_Col_PdfSupplierMoney, typeof(string));
                dt.Columns[ct_Col_PdfSupplierMoney].DefaultValue = "";

                // ������z
                dt.Columns.Add(ct_Col_SalesMoney, typeof(string));
                dt.Columns[ct_Col_SalesMoney].DefaultValue = "";

                // ���Ӑ溰��
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = "";

                // �n�溰��
                dt.Columns.Add(ct_Col_AreaCd, typeof(string));
                dt.Columns[ct_Col_AreaCd].DefaultValue = "";

                // �����ްĂx�l�c
                dt.Columns.Add(ct_Col_SearchSlipDate, typeof(string));
                dt.Columns[ct_Col_SearchSlipDate].DefaultValue = "";

                // �d����R�[�h
                dt.Columns.Add(ct_Col_SupplierCd, typeof(string));
                dt.Columns[ct_Col_SupplierCd].DefaultValue = "";

                // �o��敪
                dt.Columns.Add(ct_Col_ExpenseDivCd, typeof(string));
                dt.Columns[ct_Col_ExpenseDivCd].DefaultValue = "";

                // ���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = "";

                dt.Columns.Add(ct_Col_OrderNum, typeof(string));
                dt.Columns[ct_Col_OrderNum].DefaultValue = "";

                // �e�h�k�k�d�q
                dt.Columns.Add(ct_Col_Filler, typeof(string));
                dt.Columns[ct_Col_Filler].DefaultValue = "";

                // ���_�R�[�h
                dt.Columns.Add(ct_Col_SectionCodeRF, typeof(string));
                dt.Columns[ct_Col_SectionCodeRF].DefaultValue = "";

                // ���_�K�C�h����
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = "";

                // ���Ӑ旪��
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";

                // �`�[���l
                dt.Columns.Add(ct_Col_SlipNote, typeof(string));
                dt.Columns[ct_Col_SlipNote].DefaultValue = "";

                // �`�[���l2
                dt.Columns.Add(ct_Col_SlipNote2, typeof(string));
                dt.Columns[ct_Col_SlipNote2].DefaultValue = "";

                // �`�[���l3
                dt.Columns.Add(ct_Col_SlipNote3, typeof(string));
                dt.Columns[ct_Col_SlipNote3].DefaultValue = "";

                // �X�V����
                dt.Columns.Add(ct_Col_UpDate, typeof(string));
                dt.Columns[ct_Col_UpDate].DefaultValue = "";

                // �`�[�敪
                dt.Columns.Add(ct_Col_SalesSlipCd, typeof(string));
                dt.Columns[ct_Col_SalesSlipCd].DefaultValue = "";

                // ���[�J�[��
                dt.Columns.Add(ct_Col_MakerName, typeof(string));
                dt.Columns[ct_Col_MakerName].DefaultValue = "";

                // �����`�[�ԍ�
                dt.Columns.Add(ct_Col_DebitNLnkSalesSlNum, typeof(string));
                dt.Columns[ct_Col_DebitNLnkSalesSlNum].DefaultValue = "";
            }
        }

        /// <summary>
        /// ����f�[�^�e�L�X�gDataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
		/// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
		/// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
		/// </remarks>
        static public void CreatePrintDataTable(ref DataTable dt)
        {
            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (dt != null)
            {
                // �e�[�u�������݂��鎞�̓N���A����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                dt.Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                dt = new DataTable(ct_Tbl_PdfData);

                // �`�[����
                dt.Columns.Add(ct_Col_SlipCountSum, typeof(string));
                dt.Columns[ct_Col_SlipCountSum].DefaultValue = "";

                // ���㍇�v
                dt.Columns.Add(ct_Col_SalesMoneySum, typeof(string));
                dt.Columns[ct_Col_SalesMoneySum].DefaultValue = "";

                // �l���\��z
                dt.Columns.Add(ct_Col_SalesSupplierMoneySum, typeof(string));
                dt.Columns[ct_Col_SalesSupplierMoneySum].DefaultValue = "";

                // �s��
                dt.Columns.Add(ct_Col_PureCount, typeof(string));
                dt.Columns[ct_Col_PureCount].DefaultValue = "";

                // ���_�R�[�h
                dt.Columns.Add(ct_Col_SectionCodeRF, typeof(string));
                dt.Columns[ct_Col_SectionCodeRF].DefaultValue = "";

                // ���_�K�C�h����
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = "";

                // ���Ӑ旪��
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";

                // ���Ӑ溰��
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = "";
            }
        }

        #endregion �� �f�[�^DataSet�e�[�u���X�L�[�}�ݒ�

        #endregion �� Static Public Method

    }
}
