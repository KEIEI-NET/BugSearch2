using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MarketPriceAcqCond
    /// <summary>
    ///                      ����擾����
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����擾�����w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/5/18</br>
    /// <br>Genarated Date   :   2010/06/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MarketPriceAcqCond
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�A�N�Z�X�`�P�b�g</summary>
        private string _aaccessTicket = "";

        /// <summary>�W�F�l���[�V�����R�[�h</summary>
        private string _generationCode = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>�֘A�^��</summary>
        /// <remarks>���T�C�N���n�Ŏg�p</remarks>
        private string _relevanceModel = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";


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

        /// public propaty name  :  AaccessTicket
        /// <summary>�A�N�Z�X�`�P�b�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�N�Z�X�`�P�b�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AaccessTicket
        {
            get { return _aaccessTicket; }
            set { _aaccessTicket = value; }
        }

        /// public propaty name  :  GenerationCode
        /// <summary>�W�F�l���[�V�����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�F�l���[�V�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GenerationCode
        {
            get { return _generationCode; }
            set { _generationCode = value; }
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

        /// public propaty name  :  RelevanceModel
        /// <summary>�֘A�^���v���p�e�B</summary>
        /// <value>���T�C�N���n�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �֘A�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RelevanceModel
        {
            get { return _relevanceModel; }
            set { _relevanceModel = value; }
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

        /// public propaty name  :  BLGoodsName
        /// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }


        /// <summary>
        /// ����擾�����R���X�g���N�^
        /// </summary>
        /// <returns>MarketPriceAcqCond�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MarketPriceAcqCond�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MarketPriceAcqCond()
        {
        }

        /// <summary>
        /// ����擾�����R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="aaccessTicket">�A�N�Z�X�`�P�b�g</param>
        /// <param name="generationCode">�W�F�l���[�V�����R�[�h</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="relevanceModel">�֘A�^��(���T�C�N���n�Ŏg�p)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <returns>MarketPriceAcqCond�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MarketPriceAcqCond�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MarketPriceAcqCond(string enterpriseCode, string sectionCode, string aaccessTicket, string generationCode, Int32 bLGoodsCode, string relevanceModel, string enterpriseName, string bLGoodsName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._aaccessTicket = aaccessTicket;
            this._generationCode = generationCode;
            this._bLGoodsCode = bLGoodsCode;
            this._relevanceModel = relevanceModel;
            this._enterpriseName = enterpriseName;
            this._bLGoodsName = bLGoodsName;

        }

        /// <summary>
        /// ����擾������������
        /// </summary>
        /// <returns>MarketPriceAcqCond�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����MarketPriceAcqCond�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MarketPriceAcqCond Clone()
        {
            return new MarketPriceAcqCond(this._enterpriseCode, this._sectionCode, this._aaccessTicket, this._generationCode, this._bLGoodsCode, this._relevanceModel, this._enterpriseName, this._bLGoodsName);
        }

        /// <summary>
        /// ����擾������r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�MarketPriceAcqCond�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MarketPriceAcqCond�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(MarketPriceAcqCond target)
        {
            return ( ( this.EnterpriseCode == target.EnterpriseCode )
                 && ( this.SectionCode == target.SectionCode )
                 && ( this.AaccessTicket == target.AaccessTicket )
                 && ( this.GenerationCode == target.GenerationCode )
                 && ( this.BLGoodsCode == target.BLGoodsCode )
                 && ( this.RelevanceModel == target.RelevanceModel )
                 && ( this.EnterpriseName == target.EnterpriseName )
                 && ( this.BLGoodsName == target.BLGoodsName ) );
        }

        /// <summary>
        /// ����擾������r����
        /// </summary>
        /// <param name="marketPriceAcqCond1">
        ///                    ��r����MarketPriceAcqCond�N���X�̃C���X�^���X
        /// </param>
        /// <param name="marketPriceAcqCond2">��r����MarketPriceAcqCond�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MarketPriceAcqCond�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(MarketPriceAcqCond marketPriceAcqCond1, MarketPriceAcqCond marketPriceAcqCond2)
        {
            return ( ( marketPriceAcqCond1.EnterpriseCode == marketPriceAcqCond2.EnterpriseCode )
                 && ( marketPriceAcqCond1.SectionCode == marketPriceAcqCond2.SectionCode )
                 && ( marketPriceAcqCond1.AaccessTicket == marketPriceAcqCond2.AaccessTicket )
                 && ( marketPriceAcqCond1.GenerationCode == marketPriceAcqCond2.GenerationCode )
                 && ( marketPriceAcqCond1.BLGoodsCode == marketPriceAcqCond2.BLGoodsCode )
                 && ( marketPriceAcqCond1.RelevanceModel == marketPriceAcqCond2.RelevanceModel )
                 && ( marketPriceAcqCond1.EnterpriseName == marketPriceAcqCond2.EnterpriseName )
                 && ( marketPriceAcqCond1.BLGoodsName == marketPriceAcqCond2.BLGoodsName ) );
        }
        /// <summary>
        /// ����擾������r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�MarketPriceAcqCond�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MarketPriceAcqCond�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(MarketPriceAcqCond target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.AaccessTicket != target.AaccessTicket) resList.Add("AaccessTicket");
            if (this.GenerationCode != target.GenerationCode) resList.Add("GenerationCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.RelevanceModel != target.RelevanceModel) resList.Add("RelevanceModel");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }

        /// <summary>
        /// ����擾������r����
        /// </summary>
        /// <param name="marketPriceAcqCond1">��r����MarketPriceAcqCond�N���X�̃C���X�^���X</param>
        /// <param name="marketPriceAcqCond2">��r����MarketPriceAcqCond�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MarketPriceAcqCond�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(MarketPriceAcqCond marketPriceAcqCond1, MarketPriceAcqCond marketPriceAcqCond2)
        {
            ArrayList resList = new ArrayList();
            if (marketPriceAcqCond1.EnterpriseCode != marketPriceAcqCond2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (marketPriceAcqCond1.SectionCode != marketPriceAcqCond2.SectionCode) resList.Add("SectionCode");
            if (marketPriceAcqCond1.AaccessTicket != marketPriceAcqCond2.AaccessTicket) resList.Add("AaccessTicket");
            if (marketPriceAcqCond1.GenerationCode != marketPriceAcqCond2.GenerationCode) resList.Add("GenerationCode");
            if (marketPriceAcqCond1.BLGoodsCode != marketPriceAcqCond2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (marketPriceAcqCond1.RelevanceModel != marketPriceAcqCond2.RelevanceModel) resList.Add("RelevanceModel");
            if (marketPriceAcqCond1.EnterpriseName != marketPriceAcqCond2.EnterpriseName) resList.Add("EnterpriseName");
            if (marketPriceAcqCond1.BLGoodsName != marketPriceAcqCond2.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }
    }
}
