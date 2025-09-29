using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ������͗p�����l�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������͂̏����l�擾�f�[�^������s���܂��B</br>
    /// </remarks>
    public class DelphiSalesSlipInputInitDataSeventhAcs
    {
        # region ���R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private DelphiSalesSlipInputInitDataSeventhAcs()
        {
        }

        /// <summary>
        /// ������͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        public static DelphiSalesSlipInputInitDataSeventhAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataSeventhAcs == null)
            {
                _delphiSalesSlipInputInitDataSeventhAcs = new DelphiSalesSlipInputInitDataSeventhAcs();
            }
            return _delphiSalesSlipInputInitDataSeventhAcs;
        }
        # endregion

        #region ���v���C�x�[�g�ϐ�
        private static DelphiSalesSlipInputInitDataSeventhAcs _delphiSalesSlipInputInitDataSeventhAcs;
        private AllDefSet _allDefSet = null;                   // �S�̏����l�ݒ�}�X�^
        private StockTtlSt _stockTtlSt = null;                 // �d���݌ɑS�̐ݒ�}�X�^


        /// <summary> ���̓��[�h</summary>
        private int _inputMode;
        #endregion

        #region ���p�u���b�N�ϐ�
        /// <summary>���[�J��DB�ǂݍ��ݔ���</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#else
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#endif
        /// <summary>���_�R�[�h(�S��)</summary>
        public const string ctSectionCode = "00";

        /// <summary>�I�v�V�������</summary>
        private int _opt_CarMng;
        private int _opt_FreeSearch;
        private int _opt_PCC;
        private int _opt_RCLink;
        private int _opt_UOE;
        private int _opt_StockingPayment;
        # endregion

        #region ���񋓑�
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>����</summary>
            OFF = 0,
            /// <summary>�L��</summary>
            ON = 1,
        }
        #endregion

        # region ���p�u���b�N���\�b�h
        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataSeventh(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ���d���݌ɑS�̐ݒ�}�X�^ SFSIR09002A
            StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();          // �d���݌ɑS�̐ݒ�}�X�^
            status = stockTtlStAcs.SearchOnlyStockTtlInfo(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheStockTtlSt(aList, enterpriseCode, sectionCode);
            }
            #endregion

            #region ���S�̏����l�ݒ�}�X�^ SFCMN09082A
            AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
            AllDefSetAcs.SearchMode allDefSetSearchMode = (ctIsLocalDBRead == true) ? AllDefSetAcs.SearchMode.Local : AllDefSetAcs.SearchMode.Remote;
            status = allDefSetAcs.Search(out aList, enterpriseCode, allDefSetSearchMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, aList);
                if (this._allDefSet != null) this._inputMode = this._allDefSet.GoodsNoInpDiv;
            }
            #endregion

            #region ���I�v�V�������
            this.CacheOptionInfo();
            #endregion

            return 0;
        }
        #endregion

        # region ���d���݌ɑS�̐ݒ�}�X�^���䏈��
        /// <summary>
        /// �d���݌ɑS�̐ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="stockTtlStList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheStockTtlSt(ArrayList stockTtlStList, string enterpriseCode, string sectionCode)
        {
            if (stockTtlStList != null)
            {
                List<StockTtlSt> list = new List<StockTtlSt>((StockTtlSt[])stockTtlStList.ToArray(typeof(StockTtlSt)));

                this._stockTtlSt = list.Find(
                    delegate(StockTtlSt stockttl)
                    {
                        if ((stockttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (stockttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._stockTtlSt != null) return;

                this._stockTtlSt = list.Find(
                    delegate(StockTtlSt stockttl)
                    {
                        if ((stockttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (stockttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

            }
        }

        # endregion

        # region ���S�̏����l�ݒ�}�X�^���䏈��
        /// <summary>
        /// �S�̏����l�ݒ�}�X�^�̃��X�g������A�w�肵�����_�Ŏg�p����ݒ���擾���܂��B(���_�R�[�h��������ΑS�Аݒ�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="allDefSetArrayList">�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
        /// <returns>�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            if (allDefSetArrayList == null) return null;

            List<AllDefSet> list = new List<AllDefSet>((AllDefSet[])allDefSetArrayList.ToArray(typeof(AllDefSet)));

            AllDefSet allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == sectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (allSecAllDefSet != null) return allSecAllDefSet;

            allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == ctSectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return allSecAllDefSet;
        }

        # endregion

        #region ���I�v�V������񐧌䏈��
        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ���ԗ��Ǘ��I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_CarMng);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_CarMng = (int)Option.ON;
            }
            else
            {
                this._opt_CarMng = (int)Option.OFF;
            }
            #endregion

            #region �����R�����I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FreeSearch = (int)Option.ON;
            }
            else
            {
                this._opt_FreeSearch = (int)Option.OFF;
            }
            #endregion

            #region ���o�b�b�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCC);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_PCC = (int)Option.ON;
            }
            else
            {
                this._opt_PCC = (int)Option.OFF;
            }
            #endregion

            #region �����T�C�N���A���I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RCLink);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_RCLink = (int)Option.ON;
            }
            else
            {
                this._opt_RCLink = (int)Option.OFF;
            }
            #endregion

            #region ���t�n�d�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_UOE);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_UOE = (int)Option.ON;
            }
            else
            {
                this._opt_UOE = (int)Option.OFF;
            }
            #endregion

            #region ���d���x���Ǘ��I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_StockingPayment = (int)Option.ON;
            }
            else
            {
                this._opt_StockingPayment = (int)Option.OFF;
            }
            #endregion
        }
        #endregion


        public int GetOpt_CarMng()
        {
            return this._opt_CarMng;
        }
        public AllDefSet GetAllDefSet()
        {
            return this._allDefSet;
        }
        public StockTtlSt GetStockTtlSt()
        {
            return this._stockTtlSt;
        }
    }
}
