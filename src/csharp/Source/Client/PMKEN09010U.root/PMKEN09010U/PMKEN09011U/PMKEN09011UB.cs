using System;
using System.Drawing;
using System.Collections;
using Infragistics.Win;
using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Application.Common
{
    #region RemoveFocusRectangleDrawFilter - Class

    /// <summary> 
    /// �v���[���e�[�V�����w�t���[�����[�N����{�Ƃ���R���g���[���ł́AAppearance �I�u�W�F�N�g
    /// �̗l�X�ȃv���p�e�B����ėv�f�̊O�ς��ȒP�ɐ���ł��܂��B�������A�R���g���[�����T�|�[�g���Ă��Ȃ�
    /// �`��𐧌䂵�����Ƃ����v�]������܂��B
    /// 
    /// �v���[���e�[�V�����w�t���[�����[�N����{�Ƃ��邷�ׂẴR���g���[���́A���Ƀt���L�V�u���Ŋg������
    /// �����`��t�B���^�[���J�j�Y����񋟂��Ă��܂��B���̕`��t�B���^�[���g�p���ăR���g���[���̊e
    /// UIElement �̕`����J�X�^�}�C�Y����ɂ́AIUIElementDrawFilter �C���^�t�F�[�X����������I�u�W�F�N�g
    /// ���쐬����K�v������܂��B
    /// �����āA���s���ɂ��̃I�u�W�F�N�g���R���g���[���� DrawFilter �v���p�e�B�ɐݒ肵�܂��B
    /// 
    /// ���̃T���v���ł́AUltraWinTree �̃m�[�h���I�����ꂽ�Ƃ��Ƀt�H�[�J�X�g��\�����Ȃ��悤�ɂ���`��
    /// �t�B���^�[���g�p���܂��B
    /// 
    /// </summary>
    public class RemoveFocusRectangleDrawFilter : IUIElementDrawFilter
    {
        #region IUIElementDrawFilter Members

        #region GetPhasesToFilter

        /// <summary>
        /// ���̃��\�b�h�ɂ� UIElementDrawParams �Ƃ����\���̂��n����A���\�b�h����� DrawPhase �̗񋓎q��
        /// �������r�b�g�t���O��Ԃ��܂��B
        /// UIElementDrawParams �\���̂́A�`�摀����T�|�[�g����Graphics�ABackBrush�ADrawBorders
        /// �Ȃǂ̃��\�b�h��v���p�e�B�ƂƂ��ɁA�`�悪�K�p����� UIElement ��Ԃ��v���p�e�B�����J���Ă��܂��B
        /// DrawPhase �r�b�g�t���O�́A���݂��� UIElement �ɑ΂���`�摀�삪�ǂ̂悤�Ȓi�K�i�t�F�[�Y�j�ɂ���
        /// �̂��������܂��B(�ȉ��̃R�[�h�ɂ��� DrawElement ���\�b�h�́AGetPhasesToFilter ���\�b�h����Ԃ�
        /// ���r�b�g�t���O�������t�F�[�Y���ɌĂяo����܂��B)
        /// 
        /// DrawPhase �̗񋓎q�ɂ���āA�w�i�A�C���[�W�w�i�A���E���A�����F�A�C���[�W�̎q UIElement �Ȃǂ�
        /// �ւ��e UIElement �̕`�揈���̑O����t�B���^�[�ł��܂��B
        /// </summary>
        DrawPhase IUIElementDrawFilter.GetPhasesToFilter(ref UIElementDrawParams drawParams)
        {
            // �t�H�[�J�X�g���`�悳��钼�O�̃t�F�[�Y���g���b�v���܂��B
            return Infragistics.Win.DrawPhase.BeforeDrawFocus;
        }

        #endregion GetPhasesToFilter

        #region DrawElement

        /// <summary>
        /// ���̃��\�b�h�ɂ� GetPhasesToFilter() ���\�b�h�Ɠ��� UIElementDrawParams �\���̂̕ϐ��ƁA�ǂ̃t�F�[�Y
        /// �̕`�悪�s���Ă���̂������� DrawPhase �r�b�g�t���O���n����܂��B
        /// ���̃��\�b�h����̓u�[���l��Ԃ��܂��B
        /// false ��Ԃ��ƁA���̃t�F�[�Y�̃f�t�H���g�̕`�揈�������s����܂��B'Before' �t�F�[�Y�̏ꍇ�� true ��Ԃ�
        /// �ƁA�f�t�H���g�̕`�揈���͎��s����܂���B�����FBeforeDrawElement �t�F�[�Y�̏ꍇ�� true ��Ԃ��ƁA����
        /// �S�Ă̕`�揈�����X�L�b�v����܂��B���Ƃ��� GetPhasesToFilter ���\�b�h�������̃t�F�[�Y�������r�b�g�t���O
        /// ��Ԃ����Ƃ��Ă��X�L�b�v�����̂Œ��ӂ��Ă��������B
        /// �܂��A�e�[�}�\�����L���ɂȂ��Ă���Ƃ��ABeforeDrawTheme �t�F�[�Y�� true ��Ԃ��Ƃ��ׂĂ̕`�揈�����X�L�b�v
        /// ����܂����ABeforeDrawChildElements �t�F�[�Y�����̓X�L�b�v����܂���B
        /// </summary>
        bool IUIElementDrawFilter.DrawElement(DrawPhase drawPhase, ref UIElementDrawParams drawParams)
        {
            // false ��Ԃ��ƃf�t�H���g�̕`�揈�������s����܂��B
            // true ��Ԃ��ƃf�t�H���g�̕`�揈�������s����܂���B
            return true;
        }

        #endregion DrawElement

        #endregion IUIElementDrawFilter Members
    };

    #endregion CustomColorNodeTextDrawFilter - Class
}
