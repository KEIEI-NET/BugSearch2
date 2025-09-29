using System;
using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �h���b�v��Ԃ�񋓂��܂�
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
	/// UltraTree�m�[�h�h���b�O�h���[�t�B���^�[�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X�ł�DrawFilter�C���^�t�F�[�X�𓱓����A�c���[��DrawFilter�Ƃ��Ďg�p�ł���悤�ɂ��܂��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.1.11</br>
	/// </remarks>
	internal class UltraTree_DropHightLight_DrawFilter_Class : Infragistics.Win.IUIElementDrawFilter
	{
		#region << Constructor >>

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		public UltraTree_DropHightLight_DrawFilter_Class()
		{
			// �v���p�e�B���f�t�H���g�l�ɏ��������܂��B
			this.InitProperties();
		}

		#endregion

		#region << Delegate & Event >>

		/// <summary>
		/// �ĕ`��ʒm�C�x���g
		/// </summary>
		public event System.EventHandler Invalidate;
		
		/// <summary>
		/// QueryStateAllowedForNode�C�x���g
		/// </summary>
		public event QueryStateAllowedForNodeEventHandler QueryStateAllowedForNode;
		/// <summary>
		/// QueryStateAllowedForNodeEventHandler�f���Q�[�g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		public delegate void QueryStateAllowedForNodeEventHandler( object sender, QueryStateAllowedForNodeEventArgs e );

		#region < QueryStateAllowedForNode�C�x���g�p�����[�^�N���X >

		/// <summary>
		/// QueryStateAllowedForNode�C�x���g�p�����[�^�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : QueryStateAllowedForNode�C�x���g���g�p����N���X�ł��B</br>
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
		/// Dispose ���\�b�h
		/// </summary>
		/// <remarks>
		/// <br>Note       : �Еt���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		public void Dispose()
		{
			this._dropHighLightNode = null;
		}

		#endregion

		#region << Private Members >>

		/// <summary>�}�E�X�ʒu�̃m�[�h</summary>
		private UltraTreeNode        _dropHighLightNode;
		/// <summary>DropLine�̈ʒu</summary>
		private DropLinePositionEnum _dropLinePosition;
		/// <summary>DropLine�̕�</summary>
		private int                  _dropLineWidth;
		/// <summary>DropHighLight�m�[�h�̔w�i�F</summary>
		private System.Drawing.Color _dropHighLightBackColor;
		/// <summary>DropHighLight�m�[�h�̑O�i�F</summary>
		private System.Drawing.Color _dropHighLightForeColor;
		/// <summary>DropLine�̐F</summary>
		private System.Drawing.Color _dropLineColor;
		/// <summary>���E�̊��x</summary>
		private int                  _edgeSensitivity;

		#endregion

		#region << Public Properties >>

		/// <summary>
		/// �}�E�X�ʒu�m�[�h�v���p�e�B
		/// </summary>
		/// <remarks>
		/// �}�E�X�ʒu�̃m�[�h���擾�܂��͐ݒ肵�܂��B
		/// ���݃}�E�X�|�C���^�[���m�[�h�̂ǂ̈ʒu�ɂ��邩��DropHighLightNode���g�p���A�Q�Ƃł��܂��B
		/// </remarks>
		public UltraTreeNode DropHightLightNode
		{
			get {
				return this._dropHighLightNode;
			}
			set {
				// �m�[�h�֓����l���ݒ肳�ꂽ�ꍇ�͏I������B
				if( this._dropHighLightNode.Equals( value ) ) {	
					return;
				}
				this._dropHighLightNode = value;
				// DropNode���ύX���ꂽ�ꍇ�B
				this.PositionChanged();
			}
		}

		/// <summary>
		/// DropLine�ʒu�v���p�e�B
		/// </summary>
		/// <remarks>
		/// DropLine�̈ʒu���擾�܂��͐ݒ肵�܂��B
		/// </remarks>
		public DropLinePositionEnum DropLinePosition
		{
			get {
				return this._dropLinePosition;
			}
			set {
				// �ʒu���ȑO�Ɠ����ꍇ�͏I���B
				if( this._dropLinePosition == value ) {
					return;
				}
				this._dropLinePosition = value;
				// �h���b�v����ʒu���ύX���܂����B
				this.PositionChanged();
			}
		}

		/// <summary>
		/// DropLine���v���p�e�B
		/// </summary>
		/// <remarks>
		/// DropLine�̕����擾�܂��͐ݒ肵�܂��B
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
		/// DropHighLight�m�[�h�w�i�F�v���p�e�B
		/// </summary>
		/// <remarks>
		/// DropHighLight�m�[�h�̔w�i�F���擾�܂��͐ݒ肵�܂��B
		/// �h���b�v��̃m�[�h�̂݉e������܂��B
		/// ���̏㉺�̃m�[�h�ɂ͉e������܂���B
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
		/// DropHighLight�m�[�h�O�i�F�v���p�e�B
		/// </summary>
		/// <remarks>
		/// DropHighLight�m�[�h�̑O�i�F���擾�܂��͐ݒ肵�܂��B
		/// �h���b�v��̃m�[�h�̂݉e������܂��B
		/// ���̏㉺�̃m�[�h�ɂ͉e���͂���܂���B
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
		/// DropLine�F�v���p�e�B
		/// </summary>
		/// <remarks>
		/// DropLine�̐F���擾�܂��͐ݒ肵�܂��B
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
		/// ���E���x�v���p�e�B
		/// </summary>
		/// <remarks>
		/// ���E�̊��x���擾�܂��͐ݒ肵�܂��B
		/// �h���b�v����ɂ����āA�}�E�X�|�C���^�[���m�[�h�̂ǂ̈ʒu�ɂ���ꍇ�A�m�[�h�̏�܂��͉��ɑ}�����ׂ������v�Z���܂��B
		/// �f�t�H���g�ŁA�m�[�h�̏㕔1/3����A����1/3�����A�܂����Ԃ͗L���ɐݒ肳��Ă��܂��B
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
		/// �v���p�e�B����������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �v���p�e�B���f�t�H���g�l�ɏ��������܂��B</br>
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
		/// DropNode�EDropPosition�ύX������
		/// </summary>
		/// <remarks>
		/// <br>Note       : DropNode��������DropPosition���ύX�����ꍇ�AInvalidate�C�x���g�𔭐������A�c���[�R���g���[���̍ĕ`���ʒm���܂��B
		///                  ���̏ꍇ�ADrawFilter���c���[�R���g���[���ւ̎Q�Ƃ��Ȃ��̂ŕK�v�ƂȂ�܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		private void PositionChanged()
		{
			if( null == this.Invalidate ) {
				return;
			}

			System.EventArgs e = System.EventArgs.Empty;
		
			// �ĕ`��ʒm
			if( this.Invalidate != null ) {
				this.Invalidate( this, e );
			}
		}

		/// <summary>
		/// DropHighlight�ݒ菈��
		/// </summary>
		/// <param name="node">�h���b�O�m�[�h</param>
		/// <param name="dropLinePosition">�c���[����W</param>
		/// <remarks>
		/// <br>Note       : DropHighlight�̐ݒ�������Ȃ��܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		private void SetDropHighlightNode(UltraTreeNode node , DropLinePositionEnum dropLinePosition )
		{
			//DropNode �܂��� DropLinePosition�ւ̕ύX�_��ۑ����܂��B
			bool isPositionChanged = false;

			try {
				// �m�[�h�������܂�DropLine�������ʒu���m���߂܂��B
				if( this._dropHighLightNode.Equals( node ) && ( this._dropLinePosition == dropLinePosition ) ) {
					// �����Ƃ������ꍇ�́A�����ύX���Ă��Ȃ����Ƃ�\���B
					isPositionChanged = false;
				}
				else	
				{
					// �����ꂩ�A�܂��͗������ύX���ꂽ���Ƃ�\���B
					isPositionChanged = true;
				}
			}
			catch {
				// _dropHighLightNode�ɂ͉����ݒ肳��Ă��Ȃ��̂ŁA
				// ������r���Ȃ��B
				if( this._dropHighLightNode == null )
				{
					// �m�[�h��_dropHighLightNode�����`�F�b�N�B
					isPositionChanged = !( node == null );
				}
			}

			// �����̃v���p�e�B��ݒ肷��B�i���̏ꍇ�AisPositionChanged�͎��s���Ȃ��j
			this._dropHighLightNode = node;
			this._dropLinePosition  = dropLinePosition;

			// PositionChanged�̒l���ύX���������m�F�B
			if( isPositionChanged ) {
				// �ʒu���ύX���ꂽ
				this.PositionChanged();
			}
		}

		#endregion

		#region << Public Methods >>

		/// <summary>
		/// DropHighlight�N���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : DropNode��null�ɁA�ʒu��None�ɐݒ肷�邱�Ƃɂ��A�c���[��DropHighlight��S�ď����ł��܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		public void ClearDropHighlight()
		{
			this.SetDropHighlightNode( null, DropLinePositionEnum.None );
		}

		/// <summary>
		/// DropHighlight�ݒ菈��
		/// </summary>
		/// <param name="node">�h���b�O�m�[�h</param>
		/// <param name="pointInTreeCoords">�c���[����W</param>
		/// <remarks>
		/// <br>Note       : �c���[��DragOver�C�x���g�����������ꍇ�ɂ��̃��[�`�����Ăяo���܂��B
		///                  ���ӁF�����ň����n�����W�̓c���[�ŁA�t�H�[���̍��W�ł͂���܂���B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		public void SetDropHighlightNode( UltraTreeNode node, System.Drawing.Point pointInTreeCoords )
		{
			// �m�[�h�̋��E������̋������v�Z���邽�߂Ɏg�p�B
			// �h���b�v��m�[�h�̏�A���A����Ƃ����̃m�[�h��̂����ꂩ�Ɏw�肷��ꍇ�Ɏg�p�B
			int distanceFromEdge;

			// �V����DropLinePosition
			DropLinePositionEnum newDropLinePosition;
		
			distanceFromEdge = this._edgeSensitivity;
			// distanceFromEdge �̒l��0���m�F�B
			if( distanceFromEdge == 0 ) {
				//�����ł���΁A�f�t�H���g�l�|1/3�B
				distanceFromEdge = node.Bounds.Height / 3;
			}
			//�m�[�h�ɂ�������W���v�Z���܂��B
			if( pointInTreeCoords.Y < ( node.Bounds.Top + distanceFromEdge ) ) {
				// ���W�̓m�[�h�̏㕔�ɂ���ꍇ�B
				newDropLinePosition = DropLinePositionEnum.AboveNode;
			}
			else {
				if( pointInTreeCoords.Y > ( node.Bounds.Bottom - distanceFromEdge ) ) {
					//���W�̓m�[�h�̉����ɂ���ꍇ�B
					newDropLinePosition = DropLinePositionEnum.BelowNode;
				}
				else {
					//���W�̓m�[�h�̒��Ԃɂ���ꍇ�B
					newDropLinePosition = DropLinePositionEnum.OnNode;
				}
			}

			//�V����DropLinePosition���֐��Ɉ����n���B
			this.SetDropHighlightNode( node, newDropLinePosition );
		}

		#endregion

		#region IUIElementDrawFilter �����o

		/// <summary>
		/// IUIElementDrawFilter.GetPhasesToFilter ���\�b�h
		/// </summary>
		/// <param name="drawParams">�`��p�����[�^</param>
		/// <returns>�`��t�F�[�Y</returns>
		/// <remarks>
		/// <br>Note       : �����ł͂Q�̃t�F�[�Y���g���b�v���܂��B
		///                  AfterDrawElement  : DropLine�̕`��p
		///                  BeforeDrawElement : DropHighlight�̕`��p</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		Infragistics.Win.DrawPhase Infragistics.Win.IUIElementDrawFilter.GetPhasesToFilter( ref Infragistics.Win.UIElementDrawParams drawParams )
		{
			return ( Infragistics.Win.DrawPhase.AfterDrawElement | Infragistics.Win.DrawPhase.BeforeDrawElement );
		}

		/// <summary>
		/// �`�揈��
		/// </summary>
		/// <param name="drawPhase">�`��t�F�[�Y</param>
		/// <param name="drawParams">�`��p�����[�^</param>
		/// <returns>����</returns>
		/// <remarks>
		/// <br>Note       : ���ۂ̕`�揈�����s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		bool Infragistics.Win.IUIElementDrawFilter.DrawElement( Infragistics.Win.DrawPhase drawPhase, ref Infragistics.Win.UIElementDrawParams drawParams )
		{
			Infragistics.Win.UIElement aUIElement;
			System.Drawing.Graphics g;
			UltraTreeNode aNode;

			// DropHighlight�m�[�h���Ȃ����ʒu���w�肳��Ă��Ȃ��ꍇ�͉����`�悵�Ȃ��B
			if( ( this._dropHighLightNode == null ) || ( this._dropLinePosition == DropLinePositionEnum.None ) ) {
				return false;
			}

			// �V�K��QueryStateAllowedForNodeEventArgs�I�u�W�F�N�g���쐬
			QueryStateAllowedForNodeEventArgs eArgs = new QueryStateAllowedForNodeEventArgs();

			// ���K�̏��ŃI�u�W�F�N�g������������B
			eArgs.Node             = this._dropHighLightNode;
			eArgs.DropLinePosition = this._dropLinePosition;

			// StatesAsllowed���f�t�H���g�őS�ĉ\�ɐݒ�B
			eArgs.StatesAllowed    = DropLinePositionEnum.All;

			// �C�x���g�𔭐�������B
			if( this.QueryStateAllowedForNode != null ) {
				this.QueryStateAllowedForNode( this, eArgs );
			}

			// ���[�U�[���m�[�h�̌��݂̏�Ԃ������������m�F���A
			// �����łȂ��ꍇ�͊֐����I������B
			if( ( eArgs.StatesAllowed & this._dropLinePosition ) != this._dropLinePosition ) {
				return false;
			}

			// �`�悳��Ă���v�f���擾�B
			aUIElement = drawParams.Element;

			// �`��i�K���m�F�B
			switch( drawPhase ) {
				case Infragistics.Win.DrawPhase.BeforeDrawElement:
				{
					// BeforeDrawElement�̕`��i�K�Ȃ̂ŁAOnNode��Ԃ݂̂�`��B
					if( ( this._dropLinePosition & DropLinePositionEnum.OnNode ) == DropLinePositionEnum.OnNode ) {
						// NodeTextUIElement��`�悵�Ă��邩���m�F�B
						if( aUIElement.GetType() == typeof( Infragistics.Win.UltraWinTree.NodeTextUIElement ) ) {
							// NodeTextUIElement�̊֘A����m�[�h���擾����B
							aNode = ( UltraTreeNode )aUIElement.GetContext( typeof( UltraTreeNode ) );

							// DropHighlightNode���ǂ������`�F�b�N�B
							if( aNode.Equals( this._dropHighLightNode ) ) {
								// �m�[�h�̔w�i�F�A�O�i�F��DropHighlight�F�ɐݒ�B
								// ���ӁFAppearanceData�̓m�[�h�̕`��ɂ����Ă̂݉e�����y�ڂ��܂����A
								// ���̂ق��̃v���p�e�B�͕ύX���܂���B
								drawParams.AppearanceData.BackColor = this._dropHighLightBackColor;
								drawParams.AppearanceData.ForeColor = this._dropHighLightForeColor;
							}
						}
					}
					break;
				}
				case Infragistics.Win.DrawPhase.AfterDrawElement:
				{
					// AfterDrawElement�`��i�K�Ȃ̂ŁA��Ɖ��̕���������`�悵�܂��B
					// �c���[�v�f��`�悵�Ă��邩���m�F�B
					if( aUIElement.GetType() == typeof( Infragistics.Win.UltraWinTree.UltraTreeUIElement ) ) {
						// DropLine��`�����߂̃y����錾���܂��B
						System.Drawing.Pen pen = new System.Drawing.Pen( this._dropLineColor, this._dropLineWidth );

						// �`�悵�Ă���Graphics�I�u�W�F�N�g�ւ̃��t�@�����X���擾����B
						g = drawParams.Graphics;

						// ���ݑI������Ă���DropNode��NodeSelectableAreaUIElement���擾���܂��B
						// ���̗v�f�́ADropLine�̈ʒu����уT�C�Y���v�Z����̂Ɏg���܂��B
						Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement tElement;
						tElement = ( Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement )drawParams.Element.GetDescendant( typeof( Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement ), this._dropHighLightNode );

						// DropLine�̉E�[���v�Z���܂��B
						int leftEdge = tElement.Rect.Left - 4;

						// �R���g���[���̉E�[�̐����v�Z���܂��B
						UltraTree aTree; 
						aTree = ( UltraTree )tElement.GetContext( typeof( UltraTree ) );
						int rightEdge = aTree.DisplayRectangle.Right - 4;

						// DropLine�̐����ʒu��ۑ����܂��B
						int lineVPosition;

						if( ( this._dropLinePosition & DropLinePositionEnum.AboveNode ) == DropLinePositionEnum.AboveNode ) {
							// �m�[�h�̏㕔�ɐ��������܂��B
							lineVPosition = this._dropHighLightNode.Bounds.Top;
							g.DrawLine( pen, leftEdge     , lineVPosition    , rightEdge    , lineVPosition     );
							pen.Width = 1;
							g.DrawLine( pen, leftEdge     , lineVPosition - 3, leftEdge     , lineVPosition + 2 );
							g.DrawLine( pen, leftEdge  + 1, lineVPosition - 2, leftEdge  + 1, lineVPosition + 1 );
							g.DrawLine( pen, rightEdge    , lineVPosition - 3, rightEdge    , lineVPosition + 2 );
							g.DrawLine( pen, rightEdge - 1, lineVPosition - 2, rightEdge - 1, lineVPosition + 1 );
						}
						if( ( this._dropLinePosition & DropLinePositionEnum.BelowNode ) == DropLinePositionEnum.BelowNode ) {
							// �m�[�h�̉����ɐ��������܂��B
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
