using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   IsolIslandPrcSet
    /// <summary>
    ///                      �������i�}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �������i�}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class IsolIslandPrcSet 
    {

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _makerCode;

        /// <summary>���[�J�[����</summary>
        private string _makerShortName = "";

        /// <summary>������z</summary>
        private Double _upperLimitPrice;

        /// <summary>�[�������P��</summary>
        private Double _fractionProcUnit;

        /// <summary>�[�������敪</summary>
        private Int32 _fractionProcCd;

        /// <summary>UP��</summary>
        private Double _upRate;


        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
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
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  MakerShortName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
        }

        /// public propaty name  :  UpperLimitPrice
        /// <summary>������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double UpperLimitPrice
        {
            get { return _upperLimitPrice; }
            set { _upperLimitPrice = value; }
        }

        /// public propaty name  :  FractionProcUnit
        /// <summary>�[�������P�ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������P�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double FractionProcUnit
        {
            get { return _fractionProcUnit; }
            set { _fractionProcUnit = value; }
        }

        /// public propaty name  :  FractionProcCd
        /// <summary>�[�������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        /// public propaty name  :  UpRate
        /// <summary>UP���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UP���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double UpRate
        {
            get { return _upRate; }
            set { _upRate = value; }
        }

        /// <summary>
        /// �������i�i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public IsolIslandPrcSet Clone()
        {
            return new IsolIslandPrcSet(this._sectionCode, this._sectionGuideSnm, this._makerCode, this._makerShortName, this._upperLimitPrice, this._fractionProcUnit, this._fractionProcCd, this._upRate);

        }

        /// <summary>
		/// �������i�i����j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>EmployeeSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public IsolIslandPrcSet()
		{
		}
        
        /// <summary>
        /// �������i�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="SectionCode"></param>
        /// <param name="SectionGuideSnm"></param>
        /// <param name="MakerCode"></param>
        /// <param name="MakerShortName"></param>
        /// <param name="UpperLimitPrice"></param>
        /// <param name="FractionProcUnit"></param>
        /// <param name="FractionProcCd"></param>
        /// <param name="UpRate"></param>
        public IsolIslandPrcSet(string SectionCode, string SectionGuideSnm, Int32 MakerCode, string MakerShortName, Double UpperLimitPrice, Double FractionProcUnit, Int32 FractionProcCd, Double UpRate)
        {

            this._sectionCode = SectionCode;
            this._sectionGuideSnm = SectionGuideSnm;
            this._makerCode = MakerCode;
            this._makerShortName = MakerShortName;
            this._upperLimitPrice = UpperLimitPrice;
            this._fractionProcUnit = FractionProcUnit;
            this._fractionProcCd = FractionProcCd;
            this._upRate = UpRate;

        }
    }
}
