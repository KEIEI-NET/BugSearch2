using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustomerClaimConf
	/// <summary>
	///                      ������m�F
	/// </summary>
	/// <remarks>
	/// <br>note             :   ������m�F�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/02/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CustomerClaimConf
	{
		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>�Ǘ����_�R�[�h</summary>
		private string _mngSectionCode = "";

		/// <summary>�v�㋒�_�R�[�h</summary>
		private string _addUpSectionCode = "";

		/// <summary>����</summary>
		private string _name = "";

		/// <summary>����2</summary>
		private string _name2 = "";

		/// <summary>���Ӑ旪��</summary>
		private string _customerSnm = "";

		/// <summary>�W�����敪�R�[�h</summary>
		/// <remarks>�v���</remarks>
		private Int32 _collectMoneyCode;

		/// <summary>�����X�V�N����</summary>
		/// <remarks>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</remarks>
		private DateTime _addUpADate;

		/// <summary>�O������X�V�N����</summary>
		private DateTime _lastCAddUpUpdDate;

		/// <summary>�O�񐿋����z</summary>
		/// <remarks>DD</remarks>
		private Int64 _lastTimeDemand;

		/// <summary>����</summary>
		/// <remarks>0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</remarks>
		private Int32 _totalDay;

		/// <summary>����œ]�ŕ���</summary>
		/// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
		private Int32 _consTaxLayMethod;

		/// <summary>���z�\�����@�敪</summary>
		/// <remarks>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj</remarks>
		private Int32 _totalAmountDispWayCd;

		/// <summary>����Œ[�������敪</summary>
		private Int32 _taxFractionProcCd;

		/// <summary>�Ζ���TEL�\������</summary>
		private string _officeTelNoDspName = "";

		/// <summary>�Ζ���FAX�\������</summary>
		private string _officeFaxNoDspName = "";

		/// <summary>�d�b�ԍ��i�Ζ���j</summary>
		private string _officeTelNo = "";

		/// <summary>FAX�ԍ��i�Ζ���j</summary>
		private string _officeFaxNo = "";

		/// <summary>�^�M�Ǘ��敪</summary>
		private Int32 _creditMngCode;

		/// <summary>���񊨒�J�n��</summary>
		/// <remarks>01�`31�܂Łi�ȗ��\�j</remarks>
		private Int32 _nTimeCalcStDate;

		/// <summary>���Ӑ�S����</summary>
		/// <remarks>���Ӑ�̎Ј���</remarks>
		private string _customerAgent = "";

		/// <summary>�Ǘ����_����</summary>
		private string _mngSectionName = "";


		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get { return _customerCode; }
			set { _customerCode = value; }
		}

		/// public propaty name  :  MngSectionCode
		/// <summary>�Ǘ����_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ǘ����_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MngSectionCode
		{
			get { return _mngSectionCode; }
			set { _mngSectionCode = value; }
		}

		/// public propaty name  :  AddUpSectionCode
		/// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpSectionCode
		{
			get { return _addUpSectionCode; }
			set { _addUpSectionCode = value; }
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
			get { return _name; }
			set { _name = value; }
		}

		/// public propaty name  :  Name2
		/// <summary>����2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Name2
		{
			get { return _name2; }
			set { _name2 = value; }
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
			get { return _customerSnm; }
			set { _customerSnm = value; }
		}

		/// public propaty name  :  CollectMoneyCode
		/// <summary>�W�����敪�R�[�h�v���p�e�B</summary>
		/// <value>�v���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W�����敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CollectMoneyCode
		{
			get { return _collectMoneyCode; }
			set { _collectMoneyCode = value; }
		}

		/// public propaty name  :  AddUpADate
		/// <summary>�����X�V�N�����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpADate
		{
			get { return _addUpADate; }
			set { _addUpADate = value; }
		}

		/// public propaty name  :  AddUpADateJpFormal
		/// <summary>�����X�V�N���� �a��v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpADateJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _addUpADate); }
			set { }
		}

		/// public propaty name  :  AddUpADateJpInFormal
		/// <summary>�����X�V�N���� �a��(��)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpADateJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpADate); }
			set { }
		}

		/// public propaty name  :  AddUpADateAdFormal
		/// <summary>�����X�V�N���� ����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpADateAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpADate); }
			set { }
		}

		/// public propaty name  :  AddUpADateAdInFormal
		/// <summary>�����X�V�N���� ����(��)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpADateAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _addUpADate); }
			set { }
		}

		/// public propaty name  :  LastCAddUpUpdDate
		/// <summary>�O������X�V�N�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O������X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime LastCAddUpUpdDate
		{
			get { return _lastCAddUpUpdDate; }
			set { _lastCAddUpUpdDate = value; }
		}

		/// public propaty name  :  LastCAddUpUpdDateJpFormal
		/// <summary>�O������X�V�N���� �a��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O������X�V�N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastCAddUpUpdDateJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _lastCAddUpUpdDate); }
			set { }
		}

		/// public propaty name  :  LastCAddUpUpdDateJpInFormal
		/// <summary>�O������X�V�N���� �a��(��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O������X�V�N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastCAddUpUpdDateJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _lastCAddUpUpdDate); }
			set { }
		}

		/// public propaty name  :  LastCAddUpUpdDateAdFormal
		/// <summary>�O������X�V�N���� ����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O������X�V�N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastCAddUpUpdDateAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _lastCAddUpUpdDate); }
			set { }
		}

		/// public propaty name  :  LastCAddUpUpdDateAdInFormal
		/// <summary>�O������X�V�N���� ����(��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O������X�V�N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastCAddUpUpdDateAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _lastCAddUpUpdDate); }
			set { }
		}

		/// public propaty name  :  LastTimeDemand
		/// <summary>�O�񐿋����z�v���p�e�B</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�񐿋����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 LastTimeDemand
		{
			get { return _lastTimeDemand; }
			set { _lastTimeDemand = value; }
		}

		/// public propaty name  :  TotalDay
		/// <summary>�����v���p�e�B</summary>
		/// <value>0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get { return _totalDay; }
			set { _totalDay = value; }
		}

		/// public propaty name  :  ConsTaxLayMethod
		/// <summary>����œ]�ŕ����v���p�e�B</summary>
		/// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ConsTaxLayMethod
		{
			get { return _consTaxLayMethod; }
			set { _consTaxLayMethod = value; }
		}

		/// public propaty name  :  TotalAmountDispWayCd
		/// <summary>���z�\�����@�敪�v���p�e�B</summary>
		/// <value>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TotalAmountDispWayCd
		{
			get { return _totalAmountDispWayCd; }
			set { _totalAmountDispWayCd = value; }
		}

		/// public propaty name  :  TaxFractionProcCd
		/// <summary>����Œ[�������敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����Œ[�������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TaxFractionProcCd
		{
			get { return _taxFractionProcCd; }
			set { _taxFractionProcCd = value; }
		}

		/// public propaty name  :  OfficeTelNoDspName
		/// <summary>�Ζ���TEL�\�����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ζ���TEL�\�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OfficeTelNoDspName
		{
			get { return _officeTelNoDspName; }
			set { _officeTelNoDspName = value; }
		}

		/// public propaty name  :  OfficeFaxNoDspName
		/// <summary>�Ζ���FAX�\�����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ζ���FAX�\�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OfficeFaxNoDspName
		{
			get { return _officeFaxNoDspName; }
			set { _officeFaxNoDspName = value; }
		}

		/// public propaty name  :  OfficeTelNo
		/// <summary>�d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i�Ζ���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OfficeTelNo
		{
			get { return _officeTelNo; }
			set { _officeTelNo = value; }
		}

		/// public propaty name  :  OfficeFaxNo
		/// <summary>FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   FAX�ԍ��i�Ζ���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OfficeFaxNo
		{
			get { return _officeFaxNo; }
			set { _officeFaxNo = value; }
		}

		/// public propaty name  :  CreditMngCode
		/// <summary>�^�M�Ǘ��敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �^�M�Ǘ��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CreditMngCode
		{
			get { return _creditMngCode; }
			set { _creditMngCode = value; }
		}

		/// public propaty name  :  NTimeCalcStDate
		/// <summary>���񊨒�J�n���v���p�e�B</summary>
		/// <value>01�`31�܂Łi�ȗ��\�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񊨒�J�n���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NTimeCalcStDate
		{
			get { return _nTimeCalcStDate; }
			set { _nTimeCalcStDate = value; }
		}

		/// public propaty name  :  CustomerAgent
		/// <summary>���Ӑ�S���҃v���p�e�B</summary>
		/// <value>���Ӑ�̎Ј���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�S���҃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerAgent
		{
			get { return _customerAgent; }
			set { _customerAgent = value; }
		}

		/// public propaty name  :  MngSectionName
		/// <summary>�Ǘ����_���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ǘ����_���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MngSectionName
		{
			get { return _mngSectionName; }
			set { _mngSectionName = value; }
		}


		/// <summary>
		/// ������m�F�R���X�g���N�^
		/// </summary>
		/// <returns>CustomerClaimConf�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerClaimConf�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustomerClaimConf()
		{
		}

		/// <summary>
		/// ������m�F�R���X�g���N�^
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="mngSectionCode">�Ǘ����_�R�[�h</param>
		/// <param name="addUpSectionCode">�v�㋒�_�R�[�h</param>
		/// <param name="name">����</param>
		/// <param name="name2">����2</param>
		/// <param name="customerSnm">���Ӑ旪��</param>
		/// <param name="collectMoneyCode">�W�����敪�R�[�h(�v���)</param>
		/// <param name="addUpADate">�����X�V�N����("YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����)</param>
		/// <param name="lastCAddUpUpdDate">�O������X�V�N����</param>
		/// <param name="lastTimeDemand">�O�񐿋����z(DD)</param>
		/// <param name="totalDay">����(0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�)</param>
		/// <param name="consTaxLayMethod">����œ]�ŕ���(0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j)</param>
		/// <param name="totalAmountDispWayCd">���z�\�����@�敪(1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj)</param>
		/// <param name="taxFractionProcCd">����Œ[�������敪</param>
		/// <param name="officeTelNoDspName">�Ζ���TEL�\������</param>
		/// <param name="officeFaxNoDspName">�Ζ���FAX�\������</param>
		/// <param name="officeTelNo">�d�b�ԍ��i�Ζ���j</param>
		/// <param name="officeFaxNo">FAX�ԍ��i�Ζ���j</param>
		/// <param name="creditMngCode">�^�M�Ǘ��敪</param>
		/// <param name="nTimeCalcStDate">���񊨒�J�n��(01�`31�܂Łi�ȗ��\�j)</param>
		/// <param name="customerAgent">���Ӑ�S����(���Ӑ�̎Ј���)</param>
		/// <param name="mngSectionName">�Ǘ����_����</param>
		/// <returns>CustomerClaimConf�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerClaimConf�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustomerClaimConf( Int32 customerCode, string mngSectionCode, string addUpSectionCode, string name, string name2, string customerSnm, Int32 collectMoneyCode, DateTime addUpADate, DateTime lastCAddUpUpdDate, Int64 lastTimeDemand, Int32 totalDay, Int32 consTaxLayMethod, Int32 totalAmountDispWayCd, Int32 taxFractionProcCd, string officeTelNoDspName, string officeFaxNoDspName, string officeTelNo, string officeFaxNo, Int32 creditMngCode, Int32 nTimeCalcStDate, string customerAgent, string mngSectionName )
		{
			this._customerCode = customerCode;
			this._mngSectionCode = mngSectionCode;
			this._addUpSectionCode = addUpSectionCode;
			this._name = name;
			this._name2 = name2;
			this._customerSnm = customerSnm;
			this._collectMoneyCode = collectMoneyCode;
			this.AddUpADate = addUpADate;
			this.LastCAddUpUpdDate = lastCAddUpUpdDate;
			this._lastTimeDemand = lastTimeDemand;
			this._totalDay = totalDay;
			this._consTaxLayMethod = consTaxLayMethod;
			this._totalAmountDispWayCd = totalAmountDispWayCd;
			this._taxFractionProcCd = taxFractionProcCd;
			this._officeTelNoDspName = officeTelNoDspName;
			this._officeFaxNoDspName = officeFaxNoDspName;
			this._officeTelNo = officeTelNo;
			this._officeFaxNo = officeFaxNo;
			this._creditMngCode = creditMngCode;
			this._nTimeCalcStDate = nTimeCalcStDate;
			this._customerAgent = customerAgent;
			this._mngSectionName = mngSectionName;

		}

		/// <summary>
		/// ������m�F��������
		/// </summary>
		/// <returns>CustomerClaimConf�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustomerClaimConf�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustomerClaimConf Clone()
		{
			return new CustomerClaimConf(this._customerCode, this._mngSectionCode, this._addUpSectionCode, this._name, this._name2, this._customerSnm, this._collectMoneyCode, this._addUpADate, this._lastCAddUpUpdDate, this._lastTimeDemand, this._totalDay, this._consTaxLayMethod, this._totalAmountDispWayCd, this._taxFractionProcCd, this._officeTelNoDspName, this._officeFaxNoDspName, this._officeTelNo, this._officeFaxNo, this._creditMngCode, this._nTimeCalcStDate, this._customerAgent, this._mngSectionName);
		}

		/// <summary>
		/// ������m�F��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustomerClaimConf�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerClaimConf�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals( CustomerClaimConf target )
		{
			return ( ( this.CustomerCode == target.CustomerCode )
				 && ( this.MngSectionCode == target.MngSectionCode )
				 && ( this.AddUpSectionCode == target.AddUpSectionCode )
				 && ( this.Name == target.Name )
				 && ( this.Name2 == target.Name2 )
				 && ( this.CustomerSnm == target.CustomerSnm )
				 && ( this.CollectMoneyCode == target.CollectMoneyCode )
				 && ( this.AddUpADate == target.AddUpADate )
				 && ( this.LastCAddUpUpdDate == target.LastCAddUpUpdDate )
				 && ( this.LastTimeDemand == target.LastTimeDemand )
				 && ( this.TotalDay == target.TotalDay )
				 && ( this.ConsTaxLayMethod == target.ConsTaxLayMethod )
				 && ( this.TotalAmountDispWayCd == target.TotalAmountDispWayCd )
				 && ( this.TaxFractionProcCd == target.TaxFractionProcCd )
				 && ( this.OfficeTelNoDspName == target.OfficeTelNoDspName )
				 && ( this.OfficeFaxNoDspName == target.OfficeFaxNoDspName )
				 && ( this.OfficeTelNo == target.OfficeTelNo )
				 && ( this.OfficeFaxNo == target.OfficeFaxNo )
				 && ( this.CreditMngCode == target.CreditMngCode )
				 && ( this.NTimeCalcStDate == target.NTimeCalcStDate )
				 && ( this.CustomerAgent == target.CustomerAgent )
				 && ( this.MngSectionName == target.MngSectionName ) );
		}

		/// <summary>
		/// ������m�F��r����
		/// </summary>
		/// <param name="customerClaimConf1">
		///                    ��r����CustomerClaimConf�N���X�̃C���X�^���X
		/// </param>
		/// <param name="customerClaimConf2">��r����CustomerClaimConf�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerClaimConf�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals( CustomerClaimConf customerClaimConf1, CustomerClaimConf customerClaimConf2 )
		{
			return ( ( customerClaimConf1.CustomerCode == customerClaimConf2.CustomerCode )
				 && ( customerClaimConf1.MngSectionCode == customerClaimConf2.MngSectionCode )
				 && ( customerClaimConf1.AddUpSectionCode == customerClaimConf2.AddUpSectionCode )
				 && ( customerClaimConf1.Name == customerClaimConf2.Name )
				 && ( customerClaimConf1.Name2 == customerClaimConf2.Name2 )
				 && ( customerClaimConf1.CustomerSnm == customerClaimConf2.CustomerSnm )
				 && ( customerClaimConf1.CollectMoneyCode == customerClaimConf2.CollectMoneyCode )
				 && ( customerClaimConf1.AddUpADate == customerClaimConf2.AddUpADate )
				 && ( customerClaimConf1.LastCAddUpUpdDate == customerClaimConf2.LastCAddUpUpdDate )
				 && ( customerClaimConf1.LastTimeDemand == customerClaimConf2.LastTimeDemand )
				 && ( customerClaimConf1.TotalDay == customerClaimConf2.TotalDay )
				 && ( customerClaimConf1.ConsTaxLayMethod == customerClaimConf2.ConsTaxLayMethod )
				 && ( customerClaimConf1.TotalAmountDispWayCd == customerClaimConf2.TotalAmountDispWayCd )
				 && ( customerClaimConf1.TaxFractionProcCd == customerClaimConf2.TaxFractionProcCd )
				 && ( customerClaimConf1.OfficeTelNoDspName == customerClaimConf2.OfficeTelNoDspName )
				 && ( customerClaimConf1.OfficeFaxNoDspName == customerClaimConf2.OfficeFaxNoDspName )
				 && ( customerClaimConf1.OfficeTelNo == customerClaimConf2.OfficeTelNo )
				 && ( customerClaimConf1.OfficeFaxNo == customerClaimConf2.OfficeFaxNo )
				 && ( customerClaimConf1.CreditMngCode == customerClaimConf2.CreditMngCode )
				 && ( customerClaimConf1.NTimeCalcStDate == customerClaimConf2.NTimeCalcStDate )
				 && ( customerClaimConf1.CustomerAgent == customerClaimConf2.CustomerAgent )
				 && ( customerClaimConf1.MngSectionName == customerClaimConf2.MngSectionName ) );
		}
		/// <summary>
		/// ������m�F��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustomerClaimConf�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerClaimConf�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare( CustomerClaimConf target )
		{
			ArrayList resList = new ArrayList();
			if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
			if (this.MngSectionCode != target.MngSectionCode) resList.Add("MngSectionCode");
			if (this.AddUpSectionCode != target.AddUpSectionCode) resList.Add("AddUpSectionCode");
			if (this.Name != target.Name) resList.Add("Name");
			if (this.Name2 != target.Name2) resList.Add("Name2");
			if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
			if (this.CollectMoneyCode != target.CollectMoneyCode) resList.Add("CollectMoneyCode");
			if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
			if (this.LastCAddUpUpdDate != target.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
			if (this.LastTimeDemand != target.LastTimeDemand) resList.Add("LastTimeDemand");
			if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
			if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
			if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
			if (this.TaxFractionProcCd != target.TaxFractionProcCd) resList.Add("TaxFractionProcCd");
			if (this.OfficeTelNoDspName != target.OfficeTelNoDspName) resList.Add("OfficeTelNoDspName");
			if (this.OfficeFaxNoDspName != target.OfficeFaxNoDspName) resList.Add("OfficeFaxNoDspName");
			if (this.OfficeTelNo != target.OfficeTelNo) resList.Add("OfficeTelNo");
			if (this.OfficeFaxNo != target.OfficeFaxNo) resList.Add("OfficeFaxNo");
			if (this.CreditMngCode != target.CreditMngCode) resList.Add("CreditMngCode");
			if (this.NTimeCalcStDate != target.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
			if (this.CustomerAgent != target.CustomerAgent) resList.Add("CustomerAgent");
			if (this.MngSectionName != target.MngSectionName) resList.Add("MngSectionName");

			return resList;
		}

		/// <summary>
		/// ������m�F��r����
		/// </summary>
		/// <param name="customerClaimConf1">��r����CustomerClaimConf�N���X�̃C���X�^���X</param>
		/// <param name="customerClaimConf2">��r����CustomerClaimConf�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerClaimConf�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare( CustomerClaimConf customerClaimConf1, CustomerClaimConf customerClaimConf2 )
		{
			ArrayList resList = new ArrayList();
			if (customerClaimConf1.CustomerCode != customerClaimConf2.CustomerCode) resList.Add("CustomerCode");
			if (customerClaimConf1.MngSectionCode != customerClaimConf2.MngSectionCode) resList.Add("MngSectionCode");
			if (customerClaimConf1.AddUpSectionCode != customerClaimConf2.AddUpSectionCode) resList.Add("AddUpSectionCode");
			if (customerClaimConf1.Name != customerClaimConf2.Name) resList.Add("Name");
			if (customerClaimConf1.Name2 != customerClaimConf2.Name2) resList.Add("Name2");
			if (customerClaimConf1.CustomerSnm != customerClaimConf2.CustomerSnm) resList.Add("CustomerSnm");
			if (customerClaimConf1.CollectMoneyCode != customerClaimConf2.CollectMoneyCode) resList.Add("CollectMoneyCode");
			if (customerClaimConf1.AddUpADate != customerClaimConf2.AddUpADate) resList.Add("AddUpADate");
			if (customerClaimConf1.LastCAddUpUpdDate != customerClaimConf2.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
			if (customerClaimConf1.LastTimeDemand != customerClaimConf2.LastTimeDemand) resList.Add("LastTimeDemand");
			if (customerClaimConf1.TotalDay != customerClaimConf2.TotalDay) resList.Add("TotalDay");
			if (customerClaimConf1.ConsTaxLayMethod != customerClaimConf2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
			if (customerClaimConf1.TotalAmountDispWayCd != customerClaimConf2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
			if (customerClaimConf1.TaxFractionProcCd != customerClaimConf2.TaxFractionProcCd) resList.Add("TaxFractionProcCd");
			if (customerClaimConf1.OfficeTelNoDspName != customerClaimConf2.OfficeTelNoDspName) resList.Add("OfficeTelNoDspName");
			if (customerClaimConf1.OfficeFaxNoDspName != customerClaimConf2.OfficeFaxNoDspName) resList.Add("OfficeFaxNoDspName");
			if (customerClaimConf1.OfficeTelNo != customerClaimConf2.OfficeTelNo) resList.Add("OfficeTelNo");
			if (customerClaimConf1.OfficeFaxNo != customerClaimConf2.OfficeFaxNo) resList.Add("OfficeFaxNo");
			if (customerClaimConf1.CreditMngCode != customerClaimConf2.CreditMngCode) resList.Add("CreditMngCode");
			if (customerClaimConf1.NTimeCalcStDate != customerClaimConf2.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
			if (customerClaimConf1.CustomerAgent != customerClaimConf2.CustomerAgent) resList.Add("CustomerAgent");
			if (customerClaimConf1.MngSectionName != customerClaimConf2.MngSectionName) resList.Add("MngSectionName");

			return resList;
		}
	}
}
