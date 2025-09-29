//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �s�a�n�����}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �s�a�n�����}�X�^�̴���߰ď������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   TBOSearchSetExp
    /// <summary>
    ///                      TBO�����}�X�^�i���[�U�[�o�^�j
    /// </summary>
    /// <remarks>
    /// <br>note             :   TBO�����}�X�^�i���[�U�[�o�^�j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2006/12/6</br>
    /// <br>Genarated Date   :   2009/05/14  (CSharp File Generated Date)</br>
    /// </remarks>
    public class TBOSearchSetExp 
    {
		/// <summary>BL���i�R�[�h</summary>
		/// <remarks>��:1�`9999 ���[�U�[:10000�`</remarks>
		private Int32 _bLGoodsCode;

		/// <summary>��������</summary>
		/// <remarks>��j1001�F�o�b�e��</remarks>
		private Int32 _equipGenreCode;

		/// <summary>��������</summary>
		/// <remarks>��j100D26L�i�o�b�e���K�i�j</remarks>
		private string _equipName = "";

		/// <summary>�ԗ������\������</summary>
		/// <remarks>4,5,6,7,8������̌������������݂���ꍇ�̘A��</remarks>
		private Int32 _carInfoJoinDispOrder;

		/// <summary>�����惁�[�J�[�R�[�h</summary>
		private Int32 _joinDestMakerCd;

		/// <summary>������i��(�|�t���i��)</summary>
		/// <remarks>�n�C�t���t��</remarks>
		private string _joinDestPartsNo = "";

		/// <summary>�����p�s�x</summary>
		private Double _joinQty;

		/// <summary>�����K�i�E���L����</summary>
		private string _equipSpecialNote = "";

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL���i�R�[�h�v���p�e�B</summary>
		/// <value>��:1�`9999 ���[�U�[:10000�`</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  EquipGenreCode
		/// <summary>�������ރv���p�e�B</summary>
		/// <value>��j1001�F�o�b�e��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ރv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EquipGenreCode
		{
			get{return _equipGenreCode;}
			set{_equipGenreCode = value;}
		}

		/// public propaty name  :  EquipName
		/// <summary>�������̃v���p�e�B</summary>
		/// <value>��j100D26L�i�o�b�e���K�i�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EquipName
		{
			get{return _equipName;}
			set{_equipName = value;}
		}

		/// public propaty name  :  CarInfoJoinDispOrder
		/// <summary>�ԗ������\�����ʃv���p�e�B</summary>
		/// <value>4,5,6,7,8������̌������������݂���ꍇ�̘A��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ������\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CarInfoJoinDispOrder
		{
			get{return _carInfoJoinDispOrder;}
			set{_carInfoJoinDispOrder = value;}
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

		/// public propaty name  :  JoinDestPartsNo
		/// <summary>������i��(�|�t���i��)�v���p�e�B</summary>
		/// <value>�n�C�t���t��</value>
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

		/// public propaty name  :  JoinQty
		/// <summary>�����p�s�x�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����p�s�x�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double JoinQty
		{
			get{return _joinQty;}
			set{_joinQty = value;}
		}

		/// public propaty name  :  EquipSpecialNote
		/// <summary>�����K�i�E���L�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����K�i�E���L�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EquipSpecialNote
		{
			get{return _equipSpecialNote;}
			set{_equipSpecialNote = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>��Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  UpdEmployeeName
		/// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}

		/// <summary>
		/// TBO�����}�X�^�i���[�U�[�o�^�j�R���X�g���N�^
		/// </summary>
		/// <param name="bLGoodsCode">BL���i�R�[�h(��:1�`9999 ���[�U�[:10000�`)</param>
		/// <param name="equipGenreCode">��������(��j1001�F�o�b�e��)</param>
		/// <param name="equipName">��������(��j100D26L�i�o�b�e���K�i�j)</param>
		/// <param name="carInfoJoinDispOrder">�ԗ������\������(4,5,6,7,8������̌������������݂���ꍇ�̘A��)</param>
		/// <param name="joinDestMakerCd">�����惁�[�J�[�R�[�h</param>
		/// <param name="joinDestPartsNo">������i��(�|�t���i��)(�n�C�t���t��)</param>
		/// <param name="joinQty">�����p�s�x</param>
		/// <param name="equipSpecialNote">�����K�i�E���L����</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>TBOSearchU�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TBOSearchU�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public TBOSearchSetExp(Int32 bLGoodsCode,Int32 equipGenreCode,string equipName,Int32 carInfoJoinDispOrder,Int32 joinDestMakerCd,string joinDestPartsNo,Double joinQty,string equipSpecialNote,string enterpriseName,string updEmployeeName)
		{
			this._bLGoodsCode = bLGoodsCode;
			this._equipGenreCode = equipGenreCode;
			this._equipName = equipName;
			this._carInfoJoinDispOrder = carInfoJoinDispOrder;
			this._joinDestMakerCd = joinDestMakerCd;
			this._joinDestPartsNo = joinDestPartsNo;
			this._joinQty = joinQty;
			this._equipSpecialNote = equipSpecialNote;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// TBO�����}�X�^�i���[�U�[�o�^�j��������
		/// </summary>
		/// <returns>TBOSearchU�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����TBOSearchU�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public TBOSearchSetExp Clone()
		{
			return new TBOSearchSetExp(this._bLGoodsCode,this._equipGenreCode,this._equipName,this._carInfoJoinDispOrder,this._joinDestMakerCd,this._joinDestPartsNo,this._joinQty,this._equipSpecialNote,this._enterpriseName,this._updEmployeeName);
		}

        /// <summary>
        /// TBO�����}�X�^�i���[�U�[�o�^�j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
        /// <returns>TBOSearchSetExp�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public TBOSearchSetExp()
		{
		}
    }
}
