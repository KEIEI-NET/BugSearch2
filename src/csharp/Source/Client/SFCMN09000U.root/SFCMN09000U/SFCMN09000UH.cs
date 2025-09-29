using System;
using System.IO;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// マスタメンテナンスフレーム用マスタメンテナンス設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 各マスタメンテナンス固有の設定情報を管理するクラスです。</br>
	/// <br>Programmer : 980076 妻鳥　謙一郎</br>
	/// <br>Date       : 2004.03.19</br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class MasterMaintenanceConstruction
	{
		# region Private Members
		private ExtractionSetUpType _extractionSetUpType;
		private int _searchCount;
		private string _classID;

		private const int DEFAULT_SEARCH_COUNT = 0; 
		# endregion

		# region Constructors
		/// <summary>
		/// マスタメンテナンス設定クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 一覧表示フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public MasterMaintenanceConstruction(string classID)
		{
			this._classID = classID;
			this._extractionSetUpType = ExtractionSetUpType.SearchAuto;
			this._searchCount = DEFAULT_SEARCH_COUNT;
		}

		/// <summary>
		/// マスタメンテナンス設定クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 一覧表示フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public MasterMaintenanceConstruction()
		{
			this._classID = "";
			this._extractionSetUpType = ExtractionSetUpType.SearchAuto;
			this._searchCount = DEFAULT_SEARCH_COUNT;
		}
		# endregion

		# region Properties
		/// <summary>抽出設定値プロパティ</summary>
		/// <value>抽出設定値を取得または設定します。</value>
		public ExtractionSetUpType ExSetUpType
		{
			get{ return this._extractionSetUpType; }
			set{ this._extractionSetUpType = value; }
		}

		/// <summary>抽出対象件数プロパティ</summary>
		/// <value>抽出対象件数を取得または設定します。</value>
		public int SearchCount
		{
			get{ return this._searchCount; }
			set{ this._searchCount = value; }
		}

		/// <summary>クラスＩＤプロパティ</summary>
		/// <value>クラスＩＤを取得または設定します。</value>
		public string ClassID
		{
			get{ return this._classID; }
			set{ this._classID = value; }
		}
		# endregion

		# region Public Methods
		/// <summary>
		/// ToStringのオーバーライド
		/// </summary>
		/// <remarks>
		/// <br>Note       : クラスＩＤを返します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public override string ToString()
		{
			return this._classID;
		}
		# endregion
	}

	# region enum ExtractionSetUpType
	/// <summary>抽出方法設定の列挙型です。</summary>
	public enum ExtractionSetUpType
	{
		/// <summary>全件自動抽出</summary>
		SearchAuto = 0,

		/// <summary>件数指定抽出</summary>
		SearchSpecification = 1,
	}
	# endregion
}
