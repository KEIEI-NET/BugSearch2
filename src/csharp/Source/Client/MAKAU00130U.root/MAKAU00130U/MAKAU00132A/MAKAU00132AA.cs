//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F����^�d�������X�V
// �v���O�����T�v   �F����^�d�������X�V���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2008/08/21     �C�����e�FPartsman�p�ɕύX
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/08     �C�����e�FMantis�y11603�z�S���_�w��Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/05/12     �C�����e�FMantis�y13247�z���|�I�v�V�������̊����X�V�ݒ���C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00    �쐬�S���Fzhouyu
// �C����    2011/07/15     �C�����e�F�A�� 42 �����X�V�ŁA�Â��f�[�^���폜s�̑Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���FFSI���X�� �M�p
// �C����    2012/09/13     �C�����e�F�d�������Ή�
// ---------------------------------------------------------------------//

# region ��using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
# endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���Ӑ搿�����z�}�X�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���Ӑ搿�����z�}�X�^�̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer	: �n糋M�T</br>
	/// <br>Date		: 2007.04.03</br>
    /// <br></br>
    /// <br>Update Note: �d�����������Ή� �I�v�V�����R�[�h����Ŏd�������X�V�W�v���@��ݒ�</br>
    /// <br>Programmer : FSI���X�� �M�p</br>
    /// <br>Date       : 2012/09/13</br>
    /// </remarks>
	public class CustDmdPrcAcs
	{
		# region ��Private Member
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		//private ICustDmdPrcDB _iCustDmdPrcDB = null;
        private IMonthlyAddUpDB _iMonthlyAddUpDB = null;
		/// <summary>���[�U�[�K�C�h�I�u�W�F�N�g�i�[�o�b�t�@(HashTable)</summary>
//*		private Hashtable _CustDmdPrcGdBdTable;
		/// <summary>���[�U�[�K�C�h�I�u�W�F�N�g�i�[�o�b�t�@(ArrayList)</summary>
//*		private ArrayList _CustDmdPrcGdBdList;
		/// <summary>�L�����A�}�X�^�N���XStatic</summary>
//*		private static Hashtable _carrierTable = null;

        // --- ADD 2008/08/21 --------------------------------------------------------------------->>>>>
        /// <summary>���Аݒ�}�X�^�A�N�Z�X�N���X</summary>
        private CompanyInfAcs _companyInfAcs;
        /// <summary>���Аݒ�}�X�^</summary>
        private CompanyInf _companyInf;
        /// <summary>�݌ɊǗ��S�̐ݒ�}�X�^�A�N�Z�X�N���X</summary>
        private StockMngTtlStAcs _stockMngTtlStAcs;
        /// <summary>�݌ɊǗ��S�̐ݒ�}�X�^</summary>
        private StockMngTtlSt _stockMngTtlSt;
        /// <summary>���_���}�X�^�A�N�Z�X�N���X</summary>
        private SecInfoAcs _secInfoAcs;
        /// <summary>���t�擾�A�N�Z�X�N���X</summary>
        private DateGetAcs _dateGetAcs;
        /// <summary>�����Z�o���W���[��</summary>
        private TotalDayCalculator _totalDayCalculator;
        // --- ADD 2008/08/21 ---------------------------------------------------------------------<<<<<
        # endregion				    
		  
		# region ��Constracter
		/// <summary>
		/// ���Ӑ搿�����z�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public CustDmdPrcAcs()
		{
    		try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iMonthlyAddUpDB = (IMonthlyAddUpDB)MediationMonthlyAddUpDB.GetCustMonthlyAddUpDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._iMonthlyAddUpDB = null;
			}

            // --- ADD 2008/08/21 --------------------------------------------------------------------->>>>>
            this._companyInfAcs = new CompanyInfAcs();
            this._companyInf = new CompanyInf();
            this._stockMngTtlStAcs = new StockMngTtlStAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._dateGetAcs = DateGetAcs.GetInstance();

            this._totalDayCalculator = TotalDayCalculator.GetInstance();

            // ���Аݒ�}�X�^�Ǎ�
            LoadCompanyInf();

            // �݌ɊǗ��S�̐ݒ�}�X�^�Ǎ�
            LoadStockMngTtlSt();
            // --- ADD 2008/08/21 ---------------------------------------------------------------------<<<<<
		}
		# endregion

		#region ��Public Method

        // --- ADD 2008/08/21 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �o�^����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="addupYearMonth">�v��N��</param>
        /// <param name="prevTotalDay">�O�񌎎�������</param>
        /// <param name="currentTotalDay">���񌎎�������</param>
        /// <param name="monAddUpUpdDiv">����E�d���敪(0:����@1:�d��)</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: �I�v�V�����R�[�h����ŌĂяo�������X�V������U�蕪����悤�ύX</br>
        /// <br>Programmer : FSI���X�� �M�p</br>
        /// <br>Date       : 2012/09/13</br>
        /// </remarks>
        public int RegistDmdData(string enterpriseCode, 
                                 string sectionCode, 
                                 DateTime addupYearMonth,
                                 DateTime prevTotalDay,
                                 DateTime currentTotalDay,
                                 int monAddUpUpdDiv,
                                 out string msg)
        {
            MonthlyAddUpWork monthlyAddupWork = new MonthlyAddUpWork();
            monthlyAddupWork = GetMonthlyAddUpWork(enterpriseCode,
                                                   sectionCode,
                                                   2,
                                                   addupYearMonth,
                                                   prevTotalDay,
                                                   currentTotalDay,
                                                   monAddUpUpdDiv);

            object paraObj = monthlyAddupWork;
            object retObj;
            bool dbTimeOut;

            int status = 0;
            msg = "";

            try
            {
                // --- DEL 2012/09/13 ----------->>>>>
                //status = this._iMonthlyAddUpDB.Write(ref paraObj, out retObj, out dbTimeOut, out msg, monAddUpUpdDiv);
                // --- DEL 2012/09/13 -----------<<<<<
                // --- ADD 2012/09/13 ----------->>>>>
                #region �d�������@�\�i�ʁj
                PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                    ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
                if (PurchaseStatus.Contract == ps)
                {
                    // �d�������I�v�V�������L���̏ꍇ�A
                    // �d�������`���̎x�����X�V���������s����
                    status = this._iMonthlyAddUpDB.WriteByAddUpSecCode(ref paraObj, out retObj, out dbTimeOut, out msg, monAddUpUpdDiv);
                }
                else
                {
                    // �����`���̎x�����X�V���������s����
                    status = this._iMonthlyAddUpDB.Write(ref paraObj, out retObj, out dbTimeOut, out msg, monAddUpUpdDiv);
                }
                #endregion �d�������@�\�i�ʁj
                // --- ADD 2012/09/13 -----------<<<<<
                
                //ADD START zhouyu 2011/07/15 FOR �A�� 42
                //�݌ɍX�V�敪
                if (monthlyAddupWork.StockUpdDiv == 1)
                {
                    bool msgDiv = false;
                    status = this._iMonthlyAddUpDB.Delete(ref paraObj, out msgDiv, out msg, monAddUpUpdDiv);
                }
                else
                {
                    //�Ȃ�
                }
                //ADD END zhouyu 2011/07/15 FOR �A�� 42
                if (status == 0)
                {
                    // �L���b�V�����N���A
                    this._totalDayCalculator.ClearCache();
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="addUpYearMonth">�v��N��</param>
        /// <param name="prevTotalDay">�O�񌎎�������</param>
        /// <param name="currentTotalDay">���񌎎�������</param>
        /// <param name="monAddUpUpdDiv">����E�d���敪(0:����@1:�d��)</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int BanishDmdData(string enterpriseCode, 
                                 string sectionCode, 
                                 DateTime addUpYearMonth,
                                 DateTime prevTotalDay,
                                 DateTime currentTotalDay,
                                 int monAddUpUpdDiv,
                                 out string msg)
        {
            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();
            monthlyAddUpWork = GetMonthlyAddUpWork(enterpriseCode,
                                                   sectionCode,
                                                   1,
                                                   addUpYearMonth,
                                                   prevTotalDay,
                                                   currentTotalDay,
                                                   monAddUpUpdDiv);

            object paraObj = monthlyAddUpWork;
            object retObj;
            bool dbtimeOut;

            int status;
            msg = "";

            try
            {
                status = this._iMonthlyAddUpDB.Delete(ref paraObj, out retObj, out dbtimeOut, out msg, monAddUpUpdDiv);
                if (status == 0)
                {
                    // �L���b�V�����N���A
                    this._totalDayCalculator.ClearCache();
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// ����d�������X�V�����擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="recPayDiv">����d���敪(0:����@1:�d��)</param>
        /// <param name="prevTotalDay">�O�񌎎�������</param>
        /// <param name="currentTotalDay">���񌎎�������</param>
        /// <param name="prevTotalMonth">�O�񌎎������N��</param>
        /// <param name="currentTotalMonth">���񌎎������N��</param>
        /// <param name="convertProcessDivCd">�R���o�[�g�����敪</param>
        /// <returns>�X�e�[�^�X</returns>
        public int GetHisTotalDayMonthlyAccRecPay(string sectionCode,
                                                  int recPayDiv,
                                                  out DateTime prevTotalDay,
                                                  out DateTime currentTotalDay,
                                                  out DateTime prevTotalMonth,
                                                  out DateTime currentTotalMonth,
                                                  out int convertProcessDivCd)
        {
            int status = 0;

            prevTotalDay = new DateTime();
            currentTotalDay = new DateTime();
            prevTotalMonth = new DateTime();
            currentTotalMonth = new DateTime();
            convertProcessDivCd = 0;

            if ((sectionCode == "") || (sectionCode == "0") || (sectionCode == "00"))
            {
                // �S�Ђ̏ꍇ
                sectionCode = "";
            }
            else
            {
                // �e���_�̏ꍇ
                sectionCode = sectionCode.PadLeft(2, '0');
            }

            try
            {
                if (recPayDiv == 0)
                {
                    this._totalDayCalculator.ClearCache();
                    this._totalDayCalculator.InitializeHisMonthlyAccRec();

                    // ���㌎���X�V�����擾
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode,
                                                                                  out prevTotalDay,
                                                                                  out currentTotalDay,
                                                                                  out prevTotalMonth,
                                                                                  out currentTotalMonth,
                                                                                  out convertProcessDivCd);
                }
                else
                {
                    this._totalDayCalculator.ClearCache();
                    this._totalDayCalculator.InitializeHisMonthlyAccPay();

                    // �d�������X�V�����擾
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay(sectionCode,
                                                                                  out prevTotalDay,
                                                                                  out currentTotalDay,
                                                                                  out prevTotalMonth,
                                                                                  out currentTotalMonth,
                                                                                  out convertProcessDivCd);
                }
            }
            catch
            {
                prevTotalDay = new DateTime();
                currentTotalDay = new DateTime();
                prevTotalMonth = new DateTime();
                currentTotalMonth = new DateTime();

                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/21</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        break;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }
        // --- ADD 2008/08/21 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/21 Partsman�p�ɕύX
        /* --- DEL 2008/08/21 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �o�^����
        /// </summary>
        /// <param name="retTotalCnt"></param>
        /// <param name="enterpriseCode"></param>        
        /// <param name="setTotalDay"></param>
        /// <param name="totalDay"></param>
        /// <returns></returns>
        public int RegistDmdData(out int retTotalCnt,string enterpriseCode,string sectionCode,DateTime addUpdate,DateTime addUpYM,int totalDay,int mode,out string msg)
        {

            MonthlyAddUpWork monthlyAddupWork = new MonthlyAddUpWork();
            monthlyAddupWork.AddUpSecCode = sectionCode;
            monthlyAddupWork.EnterpriseCode = enterpriseCode;
            monthlyAddupWork.CompanyTotalDay = totalDay;
            monthlyAddupWork.AddUpDate = addUpdate; 
            monthlyAddupWork.AddUpYearMonth = addUpYM;

            monthlyAddupWork.ProcCntntsFlag = mode; // 1 �d�������X�V�@2 ���㌎���X�V
                        
            object paraObj = monthlyAddupWork;
            object retObj = (object)monthlyAddupWork;
            bool dbTimeOut;

            int status = this._iMonthlyAddUpDB.Write(ref paraObj, out retObj, out dbTimeOut, out msg);

            retTotalCnt = 0;            
            
            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retTotalCnt"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="setCustomer"></param>
        /// <param name="setTotalDay"></param>
        /// <param name="totalDay"></param>
        /// <param name="target"></param>
        /// <param name="mode"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int BanishDmdData(out int retTotalCnt, string enterpriseCode, string sectionCode, int totalDay,DateTime addUpDate,DateTime addUpDateYM,int mode,out string msg)
        {
            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();
            
            monthlyAddUpWork.EnterpriseCode = enterpriseCode;
            monthlyAddUpWork.AddUpSecCode = sectionCode;
            monthlyAddUpWork.CompanyTotalDay = totalDay; //����            
            monthlyAddUpWork.ProcCntntsFlag = mode; // 1 �����X�V 2 ���㌎���X�V
            monthlyAddUpWork.AddUpYearMonth = addUpDateYM;
            monthlyAddUpWork.AddUpDate = addUpDate;

            object paraObj = monthlyAddUpWork;
            MonthlyAddUpStatusWork monthlyAddUpStatusWork = new MonthlyAddUpStatusWork();
            object retObj = (object)monthlyAddUpWork;
            bool dbtimeOut;

            int status = this._iMonthlyAddUpDB.Delete(ref paraObj,out retObj,out dbtimeOut,out msg);

            retTotalCnt = 0;

            return status;

        }
           --- DEL 2008/08/21 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/21 Partsman�p�ɕύX

        #endregion

        #region ��Private Method

        #region DEL 2008/08/21 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/21 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���[�J���t�@�C���Ǎ��ݏ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J���t�@�C����Ǎ���ŁA����Static�ɕێ����܂��B</br>
        /// <br>Programer  : �n糋M�T</br>
        /// <br>Date       : 2006.12.19</br>
        /// </remarks>
        private void SearchOfflineData()
        {
            // �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
            OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

            // --- Search�p --- //
            // KeyList�ݒ�
            string[] carrierKeys = new string[1];
            carrierKeys[0] = LoginInfoAcquisition.EnterpriseCode;
            // ���[�J���t�@�C���Ǎ��ݏ���
            object wkObj = offlineDataSerializer.DeSerialize("CustDmdPrcAcs", carrierKeys);
            // ArrayList�ɃZ�b�g
            ArrayList wkList = wkObj as ArrayList;

            if ((wkList != null) &&
                (wkList.Count != 0))
            {
                // �L�����A�N���X���[�J�[�N���X�iArrayList�j �� UI�N���X�iStatic�j�ϊ�����
                //				CopyToStaticFromWorker(wkList);
            }
        }
           --- DEL 2008/08/21 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/21 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        // --- ADD 2008/08/21 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���Аݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        private int LoadCompanyInf()
        {
            int status = 0;

            try
            {
                status = this._companyInfAcs.Read(out this._companyInf, LoginInfoAcquisition.EnterpriseCode);
                if (status != 0)
                {
                    this._companyInf = new CompanyInf();
                }
            }
            catch
            {
                this._companyInf = new CompanyInf();
            }

            return (status);
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^�Ǎ�
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        private int LoadStockMngTtlSt()
        {
            int status = 0;
            this._stockMngTtlSt = new StockMngTtlSt();

            try
            {
                ArrayList retList;
                status = this._stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (StockMngTtlSt stockMngTtlSt in retList)
                    {
                        if (stockMngTtlSt.SectionCode.Trim() == "00")
                        {
                            this._stockMngTtlSt = stockMngTtlSt;
                            break;
                        }
                    }
                }
            }
            catch
            {
                this._stockMngTtlSt = new StockMngTtlSt();
            }

            return (status);
        }

        /// <summary>
        /// �݌ɍX�V�敪�擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="targetYearMonth">�Ώ۔N��</param>
        /// <param name="monAddUpUpdDiv">����d���敪(0:����@1:�d��)</param>
        /// <returns>�݌ɍX�V�敪</returns>
        private int GetStockUpdDiv(string sectionCode, DateTime targetYearMonth, int monAddUpUpdDiv)
        {
            int stockUpdDiv = 0;

            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;

            int status;

            if (monAddUpUpdDiv == 0)
            {
                // ���㌎���X�V�̏ꍇ�A�d�������X�V�����擾
                status = GetHisTotalDayMonthlyAccRecPay(sectionCode,
                                                        1,
                                                        out prevTotalDay,
                                                        out currentTotalDay,
                                                        out prevTotalMonth,
                                                        out currentTotalMonth,
                                                        out convertProcessDivCd);
            }
            else
            {
                // �d�������X�V�̏ꍇ�A���㌎���X�V�����擾
                status = GetHisTotalDayMonthlyAccRecPay(sectionCode,
                                                        0,
                                                        out prevTotalDay,
                                                        out currentTotalDay,
                                                        out prevTotalMonth,
                                                        out currentTotalMonth,
                                                        out convertProcessDivCd);
            }

            if (currentTotalMonth > targetYearMonth)
            {
                // �X�V
                stockUpdDiv = 1;
            }
            else
            {
                // �X�V�Ȃ�
                stockUpdDiv = 2;
            }

            return stockUpdDiv;
        }

        // DEL 2009/04/08 ------>>>
        #region �d�l�ύX�̂��ߍ폜
        ///// <summary>
        ///// �����X�V�敪�擾����
        ///// </summary>
        ///// <param name="targetYearMonth">�Ώ۔N��</param>
        ///// <returns>�X�e�[�^�X</returns>
        //private int GetTermLastDiv(DateTime targetYearMonth)
        //{
        //    int termLastDiv = 0;

        //    DateTime startMonthDate;
        //    DateTime endMonthDate;
        //    DateTime yearMonth;

        //    try
        //    {
        //        this._dateGetAcs.GetLastMonth(out startMonthDate, out endMonthDate, out yearMonth);
                
        //        if ((targetYearMonth.Year == yearMonth.Year) &&
        //            (targetYearMonth.Month == yearMonth.Month))
        //        {
        //            // ����
        //            termLastDiv = 1;
        //        }
        //        else
        //        {
        //            // �����ȊO
        //            termLastDiv = 0;
        //        }
        //    }
        //    catch
        //    {
        //        startMonthDate = new DateTime();
        //        endMonthDate = new DateTime();
        //        yearMonth = new DateTime();
        //    }

        //    return termLastDiv;
        //}
        #endregion
        // DEL 2009/04/08 ------<<<

        // ADD 2009/04/08 ------>>>
        /// <summary>
        /// �����X�V�敪�擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="targetYearMonth">�Ώ۔N��</param>
        /// <param name="procCntntsFlag">�������e�t���O(1:������@2:�����X�V)</param>
        /// <param name="monAddUpUpdDiv">����d���敪(0:����@1:�d��)</param>
        /// <param name="ps">���|�I�v�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        //private int GetTermLastDiv(string sectionCode, DateTime targetYearMonth, int procCntntsFlag, int monAddUpUpdDiv)      // DEL 2009/05/12
        private int GetTermLastDiv(string sectionCode, DateTime targetYearMonth, int procCntntsFlag, int monAddUpUpdDiv, PurchaseStatus ps)     // ADD 2009/05/12
        {
            int termLastDiv = 0;

            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;

            int status;

            List<DateTime> startMonthDateList;
            List<DateTime> endMonthDateList;
            List<DateTime> yearMonthList;

            if (monAddUpUpdDiv == 0)
            {
                // ���㌎���X�V�̏ꍇ�A�d�������X�V�����擾
                status = GetHisTotalDayMonthlyAccRecPay(sectionCode,
                                                        1,
                                                        out prevTotalDay,
                                                        out currentTotalDay,
                                                        out prevTotalMonth,
                                                        out currentTotalMonth,
                                                        out convertProcessDivCd);
            }
            else
            {
                // �d�������X�V�̏ꍇ�A���㌎���X�V�����擾
                status = GetHisTotalDayMonthlyAccRecPay(sectionCode,
                                                        0,
                                                        out prevTotalDay,
                                                        out currentTotalDay,
                                                        out prevTotalMonth,
                                                        out currentTotalMonth,
                                                        out convertProcessDivCd);
            }

            // ��v�N�x�e�[�u���擾
            this._dateGetAcs.GetFinancialYearTable(out startMonthDateList, out endMonthDateList, out yearMonthList);
            
            if (procCntntsFlag == 2)
            {
                // �X�V��
                //if ((currentTotalMonth > targetYearMonth) &&      // DEL 2009/05/12
                if ((ps == PurchaseStatus.Contract) &&              // ADD 2009/05/12
                    (currentTotalMonth > targetYearMonth) &&
                    ((targetYearMonth.Year == yearMonthList[yearMonthList.Count - 1].Year) &&
                     (targetYearMonth.Month == yearMonthList[yearMonthList.Count - 1].Month)))
                {
                    // ����
                    termLastDiv = 1;
                }
                // ADD 2009/05/12 ------>>>
                else if ((ps != PurchaseStatus.Contract) &&
                         ((targetYearMonth.Year == yearMonthList[yearMonthList.Count - 1].Year) &&
                          (targetYearMonth.Month == yearMonthList[yearMonthList.Count - 1].Month)))
                {
                    // ���|�I�v�V�����𓱓����Ă��Ȃ��ꍇ�́A�Ώ۔N���Ɖ�v�N�x�e�[�u���Ŋ�������
                    // ����
                    termLastDiv = 1;
                }
                // ADD 2009/05/12 ------<<<
            }
            else
            {
                // �����
                //if (((currentTotalMonth.Year >= yearMonthList[0].Year) &&     // DEL 2009/05/12
                if ((ps == PurchaseStatus.Contract) &&                          // ADD 2009/05/12
                    ((currentTotalMonth.Year >= yearMonthList[0].Year) &&
                     (currentTotalMonth.Month >= yearMonthList[0].Month)) &&
                    ((targetYearMonth.Year == yearMonthList[0].Year) &&
                     (targetYearMonth.Month == yearMonthList[0].Month)))
                {
                    // ����
                    termLastDiv = 1;
                }
                // ADD 2009/05/12 ------>>>
                else if ((ps != PurchaseStatus.Contract) &&
                         ((targetYearMonth.Year == yearMonthList[0].Year) &&
                          (targetYearMonth.Month == yearMonthList[0].Month)))
                {
                    // ���|�I�v�V�����𓱓����Ă��Ȃ��ꍇ�́A�Ώ۔N���Ɖ�v�N�x�e�[�u���Ŋ�������
                    // ����
                    termLastDiv = 1;
                }
                // ADD 2009/05/12 ------<<<
            }
            
            return termLastDiv;
        }
        // ADD 2009/04/08 ------<<<
        
        /// <summary>
        /// ���񌎎��������擾����
        /// </summary>
        /// <param name="targetYearMonth">�Ώ۔N��</param>
        /// <returns>�X�e�[�^�X</returns>
        private DateTime GetThisMonAddUpProcDay(DateTime targetMonth)
        {
            DateTime startDate;
            DateTime endDate;

            try
            {
                this._dateGetAcs.GetDaysFromMonth(targetMonth, out startDate, out endDate);
            }
            catch
            {
                startDate = new DateTime();
                endDate = new DateTime();
            }

            return endDate;
        }

        /// <summary>
        /// �O�񌎎��������擾����
        /// </summary>
        /// <param name="targetYearMonth">�Ώ۔N��</param>
        /// <returns>�X�e�[�^�X</returns>
        private DateTime GetLastMonAddUpProcDay(DateTime targetMonth)
        {
            DateTime startDate;
            DateTime endDate;

            try
            {
                this._dateGetAcs.GetDaysFromMonth(targetMonth, out startDate, out endDate);
            }
            catch
            {
                startDate = new DateTime();
                endDate = new DateTime();
            }

            if (startDate == DateTime.MinValue)
            {
                return startDate;
            }
            else
            {
                return startDate.AddDays(-1);
            }
        }

        /// <summary>
        /// �����X�V�p�����[�^���[�N�N���X�擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="procCntntsFlag">�������e�t���O(1:������@2:�����X�V)</param>
        /// <param name="addUpYearMonth">�v��N��</param>
        /// <param name="prevTotalDay">�O�񌎎�������</param>
        /// <param name="currentTotalDay">���񌎎�������</param>
        /// <param name="monAddUpUpdDiv">����d���敪(0:����@1:�d��)</param>
        /// <returns></returns>
        private MonthlyAddUpWork GetMonthlyAddUpWork(string enterpriseCode,
                                                     string sectionCode,
                                                     int procCntntsFlag,
                                                     DateTime addUpYearMonth,
                                                     DateTime prevTotalDay,
                                                     DateTime currentTotalDay,
                                                     int monAddUpUpdDiv)
        {
            // ADD 2009/04/08 ------>>>
            // ���t�擾���W���[���Ǝ��Џ��̍ŐV��
            this._dateGetAcs.ReloadCompanyInf();
            LoadCompanyInf();
            // ADD 2009/04/08 ------<<<
            
            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();

            monthlyAddUpWork.EnterpriseCode = enterpriseCode;                                   // ��ƃR�[�h
            monthlyAddUpWork.AddUpSecCode = sectionCode;                                        // ���_�R�[�h
            monthlyAddUpWork.CompanyTotalDay = this._companyInf.CompanyTotalDay;                // ���В���            
            monthlyAddUpWork.ProcCntntsFlag = procCntntsFlag;                                   // �������e�t���O
            monthlyAddUpWork.AddUpDate = GetThisMonAddUpProcDay(currentTotalDay);               // �v��N����
            monthlyAddUpWork.AddUpYearMonth = addUpYearMonth;                                   // �v��N��
            monthlyAddUpWork.StockPointWay = this._stockMngTtlSt.StockPointWay;                 // �݌ɕ]�����@
            monthlyAddUpWork.FractionProcCd = this._stockMngTtlSt.FractionProcCd;               // �[�������敪
            monthlyAddUpWork.ThisMonAddUpProcDay = GetThisMonAddUpProcDay(currentTotalDay);     // ���񌎎�������
            monthlyAddUpWork.LstMonAddUpProcDay = GetLastMonAddUpProcDay(currentTotalDay);      // �O�񌎎�������
            monthlyAddUpWork.AddUpDateSt = GetLastMonAddUpProcDay(currentTotalDay);
            monthlyAddUpWork.AddUpDateEd = GetThisMonAddUpProcDay(currentTotalDay);
            //ADD START zhouyu 2011/07/15 FOR �A�� 42
            monthlyAddUpWork.DataSaveMonths = this._companyInf.DataSaveMonths;                  //�f�[�^�ۑ�����
            monthlyAddUpWork.ResultDtSaveMonths = this._companyInf.ResultDtSaveMonths;          //���уf�[�^�ۑ�����
            monthlyAddUpWork.CaPrtsDtSaveMonths = this._companyInf.CaPrtsDtSaveMonths;          //���q���i�f�[�^�ۑ�����
            monthlyAddUpWork.MasterSaveMonths = this._companyInf.MasterSaveMonths;              //�}�X�^�ۑ�����
            //ADD END zhouyu 2011/07/15 FOR �A�� 42

            // ADD 2009/05/12 ------>>>
            // ���|�I�v�V��������
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            // ADD 2009/05/12 ------<<<
                
            // �X�V�������̂ݍ݌ɍX�V�敪�Z�b�g
            if (procCntntsFlag == 2)
            {
                // ADD 2009/05/12 ------>>>
                //// ���|�I�v�V��������
                //PurchaseStatus ps;
                //ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
                // ADD 2009/05/12 ------<<<
                if (ps == PurchaseStatus.Contract)
                {
                    // �݌ɍX�V�敪�擾(1:�X�V�@2:�X�V�Ȃ�)
                    monthlyAddUpWork.StockUpdDiv = GetStockUpdDiv(sectionCode, addUpYearMonth, monAddUpUpdDiv);
                }
                else
                {
                    // �݌ɍX�V�敪�擾(1:�X�V�@2:�X�V�Ȃ�)
                    // ���|�I�v�V�����𓱓����Ă��Ȃ��ꍇ�́A�������ɍX�V
                    monthlyAddUpWork.StockUpdDiv = 1;
                }
            }

            // �����X�V�敪�擾(0:�����ȊO�@1:����)
            //monthlyAddUpWork.TermLastDiv = GetTermLastDiv(addUpYearMonth);    // DEL 2009/04/08
            //monthlyAddUpWork.TermLastDiv = GetTermLastDiv(sectionCode, addUpYearMonth, procCntntsFlag, monAddUpUpdDiv);     // ADD 2009/04/08
            monthlyAddUpWork.TermLastDiv = GetTermLastDiv(sectionCode, addUpYearMonth, procCntntsFlag, monAddUpUpdDiv, ps);     // ADD 2009/05/12

            return monthlyAddUpWork;
        }
        // --- ADD 2008/08/21 ---------------------------------------------------------------------<<<<<

        #endregion
    }
}
