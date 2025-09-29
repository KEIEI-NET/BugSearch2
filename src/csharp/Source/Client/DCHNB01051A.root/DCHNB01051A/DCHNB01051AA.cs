# region ��using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
# endregion

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �[����m�F��� �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �[����m�F��ʗp�̃f�[�^���������s���܂��B</br>
    /// <br>Programmer	: 20056�@���n ���</br>
    /// <br>Date		: 2007.09.28</br>
    /// <br></br>
    /// <br>Note		: �[����m�F�s��Ή�</br>
    /// <br>Programmer	: �e�c ���V</br>
    /// <br>Date		: 2013/04/17</br>
    /// </remarks>
    public class AddresseeAcs
    {
        # region ��Private Member

        private string _enterpriseCode;                     // ��ƃR�[�h
        private string _loginSectionCode;                   // �����_�R�[�h
        private Addressee _addressee;                       // �[����m�F��ʃf�[�^�N���X
        private CustomerInfoAcs _customerInfoAcs;           // ���Ӑ�A�N�Z�X�N���X
        private static SecInfoAcs _secInfoAcs;              // ���_�A�N�Z�X�N���X
        // --- UPD 2013/04/17 Y.Wakita ---------->>>>>
        //private bool _isLocalDBRead = true;
        private bool _isLocalDBRead = false;
        // --- UPD 2013/04/17 Y.Wakita ----------<<<<<
        private GuideMode _guideMode = GuideMode.Addressee; // �K�C�h���[�h
        private string _addUpSectionCode;                   // �v�㋒�_�R�[�h
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";

        # endregion

        #region ��enum
        /// <summary>
        /// �N���^�C�v
        /// </summary>
        public enum GuideMode : int
        {
            Customer = 1, //���Ӑ�
            Addressee = 2, //�[����
            CustomerClaim = 3, //������
        }
        #endregion

        # region ��Constracter
        /// <summary>
        /// �[����m�F��ʃA�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        public AddresseeAcs()
        {
            // ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �����_�R�[�h���擾����
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // �e�A�N�Z�X�N���X�̃C���X�^���X��
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerInfoAcs.IsLocalDBRead = _isLocalDBRead;
            this._addressee = new Addressee();

            // ���_���̎擾
            string selectedSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            string addUpSectionCode;
            string addUpSectionName;
            this.GetOwnSeCtrlCode(selectedSectionCode, out addUpSectionCode, out addUpSectionName);

            this._addUpSectionCode = addUpSectionCode;
        }
        # endregion

        #region��Property
        /// <summary>�K�C�h���[�h�v���p�e�B</summary>
        public GuideMode Mode
        {
            set { this._guideMode = value; }
            get { return this._guideMode; }
        }

        /// <summary>�[����m�F��ʃf�[�^�N���X�v���p�e�B</summary>
        public Addressee Addressee
        {
            set { this._addressee = value; }
            get { return this._addressee; }
        }

        /// <summary>���[�J��DB�ǂݍ��݃��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            // --- UPD 2013/04/17 Y.Wakita ---------->>>>>
            //set { this._isLocalDBRead = true; }
            set { this._isLocalDBRead = value; }
            // --- UPD 2013/04/17 Y.Wakita ----------<<<<<
            get { return this._isLocalDBRead; }
        }
        #endregion

        #region��public Method
        /// <summary>
        /// ���Ӑ�ǂݍ��ݏ���
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerInfo">���Ӑ���N���X</param>
        /// <returns>�ǂݍ��݃X�e�[�^�X</returns>
        public int ReadCustomer(int customerCode, out CustomerInfo customerInfo)
        {
            return this.ReadCustomerProc(customerCode, out customerInfo);
        }

        /// <summary>
        /// �f�[�^�L���b�V������
        /// </summary>
        /// <param name="customerInfo">���Ӑ���N���X</param>
        /// <param name="custSuppli">���Ӑ�d�����N���X</param>
        /// <param name="addUpdate">�v����t</param>
        public void Cache(CustomerInfo customerInfo)
        {
            this.cacheProc(customerInfo);
        }
        # endregion

        #region ��Private Method
        /// <summary>
        /// ���_����A�N�Z�X�N���X�C���X�^���X������
        /// </summary>
        private void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                if (_isLocalDBRead == true)
                {
                    _secInfoAcs = new SecInfoAcs((int)SecInfoAcs.SearchMode.Local);
                }
                else
                {
                    _secInfoAcs = new SecInfoAcs((int)SecInfoAcs.SearchMode.Remote);
                }
            }

            // ���O�C���S�����_���̎擾
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// ����@�\���_�擾����
        /// </summary>
        /// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
        /// <param name="ctrlSectionCode">�Ώې��䋒�_�R�[�h</param>
        /// <param name="ctrlSectionName">�Ώې��䋒�_����</param>
        public int GetOwnSeCtrlCode(string sectionCode, out string ctrlSectionCode, out string ctrlSectionName)
        {
            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs();

            // �Ώې��䋒�_�̏����l�̓��O�C���S�����_
            ctrlSectionCode = sectionCode.TrimEnd();
            ctrlSectionName = "";

            SecInfoSet secInfoSet;
            int status = _secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (secInfoSet != null)
                        {
                            //ctrlSectionCode = secInfoSet.SectionCode.Trim();
                            ctrlSectionCode = secInfoSet.SectionCode;
                            ctrlSectionName = secInfoSet.SectionGuideNm.Trim();
                        }
                        else
                        {
                            // ���_����ݒ肪����Ă��Ȃ�
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�E���Ӑ�d�����ǂݍ��ݏ���
        /// </summary>
        /// <returns></returns>
        private int ReadCustomerProc(int customerCode, out CustomerInfo customerInfo)
        {
            customerInfo = null;
            if (customerCode == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, true, out customerInfo);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            // �Ɣ̐�ȊO�͓��Ӑ�����N���A����
            if (customerInfo.AcceptWholeSale == 0)
            {
                customerInfo = null;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// �f�[�^�L���b�V������
        /// </summary>
        /// <param name="customerInfo">���Ӑ���N���X</param>
        /// <param name="custSuppli">���Ӑ�d�����N���X</param>
        /// <param name="addUpdate">�v����t</param>
        private void cacheProc( CustomerInfo customerInfo)
        {

            if (customerInfo == null)
            {
                this._addressee = new Addressee();
                return;
            }
            this._addressee.AddresseeTelNo = customerInfo.OfficeTelNo;
            this._addressee.AddresseeFaxNo = customerInfo.OfficeFaxNo;
            this._addressee.AddresseeAddr1 = customerInfo.Address1;
            this._addressee.AddresseeAddr3 = customerInfo.Address3;
            this._addressee.AddresseeAddr4 = customerInfo.Address4;
            this._addressee.AddresseePostNo = customerInfo.PostNo;  // ADD 2013/04/17 Y.Wakita

        }
        #endregion

    }
}
