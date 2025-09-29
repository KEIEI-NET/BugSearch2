using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_DemandDtlGrpSum
	/// <summary>
	///                      ������(�ӕ����׏��)���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ������(�ӕ����׏��)���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/06/29  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ExtrInfo_DemandDtlGrpSum
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�v�㋒�_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string _addUpSecCode = "";

		/// <summary>���o�Ώیv���(�J�n)</summary>
		/// <remarks>"YYYYMMDD"  ������J�n�v����ƂȂ�N����</remarks>
		private Int32 _addUpADateSt;

		/// <summary>���o�Ώیv���(�I��)</summary>
		/// <remarks>"YYYYMMDD"  ������I���v����ƂȂ�N����</remarks>
		private Int32 _addUpADateEd;

		/// <summary>������R�[�h</summary>
		private Int32 _claimCode;

		/// <summary>�������ג��o�L��</summary>
		private bool _isExtractDepo;

		/// <summary>�����o�͐ݒ�</summary>
		private Int32 _countSheets;

		/// <summary>�����W�v���@(�o�͏�)1</summary>
		/// <remarks>�N���C�A���g����Ώۍ���ID�𓊂���</remarks>
		private string _demandSumOdr1 = "";

		/// <summary>�����W�v���@(�o�͏�)�t��1</summary>
		/// <remarks>�N���C�A���g����Ώۍ���ID�𓊂���</remarks>
		private string _demandSumOdrAttend1 = "";

		/// <summary>�����W�v���@(�o�͏�)2</summary>
		/// <remarks>�N���C�A���g����Ώۍ���ID�𓊂���</remarks>
		private string _demandSumOdr2 = "";

		/// <summary>�����W�v���@(�o�͏�)�t��2</summary>
		/// <remarks>�N���C�A���g����Ώۍ���ID�𓊂���</remarks>
		private string _demandSumOdrAttend2 = "";

		/// <summary>�����W�v���@(�o�͏�)3</summary>
		/// <remarks>�N���C�A���g����Ώۍ���ID�𓊂���</remarks>
		private string _demandSumOdr3 = "";

		/// <summary>�����W�v���@(�o�͏�)�t��3</summary>
		/// <remarks>�N���C�A���g����Ώۍ���ID�𓊂���</remarks>
		private string _demandSumOdrAttend3 = "";

		/// <summary>�x���W�v���@(�o�͏�)1</summary>
		/// <remarks>�N���C�A���g����Ώۍ���ID�𓊂���</remarks>
		private string _paymentSumOdr1 = "";

		/// <summary>�x���W�v���@(�o�͏�)�t��1</summary>
		/// <remarks>�N���C�A���g����Ώۍ���ID�𓊂���</remarks>
		private string _paymentSumOdrAttend1 = "";

		/// <summary>�x���W�v���@(�o�͏�)2</summary>
		/// <remarks>�N���C�A���g����Ώۍ���ID�𓊂���</remarks>
		private string _paymentSumOdr2 = "";

		/// <summary>�x���W�v���@(�o�͏�)�t��2</summary>
		/// <remarks>�N���C�A���g����Ώۍ���ID�𓊂���</remarks>
		private string _paymentSumOdrAttend2 = "";

		/// <summary>�x���W�v���@(�o�͏�)3</summary>
		/// <remarks>�N���C�A���g����Ώۍ���ID�𓊂���</remarks>
		private string _paymentSumOdr3 = "";

		/// <summary>�x���W�v���@(�o�͏�)�t��3</summary>
		/// <remarks>�N���C�A���g����Ώۍ���ID�𓊂���</remarks>
		private string _paymentSumOdrAttend3 = "";

		/// <summary>�����������i�敪</summary>
		private String[] _forceDmdMggCd;

		/// <summary>�����x�����i�敪</summary>
		private String[] _forcePayMggCd;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�v�㋒�_����</summary>
		private string _addUpSecName = "";


		/// public propaty name  :  EnterpriseCode
		/// <summary>��ƃR�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  AddUpSecCode
		/// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
		/// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpSecCode
		{
			get{return _addUpSecCode;}
			set{_addUpSecCode = value;}
		}

		/// public propaty name  :  AddUpADateSt
		/// <summary>���o�Ώیv���(�J�n)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  ������J�n�v����ƂȂ�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�Ώیv���(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddUpADateSt
		{
			get{return _addUpADateSt;}
			set{_addUpADateSt = value;}
		}

		/// public propaty name  :  AddUpADateEd
		/// <summary>���o�Ώیv���(�I��)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  ������I���v����ƂȂ�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�Ώیv���(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddUpADateEd
		{
			get{return _addUpADateEd;}
			set{_addUpADateEd = value;}
		}

		/// public propaty name  :  ClaimCode
		/// <summary>������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ClaimCode
		{
			get{return _claimCode;}
			set{_claimCode = value;}
		}

		/// public propaty name  :  IsExtractDepo
		/// <summary>�������ג��o�L���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ג��o�L���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsExtractDepo
		{
			get{return _isExtractDepo;}
			set{_isExtractDepo = value;}
		}

		/// public propaty name  :  CountSheets
		/// <summary>�����o�͐ݒ�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����o�͐ݒ�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CountSheets
		{
			get{return _countSheets;}
			set{_countSheets = value;}
		}

		/// public propaty name  :  DemandSumOdr1
		/// <summary>�����W�v���@(�o�͏�)1�v���p�e�B</summary>
		/// <value>�N���C�A���g����Ώۍ���ID�𓊂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����W�v���@(�o�͏�)1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DemandSumOdr1
		{
			get{return _demandSumOdr1;}
			set{_demandSumOdr1 = value;}
		}

		/// public propaty name  :  DemandSumOdrAttend1
		/// <summary>�����W�v���@(�o�͏�)�t��1�v���p�e�B</summary>
		/// <value>�N���C�A���g����Ώۍ���ID�𓊂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����W�v���@(�o�͏�)�t��1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DemandSumOdrAttend1
		{
			get{return _demandSumOdrAttend1;}
			set{_demandSumOdrAttend1 = value;}
		}

		/// public propaty name  :  DemandSumOdr2
		/// <summary>�����W�v���@(�o�͏�)2�v���p�e�B</summary>
		/// <value>�N���C�A���g����Ώۍ���ID�𓊂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����W�v���@(�o�͏�)2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DemandSumOdr2
		{
			get{return _demandSumOdr2;}
			set{_demandSumOdr2 = value;}
		}

		/// public propaty name  :  DemandSumOdrAttend2
		/// <summary>�����W�v���@(�o�͏�)�t��2�v���p�e�B</summary>
		/// <value>�N���C�A���g����Ώۍ���ID�𓊂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����W�v���@(�o�͏�)�t��2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DemandSumOdrAttend2
		{
			get{return _demandSumOdrAttend2;}
			set{_demandSumOdrAttend2 = value;}
		}

		/// public propaty name  :  DemandSumOdr3
		/// <summary>�����W�v���@(�o�͏�)3�v���p�e�B</summary>
		/// <value>�N���C�A���g����Ώۍ���ID�𓊂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����W�v���@(�o�͏�)3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DemandSumOdr3
		{
			get{return _demandSumOdr3;}
			set{_demandSumOdr3 = value;}
		}

		/// public propaty name  :  DemandSumOdrAttend3
		/// <summary>�����W�v���@(�o�͏�)�t��3�v���p�e�B</summary>
		/// <value>�N���C�A���g����Ώۍ���ID�𓊂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����W�v���@(�o�͏�)�t��3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DemandSumOdrAttend3
		{
			get{return _demandSumOdrAttend3;}
			set{_demandSumOdrAttend3 = value;}
		}

		/// public propaty name  :  PaymentSumOdr1
		/// <summary>�x���W�v���@(�o�͏�)1�v���p�e�B</summary>
		/// <value>�N���C�A���g����Ώۍ���ID�𓊂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���W�v���@(�o�͏�)1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PaymentSumOdr1
		{
			get{return _paymentSumOdr1;}
			set{_paymentSumOdr1 = value;}
		}

		/// public propaty name  :  PaymentSumOdrAttend1
		/// <summary>�x���W�v���@(�o�͏�)�t��1�v���p�e�B</summary>
		/// <value>�N���C�A���g����Ώۍ���ID�𓊂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���W�v���@(�o�͏�)�t��1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PaymentSumOdrAttend1
		{
			get{return _paymentSumOdrAttend1;}
			set{_paymentSumOdrAttend1 = value;}
		}

		/// public propaty name  :  PaymentSumOdr2
		/// <summary>�x���W�v���@(�o�͏�)2�v���p�e�B</summary>
		/// <value>�N���C�A���g����Ώۍ���ID�𓊂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���W�v���@(�o�͏�)2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PaymentSumOdr2
		{
			get{return _paymentSumOdr2;}
			set{_paymentSumOdr2 = value;}
		}

		/// public propaty name  :  PaymentSumOdrAttend2
		/// <summary>�x���W�v���@(�o�͏�)�t��2�v���p�e�B</summary>
		/// <value>�N���C�A���g����Ώۍ���ID�𓊂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���W�v���@(�o�͏�)�t��2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PaymentSumOdrAttend2
		{
			get{return _paymentSumOdrAttend2;}
			set{_paymentSumOdrAttend2 = value;}
		}

		/// public propaty name  :  PaymentSumOdr3
		/// <summary>�x���W�v���@(�o�͏�)3�v���p�e�B</summary>
		/// <value>�N���C�A���g����Ώۍ���ID�𓊂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���W�v���@(�o�͏�)3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PaymentSumOdr3
		{
			get{return _paymentSumOdr3;}
			set{_paymentSumOdr3 = value;}
		}

		/// public propaty name  :  PaymentSumOdrAttend3
		/// <summary>�x���W�v���@(�o�͏�)�t��3�v���p�e�B</summary>
		/// <value>�N���C�A���g����Ώۍ���ID�𓊂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���W�v���@(�o�͏�)�t��3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PaymentSumOdrAttend3
		{
			get{return _paymentSumOdrAttend3;}
			set{_paymentSumOdrAttend3 = value;}
		}

		/// public propaty name  :  ForceDmdMggCd
		/// <summary>�����������i�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����������i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String[] ForceDmdMggCd
		{
			get{return _forceDmdMggCd;}
			set{_forceDmdMggCd = value;}
		}

		/// public propaty name  :  ForcePayMggCd
		/// <summary>�����x�����i�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����x�����i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String[] ForcePayMggCd
		{
			get{return _forcePayMggCd;}
			set{_forcePayMggCd = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>��Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  AddUpSecName
		/// <summary>�v�㋒�_���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpSecName
		{
			get{return _addUpSecName;}
			set{_addUpSecName = value;}
		}


		/// <summary>
		/// ������(�ӕ����׏��)���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_DemandDtlGrpSum�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandDtlGrpSum�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_DemandDtlGrpSum()
		{
		}

		/// <summary>
		/// ������(�ӕ����׏��)���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="addUpSecCode">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
		/// <param name="addUpADateSt">���o�Ώیv���(�J�n)("YYYYMMDD"  ������J�n�v����ƂȂ�N����)</param>
		/// <param name="addUpADateEd">���o�Ώیv���(�I��)("YYYYMMDD"  ������I���v����ƂȂ�N����)</param>
		/// <param name="claimCode">������R�[�h</param>
		/// <param name="isExtractDepo">�������ג��o�L��</param>
		/// <param name="countSheets">�����o�͐ݒ�</param>
		/// <param name="demandSumOdr1">�����W�v���@(�o�͏�)1(�N���C�A���g����Ώۍ���ID�𓊂���)</param>
		/// <param name="demandSumOdrAttend1">�����W�v���@(�o�͏�)�t��1(�N���C�A���g����Ώۍ���ID�𓊂���)</param>
		/// <param name="demandSumOdr2">�����W�v���@(�o�͏�)2(�N���C�A���g����Ώۍ���ID�𓊂���)</param>
		/// <param name="demandSumOdrAttend2">�����W�v���@(�o�͏�)�t��2(�N���C�A���g����Ώۍ���ID�𓊂���)</param>
		/// <param name="demandSumOdr3">�����W�v���@(�o�͏�)3(�N���C�A���g����Ώۍ���ID�𓊂���)</param>
		/// <param name="demandSumOdrAttend3">�����W�v���@(�o�͏�)�t��3(�N���C�A���g����Ώۍ���ID�𓊂���)</param>
		/// <param name="paymentSumOdr1">�x���W�v���@(�o�͏�)1(�N���C�A���g����Ώۍ���ID�𓊂���)</param>
		/// <param name="paymentSumOdrAttend1">�x���W�v���@(�o�͏�)�t��1(�N���C�A���g����Ώۍ���ID�𓊂���)</param>
		/// <param name="paymentSumOdr2">�x���W�v���@(�o�͏�)2(�N���C�A���g����Ώۍ���ID�𓊂���)</param>
		/// <param name="paymentSumOdrAttend2">�x���W�v���@(�o�͏�)�t��2(�N���C�A���g����Ώۍ���ID�𓊂���)</param>
		/// <param name="paymentSumOdr3">�x���W�v���@(�o�͏�)3(�N���C�A���g����Ώۍ���ID�𓊂���)</param>
		/// <param name="paymentSumOdrAttend3">�x���W�v���@(�o�͏�)�t��3(�N���C�A���g����Ώۍ���ID�𓊂���)</param>
		/// <param name="forceDmdMggCd">�����������i�敪</param>
		/// <param name="forcePayMggCd">�����x�����i�敪</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="addUpSecName">�v�㋒�_����</param>
		/// <returns>ExtrInfo_DemandDtlGrpSum�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandDtlGrpSum�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public ExtrInfo_DemandDtlGrpSum(string enterpriseCode, string addUpSecCode, Int32 addUpADateSt, Int32 addUpADateEd, Int32 claimCode, bool isExtractDepo, Int32 countSheets, string demandSumOdr1, string demandSumOdrAttend1, string demandSumOdr2, string demandSumOdrAttend2, string demandSumOdr3, string demandSumOdrAttend3, string paymentSumOdr1, string paymentSumOdrAttend1, string paymentSumOdr2, string paymentSumOdrAttend2, string paymentSumOdr3, string paymentSumOdrAttend3, String[] forceDmdMggCd, String[] forcePayMggCd, string enterpriseName, string addUpSecName)
		{
			this._enterpriseCode = enterpriseCode;
			this._addUpSecCode = addUpSecCode;
			this._addUpADateSt = addUpADateSt;
			this._addUpADateEd = addUpADateEd;
			this._claimCode = claimCode;
			this._isExtractDepo = isExtractDepo;
			this._countSheets = countSheets;
			this._demandSumOdr1 = demandSumOdr1;
			this._demandSumOdrAttend1 = demandSumOdrAttend1;
			this._demandSumOdr2 = demandSumOdr2;
			this._demandSumOdrAttend2 = demandSumOdrAttend2;
			this._demandSumOdr3 = demandSumOdr3;
			this._demandSumOdrAttend3 = demandSumOdrAttend3;
			this._paymentSumOdr1 = paymentSumOdr1;
			this._paymentSumOdrAttend1 = paymentSumOdrAttend1;
			this._paymentSumOdr2 = paymentSumOdr2;
			this._paymentSumOdrAttend2 = paymentSumOdrAttend2;
			this._paymentSumOdr3 = paymentSumOdr3;
			this._paymentSumOdrAttend3 = paymentSumOdrAttend3;
			this._forceDmdMggCd = forceDmdMggCd;
			this._forcePayMggCd = forcePayMggCd;
			this._enterpriseName = enterpriseName;
			this._addUpSecName = addUpSecName;

		}

		/// <summary>
		/// ������(�ӕ����׏��)���o�����N���X��������
		/// </summary>
		/// <returns>ExtrInfo_DemandDtlGrpSum�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ExtrInfo_DemandDtlGrpSum�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_DemandDtlGrpSum Clone()
		{
			return new ExtrInfo_DemandDtlGrpSum(this._enterpriseCode,this._addUpSecCode,this._addUpADateSt,this._addUpADateEd,this._claimCode,this._isExtractDepo,this._countSheets,this._demandSumOdr1,this._demandSumOdrAttend1,this._demandSumOdr2,this._demandSumOdrAttend2,this._demandSumOdr3,this._demandSumOdrAttend3,this._paymentSumOdr1,this._paymentSumOdrAttend1,this._paymentSumOdr2,this._paymentSumOdrAttend2,this._paymentSumOdr3,this._paymentSumOdrAttend3,this._forceDmdMggCd,this._forcePayMggCd,this._enterpriseName,this._addUpSecName);
		}

		/// <summary>
		/// ������(�ӕ����׏��)���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_DemandDtlGrpSum�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandDtlGrpSum�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ExtrInfo_DemandDtlGrpSum target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.AddUpSecCode == target.AddUpSecCode)
				 && (this.AddUpADateSt == target.AddUpADateSt)
				 && (this.AddUpADateEd == target.AddUpADateEd)
				 && (this.ClaimCode == target.ClaimCode)
				 && (this.IsExtractDepo == target.IsExtractDepo)
				 && (this.CountSheets == target.CountSheets)
				 && (this.DemandSumOdr1 == target.DemandSumOdr1)
				 && (this.DemandSumOdrAttend1 == target.DemandSumOdrAttend1)
				 && (this.DemandSumOdr2 == target.DemandSumOdr2)
				 && (this.DemandSumOdrAttend2 == target.DemandSumOdrAttend2)
				 && (this.DemandSumOdr3 == target.DemandSumOdr3)
				 && (this.DemandSumOdrAttend3 == target.DemandSumOdrAttend3)
				 && (this.PaymentSumOdr1 == target.PaymentSumOdr1)
				 && (this.PaymentSumOdrAttend1 == target.PaymentSumOdrAttend1)
				 && (this.PaymentSumOdr2 == target.PaymentSumOdr2)
				 && (this.PaymentSumOdrAttend2 == target.PaymentSumOdrAttend2)
				 && (this.PaymentSumOdr3 == target.PaymentSumOdr3)
				 && (this.PaymentSumOdrAttend3 == target.PaymentSumOdrAttend3)
				 && (this.ForceDmdMggCd == target.ForceDmdMggCd)
				 && (this.ForcePayMggCd == target.ForcePayMggCd)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.AddUpSecName == target.AddUpSecName));
		}

		/// <summary>
		/// ������(�ӕ����׏��)���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_DemandDtlGrpSum1">
		///                    ��r����ExtrInfo_DemandDtlGrpSum�N���X�̃C���X�^���X
		/// </param>
		/// <param name="extrInfo_DemandDtlGrpSum2">��r����ExtrInfo_DemandDtlGrpSum�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandDtlGrpSum�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_DemandDtlGrpSum extrInfo_DemandDtlGrpSum1, ExtrInfo_DemandDtlGrpSum extrInfo_DemandDtlGrpSum2)
		{
			return ((extrInfo_DemandDtlGrpSum1.EnterpriseCode == extrInfo_DemandDtlGrpSum2.EnterpriseCode)
				 && (extrInfo_DemandDtlGrpSum1.AddUpSecCode == extrInfo_DemandDtlGrpSum2.AddUpSecCode)
				 && (extrInfo_DemandDtlGrpSum1.AddUpADateSt == extrInfo_DemandDtlGrpSum2.AddUpADateSt)
				 && (extrInfo_DemandDtlGrpSum1.AddUpADateEd == extrInfo_DemandDtlGrpSum2.AddUpADateEd)
				 && (extrInfo_DemandDtlGrpSum1.ClaimCode == extrInfo_DemandDtlGrpSum2.ClaimCode)
				 && (extrInfo_DemandDtlGrpSum1.IsExtractDepo == extrInfo_DemandDtlGrpSum2.IsExtractDepo)
				 && (extrInfo_DemandDtlGrpSum1.CountSheets == extrInfo_DemandDtlGrpSum2.CountSheets)
				 && (extrInfo_DemandDtlGrpSum1.DemandSumOdr1 == extrInfo_DemandDtlGrpSum2.DemandSumOdr1)
				 && (extrInfo_DemandDtlGrpSum1.DemandSumOdrAttend1 == extrInfo_DemandDtlGrpSum2.DemandSumOdrAttend1)
				 && (extrInfo_DemandDtlGrpSum1.DemandSumOdr2 == extrInfo_DemandDtlGrpSum2.DemandSumOdr2)
				 && (extrInfo_DemandDtlGrpSum1.DemandSumOdrAttend2 == extrInfo_DemandDtlGrpSum2.DemandSumOdrAttend2)
				 && (extrInfo_DemandDtlGrpSum1.DemandSumOdr3 == extrInfo_DemandDtlGrpSum2.DemandSumOdr3)
				 && (extrInfo_DemandDtlGrpSum1.DemandSumOdrAttend3 == extrInfo_DemandDtlGrpSum2.DemandSumOdrAttend3)
				 && (extrInfo_DemandDtlGrpSum1.PaymentSumOdr1 == extrInfo_DemandDtlGrpSum2.PaymentSumOdr1)
				 && (extrInfo_DemandDtlGrpSum1.PaymentSumOdrAttend1 == extrInfo_DemandDtlGrpSum2.PaymentSumOdrAttend1)
				 && (extrInfo_DemandDtlGrpSum1.PaymentSumOdr2 == extrInfo_DemandDtlGrpSum2.PaymentSumOdr2)
				 && (extrInfo_DemandDtlGrpSum1.PaymentSumOdrAttend2 == extrInfo_DemandDtlGrpSum2.PaymentSumOdrAttend2)
				 && (extrInfo_DemandDtlGrpSum1.PaymentSumOdr3 == extrInfo_DemandDtlGrpSum2.PaymentSumOdr3)
				 && (extrInfo_DemandDtlGrpSum1.PaymentSumOdrAttend3 == extrInfo_DemandDtlGrpSum2.PaymentSumOdrAttend3)
				 && (extrInfo_DemandDtlGrpSum1.ForceDmdMggCd == extrInfo_DemandDtlGrpSum2.ForceDmdMggCd)
				 && (extrInfo_DemandDtlGrpSum1.ForcePayMggCd == extrInfo_DemandDtlGrpSum2.ForcePayMggCd)
				 && (extrInfo_DemandDtlGrpSum1.EnterpriseName == extrInfo_DemandDtlGrpSum2.EnterpriseName)
				 && (extrInfo_DemandDtlGrpSum1.AddUpSecName == extrInfo_DemandDtlGrpSum2.AddUpSecName));
		}
		/// <summary>
		/// ������(�ӕ����׏��)���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_DemandDtlGrpSum�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandDtlGrpSum�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_DemandDtlGrpSum target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.AddUpSecCode != target.AddUpSecCode)resList.Add("AddUpSecCode");
			if(this.AddUpADateSt != target.AddUpADateSt)resList.Add("AddUpADateSt");
			if(this.AddUpADateEd != target.AddUpADateEd)resList.Add("AddUpADateEd");
			if(this.ClaimCode != target.ClaimCode)resList.Add("ClaimCode");
			if(this.IsExtractDepo != target.IsExtractDepo)resList.Add("IsExtractDepo");
			if(this.CountSheets != target.CountSheets)resList.Add("CountSheets");
			if(this.DemandSumOdr1 != target.DemandSumOdr1)resList.Add("DemandSumOdr1");
			if(this.DemandSumOdrAttend1 != target.DemandSumOdrAttend1)resList.Add("DemandSumOdrAttend1");
			if(this.DemandSumOdr2 != target.DemandSumOdr2)resList.Add("DemandSumOdr2");
			if(this.DemandSumOdrAttend2 != target.DemandSumOdrAttend2)resList.Add("DemandSumOdrAttend2");
			if(this.DemandSumOdr3 != target.DemandSumOdr3)resList.Add("DemandSumOdr3");
			if(this.DemandSumOdrAttend3 != target.DemandSumOdrAttend3)resList.Add("DemandSumOdrAttend3");
			if(this.PaymentSumOdr1 != target.PaymentSumOdr1)resList.Add("PaymentSumOdr1");
			if(this.PaymentSumOdrAttend1 != target.PaymentSumOdrAttend1)resList.Add("PaymentSumOdrAttend1");
			if(this.PaymentSumOdr2 != target.PaymentSumOdr2)resList.Add("PaymentSumOdr2");
			if(this.PaymentSumOdrAttend2 != target.PaymentSumOdrAttend2)resList.Add("PaymentSumOdrAttend2");
			if(this.PaymentSumOdr3 != target.PaymentSumOdr3)resList.Add("PaymentSumOdr3");
			if(this.PaymentSumOdrAttend3 != target.PaymentSumOdrAttend3)resList.Add("PaymentSumOdrAttend3");
			if(this.ForceDmdMggCd != target.ForceDmdMggCd)resList.Add("ForceDmdMggCd");
			if(this.ForcePayMggCd != target.ForcePayMggCd)resList.Add("ForcePayMggCd");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.AddUpSecName != target.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}

		/// <summary>
		/// ������(�ӕ����׏��)���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_DemandDtlGrpSum1">��r����ExtrInfo_DemandDtlGrpSum�N���X�̃C���X�^���X</param>
		/// <param name="extrInfo_DemandDtlGrpSum2">��r����ExtrInfo_DemandDtlGrpSum�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandDtlGrpSum�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_DemandDtlGrpSum extrInfo_DemandDtlGrpSum1, ExtrInfo_DemandDtlGrpSum extrInfo_DemandDtlGrpSum2)
		{
			ArrayList resList = new ArrayList();
			if(extrInfo_DemandDtlGrpSum1.EnterpriseCode != extrInfo_DemandDtlGrpSum2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(extrInfo_DemandDtlGrpSum1.AddUpSecCode != extrInfo_DemandDtlGrpSum2.AddUpSecCode)resList.Add("AddUpSecCode");
			if(extrInfo_DemandDtlGrpSum1.AddUpADateSt != extrInfo_DemandDtlGrpSum2.AddUpADateSt)resList.Add("AddUpADateSt");
			if(extrInfo_DemandDtlGrpSum1.AddUpADateEd != extrInfo_DemandDtlGrpSum2.AddUpADateEd)resList.Add("AddUpADateEd");
			if(extrInfo_DemandDtlGrpSum1.ClaimCode != extrInfo_DemandDtlGrpSum2.ClaimCode)resList.Add("ClaimCode");
			if(extrInfo_DemandDtlGrpSum1.IsExtractDepo != extrInfo_DemandDtlGrpSum2.IsExtractDepo)resList.Add("IsExtractDepo");
			if(extrInfo_DemandDtlGrpSum1.CountSheets != extrInfo_DemandDtlGrpSum2.CountSheets)resList.Add("CountSheets");
			if(extrInfo_DemandDtlGrpSum1.DemandSumOdr1 != extrInfo_DemandDtlGrpSum2.DemandSumOdr1)resList.Add("DemandSumOdr1");
			if(extrInfo_DemandDtlGrpSum1.DemandSumOdrAttend1 != extrInfo_DemandDtlGrpSum2.DemandSumOdrAttend1)resList.Add("DemandSumOdrAttend1");
			if(extrInfo_DemandDtlGrpSum1.DemandSumOdr2 != extrInfo_DemandDtlGrpSum2.DemandSumOdr2)resList.Add("DemandSumOdr2");
			if(extrInfo_DemandDtlGrpSum1.DemandSumOdrAttend2 != extrInfo_DemandDtlGrpSum2.DemandSumOdrAttend2)resList.Add("DemandSumOdrAttend2");
			if(extrInfo_DemandDtlGrpSum1.DemandSumOdr3 != extrInfo_DemandDtlGrpSum2.DemandSumOdr3)resList.Add("DemandSumOdr3");
			if(extrInfo_DemandDtlGrpSum1.DemandSumOdrAttend3 != extrInfo_DemandDtlGrpSum2.DemandSumOdrAttend3)resList.Add("DemandSumOdrAttend3");
			if(extrInfo_DemandDtlGrpSum1.PaymentSumOdr1 != extrInfo_DemandDtlGrpSum2.PaymentSumOdr1)resList.Add("PaymentSumOdr1");
			if(extrInfo_DemandDtlGrpSum1.PaymentSumOdrAttend1 != extrInfo_DemandDtlGrpSum2.PaymentSumOdrAttend1)resList.Add("PaymentSumOdrAttend1");
			if(extrInfo_DemandDtlGrpSum1.PaymentSumOdr2 != extrInfo_DemandDtlGrpSum2.PaymentSumOdr2)resList.Add("PaymentSumOdr2");
			if(extrInfo_DemandDtlGrpSum1.PaymentSumOdrAttend2 != extrInfo_DemandDtlGrpSum2.PaymentSumOdrAttend2)resList.Add("PaymentSumOdrAttend2");
			if(extrInfo_DemandDtlGrpSum1.PaymentSumOdr3 != extrInfo_DemandDtlGrpSum2.PaymentSumOdr3)resList.Add("PaymentSumOdr3");
			if(extrInfo_DemandDtlGrpSum1.PaymentSumOdrAttend3 != extrInfo_DemandDtlGrpSum2.PaymentSumOdrAttend3)resList.Add("PaymentSumOdrAttend3");
			if(extrInfo_DemandDtlGrpSum1.ForceDmdMggCd != extrInfo_DemandDtlGrpSum2.ForceDmdMggCd)resList.Add("ForceDmdMggCd");
			if(extrInfo_DemandDtlGrpSum1.ForcePayMggCd != extrInfo_DemandDtlGrpSum2.ForcePayMggCd)resList.Add("ForcePayMggCd");
			if(extrInfo_DemandDtlGrpSum1.EnterpriseName != extrInfo_DemandDtlGrpSum2.EnterpriseName)resList.Add("EnterpriseName");
			if(extrInfo_DemandDtlGrpSum1.AddUpSecName != extrInfo_DemandDtlGrpSum2.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}
	}
}
