//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �����}�X�^�̴���߰ď������s��
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
    /// public class name:   JoinPartsSetExp
    /// <summary>
    ///                      �����}�X�^�i�G�N�X�|�[�g�j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����}�X�^�i�G�N�X�|�[�g�j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class JoinPartsSetExp
    {
        /// <summary>���������[�J�[�R�[�h</summary>
        private Int32 _joinSourceMakerCode;

        /// <summary>���������[�J�[��</summary>
        private string _joinSourceMakerName = "";

        /// <summary>�������i��(�|�t���i��)</summary>
        private string _joinSourPartsNoWithH = "";

        /// <summary>�������i��(�|�����i��)</summary>
        private string _joinSourPartsNoNoneH = "";

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

        /// <summary>�����K�i�E���L����</summary>
        private string _joinSpecialNote = "";


        /// public propaty name  :  JoinSourceMakerCode
        /// <summary>���������[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinSourceMakerCode
        {
            get { return _joinSourceMakerCode; }
            set { _joinSourceMakerCode = value; }
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
            get { return _joinSourceMakerName; }
            set { _joinSourceMakerName = value; }
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
            get { return _joinSourPartsNoWithH; }
            set { _joinSourPartsNoWithH = value; }
        }

        /// public propaty name  :  JoinSourPartsNoNoneH
        /// <summary>�������i��(�|�����i��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i��(�|�����i��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinSourPartsNoNoneH
        {
            get { return _joinSourPartsNoNoneH; }
            set { _joinSourPartsNoNoneH = value; }
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
            get { return _joinDispOrder; }
            set { _joinDispOrder = value; }
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
            get { return _joinDestPartsNo; }
            set { _joinDestPartsNo = value; }
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
            get { return _joinDestMakerCd; }
            set { _joinDestMakerCd = value; }
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
            get { return _joinDestMakerName; }
            set { _joinDestMakerName = value; }
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
            get { return _joinQty; }
            set { _joinQty = value; }
        }

        /// public propaty name  :  JoinSpecialNote
        /// <summary>�����K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinSpecialNote
        {
            get { return _joinSpecialNote; }
            set { _joinSpecialNote = value; }
        }

        /// <summary>
        /// �����i�G�N�X�|�[�g�j�f�[�^�N���X��������
        /// </summary>
        /// <returns>JoinPartsSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public JoinPartsSetExp Clone()
        {
            return new JoinPartsSetExp(this._joinSourceMakerCode, this._joinSourceMakerName, this._joinSourPartsNoWithH, this.JoinSourPartsNoNoneH, this._goodsNameKana, this._joinDispOrder, this._joinDestPartsNo, this._joinDestMakerCd, this._joinDestMakerName, this._joinQty, this._joinSpecialNote);
        }

        /// <summary>
        /// �����i�G�N�X�|�[�g�j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>JoinPartsSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public JoinPartsSetExp()
        {
        }

        /// <summary>
        /// �����i�G�N�X�|�[�g�j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="JoinSourceMakerCode"></param>
        /// <param name="JoinSourceMakerName"></param>
        /// <param name="JoinSourPartsNoWithH"></param>
        /// <param name="JoinSourPartsNoNoneH"></param>
        /// <param name="GoodsNameKana"></param>
        /// <param name="JoinDispOrder"></param>
        /// <param name="JoinDestPartsNo"></param>
        /// <param name="JoinDestMakerCd"></param>
        /// <param name="JoinDestMakerName"></param>
        /// <param name="JoinQtystring"></param>
        /// <param name="JoinSpecialNote"></param>
        public JoinPartsSetExp(Int32 JoinSourceMakerCode, string JoinSourceMakerName, string JoinSourPartsNoWithH, string JoinSourPartsNoNoneH, string GoodsNameKana, Int32 JoinDispOrder, string JoinDestPartsNo, Int32 JoinDestMakerCd, string JoinDestMakerName, Double JoinQtystring, string JoinSpecialNote)
        {
            this._joinSourceMakerCode = JoinSourceMakerCode;
            this._joinSourceMakerName = JoinSourceMakerName;
            this._joinSourPartsNoWithH = JoinSourPartsNoWithH;
            this._joinSourPartsNoNoneH = JoinSourPartsNoNoneH;
            this._goodsNameKana = GoodsNameKana;
            this._joinDispOrder = JoinDispOrder;
            this._joinDestPartsNo = JoinDestPartsNo;
            this._joinDestMakerCd = JoinDestMakerCd;
            this._joinDestMakerName = JoinDestMakerName;
            this._joinQty = JoinQty;
            this._joinSpecialNote = JoinSpecialNote;
        }
    }
}
