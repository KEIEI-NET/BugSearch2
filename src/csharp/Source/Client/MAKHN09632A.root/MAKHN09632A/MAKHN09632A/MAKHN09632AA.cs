using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Drawing;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Globarization;
// 2008.02.08 96012 ローカルＤＢ参照対応 Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.08 96012 ローカルＤＢ参照対応 end

namespace Broadleaf.Application.Controller
{
	/// <summary>
    ///画像情報マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 画像情報マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 22022 段上 知子</br>
    /// <br>Date       : 2007.05.16</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
    /// <br>           : ローカルＤＢ参照対応</br>
    /// <br>UpdateNote : 2008/10/29 　     照田 貴志</br>
    /// <br>           : バグ修正、仕様変更対応</br>
    /// </remarks>
	public class ImageInfoAcs
	{
		// --------------------------------------------------
		#region Private Members

        // 企業コード
        private string          _enterpriseCode = "";

        /// <summary>画像情報マスタリモートオブジェクト格納バッファ</summary>
        private IImageInfoDB    _iImageInfoDB   = null;
        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        private ImageInfoLcDB _imageInfoLcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 ローカルＤＢ参照対応 end

        // データセット
        private DataSet         _bindDataSet    = null;
        private DataTable       _imageInfoTable = null;

        // マスタクラス格納リスト
        private Dictionary<Guid, ImageInfoWork>  _imageInfoDic   = null;    // 画像情報マスタ格納用

        // マスタ取得用リスト
        private ArrayList       _imageInfoList  = null;                     // 画像情報マスタ取得用

        #endregion

        // --------------------------------------------------
        #region Public Members

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        public static readonly string TBL_IMAGEINFO_TITLE           = "IMAGEINFO_TABLE";
        public static readonly string COL_DELETEDATE_TITLE          = "削除日";
        public static readonly string COL_IMAGEINFODIVCODE_TITLE    = "画像情報区分コード";
        public static readonly string COL_IMAGEINFODIVNAME_TITLE    = "画像情報区分";
        public static readonly string COL_IMAGEINFOCODE_TITLE       = "画像情報コード";
        //public static readonly string COL_IMAGEINFONAME_TITLE       = "画像情報表示名称";             //DEL 2008/10/29 名称変更
        public static readonly string COL_IMAGEINFONAME_TITLE       = "画像情報表示名";                 //ADD 2008/10/29
        public static readonly string COL_IMAGEINFOFLTYPE_TITLE     = "画像情報ファイルタイプ";
        public static readonly string COL_IMAGEINFODATA_TITLE       = "画像情報データ";
        public static readonly string COL_GUID_TITLE                = "GUID";

        #endregion

        // --------------------------------------------------
		#region Constructor

		/// <summary>
        ///画像情報マスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 画像情報マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		public ImageInfoAcs()
		{
			try {
				// 企業コード取得
				this._enterpriseCode    = LoginInfoAcquisition.EnterpriseCode;

				// リモートオブジェクト取得
                this._iImageInfoDB      = (IImageInfoDB)MediationImageInfoDB.GetImageInfoDB();

                // マスタクラス格納リスト初期化
                this._imageInfoDic = new Dictionary<Guid, ImageInfoWork>();

                // マスタ取得用リスト初期化
                this._imageInfoList = new ArrayList();

                // データセット初期化
                this._bindDataSet = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // データセット列情報構築
                this.DataSetColumnConstruction();
			}
			catch( Exception ) {
				// オフライン時はnullをセット
                this._iImageInfoDB = null;
			}
            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            // ローカルDBアクセスオブジェクト取得
            this._imageInfoLcDB = new ImageInfoLcDB();
            // 2008.02.08 96012 ローカルＤＢ参照対応 end
        }

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			// 画像情報テーブル
			this._imageInfoTable = new DataTable( TBL_IMAGEINFO_TITLE );

			// Addを行う順番が、列の表示順位となります。
			this._imageInfoTable.Columns.Add( COL_DELETEDATE_TITLE          , typeof( string ) );   // 削除日
			this._imageInfoTable.Columns.Add( COL_IMAGEINFODIVCODE_TITLE    , typeof( int    ) );   // 画像情報区分コード
			this._imageInfoTable.Columns.Add( COL_IMAGEINFODIVNAME_TITLE    , typeof( string ) );   // 画像情報区分名称
            //this._imageInfoTable.Columns.Add( COL_IMAGEINFOCODE_TITLE       , typeof( int    ) );   // 画像情報コード     //DEL 2008/10/29 0詰めの為
            this._imageInfoTable.Columns.Add(COL_IMAGEINFOCODE_TITLE        , typeof( string ) );   // 画像情報コード       //ADD 2008/10/29
            this._imageInfoTable.Columns.Add(COL_IMAGEINFONAME_TITLE        , typeof( string ) );   // 画像情報表示名称
			this._imageInfoTable.Columns.Add( COL_IMAGEINFOFLTYPE_TITLE     , typeof( string ) );   // 画像情報ファイルタイプ
			this._imageInfoTable.Columns.Add( COL_IMAGEINFODATA_TITLE       , typeof( Byte[] ) );   // 画像情報データ
            this._imageInfoTable.Columns.Add( COL_GUID_TITLE                , typeof( Guid   ) );   // GUID

            // PrimaryKey設定
            this._imageInfoTable.PrimaryKey = new DataColumn[] { this._imageInfoTable.Columns[COL_IMAGEINFODIVCODE_TITLE],      // 画像情報区分コード
                                                                 this._imageInfoTable.Columns[COL_IMAGEINFOCODE_TITLE]     };   // 画像情報コード

            this._bindDataSet.Tables.Add(this._imageInfoTable);
		}

		#endregion

        // --------------------------------------------------
        #region Properties

        /// <summary>データセットプロパティ</summary>
        /// <value>データセットを取得します。</value>
        public DataSet BindDataSet
        {
            get
            {
                return this._bindDataSet;
            }
        }

        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.08 96012 ローカルＤＢ参照対応 end
        #endregion

		// --------------------------------------------------
		#region GetOnlineMode

		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードの取得を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			// オンラインモードを取得
			if( this._iImageInfoDB == null ) {
				// オフライン
				return ( int )ConstantManagement.OnlineMode.Offline;
			}
			else {
				// オンライン
				return ( int )ConstantManagement.OnlineMode.Online;
			}
		}

		#endregion

		// --------------------------------------------------
		#region Read Methods

		/// <summary>
        ///読み込み処理
		/// </summary>
        /// <param name="imageInfo">画像情報マスタオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="imageInfoDiv">画像情報区分</param>
        /// <param name="imageInfoCode">画像情報コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の読み込み処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        public int Read(out ImageInfo imageInfo, string enterpriseCode, int imageInfoDiv, int imageInfoCode)
		{
            return this.ReadProc(out imageInfo, enterpriseCode, imageInfoDiv, imageInfoCode);
		}

		/// <summary>
        ///画像情報マスタ読み込み処理
		/// </summary>
        /// <param name="imageInfo">画像情報マスタオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="imageInfoDiv">画像情報区分</param>
        /// <param name="imageInfoCode">画像情報コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 画像情報マスタの読み込み処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        private int ReadProc(out ImageInfo imageInfo, string enterpriseCode, int imageInfoDiv, int imageInfoCode)
		{
            int status = 0;
            imageInfo = null;

            try
            {
                ImageInfoWork imageInfoWork = new ImageInfoWork();

                // 取得済みデータが存在する場合
                if (this._imageInfoDic.Count > 0)
                {
                    // 対象データが取得済みの場合
                    // 2009.03.25 30413 犬飼 フィルタの設定を修正 >>>>>>START
                    //string selectCommand1 = COL_IMAGEINFODIVCODE_TITLE + " = '" + imageInfoDiv + "' and " +
                    //                        COL_IMAGEINFOCODE_TITLE + " = '" + imageInfoCode + "'";
                    string selectCommand1 = COL_IMAGEINFODIVCODE_TITLE + " = '" + imageInfoDiv + "' and " +
                                            COL_IMAGEINFOCODE_TITLE + " = " + imageInfoCode;
                    // 2009.03.25 30413 犬飼 フィルタの設定を修正 <<<<<<END
                    string sortCommand1 = COL_IMAGEINFODIVCODE_TITLE + " ASC , " + COL_IMAGEINFOCODE_TITLE + " ASC";
                    DataRow[] dr = this._imageInfoTable.Select(selectCommand1, sortCommand1);
                    if (dr.Length > 0)
                    {
                        imageInfoWork = (this._imageInfoDic[(Guid)dr[0][COL_GUID_TITLE]] as ImageInfoWork);
                        imageInfo = this.CopyToImageInfoFromImageInfoWork(imageInfoWork);
                        return status;
                    }
                }

                // キー情報をセット
                imageInfoWork.EnterpriseCode = enterpriseCode;  // 企業コード
                imageInfoWork.ImageInfoDiv = imageInfoDiv;      // 画像情報区分
                imageInfoWork.ImageInfoCode = imageInfoCode;    // 画像情報コード

                // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
                //// XMLへ変換し、文字列のバイナリ化
                //byte[] parabyte = XmlByteSerializer.Serialize(imageInfoWork);
                //
                ////画像情報マスタ読み込み
                //status = this._iImageInfoDB.Read(ref parabyte, 0);
                //
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    // デシリアライズ処理
                //    imageInfoWork = (ImageInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(ImageInfoWork));
                //
                //    // 結果をメンバコピー
                //    imageInfo = this.CopyToImageInfoFromImageInfoWork(imageInfoWork);
                //}
                if (_isLocalDBRead)
                {
                    //画像情報マスタ読み込み
                    status = this._imageInfoLcDB.Read(ref imageInfoWork, 0);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 結果をメンバコピー
                        imageInfo = this.CopyToImageInfoFromImageInfoWork(imageInfoWork);
                    }
                }
                else
                {
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] parabyte = XmlByteSerializer.Serialize(imageInfoWork);
                    //画像情報マスタ読み込み
                    status = this._iImageInfoDB.Read(ref parabyte, 0);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // デシリアライズ処理
                        imageInfoWork = (ImageInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(ImageInfoWork));
                        // 結果をメンバコピー
                        imageInfo = this.CopyToImageInfoFromImageInfoWork(imageInfoWork);
                    }
                }
                // 2008.02.08 96012 ローカルＤＢ参照対応 end
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                imageInfo = null;
                this._iImageInfoDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region Write Methods

		/// <summary>
        ///書き込み処理
		/// </summary>
        /// <param name="imageInfo">画像情報マスタオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        public int Write(ImageInfo imageInfo)
        {
            // 画像情報マスタ更新
            return this.WriteProc(imageInfo);
        }

		/// <summary>
        ///画像情報マスタ書き込み処理
		/// </summary>
        /// <param name="imageInfo">画像情報マスタオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 画像情報マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private int WriteProc(ImageInfo imageInfo)
		{
			int status = 0;

			try {
                ImageInfoWork imageInfoWork = new ImageInfoWork();

                // 編集前情報取得
                if (this._imageInfoDic.ContainsKey(imageInfo.FileHeaderGuid) == true)
                {
                    imageInfoWork = (this._imageInfoDic[imageInfo.FileHeaderGuid] as ImageInfoWork);
                }

                // 編集情報取得
                CopyToImageInfoWorkFromImageInfo(ref imageInfoWork, imageInfo);

                object retObj = (object)imageInfoWork;

                //画像情報マスタ書き込み
                status = this._iImageInfoDB.Write(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // データセットに追加
                    ArrayList retArray = new ArrayList();
                    retArray = (ArrayList)retObj;
                    imageInfoWork = (ImageInfoWork)retArray[0];
                    this.ImageInfoWorkToDataSet(imageInfoWork);
				}
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iImageInfoDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region LogicalDelete Methods

		/// <summary>
        ///論理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">画像情報マスタGuid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の論理削除処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        public int LogicalDelete(Guid fileHeaderGuid)
        {
            // 画像情報マスタ論理削除
            return this.LogicalDeleteProc(fileHeaderGuid);
        }

		/// <summary>
        ///画像情報マスタ論理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">画像情報マスタGuid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 画像情報マスタの論理削除処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private int LogicalDeleteProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // 編集前情報取得
                ImageInfoWork imageInfoWork = (this._imageInfoDic[fileHeaderGuid] as ImageInfoWork);

                object retObj = (object)imageInfoWork;

                //画像情報マスタ論理削除
                status = this._iImageInfoDB.LogicalDelete(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // データセットに追加
                    imageInfoWork = (ImageInfoWork)retObj;
                    this.ImageInfoWorkToDataSet(imageInfoWork);
				}
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iImageInfoDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
        }

		#endregion

		// --------------------------------------------------
		#region Revival Methods

		/// <summary>
        ///論理削除復活処理
        /// </summary>
        /// <param name="fileHeaderGuid">画像情報マスタGuid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の論理削除復活処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        public int Revival(Guid fileHeaderGuid)
        {
            // 画像情報マスタ復活
            return this.RevivalProc(fileHeaderGuid);
        }

		/// <summary>
        ///画像情報マスタ論理削除復活処理
        /// </summary>
        /// <param name="fileHeaderGuid">画像情報マスタGuid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 画像情報マスタの論理削除復活処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private int RevivalProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // 編集前情報取得
                ImageInfoWork imageInfoWork = (this._imageInfoDic[fileHeaderGuid] as ImageInfoWork);

                object retObj = (object)imageInfoWork;

                //画像情報マスタ論理削除復活
                status = this._iImageInfoDB.RevivalLogicalDelete(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // データセットに追加
                    imageInfoWork = (ImageInfoWork)retObj;
                    this.ImageInfoWorkToDataSet(imageInfoWork);
				}
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iImageInfoDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region Delete Methods

		/// <summary>
        ///物理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">画像情報マスタGuid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の物理削除処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        public int Delete(Guid fileHeaderGuid)
        {
            // 画像情報マスタ物理削除
            return this.DeleteProc(fileHeaderGuid);
        }

		/// <summary>
        ///画像情報マスタ物理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">画像情報マスタGuid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 画像情報マスタの物理削除処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private int DeleteProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // 編集前情報取得
                ImageInfoWork imageInfoWork = (this._imageInfoDic[fileHeaderGuid] as ImageInfoWork);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(imageInfoWork);

                //画像情報マスタ物理削除
                status = this._iImageInfoDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) {
                    // 詳細グリッド用キャッシュテーブルから削除
                    this._imageInfoDic.Remove(imageInfoWork.FileHeaderGuid);
                    // データテーブルから削除
                    // 2009.03.25 30413 犬飼 フィルタの設定を修正 >>>>>>START
                    //string selectCommand1 = COL_IMAGEINFODIVCODE_TITLE + " = '" + imageInfoWork.ImageInfoDiv + "' and " +
                    //                        COL_IMAGEINFOCODE_TITLE + " = '" + imageInfoWork.ImageInfoCode + "'";
                    string selectCommand1 = COL_IMAGEINFODIVCODE_TITLE + " = '" + imageInfoWork.ImageInfoDiv + "' and " +
                                            COL_IMAGEINFOCODE_TITLE + " = " + imageInfoWork.ImageInfoCode;
                    // 2009.03.25 30413 犬飼 フィルタの設定を修正 <<<<<<END
                    string sortCommand1 = COL_IMAGEINFODIVCODE_TITLE + " ASC , " + COL_IMAGEINFOCODE_TITLE + " ASC";
                    DataRow[] dr = this._imageInfoTable.Select(selectCommand1, sortCommand1);
                    if (dr.Length > 0)
                    {
                        dr[0].Delete();
                    }
				}
			}
			catch( Exception) {
				// オフライン時はnullをセット
				this._iImageInfoDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region Search Methods

		/// <summary>
        ///検索処理(論理削除除く)
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="ImageInfoDiv">画面情報区分</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データは検索対象外です。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        public int Search(out int totalCount, string enterpriseCode, int ImageInfoDiv)
        {
            // 画像情報マスタ検索
            return this.SearchProc(out totalCount, enterpriseCode, ImageInfoDiv, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>
        ///検索処理(論理削除含む)
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データも検索対象に含みます。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        public int SearchAll(out int totalCount, string enterpriseCode)
        {
            // 画像情報マスタ検索
            return this.SearchProc(out totalCount, enterpriseCode, 0, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        ///検索処理
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="ImageInfoDiv">画面情報区分</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        private int SearchProc(out int totalCount, string enterpriseCode, int ImageInfoDiv, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;

            // 画像情報マスタ検索
            status1 = this.SearchImegeInfoProc(out totalCount, enterpriseCode, logicalMode);
            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                return status1;
            }

            // キャッシュ処理
            status2 = this.Cache(this._imageInfoList, ImageInfoDiv);
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }

            return status1;
        }

        /// <summary>
        ///画像情報マスタ検索処理
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 画像情報マスタの検索処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        private int SearchImegeInfoProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // 取得リスト初期化
                this._imageInfoList.Clear();

                // キャッシュ用テーブルをクリア
                this._imageInfoDic.Clear();

                // キー情報をセット
                ImageInfoWork paramImageInfoWork = new ImageInfoWork();
                paramImageInfoWork.EnterpriseCode = enterpriseCode;    // 企業コード

                object retobj = null;

                // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
                ////画像情報マスタ検索
                //status = this._iImageInfoDB.Search(out retobj, paramImageInfoWork, 0, logicalMode);
                //
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    this._imageInfoList = retobj as ArrayList;
                //
                //    // 該当件数格納
                //    totalCount = this._imageInfoList.Count;
                //}
                //else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                //{
                //}
                if (_isLocalDBRead)
                {
                    //画像情報マスタ検索
                    List<ImageInfoWork> workList = new List<ImageInfoWork>();
                    status = this._imageInfoLcDB.Search(out workList, paramImageInfoWork, 0, logicalMode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 該当件数格納
                        this._imageInfoList.AddRange(workList);
                        totalCount = this._imageInfoList.Count;
                    }
                }
                else
                {
                    //画像情報マスタ検索
                    status = this._iImageInfoDB.Search(out retobj, paramImageInfoWork, 0, logicalMode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this._imageInfoList = retobj as ArrayList;
                        // 該当件数格納
                        totalCount = this._imageInfoList.Count;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                    }
                }
                // 2008.02.08 96012 ローカルＤＢ参照対応 end
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iImageInfoDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

		#endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>
        ///マスタキャッシュ処理
        /// </summary>
        /// <param name="imageInfoList">画像情報取得結果リスト</param>
        /// <param name="ImageInfoDiv">画面情報区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報のキャッシュ処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        public int Cache(ArrayList imageInfoList, int ImageInfoDiv)
        {
            try
            {
                try
                {
                    // 更新処理開始
                    this._imageInfoTable.BeginLoadData();

                    // テーブルをクリア
                    this._imageInfoTable.Clear();

                    // 画像情報データをDataSetに格納
                    foreach (ImageInfoWork imageInfoWork in imageInfoList)
                    {
                        // 未登録の時
                        if (this._imageInfoDic.ContainsKey(imageInfoWork.FileHeaderGuid) == false)
                        {
                            // データセットに追加
                            this.ImageInfoWorkToDataSet(imageInfoWork);
                        }
                    }
                }
                finally
                {
                    // 更新処理終了
                    this._imageInfoTable.EndLoadData();

                    // フィルタ
                    if (ImageInfoDiv != 0)
                    {
                        this._imageInfoTable.DefaultView.RowFilter = COL_IMAGEINFODIVCODE_TITLE + " = '" + ImageInfoDiv + "'";  // 画像情報区分コード
                    }

                    // ソート
                    this._imageInfoTable.DefaultView.Sort = COL_IMAGEINFODIVCODE_TITLE + " ASC, " +     // 画像情報区分コード
                                                            COL_IMAGEINFOCODE_TITLE    + " ASC";        // 画像情報コード
                    this._imageInfoTable.AcceptChanges();
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }

        #endregion

        // --------------------------------------------------
        #region MemberCopy Methods

        /// <summary>
        /// クラスメンバコピー処理 (画像情報マスタクラス⇒画像情報マスタワーククラス)
        /// </summary>
        /// <param name="imageInfoWork">画像情報マスタワーククラス</param>
        /// <param name="imageInfo">画像情報マスタクラス</param>
        /// <remarks>
        /// <br>Note       : 画像情報マスタクラスから
        ///                  画像情報マスタワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private void CopyToImageInfoWorkFromImageInfo(ref ImageInfoWork imageInfoWork, ImageInfo imageInfo)
        {
            imageInfoWork.EnterpriseCode    = imageInfo.EnterpriseCode;     // 企業コード
            imageInfoWork.ImageInfoDiv      = imageInfo.ImageInfoDiv;       // 画像情報区分
            imageInfoWork.ImageInfoCode     = imageInfo.ImageInfoCode;      // 画像情報コード
            imageInfoWork.ImageInfoName     = imageInfo.ImageInfoName;      // 画像情報表示名称
            imageInfoWork.ImageInfoFlType   = imageInfo.ImageInfoFlType;    // 画像情報ファイルタイプ
            imageInfoWork.ImageInfoData     = imageInfo.ImageInfoData;      // 画像情報データ
        }

		/// <summary>
        /// クラスメンバコピー処理 (画像情報マスタワーククラス⇒画像情報マスタクラス)
		/// </summary>
        /// <param name="imageInfoWork">画像情報マスタワーククラス</param>
        /// <returns>画像情報マスタクラス</returns>
		/// <remarks>
        /// <br>Note       : 画像情報マスタワーククラスから
        ///                  画像情報マスタクラスへメンバコピーを行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private ImageInfo CopyToImageInfoFromImageInfoWork(ImageInfoWork imageInfoWork)
        {
            ImageInfo imageInfo = new ImageInfo();

            imageInfo.CreateDateTime    = imageInfoWork.CreateDateTime;         // 作成日時
            imageInfo.UpdateDateTime    = imageInfoWork.UpdateDateTime;         // 更新日時
            imageInfo.EnterpriseCode    = imageInfoWork.EnterpriseCode;         // 企業コード
            imageInfo.FileHeaderGuid    = imageInfoWork.FileHeaderGuid;         // GUID
            imageInfo.UpdEmployeeCode   = imageInfoWork.UpdEmployeeCode;        // 更新従業員コード
            imageInfo.UpdAssemblyId1    = imageInfoWork.UpdAssemblyId1;         // 更新アセンブリID1
            imageInfo.UpdAssemblyId2    = imageInfoWork.UpdAssemblyId2;         // 更新アセンブリID2
            imageInfo.LogicalDeleteCode = imageInfoWork.LogicalDeleteCode;      // 論理削除区分
            imageInfo.ImageInfoDiv      = imageInfoWork.ImageInfoDiv;           // 画像情報区分
            imageInfo.ImageInfoCode     = imageInfoWork.ImageInfoCode;          // 画像情報コード
            imageInfo.ImageInfoName     = imageInfoWork.ImageInfoName;          // 画像情報表示名称
            imageInfo.ImageInfoFlType   = imageInfoWork.ImageInfoFlType;        // 画像情報ファイルタイプ
            imageInfo.ImageInfoData     = imageInfoWork.ImageInfoData;          // 画像情報データ

            // テーブル更新
            _imageInfoDic[imageInfoWork.FileHeaderGuid] = imageInfoWork;

            return imageInfo;
        }

        /// <summary>
        /// 画像情報マスタオブジェクトメインDataSet展開処理
        /// </summary>
        /// <param name="imageInfoWork">画像情報マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画像情報マスタオブジェクトを、メインDataSetに格納します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        private void ImageInfoWorkToDataSet(ImageInfoWork imageInfoWork)
        {
            bool newFlg = false;    // 新規・既存フラグ
            DataRow dr = null;
            ImageInfo imageInfo = new ImageInfo();

            // 更新対象行の取得
            // 2009.03.25 30413 犬飼 フィルタの設定を修正 >>>>>>START
            //string selectCommand1 = COL_IMAGEINFODIVCODE_TITLE + " = '" + imageInfoWork.ImageInfoDiv + "' and " +
            //                        COL_IMAGEINFOCODE_TITLE + " = '" + imageInfoWork.ImageInfoCode + "'";
            string selectCommand1 = COL_IMAGEINFODIVCODE_TITLE + " = '" + imageInfoWork.ImageInfoDiv + "' and " +
                                    COL_IMAGEINFOCODE_TITLE + " = " + imageInfoWork.ImageInfoCode;
            // 2009.03.25 30413 犬飼 フィルタの設定を修正 <<<<<<END
            string sortCommand1 = COL_IMAGEINFODIVCODE_TITLE + " ASC , " + COL_IMAGEINFOCODE_TITLE + " ASC";
            DataRow[] dr2 = this._imageInfoTable.Select(selectCommand1, sortCommand1);

            if (dr2.Length <= 0)
            {
                // 新規に行を作成
                dr = this._imageInfoTable.NewRow();

                // 新規レコードチェック
                newFlg = true;
            }
            else
            {
                dr = dr2[0];
            }

            // 削除日
            if (imageInfoWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", imageInfoWork.UpdateDateTime);
            }
            dr[COL_IMAGEINFODIVCODE_TITLE]  = imageInfoWork.ImageInfoDiv;                                           // 画像情報区分コード
            dr[COL_IMAGEINFODIVNAME_TITLE]  = (string)imageInfo.GetImageInfoDivName(imageInfoWork.ImageInfoDiv);    // 画像情報区分名称
            //dr[COL_IMAGEINFOCODE_TITLE]     = imageInfoWork.ImageInfoCode;                                          // 画像情報コード         //DEL 2008/10/29 0詰めの為
            dr[COL_IMAGEINFOCODE_TITLE]     = imageInfoWork.ImageInfoCode.ToString("000000000");                    // 画像情報コード
            dr[COL_IMAGEINFONAME_TITLE]     = imageInfoWork.ImageInfoName;                                          // 画像情報表示名称
            dr[COL_IMAGEINFOFLTYPE_TITLE]   = imageInfoWork.ImageInfoFlType;                                        // 画像情報ファイルタイプ
            dr[COL_IMAGEINFODATA_TITLE]     = imageInfoWork.ImageInfoData;                                          // 画像情報データ
            dr[COL_GUID_TITLE]              = imageInfoWork.FileHeaderGuid;                                         // GUID

            // 新規レコードの場合のみ
            if (newFlg == true)
            {
                // 新規行の追加
                this._imageInfoTable.Rows.Add(dr);
            }

            // テーブルに格納
            if (this._imageInfoDic.ContainsKey(imageInfoWork.FileHeaderGuid) == true)
            {
                this._imageInfoDic.Remove(imageInfoWork.FileHeaderGuid);
            }
            this._imageInfoDic.Add(imageInfoWork.FileHeaderGuid, imageInfoWork);
        }
        
		#endregion

		// --------------------------------------------------
		#region 比較用クラス

        /// <summary>
        ///画像情報マスタ比較クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画像情報マスタオブジェクトの比較を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        public class ImageInfoCompare : IComparer
        {
            #region IComparer メンバ

            /// <summary>
            /// 比較用メソッド
            /// </summary>
            /// <param name="x">比較対象オブジェクト</param>
            /// <param name="y">比較対象オブジェクト</param>
            /// <returns>比較結果(x ＞ y : 0より大きい整数, x ＜ y : 0より小さい整数, x ＝ y : 0)</returns>
            /// <remarks>
            /// <br>Note       : 画像情報マスタオブジェクトの比較を行います。</br>
            /// <br>Programmer : 22022 段上 知子</br>
            /// <br>Date       : 2007.05.16</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                ImageInfo obj1 = x as ImageInfo;
                ImageInfo obj2 = y as ImageInfo;

                // 画像情報区分で比較
                if (obj1.ImageInfoDiv.CompareTo(obj2.ImageInfoDiv) == 0)
                {
                    // 画像情報コードで比較
                    return obj1.ImageInfoCode.CompareTo(obj2.ImageInfoCode);
                }
                else
                {
                    // 画像情報コードで比較
                    return obj1.ImageInfoCode.CompareTo(obj2.ImageInfoCode);
                }
            }

            #endregion
        }

		#endregion

	}
}
