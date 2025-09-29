using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ShipmentPartsDspParam
    /// <summary>
    ///                      �o�ו��i�\�������N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �o�ו��i�\�������w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/4/24</br>
    /// </remarks>
    public class ShipmentPartsDspParam
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _sectionCode = "";

        /// <summary>�Ώ۔N��(�J�n)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _stAddUpYearMonth;

        /// <summary>�Ώ۔N��(�I��)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _edAddUpYearMonth;

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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  AddUpSecCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  StAddUpYearMonth
        /// <summary>�v��N��(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StAddUpYearMonth
        {
            get { return _stAddUpYearMonth; }
            set { _stAddUpYearMonth = value; }
        }

        /// public propaty name  :  EdAddUpYearMonth
        /// <summary>�v��N��(�I��)�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N��(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EdAddUpYearMonth
        {
            get { return _edAddUpYearMonth; }
            set { _edAddUpYearMonth = value; }
        }

        /// <summary>
        /// �o�ו��i�\�������N���X�R���X�g���N�^
        /// </summary>
        /// <returns>ShipmentPartsDspParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ShipmentPartsDspParam()
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
        public ShipmentPartsDspParam(string enterpriseCode,string sectionCode, DateTime stAddUpYearMonth, DateTime edAddUpYearMonth)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._stAddUpYearMonth = stAddUpYearMonth;
            this._edAddUpYearMonth = edAddUpYearMonth;
        }

        /// <summary>
        /// �o�ו��i�\�������N���X��������
        /// </summary>
        /// <returns>ShipmentPartsDspParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ShipmentPartsDspParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ShipmentPartsDspParam Clone()
        {
            return new ShipmentPartsDspParam(this._enterpriseCode, this._sectionCode, this._stAddUpYearMonth, this._edAddUpYearMonth);
        }
    }
}
