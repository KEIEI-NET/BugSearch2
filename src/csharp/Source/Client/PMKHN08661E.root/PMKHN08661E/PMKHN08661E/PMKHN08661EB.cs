using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsSetSet
    /// <summary>
    ///                      �Z�b�g�}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �Z�b�g�}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class GoodsSetSet
    {
        /// <summary>�e���[�J�[�R�[�h</summary>
        private Int32 _parentGoodsMakerCd;

        /// <summary>�e���[�J�[��</summary>
        private string _parentGoodsMakerName = "";

        /// <summary>�e���i�ԍ�</summary>
        private string _parentGoodsNo = "";

        /// <summary>�\������</summary>
        private Int32 _displayOrder;

        /// <summary>�q���i�ԍ�</summary>
        private string _subGoodsNo = "";

        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>�q���i���[�J�[�R�[�h</summary>
        private Int32 _subGoodsMakerCd;

        /// <summary>�q���i���[�J�[��</summary>
        private string _subGoodsMakerName = "";

        /// <summary>���ʁi�����j</summary>
        private Double _cntFl;

        /// <summary>�Z�b�g�K�i�E���L����</summary>
        private string _setSpecialNote = "";


        /// public propaty name  :  ParentGoodsMakerCd
        /// <summary>�e���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ParentGoodsMakerCd
        {
            get { return _parentGoodsMakerCd; }
            set { _parentGoodsMakerCd = value; }
        }

        /// public propaty name  :  ParentGoodsMakerName
        /// <summary>�e���[�J�[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���[�J�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ParentGoodsMakerName
        {
            get { return _parentGoodsMakerName; }
            set { _parentGoodsMakerName = value; }
        }

        /// public propaty name  :  ParentGoodsNo
        /// <summary>�e���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ParentGoodsNo
        {
            get { return _parentGoodsNo; }
            set { _parentGoodsNo = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>�\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  SubGoodsNo
        /// <summary>�q���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SubGoodsNo
        {
            get { return _subGoodsNo; }
            set { _subGoodsNo = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  SubGoodsMakerCd
        /// <summary>�q���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubGoodsMakerCd
        {
            get { return _subGoodsMakerCd; }
            set { _subGoodsMakerCd = value; }
        }

        /// public propaty name  :  SubGoodsMakerName
        /// <summary>�q���i���[�J�[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q���i���[�J�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SubGoodsMakerName
        {
            get { return _subGoodsMakerName; }
            set { _subGoodsMakerName = value; }
        }

        /// public propaty name  :  CntFl
        /// <summary>���ʁi�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʁi�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double CntFl
        {
            get { return _cntFl; }
            set { _cntFl = value; }
        }

        /// public propaty name  :  SetSpecialNote
        /// <summary>�Z�b�g�K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g�K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SetSpecialNote
        {
            get { return _setSpecialNote; }
            set { _setSpecialNote = value; }
        }

        /// <summary>
        /// �Z�b�g�i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsSetSet Clone()
        {
            return new GoodsSetSet(this._parentGoodsMakerCd, this._parentGoodsMakerName, this._parentGoodsNo, this._displayOrder, this._subGoodsNo, this._goodsNameKana, this._subGoodsMakerCd, this._subGoodsMakerName, this._cntFl, this._setSpecialNote);
        }

        /// <summary>
        /// �Z�b�g�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsSetSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsSetSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsSetSet()
        {
        }

        /// <summary>
        /// �Z�b�g�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="ParentGoodsMakerCd"></param>
        /// <param name="ParentGoodsMakerName"></param>
        /// <param name="ParentGoodsNo"></param>
        /// <param name="DisplayOrder"></param>
        /// <param name="SubGoodsNo"></param>
        /// <param name="GoodsNameKana"></param>
        /// <param name="SubGoodsMakerCd"></param>
        /// <param name="SubGoodsMakerName"></param>
        /// <param name="CntFl"></param>
        /// <param name="SetSpecialNote"></param>
        public GoodsSetSet(Int32 ParentGoodsMakerCd, string ParentGoodsMakerName, string ParentGoodsNo, Int32 DisplayOrder, string SubGoodsNo, string GoodsNameKana, Int32 SubGoodsMakerCd, string SubGoodsMakerName, Double CntFl, string SetSpecialNote)
        {
            this._parentGoodsMakerCd = ParentGoodsMakerCd;
            this._parentGoodsMakerName = ParentGoodsMakerName;
            this._parentGoodsNo = ParentGoodsNo;
            this._displayOrder = DisplayOrder;
            this._subGoodsNo = SubGoodsNo;
            this._goodsNameKana = GoodsNameKana;
            this._subGoodsMakerCd = SubGoodsMakerCd;
            this._subGoodsMakerName = SubGoodsMakerName;
            this._cntFl = CntFl;
            this._setSpecialNote = SetSpecialNote;
        }
    }
}
