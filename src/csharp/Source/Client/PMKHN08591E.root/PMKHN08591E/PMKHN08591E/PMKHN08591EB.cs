using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsGroupSet
    /// <summary>
    ///                      ���i�����ރ}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�����ރ}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class GoodsGroupSet 
    {
        /// <summary>���i�����ރR�[�h</summary>
		private Int32 _goodsMGroup;

		/// <summary>���i�����ޖ���</summary>
		private string _goodsMGroupName = "";


		/// public propaty name  :  GoodsMGroup
		/// <summary>���i�����ރR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMGroup
		{
			get{return _goodsMGroup;}
			set{_goodsMGroup = value;}
		}

		/// public propaty name  :  GoodsMGroupName
		/// <summary>���i�����ޖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsMGroupName
		{
			get{return _goodsMGroupName;}
			set{_goodsMGroupName = value;}
		}

        /// <summary>
        /// ���i�����ށi����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsGroupSet Clone()
        {
            return new GoodsGroupSet(this._goodsMGroup, this._goodsMGroupName);
        }

        /// <summary>
		/// ���i�����ށi����j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>EmployeeSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public GoodsGroupSet()
		{
		}

        /// <summary>
        /// ���i�����ށi����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="GoodsMGroup"></param>
        /// <param name="GoodsMGroupName"></param>
        public GoodsGroupSet(Int32 GoodsMGroup, string GoodsMGroupName)
        {

            this._goodsMGroup = GoodsMGroup;
            this._goodsMGroupName = GoodsMGroupName;
        }
    }
}
