using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
	
namespace Broadleaf.Application.Remoting.ParamData
{	
	/// <summary>
	/// 優良部品取得パラメータ
	/// </summary>
	[Serializable]
	public class GetPrimePartsInfPara
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
        public GetPrimePartsInfPara()
		{
		}

        /// <summary>ハイフン付最新部品品番</summary>
        private string [] _PrtsNoWithHyphen;

        /// <summary>ハイフン無最新部品品番</summary>
        private string _PrtsNoNoneHyphen;

        /// <summary>部品メーカー</summary>
        private int _PartsMakerCode;

		/// <summary>メーカーコード</summary>
		private int [] _MakerCode;

        /// <summary>セット検索フラグ</summary>
        private int _setSearchFlg;

        /// <summary>商品番号検索区分</summary>
        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
        private int _SrchTyp;

        /// <summary>商品番号検索区分</summary>
        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
        public int SearchType
        {
            get { return _SrchTyp; }
            set { _SrchTyp = value; }
        }

        /// ハイフン付最新部品品番
        public string [] PrtsNoWithHyphen
        {
            get { return this._PrtsNoWithHyphen; }
            set { this._PrtsNoWithHyphen = value; }
        }
        /// ハイフン無最新部品品番
        public string PrtsNoNoneHyphen
        {
            get { return this._PrtsNoNoneHyphen; }
            set { this._PrtsNoNoneHyphen = value; }
        }

        /// 部品メーカー
		public int PartsMakerCode
		{
			get{return this._PartsMakerCode;}
			set{this._PartsMakerCode = value;}
		}

		/// メーカーコード
		public int [] MakerCode
		{
			get { return this._MakerCode; }
			set { this._MakerCode = value; }
		}

        /// <summary>セット検索フラグ</summary>
        public int SetSearchFlg
        {
            get { return _setSearchFlg; }
            set { _setSearchFlg = value; }
        }
	}
}
