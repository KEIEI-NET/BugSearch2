//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���ڕW�ݒ�}�X�^�i����j
// �v���O�����T�v   : �L�����y�[���ڕW�ݒ�}�X�^�Őݒ肵�����e���ꗗ�o�͂�
//                    �m�F����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CampTrgtPrintResultWork
    /// <summary>
    ///                      �L�����y�[���ڕW�ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[���ڕW�ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/04/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CampTrgtPrintResultWork 
	{
		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

        /// <summary>�K�p�J�n��</summary>
        /// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _applyStaDate;

        /// <summary>�K�p�I����</summary>
        /// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _applyEndDate;

		/// <summary>�L�����y�[���R�[�h</summary>
		/// <remarks>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</remarks>
		private Int32 _campaignCode;

		/// <summary>�L�����y�[������</summary>
		private string _campaignName = "";

		/// <summary>�ڕW�Δ�敪</summary>
		/// <remarks>10:���_,22:���_+�]�ƈ�,30:���_+���Ӑ�,32:���_+�̔��ر,44:���_+�̔��敪,50:���_+��ٰ�ߺ���,60:���_+BL����</remarks>
		private Int32 _targetContrastCd;

		/// <summary>�]�ƈ��敪</summary>
		/// <remarks>10:�̔��S���� 20:��t�S���� 30:���͒S����</remarks>
		private Int32 _employeeDivCd;

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>���_�K�C�h����</summary>
		/// <remarks>���[�󎚗p</remarks>
		private string _sectionGuideSnm = "";

		/// <summary>�]�ƈ��R�[�h</summary>
		private string _employeeCode = "";

		/// <summary>����</summary>
		private string _name = "";

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>���Ӑ旪��</summary>
		private string _customerSnm = "";

		/// <summary>�̔��G���A�R�[�h</summary>
		/// <remarks>�n��R�[�h</remarks>
		private Int32 _salesAreaCode;

		/// <summary>�̔��G���A�K�C�h����</summary>
		private string _salesAreaName = "";

		/// <summary>BL�O���[�v�R�[�h</summary>
		/// <remarks>���O���[�v�R�[�h</remarks>
		private Int32 _bLGroupCode;

		/// <summary>BL�O���[�v�R�[�h�J�i����</summary>
		/// <remarks>���p�J�i</remarks>
		private string _bLGroupKanaName = "";

		/// <summary>BL���i�R�[�h</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL���i�R�[�h���́i���p�j</summary>
		private string _bLGoodsHalfName = "";

		/// <summary>�̔��敪�R�[�h</summary>
		private Int32 _salesCode;

		/// <summary>�̔��敪�K�C�h����</summary>
		private string _salesCodeName = "";

		/// <summary>����ڕW���z1</summary>
		/// <remarks>1��</remarks>
		private Int64 _salesTargetMoney1;

		/// <summary>����ڕW���z2</summary>
		/// <remarks>2��</remarks>
		private Int64 _salesTargetMoney2;

		/// <summary>����ڕW���z3</summary>
		/// <remarks>3��</remarks>
		private Int64 _salesTargetMoney3;

		/// <summary>����ڕW���z4</summary>
		/// <remarks>4��</remarks>
		private Int64 _salesTargetMoney4;

		/// <summary>����ڕW���z5</summary>
		/// <remarks>5��</remarks>
		private Int64 _salesTargetMoney5;

		/// <summary>����ڕW���z6</summary>
		/// <remarks>6��</remarks>
		private Int64 _salesTargetMoney6;

		/// <summary>����ڕW���z7</summary>
		/// <remarks>7��</remarks>
		private Int64 _salesTargetMoney7;

		/// <summary>����ڕW���z8</summary>
		/// <remarks>8��</remarks>
		private Int64 _salesTargetMoney8;

		/// <summary>����ڕW���z9</summary>
		/// <remarks>9��</remarks>
		private Int64 _salesTargetMoney9;

		/// <summary>����ڕW���z10</summary>
		/// <remarks>10��</remarks>
		private Int64 _salesTargetMoney10;

		/// <summary>����ڕW���z11</summary>
		/// <remarks>11��</remarks>
		private Int64 _salesTargetMoney11;

		/// <summary>����ڕW���z12</summary>
		/// <remarks>12��</remarks>
		private Int64 _salesTargetMoney12;

		/// <summary>���Ԕ���ڕW���z</summary>
		private Int64 _monthlySalesTarget;

		/// <summary>������ԖڕW���z</summary>
		private Int64 _termSalesTarget;

		/// <summary>����ڕW�e���z1</summary>
		/// <remarks>1��</remarks>
		private Int64 _salesTargetProfit1;

		/// <summary>����ڕW�e���z2</summary>
		/// <remarks>2��</remarks>
		private Int64 _salesTargetProfit2;

		/// <summary>����ڕW�e���z3</summary>
		/// <remarks>3��</remarks>
		private Int64 _salesTargetProfit3;

		/// <summary>����ڕW�e���z4</summary>
		/// <remarks>4��</remarks>
		private Int64 _salesTargetProfit4;

		/// <summary>����ڕW�e���z5</summary>
		/// <remarks>5��</remarks>
		private Int64 _salesTargetProfit5;

		/// <summary>����ڕW�e���z6</summary>
		/// <remarks>6��</remarks>
		private Int64 _salesTargetProfit6;

		/// <summary>����ڕW�e���z7</summary>
		/// <remarks>7��</remarks>
		private Int64 _salesTargetProfit7;

		/// <summary>����ڕW�e���z8</summary>
		/// <remarks>8��</remarks>
		private Int64 _salesTargetProfit8;

		/// <summary>����ڕW�e���z9</summary>
		/// <remarks>9��</remarks>
		private Int64 _salesTargetProfit9;

		/// <summary>����ڕW�e���z10</summary>
		/// <remarks>10��</remarks>
		private Int64 _salesTargetProfit10;

		/// <summary>����ڕW�e���z11</summary>
		/// <remarks>11��</remarks>
		private Int64 _salesTargetProfit11;

		/// <summary>����ڕW�e���z12</summary>
		/// <remarks>12��</remarks>
		private Int64 _salesTargetProfit12;

		/// <summary>���㌎�ԖڕW�e���z</summary>
		private Int64 _monthlySalesTargetProfit;

		/// <summary>������ԖڕW�e���z</summary>
		private Int64 _termSalesTargetProfit;

		/// <summary>����ڕW����1</summary>
		/// <remarks>1��</remarks>
		private Int64 _salesTargetCount1;

		/// <summary>����ڕW����2</summary>
		/// <remarks>2��</remarks>
		private Int64 _salesTargetCount2;

		/// <summary>����ڕW����3</summary>
		/// <remarks>3��</remarks>
		private Int64 _salesTargetCount3;

		/// <summary>����ڕW����4</summary>
		/// <remarks>4��</remarks>
		private Int64 _salesTargetCount4;

		/// <summary>����ڕW����5</summary>
		/// <remarks>5��</remarks>
		private Int64 _salesTargetCount5;

		/// <summary>����ڕW����6</summary>
		/// <remarks>6��</remarks>
		private Int64 _salesTargetCount6;

		/// <summary>����ڕW����7</summary>
		/// <remarks>7��</remarks>
		private Int64 _salesTargetCount7;

		/// <summary>����ڕW����8</summary>
		/// <remarks>8��</remarks>
		private Int64 _salesTargetCount8;

		/// <summary>����ڕW����9</summary>
		/// <remarks>9��</remarks>
		private Int64 _salesTargetCount9;

		/// <summary>����ڕW����10</summary>
		/// <remarks>10��</remarks>
		private Int64 _salesTargetCount10;

		/// <summary>����ڕW����11</summary>
		/// <remarks>11��</remarks>
		private Int64 _salesTargetCount11;

		/// <summary>����ڕW����12</summary>
		/// <remarks>12��</remarks>
		private Int64 _salesTargetCount12;

		/// <summary>���㌎�ԖڕW����</summary>
		private Int64 _monthlySalesTargetCount;

		/// <summary>������ԖڕW����</summary>
		private Int64 _termSalesTargetCount;


		/// public propaty name  :  UpdateDateTime
		/// <summary>�X�V�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

        /// public propaty name  :  UpdateDateTime
        /// <summary>�K�p�J�n���v���p�e�B</summary>
        /// <value>�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>�K�p�I�����v���p�e�B</summary>
        /// <value>�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

		/// public propaty name  :  CampaignCode
		/// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
		/// <value>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CampaignCode
		{
			get{return _campaignCode;}
			set{_campaignCode = value;}
		}

		/// public propaty name  :  CampaignName
		/// <summary>�L�����y�[�����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����y�[�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CampaignName
		{
			get{return _campaignName;}
			set{_campaignName = value;}
		}

		/// public propaty name  :  TargetContrastCd
		/// <summary>�ڕW�Δ�敪�v���p�e�B</summary>
		/// <value>10:���_,22:���_+�]�ƈ�,30:���_+���Ӑ�,32:���_+�̔��ر,44:���_+�̔��敪,50:���_+��ٰ�ߺ���,60:���_+BL����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ڕW�Δ�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TargetContrastCd
		{
			get{return _targetContrastCd;}
			set{_targetContrastCd = value;}
		}

		/// public propaty name  :  EmployeeDivCd
		/// <summary>�]�ƈ��敪�v���p�e�B</summary>
		/// <value>10:�̔��S���� 20:��t�S���� 30:���͒S����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EmployeeDivCd
		{
			get{return _employeeDivCd;}
			set{_employeeDivCd = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  SectionGuideSnm
		/// <summary>���_�K�C�h���̃v���p�e�B</summary>
		/// <value>���[�󎚗p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionGuideSnm
		{
			get{return _sectionGuideSnm;}
			set{_sectionGuideSnm = value;}
		}

		/// public propaty name  :  EmployeeCode
		/// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EmployeeCode
		{
			get{return _employeeCode;}
			set{_employeeCode = value;}
		}

		/// public propaty name  :  Name
		/// <summary>���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustomerSnm
		/// <summary>���Ӑ旪�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerSnm
		{
			get{return _customerSnm;}
			set{_customerSnm = value;}
		}

		/// public propaty name  :  SalesAreaCode
		/// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
		/// <value>�n��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesAreaCode
		{
			get{return _salesAreaCode;}
			set{_salesAreaCode = value;}
		}

		/// public propaty name  :  SalesAreaName
		/// <summary>�̔��G���A�K�C�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��G���A�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesAreaName
		{
			get{return _salesAreaName;}
			set{_salesAreaName = value;}
		}

		/// public propaty name  :  BLGroupCode
		/// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>���O���[�v�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGroupCode
		{
			get{return _bLGroupCode;}
			set{_bLGroupCode = value;}
		}

		/// public propaty name  :  BLGroupKanaName
		/// <summary>BL�O���[�v�R�[�h�J�i���̃v���p�e�B</summary>
		/// <value>���p�J�i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL�O���[�v�R�[�h�J�i���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BLGroupKanaName
		{
			get{return _bLGroupKanaName;}
			set{_bLGroupKanaName = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL���i�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  BLGoodsHalfName
		/// <summary>BL���i�R�[�h���́i���p�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h���́i���p�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BLGoodsHalfName
		{
			get{return _bLGoodsHalfName;}
			set{_bLGoodsHalfName = value;}
		}

		/// public propaty name  :  SalesCode
		/// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesCode
		{
			get{return _salesCode;}
			set{_salesCode = value;}
		}

		/// public propaty name  :  SalesCodeName
		/// <summary>�̔��敪�K�C�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��敪�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesCodeName
		{
			get{return _salesCodeName;}
			set{_salesCodeName = value;}
		}

		/// public propaty name  :  SalesTargetMoney1
		/// <summary>����ڕW���z1�v���p�e�B</summary>
		/// <value>1��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW���z1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetMoney1
		{
			get{return _salesTargetMoney1;}
			set{_salesTargetMoney1 = value;}
		}

		/// public propaty name  :  SalesTargetMoney2
		/// <summary>����ڕW���z2�v���p�e�B</summary>
		/// <value>2��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW���z2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetMoney2
		{
			get{return _salesTargetMoney2;}
			set{_salesTargetMoney2 = value;}
		}

		/// public propaty name  :  SalesTargetMoney3
		/// <summary>����ڕW���z3�v���p�e�B</summary>
		/// <value>3��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW���z3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetMoney3
		{
			get{return _salesTargetMoney3;}
			set{_salesTargetMoney3 = value;}
		}

		/// public propaty name  :  SalesTargetMoney4
		/// <summary>����ڕW���z4�v���p�e�B</summary>
		/// <value>4��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW���z4�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetMoney4
		{
			get{return _salesTargetMoney4;}
			set{_salesTargetMoney4 = value;}
		}

		/// public propaty name  :  SalesTargetMoney5
		/// <summary>����ڕW���z5�v���p�e�B</summary>
		/// <value>5��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW���z5�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetMoney5
		{
			get{return _salesTargetMoney5;}
			set{_salesTargetMoney5 = value;}
		}

		/// public propaty name  :  SalesTargetMoney6
		/// <summary>����ڕW���z6�v���p�e�B</summary>
		/// <value>6��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW���z6�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetMoney6
		{
			get{return _salesTargetMoney6;}
			set{_salesTargetMoney6 = value;}
		}

		/// public propaty name  :  SalesTargetMoney7
		/// <summary>����ڕW���z7�v���p�e�B</summary>
		/// <value>7��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW���z7�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetMoney7
		{
			get{return _salesTargetMoney7;}
			set{_salesTargetMoney7 = value;}
		}

		/// public propaty name  :  SalesTargetMoney8
		/// <summary>����ڕW���z8�v���p�e�B</summary>
		/// <value>8��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW���z8�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetMoney8
		{
			get{return _salesTargetMoney8;}
			set{_salesTargetMoney8 = value;}
		}

		/// public propaty name  :  SalesTargetMoney9
		/// <summary>����ڕW���z9�v���p�e�B</summary>
		/// <value>9��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW���z9�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetMoney9
		{
			get{return _salesTargetMoney9;}
			set{_salesTargetMoney9 = value;}
		}

		/// public propaty name  :  SalesTargetMoney10
		/// <summary>����ڕW���z10�v���p�e�B</summary>
		/// <value>10��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW���z10�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetMoney10
		{
			get{return _salesTargetMoney10;}
			set{_salesTargetMoney10 = value;}
		}

		/// public propaty name  :  SalesTargetMoney11
		/// <summary>����ڕW���z11�v���p�e�B</summary>
		/// <value>11��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW���z11�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetMoney11
		{
			get{return _salesTargetMoney11;}
			set{_salesTargetMoney11 = value;}
		}

		/// public propaty name  :  SalesTargetMoney12
		/// <summary>����ڕW���z12�v���p�e�B</summary>
		/// <value>12��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW���z12�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetMoney12
		{
			get{return _salesTargetMoney12;}
			set{_salesTargetMoney12 = value;}
		}

		/// public propaty name  :  MonthlySalesTarget
		/// <summary>���Ԕ���ڕW���z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ԕ���ڕW���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 MonthlySalesTarget
		{
			get{return _monthlySalesTarget;}
			set{_monthlySalesTarget = value;}
		}

		/// public propaty name  :  TermSalesTarget
		/// <summary>������ԖڕW���z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������ԖڕW���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TermSalesTarget
		{
			get{return _termSalesTarget;}
			set{_termSalesTarget = value;}
		}

		/// public propaty name  :  SalesTargetProfit1
		/// <summary>����ڕW�e���z1�v���p�e�B</summary>
		/// <value>1��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW�e���z1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetProfit1
		{
			get{return _salesTargetProfit1;}
			set{_salesTargetProfit1 = value;}
		}

		/// public propaty name  :  SalesTargetProfit2
		/// <summary>����ڕW�e���z2�v���p�e�B</summary>
		/// <value>2��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW�e���z2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetProfit2
		{
			get{return _salesTargetProfit2;}
			set{_salesTargetProfit2 = value;}
		}

		/// public propaty name  :  SalesTargetProfit3
		/// <summary>����ڕW�e���z3�v���p�e�B</summary>
		/// <value>3��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW�e���z3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetProfit3
		{
			get{return _salesTargetProfit3;}
			set{_salesTargetProfit3 = value;}
		}

		/// public propaty name  :  SalesTargetProfit4
		/// <summary>����ڕW�e���z4�v���p�e�B</summary>
		/// <value>4��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW�e���z4�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetProfit4
		{
			get{return _salesTargetProfit4;}
			set{_salesTargetProfit4 = value;}
		}

		/// public propaty name  :  SalesTargetProfit5
		/// <summary>����ڕW�e���z5�v���p�e�B</summary>
		/// <value>5��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW�e���z5�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetProfit5
		{
			get{return _salesTargetProfit5;}
			set{_salesTargetProfit5 = value;}
		}

		/// public propaty name  :  SalesTargetProfit6
		/// <summary>����ڕW�e���z6�v���p�e�B</summary>
		/// <value>6��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW�e���z6�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetProfit6
		{
			get{return _salesTargetProfit6;}
			set{_salesTargetProfit6 = value;}
		}

		/// public propaty name  :  SalesTargetProfit7
		/// <summary>����ڕW�e���z7�v���p�e�B</summary>
		/// <value>7��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW�e���z7�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetProfit7
		{
			get{return _salesTargetProfit7;}
			set{_salesTargetProfit7 = value;}
		}

		/// public propaty name  :  SalesTargetProfit8
		/// <summary>����ڕW�e���z8�v���p�e�B</summary>
		/// <value>8��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW�e���z8�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetProfit8
		{
			get{return _salesTargetProfit8;}
			set{_salesTargetProfit8 = value;}
		}

		/// public propaty name  :  SalesTargetProfit9
		/// <summary>����ڕW�e���z9�v���p�e�B</summary>
		/// <value>9��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW�e���z9�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetProfit9
		{
			get{return _salesTargetProfit9;}
			set{_salesTargetProfit9 = value;}
		}

		/// public propaty name  :  SalesTargetProfit10
		/// <summary>����ڕW�e���z10�v���p�e�B</summary>
		/// <value>10��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW�e���z10�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetProfit10
		{
			get{return _salesTargetProfit10;}
			set{_salesTargetProfit10 = value;}
		}

		/// public propaty name  :  SalesTargetProfit11
		/// <summary>����ڕW�e���z11�v���p�e�B</summary>
		/// <value>11��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW�e���z11�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetProfit11
		{
			get{return _salesTargetProfit11;}
			set{_salesTargetProfit11 = value;}
		}

		/// public propaty name  :  SalesTargetProfit12
		/// <summary>����ڕW�e���z12�v���p�e�B</summary>
		/// <value>12��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW�e���z12�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetProfit12
		{
			get{return _salesTargetProfit12;}
			set{_salesTargetProfit12 = value;}
		}

		/// public propaty name  :  MonthlySalesTargetProfit
		/// <summary>���㌎�ԖڕW�e���z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㌎�ԖڕW�e���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 MonthlySalesTargetProfit
		{
			get{return _monthlySalesTargetProfit;}
			set{_monthlySalesTargetProfit = value;}
		}

		/// public propaty name  :  TermSalesTargetProfit
		/// <summary>������ԖڕW�e���z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������ԖڕW�e���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TermSalesTargetProfit
		{
			get{return _termSalesTargetProfit;}
			set{_termSalesTargetProfit = value;}
		}

		/// public propaty name  :  SalesTargetCount1
		/// <summary>����ڕW����1�v���p�e�B</summary>
		/// <value>1��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW����1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetCount1
		{
			get{return _salesTargetCount1;}
			set{_salesTargetCount1 = value;}
		}

		/// public propaty name  :  SalesTargetCount2
		/// <summary>����ڕW����2�v���p�e�B</summary>
		/// <value>2��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW����2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetCount2
		{
			get{return _salesTargetCount2;}
			set{_salesTargetCount2 = value;}
		}

		/// public propaty name  :  SalesTargetCount3
		/// <summary>����ڕW����3�v���p�e�B</summary>
		/// <value>3��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW����3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetCount3
		{
			get{return _salesTargetCount3;}
			set{_salesTargetCount3 = value;}
		}

		/// public propaty name  :  SalesTargetCount4
		/// <summary>����ڕW����4�v���p�e�B</summary>
		/// <value>4��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW����4�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetCount4
		{
			get{return _salesTargetCount4;}
			set{_salesTargetCount4 = value;}
		}

		/// public propaty name  :  SalesTargetCount5
		/// <summary>����ڕW����5�v���p�e�B</summary>
		/// <value>5��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW����5�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetCount5
		{
			get{return _salesTargetCount5;}
			set{_salesTargetCount5 = value;}
		}

		/// public propaty name  :  SalesTargetCount6
		/// <summary>����ڕW����6�v���p�e�B</summary>
		/// <value>6��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW����6�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetCount6
		{
			get{return _salesTargetCount6;}
			set{_salesTargetCount6 = value;}
		}

		/// public propaty name  :  SalesTargetCount7
		/// <summary>����ڕW����7�v���p�e�B</summary>
		/// <value>7��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW����7�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetCount7
		{
			get{return _salesTargetCount7;}
			set{_salesTargetCount7 = value;}
		}

		/// public propaty name  :  SalesTargetCount8
		/// <summary>����ڕW����8�v���p�e�B</summary>
		/// <value>8��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW����8�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetCount8
		{
			get{return _salesTargetCount8;}
			set{_salesTargetCount8 = value;}
		}

		/// public propaty name  :  SalesTargetCount9
		/// <summary>����ڕW����9�v���p�e�B</summary>
		/// <value>9��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW����9�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetCount9
		{
			get{return _salesTargetCount9;}
			set{_salesTargetCount9 = value;}
		}

		/// public propaty name  :  SalesTargetCount10
		/// <summary>����ڕW����10�v���p�e�B</summary>
		/// <value>10��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW����10�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetCount10
		{
			get{return _salesTargetCount10;}
			set{_salesTargetCount10 = value;}
		}

		/// public propaty name  :  SalesTargetCount11
		/// <summary>����ڕW����11�v���p�e�B</summary>
		/// <value>11��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW����11�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetCount11
		{
			get{return _salesTargetCount11;}
			set{_salesTargetCount11 = value;}
		}

		/// public propaty name  :  SalesTargetCount12
		/// <summary>����ڕW����12�v���p�e�B</summary>
		/// <value>12��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ڕW����12�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTargetCount12
		{
			get{return _salesTargetCount12;}
			set{_salesTargetCount12 = value;}
		}

		/// public propaty name  :  MonthlySalesTargetCount
		/// <summary>���㌎�ԖڕW���ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㌎�ԖڕW���ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 MonthlySalesTargetCount
		{
			get{return _monthlySalesTargetCount;}
			set{_monthlySalesTargetCount = value;}
		}

		/// public propaty name  :  TermSalesTargetCount
		/// <summary>������ԖڕW���ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������ԖڕW���ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TermSalesTargetCount
		{
			get{return _termSalesTargetCount;}
			set{_termSalesTargetCount = value;}
		}


		/// <summary>
		/// �L�����y�[���ڕW�ݒ胏�[�N�R���X�g���N�^
		/// </summary>
		/// <returns>CampTrgtPrintResultWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CampTrgtPrintResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public CampTrgtPrintResultWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CampTrgtPrintResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CampTrgtPrintResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CampTrgtPrintResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampTrgtPrintResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CampTrgtPrintResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CampTrgtPrintResultWork || graph is ArrayList || graph is CampTrgtPrintResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CampTrgtPrintResultWork).FullName));

            if (graph != null && graph is CampTrgtPrintResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CampTrgtPrintResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CampTrgtPrintResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CampTrgtPrintResultWork[])graph).Length;
            }
            else if (graph is CampTrgtPrintResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //�K�p�J�n��
            serInfo.MemberInfo.Add(typeof(Int64)); //ApplyStaDate
            //�K�p�I����
            serInfo.MemberInfo.Add(typeof(Int64)); //ApplyEndDate
            //�L�����y�[���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //�L�����y�[������
            serInfo.MemberInfo.Add(typeof(string)); //CampaignName
            //�ڕW�Δ�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TargetContrastCd
            //�]�ƈ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EmployeeDivCd
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //����
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�̔��G���A�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL�O���[�v�R�[�h�J�i����
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupKanaName
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i���p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //�̔��敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //�̔��敪�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SalesCodeName
            //����ڕW���z1
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney1
            //����ڕW���z2
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney2
            //����ڕW���z3
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney3
            //����ڕW���z4
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney4
            //����ڕW���z5
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney5
            //����ڕW���z6
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney6
            //����ڕW���z7
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney7
            //����ڕW���z8
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney8
            //����ڕW���z9
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney9
            //����ڕW���z10
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney10
            //����ڕW���z11
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney11
            //����ڕW���z12
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney12
            //���Ԕ���ڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTarget
            //������ԖڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTarget
            //����ڕW�e���z1
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit1
            //����ڕW�e���z2
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit2
            //����ڕW�e���z3
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit3
            //����ڕW�e���z4
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit4
            //����ڕW�e���z5
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit5
            //����ڕW�e���z6
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit6
            //����ڕW�e���z7
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit7
            //����ڕW�e���z8
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit8
            //����ڕW�e���z9
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit9
            //����ڕW�e���z10
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit10
            //����ڕW�e���z11
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit11
            //����ڕW�e���z12
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit12
            //���㌎�ԖڕW�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTargetProfit
            //������ԖڕW�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetProfit
            //����ڕW����1
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount1
            //����ڕW����2
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount2
            //����ڕW����3
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount3
            //����ڕW����4
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount4
            //����ڕW����5
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount5
            //����ڕW����6
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount6
            //����ڕW����7
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount7
            //����ڕW����8
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount8
            //����ڕW����9
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount9
            //����ڕW����10
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount10
            //����ڕW����11
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount11
            //����ڕW����12
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount12
            //���㌎�ԖڕW����
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTargetCount
            //������ԖڕW����
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetCount


            serInfo.Serialize(writer, serInfo);
            if (graph is CampTrgtPrintResultWork)
            {
                CampTrgtPrintResultWork temp = (CampTrgtPrintResultWork)graph;

                SetCampTrgtPrintResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CampTrgtPrintResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CampTrgtPrintResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CampTrgtPrintResultWork temp in lst)
                {
                    SetCampTrgtPrintResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CampTrgtPrintResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 63;

        /// <summary>
        ///  CampTrgtPrintResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampTrgtPrintResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCampTrgtPrintResultWork(System.IO.BinaryWriter writer, CampTrgtPrintResultWork temp)
        {
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //�K�p�J�n��
            writer.Write((Int64)temp.ApplyStaDate.Ticks);
            //�K�p�I����
            writer.Write((Int64)temp.ApplyEndDate.Ticks);
            //�L�����y�[���R�[�h
            writer.Write(temp.CampaignCode);
            //�L�����y�[������
            writer.Write(temp.CampaignName);
            //�ڕW�Δ�敪
            writer.Write(temp.TargetContrastCd);
            //�]�ƈ��敪
            writer.Write(temp.EmployeeDivCd);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //�]�ƈ��R�[�h
            writer.Write(temp.EmployeeCode);
            //����
            writer.Write(temp.Name);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�̔��G���A�R�[�h
            writer.Write(temp.SalesAreaCode);
            //�̔��G���A�K�C�h����
            writer.Write(temp.SalesAreaName);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //BL�O���[�v�R�[�h�J�i����
            writer.Write(temp.BLGroupKanaName);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i���p�j
            writer.Write(temp.BLGoodsHalfName);
            //�̔��敪�R�[�h
            writer.Write(temp.SalesCode);
            //�̔��敪�K�C�h����
            writer.Write(temp.SalesCodeName);
            //����ڕW���z1
            writer.Write(temp.SalesTargetMoney1);
            //����ڕW���z2
            writer.Write(temp.SalesTargetMoney2);
            //����ڕW���z3
            writer.Write(temp.SalesTargetMoney3);
            //����ڕW���z4
            writer.Write(temp.SalesTargetMoney4);
            //����ڕW���z5
            writer.Write(temp.SalesTargetMoney5);
            //����ڕW���z6
            writer.Write(temp.SalesTargetMoney6);
            //����ڕW���z7
            writer.Write(temp.SalesTargetMoney7);
            //����ڕW���z8
            writer.Write(temp.SalesTargetMoney8);
            //����ڕW���z9
            writer.Write(temp.SalesTargetMoney9);
            //����ڕW���z10
            writer.Write(temp.SalesTargetMoney10);
            //����ڕW���z11
            writer.Write(temp.SalesTargetMoney11);
            //����ڕW���z12
            writer.Write(temp.SalesTargetMoney12);
            //���Ԕ���ڕW���z
            writer.Write(temp.MonthlySalesTarget);
            //������ԖڕW���z
            writer.Write(temp.TermSalesTarget);
            //����ڕW�e���z1
            writer.Write(temp.SalesTargetProfit1);
            //����ڕW�e���z2
            writer.Write(temp.SalesTargetProfit2);
            //����ڕW�e���z3
            writer.Write(temp.SalesTargetProfit3);
            //����ڕW�e���z4
            writer.Write(temp.SalesTargetProfit4);
            //����ڕW�e���z5
            writer.Write(temp.SalesTargetProfit5);
            //����ڕW�e���z6
            writer.Write(temp.SalesTargetProfit6);
            //����ڕW�e���z7
            writer.Write(temp.SalesTargetProfit7);
            //����ڕW�e���z8
            writer.Write(temp.SalesTargetProfit8);
            //����ڕW�e���z9
            writer.Write(temp.SalesTargetProfit9);
            //����ڕW�e���z10
            writer.Write(temp.SalesTargetProfit10);
            //����ڕW�e���z11
            writer.Write(temp.SalesTargetProfit11);
            //����ڕW�e���z12
            writer.Write(temp.SalesTargetProfit12);
            //���㌎�ԖڕW�e���z
            writer.Write(temp.MonthlySalesTargetProfit);
            //������ԖڕW�e���z
            writer.Write(temp.TermSalesTargetProfit);
            //����ڕW����1
            writer.Write(temp.SalesTargetCount1);
            //����ڕW����2
            writer.Write(temp.SalesTargetCount2);
            //����ڕW����3
            writer.Write(temp.SalesTargetCount3);
            //����ڕW����4
            writer.Write(temp.SalesTargetCount4);
            //����ڕW����5
            writer.Write(temp.SalesTargetCount5);
            //����ڕW����6
            writer.Write(temp.SalesTargetCount6);
            //����ڕW����7
            writer.Write(temp.SalesTargetCount7);
            //����ڕW����8
            writer.Write(temp.SalesTargetCount8);
            //����ڕW����9
            writer.Write(temp.SalesTargetCount9);
            //����ڕW����10
            writer.Write(temp.SalesTargetCount10);
            //����ڕW����11
            writer.Write(temp.SalesTargetCount11);
            //����ڕW����12
            writer.Write(temp.SalesTargetCount12);
            //���㌎�ԖڕW����
            writer.Write(temp.MonthlySalesTargetCount);
            //������ԖڕW����
            writer.Write(temp.TermSalesTargetCount);

        }

        /// <summary>
        ///  CampTrgtPrintResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CampTrgtPrintResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampTrgtPrintResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CampTrgtPrintResultWork GetCampTrgtPrintResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CampTrgtPrintResultWork temp = new CampTrgtPrintResultWork();

            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //�K�p�J�n��
            temp.ApplyStaDate = new DateTime(reader.ReadInt64());
            //�K�p�I����
            temp.ApplyEndDate = new DateTime(reader.ReadInt64());
            //�L�����y�[���R�[�h
            temp.CampaignCode = reader.ReadInt32();
            //�L�����y�[������
            temp.CampaignName = reader.ReadString();
            //�ڕW�Δ�敪
            temp.TargetContrastCd = reader.ReadInt32();
            //�]�ƈ��敪
            temp.EmployeeDivCd = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //�]�ƈ��R�[�h
            temp.EmployeeCode = reader.ReadString();
            //����
            temp.Name = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�̔��G���A�R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //�̔��G���A�K�C�h����
            temp.SalesAreaName = reader.ReadString();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h�J�i����
            temp.BLGroupKanaName = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i���p�j
            temp.BLGoodsHalfName = reader.ReadString();
            //�̔��敪�R�[�h
            temp.SalesCode = reader.ReadInt32();
            //�̔��敪�K�C�h����
            temp.SalesCodeName = reader.ReadString();
            //����ڕW���z1
            temp.SalesTargetMoney1 = reader.ReadInt64();
            //����ڕW���z2
            temp.SalesTargetMoney2 = reader.ReadInt64();
            //����ڕW���z3
            temp.SalesTargetMoney3 = reader.ReadInt64();
            //����ڕW���z4
            temp.SalesTargetMoney4 = reader.ReadInt64();
            //����ڕW���z5
            temp.SalesTargetMoney5 = reader.ReadInt64();
            //����ڕW���z6
            temp.SalesTargetMoney6 = reader.ReadInt64();
            //����ڕW���z7
            temp.SalesTargetMoney7 = reader.ReadInt64();
            //����ڕW���z8
            temp.SalesTargetMoney8 = reader.ReadInt64();
            //����ڕW���z9
            temp.SalesTargetMoney9 = reader.ReadInt64();
            //����ڕW���z10
            temp.SalesTargetMoney10 = reader.ReadInt64();
            //����ڕW���z11
            temp.SalesTargetMoney11 = reader.ReadInt64();
            //����ڕW���z12
            temp.SalesTargetMoney12 = reader.ReadInt64();
            //���Ԕ���ڕW���z
            temp.MonthlySalesTarget = reader.ReadInt64();
            //������ԖڕW���z
            temp.TermSalesTarget = reader.ReadInt64();
            //����ڕW�e���z1
            temp.SalesTargetProfit1 = reader.ReadInt64();
            //����ڕW�e���z2
            temp.SalesTargetProfit2 = reader.ReadInt64();
            //����ڕW�e���z3
            temp.SalesTargetProfit3 = reader.ReadInt64();
            //����ڕW�e���z4
            temp.SalesTargetProfit4 = reader.ReadInt64();
            //����ڕW�e���z5
            temp.SalesTargetProfit5 = reader.ReadInt64();
            //����ڕW�e���z6
            temp.SalesTargetProfit6 = reader.ReadInt64();
            //����ڕW�e���z7
            temp.SalesTargetProfit7 = reader.ReadInt64();
            //����ڕW�e���z8
            temp.SalesTargetProfit8 = reader.ReadInt64();
            //����ڕW�e���z9
            temp.SalesTargetProfit9 = reader.ReadInt64();
            //����ڕW�e���z10
            temp.SalesTargetProfit10 = reader.ReadInt64();
            //����ڕW�e���z11
            temp.SalesTargetProfit11 = reader.ReadInt64();
            //����ڕW�e���z12
            temp.SalesTargetProfit12 = reader.ReadInt64();
            //���㌎�ԖڕW�e���z
            temp.MonthlySalesTargetProfit = reader.ReadInt64();
            //������ԖڕW�e���z
            temp.TermSalesTargetProfit = reader.ReadInt64();
            //����ڕW����1
            temp.SalesTargetCount1 = reader.ReadInt64();
            //����ڕW����2
            temp.SalesTargetCount2 = reader.ReadInt64();
            //����ڕW����3
            temp.SalesTargetCount3 = reader.ReadInt64();
            //����ڕW����4
            temp.SalesTargetCount4 = reader.ReadInt64();
            //����ڕW����5
            temp.SalesTargetCount5 = reader.ReadInt64();
            //����ڕW����6
            temp.SalesTargetCount6 = reader.ReadInt64();
            //����ڕW����7
            temp.SalesTargetCount7 = reader.ReadInt64();
            //����ڕW����8
            temp.SalesTargetCount8 = reader.ReadInt64();
            //����ڕW����9
            temp.SalesTargetCount9 = reader.ReadInt64();
            //����ڕW����10
            temp.SalesTargetCount10 = reader.ReadInt64();
            //����ڕW����11
            temp.SalesTargetCount11 = reader.ReadInt64();
            //����ڕW����12
            temp.SalesTargetCount12 = reader.ReadInt64();
            //���㌎�ԖڕW����
            temp.MonthlySalesTargetCount = reader.ReadInt64();
            //������ԖڕW����
            temp.TermSalesTargetCount = reader.ReadInt64();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>CampTrgtPrintResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampTrgtPrintResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CampTrgtPrintResultWork temp = GetCampTrgtPrintResultWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (CampTrgtPrintResultWork[])lst.ToArray(typeof(CampTrgtPrintResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
