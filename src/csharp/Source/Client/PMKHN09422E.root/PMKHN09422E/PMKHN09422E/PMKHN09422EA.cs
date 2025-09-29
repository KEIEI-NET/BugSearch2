//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�U�[���i�E�����ꊇ�ݒ�
// �v���O�����T�v   : ���[�U�[���i�E�����𕡐����ꊇ�ŏC���E�o�^����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UserPriceData
    /// <summary>
    ///                      ���[�U�[���i�E�����ꊇ�ݒ�
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[�U�[���i�E�����ꊇ�ݒ�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UserPriceData
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_����</summary>
        private string _sectionName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i����</summary>
        private string _bLGoodsName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i���[�J�[����</summary>
        private string _goodsMakerName = "";


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

        /// public propaty name  :  BLGoodsName
        /// <summary>BL���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
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

        /// public propaty name  :  GoodsMakerName
        /// <summary>���i���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerName
        {
            get { return _goodsMakerName; }
            set { _goodsMakerName = value; }
        }


        /// <summary>
        /// ���[�U�[���i�E�����ꊇ�ݒ�R���X�g���N�^
        /// </summary>
        /// <returns>UserPriceData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UserPriceData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UserPriceData()
        {
        }

        /// <summary>
        /// ���[�U�[���i�E�����ꊇ�ݒ�R���X�g���N�^
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionName">���_����</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="bLGoodsName">BL���i����</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsMakerName">���i���[�J�[����</param>
        /// <returns>UserPriceData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UserPriceData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UserPriceData(string sectionCode, string sectionName, Int32 bLGoodsCode, string bLGoodsName, Int32 goodsMakerCd, string goodsMakerName)
        {
            this._sectionCode = sectionCode;
            this._sectionName = sectionName;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsName = bLGoodsName;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsMakerName = goodsMakerName;

        }

        /// <summary>
        /// ���[�U�[���i�E�����ꊇ�ݒ蕡������
        /// </summary>
        /// <returns>UserPriceData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����UserPriceData�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UserPriceData Clone()
        {
            return new UserPriceData(this._sectionCode, this._sectionName, this._bLGoodsCode, this._bLGoodsName, this._goodsMakerCd, this._goodsMakerName);
        }

        /// <summary>
        /// ���[�U�[���i�E�����ꊇ�ݒ��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UserPriceData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UserPriceData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(UserPriceData target)
        {
            return ((this.SectionCode == target.SectionCode)
                 && (this.SectionName == target.SectionName)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsMakerName == target.GoodsMakerName));
        }

        /// <summary>
        /// ���[�U�[���i�E�����ꊇ�ݒ��r����
        /// </summary>
        /// <param name="userPriceData1">
        ///                    ��r����UserPriceData�N���X�̃C���X�^���X
        /// </param>
        /// <param name="userPriceData2">��r����UserPriceData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UserPriceData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(UserPriceData userPriceData1, UserPriceData userPriceData2)
        {
            return ((userPriceData1.SectionCode == userPriceData2.SectionCode)
                 && (userPriceData1.SectionName == userPriceData2.SectionName)
                 && (userPriceData1.BLGoodsCode == userPriceData2.BLGoodsCode)
                 && (userPriceData1.BLGoodsName == userPriceData2.BLGoodsName)
                 && (userPriceData1.GoodsMakerCd == userPriceData2.GoodsMakerCd)
                 && (userPriceData1.GoodsMakerName == userPriceData2.GoodsMakerName));
        }
        /// <summary>
        /// ���[�U�[���i�E�����ꊇ�ݒ��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UserPriceData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UserPriceData�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(UserPriceData target)
        {
            ArrayList resList = new ArrayList();
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsMakerName != target.GoodsMakerName) resList.Add("GoodsMakerName");

            return resList;
        }

        /// <summary>
        /// ���[�U�[���i�E�����ꊇ�ݒ��r����
        /// </summary>
        /// <param name="userPriceData1">��r����UserPriceData�N���X�̃C���X�^���X</param>
        /// <param name="userPriceData2">��r����UserPriceData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UserPriceData�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(UserPriceData userPriceData1, UserPriceData userPriceData2)
        {
            ArrayList resList = new ArrayList();
            if (userPriceData1.SectionCode != userPriceData2.SectionCode) resList.Add("SectionCode");
            if (userPriceData1.SectionName != userPriceData2.SectionName) resList.Add("SectionName");
            if (userPriceData1.BLGoodsCode != userPriceData2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (userPriceData1.BLGoodsName != userPriceData2.BLGoodsName) resList.Add("BLGoodsName");
            if (userPriceData1.GoodsMakerCd != userPriceData2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (userPriceData1.GoodsMakerName != userPriceData2.GoodsMakerName) resList.Add("GoodsMakerName");

            return resList;
        }
    }
}
