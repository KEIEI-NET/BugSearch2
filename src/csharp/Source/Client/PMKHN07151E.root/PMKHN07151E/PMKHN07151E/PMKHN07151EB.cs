//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : BL�O���[�v�}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : BL�O���[�v�}�X�^�̴���߰ď������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   BLGroupSetExp
    /// <summary>
    ///                      �O���[�v�R�[�h�}�X�^�i�G�N�X�|�[�g)���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �O���[�v�R�[�h�}�X�^�i�G�N�X�|�[�g)���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class BLGroupSetExp
    {
        /// <summary>BL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;

        /// <summary>BL�O���[�v�R�[�h����</summary>
        private string _bLGroupName = "";

        /// <summary>BL�O���[�v�R�[�h�J�i����</summary>
        private string _bLGroupKanaName = "";

        /// <summary>�̔��敪�R�[�h</summary>
        private Int32 _salesCode;

        /// <summary>�̔��敪��</summary>
        private string _salesCodeName = "";

        /// <summary>���i�啪�ރR�[�h</summary>
        private Int32 _goodsLGroup;

        /// <summary>���i�啪�ޖ�</summary>
        private string _goodsLGroupName = "";

        /// <summary>���i�����ރR�[�h</summary>
        private Int32 _goodsMGroup;

        /// <summary>���i�����ޖ�</summary>
        private string _goodsMGroupName = "";


        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  BLGroupName
        /// <summary>BL�O���[�v�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
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

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  SalesCodeName
        /// <summary>�̔��敪���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesCodeName
        {
            get { return _salesCodeName; }
            set { _salesCodeName = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>���i�啪�ޖ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ޖ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>���i�����ޖ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ޖ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// <summary>
        /// �a�k�O���[�v�i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BLGroupSetExp Clone()
        {
            return new BLGroupSetExp(this._bLGroupCode, this._bLGroupName, this._bLGroupKanaName, this._salesCode, this._salesCodeName, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName);

        }

        /// <summary>
        /// �a�k�O���[�v�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>EmployeeSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BLGroupSetExp()
        {
        }

        /// <summary>
        /// �a�k�O���[�v�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="BLGroupCode"></param>
        /// <param name="BLGroupName"></param>
        /// <param name="BLGroupKanaName"></param>
        /// <param name="SalesCode"></param>
        /// <param name="SalesCodeName"></param>
        /// <param name="GoodsLGroup"></param>
        /// <param name="GoodsLGroupName"></param>
        /// <param name="GoodsMGroup"></param>
        /// <param name="GoodsMGroupName"></param>
        public BLGroupSetExp(Int32 BLGroupCode, string BLGroupName, string BLGroupKanaName, Int32 SalesCode, string SalesCodeName, Int32 GoodsLGroup, string GoodsLGroupName, Int32 GoodsMGroup, string GoodsMGroupName)
        {
            this._bLGroupCode = BLGroupCode;
            this._bLGroupName = BLGroupName;
            this._bLGroupKanaName = BLGroupKanaName;
            this._salesCode = SalesCode;
            this._salesCodeName = SalesCodeName;
            this._goodsLGroup = GoodsLGroup;
            this._goodsLGroupName = GoodsLGroupName;
            this._goodsMGroup = GoodsMGroup;
            this._goodsMGroupName = GoodsMGroupName;

        }
    }
}
