using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   JoinPartsUProcParamWork
    /// <summary>
    ///                      結合マスタ抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   結合マスタ抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/06/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APJoinPartsUProcParamWork
    {
        /// <summary>開始日時</summary>
        private Int64 _beginningDate;

        /// <summary>終了日時</summary>
        private Int64 _endingDate;

        /// <summary>結合元品番(開始)</summary>
        private string _JoinSourPartsNoWithHBegin = "";

        /// <summary>結合元品番(終了)</summary>
        private string _JoinSourPartsNoWithHEnd = "";

        /// <summary>結合元メーカーコード(開始)</summary>
        private Int32 _joinSourceMakerCodeBegin;

        /// <summary>結合元メーカーコード(終了)</summary>
        private Int32 _joinSourceMakerCodeEnd;

        /// <summary>結合表示順位(開始)</summary>
        private Int32 _joinDispOrderBegin;

        /// <summary>結合表示順位(終了)</summary>
        private Int32 _joinDispOrderEnd;

        /// <summary>結合先メーカーコード(開始)</summary>
        private Int32 _joinDestMakerCodeBegin;

        /// <summary>結合先メーカーコード(終了)</summary>
        private Int32 _joinDestMakerCodeEnd;


        /// public propaty name  :  BeginningDate
        /// <summary>開始日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 UpdateDateTimeBegin
        {
            get { return _beginningDate; }
            set { _beginningDate = value; }
        }

        /// public propaty name  :  EndingDate
        /// <summary>終了日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 UpdateDateTimeEnd
        {
            get { return _endingDate; }
            set { _endingDate = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithHBegin
        /// <summary>結合元品番(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元品番(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoWithHBeginRF
        {
            get { return _JoinSourPartsNoWithHBegin; }
            set { _JoinSourPartsNoWithHBegin = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithHEnd
        /// <summary>結合元品番(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元品番(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoWithHEndRF
        {
            get { return _JoinSourPartsNoWithHEnd; }
            set { _JoinSourPartsNoWithHEnd = value; }
        }

        /// public propaty name  :  JoinSourceMakerCodeBegin
        /// <summary>結合元メーカーコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元メーカーコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinSourceMakerCodeBeginRF
        {
            get { return _joinSourceMakerCodeBegin; }
            set { _joinSourceMakerCodeBegin = value; }
        }

        /// public propaty name  :  JoinSourceMakerCodeEnd
        /// <summary>結合元メーカーコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元メーカーコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinSourceMakerCodeEndRF
        {
            get { return _joinSourceMakerCodeEnd; }
            set { _joinSourceMakerCodeEnd = value; }
        }

        /// public propaty name  :  JoinDispOrderBegin
        /// <summary>結合表示順位(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合表示順位(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDispOrderBeginRF
        {
            get { return _joinDispOrderBegin; }
            set { _joinDispOrderBegin = value; }
        }

        /// public propaty name  :  JoinDispOrderEnd
        /// <summary>結合表示順位(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合表示順位(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDispOrderEndRF
        {
            get { return _joinDispOrderEnd; }
            set { _joinDispOrderEnd = value; }
        }

        /// public propaty name  :  JoinDestMakerCodeBegin
        /// <summary>結合先メーカーコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先メーカーコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDestMakerCodeBeginRF
        {
            get { return _joinDestMakerCodeBegin; }
            set { _joinDestMakerCodeBegin = value; }
        }

        /// public propaty name  :  JoinDestMakerCodeEnd
        /// <summary>結合先メーカーコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先メーカーコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDestMakerCodeEndRF
        {
            get { return _joinDestMakerCodeEnd; }
            set { _joinDestMakerCodeEnd = value; }
        }


        /// <summary>
        /// 結合マスタ抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>JoinPartsUProcParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsUProcParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public APJoinPartsUProcParamWork()
        {
        }

    }
}