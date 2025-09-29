//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d��������ѕ\
// �v���O�����T�v   : �d��������ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009.05.13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �d��������ѕ\�e�[�u���X�L�[�}���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d��������ѕ\�e�[�u���X�L�[�}���N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.05.13</br>
    /// </remarks>
    public class PMKOU02065EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string Tbl_StockSalesResultInfoAccRecMain = "Tbl_StockSalesResultInfoAccRecMain";

        /// <summary> ���_�R�[�h </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> ���_�� </summary>
        /// <remarks>���_���ݒ�}�X�^ ���_�K�C�h����</remarks>
        public const string Col_SectionGuideNm = "SectionGuideNm";

        /// <summary> ���Ӑ�R�[�h </summary>
        /// <remarks>����f�[�^ ���Ӑ�R�[�h</remarks>
        public const string Col_CustomerCode = "CustomerCode";

        /// <summary> ���Ӑ於 </summary>
        /// <remarks>����f�[�^ ���Ӑ於��</remarks>
        public const string Col_CustomerName = "CustomerName";

        /// <summary> ������t </summary>
        /// <remarks>����f�[�^ ������t</remarks>
        public const string Col_SalesDate = "SalesDate";

        /// <summary> �`�[�ԍ� </summary>
        /// <remarks>����f�[�^ ����`�[�ԍ�</remarks>
        public const string Col_SalesSlipNum = "SalesSlipNum";

        /// <summary> �敪 </summary>
        /// <remarks>�`�[���f</remarks>
        public const string Col_KuBec = "KuBec";

        /// <summary> �S���� </summary>
        /// <remarks>�d���f�[�^�@�d���S���Җ���</remarks>
        public const string Col_StockAgentName = "StockAgentName";

        /// <summary> �󒍎� </summary>
        /// <remarks>����f�[�^�@��t�]�ƈ�����</remarks>
        public const string Col_FrontEmployeeNm = "FrontEmployeeNm";

        /// <summary> ���s�� </summary>
        /// <remarks>����f�[�^�@������͎Җ���</remarks>
        public const string Col_SalesInputName = "SalesInputName";

        /// <summary> ���}�[�N�P </summary>
        /// <remarks>����f�[�^�@�t�n�d���}�[�N�P</remarks>
        public const string Col_UoeRemark1 = "UoeRemark1";

        /// <summary> ���}�[�N�Q </summary>
        /// <remarks>����f�[�^�@�t�n�d���}�[�N�Q</remarks>
        public const string Col_UoeRemark2 = "UoeRemark2";

        /// <summary> ���l�P </summary>
        /// <remarks>����f�[�^�@�`�[���l</remarks>
        public const string Col_SlipNote = "SlipNote";

        /// <summary> ���l�Q </summary>
        /// <remarks>����f�[�^�@�`�[���l�Q</remarks>
        public const string Col_SlipNote2 = "SlipNote2";

        /// <summary> ���l�R </summary>
        /// <remarks>����f�[�^�@�`�[���l�R</remarks>
        public const string Col_SlipNote3 = "SlipNote3";

        /// <summary> �d�����l</summary>
        /// <remarks>�d���f�[�^�@�d���`�[���l1</remarks>
        public const string Col_SupplierSlipNote1 = "SupplierSlipNote1";

        /// <summary> �i�� </summary>
        /// <remarks>�d�����׃f�[�^�@���i�ԍ�</remarks>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> �ݎ� </summary>
        /// <remarks>�d�����׃f�[�^�@�d���݌Ɏ�񂹋敪</remarks>
        public const string Col_StockOrderDivCd = "StockOrderDivCd";

        /// <summary> �i�� </summary>
        /// <remarks>�d�����׃f�[�^�@���i����</remarks>
        public const string Col_GoodsName = "GoodsName";

        /// <summary> �W�����i </summary>
        /// <remarks>�d�����׃f�[�^�@�艿�i�Ŕ��C�����j</remarks>
        public const string Col_ListPriceTaxExcFl = "ListPriceTaxExcFl";

        /// <summary> ���� </summary>
        /// <remarks>�d�����׃f�[�^�@�d����</remarks>
        public const string Col_StockCount = "StockCount";

        /// <summary> ���P�� </summary>
        /// <remarks>���㖾�׃f�[�^�@����P���i�Ŕ��C�����j</remarks>
        public const string Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";

        /// <summary> ������z </summary>
        /// <remarks>���㖾�׃f�[�^�@������z�i�Ŕ����j</remarks>
        public const string Col_SalesMoneyTaxExc = "SalesMoneyTaxExc";

        /// <summary> �e�����z </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_GrpMoney = "GrpMoney";

        /// <summary> �e���� </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_GrpPct = "GrpPct";

        /// <summary> �}�[�N </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_Maku = "Maku";

        /// <summary> ���P�� </summary>
        /// <remarks>�d�����׃f�[�^�@�d���P���i�Ŕ��C�����j</remarks>
        public const string Col_StockUnitPriceFl = "StockUnitPriceFl";

        /// <summary> �d�����z </summary>
        /// <remarks>�d�����׃f�[�^�@�d�����z�i�Ŕ����j</remarks>
        public const string Col_StockPriceTaxExc = "StockPriceTaxExc";

        /// <summary> �d���� </summary>
        /// <remarks>�d���f�[�^�@�d����R�[�h</remarks>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> �`�[�ԍ� </summary>
        /// <remarks>�d���f�[�^�@�����`�[�ԍ�</remarks>
        public const string Col_PartySaleSlipNum = "PartySaleSlipNum";

        /// <summary> �d�����t </summary>
        /// <remarks>�d���f�[�^�@�d����</remarks>
        public const string Col_StockDate = "StockDate";

        /// <summary> �d���� </summary>
        /// <remarks>�d���f�[�^�@�d����R�[�h</remarks>
        public const string Col_SupplierCdForSort = "SupplierCdForSort";

        /// <summary> �`�[�ԍ� </summary>
        /// <remarks>�d���f�[�^�@�����`�[�ԍ�</remarks>
        public const string Col_PartySaleSlipNumForSort = "PartySaleSlipNumForSort";

        /// <summary> �d�����t </summary>
        /// <remarks>�d���f�[�^�@�d����</remarks>
        public const string Col_StockDateForSort = "StockDateForSort";

        /// <summary>�d����v</summary>
        public const string CT_StockConf_DailyHeaderDataField = "DailyHeaderDataField";

        //�d�� 
        /// <summary> ������z </summary>
        /// <remarks>���㖾�׃f�[�^�@������z�i�Ŕ����j</remarks>
        public const string Col_SalesSalesMoneyTaxExc = "SalesSalesMoneyTaxExc";

        /// <summary> �e�����z </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_SalesGrpMoney = "SalesGrpMoney";

        /// <summary> �e���� </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_SalesGrpPct = "SalesGrpPct";

        /// <summary> �d�����z </summary>
        /// <remarks>�d�����׃f�[�^�@�d�����z�i�Ŕ����j</remarks>
        public const string Col_SalesStockPriceTaxExc = "SalesStockPriceTaxExc";

        //�ԕi
        /// <summary> ������z </summary>
        /// <remarks>���㖾�׃f�[�^�@������z�i�Ŕ����j</remarks>
        public const string Col_RetGdsSalesMoneyTaxExc = "RetGdsSalesMoneyTaxExc";

        /// <summary> �e�����z </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_RetGdsGrpMoney = "RetGdsGrpMoney";

        /// <summary> �e���� </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_RetGdsGrpPct = "RetGdsGrpPct";

        /// <summary> �d�����z </summary>
        /// <remarks>�d�����׃f�[�^�@�d�����z�i�Ŕ����j</remarks>
        public const string Col_RetGdsStockPriceTaxExc = "RetGdsStockPriceTaxExc";

        //�l��
        /// <summary> ������z </summary>
        /// <remarks>���㖾�׃f�[�^�@������z�i�Ŕ����j</remarks>
        public const string Col_DistSalesMoneyTaxExc = "DistSalesMoneyTaxExc";

        /// <summary> �e�����z </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_DistGrpMoney = "DistGrpMoney";

        /// <summary> �e���� </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_DistGrpPct = "DistGrpPct";

        /// <summary> �d�����z </summary>
        /// <remarks>�d�����׃f�[�^�@�d�����z�i�Ŕ����j</remarks>
        public const string Col_DistStockPriceTaxExc = "DistStockPriceTaxExc";

        /// <summary> �d���`�[�ԍ� </summary>
        /// <remarks>�d�����׃f�[�^�@�d���`�[�ԍ�</remarks>
        public const string Col_SupplierSlipNo = "SupplierSlipNo";

        /// <summary> �d���s�ԍ� </summary>
        /// <remarks>�d�����׃f�[�^�@�d���s�ԍ�</remarks>
        public const string Col_StockRowNo = "StockRowNo";

        /// <summary> �d���� </summary>
        /// <remarks> �Ȃ�</remarks>
        public const string Col_SalesCountNumber = "SalesCountNumber";

        /// <summary> �ԕi�� </summary>
        /// <remarks> �Ȃ�</remarks>
        public const string Col_ReturnCountNumber = "ReturnCountNumber";

        /// <summary> ���v�� </summary>
        /// <remarks> �Ȃ�</remarks>
        public const string Col_TotleCountNumber = "TotleCountNumber";

        /// <summary> LineFlag</summary>
        public const string Col_LineFlag = "LineFlag";

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// �d��������ѕ\ ���[�f�[�^�p�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d��������ѕ\ ���[�f�[�^�p�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public PMKOU02065EA()
        {

        }
        #endregion

        #region �� Static Public Method
        #region �� CreateDataTable(ref DataSet ds)
        /// <summary>
        /// ���[DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�Z�b�g</param>
        /// <remarks>
        /// <br>Note       : ���[�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static public void CreateDataTableStockSalesResultInfoAccRecMain(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(Tbl_StockSalesResultInfoAccRecMain))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[Tbl_StockSalesResultInfoAccRecMain].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(Tbl_StockSalesResultInfoAccRecMain);

                DataTable dt = ds.Tables[Tbl_StockSalesResultInfoAccRecMain];

                dt.Columns.Add(Col_SectionCode, typeof(string));//���_�R�[�h 
                dt.Columns[Col_SectionCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SectionGuideNm, typeof(string));//���_�� 
                dt.Columns[Col_SectionGuideNm].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CustomerCode, typeof(string));//���Ӑ�R�[�h 
                dt.Columns[Col_CustomerCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CustomerName, typeof(string));//���Ӑ於
                dt.Columns[Col_CustomerName].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesDate, typeof(string));//������t
                dt.Columns[Col_SalesDate].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesSlipNum, typeof(string));//�`�[�ԍ�
                dt.Columns[Col_SalesSlipNum].DefaultValue = string.Empty;

                dt.Columns.Add(Col_KuBec, typeof(string));//�敪
                dt.Columns[Col_KuBec].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockAgentName, typeof(string));//�S����
                dt.Columns[Col_StockAgentName].DefaultValue = string.Empty;

                dt.Columns.Add(Col_FrontEmployeeNm, typeof(string));//�󒍎�
                dt.Columns[Col_FrontEmployeeNm].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesInputName, typeof(string));//���s��
                dt.Columns[Col_SalesInputName].DefaultValue = string.Empty;

                dt.Columns.Add(Col_UoeRemark1, typeof(string));//���}�[�N�P
                dt.Columns[Col_UoeRemark1].DefaultValue = string.Empty;

                dt.Columns.Add(Col_UoeRemark2, typeof(string));//���}�[�N�Q
                dt.Columns[Col_UoeRemark2].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SlipNote, typeof(string));//���l�P
                dt.Columns[Col_SlipNote].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SlipNote2, typeof(string));//���l�Q
                dt.Columns[Col_SlipNote2].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SlipNote3, typeof(string));//���l�R
                dt.Columns[Col_SlipNote3].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierSlipNote1, typeof(string));//�d�����l
                dt.Columns[Col_SupplierSlipNote1].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GoodsNo, typeof(string));//�i��
                dt.Columns[Col_GoodsNo].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockOrderDivCd, typeof(string));//�ݎ�
                dt.Columns[Col_StockOrderDivCd].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GoodsName, typeof(string));//�i��
                dt.Columns[Col_GoodsName].DefaultValue = string.Empty;

                dt.Columns.Add(Col_ListPriceTaxExcFl, typeof(string));//�W�����i
                dt.Columns[Col_ListPriceTaxExcFl].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockCount, typeof(string));//����
                dt.Columns[Col_StockCount].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesUnPrcTaxExcFl, typeof(string));//���P�� 
                dt.Columns[Col_SalesUnPrcTaxExcFl].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesMoneyTaxExc, typeof(string));//������z
                dt.Columns[Col_SalesMoneyTaxExc].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GrpMoney, typeof(string));//�e�����z
                dt.Columns[Col_GrpMoney].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GrpPct, typeof(string));//�e���� 
                dt.Columns[Col_GrpPct].DefaultValue = string.Empty;

                dt.Columns.Add(Col_Maku, typeof(string));//�}�[�N 
                dt.Columns[Col_Maku].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockUnitPriceFl, typeof(string));//���P�� 
                dt.Columns[Col_StockUnitPriceFl].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockPriceTaxExc, typeof(string));//�d�����z
                dt.Columns[Col_StockPriceTaxExc].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierCd, typeof(string));//�d���� 
                dt.Columns[Col_SupplierCd].DefaultValue = string.Empty;

                dt.Columns.Add(Col_PartySaleSlipNum, typeof(string));//�`�[�ԍ� 
                dt.Columns[Col_PartySaleSlipNum].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockDate, typeof(string));//�d�����t
                dt.Columns[Col_StockDate].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierCdForSort, typeof(string));//�d���� 
                dt.Columns[Col_SupplierCdForSort].DefaultValue = string.Empty;

                dt.Columns.Add(Col_PartySaleSlipNumForSort, typeof(string));//�`�[�ԍ� 
                dt.Columns[Col_PartySaleSlipNumForSort].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockDateForSort, typeof(string));//�d�����t
                dt.Columns[Col_StockDateForSort].DefaultValue = string.Empty;

                // �d����v
                dt.Columns.Add(CT_StockConf_DailyHeaderDataField, typeof(string));
                dt.Columns[CT_StockConf_DailyHeaderDataField].DefaultValue = string.Empty;

                //������z(�d��)
                dt.Columns.Add(Col_SalesSalesMoneyTaxExc, typeof(string));
                dt.Columns[Col_SalesSalesMoneyTaxExc].DefaultValue = string.Empty;

                //�e�����z(�d��)
                dt.Columns.Add(Col_SalesGrpMoney, typeof(string));
                dt.Columns[Col_SalesGrpMoney].DefaultValue = string.Empty;

                // �e����(�d��)
                dt.Columns.Add(Col_SalesGrpPct, typeof(string));
                dt.Columns[Col_SalesGrpPct].DefaultValue = string.Empty;

                //�d�����z(�d��)
                dt.Columns.Add(Col_SalesStockPriceTaxExc, typeof(string));
                dt.Columns[Col_SalesStockPriceTaxExc].DefaultValue = string.Empty;

                //������z(�ԕi)
                dt.Columns.Add(Col_RetGdsSalesMoneyTaxExc, typeof(string));
                dt.Columns[Col_RetGdsSalesMoneyTaxExc].DefaultValue = string.Empty;

                //�e�����z(�ԕi)
                dt.Columns.Add(Col_RetGdsGrpMoney, typeof(string));
                dt.Columns[Col_RetGdsGrpMoney].DefaultValue = string.Empty;

                //�e����(�ԕi)
                dt.Columns.Add(Col_RetGdsGrpPct, typeof(string));
                dt.Columns[Col_RetGdsGrpPct].DefaultValue = string.Empty;

                //�d�����z(�ԕi)
                dt.Columns.Add(Col_RetGdsStockPriceTaxExc, typeof(string));
                dt.Columns[Col_RetGdsStockPriceTaxExc].DefaultValue = string.Empty;

                //������z(�l��) 
                dt.Columns.Add(Col_DistSalesMoneyTaxExc, typeof(string));
                dt.Columns[Col_DistSalesMoneyTaxExc].DefaultValue = string.Empty;

                //�e�����z(�l��) 
                dt.Columns.Add(Col_DistGrpMoney, typeof(string));
                dt.Columns[Col_DistGrpMoney].DefaultValue = string.Empty;

                //�e����(�l��)
                dt.Columns.Add(Col_DistGrpPct, typeof(string));
                dt.Columns[Col_DistGrpPct].DefaultValue = string.Empty;

                //�d�����z(�l��)
                dt.Columns.Add(Col_DistStockPriceTaxExc, typeof(string));
                dt.Columns[Col_DistStockPriceTaxExc].DefaultValue = string.Empty;

                //�d���`�[�ԍ�
                dt.Columns.Add(Col_SupplierSlipNo, typeof(string));
                dt.Columns[Col_SupplierSlipNo].DefaultValue = string.Empty;

                //�d���s�ԍ�
                dt.Columns.Add(Col_StockRowNo, typeof(string));
                dt.Columns[Col_StockRowNo].DefaultValue = string.Empty;

                // �d���� 
                dt.Columns.Add(Col_SalesCountNumber, typeof(string));
                dt.Columns[Col_SalesCountNumber].DefaultValue = string.Empty;

                // �ԕi�� 
                dt.Columns.Add(Col_ReturnCountNumber, typeof(string));
                dt.Columns[Col_ReturnCountNumber].DefaultValue = string.Empty;

                // ���v��
                dt.Columns.Add(Col_TotleCountNumber, typeof(string));
                dt.Columns[Col_TotleCountNumber].DefaultValue = string.Empty;

                dt.Columns.Add(Col_LineFlag, typeof(bool));//lineflag
                dt.Columns[Col_LineFlag].DefaultValue = false;

            }
        }
        #endregion
        #endregion
    }
}
