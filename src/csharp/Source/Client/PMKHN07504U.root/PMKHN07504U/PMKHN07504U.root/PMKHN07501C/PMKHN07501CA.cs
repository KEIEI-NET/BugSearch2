using System;
//using System.Collections.Generic;
//using System.Text;
using System.Collections;
//using System.Xml;
//using System.IO;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// メールサービス関連 Infomation Base
    /// </summary>
    /// <remarks>
    /// メールサービスで使用する各種設定情報を管理しています。
    /// また、このクラスでDB等の外部通信部分を全て抑えています
    /// 2006.11.04現在 各種Remoteingに関しては作成中ですので、
    /// 処理の度にRemoteing処理が実行されています。
    /// おおよその目処が付き次第、Remoteing処理の実行回数を減らす
    /// チューニングをかけていきます
    /// </remarks>
    public class MailInfoBase
    {

        #region コンストラクタ、各種初期化処理

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mailServiceInfoCreateMode">メールサービス関連情報 生成モード</param>
        public MailInfoBase(MailServiceInfoCreateMode mailServiceInfoCreateMode)
        { 
            // 自拠点コードの取得
            try
            {
                SecInfoAcs secInfoAcs = new SecInfoAcs();
                if (secInfoAcs.SecInfoSet != null)
                {
                    _SectionCode = secInfoAcs.SecInfoSet.SectionCode;
                    _MainOfficeFuncFlag = secInfoAcs.SecInfoSet.MainOfficeFuncFlag;
                }
                else
                {
                    _SectionCode = "";
                }

            }
            catch (Exception)
            {
                _SectionCode = "";
                IsNsSystem = false;
            }

            // 各種情報の初期化
            InitProc(_SectionCode, mailServiceInfoCreateMode);

        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="mailServiceInfoCreateMode">メールサービス関連情報 生成モード</param>
        public MailInfoBase(string sectionCode, MailServiceInfoCreateMode mailServiceInfoCreateMode)
        {
            _SectionCode = sectionCode;

            // 各種情報の初期化
            InitProc(_SectionCode, mailServiceInfoCreateMode);
        }


        /// <summary>
        /// InfoBase初期化処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="mailServiceInfoCreateMode">メールサービス関連情報 生成モード</param>
        private bool InitProc(string sectionCode, MailServiceInfoCreateMode mailServiceInfoCreateMode)
        {

            // 各種プロパティの初期化
            _EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _SectionGuideName =   GetSectionGuideName(sectionCode);
            _MainOfficeFuncFlag = ((SecInfoSet)GetSectionInfo(sectionCode)).MainOfficeFuncFlag;

            // メール文書管理マスタ関連モジュール初期化
            //if (MailInfoBase._MailDocMngAcs == null)
            //{
            //    _MailDocMngAcs = new MailDocMngAcs();
            //}


            // 情報の初期化
            return true;
        }

        #endregion 

        #region static メンバ


        /// <summary>
        /// メール文書区分 0:メール文書(PC)
        /// </summary>
        public static int MailDocCode_Type_PC = 0;
        /// <summary>
        /// メール文書区分 1:携帯メール文書
        /// </summary>
        public static int MailDocCode_Type_Mobile = 1;
        /// <summary>
        /// メール文書区分 2:署名
        /// </summary>
        public static int MailDocCode_Type_Signature = 2;

        /// <summary>
        /// メールステータス定義 0:新規
        /// </summary>
        public static int MailStatus_NEW = MailBackup.MailBackup_MailStatus_NEW;

        /// <summary>
        /// メールステータス定義 5:エラー未送信
        /// </summary>
        public static int MailStatus_ERROR = MailBackup.MailBackup_MailStatus_ERROR;


        private bool IsNsSystem = true;

        /// <summary>
        /// 企業コード(InfoBaseの動作を設定する企業コード)
        /// </summary>
        private string _EnterpriseCode = "";

        /// <summary>
        /// 拠点コード(InfoBaseの動作を設定する拠点コード
        /// </summary>
        private string _SectionCode = "";

        /// <summary>
        /// 拠点名称(InfoBaseの動作を設定する拠点名称
        /// </summary>
        private string _SectionGuideName = "";

        /// <summary>
        /// 本社機能フラグ
        /// </summary>
        private int _MainOfficeFuncFlag = 0;


        //static private MailDocMngAcs _MailDocMngAcs = null;

        //static private DmFirstSetAcs _DmFirstSetAcs = null;

        //static private AlItmDspNmAcs _AlItmDspNmAcs = null;


        #endregion static メンバ

        #region InfoBase リフレッシュ関連


        /// <summary>
        /// 各種情報リフレッシュ(再取得＆初期化)
        /// </summary>
        /// <param name="mailServiceInfoCreateMode">メールサービス関連情報 生成モード</param>
        /// <returns></returns>
        public bool RefreshInfoBase(MailServiceInfoCreateMode mailServiceInfoCreateMode)
        {
            return RefreshInfoBase(_SectionCode, mailServiceInfoCreateMode);
        }


        /// <summary>
        /// 各種情報リフレッシュ(再取得＆初期化)
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="mailServiceInfoCreateMode">メールサービス関連情報 生成モード</param>
        /// <returns>true:処理成功</returns>
        public bool RefreshInfoBase(string sectionCode, MailServiceInfoCreateMode mailServiceInfoCreateMode)
        {


            return true;
        }

        #endregion InfoBase リフレッシュ関連

        #region 拠点関連


        /// <summary>
        /// 自拠点情報取得
        /// </summary>
        /// <remarks>
        /// 現在の拠点情報(MailInfoBaseの情報拠点)を取得します
        /// </remarks>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionGuideName">拠点名称</param>
        public void GetBaseSectionCodeSet(out string sectionCode, out string sectionGuideName)
        {
            sectionCode = _SectionCode;
            sectionGuideName = _SectionGuideName;
            return;        
        
        }

        /// <summary>
        /// 自拠点情報取得
        /// </summary>
        /// <remarks>
        /// 現在の拠点情報(MailInfoBaseの情報拠点)を取得します
        /// </remarks>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionGuideName">拠点名称</param>
        /// <param name="mainOfficeFuncFlag">本社機能フラグ</param>
        public void GetBaseSectionCodeSet(out string sectionCode, out string sectionGuideName, out int mainOfficeFuncFlag)
        {
            sectionCode          = _SectionCode;
            sectionGuideName     = _SectionGuideName;
            mainOfficeFuncFlag   = _MainOfficeFuncFlag;
            return;        
        
        }


        /// <summary>
        /// 拠点名称取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>取得した拠点名称</returns>
        public string GetSectionGuideName(string sectionCode)
        {
            // 各種プロパティの初期化
            string retStr = "";
            if (IsNsSystem)
            {
                SecInfoAcs secInfoAcs = new SecInfoAcs();
                retStr = "";

                if (secInfoAcs.SecInfoSetList != null)
                {
                    foreach (SecInfoSet obj in secInfoAcs.SecInfoSetList)
                    {

                        if (obj.SectionCode.Trim().Equals(sectionCode.Trim()))
                        {
                            retStr = obj.SectionGuideNm.Trim();
                            break;
                        }
                    }
                }

            }
            return retStr;
        }


        /// <summary>
        /// 拠点情報取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>取得した拠点名称</returns>
        private SecInfoSet GetSectionInfo(string sectionCode)
        {
            SecInfoSet retStr = null;
            if (IsNsSystem)
            {

                // 各種プロパティの初期化
                SecInfoAcs secInfoAcs = new SecInfoAcs();
                foreach (SecInfoSet obj in secInfoAcs.SecInfoSetList)
                {

                    if (obj.SectionCode.Trim().Equals(sectionCode.Trim()))
                    {
                        retStr = obj;
                        break;
                    }
                }
            }

            if (retStr == null)
            {
                retStr = new SecInfoSet();
            }

            return retStr;
        }

        /// <summary>
        /// 拠点情報リスト取得
        /// </summary>
        /// <param name="secInfoSetList">取得した拠点情報リスト</param>
        /// <returns>取得結果 true:成功, false:失敗 </returns>
        public bool GetSecInfoSetList(out SecInfoSet[] secInfoSetList)
        {
            bool retSt = false;
            secInfoSetList = null;

            if (IsNsSystem)
            {

                // 各種プロパティの初期化
                SecInfoAcs secInfoAcs = new SecInfoAcs();

                if (secInfoAcs.SecInfoSetList != null)
                {
                    secInfoSetList = secInfoAcs.SecInfoSetList;
                    retSt = true;
                }
                else
                {
                    retSt = false;
                }
            }

            if (!retSt)
            {
                ArrayList al = new ArrayList();
                secInfoSetList = (SecInfoSet[])al.ToArray(typeof(SecInfoSet));
            }

            return retSt;
        }

        #endregion 拠点関連

        #region 従業員マスタ関連

        /// <summary>
        /// 従業員詳細マスタ 情報取得
        /// </summary>
        /// <returns>status</returns>
        public int GetEmployeeDtl(out Employee employee, out EmployeeDtl employeeDtl, string employeeCode)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();

            // 従業員詳細マスタ読込
            int st = employeeAcs.Read(out employee, out employeeDtl, _EnterpriseCode, employeeCode);

            return st;
        }

        /// <summary>
        /// 従業員詳細マスタ 情報取得（ガイド）
        /// </summary>
        /// <returns>status</returns>
        public int GetEmployeeGuid(out Employee employee, out EmployeeDtl employeeDtl)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            employee = null;
            employeeDtl = null;

            // 従業員マスタ読込
            int status = employeeAcs.ExecuteGuid(_EnterpriseCode, true, out employee);

            if (status == 0)
            {
                // 従業員詳細マスタ読込
                int st = employeeAcs.Read(out employee, out employeeDtl, _EnterpriseCode, employee.EmployeeCode);

                return st;
            }
            else
            {
                return status;
            }
        }

        #endregion 従業員マスタ関連

        #region メール送信管理マスタ関連

        /// <summary>
        /// メール情報設定マスタ 情報取得
        /// </summary>
        /// <returns>メール情報設定</returns>
        public int GetMailInfoSetting(out MailInfoSetting mailInfoSetting)
        {
            MailInfoSettingAcs mailInfoSettingAcs = new MailInfoSettingAcs();
            int st = mailInfoSettingAcs.Read(out mailInfoSetting, _EnterpriseCode, _SectionCode);

            if (mailInfoSetting == null)
            {
                mailInfoSetting = new MailInfoSetting();
            }

            return st;
        }

        #endregion メール送信管理マスタ関連

    }

    /// <summary>
    /// メールサービス関連情報 生成モード
    /// </summary>
    /// <remarks>
    /// MailInfoBase、MailFactoryBase生成時に取得(初期化)する各種情報を括るための識別子
    /// 当面はどのモードでも全情報収録モードで動作します。
    /// その後、レスポンス等をみて改良が必要であれば指定されたモードで必要な各種情報のみを
    /// オブジェクト生成時に取得し、その他のデータは必要になったタイミングで取得しようと
    /// 考えています･･･
    /// </remarks>
    public enum MailServiceInfoCreateMode
    {
        /// <summary>
        /// デフォルト(該当するモードが無い場合はこれを選択)
        /// </summary>
        Default = 0,
        /// <summary>
        /// エディタモード
        /// </summary>
        Editor = 1,
        /// <summary>
        /// メール送信ライブラリモード
        /// </summary>
        MailSender = 2,
        /// <summary>
        /// メール文書生成モード
        /// </summary>
        MailFactory = 4,
        /// <summary>
        /// マクロコンバーター生成モード
        /// </summary>
        MacroConverter = 8,
        /// <summary>
        /// メールビューアーモード
        /// </summary>
        MailViewer = 16,
        /// <summary>
        /// メールバックアップデータ操作モード
        /// </summary>
        MailBackupMaker = 32,
        /// <summary>
        /// メール送信履歴操作モード
        /// </summary>
        MailSendHistoryMaker = 64,

        /// <summary>
        /// 全情報取得モード
        /// </summary>
        All = Editor | MailSender | MailFactory | MacroConverter | MailViewer | MailBackupMaker | MailSendHistoryMaker
     }
}
 