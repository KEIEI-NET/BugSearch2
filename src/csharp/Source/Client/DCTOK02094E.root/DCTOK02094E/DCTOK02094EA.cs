//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �O�N�Δ�\
// �v���O�����T�v   : �O�N�Δ�\ ���o���ʃf�[�^�e�[�u���X�L�[�}�N���X
//----------------------------------------------------------------------------//
// ����
// ---------------------------------------------------------------------------//
// �Ǘ��ԍ�  11170129-00 ���C�S�� : cheq
// �� �� ��  2015/08/17  �C�����e : RedMine#47029 �O�N�Δ�\�䗦�Z�o�s���̑Ή��@
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// �O�N�Δ�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �O�N�Δ�\�̒��o���ʃe�[�u���X�L�[�}�ł��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.11.25</br>
    /// </remarks>
	public class DCTOK02094EA
	{
		#region Public Members
        /// <summary>�O�N�Δ�\�f�[�^�e�[�u����</summary>
		public const string CT_PrevYearCpDataTable = "PrevYearCpDataTable";
        /// <summary>�O�N�Δ�\�o�b�t�@�f�[�^�e�[�u����</summary>
		public const string CT_PrevYearCpBuffDataTable = "PrevYearCpBuffDataTable";

		#region �O�N�Δ�\�J�������

		/// <summary>�v�㋒�_�R�[�h</summary>
		/// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
		public const string CT_PrevYear_AddUpSecCode = "AddUpSecCode";

		/// <summary>���_�K�C�h����</summary>
		/// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
		public const string CT_PrevYear_SectionGuidNm = "SectionGuidNm";
		
		/// <summary>�]�ƈ��R�[�h</summary>
		/// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
		public const string CT_PrevYear_EmployeeCode = "EmployeeCode";

		/// <summary>�]�ƈ�����</summary>
		/// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
		public const string CT_PrevYear_EmployeeName = "EmployeeName";

		/// <summary>���Ӑ�R�[�h</summary>
		/// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
		public const string CT_PrevYear_CustomerCode = "CustomerCode";

		/// <summary>���Ӑ旪��</summary>
		/// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
		public const string CT_PrevYear_CustomerSnm = "CustomerSnm";

		/// <summary>�Ǝ�R�[�h</summary>
		/// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
		public const string CT_PrevYear_BusinessTypeCode = "BusinessTypeCode";
		
		/// <summary>�Ǝ햼��</summary>
		/// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
		public const string CT_PrevYear_BusinessTypeName = "BusinessTypeName";
		
		/// <summary>�̔��G���A�R�[�h</summary>
		/// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
		public const string CT_PrevYear_SalesAreaCode = "SalesAreaCode";

		/// <summary>�̔��G���A����</summary>
		/// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
        public const string CT_PrevYear_SalesAreaName = "SalesAreaName";

        /// <summary>BL�R�[�h</summary>
        /// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
        public const string CT_PrevYear_BLGoodsCode = "BLGoodsCode";

        /// <summary>BL����</summary>
        /// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
        public const string CT_PrevYear_BLGoodsHalfName = "BLGoodsHalfName";

        /// <summary>���i�啪�ރR�[�h</summary>
        /// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
        public const string CT_PrevYear_GoodsLGroup = "GoodsLGroup";

        /// <summary>���i�啪�ޖ���</summary>
        /// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
        public const string CT_PrevYear_GoodsLGroupName = "GoodsLGroupName";

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
        public const string CT_PrevYear_GoodsMGroup = "GoodsMGroup";

        /// <summary>���i�����ޖ���</summary>
        /// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
        public const string CT_PrevYear_GoodsMGroupName = "GoodsMGroupName";
        
        /// <summary>�O���[�v�R�[�h</summary>
        /// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
        public const string CT_PrevYear_BLGroupCode = "BLGroupCode";

        /// <summary>�O���[�v����</summary>
        /// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
        public const string CT_PrevYear_BLGroupKanaName = "BLGroupKanaName";

		/// <summary>����z(����1������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermSales1 = "ThisTermSales1";

		/// <summary>����z(�O��1������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermSales1 = "FirstTermSales1";

		/// <summary>�����(1������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_SalesRatio1 = "SalesRatio1";

		/// <summary>�e���z(����1������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermGross1 = "ThisTermGross1";

		/// <summary>�e���z(�O��1������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermGross1 = "FirstTermGross1";

		/// <summary>�e����(1������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_GrossRatio1 = "GrossRatio1";

		/// <summary>����z(����2������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermSales2 = "ThisTermSales2";

		/// <summary>����z(�O��2������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermSales2 = "FirstTermSales2";

		/// <summary>�����(2������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_SalesRatio2 = "SalesRatio2";

		/// <summary>�e���z(����2������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermGross2 = "ThisTermGross2";

		/// <summary>�e���z(�O��2������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermGross2 = "FirstTermGross2";

		/// <summary>�e����(2������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_GrossRatio2 = "GrossRatio2";

		/// <summary>����z(����3������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermSales3 = "ThisTermSales3";

		/// <summary>����z(�O��3������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermSales3 = "FirstTermSales3";

		/// <summary>�����(3������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_SalesRatio3 = "SalesRatio3";

		/// <summary>�e���z(����3������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermGross3 = "ThisTermGross3";

		/// <summary>�e���z(�O��3������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermGross3 = "FirstTermGross3";

		/// <summary>�e����(3������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_GrossRatio3 = "GrossRatio3";

		/// <summary>����z(����4������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermSales4 = "ThisTermSales4";

		/// <summary>����z(�O��4������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermSales4 = "FirstTermSales4";

		/// <summary>�����(4������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_SalesRatio4 = "SalesRatio4";

		/// <summary>�e���z(����4������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermGross4 = "ThisTermGross4";

		/// <summary>�e���z(�O��4������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermGross4 = "FirstTermGross4";

		/// <summary>�e����(4������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_GrossRatio4 = "GrossRatio4";

		/// <summary>����z(����5������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermSales5 = "ThisTermSales5";

		/// <summary>����z(�O��5������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermSales5 = "FirstTermSales5";

		/// <summary>�����(5������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_SalesRatio5 = "SalesRatio5";

		/// <summary>�e���z(����5������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermGross5 = "ThisTermGross5";

		/// <summary>�e���z(�O��5������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermGross5 = "FirstTermGross5";

		/// <summary>�e����(5������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_GrossRatio5 = "GrossRatio5";

		/// <summary>����z(����6������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermSales6 = "ThisTermSales6";

		/// <summary>����z(�O��6������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermSales6 = "FirstTermSales6";

		/// <summary>�����(6������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_SalesRatio6 = "SalesRatio6";

		/// <summary>�e���z(����6������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermGross6 = "ThisTermGross6";

		/// <summary>�e���z(�O��6������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermGross6 = "FirstTermGross6";

		/// <summary>�e����(6������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_GrossRatio6 = "GrossRatio6";

		/// <summary>����z(����7������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermSales7 = "ThisTermSales7";

		/// <summary>����z(�O��7������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermSales7 = "FirstTermSales7";

		/// <summary>�����(7������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_SalesRatio7 = "SalesRatio7";

		/// <summary>�e���z(����7������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermGross7 = "ThisTermGross7";

		/// <summary>�e���z(�O��7������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>		
		public const string CT_PrevYear_FirstTermGross7 = "FirstTermGross7";

		/// <summary>�e����(7������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_GrossRatio7 = "GrossRatio7";
		
		/// <summary>����z(����8������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermSales8 = "ThisTermSales8";

		/// <summary>����z(�O��8������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermSales8 = "FirstTermSales8";
		
		/// <summary>�����(8������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_SalesRatio8 = "SalesRatio8";

		/// <summary>�e���z(����8������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermGross8 = "ThisTermGross8";
		
		/// <summary>�e���z(�O��8������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermGross8 = "FirstTermGross8";

		/// <summary>�e����(8������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_GrossRatio8 = "GrossRatio8";
		
		/// <summary>����z(����9������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermSales9 = "ThisTermSales9";

		/// <summary>����z(�O��9������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermSales9 = "FirstTermSales9";
		
		/// <summary>�����(9������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_SalesRatio9 = "SalesRatio9";

		/// <summary>�e���z(����9������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermGross9 = "ThisTermGross9";
		
		/// <summary>�e���z(�O��9������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermGross9 = "FirstTermGross9";

		/// <summary>�e����(9������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_GrossRatio9 = "GrossRatio9";
		
		/// <summary>����z(����10������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermSales10 = "ThisTermSales10";

		/// <summary>����z(�O��10������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermSales10 = "FirstTermSales10";
		
		/// <summary>�����(10������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_SalesRatio10 = "SalesRatio10";

		/// <summary>�e���z(����10������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermGross10 = "ThisTermGross10";

		/// <summary>�e���z(�O��10������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermGross10 = "FirstTermGross10";

		/// <summary>�e����(10������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_GrossRatio10 = "GrossRatio10";

		/// <summary>����z(����11������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermSales11 = "ThisTermSales11";

		/// <summary>����z(�O��11������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermSales11 = "FirstTermSales11";

		/// <summary>�����(11������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_SalesRatio11 = "SalesRatio11";

		/// <summary>�e���z(����11������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermGross11 = "ThisTermGross11";

		/// <summary>�e���z(�O��11������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string  CT_PrevYear_FirstTermGross11 = "FirstTermGross11";

		/// <summary>�e����(11������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_GrossRatio11 = "GrossRatio11";

		/// <summary>����z(����12������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermSales12 = "ThisTermSales12";

		/// <summary>����z(�O��12������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermSales12 = "FirstTermSales12";

		/// <summary>�����(12������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_SalesRatio12 = "SalesRatio12";

		/// <summary>�e���z(����12������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_ThisTermGross12 = "ThisTermGross12";

		/// <summary>�e���z(�O��12������)</summary>
		/// <remarks>���z�P�ʂɊւ�炸�A�~�P�ʂŃZ�b�g</remarks>
		public const string CT_PrevYear_FirstTermGross12 = "FirstTermGross12";

		/// <summary>�e����(12������)</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_GrossRatio12 = "GrossRatio12";

		#region �ȉ������Ōv�Z���鍀��
		
		/// <summary>�������v����z</summary>
		/// <remarks>�����Ōv�Z</remarks>
		public const string CT_PrevYear_thisTermTotalSales = "ThisTermTotalSales";

		/// <summary>�O�����v����z</summary>
		/// <remarks>�����Ōv�Z</remarks>
		public const string CT_PrevYear_firstTermTotalSales = "FirstTermTotalSales";

		/// <summary>Detial:�N�v�����</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_totalSalesRatio = "TotalSalesRatio";

		/// <summary>�������v�e���z</summary>
		/// <remarks>�����Ōv�Z</remarks>
		public const string CT_PrevYear_thisTermTotalGross = "ThisTermTotalGross";

		/// <summary>�O�����v�e���z</summary>
		/// <remarks>�����Ōv�Z</remarks>
		public const string CT_PrevYear_firstTermTotalGross = "FirstTermTotalGross";

		/// <summary>Detial:�N�v�e����</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_totalGrossRatio = "TotalGrossRatio";

		/// <summary>����v:�N�v�����</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_totalSlRaiotSubSec = "TotalSlRaiotSubSec";

		/// <summary>����v:�N�v�e����</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_totalGrsRatioSubSec = "TotalGrsRatioSubSec";

		/// <summary>���_�v:�N�v�����</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_totalSlRatioSec = "TotalSlRatioSec";

		/// <summary>���_�v:�N�v�e����</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_totalGrsRatioSec = "TotalGrsRatioSec";

		/// <summary>�����v:�N�v�����</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_totalSlRatioTtl = "otalSlRatioTtl";

		/// <summary>�����v:�N�v�e����</summary>
		/// <remarks>999.99�`���ŏ����_��O�ʂ��l�̌ܓ�</remarks>
		public const string CT_PrevYear_totalGrsRatioTtl = "TotalGrsRatioTtl";

		#endregion

        /// <summary>
        /// 
        /// </summary>
		public const string COL_KEYBREAK_AR	= "KEYBREAK_AR";				// �L�[�u���C�N

		#endregion

		#endregion

		#region Constructor
		/// <summary>
		/// �O�N�Δ�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �O�N�Δ�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
		public DCTOK02094EA()
		{
		}
		#endregion
		
		#region Public Methods
		/// <summary>
		/// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
		/// </summary>
		public static void SettingDataSet(ref DataSet ds)
		{
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
			if ( (ds.Tables.Contains(CT_PrevYearCpDataTable)) )
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				ds.Tables[CT_PrevYearCpDataTable].Clear();
			}
			else
			{
                CreateSaleConfTable(ref ds, 0);

			}
			
			// ����`�F�b�N���X�g�o�b�t�@�f�[�^�e�[�u��------------------------------------------
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
			if ((ds.Tables.Contains(CT_PrevYearCpBuffDataTable)))
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				ds.Tables[CT_PrevYearCpBuffDataTable].Clear();
			}
			else
			{
                CreateSaleConfTable(ref ds, 1);
			}
		}

		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// �O�N�Δ�\���o���ʍ쐬����
		/// </summary>
		private static void CreateSaleConfTable(ref DataSet ds, int buffCheck)
		{
			DataTable dt = null;
			if(buffCheck == 0)
			{
				// �X�L�[�}�ݒ�
				ds.Tables.Add(CT_PrevYearCpDataTable);
				dt = ds.Tables[CT_PrevYearCpDataTable];
			}
			else
			{
				// �X�L�[�}�ݒ�
				ds.Tables.Add(CT_PrevYearCpBuffDataTable);
				dt = ds.Tables[CT_PrevYearCpBuffDataTable];
			}

				// �v�㋒�_�R�[�h
                dt.Columns.Add(CT_PrevYear_AddUpSecCode, typeof(string));
                dt.Columns[CT_PrevYear_AddUpSecCode].DefaultValue = "";
				// ���_�K�C�h����
                dt.Columns.Add(CT_PrevYear_SectionGuidNm, typeof(string));
                dt.Columns[CT_PrevYear_SectionGuidNm].DefaultValue = "";				
				// �]�ƈ��R�[�h
                dt.Columns.Add(CT_PrevYear_EmployeeCode, typeof(string));
                dt.Columns[CT_PrevYear_EmployeeCode].DefaultValue = "";
				// �]�ƈ�����
                dt.Columns.Add(CT_PrevYear_EmployeeName, typeof(string));
                dt.Columns[CT_PrevYear_EmployeeName].DefaultValue = "";
				// ���Ӑ�R�[�h
                dt.Columns.Add(CT_PrevYear_CustomerCode, typeof(Int32));
                dt.Columns[CT_PrevYear_CustomerCode].DefaultValue = 0;
				// ���Ӑ旪��
                dt.Columns.Add(CT_PrevYear_CustomerSnm, typeof(string));
                dt.Columns[CT_PrevYear_CustomerSnm].DefaultValue = "";
				// �Ǝ�R�[�h
                dt.Columns.Add(CT_PrevYear_BusinessTypeCode, typeof(Int32));
                dt.Columns[CT_PrevYear_BusinessTypeCode].DefaultValue = 0;
				// �Ǝ햼��
                dt.Columns.Add(CT_PrevYear_BusinessTypeName, typeof(string));
                dt.Columns[CT_PrevYear_BusinessTypeName].DefaultValue = "";
				// �̔��G���A�R�[�h
                dt.Columns.Add(CT_PrevYear_SalesAreaCode, typeof(Int32));
                dt.Columns[CT_PrevYear_SalesAreaCode].DefaultValue = 0;
				// �̔��G���A����
                dt.Columns.Add(CT_PrevYear_SalesAreaName, typeof(string));
                dt.Columns[CT_PrevYear_SalesAreaName].DefaultValue = "";
                // BL�R�[�h
                dt.Columns.Add(CT_PrevYear_BLGoodsCode, typeof(Int32));
                dt.Columns[CT_PrevYear_BLGoodsCode].DefaultValue = 0;
                // BL����
                dt.Columns.Add(CT_PrevYear_BLGoodsHalfName, typeof(string));
                dt.Columns[CT_PrevYear_BLGoodsHalfName].DefaultValue = "";
                // ���i�啪�ރR�[�h
                dt.Columns.Add(CT_PrevYear_GoodsLGroup, typeof(Int32));
                dt.Columns[CT_PrevYear_GoodsLGroup].DefaultValue = 0;
                // ���i�啪�ޖ���
                dt.Columns.Add(CT_PrevYear_GoodsLGroupName, typeof(string));
                dt.Columns[CT_PrevYear_GoodsLGroupName].DefaultValue = "";
                // ���i�����ރR�[�h
                dt.Columns.Add(CT_PrevYear_GoodsMGroup, typeof(Int32));
                dt.Columns[CT_PrevYear_GoodsMGroup].DefaultValue = 0;
                // ���i�����ޖ���
                dt.Columns.Add(CT_PrevYear_GoodsMGroupName, typeof(string));
                dt.Columns[CT_PrevYear_GoodsMGroupName].DefaultValue = "";
                // �O���[�v�R�[�h
                dt.Columns.Add(CT_PrevYear_BLGroupCode, typeof(Int32));
                dt.Columns[CT_PrevYear_BLGroupCode].DefaultValue = 0;
                // �O���[�v����
                dt.Columns.Add(CT_PrevYear_BLGroupKanaName, typeof(string));
                dt.Columns[CT_PrevYear_BLGroupKanaName].DefaultValue = "";
				// ����z(����1������)
                dt.Columns.Add(CT_PrevYear_ThisTermSales1, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales1].DefaultValue = 0;
				// ����z(�O��1������)
                dt.Columns.Add(CT_PrevYear_FirstTermSales1, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales1].DefaultValue = 0;
				// �����(1������)
                dt.Columns.Add(CT_PrevYear_SalesRatio1, typeof(Double));
                dt.Columns[CT_PrevYear_SalesRatio1].DefaultValue = 0;
				// �e���z(����1������)
                dt.Columns.Add(CT_PrevYear_ThisTermGross1, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermGross1].DefaultValue = 0;
				// �e���z(�O��1������)
                dt.Columns.Add(CT_PrevYear_FirstTermGross1, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermGross1].DefaultValue = 0;
				// �e����(1������)
                dt.Columns.Add(CT_PrevYear_GrossRatio1, typeof(Double));
                dt.Columns[CT_PrevYear_GrossRatio1].DefaultValue = 0;
				// ����z(����2������)
				dt.Columns.Add(CT_PrevYear_ThisTermSales2, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales2].DefaultValue = 0;
				// ����z(�O��2������)
				dt.Columns.Add(CT_PrevYear_FirstTermSales2, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales2].DefaultValue = 0;
				// �����(2������)
				dt.Columns.Add(CT_PrevYear_SalesRatio2, typeof(Double));
                dt.Columns[CT_PrevYear_SalesRatio2].DefaultValue = 0;
				// �e���z(����2������)
				dt.Columns.Add(CT_PrevYear_ThisTermGross2, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermGross2].DefaultValue = 0;
				// �e���z(�O��2������)
				dt.Columns.Add(CT_PrevYear_FirstTermGross2, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermGross2].DefaultValue = 0;
				// �e����(2������)
				dt.Columns.Add(CT_PrevYear_GrossRatio2, typeof(Double));
                dt.Columns[CT_PrevYear_GrossRatio2].DefaultValue = 0;
				// ����z(����3������)
				dt.Columns.Add(CT_PrevYear_ThisTermSales3, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales3].DefaultValue = 0;
				// ����z(�O��3������)
				dt.Columns.Add(CT_PrevYear_FirstTermSales3, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales3].DefaultValue = 0;
				// �����(3������)
                // dt.Columns.Add(CT_PrevYear_SalesRatio3, typeof(Int64)); // DEL cheq 2015/08/17 for RedMine#47029 �䗦�Z�o�s���̑Ή��@
                dt.Columns.Add(CT_PrevYear_SalesRatio3, typeof(Double)); // ADD  cheq 2015/08/17 for RedMine#47029 �䗦�Z�o�s���̑Ή�
                dt.Columns[CT_PrevYear_SalesRatio3].DefaultValue = 0;
				// �e���z(����3������)
				dt.Columns.Add(CT_PrevYear_ThisTermGross3, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermGross3].DefaultValue = 0;
				// �e���z(�O��3������)
				dt.Columns.Add(CT_PrevYear_FirstTermGross3, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermGross3].DefaultValue = 0;
				// �e����(3������)
				dt.Columns.Add(CT_PrevYear_GrossRatio3, typeof(Double));
                dt.Columns[CT_PrevYear_GrossRatio3].DefaultValue = 0;
				// ����z(����4������)
				dt.Columns.Add(CT_PrevYear_ThisTermSales4, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales4].DefaultValue = 0;
				// ����z(�O��4������)
				dt.Columns.Add(CT_PrevYear_FirstTermSales4, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales4].DefaultValue = 0;
				// �����(4������)
				dt.Columns.Add(CT_PrevYear_SalesRatio4, typeof(Double));
                dt.Columns[CT_PrevYear_SalesRatio4].DefaultValue = 0;
				// �e���z(����4������)
                dt.Columns.Add(CT_PrevYear_ThisTermGross4, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermGross4].DefaultValue = 0;
				// �e���z(�O��4������)
				dt.Columns.Add(CT_PrevYear_FirstTermGross4, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermGross4].DefaultValue = 0;
				// �e����(4������)
				dt.Columns.Add(CT_PrevYear_GrossRatio4, typeof(Double));
                dt.Columns[CT_PrevYear_GrossRatio4].DefaultValue = 0;
				// ����z(����5������)
                dt.Columns.Add(CT_PrevYear_ThisTermSales5, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales5].DefaultValue = 0;
				// ����z(�O��5������)
				dt.Columns.Add(CT_PrevYear_FirstTermSales5, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales5].DefaultValue = 0;
				// �����(5������)
				dt.Columns.Add(CT_PrevYear_SalesRatio5, typeof(Double));
                dt.Columns[CT_PrevYear_SalesRatio5].DefaultValue = 0;
				// �e���z(����5������)
				dt.Columns.Add(CT_PrevYear_ThisTermGross5, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermGross5].DefaultValue = 0;
				// �e���z(�O��5������)
				dt.Columns.Add(CT_PrevYear_FirstTermGross5, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermGross5].DefaultValue = 0;
				// �e����(5������)
				dt.Columns.Add(CT_PrevYear_GrossRatio5, typeof(Double));
                dt.Columns[CT_PrevYear_GrossRatio5].DefaultValue = 0;
				// ����z(����6������)
				dt.Columns.Add(CT_PrevYear_ThisTermSales6, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales6].DefaultValue = 0;
				// ����z(�O��6������)
				dt.Columns.Add(CT_PrevYear_FirstTermSales6, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales6].DefaultValue = 0;
				// �����(6������)
				dt.Columns.Add(CT_PrevYear_SalesRatio6, typeof(Double));
                dt.Columns[CT_PrevYear_SalesRatio6].DefaultValue = 0;
				// �e���z(����6������)
				dt.Columns.Add(CT_PrevYear_ThisTermGross6, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermGross6].DefaultValue = 0;
				// �e���z(�O��6������)
				dt.Columns.Add(CT_PrevYear_FirstTermGross6, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermGross6].DefaultValue = 0;
				// �e����(6������)
				dt.Columns.Add(CT_PrevYear_GrossRatio6, typeof(Double));
                dt.Columns[CT_PrevYear_GrossRatio6].DefaultValue = 0;
				// ����z(����7������)
                dt.Columns.Add(CT_PrevYear_ThisTermSales7, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales7].DefaultValue = 0;
				// ����z(�O��7������)
                dt.Columns.Add(CT_PrevYear_FirstTermSales7, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales7].DefaultValue = 0;
				// �����(7������)
				dt.Columns.Add(CT_PrevYear_SalesRatio7, typeof(Double));
                dt.Columns[CT_PrevYear_SalesRatio7].DefaultValue = 0;
				// �e���z(����7������)
				dt.Columns.Add(CT_PrevYear_ThisTermGross7, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermGross7].DefaultValue = 0;
				// �e���z(�O��7������)
				dt.Columns.Add(CT_PrevYear_FirstTermGross7, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermGross7].DefaultValue = 0;
				// �e����(7������)
				dt.Columns.Add(CT_PrevYear_GrossRatio7, typeof(Double));
				dt.Columns[CT_PrevYear_GrossRatio7].DefaultValue = 0;
				// ����z(����8������)
				dt.Columns.Add(CT_PrevYear_ThisTermSales8, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermSales8].DefaultValue = 0;
				// ����z(�O��8������)
				dt.Columns.Add(CT_PrevYear_FirstTermSales8, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermSales8].DefaultValue = 0;
				// �����(8������)
				dt.Columns.Add(CT_PrevYear_SalesRatio8, typeof(Double));
				dt.Columns[CT_PrevYear_SalesRatio8].DefaultValue = 0;
				// �e���z(����8������)
				dt.Columns.Add(CT_PrevYear_ThisTermGross8, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermGross8].DefaultValue = 0;
				// �e���z(�O��8������)
				dt.Columns.Add(CT_PrevYear_FirstTermGross8, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermGross8].DefaultValue = 0;
				// �e����(8������)
				dt.Columns.Add(CT_PrevYear_GrossRatio8, typeof(Double));
				dt.Columns[CT_PrevYear_GrossRatio8].DefaultValue = 0;
				// ����z(����9������)
				dt.Columns.Add(CT_PrevYear_ThisTermSales9, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermSales9].DefaultValue = 0;
				// ����z(�O��9������)
				dt.Columns.Add(CT_PrevYear_FirstTermSales9, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermSales9].DefaultValue = 0;
				// �����(9������)
				dt.Columns.Add(CT_PrevYear_SalesRatio9, typeof(Double));
				dt.Columns[CT_PrevYear_SalesRatio9].DefaultValue = 0;
				// �e���z(����9������)
				dt.Columns.Add(CT_PrevYear_ThisTermGross9, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermGross9].DefaultValue = 0;
				// �e���z(�O��9������)
				dt.Columns.Add(CT_PrevYear_FirstTermGross9, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermGross9].DefaultValue = 0;
				// �e����(9������)
				dt.Columns.Add(CT_PrevYear_GrossRatio9, typeof(Double));
				dt.Columns[CT_PrevYear_GrossRatio9].DefaultValue = 0;
				// ����z(����10������)
				dt.Columns.Add(CT_PrevYear_ThisTermSales10, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermSales10].DefaultValue = 0;
				// ����z(�O��10������)
				dt.Columns.Add(CT_PrevYear_FirstTermSales10, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermSales10].DefaultValue = 0;
				// �����(10������)
				dt.Columns.Add(CT_PrevYear_SalesRatio10, typeof(Double));
				dt.Columns[CT_PrevYear_SalesRatio10].DefaultValue = 0;
				// �e���z(����10������)
				dt.Columns.Add(CT_PrevYear_ThisTermGross10, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermGross10].DefaultValue = 0;
				// �e���z(�O��10������)
				dt.Columns.Add(CT_PrevYear_FirstTermGross10, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermGross10].DefaultValue = 0;
				// �e����(10������)
				dt.Columns.Add(CT_PrevYear_GrossRatio10, typeof(Double));
				dt.Columns[CT_PrevYear_GrossRatio10].DefaultValue = 0;
				// ����z(����11������)
				dt.Columns.Add(CT_PrevYear_ThisTermSales11, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermSales11].DefaultValue = 0;
				// ����z(�O��11������)
				dt.Columns.Add(CT_PrevYear_FirstTermSales11, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermSales11].DefaultValue = 0;
				// �����(11������)
				dt.Columns.Add(CT_PrevYear_SalesRatio11, typeof(Double));
				dt.Columns[CT_PrevYear_SalesRatio11].DefaultValue = 0;
				// �e���z(����11������)
				dt.Columns.Add(CT_PrevYear_ThisTermGross11, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermGross11].DefaultValue = 0;
				// �e���z(�O��11������)
				dt.Columns.Add(CT_PrevYear_FirstTermGross11, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermGross11].DefaultValue = 0;
				// �e����(11������)
				dt.Columns.Add(CT_PrevYear_GrossRatio11, typeof(Double));
				dt.Columns[CT_PrevYear_GrossRatio11].DefaultValue = 0;
				// ����z(����12������)
				dt.Columns.Add(CT_PrevYear_ThisTermSales12, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermSales12].DefaultValue = 0;
				// ����z(�O��12������)
				dt.Columns.Add(CT_PrevYear_FirstTermSales12, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermSales12].DefaultValue = 0;
				// �����(12������)
				dt.Columns.Add(CT_PrevYear_SalesRatio12, typeof(Double));
				dt.Columns[CT_PrevYear_SalesRatio12].DefaultValue = 0;
				// �e���z(����12������)
				dt.Columns.Add(CT_PrevYear_ThisTermGross12, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermGross12].DefaultValue = 0;
				// �e���z(�O��12������)
				dt.Columns.Add(CT_PrevYear_FirstTermGross12, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermGross12].DefaultValue = 0;
				// �e����(12������)
				dt.Columns.Add(CT_PrevYear_GrossRatio12, typeof(Double));
				dt.Columns[CT_PrevYear_GrossRatio12].DefaultValue = 0;

				// TODO �ȉ������Őݒ肷�鍀��
				// �������v����z
				dt.Columns.Add(CT_PrevYear_thisTermTotalSales, typeof(Int64));
				dt.Columns[CT_PrevYear_thisTermTotalSales].DefaultValue = 0;
				// �O�����v����z
				dt.Columns.Add(CT_PrevYear_firstTermTotalSales, typeof(Int64));
				dt.Columns[CT_PrevYear_firstTermTotalSales].DefaultValue = 0;
				// �N�v�i���v�j�����
				dt.Columns.Add(CT_PrevYear_totalSalesRatio, typeof(Double));
				dt.Columns[CT_PrevYear_totalSalesRatio].DefaultValue = 0;
				// �������v�e���z
				dt.Columns.Add(CT_PrevYear_thisTermTotalGross, typeof(Int64));
				dt.Columns[CT_PrevYear_thisTermTotalGross].DefaultValue = 0;
				// �O�����v�e���z
				dt.Columns.Add(CT_PrevYear_firstTermTotalGross, typeof(Int64));
				dt.Columns[CT_PrevYear_firstTermTotalGross].DefaultValue = 0;
				// �N�v�e����
				dt.Columns.Add(CT_PrevYear_totalGrossRatio, typeof(Double));
				dt.Columns[CT_PrevYear_totalGrossRatio].DefaultValue = 0;
				// ����v:�N�v�����
				dt.Columns.Add(CT_PrevYear_totalSlRaiotSubSec, typeof(Double));
				dt.Columns[CT_PrevYear_totalSlRaiotSubSec].DefaultValue = 0;
				// ����v:�N�v�e����
				dt.Columns.Add(CT_PrevYear_totalGrsRatioSubSec, typeof(Double));
				dt.Columns[CT_PrevYear_totalGrsRatioSubSec].DefaultValue = 0;
				// ���_�v:�N�v�����
				dt.Columns.Add(CT_PrevYear_totalSlRatioSec, typeof(Double));
				dt.Columns[CT_PrevYear_totalSlRatioSec].DefaultValue = 0;
				// ���_�v:�N�v�e����
				dt.Columns.Add(CT_PrevYear_totalGrsRatioSec, typeof(Double));
				dt.Columns[CT_PrevYear_totalGrsRatioSec].DefaultValue = 0;
				// �����v:�N�v�����
				dt.Columns.Add(CT_PrevYear_totalSlRatioTtl, typeof(Double));
				dt.Columns[CT_PrevYear_totalSlRatioTtl].DefaultValue = 0;
				// �����v:�N�v�e����
				dt.Columns.Add(CT_PrevYear_totalGrsRatioTtl, typeof(Double));
				dt.Columns[CT_PrevYear_totalGrsRatioTtl].DefaultValue = 0;
				//// �T�u�^�C�g��
				//dt.Columns.Add(CT_PrevYear_subTitle, typeof(String));
				//dt.Columns[CT_PrevYear_subTitle].DefaultValue = "";


                // �L�[�u���C�N
				dt.Columns.Add(COL_KEYBREAK_AR, typeof(string));
				dt.Columns[COL_KEYBREAK_AR].DefaultValue = "";
		}

		#endregion
	}
}