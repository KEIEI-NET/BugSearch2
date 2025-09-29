using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SecPrintSet
    /// <summary>
    ///                      ���_���}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���_���}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class SecPrintSet 
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���Ж��̃R�[�h1</summary>
        /// <remarks>�����V�X�e���Ŏg�p���鎩�Ж��̃R�[�h</remarks>
        private Int32 _companyNameCd1;

        /// <summary>���Ж���1</summary>
        private string _companyName1 = "";

        /// <summary>���Ж���2</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _companyName2 = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideSnm = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>�X�֔ԍ�</summary>
        private string _postNo = "";

        /// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _address1 = "";

        /// <summary>�Z��3�i�Ԓn�j</summary>
        private string _address3 = "";

        /// <summary>�Z��4�i�A�p�[�g���́j</summary>
        private string _address4 = "";

        /// <summary>���Гd�b�ԍ�1</summary>
        private string _companyTelNo1 = "";

        /// <summary>���Гd�b�ԍ�2</summary>
        private string _companyTelNo2 = "";

        /// <summary>���Гd�b�ԍ�3</summary>
        private string _companyTelNo3 = "";

        /// <summary>���Гd�b�ԍ��^�C�g��1</summary>
        private string _companyTelTitle1 = "";

        /// <summary>���Гd�b�ԍ��^�C�g��2</summary>
        private string _companyTelTitle2 = "";

        /// <summary>���Гd�b�ԍ��^�C�g��3</summary>
        private string _companyTelTitle3 = "";

        /// <summary>���_�q�ɃR�[�h�P</summary>
        private string _sectWarehouseCd1 = "";

        /// <summary>���_�q�ɃR�[�h�Q</summary>
        private string _sectWarehouseCd2 = "";

        /// <summary>���_�q�ɃR�[�h�R</summary>
        private string _sectWarehouseCd3 = "";

        /// <summary>�q�ɖ���1</summary>
        private string _warehouseName1 = "";

        /// <summary>�q�ɖ���2</summary>
        private string _warehouseName2 = "";

        /// <summary>�q�ɖ���3</summary>
        private string _warehouseName3 = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>���Аݒ�E�v1</summary>
        private string _companySetNote1 = "";

        /// <summary>���Аݒ�E�v2</summary>
        private string _companySetNote2 = "";


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

        /// public propaty name  :  CompanyNameCd1
        /// <summary>���Ж��̃R�[�h1�v���p�e�B</summary>
        /// <value>�����V�X�e���Ŏg�p���鎩�Ж��̃R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CompanyNameCd1
        {
            get { return _companyNameCd1; }
            set { _companyNameCd1 = value; }
        }

        /// public propaty name  :  CompanyName1
        /// <summary>���Ж���1�v���p�e�B</summary>
        /// <value>0:�L��,1:�_���폜</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyName1
        {
            get { return _companyName1; }
            set { _companyName1 = value; }
        }

        /// public propaty name  :  CompanyName2
        /// <summary>���Ж���2�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyName2
        {
            get { return _companyName2; }
            set { _companyName2 = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  CompanyTelNo1
        /// <summary>���Гd�b�ԍ�1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelNo1
        {
            get { return _companyTelNo1; }
            set { _companyTelNo1 = value; }
        }

        /// public propaty name  :  CompanyTelNo2
        /// <summary>���Гd�b�ԍ�2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelNo2
        {
            get { return _companyTelNo2; }
            set { _companyTelNo2 = value; }
        }

        /// public propaty name  :  CompanyTelNo3
        /// <summary>���Гd�b�ԍ�3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelNo3
        {
            get { return _companyTelNo3; }
            set { _companyTelNo3 = value; }
        }

        /// public propaty name  :  CompanyTelTitle1
        /// <summary>���Гd�b�ԍ��^�C�g��1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelTitle1
        {
            get { return _companyTelTitle1; }
            set { _companyTelTitle1 = value; }
        }

        /// public propaty name  :  CompanyTelTitle2
        /// <summary>���Гd�b�ԍ��^�C�g��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelTitle2
        {
            get { return _companyTelTitle2; }
            set { _companyTelTitle2 = value; }
        }

        /// public propaty name  :  CompanyTelTitle3
        /// <summary>���Гd�b�ԍ��^�C�g��3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelTitle3
        {
            get { return _companyTelTitle3; }
            set { _companyTelTitle3 = value; }
        }

        /// public propaty name  :  SectWarehouseCd1
        /// <summary>���_�q�ɃR�[�h�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�q�ɃR�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectWarehouseCd1
        {
            get { return _sectWarehouseCd1; }
            set { _sectWarehouseCd1 = value; }
        }

        /// public propaty name  :  SectWarehouseCd2
        /// <summary>���_�q�ɃR�[�h�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�q�ɃR�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectWarehouseCd2
        {
            get { return _sectWarehouseCd2; }
            set { _sectWarehouseCd2 = value; }
        }

        /// public propaty name  :  SectWarehouseCd3
        /// <summary>���_�q�ɃR�[�h�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�q�ɃR�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectWarehouseCd3
        {
            get { return _sectWarehouseCd3; }
            set { _sectWarehouseCd3 = value; }
        }

        /// public propaty name  :  WarehouseName1
        /// <summary>�q�ɖ���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ���1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName1
        {
            get { return _warehouseName1; }
            set { _warehouseName1 = value; }
        }

        /// public propaty name  :  WarehouseName2
        /// <summary>�q�ɖ���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ���2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName2
        {
            get { return _warehouseName2; }
            set { _warehouseName2 = value; }
        }

        /// public propaty name  :  WarehouseName3
        /// <summary>�q�ɖ���3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ���3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName3
        {
            get { return _warehouseName3; }
            set { _warehouseName3 = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  CompanySetNote1
        /// <summary>���Аݒ�E�v1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Аݒ�E�v1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanySetNote1
        {
            get { return _companySetNote1; }
            set { _companySetNote1 = value; }
        }

        /// public propaty name  :  CompanySetNote2
        /// <summary>���Аݒ�E�v2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Аݒ�E�v2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanySetNote2
        {
            get { return _companySetNote2; }
            set { _companySetNote2 = value; }
        }


        /// <summary>
        /// ���Ж��̃R�[�h�擾����
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>���Ж��̃R�[�h</returns>
        /// <remarks>
        /// <br>Note       : �C���f�b�N�X�Ŏw�肵�����Ж��̃R�[�h���擾���܂�</br>
        /// <br>Programmer : 23001 �H�R�@����</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public int GetCompanyNameCd(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        return this._companyNameCd1;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }
        /// <summary>
        /// ���_�q�ɃR�[�h�擾����
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>���_�q�ɃR�[�h</returns>
        /// <remarks>
        /// <br>Note       : �C���f�b�N�X�Ŏw�肵�����_�q�ɃR�[�h���擾���܂�</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        public string GetSectWarehouseCd(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        return this._sectWarehouseCd1;
                    }
                case 1:
                    {
                        return this._sectWarehouseCd2;
                    }
                case 2:
                    {
                        return this._sectWarehouseCd3;
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// ���_�q�ɖ��̐ݒ菈��
        /// </summary>
        /// <param name="sectWarehouseNm">���_�q�ɖ���</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �C���f�b�N�X�Ŏw�肵�����Ж��̂�ݒ肵�܂�</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        public void SetSectWarehouseNm(string sectWarehouseNm, int index)
        {
            switch (index)
            {
                case 0:
                    {
                        this._warehouseName1 = sectWarehouseNm;
                        break;
                    }
                case 1:
                    {
                        this._warehouseName2 = sectWarehouseNm;
                        break;
                    }
                case 2:
                    {
                        this._warehouseName3 = sectWarehouseNm;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// ���_���i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SecPrintSet Clone()
        {
            return new SecPrintSet(this._sectionCode,this._companyNameCd1,this._companyName1,this._companyName2,this._sectionGuideSnm,this._sectionGuideNm,this._postNo,this._address1,this._address3,this._address4,this._companyTelNo1,this._companyTelNo2,this._companyTelNo3,this._companyTelTitle1,this._companyTelTitle2,this._companyTelTitle3,this._sectWarehouseCd1,this._sectWarehouseCd2,this._sectWarehouseCd3,this._warehouseName1,this._warehouseName2,this._warehouseName3,this._warehouseName,this._companySetNote1,this._companySetNote2);
            
        }

        /// <summary>
        /// ���_���i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecInfoSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SecPrintSet()
        {
        }

        /// <summary>
        /// ���_���i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="SectionCode"></param>
        /// <param name="CompanyNameCd1"></param>
        /// <param name="CompanyName1"></param>
        /// <param name="CompanyName2"></param>
        /// <param name="SectionGuideSnm"></param>
        /// <param name="SectionGuideNm"></param>
        /// <param name="PostNo"></param>
        /// <param name="Address1"></param>
        /// <param name="Address3"></param>
        /// <param name="Address4"></param>
        /// <param name="CompanyTelNo1"></param>
        /// <param name="CompanyTelNo2"></param>
        /// <param name="CompanyTelNo3"></param>
        /// <param name="CompanyTelTitle1"></param>
        /// <param name="CompanyTelTitle2"></param>
        /// <param name="CompanyTelTitle3"></param>
        /// <param name="SectWarehouseCd1"></param>
        /// <param name="SectWarehouseCd2"></param>
        /// <param name="SectWarehouseCd3"></param>
        /// <param name="WarehouseName1"></param>
        /// <param name="WarehouseName2"></param>
        /// <param name="WarehouseName3"></param>
        /// <param name="WarehouseName"></param>
        /// <param name="CompanySetNote1"></param>
        /// <param name="CompanySetNote2"></param>
        public SecPrintSet(string SectionCode, Int32 CompanyNameCd1, string CompanyName1, string CompanyName2, string SectionGuideSnm, string SectionGuideNm, string PostNo, string Address1, string Address3, string Address4, string CompanyTelNo1, string CompanyTelNo2, string CompanyTelNo3, string CompanyTelTitle1, string CompanyTelTitle2, string CompanyTelTitle3, string SectWarehouseCd1, string SectWarehouseCd2, string SectWarehouseCd3, string WarehouseName1, string WarehouseName2, string WarehouseName3, string WarehouseName, string CompanySetNote1, string CompanySetNote2)
        {
            this._sectionCode = SectionCode;
            this._companyNameCd1 = CompanyNameCd1;
            this._companyName1 = CompanyName1;
            this._companyName2 = CompanyName2;
            this._sectionGuideSnm = SectionGuideSnm;
            this._sectionGuideNm = SectionGuideNm;
            this._postNo = PostNo;
            this._address1 = Address1;
            this._address3 = Address3;
            this._address4 = Address4;
            this._companyTelNo1 = CompanyTelNo1;
            this._companyTelNo2 = CompanyTelNo2;
            this._companyTelNo3 = CompanyTelNo3;
            this._companyTelTitle1 = CompanyTelTitle1;
            this._companyTelTitle2 = CompanyTelTitle2;
            this._companyTelTitle3 = CompanyTelTitle3;
            this._sectWarehouseCd1 = SectWarehouseCd1;
            this._sectWarehouseCd2 = SectWarehouseCd2;
            this._sectWarehouseCd3 = SectWarehouseCd3;
            this._warehouseName1 = WarehouseName1;
            this._warehouseName2 = WarehouseName2;
            this._warehouseName3 = WarehouseName3;
            this._warehouseName = WarehouseName;
            this._companySetNote1 = CompanySetNote1;
            this._companySetNote2 = CompanySetNote2;

        }
    }
}
