using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
	#region EventHandler
	/// <summary>���i���ύX�f���Q�[�g</summary>
	public delegate void ChangedGoodsDataEventHandler(object seder, GoodsAcsEventArgs e);
	#endregion

	//================================================================================
	//  ���i�A�N�Z�X�N���X�Ŏg�p����C�x���g����
	//================================================================================
	#region EventArgs
	/// <summary>
	/// ���i�A�N�Z�X�N���X�C�x���g����
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���i�A�N�Z�X�N���X�̃C�x���g�����N���X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.05.10</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.08.30</br>
    /// <br>           :�EDC.NS�Ή�</br>
    /// </remarks>
	public class GoodsAcsEventArgs: EventArgs
	{
		/// <summary>�Ώۃf�[�^</summary>
		private object _objData;

		/// <summary>�G���[���b�Z�[�W</summary>
		string _message;
		
		/// <summary>
		/// ���i�A�N�Z�X�N���X�C�x���g�����̃R���X�g���N�^
		/// </summary>
		public GoodsAcsEventArgs(object dst): base()
		{
			this._message = "";
			this._objData = dst;
		}

		/// <summary>
		/// �Ώۃf�[�^
		/// </summary>
		public object Data
		{
			get { return this._objData; }
		}

		/// <summary>
		/// �G���[���b�Z�[�W
		/// </summary>
		public string Message
		{
			get { return this._message; } 
		}
	}
	#endregion

}
