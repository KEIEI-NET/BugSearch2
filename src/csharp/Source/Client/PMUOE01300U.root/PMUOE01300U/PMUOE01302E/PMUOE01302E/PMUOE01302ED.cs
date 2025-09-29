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
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2012/08/06  修正内容 : 特定のパターンでエラーになる為、キーの作成方法の変更
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    #region <Iterator Idiom/>

    /// <summary>
    /// 集合体インターフェース
    /// </summary>
    /// <typeparam name="T">集合体となるクラス</typeparam>
    public interface IAgreegate<T> where T : class
    {
        /// <summary>
        /// 集合体のサイズを取得します。
        /// </summary>
        /// <value>集合体のサイズ</value>
        int Size { get; }

        /// <summary>
        /// インデックスに対応する要素を取得します。
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>インデックスに対応する要素</returns>
        T GetAt(int index); // HACK:インデクサの方が望ましい…

        /// <summary>
        /// 反復子を生成します。
        /// </summary>
        /// <returns>反復子</returns>
        IIterator<T> CreateIterator();

        /// <summary>
        /// グループ化されたまとまり（リスト）のマップを取得します。
        /// </summary>
        /// <value>グループ化されたまとまり（リスト）のマップ</value>
        IDictionary<string, IList<T>> GroupedListMap { get; }
    }

    /// <summary>
    /// 反復子インターフェース
    /// </summary>
    /// <typeparam name="T">反復子となるクラス</typeparam>
    public interface IIterator<T> where T : class
    {
        /// <summary>
        /// 次の反復子があるか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :あり<br/>
        /// <c>false</c>:なし
        /// </returns>
        bool HasNext();

        /// <summary>
        /// 次の反復子を取得します。
        /// </summary>
        /// <returns>次の反復子</returns>
        T GetNext();
    }

    /// <summary>
    /// 簡易反復子クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SimpleIterator<T> : IIterator<T> where T : class
    {
        #region IIterator<T> メンバ

        /// <summary>
        /// 次の反復子があるか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :あり<br/>
        /// <c>false</c>:なし
        /// </returns>
        public bool HasNext()
        {
            return _nextIndex < Agreegate.Size;
        }

        /// <summary>
        /// 次の反復子を取得します。
        /// </summary>
        /// <returns>次の反復子</returns>
        public T GetNext()
        {
            return Agreegate.GetAt(_nextIndex++);
        }

        #endregion

        #region <集合体/>

        /// <summary>受信テキストの集合体</summary>
        private readonly IAgreegate<T> _agreegate;
        /// <summary>
        /// 受信テキストの集合体を取得します。
        /// </summary>
        /// <value>受信テキストの集合体</value>
        protected IAgreegate<T> Agreegate { get { return _agreegate; } }

        #endregion  // <集合体/>

        /// <summary>次の要素のインデックス</summary>
        protected int _nextIndex;

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="agreegate">集合体</param>
        public SimpleIterator(IAgreegate<T> agreegate)
        {
            _agreegate = agreegate;
        }

        #endregion  // <Constructor/>
    }

    #endregion  // <Iterator Idiom/>

    /// <summary>
    /// 受信テキスト（仕入要求電文の応答）の集合体クラス
    /// </summary>
    public sealed class ReceivedTextAgreegate : IAgreegate<ReceivedText>
    {
        #region <IAgreegate<ReceivedText> メンバ/>

        /// <summary>
        /// 集合体のサイズを取得します。
        /// </summary>
        /// <value>集合体のサイズ</value>
        public int Size
        {
            get { return ReceivedTextList.Count; }
        }

        /// <summary>
        /// インデックスに対応する要素を取得します。
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>インデックスに対応する要素</returns>
        public ReceivedText GetAt(int index)
        {
            return ReceivedTextList[index];
        }

        /// <summary>
        /// 反復子を生成します。
        /// </summary>
        /// <returns>反復子</returns>
        public IIterator<ReceivedText> CreateIterator()
        {
            return new SimpleIterator<ReceivedText>(this);
        }

        /// <summary>
        /// グループ化されたまとまり（リスト）のマップを取得します。
        /// </summary>
        /// <value>グループ化されたまとまり（リスト）のマップ</value>
        public IDictionary<string, IList<ReceivedText>> GroupedListMap
        {
            get { return ReceivedTextListMap; }
        }

        #endregion  // <IAgreegate<ReceivedText> メンバ/>

        #region <UOE受信結果/>

        /// <summary>UOE受信結果（ヘッダー）</summary>
        private readonly UoeRecHed _uoeReceivedResult;
        /// <summary>
        /// UOE受信結果（ヘッダー）を取得します。
        /// </summary>
        /// <value>UOE受信結果（ヘッダー）</value>
        private UoeRecHed UOEReceivedResult { get { return _uoeReceivedResult; } }

        #endregion  // <UOE受信結果/>

        #region <受信テキスト/>

        /// <summary>受信テキストマップ（検索用）</summary>
        private readonly IDictionary<string, ReceivedText> _receivedTextMap;
        /// <summary>
        /// 受信テキストマップ（検索用）を取得します。
        /// </summary>
        /// <value>受信テキストマップ（検索用）</value>
        private IDictionary<string, ReceivedText> ReceivedTextMap { get { return _receivedTextMap; } } 

        // TODO:マップのみとしたい…
        /// <summary>受信テキストリスト（走査用）</summary>
        private readonly IList<ReceivedText> _receivedTextList;
        /// <summary>
        /// 受信テキストリスト（走査用）を取得します。
        /// </summary>
        /// <value>受信テキストリスト（走査用）</value>
        private IList<ReceivedText> ReceivedTextList { get { return _receivedTextList; } }

        /// <summary>出荷伝票番号別の受信テキストリストのマップ</summary>
        private readonly IDictionary<string, IList<ReceivedText>> _receivedTextListMap;
        /// <summary>
        /// 出荷伝票番号別の受信テキストリストのマップを取得します。
        /// </summary>
        /// <value>出荷伝票番号別の受信テキストリストのマップ</value>
        private IDictionary<string, IList<ReceivedText>> ReceivedTextListMap { get { return _receivedTextListMap; } }

        #endregion  // <受信テキスト/>

        /// <summary>出荷伝票番号別の受信データのカウンタマップ</summary>
        private readonly IDictionary<string, int> _innerIndexCounterMap = new Dictionary<string, int>();
        /// <summary>
        /// 出荷伝票番号別の受信データのカウンタマップ
        /// </summary>
        private IDictionary<string, int> InnerIndexCounterMap { get { return _innerIndexCounterMap; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slipNo">出荷伝票番号</param>
        /// <returns></returns>
        private int GetInnerIndexNo(string slipNo)
        {
            if (!InnerIndexCounterMap.ContainsKey(slipNo))
            {
                InnerIndexCounterMap.Add(slipNo, 0);
            }
            int nextInnerIndex = ++InnerIndexCounterMap[slipNo];
            InnerIndexCounterMap[slipNo] = nextInnerIndex;

            return nextInnerIndex;
        }

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeReceivedResult">UOE受信結果（ヘッダー）</param>
        public ReceivedTextAgreegate(UoeRecHed uoeReceivedResult)
        {
            _uoeReceivedResult = uoeReceivedResult;

            _receivedTextMap    = new Dictionary<string, ReceivedText>();
            _receivedTextList   = new List<ReceivedText>();
            _receivedTextListMap= new Dictionary<string, IList<ReceivedText>>();

            foreach (UoeRecDtl uoeRecDtl in uoeReceivedResult.UoeRecDtlList)
            {
                InitializeReceivedTextCollection(uoeRecDtl);
            }
        }

        /// <summary>
        /// 受信テキストコレクションを初期化します。
        /// </summary>
        /// <param name="stockRequestAnswer">仕入要求の応答</param>
        private void InitializeReceivedTextCollection(UoeRecDtl stockRequestAnswer)
        {
            // 開局／閉局電文の応答は無視
            if (stockRequestAnswer.UOESalesOrderNo.Equals(0)) return;

            int answerCount = stockRequestAnswer.RecTelegram.Length / ReceivedText.TELEGRAM_LENGTH;
            for (int iAnswer = 0; iAnswer < answerCount; iAnswer++)
            {
                int beginIndex = iAnswer * ReceivedText.TELEGRAM_LENGTH;
                ReceivedText receivedText = new ReceivedText(stockRequestAnswer.RecTelegram, beginIndex, iAnswer + 1);

                // 出荷伝票番号でグループ化
                string slipNo = ReceivedText.FormatUOESectionSlipNo(receivedText.UOESectionSlipNo);
                receivedText.InnerIndex = GetInnerIndexNo(slipNo);

                if (!ReceivedTextListMap.ContainsKey(slipNo))
                {
                    ReceivedTextListMap.Add(slipNo, new List<ReceivedText>());
                }
                ReceivedTextListMap[slipNo].Add(receivedText);

                // 検索用マップと走査用リスト
                // upd 2012/08/06 >>>
                //string key = ReceivedText.GetKey(receivedText);
                string key = ReceivedText.GetKey(receivedText, receivedText.InnerIndex);
                // upd 2012/08/06 <<<
                if (!ReceivedTextMap.ContainsKey(key))
                {
                    ReceivedTextMap.Add(key, receivedText);
                    ReceivedTextList.Add(receivedText);
                }
            }
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < ReceivedTextList.Count; i++)
            {
                str.Append("受信テキスト[").Append(i).Append("]").Append(Environment.NewLine);
                str.Append(ReceivedTextList[i].ToString()).Append(Environment.NewLine);
                str.Append(Environment.NewLine);
            }

            return str.ToString();
        }

        #endregion  // <Override/>
    }
}
