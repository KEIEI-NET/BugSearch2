using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   BLGoodsCdSet
    /// <summary>
    ///                      BL�R�[�h�}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   BL�R�[�h�}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class BLGoodsCdSet 
    {
        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���i�敪�ڍ�</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL�O���[�v�R�[�h�J�i����</summary>
        private string _bLGroupKanaName = "";

        /// <summary>���i�|���O���[�v�R�[�h</summary>
        private Int32 _goodsRateGrpCode;

        /// <summary>���i�|���O���[�v�R�[�h��</summary>
        private string _goodsRateGrpCodeName = "";

        /// <summary>BL���i����</summary>
        private Int32 _bLGoodsGenreCode;

        /// <summary>BL���i���ޖ�</summary>
        private string _bLGoodsGenreCodeName = "";


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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
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

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���i�敪�ڍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGroupKanaName
        /// <summary>BL�O���[�v�R�[�h�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupKanaName
        {
            get { return _bLGroupKanaName; }
            set { _bLGroupKanaName = value; }
        }

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>���i�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public propaty name  :  GoodsRateGrpCodeName
        /// <summary>���i�|���O���[�v�R�[�h���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v�R�[�h���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateGrpCodeName
        {
            get { return _goodsRateGrpCodeName; }
            set { _goodsRateGrpCodeName = value; }
        }

        /// public propaty name  :  BLGoodsGenreCode
        /// <summary>BL���i���ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i���ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsGenreCode
        {
            get { return _bLGoodsGenreCode; }
            set { _bLGoodsGenreCode = value; }
        }

        /// public propaty name  :  BLGoodsGenreCodeName
        /// <summary>BL���i���ޖ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i���ޖ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsGenreCodeName
        {
            get { return _bLGoodsGenreCodeName; }
            set { _bLGoodsGenreCodeName = value; }
        }

        /// <summary>
        /// BL�R�[�h�i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BLGoodsCdSet Clone()
        {
            return new BLGoodsCdSet(this._bLGoodsCode,this._bLGoodsFullName,this._bLGoodsHalfName,this._bLGroupCode,this._bLGroupKanaName,this._goodsRateGrpCode,this._goodsRateGrpCodeName,this._bLGoodsGenreCode,this._bLGoodsGenreCodeName);

        }

        /// <summary>
		/// BL�R�[�h�i����j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
        /// <returns>BLGoodsCdSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public BLGoodsCdSet()
		{
		}

        /// <summary>
        /// BL�R�[�h�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="BLGoodsCode"></param>
        /// <param name="BLGoodsFullName"></param>
        /// <param name="BLGoodsHalfName"></param>
        /// <param name="BLGroupCode"></param>
        /// <param name="BLGroupKanaName"></param>
        /// <param name="GoodsRateGrpCode"></param>
        /// <param name="GoodsRateGrpCodeName"></param>
        /// <param name="BLGoodsGenreCode"></param>
        /// <param name="BLGoodsGenreCodeName"></param>
        public BLGoodsCdSet(Int32 BLGoodsCode,string BLGoodsFullName,string BLGoodsHalfName,Int32 BLGroupCode,string BLGroupKanaName,Int32 GoodsRateGrpCode,string GoodsRateGrpCodeName,Int32 BLGoodsGenreCode,string BLGoodsGenreCodeName)
        {
            this._bLGoodsCode = BLGoodsCode;
            this._bLGoodsFullName = BLGoodsFullName;
            this._bLGoodsHalfName = BLGoodsHalfName;
            this._bLGroupCode = BLGroupCode;
            this._bLGroupKanaName = BLGroupKanaName;
            this._goodsRateGrpCode = GoodsRateGrpCode;
            this._goodsRateGrpCodeName = GoodsRateGrpCodeName;
            this._bLGoodsGenreCode = BLGoodsGenreCode;
            this._bLGoodsGenreCodeName = BLGoodsGenreCodeName;
        }
    }
}
