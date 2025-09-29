using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   UserGdBuyDivUProcParamWork
    /// <summary>
    ///                      ���[�U�[�K�C�h�}�X�^(�̔��敪)���o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[�U�[�K�C�h�}�X�^(�̔��敪)���o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/05/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APUserGdBuyDivUProcParamWork
    {
        /// <summary>�J�n����</summary>
        private Int64 _beginningDate;

        /// <summary>�I������</summary>
        private Int64 _endingDate;

        /// <summary>�K�C�h�R�[�h(�J�n)</summary>
        private Int32 _guideCodeBegin;

        /// <summary>�K�C�h�R�[�h(�I��)</summary>
        private Int32 _guideCodeEnd;


        /// public propaty name  :  BeginningDate
        /// <summary>�J�n�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UpdateDateTimeBegin
        {
            get { return _beginningDate; }
            set { _beginningDate = value; }
        }

        /// public propaty name  :  EndingDate
        /// <summary>�I�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UpdateDateTimeEnd
        {
            get { return _endingDate; }
            set { _endingDate = value; }
        }

        /// public propaty name  :  GuideCodeBegin
        /// <summary>�K�C�h�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�C�h�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GuideCodeBeginRF
        {
            get { return _guideCodeBegin; }
            set { _guideCodeBegin = value; }
        }

        /// public propaty name  :  GuideCodeEnd
        /// <summary>�K�C�h�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�C�h�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GuideCodeEndRF
        {
            get { return _guideCodeEnd; }
            set { _guideCodeEnd = value; }
        }


        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^(�̔��敪)���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>UserGdBuyDivUProcParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UserGdBuyDivUProcParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public APUserGdBuyDivUProcParamWork()
        {
        }

    }
}