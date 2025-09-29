using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

using Broadleaf.Web.Services;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 簡単問合せID変換アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/04/06</br>
    /// <br>Note       : IDExchangeサービスの変更に伴う対応</br>
    /// <br>Programmer : 30434　工藤 恵優</br>
    /// <br>Date       : 2010/06/25</br>
    /// </remarks>
    public class SimplInqIDExchangeAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■ Private Member

        /// <summary>アプリケーション構成クラス用シリアライズキー</summary>
        private static readonly string[] AppConfigKey = new string[] { typeof(SimplInqIDExchangeAcs).Name, "AppConfigKey" };
        /// <summary>アプリケーション設定ファイル名</summary>
        private static readonly string AppConfigFileName = "PMSCM01040A_Config.dat";
		/// <summary>更新チェックWebサービスURL</summary>
		private static string WebServiceURL = String.Empty;
		/// <summary>アプリケーション構成保持クラス</summary>
		private static SimplInqIDExchangeAppConfig AppConfig;

        private SFINQ06740ABServices _service =null;

        #endregion

        // ===================================================================================== //
        // 列挙体
        // ===================================================================================== //
        #region ■ Public Enum
        /// <summary>
        /// 簡単問合せのシステムコード
        /// </summary>
        public enum SimpleInqIdCngSysCd : int
        {
            Partsman = 300
        }
        
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■ Costructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SimplInqIDExchangeAcs()
        {
            if (_service == null)
            {
                string msg = string.Empty;
                this.GetService(out msg);
            }
            // ADD 2010/06/25 IDExchangeサービスの変更に伴う対応 ---------->>>>>
            ChannelServices.RegisterChannel(new IpcClientChannel(), true);
            // ADD 2010/06/25 IDExchangeサービスの変更に伴う対応 ----------<<<<<
        }

        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■ Public Method

        /// <summary>
        /// アカウント変換処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="smplInqInf">簡単問合せID情報管理マスタオブジェクト</param>
        /// <param name="smplInqBas">簡単問合せID付属情報マスタ(基本情報)オブジェクト</param>
        /// <param name="errorMsg">エラーメッセージ</param>
        /// <returns></returns>
        public int ExchangeAcntId(string enterpriseCode, string employeeCode, out SmplInqInf smplInqInf, out SmplInqBas smplInqBas, out string errorMsg)
        {
            errorMsg = string.Empty;
            smplInqInf = null;
            smplInqBas = null;
            int status = 0;

            if (_service == null)
            {
                status = this.GetService(out errorMsg);
                if (status != 0) return status;
            }

            SmplInqBasWork smplInqBasWork;
            SmplInqInfWork smplInqInfWork;
            status = _service.ExchangeAcntId(this.GetAuthenticateCode(), (int)SimpleInqIdCngSysCd.Partsman, enterpriseCode, employeeCode, out smplInqInfWork, out smplInqBasWork, out errorMsg);
            if (status == 0)
            {
                smplInqInf = CopyToPrmFromWork(smplInqInfWork);
                smplInqBas = CopyToPrmFromWork(smplInqBasWork);
            }

            return status;
        }

        /// <summary>
        /// UNDONE:アカウント情報検索処理
        /// </summary>
        /// <param name="simplInqAcntAcntId">簡単問合せアカウントID</param>
        /// <param name="smplInqInf">簡単問合せID情報管理マスタオブジェクト</param>
        /// <param name="smplInqBas">簡単問合せID付属情報マスタ(基本情報)オブジェクト</param>
        /// <param name="smplInqChgList">簡単問合せID変換マスタオブジェクトリスト</param>
        /// <param name="errorMsg">エラーメッセージ</param>
        /// <returns></returns>
        public int SearchRelatedSmplInqInf(string simplInqAcntAcntId, out SmplInqInf smplInqInf, out SmplInqBas smplInqBas,out List<SmplInqChg> smplInqChgList, out string errorMsg)
        {
            // ADD 2010/06/25 IDExchangeサービスの変更に伴う対応 ---------->>>>>
            smplInqInf = new SmplInqInf();
            smplInqBas = new SmplInqBasExt();
            smplInqChgList = new List<SmplInqChg>();
            errorMsg = string.Empty;

            // 認証コードを取得
            string authenticateCode = this.GetAuthenticateCode();

            // 企業コードを検索
            string nsEnterpriseCode = string.Empty;
            int status = SearchNSEnterpriseCode(
                authenticateCode,
                simplInqAcntAcntId,
                out nsEnterpriseCode,
                out errorMsg
            );
            if (status.Equals(0))
            {
                smplInqBas.EnterpriseCode = nsEnterpriseCode;
            }
            else
            {
                smplInqBas = null;  // 呼出し側でnullの判定でエラー処理をしているので、nullで返す
            }

            // 簡単問合せアカウントグループIDを検索
            status = SearchSimplInqAcntGrpId(
                authenticateCode,
                simplInqAcntAcntId,
                (SmplInqBasExt)smplInqBas,
                out errorMsg
            );
            if (!status.Equals(0))
            {
                smplInqBas = null;  // 呼出し側でnullの判定でエラー処理をしているので、nullで返す
            }

            return status;
            // ADD 2010/06/25 IDExchangeサービスの変更に伴う対応 ----------<<<<<
            // DEL 2010/06/25 IDExchangeサービスの変更に伴う対応 ---------->>>>>
            #region 削除コード

            //smplInqInf=null;
            //smplInqBas=null;
            //smplInqChgList=null;
            //errorMsg = string.Empty;
            //int status = 0;

            //if (_service == null)
            //{
            //    status = this.GetService(out errorMsg);
            //    if (status != 0) return status;
            //}

            //SmplInqBasWork smplInqBasWork;
            //SmplInqInfWork smplInqInfWork;
            //SmplInqChgWork[] smplInqChgWorkList;
            //status = _service.SearchRelatedSmplInqInf(this.GetAuthenticateCode(), simplInqAcntAcntId, out smplInqInfWork, out smplInqBasWork,out smplInqChgWorkList, out errorMsg);

            //if (status == 0)
            //{
            //    smplInqInf=CopyToPrmFromWork(smplInqInfWork);
            //    smplInqBas=CopyToPrmFromWork(smplInqBasWork);
            //    if (smplInqChgWorkList!=null && smplInqChgWorkList.Length>0)
            //    {
            //        smplInqChgList=new List<SmplInqChg>();
            //        foreach(SmplInqChgWork work in smplInqChgWorkList)
            //        {
            //            smplInqChgList.Add(CopyToPrmFromWork( work));
            //        }
            //    }
            //}
            //return status;

            #endregion // 削除コード
            // DEL 2010/06/25 IDExchangeサービスの変更に伴う対応 ----------<<<<<
        }

        #endregion


        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■ Private Method

        /// <summary>
        /// サービス取得
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        private int GetService(out string errorMsg)
        {
            errorMsg = string.Empty;
            if (_service != null) return 0;

            if (AppConfig == null)
            {
                GetApplicationConfig();
            }

            if (AppConfig == null)
            {
                errorMsg = "構成ファイルの読み込みに失敗しました";
                return -1;
            }

            try
            {
                _service = new SFINQ06740ABServices(AppConfig.WebServiceURL);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return -2;
            }

            return 0;
        }

        /// <summary>
        /// WebサービスのURL取得
        /// </summary>
        /// <returns></returns>
        private string GetAuthenticateCode()
        {
            //string authenticateCode = ExchgWebServiceAuthentication.GetAuthenticateString();
            //System.Diagnostics.Trace.WriteLine(authenticateCode);
            //return authenticateCode;
            return ExchgWebServiceAuthentication.GetAuthenticateString();
        }

        /// <summary>
		/// アプリケーション構成情報取得処理
		/// </summary>
        private static void GetApplicationConfig()
        {
            try
            {
                string path = System.IO.Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, AppConfigFileName);
                // アプリケーション構成情報取得
                if (UserSettingController.ExistUserSetting(path))
                {
                    AppConfig = UserSettingController.DecryptionDeserializeUserSetting<SimplInqIDExchangeAppConfig>(path, AppConfigKey);
                }
            }
            catch (Exception ex)
            {
            }

            if (AppConfig == null)
            {
            }
            else
            {
                WebServiceURL = AppConfig.WebServiceURL;	// 更新チェックWebサービスURL
                //if (WebServiceURL.Contains("%Infomation%"))
                //{
                //    WebServiceURL = WebServiceURL.Replace("%Infomation%", GetWebTopPageURLFromPMC());
                //}
            }
        }

        /// <summary>
        /// 認証情報よりInfomationのURL取得
        /// </summary>
        /// <returns></returns>
        private static string GetWebServiceURLFromPMC()
        {
            string url = string.Empty;
            //url = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.IndexCode_Infomation);	// 更新チェックWebサービスURL
            //url += LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Infomation, ConstantManagement_SF_PRO.IndexCode_Infomation);

            return url;
        }

        #region クラス間コピー

        /// <summary>
        /// UIデータ⇒リモートパラメータ変換
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private SmplInqInfWork CopyToWorkFromPrm(SmplInqInf src)
        {
            SmplInqInfWork dst = new SmplInqInfWork();
            #region コピー
            dst.CreateDateTime = src.CreateDateTime;            // 作成日時
            dst.UpdateDateTime = src.UpdateDateTime;            // 更新日時
            dst.LogicalDeleteCode = src.LogicalDeleteCode;      // 論理削除区分
            dst.SimpleInqIdInfMngNo = src.SimpleInqIdInfMngNo;  // 簡単問合せID付属情報管理番号
            dst.SimplInqAcntAcntId = src.SimplInqAcntAcntId;    // 簡単問合せアカウントID
            dst.SimplInqAcntPass = src.SimplInqAcntPass;        // 簡単問合せアカウントパスワード
            #endregion
            return dst;
        }

        /// <summary>
        /// リモートパラメータ⇒UIデータ変換
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private SmplInqInf CopyToPrmFromWork(SmplInqInfWork src)
        {
            SmplInqInf dst = new SmplInqInf();
            #region コピー
            dst.CreateDateTime = src.CreateDateTime;            // 作成日時
            dst.UpdateDateTime = src.UpdateDateTime;            // 更新日時
            dst.LogicalDeleteCode = src.LogicalDeleteCode;      // 論理削除区分
            dst.SimpleInqIdInfMngNo = src.SimpleInqIdInfMngNo;  // 簡単問合せID付属情報管理番号
            dst.SimplInqAcntAcntId = src.SimplInqAcntAcntId;    // 簡単問合せアカウントID
            dst.SimplInqAcntPass = src.SimplInqAcntPass;        // 簡単問合せアカウントパスワード
            #endregion
            return dst;
        }

        /// <summary>
        /// UIデータ⇒リモートパラメータ変換
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private SmplInqBasWork CopyToWorkFromPrm(SmplInqBas src)
        {
            SmplInqBasWork dst = new SmplInqBasWork();
            #region コピー
            dst.CreateDateTime = src.CreateDateTime;            // 作成日時
            dst.UpdateDateTime = src.UpdateDateTime;            // 更新日時
            dst.LogicalDeleteCode = src.LogicalDeleteCode;      // 論理削除区分
            dst.SimpleInqIdInfMngNo = src.SimpleInqIdInfMngNo;  // 簡単問合せID付属情報管理番号
            dst.Name = src.Name;                                // 名称
            dst.Name2 = src.Name2;                              // 名称2
            dst.Kana = src.Kana;                                // カナ
            dst.SexCode = src.SexCode;                          // 性別コード
            dst.SexName = src.SexName;                          // 性別名称
            dst.Birthday = src.Birthday;                        // 生年月日
            dst.PostNo = src.PostNo;                            // 郵便番号
            dst.AddressCode1Upper = src.AddressCode1Upper;      // 都道府県コード
            dst.WebDspAddrADOJp = src.WebDspAddrADOJp;          // WEB表示住所(都道府県)
            dst.WebDspAddrCity = src.WebDspAddrCity;            // WEB表示住所(区市町村)
            dst.WebDspAddrBuil = src.WebDspAddrBuil;            // WEB表示住所(ビル･マンション名)
            dst.JobTypeCode = src.JobTypeCode;                  // 職種コード
            dst.BusinessTypeCode = src.BusinessTypeCode;        // 業種コード
            dst.HomeTelNo = src.HomeTelNo;                      // 自宅TEL
            dst.OfficeTelNo = src.OfficeTelNo;                  // 電話番号（勤務先）
            dst.PortableTelNo = src.PortableTelNo;              // 電話番号（携帯）
            dst.HomeFaxNo = src.HomeFaxNo;                      // FAX番号（自宅）
            dst.OfficeFaxNo = src.OfficeFaxNo;                  // FAX番号（勤務先）
            dst.MailAddress1 = src.MailAddress1;                // メールアドレス1
            dst.MailAddrKindCode1 = src.MailAddrKindCode1;      // メールアドレス種別コード1
            dst.MailAddress2 = src.MailAddress2;                // メールアドレス2
            dst.MailAddrKindCode2 = src.MailAddrKindCode2;      // メールアドレス種別コード2
            dst.MailAddress3 = src.MailAddress3;                // メールアドレス3
            dst.MailAddrKindCode3 = src.MailAddrKindCode3;      // メールアドレス種別コード3
            dst.EnterpriseCode = src.EnterpriseCode;            // 企業コード
            dst.EnterpriseName = src.EnterpriseName;            // 企業名称
            #endregion
            return dst;
        }

        /// <summary>
        /// リモートパラメータ⇒UIデータ変換
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private SmplInqBas CopyToPrmFromWork(SmplInqBasWork src)
        {
            SmplInqBas dst = new SmplInqBas();
            #region コピー
            dst.CreateDateTime = src.CreateDateTime;            // 作成日時
            dst.UpdateDateTime = src.UpdateDateTime;            // 更新日時
            dst.LogicalDeleteCode = src.LogicalDeleteCode;      // 論理削除区分
            dst.SimpleInqIdInfMngNo = src.SimpleInqIdInfMngNo;  // 簡単問合せID付属情報管理番号
            dst.Name = src.Name;                                // 名称
            dst.Name2 = src.Name2;                              // 名称2
            dst.Kana = src.Kana;                                // カナ
            dst.SexCode = src.SexCode;                          // 性別コード
            dst.SexName = src.SexName;                          // 性別名称
            dst.Birthday = src.Birthday;                        // 生年月日
            dst.PostNo = src.PostNo;                            // 郵便番号
            dst.AddressCode1Upper = src.AddressCode1Upper;      // 都道府県コード
            dst.WebDspAddrADOJp = src.WebDspAddrADOJp;          // WEB表示住所(都道府県)
            dst.WebDspAddrCity = src.WebDspAddrCity;            // WEB表示住所(区市町村)
            dst.WebDspAddrBuil = src.WebDspAddrBuil;            // WEB表示住所(ビル･マンション名)
            dst.JobTypeCode = src.JobTypeCode;                  // 職種コード
            dst.BusinessTypeCode = src.BusinessTypeCode;        // 業種コード
            dst.HomeTelNo = src.HomeTelNo;                      // 自宅TEL
            dst.OfficeTelNo = src.OfficeTelNo;                  // 電話番号（勤務先）
            dst.PortableTelNo = src.PortableTelNo;              // 電話番号（携帯）
            dst.HomeFaxNo = src.HomeFaxNo;                      // FAX番号（自宅）
            dst.OfficeFaxNo = src.OfficeFaxNo;                  // FAX番号（勤務先）
            dst.MailAddress1 = src.MailAddress1;                // メールアドレス1
            dst.MailAddrKindCode1 = src.MailAddrKindCode1;      // メールアドレス種別コード1
            dst.MailAddress2 = src.MailAddress2;                // メールアドレス2
            dst.MailAddrKindCode2 = src.MailAddrKindCode2;      // メールアドレス種別コード2
            dst.MailAddress3 = src.MailAddress3;                // メールアドレス3
            dst.MailAddrKindCode3 = src.MailAddrKindCode3;      // メールアドレス種別コード3
            dst.EnterpriseCode = src.EnterpriseCode;            // 企業コード
            dst.EnterpriseName = src.EnterpriseName;            // 企業名称
            #endregion
            return dst;
        }

        /// <summary>
        /// UIデータ⇒リモートパラメータ変換
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private SmplInqChgWork CopyToWorkFromPrm(SmplInqChg src)
        {
            SmplInqChgWork dst = new SmplInqChgWork();
            #region コピー
            dst.CreateDateTime = src.CreateDateTime;            // 作成日時
            dst.UpdateDateTime = src.UpdateDateTime;            // 更新日時
            dst.LogicalDeleteCode = src.LogicalDeleteCode;      // 論理削除区分
            dst.SimpleInqIdInfMngNo = src.SimpleInqIdInfMngNo;  // 簡単問合せID付属情報管理番号
            dst.SimpleInqIdCngSysCd = src.SimpleInqIdCngSysCd;  // 簡単問合せID変換サービスシステム区分
            dst.OriginalAcntDiskKey = src.OriginalAcntDiskKey;  // 変換元アカウント識別キー
            dst.OriginalAcntId = src.OriginalAcntId;            // 変換元アカウントID
            #endregion

            return dst;
        }

        /// <summary>
        /// リモートパラメータ⇒UIデータ変換
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private SmplInqChg CopyToPrmFromWork(SmplInqChgWork src)
        {
            SmplInqChg dst = new SmplInqChg();
            #region コピー
            dst.CreateDateTime = src.CreateDateTime;            // 作成日時
            dst.UpdateDateTime = src.UpdateDateTime;            // 更新日時
            dst.LogicalDeleteCode = src.LogicalDeleteCode;      // 論理削除区分
            dst.SimpleInqIdInfMngNo = src.SimpleInqIdInfMngNo;  // 簡単問合せID付属情報管理番号
            dst.SimpleInqIdCngSysCd = src.SimpleInqIdCngSysCd;  // 簡単問合せID変換サービスシステム区分
            dst.OriginalAcntDiskKey = src.OriginalAcntDiskKey;  // 変換元アカウント識別キー
            dst.OriginalAcntId = src.OriginalAcntId;            // 変換元アカウントID
            #endregion
            return dst;
        }

        #endregion

        // ADD 2010/06/25 IDExchangeサービスの変更に伴う対応 ---------->>>>>
        /// <summary>
        /// CMTアカウントID から NS企業コード を検索します。
        /// </summary>
        /// <remarks>
        /// コミュニケーションツール本体を経由して
        ///
        /// アカウントID --> アカウントIDが所属する企業コード 
        ///
        /// を取得します。
        /// CTI機能等で、かかってきた相手の企業コードが必要な場合等でご使用ください。
        /// 
        /// まず、下記アセンブリを参照追加してください。
        /// アセンブリは、使用するシステムのディレクトリ以下に配置してください。
        /// (例: SF･BL･CS --> \SuperFrontman 以下へ配置する)
        /// ※コミュニケーションツールのインストーラではインストールを行いません。
        /// 
        /// BLCMTServiceProvider.dll
        /// SFCMN05012E.dll
        /// SFINQ01130I.dll
        /// </remarks>
        /// <param name="authenticateCode">認証コード</param>
        /// <param name="simplInqAcntAcntId">簡単問合せアカウントID（企業コードを取得するアカウントID）</param>
        /// <param name="nsEnterpriseCode">企業コード(取得結果)</param>
        /// <param name="errorMsg">エラーメッセージ</param>
        /// <returns>処理結果ステータス</returns>
        private int SearchNSEnterpriseCode(
            string authenticateCode,
            string simplInqAcntAcntId,
            out string nsEnterpriseCode,
            out string errorMsg
        )
        {
            nsEnterpriseCode= string.Empty;
            errorMsg        = string.Empty;

            //--- 簡単問合せデータサービスプロバイダからインタフェースを取得します
            ISimpleInquiryDataService simpleInquiryDataService = BLCMTServiceProvider.GetISimpleInquiryDataService();

            CMTActGrEpr cmtActGrEpr = null; // CMTアカウントグループ企業情報(プロパティ詳細は別紙のファイルレイアウトを参照してください)
            CMTEprSet   cmtEprSet   = null; // CMT企業設定情報(プロパティ詳細は別紙のファイルレイアウトを参照してください)
            InqCoInfSt  inqCoInfSt  = null; // 簡単問合せ企業設定情報(プロパティ詳細は別紙のファイルレイアウトを参照してください)

            int status = -1;

            //--- 取得したインタフェースを利用して、簡単問合せID(アカウントID)の企業情報を取得します
            try
            {
                status = simpleInquiryDataService.SearchEnterpriseInfo(
                    authenticateCode,
                    simplInqAcntAcntId,
                    out cmtActGrEpr,
                    out cmtEprSet,
                    out inqCoInfSt,
                    out errorMsg
                );

                // 下記クラスのプロパティに企業コードがセットされています。
                // 企業コードが取得できない場合(企業情報関連が設定されていない)は、
                // オブジェクト自体がnullで返るので、nullチェックは行ってください。
                if (status.Equals(0))
                {
                    if (cmtEprSet != null)
                    {
                        // 取得した企業コードをセットする
                        nsEnterpriseCode = cmtEprSet.BLEnterpriseCd.Trim();
                        Debug.Assert(false, "OK: " + nsEnterpriseCode + "<- " + authenticateCode + ", " + simplInqAcntAcntId);
                    }
                    else
                    {
                        Debug.Assert(false, "NG: cmtEprSet がnull" + "<- " + authenticateCode + ", " + simplInqAcntAcntId);
                    }
                }
                else
                {
                    Debug.Assert(false, "NG:エラーコード：" + status.ToString() + "<- " + authenticateCode + ", " + simplInqAcntAcntId);
                }
            }
            catch (Exception ex)
            {
                // コミュニケーションツールに未ログインの状態で上記処理を実行すると例外が発生します。
                Debug.WriteLine(ex);
                errorMsg += Environment.NewLine + ex.Message;
                Debug.Assert(false, "NG:例外\n" + "<- " + authenticateCode + ", " + simplInqAcntAcntId + "\n" + ex.ToString());
            }

            return status;
        }

        /// <summary>
        /// CMTアカウントID から 簡単問合せアカウントグループID を検索します。
        /// </summary>
        /// <remarks>
        /// コミュニケーションツール本体を経由して
        //
        /// アカウントID --> アカウントIDが所属するアカウントグループ 
        ///
        /// を取得します。
        ///
        /// アカウントIDは複数のグループに所属できるので、
        /// 取得できる所属グループが1つとは限らないのでご注意ください
        /// また、ユーザの運用次第では、NS製品の拠点とCMTのアカウントグループ(所属グループ)は
        /// 一致しないケースも考えられるので、
        ///
        /// NSの拠点コード ≠ アカウントグループ
        ///
        /// となるケースが存在する事に注意してください
        ///
        /// まず、下記アセンブリを参照追加してください
        /// アセンブリは、使用するシステムのディレクトリ以下に配置してください
        /// (例: SF･BL･CS --> \SuperFrontman 以下へ配置する)
        /// ※コミュニケーションツールのインストーラではインストールを行いません
        ///
        /// BLCMTServiceProvider.dll
        /// SFCMN05012E.dll
        /// SFINQ01130I.dll
        /// </remarks>
        /// <param name="authenticateCode">認証コード</param>
        /// <param name="simplInqAcntAcntId">簡単問合せアカウントID（企業コードを取得するアカウントID）</param>
        /// <param name="smpInqBasExt">簡単問合せID付属情報マスタ(基本情報)</param>
        /// <param name="errorMsg">エラーメッセージ</param>
        /// <returns>処理結果ステータス</returns>
        private int SearchSimplInqAcntGrpId(
            string authenticateCode,
            string simplInqAcntAcntId,
            SmplInqBasExt smpInqBasExt,
            out string errorMsg
        )
        {
            errorMsg = string.Empty;

            //--- 簡単問合せデータサービスプロバイダからインタフェースを取得します
            ISimpleInquiryDataService simpleInquiryDataService = BLCMTServiceProvider.GetISimpleInquiryDataService();

            List<InqAcntGrp> inqActGrList = null;   // アカウントグループ情報リスト
            int status = -1;

            //--- 取得したインタフェースを利用して、簡単問合せID(アカウントID)の企業情報を取得します
            //    2010/06/25 20:00 時点では、実行するとエラーになりますのでご注意ください
            try
            {
                status = simpleInquiryDataService.SearchInqAcntGrp(
                    authenticateCode,
                    simplInqAcntAcntId,
                    out inqActGrList,
                    out errorMsg
                );

                // 下記クラスのプロパティに企業コードがセットされています。
                // 企業コードが取得できない場合(企業情報関連が設定されていない)は、
                // オブジェクト自体がnullで返るので、nullチェックは行ってください。
                if (status.Equals(0))
                {
                    if (inqActGrList != null)
                    {
                        // リスト内に取得したアカウントグループIDが入っています
                        foreach (InqAcntGrp inqAcntGrp in inqActGrList)
                        {
                            smpInqBasExt.SimplInqAcntGrIdList.Add(inqAcntGrp.SimplInqAcntAcntGrId);
                        }
                    }
                    else
                    {
                        Debug.Assert(false, "NG: inqActGrList がnull" + "<- " + authenticateCode + ", " + simplInqAcntAcntId);
                    }
                }
                else
                {
                    Debug.Assert(false, "NG:エラーコード：" + status.ToString() + "<- " + authenticateCode + ", " + simplInqAcntAcntId);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                errorMsg += Environment.NewLine + ex.Message;
                Debug.Assert(false, "NG:例外\n" + "<- " + authenticateCode + ", " + simplInqAcntAcntId + "\n" + ex.ToString());

                //    2010/06/25 20:00 時点では、実行するとエラーになりますのでご注意ください
                //status = 0; // HACK:2010/06/28 実装されるまで仮対応
            }
            return status;
        }
        // ADD 2010/06/25 IDExchangeサービスの変更に伴う対応 ----------<<<<<

        #endregion
    }

    /// <summary>
    /// 簡単問合せID変換構成ファイル
    /// </summary>
    [Serializable]
    public class SimplInqIDExchangeAppConfig
    {
        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SimplInqIDExchangeAppConfig() { }

        #endregion // </Constructor>

        #region <WebURL>

        /// <summary>WebサービスURL</summary>
        private string _webServiceURL;

        /// <summary>WebサービスURL</summary>
        public string WebServiceURL
        {
            get { return _webServiceURL; }
            set { _webServiceURL = value; }
        }

        #endregion  // WebURL
    }

    // ADD 2010/06/25 IDExchangeサービスの変更に伴う対応 ---------->>>>>
    /// <summary>
    /// 簡単問合せID付属情報マスタ(基本情報)の拡張クラス
    /// </summary>
    public sealed class SmplInqBasExt : SmplInqBas
    {
        /// <summary>簡単問合せアカウントグループIDリスト</summary>
        private readonly List<string> _simplInqAcntGrIdList = new List<string>();
        /// <summary>簡単問合せアカウントグループIDリストを取得します。</summary>
        public List<string> SimplInqAcntGrIdList
        {
            get { return _simplInqAcntGrIdList; }
        }

        #region Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SmplInqBasExt() : base() { }

        #endregion // Constructor
    }
    // ADD 2010/06/25 IDExchangeサービスの変更に伴う対応 ----------<<<<<
}
