//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������A���}�b�`���X�g
// �v���O�����T�v   : ���������A���}�b�`���X�g�e�[�u���X�L�[�}��`�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���������A���}�b�`���X�g�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������A���}�b�`���X�g�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.04.07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class RateUnMatchResult
    {
        /// <summary> �e�[�u������ </summary>
        public const string Tbl_Result_RateUnMatch = "Tbl_Result_RateUnMatch";

        /// <summary> �쐬�敪 </summary>
        public const string Col_ProcessKbn = "ProcessKbn";

        /// <summary> �쐬�敪 </summary>
        public const string Col_UpdateDateTime = "UpdateDateTime";

        /// <summary> ��ƃR�[�h </summary>
        public const string Col_EnterpriseCode = "EnterpriseCode";

        /// <summary> �폜�敪 </summary>
        public const string Col_LogicalDeleteCode = "LogicalDeleteCode";

        /// <summary> �폜�敪 </summary>
        public const string Col_LogicalDeleteName = "LogicalDeleteName";

        /// <summary> ���_�R�[�h </summary>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> ���_�R�[�h </summary>
        public const string Col_SectionCodeForPrint = "SectionCodeForPrint";

        /// <summary> ���_���� </summary>
        public const string Col_SectionName = "SectionName";

        /// <summary> �P���|���ݒ�敪 </summary>
        public const string Col_UnitRateSetDivCd = "UnitRateSetDivCd";

        /// <summary> �P����� </summary>
        public const string Col_UnitPriceKindCd = "UnitPriceKindCd";

        /// <summary> �P����� </summary>
        public const string Col_UnitPriceKindNm = "UnitPriceKindNm";

        /// <summary> �|���ݒ�敪 </summary>
        public const string Col_RateSettingDivide = "RateSettingDivide";

        /// <summary> �|���ݒ�敪�i���i�j </summary>
        public const string Col_RateMngGoodsCd = "RateMngGoodsCd";

        /// <summary> �|���ݒ薼�́i���i�j </summary>
        public const string Col_RateMngGoodsNm = "RateMngGoodsNm";

        /// <summary> �|���ݒ�敪�i���Ӑ�j </summary>
        public const string Col_RateMngCustCd = "RateMngCustCd";

        /// <summary> �|���ݒ薼�́i���Ӑ�j </summary>
        public const string Col_RateMngCustNm = "RateMngCustNm";

        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string Col_GoodsMakerCd = "GoodsMakerCd";

        /// <summary> ���i���[�J�[���� </summary>
        public const string Col_GoodsMakerNm = "GoodsMakerNm";

        /// <summary> ���i�ԍ� </summary>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> ���i���� </summary>
        public const string Col_GoodsNm = "GoodsNm";

        /// <summary> ���i�|�������N </summary>
        public const string Col_GoodsRateRank = "GoodsRateRank";

        /// <summary> ���i�|���O���[�v�R�[�h </summary>
        public const string Col_GoodsRateGrpCode = "GoodsRateGrpCode";

        /// <summary> BL�O���[�v�R�[�h </summary>
        public const string Col_BLGroupCode = "BLGroupCode";

        /// <summary> BL���i�R�[�h </summary>
        public const string Col_BLGoodsCode = "BLGoodsCode";

        /// <summary> ���Ӑ�R�[�h </summary>
        public const string Col_CustomerCode = "CustomerCode";

        /// <summary> ���Ӑ�|���O���[�v�R�[�h </summary>
        public const string Col_CustRateGrpCode = "CustRateGrpCode";

        /// <summary> �d����R�[�h </summary>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string Col_GoodsMakerCdForPrint = "GoodsMakerCdForPrint";

        /// <summary> ���i�ԍ� </summary>
        public const string Col_GoodsNoForPrint = "GoodsNoForPrint";

        /// <summary> ���i�|�������N </summary>
        public const string Col_GoodsRateRankForPrint = "GoodsRateRankForPrint";

        /// <summary> ���i�|���O���[�v�R�[�h </summary>
        public const string Col_GoodsRateGrpCodeForPrint = "GoodsRateGrpCodeForPrint";

        /// <summary> BL�O���[�v�R�[�h </summary>
        public const string Col_BLGroupCodeForPrint = "BLGroupCodeForPrint";

        /// <summary> BL���i�R�[�h </summary>
        public const string Col_BLGoodsCodeForPrint = "BLGoodsCodeForPrint";

        /// <summary> ���Ӑ�R�[�h </summary>
        public const string Col_CustomerCodeForPrint = "CustomerCodeForPrint";

        /// <summary> ���Ӑ�|���O���[�v�R�[�h </summary>
        public const string Col_CustRateGrpCodeForPrint = "CustRateGrpCodeForPrint";

        /// <summary> �d����R�[�h </summary>
        public const string Col_SupplierCdForPrint = "SupplierCdForPrint";

        /// <summary> ���b�g�� </summary>
        public const string Col_LotCount = "LotCount";

        /// <summary> ���i�i�����j </summary>
        public const string Col_PriceFl = "PriceFl";

        /// <summary> �|�� </summary>
        public const string Col_RateVal = "RateVal";

        /// <summary> UP�� </summary>
        public const string Col_UpRate = "UpRate";

        /// <summary> �e���m�ۗ� </summary>
        public const string Col_GrsProfitSecureRate = "GrsProfitSecureRate";

        /// <summary> �P���[�������P�� </summary>
        public const string Col_UnPrcFracProcUnit = "UnPrcFracProcUnit";

        /// <summary> �P���[�������敪 </summary>
        public const string Col_UnPrcFracProcDiv = "UnPrcFracProcDiv";

        /// <summary> �G���[�敪 </summary>
        public const string Col_IsErrRateProtyMng = "IsErrRateProtyMng";

        /// <summary> �G���[�敪 </summary>
        public const string Col_IsErrGoodsU = "IsErrGoodsU";

        /// <summary> �G���[�敪 </summary>
        public const string Col_IsAllZero = "IsAllZero";

        /// <summary> ���e </summary>
        public const string Col_Content = "Content";

        /// <summary>
        /// ���������A���}�b�`���X�g�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���������A���}�b�`���X�g�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
		/// </remarks>
        public RateUnMatchResult()
		{
		}

        /// <summary>
		/// DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="ds">�ݒ�Ώۃf�[�^�Z�b�g</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        static public void CreateDataTableResultRateUnMatch(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(Tbl_Result_RateUnMatch))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[Tbl_Result_RateUnMatch].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(Tbl_Result_RateUnMatch);

                DataTable dt = ds.Tables[Tbl_Result_RateUnMatch];

                string defValuestring = "";
                Int32 defValueInt32 = 0;
                DateTime defValueDateTime = new DateTime();
                double defValueDouble = 0.0;

                dt.Columns.Add(Col_ProcessKbn, typeof(string));
                dt.Columns[Col_ProcessKbn].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UpdateDateTime, typeof(DateTime));
                dt.Columns[Col_UpdateDateTime].DefaultValue = defValueDateTime;

                dt.Columns.Add(Col_EnterpriseCode, typeof(string));
                dt.Columns[Col_EnterpriseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_LogicalDeleteCode, typeof(Int32));
                dt.Columns[Col_LogicalDeleteCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_LogicalDeleteName, typeof(string));
                dt.Columns[Col_LogicalDeleteName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionCode, typeof(string));
                dt.Columns[Col_SectionCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionCodeForPrint, typeof(string));
                dt.Columns[Col_SectionCodeForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionName, typeof(string));
                dt.Columns[Col_SectionName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UnitRateSetDivCd, typeof(string));
                dt.Columns[Col_UnitRateSetDivCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UnitPriceKindCd, typeof(string));
                dt.Columns[Col_UnitPriceKindCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UnitPriceKindNm, typeof(string));
                dt.Columns[Col_UnitPriceKindNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_RateSettingDivide, typeof(string));
                dt.Columns[Col_RateSettingDivide].DefaultValue = defValuestring;

                dt.Columns.Add(Col_RateMngGoodsCd, typeof(string));
                dt.Columns[Col_RateMngGoodsCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_RateMngGoodsNm, typeof(string));
                dt.Columns[Col_RateMngGoodsNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_RateMngCustCd, typeof(string));
                dt.Columns[Col_RateMngCustCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_RateMngCustNm, typeof(string));
                dt.Columns[Col_RateMngCustNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerCd, typeof(string));
                dt.Columns[Col_GoodsMakerCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerNm, typeof(string));
                dt.Columns[Col_GoodsMakerNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNo, typeof(string));
                dt.Columns[Col_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNm, typeof(string));
                dt.Columns[Col_GoodsNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsRateRank, typeof(string));
                dt.Columns[Col_GoodsRateRank].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsRateGrpCode, typeof(string));
                dt.Columns[Col_GoodsRateGrpCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BLGroupCode, typeof(string));
                dt.Columns[Col_BLGroupCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BLGoodsCode, typeof(string));
                dt.Columns[Col_BLGoodsCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_CustomerCode, typeof(string));
                dt.Columns[Col_CustomerCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_CustRateGrpCode, typeof(string));
                dt.Columns[Col_CustRateGrpCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SupplierCd, typeof(string));
                dt.Columns[Col_SupplierCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_LotCount, typeof(Double));
                dt.Columns[Col_LotCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_PriceFl, typeof(Double));
                dt.Columns[Col_PriceFl].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_RateVal, typeof(Double));
                dt.Columns[Col_RateVal].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_UpRate, typeof(Double));
                dt.Columns[Col_UpRate].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_GrsProfitSecureRate, typeof(Double));
                dt.Columns[Col_GrsProfitSecureRate].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_UnPrcFracProcUnit, typeof(Double));
                dt.Columns[Col_UnPrcFracProcUnit].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_UnPrcFracProcDiv, typeof(Int32));
                dt.Columns[Col_UnPrcFracProcDiv].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_IsErrRateProtyMng, typeof(string));
                dt.Columns[Col_IsErrRateProtyMng].DefaultValue = defValuestring;

                dt.Columns.Add(Col_IsErrGoodsU, typeof(string));
                dt.Columns[Col_IsErrGoodsU].DefaultValue = defValuestring;

                dt.Columns.Add(Col_IsAllZero, typeof(string));
                dt.Columns[Col_IsAllZero].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Content, typeof(string));
                dt.Columns[Col_Content].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerCdForPrint, typeof(string));
                dt.Columns[Col_GoodsMakerCdForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNoForPrint, typeof(string));
                dt.Columns[Col_GoodsNoForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsRateRankForPrint, typeof(string));
                dt.Columns[Col_GoodsRateRankForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsRateGrpCodeForPrint, typeof(string));
                dt.Columns[Col_GoodsRateGrpCodeForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BLGroupCodeForPrint, typeof(string));
                dt.Columns[Col_BLGroupCodeForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BLGoodsCodeForPrint, typeof(string));
                dt.Columns[Col_BLGoodsCodeForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_CustomerCodeForPrint, typeof(string));
                dt.Columns[Col_CustomerCodeForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_CustRateGrpCodeForPrint, typeof(string));
                dt.Columns[Col_CustRateGrpCodeForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SupplierCdForPrint, typeof(string));
                dt.Columns[Col_SupplierCdForPrint].DefaultValue = defValuestring;

            }
        }
    }
}
