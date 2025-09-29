using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PartsSubstSet
    /// <summary>
    ///                      ��փ}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ��փ}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class PartsSubstSet
    {
        /// <summary>�ϊ������[�J�[�R�[�h</summary>
        private Int32 _chgSrcMakerCd;

        /// <summary>�ϊ������[�J�[��</summary>
        private string _chgSrcMakerName = "";

        /// <summary>�ϊ������i�ԍ�</summary>
        private string _chgSrcGoodsNo = "";

        /// <summary>�ϊ��惁�[�J�[�R�[�h</summary>
        private Int32 _chgDestMakerCd;

        /// <summary>�ϊ��惁�[�J�[��</summary>
        private string _chgDestMakerName = "";

        /// <summary>�ϊ��揤�i�ԍ�</summary>
        private string _chgDestGoodsNo = "";

        /// <summary>�K�p�J�n��</summary>
        private DateTime _applyStaDate;

        /// <summary>�K�p�I����</summary>
        private DateTime _applyEndDate;


        /// public propaty name  :  ChgSrcMakerCd
        /// <summary>�ϊ������[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ������[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChgSrcMakerCd
        {
            get { return _chgSrcMakerCd; }
            set { _chgSrcMakerCd = value; }
        }

        /// public propaty name  :  ChgSrcMakerName
        /// <summary>�ϊ������[�J�[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ������[�J�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgSrcMakerName
        {
            get { return _chgSrcMakerName; }
            set { _chgSrcMakerName = value; }
        }

        /// public propaty name  :  ChgSrcGoodsNo
        /// <summary>�ϊ������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgSrcGoodsNo
        {
            get { return _chgSrcGoodsNo; }
            set { _chgSrcGoodsNo = value; }
        }

        /// public propaty name  :  ChgDestMakerCd
        /// <summary>�ϊ��惁�[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ��惁�[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChgDestMakerCd
        {
            get { return _chgDestMakerCd; }
            set { _chgDestMakerCd = value; }
        }

        /// public propaty name  :  ChgDestMakerName
        /// <summary>�ϊ��惁�[�J�[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ��惁�[�J�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgDestMakerName
        {
            get { return _chgDestMakerName; }
            set { _chgDestMakerName = value; }
        }

        /// public propaty name  :  ChgDestGoodsNo
        /// <summary>�ϊ��揤�i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ��揤�i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgDestGoodsNo
        {
            get { return _chgDestGoodsNo; }
            set { _chgDestGoodsNo = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>�K�p�J�n���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>�K�p�I�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

        /// <summary>
        /// ��ցi����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsSubstSet Clone()
        {
            return new PartsSubstSet(this._chgSrcMakerCd, this._chgSrcMakerName, this._chgSrcGoodsNo, this._chgDestMakerCd, this._chgDestMakerName, this._chgDestGoodsNo, this._applyStaDate, this._applyEndDate);
        }

        /// <summary>
        /// ��ցi����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PartsSubstSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsSubstSet()
        {
        }

        /// <summary>
        /// ��ցi����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="ChgSrcMakerCd"></param>
        /// <param name="ChgSrcMakerName"></param>
        /// <param name="ChgSrcGoodsNo"></param>
        /// <param name="ChgDestMakerCd"></param>
        /// <param name="ChgDestMakerName"></param>
        /// <param name="ChgDestGoodsNo"></param>
        /// <param name="ApplyStaDate"></param>
        /// <param name="ApplyEndDate"></param>
        public PartsSubstSet(Int32 ChgSrcMakerCd, string ChgSrcMakerName, string ChgSrcGoodsNo, Int32 ChgDestMakerCd, string ChgDestMakerName, string ChgDestGoodsNo, DateTime ApplyStaDate, DateTime ApplyEndDate)
        {
            this._chgSrcMakerCd = ChgSrcMakerCd;
            this._chgSrcMakerName = ChgSrcMakerName;
            this._chgSrcGoodsNo = ChgSrcGoodsNo;
            this._chgDestMakerCd = ChgDestMakerCd;
            this._chgDestMakerName = ChgDestMakerName;
            this._chgDestGoodsNo = ChgDestGoodsNo;
            this._applyStaDate = ApplyStaDate;
            this._applyEndDate = ApplyEndDate;
        }
    }
}
