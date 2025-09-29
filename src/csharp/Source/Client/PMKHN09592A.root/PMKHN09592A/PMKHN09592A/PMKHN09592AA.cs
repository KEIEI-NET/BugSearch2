//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メール情報設定マスタメンテナンス
// プログラム概要   : メール情報設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2010/05/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// メール情報設定マスタメンテナンスアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: メール情報設定マスタテーブルのアクセスクラスです。</br>
    /// <br>Programmer	: 李占川</br>
    /// <br>Date		: 2010/05/24</br>
    /// <br></br>
    /// </remarks>
    public class MailInfoSettingAcs
    {
        # region -- Private Members --
        /// <summary> リモートオブジェクト格納バッファ </summary>
        private IMailInfoSettingDB _iMailInfoSettingDB = null;
        /// <summary>拠点情報部品</summary>
        private SecInfoAcs _secInfoAcs;
        /// <summary>拠点オプションフラグ</summary>
        private bool _optSection;
        /// <summary>拠点情報保持テーブル</summary>
        private Hashtable _secInfoSetTable = null;
        /// <summary>ログイン拠点</summary>
        private string _loginSectionCode = "";
        # endregion

        # region -- コンストラクタ --
        /// <summary>
        ///  メール情報設定マスタメンテナンスアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: メール情報設定マスタメンテナンスアクセスクラスのコンストラクタです。</br>
        /// <br>Programer	: 李占川</br>
        /// <br>Date		: 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        public MailInfoSettingAcs()
        {
            // メモリ生成処理
            MemoryCreate();

            // 拠点OPの判定
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
            try
            {
                this._secInfoSetTable = null;
                // リモートオブジェクト取得
                this._iMailInfoSettingDB = (IMailInfoSettingDB)MediationMailInfoSettingDB.GetMailInfoSettingDB();

            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iMailInfoSettingDB = null;
            }

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee;
            if (loginEmployee != null)
            {
                this._loginSectionCode = loginEmployee.BelongSectionCode;
            }
        }
        # endregion

        # region [ローカルアクセス用]
        /// <summary> オンラインモードの列挙型 </summary>
        public enum OnlineMode
        {
            /// <summary> オフライン </summary>
            Offline,
            /// <summary> オンライン </summary>
            Online
        }

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note		: オンラインモードを取得します</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iMailInfoSettingDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }
        # endregion

        # region -- 検索処理 --
        /// <summary>
        /// メール情報設定マスタクラス読み込み処理
        /// </summary>
        /// <param name="mailInfoSetting">メール情報設定マスタクラスオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メール情報設定マスタクラス情報を読み込みます。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Read(out MailInfoSetting mailInfoSetting, string enterpriseCode, string sectionCode)
        {
            try
            {
                mailInfoSetting = null;
                MailInfoSettingWork mailSndMngWork = new MailInfoSettingWork();
                mailSndMngWork.EnterpriseCode = enterpriseCode;
                mailSndMngWork.SectionCode = sectionCode;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);

                // メール送信管理フィールド名称読み込み
                int status = this._iMailInfoSettingDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XMLの読み込み
                    mailSndMngWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));
                    // クラス内メンバコピー
                    mailInfoSetting = CopyToMailInfoSettingFromMailInfoSettingWork(mailSndMngWork);
                }
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                mailInfoSetting = null;
                //オフライン時はnullをセット
                this._iMailInfoSettingDB = null;
                return -1;
            }
        }

        /// <summary>
        /// 全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メール情報設定マスタの全検索処理を行います。</br>
        /// <br>	       : 論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchMailInfoSettingProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
        }

        /// <summary>
        /// 検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メール情報設定マスタの全検索処理を行います。</br>
        /// <br>		   : 論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, MailInfoSetting prevMailInfoSetting)
        {
            return SearchMailInfoSettingProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, readCnt, prevMailInfoSetting);
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int SearchMailInfoSettingProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, MailInfoSetting prevMailInfoSetting)
        {
            MailInfoSettingWork mailInfoSettingWork = new MailInfoSettingWork();
            if (prevMailInfoSetting != null)
            {
                mailInfoSettingWork = CopyToMailInfoSettingWorkFromMailInfoSetting(prevMailInfoSetting);
            }
            mailInfoSettingWork.EnterpriseCode = enterpriseCode;

            // 次データ有無初期化
            nextData = false;
            // 0で初期化
            retTotalCnt = 0;

            MailInfoSettingWork[] al;
            retList = new ArrayList();
            retList.Clear();

            // 拠点情報取得処理
            ArrayList wkList = new ArrayList();
            wkList.Clear();

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(mailInfoSettingWork);

            byte[] retbyte;

            // メール情報設定マスタ検索
            int status = 0;
            if (readCnt == 0)
            {
                status = this._iMailInfoSettingDB.Search(out retbyte, parabyte, 0, logicalMode);
            }
            else
            {
                status = this._iMailInfoSettingDB.SearchSpecification(out retbyte, out retTotalCnt, out nextData, parabyte, 0, logicalMode, readCnt);
            }

            if ((status == 0) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                // XMLの読み込み
                al = (MailInfoSettingWork[])XmlByteSerializer.Deserialize(retbyte, typeof(MailInfoSettingWork[]));

                for (int i = 0; i < al.Length; i++)
                {
                    // サーチ結果取得
                    MailInfoSettingWork wkMailInfoSettingWork = (MailInfoSettingWork)al[i];
                    // メール情報設定マスタクラスへメンバコピー
                    wkList.Add(CopyToMailInfoSettingFromMailInfoSettingWork(wkMailInfoSettingWork));
                }

                retList = wkList;
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
            }
            // 全件リードの場合は戻り値の件数をセット
            if (readCnt == 0)
            {
                retTotalCnt = retList.Count;
            }

            return status;
        }

        /// <summary>
        /// メール情報設定処理
        /// </summary>
        /// <param name="mailInfoSetting">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 設定項目レコードを追加します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int AddNewBrSetItemRecord(out MailInfoSetting mailInfoSetting, string enterpriseCode, string sectionCode)
        {
            mailInfoSetting = new MailInfoSetting();

            mailInfoSetting.EnterpriseCode = enterpriseCode;			// 企業コード
            mailInfoSetting.SectionCode = sectionCode;				// 拠点コード  

            mailInfoSetting.MailSendMngNo = 0;		// e-mail送信管理番号
            mailInfoSetting.SenderName = "";		// 差出人名
            mailInfoSetting.MailAddress = "";	    // メールアドレス
            mailInfoSetting.Pop3UserId = "";		// POP3ユーザーID
            mailInfoSetting.Pop3Password = "";	    // POP3パスワード
            mailInfoSetting.Pop3ServerName = "";		// POP3サーバー名
            mailInfoSetting.SmtpServerName = "";		// SMTPサーバー名
            mailInfoSetting.SmtpAuthUseDiv = 0;	    // SMTP認証使用区分
            mailInfoSetting.PopBeforeSmtpUseDiv = 0;		// POP Before SMTP使用区分
            mailInfoSetting.SmtpUserId = "";	    // SMTPユーザーID
            mailInfoSetting.SmtpPassword = "";	    // SMTPパスワード
            mailInfoSetting.PopServerPortNo = 0;		// POPサーバーポート番号
            mailInfoSetting.SmtpServerPortNo = 0;		// SMTPサーバーポート番号
            mailInfoSetting.MailServerTimeoutVal = 0;	    // メールサーバータイムアウト値
            mailInfoSetting.BackupSendDivCd = 1;	    // バックアップ送信区分
            mailInfoSetting.BackupFormal = 0;		// バックアップ形式
            mailInfoSetting.MailSendDivUnitCnt = 0;		// メール送信分割単位件数

            // 新規登録処理
            int status = this.Write(ref mailInfoSetting);
            return status;
        }
        # endregion

        # region -- 登録･更新処理 --
        /// <summary>
        /// メール情報設定マスタ登録・更新処理
        /// </summary>
        /// <param name="mailInfoSetting">メール情報設定マスタクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メール情報設定マスタ登録・更新処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Write(ref MailInfoSetting mailInfoSetting)
        {
            // メール情報設定マスタクラスからメール情報設定マスタワーカークラスにメンバコピー
            MailInfoSettingWork mailInfoSettingWork = CopyToMailInfoSettingWorkFromMailInfoSetting(mailInfoSetting);

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(mailInfoSettingWork);

            int status = 0;
            try
            {
                // メール情報設定マスタワーク書き込み
                status = this._iMailInfoSettingDB.Write(ref parabyte);
                if (status == 0)
                {
                    // ファイル名を渡してメール情報設定マスタワーククラスをデシリアライズする
                    mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));
                    // クラス内メンバコピー
                    mailInfoSetting = CopyToMailInfoSettingFromMailInfoSettingWork(mailInfoSettingWork);
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iMailInfoSettingDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }
            return status;
        }
        # endregion

        #region -- 削除･復活処理 --
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="mailInfoSetting">データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 物理削除を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Delete(MailInfoSetting mailInfoSetting)
        {
            try
            {
                MailInfoSettingWork mailInfoSettingWorks = new MailInfoSettingWork();
                mailInfoSettingWorks = CopyToMailInfoSettingWorkFromMailInfoSetting(mailInfoSetting);

                byte[] parabyte = XmlByteSerializer.Serialize(mailInfoSettingWorks);

                // 物理削除
                int status = this._iMailInfoSettingDB.Delete(parabyte);
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iMailInfoSettingDB = null;

                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="mailInfoSetting">データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 論理削除を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int LogicalDelete(ref MailInfoSetting mailInfoSetting)
        {
            try
            {
                MailInfoSettingWork mailInfoSettingWork = CopyToMailInfoSettingWorkFromMailInfoSetting(mailInfoSetting);
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(mailInfoSettingWork);
                // 任意保険ガイド論理削除
                int status = this._iMailInfoSettingDB.LogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // ファイル名を渡して任意保険ガイドワーククラスをデシリアライズする
                    mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));
                    // クラス内メンバコピー
                    mailInfoSetting = CopyToMailInfoSettingFromMailInfoSettingWork(mailInfoSettingWork);

                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iMailInfoSettingDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// メール情報設定マスタ論理削除復活処理
        /// </summary>
        /// <param name="mailInfoSetting">メール情報設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メール情報設定マスタ復活を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Revival(ref MailInfoSetting mailInfoSetting)
        {
            try
            {
                MailInfoSettingWork mailSndMngWork = CopyToMailInfoSettingWorkFromMailInfoSetting(mailInfoSetting);
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);
                // 復活処理
                int status = this._iMailInfoSettingDB.RevivalLogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // ファイル名を渡して従業員ワーククラスをデシリアライズする
                    mailSndMngWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));
                    // クラス内メンバコピー
                    mailInfoSetting = CopyToMailInfoSettingFromMailInfoSettingWork(mailSndMngWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iMailInfoSettingDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        # endregion

        # region -- 拠点の処理 --
        /// <summary>
        /// 拠点情報取得処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報の検索処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int GetAliveSectionCodeList(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;

            retList = new ArrayList();

            SecInfoAcs secInfoAcs = new SecInfoAcs();

            // 本社機能の場合
            if (secInfoAcs.SecInfoSet.MainOfficeFuncFlag == SecInfoSet.CONSTMAINOFFICEFUNCFLAG_MAIN)
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    retList.Add(secInfoSet.SectionCode);
                }
            }
            else
            {
                retList.Add(secInfoAcs.SecInfoSet.SectionCode);
            }

            if (retList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            return status;
        }

        /// <summary>
        /// 拠点ガイド名称読込
        /// </summary>
        /// <param name="sectionName">拠点名</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>取得結果</returns>
        /// <remarks>
        /// <br>Note       : 拠点コードから拠点ガイド名称を取得します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int ReadSectionName(out string sectionName, string enterpriseCode, string sectionCode)
        {
            int status = 0;
            sectionName = "";

            if (sectionCode.Trim().Equals(""))
            {
                return status;
            }

            sectionCode = sectionCode.Trim().PadLeft(2, '0');
            if (this._secInfoSetTable == null)
            {
                status = SetSecInfoSetTable();
                if ((status != 0) && (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
            }

            if (this._secInfoSetTable.ContainsKey(sectionCode.TrimEnd()) == true)
            {
                SecInfoSet secInfoSet = (SecInfoSet)this._secInfoSetTable[sectionCode.TrimEnd()];
                if (secInfoSet.LogicalDeleteCode != 0)			// 論理削除されている場合
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sectionName = "削除済";						// 拠点名
                }
                else											// 論理削除されていない場合
                {
                    sectionName = secInfoSet.SectionGuideSnm;	// 拠点名
                }
            }
            else
            {
                //sectionName = "未登録";							// 拠点名
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 拠点情報保持テーブル設定処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報保持テーブルに拠点情報をセットします</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int SetSecInfoSetTable()
        {
            int status = 0;
            this._secInfoSetTable = new Hashtable();
            this._secInfoSetTable.Clear();

            SecInfoAcs secInfoAcs = new SecInfoAcs();

            foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
            {
                this._secInfoSetTable.Add(secInfoSet.SectionCode.TrimEnd(), secInfoSet.Clone());
            }

            if (this._secInfoSetTable.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return status;
        }
        # endregion

        # region -- クラスメンバーコピー処理 --
        /// <summary>
        /// クラスメンバコピー処理（メール情報設定マスタワーククラス⇒メール情報設定マスタクラス）
        /// </summary>
        /// <param name="mailInfoSettingWork">メール情報設定マスタワーククラス</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: メール情報設定マスタワーククラスからメール情報設定マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        private MailInfoSetting CopyToMailInfoSettingFromMailInfoSettingWork(MailInfoSettingWork mailInfoSettingWork)
        {
            MailInfoSetting mailInfoSetting = new MailInfoSetting();

            mailInfoSetting.CreateDateTime = mailInfoSettingWork.CreateDateTime;
            mailInfoSetting.UpdateDateTime = mailInfoSettingWork.UpdateDateTime;
            mailInfoSetting.EnterpriseCode = mailInfoSettingWork.EnterpriseCode;
            mailInfoSetting.FileHeaderGuid = mailInfoSettingWork.FileHeaderGuid;
            mailInfoSetting.UpdEmployeeCode = mailInfoSettingWork.UpdEmployeeCode;
            mailInfoSetting.UpdAssemblyId1 = mailInfoSettingWork.UpdAssemblyId1;
            mailInfoSetting.UpdAssemblyId2 = mailInfoSettingWork.UpdAssemblyId2;
            mailInfoSetting.LogicalDeleteCode = mailInfoSettingWork.LogicalDeleteCode;
            mailInfoSetting.SectionCode = mailInfoSettingWork.SectionCode;
            mailInfoSetting.MailSendMngNo = mailInfoSettingWork.MailSendMngNo;
            mailInfoSetting.MailAddress = mailInfoSettingWork.MailAddress;
            mailInfoSetting.DialUpCode = mailInfoSettingWork.DialUpCode;
            mailInfoSetting.DialUpConnectName = mailInfoSettingWork.DialUpConnectName;
            mailInfoSetting.DialUpLoginName = mailInfoSettingWork.DialUpLoginName;
            mailInfoSetting.DialUpPassword = mailInfoSettingWork.DialUpPassword;
            mailInfoSetting.AccessTelNo = mailInfoSettingWork.AccessTelNo;
            mailInfoSetting.Pop3UserId = mailInfoSettingWork.Pop3UserId;
            mailInfoSetting.Pop3Password = mailInfoSettingWork.Pop3Password;
            mailInfoSetting.Pop3ServerName = mailInfoSettingWork.Pop3ServerName;
            mailInfoSetting.SmtpServerName = mailInfoSettingWork.SmtpServerName;
            mailInfoSetting.SmtpUserId = mailInfoSettingWork.SmtpUserId;
            mailInfoSetting.SmtpPassword = mailInfoSettingWork.SmtpPassword;
            mailInfoSetting.SmtpAuthUseDiv = mailInfoSettingWork.SmtpAuthUseDiv;
            mailInfoSetting.SenderName = mailInfoSettingWork.SenderName;
            mailInfoSetting.PopBeforeSmtpUseDiv = mailInfoSettingWork.PopBeforeSmtpUseDiv;
            mailInfoSetting.PopServerPortNo = mailInfoSettingWork.PopServerPortNo;
            mailInfoSetting.SmtpServerPortNo = mailInfoSettingWork.SmtpServerPortNo;
            mailInfoSetting.MailServerTimeoutVal = mailInfoSettingWork.MailServerTimeoutVal;
            mailInfoSetting.BackupSendDivCd = mailInfoSettingWork.BackupSendDivCd;
            mailInfoSetting.BackupFormal = mailInfoSettingWork.BackupFormal;
            mailInfoSetting.MailSendDivUnitCnt = mailInfoSettingWork.MailSendDivUnitCnt;
            mailInfoSetting.FilePathNm = mailInfoSettingWork.FilePathNm;

            return mailInfoSetting;
        }

        /// <summary>
        /// クラスメンバコピー処理（メール情報設定マスタクラス⇒メール情報設定マスタワーククラス）
        /// </summary>
        /// <param name="mailInfoSetting">メール情報設定マスタクラス</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: メール情報設定マスタクラスからメール情報設定マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        private MailInfoSettingWork CopyToMailInfoSettingWorkFromMailInfoSetting(MailInfoSetting mailInfoSetting)
        {
            MailInfoSettingWork mailInfoSettingWork = new MailInfoSettingWork();

            mailInfoSettingWork.CreateDateTime = mailInfoSetting.CreateDateTime;
            mailInfoSettingWork.UpdateDateTime = mailInfoSetting.UpdateDateTime;
            mailInfoSettingWork.EnterpriseCode = mailInfoSetting.EnterpriseCode;
            mailInfoSettingWork.FileHeaderGuid = mailInfoSetting.FileHeaderGuid;
            mailInfoSettingWork.UpdEmployeeCode = mailInfoSetting.UpdEmployeeCode;
            mailInfoSettingWork.UpdAssemblyId1 = mailInfoSetting.UpdAssemblyId1;
            mailInfoSettingWork.UpdAssemblyId2 = mailInfoSetting.UpdAssemblyId2;
            mailInfoSettingWork.LogicalDeleteCode = mailInfoSetting.LogicalDeleteCode;
            mailInfoSettingWork.SectionCode = mailInfoSetting.SectionCode;
            mailInfoSettingWork.MailSendMngNo = mailInfoSetting.MailSendMngNo;
            mailInfoSettingWork.MailAddress = mailInfoSetting.MailAddress;
            mailInfoSettingWork.DialUpCode = mailInfoSetting.DialUpCode;
            mailInfoSettingWork.DialUpConnectName = mailInfoSetting.DialUpConnectName;
            mailInfoSettingWork.DialUpLoginName = mailInfoSetting.DialUpLoginName;
            mailInfoSettingWork.DialUpPassword = mailInfoSetting.DialUpPassword;
            mailInfoSettingWork.AccessTelNo = mailInfoSetting.AccessTelNo;
            mailInfoSettingWork.Pop3UserId = mailInfoSetting.Pop3UserId;
            mailInfoSettingWork.Pop3Password = mailInfoSetting.Pop3Password;
            mailInfoSettingWork.Pop3ServerName = mailInfoSetting.Pop3ServerName;
            mailInfoSettingWork.SmtpServerName = mailInfoSetting.SmtpServerName;
            mailInfoSettingWork.SmtpUserId = mailInfoSetting.SmtpUserId;
            mailInfoSettingWork.SmtpPassword = mailInfoSetting.SmtpPassword;
            mailInfoSettingWork.SmtpAuthUseDiv = mailInfoSetting.SmtpAuthUseDiv;
            mailInfoSettingWork.SenderName = mailInfoSetting.SenderName;
            mailInfoSettingWork.PopBeforeSmtpUseDiv = mailInfoSetting.PopBeforeSmtpUseDiv;
            mailInfoSettingWork.PopServerPortNo = mailInfoSetting.PopServerPortNo;
            mailInfoSettingWork.SmtpServerPortNo = mailInfoSetting.SmtpServerPortNo;
            mailInfoSettingWork.MailServerTimeoutVal = mailInfoSetting.MailServerTimeoutVal;
            mailInfoSettingWork.BackupSendDivCd = mailInfoSetting.BackupSendDivCd;
            mailInfoSettingWork.BackupFormal = mailInfoSetting.BackupFormal;
            mailInfoSettingWork.MailSendDivUnitCnt = mailInfoSetting.MailSendDivUnitCnt;
            mailInfoSettingWork.FilePathNm = mailInfoSetting.FilePathNm;

            return mailInfoSettingWork;
        }
        # endregion

        /// <summary>
        /// メモリ生成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メール情報設定アクセスクラスが保持するメモリを生成します。</br>
        /// <br>Programer  : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void MemoryCreate()
        {
            // オンラインの場合
            if (LoginInfoAcquisition.OnlineFlag)
            {
                //---拠点情報取得部品インスタンス化---//
                this._secInfoAcs = new SecInfoAcs();
            }
        }
    }
}
