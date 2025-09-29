using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
 	/// public class name:   SCMAnsHistOrderWork
	/// <summary>
	///                      SCM売上・回答履歴照会抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM売上・回答履歴照会抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :    2009/4/13</br>
	/// <br>Genarated Date   :   2009/06/02  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAnsHistOrderWork
	{
		/// <summary>問合せ先企業コード</summary>
		private string _inqOtherEpCd = "";

		/// <summary>回答区分</summary>
		/// <remarks>0:アクションなし 1:回答中 10:一部回答 20:回答完了 30:承認 99:キャンセル</remarks>
		private Int32[] _answerDivCd;

		/// <summary>開始問合せ日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _st_InquiryDate;

		/// <summary>終了問合せ日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _ed_InquiryDate;

		/// <summary>問合せ先拠点コード</summary>
		private string _inqOtherSecCd = "";

		/// <summary>開始得意先コード</summary>
		private Int32 _st_CustomerCode;

		/// <summary>終了得意先コード</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>回答方法</summary>
		private Int32[] _awnserMethod;

		/// <summary>受注ステータス</summary>
		/// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
		private Int32[] _acptAnOdrStatus;

		/// <summary>開始売上伝票番号</summary>
		/// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
		private string _st_SalesSlipNum = "";

		/// <summary>終了売上伝票番号</summary>
		/// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
		private string _ed_SalesSlipNum = "";

		/// <summary>開始問合せ番号</summary>
		private Int64 _st_InquiryNumber;

		/// <summary>終了問合せ番号</summary>
		private Int64 _ed_InquiryNumber;

		/// <summary>車両登録番号（プレート番号）</summary>
		private Int32 _numberPlate4;

		/// <summary>型式（フル型）</summary>
		/// <remarks>フル型式(44桁用)</remarks>
		private string _fullModel = "";

		/// <summary>車種コード</summary>
		/// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _modelCode;

		/// <summary>車種サブコード</summary>
		/// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
		private Int32 _modelSubCode;

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>純正商品番号</summary>
		private string _pureGoodsNo = "";

		/// <summary>問合せ・発注種別</summary>
		/// <remarks>1:問合せ 2:発注</remarks>
		private Int32[] _inqOrdDivCd;

        /// <summary>メーカーコード(車両情報)</summary>
        private Int32 _carMakerCode;

        /// <summary>検索タイプ（型式）</summary>
        /// <remarks>1:前方一致 2:後方一致 3:曖昧検索</remarks>
        private Int32 _serchTypeModelCd;

        /// <summary>検索タイプ（商品番号）</summary>
        /// <remarks>1:前方一致 2:後方一致 3:曖昧検索</remarks>
        private Int32 _serchTypeGoodsNo;

        /// <summary>検索タイプ（純正商品番号）</summary>
        /// <remarks>1:前方一致 2:後方一致 3:曖昧検索</remarks>
        private Int32 _serchTypePureGoodsNo;



		/// public propaty name  :  InqOtherEpCd
		/// <summary>問合せ先企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ先企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOtherEpCd
		{
			get{return _inqOtherEpCd;}
			set{_inqOtherEpCd = value;}
		}

		/// public propaty name  :  AnswerDivCd
		/// <summary>回答区分プロパティ</summary>
		/// <value>0:アクションなし 1:回答中 10:一部回答 20:回答完了 30:承認 99:キャンセル</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] AnswerDivCd
		{
			get{return _answerDivCd;}
			set{_answerDivCd = value;}
		}

		/// public propaty name  :  St_InquiryDate
		/// <summary>開始問合せ日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始問合せ日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_InquiryDate
		{
			get{return _st_InquiryDate;}
			set{_st_InquiryDate = value;}
		}

		/// public propaty name  :  Ed_InquiryDate
		/// <summary>終了問合せ日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了問合せ日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_InquiryDate
		{
			get{return _ed_InquiryDate;}
			set{_ed_InquiryDate = value;}
		}

		/// public propaty name  :  InqOtherSecCd
		/// <summary>問合せ先拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ先拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOtherSecCd
		{
			get{return _inqOtherSecCd;}
			set{_inqOtherSecCd = value;}
		}

		/// public propaty name  :  St_CustomerCode
		/// <summary>開始得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get{return _st_CustomerCode;}
			set{_st_CustomerCode = value;}
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>終了得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get{return _ed_CustomerCode;}
			set{_ed_CustomerCode = value;}
		}

		/// public propaty name  :  AwnserMethod
		/// <summary>回答方法プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] AwnserMethod
		{
			get{return _awnserMethod;}
			set{_awnserMethod = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>受注ステータスプロパティ</summary>
		/// <value>10:見積,20:受注,30:売上,40:出荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  St_SalesSlipNum
		/// <summary>開始売上伝票番号プロパティ</summary>
		/// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_SalesSlipNum
		{
			get{return _st_SalesSlipNum;}
			set{_st_SalesSlipNum = value;}
		}

		/// public propaty name  :  Ed_SalesSlipNum
		/// <summary>終了売上伝票番号プロパティ</summary>
		/// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_SalesSlipNum
		{
			get{return _ed_SalesSlipNum;}
			set{_ed_SalesSlipNum = value;}
		}

		/// public propaty name  :  St_InquiryNumber
		/// <summary>開始問合せ番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始問合せ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 St_InquiryNumber
		{
			get{return _st_InquiryNumber;}
			set{_st_InquiryNumber = value;}
		}

		/// public propaty name  :  Ed_InquiryNumber
		/// <summary>終了問合せ番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了問合せ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 Ed_InquiryNumber
		{
			get{return _ed_InquiryNumber;}
			set{_ed_InquiryNumber = value;}
		}

		/// public propaty name  :  NumberPlate4
		/// <summary>車両登録番号（プレート番号）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両登録番号（プレート番号）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NumberPlate4
		{
			get{return _numberPlate4;}
			set{_numberPlate4 = value;}
		}

		/// public propaty name  :  FullModel
		/// <summary>型式（フル型）プロパティ</summary>
		/// <value>フル型式(44桁用)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   型式（フル型）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FullModel
		{
			get{return _fullModel;}
			set{_fullModel = value;}
		}

		/// public propaty name  :  ModelCode
		/// <summary>車種コードプロパティ</summary>
		/// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelCode
		{
			get{return _modelCode;}
			set{_modelCode = value;}
		}

		/// public propaty name  :  ModelSubCode
		/// <summary>車種サブコードプロパティ</summary>
		/// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種サブコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelSubCode
		{
			get{return _modelSubCode;}
			set{_modelSubCode = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL商品コードプロパティ</summary>
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

		/// public propaty name  :  GoodsNo
		/// <summary>商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  PureGoodsNo
		/// <summary>純正商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   純正商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PureGoodsNo
		{
			get{return _pureGoodsNo;}
			set{_pureGoodsNo = value;}
		}

		/// public propaty name  :  InqOrdDivCd
		/// <summary>問合せ・発注種別プロパティ</summary>
		/// <value>1:問合せ 2:発注</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ・発注種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32[] InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
		}

        /// public propaty name  :  CarMakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カーメーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMakerCode
        {
            get { return _carMakerCode; }
            set { _carMakerCode = value; }
        }

        /// public propaty name  :  SerchTypeModelCd
        /// <summary>検索タイプ（型式）プロパティ</summary>
        /// <value>1:前方一致 2:後方一致 3:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タイプ（型式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SerchTypeModelCd
        {
            get { return _serchTypeModelCd; }
            set { _serchTypeModelCd = value; }
        }

        /// public propaty name  :  SerchTypeGoodsNo
        /// <summary>検索タイプ（商品番号）プロパティ</summary>
        /// <value>1:前方一致 2:後方一致 3:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タイプ（商品番号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SerchTypeGoodsNo
        {
            get { return _serchTypeGoodsNo; }
            set { _serchTypeGoodsNo = value; }
        }

        /// public propaty name  :  SerchTypePureGoodsNo
        /// <summary>検索タイプ（純正商品番号）プロパティ</summary>
        /// <value>1:前方一致 2:後方一致 3:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タイプ（純正商品番号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SerchTypePureGoodsNo
        {
            get { return _serchTypePureGoodsNo; }
            set { _serchTypePureGoodsNo = value; }
        }


		/// <summary>
		/// SCM売上・回答履歴照会抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>SCMAnsHistOrderWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsHistOrderWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAnsHistOrderWork()
		{
		}

	}
}




