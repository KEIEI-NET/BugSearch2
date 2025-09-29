using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Broadleaf.Application.Control;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;

using ChangGidncCache = 
	System.Collections.Generic.SortedList<
		string, Broadleaf.Application.Remoting.ParamData.ChangGidncWork>;
using ChgGidncDtCacheDtl = System.Collections.Generic.SortedList<
			int, Broadleaf.Application.Remoting.ParamData.ChgGidncDtWork>;
using ChgGidncDtCache = 
	System.Collections.Generic.SortedList<
		string,	System.Collections.Generic.SortedList<
            int, Broadleaf.Application.Remoting.ParamData.ChgGidncDtWork>>;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 変更案内(サーバーメンテ)明細編集フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 変更案内(サーバーメンテ)の明細の編集を行います。</br>
	/// <br>Programmer : 23013 牧　将人</br>
	/// <br>Date       : 2008.01.21</br>
    /// <br>Update     : 2008.01.28 Kouguhci 新レイアウト対応</br>
    /// <br>Update     : 2008.11.20 Sasaki PM用に変更</br>
    /// </remarks>
	public partial class McastMainteInfoEditor : Form, ISimpleMasterMaintenanceMulti
	{

		#region << Constructor >>

		/// <summary>
        /// 変更案内(サーバーメンテ)明細編集フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 変更案内(サーバーメンテ)明細編集フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2008.01.21</br>
		/// </remarks>
        public McastMainteInfoEditor()
		{
			InitializeComponent();

			// 新規・削除有無
			this._allowNew    = true;
			this._allowDelete = true;

			this._dataIndex    = 0;
			this._dataIndexBuf = -2;

			this._changGidncWorkClone     = null;
			this._chgGidncDtWorkListClone = null;

			// データソースを初期化
			this._dataSet = new ChangGidncDataSet();
			// キャッシュを初期化
			this._changGidncCache = new SortedList<string,ChangGidncWork>();
			this._chgGidncDtCache = new SortedList<string,SortedList<int,ChgGidncDtWork>>();

			// 設定ファイル読み込み
			this._setting = MulticastInfoEditorSetting.Load( ctSetting_FileName );
			if( this._setting == null ) {
				this._setting = new MulticastInfoEditorSetting();
			}
		}

		#endregion


		#region << Private Members >>

		/// <summary>変更案内(サーバーメンテ)一覧表示用DataSet</summary>
		private ChangGidncDataSet  _dataSet             = null;

        /// <summary>変更案内DBアクセスクラス</summary>
		private ChangePgGuideDBAcs _changePgGuideDBAcs  = null;

		/// <summary>変更案内ワークキャッシュ</summary>
        private ChangGidncCache _changGidncCache        = null;
		/// <summary>変更案内明細ワークキャッシュ</summary>
        private ChgGidncDtCache _chgGidncDtCache        = null;

        /// <summary>変更案内(サーバーメンテ)設定画面設定クラス</summary>
		private MulticastInfoEditorSetting _setting     = null;

        /// <summary>変更案内(サーバーメンテ)設定画面設定フォーム</summary>
		private MulticastInfoSettingForm   _settingForm = null;

		// INSChangeInfoEditor 用
		/// <summary>新規追加許可</summary>
		private bool               _allowNew           = false;
		/// <summary>削除許可</summary>
		private bool               _allowDelete        = false;
		/// <summary>クローズ可否</summary>
		private bool               _canClose           = false;
		/// <summary>選択データインデックス</summary>
		private int                _dataIndex;
		/// <summary>選択データインデックス保持用</summary>
		private int                _dataIndexBuf;

		/// <summary>編集前データ退避用</summary>
        private ChangGidncWork  _changGidncWorkClone            = null;
		/// <summary>編集前データ退避用</summary>
        private List<ChgGidncDtWork> _chgGidncDtWorkListClone   = null;

		#endregion


		#region << Private Constant >>

		/// <summary>オプションツールキー : 設定</summary>
		private const string ctOptionToolKey_Setting = "Setting";

		/// <summary>設定ファイル名</summary>
		private const string ctSetting_FileName      = "NSChangeInfoEditor_McastMainteInfo.xml";

		#endregion


		#region << Private Methods >>

		#region ■画面初期化処理

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期化を行います。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2008.01.21</br>
		/// </remarks>
		private void ScreenInitialize()
		{
			// 案内区分
			this.McastGidncCntntsCd_comboBox.Items.Clear();
            //Del ↓↓↓ 2008.01.28 Kouguchi
            //foreach ( int mcastGidncCntntsCd in Enum.GetValues( typeof( ConstantManagement_NS_MGD.McastGidncCntntsCd ) ) ) {
            //    this.McastGidncCntntsCd_comboBox.Items.Add(
            //        new ComboItem<int>( mcastGidncCntntsCd,
            //        ConstantManagement_NS_MGD.GetMcastGidncCntntsCdNm( mcastGidncCntntsCd ) ) );
            //}
            //Del ↑↑↑ 2008.01.28 Kouguchi
            this.McastGidncCntntsCd_comboBox.Items.Add( new ComboItem<int>( 2, ConstantManagement_NS_MGD.GetMcastGidncCntntsCdNm(2) ) );  //Add 2008.01.28 Kouguchi

            // メンテナンス区分  データメンテ、定期メンテ、緊急メンテの順
            this.McastGidnceMainteCd_comboBox.Items.Clear();
            this.McastGidnceMainteCd_comboBox.Items.Add( new ComboItem<int>(2, ConstantManagement_NS_MGD.GetServerMainteDivNm(2) ) );
            foreach ( int mcastGidnceMainteCd in Enum.GetValues( typeof( ConstantManagement_NS_MGD.MainteDiv ) ) )
            {
                if ( mcastGidnceMainteCd != 2 ) {
                    this.McastGidnceMainteCd_comboBox.Items.Add(
                        new ComboItem<int>( mcastGidnceMainteCd,
                        ConstantManagement_NS_MGD.GetServerMainteDivNm( mcastGidnceMainteCd ) ) );
                }
            }
		}

		#endregion

		#region ■キー文字列作成処理

		/// <summary>
		/// キー文字列作成処理
		/// </summary>
        /// <param name="mcastGidncCntntsCd">案内内容区分</param>
		/// <param name="productCode">パッケージ区分</param>
		/// <param name="mcastOfferDivCd">配信提供区分</param>
		/// <param name="UpdateGroupCode">更新グループコード</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="multicastVersion">配信バージョン</param>
		/// <param name="multicastConsNo">メンテナンス連番</param>
		/// <returns>キー文字列</returns>
		/// <remarks>
		/// <br>Note       : キー文字列の作成を行います。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2008.01.21</br>
		/// </remarks>
		private string GetChangGidncKey( int mcastGidncCntntsCd, string productCode, int mcastOfferDivCd, string UpdateGroupCode, string enterpriseCode, string multicastVersion, int multicastConsNo )
		{
            return String.Format( "{0,2:00}{1,-32}{2,2:00}{3,-32}{4,-16}{5,-32}{6,8:0000}", mcastGidncCntntsCd, productCode, mcastOfferDivCd, UpdateGroupCode, enterpriseCode, multicastVersion, multicastConsNo );
		}

		/// <summary>
		/// キー文字列作成処理
		/// </summary>
        /// <param name="changGidncWork">変更案内ワーククラス</param>
		/// <returns>キー文字列</returns>
		/// <remarks>
		/// <br>Note       : キー文字列の作成を行います。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2008.01.21</br>
		/// </remarks>
        private string GetChangGidncKey( ChangGidncWork changGidncWork )
		{
            return this.GetChangGidncKey( changGidncWork.McastGidncCntntsCd, changGidncWork.ProductCode, changGidncWork.McastOfferDivCd, changGidncWork.UpdateGroupCode, changGidncWork.EnterpriseCode, changGidncWork.McastGidncVersionCd, changGidncWork.MulticastConsNo );
		}

		/// <summary>
		/// キー文字列作成処理
		/// </summary>
        /// <param name="chgGidncDtWork">変更案内明細ワーククラス</param>
		/// <returns>キー文字列</returns>
		/// <remarks>
		/// <br>Note       : キー文字列の作成を行います。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2008.01.21</br>
		/// </remarks>
        private string GetChangGidncKey(ChgGidncDtWork chgGidncDtWork)
		{
            return this.GetChangGidncKey( chgGidncDtWork.McastGidncCntntsCd, chgGidncDtWork.ProductCode, chgGidncDtWork.McastOfferDivCd, chgGidncDtWork.UpdateGroupCode, chgGidncDtWork.EnterpriseCode, chgGidncDtWork.McastGidncVersionCd, chgGidncDtWork.MulticastConsNo );
		}

		#endregion

		#region ■変更案内ワークDataSet格納処理

		/// <summary>
		/// 変更案内ワークDataSet格納処理
		/// </summary>
        /// <param name="changGidncWork">変更案内ワーククラス</param>
		/// <param name="index">格納インデックス</param>
		/// <remarks>
		/// <br>Note       : 変更案内ワークの情報をDataSetに格納します。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2008.01.21</br>
		/// </remarks>
        private void SetChangGidncWorkToDataSet( ChangGidncWork changGidncWork, int index )
		{
			if( ( index < 0 ) || ( index >= this._dataSet.ChangGidnc.Count ) ) {
				// 新規行を追加
                ChangGidncDataSet.ChangGidncRow newRow = this._dataSet.ChangGidnc.NewChangGidncRow();
                this._dataSet.ChangGidnc.AddChangGidncRow( newRow );

				// インデックスを最終行にセット
                index = this._dataSet.ChangGidnc.Count - 1;
			}

            ChangGidncDataSet.ChangGidncRow row = this._dataSet.ChangGidnc[ index ];

            // 案内区分
            row.McastGidncCntntsCd   = changGidncWork.McastGidncCntntsCd;
            // 案内区分名称
            row.McastGidncCntntsNm   = ConstantManagement_NS_MGD.GetMcastGidncCntntsCdNm( changGidncWork.McastGidncCntntsCd );
            // パッケージ区分
			row.ProductCode          = changGidncWork.ProductCode;
            // 連番
			row.MulticastConsNo      = changGidncWork.MulticastConsNo;
            // 案内文１
			row.Guidance             = changGidncWork.Guidance1;

            //Add ↓↓↓ 2008.01.28 Kouguchi
            // サポート公開日時
            // ユーザー公開日時
            // メンテナンス予定日時　開始
            row.ServerMainteStScdl   = changGidncWork.ServerMainteStScdl;
            // メンテナンス予定日時　終了
            row.ServerMainteEdScdl   = changGidncWork.ServerMainteEdScdl;
            // メンテナンス日時　開始
            row.ServerMainteStTime   = changGidncWork.ServerMainteStTime;
            // メンテナンス日時　終了
            row.ServerMainteEdTime   = changGidncWork.ServerMainteEdTime;
            // メンテナンス予定日時 開始 表示用
            DateTime serverMainteStScdl = this.LongDateToDateTime( changGidncWork.ServerMainteStScdl );
            if ( ( changGidncWork.ServerMainteStScdl == 0 ) ||
                ( serverMainteStScdl == DateTime.MinValue ) ) {
                row.ServerMainteStScdlNm = String.Empty;
            }
            else {
                row.ServerMainteStScdlNm = serverMainteStScdl.ToString( "yyyy年MM月dd日 HH時mm分" );
            }
            // メンテナンス予定日時 終了 表示用
            DateTime serverMainteEdScdl = this.LongDateToDateTime( changGidncWork.ServerMainteEdScdl );
            if ( ( changGidncWork.ServerMainteEdScdl == 0 ) ||
                ( serverMainteEdScdl == DateTime.MinValue ) ) {
                row.ServerMainteEdScdlNm = String.Empty;
            }
            else {
                row.ServerMainteEdScdlNm = serverMainteEdScdl.ToString( "yyyy年MM月dd日 HH時mm分" );
            }
            // メンテナンス日時 開始 表示用
            DateTime serverMainteStTime = this.LongDateToDateTime( changGidncWork.ServerMainteStTime );
            if ( ( changGidncWork.ServerMainteStTime == 0 ) ||
                ( serverMainteStTime == DateTime.MinValue ) ) {
                row.ServerMainteStTimeNm = String.Empty;
            }
            else {
                row.ServerMainteStTimeNm = serverMainteStTime.ToString( "yyyy年MM月dd日 HH時mm分" );
            }
            // メンテナンス日時 終了 表示用
            DateTime serverMainteEdTime = this.LongDateToDateTime( changGidncWork.ServerMainteEdTime );
            if ( ( changGidncWork.ServerMainteEdTime == 0 ) ||
                ( serverMainteEdTime == DateTime.MinValue ) ) {
                row.ServerMainteEdTimeNm = String.Empty;
            }
            else {
                row.ServerMainteEdTimeNm = serverMainteEdTime.ToString( "yyyy年MM月dd日 HH時mm分" );
            }

            // 配信案内　メンテ区分
            row.McastGidncMainteCd  = changGidncWork.McastGidncMainteCd;
            // 配信案内　メンテ区分名称
			row.McastGidncMainteNm  = ConstantManagement_NS_MGD.GetServerMainteDivNm( changGidncWork.McastGidncMainteCd );
            //Add ↑↑↑ 2008.01.28 Kouguchi

			// キーを取得
			string key = this.GetChangGidncKey( changGidncWork );

			// ユニークキー
			row.UniqueKey            = key;

			// キャッシュを更新
			if( this._changGidncCache.ContainsKey( key ) ) {
                this._changGidncCache[ key ] = changGidncWork;
			}
			else {
                this._changGidncCache.Add( key, changGidncWork );
			}
		}

		#endregion

		#region ■画面クリア処理

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <param name="easyMode">簡易モード</param>
		/// <remarks>
		/// <br>Note       : 画面のクリアを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void ScreenClear( bool easyMode )
		{
            //案内区分
            this.McastGidncCntntsCd_comboBox.SelectedIndex = 0;
            // パッケージ区分
			this.ProductCode_textBox.Clear();
			// メンテナンス区分
			this.McastGidnceMainteCd_comboBox.SelectedIndex = 0;
			// メンテナンス連番
			this.MulticastConsNo_textBox.Clear();
			// メンテナンス開始予定日時
			this.ServerMainteStScdl_maskedTextBox.Clear();
			// メンテナンス終了予定日時
			this.ServerMainteEdScdl_maskedTextBox.Clear();
            // メンテナンス開始日時
            this.ServerMainteStTime_maskedTextBox.Clear();
            // メンテナンス終了日時
            this.ServerMainteEdTime_maskedTextBox.Clear();
            // メンテナンス内容
            this.ServerMainteCntnts_textBox.Clear();
            // メンテナンス案内文
            this.ServerMainteGidnc_textBox.Clear();
			// 別紙ファイル名称
			this.AnothersheetFileName_listView.Items.Clear();
			// 別紙ファイルコピー可否
			this.CopyAnothersheetFile_checkBox.Checked = true;

		}

		#endregion

		#region ■画面再構築処理

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		private void ScreenReconstruction()
		{
			// 新規
			if( this._dataIndex < 0 ) {
				ChangGidncWork       changGidncWork     = new ChangGidncWork();
                // 2008.11.20 Update >>>
				//changGidncWork.ProductCode              = ConstantManagement_NS_MGD.ProductCode.SF;
                changGidncWork.ProductCode = ConstantManagement_NS_MGD.ProductCode.PM;
                // 2008.11.20 Update <<<
                List<ChgGidncDtWork> chgGidncDtWorkList = new List<ChgGidncDtWork>();

				// 画面にデータを表示
				this.SetChangGidncWorkToScreen( changGidncWork, chgGidncDtWorkList, this._dataIndex );

				// クローン作成
				this._changGidncWorkClone     = changGidncWork.Clone();
				this._chgGidncDtWorkListClone = new List<ChgGidncDtWork>();
				// 画面のデータを取得
				List<ChgGidncDtWork> delList  = new List<ChgGidncDtWork>();
				this.GetChangGidncWorkFormScreen( ref this._changGidncWorkClone, ref this._chgGidncDtWorkListClone, ref delList );

				// 画面入力制御処理
				this.ScreenInputPermissionControl( 0 );
                
                // 新規or更新ラベルの表示切替
                this.Update_label.Text = "新規モード";
            }
			// 更新
			else {
				// キーを取得
				string key = this._dataSet.ChangGidnc[ this._dataIndex ].UniqueKey;

				ChangGidncWork       changGidncWork     = null;
				List<ChgGidncDtWork> chgGidncDtWorkList = null;
				// 各オブジェクトを取得
				if( this._changGidncCache.ContainsKey( key ) ) {
					changGidncWork = this._changGidncCache[ key ];
				}
				if( this._chgGidncDtCache.ContainsKey( key ) ) {
					chgGidncDtWorkList = new List<ChgGidncDtWork>( this._chgGidncDtCache[ key ].Values );
				}

				if( changGidncWork == null ) {
					this.Close();
					return;
				}

				// 画面にデータを表示
				this.SetChangGidncWorkToScreen( changGidncWork, chgGidncDtWorkList, this._dataIndex);

				// クローン作成
				this._changGidncWorkClone     = changGidncWork.Clone();
                if (chgGidncDtWorkList != null)
                {
                    this._chgGidncDtWorkListClone = new List<ChgGidncDtWork>(chgGidncDtWorkList);

                    for (int ix = 0; ix < this._chgGidncDtWorkListClone.Count; ix++)
                    {
                        this._chgGidncDtWorkListClone[ix] = this._chgGidncDtWorkListClone[ix].Clone();
                    }
                }
                // 画面のデータを取得
                List<ChgGidncDtWork> delList = new List<ChgGidncDtWork>();
                this.GetChangGidncWorkFormScreen(ref this._changGidncWorkClone, ref this._chgGidncDtWorkListClone, ref delList);
                
				// 画面入力制御処理
				this.ScreenInputPermissionControl( 2 );
                
                // 新規or更新ラベルの表示切替
                this.Update_label.Text = "更新モード";
            }

			// データ選択インデックス退避
			this._dataIndexBuf = this._dataIndex;
		}

		#endregion

		#region ■画面展開処理

		/// <summary>
		/// 画面展開処理
		/// </summary>
		/// <param name="changGidncWork">変更案内ワーククラス</param>
		/// <param name="chgGidncDtWorkList">変更案内明細ワークリスト</param>
		/// <remarks>
		/// <br>Note       : 変更案内データを画面に展開します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
        private void SetChangGidncWorkToScreen(ChangGidncWork changGidncWork, List<ChgGidncDtWork> chgGidncDtWorkList, int dataIndex)
		{
			if( changGidncWork == null ) {
				return;
			}

            // 案内区分
            this.McastGidncCntntsCd_comboBox.SelectedItem   = new ComboItem<int>(changGidncWork.McastGidncCntntsCd);
            // パッケージ区分
			this.ProductCode_textBox.Text                   = changGidncWork.ProductCode;

            if (dataIndex < 0)
            {
                // サーバーメンテナンス連番
                // 新規の場合
                // 2008.11.20 Update >>>
                //int multicastConsNo                         = (this._changGidncCache.Values[this._changGidncCache.Count - 1].MulticastConsNo) + 1;
                int multicastConsNo = 1;
                // 2008.11.20 Update <<<
                this.MulticastConsNo_textBox.Text = multicastConsNo.ToString();
            }
            else {
                // 更新の場合
                // メンテナンス区分
                this.McastGidnceMainteCd_comboBox.SelectedItem = new ComboItem<int>(changGidncWork.McastGidncMainteCd);
                // サーバーメンテナンス連番
                this.MulticastConsNo_textBox.Text           = changGidncWork.MulticastConsNo.ToString();
            }
			// メンテナンス開始予定日時
            if ( changGidncWork.ServerMainteStScdl == 0 ) {
				this.ServerMainteStScdl_maskedTextBox.Clear();
			}
			else {
                this.ServerMainteStScdl_maskedTextBox.Text  = changGidncWork.ServerMainteStScdl.ToString();
			}
            // メンテナンス終了予定日時
            if ( changGidncWork.ServerMainteEdScdl == 0 ) {
				this.ServerMainteEdScdl_maskedTextBox.Clear();
			}
			else {
                this.ServerMainteEdScdl_maskedTextBox.Text  = changGidncWork.ServerMainteEdScdl.ToString();
			}
            // メンテナンス開始日時
            if ( changGidncWork.ServerMainteStTime == 0 ) {
                this.ServerMainteStTime_maskedTextBox.Clear();
            }
            else {
                this.ServerMainteStTime_maskedTextBox.Text  = changGidncWork.ServerMainteStTime.ToString();
            }
            // メンテナンス終了予定日時
            if ( changGidncWork.ServerMainteEdTime == 0 ) {
                this.ServerMainteEdTime_maskedTextBox.Clear();
            }
            else {
                this.ServerMainteEdTime_maskedTextBox.Text  = changGidncWork.ServerMainteEdTime.ToString();
            }
			// サーバーメンテナンス内容
			this.ServerMainteCntnts_textBox.Text            = changGidncWork.Guidance1;

			// 明細ありの場合
			if( ( chgGidncDtWorkList != null ) && 
				( chgGidncDtWorkList.Count > 0 ) ) {
				StringBuilder changeContents       = new StringBuilder();

				foreach( ChgGidncDtWork chgGidncDtWork in chgGidncDtWorkList ) {
					// 変更内容
					if( ! String.IsNullOrEmpty( chgGidncDtWork.ChangeContents ) ) {
						changeContents.Append( chgGidncDtWork.ChangeContents );
					}
					// 別紙ファイル名称
					if( ( chgGidncDtWork.AnothersheetFileExst == 1 ) && 
						( ! String.IsNullOrEmpty( chgGidncDtWork.AnothersheetFileName ) ) ) {
						// リストビューアイテム作成
						ListViewItem newItem = new ListViewItem( new string[] { chgGidncDtWork.AnothersheetFileName, "" } );
						// ファイルの存在をチェックし、アイコンをセット
						newItem.StateImageIndex = ( this.CheckAnothersheetFileExists( chgGidncDtWork.AnothersheetFileName ) ? 0 : 1 );
						this.AnothersheetFileName_listView.Items.Add( newItem );
					}
				}
				// メンテナンス案内文
                this.ServerMainteGidnc_textBox.Text         = changeContents.ToString();
			}
		}

		#endregion

		#region ■画面取得処理

		/// <summary>
		/// 画面取得処理
		/// </summary>
		/// <param name="changGidncWork">変更案内ワーククラス</param>
		/// <param name="chgGidncDtWorkList">変更案内明細ワークリスト</param>
		/// <param name="chgGidncDtWorkDelList">削除対象変更案内明細ワークリスト</param>
		/// <remarks>
		/// <br>Note       : 変更案内データを画面から取得します。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2008.01.21</br>
		/// </remarks>
        private void GetChangGidncWorkFormScreen(ref ChangGidncWork changGidncWork, ref List<ChgGidncDtWork> chgGidncDtWorkList, ref List<ChgGidncDtWork> chgGidncDtWorkDelList)
		{
			if( changGidncWork == null ) {
				changGidncWork = new ChangGidncWork();
			}

			if( chgGidncDtWorkList == null ) {
				chgGidncDtWorkList = new List<ChgGidncDtWork>();
			}

			if( chgGidncDtWorkDelList == null ) {
				chgGidncDtWorkDelList = new List<ChgGidncDtWork>();
			}

            // 案内区分
            ComboItem<int> mcastGidncCntntsCd            = this.McastGidncCntntsCd_comboBox.SelectedItem as ComboItem<int>;
            if ( mcastGidncCntntsCd == null ) {
                changGidncWork.McastGidncCntntsCd        = 0;
            }
            else {
                changGidncWork.McastGidncCntntsCd        = mcastGidncCntntsCd.Value;
            }
            // パッケージ区分
			changGidncWork.ProductCode                   = this.ProductCode_textBox.Text;
			// メンテナンス区分
            ComboItem<int> mcastGidnceMainteCd           = this.McastGidnceMainteCd_comboBox.SelectedItem as ComboItem<int>;
            if ( mcastGidnceMainteCd == null ) {
                changGidncWork.McastGidncMainteCd        = 0;
			}
			else {
                changGidncWork.McastGidncMainteCd        = mcastGidnceMainteCd.Value;
			}
			// サーバーメンテナンス連番
			int multicastConsNo = 0;
			if( Int32.TryParse( this.MulticastConsNo_textBox.Text, out multicastConsNo ) ) {
				changGidncWork.MulticastConsNo           = multicastConsNo;
			}
			else {
				changGidncWork.MulticastConsNo           = 0;
			}
			// メンテナンス開始予定日時
			if( ( this.ServerMainteStScdl_maskedTextBox.MaskCompleted ) && 
				( this.ServerMainteStScdl_maskedTextBox.ValidateText() != null ) ) {
                    changGidncWork.ServerMainteStScdl    = this.DateTimeToLongDate( ( DateTime )this.ServerMainteStScdl_maskedTextBox.ValidateText() );
			}
			else {
                changGidncWork.ServerMainteStScdl        = 0;
			}
			// メンテナンス終了予定日時
			if( ( this.ServerMainteEdScdl_maskedTextBox.MaskCompleted ) && 
				( this.ServerMainteEdScdl_maskedTextBox.ValidateText() != null ) ) {
                    changGidncWork.ServerMainteEdScdl    = this.DateTimeToLongDate( ( DateTime )this.ServerMainteEdScdl_maskedTextBox.ValidateText() );
			}
			else {
                changGidncWork.ServerMainteEdScdl        = 0;
			}
            // メンテナンス開始日時
            if ( ( this.ServerMainteStTime_maskedTextBox.MaskCompleted ) &&
                ( this.ServerMainteStTime_maskedTextBox.ValidateText() != null ) ) {
                changGidncWork.ServerMainteStTime        = this.DateTimeToLongDate( ( DateTime )this.ServerMainteStTime_maskedTextBox.ValidateText() );
            }
            else {
                changGidncWork.ServerMainteStTime        = 0;
            }
            // メンテナンス終了日時
            if ( ( this.ServerMainteEdTime_maskedTextBox.MaskCompleted ) &&
                ( this.ServerMainteEdTime_maskedTextBox.ValidateText() != null ) ) {
                changGidncWork.ServerMainteEdTime        = this.DateTimeToLongDate( ( DateTime )this.ServerMainteEdTime_maskedTextBox.ValidateText() );
            }
            else {
                changGidncWork.ServerMainteEdTime        = 0;
            }
			// サーバーメンテナンス内容
            changGidncWork.Guidance1                     = this.ServerMainteCntnts_textBox.Text;

            // 画面上存在しない項目をセット
            // 配信案内 バージョン区分
            string multicastConsNoSt = multicastConsNo.ToString();
            string str = "";
            // バージョン区分の作成方法 "案内内容区分" + "-" + "8桁のメンテナンス連番"
            changGidncWork.McastGidncVersionCd           = mcastGidncCntntsCd.Value.ToString() + "-" + str.PadLeft(8 - multicastConsNoSt.Length, '0') + multicastConsNoSt;

			// サーバーメンテナンス案内文を分割
			List<string> changeContentsList = new List<string>();
			string changeContents = this.ServerMainteGidnc_textBox.Text;

			while( changeContents.Length > 0 ) {
				int maxLengh = ( changeContents.Length > 500 ? 500 : changeContents.Length );
                // サーバーメンテナンス案内文リストに追加
				changeContentsList.Add( changeContents.Substring( 0, maxLengh ) );
				// 追加した分を取り除く
				changeContents = changeContents.Substring( maxLengh, changeContents.Length - maxLengh );
			}

			// 別紙ファイル名リスト
			List<string> anothersheetFileNameList = new List<string>();
			foreach( ListViewItem item in this.AnothersheetFileName_listView.Items ) {
				// 各行をチェック
				if( item.SubItems[ 0 ].Text.Trim() != String.Empty ) {
					// 別紙ファイル名リストに追加
					anothersheetFileNameList.Add( item.SubItems[ 0 ].Text.Trim() );
				}
			}

            // ループ回数を取得( 変更案内明細ワークリストの件数、サーバーメンテナンス案内文リストの件数、別紙ファイル名リストの件数の中での最大値 )
			int loopCount = Math.Max( chgGidncDtWorkList.Count, Math.Max( changeContentsList.Count, anothersheetFileNameList.Count ) );

			for( int ix = 0; ix < loopCount; ix++ ) {
				ChgGidncDtWork chgGidncDtWork = null;
				if( ix < chgGidncDtWorkList.Count ) {
					chgGidncDtWork = chgGidncDtWorkList[ ix ];
				}
				else {
					chgGidncDtWork = new ChgGidncDtWork();
					// キー値をコピー
					this.CopyKeyValue( changGidncWork, chgGidncDtWork );
					// サブコードをセット
					chgGidncDtWork.MulticastSubCode = ix + 1;

					// リストに追加
					chgGidncDtWorkList.Add( chgGidncDtWork );
				}

				// 登録する情報が存在する
				if( ( ix < changeContentsList.Count ) || 
					( ix < anothersheetFileNameList.Count ) ) {
                    // サーバーメンテナンス案内文リストの件数の範囲内
					if( ix < changeContentsList.Count ) {
						chgGidncDtWork.ChangeContents = changeContentsList[ ix ];
					}
					else {
						chgGidncDtWork.ChangeContents = String.Empty;
					}

					// 別紙ファイル名リストの件数の範囲内
					if( ix < anothersheetFileNameList.Count ) {
						chgGidncDtWork.AnothersheetFileExst = 1;
						chgGidncDtWork.AnothersheetFileName = anothersheetFileNameList[ ix ];
					}
					else {
						chgGidncDtWork.AnothersheetFileExst = 0;
						chgGidncDtWork.AnothersheetFileName = String.Empty;
					}
				}
				// 登録する情報が存在しない
				else {
					// 削除リストに追加
					chgGidncDtWorkDelList.Add( chgGidncDtWork );
				}
			}

			// 削除リストないデータを既存リストから除外
			foreach( ChgGidncDtWork chgGidncDtWork in chgGidncDtWorkDelList ) {
				chgGidncDtWorkList.Remove( chgGidncDtWork );
			}
		}

		#endregion

		#region ■別紙ファイル存在チェック処理

		/// <summary>
		/// 別紙ファイル存在チェック処理
		/// </summary>
		/// <param name="anothersheetFileName">別紙ファイル名</param>
		/// <returns>チェック結果(true:存在する, false:存在しない)</returns>
		private bool CheckAnothersheetFileExists( string anothersheetFileName )
		{
			bool isExists = false;

			string anothersheetFilePath = Path.Combine( this._setting.AnothersheetFileDirPath, anothersheetFileName );

			isExists = File.Exists( anothersheetFilePath );

			return isExists;
		}

		#endregion

		#region ■キー値コピー処理

		/// <summary>
		/// キー値コピー処理(変更案内ワーク→変更案内明細ワーク)
		/// </summary>
		/// <param name="changGidncWork">変更案内ワーククラス</param>
		/// <param name="chgGidncDtWork">変更案内明細ワーククラス</param>
		/// <br>Note       : 変更案内ワーククラスから、変更案内明細ワーククラスへキー項目をコピーします。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2008.01.21</br>
        private void CopyKeyValue(ChangGidncWork changGidncWork, ChgGidncDtWork chgGidncDtWork)
		{
            // 案内区分
            chgGidncDtWork.McastGidncCntntsCd   = changGidncWork.McastGidncCntntsCd;
            // パッケージ区分
			chgGidncDtWork.ProductCode          = changGidncWork.ProductCode;			
            // 配信提供区分
			chgGidncDtWork.McastOfferDivCd      = changGidncWork.McastOfferDivCd;
			// 配信グループコード
			chgGidncDtWork.UpdateGroupCode      = changGidncWork.UpdateGroupCode;
			// 企業コード
			chgGidncDtWork.EnterpriseCode       = changGidncWork.EnterpriseCode;
			// 配信バージョン
			chgGidncDtWork.McastGidncVersionCd  = changGidncWork.McastGidncVersionCd;
            // メンテナンス連番
			chgGidncDtWork.MulticastConsNo      = changGidncWork.MulticastConsNo;
		}

		#endregion

		#region ■DateTime→LongDate(yyyyMMddHHmm)変換処理

		/// <summary>
		/// DateTime→LongDate(yyyyMMddHHmm)変換処理
		/// </summary>
		/// <param name="dateTime">DateTime</param>
		/// <returns>LongDate</returns>
		/// <remarks>
		/// <br>Note       : DateTimeからLongDate(yyyyMMddHHmm)へ変換します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private long DateTimeToLongDate( DateTime dateTime )
		{
			return ( dateTime.Year * 100000000L + dateTime.Month * 1000000L + dateTime.Day * 10000L + dateTime.Hour * 100L + dateTime.Minute );
		}

		#endregion

        #region ■LongDate⇒DateTime変換処理

        /// <summary>
        /// LongDate⇒DateTime変換処理
        /// </summary>
        /// <param name="longDate">LongDate(YYYYMMDDHHmm)</param>
        /// <returns>DateTime</returns>
        /// <remarks>
        /// <br>Note       : LongDate(YYYYMMDDHHmm)をDateTimeに変換します。</br>
        /// <br>Date       : 2008.01.30</br>
        /// </remarks>
        private DateTime LongDateToDateTime(long longDate)
        {
            DateTime dateTime = DateTime.MinValue;

            try
            {
                int yy = (int)(longDate / 100000000);
                int MM = (int)((longDate % 100000000) / 1000000);
                int dd = (int)((longDate % 1000000) / 10000);
                int HH = (int)((longDate % 10000) / 100);
                int mm = (int)(longDate % 100);

                // データ不正チェック
                dateTime = new DateTime(yy, MM, dd, HH, mm, 0);
            }
            catch
            {
                dateTime = DateTime.MinValue;
            }

            return dateTime;
        }

        #endregion

		#region ■画面入力制御処理

		/// <summary>
		/// 画面入力制御処理
		/// </summary>
		/// <param name="mode">登録モード(0:新規, 1:連続新規, 2:更新</param>
		/// <remarks>
		/// <br>Note       : 画面の入力制御を行います。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2008.01.21</br>
		/// </remarks>
		private void ScreenInputPermissionControl( int mode )
		{
            // 入力不可
            this.MulticastConsNo_textBox.Enabled = ( mode < 2 );

            // サーバーメンテナンス連番にフォーカスをセット
            this.McastGidnceMainteCd_comboBox.Focus();
            this.ActiveControl = this.McastGidnceMainteCd_comboBox;
            //this.MulticastConsNo_textBox.SelectAll();
		}

		#endregion

		#region ■保存処理

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <returns>保存結果</returns>
		/// <remarks>
		/// <br>Note       : 保存処理を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private bool SaveProc()
		{
			bool result = false;
			string errMsg = "";

			// 入力チェック
			Control control = null;
			string  message = null;
			if( ! this.ScreenDataCheck( ref control, ref message ) ) {
				MessageBox.Show( this, message, "入力チェック", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1 );

				if( control != null ) {
					control.Focus();
				}

				return result;
			}

			ChangGidncWork       changGidncWork        = null;
			List<ChgGidncDtWork> chgGidncDtWorkList    = null;
			if( this._dataIndex >= 0 ) {
				string key = this._dataSet.ChangGidnc[ this._dataIndex ].UniqueKey;
				changGidncWork = this._changGidncCache[ key ].Clone();
                try
                {
                    chgGidncDtWorkList = new List<ChgGidncDtWork>(this._chgGidncDtCache[key].Values);
                    for (int ix = 0; ix < chgGidncDtWorkList.Count; ix++)
                    {
                        chgGidncDtWorkList[ix] = chgGidncDtWorkList[ix].Clone();
                    }
                }
                catch (Exception e) {
                }
			}

			// 画面データの取得
			List<ChgGidncDtWork> chgGidncDtWorkDelList = new List<ChgGidncDtWork>();    // 削除リスト
			this.GetChangGidncWorkFormScreen( ref changGidncWork, ref chgGidncDtWorkList, ref chgGidncDtWorkDelList );

			// ファイルをコピー
			if( this.CopyAnothersheetFile_checkBox.Checked ) {
				string copyMessage = "";
				if( ! this.CopyNewAnothersheetFile( ref copyMessage ) ) {
					if( String.IsNullOrEmpty( copyMessage ) ) {
						copyMessage = "ファイルのコピーに失敗しました。\r\n\r\n登録を続行しますか？";
					}
					else {
						copyMessage = "ファイルのコピーに失敗しました。\r\n\r\n" + copyMessage + "\r\n\r\n登録を続行しますか？";
					}
					DialogResult res = MessageBox.Show( this, copyMessage, "保存確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1 );
					if( res == DialogResult.Yes ) {
					}
					else {
						MessageBox.Show( this, "保存処理を中断しました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1 );
						return result;
					}
				}
			}

			// DBアクセスクラスのインスタンスを作成
			if( this._changePgGuideDBAcs == null ) {
				this._changePgGuideDBAcs = new ChangePgGuideDBAcs();
			}

			// 保存実行
			int status = this._changePgGuideDBAcs.WriteChangGidnc( ref changGidncWork, ref chgGidncDtWorkList, chgGidncDtWorkDelList, out errMsg );
			switch( status ) {
				// 登録成功
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					// DataSetを更新
					this.SetChangGidncWorkToDataSet( changGidncWork, this._dataIndex );

					// キーを取得
					string updKey = this.GetChangGidncKey( changGidncWork );

                    ChgGidncDtCacheDtl chgGidncDtCacheDtl = null;
					// キーが既に登録済み
					if( this._chgGidncDtCache.ContainsKey( updKey ) ) {
						chgGidncDtCacheDtl = this._chgGidncDtCache[ updKey ];
					}
					else {
                        chgGidncDtCacheDtl = new ChgGidncDtCacheDtl();
						this._chgGidncDtCache.Add( updKey, chgGidncDtCacheDtl );
					}
					chgGidncDtCacheDtl.Clear();

					// 変更案内明細ワークリストを Cache に格納
					foreach( ChgGidncDtWork chgGidncDtWork in chgGidncDtWorkList ) {
						if( chgGidncDtCacheDtl.ContainsKey( chgGidncDtWork.MulticastSubCode ) ) {
							chgGidncDtCacheDtl[ chgGidncDtWork.MulticastSubCode ] = chgGidncDtWork;
						}
						else {
							chgGidncDtCacheDtl.Add( chgGidncDtWork.MulticastSubCode, chgGidncDtWork );
						}
					}

					result = true;
					break;
				}
				// キー重複
				case ( int )ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					MessageBox.Show( this, "コードが既に使用されています。", "登録失敗", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1 );
					// サーバーメンテナンス連番にフォーカスをセット
					this.MulticastConsNo_textBox.Focus();
					break;
				}
				// 他端末更新
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					MessageBox.Show( this, "他端末にて更新済みです。", "登録失敗", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1 );
					break;
				}
				// 他端末削除
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					MessageBox.Show( this, "他端末にて削除済です。", "登録失敗", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1 );
					break;
				}
				// エラー
				default:
				{
					MessageBox.Show( this, "データの登録中にエラーが発生しました。 ST=" + status.ToString(), "登録失敗", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1 );
					break;
				}
			}

			return result;
		}

		#endregion

		#region ■入力チェック

		/// <summary>
		/// 入力チェック
		/// </summary>
		/// <param name="control">対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>チェックの可否</returns>
		/// <remarks>
		/// <br>Note       : 画面の入力チェックを行います。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2008.01.21</br>
		/// </remarks>
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
			bool result = true;

            //メンテナンス区分
            //ComboItem<int> mcastOfferDivCd = this.McastGidnceMainteCd_comboBox.SelectedItem as ComboItem<int>; // Del 2008.01.30 Maki
			//Regex multicastVersionRegex = new Regex( "^[0-9]{1,5}\\.[0-9]{1,5}\\.[0-9]{1,5}\\.[0-9]{1,5}$" );  //Del 2008.01.28 Kouguchi
			Regex multicastVersionRegex = new Regex( "^[0-9]{1}-[0-9]{8}$" );  //Add 2008.01.28 Kouguchi

            //メンテナンス連番
            int multicastConsNo = 0;
			if( ! Int32.TryParse( this.MulticastConsNo_textBox.Text.TrimEnd(), out multicastConsNo ) ) 
            {
				multicastConsNo = 0;
			}


			if( multicastConsNo == 0 ) {
				message = "メンテナンス連番を入力してください。";
				control = this.MulticastConsNo_textBox;
				result  = false;
			}

			return result;
		}

		#endregion

		#region ■CopyNewAnothersheetFile

		/// <summary>
		/// 別紙フィル存在有無チェック&コピー処理
		/// </summary>
		/// <returns>結果</returns>
		private bool CopyNewAnothersheetFile( ref string message )
		{
			bool result = true;

			try {
				foreach( ListViewItem item in this.AnothersheetFileName_listView.Items ) {
					string pathFrom = item.SubItems[ 1 ].Text.Trim();
					string pathTo   = Path.Combine( this._setting.AnothersheetFileDirPath, item.SubItems[ 0 ].Text.Trim() );

					if( pathFrom == String.Empty ) {
						continue;
					}

					// コピー元ファイルが存在しない場合
					if( ! File.Exists( pathFrom ) ) {
						result = false;
						DialogResult res = MessageBox.Show( this, "コピー元ファイル\r\n「" + pathFrom + "」\r\nは存在しません。\r\n\r\n処理を続行しますか？", "ファイルコピー", 
							MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
						if( res == DialogResult.Yes ) {
							continue;
						}
						else {
							message = "コピーが中断されました。";
							break;
						}
					}

					bool runCopy = true;

					// 既にコピー先にファイルが存在する場合
					if( File.Exists( pathTo ) ) {
						DialogResult res = MessageBox.Show( this, 
							"コピー先ファイル\r\n「" + pathTo + "」\r\nは既に存在します。\r\n\r\n上書きしてもよろしいですか？", 
							"確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1 );
						if( res == DialogResult.Yes ) {
						}
						else if( res == DialogResult.No ) {
							runCopy = false;
						}
						else {
							message = "コピーが中断されました。";
							result = false;
							break;
						}
					}

					if( runCopy ) {
						// コピー実行
						try {
							File.Copy( pathFrom, pathTo, true );
						}
						catch( Exception ex ) {
							result = false;
							DialogResult res = MessageBox.Show( this, 
								"コピー元ファイル\r\n「" + pathFrom + "」\r\nをコピー中にエラーが発生しました。\r\n" + 
								ex.Message + "\r\n\r\n処理を続行しますか？", "ファイルコピー", 
								MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
							if( res == DialogResult.Yes ) {
								continue;
							}
							else {
								message = "コピーが中断されました。";
								break;
							}
						}
					}
				}
			}
			catch( Exception ex ) {
				MessageBox.Show( this, ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
				message = "コピー中にエラーが発生しました。";
				result = false;
			}

			return result;
		}

		#endregion

		#endregion


		#region << INSChangeInfoEditor メンバ >>

		#region ●選択データインデックスプロパティ

		/// <summary>
		/// 選択データインデックスプロパティ
		/// </summary>
		public int DataIndex
		{
			get {
				return this._dataIndex;
			}
			set {
				this._dataIndex = value;
			}
		}

		#endregion

		#region ●新規追加許可プロパティ

		/// <summary>
		/// 新規追加許可プロパティ
		/// </summary>
		public bool AllowNew
		{
			get {
				return this._allowNew;
			}
		}

		#endregion

		#region ●削除許可プロパティ

		/// <summary>
		/// 削除許可プロパティ
		/// </summary>
		public bool AllowDelete
		{
			get {
				return this._allowDelete;
			}
		}

		#endregion

		#region ●クローズ可否プロパティ

		/// <summary>
		/// クローズ可否プロパティ
		/// </summary>
		public bool CanClose
		{
			get {
				return this._canClose;
			}
			set {
				this._canClose = value;
			}
		}

		#endregion

		#region ■データセット取得処理

		/// <summary>
		/// データセット取得処理
		/// </summary>
		/// <param name="dataSet">データセット</param>
		/// <param name="dataMember">データメンバー</param>
		public void GetDataSet( ref DataSet dataSet, ref string dataMember )
		{
			dataSet    = this._dataSet;
			dataMember = this._dataSet.ChangGidnc.TableName;
		}

		#endregion

		#region ■オプションツール取得処理

		/// <summary>
		/// オプションツール取得処理
		/// </summary>
		/// <param name="optionTools">オプションツール</param>
		public void GetOptionTools( ref SortedList<string,ToolStripItem> optionTools )
		{
			optionTools = new SortedList<string,ToolStripItem>();

			ToolStripMenuItem settingMenuItem = new ToolStripMenuItem( "設定(&S)" );
			optionTools.Add( ctOptionToolKey_Setting, settingMenuItem );
		}

		#endregion

		#region ■グリッド列外観設定取得処理

		/// <summary>
		/// グリッド列外観設定取得処理
		/// </summary>
		/// <returns>グリッド列外観設定ディクショナリー</returns>
		public Dictionary<string,GridColAppearance> GetGridColAppearance()
		{
			Dictionary<string,GridColAppearance> gridColAppearanceDictionary = new Dictionary<string,GridColAppearance>();

			int displayIndex = 0;
            gridColAppearanceDictionary.Add( "McastGidncCntntsNm",
                new GridColAppearance( displayIndex++, "案内区分", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black));
            gridColAppearanceDictionary.Add( "ProductCode", 
				new GridColAppearance( displayIndex++, "パッケージ区分", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );
            gridColAppearanceDictionary.Add( "MulticastConsNo",
                new GridColAppearance( displayIndex++, "メンテナンス連番", DataGridViewContentAlignment.MiddleRight, "", Color.Black, Color.Black));
            gridColAppearanceDictionary.Add( "McastGidncMainteNm",
                new GridColAppearance( displayIndex++, "メンテナンス区分", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );
            gridColAppearanceDictionary.Add( "ServerMainteStScdlNm",
                new GridColAppearance( displayIndex++, "開始予定日時", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );
            gridColAppearanceDictionary.Add( "ServerMainteEdScdlNm",
                new GridColAppearance( displayIndex++, "終了予定日時", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );
            gridColAppearanceDictionary.Add( "ServerMainteStTimeNm",
                new GridColAppearance( displayIndex++, "開始日時", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );
            gridColAppearanceDictionary.Add( "ServerMainteEdTimeNm",
                new GridColAppearance( displayIndex++, "終了日時", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );

			return gridColAppearanceDictionary;
		}

		#endregion

		#region ■検索処理

		/// <summary>
		/// 検索処理
		/// </summary>
		/// <returns>STATUS</returns>
		public int Search()
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

			try {
				if( this._changePgGuideDBAcs == null ) {
					this._changePgGuideDBAcs = new ChangePgGuideDBAcs();
				}

				// テーブル・キャッシュをクリア
				this._dataSet.ChangGidnc.Clear();
				this._changGidncCache.Clear();
				this._chgGidncDtCache.Clear();

				List<ChangGidncWork> changGidncWorkList = new List<ChangGidncWork>();    // 変更案内ワークリスト
				List<ChgGidncDtWork> chgGidncDtWorkList = new List<ChgGidncDtWork>();    // 変更案内明細ワークリスト
				int                  totalCount         = 0;                             // 総件数
				string               errMsg             = "";                            // エラーメッセージ

				// 検索パラメータ生成
                ChangGidncParaWork changGidncParaWork   = new ChangGidncParaWork();
                changGidncParaWork.McastGidncCntntsCd   = 2;     // 案内区分(データメンテナンス)
                // 2008.11.20 Update >>>
				//changGidncParaWork.ProductCode          = ConstantManagement_NS_MGD.ProductCode.SF;
                changGidncParaWork.ProductCode = ConstantManagement_NS_MGD.ProductCode.PM;
                // 2008.11.20 Update <<<
                // 自動車パッケージ
				changGidncParaWork.McastOfferDivCd      = -2;    // 配信提供区分・更新グループコード・企業コードを無視するために指定
				changGidncParaWork.MulticastSystemDivCd = -1;    // 全システム区分

				// DB検索実行
				status = this._changePgGuideDBAcs.ChangGidnc( changGidncParaWork, out changGidncWorkList, out chgGidncDtWorkList, 0, Int32.MaxValue, out totalCount, out errMsg );
				switch( status ) {
					case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// 変更案内ワークリストをDataSetに展開し、Cache に格納
						foreach( ChangGidncWork changGidncWork in changGidncWorkList ) {
							this.SetChangGidncWorkToDataSet( changGidncWork, -1 );
						}

						// 変更案内明細ワークリストを Cache に格納
						foreach( ChgGidncDtWork chgGidncDtWork in chgGidncDtWorkList ) {
							// キーを取得
							string key = this.GetChangGidncKey( chgGidncDtWork );

							ChgGidncDtCacheDtl chgGidncDtCacheDtl = null;
							// キーが既に登録済み
							if( this._chgGidncDtCache.ContainsKey( key ) ) {
								chgGidncDtCacheDtl = this._chgGidncDtCache[ key ];
							}
							else {
                                chgGidncDtCacheDtl = new ChgGidncDtCacheDtl();
								this._chgGidncDtCache.Add( key, chgGidncDtCacheDtl );
							}

							if( ! chgGidncDtCacheDtl.ContainsKey( chgGidncDtWork.MulticastSubCode ) ) {
								chgGidncDtCacheDtl.Add( chgGidncDtWork.MulticastSubCode, chgGidncDtWork );
							}
						}
						break;
					}
					case ( int )ConstantManagement.DB_Status.ctDB_EOF:
					case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						break;
					}
					default:
					{
						// TODO : エラー表示
						MessageBox.Show( this, errMsg, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
						break;
					}
				}
			}
			catch( Exception ex ) {
				// TODO : エラーメッセージ表示
				MessageBox.Show( this, ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
			}

			return status;
		}

		#endregion

		#region ■削除処理

		/// <summary>
		/// 削除処理
		/// </summary>
		/// <returns>STATUS</returns>
		public int Delete()
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;

			if( this._dataIndex < 0 ) {
				return status;
			}

			ChangGidncWork changGidncWork = null;
			// キーを取得
			string key = this._dataSet.ChangGidnc[ this._dataIndex ].UniqueKey;
			// 選択されているオブジェクトを取得
			if( this._changGidncCache.ContainsKey( key ) ) {
				changGidncWork = this._changGidncCache[ key ];
			}

			if( changGidncWork == null ) {
				return status;
			}

			string errMsg = "";

			// 削除実行
			status = this._changePgGuideDBAcs.DeleteChangGidnc( changGidncWork, out errMsg );
			if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
				// キャッシュから削除
				this._changGidncCache.Remove( key );
				this._chgGidncDtCache.Remove( key );
				// DataTable から削除
				this._dataSet.ChangGidnc[ this._dataIndex ].Delete();
			}
			else {
				MessageBox.Show( this, errMsg, "削除失敗", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
			}

			return status;
		}

		#endregion

		#region ■オプションツールコマンド処理

		/// <summary>
		/// オプションツールコマンド処理
		/// </summary>
		/// <param name="key">コマンドキー</param>
		/// <param name="owner">System.Forms.IWin32Window を実装し、このフォームを所有するトップレベル ウィンドウを表すオブジェクト。</param>
		public void OptionToolCommand( string key, IWin32Window owner )
		{
			if( this._settingForm == null ) {
				this._settingForm = new MulticastInfoSettingForm();
			}

			// パラメータセット
			this._settingForm.Setting = this._setting.Clone();
			// 設定画面起動
			DialogResult result = this._settingForm.ShowDialog( owner );
			if( result == DialogResult.OK ) {
				this._setting = this._settingForm.Setting;
				// 保存
				MulticastInfoEditorSetting.Save( ctSetting_FileName, this._setting );
			}
		}

		#endregion

		#endregion


		#region << Public Methods >>

		#endregion


		#region << Control Eventts >>

		#region ■Load イベント (MulticastInfoEditor)

		/// <summary>
		/// Load イベント (MulticastInfoEditor)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームが初めて表示されるときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void MulticastInfoEditor_Load( object sender, EventArgs e )
		{
			// 画面初期化
			this.ScreenInitialize();
		}

		#endregion

		#region ■FormClosing イベント (MulticastInfoEditor)

		/// <summary>
		/// FormClosing イベント (MulticastInfoEditor)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームが閉じる前に発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void MulticastInfoEditor_FormClosing( object sender, FormClosingEventArgs e )
		{
			if( ( e.CloseReason == CloseReason.UserClosing ) && 
				( ! this._canClose ) ) {
				e.Cancel = true;
				this.Hide();
			}

			this._dataIndexBuf = -2;
		}

		#endregion

		#region ■VisibleChanged イベント (MulticastInfoEditor)

		/// <summary>
		/// VisibleChanged イベント (MulticastInfoEditor)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Visible プロパティの値が変更された場合に発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void MulticastInfoEditor_VisibleChanged( object sender, EventArgs e )
		{
			if( this.Visible == false ) {
				return;
			}

			if( this._dataIndex == this._dataIndexBuf ) {
				return;
			}

			// 画面をクリア
			this.ScreenClear( false );

			// 画面表示
			this.Initial_timer.Enabled = true;
		}

		#endregion

		#region ■Tick イベント (Initial_timer)

		/// <summary>
		/// Tick イベント (Initial_timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 指定したタイマの間隔が経過し、タイマが有効である場合に発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void Initial_timer_Tick( object sender, EventArgs e )
		{
			this.Initial_timer.Enabled = false;

			this.ScreenReconstruction();
		}

		#endregion

		#region ■Click イベント (Save_toolStripButton)

		/// <summary>
		/// Click イベント (Save_toolStripButton)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void Save_toolStripButton_Click( object sender, EventArgs e )
		{
			if( ! this.SaveProc() ) {
				return;
			}

			// 新規の場合は連続入力を可能にする
			if( this._dataIndex < 0 ) {
				// 表示データを取得
				ChangGidncWork       wkChangGidncWork     = new ChangGidncWork();
				List<ChgGidncDtWork> wkChgGidncDtWorkList = new List<ChgGidncDtWork>();
				List<ChgGidncDtWork> wkDelList              = new List<ChgGidncDtWork>();
				this.GetChangGidncWorkFormScreen( ref wkChangGidncWork, ref wkChgGidncDtWorkList, ref wkDelList );

				// 画面をクリア
				this.ScreenClear( true );

				// 連続入力用に値をセット
				ChangGidncWork changGidncWork           = new ChangGidncWork();
                // 案内内容区分
                changGidncWork.McastGidncCntntsCd       = wkChangGidncWork.McastGidncCntntsCd;  //2008.01.28 Kouguchi
                // パッケージ区分
				changGidncWork.ProductCode              = wkChangGidncWork.ProductCode;
                // 配信案内 バージョン区分
                changGidncWork.McastGidncVersionCd      = wkChangGidncWork.McastGidncVersionCd;
                // 配信提供区分
				changGidncWork.McastOfferDivCd          = wkChangGidncWork.McastOfferDivCd;
                // 更新グループコード
				changGidncWork.UpdateGroupCode          = wkChangGidncWork.UpdateGroupCode;
                // 企業コード
				changGidncWork.EnterpriseCode           = wkChangGidncWork.EnterpriseCode;
				// メンテナンス連番
				changGidncWork.MulticastConsNo          = wkChangGidncWork.MulticastConsNo;
				// 配信日
                changGidncWork.MulticastDate            = wkChangGidncWork.MulticastDate;
				// サポート公開日時
				changGidncWork.SupportOpenTime          = 0;
				// ユーザー公開日時
				changGidncWork.CustomerOpenTime         = 0;
                // メンテナンス開始予定日時
                changGidncWork.ServerMainteStScdl       = wkChangGidncWork.ServerMainteStScdl;
                // メンテナンス終了予定日時
                changGidncWork.ServerMainteEdScdl       = wkChangGidncWork.ServerMainteEdScdl;
                // メンテナンス開始日時
                changGidncWork.ServerMainteStTime       = wkChangGidncWork.ServerMainteStTime;
                // メンテナンス終了日時
                changGidncWork.ServerMainteEdTime       = wkChangGidncWork.ServerMainteEdTime;
                // 配信案内 新規・改良区分(サーバーメンテ時は固定で「1」)
                changGidncWork.McastGidncNewCustmCd     = 1;
                // 配信案内 メンテ区分
                changGidncWork.McastGidncMainteCd       = wkChangGidncWork.McastGidncMainteCd;
                // システム区分(サーバーメンテ時は固定で「0」)
				changGidncWork.SystemDivCd              = 0;
				// メンテナンス内容
                changGidncWork.Guidance1                = wkChangGidncWork.Guidance1;
                // 地域
                changGidncWork.Area                     = "";

                ChangGidncWork changGidncWorkWk         = new ChangGidncWork();
                changGidncWorkWk.ProductCode            = changGidncWork.ProductCode;
                List<ChgGidncDtWork> chgGidncDtWorkList = new List<ChgGidncDtWork>();
				// 画面にデータを表示
                this.SetChangGidncWorkToScreen(changGidncWorkWk, chgGidncDtWorkList, this._dataIndex);

				// クローン作成
				this._changGidncWorkClone     = changGidncWork.Clone();
				this._chgGidncDtWorkListClone = new List<ChgGidncDtWork>();
				// 画面のデータを取得
				List<ChgGidncDtWork> delList  = new List<ChgGidncDtWork>();
				this.GetChangGidncWorkFormScreen( ref this._changGidncWorkClone, ref this._chgGidncDtWorkListClone, ref delList );

				// 画面入力制御処理
				this.ScreenInputPermissionControl( 1 );

				this._dataIndex = this._dataIndexBuf = -1;
			}
			// 更新の場合は閉じる
			else {
				// 保存に成功したので閉じる
				this.DialogResult = DialogResult.OK;

				this.Close();
			}
		}

		#endregion

		#region ■Click イベント (Cancel_toolStripButton)

		/// <summary>
		/// Click イベント (Cancel_toolStripButton)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void Cancel_toolStripButton_Click( object sender, EventArgs e )
		{
			// 入力データを取得
			ChangGidncWork       changGidncWorkChanged     = this._changGidncWorkClone.Clone();
			List<ChgGidncDtWork> chgGidncDtWorkListChanged = new List<ChgGidncDtWork>( this._chgGidncDtWorkListClone );
			for( int ix = 0; ix < chgGidncDtWorkListChanged.Count; ix++ ) {
				chgGidncDtWorkListChanged[ ix ] = chgGidncDtWorkListChanged[ ix ].Clone();
			}

			List<ChgGidncDtWork> delList = new List<ChgGidncDtWork>();
			this.GetChangGidncWorkFormScreen( ref changGidncWorkChanged, ref chgGidncDtWorkListChanged, ref delList );

			bool isChanged = false;

			// 変更チェック
			if( ! changGidncWorkChanged.Equals( this._changGidncWorkClone ) ) {
				isChanged = true;
			}
			else if( chgGidncDtWorkListChanged.Count != this._chgGidncDtWorkListClone.Count ) {
				isChanged = true;
			}
			else if( delList.Count > 0 ) {
				isChanged = true;
			}
			else {
				for( int ix = 0; ix < chgGidncDtWorkListChanged.Count; ix++ ) {
					if( ! chgGidncDtWorkListChanged[ ix ].Equals( this._chgGidncDtWorkListClone[ ix ] ) ) {
						isChanged = true;
						break;
					}
				}
			}

			// 変更があった場合
			if( isChanged ) {
				DialogResult result = MessageBox.Show( this, "内容が変更されました。\r\n保存しますか？", "確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1 );
				switch( result ) {
					case DialogResult.Yes:
					{
						if( ! this.SaveProc() ) {
							return;
						}
						break;
					}
					case DialogResult.No:
					{
						break;
					}
					case DialogResult.Cancel:
					{
						return;
					}
				}
			}
			this.DialogResult = DialogResult.Cancel;

			this.Close();
		}

		#endregion

		#region ■Click イベント (CreateGuid_button)

		/// <summary>
		/// Click イベント (CreateGuid_button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void CreateGuid_button_Click( object sender, EventArgs e )
		{
			if( this.AnothersheetFileName_listView.SelectedItems.Count < 1 ) {
				return;
			}
			ListViewItem item = this.AnothersheetFileName_listView.SelectedItems[ 0 ];

			item.SubItems[ 0 ].Text = "Announce_" + Guid.NewGuid().ToString( "N" ) + ".pdf";
		}

		#endregion

		#region ■Click イベント (AddAnothersheetFileName_button)

		/// <summary>
		/// Click イベント (AddAnothersheetFileName_button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void AddAnothersheetFileName_button_Click( object sender, EventArgs e )
		{
			// ファイルを開く
			DialogResult result = this.Anothersheet_openFileDialog.ShowDialog( this );
			if( result == DialogResult.OK ) {
				string anothersheetFileName = "Announce_" + Guid.NewGuid().ToString( "N" ) + ".pdf";
				ListViewItem newItem = new ListViewItem( new string[] { anothersheetFileName, this.Anothersheet_openFileDialog.FileName } );
				newItem.StateImageIndex = 2;    // 追加アイコン
				this.AnothersheetFileName_listView.Items.Add( newItem );
			}
		}

		#endregion

		#region ■Click イベント (DelAnothersheetFileName_button)

		/// <summary>
		/// Click イベント (DelAnothersheetFileName_button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void DelAnothersheetFileName_button_Click( object sender, EventArgs e )
		{
			if( this.AnothersheetFileName_listView.SelectedIndices.Count < 1 ) {
				return;
			}
			int index = this.AnothersheetFileName_listView.SelectedIndices[ 0 ];

            // 削除確認
            DialogResult result = MessageBox.Show(
                this, "選択されている別紙ファイルを削除します。よろしいですか？", "確認",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result != DialogResult.Yes)
            {
                // 削除しない
                return;
            }

			this.AnothersheetFileName_listView.Items.RemoveAt( index );
		}

		#endregion

		#region ■AfterLabelEdit イベント (AnothersheetFileName_listView)

		/// <summary>
		/// AfterLabelEdit イベント (AnothersheetFileName_listView)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 項目のラベルがユーザーによって編集されると発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void AnothersheetFileName_listView_AfterLabelEdit( object sender, LabelEditEventArgs e )
		{
			if( e.Label == null ) {
				return;
			}
			// 空の場合はキャンセル
			if( e.Label.Trim() == String.Empty ) {
				e.CancelEdit = true;
			}
		}

		#endregion 

		#region ■BeforeLabelEdit イベント (AnothersheetFileName_listView)

		/// <summary>
		/// BeforeLabelEdit イベント (AnothersheetFileName_listView)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーが項目のラベルの編集を開始すると発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void AnothersheetFileName_listView_BeforeLabelEdit( object sender, LabelEditEventArgs e )
		{
		}

		#endregion

		#endregion

    }
}