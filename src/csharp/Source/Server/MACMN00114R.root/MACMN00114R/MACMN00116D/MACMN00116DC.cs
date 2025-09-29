using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OprationLogOrderWorkWork
    /// <summary>
    ///                      ���엚�����O���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���엚�����O���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OprationLogOrderWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string[] _sectionCodes;

        /// <summary>���O�f�[�^�[����</summary>
        private string _logDataMachineName = "";

        /// <summary>������R�[�h</summary>
        /// <remarks>���O�ɏ������ތ����ƂȂ����N���XID�@(UOE������R�[�h)</remarks>
        private string _logDataObjClassID = "";

        /// <summary>�J�n���O�f�[�^�쐬����</summary>
        private DateTime _st_LogDataCreateDateTime;

        /// <summary>�I�����O�f�[�^�쐬����</summary>
        private DateTime _ed_LogDataCreateDateTime;

        /// <summary>���O�f�[�^��ʋ敪�R�[�h</summary>
        /// <remarks>0:�L�^,1:�G���[,9:�V�X�e��,10:UOE(DSP) 11:UOE(�ʐM)</remarks>
        private Int32 _logDataKindCd;


        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  LogDataMachineName
        /// <summary>���O�f�[�^�[�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataMachineName
        {
            get { return _logDataMachineName; }
            set { _logDataMachineName = value; }
        }

        /// public propaty name  :  LogDataObjClassID
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// <value>���O�ɏ������ތ����ƂȂ����N���XID�@(UOE������R�[�h)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataObjClassID
        {
            get { return _logDataObjClassID; }
            set { _logDataObjClassID = value; }
        }

        /// public propaty name  :  St_LogDataCreateDateTime
        /// <summary>�J�n���O�f�[�^�쐬�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���O�f�[�^�쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_LogDataCreateDateTime
        {
            get { return _st_LogDataCreateDateTime; }
            set { _st_LogDataCreateDateTime = value; }
        }

        /// public propaty name  :  Ed_LogDataCreateDateTime
        /// <summary>�I�����O�f�[�^�쐬�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����O�f�[�^�쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_LogDataCreateDateTime
        {
            get { return _ed_LogDataCreateDateTime; }
            set { _ed_LogDataCreateDateTime = value; }
        }

        /// public propaty name  :  LogDataKindCd
        /// <summary>���O�f�[�^��ʋ敪�R�[�h�v���p�e�B</summary>
        /// <value>0:�L�^,1:�G���[,9:�V�X�e��,10:UOE(DSP) 11:UOE(�ʐM)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^��ʋ敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogDataKindCd
        {
            get { return _logDataKindCd; }
            set { _logDataKindCd = value; }
        }


        /// <summary>
        /// ���엚�����O���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>OprationLogOrderWorkWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OprationLogOrderWorkWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OprationLogOrderWork()
        {
        }

    }
}
