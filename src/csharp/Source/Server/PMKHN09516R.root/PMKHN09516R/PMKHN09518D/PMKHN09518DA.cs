//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �s�a�n���o��
// �v���O�����T�v   : �s�a�n���o��
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270029-00  �쐬�S�� : ������
// �� �� �� : 2016/05/20   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TBODataExportCond
    /// <summary>
    ///                      �s�a�n���o�͏������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �s�a�n���o�͏������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2016/05/20</br>
    /// <br>Genarated Date   :   2016/05/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TBODataExportCond
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���i�J�e�S��</summary>
        /// <remarks>1:�^�C�� 2:�o�b�e���[ 3:�I�C��</remarks>
        private int _categoryID;

        /// <summary>�i��</summary>
        private string _goodsNo = "";

        /// <summary>���[�J�[�R�[�h(Start)</summary>
        private Int32 _goodsMakerCd_ST;

        /// <summary>���[�J�[�R�[�h(End)</summary>
        private Int32 _goodsMakerCd_ED;

        /// <summary>���i�K�p��</summary>
        private Int32 _priceStartDate;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCodeRF = "";

        /// <summary>���i�����ރR�[�h</summary>
        private ArrayList _goodsMGroup;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

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

        /// public propaty name  :  CategoryID
        /// <summary>���i�J�e�S���v���p�e�B</summary>
        /// <value>1:�^�C�� 2:�o�b�e���[ 3:�I�C��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�e�S���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd_ST
        /// <summary>���[�J�[�R�[�h(Start)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h(Start)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd_ST
        {
            get { return _goodsMakerCd_ST; }
            set { _goodsMakerCd_ST = value; }
        }

        /// public propaty name  :  GoodsMakerCd_ED
        /// <summary>���[�J�[�R�[�h(End)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h(End)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd_ED
        {
            get { return _goodsMakerCd_ED; }
            set { _goodsMakerCd_ED = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>���i�J�n���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  SectionCodeRF
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeRF
        {
            get { return _sectionCodeRF; }
            set { _sectionCodeRF = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// <summary>
        /// �s�a�n���o�͏������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>TBODataExportCond�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBODataExportCond�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TBODataExportCond()
        {
        }

        /// <summary>
        /// �s�a�n���o�͏������[�N�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="categoryID">���i�J�e�S��</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="goodsMakerCd_ST">���[�J�[�R�[�h(Start)</param>
        /// <param name="goodsMakerCd_ED">���[�J�[�R�[�h(End)</param>
        /// <param name="priceStartDate">���i�J�n��</param>
        /// <param name="sectionCodeRF">���_�R�[�h</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>TBODataExportCond�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBODataExportCond�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TBODataExportCond(string enterpriseCode, int categoryID, string goodsNo, Int32 goodsMakerCd_ST, Int32 goodsMakerCd_ED, Int32 priceStartDate, string sectionCodeRF, ArrayList goodsMGroup, Int32 customerCode)
        {
            this._enterpriseCode = enterpriseCode;
            this._categoryID = categoryID;
            this._goodsNo = goodsNo;
            this._goodsMakerCd_ST = goodsMakerCd_ST;
            this._goodsMakerCd_ED = goodsMakerCd_ED;
            this._priceStartDate = priceStartDate;
            this._sectionCodeRF = sectionCodeRF;
            this._goodsMGroup = goodsMGroup;
            this._customerCode = customerCode;
        }

        /// <summary>
        /// �s�a�n���o�͏������[�N��������
        /// </summary>
        /// <returns>TBODataExportCond�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����TBODataExportCond�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TBODataExportCond Clone()
        {
            return new TBODataExportCond(this._enterpriseCode, this._categoryID, this._goodsNo, this._goodsMakerCd_ST, this._goodsMakerCd_ED, this._priceStartDate, this._sectionCodeRF, this._goodsMGroup, this._customerCode);
        }

        /// <summary>
        /// �s�a�n���o�͏������[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�TBODataExportCond�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBODataExportCond�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(TBODataExportCond target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                && (this.CategoryID == target.CategoryID)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsMakerCd_ST == target.GoodsMakerCd_ST)
                 && (this.GoodsMakerCd_ED == target.GoodsMakerCd_ED)
                 && (this.PriceStartDate == target.PriceStartDate)
                 && (this.SectionCodeRF == target.SectionCodeRF)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.CustomerCode == target.CustomerCode));
        }

        /// <summary>
        /// �s�a�n���o�͏������[�N��r����
        /// </summary>
        /// <param name="TBODataExportCond1">
        ///                    ��r����TBODataExportCond�N���X�̃C���X�^���X
        /// </param>
        /// <param name="TBODataExportCond2">��r����TBODataExportCond�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBODataExportCond�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(TBODataExportCond TBODataExportCond1, TBODataExportCond TBODataExportCond2)
        {
            return ((TBODataExportCond1.EnterpriseCode == TBODataExportCond2.EnterpriseCode)
                 && (TBODataExportCond1.CategoryID == TBODataExportCond2.CategoryID)
                 && (TBODataExportCond1.GoodsNo == TBODataExportCond2.GoodsNo)
                 && (TBODataExportCond1.GoodsMakerCd_ST == TBODataExportCond2.GoodsMakerCd_ST)
                 && (TBODataExportCond1.GoodsMakerCd_ED == TBODataExportCond2.GoodsMakerCd_ED)
                 && (TBODataExportCond1.PriceStartDate == TBODataExportCond2.PriceStartDate)
                 && (TBODataExportCond1.SectionCodeRF == TBODataExportCond2.SectionCodeRF)
                 && (TBODataExportCond1.GoodsMGroup == TBODataExportCond2.GoodsMGroup)
                 && (TBODataExportCond1.CustomerCode == TBODataExportCond2.CustomerCode));
        }
        /// <summary>
        /// �s�a�n���o�͏������[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�TBODataExportCond�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBODataExportCond�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(TBODataExportCond target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.CategoryID != target.CategoryID) resList.Add("CategoryID");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsMakerCd_ST != target.GoodsMakerCd_ST) resList.Add("GoodsMakerCd_ST");
            if (this.GoodsMakerCd_ED != target.GoodsMakerCd_ED) resList.Add("GoodsMakerCd_ED");
            if (this.PriceStartDate != target.PriceStartDate) resList.Add("PriceStartDate");
            if (this.SectionCodeRF != target.SectionCodeRF) resList.Add("SectionCodeRF");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");

            return resList;
        }

        /// <summary>
        /// �s�a�n���o�͏������[�N��r����
        /// </summary>
        /// <param name="TBODataExportCond1">��r����TBODataExportCond�N���X�̃C���X�^���X</param>
        /// <param name="TBODataExportCond2">��r����TBODataExportCond�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBODataExportCond�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(TBODataExportCond TBODataExportCond1, TBODataExportCond TBODataExportCond2)
        {
            ArrayList resList = new ArrayList();
            if (TBODataExportCond1.EnterpriseCode != TBODataExportCond2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (TBODataExportCond1.CategoryID != TBODataExportCond2.CategoryID) resList.Add("CategoryID");
            if (TBODataExportCond1.GoodsNo != TBODataExportCond2.GoodsNo) resList.Add("GoodsNo");
            if (TBODataExportCond1.GoodsMakerCd_ST != TBODataExportCond2.GoodsMakerCd_ST) resList.Add("GoodsMakerCd_ST");
            if (TBODataExportCond1.GoodsMakerCd_ED != TBODataExportCond2.GoodsMakerCd_ED) resList.Add("GoodsMakerCd_ED");
            if (TBODataExportCond1.PriceStartDate != TBODataExportCond2.PriceStartDate) resList.Add("PriceStartDate");
            if (TBODataExportCond1.SectionCodeRF != TBODataExportCond2.SectionCodeRF) resList.Add("SectionCodeRF");
            if (TBODataExportCond1.GoodsMGroup != TBODataExportCond2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (TBODataExportCond1.CustomerCode != TBODataExportCond2.CustomerCode) resList.Add("CustomerCode");

            return resList;
        }
    }
}
