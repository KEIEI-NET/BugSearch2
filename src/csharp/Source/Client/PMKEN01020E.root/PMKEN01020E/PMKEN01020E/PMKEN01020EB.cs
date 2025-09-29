using System;

namespace Broadleaf.Application.Controller
{
    /// <summary>�����^�C�v</summary>
    public enum SearchType
    {
        /// <summary>���S��v����</summary>
        WholeWord = 0,
        /// <summary>�O����v����</summary>
        PrefixSearch = 1,
        /// <summary>�����v����</summary>
        SuffixSearch = 2,
        /// <summary>�B������</summary>
        FreeSearch = 3,
        /// <summary>�n�C�t���������S��v</summary>
        WholeWordWithNoHyphen = 4,
    }

    /// <summary>��������</summary>
    public enum SearchFlag
    {
        // BL�����p�t���O
        /// <summary>���g�p�t���O[����BL�R�[�h�����D��Ɠ���]</summary>
        NoPrimeBlSearchFlag = 0,
        /// <summary>���g�p�t���O[����BL�R�[�h�����D��Ɠ���]</summary>
        NoPrimeBlSearch = 0,
        /// <summary>����BL�R�[�h�����D��</summary>
        BlSearch = 0,
        /// <summary>�D��BL�R�[�h�����D��</summary>
        PrimeBlSearch = 1,

        // �i�Ԍ����p�t���O
        /// <summary>���i���̂�[�񋟁^�D��] [���i�}�X�����p]</summary>
        GoodsInfoOnly = 2,
        /// <summary>���i���y�уZ�b�g���[�񋟁^�D��]</summary>
        GoodsAndSetInfo = 3,
        /// <summary>�i�Ԍ�������[�񋟁^�D��]</summary>
        PartsNoJoinSearch = 4,
        /// <summary>�i�Ԍ�������[��֊�]</summary>
        PartsNoJoinSearchSubst = 5,
    }

    /// <summary>����\��UI�w��t���O</summary>
    public enum SelectUIKind
    {
        /// <summary>�w��Ȃ�</summary>
        None = 0,
        /// <summary>��֑I��UI�w��</summary>
        Subst = 1,
        /// <summary>�����I��UI�w��</summary>
        Join = 2,
        /// <summary>�Z�b�g�I��UI�w��</summary>
        Set = 3,
        /// <summary>����i�ԑI��UI�w��[���������p]</summary>
        SamePartsNo = 4,
        /// <summary>���i�I��UI�w��[���������p]</summary>
        PartsSelection = 5,
        /// <summary>�D�Ǖ��i�I��UI�w��[���������p]</summary>
        PrimeSearchParts = 6
    }

    /// <summary>���i�敪</summary>
    public enum GoodsKind
    {
        /// <summary>�w��Ȃ��̕��i</summary>
        NotDesignated = 0,
        /// <summary>�����E�Z�b�g�E��ւ̌��ɂȂ镔�i(�f�t�H���g)</summary>
        Parent = 1,
        /// <summary>������̕��i</summary>
        Join = 2,
        /// <summary>�Z�b�g�q���i</summary>
        Set = 4,
        /// <summary>��֐�̕��i</summary>
        Subst = 8,
        /// <summary>������֐�i�݊��j���i</summary>
        SubstPlrl = 16
    }

    // ===================================================================================== //
    // �\����
    // ===================================================================================== //
    #region Struct
    /// <summary>
    /// �D�ǐݒ�}�X�^�L�[�\����
    /// </summary>
    public struct PrmSettingKey
    {
        string _sectionCode;
        int _goodsMGroup;
        int _tbsPartsCode;
        int _partsMakerCd;

        /// <summary>
        /// �D�ǐݒ�}�X�^�L�[�\����
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="goodsMGroup"></param>
        /// <param name="tbsPartsCode"></param>
        /// <param name="partsMakerCd"></param>
        public PrmSettingKey(string sectionCode, int goodsMGroup, int tbsPartsCode, int partsMakerCd)
        {
            this._sectionCode = sectionCode;
            this._goodsMGroup = goodsMGroup;
            this._tbsPartsCode = tbsPartsCode;
            this._partsMakerCd = partsMakerCd;
        }
    }

    /// <summary>
    /// �i�ԕ��������p�����N���X
    /// </summary>
    public class SrchCond
    {
        /// <summary>���[�J�[�R�[�h</summary>
        public int makerCd;
        /// <summary>�i��</summary>
        public string partsNo = string.Empty;
    }
    # endregion
}
