using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    class SearchPrtCtlAcs
    {
        /// <summary>0:�W�� 20:�O��</summary>
        private int _searchPrtTyp;
        /// <summary>0:��^�_��Ȃ� 1:��^�_�񂠂�</summary>
        private int _bigCarOfferDiv;
        /// <summary>0:2�֌_��Ȃ� 1:2�֌_�񂠂�</summary>
        private int _bikeSearch;
        /// <summary>0:�^�N�e�B�����_��Ȃ� 1:�^�N�e�B�����_�񂠂�</summary>
        private int _tactiSearch;
        private List<int> currentList;
        private List<int>[] lstSearchPrt;

        /// <summary>0:2�֌_��Ȃ� 1:2�֌_�񂠂�</summary>
        public int BikeSearch
        {
            get { return _bikeSearch; }
        }

        /// <summary>0:�^�N�e�B�����_��Ȃ� 1:�^�N�e�B�����_�񂠂�</summary>
        public int TactiSearch
        {
            get { return _tactiSearch; }
        }

        //>>>2010/03/29
        /// <summary>0:��^�_��Ȃ� 1:��^�_�񂠂�</summary>
        public int BigCarOfferDiv
        {
            get { return _bigCarOfferDiv; }
        }
        //<<<2010/03/29

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        ///// <param name="searchPrtTyp">�����^�C�v</param>
        ///// <param name="bigCarOfferDiv">��^�񋟋敪</param>
        public SearchPrtCtlAcs()//int searchPrtTyp, int bigCarOfferDiv)
        {
            lstSearchPrt = new List<int>[6];
            for (int i = 0; i < 6; i++)
            {
                lstSearchPrt[i] = new List<int>();
            }
            // ����������-1
            _searchPrtTyp = -1;

            // ��{�񋟃f�[�^ �_���
            PurchaseStatus psBasicOffer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicOfferData);
            // ��^�񋟋敪 �_���
            // 2009/10/23 >>>
            //PurchaseStatus psBigCarOffer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_OutsideOfferData);
            PurchaseStatus psBigCarOffer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BigCarOfferData);
            // 2009/10/23 <<<
            // ����B�^�C�v�i�O���j �_���
            // 2009/10/23 >>>
            //PurchaseStatus psPrtTyp = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BigCarOfferData);
            PurchaseStatus psPrtTyp = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_OutsideOfferData);
            // 2009/10/23 <<<
            // 2�֌����_���
            PurchaseStatus psBikeSearch = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_BikeSearch);
            // �^�N�e�B�����_���
            PurchaseStatus psTactiSearch = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_TactiSearch);

            if (psBigCarOffer == PurchaseStatus.Contract || psBigCarOffer == PurchaseStatus.Trial_Contract)   // ��^�_�񂠂�
                _bigCarOfferDiv = 1;
            if (psBasicOffer == PurchaseStatus.Contract || psBasicOffer == PurchaseStatus.Trial_Contract) // ��{�񋟃f�[�^
                _searchPrtTyp = 10;
            if (psPrtTyp == PurchaseStatus.Contract || psPrtTyp == PurchaseStatus.Trial_Contract) // �O���_�񂠂�
                _searchPrtTyp = 20;
            if (psBikeSearch == PurchaseStatus.Contract || psBikeSearch == PurchaseStatus.Trial_Contract) // 2�֌_�񂠂�
                _bikeSearch = 1;
            if (psTactiSearch == PurchaseStatus.Contract || psTactiSearch == PurchaseStatus.Trial_Contract) // �^�N�e�B�����_�񂠂�
                _tactiSearch = 1;

            //_searchPrtTyp = 0; // test
            int ind = 0;
            switch (_searchPrtTyp)
            {
                case 0: // 0:�W�� 
                    ind = 0 + _bigCarOfferDiv;
                    break;
                case 10: // 10:�g��
                    ind = 2 + _bigCarOfferDiv;
                    break;
                case 20: // 20:�O��
                    ind = 4 + _bigCarOfferDiv;
                    break;
            }
            currentList = lstSearchPrt[ind];
        }

        /// <summary>
        /// �����[�g����̌����i�ڃ��X�g��ݒ肷��B
        /// </summary>        
        /// <param name="lst">���X�g</param>
        public void AddList(ArrayList lst)
        {
            foreach (SearchPrtCtlWork searchPrtCtlWork in lst)
            {
                int ind = 0;
                switch (searchPrtCtlWork.SearchPrtType)
                {
                    case 0: // 0:�W�� 
                        ind = 0 + searchPrtCtlWork.BigCarOfferDiv;
                        break;
                    case 10: // 10:�g��
                        ind = 2 + searchPrtCtlWork.BigCarOfferDiv;
                        break;
                    case 20: // 20:�O��
                        ind = 4 + searchPrtCtlWork.BigCarOfferDiv;
                        break;
                }
                if (lstSearchPrt[ind].Contains(searchPrtCtlWork.TbsPartsCode) == false)
                    lstSearchPrt[ind].Add(searchPrtCtlWork.TbsPartsCode);
            }
        }

        /// <summary>
        /// BL�R�[�h�`�F�b�N����
        /// </summary>
        /// <param name="blCode">BL�R�[�h</param>
        /// <returns>true:�\���^false:��\��</returns>
        public bool IsBLEnabled(int blCode)
        {
            if (_searchPrtTyp == -1) return false;

            if (currentList.Contains(blCode))
                return true;
            return false;
        }

    }
}
