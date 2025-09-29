using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CMTCnectInfo
    /// <summary>
    ///                      �ȒP�⍇���ڑ����
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ȒP�⍇���ڑ����w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/03/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SimplInqCnectInfo
    {
        /// <summary>���W�ԍ�</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;


        /// public propaty name  :  CashRegisterNo
        /// <summary>���W�ԍ��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
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
        /// �ȒP�⍇���ڑ����R���X�g���N�^
        /// </summary>
        /// <returns>CMTCnectInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CMTCnectInfo�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SimplInqCnectInfo()
        {
        }

        /// <summary>
        /// �ȒP�⍇���ڑ����R���X�g���N�^
        /// </summary>
        /// <param name="cashRegisterNo">���W�ԍ�(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>CMTCnectInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CMTCnectInfo�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SimplInqCnectInfo(Int32 cashRegisterNo, Int32 customerCode)
        {
            this._cashRegisterNo = cashRegisterNo;
            this._customerCode = customerCode;

        }

        /// <summary>
        /// �ȒP�⍇���ڑ���񕡐�����
        /// </summary>
        /// <returns>CMTCnectInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CMTCnectInfo�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SimplInqCnectInfo Clone()
        {
            return new SimplInqCnectInfo(this._cashRegisterNo, this._customerCode);
        }

        /// <summary>
        /// �ȒP�⍇���ڑ�����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CMTCnectInfo�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CMTCnectInfo�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SimplInqCnectInfo target)
        {
            return ( ( this.CashRegisterNo == target.CashRegisterNo )
                 && ( this.CustomerCode == target.CustomerCode ) );
        }

        /// <summary>
        /// �ȒP�⍇���ڑ�����r����
        /// </summary>
        /// <param name="cMTCnectInfo1">
        ///                    ��r����CMTCnectInfo�N���X�̃C���X�^���X
        /// </param>
        /// <param name="cMTCnectInfo2">��r����CMTCnectInfo�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CMTCnectInfo�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SimplInqCnectInfo cMTCnectInfo1, SimplInqCnectInfo cMTCnectInfo2)
        {
            return ( ( cMTCnectInfo1.CashRegisterNo == cMTCnectInfo2.CashRegisterNo )
                 && ( cMTCnectInfo1.CustomerCode == cMTCnectInfo2.CustomerCode ) );
        }
        /// <summary>
        /// �ȒP�⍇���ڑ�����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CMTCnectInfo�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CMTCnectInfo�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SimplInqCnectInfo target)
        {
            ArrayList resList = new ArrayList();
            if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");

            return resList;
        }

        /// <summary>
        /// �ȒP�⍇���ڑ�����r����
        /// </summary>
        /// <param name="cMTCnectInfo1">��r����CMTCnectInfo�N���X�̃C���X�^���X</param>
        /// <param name="cMTCnectInfo2">��r����CMTCnectInfo�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CMTCnectInfo�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SimplInqCnectInfo cMTCnectInfo1, SimplInqCnectInfo cMTCnectInfo2)
        {
            ArrayList resList = new ArrayList();
            if (cMTCnectInfo1.CashRegisterNo != cMTCnectInfo2.CashRegisterNo) resList.Add("CashRegisterNo");
            if (cMTCnectInfo1.CustomerCode != cMTCnectInfo2.CustomerCode) resList.Add("CustomerCode");

            return resList;
        }
    }
}
