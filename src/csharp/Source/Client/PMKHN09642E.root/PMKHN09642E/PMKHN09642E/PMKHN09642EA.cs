using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignGoodsData
    /// <summary>
    ///                      �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[���Ǘ��}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/04/13</br>
    /// <br>Genarated Date   :   2011/04/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>                 :   </br>
    /// </remarks>
    public class CampaignGoodsData
    {
        /// <summary>���_�R�[�h</summary>
        /// <remarks>00�͑S��</remarks>
        private string _sectionCode = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�L�����y�[���Ώۏ��i�ݒ�}�X�^�폜����</summary>
        private Int32 _goodsStCount;

        /// <summary>�L�����y�[�����̐ݒ�}�X�^�폜����</summary>
        private Int32 _nameStCount;

        /// <summary>�L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^�폜����</summary>
        private Int32 _customStCount;

        /// <summary>�L�����y�[���ڕW�ݒ�}�X�^�폜����</summary>
        private Int32 _targetStCount;

        /// <summary>���_����</summary>
        private string _sectionName = "";

        /// <summary>Ұ����</summary>
        private string _goodsMakerNm = "";

        /// <summary>���i��</summary>
        private string _headerGoodsNo = "";


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

        /// public propaty name  :  GoodsStCount
        /// <summary>�L�����y�[���Ώۏ��i�ݒ�}�X�^�폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���Ώۏ��i�ݒ�}�X�^�폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsStCount
        {
            get { return _goodsStCount; }
            set { _goodsStCount = value; }
        }

        /// public propaty name  :  NameStCount
        /// <summary>�L�����y�[�����̐ݒ�}�X�^�폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[�����̐ݒ�}�X�^�폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NameStCount
        {
            get { return _nameStCount; }
            set { _nameStCount = value; }
        }

        /// public propaty name  :  CustomStCount
        /// <summary>�L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^�폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^�폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomStCount
        {
            get { return _customStCount; }
            set { _customStCount = value; }
        }

        /// public propaty name  :  TargetStCount
        /// <summary>�L�����y�[���ڕW�ݒ�}�X�^�폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���ڕW�ݒ�}�X�^�폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TargetStCount
        {
            get { return _targetStCount; }
            set { _targetStCount = value; }
        }

        /// public propaty name  :  SectionName
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  GoodsMakerNm
        /// <summary>Ұ�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Ұ�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
        }

        /// public propaty name  :  HeaderGoodsNo
        /// <summary>���i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HeaderGoodsNo
        {
            get { return _headerGoodsNo; }
            set { _headerGoodsNo = value; }
        }


        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>CampaignGoodsData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignGoodsData()
        {
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h(00�͑S��)</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsStCount">�L�����y�[���Ώۏ��i�ݒ�}�X�^�폜����</param>
        /// <param name="nameStCount">�L�����y�[�����̐ݒ�}�X�^�폜����</param>
        /// <param name="customStCount">�L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^�폜����</param>
        /// <param name="targetStCount">�L�����y�[���ڕW�ݒ�}�X�^�폜����</param>
        /// <param name="sectionName">���_����</param>
        /// <param name="goodsMakerNm">Ұ����</param>
        /// <param name="headerGoodsNo">���i��</param>
        /// <returns>CampaignGoodsData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignGoodsData(string sectionCode, Int32 goodsMakerCd, Int32 goodsStCount, Int32 nameStCount, Int32 customStCount, Int32 targetStCount, string sectionName, string goodsMakerNm, string headerGoodsNo)
        {
            this._sectionCode = sectionCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsStCount = goodsStCount;
            this._nameStCount = nameStCount;
            this._customStCount = customStCount;
            this._targetStCount = targetStCount;
            this._sectionName = sectionName;
            this._goodsMakerNm = goodsMakerNm;
            this._headerGoodsNo = headerGoodsNo;
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^��������
        /// </summary>
        /// <returns>CampaignGoodsData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CampaignGoodsData�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignGoodsData Clone()
        {
            return new CampaignGoodsData(this._sectionCode, this._goodsMakerCd, this._goodsStCount, this._nameStCount, this._customStCount, this._targetStCount, this._sectionName, this._goodsMakerNm, this._headerGoodsNo);
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignGoodsData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CampaignGoodsData target)
        {
            return ((this.SectionCode == target.SectionCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsStCount == target.GoodsStCount)
                 && (this.NameStCount == target.NameStCount)
                 && (this.CustomStCount == target.CustomStCount)
                 && (this.TargetStCount == target.TargetStCount)
                 && (this.SectionName == target.SectionName)
                 && (this.GoodsMakerNm == target.GoodsMakerNm)
                 && (this.HeaderGoodsNo == target.HeaderGoodsNo));
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="campaignGoodsData1">
        ///                    ��r����CampaignGoodsData�N���X�̃C���X�^���X
        /// </param>
        /// <param name="campaignGoodsData2">��r����CampaignGoodsData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CampaignGoodsData campaignGoodsData1, CampaignGoodsData campaignGoodsData2)
        {
            return ((campaignGoodsData1.SectionCode == campaignGoodsData2.SectionCode)
                 && (campaignGoodsData1.GoodsMakerCd == campaignGoodsData2.GoodsMakerCd)
                 && (campaignGoodsData1.GoodsStCount == campaignGoodsData2.GoodsStCount)
                 && (campaignGoodsData1.NameStCount == campaignGoodsData2.NameStCount)
                 && (campaignGoodsData1.CustomStCount == campaignGoodsData2.CustomStCount)
                 && (campaignGoodsData1.TargetStCount == campaignGoodsData2.TargetStCount)
                 && (campaignGoodsData1.SectionName == campaignGoodsData2.SectionName)
                 && (campaignGoodsData1.GoodsMakerNm == campaignGoodsData2.GoodsMakerNm)
                 && (campaignGoodsData1.HeaderGoodsNo == campaignGoodsData2.HeaderGoodsNo));
        }
        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignGoodsData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsData�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CampaignGoodsData target)
        {
            ArrayList resList = new ArrayList();
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsStCount != target.GoodsStCount) resList.Add("GoodsStCount");
            if (this.NameStCount != target.NameStCount) resList.Add("NameStCount");
            if (this.CustomStCount != target.CustomStCount) resList.Add("CustomStCount");
            if (this.TargetStCount != target.TargetStCount) resList.Add("TargetStCount");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.GoodsMakerNm != target.GoodsMakerNm) resList.Add("GoodsMakerNm");
            if (this.HeaderGoodsNo != target.HeaderGoodsNo) resList.Add("HeaderGoodsNo");

            return resList;
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="campaignGoodsData1">��r����CampaignGoodsData�N���X�̃C���X�^���X</param>
        /// <param name="campaignGoodsData2">��r����CampaignGoodsData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsData�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CampaignGoodsData campaignGoodsData1, CampaignGoodsData campaignGoodsData2)
        {
            ArrayList resList = new ArrayList();
            if (campaignGoodsData1.SectionCode != campaignGoodsData2.SectionCode) resList.Add("SectionCode");
            if (campaignGoodsData1.GoodsMakerCd != campaignGoodsData2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (campaignGoodsData1.GoodsStCount != campaignGoodsData2.GoodsStCount) resList.Add("GoodsStCount");
            if (campaignGoodsData1.NameStCount != campaignGoodsData2.NameStCount) resList.Add("NameStCount");
            if (campaignGoodsData1.CustomStCount != campaignGoodsData2.CustomStCount) resList.Add("CustomStCount");
            if (campaignGoodsData1.TargetStCount != campaignGoodsData2.TargetStCount) resList.Add("TargetStCount");
            if (campaignGoodsData1.SectionName != campaignGoodsData2.SectionName) resList.Add("SectionName");
            if (campaignGoodsData1.GoodsMakerNm != campaignGoodsData2.GoodsMakerNm) resList.Add("GoodsMakerNm");
            if (campaignGoodsData1.HeaderGoodsNo != campaignGoodsData2.HeaderGoodsNo) resList.Add("HeaderGoodsNo");

            return resList;
        }
    }
}
