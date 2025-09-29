//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �t���E�����E�c�l�e�L�X�g�o��
// �v���O�����T�v   : �t���E�����E�c�l�e�L�X�g�o�͂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �t���E�����E�c�l�e�L�X�g�o�̓N���X���������N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t���E�����E�c�l�e�L�X�g�o�͌��������N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class PostcardEnvelopeDMTextCndtn
    {
        #region �� Public Const

        // �o�͋敪 --------------------------------------------------------------------
        /// <summary>�S��</summary>
        public const string ct_OutShipDiv_All = "�S��";
        /// <summary>�����L��</summary>
        public const string ct_OutShipDiv_Claim = "�����L��";
        /// <summary>�`�[�L��</summary>
        public const string ct_OutShipDiv_Slip = "�`�[�L��";

        //�g�p�}�X�^ --------------------------------------------------------------------
        /// <summary>���Ӑ�}�X�^</summary>
        public const string ct_UseMasterDiv_Customer = "���Ӑ�}�X�^";
        /// <summary>�d����}�X�^</summary>
        public const string ct_UseMasterDiv_Supplier = "�d����}�X�^";
        /// <summary>���Ѓ}�X�^</summary>
        public const string ct_UseMasterDiv_Company = "���Ѓ}�X�^";
        /// <summary>���_�}�X�^</summary>
        public const string ct_UseMasterDiv_SecInfo = "���_�}�X�^";
        #endregion

        #region �� Private Member
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>���_�I�v�V���������敪</summary>
        private bool _isOptSection;

        /// <summary>�{�Ћ@�\�v���p�e�B</summary>
        private bool _isMainOfficeFunc;

        /// <summary>���_�R�[�h�J�n</summary>
        private string _st_SectionCode;

        /// <summary>���_�R�[�h�I��</summary>
        private string _ed_SectionCode;

        /// <summary>�g�p�}�X�^</summary>
        private int _useMast;

        /// <summary>�o�͋敪</summary>
        private int _outShipDiv;

        /// <summary>����</summary>
        private DateTime _totalDay;

        /// <summary>�Ώۓ��t�J�n��</summary>
        private DateTime _st_AddUpDay;

        /// <summary>�Ώۓ��t�I����</summary>
        private DateTime _ed_AddUpDay;

        /// <summary>���Ӑ�R�[�h�J�n</summary>
        private Int32 _st_CustomerCode;

        /// <summary>���Ӑ�R�[�h�I��</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>�d����R�[�h�J�n</summary>
        private Int32 _st_SupplierCode;

        /// <summary>�d����R�[�h�I��</summary>
        private Int32 _ed_SupplierCode;

        #endregion �� Private Member

        #region �� Public Property
        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e �B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ��ƃR�[�h�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  IsOptSection
        /// <summary>���_�I�v�V���������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���_�I�v�V���������敪�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>�{�Ћ@�\�v���p�e�B�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �{�Ћ@�\�v���p�e�B�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// public propaty name  :  St_SectionCode
        /// <summary>���_�R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���_�R�[�h�J�n�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public string St_SectionCode
        {
            get { return _st_SectionCode; }
            set { _st_SectionCode = value; }
        }


        /// public propaty name  :  Ed_SectionCode
        /// <summary>���_�R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���_�R�[�h�I���v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public string Ed_SectionCode
        {
            get { return _ed_SectionCode; }
            set { _ed_SectionCode = value; }
        }

        /// public propaty name  :  UseMast
        /// <summary>�g�p�}�X�^</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �g�p�}�X�^�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public int UseMast
        {
            get { return _useMast; }
            set { _useMast = value; }
        }

        /// public propaty name  :  OutShipDiv
        /// <summary>�o�͋敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �o�͋敪�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public int OutShipDiv
        {
            get { return _outShipDiv; }
            set { _outShipDiv = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �����v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public DateTime TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  St_AddUpDay
        /// <summary>�Ώۓ��t�J�n��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �Ώۓ��t�J�n���v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public DateTime St_AddUpDay
        {
            get { return _st_AddUpDay; }
            set { _st_AddUpDay = value; }
        }

        /// public propaty name  :  Ed_AddUpDay
        /// <summary>�Ώۓ��t�I����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �Ώۓ��t�I�����v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public DateTime Ed_AddUpDay
        {
            get { return _ed_AddUpDay; }
            set { _ed_AddUpDay = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>���Ӑ�R�[�h�J�n</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���Ӑ�R�[�h�J�n�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  : Ed_CustomerCode
        /// <summary>���Ӑ�R�[�h�I��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���Ӑ�R�[�h�I���v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  : St_SupplierCode
        /// <summary>�d����R�[�h�J�n</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �d����R�[�h�J�n�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public Int32 St_SupplierCode
        {
            get { return _st_SupplierCode; }
            set { _st_SupplierCode = value; }
        }

        /// public propaty name  : Ed_SupplierCode
        /// <summary>�d����R�[�h�I��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �d����R�[�h�I���v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public Int32 Ed_SupplierCode
        {
            get { return _ed_SupplierCode; }
            set { _ed_SupplierCode = value; }
        }

        #endregion �� Private Property

        #region �� Public Enum
        #region �� �o�͋敪�񋓑�
        /// <summary> �o�͋敪�񋓑� </summary>
        public enum OutShipDivState
        {
            /// <summary>�S��</summary>
            All = 0,
            /// <summary>�����L��</summary>
            Claim = 1,
            /// <summary>�`�[�L��</summary>
            Slip = 2,
        }
        #endregion ��

        #region �� �g�p�}�X�^�񋓑�
        /// <summary> �g�p�}�X�^�񋓑� </summary>
        public enum UseMastDivState
        {
            /// <summary>���Ӑ�}�X�^</summary>
            Customer = 0,
            /// <summary>�d����}�X�^</summary>
            Supplier = 1,
            /// <summary>���Ѓ}�X�^</summary>
            Company = 2,
            /// <summary>���_�}�X�^</summary>
            SecInfo = 3,
        }
        #endregion ��
        #endregion �� Public Enum
    }
}
