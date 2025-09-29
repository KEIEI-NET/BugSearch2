//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �����Ԍ��ԗ��ꗗ�\ �f�[�^�N���X
//                  :   PMSYA02101E.DLL
// Name Space       :   Broadleaf.Application.UIData
// Programmer       :   �L�Q
// Date             :   2010.04.21
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using Broadleaf.Library.Globarization;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MonthCarInspectListPara
    /// <summary>
    ///                      �����Ԍ��ԗ��ꗗ�\�f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����Ԍ��ԗ��ꗗ�\�f�[�^�N���X</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/04/21</br>
    /// <br>Genarated Date   :   2010/04/21  (CSharp File Generated Date)</br>
    /// </remarks>
    public class MonthCarInspectListPara
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�I�v�V�����敪</summary>
        private bool _isOptSection = false;

        /// <summary>�S���_�I���敪</summary>
        private bool _isSelectAllSection = false;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private string _stCustomerCode;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private string _edCustomerCode;

        /// <summary>���_�R�[�h</summary>
        private string[] _sectionCodes;

        /// <summary>�Ԍ�������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inspectMaturityDate;

        /// <summary>�J�n�Ǘ��ԍ�</summary>
        private string _stCarMngCode;

        /// <summary>�I���Ǘ��ԍ�</summary>
        private string _edCarMngCode;

        /// <summary>���s</summary>
        /// <remarks>0:�ׂ��ł� 1:1�s��s</remarks>
        private ChangeRowDivState _changeRowDiv;

        /// <summary>����</summary>
        /// <remarks>0:���Ȃ� 1:���Ӑ�</remarks>
        private ChangePageDivState _changePageDiv;

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

        /// public propaty name  :  StCustomerCode
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StCustomerCode
        {
            get { return _stCustomerCode; }
            set { _stCustomerCode = value; }
        }

        /// public propaty name  :  EdCustomerCode
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdCustomerCode
        {
            get { return _edCustomerCode; }
            set { _edCustomerCode = value; }
        }

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  InspectMaturityDate
        /// <summary>�Ԍ��������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԍ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InspectMaturityDate
        {
            get { return _inspectMaturityDate; }
            set { _inspectMaturityDate = value; }
        }

        /// public propaty name  :  InspectMaturityDateJpFormal
        /// <summary>�Ԍ������� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԍ������� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InspectMaturityDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _inspectMaturityDate); }
            set { }
        }

        /// public propaty name  :  InspectMaturityDateJpInFormal
        /// <summary>�Ԍ������� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԍ������� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InspectMaturityDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _inspectMaturityDate); }
            set { }
        }

        /// public propaty name  :  InspectMaturityDateAdFormal
        /// <summary>�Ԍ������� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԍ������� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InspectMaturityDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _inspectMaturityDate); }
            set { }
        }

        /// public propaty name  :  InspectMaturityDateAdInFormal
        /// <summary>�Ԍ������� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԍ������� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InspectMaturityDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _inspectMaturityDate); }
            set { }
        }

        /// public propaty name  :  IsOptSection
        /// <summary>���_�I�v�V�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�I�v�V�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }

        /// public propaty name  :  IsSelectAllSection
        /// <summary>�S���_�I���敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���_�I���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }


        /// public propaty name  :  StCarMngCode
        /// <summary>�J�n�Ǘ��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StCarMngCode
        {
            get { return _stCarMngCode; }
            set { _stCarMngCode = value; }
        }

        /// public propaty name  :  EdCarMngCode
        /// <summary>�I���Ǘ��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdCarMngCode
        {
            get { return _edCarMngCode; }
            set { _edCarMngCode = value; }
        }

        /// public propaty name  :  ChangeRowDiv
        /// <summary>���s</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ChangeRowDivState ChangeRowDiv
        {
            get { return _changeRowDiv; }
            set { _changeRowDiv = value; }
        }

        /// public propaty name  :  ChangePageDiv
        /// <summary>����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ChangePageDivState ChangePageDiv
        {
            get { return _changePageDiv; }
            set { _changePageDiv = value; }
        }

        /// <summary>
        /// ���Ł@�񋓌^
        /// </summary>
        public enum ChangePageDivState
        {
            /// <summary>�ׂ��ł�</summary>
            NotBlankLine = 0,
            /// <summary>1�s��s</summary>
            BlankLine = 1,
        }

        /// <summary>
        /// ���s�@�񋓌^
        /// </summary>
        public enum ChangeRowDivState
        {
            /// <summary>���Ȃ�</summary>
            No = 0,
            /// <summary>���Ӑ�</summary>
            Customer = 1,
        }

        /// <summary>�Ȃ�</summary>
        public const string ct_comm_No = "�Ȃ�";
        /// <summary>���Ӑ�</summary>
        public const string ct_comm_Customer = "���Ӑ�";
        /// <summary>�ׂ��ł�</summary>
        public const string ct_comm_NotBlankLine = "�ׂ��ł�";
        /// <summary>1�s��s</summary>
        public const string ct_comm_BlankLine = "1�s��s";

        /// <summary>
        /// ���Ł@���̎擾
        /// </summary>
        public string ChangePageDivName
        {
            get
            {
                switch (this._changePageDiv)
                {
                    case ChangePageDivState.NotBlankLine:
                        return ct_comm_NotBlankLine;
                    case ChangePageDivState.BlankLine:
                        return ct_comm_BlankLine;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// ���s�@���̎擾
        /// </summary>
        public string ChangeRowDivName
        {
            get
            {
                switch (this._changeRowDiv)
                {
                    case ChangeRowDivState.No:
                        return ct_comm_No;
                    case ChangeRowDivState.Customer:
                        return ct_comm_Customer;
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
