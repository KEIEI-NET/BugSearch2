//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Model
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2009/10/05  修正内容 : MANTIS[14370] 電文取得方法変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2012/08/06  修正内容 : 特定のパターンでエラーになる為、キーの作成方法の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2012/08/08  修正内容 : uoeSalesOrderRowNoが数値でかつuoeSalesOrderRowNoが文字列の場合
//                                  エラーで落ちる既存不具合の修正
//----------------------------------------------------------------------------//

using System;
using System.Text;
using Broadleaf.Library.Text; // 2009/10/05 ADD

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 受信テキスト（仕入要求電文の応答）クラス
    /// </summary>
    public sealed class ReceivedText
    {
        /// <summary>電話で発注したときの電文問合せ番号</summary>
        public const int SALES_ORDER_NO_BY_TELEPHONE = 0;

        #region <電文/>

        /// <summary>電文のサイズ[Byte]</summary>
        public const int TELEGRAM_LENGTH = 256;

        /// <summary>電文</summary>
        private readonly byte[] _telegram = new byte[TELEGRAM_LENGTH];
        /// <summary>
        /// 電文を取得します。
        /// </summary>
        /// <value>電文</value>
        private byte[] Telegram { get { return _telegram; } }

        #endregion  // <電文/>

        #region <GUID/>

        /// <summary>明細データとの関連に用いるGUID</summary>
        private Guid _dtlRelationGuid;
        /// <summary>
        /// 明細データとの関連に用いるGUIDのアクセサ
        /// </summary>
        /// <value>明細データとの関連に用いるGUID</value>
        public Guid DtlRelationGuid
        {
            get { return _dtlRelationGuid; }
            set { _dtlRelationGuid = value; }
        }

        #endregion  // <GUID/>

        #region <受信した順番（出荷伝票内で1～連番）/>

        /// <summary>受信した順番（出荷伝票内で1～連番）</summary>
        /// <remarks>電話発注データは本順番が回答電文対応行となります。</remarks>
        private int _innerIndex;
        /// <summary>
        /// 受信した順番のアクセサ
        /// </summary>
        public int InnerIndex
        {
            get { return _innerIndex; }
            set { _innerIndex = value; }
        }

        #endregion  // <受信した順番（出荷伝票内で1～連番）/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="telegram">電文</param>
        /// <param name="beginIndex">開始インデックス</param>
        /// <param name="innerIndex">受信した順番（出荷伝票内で1～連番）</param>
        public ReceivedText(
            byte[] telegram,
            int beginIndex,
            int innerIndex
        )
        {
            Array.Copy(telegram, beginIndex, _telegram, 0, TELEGRAM_LENGTH);
            _innerIndex = innerIndex;
        }

        #endregion  // <Constructor/>

        #region <電文ヘッダー部/>

        #region <電文区分/>

        /// <summary>
        /// 電文区分を取得します。
        /// </summary>
        /// <remarks>1バイト目（1[Byte]）</remarks>
        /// <value>電文区分</value>
        public string TelegramDiv
        {
            get
            {
                const int TELEGRAM_POSITION = 1;
                const int BYTE_LENGTH       = 1;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <電文区分/>

        #region <処理区分/>

        /// <summary>
        /// 処理区分を取得します。
        /// </summary>
        /// <remarks>2バイト目（1[Byte]）</remarks>
        /// <value>処理区分</value>
        public string ProcessDiv
        {
            get
            {
                const int TELEGRAM_POSITION = 2;
                const int BYTE_LENGTH       = 1;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <処理区分/>

        #region <処理結果/>

        /// <summary>
        /// 処理結果を取得します。
        /// </summary>
        /// <remarks>3バイト目（2[Byte]）</remarks>
        /// <value>処理結果</value>
        public string ProcessResult
        {
            get
            {
                const int TELEGRAM_POSITION = 3;
                const int BYTE_LENGTH       = 2;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <処理結果/>

        #region <電文問合せ番号>

        /// <summary>
        /// 電文問合せ番号を取得します。
        /// </summary>
        /// <remarks>5バイト目（6[Byte]）</remarks>
        /// <value>電話問合せ番号</value>
        public string UOESalesOrderNo
        {
            get
            {
                const int TELEGRAM_POSITION = 5;
                const int BYTE_LENGTH       = 6;
                const string TEL_ORDER_NO   = "000000";

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);

                string uoeSalesOrderNo = ConvertString(jisCodes);

                if (TStrConv.StrToIntDef(uoeSalesOrderNo.Trim(), 0) == 0) uoeSalesOrderNo = TEL_ORDER_NO; // 2009/10/05 ADD
                return string.IsNullOrEmpty(uoeSalesOrderNo.Trim()) ? TEL_ORDER_NO : uoeSalesOrderNo;
            }
        }

        #endregion  // <電文問合せ番号/>

        #region <回答電文対応行/>

        /// <summary>
        /// 回答電文対応行を取得します。
        /// </summary>
        /// <remarks>11バイト目（1[Byte]）</remarks>
        /// <value>回答電文対応行</value>
        public string UOESalesOrderRowNo
        {
            get
            {
                const int TELEGRAM_POSITION = 11;
                const int BYTE_LENGTH       = 1;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);

                string uoeSalesOrderRowNo = ConvertString(jisCodes);

                if (int.Parse(UOESalesOrderNo).Equals(SALES_ORDER_NO_BY_TELEPHONE)) uoeSalesOrderRowNo = string.Empty; // 2009/10/05 ADD
                // add 2012/08/08 >>>
                try
                {
                    int tempUoeSalesOrderRowNo = Convert.ToInt32(uoeSalesOrderRowNo);
                }
                catch
                {
                    uoeSalesOrderRowNo = string.Empty;
                }
                // add 2012/08/08 <<<

                return string.IsNullOrEmpty(uoeSalesOrderRowNo.Trim()) ? InnerIndex.ToString() : uoeSalesOrderRowNo;
            }
        }

        #endregion  // <回答電文対応行/>

        #region <リマーク/>

        /// <summary>
        /// リマークを取得します。
        /// </summary>
        /// <remarks>12バイト目（10[Byte]）</remarks>
        /// <value>リマーク</value>
        public string UOERemark
        {
            get
            {
                const int TELEGRAM_POSITION = 12;
                const int BYTE_LENGTH       = 10;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <リマーク/>

        #region <納品区分/>

        /// <summary>
        /// 納品区分を取得します。
        /// </summary>
        /// <remarks>22バイト目（1[Byte]）</remarks>
        /// <value>納品区分</value>
        public string DeliveryGoodsDiv
        {
            get
            {
                const int TELEGRAM_POSITION = 22;
                const int BYTE_LENGTH       = 1;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <納品区分/>

        #region <指定拠点/>

        /// <summary>
        /// 指定拠点を取得します。
        /// </summary>
        /// <remarks>23バイト目（3[Byte]）</remarks>
        /// <value>指定拠点</value>
        public string ReservedSection
        {
            get
            {
                const int TELEGRAM_POSITION = 23;
                const int BYTE_LENGTH       = 3;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <指定拠点/>

        #endregion  // <電文ヘッダー部/>

        #region <電文明細部/>

        #region <受注部品番号/>

        /// <summary>
        /// 受注部品番号を取得します。
        /// </summary>
        /// <remarks>26バイト目（20[Byte]）</remarks>
        /// <value>受注部品番号</value>
        public string AcceptPartsNo
        {
            get
            {
                const int TELEGRAM_POSITION = 26;
                const int BYTE_LENGTH       = 20;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <受注部品番号/>

        #region <出荷部品番号/>

        /// <summary>
        /// 出荷部品番号を取得します。
        /// </summary>
        /// <remarks>46バイト目（20[Byte]）</remarks>
        /// <value>出荷部品番号</value>
        public string AnswerPartsNo
        {
            get
            {
                const int TELEGRAM_POSITION = 46;
                const int BYTE_LENGTH       = 20;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <出荷部品番号/>

        #region <メーカーコード/>

        /// <summary>
        /// メーカーコードを取得します。
        /// </summary>
        /// <remarks>66バイト目（4[Byte]）</remarks>
        /// <value>メーカーコード</value>
        public string AnswerMakerCode
        {
            get
            {
                const int TELEGRAM_POSITION = 66;
                const int BYTE_LENGTH       = 4;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <メーカーコード/>

        #region <分類コード/>

        /// <summary>
        /// 分類コードを取得します。
        /// </summary>
        /// <remarks>70バイト目（4[Byte]）</remarks>
        /// <value>分類コード</value>
        public string ClassifiedCode
        {
            get
            {
                const int TELEGRAM_POSITION = 70;
                const int BYTE_LENGTH       = 4;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <分類コード/>

        #region <品名/>

        /// <summary>
        /// 品名を取得します。
        /// </summary>
        /// <remarks>74バイト目（20[Byte]）</remarks>
        /// <value>品名</value>
        public string AnswerPartsName
        {
            get
            {
                const int TELEGRAM_POSITION = 74;
                const int BYTE_LENGTH       = 20;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <品名/>

        #region <定価/>

        /// <summary>
        /// 定価を取得します。
        /// </summary>
        /// <remarks>94バイト目（7[Byte]）</remarks>
        /// <value>定価</value>
        public string AnswerListPrice
        {
            get
            {
                const int TELEGRAM_POSITION = 94;
                const int BYTE_LENGTH       = 7;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <定価/>

        #region <仕切単価/>

        /// <summary>
        /// 仕切単価を取得します。
        /// </summary>
        /// <remarks>101バイト目（7[Byte]）</remarks>
        /// <value>仕切単価</value>
        public string AnswerSalesUnitCost
        {
            get
            {
                const int TELEGRAM_POSITION = 101;
                const int BYTE_LENGTH       = 7;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <仕切単価/>

        #region <受注数/>

        /// <summary>
        /// 受注数を取得します。
        /// </summary>
        /// <remarks>108バイト目（3[Byte]）</remarks>
        /// <value>受注数</value>
        public string AcceptAnOrderCount
        {
            get
            {
                const int TELEGRAM_POSITION = 108;
                const int BYTE_LENGTH       = 3;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <受注数/>

        #region <出荷数/>

        /// <summary>
        /// 出荷数を取得します。
        /// </summary>
        /// <remarks>111バイト目（3[Byte]）</remarks>
        /// <value>出荷数</value>
        public string UOESectOutGoodsCount
        {
            get
            {
                const int TELEGRAM_POSITION = 111;
                const int BYTE_LENGTH       = 3;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <出荷数/>

        #region <B/O区分/>

        /// <summary>
        /// B/O区分を取得します。
        /// </summary>
        /// <remarks>114バイト目（1[Byte]）</remarks>
        /// <value>B/O区分</value>
        public string BOCode
        {
            get
            {
                const int TELEGRAM_POSITION = 114;
                const int BYTE_LENGTH       = 1;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <B/O区分/>

        #region <予備コード/>

        /// <summary>
        /// 予備コードを取得します。
        /// </summary>
        /// <remarks>115バイト目（1[Byte]）</remarks>
        /// <value>予備コード</value>
        public string UOEMarkCode
        {
            get
            {
                const int TELEGRAM_POSITION = 115;
                const int BYTE_LENGTH       = 1;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <予備コード/>

        #region <B/O数/>

        /// <summary>
        /// B/O数を取得します。
        /// </summary>
        /// <remarks>116バイト目（3[Byte]）</remarks>
        /// <value>B/O数</value>
        public string BOShipmentCount
        {
            get
            {
                const int TELEGRAM_POSITION = 116;
                const int BYTE_LENGTH       = 3;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <B/O数/>

        #region <出荷伝票番号/>

        /// <summary>
        /// 出荷伝票番号を取得します。
        /// </summary>
        /// <remarks>119バイト目（6[Byte]）</remarks>
        /// <value>出荷伝票番号</value>
        public string UOESectionSlipNo
        {
            get
            {
                const int TELEGRAM_POSITION = 119;
                const int BYTE_LENGTH       = 6;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <出荷伝票番号/>

        #region <B/O伝票番号/>

        /// <summary>
        /// B/O伝票番号を取得します。
        /// </summary>
        /// <remarks>125バイト目（6[Byte]）</remarks>
        /// <value>B/O伝票番号</value>
        public string BOSlipNo
        {
            get
            {
                const int TELEGRAM_POSITION = 125;
                const int BYTE_LENGTH       = 6;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <B/O伝票番号/>

        #region <ラインエラー/>

        /// <summary>
        /// ラインエラーを取得します。
        /// </summary>
        /// <remarks>131バイト目（15[Byte]）</remarks>
        /// <value>ラインエラー</value>
        public string LineErrorMessage
        {
            get
            {
                const int TELEGRAM_POSITION = 131;
                const int BYTE_LENGTH       = 15;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <ラインエラー/>

        #region <チェックコード/>

        /// <summary>
        /// ラインエラーを取得します。
        /// </summary>
        /// <remarks>146バイト目（10[Byte]）</remarks>
        /// <value>ラインエラー</value>
        public string UOECheckCode
        {
            get
            {
                const int TELEGRAM_POSITION = 146;
                const int BYTE_LENGTH       = 10;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <チェックコード/>

        #endregion  // <電文明細部/>

        /// <summary>強制的に電話発注とみなすフラグ</summary>
        /// <remarks>オンライン発注のデータが検索されなかったときに<c>true</c></remarks>
        private bool _isTelephoneOrderForced;
        /// <summary>
        /// 強制的に電話発注とみなすフラグのアクセサ
        /// </summary>
        public bool IsTelephoneOrderForced
        {
            get { return _isTelephoneOrderForced; }
            set { _isTelephoneOrderForced = value; }
        }

        /// <summary>
        /// 電話発注か判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :電話発注である<br/>
        /// <c>false</c>:電話発注ではない
        /// </returns>
        public bool IsTelephoneOrder()
        {
            if (IsTelephoneOrderForced) return true;

            return int.Parse(UOESalesOrderNo).Equals(SALES_ORDER_NO_BY_TELEPHONE);
        }

        /// <summary>
        /// キーに変換します。
        /// </summary>
        /// <returns>出荷伝票番号("000000") + "-" + UOE発注伝票番号：電文問合せ番号("000000") + "-" + UOE発注行番号：回答電文対応行("00")</returns>
        public string ToKey()
        {
            // upd 2012/08/06 >>>
            //return GetKey(this);
            return GetKey(this, InnerIndex);
            // upd 2012/08/06 <<<
        }

        /// <summary>
        /// 出荷伝票番号に変換します。
        /// </summary>
        /// <returns>出荷伝票番号("000000")</returns>
        public string ToSlipNo()
        {
            return FormatUOESectionSlipNo(UOESectionSlipNo);
        }

        /// <summary>
        /// 商品番号に変換します。
        /// </summary>
        /// <returns>
        /// 出荷部品番号
        /// （出荷部品番号が空またはスペースの場合、品名を返します）
        /// </returns>
        public string ToGoodsNo()
        {
            if (!string.IsNullOrEmpty(AnswerPartsNo.Trim()))
            {
                return AnswerPartsNo.Trim();
            }
            else
            {
                return this.AnswerPartsName.Trim();
            }
        }

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <param name="jisCodes">JISコード配列</param>
        /// <returns>文字列</returns>
        private static string ConvertString(byte[] jisCodes)
        {
            return Broadleaf.Library.Text.TStrConv.SJisToUnicode(jisCodes).Trim();
        }

        /// <summary>
        /// フォーマット化された出荷伝票番号を取得します。
        /// </summary>
        /// <param name="uoeSectionSlipNo">出荷伝票番号</param>
        /// <returns>出荷伝票番号("000000")</returns>
        public static string FormatUOESectionSlipNo(string uoeSectionSlipNo)
        {
            return uoeSectionSlipNo.Trim().PadLeft(6, '0');   
        }

        /// <summary>
        /// キーを取得します。
        /// </summary>
        /// <param name="receivedText">受信テキスト</param>
        /// <param name="innnerIndex">受信した順番（出荷伝票内で1～連番）</param>
        /// <returns>出荷伝票番号("000000") + "-" + UOE発注伝票番号：電文問合せ番号("000000") + "-" + UOE発注行番号：回答電文対応行("00")</returns>
        // upd 2012/08/06 >>>
        //public static string GetKey(ReceivedText receivedText)
        public static string GetKey(ReceivedText receivedText, int innnerIndex)
        // upd 2012/08/06 <<<
        {
            return GetKey(
                receivedText.UOESectionSlipNo.Trim(),
                int.Parse(receivedText.UOESalesOrderNo),
                // upd 2012/08/06 >>>
                //int.Parse(receivedText.UOESalesOrderRowNo)
                int.Parse(receivedText.UOESalesOrderRowNo),
                innnerIndex
                // upd 2012/08/06 <<<
            );
        }

        /// <summary>
        /// キーを取得します。
        /// </summary>
        /// <param name="uoeSectionSlipNo">出荷伝票番号</param>
        /// <param name="uoeSalesOrderNo">UOE発注伝票番号（電文問合せ番号）</param>
        /// <param name="uoeSalesOrderRowNo">UOE発注行番号（回答電文対応行）</param>
        /// <returns>出荷伝票番号("000000") + "-" + UOE発注伝票番号：電文問合せ番号("000000") + "-" + UOE発注行番号：回答電文対応行("00")</returns>
        public static string GetKey(
            string uoeSectionSlipNo,
            int uoeSalesOrderNo,
            // upd 2012/08/06 >>>
            //int uoeSalesOrderRowNo
            int uoeSalesOrderRowNo,
            int innerIndex
            // upd 2012/08/06 <<<
        )
        {
            const string SEPARATOR = "-";
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatUOESectionSlipNo(uoeSectionSlipNo));
                key.Append(SEPARATOR);
                key.Append(uoeSalesOrderNo.ToString("000000"));
                key.Append(SEPARATOR);
                key.Append(uoeSalesOrderRowNo.ToString("00"));
                // add 2012/08/06 >>>
                key.Append(SEPARATOR);
                key.Append(innerIndex.ToString());
                // add 2012/08/06 <<<
            }
            return  key.ToString();
        }

        #region <Override/>

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("電文区分：").Append(TelegramDiv).Append(Environment.NewLine);
            str.Append("処理区分：").Append(ProcessDiv).Append(Environment.NewLine);
            str.Append("処理結果：").Append(ProcessResult).Append(Environment.NewLine);
            str.Append("電文問合せ番号：").Append(UOESalesOrderNo).Append(Environment.NewLine);
            str.Append("回答電文対応行：").Append(UOESalesOrderRowNo).Append(Environment.NewLine);
            str.Append("リマーク：").Append(UOERemark).Append(Environment.NewLine);
            str.Append("納品区分：").Append(DeliveryGoodsDiv).Append(Environment.NewLine);
            str.Append("指定拠点：").Append(ReservedSection).Append(Environment.NewLine);
            str.Append("受注部品番号：").Append(AcceptPartsNo).Append(Environment.NewLine);
            str.Append("出荷部品番号：").Append(AnswerPartsNo).Append(Environment.NewLine);
            str.Append("メーカーコード：").Append(AnswerMakerCode).Append(Environment.NewLine);
            str.Append("分類コード：").Append(ClassifiedCode).Append(Environment.NewLine);
            str.Append("品名：").Append(AnswerPartsName).Append(Environment.NewLine);
            str.Append("定価：").Append(AnswerListPrice).Append(Environment.NewLine);
            str.Append("仕切単価：").Append(AnswerSalesUnitCost).Append(Environment.NewLine);
            str.Append("受注数：").Append(AcceptAnOrderCount).Append(Environment.NewLine);
            str.Append("出荷数：").Append(UOESectOutGoodsCount).Append(Environment.NewLine);
            str.Append("B/O区分：").Append(BOCode).Append(Environment.NewLine);
            str.Append("予備コード：").Append(UOEMarkCode).Append(Environment.NewLine);
            str.Append("B/O数：").Append(BOShipmentCount).Append(Environment.NewLine);
            str.Append("出荷伝票番号：").Append(UOESectionSlipNo).Append(Environment.NewLine);
            str.Append("B/O伝票番号：").Append(BOSlipNo).Append(Environment.NewLine);
            str.Append("ラインエラー：").Append(LineErrorMessage).Append(Environment.NewLine);
            str.Append("チェックコード：").Append(UOECheckCode).Append(Environment.NewLine);

            return str.ToString();
        }

        #endregion  // <Override/>
    }
}
