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
	/// 変更案内(印字位置リリース)明細編集フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 変更案内(印字位置リリース)の明細の編集を行います。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.26</br>
    /// <br></br>
    /// <br>Update     : 2008.11.20 Sasaki PM用に変更</br>
    /// </remarks>
	public partial class McastPrintPointInfoEditor : Form, ISimpleMasterMaintenanceMulti
	{

		#region << Constructor >>

		/// <summary>
		/// 変更案内(印字位置リリース)の明細の編集フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 変更案内(印字位置リリース)の明細の編集フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
        public McastPrintPointInfoEditor()
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

		/// <summary>.NS配信案内一覧表示用DataSet</summary>
		private ChangGidncDataSet  _dataSet             = null;

		/// <summary>.NS配信案内DBアクセスクラス</summary>
		private ChangePgGuideDBAcs _changePgGuideDBAcs  = null;

		/// <summary>変更案内ワークキャッシュ</summary>
        private ChangGidncCache _changGidncCache        = null;
		/// <summary>変更案内明細ワークキャッシュ</summary>
        private ChgGidncDtCache _chgGidncDtCache        = null;

		/// <summary>.NS配信案内設定画面設定クラス</summary>
		private MulticastInfoEditorSetting _setting     = null;

		/// <summary>.NS配信案内設定画面設定フォーム</summary>
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
		private const string ctSetting_FileName      = "NSChangeInfoEditor_McastPrintPointInfo.xml";

		#endregion

		#region << Private Methods >>

		#region ■画面初期化処理

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期化を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
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
            this.McastGidncCntntsCd_comboBox.Items.Add( new ComboItem<int>( 3, ConstantManagement_NS_MGD.GetMcastGidncCntntsCdNm(3) ) );  //Add 2008.01.28 Kouguchi

			// プログラム変更区分
			this.ProgramChgDivCd_comboBox.Items.Clear();
			this.ProgramChgDivCd_comboBox.Items.Add( new ComboItem<int>( 1, "新規" ) );
			this.ProgramChgDivCd_comboBox.Items.Add( new ComboItem<int>( 2, "改良" ) );
			this.ProgramChgDivCd_comboBox.Items.Add( new ComboItem<int>( 3, "障害" ) );

			// 配信システム区分(自動車パッケージ)
			this.MulticastSystemDivCd_comboBox.Items.Clear();
            // 2008.11.20 Update >>>
            //foreach( int multicastSystemDivCd in Enum.GetValues( typeof( ConstantManagement_NS_MGD.SystemDiv) ) ) {
            //    this.MulticastSystemDivCd_comboBox.Items.Add( 
            //        new ComboItem<int>( multicastSystemDivCd,
            //        ConstantManagement_NS_MGD.GetMulticastSystemDivNm( ConstantManagement_NS_MGD.ProductCode.SF, multicastSystemDivCd ) ) );
            //}

            foreach (int multicastSystemDivCd in Enum.GetValues(typeof(ConstantManagement_NS_MGD.SystemDiv)))
            {
                this.MulticastSystemDivCd_comboBox.Items.Add(
                    new ComboItem<int>(multicastSystemDivCd,
                    ConstantManagement_NS_MGD.GetMulticastSystemDivNm(ConstantManagement_NS_MGD.ProductCode.PM, multicastSystemDivCd)));
            }
            // 2008.11.20 Update <<<
        }

		#endregion

		#region ■キー文字列作成処理

		/// <summary>
		/// キー文字列作成処理
		/// </summary>
		/// <param name="productCode">パッケージ区分</param>
		/// <param name="mcastOfferDivCd">配信提供区分</param>
		/// <param name="UpdateGroupCode">更新グループコード</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="multicastVersion">配信バージョン</param>
		/// <param name="multicastConsNo">連番</param>
		/// <returns>キー文字列</returns>
		/// <remarks>
		/// <br>Note       : キー文字列の作成を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.30</br>
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
		/// <br>Date       : 2008.01.16</br>
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
		/// <br>Date       : 2008.01.16</br>
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
		/// <br>Date       : 2008.01.16</br>
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
            row.McastGidncCntntsNm   = ConstantManagement_NS_MGD.GetMcastGidncCntntsCdNm(changGidncWork.McastGidncCntntsCd);
            // パッケージ区分
			row.ProductCode          = changGidncWork.ProductCode;
			// 連番
			row.MulticastConsNo      = changGidncWork.MulticastConsNo;
			// リリース日
			row.MulticastDate        = changGidncWork.MulticastDate;
			// システム区分
			row.MulticastSystemDivCd = changGidncWork.SystemDivCd;
			// システム区分名称
			row.MulticastSystemDivNm = ConstantManagement_NS_MGD.GetMulticastSystemDivNm( changGidncWork.ProductCode, changGidncWork.SystemDivCd );

            //Del ↓↓↓ 2008.01.28 Kouguchi
            //// 配信プログラム名称
			//row.Guidance             = changGidncWork.Guidance1;
            //del ↑↑↑ 2008.01.28 Kouguchi

            //Add ↓↓↓ 2008.01.28 Kouguchi
            // 帳票名称
            row.Guidance             = changGidncWork.Guidance1;
            // 地域
            row.Area                 = changGidncWork.Area;
            //Add ↑↑↑ 2008.01.28 Kouguchi

			// キーを取得
			string key = this.GetChangGidncKey( changGidncWork );

			// ユニークキー
			row.UniqueKey            = key;

			// キャッシュを更新
			if( this._changGidncCache.ContainsKey( key ) ) {
                this._changGidncCache[key] = changGidncWork;
			}
			else {
                this._changGidncCache.Add(key, changGidncWork);
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
			// 連番
			this.MulticastConsNo_textBox.Clear();
			// リリース日
			this.MulticastDate_maskedTextBox.Clear();
			// サポート公開日時
			this.SupportOpenTime_maskedTextBox.Clear();
			// ユーザー公開日時
			this.CustomerOpenTime_maskedTextBox.Clear();
			// 新規・改良区分
			this.ProgramChgDivCd_comboBox.SelectedIndex = 0;
			// システム区分
			this.MulticastSystemDivCd_comboBox.SelectedIndex = 0;
			// 帳票名称
			this.Guidance_textBox.Clear();
            // 地域(都道府県)
            this.Area_textBox.Clear();
            // 変更内容
			this.ChangeContents_textBox.Clear();
		}

		#endregion

		#region ■連番最終番号取得処理

		/// <summary>
		/// 連番最終番号取得処理
		/// </summary>
        /// <param name="mcastGidncCntntsCd">案内区分</param>
		/// <param name="productCode">パッケージ区分</param>
		/// <param name="mcastOfferDivCd">配信提供区分</param>
		/// <param name="updateGroupCode">更新グループコード</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="multicastVersionZeroSup">配信バージョン</param>
		/// <returns>連番最終番号</returns>
		private int GetLastMulticastConsNo(int mcastGidncCntntsCd, string productCode, int mcastOfferDivCd, 
			string updateGroupCode, string enterpriseCode, string multicastVersionZeroSup )
		{
			int lastMulticastConsNo = 0;

			// 最終番号取得
			string expression = String.Format( "MAX( {0} )", this._dataSet.ChangGidnc.MulticastConsNoColumn.ColumnName );
			string filter     =
                String.Format( "{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}' AND {6} = '{7}' AND {8} = '{9}' AND {10} = '{11}'",
                this._dataSet.ChangGidnc.McastGidncCntntsCdColumn.ColumnName, mcastGidncCntntsCd,
				this._dataSet.ChangGidnc.ProductCodeColumn.ColumnName, productCode, 
				this._dataSet.ChangGidnc.McastOfferDivCdColumn.ColumnName, mcastOfferDivCd, 
				this._dataSet.ChangGidnc.UpdateGroupCodeColumn.ColumnName, updateGroupCode, 
				this._dataSet.ChangGidnc.EnterpriseCodeColumn.ColumnName, enterpriseCode, 
				this._dataSet.ChangGidnc.MulticastVersionColumn.ColumnName, multicastVersionZeroSup );
			object multicastConsNoObj = this._dataSet.ChangGidnc.Compute( expression, filter );
			if( ( multicastConsNoObj != null ) && 
				( multicastConsNoObj != DBNull.Value ) && 
				( multicastConsNoObj is int ) ) {
				lastMulticastConsNo = ( int )multicastConsNoObj;
			}

			return lastMulticastConsNo + 1;
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
                this.SetChangGidncWorkToScreen(changGidncWork, chgGidncDtWorkList, this._dataIndex);

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
                this.SetChangGidncWorkToScreen(changGidncWork, chgGidncDtWorkList, this._dataIndex);

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
				List<ChgGidncDtWork> delList  = new List<ChgGidncDtWork>();
				this.GetChangGidncWorkFormScreen( ref this._changGidncWorkClone, ref this._chgGidncDtWorkListClone, ref delList );

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
			// 連番
            if (dataIndex < 0)
            {
                // 新規の場合
                int multicastConsNo                         = (this._changGidncCache.Values[this._changGidncCache.Count - 1].MulticastConsNo) + 1;
                this.MulticastConsNo_textBox.Text           = multicastConsNo.ToString();
            }
            else {
                this.MulticastConsNo_textBox.Text           = changGidncWork.MulticastConsNo.ToString();
            }
			// リリース日
			if( changGidncWork.MulticastDate == DateTime.MinValue ) {
				this.MulticastDate_maskedTextBox.Clear();
			}
			else {
				this.MulticastDate_maskedTextBox.Text       = changGidncWork.MulticastDate.ToString( this.MulticastDate_maskedTextBox.FormatProvider );
			}
			// サポート公開日時
			if( changGidncWork.SupportOpenTime == 0 ) {
				this.SupportOpenTime_maskedTextBox.Clear();
			}
			else {
				this.SupportOpenTime_maskedTextBox.Text     = changGidncWork.SupportOpenTime.ToString();
			}
			// ユーザー公開日時
			if( changGidncWork.CustomerOpenTime == 0 ) {
				this.CustomerOpenTime_maskedTextBox.Clear();
			}
			else {
				this.CustomerOpenTime_maskedTextBox.Text    = changGidncWork.CustomerOpenTime.ToString();
			}
			// 新規・改良区分
			this.ProgramChgDivCd_comboBox.SelectedItem      = new ComboItem<int>( changGidncWork.McastGidncNewCustmCd );
			// システム区分
			this.MulticastSystemDivCd_comboBox.SelectedItem = new ComboItem<int>( changGidncWork.SystemDivCd );
			// 帳票名称
			this.Guidance_textBox.Text                      = changGidncWork.Guidance1;
            // 地域
            this.Area_textBox.Text                          = changGidncWork.Area;  //Add 2008.01.28 Kouguchi


			// 明細ありの場合
			if( ( chgGidncDtWorkList != null ) && ( chgGidncDtWorkList.Count > 0 ) ) 
            {
				StringBuilder changeContents       = new StringBuilder();

				foreach( ChgGidncDtWork chgGidncDtWork in chgGidncDtWorkList ) 
                {
					// 変更内容
					if( ! String.IsNullOrEmpty( chgGidncDtWork.ChangeContents ) ) 
                    {
						changeContents.Append( chgGidncDtWork.ChangeContents );
					}
				}
				// 変更内容
				this.ChangeContents_textBox.Text            = changeContents.ToString();
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
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
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
			// 連番
			int multicastConsNo = 0;
			if( Int32.TryParse( this.MulticastConsNo_textBox.Text, out multicastConsNo ) ) {
				changGidncWork.MulticastConsNo           = multicastConsNo;
			}
			else {
				changGidncWork.MulticastConsNo           = 0;
			}
			// リリース日
			if( ( this.MulticastDate_maskedTextBox.MaskCompleted ) && 
				( this.MulticastDate_maskedTextBox.ValidateText() != null ) ) {
				changGidncWork.MulticastDate             = ( DateTime )this.MulticastDate_maskedTextBox.ValidateText();
			}
			else {
				changGidncWork.MulticastDate             = DateTime.MinValue;
			}
			// サポート公開日時
			if( ( this.SupportOpenTime_maskedTextBox.MaskCompleted ) && 
				( this.SupportOpenTime_maskedTextBox.ValidateText() != null ) ) {
				changGidncWork.SupportOpenTime           = this.DateTimeToLongDate( ( DateTime )this.SupportOpenTime_maskedTextBox.ValidateText() );
			}
			else {
				changGidncWork.SupportOpenTime           = 0;
			}
			// ユーザー公開日時
			if( ( this.CustomerOpenTime_maskedTextBox.MaskCompleted ) && 
				( this.CustomerOpenTime_maskedTextBox.ValidateText() != null ) ) {
				changGidncWork.CustomerOpenTime          = this.DateTimeToLongDate( ( DateTime )this.CustomerOpenTime_maskedTextBox.ValidateText() );
			}
			else {
				changGidncWork.CustomerOpenTime          = 0;
			}
			// プログラム変更区分
            ComboItem<int> McastGidncNewCustmCd = this.ProgramChgDivCd_comboBox.SelectedItem as ComboItem<int>;
            if (McastGidncNewCustmCd == null) {
				changGidncWork.McastGidncNewCustmCd      = 0;
			}
			else {
                changGidncWork.McastGidncNewCustmCd      = McastGidncNewCustmCd.Value;
			}
			// システム区分
            ComboItem<int> SystemDivCd = this.MulticastSystemDivCd_comboBox.SelectedItem as ComboItem<int>;
            if (SystemDivCd == null) {
				changGidncWork.SystemDivCd               = 0;
			}
			else {
                changGidncWork.SystemDivCd               = SystemDivCd.Value;
			}
			// 帳票名称
            changGidncWork.Guidance1                     = this.Guidance_textBox.Text;
            // 地域
            changGidncWork.Area                          = this.Area_textBox.Text;  //Add 2008.01.28 Kouguchi

            // 画面上存在しない項目をセット
            // 配信案内 バージョン区分
            string multicastConsNoSt = multicastConsNo.ToString();
            string str = "";
            // バージョン区分の作成方法 "案内内容区分" + "-" + "8桁のメンテナンス連番"
            changGidncWork.McastGidncVersionCd = mcastGidncCntntsCd.Value.ToString() + "-" + str.PadLeft(8 - multicastConsNoSt.Length, '0') + multicastConsNoSt;

			// 変更内容を分割
			List<string> changeContentsList = new List<string>();
			string changeContents = this.ChangeContents_textBox.Text;

			while( changeContents.Length > 0 ) {
				int maxLengh = ( changeContents.Length > 500 ? 500 : changeContents.Length );
				// 変更内容リストに追加
				changeContentsList.Add( changeContents.Substring( 0, maxLengh ) );
				// 追加した分を取り除く
				changeContents = changeContents.Substring( maxLengh, changeContents.Length - maxLengh );
			}

			// 別紙ファイル名リスト
			//List<string> anothersheetFileNameList = new List<string>();

			// ループ回数を取得( プログラム配信案内明細ワークリストの件数、変更内容リストの件数、別紙ファイル名リストの件数の中での最大値 )
			//int loopCount = Math.Max( chgGidncDtWorkList.Count, Math.Max( changeContentsList.Count, anothersheetFileNameList.Count ) );
            int loopCount = Math.Max( chgGidncDtWorkList.Count, changeContentsList.Count );

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
				// 変更内容リストの件数の範囲内
				if( ix < changeContentsList.Count ) {
					chgGidncDtWork.ChangeContents = changeContentsList[ ix ];
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
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
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
			// 連番
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

		#region ■画面入力制御処理

		/// <summary>
		/// 画面入力制御処理
		/// </summary>
		/// <param name="mode">登録モード(0:新規, 1:連続新規, 2:更新</param>
		/// <remarks>
		/// <br>Note       : 画面の入力制御を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void ScreenInputPermissionControl( int mode )
		{
            // 入力不可
            this.MulticastConsNo_textBox.Enabled = ( mode < 2 );

            // リリース日にフォーカスをセット
            this.MulticastDate_maskedTextBox.Focus();
            this.ActiveControl = this.MulticastDate_maskedTextBox;
            this.MulticastDate_maskedTextBox.SelectAll();
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
                try {
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
					// 連番にフォーカスをセット
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
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.30</br>
		/// </remarks>
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
			bool result = true;

			//Regex multicastVersionRegex = new Regex( "^[0-9]{1,5}\\.[0-9]{1,5}\\.[0-9]{1,5}\\.[0-9]{1,5}$" );  //Del 2008.01.28 Kouguchi
			Regex multicastVersionRegex = new Regex( "^[0-9]{1}-[0-9]{8}$" );  //Add 2008.01.28 Kouguchi

            int multicastConsNo = 0;
			if( ! Int32.TryParse( this.MulticastConsNo_textBox.Text.TrimEnd(), out multicastConsNo ) ) 
            {
				multicastConsNo = 0;
			}
			
            if( multicastConsNo == 0 ) //TODO
            {
				message = "連番を入力してください。";
				control = this.MulticastConsNo_textBox;
				result  = false;
			}
			else 
            if( ( ! this.MulticastDate_maskedTextBox.MaskCompleted ) || ( this.MulticastDate_maskedTextBox.ValidateText() == null ) ) 
            {
				message = "リリース日を入力してください。";
				control = this.MulticastDate_maskedTextBox;
				result  = false;
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
				new GridColAppearance( displayIndex++, "連番", DataGridViewContentAlignment.MiddleRight, "", Color.Black, Color.Black ) );
			gridColAppearanceDictionary.Add( "MulticastDate", 
				new GridColAppearance( displayIndex++, "リリース日", DataGridViewContentAlignment.MiddleLeft, "yyyy年MM月dd日", Color.Black, Color.Black ) );
            gridColAppearanceDictionary.Add( "Area",
                new GridColAppearance( displayIndex++, "地域(都道府県)", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black));
            gridColAppearanceDictionary.Add( "MulticastSystemDivNm", 
				new GridColAppearance( displayIndex++, "システム区分", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );
            gridColAppearanceDictionary.Add( "Guidance", 
				new GridColAppearance( displayIndex++, "帳票名称", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );

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
                changGidncParaWork.McastGidncCntntsCd   = 3;     // 案内区分区分(印字位置リリース)
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
				ChangGidncWork       changGidncWork     = new ChangGidncWork();
                changGidncWork.McastGidncCntntsCd       = wkChangGidncWork.McastGidncCntntsCd;  //wkChangGidncWork.McastGidncCntntsCd;  //2008.01.28 Kouguchi
				changGidncWork.ProductCode              = wkChangGidncWork.ProductCode;
				changGidncWork.McastOfferDivCd          = wkChangGidncWork.McastOfferDivCd;
				changGidncWork.UpdateGroupCode          = wkChangGidncWork.UpdateGroupCode;
				changGidncWork.EnterpriseCode           = wkChangGidncWork.EnterpriseCode;

				// 配信バージョン
                changGidncWork.McastGidncVersionCd      = wkChangGidncWork.McastGidncVersionCd;
				// 連番
                changGidncWork.MulticastConsNo          = wkChangGidncWork.MulticastConsNo;
				// リリース日
				this.MulticastDate_maskedTextBox.Clear();
				changGidncWork.MulticastDate            = wkChangGidncWork.MulticastDate;
				// サポート公開日時
				this.SupportOpenTime_maskedTextBox.Clear();
				changGidncWork.SupportOpenTime          = wkChangGidncWork.SupportOpenTime;
				// ユーザー公開日時
				this.CustomerOpenTime_maskedTextBox.Clear();
				changGidncWork.CustomerOpenTime         = wkChangGidncWork.CustomerOpenTime;
				// 新規・改良区分
				this.ProgramChgDivCd_comboBox.SelectedIndex = 0;
                changGidncWork.McastGidncNewCustmCd     = wkChangGidncWork.McastGidncNewCustmCd;
				// システム区分
				this.MulticastSystemDivCd_comboBox.SelectedIndex = 0;
				changGidncWork.SystemDivCd              = wkChangGidncWork.SystemDivCd;
				// 帳票名称
				this.Guidance_textBox.Clear();
                changGidncWork.Guidance1                = wkChangGidncWork.Guidance1;
                // 地域
                this.Area_textBox.Clear();
                changGidncWork.Area                     = wkChangGidncWork.Area;

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

        #endregion
    }
}