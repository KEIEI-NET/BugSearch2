//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 見積・受注データ受信
// プログラム概要   : 見積・受注データの受信処理の操作を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/05/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2010/03/08  修正内容 : 受信日付更新方法変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/30  修正内容 : 簡単問合せ対応（簡単問合せ接続中の場合は自動回答対象外とする）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/31  修正内容 : 一部回答の仕様変更に伴う修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/30  修正内容 : 返品データの新着通知対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/05/21  修正内容 : 自動回答のオプション化対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤　恵優
// 作 成 日  2010/06/15  修正内容 : SCM受注データおよびSCM受注明細データ(問合せ・発注)のレイアウト変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤　恵優
// 作 成 日  2010/06/16  修正内容 : キャンセルデータ用の補正処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤　恵優
// 作 成 日  2010/06/25  修正内容 : コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤　恵優
// 作 成 日  2010/06/29  修正内容 : PM7連携時はSCM系データをDBに書かない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/12/37  修正内容 : SCM全体設定マスタで「全社」のみ登録されている状態で、PM7SP連携しようとすると、エラーで落ちる件の対応(MANTIS[0016842])
//                                 ①2010/3/30の対応を削除(xmlでCMT連携の管理を行っていない為)
//                                 ②SCM全体設定で「全社」設定の場合もPM7連携できるように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/18  修正内容 : ①Webからデータ取得時に、対象問合せ番号のデータを全件取得する
//                                 ②USER_DB,PM7SP用CSV等には、有効な明細のみ書き込みする。(PM7は、ヘッダが最新のデータのみ)
//                                 ③キャンセルデータの仕様変更対応
//                                 ③回答区分の補正処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/03/18  修正内容 : ・得意先未登録のＳＦから受信時にエラーになる件の修正
//                                 ・得意先マスタのチェックの条件にオンライン区分=10:SCMを追加
//----------------------------------------------------------------------------//
// 管理番号 10703242-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2011/05/25   修正内容 : 回答区分項目追加対応
//----------------------------------------------------------------------------//
// 管理番号 PJTASDNO004 作成担当 : LDNS wangqx
// 作 成 日  2011/07/14   修正内容 : 仮導入データクリア対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2011/08/10  修正内容 : Redmine#23502対応
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011/08/11  修正内容 : PCC-UOEメールメッセージ送信
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhouzy
// 作 成 日  2011/09/06  修正内容 : Websync PCCUOEのチャンネルを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gaofeng
// 作 成 日  2011/08/10  修正内容 : Redmine 仕様連絡 #24906の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22024 寺坂 誉志
// 作 成 日  2012.04.10  修正内容 : 高速化対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2012/04/18  修正内容 : RC-SCM速度改良の修正
//                                 （※検索結果が不正にならないようキャッシュクリアする）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22024 寺坂 誉志
// 作 成 日  2012/04/24  修正内容 : 状態表示対応(SF側)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/08/24  修正内容 : 2012/12月配信予定 SCM障害№10340の対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 三戸 伸悟
// 作 成 日  2012/11/21  修正内容 : 2012/12/12配信予定システムテスト障害№59対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/04/19  修正内容 : 2013/05/22配信予定 SCM障害№10521対応 車両管理コード追加
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/06/24  修正内容 : タブレット対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30745 吉岡
// 作 成 日  2013/05/15  修正内容 : 2013/06/18配信　SCM障害№10410
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : 2013/06/18配信 SCM障害№10384対応 入庫予定日追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/24  修正内容 : 2013/06/18配信 SCM障害№10537対応 車両管理コード追加
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/07/22  修正内容 : SFの返品要求に対して、PMからキャンセルデータが来た場合、
//                                  SF-PM連携指示書番号が空白になる障害の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/12/19  修正内容 : SCM高速化 PMNS対応 自動回答方式の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30746 高川 悟
// 作 成 日  2015/06/05  修正内容 : SCM課題一覧No35 ポップアップ異常終了対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2015/09/11  修正内容 : 全体配信システムテスト障害№149対応
//                                  サスペンド復旧時後、新着データ取得でTO発生時の
//                                  リトライ処理追加
//----------------------------------------------------------------------------//
// 管理番号 11170141-00  作成担当 : 30746 高川 悟
// 作 成 日  2015/09/16  修正内容 : システムテスト障害No.156対応
//                                  サーバー配信があたり、クライアント側が古い場合に
//                                  メッセージが表示されない
//----------------------------------------------------------------------------//
// 管理番号 11275206-00  作成担当 : 陳艶丹
// 作 成 日  2016/09/18  修正内容 : SCM高負荷クエリの対応
//----------------------------------------------------------------------------//
// 管理番号 12000031-00  作成担当 : 陳艶丹
// 作 成 日  2024/07/03  修正内容 : BLP障害対応（例外発生箇所修正対応）
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.WebDB;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Controller.Messenger;
using Broadleaf.Application.Controller.NetworkConfig;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;  // 2010/05/21 Add
using Broadleaf.Library.Globarization;  // 2010/07/14 Add

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using System.Text;                      // 2011.07.12 ZHANGYH ADD
using System.Configuration;             // 2011.07.12 ZHANGYH ADD

#if DEBUG
// ダミー参照
//using ScmOdrData = Broadleaf.Application.UIData.StubDB.ScmOdrData;
//using ScmOdDtInq = Broadleaf.Application.UIData.StubDB.ScmOdDtInq;
//using ScmOdDtAns = Broadleaf.Application.UIData.StubDB.ScmOdDtAns;
//using ScmOdDtCar = Broadleaf.Application.UIData.StubDB.ScmOdDtCar;

//using SCMAcOdrData = Broadleaf.Application.UIData.StubDB.SCMAcOdrData;
//using SCMAcOdrDtlIq = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtlIq;
//using SCMAcOdrDtlAs = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtlAs;
//using SCMAcOdrDtCar = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtCar;

using ScmOdrData = Broadleaf.Application.UIData.ScmOdrData;
using ScmOdDtInq = Broadleaf.Application.UIData.ScmOdDtInq;
using ScmOdDtAns = Broadleaf.Application.UIData.ScmOdDtAns;
using ScmOdDtCar = Broadleaf.Application.UIData.ScmOdDtCar;

using SCMAcOdrData = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
using SCMAcOdrDtlIq = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
using SCMAcOdrDtlAs = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
using SCMAcOdrDtCar = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;

#else
using ScmOdrData = Broadleaf.Application.UIData.ScmOdrData;
    using ScmOdDtInq = Broadleaf.Application.UIData.ScmOdDtInq;
    using ScmOdDtAns = Broadleaf.Application.UIData.ScmOdDtAns;
    using ScmOdDtCar = Broadleaf.Application.UIData.ScmOdDtCar;

    using SCMAcOdrData = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
    using SCMAcOdrDtlIq = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
    using SCMAcOdrDtlAs = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
    using SCMAcOdrDtCar = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;
#endif

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 見積・受注データ受信アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 見積・受注データの受信の操作を行います。</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2009/05/21</br>
	/// <br></br>
	/// <br>Update Note	: 2012.04.10 22024 寺坂　誉志</br>
	/// <br>			: １．高速化対応</br>
    /// </remarks>
    public sealed class SCMChecker : ISCMChecker
    {
        #region <ISCMChecker メンバ>

        /// <summary>
        /// 各条件チェック
        /// </summary>
        /// <returns></returns>
        public int CheckInitialInfo()
        {
            // リトライ待機時間、リトライ最大数が0以上の数値か
            if (this._retryWaitTime < 0)
            {
                LogWriter.LogWrite("configファイルのリトライ待機時間の設定が正しくありません。");
                return (int)Result.Code.Error;
            }

            if (this._retryMaxCount < 0)
            {
                LogWriter.LogWrite("configファイルのリトライ最大回数の設定が正しくありません。");
                return (int)Result.Code.Error;
            }

            // ポート番号が設定可能域(0～65535)か
            if (this._portNumber < 0 || this._portNumber > 65535)
            {
                LogWriter.LogWrite("configファイルのポート番号の設定が正しくありません。");
                return (int)Result.Code.Error;
            }

            return (int)Result.Code.Normal;
        }

        #region 新着データ受信処理
        /// <summary>
        /// 新着件数を取得します。
        /// </summary>
        /// <returns>新着件数</returns>
        /// <see cref="ISCMChecker"/>
        public int GetNewOrderCount()
        {
            LogWriter.LogWrite("新着件数取得処理開始");

            int count; // 最新問合せ数
            int newCount; // 最新レコード数
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 前回処理日時の取得。
            IOWriteSCMReadWork readWork = new IOWriteSCMReadWork();
            readWork.EnterpriseCode = this._enterpriseCd;
            readWork.InqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode; // ADD 2011/08/10

            object readPara = readWork;

            object retObject;
            status = this._iIOWriteScmDB.ScmDtlIqRead(out retObject, readPara);

            // --- Add 2011/08/10 duzg for Redmine#23502対応 --->>>
            // データクリア実行際設定した時間を取得する
            Int32 DelYMD, DelHMSXXX;
            this._companyInfAcs.ReadClearTime(this._enterpriseCd, out DelYMD, out DelHMSXXX);
            // --- Add 2011/08/10 duzg for Redmine#23502対応 --->>>

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SCMAcOdrDtlIq detail = (SCMAcOdrDtlIq)retObject;
                // --- Add 2011/08/10 duzg for Redmine#23502対応 --->>>
                if (TDateTime.DateTimeToLongDate(detail.UpdateDate) >= DelYMD)
                {
                    if (TDateTime.DateTimeToLongDate(detail.UpdateDate) == DelYMD && detail.UpdateTime <= DelHMSXXX)
                    {
                        this._beforeGetDataDate = TDateTime.LongDateToDateTime("YYYYMMDD", DelYMD);
                        this._beforeGetDataTime = DelHMSXXX;
                    }
                    else
                    {
                        this._beforeGetDataDate = detail.UpdateDate;
                        this._beforeGetDataTime = detail.UpdateTime;
                    }
                }
                else
                {
                    this._beforeGetDataDate = TDateTime.LongDateToDateTime("YYYYMMDD", DelYMD);
                    this._beforeGetDataTime = DelHMSXXX;
                }
                // --- Add 2011/08/10 duzg for Redmine#23502対応 ---<<<
                /* --- Del 2011/08/10 duzg for Redmine#23502対応 --->>>
                this._beforeGetDataDate = detail.UpdateDate;
                this._beforeGetDataTime = detail.UpdateTime;
                 --- Del 2011/08/10 duzg for Redmine#23502対応 ---<<<*/
            }
            else
            {
                // -- DELETE 2011/07/14 ------------------------------------------->>>
                // データがない場合は最小値を設定
                //this._beforeGetDataDate = DateTime.MinValue;
                //this._beforeGetDataTime = 0;
                // -- DELETE 2011/07/14 -------------------------------------------<<<
                // -- ADD 2011/07/14 ------------------------------------------->>>
                /* --- Del 2011/08/10 duzg for Redmine#23502対応 --->>>
                // データクリア実行際設定した時間を取得する
                Int32 DelYMD, DelHMSXXX;

                int status2 = this._companyInfAcs.ReadClearTime(this._enterpriseCd, out DelYMD, out DelHMSXXX);
                 --- Del 2011/08/10 duzg for Redmine#23502対応 ---<<<*/

                this._beforeGetDataDate = TDateTime.LongDateToDateTime("YYYYMMDD", DelYMD);
                this._beforeGetDataTime = DelHMSXXX;
                // -- ADD 2011/07/14 -------------------------------------------<<<
            }

            // Webアクセス引数
            ScmPopParam scmPopParam = new ScmPopParam();

            scmPopParam.InqOtherEpCd = this._enterpriseCd; // 問合せ先企業コード
            scmPopParam.InqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode; // ADD 2011/08/10
            scmPopParam.UpdateDate = this._beforeGetDataDate; // 前回取得更新年月日
            scmPopParam.UpdateTime = this._beforeGetDataTime; // 前回取得時分秒ミリ秒
            scmPopParam.InqOrdAnsDivCd = (int)DivisionValues.InqOrdAnsDivCd.Inquiry; // 問発・回答種別 1:問発 

            List<ScmPopParamDtl> scmPopParamDtlList = new List<ScmPopParamDtl>();
            ScmPopParamDtl dtl = new ScmPopParamDtl();
            scmPopParamDtlList.Add(dtl);

            for (int i = 0; i < this._retryMaxCount; i++)
            {
                if (i != 0)
                {
                    // 初回以外は設定時間待機
                    System.Threading.Thread.Sleep(this._retryWaitTime);
                }

                // 新着件数問合せ(Web)
                try
                {
                    status = this._scmOdrDataAcs.SearchCntWithCar(scmPopParam, scmPopParamDtlList, out count, out newCount);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        LogWriter.LogWrite("新着件数取得処理正常終了");
                        return count;
                    }
                    else
                    {
                        LogWriter.LogWrite("新着件数取得処理でエラーが発生しました。");
                    }
                }
                catch (Exception e)
                {
                    LogWriter.LogWrite("新着件数取得処理でエラーが発生しました。");
                    LogWriter.LogWrite(e.Message);
                }
            }

            LogWriter.LogWrite("新着件数取得処理で設定回数リトライを行いましたがエラーが発生しました。");
            return 0;
        }

////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
		/// <summary>
		/// ダウンロードします。
		/// </summary>
		/// <returns>結果コード</returns>
		public int DownloadWebDB()
		{
			return DownloadWebDB(false);
		}
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

        /// <summary>
        /// ダウンロードします。
        /// </summary>
		/// <param name="isGetlastTime">前回処理日付を取得するか[true:取得する,false:取得しない]</param>
		/// <returns>結果コード</returns>
		#region 2012.04.10 TERASAKA DEL STA
//		public int DownloadWebDB()
		#endregion
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
		public int DownloadWebDB(bool isGetlastTime)
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
        {
            LogWriter.LogWrite("新着データ取得処理開始");

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
			if (isGetlastTime)
			{
                // --- UPD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 -------------------->>>>>
                //// クリア処理を実施した日付を取得
                //Int32 DelYMD, DelHMSXXX;
                //this._companyInfAcs.ReadClearTime(this._enterpriseCd, out DelYMD, out DelHMSXXX);

                DateTime getLateUpdateDate = DateTime.MinValue; // 前回の最新取得日付
                int getLateUpdateTime = 0; // 前回の最新取得日時
                // xmlファイルから基準日を取得
                this._scmPeriod = this.ReadScmPeriodSet();
                string baseDate = DateTime.Now.AddDays(-1 * this._scmPeriod.ReceivePeriod).ToString("yyyyMMdd");
                int periodDate;
                Int32.TryParse(baseDate, out periodDate);
                object obj = null;
                int statusTime = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                // 自端末の端末番号を取得
                PosTerminalMg posTerminalMg = new PosTerminalMg();
                PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
                status = posTerminalMgAcs.Search(out posTerminalMg, this._enterpriseCd);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && posTerminalMg !=null)
                {
                    int cashRegisterNo = posTerminalMg.CashRegisterNo;
                    statusTime = this._scmTerminal.SearchScmTimeData(cashRegisterNo, out obj);
                }
                if (statusTime == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && obj != null)
                {
                    if (TDateTime.DateTimeToLongDate(((ScmTimeDataWork)obj).LastGetDate) >= periodDate)
                    {
                        // 最終取得日付
                        getLateUpdateDate = ((ScmTimeDataWork)obj).LastGetDate;
                        getLateUpdateTime = ((ScmTimeDataWork)obj).LastGetTime;
                    }
                    else
                    {
                        // 最終取得日付
                        getLateUpdateDate = TDateTime.LongDateToDateTime("YYYYMMDD", periodDate);
                    }
                }
                else
                {
                    // 最終取得日付
                    getLateUpdateDate = TDateTime.LongDateToDateTime("YYYYMMDD", periodDate);
                }
                // --- UPD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 --------------------<<<<<

                // 前回処理日時の取得
                IOWriteSCMReadWork readWork = new IOWriteSCMReadWork();
                readWork.EnterpriseCode = this._enterpriseCd;
                readWork.InqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;

				object readPara = readWork;
				object retObject;

                // ADD 2015/09/11 豊沢 全体配信システムテスト障害№149対応 --------------------->>>>>
                retObject = null;
                // 正常終了、EOF、NOT_FOUND以外のステータスはリトライを行う
                for (int retry = 0; retry < this._retryMaxCount; retry++)
                {
                    status = this._iIOWriteScmDB.ScmDtlIqRead(out retObject, readPara);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                        status == (int)ConstantManagement.DB_Status.ctDB_EOF ||
                        status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        break;
                    }

                    System.Threading.Thread.Sleep(this._retryWaitTime);
                }

                // 正常終了、EOF、NOT_FOUND以外のステータスはステータスをログに出力
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_EOF &&
                    status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    LogWriter.LogWrite(string.Format("ScmDtlIqRead Error : status {0}", status));
                }
                // ADD 2015/09/11 豊沢 全体配信システムテスト障害№149対応 ---------------------<<<<<

                // DEL 2015/09/11 豊沢 全体配信システムテスト障害№149対応 --------------------->>>>>
                //status = this._iIOWriteScmDB.ScmDtlIqRead(out retObject, readPara);
                // DEL 2015/09/11 豊沢 全体配信システムテスト障害№149対応 ---------------------<<<<<
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 前回処理日時とクリア処理日時のうち、新しい日付を検索条件として採用する
					SCMAcOdrDtlIq detail = (SCMAcOdrDtlIq)retObject;
                // --- UPD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 -------------------->>>>>
                //    if (TDateTime.DateTimeToLongDate(detail.UpdateDate) >= DelYMD)
                //    {
                //        if (TDateTime.DateTimeToLongDate(detail.UpdateDate) == DelYMD && detail.UpdateTime <= DelHMSXXX)
                //        {
                //            this._beforeGetDataDate = TDateTime.LongDateToDateTime("YYYYMMDD", DelYMD);
                //            this._beforeGetDataTime = DelHMSXXX;
                //        }
                //        else
                //        {
                //            this._beforeGetDataDate = detail.UpdateDate;
                //            this._beforeGetDataTime = detail.UpdateTime;
                //        }
                //    }
                //    else
                //    {
                //        this._beforeGetDataDate = TDateTime.LongDateToDateTime("YYYYMMDD", DelYMD);
                //        this._beforeGetDataTime = DelHMSXXX;
                //    }
                //}
                //else
                //{
                //    this._beforeGetDataDate = TDateTime.LongDateToDateTime("YYYYMMDD", DelYMD);
                //    this._beforeGetDataTime = DelHMSXXX;
                //}
                    if (TDateTime.DateTimeToLongDate(detail.UpdateDate) >= TDateTime.DateTimeToLongDate(getLateUpdateDate))
                    {
                        this._beforeGetDataDate = detail.UpdateDate;
                        this._beforeGetDataTime = detail.UpdateTime;
                    }
                    else
                    {
                        this._beforeGetDataDate = getLateUpdateDate;
                        this._beforeGetDataTime = getLateUpdateTime;
                    }
                }
                else
                {
                    this._beforeGetDataDate = getLateUpdateDate;
                    this._beforeGetDataTime = getLateUpdateTime;
                }
                // --- UPD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 --------------------<<<<<
			}
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

            // 引数
            ScmOdReadParam scmOdReadParam = new ScmOdReadParam();

            scmOdReadParam.InqOtherEpCd = this._enterpriseCd;
            scmOdReadParam.InqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode; // ADD 2011/08/10
            scmOdReadParam.UpdateDate = this._beforeGetDataDate;
            scmOdReadParam.UpdateTime = this._beforeGetDataTime;
            // 2011/02/18 >>>
            //scmOdReadParam.LatestDiscCode = (int)DivisionValues.LatestDiscCode.New; // 最新識別区分 最新

            scmOdReadParam.LatestDiscCode = (int)DivisionValues.LatestDiscCode.All; // 最新識別区分 全て
            // 2011/02/18 <<<
            scmOdReadParam.InqOrdAnsDivCd = (int)DivisionValues.InqOrdAnsDivCd.Inquiry; // 問発・回答種別 1:問発 
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            scmOdReadParam.InqOrdDataInputSystem = 10; // データ入力システム 10:パーツマン
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // 戻り値
            List<ScmOdrData> scmOdrDataList;
            List<ScmOdDtInq> scmOdDtInqList;
            List<ScmOdDtAns> scmOdDtAnsList;
            List<ScmOdDtCar> scmOdDtCarList;

            // テスト用
            //scmOdrDataList = CreateScmOdrDataForTest();
            //scmOdDtInqList = CreateScmOdDtInqForTest();
            //scmOdDtAnsList = new List<ScmOdDtAns>();
            //scmOdDtCarList = CreateScmOdDtCarForTest();

            //// 取得情報を保持。
            //this._scmOdrDataList = scmOdrDataList;
            //this._scmOdDtInqList = scmOdDtInqList;
            //this._scmOdDtCarList = scmOdDtCarList;

            //return (int)ResultUtil.Code.Normal;
            //// テストここまで

            // SCM受発注データ読込処理(Web)
            for (int i = 0; i < this._retryMaxCount; i++)
            {
                if (i != 0)
                {
                    // 初回以外は設定時間待機
                    System.Threading.Thread.Sleep(this._retryWaitTime);
                }

                try
                {
                    status = this._scmOdrDataAcs.ReadWithCar(scmOdReadParam,
                        out scmOdrDataList, out scmOdDtInqList, out scmOdDtAnsList, out scmOdDtCarList);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 取得情報を保持。
                        this._scmOdrDataList = scmOdrDataList;
                        this._scmOdDtInqList = scmOdDtInqList;
                        this._scmOdDtCarList = scmOdDtCarList;

                        LogWriter.LogWrite("新着データ取得処理正常終了");
                        return (int)Result.Code.Normal;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND
                        || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        // 本来新着データ件数取得0件でエラーになっているケース。
                        LogWriter.LogWrite("新着データが存在しませんでした。");
                        return (int)Result.Code.Error;
                    }
                    else
                    {
                        LogWriter.LogWrite("新着データ取得処理でエラーが発生しました。");
                    }
                }
                catch (Exception e)
                {
                    LogWriter.LogWrite("新着データ取得処理でエラーが発生しました。");
                    LogWriter.LogWrite(e.Message);
                }
            }

            LogWriter.LogWrite("新着データ取得処理で設定回数リトライを行いましたがエラーが発生しました。");
            return (int)Result.Code.Error;
        }

        /// <summary>
        /// ローカルDBへ登録します。
        /// </summary>
        /// <returns>結果コード</returns>
        /// <see cref="ISCMChecker"/>
        public int CopyToLocal()
        {
            LogWriter.LogWrite("新着データDB登録処理開始");

            // ローカルDB型へ変換
            // 2011/02/18 >>>
            //bool isOK = this.ConvertToUserSCMOrderHeaderRecord(this._scmOdrDataList, out this._userSCMOrderHeaderRecordList);
            bool isOK = this.ConvertToUserSCMOrderHeaderRecord(this._scmOdrDataList, out this._userSCMOrderHeaderRecordList, out this._newDataKeyList);
            // 2011/02/18 <<<
            if (!isOK)
            {
                // 2011/03/18 >>>
                //// 該当得意先がない等、エラーの場合はここで処理終了。(次回起動時に対象とするため)
                //return (int)Result.Code.Error;

                // 該当得意先がない等、エラーの場合はここで処理終了。(次回起動時に対象とするため)
                return (int)Result.Code.NotFound;
                // 2011/03/18 <<<
            }

            this.ConvertToUserSCMOrderDetailRecord(this._scmOdDtInqList, out this._userSCMOrderDetailRecordList);
            this.ConvertToUserSCMOrderCarRecord(this._scmOdDtCarList, out this._userSCMOrderCarRecordList);

            // テスト用
            //return 0;

            // 2011/02/18 Add >>>
            Dictionary<string, Dictionary<string, bool>> allCheckList = new Dictionary<string, Dictionary<string, bool>>();
            // 2011/02/18 Add <<<

            CustomSerializeArrayList writeList = new CustomSerializeArrayList();

            foreach (ISCMOrderHeaderRecord header in this._userSCMOrderHeaderRecordList)
            {
                string datakey = SCMOdrDataUtil.SCMOdrDataToUniqueKey(header);  // 2011/02/18 Add

                // ADD 2010/06/29 PM7連携時はSCM系データをDBに書かない ---------->>>>>
                // FIXME:旧システム連携の対象となるデータは無視（DBに書かない）
                if (SCMOdrDataUtil.IsLegacyHeaderRecord(header))
                {
                    const string FORMAT = "旧システム連携の対象データであるため、DBへ書込みません。問合せ番号：{0} 企業コード：{1} 拠点コード：{2}";
                    string msg = string.Format(
                        FORMAT,
                        header.InquiryNumber,
                        header.InqOtherEpCd,
                        header.InqOtherSecCd
                    );
                    LogWriter.LogWrite(msg);
                    continue;
                }
                // ADD 2010/06/29 PM7連携時はSCM系データをDBに書かない ----------<<<<<

                List<ISCMOrderDetailRecord> detailList;
                ISCMOrderCarRecord carInfo;

                SCMOdrDataUtil.GetRelatedSCMOdrAcData(
                    // 2011/02/18 Add >>>
                                    1,  // NS用モード(受信日時までチェックする)
                    // 2011/02/18 Add <<<
                                    header,
                                    this._userSCMOrderDetailRecordList,
                                    this._userSCMOrderCarRecordList,
                                    out detailList,
                                    out carInfo);
                // 2011/02/18 Add >>>
                // ヘッダも全履歴が取得される為、対応する明細が無かった時は対象外とする
                if (detailList == null || detailList.Count == 0) continue;
                // 2011/02/18 Add <<<

                // 2011/02/18 Del >>>
                //// ADD 2010/06/16 キャンセルデータ用の補正処理を追加 ---------->>>>>
                //// キャンセルデータ用の補正処理
                //// （SCM受注データおよびSCM受注明細データ(問合せ・発注)のレイアウト変更に伴う補正）
                //// ∵SCM受注データの「回答区分 = 99:キャンセル」は
                //// 　対応するSCM受注明細データ(問合せ・発注)に追加された「キャンセル状態区分」を参照しなければ設定できないため
                //// 　補正という位置付けで再設定する。
                //header.AnswerDivCd = SCMOdrDataUtil.GetAnswerDivCdIfCanceling(detailList, header.AnswerDivCd);
                //// ADD 2010/06/16 キャンセルデータ用の補正処理を追加 ----------<<<<<
                // 2011/02/18 Del <<<

                // 既存データの確認
                object retObject;
                this.CheckExistData(header, out retObject);

                if (retObject != null
                    && ((CustomSerializeArrayList)retObject).Count != 0)
                {
                    // 既存データがある場合、車両情報の共通ヘッダを設定
                    SCMAcOdrData scmAcOdrData;
                    List<SCMAcOdrDtlIq> scmAcOdrDtlIqList;
                    List<SCMAcOdrDtlAs> scmAcOdrDtlAsList;
                    SCMAcOdrDtCar scmAcOdrDtCar;

                    IOWriterUtil.ExpandSCMReadRet(retObject, out scmAcOdrData, out scmAcOdrDtlIqList, out scmAcOdrDtlAsList, out scmAcOdrDtCar);

                    // 2010/03/31 Add >>>
                    List<ISCMOrderDetailRecord> dtlList;
                    this.ConvertToUserSCMOrderDetailRecord(scmAcOdrDtlIqList, out dtlList);
                    if (this._orgDetailRecord == null) this._orgDetailRecord = new List<ISCMOrderDetailRecord>();
                    if (dtlList != null) this._orgDetailRecord.AddRange(dtlList);

                    List<ISCMOrderAnswerRecord> ansList;
                    this.ConvertToUserSCMOrderAnswerRecord(scmAcOdrDtlAsList, out ansList);
                    if (this._orgAnswerList == null) this._orgAnswerList = new List<ISCMOrderAnswerRecord>();
                    if (ansList != null) this._orgAnswerList.AddRange(ansList);
                    // 2010/03/31 Add <<<

                    // 2010/03/08 >>>
                    //((UserSCMOrderCarRecord)carInfo).CreateDateTime = scmAcOdrDtCar.CreateDateTime;
                    //((UserSCMOrderCarRecord)carInfo).UpdateDateTime = scmAcOdrDtCar.UpdateDateTime;
                    //((UserSCMOrderCarRecord)carInfo).FileHeaderGuid = scmAcOdrDtCar.FileHeaderGuid;
                    //((UserSCMOrderCarRecord)carInfo).UpdEmployeeCode = scmAcOdrDtCar.UpdEmployeeCode;
                    //((UserSCMOrderCarRecord)carInfo).UpdAssemblyId1 = scmAcOdrDtCar.UpdAssemblyId1;
                    //((UserSCMOrderCarRecord)carInfo).UpdAssemblyId2 = scmAcOdrDtCar.UpdAssemblyId2;
                    if (header.AcptAnOdrStatus == scmAcOdrDtCar.AcptAnOdrStatus && header.SalesSlipNum == scmAcOdrDtCar.SalesSlipNum)
                    {
                        ((UserSCMOrderCarRecord)carInfo).CreateDateTime = scmAcOdrDtCar.CreateDateTime;
                        ((UserSCMOrderCarRecord)carInfo).UpdateDateTime = scmAcOdrDtCar.UpdateDateTime;
                        ((UserSCMOrderCarRecord)carInfo).FileHeaderGuid = scmAcOdrDtCar.FileHeaderGuid;
                        ((UserSCMOrderCarRecord)carInfo).UpdEmployeeCode = scmAcOdrDtCar.UpdEmployeeCode;
                        ((UserSCMOrderCarRecord)carInfo).UpdAssemblyId1 = scmAcOdrDtCar.UpdAssemblyId1;
                        ((UserSCMOrderCarRecord)carInfo).UpdAssemblyId2 = scmAcOdrDtCar.UpdAssemblyId2;
                    }
                    // 2010/03/08 <<<

                    // 2011/02/18 Add >>>

                    // USER_DB上の明細を、回答済みと未回答に振り分けする
                    if (!allCheckList.ContainsKey(datakey))
                    {
                        Dictionary<string, bool> checkList = SCMOdrDataUtil.CreateAnswerdCheckDictionary(header.CancelDiv, scmAcOdrDtlIqList, scmAcOdrDtlAsList);
                        if (checkList != null)
                        {
                            allCheckList.Add(datakey, checkList);
                        }
                    }
                }
                // 2011/02/18 Add >>>
                else
                {
                    header.AnswerDivCd = (int)AnswerDivCd.NoAction;
                }

                Dictionary<string, bool> answerCheckList = new Dictionary<string, bool>();
                if (allCheckList.ContainsKey(datakey))
                {
                    answerCheckList = allCheckList[datakey];
                }
                else
                {
                    allCheckList.Add(datakey, answerCheckList);
                }


                if (answerCheckList.Count == 0)
                {
                    foreach (ISCMOrderDetailRecord dtl in detailList)
                    {
                        string key = string.Format("{0},{1}", dtl.InqRowNumber, dtl.InqRowNumDerivedNo);
                        answerCheckList.Add(key, (dtl.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled));
                    }
                }
                else
                {
                    foreach (ISCMOrderDetailRecord dtl in detailList)
                    {
                        string key = string.Format("{0},{1}", dtl.InqRowNumber, dtl.InqRowNumDerivedNo);
                        if (answerCheckList.ContainsKey(key))
                        {
                            if (dtl.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled)
                            {
                                answerCheckList[key] = true;
                            }
                            else
                            {
                                answerCheckList[key] = false;
                            }
                        }
                        else
                        {
                            answerCheckList.Add(key, false);
                        }
                    }
                }
                allCheckList[datakey] = answerCheckList;

                // 現在、未回答データが存在しない場合は、
                if (answerCheckList == null && answerCheckList.Count == 0)
                {
                    header.AnswerDivCd = (int)AnswerDivCd.NoAction;
                }
                else
                {
                    // 現在処理している問合せ番号、問/発種別の全明細の回答、未回答が振り分けられた
                    int answerDivCd = (int)AnswerDivCd.NoAction;
                    bool answerdExists = false;
                    bool noansweredExists = false;

                    // 回答区分判定
                    // 未回答・回答が存在：一部回答
                    // 回答のみ存在　　　：回答完了
                    // 上記以外　　　　　：未回答
                    foreach (bool answerd in answerCheckList.Values)
                    {
                        if (answerd)
                            answerdExists = true;
                        else
                            noansweredExists = true;

                        if (answerdExists && noansweredExists) break;
                    }

                    if (answerdExists && noansweredExists)
                    {
                        answerDivCd = (int)AnswerDivCd.PartAnswer;
                    }
                    else if (answerdExists)
                    {
                        answerDivCd = (int)AnswerDivCd.AnswerCompletion;
                    }
                    else
                    {
                        answerDivCd = (int)AnswerDivCd.NoAction;
                    }
                    header.AnswerDivCd = answerDivCd;
                }
                // 2011/02/18 Add <<<
                // 2011/02/18 Add <<<

                // 2011/02/18 Add >>>
                // キャンセル以外で発注時は、問合せデータも読み込む
                if (header.CancelDiv == 0 && header.InqOrdDivCd == (int)InqOrdDivCd.Order)
                {
                    header.InqOrdDivCd = (int)InqOrdDivCd.Inquiry;
                    object retObject2;
                    this.CheckExistData(header, out retObject2);

                    if (retObject2 != null
                        && ((CustomSerializeArrayList)retObject2).Count != 0)
                    {
                        // 既存データがある場合、車両情報の共通ヘッダを設定
                        SCMAcOdrData scmAcOdrData2;
                        List<SCMAcOdrDtlIq> scmAcOdrDtlIqList2;
                        List<SCMAcOdrDtlAs> scmAcOdrDtlAsList2;
                        SCMAcOdrDtCar scmAcOdrDtCar2;

                        IOWriterUtil.ExpandSCMReadRet(retObject2, out scmAcOdrData2, out scmAcOdrDtlIqList2, out scmAcOdrDtlAsList2, out scmAcOdrDtCar2);

                        // 2010/03/31 Add >>>
                        //List<ISCMOrderDetailRecord> dtlList2;
                        //this.ConvertToUserSCMOrderDetailRecord(scmAcOdrDtlIqList, out dtlList);
                        //if (this._orgDetailRecord == null) this._orgDetailRecord = new List<ISCMOrderDetailRecord>();
                        //if (dtlList != null) this._orgDetailRecord.AddRange(dtlList);

                        List<ISCMOrderAnswerRecord> ansList2;
                        this.ConvertToUserSCMOrderAnswerRecord(scmAcOdrDtlAsList2, out ansList2);
                        if (this._orgAnswerList == null) this._orgAnswerList = new List<ISCMOrderAnswerRecord>();
                        if (ansList2 != null) this._orgAnswerList.AddRange(ansList2);
                    }
                    header.InqOrdDivCd = (int)InqOrdDivCd.Order;
                }
                // 2011/02/18 Add <<<

                ArrayList detail = new ArrayList();
                foreach (UserSCMOrderDetailWrapper detailWrapper in detailList)
                {
                    detail.Add(detailWrapper.RealRecord);
                }

                CustomSerializeArrayList oneInquiryList = new CustomSerializeArrayList();
                oneInquiryList.Add(((UserSCMOrderHeaderWrapper)header).RealRecord);
                oneInquiryList.Add(((UserSCMOrderCarWrapper)carInfo).RealRecord);
                oneInquiryList.Add(detail);

                writeList.Add(oneInquiryList);
            }

            object writePara = writeList;

            // Write実行
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = this._iIOWriteScmDB.ScmWrite(ref writePara, CT_IOWriter_Writemode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    LogWriter.LogWrite("新着データDB登録処理正常終了");
                    return (int)Result.Code.Normal;
                }
                else
                {
                    LogWriter.LogWrite("新着データDB登録処理でエラーが発生しました。ddd");
                    LogWriter.LogWrite(Convert.ToString(status));
                    return (int)Result.Code.Error;
                }
            }
            catch (Exception e)
            {
                LogWriter.LogWrite("新着データDB登録処理で例外が発生しました。");
                LogWriter.LogWrite(e.Message);
                return (int)Result.Code.Error;
            }
        }

        /// <summary>
        /// ステータスを更新します。
        /// </summary>
        /// <returns>結果コード</returns>
        /// <see cref="ISCMChecker"/>
        public int UpdateWebDBStatus()
        {
            LogWriter.LogWrite("新着データWeb更新処理開始");

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // SCM受発注データの回答区分を更新
            for (int i = 0; i < this._scmOdrDataList.Count; i++)
            {
                ScmOdrData scmOdrData = this._scmOdrDataList[i];

                //>>>2011/05/25
                //if (scmOdrData.AnswerDivCd == (int)DivisionValues.AnswerDivCd.NoAction)
                if (scmOdrData.AnswerDivCd == (int)DivisionValues.AnswerDivCd.OnAnswer)
                //<<<2011/05/25
                {
                    // 回答区分"未アクション"を"回答中"に更新
                    //scmOdrData.AnswerDivCd = (int)DivisionValues.AnswerDivCd.OnAnswer; // 2011/05/25
                    scmOdrData.AnswerDivCd = (int)DivisionValues.AnswerDivCd.AccComplete; // 2011/05/25
                    // 問発回答区分を"回答"に
                    scmOdrData.InqOrdAnsDivCd = (int)DivisionValues.InqOrdAnsDivCd.Answer;
                    // 最新識別区分
                    scmOdrData.LatestDiscCode = (int)DivisionValues.LatestDiscCode.New;

                    // 回答従業員コード
                    CustomerSearchRet ret = this.GetCustomerSearchRet(scmOdrData.InqOtherEpCd, scmOdrData.InqOriginalEpCd.Trim(), scmOdrData.InqOriginalSecCd);//@@@@20230303

                    if (ret != null)
                    {
                        scmOdrData.AnsEmployeeCd = ret.CustomerAgentCd;
						#region 2012.04.10 TERASAKA DEL STA
//                        scmOdrData.AnsEmployeeNm = this.GetEmployeeName(this._enterpriseCd, ret.CustomerAgentCd.Trim());
						#endregion
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
						scmOdrData.AnsEmployeeNm = ret.CustomerAgentNm;
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
                    }
                    // 注：nullはあり得ない(DB登録処理内でエラーになっている)
                }
                // 2010/04/30 Add >>>
                // キャンセルも新着通知
                else if (scmOdrData.AnswerDivCd == (int)DivisionValues.AnswerDivCd.Cancel)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    continue;
                }
                // 2010/04/30 Add <<<
                else
                {
                    // 未アクション以外は処理なし
                    continue;
                }

                List<ScmOdDtInq> relatedSCMOdDtInqList;
                ScmOdDtCar relatedScmOdDtCar;

                // 受発注データと同じキーの明細情報を取得
                SCMOdrDataUtil.GetRelatedSCMOdrData(scmOdrData, this._scmOdDtInqList, this._scmOdDtCarList,
                    out relatedSCMOdDtInqList, out relatedScmOdDtCar);

                // 更新処理
                List<ScmOdrData> scmOdrDataList = new List<ScmOdrData>();
                scmOdrDataList.Add(scmOdrData);

                for (int j = 0; j < this._retryMaxCount; j++)
                {
                    if (j != 0)
                    {
                        // 初回以外は設定時間待機
                        System.Threading.Thread.Sleep(this._retryWaitTime);
                    }

                    try
                    {
                        // 回答区分の書き換えの為にレコードがインサートされてしまうので、
                        // UpdateRcvDateTime()を使用する
                        status = this._scmOdrDataAcs.UpdateRcvDateTime(ref scmOdrDataList);
                        //status = this._scmOdrDataAcs.WriteInqWithCar(ref scmOdrDataList, ref relatedScmOdDtCar, ref relatedSCMOdDtInqList);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            break;
                        }
                        else
                        {
                            LogWriter.LogWrite("新着データWeb更新処理でエラーが発生しました。");
                        }
                    }
                    catch (Exception e)
                    {
                        LogWriter.LogWrite("新着データWeb更新処理でエラーが発生しました。");
                        LogWriter.LogWrite(e.Message);
                    }
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    LogWriter.LogWrite("新着データWeb更新処理で設定回数リトライを行いましたがエラーが発生しました。");
                    break;
                }
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                LogWriter.LogWrite("新着データWeb更新処理正常終了");
                return (int)Result.Code.Normal;
            }
            else
            {
                return (int)Result.Code.Error;
            }
        }

        /// <summary>
        /// 拠点毎の旧システム連携を判別し、自動回答かCSV書き出しを行う。
        /// </summary>
        /// <returns></returns>
        public int ExecuteAutoReplyOrCSVOutput()
        {
            LogWriter.LogWrite("自動回答、CSV出力処理開始");
            // 旧システム連携拠点リストの作成
            // SCM全体設定マスタ情報を取得
            SCMTtlStAcs scmTtlStAcs = new SCMTtlStAcs();

            ArrayList scmTtlStArray;
            int status;
            status = scmTtlStAcs.SearchAll(out scmTtlStArray, this._enterpriseCd);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                LogWriter.LogWrite("SCM全体設定マスタ読込みでエラーが発生しました。");
                return (int)Result.Code.Error;
            }

            // 旧システム連携あり拠点リストを作成
            // key:拠点コード、value:CSV出力先フォルダ
            Dictionary<string, string> legacySectionList = new Dictionary<string, string>();
            IList<SCMTtlSt> legacySCMTotalSettingList = new List<SCMTtlSt>();
            // 2010/12/27 Add >>>
            // SCM全体設定マスタからNS,PM7SP振り分け用のディクショナリ
            // key:拠点コード、value:SCM全体設定.旧システム連携区分
            Dictionary<string, int> scmTargetList = new Dictionary<string, int>();
            // 2010/12/27 Add <<<

            // 旧システム連携あり拠点リストの作成
            foreach (SCMTtlSt scmTtlSt in scmTtlStArray)
            {
                if (scmTtlSt.LogicalDeleteCode == 0
                    && scmTtlSt.OldSysCooperatDiv == 1)
                {
                    legacySectionList.Add(scmTtlSt.SectionCode.Trim().PadLeft(2, '0'), scmTtlSt.OldSysCoopFolder);
                    legacySCMTotalSettingList.Add(scmTtlSt);
                }
                // 2010/12/27 Add >>>
                if (scmTtlSt.LogicalDeleteCode == 0)
                {
                    scmTargetList.Add(scmTtlSt.SectionCode.Trim(), scmTtlSt.OldSysCooperatDiv);
                }
                // 2010/12/27 Add <<<
            }

            // テスト用CSV出力先
            //legacySectionList.Add("01", "Z:\\98-作業フォルダ\\上野\\SCMプロジェクト\\拠点1のシステム連携フォルダ");

            // 旧システム連携なしリスト(自動回答対象)
            List<ISCMOrderHeaderRecord> notLegacyHeaderRecordList;
            List<ISCMOrderDetailRecord> notLegacyDetailRecordList;
            List<ISCMOrderCarRecord> notLegacyCarRecordList;
            // 旧システム連携有りリスト(CSV出力対象)
            List<ISCMOrderHeaderRecord> legacyHeaderRecordList;
            List<ISCMOrderDetailRecord> legacyDetailRecordList;
            List<ISCMOrderCarRecord> legacyCarRecordList;

            // 2011/02/18 Add >>>
            if (this._newDataKeyList == null) this._newDataKeyList = new List<string>();
            // 2011/02/18 Add <<<

            SCMOdrDataUtil.FilterByLegacySection(
                // 2010/12/27 >>>
                //legacySectionList,
                //this._simplInqCnectInfoList,          // 2010/03/30 Add
                scmTargetList,
                // 2010/12/27 <<<
                // 2011/02/18 Add >>>
                _newDataKeyList,
                // 2011/02/18 Add <<<
                this._userSCMOrderHeaderRecordList,
                this._userSCMOrderDetailRecordList,
                this._userSCMOrderCarRecordList,
                out notLegacyHeaderRecordList,
                out notLegacyDetailRecordList,
                out notLegacyCarRecordList,
                out legacyHeaderRecordList,
                out legacyDetailRecordList,
                out legacyCarRecordList);

            if (notLegacyHeaderRecordList.Count != 0)
            {
                // 2010/05/21 Add >>>
                PurchaseStatus psSCMAutoAnswer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCMAutoAnswer);
                if (psSCMAutoAnswer != PurchaseStatus.Contract && psSCMAutoAnswer != PurchaseStatus.Trial_Contract)
                {
                    LogWriter.LogWrite("自動回答オプションが契約されていません。");
                }
                else
                {
                    // 2010/05/21 Add <<<

                    // 2010/03/31 Add >>>
                    //// 自動回答処理を行う
                    //status = this.ExecuteAutoReply(notLegacyHeaderRecordList,
                    //                        notLegacyDetailRecordList,
                    //    //notLegacyAnswerRecordList,
                    //                        notLegacyCarRecordList);
                    List<ISCMOrderDetailRecord> targetDtlList;
                    List<ISCMOrderAnswerRecord> targetAndList;

                    this.GetOrgAnswerAndDetail(notLegacyHeaderRecordList, notLegacyDetailRecordList, this._orgDetailRecord, this._orgAnswerList, out targetDtlList, out targetAndList);

                    // 自動回答処理を行う
                    status = this.ExecuteAutoReply(notLegacyHeaderRecordList,
                                            notLegacyDetailRecordList,
                                            notLegacyCarRecordList,
                                            targetDtlList,
                                            targetAndList
                                            );
                }   // 2010/03/31 Add <<<
            }

            if (legacyHeaderRecordList.Count != 0)
            {
                // 旧システム連携ファイル出力処理を行う。
                status = this.OutputCSVFileForLegacySystem(legacySectionList,
                                                legacyHeaderRecordList,
                                                legacyDetailRecordList,
                    //legacyAnswerRecordList,
                                                legacyCarRecordList);
            }

            LogWriter.LogWrite("自動回答、CSV出力処理終了");

            // 旧システム連携あり拠点リストあり→旧システムの回答データを送信
            if (legacySectionList != null && legacySectionList.Count > 0)
            {
                SendAnswerOfLegacySystem(legacySCMTotalSettingList);
            }

            // DB登録、Web更新後はエラー時でもポップアップ命令を送信する
            return (int)Result.Code.Normal;
        }

        /// <summary>
        /// 旧システムの回答データを送信します。
        /// </summary>
        /// <param name="legacySCMTotalSettingList"></param>
        private static void SendAnswerOfLegacySystem(IList<SCMTtlSt> legacySCMTotalSettingList)
        {
            LogWriter.LogWrite("PM7SP::回答送信処理開始");

            foreach (SCMTtlSt scmTotalSetting in legacySCMTotalSettingList)
            {
                string sendingDataPath = SCMConfig.GetSCMSendingDataPath(scmTotalSetting);

                LogWriter.WriteDebugLog("SCMChecker.SendAnswerOfLegacySystem()", "PM7SP::回答送信処理中..." + sendingDataPath);

                int status = SCMControllerFacade.SendToWebServerByPM7BatchMode(sendingDataPath);
                if (!status.Equals((int)Result.Code.Normal))
                {
                    string msg = string.Format("PM7SP::回答送信処理中にエラーが発生しました。(status={0})", status);
                    LogWriter.LogWrite(msg);
                    return;
                }
            }
            LogWriter.LogWrite("PM7SP::回答送信処理終了");
        }

        /// <summary>
        /// 端末へポップアップ命令を送信します。
        /// </summary>
        /// <returns>結果コード</returns>
        /// <see cref="ISCMChecker"/>
        public int SendShowingPopup()
        {
            LogWriter.LogWrite("ポップアップ命令送信処理開始");

            // 送信先IPアドレスを取得
            INetworkConfig networkConfig = NetworkConfigFactory.Create(NetworkConfigType.DB);

            // DB情報取得
            ((DBNetworkConfig)networkConfig).GetIPAddressInfo(this._userSCMOrderHeaderRecordList, this._portNumber, this._enterpriseCd);

            // メッセージを送信
            IIterator<INetworkConfig> iter = networkConfig.CreateIterator();

            while (iter.HasNext())
            {
                INetworkConfig iNetworkConfig = iter.GetNext();

                try
                {
                    ITextMessageSendable textSender = MessengerFactory.CreateTextSender(
                        ProtcolType.TCP,
                        iNetworkConfig.IPAddress.ToString(),
                        iNetworkConfig.PortNumber
                    );
                    textSender.Disconnect();
                }
                catch (Exception e)
                {
                    LogWriter.LogWrite("ポップアップ命令送信処理でエラーが発生しました。");
                    LogWriter.LogWrite(e.Message);
                }
            }

            LogWriter.LogWrite("ポップアップ命令送信処理終了");

            return (int)Result.Code.Normal;
        }
        #endregion

        #region 受信日時更新処理
        /// <summary>
        /// 回答区分「回答済」のSCM受注データ取得処理(User)
        /// </summary>
        /// <returns></returns>
        public int SearchSCMAcOdrDataAtNoReceiveDate()
        {
            LogWriter.LogWrite("回答済データ取得処理処理開始");

            IOWriteSCMReadWork readWork = new IOWriteSCMReadWork();

            readWork.EnterpriseCode = this._enterpriseCd;
            Int32[] answerDivList = new Int32[1] { (int)DivisionValues.AnswerDivCd.AnsComplete }; // 回答区分「回答済」

            readWork.AnswerDivCds = answerDivList;

            //>>>2010/03/08
            DateTime dt = DateTime.Today;
            dt = dt.AddDays(this._watchingSpan * -1);
            readWork.UpdateDateOver = dt;
            readWork.ReceiveDTZeroDiv = 1;
            //<<<2010/03/08

            object paraObject = readWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            object retObject = new CustomSerializeArrayList();

            try
            {
                status = this._iIOWriteScmDB.ScmSearch(ref retObject, paraObject);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._completeDataList = (CustomSerializeArrayList)retObject;

                    LogWriter.LogWrite("回答済データ取得処理正常終了");

                    return (int)Result.Code.Normal;
                }
                else
                {
                    LogWriter.LogWrite("回答済データ取得処理でエラーが発生しました。");
                    LogWriter.LogWrite(Convert.ToString(status));
                    return (int)Result.Code.Error;
                }
            }
            catch (Exception e)
            {
                LogWriter.LogWrite("回答済データ取得処理でエラーが発生しました。");
                LogWriter.LogWrite(e.Message);
                return (int)Result.Code.Error;
            }
        }

        /// <summary>
        /// SCM受発注データ取得処理(Web)
        /// </summary>
        /// <returns></returns>
        public int SearchScmOdrDataAtNoReceiveDate()
        {
            LogWriter.LogWrite("回答済Webデータ取得処理処理開始");

            #region <計測>

            SimpleStopWatch stopWatch = new SimpleStopWatch(
                string.Format("SearchScmOdrDataAtNoReceiveDate{0}.txt", "_")
            );
            stopWatch.Memo(Environment.NewLine + string.Format(
                "{0}\tループ数：回答区分「回答完了」リスト(IOWriter.SCMSearchの戻り値)の件数={1}",
                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                _completeDataList.Count
            ));

            LogWriter.LogWrite(string.Format(
                "■{0}\tループ数：回答区分「回答完了」リスト(IOWriter.SCMSearchの戻り値)の件数={1}",
                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                _completeDataList.Count
            ));

            #endregion // <計測>

            DateTime today = DateTime.Today;
            int loopCount = 0;
            foreach (object dataList in this._completeDataList)
            {
                loopCount++;

                SCMAcOdrData header;
                List<SCMAcOdrDtlIq> detailList;
                List<SCMAcOdrDtlAs> answerList;
                SCMAcOdrDtCar car;

                #region <計測>

                stopWatch.Start(
                    string.Format("\t回答区分「回答完了」リスト(IOWriter.SCMSearchの戻り値)[ {0} ]を展開", loopCount)
                );

                #endregion // </計測>

                IOWriterUtil.ExpandSCMReadRet(dataList, out header, out detailList, out answerList, out car);

                //>>>2010/03/08
                //LogWriter.LogWrite(string.Format(
                //    "■■問合せ番号：{0} 　売上伝票番号：{1}　更新日時：{2} {3}　ヘッダ更新日時：{4}",
                //    header.InquiryNumber,
                //    header.SalesSlipNum,
                //    header.UpdateDate.ToString(),
                //    header.UpdateTime.ToString(),
                //    header.UpdateDateTime.ToString()
                //    ));
                //<<<2010/03/08

                //LogWriter.LogWrite(string.Format("■回答区分「回答完了」リスト(IOWriter.SCMSearchの戻り値)[ {0} ]を展開", header.InquiryNumber));

                #region <計測>

                stopWatch.Stop();

                #endregion  // </計測>

                if (header.UpdateDate == DateTime.MinValue)
                {
                    #region <計測>

                    stopWatch.Memo(string.Format("☆未送信データです。(header.UpdateDate = {0})", header.UpdateDate.ToString()));
                    //LogWriter.LogWrite(string.Format("■未送信データです。(header.UpdateDate = {0})", header.UpdateDate.ToString()));

                    #endregion // </計測>

                    // 未送信(更新年月日が0)の場合、処理なし
                    continue;
                }

                if (header.ReceiveDateTime != DateTime.MinValue)
                {
                    #region <計測>

                    stopWatch.Memo(string.Format("☆受信日時が設定済です。(header.ReceiveDateTime = {0})", header.ReceiveDateTime.ToString()));
                    //LogWriter.LogWrite(string.Format("■受信日時が設定済です。(header.ReceiveDateTime = {0})", header.ReceiveDateTime.ToString()));

                    #endregion // </計測>

                    // 受信日時が設定済の場合、処理なし
                    continue;
                }
                TimeSpan passedSpan = today - header.UpdateDate;
                if (passedSpan.Days > this._watchingSpan)
                {
                    #region <計測>

                    stopWatch.Memo(string.Format("☆監視期間が過ぎています。(header.UpdateDate = {0})", header.UpdateDate.ToString()));
                    //LogWriter.LogWrite(string.Format("■監視期間が過ぎています。(header.UpdateDate = {0})", header.UpdateDate.ToString()));

                    #endregion // </計測>

                    // 監視期間が過ぎている場合、処理なし
                    continue;
                }

                //>>>2010/03/08
                if (header.InquiryNumber == 0)
                {
                    //LogWriter.LogWrite(string.Format("■問合せ番号がゼロです。(header.InquiryNumber = {0})", header.InquiryNumber.ToString()));

                    // 問合せ番号0は対象外
                    continue;
                }

                if (header.AcptAnOdrStatus == 20)
                {
                    //LogWriter.LogWrite(string.Format("■受注ステータスが受注です。(headerAcptAnodrStatus = {0})", header.AcptAnOdrStatus.ToString()));

                    // 受注ステータス：受注　は対象外
                    continue;
                }
                //<<<2010/03/08

                // 伝票番号で拾うため、最新以外のデータも取る
                ScmOdReadParam scmOdReadParam = new ScmOdReadParam();

                scmOdReadParam.InqOriginalEpCd = header.InqOriginalEpCd.Trim();//@@@@20230303
                scmOdReadParam.InqOriginalSecCd = header.InqOriginalSecCd;
                scmOdReadParam.InqOtherEpCd = header.InqOtherEpCd;
                scmOdReadParam.InqOtherSecCd = header.InqOtherSecCd;
                scmOdReadParam.InquiryNumber = header.InquiryNumber;
                //>>>2010/03/08
                //scmOdReadParam.UpdateDate = header.UpdateDate;
                //scmOdReadParam.UpdateTime = header.UpdateTime;
                //<<<2010/03/08
                scmOdReadParam.LatestDiscCode = (int)DivisionValues.LatestDiscCode.All;

                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                for (int i = 0; i < this._retryMaxCount; i++)
                {
                    if (i != 0)
                    {
                        // 初回以外は設定時間待機
                        System.Threading.Thread.Sleep(this._retryWaitTime);
                    }

                    try
                    {
                        List<ScmOdrData> webHeaderList;
                        List<ScmOdDtInq> webDetailList;
                        List<ScmOdDtAns> webAnswerList;
                        List<ScmOdDtCar> webCarList;

                        #region <計測>

                        stopWatch.Start(
                            string.Format("\t★SCM Webサーバアクセス：ScmOdrDataAcs.ReadWithCar()…リトライ{0}", i)
                        );

                        #endregion // </計測>

                        status = this._scmOdrDataAcs.ReadWithCar(scmOdReadParam,
                            out webHeaderList, out webDetailList, out webAnswerList, out webCarList);

                        #region <計測>

                        stopWatch.Stop();

                        #endregion // </計測>

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //>>>2010/03/08
                            //if (header.InqOrdDivCd == webHeaderList[0].InqOrdDivCd
                            //    && webHeaderList[0].ReceiveDateTime != DateTime.MinValue)
                            //{
                            //    // 問合せ発注種別が同じかつ受信日時に設定がある
                            //    header.ReceiveDateTime = webHeaderList[0].ReceiveDateTime;

                            //    if (this._updateRecDateHeaderList == null)
                            //    {
                            //        this._updateRecDateHeaderList = new List<ISCMOrderHeaderRecord>();
                            //    }

                            //    this._updateRecDateHeaderList.Add(new UserSCMOrderHeaderRecord(header));
                            //}

                            //LogWriter.LogWrite(string.Format(string.Format("■■■PMデータ更新日時：{0} {1}", header.UpdateDate.ToString(), header.UpdateTime.ToString())));
                            //LogWriter.LogWrite(string.Format(string.Format("■■■PMデータ問合せ元：{0} {1}", header.InqOriginalEpCd, header.InqOriginalSecCd)));
                            //LogWriter.LogWrite(string.Format(string.Format("■■■PMデータ問合せ先：{0} {1}", header.InqOtherEpCd, header.InqOtherSecCd)));
                            //foreach (ScmOdrData aaa in webHeaderList)
                            //{
                            //    LogWriter.LogWrite(string.Format(string.Format("■■■更新日時：{0} {1}", aaa.UpdateDate.ToString(), aaa.UpdateTime.ToString())));
                            //}


                            ScmOdrData targetScmOdrData = webHeaderList.Find(
                                delegate(ScmOdrData scmOdrData)
                                {
                                    if ((header.UpdateDate == scmOdrData.UpdateDate) &&
                                        (header.UpdateTime == scmOdrData.UpdateTime))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            );

                            if (targetScmOdrData != null)
                            {
                                //LogWriter.LogWrite(string.Format(string.Format("■■■種別：{0}=={1}  受信日時：{2}  伝票番号：{3}",
                                //    header.InqOrdDivCd, targetScmOdrData.InqOrdDivCd, targetScmOdrData.ReceiveDateTime.ToString(), header.SalesSlipNum)));

                                if (header.InqOrdDivCd == targetScmOdrData.InqOrdDivCd
                                    && targetScmOdrData.ReceiveDateTime != DateTime.MinValue)
                                {
                                    // 問合せ発注種別が同じかつ受信日時に設定がある
                                    header.ReceiveDateTime = targetScmOdrData.ReceiveDateTime;

                                    if (this._updateRecDateHeaderList == null)
                                    {
                                        this._updateRecDateHeaderList = new List<ISCMOrderHeaderRecord>();
                                    }

                                    this._updateRecDateHeaderList.Add(new UserSCMOrderHeaderRecord(header));
                                }
                            }
                            //<<<2010/03/08

                            break;
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND
                            || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                        {
                            //LogWriter.LogWrite(string.Format("■■■webデータに該当データ無し"));

                            // 該当0件の場合はリトライしない
                            break;
                        }
                        else
                        {
                            LogWriter.LogWrite("回答済Webデータ取得処理でエラーが発生しました。");
                        }
                    }
                    catch (Exception e)
                    {
                        LogWriter.LogWrite("回答済Webデータ取得処理でエラーが発生しました。");
                        LogWriter.LogWrite(e.Message);
                    }
                }

            }

            LogWriter.LogWrite("回答済Webデータ取得処理終了");

            return (int)Result.Code.Normal;
        }



        /// <summary>
        /// Web側で受信日時が設定されていたSCM受注データの更新処理(User)
        /// </summary>
        /// <returns></returns>
        public int UpdateSCMAcOdrDataAtReceiveDate()
        {
            if (this._updateRecDateHeaderList != null
                && this._updateRecDateHeaderList.Count != 0)
            {
                LogWriter.LogWrite("受信日時更新処理開始");

                CustomSerializeArrayList writeList = new CustomSerializeArrayList();

                foreach (ISCMOrderHeaderRecord iSCMOrderHeaderRecord in this._updateRecDateHeaderList)
                {
                    CustomSerializeArrayList oneWritePara = new CustomSerializeArrayList();

                    oneWritePara.Add(((UserSCMOrderHeaderWrapper)iSCMOrderHeaderRecord).RealRecord);

                    //>>>2010/03/08
                    //LogWriter.LogWrite(string.Format(
                    //    "■■問合せ番号：{0} 　売上伝票番号：{1}　更新日時：{2} {3}　ヘッダ更新日時：{4}",
                    //    ((UserSCMOrderHeaderWrapper)iSCMOrderHeaderRecord).RealRecord.InquiryNumber,
                    //    ((UserSCMOrderHeaderWrapper)iSCMOrderHeaderRecord).RealRecord.SalesSlipNum,
                    //    ((UserSCMOrderHeaderWrapper)iSCMOrderHeaderRecord).RealRecord.UpdateDate.ToString(),
                    //    ((UserSCMOrderHeaderWrapper)iSCMOrderHeaderRecord).RealRecord.UpdateTime.ToString(),
                    //    ((UserSCMOrderHeaderWrapper)iSCMOrderHeaderRecord).RealRecord.UpdateDateTime.ToString()
                    //    ));
                    //<<<2010/03/08

                    writeList.Add(oneWritePara);
                }

                object scmWritePara = (object)writeList;

                int status = this._iIOWriteScmDB.ScmWrite(ref scmWritePara, CT_IOWriter_Writemode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    LogWriter.LogWrite("受信日時更新処理正常終了");
                    return (int)Result.Code.Normal;
                }
                else
                {
                    LogWriter.LogWrite("受信日時の更新処理でエラーが発生しました。status = " + status.ToString());
                    return (int)Result.Code.Error;
                }
            }
            else
            {
                // 処理対象なし
                LogWriter.LogWrite("受信日時の更新対象レコードが存在しませんでした。");
            }

            return (int)Result.Code.Normal;
        }
        #endregion

        // 2010/12/27 Del >>>
#if False
        // 2010/03/30 Add >>>
        #region 簡単問合せ接続中リスト取得
        /// <summary>
        /// 簡単問合せで接続中のリスト取得
        /// </summary>
        /// <returns></returns>
        public int GetSimplInqCnectInfoList()
        {
            // DEL 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ---------->>>>>
            //this._simplInqCnectInfoList = SimplInqCnectInfoController.GetConnectionInfolist(this._enterpriseCd);
            // DEL 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ----------<<<<<
            // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ---------->>>>>
            this._simplInqCnectInfoList = new List<SimplInqCnectInfo>();
            // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ----------<<<<<
            return (int)Result.Code.Normal;
        }
        #endregion
        // 2010/03/30 Add <<<
#endif
        // 2010/12/27 Del <<<

        #endregion // </ISCMChecker メンバ>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMChecker(List<string> settingList)
        {
            this._enterpriseCd = settingList[0];

            // config設定の展開
            if (!Int32.TryParse(settingList[1], out this._retryWaitTime))
            {
                this._retryWaitTime = -1;
            }
            if (!Int32.TryParse(settingList[2], out this._retryMaxCount))
            {
                this._retryMaxCount = -1;
            }
            if (!Int32.TryParse(settingList[3], out this._portNumber))
            {
                this._portNumber = -1;
            }
            if (!Int32.TryParse(settingList[4], out this._watchingSpan))
            {
                this._watchingSpan = -1;
            }

            // --- ADD 2012/08/24 三戸 2012/12/12配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
            this._answerMode = settingList[5];
            // --- ADD 2012/08/24 三戸 2012/12/12配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 -------------------->>>>>
            this._sectionCd = settingList[6];
            // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 --------------------<<<<<
            this._iIOWriteScmDB = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB();
            this._scmOdrDataAcs = new ScmOdrDataAcs2(); // Webサーバーアクセス
            this._scmTtlStAcs = new SCMTtlStAcs(); // 全体設定マスタアクセス
            this._customerSearchAcs = new CustomerSearchAcs(); // 得意先マスタアクセス
            this._makerAcs = new MakerAcs(); // メーカーアクセス
            this._employeeAcs = new EmployeeAcs(); // 従業員アクセス
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            this._companyInfAcs = new CompanyInfAcs();
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
            // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 -------------------->>>>>
            this._scmTerminal = new SCMTerminal(this._enterpriseCd, this._sectionCd);
            // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 --------------------<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
			System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(SearchMakerName), _enterpriseCd);
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
        }

        #endregion // </Constructor>

        #region <private定数>
        /// <summary>売上伝票番号の初期値</summary>
        private const string CT_DefaultSalesSlipNum = "000000000";
        /// <summary>IOWriterのwritemode 0:Insert(更新日時R設定) 1:通常モード(更新日時UI設定。Updateあり)</summary>
        private const int CT_IOWriter_Writemode = 1;
        #endregion

        #region <private変数>
        private string _enterpriseCd; // 企業コード
        private int _retryWaitTime; // リトライ待機時間
        private int _retryMaxCount; // リトライ最大回数
        private int _portNumber; // ポップアップ送信用ポート番号
        private int _watchingSpan; // 監視する期間(日)
        // --- ADD 2012/08/24 三戸 2012/12/12配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
        private string _answerMode; //回答モード "0":通常モード "1":手動回答モード
        // --- ADD 2012/08/24 三戸 2012/12/12配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        private DateTime _beforeGetDataDate; // 前回新着データ取得年月日
        private int _beforeGetDataTime; // 前回新着データ取得時分秒ミリ秒

        private IIOWriteScmDB _iIOWriteScmDB; // I/O Writer
        private ScmOdrDataAcs2 _scmOdrDataAcs; // Webサーバーアクセスクラス
        private SCMTtlStAcs _scmTtlStAcs; // SCM全体設定マスタアクセス
        private CustomerSearchAcs _customerSearchAcs; // 得意先マスタアクセス
        private MakerAcs _makerAcs; // メーカーアクセス
        private EmployeeAcs _employeeAcs; // 従業員アクセス

        private List<CustomerSearchRet> _customerSearchRetList; // 得意先マスタ

        // SCM Webデータ(Webサービスアクセス用の型)
        private List<ScmOdrData> _scmOdrDataList; // SCM受発注データリスト
        private List<ScmOdDtInq> _scmOdDtInqList; // SCM受発注(問合せ・発注)リスト
        private List<ScmOdDtCar> _scmOdDtCarList; // SCM受発注(車両情報)リスト

        // 2011/02/18 Add >>>
        // PM7SP用
        private List<string> _newDataKeyList;
        // 2011/02/18 Add <<<

        // SCM Userデータ(ユーザDBアクセス用の型)
        private List<ISCMOrderHeaderRecord> _userSCMOrderHeaderRecordList; // SCM受注データリスト
        private List<ISCMOrderDetailRecord> _userSCMOrderDetailRecordList; // SCM受注(問合せ・発注)リスト
        private List<ISCMOrderCarRecord> _userSCMOrderCarRecordList; // SCM受注データ(車両情報)リスト

        // 2010/03/31 Add >>>
        private List<ISCMOrderAnswerRecord> _orgAnswerList;         // SCM受注(回答)リスト（元々回答していた分
        private List<ISCMOrderDetailRecord> _orgDetailRecord;       // SCM受注(問合せ・発注)リスト（元々問合せ来ていた分）
        // 2010/03/31 Add <<<

        // 回答区分「回答完了」リスト(IOWriter.SCMSearchの戻り値)
        private CustomSerializeArrayList _completeDataList;
        // 受注日時更新対象リスト
        private List<ISCMOrderHeaderRecord> _updateRecDateHeaderList; // SCM受注データリスト
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
		private static List<MakerUMnt>	_makerUMntList;		// メーカー名称
		private static bool _isGetMakerUMnt;	// メーカー名称取得済みフラグ
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

        // 2010/12/27 Del >>>
        //// 2010/03/30 Add >>>
        //// 簡単問合せで接続中得意先リスト
        //private List<SimplInqCnectInfo> _simplInqCnectInfoList;
        //// 2010/03/30 Add <<<
        // 2010/12/27 Del <<<

		#region 2012.04.10 TERASAKA DEL STA
//        // 2011/02/18 Add >>>
//        private List<string> _alreadyDataGetList;
//        // 2011/02/18 Add <<<
		#endregion

        // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
        private CompanyInfAcs _companyInfAcs;
        //private CompanyInf _companyInf;// Del 2011/08/10 duzg for Redmine#23502対応
        // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<

        // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 -------------------->>>>>
        // SCM取得基準日の値設定用ファイルパス
        private const string PERIOD_UISETTING = "PMSCM01000U_UserSetting.xml";

        private ScmPeriodSet _scmPeriod;

        private SCMTerminal _scmTerminal;

        private string _sectionCd; // 拠点コード
        // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 --------------------<<<<<
        #endregion

        #region <privateメソッド>

        #region 既存データチェック処理
        /// <summary>
        /// 既存データチェック処理
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        private int CheckExistData(ISCMOrderHeaderRecord header, out object retObject)
        {
            IOWriteSCMReadWork readWork = new IOWriteSCMReadWork();

            readWork.EnterpriseCode = header.InqOtherEpCd.Trim();
            readWork.InqOtherSecCd = header.InqOtherSecCd.Trim();
            readWork.InquiryNumber = header.InquiryNumber;
            //>>>2010/03/08
            readWork.InqOriginalEpCd = header.InqOriginalEpCd.Trim();
            readWork.InqOriginalSecCd = header.InqOriginalSecCd.Trim();
            readWork.InqOrdDivCd = header.InqOrdDivCd;
            //<<<2010/03/08
            // 2011/02/18 Add >>>
            readWork.CancelDivs = new short[] { header.CancelDiv };
            // 2011/02/18 Add <<<

            object readPara = readWork;
            retObject = new CustomSerializeArrayList();

            int status = this._iIOWriteScmDB.ScmRead(ref retObject, readPara);

            return status;
        }
        #endregion

        //-----ADD by huanghx for PCC-UOEメールメッセージ送信 on 2011.08.19 ----->>>>>
        /// <summary>
        /// PCC-UOEメールメッセージ送信
        /// </summary>
        /// <param name="sendEnterpriseCode">相手の企業コード</param>
        /// <param name="sendSectionCode">相手の拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecC">問合せ先拠点コード</param>
        /// <param name="updateDate">更新年月日</param>
        /// <param name="updateTime">更新時分秒ミリ秒</param>
        /// <param name="pccMailTitle">PCCメール件名</param>
        /// <param name="pccMailDocCnts">PCCメール本文</param>
        public static void NotifyOtherSidePCCUOEMessage(string sendEnterpriseCode, string sendSectionCode, string inqOtherEpCd, string inqOtherSecCd, Int32 updateDate, Int32 updateTime, string pccMailTitle, string pccMailDocCnts)
        {
            if (sendEnterpriseCode == null || sendEnterpriseCode == null)
            {
                return;
            }
            // SCM双方向通信サービスを利用して、新着チェッカーへメッセージを送信します。
            StringBuilder msg = new StringBuilder();
            msg.Append("PCCUOE_MESSAGE/");
            msg.Append(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", sendEnterpriseCode, sendSectionCode, inqOtherEpCd, inqOtherSecCd, updateDate.ToString(), updateTime.ToString(), pccMailTitle, pccMailDocCnts));

            string localIPAddress = null;
            int portNumber = 65000; // Default Port
            // ポップアップ受信用ポート番号を保持
            try
            {
                // ポップアップ画面のApp.Configから取得
                Configuration conf = ConfigurationManager.OpenExeConfiguration("PMSCM00005U.exe");
                portNumber = int.Parse(conf.AppSettings.Settings["PortNumber"].Value);
            }
            catch (Exception e)
            {
                LogWriter.LogWrite("ポート番号の取得が失敗しましたが、デフォールトポート65000が利用します。");
                LogWriter.LogWrite(e.Message);
            }

            INetworkConfig iNetworkConfig = NetworkConfigFactory.Create(NetworkConfigType.Default);

            ((DefaultNetworkConfig)iNetworkConfig).GetLocalIPAddressInfo(portNumber);

            IIterator<INetworkConfig> iter = iNetworkConfig.CreateIterator();

            // 自端末かつ1LAN環境なので実質一つ。
            if (iter.HasNext())
            {
                INetworkConfig config = iter.GetNext();

                // 自端末のIPアドレスを保持
                localIPAddress = config.IPAddress.ToString();
            }

            if (localIPAddress != null && portNumber > 0)
            {
                ITextMessageSendable textSender = MessengerFactory.CreateTextSender(
                    ProtcolType.TCP,
                    localIPAddress,
                    portNumber
                );
                textSender.Send(msg.ToString());
            }
        }
        //-----ADD by huanghx for PCC-UOEメールメッセージ送信  on 2011.08.19 -----<<<<<

        // 2011.08.15 zhouzy ADD STA >>>>>>

        // 2011.08.15 zhouzy update STA >>>>>>
        ///// <summary>
        ///// リモート伝票発行成功すると、対応端末の通知処理
        ///// </summary>
        ///// <param name="sendEnterpriseCode">相手の企業コード</param>
        ///// <param name="sendSectionCode">相手の拠点コード</param>
        ///// <param name="inqOtherEpCd">問合せ先企業コード</param>
        ///// <param name="inqOtherSecC">問合せ先拠点コード</param>
        ///// <param name="inquiryNumbe">問合せ番号</param>
        //public static void NotifyOtherSidePCCUOERslip(string sendEnterpriseCode, string sendSectionCode, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumbe)
        /// <summary>
        /// リモート伝票発行成功すると、対応端末の通知処理
        /// </summary>
        /// <param name="sendEnterpriseCode">相手の企業コード</param>
        /// <param name="sendSectionCode">相手の拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecC">問合せ先拠点コード</param>
        /// <param name="updateDate">更新年月日</param>
        /// <param name="updateTime">更新時分秒ミリ秒</param>
        /// <param name="slipPrtKind">伝票印刷種別</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        public static void NotifyOtherSidePCCUOERslip(string sendEnterpriseCode, string sendSectionCode, string inqOtherEpCd, string inqOtherSecCd,
            Int32 updateDate, Int32 updateTime, Int32 slipPrtKind, string salesSlipNum)
        // 2011.08.15 zhouzy update END <<<<<<
        {
            // オプション制御:PCCUOEのオプションを追加する必要
            bool canNotify = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RemoteSlipPrt) >= PurchaseStatus.Contract;

            if (!canNotify || sendEnterpriseCode == null || sendEnterpriseCode == null)
            {
                return;
            }
            // SCM双方向通信サービスを利用して、新着チェッカーへメッセージを送信します。
            StringBuilder msg = new StringBuilder();

            msg.Append("PCCUOE_RSLIP/");
            // 2011.08.15 zhouzy update STA >>>>>>
            //msg.Append(string.Format("{0},{1},{2},{3},{4}", sendEnterpriseCode, sendSectionCode, inqOtherEpCd, inqOtherSecCd, inquiryNumbe.ToString()));
            msg.Append(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", sendEnterpriseCode, sendSectionCode, inqOtherEpCd, inqOtherSecCd,
                updateDate.ToString(), updateTime.ToString(), slipPrtKind.ToString(), salesSlipNum.ToString()));
            // 2011.08.15 zhouzy update END <<<<<<

            string localIPAddress = null;
            int portNumber = 65000; // Default Port
            // ポップアップ受信用ポート番号を保持
            try
            {
                // ポップアップ画面のApp.Configから取得
                Configuration conf = ConfigurationManager.OpenExeConfiguration("PMSCM00005U.exe");
                portNumber = int.Parse(conf.AppSettings.Settings["PortNumber"].Value);
            }
            catch (Exception e)
            {
                LogWriter.LogWrite("ポート番号の取得が失敗しましたが、デフォールトポート65000が利用します。");
                LogWriter.LogWrite(e.Message);
            }

            INetworkConfig iNetworkConfig = NetworkConfigFactory.Create(NetworkConfigType.Default);

            ((DefaultNetworkConfig)iNetworkConfig).GetLocalIPAddressInfo(portNumber);

            IIterator<INetworkConfig> iter = iNetworkConfig.CreateIterator();

            // 自端末かつ1LAN環境なので実質一つ。
            if (iter.HasNext())
            {
                INetworkConfig config = iter.GetNext();

                // 自端末のIPアドレスを保持
                localIPAddress = config.IPAddress.ToString();
            }

            if (localIPAddress != null && portNumber > 0)
            {
                ITextMessageSendable textSender = MessengerFactory.CreateTextSender(
                    ProtcolType.TCP,
                    localIPAddress,
                    portNumber
                );
                textSender.Send(msg.ToString());
            }
        }
        // 2011.08.15 zhouzy ADD END <<<<<<

        // 2011.07.12 ZHANGYH ADD STA >>>>>>
        // 2011.09.06 zhouzy UPDATE STA >>>>>>
        ///// <summary>
        ///// 問合せ成功すると、対応端末の通知処理
        ///// </summary>
        ///// <param name="sendEnterpriseCodeList">相手の企業コード</param>
        ///// <param name="sendSectionCodeList">相手の拠点コード</param>
        //public static void NotifyOtherSide(List<string> sendEnterpriseCodeList, List<string> sendSectionCodeList)
        /// <summary>
        /// 問合せ成功すると、対応端末の通知処理
        /// </summary>
        /// <param name="sendEnterpriseCodeList">相手の企業コード</param>
        /// <param name="sendSectionCodeList">相手の拠点コード</param>
        /// <param name="acceptOrOrderKind">受発注種別[0:通常,1:PCC-UOE]</param>
        public static void NotifyOtherSide(List<string> sendEnterpriseCodeList, List<string> sendSectionCodeList, short acceptOrOrderKind)
        // 2011.09.06 zhouzy UPDATE END <<<<<<
        {
            // オプション制御
            bool canNotify = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) >= PurchaseStatus.Contract;

            if (!canNotify || sendEnterpriseCodeList == null || sendSectionCodeList == null || sendEnterpriseCodeList.Count == 0 || sendSectionCodeList.Count == 0)
            {
                return;
            }

            // SCM双方向通信サービスを利用して、新着チェッカーへメッセージを送信します。
            StringBuilder msg = new StringBuilder();
            for (int i = 0; i < sendEnterpriseCodeList.Count; i++)
            {
                if (i > 0)
                {
                    msg.Append("|");
                }
                else
                {
                    // 2011.09.05 zhouzy UPDATE STA >>>>>>
                    //msg.Append("SCM/");
                    if (acceptOrOrderKind == 0)
                    {
                        msg.Append("SCM/");
                    }
                    else
                    {
                        msg.Append("PCCUOE/");
                    }
                    // 2011.09.05 zhouzy UPDATE END <<<<<<
                }
                msg.Append(string.Format("{0},{1}", sendEnterpriseCodeList[i], sendSectionCodeList[i]));
            }

            string localIPAddress = null;
            int portNumber = 65000; // Default Port


            // ポップアップ受信用ポート番号を保持
            try
            {
                // ポップアップ画面のApp.Configから取得
                Configuration conf = ConfigurationManager.OpenExeConfiguration("PMSCM00005U.exe");
                portNumber = int.Parse(conf.AppSettings.Settings["PortNumber"].Value);
            }
            catch (Exception e)
            {
                LogWriter.LogWrite("ポート番号の取得が失敗しましたが、デフォールトポート65000が利用します。");
                LogWriter.LogWrite(e.Message);
            }

            INetworkConfig iNetworkConfig = NetworkConfigFactory.Create(NetworkConfigType.Default);

            ((DefaultNetworkConfig)iNetworkConfig).GetLocalIPAddressInfo(portNumber);

            IIterator<INetworkConfig> iter = iNetworkConfig.CreateIterator();

            // 自端末かつ1LAN環境なので実質一つ。
            if (iter.HasNext())
            {
                INetworkConfig config = iter.GetNext();

                // 自端末のIPアドレスを保持
                localIPAddress = config.IPAddress.ToString();
            }

            if (localIPAddress != null && portNumber > 0)
            {
                ITextMessageSendable textSender = MessengerFactory.CreateTextSender(
                    ProtcolType.TCP,
                    localIPAddress,
                    portNumber
                );
                textSender.Send(msg.ToString());
            }
        }
        // 2011.07.12 ZHANGYH ADD END <<<<<<

        #region 自動回答処理
        /// <summary>
        /// 自動回答処理実行
        /// </summary>
        /// <returns>結果コード</returns>
        /// <see cref="ISCMChecker"/>
        private int ExecuteAutoReply(List<ISCMOrderHeaderRecord> autoReplyHeaderRecordList,
                                 List<ISCMOrderDetailRecord> autoReplyDetailRecordList,
                                 List<ISCMOrderCarRecord> autoReplyCarRecordList
            // 2010/03/31 Add >>>
                                 , List<ISCMOrderDetailRecord> orgDetailRecordList
                                 , List<ISCMOrderAnswerRecord> orgAnswerRecordList
            // 2010/03/31 Add <<<
            )
        {
            // 自動回答処理呼出し
            try
            {
                LogWriter.LogWrite("自動回答処理開始");

                // --- ADD 2012/08/24 三戸 2012/12/12配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                AutoFacade.RunningMode runningMode = AutoFacade.RunningMode.Auto;
                if (this._answerMode == "1")
                {
                    runningMode = AutoFacade.RunningMode.Manual;
                }
                // --- ADD 2012/08/24 三戸 2012/12/12配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                //------------------ADD 2024/07/03 陳艶丹 BLP障害対応（例外発生箇所修正対応）---------------->>>>>
                List<ISCMOrderHeaderRecord> HeaderRecordList1 = new List<ISCMOrderHeaderRecord>();
                Dictionary<string, ISCMOrderHeaderRecord> headerRecordListDic = new Dictionary<string, ISCMOrderHeaderRecord>();
                string keyFitter = "";
                //SCM受注データの重複データをフィルタリングする
                if (autoReplyHeaderRecordList.Count > 0)
                {
                    foreach (ISCMOrderHeaderRecord HeaderRecord in autoReplyHeaderRecordList)
                    {
                        keyFitter = HeaderRecord.InqOriginalEpCd.Trim() + HeaderRecord.InqOriginalSecCd + HeaderRecord.InqOtherEpCd + HeaderRecord.InqOtherSecCd + HeaderRecord.InquiryNumber;
                        if (!headerRecordListDic.ContainsKey(keyFitter))
                        {
                            HeaderRecordList1.Add(HeaderRecord);
                            headerRecordListDic.Add(keyFitter, HeaderRecord);
                        }
                    }
                }
                int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                List<ISCMOrderDetailRecord> autoReplyDetailRecordListCust = new List<ISCMOrderDetailRecord>();
                List<ISCMOrderHeaderRecord> autoReplyHeaderRecordList1 = new List<ISCMOrderHeaderRecord>();
                for (int i = 0; i < HeaderRecordList1.Count; i++)
                {
                    autoReplyHeaderRecordList1.Clear();
                    autoReplyDetailRecordListCust.Clear();
                    autoReplyHeaderRecordList1.Add(HeaderRecordList1[i]);

                    //同じSCM受注データに対応するSCM受注明細データ(問合せ・発注)のレコードリストをフィルタする
                    autoReplyDetailRecordListCust = autoReplyDetailRecordList.FindAll(delegate(ISCMOrderDetailRecord iSCMOrderDetailRecord)
                       {
                           if (iSCMOrderDetailRecord.InqOriginalEpCd.Trim() == HeaderRecordList1[i].InqOriginalEpCd.Trim() &&
                               iSCMOrderDetailRecord.InqOriginalSecCd == HeaderRecordList1[i].InqOriginalSecCd &&
                               iSCMOrderDetailRecord.InqOtherEpCd == HeaderRecordList1[i].InqOtherEpCd &&
                               iSCMOrderDetailRecord.InqOtherSecCd == HeaderRecordList1[i].InqOtherSecCd &&
                               iSCMOrderDetailRecord.InquiryNumber == HeaderRecordList1[i].InquiryNumber)
                           {
                               return true;
                           }
                           else
                           {
                               return false;
                           }
                       }
                    );

                    SCMRespondent autoSCMRespondent = AutoFacade.CreateSCMRespondent(
                        runningMode,
                        autoReplyHeaderRecordList1,
                        autoReplyCarRecordList,
                        autoReplyDetailRecordListCust
                        , orgAnswerRecordList
                        , orgDetailRecordList
                        );

                    if (runningMode == AutoFacade.RunningMode.Manual)
                    {
                        //最後の一件に循環する場合、検索結果を強制的にクリアする
                        if (i == HeaderRecordList1.Count - 1)
                        {
                            autoSCMRespondent.ClearSearchResult();
                            return (int)Result.Code.Normal;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    List<string> sendEnterpriseCodeList;
                    List<string> sendSectionCodeList;
                    status = autoSCMRespondent.Reply(out sendEnterpriseCodeList, out sendSectionCodeList);

                    //最後の一件に循環する場合、検索結果を強制的にクリアする
                    if (i == HeaderRecordList1.Count - 1)
                    {
                        autoSCMRespondent.ClearSearchResult();
                    }
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        LogWriter.LogWrite("自動回答処理正常終了");
                        status = (int)Result.Code.Normal;
                    }
                    else
                    {
                        LogWriter.LogWrite("自動回答処理でエラーが発生しました。");
                        status = (int)Result.Code.Error;
                    }
                }

                return status;
                //------------------ADD 2024/07/03 陳艶丹 BLP障害対応（例外発生箇所修正対応）----------------<<<<<

                #region 2024/07/03 陳艶丹 DEL BLP障害対応（例外発生箇所修正対応）
                //------------------DEL 2024/07/03 陳艶丹 BLP障害対応（例外発生箇所修正対応）---------------->>>>>
                //SCMRespondent autoSCMRespondent = AutoFacade.CreateSCMRespondent(
                //    // --- UPD 2012/08/24 三戸 2012/12/12配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //    //AutoFacade.RunningMode.Auto,
                //    runningMode,
                //    // --- UPD 2012/08/24 三戸 2012/12/12配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                //    autoReplyHeaderRecordList,
                //    autoReplyCarRecordList,
                //    autoReplyDetailRecordList
                //    // 2010/03/31 Add >>>
                //    , orgAnswerRecordList
                //    , orgDetailRecordList
                //    // 2010/03/31 Add <<<
                //    );

                //// --- ADD 2012/11/21 三戸 2012/12/12配信分 システムテスト障害№59 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //if (runningMode == AutoFacade.RunningMode.Manual)
                //{
                //    autoSCMRespondent.ClearSearchResult();
                //    return (int)Result.Code.Normal;
                //}
                //// --- ADD 2012/11/21 三戸 2012/12/12配信分 システムテスト障害№59 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                //// 2011.07.12 ZHANGYH ADD STA >>>>>>
                //List<string> sendEnterpriseCodeList;
                //List<string> sendSectionCodeList;
                //// 2011.07.12 ZHANGYH ADD END <<<<<<

                //// 2011.07.12 ZHANGYH EDT STA >>>>>>
                //// int status = autoSCMRespondent.Reply();
                //int status = autoSCMRespondent.Reply(out sendEnterpriseCodeList, out sendSectionCodeList);
                //// 2011.07.12 ZHANGYH EDT END <<<<<<

                //// --- ADD m.suzuki 2012/04/18 ---------->>>>>
                //autoSCMRespondent.ClearSearchResult();
                //// --- ADD m.suzuki 2012/04/18 ----------<<<<<

                //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                //{
                //    #region 2012/04/24 TERASAKA DEL STA
                //    //                    // 2011.07.12 ZHANGYH ADD STA >>>>>>
                //    //                    // 回答成功すると、SF.NS端末を通知します。
                //    //                    if (sendEnterpriseCodeList != null && sendSectionCodeList != null && sendEnterpriseCodeList.Count > 0 && sendSectionCodeList.Count > 0)
                //    //                    {
                //    //                        // 2011.09.06 zhouzy UPDATE STA >>>>>>
                //    //                        ISCMOrderHeaderRecord iSCMOrderHeaderRecord = autoReplyHeaderRecordList[0];
                //    //
                //    //                        //NotifyOtherSide(sendEnterpriseCodeList, sendSectionCodeList);
                //    //                        NotifyOtherSide(sendEnterpriseCodeList, sendSectionCodeList, iSCMOrderHeaderRecord.AcceptOrOrderKind);
                //    //                        // 2011.09.06 zhouzy UPDATE END <<<<<<
                //    //                    }
                //    //                    // 2011.07.12 ZHANGYH ADD END <<<<<<
                //    #endregion
                //    LogWriter.LogWrite("自動回答処理正常終了");
                //    return (int)Result.Code.Normal;
                //}
                //else
                //{
                //    LogWriter.LogWrite("自動回答処理でエラーが発生しました。");
                //    return (int)Result.Code.Error;
                //}
                //------------------DEL 2024/07/03 陳艶丹 BLP障害対応（例外発生箇所修正対応）----------------<<<<<
                #endregion
            }
            catch (Exception e)
            {
                LogWriter.LogWrite("自動回答処理でエラーが発生しました。");
                LogWriter.LogWrite(e.Message);
                return (int)Result.Code.Error;
            }
        }
        #endregion

        #region CSVファイル出力処理
        /// <summary>
        /// 旧システム連携CSVファイルを出力します。
        /// </summary>
        /// <returns>結果コード</returns>
        /// <see cref="ISCMTerminal"/>
        private int OutputCSVFileForLegacySystem(Dictionary<string, string> legacySectionList,
                                 List<ISCMOrderHeaderRecord> csvOutputHeaderRecordList,
                                 List<ISCMOrderDetailRecord> csvOutputDetailRecordList,
                                 List<ISCMOrderCarRecord> csvOutputCarRecordList)
        {
            LogWriter.LogWrite("CSV出力処理開始");

            int status = (int)Result.Code.Normal;

            // 2010/12/27 Add >>>
            List<string> targetSectionList = new List<string>();

            // 旧システム連携の対象データリストから、拠点リストを生成する
            foreach (ISCMOrderHeaderRecord iSCMOrderHeaderRecord in csvOutputHeaderRecordList)
            {
                if (!targetSectionList.Contains(iSCMOrderHeaderRecord.InqOtherSecCd.Trim()))
                    targetSectionList.Add(iSCMOrderHeaderRecord.InqOtherSecCd.Trim());
            }
            // 2010/12/27 Add <<<

            // 2010/12/27 >>>
            //// 拠点毎にファイルを作成
            //foreach(string sectionCd in legacySectionList.Keys)

            // 拠点毎にファイルを作成（実際のデータに含まれる拠点単位で作成する）
            foreach (string sectionCd in targetSectionList)
            // 2010/12/27 <<<
            {
                // 2010/12/27 Add >>>
                string outputFolder = string.Empty;
                if (legacySectionList.ContainsKey(sectionCd))
                {
                    outputFolder = legacySectionList[sectionCd];
                }
                else if (legacySectionList.ContainsKey("00"))
                {
                    outputFolder = legacySectionList["00"];
                }
                else
                {
                    LogWriter.LogWrite(string.Format("拠点{0}の連携フォルダを取得できない為、CSV出力出来ません", sectionCd));
                    continue;
                }
                // 2010/12/27 Add <<<

                // 1拠点のヘッダリスト作成
                List<ISCMOrderHeaderRecord> oneSectionHeaderRecordList
                    = csvOutputHeaderRecordList.FindAll(delegate(ISCMOrderHeaderRecord iSCMOrderHeaderRecord)
                    {
                        if (iSCMOrderHeaderRecord.InqOtherSecCd.Trim() == sectionCd.Trim())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                // 1拠点の明細(問合せ・発注)リスト作成
                List<ISCMOrderDetailRecord> oneSectionDetailRecordList
                    = csvOutputDetailRecordList.FindAll(delegate(ISCMOrderDetailRecord iSCMOrderDetailRecord)
                    {
                        if (iSCMOrderDetailRecord.InqOtherSecCd.Trim() == sectionCd.Trim())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                // 車両情報には問合せ先企業、拠点がないため、ヘッダの同キーで抽出
                List<ISCMOrderCarRecord> oneSectionCarRecordList = new List<ISCMOrderCarRecord>();
                foreach (ISCMOrderHeaderRecord header in oneSectionHeaderRecordList)
                {
                    ISCMOrderCarRecord oneISCMOrderCarRecord = csvOutputCarRecordList.Find(delegate(ISCMOrderCarRecord iSCMOrderCarRecord)
                        {
                            if (iSCMOrderCarRecord.InqOriginalEpCd.Trim() == header.InqOriginalEpCd.Trim()
                                && iSCMOrderCarRecord.InqOriginalSecCd.Trim() == header.InqOriginalSecCd.Trim()
                                && iSCMOrderCarRecord.InquiryNumber == header.InquiryNumber
                                && iSCMOrderCarRecord.AcptAnOdrStatus == header.AcptAnOdrStatus
                                && iSCMOrderCarRecord.SalesSlipNum == header.SalesSlipNum)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        );

                    if (oneISCMOrderCarRecord != null)
                    {
                        oneSectionCarRecordList.Add(oneISCMOrderCarRecord);
                    }
                }

                // 各テーブルごとの出力文字列リスト作成
                List<List<string>> headerList = new List<List<string>>();
                List<List<string>> detailList = new List<List<string>>();
                List<List<string>> carList = new List<List<string>>();

                foreach (ISCMOrderHeaderRecord header in oneSectionHeaderRecordList)
                {
                    headerList.Add(this.GetHeaderCSVStr(header));
                }
                foreach (ISCMOrderDetailRecord detail in oneSectionDetailRecordList)
                {
                    detailList.Add(this.GetDetailCSVStr(detail));
                }
                foreach (ISCMOrderCarRecord car in oneSectionCarRecordList)
                {
                    carList.Add(this.GetCarCSVStr(car));
                }

                if (oneSectionHeaderRecordList.Count != 0)
                {

                    // 旧システム連携CSVファイルの出力処理
                    // 2010/12/27 >>>
                    //status = CSVWriter.CSVWrite(this._enterpriseCd, legacySectionList[sectionCd],
                    //    headerList, detailList, carList);

                    status = CSVWriter.CSVWrite(this._enterpriseCd, outputFolder, headerList, detailList, carList);
                    // 2010/12/27 <<<
                }

                if (status != (int)Result.Code.Normal)
                {
                    LogWriter.LogWrite(string.Format("拠点{0}のCSVファイル出力処理でエラーが発生しました", sectionCd));
                }
            }

            LogWriter.LogWrite("CSV出力処理終了");
            return (int)Result.Code.Normal;
        }

        #region CSV出力1行データ作成
        /// <summary>
        /// SCM受注データの1行CSV出力行作成
        /// </summary>
        /// <param name="header"></param>
        private List<string> GetHeaderCSVStr(ISCMOrderHeaderRecord header)
        {
            List<string> str = new List<string>();

            // 受注データ情報
            UserSCMOrderHeaderWrapper userHeader = (UserSCMOrderHeaderWrapper)header;

            str.Add(userHeader.InqOriginalEpCd.Trim()); // 問合せ元企業コード	//@@@@20230303
            str.Add(userHeader.InqOriginalSecCd); // 問合せ元拠点コード
            str.Add(userHeader.InqOtherEpCd); // 問合せ先企業コード
            str.Add(userHeader.InqOtherSecCd); // 問合せ先拠点コード
            str.Add(Convert.ToString(userHeader.InquiryNumber)); // 問合せ番号
            str.Add(Convert.ToString(userHeader.CustomerCode)); // 得意先コード
            str.Add(userHeader.UpdateDate.ToString("yyyyMMdd")); // 更新年月日
            str.Add(Convert.ToString(userHeader.UpdateTime)); // 更新時分秒ミリ秒
            // 2011/02/18 >>>
            //str.Add(Convert.ToString(userHeader.AnswerDivCd)); // 回答区分
            // 回答区分は、キャンセル時：99、それ以外は未回答
            str.Add(Convert.ToString((userHeader.CancelDiv == 1) ? (int)AnswerDivCd.Cancel : (int)AnswerDivCd.NoAction)); // 回答区分
            // 2011/02/18 <<<
            str.Add(userHeader.JudgementDate.ToString("yyyyMMdd")); // 確定日
            str.Add(userHeader.InqOrdNote); // 問合せ・発注備考
            str.Add(userHeader.InqEmployeeCd); // 問合せ従業員コード
            str.Add(userHeader.InqEmployeeNm); // 問合せ従業員名称
            str.Add(userHeader.AnsEmployeeCd); // 回答従業員コード
            str.Add(userHeader.AnsEmployeeNm); // 回答従業員名称
            str.Add(userHeader.InquiryDate.ToString("yyyyMMdd")); // 問合せ日
            str.Add(Convert.ToString(userHeader.AcptAnOdrStatus)); // 受注ステータス
            str.Add(userHeader.SalesSlipNum); // 売上伝票番号
            str.Add(Convert.ToString(userHeader.SalesTotalTaxInc)); // 売上伝票合計（税込み）
            str.Add(Convert.ToString(userHeader.SalesSubtotalTax)); // 売上小計（税）
            str.Add(Convert.ToString(userHeader.InqOrdDivCd)); // 問合せ・発注種別
            str.Add(Convert.ToString(userHeader.InqOrdAnsDivCd)); // 問発・回答種別
            str.Add(Convert.ToString(userHeader.ReceiveDateTime.Ticks)); // 受信日時
            str.Add(Convert.ToString(userHeader.AnswerCreateDiv)); // 回答作成区分

            // ADD 2010/06/15 修正呼出し時は、グリッドの値の変更は不可 ---------->>>>>
            // SCM受注データおよびSCM受注明細データ(問合せ・発注)のレイアウト変更
            str.Add(Convert.ToString(userHeader.CancelDiv));    // キャンセル区分
            str.Add(Convert.ToString(userHeader.CMTCooprtDiv)); // CMT連携区分
            // ADD 2010/06/15 修正呼出し時は、グリッドの値の変更は不可 ----------<<<<<
            // --- ADD 2013/07/22 Y.Wakita ---------->>>>>
            str.Add(Convert.ToString(userHeader.SfPmCprtInstSlipNo));   // SF-PM連携指示書番号
            // --- ADD 2013/07/22 Y.Wakita ----------<<<<<
            // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
            str.Add(Convert.ToString(userHeader.TabUseDiv)); // タブレット使用区分
            // --- ADD 2013/06/24 Y.Wakita ----------<<<<<
            // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
            str.Add(userHeader.CarMngCode); // 車両管理コード
            // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<
            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            str.Add(Convert.ToString(userHeader.AutoAnsMthd)); // 自動回答方式
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

            return str;
        }

        /// <summary>
        /// SCM受注明細データの1行CSV出力行作成
        /// </summary>
        private List<string> GetDetailCSVStr(ISCMOrderDetailRecord detail)
        {
            List<string> str = new List<string>();

            // 受注データ情報
            UserSCMOrderDetailWrapper userdetail = (UserSCMOrderDetailWrapper)detail;

            str.Add(userdetail.InqOriginalEpCd.Trim()); // 問合せ元企業コード	//@@@@20230303
            str.Add(userdetail.InqOriginalSecCd); // 問合せ元拠点コード
            str.Add(userdetail.InqOtherEpCd); // 問合せ先企業コード
            str.Add(userdetail.InqOtherSecCd); // 問合せ先拠点コード
            str.Add(Convert.ToString(userdetail.InquiryNumber)); // 問合せ番号
            str.Add(userdetail.UpdateDate.ToString("yyyyMMdd")); // 更新年月日
            str.Add(Convert.ToString(userdetail.UpdateTime)); // 更新時分秒ミリ秒
            str.Add(Convert.ToString(userdetail.InqRowNumber)); // 問合せ行番号
            str.Add(Convert.ToString(userdetail.InqRowNumDerivedNo)); // 問合せ行番号枝番
            str.Add(userdetail.InqOrgDtlDiscGuid.ToString()); // 問合せ元明細識別GUID
            str.Add(userdetail.InqOthDtlDiscGuid.ToString()); // 問合せ先明細識別GUID
            str.Add(Convert.ToString(userdetail.GoodsDivCd)); // 商品種別
            str.Add(Convert.ToString(userdetail.RecyclePrtKindCode)); // リサイクル部品種別
            str.Add(userdetail.RecyclePrtKindName); // リサイクル部品種別名称
            str.Add(Convert.ToString(userdetail.DeliveredGoodsDiv)); // 納品区分
            str.Add(Convert.ToString(userdetail.HandleDivCode)); // 取扱区分
            str.Add(Convert.ToString(userdetail.GoodsShape)); // 商品形態
            str.Add(Convert.ToString(userdetail.DelivrdGdsConfCd)); // 納品確認区分
            str.Add(Convert.ToString(userdetail.DeliGdsCmpltDueDate)); // 納品完了予定日
            str.Add(userdetail.AnswerDeliveryDate); // 回答納期
            str.Add(Convert.ToString(userdetail.BLGoodsCode)); // BL商品コード
            str.Add(Convert.ToString(userdetail.BLGoodsDrCode)); // BL商品コード枝番
            //str.Add(userdetail.GoodsName); // 商品名
            str.Add(userdetail.InqGoodsName); // 問発商品名
            str.Add(userdetail.AnsGoodsName); // 回答商品名
            str.Add(Convert.ToString(userdetail.SalesOrderCount)); // 発注数
            str.Add(Convert.ToString(userdetail.DeliveredGoodsCount)); // 納品数
            str.Add(userdetail.GoodsNo); // 商品番号
            str.Add(Convert.ToString(userdetail.GoodsMakerCd)); // 商品メーカーコード
            str.Add(userdetail.GoodsMakerNm); // 商品メーカー名称
            str.Add(Convert.ToString(userdetail.PureGoodsMakerCd)); // 純正商品メーカーコード
            //str.Add(userdetail.PureGoodsNo); // 純正商品番号
            str.Add(userdetail.InqPureGoodsNo); // 問発純正商品番号
            str.Add(userdetail.AnsPureGoodsNo); // 回答純正商品番号
            str.Add(Convert.ToString(userdetail.ListPrice)); // 定価
            str.Add(Convert.ToString(userdetail.UnitPrice)); // 単価
            str.Add(userdetail.GoodsAddInfo); // 商品補足情報
            str.Add(Convert.ToString(userdetail.RoughRrofit)); // 粗利額
            str.Add(Convert.ToString(userdetail.RoughRate)); // 粗利率
            str.Add(userdetail.AnswerLimitDate.ToString("yyyyMMdd")); // 回答期限
            str.Add(userdetail.CommentDtl); // 備考(明細)
            str.Add(userdetail.ShelfNo); // 棚番
            str.Add(Convert.ToString(userdetail.AdditionalDivCd)); // 追加区分
            str.Add(Convert.ToString(userdetail.CorrectDivCD)); // 訂正区分
            str.Add(Convert.ToString(userdetail.InqOrdDivCd)); // 問合せ・発注種別
            str.Add(Convert.ToString(userdetail.DisplayOrder)); // 表示順位

            // ADD 2010/06/15 修正呼出し時は、グリッドの値の変更は不可 ---------->>>>>
            // SCM受注データおよびSCM受注明細データ(問合せ・発注)のレイアウト変更
            str.Add(Convert.ToString(userdetail.CancelCndtinDiv));  // キャンセル状態区分
            str.Add(Convert.ToString(userdetail.AcptAnOdrStatus));  // 受注ステータス
            str.Add(userdetail.SalesSlipNum);                       // 売上伝票番号
            str.Add(Convert.ToString(userdetail.SalesRowNo));       // 売上行番号
            // ADD 2010/06/15 修正呼出し時は、グリッドの値の変更は不可 ----------<<<<<

            return str;
        }

        /// <summary>
        /// SCM受注データ(車両情報)の1行CSV出力行作成
        /// </summary>
        private List<string> GetCarCSVStr(ISCMOrderCarRecord car)
        {
            List<string> str = new List<string>();

            // 受注データ情報
            UserSCMOrderCarWrapper userCar = (UserSCMOrderCarWrapper)car;

            str.Add(userCar.InqOriginalEpCd.Trim()); // 問合せ元企業コード	//@@@@20230303
            str.Add(userCar.InqOriginalSecCd); // 問合せ元拠点コード
            str.Add(Convert.ToString(userCar.InquiryNumber)); // 問合せ番号
            str.Add(Convert.ToString(userCar.NumberPlate1Code)); // 陸運事務所番号
            str.Add(userCar.NumberPlate1Name); // 陸運事務局名称
            str.Add(userCar.NumberPlate2); // 車両登録番号（種別）
            str.Add(userCar.NumberPlate3); // 車両登録番号（カナ）
            str.Add(Convert.ToString(userCar.NumberPlate4)); // 車両登録番号（プレート番号）
            str.Add(Convert.ToString(userCar.ModelDesignationNo)); // 型式指定番号
            str.Add(Convert.ToString(userCar.CategoryNo)); // 類別番号
            str.Add(Convert.ToString(userCar.MakerCode)); // メーカーコード
            str.Add(Convert.ToString(userCar.ModelCode)); // 車種コード
            str.Add(Convert.ToString(userCar.ModelSubCode)); // 車種サブコード
            str.Add(userCar.ModelName); // 車種名
            str.Add(userCar.CarInspectCertModel); // 車検証型式
            str.Add(userCar.FullModel); // 型式（フル型）
            str.Add(userCar.FrameNo); // 車台番号
            str.Add(userCar.FrameModel); // 車台型式
            str.Add(userCar.ChassisNo); // シャシーNo
            str.Add(Convert.ToString(userCar.CarProperNo)); // 車両固有番号
            str.Add(Convert.ToString(userCar.ProduceTypeOfYearNum)); // 生産年式（NUMタイプ）
            str.Add(userCar.Comment); // コメント
            str.Add(userCar.RpColorCode); // リペアカラーコード
            str.Add(userCar.ColorName1); // カラー名称1
            str.Add(userCar.TrimCode); // トリムコード
            str.Add(userCar.TrimName); // トリム名称
            str.Add(Convert.ToString(userCar.Mileage)); // 車両走行距離
            str.Add(Convert.ToString(userCar.AcptAnOdrStatus)); // 受注ステータス
            str.Add(userCar.SalesSlipNum); // 売上伝票番号
            // --- ADD 2013/04/19 三戸 2013/05/22配信分 SCM障害№10521 --------->>>>>>>>>>>>>>>>>>>>>>>>
            str.Add(Convert.ToString(userCar.CarMngCode)); // 車両管理コード
            // --- ADD 2013/04/19 三戸 2013/05/22配信分 SCM障害№10521 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            str.Add(Convert.ToString(userCar.ExpectedCeDate)); // 入庫予定日
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

            return str;
        }
        #endregion
        #endregion

        #region 受発注データ⇒受注データ詰替え

        /// <summary>
        /// SCM受発注データからSCM受注データへの詰替え処理
        /// </summary>
        // 2011/02/18 >>>
        //private bool ConvertToUserSCMOrderHeaderRecord(List<ScmOdrData> scmOdrDataList, out List<ISCMOrderHeaderRecord> userSCMOrderHeaderRecordList)
        private bool ConvertToUserSCMOrderHeaderRecord(List<ScmOdrData> scmOdrDataList, out List<ISCMOrderHeaderRecord> userSCMOrderHeaderRecordList, out List<string> newDataKeyList)
        // 2011/02/18 <<<
        {
            userSCMOrderHeaderRecordList = new List<ISCMOrderHeaderRecord>();
            // 2011/02/18 Add >>>
            newDataKeyList = new List<string>();
            // 2011/02/18 Add <<<

            foreach (ScmOdrData scmOdrData in scmOdrDataList)
            {
                WebSCMOrderHeaderRecord webSCMOrderHeaderRecord = new WebSCMOrderHeaderRecord(scmOdrData);

                UserSCMOrderHeaderRecord userSCMOrderHeaderRecord = new UserSCMOrderHeaderRecord(webSCMOrderHeaderRecord);

                // 受発注データにないデータの設定
                CustomerSearchRet ret = this.GetCustomerSearchRet(userSCMOrderHeaderRecord.InqOtherEpCd, userSCMOrderHeaderRecord.InqOriginalEpCd.Trim(), userSCMOrderHeaderRecord.InqOriginalSecCd);//@@@@20230303


                if (ret != null)
                {
                    // 得意先コード
                    userSCMOrderHeaderRecord.CustomerCode = ret.CustomerCode;

                    // 回答従業員コード
                    userSCMOrderHeaderRecord.AnsEmployeeCd = ret.CustomerAgentCd;
					#region 2012.04.10 TERASAKA DEL STA
//                    userSCMOrderHeaderRecord.AnsEmployeeNm = this.GetEmployeeName(this._enterpriseCd, ret.CustomerAgentCd.Trim());
					#endregion
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
					userSCMOrderHeaderRecord.AnsEmployeeNm = ret.CustomerAgentNm;
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
                }
                else
                {
                    // 得意先が取得できない場合、エラーにして処理停止
                    // (イレギュラーケースかつ一部登録すると次回の処理で新着対象にならないため全停止)
                    LogWriter.LogWrite("問合せ元企業コード" + scmOdrData.InqOriginalEpCd
                                    + ",問合せ元拠点コード" + scmOdrData.InqOriginalSecCd
                                    + "に該当する得意先マスタの登録がありません。");
                    return false;
                }

                // 企業コード
                userSCMOrderHeaderRecord.EnterpriseCode = this._enterpriseCd;

                // 売上伝票番号(初期値)
                userSCMOrderHeaderRecord.SalesSlipNum = CT_DefaultSalesSlipNum;
                // 受注ステータス(未設定)
                userSCMOrderHeaderRecord.AcptAnOdrStatus = (int)DivisionValues.AcptAnOdrStatus.NoSet;
                // 売上伝票合計（税込み）
                userSCMOrderHeaderRecord.SalesTotalTaxInc = 0;
                // 売上小計（税）
                userSCMOrderHeaderRecord.SalesSubtotalTax = 0;
                // 回答作成区分 手動(Web)
                userSCMOrderHeaderRecord.AnswerCreateDiv = (int)DivisionValues.AnswerCreateDiv.ManualWeb;

                // 更新日時はRで設定
                userSCMOrderHeaderRecord.UpdateDateTime = DateTime.MinValue;

                userSCMOrderHeaderRecordList.Add(userSCMOrderHeaderRecord);

                // 2011/02/18 Add >>>
                if (scmOdrData.LatestDiscCode == (int)DivisionValues.LatestDiscCode.New) newDataKeyList.Add(SCMOdrDataUtil.SCMOdrDataToKey(scmOdrData));
                // 2011/02/18 Add <<<
            }

            return true;
        }

        /// <summary>
        /// SCM受発注明細データ(問合せ・発注)からSCM受注明細データ(問合せ・発注)への詰替え処理
        /// </summary>
        private void ConvertToUserSCMOrderDetailRecord(List<ScmOdDtInq> scmOdDtInqList, out List<ISCMOrderDetailRecord> userSCMOrderDetailRecordList)
        {
            userSCMOrderDetailRecordList = new List<ISCMOrderDetailRecord>();

            foreach (ScmOdDtInq scmOdDtInq in scmOdDtInqList)
            {
                // 2011/02/18 Add >>>
                // 問合せ明細は最新となっているデータのみ対象
                if (scmOdDtInq.LatestDiscCode == (int)DivisionValues.LatestDiscCode.Old) continue;
                // 2011/02/18 Add <<<

                WebSCMOrderDetailRecord webSCMOrderDetailRecord = new WebSCMOrderDetailRecord(scmOdDtInq);

                UserSCMOrderDetailRecord userSCMOrderDetailRecord = new UserSCMOrderDetailRecord(webSCMOrderDetailRecord);

                // メーカー名称(メーカマスタより取得)
                userSCMOrderDetailRecord.GoodsMakerNm = this.GetMakerName(userSCMOrderDetailRecord.InqOtherEpCd, userSCMOrderDetailRecord.GoodsMakerCd);

                // 更新日時はRで設定
                userSCMOrderDetailRecord.UpdateDateTime = DateTime.MinValue;

                userSCMOrderDetailRecordList.Add(userSCMOrderDetailRecord);
            }
        }

        /// <summary>
        /// SCM受発注明細データ(回答)からSCM受注明細データ(回答)への詰替え処理
        /// </summary>
        private void ConvertToUserSCMOrderAnswerRecord(List<ScmOdDtAns> scmOdDtAnsList, out List<ISCMOrderAnswerRecord> userSCMOrderAnswerRecordList)
        {
            userSCMOrderAnswerRecordList = new List<ISCMOrderAnswerRecord>();

            foreach (ScmOdDtAns scmOdDtAns in scmOdDtAnsList)
            {
                WebSCMOrderAnswerRecord webSCMOrderAnswerRecord = new WebSCMOrderAnswerRecord(scmOdDtAns);

                UserSCMOrderAnswerRecord userSCMOrderAnswerRecord = new UserSCMOrderAnswerRecord(webSCMOrderAnswerRecord);

                // 受発注データにないデータの設定
                // 企業コード
                userSCMOrderAnswerRecord.EnterpriseCode = this._enterpriseCd;

                // 売上伝票番号(初期値)
                userSCMOrderAnswerRecord.SalesSlipNum = CT_DefaultSalesSlipNum;
                // 受注ステータス(未設定)
                userSCMOrderAnswerRecord.AcptAnOdrStatus = (int)DivisionValues.AcptAnOdrStatus.NoSet;
                // メーカー名称(メーカマスタより取得)
                userSCMOrderAnswerRecord.GoodsMakerNm = this.GetMakerName(userSCMOrderAnswerRecord.InqOtherEpCd, userSCMOrderAnswerRecord.GoodsMakerCd);

                // 更新日時はRで設定
                userSCMOrderAnswerRecord.UpdateDateTime = DateTime.MinValue;

                userSCMOrderAnswerRecordList.Add(userSCMOrderAnswerRecord);
            }
        }

        /// <summary>
        /// SCM受発注データ(車両情報)からSCM受注データ(車両情報)への詰替え処理
        /// </summary>
        private void ConvertToUserSCMOrderCarRecord(List<ScmOdDtCar> scmOdDtCarList, out List<ISCMOrderCarRecord> userSCMOrderCarRecordList)
        {
            userSCMOrderCarRecordList = new List<ISCMOrderCarRecord>();

            foreach (ScmOdDtCar scmOdDtCar in scmOdDtCarList)
            {
                WebSCMOrderCarRecord webSCMOrderCarRecord = new WebSCMOrderCarRecord(scmOdDtCar);

                UserSCMOrderCarRecord userSCMOrderCarRecord = new UserSCMOrderCarRecord(webSCMOrderCarRecord);

                // 受発注データにないデータの設定
                // 企業コード
                userSCMOrderCarRecord.EnterpriseCode = this._enterpriseCd;

                // 売上伝票番号(初期値)
                userSCMOrderCarRecord.SalesSlipNum = CT_DefaultSalesSlipNum;
                // 受注ステータス(未設定)
                userSCMOrderCarRecord.AcptAnOdrStatus = (int)DivisionValues.AcptAnOdrStatus.NoSet;

                // byte配列項目の補正
                if (userSCMOrderCarRecord.EquipObj == null)
                {
                    userSCMOrderCarRecord.EquipObj = new byte[0];
                }

                // 更新日時はRで設定
                userSCMOrderCarRecord.UpdateDateTime = DateTime.MinValue;

                userSCMOrderCarRecordList.Add(userSCMOrderCarRecord);
            }
        }

        // 2010/03/31 Add >>>
        /// <summary>
        /// SCM受発注明細データ(回答)からSCM受注明細データ(回答)への詰替え処理
        /// </summary>
        private void ConvertToUserSCMOrderAnswerRecord(List<SCMAcOdrDtlAs> scmOdDtAnsList, out List<ISCMOrderAnswerRecord> userSCMOrderAnswerRecordList)
        {
            userSCMOrderAnswerRecordList = new List<ISCMOrderAnswerRecord>();

            foreach (SCMAcOdrDtlAs scmOdDtAns in scmOdDtAnsList)
            {
                UserSCMOrderAnswerRecord userSCMOrderAnswerRecord = new UserSCMOrderAnswerRecord(scmOdDtAns);
                userSCMOrderAnswerRecordList.Add(userSCMOrderAnswerRecord);
            }
        }

        /// <summary>
        /// SCM受発注明細データ(問合せ・発注)からSCM受注明細データ(問合せ・発注)への詰替え処理
        /// </summary>
        private void ConvertToUserSCMOrderDetailRecord(List<SCMAcOdrDtlIq> scmOdDtInqList, out List<ISCMOrderDetailRecord> userSCMOrderDetailRecordList)
        {
            userSCMOrderDetailRecordList = new List<ISCMOrderDetailRecord>();

            foreach (SCMAcOdrDtlIq scmOdDtInq in scmOdDtInqList)
            {
                UserSCMOrderDetailRecord userSCMOrderDetailRecord = new UserSCMOrderDetailRecord(scmOdDtInq);

                userSCMOrderDetailRecordList.Add(userSCMOrderDetailRecord);
            }
        }

        /// <summary>
        /// 回答と明細の全データを取得します。（ヘッダに存在するデータの分に振り分ける）
        /// </summary>
        /// <param name="header"></param>
        /// <param name="detail"></param>
        /// <param name="oldDetail"></param>
        /// <param name="oldAnswer"></param>
        /// <param name="targetAllDtl"></param>
        /// <param name="targetAllAnswer"></param>
        private void GetOrgAnswerAndDetail(
            List<ISCMOrderHeaderRecord> headerList,
            List<ISCMOrderDetailRecord> detailList,
            List<ISCMOrderDetailRecord> oldDetailList,
            List<ISCMOrderAnswerRecord> oldAnswerList,
            out List<ISCMOrderDetailRecord> targetAllDtlList,
            out List<ISCMOrderAnswerRecord> targetAllAnswerList
            )
        {
            targetAllDtlList = new List<ISCMOrderDetailRecord>();
            targetAllDtlList.AddRange(detailList);
            targetAllAnswerList = new List<ISCMOrderAnswerRecord>();

            foreach (ISCMOrderHeaderRecord header in headerList)
            {
                if (oldAnswerList != null)
                {
                    targetAllAnswerList.AddRange(
                        oldAnswerList.FindAll(
                            delegate(ISCMOrderAnswerRecord target)
                            {
                                // 問合せ元企業コード違い
                                if (!target.InqOriginalEpCd.Trim().Equals(header.InqOriginalEpCd.Trim())) return false;
                                // 問合せ元拠点違い
                                if (!target.InqOriginalSecCd.Trim().Equals(header.InqOriginalSecCd.Trim())) return false;
                                // 問合せ先企業コード違い
                                if (!target.InqOtherEpCd.Trim().Equals(header.InqOtherEpCd.Trim())) return false;
                                // 問合せ先拠点違い
                                if (!target.InqOtherSecCd.Trim().Equals(header.InqOtherSecCd.Trim())) return false;
                                // 問合せ番号違い
                                if (!target.InquiryNumber.Equals(header.InquiryNumber)) return false;
                                // 2011/02/18 Del >>>
                                //// 問合せ・発注種別違い
                                //if (!target.InqOrdDivCd.Equals(header.InqOrdDivCd)) return false;
                                // 2011/02/18 Del <<<

                                return true;
                            }));
                }
                if (oldDetailList != null)
                {
                    targetAllDtlList.AddRange(
                        oldDetailList.FindAll(
                            delegate(ISCMOrderDetailRecord target)
                            {
                                // 問合せ元企業コード違い
                                if (!target.InqOriginalEpCd.Trim().Equals(header.InqOriginalEpCd.Trim())) return false;
                                // 問合せ元拠点違い
                                if (!target.InqOriginalSecCd.Trim().Equals(header.InqOriginalSecCd.Trim())) return false;
                                // 問合せ先企業コード違い
                                if (!target.InqOtherEpCd.Trim().Equals(header.InqOtherEpCd.Trim())) return false;
                                // 問合せ先拠点違い
                                if (!target.InqOtherSecCd.Trim().Equals(header.InqOtherSecCd.Trim())) return false;
                                // 問合せ番号違い
                                if (!target.InquiryNumber.Equals(header.InquiryNumber)) return false;
                                // 2011/02/18 >>>
                                //// 問合せ・発注種別違い
                                //if (!target.InqOrdDivCd.Equals(header.InqOrdDivCd)) return false;
                                // 2011/02/18 <<<

                                return true;
                            }
                        ));
                }
            }
        }
        // 2010/03/31 Add <<<
        #endregion

        #region 得意先マスタ情報取得
        /// <summary>
        ///得意先マスタ情報取得
        /// </summary>
        private CustomerSearchRet GetCustomerSearchRet(string enterpriseCd, string cusEnterpriseCd, string cusSectionCd)
        {
            if (this._customerSearchRetList == null)
            {
                // 得意先情報の取得
                CustomerSearchPara customerSearchPara = new CustomerSearchPara();

                customerSearchPara.EnterpriseCode = enterpriseCd;

                CustomerSearchRet[] retList;
                int status = this._customerSearchAcs.Serch(out retList, customerSearchPara);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._customerSearchRetList = new List<CustomerSearchRet>();

                    this._customerSearchRetList.AddRange(retList);
                }
                else
                {
                    return null;
                }
            }

            CustomerSearchRet ret = this._customerSearchRetList.Find(
                    delegate(CustomerSearchRet searchRet)
                    {
                        // 2011/03/18 >>>
                        //if (searchRet.CustomerEpCode.Trim() == cusEnterpriseCd.Trim()
                        //    && searchRet.CustomerSecCode.Trim() == cusSectionCd.Trim())
                        if (searchRet.CustomerEpCode.Trim() == cusEnterpriseCd.Trim()
                            && searchRet.CustomerSecCode.Trim() == cusSectionCd.Trim()
                            && searchRet.OnlineKindDiv == 10
                           )
                        // 2011/03/18 <<<
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

            return ret;
        }
        #endregion

        #region 名称取得
        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <returns></returns>
        private string GetMakerName(string enterPriseCode, int makerCode)
        {
			#region 2012.04.10 TERASAKA DEL STA
//            MakerUMnt makerUMnt;
//
//            int status = this._makerAcs.Read(out makerUMnt, enterPriseCode, makerCode);
//
//            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//            {
//                return makerUMnt.MakerName;
//            }
//            else
//            {
//                return string.Empty;
//            }
			#endregion
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
			while (!_isGetMakerUMnt) System.Threading.Thread.Sleep(100);

            // 2015/06/05 ADD TAKAGAWA SCM課題一覧No35 ---------->>>>>>>>>>
            // SearchMakerNameメソッド（スレッド処理）でエラーが発生していたら、その情報をthrowしてポップアップに処理を戻す
            if (_searchMakerNameThreadException != null)
            {
                throw _searchMakerNameThreadException;
            }
            // 2015/06/05 ADD TAKAGAWA SCM課題一覧No35 ----------<<<<<<<<<<

			MakerUMnt makerUMnt;
			if (_makerUMntList.Count > 0)
			{
				makerUMnt = _makerUMntList.Find(
					delegate(MakerUMnt wkObj)
					{
						if (wkObj.EnterpriseCode == enterPriseCode &&
							wkObj.GoodsMakerCd == makerCode)
							return true;
						else
							return false;
					}
				);
			}
			else
			{
				this._makerAcs.Read(out makerUMnt, enterPriseCode, makerCode);
			}

			if (makerUMnt != null)
				return makerUMnt.MakerName;
			else
				return string.Empty;
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
        }

////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //

        // 2015/06/05 ADD TAKAGAWA SCM課題一覧No35 ---------->>>>>>>>>>
        // エラー判定フラグ
        private Exception _searchMakerNameThreadException = null;
        // 2015/06/05 ADD TAKAGAWA SCM課題一覧No35 ----------<<<<<<<<<<

		private void SearchMakerName(object sender)
		{

            // 2015/06/05 ADD TAKAGAWA SCM課題一覧No35 ---------->>>>>>>>>>
            //フラグ情報クリア
            _searchMakerNameThreadException = null;
            // 2015/06/05 ADD TAKAGAWA SCM課題一覧No35 ----------<<<<<<<<<<

			string enterpriseCode = sender.ToString();
			try
			{
				ArrayList retList;
				int status = this._makerAcs.SearchAll(out retList, enterpriseCode);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					_makerUMntList = new List<MakerUMnt>((MakerUMnt[])retList.ToArray(typeof(MakerUMnt)));
				}
			}

            // 2015/06/05 ADD TAKAGAWA SCM課題一覧No35 ---------->>>>>>>>>>
            catch (Exception e)
            {
                // フラグ情報保持
                _searchMakerNameThreadException = e;

                // ログ出力
                string ErrMsg = "■例外エラーが発生しました■" + Environment.NewLine;
                ErrMsg += e.Message + Environment.NewLine;
                ErrMsg += e.StackTrace;

                LogWriter.LogWrite(ErrMsg);

                // 2015/09/16 ADD TAKAGAWA システムテスト障害No.156対応 ---------->>>>>>>>>>
                string exMessage = e.Message;
                if (!string.IsNullOrEmpty(exMessage) && exMessage.IndexOf("バージョンが異なります") != -1)
                {
                    throw;
                }
                // 2015/09/16 ADD TAKAGAWA システムテスト障害No.156対応 ----------<<<<<<<<<<

            }
            // 2015/06/05 ADD TAKAGAWA SCM課題一覧No35 ----------<<<<<<<<<<

			finally
			{
				_isGetMakerUMnt = true;
			}
		}
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

        /// <summary>
        /// 従業員名称取得
        /// </summary>
        /// <param name="enterPriseCode"></param>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        private string GetEmployeeName(string enterPriseCode, string employeeCode)
        {
            Employee employee;

            int status = this._employeeAcs.Read(out employee, enterPriseCode, employeeCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return employee.Name;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region  XML読込処理
        // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 -------------------->>>>>
        /// <summary>
        ///  SCM取得基準日の値設定読込処理
        /// </summary>
        /// <returns> SCM取得基準日の値設定</returns>
        /// <remarks>
        /// <br>Note		: SCM取得基準日の値設定情報を読み込みます。</br>
        /// <br>Programmer	: 陳艶丹</br>
        /// <br>Date		: 2016/09/18</br>
        /// </remarks>
        private ScmPeriodSet ReadScmPeriodSet()
        {
            ScmPeriodSet info = null;

            if (UserSettingController.ExistUserSetting(System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, PERIOD_UISETTING)))
            {
                try
                {
                    // XMLから抽出条件アイテムクラス配列にデシリアライズする
                    info = UserSettingController.DeserializeUserSetting<ScmPeriodSet>(System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, PERIOD_UISETTING));
                }
                catch (InvalidOperationException)
                {
                    if (info == null)
                    {
                        info = new ScmPeriodSet(10);
                    }
                }
            }
            else
            {
                info = new ScmPeriodSet(10);
            }

            // xmlにキーが存在しない場合
            if (info.ReceivePeriod == 0)
            {
                info = new ScmPeriodSet(10);
            }

            return info;
        }
        // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 --------------------<<<<<
        #endregion

        #endregion

        #region <testデータ>

        //private readonly Int64 testInquiryNumber = 1000000041;
        //private readonly DateTime testUpdateDate = DateTime.Now;
        //private readonly Int32 testUpdateTime = 0;

        ///// <summary>
        ///// テスト用受発注データ作成
        ///// </summary>
        ///// <returns></returns>
        //private List<ScmOdrData> CreateScmOdrDataForTest()
        //{
        //    List<ScmOdrData> testDataList = new List<ScmOdrData>();

        //    ScmOdrData testData1 = new ScmOdrData();

        //    testData1.InqOriginalEpCd = "0140150842030050";//問合せ元企業コード
        //    testData1.InqOriginalSecCd = "000001";//問合せ元拠点コード
        //    testData1.InqOtherEpCd = this._enterpriseCd;//問合せ先企業コード
        //    testData1.InqOtherSecCd = "01";//問合せ先拠点コード
        //    testData1.InquiryNumber = testInquiryNumber;//問合せ番号
        //    testData1.UpdateDate = testUpdateDate;//更新年月日
        //    testData1.UpdateTime = testUpdateTime;//更新時分秒ミリ秒
        //    testData1.AnswerDivCd = 0;//回答区分
        //    testData1.JudgementDate = DateTime.Now;//確定日
        //    testData1.InqOrdNote = "1";//問合せ・発注備考
        //    testData1.InqEmployeeCd = "0001";//問合せ従業員コード
        //    testData1.InqEmployeeNm = "1";//問合せ従業員名称
        //    testData1.AnsEmployeeCd = "0001";//回答従業員コード
        //    testData1.AnsEmployeeNm = "1";//回答従業員名称
        //    testData1.InquiryDate = DateTime.Now;//問合せ日
        //    testData1.ReceiveDateTime = DateTime.Now;//問合せ日
        //    testData1.InqOrdDivCd = 1; // 問合せ・発注種別 1:問合せ
        //    testData1.InqOrdAnsDivCd = 1;
        //    testData1.ReceiveDateTime = DateTime.MinValue;

        //    testDataList.Add(testData1);


        //    return testDataList;
        //}

        ///// <summary>
        ///// テスト用受発注明細データ(問合せ・発注)作成
        ///// </summary>
        ///// <returns></returns>
        //private List<ScmOdDtInq> CreateScmOdDtInqForTest()
        //{
        //    List<ScmOdDtInq> testDataList = new List<ScmOdDtInq>();

        //    ScmOdDtInq testData1 = new ScmOdDtInq();

        //    testData1.InqOriginalEpCd = "0140150842030050";//問合せ元企業コード
        //    testData1.InqOriginalSecCd = "000001";//問合せ元拠点コード
        //    testData1.InqOtherEpCd = this._enterpriseCd;//問合せ先企業コード
        //    testData1.InqOtherSecCd = "01";//問合せ先拠点コード
        //    testData1.InquiryNumber = testInquiryNumber;//問合せ番号
        //    testData1.UpdateDate = testUpdateDate;//更新年月日 
        //    testData1.UpdateTime = testUpdateTime;//更新時分秒ミリ秒

        //    testData1.InqRowNumber = 1; // 問合せ行番号
        //    testData1.InqRowNumDerivedNo = 1; // 問合せ行番号枝番
        //    testData1.InqOrgDtlDiscGuid = new Guid("61459ebb-9db0-4722-9195-68ccf6f048ad"); // 問合せ元明細識別GUID
        //    testData1.InqOthDtlDiscGuid = new Guid("61459ebb-9db0-4722-9195-68ccf6f048ad"); // 問合せ先明細識別GUID
        //    testData1.GoodsDivCd = 0; // 商品種別 0:純正 1:優良 2:リビルド 3:中古 4:平均相場
        //    testData1.RecyclePrtKindCode = 1; // リサイクル部品種別 1リビルド
        //    testData1.RecyclePrtKindName = "リビルド";
        //    testData1.DeliveredGoodsDiv = 0; // 納品区分 0:配送 1:引取
        //    testData1.HandleDivCode = 0; // 取扱区分 0:取扱品 1:納期確認中 2:未取扱品
        //    testData1.GoodsShape = 1; // 商品形態 1:部品 2:用品
        //    testData1.DelivrdGdsConfCd = 0; // 納品確認区分 0:未確認 1:確認
        //    testData1.DeliGdsCmpltDueDate = DateTime.Now.AddMonths(3); // 納品完了予定日
        //    testData1.BLGoodsCode = 0001; // BL商品コード
        //    testData1.BLGoodsDrCode = 1; // BL商品コード枝番
        //    testData1.InqGoodsName = "1"; // 問発商品名
        //    testData1.AnsGoodsName = "1"; // 回答商品名
        //    testData1.SalesOrderCount = 2; // 発注数
        //    testData1.DeliveredGoodsCount = 1; // 納品数
        //    testData1.GoodsNo = "TESTUENOret100"; // 商品番号
        //    testData1.GoodsMakerCd = 1; // 商品メーカーコード
        //    testData1.PureGoodsMakerCd = 1; // 純正商品メーカーコード
        //    testData1.InqPureGoodsNo = "TESTUENOpure100"; // 問発純正商品番号
        //    testData1.AnsPureGoodsNo = "TESTUENOpure100"; // 回答純正商品番号
        //    testData1.ListPrice = 100; // 定価
        //    testData1.UnitPrice = 100; // 単価
        //    testData1.GoodsAddInfo = "1"; // 商品補足情報
        //    testData1.RoughRrofit = 5; // 粗利額
        //    testData1.RoughRate = 5; // 粗利率
        //    testData1.AnswerLimitDate = DateTime.Now; // 回答期限
        //    testData1.CommentDtl = "1"; // 備考(明細)
        //    testData1.ShelfNo = ""; // 棚番
        //    testData1.AdditionalDivCd = 0; // 追加区分
        //    testData1.CorrectDivCD = 0; // 訂正区分
        //    testData1.InqOrdDivCd = 1;

        //    testDataList.Add(testData1);

        //    ScmOdDtInq testData2 = new ScmOdDtInq();

        //    testData2.InqOriginalEpCd = "0140150842030050";//問合せ元企業コード
        //    testData2.InqOriginalSecCd = "000001";//問合せ元拠点コード
        //    testData2.InqOtherEpCd = this._enterpriseCd;//問合せ先企業コード
        //    testData2.InqOtherSecCd = "01";//問合せ先拠点コード
        //    testData2.InquiryNumber = testInquiryNumber;//問合せ番号
        //    testData2.UpdateDate = testUpdateDate;//更新年月日 
        //    testData2.UpdateTime = testUpdateTime;//更新時分秒ミリ秒

        //    testData2.InqRowNumber = 2; // 問合せ行番号
        //    testData2.InqRowNumDerivedNo = 1; // 問合せ行番号枝番
        //    testData2.InqOrgDtlDiscGuid = new Guid("61459ebb-9db0-4722-9195-68ccf6f048ad"); // 問合せ元明細識別GUID
        //    testData2.InqOthDtlDiscGuid = new Guid("61459ebb-9db0-4722-9195-68ccf6f048ad"); // 問合せ先明細識別GUID
        //    testData2.GoodsDivCd = 0; // 商品種別 0:純正 1:優良 2:リビルド 3:中古 4:平均相場
        //    testData2.RecyclePrtKindCode = 1; // リサイクル部品種別 1リビルド
        //    testData2.RecyclePrtKindName = "リビルド";
        //    testData2.DeliveredGoodsDiv = 0; // 納品区分 0:配送 1:引取
        //    testData2.HandleDivCode = 0; // 取扱区分 0:取扱品 1:納期確認中 2:未取扱品
        //    testData2.GoodsShape = 1; // 商品形態 1:部品 2:用品
        //    testData2.DelivrdGdsConfCd = 0; // 納品確認区分 0:未確認 1:確認
        //    testData2.DeliGdsCmpltDueDate = DateTime.Now.AddMonths(3); // 納品完了予定日
        //    testData2.BLGoodsCode = 0001; // BL商品コード
        //    testData2.BLGoodsDrCode = 1; // BL商品コード枝番
        //    testData2.InqGoodsName = "1"; // 問発商品名
        //    testData2.AnsGoodsName = "1"; // 回答商品名
        //    testData2.SalesOrderCount = 2; // 発注数
        //    testData2.DeliveredGoodsCount = 1; // 納品数
        //    testData2.GoodsNo = "TESTUENOret100"; // 商品番号
        //    testData2.GoodsMakerCd = 1; // 商品メーカーコード
        //    testData2.PureGoodsMakerCd = 1; // 純正商品メーカーコード
        //    testData2.InqPureGoodsNo = "TESTUENOpure100"; // 問発純正商品番号
        //    testData2.AnsPureGoodsNo = "TESTUENOpure100"; // 回答純正商品番号
        //    testData2.ListPrice = 100; // 定価
        //    testData2.UnitPrice = 100; // 単価
        //    testData2.GoodsAddInfo = "1"; // 商品補足情報
        //    testData2.RoughRrofit = 5; // 粗利額
        //    testData2.RoughRate = 5; // 粗利率
        //    testData2.AnswerLimitDate = DateTime.Now; // 回答期限
        //    testData2.CommentDtl = "1"; // 備考(明細)
        //    testData2.ShelfNo = ""; // 棚番
        //    testData2.AdditionalDivCd = 0; // 追加区分
        //    testData2.CorrectDivCD = 0; // 訂正区分
        //    testData2.InqOrdDivCd = 1;

        //    testDataList.Add(testData2);

        //    return testDataList;
        //}

        ///// <summary>
        ///// テスト用受発注データ(車両情報)作成
        ///// </summary>
        ///// <returns></returns>
        //private List<ScmOdDtCar> CreateScmOdDtCarForTest()
        //{
        //    List<ScmOdDtCar> testDataList = new List<ScmOdDtCar>();

        //    ScmOdDtCar testData1 = new ScmOdDtCar();

        //    testData1.InqOriginalEpCd = "0140150842030050";//問合せ元企業コード
        //    testData1.InqOriginalSecCd = "000001";//問合せ元拠点コード
        //    testData1.InquiryNumber = testInquiryNumber;//問合せ番号

        //    testData1.NumberPlate1Code = 11; // 陸運事務所番号
        //    testData1.NumberPlate1Name = "1"; // 陸運事務局名称
        //    testData1.NumberPlate2 = "1"; // 車両登録番号(種別)
        //    testData1.NumberPlate3 = "1"; // 車両登録番号(カナ)
        //    testData1.NumberPlate4 = 1234; // 車両登録番号(プレート番号)
        //    testData1.ModelDesignationNo = 5; // 型式指定番号
        //    testData1.CategoryNo = 1; // 類別番号
        //    testData1.MakerCode = 1; // メーカーコード
        //    testData1.ModelCode = 1; // 車種コード
        //    testData1.ModelSubCode = 1; // 車種サブコード
        //    testData1.ModelName = "1"; // 車種名
        //    testData1.CarInspectCertModel = "1"; // 車検証型式
        //    testData1.FullModel = "1"; // 型式(フル型)
        //    testData1.FrameNo = "1"; // 車台番号
        //    testData1.FrameModel = "1"; // 車台型式
        //    testData1.ChassisNo = "1"; // シャシーNo
        //    testData1.CarProperNo = 1234; // 車両固有番号
        //    testData1.ProduceTypeOfYearNum = 201012; // 生産年式(Numタイプ)
        //    testData1.Comment = "1"; // コメント
        //    testData1.RpColorCode = "1"; // リペアカラーコード
        //    testData1.ColorName1 = "1"; // カラー名称1
        //    testData1.TrimCode = "1"; // トリムコード
        //    testData1.TrimName = "1"; // トリム名称
        //    testData1.Mileage = 999999; // 車両走行距離
        //    testData1.EquipObj = System.Text.Encoding.Unicode.GetBytes("1"); // 装備オブジェト

        //    testDataList.Add(testData1);


        //    return testDataList;
        //}
        #endregion
    }

    #region XML
    // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 -------------------->>>>>
    /// public class name:   ScmPeriodSet
    /// <summary>
    /// SCM取得基準日の値設定
    /// </summary>
    /// <remarks>
    /// <br>note             :  SCM取得基準日の値設定ファイル</br>
    /// <br>Programmer       :  陳艶丹</br>
    /// <br>Date             :  2016/09/18</br>
    /// </remarks>
    [Serializable]
    public class ScmPeriodSet
    {
        /// <summary>取得基準日の値設定</summary>
        private Int32 _receivePeriod;

        /// public propaty name  :  ReceivePeriod
        /// <summary>取得基準日の値設定プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取得基準日の値設定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReceivePeriod
        {
            get { return _receivePeriod; }
            set { _receivePeriod = value; }
        }

        /// <summary>
        /// SCM取得基準日の値設定コンストラクタ
        /// </summary>
        /// <returns>ScmPeriodSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :  ScmPeriodSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :  自動生成</br>
        /// </remarks>
        public ScmPeriodSet()
        {

        }

        /// <summary>
        /// SCM取得基準日の値設定コンストラクタ
        /// </summary>
        /// <returns>ScmPeriodSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :  ScmPeriodSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :  自動生成</br>
        /// </remarks>
        public ScmPeriodSet(int receivePeriod)
        {
            _receivePeriod = receivePeriod;
        }
    }
    // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 --------------------<<<<<
    #endregion
}
