using System;
using System.Drawing;
using System.Collections;
using Infragistics.Win;
using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Application.Common
{
    #region RemoveFocusRectangleDrawFilter - Class

    /// <summary> 
    /// プレゼンテーション層フレームワークを基本とするコントロールでは、Appearance オブジェクト
    /// の様々なプロパティを介して要素の外観を簡単に制御できます。しかし、コントロールがサポートしていない
    /// 描画を制御したいという要望もあります。
    /// 
    /// プレゼンテーション層フレームワークを基本とするすべてのコントロールは、非常にフレキシブルで拡張性の
    /// 高い描画フィルターメカニズムを提供しています。この描画フィルターを使用してコントロールの各
    /// UIElement の描画をカスタマイズするには、IUIElementDrawFilter インタフェースを実装するオブジェクト
    /// を作成する必要があります。
    /// そして、実行時にこのオブジェクトをコントロールの DrawFilter プロパティに設定します。
    /// 
    /// このサンプルでは、UltraWinTree のノードが選択されたときにフォーカス枠を表示しないようにする描画
    /// フィルターを使用します。
    /// 
    /// </summary>
    public class RemoveFocusRectangleDrawFilter : IUIElementDrawFilter
    {
        #region IUIElementDrawFilter Members

        #region GetPhasesToFilter

        /// <summary>
        /// このメソッドには UIElementDrawParams という構造体が渡され、メソッドからは DrawPhase の列挙子で
        /// 示されるビットフラグを返します。
        /// UIElementDrawParams 構造体は、描画操作をサポートするGraphics、BackBrush、DrawBorders
        /// などのメソッドやプロパティとともに、描画が適用される UIElement を返すプロパティを公開しています。
        /// DrawPhase ビットフラグは、現在この UIElement に対する描画操作がどのような段階（フェーズ）にある
        /// のかを示します。(以下のコードにある DrawElement メソッドは、GetPhasesToFilter メソッドから返さ
        /// れるビットフラグが示すフェーズ毎に呼び出されます。)
        /// 
        /// DrawPhase の列挙子によって、背景、イメージ背景、境界線、文字色、イメージの子 UIElement などに
        /// 関わる各 UIElement の描画処理の前後をフィルターできます。
        /// </summary>
        DrawPhase IUIElementDrawFilter.GetPhasesToFilter(ref UIElementDrawParams drawParams)
        {
            // フォーカス枠が描画される直前のフェーズをトラップします。
            return Infragistics.Win.DrawPhase.BeforeDrawFocus;
        }

        #endregion GetPhasesToFilter

        #region DrawElement

        /// <summary>
        /// このメソッドには GetPhasesToFilter() メソッドと同じ UIElementDrawParams 構造体の変数と、どのフェーズ
        /// の描画が行われているのかを示す DrawPhase ビットフラグが渡されます。
        /// このメソッドからはブール値を返します。
        /// false を返すと、このフェーズのデフォルトの描画処理が実行されます。'Before' フェーズの場合に true を返す
        /// と、デフォルトの描画処理は実行されません。メモ：BeforeDrawElement フェーズの場合に true を返すと、他の
        /// 全ての描画処理がスキップされます。たとえば GetPhasesToFilter メソッドから特定のフェーズを示すビットフラグ
        /// を返したとしてもスキップされるので注意してください。
        /// また、テーマ表示が有効になっているとき、BeforeDrawTheme フェーズで true を返すとすべての描画処理がスキップ
        /// されますが、BeforeDrawChildElements フェーズだけはスキップされません。
        /// </summary>
        bool IUIElementDrawFilter.DrawElement(DrawPhase drawPhase, ref UIElementDrawParams drawParams)
        {
            // false を返すとデフォルトの描画処理が実行されます。
            // true を返すとデフォルトの描画処理が実行されません。
            return true;
        }

        #endregion DrawElement

        #endregion IUIElementDrawFilter Members
    };

    #endregion CustomColorNodeTextDrawFilter - Class
}
