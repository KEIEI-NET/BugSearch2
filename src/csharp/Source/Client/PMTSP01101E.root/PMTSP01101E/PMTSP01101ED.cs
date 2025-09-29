using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{

    
    /// <summary>
    /// TSP�⍇���N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   TspRequest</br>
    /// <br>Programmer       :   32470 ����</br>
    /// <br>Date             :   2020/12/01</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class TspRequest
    {

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public TspRequest()
        { 
        
        
        
        }

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="pmEnterpriseCode">PM��ƃR�[�h</param>
        /// <param name="tspCommNo">TSP�ʐM�ԍ�</param>
        /// <param name="tspCommCount">TSP�ʐM��</param>
        /// <param name="commConditionDivCd">�ʐM��ԋ敪</param>
        public TspRequest(string enterpriseCode, string pmEnterpriseCode, Int32 tspCommNo, Int32 tspCommCount, Int32 commConditionDivCd)
        {

            _enterpriseCode = enterpriseCode;
            _pmEnterpriseCode = pmEnterpriseCode;
            _tspCommNo = tspCommNo;
            _tspCommCount = tspCommCount;
            _commConditionDivCd = commConditionDivCd;

        }


        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>PM��ƃR�[�h</summary>
        /// <remarks>���i���̊�ƃR�[�h</remarks>
        private string _pmEnterpriseCode = "";

        /// <summary>TSP�ʐM�ԍ�</summary>
        /// <remarks>�P���M���ɐU����ԍ�(PM���ɂč̔� or ��������SF���̔ԍ��̔�)</remarks>
        private Int32 _tspCommNo;

        /// <summary>TSP�ʐM��</summary>
        /// <remarks>PM�����P�����ɑ΂��ĉ񓚂��s����</remarks>
        private Int32 _tspCommCount;

        /// <summary>�ʐM��ԋ敪</summary>
        /// <remarks>0:������,1:���M�ς�,2:������,9:�G���[</remarks>
        private Int32 _commConditionDivCd;

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


        /// public propaty name  :  PmEnterpriseCode
        /// <summary>PM��ƃR�[�h�v���p�e�B</summary>
        /// <value>���i���̊�ƃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmEnterpriseCode
        {
            get { return _pmEnterpriseCode; }
            set { _pmEnterpriseCode = value; }
        }

        /// public propaty name  :  TspCommNo
        /// <summary>TSP�ʐM�ԍ��v���p�e�B</summary>
        /// <value>�P���M���ɐU����ԍ�(PM���ɂč̔� or ��������SF���̔ԍ��̔�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP�ʐM�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TspCommNo
        {
            get { return _tspCommNo; }
            set { _tspCommNo = value; }
        }

        /// public propaty name  :  TspCommCount
        /// <summary>TSP�ʐM�񐔃v���p�e�B</summary>
        /// <value>PM�����P�����ɑ΂��ĉ񓚂��s����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP�ʐM�񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TspCommCount
        {
            get { return _tspCommCount; }
            set { _tspCommCount = value; }
        }

        /// public propaty name  :  CommConditionDivCd
        /// <summary>�ʐM��ԋ敪�v���p�e�B</summary>
        /// <value>0:������,1:���M�ς�,2:������,9:�G���[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʐM��ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CommConditionDivCd
        {
            get { return _commConditionDivCd; }
            set { _commConditionDivCd = value; }
        }


    }


}
