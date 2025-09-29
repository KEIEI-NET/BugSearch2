using System;
using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
	//�h���b�v��Ԃ�񋓂��܂��B
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
		//���̃N���X�ł�DrawFilter�C���^�t�F�[�X�𓱓����A
		//�c���[��DrawFilter�Ƃ��Ďg�p�ł���悤�ɂ��܂��B

		public event System.EventHandler Invalidate;
		
		public event QueryStateAllowedForNodeEventHandler QueryStateAllowedForNode;
		public delegate void QueryStateAllowedForNodeEventHandler( object sender, QueryStateAllowedForNodeEventArgs e );

		//QueryStateAllowedForNode�C�x���g���g�p����N���X�ł��B
		public class QueryStateAllowedForNodeEventArgs:System.EventArgs
		{
			public UltraTreeNode Node ;
			public DropLinePositionEnum DropLinePosition;
			public DropLinePositionEnum StatesAllowed ;
		}

		public UltraTree_DropHightLight_DrawFilter_Class()
		{
			//�v���p�e�B���f�t�H���g�l�ɏ��������܂��B
			InitProperties();
		} 

		//�v���p�e�B���f�t�H���g�l�ɏ��������܂��B
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


		//�Еt���܂��B
		public void Dispose()
		{
			mvarDropHighLightNode = null;
		}

		//���݃}�E�X�|�C���^�[���m�[�h�̂ǂ̈ʒu�ɂ��邩��
		//DropHighLightNode���g�p���A�Q�Ƃł��܂��B
		private UltraTreeNode mvarDropHighLightNode;
		public UltraTreeNode DropHightLightNode
		{
			get
			{
				return mvarDropHighLightNode;
			}
			set
			{
				//�m�[�h�֓����l���ݒ肳�ꂽ�ꍇ�͏I������B
				if (mvarDropHighLightNode.Equals(value))
				{	
					return;
				}
				mvarDropHighLightNode = value;
				//DropNode���ύX���ꂽ�ꍇ�B
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
				//�ʒu���ȑO�Ɠ����ꍇ�͏I���B
				if (mvarDropLinePosition == value)
				{
					return;
				}
				mvarDropLinePosition = value;
				//�h���b�v����ʒu���ύX���܂����B
				PositionChanged();
			}
		}

		//DropLine�̕�
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

		//DropHighLight�m�[�h�̔w�i�F��ݒ�B
		//�h���b�v��̃m�[�h�̂݉e������܂��B
		//���̏㉺�̃m�[�h�ɂ͉e������܂���B
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

		//DropHighLight�m�[�h�̑O�i�F��ݒ�B
		//�h���b�v��̃m�[�h�̂݉e������܂��B
		//���̏㉺�̃m�[�h�ɂ͉e���͂���܂���B
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

		//DropLine�̐F�B
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

		//�h���b�v����ɂ����āA�}�E�X�|�C���^�[���m�[�h�̂ǂ̈ʒu��
		//����ꍇ�A�m�[�h�̏�܂��͉��ɑ}�����ׂ������v�Z���܂��B
		//�f�t�H���g�ŁA�m�[�h�̏㕔1/3����A����1/3�����A�܂�����
		//�͗L���ɐݒ肳��Ă��܂��B
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

		//DropNode��������DropPosition���ύX�����ꍇ�AInvalidate�C�x���g��
		//���������A�c���[�R���g���[���̍ĕ`���ʒm���܂��B
		//���̏ꍇ�ADrawFilter���c���[�R���g���[���ւ̎Q�Ƃ��Ȃ��̂ŕK�v
		//�ƂȂ�܂��B
		private void PositionChanged()
		{
			if ( null == this.Invalidate)
				return;

			System.EventArgs e = System.EventArgs.Empty;
		
			this.Invalidate(this, e);
		}

		//DropNode��Nothing�ɁA�ʒu��None�ɐݒ肷�邱�Ƃɂ��A
		//�c���[��DropHighlight��S�ď����ł��܂��B
		public void ClearDropHighlight()
		{
			SetDropHighlightNode(null, DropLinePositionEnum.None);
		}

		//�c���[��DragOver�C�x���g�����������ꍇ�ɂ��̃��[�`����
		//�Ăяo���܂��B
		//���ӁF�����ň����n�����W�̓c���[�ŁA�t�H�[���̍��W�ł�
		//����܂���B
		public void SetDropHighlightNode(UltraTreeNode Node, System.Drawing.Point PointInTreeCoords )
		{
			//�m�[�h�̋��E������̋������v�Z���邽�߂Ɏg�p�B
			//�h���b�v��m�[�h�̏�A���A����Ƃ����̃m�[�h
			//��̂����ꂩ�Ɏw�肷��ꍇ�Ɏg�p�B
			int DistanceFromEdge; 
        
			//�V����DropLinePosition
			DropLinePositionEnum NewDropLinePosition;
		
			DistanceFromEdge = mvarEdgeSensitivity;
			//DistanceFromEdge �̒l��0���m�F�B
			if (DistanceFromEdge == 0)
			{
				//�����ł���΁A�f�t�H���g�l�|1/3�B
				DistanceFromEdge = Node.Bounds.Height / 3;
			}
			//�m�[�h�ɂ�������W���v�Z���܂��B
			if (PointInTreeCoords.Y < (Node.Bounds.Top + DistanceFromEdge))
			{
				//���W�̓m�[�h�̏㕔�ɂ���ꍇ�B
				NewDropLinePosition = DropLinePositionEnum.AboveNode;
			}
			else
			{
				if (PointInTreeCoords.Y > (Node.Bounds.Bottom - DistanceFromEdge))
				{
					//���W�̓m�[�h�̉����ɂ���ꍇ�B
					NewDropLinePosition = DropLinePositionEnum.BelowNode;
				}
				else
				{
					//���W�̓m�[�h�̒��Ԃɂ���ꍇ�B
					NewDropLinePosition = DropLinePositionEnum.OnNode;
				}
			}

			//�V����DropLinePosition���֐��Ɉ����n���B
			SetDropHighlightNode(Node, NewDropLinePosition);
		}

		private void SetDropHighlightNode(UltraTreeNode Node , DropLinePositionEnum DropLinePosition )
		{
			//DropNode �܂��� DropLinePosition�ւ̕ύX�_��ۑ����܂��B
			bool IsPositionChanged = false;

			try	
			{
				//�m�[�h�������܂�DropLine�������ʒu���m���߂܂��B
				if (mvarDropHighLightNode.Equals(Node) && (mvarDropLinePosition == DropLinePosition))
				{
					//�����Ƃ������ꍇ�́A�����ύX���Ă��Ȃ����Ƃ�\���B
					IsPositionChanged = false;
				}
				else	
				{
					//�����ꂩ�A�܂��͗������ύX���ꂽ���Ƃ�\���B
					IsPositionChanged = true;
				}
			}
			catch 
			{
				//mvarDropHighLightNode�ɂ͉����ݒ肳��Ă��Ȃ��̂ŁA
				//������r���Ȃ��B
				if (mvarDropHighLightNode == null)
				{
					//�m�[�h��mvarDropHighLightNode�����`�F�b�N�B
					IsPositionChanged = !(Node == null);
				}
			}

			//�����̃v���p�e�B��ݒ肷��B�i���̏ꍇ�APositionChanged�͎��s���Ȃ��j
			mvarDropHighLightNode = Node;
			mvarDropLinePosition = DropLinePosition;

			//PositionChanged�̒l���ύX���������m�F�B
			if (IsPositionChanged)
			{
				//�ʒu���ύX���܂����B
				PositionChanged();
			}
		}

		//�����ł͂Q�̃t�F�[�Y���g���b�v���܂��B
		//AfterDrawElement: DropLine�̕`��p�B
		//BeforeDrawElement: DropHighlight�̕`��p
		Infragistics.Win.DrawPhase Infragistics.Win.IUIElementDrawFilter.GetPhasesToFilter(ref Infragistics.Win.UIElementDrawParams drawParams) 
		{
			return Infragistics.Win.DrawPhase.AfterDrawElement | Infragistics.Win.DrawPhase.BeforeDrawElement;
		}

		//���ۂ̕`��R�[�h
		bool Infragistics.Win.IUIElementDrawFilter.DrawElement(Infragistics.Win.DrawPhase drawPhase, ref Infragistics.Win.UIElementDrawParams drawParams)
		{
			Infragistics.Win.UIElement aUIElement;
			System.Drawing.Graphics g;
			UltraTreeNode aNode;

			//DropHighlight�m�[�h���Ȃ����ʒu���w�肳��Ă��Ȃ��ꍇ�͉���
			//�`�悵�Ȃ��B
			if ((mvarDropHighLightNode == null) || (mvarDropLinePosition == DropLinePositionEnum.None))
			{
				return false;
			}

			//�V�K��QueryStateAllowedForNodeEventArgs�I�u�W�F�N�g���쐬
			QueryStateAllowedForNodeEventArgs eArgs = new QueryStateAllowedForNodeEventArgs();

			//���K�̏��ŃI�u�W�F�N�g������������B
			eArgs.Node = mvarDropHighLightNode;
			eArgs.DropLinePosition = this.mvarDropLinePosition;

			//StatesAsllowed���f�t�H���g�őS�ĉ\�ɐݒ�B
			eArgs.StatesAllowed = DropLinePositionEnum.All;

			//�C�x���g�𔭐�������B
			this.QueryStateAllowedForNode(this, eArgs);

			//���[�U�[���m�[�h�̌��݂̏�Ԃ������������m�F���A
			//�����łȂ��ꍇ�͊֐����I������B
			if ((eArgs.StatesAllowed & mvarDropLinePosition) != mvarDropLinePosition)
			{
				return false;
			}

			//�`�悳��Ă���v�f���擾�B
			aUIElement = drawParams.Element;

			//�`��i�K���m�F�B
			switch (drawPhase)
			{
				case Infragistics.Win.DrawPhase.BeforeDrawElement:
				{
					//BeforeDrawElement�̕`��i�K�Ȃ̂ŁAOnNode��Ԃ݂̂�`��B
					if ((mvarDropLinePosition & DropLinePositionEnum.OnNode) == DropLinePositionEnum.OnNode)
						//if (mvarDropLinePosition == DropLinePositionEnum.OnNode)
					{
						//NodeTextUIElement��`�悵�Ă��邩���m�F�B
						if (aUIElement.GetType() == typeof(Infragistics.Win.UltraWinTree.NodeTextUIElement))
						{
							//NodeTextUIElement�̊֘A����m�[�h���擾����B
							aNode = (UltraTreeNode)aUIElement.GetContext(typeof(UltraTreeNode));

							//DropHighlightNode���ǂ������`�F�b�N�B
							if (aNode.Equals(mvarDropHighLightNode))
							{
								//�m�[�h�̔w�i�F�A�O�i�F��DropHighlight�F�ɐݒ�B
								//���ӁFAppearanceData�̓m�[�h�̕`��ɂ����Ă̂�
								//�e�����y�ڂ��܂����A���̂ق��̃v���p�e�B��
								//�ύX���܂���B
								drawParams.AppearanceData.BackColor = mvarDropHighLightBackColor;
								drawParams.AppearanceData.ForeColor = mvarDropHighLightForeColor;
							}
						}
					}
					break;
				}
				case Infragistics.Win.DrawPhase.AfterDrawElement:
				{
					//AfterDrawElement�`��i�K�Ȃ̂ŁA��Ɖ��̕���������`�悵�܂��B
					//�c���[�v�f��`�悵�Ă��邩���m�F�B
					if (aUIElement.GetType() == typeof(Infragistics.Win.UltraWinTree.UltraTreeUIElement))
					{
						//DropLine��`�����߂̃y����錾���܂��B
						System.Drawing.Pen p = new System.Drawing.Pen(mvarDropLineColor, mvarDropLineWidth);

						//�`�悵�Ă���Graphics�I�u�W�F�N�g�ւ̃��t�@�����X��
						//�擾����B
						g = drawParams.Graphics;

						//���ݑI������Ă���DropNode��NodeSelectableAreaUIElement���擾���܂��B
						//���̗v�f�́ADropLine�̈ʒu����уT�C�Y���v�Z����̂Ɏg���܂��B
						Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement tElement ;
						tElement = (Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement)drawParams.Element.GetDescendant(typeof(Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement), mvarDropHighLightNode);

						//DropLine�̉E�[���v�Z���܂��B
						int LeftEdge = tElement.Rect.Left - 4;

						//�R���g���[���̉E�[�̐����v�Z���܂��B
						UltraTree aTree; 
						aTree = (UltraTree)tElement.GetContext(typeof(UltraTree));
						int RightEdge = aTree.DisplayRectangle.Right -4;

						//DropLine�̐����ʒu��ۑ����܂��B
						int LineVPosition;

						if ((mvarDropLinePosition & DropLinePositionEnum.AboveNode) == DropLinePositionEnum.AboveNode)
						{
							//�m�[�h�̏㕔�ɐ��������܂��B
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
							//�m�[�h�̉����ɐ��������܂��B
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
