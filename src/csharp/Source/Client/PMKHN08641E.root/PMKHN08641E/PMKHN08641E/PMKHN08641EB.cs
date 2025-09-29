using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   JoinPartsSet
    /// <summary>
    ///                      �����}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class JoinPartsSet 
    {
        /// <summary>���������[�J�[�R�[�h</summary>
		private Int32 _joinSourceMakerCode;

		/// <summary>���������[�J�[��</summary>
		private string _joinSourceMakerName = "";

		/// <summary>�������i��(�|�t���i��)</summary>
		private string _joinSourPartsNoWithH = "";

		/// <summary>���i���̃J�i</summary>
		private string _goodsNameKana = "";

		/// <summary>�����\������</summary>
		/// <remarks>���[�U�[�o�^���̕\�����ʁi�񋟂��K����ɂȂ�j</remarks>
		private Int32 _joinDispOrder;

		/// <summary>������i��(�|�t���i��)</summary>
		private string _joinDestPartsNo = "";

		/// <summary>�����惁�[�J�[�R�[�h</summary>
		private Int32 _joinDestMakerCd;

		/// <summary>�����惁�[�J�[��</summary>
		private string _joinDestMakerName = "";

		/// <summary>����QTY</summary>
		private Double _joinQty;


		/// public propaty name  :  JoinSourceMakerCode
		/// <summary>���������[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 JoinSourceMakerCode
		{
			get{return _joinSourceMakerCode;}
			set{_joinSourceMakerCode = value;}
		}

		/// public propaty name  :  JoinSourceMakerName
		/// <summary>���������[�J�[���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������[�J�[���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string JoinSourceMakerName
		{
			get{return _joinSourceMakerName;}
			set{_joinSourceMakerName = value;}
		}

		/// public propaty name  :  JoinSourPartsNoWithH
		/// <summary>�������i��(�|�t���i��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������i��(�|�t���i��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string JoinSourPartsNoWithH
		{
			get{return _joinSourPartsNoWithH;}
			set{_joinSourPartsNoWithH = value;}
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
			get{return _goodsNameKana;}
			set{_goodsNameKana = value;}
		}

		/// public propaty name  :  JoinDispOrder
		/// <summary>�����\�����ʃv���p�e�B</summary>
		/// <value>���[�U�[�o�^���̕\�����ʁi�񋟂��K����ɂȂ�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 JoinDispOrder
		{
			get{return _joinDispOrder;}
			set{_joinDispOrder = value;}
		}

		/// public propaty name  :  JoinDestPartsNo
		/// <summary>������i��(�|�t���i��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������i��(�|�t���i��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string JoinDestPartsNo
		{
			get{return _joinDestPartsNo;}
			set{_joinDestPartsNo = value;}
		}

		/// public propaty name  :  JoinDestMakerCd
		/// <summary>�����惁�[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����惁�[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 JoinDestMakerCd
		{
			get{return _joinDestMakerCd;}
			set{_joinDestMakerCd = value;}
		}

		/// public propaty name  :  JoinDestMakerName
		/// <summary>�����惁�[�J�[���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����惁�[�J�[���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string JoinDestMakerName
		{
			get{return _joinDestMakerName;}
			set{_joinDestMakerName = value;}
		}

		/// public propaty name  :  JoinQty
		/// <summary>����QTY�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����QTY�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double JoinQty
		{
			get{return _joinQty;}
			set{_joinQty = value;}
		}

        /// <summary>
        /// �����i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>JoinPartsSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public JoinPartsSet Clone()
        {
            return new JoinPartsSet(this._joinSourceMakerCode, this._joinSourceMakerName, this._joinSourPartsNoWithH, this._goodsNameKana, this._joinDispOrder, this._joinDestPartsNo, this._joinDestMakerCd, this._joinDestMakerName, this._joinQty);
        }

        /// <summary>
		/// �����i����j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>JoinPartsSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public JoinPartsSet()
		{
		}

        /// <summary>
        /// �����i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="JoinSourceMakerCode"></param>
        /// <param name="JoinSourceMakerName"></param>
        /// <param name="JoinSourPartsNoWithH"></param>
        /// <param name="GoodsNameKana"></param>
        /// <param name="JoinDispOrder"></param>
        /// <param name="JoinDestPartsNo"></param>
        /// <param name="JoinDestMakerCd"></param>
        /// <param name="JoinDestMakerName"></param>
        /// <param name="JoinQty"></param>
        public JoinPartsSet(Int32 JoinSourceMakerCode, string JoinSourceMakerName, string JoinSourPartsNoWithH, string GoodsNameKana, Int32 JoinDispOrder, string JoinDestPartsNo, Int32 JoinDestMakerCd, string JoinDestMakerName, Double JoinQty)
        {
            this._joinSourceMakerCode = JoinSourceMakerCode;
            this._joinSourceMakerName = JoinSourceMakerName;
            this._joinSourPartsNoWithH = JoinSourPartsNoWithH;
            this._goodsNameKana = GoodsNameKana;
            this._joinDispOrder = JoinDispOrder;
            this._joinDestPartsNo = JoinDestPartsNo;
            this._joinDestMakerCd = JoinDestMakerCd;
            this._joinDestMakerName = JoinDestMakerName;
            this._joinQty = JoinQty;
        }
    }
}
