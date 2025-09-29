//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカーマスタ（エクスポート）（エクスポート）
// プログラム概要   : メーカーマスタ（エクスポート）のｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MakerSetExp
    /// <summary>
    ///                      メーカーマスタ（エクスポート）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   メーカーマスタ（エクスポート）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class MakerSetExp
    {
        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>メーカー略称</summary>
        private string _makerShortName = "";

        /// <summary>メーカーカナ名称</summary>
        private string _makerKanaName = "";

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;


        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  MakerShortName
        /// <summary>メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
        }

        /// public propaty name  :  MakerKanaName
        /// <summary>メーカーカナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerKanaName
        {
            get { return _makerKanaName; }
            set { _makerKanaName = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// <summary>
        /// メーカー（エクスポート）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MakerSetExp Clone()
        {
            return new MakerSetExp(this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._displayOrder);

        }

        /// <summary>
        /// メーカー（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>EmployeeSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MakerSetExp()
        {
        }

        /// <summary>
        /// メーカー（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="GoodsMakerCd"></param>
        /// <param name="MakerName"></param>
        /// <param name="MakerShortName"></param>
        /// <param name="MakerKanaName"></param>
        /// <param name="DisplayOrder"></param>
        public MakerSetExp(Int32 GoodsMakerCd, string MakerName, string MakerShortName, string MakerKanaName, Int32 DisplayOrder)
        {

            this._goodsMakerCd = GoodsMakerCd;
            this._makerName = MakerName;
            this._makerShortName = MakerShortName;
            this._makerKanaName = MakerKanaName;
            this._displayOrder = DisplayOrder;
        }
    }
}
