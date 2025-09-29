using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// メール送信管理設定テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: メール送信管理設定テーブルのアクセスクラスです。</br>
	/// <br>Programmer	: 久保　将太</br>
	/// <br>Date		: 2005.04.12</br>
	/// <br></br>
    /// <br>Note		: 項目追加・キー追加による大幅変更</br>
    /// <br>Programmer	: 23013 牧　将人</br>
    /// <br>Date		: 2006.11.06</br>
	/// </remarks>
	public class MailSndMngAcs
	{
		/// <summary> リモートオブジェクト格納バッファ </summary>
		private IMailSndMngDB _iMailSndMngDB = null;
        /// <summary>拠点情報部品</summary>
        private SecInfoAcs _secInfoAcs;
        /// <summary>拠点オプションフラグ</summary>
        private bool _optSection;
        /// <summary>拠点情報保持テーブル</summary>
        private Hashtable _secInfoSetTable = null;
        /// <summary>ログイン拠点</summary>
        private string _loginSectionCode = "";

		/// <summary>
		///  メール送信管理設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: メール送信管理設定テーブルアクセスクラスのコンストラクタです。</br>
		/// <br>Programer	: 久保　将太</br>
		/// <br>Date		: 2005.04.12</br>
		/// <br></br>
		/// </remarks>
		public MailSndMngAcs()
		{
            // メモリ生成処理
            MemoryCreate();

            // 拠点OPの判定
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
			try
			{
                this._secInfoSetTable = null;
				// リモートオブジェクト取得
				this._iMailSndMngDB = (IMailSndMngDB)MediationMailSndMngDB.GetMailSndMngDB();

			}
			catch ( Exception )
			{
				// オフライン時はnullをセット
				this._iMailSndMngDB = null;
			}            

            // ログイン拠点取得
			Employee loginEmployee = LoginInfoAcquisition.Employee;
			if( loginEmployee != null ) {
				this._loginSectionCode = loginEmployee.BelongSectionCode;
			}
		}
		
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
		/// <br>Programmer	: 久保　将太</br>
		/// <br>Date		: 2005.04.12</br>
		/// <br></br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if ( this._iMailSndMngDB == null )
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// メール送信管理設定クラス読み込み処理
		/// </summary>
		/// <param name="mailSndMng">メール送信管理設定クラスオブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="mailSendMngNo">e-mail送信管理番号</param>
		/// <param name="companySignAttachCd">自社署名添付区分</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : メール送信管理設定クラス情報を読み込みます。</br>
		/// <br>Programmer : 22013　久保　将太</br>
		/// <br>Date       : 2005.04.15</br>
		/// </remarks>
		public int Read(out MailSndMng mailSndMng, string enterpriseCode, string sectionCode)
		{			
			try
			{
				mailSndMng = null;
				MailSndMngWork mailSndMngWork = new MailSndMngWork();
				mailSndMngWork.EnterpriseCode = enterpriseCode;
                // 2006.11.02 Maki 拠点コード追加
                mailSndMngWork.SectionCode = sectionCode;                
	
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);
	
				// メール送信管理フィールド名称読み込み
				int status = this._iMailSndMngDB.Read(ref parabyte,0);
	
				if (status == 0)
				{
					// XMLの読み込み
					mailSndMngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailSndMngWork));
					// クラス内メンバコピー
					mailSndMng = CopyToMailSndMngFromMailSndMngWork(mailSndMngWork);
				}
				return status;
			}
			catch (Exception)
			{				
				//通信エラーは-1を戻す
				mailSndMng = null;
				//オフライン時はnullをセット
				this._iMailSndMngDB = null;
				return -1;
			}
		}
        
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="insLnCdChg">データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 物理削除を行います。</br>
        /// <br>Programmer : 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int Delete(MailSndMng mailSndMng)
        {
            try
            {
                MailSndMngWork mailSndMngWorks = new MailSndMngWork();
                mailSndMngWorks = CopyToMailSndMngWorkFromMailSndMng(mailSndMng);

                byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWorks);

                // 物理削除
                int status = this._iMailSndMngDB.Delete(parabyte);
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iMailSndMngDB = null;

                //通信エラーは-1を戻す
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
        /// <br>Note       : 予実管理部品設定マスタの全検索処理を行います。</br>
        /// <br>	       : 論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchMailSndMngProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
        }

        /// <summary>
        /// 検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 予実管理部品設定マスタの全検索処理を行います。</br>
        /// <br>		   : 論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, MailSndMng prevMailSndMng)
        {
            return SearchMailSndMngProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01,readCnt, prevMailSndMng);
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
        /// <br>Programmer : 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        private int SearchMailSndMngProc(out ArrayList retList,out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, MailSndMng prevMailSndMng)
        {
            MailSndMngWork mailSndMngWork = new MailSndMngWork();
            if (prevMailSndMng != null)
            {
                mailSndMngWork = CopyToMailSndMngWorkFromMailSndMng(prevMailSndMng);
            }
            mailSndMngWork.EnterpriseCode = enterpriseCode;

            // 削除されていない拠点コード確保用
            ArrayList aliveSectionCodeList = new ArrayList();
            // 拠点コードのコレクションを取得
            int sectionStatus = GetAliveSectionCodeList(out aliveSectionCodeList, enterpriseCode);

            // 次データ有無初期化
            nextData = false;
            // 0で初期化
            retTotalCnt = 0;

            MailSndMngWork[] al;
            retList = new ArrayList();
            retList.Clear();

            // 拠点情報取得処理
            ArrayList wkList = new ArrayList();
            wkList.Clear();

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);

            byte[] retbyte;

            // メール送信管理設定検索
            int status = 0;
            if (readCnt == 0)
            {
                status = this._iMailSndMngDB.Search(out retbyte, parabyte, 0, logicalMode);
            }
            else
            {
                status = this._iMailSndMngDB.SearchSpecification(out retbyte, out retTotalCnt, out nextData, parabyte, 0, logicalMode, readCnt);
            }

            if ((status == 0) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                // XMLの読み込み
                al = (MailSndMngWork[])XmlByteSerializer.Deserialize(retbyte, typeof(MailSndMngWork[]));

                for (int i = 0; i < al.Length; i++)
                {
                    // サーチ結果取得
                    MailSndMngWork wkMailSndMngWork = (MailSndMngWork)al[i];
                    // メール送信管理設定クラスへメンバコピー
                    wkList.Add(CopyToMailSndMngFromMailSndMngWork(wkMailSndMngWork));
                }
                // 拠点がある場合
                if (sectionStatus == 0)
                {
                    MailSndMng mailSndMng;
                    // 拠点情報レコードはあるが、メール送信管理設定レコードが存在しない場合
                    foreach (string sectionCode in aliveSectionCodeList)
                    {
                        bool existFlg = false;
                        for (int ix = 0; ix < wkList.Count; ix++)
                        {
                            mailSndMng = (MailSndMng)wkList[ix];
                            if (mailSndMng.SectionCode.TrimEnd() == sectionCode.TrimEnd())
                            {
                                retList.Add(mailSndMng);
                                existFlg = true;
                                break;
                            }
                        }
                        if (existFlg == false)
                        {
                            // 拠点情報に合わせてレコードを追加
                            int st = AddNewBrSetItemRecord(out mailSndMng, enterpriseCode, sectionCode);
                            if (st == 0)
                            {
                                retList.Add(mailSndMng);
                            }
                        }
                    }
                }
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
        /// 拠点情報取得処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報の検索処理を行います。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
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
		/// メール送信管理設定処理
		/// </summary>
        /// <param name="mailSndMng">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 鈑金設定項目レコードを追加します。</br>
		/// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
		/// </remarks>
		private int AddNewBrSetItemRecord(out MailSndMng mailSndMng, string enterpriseCode, string sectionCode)
		{
			mailSndMng = new MailSndMng();  

			mailSndMng.EnterpriseCode		= enterpriseCode;			// 企業コード
			mailSndMng.SectionCode			= sectionCode;				// 拠点コード  
			
			mailSndMng.MailSendMngNo	    = 0;		// e-mail送信管理番号
			mailSndMng.SenderName		    = "";		// 差出人名
			mailSndMng.MailAddress		    = "";	    // メールアドレス
			mailSndMng.Pop3UserId           = "";		// POP3ユーザーID
			mailSndMng.Pop3Password		    = "";	    // POP3パスワード
			mailSndMng.Pop3ServerName		= "";		// POP3サーバー名
			mailSndMng.SmtpServerName		= "";		// SMTPサーバー名
            mailSndMng.SmtpAuthUseDiv		= 0;	    // SMTP認証使用区分
			mailSndMng.PopBeforeSmtpUseDiv  = 0;		// POP Before SMTP使用区分
            mailSndMng.SmtpUserId		    = "";	    // SMTPユーザーID
			mailSndMng.SmtpPassword		    = "";	    // SMTPパスワード
			mailSndMng.PopServerPortNo		= 0;		// POPサーバーポート番号
			mailSndMng.SmtpServerPortNo		= 0;		// SMTPサーバーポート番号
            mailSndMng.MailServerTimeoutVal	= 0;	    // メールサーバータイムアウト値
			mailSndMng.BackupSendDivCd	    = 1;	    // バックアップ送信区分
			mailSndMng.BackupFormal		    = 0;		// バックアップ形式
			mailSndMng.MailSendDivUnitCnt	= 0;		// メール送信分割単位件数
			
			// 新規登録処理
			int status = this.Write(ref mailSndMng);
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
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int ReadSectionName(out string sectionName, string enterpriseCode, string sectionCode)
        {
            int status = 0;
            sectionName = "";

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
                    sectionName = secInfoSet.SectionGuideNm;	// 拠点名
                }
            }
            else
            {
                sectionName = "未登録";							// 拠点名
            }

            return status;
        }

        /// <summary>
        /// 拠点情報保持テーブル設定処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報保持テーブルに拠点情報をセットします</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
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

        /// <summary>
        /// 論理削除処理 TODO 使用していない
        /// </summary>
        /// <param name="mailSndMng">データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 論理削除を行います。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int LogicalDelete(ref MailSndMng mailSndMng)
        {
            try
            {
                MailSndMngWork mailSndMngWork = CopyToMailSndMngWorkFromMailSndMng(mailSndMng);
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);
                // 任意保険ガイド論理削除
                int status = this._iMailSndMngDB.LogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // ファイル名を渡して任意保険ガイドワーククラスをデシリアライズする
                    mailSndMngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailSndMngWork));
                    // クラス内メンバコピー
                    mailSndMng = CopyToMailSndMngFromMailSndMngWork(mailSndMngWork);

                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iMailSndMngDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #region 2006.11.06 Maki Del
        /*
		/// <summary>
		/// メール送信管理設定クラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>メール送信管理設定クラス</returns>
		/// <remarks>
		/// <br>Note		: メール送信管理設定クラスをデシリアライズします。</br>
		/// <br>Programmer	: 22013　久保　将太</br>
		/// <br>Date		: 2005.04.15</br>
		/// <br></br>
		/// </remarks>
		public MailSndMng Deserialize(string fileName)
		{
			MailSndMng mailSndMng = null;
			// ファイル名を渡してメール送信管理設定クラスをデシリアライズする
			mailSndMng = (MailSndMng)XmlByteSerializer.Deserialize(fileName, typeof(MailSndMng));
			return mailSndMng;
		}

		/// <summary>
		/// メール送信管理設定リストクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>メール送信管理設定クラスLIST</returns>
		/// <remarks>
		/// <br>Note       : メール送信管理設定リストクラスをデシリアライズします。</br>
		/// <br>Programmer : 22013　久保　将太</br>
		/// <br>Date       : 2005.04.15</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList mailSndMngList = new ArrayList();
			mailSndMngList.Clear();

			// ファイル名を渡してメール送信管理設定クラスをデシリアライズする
			MailSndMng[] mailSndMngs;
			mailSndMngs = (MailSndMng[])XmlByteSerializer.Deserialize(fileName, typeof(MailSndMng[]));
			
			foreach (MailSndMng mailSndMng in mailSndMngs)
			{
				mailSndMngList.Add(mailSndMng);
			}
			return mailSndMngList;
		}
        */
        #endregion

        /// <summary>
		/// メール送信管理設定登録・更新処理
		/// </summary>
		/// <param name="mailSndMng">メール送信管理設定クラス</param>
		/// <returns>STATUS</returns>
		public int Write(ref MailSndMng mailSndMng)
		{
			// メール送信管理設定クラスからメール送信管理設定ワーカークラスにメンバコピー
			MailSndMngWork mailSndMngWork = CopyToMailSndMngWorkFromMailSndMng(mailSndMng);

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);

			int status = 0;
			try
			{
				// メール送信管理設定ワーク書き込み
				status = this._iMailSndMngDB.Write(ref parabyte);
				if (status == 0)
				{
					// ファイル名を渡してメール送信管理設定ワーククラスをデシリアライズする
					mailSndMngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailSndMngWork));
					// クラス内メンバコピー
					mailSndMng = CopyToMailSndMngFromMailSndMngWork(mailSndMngWork);
				}
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iMailSndMngDB = null;
				//通信エラーは-1を戻す
				status = -1;
			}
			return status;
        }

        #region 2006.11.06 Maki Del
        /*
		/// <summary>
		/// メール送信管理クラスシリアライズ処理
		/// </summary>
		/// <param name="mailSndMng">シリアライズ対象メール送信管理クラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		public void Serialize(MailSndMng mailSndMng, string fileName)
		{
			// クラスからワーククラスにコピー
			MailSndMngWork mailSndMngWork = CopyToMailSndMngWorkFromMailSndMng(mailSndMng);
			// ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(mailSndMngWork,fileName);
		}

		/// <summary>
		/// メール送信管理クラスListシリアライズ処理
		/// </summary>
		/// <param name="mailSndMngList">シリアライズ対象メール送信管理クラスList</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : メール送信管理クラスListのシリアライズを行います。</br>
		/// <br>Programmer : 22013　久保　将太</br>
		/// <br>Date       : 2005.04.15</br>
		/// </remarks>
		public void ListSerialize(ArrayList mailSndMngList, string fileName)
		{
			MailSndMngWork[] mailSndMngWorks = new MailSndMngWork[mailSndMngList.Count];
			for(int i= 0; i < mailSndMngList.Count; i++)
			{
				mailSndMngWorks[i] = CopyToMailSndMngWorkFromMailSndMng((MailSndMng)mailSndMngList[i]);
			}
			// ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(mailSndMngWorks, fileName);
		}
        */
        #endregion

        /// <summary>　TODO 使用していない
        /// メール送信管理設定論理削除復活処理
        /// </summary>
        /// <param name="mailSndMng">メール送信管理設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メール送信管理設定復活を行います。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int Revival(ref MailSndMng mailSndMng)
        {
            try
            {
                MailSndMngWork mailSndMngWork = CopyToMailSndMngWorkFromMailSndMng(mailSndMng);
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);
                // 復活処理
                int status = this._iMailSndMngDB.RevivalLogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // ファイル名を渡して従業員ワーククラスをデシリアライズする
                    mailSndMngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailSndMngWork));
                    // クラス内メンバコピー
                    mailSndMng = CopyToMailSndMngFromMailSndMngWork(mailSndMngWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iMailSndMngDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

		/// <summary>
		/// クラスメンバコピー処理（メール送信管理設定ワーククラス⇒メール送信管理設定クラス）
		/// </summary>
		/// <param name="mailSndMngWork">メール送信管理設定ワーククラス</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: メール送信管理設定ワーククラスからメール送信管理設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer	: 22013  久保　将太</br>
		/// <br>Date		: 2005.04.15</br>
		/// <br></br>
		/// </remarks>
		private MailSndMng CopyToMailSndMngFromMailSndMngWork(MailSndMngWork mailSndMngWork)
		{
			MailSndMng mailSndMng = new MailSndMng();
            
			mailSndMng.CreateDateTime  		= mailSndMngWork.CreateDateTime;
			mailSndMng.UpdateDateTime  		= mailSndMngWork.UpdateDateTime;
			mailSndMng.EnterpriseCode		= mailSndMngWork.EnterpriseCode;
			mailSndMng.FileHeaderGuid  		= mailSndMngWork.FileHeaderGuid;
			mailSndMng.UpdEmployeeCode		= mailSndMngWork.UpdEmployeeCode;
			mailSndMng.UpdAssemblyId1		= mailSndMngWork.UpdAssemblyId1;
			mailSndMng.UpdAssemblyId2		= mailSndMngWork.UpdAssemblyId2;
			mailSndMng.LogicalDeleteCode	= mailSndMngWork.LogicalDeleteCode;
            mailSndMng.SectionCode          = mailSndMngWork.SectionCode;
			mailSndMng.MailSendMngNo		= mailSndMngWork.MailSendMngNo;
            // 2006.11.01 Maki Del >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start
            //mailSndMng.CompanySignAttachCd	= mailSndMngWork.CompanySignAttachCd;
            //mailSndMng.AttachFilePath 		= mailSndMngWork.AttachFilePath;
            //mailSndMng.MailDocMaxSize 		= mailSndMngWork.MailDocMaxSize;
            //mailSndMng.PMailDocMaxSize 		= mailSndMngWork.PMailDocMaxSize;
            //mailSndMng.MailLineStrMaxSize	= mailSndMngWork.MailLineStrMaxSize;
            //mailSndMng.PMailLineStrMaxSize	= mailSndMngWork.PMailLineStrMaxSize;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< End
			mailSndMng.MailAddress 			= mailSndMngWork.MailAddress;            
            mailSndMng.Pop3UserId           = mailSndMngWork.Pop3UserId;
            mailSndMng.Pop3Password         = mailSndMngWork.Pop3Password;
            mailSndMng.Pop3ServerName       = mailSndMngWork.Pop3ServerName;
            mailSndMng.SmtpServerName       = mailSndMngWork.SmtpServerName;
            // 2006.11.01 Maki Add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start
            mailSndMng.SmtpUserId           = mailSndMngWork.SmtpUserId;
            mailSndMng.SmtpPassword         = mailSndMngWork.SmtpPassword;
            mailSndMng.SmtpAuthUseDiv       = mailSndMngWork.SmtpAuthUseDiv;
            mailSndMng.SenderName           = mailSndMngWork.SenderName;
            mailSndMng.PopBeforeSmtpUseDiv  = mailSndMngWork.PopBeforeSmtpUseDiv;
            mailSndMng.PopServerPortNo      = mailSndMngWork.PopServerPortNo;
            mailSndMng.SmtpServerPortNo     = mailSndMngWork.SmtpServerPortNo;
            mailSndMng.MailServerTimeoutVal = mailSndMngWork.MailServerTimeoutVal;
            mailSndMng.BackupSendDivCd      = mailSndMngWork.BackupSendDivCd;
            mailSndMng.BackupFormal         = mailSndMngWork.BackupFormal;
            mailSndMng.MailSendDivUnitCnt   = mailSndMngWork.MailSendDivUnitCnt;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< End
            // 2006.11.01 Maki Del >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start
            //mailSndMng.DialUpCode 			= mailSndMngWork.DialUpCode;
            //mailSndMng.DialUpConnectName	= mailSndMngWork.DialUpConnectName;
            //mailSndMng.DialUpLoginName		= mailSndMngWork.DialUpLoginName;
            //mailSndMng.DialUpPassword 		= mailSndMngWork.DialUpPassword;
            //mailSndMng.AccessTelNo 			= mailSndMngWork.AccessTelNo;
            //mailSndMng.Pop3UserId 			= mailSndMngWork.Pop3UserId;
            //mailSndMng.Pop3Password 		= mailSndMngWork.Pop3Password;
            //mailSndMng.Pop3ServerName 		= mailSndMngWork.Pop3ServerName;
            //mailSndMng.SmtpServerName 		= mailSndMngWork.SmtpServerName;
            //mailSndMng.SenderName 			= mailSndMngWork.SenderName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< End

			return mailSndMng;
		}

		/// <summary>
		/// クラスメンバコピー処理（メール送信管理設定クラス⇒メール送信管理設定ワーククラス）
		/// </summary>
		/// <param name="mailSndMngWork">メール送信管理設定クラス</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: メール送信管理設定クラスからメール送信管理設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer	: 22013  久保　将太</br>
		/// <br>Date		: 2005.04.15</br>
		/// <br></br>
		/// </remarks>
		private MailSndMngWork CopyToMailSndMngWorkFromMailSndMng(MailSndMng mailSndMng)
		{
			MailSndMngWork mailSndMngWork = new MailSndMngWork();

////////////////////////////////////////////// 2005.06.21 TERASAKA DEL STA //
//			mailSndMngWork.CreateDateTime  		= mailSndMng.CreateDateTime;
//			mailSndMngWork.UpdateDateTime  		= mailSndMng.UpdateDateTime;
//			mailSndMngWork.EnterpriseCode		= mailSndMng.EnterpriseCode;
//			mailSndMngWork.FileHeaderGuid  		= mailSndMng.FileHeaderGuid;
//			mailSndMngWork.UpdEmployeeCode		= mailSndMng.UpdEmployeeCode;
//			mailSndMngWork.UpdAssemblyId1		= mailSndMng.UpdAssemblyId1;
//			mailSndMngWork.UpdAssemblyId2		= mailSndMng.UpdAssemblyId2;
//			mailSndMngWork.LogicalDeleteCode	= mailSndMng.LogicalDeleteCode;
//			mailSndMngWork.MailSendMngNo		= mailSndMng.MailSendMngNo;
//			mailSndMngWork.CompanySignAttachCd	= mailSndMng.CompanySignAttachCd;
//			mailSndMngWork.AttachFilePath 		= mailSndMng.AttachFilePath;
//			mailSndMngWork.MailDocMaxSize 		= mailSndMng.MailDocMaxSize;
//			mailSndMngWork.PMailDocMaxSize 		= mailSndMng.PMailDocMaxSize;
//			mailSndMngWork.MailLineStrMaxSize	= mailSndMng.MailLineStrMaxSize;
//			mailSndMngWork.PMailLineStrMaxSize	= mailSndMng.PMailLineStrMaxSize;
//			mailSndMngWork.MailAddress 			= mailSndMng.MailAddress;
//			mailSndMngWork.DialUpCode 			= mailSndMng.DialUpCode;
//			mailSndMngWork.DialUpConnectName	= mailSndMng.DialUpConnectName;
//			mailSndMngWork.DialUpLoginName		= mailSndMng.DialUpLoginName;
//			mailSndMngWork.DialUpPassword 		= mailSndMng.DialUpPassword;
//			mailSndMngWork.AccessTelNo 			= mailSndMng.AccessTelNo;
//			mailSndMngWork.Pop3UserId 			= mailSndMng.Pop3UserId;
//			mailSndMngWork.Pop3Password 		= mailSndMng.Pop3Password;
//			mailSndMngWork.Pop3ServerName 		= mailSndMng.Pop3ServerName;
//			mailSndMngWork.SmtpServerName 		= mailSndMng.SmtpServerName;
//			mailSndMngWork.SenderName 			= mailSndMng.SenderName;
// 2005.06.21 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2005.06.21 TERASAKA ADD STA //
			mailSndMngWork.CreateDateTime  		= mailSndMng.CreateDateTime;
			mailSndMngWork.UpdateDateTime  		= mailSndMng.UpdateDateTime;
			mailSndMngWork.EnterpriseCode		= mailSndMng.EnterpriseCode;
			mailSndMngWork.FileHeaderGuid  		= mailSndMng.FileHeaderGuid;
			mailSndMngWork.UpdEmployeeCode		= mailSndMng.UpdEmployeeCode;
			mailSndMngWork.UpdAssemblyId1		= mailSndMng.UpdAssemblyId1;
			mailSndMngWork.UpdAssemblyId2		= mailSndMng.UpdAssemblyId2;
			mailSndMngWork.LogicalDeleteCode	= mailSndMng.LogicalDeleteCode;

            mailSndMngWork.SectionCode          = mailSndMng.SectionCode;
			mailSndMngWork.MailSendMngNo		= mailSndMng.MailSendMngNo;
            // 2006.11.01 Maki Del >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start			
            //mailSndMngWork.CompanySignAttachCd	= mailSndMng.CompanySignAttachCd;
            //mailSndMngWork.AttachFilePath 		= mailSndMng.AttachFilePath.TrimEnd();
            //mailSndMngWork.MailDocMaxSize 		= mailSndMng.MailDocMaxSize;
            //mailSndMngWork.PMailDocMaxSize 		= mailSndMng.PMailDocMaxSize;
            //mailSndMngWork.MailLineStrMaxSize	= mailSndMng.MailLineStrMaxSize;
            //mailSndMngWork.PMailLineStrMaxSize	= mailSndMng.PMailLineStrMaxSize;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< End
            mailSndMngWork.MailAddress = mailSndMng.MailAddress.Trim();
            // 2006.11.01 Maki Add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start
            mailSndMngWork.Pop3UserId           = mailSndMng.Pop3UserId.Trim();
            mailSndMngWork.Pop3Password         = mailSndMng.Pop3Password.Trim();
            mailSndMngWork.Pop3ServerName       = mailSndMng.Pop3ServerName.Trim();
            mailSndMngWork.SmtpServerName       = mailSndMng.SmtpServerName.Trim();
            mailSndMngWork.SmtpUserId           = mailSndMng.SmtpUserId.Trim();
            mailSndMngWork.SmtpPassword         = mailSndMng.SmtpPassword.Trim();
            mailSndMngWork.SmtpAuthUseDiv       = mailSndMng.SmtpAuthUseDiv;
            mailSndMngWork.SenderName           = mailSndMng.SenderName.TrimEnd();
            mailSndMngWork.PopBeforeSmtpUseDiv  = mailSndMng.PopBeforeSmtpUseDiv;
            mailSndMngWork.PopServerPortNo      = mailSndMng.PopServerPortNo;
            mailSndMngWork.SmtpServerPortNo     = mailSndMng.SmtpServerPortNo;
            mailSndMngWork.MailServerTimeoutVal = mailSndMng.MailServerTimeoutVal;
            mailSndMngWork.BackupSendDivCd      = mailSndMng.BackupSendDivCd;
            mailSndMngWork.BackupFormal         = mailSndMng.BackupFormal;
            mailSndMngWork.MailSendDivUnitCnt   = mailSndMng.MailSendDivUnitCnt;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< End
            // 2006.11.01 Maki Del >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start			
            //mailSndMngWork.DialUpCode 			= mailSndMng.DialUpCode;
            //mailSndMngWork.DialUpConnectName	= mailSndMng.DialUpConnectName.TrimEnd();
            //mailSndMngWork.DialUpLoginName		= mailSndMng.DialUpLoginName.Trim();
            //mailSndMngWork.DialUpPassword 		= mailSndMng.DialUpPassword.Trim();
            //mailSndMngWork.AccessTelNo 			= mailSndMng.AccessTelNo.Trim();
            //mailSndMngWork.Pop3UserId 			= mailSndMng.Pop3UserId.Trim();
            //mailSndMngWork.Pop3Password 		= mailSndMng.Pop3Password.Trim();
            //mailSndMngWork.Pop3ServerName 		= mailSndMng.Pop3ServerName.Trim();
            //mailSndMngWork.SmtpServerName 		= mailSndMng.SmtpServerName.Trim();
            //mailSndMngWork.SenderName 			= mailSndMng.SenderName.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< End
// 2005.06.21 TERASAKA ADD END //////////////////////////////////////////////

			return mailSndMngWork;
		}

        /// <summary>
        /// メモリ生成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 従業員設定アクセスクラスが保持するメモリを生成します。</br>
        /// <br>Programer  : 22033 三崎  貴史</br>
        /// <br>Date       : 2005.10.25</br>
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
