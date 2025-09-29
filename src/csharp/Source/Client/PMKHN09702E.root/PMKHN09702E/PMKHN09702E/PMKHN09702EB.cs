//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g�� �F��
// �� �� ��  2012/10/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AutoAnsItemStOrder
    /// <summary>
    ///                      �����񓚕i�ڐݒ�}�X�^���o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����񓚕i�ڐݒ�}�X�^���o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class AutoAnsItemStOrder
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>00�͑S��</remarks>
        private string _sectionCode = "";

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        /// <remarks>0�͑S���Ӑ�</remarks>
        private Int32 _st_CustomerCode;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        /// <remarks>0�͑S���Ӑ�</remarks>
        private Int32 _ed_CustomerCode;

        /// <summary>�J�n���i�����ރR�[�h</summary>
        private Int32 _st_GoodsMGroup;

        /// <summary>�I�����i�����ރR�[�h</summary>
        private Int32 _ed_GoodsMGroup;

        /// <summary>�J�nBL�O���[�v�R�[�h</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>�I��BL�O���[�v�R�[�h</summary>
        private Int32 _ed_BLGroupCode;

        /// <summary>�J�nBL���i�R�[�h</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>�I��BL���i�R�[�h</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>�J�n���i���[�J�[�R�[�h</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>�I�����i���[�J�[�R�[�h</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
        /// <remarks>����ʃR�[�h</remarks>
        private Int32 _prmSetDtlNo2;

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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>00�͑S��</value>
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

        /// public propaty name  :  St_CustomerCode
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>0�͑S���Ӑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>0�͑S���Ӑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  :  St_GoodsMGroup
        /// <summary>�J�n���i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsMGroup
        {
            get { return _st_GoodsMGroup; }
            set { _st_GoodsMGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsMGroup
        /// <summary>�I�����i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsMGroup
        {
            get { return _ed_GoodsMGroup; }
            set { _ed_GoodsMGroup = value; }
        }

        /// public propaty name  :  St_BLGroupCode
        /// <summary>�J�nBL�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>�I��BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>�J�nBL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>�I��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>�J�n���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>�I�����i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
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
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>AutoAnsItemStOrder�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AutoAnsItemStOrder�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AutoAnsItemStOrder()
        {
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h(00�͑S��)</param>
        /// <param name="st_CustomerCode">�J�n���Ӑ�R�[�h(0�͑S���Ӑ�)</param>
        /// <param name="ed_CustomerCode">�I�����Ӑ�R�[�h(0�͑S���Ӑ�)</param>
        /// <param name="st_SupplierCd">�J�n�d����R�[�h</param>
        /// <param name="ed_SupplierCd">�I���d����R�[�h</param>
        /// <param name="st_GoodsMGroup">�J�n���i�����ރR�[�h</param>
        /// <param name="ed_GoodsMGroup">�I�����i�����ރR�[�h</param>
        /// <param name="st_BLGroupCode">�J�nBL�O���[�v�R�[�h</param>
        /// <param name="ed_BLGroupCode">�I��BL�O���[�v�R�[�h</param>
        /// <param name="st_BLGoodsCode">�J�nBL���i�R�[�h</param>
        /// <param name="ed_BLGoodsCode">�I��BL���i�R�[�h</param>
        /// <param name="st_GoodsMakerCd">�J�n���i���[�J�[�R�[�h</param>
        /// <param name="ed_GoodsMakerCd">�I�����i���[�J�[�R�[�h</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>AutoAnsItemStOrder�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AutoAnsItemStOrder�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AutoAnsItemStOrder(string enterpriseCode, string sectionCode, Int32 st_CustomerCode, Int32 ed_CustomerCode, Int32 st_GoodsMGroup, Int32 ed_GoodsMGroup, Int32 st_BLGroupCode, Int32 ed_BLGroupCode, Int32 st_BLGoodsCode, Int32 ed_BLGoodsCode, Int32 st_GoodsMakerCd, Int32 ed_GoodsMakerCd, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._st_CustomerCode = st_CustomerCode;
            this._ed_CustomerCode = ed_CustomerCode;
            this._st_GoodsMGroup = st_GoodsMGroup;
            this._ed_GoodsMGroup = ed_GoodsMGroup;
            this._st_BLGroupCode = st_BLGroupCode;
            this._ed_BLGroupCode = ed_BLGroupCode;
            this._st_BLGoodsCode = st_BLGoodsCode;
            this._ed_BLGoodsCode = ed_BLGoodsCode;
            this._st_GoodsMakerCd = st_GoodsMakerCd;
            this._ed_GoodsMakerCd = ed_GoodsMakerCd;
            this._enterpriseName = enterpriseName;
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^���o�����N���X��������
        /// </summary>
        /// <returns>AutoAnsItemStOrder�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����AutoAnsItemStOrder�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AutoAnsItemStOrder Clone()
        {
            return new AutoAnsItemStOrder(this._enterpriseCode, this._sectionCode, this._st_CustomerCode, this._ed_CustomerCode,  this._st_GoodsMGroup, this._ed_GoodsMGroup, this._st_BLGroupCode, this._ed_BLGroupCode, this._st_BLGoodsCode, this._ed_BLGoodsCode, this._st_GoodsMakerCd, this._ed_GoodsMakerCd, this._enterpriseName);
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^���o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AutoAnsItemStOrder�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AutoAnsItemStOrder�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(AutoAnsItemStOrder target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.St_CustomerCode == target.St_CustomerCode)
                 && (this.Ed_CustomerCode == target.Ed_CustomerCode)
                 && (this.St_GoodsMGroup == target.St_GoodsMGroup)
                 && (this.Ed_GoodsMGroup == target.Ed_GoodsMGroup)
                 && (this.St_BLGroupCode == target.St_BLGroupCode)
                 && (this.Ed_BLGroupCode == target.Ed_BLGroupCode)
                 && (this.St_BLGoodsCode == target.St_BLGoodsCode)
                 && (this.Ed_BLGoodsCode == target.Ed_BLGoodsCode)
                 && (this.St_GoodsMakerCd == target.St_GoodsMakerCd)
                 && (this.Ed_GoodsMakerCd == target.Ed_GoodsMakerCd)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^���o�����N���X��r����
        /// </summary>
        /// <param name="sCMPrtSettingOrder1">
        ///                    ��r����AutoAnsItemStOrder�N���X�̃C���X�^���X
        /// </param>
        /// <param name="sCMPrtSettingOrder2">��r����AutoAnsItemStOrder�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AutoAnsItemStOrder�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(AutoAnsItemStOrder AutoAnsItemStOrder1, AutoAnsItemStOrder AutoAnsItemStOrder2)
        {
            return ((AutoAnsItemStOrder1.EnterpriseCode == AutoAnsItemStOrder2.EnterpriseCode)
                 && (AutoAnsItemStOrder1.SectionCode == AutoAnsItemStOrder2.SectionCode)
                 && (AutoAnsItemStOrder1.St_CustomerCode == AutoAnsItemStOrder2.St_CustomerCode)
                 && (AutoAnsItemStOrder1.Ed_CustomerCode == AutoAnsItemStOrder2.Ed_CustomerCode)
                 && (AutoAnsItemStOrder1.St_GoodsMGroup == AutoAnsItemStOrder2.St_GoodsMGroup)
                 && (AutoAnsItemStOrder1.Ed_GoodsMGroup == AutoAnsItemStOrder2.Ed_GoodsMGroup)
                 && (AutoAnsItemStOrder1.St_BLGroupCode == AutoAnsItemStOrder2.St_BLGroupCode)
                 && (AutoAnsItemStOrder1.Ed_BLGroupCode == AutoAnsItemStOrder2.Ed_BLGroupCode)
                 && (AutoAnsItemStOrder1.St_BLGoodsCode == AutoAnsItemStOrder2.St_BLGoodsCode)
                 && (AutoAnsItemStOrder1.Ed_BLGoodsCode == AutoAnsItemStOrder2.Ed_BLGoodsCode)
                 && (AutoAnsItemStOrder1.St_GoodsMakerCd == AutoAnsItemStOrder2.St_GoodsMakerCd)
                 && (AutoAnsItemStOrder1.Ed_GoodsMakerCd == AutoAnsItemStOrder2.Ed_GoodsMakerCd)
                 && (AutoAnsItemStOrder1.EnterpriseName == AutoAnsItemStOrder2.EnterpriseName));
        }
        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^���o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AutoAnsItemStOrder�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AutoAnsItemStOrder�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(AutoAnsItemStOrder target)
        {
            ArrayList resList = new ArrayList();
            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( this.SectionCode != target.SectionCode ) resList.Add( "SectionCode" );
            if ( this.St_CustomerCode != target.St_CustomerCode ) resList.Add( "St_CustomerCode" );
            if ( this.Ed_CustomerCode != target.Ed_CustomerCode ) resList.Add( "Ed_CustomerCode" );
            if ( this.St_GoodsMGroup != target.St_GoodsMGroup ) resList.Add( "St_GoodsMGroup" );
            if ( this.Ed_GoodsMGroup != target.Ed_GoodsMGroup ) resList.Add( "Ed_GoodsMGroup" );
            if ( this.St_BLGroupCode != target.St_BLGroupCode ) resList.Add( "St_BLGroupCode" );
            if ( this.Ed_BLGroupCode != target.Ed_BLGroupCode ) resList.Add( "Ed_BLGroupCode" );
            if ( this.St_BLGoodsCode != target.St_BLGoodsCode ) resList.Add( "St_BLGoodsCode" );
            if ( this.Ed_BLGoodsCode != target.Ed_BLGoodsCode ) resList.Add( "Ed_BLGoodsCode" );
            if ( this.St_GoodsMakerCd != target.St_GoodsMakerCd ) resList.Add( "St_GoodsMakerCd" );
            if ( this.Ed_GoodsMakerCd != target.Ed_GoodsMakerCd ) resList.Add( "Ed_GoodsMakerCd" );
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add( "EnterpriseName" );

            return resList;
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^���o�����N���X��r����
        /// </summary>
        /// <param name="sCMPrtSettingOrder1">��r����AutoAnsItemStOrder�N���X�̃C���X�^���X</param>
        /// <param name="sCMPrtSettingOrder2">��r����AutoAnsItemStOrder�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AutoAnsItemStOrder�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(AutoAnsItemStOrder AutoAnsItemStOrder1, AutoAnsItemStOrder AutoAnsItemStOrder2)
        {
            ArrayList resList = new ArrayList();
            if ( AutoAnsItemStOrder1.EnterpriseCode != AutoAnsItemStOrder2.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( AutoAnsItemStOrder1.SectionCode != AutoAnsItemStOrder2.SectionCode ) resList.Add( "SectionCode" );
            if ( AutoAnsItemStOrder1.St_CustomerCode != AutoAnsItemStOrder2.St_CustomerCode ) resList.Add( "St_CustomerCode" );
            if ( AutoAnsItemStOrder1.Ed_CustomerCode != AutoAnsItemStOrder2.Ed_CustomerCode ) resList.Add( "Ed_CustomerCode" );
            if ( AutoAnsItemStOrder1.St_GoodsMGroup != AutoAnsItemStOrder2.St_GoodsMGroup ) resList.Add( "St_GoodsMGroup" );
            if ( AutoAnsItemStOrder1.Ed_GoodsMGroup != AutoAnsItemStOrder2.Ed_GoodsMGroup ) resList.Add( "Ed_GoodsMGroup" );
            if ( AutoAnsItemStOrder1.St_BLGroupCode != AutoAnsItemStOrder2.St_BLGroupCode ) resList.Add( "St_BLGroupCode" );
            if ( AutoAnsItemStOrder1.Ed_BLGroupCode != AutoAnsItemStOrder2.Ed_BLGroupCode ) resList.Add( "Ed_BLGroupCode" );
            if ( AutoAnsItemStOrder1.St_BLGoodsCode != AutoAnsItemStOrder2.St_BLGoodsCode ) resList.Add( "St_BLGoodsCode" );
            if ( AutoAnsItemStOrder1.Ed_BLGoodsCode != AutoAnsItemStOrder2.Ed_BLGoodsCode ) resList.Add( "Ed_BLGoodsCode" );
            if ( AutoAnsItemStOrder1.St_GoodsMakerCd != AutoAnsItemStOrder2.St_GoodsMakerCd ) resList.Add( "St_GoodsMakerCd" );
            if ( AutoAnsItemStOrder1.Ed_GoodsMakerCd != AutoAnsItemStOrder2.Ed_GoodsMakerCd ) resList.Add( "Ed_GoodsMakerCd" );
            if ( AutoAnsItemStOrder1.EnterpriseName != AutoAnsItemStOrder2.EnterpriseName ) resList.Add( "EnterpriseName" );

            return resList;
        }
    }
}
