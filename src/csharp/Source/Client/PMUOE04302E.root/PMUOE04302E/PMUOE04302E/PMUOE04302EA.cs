using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   OprationLogOrderWorkWork
	/// <summary>
	///                      ���엚�����O���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���엚�����O���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/08  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class OprationLogOrderParam
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���O�C�����_�R�[�h</summary>
		private string[] _sectionCodes;

		/// <summary>���O�f�[�^�[����</summary>
		private string _logDataMachineName = "";

		/// <summary>������R�[�h</summary>
		/// <remarks>���O�ɏ������ތ����ƂȂ����N���XID�@(UOE������R�[�h)</remarks>
		private string _logDataObjClassID = "";

		/// <summary>�J�n���O�f�[�^�쐬����</summary>
		private DateTime _st_LogDataCreateDateTime;

		/// <summary>�I�����O�f�[�^�쐬����</summary>
		private DateTime _ed_LogDataCreateDateTime;

		/// <summary>���O�f�[�^��ʋ敪�R�[�h</summary>
		/// <remarks>0:�L�^,1:�G���[,9:�V�X�e��,10:UOE(DSP) 11:UOE(�ʐM)</remarks>
		private Int32 _logDataKindCd;


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

		/// public propaty name  :  SectionCodes
		/// <summary>���O�C�����_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���O�C�����_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
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

		/// public propaty name  :  LogDataObjClassID
		/// <summary>������R�[�h�v���p�e�B</summary>
		/// <value>���O�ɏ������ތ����ƂȂ����N���XID�@(UOE������R�[�h)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LogDataObjClassID
		{
			get{return _logDataObjClassID;}
			set{_logDataObjClassID = value;}
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

		/// public propaty name  :  LogDataKindCd
		/// <summary>���O�f�[�^��ʋ敪�R�[�h�v���p�e�B</summary>
		/// <value>0:�L�^,1:�G���[,9:�V�X�e��,10:UOE(DSP) 11:UOE(�ʐM)</value>
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


		/// <summary>
		/// ���엚�����O���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>OprationLogOrderWorkWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OprationLogOrderWorkWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public OprationLogOrderParam()
		{
		}

        /// <summary>
        /// �o�ו��i�\�������N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
        /// <param name="stAddUpYearMonth">�v��N��(�J�n)(YYYYMM)</param>
        /// <param name="edAddUpYearMonth">�v��N��(�I��)(YYYYMM)</param>
        /// <returns>ShipmentPartsDspParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OprationLogOrderParam(string enterpriseCode, string[] sectionCodes, string logDataMachineName, string logDataObjClassID, DateTime st_LogDataCreateDateTime
            , DateTime ed_LogDataCreateDateTime, Int32 logDataKindCd)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCodes = sectionCodes;
            this._logDataMachineName = logDataMachineName;
            this._logDataObjClassID = logDataObjClassID;
            this._st_LogDataCreateDateTime = st_LogDataCreateDateTime;
            this._ed_LogDataCreateDateTime = ed_LogDataCreateDateTime;
            this.LogDataKindCd = LogDataKindCd;
        }

        /// <summary>
        /// �o�ו��i�\�������N���X��������
        /// </summary>
        /// <returns>ShipmentPartsDspParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ShipmentPartsDspParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OprationLogOrderParam Clone()
        {
            return new OprationLogOrderParam(this._enterpriseCode, this._sectionCodes, this._logDataMachineName, this._logDataObjClassID, this._st_LogDataCreateDateTime,
                this._ed_LogDataCreateDateTime, this.LogDataKindCd);
        }
    }
}