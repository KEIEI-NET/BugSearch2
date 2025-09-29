# region ※using
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
    /// 納入先確認画面 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 納入先確認画面用のデータ検索等を行います。</br>
    /// <br>Programmer	: 20056　對馬 大輔</br>
    /// <br>Date		: 2007.09.28</br>
    /// <br></br>
    /// <br>Note		: 納入先確認不具合対応</br>
    /// <br>Programmer	: 脇田 靖之</br>
    /// <br>Date		: 2013/04/17</br>
    /// </remarks>
    public class AddresseeAcs
    {
        # region ■Private Member

        private string _enterpriseCode;                     // 企業コード
        private string _loginSectionCode;                   // 自拠点コード
        private Addressee _addressee;                       // 納入先確認画面データクラス
        private CustomerInfoAcs _customerInfoAcs;           // 得意先アクセスクラス
        private static SecInfoAcs _secInfoAcs;              // 拠点アクセスクラス
        // --- UPD 2013/04/17 Y.Wakita ---------->>>>>
        //private bool _isLocalDBRead = true;
        private bool _isLocalDBRead = false;
        // --- UPD 2013/04/17 Y.Wakita ----------<<<<<
        private GuideMode _guideMode = GuideMode.Addressee; // ガイドモード
        private string _addUpSectionCode;                   // 計上拠点コード
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";

        # endregion

        #region ■enum
        /// <summary>
        /// 起動タイプ
        /// </summary>
        public enum GuideMode : int
        {
            Customer = 1, //得意先
            Addressee = 2, //納入先
            CustomerClaim = 3, //請求先
        }
        #endregion

        # region ■Constracter
        /// <summary>
        /// 納入先確認画面アクセスクラスコンストラクタ
        /// </summary>
        public AddresseeAcs()
        {
            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 自拠点コードを取得する
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // 各アクセスクラスのインスタンス化
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerInfoAcs.IsLocalDBRead = _isLocalDBRead;
            this._addressee = new Addressee();

            // 拠点情報の取得
            string selectedSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            string addUpSectionCode;
            string addUpSectionName;
            this.GetOwnSeCtrlCode(selectedSectionCode, out addUpSectionCode, out addUpSectionName);

            this._addUpSectionCode = addUpSectionCode;
        }
        # endregion

        #region■Property
        /// <summary>ガイドモードプロパティ</summary>
        public GuideMode Mode
        {
            set { this._guideMode = value; }
            get { return this._guideMode; }
        }

        /// <summary>納入先確認画面データクラスプロパティ</summary>
        public Addressee Addressee
        {
            set { this._addressee = value; }
            get { return this._addressee; }
        }

        /// <summary>ローカルDB読み込みモードプロパティ</summary>
        public bool IsLocalDBRead
        {
            // --- UPD 2013/04/17 Y.Wakita ---------->>>>>
            //set { this._isLocalDBRead = true; }
            set { this._isLocalDBRead = value; }
            // --- UPD 2013/04/17 Y.Wakita ----------<<<<<
            get { return this._isLocalDBRead; }
        }
        #endregion

        #region■public Method
        /// <summary>
        /// 得意先読み込み処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerInfo">得意先情報クラス</param>
        /// <returns>読み込みステータス</returns>
        public int ReadCustomer(int customerCode, out CustomerInfo customerInfo)
        {
            return this.ReadCustomerProc(customerCode, out customerInfo);
        }

        /// <summary>
        /// データキャッシュ処理
        /// </summary>
        /// <param name="customerInfo">得意先情報クラス</param>
        /// <param name="custSuppli">得意先仕入情報クラス</param>
        /// <param name="addUpdate">計上日付</param>
        public void Cache(CustomerInfo customerInfo)
        {
            this.cacheProc(customerInfo);
        }
        # endregion

        #region ■Private Method
        /// <summary>
        /// 拠点制御アクセスクラスインスタンス化処理
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

            // ログイン担当拠点情報の取得
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// 制御機能拠点取得処理
        /// </summary>
        /// <param name="sectionCode">対象拠点コード</param>
        /// <param name="ctrlSectionCode">対象制御拠点コード</param>
        /// <param name="ctrlSectionName">対象制御拠点名称</param>
        public int GetOwnSeCtrlCode(string sectionCode, out string ctrlSectionCode, out string ctrlSectionName)
        {
            // 拠点制御アクセスクラスインスタンス化処理
            this.CreateSecInfoAcs();

            // 対象制御拠点の初期値はログイン担当拠点
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
                            // 拠点制御設定がされていない
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
        /// 得意先・得意先仕入情報読み込み処理
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
            // 業販先以外は得意先情報をクリアする
            if (customerInfo.AcceptWholeSale == 0)
            {
                customerInfo = null;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// データキャッシュ処理
        /// </summary>
        /// <param name="customerInfo">得意先情報クラス</param>
        /// <param name="custSuppli">得意先仕入情報クラス</param>
        /// <param name="addUpdate">計上日付</param>
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
