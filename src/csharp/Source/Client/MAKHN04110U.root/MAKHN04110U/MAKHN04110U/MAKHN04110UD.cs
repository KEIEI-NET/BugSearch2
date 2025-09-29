using System;
using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ドロップ状態を列挙します
	/// </summary>
	[System.Flags]
	internal enum DropLinePositionEnum
	{
		None      = 0, 
		OnNode    = 1, 
		AboveNode = 2, 
		BelowNode = 4, 
		All       = OnNode | AboveNode | BelowNode
	}

	/// <summary>
	/// UltraTreeノードドラッグドローフィルタークラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスではDrawFilterインタフェースを導入し、ツリーがDrawFilterとして使用できるようにします。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.1.11</br>
	/// </remarks>
	internal class UltraTree_DropHightLight_DrawFilter_Class : Infragistics.Win.IUIElementDrawFilter
	{
		#region << Constructor >>

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		public UltraTree_DropHightLight_DrawFilter_Class()
		{
			// プロパティをデフォルト値に初期化します。
			this.InitProperties();
		}

		#endregion

		#region << Delegate & Event >>

		/// <summary>
		/// 再描画通知イベント
		/// </summary>
		public event System.EventHandler Invalidate;
		
		/// <summary>
		/// QueryStateAllowedForNodeイベント
		/// </summary>
		public event QueryStateAllowedForNodeEventHandler QueryStateAllowedForNode;
		/// <summary>
		/// QueryStateAllowedForNodeEventHandlerデリゲート
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		public delegate void QueryStateAllowedForNodeEventHandler( object sender, QueryStateAllowedForNodeEventArgs e );

		#region < QueryStateAllowedForNodeイベントパラメータクラス >

		/// <summary>
		/// QueryStateAllowedForNodeイベントパラメータクラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : QueryStateAllowedForNodeイベントが使用するクラスです。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		public class QueryStateAllowedForNodeEventArgs:System.EventArgs
		{
			public UltraTreeNode Node ;
			public DropLinePositionEnum DropLinePosition;
			public DropLinePositionEnum StatesAllowed ;
		}

		#endregion

		#endregion

		#region << Dispose >>

		/// <summary>
		/// Dispose メソッド
		/// </summary>
		/// <remarks>
		/// <br>Note       : 片付けます。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		public void Dispose()
		{
			this._dropHighLightNode = null;
		}

		#endregion

		#region << Private Members >>

		/// <summary>マウス位置のノード</summary>
		private UltraTreeNode        _dropHighLightNode;
		/// <summary>DropLineの位置</summary>
		private DropLinePositionEnum _dropLinePosition;
		/// <summary>DropLineの幅</summary>
		private int                  _dropLineWidth;
		/// <summary>DropHighLightノードの背景色</summary>
		private System.Drawing.Color _dropHighLightBackColor;
		/// <summary>DropHighLightノードの前景色</summary>
		private System.Drawing.Color _dropHighLightForeColor;
		/// <summary>DropLineの色</summary>
		private System.Drawing.Color _dropLineColor;
		/// <summary>境界の感度</summary>
		private int                  _edgeSensitivity;

		#endregion

		#region << Public Properties >>

		/// <summary>
		/// マウス位置ノードプロパティ
		/// </summary>
		/// <remarks>
		/// マウス位置のノードを取得または設定します。
		/// 現在マウスポインターがノードのどの位置にあるかをDropHighLightNodeを使用し、参照できます。
		/// </remarks>
		public UltraTreeNode DropHightLightNode
		{
			get {
				return this._dropHighLightNode;
			}
			set {
				// ノードへ同じ値が設定された場合は終了する。
				if( this._dropHighLightNode.Equals( value ) ) {	
					return;
				}
				this._dropHighLightNode = value;
				// DropNodeが変更された場合。
				this.PositionChanged();
			}
		}

		/// <summary>
		/// DropLine位置プロパティ
		/// </summary>
		/// <remarks>
		/// DropLineの位置を取得または設定します。
		/// </remarks>
		public DropLinePositionEnum DropLinePosition
		{
			get {
				return this._dropLinePosition;
			}
			set {
				// 位置が以前と同じ場合は終了。
				if( this._dropLinePosition == value ) {
					return;
				}
				this._dropLinePosition = value;
				// ドロップする位置が変更しました。
				this.PositionChanged();
			}
		}

		/// <summary>
		/// DropLine幅プロパティ
		/// </summary>
		/// <remarks>
		/// DropLineの幅を取得または設定します。
		/// </remarks>
		public int DropLineWidth
		{
			get {
				return this._dropLineWidth;
			}
			set {
				this._dropLineWidth = value;
			}
		}

		/// <summary>
		/// DropHighLightノード背景色プロパティ
		/// </summary>
		/// <remarks>
		/// DropHighLightノードの背景色を取得または設定します。
		/// ドロップ先のノードのみ影響されます。
		/// その上下のノードには影響ありません。
		/// </remarks>
		public System.Drawing.Color DropHighLightBackColor
		{
			get {
				return this._dropHighLightBackColor;
			}
			set {
				this._dropHighLightBackColor = value;
			}
		}

		/// <summary>
		/// DropHighLightノード前景色プロパティ
		/// </summary>
		/// <remarks>
		/// DropHighLightノードの前景色を取得または設定します。
		/// ドロップ先のノードのみ影響されます。
		/// その上下のノードには影響はありません。
		/// </remarks>
		public System.Drawing.Color  DropHighLightForeColor
		{
			get {
				return this._dropHighLightForeColor;
			}
			set {
				this._dropHighLightForeColor = value;
			}
		}

		/// <summary>
		/// DropLine色プロパティ
		/// </summary>
		/// <remarks>
		/// DropLineの色を取得または設定します。
		/// </remarks>
		public System.Drawing.Color DropLineColor
		{
			get {
				return this._dropLineColor;
			}
			set {
				this._dropLineColor = value;
			}
		}

		/// <summary>
		/// 境界感度プロパティ
		/// </summary>
		/// <remarks>
		/// 境界の感度を取得または設定します。
		/// ドロップ操作において、マウスポインターがノードのどの位置にある場合、ノードの上または下に挿入すべきかを計算します。
		/// デフォルトで、ノードの上部1/3が上、下部1/3が下、また中間は有効に設定されています。
		/// </remarks>
		public int EdgeSensitivity
		{
			get {
				return this._edgeSensitivity;
			}
			set {
				this._edgeSensitivity = value;
			}
		}

		#endregion

		#region << Private Methods >>

		/// <summary>
		/// プロパティ初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : プロパティをデフォルト値に初期化します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		private void InitProperties()
		{
			this._dropHighLightNode      = null;
			this._dropLinePosition       = DropLinePositionEnum.None;
			this._dropHighLightBackColor = System.Drawing.SystemColors.Highlight;
			this._dropHighLightForeColor = System.Drawing.SystemColors.HighlightText;
			this._dropLineColor          = System.Drawing.SystemColors.ControlText;
			this._edgeSensitivity        = 0;
			this._dropLineWidth          = 2;
		}

		/// <summary>
		/// DropNode・DropPosition変更時処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : DropNodeもしくはDropPositionが変更した場合、Invalidateイベントを発生させ、ツリーコントロールの再描画を通知します。
		///                  この場合、DrawFilterがツリーコントロールへの参照がないので必要となります。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		private void PositionChanged()
		{
			if( null == this.Invalidate ) {
				return;
			}

			System.EventArgs e = System.EventArgs.Empty;
		
			// 再描画通知
			if( this.Invalidate != null ) {
				this.Invalidate( this, e );
			}
		}

		/// <summary>
		/// DropHighlight設定処理
		/// </summary>
		/// <param name="node">ドラッグノード</param>
		/// <param name="dropLinePosition">ツリー上座標</param>
		/// <remarks>
		/// <br>Note       : DropHighlightの設定をおこないます。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		private void SetDropHighlightNode(UltraTreeNode node , DropLinePositionEnum dropLinePosition )
		{
			//DropNode または DropLinePositionへの変更点を保存します。
			bool isPositionChanged = false;

			try {
				// ノードが同じまたDropLineが同じ位置か確かめます。
				if( this._dropHighLightNode.Equals( node ) && ( this._dropLinePosition == dropLinePosition ) ) {
					// 両方とも同じ場合は、何も変更していないことを表す。
					isPositionChanged = false;
				}
				else	
				{
					// いずれか、または両方が変更されたことを表す。
					isPositionChanged = true;
				}
			}
			catch {
				// _dropHighLightNodeには何も設定されていないので、
				// 何も比較しない。
				if( this._dropHighLightNode == null )
				{
					// ノードが_dropHighLightNodeかをチェック。
					isPositionChanged = !( node == null );
				}
			}

			// 両方のプロパティを設定する。（この場合、isPositionChangedは実行しない）
			this._dropHighLightNode = node;
			this._dropLinePosition  = dropLinePosition;

			// PositionChangedの値が変更したかを確認。
			if( isPositionChanged ) {
				// 位置が変更された
				this.PositionChanged();
			}
		}

		#endregion

		#region << Public Methods >>

		/// <summary>
		/// DropHighlightクリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : DropNodeをnullに、位置をNoneに設定することにより、ツリーのDropHighlightを全て消去できます。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		public void ClearDropHighlight()
		{
			this.SetDropHighlightNode( null, DropLinePositionEnum.None );
		}

		/// <summary>
		/// DropHighlight設定処理
		/// </summary>
		/// <param name="node">ドラッグノード</param>
		/// <param name="pointInTreeCoords">ツリー上座標</param>
		/// <remarks>
		/// <br>Note       : ツリーのDragOverイベントが発生した場合にこのルーチンを呼び出します。
		///                  注意：ここで引き渡す座標はツリーで、フォームの座標ではありません。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		public void SetDropHighlightNode( UltraTreeNode node, System.Drawing.Point pointInTreeCoords )
		{
			// ノードの境界線からの距離を計算するために使用。
			// ドロップ先ノードの上、下、それともそのノード上のいずれかに指定する場合に使用。
			int distanceFromEdge;

			// 新しいDropLinePosition
			DropLinePositionEnum newDropLinePosition;
		
			distanceFromEdge = this._edgeSensitivity;
			// distanceFromEdge の値が0か確認。
			if( distanceFromEdge == 0 ) {
				//そうであれば、デフォルト値－1/3。
				distanceFromEdge = node.Bounds.Height / 3;
			}
			//ノードにおける座標を計算します。
			if( pointInTreeCoords.Y < ( node.Bounds.Top + distanceFromEdge ) ) {
				// 座標はノードの上部にある場合。
				newDropLinePosition = DropLinePositionEnum.AboveNode;
			}
			else {
				if( pointInTreeCoords.Y > ( node.Bounds.Bottom - distanceFromEdge ) ) {
					//座標はノードの下部にある場合。
					newDropLinePosition = DropLinePositionEnum.BelowNode;
				}
				else {
					//座標はノードの中間にある場合。
					newDropLinePosition = DropLinePositionEnum.OnNode;
				}
			}

			//新しいDropLinePositionを関数に引き渡す。
			this.SetDropHighlightNode( node, newDropLinePosition );
		}

		#endregion

		#region IUIElementDrawFilter メンバ

		/// <summary>
		/// IUIElementDrawFilter.GetPhasesToFilter メソッド
		/// </summary>
		/// <param name="drawParams">描画パラメータ</param>
		/// <returns>描画フェーズ</returns>
		/// <remarks>
		/// <br>Note       : ここでは２つのフェーズをトラップします。
		///                  AfterDrawElement  : DropLineの描画用
		///                  BeforeDrawElement : DropHighlightの描画用</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		Infragistics.Win.DrawPhase Infragistics.Win.IUIElementDrawFilter.GetPhasesToFilter( ref Infragistics.Win.UIElementDrawParams drawParams )
		{
			return ( Infragistics.Win.DrawPhase.AfterDrawElement | Infragistics.Win.DrawPhase.BeforeDrawElement );
		}

		/// <summary>
		/// 描画処理
		/// </summary>
		/// <param name="drawPhase">描画フェーズ</param>
		/// <param name="drawParams">描画パラメータ</param>
		/// <returns>結果</returns>
		/// <remarks>
		/// <br>Note       : 実際の描画処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		bool Infragistics.Win.IUIElementDrawFilter.DrawElement( Infragistics.Win.DrawPhase drawPhase, ref Infragistics.Win.UIElementDrawParams drawParams )
		{
			Infragistics.Win.UIElement aUIElement;
			System.Drawing.Graphics g;
			UltraTreeNode aNode;

			// DropHighlightノードがないか位置が指定されていない場合は何も描画しない。
			if( ( this._dropHighLightNode == null ) || ( this._dropLinePosition == DropLinePositionEnum.None ) ) {
				return false;
			}

			// 新規にQueryStateAllowedForNodeEventArgsオブジェクトを作成
			QueryStateAllowedForNodeEventArgs eArgs = new QueryStateAllowedForNodeEventArgs();

			// 正規の情報でオブジェクトを初期化する。
			eArgs.Node             = this._dropHighLightNode;
			eArgs.DropLinePosition = this._dropLinePosition;

			// StatesAsllowedをデフォルトで全て可能に設定。
			eArgs.StatesAllowed    = DropLinePositionEnum.All;

			// イベントを発生させる。
			if( this.QueryStateAllowedForNode != null ) {
				this.QueryStateAllowedForNode( this, eArgs );
			}

			// ユーザーがノードの現在の状態を許したかを確認し、
			// そうでない場合は関数を終了する。
			if( ( eArgs.StatesAllowed & this._dropLinePosition ) != this._dropLinePosition ) {
				return false;
			}

			// 描画されている要素を取得。
			aUIElement = drawParams.Element;

			// 描画段階を確認。
			switch( drawPhase ) {
				case Infragistics.Win.DrawPhase.BeforeDrawElement:
				{
					// BeforeDrawElementの描画段階なので、OnNode状態のみを描画。
					if( ( this._dropLinePosition & DropLinePositionEnum.OnNode ) == DropLinePositionEnum.OnNode ) {
						// NodeTextUIElementを描画しているかを確認。
						if( aUIElement.GetType() == typeof( Infragistics.Win.UltraWinTree.NodeTextUIElement ) ) {
							// NodeTextUIElementの関連するノードを取得する。
							aNode = ( UltraTreeNode )aUIElement.GetContext( typeof( UltraTreeNode ) );

							// DropHighlightNodeかどうかをチェック。
							if( aNode.Equals( this._dropHighLightNode ) ) {
								// ノードの背景色、前景色をDropHighlight色に設定。
								// 注意：AppearanceDataはノードの描画においてのみ影響を及ぼしますが、
								// そのほかのプロパティは変更しません。
								drawParams.AppearanceData.BackColor = this._dropHighLightBackColor;
								drawParams.AppearanceData.ForeColor = this._dropHighLightForeColor;
							}
						}
					}
					break;
				}
				case Infragistics.Win.DrawPhase.AfterDrawElement:
				{
					// AfterDrawElement描画段階なので、上と下の部分だけを描画します。
					// ツリー要素を描画しているかを確認。
					if( aUIElement.GetType() == typeof( Infragistics.Win.UltraWinTree.UltraTreeUIElement ) ) {
						// DropLineを描くためのペンを宣言します。
						System.Drawing.Pen pen = new System.Drawing.Pen( this._dropLineColor, this._dropLineWidth );

						// 描画しているGraphicsオブジェクトへのリファレンスを取得する。
						g = drawParams.Graphics;

						// 現在選択されているDropNodeのNodeSelectableAreaUIElementを取得します。
						// この要素は、DropLineの位置およびサイズを計算するのに使われます。
						Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement tElement;
						tElement = ( Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement )drawParams.Element.GetDescendant( typeof( Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement ), this._dropHighLightNode );

						// DropLineの右端を計算します。
						int leftEdge = tElement.Rect.Left - 4;

						// コントロールの右端の線を計算します。
						UltraTree aTree; 
						aTree = ( UltraTree )tElement.GetContext( typeof( UltraTree ) );
						int rightEdge = aTree.DisplayRectangle.Right - 4;

						// DropLineの垂直位置を保存します。
						int lineVPosition;

						if( ( this._dropLinePosition & DropLinePositionEnum.AboveNode ) == DropLinePositionEnum.AboveNode ) {
							// ノードの上部に線を引きます。
							lineVPosition = this._dropHighLightNode.Bounds.Top;
							g.DrawLine( pen, leftEdge     , lineVPosition    , rightEdge    , lineVPosition     );
							pen.Width = 1;
							g.DrawLine( pen, leftEdge     , lineVPosition - 3, leftEdge     , lineVPosition + 2 );
							g.DrawLine( pen, leftEdge  + 1, lineVPosition - 2, leftEdge  + 1, lineVPosition + 1 );
							g.DrawLine( pen, rightEdge    , lineVPosition - 3, rightEdge    , lineVPosition + 2 );
							g.DrawLine( pen, rightEdge - 1, lineVPosition - 2, rightEdge - 1, lineVPosition + 1 );
						}
						if( ( this._dropLinePosition & DropLinePositionEnum.BelowNode ) == DropLinePositionEnum.BelowNode ) {
							// ノードの下部に線を引きます。
							lineVPosition = this._dropHighLightNode.Bounds.Bottom;
							g.DrawLine( pen, leftEdge     , lineVPosition    , rightEdge    , lineVPosition     );
							pen.Width = 1;
							g.DrawLine( pen, leftEdge     , lineVPosition - 3, leftEdge     , lineVPosition + 2 );
							g.DrawLine( pen, leftEdge  + 1, lineVPosition - 2, leftEdge  + 1, lineVPosition + 1 );
							g.DrawLine( pen, rightEdge    , lineVPosition - 3, rightEdge    , lineVPosition + 2 );
							g.DrawLine( pen, rightEdge - 1, lineVPosition - 2, rightEdge - 1, lineVPosition + 1 );
						}
					}
					break;
				}				
			}

			return false;
		}

		#endregion
	}
}
