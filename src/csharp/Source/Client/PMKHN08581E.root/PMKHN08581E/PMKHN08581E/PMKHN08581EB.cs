using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MakerSet
    /// <summary>
    ///                      ���[�J�[�}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[�J�[�}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class MakerSet 
    {
        /// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>���[�J�[����</summary>
		private string _makerName = "";

		/// <summary>���[�J�[����</summary>
		private string _makerShortName = "";

		/// <summary>���[�J�[�J�i����</summary>
		private string _makerKanaName = "";

		/// <summary>�\������</summary>
		private Int32 _displayOrder;


        /// public propaty name  :  GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  MakerName
		/// <summary>���[�J�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MakerName
		{
			get{return _makerName;}
			set{_makerName = value;}
		}

		/// public propaty name  :  MakerShortName
		/// <summary>���[�J�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MakerShortName
		{
			get{return _makerShortName;}
			set{_makerShortName = value;}
		}

		/// public propaty name  :  MakerKanaName
		/// <summary>���[�J�[�J�i���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�J�i���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MakerKanaName
		{
			get{return _makerKanaName;}
			set{_makerKanaName = value;}
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
			get{return _displayOrder;}
			set{_displayOrder = value;}
		}

        /// <summary>
        /// ���[�J�[�i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MakerSet Clone()
        {
            return new MakerSet(this._goodsMakerCd,this._makerName,this._makerShortName,this._makerKanaName,this._displayOrder);

        }

        /// <summary>
		/// ���[�J�[�i����j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>EmployeeSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public MakerSet()
		{
		}
        
        /// <summary>
        /// ���[�J�[�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="GoodsMakerCd"></param>
        /// <param name="MakerName"></param>
        /// <param name="MakerShortName"></param>
        /// <param name="MakerKanaName"></param>
        /// <param name="DisplayOrder"></param>
        public MakerSet(Int32 GoodsMakerCd, string MakerName, string MakerShortName, string MakerKanaName, Int32 DisplayOrder)
        {

            this._goodsMakerCd = GoodsMakerCd;
            this._makerName = MakerName;
            this._makerShortName = MakerShortName;
            this._makerKanaName = MakerKanaName;
            this._displayOrder = DisplayOrder;
        }
    }
}
