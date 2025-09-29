using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CnectOrgNSSecInfo
    /// <summary>
    ///                      �A����NS���_���
    /// </summary>
    /// <remarks>
    /// <br>note             :   �A����NS���_���w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2014/9/15</br>
    /// <br>Genarated Date   :   2014/09/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CnectOrgNSSecInfo
    {
        /// <summary>�A������ƃR�[�h</summary>
        private string _cnectOriginalEpCd = "";

        /// <summary>�A�������_�R�[�h</summary>
        private string _cnectOriginalSecCd = "";

        /// <summary>�A�������_�K�C�h����</summary>
        private string _cnectOriginalSecGNm = "";


        /// public propaty name  :  CnectOriginalEpCd
        /// <summary>�A������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOriginalEpCd
        {
            get { return _cnectOriginalEpCd; }
            set { _cnectOriginalEpCd = value; }
        }

        /// public propaty name  :  CnectOriginalSecCd
        /// <summary>�A�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOriginalSecCd
        {
            get { return _cnectOriginalSecCd; }
            set { _cnectOriginalSecCd = value; }
        }

        /// public propaty name  :  CnectOriginalSecGNm
        /// <summary>�A�������_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�������_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOriginalSecGNm
        {
            get { return _cnectOriginalSecGNm; }
            set { _cnectOriginalSecGNm = value; }
        }


        /// <summary>
        /// �A����NS���_���R���X�g���N�^
        /// </summary>
        /// <returns>CnectOrgNSSecInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CnectOrgNSSecInfo�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CnectOrgNSSecInfo()
        {
        }

        /// <summary>
        /// �A����NS���_���R���X�g���N�^
        /// </summary>
        /// <param name="cnectOriginalEpCd">�A������ƃR�[�h</param>
        /// <param name="cnectOriginalSecCd">�A�������_�R�[�h</param>
        /// <param name="cnectOriginalSecGNm">�A�������_�K�C�h����</param>
        /// <returns>CnectOrgNSSecInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CnectOrgNSSecInfo�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CnectOrgNSSecInfo(string cnectOriginalEpCd, string cnectOriginalSecCd, string cnectOriginalSecGNm)
        {
            this._cnectOriginalEpCd = cnectOriginalEpCd;
            this._cnectOriginalSecCd = cnectOriginalSecCd;
            this._cnectOriginalSecGNm = cnectOriginalSecGNm;

        }

        /// <summary>
        /// �A����NS���_��񕡐�����
        /// </summary>
        /// <returns>CnectOrgNSSecInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CnectOrgNSSecInfo�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CnectOrgNSSecInfo Clone()
        {
            return new CnectOrgNSSecInfo(this._cnectOriginalEpCd, this._cnectOriginalSecCd, this._cnectOriginalSecGNm);
        }

        /// <summary>
        /// �A����NS���_����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CnectOrgNSSecInfo�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CnectOrgNSSecInfo�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CnectOrgNSSecInfo target)
        {
            return ((this.CnectOriginalEpCd == target.CnectOriginalEpCd)
                 && (this.CnectOriginalSecCd == target.CnectOriginalSecCd)
                 && (this.CnectOriginalSecGNm == target.CnectOriginalSecGNm));
        }

        /// <summary>
        /// �A����NS���_����r����
        /// </summary>
        /// <param name="cnectOrgNSSecInfo1">
        ///                    ��r����CnectOrgNSSecInfo�N���X�̃C���X�^���X
        /// </param>
        /// <param name="cnectOrgNSSecInfo2">��r����CnectOrgNSSecInfo�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CnectOrgNSSecInfo�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CnectOrgNSSecInfo cnectOrgNSSecInfo1, CnectOrgNSSecInfo cnectOrgNSSecInfo2)
        {
            return ((cnectOrgNSSecInfo1.CnectOriginalEpCd == cnectOrgNSSecInfo2.CnectOriginalEpCd)
                 && (cnectOrgNSSecInfo1.CnectOriginalSecCd == cnectOrgNSSecInfo2.CnectOriginalSecCd)
                 && (cnectOrgNSSecInfo1.CnectOriginalSecGNm == cnectOrgNSSecInfo2.CnectOriginalSecGNm));
        }
        /// <summary>
        /// �A����NS���_����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CnectOrgNSSecInfo�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CnectOrgNSSecInfo�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CnectOrgNSSecInfo target)
        {
            ArrayList resList = new ArrayList();
            if (this.CnectOriginalEpCd != target.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (this.CnectOriginalSecCd != target.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
            if (this.CnectOriginalSecGNm != target.CnectOriginalSecGNm) resList.Add("CnectOriginalSecGNm");

            return resList;
        }

        /// <summary>
        /// �A����NS���_����r����
        /// </summary>
        /// <param name="cnectOrgNSSecInfo1">��r����CnectOrgNSSecInfo�N���X�̃C���X�^���X</param>
        /// <param name="cnectOrgNSSecInfo2">��r����CnectOrgNSSecInfo�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CnectOrgNSSecInfo�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CnectOrgNSSecInfo cnectOrgNSSecInfo1, CnectOrgNSSecInfo cnectOrgNSSecInfo2)
        {
            ArrayList resList = new ArrayList();
            if (cnectOrgNSSecInfo1.CnectOriginalEpCd != cnectOrgNSSecInfo2.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (cnectOrgNSSecInfo1.CnectOriginalSecCd != cnectOrgNSSecInfo2.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
            if (cnectOrgNSSecInfo1.CnectOriginalSecGNm != cnectOrgNSSecInfo2.CnectOriginalSecGNm) resList.Add("CnectOriginalSecGNm");

            return resList;
        }
    }
}
