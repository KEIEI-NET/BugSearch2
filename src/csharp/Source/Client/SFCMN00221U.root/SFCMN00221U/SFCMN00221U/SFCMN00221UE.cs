using System;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ǂݍ��݃A�Z���u�����N���X(�����`���[�N���p)
	/// </summary>
	/// <remarks>
	/// <br>Note       : �A�Z���u����ǂݍ��ނ��߂̏��N���X�ł��B</br>
	/// <br>Programer  : 980076�@�Ȓ��@����Y</br>
	/// <br>Date       : 2006.03.08</br>
	/// <br>Update Note:</br>
	/// <br>2006.11.17 men SoftwareCode��ǉ�</br>
	/// </remarks>
	[Serializable]
	public class LuncherStartAssemblyInfo
	{
		/// <summary>
		/// �A�Z���u������
		/// </summary>
		private	string _assemblyName = "";
		/// <summary>
		/// �N���X����
		/// </summary>
		private	string _className = "";
		/// <summary>
		/// �N�����[�h(0:�����Ȃ� 1:���Ӑ�w�� 2:�ԗ��w��)
		/// </summary>
		private	int _mode;
		/// <summary>
		/// ��ʕ\������
		/// </summary>
		private	string _dispName = "";
		/// <summary>
		/// �A�C�R���C���[�W�ԍ�
		/// </summary>
		private	int _imageNo = -1;
		/// <summary>
		/// �I�v�V�����R�[�h
		/// </summary>
		private string _softwareCode = "";

		/// <summary>
		/// �A�Z���u�����̃v���p�e�B
		/// </summary>
		public string AssemblyName
		{
			get { return _assemblyName; }
			set { this._assemblyName = value; }
		}
		/// <summary>
		/// �N���X���̃v���p�e�B
		/// </summary>
		public string	ClassName
		{
			get { return _className; }
			set { this._className = value; }
		}
		/// <summary>
		/// �N�����[�h�v���p�e�B
		/// </summary>
		public int	Mode
		{
			get { return _mode; }
			set { this._mode = value; }
		}
		/// <summary>
		/// ��ʕ\�����̃v���p�e�B
		/// </summary>
		public string	DispName
		{
			get { return _dispName; }
			set { this._dispName = value; }
		}
		/// <summary>
		/// �A�C�R���C���[�W�ԍ��v���p�e�B
		/// </summary>
		public int	ImageNo
		{
			get { return _imageNo; }
			set { this._imageNo = value; }
		}
		/// <summary>
		/// �I�v�V�����R�[�h�v���p�e�B
		/// </summary>
		public string SoftwareCode
		{
			get { return _softwareCode; }
			set { this._softwareCode = value; }
		}
	}

	/// <summary>
	/// TOP���j���[�\�����N���X(�����`���[�N���p)
	/// </summary>
	/// <remarks>
	/// <br>Note       : TOP���j���[��\��������N���X�ł��B</br>
	/// <br>Programer  : 980076�@�Ȓ��@����Y</br>
	/// <br>Date       : 2006.03.08</br>
	/// <br>Update Note:</br>
	/// </remarks>
	[Serializable]
	public class LuncherTopMenuInfo
	{
		/// <summary>
		/// �N�����[�h
		/// </summary>
		private	int			_mode;
		/// <summary>
		/// ��ʕ\������
		/// </summary>
		private	string		_dispName;
		/// <summary>
		/// �A�C�R���C���[�W�ԍ�
		/// </summary>
		private	int			_imageNo = -1;

		/// <summary>
		/// �A�Z���u������
		/// </summary>
		private	string		_assemblyName;
		/// <summary>
		/// �N���X����
		/// </summary>
		private	string		_className;

		/// <summary>
		/// �N�����[�h�v���p�e�B
		/// </summary>
		public int	Mode
		{
			get { return _mode; }
			set { this._mode = value; }
		}
		/// <summary>
		/// ��ʕ\�����̃v���p�e�B
		/// </summary>
		public string	DispName
		{
			get { return _dispName; }
			set { this._dispName = value; }
		}
		/// <summary>
		/// �A�C�R���C���[�W�ԍ��v���p�e�B
		/// </summary>
		public int	ImageNo
		{
			get { return _imageNo; }
			set { this._imageNo = value; }
		}

		/// <summary>
		/// �A�Z���u�����̃v���p�e�B
		/// </summary>
		public string AssemblyName
		{
			get { return _assemblyName; }
			set { this._assemblyName = value; }
		}
		/// <summary>
		/// �N���X���̃v���p�e�B
		/// </summary>
		public string	ClassName
		{
			get { return _className; }
			set { this._className = value; }
		}
	}

	/// public class name:   SelectCustomerCarOrder
	/// <summary>
	/// �I�𓾈Ӑ�E�d���`�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>note       : �I�𓾈Ӑ�E�d���`�[�N���X</br>
	/// <br>Programer  : 980076�@�Ȓ��@����Y</br>
	/// <br>Date       : 2007.02.19</br>
	/// <br>Update Note:</br>
	/// </remarks>
	[Serializable]
	public class SliderSelectedData
	{
		#region ���Ӑ惁���o��`
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode;

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>���Ӑ�T�u�R�[�h</summary>
		private string _customerSubCode;

		/// <summary>����</summary>
		private string _name;

		/// <summary>���̂Q</summary>
		private string _name2;

		#endregion

		#region �d���`�[�����o��`
		/// <summary>�d���`��</summary>
		/// <remarks>0:�d��,1:����</remarks>
		private Int32 _supplierFormal;

		/// <summary>�d���`�[�ԍ�</summary>
		private Int32 _supplierSlipNo;
		#endregion

		#region ���Ӑ�v���p�e�B��`
		/// public propaty name  :  EnterpriseCode
		/// <summary>��ƃR�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ���i ��</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ���i ��</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustomerSubCode
		/// <summary>���Ӑ�T�u�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�T�u�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ���i ��</br>
		/// </remarks>
		public string CustomerSubCode
		{
			get{return _customerSubCode;}
			set{_customerSubCode = value;}
		}

		/// public propaty name  :  Name
		/// <summary>���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���̃v���p�e�B</br>
		/// <br>Programer        :   ���i ��</br>
		/// </remarks>
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

		/// public propaty name  :  Name2
		/// <summary>���̂Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���̂Q�v���p�e�B</br>
		/// <br>Programer        :   ���i ��</br>
		/// </remarks>
		public string Name2
		{
			get{return _name2;}
			set{_name2 = value;}
		}

		#endregion

		#region �d���`�[�v���p�e�B��`
		/// public propaty name  :  SupplierFormal
		/// <summary>�d���`���v���p�e�B</summary>
		/// <value>0:�d��,1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierFormal
		{
			get { return _supplierFormal; }
			set { _supplierFormal = value; }
		}

		/// public propaty name  :  SupplierSlipNo
		/// <summary>�d���`�[�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierSlipNo
		{
			get { return _supplierSlipNo; }
			set { _supplierSlipNo = value; }
		}
		#endregion

		#region �R���X�g���N�^
		/// <summary>
		/// ���Ӑ�d���`�[�������ʃR���X�g���N�^
		/// </summary>
		public SliderSelectedData()
		{
		}
		#endregion
	}
}
