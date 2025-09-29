using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   OprtnHisLogSrchWork
	/// <summary>
	///                      ���엚�����O�\�����o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���엚�����O�\�����o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   ���V�� K2016/10/28</br>
    /// <br>�Ǘ��ԍ�         :   11202046-00</br>
    /// <br>                 :   �_�P�Y�Ƈ� �������������̒ǉ�</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class OprtnHisLogSrchWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�J�n���O�f�[�^�쐬����</summary>
		private DateTime _st_LogDataCreateDateTime;

		/// <summary>�I�����O�f�[�^�쐬����</summary>
        private DateTime _ed_LogDataCreateDateTime;

		/// <summary>���O�C�����_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _loginSectionCd;

		/// <summary>���O�f�[�^��ʋ敪�R�[�h</summary>
		/// <remarks>���w��(�i�荞�܂Ȃ�)�̏ꍇ�́u-1�v</remarks>
		private Int32 _logDataKindCd;

		/// <summary>���O�f�[�^�[����</summary>
		private string _logDataMachineName = "";

		/// <summary>���O�f�[�^�S���҃R�[�h</summary>
		private string _logDataAgentCd = "";

		/// <summary>���O�f�[�^�ΏۃA�Z���u��ID</summary>
		/// <remarks>���O���������񂾃A�Z���u��ID</remarks>
		private string _logDataObjAssemblyID = "";

		/// <summary>���O�f�[�^�I�y���[�V�����R�[�h</summary>
		/// <remarks>������e�R�[�h(0:�N��,1:���O�C��,2:�f�[�^�Ǎ�,3:�f�[�^�}��,4:�f�[�^�X�V,5:�f�[�^�_���폜,6:�f�[�^�폜,7:���,8:�e�L�X�g�o��,9:�ʐM,10:�ďo,11:���M,12:��M,13:�^�C���A�E�g,14:�I��)</remarks>
		private Int32 _logDataOperationCd;

        //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� ----->>>>>
        /// <summary>���������t���O</summary>
        private bool _timeSearchFlag = false;

        /// <summary>�J�n���������i���j</summary>
        private Int32 _searchHourSt;

        /// <summary>�J�n���������i���j</summary>
        private Int32 _searchMinuteSt;

        /// <summary>�J�n���������i�b�j</summary>
        private Int32 _searchSecondSt;

        /// <summary>�I�����������i���j</summary>
        private Int32 _searchHourEd;

        /// <summary>�I�����������i���j</summary>
        private Int32 _searchMinuteEd;

        /// <summary>�I�����������i�b�j</summary>
        private Int32 _searchSecondEd;

        /// <summary>���������t���O(00:00:00�Ɍׂ��Ă���)</summary>
        private bool _timeSearchFlag2 = false;

        //----- ADD ���O 2021/12/15 �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή� ----->>>>>
        /// <summary>���������t���O(24���Ԃ𒴂���)</summary>
        private bool _timeSearchFlagOverDay = false;
        //----- ADD ���O 2021/12/15 �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή� -----<<<<<

        /// <summary>�J�n���������i���j</summary>
        private Int32 _searchHourSt2;

        /// <summary>�J�n���������i���j</summary>
        private Int32 _searchMinuteSt2;

        /// <summary>�J�n���������i�b�j</summary>
        private Int32 _searchSecondSt2;

        /// <summary>�I�����������i���j</summary>
        private Int32 _searchHourEd2;

        /// <summary>�I�����������i���j</summary>
        private Int32 _searchMinuteEd2;

        /// <summary>�I�����������i�b�j</summary>
        private Int32 _searchSecondEd2;
        //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� -----<<<<<


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

		/// public propaty name  :  St_LogDataCreateDateTime
		/// <summary>�J�n���O�f�[�^�쐬�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���O�f�[�^�쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime St_LogDataCreateDateTime
		{
			get{return _st_LogDataCreateDateTime;}
			set{_st_LogDataCreateDateTime = value;}
		}

		/// public propaty name  :  Ed_LogDataCreateDateTime
		/// <summary>�I�����O�f�[�^�쐬�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����O�f�[�^�쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime Ed_LogDataCreateDateTime
		{
			get{return _ed_LogDataCreateDateTime;}
			set{_ed_LogDataCreateDateTime = value;}
		}

		/// public propaty name  :  LoginSectionCd
		/// <summary>���O�C�����_�R�[�h�v���p�e�B</summary>
		/// <value>(�z��)�@�S�Ўw���{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���O�C�����_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] LoginSectionCd
		{
			get{return _loginSectionCd;}
			set{_loginSectionCd = value;}
		}

		/// public propaty name  :  LogDataKindCd
		/// <summary>���O�f�[�^��ʋ敪�R�[�h�v���p�e�B</summary>
		/// <value>���w��(�i�荞�܂Ȃ�)�̏ꍇ�́u-1�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���O�f�[�^��ʋ敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogDataKindCd
		{
			get{return _logDataKindCd;}
			set{_logDataKindCd = value;}
		}

		/// public propaty name  :  LogDataMachineName
		/// <summary>���O�f�[�^�[�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���O�f�[�^�[�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LogDataMachineName
		{
			get{return _logDataMachineName;}
			set{_logDataMachineName = value;}
		}

		/// public propaty name  :  LogDataAgentCd
		/// <summary>���O�f�[�^�S���҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���O�f�[�^�S���҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LogDataAgentCd
		{
			get{return _logDataAgentCd;}
			set{_logDataAgentCd = value;}
		}

		/// public propaty name  :  LogDataObjAssemblyID
		/// <summary>���O�f�[�^�ΏۃA�Z���u��ID�v���p�e�B</summary>
		/// <value>���O���������񂾃A�Z���u��ID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���O�f�[�^�ΏۃA�Z���u��ID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LogDataObjAssemblyID
		{
			get{return _logDataObjAssemblyID;}
			set{_logDataObjAssemblyID = value;}
		}

		/// public propaty name  :  LogDataOperationCd
		/// <summary>���O�f�[�^�I�y���[�V�����R�[�h�v���p�e�B</summary>
		/// <value>������e�R�[�h(0:�N��,1:���O�C��,2:�f�[�^�Ǎ�,3:�f�[�^�}��,4:�f�[�^�X�V,5:�f�[�^�_���폜,6:�f�[�^�폜,7:���,8:�e�L�X�g�o��,9:�ʐM,10:�ďo,11:���M,12:��M,13:�^�C���A�E�g,14:�I��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���O�f�[�^�I�y���[�V�����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogDataOperationCd
		{
			get{return _logDataOperationCd;}
			set{_logDataOperationCd = value;}
		}

        //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� --------------->>>>>
        /// public propaty name  :  TimeSearchFlag
        /// <summary>���������t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool TimeSearchFlag
        {
            get { return _timeSearchFlag; }
            set { _timeSearchFlag = value; }
        }

        /// public propaty name  :  SearchHourSt
        /// <summary>�J�n���������i���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���������i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchHourSt
        {
            get { return _searchHourSt; }
            set { _searchHourSt = value; }
        }

        /// public propaty name  :  SearchMinuteSt
        /// <summary>�J�n���������i���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���������i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchMinuteSt
        {
            get { return _searchMinuteSt; }
            set { _searchMinuteSt = value; }
        }

        /// public propaty name  :  SearchSecondSt
        /// <summary>�J�n���������i�b�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���������i�b�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchSecondSt
        {
            get { return _searchSecondSt; }
            set { _searchSecondSt = value; }
        }

        /// public propaty name  :  SearchHourEd
        /// <summary>�I�����������i���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����������i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchHourEd
        {
            get { return _searchHourEd; }
            set { _searchHourEd = value; }
        }

        /// public propaty name  :  SearchMinuteEd
        /// <summary>�I�����������i���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����������i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchMinuteEd
        {
            get { return _searchMinuteEd; }
            set { _searchMinuteEd = value; }
        }

        /// public propaty name  :  SearchSecondEd
        /// <summary>�I�����������i�b�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����������i�b�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchSecondEd
        {
            get { return _searchSecondEd; }
            set { _searchSecondEd = value; }
        }

        /// public propaty name  :  TimeSearchFlag2
        /// <summary>���������t���O(00:00:00�Ɍׂ��Ă���)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������t���O(00:00:00�Ɍׂ��Ă���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool TimeSearchFlag2
        {
            get { return _timeSearchFlag2; }
            set { _timeSearchFlag2 = value; }
        }

        //----- ADD ���O 2021/12/15 �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή� ----->>>>>
        /// public propaty name  :  TimeSearchFlagOverDay
        /// <summary>���������t���O(24���Ԃ𒴂���)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������t���O(24���Ԃ𒴂���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool TimeSearchFlagOverDay
        {
            get { return _timeSearchFlagOverDay; }
            set { _timeSearchFlagOverDay = value; }
        }
        //----- ADD ���O 2021/12/15 �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή� -----<<<<<

        /// public propaty name  :  SearchHourSt
        /// <summary>�J�n���������i���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���������i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchHourSt2
        {
            get { return _searchHourSt2; }
            set { _searchHourSt2 = value; }
        }

        /// public propaty name  :  SearchMinuteSt
        /// <summary>�J�n���������i���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���������i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchMinuteSt2
        {
            get { return _searchMinuteSt2; }
            set { _searchMinuteSt2 = value; }
        }

        /// public propaty name  :  SearchSecondSt2
        /// <summary>�J�n���������i�b�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���������i�b�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchSecondSt2
        {
            get { return _searchSecondSt2; }
            set { _searchSecondSt2 = value; }
        }

        /// public propaty name  :  SearchHourEd2
        /// <summary>�I�����������i���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����������i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchHourEd2
        {
            get { return _searchHourEd2; }
            set { _searchHourEd2 = value; }
        }

        /// public propaty name  :  SearchMinuteEd2
        /// <summary>�I�����������i���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����������i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchMinuteEd2
        {
            get { return _searchMinuteEd2; }
            set { _searchMinuteEd2 = value; }
        }

        /// public propaty name  :  SearchSecondEd2
        /// <summary>�I�����������i�b�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����������i�b�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchSecondEd2
        {
            get { return _searchSecondEd2; }
            set { _searchSecondEd2 = value; }
        }
        //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� ---------------<<<<<

		/// <summary>
		/// ���엚�����O�\�����o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>OprtnHisLogSrchWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OprtnHisLogSrchWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public OprtnHisLogSrchWork()
		{
		}

	}
}
