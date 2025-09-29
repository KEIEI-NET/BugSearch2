using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    # region
    /// <summary>
    /// �ԗ�����\���p�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԗ�����\���p�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2014/09/01</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class CarInfoThreadData
    {
        /// <summary>�ޕ�</summary>
        private Int32 _modelDesignationNo;
        /// <summary>�ԍ�</summary>
        private Int32 _categoryNo;
        /// <summary>���Y�^�O�ԋ敪</summary>
        private Int32 _frameNoKubun;
        /// <summary>�N��</summary>
        private Int32 _firstEntryDate;
        /// <summary>�N���敪</summary>
        private Int32 _firstEntryDateKubun;
        /// <summary>���[�J�[</summary>
        private Int32 _makerCode;
        /// <summary>�Ԏ�R�[�h</summary>
        private Int32 _modelCode;
        /// <summary>�Ԏ�T�u�R�[�h</summary>
        private Int32 _modelSubCode;
        /// <summary>�Ԏ햼</summary>
        private string _modelFullName = string.Empty;
        /// <summary>�^��</summary>
        private string _fullModel = string.Empty;
        /// <summary>���l</summary>
        private string _note = string.Empty;
        /// <summary>�ԑ�ԍ�</summary>
        private string _frameNo = string.Empty;
        /// <summary>��ʌ�</summary>
        private string _pgid = string.Empty;
        /// <summary>�N��(SF)</summary>
        private Int32 _firstEntryDateSF;
        /// <summary>�ԑ�ԍ�(SF)</summary>
        private string _frameNoSF = string.Empty;
        /// <summary>�V���V�[��(SF)</summary>
        private string _chassisNoSF = string.Empty;
        /// <summary>�Ԍ��،^��(SF)</summary>
        private string _carInspectCertModelSF = string.Empty;
        /// <summary>�ޕ�</summary>
        private Int32 _modelDesignationNoSF;
        /// <summary>�ԍ�</summary>
        private Int32 _categoryNoSF;
        /// <summary>���[�J�[</summary>
        private Int32 _makerCodeSF;
        /// <summary>�Ԏ�R�[�h</summary>
        private Int32 _modelCodeSF;
        /// <summary>�Ԏ�T�u�R�[�h</summary>
        private Int32 _modelSubCodeSF;
        /// <summary>�Ԏ햼</summary>
        private string _modelFullNameSF = string.Empty;

        /// public propaty name  :  ModelDesignationNo
        /// <summary>�ޕʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ޕʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  FrameNoKubun
        /// <summary>���Y�^�O�ԋ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y�^�O�ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FrameNoKubun
        {
            get { return _frameNoKubun; }
            set { _frameNoKubun = value; }
        }

        /// public propaty name  :  FirstEntryDate
        /// <summary>�N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
        }

        /// public propaty name  :  FirstEntryDateKubun
        /// <summary>�N���敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FirstEntryDateKubun
        {
            get { return _firstEntryDateKubun; }
            set { _firstEntryDateKubun = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>���[�J�[�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>�Ԏ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>�Ԏ�T�u�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>�Ԏ햼�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ햼�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  Note
        /// <summary>���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>�ԑ�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }

        /// public propaty name  :  Pgid
        /// <summary>��ʌ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ʌ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Pgid
        {
            get { return _pgid; }
            set { _pgid = value; }
        }

        /// public propaty name  :  FirstEntryDate
        /// <summary>�N��(SF)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N��(SF)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FirstEntryDateSF
        {
            get { return _firstEntryDateSF; }
            set { _firstEntryDateSF = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>�ԑ�ԍ�(SF)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ�ԍ�(SF)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrameNoSF
        {
            get { return _frameNoSF; }
            set { _frameNoSF = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>�V���V�[��(SF)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���V�[��(SF)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChassisNoSF
        {
            get { return _chassisNoSF; }
            set { _chassisNoSF = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>�^��(SF)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^��(SF)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarInspectCertModelSF
        {
            get { return _carInspectCertModelSF; }
            set { _carInspectCertModelSF = value; }
        }

        /// public propaty name  :  ModelDesignationNoSF
        /// <summary>�ޕ�(SF)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ޕ�(SF)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelDesignationNoSF
        {
            get { return _modelDesignationNoSF; }
            set { _modelDesignationNoSF = value; }
        }

        /// public propaty name  :  CategoryNoSF
        /// <summary>�ԍ�(SF)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ�(SF)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CategoryNoSF
        {
            get { return _categoryNoSF; }
            set { _categoryNoSF = value; }
        }

        /// public propaty name  :  MakerCodeSF
        /// <summary>���[�J�[(SF)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[(SF)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCodeSF
        {
            get { return _makerCodeSF; }
            set { _makerCodeSF = value; }
        }

        /// public propaty name  :  ModelCodeSF
        /// <summary>�Ԏ�R�[�h(SF)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�R�[�h(SF)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelCodeSF
        {
            get { return _modelCodeSF; }
            set { _modelCodeSF = value; }
        }

        /// public propaty name  :  ModelSubCodeSF
        /// <summary>�Ԏ�T�u�R�[�h(SF)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�T�u�R�[�h(SF)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelSubCodeSF
        {
            get { return _modelSubCodeSF; }
            set { _modelSubCodeSF = value; }
        }

        /// public propaty name  :  ModelFullNameSF
        /// <summary>�Ԏ햼(SF)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ햼(SF)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelFullNameSF
        {
            get { return _modelFullNameSF; }
            set { _modelFullNameSF = value; }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public CarInfoThreadData()
        {
        }
    }
    # endregion

}
