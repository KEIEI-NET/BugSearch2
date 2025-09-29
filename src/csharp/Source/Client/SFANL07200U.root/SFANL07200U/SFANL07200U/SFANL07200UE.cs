using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ユーザー設定画面クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ユーザー設定情報を入力します。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.03.05</br>
	/// </remarks>
	public partial class SFANL07200UE : Form
	{
		#region Constructor
		/// <summary>
		/// ユーザー設定画面クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : ユーザー設定画面クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public SFANL07200UE()
		{
			InitializeComponent();

			this._imageList16									= IconResourceManagement.ImageList16;

			this._analysisChartSettingAcs						= new AnalysisChartSettingAcs();

			// 詳細表示初期値
			this.DetailDisplayInitialValue_ultraOptionSet.Value	= this._analysisChartSettingAcs.DetailDisplayInitialValue;
			// ポイントラベル表示初期値
			this.PointLabelInitialValue_ultraOptionSet.Value	= this._analysisChartSettingAcs.PointLabelInitialValue;
			// ポイントラベルフォントサイズ初期値
			this.PointLabelSize_tComboEditor.Value				= this._analysisChartSettingAcs.PointLabelSizeInitialValue;
			// ラベル角度初期値
			this.LabelVerticalInitialValue_ultraOptionSet.Value	= this._analysisChartSettingAcs.LabelVerticalInitialValue;
			// ラベル最大桁数初期値
			if (this._analysisChartSettingAcs.LabelMaxLengthInitialValue != -1)
			{
				this.LabelMaxLengthInitialValue_tNedit.SetInt(this._analysisChartSettingAcs.LabelMaxLengthInitialValue);
			}
			else
			{
				this.LabelMaxLengthInitialValue_tNedit.Clear();
			}
			// ラベルフォントサイズ初期値
			this.LabelSize_tComboEditor.Value					= this._analysisChartSettingAcs.LabelSizeInitialValue;
			// ３Ｄ／２Ｄ表示初期値
			this.View3D2DInitialValue_ultraOptionSet.Value		= this._analysisChartSettingAcs.View3D2DInitialValue;
		}
		#endregion

		#region Private Members
		private ImageList _imageList16 = null;
		private AnalysisChartSettingAcs _analysisChartSettingAcs = null;
		#endregion

		#region Control Events
		/// <summary>
		/// Form.Load イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		private void SFANL07200UE_Load(object sender, EventArgs e)
		{
			this.Ok_ultraButton.ImageList = this._imageList16;
			this.Cancel_ultraButton.ImageList = this._imageList16;
			this.Ok_ultraButton.Appearance.Image = Size16_Index.DECISION;
			this.Cancel_ultraButton.Appearance.Image = Size16_Index.BEFORE;

			// 詳細表示初期値
			this.DetailDisplayInitialValue_ultraOptionSet.Value = this._analysisChartSettingAcs.DetailDisplayInitialValue;
			this.DetailDisplayInitialValue_ultraOptionSet.FocusedIndex = this.DetailDisplayInitialValue_ultraOptionSet.CheckedIndex;
			// ポイントラベル表示初期値
			this.PointLabelInitialValue_ultraOptionSet.Value = this._analysisChartSettingAcs.PointLabelInitialValue;
			this.PointLabelInitialValue_ultraOptionSet.FocusedIndex = this.PointLabelInitialValue_ultraOptionSet.CheckedIndex;
			// ポイントラベルフォントサイズ初期値
			this.PointLabelSize_tComboEditor.Value = this._analysisChartSettingAcs.PointLabelSizeInitialValue;
			// ラベル角度初期値
			this.LabelVerticalInitialValue_ultraOptionSet.Value = this._analysisChartSettingAcs.LabelVerticalInitialValue;
			this.LabelVerticalInitialValue_ultraOptionSet.FocusedIndex = this.LabelVerticalInitialValue_ultraOptionSet.CheckedIndex;
			// ラベル最大桁数初期値
			if (this._analysisChartSettingAcs.LabelMaxLengthInitialValue != -1)
			{
				this.LabelMaxLengthInitialValue_tNedit.SetInt(this._analysisChartSettingAcs.LabelMaxLengthInitialValue);
			}
			else
			{
				this.LabelMaxLengthInitialValue_tNedit.Clear();
			}
			// ラベルフォントサイズ初期値
			this.LabelSize_tComboEditor.Value = this._analysisChartSettingAcs.LabelSizeInitialValue;
			// ３Ｄ／２Ｄ表示初期値
			this.View3D2DInitialValue_ultraOptionSet.Value = this._analysisChartSettingAcs.View3D2DInitialValue;
			this.View3D2DInitialValue_ultraOptionSet.FocusedIndex = this.View3D2DInitialValue_ultraOptionSet.CheckedIndex;
		}

		/// <summary>
		/// UltraButton.Click イベント（Ok_ultraButton）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		private void Ok_ultraButton_Click(object sender, EventArgs e)
		{
			// 詳細表示初期値
			this._analysisChartSettingAcs.DetailDisplayInitialValue			= (bool)this.DetailDisplayInitialValue_ultraOptionSet.Value;
			// ポイントラベル表示初期値
			this._analysisChartSettingAcs.PointLabelInitialValue			= (bool)this.PointLabelInitialValue_ultraOptionSet.Value;
			// ポイントラベルフォントサイズ初期値
			this._analysisChartSettingAcs.PointLabelSizeInitialValue		= (int)this.PointLabelSize_tComboEditor.SelectedItem.DataValue;
			// ラベル角度初期値
			this._analysisChartSettingAcs.LabelVerticalInitialValue			= (bool)this.LabelVerticalInitialValue_ultraOptionSet.Value;
			// ラベル最大桁数初期値
			if (this.LabelMaxLengthInitialValue_tNedit.DataText == string.Empty)
			{
				this._analysisChartSettingAcs.LabelMaxLengthInitialValue	= -1;
			}
			else
			{
				this._analysisChartSettingAcs.LabelMaxLengthInitialValue	= this.LabelMaxLengthInitialValue_tNedit.GetInt();
			}
			// ラベルフォントサイズ初期値
			this._analysisChartSettingAcs.LabelSizeInitialValue				= (int)this.LabelSize_tComboEditor.SelectedItem.DataValue;
			// ３Ｄ／２Ｄ表示初期値
			this._analysisChartSettingAcs.View3D2DInitialValue				= (bool)this.View3D2DInitialValue_ultraOptionSet.Value;

			this._analysisChartSettingAcs.Serialize();
		}
		#endregion

	}

	/// <summary>
	/// 分析チャート表示設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : シリアル化する分析チャート表示設定クラスです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.03.05</br>
	/// </remarks>
	[Serializable]
	public class AnalysisChartSetting
	{
		#region Constructor
		/// <summary>
		/// 分析チャート表示設定クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 分析チャート表示設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public AnalysisChartSetting()
		{
			this._detailDisplayInitialValue		= DEFAULT_DETAILDISPLAYINITIAL_VALUE;
			this._pointLabelInitialValue		= DEFAULT_POINTLABELINITIAL_VALUE;
			this._pointLabelSizeInitialValue	= DEFAULT_POINTLABELSIZEINITIAL_VALUE;
			this._labelVerticalInitialValue		= DEFAULT_LABELVERTICALINITIAL_VALUE;
			this._labelMaxLengthInitialValue	= DEFAULT_LABELMAXLENGTHINITIAL_VALUE;
			this._labelSizeInitialValue			= DEFAULT_LABELSIZEINITIAL_VALUE;
			this._view3D2DInitialValue			= DEFAULT_VIEW3D2DINITIAL_VALUE;
		}

		/// <summary>
		/// 分析チャート表示設定クラスコンストラクタ
		/// </summary>
		/// <param name="detailDisplayInitialValue">詳細表示初期値</param>
		/// <param name="pointLabelInitialValue">ポイントラベル表示初期値</param>
		/// <param name="pointLabelSizeInitialValue">ポイントラベルフォントサイズ初期値</param>
		/// <param name="labelVerticalInitialValue">ラベル角度初期値</param>
		/// <param name="labelMaxLengthInitialValue">ラベル最大桁数初期値</param>
		/// <param name="labelSizeInitialValue">ラベルフォントサイズ初期値</param>
		/// <param name="view3D2DInitialValue">３Ｄ／２Ｄ表示初期値</param>
		/// <remarks>
		/// <br>Note       : 分析チャート表示設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public AnalysisChartSetting(bool detailDisplayInitialValue, bool pointLabelInitialValue, int pointLabelSizeInitialValue, bool labelVerticalInitialValue, int labelMaxLengthInitialValue, int labelSizeInitialValue, bool view3D2DInitialValue)
		{
			this._detailDisplayInitialValue		= detailDisplayInitialValue;
			this._pointLabelInitialValue		= pointLabelInitialValue;
			this._pointLabelSizeInitialValue	= pointLabelSizeInitialValue;
			this._labelVerticalInitialValue		= labelVerticalInitialValue;
			this._labelMaxLengthInitialValue	= labelMaxLengthInitialValue;
			this._labelSizeInitialValue			= labelSizeInitialValue;
			this._view3D2DInitialValue			= view3D2DInitialValue;
		}
		#endregion

		#region Private Member
		/// <summary>詳細表示初期値</summary>
		private bool _detailDisplayInitialValue;
		/// <summary>ポイントラベル表示初期値</summary>
		private bool _pointLabelInitialValue;
		/// <summary>ポイントラベルフォントサイズ初期値</summary>
		private int _pointLabelSizeInitialValue;
		/// <summary>ラベル角度初期値</summary>
		private bool _labelVerticalInitialValue;
		/// <summary>ラベル最大桁数初期値</summary>
		private int _labelMaxLengthInitialValue;
		/// <summary>ラベルフォントサイズ初期値</summary>
		private int _labelSizeInitialValue;
		/// <summary>３Ｄ／２Ｄ表示初期値</summary>
		private bool _view3D2DInitialValue;

		/// <summary>詳細表示初期値</summary>
		private const bool DEFAULT_DETAILDISPLAYINITIAL_VALUE	= false;
		/// <summary>ポイントラベル表示初期値</summary>
		private const bool DEFAULT_POINTLABELINITIAL_VALUE		= true;
		/// <summary>ポイントラベルフォントサイズ初期値</summary>
		private const int DEFAULT_POINTLABELSIZEINITIAL_VALUE	= 9;
		/// <summary>ラベル角度初期値</summary>
		private const bool DEFAULT_LABELVERTICALINITIAL_VALUE	= false;
		/// <summary>ラベル最大桁数初期値</summary>
		private const int DEFAULT_LABELMAXLENGTHINITIAL_VALUE	= -1;
		/// <summary>ラベルフォントサイズ初期値</summary>
		private const int DEFAULT_LABELSIZEINITIAL_VALUE		= 9;
		/// <summary>３Ｄ／２Ｄ表示初期値</summary>
		private const bool DEFAULT_VIEW3D2DINITIAL_VALUE		= true;
		#endregion

		#region Propaty
		/// <summary>詳細表示初期値プロパティ</summary>
		public bool DetailDisplayInitialValue
		{
			get { return this._detailDisplayInitialValue; }
			set { this._detailDisplayInitialValue = value; }
		}

		/// <summary>ポイントラベル表示初期値プロパティ</summary>
		public bool PointLabelInitialValue
		{
			get { return this._pointLabelInitialValue; }
			set { this._pointLabelInitialValue = value; }
		}

		/// <summary>ポイントラベルフォントサイズ初期値プロパティ</summary>
		public int PointLabelSizeInitialValue
		{
			get { return this._pointLabelSizeInitialValue; }
			set { this._pointLabelSizeInitialValue = value; }
		}

		/// <summary>ラベル角度初期値プロパティ</summary>
		public bool LabelVerticalInitialValue
		{
			get { return this._labelVerticalInitialValue; }
			set { this._labelVerticalInitialValue = value; }
		}

		/// <summary>ラベル最大桁数初期値プロパティ</summary>
		public int LabelMaxLengthInitialValue
		{
			get { return this._labelMaxLengthInitialValue; }
			set { this._labelMaxLengthInitialValue = value; }
		}

		/// <summary>ラベルフォントサイズ初期値プロパティ</summary>
		public int LabelSizeInitialValue
		{
			get { return this._labelSizeInitialValue; }
			set { this._labelSizeInitialValue = value; }
		}

		/// <summary>３Ｄ／２Ｄ表示初期値プロパティ</summary>
		public bool View3D2DInitialValue
		{
			get { return this._view3D2DInitialValue; }
			set { this._view3D2DInitialValue = value; }
		}
		#endregion
	}

	/// <summary>
	/// 分析チャート表示設定アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 分析チャート表示設定クラスのアクセス制御を行います。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.03.05</br>
	/// </remarks>
	public class AnalysisChartSettingAcs
	{
		#region Constructor
		/// <summary>
		/// 分析チャート表示設定アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 分析チャート表示設定アクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public AnalysisChartSettingAcs()
		{
			// 起動モード取得
			if (SFANL07200UA._parameter.Length != 0)
			{
				this._startMode = TStrConv.StrToIntDef(SFANL07200UA._parameter[0], 0);
			}

			if (_analysisChartSetting == null)
			{
				_analysisChartSetting = new AnalysisChartSetting();
			}
			this.Deserialize();
		}
		#endregion

		#region Private Member
		/// <summary>起動モード</summary>
		private int _startMode = 0;
		/// <summary>分析チャート表示設定クラス</summary>
		private static AnalysisChartSetting _analysisChartSetting;

		/// <summary>分析チャート表示設定保存ファイル名称</summary>
		private const string XML_FILE_NAME = "SFANL07200U_ChartSetting?.XML";
		#endregion

		#region Events
		/// <summary>分析チャート表示設定変更後イベント</summary>
		public static event EventHandler AnalysisChartSettingChanged;
		#endregion

		#region Properties
		/// <summary>詳細表示初期値プロパティ</summary>
		public bool DetailDisplayInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.DetailDisplayInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.DetailDisplayInitialValue = value;
			}
		}

		/// <summary>ポイントラベル表示初期値プロパティ</summary>
		public bool PointLabelInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.PointLabelInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.PointLabelInitialValue = value;
			}
		}

		/// <summary>ポイントラベルフォントサイズ初期値プロパティ</summary>
		public int PointLabelSizeInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.PointLabelSizeInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.PointLabelSizeInitialValue = value;
			}
		}

		/// <summary>ラベル角度初期値プロパティ</summary>
		public bool LabelVerticalInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.LabelVerticalInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.LabelVerticalInitialValue = value;
			}
		}

		/// <summary>ラベル最大桁数初期値プロパティ</summary>
		public int LabelMaxLengthInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.LabelMaxLengthInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.LabelMaxLengthInitialValue = value;
			}
		}

		/// <summary>ラベルフォントサイズ初期値プロパティ</summary>
		public int LabelSizeInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.LabelSizeInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.LabelSizeInitialValue = value;
			}
		}

		/// <summary>３Ｄ／２Ｄ表示初期値プロパティ</summary>
		public bool View3D2DInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.View3D2DInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.View3D2DInitialValue = value;
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// 分析チャート表示設定クラスシリアライズ処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 分析チャート表示設定クラスのシリアライズを行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public void Serialize()
		{
			string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

			UserSettingController.SerializeUserSetting(_analysisChartSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));

			// 受注検索検索画面用ユーザー設定変更後イベント
			if (AnalysisChartSettingChanged != null)
			{
				AnalysisChartSettingChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// 分析チャート表示設定クラスデシリアライズ処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 分析チャート表示設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public void Deserialize()
		{
			string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)))
			{
				try
				{
					_analysisChartSetting = UserSettingController.DeserializeUserSetting<AnalysisChartSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
				}
				catch (InvalidOperationException)
				{
					UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
				}
			}
		}
		#endregion
	}
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               