using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �d���挳�� �x������ �����[�g���o���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������e���͕\�̃����[�g���o���ʂ�ێ�����B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMKOU02035EB
    {
        #region �� Public�萔
        /// <summary> ��ƃR�[�h </summary>
        public const string ct_Tbl_EnterpriseCode = "EnterpriseCode";
        /// <summary> �v�㋒�_�R�[�h </summary>
        public const string ct_Tbl_AddUpSecCode = "AddUpSecCode";
        /// <summary> �x����R�[�h </summary>
        public const string ct_Tbl_PayeeCode = "PayeeCode";
        /// <summary> �x���於�� </summary>
        public const string ct_Tbl_PayeeName = "PayeeName";
        /// <summary> �x���於��2 </summary>
        public const string ct_Tbl_PayeeName2 = "PayeeName2";
        /// <summary> �x���旪�� </summary>
        public const string ct_Tbl_PayeeSnm = "PayeeSnm";
        /// <summary> �d����R�[�h </summary>
        public const string ct_Tbl_SupplierCd = "SupplierCd";
        /// <summary> �d���於1 </summary>
        public const string ct_Tbl_SupplierNm1 = "SupplierNm1";
        /// <summary> �d���於2 </summary>
        public const string ct_Tbl_SupplierNm2 = "SupplierNm2";
        /// <summary> �d���旪�� </summary>
        public const string ct_Tbl_SupplierSnm = "SupplierSnm";
        /// <summary> �v��N���� </summary>
        public const string ct_Tbl_AddUpDate = "AddUpDate";
        /// <summary> �v��N�� </summary>
        public const string ct_Tbl_AddUpYearMonth = "AddUpYearMonth";
        /// <summary> �O�񔃊|���z </summary>
        public const string ct_Tbl_LastTimeAccPay = "LastTimeAccPay";
        /// <summary> �d��2��O�c���i���|�v�j </summary>
        public const string ct_Tbl_StckTtl2TmBfBlAccPay = "StckTtl2TmBfBlAccPay";
        /// <summary> �d��3��O�c���i���|�v�j </summary>
        public const string ct_Tbl_StckTtl3TmBfBlAccPay = "StckTtl3TmBfBlAccPay";
        /// <summary> ����x�����z�i�ʏ�x���j </summary>
        public const string ct_Tbl_ThisTimePayNrml = "ThisTimePayNrml";
        /// <summary> ����J�z�c���i���|�v�j </summary>
        public const string ct_Tbl_ThisTimeTtlBlcAcPay = "ThisTimeTtlBlcAcPay";
        /// <summary> ���E�㍡��d�����z </summary>
        public const string ct_Tbl_OfsThisTimeStock = "OfsThisTimeStock";
        /// <summary> ���E�㍡��d������� </summary>
        public const string ct_Tbl_OfsThisStockTax = "OfsThisStockTax";
        /// <summary> ����ԕi���z </summary>
        public const string ct_Tbl_ThisStckPricRgds = "ThisStckPricRgds";
        /// <summary> ����ԕi����� </summary>
        public const string ct_Tbl_ThisStcPrcTaxRgds = "ThisStcPrcTaxRgds";
        /// <summary> ����l�����z </summary>
        public const string ct_Tbl_ThisStckPricDis = "ThisStckPricDis";
        /// <summary> ����l������� </summary>
        public const string ct_Tbl_ThisStcPrcTaxDis = "ThisStcPrcTaxDis";
        /// <summary> ����Œ����z </summary>
        public const string ct_Tbl_TaxAdjust = "TaxAdjust";
        /// <summary> �c�������z </summary>
        public const string ct_Tbl_BalanceAdjust = "BalanceAdjust";
        /// <summary> �d�����v�c���i���|�v�j </summary>
        public const string ct_Tbl_StckTtlAccPayBalance = "StckTtlAccPayBalance";
        /// <summary> �����X�V���s�N���� </summary>
        public const string ct_Tbl_MonthAddUpExpDate = "MonthAddUpExpDate";
        /// <summary> �����X�V�J�n�N���� </summary>
        public const string ct_Tbl_StMonCAddUpUpdDate = "StMonCAddUpUpdDate";
        /// <summary> �O�񌎎��X�V�N���� </summary>
        public const string ct_Tbl_LaMonCAddUpUpdDate = "LaMonCAddUpUpdDate";
        /// <summary> �d���`�[���� </summary>
        public const string ct_Tbl_StockSlipCount = "StockSlipCount";
        /// <summary> ���ς݃t���O </summary>
        public const string ct_Tbl_CloseFlg = "CloseFlg";


        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public PMKOU02035EB()
        {
        }

        #endregion

        #region �� public���\�b�h
        /// <summary>
        /// ������e���͕\DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : ������e���͕\�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        static public void CreateDataTable(ref DataTable dt)
        {
            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (dt != null)
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                dt.Clear();
            }
            else
            {
                //�e�J�����̃f�t�H���g�̒l
                string defaultValueOfstring = string.Empty;
                int defaultValueOfInt32 = 0,
                    defaultValueOfInt64 = 0;

                // ��ƃR�[�h
                dt.Columns.Add(ct_Tbl_EnterpriseCode, typeof(string));
                dt.Columns[ct_Tbl_EnterpriseCode].DefaultValue = defaultValueOfstring;
                // �v�㋒�_�R�[�h
                dt.Columns.Add(ct_Tbl_AddUpSecCode, typeof(string));
                dt.Columns[ct_Tbl_AddUpSecCode].DefaultValue = defaultValueOfstring;
                // �x����R�[�h
                dt.Columns.Add(ct_Tbl_PayeeCode, typeof(Int32));
                dt.Columns[ct_Tbl_PayeeCode].DefaultValue = defaultValueOfInt32;
                // �x���於��
                dt.Columns.Add(ct_Tbl_PayeeName, typeof(string));
                dt.Columns[ct_Tbl_PayeeName].DefaultValue = defaultValueOfstring;
                // �x���於��2
                dt.Columns.Add(ct_Tbl_PayeeName2, typeof(string));
                dt.Columns[ct_Tbl_PayeeName2].DefaultValue = defaultValueOfstring;
                // �x���旪��
                dt.Columns.Add(ct_Tbl_PayeeSnm, typeof(string));
                dt.Columns[ct_Tbl_PayeeSnm].DefaultValue = defaultValueOfstring;
                // �d����R�[�h
                dt.Columns.Add(ct_Tbl_SupplierCd, typeof(Int32));
                dt.Columns[ct_Tbl_SupplierCd].DefaultValue = defaultValueOfInt32;
                // �d���於1
                dt.Columns.Add(ct_Tbl_SupplierNm1, typeof(string));
                dt.Columns[ct_Tbl_SupplierNm1].DefaultValue = defaultValueOfstring;
                // �d���於2
                dt.Columns.Add(ct_Tbl_SupplierNm2, typeof(string));
                dt.Columns[ct_Tbl_SupplierNm2].DefaultValue = defaultValueOfstring;
                // �d���旪��
                dt.Columns.Add(ct_Tbl_SupplierSnm, typeof(string));
                dt.Columns[ct_Tbl_SupplierSnm].DefaultValue = defaultValueOfstring;
                // �v��N����
                dt.Columns.Add(ct_Tbl_AddUpDate, typeof(Int32));
                dt.Columns[ct_Tbl_AddUpDate].DefaultValue = defaultValueOfInt32;
                // �v��N��
                dt.Columns.Add(ct_Tbl_AddUpYearMonth, typeof(Int32));
                dt.Columns[ct_Tbl_AddUpYearMonth].DefaultValue = defaultValueOfInt32;
                // �O�񔃊|���z
                dt.Columns.Add(ct_Tbl_LastTimeAccPay, typeof(Int64));
                dt.Columns[ct_Tbl_LastTimeAccPay].DefaultValue = defaultValueOfInt64;
                // �d��2��O�c���i���|�v�j
                dt.Columns.Add(ct_Tbl_StckTtl2TmBfBlAccPay, typeof(Int64));
                dt.Columns[ct_Tbl_StckTtl2TmBfBlAccPay].DefaultValue = defaultValueOfInt64;
                // �d��3��O�c���i���|�v�j
                dt.Columns.Add(ct_Tbl_StckTtl3TmBfBlAccPay, typeof(Int64));
                dt.Columns[ct_Tbl_StckTtl3TmBfBlAccPay].DefaultValue = defaultValueOfInt64;
                // ����x�����z�i�ʏ�x���j
                dt.Columns.Add(ct_Tbl_ThisTimePayNrml, typeof(Int64));
                dt.Columns[ct_Tbl_ThisTimePayNrml].DefaultValue = defaultValueOfInt64;
                // ����J�z�c���i���|�v�j
                dt.Columns.Add(ct_Tbl_ThisTimeTtlBlcAcPay, typeof(Int64));
                dt.Columns[ct_Tbl_ThisTimeTtlBlcAcPay].DefaultValue = defaultValueOfInt64;
                // ���E�㍡��d�����z
                dt.Columns.Add(ct_Tbl_OfsThisTimeStock, typeof(Int64));
                dt.Columns[ct_Tbl_OfsThisTimeStock].DefaultValue = defaultValueOfInt64;
                // ���E�㍡��d�������
                dt.Columns.Add(ct_Tbl_OfsThisStockTax, typeof(Int64));
                dt.Columns[ct_Tbl_OfsThisStockTax].DefaultValue = defaultValueOfInt64;
                // ����ԕi���z
                dt.Columns.Add(ct_Tbl_ThisStckPricRgds, typeof(Int64));
                dt.Columns[ct_Tbl_ThisStckPricRgds].DefaultValue = defaultValueOfInt64;
                // ����ԕi�����
                dt.Columns.Add(ct_Tbl_ThisStcPrcTaxRgds, typeof(Int64));
                dt.Columns[ct_Tbl_ThisStcPrcTaxRgds].DefaultValue = defaultValueOfInt64;
                // ����l�����z
                dt.Columns.Add(ct_Tbl_ThisStckPricDis, typeof(Int64));
                dt.Columns[ct_Tbl_ThisStckPricDis].DefaultValue = defaultValueOfInt64;
                // ����l�������
                dt.Columns.Add(ct_Tbl_ThisStcPrcTaxDis, typeof(Int64));
                dt.Columns[ct_Tbl_ThisStcPrcTaxDis].DefaultValue = defaultValueOfInt64;
                // ����Œ����z
                dt.Columns.Add(ct_Tbl_TaxAdjust, typeof(Int64));
                dt.Columns[ct_Tbl_TaxAdjust].DefaultValue = defaultValueOfInt64;
                // �c�������z
                dt.Columns.Add(ct_Tbl_BalanceAdjust, typeof(Int64));
                dt.Columns[ct_Tbl_BalanceAdjust].DefaultValue = defaultValueOfInt64;
                // �d�����v�c���i���|�v�j
                dt.Columns.Add(ct_Tbl_StckTtlAccPayBalance, typeof(Int64));
                dt.Columns[ct_Tbl_StckTtlAccPayBalance].DefaultValue = defaultValueOfInt64;
                // �����X�V���s�N����
                dt.Columns.Add(ct_Tbl_MonthAddUpExpDate, typeof(Int32));
                dt.Columns[ct_Tbl_MonthAddUpExpDate].DefaultValue = defaultValueOfInt32;
                // �����X�V�J�n�N����
                dt.Columns.Add(ct_Tbl_StMonCAddUpUpdDate, typeof(Int32));
                dt.Columns[ct_Tbl_StMonCAddUpUpdDate].DefaultValue = defaultValueOfInt32;
                // �O�񌎎��X�V�N����
                dt.Columns.Add(ct_Tbl_LaMonCAddUpUpdDate, typeof(Int32));
                dt.Columns[ct_Tbl_LaMonCAddUpUpdDate].DefaultValue = defaultValueOfInt32;
                // �d���`�[����
                dt.Columns.Add(ct_Tbl_StockSlipCount, typeof(Int32));
                dt.Columns[ct_Tbl_StockSlipCount].DefaultValue = defaultValueOfInt32;
                // ���ς݃t���O
                dt.Columns.Add(ct_Tbl_CloseFlg, typeof(Int32));
                dt.Columns[ct_Tbl_CloseFlg].DefaultValue = defaultValueOfInt32;

            }
        }
        #endregion
    }
}
