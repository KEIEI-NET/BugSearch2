//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[�����ѕ\
// �v���O�����T�v   : �L�����y�[�����ѕ\�@�e�[�u���X�L�[�}���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/05/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// �L�����y�[�����ѕ\�e�[�u���X�L�[�}��`�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �L�����y�[�����ѕ\�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
	/// <br>Programmer : �c����</br>
	/// <br>Date       : 2011/05/19</br>
	/// </remarks>
	public class PMKHN02054EA
	{
		#region �� Public Const

		/// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_CampaignData = "Tbl_CampaignData";

        /// <summary> ����߰݃R�[�h </summary>
        public const string ct_Col_CampaignCode = "CampaignCode";
        /// <summary> ����߰ݖ��� </summary>
        public const string ct_Col_CampaignName = "CampaignName";
        /// <summary> ����߰ݓK�p�� </summary>
        public const string ct_Col_ApplyDate = "ApplyDate";
        /// <summary> ���ьv�㋒�_�R�[�h </summary>
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        /// <summary> ���_���� </summary>
        public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        /// <summary> �Ǘ����_�R�[�h </summary>
        public const string ct_Col_ManageSectionCode = "ManageSectionCode";
        /// <summary> �Ǘ����_���� </summary>
        public const string ct_Col_ManageSectionNm = "ManageSectionNm";
        /// <summary> ���Ӑ�R�[�h </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> ���Ӑ於�� </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> �]�ƈ��R�[�h </summary>
        public const string ct_Col_EmployeeCode = "EmployeeCode";
        /// <summary> �]�ƈ����� </summary>
        public const string ct_Col_EmployeeName = "EmployeeName";
        /// <summary> �n��R�[�h </summary>
        public const string ct_Col_AreaCode = "AreaCode";
        /// <summary> �n�於�� </summary>
        public const string ct_Col_AreaName = "AreaName";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> BL���i�R�[�h </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> BL���i�R�[�h���́i���p�j </summary>
        public const string ct_Col_BLGoodsHalfName = "BLGoodsHalfName";
        /// <summary> BL�O���[�v�R�[�h </summary>
        public const string ct_Col_BLGroupCode = "BLGroupCode";
        /// <summary> BL�O���[�v���� </summary>
        public const string ct_Col_BLGroupKanaName = "BLGroupKanaName";
        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> ���[�J�[����</summary>
        public const string ct_Col_MakerShortName = "MakerShortName";
        /// <summary> �o�א� </summary>
        public const string ct_Col_TotalSalesCount = "TotalSalesCount";
        /// <summary> ������z</summary>
        public const string ct_Col_TotalSalesMoney = "TotalSalesMoney";
        /// <summary> �ڕW��</summary>
        public const string ct_Col_GoalsCount = "GoalsCount";
        /// <summary> �ڕW�z</summary>
        public const string ct_Col_GoalsMoney = "GoalsMoney";
        /// <summary> �e�����z</summary>
        public const string ct_Col_GrossProfit = "GrossProfit";
        /// <summary> �e����</summary>
        public const string ct_Col_GrossRate = "GrossRate";

        /// <summary> ���㐔�v1 </summary>
        public const string ct_Col_TotalSalesCount1 = "TotalSalesCount1";
        /// <summary> ���㐔�v2 </summary>
        public const string ct_Col_TotalSalesCount2 = "TotalSalesCount2";
        /// <summary> ���㐔�v3 </summary>
        public const string ct_Col_TotalSalesCount3 = "TotalSalesCount3";
        /// <summary> ���㐔�v4 </summary>
        public const string ct_Col_TotalSalesCount4 = "TotalSalesCount4";
        /// <summary> ���㐔�v5 </summary>
        public const string ct_Col_TotalSalesCount5 = "TotalSalesCount5";
        /// <summary> ���㐔�v6 </summary>
        public const string ct_Col_TotalSalesCount6 = "TotalSalesCount6";
        /// <summary> ���㐔�v7 </summary>
        public const string ct_Col_TotalSalesCount7 = "TotalSalesCount7";
        /// <summary> ���㐔�v8 </summary>
        public const string ct_Col_TotalSalesCount8 = "TotalSalesCount8";
        /// <summary> ���㐔�v9 </summary>
        public const string ct_Col_TotalSalesCount9 = "TotalSalesCount9";
        /// <summary> ���㐔�v10 </summary>
        public const string ct_Col_TotalSalesCount10 = "TotalSalesCount10";
        /// <summary> ���㐔�v11 </summary>
        public const string ct_Col_TotalSalesCount11 = "TotalSalesCount11";
        /// <summary> ���㐔�v12 </summary>
        public const string ct_Col_TotalSalesCount12 = "TotalSalesCount12";
        /// <summary> ������z1 �Ŕ��� </summary>
        public const string ct_Col_SalesMoney1 = "SalesMoney1";
        /// <summary> ������z2</summary>
        public const string ct_Col_SalesMoney2 = "SalesMoney2";
        /// <summary> ������z3</summary>
        public const string ct_Col_SalesMoney3 = "SalesMoney3";
        /// <summary> ������z4</summary>
        public const string ct_Col_SalesMoney4 = "SalesMoney4";
        /// <summary> ������z5</summary>
        public const string ct_Col_SalesMoney5 = "SalesMoney5";
        /// <summary> ������z6</summary>
        public const string ct_Col_SalesMoney6 = "SalesMoney6";
        /// <summary> ������z7</summary>
        public const string ct_Col_SalesMoney7 = "SalesMoney7";
        /// <summary> ������z8</summary>
        public const string ct_Col_SalesMoney8 = "SalesMoney8";
        /// <summary> ������z9</summary>
        public const string ct_Col_SalesMoney9 = "SalesMoney9";
        /// <summary> ������z10</summary>
        public const string ct_Col_SalesMoney10 = "SalesMoney10";
        /// <summary> ������z11</summary>
        public const string ct_Col_SalesMoney11 = "SalesMoney11";
        /// <summary> ������z12</summary>
        public const string ct_Col_SalesMoney12 = "SalesMoney12";
        /// <summary> �e���z1</summary>
        public const string ct_Col_GrossProfit1 = "GrossProfit1";
        /// <summary> �e���z2</summary>
        public const string ct_Col_GrossProfit2 = "GrossProfit2";
        /// <summary> �e���z3</summary>
        public const string ct_Col_GrossProfit3 = "GrossProfit3";
        /// <summary> �e���z4</summary>
        public const string ct_Col_GrossProfit4 = "GrossProfit4";
        /// <summary> �e���z5</summary>
        public const string ct_Col_GrossProfit5 = "GrossProfit5";
        /// <summary> �e���z6</summary>
        public const string ct_Col_GrossProfit6 = "GrossProfit6";
        /// <summary> �e���z7</summary>
        public const string ct_Col_GrossProfit7 = "GrossProfit7";
        /// <summary> �e���z8</summary>
        public const string ct_Col_GrossProfit8 = "GrossProfit8";
        /// <summary> �e���z9</summary>
        public const string ct_Col_GrossProfit9 = "GrossProfit9";
        /// <summary> �e���z10</summary>
        public const string ct_Col_GrossProfit10 = "GrossProfit10";
        /// <summary> �e���z11</summary>
        public const string ct_Col_GrossProfit11 = "GrossProfit11";
        /// <summary> �e���z12</summary>
        public const string ct_Col_GrossProfit12 = "GrossProfit12";

        /// <summary> �������㐔</summary>
        public const string ct_Col_MonthlySalesCount = "MonthlySalesCount";
        /// <summary> ���ԗ݌v���㐔</summary>
        public const string ct_Col_TermSalesCount = "TermSalesCount";
        /// <summary> �������ʖڕW1</summary>
        public const string ct_Col_MonthlySalesTargetCount1 = "MonthlySalesTargetCount1";
        /// <summary> ���ԗ݌v���ʖڕW1</summary>
        public const string ct_Col_TermSalesTargetCount1 = "TermSalesTargetCount1";
        /// <summary> �������ʖڕW2</summary>
        public const string ct_Col_MonthlySalesTargetCount2 = "MonthlySalesTargetCount2";
        /// <summary> ���ԗ݌v���ʖڕW2</summary>
        public const string ct_Col_TermSalesTargetCount2 = "TermSalesTargetCount2";
        /// <summary> �������ʖڕW3</summary>
        public const string ct_Col_MonthlySalesTargetCount3 = "MonthlySalesTargetCount3";
        /// <summary> ���ԗ݌v���ʖڕW3</summary>
        public const string ct_Col_TermSalesTargetCount3 = "TermSalesTargetCount3";
        /// <summary> �������ʒB����1</summary>
        public const string ct_Col_MonthlySalesCountAchivRate1 = "MonthlySalesCountAchivRate1";
        /// <summary> ���ԗ݌v���ʒB����1</summary>
        public const string ct_Col_TermSalesCountAchivRate1 = "TermSalesCountAchivRate1";
        /// <summary> �������ʒB����2</summary>
        public const string ct_Col_MonthlySalesCountAchivRate2 = "MonthlySalesCountAchivRate2";
        /// <summary> ���ԗ݌v���ʒB����2</summary>
        public const string ct_Col_TermSalesCountAchivRate2 = "TermSalesCountAchivRate2";
        /// <summary> �������ʒB����3</summary>
        public const string ct_Col_MonthlySalesCountAchivRate3 = "MonthlySalesCountAchivRate3";
        /// <summary> ���ԗ݌v���ʒB����3</summary>
        public const string ct_Col_TermSalesCountAchivRate3 = "TermSalesCountAchivRate3";
        /// <summary> ��������z</summary>
        public const string ct_Col_MonthlySalesMoney = "MonthlySalesMoney";
        /// <summary> ���ԗ݌v����z</summary>
        public const string ct_Col_TermSalesMoney = "TermSalesMoney";
        /// <summary> ��������ڕW1</summary>
        public const string ct_Col_MonthlySalesTarget1 = "MonthlySalesTarget1";
        /// <summary> ���ԗ݌v����ڕW1</summary>
        public const string ct_Col_TermSalesTarget1 = "TermSalesTarget1";
        /// <summary> ��������ڕW2</summary>
        public const string ct_Col_MonthlySalesTarget2 = "MonthlySalesTarget2";
        /// <summary> ���ԗ݌v����ڕW2</summary>
        public const string ct_Col_TermSalesTarget2 = "TermSalesTarget2";
        /// <summary> ��������ڕW3</summary>
        public const string ct_Col_MonthlySalesTarget3 = "MonthlySalesTarget3";
        /// <summary> ���ԗ݌v����ڕW3</summary>
        public const string ct_Col_TermSalesTarget3 = "TermSalesTarget3";
        /// <summary> ��������B����1</summary>
        public const string ct_Col_MonthlySalesMoneyAchivRate1 = "MonthlySalesMoneyAchivRate1";
        /// <summary> ���ԗ݌v����B����1</summary>
        public const string ct_Col_TermSalesMoneyAchivRate1 = "TermSalesMoneyAchivRate1";
        /// <summary> ��������B����2</summary>
        public const string ct_Col_MonthlySalesMoneyAchivRate2 = "MonthlySalesMoneyAchivRate2";
        /// <summary> ���ԗ݌v����B����2</summary>
        public const string ct_Col_TermSalesMoneyAchivRate2 = "TermSalesMoneyAchivRate2";
        /// <summary> ��������B����3</summary>
        public const string ct_Col_MonthlySalesMoneyAchivRate3 = "MonthlySalesMoneyAchivRate3";
        /// <summary> ���ԗ݌v����B����3</summary>
        public const string ct_Col_TermSalesMoneyAchivRate3 = "TermSalesMoneyAchivRate3";
        /// <summary> �����e���z</summary>
        public const string ct_Col_MonthlySalesProfit = "MonthlySalesProfit";
        /// <summary> ���ԗ݌v�e���z</summary>
        public const string ct_Col_TermSalesProfit = "TermSalesProfit";
        /// <summary> �����e����</summary>
        public const string ct_Col_MonthlySalesProfitRate = "MonthlySalesProfitRate";
        /// <summary> ���ԗ݌v�e����</summary>
        public const string ct_Col_TermSalesProfitRate = "TermSalesProfitRate";
        /// <summary> �����e���ڕW1</summary>
        public const string ct_Col_MonthlySalesTargetProfit1 = "MonthlySalesTargetProfit1";
        /// <summary> ���ԗ݌v�e���ڕW1</summary>
        public const string ct_Col_TermSalesTargetProfit1 = "TermSalesTargetProfit1";
        /// <summary> �����e���ڕW2</summary>
        public const string ct_Col_MonthlySalesTargetProfit2 = "MonthlySalesTargetProfit2";
        /// <summary> ���ԗ݌v�e���ڕW2</summary>
        public const string ct_Col_TermSalesTargetProfit2 = "TermSalesTargetProfit2";
        /// <summary> �����e���ڕW3</summary>
        public const string ct_Col_MonthlySalesTargetProfit3 = "MonthlySalesTargetProfit3";
        /// <summary> ���ԗ݌v�e���ڕW3</summary>
        public const string ct_Col_TermSalesTargetProfit3 = "TermSalesTargetProfit3";
        /// <summary> �����e���B����1</summary>
        public const string ct_Col_MonthlySalesProfitAchivRate1 = "MonthlySalesProfitAchivRate1";
        /// <summary> ���ԗ݌v�e���B����1</summary>
        public const string ct_Col_TermSalesProfitAchivRate1 = "TermSalesProfitAchivRat1";
        /// <summary> �����e���B����2</summary>
        public const string ct_Col_MonthlySalesProfitAchivRate2 = "MonthlySalesProfitAchivRate2";
        /// <summary> ���ԗ݌v�e���B����2</summary>
        public const string ct_Col_TermSalesProfitAchivRate2 = "TermSalesProfitAchivRat2";
        /// <summary> �����e���B����3</summary>
        public const string ct_Col_MonthlySalesProfitAchivRate3 = "MonthlySalesProfitAchivRate3";
        /// <summary> ���ԗ݌v�e���B����3</summary>
        public const string ct_Col_TermSalesProfitAchivRate3 = "TermSalesProfitAchivRat3";

        #region ����p
        /// <summary> HeaderKey1 (���_�{�S����)</summary>
        public const string ct_Col_HeaderKey1 = "HeaderKey1";
        #endregion

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
		/// �L�����y�[�����ѕ\�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �L�����y�[�����ѕ\�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		public PMKHN02054EA()
		{
		}
		#endregion

		#region �� Static Public Method
		#region �� �L�����y�[�����ѕ\DataSet�e�[�u���X�L�[�}�ݒ�
		/// <summary>
		/// �L�����y�[�����ѕ\DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
		/// <remarks>
		/// <br>Note       : �L�����y�[�����ѕ\�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		static public void CreateDataTable(ref DataTable dt)
		{
			// �e�[�u�������݂��邩�ǂ����̃`�F�b�N
			if ( dt != null )
			{
				// �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				dt.Clear();
			}
			else
			{
				// �X�L�[�}�ݒ�
                dt = new DataTable(ct_Tbl_CampaignData);

                //����߰݃R�[�h
                dt.Columns.Add(ct_Col_CampaignCode, typeof(string));
                dt.Columns[ct_Col_CampaignCode].DefaultValue = "";
                //����߰ݖ���
                dt.Columns.Add(ct_Col_CampaignName, typeof(string));
                dt.Columns[ct_Col_CampaignName].DefaultValue = "";
                //����߰ݓK�p��
                dt.Columns.Add(ct_Col_ApplyDate, typeof(string));
                dt.Columns[ct_Col_ApplyDate].DefaultValue = "";

                //���ьv�㋒�_�R�[�h
				dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = "";
                //���_�K�C�h����
                dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";
                //�Ǘ����_�R�[�h 
                dt.Columns.Add(ct_Col_ManageSectionCode, typeof(string));
                dt.Columns[ct_Col_ManageSectionCode].DefaultValue = "";
                //�Ǘ����_���� 
                dt.Columns.Add(ct_Col_ManageSectionNm, typeof(string));
                dt.Columns[ct_Col_ManageSectionNm].DefaultValue = "";
                //���Ӑ�R�[�h
                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                //���Ӑ旪��
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";
                //�]�ƈ��R�[�h
                dt.Columns.Add(ct_Col_EmployeeCode, typeof(string));
                dt.Columns[ct_Col_EmployeeCode].DefaultValue = "";
                //�]�ƈ�����
                dt.Columns.Add(ct_Col_EmployeeName, typeof(string));
                dt.Columns[ct_Col_EmployeeName].DefaultValue = "";
                //�n��R�[�h
                dt.Columns.Add(ct_Col_AreaCode, typeof(Int32));
                dt.Columns[ct_Col_AreaCode].DefaultValue = 0;
                //�n�於��
                dt.Columns.Add(ct_Col_AreaName, typeof(string));
                dt.Columns[ct_Col_AreaName].DefaultValue = "";
                //���i�ԍ�
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";
                // ���i����
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = "";
                //BL���i�R�[�h
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;
                //BL���i�R�[�h���́i���p�j
                dt.Columns.Add(ct_Col_BLGoodsHalfName, typeof(string));
                dt.Columns[ct_Col_BLGoodsHalfName].DefaultValue = "";
                //BL�O���[�v�R�[�h
                dt.Columns.Add(ct_Col_BLGroupCode, typeof(Int32)); 
                dt.Columns[ct_Col_BLGroupCode].DefaultValue = 0;
                //BL�O���[�v�R�[�h����
                dt.Columns.Add(ct_Col_BLGroupKanaName, typeof(string));
                dt.Columns[ct_Col_BLGroupKanaName].DefaultValue = "";
                //���i���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;
                //���i���[�J�[����
                dt.Columns.Add(ct_Col_MakerShortName, typeof(string));
                dt.Columns[ct_Col_MakerShortName].DefaultValue = "";
                //���㐔�v
                dt.Columns.Add(ct_Col_TotalSalesCount, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount].DefaultValue = 0;
                //������z
                dt.Columns.Add(ct_Col_TotalSalesMoney, typeof(Int64));
                dt.Columns[ct_Col_TotalSalesMoney].DefaultValue = 0;
                //�ڕW��
                dt.Columns.Add(ct_Col_GoalsCount, typeof(double));
                dt.Columns[ct_Col_GoalsCount].DefaultValue = 0;
                //�ڕW�z
                dt.Columns.Add(ct_Col_GoalsMoney, typeof(Int64));
                dt.Columns[ct_Col_GoalsMoney].DefaultValue = 0;
                //�e�����z
                dt.Columns.Add(ct_Col_GrossProfit, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit].DefaultValue = 0;
                //�e����
                dt.Columns.Add(ct_Col_GrossRate, typeof(double));
                dt.Columns[ct_Col_GrossRate].DefaultValue = 0;

                //���㐔�v1
                dt.Columns.Add(ct_Col_TotalSalesCount1, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount1].DefaultValue = 0;
                //���㐔�v2
                dt.Columns.Add(ct_Col_TotalSalesCount2, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount2].DefaultValue = 0;
                //���㐔�v3
                dt.Columns.Add(ct_Col_TotalSalesCount3, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount3].DefaultValue = 0;
                //���㐔�v4
                dt.Columns.Add(ct_Col_TotalSalesCount4, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount4].DefaultValue = 0;
                //���㐔�v5
                dt.Columns.Add(ct_Col_TotalSalesCount5, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount5].DefaultValue = 0;
                //���㐔�v6
                dt.Columns.Add(ct_Col_TotalSalesCount6, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount6].DefaultValue = 0;
                //���㐔�v7
                dt.Columns.Add(ct_Col_TotalSalesCount7, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount7].DefaultValue = 0;
                //���㐔�v8
                dt.Columns.Add(ct_Col_TotalSalesCount8, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount8].DefaultValue = 0;
                //���㐔�v9
                dt.Columns.Add(ct_Col_TotalSalesCount9, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount9].DefaultValue = 0;
                //���㐔�v10
                dt.Columns.Add(ct_Col_TotalSalesCount10, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount10].DefaultValue = 0;
                //���㐔�v11
                dt.Columns.Add(ct_Col_TotalSalesCount11, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount11].DefaultValue = 0;
                //���㐔�v12
                dt.Columns.Add(ct_Col_TotalSalesCount12, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount12].DefaultValue = 0;
                //������z1
                dt.Columns.Add(ct_Col_SalesMoney1, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney1].DefaultValue = 0;
                //������z2
                dt.Columns.Add(ct_Col_SalesMoney2, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney2].DefaultValue = 0;
                //������z3
                dt.Columns.Add(ct_Col_SalesMoney3, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney3].DefaultValue = 0;
                //������z4
                dt.Columns.Add(ct_Col_SalesMoney4, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney4].DefaultValue = 0;
                //������z5
                dt.Columns.Add(ct_Col_SalesMoney5, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney5].DefaultValue = 0;
                //������z6
                dt.Columns.Add(ct_Col_SalesMoney6, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney6].DefaultValue = 0;
                //������z7
                dt.Columns.Add(ct_Col_SalesMoney7, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney7].DefaultValue = 0;
                //������z8
                dt.Columns.Add(ct_Col_SalesMoney8, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney8].DefaultValue = 0;
                //������z9
                dt.Columns.Add(ct_Col_SalesMoney9, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney9].DefaultValue = 0;
                //������z10
                dt.Columns.Add(ct_Col_SalesMoney10, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney10].DefaultValue = 0;
                //������z11
                dt.Columns.Add(ct_Col_SalesMoney11, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney11].DefaultValue = 0;
                //������z12
                dt.Columns.Add(ct_Col_SalesMoney12, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney12].DefaultValue = 0;
                //�e���z1
                dt.Columns.Add(ct_Col_GrossProfit1, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit1].DefaultValue = 0;
                //�e���z2
                dt.Columns.Add(ct_Col_GrossProfit2, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit2].DefaultValue = 0;
                //�e���z3
                dt.Columns.Add(ct_Col_GrossProfit3, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit3].DefaultValue = 0;
                //�e���z4
                dt.Columns.Add(ct_Col_GrossProfit4, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit4].DefaultValue = 0;
                //�e���z5
                dt.Columns.Add(ct_Col_GrossProfit5, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit5].DefaultValue = 0;
                //�e���z6
                dt.Columns.Add(ct_Col_GrossProfit6, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit6].DefaultValue = 0;
                //�e���z7
                dt.Columns.Add(ct_Col_GrossProfit7, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit7].DefaultValue = 0;
                //�e���z8
                dt.Columns.Add(ct_Col_GrossProfit8, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit8].DefaultValue = 0;
                //�e���z9
                dt.Columns.Add(ct_Col_GrossProfit9, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit9].DefaultValue = 0;
                //�e���z10
                dt.Columns.Add(ct_Col_GrossProfit10, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit10].DefaultValue = 0;
                //�e���z11
                dt.Columns.Add(ct_Col_GrossProfit11, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit11].DefaultValue = 0;
                //�e���z12
                dt.Columns.Add(ct_Col_GrossProfit12, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit12].DefaultValue = 0;
                
                // �������㐔
                dt.Columns.Add(ct_Col_MonthlySalesCount, typeof(double));
                dt.Columns[ct_Col_MonthlySalesCount].DefaultValue = 0;
                // ���ԗ݌v���㐔
                dt.Columns.Add(ct_Col_TermSalesCount, typeof(double));
                dt.Columns[ct_Col_TermSalesCount].DefaultValue = 0;
                // �������ʖڕW1
                dt.Columns.Add(ct_Col_MonthlySalesTargetCount1, typeof(double));
                dt.Columns[ct_Col_MonthlySalesTargetCount1].DefaultValue = 0;
                // ���ԗ݌v���ʖڕW1
                dt.Columns.Add(ct_Col_TermSalesTargetCount1, typeof(double));
                dt.Columns[ct_Col_TermSalesTargetCount1].DefaultValue = 0;
                // �������ʖڕW2
                dt.Columns.Add(ct_Col_MonthlySalesTargetCount2, typeof(double));
                dt.Columns[ct_Col_MonthlySalesTargetCount2].DefaultValue = 0;
                // ���ԗ݌v���ʖڕW2
                dt.Columns.Add(ct_Col_TermSalesTargetCount2, typeof(double));
                dt.Columns[ct_Col_TermSalesTargetCount2].DefaultValue = 0;
                // �������ʖڕW3
                dt.Columns.Add(ct_Col_MonthlySalesTargetCount3, typeof(double));
                dt.Columns[ct_Col_MonthlySalesTargetCount3].DefaultValue = 0;
                // ���ԗ݌v���ʖڕW3
                dt.Columns.Add(ct_Col_TermSalesTargetCount3, typeof(double));
                dt.Columns[ct_Col_TermSalesTargetCount3].DefaultValue = 0;
                // �������ʒB����1
                dt.Columns.Add(ct_Col_MonthlySalesCountAchivRate1, typeof(double));
                dt.Columns[ct_Col_MonthlySalesCountAchivRate1].DefaultValue = 0;
                // ���ԗ݌v���ʒB����1
                dt.Columns.Add(ct_Col_TermSalesCountAchivRate1, typeof(double));
                dt.Columns[ct_Col_TermSalesCountAchivRate1].DefaultValue = 0;
                // �������ʒB����2
                dt.Columns.Add(ct_Col_MonthlySalesCountAchivRate2, typeof(double));
                dt.Columns[ct_Col_MonthlySalesCountAchivRate2].DefaultValue = 0;
                // ���ԗ݌v���ʒB����2
                dt.Columns.Add(ct_Col_TermSalesCountAchivRate2, typeof(double));
                dt.Columns[ct_Col_TermSalesCountAchivRate2].DefaultValue = 0;
                // �������ʒB����3
                dt.Columns.Add(ct_Col_MonthlySalesCountAchivRate3, typeof(double));
                dt.Columns[ct_Col_MonthlySalesCountAchivRate3].DefaultValue = 0;
                // ���ԗ݌v���ʒB����3
                dt.Columns.Add(ct_Col_TermSalesCountAchivRate3, typeof(double));
                dt.Columns[ct_Col_TermSalesCountAchivRate3].DefaultValue = 0;
                // ��������z
                dt.Columns.Add(ct_Col_MonthlySalesMoney, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesMoney].DefaultValue = 0;
                // ���ԗ݌v����z
                dt.Columns.Add(ct_Col_TermSalesMoney, typeof(Int64));
                dt.Columns[ct_Col_TermSalesMoney].DefaultValue = 0;
                // ��������ڕW1
                dt.Columns.Add(ct_Col_MonthlySalesTarget1, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesTarget1].DefaultValue = 0;
                // ���ԗ݌v����ڕW1
                dt.Columns.Add(ct_Col_TermSalesTarget1, typeof(Int64));
                dt.Columns[ct_Col_TermSalesTarget1].DefaultValue = 0;
                // ��������B����1
                dt.Columns.Add(ct_Col_MonthlySalesMoneyAchivRate1, typeof(double));
                dt.Columns[ct_Col_MonthlySalesMoneyAchivRate1].DefaultValue = 0;
                // ���ԗ݌v����B����1
                dt.Columns.Add(ct_Col_TermSalesMoneyAchivRate1, typeof(double));
                dt.Columns[ct_Col_TermSalesMoneyAchivRate1].DefaultValue = 0;
                // ��������ڕW2
                dt.Columns.Add(ct_Col_MonthlySalesTarget2, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesTarget2].DefaultValue = 0;
                // ���ԗ݌v����ڕW2
                dt.Columns.Add(ct_Col_TermSalesTarget2, typeof(Int64));
                dt.Columns[ct_Col_TermSalesTarget2].DefaultValue = 0;
                // ��������B����2
                dt.Columns.Add(ct_Col_MonthlySalesMoneyAchivRate2, typeof(double));
                dt.Columns[ct_Col_MonthlySalesMoneyAchivRate2].DefaultValue = 0;
                // ���ԗ݌v����B����2
                dt.Columns.Add(ct_Col_TermSalesMoneyAchivRate2, typeof(double));
                dt.Columns[ct_Col_TermSalesMoneyAchivRate2].DefaultValue = 0;
                // ��������ڕW3
                dt.Columns.Add(ct_Col_MonthlySalesTarget3, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesTarget3].DefaultValue = 0;
                // ���ԗ݌v����ڕW3
                dt.Columns.Add(ct_Col_TermSalesTarget3, typeof(Int64));
                dt.Columns[ct_Col_TermSalesTarget3].DefaultValue = 0;
                // ��������B����3
                dt.Columns.Add(ct_Col_MonthlySalesMoneyAchivRate3, typeof(double));
                dt.Columns[ct_Col_MonthlySalesMoneyAchivRate3].DefaultValue = 0;
                // ���ԗ݌v����B����3
                dt.Columns.Add(ct_Col_TermSalesMoneyAchivRate3, typeof(double));
                dt.Columns[ct_Col_TermSalesMoneyAchivRate3].DefaultValue = 0;
                // �����e���z
                dt.Columns.Add(ct_Col_MonthlySalesProfit, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesProfit].DefaultValue = 0;
                // ���ԗ݌v�e���z
                dt.Columns.Add(ct_Col_TermSalesProfit, typeof(Int64));
                dt.Columns[ct_Col_TermSalesProfit].DefaultValue = 0;
                // �����e����
                dt.Columns.Add(ct_Col_MonthlySalesProfitRate, typeof(double));
                dt.Columns[ct_Col_MonthlySalesProfitRate].DefaultValue = 0;
                // ���ԗ݌v�e����
                dt.Columns.Add(ct_Col_TermSalesProfitRate, typeof(double));
                dt.Columns[ct_Col_TermSalesProfitRate].DefaultValue = 0;
                // �����e���ڕW1
                dt.Columns.Add(ct_Col_MonthlySalesTargetProfit1, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesTargetProfit1].DefaultValue = 0;
                // ���ԗ݌v�e���ڕW1
                dt.Columns.Add(ct_Col_TermSalesTargetProfit1, typeof(Int64));
                dt.Columns[ct_Col_TermSalesTargetProfit1].DefaultValue = 0;
                // �����e���B����1
                dt.Columns.Add(ct_Col_MonthlySalesProfitAchivRate1, typeof(double));
                dt.Columns[ct_Col_MonthlySalesProfitAchivRate1].DefaultValue = 0;
                // ���ԗ݌v�e���B����1
                dt.Columns.Add(ct_Col_TermSalesProfitAchivRate1, typeof(double));
                dt.Columns[ct_Col_TermSalesProfitAchivRate1].DefaultValue = 0;
                // �����e���ڕW2
                dt.Columns.Add(ct_Col_MonthlySalesTargetProfit2, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesTargetProfit2].DefaultValue = 0;
                // ���ԗ݌v�e���ڕW2
                dt.Columns.Add(ct_Col_TermSalesTargetProfit2, typeof(Int64));
                dt.Columns[ct_Col_TermSalesTargetProfit2].DefaultValue = 0;
                // �����e���B����2
                dt.Columns.Add(ct_Col_MonthlySalesProfitAchivRate2, typeof(double));
                dt.Columns[ct_Col_MonthlySalesProfitAchivRate2].DefaultValue = 0;
                // ���ԗ݌v�e���B����2
                dt.Columns.Add(ct_Col_TermSalesProfitAchivRate2, typeof(double));
                dt.Columns[ct_Col_TermSalesProfitAchivRate2].DefaultValue = 0;
                // �����e���ڕW3
                dt.Columns.Add(ct_Col_MonthlySalesTargetProfit3, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesTargetProfit3].DefaultValue = 0;
                // ���ԗ݌v�e���ڕW3
                dt.Columns.Add(ct_Col_TermSalesTargetProfit3, typeof(Int64));
                dt.Columns[ct_Col_TermSalesTargetProfit3].DefaultValue = 0;
                // �����e���B����3
                dt.Columns.Add(ct_Col_MonthlySalesProfitAchivRate3, typeof(double));
                dt.Columns[ct_Col_MonthlySalesProfitAchivRate3].DefaultValue = 0;
                // ���ԗ݌v�e���B����3
                dt.Columns.Add(ct_Col_TermSalesProfitAchivRate3, typeof(double));
                dt.Columns[ct_Col_TermSalesProfitAchivRate3].DefaultValue = 0;

                // HeaderKey1 (���_�{�S����)</summary>
                dt.Columns.Add(ct_Col_HeaderKey1, typeof(string));
                dt.Columns[ct_Col_HeaderKey1].DefaultValue = "";
			}
		}
		#endregion
		#endregion
	}
}
