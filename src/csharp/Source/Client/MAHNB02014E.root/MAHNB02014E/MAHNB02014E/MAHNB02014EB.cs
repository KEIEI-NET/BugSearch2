using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// �����ꗗ�\�����f�[�^�p�e�[�u���X�L�[�}��`�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����ꗗ�\�̈����f�[�^�p�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
	/// <br>Programmer : 22013 �v�ہ@����</br>
	/// <br>Date       : 2007.03.05</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MAHNB02014EB
	{
		#region �� Static Const

		/// <summary> �e�[�u������ </summary>
		public const string ct_Tbl_DepositAlw				= "Tbl_DepositAlw";

		/// <summary> �����[�V�������� </summary>
		public const string ct_Rel_DepositAlw				= "Rel_DepositAlw";

		/// <summary> �����݌v��� </summary>
		public const string ct_Col_ReconcileAddUpDate		= "ReconcileAddUpDate";

		/// <summary> �󒍔ԍ� </summary>
		public const string ct_Col_AcceptAnOrderNo			= "AcceptAnOrderNo";
		
		/// <summary> �󒍃X�e�[�^�X </summary>
		public const string ct_Col_AcptAnOdrStatus			= "AcptAnOdrStatus";
		
		/// <summary> ����`�[��� </summary>
		public const string ct_Col_SalesSlipKind			= "SalesSlipKind";
		
		/// <summary> �󒍃X�e�[�^�X���� </summary>
		public const string ct_Col_AcptAnOdrStatusName		= "AcptAnOdrStatusName";

		/// <summary> ����`�[�ԍ� </summary>
		public const string ct_Col_SalesSlipNum				= "SalesSlipNum";
		
		/// <summary> ����`�[�ԍ� </summary>
		public const string ct_Col_AcptAnOdrSlipNum			= "AcptAnOdrSlipNum";
		
		/// <summary> ���ϓ`�[�ԍ� </summary>
		public const string ct_Col_EstimateSlipNo			= "EstimateSlipNo";
		
		/// <summary> �����`�[�ԍ� </summary>
		public const string ct_Col_SearchSlipNo				= "SearchSlipNo";

		/// <summary> �ԓ`�敪 </summary>
		/// <remarks>0:���`,1:�ԓ`,2:����</remarks>
		public const string ct_Col_DebitNoteDiv				= "DebitNoteDiv";
		
		/// <summary> �ԓ`�敪���� </summary>
		public const string ct_Col_DebitNoteDivName			= "DebitNoteDivName";
		
		/// <summary> �ԍ��A���󒍔ԍ� </summary>
		/// <remarks>�ԍ��̑�����󒍔ԍ�</remarks>
		public const string ct_Col_DebitNLnkAcptAnOdr		= "DebitNLnkAcptAnOdr";
		
		/// <summary> ����`�[�敪 </summary>
		/// <remarks>0:����,1:�ԕi,2:�l��</remarks>
		public const string ct_Col_SalesSlipCd				= "SalesSlipCd";
		
		/// <summary> ����`�[�敪���� </summary>
		public const string ct_Col_SalesSlipCdName			= "SalesSlipCdName";
		
		/// <summary> ����`�� </summary>
		/// <remarks>10:�X������,11:�O��,20:�Ɩ��̔��i���؁j</remarks>
		public const string ct_Col_SalesFormal				= "SalesFormal";
		
		/// <summary> ����`������ </summary>
		public const string ct_Col_SalesFormalName			= "SalesFormalName";
		
		/// <summary> ������͋��_�R�[�h </summary>
		public const string ct_Col_SalesInpSecCd			= "SalesInpSecCd";
		
		/// <summary> ������͋��_���� </summary>
		/// <remarks>���K�C�h����</remarks>
		public const string ct_Col_SalesInpSecNm			= "SalesInpSecNm";
		
		/// <summary> �����v�㋒�_�R�[�h </summary>
		public const string ct_Col_ResultsAddUpSecCd		= "ResultsAddUpSecCd";
		
		/// <summary> �����v�㋒�_���� </summary>
		/// <remarks>���K�C�h����</remarks>
		public const string ct_Col_ResultsAddUpSecNm		= "ResultsAddUpSecNm";
		
		/// <summary> ���ьv�㋒�_�R�[�h </summary>
		public const string ct_Col_UpdateSecCd				= "UpdateSecCd";
		
		/// <summary> ���ьv�㋒�_���� </summary>
		/// <remarks>���K�C�h����</remarks>
		public const string ct_Col_UpdateSecNm				= "UpdateSecNm";
		
		/// <summary> ���ϓ��t </summary>
		public const string ct_Col_EstimateDate				= "EstimateDate";

		/// <summary> �\�[�g�p���ϓ��t </summary>
		public const string ct_Col_Sort_EstimateDate		= "Sort_EstimateDate";

		/// <summary> �󒍓� </summary>
		public const string ct_Col_AcceptAnOrderDate		= "AcceptAnOrderDate";
		
		/// <summary> �\�[�g�p�󒍓� </summary>
		public const string ct_Col_Sort_AcceptAnOrderDate	= "Sort_AcceptAnOrderDate";
		
		/// <summary> ������t </summary>
		public const string ct_Col_SalesDate				= "SalesDate";
		
		/// <summary> �\�[�g�p������t </summary>
		public const string ct_Col_Sort_SalesDate			= "Sort_SalesDate";
		
		/// <summary> ����v����t </summary>
		public const string ct_Col_SalesAddUpADate			= "SalesAddUpADate";

		/// <summary> �\�[�g�p����v����t </summary>
		public const string ct_Col_Sort_SalesAddUpADate		= "Sort_SalesAddUpADate";
		
		/// <summary> ���|�敪 </summary>
		/// <remarks>0:���|�Ȃ�,1:���|</remarks>
		public const string ct_Col_AccRecDivCd				= "AccRecDivCd";
		
		/// <summary> ���|�敪���� </summary>
		public const string ct_Col_AccRecDivCdName			= "AccRecDivCdName";
		
		/// <summary> �������v�z </summary>
		/// <remarks>�`�[�S�̂̐������v�i�N���W�b�g�萔���͊܂܂Ȃ��j</remarks>
		public const string ct_Col_DemandableTtl			= "DemandableTtl";
		
		/// <summary> �����������v�z </summary>
		/// <remarks>�a����������v�z���܂�</remarks>
		public const string ct_Col_DepositAllowanceTtl		= "DepositAllowanceTtl";
		
		/// <summary> �a����������v�z </summary>	
		public const string ct_Col_MnyDepoAllowanceTtl		= "MnyDepoAllowanceTtl";
		
		/// <summary> ���������c�� </summary>
		public const string ct_Col_DepositAlwcBlnce			= "DepositAlwcBlnce";
		
		/// <summary> ������� </summary>
		/// <remarks> 0:������, 1:�ꕔ����, 2:������</remarks>
		public const string ct_Col_AllowanceState			= "AllowanceState";
		
		/// <summary> ������Ԗ��� </summary>
		public const string ct_Col_AllowanceStateName		= "AllowanceStateName";
		
		/// <summary> ������R�[�h </summary>
		public const string ct_Col_ClaimCode				= "ClaimCode";
		
		/// <summary> �����於��1 </summary>
		public const string ct_Col_ClaimName1				= "ClaimName1";
		
		/// <summary> �����於��2 </summary>
		public const string ct_Col_ClaimName2				= "ClaimName2";
		
		/// <summary> ���Ӑ�R�[�h </summary>
		public const string ct_Col_CustomerCode				= "CustomerCode";
		
		/// <summary> ���Ӑ於�� </summary>
		public const string ct_Col_CustomerName				= "CustomerName";
		
		/// <summary> ���Ӑ於��2 </summary>
		public const string ct_Col_CustomerName2			= "CustomerName2";
		
		/// <summary> �h�� </summary>
		public const string ct_Col_HonorificTitle			= "HonorificTitle";
		
		/// <summary> �J�i </summary>
		public const string ct_Col_Kana						= "Kana";

		/// <summary> �����v�㋒�_�R�[�h </summary>
		public const string ct_Col_DepositAddupSecCd		= "DepositAddupSecCd";

		/// <summary> �����v�㋒�_���� </summary>
		public const string ct_Col_DepositAddupSecNm		= "DepositAddupSecNm";

		/// <summary> �����`�[�ԍ� </summary>
		public const string ct_Col_DepositSlipNo			= "DepositSlipNo";

		#endregion

		#region �� Constructor
		/// <summary>
		/// �����ꗗ�\�����f�[�^�p�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����ꗗ�\�����f�[�^�p�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
		/// <br>Programmer : 22013 �v�ہ@����</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public MAHNB02014EB()
		{
		}
		#endregion

		#region �� Static Public Method
		#region �� CreateDataTable(ref DataSet ds)
		/// <summary>
		/// ����DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="ds">�ݒ�Ώۃf�[�^�Z�b�g</param>
		/// <remarks>
		/// <br>Note       : �����f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
		/// <br>Programmer : 22013 �v�ہ@����</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		static public void CreateDataTableDepositAllowance(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// �e�[�u�������݂��邩�ǂ����̃`�F�b�N
			if ( ds.Tables.Contains( ct_Tbl_DepositAlw ) )
			{
				// �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				ds.Tables[ct_Tbl_DepositAlw].Clear();
			}
			else
			{
				// �X�L�[�}�ݒ�
				ds.Tables.Add(ct_Tbl_DepositAlw);
				DataTable dt = ds.Tables[ct_Tbl_DepositAlw];

				dt.Columns.Add(ct_Col_ReconcileAddUpDate		, typeof(string));		// �����݌v���
				dt.Columns[ct_Col_ReconcileAddUpDate			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_AcceptAnOrderNo			, typeof(int));			// �󒍔ԍ�
				dt.Columns[ct_Col_AcceptAnOrderNo				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AcptAnOdrStatus			, typeof(int));			// �󒍃X�e�[�^�X
				dt.Columns[ct_Col_AcptAnOdrStatus				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_SalesSlipKind				, typeof(int));			// ����`�[���
				dt.Columns[ct_Col_SalesSlipKind					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AcptAnOdrStatusName		, typeof(string));		// �󒍃X�e�[�^�X����
				dt.Columns[ct_Col_AcptAnOdrStatusName			].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_SalesSlipNum				, typeof(string));		// ����`�[�ԍ�
				dt.Columns[ct_Col_SalesSlipNum					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_AcptAnOdrSlipNum			, typeof(string));		// ����`�[�ԍ�
				dt.Columns[ct_Col_AcptAnOdrSlipNum				].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_EstimateSlipNo			, typeof(string));		// ���ϓ`�[�ԍ�
				dt.Columns[ct_Col_EstimateSlipNo				].DefaultValue = "";		

				dt.Columns.Add(ct_Col_SearchSlipNo				, typeof(string));		// �����`�[�ԍ�
				dt.Columns[ct_Col_SearchSlipNo					].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_DebitNoteDiv				, typeof(int));			// �ԓ`�敪
				dt.Columns[ct_Col_DebitNoteDiv					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_DebitNoteDivName			, typeof(string));		// �ԓ`�敪����
				dt.Columns[ct_Col_DebitNoteDivName				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_DebitNLnkAcptAnOdr		, typeof(int));			// �ԍ��A���󒍔ԍ�
				dt.Columns[ct_Col_DebitNLnkAcptAnOdr			].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_SalesSlipCd				, typeof(int));			// ����`�[�敪
				dt.Columns[ct_Col_SalesSlipCd					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_SalesSlipCdName			, typeof(string));		// ����`�[�敪����
				dt.Columns[ct_Col_SalesSlipCdName				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_SalesFormal				, typeof(int));			// ����`��
				dt.Columns[ct_Col_SalesFormal					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_SalesFormalName			, typeof(string));		// ����`��
				dt.Columns[ct_Col_SalesFormalName				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_SalesInpSecCd				, typeof(string));		// ������͋��_�R�[�h
				dt.Columns[ct_Col_SalesInpSecCd					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_SalesInpSecNm				, typeof(string));		// ������͋��_����
				dt.Columns[ct_Col_SalesInpSecNm					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_ResultsAddUpSecCd			, typeof(string));		// �����v�㋒�_�R�[�h
				dt.Columns[ct_Col_ResultsAddUpSecCd				].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_ResultsAddUpSecNm			, typeof(string));		// �����v�㋒�_����
				dt.Columns[ct_Col_ResultsAddUpSecNm				].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_UpdateSecCd				, typeof(string));		// ���ьv�㋒�_�R�[�h
				dt.Columns[ct_Col_UpdateSecCd					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_UpdateSecNm				, typeof(string));		// ���ьv�㋒�_����
				dt.Columns[ct_Col_UpdateSecNm					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_EstimateDate				, typeof(string));		// ���ϓ��t
				dt.Columns[ct_Col_EstimateDate					].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_Sort_EstimateDate			, typeof(long));		// �\�[�g�p���ϓ��t
				dt.Columns[ct_Col_EstimateDate					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AcceptAnOrderDate			, typeof(string));		// �󒍓�
				dt.Columns[ct_Col_AcceptAnOrderDate				].DefaultValue = "";		

				dt.Columns.Add(ct_Col_Sort_AcceptAnOrderDate	, typeof(long));		// �\�[�g�p�󒍓�
				dt.Columns[ct_Col_Sort_AcceptAnOrderDate		].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_SalesDate					, typeof(string));		// ������t
				dt.Columns[ct_Col_SalesDate						].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_Sort_SalesDate			, typeof(long));		// �\�[�g�p������t
				dt.Columns[ct_Col_Sort_SalesDate				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_SalesAddUpADate			, typeof(string));		// ����v����t
				dt.Columns[ct_Col_SalesAddUpADate				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_Sort_SalesAddUpADate		, typeof(long));		// �\�[�g�p����v����t
				dt.Columns[ct_Col_Sort_SalesAddUpADate			].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AccRecDivCd				, typeof(int));			// ���|�敪
				dt.Columns[ct_Col_AccRecDivCd					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AccRecDivCdName			, typeof(string));		// ���|�敪����
				dt.Columns[ct_Col_AccRecDivCdName				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_DemandableTtl				, typeof(long));		// �������v�z
				dt.Columns[ct_Col_DemandableTtl					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_DepositAllowanceTtl		, typeof(long));		// �����������v�z
				dt.Columns[ct_Col_DepositAllowanceTtl			].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_MnyDepoAllowanceTtl		, typeof(long));		// �a����������v�z
				dt.Columns[ct_Col_MnyDepoAllowanceTtl			].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_DepositAlwcBlnce			, typeof(long));		// ���������c��
				dt.Columns[ct_Col_DepositAlwcBlnce				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AllowanceState			, typeof(int));			// �������
				dt.Columns[ct_Col_AllowanceState				].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_AllowanceStateName		, typeof(string));		// ������Ԗ���
				dt.Columns[ct_Col_AllowanceStateName			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_ClaimCode					, typeof(int));			// ������R�[�h
				dt.Columns[ct_Col_ClaimCode						].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_ClaimName1				, typeof(string));		// �����於��1
				dt.Columns[ct_Col_ClaimName1					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_ClaimName2				, typeof(string));		// �����於��2
				dt.Columns[ct_Col_ClaimName2					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_CustomerCode				, typeof(int));			// ���Ӑ�R�[�h
				dt.Columns[ct_Col_CustomerCode					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_CustomerName				, typeof(string));		// ���Ӑ於��
				dt.Columns[ct_Col_CustomerName					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_CustomerName2				, typeof(string));		// ���Ӑ於��2
				dt.Columns[ct_Col_CustomerName2					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_HonorificTitle			, typeof(string));		// �h��
				dt.Columns[ct_Col_HonorificTitle				].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_Kana						, typeof(string));		// �J�i
				dt.Columns[ct_Col_Kana							].DefaultValue = "";

				dt.Columns.Add(ct_Col_DepositAddupSecCd			, typeof(string));		// �����v�㋒�_�R�[�h
				dt.Columns[ct_Col_DepositAddupSecCd				].DefaultValue = "";	

				dt.Columns.Add(ct_Col_DepositAddupSecNm			, typeof(string));		// �����v�㋒�_����
				dt.Columns[ct_Col_DepositAddupSecNm				].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_DepositSlipNo				, typeof(int));			// �����`�[�ԍ�
				dt.Columns[ct_Col_DepositSlipNo					].DefaultValue = 0;		
				
		}

		}
		#endregion
		#endregion

	}
}
