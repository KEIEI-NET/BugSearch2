using System;
using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
	//ドロップ状態を列挙します。
	[System.Flags] internal enum DropLinePositionEnum
	{
		None = 0,
		OnNode = 1,
		AboveNode = 2,
		BelowNode = 4,
		All = OnNode | AboveNode | BelowNode
	}

	internal class UltraTree_DropHightLight_DrawFilter_Class : Infragistics.Win.IUIElementDrawFilter
	{
		//このクラスではDrawFilterインタフェースを導入し、
		//ツリーがDrawFilterとして使用できるようにします。

		public event System.EventHandler Invalidate;
		
		public event QueryStateAllowedForNodeEventHandler QueryStateAllowedForNode;
		public delegate void QueryStateAllowedForNodeEventHandler( object sender, QueryStateAllowedForNodeEventArgs e );

		//QueryStateAllowedForNodeイベントが使用するクラスです。
		public class QueryStateAllowedForNodeEventArgs:System.EventArgs
		{
			public UltraTreeNode Node ;
			public DropLinePositionEnum DropLinePosition;
			public DropLinePositionEnum StatesAllowed ;
		}

		public UltraTree_DropHightLight_DrawFilter_Class()
		{
			//プロパティをデフォルト値に初期化します。
			InitProperties();
		} 

		//プロパティをデフォルト値に初期化します。
		private void InitProperties()
		{
			mvarDropHighLightNode = null;
			mvarDropLinePosition = DropLinePositionEnum.None;
			mvarDropHighLightBackColor = System.Drawing.SystemColors.Highlight;
			mvarDropHighLightForeColor = System.Drawing.SystemColors.HighlightText;
			mvarDropLineColor = System.Drawing.SystemColors.ControlText;
			mvarEdgeSensitivity = 0;
			mvarDropLineWidth = 2;
		}


		//片付けます。
		public void Dispose()
		{
			mvarDropHighLightNode = null;
		}

		//現在マウスポインターがノードのどの位置にあるかを
		//DropHighLightNodeを使用し、参照できます。
		private UltraTreeNode mvarDropHighLightNode;
		public UltraTreeNode DropHightLightNode
		{
			get
			{
				return mvarDropHighLightNode;
			}
			set
			{
				//ノードへ同じ値が設定された場合は終了する。
				if (mvarDropHighLightNode.Equals(value))
				{	
					return;
				}
				mvarDropHighLightNode = value;
				//DropNodeが変更された場合。
				PositionChanged();
			}
		}

		private DropLinePositionEnum mvarDropLinePosition;
		public DropLinePositionEnum DropLinePosition
		{
			get
			{
				return mvarDropLinePosition;
			}
			set
			{
				//位置が以前と同じ場合は終了。
				if (mvarDropLinePosition == value)
				{
					return;
				}
				mvarDropLinePosition = value;
				//ドロップする位置が変更しました。
				PositionChanged();
			}
		}

		//DropLineの幅
		private int mvarDropLineWidth;
		public int DropLineWidth
		{
			get
			{
				return mvarDropLineWidth;
			}
			set
			{
				mvarDropLineWidth = value;
			}
		}

		//DropHighLightノードの背景色を設定。
		//ドロップ先のノードのみ影響されます。
		//その上下のノードには影響ありません。
		private System.Drawing.Color mvarDropHighLightBackColor; 
		public System.Drawing.Color DropHighLightBackColor
		{
			get
			{
				return mvarDropHighLightBackColor;
			}
			set
			{
				mvarDropHighLightBackColor = value;
			}
		}

		//DropHighLightノードの前景色を設定。
		//ドロップ先のノードのみ影響されます。
		//その上下のノードには影響はありません。
		private System.Drawing.Color  mvarDropHighLightForeColor;
		public System.Drawing.Color  DropHighLightForeColor
		{
			get
			{
				return mvarDropHighLightForeColor;
			}
			set
			{
				mvarDropHighLightForeColor = value;
			}
		}

		//DropLineの色。
		private System.Drawing.Color  mvarDropLineColor ;
		public System.Drawing.Color DropLineColor
		{
			get
			{
				return mvarDropLineColor;
			}
			set
			{
				mvarDropLineColor = value;
			}
		}

		//ドロップ操作において、マウスポインターがノードのどの位置に
		//ある場合、ノードの上または下に挿入すべきかを計算します。
		//デフォルトで、ノードの上部1/3が上、下部1/3が下、また中間
		//は有効に設定されています。
		private int mvarEdgeSensitivity ;
		public int EdgeSensitivity
		{
			get
			{
				return mvarEdgeSensitivity;
			}
			set
			{
				mvarEdgeSensitivity = value;
			}
		}

		//DropNodeもしくはDropPositionが変更した場合、Invalidateイベントを
		//発生させ、ツリーコントロールの再描画を通知します。
		//この場合、DrawFilterがツリーコントロールへの参照がないので必要
		//となります。
		private void PositionChanged()
		{
			if ( null == this.Invalidate)
				return;

			System.EventArgs e = System.EventArgs.Empty;
		
			this.Invalidate(this, e);
		}

		//DropNodeをNothingに、位置をNoneに設定することにより、
		//ツリーのDropHighlightを全て消去できます。
		public void ClearDropHighlight()
		{
			SetDropHighlightNode(null, DropLinePositionEnum.None);
		}

		//ツリーのDragOverイベントが発生した場合にこのルーチンを
		//呼び出します。
		//注意：ここで引き渡す座標はツリーで、フォームの座標では
		//ありません。
		public void SetDropHighlightNode(UltraTreeNode Node, System.Drawing.Point PointInTreeCoords )
		{
			//ノードの境界線からの距離を計算するために使用。
			//ドロップ先ノードの上、下、それともそのノード
			//上のいずれかに指定する場合に使用。
			int DistanceFromEdge; 
        
			//新しいDropLinePosition
			DropLinePositionEnum NewDropLinePosition;
		
			DistanceFromEdge = mvarEdgeSensitivity;
			//DistanceFromEdge の値が0か確認。
			if (DistanceFromEdge == 0)
			{
				//そうであれば、デフォルト値－1/3。
				DistanceFromEdge = Node.Bounds.Height / 3;
			}
			//ノードにおける座標を計算します。
			if (PointInTreeCoords.Y < (Node.Bounds.Top + DistanceFromEdge))
			{
				//座標はノードの上部にある場合。
				NewDropLinePosition = DropLinePositionEnum.AboveNode;
			}
			else
			{
				if (PointInTreeCoords.Y > (Node.Bounds.Bottom - DistanceFromEdge))
				{
					//座標はノードの下部にある場合。
					NewDropLinePosition = DropLinePositionEnum.BelowNode;
				}
				else
				{
					//座標はノードの中間にある場合。
					NewDropLinePosition = DropLinePositionEnum.OnNode;
				}
			}

			//新しいDropLinePositionを関数に引き渡す。
			SetDropHighlightNode(Node, NewDropLinePosition);
		}

		private void SetDropHighlightNode(UltraTreeNode Node , DropLinePositionEnum DropLinePosition )
		{
			//DropNode または DropLinePositionへの変更点を保存します。
			bool IsPositionChanged = false;

			try	
			{
				//ノードが同じまたDropLineが同じ位置か確かめます。
				if (mvarDropHighLightNode.Equals(Node) && (mvarDropLinePosition == DropLinePosition))
				{
					//両方とも同じ場合は、何も変更していないことを表す。
					IsPositionChanged = false;
				}
				else	
				{
					//いずれか、または両方が変更されたことを表す。
					IsPositionChanged = true;
				}
			}
			catch 
			{
				//mvarDropHighLightNodeには何も設定されていないので、
				//何も比較しない。
				if (mvarDropHighLightNode == null)
				{
					//ノードがmvarDropHighLightNodeかをチェック。
					IsPositionChanged = !(Node == null);
				}
			}

			//両方のプロパティを設定する。（この場合、PositionChangedは実行しない）
			mvarDropHighLightNode = Node;
			mvarDropLinePosition = DropLinePosition;

			//PositionChangedの値が変更したかを確認。
			if (IsPositionChanged)
			{
				//位置が変更しました。
				PositionChanged();
			}
		}

		//ここでは２つのフェーズをトラップします。
		//AfterDrawElement: DropLineの描画用。
		//BeforeDrawElement: DropHighlightの描画用
		Infragistics.Win.DrawPhase Infragistics.Win.IUIElementDrawFilter.GetPhasesToFilter(ref Infragistics.Win.UIElementDrawParams drawParams) 
		{
			return Infragistics.Win.DrawPhase.AfterDrawElement | Infragistics.Win.DrawPhase.BeforeDrawElement;
		}

		//実際の描画コード
		bool Infragistics.Win.IUIElementDrawFilter.DrawElement(Infragistics.Win.DrawPhase drawPhase, ref Infragistics.Win.UIElementDrawParams drawParams)
		{
			Infragistics.Win.UIElement aUIElement;
			System.Drawing.Graphics g;
			UltraTreeNode aNode;

			//DropHighlightノードがないか位置が指定されていない場合は何も
			//描画しない。
			if ((mvarDropHighLightNode == null) || (mvarDropLinePosition == DropLinePositionEnum.None))
			{
				return false;
			}

			//新規にQueryStateAllowedForNodeEventArgsオブジェクトを作成
			QueryStateAllowedForNodeEventArgs eArgs = new QueryStateAllowedForNodeEventArgs();

			//正規の情報でオブジェクトを初期化する。
			eArgs.Node = mvarDropHighLightNode;
			eArgs.DropLinePosition = this.mvarDropLinePosition;

			//StatesAsllowedをデフォルトで全て可能に設定。
			eArgs.StatesAllowed = DropLinePositionEnum.All;

			//イベントを発生させる。
			this.QueryStateAllowedForNode(this, eArgs);

			//ユーザーがノードの現在の状態を許したかを確認し、
			//そうでない場合は関数を終了する。
			if ((eArgs.StatesAllowed & mvarDropLinePosition) != mvarDropLinePosition)
			{
				return false;
			}

			//描画されている要素を取得。
			aUIElement = drawParams.Element;

			//描画段階を確認。
			switch (drawPhase)
			{
				case Infragistics.Win.DrawPhase.BeforeDrawElement:
				{
					//BeforeDrawElementの描画段階なので、OnNode状態のみを描画。
					if ((mvarDropLinePosition & DropLinePositionEnum.OnNode) == DropLinePositionEnum.OnNode)
						//if (mvarDropLinePosition == DropLinePositionEnum.OnNode)
					{
						//NodeTextUIElementを描画しているかを確認。
						if (aUIElement.GetType() == typeof(Infragistics.Win.UltraWinTree.NodeTextUIElement))
						{
							//NodeTextUIElementの関連するノードを取得する。
							aNode = (UltraTreeNode)aUIElement.GetContext(typeof(UltraTreeNode));

							//DropHighlightNodeかどうかをチェック。
							if (aNode.Equals(mvarDropHighLightNode))
							{
								//ノードの背景色、前景色をDropHighlight色に設定。
								//注意：AppearanceDataはノードの描画においてのみ
								//影響を及ぼしますが、そのほかのプロパティは
								//変更しません。
								drawParams.AppearanceData.BackColor = mvarDropHighLightBackColor;
								drawParams.AppearanceData.ForeColor = mvarDropHighLightForeColor;
							}
						}
					}
					break;
				}
				case Infragistics.Win.DrawPhase.AfterDrawElement:
				{
					//AfterDrawElement描画段階なので、上と下の部分だけを描画します。
					//ツリー要素を描画しているかを確認。
					if (aUIElement.GetType() == typeof(Infragistics.Win.UltraWinTree.UltraTreeUIElement))
					{
						//DropLineを描くためのペンを宣言します。
						System.Drawing.Pen p = new System.Drawing.Pen(mvarDropLineColor, mvarDropLineWidth);

						//描画しているGraphicsオブジェクトへのリファレンスを
						//取得する。
						g = drawParams.Graphics;

						//現在選択されているDropNodeのNodeSelectableAreaUIElementを取得します。
						//この要素は、DropLineの位置およびサイズを計算するのに使われます。
						Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement tElement ;
						tElement = (Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement)drawParams.Element.GetDescendant(typeof(Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement), mvarDropHighLightNode);

						//DropLineの右端を計算します。
						int LeftEdge = tElement.Rect.Left - 4;

						//コントロールの右端の線を計算します。
						UltraTree aTree; 
						aTree = (UltraTree)tElement.GetContext(typeof(UltraTree));
						int RightEdge = aTree.DisplayRectangle.Right -4;

						//DropLineの垂直位置を保存します。
						int LineVPosition;

						if ((mvarDropLinePosition & DropLinePositionEnum.AboveNode) == DropLinePositionEnum.AboveNode)
						{
							//ノードの上部に線を引きます。
							LineVPosition = mvarDropHighLightNode.Bounds.Top;
							g.DrawLine(p, LeftEdge, LineVPosition, RightEdge, LineVPosition);
							p.Width = 1;
							g.DrawLine(p, LeftEdge, LineVPosition - 3, LeftEdge, LineVPosition + 2);
							g.DrawLine(p, LeftEdge + 1, LineVPosition - 2, LeftEdge + 1, LineVPosition + 1);
							g.DrawLine(p, RightEdge, LineVPosition - 3, RightEdge, LineVPosition + 2);
							g.DrawLine(p, RightEdge - 1, LineVPosition - 2, RightEdge - 1, LineVPosition + 1);
						}
						if ((mvarDropLinePosition & DropLinePositionEnum.BelowNode) == DropLinePositionEnum.BelowNode)
						{
							//ノードの下部に線を引きます。
							LineVPosition = mvarDropHighLightNode.Bounds.Bottom;
							g.DrawLine(p, LeftEdge, LineVPosition, RightEdge, LineVPosition);
							p.Width = 1;
							g.DrawLine(p, LeftEdge, LineVPosition - 3, LeftEdge, LineVPosition + 2);
							g.DrawLine(p, LeftEdge + 1, LineVPosition - 2, LeftEdge + 1, LineVPosition + 1);
							g.DrawLine(p, RightEdge, LineVPosition - 3, RightEdge, LineVPosition + 2);
							g.DrawLine(p, RightEdge - 1, LineVPosition - 2, RightEdge - 1, LineVPosition + 1);
						}
					}
					break;
				}				
			}
			return false;
		}
	}
}
