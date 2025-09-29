using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �R���{�A�C�e���N���X
	/// </summary>
	/// <typeparam name="T">�R���{�A�C�e���̒l�̌^���w�肵�܂��B</typeparam>
	/// <remarks>
	/// <br>Note       : �R���{�{�b�N�X�Ɋi�[����l�Ɩ��̂̑g�ݍ��킹���`���܂��B</br>
	/// <br>Programmer : 23001 �H�R�@����</br>
	/// <br>Date       : 2007.03.26</br>
	/// </remarks>
	internal class ComboItem<T>
	{
		#region << Constructor >>

		/// <summary>
		/// �R���{�A�C�e���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �R���{�A�C�e���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public ComboItem()
		{
		}

		/// <summary>
		/// �R���{�A�C�e���N���X�R���X�g���N�^
		/// </summary>
		/// <param name="value">�l</param>
		/// <remarks>
		/// <br>Note       : �R���{�A�C�e���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public ComboItem( T value ) : this( value, "" )
		{
		}

		/// <summary>
		/// �R���{�A�C�e���N���X�R���X�g���N�^
		/// </summary>
		/// <param name="value">�l</param>
		/// <param name="name">����</param>
		/// <remarks>
		/// <br>Note       : �R���{�A�C�e���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public ComboItem( T value, string name )
		{
			this._value = value;
			this._name  = name;
		}

		#endregion

		#region << Private Members >>

		/// <summary>�l</summary>
		private T      _value;
		/// <summary>����</summary>
		private string _name = "";

		#endregion

		#region << Public Properties >>

		/// <summary>
		/// �l�v���p�e�B
		/// </summary>
		public T Value
		{
			get {
				return this._value;
			}
			set {
				this._value = value;
			}
		}

		/// <summary>
		/// ���̃v���p�e�B
		/// </summary>
		public string Name
		{
			get {
				return this._name;
			}
			set {
				this._name = value;
			}
		}

		#endregion

		#region << Public Methods >>

		/// <summary>
		/// ComboItem �N���X�� String �^�ɕϊ����܂��B
		/// </summary>
		/// <returns>String �^�I�u�W�F�N�g</returns>
		public override string ToString()
		{
			return this._name ?? String.Empty;
		}

		/// <summary>
		/// �w�肵�� System.Object ���A���݂� System.Object �Ɠ��������ǂ����𔻒f���܂��B
		/// </summary>
		/// <param name="obj">���݂� System.Object �Ɣ�r���� System.Object�B</param>
		/// <returns></returns>
		public override bool Equals( object obj )
		{
			bool equals = false;

			ComboItem<T> comboItem = obj as ComboItem<T>;

			if( comboItem != null ) {
				equals = ( this.Value.Equals( comboItem.Value ) );
			}

			return equals;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#endregion
	}
}
