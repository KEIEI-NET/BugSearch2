using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 支払伝票アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 支払伝票のテーブルへアクセスします。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2006.05.23</br>
	/// <br></br>
	/// <br>Update Note : 2006.12.22 木村 武正</br>
	/// <br>              携帯.NS用に赤伝のインターフェースを追加</br>
    /// <br>Update Note : 2010.04.27 gejun</br>
    /// <br>              M1007A-支払手形データ更新追加</br>
    /// <br>Update Note : 2011.07.30 qijh</br>
    /// <br>              SCM対応 - 拠点管理(10704767-00)
    /// <br>              送信済みのチェックメッセージを出力できるように改修</br>
    /// <br>Update Note : 2011/12/15 tianjw</br>
    /// <br>              Redmine#27390 拠点管理/売上日のチェック</br>
    /// <br>Update Note : 2013.02.21 脇田 靖之</br>
    /// <br>              支払伝票削除時、手形データ紐付け解除対応
    /// <br></br>
	/// </remarks>
	public class PaymentSlpAcs
	{
		#region PrivateMember
        
        // ADD 2011/07/30 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
        /// <summary>
        /// 送信済チェック失敗のステータス
        /// </summary>
        private const int STATUS_CHK_SEND_ERR = -1001;

        /// <summary>
        /// 送信済チェック失敗のエラーメッセージ
        /// </summary>
        private const string CHK_SEND_ERR_MSG = "送信済みのデータの為、更新できません。";
        // ADD 2011/07/30 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

		// エラーメッセージ
		private string _errorMessage;
		#endregion

		#region Interface
		// リモートインターフェース
		IPaymentSlpDB _iPaymentSlpDB;
		#endregion

		#region Property
		/// <summary>エラーメッセージ</summary>
		public string ErrorMessage
		{
			get { return _errorMessage; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PaymentSlpAcs()
		{
			try
			{
				// リモートオブジェクト取得
				_iPaymentSlpDB = (IPaymentSlpDB)MediationPaymentSlpDB.GetPaymentSlpDB();
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				_iPaymentSlpDB = null;
			}
		}
		#endregion

		#region PublicMethod
        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 支払伝票登録処理
        /// </summary>
        /// <param name="paymentSlp">支払伝票マスタ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票の登録・更新を行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        public int Write(ref PaymentSlp paymentSlp)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            _errorMessage = "";

            PaymentDataWork paymentDataWork = CopyToPaymentDataWorkFromPaymentSlp(paymentSlp);
            
            // XMLへ変換
            byte[] parabyte = XmlByteSerializer.Serialize(paymentDataWork);
           
            try
            {
                // 入金データ書き込み
                status = this._iPaymentSlpDB.Write(ref parabyte);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // XMLの読み込み
                            paymentDataWork = (PaymentDataWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentDataWork));
                            paymentSlp = CopyToPaymentSlpFromPaymentDataWork(paymentDataWork);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            _errorMessage = "支払伝票は他端末により既に更新、又は削除されています。";
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "支払伝票は他端末により既に削除されています。";
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT:
                        {
                            _errorMessage = "支払番号を別端末が採番しています。\r\nしばらくお待ちになって再度実行してください。";
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                    case STATUS_CHK_SEND_ERR:
                        {
                            _errorMessage = CHK_SEND_ERR_MSG;
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
                    default:
                        {
                            _errorMessage = "支払伝票の保存処理に失敗しました。";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "支払伝票の保存処理にて例外が発生しました。\r\n" + ex.Message;
                //オフライン時はnullをセット
                _iPaymentSlpDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }
        // --------------- ADD START 2010.04.27 gejun FOR M1007A-支払手形データ更新追加-------->>>>
        /// <summary>
        /// 支払伝票登録処理(支払手形データも連れる)
        /// </summary>
        /// <param name="paymentSlp">支払伝票マスタ</param>
        /// <param name="payDraftData">支払手形データ</param>
        /// <param name="payDraftDataDel">支払手形データ(削除用)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票の登録・更新・削除を行います。</br>
        /// <br>Programmer	: gejun</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        public int WriteWithPayDraft(ref PaymentSlp paymentSlp, PayDraftData payDraftData, PayDraftData payDraftDataDel)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            _errorMessage = "";

            PaymentDataWork paymentDataWork = CopyToPaymentDataWorkFromPaymentSlp(paymentSlp);
            PayDraftDataWork payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);
            PayDraftDataWork payDraftDataWorkDel =new PayDraftDataWork();
            if (payDraftDataDel != null)
                payDraftDataWorkDel = CopyToPayDraftDataWorkFromPayDraftData(payDraftDataDel);
            else
                payDraftDataWorkDel = null;

            // XMLへ変換
            byte[] parabyte = XmlByteSerializer.Serialize(paymentDataWork);
            byte[] parabyteUpd = XmlByteSerializer.Serialize(payDraftDataWork);
            byte[] parabyteDel;
            if(payDraftDataWorkDel != null)
                parabyteDel = XmlByteSerializer.Serialize(payDraftDataWorkDel);
            else
                parabyteDel = null;

            try
            {
                // 入金データ書き込み
                status = this._iPaymentSlpDB.WriteWithPayDraft(ref parabyte, parabyteUpd, parabyteDel);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // XMLの読み込み
                            paymentDataWork = (PaymentDataWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentDataWork));
                            paymentSlp = CopyToPaymentSlpFromPaymentDataWork(paymentDataWork);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            _errorMessage = "支払伝票は他端末により既に更新、又は削除されています。";
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "支払伝票は他端末により既に削除されています。";
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                    case STATUS_CHK_SEND_ERR:
                        {
                            _errorMessage = CHK_SEND_ERR_MSG;
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
                    case (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT:
                        {
                            _errorMessage = "支払番号を別端末が採番しています。\r\nしばらくお待ちになって再度実行してください。";
                            break;
                        }
                    default:
                        {
                            _errorMessage = "支払伝票の保存処理に失敗しました。";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "支払伝票の保存処理にて例外が発生しました。\r\n" + ex.Message;
                //オフライン時はnullをセット
                _iPaymentSlpDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }
        // --------------- ADD END 2010.04.27 gejun FOR M1007A-支払手形データ更新追加-------->>>>
        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        /// <summary>
        /// 支払伝票登録処理(支払・受取手形データも連れる)
        /// </summary>
        /// <param name="paymentSlp">支払伝票マスタ</param>
        /// <param name="payDraftData">支払手形データ</param>
        /// <param name="payDraftDataDel">支払手形データ(削除用)</param>
        /// <param name="rcvDraftData">受取手形データ</param>
        /// <param name="rcvDraftDataDel">受取手形データ(削除用)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票の登録・更新・削除を行います。</br>
        /// <br>Programmer	: 宮本</br>
        /// <br>Date		: 2012/10/18</br>
        /// </remarks>
        public int WriteWithDraft(ref PaymentSlp paymentSlp, PayDraftData payDraftData, PayDraftData payDraftDataDel
                                                           , RcvDraftData rcvDraftData, RcvDraftData rcvDraftDataDel)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            _errorMessage = "";

            PaymentDataWork paymentDataWork = CopyToPaymentDataWorkFromPaymentSlp(paymentSlp);
            PayDraftDataWork payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);
            PayDraftDataWork payDraftDataWorkDel = new PayDraftDataWork();
            if (payDraftDataDel != null)
                payDraftDataWorkDel = CopyToPayDraftDataWorkFromPayDraftData(payDraftDataDel);
            else
                payDraftDataWorkDel = null;

            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();
            RcvDraftDataWork rcvDraftDataWorkDel = new RcvDraftDataWork();
            if (rcvDraftData != null)
                rcvDraftDataWork = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftData);
            else
                rcvDraftDataWork = null;
            if (rcvDraftDataDel != null)
                rcvDraftDataWorkDel = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftDataDel);
            else
                rcvDraftDataWorkDel = null;

            // XMLへ変換
            byte[] parabyte = XmlByteSerializer.Serialize(paymentDataWork);
            byte[] parabytePayUpd = XmlByteSerializer.Serialize(payDraftDataWork);
            byte[] parabytePayDel;
            if (payDraftDataWorkDel != null)
                parabytePayDel = XmlByteSerializer.Serialize(payDraftDataWorkDel);
            else
                parabytePayDel = null;
            byte[] parabyteRcvUpd;
            if (rcvDraftDataWork != null)
                parabyteRcvUpd = XmlByteSerializer.Serialize(rcvDraftDataWork);
            else
                parabyteRcvUpd = null;
            byte[] parabyteRcvDel;
            if (rcvDraftDataWorkDel != null)
                parabyteRcvDel = XmlByteSerializer.Serialize(rcvDraftDataWorkDel);
            else
                parabyteRcvDel = null;

            try
            {
                // 支払データ書き込み
                status = this._iPaymentSlpDB.WriteWithDraft(ref parabyte, parabytePayUpd, parabytePayDel, parabyteRcvUpd, parabyteRcvDel);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // XMLの読み込み
                            paymentDataWork = (PaymentDataWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentDataWork));
                            paymentSlp = CopyToPaymentSlpFromPaymentDataWork(paymentDataWork);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            _errorMessage = "支払伝票は他端末により既に更新、又は削除されています。";
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "支払伝票は他端末により既に削除されています。";
                            break;
                        }
                    case STATUS_CHK_SEND_ERR:
                        {
                            _errorMessage = CHK_SEND_ERR_MSG;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT:
                        {
                            _errorMessage = "支払番号を別端末が採番しています。\r\nしばらくお待ちになって再度実行してください。";
                            break;
                        }
                    default:
                        {
                            _errorMessage = "支払伝票の保存処理に失敗しました。";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "支払伝票の保存処理にて例外が発生しました。\r\n" + ex.Message;
                //オフライン時はnullをセット
                _iPaymentSlpDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

        /// <summary>
        /// 支払伝票読込処理
        /// </summary>
        /// <param name="paymentSlp">支払伝票マスタ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="paymentSlipNo">支払伝票番号</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票の読込を行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        public int Read(out PaymentSlp paymentSlp, string enterpriseCode, int paymentSlipNo)
        {
            int status = 0;
            _errorMessage = "";
            paymentSlp = null;

            try
            {
                byte[] parabyte;
                status = _iPaymentSlpDB.Read(enterpriseCode, paymentSlipNo, out parabyte);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // XMLの読み込み
                            PaymentDataWork paymentDataWork = (PaymentDataWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentDataWork));
                            // クラス内メンバコピー
                            paymentSlp = CopyToPaymentSlpFromPaymentDataWork(paymentDataWork);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "指定支払伝票は存在しません。";
                            break;
                        }
                    default:
                        {
                            _errorMessage = "支払伝票の読込処理に失敗しました。";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "支払伝票の読込にて例外が発生しました。\r\n" + ex.Message;
                //オフライン時はnullをセット
                _iPaymentSlpDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 支払伝票削除処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="paymentSlipNo">支払伝票番号</param>
        /// <param name="payDraftData">支払手形情報</param>
        /// <param name="retPaymentDataWork">元相殺済み黒伝</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票の削除を行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
        //public int Delete(string enterpriseCode, int paymentSlipNo, out PaymentDataWork retPaymentDataWork)
        public int Delete(string enterpriseCode, int paymentSlipNo, PayDraftData payDraftData, out PaymentDataWork retPaymentDataWork)
        // --- UPD 2013/02/21 Y.Wakita ----------<<<<<
        {
            retPaymentDataWork = null;

            int status = 0;
            _errorMessage = "";

            try
            {
                // --- ADD 2013/02/21 Y.Wakita ---------->>>>>
                PayDraftDataWork payDraftDataWork = new PayDraftDataWork();
                byte[] parabytePayUpd;
                if (payDraftData != null)
                {
                    payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);
                    // XMLへ変換
                    parabytePayUpd = XmlByteSerializer.Serialize(payDraftDataWork);
                }
                else
                {
                    payDraftDataWork = null;
                    parabytePayUpd = null;
                }
                // --- ADD 2013/02/21 Y.Wakita ----------<<<<<
                byte[] PaymentDataWorkByte;

                // ADD 2009/05/01 コメント追記
                // 物理削除メソッドを使用しているが、リモート側で論理削除処理に変更している
                // 支払伝票削除
                // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
                //status = _iPaymentSlpDB.Delete(enterpriseCode, paymentSlipNo, out PaymentDataWorkByte);
                status = _iPaymentSlpDB.Delete(enterpriseCode, paymentSlipNo, parabytePayUpd, out PaymentDataWorkByte);
                // --- UPD 2013/02/21 Y.Wakita ----------<<<<<

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            if (PaymentDataWorkByte != null)
                            {
                                // 元相殺済み黒伝を返す。
                                retPaymentDataWork = (PaymentDataWork)XmlByteSerializer.Deserialize(PaymentDataWorkByte, typeof(PaymentDataWork));
                            }
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            _errorMessage = "支払伝票は他端末により既に更新、又は削除されています。";
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "支払伝票は他端末により既に削除されています。";
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                    case STATUS_CHK_SEND_ERR:
                        {
                            _errorMessage = CHK_SEND_ERR_MSG;
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
                    default:
                        {
                            _errorMessage = "支払伝票の削除処理に失敗しました。";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "支払伝票の削除処理にて例外が発生しました。\r\n" + ex.Message;
                //オフライン時はnullをセット
                _iPaymentSlpDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 支払伝票赤伝作成処理
        /// </summary>
        /// <param name="mode">赤伝作成モード 0:赤入金作成</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="updateSecCd">更新拠点コード</param>
        /// <param name="paymentAgentCode">支払担当者コード</param>
        /// <param name="paymentAgentNm">支払担当者名</param>
        /// <param name="addUpADate">計上日</param>
        /// <param name="paymentSlipNo">支払伝票番号(赤伝を行う黒伝)</param>
        /// <param name="retPaymentDataWorkList">支払伝票マスタ(更新結果)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した支払伝票番号の赤支払作成処理を行います</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/08</br>
        /// </remarks>
        public int RedCreate(int mode, string enterpriseCode, string updateSecCd, string paymentAgentCode, string paymentAgentNm, DateTime addUpADate, int paymentSlipNo, out ArrayList retPaymentDataWorkList)
        {
            int status = 0;
            _errorMessage = "";

            retPaymentDataWorkList = new ArrayList();
            retPaymentDataWorkList.Clear();

            try
            {
                object retObj;
                status = _iPaymentSlpDB.RedCreate(mode,
                                                  enterpriseCode,
                                                  updateSecCd,
                                                  paymentAgentCode,
                                                  paymentAgentNm,
                                                  addUpADate,
                                                  paymentSlipNo,
                                                  out retObj);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            ArrayList wkList = retObj as ArrayList;
                            if (wkList != null)
                            {
                                for (int i = 0; i != wkList.Count; i++)
                                {
                                    PaymentDataWork work = (PaymentDataWork)wkList[i];
                                    retPaymentDataWorkList.Add(work);
                                }
                            }
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            _errorMessage = "支払伝票は他端末により既に更新、又は削除されています。";
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                    case STATUS_CHK_SEND_ERR:
                        {
                            _errorMessage = CHK_SEND_ERR_MSG;
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "支払伝票は他端末により既に削除されています。";
                            break;
                        }
                    default:
                        {
                            _errorMessage = "支払伝票の赤伝処理に失敗しました。";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "支払伝票の赤伝処理にて例外が発生しました。\r\n" + ex.Message;
                //オフライン時はnullをセット
                _iPaymentSlpDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }


        // --------------- ADD START 2010.04.27 gejun FOR M1007A-支払手形データ更新追加-------->>>>
        /// <summary>
        /// クラスメンバーコピー処理（支払手形データマスタクラス⇒支払手形データマスタワーククラス）
        /// </summary>
        /// <param name="payDraftData">支払手形データマスタクラス</param>
        /// <returns>支払手形データマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 支払手形データマスタクラスから支払手形データマスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        private PayDraftDataWork CopyToPayDraftDataWorkFromPayDraftData(PayDraftData payDraftData)
        {
            PayDraftDataWork payDraftDataWork = new PayDraftDataWork();

            payDraftDataWork.CreateDateTime = payDraftData.CreateDateTime;
            payDraftDataWork.UpdateDateTime = payDraftData.UpdateDateTime;
            payDraftDataWork.EnterpriseCode = payDraftData.EnterpriseCode;
            payDraftDataWork.FileHeaderGuid = payDraftData.FileHeaderGuid;
            payDraftDataWork.UpdEmployeeCode = payDraftData.UpdEmployeeCode;
            payDraftDataWork.UpdAssemblyId1 = payDraftData.UpdAssemblyId1;
            payDraftDataWork.UpdAssemblyId2 = payDraftData.UpdAssemblyId2;
            payDraftDataWork.LogicalDeleteCode = payDraftData.LogicalDeleteCode;
            payDraftDataWork.PayDraftNo = payDraftData.PayDraftNo;
            payDraftDataWork.DraftKindCd = payDraftData.DraftKindCd;
            payDraftDataWork.DraftDivide = payDraftData.DraftDivide;
            payDraftDataWork.Payment = payDraftData.Payment;
            payDraftDataWork.BankAndBranchCd = payDraftData.BankAndBranchCd;
            payDraftDataWork.BankAndBranchNm = payDraftData.BankAndBranchNm;
            payDraftDataWork.SectionCode = payDraftData.SectionCode;
            payDraftDataWork.AddUpSecCode = payDraftData.AddUpSecCode;
            payDraftDataWork.SupplierCd = payDraftData.SupplierCd;
            payDraftDataWork.SupplierNm1 = payDraftData.SupplierNm1;
            payDraftDataWork.SupplierNm2 = payDraftData.SupplierNm2;
            payDraftDataWork.SupplierSnm = payDraftData.SupplierSnm;
            payDraftDataWork.ProcDate = payDraftData.ProcDate;
            payDraftDataWork.DraftDrawingDate = payDraftData.DraftDrawingDate;
            payDraftDataWork.ValidityTerm = payDraftData.ValidityTerm;
            payDraftDataWork.DraftStmntDate = payDraftData.DraftStmntDate;
            payDraftDataWork.Outline1 = payDraftData.Outline1;
            payDraftDataWork.Outline2 = payDraftData.Outline2;
            payDraftDataWork.SupplierFormal = payDraftData.SupplierFormal;
            payDraftDataWork.PaymentSlipNo = payDraftData.PaymentSlipNo;
            payDraftDataWork.PaymentRowNo = payDraftData.PaymentRowNo;
            payDraftDataWork.PaymentDate = payDraftData.PaymentDate;

            return payDraftDataWork;
        }
        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        /// <summary>
        /// クラスメンバーコピー処理（受取手形データマスタクラス⇒受取手形データマスタワーククラス）
        /// </summary>
        /// <param name="rcvDraftData">受取手形データマスタクラス</param>
        /// <returns>受取手形データマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 受取手形データマスタクラスから受取手形データマスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 宮本</br>
        /// <br>Date       : 2012/10/18</br>
        /// </remarks>
        private RcvDraftDataWork CopyToRcvDraftDataWorkFromRcvDraftData(RcvDraftData rcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();

            rcvDraftDataWork.CreateDateTime = rcvDraftData.CreateDateTime;
            rcvDraftDataWork.UpdateDateTime = rcvDraftData.UpdateDateTime;
            rcvDraftDataWork.EnterpriseCode = rcvDraftData.EnterpriseCode;
            rcvDraftDataWork.FileHeaderGuid = rcvDraftData.FileHeaderGuid;
            rcvDraftDataWork.UpdEmployeeCode = rcvDraftData.UpdEmployeeCode;
            rcvDraftDataWork.UpdAssemblyId1 = rcvDraftData.UpdAssemblyId1;
            rcvDraftDataWork.UpdAssemblyId2 = rcvDraftData.UpdAssemblyId2;
            rcvDraftDataWork.LogicalDeleteCode = rcvDraftData.LogicalDeleteCode;
            rcvDraftDataWork.RcvDraftNo = rcvDraftData.RcvDraftNo;
            rcvDraftDataWork.DraftKindCd = rcvDraftData.DraftKindCd;
            rcvDraftDataWork.DraftDivide = rcvDraftData.DraftDivide;
            rcvDraftDataWork.Deposit = rcvDraftData.Deposit;
            rcvDraftDataWork.BankAndBranchCd = rcvDraftData.BankAndBranchCd;
            rcvDraftDataWork.BankAndBranchNm = rcvDraftData.BankAndBranchNm;
            rcvDraftDataWork.SectionCode = rcvDraftData.SectionCode;
            rcvDraftDataWork.AddUpSecCode = rcvDraftData.AddUpSecCode;
            rcvDraftDataWork.CustomerCode = rcvDraftData.CustomerCode;
            rcvDraftDataWork.CustomerName = rcvDraftData.CustomerName;
            rcvDraftDataWork.CustomerName2 = rcvDraftData.CustomerName2;
            rcvDraftDataWork.CustomerSnm = rcvDraftData.CustomerSnm;
            rcvDraftDataWork.ProcDate = rcvDraftData.ProcDate;
            rcvDraftDataWork.DraftDrawingDate = rcvDraftData.DraftDrawingDate;
            rcvDraftDataWork.ValidityTerm = rcvDraftData.ValidityTerm;
            rcvDraftDataWork.DraftStmntDate = rcvDraftData.DraftStmntDate;
            rcvDraftDataWork.Outline1 = rcvDraftData.Outline1;
            rcvDraftDataWork.Outline2 = rcvDraftData.Outline2;
            rcvDraftDataWork.AcptAnOdrStatus = rcvDraftData.AcptAnOdrStatus;
            rcvDraftDataWork.DepositSlipNo = rcvDraftData.DepositSlipNo;
            rcvDraftDataWork.DepositRowNo = rcvDraftData.DepositRowNo;
            rcvDraftDataWork.DepositDate = rcvDraftData.DepositDate;
            
            return rcvDraftDataWork;
        }
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

        // --------------- ADD END 2010.04.27 gejun FOR M1007A-支払手形データ更新追加-------->>>>
        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="paymentSlp">支払伝票クラス</param>
        /// <returns>支払伝票ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/08</br>
        /// <br>Update Note: 2011/12/15 tianjw</br>
        /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
        /// </remarks>
        private PaymentDataWork CopyToPaymentDataWorkFromPaymentSlp(PaymentSlp paymentSlp)
        {
            PaymentDataWork paymentDataWork = new PaymentDataWork();

            paymentDataWork.CreateDateTime = paymentSlp.CreateDateTime;              // 作成日付
            paymentDataWork.UpdateDateTime = paymentSlp.UpdateDateTime;              // 更新日付
            paymentDataWork.EnterpriseCode = paymentSlp.EnterpriseCode;              // 企業コード
            paymentDataWork.FileHeaderGuid = paymentSlp.FileHeaderGuid;              // GUID
            paymentDataWork.UpdEmployeeCode = paymentSlp.UpdEmployeeCode;            // 更新従業員コード
            paymentDataWork.UpdAssemblyId1 = paymentSlp.UpdAssemblyId1;              // 更新アセンブリID1
            paymentDataWork.UpdAssemblyId2 = paymentSlp.UpdAssemblyId2;              // 更新アセンブリID2
            paymentDataWork.LogicalDeleteCode = paymentSlp.LogicalDeleteCode;        // 論理削除区分
            paymentDataWork.DebitNoteDiv = paymentSlp.DebitNoteDiv;                  // 赤伝区分
            paymentDataWork.PaymentSlipNo = paymentSlp.PaymentSlipNo;                // 支払伝票番号
            paymentDataWork.SupplierCd = paymentSlp.SupplierCd;                      // 仕入先コード
            paymentDataWork.SupplierNm1 = paymentSlp.SupplierNm1;                    // 仕入先名1
            paymentDataWork.SupplierNm2 = paymentSlp.SupplierNm2;                    // 仕入先名2
            paymentDataWork.SupplierSnm = paymentSlp.SupplierSnm;                    // 仕入先略称
            paymentDataWork.PayeeCode = paymentSlp.PayeeCode;                        // 支払先コード
            paymentDataWork.PayeeName = paymentSlp.PayeeName;                        // 支払先名称
            paymentDataWork.PayeeName2 = paymentSlp.PayeeName2;                      // 支払先名称2
            paymentDataWork.PayeeSnm = paymentSlp.PayeeSnm;                          // 支払先略称
            paymentDataWork.PaymentInpSectionCd = paymentSlp.PaymentInpSectionCd;    // 支払入力拠点コード
            paymentDataWork.SubSectionCode = paymentSlp.SubSectionCode;
            paymentDataWork.AddUpSecCode = paymentSlp.AddUpSecCode;                  // 計上拠点コード
            paymentDataWork.UpdateSecCd = paymentSlp.UpdateSecCd;                    // 更新拠点コード
            paymentDataWork.PaymentDate = paymentSlp.PaymentDate;                    // 支払日付
            paymentDataWork.PrePaymentDate = paymentSlp.PrePaymentDate;              // 前回支払日付 // ADD 2011/12/15
            paymentDataWork.AddUpADate = paymentSlp.AddUpADate;                      // 計上日付
            paymentDataWork.PaymentTotal = paymentSlp.PaymentTotal;                  // 支払計
            paymentDataWork.Payment = paymentSlp.Payment;                            // 支払金額
            paymentDataWork.FeePayment = paymentSlp.FeePayment;                      // 手数料支払額
            paymentDataWork.DiscountPayment = paymentSlp.DiscountPayment;            // 値引支払額
            paymentDataWork.AutoPayment = paymentSlp.AutoPayment;                    // 自動支払区分
            paymentDataWork.DraftDrawingDate = paymentSlp.DraftDrawingDate;          // 手形振出日
            paymentDataWork.DebitNoteLinkPayNo = paymentSlp.DebitNoteLinkPayNo;      // 赤黒支払連結番号
            paymentDataWork.PaymentAgentCode = paymentSlp.PaymentAgentCode;          // 支払担当者コード
            paymentDataWork.PaymentAgentName = paymentSlp.PaymentAgentName;          // 支払担当者名称
            paymentDataWork.PaymentInputAgentCd = paymentSlp.PaymentInputAgentCd;
            paymentDataWork.PaymentInputAgentNm = paymentSlp.PaymentInputAgentNm;
            paymentDataWork.Outline = paymentSlp.Outline;                            // 伝票摘要
            paymentDataWork.DraftKind = paymentSlp.DraftKind;                        // 手形種類
            paymentDataWork.DraftKindName = paymentSlp.DraftKindName;                // 手形種類名称
            paymentDataWork.DraftDivide = paymentSlp.DraftDivide;                    // 手形区分
            paymentDataWork.DraftDivideName = paymentSlp.DraftDivideName;            // 手形区分名称
            paymentDataWork.DraftNo = paymentSlp.DraftNo;                            // 手形番号
            paymentDataWork.BankCode = paymentSlp.BankCode;                          // 銀行コード
            paymentDataWork.BankName = paymentSlp.BankName;                          // 銀行名称
            paymentDataWork.PaymentRowNo1 = paymentSlp.PaymentRowNoDtl[0];
            paymentDataWork.PaymentRowNo2 = paymentSlp.PaymentRowNoDtl[1];
            paymentDataWork.PaymentRowNo3 = paymentSlp.PaymentRowNoDtl[2];
            paymentDataWork.PaymentRowNo4 = paymentSlp.PaymentRowNoDtl[3];
            paymentDataWork.PaymentRowNo5 = paymentSlp.PaymentRowNoDtl[4];
            paymentDataWork.PaymentRowNo6 = paymentSlp.PaymentRowNoDtl[5];
            paymentDataWork.PaymentRowNo7 = paymentSlp.PaymentRowNoDtl[6];
            paymentDataWork.PaymentRowNo8 = paymentSlp.PaymentRowNoDtl[7];
            paymentDataWork.PaymentRowNo9 = paymentSlp.PaymentRowNoDtl[8];
            paymentDataWork.PaymentRowNo10 = paymentSlp.PaymentRowNoDtl[9];
            paymentDataWork.MoneyKindCode1 = paymentSlp.MoneyKindCodeDtl[0];
            paymentDataWork.MoneyKindCode2 = paymentSlp.MoneyKindCodeDtl[1];
            paymentDataWork.MoneyKindCode3 = paymentSlp.MoneyKindCodeDtl[2];
            paymentDataWork.MoneyKindCode4 = paymentSlp.MoneyKindCodeDtl[3];
            paymentDataWork.MoneyKindCode5 = paymentSlp.MoneyKindCodeDtl[4];
            paymentDataWork.MoneyKindCode6 = paymentSlp.MoneyKindCodeDtl[5];
            paymentDataWork.MoneyKindCode7 = paymentSlp.MoneyKindCodeDtl[6];
            paymentDataWork.MoneyKindCode8 = paymentSlp.MoneyKindCodeDtl[7];
            paymentDataWork.MoneyKindCode9 = paymentSlp.MoneyKindCodeDtl[8];
            paymentDataWork.MoneyKindCode10 = paymentSlp.MoneyKindCodeDtl[9];
            paymentDataWork.MoneyKindName1 = paymentSlp.MoneyKindNameDtl[0];
            paymentDataWork.MoneyKindName2 = paymentSlp.MoneyKindNameDtl[1];
            paymentDataWork.MoneyKindName3 = paymentSlp.MoneyKindNameDtl[2];
            paymentDataWork.MoneyKindName4 = paymentSlp.MoneyKindNameDtl[3];
            paymentDataWork.MoneyKindName5 = paymentSlp.MoneyKindNameDtl[4];
            paymentDataWork.MoneyKindName6 = paymentSlp.MoneyKindNameDtl[5];
            paymentDataWork.MoneyKindName7 = paymentSlp.MoneyKindNameDtl[6];
            paymentDataWork.MoneyKindName8 = paymentSlp.MoneyKindNameDtl[7];
            paymentDataWork.MoneyKindName9 = paymentSlp.MoneyKindNameDtl[8];
            paymentDataWork.MoneyKindName10 = paymentSlp.MoneyKindNameDtl[9];
            paymentDataWork.MoneyKindDiv1 = paymentSlp.MoneyKindDivDtl[0];
            paymentDataWork.MoneyKindDiv2 = paymentSlp.MoneyKindDivDtl[1];
            paymentDataWork.MoneyKindDiv3 = paymentSlp.MoneyKindDivDtl[2];
            paymentDataWork.MoneyKindDiv4 = paymentSlp.MoneyKindDivDtl[3];
            paymentDataWork.MoneyKindDiv5 = paymentSlp.MoneyKindDivDtl[4];
            paymentDataWork.MoneyKindDiv6 = paymentSlp.MoneyKindDivDtl[5];
            paymentDataWork.MoneyKindDiv7 = paymentSlp.MoneyKindDivDtl[6];
            paymentDataWork.MoneyKindDiv8 = paymentSlp.MoneyKindDivDtl[7];
            paymentDataWork.MoneyKindDiv9 = paymentSlp.MoneyKindDivDtl[8];
            paymentDataWork.MoneyKindDiv10 = paymentSlp.MoneyKindDivDtl[9];
            paymentDataWork.Payment1 = paymentSlp.PaymentDtl[0];
            paymentDataWork.Payment2 = paymentSlp.PaymentDtl[1];
            paymentDataWork.Payment3 = paymentSlp.PaymentDtl[2];
            paymentDataWork.Payment4 = paymentSlp.PaymentDtl[3];
            paymentDataWork.Payment5 = paymentSlp.PaymentDtl[4];
            paymentDataWork.Payment6 = paymentSlp.PaymentDtl[5];
            paymentDataWork.Payment7 = paymentSlp.PaymentDtl[6];
            paymentDataWork.Payment8 = paymentSlp.PaymentDtl[7];
            paymentDataWork.Payment9 = paymentSlp.PaymentDtl[8];
            paymentDataWork.Payment10 = paymentSlp.PaymentDtl[9];
            paymentDataWork.ValidityTerm1 = paymentSlp.ValidityTermDtl[0];
            paymentDataWork.ValidityTerm2 = paymentSlp.ValidityTermDtl[1];
            paymentDataWork.ValidityTerm3 = paymentSlp.ValidityTermDtl[2];
            paymentDataWork.ValidityTerm4 = paymentSlp.ValidityTermDtl[3];
            paymentDataWork.ValidityTerm5 = paymentSlp.ValidityTermDtl[4];
            paymentDataWork.ValidityTerm6 = paymentSlp.ValidityTermDtl[5];
            paymentDataWork.ValidityTerm7 = paymentSlp.ValidityTermDtl[6];
            paymentDataWork.ValidityTerm8 = paymentSlp.ValidityTermDtl[7];
            paymentDataWork.ValidityTerm9 = paymentSlp.ValidityTermDtl[8];
            paymentDataWork.ValidityTerm10 = paymentSlp.ValidityTermDtl[9];
            paymentDataWork.InputDay = paymentSlp.InputDay;

            return paymentDataWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="paymentDataWork">支払伝票ワーククラス</param>
        /// <returns>支払伝票クラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/08</br>
        /// </remarks>
        private PaymentSlp CopyToPaymentSlpFromPaymentDataWork(PaymentDataWork paymentDataWork)
        {
            PaymentSlp paymentSlp = new PaymentSlp();

            paymentSlp.CreateDateTime = paymentDataWork.CreateDateTime;              // 作成日付
            paymentSlp.UpdateDateTime = paymentDataWork.UpdateDateTime;              // 更新日付
            paymentSlp.EnterpriseCode = paymentDataWork.EnterpriseCode;              // 企業コード
            paymentSlp.FileHeaderGuid = paymentDataWork.FileHeaderGuid;              // GUID
            paymentSlp.UpdEmployeeCode = paymentDataWork.UpdEmployeeCode;            // 更新従業員コード
            paymentSlp.UpdAssemblyId1 = paymentDataWork.UpdAssemblyId1;              // 更新アセンブリID1
            paymentSlp.UpdAssemblyId2 = paymentDataWork.UpdAssemblyId2;              // 更新アセンブリID2
            paymentSlp.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;        // 論理削除区分
            paymentSlp.DebitNoteDiv = paymentDataWork.DebitNoteDiv;                  // 赤伝区分
            paymentSlp.PaymentSlipNo = paymentDataWork.PaymentSlipNo;                // 支払伝票番号
            paymentSlp.SupplierCd = paymentDataWork.SupplierCd;                      // 仕入先コード
            paymentSlp.SupplierNm1 = paymentDataWork.SupplierNm1;                    // 仕入先名1
            paymentSlp.SupplierNm2 = paymentDataWork.SupplierNm2;                    // 仕入先名2
            paymentSlp.SupplierSnm = paymentDataWork.SupplierSnm;                    // 仕入先略称
            paymentSlp.PayeeCode = paymentDataWork.PayeeCode;                        // 支払先コード
            paymentSlp.PayeeName = paymentDataWork.PayeeName;                        // 支払先名称
            paymentSlp.PayeeName2 = paymentDataWork.PayeeName2;                      // 支払先名称2
            paymentSlp.PayeeSnm = paymentDataWork.PayeeSnm;                          // 支払先略称
            paymentSlp.PaymentInpSectionCd = paymentDataWork.PaymentInpSectionCd;    // 支払入力拠点コード
            paymentSlp.AddUpSecCode = paymentDataWork.AddUpSecCode;                  // 計上拠点コード
            paymentSlp.UpdateSecCd = paymentDataWork.UpdateSecCd;                    // 更新拠点コード
            paymentSlp.PaymentDate = paymentDataWork.PaymentDate;                    // 支払日付
            paymentSlp.AddUpADate = paymentDataWork.AddUpADate;                      // 計上日付
            paymentSlp.PaymentTotal = paymentDataWork.PaymentTotal;                  // 支払計
            paymentSlp.Payment = paymentDataWork.Payment;                            // 支払金額
            paymentSlp.FeePayment = paymentDataWork.FeePayment;                      // 手数料支払額
            paymentSlp.DiscountPayment = paymentDataWork.DiscountPayment;            // 値引支払額
            paymentSlp.AutoPayment = paymentDataWork.AutoPayment;                    // 自動支払区分
            paymentSlp.DraftDrawingDate = paymentDataWork.DraftDrawingDate;          // 手形振出日
            paymentSlp.DebitNoteLinkPayNo = paymentDataWork.DebitNoteLinkPayNo;      // 赤黒支払連結番号
            paymentSlp.PaymentAgentCode = paymentDataWork.PaymentAgentCode;          // 支払担当者コード
            paymentSlp.PaymentAgentName = paymentDataWork.PaymentAgentName;          // 支払担当者名称
            paymentSlp.PaymentInputAgentCd = paymentDataWork.PaymentInputAgentCd;
            paymentSlp.PaymentInputAgentNm = paymentDataWork.PaymentInputAgentNm;
            paymentSlp.Outline = paymentDataWork.Outline;                            // 伝票摘要
            paymentSlp.DraftKind = paymentDataWork.DraftKind;                        // 手形種類
            paymentSlp.DraftKindName = paymentDataWork.DraftKindName;                // 手形種類名称
            paymentSlp.DraftDivide = paymentDataWork.DraftDivide;                    // 手形区分
            paymentSlp.DraftDivideName = paymentDataWork.DraftDivideName;            // 手形区分名称
            paymentSlp.DraftNo = paymentDataWork.DraftNo;                            // 手形番号
            paymentSlp.BankCode = paymentDataWork.BankCode;                          // 銀行コード
            paymentSlp.BankName = paymentDataWork.BankName;                          // 銀行名称
            paymentSlp.PaymentRowNoDtl = new int[10];
            paymentSlp.PaymentRowNoDtl[0] = paymentDataWork.PaymentRowNo1;
            paymentSlp.PaymentRowNoDtl[1] = paymentDataWork.PaymentRowNo2;
            paymentSlp.PaymentRowNoDtl[2] = paymentDataWork.PaymentRowNo3;
            paymentSlp.PaymentRowNoDtl[3] = paymentDataWork.PaymentRowNo4;
            paymentSlp.PaymentRowNoDtl[4] = paymentDataWork.PaymentRowNo5;
            paymentSlp.PaymentRowNoDtl[5] = paymentDataWork.PaymentRowNo6;
            paymentSlp.PaymentRowNoDtl[6] = paymentDataWork.PaymentRowNo7;
            paymentSlp.PaymentRowNoDtl[7] = paymentDataWork.PaymentRowNo8;
            paymentSlp.PaymentRowNoDtl[8] = paymentDataWork.PaymentRowNo9;
            paymentSlp.PaymentRowNoDtl[9] = paymentDataWork.PaymentRowNo10;
            paymentSlp.MoneyKindCodeDtl = new int[10];
            paymentSlp.MoneyKindCodeDtl[0] = paymentDataWork.MoneyKindCode1;
            paymentSlp.MoneyKindCodeDtl[1] = paymentDataWork.MoneyKindCode2;
            paymentSlp.MoneyKindCodeDtl[2] = paymentDataWork.MoneyKindCode3;
            paymentSlp.MoneyKindCodeDtl[3] = paymentDataWork.MoneyKindCode4;
            paymentSlp.MoneyKindCodeDtl[4] = paymentDataWork.MoneyKindCode5;
            paymentSlp.MoneyKindCodeDtl[5] = paymentDataWork.MoneyKindCode6;
            paymentSlp.MoneyKindCodeDtl[6] = paymentDataWork.MoneyKindCode7;
            paymentSlp.MoneyKindCodeDtl[7] = paymentDataWork.MoneyKindCode8;
            paymentSlp.MoneyKindCodeDtl[8] = paymentDataWork.MoneyKindCode9;
            paymentSlp.MoneyKindCodeDtl[9] = paymentDataWork.MoneyKindCode10;
            paymentSlp.MoneyKindNameDtl = new string[10];
            paymentSlp.MoneyKindNameDtl[0] = paymentDataWork.MoneyKindName1;
            paymentSlp.MoneyKindNameDtl[1] = paymentDataWork.MoneyKindName2;
            paymentSlp.MoneyKindNameDtl[2] = paymentDataWork.MoneyKindName3;
            paymentSlp.MoneyKindNameDtl[3] = paymentDataWork.MoneyKindName4;
            paymentSlp.MoneyKindNameDtl[4] = paymentDataWork.MoneyKindName5;
            paymentSlp.MoneyKindNameDtl[5] = paymentDataWork.MoneyKindName6;
            paymentSlp.MoneyKindNameDtl[6] = paymentDataWork.MoneyKindName7;
            paymentSlp.MoneyKindNameDtl[7] = paymentDataWork.MoneyKindName8;
            paymentSlp.MoneyKindNameDtl[8] = paymentDataWork.MoneyKindName9;
            paymentSlp.MoneyKindNameDtl[9] = paymentDataWork.MoneyKindName10;
            paymentSlp.MoneyKindDivDtl = new int[10];
            paymentSlp.MoneyKindDivDtl[0] = paymentDataWork.MoneyKindDiv1;
            paymentSlp.MoneyKindDivDtl[1] = paymentDataWork.MoneyKindDiv2;
            paymentSlp.MoneyKindDivDtl[2] = paymentDataWork.MoneyKindDiv3;
            paymentSlp.MoneyKindDivDtl[3] = paymentDataWork.MoneyKindDiv4;
            paymentSlp.MoneyKindDivDtl[4] = paymentDataWork.MoneyKindDiv5;
            paymentSlp.MoneyKindDivDtl[5] = paymentDataWork.MoneyKindDiv6;
            paymentSlp.MoneyKindDivDtl[6] = paymentDataWork.MoneyKindDiv7;
            paymentSlp.MoneyKindDivDtl[7] = paymentDataWork.MoneyKindDiv8;
            paymentSlp.MoneyKindDivDtl[8] = paymentDataWork.MoneyKindDiv9;
            paymentSlp.MoneyKindDivDtl[9] = paymentDataWork.MoneyKindDiv10;
            paymentSlp.PaymentDtl = new long[10];
            paymentSlp.PaymentDtl[0] = paymentDataWork.Payment1;
            paymentSlp.PaymentDtl[1] = paymentDataWork.Payment2;
            paymentSlp.PaymentDtl[2] = paymentDataWork.Payment3;
            paymentSlp.PaymentDtl[3] = paymentDataWork.Payment4;
            paymentSlp.PaymentDtl[4] = paymentDataWork.Payment5;
            paymentSlp.PaymentDtl[5] = paymentDataWork.Payment6;
            paymentSlp.PaymentDtl[6] = paymentDataWork.Payment7;
            paymentSlp.PaymentDtl[7] = paymentDataWork.Payment8;
            paymentSlp.PaymentDtl[8] = paymentDataWork.Payment9;
            paymentSlp.PaymentDtl[9] = paymentDataWork.Payment10;
            paymentSlp.ValidityTermDtl = new DateTime[10];
            paymentSlp.ValidityTermDtl[0] = paymentDataWork.ValidityTerm1;
            paymentSlp.ValidityTermDtl[1] = paymentDataWork.ValidityTerm2;
            paymentSlp.ValidityTermDtl[2] = paymentDataWork.ValidityTerm3;
            paymentSlp.ValidityTermDtl[3] = paymentDataWork.ValidityTerm4;
            paymentSlp.ValidityTermDtl[4] = paymentDataWork.ValidityTerm5;
            paymentSlp.ValidityTermDtl[5] = paymentDataWork.ValidityTerm6;
            paymentSlp.ValidityTermDtl[6] = paymentDataWork.ValidityTerm7;
            paymentSlp.ValidityTermDtl[7] = paymentDataWork.ValidityTerm8;
            paymentSlp.ValidityTermDtl[8] = paymentDataWork.ValidityTerm9;
            paymentSlp.ValidityTermDtl[9] = paymentDataWork.ValidityTerm10;
            paymentSlp.InputDay = paymentDataWork.InputDay;

            return paymentSlp;
        }
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 支払伝票登録処理
		/// </summary>
		/// <param name="paymentSlp">支払伝票マスタ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払伝票の登録・更新を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.23</br>
		/// </remarks>
		public int Write(ref PaymentSlp paymentSlp)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			_errorMessage = "";

			PaymentSlpWork paymentSlpWork
				= (PaymentSlpWork)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentSlp, typeof(PaymentSlpWork));
			// XMLへ変換
			byte[] parabyte = XmlByteSerializer.Serialize(paymentSlpWork);

			try
			{
				// 入金データ書き込み
				status = this._iPaymentSlpDB.Write(ref parabyte);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// XMLの読み込み
						paymentSlpWork = (PaymentSlpWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentSlpWork));
						paymentSlp = (PaymentSlp)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentSlpWork, typeof(PaymentSlp));
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						_errorMessage = "支払伝票は他端末により既に更新、又は削除されています。";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						_errorMessage = "支払伝票は他端末により既に削除されています。";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT:
					{
						_errorMessage = "支払番号を別端末が採番しています。\r\nしばらくお待ちになって再度実行してください。";
						break;
					}
					default:
					{
						_errorMessage = "支払伝票の保存処理に失敗しました。";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorMessage = "支払伝票の保存処理にて例外が発生しました。\r\n" +ex.Message;
				//オフライン時はnullをセット
				_iPaymentSlpDB = null;
				//通信エラーは-1を戻す
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// 支払伝票読込処理
		/// </summary>
		/// <param name="paymentSlp">支払伝票マスタ</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="paymentSlipNo">支払伝票番号</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払伝票の読込を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.23</br>
		/// </remarks>
		public int Read(out PaymentSlp paymentSlp, string enterpriseCode, int paymentSlipNo)
		{
			int status = 0;
			_errorMessage = "";
			paymentSlp = null;

			try
			{
				byte[] parabyte;
				status = _iPaymentSlpDB.Read(enterpriseCode, paymentSlipNo, out parabyte);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// XMLの読み込み
						PaymentSlpWork paymentSlpWork = (PaymentSlpWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentSlpWork));
						// クラス内メンバコピー
						paymentSlp = (PaymentSlp)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentSlpWork, typeof(PaymentSlp));
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						_errorMessage = "指定支払伝票は存在しません。";
						break;
					}
					default:
					{
						_errorMessage = "支払伝票の読込処理に失敗しました。";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorMessage = "支払伝票の読込にて例外が発生しました。\r\n" + ex.Message;
				//オフライン時はnullをセット
				_iPaymentSlpDB = null;
				//通信エラーは-1を戻す
				status = -1;
			}

			return status;
		}

        /// <summary>
		/// 支払伝票削除処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="paymentSlipNo">支払伝票番号</param>
		/// <param name="retPaymentSlpWork">元相殺済み黒伝</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払伝票の削除を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.23</br>
		/// <br>Update Note : 2007.02.13 18322 T.Kimura 赤伝を削除したときに元相殺済み黒伝を返すように変更</br>
		/// </remarks>
        // ↓ 20070213 18322 c MA.NS用に変更
		//public int Delete(string enterpriseCode, int paymentSlipNo)
		//{

		public int Delete(string enterpriseCode, int paymentSlipNo, out PaymentSlpWork retPaymentSlpWork)
		{
            retPaymentSlpWork = null;

        // ↑ 20070213 18322 c
			int status = 0;
			_errorMessage = "";

			try
			{
                // ↓ 20070213 18322 c
                //status = _iPaymentSlpDB.Delete(enterpriseCode, paymentSlipNo);

                byte[] PaymentSlpWorkByte;

                // 支払伝票削除
				status = _iPaymentSlpDB.Delete(enterpriseCode, paymentSlipNo, out PaymentSlpWorkByte);
                // ↑ 20070213 18322 c

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        // 20070213 18322 a MA.NS用に変更
                        if (PaymentSlpWorkByte != null) 
                        {
						    // 元相殺済み黒伝を返す。
                            retPaymentSlpWork = (PaymentSlpWork)XmlByteSerializer.Deserialize(PaymentSlpWorkByte, typeof(PaymentSlpWork));
                        }
                        // ↑ 20070213 18322 a
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						_errorMessage = "支払伝票は他端末により既に更新、又は削除されています。";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						_errorMessage = "支払伝票は他端末により既に削除されています。";
						break;
					}
					default:
					{
						_errorMessage = "支払伝票の削除処理に失敗しました。";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorMessage = "支払伝票の削除処理にて例外が発生しました。\r\n" + ex.Message;
				//オフライン時はnullをセット
				_iPaymentSlpDB = null;
				//通信エラーは-1を戻す
				status = -1;
			}

			return status;
		}

        /// <summary>
        /// 支払伝票赤伝作成処理
        /// </summary>
        /// <param name="mode">赤伝作成モード 0:赤入金作成</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="updateSecCd">更新拠点コード</param>
        /// <param name="paymentAgentCode">支払担当者コード</param>
        /// <param name="paymentAgentNm">支払担当者名</param>
        /// <param name="addUpADate">計上日</param>
        /// <param name="paymentSlipNo">支払伝票番号(赤伝を行う黒伝)</param>
        /// <param name="retPaymentSlpWorkList">支払伝票マスタ(更新結果)</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した支払伝票番号の赤支払作成処理を行います</br>
		/// <br>Programmer : 18322 木村 武正</br>
		/// <br>Date       : 2006.12.22</br>
		/// </remarks>
        public int RedCreate(int mode, string enterpriseCode, string updateSecCd, string paymentAgentCode, string paymentAgentNm, DateTime addUpADate, int paymentSlipNo, out ArrayList retPaymentSlpWorkList)
        {
            int status = 0;
            _errorMessage = "";

            retPaymentSlpWorkList = new ArrayList();
            retPaymentSlpWorkList.Clear();

            try
            {
                object retObj;
                status = _iPaymentSlpDB.RedCreate(mode,
                                                  enterpriseCode,
                                                  updateSecCd,
                                                  paymentAgentCode,
                                                  paymentAgentNm,
                                                  addUpADate,
                                                  paymentSlipNo,
                                                  out retObj);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            ArrayList wkList = retObj as ArrayList;
                            if (wkList != null)
                            {
                                for (int i = 0; i != wkList.Count; i++)
                                {
                                    PaymentSlpWork work = (PaymentSlpWork)wkList[i];
                                    retPaymentSlpWorkList.Add(work);
                                }
                            }
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            _errorMessage = "支払伝票は他端末により既に更新、又は削除されています。";
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "支払伝票は他端末により既に削除されています。";
                            break;
                        }
                    default:
                        {
                            _errorMessage = "支払伝票の赤伝処理に失敗しました。";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "支払伝票の赤伝処理にて例外が発生しました。\r\n" + ex.Message;
                //オフライン時はnullをセット
                _iPaymentSlpDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        #endregion
    }
}
