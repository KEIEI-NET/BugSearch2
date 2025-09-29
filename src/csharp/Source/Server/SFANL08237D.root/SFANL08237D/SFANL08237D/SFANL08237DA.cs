using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePrtCmnExtPrmWork
    /// <summary>
    ///                      ���R���[���ʒ��o�p�����[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[���ʒ��o�p�����[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2007/7/23</br>
    /// <br>Genarated Date   :   2007/07/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
//    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePrtCmnExtPrmWork
    {
        /// <summary>
        /// ���R���[���ʒ��o�p�����[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>FrePrtCmnExtPrmWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePrtCmnExtPrmWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FrePrtCmnExtPrmWork()
        {
        }

        /// <summary>
        /// �R���X�g���N�^�I�[�o�[���[�h(+1)
        /// </summary>
        /// <param name="selectItems">select����</param>
        /// <param name="cipherItemsLs">�Í�������ID���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCodeList">���_�R�[�h</param>
        /// <param name="sectionNameList">���_����</param>
        /// <param name="sectionOptionDiv">���_�I�v�V�����L��</param>
        /// <param name="frePprECndWorkLs">���o����</param>
        public FrePrtCmnExtPrmWork(string selectItems, List<string> cipherItemsLs, string enterpriseCode, List<string>sectionCodeList,
            List<string> sectionNameList, bool sectionOptionDiv, List<FrePprECndWork> frePprECndWorkLs)
		{
            _selectItems = selectItems;
            _cipherItemsLs = cipherItemsLs;
            _enterpriseCode = enterpriseCode;
            _sectionCodeList = sectionCodeList;

            _sectionNameList = sectionNameList;
            _sectionOptionDiv = sectionOptionDiv;
            _frePprECndWorkLs = frePprECndWorkLs;
        }
        
        /// <summary>Select����</summary>
        private string _selectItems = "";

        /// <summary>�Í�������ID���X�g</summary>
        private List<string> _cipherItemsLs;

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private List<string> _sectionCodeList;

        /// <summary>���_����</summary>
        private List<string> _sectionNameList;

        /// <summary>���_�I�v�V�����L��</summary>
        private bool _sectionOptionDiv;

        /// <summary>���o����</summary>
        private List<FrePprECndWork> _frePprECndWorkLs;
     
        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  SelectItems
        /// <summary>Select���ڃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Select���ڃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelectItems
        {
            get { return _selectItems; }
            set { _selectItems = value; }
        }

        /// public propaty name  :  CipherItemsLs
        /// <summary>�Í�������ID���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Í�������ID���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> CipherItemsLs
        {
            get { return _cipherItemsLs; }
            set { _cipherItemsLs = value; }
        }

        /// public propaty name  :  CipherItemsLs
        /// <summary>���o�������X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�������X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<FrePprECndWork> FrePprECndLs
        {
            get { return _frePprECndWorkLs; }
            set { _frePprECndWorkLs = value; }
        }

        /// <summary>���_�R�[�h</summary>
        public List<string> SectionCodeList
        {
            get { return _sectionCodeList; }
            set { _sectionCodeList = value; }
        }

        /// <summary>���_����</summary>
        public List<string> SectionNameList
        {
            get { return _sectionNameList; }
            set { _sectionNameList = value; }
        }
        
        /// <summary>���_�I�v�V�����L��</summary>
        public bool SectionOptionDiv
        {
            get { return _sectionOptionDiv; }
            set { _sectionOptionDiv = value; }
        }

        #region public methods
        /// <summary>
        /// ���o�����̃��O���쐬���܂�
        /// </summary>
        /// <returns>����F0�@�ُ�F-1</returns>
        public string GenerateExtCndPrmLog()
        {
            StringBuilder paraStr = new StringBuilder("Search Para: ");
            //��ƃR�[�h�͕K�{
            paraStr.Append("enterpriseCode:").Append(this._enterpriseCode);
            //���_�I�v�V�����L��̎�
            if (SectionOptionDiv)
            {
                paraStr.Append(",SectionCode:");
                foreach (string secNm in this._sectionCodeList)
                {
                    paraStr.Append(secNm + "/");
                }
            }
            if (_frePprECndWorkLs != null)
            {
                foreach (FrePprECndWork eCnd in _frePprECndWorkLs)
                {
                    paraStr.Append("," + eCnd.ExtraConditionTitle + ":");
                    switch (eCnd.ExtraConditionDivCd)
                    {
                        case 1:
                            {   //���l�^
                                paraStr.Append(eCnd.StExtraNumCode.ToString() + "�`" + eCnd.EdExtraNumCode.ToString());
                                break;
                            }
                        case 2:
                        case 3:
                            {   //�����^
                                paraStr.Append(eCnd.StExtraCharCode + "�`" + eCnd.EdExtraCharCode);
                                break;
                            }
                        case 4:
                            {   //���t�^
                                paraStr.Append(eCnd.StartExtraDate.ToString() + "�`" + eCnd.EndExtraDate.ToString());
                                break;
                            }
                        case 5:
                            {   //�R���{�{�b�N�X
                                paraStr.Append(eCnd.StExtraNumCode);
                                break;
                            }
                        case 6:
                            {   //�`�F�b�N�{�b�N�X
                                if (eCnd.CheckItemCode1 != -1) paraStr.Append(eCnd.CheckItemCode1.ToString() + "/");
                                if (eCnd.CheckItemCode2 != -1) paraStr.Append(eCnd.CheckItemCode2.ToString() + "/");
                                if (eCnd.CheckItemCode3 != -1) paraStr.Append(eCnd.CheckItemCode3.ToString() + "/");
                                if (eCnd.CheckItemCode4 != -1) paraStr.Append(eCnd.CheckItemCode4.ToString() + "/");
                                if (eCnd.CheckItemCode5 != -1) paraStr.Append(eCnd.CheckItemCode5.ToString() + "/");
                                if (eCnd.CheckItemCode6 != -1) paraStr.Append(eCnd.CheckItemCode6.ToString() + "/");
                                if (eCnd.CheckItemCode7 != -1) paraStr.Append(eCnd.CheckItemCode7.ToString() + "/");
                                if (eCnd.CheckItemCode8 != -1) paraStr.Append(eCnd.CheckItemCode8.ToString() + "/");
                                if (eCnd.CheckItemCode9 != -1) paraStr.Append(eCnd.CheckItemCode9.ToString() + "/");
                                if (eCnd.CheckItemCode10 != -1) paraStr.Append(eCnd.CheckItemCode10.ToString());
                                break;
                            }
                    }
                }
            }
            return paraStr.ToString();
        }
        #endregion
    }
}