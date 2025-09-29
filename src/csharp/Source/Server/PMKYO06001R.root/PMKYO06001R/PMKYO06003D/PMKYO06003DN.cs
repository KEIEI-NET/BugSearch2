using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   UserGdBuyDivUProcParamWork
    /// <summary>
    ///                      ユーザーガイドマスタ(販売区分)抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ユーザーガイドマスタ(販売区分)抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/05/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APUserGdBuyDivUProcParamWork
    {
        /// <summary>開始日時</summary>
        private Int64 _beginningDate;

        /// <summary>終了日時</summary>
        private Int64 _endingDate;

        /// <summary>ガイドコード(開始)</summary>
        private Int32 _guideCodeBegin;

        /// <summary>ガイドコード(終了)</summary>
        private Int32 _guideCodeEnd;


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

        /// public propaty name  :  GuideCodeBegin
        /// <summary>ガイドコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ガイドコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GuideCodeBeginRF
        {
            get { return _guideCodeBegin; }
            set { _guideCodeBegin = value; }
        }

        /// public propaty name  :  GuideCodeEnd
        /// <summary>ガイドコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ガイドコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GuideCodeEndRF
        {
            get { return _guideCodeEnd; }
            set { _guideCodeEnd = value; }
        }


        /// <summary>
        /// ユーザーガイドマスタ(販売区分)抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>UserGdBuyDivUProcParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UserGdBuyDivUProcParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public APUserGdBuyDivUProcParamWork()
        {
        }

    }
}