using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 変更案内監視アプリケーション構成情報クラス
	/// </summary>
	public class ChangeInfoCheckAppConfig
	{
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public ChangeInfoCheckAppConfig() { }

		/// <summary>WebサービスURL</summary>
		private string _webServiceURL;
		/// <summary>チェック間隔(min)</summary>
		private int _checkTimeSpan;
		/// <summary>変更案内TOPページURL</summary>
		private string _webTopPageURL;

		/// <summary>WebサービスURL</summary>
		public string WebServiceURL
		{
			get { return _webServiceURL; }
			set { _webServiceURL = value; }
		}

		/// <summary>チェック間隔(min)</summary>
		public int CheckTimeSpan
		{
			get { return _checkTimeSpan; }
			set { _checkTimeSpan = value; }
		}

		/// <summary>変更案内TOPページURL</summary>
		public string WebTopPageURL
		{
			get { return _webTopPageURL; }
			set { _webTopPageURL = value; }
		}
	}


	/// <summary>
	/// 変更案内通知 最新変更データ情報シリアライズ用クラス
	/// </summary>
	public class LatestChangeInfoData
	{
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public LatestChangeInfoData() { }

		/// <summary>パッケージ区分</summary>
		private string _productCode;

		/// <summary>定期メンテナンス サーバーメンテナンス連番</summary>
		private int _nmlServerMainteConsNo;

		/// <summary>緊急メンテナンス サーバーメンテナンス連番</summary>
		private int _emgServerMainteConsNo;

		/// <summary>データメンテナンス サーバーメンテナンス連番</summary>
		private int _datServerMainteConsNo;
        
        /// <summary>配信バージョン</summary>
		private string _multicastVersion;

		/// <summary>印字位置リリース 連番</summary>
		private int _printPositionConsNo;

		/// <summary>パッケージ区分</summary>
		public string ProductCode
		{
			get { return _productCode; }
			set { _productCode = value; }
		}

		/// <summary>定期メンテナンス サーバーメンテナンス連番</summary>
		public int NmlServerMainteConsNo
		{
			get { return _nmlServerMainteConsNo; }
			set { _nmlServerMainteConsNo = value; }
		}

		/// <summary>緊急メンテナンス サーバーメンテナンス連番</summary>
		public int EmgServerMainteConsNo
		{
			get { return _emgServerMainteConsNo; }
			set { _emgServerMainteConsNo = value; }
		}

		/// <summary>データメンテナンス サーバーメンテナンス連番</summary>
		public int DatServerMainteConsNo
		{
			get { return _datServerMainteConsNo; }
			set { _datServerMainteConsNo = value; }
		}

		/// <summary>配信バージョン</summary>
		public string MulticastVersion
		{
			get { return _multicastVersion; }
			set { _multicastVersion = value; }
		}

		/// <summary>印字位置リリース 連番</summary>
		public int PrintPositionConsNo
		{
			get { return _printPositionConsNo; }
			set { _printPositionConsNo = value; }
		}
    
    
    }
}
