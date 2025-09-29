//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＴＢＯ検索マスタ（エクスポート）
// プログラム概要   : ＴＢＯ検索マスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   TBOSearchSetExp
    /// <summary>
    ///                      TBO検索マスタ（ユーザー登録）
    /// </summary>
    /// <remarks>
    /// <br>note             :   TBO検索マスタ（ユーザー登録）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2006/12/6</br>
    /// <br>Genarated Date   :   2009/05/14  (CSharp File Generated Date)</br>
    /// </remarks>
    public class TBOSearchSetExp 
    {
		/// <summary>BL商品コード</summary>
		/// <remarks>提供:1～9999 ユーザー:10000～</remarks>
		private Int32 _bLGoodsCode;

		/// <summary>装備分類</summary>
		/// <remarks>例）1001：バッテリ</remarks>
		private Int32 _equipGenreCode;

		/// <summary>装備名称</summary>
		/// <remarks>例）100D26L（バッテリ規格）</remarks>
		private string _equipName = "";

		/// <summary>車両結合表示順位</summary>
		/// <remarks>4,5,6,7,8が同一の結合が複数存在する場合の連番</remarks>
		private Int32 _carInfoJoinDispOrder;

		/// <summary>結合先メーカーコード</summary>
		private Int32 _joinDestMakerCd;

		/// <summary>結合先品番(－付き品番)</summary>
		/// <remarks>ハイフン付き</remarks>
		private string _joinDestPartsNo = "";

		/// <summary>結合ＱＴＹ</summary>
		private Double _joinQty;

		/// <summary>装備規格・特記事項</summary>
		private string _equipSpecialNote = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL商品コードプロパティ</summary>
		/// <value>提供:1～9999 ユーザー:10000～</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  EquipGenreCode
		/// <summary>装備分類プロパティ</summary>
		/// <value>例）1001：バッテリ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備分類プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EquipGenreCode
		{
			get{return _equipGenreCode;}
			set{_equipGenreCode = value;}
		}

		/// public propaty name  :  EquipName
		/// <summary>装備名称プロパティ</summary>
		/// <value>例）100D26L（バッテリ規格）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EquipName
		{
			get{return _equipName;}
			set{_equipName = value;}
		}

		/// public propaty name  :  CarInfoJoinDispOrder
		/// <summary>車両結合表示順位プロパティ</summary>
		/// <value>4,5,6,7,8が同一の結合が複数存在する場合の連番</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両結合表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CarInfoJoinDispOrder
		{
			get{return _carInfoJoinDispOrder;}
			set{_carInfoJoinDispOrder = value;}
		}

		/// public propaty name  :  JoinDestMakerCd
		/// <summary>結合先メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合先メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JoinDestMakerCd
		{
			get{return _joinDestMakerCd;}
			set{_joinDestMakerCd = value;}
		}

		/// public propaty name  :  JoinDestPartsNo
		/// <summary>結合先品番(－付き品番)プロパティ</summary>
		/// <value>ハイフン付き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合先品番(－付き品番)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JoinDestPartsNo
		{
			get{return _joinDestPartsNo;}
			set{_joinDestPartsNo = value;}
		}

		/// public propaty name  :  JoinQty
		/// <summary>結合ＱＴＹプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合ＱＴＹプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double JoinQty
		{
			get{return _joinQty;}
			set{_joinQty = value;}
		}

		/// public propaty name  :  EquipSpecialNote
		/// <summary>装備規格・特記事項プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備規格・特記事項プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EquipSpecialNote
		{
			get{return _equipSpecialNote;}
			set{_equipSpecialNote = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  UpdEmployeeName
		/// <summary>更新従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}

		/// <summary>
		/// TBO検索マスタ（ユーザー登録）コンストラクタ
		/// </summary>
		/// <param name="bLGoodsCode">BL商品コード(提供:1～9999 ユーザー:10000～)</param>
		/// <param name="equipGenreCode">装備分類(例）1001：バッテリ)</param>
		/// <param name="equipName">装備名称(例）100D26L（バッテリ規格）)</param>
		/// <param name="carInfoJoinDispOrder">車両結合表示順位(4,5,6,7,8が同一の結合が複数存在する場合の連番)</param>
		/// <param name="joinDestMakerCd">結合先メーカーコード</param>
		/// <param name="joinDestPartsNo">結合先品番(－付き品番)(ハイフン付き)</param>
		/// <param name="joinQty">結合ＱＴＹ</param>
		/// <param name="equipSpecialNote">装備規格・特記事項</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>TBOSearchUクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TBOSearchUクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public TBOSearchSetExp(Int32 bLGoodsCode,Int32 equipGenreCode,string equipName,Int32 carInfoJoinDispOrder,Int32 joinDestMakerCd,string joinDestPartsNo,Double joinQty,string equipSpecialNote,string enterpriseName,string updEmployeeName)
		{
			this._bLGoodsCode = bLGoodsCode;
			this._equipGenreCode = equipGenreCode;
			this._equipName = equipName;
			this._carInfoJoinDispOrder = carInfoJoinDispOrder;
			this._joinDestMakerCd = joinDestMakerCd;
			this._joinDestPartsNo = joinDestPartsNo;
			this._joinQty = joinQty;
			this._equipSpecialNote = equipSpecialNote;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// TBO検索マスタ（ユーザー登録）複製処理
		/// </summary>
		/// <returns>TBOSearchUクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいTBOSearchUクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public TBOSearchSetExp Clone()
		{
			return new TBOSearchSetExp(this._bLGoodsCode,this._equipGenreCode,this._equipName,this._carInfoJoinDispOrder,this._joinDestMakerCd,this._joinDestPartsNo,this._joinQty,this._equipSpecialNote,this._enterpriseName,this._updEmployeeName);
		}

        /// <summary>
        /// TBO検索マスタ（ユーザー登録）データクラスワークコンストラクタ
		/// </summary>
        /// <returns>TBOSearchSetExpクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public TBOSearchSetExp()
		{
		}
    }
}
