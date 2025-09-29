using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PartsPosCodeSet
    /// <summary>
    ///                      ���ʃ}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���ʃ}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class PartsPosCodeSet
    {
        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於</summary>
        private string _customerSnm;

        /// <summary>�������ʃR�[�h</summary>
        private Int32 _searchPartsPosCode;

        /// <summary>�������ʃR�[�h����</summary>
        /// <remarks>�\������0�ABL�R�[�h0�̏ꍇ���ʖ��̂��Z�b�g</remarks>
        private string _searchPartsPosName = "";

        /// <summary>�������ʕ\������</summary>
        private Int32 _posDispOrder;

        /// <summary>BL�R�[�h</summary>
        /// <remarks>�O�̏ꍇ�A���ʖ��̗p���R�[�h</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGoodsHalfName = "";

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

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ於�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SearchPartsPosCode
        /// <summary>�������ʃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchPartsPosCode
        {
            get { return _searchPartsPosCode; }
            set { _searchPartsPosCode = value; }
        }

        /// public propaty name  :  SearchPartsPosName
        /// <summary>�������ʃR�[�h���̃v���p�e�B</summary>
        /// <value>�\������0�ABL�R�[�h0�̏ꍇ���ʖ��̂��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʃR�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchPartsPosName
        {
            get { return _searchPartsPosName; }
            set { _searchPartsPosName = value; }
        }

        /// public propaty name  :  PosDispOrder
        /// <summary>�������ʕ\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʕ\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PosDispOrder
        {
            get { return _posDispOrder; }
            set { _posDispOrder = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// <value>�O�̏ꍇ�A���ʖ��̗p���R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL���i�R�[�h���́i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// <summary>
        /// ���ʁi����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsPosCodeSet Clone()
        {
            return new PartsPosCodeSet(this._customerCode, this._customerSnm, this._searchPartsPosCode, this._searchPartsPosName, this._posDispOrder, this._tbsPartsCode, this._bLGoodsHalfName);
        }

        /// <summary>
        /// ���ʁi����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PartsPosCodeSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsPosCodeSet()
        {
        }

        /// <summary>
        /// ���ʁi����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="CustomerCode"></param>
        /// <param name="CustomerSnm"></param>
        /// <param name="SearchPartsPosCode"></param>
        /// <param name="SearchPartsPosName"></param>
        /// <param name="PosDispOrder"></param>
        /// <param name="TbsPartsCode"></param>
        /// <param name="BLGoodsHalfName"></param>
        public PartsPosCodeSet(Int32 CustomerCode, string CustomerSnm, Int32 SearchPartsPosCode, string SearchPartsPosName, Int32 PosDispOrder, Int32 TbsPartsCode, string BLGoodsHalfName)
        {
            this._customerCode = CustomerCode;
            this._customerSnm = CustomerSnm;
            this._searchPartsPosCode = SearchPartsPosCode;
            this._searchPartsPosName = SearchPartsPosName;
            this._posDispOrder = PosDispOrder;
            this._tbsPartsCode = TbsPartsCode;
            this._bLGoodsHalfName = BLGoodsHalfName;
        }
    }
}
