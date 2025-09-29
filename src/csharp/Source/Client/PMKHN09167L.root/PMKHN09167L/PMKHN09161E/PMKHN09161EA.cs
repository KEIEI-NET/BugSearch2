using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AuthorityLevel
    /// <summary>
    ///                      �������x���}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �������x���}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/7/3</br>
    /// <br>Genarated Date   :   2008/07/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class AuthorityLevel
    {
        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>�������x���敪</summary>
        /// <remarks>0:�E�� 1:�ٗp�`��</remarks>
        private Int32 _authorityLevelDiv;

        /// <summary>�������x���R�[�h</summary>
        /// <remarks>100(�ō�����)�`10(�Œጠ��)</remarks>
        private Int32 _authorityLevelCd;

        /// <summary>�������x������</summary>
        private string _authorityLevelNm = "";


        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  AuthorityLevelDiv
        /// <summary>�������x���敪�v���p�e�B</summary>
        /// <value>0:�E�� 1:�ٗp�`��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������x���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AuthorityLevelDiv
        {
            get { return _authorityLevelDiv; }
            set { _authorityLevelDiv = value; }
        }

        /// public propaty name  :  AuthorityLevelCd
        /// <summary>�������x���R�[�h�v���p�e�B</summary>
        /// <value>100(�ō�����)�`10(�Œጠ��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������x���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AuthorityLevelCd
        {
            get { return _authorityLevelCd; }
            set { _authorityLevelCd = value; }
        }

        /// public propaty name  :  AuthorityLevelNm
        /// <summary>�������x�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������x�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AuthorityLevelNm
        {
            get { return _authorityLevelNm; }
            set { _authorityLevelNm = value; }
        }


        /// <summary>
        /// �������x���}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>AuthorityLevel�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AuthorityLevel�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AuthorityLevel()
        {
        }

        /// <summary>
        /// �������x���}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="offerDate">�񋟓��t(YYYYMMDD)</param>
        /// <param name="authorityLevelDiv">�������x���敪(0:�E�� 1:�ٗp�`��)</param>
        /// <param name="authorityLevelCd">�������x���R�[�h(100(�ō�����)�`10(�Œጠ��))</param>
        /// <param name="authorityLevelNm">�������x������</param>
        /// <returns>AuthorityLevel�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AuthorityLevel�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AuthorityLevel(Int32 offerDate, Int32 authorityLevelDiv, Int32 authorityLevelCd, string authorityLevelNm)
        {
            this._offerDate = offerDate;
            this._authorityLevelDiv = authorityLevelDiv;
            this._authorityLevelCd = authorityLevelCd;
            this._authorityLevelNm = authorityLevelNm;

        }

        /// <summary>
        /// �������x���}�X�^��������
        /// </summary>
        /// <returns>AuthorityLevel�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����AuthorityLevel�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AuthorityLevel Clone()
        {
            return new AuthorityLevel(this._offerDate, this._authorityLevelDiv, this._authorityLevelCd, this._authorityLevelNm);
        }

        /// <summary>
        /// �������x���}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AuthorityLevel�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AuthorityLevel�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(AuthorityLevel target)
        {
            return ((this.OfferDate == target.OfferDate)
                 && (this.AuthorityLevelDiv == target.AuthorityLevelDiv)
                 && (this.AuthorityLevelCd == target.AuthorityLevelCd)
                 && (this.AuthorityLevelNm == target.AuthorityLevelNm));
        }

        /// <summary>
        /// �������x���}�X�^��r����
        /// </summary>
        /// <param name="authorityLevel1">
        ///                    ��r����AuthorityLevel�N���X�̃C���X�^���X
        /// </param>
        /// <param name="authorityLevel2">��r����AuthorityLevel�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AuthorityLevel�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(AuthorityLevel authorityLevel1, AuthorityLevel authorityLevel2)
        {
            return ((authorityLevel1.OfferDate == authorityLevel2.OfferDate)
                 && (authorityLevel1.AuthorityLevelDiv == authorityLevel2.AuthorityLevelDiv)
                 && (authorityLevel1.AuthorityLevelCd == authorityLevel2.AuthorityLevelCd)
                 && (authorityLevel1.AuthorityLevelNm == authorityLevel2.AuthorityLevelNm));
        }
        /// <summary>
        /// �������x���}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AuthorityLevel�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AuthorityLevel�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(AuthorityLevel target)
        {
            ArrayList resList = new ArrayList();
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.AuthorityLevelDiv != target.AuthorityLevelDiv) resList.Add("AuthorityLevelDiv");
            if (this.AuthorityLevelCd != target.AuthorityLevelCd) resList.Add("AuthorityLevelCd");
            if (this.AuthorityLevelNm != target.AuthorityLevelNm) resList.Add("AuthorityLevelNm");

            return resList;
        }

        /// <summary>
        /// �������x���}�X�^��r����
        /// </summary>
        /// <param name="authorityLevel1">��r����AuthorityLevel�N���X�̃C���X�^���X</param>
        /// <param name="authorityLevel2">��r����AuthorityLevel�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AuthorityLevel�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(AuthorityLevel authorityLevel1, AuthorityLevel authorityLevel2)
        {
            ArrayList resList = new ArrayList();
            if (authorityLevel1.OfferDate != authorityLevel2.OfferDate) resList.Add("OfferDate");
            if (authorityLevel1.AuthorityLevelDiv != authorityLevel2.AuthorityLevelDiv) resList.Add("AuthorityLevelDiv");
            if (authorityLevel1.AuthorityLevelCd != authorityLevel2.AuthorityLevelCd) resList.Add("AuthorityLevelCd");
            if (authorityLevel1.AuthorityLevelNm != authorityLevel2.AuthorityLevelNm) resList.Add("AuthorityLevelNm");

            return resList;
        }
    }
}
