//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����ꊇ�C��
// �v���O�����T�v   : �����ꊇ�C�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/04/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesRateSearchParam
    /// <summary>
    ///                      �����ꊇ�C�����o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �|���}�X�^�ꊇ�o�^�C�����o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/01/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SalesRateSearchParam
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�S�Ўw���null</remarks>
        private String _sectionCode;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        /// <remarks>(�z��) null�̏ꍇ�͑S��</remarks>
        private Int32[] _custRateGrpCode;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>���O�C�����_�R�[�h</summary>
        /// <remarks></remarks>
        private String[] _prmSectionCode;

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
        /// <value>�S�Ўw���null</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>(�z��) null�̏ꍇ�͑S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
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

        /// public propaty name  :  SectionCode
        /// <summary>���O�C�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String[] PrmSectionCode
        {
            get { return _prmSectionCode; }
            set { _prmSectionCode = value; }
        }

        /// <summary>
        /// �����ꊇ�C�����o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>SalesRateSearchParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRateSearchParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesRateSearchParam()
        {
        }

        /// <summary>
        /// �����ꊇ�C���C�����o�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h(�S�Ўw���null)</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h((�z��) null�̏ꍇ�͑S��)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="prmSectionCode">���O�C�����_�R�[�h</param>
        /// <returns>SalesRateSearchParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRateSearchParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesRateSearchParam(string enterpriseCode, String sectionCode, Int32 bLGoodsCode, Int32 goodsMakerCd, Int32[] custRateGrpCode, string enterpriseName, String[] prmSectionCode)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsMakerCd = goodsMakerCd;
            this._custRateGrpCode = custRateGrpCode;
            this._enterpriseName = enterpriseName;
            this._prmSectionCode = prmSectionCode;
        }

        /// <summary>
        /// �����ꊇ�C�����o�����N���X��������
        /// </summary>
        /// <returns>SalesRateSearchParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesRateSearchParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesRateSearchParam Clone()
        {
            return new SalesRateSearchParam(this._enterpriseCode, this._sectionCode, this._bLGoodsCode, this._goodsMakerCd, this._custRateGrpCode, this._enterpriseName, this._prmSectionCode);
        }

        /// <summary>
        /// �����ꊇ�C�����o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesRateSearchParam�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRateSearchParam�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SalesRateSearchParam target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.PrmSectionCode == target.PrmSectionCode));
        }

        /// <summary>
        /// �����ꊇ�C�����o�����N���X��r����
        /// </summary>
        /// <param name="rateSearchParam1">
        ///                    ��r����SalesRateSearchParam�N���X�̃C���X�^���X
        /// </param>
        /// <param name="rateSearchParam2">��r����SalesRateSearchParam�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRateSearchParam�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SalesRateSearchParam rateSearchParam1, SalesRateSearchParam rateSearchParam2)
        {
            return ((rateSearchParam1.EnterpriseCode == rateSearchParam2.EnterpriseCode)
                 && (rateSearchParam1.SectionCode == rateSearchParam2.SectionCode)
                 && (rateSearchParam1.BLGoodsCode == rateSearchParam2.BLGoodsCode)
                 && (rateSearchParam1.GoodsMakerCd == rateSearchParam2.GoodsMakerCd)
                 && (rateSearchParam1.CustRateGrpCode == rateSearchParam2.CustRateGrpCode)
                 && (rateSearchParam1.EnterpriseName == rateSearchParam2.EnterpriseName)
                 && (rateSearchParam1.PrmSectionCode == rateSearchParam2.PrmSectionCode));
        }
        /// <summary>
        ///  �����ꊇ�C�����o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesRateSearchParam�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRateSearchParam�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SalesRateSearchParam target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.PrmSectionCode != target.PrmSectionCode) resList.Add("PrmSectionCode");

            return resList;
        }

        /// <summary>
        /// �����ꊇ�C�����o�����N���X��r����
        /// </summary>
        /// <param name="rateSearchParam1">��r����SalesRateSearchParam�N���X�̃C���X�^���X</param>
        /// <param name="rateSearchParam2">��r����SalesRateSearchParam�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRateSearchParam�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SalesRateSearchParam rateSearchParam1, SalesRateSearchParam rateSearchParam2)
        {
            ArrayList resList = new ArrayList();
            if (rateSearchParam1.EnterpriseCode != rateSearchParam2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (rateSearchParam1.SectionCode != rateSearchParam2.SectionCode) resList.Add("SectionCode");
            if (rateSearchParam1.BLGoodsCode != rateSearchParam2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (rateSearchParam1.GoodsMakerCd != rateSearchParam2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (rateSearchParam1.CustRateGrpCode != rateSearchParam2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (rateSearchParam1.EnterpriseName != rateSearchParam2.EnterpriseName) resList.Add("EnterpriseName");
            if (rateSearchParam1.PrmSectionCode != rateSearchParam2.PrmSectionCode) resList.Add("PrmSectionCode");

            return resList;
        }
    }
}
