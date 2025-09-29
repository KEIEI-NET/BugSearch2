using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsSubstUSearchParamWork
    /// <summary>
    ///                      ��֐V���֘A�\�����o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ��֐V���֘A�\�����o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PartsSubstUSearchParamWork 
	{
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�����敪</summary>
        /// <remarks>0:��֐�,1:��֌�</remarks>
        private Int32 _searchDiv;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�ϊ������[�J�[�R�[�h</summary>
        private Int32 _chgSrcMakerCd;

        /// <summary>�ϊ������i�ԍ�</summary>
        private string _chgSrcGoodsNo = "";


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

        /// public propaty name  :  SearchDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:��֐�,1:��֌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

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


        /// <summary>
        /// ��֐V���֘A�\�����o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PartsSubstUSearchParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstUSearchParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsSubstUSearchParamWork()
        {
        }

	}
}
