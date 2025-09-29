//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M��������N���X
// �v���O�����T�v   : �t�n�d���M��������̒�`
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UoeSndRcvCtlPara
    /// <summary>
    ///                      �t�n�d���M��������N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �t�n�d���M��������N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UoeSndRcvCtlPara
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�Ɩ��敪</summary>
        /// <remarks>1:���� 2:���� 3:�݌Ɋm�F</remarks>
        private Int32 _businessCode;

        /// <summary>�V�X�e���敪</summary>
        /// <remarks>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</remarks>
        private Int32 _systemDivCd;

        /// <summary>�����敪</summary>
        /// <remarks>0:�ʏ� 1:����</remarks>
        private Int32 _processDiv;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�Ɩ��敪����</summary>
        private string _businessName = "";


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

        /// public propaty name  :  BusinessCode
        /// <summary>�Ɩ��敪�v���p�e�B</summary>
        /// <value>1:���� 2:���� 3:�݌Ɋm�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɩ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessCode
        {
            get { return _businessCode; }
            set { _businessCode = value; }
        }

        /// public propaty name  :  SystemDivCd
        /// <summary>�V�X�e���敪�v���p�e�B</summary>
        /// <value>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�X�e���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
        }

        /// public propaty name  :  ProcessDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�ʏ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcessDiv
        {
            get { return _processDiv; }
            set { _processDiv = value; }
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
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  BusinessName
        /// <summary>�Ɩ��敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɩ��敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessName
        {
            get { return _businessName; }
            set { _businessName = value; }
        }


        /// <summary>
        /// �t�n�d���M��������N���X�R���X�g���N�^
        /// </summary>
        /// <returns>UoeSndRcvCtlPara�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UoeSndRcvCtlPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UoeSndRcvCtlPara()
        {
        }

        /// <summary>
        /// �t�n�d���M��������N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="businessCode">�Ɩ��敪(1:���� 2:���� 3:�݌Ɋm�F)</param>
        /// <param name="systemDivCd">�V�X�e���敪(0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[)</param>
        /// <param name="processDiv">�����敪(0:�ʏ� 1:����)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="businessName">�Ɩ��敪����</param>
        /// <returns>UoeSndRcvCtlPara�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UoeSndRcvCtlPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UoeSndRcvCtlPara(string enterpriseCode, Int32 businessCode, Int32 systemDivCd, Int32 processDiv, string enterpriseName, string businessName)
        {
            this._enterpriseCode = enterpriseCode;
            this._businessCode = businessCode;
            this._systemDivCd = systemDivCd;
            this._processDiv = processDiv;
            this._enterpriseName = enterpriseName;
            this._businessName = businessName;

        }

        /// <summary>
        /// �t�n�d���M��������N���X��������
        /// </summary>
        /// <returns>UoeSndRcvCtlPara�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����UoeSndRcvCtlPara�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UoeSndRcvCtlPara Clone()
        {
            return new UoeSndRcvCtlPara(this._enterpriseCode, this._businessCode, this._systemDivCd, this._processDiv, this._enterpriseName, this._businessName);
        }

        /// <summary>
        /// �t�n�d���M��������N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UoeSndRcvCtlPara�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UoeSndRcvCtlPara�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(UoeSndRcvCtlPara target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.BusinessCode == target.BusinessCode)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.ProcessDiv == target.ProcessDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.BusinessName == target.BusinessName));
        }

        /// <summary>
        /// �t�n�d���M��������N���X��r����
        /// </summary>
        /// <param name="uoeSndRcvCtlPara1">
        ///                    ��r����UoeSndRcvCtlPara�N���X�̃C���X�^���X
        /// </param>
        /// <param name="uoeSndRcvCtlPara2">��r����UoeSndRcvCtlPara�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UoeSndRcvCtlPara�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(UoeSndRcvCtlPara uoeSndRcvCtlPara1, UoeSndRcvCtlPara uoeSndRcvCtlPara2)
        {
            return ((uoeSndRcvCtlPara1.EnterpriseCode == uoeSndRcvCtlPara2.EnterpriseCode)
                 && (uoeSndRcvCtlPara1.BusinessCode == uoeSndRcvCtlPara2.BusinessCode)
                 && (uoeSndRcvCtlPara1.SystemDivCd == uoeSndRcvCtlPara2.SystemDivCd)
                 && (uoeSndRcvCtlPara1.ProcessDiv == uoeSndRcvCtlPara2.ProcessDiv)
                 && (uoeSndRcvCtlPara1.EnterpriseName == uoeSndRcvCtlPara2.EnterpriseName)
                 && (uoeSndRcvCtlPara1.BusinessName == uoeSndRcvCtlPara2.BusinessName));
        }
        /// <summary>
        /// �t�n�d���M��������N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UoeSndRcvCtlPara�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UoeSndRcvCtlPara�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(UoeSndRcvCtlPara target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.BusinessCode != target.BusinessCode) resList.Add("BusinessCode");
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.ProcessDiv != target.ProcessDiv) resList.Add("ProcessDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.BusinessName != target.BusinessName) resList.Add("BusinessName");

            return resList;
        }

        /// <summary>
        /// �t�n�d���M��������N���X��r����
        /// </summary>
        /// <param name="uoeSndRcvCtlPara1">��r����UoeSndRcvCtlPara�N���X�̃C���X�^���X</param>
        /// <param name="uoeSndRcvCtlPara2">��r����UoeSndRcvCtlPara�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UoeSndRcvCtlPara�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(UoeSndRcvCtlPara uoeSndRcvCtlPara1, UoeSndRcvCtlPara uoeSndRcvCtlPara2)
        {
            ArrayList resList = new ArrayList();
            if (uoeSndRcvCtlPara1.EnterpriseCode != uoeSndRcvCtlPara2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uoeSndRcvCtlPara1.BusinessCode != uoeSndRcvCtlPara2.BusinessCode) resList.Add("BusinessCode");
            if (uoeSndRcvCtlPara1.SystemDivCd != uoeSndRcvCtlPara2.SystemDivCd) resList.Add("SystemDivCd");
            if (uoeSndRcvCtlPara1.ProcessDiv != uoeSndRcvCtlPara2.ProcessDiv) resList.Add("ProcessDiv");
            if (uoeSndRcvCtlPara1.EnterpriseName != uoeSndRcvCtlPara2.EnterpriseName) resList.Add("EnterpriseName");
            if (uoeSndRcvCtlPara1.BusinessName != uoeSndRcvCtlPara2.BusinessName) resList.Add("BusinessName");

            return resList;
        }
    }
}
